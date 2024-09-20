using CRM.UITest.CommonMethods;
using CRM.UITest.Helper.Common;
using CRM.UITest.Helper.DataModels;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.AddShipment_PageElements_AllUsers
{
    [Binding]
    public class AddShipmentLTLPage_FontEnhancementsSteps : AddShipments
    {
        [Given(@"I am a DLS user of type (.*) and login into application")]
        public void GivenIAmADLSUserOfTypeAndLoginIntoApplication(string userType)
        {
            UserCredentialsModel userModel = new UserCredentialsModel();
            UserTypeLoginCredentials userObj = new UserTypeLoginCredentials();
            userModel = userObj.GetCredentials(userType);

            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(userModel.UserName, userModel.Password);
        }

        [When(@"I click on add shipment depending on the UserType (.*)")]
        public void WhenIClickOnAddShipmentDependingOnTheUserType(string userType)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementPresent(attributeName_id, ShipmentList_AddShipmentButton_Id, "Add Shipment Button");
            if (userType.Equals("external",StringComparison.InvariantCultureIgnoreCase))
            {
                WaitForElementVisible(attributeName_id, ShipmentList_AddShipmentButton_Id, "Add Shipment Button");
                Click(attributeName_id, ShipmentList_AddShipmentButton_Id);
            }
        }

        [When(@"I select (.*) from the dropdown and click on add shipment button")]
        public void WhenISelectFromTheDropdownAndClickOnAddShipmentButton(string CustomerAccName)
        {
            Report.WriteLine("Select Customer Name from the dropdown list");
            Click(attributeName_xpath, ShipmentList_CustomerSelection_Xpath);

            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_Customer_dropdownValue_Xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == CustomerAccName)
                {
                    DropDownList[i].Click();
                    break;
                }
            }
            Click(attributeName_id, AddShipmentButtionInternal_Id);
        }


        [Then(@"I Verify font-size will be increased to Twenty and font-color will be black for all fields")]
        public void ThenIVerifyFont_SizeWillBeIncreasedToTwentyAndFont_ColorWillBeBlackForAllFields()
        { 
            string font_size = "20px";
            string font_color = "rgba(0, 0, 0, 1)";

            Report.WriteLine("Verify the Shipping From Section ");

            string From_ClearAddress = GetCSSValue(attributeName_id, ShippingFrom_ClearAddress_Id, "font-size");
            Assert.AreEqual(font_size, From_ClearAddress);
       
            string From_SavedAdd = GetCSSValue(attributeName_id, ShippingFrom_SelectSavedOriginDropDown_Id, "font-size");
            Assert.AreEqual(font_size, From_SavedAdd);
            string From_SavedAdd_Color = GetCSSValue(attributeName_id, ShippingFrom_SelectSavedOriginDropDown_Id, "color");
            Assert.AreEqual(font_color, From_SavedAdd_Color);

            string From_OriginZip = GetCSSValue(attributeName_id, ShippingFrom_zipcode_Id, "font-size");
            Assert.AreEqual(font_size, From_OriginZip);
            string From_OriginZip_Color = GetCSSValue(attributeName_id, ShippingFrom_zipcode_Id, "color");
            Assert.AreEqual(font_color, From_OriginZip_Color);

            string From_OriginCountry = GetCSSValue(attributeName_xpath, ShippingFrom_CountryDropDown_SelectedValue_xpath, "font-size");
            Assert.AreEqual(font_size, From_OriginCountry);
            string From_OriginCountry_Color = GetCSSValue(attributeName_xpath, ShippingFrom_CountryDropDown_SelectedValue_xpath, "color");
            Assert.AreEqual(font_color, From_OriginCountry_Color);

            string From_OriginCity = GetCSSValue(attributeName_id, ShippingFrom_City_Id, "font-size");
            Assert.AreEqual(font_size, From_OriginCity);
            string From_OriginCity_Color = GetCSSValue(attributeName_id, ShippingFrom_City_Id, "color");
            Assert.AreEqual(font_color, From_OriginCity_Color);

            string From_OriginState = GetCSSValue(attributeName_xpath, ShippingFrom_StateDropdwon_SelectedValue_xpath, "font-size");
            Assert.AreEqual(font_size, From_OriginState);
            string From_OriginState_Color = GetCSSValue(attributeName_xpath, ShippingFrom_StateDropdwon_SelectedValue_xpath, "color");
            Assert.AreEqual(font_color, From_OriginState_Color);

            string From_ServiceAndAcc = GetCSSValue(attributeName_xpath, ShippingFrom_ServicesAccessorial_DropDown_xpath, "font-size");
            Assert.AreEqual(font_size, From_ServiceAndAcc);
            string From_ServiceAndAcc_Color = GetCSSValue(attributeName_xpath, ShippingFrom_ServicesAccessorial_DropDown_xpath, "color");
            Assert.AreEqual(font_color, From_ServiceAndAcc_Color);

            Report.WriteLine("Verify the Shipping To Section");
            VerifyElementPresent(attributeName_xpath, ShippingToSectionText_xpath, "Shipping To");

            string To_ClearAddress = GetCSSValue(attributeName_id, ShippingFrom_ClearAddress_Id, "font-size");
            Assert.AreEqual(font_size, To_ClearAddress);

            string To_SavedAdd = GetCSSValue(attributeName_id, ShippingTo_SelectSavedDestDropDown_Id, "font-size");
            Assert.AreEqual(font_size, To_SavedAdd);
            string To_SavedAdd_Color = GetCSSValue(attributeName_id, ShippingTo_SelectSavedDestDropDown_Id, "color");
            Assert.AreEqual(font_color, To_SavedAdd_Color);

            string To_DestinationZip = GetCSSValue(attributeName_id, ShippingTo_zipcode_Id, "font-size");
            Assert.AreEqual(font_size, To_DestinationZip);
            string To_DestinationZip_Color = GetCSSValue(attributeName_id, ShippingTo_zipcode_Id, "color");
            Assert.AreEqual(font_color, To_DestinationZip_Color);

            string To_DestinationCountry = GetCSSValue(attributeName_xpath, ShippingTo_CountryDropDown_SelectedValue_xpath, "font-size");
            Assert.AreEqual(font_size, To_DestinationCountry);
            string To_DestinationCountry_Color = GetCSSValue(attributeName_xpath, ShippingTo_CountryDropDown_SelectedValue_xpath, "color");
            Assert.AreEqual(font_color, To_DestinationCountry_Color);

            string To_DestinationCity = GetCSSValue(attributeName_id, ShippingTo_City_Id, "font-size");
            Assert.AreEqual(font_size, To_DestinationCity);
            string To_DestinationCity_Color = GetCSSValue(attributeName_id, ShippingTo_City_Id, "color");
            Assert.AreEqual(font_color, To_DestinationCity_Color);

            string To_DestinationState = GetCSSValue(attributeName_xpath, ShippingTo_StateDropdwon_SelectedValue_xpath, "font-size");
            Assert.AreEqual(font_size, To_DestinationState);
            string To_DestinationState_Color = GetCSSValue(attributeName_xpath, ShippingTo_StateDropdwon_SelectedValue_xpath, "color");
            Assert.AreEqual(font_color, To_DestinationState_Color);

            string To_ServiceAndAcc = GetCSSValue(attributeName_xpath, ShippingTo_ServicesAccessorial_DropDown_xpath, "font-size");
            Assert.AreEqual(font_size, To_ServiceAndAcc);
            string To_ServiceAndAcc_Color = GetCSSValue(attributeName_xpath, ShippingTo_ServicesAccessorial_DropDown_xpath, "color");
            Assert.AreEqual(font_color, To_ServiceAndAcc_Color);

            Report.WriteLine("Verify the Freight Description Section");
            string FreightDesc_Color = GetCSSValue(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id, "color");
            Assert.AreEqual(font_color, FreightDesc_Color);

            string FD_ClearItem = GetCSSValue(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id, "font-size");
            Assert.AreEqual(font_size, FD_ClearItem);

            //string FD_SavedItem = GetCSSValue(attributeName_xpath, ClassorSavedItemField_xpath, "font-size");
            //Assert.AreEqual(font_size, FD_SavedItem);
            //string FD_SavedItem_Color = GetCSSValue(attributeName_xpath, ClassorSavedItemField_xpath, "color");
            //Assert.AreEqual(font_color, FD_SavedItem_Color);

            string FD_Quantity = GetCSSValue(attributeName_id, FreightDesp_FirstItem_Quantity_Id, "font-size");
            Assert.AreEqual(font_size, FD_Quantity);
            string FD_Quantity_Color = GetCSSValue(attributeName_id, FreightDesp_FirstItem_Quantity_Id, "color");
            Assert.AreEqual(font_color, FD_Quantity_Color);

            string FD_QuantityType = GetCSSValue(attributeName_id, FreightDesp_FirstItem_Quantity_Id, "font-size");
            Assert.AreEqual(font_size, FD_QuantityType);
            string FD_QuantityType_Color = GetCSSValue(attributeName_id, FreightDesp_FirstItem_Quantity_Id, "color");
            Assert.AreEqual(font_color, FD_QuantityType_Color);

            string FD_Weight = GetCSSValue(attributeName_id, FreightDesp_FirstItem_Weight_Id, "font-size");
            Assert.AreEqual(font_size, FD_Weight);
            string FD_Weight_Color = GetCSSValue(attributeName_id, FreightDesp_FirstItem_Weight_Id, "color");
            Assert.AreEqual(font_color, FD_Weight_Color);

            string FD_InsuredValue = GetCSSValue(attributeName_id, InsuredValue_TextBox_Id, "font-size");
            Assert.AreEqual(font_size, FD_InsuredValue);
            string FD_InsuredValue_Color = GetCSSValue(attributeName_id, InsuredValue_TextBox_Id, "color");
            Assert.AreEqual(font_color, FD_InsuredValue_Color);


            //string AddAdditionalItemButton = GetCSSValue(attributeName_xpath, LTL_AddAdditionalItemLink_Xpath, "font-size");
            //Assert.AreEqual(font_size, AddAdditionalItemButton);

            string PickUpdate = GetCSSValue(attributeName_xpath, PickUpDate_Xpath, "font-size");
            Assert.AreEqual(font_size, PickUpdate);
            string PickUpdate_Color = GetCSSValue(attributeName_xpath, PickUpDate_Xpath, "color");
            Assert.AreEqual(font_color, PickUpdate_Color);

            string PickupDate_Select = GetCSSValue(attributeName_id, LTL_PickUpDate_Id, "font-size");
            Assert.AreEqual(font_size, PickupDate_Select);
            string PickupDate_Select_Color = GetCSSValue(attributeName_id, LTL_PickUpDate_Id, "color");
            Assert.AreEqual(font_color, PickupDate_Select_Color);

            string ViewQuoteResults = GetCSSValue(attributeName_xpath, ViewRatesButton_xpath, "font-size");
            Assert.AreEqual(font_size, ViewQuoteResults);
        }  
    }
}
