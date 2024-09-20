using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System;
using TechTalk.SpecFlow;
using CRM.UITest.Objects;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.IO;
using CRM.UITest.CommonMethods;

namespace CRM.UITest.Scripts.Tracking
{
    [Binding]
    public class TrackingpageUploadShipmentTrackingTemplateSteps :ObjectRepository

    {
 
        [Given(@"I click on tracking module")]
        public void GivenIClickOnTrackingModule()
        {
            Report.WriteLine("click on tracking icon from left navigation wizard");
            Click(attributeName_xpath, trackingicon);
         }
        
        [When(@"I will be navigated to ""(.*)""")]
        public void WhenIWillBeNavigatedTo(string trackingpage)
        {
            Report.WriteLine("Navigated to tracking page");
            string expheader = Gettext(attributeName_xpath, trackingheader);
            Assert.AreEqual(expheader, trackingpage);
        }
        
        [When(@"I click on upload button")]
        public void WhenIClickOnUploadButton()
        {
            Report.WriteLine("Click On Upload Button");
            Click(attributeName_id, TrackingPage_UploadTemplate_id);            
        }
        
        [When(@"I displayed with upload modal")]
        public void WhenIDisplayedWithUploadModal()
        {
            Report.WriteLine("Upload modal displayed");
            VerifyElementPresent(attributeName_xpath, trackinguploadmodal, "uploadmodal");
        }
        
        [When(@"I click on cancel button")]
        public void WhenIClickOnCancelButton()
        {
            Report.WriteLine("Click on cancel button");
            Click(attributeName_xpath, trackingcancelbutton);
        }
        
        [When(@"I click on submit button")]
        public void WhenIClickOnSubmitButton()
        {
            Report.WriteLine("Click on submit button");            
            Click(attributeName_xpath, trackingsubmitbutton);
        }
        
        [When(@"I click on download button")]
        public void WhenIClickOnDownloadButton()
        {
            Report.WriteLine("Click on download button");
            Click(attributeName_xpath, trackingdownloadbutton);
        }
        
        [When(@"I attached the template from ""(.*)""")]
        public void WhenIAttachedTheTemplateFrom(string path)
        {
            Report.WriteLine("i upladed file");
            WaitForElementVisible(attributeName_xpath, trackingselectfile, "file");
            VerifyElementPresent(attributeName_xpath, trackingselectfile, "file");
            DefineTimeOut(180000);
            string filepath = Path.GetFullPath(path);
            //GlobalVariables.webDriver.WaitForPageLoad();            
            FileUpload(attributeName_xpath, trackingselectfile, filepath);                
        }
        [Then(@"I will be displayed with Track Multiple Shipments by File Upload area with the all fields")]
        public void ThenIWillBeDisplayedWithTrackMultipleShipmentsByFileUploadAreaWithTheAllFields()
        {
            Report.WriteLine("i am displayed with File Upload area ");
            VerifyElementVisible(attributeName_xpath, trackinguploadarea, "uploadarea");
            VerifyElementVisible(attributeName_xpath, trackinguploadsubheader, "uploadsubheader");
            VerifyElementVisible(attributeName_xpath, trackingdownloadbutton, "uploadbutton");
            VerifyElementVisible(attributeName_xpath, trackingdownloadbutton, "downloadbutton");
           
        }
        
        [Then(@"I should not be displayed with Track Multiple Shipments by File Upload area with the all fields")]
        public void ThenIShouldNotBeDisplayedWithTrackMultipleShipmentsByFileUploadAreaWithTheAllFields()
        {
            Report.WriteLine("i am not displaying with File Upload area ");
            VerifyElementNotVisible(attributeName_xpath, trackinguploadarea, "uploadarea");
            VerifyElementNotVisible(attributeName_xpath, trackinguploadsubheader, "uploadsubheader");
            VerifyElementNotVisible(attributeName_xpath, trackingdownloadbutton, "uploadbutton");
            VerifyElementNotVisible(attributeName_xpath, trackingdownloadbutton, "downloadbutton");
        }
        
        [Then(@"I should display with the upload shipments modal")]
        public void ThenIShouldDisplayWithTheUploadShipmentsModal()
        {
            Report.WriteLine("i am not displaying with File Upload area ");
            Thread.Sleep(300);
            VerifyElementPresent(attributeName_xpath, trackinguploadmodal, "modal");

        }
        
        [Then(@"I should be displayed ""(.*)"" Upload Shipments")]
        public void ThenIShouldBeDisplayedUploadShipments(string header)
        {
            Report.WriteLine("i displayed the header");
            string observed = Gettext(attributeName_xpath, trackinguploadmodalheader);
            Assert.AreEqual(header, observed);
        }
        


        [Then(@"I should be displayed ""(.*)"" Select an Excel file to track up to (.*) shipments")]
        public void ThenIShouldBeDisplayedSelectAnExcelFileToTrackUpToShipments(string p0, int p1)
        {
            Report.WriteLine("i displayed the subheader");
            string expected = "Select an Excel file to track up to 25 shipments";
            Thread.Sleep(300);
            string observed = Gettext(attributeName_xpath, trackinguploadmodalsubheader);
            Assert.AreEqual(expected, observed);
        }
        
        [Then(@"I should be display with ""(.*)"" no file Selected")]
        public void ThenIShouldBeDisplayWithNoFileSelected(string label)
        {
            Report.WriteLine("i displayed the label");
            WaitForElementVisible(attributeName_xpath, trackinguploadmodalnofilelabel, "label");
            string observed = Gettext(attributeName_xpath, trackinguploadmodalnofilelabel);
            Assert.AreEqual(label, observed);
        }
        
        [Then(@"I should be displayed with option to select file")]
        public void ThenIShouldBeDisplayedWithOptionToSelectFile()
        {
            Report.WriteLine("i have option to select file");
            VerifyElementVisible(attributeName_xpath, trackingselectfile, "select file");
        }

        [Then(@"I should be display with label no file Selected ""(.*)""")]
        public void ThenIShouldBeDisplayWithLabelNoFileSelected(string label)
        {
            Report.WriteLine("i have displyed with select file label");
            WaitForElementVisible(attributeName_xpath, trackinguploadedfilename,"error");
            string actuallabel = Gettext(attributeName_xpath, trackinguploadedfilename);
            Assert.AreEqual(actuallabel, label);
        }


        [Then(@"I should have option to cancel")]
        public void ThenIShouldHaveOptionToCancel()
        {
            Report.WriteLine("i have the cancel button" );
            VerifyElementVisible(attributeName_xpath, trackingcancelbutton,"cancelbutton");
        }
        
        [Then(@"I should have option to submit")]
        public void ThenIShouldHaveOptionToSubmit()
        {
            Report.WriteLine("i have the submit button");
            VerifyElementVisible(attributeName_xpath, trackingsubmitbutton, "cancelbutton");
        }
        
        [Then(@"upload modal should be closed")]
        public void ThenUploadModalShouldBeClosed()
        {
            Report.WriteLine("upload modal will be closed");
			WaitForElementNotVisible(attributeName_xpath, trackinguploadmodal, "uploadmodal");
            VerifyElementNotVisible(attributeName_xpath, trackinguploadmodal, "uploadmodal");
        }
        
        [Then(@"I should be displayed with ""(.*)"" PLEASE SELECT THE FILE")]
        public void ThenIShouldBeDisplayedWithPLEASESELECTTHEFILE(string errormessage)
        {
            Report.WriteLine("upload modal will be closed");
            WaitForElementPresent(attributeName_xpath, trackingselectfilerrorpoup, "errormodal");
            Thread.Sleep(400);
            string observed = Gettext(attributeName_xpath, trackingselectfilerrormessage);
            Assert.AreEqual(errormessage, observed);
            
        }
  
        [Then(@"I should be able to upload the document")]
        public void ThenIShouldBeAbleToUploadTheDocument()
        {
            Report.WriteLine("file has uploaded");
            string expected = "ShipmentTrackingTemplate.xlsx";
            WaitForElementPresent(attributeName_xpath, trackinguploadedfilename, "filename");
            VerifyElementVisible(attributeName_xpath, trackinguploadedfilename, "filename");
            string actual = Gettext(attributeName_xpath, trackinguploadedfilename);
            Assert.AreEqual(expected, actual);
            
                
        }
        
        [Then(@"I should navigate to tracking details screen")]
        public void ThenIShouldNavigateToTrackingDetailsScreen()
        {
            Report.WriteLine("i navigated to tracking details screen");
            Thread.Sleep(300);
            string expectedheader = "Tracking";
            string observedheader = Gettext(attributeName_xpath, TrackingPage_Header_xpath);
            Assert.AreEqual(expectedheader, observedheader);
            string expectedsubheader = "The tracking information you requested is displayed below.";
            string observedsubheader = Gettext(attributeName_xpath, TrackingPage_sebHeader_xpath);
            Assert.AreEqual(expectedsubheader, observedsubheader);
        }
        [Then(@"I should see the results of tracking numbers for '(.*)'")]
        public void ThenIShouldSeeTheResultsOfTrackingNumbersFor(string uploadedfilepath)
        {
            IList<IWebElement> trackingresults = GlobalVariables.webDriver.FindElements(By.XPath(trackingrefernceresults));
            List<string> trackingresultsvalues = IndividualColumnData(trackingrefernceresults);
            trackingresultsvalues.RemoveAll(string.IsNullOrEmpty);
            List<string> rowValue = new List<string> { };
            Excel.Application xlApp = new Excel.Application();
            string filepath = Path.GetFullPath(uploadedfilepath);
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(filepath);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;
            int rowCount = xlRange.Rows.Count;
            int rowvaluecount = (rowCount - 4);
            int uicount = trackingresults.Count;
            int uivaluecount = (uicount / 2);
            Assert.AreEqual(rowvaluecount, uivaluecount);
            List<string> rowValues = new List<string> { };

            for (int i = 5; i <= rowCount; i++)
            {
                
              rowValues.Add(xlRange.Cells[i,1].Value2.ToString());
                

            }

            for (int i = 0; i < uivaluecount; i++)
            {
                int index = trackingresultsvalues[i].IndexOf(" ");
                string value = trackingresultsvalues[i].Substring(0, index);

                if (rowValues.Contains(value))
                {
                    Report.WriteLine("Entered Reference values contains invalid tracking numbers displaying in warning popup");
                }
                else
                {
                    throw new System.Exception("Entered Reference values doesnot contains invalid tracking numbers displaying in warning popup");
                }
            }


        }


        [Then(@"I should be display with ""(.*)"" invalidinput message popup")]
        public void ThenIShouldBeDisplayWithInvalidinputMessagePopup(string errorforinvalidname)
        {
            Report.WriteLine("DisplayWithInvalidinputMessagePopup");
            VerifyElementVisible(attributeName_xpath, trackingerrorforinavlidname, "error");
            string experrorforinavlidfilename = Gettext(attributeName_xpath, trackingerrorforinavlidname);
            Assert.AreEqual(errorforinvalidname, experrorforinavlidfilename);
        }

        
        [Then(@"I should be able to see the ""(.*)"" saying there are no tracking numbers")]
        public void ThenIShouldBeAbleToSeeTheSayingThereAreNoTrackingNumbers(string errormessage)
        {
            Report.WriteLine("ThereAreNoTrackingNumbers");
            VerifyElementVisible(attributeName_xpath, trackingpopupforemptyfile, "error");
            string actualerrorforemptyfile = Gettext(attributeName_xpath, trackingpopupforemptyfile);
            Assert.AreEqual(actualerrorforemptyfile, errormessage);
        }
        [Then(@"I should be displayed with '(.*)' for invalid tracking numbers and results for valid refrences ""(.*)""")]
        public void ThenIShouldBeDisplayedWithForInvalidTrackingNumbersAndResultsForValidRefrences(string errormessage, string path)
        {
            Report.WriteLine("IShouldBeDisplayedWithForInvalidTrackingNumbersAndResultsForValidRefrences");
            WaitForElementPresent(attributeName_xpath, TrackingWarningRefNo_xpath, "error");
            string invalidlist = Gettext(attributeName_xpath, trackingresultslistforinvalid);
            invalidlist = invalidlist.Replace("Tracking", "");
            invalidlist = invalidlist.Replace("details", "");
            invalidlist = invalidlist.Replace("were", "");
            invalidlist = invalidlist.Replace("not", "");
            invalidlist = invalidlist.Replace("found", "");
            invalidlist = invalidlist.Replace("for", "");
            invalidlist = invalidlist.Replace("the", "");
            invalidlist = invalidlist.Replace("following", "");
            invalidlist = invalidlist.Replace("tracking", "");
            invalidlist = invalidlist.Replace("numbers", "");
            string text = invalidlist.Replace("\r\n", " ");
            string[] invalidnumber = text.TrimStart(' ').Split(' ');
            int invalidnumberscount = invalidnumber.Count();
            Report.WriteLine("enetered invalidrefernces:" + invalidnumberscount );
            Excel.Application xlApp = new Excel.Application();
            string filepath = Path.GetFullPath(path);
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(filepath);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;
            int rowCount = xlRange.Rows.Count - 4;
            int validnumbers = rowCount - invalidnumberscount;
            Click(attributeName_xpath, TrackingWarningpopupClose_xpath);
            IList<IWebElement> trackingresults = GlobalVariables.webDriver.FindElements(By.XPath(trackingrefernceresults));
            int validcountuicount = trackingresults.Count / 2;
            Assert.AreEqual(validcountuicount, validnumbers);
            Report.WriteLine("Results showed for valid refernces");
        }

        [Then(@"I click on the close button of error popup")]
        public void ThenIClickOnTheCloseButtonOfErrorPopup()
        {
            Report.WriteLine("Click On The Close Button");
            Click(attributeName_xpath, trackingwarningpopupclosebutton);
        }

        [Then(@"I should display with the error poup for more than maximum ""(.*)""")]
        public void ThenIShouldDisplayWithTheErrorPoupForMoreThanMaximum(string messageformax)
        {
            Report.WriteLine("Error Poup For More Than Maximum");
            WaitForElementPresent(attributeName_xpath, trackingerrormessageformaxnumber,"element");
            string actualmxamessage = Gettext(attributeName_xpath, trackingerrormessageformaxnumber);
            Assert.AreEqual(actualmxamessage, messageformax);
        }
        [Then(@"I should display with '(.*)' popup for all invaliddata")]
        public void ThenIShouldDisplayWithPopupForAllInvaliddata(string errorforallinvalid)
        {
            Report.WriteLine("Error Poup For invaliddta");
            WaitForElementPresent(attributeName_xpath, trackingerrorforallinvalid, "error");
            Thread.Sleep(300);
            string actualerrorforallinvalid = Gettext(attributeName_xpath, trackingerrorforallinvalid);
            Assert.AreEqual(actualerrorforallinvalid, errorforallinvalid);
        }

        [Then(@"I click on close button of error popup for invalid tracking numbers combination")]
        public void ThenIClickOnCloseButtonOfErrorPopupForInvalidTrackingNumbersCombination()
        {
            Report.WriteLine("Click On Close ButtonOf ErrorPopup ForInvalid TrackingNumbers");
            Click(attributeName_xpath, trackingresultslistforinvalid);
        }
                 


    }
}
