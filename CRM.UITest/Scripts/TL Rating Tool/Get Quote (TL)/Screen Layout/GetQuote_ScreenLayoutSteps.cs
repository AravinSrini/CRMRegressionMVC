using System;
using CRM.UITest.Objects;
using CRM.UITest.CommonMethods;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.TL_Rating_Tool.Get_Quote__TL_.Screen_Layout
{
    [Binding]
    public class GetQuote_ScreenLayoutSteps : TruckloadRatingTool
    {
        [Given(@"I clicked on Rating Tool icon")]
        public void GivenIClickedOnRatingToolIcon()
        {
            Report.WriteLine("Clicking on the Rating Tool Icon from Left navigation pane");
            ((IJavaScriptExecutor)GlobalVariables.webDriver).ExecuteScript("document.body.style.zoom = '90%'");
            ((IJavaScriptExecutor)GlobalVariables.webDriver).ExecuteScript("$('#ratingTools').trigger('click')");
            GlobalVariables.webDriver.WaitForPageLoad();
            ((IJavaScriptExecutor)GlobalVariables.webDriver).ExecuteScript("document.body.style.zoom = '100%'");
        }

        [When(@"I click on the calender to select the (.*)")]
        public void WhenIClickOnTheCalenderToSelectThe(int PickupDate)
        {
            Click(attributeName_xpath, "html/body/div[4]/section/div[4]/form/div[1]/div[3]/div/div[1]/span/i");
            DatePickerFromCalander(attributeName_xpath, "html/body/div[7]/div[1]/table/tbody/tr/td", PickupDate, "html/body/div[7]/div[1]/table/thead/tr[1]/th[3]/i");
        }

        [When(@"I click on the DatePicker calender to select the (.*)")]
        public void WhenIClickOnTheDatePickerCalenderToSelectThe(string PickupDate)
        {
            Click(attributeName_xpath, "html/body/div[4]/section/div[4]/form/div[1]/div[3]/div/div[1]/span/i");
            DatePickerFromCalander(attributeName_xpath, "html/body/div[7]/div[1]/table/tbody/tr/td",Convert.ToInt32(PickupDate), "html/body/div[7]/div[1]/table/thead/tr[1]/th[3]/i");
        }

        [Then(@"I should be navigated to the Get Quote TL page with text as (.*)")]
        public void ThenIShouldBeNavigatedToTheGetQuoteTLPageWithTextAs(string GetQuoteText)
        {
            Report.WriteLine("Get Quote Truckload page Header");
            Verifytext(attributeName_xpath, TL_GetQuote_Title_Xpath, GetQuoteText);
            
        }

        [Then(@"I should be able to see the '(.*)'")]
        public void ThenIShouldBeAbleToSeeThe(string BackToRatingTools_Button)
        {
            Report.WriteLine("Verify the Back To Rating Tools button");
            Verifytext(attributeName_xpath, TL_BackToRatingTools_Button_Xpath, BackToRatingTools_Button);
          
        }


        [Then(@"I should be able to see the '(.*)' for required fields")]
        public void ThenIShouldBeAbleToSeeTheForRequiredFields(string RequiredField_Text)
        {
            Report.WriteLine("Verify the Warning Message for the Required Fields");
            Verifytext(attributeName_xpath, TL_WarningMessage_Orange_xpath, RequiredField_Text);
        }


       

        [Then(@"I should be able to see the StationName, EquipmentType and (.*) fields")]
        public void ThenIShouldBeAbleToSeeTheStationNameEquipmentTypeAndFields(string SpecialInstructions)
        {
            
            VerifyElementPresent(attributeName_xpath, TL_StationName_Xpath, "StationName");
            VerifyElementPresent(attributeName_xpath, TL_EquipmentType_Xpath, "EquipmentType");

            Report.WriteLine("Verifying the the Special Instructions field");
            VerifyElementPresent(attributeName_id, TL_SpecialInstructions_Id, "SpecialInstructions");
            var DefaultText_description = GetAttribute(attributeName_id, TL_SpecialInstructions_Id, "placeholder");
            Assert.AreEqual(SpecialInstructions, DefaultText_description);

        }

        [Then(@"I should be able to see the (.*), (.*), (.*), (.*) in the Shipping From Section with (.*)")]
        public void ThenIShouldBeAbleToSeeTheInTheShippingFromSectionWith(string ShippingFrom_Zipcode_Postal, string ShippingFrom_Country, string ShippingFrom_City, string ShippingFrom_SelectState_Province, string ShippingFromLable)
        {
            VerifyElementPresent(attributeName_id, TL_ShippingFromZip_Textbox_ID, "ZipCode");
            var DefaultText_FromZipcode = GetAttribute(attributeName_id, TL_ShippingFromZip_Textbox_ID, "placeholder");
            Assert.AreEqual(ShippingFrom_Zipcode_Postal, DefaultText_FromZipcode);

            VerifyElementPresent(attributeName_id, TL_ShippingFrom_City_Textbox_ID, "City");
            var DefaultText_FromCity = GetAttribute(attributeName_id, TL_ShippingFrom_City_Textbox_ID, "placeholder");
            Assert.AreEqual(ShippingFrom_City, DefaultText_FromCity);


            VerifyElementPresent(attributeName_xpath, TL_ShippingFrom_StateProvince_Dropdown_Xpath, "State/Province");
            var DefaultText_FromState = Gettext(attributeName_xpath, TL_ShippingFrom_StateProvince_Dropdown_Xpath);
            Assert.AreEqual(ShippingFrom_SelectState_Province, DefaultText_FromState);

            VerifyElementPresent(attributeName_xpath, TL_ShippingFrom_Country_Dropdown_Xpath, "Country");
            var DefaultText_FromCountry = Gettext(attributeName_xpath, TL_ShippingFrom_Country_Dropdown_Xpath);
            Assert.AreEqual(ShippingFrom_Country, DefaultText_FromCountry);

            Report.WriteLine("Verifying the Shipping From lable in the Get Quote (TL) page");
            Verifytext(attributeName_xpath, TL_ShippingFrom_Lable_xpath, ShippingFromLable);


        }

        [Then(@"I should be able to see the (.*), (.*), (.*), (.*) in the Shipping To Section with (.*)")]
        public void ThenIShouldBeAbleToSeeTheInTheShippingToSectionWith(string ShippingTo_Zipcode_Postal, string ShippingTo_Country, string ShippingTo_City, string ShippingTo_SelectState_Province, string ShippingToLable)
        {
            VerifyElementPresent(attributeName_id, TL_ShippingToZip_Textbox_ID, "ZipCode");
            var DefaultText_ToZipcode = GetAttribute(attributeName_id, TL_ShippingToZip_Textbox_ID, "placeholder");
            Assert.AreEqual(ShippingTo_Zipcode_Postal, DefaultText_ToZipcode);

            VerifyElementPresent(attributeName_id, TL_ShippingTo_City_Textbox_ID, "City");
            var DefaultText_ToCity = GetAttribute(attributeName_id, TL_ShippingTo_City_Textbox_ID, "placeholder");
            Assert.AreEqual(ShippingTo_City, DefaultText_ToCity);


            VerifyElementPresent(attributeName_xpath, TL_ShippingTo_StateProvince_Dropdown_Xpath, "State/Province");
            var DefaultText_ToState = Gettext(attributeName_xpath, TL_ShippingTo_StateProvince_Dropdown_Xpath);
            Assert.AreEqual(ShippingTo_SelectState_Province, DefaultText_ToState);

            VerifyElementPresent(attributeName_xpath, TL_ShippingTo_Country_Dropdown_Xpath, "Country");
            var DefaultText_ToCountry = Gettext(attributeName_xpath, TL_ShippingTo_Country_Dropdown_Xpath);
            Assert.AreEqual(ShippingTo_Country, DefaultText_ToCountry);

            Report.WriteLine("Verifying the Shipping To lable in the Get Quote (TL) page");
            Verifytext(attributeName_xpath, TL_ShippingTo_Lable_xpath, ShippingToLable);
        }


        [Then(@"I should be able to see the Pick_upDate, PickUp_FromTime, PickUp_ToTime with (.*)  in Pick up Date Picker section")]
        public void ThenIShouldBeAbleToSeeThePick_UpDatePickUp_FromTimePickUp_ToTimeWithInPickUpDatePickerSection(string PickUpDate_Lable)
        {
            VerifyElementPresent(attributeName_id, TL_PickupDate_Id, "Pickupdate");
            VerifyElementPresent(attributeName_xpath, TL_pickstart, "PickUpReadyToTime");
            VerifyElementPresent(attributeName_xpath, TL_pickend, "PickUpCloseToTime");
            Report.WriteLine("Verifying the PickUp Date lable in the Get Quote (TL) page");
            Verifytext(attributeName_xpath, TL_PickUpDate_Lable_xpath, PickUpDate_Lable);
        }

        [Then(@"I should be able to see the DropOffDate, DropOff_FromTime , DropOff_ToTime with (.*) in DropOff Date Picker section")]
        public void ThenIShouldBeAbleToSeeTheDropOffDateDropOff_FromTimeDropOff_ToTimeWithInDropOffDatePickerSection(string DropOffDate_Lable)
        {
            VerifyElementPresent(attributeName_id, TL_PickupDate_Id, "TL_DropoffDate_Id");
            VerifyElementPresent(attributeName_xpath, TL_dropstart, "DropOffReadyToTime");
            VerifyElementPresent(attributeName_xpath, TL_dropend, "DropOffCloseToTime");
            Report.WriteLine("Verifying the Drop off lable in the Get Quote (TL) page");
            Verifytext(attributeName_xpath, TL_DropOffDate_Lable_xpath, DropOffDate_Lable);
        }

        [Then(@"I should be able to (.*),(.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), with Add_Additional_Item and Get Live Quote Button")]
        public void ThenIShouldBeAbleToWithAdd_Additional_ItemAndGetLiveQuoteButton(string FreightDescription_Lable, string FreightDescription, string HazardousMaterial_Yes_RadioButton, string HazardousMaterial_No_RadioButton, string Quantity, string Quantity_Type, string Freight_Weight, string Weight_Type, string InsuredValue)
        {
            Report.WriteLine("Verifying the Freight Description lable in the Get Quote (TL) page");
            Verifytext(attributeName_xpath, FreightDescriptionlable_xpath, FreightDescription_Lable);

            Report.WriteLine("Verifying the description field in the Freight Description");
            VerifyElementPresent(attributeName_id, EnterDescriptionField_id, "EnterDescription");
            var DefaultText_description = GetAttribute(attributeName_id, EnterDescriptionField_id, "placeholder");
            Assert.AreEqual(FreightDescription, DefaultText_description);

            VerifyElementPresent(attributeName_xpath, TL_Hazmat_YesButton_xpath, HazardousMaterial_Yes_RadioButton);
            VerifyElementPresent(attributeName_xpath, TL_Hazmat_NoButton_xpath, HazardousMaterial_No_RadioButton);

            Report.WriteLine("Verifying the Quantity field in the Freight Description");
            VerifyElementPresent(attributeName_id, TLQuantity_id, "Quantity");
            var DefaultText_Quantity = GetAttribute(attributeName_id, TLQuantity_id, "placeholder");
            Assert.AreEqual(Quantity, DefaultText_Quantity);

            Report.WriteLine("Verifying the Quantity Type field in the Frieght Description section and default select Skids");
            VerifyElementPresent(attributeName_id, TLQuantityType_id, "QuantityType");
            var Defaulttext_QuantityType = Gettext(attributeName_xpath, TLQuantityType_xpath);
            Assert.AreEqual(Quantity_Type, Defaulttext_QuantityType);


            Report.WriteLine("Verifying the weight field in the Frieght Description section");
            VerifyElementPresent(attributeName_id, TLweight_id, "weight");
            var Defaulttext_weight = GetAttribute(attributeName_id, TLweight_id, "placeholder");
            Assert.AreEqual(Freight_Weight, Defaulttext_weight);


            Report.WriteLine("Verifying the Weight Type field in the Frieght Description section and default select LBS");
            var Defaulttext_WeightType = Gettext(attributeName_xpath, TLWeightType_xpath);
            Assert.AreEqual(Weight_Type, Defaulttext_WeightType);

            Report.WriteLine("Verifying the Insured field in the Frieght Description section ");            
            VerifyElementPresent(attributeName_id, TL_EnterInsuredValue_Id, "InsuredValue");
            var Defaulttext_InsuredValue = GetAttribute(attributeName_id, TL_EnterInsuredValue_Id, "placeholder");
            Assert.AreEqual(InsuredValue, Defaulttext_InsuredValue);
        }

        [Then(@"I should be able to see the Question Mark with tool tip as (.*)")]
        public void ThenIShouldBeAbleToSeeTheQuestionMarkWithToolTipAs(string QuestionMark_Information)
        {
            OnMouseOver(attributeName_xpath, TL_tooltipiconmsg_xpath);
            string ActualHover_Message = GetAttribute(attributeName_xpath, TL_tooltipiconmsg_xpath, "data-title");
            Assert.AreEqual(QuestionMark_Information, ActualHover_Message);
        }




        [Then(@"all the required fields must be highlighted")]
        public void ThenAllTheRequiredFieldsMustBeHighlighted()
        {
            Report.WriteLine("I should see the orange color rectangle for the Shipping From field");
            var colorofthe_ShippingFromZipCode_Field = GetCSSValue(attributeName_id, TL_ShippingFromZip_Textbox_ID, "border-bottom-color");
            Assert.AreEqual("rgba(255, 184, 69, 1)", colorofthe_ShippingFromZipCode_Field);

            Report.WriteLine("I should see the orange color rectangle for the Shipping To field");
            var colorofthe_ShippingToZipCode_Field = GetCSSValue(attributeName_id, TL_ShippingToZip_Textbox_ID, "border-bottom-color");
            Assert.AreEqual("rgba(255, 184, 69, 1)", colorofthe_ShippingToZipCode_Field);

            Report.WriteLine("I should see the orange color rectangle for the Enter Description field");
            var colorofthe_description_Field = GetCSSValue(attributeName_id, EnterDescriptionField_id, "border-bottom-color");
            Assert.AreEqual("rgba(255, 184, 69, 1)", colorofthe_description_Field);

            Report.WriteLine("I should see the orange color rectangle for the Enter quantity field");
            var colorofthe_Quantity_Field = GetCSSValue(attributeName_id, TLQuantity_id, "border-bottom-color");
            Assert.AreEqual("rgba(255, 184, 69, 1)", colorofthe_Quantity_Field);

            Report.WriteLine("I should see the orange color rounded rectangle for the Enter Weight field");
            var colorofthe_Weight_Field = GetCSSValue(attributeName_id, TLweight_id, "border-bottom-color");
            Assert.AreEqual("rgba(255, 184, 69, 1)", colorofthe_Weight_Field);
        }



    }
}
