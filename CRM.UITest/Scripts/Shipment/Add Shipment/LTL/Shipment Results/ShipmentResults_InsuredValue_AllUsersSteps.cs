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
    public class ShipmentResults_InsuredValue_AllUsersSteps : AddShipments
    {
        [Given(@"I am a shpentry, operations, sales, sales management or station user (.*),(.*)")]
        public void GivenIAmAShpentryOperationsSalesSalesManagementOrStationUser(string Username, string Password)
        {
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(Username, Password);

        }

        [Given(@"I enter the (.*),(.*) on add shipment LTL page")]
        public void GivenIEnterTheOnAddShipmentLTLPage(string insuredValue, string insuredtype)
        {
            Report.WriteLine("I enter the Insured value and Insured type");
            SendKeys(attributeName_id, InsuredValue_TextBox_Id, insuredValue);

            Report.WriteLine("Select the insured value type ");
            Click(attributeName_xpath, InsuredValue_Type_xpath);
            IList<IWebElement> DropDownListClass = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='instype_chosen']/div/ul/li"));
            int DropDownClassCount = DropDownListClass.Count;
            for (int i = 0; i < DropDownClassCount; i++)
            {
                if (DropDownListClass[i].Text == insuredtype)
                {
                    DropDownListClass[i].Click();
                    break;
                }
            }
        }

        [Then(@"Verify the value is auto populated value for (.*) and (.*)")]
        public void ThenVerifyTheValueIsAutoPopulatedValueForAnd(string insuredValue, string insuredtype)
        {
            Report.WriteLine("Value us autopopulated in insured value and insured type");
            string INsuredAutoActual = GetValue(attributeName_xpath, ".//*[@id='shipValueNumber']", "value");
            string[] ActualINs = INsuredAutoActual.Split('$');
            string ActualInsuredValue = ActualINs[1];
          
            Assert.AreEqual(insuredValue, ActualInsuredValue);

            string InsuredTypeActual = Gettext(attributeName_xpath, ".//*[@id='shipValueType_chosen']/a/span");
            Assert.AreEqual(insuredtype, InsuredTypeActual);
        }

        [Then(@"Verify both field are editable")]
        public void ThenVerifyBothFieldAreEditable()
        {
            Clear(attributeName_id, ShipResults_InsuredRateTextbox_Id);
            SendKeys(attributeName_id, ShipResults_InsuredRateTextbox_Id, "123456");

            Click(attributeName_xpath, ".//*[@id='shipValueType_chosen']/a");
            IList <IWebElement> DropDownListClass = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='shipValueType_chosen']/div/ul/li"));
            int DropDownClassCount = DropDownListClass.Count;
            for (int i = 0; i < DropDownClassCount; i++)
            {
                if (DropDownListClass[i].Text == "Used")
                {
                    DropDownListClass[i].Click();
                    break;
                }
            }

        }
        [Then(@"Verify the View Terms and Conditions button is active")]
        public void ThenVerifyTheViewTermsAndConditionsButtonIsActive()
        {
            VerifyElementPresent(attributeName_xpath, Shipresults_TermsandCondition_Xpath, "Terms and Condition");

        }
        [Then(@"Verify i have option to enter the insured value for (.*)")]
        public void ThenVerifyIHaveOptionToEnterTheInsuredValueFor(string insured_value)
        {
            Report.WriteLine("Enter the value in Insured Value field");
            SendKeys(attributeName_id, ShipResults_InsuredRateTextbox_Id, insured_value);
        }

        [Then(@"Insured value field allows (.*) and (.*)")]
        public void ThenInsuredValueFieldAllowsAnd(string numerical_digit, string decimal_digit)
        {
            Clear(attributeName_id, ShipResults_InsuredRateTextbox_Id);
            Report.WriteLine("Enter the numerical digit");
            SendKeys(attributeName_id, ShipResults_InsuredRateTextbox_Id, numerical_digit);

            string InsuredNumericvalue = GetValue(attributeName_id, ShipResults_InsuredRateTextbox_Id,"value");
            string[] InsureValue1 = InsuredNumericvalue.Split('$');
            string ActualInsuredValue = InsureValue1[1];

            Assert.AreEqual(numerical_digit, ActualInsuredValue);

            Clear(attributeName_id, ShipResults_InsuredRateTextbox_Id);
            Report.WriteLine("Enter the decimal value");
            SendKeys(attributeName_id, ShipResults_InsuredRateTextbox_Id, decimal_digit);
           
            string ActualInsuredValueDec = GetValue(attributeName_id, ShipResults_InsuredRateTextbox_Id,"value");
            string[] ActualIns = ActualInsuredValueDec.Split('$');
            string ActualInsValue = ActualIns[1];

            Assert.AreEqual(decimal_digit, ActualInsValue);

        }

        [Then(@"Verify the dropdown have the (.*)")]
        public void ThenVerifyTheDropdownHaveThe(string isuredvaluetype)
        {
            Report.WriteLine("Click on Insured Value Type dropdown");
            Click(attributeName_xpath, ShipResults_InsuredValueType_Dropdown_Xpath);
            if (isuredvaluetype == "New")
            {
                Report.WriteLine("Verify the Dropdown  New option value type");
                String ActualNewOption = Gettext(attributeName_xpath, ".//*[@id='shipValueType_chosen']/div/ul/li[1]");
                Assert.AreEqual(isuredvaluetype, ActualNewOption);
            }
            else if (isuredvaluetype == "Used")
            {
                Report.WriteLine("Verify the Dropdown have Used option value type");
                String ActualNewOption = Gettext(attributeName_xpath, ".//*[@id='shipValueType_chosen']/div/ul/li[2]");
                Assert.AreEqual(isuredvaluetype, ActualNewOption);
            }


        }
        [When(@"I arrive on shipment Results LTL page and entered (.*)")]
        public void WhenIArriveOnShipmentResultsLTLPageAndEntered(string insured_value)
        {
            Report.WriteLine("I arrive on shipment result page");
            VerifyElementPresent(attributeName_xpath, ShipResults_PageHeaderText_Relativexpath, "Shipment Results (LTL)");
            SendKeys(attributeName_id, ShipResults_INsuredValue_Id, insured_value);


        }
        [Then(@"Verify the Insured value type defaulted to used")]
        public void ThenVerifyTheInsuredValueTypeDefaultedToUsed()
        {
            string ExpectedInsuredTypeDropDownAutoLogin = "Used";
            Report.WriteLine("Verify that insured value type is bydefault selected as Used");
            string InsuredVlaueTypedefault = Gettext(attributeName_xpath, ".//*[@id='shipValueType_chosen']/a/span");
            Assert.AreEqual(ExpectedInsuredTypeDropDownAutoLogin, InsuredVlaueTypedefault);
        }

        [Then(@"I have the option to change the insured value type to New")]
        public void ThenIHaveTheOptionToChangeTheInsuredValueTypeToNew()
        {
            string ExpectedchangeValuetoNew = "New";
            Report.WriteLine("I have option to change Used to New");
            Click(attributeName_xpath, ShipResults_InsuredValueType_Dropdown_Xpath);

            Click(attributeName_xpath, ShipResults_InsuredType_New_Xpath);
            string ActualChangedValue = Gettext(attributeName_xpath, ".//*[@id='shipValueType_chosen']/a/span");
            Assert.AreEqual(ExpectedchangeValuetoNew, ActualChangedValue);
        }


        [Then(@"I should see the View (.*) button")]
        public void ThenIShouldSeeTheViewButton(string terms_and_condition)
        {
            
            String TermsCondition = Gettext(attributeName_xpath, Shipresults_TermsandCondition_Xpath);
            Assert.AreEqual(terms_and_condition, TermsCondition);
        }



        [When(@"Click on Terms and conditon on Shipment result page")]
        public void WhenClickOnTermsAndConditonOnShipmentResultPage()
        {
           
            Report.WriteLine("Click on Terms and condition button");
            Click(attributeName_xpath, Shipresults_TermsandCondition_Xpath);
            Thread.Sleep(3000);


        }

        [Then(@"Verify the presented model with the (.*)")]
        public void ThenVerifyThePresentedModelWithThe(string shipmentModelheading)
        {
            Report.WriteLine("Shipment Model heading ");
            string ModelHeadingActual = Gettext(attributeName_xpath, ShipResults_Shipmodel_Heading_Xpath);
            Assert.AreEqual(shipmentModelheading, ModelHeadingActual);
        }

        [When(@"I click on Download DLSW Claim form in model from Shipment result page")]
        public void WhenIClickOnDownloadDLSWClaimFormInModelFromShipmentResultPage()
        {
            scrollElementIntoView(attributeName_xpath, ShipResults_Model_DLSWForm_Xpath);
            Click(attributeName_xpath, ShipResults_Model_DLSWForm_Xpath);
            Thread.Sleep(3000);
        }
        [Then(@"Verify that DLSW claim form will be downloaded")]
        public void ThenVerifyThatDLSWClaimFormWillBeDownloaded()
        {
            Report.WriteLine("Verified the DLSW claim form will be downloaded");
            string downlaodfile = "DownloadDlswwClaimsForm.docx";
            string downloadpath = GetDownloadedFilePath("DownloadDlswwClaimsForm.docx");
            bool Expected = downloadpath.Contains(downlaodfile);
            if (Expected == true)
            {
                Report.WriteLine("DLSWW form has downloaded");
            }
            else
            {
                Report.WriteLine("DLSWW form is not downloaded");
            }
        }
        [When(@"Click on close button from model in shipment result page")]
        public void WhenClickOnCloseButtonFromModelInShipmentResultPage()
        {
            Report.WriteLine("click on close button");
            Click(attributeName_xpath, ShipResults_Model_Close_Button_Xpath);
            Thread.Sleep(3000);

        }

        [Then(@"Verify i should be navigated to the Shipment Results LTL page")]
        public void ThenVerifyIShouldBeNavigatedToTheShipmentResultsLTLPage()
        {
            Report.WriteLine("Verify i am navigated to the Shipment Result LTL page");
            VerifyElementPresent(attributeName_xpath, ShipResults_PageHeaderText_xpath, "Shipment Results (LTL)");
        }

        [When(@"I Select the (.*) from dropdown in shipment result page")]
        public void WhenISelectTheFromDropdownInShipmentResultPage(string insuredValue_type)
        {
            Click(attributeName_xpath, ".//*[@id='shipValueType_chosen']/a");
            IList<IWebElement> DropDownListClass = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='shipValueType_chosen']/div/ul/li"));
            int DropDownClassCount = DropDownListClass.Count;
            for (int i = 0; i < DropDownClassCount; i++)
            {
                if (DropDownListClass[i].Text == insuredValue_type)
                {
                    DropDownListClass[i].Click();
                    break;
                }
            }
        }

        [When(@"I click on Show Insured Rate button in shipment result page")]
        public void WhenIClickOnShowInsuredRateButtonInShipmentResultPage()
        {
            Click(attributeName_id, ShipResults_ShowInsuredRateButton_Id);
        }

        [Then(@"Verify that results grid will update to display the Insured Rate column (.*)")]
        public void ThenVerifyThatResultsGridWillUpdateToDisplayTheInsuredRateColumn(string Usertype)
        {
            if (Usertype == "Internal")
            {
                VerifyElementPresent(attributeName_xpath, ShipResults_Internal_Rate_Column_Xpath, "Insured Rate");
            }
            else if (Usertype == "External")
            {
                VerifyElementPresent(attributeName_xpath, ShipResults_External_Rate_Column_Xpath, "Rate");
            }
        }

        [Then(@"Verify each carrier displayed on the results page will have an option to Create an Insured Shipment (.*)")]
        public void ThenVerifyEachCarrierDisplayedOnTheResultsPageWillHaveAnOptionToCreateAnInsuredShipment(string Usertype)
        {
            IList<IWebElement> row = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='ShipmentResultTable']/tbody/tr"));
            string rowValue = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[1]/td[1]/div/div");
            for (int i = 1; i<=row.Count; i++)
            {
                if (row.Count >= 1 && rowValue != "There are no rates available for this shipment.")
                {
                    if (Usertype.Equals("Internal"))
                    {
                        VerifyElementPresent(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + i + "]/td[6]/div[5]/button[@id='btncreateinsuredshipment']", "create insured shipment button");

                    }
                    else if (Usertype.Equals("External"))
                    {
                        VerifyElementPresent(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + i + "]/td[5]/div[5]/button[@id='btncreateinsuredshipment']", "create insured shipment button");

                    }

                }
                else
                {
                    Report.WriteLine("No Rates avialable on the Shipment Results page");
                }
            }

        }

    }


}