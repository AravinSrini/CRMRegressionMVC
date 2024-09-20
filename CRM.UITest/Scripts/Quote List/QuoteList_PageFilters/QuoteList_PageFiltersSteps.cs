using CRM.UITest.CommonMethods;
using CRM.UITest.CsaServiceReference;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.Implementations.QuoteList;
using CRM.UITest.Helper.Interfaces.Quote;
using CRM.UITest.Helper.ViewModel.RateModel;
using CRM.UITest.Objects;
using CRM.UITest.Scripts.Quote_List.QuoteList_InternalUsers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.QuoteList_InternalUsers
{
    [Binding]
    public class QuoteList_PageFiltersSteps : Quotelist
    {
        string errorMessage = null;
        string usertype = string.Empty;

        [When(@"I select New filter radio button in quote list page")]
        public void WhenISelectNewFilterRadioButtonInQuoteListPage()
        {
            Report.WriteLine("Selecting New filter radio button");
            Click(attributeName_id, QuoteList_NewRadioButton_Id);
        }
        
        [When(@"I select Expired filter radio button in quote list page")]
        public void WhenISelectExpiredFilterRadioButtonInQuoteListPage()
        {
            Report.WriteLine("Selecting Expired filter radio button");
            Click(attributeName_id, QuoteList_ExpiredButton_Id);
        }
        
        [When(@"I select past (.*) hours filter radio button in quote list page")]
        public void WhenISelectPastHoursFilterRadioButtonInQuoteListPage(int p0)
        {
            Report.WriteLine("Selecting Expired filter radio button");
            Click(attributeName_id, QuoteList_Past24Hours_Id);
        }
        
        [Then(@"all filter radio button should be selected by default in quote list page")]
        public void ThenAllFilterRadioButtonShouldBeSelectedByDefaultInQuoteListPage()
        {
            Report.WriteLine("Verifying default selected filter radio button");
            VerifyElementChecked(attributeName_id, QuoteList_AllRadioButton_Id, "All Radio Button");
            Report.WriteLine("All filter radio button is selected by default");
        }


        [Then(@"only new quote records should be filtered and displaying results should match with API results for the new records for (.*)")]
        public void ThenOnlyNewQuoteRecordsShouldBeFilteredAndDisplayingResultsShouldMatchWithAPIResultsForTheNewRecordsFor(string Account)
        {
            Thread.Sleep(10000);
            List<string> QuoteList = new List<string>();
            IGetQuoteList MGQuotes = new GetQuoteList();

            List<QuoteListExtractModel> QModel = MGQuotes.GetMgQuotes(Account, out errorMessage);

            if (QModel != null)
            {
                for (int j = 0; j < QModel.Count; j++)
                {
                    TimeSpan data = DateTime.Now - (Convert.ToDateTime(QModel[j].CreatedDate));
                    double diff = data.TotalMinutes;
                    if (diff < (24 * 60))
                    {
                        QuoteList.Add(QModel[j].QuoteReferenceNumber);
                    }
                    else
                    {
                        Report.WriteLine(QModel[j].QuoteReferenceNumber + "is not new Quote");
                    }
                }

                IList<IWebElement> UIQuotes = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_RequestNumberAll_Values_Xpath));
                List<string> UIValue = new List<string>();

                    for (int j = 0; j < UIQuotes.Count; j++)
                    {
                        string UIQuoteNumber = UIQuotes[j].Text;
                        UIValue.Add(UIQuoteNumber);
                    }
                    CollectionAssert.AreEqual(QuoteList.OrderBy(q => q).ToList(), UIValue.OrderBy(q => q).ToList());
                    Report.WriteLine("Displaying new quotes in the UI is matching with API results");
            }
            else
            {
                VerifyElementPresent(attributeName_xpath, QuoteList_NoResults_Xpath, "NoRecordsFound");
                Report.WriteLine("No quotes exists for the selected filter");
            }
        }

        [Then(@"only expired quote records should be filtered and displaying results should match with API results for the expired records (.*)")]
        public void ThenOnlyExpiredQuoteRecordsShouldBeFilteredAndDisplayingResultsShouldMatchWithAPIResultsForTheExpiredRecords(string Account)
        {
            Thread.Sleep(10000);
            List<string> QuoteList = new List<string>();
            IGetQuoteList MGQuotes = new GetQuoteList();

            List<QuoteListExtractModel> QModel = MGQuotes.GetMgQuotes(Account, out errorMessage);
            if (QModel != null)
            {
                for (int j = 0; j < QModel.Count; j++)
                {
                    if (QModel[j].PickUpDate != null && DateTime.Compare(Convert.ToDateTime(QModel[j].PickUpDate), DateTime.Today) < 0)
                    {
                        QuoteList.Add(QModel[j].QuoteReferenceNumber);
                    }
                    else
                    {
                        Report.WriteLine(QModel[j].QuoteReferenceNumber + "is not Expired Quote");
                    }
                }
                IList<IWebElement> UIQuotes = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_RequestNumberAll_Values_Xpath));
                List<string> UIValue = new List<string>();

                for (int j = 0; j < UIQuotes.Count; j++)
                {
                    string UIQuoteNumber = UIQuotes[j].Text;
                    UIValue.Add(UIQuoteNumber);
                }
                CollectionAssert.AreEqual(QuoteList.OrderBy(q => q).ToList(), UIValue.OrderBy(q => q).ToList());
                Report.WriteLine("Displaying new quotes in the UI is matching with API results");
            }
            else
            {
                VerifyElementPresent(attributeName_xpath, QuoteList_NoResults_Xpath, "NoRecordsFound");
                Report.WriteLine("No quotes exists for the selected filter");
            }
        }

        [Then(@"only past (.*) hours quote records should be filtered and displaying results should match with API results for the past (.*) hours records (.*)")]
        public void ThenOnlyPastHoursQuoteRecordsShouldBeFilteredAndDisplayingResultsShouldMatchWithAPIResultsForThePastHoursRecords(int p0, int p1, string Account)
        {
            Thread.Sleep(10000);
            List<string> QuoteList = new List<string>();
            IGetQuoteList MGQuotes = new GetQuoteList();

            List<QuoteListExtractModel> QModel = MGQuotes.GetMgQuotes(Account, out errorMessage);
            if(QModel != null)
            { 
             for (int j = 0; j < QModel.Count; j++)
                {
                    TimeSpan data = DateTime.Now - (Convert.ToDateTime(QModel[j].CreatedDate));
                    if (data.Hours > 24 && QModel[j].QuoteAmount == "TBD")
                    {
                        QuoteList.Add(QModel[j].QuoteReferenceNumber);
                    }
                    else
                    {
                        Report.WriteLine(QModel[j].QuoteReferenceNumber + "is not past 24hours Quote");
                    }
            }

            IList<IWebElement> UIQuotes = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_RequestNumberAll_Values_Xpath));
            List<string> UIValue = new List<string>();

                for (int j = 0; j < UIQuotes.Count; j++)
                {
                    string UIQuoteNumber = UIQuotes[j].Text;
                    UIValue.Add(UIQuoteNumber);
                }
                CollectionAssert.AreEqual(QuoteList.OrderBy(q => q).ToList(), UIValue.OrderBy(q => q).ToList());
                Report.WriteLine("Displaying new quotes in the UI is matching with API results");
            }
            else
            {
                VerifyElementPresent(attributeName_xpath, QuoteList_NoResults_Xpath, "NoRecordsFound");
                Report.WriteLine("No quotes exists for the Past 24 hours filter");
            }
        }
        
        [Then(@"no records message should be displayed in the grid")]
        public void ThenNoRecordsMessageShouldBeDisplayedInTheGrid()
        {
            int count = GetCount(attributeName_xpath, QuoteList_NoResults_Xpath);
            if(count > 1)
            {
                Report.WriteLine("Records exists for the logged in user");
                Report.WriteLine("Unable to verify no records exists scenario");
            }
            else
            {
                string actMessage = "No Results Found";
                string expMessage = Gettext(attributeName_xpath, QuoteList_NoResults_Xpath);
                Assert.AreEqual(actMessage, expMessage);
                Report.WriteLine("No records are displaying for the selected filter option");
            }
        }

        [When(@"I now select any customeraccount (.*) from the dropdown")]
        public void WhenINowSelectAnyCustomeraccountFromTheDropdown(string Account)
        {
            if (usertype == "External")
            {
                Click(attributeName_xpath, QuoteList_CustomerDropdownNameDisplay_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, CustomerDropdownValesExtuser_Xpath, Account);
            }
            else
            {
                Click(attributeName_xpath, QuoteList_CustomerDropdownNameDisplay_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, QuoteList_CustomerDropdown_Label_Xpath, Account);
            }
            Report.WriteLine("Selected the associated customer");
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [When(@"I now Select past (.*) hours filter radio button in quote list page")]
        public void WhenINowSelectPastHoursFilterRadioButtonInQuoteListPage(int p0)
        {
            Report.WriteLine("Selecting 24 hours filter radio button");
            Click(attributeName_id, QuoteList_Past24Hours_Id);
        }

        [When(@"I now select any (.*) from view dropdown present in top grid of quote list page")]
        public void WhenINowSelectAnyFromViewDropdownPresentInTopGridOfQuoteListPage(string option)
        {
            Thread.Sleep(10000);
            Report.WriteLine("Select option from view dropdown");
            SelectDropdownlistvalue(attributeName_xpath, QuoteList_TopGrid_DisplayListDropdownOptions_Xpath, option);
        }

        [Then(@"only past (.*) hours of CSA and MG quote records should be filtered and the displayed results should match with API results for the past (.*) hours records (.*)")]
        public void ThenOnlyPastHoursOfCSAAndMGQuoteRecordsShouldBeFilteredAndTheDisplayedResultsShouldMatchWithAPIResultsForThePastHoursRecords(int p0, int p1, string Account)
        {
            //getting past 24 hours csa quotes
            int accID = DBHelper.GetAccountIdforAccountName(Account);
            CustomerAccount value = DBHelper.GetAccountDetails(accID);
            int csaNumb = Convert.ToInt32(value.CsaCustomerNumber);

            ICsaQuoteListByLast30Days CSAQuote = new CsaQuoteListByLast30Days();
            ShipmentListReponse csaLast30DaysQoteList = CSAQuote.GetCsaQuoteListByLast30Days(csaNumb, out errorMessage);
            DateTime currentDateAndTime = DateTime.UtcNow;
            List<string> mgAndCsaquotesCreatedin24Hrs = csaLast30DaysQoteList.Shipments.Where(b => b.CreatedDateTime > currentDateAndTime.AddHours(-24)).Select(a => a.ShipQuoteNo.ToString()).ToList();

            //getting past 24 hours mg quotes
            List<string> MGQuoteList = new List<string>();
            IGetQuoteList MGQuotes = new GetQuoteList();
            List<QuoteListExtractModel> QModel = MGQuotes.GetMgQuotes(Account, out errorMessage);
            if (QModel != null)
            {
                for (int j = 0; j < QModel.Count; j++)
                {
                    //TimeSpan data = now.Subtract(Convert.ToDateTime(QModel[j].CreatedDate));
                    TimeSpan data = DateTime.UtcNow - (Convert.ToDateTime(QModel[j].CreatedDate));
                    if (data.TotalHours < 24)
                    {
                        MGQuoteList.Add(QModel[j].QuoteReferenceNumber);
                    }
                    else
                    {
                        Report.WriteLine(QModel[j].QuoteReferenceNumber + "is not past 24hours Quote");
                    }
                }

            }

            //getting past 24 hours quotes in a single list
            mgAndCsaquotesCreatedin24Hrs.AddRange(MGQuoteList);
            mgAndCsaquotesCreatedin24Hrs.Sort();

            //getting past 24 hours from UI 
            IList<IWebElement> UIQuotes;
            if (usertype == "External")
            {
               UIQuotes = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_RequestNumberAll_Values_New_Xpath));
            }
            else
            {
               UIQuotes = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_RequestNumberInternal_Values_New_Xpath));
            }
            List<string> UIValue = new List<string>();

            for (int j = 0; j < UIQuotes.Count; j++)
            {
                string UIQuoteNumber = UIQuotes[j].Text;
                UIValue.Add(UIQuoteNumber);
            }
            UIValue.Sort();

            //comparing both lists   
            if (mgAndCsaquotesCreatedin24Hrs != null)
            {
                CollectionAssert.AreEqual(mgAndCsaquotesCreatedin24Hrs, UIValue);
                Report.WriteLine("Displaying new quotes in the UI is matching with API results");
            }
            else
            {
                string no24HourQuoteText = Gettext(attributeName_xpath, QuoteList_NoResults_Xpath);
                Assert.AreEqual("NoRecordsFound", no24HourQuoteText);
                Report.WriteLine("No quotes exists for the Past 24 hours filter");
            }
        }

        [Given(@"I am a user with access to Quote List Page (.*)")]
        public void GivenIAmAUserWithAccessToQuoteListPage(string user)
        {
            usertype = user;
            if (user == "External")
            {
                string username = ConfigurationManager.AppSettings["username-Both"].ToString();
                string password = ConfigurationManager.AppSettings["password-Both"].ToString();
                CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
                CrmLogin.LoginToCRMApplication(username, password);
            }
            else if (user == "Internal")
            {
                string username = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
                string password = ConfigurationManager.AppSettings["password-crmOperation"].ToString();
                CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
                CrmLogin.LoginToCRMApplication(username, password);
            }
            else if (user == "Sales")
            {
                string username = ConfigurationManager.AppSettings["username-salesdelta"].ToString();
                string password = ConfigurationManager.AppSettings["password-salesdelta"].ToString();
                CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
                CrmLogin.LoginToCRMApplication(username, password);
            }
        }

    }
}
