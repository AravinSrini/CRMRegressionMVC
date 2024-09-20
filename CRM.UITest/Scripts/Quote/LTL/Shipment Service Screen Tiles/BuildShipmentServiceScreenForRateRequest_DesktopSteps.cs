using System;
using TechTalk.SpecFlow;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;


namespace CRM.UITest.Scripts.Quote.LTL
{
    [Binding]
    public class BuildShipmentServiceScreenForRateRequest_DesktopSteps : ObjectRepository
    {

        [Then(@"The (.*) list button should be present on Shipment service screen")]
        public void ThenTheListButtonShouldBePresentOnShipmentServiceScreen(string BacktoQuote)
        {
            Report.WriteLine("Visibility of Back to Quote button");
            VerifyElementPresent(attributeName_id, BackToQuoteButton_Id, BacktoQuote);
        }

    }
}
