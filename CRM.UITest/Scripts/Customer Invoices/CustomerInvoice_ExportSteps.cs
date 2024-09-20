using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using Aspose.Cells;
using System.Configuration;
using System.Threading;
using System.Linq;

namespace CRM.UITest.Scripts.Customer_Invoices
{
    [Binding]
    public class CustomerInvoice_ExportSteps : Customer_Invoice
    {
        public string downloadpath;
        CommonMethodsCrm crm = new CommonMethodsCrm();
        public WebElementOperations objWebElementOperations = new WebElementOperations();
             
        public CustomerInvoice_ExportSteps()
        {
            License license = new License();
            license.SetLicense("Aspose.Cells.lic");
        }

        [Given(@"I am a operations, sales, sales management, station owner or Access RRD User")]
        public void GivenIAmAOperationsSalesSalesManagementStationOwnerOrAccessRRDUser()
        {
            Report.WriteLine("Logging into CRM with an Access RRD user");
            string username = ConfigurationManager.AppSettings["username-AccessRRDUser"].ToString();
            string password = ConfigurationManager.AppSettings["password-AccessRRDUser"].ToString();
            crm.LoginToCRMApplication(username, password);
        }              

        [Given(@"I click on the button search invoices")]
        public void GivenIClickOnTheButtonSearchInvoices()
        {
            Report.WriteLine("Clicking on the search invoices button");
            Click(attributeName_id, SearchAreaSearchInvoicesButton_id);
            GlobalVariables.webDriver.WaitForPageLoad();
        }


        [Then(@"I have the option to select All - Excel")]
        public void ThenIHaveTheOptionToSelectAll_Excel()
        {
            VerifyElementPresent(attributeName_id, CustomInvoiceExportExcel_Id, "Excel export option");
            Report.WriteLine("Excel export option is present");
        }

        [Then(@"I have the option to select All - PDF")]
        public void ThenIHaveTheOptionToSelectAll_PDF()
        {
            VerifyElementPresent(attributeName_id, CustomInvoiceExportPDF_Id, "PDF export option");
            Report.WriteLine("PDF export option is present");
        }

        [Then(@"I will no longer have an option to select Displayed")]
        public void ThenIWillNoLongerHaveAnOptionToSelectDisplayed()
        {
            string ExportOption2 = Gettext(attributeName_id, CustomInvoiceExportPDF_Id);
            if (ExportOption2 != "Displayed")
            {
                Report.WriteLine("Select Displayed option is no longer available");
            }
            else
            {
                Assert.Fail();
            }
        }

        [Given(@"Open filter is applied")]
        public void GivenOpenFilterIsApplied()
        {
            Click(attributeName_xpath, CustomInvoiceGridOpenFilter_Xpath);
            Report.WriteLine("Open filter is applied");
        }
        
        [Given(@"I select a Open Saved Report (.*) from the dropdown")]
        public void GivenISelectAOpenSavedReportClosedInvoiceReportFromTheDropdown(string savedReport)
        {
            Report.WriteLine("Chosen the saved report with Closed status from the dropdown which is: " + savedReport);
            Click(attributeName_xpath, SelectExistingReportDropdown_Xpath);
            Thread.Sleep(1000);
            SendKeys(attributeName_xpath, SelectExistingReportDropdown_SearchInputInDropdown_Xpath, savedReport);
            var items = GlobalVariables.webDriver.FindElements(By.XPath(SelectExistingReport_SearchedDataSelectInDropdown_Xpath));
            var selectedItem = items.FirstOrDefault(x => x.Text == savedReport);
            selectedItem.Click();
            GlobalVariables.webDriver.WaitForPageLoad();
        }


        [Given(@"Closed filter is applied")]
        public void GivenClosedFilterIsApplied()
        {
            Click(attributeName_xpath, CustomInvoiceGridClosedFilter_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Closed filter is applied");            
        }

        [Given(@"All filter is applied")]
        public void GivenAllFilterIsApplied()
        {
            Click(attributeName_xpath, CustomInvoiceGridAllFilter_Xpath);
            Report.WriteLine("All filter is applied");
        }

        [When(@"I click on All - PDF option from the export dropdown")]
        public void WhenIClickOnAll_PDFOptionFromTheExportDropdown()
        {
            Click(attributeName_id, CustomInvoiceExportButton_Id);
            Click(attributeName_id, CustomInvoiceExportPDF_Id);
            Report.WriteLine("Clicked on PDF Export option");
        }

        [Then(@"I will no longer have an option to select All")]
        public void ThenIWillNoLongerHaveAnOptionToSelectAll()
        {
            string ExportOption1 = Gettext(attributeName_id, CustomInvoiceExportExcel_Id);
            if(ExportOption1 != "All")
            {
                Report.WriteLine("Select All option is no longer available");
            }
            else
            {
                Assert.Fail();
            }
        }

        [When(@"I click on Export drop down arrow")]
        public void WhenIClickOnExportDropDownArrow()
        {
            Click(attributeName_id, CustomInvoiceExportButton_Id);
            Report.WriteLine("Clicked on Export button");
        }
        
        [When(@"I click on All - Excel option from the export dropdown")]
        public void WhenIClickOnAll_ExcelOptionFromTheExportDropdown()
        {
            Click(attributeName_id, CustomInvoiceExportButton_Id);
            Click(attributeName_id, CustomInvoiceExportExcel_Id);
            Report.WriteLine("All - Excel option is clicked");
        }
        
        [Then(@"A Customer Invoice excel should get downloaded")]
        public void ThenACustomerInvoiceExcelShouldGetDownloaded()
        {          
            downloadpath = GetDownloadedFilePath("CustomerInvoiceListExport.xls"); 
            Report.WriteLine("Customer Invoice excel is downloaded");
        }
        
        [Then(@"The excel file should contain the following column names - Sales Rep, Account \#, Station, Customer \#, Customer Name, Invoice Number, Reference ID \#, Invoice Date, Due Date, Original Amt, Outstanding Amt, Days Past Due, Dispute Code")]
        public void ThenTheExcelFileShouldContainTheFollowingColumnNames_SalesRepAccountStationCustomerCustomerNameInvoiceNumberReferenceIDInvoiceDateDueDateOriginalAmtOutstandingAmtDaysPastDueDisputeCode()
        {
            Workbook wb = new Workbook(downloadpath);
            Worksheet Worksheet = wb.Worksheets[0];
            Cells cells = Worksheet.Cells;
            int colcount = Worksheet.Cells.MaxDataColumn;
            int rowcount = Worksheet.Cells.MaxDataRow;
            Range range = Worksheet.Cells.MaxDisplayRange;
            for (int k = 1; k <= 1; k++)
            {
                for (int j = 0; j <= colcount; j++)
                {
                    string Exccontent = Convert.ToString((range[k, j]).DisplayStringValue);
                    List<string> expecteDHeaderColumnValues = new List<string>(new string[] { "Sales Rep", "Account #", "Station", "Customer #", "Customer Name", "Invoice Number", "Reference ID #", "Invoice Date", "Due Date", "Original Amt", "Outstanding Amt", "Days Past Due", "Dispute Code" });
                    if(expecteDHeaderColumnValues.Contains(Exccontent))
                    {
                        Report.WriteLine("Excel header value" + Exccontent + "is matching with the expected value");
                    }
                    else
                    {
                        Assert.Fail();
                    }
                }
            }
            DeleteFilesFromFolder(downloadpath);
        }

        [Then(@"Excel sheet count and values should match with the UI count and values of Customer Invoice list page")]
        public void ThenExcelSheetCountAndValuesShouldMatchWithTheUICountAndValuesOfCustomerInvoiceListPage()
        {
            
            int k = 0;
            int UIrow = 0;    
            List<string> UIvalue = IndividualColumnData("//html//tr[@role = 'row']");
            int UIValCount = UIvalue.Count;
            Workbook wb = new Workbook(downloadpath);
            Worksheet Worksheet = wb.Worksheets[0];
            Cells cells = Worksheet.Cells;
            int colcount = Worksheet.Cells.MaxDataColumn;
            int rowcount = Worksheet.Cells.MaxDataRow;
            Range range = Worksheet.Cells.MaxDisplayRange;
               if(UIValCount== rowcount)
                { 
                for ( k = 2; k <= rowcount; k++)
                {
                    int UIcolumn = 1;
                    if(k == 2)
                    {
                       UIrow = 1;
                    }
                    else
                    {
                       UIrow = UIrow + 1;//Gets value of next row from UI
                    }                
                    for (int j = 0; j <= colcount; j++)
                    {
                       string UIstatus = GlobalVariables.webDriver.FindElement(By.XPath("//html//tr[@role = 'row'][" + UIrow + "]/td[" + UIcolumn + "]")).Text;
                       string Exccontent = Convert.ToString((range[k, j]).DisplayStringValue);
                       if(UIstatus.Contains(Exccontent))
                       {
                          Report.WriteLine("Value from excel" + Exccontent + "is matching with UI value");
                          UIcolumn++;
                       }
                        else if(UIcolumn == 8)
                        {
                            UIcolumn++; // Due Date skip from UI
                            j--;
                        }
                        else if(UIcolumn == 5)
                        {
                           UIcolumn--;
                           j--;
                        }
                        else
                        {
                           Assert.Fail();
                        }
                      }
                    }                                 
                }
                else
                {
                    Assert.Fail();
                }

            DeleteFilesFromFolder(downloadpath);
        }
        
        [Then(@"A Customer Invoice PDF document should get opened in an other tab")]
        public void ThenACustomerInvoicePDFDocumentShouldGetOpenedInAnOtherTab()
        {
            string ExpecURL = "http://dlsww-test.rrd.com/CustomerInvoice/CustomerInvoicePdfExport";
            WindowHandling(ExpecURL);
            string expectedURL = GetURL();
            Assert.AreEqual(expectedURL, ExpecURL);
            Report.WriteLine("Customer Invoice PDF document is opened in an other tab");

        }        

        [Given(@"I am a shp\.entry, shp\.entrynortes, shp\.inquiry, shp\.inquirynorates, or access rrd user")]
        public void GivenIAmAShp_EntryShp_EntrynortesShp_InquiryShp_InquirynoratesOrAccessRrdUser()
        {
            string username = ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();
            string password = ConfigurationManager.AppSettings["ExternalUserPassword"].ToString();
            crm.LoginToCRMApplication(username, password);
        }

        [When(@"I click on Excel option from the export dropdown")]
        public void WhenIClickOnExcelOptionFromTheExportDropdown()
        {            
            Click(attributeName_id, CustomInvoiceExportButton_Id);
            Click(attributeName_id, CustomInvoiceExportExcel_Id);
            Report.WriteLine("Excel option is clicked");
        }

        [Then(@"The excel file should contain the following column names - Sales Rep, Account \#, Station, Customer \#, Customer Name, Invoice Number, Reference ID \#, Invoice Date, Due Date, Payment Date, Original Amt, Outstanding Amt, Dispute Code")]
        public void ThenTheExcelFileShouldContainTheFollowingColumnNames_SalesRepAccountStationCustomerCustomerNameInvoiceNumberReferenceIDInvoiceDateDueDatePaymentDateOriginalAmtOutstandingAmtDisputeCode()
        {
            Workbook wb = new Workbook(downloadpath);
            Worksheet Worksheet = wb.Worksheets[0];
            Cells cells = Worksheet.Cells;
            int colcount = Worksheet.Cells.MaxDataColumn;
            int rowcount = Worksheet.Cells.MaxDataRow;
            Range range = Worksheet.Cells.MaxDisplayRange;
            for (int k = 1; k <= 1; k++)
            {
                for (int j = 0; j <= colcount; j++)
                {
                    string Exccontent = Convert.ToString((range[k, j]).DisplayStringValue);
                    List<string> expecteDHeaderColumnValues = new List<string>(new string[] { "Sales Rep", "Account #", "Station", "Customer #", "Customer Name", "Invoice Number", "Reference ID #", "Invoice Date", "Due Date", "Payment Date", "Original Amt", "Outstanding Amt", "Dispute Code" });
                    if (expecteDHeaderColumnValues.Contains(Exccontent))
                    {
                        Report.WriteLine("Excel header value" + Exccontent + "is matching with the expected value");
                    }
                    else
                    {
                        Assert.Fail();
                    }
                }
            }
            DeleteFilesFromFolder(downloadpath);
        }

        [Then(@"Excel sheet count and values should match with UI count and values of Customer Invoice list page")]
        public void ThenExcelSheetCountAndValuesShouldMatchWithUICountAndValuesOfCustomerInvoiceListPage()
        {
            int k = 0;
            List<string> UIvalue = IndividualColumnData("//html//tr[@role = 'row']");
            int UIValCount = UIvalue.Count;
            Workbook wb = new Workbook(downloadpath);
            Worksheet Worksheet = wb.Worksheets[0];
            Cells cells = Worksheet.Cells;
            int colcount = Worksheet.Cells.MaxDataColumn;
            int rowcount = Worksheet.Cells.MaxDataRow;
            Range range = Worksheet.Cells.MaxDisplayRange;
            if (UIValCount == rowcount)
            {
                for (k = 2; k <= rowcount; k++)
                {
                    int UIcolumn = 1;
                    int UIrow = 1;

                    if (k > 2)
                    {
                        UIrow = UIrow + 1;//Gets value of next row from UI
                    }
                    for (int j = 0; j <= colcount; j++)
                    {
                        string UIstatus = GlobalVariables.webDriver.FindElement(By.XPath("//html//tr[@role = 'row'][" + UIrow + "]/td[" + UIcolumn + "]")).Text;
                        string Exccontent = Convert.ToString((range[k, j]).DisplayStringValue);
                        if (UIstatus.Contains(Exccontent))
                        {
                            Report.WriteLine("Value from excel" + Exccontent + "is matching with UI value");
                            UIcolumn++;
                        }
                        else if (UIcolumn == 8)
                        {
                            UIcolumn++; // Due Date skip from UI
                            j--;
                        }
                        else if (UIcolumn == 5)
                        {
                            UIcolumn--; //Customer Number & Name
                            j--;
                        }
                        else
                        {
                            Assert.Fail();
                        }
                    }
                }
            }
            else
            {
                Assert.Fail();
            }

            DeleteFilesFromFolder(downloadpath);
        }

    }
}
