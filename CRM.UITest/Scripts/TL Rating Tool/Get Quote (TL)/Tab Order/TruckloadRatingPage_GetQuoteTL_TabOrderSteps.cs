using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.TL_Rating_Tool.Get_Quote__TL_.Tab_Order
{
    [Binding]
    public class TruckloadRatingPage_GetQuoteTL_TabOrderSteps : TruckloadRatingTool
    {
        [Then(@"I must be able to verify the tab order for the mandatory fields for the GetQuote Truckload screen")]
        public void ThenIMustBeAbleToVerifyTheTabOrderForTheMandatoryFieldsForTheGetQuoteTruckloadScreen()
        {

            Report.WriteLine("Verifying for Tab in Shipping From Zip field");
            IWebElement _activeElement = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            string firstElementId = _activeElement.GetAttribute("id");
            Assert.AreEqual(firstElementId, "origin-zip");
            _activeElement.SendKeys(Keys.Tab);

            Report.WriteLine("Verifying for Tab in Shipping To Zip field");
            IWebElement _activeElement1 = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            string SecondElementId = _activeElement1.GetAttribute("id");
            Assert.AreEqual(SecondElementId, "destination-zip");
            _activeElement1.SendKeys(Keys.Tab);

            Report.WriteLine("Verifying for Tab in FreightDescription field");
            IWebElement _activeElement2 = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            string ThirdElementId = _activeElement2.GetAttribute("Id");
            Assert.AreEqual(ThirdElementId, "FreightDescription-0");
            _activeElement2.SendKeys(Keys.Tab);

            Report.WriteLine("Verifying for Tab in Quantity field");
            IWebElement _activeElement3 = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            string FourthElementId = _activeElement3.GetAttribute("Id");
            Assert.AreEqual(FourthElementId, "quantity-0");
            _activeElement3.SendKeys(Keys.Tab);

            Report.WriteLine("Verifying for Tab in Weight field");
            IWebElement _activeElement4 = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            string FifthElementId = _activeElement4.GetAttribute("Id");
            Assert.AreEqual(FifthElementId, "weight-0");
            _activeElement4.SendKeys(Keys.Tab);

            Report.WriteLine("Verifying for Tab in GetLiveQuote button");
            IWebElement _activeElement5 = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            string SixthElementId = _activeElement5.GetAttribute("Class");
            Assert.AreEqual(SixthElementId, "btn livequote btn btn-warning");
        }

    }
}