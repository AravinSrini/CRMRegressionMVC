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
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Review_and_Submit
{
    [Binding]
    public class LiabilityCoverageVerbiageChange : AddShipments
    {
        [When(@"I select any carrier which is associated with Carrier Rate Settings and click on create shipment button (.*)")]
        public void WhenISelectAnyCarrierWhichIsAssociatedWithCarrierRateSettingsAndClickOnCreateShipmentButton(string Usertype)
        {
            string configURL = launchUrl;

            string resultPagrURL = configURL + "Shipment/ShipmentResultsLtl";
            if (GetURL() == resultPagrURL)
            {
                 IList<IWebElement> row = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='ShipmentResultTable']/tbody/tr"));
                    for (int i = 1; i <= row.Count; i++)
                    {
                        string verCarrierName = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + i + "]/td");
                        if (verCarrierName != "There are no rates available for this shipment.")
                        {
                            string CarrierName = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + i + "]/td[1]/div/div");

                            InsuredRateCarrier value = DBHelper.insuredCarrier(CarrierName);

                            if (value != null)
                            {

                            Report.WriteLine("Create shipment for selected carrier");
                            scrollElementIntoView(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + i + "]/td[1]/div/div");

                            if (Usertype.Equals("Internal"))
                            {
                                Click(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + i + "]/td[5]/div[5]/button");

                            }
                            else
                            {
                                Click(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + i + "]/td[4]/div[5]/button");
                            }

                            bool InsuredRate_PopUp = IsElementPresent(attributeName_xpath, InsuredValueModalHeaderTest_xpath, "Insured Rate PopUp");
                            if (InsuredRate_PopUp)
                            {
                                Click(attributeName_id, InsuredValueModal_ContinueWithoutRateButton_id);

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



        [Then(@"verify the liability covergae verbiage for carrier which has a Cost per Pound \(New\) and Cost per Pound \(Used\) Insured Rate associated in Carrier Rate Settings")]
        public void ThenVerifyTheLiabilityCovergaeVerbiageForCarrierWhichHasACostPerPoundNewAndCostPerPoundUsedInsuredRateAssociatedInCarrierRateSettings()
        {
            scrollElementIntoView(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[4]/div/div/div[1]/h4");
            bool d = IsElementPresent(attributeName_xpath, ".//*[@id='carrierlogo']", "CarrierImage"); // ---Add image path
            if (d)
            {
                Verifytext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[4]/div/div/div[2]/div/div/div[1]/div/div/span[1]", "Carrier’s Legal Liability per Pound without Insurance");
                Verifytext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[4]/div/div/div[2]/div/div/div[1]/div/div/span[4]", "Carrier’s Max Liability if Shipment is Not Insured");

            }
            else if (d != true)
            {
                Verifytext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[4]/div/div/div[2]/div/div/div[1]/div/div/span[1]", "Carrier’s Legal Liability per Pound without Insurance");
                Verifytext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[4]/div/div/div[2]/div/div/div[1]/div/div/span[4]", "Carrier’s Max Liability if Shipment is Not Insured");

            }
            else
            {
                Assert.Fail("Liability Coverage label is not displayed");
            }


        }



        [When(@"I select any carrier which is associated with Carrier Rate Settings and click on create Insured shipment button (.*)")]
        public void WhenISelectAnyCarrierWhichIsAssociatedWithCarrierRateSettingsAndClickOnCreateInsuredShipmentButton(string Usertype)
        {
           string configURL = launchUrl;

            string resultPagrURL = configURL + "Shipment/ShipmentResultsLtl";
            if (GetURL() == resultPagrURL)
            {
                    IList<IWebElement> row = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='ShipmentResultTable']/tbody/tr"));
                    for (int i = 1; i <= row.Count; i++)
                    {
                        string verCarrierName = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + i + "]/td");
                        if (verCarrierName != "There are no rates available for this shipment.")
                        {
                            string CarrierName = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + i + "]/td[1]/div/div");

                        InsuredRateCarrier value = DBHelper.insuredCarrier(CarrierName);

                        if (value != null)
                        {
                            scrollElementIntoView(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + i + "]/td[1]/div/div");
                            if (Usertype.Equals("Internal"))
                            {
                                Report.WriteLine("Create Insured shipment for selected carrier");
                                Click(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + i + "]/td[6]/div[5]/button");

                            }
                            else
                            {
                                Report.WriteLine("Create Insured shipment for selected carrier");
                                //scrollpagedown();
                                //scrollpagedown();
                                Click(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + i + "]/td[5]/div[5]/button");
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


        [Then(@"verify the liability covergae verbiage for carrier which has a Cost per Pound \(New\) and Cost per Pound \(Used\) Insured Rate associated in Carrier Rate Settings for Insured Rates")]
        public void ThenVerifyTheLiabilityCovergaeVerbiageForCarrierWhichHasACostPerPoundNewAndCostPerPoundUsedInsuredRateAssociatedInCarrierRateSettingsForInsuredRates()
        {
            scrollElementIntoView(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[4]/div/div/div[1]/h4");
            bool d = IsElementPresent(attributeName_xpath, "", "CarrierImage"); // ---Add image path
            if (d)
            {
                Verifytext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[4]/div/div/div[2]/div/div/div[1]/div/div/span[1]", "Carrier’s Legal Liability per Pound without Insurance");
                Verifytext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[4]/div/div/div[2]/div/div/div[1]/div/div/span[4]", "Carrier’s Max Liability if Shipment is Not Insured");

            }
            else
            {
                Verifytext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[4]/div/div/div[2]/div/div/div[1]/div/div/span[1]", "Carrier’s Legal Liability per Pound without Insurance");
                Verifytext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[4]/div/div/div[2]/div/div/div[1]/div/div/span[4]", "Carrier’s Max Liability if Shipment is Not Insured");

            }
        }


    }
}


 

