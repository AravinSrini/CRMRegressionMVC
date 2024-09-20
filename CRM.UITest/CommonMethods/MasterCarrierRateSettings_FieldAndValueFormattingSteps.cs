using System.Collections.Generic;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using TechTalk.SpecFlow;

namespace CRM.UITest
{
    [Binding]
    public class MasterCarrierRateSettings_FieldAndValueFormattingSteps : MaintenaceTools
    {
        public WebElementOperations objWebElementOperations = new WebElementOperations();

        [Then(@"the value type for the Surge field in the grid will be defaulted to Percentage with (.*) decimal places")]
        public void ThenTheValueTypeForTheSurgeFieldInTheGridWillBeDefaultedToPercentageWithDecimalPlaces(int p0)
        {
            IList<IWebElement> SurgevaluesUI = GlobalVariables.webDriver.FindElements(By.XPath(Surge_ColumnValues_Xpath));
            List<string> SurgeListValues = objWebElementOperations.GetListFromIWebElement(SurgevaluesUI);

            for (int i = 0; i < SurgeListValues.Count; i++)
            {
                if (SurgeListValues[i].ToLower() == "none")
                {
                    Report.WriteLine("Surge value is not displayed since it is excluded carrier");
                }
                else
                {
                    string ActualSurgeFieldValue = SurgeListValues[i];

                    //Get last character
                    char lastChar = ActualSurgeFieldValue[ActualSurgeFieldValue.Length - 1];
                    
                    //Verify Percentage Symbol
                    Report.WriteLine("Verification of percentage symbol for Surge Field value");
                    Assert.AreEqual('%', lastChar);

                    //Get value after decimal 
                    string valueAfterDecimal = ActualSurgeFieldValue.Split('.')[1];
                    valueAfterDecimal = valueAfterDecimal?.Replace("%", "");

                    //Verify that the value has 2 decimal places 
                    Report.WriteLine("Verification of 2 decimal places for Surge Field value");
                    Assert.AreEqual(2, valueAfterDecimal.Length);
                }
            }
        }

        [Then(@"the value type for the Bump field in the grid will be defaulted to Percentage with (.*) decimal places")]
        public void ThenTheValueTypeForTheBumpFieldInTheGridWillBeDefaultedToPercentageWithDecimalPlaces(int p0)
        {
            IList<IWebElement> bumpValuesUI = GlobalVariables.webDriver.FindElements(By.XPath(Bump_ColumnValues_Xpath));
            List<string> bumpListValues = objWebElementOperations.GetListFromIWebElement(bumpValuesUI);

            for (int i = 0; i < bumpListValues.Count; i++)
            {
                if (bumpListValues[i].ToLower() == "none")
                {
                    Report.WriteLine("Bump value is not displayed since it is excluded carrier");
                }
                else
                {
                    string ActualBumpFieldValue = bumpListValues[i];

                    char lastChar = ActualBumpFieldValue[ActualBumpFieldValue.Length - 1];

                    //Verify Percentage Symbol                  
                    Report.WriteLine("Verification of percentage symbol for Bump Field value");
                    Assert.AreEqual('%', lastChar);

                    //Get value after decimal 
                    string valueAfterDecimal = ActualBumpFieldValue.Split('.')[1];
                    valueAfterDecimal = valueAfterDecimal?.Replace("%", "");

                    //Verify that the value has 2 decimal places 
                    Report.WriteLine("Verification of 2 decimal places for Bump Field value");
                    Assert.AreEqual(2, valueAfterDecimal.Length);
                }
            }
        }

        [Then(@"the value type for the Gainshare field in the grid will be defaulted to Percentage with (.*) decimal places")]
        public void ThenTheValueTypeForTheGainshareFieldInTheGridWillBeDefaultedToPercentageWithDecimalPlaces(int p0)
        {
            IList<IWebElement> gainshareValuesUI = GlobalVariables.webDriver.FindElements(By.XPath(Gainshare_ColumnValues_Xpath));
            List<string> listValues = objWebElementOperations.GetListFromIWebElement(gainshareValuesUI);

            for (int i = 0; i < listValues.Count; i++)
            {
                if (listValues[i].ToLower() == "none")
                {
                    Report.WriteLine("Gainshare value is not displayed since it is excluded carrier");
                }
                else
                {
                    string ActualGainshareFieldValue = listValues[i];

                    char lastChar = ActualGainshareFieldValue[ActualGainshareFieldValue.Length - 1];

                    //Verify Percentage Symbol                  
                    Report.WriteLine("Verification of Percentage symbol for Gainshare Field value");
                    Assert.AreEqual('%', lastChar);

                    //Get value after decimal 
                    string valueAfterDecimal = ActualGainshareFieldValue.Split('.')[1];
                    valueAfterDecimal = valueAfterDecimal?.Replace("%", "");

                    //Verify that the value has 2 decimal places 
                    Report.WriteLine("Verification of 2 decimal places for Gainshare Field value");
                    Assert.AreEqual(2, valueAfterDecimal.Length);
                }
            }
        }

        [Then(@"the value type for the Minimum field in the grid will be defaulted to Percentage with (.*) decimal places")]
        public void ThenTheValueTypeForTheMinimumFieldInTheGridWillBeDefaultedToPercentageWithDecimalPlaces(int p0)
        {
            IList<IWebElement> minimumValuesUI = GlobalVariables.webDriver.FindElements(By.XPath(Minimum_ColumnValues_Xpath));
            List<string> listValues = objWebElementOperations.GetListFromIWebElement(minimumValuesUI);

            for (int i = 0; i < listValues.Count; i++)
            {
                if (listValues[i].ToLower() == "none")
                {
                    Report.WriteLine("Minimum value is not displayed since it is excluded carrier");
                }
                else
                {
                    string ActualMinimumFieldValue = listValues[i];

                    char lastChar = ActualMinimumFieldValue[ActualMinimumFieldValue.Length - 1];

                    //Verify Percentage Symbol                  
                    Report.WriteLine("Verification of percentage symbol for Minimum Field value");
                    Assert.AreEqual('%', lastChar);

                    //Get value after decimal 
                    string valueAfterDecimal = ActualMinimumFieldValue.Split('.')[1];
                    valueAfterDecimal = valueAfterDecimal?.Replace("%", "");

                    //Verify that the value has 2 decimal places 
                    Report.WriteLine("Verification of 2 decimal places for Minimum Field value");
                    Assert.AreEqual(2, valueAfterDecimal.Length);
                }
            }
        }

        [Then(@"the value type for the Master Accessorial Charge field in the grid will be defaulted to Percentage with (.*) decimal places")]
        public void ThenTheValueTypeForTheMasterAccessorialChargeFieldInTheGridWillBeDefaultedToPercentageWithDecimalPlaces(int p0)
        {
            IList<IWebElement> masterAccessorialFieldValueValuesUI = GlobalVariables.webDriver.FindElements(By.XPath(MasterAccCharge_ColumnValues_Xpath));
            List<string> listValues = objWebElementOperations.GetListFromIWebElement(masterAccessorialFieldValueValuesUI);

            for (int i = 0; i < listValues.Count; i++)
            {
                if (listValues[i].ToLower() == "none")
                {
                    Report.WriteLine("MasterAccessorial value is not displayed since it is excluded carrier");
                }
                else
                {
                    string ActualMasterAccessorialFieldValue = listValues[i];

                    char lastChar = ActualMasterAccessorialFieldValue[ActualMasterAccessorialFieldValue.Length - 1];

                    //Verify Percentage Symbol                  
                    Report.WriteLine("Verification of percentage symbol for MasterAccessorialCharge Field value");
                    Assert.AreEqual('%', lastChar);

                    //Get value after decimal 
                    string valueAfterDecimal = ActualMasterAccessorialFieldValue.Split('.')[1];
                    valueAfterDecimal = valueAfterDecimal?.Replace("%", "");

                    //Verify that the value has 2 decimal places 
                    Report.WriteLine("Verification of 2 decimal places for MasterAccessorialCharge Field value");
                    Assert.AreEqual(2, valueAfterDecimal.Length);
                }
            }
        }

        [Then(@"the value for the Min Threshold field in the grid will be defaulted to dollar with (.*) decimal places")]
        public void ThenTheValueForTheMinThresholdFieldInTheGridWillBeDefaultedToDollarWithDecimalPlaces(int p0)
        {
            IList<IWebElement> minThresholdFieldValueValuesUI = GlobalVariables.webDriver.FindElements(By.XPath(MinThreshold_ColumnValues_Xpath));
            List<string> listValues = objWebElementOperations.GetListFromIWebElement(minThresholdFieldValueValuesUI);

            for (int i = 0; i < listValues.Count; i++)
            {
                if (listValues[i].ToLower() == "none")
                {
                    Report.WriteLine("MinThreshold value is not displayed since it is excluded carrier");
                }
                else
                {
                    string ActualMinThresholdFieldValue = listValues[i];

                    char firstChar = ActualMinThresholdFieldValue[0];

                    //Verify Dollar Symbol                  
                    Report.WriteLine("Verification of dollar symbol for MinThreshold Field value");
                    Assert.AreEqual('$', firstChar);

                    //Get value after decimal 
                    string valueAfterDecimal = ActualMinThresholdFieldValue.Split('.')[1];
                    valueAfterDecimal = valueAfterDecimal?.Replace("$", "");

                    //Verify that the value has 2 decimal places 
                    Report.WriteLine("Verification of 2 decimal places for MinThreshold Field value");
                    Assert.AreEqual(2, valueAfterDecimal.Length);
                }
            }
        }

        [Then(@"the value type for the Min Amount field in the grid will be defaulted to dollar with (.*) decimal places")]
        public void ThenTheValueTypeForTheMinAmountFieldInTheGridWillBeDefaultedToDollarWithDecimalPlaces(int p0)
        {
            IList<IWebElement> minAmountFieldValueValuesUI = GlobalVariables.webDriver.FindElements(By.XPath(MinAmount_ColumnValues_Xpath));
            List<string> listValues = objWebElementOperations.GetListFromIWebElement(minAmountFieldValueValuesUI);

            for (int i = 0; i < listValues.Count; i++)
            {
                if (listValues[i].ToLower() == "none")
                {
                    Report.WriteLine("MinAmount value is not displayed since it is excluded carrier");
                }
                else
                {
                    string ActualMinAmountFieldValue = listValues[i];

                    char firstChar = ActualMinAmountFieldValue[0];

                    //Verify Dollar Symbol               
                    Report.WriteLine("Verification of Dollar symbol for MinAmount Field value");
                    Assert.AreEqual('$', firstChar);

                    //Get value after decimal 
                    string valueAfterDecimal = ActualMinAmountFieldValue.Split('.')[1];
                    valueAfterDecimal = valueAfterDecimal?.Replace("$", "");

                    //Verify that the value has 2 decimal places 
                    Report.WriteLine("Verification of 2 decimal places for MinAmount Field value");
                    Assert.AreEqual(2, valueAfterDecimal.Length);
                }
            }
        }
    }
}
