using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Quote.LTL.Shipment_Information_Screen.Get_Quote__LTL__Screen
{
    [Binding]
    public class GetQuoteLTL_DimFieldsRequiredWhenValueEnteredSteps : Quotelist
    {
        IWebDriver driver = GlobalVariables.webDriver;
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();

        [Given(@"I have NOT selected Overlength as a accessorial in either of the following sections: Shipping From, Shipping To")]
        public void GivenIHaveNOTSelectedOverlengthAsAAccessorialInEitherOfTheFollowingSectionsShippingFromShippingTo()
        {
            Report.WriteLine("Overlength has not selected as accessorial");
            Click(attributeName_id, GetQuote_ClearItem_Button_Id);
            if (GlobalVariables.webDriver.FindElements(By.XPath("//*[@id='servicesaccessorialsfrom_chosen']/ul/li[span[.='Overlength']]/a")).Count > 0)
                Click(attributeName_xpath, "//*[@id='servicesaccessorialsfrom_chosen']/ul/li[span[.='Overlength']]/a");
        }

        [Given(@"I am on GetQuote \(LTL\) page")]
        public void GivenIAmOnGetQuoteLTLPage()
        {
            Report.WriteLine("I am on the Get Quote (LTL) page");

            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, QuoteIconModule_Xpath);
            Report.WriteLine("Navigated to Quote list page");

            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, QuoteSubmitrateRequest_Button_Xpath);
            Click(attributeName_xpath, GetQuote_LtlButton_Xpath);

        }

        [When(@"I enter the following values in the length width and height fields ""(.*)"", ""(.*)"", ""(.*)""")]
        public void WhenIEnterTheFollowingValuesInTheLengthWidthAndHeightFields(string length, string width, string height)
        {
            Thread.Sleep(2000);
            SendKeys(attributeName_id, QuoteLTLPage_Length_Id, length);
            Thread.Sleep(2000);
            SendKeys(attributeName_id, QuoteLTLPage_Width_Id, width);
            Thread.Sleep(2000);
            SendKeys(attributeName_id, QuoteLTLPage_Height_Id, height);
        }

        [When(@"I click Clear Item for that item")]
        public void WhenIClickClearItemForThatItem()
        {
            Click(attributeName_id, GetQuote_ClearItem_Button_Id);
        }

        [When(@"I remove the value for Length")]
        public void WhenIRemoveTheValueForLength()
        {
            Thread.Sleep(1000);
            SendKeys(attributeName_id, QuoteLTLPage_Length_Id, "");
        }

        [When(@"I have selected Overlength as a accessorial in the Shipping From field")]
        public void WhenIHaveSelectedOverlengthAsAAccessorialInTheShippingFromField()
        {
            Click(attributeName_xpath, LTL_ServicesAndAccessorials_ShipFrom_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, LTL_ServicesAndAccessorials_ShipFrom_Xpath, "Overlength");
        }

        [When(@"I have un-selected Overlength as an accessorial in the Shipping From field")]
        public void WhenIHaveUn_SelectedOverlengthAsAnAccessorialInTheShippingFromField()
        {Thread.Sleep(1000);
            Click(attributeName_xpath, "//*[@id='servicesaccessorialsfrom_chosen']/ul/li[span[.='Overlength']]/a");
        }

        [When(@"I enter the following values in the length width and height fields for an additional item ""(.*)"", ""(.*)"", ""(.*)""")]
        public void WhenIEnterTheFollowingValuesInTheLengthWidthAndHeightFieldsForAnAdditionalItem(string length, string width, string height)
        {
            Thread.Sleep(1000);
            Click(attributeName_xpath, GetQuote_AddAdditionalItem_Button_XPath);

            Thread.Sleep(1000);
            SendKeys(attributeName_id, QuoteLTLPage_Length_Id_Additional, length);
            Thread.Sleep(1000);
            SendKeys(attributeName_id, QuoteLTLPage_Width_Id_Additional, width);
            Thread.Sleep(1000);
            SendKeys(attributeName_id, QuoteLTLPage_Height_Id_Additional, height);
        }

        [When(@"I click Clear Item for that additional item")]
        public void WhenIClickClearItemForThatAdditionalItem()
        {
            Click(attributeName_id, GetQuote_ClearItem_Button_Id_Additional);
        }

        [When(@"I remove the value for Length for the additional item")]
        public void WhenIRemoveTheValueForLengthForTheAdditionalItem()
        {
            Thread.Sleep(1000);
            SendKeys(attributeName_id, QuoteLTLPage_Length_Id_Additional, "");
        }

        [When(@"I add (.*) additional items")]
        public void WhenIAddAdditionalItems(int numItems)
        {
            for(int i = 0; i < numItems; i++)
            {
                Click(attributeName_xpath, GetQuote_AddAdditionalItem_Button_XPath);
                WaitForElementVisible(attributeName_id, "length-" + (i + 1).ToString(), "Additional item length field");
            }
        }



        [Then(@"the Length, Width, and Height fields will not be required")]
        public void ThenTheLengthWidthAndHeightFieldsWillNotBeRequired()
        {
            var lengthElement = GlobalVariables.webDriver.FindElement(By.Id(QuoteLTLPage_Length_Id));
            var widthElement = GlobalVariables.webDriver.FindElement(By.Id(QuoteLTLPage_Width_Id));
            var heightElement = GlobalVariables.webDriver.FindElement(By.Id(QuoteLTLPage_Height_Id));

            Assert.IsFalse(elementHasClass(lengthElement, "required-input-field"));
            Assert.IsFalse(elementHasClass(widthElement, "required-input-field"));
            Assert.IsFalse(elementHasClass(heightElement, "required-input-field"));
        }

        [Then(@"the Length, Width, and Height fields will be required")]
        public void ThenTheLengthWidthAndHeightFieldsWillBeRequired()
        {
            var lengthElement = GlobalVariables.webDriver.FindElement(By.Id(QuoteLTLPage_Length_Id));
            var widthElement = GlobalVariables.webDriver.FindElement(By.Id(QuoteLTLPage_Width_Id));
            var heightElement = GlobalVariables.webDriver.FindElement(By.Id(QuoteLTLPage_Height_Id));

            Assert.IsTrue(elementHasClass(lengthElement, "required-input-field"));
            Assert.IsTrue(elementHasClass(widthElement, "required-input-field"));
            Assert.IsTrue(elementHasClass(heightElement, "required-input-field"));
        }

        [Then(@"the Length, Width, and Height fields will be required for the additional item")]
        public void ThenTheLengthWidthAndHeightFieldsWillBeRequiredForTheAdditionalItem()
        {
            var lengthElement = GlobalVariables.webDriver.FindElement(By.Id(QuoteLTLPage_Length_Id_Additional));
            var widthElement = GlobalVariables.webDriver.FindElement(By.Id(QuoteLTLPage_Width_Id_Additional));
            var heightElement = GlobalVariables.webDriver.FindElement(By.Id(QuoteLTLPage_Height_Id_Additional));

            Assert.IsTrue(elementHasClass(lengthElement, "required-input-field"));
            Assert.IsTrue(elementHasClass(widthElement, "required-input-field"));
            Assert.IsTrue(elementHasClass(heightElement, "required-input-field"));
        }

        [Then(@"the Length, Width, and Height fields will not be required for the additional item")]
        public void ThenTheLengthWidthAndHeightFieldsWillNotBeRequiredForTheAdditionalItem()
        {
            var lengthElement = GlobalVariables.webDriver.FindElement(By.Id(QuoteLTLPage_Length_Id_Additional));
            var widthElement = GlobalVariables.webDriver.FindElement(By.Id(QuoteLTLPage_Width_Id_Additional));
            var heightElement = GlobalVariables.webDriver.FindElement(By.Id(QuoteLTLPage_Height_Id_Additional));

            Assert.IsFalse(elementHasClass(lengthElement, "required-input-field"));
            Assert.IsFalse(elementHasClass(widthElement, "required-input-field"));
            Assert.IsFalse(elementHasClass(heightElement, "required-input-field"));
        }

        [Then(@"the Length, Width, and Height fields will not be required for the second additional item")]
        public void ThenTheFreightLengthWidthAndHeightFieldsWillNotBeRequiredForTheSecondAdditionalItem()
        {
            var lengthElement = GlobalVariables.webDriver.FindElement(By.Id(QuoteLTLPage_Length_Id_Second_Additional));
            var widthElement = GlobalVariables.webDriver.FindElement(By.Id(QuoteLTLPage_Width_Id_Second_Additional));
            var heightElement = GlobalVariables.webDriver.FindElement(By.Id(QuoteLTLPage_Height_Id_Second_Additional));

            Assert.IsFalse(elementHasClass(lengthElement, "required-input-field"));
            Assert.IsFalse(elementHasClass(widthElement, "required-input-field"));
            Assert.IsFalse(elementHasClass(heightElement, "required-input-field"));
        }



        public bool elementHasClass(IWebElement element, string requiredInput) { return element.GetAttribute("class").Contains(requiredInput); }
    }
}
