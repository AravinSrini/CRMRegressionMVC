using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRM.UITest.CommonMethods;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Linq;
using TechTalk.SpecFlow;
using System.Threading;

namespace CRM.UITest.Scripts.Insurance_Claims
{
    [Binding]
    public class InsuranceClaims_ClaimForm_FreightChargesUpdateSteps : CRM.UITest.Objects.InsuranceClaim
    {
        [Then(@"the Original Freight Charges will become active")]
        public void ThenTheOriginalFreightChargesWillBecomeActive()
        {
            VerifyElementEnabled(attributeName_classname, OriginFreightChargeOptionField_Class, "Original Freight Charges Textbox");
        }

        [Then(@"the Return Freight Charges will become active")]
        public void ThenTheReturnFreightChargesWillBecomeActive()
        {
            VerifyElementEnabled(attributeName_id, "btn-returnFreightchargesReturnFreightCharges", "Return  Freight Checkbox");
        }

        [Then(@"the Replacement Freight Charges will become active")]
        public void ThenTheReplacementFreightChargesWillBecomeActive()
        {
            VerifyElementEnabled(attributeName_id, "btn-replacementFreightchargesReplacementFreightCharges", "Replacement Freight checknbox");
        }


        [Then(@"the Original Freight Charges option will be auto-selected")]
        public void ThenTheOriginalFreightChargesOptionWillBeAuto_Selected()
        {
            VerifyElementChecked(attributeName_id, "btn-OriginalFreightchargesOriginalFreightCharges", "Original Freight Checkbox");
        }

        [Then(@"the Original Freight Charges check box is inactive")]
        public void ThenTheOriginalFreightChargesCheckBoxIsInactive()
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)GlobalVariables.webDriver;
            executor.ExecuteScript("$('#btn-OriginalFreightchargesOriginalFreightCharges').click();");
            VerifyElementChecked(attributeName_id, "btn-OriginalFreightchargesOriginalFreightCharges", "Original Freight Checkbox");
        }

        [Then(@"I have the option to select Return Freight Charges")]
        public void ThenIHaveTheOptionToSelectReturnFreightCharges()
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)GlobalVariables.webDriver;
            executor.ExecuteScript("$('#btn-returnFreightchargesReturnFreightCharges').click();");
        }

        [Then(@"I have the option to select Replacement Freight Charges")]
        public void ThenIHaveTheOptionToSelectReplacementFreightCharges()
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)GlobalVariables.webDriver;
            executor.ExecuteScript("$('#btn-replacementFreightchargesReplacementFreightCharges').click();");
        }

        [Then(@"the (.*) Value and DLSW Ref \# fields become active")]
        public void ThenTheValueAndDLSWRefFieldsBecomeActive(string freightCharges)
        {
            if (freightCharges == "Return Freight Charges")
            {
                VerifyElementEnabled(attributeName_classname, ReturnFreightVal_Class, "Return Freight Charges field");
            }
            else if (freightCharges == "Replacement Freight Charges")
            {
                VerifyElementEnabled(attributeName_classname, ReplaceFreightVal_Class, "Replacement Freight Charges field");
            }
        }


        [Then(@"I am required to enter a DLSW Ref \# for the (.*)")]
        public void ThenIAmRequiredToEnterADLSWRefForThe(string freightCharges)
        {
            if (freightCharges == "Return Freight Charges")
            {
                string actualReturnFreightChargesDLSWFieldCSSValue = GetCSSValue(attributeName_id, "dlswreturnbol", "background-color");
                string expectedReturnFreightChargesDLSWFieldCSSValue = "rgba(251, 236, 237, 1)";
                Assert.AreEqual(expectedReturnFreightChargesDLSWFieldCSSValue, actualReturnFreightChargesDLSWFieldCSSValue);
                SendKeys(attributeName_id, "dlswreturnbol", "23");
            }
            else if (freightCharges == "Replacement Freight Charges")
            {
                string actualReplacementFreightChargesDLSWFieldCSSValue = GetCSSValue(attributeName_id, "dlswreplacementbol", "background-color");
                string expectedReplacementFreightChargesDLSWFieldCSSValue = "rgba(251, 236, 237, 1)";
                Assert.AreEqual(expectedReplacementFreightChargesDLSWFieldCSSValue, actualReplacementFreightChargesDLSWFieldCSSValue);
                SendKeys(attributeName_id, "dlswreplacementbol", "23");
            }
        }


        [When(@"I check the (.*) option")]
        public void WhenICheckTheOption(string freightCharges)
        {
            if (freightCharges == "Return Freight Charges")
            {
                IJavaScriptExecutor executor = (IJavaScriptExecutor)GlobalVariables.webDriver;
                executor.ExecuteScript("$('#btn-returnFreightchargesReturnFreightCharges').click();");
            }
            else if (freightCharges == "Replacement Freight Charges")
            {
                IJavaScriptExecutor executor = (IJavaScriptExecutor)GlobalVariables.webDriver;
                executor.ExecuteScript("$('#btn-replacementFreightchargesReplacementFreightCharges').click();");
            }
        }

        [Then(@"the (.*) Value and DLSW Ref \# fields becomes disabled")]
        public void ThenTheValueAndDLSWRefFieldsBecomesDisabled(string freightCharges)
        {
            if (freightCharges == "Return Freight Charges")
            {
                VerifyElementNotEnabled(attributeName_classname, ReturnFreightVal_Class, "Return Freight Charges Value field");
                VerifyElementNotEnabled(attributeName_id, "dlswreturnbol", "Return Freight Charges DLSW Ref field");
            }
            else if (freightCharges == "Replacement Freight Charges")
            {
                VerifyElementNotEnabled(attributeName_classname, ReplaceFreightVal_Class, "Replacement Freight Charges Value field");
                VerifyElementNotEnabled(attributeName_id, "dlswreplacementbol", "Replacement Freight Charges DLSW Ref field");
            }
        }

        [Given(@"I check the (.*) option")]
        public void GivenICheckTheOption(string freightCharges)
        {
            WhenICheckTheOption(freightCharges);
        }

        [When(@"I select No for the Do you wish to add freight charges option")]
        public void WhenISelectNoForTheDoYouWishToAddFreightChargesOption()
        {
            Click(attributeName_xpath, FreightChargeYes_Xpath);
            Click(attributeName_xpath, FreightChargeNo_Xpath);
        }

        [Then(@"the Freight Charges field sections will be hidden")]
        public void ThenTheFreightChargesFieldSectionsWillBeHidden()
        {
            Thread.Sleep(2000);
            bool freightChargesSection = GlobalVariables.webDriver.FindElement(By.Id("dlswreturnbol")).Displayed;
            Assert.IsFalse(freightChargesSection);
        }

        [When(@"I Select Yes for the (.*) question")]
        public void WhenISelectYesForTheQuestion(string p0)
        {
            scrollElementIntoView(attributeName_id, "DescriptionofClaimedArticles");
            Click(attributeName_xpath, FreightChargeYes_Xpath);
        }


        [When(@"I Select No for the (.*) question")]
        public void WhenISelectNoForTheQuestion(string p0)
        {
            WhenISelectYesForTheQuestion(p0);
            Click(attributeName_xpath, FreightChargeNo_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
        }


        [Given(@"I select Yes for the (.*) question")]
        public void GivenISelectYesForTheQuestion(string p0)
        {
            WhenISelectYesForTheQuestion(p0);
        }

        [Then(@"I am required to enter a value in the Value field of the (.*)option")]
        public void ThenIAmRequiredToEnterAValueInTheValueFieldOfTheOption(string freightCharges)
        {
            switch (freightCharges)
            {
                case "Original Freight Charges":
                    {
                        //scrollpagedown();
                        //scrollpagedown();
                        scrollElementIntoView(attributeName_id, "AccuracyVerbiage");
                        Click(attributeName_id, SubmitClaimButton_Id);
                        scrollElementIntoView(attributeName_id, "DescriptionofClaimedArticles");

                        string actualOriginalFreightChargesFieldCSSValue = GetCSSValue(attributeName_classname, OriginFreightChargeOptionField_Class, "background-color");
                        string expectedOriginalFreightChargesFieldCSSValue = "rgba(251, 236, 237, 1)";
                        Assert.AreEqual(expectedOriginalFreightChargesFieldCSSValue, actualOriginalFreightChargesFieldCSSValue);
                        SendKeys(attributeName_classname, OriginFreightChargeOptionField_Class, "23");
                        Click(attributeName_classname, ReturnFreightVal_Class);
                        break;
                    }

                case "Return Freight Charges":
                    {
                        //scrollpagedown();
                        //scrollpagedown();
                        scrollElementIntoView(attributeName_id, "AccuracyVerbiage");
                        Click(attributeName_id, SubmitClaimButton_Id);
                        scrollElementIntoView(attributeName_id, "DescriptionofClaimedArticles");
                        string actualReturnFreightChargesFieldCSSValue = GetCSSValue(attributeName_classname, ReturnFreightVal_Class, "background-color");
                        string expectedReturnFreightChargesFieldCSSValue = "rgba(251, 236, 237, 1)";
                        Assert.AreEqual(expectedReturnFreightChargesFieldCSSValue, actualReturnFreightChargesFieldCSSValue);
                        SendKeys(attributeName_classname, ReturnFreightVal_Class, "23");
                        Click(attributeName_classname, ReplaceFreightVal_Class);
                        break;
                    }
                case "Replacement Freight Charges":
                    {
                        //scrollpagedown();
                        //scrollpagedown();
                        scrollElementIntoView(attributeName_id, "AccuracyVerbiage");
                        Click(attributeName_id, SubmitClaimButton_Id);
                        scrollElementIntoView(attributeName_id, "DescriptionofClaimedArticles");
                        string actualReplacementFreightChargesFieldCSSValue = GetCSSValue(attributeName_classname, ReplaceFreightVal_Class, "background-color");
                        string expectedReplacementFreightChargesFieldCSSValue = "rgba(251, 236, 237, 1)";
                        Assert.AreEqual(expectedReplacementFreightChargesFieldCSSValue, actualReplacementFreightChargesFieldCSSValue);
                        SendKeys(attributeName_classname, ReplaceFreightVal_Class, "23");
                        Click(attributeName_classname, ReturnFreightVal_Class);
                        break;
                    }
            }
        }

        [When(@"I uncheck (.*) option")]
        public void WhenIUncheckOption(string freightCharges)
        {
            WhenICheckTheOption(freightCharges);
        }

        [Then(@"the (.*) Value field will be currency formatted \(\$xx,xxx\.xx\)")]
        public void ThenTheValueFieldWillBeCurrencyFormattedXxXxx_Xx(string freightCharges)
        {
            if (freightCharges == "Return Freight Charges")
            {
                string returnFreightChargesValue = GetValue(attributeName_classname, ReturnFreightVal_Class, "value");
                string[] enteredValue_withdeciaml = returnFreightChargesValue.Split('.');
                string checking_TwoDeciaml_Places = enteredValue_withdeciaml[1].ToString();
                int checking_TwoDecial_Places_Count = checking_TwoDeciaml_Places.Count();
                string checkForTwoZero = checking_TwoDeciaml_Places.Substring(0, 2);
                Assert.AreEqual("00", checkForTwoZero);

                Report.WriteLine("Verifying Currency Format and its prefixed before the Return Freight Charges Value");
                string currencyBeforeClaimedFreightValue = returnFreightChargesValue.Substring(0, 1);
                Assert.AreEqual("$", currencyBeforeClaimedFreightValue);
            }
            else if (freightCharges == "Replacement Freight Charges")
            {
                string replacementFreightChargesValue = GetValue(attributeName_classname, ReplaceFreightVal_Class, "value");
                string[] enteredValue_withdeciaml = replacementFreightChargesValue.Split('.');
                string checking_TwoDeciaml_Places = enteredValue_withdeciaml[1].ToString();
                int checking_TwoDecial_Places_Count = checking_TwoDeciaml_Places.Count();
                string checkForTwoZero = checking_TwoDeciaml_Places.Substring(0, 2);
                Assert.AreEqual("00", checkForTwoZero);

                Report.WriteLine("Verifying Currency Format and its prefixed before the Replacement Freight Charges Value");
                string currencyBeforeClaimedFreightValue = replacementFreightChargesValue.Substring(0, 1);
                Assert.AreEqual("$", currencyBeforeClaimedFreightValue);
            }
        }

        [Then(@"the Value field will be currency formatted \(\$xx,xxx\.xx\)")]
        public void ThenTheValueFieldWillBeCurrencyFormattedXxXxx_Xx()
        {
            SendKeys(attributeName_classname, OriginFreightChargeOptionField_Class, "23");
            Click(attributeName_classname, ReturnFreightVal_Class);

            string originalFreightChargesValue = GetValue(attributeName_classname, OriginFreightChargeOptionField_Class, "value");
            string[] enteredValue_withdeciaml = originalFreightChargesValue.Split('.');
            string checking_TwoDeciaml_Places = enteredValue_withdeciaml[1].ToString();
            int checking_TwoDecial_Places_Count = checking_TwoDeciaml_Places.Count();
            string checkForTwoZero = checking_TwoDeciaml_Places.Substring(0, 2);
            Assert.AreEqual("00", checkForTwoZero);

            Report.WriteLine("Verifying Currency Format and its prefixed before the original Freight Charges Value");
            string currencyBeforeClaimedFreightValue = originalFreightChargesValue.Substring(0, 1);
            Assert.AreEqual("$", currencyBeforeClaimedFreightValue);
        }

        [Given(@"the (.*) Value and DLSW Ref \# fields become active")]
        public void GivenTheValueAndDLSWRefFieldsBecomeActive(string freightCharges)
        {
            ThenTheValueAndDLSWRefFieldsBecomeActive(freightCharges);
        }
    }
}
