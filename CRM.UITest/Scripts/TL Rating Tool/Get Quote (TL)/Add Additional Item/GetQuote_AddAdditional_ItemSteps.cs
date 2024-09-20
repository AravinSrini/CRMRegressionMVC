using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace CRM.UITest.Scripts.TL_Rating_Tool.Get_Quote__TL_.Add_Additional_Item
{
    [Binding]
    public class GetQuote_AddAdditional_ItemSteps : TruckloadRatingTool
    {


        [When(@"I have click on Add Additional item button in get quote TL page")]
        public void WhenIHaveClickOnAddAdditionalItemButtonInGetQuoteTLPage()
        {
            Report.WriteLine("Click on Add Additional Item Button");
            Click(attributeName_xpath, TL_AddAdditionalItem_Button_Xpath);
        }

        [When(@"I should be able to see additional fields (.*),(.*), (.*),(.*),(.*),(.*),(.*)")]
        public void WhenIShouldBeAbleToSeeAdditionalFields(string FreightDescription, string HazardousMaterial_No_RadioButton, string HazardousMaterial_Yes_RadioButton, string Quantity, string Quantity_Type, string Freight_Weight, string Weight_Type)
        {
            Report.WriteLine("verify that all additional fields should present");            

            Report.WriteLine("Verifying the description field in the Freight Description Section");
            VerifyElementPresent(attributeName_xpath, TL_AddAdditional_FreightDescription_Xpath, FreightDescription);
            var DefaultText_description = GetAttribute(attributeName_xpath, TL_AddAdditional_FreightDescription_Xpath, "placeholder");
            Assert.AreEqual(FreightDescription, DefaultText_description);

            VerifyElementPresent(attributeName_xpath, TL_AddAdditional_HazMatNo_RadioButton_Xpath, HazardousMaterial_No_RadioButton);
            VerifyElementPresent(attributeName_xpath, TL_AddAdditional_HazMatYes_RadioButton_Xpath, HazardousMaterial_Yes_RadioButton);
            
            Report.WriteLine("Verifying the Quantity field in the Freight Description");
            VerifyElementPresent(attributeName_xpath, TL_AddAdditional_Quantity_Xpath, Quantity);
            var DefaultText_Quantity = GetAttribute(attributeName_xpath, TL_AddAdditional_Quantity_Xpath, "placeholder");
            Assert.AreEqual(Quantity, DefaultText_Quantity);

            Report.WriteLine("Verifying the Quantity Type field in the Frieght Description section and default select Skids");
            VerifyElementPresent(attributeName_xpath, TL_AddAdditional_QuantityType_Xpath, Quantity_Type);
            var Defaulttext_QuantityType = Gettext(attributeName_xpath, TL_AddAdditional_QuantityType_Xpath);
            Assert.AreEqual(Quantity_Type, Defaulttext_QuantityType);


            Report.WriteLine("Verifying the weight field in the Frieght Description section");
            VerifyElementPresent(attributeName_xpath, TL_AddAdditional_Weight_Xpath, Freight_Weight);
            var Defaulttext_weight = GetAttribute(attributeName_xpath, TL_AddAdditional_Weight_Xpath, "placeholder");
            Assert.AreEqual(Freight_Weight, Defaulttext_weight);


            Report.WriteLine("Verifying the Weight Type field in the Frieght Description section and default select LBS");
            VerifyElementPresent(attributeName_xpath, TL_AddAdditional_WeightType_Xpath, Weight_Type);
            var Defaulttext_WeightType = Gettext(attributeName_xpath, TL_AddAdditional_WeightType_Xpath);
            Assert.AreEqual(Weight_Type, Defaulttext_WeightType);


        }

        [Then(@"I should be able to see the (.*) and (.*)")]
        public void ThenIShouldBeAbleToSeeTheAnd(string RemoveButton, string ADDAdditionalItem)
        {
            Report.WriteLine("verify the Remove and add additional item button should be present");
            VerifyElementPresent(attributeName_xpath, TL_AddAdditional_Remove_Button_Xpath, RemoveButton);
            VerifyElementPresent(attributeName_xpath, TL_AddAdditionalItem_Button_Xpath, ADDAdditionalItem);
        }

        [Then(@"I should be able to see (.*) is selected by default")]
        public void ThenIShouldBeAbleToSeeIsSelectedByDefault(string HazardousMaterial_No_RadioButton)
        {
            Report.WriteLine("verify the HazMat radio button is by default selected as NO ");
            VerifyElementEnabled(attributeName_xpath, TL_AddAdditional_HazMatNo_RadioButton_Xpath, "DefaultNoRadioBtn");
        }

        [When(@"I click on the Remove button in get quote TL page")]
        public void WhenIClickOnTheRemoveButtonInGetQuoteTLPage()
        {
            Report.WriteLine("I click on Remove button ");
            Click(attributeName_xpath, TL_AddAdditional_Remove_Button_Xpath);
            Thread.Sleep(1000);
        }

        [Then(@"I should not be able to see additional fields (.*),(.*), (.*),(.*),(.*),(.*),(.*) and (.*)")]
        public void ThenIShouldNotBeAbleToSeeAdditionalFieldsAnd(string FreightDescription, string HazardousMaterial_No_RadioButton, string HazardousMaterial_Yes_RadioButton, string Quantity, string Quantity_Type, string Freight_Weight, string Weight_Type, string RemoveButton)
        {
            Report.WriteLine("Verifing that we are not able to see the Additional item field after clicking on remove button ");
            VerifyElementNotPresent(attributeName_xpath, TL_AddAdditional_FreightDescription_Xpath, FreightDescription);
            VerifyElementNotPresent(attributeName_xpath, TL_AddAdditional_HazMatNo_RadioButton_Xpath, HazardousMaterial_No_RadioButton);
            VerifyElementNotPresent(attributeName_xpath, TL_AddAdditional_HazMatYes_RadioButton_Xpath, HazardousMaterial_Yes_RadioButton);
            VerifyElementNotPresent(attributeName_xpath, TL_AddAdditional_Quantity_Xpath, Quantity);
            VerifyElementNotPresent(attributeName_xpath, TL_AddAdditional_QuantityType_Xpath, Quantity_Type);
            VerifyElementNotPresent(attributeName_xpath, TL_AddAdditional_Weight_Xpath, Freight_Weight);
            VerifyElementNotPresent(attributeName_xpath, TL_AddAdditional_WeightType_Xpath, Weight_Type);
            VerifyElementNotPresent(attributeName_xpath, TL_AddAdditional_Remove_Button_Xpath, RemoveButton);

        }

        [When(@"I have selected the HazardousMaterial Yes RadioButton radion button")]
        public void WhenIHaveSelectedTheHazardousMaterialYesRadioButtonRadionButton()
        {
            Report.WriteLine("i have select the Yes radio buttion for HazMat Additional item section");
            RadiobuttonSelection(attributeName_xpath, TL_AddAdditional_HazMatYes_RadioButton_Xpath);
        }

        [Then(@"I should be able to see (.*), (.*), (.*), (.*), (.*), and (.*)")]
        public void ThenIShouldBeAbleToSeeAnd(string Add_UN_Number, string Add_CCN_Number, string Add_HazmatPackageGroup_DropDown, string Add_HazmatClass_DropDown, string Add_ResponseContactName, string Add_EmergencyResponsePhone_Number)
        {
            
            Report.WriteLine("Verifying the UN Number field in the Hazardous Section");
            VerifyElementPresent(attributeName_xpath, TL_AddAdditionalHazMat_UN_Number_Xpath, Add_UN_Number);
            var DefaultText_UNNumber = GetAttribute(attributeName_xpath, TL_AddAdditionalHazMat_UN_Number_Xpath, "placeholder");
            Assert.AreEqual(Add_UN_Number, DefaultText_UNNumber);

           
            Report.WriteLine("Verifying the CCN Number field in the Hazardous Section");
            VerifyElementPresent(attributeName_xpath, TL_AddAdditionalHazMat_CCN_Number_Xpath, Add_CCN_Number);
            var DefaultText_CCNNumber = GetAttribute(attributeName_xpath, TL_AddAdditionalHazMat_CCN_Number_Xpath, "placeholder");
            Assert.AreEqual(Add_CCN_Number, DefaultText_CCNNumber);
            
            Report.WriteLine("Verifying the HazMat Package Group field in the Hazardous Section");
            VerifyElementPresent(attributeName_xpath, TL_AddAdditionalHazMat_HazMatPackageGroup_Dropdown_Xpath, Add_HazmatPackageGroup_DropDown);
            var DefaultText_HazmatPackage_Group = Gettext(attributeName_xpath, TL_AddAdditionalHazMat_HazMatPackageGroup_Dropdown_Xpath);
            Assert.AreEqual(Add_HazmatPackageGroup_DropDown, DefaultText_HazmatPackage_Group);
                        
            Report.WriteLine("Verifying the HazMat Class field in the Hazardous Section");
            VerifyElementPresent(attributeName_xpath, TL_AddAdditionalHazMat_HazMatClass_Dropdown_Xpath, Add_HazmatClass_DropDown);
            var DefaultText_HazmatClass = Gettext(attributeName_xpath, TL_AddAdditionalHazMat_HazMatClass_Dropdown_Xpath);
            Assert.AreEqual(Add_HazmatClass_DropDown, DefaultText_HazmatClass);
                        
            Report.WriteLine("Verifying the Response Contact ame field in the Hazardous Section");
            VerifyElementPresent(attributeName_xpath, TL_AddAdditionalHazMat_ResponseContactName_Xpath, Add_ResponseContactName);
            var DefaultText_ContactName = GetAttribute(attributeName_xpath, TL_AddAdditionalHazMat_ResponseContactName_Xpath, "placeholder");
            Assert.AreEqual(Add_ResponseContactName, DefaultText_ContactName);
            
            Report.WriteLine("Verifying the Emergency Response Phone field in the Hazardous Section");
            VerifyElementPresent(attributeName_xpath, TL_AddAdditionalHazMat_EmergencyResponsePhone_Number_Xpath, Add_EmergencyResponsePhone_Number);
            var DefaultText_PhoneNumber = GetAttribute(attributeName_xpath, TL_AddAdditionalHazMat_EmergencyResponsePhone_Number_Xpath, "placeholder");
            Assert.AreEqual(Add_EmergencyResponsePhone_Number, DefaultText_PhoneNumber);
        }

    }
}
