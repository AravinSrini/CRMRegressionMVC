using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.Implementations;
using CRM.UITest.Helper.Interfaces;
using CRM.UITest.Objects;
using OpenQA.Selenium.Firefox;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.ShipmentList.Shipment_List___Show_loading_icon
{
    [Binding]
    public class Shipment_List___Select_Report_Overlay_Steps : AddShipments
    {
        IAddCustomReportToDB addCustomReportToDB = new AddCustomReportToDB();

        [Given(@"I am a sales sales management operations or station owner user (.*) (.*)")]
        public void GivenIAmASalesSalesManagementOperationsOrStationOwnerUser(string username, string password)
        {
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();

            string Username = ConfigurationManager.AppSettings[username];
            string Password = ConfigurationManager.AppSettings[password];

            Report.WriteLine("Logging in as " + username);
            CrmLogin.LoginToCRMApplication(Username, Password);
        }


        [When(@"I click the report ""(.*)""")]
        public void WhenIClickTheReport(string reportName)
        {
            Report.WriteLine("Selecting the report " + reportName + " from the Report Dropdown");
            WaitForElementVisible(attributeName_id, "ReportType_chosen", "Report Dropdown");
            GlobalVariables.webDriver.WaitForPageLoad();

            Thread.Sleep(500);
            Click(attributeName_xpath, "/html/body/div[3]/div/div[2]/div[2]/div/div[1]/div/div/div[1]/div/div/div/a/span");

            if (GlobalVariables.webDriver is FirefoxDriver)
            {
                Click(attributeName_xpath, "/html/body/div[3]/div/div[2]/div[2]/div/div[1]/div/div/div[1]/div/div/div/a/span");
            }

            SendKeys(attributeName_xpath, ShipmentList_ReportDropdown_Search_Xpath, reportName);
            SelectDropdownValueFromList(attributeName_xpath, ShipmentList_ReportDropdown_Xpath, reportName);
            Thread.Sleep(500);
        }

        [Then(@"the report dropdown will not be visible")]
        public void ThenTheReportDropdownWillNotBeVisible()
        {
            Report.WriteLine("Verifying that the report dropdown collapsed");
            VerifyElementNotVisible(attributeName_xpath, "//div[contains(@id, 'ReportType_chosen')]/div[contains(@class, 'chosen-drop')]", "Report Dropdown");
        }

        [Then(@"the loading overlay will be visible on the grid")]
        public void ThenTheLoadingOverlayWillBeVisibleOnTheGrid()
        {
            Report.WriteLine("Verifying the loading overlay is visible on the grid");
            VerifyElementVisible(attributeName_xpath, "//span[contains(@class, 'style-spin fa fa-spinner fa-spin fa-3x fa-fw')]", "Loading icon");
        }

        private CustomReport generateCustomReportModel(string createdBy)
        {
            CustomReport report = new CustomReport()
            {
                CustomReportName = "Ninja Test Report",
                PickUpDateStart = DateTime.Now.AddMonths(-1),
                PickUpDateEnd = DateTime.Now,
                CreatedBy = createdBy,
                CreatedDate = DateTime.Now,               
            };

            return report;
        }

        [BeforeScenario("@111077CustomReport")]
        public void AddCustomReport()
        {
            List<string> createdByNames = new List<string>
            {
                "currentsprint.operations@dls-ww.com",
                "currentsprint.sales@dls-ww.com",
                "currentsprint.salesmanager@dls-ww.com",
                "currentsprint.stationowner@dls-ww.com",
                "stephy.rodrigues@saggezza.com",
                "currentsprint.inquiry@dls-ww.com"
            };
            DBHelper.RemoveUserCustomReportMappingFromDB("Ninja Test Report");
            DBHelper.RemoveCustomReportsFromDB("Ninja Test Report");

            CustomReport report = generateCustomReportModel("currentsprint.operations@dls-ww.com");
            addCustomReportToDB.AddCustomReport(report);

            report = generateCustomReportModel("currentsprint.sales@dls-ww.com");
            addCustomReportToDB.AddCustomReport(report);

            report = generateCustomReportModel("currentsprint.salesmanager@dls-ww.com");
            addCustomReportToDB.AddCustomReport(report);

            report = generateCustomReportModel("currentsprint.stationowner@dls-ww.com");
            addCustomReportToDB.AddCustomReport(report);

            report = generateCustomReportModel("stephy.rodrigues@saggezza.com");
            addCustomReportToDB.AddCustomReport(report);

            report = generateCustomReportModel("currentsprint.inquiry@dls-ww.com");
            addCustomReportToDB.AddCustomReport(report);
        }
    }
}
