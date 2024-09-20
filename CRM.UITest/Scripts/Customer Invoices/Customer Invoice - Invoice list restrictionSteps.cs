using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Objects;
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
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Customer_Invoices
{
    [Binding]
    public class Customer_Invoice___Invoice_list_restrictionSteps : Customer_Invoice
    {

        List<string> StationNames = new List<string>();

        [Given(@"I am a shp\.entry, shp\.entrynortes, shp\.inquiry, shp\.inquirynorates, and access rrd user")]
        public void GivenIAmAShp_EntryShp_EntrynortesShp_InquiryShp_InquirynoratesAndAccessRrdUser()
        {
            string username = ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();
            string password = ConfigurationManager.AppSettings["ExternalUserPassword"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }


        [Then(@"I should see an Open filter Option")]
        public void ThenIShouldSeeAnOpenFilterOption()
        {
            Report.WriteLine("I will see the Filter List Open Options");
            Verifytext(attributeName_xpath, CustomerInvoices_FilterList_Open_Xpath, "OPEN");
        }


        [Then(@"I should see an Closed filter option")]
        public void ThenIShouldSeeAnClosedFilterOption()
        {
            Verifytext(attributeName_xpath, CustomerInvoices_FilterList_Closed_Xpath, "CLOSED");
            VerifyElementNotPresent(attributeName_xpath, CustomerInvoices_FilterList_All_Xpath, "ALL");
        }



        [When(@"I select Closed status on the Customer Invoice List")]
        public void WhenISelectClosedStatusOnTheCustomerInvoiceList()
        {
            Click(attributeName_xpath, CustomerInvoices_FilterList_Closed_Xpath);
        }

        [Then(@"I should get last two years invoice list based on the Closed Date")]
        public void ThenIShouldGetLastTwoYearsInvoiceListBasedOnTheClosedDate()
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


        public void GetStationNamesIDP()
        {
            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);
            List<AppUserClaimInfo> claimValue = new List<AppUserClaimInfo>();
            List<AppUserClaimInfo> claimDetails = IDP.GetUserClaimDetails("zzzext");
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


        [Then(@"I should have Open Status option")]
        public void ThenIShouldHaveOpenStatusOption()
        {
            Report.WriteLine("Open is selected by default");
            RadiobuttonChecked(attributeName_xpath, CustomReport_OpenRadioButton_Xpath);
        }


        [Then(@"I should have Closed Status option")]
        public void ThenIShouldHaveClosedStatusOption()
        {
            Report.WriteLine("I will see the Closed Invoice type option");
            VerifyElementVisible(attributeName_xpath, CustomReport_Close_Xpath, "Closed");
            VerifyElementNotPresent(attributeName_xpath, CustomReport_All_Xpath, "All");
        }




        [When(@"Enter date in the Date Range")]
        public void WhenEnterDateInTheDateRange()
        {
           

            int todaysDateIndex = 0;
            Click(attributeName_xpath, CustomReport_CreateReportSection_DateRangePicker_Xpath);
            IList<IWebElement> datesAvailableForStartDate = GlobalVariables.webDriver.FindElements(By.XPath(CustomReport_CreateReportSection_DateRangePicker_AvailableDates_Xpath));

            for (int i = 0; i < datesAvailableForStartDate.Count; i++)
            {
                if (datesAvailableForStartDate[i].GetAttribute("class").Contains("today"))
                {
                    //Select today as the start date
                    datesAvailableForStartDate[i].Click();
                    Report.WriteLine("Selected Current date as start date in DateRange picker");
                    todaysDateIndex = i;
                    break;
                }
            }

            //Select tomorrow's date as end date
            IList<IWebElement> datesAvailableForEndDate = GlobalVariables.webDriver.FindElements(By.XPath(CustomReport_CreateReportSection_DateRangePicker_AvailableDates_Xpath));
            datesAvailableForEndDate[todaysDateIndex + 1].Click();
            Report.WriteLine("Selected Tomorrow's date as end date in DateRange picker");
        }

        [Then(@"I should have option to clear the Date Range")]
        public void ThenIShouldHaveOptionToClearTheDateRange()
        {
            Click(attributeName_xpath, CustomReport_CreateReportSection_DateRangePicker_Xpath);
            Report.WriteLine("Clicked on the Date Range picker");
            Verifytext(attributeName_xpath, CreateCustomReportDateRange_xpath, "Clear");
            Click(attributeName_xpath, CreateCustomReportDateRange_xpath);
            string dateRangeSelected = GetValue(attributeName_id, CustomReport_DateRangePlaceHolder_Id, "value");
            Assert.AreEqual(dateRangeSelected, "");
        }

        [Then(@"I will see loading icon on the grid till Invoice list is loaded")]
        public void ThenIWillSeeLoadingIconOnTheGridTillInvoiceListIsLoaded()
        {
            VerifyElementVisible(attributeName_xpath, ".//*[@id='page-content-wrapper']//span[@class = 'style-spin fa fa-spinner fa-spin fa-3x fa-fw']", "Loading Icon");
            WaitForElementNotVisible(attributeName_xpath, ".//*[@id='page-content-wrapper']//span[@class = 'style-spin fa fa-spinner fa-spin fa-3x fa-fw']", "Loading Icon not Visible");
            //VerifyElementPresent(attributeName_xpath, "", "Data in the Invoice List");
        }

        [Then(@"I should be loading icon on the Customer Invoice page load")]
        public void ThenIShouldBeLoadingIconOnTheCustomerInvoicePageLoad()
        {
            VerifyElementVisible(attributeName_xpath, "", "Loading Icon");
        }


        [Given(@"I select one or more Stations from the station drop down list (.*)")]
        public void GivenISelectOneOrMoreStationsFromTheStationDropDownList(string p0)
        {
            string station = Regex.Replace(p0, @"(\s+|&|'|\(|\)|<|>|#)", "");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, CustomerInvoicePage_AccessRRDUser_StationsDropdown_Id);
            SendKeys(attributeName_xpath, ".//*[@id='AccessRRDStations_chosen']/ul/li//input", station);
            Click(attributeName_xpath, ".//*[@id='AccessRRDStations_chosen']/div/ul/li");
          
            //SelectAllValuesFromDropdown(attributeName_xpath, CustomerInvoicePage_AccessRRDUser_StationsDropdownAllValues_Xpath);
            //Click(attributeName_id, CustomerInvoicePage_AccessRRDUser_StationsDropdown_Id);
            //IList<IWebElement> stationDropdownList = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoicePage_AccessRRDUser_StationsDropdownAllValues_Xpath));

            //int countStations = stationDropdownList.Count;
            //List<string> stations = new List<string>();

            
            //for (int i = 0; i < countStations; i++)

            //{
            //        if (stationDropdownList[i].Text.Equals("ZZZ - Web Services Test") || stationDropdownList[i].Text.Equals("ENT - Bolingbrook IL"))
            //        {
            //            Click(attributeName_xpath, "//div[@id='AccessRRDStations_chosen']//div[@class='chosen-drop']//li[" + i + "]");
            //        }
                
            //}

            //string accountsSelected = Gettext(attributeName_id, CustomerInvoicePage_AccessRRDUser_StationsDropdown_Id);
            //foreach (string station in stations)
            //{
            //    Assert.IsTrue(accountsSelected.Contains(station));
            //}

            //Report.WriteLine("Selected multiple stations which I am associated to");

        }


        [Given(@"I select (.*) for the selected Stations in Customer drop down down list")]
        public void GivenISelectForTheSelectedStationsInCustomerDropDownDownList(string p0)
        {
            string CustomerName = Regex.Replace(p0, @"(\s+|&|'|\(|\)|<|>|#)", "");
            Click(attributeName_id, CustomerInvoicePage_AccessRRDUser_AccountsDropdown_Id);
            IList<IWebElement> accounts = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoicePage_AccessRRDUser_CustomerAccountsDropdownAllValues_XPath));
            for (int i = 0; i < accounts.Count; i++)

            {
                if (accounts[i].Text.Equals(CustomerName))
                {
                    int j = i + 1;
                    Click(attributeName_xpath, "//div[@id='AccessRRDAccounts_chosen']//div[@class='chosen-drop']//li["+ j +"]");
                    break;
                }

            }
        }

        [Given(@"I select Closed Status on the Customer Invoice List")]
        public void GivenISelectClosedStatusOnTheCustomerInvoiceList()
        {
            Click(attributeName_xpath, CustomerInvoices_FilterList_Closed_Xpath);
            Thread.Sleep(1000);
            WaitForElementNotVisible(attributeName_xpath, ".//*[@id='page-content-wrapper']//span[@class = 'style-spin fa fa-spinner fa-spin fa-3x fa-fw']", "Loading Icon not Visible");
        }


        [When(@"I select Open Status on the Customer Invoice List")]
        public void WhenISelectOpenStatusOnTheCustomerInvoiceList()
        {
            Click(attributeName_xpath, CustomerInvoices_FilterList_Open_Xpath);
        }


        






    }
}
