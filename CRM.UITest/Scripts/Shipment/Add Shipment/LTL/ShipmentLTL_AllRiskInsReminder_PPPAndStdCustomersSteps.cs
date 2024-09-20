using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Objects;
using Microsoft.IdentityModel.Protocols;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL
{
    [Binding]
    public class ShipmentLTL_AllRiskInsReminder_PPPAndStdCustomersSteps : AddShipments
    {
        string Station_Name = "ZZZ - Web Services Test";
        string InsuredValuePPP = "16,000.00";
        string InsuredValueStandard = "$100,000.01";
        CommonMethodsCrm crm = new CommonMethodsCrm();
        [Given(@"I am a shp\.entrynorates, shp\.entry, sales, sales management, operations, or station owner user")]
        public void GivenIAmAShp_EntrynoratesShp_EntrySalesSalesManagementOperationsOrStationOwnerUser()
        {
            string username = ConfigurationManager.AppSettings["username-OperationsCrm"].ToString();
            string password = ConfigurationManager.AppSettings["password-OperationsCrm"].ToString();
            crm.LoginToCRMApplication(username, password);
        }

        [Given(@"I am associated to a customer with PPP all-risk insurance setting")]
        public void GivenIAmAssociatedToACustomerWithPPPAll_RiskInsuranceSetting()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ShipmentIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            string PPPCustomer = DBHelper.GetPPP_Customer(Station_Name);
            Click(attributeName_xpath, AllCustomerDropdown_Selection_Internal_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, AllCustomerDroppdownValues_Internal_Xpath, PPPCustomer);
            Report.WriteLine("PPP Customer is been selected from the dropdown");
        }

        [Given(@"The customer in which I am associated does not have PPP all-risk insurance setting")]
        public void GivenTheCustomerInWhichIAmAssociatedDoesNotHavePPPAll_RiskInsuranceSetting()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ShipmentIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            string StdCustomer = DBHelper.GetStandard_Customer(Station_Name);
            Click(attributeName_xpath, AllCustomerDropdown_Selection_Internal_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, AllCustomerDroppdownValues_Internal_Xpath, StdCustomer);
            Report.WriteLine("Standard Customer is been selected from the dropdown");

        }

        [Given(@"I am creating an LTL shipment")]
        public void GivenIAmCreatingAnLTLShipment()
        {
            Click(attributeName_id, AddShipmentButtionInternal_Id);
            Report.WriteLine("Clicked on Add shipment button");
            Click(attributeName_id, AddShipmentLTL_Button_Id);
            Report.WriteLine("Clicked on LTL tile on Adds shipment page");
        }

        [Given(@"I am on the Add Shipment\(LTL\) page")]
        public void GivenIAmOnTheAddShipmentLTLPage()
        {
            Verifytext(attributeName_xpath, AddShipment_PageTitle_xpath, "Add Shipment (LTL)");
            Report.WriteLine("Navigated to Shipment list page");
        }

        [When(@"I enter a value greater than \$(.*)\.(.*) in (.*) field")]
        public void WhenIEnterAValueGreaterThan_InField(Decimal p0, int p1, string InsuredValue)
        {
            VerifyElementPresent(attributeName_id, InsuredValue_TextBox_Id, InsuredValue);
            SendKeys(attributeName_id, InsuredValue_TextBox_Id, "16,000.00");
            Report.WriteLine("Entered value greater than $15,000.00 in Add shipment LTL page");
        }

        [When(@"I enter a value less than \$(.*)\.(.*) in (.*) field")]
        public void WhenIEnterAValueLessThan_InField(Decimal p0, int p1, string InsuredField)
        {
            VerifyElementPresent(attributeName_id, InsuredValue_TextBox_Id, InsuredField);
            SendKeys(attributeName_id, InsuredValue_TextBox_Id, "14,000.00");
            Report.WriteLine("Entered a value less than $15,000.00 in Add shipment LTL page");

        }

        [When(@"I enter a Value equal to \$(.*)\.(.*) in (.*) field")]
        public void WhenIEnterAValueEqualTo_InField(Decimal p0, int p1, string InsuredField)
        {
            
            VerifyElementPresent(attributeName_id, InsuredValue_TextBox_Id, InsuredField);
            SendKeys(attributeName_id, InsuredValue_TextBox_Id, "15,000.00");
            Report.WriteLine("Entered a value equal to $15,000.00 in Add shipment LTL page");
            Click(attributeName_id, ShipResults_ShowInsuredRateButton_Id);
        }

        [When(@"I enter a Value less than \$(.*)\.(.*) on (.*) field")]
        public void WhenIEnterAValueLessThan_OnField(Decimal p0, int p1, string InsuredField)
        {
            VerifyElementPresent(attributeName_xpath, ShipResultsInsuredValue_Xpath, InsuredField);
            SendKeys(attributeName_xpath, ShipResultsInsuredValue_Xpath, "$14,000.00");
            Report.WriteLine("Entered a value less than $15,000.00 in Add shipment LTL page");
            Click(attributeName_id, ShipResults_ShowInsuredRateButton_Id);
        }

        [When(@"I enter a value equal to \$(.*)\.(.*) on (.*) field")]
        public void WhenIEnterAValueEqualTo_OnField(Decimal p0, int p1, string InsuredField)
        {
            VerifyElementPresent(attributeName_xpath, ShipResultsInsuredValue_Xpath, InsuredField);
            SendKeys(attributeName_xpath, ShipResultsInsuredValue_Xpath, "$15,000.00");
            Report.WriteLine("Entered a value equal to $15,000.00 in Add shipment LTL page");
             Click(attributeName_id, ShipResults_ShowInsuredRateButton_Id);
        }

        [When(@"I enter a value less than \$(.*)\.(.*) in the (.*) field of the Insured Rates modal")]
        public void WhenIEnterAValueLessThan_InTheFieldOfTheInsuredRatesModal(Decimal p0, int p1, string InsuredField)
        {
            Click(attributeName_xpath, ShipmentResult_CreateShipmentButton_Xpath);
            Report.WriteLine("Clicked on create shipment button");
            Thread.Sleep(3000);
            VerifyElementPresent(attributeName_xpath, ShipResultsInsuredValModal_Xpath, InsuredField);
            MoveToElement(attributeName_xpath, ShipResultsInsuredValModal_Xpath);
            SendKeys(attributeName_xpath, ShipResultsInsuredValModal_Xpath, "$14,000.00");
            Report.WriteLine("Entered a value less than $15,000.00 in the insured rates Modal of Shipment results page");
            Click(attributeName_xpath, ShipResultsShowInsuredRateButton_Modal_Xpath);
            Report.WriteLine("Clicked on Show insured rates button on insured rates modal");
        }

        [When(@"I enter a value equal to \$(.*)\.(.*) in the (.*) field of the Insured Rates modal")]
        public void WhenIEnterAValueEqualTo_InTheFieldOfTheInsuredRatesModal(Decimal p0, int p1, string InsuredField)
        {
            Click(attributeName_xpath, ShipmentResult_CreateShipmentButton_Xpath);
            Report.WriteLine("Clicked on create shipment button");
            Thread.Sleep(3000);
            VerifyElementPresent(attributeName_xpath, ShipResultsInsuredValModal_Xpath, InsuredField);
            SendKeys(attributeName_xpath, ShipResultsInsuredValModal_Xpath, "$15,000.00");
            Report.WriteLine("Entered a value equal to $15,000.00 in the insured rates Modal of Shipment results page");
            Click(attributeName_xpath, ShipResultsShowInsuredRateButton_Modal_Xpath);
            Report.WriteLine("Clicked on Show insured rates button on insured rates modal");

        }

        [Then(@"All Risk Ins Reminder message will not be displayed on Insured Rates modal of Shipment Results page")]
        public void ThenAllRiskInsReminderMessageWillNotBeDisplayedOnInsuredRatesModalOfShipmentResultsPage()
        {
            VerifyElementNotVisible(attributeName_xpath, ShipResultsInsuredRatesModalErrorMessage_Xpath, "ErrorMessage");
            Report.WriteLine("All Risk Ins Reminder message is not displayed on Insured Rates modal of Shipment Results page");
        }


        [Then(@"All Risk Ins Reminder message will not be displayed on Shipment Results \(LTL\) page")]
        public void ThenAllRiskInsReminderMessageWillNotBeDisplayedOnShipmentResultsLTLPage()
        {

            VerifyElementNotPresent(attributeName_xpath, ShipResultsInsuredValueError_Xpath, "Error");
            Report.WriteLine("All Risk Ins Reminder message will not be displayed on Shipment Results page");
        }

        [Then(@"All Risk Ins Reminder message will not be displayed on Add Shipment\(LTL\) page")]
        public void ThenAllRiskInsReminderMessageWillNotBeDisplayedOnAddShipmentLTLPage()
        {
            VerifyElementNotVisible(attributeName_xpath, ErrorHeadingInsured_Xpath, "Error");
            Report.WriteLine("All Risk Ins Reminder message is not displayed on Add Shipment(LTL) page");
        }

        [Given(@"I entered a value greater than \$(.*)\.(.*) on the (.*) field of the Insured Rates modal")]
        public void GivenIEnteredAValueGreaterThan_OnTheFieldOfTheInsuredRatesModal(Decimal p0, int p1, string InsuredField)
        {
            Thread.Sleep(3000);
            VerifyElementPresent(attributeName_xpath, ShipResultsInsuredValModal_Xpath, InsuredField);
            SendKeys(attributeName_xpath, ShipResultsInsuredValModal_Xpath, InsuredValueStandard);
            Report.WriteLine("Entered a value greater than $100,000.00 in the insured rates Modal of Shipment results page");
       }

        [Given(@"I am on the Shipment Results\(LTL\) page")]
        public void GivenIAmOnTheShipmentResultsLTLPage()
        {
            Verifytext(attributeName_xpath, AddShipment_PageTitle_xpath, "Add Shipment (LTL)");
            Report.WriteLine("Navigated to Shipment list page");
            scrollElementIntoView(attributeName_id, ShippingFrom_ClearAddress_Id);
            SendKeys(attributeName_id, ShippingFrom_LocationName_Id, "test");
            SendKeys(attributeName_id, ShippingFrom_LocationAddressLine1_Id, "Address");
            SendKeys(attributeName_id, ShippingFrom_zipcode_Id, "60606");
            scrollElementIntoView(attributeName_id, ShippingTo_LocationName_Id);
            SendKeys(attributeName_id, ShippingTo_LocationName_Id, "testing");
            SendKeys(attributeName_id, ShippingTo_LocationAddressLine1_Id, "addressdest");
            SendKeys(attributeName_id, ShippingTo_zipcode_Id, "60606");
            scrollElementIntoView(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            Click(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            scrollElementIntoView(attributeName_xpath, FreightDesp_SectionText_xpath);
            MoveToElement(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id);
            Click(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id);
            Thread.Sleep(3000);
            IList<IWebElement> dropdownValues = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='scrollable-dropdown-menu-Origin']/div/span[1]/span/div/span/div/p"));
            for (int i = 0; i < dropdownValues.Count; i++)
            {
                int z = i + 1;
                string value = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='scrollable-dropdown-menu-Origin']/div/span[1]/span/div/span/div[" + z + "]/p")).Text;
                if (value == "65")
                {
                    GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='scrollable-dropdown-menu-Origin']/div/span[1]/span/div/span/div[" + z + "]/p")).Click();
                    break;
                }
            }
            SendKeys(attributeName_id, FreightDesp_FirstItem_NMFC_Id, "34");
            SendKeys(attributeName_id, FreightDesp_FirstItem_Quantity_Id, "1");
            SendKeys(attributeName_id, FreightDesp_FirstItem_Weight_Id, "5");
            SendKeys(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id, "Description");
            Clear(attributeName_id, FreightDesp_FirstItem_Length_Id);
            Clear(attributeName_id, FreightDesp_FirstItem_Width_Id);
            Clear(attributeName_id, FreightDesp_FirstItem_Height_Id);
            Click(attributeName_xpath, ViewRatesButton_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            VerifyElementPresent(attributeName_xpath, ShipResults_PageHeaderText_Relativexpath, "Shipment Results (LTL)");
            Report.WriteLine("Navigated to Shipment Results page");

        }

        [Given(@"I did not enter a value in (.*) field")]
        public void GivenIDidNotEnterAValueInField(string InsuredVal)
        {
            VerifyElementPresent(attributeName_xpath, ShipResultsInsuredValue_Xpath, InsuredVal);
            Clear(attributeName_xpath, ShipResultsInsuredValue_Xpath);
            Report.WriteLine("No value is entered in Insured value field");
        }

        [Given(@"I Clicked on (.*) button")]
        public void GivenIClickedOnButton(string ShipButton)
        {
            VerifyElementPresent(attributeName_xpath, ShipmentResult_CreateShipmentButton_Xpath, ShipButton);
            Click(attributeName_xpath, ShipmentResult_CreateShipmentButton_Xpath);
            Report.WriteLine("Clicked on create shipment button");

        }

        [Given(@"I entered a value greater than \$(.*)\.(.*) in (.*) field of the Insured Rates modal")]
        public void GivenIEnteredAValueGreaterThan_InFieldOfTheInsuredRatesModal(Decimal p0, int p1, string InsuredField)
        {
            Thread.Sleep(3000);
            VerifyElementPresent(attributeName_xpath, ShipResultsInsuredValModal_Xpath, InsuredField);
            SendKeys(attributeName_xpath, ShipResultsInsuredValModal_Xpath, InsuredValuePPP);
            Report.WriteLine("Entered a value greater than $15,000.00 in the insured rates Modal of Shipment results page");
        }

        [When(@"I click on (.*) button of Insured Rates modal")]
        public void WhenIClickOnButtonOfInsuredRatesModal(string p0)
        {
            Click(attributeName_xpath, ShipResultsShowInsuredRateButton_Modal_Xpath);
            Report.WriteLine("Clicked on Show insured rates button on insured rates modal");
        }

        [Then(@"I will receive a message: '(.*)' beneath Insured value field of modal")]
        public void ThenIWillReceiveAMessageBeneathInsuredValueFieldOfModal(string ErrorMessage)
        {
            Verifytext(attributeName_xpath, ShipResultsInsuredRatesModalErrorMessage_Xpath, ErrorMessage.ToUpper());
            Report.WriteLine("Expected Error message is displayed when user enters a value greater than $15,000.00 in Insured Value field of the Insured Rates modal");
        }

        [Then(@"I will receive a message: '(.*)' beneath Insured value field of the modal")]
        public void ThenIWillReceiveAMessageBeneathInsuredValueFieldOfTheModal(string ErrorMessage)
        {
            Verifytext(attributeName_xpath, ShipResultsInsuredRatesModalErrorMessage_Xpath, ErrorMessage.ToUpper());
            Report.WriteLine("Expected Error message is displayed when user enters a value greater than $100,000.00 in Insured Value field of the Insured Rates modal");

        }

        [Then(@"I have an option to continue without insured rates\.")]
        public void ThenIHaveAnOptionToContinueWithoutInsuredRates_()
        {
            VerifyElementPresent(attributeName_xpath, ShipResultsModalWithoutInsuredRates_Xpath, "WithoutInsuredRatesButton");
            Report.WriteLine("Continue without insured rates option is present ");
        }

        [Then(@"I will receive a error message:'(.*)'")]
        public void ThenIWillReceiveAErrorMessage(string ErrorHeading)
        {
            Verifytext(attributeName_xpath, ErrorHeadingInsured_Xpath, ErrorHeading.ToUpper());
            Report.WriteLine("Error is displayed");
        }

        [Then(@"Message will read '(.*)'")]
        public void ThenMessageWillRead(string ErrorMessage)
        {
            Verifytext(attributeName_xpath, ErrorMessageInsured_Xpath, ErrorMessage);
            Report.WriteLine("Error message is displyed on Add shipment LTL page when insured value exceeds $15,000.00");
        }

        [Then(@"I have an option to remove the message")]
        public void ThenIHaveAnOptionToRemoveTheMessage()
        {
            VerifyElementPresent(attributeName_xpath, ErrorMessageCloseIcon_Xpath,"Remove option");
            Report.WriteLine("Error message remove option is present in Add shipment LTL page");
            Click(attributeName_xpath, ErrorMessageCloseIcon_Xpath);
            Report.WriteLine("Error message is removed");
        }

        [Then(@"I will not be able to see (.*)")]
        public void ThenIWillNotBeAbleToSee(string Rates)
        {
            Click(attributeName_xpath, Shipments_ViewRatesButton_xpath);
            VerifyElementNotPresent(attributeName_xpath, ShipResults_PageHeaderText_Relativexpath, "Shipment Results (LTL)");
            Report.WriteLine("User is not able to see view rates");
        }

        [When(@"I enter a value greater than \$(.*)\.(.*) on (.*) field")]
        public void WhenIEnterAValueGreaterThan_OnField(Decimal p0, int p1, string InsuredField)
        {
            VerifyElementPresent(attributeName_xpath, ShipResultsInsuredValue_Xpath, InsuredField);
            SendKeys(attributeName_xpath, ShipResultsInsuredValue_Xpath, InsuredValuePPP);
            Report.WriteLine("Entered value greater than $15,000.00 in Add shipment LTL page");
            Click(attributeName_id, ShipResults_ShowInsuredRateButton_Id);
        }

         [When(@"I enter a Value greater than \$(.*)\.(.*) on the (.*) field")]
        public void WhenIEnterAValueGreaterThan_OnTheField(Decimal p0, int p1, string InsuredField)
        {
            VerifyElementPresent(attributeName_xpath, ShipResultsInsuredValue_Xpath, InsuredField);
            SendKeys(attributeName_xpath, ShipResultsInsuredValue_Xpath, InsuredValueStandard);
            Report.WriteLine("Entered value greater than $100,000.00 in Add shipment LTL page");
            Click(attributeName_id, ShipResults_ShowInsuredRateButton_Id);
        }


        [Then(@"I will receive a message: '(.*)' beneath the Insured value field")]
        public void ThenIWillReceiveAMessageBeneathTheInsuredValueField(string ErrorMessage)
        {
            Verifytext(attributeName_xpath, ShipResultsInsuredValueError_Xpath, ErrorMessage.ToUpper());
            Report.WriteLine("Error message is displyed on Add shipment LTL page when insured value exceeds $15,000.00");
        }

        [Then(@"I will receive a message: '(.*)' beneath Insured value field")]
        public void ThenIWillReceiveAMessageBeneathInsuredValueField(string ErrorMessage)
        {
            Verifytext(attributeName_xpath, ShipResultsInsuredValueError_Xpath, ErrorMessage.ToUpper());
            Report.WriteLine("Error message is displyed on Shipment results page when insured value exceeds $100,000.00");
        }

    }
}
