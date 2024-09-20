using CRM.UITest.Objects;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CRM.UITest.CommonMethods.Mvc4Regressions
{
    public class InternationalShipment : Mvc4Objects
    {
        public void Select_InternationalService_Type_level(string Type, string level)
        {
            
            Report.WriteLine("Navigate to MVC5 Shipment list");
            try
            {
                Click(attributeName_xpath, ShipmentModule_Xpath);

            }
            catch (Exception)
            {
                Thread.Sleep(20000);
                Console.WriteLine("error occurred");
            }
            WaitForElementVisible(attributeName_xpath, ShipmentList_Header_Text_Xpath, "Shipment List");
            Click(attributeName_id, AddShipment_button_Id);

            Click(attributeName_id, Int_Shipment_Tile_Id);
            WaitForElementVisible(attributeName_xpath, Int_ServiceType_Modal_Verbiage, "International Type Verbiage");
            Click(attributeName_xpath, Int_Shipment_Type_dropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, Int_Shipment_Type_dropdown_Value_Xpath, Type);
            //Thread.Sleep(2500);
            WaitForElementVisible(attributeName_xpath, Int_Shipment_level_dropdown_Xpath, "International service level dropdown");
            Click(attributeName_xpath, Int_Shipment_level_dropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, Int_Shipment_level_dropdown_value_Xpath, level);
            Click(attributeName_id, Int_Shipment_Continue_button_Id);
        }

        public void Entering_Datas_in_International_ShipmentLocationAndDates_Page(string OName, string OAddress, string OCountry, string OCity, string OState, string OZip, string DName, string DAddress, string DCountry, string DCity, string DState, string DZip)
        {
            WaitForElementVisible(attributeName_xpath, Int_Shipment_LocationAndDates_Text_Xpath, "Shipment Locations and Dates Header");
            Click(attributeName_id, Int_Shipment_OringinClearAddress_button_Id);
            Thread.Sleep(4000);
            SendKeys(attributeName_id, Int_Shipment_OriginName_Textbox_Id, OName);
            SendKeys(attributeName_id, Int_Shipment_OriginAddress_Textbox_Id, OAddress);
            scrollElementIntoView(attributeName_xpath, Int_Shipment_OriginCountry_dropdown_Xpath);
            Click(attributeName_xpath, Int_Shipment_OriginCountry_dropdown_Xpath);

            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(Int_Shipment_OriginCountry_dropdown_value_Xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == OCountry)
                {
                    DropDownList[i].Click();
                    break;
                }
            }

            //SelectDropdownValueFromList(attributeName_xpath, Int_Shipment_OriginCountry_dropdown_value_Xpath, OCountry);
            Thread.Sleep(1000);
            Click(attributeName_xpath, Int_Shipment_OriginState_dropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, Int_Shipment_OriginState_dropdown_value_Xpath, OState);
            Thread.Sleep(1000);
            SendKeys(attributeName_id, Int_Shipment_OriginCity_Textbox_Id, OCity);
            SendKeys(attributeName_id, Int_Shipment_OriginZip_Textbox_Id, OZip);
            Click(attributeName_id, Int_Shipment_OriginCity_Textbox_Id);
            Thread.Sleep(1000);

            scrollElementIntoView(attributeName_id, Int_Shipment_DestinationClearAddress_button_Id);
            Click(attributeName_id, Int_Shipment_DestinationClearAddress_button_Id);
            Thread.Sleep(4000);
            SendKeys(attributeName_id, Int_Shipment_DestinationName_Textbox_Id, DName);
            SendKeys(attributeName_id, Int_Shipment_DestinationAddress_Textbox_Id, DAddress);
            Click(attributeName_xpath, Int_Shipment_DestinationCountry_dropdown_Xpath);
            IList<IWebElement> DDropDownList = GlobalVariables.webDriver.FindElements(By.XPath(Int_Shipment_OriginCountry_dropdown_value_Xpath));
            int DDropDownCount = DDropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == DCountry)
                {
                    DropDownList[i].Click();
                    break;
                }
            }
            //scrollElementIntoView(attributeName_xpath, Int_Shipment_DestinationCountry_dropdown_value_Xpath);
            //SelectDropdownValueFromList(attributeName_xpath, Int_Shipment_DestinationCountry_dropdown_value_Xpath, DCountry);
            Thread.Sleep(1000);
            Click(attributeName_xpath, Int_Shipment_DestinationState_dropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, Int_Shipment_DestinationState_dropdown_value_Xpath, DState);
            Thread.Sleep(1000);
            SendKeys(attributeName_id, Int_Shipment_DestinationCity_Textbox_Id, DCity);
            SendKeys(attributeName_id, Int_Shipment_DestinationZip_Textbox_Id, DZip);
            Click(attributeName_id, Int_Shipment_DestinationCity_Textbox_Id);
            Thread.Sleep(1000);

            scrollElementIntoView(attributeName_xpath, Int_Shipment_PickUp_ReadyTime_dropdown_Xpath);
            Click(attributeName_xpath, Int_Shipment_PickUp_ReadyTime_dropdown_Xpath);
            Click(attributeName_xpath, Int_Shipment_PickUp_ReadyTime_dropdown_value_Xpath);
            Thread.Sleep(2000);
            Click(attributeName_xpath, Int_Shipment_PickUp_CloseTime_dropdown_Xpath);
            Click(attributeName_xpath, Int_Shipment_PickUp_CloseTime_dropdown_value_Xpath);
            Thread.Sleep(2000);

            Click(attributeName_xpath, Int_Shipment_Delivery_ReadyTime_dropdown_Xpath);
            Click(attributeName_xpath, Int_Shipment_Delivery_ReadyTime_dropdown_value_Xpath);
            Thread.Sleep(2000);
            Click(attributeName_xpath, Int_Shipment_Delivery_CloseTime_dropdown_Xpath);
            Click(attributeName_xpath, Int_Shipment_Delivery_CloseTime_dropdown_value_Xpath);
            Thread.Sleep(2000);
            Click(attributeName_id, Int_Shipment_LocationAndDates_Page_SaveAndContinue_button_Id);

        }

        public void Entering_Datas_in_Iternational_ItemInformation_Page(string Pieces, string Weight, string Length, string Width, string Height, string Description, string CommercialInvoiceValue)
        {
            WaitForElementVisible(attributeName_xpath, Int_Shipment_ItemInformation_Textbox_Xpath, "Item Information");
            SendKeys(attributeName_id, Int_Shipment_Pieces_Textbox_Id, Pieces);
            SendKeys(attributeName_id, Int_Shipment_Weight_Textbox_Id, Weight);
            SendKeys(attributeName_id, Int_Shipment_Length_Textbox_Id, Length);
            SendKeys(attributeName_id, Int_Shipment_Width_Textbox_Id, Width);
            SendKeys(attributeName_id, Int_Shipment_Height_Textbox_Id, Height);

            scrollElementIntoView(attributeName_xpath, Int_Shipment_Description_Textbox_Xpath);
            SendKeys(attributeName_xpath, Int_Shipment_Description_Textbox_Xpath, Description);

            Click(attributeName_xpath, Int_Shipment_IncoTerms_dropdown_Xpath);
            Click(attributeName_xpath, Int_Shipment_First_IncoTerms_dropdown_Value);
            SendKeys(attributeName_id, Int_shipment_CommercialValue_Textbox_Id, CommercialInvoiceValue);
            scrollElementIntoView(attributeName_id, Int_Shipment_ItemInformation_Page_SaveAndContinue_button_Id);
            Click(attributeName_id, Int_Shipment_ItemInformation_Page_SaveAndContinue_button_Id);

            WaitForElementVisible(attributeName_xpath, Int_Shipment_ReviewAndSubmitPage_Text_Xpath, "Review and Submit Page");
            scrollElementIntoView(attributeName_id, Int_Shipment_Submit_button_Id);
            Click(attributeName_id, Int_Shipment_Submit_button_Id);
        }
    }
}
