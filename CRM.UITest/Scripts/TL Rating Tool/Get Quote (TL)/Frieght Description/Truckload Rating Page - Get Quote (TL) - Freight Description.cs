using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.TL_Rating_Tool.Get_Quote__TL_.Frieght_Description
{
    [Binding]
    public class Truckload_Rating_Page___Get_Quote__TL____Freight_Description : TruckloadRatingTool
    {
        [When(@"I enter data in the required fields '(.*)', '(.*)' and '(.*)' in rating tool page")]
        [When(@"I enter data in the required fields '(.*)', '(.*)' and select the PickupDate in rating tool page")]
        public void WhenIEnterDataInTheRequiredFieldsAndSelectThePickupDateInRatingToolPage(int OriginZipCode, int DestinationZipCode)
        {
            Report.WriteLine("Enter valid data in the required fields in Projected Amount page");

            SendKeys(attributeName_id, ProjectedAmount_OriginZip_Textbox_Id, OriginZipCode.ToString());
            SendKeys(attributeName_id, ProjectedAmount_DestinationZip_Textbox_Id, DestinationZipCode.ToString());
            Click(attributeName_cssselector, ProjectedAmount_Calendar_css);
            DatePickerFromCalander(attributeName_xpath, ProjectedAmount_Activeday_xpath, 0, ProjectedAmount_RightClickCalendar_xpath);
        }

        [When(@"I Click on Get Rate button in rating tool page")]
        public void WhenIClickOnGetRateButtonInRatingToolPage()
        {
            Report.WriteLine("Click on Get Rate button in rating tool page");
            Click(attributeName_id, ProjectedAmount_GetRate_Button_ID);
        }

        [When(@"I click on Get Quote Now button in rating tool page")]
        public void WhenIClickOnGetQuoteNowButtonInRatingToolPage()
        {
            Report.WriteLine("Click on Get Quote Now button in rating tool page");
            Click(attributeName_id, ProjectedAmount_GetQuoteNow_Button_ID);
        }

        [Then(@"I should see an option to enter a Freight Description with '(.*)' and'(.*)'")]
        public void ThenIShouldSeeAnOptionToEnterAFreightDescriptionWithAnd(string lable, string defaulttext)
        {
            Report.WriteLine("Verifying the Freight Description lable in the Get Quote (TL) page");
            Verifytext(attributeName_xpath, FreightDescriptionlable_xpath, lable);

            Report.WriteLine("Verifying the description field in the Freight Description");
            VerifyElementPresent(attributeName_id, EnterDescriptionField_id, "EnterDescription");
            var DefaultText_description = GetAttribute(attributeName_id, EnterDescriptionField_id, "placeholder");
            Assert.AreEqual(defaulttext, DefaultText_description);
        }

        [Then(@"I should be able to enter free form text '(.*)' in the Description text field")]
        public void ThenIShouldBeAbleToEnterFreeFormTextInTheDescriptionTextField(string descriptiontext)
        {
            Report.WriteLine("Verifying Description text field should accept free form text");
            SendKeys(attributeName_id, EnterDescriptionField_id, descriptiontext);
        }

        [Then(@"I should see Freight Description field as required field by verifying the field border color should be in Orange")]
        public void ThenIShouldSeeFreightDescriptionFieldAsRequiredFieldByVerifyingTheFieldBorderColorShouldBeInOrange()
        {
            Report.WriteLine("I should see the orange color rectangle for the Enter Description field");
            var colorofthedescription_Field = GetCSSValue(attributeName_id, EnterDescriptionField_id, "border-bottom-color");
            Assert.AreEqual("rgba(255, 184, 69, 1)", colorofthedescription_Field);
        }

        [Then(@"I should see an option to enter a Quantity with '(.*)'")]
        public void ThenIShouldSeeAnOptionToEnterAQuantityWith(string Qntdefaulttext)
        {
            Report.WriteLine("Verifying the Quantity field in the Frieght Description section");
            VerifyElementPresent(attributeName_id, TLQuantity_id, "Quantity");
            var Defaulttext_Quantity = GetAttribute(attributeName_id, TLQuantity_id, "placeholder");
            Assert.AreEqual(Qntdefaulttext, Defaulttext_Quantity);
        }

        [Then(@"I should be able to enter '(.*)' in the Quantity text field")]
        public void ThenIShouldBeAbleToEnterInTheQuantityTextField(string quantity)
        {
            Report.WriteLine("Enter the value in Quantity field in the Frieght Description section");
            SendKeys(attributeName_id, TLQuantity_id, quantity);
        }

        [Then(@"I should see Quantity field as required field by verifying the field border color should be in Orange")]
        public void ThenIShouldSeeQuantityFieldAsRequiredFieldByVerifyingTheFieldBorderColorShouldBeInOrange()
        {
            Report.WriteLine("I should see the orange color rectangle for the Enter quantity field");
            var colorofthedescription_Field = GetCSSValue(attributeName_id, TLQuantity_id, "border-bottom-color");
            Assert.AreEqual("rgba(255, 184, 69, 1)", colorofthedescription_Field);
        }

        [Then(@"I should see quantity type value is defaulted to '(.*)'")]
        public void ThenIShouldSeeQuantityTypeValueIsDefaultedTo(string Skids)
        {
            Report.WriteLine("Verifying the Quantity Type field in the Frieght Description section and default select Skids");
            VerifyElementPresent(attributeName_id, TLQuantityType_id, "QuantityType");
            var Defaulttext_QuantityType = Gettext(attributeName_xpath, TLQuantityType_xpath);
            Assert.AreEqual(Skids, Defaulttext_QuantityType);
        }

        [Then(@"I should see weight type value is defaulted to '(.*)'")]
        public void ThenIShouldSeeWeightTypeValueIsDefaultedTo(string LBS)
        {
            Report.WriteLine("Verifying the Weight Type field in the Frieght Description section and default select LBS");
            var Defaulttext_WeightType = Gettext(attributeName_xpath, TLWeightType_xpath);
            Assert.AreEqual(LBS, Defaulttext_WeightType);
        }

        [Then(@"Verify Quantity Type field is editable field")]
        public void ThenVerifyQuantityTypeFieldIsEditableField()
        {
            Report.WriteLine("Quantity Type field in the Freight Description section should be editable");
            Click(attributeName_id, TLQuantityType_id);
            SendKeys(attributeName_xpath, TLQuantityTypetextbox_xpath, "Bags");
            Click(attributeName_xpath, TLQuantityTypeFirstOption_xpath);
            var Selectedtext_QuantityType = Gettext(attributeName_xpath, TLQuantityType_xpath);
            Assert.AreEqual("Bags", Selectedtext_QuantityType);
        }

        [Then(@"I should see an option to enter a Weight with '(.*)'")]
        public void ThenIShouldSeeAnOptionToEnterAWeightWith(string Wgtdefaulttext)
        {
            Report.WriteLine("Verifying the weight field in the Frieght Description section");
            VerifyElementPresent(attributeName_id, TLweight_id, "weight");
            var Defaulttext_weight = GetAttribute(attributeName_id, TLweight_id, "placeholder");
            Assert.AreEqual(Wgtdefaulttext, Defaulttext_weight);
        }

        [Then(@"I should see Weight field as required field by verifying the field border color should be in Orange")]
        public void ThenIShouldSeeWeightFieldAsRequiredFieldByVerifyingTheFieldBorderColorShouldBeInOrange()
        {
            Report.WriteLine("I should see the orange color rounded rectangle for the Enter Weight field");
            var coloroftheweight_Field = GetCSSValue(attributeName_id, TLweight_id, "border-bottom-color");
            Assert.AreEqual("rgba(255, 184, 69, 1)", coloroftheweight_Field);
        }

        [Then(@"I should be able to enter '(.*)' in the Weight text field")]
        public void ThenIShouldBeAbleToEnterInTheWeightTextField(int weight)
        {
            Report.WriteLine("Enter the value in Weight field in the Frieght Description section");
            SendKeys(attributeName_id, TLweight_id, weight.ToString());
        }

        [Then(@"Verify Weight field is editable field")]
        public void ThenVerifyWeightFieldIsEditableField()
        {
            Report.WriteLine("Weight Type field in the Freight Description section should be editable");
            Click(attributeName_id, TLWeightType_id);
            Click(attributeName_xpath, TLWeightTypeSecondOption_xpath);
            var Selectedtext_WeightType = Gettext(attributeName_xpath, TLWeightType_xpath);
            Assert.AreEqual("KILOS", Selectedtext_WeightType);
        }

        [Then(@"I click on  Quantity Type field dropdown in the Get Quote \(TL\) page")]
        public void ThenIClickOnQuantityTypeFieldDropdownInTheGetQuoteTLPage()
        {
            Report.WriteLine("clicking on Quantity Type field drop down");
            Click(attributeName_id, TLQuantityType_id);
        }

        [Then(@"The '(.*)' should be displayed in quantity unit field dropdown list")]
        public void ThenTheShouldBeDisplayedInQuantityUnitFieldDropdownList(string options)
        {
            Report.WriteLine("All required fields should display in Quantity Type drop down");
            List<string> QuantityDropdownValues_UI = GetDropdownValues(attributeName_id, TLQuantityType_id, "li");
            List<string> QuantityOptions_Expected = new List<string>(options.Split(','));
            foreach (string Quantity in QuantityOptions_Expected)
            {
                if (QuantityDropdownValues_UI.Contains(Quantity))
                {
                    Console.WriteLine(Quantity + "field is present in the dropdown");
                }
                else
                {
                    Console.WriteLine("Matching not found for " + Quantity);
                }
            }
        }

        [Then(@"I click on  Weight field dropdown in the Get Quote \(TL\) page")]
        public void ThenIClickOnWeightFieldDropdownInTheGetQuoteTLPage()
        {
            Report.WriteLine("clicking on Quantity Type field drop down");
            Click(attributeName_id, TLWeightType_id);
        }

        [Then(@"The '(.*)' should be displayed in weight unit field dropdown list")]
        public void ThenTheShouldBeDisplayedInWeightUnitFieldDropdownList(string options)
        {
            Report.WriteLine("All required fields should display in Quantity Type drop down");
            List<string> WeightDropdownValues_UI = GetDropdownValues(attributeName_id, TLWeightType_id, "li");
            List<string> WeightOptions_Expected = new List<string>(options.Split(','));
            foreach (string Weight in WeightOptions_Expected)
            {
                if (WeightDropdownValues_UI.Contains(Weight))
                {
                    Console.WriteLine(Weight + "field is present in the dropdown");
                }
                else
                {
                    Console.WriteLine("Matching not found for " + Weight);
                }
            }
        }

    }
}
