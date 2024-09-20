using System.Configuration;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Scripts.QuoteToShipment.LTL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;

namespace CRM.UITest.Scripts.RateToShipment.LTL.ShipmentInformationScreen
{
    [Binding]
    public class RateRequestLTLToAddShipmentLTL_NewAccessorial_NotificationSteps : AddShipmentLTL
    {
        AddShipmentLTL addShipment = new AddShipmentLTL();
        AddQuoteLTL getQuote = new AddQuoteLTL();
        RateToShipmentLTL rateToShipment = new RateToShipmentLTL();
        AddShipmentLTL addShipmentObjects = new AddShipmentLTL();
        [Given(@"I have passed all mandatory fields by selecting Notification in shipfrom section")]
        public void GivenIHavePassedAllMandatoryFieldsBySelectingNotificationInShipfromSection()
        {
            Report.WriteLine("I have passed all mandatory fields Length,Width,Height fields by selecting Overlength");
            getQuote.EnterOriginZip("60606");
            getQuote.EnterDestinationZip("33126");
            getQuote.EnterItemdata("50", "50");
            Click(attributeName_xpath, LTL_ServicesAndAccessorials_ShipFrom_Xpath);
            DefineTimeOut(2000);
            SelectDropdownValueFromList(attributeName_xpath, LTL_ServicesDropdownValues_ShipFrom_Xpath, "Notification");
            SendKeys(attributeName_id, LTL_Length_Id, "11");
            SendKeys(attributeName_id, LTL_Width_Id, "11");
            SendKeys(attributeName_id, LTL_Height_Id, "11");
            //Click(attributeName_xpath, "//*[@id='Length-Additional-Warning-0']/h4/i[@class='icon-close right']");
            DefineTimeOut(1000);
                      
        }
        [Given(@"I have passed all mandatory fields by selecting Notification in shipto section")]
        public void GivenIHavePassedAllMandatoryFieldsBySelectingNotificationInShiptoSection()
        {

            Report.WriteLine("I have passed all mandatory fields Length,Width,Height fields by selecting Overlength");
            getQuote.EnterOriginZip("60606");
            getQuote.EnterDestinationZip("33126");
            getQuote.EnterItemdata("50", "50");
            Click(attributeName_xpath, LTL_ServicesAndAccessorials_ShipTo_Xpath);
            DefineTimeOut(2000);
            SelectDropdownValueFromList(attributeName_xpath, LTL_ServicesDropdownValues_ShipTo_Xpath, "Notification");
            SendKeys(attributeName_id, LTL_Length_Id, "11");
            SendKeys(attributeName_id, LTL_Width_Id, "11");
            SendKeys(attributeName_id, LTL_Height_Id, "11");
            //Click(attributeName_xpath, "//*[@id='Length-Additional-Warning-0']/h4/i[@class='icon-close right']");
            DefineTimeOut(1000);
            rateToShipment.EnterDataInInsuredField_Quote("100");

        }
      
        [When(@"I click on create shipment for selected carrier which has gaurenteed rate")]
        public void WhenIClickOnCreateShipmentForSelectedCarrierWhichHasGaurenteedRate()
        {
            getQuote.ClickViewRates();
            Report.WriteLine("I am on Rate Results page");
            Report.WriteLine("I click on create shipment for selected carrier which has gaurenteed rate");
            Click(attributeName_xpath, "(.//*[@id='create-gua-shipment-btn'])[1]");
        }
        
        [When(@"I click on create insured shipment for selected carrier which has gaurenteed rate")]
        public void WhenIClickOnCreateInsuredShipmentForSelectedCarrierWhichHasGaurenteedRate()
        {
            Report.WriteLine("I click on create shipment for selected carrier which has gaurenteed rate");
            Click(attributeName_xpath, "CreateInsuredshipment_Gauranteed_xpath");
        }
        
        [Then(@"Notification accessorials should be autopoulated on Add Shipment \(LTL\) page")]
        public void ThenNotificationAccessorialsShouldBeAutopoulatedOnAddShipmentLTLPage()
        {
            Report.WriteLine("I will see the Notification accessorial auto populated in  add services & accessorials field of the Shipping from section");
            Assert.AreEqual(Gettext(attributeName_xpath,ShippingFrom_selectedServicesAccessorial_DropDown_xpath), "Notification");

        }

        [Then(@"Notification accessorials in shipto should be autopoulated on Add Shipment \(LTL\) page")]
        public void ThenNotificationAccessorialsInShiptoShouldBeAutopoulatedOnAddShipmentLTLPage()
        {
           Report.WriteLine("I will see the Notification accessorial auto populated in  add services & accessorials field of the Shipping from section");
            Assert.AreEqual(Gettext(attributeName_xpath, ShippingTo_selectedServicesAccessorial_DropDown_xpath), "Notification");

        }


        [Then(@"Notification accessorials in shipto section should be editable")]
        public void ThenNotificationAccessorialsInShiptoSectionShouldBeEditable()
        {
            Report.WriteLine("Notification accessorials in shipto should be autopoulated on Add Shipment LTL page");
            GlobalVariables.webDriver.WaitForPageLoad();
            VerifyElementEnabled(attributeName_xpath, ShippingTo_ServicesAccessorial_DropDown_xpath, "Notification");
            Click(attributeName_xpath, ShippingTo_ServicesAccessorial_Delete_Icon_xpath);
            Assert.AreEqual(Gettext(attributeName_xpath, ShippingTo_ServicesAccessorial_DropDown_xpath), "");
            Report.WriteLine("User should be able to remove the notification accessorial");
        }

        [Then(@"Notification accessorials in shipfrom section should be editable")]
        public void ThenNotificationAccessorialsInShipfromSectionShouldBeEditable()
        {
            Report.WriteLine("Notification accessorials in shipfrom should be autopoulated on Add Shipment LTL page");
            GlobalVariables.webDriver.WaitForPageLoad();
            VerifyElementEnabled(attributeName_xpath, ShippingFrom_ServicesAccessorial_DropDown_xpath, "Notification");
            Click(attributeName_xpath, ShippingFrom_ServicesAccessorial_Delete_Icon_xpath);
            Assert.AreEqual(Gettext(attributeName_xpath, ShippingFrom_ServicesAccessorial_DropDown_xpath),"");
            Report.WriteLine("User should be able to remove the notification accessorial");
        }

    }
}
