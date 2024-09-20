using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Configuration;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment__LTL__2019
{
    [Binding]
    public class AddShipmentLTL2019_ShippingFromTo_ViewOrigin_DestinationOnMapSteps : AddShipments
    {
        string ShippingFromURL = "https://www.google.com/maps";
        [Given(@"I have entered all required information in the Shipping From section  - (.*), (.*) and (.*)")]
        public void GivenIHaveEnteredAllRequiredInformationInTheShippingFromSection_And(string LocationName, string LocationAddress, string Zipcode)
        {
            IsElementPresent(attributeName_xpath, ShippingFrom_ClearAddress_Xpath, "Clear address link"); //Verifying clear address link presence
            Click(attributeName_xpath, ShippingFrom_ClearAddress_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Shipment From section");
            SendKeys(attributeName_id, ShippingFrom_LocationName_NewScreen_Id, LocationName);
            SendKeys(attributeName_id, ShippingFrom_LocationAddressLine1_NewScreen_Id, LocationAddress);
            SendKeys(attributeName_id, ShippingFrom_zipcode_NewScreen_Id, Zipcode);
            GlobalVariables.webDriver.WaitForPageLoad();

        }

        [Given(@"I am a shp\.entry, shp\.entrynorates User")]
        public void GivenIAmAShp_EntryShp_EntrynoratesUser()
        {
            string userName = ConfigurationManager.AppSettings["username-NewScreenShipEntryUser"].ToString();
            string password = ConfigurationManager.AppSettings["password-NewScreenShipEntryUser"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(userName, password);
        }

        [Given(@"I am on the Add Shipment \(LTL\) page for an external user")]
        public void GivenIAmOnTheAddShipmentLTLPageForAnExternalUser()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ShipmentIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, AddShipment_Button_id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, AddShipmentLTL_Button_Id);
        }

        [Given(@"I have Not entered all required information in the Shipping from section,")]
        public void GivenIHaveNotEnteredAllRequiredInformationInTheShippingFromSection()
        {
            IsElementPresent(attributeName_xpath, ShippingFrom_ClearAddress_Xpath, "Clear address link"); //Verifying clear address link presence
            Click(attributeName_xpath, ShippingFrom_ClearAddress_Xpath);
            Thread.Sleep(5000);
        }
        
        [Given(@"I click On the view Origin on Map button")]
        public void GivenIClickOnTheViewOriginOnMapButton()
        {
            Report.WriteLine("Click on View Origin Location map button");
            Click(attributeName_xpath, ShippingFrom_ViewOriginLocationMap_newScreen_Xpath);
            Thread.Sleep(5000);
        }

        [Given(@"I received the pop up reminder to enter all required information from the Shipping To section")]
        public void GivenIReceivedThePopUpReminderToEnterAllRequiredInformationFromTheShippingToSection()
        {
            Report.WriteLine("PopUp Remainder To section");
            string UIPopUp = Gettext(attributeName_xpath, ShippingTo_MapValidation_Message_NewScreen_Xpath);
            Assert.AreEqual(UIPopUp, "Please enter all required destination address fields");
        }


        [Given(@"I received the pop up reminder to enter all required information,")]
        public void GivenIReceivedThePopUpReminderToEnterAllRequiredInformation()
        {
            Report.WriteLine("PopUp Remainder from section");
            string UIPopUp = Gettext(attributeName_xpath, ShippingFrom_MapValidation_Message_NewScreen_Xpath);
            Assert.AreEqual(UIPopUp, "Please enter all required origin address fields");
        }
        
        [Given(@"I have entered all required information in the Shipping To section,  - (.*), (.*) and (.*)")]
        public void GivenIHaveEnteredAllRequiredInformationInTheShippingToSection_And(string LocationName, string LocationAddress, string Zipcode)
        {
            IsElementPresent(attributeName_xpath, ShippingTo_ClearAddress_Xpath, "Clear address link"); //Verifying clear address link presence
            Click(attributeName_xpath, ShippingTo_ClearAddress_Xpath);
            Report.WriteLine("Shipment From section");
            SendKeys(attributeName_id, ShippingTo_LocationName_NewScreen_Id, LocationName);
            SendKeys(attributeName_id, ShippingTo_LocationAddressLine1_NewScreen_Id, LocationAddress);
            SendKeys(attributeName_id, ShippingTo_zipcode_NewScreen_Id, Zipcode);
        }
        
        [Given(@"I have Not entered all required information in the Shipping To section,")]
        public void GivenIHaveNotEnteredAllRequiredInformationInTheShippingToSection()
        {
            IsElementPresent(attributeName_xpath, ShippingTo_ClearAddress_Xpath, "Clear address link"); //Verifying clear address link presence
            Click(attributeName_xpath, ShippingTo_ClearAddress_Xpath);
            Thread.Sleep(5000);
        }
        
        [Given(@"I click On the view Origin on Map button in the Shipping To section")]
        public void GivenIClickOnTheViewOriginOnMapButtonInTheShippingToSection()
        {
            Report.WriteLine("Click on View destination Location map button");
            Click(attributeName_xpath, ShippingTo_ViewOriginLocationMap_newScreen_Xpath);
            Thread.Sleep(5000);
        }
        
        [When(@"I click On the view Origin on Map button")]
        public void WhenIClickOnTheViewOriginOnMapButton()
        {
            Report.WriteLine("Click on View Origin Location map button");
            Click(attributeName_xpath, ShippingFrom_ViewOriginLocationMap_newScreen_Xpath);
            Thread.Sleep(5000);
        }
        
        [When(@"I click on the Close button of the pop up reminder modal,")]
        public void WhenIClickOnTheCloseButtonOfThePopUpReminderModal()
        {
            Report.WriteLine("Click on Close Button");
            Click(attributeName_xpath, ShippingFrom_MapClose_Button_NewScreen_Xpath);
        }
        
        [When(@"I click On the view Origin on Map button in the Shipping To section")]
        public void WhenIClickOnTheViewOriginOnMapButtonInTheShippingToSection()
        {
            Report.WriteLine("Click on View destination Location map button");
            Click(attributeName_xpath, ShippingTo_ViewOriginLocationMap_newScreen_Xpath);
            Thread.Sleep(5000);
        }
        
        [Then(@"I will arrive on the Map as the default,")]
        public void ThenIWillArriveOnTheMapAsTheDefault()
        {
            Report.WriteLine("Map view");

            Thread.Sleep(10000);
            WindowHandling("https://www.google.com/maps/place/Los+Angeles,+CA+90024,+USA/@34.0631451,-118.4389438,17z/data=!3m1!4b1!4m5!3m4!1s0x80c2bc7c23ae2a19:0x36a47f944a7f67e8!8m2!3d34.0631451!4d-118.4367551");
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
        
        [Then(@"I have the option of viewing a satellite image of the location,")]
        public void ThenIHaveTheOptionOfViewingASatelliteImageOfTheLocation()
        {
            Report.WriteLine("Verifying satellite image");
            VerifyElementVisible(attributeName_xpath, SatelliteImage_Xpath, "SatelliteImage");
        }
        
        [Then(@"the origin name and address will be noted on the window - (.*)")]
        public void ThenTheOriginNameAndAddressWillBeNotedOnTheWindow_(string OriginName_Address)
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

        [Then(@"I will receive a pop up notification requesting that I enter all required information from To section")]
        public void ThenIWillReceiveAPopUpNotificationRequestingThatIEnterAllRequiredInformationFromToSection()
        {
            Report.WriteLine("PopUp Remainder To section");
            string UIPopUp = Gettext(attributeName_xpath, ShippingTo_MapValidation_Message_NewScreen_Xpath);
            Assert.AreEqual(UIPopUp, "Please enter all required destination address fields");
        }


        [Then(@"I will receive a pop up notification requesting that I enter all required information,")]
        public void ThenIWillReceiveAPopUpNotificationRequestingThatIEnterAllRequiredInformation()
        {
            Report.WriteLine("PopUp Remainder from section");
            string UIPopUp = Gettext(attributeName_xpath, ShippingFrom_MapValidation_Message_NewScreen_Xpath);
            Assert.AreEqual(UIPopUp, "Please enter all required origin address fields");
        }
        
        [Then(@"the pop up notification modal will have a close button\.")]
        public void ThenThePopUpNotificationModalWillHaveACloseButton_()
        {
            Report.WriteLine("Close button for PopuP remainder");
            VerifyElementPresent(attributeName_xpath, ShippingFrom_MapClose_Button_NewScreen_Xpath, "Close");
        }
        
        [Then(@"the modal will close\.")]
        public void ThenTheModalWillClose_()
        {
            VerifyElementPresent(attributeName_xpath, AddShipment_PageTitle_xpath, "Add Shipment(LTL)");
        }
    }
}
