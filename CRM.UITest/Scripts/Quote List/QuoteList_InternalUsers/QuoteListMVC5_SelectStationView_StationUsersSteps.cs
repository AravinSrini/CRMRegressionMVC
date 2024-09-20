using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.CsaServiceReference;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.Common;
using CRM.UITest.Helper.ViewModel.Shipment;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using Rrd.ServiceAccessLayer;
using CRM.UITest.Helper.Interfaces.Quote;
using CRM.UITest.Helper.Implementations.QuoteList;

namespace CRM.UITest.Scripts.Quote_List.QuoteList_InternalUsers
{
    [Binding]
    public class QuoteListMVC5_SelectStationView_StationUsersSteps:Quotelist
    {
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
        string errorMessage = null;

        [Given(@"I am a sales Management, Operations or Station Owner user")]
        public void GivenIAmASalesManagementOperationsOrStationOwnerUser()
        {
            string userName = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
            string password = ConfigurationManager.AppSettings["password-crmOperation"].ToString();
            CrmLogin.LoginToCRMApplication(userName, password);
        }

        [Given(@"I am on the Quote List page")]
        public void GivenIAmOnTheQuoteListPage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            string userName = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
            IdServerAccess idp = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);
            var claim = idp.VerifyIfUserHasClaim(userName, "dlscrm-role", "EnableQuoteListStationSelection");
            Thread.Sleep(4000);
            if (IsElementPresent(attributeName_xpath, MgErrorErrorCheck_Xpath, "Error")) Click(attributeName_xpath, MgErrorCloseButton_Xpath);
            if (claim == true)
            {
                Thread.Sleep(4000);
                Report.WriteLine("I have access to station selection from customer dropdown in quote list page");
                Click(attributeName_xpath, QuoteIconModule_Xpath);
                Report.WriteLine("Navigated to Quote List page");
                WaitForElementVisible(attributeName_xpath, QuoteList_HeaderText_xpath, "Quote List");
            }
            else
            {
                Report.WriteLine("I have access to only customer selection from customer dropdown in quote list page");
            }               
        }        

        [Given(@"I clicked on Customer List dropdown arrow")]
        public void GivenIClickedOnCustomerListDropdownArrow()
        {
            Report.WriteLine("Clicked on Customer Dropdown arrow");
            Click(attributeName_xpath, QuoteList_CustomerDropdown_Xpath);
        }
        
        [When(@"I click on the Customer list drop down arrow")]
        public void WhenIClickOnTheCustomerListDropDownArrow()
        {
            Report.WriteLine("Clicked on Customer Dropdown arrow");
            Click(attributeName_xpath, QuoteList_CustomerDropdown_Xpath);
        }

        [When(@"I selected a station")]
        public void WhenISelectedAStation()
        {
            Report.WriteLine("Selected a station");
            SelectDropdownValueFromList(attributeName_xpath, QuoteList_CustomerDropdownList_Xpath, "ZZZ - Web Services Test");
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Then(@"I have the option to select a station")]
        public void ThenIHaveTheOptionToSelectAStation()
        {
            Report.WriteLine("Select station from dropdown");
            SelectDropdownValueFromList(attributeName_xpath, QuoteList_CustomerDropdownList_Xpath, "ENT - Bolingbrook IL");
        }

        [Then(@"Quote list page will be refreshed to display submitted rate requests within the past 30days for the customers associated to the selected station")]
        public void ThenQuoteListPageWillBeRefreshedToDisplaySubmittedRateRequestsWithinThePastDaysForTheCustomersAssociatedToTheSelectedStation()
        {
            string station = "ZZZ - Web Services Test";
            GetListScreenDetails getListScreenDetails = new GetListScreenDetails();
            IList<ShipmentListViewModel> quotedata= getListScreenDetails.GetListScreenDetailsMG(station);
            List<String> QuoteList = new List<string>();
            if (quotedata != null)
            {
                for (int j = 1; j < quotedata.Count; j++)
                {
                    QuoteList.Add(quotedata[j].PrimaryReference);
                }
            }
            else
            {
                Report.WriteLine("Not received any reposnse from API for selected Station ID ");
            }
                    
            SelectDropdownlistvalue(attributeName_xpath, QuoteList_TopGrid_DisplayListDropdownOptions_Xpath, "ALL");
            GlobalVariables.webDriver.WaitForPageLoad();
            IList<IWebElement> quoteListUI = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_RequestNumberInternal_Values_Xpath));
            List<string> actualQuoteList = new List<string>();
            Report.WriteLine("UI values count are: " + quoteListUI);

            if (QuoteList.Count > 1)
            {

                for (int k = 0; k < quoteListUI.Count; k++)
                {
                    string UIShipValues = quoteListUI[k].Text;
                    actualQuoteList.Add(UIShipValues);
                }

            }
            else
            {
                Report.WriteLine("No Quotes exists for the selected station");
                VerifyElementPresent(attributeName_xpath, QuoteList_NoResults_Xpath, "No Records Found");
            }

            CustomerAccount customerAccount = DBHelper.GetStationDetailsByStationName("ZZZ - Web Services Test");

            string stationNameDB = DBHelper.GetStationNameonStationID(customerAccount.StationId);
            List<CustomerAccount> customerListValue = DBHelper.GetAccountsMappedforStation(stationNameDB);

            for (int k = 0; k < customerListValue.Count; k++)
            {
                if (customerListValue[k].TmsSystem == "CSA" || customerListValue[k].TmsSystem == "BOTH")
                {
                    ICsaQuoteListByLast30Days quoteCSA = new CsaQuoteListByLast30Days();
                    ShipmentListReponse quoteListAPI = quoteCSA.GetCsaQuoteListByLast30Days(Convert.ToInt32(customerListValue[k].CsaCustomerNumber), out errorMessage);
                    Report.WriteLine("CSA API values are: " + quoteListAPI);
                    if (quoteListAPI != null)
                    {
                        List<string> QuoteValue = quoteListAPI.Shipments.Select(a => a.Housebill).ToList();
                        foreach (var element in QuoteValue)
                        {
                            QuoteList.Add(element);
                        }
                    }
                    else
                    {
                        Report.WriteLine("Data not found for the CSA station account number" + customerListValue[k].CsaCustomerNumber);
                    }
                }
            }

            Assert.AreEqual(QuoteList.Count, actualQuoteList.Count);            
            Report.WriteLine("Displaying quote list in the UI is matching with API results");
        }
                
        [Then(@"the Submit Rate Request button is not visible")]
        public void ThenTheSubmitRateRequestButtonIsNotVisible()
        {
            Report.WriteLine("Submit Rate Request button is not visible");
            VerifyElementNotVisible(attributeName_xpath, QuoteSubmitrateRequest_Button_Xpath, "Submit Rate Request");
        }

    }
}
