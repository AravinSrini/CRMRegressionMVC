using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.Dls.IdentityServer.Core.Dto;
using Rrd.ServiceAccessLayer;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;


namespace CRM.UITest.Scripts.Customer_Invoices
{
    [Binding]
    public class CRMAccessRRD_StationOwnerandOperations_AccessSteps : Customer_Invoice
    {
        string station1 = string.Empty;

        [Given(@"I am a Station Owner or Operations user")]
        public void GivenIAmAStationOwnerOrOperationsUser()
        {
            string username = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
            string password = ConfigurationManager.AppSettings["password-crmOperation"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"I am on the Customer Invoice Page")]
        public void GivenIAmOnTheCustomerInvoicePage()
        {
            Report.WriteLine("Click on Customer Invoices icon");
            Click(attributeName_xpath, customerInvoiceIcon_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();

            Report.WriteLine("I arrived on Customer Invoices Page");
            Verifytext(attributeName_xpath, customerInvoicesHeader_xpath, "Customer Invoices");
        }

        [When(@"I Click on the Station dropdown")]
        public void WhenIClickOnTheStationDropdown()
        {
            Report.WriteLine("expanding the Create Custom Report section");
            Click(attributeName_xpath, CreateCustomReport_StationDropdown_Xpath);
        }

        [When(@"I Select a Station from the Station dropdown")]
        public void WhenISelectAStationFromTheStationDropdown()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, CreateCustomReport_StationDropdown_Xpath);
            IList<IWebElement> stationsDropdownList = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='ReportStations_chosen']/div/ul/li"));
            station1 = stationsDropdownList[0].Text;
            stationsDropdownList[0].Click();
        }

        [Then(@"I should see All the station which I am associated")]
        public void ThenIShouldSeeAllTheStationWhichIAmAssociated()
        {
            List<string> actualStations = new List<string>();
            IList<IWebElement> stationDropdownList2 = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='ReportStations_chosen']/div/ul/li"));

            foreach (IWebElement element in stationDropdownList2)
            {
                actualStations.Add(element.Text);
            }
            actualStations.Sort();

            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);
            List<AppUserClaimInfo> claimValue = new List<AppUserClaimInfo>();
            List<AppUserClaimInfo> claimDetails = IDP.GetUserClaimDetails(ConfigurationManager.AppSettings["username-crmOperation"].ToString());
            claimValue = claimDetails.Where(x => x.ClaimType == "dlscrm-StationId").Select(x => new AppUserClaimInfo
            {
                ClaimValue = x.ClaimValue,

            }).ToList();

            List<string> stationId = claimValue.Select(x => x.ClaimValue).ToList();
            List<string> expectedStationNames = DBHelper.GetMappedStationList(stationId);
            expectedStationNames.Sort();

            CollectionAssert.AreEqual(actualStations, expectedStationNames);
            Report.WriteLine("The station that I am associated are available in alphabetical order in Station Dropdown");
        }

        [Then(@"I will see All the Customer Account associated to selected Station")]
        public void ThenIWillSeeAllTheCustomerAccountAssociatedToSelectedStation()
        {
            Click(attributeName_xpath, ReportAccount_Xpath);
            Thread.Sleep(2000);
            Click(attributeName_xpath, ReportAccount_Xpath);
            IList<IWebElement> dropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ReportAccountDropdownVal_Xpath));
            List<string> dropDownUI = new List<string>();
            for (int i = 2; i < dropDownList.Count; i++)
            {
                dropDownUI.Add(dropDownList[i].Text);
            }

            List<string> value = DBHelper.GetCustomerActiveAndInactiveByStationName(station1);
            Assert.AreEqual(dropDownUI.Count, value.Count);
            value.Sort();
            dropDownUI.Sort();
            CollectionAssert.AreEqual(value, dropDownUI);

        }
    }
}
