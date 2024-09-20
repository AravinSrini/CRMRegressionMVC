using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using CRM.UITest.Objects;
using TechTalk.SpecFlow;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Information_Screen
{
    [Binding]
    public class AddShipmentLTL_ViewOriginOrDestinationLocation_AllUsersSteps : AddShipments
    {
        [Given(@"I have entered all the required information in the Shipping from section - (.*), (.*) and (.*)")]
        public void GivenIHaveEnteredAllTheRequiredInformationInTheShippingFromSection_And(string LocationName, string LocationAddress, string Zipcode)
        {
            Report.WriteLine("Shipment From section");
            SendKeys(attributeName_id, ShippingFrom_LocationName_Id, LocationName);
            SendKeys(attributeName_id, ShippingFrom_LocationAddressLine1_Id, LocationAddress);
            SendKeys(attributeName_id, ShippingFrom_zipcode_Id, Zipcode);
        }

        [Given(@"I have entered all the required information in the Shipping To section - (.*), (.*) and (.*)")]
        public void GivenIHaveEnteredAllTheRequiredInformationInTheShippingToSection_And(string LocationName, string LocationAddress, string Zipcode)
        {
            Report.WriteLine("Shipment To section");
            SendKeys(attributeName_id, ShippingTo_LocationName_Id, LocationName);
            SendKeys(attributeName_id, ShippingTo_LocationAddressLine1_Id, LocationAddress);
            SendKeys(attributeName_id, ShippingTo_zipcode_Id, Zipcode);
            Thread.Sleep(3000);
        }

        [When(@"I Click on View Origin Location on Map button")]
        public void WhenIClickOnViewOriginLocationOnMapButton()
        {
            Report.WriteLine("Click on View Origin Location map button");
            Click(attributeName_id, ShippingFrom_ViewOriginLocationMap_Id);
            Thread.Sleep(5000);
        }

        [When(@"I click on View Origin Location on Map button without entering all required fields on Shipping From section")]
        public void WhenIClickOnViewOriginLocationOnMapButtonWithoutEnteringAllRequiredFieldsOnShippingFromSection()
        {
            Report.WriteLine("Click map button without entering values");
            Click(attributeName_id, ShippingFrom_ViewOriginLocationMap_Id);
            Thread.Sleep(5000);
        }

        [When(@"I Click on View Destination Location on Map button")]
        public void WhenIClickOnViewDestinationLocationOnMapButton()
        {
            Report.WriteLine("Click on View Destination button");
            Click(attributeName_id, ShippingTo_ViewDestLocationMap_Id);
            Thread.Sleep(3000);
        }

        [When(@"I click on View Destination Location on Map button without entering all required fields on Shipping To section")]
        public void WhenIClickOnViewDestinationLocationOnMapButtonWithoutEnteringAllRequiredFieldsOnShippingToSection()
        {
            Report.WriteLine("Click on view destination button");
            Click(attributeName_id, ShippingTo_ViewDestLocationMap_Id);
            Thread.Sleep(3000);
        }

        [Then(@"I must be able to view a map based on Shipping from Informaion - (.*)")]
        public void ThenIMustBeAbleToViewAMapBasedOnShippingFromInformaion_(string ShippingFromURL)
        {
            Report.WriteLine("Map view");

            Thread.Sleep(10000);
            WindowHandling("https://www.google.com/maps/place/XCC+Logistics+SA/@25.796214,-80.3803407,17z/data=!3m1!4b1!4m5!3m4!1s0x88d9beb9c966aac7:0xeb828c6d7d27b61d!8m2!3d25.796214!4d-80.378152");
            string UIUrl = GetURL();
            
            
            if (UIUrl.Contains(ShippingFromURL))
            {
                Report.WriteLine("Map is displayed");
            }
            else
            {
                Report.WriteFailure("Map is not Dispalyed");
            }
        }

        [Then(@"I must be able to view Origin name and address on the window - (.*)")]
        public void ThenIMustBeAbleToViewOriginNameAndAddressOnTheWindow_(string OriginName_Address)
        {
            Report.WriteLine("View of Origin Name and address on window");
            string UIUrl = GetURL();
            if (UIUrl.Contains(OriginName_Address))
            {
                Report.WriteLine("Origin name and address is displayed");
            }
            else
            {
                Report.WriteFailure("Origin name and address is not displayed");

            }
        }
        [Given(@"I click on clear address")]
        public void GivenIClickOnClearAddress()
        {
            Report.WriteLine("Click on clear address");
            Click(attributeName_id, ShippingFrom_ClearAddress_Id);
            Thread.Sleep(5000);
        }



        [Then(@"I should be able to view a popup reminder to enter all required destination information")]
        public void ThenIShouldBeAbleToViewAPopupReminderToEnterAllRequiredDestinationInformation()
        {
            Report.WriteLine("PopUp Remainder");
            string UIPopUp = Gettext(attributeName_xpath, ShippingTo_MapValidation_Message_Xpath);
            Assert.AreEqual(UIPopUp, "Please enter all required destination address");
        }

        [Then(@"I should be able to view a popup reminder to enter all required information for destination section")]
        public void ThenIShouldBeAbleToViewAPopupReminderToEnterAllRequiredInformationForDestinationSection()
        {
            Report.WriteLine("PopUp Remainder");
            string UIPopUp = Gettext(attributeName_xpath, ShippingTo_MapValidation_Message_Xpath);
            Assert.AreEqual(UIPopUp, "Please enter all required destination address");

        }

        [Then(@"I should be able to view a popup reminder to enter all required information")]
        public void ThenIShouldBeAbleToViewAPopupReminderToEnterAllRequiredInformation()
        {
            Report.WriteLine("PopUp Remainder");
            string UIPopUp = Gettext(attributeName_xpath, ShippingFrom_MapValidation_Message_Xpath);
            Assert.AreEqual(UIPopUp, "Please enter all required origin address");
        }

        [Then(@"I should be able to view a Close button on the popup reminder")]
        public void ThenIShouldBeAbleToViewACloseButtonOnThePopupReminder()
        {
            Report.WriteLine("Close button for PopuP remainder");
            VerifyElementPresent(attributeName_xpath, ShippingFrom_MapClose_Button_Xpath, "Close");
        }
        [Then(@"I should be able to view a Close button on destination map popup reminder")]
        public void ThenIShouldBeAbleToViewACloseButtonOnDestinationMapPopupReminder()
        {
            Report.WriteLine("Close button for PopuP remainder");
            VerifyElementPresent(attributeName_xpath, ShippingTo_MapClose_Button_Xpath, "Close");
        }


        [Then(@"I must be able to click on it and the modal should get closed")]
        public void ThenIMustBeAbleToClickOnItAndTheModalShouldGetClosed()
        {
            Report.WriteLine("Click on Close Button");
            Click(attributeName_xpath, ShippingFrom_MapClose_Button_Xpath);
            Thread.Sleep(5000);
            VerifyElementPresent(attributeName_xpath, AddShipment_PageTitle_xpath, "Add Shipment(LTL)");
        }

        [Given(@"I click on clear address for destination section")]
        public void GivenIClickOnClearAddressForDestinationSection()
        {
            Report.WriteLine("Click on clear address for destination section");
            Click(attributeName_id, ShippingTo_ClearAddress_Id);
            Thread.Sleep(3000);
        }

        [Then(@"I must be able to click on Close button on destination map popup reminder and the modal should get closed")]
        public void ThenIMustBeAbleToClickOnCloseButtonOnDestinationMapPopupReminderAndTheModalShouldGetClosed()
        {
            Report.WriteLine("Click on Close Button");
            Click(attributeName_xpath, ShippingTo_MapClose_Button_Xpath);
            Thread.Sleep(5000);
            VerifyElementPresent(attributeName_xpath, AddShipment_PageTitle_xpath, "Add Shipment(LTL)");

        }

        [Then(@"I must be able to view a map based on Shipping To Informaion - (.*)")]
        public void ThenIMustBeAbleToViewAMapBasedOnShippingToInformaion_(string ShippingToURL)
        {
            Report.WriteLine("Map View");
            Thread.Sleep(10000);
            WindowHandling("https://www.google.com/maps/place/XCC+Logistics+SA/@25.796214,-80.3803407,17z/data=!3m1!4b1!4m5!3m4!1s0x88d9beb9c966aac7:0xeb828c6d7d27b61d!8m2!3d25.796214!4d-80.378152");
            string UIUrl = GetURL();
            if (UIUrl.Contains(ShippingToURL))
            {
                Report.WriteLine("Map is displayed");
            }
            else
            {
                Report.WriteFailure("Map is not Dispalyed");
            }
        }
        [Then(@"I must be able to view Destination name and address on the window - (.*)")]
        public void ThenIMustBeAbleToViewDestinationNameAndAddressOnTheWindow_(string DestinationOriginName_Address)
        {
            Report.WriteLine("View of Destination Name and address on window");
            string UIUrl = GetURL();
            if (UIUrl.Contains(DestinationOriginName_Address))
            {
                Report.WriteLine("Destination name and address is displayed");
            }
            else
            {
                Report.WriteFailure("Destination name and address is not displayed");

            }
        }

    }
}
