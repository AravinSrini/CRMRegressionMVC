using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment__LTL__2019
{
    [Binding]
    public class _76032_Add_Shipment__LTL__2019___Page_ElementsSteps : AddShipments
    {
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
        string StationandCustomerSelected;

        [Given(@"I am a shpentry, shpentrynorates user")]
        public void GivenIAmAShpentryShpentrynoratesUser()
        {
            string userName = ConfigurationManager.AppSettings["username-NewScreenShipEntryUser"].ToString();
            string password = ConfigurationManager.AppSettings["password-NewScreenShipEntryUser"].ToString();            
            CrmLogin.LoginToCRMApplication(userName, password);
        }

        [When(@"I arrive on the Add Shipment - \(LTL\) page for External user")]
        public void WhenIArriveOnTheAddShipment_LTLPageForExternalUser()
        {
            Report.WriteLine("Click on shipment icon");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, ShipmentIcon_Xpath);
            Click(attributeName_id, ShipmentList_AddShipmentButton_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ShipmentList_LTLtile_Id);       
        }

        [Then(@"I will see the Add Shipment \(LTL\) label")]
        public void ThenIWillSeeTheAddShipmentLTLLabel()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Verifytext(attributeName_xpath, AddShipment_LTL_2019_PageTitle_xpath, "Add Shipment (LTL)");
        }

        [Then(@"the verbiage beneath the Add Shipment \(LTL\) label as (.*)")]
        public void ThenTheVerbiageBeneathTheAddShipmentLTLLabelAs(string RequiredFieldVerbiage)
        {
            string ExpectedRequiredVerbiage = Regex.Replace(RequiredFieldVerbiage, "[^0-9A-Za-z ,]", "");
            string ActualVerbiage = Gettext(attributeName_xpath, AddShipmentLTL_2019_RquiredFieldVerbiage_xpath);
            Assert.AreEqual(ActualVerbiage, ExpectedRequiredVerbiage);

            
        }

        [Then(@"Back to Shipment List button")]
        public void ThenBackToShipmentListButton()
        {
            Verifytext(attributeName_id, BacktoShipmentList_2019_Id, "Back to Shipment List");
        }

        [Then(@"Shipment From Section")]
        public void ThenShipmentFromSection()
        {
            Verifytext(attributeName_xpath, AddShipmentLTL_2019_ShippingFromSectionTitle_xpath, "Shipping From");
        }

        [Then(@"Shipment To Section")]
        public void ThenShipmentToSection()
        {
            Verifytext(attributeName_xpath, AddShipmentLTL_2019_ShippingToSectionTitle_xpath, "Shipping To");
        }

        [Then(@"Pickup Date Section")]
        public void ThenPickupDateSection()
        {
            Verifytext(attributeName_xpath, AddShipmentLTL_2019_PickupDateSectionTitle_xpath, "Pickup Date");
        }

        [Then(@"Special Instructions Section")]
        public void ThenSpecialInstructionsSection()
        {
            Verifytext(attributeName_xpath, AddShipmentLTL_2019_SpecialInstructionsSectionTitle_xpath, "Special Instructions");
        }

        [Then(@"Insured Value Section")]
        public void ThenInsuredValueSection()
        {
            Verifytext(attributeName_xpath, AddShipmentLTL_2019_InsuredValueSectionTitle_xpath, "Insured Value");
        }

        [Then(@"Reference Numbers Section")]
        public void ThenReferenceNumbersSection()
        {
            VerifyElementPresent(attributeName_xpath, AddShipmentLTL_2019_ReferenceNumberSectionTitle_xpath, "Reference Numbers");

        }

        [Then(@"Freight Description Section")]
        public void ThenFreightDescriptionSection()
        {
            Verifytext(attributeName_xpath, AddShipmentLTL_2019_FreightDescriptionSectionTitle_xpath, "Freight Description");
        }

        [Then(@"View Rates button")]
        public void ThenViewRatesButton()
        {
            Verifytext(attributeName_xpath, AddShipmentLTL_2019_ViewRatesButton_xpath, "View Rates");
        }

        [Given(@"I am a operations, sales management or station owner user")]
        public void GivenIAmAOperationsSalesManagementOrStationOwnerUser()
        {
            string userName = ConfigurationManager.AppSettings["username-NewScreenCrmOperationUser"].ToString();
            string password = ConfigurationManager.AppSettings["password-NewScreenCrmOperationUser"].ToString();
            CrmLogin.LoginToCRMApplication(userName, password);
        }

        [When(@"I arrive on the (.*) Add Shipment - \(LTL\) page for Internal user")]
        public void WhenIArriveOnTheAddShipment_LTLPageForInternalUser(string Customer)
        {
            Customer = "ZZZ - Czar Customer Test";            
            Report.WriteLine("Click on shipment icon");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, ShipmentIcon_Xpath);
            Report.WriteLine("Customer Selection dropdown");
            Click(attributeName_xpath, AllCustomerDropdown_Selection_Internal_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, AllCustomerDroppdownValues_Internal_Xpath, Customer);

            StationandCustomerSelected = Gettext(attributeName_xpath, ".//*[@id='CustomerType_chosen']/a/span");

            Report.WriteLine("Click on Add Shipment button Internal users");
            Click(attributeName_id, AddShipmentButtionInternal_Id);

            Report.WriteLine("Click on LTL tile");
            Click(attributeName_id, ShipmentServiceTypeLTL_id);
        }

        [When(@"I arrive on the (.*) Add Shipment - \(LTL\) page for Sales user")]
        public void WhenIArriveOnTheAddShipment_LTLPageForSalesUser(string Customer)
        {
            Customer = "ZZZ - GS Demo";            
            Report.WriteLine("Click on shipment icon");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, ShipmentIcon_Xpath);
            Report.WriteLine("Customer Selection dropdown");
            Click(attributeName_xpath, AllCustomerDropdown_Selection_Internal_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, AllCustomerDroppdownValues_Internal_Xpath, Customer);

            StationandCustomerSelected = Gettext(attributeName_xpath, ".//*[@id='CustomerType_chosen']/a/span");

            Report.WriteLine("Click on Add Shipment button Internal users");
            Click(attributeName_id, AddShipmentButtionInternal_Id);

            Report.WriteLine("Click on LTL tile");
            Click(attributeName_id, ShipmentServiceTypeLTL_id);
        }

        [Then(@"I should see the selected Station and Customer name displayed on the Add Shipment \(LTL\) page")]
        public void ThenIShouldSeeTheSelectedStationAndCustomerNameDisplayedOnTheAddShipmentLTLPage()
        {
            Report.WriteLine("View Staion name - Customer name");
            string UIStationandCustomerName = Gettext(attributeName_id, AddShipmentLTL_2019_StationandCustomerName_Id);

            Assert.AreEqual(StationandCustomerSelected, UIStationandCustomerName);

        }

        [Then(@"I should not be able to edit the displayed Station and Customer name")]
        public void ThenIShouldNotBeAbleToEditTheDisplayedStationAndCustomerName()
        {
            IsElementDisabled(attributeName_xpath, AddShipmentLTL_StationCustomerNotEditable_2019_xpath, "Station-Customer");
        }

        [Given(@"I arrive on the Add Shipment - \(LTL\) page for External user")]
        public void GivenIArriveOnTheAddShipment_LTLPageForExternalUser()
        {
            Report.WriteLine("Click on shipment icon");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, ShipmentIcon_Xpath);
            Click(attributeName_id, ShipmentList_AddShipmentButton_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ShipmentList_LTLtile_Id);
        }

        [When(@"I clicked on the Back to Shipment List button")]
        public void WhenIClickedOnTheBackToShipmentListButton()
        {
            Click(attributeName_id, BacktoShipmentList_2019_Id);
        }

        [Then(@"I should be navigated to the Shipment List page")]
        public void ThenIShouldBeNavigatedToTheShipmentListPage()
        {
            Verifytext(attributeName_cssselector, ShipmentListHeader_2019_css, "Shipment List");
        }

        [Given(@"I arrive on the (.*) Add Shipment \(LTL\) page for Internal user")]
        public void GivenIArriveOnTheAddShipmentLTLPageForInternalUser(string Customer)
        {
            Customer = "ZZZ - Czar Customer Test";            
            Report.WriteLine("Click on shipment icon");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, ShipmentIcon_Xpath);
            Report.WriteLine("Customer Selection dropdown");
            Click(attributeName_xpath, AllCustomerDropdown_Selection_Internal_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, AllCustomerDroppdownValues_Internal_Xpath, Customer);

            StationandCustomerSelected = Gettext(attributeName_xpath, ".//*[@id='CustomerType_chosen']/a/span");

            Report.WriteLine("Click on Add Shipment button Internal users");
            Click(attributeName_id, AddShipmentButtionInternal_Id);

            Report.WriteLine("Click on LTL tile");
            Click(attributeName_id, ShipmentServiceTypeLTL_id);
        }

        [Given(@"I arrive on the (.*) Add Shipment \(LTL\) page for Sales user")]
        public void GivenIArriveOnTheAddShipmentLTLPageForSalesUser(string Customer)
        {
            Customer = "ZZZ - GS Customer Test";
            Report.WriteLine("Click on shipment icon");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, ShipmentIcon_Xpath);
            Report.WriteLine("Customer Selection dropdown");
            Click(attributeName_xpath, AllCustomerDropdown_Selection_Internal_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, AllCustomerDroppdownValues_Internal_Xpath, Customer);

            StationandCustomerSelected = Gettext(attributeName_xpath, ".//*[@id='CustomerType_chosen']/a/span");

            Report.WriteLine("Click on Add Shipment button Internal users");
            Click(attributeName_id, AddShipmentButtionInternal_Id);

            Report.WriteLine("Click on LTL tile");
            Click(attributeName_id, ShipmentServiceTypeLTL_id);
        }
















    }
}
