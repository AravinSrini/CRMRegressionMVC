using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Insurance_Claims.Claim_Details
{
    [Binding]
    public class InsuranceClaims_PaymentTab_AddPaymentFunctionalitySteps : CRM.UITest.Objects.InsuranceClaim
    {
        string GetClaimNum = null;
        int GetPaymentTypeCount = 0;
        [Given(@"I clicked on the hyperlink of a displayed claim")]
        public void GivenIClickedOnTheHyperlinkOfADisplayedClaim()
        {
            Click(attributeName_xpath, ClaimListGrid_PendingCheckbox_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            GetClaimNum = Gettext(attributeName_xpath, ClaimListDLSWREF_HyperLink_Xpath);
            Click(attributeName_xpath, ClaimListDLSWREF_HyperLink_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Navigated to claim details page");
        }

        [Given(@"Clicked on the Payments Tab")]
        public void GivenClickedOnThePaymentsTab()
        {
            Click(attributeName_xpath, CustomerDetails_PaymentTab_Xpath);
            Report.WriteLine("Clicked on Payment tab");
        }

        [When(@"I click on Add Payment button")]
        public void WhenIClickOnAddPaymentButton()
        {
            scrollpagedown();
            Click(attributeName_id, AddPaymentButton_Id);
            Report.WriteLine("Clicked on Add Payment button");
        }


        [Given(@"I clicked on the Add Payment button")]
        public void GivenIClickedOnTheAddPaymentButton()
        {
            Click(attributeName_id, AddPaymentButton_Id);
            Report.WriteLine("Clicked on Add Payment button");
        }
        
        [Given(@"The Add Payment modal opened")]
        public void GivenTheAddPaymentModalOpened()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Verifytext(attributeName_xpath, PaymentModalTitle_Xpath, "Add Payment");
            Report.WriteLine("Add Payment modal is opened");
        }
        
        [Given(@"Arrived on the Payments Tab")]
        public void GivenArrivedOnThePaymentsTab()
        {
            VerifyElementPresent(attributeName_xpath, AddPaymentButton_Id, "Payment Tab section");
            Report.WriteLine("Arrived on Payment Tab");
        }

        [Given(@"Arrived on Payments Tab")]
        public void GivenArrivedOnPaymentsTab()
        {
            VerifyElementPresent(attributeName_xpath, AddPaymentButton_Id, "Payment Tab section");
            IList<IWebElement> PaymentTypesListUI = GlobalVariables.webDriver.FindElements(By.XPath(PaymentTypeList_Xpath));
            GetPaymentTypeCount = PaymentTypesListUI.Count;
            Report.WriteLine("Arrived on Payment Tab");
        }


        [Given(@"I entered all required information")]
        public void GivenIEnteredAllRequiredInformation()
        {
            Click(attributeName_xpath, PaymentTypeDropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, PaymentTypeDropdownValues_Xpath, "Expense");
            SendKeys(attributeName_xpath, PaymentAmountModal_Xpath, "456");
            SendKeys(attributeName_xpath, CheckNumberModal_Xpath, "4354");
            SendKeys(attributeName_xpath, PaymentCommentModal_Xpath, "fks uufdyus 7883");
        }
        
        [Given(@"I did not enter all required information")]
        public void GivenIDidNotEnterAllRequiredInformation()
        {
            Click(attributeName_xpath, PaymentTypeDropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, PaymentTypeDropdownValues_Xpath, "Expense");
            SendKeys(attributeName_xpath, PaymentAmountModal_Xpath, "456");
        }
        
        [When(@"I click in the  Payment Type field")]
        public void WhenIClickInThePaymentTypeField()
        {
            Click(attributeName_xpath, PaymentTypeDropdown_Xpath);
            Report.WriteLine("Clicked on Payment Type field");
        }

        [When(@"I select (.*)")]
        public void WhenISelect(string PaymentType)
        {
            Click(attributeName_xpath, PaymentTypeDropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, PaymentTypeDropdown_Label_Xpath, PaymentType);
            Report.WriteLine("Payment Type is selected");
        }


        [When(@"I click on Save button")]
        public void WhenIClickOnSaveButton()
        {
            Click(attributeName_xpath, AddNewPaymentButtonModal_Xpath);
            Report.WriteLine("Clicked on Save button");
        }

        [Then(@"I will receive message (.*)")]
        public void ThenIWillReceiveMessage(string ErrorMessage)
        {
            Verifytext(attributeName_xpath, PayemntModalErrorMessage, ErrorMessage);
            Report.WriteLine("Error message is displayed");
        }


        [Then(@"The Add Payment modal will open")]
        public void ThenTheAddPaymentModalWillOpen()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Verifytext(attributeName_xpath, PaymentModalTitle_Xpath, "Add Payment");
            Report.WriteLine("Add Payment modal is opened");
        }
        
        [Then(@"I will be able to see Payment Type")]
        public void ThenIWillBeAbleToSeePaymentType()
        {
            VerifyElementVisible(attributeName_xpath, PaymentTypeDropdown_Xpath, "PaymentType");
           Verifytext(attributeName_xpath, PaymentTypeDropdown_Label_Xpath, "Payment Type");
            Report.WriteLine("Able to view Payment Type");
        }
        
        [Then(@"I will be able to see Payment Amount")]
        public void ThenIWillBeAbleToSeePaymentAmount()
        {
            VerifyElementVisible(attributeName_xpath, PaymentAmountModal_Xpath, "Payment Amount");
            Verifytext(attributeName_xpath, PaymentAmountModal_Label_Xpath, "Payment Amount");
            Report.WriteLine("Able to view Payment Amount");
        }
        
        [Then(@"I will be able to see Payment Date")]
        public void ThenIWillBeAbleToSeePaymentDate()
        {
            VerifyElementVisible(attributeName_xpath, PaymentDateModal_Xpath, "Payment Date");
            Verifytext(attributeName_xpath, PaymentDateModal_Label_Xpath, "Payment Date");
            Report.WriteLine("Able to view Payment Date");
        }
        
        [Then(@"I will be able to see Check Number")]
        public void ThenIWillBeAbleToSeeCheckNumber()
        {
            VerifyElementVisible(attributeName_xpath, CheckNumberModal_Xpath, "Check Number");
            Verifytext(attributeName_xpath, CheckNumModal_Label_Xpath, "Check Number");
            Report.WriteLine("Able to view Check Number");
        }
        
        [Then(@"I will be able to see Check Date")]
        public void ThenIWillBeAbleToSeeCheckDate()
        {
            VerifyElementVisible(attributeName_xpath, CheckDateModal_Xpath, "Check Date");
            Verifytext(attributeName_xpath, CheckDateModal_Label_Xpath, "Check Date");
            Report.WriteLine("Able to view Check Date");
        }
        
        [Then(@"I will be able to see Comments")]
        public void ThenIWillBeAbleToSeeComments()
        {
            VerifyElementVisible(attributeName_xpath, PaymentCommentModal_Xpath, "Payment Comment");
            Verifytext(attributeName_xpath, PaymentCommentModal_Label_Xpath, "Comments");
            Report.WriteLine("Able to view Payment Comment");
        }

        [Then(@"I will be able to see '(.*)' button")]
        public void ThenIWillBeAbleToSeeButton(string AddModalButton)
        {
            if(AddModalButton == "Cancel")
            {
                VerifyElementVisible(attributeName_xpath, PaymentModalCancelButton_Xpath, "Cancel button");
                Verifytext(attributeName_xpath, PaymentModalCancelButton_Xpath, "Cancel");
            }

            if(AddModalButton == "Add")
            {
                VerifyElementVisible(attributeName_xpath, AddNewPaymentButtonModal_Xpath, "Add button");
                Verifytext(attributeName_xpath, AddNewPaymentButtonModal_Xpath, "Add");
            }
        }

        [Then(@"The following will be required fields : Payment Type, Payment Amount, Payment Date, Check Number, Check Date, Comments")]
        public void ThenTheFollowingWillBeRequiredFieldsPaymentTypePaymentAmountPaymentDateCheckNumberCheckDateComments()
        {
            Click(attributeName_xpath, AddNewPaymentButtonModal_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
           // Verifytext(attributeName_xpath, PaymentModalTitle_Xpath, "Add Paymemt");
            string actualText = Gettext(attributeName_xpath, PaymentModalTitle_Xpath);
            string expectedText = "Add Payment";
            Assert.AreEqual(actualText, expectedText);
            string GetPaymentTypeCSS = GetCSSValue(attributeName_xpath, PaymentTypeDropdown_Xpath, "background-color");
           // Assert.AreEqual("rgba(251, 236, 237, 1)", GetPaymentTypeCSS);
            string GetPaymentAmountCSS = GetCSSValue(attributeName_xpath, PaymentAmountModal_Xpath, "background-color");
            Assert.AreEqual("rgba(251, 236, 237, 1)", GetPaymentAmountCSS);
            string GetPaymentDateCSS = GetCSSValue(attributeName_xpath, PaymentDateModal_Xpath, "background-color");
           // Assert.AreEqual("rgba(251, 236, 237, 1)", GetPaymentDateCSS);
            string GetCheckNumberCSS = GetCSSValue(attributeName_xpath, CheckNumberModal_Xpath, "background-color");
            Assert.AreEqual("rgba(251, 236, 237, 1)", GetCheckNumberCSS);
            string GetCheckDateCSS = GetCSSValue(attributeName_xpath, CheckDateModal_Xpath, "background-color");
           // Assert.AreEqual("rgba(251, 236, 237, 1)", GetCheckDateCSS);
            string GetPaymentCommentCSS = GetCSSValue(attributeName_xpath, PaymentCommentModal_Xpath, "background-color");
            Assert.AreEqual("rgba(251, 236, 237, 1)", GetPaymentCommentCSS);
            Report.WriteLine("Payment Type, Payment Amount, Payment Date, Check Number, Check Date, Comments are required fields");

        }

        [Then(@"The PaymentType will be a selectable dropdown list")]
        public void ThenThePaymentTypeWillBeASelectableDropdownList()
        {
            Click(attributeName_xpath, PaymentTypeDropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, PaymentTypeDropdownValues_Xpath, "Carrier Direct Pay To Claimant");
            Report.WriteLine("Payment type is a selectable dropdown list");
        }
        
        [Then(@"The Payment Amount field format will be currency")]
        public void ThenThePaymentAmountFieldFormatWillBeCurrency()
        {
            SendKeys(attributeName_xpath, PaymentAmountModal_Xpath, "34");
            Click(attributeName_xpath, PaymentAmountModal_Label_Xpath);
            string GetPaymentAmount = GetAttribute(attributeName_id, PaymentAmountModal_Id,"value");
            if(GetPaymentAmount.Contains("$"))
            {
                Report.WriteLine("Payment Amount field format is currency");
            }
            else
            {
                Assert.Fail();
            }
        }
        
        [Then(@"The Payment Amount field will allow upto two decimal places")]
        public void ThenThePaymentAmountFieldWillAllowUptoTwoDecimalPlaces()
        {
            SendKeys(attributeName_xpath, PaymentAmountModal_Xpath, "34.32");
           // Click(attributeName_xpath, PaymentAmountModal_Label_Xpath);
            string GetPaymentAmount = GetAttribute(attributeName_id, PaymentAmountModal_Id, "value");
            Assert.AreEqual(GetPaymentAmount, "34.32");
            Report.WriteLine("Payment Amount field allows upto two decimal places");
        }
        
        [Then(@"The Payment Amount field will auto fill with \$ and two decimal places")]
        public void ThenThePaymentAmountFieldWillAutoFillWithAndTwoDecimalPlaces()
        {
            SendKeys(attributeName_xpath, PaymentAmountModal_Xpath, "34");
            // Click(attributeName_xpath, PaymentAmountModal_Label_Xpath);
            string GetPaymentAmount = GetAttribute(attributeName_id, PaymentAmountModal_Id, "value");
            if ((GetPaymentAmount.Contains("$")) && (GetPaymentAmount.Contains(".00")))
            {
                Report.WriteLine("Payment Amount field is auto filled with $ and two decimal places");
            }
            else
            {
                Assert.Fail();
            }
        }

        [Then(@"Payment Date calender will not allow to select a future date")]
        public void ThenPaymentDateCalenderWillNotAllowToSelectAFutureDate()
        {
            Click(attributeName_id, PaymentDateModal_Lebel_Id);
            string futureDate = GetAttribute(attributeName_xpath, PaymentDate_DatePicker_FutureDisabledDate_Xpath, "class");
            Assert.AreEqual(futureDate, "day disabled new");
        }
        
        [Then(@"The Payment Date field will be editable with the format -  mm/dd/yyyy")]
        public void ThenThePaymentDateFieldWillBeEditableWithTheFormat_MmDdYyyy()
        {
            Click(attributeName_id, PaymentDateModal_Lebel_Id);
            Click(attributeName_xpath, PaymentDate_DatePicker_SelectDate_Xpath);
            string paymentDate = GetAttribute(attributeName_id, PaymentDateModal_Lebel_Id,"value");
            bool isValid = false;
            try
            {
                DateTime.ParseExact(paymentDate, "mm-dd-yyyy", null);
                isValid = true;
            }
            catch (FormatException fe) { }

            Assert.IsTrue(isValid);
        }
        
        [Then(@"The Check Number field will be free form text - allowing a max length of (.*) alpha-numeric and special characters")]
        public void ThenTheCheckNumberFieldWillBeFreeFormText_AllowingAMaxLengthOfAlpha_NumericAndSpecialCharacters(int p0)
        {
            string CheckNumber = "ayment Amount (required, currency; allow up to 2 decimal";
            SendKeys(attributeName_xpath, CheckNumberModal_Xpath, CheckNumber);
            string GetCheckNumberUI = Gettext(attributeName_xpath, CheckNumberModal_Xpath);
            Assert.AreNotEqual(CheckNumber, GetCheckNumberUI);
            Report.WriteLine("Check Number field will not allow more than 50 alpha-numeric and special characters");
            Assert.AreEqual("payment Amount (required, currency; allow up to 2 d", GetCheckNumberUI);
            Report.WriteLine("Check Number field allows upto 50 alpha-numeric and special characters");
        }
        
        [Then(@"Check Date calender will not allow to select a future date")]
        public void ThenCheckDateCalenderWillNotAllowToSelectAFutureDate()
        {
            Click(attributeName_id, CheckDateModal_Lebel_Id);
            string futureDate = GetAttribute(attributeName_xpath, CheckDate_DatePicker_FutureDisabledDate_Xpath, "class");
            Assert.AreEqual(futureDate, "day disabled new");
        }
        
        [Then(@"The Check Date field will be editable with the format -  mm/dd/yyyy")]
        public void ThenTheCheckDateFieldWillBeEditableWithTheFormat_MmDdYyyy()
        {
            Click(attributeName_id, CheckDateModal_Lebel_Id);
            Click(attributeName_xpath, CheckDate_DatePicker_Selectdate_Xpath);
            string checkDate = Gettext(attributeName_id, CheckDateModal_Lebel_Id);
            bool isValid = false;
            try
            {
                DateTime.ParseExact(checkDate, "mm/dd/yyyy", null);
                isValid = true;
            }
            catch (FormatException fe) { }

            Assert.IsTrue(isValid);
        }
        
        [Then(@"The Comments field format will be free form text - allowing a max length of (.*) alpha-numeric and special characters")]
        public void ThenTheCommentsFieldFormatWillBeFreeFormText_AllowingAMaxLengthOfAlpha_NumericAndSpecialCharacters(int p0)
        {
            string CommentField = "Payment Amount (required, currency; allow up to 2 decimal places and always display 2 decimal places, auto fill $ and 2Payment Amount (required, currency; allow up to 2 decimal places and always display 2 decimal places, auto fill $ and 2 decimal places; $xx,xxx.xx)Payment Amount (required, currency; allow up to 2 decimal places and always display 2 decimal places, auto fill $ and 2 decimal Payment Date (required, calendar option, unable to select future date, field editable - format mm/dd/yyyy)768";
            SendKeys(attributeName_xpath, PaymentCommentModal_Xpath, CommentField);
            string GetCommentUI = Gettext(attributeName_xpath, PaymentCommentModal_Xpath);
            Assert.AreNotEqual(CommentField, GetCommentUI);
            Report.WriteLine("Commnent field will not allow more than 500 alpha-numeric and special characters");
            Assert.AreEqual(GetCommentUI, "Payment Amount (required, currency; allow up to 2 decimal places and always display 2 decimal places, auto fill $ and 2Payment Amount (required, currency; allow up to 2 decimal places and always display 2 decimal places, auto fill $ and 2 decimal places; $xx,xxx.xx)Payment Amount (required, currency; allow up to 2 decimal places and always display 2 decimal places, auto fill $ and 2 decimal Payment Date (required, calendar option, unable to select future date, field editable - format mm/dd/yyyy)");
            Report.WriteLine("Commnent field will allow upto 500 alpha-numeric and special characters");
        }

        [Then(@"I will see a list of payment types (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*)")]
        public void ThenIWillSeeAListOfPaymentTypes(string PaymentType1, string PaymentType2, string PaymentType3, string PaymentType4, string PaymentType5, string PaymentType6, string PaymentType7, string PaymentType8, string PaymentType9, string PaymentType10, string PaymentType11, string PaymentType12)
        {
            List<string> PaymentTypeUI = new List<string>();
            List<string> SelectedStationNames = new List<string>(new string[] {PaymentType1, PaymentType2, PaymentType2, PaymentType3, PaymentType4, PaymentType5, PaymentType6, PaymentType7, PaymentType8, PaymentType9, PaymentType10, PaymentType11, PaymentType12});
            IList<IWebElement> PaymentTypes = GlobalVariables.webDriver.FindElements(By.XPath(PaymentTypeDropdownValues_Xpath));
            foreach(var IWebElement in PaymentTypes)
            {
                PaymentTypeUI.Add(IWebElement.Text);
            }

            if(SelectedStationNames.Equals(PaymentTypeUI))
            {
                Report.WriteLine("Expected Payment types are displayed in the list");
            }
            else
            {
                Assert.Fail();
            }
        }

        [Then(@"The payment type list is configurable")]
        public void ThenThePaymentTypeListIsConfigurable()
        {
            List<string> PaymentTypeUI = new List<string>();
            List<string> GetPayementTypeDB = DBHelper.GetPaymentTypes();
            IList<IWebElement> PaymentTypes = GlobalVariables.webDriver.FindElements(By.XPath(PaymentTypeDropdownValues_Xpath));
            foreach (var IWebElement in PaymentTypes)
            {
                PaymentTypeUI.Add(IWebElement.Text);
            }

            if(GetPayementTypeDB.Equals(PaymentTypeUI))
            {
                Report.WriteLine("Configured Payment types are displayed in the list");
            }
            else
            {
                Assert.Fail();
            }
        }


        [Then(@"Payment Date is optional")]
        public void ThenPaymentDateIsOptional()
        {
            Verifytext(attributeName_xpath, PaymentDateModal_Label_Xpath, "Payemnt Date");
            Click(attributeName_xpath, AddNewPaymentButtonModal_Xpath);
            string GetPaymentDateCSS = GetCSSValue(attributeName_xpath, PaymentDateModal_Xpath, "Background");
            Assert.AreNotEqual("rgba(251, 236, 237, 1)", GetPaymentDateCSS);
            Report.WriteLine("Payment Date is optional");
        }

        [Then(@"Check Number is optional")]
        public void ThenCheckNumberIsOptional()
        {
            Verifytext(attributeName_xpath, CheckNumModal_Label_Xpath, "Check Number");
            Click(attributeName_xpath, AddNewPaymentButtonModal_Xpath);
            string GetPaymentDateCSS = GetCSSValue(attributeName_xpath, CheckNumberModal_Xpath, "Background");
            Assert.AreNotEqual("rgba(251, 236, 237, 1)", GetPaymentDateCSS);
            Report.WriteLine("Check Number is optional");
        }
        
        [Then(@"Check Date is optional")]
        public void ThenCheckDateIsOptional()
        {
            Verifytext(attributeName_xpath, CheckDateModal_Label_Xpath, "Check Date");
            Click(attributeName_xpath, AddNewPaymentButtonModal_Xpath);
            string GetPaymentDateCSS = GetCSSValue(attributeName_xpath, CheckDateModal_Xpath, "Background");
            Assert.AreNotEqual("rgba(251, 236, 237, 1)", GetPaymentDateCSS);
            Report.WriteLine("Check Date is optional");
        }

        [When(@"I click on Cancel button of Add Payemnt Modal")]
        public void WhenIClickOnCancelButtonOfAddPayemntModal()
        {
            Click(attributeName_xpath, PaymentModalCancelButton_Xpath);
            Report.WriteLine("Clicked on cancel button of Add Payment modal");
        }


        [Then(@"The modal will close")]
        public void ThenTheModalWillClose()
        {
            VerifyElementNotPresent(attributeName_xpath, PaymentModalTitle_Xpath, "Add Payment");
            Report.WriteLine("Add Payment modal is closed");
        }
        
        [Then(@"No new payment entry is created\.")]
        public void ThenNoNewPaymentEntryIsCreated_()
        {
            IList<IWebElement> PaymentTypesListUI = GlobalVariables.webDriver.FindElements(By.XPath(PaymentTypeList_Xpath));
            int GetPaymnetTypesCount = PaymentTypesListUI.Count;
            if(GetPaymnetTypesCount == GetPaymentTypeCount)
            {
                Report.WriteLine("No new payment is created");
            }
            else
            {
                Assert.Fail();
            }
        }

        [Then(@"The new payment entry will be displayed in the Payment grid\.")]
        public void ThenTheNewPaymentEntryWillBeDisplayedInThePaymentGrid_()
        {
            Random rnd = new Random();
            Click(attributeName_xpath, PaymentTypeDropdown_Xpath);
            Report.WriteLine("Entering data in payment modal");
            SelectDropdownValueFromList(attributeName_xpath, PaymentTypeDropdownValues_Xpath, "Expense");
            SendKeys(attributeName_xpath, PaymentAmountModal_Xpath, ""+rnd.Next(100,500));
            SendKeys(attributeName_xpath, CheckNumberModal_Xpath, "4354");
            SendKeys(attributeName_xpath, PaymentCommentModal_Xpath, "testing testing test xyz claim details comment");

            string paymentType = "Expense";
            string paymentAmount = Gettext(attributeName_id, PaymentAmountModal_Id);
            string comment = "testing testing test xyz claim details comment";
            string checkNumber = "4354";
            string paymentDate = Gettext(attributeName_id, PaymentDateModal_Lebel_Id).Replace('-', '/');
            string checkDate = Gettext(attributeName_id, CheckDateModal_Lebel_Id).Replace('-', '/');
            Report.WriteLine("Adding all payment data");
            string addPageData = paymentType + paymentDate + comment + checkNumber + checkDate + paymentAmount;
           
            Click(attributeName_xpath, AddNewPaymentButtonModal_Xpath);
           
            List<string> mainPageDataList = new List<string>();
            IList<IWebElement> paymentTableRow = GlobalVariables.webDriver.FindElements(By.XPath(PaymentTableRow_Xpath));
           
            for(int i = 0; i< paymentTableRow.Count; i++)
            {
                string paymentTypeFromTable = Gettext(attributeName_xpath, ".//*[@id='PaymentGrid']/tbody/tr[i]/td[1]");
                string paymentDateFromTable = Gettext(attributeName_xpath, ".//*[@id='PaymentGrid']/tbody/tr[i]/td[2]");
                string commentFromTable = Gettext(attributeName_xpath, ".//*[@id='PaymentGrid']/tbody/tr[i]/td[3]");
                string checkNumberFromTable = Gettext(attributeName_xpath, ".//*[@id='PaymentGrid']/tbody/tr[i]/td[4]");
                string checkDateFromTable = Gettext(attributeName_xpath, ".//*[@id='PaymentGrid']/tbody/tr[i]/td[5]");
                string pamentAmountFromTable = Gettext(attributeName_xpath, ".//*[@id='PaymentGrid']/tbody/tr[i]/td[6]");

                string addGridData = paymentTypeFromTable + paymentDateFromTable + commentFromTable + checkNumberFromTable + checkDateFromTable + pamentAmountFromTable;
                mainPageDataList.Add(addGridData);
            }

            Report.WriteLine("Checking new added data in payment grid");
            Assert.IsTrue(mainPageDataList.Contains(addPageData));


        }
        
        [Then(@"The required fields missing information will be highlighted in red\.")]
        public void ThenTheRequiredFieldsMissingInformationWillBeHighlightedInRed_()
        {
            string GetPaymentTypeCSS = GetCSSValue(attributeName_xpath, PaymentTypeDropdown_Xpath, "Background");
            Assert.AreEqual("rgba(251, 236, 237, 1)", GetPaymentTypeCSS);
            string GetPaymentAmountCSS = GetCSSValue(attributeName_xpath, PaymentAmountModal_Xpath, "Background");
            Assert.AreEqual("rgba(251, 236, 237, 1)", GetPaymentAmountCSS);
            string GetPaymentDateCSS = GetCSSValue(attributeName_xpath, PaymentDateModal_Xpath, "Background");
            Assert.AreEqual("rgba(251, 236, 237, 1)", GetPaymentDateCSS);
            string GetCheckNumberCSS = GetCSSValue(attributeName_xpath, CheckNumberModal_Xpath, "Background");
            Assert.AreEqual("rgba(251, 236, 237, 1)", GetCheckNumberCSS);
            string GetCheckDateCSS = GetCSSValue(attributeName_xpath, CheckDateModal_Xpath, "Background");
            Assert.AreEqual("rgba(251, 236, 237, 1)", GetCheckDateCSS);
            string GetPaymentCommentCSS = GetCSSValue(attributeName_xpath, PaymentCommentModal_Xpath, "Background");
            Assert.AreEqual("rgba(251, 236, 237, 1)", GetPaymentCommentCSS);
            Report.WriteLine("The required fields are highlighted in red");


        }
    }
}
