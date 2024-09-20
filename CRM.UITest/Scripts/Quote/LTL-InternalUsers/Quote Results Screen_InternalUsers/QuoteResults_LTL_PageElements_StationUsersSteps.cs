using CRM.UITest.Helper;
using CRM.UITest.Helper.ViewModel;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Quote.LTL_InternalUsers.Quote_Results_Screen_InternalUsers
{
    [Binding]
    public class QuoteResults_LTL_PageElements_StationUsersSteps : ObjectRepository
    {
        string OCity = null;
        string OState = null;
        string DCity = null;
        string DState = null;

        [Then(@"I will be navigated to Rate Results page and I will not see Create shipment and Create Insured Shipment button")]
        public void ThenIWillBeNavigatedToRateResultsPageAndIWillNotSeeCreateShipmentAndCreateInsuredShipmentButton()
        {
            string configURL = launchUrl;
            string resultPagrURL = configURL + "Rate/LtlResultsView";
            Report.WriteLine("Verifying User Navigated to Rate Results page by URL");
            if (GetURL() == resultPagrURL)
            {

                Report.WriteLine("Verifying for the absence of Create Shipment button");
                Assert.IsTrue(ElementNotPresent(attributeName_id, QuoteResults_StandardRates_CreateShipment_button_Id, "StandardShipmentButton"));

                Report.WriteLine("Verifying for the absence of Create Insured Shipment button");
                Assert.IsTrue(ElementNotPresent(attributeName_id, QuoteResults_StandardInsuredRates_CreateShipment_button_Id, "StandardInsuredShipmentButton"));
            }

            else
            {
                Report.WriteLine("No Rates available for the selected Customer");
            }

        }

        [Then(@"I will see Est Cost and Est Margin label")]
        public void ThenIWillSeeEstCostAndEstMarginLabel()
        {
            string configURL = launchUrl;
            string resultPagrURL = configURL + "Rate/LtlResultsView";
            Report.WriteLine("Verifying User Navigated to Rate Results page by URL");
            if (GetURL() == resultPagrURL)
            {

                Report.WriteLine("Verifying for the presence of Est Cost label");
                Assert.IsTrue(IsElementPresent(attributeName_xpath, QuoteResults_EstCost_Text_Xpath, "EstCost label"));
                string EstCostText_UI = Gettext(attributeName_xpath, QuoteResults_EstCost_Text_Xpath);
                Assert.AreEqual("EST COST", EstCostText_UI);

                Report.WriteLine("Verifying for the Est Margin label");
                string EstMarginStd_UI = Gettext(attributeName_xpath, QuoteResults_EstMargin_StdFirstCarrier_Text_Xpath);
                Assert.IsTrue(EstMarginStd_UI.Contains("Est Margin"));
                string EstMarginStdIns_UI = Gettext(attributeName_xpath, QuoteResults_EstMargin_StdInsFirstCarrier_Text_Xpath);
                Assert.IsTrue(EstMarginStd_UI.Contains("Est Margin"));
            }

            else
            {
                Report.WriteLine("No Rates available for the selected Customer");
            }

        }

        [Then(@"I will see Fuel Linehaul and Accessorials labels")]
        public void ThenIWillSeeFuelLinehaulAndAccessorialsLabels()
        {
            string configURL = launchUrl;
            string resultPagrURL = configURL + "Rate/LtlResultsView";
            Report.WriteLine("Verifying User Navigated to Rate Results page by URL");
            if (GetURL() == resultPagrURL)
            {
                Report.WriteLine("Verifying for the presence of Fuel label");
                string Fuel_StdText_UI = Gettext(attributeName_xpath, QuoteResults_Fuel_FirstCarrierText_Xpath);
                Assert.IsTrue(Fuel_StdText_UI.Contains("Fuel"));


                Report.WriteLine("Verifying for the presence of Linehaul label");
                string Linehaul_StdText_UI = Gettext(attributeName_xpath, QuoteResults_LineHaul_FirstCarrierText_Xpath);
                Assert.IsTrue(Linehaul_StdText_UI.Contains("Line Haul"));

                Report.WriteLine("Verifying for the Presence Accessorials Label");
                string Accessoral_StdTextUI = Gettext(attributeName_xpath, QuoteResults_Accessorial_FirstCarrierText_Xpath);
                Assert.IsTrue(Accessoral_StdTextUI.Contains("Accessorials"));
            }

            else
            {
                Report.WriteLine("No Rates available for the selected Customer");
            }
        }

        [Then(@"API Response of the Est Cost,Fuel,LineHaul and Accessorials should match with UI")]
        public void ThenAPIResponseOfTheEstCostFuelLineHaulAndAccessorialsShouldMatchWithUI()
        {
            ScenarioContext.Current.Pending();
        }


        [When(@"I enter valid data in zipcode (.*) in Origin Section")]
        public void WhenIEnterValidDataInZipcodeInOriginSection(string OriginZip)
        {

            Report.WriteLine("Clearing if any default Address present in Origin section");
            Thread.Sleep(1000);
            string _selectedAddress = GetValue(attributeName_id, LTL_SavedOriginAddressDropdown_Id, "value");

            if (_selectedAddress != "" || _selectedAddress != string.Empty)
            {
                Click(attributeName_id, ClearAddress_OriginId);
                Thread.Sleep(4000);
            }

            SendKeys(attributeName_id, LTL_OriginZipPostal_Id, OriginZip);

            OCity = Gettext(attributeName_id, LTL_OriginCity_Id);
            OState = Gettext(attributeName_xpath, LTL_Origin_AutoPopulate_StateValue_xpath);

        }

        [When(@"I enter valid data in zipcode (.*) in Destination section")]
        public void WhenIEnterValidDataInZipcodeInDestinationSection(string DestinationZip)
        {
            Report.WriteLine("Clearing if any default Address present in Destination section");
            string _selectedAddress = GetValue(attributeName_id, LTL_SavedDestinationAddressDropdown_Id, "value");

            if (_selectedAddress != "" || _selectedAddress != string.Empty)
            {
                Click(attributeName_id, ClearAddress_DestId);
                Thread.Sleep(3000);
            }
            Report.WriteLine("Entering data in destination section");
            SendKeys(attributeName_id, LTL_DestinationZipPostal_Id, DestinationZip);

            DCity = Gettext(attributeName_id, LTL_OriginCity_Id);
            DState = Gettext(attributeName_xpath, LTL_Origin_AutoPopulate_StateValue_xpath);

        }

        //[When(@"I enter valid data in Item information section (.*), (.*)")]
        //public void WhenIEnterValidDataInItemInformationSection(string Classification, string Weight)
        //{
        //    Report.WriteLine("Enter details in item section");
        //    //Click(attributeName_id, LTL_Classification_Id);
        //    Click(attributeName_id, LTL_Weight_Id);
        //    Click(attributeName_id, LTL_Classification_Id);
        //    IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(LTL_ClassificationValues_Xpath));
        //    int DropDownCount = DropDownList.Count;
        //    for (int i = 0; i < DropDownCount; i++)
        //    {
        //        if (DropDownList[i].Text == Classification)
        //        {
        //            DropDownList[i].Click();
        //            break;
        //        }
        //    }
        //    SendKeys(attributeName_id, LTL_Weight_Id, Weight);
        //    Thread.Sleep(3000);
        //}



        [Then(@"API Response of the Est Margin should match with UI(.*), (.*) ,(.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*),(.*),(.*), (.*), (.*),(.*),(.*)")]
        public void ThenAPIResponseOfTheEstMarginShouldMatchWithUI(string Account, string Service, string OriginCity, string OriginZip, string OriginState, string OriginCountry, string DestinationCity, string DestinationZip, string DestinationState, string DestinationCountry, string Classification, double Quantity, string QuantityUNIT, double Weight, string WeightUnit, string Username)
        {
            List<RateResultCarrierViewModel> apirespone = GetRatesAndCarriersAPICall.CallRateRequestApi(Account, Service, OriginCity, OriginZip, OriginState, OriginCountry,
                DestinationCity, DestinationZip, DestinationState, DestinationCountry, Classification, Quantity, QuantityUNIT, Weight, WeightUnit, Username, false);
            List<string> carrierNames = apirespone.Select(p => p.CarrierName).ToList();
            List<string> carrierNames1 = apirespone.Select(p => p.EstMargin).ToList();
            string carriername = apirespone[0].CarrierName;
            //Getting est cost values from API for first carrier
            decimal FuelCost = apirespone[0].EstCharges[0].FuelCost;
            decimal LineHaul = apirespone[0].EstCharges[0].LineHaul;
            decimal Assessorial = apirespone[0].EstCharges[0].Assessorial;
            decimal TotalCost = apirespone[0].EstCharges[0].TotalCost;
            string EstMargin = apirespone[0].EstMargin;

            if (FuelCost == null)
            {
                string FuelCostUI = GlobalVariables.webDriver.FindElement(By.XPath("//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[4]/ul[1]/li[2]")).Text;
                FuelCostUI.Equals("N/A");
            }
            else
            {
                //Getting Fuel Cost from UI First row and matching with API
                string FuelCostUI = GlobalVariables.webDriver.FindElement(By.XPath("//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[4]/ul[1]/li[2]")).Text;
                string FuelCostUI1 = Regex.Replace(FuelCostUI, @"[^0-9.]+", "");
                double FuelCostUI11 = double.Parse(FuelCostUI1);
                FuelCostUI11.Equals(FuelCost);
            }

            if (LineHaul == null)
            {
                string LineHaulUI = GlobalVariables.webDriver.FindElement(By.XPath("//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[4]/ul[1]/li[3]")).Text;
                LineHaulUI.Equals("N/A");
            }
            else
            {
                //Getting Line haul Cost from UI First row and matching with API
                string LineHaulUI = GlobalVariables.webDriver.FindElement(By.XPath("//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[4]/ul[1]/li[3]")).Text;
                string LineHaulUI1 = Regex.Replace(LineHaulUI, @"[^0-9.]+", "");
                double LineHaulUI11 = double.Parse(LineHaulUI1);
                LineHaulUI1.Equals(LineHaul);
            }

            if (TotalCost == null)
            {
                string TotalCostUI = GlobalVariables.webDriver.FindElement(By.XPath("//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[4]/ul[1]/li[1]")).Text;
                TotalCostUI.Equals("N/A");
            }
            else {
                //Getting Total Cost from UI First row and matching with API
                string TotalCostUI = GlobalVariables.webDriver.FindElement(By.XPath("//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[4]/ul[1]/li[1]")).Text;
                string TotalCostUI1 = Regex.Replace(TotalCostUI, @"[^0-9.]+", "");
                double TotalCostUI11 = double.Parse(TotalCostUI1);
                TotalCostUI11.Equals(TotalCost);
            }
            if (Assessorial == null)
            {
                string AssessorialUI = GlobalVariables.webDriver.FindElement(By.XPath("//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[4]/ul[1]/li[4]")).Text;
                AssessorialUI.Equals("N/A");
            }
            else
            {
                //Getting Assessorial from UI First row and matching with API
                string AssessorialUI = GlobalVariables.webDriver.FindElement(By.XPath("//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[4]/ul[1]/li[4]")).Text;
                string AssessorialUI1 = Regex.Replace(AssessorialUI, @"[^0-9.]+", "");
                double AssessorialUI11 = double.Parse(AssessorialUI1);
                AssessorialUI11.Equals(Assessorial);
            }

            if (EstMargin == null)
            {
                string EstMarginUI = GlobalVariables.webDriver.FindElement(By.XPath("//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[5]/ul[2]/li/b")).Text;
                EstMarginUI.Equals("N/A");
            }
            else
            {
                //Getting Est Margin Cost from UI First row and matching with API
                string EstMarginUI = GlobalVariables.webDriver.FindElement(By.XPath("//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[5]/ul[2]/li/b")).Text;
                string EstMarginUI1 = Regex.Replace(EstMarginUI, @"[^0-9.]+", "");
                double EstMarginUI111 = double.Parse(EstMarginUI1);
                EstMarginUI111.Equals(EstMargin);
            }



            int APICount = carrierNames.Count;
            IList<IWebElement> carrierNameUI = GlobalVariables.webDriver.FindElements(By.XPath(ltlcarriersall_xpath));
            int carrierNameCountUI = carrierNameUI.Count();

            string firstCarrierUI = carrierNameUI[0].Text;
            carriername.Contains(firstCarrierUI);

            //Verifying carrier name in UI with API
            //for (int y = 0; y < carrierNameCountUI; y++)
            //{
            //    string value = carrierNameUI[y].Text;
            //    if (carrierNames.Contains(value))
            //    {
            //        Console.WriteLine(value + "Carrier Found");
            //    }
            //    else
            //    {
            //        throw new Exception("Carrier not Found");
            //    }
            //}
        }
    }

 }

