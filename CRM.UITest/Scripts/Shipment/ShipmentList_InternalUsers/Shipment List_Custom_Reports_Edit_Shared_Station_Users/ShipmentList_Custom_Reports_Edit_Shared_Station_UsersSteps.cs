using CRM.UITest.Entities;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.ShipmentList_InternalUsers.Shipment_List_Custom_Reports_Edit_Shared_Station_Users
{
    [Binding]
    public class ShipmentList_Custom_Reports_Edit_Shared_Station_UsersSteps : Shipmentlist
    {
        string selectedReport;
        
        [When(@"I Update the any Report Parameter(.*)")]
        public void WhenIUpdateTheAnyReportParameter(string OrgCity)
        {
            Click(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div[2]/div/div[1]/div/div/div[3]/div[1]/div[2]/div[1]/div/div[1]/label");
            Thread.Sleep(700);
            Click(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div[2]/div/div[1]/div/div/div[3]/div[1]/div[2]/div[1]/div/div[1]/label");
            Thread.Sleep(700);


            Clear(attributeName_id, FilterSection_OriginCity_Textbox_Id);
            Thread.Sleep(500);
            SendKeys(attributeName_id, FilterSection_OriginCity_Textbox_Id, OrgCity);
        }

        [When(@"I Click on the Preview button")]
        public void WhenIClickOnThePreviewButton()
        {
            Click(attributeName_id, FilterSection_PreviewReport_button_Id);
            WaitForElementNotVisible(attributeName_xpath, "(//span[@class='style-spin fa fa-spinner fa-spin fa-3x fa-fw'])", "MVC5 Loading Symbol");
        }

        [Then(@"Update Report Parameters button and Delete Report button are disabled")]
        public void ThenUpdateReportParametersButtonAndDeleteReportButtonAreDisabled()
        {
            bool _updatebuttonDisabled = IsElementDisabled(attributeName_id, FilterSection_UpdateReport_button_Id, "Update button");
            Assert.IsTrue(_updatebuttonDisabled);

            bool _deletebuttonDisabled = IsElementDisabled(attributeName_id, FilterSection_DeleteReport_button_Id, "delete button");
            Assert.IsTrue(_deletebuttonDisabled);
        }

        [Then(@"I will see options as Preview and Save and Share buttons")]
        public void ThenIWillSeeOptionsAsPreviewAndSaveAndShareButtons()
        {
            bool _previewbuttonEnabled = IsElementEnabled(attributeName_id, FilterSection_PreviewReport_button_Id, "Preview button");
            Assert.IsTrue(_previewbuttonEnabled);

            bool _savebuttonEnabled = IsElementEnabled(attributeName_id, FilterSection_SaveReport_button_Id, "Save button");
            Assert.IsTrue(_savebuttonEnabled);

            bool _sharebuttonEnabled = IsElementEnabled(attributeName_xpath, ShipmentList_shareaccess_checkbox_Xpath, "Share button");
            Assert.IsTrue(_sharebuttonEnabled);
        }

        [Then(@"the Shipment list updated with updated results of Report Parameters(.*)service(.*)reference(.*)startdate(.*)enddate(.*)orgincity(.*)destcity(.*)status(.*)acc(.*)accnumber(.*)")]
        public void ThenTheShipmentListUpdatedWithUpdatedResultsOfReportParametersservicereferencestartdateenddateorgincitydestcitystatusaccaccnumber(string p0, string p1, string p2, string p3, string p4, string p5, string p6, string p7, string p8, string p9)
        {
            ScenarioContext.Current.Pending();
        }

        
        [When(@"I selected Custom Report which I did not create(.*),(.*)")]
        public void WhenISelectedCustomReportWhichIDidNotCreate(string UserEmail, string CustomReport)
        {
            
            IList<IWebElement> ReportDropDownList = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='ReportType_chosen']/div/ul/li"));
            List<string> _dropdownListReport = ReportDropDownList.Select(c => c.Text.ToUpper()).ToList();
            string CustomReport_Uppercase = CustomReport.ToUpper();

            bool check = _dropdownListReport.Contains(CustomReport_Uppercase);
            if (check)
            {
                bool value = DBHelper.GetReport_Not_created_by_LoggedInUser(CustomReport, UserEmail);
                if (value == false)
                {
                    SendKeys(attributeName_xpath, ".//*[@id='ReportType_chosen']/div/div/input", CustomReport);
                    Thread.Sleep(500);
                    Click(attributeName_xpath, ".//*[@id='ReportType_chosen']/div/ul/li[2]");
                }
                else
                {
                    Report.WriteLine("No Reports available without created by him, Please pass another Report name");
                }

            }

            else
            {

                Report.WriteLine("No Report matches search criteria inorder to select");

            }
           WaitForElementNotVisible(attributeName_xpath, "(//span[@class='style-spin fa fa-spinner fa-spin fa-3x fa-fw'])", "MVC5 Loading Symbol");
        }

    }
}
