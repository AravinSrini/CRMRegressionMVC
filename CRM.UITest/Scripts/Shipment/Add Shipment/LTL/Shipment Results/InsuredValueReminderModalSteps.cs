using CRM.UITest.CommonMethods;
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

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Results
{
    [Binding]
    public class InsuredValueReminderModalSteps : AddShipments
    {
        CommonMethodsCrm crm = new CommonMethodsCrm();

        [Given(@"I am a shp\.entry user (.*) (.*)")]
        public void GivenIAmAShp_EntryUser(string Username, string Password)
        {
            crm.LoginToCRMApplication(Username, Password);
        }

        [When(@"I click on create shipment button for any of the listed carrier (.*)")]
        public void WhenIClickOnCreateShipmentButtonForAnyOfTheListedCarrier(string Usertype)
        {
            Report.WriteLine("Create shipment for selected carrier");
            IList<IWebElement> row = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='ShipmentResultTable']/tbody/tr"));
            string rowValue = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[1]/td[1]/div/div");
            if (row.Count >= 1 && rowValue != "There are no rates available for this shipment.")
            {
                    if (Usertype.Equals("Internal"))
                    {
                        Click(attributeName_xpath, ShipResults_Internal_CreateShipButton_xpath);
                        Thread.Sleep(500);
                    }
                    else
                    {
                        Click(attributeName_xpath, ShipResults_External_CreateShipButton_xpath);
                    Thread.Sleep(500);
                    }

                    bool InsuredRate_PopUp = IsElementVisible(attributeName_xpath, InsuredValueModalHeaderTest_xpath, "Insured Rate PopUp");
                    if (InsuredRate_PopUp)
                    {

                       Report.WriteLine("Insured Value Reminder modal pop up is displayed when Insured value is not entered");

                     }
                     else
                     {
                      Assert.Fail("Insured Value Reminder modal pop up is not displayed when Insured value is not entered");
                     }

            }else
            {
                Report.WriteLine("No Rates avialable on the Shipment Results page");
            }

        }


        [Then(@"Verify the insured value reminder modal pop up is displayed")]
        public void ThenVerifyTheInsuredValueReminderModalPopUpIsDisplayed()
        {
            VerifyElementPresent(attributeName_xpath, InsuredValueModalHeaderTest_xpath, "Insured Rates");
        }

        [Then(@"the modal will display the message as (.*)")]
        public void ThenTheModalWillDisplayTheMessageAs(string InsuredRatesMessage)
        {
            Verifytext(attributeName_xpath, InsuredValueModalTextMessage_xpath, InsuredRatesMessage);
        }

        [Then(@"there will be an Insured value field with Currency formatted")]
        public void ThenThereWillBeAnInsuredValueFieldWithCurrencyFormatted()
        {
            Click(attributeName_xpath, InsuredValueModal_insuredvalueTextbox_xpath);
            Click(attributeName_xpath, InsuredValueModalTextMessage_xpath);
            string textFormat = GetAttribute(attributeName_xpath, InsuredValueModal_insuredvalueTextbox_xpath, "value");
            Assert.AreEqual(textFormat, "$");
        }


        [Then(@"there will be insured type selection field defaulted to New")]
        public void ThenThereWillBeInsuredTypeSelectionFieldDefaultedToNew()
        {
            string ActualInsuredTypeSelection = Gettext(attributeName_xpath, InsuredValueModal_DefualtInsuredTypeSelection_xpath);
            string ExpectedInsuredTypeSelection = "New";
            Assert.AreEqual(ActualInsuredTypeSelection, ExpectedInsuredTypeSelection);
        }

        [Then(@"there will be Show Insured Rate button")]
        public void ThenThereWillBeShowInsuredRateButton()
        {
            Verifytext(attributeName_id, InsuredValueModal_ShowInsuredRateButton_id, "Show Insured Rate");
        }

        [Then(@"there will be Continue without insured rate button")]
        public void ThenThereWillBeContinueWithoutInsuredRateButton()
        {
            Verifytext(attributeName_id, InsuredValueModal_ContinueWithoutRateButton_id, "Continue without Insured rates");
        }

        [Then(@"there will be a check box Don't Show Me This Again")]
        public void ThenThereWillBeACheckBoxDonTShowMeThisAgain()
        {
            Verifytext(attributeName_xpath, InusredValueModal_DontShowMeThisAgain_xpath, "Don't Show Me This Again");
        }

        [Then(@"insured Type selection field should be defaulted to Used")]
        public void ThenInsuredTypeSelectionFieldShouldBeDefaultedToUsed()
        {
            string ActualInsuredTypeSelection = Gettext(attributeName_xpath, InsuredValueModal_DefualtInsuredTypeSelection_xpath);
            string ExpectedInsuredTypeSelection = "Used";
            Assert.AreEqual(ActualInsuredTypeSelection, ExpectedInsuredTypeSelection);
        }

        [Then(@"I have option to select New")]
        public void ThenIHaveOptionToSelectNew()
        {
            Click(attributeName_xpath, InsuredValueModal_DefualtInsuredTypeSelection_xpath);
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(InsuredValueModal_InsuredTypeSelectionOptions_xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == "New")
                {
                    DropDownList[i].Click();
                    break;
                }
            }
            Thread.Sleep(500);
        }


        [When(@"I enter the Insured Value")]
        public void WhenIEnterTheInsuredValue()
        {
            SendKeys(attributeName_xpath, InsuredValueModal_insuredvalueTextbox_xpath, "1000");
        }

        [When(@"I click on the Show Insured Rate button")]
        public void WhenIClickOnTheShowInsuredRateButton()
        {
            Click(attributeName_id, InsuredValueModal_ShowInsuredRateButton_id);
        }

        [Then(@"I am returned back to the Shipment Results LTL page")]
        public void ThenIAmReturnedBackToTheShipmentResultsLTLPage()
        {
            VerifyElementPresent(attributeName_xpath, ShipResults_PageHeaderText_xpath, "Shipment Results Page");
        }


        [Then(@"I should be displayed the Insured Rate column with Create an Insured Shipment Button")]
        public void ThenIShouldBeDisplayedTheInsuredRateColumnWithCreateAnInsuredShipmentButton()
        {
            VerifyElementPresent(attributeName_xpath, InsuredRateColumn_xpath, "Insured Rate Column");
        }


        [When(@"I click on the Continue Without Insured Rates Button")]
        public void WhenIClickOnTheContinueWithoutInsuredRatesButton()
        {
            Thread.Sleep(5000);
            Click(attributeName_id, InsuredValueModal_ContinueWithoutRateButton_id);
        }

        

        [Then(@"I am taken to the Review and Submit page")]
        public void ThenIAmTakenToTheReviewAndSubmitPage()
        {
            VerifyElementPresent(attributeName_xpath, ReviewAndSubmit_Title_Xpath, "Review and Submit Page");
        }

        [When(@"I click on the Don't Show Me This Again check box")]
        public void WhenIClickOnTheDonTShowMeThisAgainCheckBox()
        {
            Click(attributeName_xpath, InusredValueModal_DontShowMeThisAgain_xpath);
        }

        [Then(@"Insured value reminder modal pop up should not be displayed")]
        public void ThenInsuredValueReminderModalPopUpShouldNotBeDisplayed()
        {
            VerifyElementNotPresent(attributeName_xpath, InsuredValueModalHeaderTest_xpath, "Insured Rates");
        }

        [When(@"I Click on Create Shipment button (.*)")]
        public void WhenIClickOnCreateShipmentButton(string Usertype)
        {
            Report.WriteLine("Create shipment for selected carrier");
            IList<IWebElement> row = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='ShipmentResultTable']/tbody/tr"));
            string rowValue = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[1]/td[1]/div/div");
            if (row.Count >= 1 && rowValue != "There are no rates available for this shipment.")
            {
                if (Usertype.Equals("Internal"))
                {
                    Click(attributeName_xpath, ShipResults_Internal_CreateShipButton_xpath);
                    Thread.Sleep(500);
                }
                else
                {
                    Click(attributeName_xpath, ShipResults_External_CreateShipButton_xpath);
                    Thread.Sleep(500);
                }

                bool InsuredRate_PopUp = IsElementPresent(attributeName_xpath, InsuredValueModalHeaderTest_xpath, "Insured Rate PopUp");
                if (InsuredRate_PopUp)
                {

                    Assert.Fail("Insured Value Reminder modal pop up is displayed even after Clicked on the Dont Show Me This Again checkbox");

                }
                else
                {
                    Report.WriteLine("Insured Value Reminder modal pop up is not displayed after Clicked on the Dont Show Me This Again checkbox");
                }

            }
            else
            {
                Report.WriteLine("No Rates avialable on the Shipment Results page");
            }
        }





















    }
}
