using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.TL_Rating_Tool.Get_Quote__TL_
{
    [Binding]
    public sealed class GetQuote_Truckload_Steps : TruckloadRatingTool
    {
        

        [When(@"I enter required fields (.*),(.*),(.*) in rating tool page")]
        public void WhenIEnterRequiredFieldsInRatingToolPage(string OriginZipCode, string DestinationZipCode, string Weight)
        {
            SendKeys(attributeName_id, ProjectedAmount_OriginZip_Textbox_Id, OriginZipCode);
            SendKeys(attributeName_id, ProjectedAmount_DestinationZip_Textbox_Id, DestinationZipCode);
            SendKeys(attributeName_id, ProjectedAmount_Weight_Textbox_Id, Weight);
        }

        [When(@"Click on Get Rate button in rating tool page")]
        public void WhenClickOnGetRateButtonInRatingToolPage()
        {
            Report.WriteLine("Click on GetRate button");
            Click(attributeName_id, ProjectedAmount_GetRate_Button_ID);
        }
    }
}
