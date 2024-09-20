using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Maintenance_Tools.Master_Carrier_Rate_Settings
{
    [Binding]
    public sealed class MasterCarrierRateSettings_Format_IndividualAccessorialFieldSteps: MaintenaceTools
    {


        [When(@"I have selected Customer from Master carrier Rate settings page (.*)")]
        public void WhenIHaveSelectedCustomerFromMasterCarrierRateSettingsPage(string Customer_Name)
        {
            Click(attributeName_id, MaintenanceModule_id);
            GlobalVariables.webDriver.WaitForPageLoad();

            Report.WriteLine("Click on pricing button");
            VerifyElementPresent(attributeName_xpath, Pricing_Button_Xpath, "Pricing");
            Click(attributeName_xpath, Pricing_Button_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();

            VerifyElementVisible(attributeName_xpath, MasterCarrierRatePage_Title_Xpath, "Master Carrier Rate Settings");
            Report.WriteLine("I am on Master Carrier Rate Settings page");


            Report.WriteLine("Selecting " + Customer_Name + " from Customer dropdown");
            Click(attributeName_xpath, CustomerSelection_DropdownBox_Xpath);
            SendKeys(attributeName_xpath, AllCustomer_Dropdown_Search_Xpath, Customer_Name);
            Click(attributeName_xpath, IndividualCustomers_DropdownFirstValue_Xpath);
            WaitForElementVisible(attributeName_xpath, CarrierAllValues_Xpath, "value");

        }

        [When(@"Customer has one or more (.*) set")]
        public void WhenCustomerHasOneOrMoreSet(string Individual_Accessorial)
        {
            Report.WriteLine("Verifying Carrier display on Master carrier rate settings page");
            IList<IWebElement> carriersUI = GlobalVariables.webDriver.FindElements(By.XPath(CarrierAllValues_Xpath));
            string Gridtext = Gettext(attributeName_xpath, CarrierAllValues_Xpath);
            int CarrierCount = carriersUI.Count();
            if (carriersUI.Count >= 1 && Gridtext != "No data available in table")
            {
                for (int i = 1; i < CarrierCount; i++)
                {
                    if (carriersUI[i].Selected.ToString().Contains((ConsoleColor.Gray).ToString()))
                    {
                        Report.WriteLine("Carrier is deactivated in Grid ");
                    }
                    else
                    {
                        Report.WriteLine("Selected the Carrier from the Grid");

                        Click(attributeName_xpath, ".//*[@id='CustomerTable']//tbody/tr[" + i + "]//label");
                        WaitForElementVisible(attributeName_id, SetAccessorial_Button_Id, "value");

                        Report.WriteLine("Click on Set Accessorial");
                        Click(attributeName_id, SetAccessorial_Button_Id);
                        WaitForElementVisible(attributeName_xpath, SetAccessorialType_Xpath,"value");
                        
                        Click(attributeName_xpath, SetAccessorialType_Xpath);
                        
                        IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(SetAccessorailTypeValues_Xpath));
                        int DropDownCount = DropDownList.Count;
                        for (int j = 0; j < DropDownCount; j++)
                        {
                            if (DropDownList[j].Text == Individual_Accessorial)
                            {
                                DropDownList[j].Click();
                                break;
                            }
                        }

                        break;
                    }


                }
            }
            else
            {
                Report.WriteLine("No Carriers Found");
            }

        }

        [When(@"Individual Accessorial have (.*) value")]
        public void WhenIndividualAccessorialHaveValue(string Numeric)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("I enter the value for selected accessorial");
            SendKeys(attributeName_id, SetAccessorialTypeText_Id, Numeric);
            

        }

        [Then(@"The value displayed will be in (.*) currency format")]
        public void ThenTheValueDisplayedWillBeInCurrencyFormat(string dollor_sign)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            string Actuallsign = GetValue(attributeName_id, SetGainshareDropDown_Id,"value");
            Report.WriteLine("Verified as $ sign are matching");
            Assert.AreEqual(dollor_sign, Actuallsign);
            Click(attributeName_id, SetAccessorial_SaveButton_Id);

        }

        [Then(@"The value will be preceded by the (.*)")]
        public void ThenTheValueWillBePrecededByThe(string dollor_sign)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Accessorial value will be updated with the $ sign");
            string GetFirstAccessorial = Gettext(attributeName_xpath, FirstCarrier_SetAccessorial_Xpath);
            if(GetFirstAccessorial.Contains(dollor_sign))
            {
                Report.WriteLine("Value" + GetFirstAccessorial + "is preceded by" + dollor_sign);
            }
            else
            {
                Report.WriteLine("Accessorail doesn't have currency format");
            }
        }

        [Then(@"Each value will have two (.*)")]
        public void ThenEachValueWillHaveTwo(string decimal_places)
        {
            
            Report.WriteLine("Each value have the 2 decimal places");
            string GetFirstAccessorial = Gettext(attributeName_xpath, FirstCarrier_SetAccessorial_Xpath);
            if(GetFirstAccessorial.Contains(decimal_places))
            {
                Report.WriteLine("Value" + GetFirstAccessorial + "Have the 2 decimal Places" + decimal_places);
            }
            else
            {
                Report.WriteLine("Accessorial doesn't updated with the decimal value ");
            }
        }



    }
}
