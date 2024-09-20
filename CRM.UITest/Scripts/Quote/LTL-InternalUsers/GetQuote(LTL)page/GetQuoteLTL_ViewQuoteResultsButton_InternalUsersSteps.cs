using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using CRM.UITest.Objects;
using System;
using TechTalk.SpecFlow;
using System.Threading;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using OpenQA.Selenium;
using System.Collections.Generic;
using CRM.UITest.CommonMethods;

namespace CRM.UITest.Scripts.Quote.LTL_InternalUsers.GetQuote_LTL_page
{
    [Binding]
    public class GetQuoteLTL_ViewQuoteResultsButton_InternalUsersSteps : ObjectRepository
    {
        [Given(@"I am a DLS user and Login into application with valid (.*) and (.*)")]
        public void GivenIAmADLSUserAndLoginIntoApplicationWithValid(string userName, string password)
        {
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(userName, password);
            Report.WriteLine("I logged into CRM application with RRD access user");
        }

        [When(@"I have entered valid zipcode (.*) in Shipping From section")]
        public void WhenIHaveEnteredValidZipcodeInShippingFromSection(string ShippingFrom)
        {
            Report.WriteLine("Entering Zip/postal code in Shipping from section");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, LTL_OriginZipPostal_Id);
            SendKeys(attributeName_id, LTL_OriginZipPostal_Id, ShippingFrom);
        }

        [When(@"I have entered valid zipcode (.*) in Shipping To section")]
        public void WhenIHaveEnteredValidZipcodeInShippingToSection(string ShippingTo)
        {
            Report.WriteLine("Entering Zip/postal code in Shipping To section");
            Click(attributeName_id, LTL_DestinationZipPostal_Id);
            SendKeys(attributeName_id, LTL_DestinationZipPostal_Id, ShippingTo);
        }

        [When(@"I enter valid data (.*), (.*) in Freight Description Section")]
        public void WhenIEnterValidDataInFreightDescriptionSection(string Classification, string Weight)
        {
            Report.WriteLine("Enter details in Freight Description section");
            Click(attributeName_id, LTL_Weight_Id);
            Click(attributeName_id, LTL_Classification_Id);
            Thread.Sleep(1000);

            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(LTL_ClassificationValues_Xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == Classification)
                {
                    DropDownList[i].Click();
                    break;
                }
            }
            Click(attributeName_id, LTL_Weight_Id);
            SendKeys(attributeName_id, LTL_Weight_Id, Weight);
        }

        [When(@"I Click on View Quote Results button")]
        public void WhenIClickOnViewQuoteResultsButton()
        {
            Report.WriteLine("Click on Quote Results");
            try
            {
                Click(attributeName_id, LTL_ViewQuoteResults_Id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Thread.Sleep(5000);
            WaitForElementPresent(attributeName_xpath, ltlQuoteResultsheader_xpath, "waitforheader");
        }

        [When(@"I Select Canada from Shipping From Country dropdown")]
        public void WhenISelectCanadaFromShippingFromCountryDropdown()
        {
            Report.WriteLine("Selecting Country as Canada from ShippingFrom section");
            Click(attributeName_xpath, LTL_OriginCountryDropdown_Xpath);
            Click(attributeName_xpath, LTL_OriginCanadaCountryDropdown_Xpath); 
        }

        [When(@"I enter valid data in Shipping From section (.*), (.*) and (.*)")]
        public void WhenIEnterValidDataInShippingFromSectionAnd(string ShippingFromPostal, string ShippingFromCity, string ShippingFromProvince)
        {
            Report.WriteLine("Entering data in ShippingFrom section");
            SendKeys(attributeName_id, LTL_OriginCity_Id, ShippingFromCity);
            Click(attributeName_id, LTL_OriginStateProvince_Id);
            SelectDropdownValueFromList(attributeName_xpath, LTL_OriginStateProvinceValues_Xpath, ShippingFromProvince);
            SendKeys(attributeName_id, LTL_OriginZipPostal_Id, ShippingFromPostal);
        }

        [When(@"I Select Canada from Shipping To Country dropdown")]
        public void WhenISelectCanadaFromShippingToCountryDropdown()
        {
            Report.WriteLine("Selecting Country as Canada from ShippingTo section");
            Click(attributeName_id, LTL_DestinationCountryDropdown_Id);
            Click(attributeName_xpath, LTL_DestinationCanadaCountryDropdown_Xpath);
        }

        [When(@"I enter valid data in Shipping To section (.*), (.*) and (.*)")]
        public void WhenIEnterValidDataInShippingToSectionAnd(string ShippingToPostal, string ShippingToCity, string ShippingToProvince)
        {
            Report.WriteLine("Entering data in ShippingTo section");
            SendKeys(attributeName_id, LTL_DestinationCity_Id, ShippingToCity);
            Click(attributeName_id, LTL_DestinationStateProvince_Id);
            SelectDropdownValueFromList(attributeName_xpath, LTL_DestinationStateProvinceValues_Xpath, ShippingToProvince);
            SendKeys(attributeName_id, LTL_DestinationZipPostal_Id, ShippingToPostal);
        }

        [Then(@"I should be navigated to Quote Results Page displayed with rates")]
        public void ThenIShouldBeNavigatedToQuoteResultsPageDisplayedWithRates()
        {
            Report.WriteLine("Quote Results page displayed with rates");
            WaitForElementVisible(attributeName_xpath, ltlQuoteResultsheader_xpath, "Quote Results (LTL)");
            VerifyElementVisible(attributeName_id, QuoteResults_customerName_Id, "customerName");
        }

        //[Then(@"Compare the Rate Results Grid with API")]
        //public void ThenCompareTheRateResultsGridWithAPI()
        //{
        //    Report.WriteLine("Compare the Rate Results Grid with API");
        //    List<RateResultCarrierViewModel> apirespone = GetRatesAndCarriersUsingAPI.CallRateRequestApi("ZZZ Sandbox DLS Worldwide", "LTL", "CHICAGO", "60606", "IL", "USA", "LOS ANGELES", "60606", "CA", "USA",
        //                                              "50", 1, "SKD", 4, "lbs", "zzz@test.com");

        //    List<string> carrierNames = apirespone.Select(p => p.CarrierName).ToList();
        //    int APICount = carrierNames.Count;
        //}

        [Then(@"I should be navigated to Quote Results Page displayed with no rates")]
        public void ThenIShouldBeNavigatedToQuoteResultsPageDisplayedWithNoRates()
        {
            Report.WriteLine("Quote Results page displayed with no rates");            
            WaitForElementVisible(attributeName_xpath, ltlnorateresultsheader_xpath, "No rate results page");
            VerifyElementVisible(attributeName_id, QuoteResults_customerName_Id, "customerName");
        }
    }
}
