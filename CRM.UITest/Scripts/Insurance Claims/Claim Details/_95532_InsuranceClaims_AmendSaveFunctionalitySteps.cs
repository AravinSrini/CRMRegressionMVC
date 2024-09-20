using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.DocRepo;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Insurance_Claims.Claim_Details
{
    [Binding]
    public class _95532_InsuranceClaims_AmendSaveFunctionalitySteps : Objects.InsuranceClaim
    {
        ClickAndWaitMethods crmWait = new ClickAndWaitMethods();
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
        InsuranceClaimsubmit CreateClaim = new InsuranceClaimsubmit();
        AmendEditClaimSubmit Claim = new AmendEditClaimSubmit();
        List<string> allextentions = new List<string> { ".doc", ".docx", ".xls", ".xlsx", ".ppt", ".pptx", ".pdf", ".txt", ".tif", ".jpg", ".png" };
        List<string> associated_documentsfromUI = new List<string>();
        List<string> associated_documentsfromDB = new List<string>();
        string Amendclaimvalue = null;
        InsuranceClaimHistory claimHistoryTab = null;
        string ExpItemnum = "";
        int Expquantity = 45;
        Decimal ExpWeight = 23;
        string ExpDescription = "Description Test 123";
        decimal ExpOriginalFreight = 65;
        decimal ExpreturnFreight = 54;
        string ExpDlswRef = "BILLLADING123";
        decimal ExpReplacementFreight = 65;
        string orginalDoctype = "Airway Bill";
        int Claimnumber;
        string filename;
        string DeletefileName;
        string nameofTheUpdatedUser = string.Empty;
        [Given(@"I clicked on the edit icon of a claim in Amend status for a (.*)")]
        public void GivenIClickedOnTheEditIconOfAClaimInAmendStatusForA(string user)
        {
            if (user == "External")
            {
                // As External user doesnot have access to see the claim detils page after resubmit so login as claimspecialist and verifying the resubmition claim details
                string userName = ConfigurationManager.AppSettings["username-CurrentsprintClaimspecialist"].ToString();
                string password = ConfigurationManager.AppSettings["password-CurrentsprintClaimspecialist"].ToString();
                CrmLogin.LoginToCRMApplication(userName, password);
                GlobalVariables.webDriver.WaitForPageLoad();
                Click(attributeName_id, ClaimsIcon_Id);
                
            }
            else if(user == "Internal")
            {
                string userName = ConfigurationManager.AppSettings["username-CurrentSprintOperations"].ToString();
                string password = ConfigurationManager.AppSettings["password-CurrentSprintOperations"].ToString();
                CrmLogin.LoginToCRMApplication(userName, password);
                GlobalVariables.webDriver.WaitForPageLoad();
                Click(attributeName_id, ClaimsIcon_Id);
               
            }
            else if (user == "Sales")
            {
                string userName = ConfigurationManager.AppSettings["username-CurrentSprintSales"].ToString();
                string password = ConfigurationManager.AppSettings["password-CurrentSprintSales"].ToString();
                CrmLogin.LoginToCRMApplication(userName, password);
                GlobalVariables.webDriver.WaitForPageLoad();
                Click(attributeName_id, ClaimsIcon_Id);
              
            }
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("I un-check submitted checkbox");
            crmWait.ClickAndWait(attributeName_xpath, ClaimsList_SubmittedStatusCheckBox_Xpath); //submitted
            Report.WriteLine("I check amend checkbox");
            crmWait.ClickAndWait(attributeName_xpath, ClaimsList_AmendStatusCheckBox_Xpath); //amend
            SendKeys(attributeName_xpath, ClaimList_ClaimNumberSearchBox_Xpath, Claimnumber.ToString());
            crmWait.ClickAndWait(attributeName_xpath, ClaimListEditIcon_Xpath);
        }


        [Given(@"I clicked on the edit icon of a claim in Amend status")]
        public void GivenIClickedOnTheEditIconOfAClaimInAmendStatus()
        {
            
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("I un-check submitted checkbox");
            crmWait.ClickAndWait(attributeName_xpath, ClaimsList_SubmittedStatusCheckBox_Xpath); //submitted
            Report.WriteLine("I check amend checkbox");            
            crmWait.ClickAndWait(attributeName_xpath, ClaimsList_AmendStatusCheckBox_Xpath); //amend
            SendKeys(attributeName_xpath, ClaimList_ClaimNumberSearchBox_Xpath, Claimnumber.ToString());
            crmWait.ClickAndWait(attributeName_xpath, ClaimListEditIcon_Xpath);           
        }

        [Given(@"I am creating claim and Amend it for a (.*)")]
        public void GivenIAmCreatingClaimAndAmendItForA(string user)
        {
            Click(attributeName_xpath, SubmitClaimButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Claimnumber = CreateClaim.Claimsubmit(user);
            if (user == "claimspecialist")
            {
                SendKeys(attributeName_xpath, ClaimList_ClaimNumberSearchBox_Xpath, Claimnumber.ToString());
                Click(attributeName_xpath, ClaimList_Grid_ClaimNumbers);
                GlobalVariables.webDriver.WaitForPageLoad();
                scrollPageup();
                scrollPageup();
                Click(attributeName_xpath, ClaimStatus_Xpath);
                Thread.Sleep(3000);
                Click(attributeName_xpath, "//div[@id='CarrierMode_chosen']/div/ul/li[2]");
                Thread.Sleep(3000);
                Click(attributeName_id, Details_SubmitClaimDetails_Button_Id);
                GlobalVariables.webDriver.WaitForPageLoad();
                scrollPageup();
                scrollPageup();
                Click(attributeName_id, BackToClaimsList_Button_ClaimDetails_Id);
                GlobalVariables.webDriver.WaitForPageLoad();
            }
            else
            {
                Click(attributeName_xpath, LoggedinUser_Xpath);
                GlobalVariables.webDriver.WaitForPageLoad();
                Click(attributeName_xpath, SignOut_Xpath);
                GlobalVariables.webDriver.WaitForPageLoad();
                string userName = ConfigurationManager.AppSettings["username-CurrentsprintClaimspecialist"].ToString();
                string password = ConfigurationManager.AppSettings["password-CurrentsprintClaimspecialist"].ToString();
                CrmLogin.LoginToCRMApplication(userName, password);
                SendKeys(attributeName_xpath, ClaimList_ClaimNumberSearchBox_Xpath, Claimnumber.ToString());
                Click(attributeName_xpath, ClaimList_Grid_ClaimNumbers);
                GlobalVariables.webDriver.WaitForPageLoad();
                scrollPageup();
                scrollPageup();
                Click(attributeName_xpath, ClaimStatus_Xpath);
                Thread.Sleep(3000);
                Click(attributeName_xpath, "//div[@id='CarrierMode_chosen']/div/ul/li[2]");
                GlobalVariables.webDriver.WaitForPageLoad();
                Click(attributeName_id, Details_SubmitClaimDetails_Button_Id);
                Thread.Sleep(2000);
                scrollPageup();
                scrollPageup();
                Click(attributeName_id, BackToClaimsList_Button_ClaimDetails_Id);
                GlobalVariables.webDriver.WaitForPageLoad();
                Click(attributeName_xpath, LoggedinUser_Xpath);
                GlobalVariables.webDriver.WaitForPageLoad();
                Click(attributeName_xpath, SignOut_Xpath);
                GlobalVariables.webDriver.WaitForPageLoad();
            }
        }
        [Given(@"I am on the Submit a Claim page,")]
        public void GivenIAmOnTheSubmitAClaimPage()
        {
            Report.WriteLine("Verifying user in Submit claim page");
            VerifyElementPresent(attributeName_xpath, Submit_Claim_Page_Header_xpath, "Amend a previously submitted motor carrier shortage or damage claim");
        }

        [When(@"I completed all required information and click On the Resubmit Claim button")]
        public void WhenICompletedAllRequiredInformationAndClickOnTheResubmitClaimButton()
        {
            var tuple = Claim.Claimsubmit("ClaimSpecialist");
            filename = tuple.Item2;

        }
        
        [Given(@"I am a operations user")]
        public void GivenIAmAOperationsUser()
        {
            string userName = ConfigurationManager.AppSettings["username-CurrentSprintOperations"].ToString();
            string password = ConfigurationManager.AppSettings["password-CurrentSprintOperations"].ToString();
            CrmLogin.LoginToCRMApplication(userName, password); ScenarioContext.Current.Pending();
        }      
     
        
        [Given(@"I am a claimspecialist user")]
        public void GivenIAmAClaimspecialistUser()
        {
            string userName = ConfigurationManager.AppSettings["username-CurrentsprintClaimspecialist"].ToString();
            string password = ConfigurationManager.AppSettings["password-CurrentsprintClaimspecialist"].ToString();
            CrmLogin.LoginToCRMApplication(userName, password);
        }
        
        [Given(@"I am on the Claim Details page of a claim that was Resubmitted")]
        public void GivenIAmOnTheClaimDetailsPageOfAClaimThatWasResubmitted()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ClaimsIcon_Id);
            int Claimnumber = DBHelper.GetResubmittedClaimNumber();
            SendKeys(attributeName_xpath, ClaimList_ClaimNumberSearchBox_Xpath, Claimnumber.ToString());
            crmWait.ClickAndWait(attributeName_xpath, ClaimList_Grid_ClaimNumbers);
        }


        [When(@"I click on the Status/History tab")]
        public void WhenIClickOnTheStatusHistoryTab()
        {
            Click(attributeName_xpath, CustomerDetails_StatusOrHistory_Xpath);
        }
        
        [Then(@"the updated data will be saved")]
        public void ThenTheUpdatedDataWillBeSaved()
        {

            Report.WriteLine("Verifying all added data from DB");
            InsuranceClaimViewModel savedClaimValues = DBHelper.GetInsuranceClaimValues(Claimnumber);
            Report.WriteLine("Verifying Quantity from DB");
            int Actualquantity = savedClaimValues.Quantity;
            Assert.AreEqual(Actualquantity, Expquantity);
            Report.WriteLine("Verifying Weight from DB");
            Decimal ActualWeight = savedClaimValues.Weight.Value;
            Assert.AreEqual(ActualWeight, ExpWeight);
            Report.WriteLine("Verifying Description from DB");
            string ActualDescription = savedClaimValues.Description;
            Assert.AreEqual(ActualDescription, ExpDescription);
            Report.WriteLine("Verifying OriginalFreightCharge from DB");
            Decimal ActualOriginalFreight = savedClaimValues.OriginalFreightCharge.Value;
            Assert.AreEqual(ActualOriginalFreight, ExpOriginalFreight);
            Report.WriteLine("Verifying ReturnFreightCharge from DB");
            Decimal ActualreturnFreight = savedClaimValues.ReturnFreightCharge.Value;
            Assert.AreEqual(ActualreturnFreight, ExpreturnFreight);
            Report.WriteLine("Verifying DlswRefNumber from DB");
            string ActualDlswRef = savedClaimValues.DlswRefNumber;
            Assert.AreEqual(ActualDlswRef, ExpDlswRef);
            Report.WriteLine("Verifying ReplacementFreightCharge from DB");
            Decimal ActualReplacementFreight = savedClaimValues.ReplacementFreightCharge.Value;
            Assert.AreEqual(ActualReplacementFreight, ExpReplacementFreight);

            Report.WriteLine("Verifying Doc from DB");
            SendKeys(attributeName_xpath, ClaimList_ClaimNumberSearchBox_Xpath, Claimnumber.ToString());
            Click(attributeName_xpath, ClaimList_Grid_ClaimNumbers);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, DocumentTab_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Thread.Sleep(3000);
            Report.WriteLine("I will see a list associated document");
            IList<IWebElement> associated_documents = GlobalVariables.webDriver.FindElements(By.XPath(DetailsTab_DocumentsTab_AssciateDocument_Xpath));
            for (int i = 0; i < associated_documents.Count; i++)
            {
                Report.WriteLine("Associated Document is :" + associated_documents[i].Text);
                associated_documentsfromUI.Add(associated_documents[i].Text);

            }
            CollectionAssert.Contains(associated_documentsfromUI, filename);
        }
        
        [Then(@"the claim status will be updated to Submitted")]
        public void ThenTheClaimStatusWillBeUpdatedToSubmitted()
        {
             
             Report.WriteLine("Verifyting the claim is in Submitted status from DB");
             int status = DBHelper.GetInsuranceStatus(Claimnumber);
            if (status == 4)
              { Report.WriteLine("The Claim is in Submitted status");
               }
              else
             {
                 Report.WriteFailure("The Claim is not in Submitted status");
             }
        }
        [Then(@"an entry will be recorded on the Status/History tab of the Claim Details page for a (.*)")]
        public void ThenAnEntryWillBeRecordedOnTheStatusHistoryTabOfTheClaimDetailsPageForA(string user)
         {
            claimHistoryTab = DBHelper.GetInsuranceClaimHistorydetails(Claimnumber.ToString());
            Report.WriteLine("Verifying  Date/Time in status/History Tab from DB");
            string ctzdate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(claimHistoryTab.ModifiedDate, TimeZoneInfo.Utc.Id, "Central Standard Time")
                .ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);

            string todayDate = DateTime.Now.ToString("MM/dd/yyyy");           
            Assert.AreEqual(ctzdate, todayDate);
            Report.WriteLine("Verifying  Updated by in status/History Tab");
            claimHistoryTab = DBHelper.GetInsuranceClaimHistorydetails(Claimnumber.ToString());
            if (user == "claimspecialist")
            {
                nameofTheUpdatedUser = "Currentsprint Claimspecialist";
            } else if (user == "Sales")
            { nameofTheUpdatedUser = "Currentsprint Sales"; }
            else if (user == "Internal")
            { nameofTheUpdatedUser = "Currentsprint Operations"; }
            else
            { nameofTheUpdatedUser = "Currentsprint Claimspecialist";
            }
            Assert.AreEqual(claimHistoryTab.UserFullName, nameofTheUpdatedUser);
            Report.WriteLine("Verifying  Category in status/History Tab");
            claimHistoryTab = DBHelper.GetInsuranceClaimHistorydetails(Claimnumber.ToString());
            string Category = DBHelper.GetInsuranceClaimCategory(Convert.ToInt32(claimHistoryTab.CategoryId));
            string ExpCategory = "Status Update";
            Assert.AreEqual(Category, ExpCategory);
            Report.WriteLine("Verifying  comment in status/History Tab");
            claimHistoryTab = DBHelper.GetInsuranceClaimHistorydetails(Claimnumber.ToString());
             string ExpComment = "Claim was resubmitted";
            Assert.AreEqual(claimHistoryTab.Comments, ExpComment);
        }
        
        [Then(@"the Submit a Claim page will close")]
        public void ThenTheSubmitAClaimPageWillClose()
        {
            Report.WriteLine("Verifying After click on resubmit page will navigate to Claim list page");
            VerifyElementVisible(attributeName_xpath, ClaimsList_Pageheading_Xpath,"Claims List");
        }

        [Then(@"I will arrive on the claims List page")]
        public void ThenIWillArriveOnTheClaimsListPage()
        {
            scrollPageup();
            scrollPageup();
            Click(attributeName_id, BackToClaimsList_Button_ClaimDetails_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("arrive on the Claims List page");
            VerifyElementVisible(attributeName_xpath, ClaimsListPage_HeaderText_Xpath, "claims List");
        }
        [Then(@"I will not see the edit icon associated to the amended claim\.")]
        public void ThenIWillNotSeeTheEditIconAssociatedToTheAmendedClaim_()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("I un-check submitted checkbox");
            crmWait.ClickAndWait(attributeName_xpath, ClaimsList_SubmittedStatusCheckBox_Xpath); //submitted
            Report.WriteLine("I check amend checkbox");
            crmWait.ClickAndWait(attributeName_xpath, ClaimsList_AmendStatusCheckBox_Xpath); //amend
            Report.WriteLine("Verifying the Resubmited claim is not present in Amend status");
            SendKeys(attributeName_xpath, ClaimList_ClaimNumberSearchBox_Xpath, Claimnumber.ToString());
            VerifyElementPresent(attributeName_xpath, Claimlist_NoResult_xpath, "No Results Found");
        }       

        [Then(@"I will see an entry recording the re-submission and the entry will include the following: Date/Time - Date and time that the claim was resubmitted,Updated By - name of the user that resubmitted the claim,Category - \(Status Update\),Comment - \(Claim was resubmitted\)")]
        public void ThenIWillSeeAnEntryRecordingTheRe_SubmissionAndTheEntryWillIncludeTheFollowingDateTime_DateAndTimeThatTheClaimWasResubmittedUpdatedBy_NameOfTheUserThatResubmittedTheClaimCategory_StatusUpdateComment_ClaimWasResubmitted()
        {
            int Claimnumber = DBHelper.GetResubmittedClaimNumber();
            Report.WriteLine("Verify the Records in History Tab");
            claimHistoryTab = DBHelper.GetInsuranceClaimHistorydetails(Claimnumber.ToString());
            Report.WriteLine("Verifying  Date/Time in status/History Tab");
            string ctzdate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(claimHistoryTab.ModifiedDate, TimeZoneInfo.Utc.Id, "Central Standard Time")
                .ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
            string dateTimeFromUI = Gettext(attributeName_xpath, LatestDateTimeValue_Xpath);
            string[] dateFromUI = dateTimeFromUI.Split(' ');
            Assert.AreEqual(ctzdate, dateFromUI[0]);
            Report.WriteLine("Verifying  Updated by in status/History Tab");
            claimHistoryTab = DBHelper.GetInsuranceClaimHistorydetails(Claimnumber.ToString());
            
            string nameofTheUpdatedUser = Gettext(attributeName_xpath, LatestupdatedByValue_Xpath);
            Assert.AreEqual(claimHistoryTab.UserFullName, nameofTheUpdatedUser);
            Report.WriteLine("Verifying  Category in status/History Tab");
            claimHistoryTab = DBHelper.GetInsuranceClaimHistorydetails(Claimnumber.ToString());
            string Category = DBHelper.GetInsuranceClaimCategory(Convert.ToInt32(claimHistoryTab.CategoryId));
            string CategoryUI = Gettext(attributeName_xpath, LatestCategoryValue_Xpath);
            Assert.AreEqual(Category, CategoryUI);
            Report.WriteLine("Verifying  comment in status/History Tab");
            claimHistoryTab = DBHelper.GetInsuranceClaimHistorydetails(Claimnumber.ToString());
            string Comments = Gettext(attributeName_xpath, LatestCommentValue_Xpath);
            Assert.AreEqual(claimHistoryTab.Comments, Comments);
        }
        [When(@"I updated a doctype to new doctype from Amend Edit page and click On the Resubmit Claim button")]
        public void WhenIUpdatedADoctypeToNewDoctypeFromAmendEditPageAndClickOnTheResubmitClaimButton()
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            Click(attributeName_xpath, DocumentDropdown_Xpath);
            Thread.Sleep(3000);
            SelectDropdownValueFromList(attributeName_xpath, DocumentDropdownValues_Xpath, orginalDoctype);
            scrollpagedown();
            scrollpagedown();
            Click(attributeName_id, SubmitClaimButton_Id);
            GlobalVariables.webDriver.WaitForPageLoad();

        }
        [Then(@"Updated doctype should be Bind in claimdetails page\.")]
        public void ThenUpdatedDoctypeShouldBeBindInClaimdetailsPage_()
        {
            SendKeys(attributeName_xpath, ClaimList_ClaimNumberSearchBox_Xpath, Claimnumber.ToString());
            crmWait.ClickAndWait(attributeName_xpath, ClaimList_Grid_ClaimNumbers);
            crmWait.ClickAndWait(attributeName_xpath, DocumentTab_Xpath);
            string changedDoctype = Gettext(attributeName_xpath, ClaimDetail2ndDoctypeName_Xpath);
            if (changedDoctype == orginalDoctype)
            { Report.WriteLine("Updated Doctype is binded in claimdeatils page"); }
            else
            { Report.WriteFailure("Updated Doctype is not binded in claimdeatils page"); }
        }

        [When(@"I delete a doc from Amend Edit page and click On the Resubmit Claim button")]
        public void WhenIDeleteADocFromAmendEditPageAndClickOnTheResubmitClaimButton()
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            DeletefileName = GetAttribute(attributeName_xpath, "//*[@id='page-content-wrapper']/div[2]/div[1]/div[19]/div[3]/div[2]/div[2]/div/div[2]/div/div/div/span/a", "data-filename");
            Click(attributeName_xpath, AdditionalRemoveButton_Xpath);
            scrollpagedown();
            scrollpagedown();
            Click(attributeName_id, SubmitClaimButton_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
        }
        [Then(@"Deleted doc should not be available in detail page")]
        public void ThenDeletedDocShouldNotBeAvailableInDetailPage()
        {
            SendKeys(attributeName_xpath, ClaimList_ClaimNumberSearchBox_Xpath, Claimnumber.ToString());
            crmWait.ClickAndWait(attributeName_xpath, ClaimList_Grid_ClaimNumbers);
            crmWait.ClickAndWait(attributeName_xpath, DocumentTab_Xpath);
            Thread.Sleep(3000);
            Report.WriteLine("I will see a list associated document");
            IList<IWebElement> associated_documents = GlobalVariables.webDriver.FindElements(By.XPath(DetailsTab_DocumentsTab_AssciateDocument_Xpath));
            for (int i = 0; i < associated_documents.Count; i++)
            {
                Report.WriteLine("Associated Document is :" + associated_documents[i].Text);
                associated_documentsfromUI.Add(associated_documents[i].Text);

            }
            CollectionAssert.DoesNotContain(associated_documentsfromUI, DeletefileName);

        }

        [Then(@"the entry is not editable\.")]
        public void ThenTheEntryIsNotEditable_()
        {

            VerifyElementNotPresent(attributeName_xpath, ".//*[@id='InsuranceClaimHistoryGrid']/tbody/tr/td/a", "Edit Icon");

        }
    }
}
