using System;
using TechTalk.SpecFlow;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using CRM.UITest.Entities;

namespace CRM.UITest.Scripts.Dashboard.Dashboard___Pie_Chart
{
    [Binding]
    public class CSRDashboardAndCsrlistForSalesUsers_AssociatedCustomerAccountsSteps : ObjectRepository
    {
        IWebDriver driver = GlobalVariables.webDriver;
        [Given(@"I am on the CSR Dashboard page")]
        [When(@"I am on the CSR Dashboard page")]
        public void WhenIAmOnTheCSRDashboardPage()
        {
            VerifyElementVisible(attributeName_cssselector, "#page-content-wrapper > div.container-fluid.container-with-sidebar > div.page-header > div > div > h1", "Dashboard Title");
        }
       

        [Then(@"I will see the pending CSRs count for the customer account to which I am associated to on pie chart")]
        public void ThenIWillSeeThePendingCSRsCountForTheCustomerAccountToWhichIAmAssociatedToOnPieChart()
        {
            OnMouseOver(attributeName_id, DashBoardCSRPeichart_pendingCSR_Id);
            string expectedCountForPending = Gettext(attributeName_xpath, DashBoardCSRCount_Xpath);
            int DBcount = DBHelper.PendingCSRCount("Sales Delta");
            int UICount = Convert.ToInt32(expectedCountForPending);
            Assert.AreEqual(DBcount, UICount);
        }

        [Then(@"I will see the inProgress CSRs count for the customer account to which I am associated to on pie chart")]
        public void ThenIWillSeeTheInProgressCSRsCountForTheCustomerAccountToWhichIAmAssociatedToOnPieChart()
        {
            OnMouseOver(attributeName_id, DashBoardCSrPeichart_inProgress_Id);
            string expectedCountForPending = Gettext(attributeName_xpath, DashBoardCSRCount_Xpath);
            int DBCount = DBHelper.InProgressCSRCount("Sales Delta");
            int UICount = Convert.ToInt32(expectedCountForPending);
            Assert.AreEqual(DBCount, UICount);
        }

        [Then(@"I will see the denied CSRs count for the customer account to which I am associated to on pie chart")]
        public void ThenIWillSeeTheDeniedCSRsCountForTheCustomerAccountToWhichIAmAssociatedToOnPieChart()
        {
            OnMouseOver(attributeName_id, DashBoardCSrPeichart_denied_Id);
            string expectedCountForPending = Gettext(attributeName_xpath, DashBoardCSRCount_Xpath);
            int DBCount = DBHelper.DeniedCSRCount("Sales Delta");
            int UICount = Convert.ToInt32(expectedCountForPending);
            Assert.AreEqual(DBCount, UICount);
        }

    }
}
