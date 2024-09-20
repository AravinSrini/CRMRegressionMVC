
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.CsaServiceReference;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.Common;
using CRM.UITest.Helper.ViewModel.Shipment;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using Rrd.ServiceAccessLayer;
using CRM.UITest.Helper.Interfaces.Quote;
using CRM.UITest.Helper.Implementations.QuoteList;
using CRM.UITest.Helper.Implementations.ShipmentList;
using CRM.UITest.Helper.Implementations.StandardReport;
using System.Xml.Linq;
using System.Net.Http;
using CRM.UITest.Helper.ViewModel.RateModel;
using System.Threading;

namespace CRM.UITest.Scripts.Quote_List.QuoteList_InternalUsers
{
    [Binding]
    public class QuoteList_StationUsers_FilteredCustomerFunctionalitySteps : Quotelist
    {
        string actualText = null;
        string expectedText = null;
        string errorMessage = null;
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
        public string passedcustomer;

        [Given(@"I am a sales, sales management, operations, or station owner user")]
        public void GivenIAmASalesSalesManagementOperationsOrStationOwnerUser()
        {
            string username = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
            string password = ConfigurationManager.AppSettings["password-crmOperation"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"I am on Quote List page as a internal user")]
        public void GivenIAmOnQuoteListPageAsAInternalUser()
        {
            string userName = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
            IdServerAccess idp = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);
            var claim = idp.VerifyIfUserHasClaim(userName, "dlscrm-role", "ShowInternalUserCustomerDropdownRevampList");
            if (claim == true)
            {
                Report.WriteLine("I have access to station selection from customer dropdown in quote list page");
                Click(attributeName_xpath, QuoteIconModule_Xpath);
                Report.WriteLine("Navigated to Quote List page");
                WaitForElementVisible(attributeName_xpath, QuoteList_HeaderText_xpath, "Quotes");
            }
            else
            {
                Report.WriteLine("I have access to only customer selection from customer dropdown in quote list page");
            }
        }

        [Given(@"I have navigated away from Quote List page")]
        public void GivenIHaveNavigatedAwayFromQuoteListPage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ShipmentIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
        }


        [Given(@"i click on customer list dropdown")]
        public void GivenIClickOnCustomerListDropdown()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, QuoteList_CustomerDropdownList_InternalUser_Xpath);
        }

        [Given(@"I have selected a customer on the Quote List page")]
        public void GivenIHaveSelectedACustomerOnTheQuoteListPage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, QuoteList_CustomerDropdownList_InternalUser_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, QuoteList_CustomerDropdownValues_Xpath, "ZZZ - Czar Customer Test");
        }


        [When(@"i click on customer list dropdown")]
        public void WhenIClickOnCustomerListDropdown()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, QuoteList_CustomerDropdownList_InternalUser_Xpath);
        }

        [When(@"i select a customer from the customer list dropdown")]
        public void WhenISelectACustomerFromTheCustomerListDropdown()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, QuoteList_CustomerDropdownList_InternalUser_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, QuoteList_CustomerDropdownValues_Xpath, "ZZZ - Czar Customer Test");
        }


        [When(@"I select Station from the list")]
        public void WhenISelectStationFromTheList()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, QuoteList_CustomerDropdownList_InternalUser_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, QuoteList_CustomerDropdownValues_Xpath, "ZZZ - Web Services Test");
        }

        [Given(@"I have selected a station on the Quote List page")]
        public void GivenIHaveSelectedAStationOnTheQuoteListPage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, QuoteList_CustomerDropdownList_InternalUser_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, QuoteList_CustomerDropdownValues_Xpath, "ZZZ - Web Services Test");
        }


        [When(@"I return to the Quote List page")]
        public void WhenIReturnToTheQuoteListPage()
        {
            Click(attributeName_xpath, QuoteIconModule_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [When(@"I arrive on the Shipment List page")]
        public void WhenIArriveOnTheShipmentListPage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ShipmentIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [When(@"customer list is placed beneath the header at center")]
        public void WhenCustomerListIsPlacedBeneathTheHeaderAtCenter()
        {
          //  VerifyElementPresent(attributeName_xpath, QuoteList_CustomerDropdownList_InternalUser_Xpath, "customer dropdown");
            VerifyElementPresent(attributeName_xpath, QuoteList_customerDropdownVerbiage_Xpath, "customer dropdown");
        }

        [Then(@"text (.*) is shown beneath the customer list")]
        public void ThenTextIsShownBeneathTheCustomerList(string p0)
        {
            expectedText = "Submitted rate requests within the past 30 days are shown.";
            actualText = Gettext(attributeName_xpath, QuoteList_customerDropdownVerbiage_Xpath);
            Assert.AreEqual(expectedText, actualText);
        }

        [When(@"I am on Quote List page")]
        public void WhenIAmOnQuoteListPage()
        {
            string userName = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
            IdServerAccess idp = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);
            var claim = idp.VerifyIfUserHasClaim(userName, "dlscrm-role", "ShowInternalUserCustomerDropdownRevampList");
            if (claim == true)
            {
                Report.WriteLine("I have access to station selection from customer dropdown in quote list page");
                Click(attributeName_xpath, QuoteIconModule_Xpath);
                Report.WriteLine("Navigated to Quote List page");
                WaitForElementVisible(attributeName_xpath, QuoteList_HeaderText_xpath, "Quotes");
            }
            else
            {
                Report.WriteLine("I have access to only customer selection from customer dropdown in quote list page");
            }
        }


        [Then(@"I am allowed to select Station from the list")]
        public void ThenIAmAllowedToSelectStationFromTheList()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            SelectDropdownValueFromList(attributeName_xpath, QuoteList_CustomerDropdownValues_Xpath, "ENT - Bolingbrook IL");
        }

        [Then(@"the quote list will display any quotes associated to the station for the previous (.*) days")]
        public void ThenTheQuoteListWillDisplayAnyQuotesAssociatedToTheStationForThePreviousDays(int p0)
        {
            string station = "ZZZ - Web Services Test";
            GetListScreenDetails getListScreenDetails = new GetListScreenDetails();
            IList<ShipmentListViewModel> quotedata = getListScreenDetails.GetListScreenDetailsMG(station);
            List<String> QuoteList = new List<string>();
            if (quotedata != null)
            {
                for (int j = 1; j < quotedata.Count; j++)
                {
                    QuoteList.Add(quotedata[j].PrimaryReference);
                }
            }
            else
            {
                Report.WriteLine("Not received any reposnse from API for selected Station ID ");
            }

            SelectDropdownlistvalue(attributeName_xpath, QuoteList_TopGrid_DisplayListDropdownOptions_Xpath, "ALL");
            GlobalVariables.webDriver.WaitForPageLoad();
            IList<IWebElement> quoteListUI = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_RequestNumberInternal_Values_Xpath));
            List<string> actualQuoteList = new List<string>();
            Report.WriteLine("UI values count are: " + quoteListUI);

            if (QuoteList.Count > 1)
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

            CustomerAccount customerAccount = DBHelper.GetStationDetailsByStationName("ZZZ - Web Services Test");

            string stationNameDB = DBHelper.GetStationNameonStationID(customerAccount.StationId);
            List<CustomerAccount> customerListValue = DBHelper.GetAccountsMappedforStation(stationNameDB);

            for (int k = 0; k < customerListValue.Count; k++)
            {
                if (customerListValue[k].TmsSystem == "CSA" || customerListValue[k].TmsSystem == "BOTH")
                {
                    ICsaQuoteListByLast30Days quoteCSA = new CsaQuoteListByLast30Days();
                    ShipmentListReponse quoteListAPI = quoteCSA.GetCsaQuoteListByLast30Days(Convert.ToInt32(customerListValue[k].CsaCustomerNumber), out errorMessage);
                    Report.WriteLine("CSA API values are: " + quoteListAPI);
                    if (quoteListAPI != null)
                    {
                        List<string> QuoteValue = quoteListAPI.Shipments.Select(a => a.Housebill).ToList();
                        foreach (var element in QuoteValue)
                        {
                            QuoteList.Add(element);
                        }
                    }
                    else
                    {
                        Report.WriteLine("Data not found for the CSA station account number" + customerListValue[k].CsaCustomerNumber);
                    }
                }
            }

            Assert.AreEqual(QuoteList.Count, actualQuoteList.Count);
            Report.WriteLine("Displaying quote list in the UI is matching with API results");
        }

        [Then(@"the customer name will be display")]
        public void ThenTheCustomerNameWillBeDisplay()
        {
            expectedText = "ZZZ - Web Services Test - ZZZ - Czar Customer Test";
            actualText = Gettext(attributeName_xpath, QuoteList_CustomerDropdownNameDisplay_Xpath);
            Assert.AreEqual(expectedText, actualText);
        }

        [Then(@"the customer previously filtered will be pre-selected")]
        public void ThenTheCustomerPreviouslyFilteredWillBePre_Selected()
        {
            expectedText = "ZZZ - Web Services Test - ZZZ - Czar Customer Test";
            actualText = Gettext(attributeName_xpath, PreselectedCustomer_Xpath);
            Assert.AreEqual(expectedText, actualText);
        }

        [Then(@"the quote list will display any quotes associated to the customer for the previous (.*) days")]
        public void ThenTheQuoteListWillDisplayAnyQuotesAssociatedToTheCustomerForThePreviousDays(int p0)
        {
           
            GlobalVariables.webDriver.WaitForPageLoad();
          //  Click(attributeName_xpath, QuoteList_TopGrid_DisplayListViewDropdown_Xpath);

          //  SelectDropdownValueFromList(attributeName_xpath, QuoteList_TopGrid_DisplayListViewDropdown_Xpath, option);
          //  SelectDropdownlistvalue(attributeName_xpath, QuoteList_TopGrid_DisplayListDropdownOptions_Xpath, option);

            Click(attributeName_xpath, QuoteList_TopGrid_DisplayListViewDropdown_Xpath);
            IList<IWebElement> CustomerDropdown_s = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_TopGrid_DisplayListDropdownOptions_Xpath));
            int CustomerDropdown_ship = CustomerDropdown_s.Count;
            for (int i = 0; i < CustomerDropdown_ship; i++)
            {
                if (CustomerDropdown_s[i].Text == "ALL")
                {
                    CustomerDropdown_s[i].Click();
                    break;
                }
            }

            string Account = "ZZZ - Czar Customer Test";

            //List<string> QuoteList = new List<string>();
            //IMgQuoteListForSalesUser MGQuotes = new MgQuoteListForSalesUser();

            //List<QuoteListExtractModel> QModel = MGQuotes.GetMgQuoteList(Account, true);

            //if (QModel != null)
            //{
            //    for (int j = 0; j < QModel.Count; j++)
            //    {
            //        QuoteList.Add(QModel[j].QuoteReferenceNumber);
            //    }


            //    IList<IWebElement> UIQuotes = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_RequestNumberInternal_Values_Xpath));
            //    List<string> UIValue = new List<string>();
            //    Thread.Sleep(3000);
            //    for (int k = 0; k < UIQuotes.Count; k++)
            //    {
            //        string UIQuoteNumber = UIQuotes[k].Text;
            //        UIValue.Add(UIQuoteNumber);
            //    }
            //    CollectionAssert.AreEqual(QuoteList.OrderBy(q => q).ToList(), UIValue.OrderBy(q => q).ToList());
            //    Report.WriteLine("Displaying default quote list in the UI is matching with API results");
            //}
            //else
            //{
            //    VerifyElementPresent(attributeName_xpath, QuoteList_NoResults_Xpath, "No Results");
            //    Report.WriteLine("No quotes exists for the selected account");
            //}
            //List<string> QuoteList = new List<string>();
            //IMgQuoteListForSalesUser MGQuotes = new MgQuoteListForSalesUser();

            //List<QuoteListExtractModel> QModel = MGQuotes.GetMgQuoteList(Account, true);

            //if (QModel != null)
            //{
            //    for (int j = 0; j < QModel.Count; j++)
            //    {
            //        QuoteList.Add(QModel[j].QuoteReferenceNumber);
            //    }


            //    IList<IWebElement> UIQuotes = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_RequestNumberInternal_Values_Xpath));
            //    List<string> UIValue = new List<string>();

            //    for (int k = 0; k < UIQuotes.Count; k++)
            //    {

            //        string UIQuoteNumber = UIQuotes[k].Text;
            //        UIValue.Add(UIQuoteNumber);
            //    }
            //    CollectionAssert.AreEqual(QuoteList.OrderBy(q => q).ToList(), UIValue.OrderBy(q => q).ToList());
            //    Report.WriteLine("Displaying default quote list in the UI is matching with API results");
            //}
            //else
            //{
            //    VerifyElementPresent(attributeName_xpath, QuoteList_NoResults_Xpath, "No Results");
            //    Report.WriteLine("No quotes exists for the selected account");
            //}

            GetListScreenDetails getListScreenDetails = new GetListScreenDetails();
            IList<ShipmentListViewModel> quoteData = getListScreenDetails.GetListScreenDetailsMGForCustomerUsers(Account);
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

            //SelectDropdownlistvalue(attributeName_xpath, QuoteGridAllOption_Xpath, "ALL");
            //GlobalVariables.webDriver.WaitForPageLoad();
            IList<IWebElement> quoteListUI = GlobalVariables.webDriver.FindElements(By.XPath(QuoteGridRefVlaues_Xpath));
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
            }
            Assert.AreEqual(quoteList.Count, actualQuoteList.Count);
            Report.WriteLine("Displaying quote list in the UI is matching with API results");

        }

        [Then(@"I have the option to select another customer, station")]
        public void ThenIHaveTheOptionToSelectAnotherCustomerStation()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, QuoteList_CustomerDropdownList_InternalUser_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, QuoteList_CustomerDropdownValues_Xpath, "ENT - Bolingbrook IL");
        }

        [Then(@"the station selected on the Quote List page will be pre-selected")]
        public void ThenTheStationSelectedOnTheQuoteListPageWillBePre_Selected()
        {
            expectedText = "ZZZ - Web Services Test";
            actualText = Gettext(attributeName_xpath, PreselectedCustomer_Xpath);
            Assert.AreEqual(expectedText, actualText);
        }

        [Then(@"the customer selected on the Quote List page will be pre-selected")]
        public void ThenTheCustomerSelectedOnTheQuoteListPageWillBePre_Selected()
        {
            expectedText = "ZZZ - Web Services Test - ZZZ - Czar Customer Test";
            actualText = Gettext(attributeName_xpath, PreselectedCustomer_Xpath);
            Assert.AreEqual(expectedText, actualText);
        }


        [Then(@"the shipment list will display any shipments associated to the customer for the previous (.*) days")]
        public void ThenTheShipmentListWillDisplayAnyShipmentsAssociatedToTheCustomerForThePreviousDays(int p0)
        {

            List<String> ShipList = new List<string>();
            int accID = DBHelper.GetAccountIdforAccountName("ZZZ - Czar Customer Test");
            CustomerSetup value = DBHelper.GetSetupDetails(accID);

            // Building request xml
            ListScreenExtractRequestXML data = new ListScreenExtractRequestXML();
            XElement reqXML = data.GetRequestXMLForShipmentListStationUser(value.MgAccountNumber, "CRM-ShpPrev30DaysAgent");

            //Building Client
            BuildHttpClient client = new BuildHttpClient();
            HttpClient headers = client.BuildHttpClientWithHeaders("ZZZ - Czar Customer Test", "application/xml");


            string uri = $"MercuryGate/ListScreenExtract";
            ShipmentListScreen Slist = new ShipmentListScreen();
            List<ShipmentListViewModel> Sdata = Slist.CallListScreen(uri, headers, reqXML);

            if (Sdata != null)
            {
                for (int j = 1; j < Sdata.Count; j++)
                {
                    if (Sdata[j].CustomerName.Contains("ZZZ - Czar Customer Test"))
                    {
                        ShipList.Add(Sdata[j].PrimaryReference);


                    }

                }
            }
            else
            {
                Report.WriteLine("Not received any reposnse from API for Station ID: " + value.MgAccountNumber);
            }

            //Getting UI Shipment List

            Click(attributeName_xpath, ShipmentList_TopGrid_ViewDropdown_Xpath);
            IList<IWebElement> CustomerDropdown_s = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_TopGrid_ViewDropdownValues_Xpath));
            int CustomerDropdown_ship = CustomerDropdown_s.Count;
            for (int i = 0; i < CustomerDropdown_ship; i++)
            {
                if (CustomerDropdown_s[i].Text == "ALL")
                {
                    CustomerDropdown_s[i].Click();
                    break;
                }
            }
            IList<IWebElement> UIShipments = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentListGrid_RefValues_Xpath));
            List<string> UIValue = new List<string>();

            if (ShipList.Count > 1)
            {

                for (int k = 0; k < UIShipments.Count; k++)
                {
                    string UIShipValues = UIShipments[k].Text;
                    UIValue.Add(UIShipValues);
                }

                Assert.AreEqual(ShipList.Count, UIValue.Count);
                Report.WriteLine("Displaying default shipment list in the UI is matching with API results");
            }
            else
            {
                Report.WriteLine("No shipment exists for the selected account");

            }
        }

        [Then(@"The shipment list should display shipments associated to the station for the previous (.*) days")]
        public void ThenTheShipmentListShouldDisplayShipmentsAssociatedToTheStationForThePreviousDays(int p0)
        {
            List<String> ShipList = new List<string>();
            // string stationNameDB = DBHelper.GetStationNameonStationID("ZZZ - Web Services Test");
            string stationNameDB = DBHelper.GetStationID("ZZZ - Web Services Test");
            List<CustomerAccount> customerListValue = DBHelper.GetAccountsMappedforStation(stationNameDB);

            for (int k = 0; k < customerListValue.Count; k++)
            {
                int accID = DBHelper.GetAccountIdforAccountName(customerListValue[k].ToString());
                CustomerSetup value = DBHelper.GetSetupDetails(accID);

                //Building Client
                BuildHttpClient client = new BuildHttpClient();
                HttpClient headers = client.BuildHttpClientWithHeaders("Admin", "application/xml");

                // Building request xml
                ListScreenExtractRequestXML data = new ListScreenExtractRequestXML();
                XElement reqXML = data.GetRequestXMLForShipmentListStationUser(value.MgAccountNumber, "CRM-ShpPrev30DaysAgent");



                string uri = $"MercuryGate/ListScreenExtract";
                ShipmentListScreen Slist = new ShipmentListScreen();
                List<ShipmentListViewModel> Sdata = Slist.CallListScreen(uri, headers, reqXML);

                if (Sdata != null)
                {
                    for (int j = 1; j < Sdata.Count; j++)
                    {
                        ShipList.Add(Sdata[j].PrimaryReference);
                    }
                }
                else
                {
                    Report.WriteLine("Not received any reposnse from API for Station ID: " + value.MgAccountNumber);
                }
            }
        }
    }
}
