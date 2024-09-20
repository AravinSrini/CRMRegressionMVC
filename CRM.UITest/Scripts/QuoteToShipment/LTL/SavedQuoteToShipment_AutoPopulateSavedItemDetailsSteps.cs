using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.Common;
using CRM.UITest.Helper.DataModels;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.QuoteToShipment.LTL
{
    [Binding]
    public class SavedQuoteToShipment_AutoPopulateSavedItemDetailsSteps : AddShipments
    {
        CommonMethodsCrm crmLogin = new CommonMethodsCrm();
        RateToShipmentLTL ltlQuote = new RateToShipmentLTL();
        private static string quoteNumber = string.Empty;

        [Given(@"I am Shp\.Inquiry, Shp\.Entry user logged in to CRM Application (.*)")]
        public void GivenIAmShp_InquiryShp_EntryUserLoggedInToCRMApplication(string userType)
        {
            UserCredentialsModel userModel = new UserCredentialsModel();
            UserTypeLoginCredentials userObj = new UserTypeLoginCredentials();
            userModel = userObj.GetCredentials(userType);

            //Logging into CRM Application
            Report.WriteLine("Logging into CRM Application");
            crmLogin.LoginToCRMApplication(userModel.UserName, userModel.Password);
        }

        [Given(@"I have a quote with Saved Item for External user (.*)")]
        public void GivenIHaveAQuoteWithSavedItemForExternalUser(string item)
        {
            CreateQuoteForGivenItem(string.Empty, item);
        }

        [Given(@"I am in the Quote Details Section of a non expired LTL quote with Saved Item For External user")]
        public void GivenIAmInTheQuoteDetailsSectionOfANonExpiredLTLQuoteWithSavedItemForExternalUser()
        {
            //Go to Quote List
            Report.WriteLine("Clicking on quote module icon");
            NavigateToQuoteList();

            //Search for the quote number with saved item
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_id, "searchbox", quoteNumber);

            //Click on Expand Quote          
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, QuoteExpand_Xpath);
        }

        [Given(@"I am in the Quote Details Section of a non expired LTL quote with Saved Item For Internal user (.*)")]
        public void GivenIAmInTheQuoteDetailsSectionOfANonExpiredLTLQuoteWithSavedItemForInternalUser(string customerName)
        {
            //Go to Quote List
            Report.WriteLine("Clicking on quote module icon");
            NavigateToQuoteList();
            GlobalVariables.webDriver.WaitForPageLoad();
            SelectCustomerInQuoteList(customerName);

            //Search for the quote number with saved item
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_id, "searchbox", quoteNumber);

            //Click on Expand Quote          
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, QuoteExpandInternal_Xpath);
        }

        [Given(@"I click on the Create Shipment button from Quote list")]
        public void GivenIClickOnTheCreateShipmentButtonFromQuoteList()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Click on Create Shipment");
            WaitForElementVisible(attributeName_id, QuoteCreateShipment_Id, "Create Shipment");
            Click(attributeName_id, QuoteCreateShipment_Id);
        }

        [When(@"I arrive on the LTL Add Shipment page")]
        public void WhenIArriveOnTheLTLAddShipmentPage()
        {
            Report.WriteLine("Add Shipment page");
            GlobalVariables.webDriver.WaitForPageLoad();
            Verifytext(attributeName_xpath, Addshipment_pageheader_Xpath, "Add Shipment (LTL)");
        }

        [Then(@"Hazardous material details are auto-populated in the Hazardous Details of Freight Description section (.*) (.*)")]
        public void ThenHazardousMaterialDetailsAreAuto_PopulatedInTheHazardousDetailsOfFreightDescriptionSection(string customerName, string item)
        {
            scrollElementIntoView(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id);
            Item itemDetails = DBHelper.GetItem(customerName, item);

            string hazmatGrp = Gettext(attributeName_xpath, FreightDesp_FirstItem_SelectHazmatPackageGroup_DownDown_xpath);
            Report.WriteLine("Verification that the HazMatPackagingGroup is auto - populated in Add Shipment Page from Saved quote");
            Assert.AreEqual((itemDetails.HazMatPackagingGroup), hazmatGrp);

            string emgContactName = GetValue(attributeName_id, FreightDesp_FirstItem_EmergencyReponseContactName_Id, "value");
            Report.WriteLine("Verification that the EmergencyContactName is auto - populated in Add Shipment Page from Saved quote");
            Assert.IsTrue(string.Equals((itemDetails.EmergencyContactName), emgContactName, StringComparison.OrdinalIgnoreCase));

            string ccnNumber = GetValue(attributeName_id, FreightDesp_FirstItem_CCN_Number_Id, "value");
            Report.WriteLine("Verification that the CcnNumber is auto - populated in Add Shipment Page from Saved quote");
            Assert.AreEqual((itemDetails.CcnNumber), ccnNumber);

            string hazmatClass = Gettext(attributeName_xpath, FreightDesp_FirstItem_SelectHazmatClass_DropwDown_xpath);
            Report.WriteLine("Verification that the HazMatClass is auto - populated in Add Shipment Page from Saved quote");
            Assert.AreEqual((itemDetails.HazMatClass), hazmatClass);

            string emgPhoneNumber = GetValue(attributeName_id, FreightDesp_FirstItem_EmergencyReponsePhoneNumber_Id, "value");
            string EmergencyPhoneNumberexpected = Regex.Replace(itemDetails.EmergencyPhoneNumber, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
            string EmergencyPhoneNumberActual = Regex.Replace(emgPhoneNumber, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
            Report.WriteLine("Verification that the EmergencyPhoneNumber is auto - populated in Add Shipment Page from Saved quote");
            Assert.AreEqual((EmergencyPhoneNumberexpected), EmergencyPhoneNumberActual);
        }

        [Then(@"NMFC and Item Description fields are auto-populated in the Freight Description section (.*) (.*)")]
        public void ThenNMFCAndItemDescriptionFieldsAreAuto_PopulatedInTheFreightDescriptionSection(string customerName, string item)
        {
            scrollElementIntoView(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id);
            Item itemDetails = DBHelper.GetItem(customerName, item);
            string nmfc = GetValue(attributeName_id, FreightDesp_FirstItem_NMFC_Id, "value");
            Report.WriteLine("Verification that the NMFC code is auto - populated in Add Shipment Page from Saved quote");
            Assert.AreEqual(itemDetails.NmfcCode.ToUpper(), nmfc.ToUpper());

            string itemDescription = GetValue(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id, "value");
            Report.WriteLine("Verification that the Item Description is auto - populated in Add Shipment Page from Saved quote");
            Assert.AreEqual(itemDetails.ItemDescription.ToUpper(), itemDescription.ToUpper());
        }

        [Given(@"I am Sales, Sales Management, Operations, or Station Owner user logged in to CRM Application (.*)")]
        public void GivenIAmSalesSalesManagementOperationsOrStationOwnerUserLoggedInToCRMApplication(string userType)
        {
            UserCredentialsModel userModel = new UserCredentialsModel();
            UserTypeLoginCredentials userObj = new UserTypeLoginCredentials();
            userModel = userObj.GetCredentials(userType);

            //Logging into CRM Application
            Report.WriteLine("Logging into CRM Application");
            crmLogin.LoginToCRMApplication(userModel.UserName, userModel.Password);
        }

        [Given(@"I have a quote with Saved Item containing Hazardous material for External user (.*)")]
        public void GivenIHaveAQuoteWithSavedItemContainingHazardousMaterialForExternalUser(string item)
        {
            CreateQuoteForGivenItem(string.Empty, item);
        }

        [Given(@"I have a quote with Saved Item for Internal user (.*) (.*)")]
        public void GivenIHaveAQuoteWithSavedItemForInternalUser(string customerName, string item)
        {
            CreateQuoteForGivenItem(customerName, item);
        }

        private void CreateQuoteForGivenItem(string customerName, string item)
        {
            //Go to Quote List
            NavigateToQuoteList();

            //Go to LTL shipment information page
            GlobalVariables.webDriver.WaitForPageLoad();
            NavigateToShipmentInformationPageFromQuoteList(customerName);

            //Enter Address and Item Information
            GlobalVariables.webDriver.WaitForPageLoad();
            EnterAddressData();
            EnterItemInformation(item);

            //Click on View Rates
            GlobalVariables.webDriver.WaitForPageLoad();
            ViewQuoteResults();

            //Create Quote
            GlobalVariables.webDriver.WaitForPageLoad();
            CreateQuote(customerName);

            //Set the Quote Number
            GlobalVariables.webDriver.WaitForPageLoad();
            quoteNumber = Gettext(attributeName_id, QC_RequestNumber_id);
        }

        public void NavigateToQuoteList()
        {
            //Go to Quote List
            Report.WriteLine("Clicking on quote module icon");
            try
            {
                Click(attributeName_xpath, QuoteModule_Xpath);
            }
            catch
            {
                GlobalVariables.webDriver.WaitForPageLoad();
            }
        }

        public void SelectCustomerInQuoteList(string customerName)
        {
            if (!string.IsNullOrWhiteSpace(customerName))
            {
                Report.WriteLine("Select Customer Name from the dropdown list");

                Click(attributeName_xpath, QuoteCustomerSelectionDropdown_Xpath);

                IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(QuoteCustomerSelectioDropdownValues_Xpath));
                int DropDownCount = DropDownList.Count;
                for (int i = 0; i < DropDownCount; i++)
                {
                    if (DropDownList[i].Text == customerName)
                    {
                        DropDownList[i].Click();
                        break;
                    }
                }
            }
        }

        public void NavigateToShipmentInformationPageFromQuoteList(string customerName)
        {
            //Select customer from quote list page
            SelectCustomerInQuoteList(customerName);

            Report.WriteLine("I have clicked on Submit Rate Request button");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, SubmitRateRequestBtn_id);

            //Click on LTL service Tile
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, "btn_ltl");
        }

        public void EnterAddressData()
        {
            //Enter Address information           
            Click(attributeName_id, ClearAddress_OriginId);
            Report.WriteLine("Entering data in origin section");
            SendKeys(attributeName_id, LTL_OriginZipPostal_Id, "60517");

            Click(attributeName_id, ClearAddress_DestId);
            Report.WriteLine("Entering data in destination section");
            SendKeys(attributeName_id, LTL_DestinationZipPostal_Id, "90210");
        }

        public void EnterItemInformation(string item)
        {
            //Enter Item Information
            SendKeys(attributeName_xpath, FrightDescription_SavedItemDropdown_XPath, item.Trim());

            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, LTL_SavedItemDropdownValues_Xpath, "Saved Item Dropdown List");

            IList<IWebElement> itemDropDownList = GlobalVariables.webDriver.FindElements(By.XPath(LTL_SavedItemDropdownValues_Xpath));
            int itemDropDownCount = itemDropDownList.Count;

            for (int i = 0; i < itemDropDownCount; i++)
            {
                if (itemDropDownList[i].Text?.Split(' ')?[1] == item)
                {
                    itemDropDownList[i].Click();
                    break;
                }
            }
        }

        public void ViewQuoteResults()
        {
            try
            {
                //Click on View Rates
                Click(attributeName_id, "view-quote-results");
            }
            catch
            {
                GlobalVariables.webDriver.WaitForPageLoad();
            }
        }

        public void CreateQuote(string customerName)
        {
            //Create quote
            if (GlobalVariables.webDriver.Url.Contains("LtlNoResultsView"))
            {
                Click(attributeName_id, ltlsavequotenorateslink_xpath);
            }
            else
            {
                GlobalVariables.webDriver.WaitForPageLoad();
                if (string.IsNullOrWhiteSpace(customerName))
                {
                    Click(attributeName_xpath, ltlsaverateasquotelnk_xpath);
                }
                else
                {
                    Click(attributeName_xpath, ltlsaverateasquotelnkStationUsers_xpath);
                }
            }
        }
    }
}
