using CRM.UITest.CommonMethods;
using Rrd.ServiceAccessLayer;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using TechTalk.SpecFlow;
using Rrd.Dls.IdentityServer.Core.Dto;
using CRM.UITest.Objects;
using CRM.UITest.Entities;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System;

namespace CRM.UITest.Scripts.Customer_Invoices
{
    [Binding]
    public class _48353_Customer_Invoice___List_View_With_Multiple_DAGRTSteps : Customer_Invoice
    {
        public string userName;
        List<string> stationId;
        List<string> dagrtNumber;
        List<string> openInvoicesNumberListValuesDB;
        List<string> closedInvoicesNumberListValuesDB;
        string station1 = "ZZZ - Web Services Test";
        string station2 = "ENT - Bolingbrook IL";
        string CustomerAccountType = "All Accounts";
        List<string> OpenInvoiceNumberListValuesUI = new List<string>();
        List<string> ClosedInvoiceNumberListValuesUI = new List<string>();
        List<string> dagrtNum = new List<string>();
        public string station_Id = "ZZZ";


        [Given(@"I am a sales management, operations, or station owner user with access to Customer Invoice")]
        public void GivenIAmASalesManagementOperationsOrStationOwnerUserWithAccessToCustomerInvoice()
        {
            userName = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
            string password = ConfigurationManager.AppSettings["password-crmOperation"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(userName, password);
            Report.WriteLine("I logged into CRM application with RRD access user");
        }

        [Given(@"I'm assigned to a station with multiple DAGRT numbers")]
        public void GivenIMAssignedToAStationWithMultipleDAGRTNumbers()
        {
            Report.WriteLine("User should see Dashboard icon in the left navigation menu of Landing Page");
            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);


            List<AppUserClaimInfo> claimValue = new List<AppUserClaimInfo>();
            List<AppUserClaimInfo> claimDetails = IDP.GetUserClaimDetails(userName);
            claimValue = claimDetails.Where(x => x.ClaimType == "dlscrm-StationId").Select(x => new AppUserClaimInfo
            {
                ClaimValue = x.ClaimValue,

            }).ToList();

            stationId = claimValue.Select(x => x.ClaimValue).ToList();
            

            dagrtNumber = DBHelper.GetAllDagrtNumberForALLStations(stationId);


            int dagart = dagrtNumber.Count;
            for(int i = 0; i< dagart; i++)
            {
                if (dagrtNumber[i].Contains(','))
                {
                    string[] gg = dagrtNumber[i].Split(',');
                    int ff = gg.Count();
                    for(int j =0; j < ff; j++)
                    {
                        dagrtNum.Add(gg[j]);

                    }


                }else
                {
                    dagrtNum.Add(dagrtNumber[i]);
                }
            }

            openInvoicesNumberListValuesDB = DBHelper.GetAllMatchingDAGRTCustomerOpenInvoices(dagrtNum);
        }

        [Then(@"the grid will display Open invoices where the invoice DAGRT \# matches any DAGRT \# within the station DAGRT list")]
        public void ThenTheGridWillDisplayOpenInvoicesWhereTheInvoiceDAGRTMatchesAnyDAGRTWithinTheStationDAGRTList()
        {
            
            Thread.Sleep(200000);
            string OpenNoRecordFound = Gettext(attributeName_xpath, ".//*[contains(@id,'gridCustomerInvoiceList')]/tbody/tr/td");

            string invCount = Gettext(attributeName_xpath, ".//*[@class=' headerPosition']/div[@class='dataTables_info']");
            string displaycount = invCount.Substring(invCount.LastIndexOf("of ") + 2);
            string gg = displaycount.Remove(0, 1);
            int DC = Convert.ToInt32(displaycount);

            //Click(attributeName_xpath, CustomerInvoice_TopGrid_DisplayListViewDropdown_Xpath);

            Click(attributeName_xpath, ".//*[contains(@id,'gridCustomerInvoice')]/label/select");

            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(".//*[contains(@id,'gridCustomerInvoice')]/label/select/option"));
            int DropDownCount = DropDownList.Count;
            for (int i = 1; i <= DropDownCount; i++)
            {
                int j = i - 1;
                if (DropDownList[j].Text == "ALL")
                {
                    DropDownList[j].Click();
                    break;
                }
            }



            //int OpenInvCount = GetCount(attributeName_xpath, CustomerInvoives_DisplayAllRow_Xpath);

            int OpenInvCount = GetCount(attributeName_xpath, ".//*[contains(@id,'gridCustomerInvoiceList')]//tbody/tr");
            //open Invoices 
            if (OpenInvCount >= 1 && OpenNoRecordFound != "No Results Found")
            {
                WaitForElementPresent(attributeName_xpath, ".//*[contains(@id,'gridCustomerInvoiceList')]/tbody/tr[1]/td[2]", "SalesRep");
                IList <IWebElement> OpenInvoicesUI = GlobalVariables.webDriver.FindElements(By.XPath(Customerinvoices_InvoiceNumber_All_Xpath));
                if (OpenInvoicesUI.Count > 0)
                {

                    foreach (IWebElement element in OpenInvoicesUI)
                    {

                        OpenInvoiceNumberListValuesUI.Add((element.Text).ToString());
                    }
                }

                openInvoicesNumberListValuesDB = DBHelper.GetAllMatchingDAGRTCustomerOpenInvoices(dagrtNum);
                OpenInvoiceNumberListValuesUI.Sort();
                openInvoicesNumberListValuesDB.Sort();
                CollectionAssert.AreEqual(OpenInvoiceNumberListValuesUI, openInvoicesNumberListValuesDB);
               
               
            }
            else
            {
                VerifyElementPresent(attributeName_xpath, CustomerInvoiceGridEmpty_Xpath, "No Results Found");
                Report.WriteLine("No Results found");
            }

            

        }


        [Then(@"the grid will display Closed invoices where the invoice DAGRT \# matches any DAGRT \# within the station DAGRT list")]
        public void ThenTheGridWillDisplayClosedInvoicesWhereTheInvoiceDAGRTMatchesAnyDAGRTWithinTheStationDAGRTList()
        {
            //closed invoices
            Click(attributeName_xpath, CustomerInvoices_FilterList_Closed_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            string ClosedNoRecordFound = Gettext(attributeName_xpath, CustomerInvocies_NoResultFound_Xpath);
            int ClosedInvCount = GetCount(attributeName_xpath, CustomerInvoives_DisplayAllRow_Xpath);

            if (ClosedInvCount >= 1 && ClosedNoRecordFound != "No Results Found")
            {
                IList<IWebElement> ClosedInvoicesUI = GlobalVariables.webDriver.FindElements(By.XPath(Customerinvoices_InvoiceNumber_All_Xpath));
                if (ClosedInvoicesUI.Count > 0)
                {

                    foreach (IWebElement element in ClosedInvoicesUI)
                    {

                        ClosedInvoiceNumberListValuesUI.Add((element.Text).ToString());
                    }
                }

                ClosedInvoiceNumberListValuesUI.Sort();

                closedInvoicesNumberListValuesDB = DBHelper.GetAllMatchingDAGRTCustomerClosedInvoices(dagrtNumber);
                closedInvoicesNumberListValuesDB.Sort();
                CollectionAssert.AreEqual(ClosedInvoiceNumberListValuesUI, closedInvoicesNumberListValuesDB);
            }
            else
            {
                VerifyElementPresent(attributeName_xpath, CustomerInvoiceGridEmpty_Xpath, "No Results Found");
                Report.WriteLine("No Results found");
            }
        }



        [Given(@"I select a station with multiple DAGRT numbers")]
        public void GivenISelectAStationWithMultipleDAGRTNumbers()
        {
            Click(attributeName_xpath, CustomerInvoiceAccessRrdStation_Xpath);
            // SelectDropdownValueFromList(attributeName_xpath, CustomerInvoiceAccessRrdStationDropdown_Xpath, station1);
            IList<IWebElement> stationValue = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoiceAccessRrdStationDropdown_Xpath));
            for (int i = 0; i < stationValue.Count; i++)
            {
                if (stationValue[i].Text == station1)
                {
                    stationValue[i].Click();
                    break;
                }
            }

        }

        

        [When(@"I choose '(.*)' for the selected station")]
        public void WhenIChooseForTheSelectedStation(string CustomerAccountType)
        {
            Click(attributeName_id, "AccessRRDAccounts_chosen");
            Thread.Sleep(2000);
            //SelectDropdownValueFromList(attributeName_xpath, CustomerInvoiceAccessRrdCustomerDropdown_Xpath, CustomerAccountType);
            IList<IWebElement> stationValue = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoiceAccessRrdCustomerDropdown_Xpath));
            for (int i = 0; i < stationValue.Count; i++)
            {
                if (stationValue[i].Text == CustomerAccountType)
                {
                    stationValue[i].Click();
                    break;
                }
            }
            Report.WriteLine("Station and All Accounts has been selected");
        }

        [When(@"I click on the Display Invoices Button")]
        public void WhenIClickOnTheDisplayInvoicesButton()
        {
            Click(attributeName_id, CustomerInvoicePage_AccessRRDUser_DisplayInvoiceButton_Id);
            Report.WriteLine("Clicked on Display Invoices button");
           
        }

        

        [Then(@"the grid will display Open invoices where the invoice DAGRT \# matches any DAGRT \# within the selected (.*) DAGRT list\.")]
        public void ThenTheGridWillDisplayOpenInvoicesWhereTheInvoiceDAGRTMatchesAnyDAGRTWithinTheSelectedDAGRTList_(string p0)
        {
            scrollElementIntoView(attributeName_xpath, CustomerInvoice_TopGrid_DisplayListViewDropdown_Xpath);
            //Thread.Sleep(40000);
            Click(attributeName_xpath, CustomerInvoice_TopGrid_DisplayListViewDropdown_Xpath);
            SelectDropdownlistvalue(attributeName_xpath, CustomerInvoice_TopGrid_DisplayListDropdownOptions_Xpath, "ALL");

            //open Invoices 
            dagrtNumber = DBHelper.GetAllDagrtNumberForALLStations(station_Id);
            openInvoicesNumberListValuesDB = DBHelper.GetAllMatchingDAGRTCustomerOpenInvoices(dagrtNumber);

            //openInvoicesNumberListValuesDB = DBHelper.GetOpenDAGRTCustomerInvoices(station1);
            string OpenNoRecordFound = Gettext(attributeName_xpath, CustomerInvocies_NoResultFound_Xpath);
            int OpenInvCount = GetCount(attributeName_xpath, CustomerInvoives_DisplayAllRow_Xpath);
            if (OpenInvCount >= 1 && OpenNoRecordFound != "No Results Found")
            {

                IList<IWebElement> OpenInvoicesUI = GlobalVariables.webDriver.FindElements(By.XPath(CustomerinvoicesInvoiceNumber_All_Xpath));
                if (OpenInvoicesUI.Count > 0)
                {

                    foreach (IWebElement element in OpenInvoicesUI)
                    {

                        OpenInvoiceNumberListValuesUI.Add((element.Text).ToString());
                    }
                }
                OpenInvoiceNumberListValuesUI.Sort();
                openInvoicesNumberListValuesDB.Sort();

                CollectionAssert.AreEqual(OpenInvoiceNumberListValuesUI, openInvoicesNumberListValuesDB);
            }
            else
            {
                VerifyElementPresent(attributeName_xpath, CustomerInvoiceGridEmpty_Xpath, "No Results Found");
                Report.WriteLine("No Results found");
            }
        }


        [Then(@"the grid will display Closed invoices where the invoice DAGRT \# matches any DAGRT \# within the selected (.*) DAGRT list\.")]
        public void ThenTheGridWillDisplayClosedInvoicesWhereTheInvoiceDAGRTMatchesAnyDAGRTWithinTheSelectedDAGRTList_(string p0)
        {
            Click(attributeName_xpath, CustomerInvoices_FilterList_Closed_Xpath);
            scrollElementIntoView(attributeName_xpath, CustomerInvoice_TopGrid_DisplayListViewDropdown_Xpath);
            Click(attributeName_xpath, CustomerInvoice_TopGrid_DisplayListViewDropdown_Xpath);
            SelectDropdownlistvalue(attributeName_xpath, CustomerInvoice_TopGrid_DisplayListDropdownOptions_Xpath, "ALL");

            GlobalVariables.webDriver.WaitForPageLoad();
            string ClosedNoRecordFound = Gettext(attributeName_xpath, CustomerInvocies_NoResultFound_Xpath);
            int ClosedInvCount = GetCount(attributeName_xpath, CustomerInvoives_DisplayAllRow_Xpath);

            if (ClosedInvCount >= 1 && ClosedNoRecordFound != "No Results Found")
            {
                IList<IWebElement> ClosedInvoicesUI = GlobalVariables.webDriver.FindElements(By.XPath(CustomerinvoicesInvoiceNumber_All_Xpath));
                if (ClosedInvoicesUI.Count > 0)
                {

                    foreach (IWebElement element in ClosedInvoicesUI)
                    {

                        ClosedInvoiceNumberListValuesUI.Add((element.Text).ToString());
                    }
                }

                ClosedInvoiceNumberListValuesUI.Sort();

                dagrtNumber = DBHelper.GetAllDagrtNumberForALLStations(station_Id);
                closedInvoicesNumberListValuesDB = DBHelper.GetAllMatchingDAGRTCustomerClosedInvoices(dagrtNumber);
                closedInvoicesNumberListValuesDB.Sort();
                CollectionAssert.AreEqual(ClosedInvoiceNumberListValuesUI, closedInvoicesNumberListValuesDB);
            }
            else
            {
                VerifyElementPresent(attributeName_xpath, CustomerInvoiceGridEmpty_Xpath, "No Results Found");
                Report.WriteLine("No Results found");

            }

        }


    }
}
