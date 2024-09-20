using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Carrier_Website
{
    [Binding]
    public  class CarrierWebsiteLogins_NonAdminSteps : MaintenaceTools
    {
        CommonMethodsCrm crm = new CommonMethodsCrm();
        public string PasswordCopyIcon;
        public string FirstScacsUI;

        [Given(@"I am an Operations, Station Owner or System Configuration user (.*),(.*)")]
        public void GivenIAmAnOperationsStationOwnerOrSystemConfigurationUser(string Username, string Password)
        {
            crm.LoginToCRMApplication(Username, Password);

        }

        [Given(@"I am on the Carrier Website Logins page for Non admin")]
        public void GivenIAmOnTheCarrierWebsiteLoginsPageForNonAdmin()
        {
            Report.WriteLine("I am on the Carrier Website Login Page");
            OnMouseOver(attributeName_cssselector, TMS_Launch_Icon_css);
            Click(attributeName_xpath, TmsLaunch_CarrierWebsiteLogin_Xpath);
            WaitForElementVisible(attributeName_xpath, CarrierWebsite_Title_NonAdmin_Xpath, "Carrier Website Logins");
            VerifyElementPresent(attributeName_xpath, CarrierWebsite_Title_NonAdmin_Xpath, "Carrier Website Logins");
        }



        [When(@"I selected the option to copy the Password field value to clipboard")]
        public void WhenISelectedTheOptionToCopyThePasswordFieldValueToClipboard()
        {


            int row = GetCount(attributeName_xpath, CarrierWebiste_TableRows_Xpath);
            if (row > 1)
            {
                FirstScacsUI = Gettext(attributeName_xpath, CarrierWbsite_FirstCarrierScac_Xpath);

                Report.WriteLine("Verify the Password Copy Icon");

                Click(attributeName_xpath, CarrierWebsite_FirstPasswordCopyIcon_Xpath);
                Thread.Sleep(2000);
                SendKeys(attributeName_xpath, CarrierWebsite_SearchField_Xpath, Keys.Control + "v");
                Thread.Sleep(2000);

                 PasswordCopyIcon = GetValue(attributeName_xpath, CarrierWebsite_SearchField_Xpath,"value");
                Clear(attributeName_xpath, CarrierWebsite_SearchField_Xpath);
                Click(attributeName_xpath, CarrierWebsite_Title_NonAdmin_Xpath);
                Thread.Sleep(3000);
            }
        }


        [Then(@"Verify the Password will be copied to my clipboard")]
        public void ThenVerifyThePasswordWillBeCopiedToMyClipboard()
        {
               
                CRM.UITest.Entities.Proxy.CarrierWebsite carrierValue = new CRM.UITest.Entities.Proxy.CarrierWebsite();
                carrierValue = DBHelper.GetCarrierDetails(FirstScacsUI);
                Thread.Sleep(2000);
                Assert.AreEqual(carrierValue.Password, PasswordCopyIcon);

        }


    }
}
