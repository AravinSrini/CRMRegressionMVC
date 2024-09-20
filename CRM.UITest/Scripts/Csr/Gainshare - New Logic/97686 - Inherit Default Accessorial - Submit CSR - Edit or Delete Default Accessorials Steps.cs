using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.Common;
using CRM.UITest.Helper.DataModels;
using CRM.UITest.Helper.Implementations;
using CRM.UITest.Helper.Implementations.CSR;
using CRM.UITest.Helper.Implementations.Csrs;
using CRM.UITest.Helper.Implementations.Default_Accessorials;
using CRM.UITest.Helper.Interfaces;
using CRM.UITest.Helper.Interfaces.Default_Accessorials;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Csr.Gainshare___New_Logic
{
    [Binding]
    public sealed class Inherit_Default_Accessorial___Submit_CSR___Edit_or_Delete_Default_Accessorials_Steps : Submit_CSR
    {
        ClickAndWaitMethods clickMethods = new ClickAndWaitMethods();
        GetCsrAccountId getAccountID = new GetCsrAccountId();
        GetCustomerStationID getStationId = new GetCustomerStationID();
        AccessorialHelpers accessorialHelper = new AccessorialHelpers();
        IGetCSRCarrierAccessorials getCarrierAccessorials = new GetCSRCarrierAccessorials();
        IGetCSRIndividualAccessorials getCustomerAccessorials = new GetCSRIndividualAccessorials();
        IGetStationCarrierDefaultAccessorials getStationCarrierDefaultAccessorials = new GetStationCarrierDefaultAccessorials();
        IGetStationIndividualDefaultAccessorials getStationIndividualDefaultAccessorials = new GetStationIndividualDefaultAccessorials();
        IGetCorporateCarrierDefaultAccessorials getCorporateCarrierDefaultAccessorials = new GetCorporateCarrierDefaultAccessorials();
        IGetCorporateIndividualDefaultAccessorials getCorporateDefaultAccessorials = new GetCorporateIndividualDefaultAccessorials();
        string username = string.Empty;
        string stationId = string.Empty;
        List<string> displayedIndividualAccessorials = new List<string>();

        [Given(@"I am submitting a new csr for a (.*)")]
        public void GivenIAmSubmittingANewCsr(string accountType)
        {
            Report.WriteLine("Navigating to the user management page");
            Click(attributeName_xpath, UserManagementIcon_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();

            Report.WriteLine("Opening the csr list");
            WaitForElementVisible(attributeName_xpath, View_Csr_List_Button_Xpath, "View CSR List Button");

            WaitForElementNotVisible(attributeName_id, Loading_Icon_Id, "Loading Icon");
            Click(attributeName_xpath, View_Csr_List_Button_Xpath);

            Report.WriteLine("Submitting a new csr");
            clickMethods.ClickAndWait(attributeName_xpath, Submit_Csr_Button_Xpath);

            Report.WriteLine("Selecting TMS type MG");
            IWebElement mgButton = GlobalVariables.webDriver.FindElement(By.XPath(TMS_System_MG_Clickable_Xpath));
            WebDriverHelpers.CheckRadioButton(mgButton);

            Report.WriteLine("Entering customer name");
            SendKeys(attributeName_xpath, Customer_Account_Name_Xpath, "97686 Zach Test");
            username = "97686 Zach Test";


            WaitForElementNotVisible(attributeName_id, Loading_Icon_Id, "Loading Icon");
            Report.WriteLine("Selecting No Invoice");
            Click(attributeName_xpath, CustomerInvoiceMethod_Dropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, Customer_Invoice_Method_Xpath, "No Invoice");
        }

        [Given(@"I am submitting a new csr for Primary account")]
        public void GivenIAmSubmittingANewCsrForPrimaryAccount()
        {
            Report.WriteLine("Submitting a new csr");
            string baseURL = ConfigurationManager.AppSettings["BaseUrl"];
            GlobalVariables.webDriver.Url = baseURL + "/L/Customer/AccountInformation";

            Report.WriteLine("Selecting NTS from station id dropdown");
            Click(attributeName_xpath, StationId_DropDown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, Station_Id_DropDown_Xpath, "NTS");
            WaitForElementNotVisible(attributeName_id, Loading_Icon_Id, "Loading Icon");
            stationId = "NTS";

            Click(attributeName_xpath, Primary_CSR_Type_Xpath);

            WaitForElementNotVisible(attributeName_id, Loading_Icon_Id, "Loading Icon");

            Report.WriteLine("Selecting TMS type MG");
            IWebElement mgButton = GlobalVariables.webDriver.FindElement(By.XPath(TMS_System_MG_Clickable_Xpath));
            WebDriverHelpers.CheckRadioButton(mgButton);

            Report.WriteLine("Entering customer name");
            SendKeys(attributeName_xpath, Customer_Account_Name_Xpath, "97686 Zach Test");
            username = "97686 Zach Test";

            Report.WriteLine("Selecting No Invoice");
            Click(attributeName_xpath, CustomerInvoiceMethod_Dropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, Customer_Invoice_Method_Xpath, "No Invoice");

            Report.WriteLine("Clicking Save and Continue");
            clickMethods.ClickAndWait(attributeName_xpath, Save_And_Continue_Xpath);
        }

        [Given(@"I am on the Pricing Model page for the CSR")]
        public void GivenIAmOnThePricingModelPageForTheCSR()
        {
            Report.WriteLine("Entering 97686 as the location name");
            SendKeys(attributeName_xpath, CustomerLocation_Name_Textbox_Xpath, "97686");
            Report.WriteLine("Entering 97686 as Address line 1");
            SendKeys(attributeName_xpath, CustomerLocation_Address1_Textbox_Xpath, "97686");
            Report.WriteLine("Entering Chicago as the city");
            SendKeys(attributeName_xpath, CustomerLocation_City_Textbox_Xpath, "Chicago");

            Report.WriteLine("Selecting AL as the state");
            Click(attributeName_xpath, CustomerLocation_StateDropDown_Xpath);
            IWebElement stateFromDropdown = GlobalVariables.webDriver.FindElement(By.XPath("//*[@id='state-customer-location-select_listbox']/li[3]"));
            WebDriverHelpers.ClickElementFromDropDown(stateFromDropdown);

            Report.WriteLine("Entering 60606 as the zip code");
            SendKeys(attributeName_xpath, CustomerLocation_Zip_Textbox_Xpath, "60606");

            Report.WriteLine("Entering 97686 as the contact name");
            SendKeys(attributeName_xpath, CustomerContactInformation_Name_Textbox_Xpath, "97686");
            Report.WriteLine("Entering 9999999999 as the phone number");
            SendKeys(attributeName_xpath, CustomerContactInformation_PhoneNumber_Textbox_Xpath, "9999999999");
            Report.WriteLine("Entering 96965@96964.com as the email address");
            SendKeys(attributeName_xpath, CustomerContactInformation_Email_Textbox_Xpath, "96964@96964.com");

            Report.WriteLine("Clicking on the use customer location and contact info for bill to location and contact details");
            Click(attributeName_xpath, CheckBox_UseCustomerLocation_ContactInformation_for_BillToLocation_Contact_Details);

            Report.WriteLine("Clicking on save and continue");
            clickMethods.ClickAndWait(attributeName_xpath, LocationsAndContacts_SaveAndContinueButton_Xpath);

            Report.WriteLine("Verifying User is navigated ot the customer pricing page");

            Verifytext(attributeName_xpath, "//*[@id='main']/div[2]/div/h3", "Pricing Model");
        }

        [Given(@"I fill in valid Gainshare percentage information")]
        [When(@"I fill in valid Gainshare percentage information")]
        public void GivenIFillInValidGainsharePercentageInformation()
        {
            Thread.Sleep(1000);

            WebDriverHelpers.CheckRadioButton(GlobalVariables.webDriver.FindElement(By.XPath("//*[@id='pricing-carriersExclud-no']")));
            WebDriverHelpers.CheckRadioButton(GlobalVariables.webDriver.FindElement(By.XPath("//*[@id='pricing-household-no']")));

            SendKeys(attributeName_id, Gainshare_percentage_Id, "50");

            List<IWebElement> gainsharePercentageFields = new List<IWebElement>();
            gainsharePercentageFields = GlobalVariables.webDriver.FindElements(By.XPath("//input[contains(@id, 'gainshare-percentage')]")).ToList();

            for (int i = 0; i < gainsharePercentageFields.Count; i++)
            {
                SendKeys(attributeName_id, "gainshare-percentage-" + (i), "50");
                SendKeys(attributeName_id, "pricing-min-" + (i), "50");
                SendKeys(attributeName_id, "pricing-master-Acc-" + (i), "50");
            }
            scrollElementIntoView(attributeName_xpath, "//*[@id='header']");
        }


        [Given(@"I am submitting a revised csr for a (.*)")]
        public void GivenIAmSubmittingARevisedCsr(string accountType)
        {
            Report.WriteLine("Navigating to Account Management Screen");
            WaitForElementVisible(attributeName_xpath, UserManagementIcon_Xpath, "User Management Icon");
            clickMethods.ClickAndWait(attributeName_xpath, UserManagementIcon_Xpath);
            Thread.Sleep(1000);
            if (accountType.Equals("Primary account"))
            {
                Report.WriteLine("Selecting a primary account customer");
                Report.WriteLine("Searching 97686 primary station accessorials in the customer profiles");
                SendKeys(attributeName_id, SearchCustomer_id, "97686 primary station accessorials");
                WaitForElementVisible(attributeName_xpath, "//a[contains(.,'97686 primary station accessorials')]", "Primary account");

                Report.WriteLine("Navigating to 97686 primary station accessorials' customer details");
                WaitForElementNotVisible(attributeName_id, Loading_Icon_Id, "Loading Icon");
                Thread.Sleep(2000);
                Click(attributeName_xpath, "//a[contains(.,'97686 primary station accessorials')]");
                username = "97686 primary station accessorials";
            }
            else
            {
                Report.WriteLine("Selecting a sub-account customer");
                Report.WriteLine("Searching 97686 sub station level in the customer profiles");
                SendKeys(attributeName_id, SearchCustomer_id, "97686 sub station level");
                WaitForElementVisible(attributeName_xpath, "//a[contains(.,'97686 sub station level')]", "Sub account");

                Report.WriteLine("Navigating to 97686 sub station level 's customer details");
                clickMethods.ClickAndWait(attributeName_xpath, "//a[contains(.,'97686 sub station level')]");
                username = "97686 sub station level";
            }
        }

        [Given(@"the default carrier accessorial was set at the Primary level")]
        public void GivenTheDefaultCarrierAccessorialWasSetAtThePrimaryLevel()
        {

            Report.WriteLine("Selecting NT2 from station id dropdown");
            Click(attributeName_xpath, StationId_DropDown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, Station_Id_DropDown_Xpath, "NT2");
            GlobalVariables.webDriver.WaitForPageLoad();

            WaitForElementNotVisible(attributeName_id, Loading_Icon_Id, "Loading Icon");
        }

        [Given(@"the default carrier accessorial was set at the Station level")]
        public void GivenTheDefaultCarrierAccessorialWasSetAtTheStationLevel()
        {
            Report.WriteLine("Selecting NTS from station id dropdown");
            Click(attributeName_xpath, StationId_DropDown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, Station_Id_DropDown_Xpath, "NTS");
            GlobalVariables.webDriver.WaitForPageLoad();
            stationId = "NTS";

            WaitForElementNotVisible(attributeName_id, Loading_Icon_Id, "Loading Icon");
        }

        [Given(@"I choose a (.*) as the account type")]
        public void GivenIChooseAPrimaryAccountAsTheAccountType(string accountType)
        {
            Report.WriteLine("Selecting the account type " + accountType);
            if (accountType.Equals("Primary account"))
            {
                GlobalVariables.webDriver.FindElement(By.XPath(PrimaryAccount_Csr_RadioButton_Clickable_Xpath)).Click();
            }
            else
            {
                GlobalVariables.webDriver.FindElement(By.XPath(SubAccount_Csr_RadioButton_Clickable_Xpath)).Click();
                GlobalVariables.webDriver.WaitForPageLoad();
                Report.WriteLine("Selecting a primary customer");
                Click(attributeName_xpath, SelectPrimaryAcctDropDown_Xpath);
                Thread.Sleep(2000);
                SelectDropdownValueFromList(attributeName_xpath, SelectPrimaryAcctDropDown_Xpath, "97686 primary station accessorials");
            }

            WaitForElementNotVisible(attributeName_id, Loading_Icon_Id, "Loading Icon");

            Report.WriteLine("Selecting TMS System as MG");
            IWebElement mgButton = GlobalVariables.webDriver.FindElement(By.XPath(TMS_System_MG_Clickable_Xpath));
            WebDriverHelpers.CheckRadioButton(mgButton);

            Report.WriteLine("Entering customer name");
            SendKeys(attributeName_xpath, Customer_Account_Name_Xpath, "97686 Zach Test");
            username = "97686 Zach Test";

            Report.WriteLine("Selecting No Invoice");
            Click(attributeName_xpath, CustomerInvoiceMethod_Dropdown_Xpath);
            Thread.Sleep(2000);
            SelectDropdownValueFromList(attributeName_xpath, Customer_Invoice_Method_Xpath, "No Invoice");

            Report.WriteLine("Clicking Save and Continue");
            clickMethods.ClickAndWait(attributeName_xpath, Save_And_Continue_Xpath);
        }

        [Given(@"I choose a Sub-account as the account type for customer ""(.*)""")]
        public void GivenIChooseASub_AccountAsTheAccountTypeForCustomer(string primaryAccountName)
        {
            Report.WriteLine("Selecting the account type sub-account");
            GlobalVariables.webDriver.FindElement(By.XPath(SubAccount_Csr_RadioButton_Clickable_Xpath)).Click();

            Report.WriteLine("Selecting a primary customer");
            Click(attributeName_xpath, SelectPrimaryAcctDropDown_Xpath);
            Thread.Sleep(1000);
            SelectDropdownValueFromList(attributeName_xpath, SelectPrimaryAcctDropDown_Xpath, primaryAccountName);

            Report.WriteLine("Selecting TMS System as MG");
            IWebElement mgButton = GlobalVariables.webDriver.FindElement(By.XPath(TMS_System_MG_Clickable_Xpath));
            WebDriverHelpers.CheckRadioButton(mgButton);

            Report.WriteLine("Entering customer name");
            SendKeys(attributeName_xpath, Customer_Account_Name_Xpath, "97686 Zach Test");
            username = "97686 Zach Test";

            Report.WriteLine("Selecting No Invoice");
            Click(attributeName_xpath, CustomerInvoiceMethod_Dropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, Customer_Invoice_Method_Xpath, "No Invoice");

            Report.WriteLine("Clicking Save and Continue");
            clickMethods.ClickAndWait(attributeName_xpath, Save_And_Continue_Xpath);
        }


        [Given(@"the default carrier accessorial was set at the Corporate level")]
        public void GivenTheDefaultCarrierAccessorialWasSetAtTheCorporateLevel()
        {
            Report.WriteLine("Selecting NT2 from station id dropdown");
            Click(attributeName_xpath, StationId_DropDown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, Station_Id_DropDown_Xpath, "NT2");
            GlobalVariables.webDriver.WaitForPageLoad();
            stationId = "NT2";

            WaitForElementNotVisible(attributeName_id, Loading_Icon_Id, "Loading Icon");

            Report.WriteLine("Clicking Save and Continue");
            clickMethods.ClickAndWait(attributeName_xpath, Save_And_Continue_Xpath);
        }

        [Given(@"one or more default accessorials are displayed")]
        public void GivenOneOrMoreDefaultAccessorialsAreDisplayed()
        {
            Report.WriteLine("Getting displayed accessorials");
            List<IWebElement> addedAccessorials = GlobalVariables.webDriver.FindElements(By.XPath("//*[@class='AccType']")).ToList();

            foreach (IWebElement addedAccessorial in addedAccessorials)
            {
                string accessorialsText = addedAccessorial.Text;

                Regex accessorialNameFromString = new Regex("(?<=(\\), )|^)(.*?)(?=:)");

                MatchCollection matches = accessorialNameFromString.Matches(accessorialsText);

                List<string> matchesAsStrings = matches.Cast<Match>().Select(match => match.Value.ToLower()).ToList();
                displayedIndividualAccessorials.AddRange(matchesAsStrings);
            }

            Assert.IsTrue(displayedIndividualAccessorials.Count > 0);
            Report.WriteLine("There are default accessorials");
        }

        [Given(@"I clicked on the Set Individual Accessorials button of a carrier with carrier specific pricing")]
        public void GivenIClickedOnTheSetIndividualAccessorialsButtonOfACarrierWithCarrierSpecificPricing()
        {
            Report.WriteLine("Clicking on carrier level accessorial");
            Thread.Sleep(500);
            Click(attributeName_xpath, Gainshare_First_Carrier_Individual_Accessorial_Xpath);
            WaitForElementVisible(attributeName_xpath, Gainshare_Individual_Accessorial_Modal_Xpath, "Individual Accessorial Modal");
        }

        [Given(@"I edited an existing default accessorial in the Set Individual Accessorials modal")]
        public void GivenIEditedAnExistingDefaultAccessorialInTheSetIndividualAccessorialsModal()
        {
            Report.WriteLine("Entering 30 as the default accessorial value");
            SendKeys(attributeName_xpath, Gainshare_Individual_Accessorial_Modal_Pricing_Xpath, "30");
        }

        [Given(@"I delete an existing default accessorial in the Set Individual Accessorials modal")]
        public void GivenIDeleteAnExistingDefaultAccessorialInTheSetIndividualAccessorialsModal()
        {
            Report.WriteLine("Opening the delate individual accessorials modal");
            Click(attributeName_xpath, Gainshare_Delete_Individual_Accessorials_Button_Xpath);
            WaitForElementVisible(attributeName_xpath, Gainshare_Delete_Individual_Accessorials_Modal_Xpath, "Delete Individual Accessorials Modal");

            Report.WriteLine("Selecting the first accessorial");
            var accessorialsToDelete = GlobalVariables.webDriver.FindElements(By.XPath(Gainshare_Delete_Individual_Accessorials_Accessorial_Prefix_Xpath));
            Click(attributeName_xpath, Gainshare_Delete_Individual_Accessorials_Accessorial_Prefix_Xpath + accessorialsToDelete[0].Text);

            Report.WriteLine("Clicking the delete button");
            Click(attributeName_xpath, Gainshare_Delete_Individual_Accessorial_Delete_Button_Xpath);
            WaitForElementNotVisible(attributeName_xpath, Gainshare_Delete_Individual_Accessorials_Modal_Xpath, "Delete Individual Accessorials Modal");
        }

        [Given(@"I add an accessorial in the Set Individual Accessorials modal")]
        public void GivenIAddAnAccessorialInTheSetIndividualAccessorialsModal()
        {
            Report.WriteLine("Clicking add accessorial");
            Click(attributeName_xpath, Gainshare_Individual_Accessorial_Modal_Add_Accessorial);

            Report.WriteLine("Selecting appointment as the accessorial");
            Click(attributeName_xpath, "(//*[contains(@id, 'set-accessorial-modal')]//div[contains(@id, 'setAccessorial')])[last()]");
            SelectDropdownValueFromList(attributeName_xpath, "(//*[contains(@id, 'set-accessorial-modal')]//div[contains(@id, 'setAccessorial')])[last()]/div/ul", "APPOINTMENT");

            Report.WriteLine("Selecting flat over cost as the gainshare type");
            Click(attributeName_xpath, "(//*[contains(@id, 'set-accessorial-modal')]//div[contains(@id, 'setGainShareType')])[last()]");
            SelectDropdownValueFromList(attributeName_xpath, "(//*[contains(@id, 'set-accessorial-modal')]//div[contains(@id, 'setGainShareType')])[last()]/div/ul", "SET FLAT AMOUNT");

            Report.WriteLine("Entering 20 as the flat over cost value");
            SendKeys(attributeName_xpath, Gainshare_Individual_Accessorial_Added_Last_Cost_Xpath, "20");
        }

        [Given(@"I edited an existing default carrier accessorial in the Set Individual Accessorials modal")]
        public void GivenIEditedAnExistingDefaultCarrierAccessorialInTheSetIndividualAccessorialsModal()
        {
            Report.WriteLine("Editing gainshare value");
            SendKeys(attributeName_xpath, Gainshare_Individual_Accessorial_Default_Last_Cost_Xpath, "30");
        }

        [Given(@"I click the Set Individual Accessorials button")]
        public void GivenIClickTheSetIndividualAccessorialsButton()
        {
            Report.WriteLine("Opening the individual accessorial modal");
            WaitForElementVisible(attributeName_xpath, Gainshare_Set_Individual_Accessorials_Xpath, "Individual Accessorial Modal Link");
            Thread.Sleep(500);
            Click(attributeName_xpath, Gainshare_Set_Individual_Accessorials_Xpath);
            WaitForElementVisible(attributeName_xpath, Gainshare_Individual_Accessorial_Modal_Xpath, "Individual Accessorial Modal");
        }

        [Given(@"one or more default carrier accessorials are displayed and populated with the correct information")]
        [When(@"one or more default carrier accessorials are displayed and populated with the correct information")]
        public void GivenOneOrMoreDefaultCarrierAccessorialsAreDisplayed()
        {
            Thread.Sleep(1000);
            Report.WriteLine("Verifying that the carrier gainshare section is displayed");
            VerifyElementVisible(attributeName_xpath, Gainshare_First_Carrier_Section, "Carrier gainshare section");
        }

        [Given(@"I click the Save button")]
        [When(@"I click the Save button")]
        public void WhenIClickTheSaveButton()
        {
            Report.WriteLine("Clicking the save button");
            Click(attributeName_xpath, Gainshare_Individual_Accessorial_Modal_Save_Xpath);
            WaitForElementNotVisible(attributeName_xpath, Gainshare_Individual_Accessorial_Modal_Xpath, "Individual Accessorial Modal");
        }

        [Then(@"the Carrier-Specific Gainshare Pricing section of the carrier with a default accessorial will be expanded")]
        public void ThenTheCarrier_SpecificGainsharePricingSectionOfTheCarrierWithADefaultAccessorialWillBeExpanded()
        {
            VerifyElementVisible(attributeName_xpath, Gainshare_First_Carrier_Section, "First Carrier gainshare section");
            VerifyElementVisible(attributeName_xpath, Gainshare_First_Added_Carrier_Individual_Accessorials_Xpath, "Added Gainshare Carrier Accessorials");
        }

        [Then(@"the edited default carrier accessorial will be set at the customer level")]
        [Then(@"the added default accessorial will be set at the customer level")]
        [Then(@"the added accessorial will be set at the customer level")]
        [Then(@"the default accessorials will be set at the customer level")]
        public void ThenTheEditedDefaultAccessorialWillBeSetAtTheCustomerLevel()
        {
            Report.WriteLine("Getting individual accessorials");
            Thread.Sleep(500);
            Click(attributeName_xpath, Gainshare_Set_Individual_Accessorials_Xpath);
            WaitForElementVisible(attributeName_xpath, Gainshare_Individual_Accessorial_Modal_Xpath, "Individual Accessorial Modal");

            List<IWebElement> individualAccessorials = GlobalVariables.webDriver.FindElements(By.XPath("//div[contains(@id, 'setAccessorial')]/a/span")).ToList();
            List<IWebElement> individualGainshares = GlobalVariables.webDriver.FindElements(By.XPath("//div[contains(@id, 'setGainShareType')]/a/span")).ToList();
            List<IWebElement> individualPrices = GlobalVariables.webDriver.FindElements(By.XPath("//input[contains(@id, 'pricing-setGainshare')]")).ToList();

            List<IWebElement> individualPricesNotEmpty = new List<IWebElement>();

            foreach(IWebElement individualPrice in individualPrices)
            {
                if(individualPrice.GetAttribute("value") != "")
                {
                    individualPricesNotEmpty.Add(individualPrice);
                }
            }

            List<CsrCustomerAccessorial> individualAccessorialsFromScreen = new List<CsrCustomerAccessorial>();
            List<CsrCustomerAccessorial> carrierAccessorialsFromScreen = new List<CsrCustomerAccessorial>();

            GetAccessorialCode getAccessorialCodeFromName = new GetAccessorialCode();

            for (int i = 0; i < individualAccessorials.Count; i++)
            {
                string accessorialCode = getAccessorialCodeFromName.GetAccessorialCodeFromName(individualAccessorials[i].Text);
                individualAccessorialsFromScreen.Add(new CsrCustomerAccessorial()
                {
                    AccessorialName = individualAccessorials[i].Text,
                    GainShareType = individualGainshares[i].Text,
                    AccessorialValue = individualPricesNotEmpty[i].GetAttribute("value"),
                    AccessorialCode = accessorialCode
                });
            }
            Report.WriteLine("Closing individual accessorial modal");
            Click(attributeName_xpath, Gainshare_Individual_Accessorial_Modal_Close_Xpath);
            WaitForElementNotVisible(attributeName_xpath, Gainshare_Individual_Accessorial_Modal_Xpath, "Individual Accessorial Modal");

            List<IWebElement> carrierAccessorialSections = GlobalVariables.webDriver.FindElements(By.XPath(Gainshare_Carrier_Accessorial_List_Xpath)).ToList();

            Report.WriteLine("Getting carrier accessorials");
            int pos = 1;
            foreach (IWebElement setAccessorial in carrierAccessorialSections)
            {
                string carrierSCAC = setAccessorial.FindElement(By.XPath(Gainsshare_Carrier_ScacCode_General_Xpath)).Text;
                scrollElementIntoView(attributeName_xpath, "//span[contains(@id, 'set-accessorial" + pos + "')]");
                Thread.Sleep(500);
                setAccessorial.FindElement(By.XPath("//span[contains(@id, 'set-accessorial" + pos + "')]")).Click();
                WaitForElementVisible(attributeName_xpath, Gainshare_Individual_Accessorial_Modal_Xpath, "Individual Accessorial Modal");

                List<IWebElement> carrierAccessorialNames = GlobalVariables.webDriver.FindElements(By.XPath("//div[contains(@id, 'setAccessorial')]/a/span")).ToList();
                List<IWebElement> carrierGainshareTypes = GlobalVariables.webDriver.FindElements(By.XPath("//div[contains(@id, 'setGainShareType')]/a/span")).ToList();
                List<IWebElement> carrierAccessorialPrices = GlobalVariables.webDriver.FindElements(By.XPath("//input[contains(@id, 'pricing-setGainshare')]")).ToList();

                List<IWebElement> carrierPricesNotEmpty = new List<IWebElement>();

                foreach (IWebElement carrierAccessorialPrice in carrierAccessorialPrices)
                {
                    if (carrierAccessorialPrice.GetAttribute("value") != "")
                    {
                        carrierPricesNotEmpty.Add(carrierAccessorialPrice);
                    }
                }

                for (int i = 0; i < carrierAccessorialNames.Count; i++)
                {
                    string carrierAccessorialCode = getAccessorialCodeFromName.GetAccessorialCodeFromName(carrierAccessorialNames[i].Text);
                    carrierAccessorialsFromScreen.Add(new CsrCustomerAccessorial()
                    {
                        carrierScacCode = carrierSCAC,
                        AccessorialName = carrierAccessorialNames[i].Text,
                        GainShareType = carrierGainshareTypes[i].Text,
                        AccessorialValue = carrierPricesNotEmpty[i].GetAttribute("value"),
                        AccessorialCode = carrierAccessorialCode
                    });

                }

                Report.WriteLine("Closing individual accessorial modal");
                Click(attributeName_xpath, Gainshare_Individual_Accessorial_Modal_Close_Xpath);
                WaitForElementNotVisible(attributeName_xpath, Gainshare_Individual_Accessorial_Modal_Xpath, "Individual accessorial modal");
                pos++;
            }

            Thread.Sleep(500);
            clickMethods.ClickAndWait(attributeName_xpath, PricingModel_SaveAndContinuebutton);

            Report.WriteLine("Navigating to Portal users page");
            clickMethods.ClickAndWait(attributeName_xpath, SavedItemsAndAddresses_SaveAndContinue_button_Xpath);

            Report.WriteLine("Navigating to Review and Submit page");
            clickMethods.ClickAndWait(attributeName_xpath, PortalUsers_SaveAndContinue_button_Xpath);

            Report.WriteLine("Submitting the CSR");
            clickMethods.ClickAndWait(attributeName_xpath, ReviewSubmitPage_Submit_Csr_Button_Xpath);

            List<DefaultAccessorialSetupModel> customerAccessorialsFromDb = GetCustomerAccessorials(username);

            Report.WriteLine("Verifying amount of individual accessorials in db is the same as those on screen");
            Assert.AreEqual(individualAccessorialsFromScreen.Count, customerAccessorialsFromDb.Count);

            List<DefaultAccessorialSetupModel> carrierAccessorialsFromDb = GetCarrierAccessorials(username);

            Report.WriteLine("Verifying amount of carrier accessorials in db is the same as those on screen");
            Assert.AreEqual(carrierAccessorialsFromScreen.Count, carrierAccessorialsFromDb.Count);

            Report.WriteLine("Verifying individual accessorials match from DB");
            accessorialHelper.compareIndividualAccessorials(customerAccessorialsFromDb, individualAccessorialsFromScreen);

            Report.WriteLine("Verifying carrier accessorials match from DB");
            accessorialHelper.compareIndividualAccessorials(carrierAccessorialsFromDb, carrierAccessorialsFromScreen);
        }

        [Then(@"the default accessorials will not be set at the customer level")]
        public void ThenTheDefaultAccessorialsWillNotBeSetAtTheCustomerLevel()
        {
            Thread.Sleep(500);
            clickMethods.ClickAndWait(attributeName_xpath, PricingModel_SaveAndContinuebutton);

            Report.WriteLine("Navigating to Portal users page");
            clickMethods.ClickAndWait(attributeName_xpath, SavedItemsAndAddresses_SaveAndContinue_button_Xpath);

            Report.WriteLine("Navigating to Review and Submit page");
            clickMethods.ClickAndWait(attributeName_xpath, PortalUsers_SaveAndContinue_button_Xpath);

            Report.WriteLine("Submitting the CSR");
            clickMethods.ClickAndWait(attributeName_xpath, ReviewSubmitPage_Submit_Csr_Button_Xpath);

            List<DefaultAccessorialSetupModel> customerAccessorialsFromDb = GetCustomerAccessorials(username);

            Report.WriteLine("Verifying amount of individual accessorials in db is zero");
            Assert.AreEqual(0, customerAccessorialsFromDb.Count);

            List<DefaultAccessorialSetupModel> carrierAccessorialsFromDb = GetCarrierAccessorials(username);

            Report.WriteLine("Verifying amount of carrier accessorials in db is zero");
            Assert.AreEqual(0, carrierAccessorialsFromDb.Count);
        }


        private List<DefaultAccessorialSetupModel> GetCarrierAccessorials(string customerName)
        {
            int accountID = getAccountID.GetCsrAccountIdFromDB(customerName);

            return getCarrierAccessorials.GetCarrierAccessorialsFromCsrStage(accountID);
        }

        private List<DefaultAccessorialSetupModel> GetCustomerAccessorials(string customerName)
        {
            int accountID = getAccountID.GetCsrAccountIdFromDB(customerName);

            return getCustomerAccessorials.GetAccessorialsFromCsrStage(accountID);
        }

        private List<DefaultAccessorialSetupModel> GetIndividualAccessorialsStationLevel(string customerName)
        {
            stationId = getStationId.GetStationIDFromCustomerName(customerName);
            return getStationIndividualDefaultAccessorials.GetDefaultIndividualAccessorialsForStation(stationId);
        }

        private List<DefaultAccessorialSetupModel> GetCarrierAccessorialsStationLevel(string customerName)
        {
            string stationID = getStationId.GetStationIDFromCustomerName(customerName);
            return getStationCarrierDefaultAccessorials.GetCarrierDefaultAccessorialsForStation(stationID);
        }

        private List<DefaultAccessorialSetupModel> GetIndividualAccessorialsCorporateLevel()
        {
            return getCorporateDefaultAccessorials.GetDefaultIndividualAccessorialsForCorporate();
        }
        private List<DefaultAccessorialSetupModel> GetCarrierAccessorialsCorporateLevel()
        {
            return getCorporateCarrierDefaultAccessorials.GetCarrierDefaultAccessorialsForCorporate();
        }

        private List<DefaultAccessorialSetup> CreateDefaultAccessorials()
        {
            List<DefaultAccessorialSetup> defaultAccessorials = new List<DefaultAccessorialSetup>
            {
                new DefaultAccessorialSetup
                {
                    AccessorialCode = "IPU",
                    AccessorialName = "Inside Pickup",
                    AccessorialValue = 40,
                    CreatedBy = "Automation 97686",
                    CreatedDate = DateTime.Now,
                    ModifiedBy = "Automation 97686",
                    ModifiedDate = DateTime.Now,
                    GainshareCostingTypeId = 1
                },

                new DefaultAccessorialSetup
                {
                    AccessorialCode = "INAR",
                    AccessorialName = "Ins-All Risk",
                    AccessorialValue = 60,
                    CreatedBy = "Automation 97686",
                    CreatedDate = DateTime.Now,
                    ModifiedBy = "Automation 97686",
                    ModifiedDate = DateTime.Now,
                    GainshareCostingTypeId = 1,
                    CarrierSCAC = "AACT"
                },

                new DefaultAccessorialSetup
                {
                    AccessorialCode = "LMAC1",
                    AccessorialName = "Limited Access Pickup",
                    AccessorialValue = 60,
                    CreatedBy = "Automation 97686",
                    CreatedDate = DateTime.Now,
                    ModifiedBy = "Automation 97686",
                    ModifiedDate = DateTime.Now,
                    GainshareCostingTypeId = 1,
                    CarrierSCAC = "AACT"
                },

                new DefaultAccessorialSetup
                {
                    AccessorialCode = "HAZM",
                    AccessorialName = "Hazardous Material",
                    AccessorialValue = 80,
                    CreatedBy = "Automation 97686",
                    CreatedDate = DateTime.Now,
                    ModifiedBy = "Automation 97686",
                    ModifiedDate = DateTime.Now,
                    GainshareCostingTypeId = 1,
                    CarrierSCAC = "BBFG"
                }
            };

            return defaultAccessorials;
        }

        [BeforeScenario("97686", "96964")]
        private void DeleteAllCsrStageInformation()
        {
            DeleteAllCsrStageInfoForUser deleteAllCsrStageInfo = new DeleteAllCsrStageInfoForUser();
            string username = "97686 primary station accessorials";
            deleteAllCsrStageInfo.DeleteAllCsrStageInformation(username);

            username = "97686 Zach Test";
            deleteAllCsrStageInfo.DeleteAllCsrStageInformation(username);

            username = "97686 sub station level";
            deleteAllCsrStageInfo.DeleteAllCsrStageInformation(username);

            username = "GS - Ninja Customer not revised";
            deleteAllCsrStageInfo.DeleteAllCsrStageInformation(username);
        }

        [BeforeScenario("97686CorporateAccessorials", "97682CorporateAccessorials")]
        private void AddCorporateAccessorials()
        {
            DBHelper.DeleteDefaultCorporateAccessorials();

            List<DefaultAccessorialSetup> defaultCorporateAccessorials = CreateDefaultAccessorials();
            DBHelper.InsertDefaultAccessorials(defaultCorporateAccessorials);
        }

        [BeforeScenario("97686StationAccessorials", "97682StationAccessorials")]
        private void AddStationAccessorials()
        {
            DBHelper.DeleteDefaultStationAccessorials("NTS");

            List<DefaultAccessorialSetup> defaultStationAccessorials = CreateDefaultAccessorials();
            for(int i =0; i < defaultStationAccessorials.Count; i++)
            {
                defaultStationAccessorials[i].StationId = "NTS";
            }
            DBHelper.InsertDefaultAccessorials(defaultStationAccessorials);
        }
    }
}