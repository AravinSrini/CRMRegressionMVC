using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Quote.LTL.Shipment_Information_Screen.Get_Quote__LTL__Screen
{
    [Binding]
    public  class LTL_GetQuote_Font_EnhancementsSteps : AddShipments
    {
        CommonMethodsCrm crm = new CommonMethodsCrm();
        [Given(@"I am an Ship Entry, Ship EntryNoRates, Ship Inquiry, Operations, Sales, or Sales Management user (.*),(.*)")]
        public void GivenIAmAnShipEntryShipEntryNoRatesShipInquiryOperationsSalesOrSalesManagementUser(string Username, string Password)
        {
            crm.LoginToCRMApplication(Username, Password);
        }

        [When(@"I am on the Get Quote LTL Page (.*),(.*)")]
        public void WhenIAmOnTheGetQuoteLTLPage(string usertype, string Account)
        {
            Report.WriteLine("Click on the Quote Module");
            Click(attributeName_xpath, QuoteIcon_Xpath);

            if (usertype == "Internal")
            {
                Report.WriteLine("Select Customer Name from the dropdown list");

                Click(attributeName_xpath, QuoteCustomerSelectionDropdown_Xpath);

                IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(QuoteCustomerSelectioDropdownValues_Xpath));
                int DropDownCount = DropDownList.Count;
                for (int i = 0; i < DropDownCount; i++)
                {
                    if (DropDownList[i].Text == Account)
                    {
                        DropDownList[i].Click();
                        break;
                    }
                }

                Report.WriteLine("Click on the Submit Rate Request Button");
                Click(attributeName_id, SubmitRateRequestBtn_id);
                Report.WriteLine("Click on the LTL Tile");
                Click(attributeName_id, ShipmentServiceTypeLTL_id);
                Report.WriteLine("I am on the Get Quote LTL Page");
                VerifyElementPresent(attributeName_xpath, LTLpagetitle_xpath, "Get Quote (LTL)");

            }
            else
            {
                Report.WriteLine("Click on the Submit Rate Request Button");
                Click(attributeName_id, SubmitRateRequestBtn_id);

                Report.WriteLine("Click on the LTL Tile");
                Click(attributeName_id, ShipmentServiceTypeLTL_id);
                Report.WriteLine("I am on the Get Quote LTL Page");
                VerifyElementPresent(attributeName_xpath, LTLpagetitle_xpath, "Get Quote (LTL)");
            }
        }

        [Then(@"Verify (.*) will be increased to Twenty and (.*) will be darker for all fields")]
        public void ThenVerifyWillBeIncreasedToTwentyAndWillBeDarkerForAllFields(string font_size, string font_color)
        {
            Report.WriteLine("Verify the Shipping From Section ");
            VerifyElementPresent(attributeName_xpath, LTL_ShipinformationPage_ShippingFrom_Xpath, "Shipping From");
            Click(attributeName_id, ClearAddress_FromId);
            string ShippingFrom = GetCSSValue(attributeName_xpath, LTL_ShipinformationPage_ShippingFrom_Xpath, "font-size");
            Assert.AreEqual(font_size, ShippingFrom);
            string FontcolorShippingFrom = GetCSSValue(attributeName_xpath, LTL_ShipinformationPage_ShippingFrom_Xpath, "color");
            Assert.AreEqual(font_color, FontcolorShippingFrom);

            string From_ClearAddress = GetCSSValue(attributeName_id, ClearAddress_FromId, "font-size");
            Assert.AreEqual(font_size, From_ClearAddress);


            string From_SavedAdd = GetCSSValue(attributeName_id, LTL_SavedOriginAddressDropdown_Id, "font-size");
            Assert.AreEqual(font_size, From_SavedAdd);
            string From_SavedAdd_Color = GetCSSValue(attributeName_id, LTL_SavedOriginAddressDropdown_Id, "color");
            Assert.AreEqual(font_color, From_SavedAdd_Color);


            string From_OriginZip = GetCSSValue(attributeName_id, LTL_OriginZipPostal_Id, "font-size");
            Assert.AreEqual(font_size, From_OriginZip);
            string From_OriginZip_Color = GetCSSValue(attributeName_id, LTL_OriginZipPostal_Id, "color");
            Assert.AreEqual(font_color, From_OriginZip_Color);

            string From_OriginCountry = GetCSSValue(attributeName_xpath, LTL_OriginCountryDropdown_SelectedValue_Xpath, "font-size");
            Assert.AreEqual(font_size, From_OriginCountry);
            string From_OriginCountry_Color = GetCSSValue(attributeName_xpath, LTL_OriginCountryDropdown_SelectedValue_Xpath, "color");
            Assert.AreEqual(font_color, From_OriginCountry_Color);

            string From_OriginCity = GetCSSValue(attributeName_id, LTL_OriginCity_Id, "font-size");
            Assert.AreEqual(font_size, From_OriginCity);
            string From_OriginCity_Color = GetCSSValue(attributeName_id, LTL_OriginCity_Id, "color");
            Assert.AreEqual(font_color, From_OriginCity_Color);

            string From_OriginState = GetCSSValue(attributeName_xpath, ".//*[@id='select_origin_country_chosen']/a/span", "font-size");
            Assert.AreEqual(font_size, From_OriginState);
            string From_OriginState_Color = GetCSSValue(attributeName_xpath, ".//*[@id='select_origin_country_chosen']/a/span", "color");
            Assert.AreEqual(font_color, From_OriginState_Color);

            string From_ServiceAndAcc = GetCSSValue(attributeName_xpath, LTL_ServicesAndAccessorials_ShipFrom_Text_Xpath, "font-size");
            Assert.AreEqual(font_size, From_ServiceAndAcc);
            string From_ServiceAndAcc_Color = GetCSSValue(attributeName_xpath, LTL_ServicesAndAccessorials_ShipFrom_Text_Xpath, "color");
            Assert.AreEqual(font_color, From_ServiceAndAcc_Color);



            Report.WriteLine("Verify the Shipping To Section");
            VerifyElementPresent(attributeName_xpath, LTL_ShipinformationPage_ShippingTo_Xpath, "Shipping To");
            Click(attributeName_id, ClearAddress_ToId);
            string ShippingTO = GetCSSValue(attributeName_xpath, LTL_ShipinformationPage_ShippingTo_Xpath, "font-size");
            Assert.AreEqual(font_size, ShippingTO);
            string FontColorShippingTO = GetCSSValue(attributeName_xpath, LTL_ShipinformationPage_ShippingTo_Xpath, "color");
            Assert.AreEqual(font_color, FontColorShippingTO);

        

            string To_ClearAddress = GetCSSValue(attributeName_id, ClearAddress_ToId, "font-size");
            Assert.AreEqual(font_size, To_ClearAddress);


            string To_SavedAdd = GetCSSValue(attributeName_id, LTL_SavedDestinationAddressDropdown_Id, "font-size");
            Assert.AreEqual(font_size, To_SavedAdd);
            string To_SavedAdd_Color = GetCSSValue(attributeName_id, LTL_SavedDestinationAddressDropdown_Id, "color");
            Assert.AreEqual(font_color, To_SavedAdd_Color);

            string To_DestinationZip = GetCSSValue(attributeName_id, LTL_DestinationZipPostal_Id, "font-size");
            Assert.AreEqual(font_size, To_DestinationZip);
            string To_DestinationZip_Color = GetCSSValue(attributeName_id, LTL_DestinationZipPostal_Id, "color");
            Assert.AreEqual(font_color, To_DestinationZip_Color);


            string To_DestinationCountry = GetCSSValue(attributeName_xpath, countryforDestination_xpath, "font-size");
            Assert.AreEqual(font_size, To_DestinationCountry);
            string To_DestinationCountry_Color = GetCSSValue(attributeName_xpath, countryforDestination_xpath, "color");
            Assert.AreEqual(font_color, To_DestinationCountry_Color);


            string To_DestinationCity = GetCSSValue(attributeName_id, LTL_DestinationCity_Id, "font-size");
            Assert.AreEqual(font_size, To_DestinationCity);
            string To_DestinationCity_Color = GetCSSValue(attributeName_id, LTL_DestinationCity_Id, "color");
            Assert.AreEqual(font_color, To_DestinationCity_Color);

            string To_DestinationState = GetCSSValue(attributeName_xpath, stateforDestination_xpath, "font-size");
            Assert.AreEqual(font_size, To_DestinationState);
            string To_DestinationState_Color = GetCSSValue(attributeName_xpath, stateforDestination_xpath, "color");
            Assert.AreEqual(font_color, To_DestinationState_Color);

            string To_ServiceAndAcc = GetCSSValue(attributeName_xpath, LTL_ServicesAndAccessorials_ShipTo_Text_Xpath, "font-size");
            Assert.AreEqual(font_size, To_ServiceAndAcc);
            string To_ServiceAndAcc_Color = GetCSSValue(attributeName_xpath, LTL_ServicesAndAccessorials_ShipTo_Text_Xpath, "color");
            Assert.AreEqual(font_color, To_ServiceAndAcc_Color);
            

            Report.WriteLine("Verify the Freight Description Section");
            VerifyElementPresent(attributeName_xpath, LTL_FreightDescriptionHeader_Xpath, "Freight Description");
            Click(attributeName_id, LTL_ClearItem_Id);
            string FreightDesc_Color = GetCSSValue(attributeName_xpath, LTL_FreightDescriptionHeader_Xpath, "color");
            Assert.AreEqual(font_color, FreightDesc_Color);

            string FD_ClearItem = GetCSSValue(attributeName_id, LTL_ClearItem_Id, "font-size");
            Assert.AreEqual(font_size, FD_ClearItem);

            string FD_SavedItem = GetCSSValue(attributeName_xpath, ClassorSavedItemField_xpath, "font-size");
            Assert.AreEqual(font_size, FD_SavedItem);
            string FD_SavedItem_Color = GetCSSValue(attributeName_xpath, ClassorSavedItemField_xpath, "color");
            Assert.AreEqual(font_color, FD_SavedItem_Color);

            string FD_Quantity = GetCSSValue(attributeName_id, Quantity_id, "font-size");
            Assert.AreEqual(font_size, FD_Quantity);
            string FD_Quantity_Color = GetCSSValue(attributeName_id, Quantity_id, "color");
            Assert.AreEqual(font_color, FD_Quantity_Color);

            string FD_QuantityType = GetCSSValue(attributeName_xpath, QuantityType_xpath, "font-size");
            Assert.AreEqual(font_size, FD_QuantityType);
            string FD_QuantityType_Color = GetCSSValue(attributeName_xpath, QuantityType_xpath, "color");
            Assert.AreEqual(font_color, FD_QuantityType_Color);

            string FD_Weight = GetCSSValue(attributeName_id, LTL_Weight_Id, "font-size");
            Assert.AreEqual(font_size, FD_Weight);
            string FD_Weight_Color = GetCSSValue(attributeName_id, LTL_Weight_Id, "color");
            Assert.AreEqual(font_color, FD_Weight_Color);

            string FD_InsuredValue = GetCSSValue(attributeName_id, LTL_EnterInsuredValue_Id, "font-size");
            Assert.AreEqual(font_size, FD_InsuredValue);
            string FD_InsuredValue_Color = GetCSSValue(attributeName_id, LTL_EnterInsuredValue_Id, "color");
            Assert.AreEqual(font_color, FD_InsuredValue_Color);

            string FD_InsuredType = GetCSSValue(attributeName_xpath, InsuredValueNew_xpath, "font-size");
            Assert.AreEqual(font_size, FD_InsuredType);
            string FD_InsuredType_Color = GetCSSValue(attributeName_xpath, InsuredValueNew_xpath, "color");
            Assert.AreEqual(font_color, FD_InsuredType_Color);


            string AddAdditionalItemButton = GetCSSValue(attributeName_xpath, LTL_AddAdditionalItemLink_Xpath, "font-size");
            Assert.AreEqual(font_size, AddAdditionalItemButton);
           

            string PickUpdate = GetCSSValue(attributeName_xpath, PicupDate_Xpath, "font-size");
            Assert.AreEqual(font_size, PickUpdate);
            string PickUpdate_Color = GetCSSValue(attributeName_xpath, PicupDate_Xpath, "color");
            Assert.AreEqual(font_color, PickUpdate_Color);

            string PickupDate_Select = GetCSSValue(attributeName_id, Pickupdate_id, "font-size");
            Assert.AreEqual(font_size, PickupDate_Select);
            string PickupDate_Select_Color = GetCSSValue(attributeName_id, Pickupdate_id, "color");
            Assert.AreEqual(font_color, PickupDate_Select_Color);

            string ViewQuoteResults = GetCSSValue(attributeName_id, ViewQuoteResultsBtn_id, "font-size");
            Assert.AreEqual(font_size, ViewQuoteResults);
        }

      

    }
}
