using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Confirmation_Screen__All_Users
{
    [Binding]
    public class ShipmentConfirmationLTLMVC5_UploadDocumentToDocRepositorySteps :AddShipments 
    {
        [When(@"I have uploaded files in Shipment Documents landing zone '(.*)'")]
        public void WhenIHaveUploadedFilesInShipmentDocumentsLandingZone(string filepath)
        {
            Report.WriteLine("Click on Upload document section of LTL Shipment confirmation");
            Report.WriteLine("uploading validfile");
            string filepathfull = Path.GetFullPath(filepath);
            FileUpload(attributeName_xpath, confirmation_uploaddocumentsection, filepathfull);
            Thread.Sleep(20000);
            WaitForElementVisible(attributeName_xpath, confirmation_BOLValue_Xpath, "waitforthepageload");
        }
        
        [When(@"I have navigated to docrepo recently added page")]
        public void WhenIHaveNavigatedToDocrepoRecentlyAddedPage()
        {
            Mvc4Objects mvc4 = new Mvc4Objects();
            Report.WriteLine("Click on docrepo icon");
            Click(attributeName_id, mvc4.DocRepo_icon_Id);
            Thread.Sleep(20000);
            WaitForElementVisible(attributeName_id, mvc4.DocRepo_RecentlyAddedtitlt_Id, "Docrepopage");
        }
        
        [Then(@"I should be diaplyed the uploadefile '(.*)' in recently added folder")]
        public void ThenIShouldBeDiaplyedTheUploadefileInRecentlyAddedFolder(string filename)
        {
            Mvc4Objects mvc4 = new Mvc4Objects();
            Report.WriteLine("Click on docrepo icon");
            Thread.Sleep(20000);
            SendKeys(attributeName_id, mvc4.DocRepo_SearchBox_Id, filename);
            Verifytext(attributeName_xpath, mvc4.DocRepo_Firstrow_FileName_Xpath, filename);
        }
        
        [Then(@"I should be displayed in '(.*)' BOL folder")]
        public void ThenIShouldBeDisplayedInBOLFolder(string filename)
        {
            Mvc4Objects mvc4 = new Mvc4Objects();
            Report.WriteLine("Click on docrepo icon");
            Click(attributeName_xpath, mvc4.DocRepo_BOLTab_Xpath);
            SendKeys(attributeName_id, mvc4.DocRepo_SearchBox_Id, filename);
            Verifytext(attributeName_xpath, mvc4.DocRepo_Firstrow_FileName_Xpath, filename);
        }
        
        [Then(@"I should be diaplyed the uploadefile '(.*)' will be assigned the CRM Primary Reference number of the shipment in Docrepo module")]
        public void ThenIShouldBeDiaplyedTheUploadefileWillBeAssignedTheCRMPrimaryReferenceNumberOfTheShipmentInDocrepoModule(string filename)
        {
            Thread.Sleep(20000);
            WaitForElementVisible(attributeName_xpath, confirmation_BOLValue_Xpath,"BOL");
            string refrencenumber = Gettext(attributeName_xpath, confirmation_BOLValue_Xpath);
            Mvc4Objects mvc4 = new Mvc4Objects();
            Report.WriteLine("Click on docrepo icon");
            Click(attributeName_id, mvc4.DocRepo_icon_Id);
            WaitForElementVisible(attributeName_id, mvc4.DocRepo_RecentlyAddedtitlt_Id,"Docrepopage");
            SendKeys(attributeName_id, mvc4.DocRepo_SearchBox_Id, filename);
            Click(attributeName_id, mvc4.DocRepo_SearchBox_Id);
            string refrenceactual = Gettext(attributeName_xpath, ".//*[@id='docRepoTable']/table/tbody/tr[1]/td[2]/span[1]/a");
            Assert.AreEqual(refrencenumber, refrenceactual);
          
        }
    }
}
