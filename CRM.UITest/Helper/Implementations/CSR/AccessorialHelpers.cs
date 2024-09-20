using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.DataModels;
using CRM.UITest.Helper.Implementations.Default_Accessorials;
using CRM.UITest.Objects;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace CRM.UITest.Helper.Implementations.CSR
{
    public class AccessorialHelpers : Submit_CSR
    {
        public List<CsrCustomerAccessorial> getIndividualAccessorialsFromScreen()
        {
            Report.WriteLine("Getting individual accessorials");
            Thread.Sleep(500);
            Click(attributeName_xpath, Gainshare_Set_Individual_Accessorials_Xpath);
            WaitForElementVisible(attributeName_xpath, Gainshare_Individual_Accessorial_Modal_Xpath, "Individual Accessorial Modal");

            List<IWebElement> individualAccessorials = GlobalVariables.webDriver.FindElements(By.XPath("//div[contains(@id, 'setAccessorial')]/a/span")).ToList();
            List<IWebElement> individualGainshares = GlobalVariables.webDriver.FindElements(By.XPath("//div[contains(@id, 'setGainShareType')]/a/span")).ToList();
            List<IWebElement> individualPrices = GlobalVariables.webDriver.FindElements(By.XPath("//input[contains(@id, 'pricing-setGainshare')]")).ToList();
            List<IWebElement> individualPricesNotEmpty = individualPrices.Where(x => x.GetAttribute("value") != "").ToList();

            List<CsrCustomerAccessorial> individualAccessorialsFromScreen = new List<CsrCustomerAccessorial>();

            GetAccessorialCode getAccessorialCodeFromName = new GetAccessorialCode();

            for (int i = 0; i < individualAccessorials.Count; i++)
            {
                individualAccessorialsFromScreen.Add(new CsrCustomerAccessorial()
                {
                    AccessorialName = individualAccessorials[i].Text,
                    GainShareType = individualGainshares[i].Text,
                    AccessorialValue = individualPricesNotEmpty[i].GetAttribute("value")
                });
            }
            Report.WriteLine("Closing individual accessorial modal");
            Click(attributeName_xpath, Gainshare_Individual_Accessorial_Modal_Close_Xpath);
            WaitForElementNotVisible(attributeName_xpath, Gainshare_Individual_Accessorial_Modal_Xpath, "Individual Accessorial Modal");

            return individualAccessorialsFromScreen;
        }

        public List<CsrCustomerAccessorial> getCarrierAccessorialsFromScreen()
        {
            GetAccessorialCode getAccessorialCodeFromName = new GetAccessorialCode();
            Report.WriteLine("Getting carrier accessorials");
            int carrierAccessorialSections = GlobalVariables.webDriver.FindElements(By.XPath(Gainshare_Carrier_Accessorial_List_Xpath)).Count;
            List<CsrCustomerAccessorial> carrierAccessorialsFromScreen = new List<CsrCustomerAccessorial>();
            for (int carrierPosition = 0; carrierPosition < carrierAccessorialSections; carrierPosition++)
            {
                Thread.Sleep(500);
                string carrierSectionXpath = "//div[@id = 'addtionalItem-" + carrierPosition + "']";
                string carrierSCAC = GlobalVariables.webDriver.FindElement(By.XPath(carrierSectionXpath + Gainsshare_Carrier_ScacCode_General_Xpath)).Text;

                GlobalVariables.webDriver.FindElement(By.XPath(carrierSectionXpath + "//span[contains(@class, 'LinkShowCarrierLevelIndivAccess')]")).Click();
                WaitForElementVisible(attributeName_xpath, Gainshare_Individual_Accessorial_Modal_Xpath, "Individual Accessorial Modal");

                List<IWebElement> carrierAccessorialNames = GlobalVariables.webDriver.FindElements(By.XPath("//div[contains(@id, 'setAccessorial')]/a/span")).ToList();
                List<IWebElement> carrierGainshareTypes = GlobalVariables.webDriver.FindElements(By.XPath("//div[contains(@id, 'setGainShareType')]/a/span")).ToList();
                List<IWebElement> carrierAccessorialPrices = GlobalVariables.webDriver.FindElements(By.XPath("//input[contains(@id, 'pricing-setGainshare')]")).ToList();
                List<IWebElement> carrierPricesNotEmpty = carrierAccessorialPrices.Where(x => x.GetAttribute("value") != "").ToList();

                if (carrierPricesNotEmpty.Count > 0)
                {
                    for (int i = 0; i < carrierAccessorialNames.Count; i++)
                    {
                        carrierAccessorialsFromScreen.Add(new CsrCustomerAccessorial()
                        {
                            carrierScacCode = carrierSCAC,
                            AccessorialName = carrierAccessorialNames[i].Text,
                            GainShareType = carrierGainshareTypes[i].Text,
                            AccessorialValue = carrierPricesNotEmpty[i].GetAttribute("value")
                        });

                    }
                }

                Report.WriteLine("Closing individual accessorial modal");
                Click(attributeName_xpath, Gainshare_Individual_Accessorial_Modal_Close_Xpath);
            }

            return carrierAccessorialsFromScreen;
        }

        public void compareIndividualAccessorials(List<DefaultAccessorialSetupModel> individualAccessorialsFromDb, List<CsrCustomerAccessorial> individualAccessorialsFromScreen)
        {
            Report.WriteLine("Verifying that the individual accessorials have been added into the screen with the correct values");
            foreach (DefaultAccessorialSetupModel individualAccessorial in individualAccessorialsFromDb)
            {
                if (individualAccessorialsFromScreen.Any(x => x.AccessorialName.ToLower() == individualAccessorial.AccessorialName.ToLower()))
                {
                    CsrCustomerAccessorial indvAccessorial = individualAccessorialsFromScreen.Where(x => x.AccessorialName.ToLower() == individualAccessorial.AccessorialName.ToLower()).FirstOrDefault();

                    if (indvAccessorial.AccessorialValue != individualAccessorial.AccessorialValue.ToString() || indvAccessorial.GainShareType.ToLower() != individualAccessorial.GainshareCostingType.ToLower())
                    {
                        Report.WriteFailure("An individual accessorial has the incorrect data");
                    }
                }
                else
                {
                    Report.WriteFailure("An individual accessorial from the station was not taken from the database");
                }
            }
        }

        public void compareCarrierAccessorials(List<DefaultAccessorialSetupModel> carrierAccessorialsFromDb, List<CsrCustomerAccessorial> carrierAccessorialsFromScreen)
        {

            Report.WriteLine("Verifying that the carrier accessorials have been added into the screen with the correct values");
            foreach (DefaultAccessorialSetupModel individualAccessorial in carrierAccessorialsFromDb)
            {
                if (carrierAccessorialsFromDb.Any(x => x.AccessorialName.ToLower() == individualAccessorial.AccessorialName.ToLower()))
                {
                    CsrCustomerAccessorial indvAccessorial = carrierAccessorialsFromScreen.Where(x => x.AccessorialName.ToLower() == individualAccessorial.AccessorialName.ToLower()).FirstOrDefault();

                    if (indvAccessorial.AccessorialValue != individualAccessorial.AccessorialValue.ToString() || indvAccessorial.GainShareType.ToLower() != individualAccessorial.GainshareCostingType.ToLower() ||
                        indvAccessorial.carrierScacCode != individualAccessorial.CarrierSCAC)
                    {
                        Report.WriteFailure("A carrier accessorial has the incorrect data");
                    }
                }
                else
                {
                    Report.WriteFailure("A carrier accessorial from the station was not taken from the database");
                }
            }
        }
    }
}
