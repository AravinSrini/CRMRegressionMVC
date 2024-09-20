using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
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
using System.Net.Http;
using System.Xml.Linq;
using CRM.UITest.Helper.Common;
using CRM.UITest.Helper.Implementations.CustomReportXML;
using CRM.UITest.Helper.Implementations.ShipmentList;
using CRM.UITest.Helper.ViewModel.Shipment;
using CRM.UITest.CsaServiceReference;

namespace CRM.UITest.Scripts.Shipment.ShipmentList_InternalUsers.ShipmentList_CustomReportsCreate_StationUsers
{
    [Binding]
    public class ShipmentList_CustomReportsCreate_StationUsersSteps : Shipmentlist
    {
        string CreatedCustomReport;

        [Then(@"I will not be able to see Customer selection dropdown")]
        public void ThenIWillNotBeAbleToSeeCustomerSelectionDropdown()
        {
            VerifyElementNotVisible(attributeName_xpath, ".//*[@id='CustomerType_chosen']/a", "Customer Selection Dropdown");
        }

        [Then(@"I will see the text message as The custom report will be for All Customers(.*)")]
        public void ThenIWillSeeTheTextMessageAsTheCustomReportWillBeForAllCustomers(string CustomeReport_text)
        {
            VerifyElementPresent(attributeName_xpath, FilterSection_CustomReportText_Xpath, CustomeReport_text);
        }

        [When(@"I select any Customer Account from the drop down(.*)")]
        public void WhenISelectAnyCustomerAccountFromTheDropDown(string _CustomerAccount)
        {
            Click(attributeName_xpath, ShipmentList_Customer_dropdown_Xpath);

            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_Customer_dropdownValue_Xpath));
            scrollElementIntoView(attributeName_xpath, ".//li[contains(text(), 'ZZZ - Czar Customer Test')]");
            //Click(attributeName_xpath, ".//li[contains(text(), 'ZZZ - Czar Customer Test')]");
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == _CustomerAccount)
                {
                    DropDownList[i].Click();
                    break;
                }
            }
            Thread.Sleep(500);
            //SelectDropdownValueFromList(attributeName_xpath, ShipmentList_Customer_dropdownValue_Xpath, "Pella");
        }

        [When(@"I selected any Customer which has Report(.*)")]
        public void WhenISelectedAnyCustomerWhichHasReport(string _CustomerAccount)
        {
            Click(attributeName_xpath, ShipmentList_Customer_dropdown_Xpath);
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_Customer_dropdownValue_Xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == _CustomerAccount)
                {
                    DropDownList[i].Click();
                    break;
                }
            }
        }


        [When(@"I enter the required fields(.*)(.*)(.*)(.*)(.*)")]
        public void WhenIEnterTheRequiredFields(string ServiceType, string OrgCity, string DestCity, string Status, string RefNumber)
        {
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
            SelectDropdownValueFromList(attributeName_xpath, FilterSection_Status_List_Xpath, Status);
            SendKeys(attributeName_id, FilterSection_RefNumber_Textbox_Id, RefNumber);

        }

        [When(@"enter the required fields for the Filter(.*)(.*)(.*)(.*)(.*)(.*)")]
        public void WhenEnterTheRequiredFieldsForTheFilter(string ServiceType, string StartDate, string Enddate, string OrgCity, string DestCity, string Status)
        {
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
            SelectDropdownValueFromList(attributeName_xpath, FilterSection_Status_List_Xpath, Status);

            int _startDate = Convert.ToInt32(StartDate);
            int _EndDate = Convert.ToInt32(Enddate);
            DatePickerFromCalander(attributeName_xpath, " ", _startDate, " ");
            DatePickerFromCalander(attributeName_xpath, " ", _EndDate, " ");

        }


        [When(@"I Click on Save as New button")]
        public void WhenIClickOnSaveAsNewButton()
        {
            Click(attributeName_id, FilterSection_SaveReport_button_Id);
        }

        [Then(@"I will see Save Report Modal PopUp")]
        public void ThenIWillSeeSaveReportModalPopUp()
        {
            VerifyElementPresent(attributeName_xpath, SaveReport_ModalPopUp_Text_Xpath, "Save Report");
        }

        [Then(@"I will see free form textbox")]
        public void ThenIWillSeeFreeFormTextbox()
        {
            VerifyElementPresent(attributeName_id, NameThisReport_Textbox_Id, "Report Name Textbox");
        }

        [Then(@"I will see Ok and Cancel button")]
        public void ThenIWillSeeOkAndCancelButton()
        {
            VerifyElementPresent(attributeName_xpath, SaveReport_ModalPopUp_Cancel_button_Xpath, "cancel button");
            VerifyElementPresent(attributeName_xpath, SaveReport_ModalPopUp_Ok_button_Xpath, "Ok button");

        }

        [Then(@"I Click on cancel button closes the Save Report Modal Pop")]
        public void ThenIClickOnCancelButtonClosesTheSaveReportModalPop()
        {
            Click(attributeName_xpath, "(//a[@class='closeOverlay btn confirm-cancel'])[1]");
            Thread.Sleep(700);
            VerifyElementNotVisible(attributeName_xpath, SaveReport_ModalPopUp_Text_Xpath, "Save Report");


        }

        [When(@"enter the required filters(.*)and(.*)")]
        public void WhenEnterTheRequiredFiltersand(string OrgCity, string DestCity)
        {
            SendKeys(attributeName_id, FilterSection_OriginCity_Textbox_Id, OrgCity);
            SendKeys(attributeName_id, FilterSection_DestCity_Textbox_Id, DestCity);
        }


        [When(@"I enter the required filters(.*)(.*)")]
        public void WhenIEnterTheRequiredFilters(string OrgCity, string DestCity)
        {
            SendKeys(attributeName_id, FilterSection_OriginCity_Textbox_Id, OrgCity);
            SendKeys(attributeName_id, FilterSection_DestCity_Textbox_Id, DestCity);
        }

        [Then(@"I will be able to save the Report(.*)")]
        public void ThenIWillBeAbleToSaveTheReport(string ReportName)
        {
            CreatedCustomReport = DBHelper._checkDuplicate_CustomReportName(ReportName);
            SendKeys(attributeName_id, NameThisReport_Textbox_Id, CreatedCustomReport);
            Click(attributeName_xpath, SaveReport_ModalPopUp_Ok_button_Xpath);

            WaitForElementVisible(attributeName_xpath, ShipmentList_Header_Xpath, "Shipment List Header");
            Thread.Sleep(17000);
        }

        [Then(@"I will be able to see shared Report in drop down(.*)")]
        public void ThenIWillBeAbleToSeeSharedReportInDropDown(string shared_CustomReport)
        {
            Click(attributeName_xpath, ShipmentList_FilteredReports_Xpath);
            SendKeys(attributeName_xpath, ".//*[@id='ReportType_chosen']/div/div/input", shared_CustomReport);
            Click(attributeName_xpath, ".//*[@id='ReportType_chosen']/div/ul/li[2]");
        }


        [Then(@"Created share Custom Report should Updated in Database (.*)")]
        public void ThenCreatedShareCustomReportShouldUpdatedInDatabase(string ReportName)
        {
            CreatedCustomReport = DBHelper._checkDuplicate_CustomReportName(ReportName);
            SendKeys(attributeName_id, NameThisReport_Textbox_Id, CreatedCustomReport);
            Click(attributeName_xpath, SaveReport_ModalPopUp_Ok_button_Xpath);

            CustomReport CR = DBHelper._CustomReport_Data(CreatedCustomReport);
            Assert.AreEqual("true", (CR.IsSharedReport));
            
        }

       
        [Then(@"I will be able to see Report data in database(.*)OriginCity(.*)DestinationCity(.*)")]
        public void ThenIWillBeAbleToSeeReportDataInDatabaseOriginCityDestinationCity(string ReportName, string OrgCity, string DestCity)
        {
            CustomReport CR = DBHelper._CustomReport_Data(CreatedCustomReport);
            Assert.AreEqual(OrgCity, (CR.OriginCity));
            Assert.AreEqual(DestCity, (CR.DestinationCity));
        }


        [Then(@"I will see share Custom Report is Updated in Database(.*)")]
        public void ThenIWillSeeShareCustomReportIsUpdatedInDatabase(string reportname)
        {
            CustomReport CR = DBHelper._CustomReport_Data(CreatedCustomReport);
            Assert.AreEqual(reportname, (CR.IsSharedReport));
        }


        [Then(@"the I will not see Custom Filter section")]
        public void ThenTheIWillNotSeeCustomFilterSection()
        {
            VerifyElementNotVisible(attributeName_xpath, FilterSection_ServiceType_Text_Xpath, "FilterSection ServiceType");
        }

        [Then(@"I will be able to see created Report in the Report dropdown")]
        public void ThenIWillBeAbleToSeeCreatedReportInTheReportDropdown()
        {
            Click(attributeName_xpath, ShipmentList_Report_dropdown_Xpath);
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_Report_dropdown_Values_Xpath));

            List<string> _ReportDropdown_List = DropDownList.Select(a => a.Text).ToList();
            Assert.IsTrue(_ReportDropdown_List.Contains(CreatedCustomReport));

        }

        [Then(@"I will see Customer Account dropdown")]
        public void ThenIWillSeeCustomerAccountDropdown()
        {
            VerifyElementPresent(attributeName_xpath, ShipmentList_Customer_dropdown_Xpath, "Customer Account Dropdown");
        }

        [Then(@"I will not see Custom Report text(.*)")]
        public void ThenIWillNotSeeCustomReportText(string CustomeReport_text)
        {
            VerifyElementNotVisible(attributeName_xpath, FilterSection_CustomReportText_Xpath, CustomeReport_text);
        }

        

        [When(@"I select any Custom Report from Report Dropdown(.*)")]
        public void WhenISelectAnyCustomReportFromReportDropdown(string _CustomReport)
        {
            IList<IWebElement> ReportDropDownList = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='ReportType_chosen']/div/ul/li"));
            List<string> _dropdownListReport = ReportDropDownList.Select(c => c.Text.ToUpper()).ToList();
            string CustomReport_Uppercase = _CustomReport.ToUpper();

            bool check = _dropdownListReport.Contains(CustomReport_Uppercase);
            if (check)
            {
                SendKeys(attributeName_xpath, ".//*[@id='ReportType_chosen']/div/div/input", _CustomReport);
                Thread.Sleep(500);
                Click(attributeName_xpath, ".//*[@id='ReportType_chosen']/div/ul/li[2]");
            }
            else
            {
                Report.WriteLine("No Report matches search criteria inorder to select");
            }
            
        }



        [Then(@"the Shipment list will be displayed for the created Report(.*)reference(.*)startdate(.*)enddate(.*)orgincity(.*)destcity(.*)status(.*)acc(.*)")]
        public void ThenTheShipmentListWillBeDisplayedForTheCreatedReportreferencestartdateenddateorgincitydestcitystatusacc(string servType, string RefNumber, string StardDate, string Enddate, string OrgCity, string DestCity, string Status_UI, string CustomerAccount)
        {


            ShipmentListReponse results = null;
            int SetUpID = DBHelper.GetAccountIdforAccountName(CustomerAccount);
            CustomerAccount value = DBHelper.GetAccountDetails(SetUpID);
            string Num = value.CsaCustomerNumber.ToString();
            int _number = Convert.ToInt32(Num);
            string NoShipmentEntries = "Showing 0 to 0 of 0 entries";
            string ShipmentEntries = Gettext(attributeName_xpath, ".//*[@id='ShipmentGrid_wrapper']/div[2]/div/div[1]/div");
            //if (NoShipmentEntries == ShipmentEntries)
            //{
            //    string NoResultsFound_Text_Actual = Gettext(attributeName_xpath, ".//td[contains(text(), 'No Results Found')]");
            //    Assert.AreEqual("No Results Found", NoResultsFound_Text_Actual);
            //}
            //else
            //{
                List<String> ShipList = new List<string>();

                if (servType == "International")
                {

                    DateTime Startdt = new DateTime();
                    Startdt = Convert.ToDateTime(StardDate);


                    DateTime Enddt = new DateTime();
                    Enddt = Convert.ToDateTime(Enddate);


                    string servicelevel = "";
                    string mode = "airexport,airimport,oceanexport,oceanimport";

                    ShipmentsSoapClient csaClient = new ShipmentsSoapClient();

                    string stats = "Delayed,OSD,Rejected,New,Pending,Pre-Plan,Unscheduled,Tendered,Rated,Booked,Appointment Scheduled,Delivered,Pending Documents,Customer Web Shipment,Scheduled,Picked Up,In Transit,Routing Alerted,Confirmed on Board,Confirmed on Connection,Delivered by Vendor,En Route,On Hand Connection,On Hand Origin,On Hand Dest,Out for Delivery,Arrived at Delivery Location,Delivered,Approved for Invoicing,Invoiced,Posted to SAP,All Costs Verified,Over/ Short/ Damaged,On Hand Destination,Cancelled,Cancelled Shipment,Web,Scheduled";
                    results = csaClient.ShipmentListParm(_number.ToString(), Startdt.ToString(), Enddt.ToString(), "", "airexport,airimport,oceanexport,oceanimport", "", stats, "", "", "","");


                }
                else if (servType == "DomForwarding")
                {
                    DateTime Startdt = new DateTime();
                    Startdt = Convert.ToDateTime(StardDate);


                    DateTime Enddt = new DateTime();
                    Enddt = Convert.ToDateTime(Enddate);


                    string servicelevel = "NF,SD,1D,1A,2D,2A,3D,3A,5D,WG,EU,LC,LT,FT,CH";
                    string _mode = "domair";

                    ShipmentsSoapClient csaClient = new ShipmentsSoapClient();

                    string stats = "Delayed,OSD,Rejected,New,Pending,Pre-Plan,Unscheduled,Tendered,Rated,Booked,Appointment Scheduled,Delivered,Pending Documents,Customer Web Shipment,Scheduled,Picked Up,In Transit,Routing Alerted,Confirmed on Board,Confirmed on Connection,Delivered by Vendor,En Route,On Hand Connection,On Hand Origin,On Hand Dest,Out for Delivery,Arrived at Delivery Location,Delivered,Approved for Invoicing,Invoiced,Posted to SAP,All Costs Verified,Over/ Short/ Damaged,On Hand Destination,Cancelled,Cancelled Shipment,Web,Scheduled";
                    results = csaClient.ShipmentListParm(_number.ToString(), Startdt.ToString(), Enddt.ToString(), "", _mode, servicelevel, stats, "", "", "","");

                }
                
                List<string> ShipValue = results.Shipments.Select(a => a.Housebill).ToList();
                foreach (var t in ShipValue)
                {
                    ShipList.Add(t);
                }
                string g = Gettext(attributeName_xpath, ".//*[@id='ShipmentGrid']/tbody/tr[1]/td[1]");
                string[] f = g.Split('\r');

                Assert.AreEqual(results.Shipments[0].Housebill, f[0]);
                Click(attributeName_xpath, "//*[@id='ShipmentGrid_length']/label/select");
                // SelectDropdownlistvalue(attributeName_xpath, ShipmentList_TopGrid_ViewDropdownValues_Xpath, "ALL");


                IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_TopGrid_ViewDropdownValues_Xpath));
                int DropDownCount = DropDownList.Count;
                for (int i = 0; i < DropDownCount; i++)
                {
                    if (DropDownList[i].Text == "ALL")
                    {
                        DropDownList[i].Click();
                        break;
                    }
                }


                IList<IWebElement> UIShipments = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentListGrid_RefNumAllValues_Xpath));
                List<string> UIValue = new List<string>();

                if (ShipList.Count > 1)
                {

                    for (int p = 0; p < UIShipments.Count; p++)
                    {
                        string _RefNumber = UIShipments[p].Text;
                        UIValue.Add(_RefNumber);
                    }

                    Assert.AreEqual(ShipList.Count, UIValue.Count);
                    Report.WriteLine("Displaying list in the UI is matching with API results");
                }
                else
                {
                    Report.WriteLine("No Shipments found");
                    VerifyElementPresent(attributeName_xpath, ShipmentList_NoRecords_Xpath, "No Records Found");
                }


            //}
        }

        [When(@"I create Custom Report(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void WhenICreateCustomReport(string servType, string StardDate, string Enddate, string Status_UI, string OrgCity, string DestCity, string RefNumber)
        {
            if (servType == "International")
            {
                Click(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div[2]/div/div[1]/div/div/div[3]/div[1]/div[2]/div[1]/div/div[6]/label");
            }

            if (servType == "DomForwarding")
            {
                Click(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div[2]/div/div[1]/div/div/div[3]/div[1]/div[2]/div[1]/div/div[5]/label");
            }
            Click(attributeName_xpath, ".//*[@id='SchedulePickupDates']");
            Clear(attributeName_xpath, "html/body/div[8]/div[1]/div[1]/input");

            SendKeys(attributeName_xpath, "html/body/div[8]/div[1]/div[1]/input", StardDate);
            Clear(attributeName_xpath, "html/body/div[8]/div[2]/div[1]/input");
            SendKeys(attributeName_xpath, "html/body/div[8]/div[2]/div[1]/input", Enddate);
            Click(attributeName_xpath, "html/body/div[8]/div[3]/div/button");
        }

        [Then(@"I selecting any customer Account(.*)(.*)")]
        public void ThenISelectingAnyCustomerAccount(string CustomerAccount, string UserType)
        {
            if (UserType == "Internal")
            {
                Click(attributeName_xpath, ShipmentList_Customer_dropdown_Xpath);
                IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_Customer_dropdownValue_Xpath));
                int DropDownCount = DropDownList.Count;
                for (int i = 0; i < DropDownCount; i++)
                {
                    if (DropDownList[i].Text == CustomerAccount)
                    {
                        DropDownList[i].Click();
                        break;
                    }
                }

                string Customer_Text_Actual = Gettext(attributeName_xpath, ShipmentList_Customer_dropdown_Xpath);
                Assert.IsTrue(Customer_Text_Actual.Contains(CustomerAccount));
            }
        }

        [Then(@"the Shipment list for Internal User will be displayed for the created Report(.*)reference(.*)startdate(.*)enddate(.*)orgincity(.*)destcity(.*)status(.*)acc(.*)StationId(.*)")]
        public void ThenTheShipmentListForInternalUserWillBeDisplayedForTheCreatedReportreferencestartdateenddateorgincitydestcitystatusaccStationId(string servType, string RefNumber, string StardDate, string Enddate, string OrgCity, string DestCity, string Status_UI, string CustomerAccount, string StationData)
        {
            ShipmentListReponse results = null;
            string[] values = StationData.Split(',');
            List<string> StatID = new List<string>();
            List<String> ShipList = new List<string>();

            foreach (var v in values)
            {
                StatID.Add(v);
            }
            for (int i = 0; i < StatID.Count; i++)
            {



                //Calling db to get account number for the mapped station 
                string DBdetails = DBHelper.GetStationNameonStationID(StatID[i]);
                List<CustomerAccount> listvalue = DBHelper.GetAccountsMappedforStation(DBdetails);

                for (int k = 0; k < listvalue.Count; k++)
                {
                    if (listvalue[k].TmsSystem == "CSA" || listvalue[k].TmsSystem == "BOTH")
                    {
                        string b = listvalue[k].CsaCustomerNumber.ToString();
                        int _number = Convert.ToInt32(b);
                        DateTime Startdt = new DateTime();
                        Startdt = Convert.ToDateTime(StardDate);
                        //string h = Startdt.ToString();

                        DateTime Enddt = new DateTime();
                        Enddt = Convert.ToDateTime(Enddate);
                        if (servType == "International")
                        {
                            string servicelevel = "";
                            string mode = "airexport,airimport,oceanexport,oceanimport";

                            ShipmentsSoapClient csaClient = new ShipmentsSoapClient();

                            string stats = "Delayed,OSD,Rejected,New,Pending,Pre-Plan,Unscheduled,Tendered,Rated,Booked,Appointment Scheduled,Delivered,Pending Documents,Customer Web Shipment,Scheduled,Picked Up,In Transit,Routing Alerted,Confirmed on Board,Confirmed on Connection,Delivered by Vendor,En Route,On Hand Connection,On Hand Origin,On Hand Dest,Out for Delivery,Arrived at Delivery Location,Delivered,Approved for Invoicing,Invoiced,Posted to SAP,All Costs Verified,Over/ Short/ Damaged,On Hand Destination,Cancelled,Cancelled Shipment,Web,Scheduled";
                            results = csaClient.ShipmentListParm(_number.ToString(), Startdt.ToString(), Enddt.ToString(), "", "airexport,airimport,oceanexport,oceanimport", "", stats, "", "", "","");
                        }

                        else
                        {

                            string servicelevel = "NF,SD,1D,1A,2D,2A,3D,3A,5D,WG,EU,LC,LT,FT,CH";
                            string _mode = "domair";
                            ShipmentsSoapClient csaClient = new ShipmentsSoapClient();

                            string stats = "Delayed,OSD,Rejected,New,Pending,Pre-Plan,Unscheduled,Tendered,Rated,Booked,Appointment Scheduled,Delivered,Pending Documents,Customer Web Shipment,Scheduled,Picked Up,In Transit,Routing Alerted,Confirmed on Board,Confirmed on Connection,Delivered by Vendor,En Route,On Hand Connection,On Hand Origin,On Hand Dest,Out for Delivery,Arrived at Delivery Location,Delivered,Approved for Invoicing,Invoiced,Posted to SAP,All Costs Verified,Over/ Short/ Damaged,On Hand Destination,Cancelled,Cancelled Shipment,Web,Scheduled";
                            results = csaClient.ShipmentListParm(_number.ToString(), Startdt.ToString(), Enddt.ToString(), "", _mode, servicelevel, stats, "", "", "","");

                        }
                        List<string> ShipValue = results.Shipments.Select(a => a.Housebill).ToList();
                        foreach (var t in ShipValue)
                        {
                            ShipList.Add(t);
                        }
                    }
                }
            }

            string g = Gettext(attributeName_xpath, ".//*[@id='ShipmentGrid']/tbody/tr[1]/td[1]");
            string[] f = g.Split('\r');

            Assert.AreEqual(ShipList[0], f[0]);
            Click(attributeName_xpath, "//*[@id='ShipmentGrid_length']/label/select");
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_TopGrid_ViewDropdownValues_Xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == "ALL")
                {
                    DropDownList[i].Click();
                    break;
                }
            }
            IList<IWebElement> UIShipments = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentListGrid_RefNumAllValues_Xpath));
            List<string> UIValue = new List<string>();

            if (ShipList.Count > 1)
            {

                for (int p = 0; p < UIShipments.Count; p++)
                {
                    string _RefNumber = UIShipments[p].Text;
                    UIValue.Add(_RefNumber);
                }

                Assert.AreEqual(ShipList.Count, UIValue.Count);
                Report.WriteLine("Displaying list in the UI is matching with API results");
            }
            else
            {
                Report.WriteLine("No Shipments found");
                VerifyElementPresent(attributeName_xpath, ShipmentList_NoRecords_Xpath, "No Records Found");
            }
        }

        [When(@"I select a report with name as Select a Report(.*)")]
        public void WhenISelectAReportWithNameAsSelectAReport(string SelectReport_text)
        {
            Click(attributeName_xpath, ShipmentList_Report_dropdown_Xpath);
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_Report_dropdown_Values_Xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == SelectReport_text)
                {
                    DropDownList[i].Click();
                    break;
                }
            }
        }

        [Then(@"the Shipment List will be displayed for Thirtydays(.*)(.*)")]
        public void ThenTheShipmentListWillBeDisplayedForThirtydays(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I have selected any Standard Report(.*)")]
        public void WhenIHaveSelectedAnyStandardReport(string _StandardReport)
        {
            Click(attributeName_xpath, ShipmentList_Report_dropdown_Xpath);
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_Report_dropdown_Values_Xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == _StandardReport)
                {
                    DropDownList[i].Click();
                    break;
                }
            }
        }

        [Then(@"the Shipment List will display for the selected Standard Report(.*)")]
        public void ThenTheShipmentListWillDisplayForTheSelectedStandardReport(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I will see default Customer Selection will be All customer")]
        public void ThenIWillSeeDefaultCustomerSelectionWillBeAllCustomer()
        {
            string Default_Text_Actual = Gettext(attributeName_xpath, ShipmentList_Customer_dropdown_Xpath);
            Assert.AreEqual("All Customers", Default_Text_Actual);
        }

        [Then(@"I able to select any one customer(.*)")]
        public void ThenIAbleToSelectAnyOneCustomer(string _CustomerAccount)
        {
            Click(attributeName_xpath, ShipmentList_Customer_dropdown_Xpath);
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_Customer_dropdownValue_Xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == _CustomerAccount)
                {
                    DropDownList[i].Click();
                    break;
                }
            }

            string Customer_Text_Actual = Gettext(attributeName_xpath, ShipmentList_Customer_dropdown_Xpath);
            Assert.IsTrue(Customer_Text_Actual.Contains(_CustomerAccount));
        }

        [Given(@"I have select any Custom Report which has No shipments from Report Dropdown(.*)")]
        public void GivenIHaveSelectAnyCustomReportWhichHasNoShipmentsFromReportDropdown(string _CustomReport)
        {
            Click(attributeName_xpath, ShipmentList_Report_dropdown_Xpath);
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_Report_dropdown_Values_Xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == _CustomReport)
                {
                    DropDownList[i].Click();
                    break;
                }
            }
        }

        [Then(@"I will see No Results found text message")]
        public void ThenIWillSeeNoResultsFoundTextMessage()
        {
            string NoShipmentEntries = "Showing 0 to 0 of 0 entries";
            string ShipmentEntries = Gettext(attributeName_xpath, ".//*[@id='ShipmentGrid_wrapper']/div[2]/div/div[1]/div");
            if (NoShipmentEntries == ShipmentEntries)
            {
                string NoResultsFound_Text_Actual = Gettext(attributeName_xpath, ".//td[contains(text(), 'No Results Found')]");
                Assert.AreEqual("No Results Found", NoResultsFound_Text_Actual);
            }
            else
            {
                Report.WriteLine("Shipments found in the Shipment List");
            }
        }

        [When(@"I have select any Report which has No shipments from Report Dropdown(.*)")]
        public void GivenIHaveSelectAnyReportWhichHasNoShipmentsFromReportDropdown(string StandardReport)
        {
            WaitForElementVisible(attributeName_xpath, ShipmentList_Header_Xpath, "Shipment List");
            Click(attributeName_xpath, ShipmentList_Report_dropdown_Xpath);

            IList<IWebElement> ReportDropDownList = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='ReportType_chosen']/div/ul/li"));
            List<string> _dropdownListReport = ReportDropDownList.Select(c => c.Text.ToUpper()).ToList();
            string CustomReport_Uppercase = StandardReport.ToUpper();

            bool check = _dropdownListReport.Contains(CustomReport_Uppercase);
            if (check)
            {
                SendKeys(attributeName_xpath, ".//*[@id='ReportType_chosen']/div/div/input", StandardReport);
                Thread.Sleep(500);
                Click(attributeName_xpath, ".//*[@id='ReportType_chosen']/div/ul/li[2]");
                Thread.Sleep(30000);
            }
            else
            {
                Report.WriteLine("No Report for the entered search criteria");
            }
        }

        [Then(@"I Should see Shared Report Checkbox")]
        public void ThenIShouldSeeSharedReportCheckbox()
        {
            IsElementPresent(attributeName_xpath, ShipmentList_shareaccess_checkbox_Xpath, "SHARE REPORT");
        }

        [When(@"I clicked on Shared Checkbox")]
        public void WhenIClickedOnSharedCheckbox()
        {
            Click(attributeName_xpath, ShipmentList_shareaccess_checkbox_Xpath);
        }

        [Then(@"I try to save the shared Report which already exist for another report will be getting error message(.*)")]
        public void ThenITryToSaveTheSharedReportWhichAlreadyExistForAnotherReportWillBeGettingErrorMessage(string DuplicateReportName)
        {
            SendKeys(attributeName_id, FilterSection_ReportName_Text_Id, DuplicateReportName);
            Click(attributeName_id, SaveReport_ModalPopUp_Ok_button_Id);
            string UIstirng=Gettext(attributeName_id, SaveReport_ModalPopUp_warning_message_Id);
            string exptectedString = "Shared report name already exists";
            Assert.AreEqual(UIstirng, exptectedString);
        }

        [Then(@"any user who having access to my station will have access to this report(.*)(.*)")]
        public void ThenAnyUserWhoHavingAccessToMyStationWillHaveAccessToThisReport(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }



        [When(@"I am Update the any Report Parameter of CSA (.*),(.*)")]
        public void WhenIAmUpdateTheAnyReportParameterOfCSA(string StardDate, string Enddate)
        {
            Click(attributeName_xpath, ".//*[@id='SchedulePickupDates']");
            Clear(attributeName_xpath, "html/body/div[8]/div[1]/div[1]/input");

            SendKeys(attributeName_xpath, "html/body/div[8]/div[1]/div[1]/input", StardDate);
            Clear(attributeName_xpath, "html/body/div[8]/div[2]/div[1]/input");
            SendKeys(attributeName_xpath, "html/body/div[8]/div[2]/div[1]/input", Enddate);
            Click(attributeName_xpath, "html/body/div[8]/div[3]/div/button");
        }


        [Then(@"Shipment list displayed for the selected Custom Report and Customer Accountuser(.*)service(.*)reference(.*)startdate(.*)enddate(.*)orgincity(.*)destcity(.*)status(.*)acc(.*)accnumber(.*)report(.*)")]
        public void ThenShipmentListDisplayedForTheSelectedCustomReportAndCustomerAccountuserservicereferencestartdateenddateorgincitydestcitystatusaccaccnumberreport(string Useremail, string ServiceType, string RefNumber, string StardDate, string Enddate, string OrgCity, string DestCity, string Status, string CustomerAccount, string stationData, string APIReport)
        {
            string[] values = stationData.Split(',');
            List<string> StatID = new List<string>();
            List<String> ShipList = new List<string>();
            List<String> ShipmentList = new List<string>();
            string MgCustomerAccountNumber;
            List<ShipmentListViewModel> Sdata;
            foreach (var v in values)
            {
                StatID.Add(v);
            }
            for (int i = 0; i < StatID.Count; i++)
            {
                //Calling db to get account number for the mapped station 
                CustomerSetup value = DBHelper.GetStationDetailsById(StatID[i]);
                if (value.MgAccountNumber == null)
                {
                    MgCustomerAccountNumber = null;
                    Sdata = null;
                }
                else
                {
                    MgCustomerAccountNumber = value.MgAccountNumber.ToString();
                    BuildHttpClient objBuildHttpClient = new BuildHttpClient();
                    HttpClient headers = objBuildHttpClient.BuildHttpClientWithHeaders(CustomerAccount, "application/xml");
                    GetCustomReportXML _CustXml = new GetCustomReportXML();
                    XElement resuestXML = _CustXml._GetCustReportXML(Useremail, ServiceType, RefNumber, StardDate, Enddate, OrgCity, DestCity, Status, CustomerAccount, MgCustomerAccountNumber, APIReport);

                    string uri = $"MercuryGate/ListScreenExtract";
                    ShipmentListScreen Slist = new ShipmentListScreen();
                    Sdata = Slist.CallListScreen(uri, headers, resuestXML);
                }

                if (Sdata != null)
                {

                    for (int j = 1; j < Sdata.Count; j++)
                    {
                        ShipmentList.Add(Sdata[j].PrimaryReference);
                    }
                }
                else
                {
                    Report.WriteLine("No Response from API");
                }
            }


            IList<IWebElement> UIShipmentVal = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentListGrid_RefNumAllValues_Xpath));
            List<string> UIValue = new List<string>();
            if (ShipmentList.Count >= 1)
            {
                for (int k = 0; k < UIShipmentVal.Count; k++)
                {
                    string UIShipNum = UIShipmentVal[k].Text;
                    UIValue.Add(UIShipNum);
                }

                Assert.AreEqual(ShipmentList.Count, UIValue.Count);
                UIValue.Reverse();//reversed code
                CollectionAssert.AreEqual(ShipmentList, UIValue);

            }
            else
            {
                Report.WriteLine("Values does not exists in shipment list response");
            }
        }


        [Then(@"the Shipment list displayed for the selected Custom Report and Customer Accountuser(.*)service(.*)reference(.*)startdate(.*)enddate(.*)orgincity(.*)destcity(.*)status(.*)acc(.*)accnumber(.*)report(.*)")]
        public void ThenTheShipmentListDisplayedForTheSelectedCustomReportAndCustomerAccountuserservicereferencestartdateenddateorgincitydestcitystatusaccaccnumberreport(string Useremail, string ServiceType, string RefNumber, string StardDate, string Enddate, string OrgCity, string DestCity, string Status, string CustomerAccount, string MgCustomerAccountNumber, string APIReport)
        {
            BuildHttpClient objBuildHttpClient = new BuildHttpClient();
            HttpClient headers = objBuildHttpClient.BuildHttpClientWithHeaders(CustomerAccount, "application/xml");
            GetCustomReportXML _CustXml = new GetCustomReportXML();
            XElement resuestXML = _CustXml._GetCustReportXML(Useremail, ServiceType, RefNumber, StardDate, Enddate, OrgCity, DestCity, Status, CustomerAccount, MgCustomerAccountNumber, APIReport);

            string uri = $"MercuryGate/ListScreenExtract";
            ShipmentListScreen Slist = new ShipmentListScreen();
            List<ShipmentListViewModel> Sdata = Slist.CallListScreen(uri, headers, resuestXML);

            List<String> ShipmentList = new List<string>();

            if (Sdata != null)
            {

                for (int j = 1; j < Sdata.Count; j++)
                {
                    ShipmentList.Add(Sdata[j].PrimaryReference);
                }
            }
            else
            {
                Report.WriteLine("No Response from API");
            }

            IList<IWebElement> UIShipmentVal = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentListGrid_RefNumAllValues_Xpath));
            List<string> UIValue = new List<string>();
            if (ShipmentList.Count >= 1)
            {
                for (int k = 0; k < UIShipmentVal.Count; k++)
                {
                    string UIShipNum = UIShipmentVal[k].Text;
                    UIValue.Add(UIShipNum);
                }

                Assert.AreEqual(ShipmentList.Count, UIValue.Count);
                UIValue.Reverse();//reversed code
                CollectionAssert.AreEqual(ShipmentList, UIValue);

            }
            else
            {
                Report.WriteLine("Values does not exists in shipment list response");
            }
        }

    }
}
