using CRM.UITest.CommonMethods;
using CRM.UITest.Helper.Implementations;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Xml.Linq;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Quote.LTL.Quote_Results_Screen
{
    [Binding]
    public class _75715_Quote__LTL____Accessorial_Cost__0 : AddShipments
    {
        CommonMethodsCrm crm = new CommonMethodsCrm();
        
        [Given(@"I am a ship inquiry or ship entry user with a valid ""(.*)"" ""(.*)""")]
        public void GivenIAmAShipInquiryOrShipEntryUserWithAValid(string user, string pass)
        {
            string username = ConfigurationManager.AppSettings[user].ToString();
            string password = ConfigurationManager.AppSettings[pass].ToString();
            Report.WriteLine("Logging in as " + username);
            crm.LoginToCRMApplication(username, password);
        }

        [Given(@"I have selected ""(.*)"" as an accessorial that has a calculated cost of zero")]
        public void GivenIHaveSelectedAsAnAccessorialThatHasACalculatedCostOfZero(string accessorial)
        {
            Report.WriteLine("Selecting the accessorial " + accessorial + " of cost zero");
            Click(attributeName_xpath, LTL_ServicesAndAccessorials_ShipFrom_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, LTL_ServicesAndAccessorials_ShipFrom_Xpath, accessorial);
        }

        [Given(@"I have clicked on View Quote Results")]
        public void GivenIHaveClickedOnViewQuoteResults()
        {
            Report.WriteLine("Click on View Quote Results button");
            Click(attributeName_xpath, ViewQuoteResults_xpath);
        }

        [Given(@"I have selected ""(.*)"" as an accessorial that has a calculated cost greater than zero")]
        public void GivenIHaveSelectedAsAnAccessorialThatHasACalculatedCostGreaterThanZero(string accessorial)
        {
            Report.WriteLine("Selecting the accessorial " + accessorial + " of cost greater than zero");
            Click(attributeName_xpath, LTL_ServicesAndAccessorials_ShipFrom_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, LTL_ServicesAndAccessorials_ShipFrom_Xpath, accessorial);
        }

        [Given(@"I have entered an insured value of ""(.*)""")]
        public void GivenIHaveEnteredAnInsuredValueOf(string value)
        {
            Report.WriteLine("Included insured value");
            WaitForElementVisible(attributeName_id, "quote-criteria-pickup-date", "ShipmentValueNumber");
            SendKeys(attributeName_xpath, "//*[@id='shipValueNumber']", value);
            Click(attributeName_xpath, ShipResults_ShowInsuredRateButton_Xpath);
        }

        [Given(@"I have input the following information for Shipping From ""(.*)""")]
        public void GivenIHaveInputTheFollowingInformationForShippingFrom(string zip)
        {
            Report.WriteLine("Adding shipping from information");
            Click(attributeName_id, ShippingFrom_zipcode_Id);
            Thread.Sleep(500);
            SendKeys(attributeName_id, ShippingFrom_zipcode_Id, zip);
            Thread.Sleep(500);
            SendKeys(attributeName_id, ShippingFrom_City_Id, "Romeoville");
            Thread.Sleep(500);
            Click(attributeName_xpath, ShippingFrom_StateDropdwon_xpath);
            SelectDropdownValueFromList(attributeName_xpath, ShippingFrom_StateDropdwon_Values_xpath, "IL");
        }

        [Given(@"I have input the following information for Shipping To ""(.*)""")]
        public void GivenIHaveInputTheFollowingInformationForShippingTo(string zip)
        {
            Report.WriteLine("Entering destination zip code");
            Click(attributeName_id, ShippingTo_zipcode_Id);
            Thread.Sleep(500);
            SendKeys(attributeName_id, ShippingTo_zipcode_Id, zip);
            Thread.Sleep(500);
            SendKeys(attributeName_id, ShippingTo_City_Id, "Chicago");
            Thread.Sleep(500);
            Click(attributeName_xpath, ShippingTo_StateDropdwon_xpath);
            SelectDropdownValueFromList(attributeName_xpath, ShippingTo_StateDropdwon_Values_xpath, "IL");
        }

        [Given(@"I enter the following values in the length width and height fields ""(.*)"", ""(.*)"", ""(.*)""")]
        public void WhenIEnterTheFollowingValuesInTheLengthWidthAndHeightFields(string length, string width, string height)
        {
            Thread.Sleep(500);
            SendKeys(attributeName_id, "length-0", length);
            Thread.Sleep(500);
            SendKeys(attributeName_id, "width-0", width);
            Thread.Sleep(500);
            SendKeys(attributeName_id, "height-0", height);
        }

        [Given(@"Overlength is not selected as a accessorial in either of the following sections: Shipping From, Shipping To")]
        public void GivenOverlengthIsNotSelectedAsAAccessorialInEitherOfTheFollowingSectionsShippingFromShippingTo()
        {
            Report.WriteLine("Overlength has not selected as accessorial");
            if (GlobalVariables.webDriver.FindElements(By.XPath("//*[@id='servicesaccessorialsfrom_chosen']/ul/li[span[.='Overlength']]/a")).Count > 0)
                Click(attributeName_xpath, "//*[@id='servicesaccessorialsfrom_chosen']/ul/li[span[.='Overlength']]/a");
        }

        [When(@"the Save Rate as Quote button is clicked")]
        public void WhenTheSaveRateAsQuoteButtonIsClicked()
        {
            Report.WriteLine("Click Save Rate as Quote Button");
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, "//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[td[1][contains(.,'Central Transport')]]", "Rate Grid");
            scrollElementIntoView(attributeName_xpath, "//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[td[1][contains(.,'Central Transport')]]");
            WaitForElementVisible(attributeName_xpath, "//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[td[1][contains(.,'Central Transport')]]/td[4]/ul[2]/li/a", "Central Transport create shipment button");
            Click(attributeName_xpath, "//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[td[1]/ul/li[contains(.,'Central Transport')]]/td[4]/ul[2]/li/a");
        }

        [When(@"the Save Insured Rate as Quote button is clicked")]
        public void WhenTheSaveInsuredRateAsQuoteButtonIsClicked()
        {
            Report.WriteLine("Click Save Insured Rate as Quote button");
            GlobalVariables.webDriver.WaitForPageLoad();

            WaitForElementVisible(attributeName_xpath, "//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[td[1][contains(.,'Central Transport')]]", "Rate Grid");
            scrollElementIntoView(attributeName_xpath, "//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[td[1][contains(.,'Central Transport')]]");
            WaitForElementVisible(attributeName_xpath, "//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[td[1][contains(.,'Central Transport')]]/td[5]/ul[2]/li/a", "Central Transport create insured shipment button");
            Click(attributeName_xpath, "//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[td[1]/ul/li[contains(.,'Central Transport')]]/td[5]/ul[2]/li/a");
        }

        [Then(@"the appointment accessorial will not be included in the Customer Price Sheet in MG\.")]
        public void ThenTheAppointmentAccessorialWillNotBeIncludedInTheCustomerPriceSheetInMGFor()
        {
            Report.WriteLine("Verify accessorial with cost less than zero is on pricesheet");
            WaitForElementPresent(attributeName_id, "referenceNumber-value", "Reference Number Value");
            string quoteNumber = GlobalVariables.webDriver.FindElement(By.Id("referenceNumber-value")).Text;
            XDocument shipment = GetShipmentFromMG.getShipment(quoteNumber);

            List<XElement> chargeListWithAccessorials = shipment.Elements("MercuryGate").Elements("Shipment").Elements("PriceSheets").Elements("PriceSheet").Elements("Charges").Elements("Charge")
                            .Where(x => x.Attribute("type").Value.ToUpper().Equals("ACCESSORIAL")).Where(x => x.Element("Amount").Equals("0.00")).ToList();

            if (chargeListWithAccessorials.Count != 0)
            {
                foreach(XElement charge in chargeListWithAccessorials)
                {
                    string value = charge.Element("Description").Value;

                    if (value == "APPT")
                    {
                        Report.WriteFailure("Accessorial that equals zero in value is included in pricesheet");
                    }
                }
            }

            Report.WriteLine("Test Passed: Accessorial of cost zero not included");
        }

        [Then(@"the Limited Access Pickup accesorial will be included in the Customer Price Sheet in MG\.")]
        public void ThenTheLimitedAccessPickupAccesorialWillBeIncludedInTheCustomerPriceSheetInMG_()
        {
            Report.WriteLine("Verify accessorial with cost greater than zero is on pricesheet");
            WaitForElementPresent(attributeName_id, "referenceNumber-value", "Reference Number Value");
            string quoteNumber = GlobalVariables.webDriver.FindElement(By.Id("referenceNumber-value")).Text;
            XDocument shipment = GetShipmentFromMG.getShipment(quoteNumber);

            List<XElement> chargeListWithAccessorials = shipment.Elements("MercuryGate").Elements("Shipment").Elements("PriceSheets").Elements("PriceSheet").Elements("Charges").Elements("Charge")
                            .Where(x => x.Attribute("type").Value.ToUpper().Equals("ACCESSORIAL")).ToList();

            if (chargeListWithAccessorials.Count != 0)
            {
                foreach(XElement charge in chargeListWithAccessorials)
                {
                    string value = charge.Element("Description").Value;

                    if (value != "All Risk" && value != "Limited Access Pickup" && value != "Product Protection")
                    {
                        Report.WriteFailure("Accessorial that equals zero in value is included in pricesheet");
                    }
                }
            }
            else
            {
                Report.WriteFailure("No charges with accessorials found");
            }
            
            Report.WriteLine("Test Passed: Accessorial of cost greater than zero included");
        }
    }
}
