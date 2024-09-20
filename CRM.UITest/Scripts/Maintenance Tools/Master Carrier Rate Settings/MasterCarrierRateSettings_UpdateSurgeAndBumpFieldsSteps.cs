using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.DataModels;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;

namespace CRM.UITest.Scripts.Maintenance_Tools.Master_Carrier_Rate_Settings
{
    [Binding]
    public class MasterCarrierRateSettings_UpdateSurgeAndBumpFieldsSteps : MaintenaceTools
    {
        public WebElementOperations ObjWebElementOperations = new WebElementOperations();
        public BumpSurgeCalculationModel bumpSurgeCalculationModel = new BumpSurgeCalculationModel();


        [Given(@"I am on the Master Carrier Rate Settings page (.*)")]
        public void GivenIAmOnTheMasterCarrierRateSettingsPage(string MasterCarrierPageTitle)
        {
            Click(attributeName_xpath, MaintenanceTools_Icon_Xpath);
            Thread.Sleep(1000);
            Click(attributeName_xpath, Pricing_Button_Xpath);
            VerifyElementVisible(attributeName_xpath, MasterCarrierRatePage_Title_Xpath, MasterCarrierPageTitle);
            Report.WriteLine("I am on Master Carrier Rate Settings page");
        }

        [When(@"I have selected a customer (.*)")]
        public void WhenIHaveSelectedACustomer(string CustomerName)
        {
            Click(attributeName_xpath, CustomerSelection_DropdownBox_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, CustomerSelection_DropdownList_Xpath, CustomerName);
            Report.WriteLine("Selected Customer from Customer Dropdown");
            Thread.Sleep(50000);
        }


        [When(@"I have selected one carriers")]
        public void WhenIHaveSelectedOneCarriers()
        {
            Thread.Sleep(10000);
            Report.WriteLine("Verifying Carrier display on Master carrier rate settings page");
            IList<IWebElement> carriersUI = GlobalVariables.webDriver.FindElements(By.XPath(CarrierAllValues_Xpath));
            if (carriersUI.Count > 0)
            {
                Report.WriteLine("Selecting one carrier");
                Click(attributeName_xpath, FirstCarrierSelect_Xpath);
            }
            else
            {
                Report.WriteLine("No Carriers Found");
            }
        }

        [When(@"I have selected one or more carriers")]
        public void WhenIHaveSelectedOneOrMoreCarriers()
        {
            Thread.Sleep(10000);
            Report.WriteLine("Verifying Carrier display on Master carrier rate settings page");
            IList<IWebElement> carriersUI = GlobalVariables.webDriver.FindElements(By.XPath(CarrierAllValues_Xpath));
            if (carriersUI.Count > 0)
            {
                Report.WriteLine("Selecting one carrier");
                Click(attributeName_xpath, FirstCarrierSelect_Xpath);
            }
            else
            {
                Report.WriteLine("No Carriers Found");
            }
        }

        [When(@"I selected two carriers")]
        public void WhenISelectedTwoCarriers()
        {
            IList<IWebElement> carriersUI = GlobalVariables.webDriver.FindElements(By.XPath(CarrierAllValues_Xpath));
            if (carriersUI.Count > 0)
            {
                Report.WriteLine("Selecting two carrier");
                Click(attributeName_xpath, FirstCarrierSelect_Xpath);
                Thread.Sleep(5000);
                Click(attributeName_xpath, SecondCarrierSelect_Xpath);
            }
            else
            {
                Report.WriteLine("No Carriers Found");
            }
        }


        [When(@"I have selected all carriers")]
        public void WhenIHaveSelectedAllCarriers()
        {
            IList<IWebElement> carriersUI = GlobalVariables.webDriver.FindElements(By.XPath(CarrierAllValues_Xpath));
            if (carriersUI.Count > 0)
            {
                Report.WriteLine("Select all carriers");
                Click(attributeName_xpath, AllCarrierSelect_Xpath);
            }
            else
            {
                Report.WriteLine("No Carriers Found");
            }


        }

        [When(@"I update Surge or Bump fields (.*),(.*)")]
        public void WhenIUpdateSurgeOrBumpFields(string Surge, string Bump)
        {
            Report.WriteLine("Updating Surge or Bump values");
            SendKeys(attributeName_xpath, SurgeValue_Textbox_Xpath, Surge);
            Click(attributeName_id, Surgebutton_Id);
            Thread.Sleep(80000);
        }



        [When(@"I have updated any of the following fields (.*),(.*)")]
        public void WhenIHaveUpdatedAnyOfTheFollowingFields(string Surge, string Bump)
        {
            Report.WriteLine("Updating Surge or Bump values");
            SendKeys(attributeName_xpath, BumpValue_Textbox_Xpath, Bump);
            Click(attributeName_id, Bumpbutton_Id);
            Thread.Sleep(5000);
        }
        [Then(@"Surge and Bump values will be displayed on the Master Carrier Rate Settings page - (.*)")]
        public void ThenSurgeAndBumpValuesWillBeDisplayedOnTheMasterCarrierRateSettingsPage_(string CustomerName)
        {
            string OneCarrierUI = Gettext(attributeName_xpath, CarrierOne_Xpath);
            BumpSurgeCustomerSetUp setup = DBHelper.GetBumpSurgeFromDB(OneCarrierUI, CustomerName);
            bumpSurgeCalculationModel.Bump = (setup?.Bump) ?? 0;
            bumpSurgeCalculationModel.Surge = (setup?.Surge) ?? 0;
            if ((bumpSurgeCalculationModel.Bump > 0 || bumpSurgeCalculationModel.Surge > 0))
            {

                Report.WriteLine("Bump value is saved in Database");
                string BumpUI = Gettext(attributeName_xpath, FirstBumpValue_Xpath);
                Assert.AreEqual(Convert.ToString(bumpSurgeCalculationModel.Bump) + "%", BumpUI);
                Report.WriteLine("Entered Bump value is displayed in Master carrier rate settings page");


                Report.WriteLine("Surge value is saved in Database");
                string SurgeUI = Gettext(attributeName_xpath, FirstSurgeValue_Xpath);
                Assert.AreEqual(Convert.ToString(bumpSurgeCalculationModel.Surge) + "%", SurgeUI);
                Report.WriteLine("Entered Surge value is displayed in Master carrier rate settings page");


            }
            else if ((bumpSurgeCalculationModel.Bump == 0 && bumpSurgeCalculationModel.Surge == 0))
            {
                IsElementDisabled(attributeName_xpath, CarrierOne_Xpath, OneCarrierUI);
                Report.WriteLine("Bump and Surge value is not updated since its excluded carrier");
            }

            else
            {
                Report.WriteFailure("The entered Bump or surge values does not exists in database");
                Assert.Fail();
            }

        }



        [Then(@"The values entered for all the Surge or Bump fields will get saved and displayed on the Master Carrier Rate Settings page-(.*),(.*),(.*)")]
        public void ThenTheValuesEnteredForAllTheSurgeOrBumpFieldsWillGetSavedAndDisplayedOnTheMasterCarrierRateSettingsPage_(string CustomerName, string Bump, string Surge)
        {
            IList<IWebElement> carriersUI = GlobalVariables.webDriver.FindElements(By.XPath(CarrierAllValues_Xpath));
            if (carriersUI.Count > 0)
            {
                List<string> carrierListValues = ObjWebElementOperations.GetListFromIWebElement(carriersUI);

                IList<IWebElement> BumpvaluesUI = GlobalVariables.webDriver.FindElements(By.XPath(Bump_ColumnValues_Xpath));
                List<string> BumpListValues = ObjWebElementOperations.GetListFromIWebElement(BumpvaluesUI);


                IList<IWebElement> SurgevaluesUI = GlobalVariables.webDriver.FindElements(By.XPath(Surge_ColumnValues_Xpath));
                List<string> SurgeListValues = ObjWebElementOperations.GetListFromIWebElement(SurgevaluesUI);

                for (int i = 0; i < carrierListValues.Count; i++)
                {
                    BumpSurgeCustomerSetUp setup = DBHelper.GetBumpSurgeFromDB(carrierListValues[i], CustomerName);
                    bumpSurgeCalculationModel.Bump = (setup?.Bump) ?? 0;
                    bumpSurgeCalculationModel.Surge = (setup?.Surge) ?? 0;
                    if ((bumpSurgeCalculationModel.Bump > 0 || bumpSurgeCalculationModel.Surge > 0))
                    {
                        if (Convert.ToString(bumpSurgeCalculationModel.Bump).Equals(Bump) && Convert.ToString(bumpSurgeCalculationModel.Surge).Equals(Surge))
                        {
                            Report.WriteLine("Bump value is saved in Database");
                            Assert.AreEqual(Convert.ToString(bumpSurgeCalculationModel.Bump) + "%", BumpListValues[i]);
                            Report.WriteLine("Entered Bump value is displayed in Master carrier rate settings page");
                            Report.WriteLine("Surge value is saved in Database");
                            Assert.AreEqual(Convert.ToString(bumpSurgeCalculationModel.Surge) + "%", SurgeListValues[i]);
                            Report.WriteLine("Entered Surge value is displayed in Master carrier rate settings page");
                        }
                        else if (Convert.ToString(bumpSurgeCalculationModel.Bump).Equals(Bump))
                        {
                            Report.WriteLine("Bump value is saved in Database");
                            Assert.AreEqual(Convert.ToString(bumpSurgeCalculationModel.Bump) + "%", BumpListValues[i]);
                            Report.WriteLine("Entered Bump value is displayed in Master carrier rate settings page");
                        }
                        else if (Convert.ToString(bumpSurgeCalculationModel.Surge).Equals(Surge))
                        {
                            Report.WriteLine("Surge value is saved in Database");
                            Assert.AreEqual(Convert.ToString(bumpSurgeCalculationModel.Surge) + "%", SurgeListValues[i]);
                            Report.WriteLine("Entered Surge value is displayed in Master carrier rate settings page");
                        }
                        else
                        {
                            Report.WriteFailure("The entered Bump or surge values does not match with the database value");
                            Assert.Fail();
                        }

                    }
                    else if ((bumpSurgeCalculationModel.Bump == 0 && bumpSurgeCalculationModel.Surge == 0))
                    {
                        IsElementDisabled(attributeName_xpath, CarrierAllValues_Xpath, carrierListValues[i]);
                        Report.WriteLine("Bump and Surge value is not updated since its excluded carrier");
                    }

                }
            }
            else
            {
                Report.WriteLine("No Carriers Found");
            }
        }

        [Then(@"The values entered for Surge or Bump fields will get saved and displayed on the Master Carrier Rate Settings page-(.*),(.*),(.*)")]
        public void ThenTheValuesEnteredForSurgeOrBumpFieldsWillGetSavedAndDisplayedOnTheMasterCarrierRateSettingsPage_(string CustomerName, string Bump, string Surge)
        {
            IList<IWebElement> carriersUI = GlobalVariables.webDriver.FindElements(By.XPath(CarrierAllValues_Xpath));
            if (carriersUI.Count > 0)
            {
                List<string> carrierListValues = ObjWebElementOperations.GetListFromIWebElement(carriersUI);

                IList<IWebElement> BumpvaluesUI = GlobalVariables.webDriver.FindElements(By.XPath(Bump_ColumnValues_Xpath));
                List<string> BumpListValues = ObjWebElementOperations.GetListFromIWebElement(BumpvaluesUI);


                IList<IWebElement> SurgevaluesUI = GlobalVariables.webDriver.FindElements(By.XPath(Surge_ColumnValues_Xpath));
                List<string> SurgeListValues = ObjWebElementOperations.GetListFromIWebElement(SurgevaluesUI);


                for (int i = 0; i <= 1; i++)
                {
                    BumpSurgeCustomerSetUp setup = DBHelper.GetBumpSurgeFromDB(carrierListValues[i], CustomerName);
                    bumpSurgeCalculationModel.Bump = (setup?.Bump) ?? 0;
                    bumpSurgeCalculationModel.Surge = (setup?.Surge) ?? 0;
                    if ((bumpSurgeCalculationModel.Bump > 0 || bumpSurgeCalculationModel.Surge > 0))
                    {
                        if (Convert.ToString(bumpSurgeCalculationModel.Bump).Equals(Bump) && Convert.ToString(bumpSurgeCalculationModel.Surge).Equals(Surge))
                        {
                            Report.WriteLine("Bump value is saved in Database");
                            Assert.AreEqual(Convert.ToString(bumpSurgeCalculationModel.Bump) + "%", BumpListValues[i]);
                            Report.WriteLine("Entered Bump value is displayed in Master carrier rate settings page");
                            Report.WriteLine("Surge value is saved in Database");
                            Assert.AreEqual(Convert.ToString(bumpSurgeCalculationModel.Surge) + "%", SurgeListValues[i]);
                            Report.WriteLine("Entered Surge value is displayed in Master carrier rate settings page");

                        }
                        else if (Convert.ToString(bumpSurgeCalculationModel.Bump).Equals(Bump))
                        {
                            Report.WriteLine("Bump value is saved in Database");
                            Assert.AreEqual(Convert.ToString(bumpSurgeCalculationModel.Bump) + "%", BumpListValues[i]);
                            Report.WriteLine("Entered Bump value is displayed in Master carrier rate settings page");
                        }
                        else if (Convert.ToString(bumpSurgeCalculationModel.Surge).Equals(Surge))
                        {
                            Report.WriteLine("Surge value is saved in Database");
                            Assert.AreEqual(Convert.ToString(bumpSurgeCalculationModel.Surge) + "%", SurgeListValues[i]);
                            Report.WriteLine("Entered Surge value is displayed in Master carrier rate settings page");
                        }
                        else
                        {
                            Report.WriteFailure("The entered Bump or surge values does not exists in database");
                            Assert.Fail();
                        }

                    }
                    else if ((bumpSurgeCalculationModel.Bump == 0 && bumpSurgeCalculationModel.Surge == 0))
                    {
                        IsElementDisabled(attributeName_xpath, CarrierAllValues_Xpath, carrierListValues[i]);
                        Report.WriteLine("Bump and Surge value is not updated since its excluded carrier");
                    }


                }
            }
            else
            {
                Report.WriteLine("No Carriers Found");
            }
        }

        [Then(@"The values will be saved and displayed on the Master Carrier Rate Settings page - (.*),(.*),(.*)")]
        public void ThenTheValuesWillBeSavedAndDisplayedOnTheMasterCarrierRateSettingsPage_(string CustomerName, string Bump, string Surge)
        {
            string OneCarrierUI = Gettext(attributeName_xpath, CarrierOne_Xpath);
            BumpSurgeCustomerSetUp setup = DBHelper.GetBumpSurgeFromDB(OneCarrierUI, CustomerName);
            bumpSurgeCalculationModel.Bump = (setup?.Bump) ?? 0;
            bumpSurgeCalculationModel.Surge = (setup?.Surge) ?? 0;
            if ((bumpSurgeCalculationModel.Bump > 0 || bumpSurgeCalculationModel.Surge > 0))
            {
                if (Convert.ToString(bumpSurgeCalculationModel.Bump).Equals(Bump) && Convert.ToString(bumpSurgeCalculationModel.Surge).Equals(Surge))
                {
                    Report.WriteLine("Bump value is saved in Database");
                    string BumpUI = Gettext(attributeName_xpath, FirstBumpValue_Xpath);
                    Assert.AreEqual(Convert.ToString(bumpSurgeCalculationModel.Bump) + "%", BumpUI);
                    Report.WriteLine("Entered Bump value is displayed in Master carrier rate settings page");
                    Report.WriteLine("Surge value is saved in Database");
                    string SurgeUI = Gettext(attributeName_xpath, FirstSurgeValue_Xpath);
                    Assert.AreEqual(Convert.ToString(bumpSurgeCalculationModel.Surge) + "%", SurgeUI);
                    Report.WriteLine("Entered Surge value is displayed in Master carrier rate settings page");

                }
                else if (Convert.ToString(bumpSurgeCalculationModel.Bump).Equals(Bump))
                {
                    Report.WriteLine("Bump value is saved in Database");
                    string BumpUI = Gettext(attributeName_xpath, FirstBumpValue_Xpath);
                    Assert.AreEqual(Convert.ToString(bumpSurgeCalculationModel.Bump) + "%", BumpUI);
                    Report.WriteLine("Entered Bump value is displayed in Master carrier rate settings page");
                }
                else if (Convert.ToString(bumpSurgeCalculationModel.Surge).Equals(Surge))
                {
                    Report.WriteLine("Surge value is saved in Database");
                    string SurgeUI = Gettext(attributeName_xpath, FirstSurgeValue_Xpath);
                    Assert.AreEqual(Convert.ToString(bumpSurgeCalculationModel.Surge) + "%", SurgeUI);
                    Report.WriteLine("Entered Surge value is displayed in Master carrier rate settings page");
                }
                else
                {
                    Report.WriteFailure("The entered Bump or surge values does not exists in database");
                    Assert.Fail();
                }

            }
            else if ((bumpSurgeCalculationModel.Bump == 0 && bumpSurgeCalculationModel.Surge == 0))
            {
                IsElementDisabled(attributeName_xpath, CarrierOne_Xpath, OneCarrierUI);
                Report.WriteLine("Bump and Surge value is not updated since its excluded carrier");
            }


        }




    }


}

