using System.Collections.Generic;
using System.Configuration;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Quote_List.QuoteList_ExternalUsers
{
    [Binding]
    public class RateRequest_AllowCustomerUsersAccessToSub_Accounts_GetQuoteTileAndGetQuoteLTLPageSteps : Quotelist
    {
        [Given(@"I am a shp\.entry or shp\.inquiry user associated to a primary account of TmsType MG that has sub-accounts")]
        public void GivenIAmAShp_EntryOrShp_InquiryUserAssociatedToAPrimaryAccountOfTmsTypeMGThatHasSub_Accounts()
        {
            string username = ConfigurationManager.AppSettings["username-ExtuserCustDropdown"].ToString();
            string password = ConfigurationManager.AppSettings["password-ExtuserCustDropdown"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"I am a shp\.entry or shp\.inquiry user associated to a primary account of TmsType Both that has sub-accounts")]
        public void GivenIAmAShp_EntryOrShp_InquiryUserAssociatedToAPrimaryAccountOfTmsTypeBothThatHasSub_Accounts()
        {
            string username = ConfigurationManager.AppSettings["username-ExtuserCustDropdownWithCustomerBoth"].ToString();
            string password = ConfigurationManager.AppSettings["password-ExtuserCustDropdownWithCustomerBoth"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"I am on the QuoteList page")]
        public void GivenIAmOnTheQuoteListPage()
        {
            //Navigate to Quotelist
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, QuoteIconModule_Xpath);
            Report.WriteLine("Navigated to Quote list page");
        }

        [Given(@"I select primary-Customer (.*) from the customer drop down list of QuoteList page")]
        public void GivenISelectPrimary_CustomerFromTheCustomerDropDownListOfQuoteListPage(string primaryAccountName)
        {
            //Select primary account from dropdown
            GlobalVariables.webDriver.WaitForPageLoad();
            SelectPrimaryAccountFromCustomerDropdown(primaryAccountName);
        }

        [Given(@"I select sub-Customer (.*) from the customer drop down list of QuoteList page")]
        public void GivenISelectSub_CustomerFromTheCustomerDropDownListOfQuoteListPage(string subAccountName)
        {
            //Select sub account from dropdown
            GlobalVariables.webDriver.WaitForPageLoad();
            SelectSubAccountFromCustomerDropdown(subAccountName);
        }

        [Given(@"I am on the Get Quote Tile page for a primary customer (.*)")]
        public void GivenIAmOnTheGetQuoteTilePageForAPrimaryCustomer(string primaryAccountName)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, QuoteIconModule_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Navigated to Quote list page");

            //Select primary account from dropdown
            SelectPrimaryAccountFromCustomerDropdown(primaryAccountName);

            Click(attributeName_id, SubmitRateRequestBtn_id);
            Report.WriteLine("Navigated to Quote Tiles page");
        }

        [Given(@"I am on the Get Quote Tile page for a sub customer (.*)")]
        public void GivenIAmOnTheGetQuoteTilePageForASubCustomer(string subAccountName)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, QuoteIconModule_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Navigated to Quote list page");

            //Select sub account from dropdown
            SelectSubAccountFromCustomerDropdown(subAccountName);

            Click(attributeName_id, SubmitRateRequestBtn_id);
            Report.WriteLine("Navigated to Quote Tiles page");
        }

        [When(@"I will click on LTL tile")]
        public void WhenIWillClickOnLTLTile()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, LTL_TileLabel_Id);
            Report.WriteLine("Clicked on LTL Quote Tile");
        }

        [Then(@"I will arrive on the Get Quote tile page")]
        public void ThenIWillArriveOnTheGetQuoteTilePage()
        {
            string getQuoteTilesPageheader = Gettext(attributeName_xpath, "//h1[contains(text(),'Get Quot')]");
            Assert.AreEqual("Get Quote", getQuoteTilesPageheader);
            Report.WriteLine("I have navigated to Get Quote Tiles page");
        }

        [Then(@"I will see the associated service type selections for TmsType Mg")]
        public void ThenIWillSeeTheAssociatedServiceTypeSelectionsForTmsTypeMg()
        {
            //Verify ltl tile is available
            VerifyElementVisible(attributeName_id, LTL_TileLabel_Id, "LTL Tile");
            Report.WriteLine("Verified that the LTL tile is available in Get Quote LTL Tile Page");

            //Verify Truckload tile is available
            VerifyElementVisible(attributeName_id, TL_TileLabel_Id, "TruckLoad Tile");
            Report.WriteLine("Verified that the Truckload tile is available in Get Quote LTL Tile Page");

            //Verify Partial Truckload tile is available
            VerifyElementVisible(attributeName_id, Partial_TL_TileLabel_Id, "Partial TruckLoad Tile");
            Report.WriteLine("Verified that the Partial Truckload tile is available in Get Quote LTL Tile Page");

            //Verify Intermodal tile is available
            VerifyElementVisible(attributeName_id, Intermodal_TileLabel_Id, "Intermodal Tile");
            Report.WriteLine("Verified that the Intermodal tile is available in Get Quote LTL Tile Page");

            //Verify International tile is not available
            bool internationalTile = IsElementPresent(attributeName_id, International_TileLabel_Id, "International Tile");
            Assert.IsFalse(internationalTile);
            Report.WriteLine("Verified that the International tile is not available in Get Quote LTL Tile Page");

            //Verify DomesticForwarding tile is not available
            bool domesticForwardingTile = IsElementPresent(attributeName_id, DomesticForwarding_TitleLabel_Id, "DomesticForwarding Tile");
            Assert.IsFalse(domesticForwardingTile);
            Report.WriteLine("Verified that the  DomesticForwarding tile is not available in Get Quote LTL Tile Page");
        }

        [Then(@"I will see the associated service type selections for TmsType Both")]
        public void ThenIWillSeeTheAssociatedServiceTypeSelectionsForTmsTypeBoth()
        {
            //Verify ltl tile is available
            VerifyElementVisible(attributeName_id, LTL_TileLabel_Id, "LTL Tile");
            Report.WriteLine("Verified that the LTL tile is available in Get Quote LTL Tile Page");

            //Verify Truckload tile is available
            VerifyElementVisible(attributeName_id, TL_TileLabel_Id, "TruckLoad Tile");
            Report.WriteLine("Verified that the Truckload tile is available in Get Quote LTL Tile Page");

            //Verify Partial Truckload tile is available
            VerifyElementVisible(attributeName_id, Partial_TL_TileLabel_Id, "Partial TruckLoad Tile");
            Report.WriteLine("Verified that the Partial Truckload tile is available in Get Quote LTL Tile Page");

            //Verify Intermodal tile is available
            VerifyElementVisible(attributeName_id, Intermodal_TileLabel_Id, "Intermodal Tile");
            Report.WriteLine("Verified that the Intermodal tile is available in Get Quote LTL Tile Page");

            //Verify DomesticForwarding tile is available
            VerifyElementVisible(attributeName_id, International_TileLabel_Id, "DomesticForwarding Tile");
            Report.WriteLine("Verified that the International tile is available in Get Quote LTL Tile Page");

            //Verify DomesticForwarding tile is available
            VerifyElementVisible(attributeName_id, DomesticForwarding_TitleLabel_Id, "DomesticForwarding Tile");
            Report.WriteLine("Verified that the  DomesticForwarding tile is available in Get Quote LTL Tile Page");
        }

        [Then(@"I will see the customer name displayed on the Get Quote tile page (.*)")]
        public void ThenIWillSeeTheCustomerNameDisplayedOnTheGetQuoteTilePage(string customerName)
        {
            string customerNameValue = Gettext(attributeName_xpath, LTL_GetQuotePage_CustomerUsersCustomerAccountBinding_Xpath);
            Assert.AreEqual(customerName, customerNameValue);
            Report.WriteLine("Verified that the customer name is displayed in the Get Quote LTL Tile Page");
        }

        [Then(@"I will see only LTL service type option")]
        public void ThenIWillSeeOnlyLTLServiceTypeOption()
        {
            //Verify ltl tile is available
            VerifyElementVisible(attributeName_id, LTL_TileLabel_Id, "LTL Tile");
            Report.WriteLine("Verified that the LTL tile is available in Get Quote LTL Tile Page");

            //Verify Truckload tile is not available
            bool truckloadTile = IsElementPresent(attributeName_id, TL_TileLabel_Id, "TruckLoad Tile");
            Assert.IsFalse(truckloadTile);
            Report.WriteLine("Verified that the Truckload tile is not available in Get Quote LTL Tile Page");

            //Verify Partial Truckload tile is not available
            bool partialTruckloadTile = IsElementPresent(attributeName_id, Partial_TL_TileLabel_Id, "Partial TruckLoad Tile");
            Assert.IsFalse(partialTruckloadTile);
            Report.WriteLine("Verified that the Partial Truckload tile is not available in Get Quote LTL Tile Page");

            //Verify Intermodal tile is not available
            bool intermodalTile = IsElementPresent(attributeName_id, Intermodal_TileLabel_Id, "Intermodal Tile");
            Assert.IsFalse(intermodalTile);
            Report.WriteLine("Verified that the Intermodal tile is not available in Get Quote LTL Tile Page");

            //Verify International tile is not available
            bool internationalTile = IsElementPresent(attributeName_id, International_TileLabel_Id, "International Tile");
            Assert.IsFalse(internationalTile);
            Report.WriteLine("Verified that the International tile is not available in Get Quote LTL Tile Page");

            //Verify DomesticForwarding tile is not available
            bool domesticForwardingTile = IsElementPresent(attributeName_id, DomesticForwarding_TitleLabel_Id, "DomesticForwarding Tile");
            Assert.IsFalse(domesticForwardingTile);
            Report.WriteLine("Verified that the  DomesticForwarding tile is not available in Get Quote LTL Tile Page");
        }

        [Then(@"I will arrive on the Get Quote \(LTL\) page")]
        public void ThenIWillArriveOnTheGetQuoteLTLPage()
        {
            string getQuoteLtlShipmentInformationHeader = Gettext(attributeName_xpath, LTL_shipmentinformationpageheader_Xpath);
            Assert.AreEqual("Get Quote (LTL)", getQuoteLtlShipmentInformationHeader);
            Report.WriteLine("I have navigated to Get Quote (LTL) page");
        }

        [Then(@"I will see the customer name displayed on the Get Quote \(LTL\) page (.*)")]
        public void ThenIWillSeeTheCustomerNameDisplayedOnTheGetQuoteLTLPage(string customerName)
        {
            string customerNameValue = Gettext(attributeName_xpath, LTL_GetQuotePage_CustomerUsersCustomerAccountBinding_Xpath);
            Assert.AreEqual(customerName, customerNameValue);
            Report.WriteLine("Verified that the customer name is displayed in the Get Quote LTL Page");
        }

        private void SelectPrimaryAccountFromCustomerDropdown(string primaryCustomerAccount)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, CustomerDropdownExtuser_Xpath);
            IList<IWebElement> customerAccounts = GlobalVariables.webDriver.FindElements(By.XPath(PrimaryCustomerAccountsDropdownValues_Xpath));

            for (int i = 0; i < customerAccounts.Count; i++)
            {
                if (customerAccounts[i].Text == primaryCustomerAccount)
                {
                    customerAccounts[i].Click();
                    Report.WriteLine("Selected primary customer " + primaryCustomerAccount + " account from dropdown");
                    break;
                }
            }
        }

        private void SelectSubAccountFromCustomerDropdown(string subCustomerAccount)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, CustomerDropdownExtuser_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            IList<IWebElement> customerAccounts = GlobalVariables.webDriver.FindElements(By.XPath(FirstlevelSubAccountsDropdownValues_Xpath));

            for (int i = 0; i < customerAccounts.Count; i++)
            {
                if (customerAccounts[i].Text == subCustomerAccount)
                {
                    customerAccounts[i].Click();
                    Report.WriteLine("Selected sub customer account " + subCustomerAccount + " from dropdown");
                    break;
                }
            }
        }
    }
}
