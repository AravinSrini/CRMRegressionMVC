using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
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

namespace CRM.UITest.Scripts.Carrier_Website 
{
    [Binding]
    public class Carrier_Website_Logins_Layout___Non_AdminSteps : MaintenaceTools
    {
        CommonMethodsCrm crm = new CommonMethodsCrm();
        AddQuoteLTL ltl = new AddQuoteLTL();

        [When(@"I am on the Carrier Website Logins page for the non admin user")]
        public void WhenIAmOnTheCarrierWebsiteLoginsPageForTheNonAdminUser()
        {
            VerifyElementPresent(attributeName_cssselector, TMS_Launch_Icon_css, "TMS Launch Icon");

            Report.WriteLine("Clicking on Carrier website button");
            OnMouseOver(attributeName_cssselector, TMS_Launch_Icon_css);
            scrollElementIntoView(attributeName_xpath, TMS_Launch_CarrierWebsite_Option_xpath);
            Click(attributeName_xpath, TMS_Launch_CarrierWebsite_Option_xpath);
            Thread.Sleep(2000);            
            
            WaitForElementVisible(attributeName_xpath, CarrierWebsite_Title_NonAdmin_Xpath, "Carrier Website Page Header");
            Report.WriteLine("Verifying carrier website login page");
            Verifytext(attributeName_xpath, CarrierWebsite_Title_NonAdmin_Xpath, "Carrier Website Logins");
            VerifyElementNotPresent(attributeName_xpath, BackToMaintenanceTools_Button_Xpath, "Back to Maintenance Tools");
        }


        [Then(@"I can see the Website with option Copy to Clipboard icon, Login with Copy to Clipboard icon, Password with Copy to Clipboard icon")]
        public void ThenICanSeeTheWebsiteWithOptionCopyToClipboardIconLoginWithCopyToClipboardIconPasswordWithCopyToClipboardIcon()
        {
            IList<IWebElement> row = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='CarrierWebsiteLogin']/tbody/tr"));
            for (int j = 1; j <= row.Count; j++)
            {

                VerifyElementPresent(attributeName_xpath, ".//*[@id='CarrierWebsiteLogin']/tbody/tr/td[4]/a[@id='websitecopypopup']", "websitecopypopup");
                VerifyElementPresent(attributeName_xpath, ".//*[@id='CarrierWebsiteLogin']/tbody/tr[1]/td[5]/a/span", "Login Copy Icon");
                VerifyElementPresent(attributeName_xpath, ".//*[@id='CarrierWebsiteLogin']/tbody/tr[1]/td[6]/a[1]/span", "Password Copy Icon");
                VerifyElementPresent(attributeName_xpath, ".//*[@id='CarrierWebsiteLogin']/tbody/tr/td[6]/a[@id='loginpopup']", "PasswordEdit Icon");

                break;
            }
        }


        [Then(@"I should see all columns SCAC, Carrier Name, Account Number, Website with option Copy to Clipboard icon, Login with Copy to Clipboard icon, Password with Copy to Clipboard icon and Notes Column")]
        public void ThenIShouldSeeAllColumnsSCACCarrierNameAccountNumberWebsiteWithOptionCopyToClipboardIconLoginWithCopyToClipboardIconPasswordWithCopyToClipboardIconAndNotesColumn()
        {
            IList<IWebElement> row = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='CarrierWebsiteLogin']/tbody/tr"));
            for (int j = 1; j <= row.Count; j++)
            {

                VerifyElementPresent(attributeName_xpath, ".//*[@id='CarrierWebsiteLogin']/tbody/tr/td[4]/a[@id='websitecopypopup']", "websitecopypopup");
                VerifyElementPresent(attributeName_xpath, ".//*[@id='CarrierWebsiteLogin']/tbody/tr[1]/td[5]/a/span", "Login Copy Icon");
                VerifyElementPresent(attributeName_xpath, ".//*[@id='CarrierWebsiteLogin']/tbody/tr[1]/td[6]/a[1]/span", "Password Copy Icon");
                VerifyElementNotPresent(attributeName_xpath, ".//*[@id='CarrierWebsiteLogin']/tbody/tr/td[6]/a[@id='loginpopup']", "PasswordEdit Icon");

                break;
            }
        }


        [Then(@"the data displayed in the grid should match with the DB")]
        public void ThenTheDataDisplayedInTheGridShouldMatchWithTheDB()
        {
            IList<IWebElement> row = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='CarrierWebsiteLogin']/tbody/tr"));
            for (int j = 1; j <= row.Count; j++)
            {

                string scac = Gettext(attributeName_xpath, ".//*[@id='CarrierWebsiteLogin']/tbody/tr/td[" + j +"]/span");


                CRM.UITest.Entities.Proxy.CarrierWebsite carrierValue = new CRM.UITest.Entities.Proxy.CarrierWebsite();
                carrierValue = DBHelper.GetCarrierDetails(scac);
                                
                string scac1 = Gettext(attributeName_xpath, ".//*[@id='CarrierWebsiteLogin']/tbody/tr/td[" + j + "]");
                Assert.AreEqual(scac1, carrierValue.Scac);

                int k = j + 1;
                string carrier = Gettext(attributeName_xpath, ".//*[@id='CarrierWebsiteLogin']/tbody/tr/td[" + k + "]");
                Assert.AreEqual(carrier, carrierValue.CarrierName);

                int l = j + 2;
                string account = Gettext(attributeName_xpath, ".//*[@id='CarrierWebsiteLogin']/tbody/tr/td[" + l + "]");
                Assert.AreEqual(account, carrierValue.AccountNumber);

                int m = j + 3;
                string website = Gettext(attributeName_xpath, ".//*[@id='CarrierWebsiteLogin']/tbody/tr/td[" + m + "]//*[@id='websiteurl']");
                Assert.AreEqual(website, carrierValue.Website);

                int n= j + 4;
                string login = Gettext(attributeName_xpath, ".//*[@id='CarrierWebsiteLogin']/tbody/tr/td["+ n +"]/span");
                Assert.AreEqual(login, carrierValue.Login);

                int o = j + 6;
                string notes = Gettext(attributeName_xpath, ".//*[@id='CarrierWebsiteLogin']/tbody/tr/td[" + o + "]");
                Assert.AreEqual(notes, carrierValue.Notes);

                Click(attributeName_xpath, CarrierWebsite_FirstPasswordCopyIcon_Xpath);
                SendKeys(attributeName_xpath, CarrierWebsite_SearchField_Xpath, Keys.Control + "v");
                string PasswordCopyIcon = GetValue(attributeName_xpath, CarrierWebsite_SearchField_Xpath, "value");
                Clear(attributeName_xpath, CarrierWebsite_SearchField_Xpath);
                Assert.AreEqual(PasswordCopyIcon, carrierValue.Password);
                
                break;
            }




        }

        //API Scenarios

        

        /*
        [Then(@"Verify the API Response of the shipment results should match with UI(.*), (.*) ,(.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*),(.*),(.*), (.*), (.*),(.*),(.*),(.*),(.*)")]
        public void ThenVerifyTheAPIResponseOfTheShipmentResultsShouldMatchWithUI(string CustomerName, string Service, string OriginCity, string OriginZip, string OriginState, string OriginCountry, string DestinationCity, string DestinationZip, string DestinationState, string DestinationCountry, string Classification, double Quantity, string QuantityUNIT, double Weight, string WeightUnit, string Username, string originAccessorials, string destinationAccessorials)
        {
            List<RateResultCarrierViewModel> apirespone = GetRatesAndCarriersAPICall.CallRateRequestApi1(CustomerName, Service, OriginCity, OriginZip, OriginState, OriginCountry, DestinationCity, DestinationZip, DestinationState, DestinationCountry, Classification, Quantity, QuantityUNIT, Weight, WeightUnit, Username, originAccessorials, destinationAccessorials);
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
            else
            {
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
        }

    */
    }
}
