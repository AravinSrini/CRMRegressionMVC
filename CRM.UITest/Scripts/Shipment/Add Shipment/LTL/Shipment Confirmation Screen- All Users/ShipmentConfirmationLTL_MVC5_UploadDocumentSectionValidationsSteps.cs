using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Confirmation_Screen__All_Users
{
    [Binding]
    public class ShipmentConfirmationLTL_MVC5_UploadDocumentSectionValidationsSteps : AddShipments
    {
        [When(@"I am uploading the invalid file (.*)")]
        public void WhenIAmUploadingTheInvalidFile(string invalidfilepath)
        {
            Report.WriteLine("uploading mp3 file format");
            string filepath = Path.GetFullPath(invalidfilepath);
            FileUpload(attributeName_xpath, confirmation_uploaddocumentsection, filepath);
        }

        [When(@"I upload the invalid file with name conatins more than the limit (.*)")]
        public void WhenIUploadTheInvalidFileWithNameConatinsMoreThanTheLimit(string invalidfilepath)
        {
            Report.WriteLine("Uploading more than 70 charatcers file name");
            string filepath = Path.GetFullPath(invalidfilepath);
            FileUpload(attributeName_xpath, confirmation_uploaddocumentsection, filepath);
        }

        [When(@"I tried to upload the invalid file with the limit of more than ten MB (.*)")]
        public void WhenITriedToUploadTheInvalidFileWithTheLimitOfMoreThanTenMB(string invalidfilepath)
        {
            Report.WriteLine("Uploading file more than 10MB");
            string filepath = Path.GetFullPath(invalidfilepath);
            FileUpload(attributeName_xpath, confirmation_uploaddocumentsection, filepath);
        }

        [When(@"I am uploading valid file (.*)")]
        public void WhenIAmUploadingValidFile(string validfilepath)
        {
            Report.WriteLine("Uploading file");
            string filepath = Path.GetFullPath(validfilepath);
            FileUpload(attributeName_xpath, confirmation_uploaddocumentsection, filepath);
        }

        [When(@"I am uploading valid files more than the limit (.*)")]
        public void WhenIAmUploadingValidFilesMoreThanTheLimit(string files)
        {
            string[] path = files.Split(',');
            Report.WriteLine("Uploading file");
            for (int i = 0; i <= 10; i++)
            {
                string filepath = Path.GetFullPath("../../Scripts/TestData/Testfiles_confirmationupload/" + path[i]);
                FileUpload(attributeName_xpath, ConfrimationFileUpload_Xpath, filepath);
                Thread.Sleep(15000);
            }
        }

        [When(@"I upload the valid file (.*)")]
        public void WhenIUploadTheValidFile(string validfilepath)
        {
            Report.WriteLine("Upload valid file");
            string filepath = Path.GetFullPath(validfilepath);
            FileUpload(attributeName_xpath, confirmation_uploaddocumentsection, filepath);
        }

        [When(@"Again i am trying to upload the same file with same name in CRM (.*)")]
        public void WhenAgainIAmTryingToUploadTheSameFileWithSameNameInCRM(string validfilepath)
        {
            Report.WriteLine("Upload duplicate file");
            Thread.Sleep(4000);
            string filepath = Path.GetFullPath(validfilepath);
            FileUpload(attributeName_xpath, confirmation_uploaddocumentsection, filepath);
        }

        [Then(@"I should be displayed with an error message")]
        public void ThenIShouldBeDisplayedWithAnErrorMessage()
        {
            Report.WriteLine("Error message should be displayed in Error popup");
            WaitForElementVisible(attributeName_xpath, FileUploadErrorpopupheader_Xpath, "Error");
            VerifyElementVisible(attributeName_xpath, FileUploadErrorpopupheader_Xpath, "Error");
            string ErrorMsg_UI = Gettext(attributeName_xpath, FileUploadErrorMsg_Xpath);

            string verbiage = "The following file(s) cannot be uploaded. ";
            string verbiage1 = "Documents must be less than 10MB (file size), ";
            string verbiage2 = "less than 70 characters(file length), and one if ";
            string verbiage3 = "the following file types : .jpg, .jpeg, .png, .csv, ";
            string verbiage4 = ".pdf, .doc, .docx, .xls, .xlsx(file type)";

            if (ErrorMsg_UI.Contains(verbiage) && ErrorMsg_UI.Contains(verbiage1) && ErrorMsg_UI.Contains(verbiage2) && ErrorMsg_UI.Contains(verbiage3) && ErrorMsg_UI.Contains(verbiage4))
            {
                Report.WriteLine("Error pop up Verbiage displaying in UI is matching");
            }
            else
            {
                throw new System.Exception("Error pop up verbiage not matching");
            }
            Thread.Sleep(2000);
            Click(attributeName_xpath, FileUploadpopupClose_Xpath);
        }

        [Then(@"the file should not get uploaded")]
        public void ThenTheFileShouldNotGetUploaded()
        {
            Report.WriteLine("File not get uploaded");
            VerifyElementNotPresent(attributeName_xpath, FirstSavedFile_SavedBtn_Xpath, "Saved");
        }

        [Then(@"files should get uploaded (.*)")]
        public void ThenFilesShouldGetUploaded(string filename)
        {
            Report.WriteLine("Files successfully uploaded");
            Thread.Sleep(3000);
            WaitForElementVisible(attributeName_xpath, FirstSavedFile_Xpath, filename);
            VerifyElementPresent(attributeName_xpath, FirstSavedFile_Xpath, filename);
            VerifyElementPresent(attributeName_xpath, FirstSavedFile_SavedBtn_Xpath, "Saved");
            VerifyElementPresent(attributeName_xpath, FirstSavedFile_RemoveBtn_Xpath, "Remove");
        }

        [Then(@"remove uploaded file (.*)")]
        public void ThenRemoveUploadedFile(string filename)
        {
            Report.WriteLine("Remove the uploaded file");
            Thread.Sleep(3000);
            Click(attributeName_xpath, FirstSavedFile_RemoveBtn_Xpath);
        }

        [Then(@"I should be displayed with an error message of Maximum file limit")]
        public void ThenIShouldBeDisplayedWithAnErrorMessageOfMaximumFileLimit()
        {
            Report.WriteLine("Error message should be displayed for more than 10 files");
            string ErrorMsg_Maxlimit_UI = Gettext(attributeName_xpath, FileUploadErrorMsg_Xpath);

            string ErrorMsg_Maxlimit = "File(s) cannot be uploaded as they exceed the maximum file limit of 10 files.";
            if (ErrorMsg_Maxlimit_UI.Contains(ErrorMsg_Maxlimit))
            {
                Report.WriteLine("Error pop up Verbiage displaying in UI is matching");
            }
            else
            {
                throw new System.Exception("Error pop up verbiage not matching");
            }
            Thread.Sleep(2000);
        }

        [Then(@"The files will not be uploaded when they are greater than ten in count")]
        public void ThenTheFilesWillNotBeUploadedWhenTheyAreGreaterThanTenInCount()
        {
            Report.WriteLine("Files not get uploaded more than ten when user trying to upload");            
            Click(attributeName_xpath, FileUploadpopupClose_Xpath);            
        }        

        [Then(@"remove files from docrepodb after the execution '(.*)'")]
        public void ThenRemoveFilesFromDocrepodbAfterTheExecution(string files)
        {
            Report.WriteLine("RemoveFileFromDocrepodbAfterTheExecution");
            string[] path = files.Split(',');
            for (int i = 0; i <= 10; i++)
            {
                DBHelper.removefile(path[i]);
            }
            Thread.Sleep(2000);                
        }

        [Then(@"the file that was previously uploaded in CRM will not be uploaded (.*)")]
        public void ThenTheFileThatWasPreviouslyUploadedInCRMWillNotBeUploaded(string filename)
        {
            Report.WriteLine("Previously uploaded file should not be there");
            string fileName_UI = Gettext(attributeName_xpath, FirstSavedFile_Xpath);
            Assert.AreEqual(filename, fileName_UI);
        }
    }
}
