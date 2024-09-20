using CRM.UITest.CommonMethods;
using CRM.UITest.CsaServiceReference;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.Common;
using CRM.UITest.Helper.Implementations.ShipmentList;
using CRM.UITest.Helper.Implementations.StandardReport;
using CRM.UITest.Helper.Interfaces.Quote;
using CRM.UITest.Helper.Interfaces.Shipment;
using CRM.UITest.Helper.ViewModel.Shipment;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Xml.Linq;
using TechTalk.SpecFlow;
namespace CRM.UITest.Scripts.Shipment.ShipmentList.ShipmentList_InactiveCustomers_StationUsers
{
    [Binding]
    public class ShipmentList_Inactive_Customer_Station_UsersSteps : Shipmentlist
    {
        string errorMessage = null;
        public WebElementOperations ObjWebElementOperations = new WebElementOperations();
        CommonMethodsCrm crm = new CommonMethodsCrm();

        [Given(@"I am a sales, sales management, operations, or stationowner user - (.*) and (.*)")]
        public void GivenIAmASalesSalesManagementOperationsOrStationownerUser_And(string Username, string Password)
        {
            crm.LoginToCRMApplication(Username, Password);
        }


        [Given(@"I arrive on shipment list page")]
        public void GivenIArriveOnShipmentListPage()
        {
            Report.WriteLine("Shipment list page");
            Verifytext(attributeName_xpath, ShipmentList_Title_Xpath, "Shipment List");
        }

        [When(@"I click on Customer List dropdown")]
        public void WhenIClickOnCustomerListDropdown()
        {
            Report.WriteLine("Click on Customer List dropdown");
            Click(attributeName_xpath, ShipmentList_CustomerSelection_Xpath);
        }

        [Then(@"For a selected inactive customer the Add shipment button should be inactive (.*)")]
        public void ThenForASelectedInactiveCustomerTheAddShipmentButtonShouldBeInactive(string stationData)
        {

            InactiveOrActiveCustomer ActiveInactiveCheck_Class = new InactiveOrActiveCustomer();
            ActiveInactiveCheck_Class.GetActiveInactiveCust(stationData);
        }


        [Then(@"Inactive customers should be grayed out (.*)")]
        public void ThenInactiveCustomersShouldBeGrayedOut(string stationData)
        {
            InactiveOrActiveCustomer ActiveInactiveCheck_Class = new InactiveOrActiveCustomer();
            ActiveInactiveCheck_Class.GetActiveInactiveCust(stationData);
        }

        [Then(@"For a selected inactive customer the Add shipment button should be inactive")]
        public void ThenForASelectedInactiveCustomerTheAddShipmentButtonShouldBeInactive()
        {
            VerifyElementNotEnabled(attributeName_id, ShipmentList_AddShipmentButtonInternalUser_Id, "Add Shipment");
            Report.WriteLine("Add Shipment button is inactive for inactive customers");
        }

        [When(@"I select an inactive Customer from the dropdown list (.*)")]
        public void WhenISelectAnInactiveCustomerFromTheDropdownList(string Account)
        {
            SelectDropdownValueFromList(attributeName_xpath, ShipmentList_CustomerSelection_Dropdown_Values_Xpath, Account);
            Report.WriteLine("Selected Inactive Customer form the list");
        }

        [Then(@"Shipment list grid will get loaded with shipments from past (.*) days for the customer selected (.*)")]
        public void ThenShipmentListGridWillGetLoadedWithShipmentsFromPastDaysForTheCustomerSelected(int p0, string Account)
        {
            List<String> ShipList = new List<string>();
            int accID = DBHelper.GetAccountIdforAccountName(Account);
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

            //Getting UI Shipment List
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
                CollectionAssert.AreEqual(ShipList.OrderBy(q => q).ToList(), UIValue.OrderBy(q => q).ToList());
                Report.WriteLine("Displaying default shipment list in the UI is matching with API results");
            }
            else
            {
                Report.WriteLine("No shipment exists for the selected account");
                VerifyElementPresent(attributeName_xpath, ShipmentList_NoRecords_Xpath, "No Records Found");
            }
        }

        [Then(@"Copy Shipment icon for any displayed LTL shipment will be disabled")]
        public void ThenCopyShipmentIconForAnyDisplayedLTLShipmentWillBeDisabled()
        {
            IList<IWebElement> UIShipvalue = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentListGrid_RefValues_Xpath));
            if (UIShipvalue.Count > 0)
            {
                for (int i = 1; i <= UIShipvalue.Count; i++)
                {
                    VerifyElementNotEnabled(attributeName_xpath, ".//*[@id='ShipmentGrid']/tbody/tr[" + i + "]/td[11]/a[2]", "Copy Icon");
                    Report.WriteLine("Copy Icon is disabled for inactive customer");
                }
            }
        }

        [Then(@"Create Return Shipment icon for any displayed LTL shipment will be disabled\.")]
        public void ThenCreateReturnShipmentIconForAnyDisplayedLTLShipmentWillBeDisabled_()
        {
            IList<IWebElement> UIShipvalue = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentListGrid_RefValues_Xpath));
            if (UIShipvalue.Count > 0)
            {
              
                for (int i = 1; i <= UIShipvalue.Count; i++)
                {
                    VerifyElementNotEnabled(attributeName_xpath, ".//*[@id='ShipmentGrid']/tbody/tr[" + i + "]/td[11]/a[3]", "Return Icon");
                    Report.WriteLine("Return Icon is disabled for inactive customer");
                }
            }
        }

        [Then(@"Edit Shipment icon for any displayed LTL shipment will be disabled")]
        public void ThenEditShipmentIconForAnyDisplayedLTLShipmentWillBeDisabled()
        {
            IList<IWebElement> UIShipvalue = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentListGrid_RefValues_Xpath));
            if (UIShipvalue.Count > 0)
            {
               
                for (int i = 1; i <= UIShipvalue.Count; i++)
                {
                    VerifyElementNotEnabled(attributeName_xpath, ".//*[@id='ShipmentGrid']/tbody/tr[" + i + "]/td[10]/button", "Edit Icon");
                    Report.WriteLine("Edit Icon is disabled for inactive customer");
                }
            }
        }

    }
}
