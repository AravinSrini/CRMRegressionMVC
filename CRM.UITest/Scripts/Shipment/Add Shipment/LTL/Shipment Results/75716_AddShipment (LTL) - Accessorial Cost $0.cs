using CRM.UITest.CommonMethods;
using CRM.UITest.Helper.Implementations;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml.Linq;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Results
{
    [Binding]
    public sealed class _75716_AddShipment__LTL____Accessorial_Cost__0 : AddShipments
    {
        [Given(@"I have selected ""(.*)"" as an accessorial that has a calculated cost of zero on the Add Shipment page")]
        [Given(@"I have selected ""(.*)"" as an accessorial that has a calculated cost greater than zero on the Add Shipment page")]
        public void GivenIHaveSelectedAsAnAccessorialThatHasACalculatedCostOfZeroOnTheAddShipmentPage(string accessorial)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, LTLAddShipment_SelectedAccessorial_ShippingFrom_Xpath, "Accessorial");
            WaitForElementVisible(attributeName_id, "cookiescript_badge_wrapper", "CookieScript");
            Report.WriteLine("Selecting " + accessorial + " accessorial");
            WaitForElementVisible(attributeName_xpath, LTLAddShipment_SelectedAccessorial_ShippingFrom_Xpath, "Shipping From Accessorial Dropdown");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, LTLAddShipment_SelectedAccessorial_ShippingFrom_Xpath);
            Thread.Sleep(500);
            SendKeys(attributeName_xpath, "//*[@id='shippingfromaccessorial_chosen']/ul/li/input", accessorial);
            SelectDropdownValueFromList(attributeName_xpath, LTLAddShipment_SelectedAccessorial_ShippingFrom_Xpath, accessorial);
        }
        
        [Given(@"I have entered all the required information in the Freight Description section - \{(.*)}, \{(.*)}, \{(.*)}, \{(.*)}")]
        public void GivenIHaveEnteredAllTheRequiredInformationInTheFreightDescriptionSection_(string classNumber, string description, string quantity, string weight)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Writing information to freight description section");
            Thread.Sleep(500);
            SendKeys(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id, classNumber);
            Thread.Sleep(500);
            SendKeys(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id, description);
            Thread.Sleep(500);
            SendKeys(attributeName_id, FreightDesp_FirstItem_Quantity_Id, quantity);
            Thread.Sleep(500);
            SendKeys(attributeName_id, FreightDesp_FirstItem_Weight_Id, weight);
        }

        [Given(@"I have entered the following dimensions ""(.*)"", ""(.*)"", ""(.*)""")]
        public void GivenIHaveEnteredTheFollowingDimensions(int length, int width, int height)
        {
            Thread.Sleep(500);
            SendKeys(attributeName_id, FreightDesp_FirstItem_Length_Id, length.ToString());
            Thread.Sleep(500);
            SendKeys(attributeName_id, FreightDesp_FirstItem_Width_Id, width.ToString());
            Thread.Sleep(500);
            SendKeys(attributeName_id, FreightDesp_FirstItem_Height_Id, height.ToString());
        }

        [Given(@"I add the following reference numbers ""(.*)""")]
        public void GivenIAddTheFollowingReferenceNumbers(int reference)
        {
            Thread.Sleep(500);
            SendKeys(attributeName_id, "orderNumber", reference.ToString());
            Thread.Sleep(500);
            SendKeys(attributeName_id, "glcode", reference.ToString());
            Thread.Sleep(500);
            SendKeys(attributeName_id, "ltl-reference-num-1", reference.ToString());
            Thread.Sleep(500);
            SendKeys(attributeName_id, "ltl-reference-num-2", reference.ToString());
        }



        [When(@"I click the submit shipment button")]
        public void WhenIClickTheSubmitShipmentButton()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            scrollElementIntoView(attributeName_xpath, ViewRatesButton_xpath);
            Report.WriteLine("Clicking Submit Shipment button");
            Click(attributeName_xpath, ViewRatesButton_xpath);
        }

        [When(@"I click on the button Create Shipment")]
        public void WhenIClickOnTheButtonCreateShipment()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_id, ShipResults_CreateShipButton_Id, "Create Shipment Button");
            Report.WriteLine("Clicking Create Shipment button");
            Click(attributeName_xpath, "//*[@id='ShipmentResultTable']/tbody/tr[td[1]/div/div[contains(.,'Central Transport')]]//button[@id='createShipment']");
        }

        [When(@"I click the Submit Shipment button on the Review and Submit shipment page")]
        public void WhenIClickTheSubmitShipmentButtonOnTheReviewAndSubmitShipmentPage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Clicking Submit Shipment button on Review and Submit Shipment page");
            Click(attributeName_id, ReviewPage_SubmitButton_id);
        }

        [Then(@"the appointment accessorial will not be included in the Customer Price Sheet in MG from Add Shipment")]
        public void ThenTheAppointmentAccessorialWillNotBeIncludedInTheCustomerPriceSheetInMGFromAddShipment()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_id, "ref-num-label", "Reference number label");
            Report.WriteLine("Verifying accessorial value in MercuryGate");
            string quoteNumber = GlobalVariables.webDriver.FindElement(By.Id("ref-num-label")).Text;
            XDocument shipment = GetShipmentFromMG.getShipment(quoteNumber);

            List<XElement> chargeListWithAccessorials = shipment.Elements("MercuryGate").Elements("Shipment").Elements("PriceSheets").Elements("PriceSheet").Elements("Charges").Elements("Charge")
                .Where(x => x.Attribute("type").Value.ToUpper().Equals("ACCESSORIAL")).Where(x => x.Element("Amount").Equals("0.00")).ToList();

            if (chargeListWithAccessorials.Count != 0)
            {
                Report.WriteFailure("");
            }
            
            Report.WriteLine("Test passed, accessorial that should not be included is not being shown.");
        }

        [Then(@"the Limited Access Pickup accessorial will be included in the Customer Price Sheet in MG from Add Shipment")]
        public void ThenTheLimitedAccessPickupAccessorialWillBeIncludedInTheCustomerPriceSheetInMGFromAddShipment()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_id, "ref-num-label", "Reference Number");
            Report.WriteLine("Verifying accessorial value in MercuryGate");
            string quoteNumber = GlobalVariables.webDriver.FindElement(By.Id("ref-num-label")).Text;
            XDocument shipment = GetShipmentFromMG.getShipment(quoteNumber);

            List<XElement> chargeListWithAccessorials = shipment.Elements("MercuryGate").Elements("Shipment").Elements("PriceSheets").Elements("PriceSheet").Elements("Charges").Elements("Charge")
                .Where(x => x.Attribute("type").Value.ToUpper().Equals("ACCESSORIAL")).ToList();

            if (chargeListWithAccessorials.Count != 0)
            {
                foreach (XElement charge in chargeListWithAccessorials)
                {
                    string value = charge.Element("Description").Value;

                    if (value != "All Risk" && value != "Limited Access Pickup")
                    {
                        Report.WriteLine("Test failure, accessorial that should be included is not appearing.");
                    }
                }
            }
            else
            {
                Report.WriteFailure("No charges with accessorials found");
            }
            
            Report.WriteLine("Test passed with accessorial that should be included.");
        }
    }
}
