using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
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
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Customer_Invoices
{
    [Binding]
    public class Customer_Invoice___Filter_Invoices_by_RoleSteps : Customer_Invoice
    {
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();

        [Given(@"I am a Sales, ShipEntry, ShipEntryNoRates, ShipInquiry or ShipInquiryNoRates user")]
        public void GivenIAmASalesShipEntryShipEntryNoRatesShipInquiryOrShipInquiryNoRatesUser()
        {
            string username = ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();
            string password = ConfigurationManager.AppSettings["ExternalUserPassword"].ToString();
            CrmLogin.LoginToCRMApplication(username, password);
        }


        [Given(@"I am a Sales user")]
        public void GivenIAmASalesUser()
        {
            
            string username = ConfigurationManager.AppSettings["username-CurrentSprintSales"].ToString();
            string password = ConfigurationManager.AppSettings["password-CurrentSprintSales"].ToString();
            CrmLogin.LoginToCRMApplication(username, password);
        }


        //[When(@"I arrive on the Customer Invoices list page")]
        //public void WhenIArriveOnTheCustomerInvoicesListPage()
        //{
        //    Click(attributeName_xpath, customerInvoiceIcon_xpath);
        //    string customerInvHeaderText = Gettext(attributeName_xpath, customerInvoicesHeader_xpath);
        //    Assert.AreEqual("Customer Invoices", customerInvHeaderText);
        //}

        [Then(@"I should see invoices for the customer account that I am associated to and I can also see invoices for all the sub accounts")]
        public void ThenIShouldSeeInvoicesForTheCustomerAccountThatIAmAssociatedToAndICanAlsoSeeInvoicesForAllTheSubAccounts()
        {
            Report.WriteLine("User should see Dashboard icon in the left navigation menu of Landing Page");
            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);


            List<AppUserClaimInfo> claimValue = new List<AppUserClaimInfo>();
            List<AppUserClaimInfo> claimDetails = IDP.GetUserClaimDetails("salesDelta");
            claimValue = claimDetails.Where(x => x.ClaimType == "dlscrm-CustomerSetUpId").Select(x => new AppUserClaimInfo
            {
                ClaimValue = x.ClaimValue,

            }).ToList();
            List<int> custSetupId = claimValue.Select(x => Convert.ToInt32(x.ClaimValue)).ToList();

            List<int> custAccId = DBHelper.GetCustomerAccountNumber(custSetupId);
            List<string> CustNames_p = DBHelper.CustomerNameOfPrimaryAccount(custSetupId);
            List<string> CustNames_S = DBHelper.CustomerNameOfSubAccountUnderPrimaryAccount(custAccId);
            CustNames_p.AddRange(CustNames_S);

            List<string> CustInv_CustNames = DBHelper.GetCustomerNameFromCustomerInvoice();

            List<string> mappedCust = new List<string>();
            for (int i = 0; i < CustInv_CustNames.Count; i++)
            {
                for (int j = 0; j < CustNames_p.Count; j++)
                {
                    if (CustInv_CustNames[i].Equals(CustNames_p[j]))
                    {
                        mappedCust.Add(CustInv_CustNames[i]);
                        Report.WriteLine("CustomerInvoice table contain the customer which is mapped to the sales User");
                    }
                    else
                    {
                        Report.WriteLine("CustomerInvoice table does not contain the customer which is mapped to the sales User");
                    }
                }
            }

            Report.WriteLine("Display option dropdown");
            Click(attributeName_xpath, CustomerInvoice_TopGrid_DisplayListViewDropdown_Xpath);
            SelectDropdownlistvalue(attributeName_xpath, CustomerInvoice_TopGrid_DisplayListDropdownOptions_Xpath, "ALL");

            Click(attributeName_xpath, CustomerInvoice_ALLRadiobutton_xpath);

            List<string> CustUI = new List<string>();
            IList<IWebElement> typeofIntegration = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='gridCustomerInvoiceList']//tr/td[3]/span[2]"));
            foreach (IWebElement element in typeofIntegration)
            {
                CustUI.Add((element.Text).ToString());

            }

            CustUI.Sort();
            mappedCust.Sort();


            for (int i = 0; i < mappedCust.Count; i++)
            {
                if (CustUI[i] == mappedCust[i])
                {
                    Report.WriteLine("Expected value :" + mappedCust[i] + " is equal to the actual value: " + CustUI[i]);
                }
                else
                {
                    Report.WriteFailure("Customer names not matching with mapped customer names for the user");
                }


            }


        }


        [Then(@"I should see invoices for the customer account that I am associated to and I can also see invoices for all the sub accounts for ShipEntry, ShipEntryNoRates, ShipInquiry or ShipInquiryNoRates user")]
        public void ThenIShouldSeeInvoicesForTheCustomerAccountThatIAmAssociatedToAndICanAlsoSeeInvoicesForAllTheSubAccountsForShipEntryShipEntryNoRatesShipInquiryOrShipInquiryNoRatesUser()
        {
            Report.WriteLine("User should see Dashboard icon in the left navigation menu of Landing Page");
            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);

            string setupID = IDP.GetClaimValue("zzzext", "dlscrm-CustomerSetUpId");            
            int custSetupId = Convert.ToInt32(setupID);

            int accId = DBHelper.GetAccountNumber(custSetupId);
            string cust = DBHelper.CustomerName(custSetupId);

            

            List<string> CustNames_p = DBHelper.Get_CustomerNameOfPrimaryAccount(custSetupId);

            List<string> CustNames = DBHelper.GetCustomerNameOfSubAccountUnderPrimaryAccount(cust);

            CustNames_p.AddRange(CustNames);

            List<string> CustInv_CustNames = DBHelper.GetCustomerNameFromCustomerInvoice();

            List<string> mappedCust = new List<string>();

            for (int i = 0; i < CustInv_CustNames.Count; i++)
            {
                for (int j = 0; j < CustNames_p.Count; j++)
                {
                    if (CustInv_CustNames[i].Equals(CustNames_p[j]))
                    {
                        mappedCust.Add(CustInv_CustNames[i]);
                        Report.WriteLine("CustomerInvoice table contain the customer which is mapped to the sales User");
                    }
                    else
                    {
                        Report.WriteLine("CustomerInvoice table does not contain the customer which is mapped to the sales User");
                    }
                }
            }

            Report.WriteLine("Display option dropdown");
            Click(attributeName_xpath, CustomerInvoice_TopGrid_DisplayListViewDropdown_Xpath);
            SelectDropdownlistvalue(attributeName_xpath, CustomerInvoice_TopGrid_DisplayListDropdownOptions_Xpath, "ALL");

            Click(attributeName_xpath, CustomerInvoice_ALLRadiobutton_xpath);

            List<string> CustUI = new List<string>();
            IList<IWebElement> typeofIntegration = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='gridCustomerInvoiceList']//tr/td[3]/span[2]"));
            foreach (IWebElement element in typeofIntegration)
            {
                CustUI.Add((element.Text).ToString());

            }

            CustUI.Sort();
            mappedCust.Sort();

            
            for (int i = 0; i < mappedCust.Count; i++)
            {
                if (CustUI[i] == mappedCust[i])
                {
                    Report.WriteLine("Expected value :" + mappedCust[i] + " is equal to the actual value: " + CustUI[i]);
                }
                else
                {
                    Report.WriteFailure("Sorting is not as expected");
                }
              

            }

        }



        [Given(@"I am a Sales Management, Operations or Station Owner user")]
        public void GivenIAmASalesManagementOperationsOrStationOwnerUser()
        {
            string username = ConfigurationManager.AppSettings["username-OpStage"].ToString();
            string password = ConfigurationManager.AppSettings["password-OpStage"].ToString();
            CrmLogin.LoginToCRMApplication(username, password);
        }


        [Then(@"I should see only the Invoices for the customers of the stations that I am associated to")]
        public void ThenIShouldSeeOnlyTheInvoicesForTheCustomersOfTheStationsThatIAmAssociatedTo()
        {
            Report.WriteLine("User should see Dashboard icon in the left navigation menu of Landing Page");
            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);


            List<AppUserClaimInfo> claimValue = new List<AppUserClaimInfo>();
            List<AppUserClaimInfo> claimDetails = IDP.GetUserClaimDetails("Opstage");
            claimValue = claimDetails.Where(x => x.ClaimType == "dlscrm-StationId").Select(x => new AppUserClaimInfo
            {
                ClaimValue = x.ClaimValue,

            }).ToList();

            //string stationId = IDP.GetClaimValue("Opstage", "dlscrm-StationId");

            List<string> stationId = claimValue.Select(x => x.ClaimValue).ToList();

            List<CustomerSetup> customerNames = DBHelper.GetAllCustomersForAllTheStations(stationId);
            List<string> cust = customerNames.Select(x => x.CustomerName).ToList();
            Thread.Sleep(400);

            List<string> CustInv_CustNames = DBHelper.GetCustomerNameFromCustomerInvoice();

            List<string> mappedCust = new List<string>();

            for (int i = 0; i < CustInv_CustNames.Count; i++)
            {
                for (int j = 0; j < cust.Count; j++)
                {
                    if (CustInv_CustNames[i].Equals(cust[j]))
                    {
                        mappedCust.Add(CustInv_CustNames[i]);
                        Report.WriteLine("CustomerInvoice table contain the customer which is mapped to the sales User");
                    }
                    else
                    {
                        Report.WriteLine("CustomerInvoice table does not contain the customer which is mapped to the sales User");
                    }
                }
            }



            Report.WriteLine("Display option dropdown");
            Click(attributeName_xpath, CustomerInvoice_TopGrid_DisplayListViewDropdown_Xpath);
            SelectDropdownlistvalue(attributeName_xpath, CustomerInvoice_TopGrid_DisplayListDropdownOptions_Xpath, "ALL");

            Click(attributeName_xpath, CustomerInvoice_ALLRadiobutton_xpath);

            List<string> CustUI = new List<string>();
            IList<IWebElement> typeofIntegration = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='gridCustomerInvoiceList']//tr/td[3]/span[2]"));
            foreach (IWebElement element in typeofIntegration)
            {
                CustUI.Add((element.Text).ToString());

            }

            CustUI.Sort();
            mappedCust.Sort();


            for (int i = 0; i < mappedCust.Count; i++)
            {
                if (CustUI[i] == mappedCust[i])
                {
                    Report.WriteLine("Expected value :" + mappedCust[i] + " is equal to the actual value: " + CustUI[i]);
                }
                else
                {
                    Report.WriteFailure("Sorting is not as expected");
                }


            }










        }




    }
}
