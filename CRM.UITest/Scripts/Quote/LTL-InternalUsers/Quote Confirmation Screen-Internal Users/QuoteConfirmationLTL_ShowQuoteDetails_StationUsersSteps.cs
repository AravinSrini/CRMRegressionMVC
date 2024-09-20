using System;
using TechTalk.SpecFlow;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Collections.Generic;
using System.IO;
using System.Data;
using CRM.UITest.CommonMethods;

namespace CRM.UITest.Scripts.Quote.LTL_InternalUsers.Quote_Confirmation_Screen_Internal_Users
{
    [Binding]
    public class QuoteConfirmationLTL_ShowQuoteDetails_StationUsersSteps : ObjectRepository
    {
        [Then(@"I will see Quote Amount section")]
        public void ThenIWillSeeQuoteAmountSection()
        {
            Report.WriteLine("DisplayedQuoteAmountSection");
            VerifyElementPresent(attributeName_xpath, LTL_QC_QuoteAmountSection, "QuoteAmountSection");
        }

        [Then(@"I should be displayed with quote amount")]
        public void ThenIShouldBeDisplayedWithQuoteAmount()
        {
            Report.WriteLine("DisplayedQuoteAmount");
            VerifyElementPresent(attributeName_xpath, LTL_QC_QuoteAmount, "ThenIWillSeeQuoteAmountSection");
        }

        [Then(@"I should be displayed with Est Cost")]
        public void ThenIShouldBeDisplayedWithEstCost()
        {
            Report.WriteLine("DisplayedEst Cost");
            VerifyElementPresent(attributeName_xpath, LTL_QC_EstCost, "EstCost");
        }

        [Then(@"I should be displayed with Est Margin")]
        public void ThenIShouldBeDisplayedWithEstMargin()
        {
            Report.WriteLine("DisplayedEst Cost");
            VerifyElementPresent(attributeName_xpath, LTL_QC_EstMargin, "EstMargin");
        }

        [Then(@"I should disply the quote amount,Est Cost,Est margin values in confirmation page on saving the rate on results page")]
        public void ThenIShouldDisplyTheQuoteAmountEstCostEstMarginValuesInConfirmationPageOnSavingTheRateOnResultsPage()
        {
            Report.WriteLine("quote amount,Est Cost,Est margin values in confirmation page on saving the rate on results page");
            string expEstCost0 = Gettext(attributeName_xpath, QuoteResults_EstCost_FirstCarriervaluec_xpath);
            string[] expEstCost1 = expEstCost0.Split('$');
            string expEstCost = expEstCost1[1];
            string expEstMargin0 = Gettext(attributeName_xpath, QuoteResults_EstMargin_FirstCarriervaluec_xpath);
            string[] expEstMargin1 = expEstMargin0.Split(' ', '%');
            string expEstMargin = expEstMargin1[4];
            string configURL = launchUrl;
            string resultPagrURL = configURL + "Rate/LtlResultsView";
            if (GetURL() == resultPagrURL)
            {
                Click(attributeName_xpath, ltlsaverateasquotelnkint_xpath);
            }
            else
            {
                Console.WriteLine("Rate Results are not available for the given information");
                Click(attributeName_xpath, ltlsavequotenorateslink_xpath);
            }
            Report.WriteLine("Verify the LTL quote Confirmation header");
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, LTL_QuoteConfirmationPageHeader_Xpath, "confirmpage");
            Report.WriteLine("Verify Show Quote Details link functionality on Confirmation page");
            Click(attributeName_id, LTL_QC_ShowQuoteDetails_Id);
            VerifyElementPresent(attributeName_xpath, LTL_QC_QuoteAmountSection, "QuoteAmountSection");
            string actEstCost0 = Gettext(attributeName_xpath, LTL_QC_EstCost);
            string[] actEstCost1 = expEstCost0.Split(' ', '$');
            string actEstCost = actEstCost1[2];
            string actEstMargin0 = Gettext(attributeName_xpath, LTL_QC_EstMargin);
            string[] actEstMargin1 = actEstMargin0.Split(' ', '%');
            string actEstMargin = actEstMargin1[3];
            Assert.AreEqual(expEstCost, actEstCost);
            Assert.AreEqual(expEstMargin, actEstMargin);
        }

        [Then(@"I should disply the quote amount,Est Cost,Est margin values in confirmation page on saving the guaranteed rates on results page")]
        public void ThenIShouldDisplyTheQuoteAmountEstCostEstMarginValuesInConfirmationPageOnSavingTheGuaranteedRatesOnResultsPage()
        {
            Report.WriteLine("quote amount,Est Cost,Est margin values in confirmation page on saving the rate on results page");
            string expEstCost0 = Gettext(attributeName_xpath, QuoteResults_EstCost_FirstCarriervalue_G_xpath);
            string[] expEstCost1 = expEstCost0.Split('$');
            string expEstCost = expEstCost1[1];
            string expEstMargin0 = Gettext(attributeName_xpath, QuoteResults_EstMargin_FirstCarriervalue_G_xpath);
            string[] expEstMargin1 = expEstMargin0.Split(' ', '%');
            string expEstMargin = expEstMargin1[4];
            string configURL = launchUrl;
            string resultPagrURL = configURL + "Rate/LtlResultsView";
            if (GetURL() == resultPagrURL)
            {
                Click(attributeName_xpath, saverateasquoteGuaranteedint_xpath);
            }
            else
            {
                Console.WriteLine("Rate Results are not available for the given information");
                Click(attributeName_xpath, ltlsavequotenorateslink_xpath);
            }
            Report.WriteLine("Verify the LTL quote Confirmation header");
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, LTL_QuoteConfirmationPageHeader_Xpath, "confirmpage");
            Report.WriteLine("Verify Show Quote Details link functionality on Confirmation page");
            Click(attributeName_id, LTL_QC_ShowQuoteDetails_Id);
            VerifyElementPresent(attributeName_xpath, LTL_QC_QuoteAmountSection, "QuoteAmountSection");
            string actEstCost0 = Gettext(attributeName_xpath, LTL_QC_EstCost);
            string[] actEstCost1 = expEstCost0.Split(' ', '$');
            string actEstCost = actEstCost1[2];
            string actEstMargin0 = Gettext(attributeName_xpath, LTL_QC_EstMargin);
            string[] actEstMargin1 = actEstMargin0.Split(' ', '%');
            string actEstMargin = actEstMargin1[3];

            Assert.AreEqual(expEstCost, actEstCost);
            Assert.AreEqual(expEstMargin, actEstMargin);
        }
    }
}