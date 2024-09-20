using CRM.UITest.Entities;
using CRM.UITest.Objects;
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
    public class Master_Carrier_Rate_Settings___Excluded_Carriers___Values_Not_Displayed_Steps : MaintenaceTools
    {
        [When(@"I must be navigated to (.*) Page")]
        public void WhenIMustBeNavigatedToPage(string title)
        {

            Report.WriteLine("Master carrier rate settings page title");
            Verifytext(attributeName_xpath, MasterCarrierRatePage_Title_Xpath, title);



        }


        [When(@"I have selected a customer(.*) has one or more excluded carriers from gainshare pricing")]
        public void WhenIHaveSelectedACustomerHasOneOrMoreExcludedCarriersFromGainsharePricing(string customer)
        {
            Report.WriteLine("Click on Customers dropdown");
            Click(attributeName_xpath, CustomerSelection_DropdownBox_Xpath);
            IList<IWebElement> CustomerdropdownValues = GlobalVariables.webDriver.FindElements(By.XPath(CustomerSelection_DropdownList_Xpath));
            for (int i = 0; i <= CustomerdropdownValues.Count; i++)
            {
                if (CustomerdropdownValues[i].Text == customer)
                {
                    //  SelectDropdownValueFromList(attributeName_xpath, CustomerSelection_DropdownList_Xpath, customer);
                    CustomerdropdownValues[i].Click();
                    break;
                }
                else
                {
                    Report.WriteLine("Customer value does not exists");
                }
            }


        }


        [When(@"I have selected a customer(.*) has no excluded carriers from gainshare pricing")]
        public void WhenIHaveSelectedACustomerHasNoExcludedCarriersFromGainsharePricing(string customer)
        {
            Report.WriteLine("Click on Customers dropdown");
            Click(attributeName_xpath, CustomerSelection_DropdownBox_Xpath);
            IList<IWebElement> CustomerdropdownValues = GlobalVariables.webDriver.FindElements(By.XPath(CustomerSelection_DropdownList_Xpath));
            for (int i = 0; i <= CustomerdropdownValues.Count; i++)
            {
                if (CustomerdropdownValues[i].Text == customer)
                {
                    SelectDropdownValueFromList(attributeName_xpath, CustomerSelection_DropdownList_Xpath, customer);
                    break;
                }
                else
                {
                    Report.WriteLine("Customer value does not exists");
                }
            }
        }


        [Then(@"Verfiy Bump,Surge,Gainshare,Minimum,Min Threshold,Min Amount,Master Accessorial Charge,Accessorial fields (.*)")]
        public void ThenVerfiyBumpSurgeGainshareMinimumMinThresholdMinAmountMasterAccessorialChargeAccessorialFields(string customerName)
        {

            int pricingModelId = DBHelper.GetGainsharePricingId(customerName);
            string excludedCarriers = DBHelper.GetExcludedCarriersforCustomer(pricingModelId);
            if (excludedCarriers == null)
            {             
                    Report.WriteLine("No excluded carrier is available for selected customer");  
            }

            else
            {
                string[] excludedCarriersActual = excludedCarriers.Split(',');
                List<string> carriersExcludedDB = new List<string>();

                foreach (string element in excludedCarriersActual)
                {
                    carriersExcludedDB.Add(DBHelper.Carriernameforscac(element));
                }

                Thread.Sleep(20000);
                IList<IWebElement> carriersListRate = GlobalVariables.webDriver.FindElements(By.XPath("//*[@id='CustomerTable']//tbody/tr/td[2]"));
                List<string> carriersExcludedUI = new List<string>();
                foreach (IWebElement element in carriersListRate)
                {
                    carriersExcludedUI.Add(element.Text.ToString());
                }

                if (carriersExcludedDB.Count > 0)
                {
                    string surgeValue = null;
                    string bumpValue = null;
                    string gainshareValue = null;
                    string minimumValue = null;
                    string minThresholdValue = null;
                    string minAmountValue = null;
                    string masterAccessorialChargeValue = null;

                    for (int i = 0; i < carriersExcludedUI.Count; i++)
                    {
                        //if (i <= carriersExcludedDB.Count())
                        //{


                        if (carriersExcludedDB.Contains(carriersExcludedUI[i]))
                        {
                            int j = 3;
                            int k = i; // bcz in UI is starts with 0
                            k++;
                            //Need to write code to verify None value in UI
                            surgeValue = Gettext(attributeName_xpath, "//*[@id='CustomerTable']/tbody/tr[" + k + "]/td[" + j + "]");
                            j++;
                            bumpValue = Gettext(attributeName_xpath, "//*[@id='CustomerTable']/tbody/tr[" + k + "]/td[" + j + "]");
                            j++;
                            gainshareValue = Gettext(attributeName_xpath, "//*[@id='CustomerTable']/tbody/tr[" + k + "]/td[" + j + "]");
                            j++;
                            minimumValue = Gettext(attributeName_xpath, "//*[@id='CustomerTable']/tbody/tr[" + k + "]/td[" + j + "]");
                            j++;
                            minThresholdValue = Gettext(attributeName_xpath, "//*[@id='CustomerTable']/tbody/tr[" + k + "]/td[" + j + "]");
                            j++;
                            minAmountValue = Gettext(attributeName_xpath, "//*[@id='CustomerTable']//tbody/tr[" + k + "]/td[" + j + "]");
                            j++;
                            masterAccessorialChargeValue = Gettext(attributeName_xpath, "//*[@id='CustomerTable']//tbody/tr[" + k + "]/td[" + j + "]");
                            //j++;
                            //Verfying expected Bump,Surge,Gainshare,Minimum,Min Threshold,Min Amount,Master Accessorial Charge,Accessorial fields
                            if (surgeValue.Equals("None"))
                            {
                                Report.WriteLine("None is displayed for excluded carrier");
                            }
                            else
                            {
                                throw new Exception("None is not displayed for excluded carrier");
                            }
                            if (bumpValue.Equals("None"))
                            {
                                Report.WriteLine("None is displayed for bump field");
                            }
                            else
                            {
                                throw new Exception("None is not displayed for bump field");
                            }
                            if (gainshareValue.Equals("None"))
                            {
                                Report.WriteLine("None is displayed for gainshare field");
                            }
                            else
                            {
                                throw new Exception("None is not displayed for gainshare field");
                            }
                            if (minimumValue.Equals("None"))
                            {
                                Report.WriteLine("None is displayed for minimum field");
                            }
                            else
                            {
                                throw new Exception("None is not displayed for minimum field");
                            }
                            if (minThresholdValue.Equals("None"))
                            {
                                Report.WriteLine("None is displayed for minThreshold field");
                            }
                            else
                            {
                                throw new Exception("None is not displayed for minThreshold field");
                            }
                            if (minAmountValue.Equals("None"))
                            {
                                Report.WriteLine("None is displayed for minAmount field");
                            }
                            else
                            {
                                throw new Exception("None is not displayed for minAmount field");
                            }

                            if (masterAccessorialChargeValue.Equals("None"))
                            {
                                Report.WriteLine("None is displayed for masterAccessorialCharge field");
                            }
                            else
                            {
                                throw new Exception("None is not displayed for masterAccessorialCharge field");
                            }


                        }

                    }
                }
               
            }
        }


       

    }
}
