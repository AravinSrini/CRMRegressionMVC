using CRM.UITest.CommonMethods;
using CRM.UITest.Helper.Common;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Csr.Gainshare___New_Logic
{
    [Binding]
    public sealed class _96964___Inherit_Default_Accessorial___Submit_CSR___Gainshare_New_Logic_OptionStepDefinition : Submit_CSR
    {
        ClickAndWaitMethods clickMethods = new ClickAndWaitMethods();
        [Given(@"I am submitting a new csr")]
        public void GivenIAmSubmittingANewOrRevisedCsr()
        {
            string baseURL = ConfigurationManager.AppSettings["BaseUrl"];
            GlobalVariables.webDriver.Url = baseURL + "/L/Customer/AccountInformation";
        }

        [Given(@"I am submitting a revised csr for customer ""(.*)""")]
        public void GivenIAmSubmittingARevisedCsrForCustomer(string customerName)
        {
            Report.WriteLine("Navigating to Usermanagement page");
            WaitForElementVisible(attributeName_xpath, UserManagementIcon_Xpath, "User Management Icon");
            clickMethods.ClickAndWait(attributeName_xpath, UserManagementIcon_Xpath);

            Report.WriteLine("Searching GS - Ninja Customer not revised in the customer profiles");
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementNotVisible(attributeName_id, Loading_Icon_Id, "Loading Icon");
            SendKeys(attributeName_id, SearchCustomer_id, customerName);
            Thread.Sleep(4000);
            Report.WriteLine("Navigating to customer details");
            clickMethods.ClickAndWait(attributeName_xpath, "//a[contains(.,'" + customerName + "')]");
        }
       
        [Given(@"I am on the Pricing Model page for a new CSR")]
        public void GivenIAmOnThePricingModelPageForANewCSR()
        {
            Report.WriteLine("Selecting ZZZ from station id dropdown");
            Click(attributeName_xpath, StationId_DropDown_Xpath);
            WebDriverHelpers.ClickElementFromDropDown(GlobalVariables.webDriver.FindElement(By.XPath("//*[@id='customer-station-id_listbox']/li[text() = 'ZZZ']")));
            GlobalVariables.webDriver.WaitForPageLoad();

            WaitForElementNotVisible(attributeName_id, Loading_Icon_Id, "Loading Icon");
            Report.WriteLine("Clicking primary account");
            Click(attributeName_xpath, Primary_CSR_Type_Xpath);
            Report.WriteLine("Clicking MG as TMS type");
            IWebElement mg = GlobalVariables.webDriver.FindElement(By.XPath("//input[contains(@id, 'tms-systems-1')]"));
            WebDriverHelpers.SetAttribute(mg, "checked", "true");
            Report.WriteLine("Entering customer account name as 96964 customer");
            SendKeys(attributeName_xpath, Customer_Account_Name_Xpath, "96964 customer");

            Report.WriteLine("Selecting No Invoice");
            Click(attributeName_xpath, CustomerInvoiceMethod_Dropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, Customer_Invoice_Method_Xpath, "No Invoice");

            Report.WriteLine("Clicking Save and Continue");
            clickMethods.ClickAndWait(attributeName_xpath, Save_And_Continue_Xpath);
            Thread.Sleep(500);
            Report.WriteLine("Entering 96964 as the location name");
            SendKeys(attributeName_xpath, CustomerLocation_Name_Textbox_Xpath, "96964");
            Report.WriteLine("Entering 96964 as Address line 1");
            SendKeys(attributeName_xpath, CustomerLocation_Address1_Textbox_Xpath, "96964");
            Report.WriteLine("Entering Chicago as the city");
            SendKeys(attributeName_xpath, CustomerLocation_City_Textbox_Xpath, "Chicago");

            Report.WriteLine("Selecting AK as the state");
            Click(attributeName_xpath, CustomerLocation_StateDropDown_Xpath);
            WebDriverHelpers.ClickElementFromDropDown(GlobalVariables.webDriver.FindElement(By.XPath("//*[@id='state-customer-location-select_listbox']/li[2]")));
            GlobalVariables.webDriver.WaitForPageLoad();

            Report.WriteLine("Entering 60606 as the zip code");
            SendKeys(attributeName_xpath, CustomerLocation_Zip_Textbox_Xpath, "60606");

            Report.WriteLine("Entering 96964 as the contact name");
            SendKeys(attributeName_xpath, CustomerContactInformation_Name_Textbox_Xpath, "96964");
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

        [Given(@"I am on the Pricing Model page")]
        [When(@"I am submitting a revised csr and go to the Pricing Model Page")]
        public void GivenIAmOnThePricingModelPage()
        {
            WaitForElementNotVisible(attributeName_id, Loading_Icon_Id, "Loading Icon");
            Report.WriteLine("Clicking on submit a revised CSR");
            WebDriverHelpers.ClickElement(GlobalVariables.webDriver.FindElement(By.Id(SubmitReviseCSRBtn_id)));
            WaitForElementVisible(attributeName_xpath, Revised_Pricing_Model, "Revised Pricing Model");
            Report.WriteLine("Clicking on pricing model");
            Thread.Sleep(2000);
            Click(attributeName_xpath, Revised_Pricing_Model);

            GlobalVariables.webDriver.WaitForPageLoad();

            Report.WriteLine("Verifying User is navigated to the customer pricing page");

            Verifytext(attributeName_xpath, "//*[@id='main']/div[2]/div/h3", "Pricing Model");
        }

        [Given(@"the pricing model of the customer is Gainshare and the CRM Rating Logic flag is (.*)")]
        public void GivenThePricingModelOfTheCustomerIsGainshareAndTheCRMRatingLogicFlagIsYes(string ratingFlag)
        {

            Report.WriteLine("Navigating to Usermanagement page");
            WaitForElementVisible(attributeName_xpath, UserManagementIcon_Xpath, "User Management Icon");
            clickMethods.ClickAndWait(attributeName_xpath, UserManagementIcon_Xpath);

            if (ratingFlag.Equals("Yes"))
            {
                Report.WriteLine("Searching GS - Ninja Customer in the customer profiles");
                SendKeys(attributeName_id, SearchCustomer_id, "GS - Ninja Customer not revised");
                Thread.Sleep(4000);
                Report.WriteLine("Navigating to GS - Ninja Customer's customer details");
                clickMethods.ClickAndWait(attributeName_xpath, "//a[contains(.,'GS - Ninja Customer not revised')]");
            }
            else
            {
                Report.WriteLine("Searching GS - Ninja Customer no rating logic in the customer profiles");
                SendKeys(attributeName_id, SearchCustomer_id, "GS - Ninja Customer no rating logic");
                Thread.Sleep(4000);
                Report.WriteLine("Navigating to GS - Ninja Customer no rating logic's customer details");
                clickMethods.ClickAndWait(attributeName_xpath, "//a[contains(.,'GS - Ninja Customer no rating logic')]");
            }
        }

        [Given(@"I checked the Gainshare - New Logic box")]
        [Given(@"I select yes for Gainshare - New Logic")]
        [When(@"I check the Gainshare - New Logic checkbox")]
        public void GivenISelectYesForGainshare_NewLogic()
        {
            Report.WriteLine("Clicking Gainshare New Logic checkbox");
            IWebElement gainshareCheckbox = GlobalVariables.webDriver.FindElement(By.XPath(PricingModel_Gainshare_New_Logic_Checkbox_Input_Xpath));
            bool isChecked = gainshareCheckbox.Selected;

            if (!isChecked)
            {
                WebDriverHelpers.ClickElement(gainshareCheckbox);
            }
        }

        [Given(@"I uncheck the Gainshare - New Logic checkbox")]
        [Given(@"I check the Gainshare - New Logic checkbox")]
        [When(@"I swap the gainshare new logic checkbox value")]
        public void GivenICheckTheGainshare_NewLogicCheckbox()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, PricingModel_Gainshare_New_Logic_Checkbox_Xpath);
        }

        [Given(@"my Pricing Model Type is Gainshare")]
        [Given(@"the pricing model of the customer is Gainshare")]
        [When(@"I choose Gainshare from the Select A Pricing Type drop down list")]
        public void WhenIChooseGainshareFromTheSelectAPricingTypeDropDownList()
        {
            Report.WriteLine("Selecting Gainshare as the pricing type");
            Thread.Sleep(2000);
            Click(attributeName_xpath, PricingType_DropDown_Xpath);
            Thread.Sleep(500);
            SelectDropdownValueFromList(attributeName_xpath, PricingType_DropDownDropDownList_Xpath, "Gainshare");
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [When(@"I set Gainshare - New Logic to (.*)")]
        [Given(@"I set Gainshare - New Logic to (.*)")]
        public void GivenISetGainshare_NewLogicTo(string option)
        {
            IWebElement gainshareCheckbox = GlobalVariables.webDriver.FindElement(By.XPath(PricingModel_Gainshare_New_Logic_Checkbox_Input_Xpath));
            bool isChecked = gainshareCheckbox.Selected;

            if (option.Equals("Yes"))
            {
                if (!isChecked)
                {
                    Click(attributeName_xpath, PricingModel_Gainshare_New_Logic_Checkbox_Xpath);
                }                
            }
            else
            {
                if (isChecked)
                {
                    Click(attributeName_xpath, PricingModel_Gainshare_New_Logic_Checkbox_Xpath);
                }
            }
        }


        [When(@"I click the save button")]
        public void WhenIClickTheSaveButton()
        {
            Report.WriteLine("Setting gainshare pricing values");
            WaitForElementVisible(attributeName_id, Gainshare_percentage_Id, "Gainshare percentage");
            SendKeys(attributeName_id, Gainshare_percentage_Id, "50");
            SendKeys(attributeName_xpath, Gainshare_Minimum_Textbox_xpath, "50");
            SendKeys(attributeName_xpath, Gainshare_Master_Accessorial_Charge_Textbox_Xpath, "50");

            Thread.Sleep(2000);

            Report.WriteLine("Setting Carriers Excluded to no");
            IWebElement mg = GlobalVariables.webDriver.FindElement(By.Id("pricing-carriersExclud-no"));
            WebDriverHelpers.CheckRadioButton(mg);

            Report.WriteLine("Setting Household Goods to no");
            mg = GlobalVariables.webDriver.FindElement(By.Id("pricing-household-no"));
            WebDriverHelpers.CheckRadioButton(mg);

            Report.WriteLine("Clicking the saved button");

            List<IWebElement> carrierScacDropDowns = GlobalVariables.webDriver.FindElements(By.XPath("//div[contains(@id, 'carrier_scac_code_')]/a/span")).ToList();            

            for (int i = 0; i < carrierScacDropDowns.Count; i++)
            {
                if (carrierScacDropDowns[i].Text.Equals("Select an Option"))
                {
                    Click(attributeName_xpath, "//*[@id='carrier_scac_code_" + i + "_chosen']");
                    SelectDropdownValueFromList(attributeName_xpath, "//*[@id='carrier_scac_code_" + i + "_chosen']", "ABFL");
                }
            }    

            List<IWebElement> gainsharePercentageInputs = GlobalVariables.webDriver.FindElements(By.XPath("//*/input[contains(@id, 'gainshare-percentage')]")).ToList();
            foreach (IWebElement gainsharePercInput in gainsharePercentageInputs)
            {
                gainsharePercInput.SendKeys("50");
            }
            clickMethods.ClickAndWait(attributeName_xpath, PricingModel_SaveAndContinuebutton);
        }

        [When(@"I then click the back button on the saved items and addresses page")]
        public void WhenIThenClickTheBackButtonOnTheSavedItemsAndAddressesPage()
        {
            Report.WriteLine("Clicking the back button");
            clickMethods.ClickAndWait(attributeName_xpath, Saved_Address_Back_Button_Xpath);
        }

        [Given(@"I arrive on the Review and Submit page")]
        [When(@"I arrive on the Review and Submit page")]
        public void WhenIArriveOnTheReviewAndSubmitPage()
        {
            Report.WriteLine("Setting gainshare pricing values");
            WaitForElementVisible(attributeName_id, Gainshare_percentage_Id, "Gainshare percentage");
            SendKeys(attributeName_id, Gainshare_percentage_Id, "50");
            SendKeys(attributeName_xpath, Gainshare_Minimum_Textbox_xpath, "50");
            SendKeys(attributeName_xpath, Gainshare_Master_Accessorial_Charge_Textbox_Xpath, "50");

            Thread.Sleep(2000);

            Report.WriteLine("Setting Carriers Excluded to no");
            IWebElement mg = GlobalVariables.webDriver.FindElement(By.Id("pricing-carriersExclud-no"));
            WebDriverHelpers.CheckRadioButton(mg);

            Report.WriteLine("Setting Household Goods to no");
            mg = GlobalVariables.webDriver.FindElement(By.Id("pricing-household-no"));
            WebDriverHelpers.CheckRadioButton(mg);

            Report.WriteLine("Navigating to saved Items and Addresses");
            List<IWebElement> carrierSpecificGainshares = GlobalVariables.webDriver.FindElements(By.XPath("//*[contains(@id, 'addtionalItem-')]")).ToList();
            for (int i = 0; i < carrierSpecificGainshares.Count; i++)
            {
                SendKeys(attributeName_xpath, "//input[contains(@id, 'gainshare-percentage-" + i + "')]", "50");
                SendKeys(attributeName_xpath, "//input[contains(@id, 'pricing-min-threshold-" + i + "')]", "50");
                SendKeys(attributeName_xpath, "//input[contains(@id, 'pricing-min-amount-" + i + "')]", "50");
                SendKeys(attributeName_xpath, "//input[contains(@id, 'pricing-min-" + i + "')]", "50");
                SendKeys(attributeName_xpath, "//input[contains(@id, 'pricing-master-Acc-" + i + "')]", "50");
            }

            List<IWebElement> carrierScacDropDowns = GlobalVariables.webDriver.FindElements(By.XPath("//div[contains(@id, 'carrier_scac_code_')]/a/span")).ToList();

            for (int i = 0; i < carrierScacDropDowns.Count; i++)
            {
                if (carrierScacDropDowns[i].Text.Equals("Select an Option"))
                {
                    Click(attributeName_xpath, "//*[@id='carrier_scac_code_" + i + "_chosen']");
                    SelectDropdownValueFromList(attributeName_xpath, "//*[@id='carrier_scac_code_" + i + "_chosen']", "ABFL");
                }
            }
            clickMethods.ClickAndWait(attributeName_id, "save-Pricing-Model");

            Report.WriteLine("Navigating to Portal users page");
            clickMethods.ClickAndWait(attributeName_xpath, SavedItemsAndAddresses_SaveAndContinue_button_Xpath);

            Report.WriteLine("Navigating to Review and Submit page");
            clickMethods.ClickAndWait(attributeName_xpath, PortalUsers_SaveAndContinue_button_Xpath);
        }

        [Then(@"the gainshare new logic check box will be selected")]
        public void ThenTheGainshareNewLogicCheckBoxWillBeSelected()
        {
            IWebElement isChecked = GlobalVariables.webDriver.FindElement(By.XPath(PricingModel_Gainshare_New_Logic_Checkbox_Input_Xpath));
            bool isSelected = isChecked.Selected;
            if (!isSelected)
            {
                Report.WriteFailure("Checkbox was not selected when it should be");
            }
        }
        
        [Then(@"I will see a field Gainshare - New Logic")]
        public void ThenIWillSeeAFieldGainshare_NewLogic()
        {
            Report.WriteLine("Verifying Gainshare - New Logic label is visible");
            VerifyElementVisible(attributeName_xpath, PricingModel_Gainshare_New_Logic_Label_Xpath, "Gainshare - New Logic label");
        }

        [Then(@"I will see a check box associated to the new field")]
        public void ThenIWillSeeACheckBoxAssociatedToTheNewField()
        {
            Report.WriteLine("Verify Gainshare - New Logic checkbox is visible");
            VerifyElementVisible(attributeName_xpath, PricingModel_Gainshare_New_Logic_Label_Xpath, "Gainshare - New Logic checkbox");
        }

        [Then(@"the check box by default will not be selected")]
        public void ThenTheCheckBoxByDefaultWillNotBeSelected()
        {
            IWebElement gainshareCheckbox = GlobalVariables.webDriver.FindElement(By.XPath(PricingModel_Gainshare_New_Logic_Checkbox_Xpath));
            bool isChecked = gainshareCheckbox.Selected;

            if (isChecked)
            {
                Report.WriteFailure("Checkbox was selected when it shouldn't be");
            }
            Report.WriteLine("Checkbox was not selected ");
        }

        [Then(@"I will see a new field Gainshare - New Logic")]
        public void ThenIWillSeeANewFieldGainshare_NewLogic()
        {
            Report.WriteLine("Verifying the gainshare logic field is visible");
            VerifyElementVisible(attributeName_xpath, ReviewSubmitPage_Gainshare_New_Logic_Xpath, "Gainshare - New Logic field");
        }

        [Then(@"the new field will be located below the Master Accessorial Charge field")]
        public void ThenTheNewFieldWillBeLocatedBelowTheMasterAccessorialChargeField()
        {
            int gainshareYCoord = GlobalVariables.webDriver.FindElement(By.XPath(ReviewSubmitPage_Gainshare_New_Logic_Xpath)).Location.Y;
            int masterChargeYCoord = GlobalVariables.webDriver.FindElement(By.XPath(ReviewSubmitPage_PricingModel_MasterCharge_Xpath)).Location.Y;

            if ((gainshareYCoord < masterChargeYCoord))
                Report.WriteFailure("Gainshare - New Logic was not below Master Accessorial Charge");
        }

        [Then(@"the new field will be located above the Individual Accessorial Charges field")]
        public void ThenTheNewFieldWillBeLocatedAboveTheIndividualAccessorialChargesField()
        {
            int gainshareYCoord = GlobalVariables.webDriver.FindElement(By.XPath(ReviewSubmitPage_Gainshare_New_Logic_Xpath)).Location.Y;
            int individualAccessorialChargeYCoord = GlobalVariables.webDriver.FindElement(By.XPath(ReviewSubmitPage_PricingModel_IndividualCharge_Xpath)).Location.Y;

            if ((gainshareYCoord > individualAccessorialChargeYCoord))
                Report.WriteFailure("Gainshare - New Logic was not below Individual Accessorial Charges");
        }

        [Then(@"the Gainshare - New Logic check box will be checked based on the rating logic value (.*)")]
        public void ThenTheGainshare_NewLogicCheckBoxWillBeCheckedBasedOnTheRatingLogicValueYes(string ratingFlag)
        {
            if(ratingFlag.Equals("Yes"))
            {
                Report.WriteLine("Verifying that the gainshare new logic checkbox is checked");
                IWebElement gainshareCheckbox = GlobalVariables.webDriver.FindElement(By.XPath(PricingModel_Gainshare_New_Logic_Checkbox_Input_Xpath));
                bool isChecked = gainshareCheckbox.Selected;
                Assert.IsTrue(isChecked);
            }
            else
            {
                Report.WriteLine("Verifying that the gainshare new logic checkbox is not checked");
                IWebElement gainshareCheckbox = GlobalVariables.webDriver.FindElement(By.XPath(PricingModel_Gainshare_New_Logic_Checkbox_Input_Xpath));
                bool isChecked = gainshareCheckbox.Selected;
                Assert.IsFalse(isChecked);
            }
        }

        [Then(@"I have the option to interact with the checkbox")]
        public void ThenIHaveTheOptionToInteractWithTheCheckbox()
        {
            Report.WriteLine("Verifing that the gainshare new logic checkbox is interactable");
            bool isClickable = GlobalVariables.webDriver.FindElement(By.XPath(PricingModel_Gainshare_New_Logic_Checkbox_Xpath)).Enabled;
            Assert.IsTrue(isClickable);
        }

        [Then(@"the value associated to the Gainshare - New Logic field will not be (.*)")]
        public void ThenTheValueAssociatedToTheGainshare_NewLogicFieldWillNotBeYes(string newLogicFlag)
        {
            Report.WriteLine("Verifying the gainshare - new logic field value not " + newLogicFlag);
            if (newLogicFlag.Equals("Yes"))
            {
                string gainshareLogic = GlobalVariables.webDriver.FindElement(By.XPath(ReviewSubmitPage_Gainshare_New_Logic_Xpath)).Text;
                Assert.AreEqual("No", gainshareLogic);
            }
            else
            {
                string gainshareLogic = GlobalVariables.webDriver.FindElement(By.XPath(ReviewSubmitPage_Gainshare_New_Logic_Xpath)).Text;
                Assert.AreEqual("Yes", gainshareLogic);
            }
        }

        [Then(@"the value associated to the Gainshare - New Logic field will be (.*)")]
        public void ThenTheValueAssociatedToTheGainshare_NewLogicFieldWillBeYes(string newLogicFlag)
        {
            Report.WriteLine("Verifying the gainshare - new logic field value is " + newLogicFlag);
            if(newLogicFlag.Equals("Yes"))
            {
                string gainshareLogic = GlobalVariables.webDriver.FindElement(By.XPath(ReviewSubmitPage_Gainshare_New_Logic_Xpath)).Text;
                Assert.AreEqual("Yes", gainshareLogic);
            }
            else
            {
                string gainshareLogic = GlobalVariables.webDriver.FindElement(By.XPath(ReviewSubmitPage_Gainshare_New_Logic_Xpath)).Text;
                Assert.AreEqual("No", gainshareLogic);
            }
        }
    }
}
