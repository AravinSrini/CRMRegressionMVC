using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Results
{
    [Binding]
    public class LiabilityCoverage_AllUsersSteps : AddShipments
    {
        CommonMethodsCrm crm = new CommonMethodsCrm();
        AddShipmentLTL ltl = new AddShipmentLTL();

        public decimal weight;
        
        [Then(@"I should be displayed with Cost per Pound New and Cost per Pound Used fields above Max Liability field in non guaranteed grid")]
        public void ThenIShouldBeDisplayedWithCostPerPoundNewAndCostPerPoundUsedFieldsAboveMaxLiabilityFieldInNonGuaranteedGrid()
        {
            string configURL = launchUrl;

            string resultPagrURL = configURL + "Shipment/ShipmentResultsLtl";
            if (GetURL() == resultPagrURL)
            {
                
                IList<IWebElement> row = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='ShipmentResultTable']/tbody/tr"));
                for (int i = 1; i <= row.Count; i++)
                {
                    string CarrierName = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + i + "]/td[1]/div/div");
                    if (CarrierName != "There are no rates available for this shipment.")
                    {

                        InsuredRateCarrier value = DBHelper.insuredCarrier(CarrierName);

                        if (value != null)
                        {
                            scrollElementIntoView(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr/td[1]/div/div");
                            VerifyElementPresent(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr/td[1]/div/div[2]/span[1]", "Liability Cost per Pound New");
                            VerifyElementPresent(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr/td[1]/div/div[2]/span[2]", "Liability Cost per Pound Used");

                            break;

                        }
                        else
                        {
                            Report.WriteLine("Carrier is not associated with the Carrier Rate Setting");
                        }

                    }
                    else
                    {
                        Report.WriteLine("There are no rates available on the Shipment Results page");
                    }
                }
            
            }
            else
            {
                Report.WriteLine("Not navigated to the Shipment Results page");
            }

        }

        [Then(@"Cost per Pound New and Cost per Pound Used fields should be prefixed with dollar symbol in non guaranteed grid")]
        public void ThenCostPerPoundNewAndCostPerPoundUsedFieldsShouldBePrefixedWithDollarSymbolInNonGuaranteedGrid()
        {
            string configURL = launchUrl;

            string resultPagrURL = configURL + "Shipment/ShipmentResultsLtl";
            if (GetURL() == resultPagrURL)
            {
                
                IList<IWebElement> row = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='ShipmentResultTable']/tbody/tr"));
                for (int i = 1; i <= row.Count; i++)
                {
                    string CarrierName = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + i + "]/td[1]/div/div");
                    if (CarrierName != "There are no rates available for this shipment.")
                    {
                        InsuredRateCarrier value = DBHelper.insuredCarrier(CarrierName);

                        if (value != null)
                        {
                            scrollElementIntoView(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + i + "]/td[1]/div/div");
                            bool d = IsElementPresent(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + i + "]/td[1]/div/div[2]/img", "CarrierImage");
                            if (d)
                            {
                                string New1 = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + i + "]/td[1]/div/div[3]");
                                string[] a = New1.Split(' ');
                                Report.WriteLine("User displaying with Cost per pound new field with prefix dollar");
                                string dollarnew = a[7];
                                string dollarActualnew = dollarnew.Substring(0, 1);
                                string dollarexpnew = "$";
                                Assert.AreEqual(dollarActualnew, dollarexpnew);
                                Report.WriteLine("User displaying with Cost per pound Used field with prefix dollar");
                                string dollarused = a[9];
                                string dollarActualused = dollarnew.Substring(0, 1);
                                string dollarexpused = "$";
                                Assert.AreEqual(dollarActualused, dollarexpused);
                            }
                            else
                            {
                                //string New = GetAttribute(attributeName_xpath,".//*[@id='ShipmentResultTable']/tbody/tr/td[1]/div/div[2]/span","Value");
                                //string Used = GetAttribute(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr/td[1]/div/div[2]/span[2]", "Value");
                                string New1 = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + i + "]/td[1]/div/div[2]");
                                string[] a = New1.Split(' ');
                                Report.WriteLine("User displaying with Cost per pound new field with prefix dollar");
                                string dollarnew = a[7];
                                string dollarActualnew = dollarnew.Substring(0, 1);
                                string dollarexpnew = "$";
                                Assert.AreEqual(dollarActualnew, dollarexpnew);
                                Report.WriteLine("User displaying with Cost per pound Used field with prefix dollar");
                                string dollarused = a[9];
                                string dollarActualused = dollarnew.Substring(0, 1);
                                string dollarexpused = "$";
                                Assert.AreEqual(dollarActualused, dollarexpused);

                            }
                            break;
                        }

                        else
                        {
                            Report.WriteLine("Carrier is not associated with the Carrier Rate Setting");
                        }


                    }

                    else
                    {
                        Report.WriteLine("There are no rates available on the Shipment Results page");
                    }
                }
            }
            else
            {
                Report.WriteLine("Not navigated to the Shipment Results page");
            }
            
        }


        [Then(@"Cost per Pound New and Cost per Pound Used fields values should match with DB values in non guaranteed grid")]
        public void ThenCostPerPoundNewAndCostPerPoundUsedFieldsValuesShouldMatchWithDBValuesInNonGuaranteedGrid()
        {
            string configURL = launchUrl;

            string resultPagrURL = configURL + "Shipment/ShipmentResultsLtl";
            if (GetURL() == resultPagrURL)
            {
                //bool NoShipmentsAvailable_text = IsElementPresent(attributeName_xpath, ShipResults_NoShipmentsAvailable_Text_Xpath, "There are no rates available for this shipment.");
                //if (NoShipmentsAvailable_text == false)
                //{
                    IList<IWebElement> row = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='ShipmentResultTable']/tbody/tr"));
                    for (int i = 1; i <= row.Count; i++)
                    {
                    string CarrierName = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + i + "]/td[1]/div/div");

                    if(CarrierName!= "There are no rates available for this shipment.")
                    { 
                        InsuredRateCarrier value = DBHelper.insuredCarrier(CarrierName);                        

                        if (value != null)
                        {
                            string dbCostperPoundNew = value.CostPerPoundNew;
                            string dbCostperPoundUsed = value.CostPerPoundUsed_;
                            scrollElementIntoView(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + i + "]/td[1]/div/div");
                            bool d = IsElementPresent(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + i + "]/td[1]/div/div[2]/img", "CarrierImage");
                            if (d)
                            {
                                string New1 = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + i + "]/td[1]/div/div[3]");
                                string[] a = New1.Split(' ');                                
                                string dollarnew = a[7];
                                string dollarActualnew = dollarnew.Remove(0, 1);
                                Assert.AreEqual(dbCostperPoundNew, dollarActualnew);                                                                
                                string dollarused = a[9];
                                string dollarActualUsed = dollarused.Remove(0, 1);
                                Assert.AreEqual(dbCostperPoundUsed, dollarActualUsed);
                            }
                            else
                            {
                                string New1 = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + i + "]/td[1]/div/div[2]");
                                string[] a = New1.Split(' ');
                                string dollarnew = a[7];
                                string dollarActualnew = dollarnew.Remove(0, 1);                                
                                Assert.AreEqual(dbCostperPoundNew, dollarActualnew);
                                string dollarused = a[9];
                                string dollarActualUsed = dollarused.Remove(0, 1);
                                Assert.AreEqual(dbCostperPoundUsed, dollarActualUsed);

                            }
                            break;
                        }

                        else
                        {
                            Report.WriteLine("Carrier is not associated with the Carrier Rate Setting");
                        }

                    }
                    else
                    {
                        Report.WriteLine("There are no rates available on the Shipment Results page");
                    }
                }

                
            }
            else
            {
                Report.WriteLine("Not navigated to the Shipment Results page");
            }
        }

        [Then(@"Verify the Maximum Liability Calculation for both New and Used values (.*)")]
        public void ThenVerifyTheMaximumLiabilityCalculationForBothNewAndUsedValues(string weight)
        {
            IList<IWebElement> row = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='ShipmentResultTable']/tbody/tr"));
            for (int i = 1; i <= row.Count; i++)
            {
                string CarrierName = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + i + "]/td[1]/div/div");

                InsuredRateCarrier value = DBHelper.insuredCarrier(CarrierName);
               

                if (value != null)
                {
                    string costperNew = value.CostPerPoundNew;
                    decimal costper_New = Convert.ToDecimal(costperNew);

                    string costperUsed = value.CostPerPoundUsed_;
                    decimal costper_Used = Convert.ToDecimal(costperUsed);

                    string maxLiaNew = value.MaximumLiabilityNew__;
                    decimal maxLia_New = Convert.ToDecimal(maxLiaNew);

                    string maxLiaUsed = value.MaximumLiabilityUsed__;
                    decimal maxLia_Used = Convert.ToDecimal(maxLiaUsed);
                    
                    bool d = IsElementPresent(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + i + "]/td[1]/div/div[2]/img", "CarrierImage");
                    if (d)
                    {
                        string New1 = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr/td[1]/div/div[4]");
                        string[] a = New1.Split(' ');
                        string dollarnew = a[7];                       
                        
                        string dollarused = a[9];

                        decimal calNew = (costper_New * Convert.ToDecimal(weight));
                        decimal calUsed = (costper_Used * Convert.ToDecimal(weight));
                        if (calNew > maxLia_New)
                        {
                            Report.WriteLine("UI and Calculated data is matching");
                            Assert.AreEqual(maxLia_New, Convert.ToDecimal(dollarnew));
                        }
                        else
                        {
                            Report.WriteLine("UI and Calculated data is matching");
                            Assert.AreEqual(calNew, Convert.ToDecimal(dollarnew));
                        }

                        if (calUsed > maxLia_Used)
                        {
                            Report.WriteLine("UI and Calculated data is matching");
                            Assert.AreEqual(maxLia_Used, Convert.ToDecimal(dollarused));
                        }
                        else
                        {
                            Report.WriteLine("UI and Calculated data is matching");
                            Assert.AreEqual(calUsed, Convert.ToDecimal(dollarused));
                        }


                    }
                    else
                    {
                        string New1 = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr/td[1]/div/div[3]");
                        string[] a = New1.Split(' ');
                        string dollarnew = a[9];               
                        
                        string dollarused = a[12];
                       
                        decimal calNew = (costper_New * 1000);                        
                        decimal calUsed = (costper_Used * 1000);
                        if (calNew > maxLia_New)
                        {
                            Report.WriteLine("UI and Calculated data is matching");
                            Assert.AreEqual(maxLiaNew, Convert.ToDecimal(dollarnew));
                        }
                        else
                        {
                            Report.WriteLine("UI and Calculated data is matching");
                            Assert.AreEqual(calNew, Convert.ToDecimal(dollarnew));
                        }

                        if (calUsed > maxLia_Used)
                        {
                            Report.WriteLine("UI and Calculated data is matching");
                            Assert.AreEqual(maxLia_Used, Convert.ToDecimal(dollarused));
                        }
                        else
                        {
                            Report.WriteLine("UI and Calculated data is matching");
                            Assert.AreEqual(calUsed, Convert.ToDecimal(dollarused));
                        }
                    }
                    break;
                }
                else
                {
                    Report.WriteLine("Carrier is not associated with the Carrier Rate Setting");
                }
            }
        }


        [When(@"LTL carrier has Cost per Pound New Insured rate assiciated in Carrier Rate Settings")]
        public void WhenLTLCarrierHasCostPerPoundNewInsuredRateAssiciatedInCarrierRateSettings()
        {
            IList<IWebElement> row = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='ShipmentResultTable']/tbody/tr"));
            for (int i = 1; i <= row.Count; i++)
            {
                string CarrierName = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + i + "]/td[1]/div/div");

                InsuredRateCarrier value = DBHelper.insuredCarrier(CarrierName);
                
                if (value != null)
                {
                    GuaranteedCarrier value1 = DBHelper.guaranteedCarrier(CarrierName);
                    string gCarrierName = value1.CarrierName;

                    if (value1 != null)
                    {

                        scrollElementIntoView(attributeName_xpath, ShipResults_GuaranteedColumnHeader_CARRIER_Xpath);
                        IList<IWebElement> guaranteedRatesRow = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='GuaranteedResultTable']/tbody/tr"));
                        for (int j = 1; j <= row.Count; j++)
                        {
                            string guaranteedCarrierName = Gettext(attributeName_xpath, ".//*[@id='GuaranteedResultTable']/tbody/tr[" + j + "]/td[1]/div/div[1]");
                            if (guaranteedCarrierName == gCarrierName)
                            {
                                bool d = IsElementPresent(attributeName_xpath, ".//*[@id='GuaranteedResultTable']/tbody/tr[" + j + "]/td[1]/div/div[2]/img", "CarrierImage");
                                if (d)
                                {

                                    Verifytext(attributeName_xpath, ".//*[@id='GuaranteedResultTable']/tbody/tr[" + j + "]/td[1]/div/div[3]/label", "Carrier’s Legal Liability per Pound without Insurance");
                                    Verifytext(attributeName_xpath, ".//*[@id='GuaranteedResultTable']/tbody/tr[" + j + "]/td[1]/div/div[4]/label", "Carrier’s Max Liability if Shipment is Not Insured");
                                }
                                else
                                {

                                    Verifytext(attributeName_xpath, ".//*[@id='GuaranteedResultTable']/tbody/tr[" + j + "]/td[1]/div/div[2]/label", "Carrier’s Legal Liability per Pound without Insurance");
                                    Verifytext(attributeName_xpath, ".//*[@id='GuaranteedResultTable']/tbody/tr[" + j + "]/td[1]/div/div[3]/label", "Carrier’s Max Liability if Shipment is Not Insured");

                                }
                                break;

                            }
                        }
                        break;

                    }
                    else
                    {
                        Report.WriteLine("Carrier is not associated with the Guaranteed Rates Carrier Rate ");
                    }
                }

                else
                {
                    Report.WriteLine("Carrier is not associated with the Carrier Rate Setting");
                }
            }
        }

        [Then(@"I will see only the New Maximum Liability Calculation amount is displayed (.*)")]
        public void ThenIWillSeeOnlyTheNewMaximumLiabilityCalculationAmountIsDisplayed(string weight)
        {

            IList<IWebElement> row = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='ShipmentResultTable']/tbody/tr"));
            for (int i = 1; i <= row.Count; i++)
            {
                string CarrierName = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + i + "]/td[1]/div/div");

                InsuredRateCarrier value = DBHelper.insuredCarrier(CarrierName);


                if (value != null)
                {
                    string costperNew = value.CostPerPoundNew;
                    decimal costper_New = Convert.ToDecimal(costperNew);

                    string costperUsed = value.CostPerPoundUsed_;
                    decimal costper_Used = Convert.ToDecimal(costperUsed);

                    string maxLiaNew = value.MaximumLiabilityNew__;
                    decimal maxLia_New = Convert.ToDecimal(maxLiaNew);

                    string maxLiaUsed = value.MaximumLiabilityUsed__;
                    decimal maxLia_Used = Convert.ToDecimal(maxLiaUsed);

                    bool d = IsElementPresent(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + i + "]/td[1]/div/div[2]/img", "CarrierImage");
                    if (d)
                    {
                        string New1 = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr/td[1]/div/div[4]");
                        string[] a = New1.Split(':');
                        string dollarnew = a[1];
                        string dollarnew1 = dollarnew.Remove(0, 2);

                        decimal calNew = (costper_New * Convert.ToDecimal(weight));
                        decimal calUsed = (costper_Used * Convert.ToDecimal(weight));
                        if (calNew > maxLia_New)
                        {
                            Report.WriteLine("UI and Calculated data is matching");
                            Assert.AreEqual(maxLia_New, Convert.ToDecimal(dollarnew1));
                        }
                        else
                        {
                            Report.WriteLine("UI and Calculated data is matching");
                            Assert.AreEqual(calNew, Convert.ToDecimal(dollarnew1));
                        }

                    }
                    else
                    {
                        string New1 = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr/td[1]/div/div[3]");
                        string[] a = New1.Split(':');
                        string dollarnew = a[1];
                        string dollarnew1 = dollarnew.Remove(0, 2);                        

                        decimal calNew = (costper_New * Convert.ToDecimal(weight));
                        decimal calUsed = (costper_Used * Convert.ToDecimal(weight));
                        if (calNew > maxLia_New)
                        {
                            Report.WriteLine("UI and Calculated data is matching");
                            Assert.AreEqual(maxLiaNew, Convert.ToDecimal(dollarnew1));
                        }
                        else
                        {
                            Report.WriteLine("UI and Calculated data is matching");
                            Assert.AreEqual(calNew, Convert.ToDecimal(dollarnew1));
                        }

                    }
                    break;
                }
                else
                {
                    Report.WriteLine("Carrier is not associated with the Carrier Rate Setting");
                }
            }
        }

        [Given(@"I enter values in add shipment ltl page (.*), (.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*) and (.*)")]
        public void GivenIEnterValuesInAddShipmentLtlPageAnd(string Usertype,
            string CustomerName,
            string originName,
            string originAddr1,
            string originZipcode,
            string destinationName,
            string destinationAddr1,
            string destinationZipcode,
            string Classification,
            string nmfc,
            string quantity,
            string weight,
            string itemdesc, 
            string WeightType)
        {
            ltl.NaviagteToShipmentList();
            ltl.SelectCustomerFromShipmentList(Usertype, CustomerName);

            ltl.AddShipmentOriginData(originName, originAddr1, originZipcode);
            ltl.AddShipmentDestinationData(destinationName, destinationAddr1, destinationZipcode);
        }


        [Then(@"I will see only the Used Maximum Liability Calculation amount is displayed (.*)")]
        public void ThenIWillSeeOnlyTheUsedMaximumLiabilityCalculationAmountIsDisplayed(string weight)
        {

            IList<IWebElement> row = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='ShipmentResultTable']/tbody/tr"));
            for (int i = 1; i <= row.Count; i++)
            {
                string CarrierName = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + i + "]/td[1]/div/div");

                InsuredRateCarrier value = DBHelper.insuredCarrier(CarrierName);


                if (value != null)
                {
                    string costperNew = value.CostPerPoundNew;
                    decimal costper_New = Convert.ToDecimal(costperNew);

                    string costperUsed = value.CostPerPoundUsed_;
                    decimal costper_Used = Convert.ToDecimal(costperUsed);

                    string maxLiaNew = value.MaximumLiabilityNew__;
                    decimal maxLia_New = Convert.ToDecimal(maxLiaNew);

                    string maxLiaUsed = value.MaximumLiabilityUsed__;
                    decimal maxLia_Used = Convert.ToDecimal(maxLiaUsed);
                    decimal calNew = (costper_New * Convert.ToDecimal(weight));
                    decimal calUsed = (costper_Used * Convert.ToDecimal(weight));

                    bool d = IsElementPresent(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + i + "]/td[1]/div/div[2]/img", "CarrierImage");
                    if (d)
                    {
                        string Used1 = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr/td[1]/div/div[4]");
                        string[] a = Used1.Split(':');
                        string dollarused = a[1];
                        string dollarused1 = dollarused.Remove(0, 2);

                        //decimal calNew = (costper_New * Convert.ToDecimal(weight));
                        //decimal calUsed = (costper_Used * Convert.ToDecimal(weight));
                        if (calUsed > maxLia_Used)
                        {
                            Report.WriteLine("UI and Calculated data is matching");
                            Assert.AreEqual(maxLia_New, Convert.ToDecimal(dollarused1));
                        }
                        else
                        {
                            Report.WriteLine("UI and Calculated data is matching");
                            Assert.AreEqual(calNew, Convert.ToDecimal(dollarused1));
                        }

                    }
                    else
                    {
                        string Used1 = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr/td[1]/div/div[3]");
                        string[] a = Used1.Split(':');
                        string dollarused = a[1];
                        string dollarused1 = dollarused.Remove(0, 2);

                        //decimal calNew = (costper_New * Convert.ToDecimal(weight));
                        //decimal calUsed = (costper_Used * Convert.ToDecimal(weight));
                        if (calUsed > maxLia_Used)
                        {
                            Report.WriteLine("UI and Calculated data is matching");
                            Assert.AreEqual(maxLia_Used, Convert.ToDecimal(dollarused1));
                        }
                        else
                        {
                            Report.WriteLine("UI and Calculated data is matching");
                            Assert.AreEqual(calUsed, Convert.ToDecimal(dollarused1));
                        }

                    }
                    break;
                }
                else
                {
                    Report.WriteLine("Carrier is not associated with the Carrier Rate Setting");
                }
            }
        }



        [Then(@"Entered weight in kilos is converted to Pound to calculate the Maximum Liability and I will see only the New Maximum Liability Calculation amount is displayed (.*)")]
        public void ThenEnteredWeightInKilosIsConvertedToPoundToCalculateTheMaximumLiabilityAndIWillSeeOnlyTheNewMaximumLiabilityCalculationAmountIsDisplayed(string weight)
        {
            IList<IWebElement> row = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='ShipmentResultTable']/tbody/tr"));
            for (int i = 1; i <= row.Count; i++)
            {
                string CarrierName = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + i + "]/td[1]/div/div");

                InsuredRateCarrier value = DBHelper.insuredCarrier(CarrierName);


                if (value != null)
                {
                    string costperNew = value.CostPerPoundNew;
                    decimal costper_New = Convert.ToDecimal(costperNew);

                    string costperUsed = value.CostPerPoundUsed_;
                    decimal costper_Used = Convert.ToDecimal(costperUsed);

                    string maxLiaNew = value.MaximumLiabilityNew__;
                    decimal maxLia_New = Convert.ToDecimal(maxLiaNew);

                    string maxLiaUsed = value.MaximumLiabilityUsed__;
                    decimal maxLia_Used = Convert.ToDecimal(maxLiaUsed);

                    double calWeight1 = (Convert.ToDouble(weight)* 2.2046);                    
                    double calWeight = Math.Round(calWeight1, 2);

                    decimal calNew = (costper_New * Convert.ToDecimal(calWeight));
                    decimal Cal_New = Math.Round(calNew, 2);
                    decimal calUsed = (costper_Used * Convert.ToDecimal(calWeight));
                    decimal Cal_Used = Math.Round(calUsed, 2);


                    bool d = IsElementPresent(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + i + "]/td[1]/div/div[2]/img", "CarrierImage");
                    if (d)
                    {
                        string New1 = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr/td[1]/div/div[4]");
                        string[] a = New1.Split(':');
                        string dollarnew = a[1];
                        string dollarnew1 = dollarnew.Remove(0, 2);

                       // decimal calNew = (costper_New * Convert.ToDecimal(calWeight));
                        //decimal calUsed = (costper_Used * Convert.ToDecimal(calWeight));
                        if (Cal_New > maxLia_New)
                        {
                            Report.WriteLine("UI and Calculated data is matching");
                            Assert.AreEqual(maxLia_New, Convert.ToDecimal(dollarnew1));
                        }
                        else
                        {
                            Report.WriteLine("UI and Calculated data is matching");
                            Assert.AreEqual(Cal_New, Convert.ToDecimal(dollarnew1));
                        }

                    }
                    else
                    {
                        string New1 = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr/td[1]/div/div[3]");
                        string[] a = New1.Split(':');
                        string dollarnew = a[1];
                        string dollarnew1 = dollarnew.Remove(0, 2);

                        //decimal calNew = (costper_New * Convert.ToDecimal(calWeight));
                        //decimal calUsed = (costper_Used * Convert.ToDecimal(calWeight));
                        if (Cal_New > maxLia_New)
                        {
                            Report.WriteLine("UI and Calculated data is matching");
                            Assert.AreEqual(maxLiaNew, Convert.ToDecimal(dollarnew1));
                        }
                        else
                        {
                            Report.WriteLine("UI and Calculated data is matching");
                            Assert.AreEqual(Cal_New, Convert.ToDecimal(dollarnew1));
                        }

                    }
                    break;
                }
                else
                {
                    Report.WriteLine("Carrier is not associated with the Carrier Rate Setting");
                }
            }
        }



        [Then(@"Entered weight in kilos is converted to Pound to calculate the Maximum Liability and I will see only the Used Maximum Liability Calculation amount is displayed (.*)")]
        public void ThenEnteredWeightInKilosIsConvertedToPoundToCalculateTheMaximumLiabilityAndIWillSeeOnlyTheUsedMaximumLiabilityCalculationAmountIsDisplayed(string weight)
        {
            IList<IWebElement> row = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='ShipmentResultTable']/tbody/tr"));
            for (int i = 1; i <= row.Count; i++)
            {
                string CarrierName = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + i + "]/td[1]/div/div");

                InsuredRateCarrier value = DBHelper.insuredCarrier(CarrierName);


                if (value != null)
                {
                    string costperNew = value.CostPerPoundNew;
                    decimal costper_New = Convert.ToDecimal(costperNew);

                    string costperUsed = value.CostPerPoundUsed_;
                    decimal costper_Used = Convert.ToDecimal(costperUsed);

                    string maxLiaNew = value.MaximumLiabilityNew__;
                    decimal maxLia_New = Convert.ToDecimal(maxLiaNew);

                    string maxLiaUsed = value.MaximumLiabilityUsed__;
                    decimal maxLia_Used = Convert.ToDecimal(maxLiaUsed);

                    double calWeight1 = (Convert.ToDouble(weight) * 2.2046);                    
                    double calWeight = Math.Round(calWeight1, 2);

                    decimal calNew = (costper_New * Convert.ToDecimal(calWeight));
                    decimal Cal_New = Math.Round(calNew, 2);
                    decimal calUsed = (costper_Used * Convert.ToDecimal(calWeight));
                    decimal Cal_Used = Math.Round(calNew, 2);



                    bool d = IsElementPresent(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + i + "]/td[1]/div/div[2]/img", "CarrierImage");
                    if (d)
                    {
                        string New1 = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr/td[1]/div/div[4]");
                        string[] a = New1.Split(':');
                        string dollarnew = a[1];
                        string dollarnew1 = dollarnew.Remove(0, 2);

                       // decimal calNew = (costper_New * Convert.ToDecimal(calWeight));
                       // decimal calUsed = (costper_Used * Convert.ToDecimal(calWeight));
                        if (Cal_Used > maxLia_Used)
                        {
                            Report.WriteLine("UI and Calculated data is matching");
                            Assert.AreEqual(maxLia_Used, Convert.ToDecimal(dollarnew1));
                        }
                        else
                        {
                            Report.WriteLine("UI and Calculated data is matching");
                            Assert.AreEqual(Cal_Used, Convert.ToDecimal(dollarnew1));
                        }

                    }
                    else
                    {
                        string New1 = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr/td[1]/div/div[3]");
                        string[] a = New1.Split(':');
                        string dollarnew = a[1];
                        string dollarnew1 = dollarnew.Remove(0, 2);

                        //decimal calNew = (costper_New * Convert.ToDecimal(calWeight));
                        //decimal calUsed = (costper_Used * Convert.ToDecimal(calWeight));                        

                        if (Cal_Used > maxLia_Used)
                        {
                            Report.WriteLine("UI and Calculated data is matching");
                            Assert.AreEqual(maxLia_Used, Convert.ToDecimal(dollarnew1));
                        }
                        else
                        {
                            Report.WriteLine("UI and Calculated data is matching");
                            Assert.AreEqual(Cal_Used, Convert.ToDecimal(dollarnew1));
                        }

                    }
                    break;
                }
                else
                {
                    Report.WriteLine("Carrier is not associated with the Carrier Rate Setting");
                }
            }
        }










    }
}
