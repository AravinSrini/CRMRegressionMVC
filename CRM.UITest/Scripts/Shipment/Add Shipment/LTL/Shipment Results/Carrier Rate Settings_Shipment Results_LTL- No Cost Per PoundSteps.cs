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
    public class Carrier_Rate_Settings_Shipment_Results_LTL__No_Cost_Per_PoundSteps : ObjectRepository
    {

        [Then(@"Verify the labels, fields and verbiage change for the associated carrier on the carrier information section on Shipment Results page")]
        public void ThenVerifyTheLabelsFieldsAndVerbiageChangeForTheAssociatedCarrierOnTheCarrierInformationSectionOnShipmentResultsPage()
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
                        if (CarrierName == "YRC Freight")
                        {
                            InsuredRateCarrier value = DBHelper.insuredCarrier(CarrierName);

                            if (value != null)
                            {
                                string dbCostperPoundNew = value.CostPerPoundNew;
                                string dbCostperPoundUsed = value.CostPerPoundUsed_;
                                scrollElementIntoView(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + i + "]/td[1]/div/div");
                                bool d = IsElementPresent(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + i + "]/td[1]/div/div[2]/img", "CarrierImage");
                                if (dbCostperPoundNew == null && dbCostperPoundUsed != null)
                                {
                                    if (d)
                                    {
                                        string New1 = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + i + "]/td[1]/div/div[3]");
                                        string[] a = New1.Split('\n');
                                        string[] expected = a[1].Split(':');
                                        Assert.AreEqual(expected[0], "Used");
                                        string newValue = expected[1];
                                        Assert.AreEqual(newValue.Remove(0, 2), dbCostperPoundUsed);
                                        Report.WriteLine("Cost per pound Used value matches with DB");


                                    }
                                    else
                                    {
                                        string New1 = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + i + "]/td[1]/div/div[2]");
                                        string[] a = New1.Split('\n');
                                        string[] expected = a[1].Split(':');
                                        Assert.AreEqual(expected[0], "Used");
                                        string newValue = expected[1];
                                        Assert.AreEqual(newValue.Remove(0, 2), dbCostperPoundUsed);
                                        Report.WriteLine("Cost per pound Used value matches with DB");


                                    }
                                    break;
                                }
                                else if (dbCostperPoundUsed == null && dbCostperPoundNew != null)
                                {
                                    if (d)
                                    {
                                        string New1 = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + i + "]/td[1]/div/div[3]");
                                        string[] a = New1.Split('\n');
                                        string[] expected = a[1].Split(':');
                                        Assert.AreEqual(expected[0], "New");
                                        string newValue = expected[1];
                                        Assert.AreEqual(newValue.Remove(0, 2), dbCostperPoundNew);
                                        Report.WriteLine("Cost per pound New value matches with DB");

                                    }
                                    else
                                    {
                                        string New1 = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + i + "]/td[1]/div/div[2]");
                                        string[] a = New1.Split('\n');
                                        string[] expected = a[1].Split(':');
                                        Assert.AreEqual(expected[0], "New");
                                        string newValue = expected[1];
                                        Assert.AreEqual(newValue.Remove(0, 2), dbCostperPoundNew);
                                        Report.WriteLine("Cost per pound New value matches with DB");


                                    }
                                    break;
                                }
                                else if (dbCostperPoundNew == null && dbCostperPoundUsed == null)
                                {
                                    if (d)
                                    {
                                        string NewVerbiage = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + i + "]/td[1]/div/div[3]/label");
                                        Assert.AreEqual(NewVerbiage, "Please contact your DLS representative for carrier liability per pound without insurance");
                                        Report.WriteLine("Matches the text Please contact your DLS representative for carrier liability per pound without insurance");

                                    }
                                    else
                                    {
                                        string NewVerbiage = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + i + "]/td[1]/div/div[2]/label");
                                        Assert.AreEqual(NewVerbiage, "Please contact your DLS representative for carrier liability per pound without insurance");
                                        Report.WriteLine("Matches the text Please contact your DLS representative for carrier liability per pound without insurance");

                                    }
                                    break;
                                }
                                else if (dbCostperPoundNew != null && dbCostperPoundUsed != null)
                                {
                                    if (d)
                                    {
                                        //string New1 = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + i + "]/td[1]/div/div[3]");
                                        //string[] a = New1.Split('\n');
                                        string New1 = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + i + "]/td[1]/div/div[3]");
                                        string[] a = New1.Split('\n');
                                        string dollarnew = a[7];
                                        string dollarActualnew = dollarnew.Remove(0, 1);
                                        Assert.AreEqual(dbCostperPoundNew, dollarActualnew);
                                        string dollarused = a[9];
                                        string dollarActualUsed = dollarused.Remove(0, 1);
                                        Assert.AreEqual(dbCostperPoundUsed, dollarActualUsed);

                                    }
                                    else
                                    {
                                        //string New1 = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + i + "]/td[1]/div/div[2]");
                                        //string[] a = New1.Split('\n');
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

                            }

                            else
                            {
                                Report.WriteLine("Carrier is not associated with the Carrier Rate Setting");
                            }

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

        [Then(@"Verify the labels, fields and verbiage change for the associated carrier on the carrier information section on Review and Submit page")]
        public void ThenVerifyTheLabelsFieldsAndVerbiageChangeForTheAssociatedCarrierOnTheCarrierInformationSectionOnReviewAndSubmitPage()
        {
            scrollElementIntoView(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[4]/div/div/div[1]/h4");
            bool d = IsElementPresent(attributeName_xpath, ".//*[@id='carrierlogo']", "CarrierImage"); // ---Add image path
            string CarrierName = Gettext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[4]/div/div/div[2]/div/div/div[1]/div/span");
            InsuredRateCarrier value = DBHelper.insuredCarrier(CarrierName);
            string dbCostperPoundNew = value.CostPerPoundNew;
            string dbCostperPoundUsed = value.CostPerPoundUsed_;

            if(dbCostperPoundNew == null && dbCostperPoundUsed != null)
            {
                if (d)
                {
                    Verifytext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[4]/div/div/div[2]/div/div/div[1]/div/div/span[1]", "Carrier’s Legal Liability per Pound without Insurance");
                    //Verifytext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[4]/div/div/div[2]/div/div/div[1]/div/div/span[4]", "Carrier’s Max Liability if Shipment is Not Insured");

                }
                else if (d != true)
                {
                    Verifytext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[4]/div/div/div[2]/div/div/div[1]/div/div/span[1]", "Carrier’s Legal Liability per Pound without Insurance");
                    //Verifytext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[4]/div/div/div[2]/div/div/div[1]/div/div/span[4]", "Carrier’s Max Liability if Shipment is Not Insured");

                }
                else
                {
                    Assert.Fail("Liability Coverage label is not displayed");
                }

            }
            else if(dbCostperPoundNew != null && dbCostperPoundUsed==null)
            {
                if (d)
                {
                    Verifytext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[4]/div/div/div[2]/div/div/div[1]/div/div/span[1]", "Carrier’s Legal Liability per Pound without Insurance");
                    //Verifytext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[4]/div/div/div[2]/div/div/div[1]/div/div/span[4]", "Carrier’s Max Liability if Shipment is Not Insured");

                }
                else if (d != true)
                {
                    Verifytext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[4]/div/div/div[2]/div/div/div[1]/div/div/span[1]", "Carrier’s Legal Liability per Pound without Insurance");
                    //Verifytext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[4]/div/div/div[2]/div/div/div[1]/div/div/span[4]", "Carrier’s Max Liability if Shipment is Not Insured");

                }
                else
                {
                    Assert.Fail("Liability Coverage label is not displayed");
                }

            }
            else if(dbCostperPoundNew ==null && dbCostperPoundUsed == null)
            {
                if (d)
                {
                    Verifytext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[4]/div/div/div[2]/div/div/div[1]/div/span[2]", "Please contact your DLS representative for carrier liability per pound without insurance");
                                                     

                }
                else if (d != true)
                {
                    Verifytext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[1]/td[1]/div/div[2]/label", "Please contact your DLS representative for carrier liability per pound without insurance");

                }
                else
                {
                    Assert.Fail("Liability Coverage label is not displayed");
                }

            }

           
        }



    }
}
