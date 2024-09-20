using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Helper;
using CRM.UITest.Helper.Common;
using CRM.UITest.Helper.Implementations;
using CRM.UITest.Helper.Implementations.Csrs;
using CRM.UITest.Helper.Interfaces;
using CRM.UITest.Helper.Interfaces.Csrs;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Csr.CustomerDetails
{
    [Binding]
    public class CRM_Rating_Logic___Audit_Info_Steps : Submit_CSR
    {
        IGetCustomerRatingLogicAuditInfo getCustomerRatingLogicAuditInfo = new GetCustomerRatingLogicAuditInfo();
        IChangeCRMRatingLogicFlagToFalse changeCRMRatingLogicFlagToFalse = new ChangeCRMRatingLogicFlagToFalse();
        IChangeCRMRatingLogicFlagToTrue changeCRMRatingLogicFlagToTrue = new ChangeCRMRatingLogicFlagToTrue();
        IRevertCsrAuditInfoForUser revertCsrAuditInfoForUser = new RevertCsrAuditInforForUser();
        DeleteAllCsrStageInfoForUser deleteAllCsrStageInfo = new DeleteAllCsrStageInfoForUser();
        DateTime expectedCreatedDate;
        string customer = string.Empty;
        ClickAndWaitMethods clickMethods = new ClickAndWaitMethods();

        [Given(@"I navigate to the Customer Details screen for the customer ""(.*)""")]
        public void GivenINaviagteToTheCustomerDetailsScreenForTheCustomer(string customerName)
        {
            customer = customerName;
            Report.WriteLine("Navigating to Account Management Screen");
            WaitForElementVisible(attributeName_xpath, UserManagementIcon_Xpath, "Account Management Icon");
            Click(attributeName_xpath, UserManagementIcon_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Searching for customer name from list");
            WaitForElementNotVisible(attributeName_id, Loading_Icon_Id, "Loading Icon");
            WaitForElementVisible(attributeName_id, SearchCustomer_id, "Search Customer text box");
            SendKeys(attributeName_id, SearchCustomer_id, customerName);
            Report.WriteLine("Navigating to customer details screen");
            Click(attributeName_xpath, "//a[contains(.,'" + customerName + "')]");
        }

        [Given(@"I open the Edit Gainshare Modal for the customer")]
        public void GivenIOpenTheEditGainshareModalForTheCustomer()
        {
            Report.WriteLine("Opening Pricing Model section");
            WaitForElementNotVisible(attributeName_id, Loading_Icon_Id, "Loading Icon");
            scrollElementIntoView(attributeName_xpath, PricingModel_Section_Dropdown_Xpath);
            Thread.Sleep(500);
            IWebElement pricingModelField = GlobalVariables.webDriver.FindElement(By.XPath(PricingModel_Section_Dropdown_Xpath));
            WebDriverHelpers.ClickElement(pricingModelField);
            Report.WriteLine("Opening Edit Gainshare model");
            WaitForElementVisible(attributeName_xpath, PricingModel_EditGainshare_Xpath, "Edit Gainshare Icon");
            Thread.Sleep(1000);
            Click(attributeName_xpath, PricingModel_EditGainshare_Xpath);
        }

        [Given(@"I am submitting a revised csr for the customer ""(.*)""")]
        public void GivenIAmSubmittingARevisedCsrForTheCustomer(string customerName)
        {
            Report.WriteLine("Navigating to Usermanagement page");
            WaitForElementVisible(attributeName_xpath, UserManagementIcon_Xpath, "User Management Icon");
            Click(attributeName_xpath, UserManagementIcon_Xpath);
            Report.WriteLine("Searching " + customerName + " in the customer profiles");
            WaitForElementNotVisible(attributeName_id, Loading_Icon_Id, "Loading Icon");
            WaitForElementVisible(attributeName_id, SearchCustomer_id, "Search Customer text box");
            SendKeys(attributeName_id, SearchCustomer_id, customerName);
            Report.WriteLine("Navigating to " + customerName + "'s customer details");
            clickMethods.ClickAndWait(attributeName_xpath, "//a[contains(.,'" + customerName + "')]");
        }

        [When(@"I change the pricing percentage to ""(.*)""")]
        public void GivenIChangeThePricingPercentageTo(string percentage)
        {
            GlobalVariables.webDriver.FindElement(By.Id(Gainshare_percentage_Id)).Clear();
            SendKeys(attributeName_id, Gainshare_percentage_Id, percentage);
        }

        [When(@"I Set Apply CRM Rating Logic to ""(.*)""")]
        public void WhenISetApplyCRMRatingLogicTo(string option)
        {
            IWebElement crmRatingCheckbox = GlobalVariables.webDriver.FindElement(By.XPath(PricingModel_ApplyCRMRatingLogic_Xpath));
            bool isChecked = crmRatingCheckbox.Selected;

            if (option.Equals("Yes"))
            {
                if (!isChecked)
                {
                    Report.WriteLine("Checking the Applying CRM Rating Logic checkbox");
                    WebDriverHelpers.ClickElement(crmRatingCheckbox);
                }
            }
            else
            {
                if (isChecked)
                {
                    Report.WriteLine("Unchecking the Applying CRM Rating Logic checkbox");
                    WebDriverHelpers.ClickElement(crmRatingCheckbox);
                }
            }
        }



        [When(@"save the edited Gainshare information")]
        public void WhenSaveTheEditedGainshareInformation()
        {
            Report.WriteLine("Saving information on Edit Gainshare modal");
            IWebElement saveEditGainshare = GlobalVariables.webDriver.FindElement(By.XPath(PricingModel_SaveEditGainshare_Button_Xpath));
            WebDriverHelpers.ClickElement(saveEditGainshare);
            WaitForElementNotVisible(attributeName_id, Loading_Icon_Id, "Loading Icon");
            Thread.Sleep(1000);
        }

        [When(@"I navigate to Review And Submit CSR screen")]
        public void WhenINavigateToReviewAndSubmitCSRScreen()
        {
            Report.WriteLine("Saving Pricing Model information for revised CSR");
            scrollElementIntoView(attributeName_xpath, PricingModel_SaveAndContinuebutton);
            Click(attributeName_xpath, PricingModel_SaveAndContinuebutton);
            Report.WriteLine("Saving Saved Items and Addresses information");
            scrollElementIntoView(attributeName_xpath, SavedItemsAndAddresses_SaveAndContinue_button_Xpath);
            Click(attributeName_xpath, SavedItemsAndAddresses_SaveAndContinue_button_Xpath);
            Report.WriteLine("Saving Portal Users");
            WaitForElementVisible(attributeName_xpath, PortalUsers_SaveAndContinue_button_Xpath, "Portal Users Save and Continue button");
            Click(attributeName_xpath, PortalUsers_SaveAndContinue_button_Xpath);
        }

        [When(@"I changed minimum about to ""(.*)""")]
        public void WhenIChangedMinimumAboutTo(string minimum)
        {
            GlobalVariables.webDriver.FindElement(By.XPath(PricingModel_Minimum_Gainshare_Percentage_Xpath)).Clear();
            SendKeys(attributeName_xpath, PricingModel_Minimum_Gainshare_Percentage_Xpath, minimum);
        }

        [Then(@"the correct audit information will be saved in the database for ""(.*)"" with station ""(.*)"" and created by name ""(.*)"" and new logic (.*) and old logic (.*)")]
        public void ThenTheCorrectAuditInformationWillBeSavedInTheDatabaseForWithStationAndCreatedByNameAndNewLogicTrueAndOldLogicFalse(string customerName, string stationName, string creatorName, bool newLogic, bool oldLogic)
        {
            customer = customerName;
            expectedCreatedDate = DateTime.UtcNow;
            Report.WriteLine("Getting audit information from database");
            CustomerRatingLogicAuditModel auditInfo = getCustomerRatingLogicAuditInfo.GetCustomerRatingLogicAuditInfo(customerName);

            Report.WriteLine("Verifying customer name on audit is correct");
            Assert.AreEqual(customerName, auditInfo.CustomerName);

            Report.WriteLine("Verifying station name on audit is correct");
            Assert.AreEqual(stationName, auditInfo.StationName);

            Report.WriteLine("Verifying created by on audit is correct");
            Assert.AreEqual(creatorName, auditInfo.CreatedBy);

            if ((expectedCreatedDate - auditInfo.CreatedDate).TotalMinutes > 2)
            {
                Report.WriteFailure("Created date and time for audit is not correct");
            }

            Report.WriteLine("Verifying old rating logic value on audit is correct");
            Assert.AreEqual(oldLogic, auditInfo.OldRatingLogicValue);

            Report.WriteLine("Verifying new rating logic value on audit is correct");
            Assert.AreEqual(newLogic, auditInfo.NewRatingLogicValue);
        }

        [Then(@"no audit information will be saved in the database for ""(.*)""")]
        public void ThenNoAuditInformationWillBeSavedInTheDatabaseFor(string customerName)
        {
            CustomerRatingLogicAuditModel auditInfo = getCustomerRatingLogicAuditInfo.GetCustomerRatingLogicAuditInfo(customerName);
            Assert.IsNull(auditInfo);
        }

        [BeforeScenario("@97776")]
        private void RevertToOriginalSettings()
        {
            changeCRMRatingLogicFlagToTrue.ChangeCRMRatingLogicToTrue("97776 Gainshare Logic On");
            changeCRMRatingLogicFlagToTrue.ChangeCRMRatingLogicToTrue("97776 Revised CSA Gainshare Logic On");
            changeCRMRatingLogicFlagToTrue.ChangeCRMRatingLogicToTrue("97776 Revised Gainshare Logic On");
            changeCRMRatingLogicFlagToFalse.ChangeCRMRatingLogicFlagFromTrueToFalse("97776 Gainshare Logic Off");
            changeCRMRatingLogicFlagToFalse.ChangeCRMRatingLogicFlagFromTrueToFalse("97776 Revised CSA Gainshare Logic Off");
            changeCRMRatingLogicFlagToFalse.ChangeCRMRatingLogicFlagFromTrueToFalse("97776 Revised Gainshare Logic Off");

            revertCsrAuditInfoForUser.RevertCsrAuditInfoForUser("97776 Gainshare Logic On");
            revertCsrAuditInfoForUser.RevertCsrAuditInfoForUser("97776 Revised CSA Gainshare Logic On");
            revertCsrAuditInfoForUser.RevertCsrAuditInfoForUser("97776 Revised Gainshare Logic On");
            revertCsrAuditInfoForUser.RevertCsrAuditInfoForUser("97776 Gainshare Logic Off");
            revertCsrAuditInfoForUser.RevertCsrAuditInfoForUser("97776 Revised CSA Gainshare Logic Off");
            revertCsrAuditInfoForUser.RevertCsrAuditInfoForUser("97776 Revised Gainshare Logic Off");

            

            deleteAllCsrStageInfo.DeleteAllCsrStageInformation("97776 Gainshare Logic On");
            deleteAllCsrStageInfo.DeleteAllCsrStageInformation("97776 Revised CSA Gainshare Logic On");
            deleteAllCsrStageInfo.DeleteAllCsrStageInformation("97776 Revised Gainshare Logic On");
            deleteAllCsrStageInfo.DeleteAllCsrStageInformation("97776 Gainshare Logic Off");
            deleteAllCsrStageInfo.DeleteAllCsrStageInformation("97776 Revised CSA Gainshare Logic Off");
            deleteAllCsrStageInfo.DeleteAllCsrStageInformation("97776 Revised Gainshare Logic Off");

            DBHelper.DeleteDefaultCorporateAccessorials();
        }
    }
}
