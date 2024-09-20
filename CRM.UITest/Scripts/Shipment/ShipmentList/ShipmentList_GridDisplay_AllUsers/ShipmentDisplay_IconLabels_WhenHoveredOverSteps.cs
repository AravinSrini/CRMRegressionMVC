using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.IdentityModel.Protocols;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Configuration;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.ShipmentList.ShipmentList_GridDisplay_AllUsers
{
    [Binding]
    public class Shipment_DisplayIconLabelsWhenHoveredOverSteps : Shipmentlist
    {
        [Given(@"I am an external user who has access to the application")]
        public void GivenIAmAnExternalUserWhoHasAccessToTheApplication()
        {
            string username = ConfigurationManager.AppSettings["username-Both"].ToString();
            string password = ConfigurationManager.AppSettings["password-Both"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"I am on Shipment List page")]
        public void GivenIAmOnShipmentListPage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ShipmentIcon_Id);
            Report.WriteLine("Navigated to shipment list page");
        }

        [Given(@"I am an internal user who has access to the application")]
        public void GivenIAmAnInternalUserWhoHasAccessToTheApplication()
        {
            string username = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
            string password = ConfigurationManager.AppSettings["password-crmOperation"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [When(@"I mouse hover on More Information icon for LTL shipments")]
        public void WhenIMouseHoverOnMoreInformationIconForLTLShipments()
        {
            int ShipmentCount = GetCount(attributeName_xpath, ShipmentList_AllRowsGrid_Xpath);
            if (ShipmentCount >= 1)
            {
                OnMouseOver(attributeName_xpath, ShipmentList_MoreIcon_Xpath);
                Report.WriteLine("Mouse hovered on More information icon");
            }
            else
            {
                Report.WriteLine("No Records found");
            }
        }

        [When(@"I mouse hover on Copy shipment icon for LTL shipments")]
        public void WhenIMouseHoverOnCopyShipmentIconForLTLShipments()
        {
            int ShipmentCount = GetCount(attributeName_xpath, ShipmentList_AllRowsGrid_Xpath);
            if (ShipmentCount >= 1)
            {
                OnMouseOver(attributeName_xpath, ShipmentList_CopyShipIcon_Xpath);
                Report.WriteLine("Mouse hovered on Copy information icon");
            }
            else
            {
                Report.WriteLine("No Records found");
            }
        }

        [Given(@"I search for LTL Shipments")]
        public void GivenISearchForLTLShipments()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_id, ShipmentListSearchBox_Id, "LTL");
        }

        [When(@"I mouse hover on Return shipment icon for LTL shipments")]
        public void WhenIMouseHoverOnReturnShipmentIconForLTLShipments()
        {
            int ShipmentCount = GetCount(attributeName_xpath, ShipmentList_AllRowsGrid_Xpath);
            if (ShipmentCount >= 1)
            {
                OnMouseOver(attributeName_xpath, ShipmentList_ReturnShipIcon_Xpath);
                Report.WriteLine("Mouse hovered on Return information icon");
            }
            else
            {
                Report.WriteLine("No Records found");
            }
        }

        [Given(@"I choose a Customer from the dropdown list")]
        public void GivenIChooseACustomerFromTheDropdownList()
        {
            Click(attributeName_xpath, ShipmentListInternal_CustomerDropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, ShipmentListInternal_CustDropdownVal_Xpath, "ZZZ - Czar Customer Test");
            Report.WriteLine("Customer is chosen");
        }


        [Then(@"I should be able to view a tool tip labeled More Information\.")]
        public void ThenIShouldBeAbleToViewAToolTipLabeledMoreInformation_()
        {   
             var MoreInfoToolTipVal = GetAttribute(attributeName_xpath, ShipmentList_MoreIcon_Xpath, "data-original-title");
             Assert.AreEqual(MoreInfoToolTipVal, "More Information");           
        }

        [Then(@"I should be able to view a tool tip labeled Copy Shipment\.")]
        public void ThenIShouldBeAbleToViewAToolTipLabeledCopyShipment_()
        {
            var CopyInfoToolTipVal = GetAttribute(attributeName_xpath, ShipmentList_CopyShipIcon_Xpath, "data-title");
            Assert.AreEqual(CopyInfoToolTipVal, "Copy Shipment");
        }

        [Then(@"I should be able to view a tool tip labeled Return Shipment\.")]
        public void ThenIShouldBeAbleToViewAToolTipLabeledReturnShipment_()
        {
            var ReturnInfoToolTipVal = GetAttribute(attributeName_xpath, ShipmentList_ReturnShipIcon_Xpath, "data-title");
            Assert.AreEqual(ReturnInfoToolTipVal, "Return Shipment");
        }
    }
}
