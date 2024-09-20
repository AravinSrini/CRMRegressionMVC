using CRM.UITest.Objects;
using Rrd.Dls.IdentityServer.Core.Dto;
using Rrd.ServiceAccessLayer;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Entities;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using CRM.UITest.Helper.Implementations.QuoteList;
using CRM.UITest.Helper.ViewModel.RateModel;
using CRM.UITest.Helper.Interfaces.Quote;
using CRM.UITest.CsaServiceReference;
using System.Threading;

namespace CRM.UITest.Scripts.Quote_List.QuoteList_InternalUsers
{
    [Binding]
    public class QuoteList_CustomerSelection_StationUsersSteps : Quotelist
    {
        string errorMessage = string.Empty;

        [When(@"I click on customer drop down list")]
        public void WhenIClickOnCustomerDropDownList()
        {
            Report.WriteLine("Clicking on customer dropdown list");
            Click(attributeName_xpath, QuoteList_CustomerDropdown_Xpath);
            
        }
                
        [Then(@"list of customers in which I am associated will be displayed and should match with API (.*)")]
        public void ThenListOfCustomersInWhichIAmAssociatedWillBeDisplayedAndShouldMatchWithAPI(string Username)
        {
            Thread.Sleep(8000);
            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);
            List<AppUserClaimInfo> AllClaimDetails = IDP.GetUserClaimDetails(Username);
            List<string> setClaimDetails = AllClaimDetails.Where(c => c.ClaimType == "dlscrm-StationId").Select(a => a.ClaimValue).ToList();
            List<string> ExpAcc = new List<string>();

            for (int i = 0; i < setClaimDetails.Count; i++)
            {
                string setupId = setClaimDetails[i];
                List<CustomerSetup> value = DBHelper.GetRecordsMappedforStationID(setupId);

                for (int j = 0; j < value.Count; j++)
                {
                    string custname = value[j].CustomerName;
                    ExpAcc.Add(custname);
                }               
             }

            int UICount = GetCount(attributeName_xpath, QuoteList_CustomerDropdownList_Xpath);
            Assert.AreEqual(ExpAcc.Count +1, UICount);
            Report.WriteLine("Displaying Customer account list count is matching with DB count");

            IList<IWebElement> values = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_CustomerDropdownList_Xpath));

            for ( int k = 1; k <values.Count; k++)
            {
                if(ExpAcc.Contains(values[k].Text))
                {
                    Report.WriteLine("Displaying Customer account " + values[k].Text + " is mapped to logged in user");
                }
                else
                {
                    Report.WriteLine("Displaying Customer account " + values[k].Text + " is not mapped to logged in user");
                    Assert.IsTrue(false);
                }
            }

          }
        
        [Then(@"All Customers option should be selected by default")]
        public void ThenAllCustomersOptionShouldBeSelectedByDefault()
        {
            Report.WriteLine("Verifying default selected customer account");
            string actText = Gettext(attributeName_xpath, QuoteList_CustomerDropdown_Label_Xpath);
            Assert.AreEqual(actText, "All Customers");
        }

        [Then(@"all the associated customers past (.*) days quotes should be displayed and should match with API (.*)")]
        public void ThenAllTheAssociatedCustomersPastDaysQuotesShouldBeDisplayedAndShouldMatchWithAPI(int p0, string stationData)
        {
            Thread.Sleep(1000);
            string[] values = stationData.Split(',');
            List<string> StatID = new List<string>();
            List<String> QuoteList = new List<string>();

            foreach (var v in values)
            {
                StatID.Add(v);
            }
            IMgQuoteListForSalesUser MGQuotes = new MgQuoteListForSalesUser();

            for (int i = 0; i < StatID.Count; i++)
            {
                CustomerSetup value = DBHelper.GetStationDetailsById(StatID[i]);
                List<QuoteListExtractModel> QModel = MGQuotes.GetMgQuoteList(value.MgAccountNumber, false);

                if (QModel != null)
                {
                    for (int j = 0; j < QModel.Count; j++)
                    {
                        QuoteList.Add(QModel[j].QuoteReferenceNumber);
                    }
                }
                else
                {
                    Report.WriteLine("Not received any reposnse from API for Station ID: " + StatID[i]);
                }

                    string data = DBHelper.GetStationNameonStationID(StatID[i]);
                    List<CustomerAccount> listvalue = DBHelper.GetAccountsMappedforStation(data);

                    for (int k = 0; k < listvalue.Count; k++)
                {
                    if(listvalue[k].TmsSystem == "CSA" || listvalue[k].TmsSystem == "BOTH")
                    {
                        ICsaQuoteListByLast30Days CSAQuote = new CsaQuoteListByLast30Days();
                        ShipmentListReponse APIQuotes = CSAQuote.GetCsaQuoteListByLast30Days(Convert.ToInt32(listvalue[k].CsaCustomerNumber), out errorMessage);

                        List<int> QuotesValue = APIQuotes.Shipments.Select(a => a.ShipQuoteNo).ToList();             

                        foreach (var t in QuotesValue)
                        {
                            QuoteList.Add(Convert.ToString(t));
                        }
                    }
                }
            }

            IList<IWebElement> UIQuotes = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_RequestNumberInternal_Values_Xpath));
            List<string> UIValue = new List<string>();

            if (QuoteList.Count > 1)
            {

                for (int k = 0; k < UIQuotes.Count; k++)
                {
                    string UIQuoteNumber = UIQuotes[k].Text;
                    UIValue.Add(UIQuoteNumber);
                }

                Assert.AreEqual(QuoteList.Count, UIValue.Count);
                Report.WriteLine("Displaying default quote list in the UI is matching with API results");
            }
            else
            {
                Report.WriteLine("No quotes exists for the selected account");
            }

        }

        [Then(@"all the associated MG quotes for the selected customer past (.*) days should be displayed and should match with API (.*)")]
        public void ThenAllTheAssociatedMGQuotesForTheSelectedCustomerPastDaysShouldBeDisplayedAndShouldMatchWithAPI(int p0, string Account)
        {
            Thread.Sleep(10000);
            List<string> QuoteList = new List<string>();
            IMgQuoteListForSalesUser MGQuotes = new MgQuoteListForSalesUser();

            List<QuoteListExtractModel> QModel = MGQuotes.GetMgQuoteList(Account, true);

            if (QModel != null)
            {
                for (int j = 0; j < QModel.Count; j++)
                {
                    QuoteList.Add(QModel[j].QuoteReferenceNumber);
                }
            

            IList<IWebElement> UIQuotes = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_RequestNumberInternal_Values_Xpath));
            List<string> UIValue = new List<string>();

            for (int k = 0; k < UIQuotes.Count; k++)
            {
                string UIQuoteNumber = UIQuotes[k].Text;
                UIValue.Add(UIQuoteNumber);
            }
            CollectionAssert.AreEqual(QuoteList.OrderBy(q => q).ToList(), UIValue.OrderBy(q => q).ToList());
            Report.WriteLine("Displaying default quote list in the UI is matching with API results");
           }
            else
            {
                VerifyElementPresent(attributeName_xpath, QuoteList_NoResults_Xpath, "No Results");
                Report.WriteLine("No quotes exists for the selected account");
            }
        }


        [Then(@"all the associated CSA quotes for the selected customer past (.*) days should be displayed and should match with API (.*)")]
        public void ThenAllTheAssociatedCSAQuotesForTheSelectedCustomerPastDaysShouldBeDisplayedAndShouldMatchWithAPI(int p0, string Account)
        {
            Thread.Sleep(10000);
            int accID = DBHelper.GetAccountIdforAccountName(Account.Trim());
            CustomerAccount value = DBHelper.GetAccountDetails(accID);
            int csaNumb = Convert.ToInt32(value.CsaCustomerNumber);

            ICsaQuoteListByLast30Days CSAQuote = new CsaQuoteListByLast30Days();
            ShipmentListReponse APIQuotes = CSAQuote.GetCsaQuoteListByLast30Days(csaNumb, out errorMessage);

            List<int> QuotesValue = APIQuotes.Shipments.Select(a => a.ShipQuoteNo).ToList();
            List<string> CSAQuotes = new List<string>();
             
            foreach(int i in QuotesValue)
            {
                CSAQuotes.Add(Convert.ToString(i));
            }

            IList<IWebElement> UIQuotes = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_RequestNumberInternal_Values_Xpath));
            List<string> UIValue = new List<string>();

            if (CSAQuotes.Count >= 1)
            {

                for (int j = 0; j < UIQuotes.Count; j++)
                {
                    string UIQuoteNumber = UIQuotes[j].Text;
                    UIValue.Add(UIQuoteNumber);
                }


                CollectionAssert.AreEqual(CSAQuotes.OrderBy(q => q).ToList(), UIValue.OrderBy(q => q).ToList());
                Report.WriteLine("Displaying CSA quotes in the UI is matching with API results");
            }
            else
            {
                Report.WriteLine("No quotes exists for the selected account");
            }
        }

        [Then(@"all the associated Both TMS quotes for the selected customer past (.*) days should be displayed and should match with API  (.*)")]
        public void ThenAllTheAssociatedBothTMSQuotesForTheSelectedCustomerPastDaysShouldBeDisplayedAndShouldMatchWithAPI(int p0, string Account)
        {
            Thread.Sleep(10000);
            List<string> QuoteList = new List<string>();
            IMgQuoteListForSalesUser MGQuotes = new MgQuoteListForSalesUser();

            List<QuoteListExtractModel> QModel = MGQuotes.GetMgQuoteList(Account, true);

            if (QModel != null)
            {
                for (int j = 0; j < QModel.Count; j++)
                {
                    QuoteList.Add(QModel[j].QuoteReferenceNumber);
                }
            }
            else
            {
                Report.WriteLine("Not received any reposnse from API for Selected Account");
            }

            int accID = DBHelper.GetAccountIdforAccountName(Account);
            CustomerAccount value = DBHelper.GetAccountDetails(accID);
            int csaNumb = Convert.ToInt32(value.CsaCustomerNumber);

            ICsaQuoteListByLast30Days CSAQuote = new CsaQuoteListByLast30Days();
            ShipmentListReponse CSAAPIQuotes = CSAQuote.GetCsaQuoteListByLast30Days(csaNumb, out errorMessage);

            List<int> QuotesValue = CSAAPIQuotes.Shipments.Select(a => a.ShipQuoteNo).ToList();

            foreach (int i in QuotesValue)
            {
                QuoteList.Add(Convert.ToString(i));
            }

            IList<IWebElement> UIQuotes = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_RequestNumberInternal_Values_Xpath));
            List<string> UIValue = new List<string>();
            

            if (UIQuotes.Count > 1 && QuoteList.Count > 1)
            {
                for (int j = 0; j < UIQuotes.Count; j++)
                {
                    string UIQuoteNumber = UIQuotes[j].Text;
                    UIValue.Add(UIQuoteNumber);
                }
                CollectionAssert.AreEqual(QuoteList.OrderBy(q => q).ToList(), UIValue.OrderBy(q => q).ToList());

                Report.WriteLine("Displaying quotes in the UI is matching with API results");
            }
            else
            {
                Report.WriteLine("No quotes exists for the selected account");
            }
         }

        [Then(@"recently selected (.*) only should be binded")]
        public void ThenRecentlySelectedOnlyShouldBeBinded(string Account)
        {
            Report.WriteLine("Verifying the recently selected customer account");
            string actText = Gettext(attributeName_xpath, QuoteList_CustomerDropdown_Label_Xpath);
            if(actText.Contains(Account))
            {
                Report.WriteLine("Recently selected customer account is binding");
            }
            else
            {
                Report.WriteLine("Recently selected customer account is not binding");
                Assert.IsTrue(false);
            }
        }

        [When(@"I select All customers from the dropdown")]
        public void WhenISelectAllCustomersFromTheDropdown()
        {
            Click(attributeName_xpath, QuoteList_ClickCustomerDropdown_xpath);
            SelectDropdownValueFromList(attributeName_xpath, QuoteList_CustomerDropdownList_Xpath, "All Customers");
            Thread.Sleep(2000);
        }

        [Then(@"quote list grid should be empty")]
        public void ThenQuoteListGridShouldBeEmpty()
        {
            VerifyElementPresent(attributeName_xpath, QuoteList_NoResults_Xpath, "No Results");
            Report.WriteLine("Quote list grid is empty since logged in user station does not have any accounts");
        }

        [Then(@"message will be displayed in grid section along with (.*) name")]
        public void ThenMessageWillBeDisplayedInGridSectionAlongWithName(string Account)
        {
            string actMessage = "There are no quotes within the past 30 days for the selected customer " + Account;
            string expMessage = Gettext(attributeName_xpath, QuoteList_NoResults_Xpath);
            Assert.AreEqual(actMessage, expMessage);
        }

        [Then(@"list of quotes displaying and should match with API (.*)")]
        public void ThenListOfQuotesDisplayingAndShouldMatchWithAPI(string Username)
        {
            Thread.Sleep(10000);
            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);
            List<AppUserClaimInfo> abc = IDP.GetUserClaimDetails(Username);
            string setupID = IDP.GetClaimValue(Username, "dlscrm-CustomerSetUpId");
            int value = Convert.ToInt32(setupID);

            CustomerSetup data = DBHelper.GetSetupDetails(value);

            IGetQuoteList list = new GetQuoteList();
            List<QuoteListExtractModel> rModel = list.GetMgQuotes(data.CustomerName, out errorMessage);
            List<string> MGAPIQuotes = new List<string>();

            if (rModel != null)
            {

                for (int i = 0; i < rModel.Count; i++)
                {
                    string QuoteNumber = rModel[i].QuoteReferenceNumber;
                    MGAPIQuotes.Add(QuoteNumber);
                }

                IList<IWebElement> UIQuotes = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_RequestNumberAll_Values_Xpath));
                List<string> UIValue = new List<string>();


                if (UIQuotes.Count > 1 && MGAPIQuotes.Count > 1)
                {
                    for (int j = 0; j < UIQuotes.Count; j++)
                    {
                        string UIQuoteNumber = UIQuotes[j].Text;
                        UIValue.Add(UIQuoteNumber);
                    }
                    CollectionAssert.AreEqual(MGAPIQuotes.OrderBy(q => q).ToList(), UIValue.OrderBy(q => q).ToList());
                    Report.WriteLine("Displaying MG quotes in the UI is matching with API results");
                }
            }
            else
            {
                VerifyElementPresent(attributeName_xpath, QuoteList_NoResults_Xpath, "No Records");
                Report.WriteLine("No quotes exists for the selected account");
            }

        }

    }
}
