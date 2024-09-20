using CRM.UITest.CommonMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using CRM.UITest.Objects;
using CRM.UITest.Helper;
using CRM.UITest.Helper.ViewModel;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using System.Threading;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.ServiceAccessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CRM.UITest.Scripts.Carrier_Website
{
    [Binding]
    public class Carrier_Website_Logins_Layout___AdminSteps : MaintenaceTools
    {

        CommonMethodsCrm crm = new CommonMethodsCrm();
        AddQuoteLTL ltl = new AddQuoteLTL();


        [Given(@"I am System Admin or Pricing Configuration user - (.*), (.*)")]
        public void GivenIAmSystemAdminOrPricingConfigurationUser_(string Username, string Password)
        {
            crm.LoginToCRMApplication(Username, Password);
        }



        [When(@"I am on the Carrier Website Logins page for the admin user")]
        public void WhenIAmOnTheCarrierWebsiteLoginsPageForTheAdminUser()
        {
            Report.WriteLine("Clicking on Maintanence Tools icon");
            Click(attributeName_cssselector, MaintenanceToolIcon_css);
            Report.WriteLine("Clicking on Carrier website button");
            scrollElementIntoView(attributeName_id, CarrierWebsite_Button_Id);
            Click(attributeName_id, CarrierWebsite_Button_Id);
            WaitForElementVisible(attributeName_xpath, CarrierWebsite_Title_Xpath, "Carrier Website Page Header");
            Report.WriteLine("Verifying carrier website login page");
            Verifytext(attributeName_xpath, CarrierWebsite_Title_Xpath, "Admin Carrier Website Logins");
            VerifyElementPresent(attributeName_xpath, BackToMaintenanceTools_Button_Xpath, "Back to Maintenance Tools");
        }


        
        [Then(@"I see the RRD DLS Worldwide logo")]
        public void ThenISeeTheRRDDLSWorldwideLogo()
        {
            Report.WriteLine("Landing on Maintenance Tools page");
            //WaitForElementVisible(attributeName_cssselector, DLSWorldwideimage_css, "DLSWorldwide");
            VerifyElementPresent(attributeName_xpath, DashboardHeaderlogo_Xpath, "DLSWorldwide");
            Report.WriteLine("Verify DLS Worldwide in logo");
            string logohastext = GetAttribute(attributeName_xpath, DashboardHeaderlogo_Xpath, "alt");
            Assert.AreEqual("DLS Worldwide", logohastext);
        }

        [Then(@"I see the my credentials on the Carrier Website Login page (.*)")]
        public void ThenISeeTheMyCredentialsOnTheCarrierWebsiteLoginPage(string Username)
        {
            
            Report.WriteLine("User should see Maintenance Tools icon in the left navigation menu of Landing Page");
            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);

            string userFirstName = IDP.GetClaimValue(Username, "dlscrm-FirstName");
            string userLastname = IDP.GetClaimValue(Username, "dlscrm-LastName");
            string userCredentials = userFirstName + " " + userLastname;
            string ActualuserCredentials = Gettext(attributeName_id, UserDropdown_id);
            Assert.AreEqual(ActualuserCredentials, userCredentials);
            
        }

        [Then(@"I should see the column names as SCAC, Carrier Name, Account Number, Website , Login, Password and Notes Column")]
        public void ThenIShouldSeeTheColumnNamesAsSCACCarrierNameAccountNumberWebsiteLoginPasswordAndNotesColumn()
        {
            IList < IWebElement > totalcarriers = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='CarrierWebsiteLogin']/thead/tr/th"));
            int colCount = totalcarriers.Count();
            for (int i= 1; i < colCount; i++)
            {
                List<string> expectedColumnValues = new List<string>(new string[] { "SCAC", "CARRIER", "Account #", "Website", "Login", "Password", "NOTES" });
                string colName = Gettext(attributeName_xpath, ".//*[@id='CarrierWebsiteLogin']/thead/tr/th[" + i + "] ");
                foreach (var s in expectedColumnValues)
                {
                    if (expectedColumnValues.Contains(s))
                    {
                        Report.WriteLine("Column name " + s + "displaying in UI column name");
                    }
                    else
                    {
                        Assert.Fail();
                    }
                }
            }
        }


        [Then(@"I should see all columns SCAC, Carrier Name, Account Number, Website with option Copy to Clipboard icon, Login with Copy to Clipboard icon, Password with Copy to Clipboard icon and Edit Option and Notes Column")]
        public void ThenIShouldSeeAllColumnsSCACCarrierNameAccountNumberWebsiteWithOptionCopyToClipboardIconLoginWithCopyToClipboardIconPasswordWithCopyToClipboardIconAndEditOptionAndNotesColumn()
        {
                IList <IWebElement> row = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='CarrierWebsiteLogin']/tbody/tr"));
                for (int j = 1; j <= row.Count; j++)
                {
                        
                        VerifyElementPresent(attributeName_xpath, ".//*[@id='CarrierWebsiteLogin']/tbody/tr/td[4]/a[@id='websitecopypopup']", "websitecopypopup");
                        VerifyElementPresent(attributeName_xpath, ".//*[@id='CarrierWebsiteLogin']/tbody/tr[1]/td[5]/a/span", "Login Copy Icon");
                        VerifyElementPresent(attributeName_xpath, ".//*[@id='CarrierWebsiteLogin']/tbody/tr[1]/td[6]/a[1]/span", "Password Copy Icon");
                        VerifyElementPresent(attributeName_xpath, ".//*[@id='CarrierWebsiteLogin']/tbody/tr/td[6]/a[@id='loginpopup']", "PasswordEdit Icon");

                   break;
                 }
        }

        [Then(@"I should see the Search Text Box")]
        public void ThenIShouldSeeTheSearchTextBox()
        {
            VerifyElementPresent(attributeName_xpath, CarrierWebsite_SearchTextBox_xpath, "Search Text Box");
        }

        [Then(@"I should be able to view (.*) under dropdown in top grid of Carrier Website Login page")]
        public void ThenIShouldBeAbleToViewUnderDropdownInTopGridOfCarrierWebsiteLoginPage(string Options)
        {
           
            VerifyElementPresent(attributeName_xpath, CarrierWebsite_ViewOption_xpath, "View Option");

            string[] values = Options.Split(',');

            Click(attributeName_xpath, ".//*[@id='CarrierWebsiteLogin_length']/label/select");
                    
            
            IList<IWebElement> UIValues = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='CarrierWebsiteLogin_length']/label/select/option"));
            List <string> ExpectedVal = new List<string>();

            foreach (var v in values)
            {
                ExpectedVal.Add(v);
            }

            Assert.AreEqual(ExpectedVal.Count, UIValues.Count);
            for (int i = 0; i < UIValues.Count; i++)
            {
                if (ExpectedVal.Contains(UIValues[i].Text))
                {
                    Report.WriteLine("Option" + UIValues[i].Text + " is displaying under view dropdown");
                }
                else
                {
                    Report.WriteLine("Option" + UIValues[i].Text + " displaying under view dropdown is not expected");
                    Assert.IsTrue(false);
                }
            }
        }

       

        [Given(@"I am an DLS user and login into application with valid (.*) and (.*)")]
        public void GivenIAmAnDLSUserAndLoginIntoApplicationWithValidAnd(string Username, string Password)
        {
            crm.LoginToCRMApplication(Username, Password);
        }

        [When(@"I enter all required data on the Get Quote LTL page (.*) , (.*), (.*), (.*),(.*),(.*), (.*), (.*),(.*)")]
        public void WhenIEnterAllRequiredDataOnTheGetQuoteLTLPage(string userType, string CustomerAccName, string OriginZip, string DestinationZip, string Classification, string Quantity, string QuantityUNIT, string Weight, string WeightUnit)
        {
            ltl.NaviagteToQuoteList();
            ltl.Add_QuoteLTL(userType, CustomerAccName);
            try
            {
                Thread.Sleep(10000);
                Click(attributeName_id, ClearAddress_OriginId);

            }
            catch (Exception)
            {
                Thread.Sleep(50000);
                Console.WriteLine("error occurred");
            }
            
            ltl.EnterOriginZip(OriginZip);
            Click(attributeName_id, ClearAddress_DestId);
            ltl.EnterDestinationZip(DestinationZip);
            Click(attributeName_id, LTL_ClearItem_Id);
            ltl.EnterItemdata(Classification, Weight);
            SendKeys(attributeName_id, "quantity-0", "6");
        }

        [When(@"I click on view quote results button on the Get Quote LTL page")]
        public void WhenIClickOnViewQuoteResultsButtonOnTheGetQuoteLTLPage()
        {
           
           ltl.ClickViewRates();
        }



    }
}
