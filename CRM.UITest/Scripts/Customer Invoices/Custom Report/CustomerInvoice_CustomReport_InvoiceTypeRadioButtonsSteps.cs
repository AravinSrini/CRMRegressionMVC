using System;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using TechTalk.SpecFlow;
using System.Configuration;
using System.Collections.Generic;
using OpenQA.Selenium;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;

namespace CRM.UITest.Scripts.Customer_Invoices
{
    [Binding]
    public class CustomerInvoice_CustomReport_InvoiceTypeRadioButtonsSteps : Customer_Invoice
    {
        CommonMethodsCrm crm = new CommonMethodsCrm();
        public string stationName = "ZZZ - Web Services Test";
        public string EnterCustomerName = "All Accounts";
        string ReportName = Guid.NewGuid().ToString() + "CustomRprtTst";
        string ActualColumn_DaysPastDue = null;
        string invoiceNumber = null;
        string reportType = "Closed";

        [Given(@"I am on the Create Custom Report section")]
        public void GivenIAmOnTheCreateCustomReportSection()
        {
            try
            {
                GlobalVariables.webDriver.WaitForPageLoad();
                Click(attributeName_xpath, CustomReportHeaderSection_Xpath);
            }
            catch
            {
                GlobalVariables.webDriver.WaitForPageLoad();
            }

            Report.WriteLine("Expanded the Create Custom Report section");

            ActualColumn_DaysPastDue = Gettext(attributeName_xpath, CustomerInvoices_DaysPastDue_Xpath);
        }

        [Given(@"I have selected the closed radio button")]
        public void GivenIHaveSelectedTheClosedRadioButton()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, CustomReport_CloseRadioButton_Xpath);
            Report.WriteLine("Selected Closed Radio Button as Invoice Type");
        }

        [Given(@"I select valid Station, Accounts and Report Name")]
        public void GivenISelectValidStationAccountsAndReportName()
        {
            IList<IWebElement> StationNameList_UI = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='ReportStations_chosen']/ul/li/span"));
            int StationNameList_UICount = StationNameList_UI.Count;


            if (StationNameList_UICount > 0)
            {
                Report.WriteLine("station name is default selected");
                VerifyElementPresent(attributeName_xpath, ".//*[@id='ReportStations_chosen']//li[1]/span", "DefaultStationSelectedName");

            }
            else
            {

                Click(attributeName_xpath, CustomReport_Station_xpath);
                SelectDropdownValueFromList(attributeName_xpath, CustomReport_StationSelectionValues_xpath, stationName);
                Report.WriteLine("Selected the staion: " + stationName);
            }

            Click(attributeName_xpath, CustomReport_Accounts_xpath);
            SelectDropdownValueFromList(attributeName_xpath, CustomReport_AccountSelectionValues_xpath, EnterCustomerName);
            SendKeys(attributeName_id, CustomReportReportName_Id, ReportName);
        }

        [Given(@"I expanded the Create Custom Report section")]
        public void GivenIExpandedTheCreateCustomReportSection()
        {
            try
            {
                GlobalVariables.webDriver.WaitForPageLoad();
                Click(attributeName_xpath, CustomReportHeaderSection_Xpath);
            }
            catch
            {
                GlobalVariables.webDriver.WaitForPageLoad();
            }

            Report.WriteLine("Expanded the Create Custom Report section");
        }

        [Given(@"I created a CustomReport")]
        public void GivenICreatedACustomReport()
        {
            ActualColumn_DaysPastDue = Gettext(attributeName_xpath, CustomerInvoices_DaysPastDue_Xpath);
            Report.WriteLine("Creating custom Report");
            ReportName = Guid.NewGuid().ToString() + "CustomRprtTest";
            Click(attributeName_id, createCustomReportsectionExpandArrow_id);
            Report.WriteLine("Create Custom Report section is expanded");
            WaitForElementVisible(attributeName_xpath, ReportName_Xpath, "Report Section");
            if (reportType == "Closed")
            {
                Click(attributeName_xpath, "//label[@for='InvoiceTypeClosed']");
            }
            SendKeys(attributeName_id, InvoiceVal_Id, "4");
            scrollElementIntoView(attributeName_id, CustomerInvoices_MakePayment_Button_Id);
            Click(attributeName_xpath, CustomReport_Stations_InputText_Xpath);
            IList<IWebElement> stationValue = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='ReportStations_chosen']//div//li"));
            int count = 0;
            for (int i = 0; i < stationValue.Count; i++)
            {
                if (stationValue[i].Text == stationName)
                {
                    stationValue[i].Click();
                    break;
                }
                count++;
            }

            //#--------------Clicking on First Station if passed station is not avilable
            if (count >= stationValue.Count)
            {
                Click(attributeName_xpath, ".//*[@id='ReportStations_chosen']/div/ul/li[1]");
                stationName = GetAttribute(attributeName_xpath, CustomReport_Stations_InputText_Xpath, "value");
            }
            Click(attributeName_xpath, ReportAccount_Xpath);
            Click(attributeName_xpath, "//div[@id='ReportAccounts_chosen']//ul[@class='chosen-results']/li[1]");
            SendKeys(attributeName_xpath, ReportName_Xpath, ReportName);
            Report.WriteLine("Values are passed to all the fields");            
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [When(@"I click the Preview/Run Now button")]
        public void WhenIClickThePreviewRunNowButton()
        {
            Report.WriteLine("Click on the Preview Run Now button");
            Click(attributeName_id, CustomReport_Preview_Run_Button_Id);
        }

        [When(@"I expanded the Create Custom Report section")]
        public void WhenIExpandedTheCreateCustomReportSection()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, CustomReportHeaderSection_Xpath);
            Report.WriteLine("Expanded the Create Custom Report section");
        }

        [When(@"I Select Closed as the Invoice Type")]
        public void WhenISelectClosedAsTheInvoiceType()
        {
            GlobalVariables.webDriver.WaitForPageLoad();

            if (IsElementVisible(attributeName_xpath, CustomReport_CreateReportSection_InvoiceType_Closed_Xpath, "InvoiceType"))
            {
                Click(attributeName_xpath, CustomReport_CreateReportSection_InvoiceType_Closed_Xpath);
                Report.WriteLine("Selected Closed as the InoviceType");
            }
            else
            {
                Report.WriteFailure("InvoiceType Closed is not visible");
            }
        }

        [Then(@"I will no longer see the Days Past Due column in my grid results\.")]
        public void ThenIWillNoLongerSeeTheDaysPastDueColumnInMyGridResults_()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            VerifyElementNotPresent(attributeName_xpath, CustomerInvoices_DaysPastDueUsingText_Xpath, ActualColumn_DaysPastDue);
            Report.WriteLine("Days Past Due column is removed");
        }

        [Then(@"the Invoice Type selection will be defaulted to Open")]
        public void ThenTheInvoiceTypeSelectionWillBeDefaultedToOpen()
        {
            string invoiceTypeOpenOptionSelected = GetAttribute(attributeName_id, CustomReport_CreateReportSection_InvoiceType_Open_Id, "checked");
            Assert.AreEqual("true", invoiceTypeOpenOptionSelected);
            Report.WriteLine("Verified that the InvoiceType is defaulted to Open");
        }

        [Then(@"I have the option to select Closed")]
        public void ThenIHaveTheOptionToSelectClosed()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            bool isClosedOptionAvailable = IsElementPresent(attributeName_id, CustomReport_CreateReportSection_InvoiceType_Closed_Id, "InvoiceType");
            Assert.IsTrue(isClosedOptionAvailable);
            Report.WriteLine("Verified that I have an option to select Closed as InoviceType ");
        }

        [Then(@"I have the option to select All")]
        public void ThenIHaveTheOptionToSelectAll()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            bool isAllOptionAvailable = IsElementPresent(attributeName_id, CustomReport_CreateReportSection_InvoiceType_All_Id, "InvoiceType");
            Assert.IsTrue(isAllOptionAvailable);
            Report.WriteLine("Verified that I have an option to select All as InoviceType ");
        }

        [Then(@"I am unable to enter a Days Past Due value")]
        public void ThenIAmUnableToEnterADaysPastDueValue()
        {
            string daysPastDueDisabledProperty = GetAttribute(attributeName_id, CustomReport_DaysPastDue_Input_Id, "disabled");
            Assert.AreEqual("true", daysPastDueDisabledProperty);
            Report.WriteLine("Verified that the DaysPastDue field is disabled");
        }

        [Then(@"I will see a New column labeled Payment Date to the right of column Due Date")]
        public void ThenIWillSeeANewColumnLabeledPaymentDateToTheRightOfColumnDueDate()
        {
            String ActualColumn_PaymentDate = Gettext(attributeName_xpath, CustomerInvoices_PaymentDate_Xpath);
            VerifyElementPresent(attributeName_xpath, CustomerInvoices_PaymentDate_Xpath, ActualColumn_PaymentDate);
            Report.WriteLine("Payment Date Column is present");
        }


        [Then(@"the value for this column will be the Last Payment Date from Table from SAP")]
        public void ThenTheValueForThisColumnWillBeTheLastPaymentDateFromTableFromSAP()
        {

            if(Gettext(attributeName_xpath, CustomerInvocies_NoResultFound_Xpath)== "No Results Found")
            {
                Report.WriteLine("Invoices data not available");
            }
            else
            {
                IList<IWebElement> allInvoicesNumbers = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoices_AllInvoiceNumbers_xpath));
                IList<IWebElement> allPaymentDates = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoices_AllPaymentDate_xpath));

                int allInvoicesNumbersCount = allInvoicesNumbers.Count;
                for(int i=0; i< allInvoicesNumbersCount; i++)
                {

                    invoiceNumber = allInvoicesNumbers[i].Text;
                    CustomerInvoice invoiceNumberDetails = DBHelper.GetCustomerInvoiceDetails(invoiceNumber);
                    string lastPaymentDateUIValue = allPaymentDates[i].Text;
                    string LastPaymentDateWithTime = invoiceNumberDetails.LastPaymentDate.ToString();
                    Assert.IsTrue(LastPaymentDateWithTime.Contains(lastPaymentDateUIValue));
                }
                
            }                        
        }

    }
}
