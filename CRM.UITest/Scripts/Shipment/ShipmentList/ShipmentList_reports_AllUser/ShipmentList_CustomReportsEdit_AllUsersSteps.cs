using CRM.UITest.Entities.Proxy;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.ServiceAccessLayer;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using CRM.UITest.Helper.Common;
using CRM.UITest.Helper.Implementations.CustomReportXML;
using System.Net.Http;
using System.Xml.Linq;
using System.Threading;

namespace CRM.UITest
{
    [Binding]
    public class ShipmentList_CustomReportsEdit_AllUsersSteps : Shipmentlist
    {
        [When(@"I have selected the '(.*)' which i created")]
        public void WhenIHaveSelectedTheWhichICreated(string customreport)
        {
            Report.WriteLine("user selected the customer report from dropdown");
            Click(attributeName_xpath, ShipmentList_FilteredReports_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, ShipmentList_Report_dropdown_Values_Xpath, customreport);

        }

        [When(@"I have selected the '(.*)' which i created and the same report name already existed with in the station")]
        public void WhenIHaveSelectedTheWhichICreatedAndTheSameReportNameAlreadyExistedWithInTheStation(string customreport)
        {
            Report.WriteLine("user selected the customer report from dropdown");
            Click(attributeName_xpath, ShipmentList_FilteredReports_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, ShipmentList_Report_dropdown_Values_Xpath, customreport);
        }

        [When(@"I selected the shared access")]
        public void WhenISelectedTheSharedAccess()
        {
            Report.WriteLine("user selected the customer report from dropdown");
            Click(attributeName_xpath, ShipmentList_shareaccess_checkbox_Xpath);
        }

        [When(@"I click on Update Report Parameters button")]
        public void WhenIClickOnUpdateReportParametersButton()
        {
            Report.WriteLine("user selected the customer report from dropdown");
            Click(attributeName_xpath, updatereport_button_Xpath);
            Thread.Sleep(20000);
        }

        [Then(@"I should be displayed with '(.*)'")]
        public void ThenIShouldBeDisplayedWith(string Reporteditwillbeforallcustomers)
        {
            Report.WriteLine("ShouldNotBeDisplayedWithCustomerSelectionOption");
            Verifytext(attributeName_xpath, ShipmentList_Reporteditwillbeforall_Xpath, "Report edit will be for all customers.");
        }

        [Then(@"I should not be displayed with customer selection option")]
        public void ThenIShouldNotBeDisplayedWithCustomerSelectionOption()
        {
            Report.WriteLine("ShouldNotBeDisplayedWithCustomerSelectionOption");
            VerifyElementNotVisible(attributeName_xpath, ShipmentList_CustomerSelection_Xpath, "CustomerSelection");
        }

        [Then(@"I should be displayed with error message '(.*)'")]
        public void ThenIShouldBeDisplayedWithErrorMessage(string Sharedreportnamealreadyexists)
        {
            Report.WriteLine("ShouldNotBeDisplayedWithCustomerSelectionOption");
            VerifyElementPresent(attributeName_xpath, Sharedreportnamealreadyexists_error_modal, "error"); 
            Verifytext(attributeName_xpath, Sharedreportnamealreadyexists_error, Sharedreportnamealreadyexists);
        }

        [Then(@"Custom report should be saved")]
        public void ThenCustomReportShouldBeSaved()
        {

            Report.WriteLine("CustomReportShouldBeSaved and edit section closed");
            Thread.Sleep(30000);
            VerifyElementPresent(attributeName_id, ShipmentList_ShowFilter_link_Id, "saved");

        }


        [Then(@"custom report edit section should be hidden")]
        public void ThenCustomReporteditSectionShouldBeHidden()
        {
            Report.WriteLine("ShouldNotBeDisplayedWithCustomerSelectionOption");
            VerifyElementNotVisible(attributeName_xpath, updatereportsection, "customereditselection");
        }

        [Then(@"'(.*)' text should not be visible")]
        public void ThenTextShouldNotBeVisible(string Reporteditwillbeforallcustomers)
        {
            Report.WriteLine("ShouldNotBeDisplayedWithCustomerSelectionOption");
            VerifyElementNotVisible(attributeName_xpath, ShipmentList_Reporteditwillbeforall_Xpath, "Report edit will be for all customers");
        }

        [Then(@"I should be displayed with customer selection option")]
        public void ThenIShouldBeDisplayedWithCustomerSelectionOption()
        {
            Report.WriteLine("ShouldBeDisplayedWithCustomerSelectionOption");
            VerifyElementPresent(attributeName_xpath, ShipmentList_CustomerSelection_Xpath, "customerselection");
        }

        [When(@"I updated fields '(.*)','(.*)','(.*)','(.*)','(.*)','(.*)','(.*)'")]
        public void WhenIUpdatedFields(string RefNumber, string ServiceType, string StartDate, string Enddate, string OrgCity, string DestCity, string Status)
        {
            Report.WriteLine("updated fields");
            Clear(attributeName_id, FilterSection_RefNumber_Textbox_Id);
            Clear(attributeName_id, FilterSection_OriginCity_Textbox_Id);
            Clear(attributeName_id, FilterSection_DestCity_Textbox_Id);
            Click(attributeName_xpath, FilterSection_ClearAll_button_Xpath);

            switch (ServiceType)
            {
                case "LTL":
                    {
                        Click(attributeName_xpath, FilterSection_LTL_ServiceType_Checkbox_Xpath);
                        break;
                    }
                case "TL":
                    {
                        Click(attributeName_xpath, FilterSection_TL_ServiceType_Checkbox_Xpath);
                        break;
                    }
                case "PTL":
                    {
                        Click(attributeName_xpath, FilterSection_PTL_ServiceType_Checkbox_Xpath);
                        break;
                    }
                case "IML":
                    {
                        Click(attributeName_xpath, FilterSection_IML_ServiceType_Checkbox_Xpath);
                        break;
                    }
                case "DomFwd":
                    {
                        Click(attributeName_xpath, FilterSection_DomForwarding_ServiceType_Checkbox_Xpath);
                        break;
                    }
                case "Intl":
                    {
                        Click(attributeName_xpath, FilterSection_Intl_ServiceType_Checkbox_Xpath);
                        break;
                    }
            }
            SendKeys(attributeName_id, FilterSection_OriginCity_Textbox_Id, OrgCity);
            SendKeys(attributeName_id, FilterSection_DestCity_Textbox_Id, DestCity);
            Click(attributeName_xpath, FilterSection_Status_dropdown_Xpath);
            SendKeys(attributeName_xpath, ".//*[@id='status_select_chosen']/ul/li/input", Status);
            SelectDropdownValueFromList(attributeName_xpath, FilterSection_Status_List_Xpath, Status);
            SendKeys(attributeName_id, FilterSection_RefNumber_Textbox_Id, RefNumber);
 
        }


        [Then(@"I should be displayed shipment list grid for the updated report")]
        public void ThenIShouldBeDisplayedShipmentListGridForTheUpdatedReport(string UserEmail, string ServiceType, string RefNumber, string StardDate, string Enddate, string OrgCity, string DestCity, string Status, string CustomerAccount, string APIReport)
        {
            
        }


        [When(@"I updated field '(.*)'")]
        public void WhenIUpdatedField(string OrgCity)
        {
            Clear(attributeName_id, FilterSection_OriginCity_Textbox_Id);
            SendKeys(attributeName_id, FilterSection_OriginCity_Textbox_Id, OrgCity);
        }



    }
}
