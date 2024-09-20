using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Input;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Carrier_Website
{
    [Binding]
    public  class CarrierWebsiteLogins_AdminSteps : MaintenaceTools
    {

        CommonMethodsCrm crm = new CommonMethodsCrm();
        public string CarrierURL;
        public string WebsiteCopyIcon;
        public string LoginCopyIcon;
        public string PasswordCopyIcon;

   

        [Given(@"I am a System Admin and Pricing Configuration user (.*), (.*)")]
        public void GivenIAmASystemAdminAndPricingConfigurationUser(string Username, string Password)
        {
            crm.LoginToCRMApplication(Username, Password);
        }


        [Given(@"I am on the Carrier Website Logins page")]
        public void GivenIAmOnTheCarrierWebsiteLoginsPage()
        {
            Report.WriteLine("I am on the Maintenance Tools Page");
            Click(attributeName_xpath, MaintenanceTools_Icon_Xpath);
            WaitForElementVisible(attributeName_xpath, MaintenanceToolsPage_Title_Xpath, "Maintenance Tools");


            Report.WriteLine("I am on the Carrier Website Login Page");
            Click(attributeName_id, CarrierWebsite_Logins_Id);
            WaitForElementVisible(attributeName_xpath, CarrierWebsite_Title_Xpath, "Admin Carrier Website Logins");

            VerifyElementPresent(attributeName_xpath, CarrierWebsite_Title_Xpath, "Admin Carrier Website Logins");
        }

        [When(@"I input (.*) into the search field")]
        public void WhenIInputIntoTheSearchField(string Search_Text)
        {
            Report.WriteLine("I search Text in Search Field");
            Thread.Sleep(3000);
            SendKeys(attributeName_xpath, CarrierWebsite_SearchField_Xpath, Search_Text);
            Thread.Sleep(5000);
        }


        [Then(@"The results of my search (.*) will be updated in the table")]
        public void ThenTheResultsOfMySearchWillBeUpdatedInTheTable(string Search_Text)
        {
            Report.WriteLine("Records will be Update in the Table");

            IList<IWebElement> TableAllRows = GlobalVariables.webDriver.FindElements(By.XPath(CarrierWebiste_TableRows_Xpath));
          
            if (TableAllRows.Count >= 1)
            {
                for (int i = 0; i < TableAllRows.Count(); i++)
                {
                    if(TableAllRows[i].Text.Contains(Search_Text))

                    {
                        Report.WriteLine("Rows are matched with the search Records :" + TableAllRows[i].Text);

                    }
                   
                }
            }
        }

        [When(@"I click on website URL")]
        public void WhenIClickOnWebsiteURL()
        {
            Report.WriteLine("I click on the Carrier Website");
            int row = GetCount(attributeName_xpath, CarrierWebiste_TableRows_Xpath);
            if(row > 1)
            {
                Report.WriteLine("Click on First Carrier Website Link ");
                CarrierURL = Gettext(attributeName_xpath, CarrierWebsite_FirstWebsiteLink_Xpath);
                Click(attributeName_xpath, CarrierWebsite_FirstWebsiteLink_Xpath);
                Thread.Sleep(5000);

            }

        }

        [Then(@"The website will be open in the new tab")]
        public void ThenTheWebsiteWillBeOpenInTheNewTab()
        {
            string URl = "https://www.google.com/?gws_rd=ssl";
            Report.WriteLine("Website will be navigated to the New Tab");

        
            WindowHandling(URl);
            Thread.Sleep(2000);
            string ExpectedURL = GetURL();
            Thread.Sleep(3000);
            if (ExpectedURL.Contains(CarrierURL))
   
            {
                Report.WriteLine("URL are matching in New Tab");
            }
            else
            {
                Report.WriteLine("URL are not matching");
            }

        }

        [When(@"I select the option to copy the Website field value to clipboard")]
        public void WhenISelectTheOptionToCopyTheWebsiteFieldValueToClipboard()
        {

            int row = GetCount(attributeName_xpath, CarrierWebiste_TableRows_Xpath);
            if (row > 1)
            {

                Report.WriteLine("Verify the Website Copy Icon");
                Click(attributeName_xpath, CarrierWebsite_FirstWebsiteCopyIcon_Xpath);
                Thread.Sleep(2000);
                SendKeys(attributeName_xpath, CarrierWebsite_SearchField_Xpath,Keys.Control + "v");

                WebsiteCopyIcon = GetValue(attributeName_xpath, CarrierWebsite_SearchField_Xpath,"value");
                Clear(attributeName_xpath, CarrierWebsite_SearchField_Xpath);

            }

        }

        [When(@"I select the option to copy the Login field value to clipboard")]
        public void WhenISelectTheOptionToCopyTheLoginFieldValueToClipboard()
        {
            int row = GetCount(attributeName_xpath, CarrierWebiste_TableRows_Xpath);
            if (row > 1)
            {
                
                Report.WriteLine("Verify the Login Copy Icon");
                Click(attributeName_xpath, CarrierWebsite_FirstLoginCopyIcon_Xpath);
                Thread.Sleep(2000);
                SendKeys(attributeName_xpath, CarrierWebsite_SearchField_Xpath, Keys.Control + "v");

                LoginCopyIcon = GetValue(attributeName_xpath, CarrierWebsite_SearchField_Xpath,"value");
                Clear(attributeName_xpath, CarrierWebsite_SearchField_Xpath);
                Thread.Sleep(2000);

            }


        }

        [When(@"I select the option to copy the Password field value to clipboard")]
        public void WhenISelectTheOptionToCopyThePasswordFieldValueToClipboard()
        {
            int row = GetCount(attributeName_xpath, CarrierWebiste_TableRows_Xpath);
            if (row > 1)
            {
                Report.WriteLine("Verify the Password Copy Icon");

                Click(attributeName_xpath, CarrierWebsite_FirstPasswordCopyIcon_Xpath);
                SendKeys(attributeName_xpath, CarrierWebsite_SearchField_Xpath, Keys.Control + "v");

                PasswordCopyIcon = Gettext(attributeName_xpath, CarrierWebsite_SearchField_Xpath);
                Clear(attributeName_xpath, CarrierWebsite_SearchField_Xpath);
            }

        }

        [Then(@"The Website value will be copied to my clipboard")]
        public void ThenTheWebsiteValueWillBeCopiedToMyClipboard()
        {
            Thread.Sleep(5000);
            Report.WriteLine("Website value will be copied to my clipboard");
            string UIWebsiteLoginLink = Gettext(attributeName_xpath, CarrierWebsite_FirstWebsiteLink_Xpath);
            Assert.AreEqual(UIWebsiteLoginLink, WebsiteCopyIcon);
        }

        [Then(@"The Login value will be copied to my clipboard")]
        public void ThenTheLoginValueWillBeCopiedToMyClipboard()
        {
            Thread.Sleep(2000);
            Report.WriteLine("Login value will be copied to my clipboard");
            string UILoginLink = Gettext(attributeName_xpath, CarrierWebsite_FirstLogin_Xpath);
            Assert.AreEqual(UILoginLink, LoginCopyIcon);


        }

        [Then(@"The Password will be copied to my clipboard")]
        public void ThenThePasswordWillBeCopiedToMyClipboard()
        {
            Thread.Sleep(2000);
            int row = GetCount(attributeName_xpath, CarrierWebiste_TableRows_Xpath);
            if (row > 1)
            {


                Report.WriteLine("Password value will be copied to my clipboard");

                Click(attributeName_xpath, CarrierWebsite_FirstEditPasswordIcon_Xpath);

                string PasswordMatchFromModel = Gettext(attributeName_id, CarrierWebsite_FirstPasswordEditModel_Password_Id);

                Assert.AreEqual(PasswordMatchFromModel, PasswordCopyIcon);
            }

        }
        [When(@"I select the option to edit the Password field value")]
        public void WhenISelectTheOptionToEditThePasswordFieldValue()
        {
            int row = GetCount(attributeName_xpath, CarrierWebiste_TableRows_Xpath);
            if (row > 1)
            {
                Report.WriteLine("Click on Password edit icon ");
                Click(attributeName_xpath, CarrierWebsite_FirstEditPasswordIcon_Xpath);
            }
        }

        [Then(@"I will be taken to the Carrier Website Logins (.*) modal")]
        public void ThenIWillBeTakenToTheCarrierWebsiteLoginsModal(string EditPassword)
        {
            Thread.Sleep(5000);
            Report.WriteLine("I am on the Edit password model");
            WaitForElementVisible(attributeName_xpath, CarrierWebsite_FirstEditPasswordModelHeader_Xpath, "Edit Password");
            string EditPasswordModel = Gettext(attributeName_xpath, CarrierWebsite_FirstEditPasswordModelHeader_Xpath);
            Assert.AreEqual(EditPassword, EditPasswordModel);
            
        }



    }
}
