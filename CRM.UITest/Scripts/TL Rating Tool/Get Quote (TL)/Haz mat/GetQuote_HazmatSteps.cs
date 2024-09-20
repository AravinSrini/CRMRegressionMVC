using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.TL_Rating_Tool.Get_Quote__TL_.Haz_mat
{
    [Binding]
    public class GetQuote_HazmatSteps : TruckloadRatingTool
    {
        [When(@"I click on the hazardous material Yes radio button")]
        public void WhenIClickOnTheHazardousMaterialYesRadioButton()
        {
            Report.WriteLine("Click on Hazardous Materials");
            Click(attributeName_xpath, TL_HazardousMaterials_Yes_Button_Xpath);
        }
        [Then(@"I must be able to see (.*), (.*), (.*), (.*), (.*), and (.*)")]
        public void ThenIMustBeAbleToSeeAnd(string UN_Number, string CCN_Number, string HazmatPackageGroup_DropDown, string HazmatClass_DropDown, string ResponseContactName, string EmergencyResponsePhone_Number)
        {
            Report.WriteLine("I must be able to see all fields");
            VerifyElementPresent(attributeName_xpath, TL_HazardousMaterials_UN_Number_Xpath, UN_Number);
            VerifyElementPresent(attributeName_xpath, TL_HazardousMaterials_CCN_Number_Xpath, CCN_Number);
            VerifyElementPresent(attributeName_xpath, TL_HazardousMaterials_HazMatPackageGroup_Dropdown_Xpath, HazmatPackageGroup_DropDown);
            VerifyElementPresent(attributeName_xpath, TL_HazardousMaterials_HazMatClass_Dropdown_Xpath, HazmatClass_DropDown);
            VerifyElementPresent(attributeName_xpath, TL_HazardousMaterials_ResponseContactName_Xpath, ResponseContactName);
            VerifyElementPresent(attributeName_xpath, TL_HazardousMaterials_EmergencyResponsePhone_Number_Xpath, EmergencyResponsePhone_Number);

        }

        [Then(@"I must be able to see all required field border Color in orange")]
        public void ThenIMustBeAbleToSeeAllRequiredFieldBorderColorInOrange()
        {
            {
                string ExpectedborderColor = "rgb(255, 184, 69)";
                Report.WriteLine("UN_Number field border showing in Orange Color");
                string ActualUNborderColor = GetCSSValue(attributeName_xpath, TL_HazardousMaterials_UN_Number_Xpath, "border-color");
                Assert.AreEqual(ExpectedborderColor, ActualUNborderColor);

                Report.WriteLine("CCN_Number field border is showing in Orange Color");
                string ActualCCNborderColor = GetCSSValue(attributeName_xpath, TL_HazardousMaterials_CCN_Number_Xpath, "border-color");
                Assert.AreEqual(ExpectedborderColor, ActualCCNborderColor);

                Report.WriteLine("HazMat Package group dropdown border is showing in Orange Color");
                string ActualHazMatpackagegrpborderColor = GetCSSValue(attributeName_xpath, TL_HazardousMaterials_HazMatPackageGroup_Dropdown_Xpath, "border-color");
                Assert.AreEqual(ExpectedborderColor, ActualHazMatpackagegrpborderColor);

                Report.WriteLine("HazMat Class dropdown border is showing in Orange Color");
                string ActualHazMatClassborderColor = GetCSSValue(attributeName_xpath, TL_HazardousMaterials_HazMatClass_Dropdown_Xpath, "border-color");
                Assert.AreEqual(ExpectedborderColor, ActualHazMatClassborderColor);

                Report.WriteLine("Response Contact name border is showing in Oranage Color");
                string ActualResponsecntctborderColor = GetCSSValue(attributeName_xpath, TL_HazardousMaterials_ResponseContactName_Xpath, "border-color");
                Assert.AreEqual(ExpectedborderColor, ActualResponsecntctborderColor);

                Report.WriteLine("Emergency Response phone number is showing in Oranage Color");
                string ActualEmergencyphoneborderColor = GetCSSValue(attributeName_xpath, TL_HazardousMaterials_EmergencyResponsePhone_Number_Xpath, "border-color");
                Assert.AreEqual(ExpectedborderColor, ActualEmergencyphoneborderColor);
            }
        }


        [When(@"I click on the hazardous material No radio button")]
        public void WhenIClickOnTheHazardousMaterialNoRadioButton()
        {
            Report.WriteLine("Click on Hazardous Material No Radio button");
            Click(attributeName_xpath, TL_HazardousMaterials_No_Button_Xpath);
            Thread.Sleep(1000);
        }

        [Then(@"I should not be able to see (.*), (.*), (.*), (.*), (.*), and (.*)")]
        public void ThenIShouldNotBeAbleToSeeAnd(string UN_Number, string CCN_Number, string HazmatPackageGroup_DropDown, string HazmatClass_DropDown, string ResponseContactName, string EmergencyResponsePhone_Number)
        {
            Report.WriteLine("I should not be able to see all Hazardous Materials fields");

            VerifyElementNotVisible(attributeName_xpath, TL_HazardousMaterials_UN_Number_Xpath, UN_Number);
            VerifyElementNotVisible(attributeName_xpath, TL_HazardousMaterials_CCN_Number_Xpath, CCN_Number);
            VerifyElementNotVisible(attributeName_xpath, TL_HazardousMaterials_HazMatPackageGroup_Dropdown_Xpath, HazmatPackageGroup_DropDown);
            VerifyElementNotVisible(attributeName_xpath, TL_HazardousMaterials_HazMatClass_Dropdown_Xpath, HazmatClass_DropDown);
            VerifyElementNotVisible(attributeName_xpath, TL_HazardousMaterials_ResponseContactName_Xpath, ResponseContactName);
            VerifyElementNotVisible(attributeName_xpath, TL_HazardousMaterials_EmergencyResponsePhone_Number_Xpath, EmergencyResponsePhone_Number);

        }

        [When(@"I enter Zipcode (.*) and leave focus from the origin section in GetQuote\(TL\) page")]
        public void WhenIEnterZipcodeAndLeaveFocusFromTheOriginSectionInGetQuoteTLPage(string ShippingFrom_ValidZip)
        {
            Report.WriteLine("I enter the zipcode for Origin section in get quote TL page");
            SendKeys(attributeName_id, TL_ShippingFromZip_Textbox_ID, ShippingFrom_ValidZip);
        }
        [When(@"I enter Zipcode (.*) and leave focus from the destination section in GetQuote\(TL\) page")]
        public void WhenIEnterZipcodeAndLeaveFocusFromTheDestinationSectionInGetQuoteTLPage(string ShippingTo_ValidZip)
        {
            Report.WriteLine("I enter the zipcode for Destination section in get quote TL page");
            SendKeys(attributeName_id, TL_ShippingToZip_Textbox_ID, ShippingTo_ValidZip);
        }

        [When(@"I should be able to enter '(.*)' in the Description text field")]
        public void WhenIShouldBeAbleToEnterInTheDescriptionTextField(string descriptiontext)
        {
            Report.WriteLine("I entered the text for freight description");
            SendKeys(attributeName_id, EnterDescriptionField_id, descriptiontext);
        }

        [When(@"I should be able to enter '(.*)' in the Quantity text field")]
        public void WhenIShouldBeAbleToEnterInTheQuantityTextField(string quantity)
        {
            Report.WriteLine("I enter the quantity in get quote TL page ");
            SendKeys(attributeName_id, TLQuantity_id, quantity);
        }
        [When(@"I should be able to enter '(.*)' in the Weight text field")]
        public void WhenIShouldBeAbleToEnterInTheWeightTextField(string Freight_Weight)
        {
            Report.WriteLine("I enter the weight in get quote TL page");
            SendKeys(attributeName_id, TLweight_id, Freight_Weight);
        }

        [When(@"I click on the Get Live Quote button in Get Quote TL page")]
        public void WhenIClickOnTheGetLiveQuoteButtonInGetQuoteTLPage()
        {
            Report.WriteLine("I click on Get Live Quote button in get quote TL page");
            Click(attributeName_xpath, TL_GetLiveQuoteButton_xpath);
            Thread.Sleep(1000);
        }

        [Then(@"I should be able to see the all fields background color as red")]
        public void ThenIShouldBeAbleToSeeTheAllFieldsBackgroundColorAsRed()
        {
            string ExpectedbackgroundColor = "url(\"http://dlsww-dev.rrd.com/images/formicons.png\"), linear-gradient(rgb(251, 236, 236), rgb(251, 236, 236))";
            Report.WriteLine("I should be able to see all required field background color in red ");
            string ActualUNbackgroundColor = GetCSSValue(attributeName_xpath, TL_HazardousMaterials_UN_Number_Xpath, "background-image");
            Assert.AreEqual(ExpectedbackgroundColor, ActualUNbackgroundColor);

            string ActualCCNbackgroundColor = GetCSSValue(attributeName_xpath, TL_HazardousMaterials_CCN_Number_Xpath, "background-image");
            Assert.AreEqual(ExpectedbackgroundColor, ActualCCNbackgroundColor);

            string ExpectedbackgrounddrpColor = "url(\"http://dlsww-dev.rrd.com/Content/images/formicons.png\"), linear-gradient(rgb(251, 236, 236), rgb(251, 236, 236))";
            string ActualHazMatpackagegrpbackgroundColor = GetCSSValue(attributeName_xpath, TL_HazardousMaterials_HazMatPackageGroup_Dropdown_Xpath, "background-image");
            Assert.AreEqual(ExpectedbackgrounddrpColor, ActualHazMatpackagegrpbackgroundColor);

            string ActualHazMatClassbackgroundColor = GetCSSValue(attributeName_xpath, TL_HazardousMaterials_HazMatClass_Dropdown_Xpath, "background-image");
            Assert.AreEqual(ExpectedbackgrounddrpColor, ActualHazMatClassbackgroundColor);


            string ActualResponsecntctbackgroundColor = GetCSSValue(attributeName_xpath, TL_HazardousMaterials_ResponseContactName_Xpath, "background-image");
            Assert.AreEqual(ExpectedbackgroundColor, ActualResponsecntctbackgroundColor);

            string ActualEmergencyphonebackgroundColor = GetCSSValue(attributeName_xpath, TL_HazardousMaterials_EmergencyResponsePhone_Number_Xpath, "background-image");
            Assert.AreEqual(ExpectedbackgroundColor, ActualEmergencyphonebackgroundColor);

        }

    }


}
