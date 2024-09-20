using CRM.UITest.Entities;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.ServiceAccessLayer;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.ShipmentList.ShipmentList_CustomReportsDelete_AllUsers
{
    [Binding]
    public class ShipmentList_CustomReportsDelete_AllUsersSteps: Shipmentlist
    {        
        [Given(@"I navigate to shipment list (.*) page")]
        public void GivenINavigateToShipmentListPage(string ShipmentList_Header)
        {
            Report.WriteLine("I navigate to shipment list page");
            VerifyElementVisible(attributeName_xpath, ShipmentList_Title_Xpath, "Shipment List");
            string ShipmentlistHeader_UI = Gettext(attributeName_xpath, ShipmentList_Title_Xpath);
            Assert.AreEqual(ShipmentList_Header, ShipmentlistHeader_UI);
        }

        [Given(@"I create a customreport (.*)")]
        public void GivenICreateACustomreport(string Customreport)
        {
            Click(attributeName_id, ShipmentList_ShowFilter_link_Id);
            SendKeys(attributeName_id, FilterSection_OriginCity_Textbox_Id, "Los Angeles");
            SendKeys(attributeName_id, FilterSection_DestCity_Textbox_Id, "Miami");
            Click(attributeName_id, FilterSection_SaveReport_button_Id);
            VerifyElementPresent(attributeName_xpath, SaveReport_ModalPopUp_Text_Xpath, "Save Report");
            Thread.Sleep(1000);
            SendKeys(attributeName_id, NameThisReport_Textbox_Id, Customreport);
            Click(attributeName_id, SaveReport_ModalPopUp_Ok_button_Id);
        }

        [Given(@"I have selected the custom report (.*)which i created")]
        public void GivenIHaveSelectedTheCustomReportWhichICreated(string Customreport)
        {
            Report.WriteLine("I have selected the custom report which i selected");
            Thread.Sleep(1000);
            Click(attributeName_xpath, ShipmentList_FilteredReports_Xpath);
            SendKeys(attributeName_xpath, SelectAReportSearchBoxnShipmentList_Xpath, Customreport);

            Click(attributeName_xpath, "//*[@id='ReportType_chosen']/div/ul/li[2]");
        }
        
        [Given(@"I Clicked on Show Filter link")]
        public void GivenIClickedOnShowFilterLink()
        {
            Report.WriteLine("I clicked on show filter link");
            Click(attributeName_id, ShipmentList_ShowFilter_link_Id);
        }
                
        [When(@"I click on Delete Report link")]
        public void WhenIClickOnDeleteReportLink()
        {
            Report.WriteLine("I click on Delete Report link");
            Click(attributeName_id, FilterSection_DeleteReport_button_Id);
        }
        
        [When(@"I click on Cancel button in Delete report modal")]
        public void WhenIClickOnCancelButtonInDeleteReportModal()
        {
            Report.WriteLine("I click on Cancel button of Delete report modal");
            Click(attributeName_xpath, FilterSection_DeleteReport_Cancel_Xpath);
        }
        
        [When(@"I click on Yes button in Delete Report modal")]
        public void WhenIClickOnYesButtonInDeleteReportModal()
        {
            Report.WriteLine("I click on Yes button in Delete Report modal");
            Thread.Sleep(1000);
            Click(attributeName_id, FilterSection_DeleteReport_Yes_Id);
        }
        
        [Then(@"I should be displayed with Delete Report link")]
        public void ThenIShouldBeDisplayedWithDeleteReportLink()
        {
            Report.WriteLine("I should be displayed with Delete Report link");
            VerifyElementVisible(attributeName_id, FilterSection_DeleteReport_button_Id, "Delete Report");
        }
        
        [Then(@"I should be displayed with Delete Report modal pop up")]
        public void ThenIShouldBeDisplayedWithDeleteReportModalPopUp()
        {
            Report.WriteLine("I should be displayed with Delete Report modal");
            VerifyElementVisible(attributeName_xpath, FilterSection_DeleteReport_Header_Xpath, "");
        }
        
        [Then(@"I will be navigated to shipment list page")]
        public void ThenIWillBeNavigatedToShipmentListPage()
        {
            Report.WriteLine("I will be navigated to Shipment List page");
            VerifyElementVisible(attributeName_xpath, ShipmentList_Header_Xpath, "Shipment List");
        }
        
        [Then(@"Reports in grid will be displayed still")]
        public void ThenReportsInGridWillBeDisplayedStill()
        {
            Report.WriteLine("Reports in grid will be displayed still");
            VerifyElementVisible(attributeName_xpath, ShipmentListGrid_HeaderValues_Xpath, "");
        }
        
        [Then(@"Show filter section will be displayed still")]
        public void ThenShowFilterSectionWillBeDisplayedStill()
        {
            Report.WriteLine("Show filter section will be displayed still");
            VerifyElementVisible(attributeName_id, ShipmentList_HideFilter_link_Id, "Hide Filters");
        }
        
        [Then(@"the Report will be default to Select a Report")]
        public void ThenTheReportWillBeDefaultToSelectAReport()
        {
            Report.WriteLine("The report dropdwon will defaulted to Select a Report");
            Thread.Sleep(1000);
            WaitForElementNotVisible(attributeName_xpath, FilterSection_Status_dropdown_Xpath, "Select one or more...");
            string actText = Gettext(attributeName_xpath, ShipmentList_Report_dropdown_Xpath);
            Assert.AreEqual(actText, "Select a Report");
        }
        
        [Then(@"Shipment list will be updated to display all shipments for the past thirty days for all customers")]
        public void ThenShipmentListWillBeUpdatedToDisplayAllShipmentsForThePastThirtyDaysForAllCustomers()
        {
            Report.WriteLine("Shipment list will be updated to display all shipments for the past 30 days for all customers");
            VerifyElementVisible(attributeName_xpath, AllshipmentsTextInShipmentList_Xpath, " All shipments for the past 30 days are shown.");
        }
        
        [Then(@"Created custom report will be removed from the report list (.*)")]
        public void ThenCreatedCustomReportWillBeRemovedFromTheReportList(string Customreport)
        {
            Report.WriteLine("created custom report will be removed from the report list");
            Thread.Sleep(5000);
            WaitForElementNotVisible(attributeName_xpath, FilterSection_Status_dropdown_Xpath, "Select one or more...");
            Click(attributeName_xpath, ShipmentList_Report_dropdown_Xpath);
            SendKeys(attributeName_xpath, SelectAReportSearchBoxnShipmentList_Xpath, Customreport);
            VerifyElementNotPresent(attributeName_xpath, "//*[@id='ReportType_chosen']/div/ul/li[2]", Customreport);
        }
        
        [Then(@"Created custom report will be deleted from DB (.*)")]
        public void ThenCreatedCustomReportWillBeDeletedFromDB(string Customreport)
        {
            Report.WriteLine("Created custom report will be deleted from DB");
            var customrepdel = DBHelper.GetCustomReportName(Customreport);
            //string count = customrepdel.ToString();
            Assert.AreEqual(customrepdel.Count(), 0);                       
            
        }
    }
}
