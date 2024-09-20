using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.TL_Rating_Tool.Get_Quote__TL_.Insured_Value
{
    [Binding]
    public class TruckloadRatingPage_GetQuoteTL_InsuredValueSteps: TruckloadRatingTool
    {
        [When(@"I enter data in (.*) field of Get Quote TL")]
        public void WhenIEnterDataInFieldOfGetQuoteTL(string InsuredValue)
        {
            Report.WriteLine("Entering data in Enter Insured value text box");
            SendKeys(attributeName_id, TL_EnterInsuredValue_Id, InsuredValue);
        }

        [When(@"I enter more than maximun value in (.*) field of Get Quote TL")]
        public void WhenIEnterMoreThanMaximumValueInFieldOfGetQuoteTL(string InsuredValue)
        {
            Report.WriteLine("Entering >100000 in Enter Insured value text box");
            SendKeys(attributeName_id, TL_EnterInsuredValue_Id, InsuredValue);
        }

        [When(@"I enter zero in (.*) field of Get Quote TL")]
        public void WhenIEnterZeroInFieldOfGetQuoteTL(string InsuredValue)
        {
            Report.WriteLine("Entering 0 in Enter Insured value text box");
            SendKeys(attributeName_id, TL_EnterInsuredValue_Id, InsuredValue);
        }

        [Then(@"I should be able to enter decimal values in (.*) textbox")]
        public void ThenIShouldBeAbleToEnterDecimalValuesInTextbox(string InsuredValue)
        {
            Report.WriteLine("Insured Value Text box should accept decimal values");
            SendKeys(attributeName_id, TL_EnterInsuredValue_Id, InsuredValue);
            Thread.Sleep(1000);
        }

        [Then(@"I click on weight text box")]
        public void ThenIClickOnWeightTextBox()
        {
            Report.WriteLine("Click on Weight Text box");
            Click(attributeName_id, TLweight_id);
        }
        
        [Then(@"I must be displayed with (.*) in decimals")]
        public void ThenIMustBeDisplayedWithInDecimals(string InsuredValue)
        {
            Report.WriteLine("Decimal values should be displayed in Insured value field");
            string insuredvalue_UI=Gettext(attributeName_id, TL_EnterInsuredValue_Id);
            string insuredvalue_exp = "$" + InsuredValue + ".00";
            Assert.AreEqual(insuredvalue_exp, insuredvalue_UI);
        }
        
        [Then(@"Error message should be displayed for entering more than the limit of insured value")]
        public void ThenErrorMessageShouldBeDisplayedForEnteringMoreThanTheLimitOfInsuredValue()
        {
            Report.WriteLine("Error message should be displayed when entering more than maximum insured value");
            VerifyElementVisible(attributeName_xpath, TL_Maxinsval_Errorheader_xpath, "ERROR");
            Thread.Sleep(2000);
            string ActualError=Gettext(attributeName_xpath, TL_MaxInsuredValue_Error_Xpath);
            string ExpectedError = "The entered shipment value exceeds $100,000. Please contact your RR Donnelley representatives.";            
            Assert.AreEqual(ExpectedError, ActualError);
        }
        
        [Then(@"Error message should be displayed for entering zero insured value")]
        public void ThenErrorMessageShouldBeDisplayedForEnteringZeroInsuredValue()
        {
            string ActualError = Gettext(attributeName_xpath, "TL_MinInsuredValue_Error_Xpath");
            string ExpectedError = "";
            Assert.AreEqual(ExpectedError, ActualError);
        }
        
        [Then(@"I must be able to see the tool tip (.*) when mouse hover on Question mark of Get Quote TL")]
        public void ThenIMustBeAbleToSeeTheToolTipWhenMouseHoverOnQuestionMarkOfGetQuoteTL(string Message)
        {
            Report.WriteLine("Verifying tool tip when mousehover on the Question mark icon");
            VerifyElementPresent(attributeName_xpath, TL_tooltipicon_xpath, "tooltip");
            OnMouseOver(attributeName_xpath, TL_tooltipiconmsg_xpath);
            var TooltipMessage_UI = GetAttribute(attributeName_xpath, TL_tooltipiconmsg_xpath, "data-title");
            Assert.AreEqual(Message, TooltipMessage_UI);
        }

        [Then(@"(.*) text box zero should not be visible")]
        public void ThenTextBoxZeroShouldNotBeVisible(string InsuredValue)
        {
            string Actualval = Gettext(attributeName_id, TL_EnterInsuredValue_Id);
            Assert.AreNotEqual(InsuredValue, Actualval);
        }        
    }
}
