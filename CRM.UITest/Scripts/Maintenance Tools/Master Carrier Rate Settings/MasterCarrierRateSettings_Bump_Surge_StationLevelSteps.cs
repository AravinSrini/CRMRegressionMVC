using CRM.UITest.CommonMethods;
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
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Maintenance_Tools.Master_Carrier_Rate_Settings
{
    [Binding]
    public class MasterCarrierRateSettings_Bump_Surge_StationLevelSteps : MaintenaceTools
    {
        public WebElementOperations ObjWebElementOperations = new WebElementOperations();
        public BumpSurgeCalculationModel bumpSurgeCalculationModel = new BumpSurgeCalculationModel();

        [When(@"I have selected all Stations")]
        public void WhenIHaveSelectedAllStations()
        {
            Click(attributeName_xpath, CustomerSelection_DropdownBox_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, AllCustomers_AllStations_Xpath, "ALL CUSTOMERS");
            Report.WriteLine("Clicked on all stations");

        }

        [When(@"I have selected one Station (.*)")]
        public void WhenIHaveSelectedOneStation(string StationName)
        {
            Click(attributeName_xpath, StationDropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, AllStations_DropdownValues_Xpath, StationName);
            Report.WriteLine("Seleted one station");
        }

        [Then(@"Surge and Bump values will be displayed on the Master Carrier Rate Settings page\.")]
        public void ThenSurgeAndBumpValuesWillBeDisplayedOnTheMasterCarrierRateSettingsPage_()
        {
            BumpSurgeAllStationsDisplay DisplayOfBumpSurge_AllStations = new BumpSurgeAllStationsDisplay();
            DisplayOfBumpSurge_AllStations.GetBumpSurgeValues_AllStations();
        }

        [Then(@"Surge and Bump values will be displayed as None if values does not exists for the carriers")]
        public void ThenSurgeAndBumpValuesWillBeDisplayedAsNoneIfValuesDoesNotExistsForTheCarriers()
        {
            BumpSurgeAllStationsDisplay DisplayOfBumpSurge_AllStations = new BumpSurgeAllStationsDisplay();
            DisplayOfBumpSurge_AllStations.GetBumpSurgeValues_AllStations();
        }

        [Then(@"the values for all carriers will be saved to the database for all stations (.*),(.*)")]
        public void ThenTheValuesForAllCarriersWillBeSavedToTheDatabaseForAllStations(string Bump, string Surge)
        {
            IList<IWebElement> carriersUI = GlobalVariables.webDriver.FindElements(By.XPath(CarrierAllValues_Xpath));
            if (carriersUI.Count > 0)
            {
                List<string> carrierListValues = ObjWebElementOperations.GetListFromIWebElement(carriersUI);

                IList<IWebElement> BumpvaluesUI = GlobalVariables.webDriver.FindElements(By.XPath(Bump_ColumnValues_Xpath));
                List<string> BumpListValues = ObjWebElementOperations.GetListFromIWebElement(BumpvaluesUI);


                IList<IWebElement> SurgevaluesUI = GlobalVariables.webDriver.FindElements(By.XPath(Surge_ColumnValues_Xpath));
                List<string> SurgeListValues = ObjWebElementOperations.GetListFromIWebElement(SurgevaluesUI);
                List<string> ExpStations = new List<string>();
                List<string> Stations = DBHelper.GetAllStationName();
                foreach (var v in Stations)
                {
                    ExpStations.Add(v);
                }
                for (int j = 0; j <= ExpStations.Count; j++)
                {
                    for (int i = 0; i <= carrierListValues.Count; i++)
                    {
                        BumpSurgeStationSetUp setup = DBHelper.GetSurgeBumpStationDB(carrierListValues[i], ExpStations[j]);
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
            }

            else
            {
                Report.WriteLine("No Carriers Found");
            }
        }

        [Then(@"the values for all carriers will be saved to the database of the station selected (.*),(.*),(.*)")]
        public void ThenTheValuesForAllCarriersWillBeSavedToTheDatabaseOfTheStationSelected(string StationName, string Bump, string Surge)
        {
            IList<IWebElement> carriersUI = GlobalVariables.webDriver.FindElements(By.XPath(CarrierAllValues_Xpath));
            if (carriersUI.Count > 0)
            {
                List<string> carrierListValues = ObjWebElementOperations.GetListFromIWebElement(carriersUI);

                IList<IWebElement> BumpvaluesUI = GlobalVariables.webDriver.FindElements(By.XPath(Bump_ColumnValues_Xpath));
                List<string> BumpListValues = ObjWebElementOperations.GetListFromIWebElement(BumpvaluesUI);


                IList<IWebElement> SurgevaluesUI = GlobalVariables.webDriver.FindElements(By.XPath(Surge_ColumnValues_Xpath));
                List<string> SurgeListValues = ObjWebElementOperations.GetListFromIWebElement(SurgevaluesUI);

                for (int i = 0; i <= carrierListValues.Count; i++)
                {
                    BumpSurgeStationSetUp setup = DBHelper.GetSurgeBumpStationDB(carrierListValues[i], StationName);
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
        }

        [Then(@"the values for the selected carriers will be saved to the database of the station selected (.*),(.*),(.*)")]
        public void ThenTheValuesForTheSelectedCarriersWillBeSavedToTheDatabaseOfTheStationSelected(string StationName, string Bump, string Surge)
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
                    BumpSurgeStationSetUp setup = DBHelper.GetSurgeBumpStationDB(carrierListValues[i], StationName);
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
        }


        [Then(@"the values for the selected carriers will be saved to the database for all stations (.*),(.*)")]
        public void ThenTheValuesForTheSelectedCarriersWillBeSavedToTheDatabaseForAllStations(string Bump, string Surge)
        {

            IList<IWebElement> carriersUI = GlobalVariables.webDriver.FindElements(By.XPath(CarrierAllValues_Xpath));
            if (carriersUI.Count > 0)
            {
                List<string> carrierListValues = ObjWebElementOperations.GetListFromIWebElement(carriersUI);

                IList<IWebElement> BumpvaluesUI = GlobalVariables.webDriver.FindElements(By.XPath(Bump_ColumnValues_Xpath));
                List<string> BumpListValues = ObjWebElementOperations.GetListFromIWebElement(BumpvaluesUI);


                IList<IWebElement> SurgevaluesUI = GlobalVariables.webDriver.FindElements(By.XPath(Surge_ColumnValues_Xpath));
                List<string> SurgeListValues = ObjWebElementOperations.GetListFromIWebElement(SurgevaluesUI);
                List<string> ExpStations = new List<string>();
                List<string> Stations = DBHelper.GetAllStationName();
                foreach (var v in Stations)
                {
                    ExpStations.Add(v);
                }
                for (int j = 0; j <= ExpStations.Count; j++)
                {
                    for (int i = 0; i <= 1; i++)
                    {
                        BumpSurgeStationSetUp setup = DBHelper.GetSurgeBumpStationDB(carrierListValues[i], ExpStations[j]);
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
            }

            else
            {
                Report.WriteLine("No Carriers Found");
            }
        }

      

        [Then(@"the values will be saved to the database for all stations (.*),(.*)")]
        public void ThenTheValuesWillBeSavedToTheDatabaseForAllStations(string Bump, string Surge)
        {

           string OneCarrierUI = Gettext(attributeName_xpath, CarrierOne_Xpath);
            List<string> ExpStations = new List<string>();
            List<string> Stations = DBHelper.GetAllStationName();
            foreach (var v in Stations)
            {
                ExpStations.Add(v);
            }
            for (int j = 0; j <= ExpStations.Count; j++)
            {
                BumpSurgeStationSetUp setup = DBHelper.GetSurgeBumpStationDB(OneCarrierUI, ExpStations[j]);
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
        [Then(@"the values for all carriers will be saved to the database of all customers, and their sub-customers (.*),(.*),(.*)")]
        public void ThenTheValuesForAllCarriersWillBeSavedToTheDatabaseOfAllCustomersAndTheirSub_Customers(string StationName, string Bump, string Surge)
        {
            IList<IWebElement> carriersUI = GlobalVariables.webDriver.FindElements(By.XPath(CarrierAllValues_Xpath));
            if (carriersUI.Count > 0)
            {
                List<string> carrierListValues = ObjWebElementOperations.GetListFromIWebElement(carriersUI);

                IList<IWebElement> BumpvaluesUI = GlobalVariables.webDriver.FindElements(By.XPath(Bump_ColumnValues_Xpath));
                List<string> BumpListValues = ObjWebElementOperations.GetListFromIWebElement(BumpvaluesUI);


                IList<IWebElement> SurgevaluesUI = GlobalVariables.webDriver.FindElements(By.XPath(Surge_ColumnValues_Xpath));
                List<string> SurgeListValues = ObjWebElementOperations.GetListFromIWebElement(SurgevaluesUI);
                List<string> ExpAcc = new List<string>();
                List<CustomerSetup> value = DBHelper.GetRecordsMappedforStationID(StationName);
                for (int j = 0; j < value.Count; j++)
                {
                    string custname = value[j].CustomerName;
                    ExpAcc.Add(custname);
                }
                for (int i = 0; i <= ExpAcc.Count; i++)
                {
                    for (int k = 0; k <= carrierListValues.Count; k++)
                    {
                        BumpSurgeCustomerSetUp setup = DBHelper.GetBumpSurgeFromDB(carrierListValues[k], ExpAcc[i]);
                        bumpSurgeCalculationModel.Bump = (setup?.Bump) ?? 0;
                        bumpSurgeCalculationModel.Surge = (setup?.Surge) ?? 0;
                        if ((bumpSurgeCalculationModel.Bump > 0 || bumpSurgeCalculationModel.Surge > 0))
                        {
                            if (Convert.ToString(bumpSurgeCalculationModel.Bump).Equals(Bump) && Convert.ToString(bumpSurgeCalculationModel.Surge).Equals(Surge))
                            {
                                Report.WriteLine("Bump value is saved in Database");
                                Assert.AreEqual(Convert.ToString(bumpSurgeCalculationModel.Bump) + "%", BumpListValues[k]);
                                Report.WriteLine("Entered Bump value is displayed in Master carrier rate settings page");
                                Report.WriteLine("Surge value is saved in Database");
                                Assert.AreEqual(Convert.ToString(bumpSurgeCalculationModel.Surge) + "%", SurgeListValues[k]);
                                Report.WriteLine("Entered Surge value is displayed in Master carrier rate settings page");

                            }
                            else if (Convert.ToString(bumpSurgeCalculationModel.Bump).Equals(Bump))
                            {
                                Report.WriteLine("Bump value is saved in Database");
                                Assert.AreEqual(Convert.ToString(bumpSurgeCalculationModel.Bump) + "%", BumpListValues[k]);
                                Report.WriteLine("Entered Bump value is displayed in Master carrier rate settings page");
                            }
                            else if (Convert.ToString(bumpSurgeCalculationModel.Surge).Equals(Surge))
                            {
                                Report.WriteLine("Surge value is saved in Database");
                                Assert.AreEqual(Convert.ToString(bumpSurgeCalculationModel.Surge) + "%", SurgeListValues[k]);
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
                            IsElementDisabled(attributeName_xpath, CarrierAllValues_Xpath, carrierListValues[k]);
                            Report.WriteLine("Bump and Surge value is not updated since its excluded carrier");
                        }

                    }
                }
            }


            else
            {
                Report.WriteLine("No Carriers Found");
            }
        }


        [Then(@"the values for the selected carriers will be saved to the database of all customers, and their sub-customers (.*),(.*),(.*)")]
        public void ThenTheValuesForTheSelectedCarriersWillBeSavedToTheDatabaseOfAllCustomersAndTheirSub_Customers(string StationName, string Bump, string Surge)
        {

            IList<IWebElement> carriersUI = GlobalVariables.webDriver.FindElements(By.XPath(CarrierAllValues_Xpath));
            if (carriersUI.Count > 0)
            {
                List<string> carrierListValues = ObjWebElementOperations.GetListFromIWebElement(carriersUI);

                IList<IWebElement> BumpvaluesUI = GlobalVariables.webDriver.FindElements(By.XPath(Bump_ColumnValues_Xpath));
                List<string> BumpListValues = ObjWebElementOperations.GetListFromIWebElement(BumpvaluesUI);


                IList<IWebElement> SurgevaluesUI = GlobalVariables.webDriver.FindElements(By.XPath(Surge_ColumnValues_Xpath));
                List<string> SurgeListValues = ObjWebElementOperations.GetListFromIWebElement(SurgevaluesUI);
                List<string> ExpAcc = new List<string>();
                List<CustomerSetup> value = DBHelper.GetRecordsMappedforStationID(StationName);
                for (int j = 0; j < value.Count; j++)
                {
                    string custname = value[j].CustomerName;
                    ExpAcc.Add(custname);
                }
                for (int i = 0; i <= ExpAcc.Count; i++)
                {
                    for (int k = 0; k <= carrierListValues.Count; k++)
                    {
                        BumpSurgeCustomerSetUp setup = DBHelper.GetBumpSurgeFromDB(carrierListValues[k], ExpAcc[i]);
                        bumpSurgeCalculationModel.Bump = (setup?.Bump) ?? 0;
                        bumpSurgeCalculationModel.Surge = (setup?.Surge) ?? 0;
                        if ((bumpSurgeCalculationModel.Bump > 0 || bumpSurgeCalculationModel.Surge > 0))
                        {
                            if (Convert.ToString(bumpSurgeCalculationModel.Bump).Equals(Bump) && Convert.ToString(bumpSurgeCalculationModel.Surge).Equals(Surge))
                            {
                                Report.WriteLine("Bump value is saved in Database");
                                Assert.AreEqual(Convert.ToString(bumpSurgeCalculationModel.Bump) + "%", BumpListValues[k]);
                                Report.WriteLine("Entered Bump value is displayed in Master carrier rate settings page");
                                Report.WriteLine("Surge value is saved in Database");
                                Assert.AreEqual(Convert.ToString(bumpSurgeCalculationModel.Surge) + "%", SurgeListValues[k]);
                                Report.WriteLine("Entered Surge value is displayed in Master carrier rate settings page");

                            }
                            else if (Convert.ToString(bumpSurgeCalculationModel.Bump).Equals(Bump))
                            {
                                Report.WriteLine("Bump value is saved in Database");
                                Assert.AreEqual(Convert.ToString(bumpSurgeCalculationModel.Bump) + "%", BumpListValues[k]);
                                Report.WriteLine("Entered Bump value is displayed in Master carrier rate settings page");
                            }
                            else if (Convert.ToString(bumpSurgeCalculationModel.Surge).Equals(Surge))
                            {
                                Report.WriteLine("Surge value is saved in Database");
                                Assert.AreEqual(Convert.ToString(bumpSurgeCalculationModel.Surge) + "%", SurgeListValues[k]);
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
                            IsElementDisabled(attributeName_xpath, CarrierAllValues_Xpath, carrierListValues[k]);
                            Report.WriteLine("Bump and Surge value is not updated since its excluded carrier");
                        }

                    }
                }
            }


            else
            {
                Report.WriteLine("No Carriers Found");
            }
        }



        [Then(@"the values for all carriers will be saved to the database for all customers, and their sub-customers (.*),(.*)")]
        public void ThenTheValuesForAllCarriersWillBeSavedToTheDatabaseForAllCustomersAndTheirSub_Customers(string Bump, string Surge)
        {
            IList<IWebElement> carriersUI = GlobalVariables.webDriver.FindElements(By.XPath(CarrierAllValues_Xpath));
            if (carriersUI.Count > 0)
            {
                List<string> carrierListValues = ObjWebElementOperations.GetListFromIWebElement(carriersUI);

                IList<IWebElement> BumpvaluesUI = GlobalVariables.webDriver.FindElements(By.XPath(Bump_ColumnValues_Xpath));
                List<string> BumpListValues = ObjWebElementOperations.GetListFromIWebElement(BumpvaluesUI);


                IList<IWebElement> SurgevaluesUI = GlobalVariables.webDriver.FindElements(By.XPath(Surge_ColumnValues_Xpath));
                List<string> SurgeListValues = ObjWebElementOperations.GetListFromIWebElement(SurgevaluesUI);
                List<string> ExpStations = new List<string>();
                List<string> Stations = DBHelper.GetAllStationName();
                foreach (var v in Stations)
                {
                    ExpStations.Add(v);
                }
                for (int i = 0; i <= ExpStations.Count; i++)
                {
                    List<CustomerSetup> CustomerVal = DBHelper.GetAllCustomersForAllStations(ExpStations[i]);
                    for (int j = 0; j <= CustomerVal.Count; j++)
                    {
                        for (int k = 0; k <= carrierListValues.Count; k++)
                        {
                            BumpSurgeCustomerSetUp setup = DBHelper.GetBumpSurgeFromDB(carrierListValues[k], CustomerVal[j].ToString());
                            bumpSurgeCalculationModel.Bump = (setup?.Bump) ?? 0;
                            bumpSurgeCalculationModel.Surge = (setup?.Surge) ?? 0;
                            if ((bumpSurgeCalculationModel.Bump > 0 || bumpSurgeCalculationModel.Surge > 0))
                            {
                                if (Convert.ToString(bumpSurgeCalculationModel.Bump).Equals(Bump) && Convert.ToString(bumpSurgeCalculationModel.Surge).Equals(Surge))
                                {
                                    Report.WriteLine("Bump value is saved in Database");
                                    Assert.AreEqual(Convert.ToString(bumpSurgeCalculationModel.Bump) + "%", BumpListValues[k]);
                                    Report.WriteLine("Entered Bump value is displayed in Master carrier rate settings page");
                                    Report.WriteLine("Surge value is saved in Database");
                                    Assert.AreEqual(Convert.ToString(bumpSurgeCalculationModel.Surge) + "%", SurgeListValues[k]);
                                    Report.WriteLine("Entered Surge value is displayed in Master carrier rate settings page");

                                }
                                else if (Convert.ToString(bumpSurgeCalculationModel.Bump).Equals(Bump))
                                {
                                    Report.WriteLine("Bump value is saved in Database");
                                    Assert.AreEqual(Convert.ToString(bumpSurgeCalculationModel.Bump) + "%", BumpListValues[k]);
                                    Report.WriteLine("Entered Bump value is displayed in Master carrier rate settings page");
                                }
                                else if (Convert.ToString(bumpSurgeCalculationModel.Surge).Equals(Surge))
                                {
                                    Report.WriteLine("Surge value is saved in Database");
                                    Assert.AreEqual(Convert.ToString(bumpSurgeCalculationModel.Surge) + "%", SurgeListValues[k]);
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
                                IsElementDisabled(attributeName_xpath, CarrierAllValues_Xpath, carrierListValues[k]);
                                Report.WriteLine("Bump and Surge value is not updated since its excluded carrier");
                            }

                        }
                    }
                }
            }

            else
            {
                Report.WriteLine("No Carriers Found");
            }
        }

        [Then(@"the values for the selected carriers will be saved to the database for all customers, and their sub-customers (.*),(.*)")]
        public void ThenTheValuesForTheSelectedCarriersWillBeSavedToTheDatabaseForAllCustomersAndTheirSub_Customers(string Bump, string Surge)
        {
            IList<IWebElement> carriersUI = GlobalVariables.webDriver.FindElements(By.XPath(CarrierAllValues_Xpath));
            if (carriersUI.Count > 0)
            {
                List<string> carrierListValues = ObjWebElementOperations.GetListFromIWebElement(carriersUI);

                IList<IWebElement> BumpvaluesUI = GlobalVariables.webDriver.FindElements(By.XPath(Bump_ColumnValues_Xpath));
                List<string> BumpListValues = ObjWebElementOperations.GetListFromIWebElement(BumpvaluesUI);


                IList<IWebElement> SurgevaluesUI = GlobalVariables.webDriver.FindElements(By.XPath(Surge_ColumnValues_Xpath));
                List<string> SurgeListValues = ObjWebElementOperations.GetListFromIWebElement(SurgevaluesUI);
                List<string> ExpStations = new List<string>();
                List<string> Stations = DBHelper.GetAllStationName();
                foreach (var v in Stations)
                {
                    ExpStations.Add(v);
                }
                for (int i = 0; i <= ExpStations.Count; i++)
                {
                    List<CustomerSetup> CustomerVal = DBHelper.GetAllCustomersForAllStations(ExpStations[i]);
                    for (int j = 0; j <= CustomerVal.Count; j++)
                    {
                        for (int k = 0; k <= 1; k++)
                        {
                            BumpSurgeCustomerSetUp setup = DBHelper.GetBumpSurgeFromDB(carrierListValues[k], CustomerVal[j].ToString());
                            bumpSurgeCalculationModel.Bump = (setup?.Bump) ?? 0;
                            bumpSurgeCalculationModel.Surge = (setup?.Surge) ?? 0;
                            if ((bumpSurgeCalculationModel.Bump > 0 || bumpSurgeCalculationModel.Surge > 0))
                            {
                                if (Convert.ToString(bumpSurgeCalculationModel.Bump).Equals(Bump) && Convert.ToString(bumpSurgeCalculationModel.Surge).Equals(Surge))
                                {
                                    Report.WriteLine("Bump value is saved in Database");
                                    Assert.AreEqual(Convert.ToString(bumpSurgeCalculationModel.Bump) + "%", BumpListValues[k]);
                                    Report.WriteLine("Entered Bump value is displayed in Master carrier rate settings page");
                                    Report.WriteLine("Surge value is saved in Database");
                                    Assert.AreEqual(Convert.ToString(bumpSurgeCalculationModel.Surge) + "%", SurgeListValues[k]);
                                    Report.WriteLine("Entered Surge value is displayed in Master carrier rate settings page");

                                }
                                else if (Convert.ToString(bumpSurgeCalculationModel.Bump).Equals(Bump))
                                {
                                    Report.WriteLine("Bump value is saved in Database");
                                    Assert.AreEqual(Convert.ToString(bumpSurgeCalculationModel.Bump) + "%", BumpListValues[k]);
                                    Report.WriteLine("Entered Bump value is displayed in Master carrier rate settings page");
                                }
                                else if (Convert.ToString(bumpSurgeCalculationModel.Surge).Equals(Surge))
                                {
                                    Report.WriteLine("Surge value is saved in Database");
                                    Assert.AreEqual(Convert.ToString(bumpSurgeCalculationModel.Surge) + "%", SurgeListValues[k]);
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
                                IsElementDisabled(attributeName_xpath, CarrierAllValues_Xpath, carrierListValues[k]);
                                Report.WriteLine("Bump and Surge value is not updated since its excluded carrier");
                            }

                        }
                    }
                }
            }

            else
            {
                Report.WriteLine("No Carriers Found");
            }
        }

        [Then(@"the values will be saved to the database for all customers, and their sub-customers (.*),(.*)")]
        public void ThenTheValuesWillBeSavedToTheDatabaseForAllCustomersAndTheirSub_Customers(string Bump, string Surge)
        {

            string OneCarrierUI = Gettext(attributeName_xpath, CarrierOne_Xpath);
            List<string> ExpStations = new List<string>();
            List<string> Stations = DBHelper.GetAllStationName();
            foreach (var v in Stations)
            {
                ExpStations.Add(v);
            }
            for (int i = 0; i <= ExpStations.Count; i++)
            {
                List<CustomerSetup> CustomerVal = DBHelper.GetAllCustomersForAllStations(ExpStations[i]);

                for (int j = 0; j <= CustomerVal.Count; j++)
                {
                    BumpSurgeCustomerSetUp setup = DBHelper.GetBumpSurgeFromDB(OneCarrierUI, CustomerVal[j].ToString());
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

        [Then(@"Surge and Bump values will be displayed on the Master Carrier Rate Settings page (.*)")]
        public void ThenSurgeAndBumpValuesWillBeDisplayedOnTheMasterCarrierRateSettingsPage(string StationName)
        {
            string OneCarrierUI = Gettext(attributeName_xpath, CarrierOne_Xpath);
            BumpSurgeStationSetUp setup = DBHelper.GetSurgeBumpStationDB(OneCarrierUI, StationName);
            bumpSurgeCalculationModel.Bump = (setup?.Bump) ?? 0;
            bumpSurgeCalculationModel.Surge = (setup?.Surge) ?? 0;
            if ((bumpSurgeCalculationModel.Bump > 0 || bumpSurgeCalculationModel.Surge > 0))
            {

                Report.WriteLine("Bump value is saved in Station Database");
                string BumpUI = Gettext(attributeName_xpath, FirstBumpValue_Xpath);
                Assert.AreEqual(Convert.ToString(bumpSurgeCalculationModel.Bump) + "%", BumpUI);
                Report.WriteLine("Entered Bump value is displayed in Master carrier rate settings page");


                Report.WriteLine("Surge value is saved in Station Database");
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



        [Then(@"the values will be saved to the database for the station selected (.*),(.*),(.*)")]
        public void ThenTheValuesWillBeSavedToTheDatabaseForTheStationSelected(string StationName, string Bump, string Surge)
        {

            string OneCarrierUI = Gettext(attributeName_xpath, CarrierOne_Xpath);
            BumpSurgeStationSetUp setup = DBHelper.GetSurgeBumpStationDB(OneCarrierUI, StationName);
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


        [Then(@"the values will be saved to the database for all customers, and their sub-customers, associated to the station (.*),(.*),(.*)")]
        public void ThenTheValuesWillBeSavedToTheDatabaseForAllCustomersAndTheirSub_CustomersAssociatedToTheStation(string StationName, string Bump, string Surge)
        {
            List<string> ExpAcc = new List<string>();
            List<CustomerSetup> value = DBHelper.GetRecordsMappedforStationID(StationName);
            for (int j = 0; j < value.Count; j++)
            {
                string custname = value[j].CustomerName;
                ExpAcc.Add(custname);
            }

            for (int k = 0; k <= ExpAcc.Count; k++)
            {
                string OneCarrierUI = Gettext(attributeName_xpath, CarrierOne_Xpath);
                BumpSurgeCustomerSetUp setup = DBHelper.GetBumpSurgeFromDB(OneCarrierUI, ExpAcc[k]);
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

}

