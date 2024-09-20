using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Objects;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace CRM.UITest.Scripts.Integration_List_Page
{
    [Binding]
    public class IntegrationListDetails_CommentVisibilitySteps:Integration
    {
        CommonMethodsCrm crm = new CommonMethodsCrm();

        [Given(@"I am an operations,sales or station owner user (.*), (.*)")]
        public void GivenIAmAnOperationsSalesOrStationOwnerUser(string userName, string password)
        {
            crm.LoginToCRMApplication(userName, password);
           
        }
        
        [Given(@"I am system admin or sales management user (.*), (.*)")]
        public void GivenIAmSystemAdminOrSalesManagementUser(string userName, string password)
        {
            crm.LoginToCRMApplication(userName, password);
        }

        [When(@"I click all requests")]
        public void WhenIClickAllRequests()
        {            
            
                Report.WriteLine("Click on All requests radio button");
               
                WaitForElementVisible(attributeName_xpath, IntegrationList_Filter_All_RadioButton_xpath, "radio");
                Click(attributeName_xpath, IntegrationList_Filter_All_RadioButton_xpath);
          
           
        }


        [Then(@"I will be displayed withonly public integration notes for logged in user (.*)")]
        public void ThenIWillBeDisplayedWithonlyPublicIntegrationNotesForLoggedInUser(string claim)
        {
            Thread.Sleep(3000);            
            IList<IWebElement> AllUIComments = GlobalVariables.webDriver.FindElements(By.XPath(Allcomments_Xpath));
            List<string> AllComments = new List<string>();
            foreach (IWebElement element in AllUIComments)
            {
                AllComments.Add(element.ToString());
            }

            if (claim != "IntegrationNotesCommentsVisibility")
            {
                //Db verification
                int CommentsCountUI = AllUIComments.Count;
                string getStationName = Gettext(attributeName_xpath, FirstStationName_Xpath);
                string getCompanyName = Gettext(attributeName_xpath, FisrtCompanyName_Xpath);
                Thread.Sleep(5000);                
                int CommentsCountDb = DBHelper.GetPublicCommentsForIntegrationRequest(getStationName, getCompanyName).Count;
                Thread.Sleep(3000);
                Assert.AreEqual(CommentsCountUI, CommentsCountDb);
                Report.WriteLine("I will be displayed with only Public integration notes");
            }
            else
            {
                throw new System.Exception("I am displaying with both public and private");
            }             
            
        }

        [Then(@"I will be displayed withpublic or private integration notes for logged in user (.*)")]
        public void ThenIWillBeDisplayedWithpublicOrPrivateIntegrationNotesForLoggedInUser(string claim)
        {
            Thread.Sleep(3000);            
            IList<IWebElement> AllCommentsUI = GlobalVariables.webDriver.FindElements(By.XPath(Allcomments_Xpath));
            List<string> AllComments = new List<string>();
            foreach (IWebElement element in AllCommentsUI)
            {
                AllComments.Add(element.Text.ToString());
            }

            if (claim == "IntegrationNotesCommentsVisibility")
            {
                //comment visibility verification                            
                int CommentsCountUI = AllCommentsUI.Count;
                string getStationName = Gettext(attributeName_xpath, FirstStationName_Xpath);
                string getCompanyName = Gettext(attributeName_xpath, FisrtCompanyName_Xpath);                
                Thread.Sleep(5000);
                int CommentsCountDB = DBHelper.GetAllCommentsForIntegrationRequest(getStationName, getCompanyName).Count;
                Thread.Sleep(5000);
                Assert.AreEqual(CommentsCountUI, CommentsCountDB);
                Report.WriteLine("I will be displayed with Private and Public integration notes");
            }
            else
            {
                throw new System.Exception("I am displaying with only public");
            }             
            
        }
    }
}
