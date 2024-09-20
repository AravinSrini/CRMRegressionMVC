using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.CsaServiceReference;
using CRM.UITest.Helper.Common;
using CRM.UITest.Helper.Implementations.ShipmentList;
using CRM.UITest.Helper.Interfaces.Shipment;
using CRM.UITest.Helper.ViewModel.Shipment;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;

namespace CRM.UITest.Scripts.Quote_List.QuoteList_ExternalUsers
{
    [Binding]
    public class RateRequest_AllowCustomerUsersAccessToSub_Accounts_QuoteListGridSteps : Quotelist
    {
        string errorMessage = string.Empty;

        [Given(@"I am a shp\.entry or shp\.inquiry user associated to a primary account that has sub-accounts")]
        public void GivenIAmAShp_EntryOrShp_InquiryUserAssociatedToAPrimaryAccountThatHasSub_Accounts()
        {
            string username = ConfigurationManager.AppSettings["username-ExtuserCustDropdown"].ToString();
            string password = ConfigurationManager.AppSettings["password-ExtuserCustDropdown"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"I am a shp\.entry or shp\.inquiry user associated to a primary account that has sub-accounts with zzzcsastage")]
        public void GivenIAmAShp_EntryOrShp_InquiryUserAssociatedToAPrimaryAccountThatHasSub_AccountsWithZzzcsastage()
        {
            string username = "zzzcsa@stage.com";
            string password = "Te$t1234";
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"I select All Customers from the customer drop down list")]
        public void GivenISelectAllCustomersFromTheCustomerDropDownList()
        {
            Report.WriteLine("selecting All Customers from the customer drop down list");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, CustomerDropdownExtuser_Xpath);
            SelectDropdownValueFromList(attributeName_xpath,CustomerDropdownValesExtuser_Xpath, "All Customers");            
        }

        [When(@"I myself select All Customers from the customer drop down list")]
        public void WhenIMyselfSelectAllCustomersFromTheCustomerDropDownList()
        {
            Report.WriteLine("selecting All Customers from the customer drop down list");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, CustomerDropdownExtuser_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, CustomerDropdownValesExtuser_Xpath, "All Customers");
        }        

        [Given(@"I select sub-Customer of MG or Both from the customer drop down list (.*)")]
        public void GivenISelectSub_CustomerOfMGOrBothFromTheCustomerDropDownList(string customerName)
        {
            Report.WriteLine("selecting sub-Customer of MG or Both from the customer drop down list");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, CustomerDropdownExtuser_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, CustomerDropdownValesExtuser_Xpath, "36691 Scenario1 Subacc");
        }

        [When(@"I select All Customers from the customer drop down list")]
        public void WhenISelectAllCustomersFromTheCustomerDropDownList()
        {
            Report.WriteLine("selecting All Customers from the customer drop down list");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, CustomerDropdownExtuser_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, CustomerDropdownValesExtuser_Xpath, "All Customers");
        }

        [When(@"I expand the quote details of any displayed quote")]
        public void WhenIExpandTheQuoteDetailsOfAnyDisplayedQuote()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_xpath, QuoteList_SearchBox_Xpath, "LTL");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, QuoteList_NewLabel_Xpath);
            //Click(attributeName_xpath, QuoteListPageSelectAll);
            int quoteListCount = GetCount(attributeName_xpath, QuoteList_AllNoOfRecords_xpath);
            if (quoteListCount > 1)
            {
                Report.WriteLine("Expand the first new LTL Quote in the Quote List ");
                Click(attributeName_xpath, QuoteList_TopGrid_expandquote_Xpath);
                GlobalVariables.webDriver.WaitForPageLoad();
            }
        }

        [When(@"I select primary customer of MG or both  from the customer drop down list (.*)")]
        public void WhenISelectPrimaryCustomerOfMGOrBothFromTheCustomerDropDownList(string Customer)
        {
            Report.WriteLine("selecting sub-Customer of MG or Both from the customer drop down list");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, CustomerDropdownExtuser_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, CustomerDropdownValesExtuser_Xpath, Customer);
        }

        [When(@"I select Sub-customer of MG or both  from the customer drop down list (.*),(.*)")]
        public void WhenISelectSub_CustomerOfMGOrBothFromTheCustomerDropDownList(string Customer, string tmsType)
        {
            Report.WriteLine("selecting sub-Customer of MG or Both from the customer drop down list");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, CustomerDropdownExtuser_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, CustomerDropdownValesExtuser_Xpath, Customer);
        }

        [When(@"I myself select Sub-customer of MG or both  from the customer drop down list (.*),(.*)")]
        public void WhenIMyselfSelectSub_CustomerOfMGOrBothFromTheCustomerDropDownList(string Customer, string tmsType)
        {
                Report.WriteLine("selecting sub-Customer of MG or Both from the customer drop down list");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, CustomerDropdownExtuser_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, CustomerDropdownValesExtuser_Xpath, Customer);
        }

        [When(@"I expand the quote details of any displayed Non LTL quote")]
        public void WhenIExpandTheQuoteDetailsOfAnyDisplayedNonLTLQuote()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_xpath, QuoteList_SearchBox_Xpath, "inter");
            GlobalVariables.webDriver.WaitForPageLoad();
            int quoteListCount = GetCount(attributeName_xpath, QuoteList_AllNoOfRecords_xpath);
            if (quoteListCount > 1)
            {
                Report.WriteLine("Expand the first new Truckload Quote in the Quote List ");
                Click(attributeName_xpath, QuoteList_TopGrid_expandquote_Xpath);
                GlobalVariables.webDriver.WaitForPageLoad();
            }
            else
            {
                SendKeys(attributeName_xpath, QuoteList_SearchBox_Xpath, "TRUCKLOAD");
                GlobalVariables.webDriver.WaitForPageLoad();
                int quoteListCount1 = GetCount(attributeName_xpath, QuoteList_AllNoOfRecords_xpath);
                if (quoteListCount > 1)
                {
                    Report.WriteLine("Expand the first new international Quote in the Quote List ");
                    Click(attributeName_xpath, QuoteList_TopGrid_expandquote_Xpath);
                    GlobalVariables.webDriver.WaitForPageLoad();
                }

            }
        }

        [Then(@"Submit Rate Request button will be hidden")]
        public void ThenSubmitRateRequestButtonWillBeHidden()
        {
            Report.WriteLine("Rate Request button is hidden");
            VerifyElementNotVisible(attributeName_xpath, QuoteSubmitrateRequest_Button_Xpath, "RateRequestButton");
        }

        [Then(@"Quote List grid will refresh to display all quotes associated to the primary account for the past thirtydays(.*),(.*)")]
        public void ThenQuoteListGridWillRefreshToDisplayAllQuotesAssociatedToThePrimaryAccountForThePastThirtydays(string Customer, string tmsType)
        {
            if (tmsType == "MG")
            {
                GetListScreenDetails getListScreenDetails = new GetListScreenDetails();
                IList<ShipmentListViewModel> quoteData = getListScreenDetails.GetListScreenDetailsMGForCustomerUsers(Customer);
                List<String> quoteList = new List<string>();
                if (quoteData != null)
                {
                    for (int j = 1; j < quoteData.Count; j++)
                    {
                        quoteList.Add(quoteData[j].PrimaryReference);
                    }
                }
                else
                {
                    Report.WriteLine("Not received any response from API for selected Customer ");
                }

                SelectDropdownlistvalue(attributeName_xpath, QuoteList_TopGrid_DisplayListDropdownOptions_Xpath, "ALL");
                GlobalVariables.webDriver.WaitForPageLoad();
                IList<IWebElement> quoteListUI = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_RequestNumberInternal_Values_Xpath));
                List<string> actualQuoteList = new List<string>();
                Report.WriteLine("UI values count are: " + quoteListUI);

                if (quoteList.Count > 1)
                {

                    for (int k = 0; k < quoteListUI.Count; k++)
                    {
                        string UIShipValues = quoteListUI[k].Text;
                        actualQuoteList.Add(UIShipValues);
                    }

                }
                else
                {
                    Report.WriteLine("No Quotes exists for the selected station");
                    VerifyElementPresent(attributeName_xpath, QuoteList_NoResults_Xpath, "No Records Found");
                }
                Assert.AreEqual(quoteList.Count, actualQuoteList.Count);
                //CollectionAssert.AreEqual(quoteList.OrderBy(q => q).ToList(), actualQuoteList.OrderBy(q => q).ToList());
                Report.WriteLine("Displaying quote list in the UI is matching with API results");
            }

            else
            {
                GetListScreenDetails getListScreenDetails = new GetListScreenDetails();
                IList<ShipmentListViewModel> quoteData = getListScreenDetails.GetListScreenDetailsMGForCustomerUsers(Customer);
                List<String> quoteList = new List<string>();
                if (quoteData != null)
                {
                    for (int j = 1; j < quoteData.Count; j++)
                    {
                        quoteList.Add(quoteData[j].PrimaryReference);
                    }
                }
                else
                {
                    Report.WriteLine("Not received any response from API for selected Customer");
                }

                SelectDropdownlistvalue(attributeName_xpath, QuoteList_TopGrid_DisplayListDropdownOptions_Xpath, "ALL");
                GlobalVariables.webDriver.WaitForPageLoad();
                IList<IWebElement> quoteListUI = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_RequestNumberInternal_Values_Xpath));
                List<string> actualQuoteList = new List<string>();
                Report.WriteLine("UI values count are: " + quoteListUI);

                if (quoteList.Count > 1)
                {

                    for (int k = 0; k < quoteListUI.Count; k++)
                    {
                        string UIShipValues = quoteListUI[k].Text;
                        actualQuoteList.Add(UIShipValues);
                    }

                }
                else
                {
                    Report.WriteLine("No Quotes exists for the selected station");
                    VerifyElementPresent(attributeName_xpath, QuoteList_NoResults_Xpath, "No Records Found");
                }
                ICsaShipmentListByLast30Days csaQuotes = new CsaShipmentListByLast30Days();
                ShipmentListReponse shipmentListAPI = csaQuotes.GetCsaShipmentListByLast30Days(Convert.ToInt32("183278888"), out errorMessage);
                Report.WriteLine("CSA API values are: " + shipmentListAPI);
                if (shipmentListAPI != null)
                {
                    List<string> quoteListValuesAPI = shipmentListAPI.Shipments.Select(a => a.Housebill).ToList();
                    foreach (var element in quoteListValuesAPI)
                    {
                        quoteList.Add(element);
                    }
                }
                else
                {
                    Report.WriteLine("Data not found for the CSA customer account number" + "CsaCustomerNumber");
                }

                Assert.AreEqual(quoteList.Count, actualQuoteList.Count);
               // CollectionAssert.AreEqual(quoteList.OrderBy(q => q).ToList(), actualQuoteList.OrderBy(q => q).ToList());
                Report.WriteLine("Displaying quote list in the UI is matching with API results");
            }
        }

        [Then(@"Quote List grid will refresh to display all quotes associated to the selected sub-account for the past thirtydays(.*),(.*)")]
        public void ThenQuoteListGridWillRefreshToDisplayAllQuotesAssociatedToTheSelectedSub_AccountForThePastThirtydays(string Customer, string tmsType)
        {

            if (tmsType == "MG")
            {
                GetListScreenDetails getListScreenDetails = new GetListScreenDetails();
                IList<ShipmentListViewModel> quoteData = getListScreenDetails.GetListScreenDetailsMGForCustomerUsers(Customer);
                List<String> quoteList = new List<string>();
                if (quoteData != null)
                {
                    for (int j = 1; j < quoteData.Count; j++)
                    {
                        quoteList.Add(quoteData[j].PrimaryReference);
                    }
                }
                else
                {
                    Report.WriteLine("Not received any response from API for selected Customer ");
                }

                SelectDropdownlistvalue(attributeName_xpath, QuoteList_TopGrid_DisplayListDropdownOptions_Xpath, "ALL");
                GlobalVariables.webDriver.WaitForPageLoad();
                IList<IWebElement> quoteListUI = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_RequestNumberInternal_Values_Xpath));
                List<string> actualQuoteList = new List<string>();
                Report.WriteLine("UI values count are: " + quoteListUI);

                if (quoteList.Count > 1)
                {

                    for (int k = 0; k < quoteListUI.Count; k++)
                    {
                        string UIShipValues = quoteListUI[k].Text;
                        actualQuoteList.Add(UIShipValues);
                    }

                }
                else
                {
                    Report.WriteLine("No Quotes exists for the selected station");
                    VerifyElementPresent(attributeName_xpath, QuoteList_NoResults_Xpath, "No Records Found");
                }
                Assert.AreEqual(quoteList.Count, actualQuoteList.Count);
                CollectionAssert.AreEqual(quoteList.OrderBy(q => q).ToList(), actualQuoteList.OrderBy(q => q).ToList());
                Report.WriteLine("Displaying quote list in the UI is matching with API results");
            }

            else
            {
                GetListScreenDetails getListScreenDetails = new GetListScreenDetails();
                IList<ShipmentListViewModel> quoteData = getListScreenDetails.GetListScreenDetailsMGForCustomerUsers(Customer);
                List<String> quoteList = new List<string>();
                if (quoteData != null)
                {
                    for (int j = 1; j < quoteData.Count; j++)
                    {
                        quoteList.Add(quoteData[j].PrimaryReference);
                    }
                }
                else
                {
                    Report.WriteLine("Not received any response from API for selected Customer ");
                }

                SelectDropdownlistvalue(attributeName_xpath, QuoteList_TopGrid_DisplayListDropdownOptions_Xpath, "ALL");
                GlobalVariables.webDriver.WaitForPageLoad();
                IList<IWebElement> quoteListUI = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_RequestNumberInternal_Values_Xpath));
                List<string> actualQuoteList = new List<string>();
                Report.WriteLine("UI values count are: " + quoteListUI);

                if (quoteList.Count > 1)
                {
                    for (int k = 0; k < quoteListUI.Count; k++)
                    {
                        string UIShipValues = quoteListUI[k].Text;
                        actualQuoteList.Add(UIShipValues);
                    }

                }
                else
                {
                    Report.WriteLine("No Quotes exists for the selected customer");
                    VerifyElementPresent(attributeName_xpath, QuoteList_NoResults_Xpath, "No Records Found");
                }
                ICsaShipmentListByLast30Days csaQuotes = new CsaShipmentListByLast30Days();
                ShipmentListReponse shipmentListAPI = csaQuotes.GetCsaShipmentListByLast30Days(Convert.ToInt32("183278888"), out errorMessage);
                Report.WriteLine("CSA API values are: " + shipmentListAPI);
                if (shipmentListAPI != null)
                {
                    List<string> quoteValue = shipmentListAPI.Shipments.Select(a => a.Housebill).ToList();
                    foreach (var element in quoteValue)
                    {
                        quoteList.Add(element);
                    }
                }
                else
                {
                    Report.WriteLine("Data not found for the CSA  account number" + "CsaCustomerNumber");
                }

                Assert.AreEqual(quoteList.Count, quoteListUI.Count);
               // CollectionAssert.AreEqual(quoteList.OrderBy(q => q).ToList(), actualQuoteList.OrderBy(q => q).ToList());
                Report.WriteLine("Displaying quote list in the UI is matching with API results");
            }
        }


        [Then(@"Quote List grid will refresh to display all quotes associated to the primary account and sub-accounts for the past (.*) days (.*)")]
        public void ThenQuoteListGridWillRefreshToDisplayAllQuotesAssociatedToThePrimaryAccountAndSub_AccountsForThePastDays(string Customer, string tmsType)
        {
            if (tmsType == "MG")
            {
                GetListScreenDetails getListScreenDetails = new GetListScreenDetails();
                IList<ShipmentListViewModel> quoteData = getListScreenDetails.GetListScreenDetailsMGForCustomerUsers(Customer);
                List<String> quoteList = new List<string>();
                if (quoteData != null)
                {
                    for (int j = 1; j < quoteData.Count; j++)
                    {
                        quoteList.Add(quoteData[j].PrimaryReference);
                    }
                }
                else
                {
                    Report.WriteLine("Not received any response from API for selected Customer ");
                }

                SelectDropdownlistvalue(attributeName_xpath, QuoteList_TopGrid_DisplayListDropdownOptions_Xpath, "ALL");
                GlobalVariables.webDriver.WaitForPageLoad();
                IList<IWebElement> quoteListUI = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_RequestNumberInternal_Values_Xpath));
                List<string> actualQuoteList = new List<string>();
                Report.WriteLine("UI values count are: " + quoteListUI);

                if (quoteList.Count > 1)
                {

                    for (int k = 0; k < quoteListUI.Count; k++)
                    {
                        string UIShipValues = quoteListUI[k].Text;
                        actualQuoteList.Add(UIShipValues);
                    }

                }
                else
                {
                    Report.WriteLine("No Quotes exists for the selected station");
                    VerifyElementPresent(attributeName_xpath, QuoteList_NoResults_Xpath, "No Records Found");
                }
                Assert.AreEqual(quoteList.Count, actualQuoteList.Count);
                CollectionAssert.AreEqual(quoteList.OrderBy(q => q).ToList(), actualQuoteList.OrderBy(q => q).ToList());
                Report.WriteLine("Displaying quote list in the UI is matching with API results");
            }

            else
            {
                GetListScreenDetails getListScreenDetails = new GetListScreenDetails();
                IList<ShipmentListViewModel> quoteData = getListScreenDetails.GetListScreenDetailsMGForCustomerUsers(Customer);
                List<String> quoteList = new List<string>();
                if (quoteData != null)
                {
                    for (int j = 1; j < quoteData.Count; j++)
                    {
                        quoteList.Add(quoteData[j].PrimaryReference);
                    }
                }
                else
                {
                    Report.WriteLine("Not received any response from API for selected Customer");
                }

                SelectDropdownlistvalue(attributeName_xpath, QuoteList_TopGrid_DisplayListDropdownOptions_Xpath, "ALL");
                GlobalVariables.webDriver.WaitForPageLoad();
                IList<IWebElement> quoteListUI = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_RequestNumberInternal_Values_Xpath));
                List<string> actualQuoteList = new List<string>();
                Report.WriteLine("UI values count are: " + quoteListUI);

                if (quoteList.Count > 1)
                {

                    for (int k = 0; k < quoteListUI.Count; k++)
                    {
                        string UIShipValues = quoteListUI[k].Text;
                        actualQuoteList.Add(UIShipValues);
                    }

                }
                else
                {
                    Report.WriteLine("No Quotes exists for the selected station");
                    VerifyElementPresent(attributeName_xpath, QuoteList_NoResults_Xpath, "No Records Found");
                }
                ICsaShipmentListByLast30Days csaQuotes = new CsaShipmentListByLast30Days();
                ShipmentListReponse shipmentListAPI = csaQuotes.GetCsaShipmentListByLast30Days(Convert.ToInt32("183278888"), out errorMessage);
                Report.WriteLine("CSA API values are: " + shipmentListAPI);
                if (shipmentListAPI != null)
                {
                    List<string> quoteListValuesAPI = shipmentListAPI.Shipments.Select(a => a.Housebill).ToList();
                    foreach (var element in quoteListValuesAPI)
                    {
                        quoteList.Add(element);
                    }
                }
                else
                {
                    Report.WriteLine("Data not found for the CSA customer account number" + "CsaCustomerNumber");
                }

                Assert.AreEqual(quoteList.Count, quoteListUI.Count);
               // CollectionAssert.AreEqual(quoteList.OrderBy(q => q).ToList(), actualQuoteList.OrderBy(q => q).ToList());
                Report.WriteLine("Displaying quote list in the UI is matching with API results");
            }
        }

        [Then(@"the Re-Quote button will be hidden")]
        public void ThenTheRe_QuoteButtonWillBeHidden()
        {
            Report.WriteLine("Re-Quote button is hidden");
            VerifyElementNotPresent(attributeName_id, QuoteDetails_RequoteButton_id, "requote");
        }

        [Then(@"the Create Shipment button will be hidden")]
        public void ThenTheCreateShipmentButtonWillBeHidden()
        {
            Report.WriteLine("Create Shipment button is hidden");
            GlobalVariables.webDriver.WaitForPageLoad();
            DefineTimeOut(2000);
            VerifyElementNotVisible(attributeName_id, QuoteDetails_CreateShipmentButton_Id, "CreateShipmentbutton");
        }

        [Then(@"Rate Request button will be active")]
        public void ThenRateRequestButtonWillBeActive()
        {
            Report.WriteLine("Rate Request button is hidden");
            VerifyElementEnabled(attributeName_xpath, QuoteSubmitrateRequest_Button_Xpath, "RateRequestButton");
        }

        [Then(@"Quote List grid will refresh to display all quotes associated to the primary account for the past (.*) days")]
        public void ThenQuoteListGridWillRefreshToDisplayAllQuotesAssociatedToThePrimaryAccountForThePastDays(string Customer, string tmsType)
        {
            if (tmsType == "MG")
            {
                Assert.AreEqual(Gettext(attributeName_id, QuoteList_CustomerDropdown_Xpath), Customer);
                GetListScreenDetails getListScreenDetails = new GetListScreenDetails();
                IList<ShipmentListViewModel> quoteData = getListScreenDetails.GetListScreenDetailsMGForCustomerUsers(Customer);
                List<String> quoteList = new List<string>();
                if (quoteData != null)
                {
                    for (int j = 1; j < quoteData.Count; j++)
                    {
                        quoteList.Add(quoteData[j].PrimaryReference);
                    }
                }
                else
                {
                    Report.WriteLine("Not received any response from API for selected Customer ");
                }

                SelectDropdownlistvalue(attributeName_xpath, QuoteList_TopGrid_DisplayListDropdownOptions_Xpath, "ALL");
                GlobalVariables.webDriver.WaitForPageLoad();                
                IList<IWebElement> quoteListUI = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_RequestNumberInternal_Values_Xpath));
                List<string> actualQuoteList = new List<string>();
                Report.WriteLine("UI values count are: " + quoteListUI);

                if (quoteList.Count > 1)
                {

                    for (int k = 0; k < quoteListUI.Count; k++)
                    {
                        string UIShipValues = quoteListUI[k].Text;
                        actualQuoteList.Add(UIShipValues);
                    }

                }
                else
                {
                    Report.WriteLine("No Quotes exists for the selected station");
                    VerifyElementPresent(attributeName_xpath, QuoteList_NoResults_Xpath, "No Records Found");
                }
                Assert.AreEqual(quoteList.Count, actualQuoteList.Count);
                CollectionAssert.AreEqual(quoteList.OrderBy(q => q).ToList(), actualQuoteList.OrderBy(q => q).ToList());
                Report.WriteLine("Displaying quote list in the UI is matching with API results");
            }

            else
            {
                GetListScreenDetails getListScreenDetails = new GetListScreenDetails();
                IList<ShipmentListViewModel> quoteData = getListScreenDetails.GetListScreenDetailsMGForCustomerUsers(Customer);
                List<String> quoteList = new List<string>();
                if (quoteData != null)
                {
                    for (int j = 1; j < quoteData.Count; j++)
                    {
                        quoteList.Add(quoteData[j].PrimaryReference);
                    }
                }
                else
                {
                    Report.WriteLine("Not received any response from API for selected Customer ");
                }

                SelectDropdownlistvalue(attributeName_xpath, QuoteList_TopGrid_DisplayListDropdownOptions_Xpath, "ALL");
                GlobalVariables.webDriver.WaitForPageLoad();
                IList<IWebElement> quoteListUI = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_RequestNumberInternal_Values_Xpath));
                List<string> actualQuoteList = new List<string>();
                Report.WriteLine("UI values count are: " + quoteListUI);

                if (quoteList.Count > 1)
                {
                    for (int k = 0; k < quoteListUI.Count; k++)
                    {
                        string UIShipValues = quoteListUI[k].Text;
                        actualQuoteList.Add(UIShipValues);
                    }

                }
                else
                {
                    Report.WriteLine("No Quotes exists for the selected customer");
                    VerifyElementPresent(attributeName_xpath, QuoteList_NoResults_Xpath, "No Records Found");
                }
                ICsaShipmentListByLast30Days csaQuotes = new CsaShipmentListByLast30Days();
                ShipmentListReponse shipmentListAPI = csaQuotes.GetCsaShipmentListByLast30Days(Convert.ToInt32("CsaCustomerNumber"), out errorMessage);
                Report.WriteLine("CSA API values are: " + shipmentListAPI);
                if (shipmentListAPI != null)
                {
                    List<string> quoteValue = shipmentListAPI.Shipments.Select(a => a.Housebill).ToList();
                    foreach (var element in quoteValue)
                    {
                        quoteList.Add(element);
                    }
                }
                else
                {
                    Report.WriteLine("Data not found for the CSA  account number" + "CsaCustomerNumber");
                }

                Assert.AreEqual(quoteList.Count, actualQuoteList.Count);
                CollectionAssert.AreEqual(quoteList.OrderBy(q => q).ToList(), actualQuoteList.OrderBy(q => q).ToList());
                Report.WriteLine("Displaying quote list in the UI is matching with API results");
            }
        }

        [Then(@"Create Shipment button will not be displayed")]
        public void ThenCreateShipmentButtonWillNotBeDisplayed()
        {
            Report.WriteLine("Create Shipment button is hidden");
            GlobalVariables.webDriver.WaitForPageLoad();
            DefineTimeOut(3000);
            VerifyElementNotVisible(attributeName_id, QuoteDetails_CreateShipmentButton_Id, "CreateShipmentbutton");
        }

        [Then(@"Quote List grid will refresh to display all quotes associated to the primary account and sub-accounts for the past (.*) days")]
        public void ThenQuoteListGridWillRefreshToDisplayAllQuotesAssociatedToThePrimaryAccountAndSub_AccountsForThePastDays(int p0)
        {
            
        }

        [When(@"I select primary customer of MG or both  from the customer drop down (.*),(.*) list")]
        public void WhenISelectPrimaryCustomerOfMGOrBothFromTheCustomerDropDownList(string Customer, string tmsType)
        {

            Report.WriteLine("selecting sub-Customer of MG or Both from the customer drop down list");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, CustomerDropdownExtuser_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, CustomerDropdownValesExtuser_Xpath, Customer);


        }

        [When(@"I myself select primary customer of MG or both  from the customer drop down (.*),(.*) list")]
        public void WhenIMyselfSelectPrimaryCustomerOfMGOrBothFromTheCustomerDropDownZZZ_CzarCustomerTestMGList(string Customer, string tmsType)
        {
            Report.WriteLine("selecting sub-Customer of MG or Both from the customer drop down list");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, CustomerDropdownExtuser_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, CustomerDropdownValesExtuser_Xpath, Customer);
        }


    }
}
