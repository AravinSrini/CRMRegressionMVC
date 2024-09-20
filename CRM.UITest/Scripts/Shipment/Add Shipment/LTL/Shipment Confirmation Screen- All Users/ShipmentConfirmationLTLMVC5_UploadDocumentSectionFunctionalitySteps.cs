using System;
using System.Collections.Generic;
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
    public class ShipmentConfirmationLTLMVC5_UploadDocumentSectionFunctionalitySteps:AddShipments
    {
                  
        [When(@"I click on remove button in Upload Document Section")]
        public void WhenIClickOnRemoveButtonInUploadDocumentSection()
        {
            Report.WriteLine("clicked on remove button");
            Click(attributeName_xpath, Fileremove_Xpath);
        }
        
        [Then(@"I should be displayed with file link,confirmation of document,option to remove file")]
        public void ThenIShouldBeDisplayedWithFileLinkConfirmationOfDocumentOptionToRemoveFile()
        {
            Report.WriteLine("DisplayedWithFileLinkConfirmationOfDocumentOptionToRemoveFile");
            Thread.Sleep(10000);
            VerifyElementPresent(attributeName_xpath, FirstSavedFilelink_Xpath, "filelink");
            VerifyElementPresent(attributeName_xpath, FirstSavedsuccess_Xpath, "successmessage");
            VerifyElementPresent(attributeName_xpath, Fileremove_Xpath, "removebutton");
        }


        [Then(@"I should be able to download the file on click on the file link '(.*)'")]
        public void ThenIShouldBeAbleToDownloadTheFileOnClickOnTheFileLink(string filename)
        {
            Report.WriteLine("click on the file link");
            Click(attributeName_xpath, FirstSavedFilelink_Xpath);
            Report.WriteLine("file is downloaded");
            string FilePath = GetDownloadedFilePath(filename);
            Report.WriteLine("file is downloaded");
            Assert.IsNotNull(FilePath);
        }
   
        [Then(@"file should be inserted in DB '(.*)'")]
        public void ThenFileShouldBeInsertedInDB(string filename)
        {
            Report.WriteLine("file is inserted in db");
            Assert.AreEqual(DBHelper.fileinsertcheck(filename), filename);
        }
             
       
        [Then(@"Uploaded file should be removed")]
        public void ThenUploadedFileShouldBeRemoved()
        {
            Report.WriteLine("Uploaded file should be removed");
            Thread.Sleep(20000);
            VerifyElementNotPresent(attributeName_xpath, FirstSavedFilelink_Xpath, "filelink");
        
        }

        [Then(@"file should be removed from DB '(.*)'")]
        public void ThenFileShouldBeRemovedFromDB(string filename)
        {
            Report.WriteLine("file is removed from DB");
            Assert.IsNull(DBHelper.fileinsertcheck(filename), filename);
        }

        [Then(@"remove file from docrepodb after the execution '(.*)'")]
        public void ThenRemoveFileFromDocrepodbAfterTheExecution(string filename)
        {
            Report.WriteLine("RemoveFileFromDocrepodbAfterTheExecution");
            DBHelper.removefile(filename);


        }

    }
}
