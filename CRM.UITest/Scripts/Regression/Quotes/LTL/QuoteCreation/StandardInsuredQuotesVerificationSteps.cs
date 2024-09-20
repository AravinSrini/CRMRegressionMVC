using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Collections.Generic;
using System.Configuration;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Regression.Quotes
{
    [Binding]
    public class StandardInsuredQuotesVerificationSteps : Quotelist
    {
        [Given(@"I am an operation user")]
        public void GivenIAmAnOperationUser()
        {
            string username = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
            string password = ConfigurationManager.AppSettings["password-crmOperation"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"I select customeraccount from the dropdown (.*)")]
        public void GivenISelectCustomeraccountFromTheDropdown(string customerAccount)
        {
            Click(attributeName_xpath, QuoteList_ClickCustomerDropdown_xpath);
            Report.WriteLine("Selecting" + customerAccount + "from the Customer dropdown list");

            IList<IWebElement> CustomerDropdown_List = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='CategoryType_chosen']/div/ul/li"));
            int CustomerNameListCount = CustomerDropdown_List.Count;
            for (int i = 0; i < CustomerNameListCount; i++)
            {
                if (CustomerDropdown_List[i].Text == customerAccount)
                {
                    CustomerDropdown_List[i].Click();
                    break;
                }
            }
        }

        [Given(@"I Enter Shipment value to get Insured Rates '(.*)'")]
        public void GivenIEnterShipmentValueToGetInsuredRates(int ShipmentValue)
        {
            Report.WriteLine("Enter the Insured Rate");
            SendKeys(attributeName_xpath, GetQuoteInsuredVal_Xpath, ShipmentValue.ToString());
        }
    }
}
