using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;

namespace CRM.UITest.Scripts.Maintenance_Tools.Master_Carrier_Rate_Settings
{
    [Binding]
    public class MasterCarrierRateSettings_GainshareFieldSteps : MaintenaceTools
    {
        CommonMethodsCrm crm = new CommonMethodsCrm();
        public WebElementOperations ObjWebElementOperations = new WebElementOperations();

        [Then(@"I will have the option to enter a Gainshare percentage value")]
        public void ThenIWillHaveTheOptionToEnterAGainsharePercentageValue()
        {
            try
            {
                WaitForElementVisible(attributeName_id, GainhsharefieldButtonId, "Button");
                VerifyElementVisible(attributeName_id, GainhsharefieldButtonId, "Button");
                Report.WriteLine("displaying the Gainshare Percentage textbox");
                VerifyElementVisible(attributeName_id, GainhsharefieldSymbol_id, "Symbol");
                Report.WriteLine("displaying the percentage symbol for the Gainshare Percentage textbox");
            }
            catch
            {
                Report.WriteLine("Page is loading");
            }
        }

        [Then(@"Value type label will be %")]
        public void ThenValueTypeLabelWillBe()
        {
            try
            {
                VerifyElementVisible(attributeName_id, GainhsharefieldTextbox_id, "TextBox");
                Report.WriteLine("displaying the percentage symbol for the Gainshare Percentage textbox");
            }
            catch
            {
                Report.WriteLine("Page is loading");
            }
        }

        [Then(@"To the right of the Gainshare percentage value field will be a button labeled Gainshare %")]
        public void ThenToTheRightOfTheGainsharePercentageValueFieldWillBeAButtonLabeledGainshare()
        {
            try
            {
                VerifyElementVisible(attributeName_id, GainhsharefieldSymbol_id, "Button");
                Report.WriteLine("displaying the percentage symbol for the Gainshare Percentage textbox");
            }
            catch
            {
                Report.WriteLine("Page is loading");
            }
        }

        [When(@"I have entered a gainshare value in the Gainshare percentage value field (.*)")]
        public void WhenIHaveEnteredAGainshareValueInTheGainsharePercentageValueField(string gainshareVal)
        {
            SendKeys(attributeName_id, GainhsharefieldTextbox_id, gainshareVal);
            Report.WriteLine("entered the value in Gainshare percentage value field");
        }

        [When(@"I click on the Gainshare % button")]
        public void WhenIClickOnTheGainshareButton()
        {
            Report.WriteLine("Clicked on Gainshare percentage value Button");
            Click(attributeName_id, GainhsharefieldButtonId);
        }

        [Then(@"The values will be saved(.*)")]
        public void ThenTheValuesWillBeSaved(string customerName)
        {
            int pricingModelId = DBHelper.GetGainsharePricingId(customerName);
            List<InsuredRateCarrier> DBcarriers = DBHelper.GetAllCarriers();
            IList<IWebElement> carriersUI = GlobalVariables.webDriver.FindElements(By.XPath(CarrierAllValues_Xpath));
            if (carriersUI.Count > 0)
            {
                List<string> carrierListValues = new List<string>();
                foreach (IWebElement element in carriersUI)
                {
                    carrierListValues.Add((element.Text));
                }

                IList<IWebElement> UIGainshare = GlobalVariables.webDriver.FindElements(By.XPath(Gainshare_ColumnValues_Xpath));
                List<string> UIGainshareValues = new List<string>();
               
                foreach (IWebElement element in UIGainshare)
                {
                    UIGainshareValues.Add((element.Text));
                }

                for (int i = 0; i < carrierListValues.Count; i++)
                {
                    if (carrierListValues.Contains(DBcarriers[i].CarrierName))
                    {
                        GainShareScacCode value = DBHelper.GetGainshareScacByCarrierName(pricingModelId, carrierListValues[i]);

                        if (value == null)
                        {
                            GainsharePricingModel value1 = DBHelper.GetGainshareScacByCustomerlevel(pricingModelId);
                            if (UIGainshareValues[i].ToLower() != "none")
                            {
                                Assert.AreEqual(UIGainshareValues[i], value1.Percentage + "%");
                            }
                        }
                        else
                        {
                            Assert.AreEqual(UIGainshareValues[i], value.GainsharePercentage + "%");
                        }
                    }
                }
            }
        }

        [Then(@"The grid will update (.*) to display the updated values for Customers (.*)")]
        public void ThenTheGridWillUpdateToDisplayTheUpdatedValuesForCustomers(string gainshareVal, string CustomerName)
        {
            IList<IWebElement> carriersUI = GlobalVariables.webDriver.FindElements(By.XPath(CarrierAllValues_Xpath));
            if (carriersUI.Count > 0)
            {
                List<string> carrierListValues = ObjWebElementOperations.GetListFromIWebElement(carriersUI);

                IList<IWebElement> GainshareUI = GlobalVariables.webDriver.FindElements(By.XPath(Gainshare_ColumnValues_Xpath));
                List<string> GainshareListValues = ObjWebElementOperations.GetListFromIWebElement(GainshareUI);
                int pricingModelId = DBHelper.GetGainsharePricingId(CustomerName);
                int setupId = DBHelper.GetCustomerSetupId(CustomerName);
                int customerId = DBHelper.GetCustomerAccountId(setupId);
                GainsharePricingModel gainsharePricingModel = DBHelper.GetGainsharePricingDataByAID(customerId);

                for (int i = 0; i < carrierListValues.Count; i++)
                {
                   
                    GainShareScacCode gainshareModel = DBHelper.GetGainshareScacByCarrierName(pricingModelId, carrierListValues[i]);

                    if (gainshareModel!=null && Convert.ToDouble(gainshareModel?.GainsharePercentage) >= 0)
                    {
                        if (Convert.ToString(gainshareModel.GainsharePercentage).Equals(gainshareVal))
                        {
                            Report.WriteLine("Gainshare Percentage value is saved in Database");
                            Assert.AreEqual(Convert.ToString(gainshareModel.GainsharePercentage) + "%", GainshareListValues[i]);
                            Report.WriteLine("Gainshare Percentage value is displayed in Master carrier rate settings page");
                        }
                        if (Convert.ToString(gainshareModel.GainsharePercentage + "%").Equals(GainshareListValues[i]))
                        {
                            Report.WriteLine("Gainshare Percentage value is saved in Database");
                            Assert.AreEqual(Convert.ToString(gainshareModel.GainsharePercentage) + "%", GainshareListValues[i]);
                            Report.WriteLine("Gainshare Percentage value is displayed in Master carrier rate settings page");
                        }
                        else
                        {
                            Report.WriteFailure("The entered Gainshare Percentage values does not match with the database value");
                            Assert.Fail();
                        }

                    }
                    else if(gainsharePricingModel != null && Convert.ToString(gainsharePricingModel.Percentage + "%").Equals(GainshareListValues[i]))
                    {
                            Report.WriteLine("Gainshare Percentage value is saved in Database");
                            Assert.AreEqual(Convert.ToString(gainsharePricingModel.Percentage) + "%", GainshareListValues[i]);
                            Report.WriteLine("Entered Gainshare Percentage value is displayed in Master carrier rate settings page");
                    }                   
                    else if (Convert.ToDouble(gainsharePricingModel?.Percentage) == 0)
                    {
                        IsElementDisabled(attributeName_xpath, CarrierAllValues_Xpath, carrierListValues[i]);
                        Report.WriteLine("Gainshare Percentage value is not updated since its excluded carrier");
                    }
                    else
                    {
                        Report.WriteFailure("The entered Gainshare Percentage values does not match with the database value");
                        Assert.Fail();
                    }
                }
            }
            else
            {
                Report.WriteLine("No Carriers Found");
            }
        }

        [When(@"I click the Gainshare % button to save the values")]
        public void WhenIClickTheGainshareButtonToSaveTheValues()
        {
            Report.WriteLine("Clicked on Gainshare Percentage field to save");
            Click(attributeName_id, GainhsharefieldButtonId);
        }


        [Then(@"The Gainshare field of the selected carrier\(s\) will be formatted as percentage (.*)")]
        public void ThenTheGainshareFieldOfTheSelectedCarrierSWillBeFormattedAsPercentage(int gainshareVal)
        {
            List<string> GridColumnNames = IndividualColumnData(".//*[@id='CustomerTable']/thead/tr/th");
            for (int i = 1; i <= GridColumnNames.Count; i++)
            {
                string ColumnNameValue = Gettext(attributeName_xpath, ".//*[@id='CustomerTable']/thead/tr/th[5]");
                if (ColumnNameValue == "GAINSHARE")
                {
                    string CarrierColumn = Gettext(attributeName_xpath, ".//*[@id='CustomerTable']/thead/tr/th[2]");
                    if (CarrierColumn == "CARRIER")
                    {
                        List<string> CarrierCount = IndividualColumnData(".//*[@id='CustomerTable']/tbody/tr");
                        string CarrierName = Gettext(attributeName_xpath, ".//*[@id='CustomerTable']/tbody/tr[" + 1 + "]/td[2]");
                        if (CarrierName == "A&B Freight Line Inc" | CarrierName == "AAA Cooper Transportation" | CarrierName == "Averitt Express")
                        {
                            string SetGainshareValue = Gettext(attributeName_xpath, ".//*[@id='CustomerTable']/tbody/tr[" + 1 + "]/td[5]");
                            Assert.AreEqual(SetGainshareValue, Convert.ToDecimal(gainshareVal.ToString()).ToString("F") + '%');
                            Report.WriteLine("Gainshare Percentage values updated for the selected carriers");
                            break;
                        }
                        else
                        {
                            Report.WriteLine("Added Gainshare Percentage value " + gainshareVal + " not matches with the column[" + i + "] in the Grid");
                            Assert.IsTrue(true);
                        }
                    }
                }
            }
        }

        [Then(@"Each value will have (.*) decimal places")]
        public void ThenEachValueWillHaveDecimalPlaces(int p0)
        {
            List<string> GridColumnNames = IndividualColumnData(".//*[@id='CustomerTable']/thead/tr/th");
            for (int i = 1; i <= GridColumnNames.Count; i++)
            {
                string ColumnNameValue = Gettext(attributeName_xpath, ".//*[@id='CustomerTable']/thead/tr/th[5]");
                if (ColumnNameValue == "GAINSHARE")
                {
                    string CarrierColumn = Gettext(attributeName_xpath, ".//*[@id='CustomerTable']/thead/tr/th[2]");
                    if (CarrierColumn == "CARRIER")
                    {
                        List<string> CarrierCount = IndividualColumnData(".//*[@id='CustomerTable']/tbody/tr");
                        string CarrierName = Gettext(attributeName_xpath, ".//*[@id='CustomerTable']/tbody/tr[" + 1 + "]/td[2]");
                        if (CarrierName == "A&B Freight Line Inc" | CarrierName == "AAA Cooper Transportation" | CarrierName == "Averitt Express")
                        {
                            string SetGainshareValue = Gettext(attributeName_xpath, ".//*[@id='CustomerTable']/tbody/tr[" + 1 + "]/td[5]");
                            Assert.IsTrue(SetGainshareValue.Contains("%") && SetGainshareValue.Length - SetGainshareValue.IndexOf(".") == 4);
                            Report.WriteLine("Gainshare Percentage values updated for the selected carriers");
                            break;
                        }
                        else
                        {
                            Report.WriteLine("Added Gainshare Percentage value not matches with the format in the Grid");
                            Assert.IsTrue(true);
                        }
                    }
                }
            }
        }


        [Then(@"The maximum value will be (.*)")]
        public void ThenTheMaximumValueWillBe(Decimal p0)
        {
            List<string> GridColumnNames = IndividualColumnData(".//*[@id='CustomerTable']/thead/tr/th");
            for (int i = 1; i <= GridColumnNames.Count; i++)
            {
                string ColumnNameValue = Gettext(attributeName_xpath, ".//*[@id='CustomerTable']/thead/tr/th[" + i + "]");
                if (ColumnNameValue == "GAINSHARE")
                {
                    string CarrierColumn = Gettext(attributeName_xpath, ".//*[@id='CustomerTable']/thead/tr/th[2]");
                    if (CarrierColumn == "CARRIER")
                    {
                        List<string> CarrierCount = IndividualColumnData(".//*[@id='CustomerTable']/tbody/tr");
                        string CarrierName = Gettext(attributeName_xpath, ".//*[@id='CustomerTable']/tbody/tr[" + 1 + "]/td[2]");
                        if (CarrierName == "A&B Freight Line Inc" | CarrierName == "AAA Cooper Transportation" | CarrierName == "Averitt Express")
                        {
                            string SetGainshareValue = Gettext(attributeName_xpath, ".//*[@id='CustomerTable']/tbody/tr[" + 1 + "]/td[5]");
                            SetGainshareValue = SetGainshareValue.Replace("%", string.Empty);
                            Assert.IsTrue(Convert.ToDouble(SetGainshareValue) < 100.00);
                            Report.WriteLine("Gainshare Percentage values updated for the selected carriers");
                            break;
                        }
                        else
                        {
                            Report.WriteLine("Added Gainshare Percentage value does not matches with the Format");
                            Assert.IsTrue(true);
                        }
                    }
                }
            }
        }

        [Then(@"% is displayed after the numerical value\.")]
        public void ThenIsDisplayedAfterTheNumericalValue_()
        {
            List<string> GridColumnNames = IndividualColumnData(".//*[@id='CustomerTable']/thead/tr/th");
            for (int i = 1; i <= GridColumnNames.Count; i++)
            {
                string ColumnNameValue = Gettext(attributeName_xpath, ".//*[@id='CustomerTable']/thead/tr/th[" + i + "]");
                if (ColumnNameValue == "GAINSHARE")
                {
                    string CarrierColumn = Gettext(attributeName_xpath, ".//*[@id='CustomerTable']/thead/tr/th[2]");
                    if (CarrierColumn == "CARRIER")
                    {
                        List<string> CarrierCount = IndividualColumnData(".//*[@id='CustomerTable']/tbody/tr");
                        string CarrierName = Gettext(attributeName_xpath, ".//*[@id='CustomerTable']/tbody/tr[" + 1 + "]/td[2]");
                        if (CarrierName == "A&B Freight Line Inc" | CarrierName == "AAA Cooper Transportation" | CarrierName == "Averitt Express")
                        {
                            string SetGainshareValue = Gettext(attributeName_xpath, ".//*[@id='CustomerTable']/tbody/tr[" + 1 + "]/td[5]");
                            Assert.IsTrue(SetGainshareValue.Contains("%") && SetGainshareValue.Contains("."));
                            Report.WriteLine("Gainshare Percentage values updated for the selected carriers");
                            break;
                        }
                        else
                        {
                            Report.WriteLine("Added Gainshare Percentage value not matches with the column[" + i + "] in the Grid");
                            Assert.IsTrue(true);
                        }
                    }
                }
            }
        }
    }
}
