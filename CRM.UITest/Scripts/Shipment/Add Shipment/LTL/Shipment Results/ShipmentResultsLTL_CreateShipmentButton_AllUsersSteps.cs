using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using CRM.UITest.Objects;
using TechTalk.SpecFlow;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Results
{
    [Binding]
    public class ShipmentResultsLTL_CreateShipmentButton_AllUsersSteps : AddShipments
    {
        [When(@"I click on Create Shipment button of any carrier displayed")]
        public void WhenIClickOnCreateShipmentButtonOfAnyCarrierDisplayed()
        {
            Report.WriteLine("Click on Create Shipment button");
            Click(attributeName_xpath, ShipResults_CreateShipButton_Xpath);
        }

        [Then(@"I must be navigated to Review and Submit Shipment page")]
        public void ThenIMustBeNavigatedToReviewAndSubmitShipmentPage()
        {
            Report.WriteLine("Navigation to Review and Submit page");
            Verifytext(attributeName_xpath, ReviewAndSubmit_Title_Xpath, "Review and Submit Shipment (LTL)");
        }

        [When(@"I click on Create Insured Shipment button of any carrier displayed")]
        public void WhenIClickOnCreateInsuredShipmentButtonOfAnyCarrierDisplayed()
        {
            Report.WriteLine("Click on Create Insured Shipment Button");
            Click(attributeName_xpath, ShipResults_CreateShipInsuredButton_Xpath);
        }

        [When(@"I enter Insured value - (.*)")]
        public void WhenIEnterInsuredValue_(string Insured)
        {
            Report.WriteLine("Insured value");
            SendKeys(attributeName_xpath, ShipResults_InsuredValue_Xpath, Insured);
            Click(attributeName_xpath, ShipResults_ShowInsuredRateButton_Xpath);
        }


    }
}
