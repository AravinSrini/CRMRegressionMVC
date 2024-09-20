using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Information_Screen
{
    [Binding]
    public class AddShipmentLTL_ReferenceNumbers_AllUsersSteps : AddShipments
    {
        [Given(@"I click on Add Shipment button")]
        public void GivenIClickOnAddShipmentButton()
        {
            Report.WriteLine("Click on Add Shipment Button");
            Click(attributeName_id, AddShipmentButton_id);
        }

        [Given(@"I Click on LTL service type")]
        public void GivenIClickOnLTLServiceType()
        {
            Report.WriteLine("Click on LTL tile");
            Click(attributeName_id, ShipmentServiceTypeLTL_id);
        }

        [Given(@"I arrive on Add shipment LTL page")]
        public void GivenIArriveOnAddShipmentLTLPage()
        {
            Report.WriteLine("Add Shipment LTL page");
            Verifytext(attributeName_xpath, AddShipment_PageTitle_xpath, "Add Shipment (LTL)");

        }

        [When(@"I click on Add Additional Reference button")]
        public void WhenIClickOnAddAdditionalReferenceButton()
        {
            Report.WriteLine("Click on Add additional Reference Button");
            Click(attributeName_xpath, AddAdditionalReference_Button_xpath);
            Thread.Sleep(3000);
        }

        [Then(@"I must be able to view Reference number dropdown list")]
        public void ThenIMustBeAbleToViewReferenceNumberDropdownList()
        {
            Report.WriteLine("View Reference number dropdown list");
            VerifyElementPresent(attributeName_xpath, Additional_SelectReferenceType_DropDown_xpath, "Reference Type");
        }

        [Then(@"I must be able to view Reference number text field")]
        public void ThenIMustBeAbleToViewReferenceNumberTextField()
        {
            Report.WriteLine("View of Reference number text field");
            VerifyElementPresent(attributeName_xpath, AdditionalReferenceNumber_Value_xpath, "Reference number");
        }

        [Then(@"I should be able to view Remove button")]
        public void ThenIShouldBeAbleToViewRemoveButton()
        {
            Report.WriteLine("View Remove button");
            VerifyElementPresent(attributeName_xpath, Remove_AdditionalReference_Button_xpath, "Remove");
        }


        [Then(@"I should be able to view an error messaging indicating that the Enter reference number text field is required")]
        public void ThenIShouldBeAbleToViewAnErrorMessagingIndicatingThatTheEnterReferenceNumberTextFieldIsRequired()
        {
            Report.WriteLine("Error message");
            string ErrorMessageUI = Gettext(attributeName_xpath, ErrorMessageReferenceType_Xpath);
            Assert.AreEqual(ErrorMessageUI, "Please enter a Reference Number");
        }

        [Then(@"The Enter reference number field should be highlighted\.")]
        public void ThenTheEnterReferenceNumberFieldShouldBeHighlighted_()
        {
            var coloroftheRef = GetCSSValue(attributeName_id, ReferenceType_Highlight_Id, "background-color");
            Assert.AreEqual(coloroftheRef, "rgba(251, 236, 236, 1)");
        }

        [When(@"I try entering more than twenty five characters to reference number field")]
        public void WhenITryEnteringMoreThanTwentyFiveCharactersToReferenceNumberField()
        {
            Report.WriteLine("Enter more than 25 characters");
            SendKeys(attributeName_xpath, AdditionalReferenceNumber_Value_xpath, "12345678MIER234AEQWTYUIONSFAAWD");
        }

        [Then(@"I should not be able to enter more than twenty five charcters")]
        public void ThenIShouldNotBeAbleToEnterMoreThanTwentyFiveCharcters()
        {
            Report.WriteLine("More than 25 characters should not be entered");
            string UIRef = GetAttribute(attributeName_xpath, AdditionalReferenceNumber_Value_xpath,"value");
            Assert.AreEqual(UIRef, "12345678MIER234AEQWTYUION");

        }


        [When(@"I select Reference type without adding data to enter reference number field")]
        public void WhenISelectReferenceTypeWithoutAddingDataToEnterReferenceNumberField()
        {
            Report.WriteLine("Select Refernce from dropdown list");
            Click(attributeName_xpath, Additional_SelectReferenceType_DropDown_xpath);
            Thread.Sleep(1000);
            SelectDropdownValueFromList(attributeName_xpath, Additional_SelectReferenceType_DropDown_Values_xpath, "BOL Number");

        }

        [When(@"I expand Reference number section")]
        public void WhenIExpandReferenceNumberSection()
        {
            Report.WriteLine("Expand reference number section");
            scrollpagedown();
            Thread.Sleep(2000);
            scrollpagedown();
            Thread.Sleep(1000);
            scrollpagedown();
            Thread.Sleep(1000);
            Click(attributeName_xpath, ReferenceNumbers_ExpandSection_xpath);
            Thread.Sleep(3000);
        }

        [Then(@"I should be able to click on Add Additional Reference button")]
        public void ThenIShouldBeAbleToClickOnAddAdditionalReferenceButton()
        {
            Report.WriteLine("Click on Add Additional Reference button");
            Click(attributeName_xpath, AddAdditionalReference_Button_xpath);
            Thread.Sleep(5000);
        }

        [Then(@"I must be able to select a reference from reference dropdown list")]
        public void ThenIMustBeAbleToSelectAReferenceFromReferenceDropdownList()
        {
            Report.WriteLine("Select Refernce from dropdown list");
            Click(attributeName_xpath, Additional_SelectReferenceType_DropDown_xpath);
            Thread.Sleep(1000);
            SelectDropdownValueFromList(attributeName_xpath, Additional_SelectReferenceType_DropDown_Values_xpath, "BOL Number");
        }

        [When(@"I select reference type from reference number dropdown list")]
        public void WhenISelectReferenceTypeFromReferenceNumberDropdownList()
        {
            Report.WriteLine("Select Refernce from dropdown list");
            Click(attributeName_xpath, Additional_SelectReferenceType_DropDown_xpath);
            Thread.Sleep(1000);
            SelectDropdownValueFromList(attributeName_xpath, Additional_SelectReferenceType_DropDown_Values_xpath, "BOL Number");

        }

        [Then(@"I must be able to enter Reference number")]
        public void ThenIMustBeAbleToEnterReferenceNumber()
        {
            Report.WriteLine("Enter Reference number");
            SendKeys(attributeName_xpath, AdditionalReferenceNumber_Value_xpath, "MIG41224325");
        }

        [Then(@"I should be able to click on remove button")]
        public void ThenIShouldBeAbleToClickOnRemoveButton()
        {
            Report.WriteLine("Click on Remove Button");
            Click(attributeName_xpath, Remove_AdditionalReference_Button_xpath);
            Thread.Sleep(1000);
        }

        [Then(@"The added Additional Reference should be removed")]
        public void ThenTheAddedAdditionalReferenceShouldBeRemoved()
        {
            Report.WriteLine("Removal of Additional Reference");
            VerifyElementNotPresent(attributeName_xpath, Remove_AdditionalReference_Button_xpath, "Remove");
        }
    }
}
