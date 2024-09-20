using Aspose.Cells;
using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Insurance_Claims.Claim_Details
{
    [Binding]
    public class _39769_InsuranceClaims_ClaimDetails_ExportbuttonSteps : InsuranceClaim
    {
        CommonMethodsCrm crmLogin = new CommonMethodsCrm();
        int claimNumber = 0;
        List<string> exportOptionAmend = new List<string>();


        string downloadpath = null;
        InsuranceClaims_ClaimDetailsHeader_Claim_Specialist_Steps claimDetails = new InsuranceClaims_ClaimDetailsHeader_Claim_Specialist_Steps();
        string clmainType = null;
        string claimNumber_ClaimsDetails_UI=null;

        [Given(@"I am on the claim details page for any claim Type LTL,FTL,Forwording")]
        public void GivenIAmOnTheClaimDetailsPageForAnyClaimTypeLTLFTLForwording()
        {
            claimDetails.WhenIAmOnTheDetailsTabOfTheClaimDetails();
            GlobalVariables.webDriver.WaitForPageLoad();
            clmainType = Gettext(attributeName_xpath, ClaimDetailsMode_Xpath);
        }


        [Given(@"I am a sales, sales management, operations, station owner, or claim specialist user")]
        public void GivenIAmASalesSalesManagementOperationsStationOwnerOrClaimSpecialistUser()
        {
            string username = ConfigurationManager.AppSettings["username-claimspecialistClaim"].ToString();
            string password = ConfigurationManager.AppSettings["password-claimspecialistClaim"].ToString();
            CommonMethodsCrm crmLogin = new CommonMethodsCrm();
            crmLogin.LoginToCRMApplication(username, password);
        }

        [When(@"I click on the Export button from claim details page")]
        public void WhenIClickOnTheExportButtonFromClaimDetailsPage()
        {
            Click(attributeName_id, DifferentTypeReportExportButton_id);
        }

        [Given(@"I clicked on the Export button")]
        public void GivenIClickedOnTheExportButton()
        {
            Click(attributeName_id, DifferentTypeReportExportButton_id);
        }

        [Then(@"I will see a drop down list of exportable report options Payment Tab,History Tab,Claim Submitted by Customer")]
        public void ThenIWillSeeADropDownListOfExportableReportOptionsPaymentTabHistoryTabClaimSubmittedByCustomer()
        {
            IList<IWebElement> value = GlobalVariables.webDriver.FindElements(By.XPath(DifferentTypeReportExportOptions_Xpath));
            List<string> exportOptionsUI = new List<string>();
            for (int i = 0; i < value.Count; i++)
            {
                string data = value[i].Text;
                data.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
                exportOptionsUI.Add(data);
            }
            List<string> expectedExportOptions = new List<string>
           {
               "Payment Tab", "History Tab", "Claim Submitted By Customer"

           };

            CollectionAssert.AreEqual(expectedExportOptions, exportOptionsUI);
        }


        [When(@"I select(.*) the History Tab or Payment Tab option")]
        public void WhenISelectTheHistoryTabOrPaymentTabOption(string reportExportType)
        {
            if (reportExportType == "Payment Tab")
            {
                Click(attributeName_xpath, PaymentTabReportExportButton_Xpath);
            }
            if (reportExportType == "History Tab")
            {
                Click(attributeName_xpath, HistoryTabReportExportButton_Xpath);
            }
            GlobalVariables.webDriver.WaitForPageLoad();
        }


        [Then(@"An excel report will be downloaded with the details displayed of corresponding tab (.*)")]
        public void ThenAnExcelReportWillBeDownloadedWithTheDetailsDisplayedOfCorrespondingTab(string reportExportType)
        {
            GetDownloadPath GetDownloadFolder = new GetDownloadPath();
            if (reportExportType == "Payment Tab")
            {
                downloadpath = GetDownloadFolder.GetDownloadFolderPath(@"\Export Report_Claims_Payment Tab.xlsx");
                Workbook wb = new Workbook(downloadpath);
                Worksheet Worksheet = wb.Worksheets[0];
                Cells cells = Worksheet.Cells;
                int colcount = Worksheet.Cells.MaxDataColumn;
                int rowcount = Worksheet.Cells.MaxDataRow;
                Range range = Worksheet.Cells.MaxDisplayRange;
                Click(attributeName_xpath, "//a[text()='Payments']");
                string uiText = Gettext(attributeName_xpath, "//table[@id='PaymentGrid']/tbody/tr");
                if (uiText.ToLower() == "No Results Found".ToLower())
                {
                    string excelContent = Convert.ToString((range[7, 0]).DisplayStringValue);
                    string expectedValue = string.Empty;
                    Assert.AreEqual(expectedValue, excelContent);
                    DeleteFilesFromFolder(downloadpath);
                }
                else
                {
                    int uiValue = GlobalVariables.webDriver.FindElements(By.XPath("//table[@id='PaymentGrid']/tbody/tr")).Count();
                    int expectedRowPaymentExcel = uiValue + 6;
                    try
                    {
                        for (int k = 0; k <= expectedRowPaymentExcel; k++)
                        {

                            for (int j = 0; j <= colcount; j++)
                            {
                                string excelContent = Convert.ToString((range[k, j]).DisplayStringValue);
                                if (k == 0)
                                {
                                    if (excelContent.Contains("DLSW Payment Tab Report"))
                                    {
                                        Report.WriteLine("Excel header value" + excelContent + "is matching with the expected value");
                                        break;
                                    }

                                    else
                                    {
                                        Assert.Fail();
                                    }
                                }
                                if (k == 2)
                                {
                                    if (excelContent.Contains("DLSW Claim #"))
                                    {
                                        Report.WriteLine("Excel header value" + excelContent + "is matching with the expected value");
                                        break;
                                    }
                                    else
                                    {
                                        Assert.Fail();
                                    }
                                }
                                if (k == 4)
                                {
                                    if (excelContent.Contains("Outstanding Amount:"))
                                    {
                                        Report.WriteLine("Excel header value" + excelContent + "is matching with the expected value");
                                        break;
                                    }
                                    else
                                    {
                                        Assert.Fail();
                                    }
                                }
                                if (k == 6)
                                {
                                    List<string> expectedPaymentHeaderColumnValues = new List<string>(new string[] { "Payment Type", "PaymentDate", "Comment", "Check Number", "Check Date", "Payment Amount" });

                                    if (expectedPaymentHeaderColumnValues[j].Contains(excelContent))
                                    {
                                        Report.WriteLine("Excel header value" + excelContent + "is matching with the expected value");
                                    }
                                    else
                                    {
                                        Assert.Fail();
                                    }
                                }
                                if (k > 6)
                                {

                                    string paymentValueUI = Gettext(attributeName_xpath, "//table[@id='PaymentGrid']/tbody/tr[" + (k - 6) + "]/td[" + (j + 1) + "]");
                                    Assert.AreEqual(paymentValueUI, excelContent);
                                }
                            }

                        }
                    }
                    finally
                    {
                        DeleteFilesFromFolder(downloadpath);
                    }
                }
            }

            if (reportExportType == "History Tab")
            {
                downloadpath = GetDownloadFolder.GetDownloadFolderPath(@"\Export Report_Claims_History Tab.xlsx");
                Workbook wb = new Workbook(downloadpath);
                Worksheet Worksheet = wb.Worksheets[0];
                Cells cells = Worksheet.Cells;
                int colcount = Worksheet.Cells.MaxDataColumn;
                int rowcount = Worksheet.Cells.MaxDataRow;
                Range range = Worksheet.Cells.MaxDisplayRange;

                Click(attributeName_id, "tabClaimDetailStatusHistory");
                string uiText = Gettext(attributeName_xpath, "//table[@id='InsuranceClaimHistoryGrid']/tbody/tr");
                if (uiText.ToLower() == "No data available in table".ToLower())
                {
                    string excelContent = Convert.ToString((range[6, 0]).DisplayStringValue);
                    string expectedValue = string.Empty;
                    Assert.AreEqual(expectedValue, excelContent);
                    DeleteFilesFromFolder(downloadpath);
                }

                else
                {
                    int uiValue = GlobalVariables.webDriver.FindElements(By.XPath("//table[@id='InsuranceClaimHistoryGrid']/tbody/tr")).Count();
                    int expectedRowHistoryExcel = uiValue + 5;

                    try
                    {
                        for (int k = 0; k <= expectedRowHistoryExcel; k++)
                        {

                            for (int j = 0; j <= colcount; j++)
                            {
                                string excelContent = Convert.ToString((range[k, j]).DisplayStringValue);
                                if (k == 0)
                                {
                                    if (excelContent.Contains("DLSW History Tab Report"))
                                    {
                                        Report.WriteLine("Excel header value" + excelContent + "is matching with the expected value");
                                        break;
                                    }

                                    else
                                    {
                                        Assert.Fail();
                                    }
                                }
                                if (k == 2)
                                {
                                    if (excelContent.Contains("DLSW Claim #"))
                                    {
                                        Report.WriteLine("Excel header value" + excelContent + "is matching with the expected value");
                                        break;
                                    }
                                    else
                                    {
                                        Assert.Fail();
                                    }
                                }
                                if (k == 5)
                                {
                                    List<string> expecteDHistoryHeaderColumnValues = new List<string>(new string[] { "Date/Time", "Updated By", "Category", "Comment" });

                                    if (expecteDHistoryHeaderColumnValues.Contains(excelContent))
                                    {
                                        Report.WriteLine("Excel header value" + excelContent + "is matching with the expected value");
                                    }
                                    else
                                    {
                                        Assert.Fail();
                                    }
                                    if (k > 5)
                                    {
                                        string historyValueUI = Gettext(attributeName_xpath, "//table[@id='PaymentGrid']/tbody/tr[" + (k - 4) + "]/td[" + (j + 1) + "]");
                                        Assert.AreEqual(historyValueUI, excelContent);
                                    }
                                }

                            }
                        }
                    }
                    finally
                    {
                        DeleteFilesFromFolder(downloadpath);
                    }
                }
            }
        }


        [When(@"I Select The Claim Submitted by Customer option")]
        public void WhenISelectTheClaimSubmittedByCustomerOption()
        {
            claimNumber_ClaimsDetails_UI = GetAttribute(attributeName_id, "DlswClaim", "value");
            Click(attributeName_xpath, ClaimSubmittedByCustomerTabReportExportButton_Xpath);
        }


        [Then(@"A PDF of the claim submitted to DLSW will be displayed in next tab")]
        public void ThenAPDFOfTheClaimSubmittedToDLSWWillBeDisplayedInNextTab()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            string configURL = launchUrl;
            Report.WriteLine("Verifying the Pdf opened in new tab");
            WindowHandling(configURL + "InsuranceClaim/ViewCustomerSubmittedClaimDetailsDocument?insuranceClaimNumber=" + claimNumber_ClaimsDetails_UI);
            string resultPagrURL = configURL + "InsuranceClaim/ViewCustomerSubmittedClaimDetailsDocument?insuranceClaimNumber=" + claimNumber_ClaimsDetails_UI;
            if (GetURL() == resultPagrURL)
            {
                Report.WriteLine("A PDF of the claim submitted to DLSWm is opened in New Tab");
            }
            else
            {
                Report.WriteFailure ("A PDF of the claim submitted to DLSWm is not opened in New Tab");
            }
        }


        [Given(@"I am user who have access to Claim Details page '(.*)' '(.*)'")]
        public void GivenIAmUserWhoHaveAccessToClaimDetailsPage(string userName, string passWord)
        {
            string username = ConfigurationManager.AppSettings[userName].ToString();
            string password = ConfigurationManager.AppSettings[passWord].ToString();
            crmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"I am on the claim details page of a claim that was previously amended and resubmitted")]
        public void GivenIAmOnTheClaimDetailsPageOfAClaimThatWasPreviouslyAmendedAndResubmitted()
        {
            Submit_AmendClaim ClaimVal = new Submit_AmendClaim();
            ClaimVal.ClaimSubmitAmend("InternalOrClaimspecialist");
            ResubmitClaim ClaimNum = new ResubmitClaim();
            claimNumber = ClaimNum.GetResubmitClaimNumber();
            SendKeys(attributeName_xpath, ClaimListPageSearch_Xpath, claimNumber.ToString());
            string claimNumberGridVal = Gettext(attributeName_xpath, ClaimListFirstClaimNumberClaimUser_Xpath);
            Click(attributeName_linktext, claimNumberGridVal);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Navigated to Claim Details page of a claim that was previously amended and resubmitted");
        }

        [Given(@"I am on the claim details page of a claim that was previously amended and resubmitted for an internal user")]
        public void GivenIAmOnTheClaimDetailsPageOfAClaimThatWasPreviouslyAmendedAndResubmittedForAnInternalUser()
        {
            Click(attributeName_id, ClaimsIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Submit_AmendClaim ClaimVal = new Submit_AmendClaim();
            ClaimVal.ClaimSubmitAmend("InternalOrClaimspecialist");
            ResubmitClaim ClaimNum = new ResubmitClaim();
            claimNumber = ClaimNum.GetResubmitClaimNumber();
            SendKeys(attributeName_xpath, ClaimListPageSearch_Xpath, claimNumber.ToString());
            string claimNumberGridVal = Gettext(attributeName_xpath, ClaimListFirstClaimNumberInternal_Xpath);
            Click(attributeName_linktext, claimNumberGridVal);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Navigated to Claim Details page of a claim that was previously amended and resubmitted");
        }

        [When(@"I click on Export dropdown arrow of Claim details page")]
        public void WhenIClickOnExportDropdownArrowOfClaimDetailsPage()
        {
            Click(attributeName_id, DifferentTypeReportExportButton_id);
            Report.WriteLine("Clicked on Export dropdown arrow of Claim details page");
        }


        [Then(@"I will see a new option '(.*)' on the export dropdown of Claim details page")]
        public void ThenIWillSeeANewOptionOnTheExportDropdownOfClaimDetailsPage(string claimAmendByCustomerOption)
        {
            GetExportDropdownVal();
            if (exportOptionAmend.Contains(claimAmendByCustomerOption))
            {
                Report.WriteLine("Claim Amended By Customer option is present in the export dropdown");
            }
            else
            {
                Assert.Fail();
            }
        }

        [Given(@"I am on the claim details page of a claim that was not previously amended and resubmitted for internal user")]
        public void GivenIAmOnTheClaimDetailsPageOfAClaimThatWasNotPreviouslyAmendedAndResubmittedForInternalUser()
        {
            Click(attributeName_id, ClaimsIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, SubmitClaimButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Navigated to Submit a Claim page");
            InsuranceClaimsubmit Claim = new InsuranceClaimsubmit();
            claimNumber = Claim.Claimsubmit("InternalOrClaimSpecialist");//Submitted a Claim
            SendKeys(attributeName_xpath, ClaimListPageSearch_Xpath, claimNumber.ToString());
            string claimNumberGridVal = Gettext(attributeName_xpath, ClaimListFirstClaimNumberInternal_Xpath);
            Click(attributeName_linktext, claimNumberGridVal);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Navigated to Claim Details page of a claim that was not previously amended and resubmitted");

        }

        [Given(@"I am on the claim details page of a claim that was not previously amended and resubmitted")]
        public void GivenIAmOnTheClaimDetailsPageOfAClaimThatWasNotPreviouslyAmendedAndResubmitted()
        {
            Click(attributeName_xpath, SubmitClaimButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Navigated to Submit a Claim page");
            InsuranceClaimsubmit Claim = new InsuranceClaimsubmit();
            claimNumber = Claim.Claimsubmit("InternalOrClaimSpecialist");//Submitted a Claim
            SendKeys(attributeName_xpath, ClaimListPageSearch_Xpath, claimNumber.ToString());
            string claimNumberGridVal = Gettext(attributeName_xpath, ClaimListFirstClaimNumberClaimUser_Xpath);
            Click(attributeName_linktext, claimNumberGridVal);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Navigated to Claim Details page of a claim that was not previously amended and resubmitted");
        }

        [Then(@"I will not see a new option '(.*)' on the export dropdown of Claim details page")]
        public void ThenIWillNotSeeANewOptionOnTheExportDropdownOfClaimDetailsPage(string claimAmendByCustomerOption)
        {
            GetExportDropdownVal();
            if (exportOptionAmend.Contains(claimAmendByCustomerOption))
            {
                Assert.Fail();
            }
            else
            {
                Report.WriteLine("Claim Amended By Customer option is not present in the export dropdown");
            }
        }

        [When(@"I click on Claim Amended By Customer option from the export dropdown of Claim details page")]
        public void WhenIClickOnClaimAmendedByCustomerOptionFromTheExportDropdownOfClaimDetailsPage()
        {
            Click(attributeName_id, DifferentTypeReportExportButton_id);
            Report.WriteLine("Clicked on Export dropdown arrow of Claim details page");
            Click(attributeName_xpath, ClaimAmendedByCustomerTabReportExportButton_Xpath);
            Report.WriteLine("clicked on Claim Amended By Customer option from the export dropdown of Claim details page");

        }

        [Then(@"I will see a pdf of the amended claim form with the most recent data updates")]
        public void ThenIWillSeeAPdfOfTheAmendedClaimFormWithTheMostRecentDataUpdates()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            string configURL = launchUrl;
            Report.WriteLine("Verifying the Pdf opened in new tab");

            string resultPagrURL = configURL + "InsuranceClaim/ViewClaimDetailsDocument?insuranceClaimNumber=" + claimNumber;
            WindowHandling(resultPagrURL);
            string ExpectedURL = GetURL();
            Assert.AreEqual(resultPagrURL, ExpectedURL);
            Report.WriteLine("pdf of the amended claim form with the most recent data updates is opened in a new tab");

        }

        public void GetExportDropdownVal()
        {
            IList<IWebElement> options = GlobalVariables.webDriver.FindElements(By.XPath(DifferentTypeReportExportOptions_Xpath));
            for (int i = 0; i < options.Count; i++)
            {
                string data = options[i].Text;
                exportOptionAmend.Add(data);
            }
        }
    }
}
