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
using System.Configuration;
using TechTalk.SpecFlow;
namespace CRM.UITest.Scripts.Maintenance_Tools.Master_Carrier_Rate_Settings
{
    [Binding]
    public class MasterCarrierRateSettings_CarrierAccessorialShownNASteps
    {
        BumpSurgeAllStationsDisplay bumpSurgeAllStationsDisplay = new BumpSurgeAllStationsDisplay();
        string accessorialType = null;
        string accessorialValue = null;
        [Given(@"I am systemadmin user")]
        public void GivenIAmSystemadminUser()
        {
            string username = ConfigurationManager.AppSettings["username-SystemAdmin"].ToString();
            string password = ConfigurationManager.AppSettings["password-SystemAdmin"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }
        
        [Given(@"I have navigated to the mastercarrierratesettings page")]
        public void GivenIHaveNavigatedToTheMastercarrierratesettingsPage()
        {
            bumpSurgeAllStationsDisplay.NavigateTo_MasterCarrierRateSettingsPage();
            bumpSurgeAllStationsDisplay.SelectCustomerFromDropdown_MasterCarrierRateSettingsPage("Darshan Sprint 78");

        }

        [When(@"I have defaultaccessorials values for the any accessorials type")]
        public void WhenIHaveDefaultaccessorialsValuesForTheAnyAccessorialsType()
        {
           DefaultAccessorialSetup DefaultAccessorial = DBHelper.getdefaultAccessorials();
            accessorialType = DefaultAccessorial?.AccessorialName;
            accessorialValue = DefaultAccessorial?.AccessorialValue.ToString();
            if (!string.IsNullOrEmpty(accessorialValue))
            {
                Report.WriteLine("I have values in defaultaccessorials for any accessorials");
            }

        }

        [Then(@"I should be displayed with the default individual accessorials for all carriers")]
        public void ThenIShouldBeDisplayedWithTheDefaultIndividualAccessorialsForAllCarriers()
        {
            IList<IWebElement> Accessorilavalues = GlobalVariables.webDriver.FindElements(By.XPath(".//td[12]"));
            //need to refactor this xpath based on the accessorialType
            List<string> AccessorialvalueUI = new List<string>();
            foreach (IWebElement element in Accessorilavalues)
            {
                AccessorialvalueUI.Add((element.Text).ToString());
            }
            for(int i =0;i< AccessorialvalueUI.Count; i++)
            {
                Assert.AreEqual(AccessorialvalueUI[i],"$" + accessorialValue);
            }
        }

    }
}
