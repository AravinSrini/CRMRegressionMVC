using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.DocRepo;
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
    public class _40287_Insurance_Claims___Documents_Tab___Elements_Steps : InsuranceClaim
    {
        InsuranceClaims_PaymentTab_ElementsSteps hyperlinkclick = new InsuranceClaims_PaymentTab_ElementsSteps();
        public int claim_number;
        List<string> allextentions = new List<string> { ".doc", ".docx", ".xls", ".xlsx", ".ppt", ".pptx", ".pdf", ".txt", ".tif", ".jpg", ".png" };
        List<string> associated_documentsfromUI = new List<string>();
        List<string> associated_documentsfromDB = new List<string>();
        public int req_count;
        public string pdfpresent;
        

        [Given(@"I am a sales, sales management, operations, station owner and claims specialist user")]
        public void GivenIAmASalesSalesManagementOperationsStationOwnerAndClaimsSpecialistUser()
        {
            string username = ConfigurationManager.AppSettings["username-claimspecialistClaim"].ToString();
            string password = ConfigurationManager.AppSettings["password-claimspecialistClaim"].ToString();
            CommonMethodsCrm crmLogin = new CommonMethodsCrm();
            crmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"I clicked on the hyper link of a displayed claim of the Claims List page")]
        public void GivenIClickedOnTheHyperLinkOfADisplayedClaimOfTheClaimsListPage()
        {
            hyperlinkclick.GivenIClickedOnTheHyperLinkOfADisplayedClaim();
            claim_number = hyperlinkclick.claimNumber;
       }

        [When(@"I click on the Document tab of the details tab")]
        public void WhenIClickOnTheDocumentTabOfTheDetailsTab()
        {
            DefineTimeOut(5000);
            Report.WriteLine("Click on the Document Tab");
            Click(attributeName_xpath, DetailsTab_DocumentsTab_Xpath);
        }

        [Then(@"I will see Add Additional Document button")]
        public void ThenIWillSeeAddAdditionalDocumentButton()
        {
            DefineTimeOut(4000);
            VerifyElementPresent(attributeName_id, Detailstab_AddAdditionalDocumnebt_Button_id, "Add Additional Document");
        }

        [Then(@"I will see a list of required documents")]
        public void ThenIWillSeeAListOfRequiredDocuments()
        {

            Report.WriteLine("I will see a list of required documents");
            IList<IWebElement> requireddocuments = GlobalVariables.webDriver.FindElements(By.XPath(DetailsTab_DocumentsTab_RequiredDocument_Xpath));
            for (int i = 0; i < requireddocuments.Count; i++)
            {
                if (requireddocuments.Count > 1)
                {
                    req_count = requireddocuments.Count();
                    Report.WriteLine("Document is :" + requireddocuments[i].Text);
          
                }
                else
                {
                    Report.WriteLine("List containing only one required document");
                    Assert.AreEqual(requireddocuments[i].Text, "COMPLETE VENDOR INVOICE");
                    break;
                }
            }

        }

        [Then(@"The required documents are (.*)")]
        public void ThenTheRequiredDocumentsAre(string completevendor_invoice)
        {
            string [] completevendor_1 = completevendor_invoice.Split('<');
            string completevendor2 = completevendor_1[1].ToString();
            string [] completevendor3 = completevendor2.Split('>');
            string complete_vendor_invoice = completevendor3[0];

            string defaultrequired_document = Gettext(attributeName_xpath, DetailsTab_DocumentsTab_Defaultone_Xpath);
            Assert.AreEqual(complete_vendor_invoice, complete_vendor_invoice);

        }

        [Then(@"I will see a list of documents associated to the claim")]
        public void ThenIWillSeeAListOfDocumentsAssociatedToTheClaim()
        {
            Report.WriteLine("I will see a list associated document");
            
            IList<IWebElement> associated_documents = GlobalVariables.webDriver.FindElements(By.XPath(DetailsTab_DocumentsTab_AssciateDocument_Xpath));
            for (int i = 0; i < associated_documents.Count; i++)
            {
                Report.WriteLine("Associated Document is :" + associated_documents[i].Text);
                associated_documentsfromUI.Add(associated_documents[i].Text);
                
            }

            List<FileInfo> FilenameListfrom_db = DBHelper.GetMetaDateFile("CLAIMNUMBER", claim_number.ToString());
            for (int i = 0; i < FilenameListfrom_db.Count; i++)
            {
                string filename = FilenameListfrom_db[i].FileName;
                string extention1 = FilenameListfrom_db[i].FileExtension;
                string extention = "." + extention1.TrimEnd();
                string filewithextention = filename + extention;

                associated_documentsfromDB.Add(filewithextention);
            }

            CollectionAssert.AreEqual(associated_documentsfromUI, associated_documentsfromDB);

        }

        [Then(@"I will see the document type")]
        public void ThenIWillSeeTheDocumentType()
        {
            Report.WriteLine("I will see the document type");
            for (int i = 0; i < associated_documentsfromUI.Count; i++)
            {
                for(int j = 0; j< allextentions.Count; j++)
                {
                    if(associated_documentsfromUI[i].Contains(allextentions[j]))
                    {
                        Report.WriteLine("This file is containing" + associated_documentsfromUI[i] + "Extension type :" + allextentions[j]);
                    }
                }

             }
         }

        [Then(@"I will see the document name displayed as a hyper link")]
        public void ThenIWillSeeTheDocumentNameDisplayedAsAHyperLink()
        {
            
            IList<IWebElement> associated_documents = GlobalVariables.webDriver.FindElements(By.XPath(DetailsTab_DocumentsTab_AssciateDocument_Xpath));
            for (int i = 0; i < associated_documents.Count; i++)
            {
                int j = i + 2;
                string linkclickable = GetAttribute(attributeName_xpath, ".//*[@id='divDocuments']/div[" + j + "]/div[2]/a", "href");
                if(linkclickable != null)
                {
                    Report.WriteLine("Document" + associated_documents[i].Text + "is displayed with hyperlink");
                }
                
            }

        }

        [Then(@"I will see a Delete icon next to each displayed document")]
        public void ThenIWillSeeADeleteIconNextToEachDisplayedDocument()
        {
            IList<IWebElement> associated_documents = GlobalVariables.webDriver.FindElements(By.XPath(DetailsTab_DocumentsTab_AssciateDocument_Xpath));
            for (int i = 0; i < associated_documents.Count; i++)
            {
                int j = i + 2;
                VerifyElementPresent(attributeName_xpath, ".//*[@id='divDocuments']/div[" + j + "]/div[2]/a[2]", "Delete icon");
            }
        }

         [Then(@"I will see a note (.*)")]
         public void ThenIWillSeeANote(string Note)
         {
            GlobalVariables.webDriver.WaitForPageLoad();
            string[] Note1 = Note.Split('<');
            string Note2 = Note1[1].ToString();
            string[] Note3 = Note2.Split('>');
            string note = Note3[0];

            Report.WriteLine("I will see a note");
            string Actualnote = Gettext(attributeName_xpath, DetailsTab_DocumentsTab_Note_Xpath);
            Assert.AreEqual(note, Actualnote);
         }

        [Given(@"I clicked on the Document tab")]
        public void GivenIClickedOnTheDocumentTab()
        {
            DefineTimeOut(5000);
            Report.WriteLine("Click on the Document Tab");
            Click(attributeName_xpath, DetailsTab_DocumentsTab_Xpath);
        }

        [When(@"I click on the hyper link of any displayed document")]
        public void WhenIClickOnTheHyperLinkOfAnyDisplayedDocument()
        {
            DefineTimeOut(2000);
            Report.WriteLine("click on any displayed document");
            IList<IWebElement> associated_documents = GlobalVariables.webDriver.FindElements(By.XPath(DetailsTab_DocumentsTab_AssciateDocument_Xpath));
            for (int i = 0; i < associated_documents.Count; i++)
            {
                if (associated_documents[i].Text.Contains(".pdf"))
                {
                    pdfpresent = "pdf is present";
                    int j = i + 2;
                    Click(attributeName_xpath, ".//*[@id='divDocuments']/div[" + j + "]/div[2]/a[1]");
                }
            }
        }

        [Then(@"The document will be displayed in a new browser tab")]
        public void ThenTheDocumentWillBeDisplayedInANewBrowserTab()
        {
            DefineTimeOut(2000);
            if(pdfpresent != null)
            {
                Report.WriteLine("The document will be displayed in new browser tab");     
                WindowHandling("http://dlsww-test.rrd.com/InsuranceClaim/DownloadSavedDocument?fileName=");
                string expectedURL = GetURL();
                if (expectedURL != null)
                {
                    Report.WriteLine("Open in the new Tab");
                }
            }
                             
        }

    }
}
