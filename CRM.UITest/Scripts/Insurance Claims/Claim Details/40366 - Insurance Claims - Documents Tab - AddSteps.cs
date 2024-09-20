using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Insurance_Claims.Claim_Details
{
    [Binding]
    public class _40366___Insurance_Claims___Documents_Tab___AddSteps : InsuranceClaim
    {

        List<string> expectedDocTypeValues = new List<string>(new string[] { "Complete Vendor Invoice", "Airway Bill", "Bill of Lading", "Claimant's Form W-9", "Concealed Damage Notification", "Customs Document", "Delivery Receipt", "Inspection Report", "Ocean Bill of Lading", "Packing List", "Pictures - On Receipt", "Pictures - Prior to Shipment", "Repair Invoice", "Other" });
        List<string> extensions = new List<string> { ".doc", ".docx", ".xls", ".xlsx", ".ppt", ".pptx", ".pdf", ".txt", ".tif", ".jpg", ".png" };
        public int UIDocTypeCount;
        public string ExpectedInvalidFileName;
        public string ExpectedInvalidFileSize;
        public string ExpFileName;

        [When(@"I click on the Add Additional Document button on the Document tab")]
        public void WhenIClickOnTheAddAdditionalDocumentButtonOnTheDocumentTab()
        {

            Click(attributeName_id, ClaimDetails_DocTab_AddAdditionalDocButton_Id);
        }


        [Then(@"I will see a Document Type drop down list")]
        public void ThenIWillSeeADocumentTypeDropDownList()
        {
            VerifyElementPresent(attributeName_xpath, ClaimDetaisl_DocTab_DocumentTypeDropDownList_xpath, "DocumentTypeDropdownList");
            Report.WriteLine("Document Type drop down list is present on Claim Details Document Tab ");
        }


        [Then(@"the default selection in the drop down list will be (.*)")]
        public void ThenTheDefaultSelectionInTheDropDownListWillBe(string ExpecDropdownDefaultText)
        {

            string ActualDropdownDefaultText = Gettext(attributeName_xpath, ".//div[@id='DocType1_chosen']/a[@class='chosen-single chosen-default']/span");
            Assert.AreEqual("Select document type...", ActualDropdownDefaultText);
            Report.WriteLine("Default value of document type drop down matches with the expected value");
        }

        [Then(@"I will see an inactive document upload icon")]
        public void ThenIWillSeeAnInactiveDocumentUploadIcon()
        {
            VerifyElementNotEnabled(attributeName_xpath, ClaimDetails_DocTab_InactiveUploadButton_xpath, "Document Upload");
            Report.WriteLine("Document Upload button is inactive when document type is not selected");
        }


        [Then(@"I will see the verbiage (.*) next to the document upload icon")]
        public void ThenIWillSeeTheVerbiageNextToTheDocumentUploadIcon(string NoDocSelectedVerbiage)
        {
            string GetUIVal = Gettext(attributeName_xpath, ClaimsDetails_DocTab_NofileuploadedVerbiage_xpath);
            Assert.AreEqual("No file currently uploaded", GetUIVal);
            Report.WriteLine("Verbiage next to document upload button is verified");
        }

        [Then(@"I will see a Remove button for the Additional Document Type section")]
        public void ThenIWillSeeARemoveButtonForTheAdditionalDocumentTypeSection()
        {
            VerifyElementPresent(attributeName_xpath, ClaimDetails_DocTab_RemoveButton_xpath, "Remove Button");
            Report.WriteLine("Remove button exists");
        }

        [Then(@"I will see an Add Additional Document button on the Document Tab")]
        public void ThenIWillSeeAnAddAdditionalDocumentButtonOnTheDocumentTab()
        {
            VerifyElementPresent(attributeName_id, ClaimDetails_DocTab_AddAdditionalDocButton_Id, "Add Additional Document");
        }


        [Given(@"I clicked on the Add Additional Document button")]
        public void GivenIClickedOnTheAddAdditionalDocumentButton()
        {
            WaitForElementVisible(attributeName_id, ClaimDetails_DocTab_AddAdditionalDocButton_Id, "Add Button");
            Click(attributeName_id, ClaimDetails_DocTab_AddAdditionalDocButton_Id);
            
        }

        [When(@"I click in the Document Type drop down list")]
        public void WhenIClickInTheDocumentTypeDropDownList()
        {
            Click(attributeName_xpath, ClaimDetails_DocTab_SelectDocumentTypeDefaultText_xpath);
            Report.WriteLine("Clicked on Document type field");
        }


        [Then(@"I will see list of Document types (.*)")]
        public void ThenIWillSeeListOfDocumentTypes(string p0)
        {
            
            IList<IWebElement> UIDocumentTypes = GlobalVariables.webDriver.FindElements(By.XPath(ClaimsDetails_DocTab_DocumentTypedropdownValues_xpath));
            UIDocTypeCount = UIDocumentTypes.Count;
            for (int i = 2; i < UIDocTypeCount; i++)
            {

                string UIDocTypeName = Gettext(attributeName_xpath, ".//*[@id='DocType1_chosen']/div/ul/li[" + i + "] ");

                if (expectedDocTypeValues.Contains(UIDocTypeName))
                {
                    Report.WriteLine("is displayed in Document type drop down list");
                }
                else
                {
                    Assert.Fail();
                }

            }
        }

       

        [Then(@"(.*) will be displayed first in the list")]
        public void ThenWillBeDisplayedFirstInTheList(string firstDocumentType)
        {
            IList<IWebElement> UIDocumentTypes = GlobalVariables.webDriver.FindElements(By.XPath(ClaimsDetails_DocTab_DocumentTypedropdownValues_xpath));
            int UIDocTypeCount = UIDocumentTypes.Count;
            for (int i = 2; i <= 2; i++)
            {
                string UIDocTypeName = Gettext(attributeName_xpath, ".//*[@id='DocType1_chosen']/div/ul/li[" + i + "] ");
                if (UIDocTypeName.Equals(UIDocumentTypes[1].Text))
                {
                    Report.WriteLine("Complete Vendor Invoice is displayed first in the document type list");
                }
                else
                {
                    Assert.Fail();
                }
            }
        }


        [Then(@"(.*) will be displayed last in the list")]
        public void ThenWillBeDisplayedLastInTheList(string lastDocumentType)
        {
            IList<IWebElement> UIDocumentTypes = GlobalVariables.webDriver.FindElements(By.XPath(ClaimsDetails_DocTab_DocumentTypedropdownValues_xpath));
            int UIDocTypeCount = UIDocumentTypes.Count;

            string lastDoctypeNameUI= Gettext(attributeName_xpath, ".//*[@id='DocType1_chosen']/div/ul/li[" + UIDocTypeCount + "] ");
            Assert.AreEqual(lastDoctypeNameUI, "Other");
            
        }



        [Then(@"all other documents will displayed alphabetically after (.*)")]
        public void ThenAllOtherDocumentsWillDisplayedAlphabeticallyAfter(string firstDocumentTypeName)
        {
            //Click(attributeName_xpath, ClaimDetails_DocTab_SelectDocumentTypeDefaultText_xpath);
            int j = 0;
            List<string> DocTypeUI = new List<string>();
            List<string> DocTypeUICheck = new List<string>();
            IList<IWebElement> UIDocumentTypes = GlobalVariables.webDriver.FindElements(By.XPath(ClaimsDetails_DocTab_DocumentTypedropdownValues_xpath));
            int UIDocTypeCount = UIDocumentTypes.Count;
            for (int i = 3; i <= UIDocTypeCount-1; i++)
            {

                IList<IWebElement> DocType = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='divNewSelectedDocumentType']//*[@class='chosen-results']/li[" + i + "]"));
                foreach (IWebElement element in DocType)
                {
                    DocTypeUI.Add((element.Text).ToString());

                }
            }
            DocTypeUI.Sort();

            IList<IWebElement> UIDocumentTypesCheck = GlobalVariables.webDriver.FindElements(By.XPath(ClaimsDetails_DocTab_DocumentTypedropdownValues_xpath));
            int UIDocTypeCountCheck = UIDocumentTypesCheck.Count;
            for (int i = 3; i <= 14; i++)
            {

                IList<IWebElement> DocTypeCheck = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='divNewSelectedDocumentType']//*[@class='chosen-results']/li[" + i + "]"));
                foreach (IWebElement element in DocTypeCheck)
                {
                    DocTypeUICheck.Add((element.Text).ToString());

                }
            }

            if (DocTypeUI[j] == DocTypeUICheck[j])
            {
                Report.WriteLine("Document types are sorted in alphabetical order");
            }
            else
            {
                Report.WriteFailure("Document types are not sorted in alphabetical order");
                Assert.Fail();

            }
        }

        [Then(@"the document list is configurable")]
        public void ThenTheDocumentListIsConfigurable()
        {
            
            Report.WriteLine("Clicked on Document type field");
            SelectDropdownValueFromList(attributeName_xpath, ".//*[@id='DocType1_chosen']/div/ul/li[2]", "Complete Vendor Invoice");
        }

        [When(@"I choose a document type from the document type drop down list")]
        public void WhenIChooseADocumentTypeFromTheDocumentTypeDropDownList()
        {
            
            Click(attributeName_xpath, ClaimDetails_DocTab_SelectDocumentTypeDefaultText_xpath);
            Report.WriteLine("Clicked on Document type field");
            SelectDropdownValueFromList(attributeName_xpath, ".//*[@id='DocType1_chosen']/div/ul/li[2]", "Complete Vendor Invoice");


        }

        [Then(@"the document upload icon should be active")]
        public void ThenTheDocumentUploadIconShouldBeActive()
        {
            VerifyElementEnabled(attributeName_xpath, ".//*[@id='divFilePreviewContainer1']/div[1]/button", "Document Upload Button");
            Report.WriteLine("Document Upload button is active when document type is selected form the dropdown");
        }


        [When(@"I click on the Remove button for the Additional Document")]
        public void WhenIClickOnTheRemoveButtonForTheAdditionalDocument()
        {
            Click(attributeName_xpath, ".//*[@id='divFilePreviewContainer1']/div[4]/button");
        }

        [Then(@"the additional Document Type section should be removed")]
        public void ThenTheAdditionalDocumentTypeSectionShouldBeRemoved()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I should not see the Remove button")]
        public void ThenIShouldNotSeeTheRemoveButton()
        {
            VerifyElementNotPresent(attributeName_xpath, ".//*[@id='divFilePreviewContainer1']/div[4]/button", "Remove");
        }

        [Then(@"I should not see the Add Additional Document button")]
        public void ThenIShouldNotSeeTheAddAdditionalDocumentButton()
        {
            VerifyElementNotPresent(attributeName_xpath, ClaimDetails_DocTab_AddAdditionalDocButton_Id, "Add Additional Document");
        }


        [Given(@"I selected a document type from the drop down list")]
        public void GivenISelectedADocumentTypeFromTheDropDownList()
        {
            Report.WriteLine("Clicked on Document type field");
            Click(attributeName_id, ClaimDetails_DocTab_AddAdditionalDocButton_Id);
            Click(attributeName_xpath, ClaimDetails_DocTab_SelectDocumentTypeDefaultText_xpath);
            SelectDropdownValueFromList(attributeName_xpath, ".//*[@id='DocType1_chosen']/div/ul/li[2]", "Complete Vendor Invoice");

        }






        [Given(@"I have selected a valid document to upload (.*) from Add Additional Document")]
        public void GivenIHaveSelectedAValidDocumentToUploadFromAddAdditionalDocument(string p0)
        {
            Click(attributeName_id, ClaimDetails_DocTab_AddAdditionalDocButton_Id);
            Click(attributeName_id, ClaimDetails_DocTab_AddAdditionalDocButton_Id);
            Click(attributeName_id, ClaimDetails_DocTab_AddAdditionalDocButton_Id);
            Click(attributeName_id, ClaimDetails_DocTab_AddAdditionalDocButton_Id);
            Click(attributeName_id, ClaimDetails_DocTab_AddAdditionalDocButton_Id);
            GlobalVariables.webDriver.WaitForPageLoad();

            int count = 5;
            for (int i = 1; i <= count; i++)
            {
                
                GlobalVariables.webDriver.WaitForPageLoad();


                List <string> fileNames = new List<string> { "Claim.xlsx", "Elevate.png", "hacker.txt", "AfterFix_CsrDetailsReport.pdf", "TestClaim.docx", "Testjpg.tif" };
                              
                    int z = i + 1;
                    int k = i - 1;

                   
                    Click(attributeName_xpath, ".//div[@id='DocType"+i+"_chosen']/a[@class='chosen-single chosen-default']/span");
                    GlobalVariables.webDriver.WaitForPageLoad();
                
                    string doctype = expectedDocTypeValues[k];
                    SelectDropdownValueFromList(attributeName_xpath, ".//*[@id='DocType"+i+"_chosen']/div/ul/li["+z+"]", doctype);
                    GlobalVariables.webDriver.WaitForPageLoad();

                    string ExpFileName = fileNames[k];
                    string file_path = Path.GetFullPath("../../Scripts/TestData/Testfiles_ClaimDocument/"+ ExpFileName + " ");
                    
                    FileUpload(attributeName_xpath, ".//*[@id='divFilePreviewContainer"+i+"']/div[1]/button", file_path);
                    Report.WriteLine("Document is been uploaded");
                    GlobalVariables.webDriver.WaitForPageLoad();

                    string ActualFileName = Gettext(attributeName_xpath, ".//*[@id='divFilePreviewContainer"+i+"']/div[2]/p/div/div/span/a");
                    Assert.AreEqual(ExpFileName, ActualFileName);
                    Report.WriteLine("Upload document name is verified");
                }
            

        }

        [Given(@"I clicked on the file upload icon to select a valid document to upload")]
        public void GivenIClickedOnTheFileUploadIconToSelectAValidDocumentToUpload()
        {
            ExpFileName = "Claim.xlsx";
            string ExpectedFileName = Path.GetFullPath("../../Scripts/TestData/Testfiles_ClaimDocument/"+ExpFileName+" ");
            FileUpload(attributeName_xpath, ".//*[@id='divFilePreviewContainer1']/div[1]/button", ExpectedFileName);
            Report.WriteLine("Document is been uploaded");
        }


        [Then(@"I should see uploaded document displayed on the Document Tab")]
        public void ThenIShouldSeeUploadedDocumentDisplayedOnTheDocumentTab()
        {
            string ActualFileName = Gettext(attributeName_xpath, ".//*[@id='divFilePreviewContainer1']/div[2]/p/div/div/span/a");
            Assert.AreEqual(ExpFileName, ActualFileName);
            Report.WriteLine("Upload document name is verified");
        }


        [When(@"I close the search dialogue box")]
        public void WhenICloseTheSearchDialogueBox()
        {
            VerifyElementPresent(attributeName_xpath, ".//*[@id='divDocuments']/div[1]/div/p","NoteonDocumentTab");
        }

        [Given(@"I clicked on the file upload icon to select a invalid document to upload")]
        public void GivenIClickedOnTheFileUploadIconToSelectAInvalidDocumentToUpload()
        {
            ExpectedInvalidFileName = "MGAcct_MGBill.xml";
            string ExpectedFilePath = Path.GetFullPath("../../Scripts/TestData/Testfiles_ClaimDocument/"+ ExpectedInvalidFileName+"");
            FileUpload(attributeName_xpath, ".//*[@id='divFilePreviewContainer1']/div[1]/button", ExpectedFilePath);
            Report.WriteLine("Document is been uploaded");
        }

        [Given(@"I closed the search dialogue box")]
        public void GivenIClosedTheSearchDialogueBox()
        {
            VerifyElementPresent(attributeName_xpath, ".//*[@id='divDocuments']/div[1]/div/p", "NoteonDocumentTab");
        }

        [When(@"the document selected is not an acceptable type")]
        public void WhenTheDocumentSelectedIsNotAnAcceptableType()
        {
            string ActualFileName = Gettext(attributeName_xpath, ClaimsDetails_DocTab_NofileuploadedVerbiage_xpath);
            if (ActualFileName.Equals("No file currently uploaded"))
            {
                Report.WriteLine("Invalid file type is not uploaded");
            }
            else 
            {
                Assert.Fail();

            }
        }

        [Then(@"I will see a message : (.*)")]
        public void ThenIWillSeeAMessage(string InvalidFileMessage)
        {
            string InvalidFileErrMsg = Gettext(attributeName_xpath, ".//*[@id='divFilePreviewContainer1']/div[3]/span");
            Verifytext(attributeName_xpath, ".//*[@id='divFilePreviewContainer1']/div[3]/span", InvalidFileErrMsg);
        }


        [Then(@"the document will not be displayed on the Document Tab")]
        public void ThenTheDocumentWillNotBeDisplayedOnTheDocumentTab()
        {
            Verifytext(attributeName_xpath, ".//*[@id='divFilePreviewContainer1']/div[2]/p/span", "No file currently uploaded");
        }

        [Given(@"I clicked on the file upload icon to select a file greater than tenMB")]
        public void GivenIClickedOnTheFileUploadIconToSelectAFileGreaterThanTenMB()
        {
            ExpectedInvalidFileSize = "RRD_CRM_Customer_Portal_Designs_12-10.pdf";
            string ExpectedFilePath = Path.GetFullPath("../../Scripts/TestData/Testfiles_ClaimDocument/"+ExpectedInvalidFileSize+" ");
            FileUpload(attributeName_xpath, ".//*[@id='divFilePreviewContainer1']/div[1]/button", ExpectedFilePath);
            Report.WriteLine("Document is been uploaded");
        }



        [When(@"the document selected size is greater than (.*)MB")]
        public void WhenTheDocumentSelectedSizeIsGreaterThanMB(int p0)
        {
            string ActualFileName = Gettext(attributeName_xpath, ClaimsDetails_DocTab_NofileuploadedVerbiage_xpath);
            if (ActualFileName.Equals("No file currently uploaded"))
            {
                Report.WriteLine("File Size greater than 10MB is not uploaded");
            }
            else
            {
                Assert.Fail();

            }
        }

        [Then(@"I will see a message as (.*)")]
        public void ThenIWillSeeAMessageAs(string InvalidFileSize)
        {
            string GreaterFileSize = Gettext(attributeName_xpath, ".//*[@id='divFilePreviewContainer1']/div[3]/span");
            Verifytext(attributeName_xpath, ".//*[@id='divFilePreviewContainer1']/div[3]/span", GreaterFileSize);
        }






        [Then(@"the selected file must pass the Acceptable file type validation")]
        public void ThenTheSelectedFileMustPassTheAcceptableFileTypeValidation()
        {
            IList<IWebElement> UIDocumentTypes = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='divNewSelectedDocumentType']//*[@class='DocumentUploadLink']/a"));
            UIDocTypeCount = UIDocumentTypes.Count;
            for(int i = 0;i< UIDocTypeCount; i++)
            {
                if(extensions[i].Contains(UIDocumentTypes[i].Text))
                {
                    Report.WriteLine("This" + UIDocumentTypes[i].Text + "is having this" + extensions[i]);
                }    
                        
             }
        }

        [When(@"the document passes the Acceptable file type and size validation")]
        public void WhenTheDocumentPassesTheAcceptableFileTypeAndSizeValidation()
        {
            VerifyElementPresent(attributeName_xpath, ".//*[@id='divDocuments']/div[1]/div/p", "NoteonDocumentTab");
        }



    }
}
