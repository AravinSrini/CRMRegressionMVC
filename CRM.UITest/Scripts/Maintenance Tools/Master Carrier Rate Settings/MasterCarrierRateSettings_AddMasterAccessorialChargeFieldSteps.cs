using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;

namespace CRM.UITest.Scripts.Maintenance_Tools.Master_Carrier_Rate_Settings
{
    [Binding]
    public class MasterCarrierRateSettings_AddMasterAccessorialChargeFieldSteps : MaintenaceTools
    {
        [When(@"I have selected the'(.*)'")]
        public void WhenIHaveSelectedThe(string CustomerName)
        {
            Report.WriteLine("Selected Customer from Customer Dropdown");
            Click(attributeName_xpath, CustomerSelection_DropdownBox_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, CustomerSelection_DropdownList_Xpath, CustomerName);
            Thread.Sleep(80000);
        }

        [When(@"I have entered value in the '(.*)' Master Accessorial Charge field")]
        public void WhenIHaveEnteredValueInTheMasterAccessorialChargeField(string masterAccVal)
        {
            Report.WriteLine("entered the value in Master Accessorial Charge field");
            SendKeys(attributeName_id, MasterAccessorialChargefieldTextbox_id, masterAccVal);
        }

        [When(@"I click on Master Accessorial Charge button")]
        public void WhenIClickOnMasterAccessorialChargeButton()
        {
            Report.WriteLine("Clicked on Master Accessorial Charge field");
            Click(attributeName_id, MasterAccessorialChargefieldButton_id);
        }

        [Then(@"I will have an option to enter Master Accessorial Charge with percentage")]
        public void ThenIWillHaveAnOptionToEnterMasterAccessorialChargeWithPercentage()
        {
            try
            {
                Report.WriteLine("displaying the Master Accessorial Charge textbox");
                WaitForElementVisible(attributeName_id, MasterAccessorialChargefieldTextbox_id, "TextBox");
                VerifyElementVisible(attributeName_id, MasterAccessorialChargefieldTextbox_id, "TextBox");
                Report.WriteLine("displaying the percentage symbol for the Master Accessorial Charge textbox");
                VerifyElementVisible(attributeName_id, MasterAccessorialChargefieldSymbol_id, "Symbol");
            }
            catch
            {

                Report.WriteLine("Page is loading");                                    
            }
        }

        [Then(@"I will be displayed withMaster Accessorial Charge button right of Master Accessorial Charge textbox")]
        public void ThenIWillBeDisplayedWithMasterAccessorialChargeButtonRightOfMasterAccessorialChargeTextbox()
        {
            Report.WriteLine("displaying the Master Accessorial Charge Button");
            VerifyElementVisible(attributeName_id, MasterAccessorialChargefieldButton_id, "Button");
        }

        [When(@"I have selected multiple carriers")]
        public void WhenIHaveSelectedMultipleCarriers()
        {
            Thread.Sleep(10000);
            Report.WriteLine("Verifying Carrier display on Master carrier rate settings page");
            IList<IWebElement> carriersUI = GlobalVariables.webDriver.FindElements(By.XPath(CarrierAllValues_Xpath));

            if (carriersUI.Count > 0)
            {
                Report.WriteLine("Selecting top three carrier");
                Click(attributeName_xpath, FirstCarrierr1_Checkbox_Xpath);
                Click(attributeName_xpath, secondCarrier_Checkbox_Xpath);
                Click(attributeName_xpath, ThirdCarrier_Checkbox_Xpath);

            }
            else
            {
                Report.WriteLine("No Carriers Found");
            }
        }

        [Then(@"Master Accessorial Chargevalue '(.*)' for the selected carriers '(.*)' of '(.*)' should be saved in Database")]
        public void ThenMasterAccessorialChargevalueForTheSelectedCarriersOfShouldBeSavedInDatabase(string masterAccVal, string carrierName, string customerName)
        {
            int pricingId = DBHelper.GetGainsharePricingId(customerName);
            decimal ExpmasterAccVal = DBHelper.GetGainshareScacByCarrierName(pricingId, carrierName).MasterAccessorialCharge;
            decimal masterAccVal_dec = decimal.Parse(masterAccVal);
            Assert.AreEqual(ExpmasterAccVal.ToString(), masterAccVal_dec.ToString());
        }

        [Then(@"the grid will display the '(.*)' and '(.*)' with updated Master Accessorial Charge values for the selected carriers")]
        public void ThenTheGridWillDisplayTheAndWithUpdatedMasterAccessorialChargeValuesForTheSelectedCarriers(string masterAccVal, string Carrier)
        {
            List<string> GridColumnNames = IndividualColumnData(".//*[@id='CustomerTable']/thead/tr/th");
            for (int i = 1; i <= GridColumnNames.Count; i++)
            {
                string ColumnNameValue = Gettext(attributeName_xpath, ".//*[@id='CustomerTable']/thead/tr/th[" + i + "]");
                if (ColumnNameValue == "MASTER ACCESSORIAL CHARGE")
                {
                    string CarrierColumn = Gettext(attributeName_xpath, ".//*[@id='CustomerTable']/thead/tr/th[2]");
                    if (CarrierColumn == "CARRIER")
                    {
                        List<string> CarrierCount = IndividualColumnData(".//*[@id='CustomerTable']/tbody/tr");
                        for (int j = 1; j <= CarrierCount.Count; j++)
                        {
                            string CarrierName = Gettext(attributeName_xpath, ".//*[@id='CustomerTable']/tbody/tr[" + j + "]/td[2]");

                            if (CarrierName == Carrier)
                            {
                                string SetMasterAccValue = Gettext(attributeName_xpath, ".//*[@id='CustomerTable']/tbody/tr[" + j + "]/td[9]");
                                Assert.AreEqual(SetMasterAccValue, masterAccVal+'%');
                                Report.WriteLine("Master Accessorial Charge values updated for the selected carriers");
                                break;
                            }

                            else
                            {
                                Report.WriteLine("Added Master Accessorial value " + masterAccVal + " not matches with the column[" + i + "] in the Grid");
                                Assert.IsTrue(true);
                            }
                        }
                    }
                }
            }
        }



        [Then(@"the grid will display the '(.*)' with updated Master Accessorial Charge values for the selected multiple carriers")]
        public void ThenTheGridWillDisplayTheWithUpdatedMasterAccessorialChargeValuesForTheSelectedMultipleCarriers(Decimal masterAccVal)
        {
            List<string> GridColumnNames = IndividualColumnData(".//*[@id='CustomerTable']/thead/tr/th");
            for (int i = 1; i <= GridColumnNames.Count; i++)
            {
                string ColumnNameValue = Gettext(attributeName_xpath, ".//*[@id='CustomerTable']/thead/tr/th[" + i + "]");
                if (ColumnNameValue == "MASTER ACCESSORIAL CHARGE")
                {
                    string CarrierColumn = Gettext(attributeName_xpath, ".//*[@id='CustomerTable']/thead/tr/th[2]");
                    if (CarrierColumn == "CARRIER")
                    {
                        List<string> CarrierCount = IndividualColumnData(".//*[@id='CustomerTable']/tbody/tr");
                        for (int j = 1; j <= 3; j++)
                        {
                            string CarrierName = Gettext(attributeName_xpath, ".//*[@id='CustomerTable']/tbody/tr[" + j + "]/td[2]");

                            if (CarrierName == "A & B Freight Line Inc" | CarrierName == "AAA Cooper Transportation" | CarrierName == "Averitt Express")
                            {
                                string SetMasterAccValue = Gettext(attributeName_xpath, ".//*[@id='CustomerTable']/tbody/tr[" + j + "]/td[9]");
                                Assert.AreEqual(SetMasterAccValue, masterAccVal.ToString()+'%');
                                Report.WriteLine("Master Accessorial Charge values updated for the selected carriers");
                                break;
                            }

                            else
                            {
                                Report.WriteLine("Added Master Accessorial value " + masterAccVal + " not matches with the column[" + i + "] in the Grid");
                                Assert.IsTrue(true);
                            }
                        }
                    }
                }
            }
        }
    }
}






