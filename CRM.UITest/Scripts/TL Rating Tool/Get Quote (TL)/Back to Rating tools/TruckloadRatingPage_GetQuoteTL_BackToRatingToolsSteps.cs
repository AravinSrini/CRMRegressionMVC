using System;
using System.Threading;
using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using TechTalk.SpecFlow;


namespace CRM.UITest.Scripts.TL_Rating_Tool.Get_Quote__TL_.Back_to_Rating_tools
{
    [Binding]
    public class TruckloadRatingPage_GetQuoteTL_BackToRatingToolsSteps:TruckloadRatingTool
    {

        [Given(@"I have entered required fields '(.*)','(.*)','(.*)','(.*)' in TL Rating Tool Projected amount page")]
        public void GivenIHaveEnteredRequiredFieldsInTLRatingToolProjectedAmountPage(string OriginZipCode, string DestinationZipCode, string p2, string Weight)
        {
            Report.WriteLine("Pass data to Projected Amount fields");
            SendKeys(attributeName_id, ProjectedAmount_OriginZip_Textbox_Id, OriginZipCode);
            SendKeys(attributeName_id, ProjectedAmount_DestinationZip_Textbox_Id, DestinationZipCode);
            Click(attributeName_xpath, "html/body/div[4]/section/div[4]/form/div[1]/div[3]/div/div[1]/span/i");
            DatePickerFromCalander(attributeName_xpath, "html/body/div[7]/div[1]/table/tbody/tr/td", 0, "html/body/div[7]/div[1]/table/thead/tr[1]/th[3]/i");
            SendKeys(attributeName_id, ProjectedAmount_Weight_Textbox_Id, Weight);

        }


        [Given(@"I have Clicked on Get Rate button in TL Rating Tool Projected amount page")]
        public void GivenIHaveClickedOnGetRateButtonInTLRatingToolProjectedAmountPage()
        {
            Report.WriteLine("Click on GetRate button");           
			try
			{
				Click(attributeName_id, ProjectedAmount_GetRate_Button_ID);
				Thread.Sleep(5000);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
            WaitForElementVisible(attributeName_id, ProjectedAmount_GetQuoteNow_Button_ID, "GetQuoteNow Button");
        }
        
        [Given(@"I have clicked on Get Quote New button in rating tool page")]
        public void GivenIHaveClickedOnGetQuoteNewButtonInRatingToolPage()
        {
            Report.WriteLine("Click on Get Quote Now");
            Click(attributeName_xpath, ProjectedAmount_GetQuoteNow_Button_Xpath);
        }

        [When(@"I have arrived on Get Quote \(TL\) '(.*)' page")]
        public void WhenIHaveArrivedOnGetQuoteTLPage(string GetQuoteTitle)
        {
            Report.WriteLine("Get Quote TL page");
            Verifytext(attributeName_xpath, TL_GetQuote_Title_Xpath, GetQuoteTitle);
        }

        
        [When(@"I click on Back to Rating Tools button")]
        public void WhenIClickOnBackToRatingToolsButton()
        {
            Report.WriteLine("Click on Rating Tools");
            Click(attributeName_xpath, TL_BackToRatingTools_Button_Xpath);
        }

        [Then(@"I must be naviagted back to '(.*)' page")]
        public void ThenIMustBeNaviagtedBackToPage(string RatingTools)
        {
            Report.WriteLine("Projected Page Navigation");
            Verifytext(attributeName_xpath, TL_ProjectedAmountPage_Title_Xpath, RatingTools);
        }

    }
}
