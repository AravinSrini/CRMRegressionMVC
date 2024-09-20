using CRM.UITest.CommonMethods;
using CRM.UITest.Helper.Common;
using CRM.UITest.Helper.DataModels;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using System.Threading;
using System.IO;
using System.Configuration;
using CRM.UITest.Entities;

namespace CRM.UITest.Scripts.Insurance_Claims
{
    [Binding]
    public class InsuranceClaims_SubmitAClaim_AddlDocumentUploadSteps : InsuranceClaim
    {
        CommonMethodsCrm crmLogin = new CommonMethodsCrm();

        [Given(@"I am a shp\.inquiry, shp\.inquirynorates, shp\.entry, shp\.entrynorates Sales, Sales Management, Operations, Station Owner user or claims Specialist user")]
        public void GivenIAmAShp_InquiryShp_InquirynoratesShp_EntryShp_EntrynoratesSalesSalesManagementOperationsStationOwnerUserOrClaimsSpecialistUser()
        {
            string username = ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();
            string password = ConfigurationManager.AppSettings["ExternalUserPassword"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }


        [Given(@"I am on Submit a Claim page and Additional Document section is visible")]
        public void GivenIAmOnSubmitAClaimPageAndAdditionalDocumentSectionIsVisible()
        {
            Click(attributeName_id, ClaimsIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, Submit_A_Claim_button_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, Submit_A_Claim_Page_Header_Text_Xpath, "Submit a Claim");
            VerifyElementPresent(attributeName_xpath, Submit_A_Claim_Page_Header_Text_Xpath, "Submit a Claim");

        }

        [Given(@"Additional Document section is visible")]
        public void GivenAdditionalDocumentSectionIsVisible()
        {
            scrollpagedown();
            scrollElementIntoView(attributeName_id, AddAdditionalDocument_Button_Id);
            Click(attributeName_id, AddAdditionalDocument_Button_Id);
            Report.WriteLine("Additional document section is visible");
        }


        [Given(@"And I am on Submit a Claim page and Additional Document section is visible")]
        public void GivenAndIAmOnSubmitAClaimPageAndAdditionalDocumentSectionIsVisible()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"Document is not uploaded")]
        public void GivenDocumentIsNotUploaded()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I click on Add Additional Document button")]
        public void WhenIClickOnAddAdditionalDocumentButton()
        {
            scrollpagedown();
            scrollElementIntoView(attributeName_id, AddAdditionalDocument_Button_Id);
            Click(attributeName_id, AddAdditionalDocument_Button_Id);
            Report.WriteLine("Clicked on Add Additional Document Button");
        }

        [When(@"I select a document from the document drop down list")]
        public void WhenISelectADocumentFromTheDocumentDropDownList()
        {
            Click(attributeName_xpath, DocumentDropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, DocumentDropdownValues_Xpath, "Repair Invoice");
            Report.WriteLine("Document Type is selected form the dropdown list");
        }

        [When(@"I click on Document Type field drop down list")]
        public void WhenIClickOnDocumentTypeFieldDropDownList()
        {
            Click(attributeName_xpath, DocumentDropdown_Xpath);
            Report.WriteLine("Clicked on Document type field");
        }

        [When(@"I select Repair Invoice as document type")]
        public void WhenISelectRepairInvoiceAsDocumentType()
        {
            Click(attributeName_xpath, DocumentDropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, DocumentDropdownValues_Xpath, "Repair Invoice");
            Report.WriteLine("Repair Invoice is selected as Document type");
        }

        [When(@"I select Complete Vendor Invoice as document type")]
        public void WhenISelectCompleteVendorInvoiceAsDocumentType()
        {
            Click(attributeName_xpath, DocumentDropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, DocumentDropdownValues_Xpath, "Complete Vendor Invoice");
            Report.WriteLine("Complete Vendor Invoice is selected as Document type");
        }

        [When(@"I click on the Remove button")]
        public void WhenIClickOnTheRemoveButton()
        {
            Click(attributeName_xpath, AdditionalRemoveButton_Xpath);
            Report.WriteLine("Delete Button is clicked");
        }

        [When(@"I click on Submit Claim button")]
        public void WhenIClickOnSubmitClaimButton()
        {
            scrollpagedown();
            Click(attributeName_id, SubmitClaimButton_Id);
            Report.WriteLine("Clicked on Submit claim button");
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, ClaimsList_InstructionalVerbiage_xpath,"Cliam list");
        }
        [When(@"I click Submit Claim button")]
        public void WhenIClickSubmitClaimButton()
        {
            scrollpagedown();
            Click(attributeName_id, SubmitClaimButton_Id);
            Report.WriteLine("Clicked on Submit claim button");
        }

        [When(@"I click on Document Type field drop down")]
        public void WhenIClickOnDocumentTypeFieldDropDown()
        {
            Click(attributeName_xpath, DocumentDropdown_Xpath);
            Report.WriteLine("Clicked on Document type dropdown field");
        }

        [Then(@"I should be able to view a Document Type drop down list")]
        public void ThenIShouldBeAbleToViewADocumentTypeDropDownList()
        {
            VerifyElementPresent(attributeName_xpath, DocumentDropdown_Xpath, "DocumentType");
            Report.WriteLine("Document Type drop down list is present on submit a claim page");

        }

        [Then(@"The default selection in the drop down list should be - Select document type")]
        public void ThenTheDefaultSelectionInTheDropDownListShouldBe_SelectDocumentType()
        {
            string ExpecVal = "Select document type...";
            string GetUIVal = Gettext(attributeName_xpath, DocumentDropdown_Xpath);
            Assert.AreEqual(ExpecVal, GetUIVal);
            Report.WriteLine("Default value of document type drop down matches with the expected value");

        }

        [Then(@"I should be able to view document upload button")]
        public void ThenIShouldBeAbleToViewDocumentUploadButton()
        {
            VerifyElementPresent(attributeName_xpath, AdditionalUploadButton_Xpath, "Upload Button");
            Report.WriteLine("Document upload button is present");
        }

        [Then(@"The document upload button should be inactive")]
        public void ThenTheDocumentUploadButtonShouldBeInactive()
        {
            VerifyElementNotEnabled(attributeName_xpath, AdditionalUploadButton_Xpath, "Document Upload");
            Report.WriteLine("Document Upload button is inactive when document type is not selected");
        }

        [Then(@"I should be able to view a verbiage next to document upload button stating - No file currently uploaded")]
        public void ThenIShouldBeAbleToViewAVerbiageNextToDocumentUploadButtonStating_NoFileCurrentlyUploaded()
        {
            string ExpecVal = "No file currently uploaded";
            string GetUIVal = Gettext(attributeName_xpath, AdditionalUpload_NofileMessage_Xpath);
            Assert.AreEqual(ExpecVal, GetUIVal);
            Report.WriteLine("Verbiage next to document upload button is verified");
        }

        [Then(@"I should be able to view remove button")]
        public void ThenIShouldBeAbleToViewRemoveButton()
        {
            VerifyElementPresent(attributeName_xpath, AdditionalRemoveButton_Xpath, "Remove Button");
            Report.WriteLine("Remove button exists");
        }

        [Then(@"The document upload icon will be active\.")]
        public void ThenTheDocumentUploadIconWillBeActive_()
        {
            VerifyElementEnabled(attributeName_xpath, AdditionalUploadButton_Xpath, "Document Upload Button");
            Report.WriteLine("Document Upload button is active when document type is selected form the dropdown");
        }

        [Then(@"I should be able to view the following values in the Document Type field drop down list - Complete Vendor Invoice, Airway Bill, Bill of Lading, Claimant's Form W(.*), Concealed Damage Notification, Customs Document, Delivery Receipt, Inspection Report, Ocean Bill of Lading, Packing List, Pictures - On Receipt, Pictures - Prior to Shipment, Repair Invoice, Other")]
        public void ThenIShouldBeAbleToViewTheFollowingValuesInTheDocumentTypeFieldDropDownList_CompleteVendorInvoiceAirwayBillBillOfLadingClaimantSFormWConcealedDamageNotificationCustomsDocumentDeliveryReceiptInspectionReportOceanBillOfLadingPackingListPictures_OnReceiptPictures_PriorToShipmentRepairInvoiceOther(int p0)
        {
            IList<IWebElement> UIDocumentTypes = GlobalVariables.webDriver.FindElements(By.XPath(DocumentDropdownValues_Xpath));
            int UIDocTypeCount = UIDocumentTypes.Count;
            for (int i = 2; i < UIDocTypeCount; i++)
            {
                
                List<string> expectedDocTypeValues = new List<string>(new string[] { "Complete Vendor Invoice", "Airway Bill", "Bill of Lading", "Claimant's Form W-9", "Concealed Damage Notification", "Customs Document", "Delivery Receipt", "Inspection Report", "Ocean Bill of Lading", "Packing List", "Pictures - On Receipt", "Pictures - Prior to Shipment", "Repair Invoice", "Other" });
                string UIDocTypeName = Gettext(attributeName_xpath, ".//*[@id='DocType_0_chosen']/div/ul/li[" + i + "] ");
                
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

        [Then(@"Complete Vendor Invoice should be displayed first in the list")]
        public void ThenCompleteVendorInvoiceShouldBeDisplayedFirstInTheList()
        {
            IList<IWebElement> UIDocumentTypes = GlobalVariables.webDriver.FindElements(By.XPath(DocumentDropdownValues_Xpath));
            int UIDocTypeCount = UIDocumentTypes.Count;
            for (int i = 2; i <= 2; i++)
            {
                string UIDocTypeName = Gettext(attributeName_xpath, ".//*[@id='DocType_0_chosen']/div/ul/li[" + i + "] ");
                if (UIDocTypeName.Equals("Complete Vendor Invoice"))
                {
                    Report.WriteLine("Complete Vendor Invoice is displayed first in the document type list");
                }
                else
                {
                    Assert.Fail();
                }
            }
        }

        [Then(@"Other should be displayed last in the list")]
        public void ThenOtherShouldBeDisplayedLastInTheList()
        {
            IList<IWebElement> UIDocumentTypes = GlobalVariables.webDriver.FindElements(By.XPath(DocumentDropdownValues_Xpath));
            int UIDocTypeCount = UIDocumentTypes.Count;
            for (int i = 15; i <=15; i++)
            {
                string UIDocTypeName = Gettext(attributeName_xpath, ".//*[@id='DocType_0_chosen']/div/ul/li[" + i + "] ");
                if (UIDocTypeName.Equals("Other"))
                {
                    Report.WriteLine("Other is displayed last in the document type list");
                }
                else
                {
                    Assert.Fail();
                }
            }
        }

        [Then(@"I should be able to view document selection options in the Document Type field drop down list sorted alphabetically except for the first and last option")]
        public void ThenIShouldBeAbleToViewDocumentSelectionOptionsInTheDocumentTypeFieldDropDownListSortedAlphabeticallyExceptForTheFirstAndLastOption()
        {
            int j = 0;
            List<string> DocTypeUI = new List<string>();
            List<string> DocTypeUICheck = new List<string>();
            IList<IWebElement> UIDocumentTypes = GlobalVariables.webDriver.FindElements(By.XPath(DocumentDropdownValues_Xpath));
            int UIDocTypeCount = UIDocumentTypes.Count;
            for (int i = 3; i <= 14; i++)
            {

                IList<IWebElement> DocType = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='DocType_0_chosen']/div/ul/li[" + i + "] "));
                foreach (IWebElement element in DocType)
                {
                    DocTypeUI.Add((element.Text).ToString());

                }
            }
            DocTypeUI.Sort();

            IList<IWebElement> UIDocumentTypesCheck = GlobalVariables.webDriver.FindElements(By.XPath(DocumentDropdownValues_Xpath));
            int UIDocTypeCountCheck = UIDocumentTypesCheck.Count;
            for (int i = 3; i <= 14; i++)
            {

                IList<IWebElement> DocTypeCheck = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='DocType_0_chosen']/div/ul/li[" + i + "] "));
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

        [Then(@"All the displayed document selection options should be present in DB")]
        public void ThenAllTheDisplayedDocumentSelectionOptionsShouldBePresentInDB()
        {
            int j = 0;
            IList<IWebElement> UIDocumentTypes = GlobalVariables.webDriver.FindElements(By.XPath(DocumentDropdownValues_Xpath));
            int UIDocTypeCount = UIDocumentTypes.Count;
            List<string> DocTypeUIVal = new List<string>();
            for (int i = 3; i <= 14; i++)
            {
                IList<IWebElement> DocTypeUI = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='DocType_0_chosen']/div/ul/li[" + i + "] "));
                foreach (IWebElement element in DocTypeUI)
                {
                    DocTypeUIVal.Add((element.Text).ToString());

                }

            }
            List<string> DocumentTypeDB = DBHelper.GetDocTypeVal();
            if (DocumentTypeDB[j] == DocTypeUIVal[j])
            {
                Report.WriteLine("Displayed document Type is present in DB");
            }
            else
            {
                Assert.Fail();
            }


            }

        [Then(@"I should be able to view a tool tip for Repair Invoice")]
        public void ThenIShouldBeAbleToViewAToolTipForRepairInvoice()
        {
            VerifyElementVisible(attributeName_xpath, AdditionalTooltip_Xpath, "Repair Invoice Tooltip");
            Report.WriteLine("Repair Invoice tool tip is present");
        }

        [Then(@"On mouse hover i should see a verbiage stating - This should be detailed out by parts and labor, including labor rate\.")]
        public void ThenOnMouseHoverIShouldSeeAVerbiageStating_ThisShouldBeDetailedOutByPartsAndLaborIncludingLaborRate_()
        {
            OnMouseOver(attributeName_xpath, AdditionalTooltip_Xpath);
            string ExpRepairInvoice = "This should be detailed out by parts and labor, including labor rate.";
            string ActualRepairInvoice = GetAttribute(attributeName_xpath, AdditionalTooltip_Xpath, "data-title");
            Assert.AreEqual(ExpRepairInvoice, ExpRepairInvoice);
            Report.WriteLine("Repair Invoice tool tip is verified");
        }

        [Then(@"I should be able to view a tool tip for Complete Vendor Invoice")]
        public void ThenIShouldBeAbleToViewAToolTipForCompleteVendorInvoice()
        {
            VerifyElementVisible(attributeName_xpath, AdditionalTooltip_Xpath, "Complete Vendor Invoice tool tip");
            Report.WriteLine("Complete Vendor Invoice tool tip is present");
        }

        [Then(@"On mouse hover i should see a verbiage stating - This invoice should show your cost for the product being claimed\.")]
        public void ThenOnMouseHoverIShouldSeeAVerbiageStating_ThisInvoiceShouldShowYourCostForTheProductBeingClaimed_()
        {
            OnMouseOver(attributeName_xpath, AdditionalTooltip_Xpath);
            string ExpCompleteVendorInvoice = "This invoice should show your cost for the product being claimed.";
            string ActualCompleteVendorInvoice = GetAttribute(attributeName_xpath, AdditionalTooltip_Xpath, "data-title");
            Assert.AreEqual(ExpCompleteVendorInvoice, ActualCompleteVendorInvoice);
            Report.WriteLine("Complete Vendor Invoice tool tip is verified");
        }

        [Then(@"The additional document section will be removed\.")]
        public void ThenTheAdditionalDocumentSectionWillBeRemoved_()
        {
            VerifyElementNotVisible(attributeName_xpath, AdditionalDeleteButton_Xpath, "Remove Button");
            Report.WriteLine("Additional document section is removed when remove button is clicked");
        }

        [Then(@"I will receive an error message stating - Please add document to claim form")]
        public void ThenIWillReceiveAnErrorMessageStating_PleaseAddDocumentToClaimForm()
        {
            scrollpagedown();
            scrollpagedown();
            scrollElementIntoView(attributeName_xpath, AdditionalDocMessageSubmit_Xpath);
            Verifytext(attributeName_xpath, AdditionalDocMessageSubmit_Xpath, "Please add document to claim form");
            Report.WriteLine("Error message when no files are uploaded is verified");
        }

        [Then(@"The page will be focused to the Additional Document section\.")]
        public void ThenThePageWillBeFocusedToTheAdditionalDocumentSection_()
        {
            VerifyFocus(attributeName_xpath, AdditionalUploadButton_Xpath);
            Report.WriteLine("Additional document section is focused");
        }

        [Then(@"I should be able to select any document type from the Document Type field drop down list")]
        public void ThenIShouldBeAbleToSelectAnyDocumentTypeFromTheDocumentTypeFieldDropDownList()
        {
            SelectDropdownValueFromList(attributeName_xpath, DocumentDropdownValues_Xpath, "Concealed Damage Notification");
            Report.WriteLine("Document type is selected from the dropdown");
        }

        [Then(@"I should be able to upload a document")]
        public void ThenIShouldBeAbleToUploadADocument()
        {
            string filepath = Path.GetFullPath("../../Scripts/TestData/Testfiles_ClaimDocument/Claim.xlsx");
            Thread.Sleep(3000);
            FileUpload(attributeName_xpath, AdditionalUploadButton_Xpath, filepath);
            Report.WriteLine("Document is been uploaded");
            string ExpFileName = "Claim.xlsx";
            string ActualFileName = Gettext(attributeName_xpath, AdditionalUploadedFile_Xpath);
            Assert.AreEqual(ExpFileName, ActualFileName);
            Report.WriteLine("Upload document name is verified");
        }

        [Then(@"Document upload button should be inactive")]
        public void ThenDocumentUploadIconShouldBeInactive()
        {
            VerifyElementNotEnabled(attributeName_xpath, AdditionalUploadButton_Xpath, "Upload Button");
            Report.WriteLine("Upload button is inactive when document type is not selected");
        }

        [Given(@"Document is not been uploaded")]
        public void GivenDocumentIsNotBeenUploaded()
        {
            VerifyElementNotPresent(attributeName_xpath, AdditionalUploadedFile_Xpath, "Uploaded Document");
            Report.WriteLine("Document is not uploaded");
        }
        [When(@"I upload a valid document")]
        public void WhenIUploadAValidDocument()
        {
            Click(attributeName_xpath, DocumentDropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, DocumentDropdownValues_Xpath, "Concealed Damage Notification");
            string filepath = Path.GetFullPath("../../Scripts/TestData/Testfiles_ClaimDocument/Claim.xlsx");
            Thread.Sleep(3000);
            FileUpload(attributeName_xpath, AdditionalUploadButton_Xpath, filepath);
            Report.WriteLine("Document is been uploaded");
        }

        [Then(@"Document type dropdown should be in disabled")]
        public void ThenDocumentTypeDropdownShouldBeInDisabled()
        {
            IsElementDisabled(attributeName_xpath, DocumentDropdown_Xpath, "Document type");
            Report.WriteLine("Document type dropdown is disabled once document is uploaded");
        }

        [When(@"I delete an uploaded document")]
        public void WhenIDeleteAnUploadedDocument()
        {
            Click(attributeName_xpath, DocumentDropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, DocumentDropdownValues_Xpath, "Concealed Damage Notification");
            string filepath = Path.GetFullPath("../../Scripts/TestData/Testfiles_ClaimDocument/Claim.xlsx");
            Thread.Sleep(3000);
            FileUpload(attributeName_xpath, AdditionalUploadButton_Xpath, filepath);
            Report.WriteLine("Document is been uploaded");
            string ExpFileName = "Claim.xlsx";
            string ActualFileName = Gettext(attributeName_xpath, AdditionalUploadedFile_Xpath);
            Assert.AreEqual(ExpFileName, ActualFileName);
            Report.WriteLine("Uploaded document is visible");
            Click(attributeName_xpath, AdditionalDeleteButton_Xpath);
            VerifyElementPresent(attributeName_xpath, AdditionalDeleteConfirmationModal_Xpath, "Delete Modal");
            WaitForElementVisible(attributeName_id, AdditionalModalDeleteButton_Id,"Delete Button");
            Click(attributeName_id, AdditionalModalDeleteButton_Id);
            Thread.Sleep(4000);
            VerifyElementNotPresent(attributeName_xpath, AdditionalUploadedFile_Xpath, "Uploaded file");
            Report.WriteLine("Uploaded document is deleted");
        }

        [Then(@"Document type dropdown should be enabled")]
        public void ThenDocumentTypeDropdownShouldBeEnabled()
        {
            IsElementEnabled(attributeName_xpath, DocumentDropdown_Xpath, "Document type");
            Report.WriteLine("Document type dropdown is enabled once uploaded file is deleted");
        }

        [Then(@"Document upload button will be enabled once document type is selected")]
        public void ThenDocumentUploadButtonWillBeEnabledOnceDocumentTypeIsSelected()
        {
            Click(attributeName_xpath, DocumentDropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, DocumentDropdownValues_Xpath, "Claimant's Form W-9");
            Report.WriteLine("Document type is selected");
            VerifyElementEnabled(attributeName_xpath, AdditionalUploadButton_Xpath, "Upload button");
            Report.WriteLine("Document upload button is enabled once document type is selected");
        }

        private Boolean IsElementFocused(string Id)
        {
            IWebElement _activeElement = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            string ElementId = _activeElement.GetAttribute("id");
            return ElementId.Equals(Id);
        }
        private void VerifyFocus(string element, string elementId)
        {
            if (string.IsNullOrEmpty(element))
            {
                if (IsElementFocused(elementId))
                {
                    Assert.IsTrue(true);
                }
                else
                {
                    Assert.IsFalse(false);
                }

            }
        }
    }
}
