using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Objects;
using Microsoft.IdentityModel.Protocols;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Quote.LTL
{
    [Binding]
    public class QuoteLTL_AllRiskInsReminder_PPPAndStdCustomersSteps:Quotelist
    {
        string Station_Name = "ZZZ - Web Services Test";
        CommonMethodsCrm crm = new CommonMethodsCrm();
        [Given(@"I am a shp\.entry, sales, sales management, operations, or a stationowner user")]
        public void GivenIAmAShp_EntrySalesSalesManagementOperationsOrAStationownerUser()
        {
            string username = ConfigurationManager.AppSettings["username-OperationsCrm"].ToString();
            string password = ConfigurationManager.AppSettings["password-OperationsCrm"].ToString();
            crm.LoginToCRMApplication(username, password);
        }

        [Given(@"The customer in which I am associated does not have a PPP all-risk insurance setting")]
        public void GivenTheCustomerInWhichIAmAssociatedDoesNotHaveAPPPAll_RiskInsuranceSetting()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, QuoteList_Icon_Xpath);
            Report.WriteLine("Clicked on Quote Icon");
            string StdCustomer = DBHelper.GetStandard_Customer(Station_Name);
            Click(attributeName_xpath, QuoteList_CustomerDropdown_Xpath);
            //SelectDropdownValueFromList(attributeName_xpath, QuoteListDropdownXpath, StdCustomer);
            IList<IWebElement> custlistValue = GlobalVariables.webDriver.FindElements(By.XPath(QuoteListDropdownXpath));
            for (int i = 0; i < custlistValue.Count; i++)
            {
                if (custlistValue[i].Text == StdCustomer)
                {
                    custlistValue[i].Click();
                    break;
                }
            }
            Report.WriteLine("Standard Customer is been selected from the dropdown");
        }
        
        [Given(@"I am submitting an LTL quote")]
        public void GivenIAmSubmittingAnLTLQuote()
        {
            Click(attributeName_xpath, QuoteSubmitrateRequest_Button_Xpath);
            Report.WriteLine("Clicked on Submit a Rate Request button");
            Click(attributeName_xpath, GetQuote_LTLTile_Button_Xpath);
            Report.WriteLine("Clicked on LTL Tile button");
        }

        [Given(@"I am on Quote Results \(LTL\) page")]
        public void GivenIAmOnQuoteResultsLTLPage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Verifytext(attributeName_xpath, GetQuote_LTL_Title_Xpath, "Get Quote (LTL)");
            SendKeys(attributeName_xpath, QuoteOriginZip, "60606");
            SendKeys(attributeName_xpath, QuoteDestinationZip, "60606");
            SendKeys(attributeName_xpath, QuoteLTLPage_SavedItem_Xpath, "65");
            SendKeys(attributeName_xpath, QuoteWeight_Xpath, "13");
            Clear(attributeName_id, QuoteLTLPage_Length_Id);
            Clear(attributeName_id, QuoteLTLPage_Width_Id);
            Clear(attributeName_id, QuoteLTLPage_Height_Id);
            Click(attributeName_id, LTL_ViewQuoteResults_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Navigated to Quote results page");
        }

        [Given(@"I am on Get Quote \(LTL\) Page")]
        public void GivenIAmOnGetQuoteLTLPage()
        {
            Verifytext(attributeName_xpath, GetQuote_LTL_Title_Xpath, "Get Quote (LTL)");
            Report.WriteLine("Navigated to Get Quote LTL page");
        }

        [Given(@"I am associated to a customer with a PPP all-risk insurance setting")]
        public void GivenIAmAssociatedToACustomerWithAPPPAll_RiskInsuranceSetting()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, QuoteList_Icon_Xpath);
            Report.WriteLine("Clicked on Quote Icon");
            string PPPCustomer = DBHelper.GetPPP_Customer(Station_Name);
            Click(attributeName_xpath, QuoteList_CustomerDropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, QuoteListDropdownXpath, PPPCustomer);
            Report.WriteLine("PPP Customer is been selected from the dropdown");

        }

        [Given(@"I did not enter an insured value on the Get Quote \(LTL\) page")]
        public void GivenIDidNotEnterAnInsuredValueOnTheGetQuoteLTLPage()
        {
            Clear(attributeName_xpath, GetQuoteInsuredVal_Xpath);
            Report.WriteLine("No insured value is entered on Get Quote LTL page");
        }

        
        [When(@"I enter a value greater than \$(.*) in the (.*) field")]
        public void WhenIEnterAValueGreaterThanInTheField(Decimal p0, string InsuredField)
        {
            VerifyElementPresent(attributeName_xpath, GetQuoteInsuredVal_Xpath, InsuredField);
            SendKeys(attributeName_xpath, GetQuoteInsuredVal_Xpath, "110,000.00");
            Report.WriteLine("Entered insured value greater than $100,000.00 on Get quote page");
        }


        [When(@"I enter value greater than \$(.*) in the (.*) field")]
        public void WhenIEnterValueGreaterThanInTheField(Decimal p0, string InsuredField)
        {
            VerifyElementPresent(attributeName_xpath, QuoteResult_InsuredVal_Xpath, InsuredField);
            SendKeys(attributeName_xpath, QuoteResult_InsuredVal_Xpath, "110,000");
            Report.WriteLine("Entered insured value greater than $100,000.00 on Quote Results page");
            Click(attributeName_xpath, QuoteResultShowInsuredRateButton_Xpath);
        }

        [Then(@"I will receive a message:'(.*)' beneath insured value field of Quote results page")]
        public void ThenIWillReceiveAMessageBeneathInsuredValueFieldOfQuoteResultsPage(string ErrorMessage)
        {
            Verifytext(attributeName_xpath, QuoteResult_InsuredValErrorMessage_Xpath, ErrorMessage.ToUpper());
            Report.WriteLine("Expected error message is displayed on Shipment Results page");          
        }

        [When(@"I enter a value greater than \$(.*)\.(.*) in the (.*)field")]
        public void WhenIEnterAValueGreaterThan_InTheField(Decimal p0, int p1, string InsuredField)
        {
            VerifyElementPresent(attributeName_xpath, GetQuoteInsuredVal_Xpath, InsuredField);
            SendKeys(attributeName_xpath, GetQuoteInsuredVal_Xpath, "16,000.00");
            Report.WriteLine("Entered insured value greater than $15,000.00 on Get quote page");
        }

        [When(@"I enter value greater than \$(.*)\.(.*) in the (.*)field")]
        public void WhenIEnterValueGreaterThan_InTheField(Decimal p0, int p1, string InsuredField)
        {
            VerifyElementPresent(attributeName_xpath, QuoteResult_InsuredVal_Xpath, InsuredField);
            SendKeys(attributeName_xpath, QuoteResult_InsuredVal_Xpath, "16,000.00");
            Report.WriteLine("Entered insured value greater than $15,000.00 on Quote results page");
            Click(attributeName_xpath, QuoteResultShowInsuredRateButton_Xpath);
        }

        [Then(@"I will receive a message: '(.*)'")]
        public void ThenIWillReceiveAMessage(string Error)
        {
            Verifytext(attributeName_xpath, GetQuoteInsuredValError_Xpath, Error.ToUpper());
            Report.WriteLine("Error is displayed");
        }
        
        [Then(@"The error message will read '(.*)'")]
        public void ThenTheErrorMessageWillRead(string ErrorMessage)
        {
            Verifytext(attributeName_xpath, GetQuoteInsuredValErrorMessage_Xpath, ErrorMessage);
            Report.WriteLine("Expected Error message is displayed on Get Quote LTL page");
        }

        [Given(@"I did not enter a value on (.*) field")]
        public void GivenIDidNotEnterAValueOnField(string p0)
        {
            Clear(attributeName_xpath, QuoteResult_InsuredVal_Xpath);
            Report.WriteLine("No value is entered in Insured value field of Quote results page");
        }

        [Given(@"I clicked on (.*)button")]
        public void GivenIClickedOnButton(string CreateShipButton)
        {
            VerifyElementPresent(attributeName_xpath, QuoteResultCreateShipment_Button_Xpath, CreateShipButton);
            Click(attributeName_xpath, QuoteResultCreateShipment_Button_Xpath);
            Report.WriteLine("Clicked on Create Shipment button");
        }

        [Given(@"I entered value greater than \$(.*)\.(.*) in the (.*) field of the Insured Rates modal")]
        public void GivenIEnteredValueGreaterThan_InTheFieldOfTheInsuredRatesModal(Decimal p0, int p1, string InsuredField)
        {
            WaitForElementVisible(attributeName_xpath, InsuredValueModal_Xpath, InsuredField);
            VerifyElementPresent(attributeName_xpath, InsuredValueModal_Xpath, InsuredField);
            SendKeys(attributeName_xpath, InsuredValueModal_Xpath, "110,000.00");
            Report.WriteLine("Entered value greater than $100,000.00 on Insured rates modal");
        }

        [Given(@"I entered value greater than \$(.*)\.(.*) in the (.*) field of the Insured rates modal")]
        public void GivenIEnteredValueGreaterThan_InTheFieldOfTheInsuredratesModal(Decimal p0, int p1, string InsuredField)
        {
            WaitForElementVisible(attributeName_xpath, InsuredValueModal_Xpath, InsuredField);
            VerifyElementPresent(attributeName_xpath, InsuredValueModal_Xpath, InsuredField);
            SendKeys(attributeName_xpath, InsuredValueModal_Xpath, "16,000.00 ");
            Report.WriteLine("Entered value greater than $15,000.00  on Insured rates modal");

        }

        [When(@"I click on (.*)button")]
        public void WhenIClickOnButton(string ShowInsuredButton)
        {
            VerifyElementPresent(attributeName_xpath, QuoteResultsModalShowInsuredButton_Xpath, ShowInsuredButton);
            Click(attributeName_xpath, QuoteResultsModalShowInsuredButton_Xpath);
            Report.WriteLine("Clicked on Show insured rate button");
        }

        [Then(@"I will receive a message:'(.*)' beneath the Insured value field of modal")]
        public void ThenIWillReceiveAMessageBeneathTheInsuredValueFieldOfModal(string ErrorMessage)
        {
            if (ErrorMessage.Contains("The entered shipment value exceeds $100,000. Please contact your DLS representative."))
            {
                Verifytext(attributeName_xpath, "//div[@id='insuredCreateShipmentModal']//p[text()='The entered shipment value exceeds $100,000. Please contact your DLS representative.']", ErrorMessage.ToUpper());
            }
            else
            {
                Verifytext(attributeName_xpath, "//div[@id='insuredCreateShipmentModal']//p[text()='The entered shipment value exceeds $15,000. Please contact your DLS representative.']", ErrorMessage.ToUpper());
            }
            Report.WriteLine("Expected error message is displayed on Insured rates modal");
        }

        [Then(@"I have the option to remove the message")]
        public void ThenIHaveTheOptionToRemoveTheMessage()
        {
            VerifyElementPresent(attributeName_xpath, GetQuoteInsuredValErrorMesssage_Remove_Xpath, "Remove option");
            Report.WriteLine("Error message remove option is present in Get Quote LTL page");
            Click(attributeName_xpath, GetQuoteInsuredValErrorMesssage_Remove_Xpath);
            Report.WriteLine("Error message is removed");
            WaitForElementVisible(attributeName_id, GetQuote_ViewQuoteResult_Button_Id, "View Results");
        }
        
        [Then(@"I am unable to (.*)")]
        public void ThenIAmUnableTo(string p0)
        {
            MoveToElementClick(attributeName_id, GetQuote_ViewQuoteResult_Button_Id);
            Report.WriteLine("Clicked on View Quote Results page");
            VerifyElementNotPresent(attributeName_xpath, QuoteResult_Title_Xpath, "Quote Results (LTL)");
            Report.WriteLine("Unable to view Quote Results");
        }
       
        [Then(@"I have the option to continue without insured rates\.")]
        public void ThenIHaveTheOptionToContinueWithoutInsuredRates_()
        {
            VerifyElementPresent(attributeName_xpath, InsuredValueModalWithoutInsured_Button_Xpath, "WithoutInsuredRateButton");
            Report.WriteLine("Continue without insured rates button is present");
        }

        [When(@"I enter a value less than \$(.*)\.(.*) in the (.*)field")]
        public void WhenIEnterAValueLessThan_InTheField(Decimal p0, int p1, string InsuredField)
        {
            VerifyElementPresent(attributeName_xpath, GetQuoteInsuredVal_Xpath, InsuredField);
            SendKeys(attributeName_xpath, GetQuoteInsuredVal_Xpath, "14,000.00");
            Report.WriteLine("Entered insured value less than $15,000.00 on Get quote page");

        }

        [When(@"I enter a value equal to \$(.*)\.(.*) in (.*)field")]
        public void WhenIEnterAValueEqualTo_InField(Decimal p0, int p1, string InsuredField)
        {
            VerifyElementPresent(attributeName_xpath, GetQuoteInsuredVal_Xpath, InsuredField);
            SendKeys(attributeName_xpath, GetQuoteInsuredVal_Xpath, "15,000.00");
            Report.WriteLine("Entered insured value equal to $15,000.00 on Get quote page");

        }

        [When(@"I enter a value less than \$(.*)\.(.*) on (.*)field")]
        public void WhenIEnterAValueLessThan_OnField(Decimal p0, int p1, string InsuredField)
        {
            VerifyElementPresent(attributeName_xpath, QuoteResult_InsuredVal_Xpath, InsuredField);
            SendKeys(attributeName_xpath, QuoteResult_InsuredVal_Xpath, "14,000.00");
            Report.WriteLine("Entered insured value less than $15,000.00 on Quote results page");
            Click(attributeName_xpath, QuoteResultShowInsuredRateButton_Xpath);
        }

        [When(@"I enter a value equal to \$(.*)\.(.*) on the (.*)field")]
        public void WhenIEnterAValueEqualTo_OnTheField(Decimal p0, int p1, string InsuredField)
        {
            VerifyElementPresent(attributeName_xpath, QuoteResult_InsuredVal_Xpath, InsuredField);
            SendKeys(attributeName_xpath, QuoteResult_InsuredVal_Xpath, "15,000.00");
            Report.WriteLine("Entered insured value equal to $15,000.00 on Quote results page");
            Click(attributeName_xpath, QuoteResultShowInsuredRateButton_Xpath);
        }

        [When(@"I enter value less than \$(.*)\.(.*) in the (.*)field of Insured Rates modal")]
        public void WhenIEnterValueLessThan_InTheFieldOfInsuredRatesModal(Decimal p0, int p1, string InsuredField)
        {
            VerifyElementPresent(attributeName_xpath, QuoteResultCreateShipment_Button_Xpath, "CreateShipButton");
            Click(attributeName_xpath, QuoteResultCreateShipment_Button_Xpath);
            Report.WriteLine("Clicked on Create Shipment button");
            WaitForElementVisible(attributeName_xpath, InsuredValueModal_Xpath, InsuredField);
            VerifyElementPresent(attributeName_xpath, InsuredValueModal_Xpath, InsuredField);
            SendKeys(attributeName_xpath, InsuredValueModal_Xpath, "14,000.00 ");
            Report.WriteLine("Entered value less than $15,000.00 on Insured rates modal");
            Click(attributeName_xpath, QuoteResultsModalShowInsuredButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [When(@"I enter a value equal to \$(.*)\.(.*) in (.*)field of Insured Rates modal")]
        public void WhenIEnterAValueEqualTo_InFieldOfInsuredRatesModal(Decimal p0, int p1, string InsuredField)
        {
            VerifyElementPresent(attributeName_xpath, QuoteResultCreateShipment_Button_Xpath, "CreateShipButton");
            Click(attributeName_xpath, QuoteResultCreateShipment_Button_Xpath);
            Report.WriteLine("Clicked on Create Shipment button");
            WaitForElementVisible(attributeName_xpath, InsuredValueModal_Xpath, InsuredField);
            VerifyElementPresent(attributeName_xpath, InsuredValueModal_Xpath, InsuredField);
            SendKeys(attributeName_xpath, InsuredValueModal_Xpath, "15,000.00 ");
            Report.WriteLine("Entered value equal to $15,000.00 on Insured rates modal");
            Click(attributeName_xpath, QuoteResultsModalShowInsuredButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Then(@"All Risk Ins Reminder message will not be displayed on Insured Rates modal of Quote Results page")]
        public void ThenAllRiskInsReminderMessageWillNotBeDisplayedOnInsuredRatesModalOfQuoteResultsPage()
        {
            VerifyElementNotVisible(attributeName_xpath, InsuredValModal_ErrorMessage_Xpath, "ErrorMessage");
            Report.WriteLine("All Risk Ins Reminder message is not displayed on Insured rates modal of Quote results page");
        }

        [Then(@"All Risk Ins Reminder message will not be displayed on Quote results page")]
        public void ThenAllRiskInsReminderMessageWillNotBeDisplayedOnQuoteResultsPage()
        {
            VerifyElementNotVisible(attributeName_xpath, QuoteResult_InsuredValErrorMessage_Xpath, "ErrorMessage");
            Report.WriteLine("All Risk Ins Reminder message is not displayed on Quote results page");
        }


        [Then(@"All Risk Ins Reminder message will not be displayed on Get Quote \(LTL\) page")]
        public void ThenAllRiskInsReminderMessageWillNotBeDisplayedOnGetQuoteLTLPage()
        {
            VerifyElementNotVisible(attributeName_xpath, GetQuoteInsuredValWarning_Xpath, "ErrorPopup");
            Report.WriteLine("All Risk Ins Reminder message is not displayed on Get Quote LTL page"); 
        }

    }
}
