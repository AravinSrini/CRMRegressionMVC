using System;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CRM.UITest.Scripts.Shipment.ShipmentList.Shipment_List_Page___CRM_Invoicing
{
    [Binding]
    public class CRMInvoicing_ShipmentListPageSteps: Shipmentlist
    {
        CommonMethodsCrm crm = new CommonMethodsCrm();

        [Given(@"I am a shp\.entry, shp\.inquiry, operations, sales, sales management, or station owner user (.*) (.*)")]
        public void GivenIAmAShp_EntryShp_InquiryOperationsSalesSalesManagementOrStationOwnerUser(string userName, string password)
        {
            crm.LoginToCRMApplication(userName, password);
        }

        [When(@"I arrive on shipment list page with Customer Invoice access")]
        public void WhenIArriveOnShipmentListPageWithCustomerInvoiceAccess()
        {
            Report.WriteLine("Verifying shipment list page");
            VerifyElementVisible(attributeName_xpath, ShipmentList_Title_Xpath, "Shipment List");
        }

        [When(@"I hover over the Customer Invoice option for the Delivered shipment")]
        public void WhenIHoverOverTheCustomerInvoiceOptionForTheDeliveredShipment()
        {
            Report.WriteLine("Selecting latest shipment which is delivered  status");
            SendKeys(attributeName_id, ShipmentListSearchBox_Id, "Delivered");
            int rowcount = GetCount(attributeName_xpath, ".//*[@id='ShipmentGrid']/tbody/tr[4]");
            if (rowcount >= 1)
            {
                Report.WriteLine("hover over the Customer Invoice option for the Delivered shipment");
                OnMouseOver(attributeName_id,ShipmentListGrid_InvoiceIcon_id);
            }
            else
            {
                Report.WriteLine("No Records found for the Delivered status in Shipment List Grid");
            }
        }

        [When(@"I click on Customer Invoice for the Delivered shipment")]
        public void WhenIClickOnCustomerInvoiceForTheDeliveredShipment()
        {
            Report.WriteLine("clicking on Customer Invoice for the Delivered shipment");
            Report.WriteLine("Selecting latest shipment which is delivered  status");
            SendKeys(attributeName_id, ShipmentListSearchBox_Id, "Delivered");
            int rowcount = GetCount(attributeName_xpath, ".//*[@id='ShipmentGrid']/tbody/tr[4]");
            if (rowcount >= 1)
            {
                Click(attributeName_id, ShipmentListGrid_InvoiceIcon_id);
            }
        }

        [Then(@"New tab will open for the selected customer Invoice")]
        public void ThenNewTabWillOpenForTheSelectedCustomerInvoice()
        {
            Report.WriteLine("new Tab opening");
            WindowHandling("http://dlscrm-test.rrd.com/Shipment/ViewShipmentInvoiceDocument");
        }

        [Then(@"I must be displaying with view Customer Invoice option for Delivered status of Mg Shipments")]
        public void ThenIMustBeDisplayingWithViewCustomerInvoiceOptionForDeliveredStatusOfMgShipments()
        {
            Report.WriteLine("Selecting latest shipment which is delivered  status");
            SendKeys(attributeName_id, ShipmentListSearchBox_Id, "Delivered");
            int rowcount = GetCount(attributeName_xpath, ".//*[@id='ShipmentGrid']/tbody/tr[4]");
            if (rowcount >= 1)
            {
                Report.WriteLine("I must see the Customer Invoice option for Delivered status of Mg Shipments");
                VerifyElementPresent(attributeName_id, ShipmentListGrid_InvoiceIcon_id, "Invoice Icon");
            }
            else
            {
                Report.WriteLine("No Records found for the Delivered status in Shipment List Grid");
            }
        }
                
        [Then(@"the name of Customer Invoice option will display")]
        public void ThenTheNameOfCustomerInvoiceOptionWillDisplay()
        {
            Report.WriteLine("Selecting latest shipment which is delivered  status");
            int rowcount = GetCount(attributeName_xpath, ".//*[@id='ShipmentGrid']/tbody/tr[4]");
            if (rowcount >= 1)
            {
                var TooltipMessage_UI = GetAttribute(attributeName_id, ShipmentListGrid_InvoiceIcon_id, "data-original-title");
                Assert.AreEqual(TooltipMessage_UI, "Customer Invoice");
            }
            else
            {
                Report.WriteLine("No Records found for the Delivered status in Shipment List Grid");
            }
        }

    }
}
