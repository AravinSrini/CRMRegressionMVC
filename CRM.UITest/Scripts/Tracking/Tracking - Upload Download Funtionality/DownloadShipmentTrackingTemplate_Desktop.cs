using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Tracking
{
    [Binding]
    public sealed class DownloadShipmentTrackingTemplate_Desktop : ObjectRepository
    {
        [Then(@"I must see the Download template button '(.*)'")]
        public void ThenIMustSeeTheDownloadTemplateButton(string DownloadBtn)
        {
            Report.WriteLine("Must see the Download template button in tracking landing page");
            Verifytext(attributeName_id, DownloadinTrackingBtn_id, DownloadBtn);
        }

        [When(@"I click the Download Template button in the tracking landing page")]
        public void WhenIClickTheDownloadTemplateButtonInTheTrackingLandingPage()
        {
            Report.WriteLine("click the Download Template button in the tracking landing page");
            Click(attributeName_id, DownloadinTrackingBtn_id);
        }

    }
}
