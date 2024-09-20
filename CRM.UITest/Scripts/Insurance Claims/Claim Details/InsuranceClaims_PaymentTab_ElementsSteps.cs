using System;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.IdentityModel.Protocols;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;

using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using System.Threading;

namespace CRM.UITest.Scripts.Insurance_Claims.Claim_Details
{
    [Binding]
    public class InsuranceClaims_PaymentTab_ElementsSteps : Objects.InsuranceClaim
    {
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
        string expectedText = null;
        string actualText = null;

        [Given(@"I am a sales, sales management, operations, station owner, claims specialist user")]
        public void GivenIAmASalesSalesManagementOperationsStationOwnerClaimsSpecialistUser()
        {
            string username = ConfigurationManager.AppSettings["username-claimspecialistClaim"].ToString();
            string password = ConfigurationManager.AppSettings["password-claimspecialistClaim"].ToString();
            CrmLogin.LoginToCRMApplication(username, password);
        }


        public int claimNumber;

        [Given(@"I clicked on the hyper link of a displayed claim")]
        public void GivenIClickedOnTheHyperLinkOfADisplayedClaim()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, ClaimListGrid_PendingCheckbox_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            claimNumber = DBHelper.GetRecentClaimNumber();

            IList<IWebElement> RowCount = GlobalVariables.webDriver.FindElements(By.XPath("//*[@id='gridInsuranceClaimList']/tbody/tr"));
            for (int i = 1; i < RowCount.Count; i++)
            {
                IWebElement ColumnElement = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='gridInsuranceClaimList']//tr[" + i + "]/td[3]/span[1]/a"));
                string columnValue = ColumnElement.Text;
                if (columnValue == claimNumber.ToString())
                {
                    ColumnElement.Click();
                    break;
                }
            }
        }

        [Given(@"I clicked on the hyper link of a displayed claim to arrive on the Details tab")]
        public void GivenIClickedOnTheHyperLinkOfADisplayedClaimToArriveOnTheDetailsTab()
        {
            GlobalVariables.webDriver.WaitForPageLoad();

            Click(attributeName_xpath, ClaimsList_PendingCheckbox_xpath);
            int claimNumber = DBHelper.GetRecentClaimNumberWithPayment();
            string claimNo = claimNumber.ToString();
            SendKeys(attributeName_xpath, ClaimList_ClaimNumberSearchBox_Xpath, claimNo);
            IWebElement ColumnElement = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='gridInsuranceClaimList']/tbody/tr[1]/td[3]/span[1]/a"));
            ColumnElement.Click();

        }


        [Given(@"I arrive on the Details tab of the selected claim")]
        public void GivenIArriveOnTheDetailsTabOfTheSelectedClaim()
        {
            Verifytext(attributeName_xpath, ClaimDetailsPage_Header_Xpath, "Claim Details");
            Report.WriteLine("Arrived on Details tab of the selected claim");
            //expectedText = "DETAILS";
            //actualText = Gettext(attributeName_xpath, ClaimDetailsTabText_Xpath);
            //Assert.AreEqual(expectedText, actualText);
        }


        [Given(@"I clicked on the Payment tab")]
        public void GivenIClickedOnThePaymentTab()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, CustomerDetails_PaymentTab_Xpath);
        }
        
        [When(@"I click on the Payment tab")]
        public void WhenIClickOnThePaymentTab()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, CustomerDetails_PaymentTab_Xpath);
        }
        
        [When(@"the comment of any displayed payment entry is greater than (.*) characters")]
        public void WhenTheCommentOfAnyDisplayedPaymentEntryIsGreaterThanCharacters(int p0)
        {
            Random rnd = new Random();
            scrollpagedown();
            Click(attributeName_id, AddPaymentButton_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, PaymentTypeDropdown_Xpath);
            Report.WriteLine("Entering data in payment modal");
            SelectDropdownValueFromList(attributeName_xpath, PaymentTypeDropdownValues_Xpath, "Expense");
            SendKeys(attributeName_xpath, PaymentAmountModal_Xpath, "" + rnd.Next(100, 500));
            SendKeys(attributeName_xpath, CheckNumberModal_Xpath, "4354");
            SendKeys(attributeName_xpath, PaymentCommentModal_Xpath, "testing testing test xyz claim details comment");
            Click(attributeName_id, CheckDateModal_Lebel_Id);
            Click(attributeName_xpath, CheckDate_DatePicker_Selectdate_Xpath);
            Click(attributeName_id, PaymentDateModal_Lebel_Id);
            Click(attributeName_xpath, PaymentDate_DatePicker_SelectDate_Xpath);
            Click(attributeName_xpath, AddNewPaymentButtonModal_Xpath);

        }

        [Then(@"I will see a Payment grid with the following  columns : PAYMENT TYPE,PAYMENT DATE,COMMENT,CHECK NUMBER,CHECK DATE,PAYMENT AMOUNT")]
        public void ThenIWillSeeAPaymentGridWithTheFollowingColumnsPAYMENTTYPEPAYMENTDATECOMMENTCHECKNUMBERCHECKDATEPAYMENTAMOUNT()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Verifying the payment grid elements");
            string PaymentType = "PAYMENT TYPE";
            string PaymentDate = "PAYMENT DATE";
            string Comment = "COMMENT";
            string CheckNumber = "CHECK NUMBER";
            string CheckDate = "CHECK DATE";
            string PaymentAmount = "PAYMENT AMOUNT";


            scrollpagedown();
            IsElementPresent(attributeName_xpath, PaymentType_Xpath, "PaymentType");
            IsElementPresent(attributeName_xpath, PaymentDate_Xpath, "Payment Date");
            IsElementPresent(attributeName_xpath, Comment_Xpath, "Comment");
            IsElementPresent(attributeName_xpath, CheckNumber_Xpath, "CheckNumber");
            IsElementPresent(attributeName_xpath, CheckDate_Xpath, "CheckDate");
            IsElementPresent(attributeName_xpath, PaymentAmount_Xpath, "PaymentAmount");
            IsElementPresent(attributeName_xpath, AddPaymentButton_Id, "Add Payment");

            Report.WriteLine("Comparing the grid text");

            string paymentTypeUI = Gettext(attributeName_xpath, PaymentType_Xpath);
            Assert.AreEqual(paymentTypeUI, PaymentType);
            string paymentDateUI = Gettext(attributeName_xpath, PaymentDate_Xpath);
            Assert.AreEqual(paymentDateUI, PaymentDate);
            string commentUI = Gettext(attributeName_xpath, Comment_Xpath);
            Assert.AreEqual(commentUI, Comment);
            string checkNumberUI = Gettext(attributeName_xpath, CheckNumber_Xpath);
            Assert.AreEqual(checkNumberUI, CheckNumber);
            string checkDateUI = Gettext(attributeName_xpath, CheckDate_Xpath);
            Assert.AreEqual(checkDateUI, CheckDate);
            string paymentAmountUI = Gettext(attributeName_xpath, PaymentAmount_Xpath);
            Assert.AreEqual(paymentAmountUI, PaymentAmount);
        }


        [Then(@"Payment Date format should be mm/dd/yyyy")]
        public void ThenPaymentDateFormatShouldBeMmDdYyyy()
        {
            scrollpagedown();
           // string paymentDateValue = GetAttribute(attributeName_xpath, PaymentDateValue_Xpath, "value");
            string paymentDateValue = Gettext(attributeName_xpath, PaymentDateValue_Xpath);
            bool isValid = false;
            try
            {
                DateTime.ParseExact(paymentDateValue, "mm/dd/yyyy", null);
                isValid = true;
            }
            catch (FormatException fe) { }

            Assert.IsTrue(isValid);

            //for (int i =1; i<= 10; i++)
            //{
            //    // string paymentDateValue = GetAttribute(attributeName_xpath, ".//*[@id='PaymentGrid']/tbody/tr[" + i + "]/td[2]", "value");
            //    string paymentDateValue = Gettext(attributeName_xpath, ".//*[@id='PaymentGrid']/tbody/tr[" + i + "]/td[2]");
            //    if (!(paymentDateValue.Equals(null)))
            //    {
            //        DateTime.ParseExact(paymentDateValue, "mm/dd/yyyy", null);
            //        break;
            //    }
            //}


        }
        
        [Then(@"Check Date format should be mm/dd/yyyy")]
        public void ThenCheckDateFormatShouldBeMmDdYyyy()
        {
            string checkDate = Gettext(attributeName_xpath, CheckDateValue_Xpath);
            bool isValid = false;
            try
            {
                DateTime.ParseExact(checkDate, "mm/dd/yyyy", null);
                isValid = true;
            }catch(FormatException fe) {}

            Assert.IsTrue(isValid);
        }
        
        [Then(@"Payment Amount currency format should be \$x,xxx\.xx")]
        public void ThenPaymentAmountCurrencyFormatShouldBeXXxx_Xx()
        {
            string currency = Gettext(attributeName_xpath, PaymentAmountValue_Xpath);
            Boolean validCurrencyFormat = System.Text.RegularExpressions.Regex.IsMatch(currency, @"^\$([\d]{1, 2},)?([\d]+)\.([\d]{2,2})$");
            
        }
        
        [Then(@"I will see a field on the tab (.*)")]
        public void ThenIWillSeeAFieldOnTheTab(string p0)
        {
            IsElementPresent(attributeName_id, OutstandingAmount_Id, "OutstandingAmount");
        }

        [Then(@"I will see three dots(.*)")]
        public void ThenIWillSeeThreeDots(string p0)
        {
            Report.WriteLine("Verifying three dots");
            IList<IWebElement> paymentTableRow = GlobalVariables.webDriver.FindElements(By.XPath(PaymentTableRow_Xpath));
            int i = paymentTableRow.Count;
            string Comment = GetAttribute(attributeName_xpath, ".//*[@id='PaymentGrid']/tbody/tr["+i+"]/td[3]", "class");
            Assert.AreEqual(Comment, "GridCommentColumn all commentToolTip");
        }


        [Then(@"mouse over will show the details")]
        public void ThenMouseOverWillShowTheDetails()
        {
            OnMouseOver(attributeName_xpath, FirstCommentValue_Xpath);

            Report.WriteLine("Verifying tool tip text");
            string actualToolTipText = GetAttribute(attributeName_xpath, FirstCommentValue_Xpath, "data-original-title");
            string expectedToolTipText = Gettext(attributeName_xpath, FirstCommentValue_Xpath);
            Assert.AreEqual(actualToolTipText, expectedToolTipText);
        }


        [Then(@"I will see an (.*) button")]
        public void ThenIWillSeeAnButton(string p0)
        {
            IsElementPresent(attributeName_id, AddPaymentButton_Id, "Add Payment");
        }
    }
}
