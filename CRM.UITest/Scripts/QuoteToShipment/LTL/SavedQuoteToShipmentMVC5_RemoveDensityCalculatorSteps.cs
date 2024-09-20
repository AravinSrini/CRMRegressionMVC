using System;
using TechTalk.SpecFlow;
using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;

namespace CRM.UITest.Scripts.QuoteToShipment.LTL
{
    [Binding]
    public class SavedQuoteToShipmentMVC5_RemoveDensityCalculatorSteps:ObjectRepository
    {               
        [Then(@"I should not be displayed with Estimate Class button")]
        public void ThenIShouldNotBeDisplayedWithEstimateClassButton()
        {
            Report.WriteLine("Not displaying the Estomate Class button");
            VerifyElementNotVisible(attributeName_id, LTL_EstimateClassButton_Id, "Button");
        }
    }
}
