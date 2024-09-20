using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Xml.Linq;
using TechTalk.SpecFlow;
using Rrd.ServiceAccessLayer;
using CRM.UITest.Helper.Interfaces.Quote;
using CRM.UITest.Helper.Implementations.QuoteList;
using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.Common;
using CRM.UITest.Helper.Implementations.ShipmentList;
using CRM.UITest.Helper.Implementations.StandardReport;
using CRM.UITest.Objects;
using CRM.UITest.Helper.ViewModel.Shipment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using CRM.UITest.CsaServiceReference;
using CRM.UITest.Helper.Interfaces.Shipment;
using System.Threading;

namespace CRM.UITest.Scripts.Shipment.ShipmentList.Shipment_List___Customer_Or_Station_Dropdown
{
    [Binding]
    public class ShipmentList_StationUsers_FilteredCustomerFunctionalitySteps : Shipmentlist
    {
        string errorMessage = null;
        [Given(@"I am a  sales, sales management, operations, or station owner user")]
        public void GivenIAmASalesSalesManagementOperationsOrStationOwnerUser()
        {
            string username = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
            string password = ConfigurationManager.AppSettings["password-crmOperation"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"I have navigated away from the Shipment list page by selecting a Customer")]
        public void GivenIHaveNavigatedAwayFromTheShipmentListPageBySelectingACustomer()
        {
            Click(attributeName_xpath, ShipmentIcon_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Verifytext(attributeName_xpath, ShipmentList_Title_Xpath, "Shipment List");
            Report.WriteLine("Navigated to Shipment list page");
            Click(attributeName_xpath, ShipmentList_CustomerOrStationDropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, ShipmentList_CustomerDropdownValues_Xpath, "ZZZ - Czar Customer Test");
            Report.WriteLine("Customer is been selected from the Customer or Station dropdown");
            Click(attributeName_xpath, QuoteIcon_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Navigated away from Shipment list page");
        }

        [When(@"I am on the Shipment List page")]
        public void WhenIAmOnTheShipmentListPage()
        {
            WaitForElementVisible(attributeName_cssselector, DashboardpageTitle_css, "Dashboard");
            try
            {
                Click(attributeName_xpath, ShipmentModule_Xpath);

            }
            catch (Exception)
            {
                Thread.Sleep(20000);
                Console.WriteLine("error occurred");
            }
            WaitForElementVisible(attributeName_xpath, ShipmentList_Title_Xpath, "Shipment List");
        }

        [When(@"I select a Customer from the dropdown of Shipment list page")]
        public void WhenISelectACustomerFromTheDropdownOfShipmentListPage()
        {
            Click(attributeName_xpath, ShipmentList_CustomerOrStationDropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, ShipmentList_CustomerDropdownValues_Xpath, "ZZZ - Czar Customer Test");
        }

        [Given(@"I have navigated away from the Shipment list page by selecting a Station")]
        public void GivenIHaveNavigatedAwayFromTheShipmentListPageBySelectingAStation()
        {
            Click(attributeName_xpath, ShipmentIcon_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Verifytext(attributeName_xpath, ShipmentList_Title_Xpath, "Shipment List");
            Report.WriteLine("Navigated to Shipment list page");
            Click(attributeName_xpath, ShipmentList_CustomerOrStationDropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, ShipmentList_CustomerDropdownValues_Xpath, "ZZZ - Web Services Test");
            Report.WriteLine("Customer is been selected from the Customer or Station dropdown");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, QuoteIcon_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Navigated away from Shipment list page");

        }

        [Then(@"A text should be displayed beneath the customer list stating - All shipments for the past (.*) days are shown\.")]
        public void ThenATextShouldBeDisplayedBeneathTheCustomerListStating_AllShipmentsForThePastDaysAreShown_(int p0)
        {
            Verifytext(attributeName_xpath, CustomerOrStationVerbiage_Xpath, "All shipments for the past 30 days are shown.");
            Report.WriteLine("Expected Verbiage is displayed beneath the customer list");
        }

        [Then(@"The customer list should be selected with select option")]
        public void ThenTheCustomerListShouldBeSelectedWithSelectOption()
        {
            Verifytext(attributeName_xpath, ShipmentList_CustomerOrStationDropdown_Xpath, "Select...");
            Report.WriteLine("Select option is selected in Customer list");
        }

        [Then(@"I should not be able to see a verbiage stating - All shipments for the past (.*) days are shown\.")]
        public void ThenIShouldNotBeAbleToSeeAVerbiageStating_AllShipmentsForThePastDaysAreShown_(int p0)
        {
            VerifyElementNotVisible(attributeName_xpath, CustomerOrStationVerbiage_Xpath, "Customer List Verbiage");
            Report.WriteLine("All shipments for the past 30 days are shown - verbiage is not present");
        }

        [Then(@"The customer previously filtered should get pre-selected")]
        public void ThenTheCustomerPreviouslyFilteredShouldGetPre_Selected()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Verifytext(attributeName_xpath, Shipment_CustomerOrStationDropdown_Selected_Xpath, "ZZZ - Web Services Test - ZZZ - Czar Customer Test");
            Report.WriteLine("Customer previously filtered is pre-selected ");
        }

        [Then(@"The shipment list should display any shipments associated to the customer for the previous (.*) days")]
        public void ThenTheShipmentListShouldDisplayAnyShipmentsAssociatedToTheCustomerForThePreviousDays(int p0)
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

        [Then(@"I should have an option to select another customer, station\.")]
        public void ThenIShouldHaveAnOptionToSelectAnotherCustomerStation_()
        {
            MoveToElement(attributeName_xpath, Shipment_CustomerOrStationDropdown_Selected_Xpath);
            Click(attributeName_xpath, Shipment_CustomerOrStationDropdown_Selected_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, ShipmentList_CustomerDropdownValues_Xpath, "ZZZ - GS Customer Test");
            Report.WriteLine("Able to select another Customer,Station");
        }

        [Then(@"I should have an option to select another customer, station from Quote list page")]
        public void ThenIShouldHaveAnOptionToSelectAnotherCustomerStationFromQuoteListPage()
        {
            Click(attributeName_xpath, QuoteCustomerOrStationDropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, QuoteCustomerOrStationDropdownVal_Xpath, "ZZZ - GS Customer Test");
            Report.WriteLine("Able to select another Customer,Station");
        }


        [Then(@"The customer selected on the Shipment List page should get pre-selected")]
        public void ThenTheCustomerSelectedOnTheShipmentListPageShouldGetPre_Selected()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Verifytext(attributeName_xpath, QuoteCustomerOrStationDropdown_Xpath, "ZZZ - Web Services Test - ZZZ - Czar Customer Test");
            Report.WriteLine("Customer previously filtered is pre-selected ");
        }

        [Then(@"The quote list should display any quotes associated to the customer for the previous (.*) days")]
        public void ThenTheQuoteListShouldDisplayAnyQuotesAssociatedToTheCustomerForThePreviousDays(int p0)
        {

            GetListScreenDetails getListScreenDetails = new GetListScreenDetails();
            IList<ShipmentListViewModel> quoteData = getListScreenDetails.GetListScreenDetailsMGForCustomerUsers("ZZZ - Czar Customer Test");
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

            SelectDropdownlistvalue(attributeName_xpath, QuoteGridAllOption_Xpath, "ALL");
            GlobalVariables.webDriver.WaitForPageLoad();
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

        [Then(@"The station previously filtered should get pre-selected")]
        public void ThenTheStationPreviouslyFilteredShouldGetPre_Selected()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Verifytext(attributeName_xpath, Shipment_CustomerOrStationDropdown_Selected_Xpath, "ZZZ - Web Services Test");
            Report.WriteLine("Customer previously filtered is pre-selected ");
        }

        [Then(@"The shipment list should display any shipments associated to the station for the previous (.*) days")]
        public void ThenTheShipmentListShouldDisplayAnyShipmentsAssociatedToTheStationForThePreviousDays(int p0)
        {
            List<String> ShipList = new List<string>();
            int accID = DBHelper.GetAccountIdforAccountName("ZZZ - Web Services Test");
            CustomerSetup value = DBHelper.GetSetupDetails(accID);

            // Building request xml
            ListScreenExtractRequestXML data = new ListScreenExtractRequestXML();
            XElement reqXML = data.GetRequestXMLForShipmentListStationUser(value.MgAccountNumber, "CRM-ShpPrev30DaysAgent");

            //Building Client
            BuildHttpClient client = new BuildHttpClient();
            HttpClient headers = client.BuildHttpClientWithHeaders("Admin", "application/xml");

            string uri = $"MercuryGate/ListScreenExtract";
            ShipmentListScreen Slist = new ShipmentListScreen();
            List<ShipmentListViewModel> Sdata = Slist.CallListScreen(uri, headers, reqXML);
            Report.WriteLine("MG API values are: " + Sdata);
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

            CustomerAccount val = DBHelper.GetStationDetailsByStationName("ZZZ - Web Services Test");

            string DBdetails = DBHelper.GetStationNameonStationID(val.StationId);
            List<CustomerAccount> listvalue = DBHelper.GetAccountsMappedforStation(DBdetails);

            for (int k = 0; k < listvalue.Count; k++)
            {
                if (listvalue[k].TmsSystem == "CSA" || listvalue[k].TmsSystem == "BOTH")
                {
                    ICsaShipmentListByLast30Days CSAShip = new CsaShipmentListByLast30Days();
                    ShipmentListReponse APIShipments = CSAShip.GetCsaShipmentListByLast30Days(Convert.ToInt32(listvalue[k].CsaCustomerNumber), out errorMessage);
                    Report.WriteLine("CSA API values are: " + APIShipments);
                    if (APIShipments != null)
                    {
                        List<string> ShipValue = APIShipments.Shipments.Select(a => a.Housebill).ToList();
                        foreach (var t in ShipValue)
                        {
                            ShipList.Add(t);
                        }
                    }
                    else
                    {
                        Report.WriteLine("Data not found for the CSA station account number" + listvalue[k].CsaCustomerNumber);
                    }

                }
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
                for (int j = 0; j < UIShipments.Count; j++)
                {
                    string UIShipValues = UIShipments[j].Text;
                    UIValue.Add(UIShipValues);
                }

                Assert.AreEqual(ShipList.Count, UIValue.Count);
                Report.WriteLine("Displaying default shipment list in the UI is matching with API results");
            }
            else
            {
                Report.WriteLine("No shipment exists for the selected account");
                VerifyElementPresent(attributeName_xpath, ShipmentList_NoRecords_Xpath, "No Records Found");
            }
        }

        [Then(@"The station selected on the Shipment List page should get pre-selected")]
        public void ThenTheStationSelectedOnTheShipmentListPageShouldGetPre_Selected()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Verifytext(attributeName_xpath, QuoteCustomerOrStationDropdown_Xpath, "ZZZ - Web Services Test");
            Report.WriteLine("Station previously filtered is pre-selected ");

        }

        [Then(@"The quote list should display any quotes associated to the station for the previous (.*) days")]
        public void ThenTheQuoteListShouldDisplayAnyQuotesAssociatedToTheStationForThePreviousDays(int p0)
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

            SelectDropdownlistvalue(attributeName_xpath, QuoteGridAllOption_Xpath, "ALL");
            GlobalVariables.webDriver.WaitForPageLoad();
            IList<IWebElement> quoteListUI = GlobalVariables.webDriver.FindElements(By.XPath(QuoteGridRefVlaues_Xpath));
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

    }
           
}
