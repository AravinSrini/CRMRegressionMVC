using System;
using System.Threading;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using CRM.UITest.Entities;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;

namespace CRM.UITest.Scripts.Integration_List_Page
{
    [Binding]
    public class IntegrationListPage_SalesManagementDetailsSteps : Integration
    {

        [When(@"I am on Integration Request List Page with title")]
        public void WhenIAmOnIntegrationRequestListPageWithTitle()
        {
            
                Click(attributeName_xpath, IntegrationMenuIcon);                
                Report.WriteLine("User see the Title Integration Request List Page ");
           
            
       }

        [When(@"I expanded the Integration Request")]
        public void WhenIExpandedTheIntegrationRequest()
        {
          
                Report.WriteLine("expanded the Integration Request");
                Click(attributeName_xpath, FirstrequestexpandIcon_xpath);                
           
            
        }


        [When(@"I click select pendingapproval requests")]
        public void WhenIClickSelectPendingapprovalRequests()
        {
            Report.WriteLine("Click on select Pendingapproval requests");

           
            WaitForElementVisible(attributeName_xpath, ".//*[@id='gridIntegrationList_wrapper']/div[1]/div[2]/div/div/div[2]/label[@for='FilterByStatusPendingApproval']", "radio");
            Click(attributeName_xpath, ".//*[@id='gridIntegrationList_wrapper']/div[1]/div[2]/div/div/div[2]/label[@for='FilterByStatusPendingApproval']");
        }

        [Then(@"I should be display with Status Bar with current status highlighted for Pendingapproval")]
        public void ThenIShouldBeDisplayWithStatusBarWithCurrentStatusHighlightedForPendingapproval()
        {
        
            var colorofHighlighted_currentstatus = GetCSSValue(attributeName_xpath,pendingRmapprovalstatusbar_xpath, "background-color");
            Assert.AreEqual("rgba(154, 0, 255, 1)", colorofHighlighted_currentstatus);
            Report.WriteLine("display with Status Bar with current status highlighted");
        }

        [Then(@"i should be displayed with Pendingapproval includes the pending RM approval")]
        public void ThenIShouldBeDisplayedWithPendingapprovalIncludesThePendingRMApproval()
        {
            string statusforpendingapproval = Gettext(attributeName_xpath, pendingRmapprovalstatusbar_label_xpath);
            //Assert.AreEqual(statusforpendingapproval, "Pending RM Aproval");
        }

        [Then(@"I should be display with Status Bar with current status highlighted for inprogress")]
        public void ThenIShouldBeDisplayWithStatusBarWithCurrentStatusHighlightedForInprogress()
        {
            var colorofHighlighted_currentstatus = GetCSSValue(attributeName_xpath, Inprogressstatusbar_xpath, "background-color");
            try
            {

                Assert.AreEqual("rgba(153, 155, 161, 1)", colorofHighlighted_currentstatus);
            }
            catch
            {

                Assert.AreEqual("rgba(74, 134, 232, 1)", colorofHighlighted_currentstatus);
            }
            
            Report.WriteLine("display with Status Bar with current status highlighted");
        }

        [Then(@"i should be displayed with In Progress includes the respective stages")]
        public void ThenIShouldBeDisplayedWithInProgressIncludesTheRespectiveStages()
        {

            Thread.Sleep(1000);
            string statusforinprogress = Gettext(attributeName_xpath, Inprogressstatusbar_label_xpath);
            Thread.Sleep(1000);
            string statusunderinprogress = statusforinprogress.Remove(0, 13);
            List<string> statusList = new List<string>(new string[] { "Waiting On Integration Team", "Pending management approval", "Documentation Sent to Customer", "Waiting on MG/CSA Configuration", "Waiting on Customer Configuration", "QA Testing" });
            
                if (statusList.Contains(statusunderinprogress))
                {
                    Console.WriteLine("inprogress includes only Waiting on Integration Team, Pending management approval, Waiting on integration team, Documentation Sent to Customer, Waiting on MG / CSA Configuration, Waiting on Customer Configuration, QA Testing");
                }
                else
                {
                    throw new System.Exception("status is mismatching");
                }
            
        }

        [When(@"I click select completed requests")]
        public void WhenIClickSelectCompletedRequests()
        {
            Report.WriteLine("Click on select complete requests");
           
            try
            {
                WaitForElementVisible(attributeName_xpath, IntegrationList_Filter_Completed_RadioButton_xpath, "radio");
                Click(attributeName_xpath, IntegrationList_Filter_Completed_RadioButton_xpath);
            }
            catch
            {
                Thread.Sleep(20000);
            }
        }

        [Then(@"I should be display with Status Bar with current status highlighted for completed status")]
        public void ThenIShouldBeDisplayWithStatusBarWithCurrentStatusHighlightedForCompletedStatus()
        {
            var colorofHighlighted_currentstatus = GetCSSValue(attributeName_xpath,Completedstatusbar_xpath, "background-color");
            Assert.AreEqual("rgba(153, 155, 161, 1)", colorofHighlighted_currentstatus);
            Report.WriteLine("display with Status Bar with current status highlighted");
        }

        [Then(@"i should be displayed with Completed includes the respective stages")]
        public void ThenIShouldBeDisplayedWithCompletedIncludesTheRespectiveStages()
        {
            Thread.Sleep(9000);
            string statusforcompleted = Gettext(attributeName_xpath, Completedstatusbar_label_xpath);
            Thread.Sleep(9000);
            if(statusforcompleted.Length >= 11)
            {
                string statusundercompleted = statusforcompleted.Remove(0, 11);
                List<string> statusList = new List<string>(new string[] { "Denied", "On hold per customer", "Inactive", "In production" });

                if (statusList.Contains(statusundercompleted))
                {
                    Console.WriteLine("Completed includes only Denied On hold per customer,Inactive,In production");
                }
                else
                {
                    throw new System.Exception("status is mismatching");
                }

            }
            
            
        }

        [Then(@"i should be displayed with Company Contact Name, Company Contact Phone and Company Contact Email")]
        public void ThenIShouldBeDisplayedWithCompanyContactNameCompanyContactPhoneAndCompanyContactEmail()
        {
            Report.WriteLine("displayed with Company Contact Name, Company Contact Phone and Company Contact Email");
            Thread.Sleep(5000);
            VerifyElementVisible(attributeName_id, CompanyContactNameTextbox_id, "textbox");
            Verifytext(attributeName_xpath, CompanyContactNamelabel_xpath, "Company Contact Name".ToUpper());
            VerifyElementVisible(attributeName_id, CompanyContactPhoneTextbox_id, "textbox");
            Verifytext(attributeName_xpath, CompanyContactPhonelabel_xpath, "Company Contact Phone".ToUpper());
            VerifyElementVisible(attributeName_id, CompanyContactEmailTextbox_id, "textbox");
            Verifytext(attributeName_xpath, CompanyContactEmaillabel_xpath, "Company Contact Email".ToUpper());
        }
        
        [Then(@"i should be displayed with IT/developer contact name,IT/developer Contact phone and IT/developer email")]
        public void ThenIShouldBeDisplayedWithITDeveloperContactNameITDeveloperContactPhoneAndITDeveloperEmail()
        {
            Report.WriteLine("displayed with IT/developer contact name,IT/developer Contact phone and IT/developer email");
            VerifyElementVisible(attributeName_id, IT_developercontactnametextbox_id, "textbox");
            Verifytext(attributeName_xpath, IT_developercontactnamelabel_xpath, "IT/dev contact name".ToUpper());
            VerifyElementVisible(attributeName_id, ITdeveloperContactphonetextbox_id, "textbox");
            Verifytext(attributeName_xpath, ITdeveloperContactphone_xpath, "it/dev contact phone".ToUpper());
            VerifyElementVisible(attributeName_id, ITdeveloperemailtextbox_id, "textbox");
            Verifytext(attributeName_xpath, ITdeveloperemaillabel, "it/dev contact email".ToUpper());
        }
        
        [Then(@"i should be displayed with Type of Integration, Year to Date shipments and Year to Date Revenue")]
        public void ThenIShouldBeDisplayedWithTypeOfIntegrationYearToDateShipmentsAndYearToDateRevenue()
        {
            Report.WriteLine("displayed with Integration, Year to Date shipments and Year to Date Revenue");
            VerifyElementVisible(attributeName_xpath, TypeofIntegrationdropdown_xpath, "dropdown");
            Verifytext(attributeName_xpath, TypeofIntegrationlabel_xpath, "Type of Integration".ToUpper());
            VerifyElementVisible(attributeName_id, YeartoDateshipmentstextbox_id, "textbox");
            Verifytext(attributeName_xpath, YeartoDateshipmentslabel_xpath, "Year to Date shipments".ToUpper());
            VerifyElementVisible(attributeName_id, YeartoDateRevenuetextbox_id, "textbox");
            Verifytext(attributeName_xpath, YeartoDateRevenuelabel_xpath, "Year to Date Revenue".ToUpper());
        }
        
        [Then(@"i should be displayed with Potential Revenue, Additional Comments, MG/CSA Total Hours, Integration Team Total Hours and Status")]
        public void ThenIShouldBeDisplayedWithPotentialRevenueAdditionalCommentsMGCSATotalHoursIntegrationTeamTotalHoursAndStatus()
        {
            Report.WriteLine("Potential Revenue, Additional Comments, MG/CSA Total Hours, Integration Team Total Hours and Status");
            MoveToElement(attributeName_id, PotentialRevenuetextbox_id);
            VerifyElementVisible(attributeName_id, PotentialRevenuetextbox_id, "textbox");
            Verifytext(attributeName_xpath, PotentialRevenuelabel_xpath, "Potential Revenue".ToUpper());            
            VerifyElementVisible(attributeName_id, AdditionalCommentstextbox_id, "textbox");
            Verifytext(attributeName_xpath, AdditionalCommentslabel_xpath, "Additional Comments".ToUpper());
            VerifyElementVisible(attributeName_id, MG_CSATotalHourstextbox_id, "textbox");
            MoveToElement(attributeName_xpath, MG_CSATotalHourslabel_xpath);
            Verifytext(attributeName_xpath, MG_CSATotalHourslabel_xpath, "mg/csa total hours".ToUpper());
            VerifyElementVisible(attributeName_id, IntegrationTeamTotalHourstextbox_id, "textbox");
            Verifytext(attributeName_xpath, IntegrationTeamTotalHourslabel_xpath, "Integration Team Total Hours".ToUpper());
            VerifyElementVisible(attributeName_xpath, IntegrationTeamStatusdropdown_xpath, "dropdown");
            Verifytext(attributeName_xpath, IntegrationTeamStatuslabel_xpath, "Integration Status".ToUpper());
        }
        
        //[Then(@"I be displaying with integration notes of Comment, Commenter, Date/Time and Public/Private")]
        //public void ThenIBeDisplayingWithIntegrationNotesOfCommentCommenterDateTimeAndPublicPrivate()
        //{
        //    Report.WriteLine("integration notes of Comment, Commenter, Date/Time and Public/Private");
        //    Verifytext(attributeName_xpath, Commentsheader_xpath, "Comment".ToUpper());
        //    Verifytext(attributeName_xpath, Commenterheader_xpath, "Commenter".ToUpper());
        //    Verifytext(attributeName_xpath, Date_timeheader_xpath, "Date/Time".ToUpper());
        //    Verifytext(attributeName_xpath, Public_privateheader_xpath, "Public/Private".ToUpper());
        //}
    }
}
