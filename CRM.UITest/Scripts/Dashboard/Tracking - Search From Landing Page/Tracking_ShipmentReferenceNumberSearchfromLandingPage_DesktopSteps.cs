using System;
using System.Linq;
using System.Threading;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Reflection;

namespace CRM.UITest.Scripts.Quote.LTL
{
    [Binding]
    public class Tracking_ShipmentReferenceNumberSearchfromLandingPage_DesktopSteps:ObjectRepository
    {
        
        [Given(@"I enter the tracking numbers '(.*)'")]
        public void GivenIEnterTheTrackingNumbers(string EnterReferenceNumberText)
        {
            Report.WriteLine("I enter the Tracking numbers");
            Click(attributeName_id, searchbox_id);
            SendKeys(attributeName_id, searchbox_id, EnterReferenceNumberText);
        }
        
        [When(@"I have not entered the '(.*)' values in the search box")]
        public void WhenIHaveNotEnteredTheValuesInTheSearchBox(string EnterReferenceNumberText)
        {
            Report.WriteLine("I have not passed any value in the tracking search box");
            Click(attributeName_id, searchbox_id);
            SendKeys(attributeName_id, searchbox_id, EnterReferenceNumberText);
        }
        
        [When(@"I click on Search arrow")]
        public void WhenIClickOnSearchArrow()
        {
            Report.WriteLine("Click on search arrow");
            Click(attributeName_xpath, TrackingsearchArrow_xpath);        
        }
        
        [When(@"I pass the '(.*)' values in the search box")]
        public void WhenIPassTheValuesInTheSearchBox(string EnterReferenceNumberText)
        {
            Report.WriteLine("I have entered multiple invalid reference numbers");
            SendKeys(attributeName_id, searchbox_id, EnterReferenceNumberText);
        }
        
        [When(@"I enter the '(.*)' values in the search box")]
        public void WhenIEnterTheValuesInTheSearchBox(string EnterReferenceNumberText)
        {
            Report.WriteLine("I have entered combination of both valid and invalid numbers");
            SendKeys(attributeName_id, searchbox_id, EnterReferenceNumberText);
        }
        
        [When(@"I click on upload button of track multiple shipments by file upload")]
        public void WhenIClickOnUploadButtonOfTrackMultipleShipmentsByFileUpload()
        {
            Report.WriteLine("I Click on Upload button on landing page");
            Click(attributeName_id, UploadBtn_id);
        }

        [When(@"I should be displayed with upload modal")]
        public void WhenIShouldBeDisplayedWithUploadModal()
        {
            Report.WriteLine("I should be displayed with upload shipment modal pop up");
            VerifyElementVisible(attributeName_xpath, UploadShipmentpopupTitle_xpath, "Upload Shipments");
        }

        [When(@"I click select file of the Upload Shipment modal")]
        public void WhenIClickSelectFileOfTheUploadShipmentModal()
        {
            Report.WriteLine("click select file button in the Upload Shipment modal");
            Thread.Sleep(3000);
            Click(attributeName_xpath, SelectFileUploadpopup_xpath);
            Thread.Sleep(3000);
        }


        [When(@"User can able to select a valid file through file explorer""(.*)""")]
        public void WhenUserCanAbleToSelectAValidFileThroughFileExplorer(string path)
        {
            Report.WriteLine("I uploaded the file");
            VerifyElementPresent(attributeName_xpath, trackingselectfile, "a;");
            Thread.Sleep(3000);
            FileUpload(attributeName_xpath, trackingselectfile, path);
            Thread.Sleep(3000);
        }

        [When(@"I verify the entered tracking numbers searchbox")]
        public void WhenIVerifyTheEnteredTrackingNumbersSearchbox()
        {
            Report.WriteLine("Get the tracking numbers entered in the search box");
            string expectedvalues=GetValue(attributeName_id, searchbox_id, "value");            
        }

        [Then(@"I should be able to enter only ten tracking reference numbers '(.*)'")]
        public void ThenIShouldBeAbleToEnterOnlyTenTrackingReferenceNumbers(string EnterReferenceNumberText)
        {
            Report.WriteLine("Should be displayed with only 10 tracking numbers");
            string expectedvalues = GetValue(attributeName_id, searchbox_id, "value");
            Assert.AreNotEqual(expectedvalues, EnterReferenceNumberText);
            Report.WriteLine("Entered tracking numbers and displaying tracking numbers in the application are not same");
        }

        [Then(@"I should be displayed with the '(.*)' message in the pop up")]
        public void ThenIShouldBeDisplayedWithTheMessageInThePopUp(string warningmsg)
        {
            Report.WriteLine("Warning message should be displayed in the pop up");
            VerifyElementVisible(attributeName_xpath, TrackingWarningheader_xpath, "Warning");
            String ActualWarningmsg = Gettext(attributeName_xpath, TrackingWarningmsg_xpath);
            if (ActualWarningmsg.Contains(warningmsg))
            {
                Report.WriteLine("Error message displayed in warning pop up");
            }
            else
            {
                throw new System.Exception("Error message not displayed in warning pop up");
            }           

        }

        [Then(@"I see the '(.*)' message in the pop up")]
        public void ThenISeeTheMessageInThePopUp(string Errormsg)
        {
            Report.WriteLine("I displayed with an error message in the Error modal pop up");
            Thread.Sleep(1000);
            String ActualErrormsg = Gettext(attributeName_xpath, Errorpopupmsg_xpath);
            Assert.AreEqual(Errormsg, ActualErrormsg);            
        }

        [Then(@"I can see the '(.*)' message in the pop up for entering invalid numbers")]
        public void ThenICanSeeTheMessageInThePopUpForEnteringInvalidNumbers(string Errormsg_invalid)
        {
            Report.WriteLine("I displayed with an error message in the modal pop up");
            Thread.Sleep(1000);
            String ActualErrormsg = Gettext(attributeName_xpath, TrackingErrormsg_xpath);
            Assert.AreEqual(Errormsg_invalid, ActualErrormsg);
        }

        [Then(@"I navigate to '(.*)' Details page")]
        public void ThenINavigateToDetailsPage(string Tracking)
        {
            Report.WriteLine("I am navigating to Tracking Page");
            string TrackingPageHeader_UI = Gettext(attributeName_xpath, TrackingPageHearder_xpath);            
            Assert.AreEqual(Tracking, TrackingPageHeader_UI);
        }

        [Then(@"I see the results for the entered single reference number '(.*)'")]
        public void ThenISeeTheResultsForTheEnteredSingleReferenceNumber(string Refno)
        {
            Report.WriteLine("Results are displaying for the entered single reference number");
            string TrackingRefResults = Gettext(attributeName_xpath, TrackingRefno_xpath);
            string[] Trackingnoactual = TrackingRefResults.Split(' ');
            string actualRefno = Trackingnoactual[0];
            Assert.AreEqual(Refno, actualRefno);
        }

        [Then(@"I see the results for the entered reference numbers '(.*)'")]
        public void ThenISeeTheResultsForTheEnteredReferenceNumbers(string Ref)
        {
            Report.WriteLine("Results are displaying for the entered reference number");
            List<string> TrackingNumber_UI = IndividualColumnData(TrackingRefno_xpath);

            string[] valuesexp = Ref.Split(',');

            for (int i = 0; i < TrackingNumber_UI.Count; i++)
            {
                int index = TrackingNumber_UI[i].IndexOf(" ");
                string value = TrackingNumber_UI[i].Substring(0, index);
                
                if(valuesexp.Contains(value))
                {
                    Report.WriteLine("Entered Reference value and Reference value appearing in the Results are same");
                }
                else
                {
                    throw new System.Exception("Entered Reference value and Reference value appearing in the Results are not same");
                }
              
            }            

        }

        [Then(@"Pop up displays all the list of tracking numbers that not exist '(.*)'")]
        public void ThenPopUpDisplaysAllTheListOfTrackingNumbersThatNotExist(string EnterReferenceNumberText)
        {
            Report.WriteLine("Pop up display list of non existing tracking numbers");

            string[] Expreferencenumbers = EnterReferenceNumberText.Split(',');
            
            string b = Gettext(attributeName_xpath, TrackingWarningRefNo_xpath);
            b = b.Replace("Tracking", "");
            b = b.Replace("details", "");
            b = b.Replace("were", "");
            b = b.Replace("not", "");
            b = b.Replace("found", "");
            b = b.Replace("for", "");
            b = b.Replace("the", "");
            b = b.Replace("following", "");
            b = b.Replace("tracking", "");
            b = b.Replace("numbers", "");
            string text = b.Replace("\r\n", " ");
            string[] starray = text.TrimStart(' ').Split(' ');
            foreach (string s in starray)
            {
                if (Expreferencenumbers.Contains(s))
                {
                    Report.WriteLine("Entered Reference values contains invalid tracking numbers displaying in warning popup");
                }
                else
                {
                    throw new System.Exception("Entered Reference values doesnot contains invalid tracking numbers displaying in warning popup");
                }

            }
        }
        
        [Then(@"I click on close button in the pop up")]
        public void ThenIClickOnCloseButtonInThePopUp()
        {            
            Report.WriteLine("Click on Close button of error message pop up");
            Click(attributeName_xpath, TrackingErrorpopupclose_xpath);
            Thread.Sleep(1000);
        }

        [Then(@"I clicked on close button in the warning pop up")]
        public void ThenIClickedOnCloseButtonInTheWarningPopUp()
        {
            Report.WriteLine("Click on Close button of warning message pop up");
            Click(attributeName_xpath, TrackingWarningpopupClose_xpath);
        }

        [Then(@"I should be displayed with Tracking search")]
        public void ThenIShouldBeDisplayedWithTrackingSearch()
        {
            Report.WriteLine("Tracking Search box should be displayed");
            VerifyElementVisible(attributeName_id, searchbox_id, "EnterReferenceNumberText");
        }

        [Then(@"I see list of Tracking Results based on the entered valid numbers '(.*)'")]
        public void ThenISeeListOfTrackingResultsBasedOnTheEnteredValidNumbers(string Ref)
        {
            Report.WriteLine("Tracking numbers list should be displayed for the valid Tracking reference numbers");
            List<string> TrackingNumber_UI = IndividualColumnData(TrackingRefno_xpath);

            string[] valuesexp = Ref.Split(',');

            for (int i = 0; i < TrackingNumber_UI.Count; i++)
            {
                int index = TrackingNumber_UI[i].IndexOf(" ");
                string value = TrackingNumber_UI[i].Substring(0, index);

                if (valuesexp.Contains(value))
                {
                    Report.WriteLine("Entered valid Reference numbers are displaying in the results");
                }
                else
                {
                    throw new System.Exception("Entered valid Reference numbers are not displaying in the results");
                }

            }

        }

        [Then(@"Navigation menu have only Tracking icon on left wizard")]
        public void ThenNavigationMenuHaveOnlyTrackingIconOnLeftWizard()
        {
            Report.WriteLine("Only Tracking icon displaying on the left wizard");
            Thread.Sleep(1000);
            VerifyElementVisible(attributeName_xpath, Trackingiconhomepage_xpath, "Tracking");
        }
        
        [Then(@"I should not display with any other icons on left wizard")]
        public void ThenIShouldNotDisplayWithAnyOtherIconsOnLeftWizard()
        {
            Report.WriteLine("Other icons should not be displayed");
            VerifyElementNotPresent(attributeName_xpath, Dashboard_home_xpath, "Dashboard");
            VerifyElementNotPresent(attributeName_xpath, Quotes_home_xpath, "Quotes");
            VerifyElementNotPresent(attributeName_xpath, Shipment_home_xpath, "Shipments");
            VerifyElementNotPresent(attributeName_xpath, DocumentRepo_home_xpath, "Document Repository");
            VerifyElementNotPresent(attributeName_xpath, UserManagement_home_xpath, "User Management");
        }

        [When(@"I click on upload button from homepage")]
        public void WhenIClickOnUploadButtonFromHomepage()
        {
            Report.WriteLine("Click On Upload Button");
            Click(attributeName_id, UploadBtn_id);
            Thread.Sleep(300);
        }

        [When(@"I have attached the template using ""(.*)""")]
        public void WhenIHaveAttachedTheTemplateUsing(string path)
        {
            Report.WriteLine("I uploaded file");
            VerifyElementPresent(attributeName_xpath, Trackingselectfile_xpath, "a;");
            Thread.Sleep(3000);


			string currentDirPath = Environment.CurrentDirectory;
			DirectoryInfo dirParent = Directory.GetParent(currentDirPath);
			string dirParentpath = dirParent.ToString();
			DirectoryInfo soluParent = Directory.GetParent(dirParentpath);
			string soluParentpath = soluParent.ToString();
			string filepath = "\\Scripts\\TestData\\Testfiles_trackingupload" + path;
			string relativePath = soluParentpath + filepath;
            FileUpload(attributeName_xpath, Trackingselectfile_xpath, relativePath);
            Thread.Sleep(3000);
        }
        [When(@"I click on submit button from landing page")]
        public void WhenIClickOnSubmitButtonFromLandingPage()
        {
            Report.WriteLine("Click on submit button");
            //Thread.Sleep(3000);
            Click(attributeName_xpath, trackingsubmitbutton);
            //Thread.Sleep(3000);
        }

        [Then(@"Ishould bedisplaying with '(.*)' popup for all invaliddata")]
        public void ThenIShouldBeDisplayingWithPopupForAllInvaliddata(string errormsgforallinvalid)
        {
            Report.WriteLine("Error message for all invalid data should be displayed");
            Thread.Sleep(1000);
            string actualerrorforallinvalid = Gettext(attributeName_xpath, trackingwarningmessageforinvalid);
            Assert.AreEqual(errormsgforallinvalid,actualerrorforallinvalid);
        }

        [Then(@"I should navigate to tracking details screen for uploadedfile")]
        public void ThenIShouldNavigateToTrackingDetailsScreenForUploadedfile()
        {
            Report.WriteLine("I navigated to tracking details screen");
            string expectedheader = "Tracking";
            string observedheader = Gettext(attributeName_xpath, TrackingPage_Header_xpath);
            Assert.AreEqual(expectedheader, observedheader);
            
        }

        [Then(@"Ishould be able to see the results of tracking numbers for '(.*)'")]
        public void ThenIShouldBeAbleToSeeTheResultsOfTrackingNumbersFor(string path)
        {
            IList<IWebElement> trackingresults = GlobalVariables.webDriver.FindElements(By.XPath(TrackingRefno_xpath));
            List<string> trackingresultsvalues = IndividualColumnData(TrackingRefno_xpath);
            string FilePath = Path.GetFullPath(path);
            trackingresultsvalues.RemoveAll(string.IsNullOrEmpty);
            List<string> rowValue = new List<string> { };
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(FilePath);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;
            int rowCount = xlRange.Rows.Count;
            int rowvaluecount = (rowCount - 4);
            int uicount = trackingresults.Count;            
            Thread.Sleep(1000);
            Assert.AreEqual(rowvaluecount, uicount);
            List<string> rowValues = new List<string> { };

            for (int i = 5; i <= rowCount; i++)
            {
                rowValues.Add(xlRange.Cells[i, 1].Value2.ToString());
            }

            for (int i = 0; i < uicount; i++)
            {
                int index = trackingresultsvalues[i].IndexOf(" ");
                string value = trackingresultsvalues[i].Substring(0, index);

                if (rowValues.Contains(value))
                {
                    Report.WriteLine("Entered Reference values are valid tracking numbers");
                }
                else
                {
                    throw new System.Exception("Entered Reference values doesnot contains valid tracking numbers");
                }
            }

        }


        [Then(@"I should be displayed with the ""(.*)""")]
        public void ThenIShouldBeDisplayedWithThe(string Errormsg)
        {
            Report.WriteLine("Error message should be displayed");
            Thread.Sleep(1000);
            string actualerrorforemptyfile = Gettext(attributeName_xpath, TrackingErrormsg_xpath);
            Assert.AreEqual(actualerrorforemptyfile, Errormsg);
        }

        [Then(@"I should be displayed with '(.*)' for invalid tracking numbers and results for valid refrences ""(.*)"" from homepage upload")]
        public void ThenIShouldBeDisplayedWithForInvalidTrackingNumbersAndResultsForValidRefrencesFromHomepageUpload(string warningmessage, string path)
        {
            Report.WriteLine("I should be displayed with invalid tracking numbers in the warning pop up");
            WaitForElementVisible(attributeName_xpath, TrackingWarningRefNo_xpath, "error");
            string FilePath = Path.GetFullPath("../../Scripts/TestData/Testfiles_trackingupload");
            string invalidlist = Gettext(attributeName_xpath, TrackingWarningRefNo_xpath);
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
            Report.WriteLine("enetered invalidrefernces:" + invalidnumberscount);
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(FilePath+path);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;
            int rowCount = xlRange.Rows.Count - 4;
            int validnumbers = rowCount - invalidnumberscount;
            Thread.Sleep(1000);
            Click(attributeName_xpath, TrackingWarningpopupClose_xpath);
            IList<string> trackingresults = IndividualColumnData(TrackingRefno_xpath);
            for (int i = 0; i < trackingresults.Count; i++)
            {
                int index = trackingresults[i].IndexOf(" ");
                string value = trackingresults[i].Substring(0, index);

            }
                int validcountuicount = trackingresults.Count;
            Assert.AreEqual(validcountuicount, validnumbers);
            Report.WriteLine("Results are displaying for valid tracking refernces");            
        }

        [Then(@"I should be displayed with the error poup for more than maximum ""(.*)""")]
        public void ThenIShouldBeDisplayedWithTheErrorPoupForMoreThanMaximum(string messageformaxnumbers)
        {
            Report.WriteLine("Error message should be displayed for more than 25 numbers in the uploaded template");
            Thread.Sleep(1000);
            string actualmxamessage = Gettext(attributeName_xpath, TrackingErrormsg_xpath);
            Assert.AreEqual(actualmxamessage, messageformaxnumbers);
        }
    }
}
