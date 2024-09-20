using CRM.UITest.Objects;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.UAT_Regression.Domestic_Forwarding
{
    [Binding]
    public class Domestic_Forwarding_Submit_Rate_Request_Manually_enter_data_and_Verify_Uploaded_DocumentSteps : Mvc4Objects
    {
        public string Pieces;
        public string Weight;

        [Given(@"I enter data in origin on Shipment Locations and Dates page (.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void GivenIEnterDataInOriginOnShipmentLocationsAndDatesPage(string OriginLocationName, 
            string OriginAddress1, 
            string OriginCountry, 
            string OriginZip, 
            string OriginState, 
            string OriginCity, 
            string OriginContactName, 
            string OriginPhoneNo)
        {
            SendKeys(attributeName_id, DF_LocationName_Id, OriginLocationName);
            SendKeys(attributeName_id, DF_Address1_Id, OriginAddress1);
            SendKeys(attributeName_id, DF_ZipCode_Id, OriginZip);
            SendKeys(attributeName_id,DF_OriginContactName_Id, OriginContactName);
            SendKeys(attributeName_id,DF_OriginPhoneNum_Id, OriginPhoneNo);

        }

        [Given(@"I enter data in destination on Shipment Locations and Dates page (.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void GivenIEnterDataInDestinationOnShipmentLocationsAndDatesPage(string DestinationLocationName,
            string DestinationAddress1, 
            string DestinationCountry, 
            string DestinationZip, 
            string DestinationState, 
            string DestinationCity, 
            string DestinationContactName,
            string DestinationPhoneNo)
        {
            SendKeys(attributeName_id, DF_DesLocationName_Id, DestinationLocationName);
            SendKeys(attributeName_id, DF_DesAddress1_Id, DestinationAddress1);
            SendKeys(attributeName_id, DF_DesZipcode_Id, DestinationZip);
            SendKeys(attributeName_id, DF_DesContactName_Id, DestinationContactName);
            SendKeys(attributeName_id, DF_DesPhoneNum_Id, DestinationPhoneNo);
        }

        [Given(@"I enter data in frieght description on Shipment Locations and Dates page (.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void GivenIEnterDataInFrieghtDescriptionOnShipmentLocationsAndDatesPage(string SelectItem, 
            string Pieces, 
            string Weight, 
            string Lenght, 
            string Width, 
            string Height, 
            string Description)
        {
            Report.WriteLine("Selecting a saved item from the dropdown");
            scrollElementIntoView(attributeName_xpath, DF_SavedItem_Xpath);
            Click(attributeName_xpath, DF_SavedItem_Xpath);
            SendKeys(attributeName_xpath, DF_SavedItem_Search_Xpath, SelectItem);
            Click(attributeName_xpath, DF_SavedItenDropdown_FirstValue_Xpath);

            SendKeys(attributeName_id, DF_Pieces_Id, Pieces);
            SendKeys(attributeName_id, DF_Weight_Id, Weight);
            SendKeys(attributeName_id, DF_DimensionLength_Id, Lenght);
            SendKeys(attributeName_id, DF_DimensionWidth_Id, Width);
            SendKeys(attributeName_id, DF_DimensionHeight_Id, Height);
            SendKeys(attributeName_id, DF_Description_Id, Description);

        }

        [Given(@"I enter addtional pieces in frieght description on Shipment Locations and Dates page (.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void GivenIEnterAddtionalPiecesInFrieghtDescriptionOnShipmentLocationsAndDatesPage(string SelectItem1, 
            string Pieces1, 
            string Weight1, 
            string Lenght1, 
            string Width1, 
            string Height1, 
            string Description1)
        {
            Report.WriteLine("Selecting a saved item from the dropdown");            
            Click(attributeName_id, DF_Add_Additional_Piece_Id);
            Click(attributeName_xpath, DF_First_SavedItem_Xpath);
            SendKeys(attributeName_xpath, DF_First_SavedItem_Search_Xpath, SelectItem1);
            Click(attributeName_xpath, DF_First_SavedItemDropdown_FirstValue_Xpath);

            SendKeys(attributeName_id, DF_First_Pieces_Id, Pieces1);
            SendKeys(attributeName_id, DF_First_Weight_Id, Weight1);
            SendKeys(attributeName_id, DF_First_DimensionLength_Id, Lenght1);
            SendKeys(attributeName_id, DF_First_DimensionWidth_Id, Width1);
            SendKeys(attributeName_id, DF_First_DimensionHeight_Id, Height1);
            SendKeys(attributeName_id, DF_First_Description_Id, Description1);

        }

        [Given(@"I enter the Reference numbers on Shipment Locations and Dates page (.*),(.*),(.*)")]
        public void GivenIEnterTheReferenceNumbersOnShipmentLocationsAndDatesPage(string RefType, string RefNumber, string CustType)
        {
            scrollElementIntoView(attributeName_xpath, DF_Reference_Number_Yes_RadioButton_xpath);
            Click(attributeName_xpath, DF_Reference_Number_Yes_RadioButton_xpath);
            Click(attributeName_xpath, DF_ReferenceType_DropDown_xpath);            
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(DF_ReferenceType_DropDownValues_xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == RefType)
                {
                    DropDownList[i].Click();
                    break;
                }
            }
            Thread.Sleep(500);
            SendKeys(attributeName_id, DF_Reference_Number_Id, RefNumber);

            Click(attributeName_xpath, DF_CustomerType_DropDown_xpath);
            IList<IWebElement> DropDownList1 = GlobalVariables.webDriver.FindElements(By.XPath(DF_CustomerType_DropDown_values_xpath));
            int DropDownCount1 = DropDownList1.Count;
            for (int i = 0; i < DropDownCount1; i++)
            {
                if (DropDownList1[i].Text == CustType)
                {
                    DropDownList1[i].Click();
                    break;
                }
            }

        }

        [Given(@"I enter the additional Services and accessorial on Shipment Locations and Dates page (.*),(.*) and (.*)")]
        public void GivenIEnterTheAdditionalServicesAndAccessorialOnShipmentLocationsAndDatesPageAnd(string ServicesType, string ShipmentValue, string DefaultSpecialInstruction)
        {
            scrollElementIntoView(attributeName_xpath, DF_ServicesAccessorials_Yes_RadioButton_xpath);
            Click(attributeName_xpath, DF_ServicesAccessorials_Yes_RadioButton_xpath);
            Click(attributeName_xpath, DF_ServicesAccessorials_SearchBox_xpath);
            SendKeys(attributeName_xpath, DF_ServicesAccessorials_SearchBox_xpath, ServicesType);            
            Click(attributeName_xpath, DF_ServicesAccessorials_FirstValue_xpath);
            Thread.Sleep(500);

            SendKeys(attributeName_xpath, DF_ShipmentValue_xpath, ShipmentValue);
            SendKeys(attributeName_id, DF_DefaultSpecialInstructions_Id, DefaultSpecialInstruction);
            

        }

        [When(@"I click on the Save and Continue Button")]
        public void WhenIClickOnTheSaveAndContinueButton()
        {
            Click(attributeName_id, DF_SaveAndContinue_Button_Id);
        }

        [Then(@"I click on the Submit button")]
        public void ThenIClickOnTheSubmitButton()
        {
            scrollElementIntoView(attributeName_id, DF_Submit_Button_Id);
            Click(attributeName_id, DF_Submit_Button_Id);
        }

        [Then(@"I verify the data on Confirmation page")]
        public void ThenIVerifyTheDataOnConfirmationPage()
        {
            VerifyElementPresent(attributeName_xpath, DF_ConfirmationPageTitle_xpath, "Confirmation Page");
            Verifytext(attributeName_xpath, DF_ServiceName_xpath, "Domestic Forwarding");
        }



    }
}
