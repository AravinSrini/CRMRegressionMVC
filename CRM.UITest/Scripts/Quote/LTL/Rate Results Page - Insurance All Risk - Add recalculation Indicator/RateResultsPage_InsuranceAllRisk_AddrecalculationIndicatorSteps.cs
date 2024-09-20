using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
//comment

namespace CRM.UITest
{
    [Binding]
    public class RateResultsPage_InsuranceAllRisk_AddrecalculationIndicatorSteps : Quotelist
    {
        
        [Given(@"I am on the quote results \(LTL\) page")]
        public void GivenIAmOnTheQuoteResultsLTLPage()
        {
            ClickAndWaitMethods clickndwait = new ClickAndWaitMethods();
            clickndwait.ClickAndWait(attributeName_xpath, QuoteIconModule_Xpath);
                     
            Report.WriteLine("Selecting a Customer from dropdown list");
            clickndwait.ClickAndWait(attributeName_xpath, CustomerDropdownExtuser_Xpath);            
            SelectDropdownValueFromList(attributeName_xpath, CustomerDropdownValesExtuser_Xpath, "ZZZ - Czar Customer Test");
            clickndwait.ClickAndWait(attributeName_xpath, QuoteList_SubmitQuote_Button_Xpath);
            clickndwait.ClickAndWait(attributeName_xpath, GetQuote_LtlButton_Xpath);
            clickndwait.ClickAndWait(attributeName_id, GetQuote_ViewQuoteResult_Button_Id);
            
        }

      //  private void ClickAndWait(string param1, string param2)
        //{
          //  Click(param1, param2);
            //GlobalVariables.webDriver.WaitForPageLoad();
        //}

        [Given(@"I have a value in the insured Value field")]
        public void GivenIHaveAValueInTheInsuredValueField()
        {
            SendKeys(attributeName_id, QuoteResults_ShipmentValue_Id, "100");
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [When(@"I clicked on the show Insured rate button")]
        public void WhenIClickedOnTheShowInsuredRateButton()
        {
            Click(attributeName_id, QuoteResults_ShowInsuredRatesButton_Id);
        }

        [Then(@"I will see an Indicator that CRM is updating the results\.")]
        public void ThenIWillSeeAnIndicatorThatCRMIsUpdatingTheResults_()
        {
            WaitForElementVisible(attributeName_xpath, InsuredRateLoadingIcon_Xpath, "Loading Icon");
            VerifyElementVisible(attributeName_xpath, InsuredRateLoadingIcon_Xpath, "Loading Icon");
        }
    }
}
