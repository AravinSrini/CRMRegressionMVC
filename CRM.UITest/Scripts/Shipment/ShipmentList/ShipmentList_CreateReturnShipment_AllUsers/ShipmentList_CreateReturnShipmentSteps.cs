using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.ShipmentList.ShipmentList_CreateReturnShipment_AllUsers
{
    [Binding]
    public class ShipmentList_CreateReturnShipmentSteps : Shipmentlist
    {
        [When(@"I click on the return shipment icon (.*)")]
        public void WhenIClickOnTheReturnShipmentIcon(string UserType)
        {
            //string rowvalue = Gettext(attributeName_xpath, ".//*[@id='ShipmentGrid']/tbody/tr/td");
            int Shipmentrowcount = GetCount(attributeName_xpath, ShipmentList_TotalRecords_Xpath);
            if (Shipmentrowcount >= 1)
            {
                SendKeys(attributeName_id, ShipmentListSearchBox_Id, "LTL");
                if (UserType == "ShipEntry" || UserType == "ShipInquiry")
                {
                    Click(attributeName_xpath, ShipmentListGrid_External_ReturnIcon_Xpath);
                    Thread.Sleep(2000);
                }
                else if (UserType == ("Operation") || (UserType == "Sales") || UserType == ("SalesManagement") || (UserType == "StationOwner"))
                {
                    Click(attributeName_xpath, ShipmentListGrid_ReturnIcon_Xpath);
                    Thread.Sleep(2000);
                }


            }
            else
            {
                Report.WriteLine("No Records found for the LTL service for the logged in user so unable to test the scenario");
            }
        }


        [Then(@"Pop up asking for the Confirmation to create return shipment is displayed with (.*) header")]
        public void ThenPopUpAskingForTheConfirmationToCreateReturnShipmentIsDisplayedWithHeader(string CreateReturnShipmentTitle)
        {
            int Shipmentrowcount = GetCount(attributeName_xpath, ShipmentList_TotalRecords_Xpath);
            if (Shipmentrowcount >= 1)
            {
                Verifytext(attributeName_xpath, ShipmentList_ReturnShipmentHeaderText_xpath, CreateReturnShipmentTitle);

            }
            else
            {
                Report.WriteLine("No Records found for the LTL service for the logged in user so unable to test the scenario");
            }
            
        }

        [Then(@"I must see the confirmation text (.*) in the pop up")]
        public void ThenIMustSeeTheConfirmationTextInThePopUp(string ConfirmationText)
        {
            int Shipmentrowcount = GetCount(attributeName_xpath, ShipmentList_TotalRecords_Xpath);
            if (Shipmentrowcount >= 1)
            {
                Verifytext(attributeName_xpath, ShipemntList_ReturnShipment_ConfirmationText_xpath, ConfirmationText);

            }
            else
            {
                Report.WriteLine("No Records found for the LTL service for the logged in user so unable to test the scenario");
            }
            
        }

        [Then(@"I must see the Yes and No buttons in the Pop up")]
        public void ThenIMustSeeTheYesAndNoButtonsInThePopUp()
        {
            int Shipmentrowcount = GetCount(attributeName_xpath, ShipmentList_TotalRecords_Xpath);
            if (Shipmentrowcount >= 1)
            {
                VerifyElementPresent(attributeName_xpath, ShipmentList_ReturnShipment_Yes_Xpath, "Yes");
                VerifyElementPresent(attributeName_xpath, ShipmentList_ReturnShipment_No_Xpath, "No");

            }
            else
            {
                Report.WriteLine("No Records found for the LTL service for the logged in user so unable to test the scenario");
            }
            
        }


        [When(@"I click on the No button in Create Return Shipment pop up")]
        public void WhenIClickOnTheNoButtonInCreateReturnShipmentPopUp()
        {
            int Shipmentrowcount = GetCount(attributeName_xpath, ShipmentList_TotalRecords_Xpath);
            if (Shipmentrowcount >= 1)
            {
                Click(attributeName_xpath, ShipmentList_ReturnShipment_No_Xpath);
                Thread.Sleep(2000);

            }
            else
            {
                Report.WriteLine("No Records found for the LTL service for the logged in user so unable to test the scenario");
            }
           
        }

        [Then(@"Create Return Shipment Pop Up should be closed and user should be returned back to the Shipment list page")]
        public void ThenCreateReturnShipmentPopUpShouldBeClosedAndUserShouldBeReturnedBackToTheShipmentListPage()
        {
            int Shipmentrowcount = GetCount(attributeName_xpath, ShipmentList_TotalRecords_Xpath);

            if (Shipmentrowcount >= 1)
            {
                VerifyElementNotVisible(attributeName_xpath, ShipmentList_ReturnShipmentHeaderText_xpath, "Create Return Shipment");
                VerifyElementVisible(attributeName_xpath, ShipmentList_Title_Xpath, "Shipment List");

            }
            else
            {
                Report.WriteLine("No Records found for the LTL service for the logged in user so unable to test the scenario");
            }
            
        }

        [When(@"I click on the Yes button in Create Return Shipment pop up")]
        public void WhenIClickOnTheYesButtonInCreateReturnShipmentPopUp()
        {
            int Shipmentrowcount = GetCount(attributeName_xpath, ShipmentList_TotalRecords_Xpath);
            if (Shipmentrowcount >= 1)
            {
                Click(attributeName_xpath, ShipmentList_ReturnShipment_Yes_Xpath);
                Thread.Sleep(2000);

            }
            else
            {
                Report.WriteLine("No Records found for the LTL service for the logged in user so unable to test the scenario");
            }

            
        }

        [Then(@"I must be on the Shipment List Locations and Dates page")]
        public void ThenIMustBeOnTheShipmentListLocationsAndDatesPage()
        {
            

        //[Then(@"I must be to navigated to the Add Shipment Locations and Dates page (.*)")]
        //public void ThenIMustBeToNavigatedToTheAddShipmentLocationsAndDatesPage(string LocationsAndDatesPageTitle)
        //{
            int Shipmentrowcount = GetCount(attributeName_xpath, ShipmentList_TotalRecords_Xpath);
            if (Shipmentrowcount >= 1)
            {
                Verifytext(attributeName_xpath, ShipmentLocationsandDates_xpath, "Shipment Locations and Dates");

            }
            else
            {
                Report.WriteLine("No Records found for the LTL service for the logged in user so unable to test the scenario");
            }
            
        }








    }
}
