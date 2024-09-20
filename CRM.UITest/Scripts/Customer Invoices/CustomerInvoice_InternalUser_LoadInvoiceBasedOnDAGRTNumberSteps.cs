using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Objects;
using Microsoft.IdentityModel.Protocols;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.Dls.IdentityServer.Core.Dto;
using Rrd.ServiceAccessLayer;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Customer_Invoices
{
    [Binding]
    public class CustomerInvoice_InternalUser_LoadInvoiceBasedOnDAGRTNumberSteps : Customer_Invoice
    {
        string station1 = "ZZZ - Web Services Test";
        string station2 = "ENT - Bolingbrook IL";
        string CustomerAccountType = "All Accounts";
        string Startdate = null;
        string Enddate = null;
        List<string> StationNames = new List<string>();

        [Given(@"I am a Station owner, Operations or SalesManagement user")]
        public void GivenIAmAStationOwnerOperationsOrSalesManagementUser()
        {
            string username = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
            string password = ConfigurationManager.AppSettings["password-crmOperation"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }
        
        [Given(@"I am on Customer Invoices Page")]
        public void GivenIAmOnCustomerInvoicesPage()
        {
            Click(attributeName_xpath, customerInvoiceIcon_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Navigated to Customer Invoices page");
        }
        
        [Given(@"I am a Station owner, Operations, SalesManagement user or AccessRRD user")]
        public void GivenIAmAStationOwnerOperationsSalesManagementUserOrAccessRRDUser()
        {
            string username = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
            string password = ConfigurationManager.AppSettings["password-crmOperation"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"One or more (.*) along with '(.*)' has been selected by choosing Closed as filter option\.")]
        public void GivenOneOrMoreAlongWithHasBeenSelectedByChoosingClosedAsFilterOption_(string Stations, string p1)
        {      
            if (Stations == "SingleStation")
            {
                Click(attributeName_xpath, CustomReport_Close_Xpath);
                Report.WriteLine("Closed filter option is been clicked");
                StationAccountSelectionSingle();
            }
            else
            {
                Click(attributeName_xpath, CustomReport_Close_Xpath);
                Report.WriteLine("Closed filter option is been clicked");
                StationAccountSelectionMultiple();
            }
        }

        [Given(@"One or more (.*) along with '(.*)' has been selected by choosing Open as filter option")]
        public void GivenOneOrMoreAlongWithHasBeenSelectedByChoosingOpenAsFilterOption(string Stations, string p1)
        {
            if (Stations == "SingleStation")
            {
                Click(attributeName_xpath, CustomReport_Open_Xpath);
                Report.WriteLine("Open filter option is been clicked");
                StationAccountSelectionSingle();
            }
            else
            {
                Click(attributeName_xpath, CustomReport_Open_Xpath);
                Report.WriteLine("Open filter option is been clicked");
                StationAccountSelectionMultiple();
            }
        }

        [Given(@"I am an AccessRRD user")]
        public void GivenIAmAnAccessRRDUser()
        {
            string username = ConfigurationManager.AppSettings["username-AccessRRDUser"].ToString();
            string password = ConfigurationManager.AppSettings["password-AccessRRDUser"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"One or more (.*) along with '(.*)' has been selected")]
        public void GivenOneOrMoreAlongWithHasBeenSelected(string Stations, string p1)
        {
            if(Stations == "SingleStation")
            {
                Click(attributeName_xpath, CustomerInvoiceAccessRrdStation_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, CustomerInvoiceAccessRrdStationDropdown_Xpath, station1);
                Click(attributeName_xpath, CustomerInvoiceAccessRrdCustomer_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, CustomerInvoiceAccessRrdCustomerDropdown_Xpath, CustomerAccountType);
                Report.WriteLine("Station and All Accounts has been selected");
            }
            else
            {
                Click(attributeName_xpath, CustomerInvoiceAccessRrdStation_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, CustomerInvoiceAccessRrdStationDropdown_Xpath, station1);
                Click(attributeName_xpath, CustomerInvoiceAccessRrdStation_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, CustomerInvoiceAccessRrdStationDropdown_Xpath, station2);
                Click(attributeName_xpath, CustomerInvoiceAccessRrdCustomer_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, CustomerInvoiceAccessRrdCustomerDropdown_Xpath, CustomerAccountType);
                Report.WriteLine("Stations and All Accounts has been selected");
            }
        }

        [Given(@"Display Invoices button has been clicked")]
        public void GivenDisplayInvoicesButtonHasBeenClicked()
        {
            Click(attributeName_id, CustomerInvoicePage_AccessRRDUser_DisplayInvoiceButton_Id);
            Report.WriteLine("Clicked on Display Invoices button");
        }

        [When(@"I click Display Invoices button")]
        public void WhenIClickDisplayInvoicesButton()
        {
            Click(attributeName_id, CustomerInvoicePage_AccessRRDUser_DisplayInvoiceButton_Id);
            Report.WriteLine("Clicked on Display Invoices button");
        }

        [When(@"I am on the Customer Invoices page")]
        public void WhenIAmOnTheCustomerInvoicesPage()
        {
            Click(attributeName_xpath, customerInvoiceIcon_xpath);
            Report.WriteLine("Clicked on Customer Invoice button");
            VerifyElementPresent(attributeName_xpath, customerInvoicesHeader_xpath, "Customer Invoices");
            Report.WriteLine("Navigated to Customer Invoice page");
        }
        
        [When(@"I select Closed Invoices")]
        public void WhenISelectClosedInvoices()
        {
            Click(attributeName_xpath, CustomInvoiceGridClosedFilter_Xpath);
            Report.WriteLine("Closed Invoices option is been selected");
        }

        [When(@"I click Preview/Run now button")]
        public void WhenIClickPreviewRunNowButton()
        {
            Click(attributeName_id, CustomReport_Preview_Run_Button_Id);
            Report.WriteLine("Clicked on Preview/Run now button");
        }
        [Then(@"Closed Invoices should be listed based on DAGRT numbers of selected (.*),date range and closed dates")]
        public void ThenClosedInvoicesShouldBeListedBasedOnDAGRTNumbersOfSelectedDateRangeAndClosedDates(string Stations)
        {
            if(Stations == "SingleStation")
            {
                scrollpagedown();
                scrollpagedown();
                List<string> DAGRTClosedCustomerNumDateRange = new List<string>();
                List<string> DAGRTClosedCustomerNumDateRanegUI = new List<string>();
                IList<IWebElement> CustomerNumber = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoiceGridCustomerNum_Xpath));
                foreach (var IWebElement in CustomerNumber)
                {
                    DAGRTClosedCustomerNumDateRanegUI.Add(IWebElement.Text);
                }
                if (CustomerNumber.Count > 0)
                {                  
                        DateTime startDate = Convert.ToDateTime(Startdate);
                        DateTime endDate = Convert.ToDateTime(Enddate);
                        List<string> ClosedCustomerInvoiceDAGRT = DBHelper.GetClosedDAGRTCustomerInvoicesDateRange(station1, startDate, endDate);
                        foreach (var v in ClosedCustomerInvoiceDAGRT)
                        {
                            DAGRTClosedCustomerNumDateRange.Add(v);
                        }                  

                    if (DAGRTClosedCustomerNumDateRanegUI.ToString().Contains(DAGRTClosedCustomerNumDateRange.ToString()))
                    {
                        Report.WriteLine("Last two years Closed Invoices is getting listed based on DAGRT numbers of selected stations and closed dates");
                    }
                    else
                    {
                        Assert.Fail();
                    }
                }
                else
                {
                    VerifyElementPresent(attributeName_xpath, CustomerInvoiceGridEmpty_Xpath, "No Results Found");
                    Report.WriteLine("No Results found");
                }
            }
            else
            {
                scrollpagedown();
                scrollpagedown();
                List<string> DAGRTClosedCustomerNumDateRange = new List<string>();
                List<string> DAGRTClosedCustomerNumDateRanegUI = new List<string>();
                IList<IWebElement> CustomerNumber = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoiceGridCustomerNum_Xpath));
                foreach (var IWebElement in CustomerNumber)
                {
                    DAGRTClosedCustomerNumDateRanegUI.Add(IWebElement.Text);
                }
                if (CustomerNumber.Count > 0)
                {
                    List<string> SelectedStationNames = new List<string>(new string[] { station1, station2 });
                    for (int i = 0; i < SelectedStationNames.Count; i++)
                    {
                        DateTime startDate = Convert.ToDateTime(Startdate);
                        DateTime endDate = Convert.ToDateTime(Enddate);
                        List<string> ClosedCustomerInvoiceDAGRT = DBHelper.GetClosedDAGRTCustomerInvoicesDateRange(SelectedStationNames[i], startDate, endDate);
                        foreach (var v in ClosedCustomerInvoiceDAGRT)
                        {
                            DAGRTClosedCustomerNumDateRange.Add(v);
                        }
                    }

                    if (DAGRTClosedCustomerNumDateRanegUI.ToString().Contains(DAGRTClosedCustomerNumDateRange.ToString()))
                    {
                        Report.WriteLine("Last two years Closed Invoices is getting listed based on DAGRT numbers of selected stations and closed dates");
                    }
                    else
                    {
                        Assert.Fail();
                    }
                }
                else
                {
                    VerifyElementPresent(attributeName_xpath, CustomerInvoiceGridEmpty_Xpath, "No Results Found");
                    Report.WriteLine("No Results found");
                }
            }
        }

        [Given(@"Date Range has been selected")]
        public void GivenDateRangeHasBeenSelected()
        {
            Click(attributeName_xpath, CustomReport_CreateReportSection_DateRangePicker_Xpath);
            PreviousDatePickerFromCalander(attributeName_xpath, "html/body/div[8]/div[1]/div[2]/table/tbody/tr/td", -1344, "html/body/div[8]/div[1]/div[2]/table/thead/tr[1]/th[1]");
            DatePickerDoubleGridCalanderFutureEndDate(attributeName_xpath, "html/body/div[8]/div[2]/div[2]/table/tbody/tr/td", 30, "17", "html/body/div[8]/div[2]/div[2]/table/thead/tr[1]/th[3]");
            string dateRangeSelected = GetValue(attributeName_id, CustomReport_DateRangePlaceHolder_Id, "value");
            string[] result = dateRangeSelected.Split(new string[] {"-"}, StringSplitOptions.None);
            Startdate = result[0];
            Enddate = result[1];
        }

        [When(@"I have selected one or more (.*)")]
        public void WhenIHaveSelectedOneOrMore(string stations)
        {
            if(stations == "SingleStation")
            {
                Click(attributeName_xpath, ReportStationName_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, CustomReport_Stations_Xpath, station1);
                Report.WriteLine("One station have been selected");
            }
            else
            {
                Click(attributeName_xpath, ReportStationName_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, CustomReport_Stations_Xpath, station1);
                Click(attributeName_xpath, ReportStationName_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, CustomReport_Stations_Xpath, station2);
                Report.WriteLine("More than one station have been selected");
            }
        }



        [When(@"I select '(.*)' option")]
        public void WhenISelectOption(string p0)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            MoveToElement(attributeName_xpath, CustomerIvoiceGridClosedOption_Xpath);
            Click(attributeName_xpath, CustomerIvoiceGridClosedOption_Xpath);
            Report.WriteLine("Closed Option is selected");
        }

        [Then(@"All Open invoices based on DAGRT numbers of the associated stations should get displayed")]
        public void ThenAllOpenInvoicesBasedOnDAGRTNumbersOfTheAssociatedStationsShouldGetDisplayed()
        {
            GetStationNamesIDP();
            scrollpagedown();
            scrollpagedown();
            List<string> DAGRTOpenCustomerNum = new List<string>();
            List<string> DAGRTOpenCustomerNumUI = new List<string>();
            IList<IWebElement> CustomerNumber = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoiceGridCustomerNum_Xpath));
            foreach (var IWebElement in CustomerNumber)
            {
                DAGRTOpenCustomerNumUI.Add(IWebElement.Text);
            }
            if (CustomerNumber.Count > 0)
            {
                for (int i = 0; i < StationNames.Count; i++)
                {
                    List<string> OpenCustomerInvoiceDAGRT = DBHelper.GetOpenDAGRTCustomerInvoices(StationNames[i]);
                    foreach (var v in OpenCustomerInvoiceDAGRT)
                    {
                        DAGRTOpenCustomerNum.Add(v);
                    }
                }

                if (DAGRTOpenCustomerNumUI.ToString().Contains(DAGRTOpenCustomerNum.ToString()))
                {
                    Report.WriteLine("All Open Invoices is getting listed based on DAGRT numbers of selected stations");
                }
                else
                {
                    Assert.Fail();
                }

            }
            else
            {
                VerifyElementPresent(attributeName_xpath, CustomerInvoiceGridEmpty_Xpath, "No Results Found");
                Report.WriteLine("No Results found");
            }

        }

        [Then(@"I should be able to view Open as filter option")]
        public void ThenIShouldBeAbleToViewOpenasFilterOption()
        {
            VerifyElementPresent(attributeName_xpath, CustomInvoiceGridOpenFilter_Xpath, "Open");
            Report.WriteLine("Open filter option is present");
        }

        [Then(@"I should be able to view Closed as filter option")]
        public void ThenIShouldBeAbleToViewClosedasFilterOption()
        {
            VerifyElementPresent(attributeName_xpath, CustomInvoiceGridClosedFilter_Xpath, "Closed");
            Report.WriteLine("Closed filter option is present");
        }
        
        [Then(@"I should see last two years closed invoices based on DAGRT numbers of the associated stations and closed dates")]
        public void ThenIShouldSeeLastTwoYearsClosedInvoicesBasedOnDAGRTNumbersOfTheAssociatedStationsAndClosedDates()
        {
            GetStationNamesIDP();
            scrollpagedown();
            scrollpagedown();
            List<string> DAGRTClosedCustomerNum = new List<string>();
            List<string> DAGRTClosedCustomerNumUI = new List<string>();
            IList<IWebElement> CustomerNumber = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoiceGridCustomerNum_Xpath));
            foreach (var IWebElement in CustomerNumber)
            {
                DAGRTClosedCustomerNumUI.Add(IWebElement.Text);
            }
            if (CustomerNumber.Count > 0)
            {
                for (int i = 0; i < StationNames.Count; i++)
                {
                    List<string> ClosedCustomerInvoiceDAGRT = DBHelper.GetClosedDAGRTCustomerInvoices(StationNames[i]);
                    foreach (var v in ClosedCustomerInvoiceDAGRT)
                    {
                        DAGRTClosedCustomerNum.Add(v);
                    }
                }

                if (DAGRTClosedCustomerNumUI.ToString().Contains(DAGRTClosedCustomerNum.ToString()))
                {
                    Report.WriteLine("Last two years Closed Invoices is getting listed based on DAGRT numbers of selected stations and closed dates");
                }
                else
                {
                    Assert.Fail();
                }
            }
            else
            {
                VerifyElementPresent(attributeName_xpath, CustomerInvoiceGridEmpty_Xpath, "No Results Found");
                Report.WriteLine("No Results found");
            }

        }
       [Then(@"I should be able to select '(.*)'")]
        public void ThenIShouldBeAbleToSelect(string p0)
        {
            Click(attributeName_xpath, ReportAccount_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, ReportAccountDropdownVal_Xpath, CustomerAccountType);
            Report.WriteLine("Able to select All Accounts for the customer dropdown");
        }

        [Then(@"All Open Invoices should be listed based on DAGRT numbers of selected (.*)")]
        public void ThenAllOpenInvoicesShouldBeListedBasedOnDAGRTNumbersOfSelected(string Stations)
        {
            if(Stations == "SingleStation")
            {
                GetOpenCustomerInvoicesSingleStation();
            }
            else
            {
                GetOpenCustomerInvoicesMultipleStations();
            }
        }

        [Then(@"Last two years Closed Invoices should be listed based on DAGRT numbers of selected (.*) and closed dates")]
        public void ThenLastTwoYearsClosedInvoicesShouldBeListedBasedOnDAGRTNumbersOfSelectedAndClosedDates(string Stations)
        {
            if(Stations == "SingleStation")
            {
                GetClosedCustomerInvoicesSingleStation();
            }
            else
            {
                GetClosedCustomerInvoicesMultipleStations();
            }
        }

        [Then(@"I should be able to select '(.*)'\.")]
        public void ThenIShouldBeAbleToSelect_(string p0)
        {
            Click(attributeName_xpath, CustomerInvoiceAccessRrdCustomer_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, CustomerInvoiceAccessRrdCustomerDropdown_Xpath, CustomerAccountType);
            Report.WriteLine("Able to select All Accounts for the customer dropdown");
        }

        [Then(@"Invoices should be listed based on DAGRT numbers of selected (.*)")]
        public void ThenInvoicesShouldBeListedBasedOnDAGRTNumbersOfSelected(string Stations)
        {
            if(Stations == "SingleStation")
            {
                GetOpenCustomerInvoicesSingleStation();
            }
            else
            {
                GetOpenCustomerInvoicesMultipleStations();
            }
        }


        public void GetOpenCustomerInvoicesSingleStation()
        {
            scrollpagedown();
            scrollpagedown();
            List<string> DAGRTOpenCustomerNum = new List<string>();
            List<string> DAGRTOpenCustomerNumUI = new List<string>();
            IList<IWebElement> CustomerNumber = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoiceGridCustomerNum_Xpath));
            foreach (var IWebElement in CustomerNumber)
            {
                DAGRTOpenCustomerNumUI.Add(IWebElement.Text);
            }
            if (CustomerNumber.Count > 0)
            {
                    List<string> OpenCustomerInvoiceDAGRT = DBHelper.GetOpenDAGRTCustomerInvoices(station1);
                    foreach (var v in OpenCustomerInvoiceDAGRT)
                    {
                        DAGRTOpenCustomerNum.Add(v);
                    }
                if (DAGRTOpenCustomerNumUI.ToString().Contains(DAGRTOpenCustomerNum.ToString()))
                {
                    Report.WriteLine("All Open Invoices is getting listed based on DAGRT numbers of selected stations");
                }
                else
                {
                    Assert.Fail();
                }

            }
            else
            {
                VerifyElementPresent(attributeName_xpath, CustomerInvoiceGridEmpty_Xpath, "No Results Found");
                Report.WriteLine("No Results found");
            }
        }
       public void GetOpenCustomerInvoicesMultipleStations()
        {
            scrollpagedown();
            scrollpagedown();
            List<string> DAGRTOpenCustomerNum = new List<string>();
            List<string> DAGRTOpenCustomerNumUI = new List<string>();
            IList<IWebElement> CustomerNumber = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoiceGridCustomerNum_Xpath));
            foreach (var IWebElement in CustomerNumber)
            {
                DAGRTOpenCustomerNumUI.Add(IWebElement.Text);
            }
            if (CustomerNumber.Count > 0)
            {
                List<string> SelectedStationNames = new List<string>(new string[] { station1, station2 });
                for (int i = 0; i < SelectedStationNames.Count; i++)
                {
                    List<string> OpenCustomerInvoiceDAGRT = DBHelper.GetOpenDAGRTCustomerInvoices(SelectedStationNames[i]);
                    foreach (var v in OpenCustomerInvoiceDAGRT)
                    {
                        DAGRTOpenCustomerNum.Add(v);
                    }
                }

                if (DAGRTOpenCustomerNumUI.ToString().Contains(DAGRTOpenCustomerNum.ToString()))
                {
                    Report.WriteLine("All Open Invoices is getting listed based on DAGRT numbers of selected stations");
                }
                else
                {
                    Assert.Fail();
                }

            }
            else
            {
                VerifyElementPresent(attributeName_xpath, CustomerInvoiceGridEmpty_Xpath, "No Results Found");
                Report.WriteLine("No Results found");
            }
        }
        public void GetClosedCustomerInvoicesSingleStation()
        {
            scrollpagedown();
            scrollpagedown();
            List<string> DAGRTClosedCustomerNum = new List<string>();
            List<string> DAGRTClosedCustomerNumUI = new List<string>();
            IList<IWebElement> CustomerNumber = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoiceGridCustomerNum_Xpath));
            foreach (var IWebElement in CustomerNumber)
            {
                DAGRTClosedCustomerNumUI.Add(IWebElement.Text);
            }
            if (CustomerNumber.Count > 0)
            {             
                    List<string> ClosedCustomerInvoiceDAGRT = DBHelper.GetClosedDAGRTCustomerInvoices(station1);
                    foreach (var v in ClosedCustomerInvoiceDAGRT)
                    {
                        DAGRTClosedCustomerNum.Add(v);
                    }

                if (DAGRTClosedCustomerNumUI.ToString().Contains(DAGRTClosedCustomerNum.ToString()))
                {
                    Report.WriteLine("Last two years Closed Invoices is getting listed based on DAGRT numbers of selected stations and closed dates");
                }
                else
                {
                    Assert.Fail();
                }
            }
            else
            {
                VerifyElementPresent(attributeName_xpath, CustomerInvoiceGridEmpty_Xpath, "No Results Found");
                Report.WriteLine("No Results found");
            }
        }
        public void GetClosedCustomerInvoicesMultipleStations()
        {
            scrollpagedown();
            scrollpagedown();
            List<string> DAGRTClosedCustomerNum = new List<string>();
            List<string> DAGRTClosedCustomerNumUI = new List<string>();
            IList<IWebElement> CustomerNumber = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoiceGridCustomerNum_Xpath));
            foreach (var IWebElement in CustomerNumber)
            {
                DAGRTClosedCustomerNumUI.Add(IWebElement.Text);
            }
            if (CustomerNumber.Count > 0)
            {
                List<string> SelectedStationNames = new List<string>(new string[] { station1, station2 });
                for (int i = 0; i < SelectedStationNames.Count; i++)
                {
                    List<string> ClosedCustomerInvoiceDAGRT = DBHelper.GetClosedDAGRTCustomerInvoices(SelectedStationNames[i]);
                    foreach (var v in ClosedCustomerInvoiceDAGRT)
                    {
                        DAGRTClosedCustomerNum.Add(v);
                    }
                }

                if (DAGRTClosedCustomerNumUI.ToString().Contains(DAGRTClosedCustomerNum.ToString()))
                {
                    Report.WriteLine("Last two years Closed Invoices is getting listed based on DAGRT numbers of selected stations and closed dates");
                }
                else
                {
                    Assert.Fail();
                }
            }
            else
            {
                VerifyElementPresent(attributeName_xpath, CustomerInvoiceGridEmpty_Xpath, "No Results Found");
                Report.WriteLine("No Results found");
            }
        }

        public void GetStationNamesIDP()
        {
            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);
            List<AppUserClaimInfo> claimValue = new List<AppUserClaimInfo>();
            List<AppUserClaimInfo> claimDetails = IDP.GetUserClaimDetails("crmoperation");
            claimValue = claimDetails.Where(x => x.ClaimType == "dlscrm-StationId").Select(x => new AppUserClaimInfo
            {
                ClaimValue = x.ClaimValue,

            }).ToList();
            List<string> stationId = claimValue.Select(x => x.ClaimValue).ToList();
            for (int i = 0; i < stationId.Count; i++)
            {
                string StationName = DBHelper.GetStationNameonStationID(stationId[i]);
                StationNames.Add(StationName);

            }
        }

        public void StationAccountSelectionSingle()
        {
            Click(attributeName_xpath, ReportStationName_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, CustomReport_Stations_Xpath, station1);
            Click(attributeName_xpath, ReportAccount_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, ReportAccountDropdownVal_Xpath, CustomerAccountType);
            SendKeys(attributeName_xpath, CustomerInvoiceReportName_Xpath, "TestPreview");
            Report.WriteLine("Station and All Accounts has been selected");
        }


        public void StationAccountSelectionMultiple()
        {
            Click(attributeName_xpath, ReportStationName_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, CustomReport_Stations_Xpath, station1);
            Click(attributeName_xpath, ReportStationName_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, CustomReport_Stations_Xpath, station2);
            Click(attributeName_xpath, ReportAccount_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, ReportAccountDropdownVal_Xpath, CustomerAccountType);
            SendKeys(attributeName_xpath, CustomerInvoiceReportName_Xpath, "TestPreview");
            Report.WriteLine("Stations and All Accounts has been selected");
        }
    
    }
}
