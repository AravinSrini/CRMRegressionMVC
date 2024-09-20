using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using Rrd.ServiceAccessLayer;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Integration_List_Page
{
    [Binding]
    public class IntegrationListPage_AcceptOrDenySteps :Integration
    {
        CommonMethodsCrm crm = new CommonMethodsCrm();
        public string stationNameInGridUI = null;

        [Given(@"I am a Sales Management or a System Admin user logged in with (.*) and (.*)")]
        public void GivenIAmASalesManagementOrASystemAdminUserLoggedInWithAnd(string Username, string Password)
        {
            crm.LoginToCRMApplication(Username, Password);
        }

        [When(@"I select the status as Pending approval radio button")]
        public void WhenISelectTheStatusAsPendingApprovalRadioButton()
        {
           
            Click(attributeName_xpath, IntegrationPendingApproval_RadioButton);
            
        }
        
        [When(@"I expand the station details section")]
        public void WhenIExpandTheStationDetailsSection()
        {

              
                Report.WriteLine("expanded the Integration Request");
                Click(attributeName_xpath, IntegrationExpanbutton);
            }
           
            
        

        [Then(@"I should see the approve button available")]
        public void ThenIShouldSeeTheApproveButtonAvailable()
        {
            Report.WriteLine("The Approve button should be displayed on expanding");
            VerifyElementPresent(attributeName_id, IntegrationApprovebutton, "Approve");

        }

        [Then(@"I should see the deny button available")]
        public void ThenIShouldSeeTheDenyButtonAvailable()
        {
            Report.WriteLine("The Deny button should be displayed on expanding");
            VerifyElementPresent(attributeName_id, IntegrationDenybutton,"Deny");
        }

        [When(@"I click on Approve Button")]
        public void WhenIClickOnApproveButton()
        {
            stationNameInGridUI = Gettext(attributeName_xpath, stationNameInTheGrid);
            Click(attributeName_id, IntegrationApprovebutton);
           
        }

        [Then(@"Verify the status of the request will change from -Pending Regional Manager Approval to In Progress(.*)")]
        public void ThenVerifyTheStatusOfTheRequestWillChangeFrom_PendingRegionalManagerApprovalToInProgress(string expectedInProgressStatus)
        {
            Click(attributeName_xpath, IntegrationList_InProgress_RadioButton_xpath);
            SendKeys(attributeName_xpath, SearchIntegration, stationNameInGridUI);

            Click(attributeName_xpath, IntegrationExpanbutton);


            string stationAfterApprove = Gettext(attributeName_xpath, IntegrationInprogressStatus);
            Assert.AreEqual(stationAfterApprove,expectedInProgressStatus);
           
           
        }

      
        [When(@"I click on Deny Button")]
        public void WhenIClickOnDenyButton()
        {
            stationNameInGridUI = Gettext(attributeName_xpath, stationNameInTheGrid);

            Click(attributeName_id, IntegrationDenybutton);
        }

        [Then(@"the status of the request in the Integration List Page will change from Pending Regional Manager Approval to Completed status(.*)")]
        public void ThenTheStatusOfTheRequestInTheIntegrationListPageWillChangeFromPendingRegionalManagerApprovalToCompletedStatus(string expectedCompletedStatus)
        {
            Click(attributeName_xpath, IntegrationList_complete_RadioButton_xpath);
            SendKeys(attributeName_xpath, SearchIntegration, stationNameInGridUI);
            Click(attributeName_xpath, IntegrationExpanbutton);

            string DenyStatusCompleted = Gettext(attributeName_xpath, IntegrationDeniedStatus);
            Assert.AreEqual(DenyStatusCompleted, expectedCompletedStatus);

        }
     


    }
}
