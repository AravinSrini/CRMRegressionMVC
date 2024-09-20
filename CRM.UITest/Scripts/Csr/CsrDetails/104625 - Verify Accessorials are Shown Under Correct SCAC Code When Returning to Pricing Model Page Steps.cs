using CRM.UITest.CommonMethods;
using CRM.UITest.Helper.Common;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Csr.CsrDetails
{
    [Binding]
    public sealed class _104625___Verify_Accessorials_are_Shown_Under_Correct_SCAC_Code_When_Returning_to_Pricing_Model_Page_Steps : Submit_CSR
    {
        [Given(@"I have entered valid information to the Gainshare fields")]
        public void GivenIHaveEnteredValidInformationToTheGainshareFields()
        {
            Thread.Sleep(2000);
            Report.WriteLine("Entering values into Gainshare fields of Pricing Model Page");
            SendKeys(attributeName_id, Gainshare_percentage_Id, "50");

            Report.WriteLine("Setting Carriers Excluded to no");
            IWebElement mg = GlobalVariables.webDriver.FindElement(By.Id("pricing-carriersExclud-no"));
            WebDriverHelpers.CheckRadioButton(mg);

            Report.WriteLine("Setting Household Goods to no");
            mg = GlobalVariables.webDriver.FindElement(By.Id("pricing-household-no"));
            WebDriverHelpers.CheckRadioButton(mg);
        }

        [Given(@"I have added two accessorials to the Gainshare area")]
        public void GivenIHaveAddedTwoAccessorialsToTheGainshareArea()
        {
            Report.WriteLine("Adding two accessorials to gainshare customer");
            Thread.Sleep(2000);
            Click(attributeName_xpath, Gainshare_Set_Individual_Accessorials_Xpath);
            Click(attributeName_xpath, Gainshare_Individual_Accessorial_First_Accessorial_Name_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, Gainshare_Carrier_SetIndividualAccessorials_Modal_AccessorialType_Dropdown_Values, "APPOINTMENT");
            Click(attributeName_xpath, Gainshare_Carrier_SetIndividualAccessorials_Modal_GainshareType_Dropdown);
            SelectDropdownValueFromList(attributeName_xpath, Gainshare_Carrier_SetIndividualAccessorials_Modal_GainshareType_Dropdown_Values, "FLAT OVER COST");
            SendKeys(attributeName_xpath, Gainshare_Carrier_SetIndividualAccessorials_Modal_FlatOverCost, "20");

            Click(attributeName_xpath, Gainshare_Individual_Accessorial_Modal_Add_Accessorial);

            Click(attributeName_xpath, Gainshare_Carrier_SetIndividualAccessorials_Modal_AccessorialType_Dropdown_2);
            scrollpagedown();
            SelectDropdownValueFromList(attributeName_xpath, Gainshare_Carrier_SetIndividualAccessorials_Modal_AccessorialType_Dropdown_Values_2, "COD");
            Click(attributeName_xpath, Gainshare_Carrier_SetIndividualAccessorials_Modal_GainshareType_Dropdown_2);
            SelectDropdownValueFromList(attributeName_xpath, Gainshare_Carrier_SetIndividualAccessorials_Modal_GainshareType_Dropdown_Values, "FLAT OVER COST");
            SendKeys(attributeName_xpath, Gainshare_Carrier_SetIndividualAccessorials_Modal_FlatOverCost2, "20");
            Click(attributeName_xpath, Gainshare_Individual_Accessorial_Modal_Save_Xpath);
        }

        [Given(@"I click Add Carrier-Specific Gainshare")]
        public void GivenIClickAddCarrier_SpecificGainshare()
        {
            Thread.Sleep(2000);
            Report.WriteLine("Clicking Add Carrier-Specific Gainshare");
            scrollpagedown();
            Click(attributeName_xpath, Gainshare_Add_Carrier_Specific_Gainshare_Pricing_Xpath);
        }

        [Given(@"I have selected ""(.*)"" for the SCAC Code on Carrier-Specific Gainshare One")]
        public void GivenIHaveSelectedForTheSCACCodeOnCarrier_SpecificGainshareOne(string scacCode)
        {
            Report.WriteLine("Selecting " + scacCode + " as the SCAC Code on carrier gainshare number 1");
            Click(attributeName_xpath, Gainshare_Carrier_ScacCode_1_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, Gainshare_Carrier_ScacCode_1_DropdownList_Xpath, scacCode);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I have selected ""(.*)"" for the SCAC Code on Carrier-Specific Gainshare Two")]
        public void GivenIHaveSelectedForTheSCACCodeOnCarrier_SpecificGainshareTwo(string scacCode)
        {
            Report.WriteLine("Selecting " + scacCode + " as the SCAC Code on carrier gainshare number 1");
            Click(attributeName_xpath, Gainshare_Carrier_ScacCode_2_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, Gainshare_Carrier_ScacCode_2_DropdownList_Xpath, scacCode);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I have selected ""(.*)"" for the SCAC Code on Carrier-Specific Gainshare Three")]
        public void GivenIHaveSelectedForTheSCACCodeOnCarrier_SpecificGainshareThree(string scacCode)
        {
            Thread.Sleep(2000);
            Report.WriteLine("Selecting " + scacCode + " as the SCAC Code on carrier gainshare number 1");
            Click(attributeName_xpath, Gainshare_Carrier_ScacCode_3_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, Gainshare_Carrier_ScacCode_3_DropdownList_Xpath, scacCode);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I have entered ""(.*)"" for the Gainshare Percentage on Carrier-Specific Gainshare One")]
        public void GivenIHaveEnteredForTheGainsharePercentageOnCarrier_SpecificGainshareOne(string gainsharePercentage)
        {
            Report.WriteLine("Entering " + gainsharePercentage + " in gainshare percentage field of gainshare carrier number 1");
            SendKeys(attributeName_xpath, Gainshare_Carrier_Gainshare_Percentage_Field_1_Xpath, gainsharePercentage);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I have entered ""(.*)"" for the Gainshare Percentage on Carrier-Specific Gainshare Two")]
        public void GivenIHaveEnteredForTheGainsharePercentageOnCarrier_SpecificGainshareTwo(string gainsharePercentage)
        {
            Report.WriteLine("Entering " + gainsharePercentage + " in gainshare percentage field of gainshare carrier number 2");
            SendKeys(attributeName_xpath, Gainshare_Carrier_Gainshare_Percentage_Field_2_Xpath, gainsharePercentage);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I have entered ""(.*)"" for the Gainshare Percentage on Carrier-Specific Gainshare Three")]
        public void GivenIHaveEnteredForTheGainsharePercentageOnCarrier_SpecificGainshareThree(string gainsharePercentage)
        {
            Report.WriteLine("Entering " + gainsharePercentage + " in gainshare percentage field of gainshare carrier number 3");
            SendKeys(attributeName_xpath, Gainshare_Carrier_Gainshare_Percentage_Field_3_Xpath, gainsharePercentage);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [When(@"I click Set Individual Accessorials on Carrier-Specific Gainshare One")]
        public void WhenIClickSetIndividualAccessorialsOnCarrier_SpecificGainshareOne()
        {
            Thread.Sleep(2000);
            Report.WriteLine("Clicking Set Individual Accessorials on Carrier Gainshare Carrier 1");
            Click(attributeName_xpath, Gainshare_Carrier_SetIndividualAccessorials_1_Xpath);
        }

        [Given(@"I click Set Individual Accessorials on Carrier-Specific Gainshare Three")]
        public void GivenIClickSetIndividualAccessorialsOnCarrier_SpecificGainshareThree()
        {
            Thread.Sleep(2000);
            Report.WriteLine("Clicking Set Individual Accessorials on Carrier Gainshare Carrier 3");
            Click(attributeName_xpath, Gainshare_Carrier_SetIndividualAccessorials_3_Xpath);
        }

        [Given(@"I have selected ""(.*)"" on the Set Individual Accessorials Modal")]
        public void GivenIHaveSelectedOnTheSetIndividualAccessorialsModal(string accessorialType)
        {
            Report.WriteLine("Setting individual accessorial type to " + accessorialType);
            Click(attributeName_xpath, Gainshare_Carrier_SetIndividualAccessorials_Modal_AccessorialType_Dropdown);
            SelectDropdownValueFromList(attributeName_xpath, Gainshare_Carrier_SetIndividualAccessorials_Modal_AccessorialType_Dropdown_Values, accessorialType);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I have set the Gainshare Type to ""(.*)"" on the Set Individual Accessorials modal")]
        public void GivenIHaveSetTheGainshareTypeToOnTheSetIndividualAccessorialsModal(string gainshareType)
        {
            Report.WriteLine("Setting gainshare type to " + gainshareType);
            Click(attributeName_xpath, Gainshare_Carrier_SetIndividualAccessorials_Modal_GainshareType_Dropdown);
            SelectDropdownValueFromList(attributeName_xpath, Gainshare_Carrier_SetIndividualAccessorials_Modal_GainshareType_Dropdown_Values, gainshareType);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I have entered valid information for the overlength fields on the Set Individual Accessorials modal")]
        public void GivenIHaveEnteredValidInformationForTheOverlengthFieldsOnTheSetIndividualAccessorialsModal()
        {
            Report.WriteLine("Writing 5 to all Overlength fields");
            SendKeys(attributeName_xpath, Gainshare_Carrier_SetIndividualAccessorials_Modal_Overlength_Value_Over8, "5");
            SendKeys(attributeName_xpath, Gainshare_Carrier_SetIndividualAccessorials_Modal_Overlength_Value_Over9, "5");
            SendKeys(attributeName_xpath, Gainshare_Carrier_SetIndividualAccessorials_Modal_Overlength_Value_Over10, "5");
            SendKeys(attributeName_xpath, Gainshare_Carrier_SetIndividualAccessorials_Modal_Overlength_Value_Over11, "5");
            SendKeys(attributeName_xpath, Gainshare_Carrier_SetIndividualAccessorials_Modal_Overlength_Value_Over12, "5");
            SendKeys(attributeName_xpath, Gainshare_Carrier_SetIndividualAccessorials_Modal_Overlength_Value_Over13, "5");
            SendKeys(attributeName_xpath, Gainshare_Carrier_SetIndividualAccessorials_Modal_Overlength_Value_Over14, "5");
            SendKeys(attributeName_xpath, Gainshare_Carrier_SetIndividualAccessorials_Modal_Overlength_Value_Over15, "5");
            SendKeys(attributeName_xpath, Gainshare_Carrier_SetIndividualAccessorials_Modal_Overlength_Value_Over16, "5");
            SendKeys(attributeName_xpath, Gainshare_Carrier_SetIndividualAccessorials_Modal_Overlength_Value_Over17, "5");
            SendKeys(attributeName_xpath, Gainshare_Carrier_SetIndividualAccessorials_Modal_Overlength_Value_Over18, "5");
            SendKeys(attributeName_xpath, Gainshare_Carrier_SetIndividualAccessorials_Modal_Overlength_Value_Over19, "5");
            SendKeys(attributeName_xpath, Gainshare_Carrier_SetIndividualAccessorials_Modal_Overlength_Value_Over20, "5");
            SendKeys(attributeName_xpath, Gainshare_Carrier_SetIndividualAccessorials_Modal_Overlength_Value_Over21, "5");
            SendKeys(attributeName_xpath, Gainshare_Carrier_SetIndividualAccessorials_Modal_Overlength_Value_Over22, "5");
            SendKeys(attributeName_xpath, Gainshare_Carrier_SetIndividualAccessorials_Modal_Overlength_Value_Over23, "5");
            SendKeys(attributeName_xpath, Gainshare_Carrier_SetIndividualAccessorials_Modal_Overlength_Value_Over24, "5");
            SendKeys(attributeName_xpath, Gainshare_Carrier_SetIndividualAccessorials_Modal_Overlength_Value_Over25, "5");
            SendKeys(attributeName_xpath, Gainshare_Carrier_SetIndividualAccessorials_Modal_Overlength_Value_Over26, "5");
            SendKeys(attributeName_xpath, Gainshare_Carrier_SetIndividualAccessorials_Modal_Overlength_Value_Over27, "5");
            SendKeys(attributeName_xpath, Gainshare_Carrier_SetIndividualAccessorials_Modal_Overlength_Value_Over28, "5");
            SendKeys(attributeName_xpath, Gainshare_Carrier_SetIndividualAccessorials_Modal_Overlength_Value_Over29, "5");
            SendKeys(attributeName_xpath, Gainshare_Carrier_SetIndividualAccessorials_Modal_Overlength_Value_Over30, "5");
        }

        [Given(@"I click save on the Set Individual Accessorials modal")]
        public void GivenIClickSaveOnTheSetIndividualAccessorialsModal()
        {
            Report.WriteLine("Saving individual accessorials");
            Click(attributeName_xpath, Gainshare_Carrier_SetIndividualAccessorials_Modal_Save);
        }

        [Given(@"I click save and continue on the Pricing Model page")]
        public void GivenIClickSaveAndContinueOnThePricingModelPage()
        {
            Thread.Sleep(2000);
            Report.WriteLine("Clicking Save and Continue");
            Click(attributeName_xpath, PricingModel_SaveAndContinuebutton);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [When(@"I click the Back button on the Saved Items and Addresses page")]
        public void WhenIClickTheBackButtonOnTheSavedItemsAndAddressesPage()
        {
            Report.WriteLine("Clicking Back on Saved Items and Addresses Page");
            Click(attributeName_xpath, Saved_Address_Back_Button_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [When(@"I enter valid information on the Individual Accessorials modal for one accessorial")]
        public void WhenIEnterValidInformationOnTheIndividualAccessorialsModalForOneAccessorial()
        {
            Click(attributeName_xpath, Gainshare_Individual_Accessorial_First_Accessorial_Name_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, Gainshare_Carrier_SetIndividualAccessorials_Modal_AccessorialType_Dropdown_Values, "APPOINTMENT");
            Click(attributeName_xpath, Gainshare_Carrier_SetIndividualAccessorials_Modal_GainshareType_Dropdown);
            SelectDropdownValueFromList(attributeName_xpath, Gainshare_Carrier_SetIndividualAccessorials_Modal_GainshareType_Dropdown_Values, "FLAT OVER COST");
        }

        [When(@"I click Set Individual Accessorials")]
        public void WhenIClickSetIndividualAccessorials()
        {
            Report.WriteLine("Clicking Set Individual Accessorials");
            Click(attributeName_xpath, Gainshare_Set_Individual_Accessorials_Xpath);
        }

        [Then(@"the accessorial will be displayed under the correct SCAC code")]
        public void ThenTheAccessorialWillBeDisplayedUnderTheCorrectSCACCode()
        {
            string accessorialTitleValue = Gettext(attributeName_xpath, Gainshare_Third_Added_Carrier_Individual_Accessorials_Xpath);
            Assert.AreEqual("OVERLENGTH: (flat over cost)", accessorialTitleValue);
            Report.WriteLine("Values are shown correctly.");
        }

        [Then(@"I will see the Set Flat Amount field on the modal")]
        public void ThenIWillSeeTheSetFlatAmountFieldOnTheModal()
        {
            Report.WriteLine("Verifying Set Flat Amount field is visible");
            VerifyElementVisible(attributeName_xpath, Gainshare_First_Carrier_Individual_Accessorial_Modal_Value_Xpath, "Set Flat Amount field");
            Report.WriteLine("Set Flat Amount field is visible.");
        }

        [Then(@"the Set Individual Accessorials modal will be visible")]
        public void ThenTheSetIndividualAccessorialsModalWillBeVisible()
        {
            VerifyElementVisible(attributeName_xpath, Gainshare_Individual_Accessorial_Modal_Xpath, "Set Individual Accessorials Modal");
            Report.WriteLine("Modal is visible");
        }
    }
}
