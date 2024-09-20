using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.Implementations.QuoteList;
using CRM.UITest.Helper.Interfaces.Quote;
using CRM.UITest.Helper.ViewModel.RateModel;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Quote_List.QuoteList_LayoutPage
{
    [Binding]
    public  class QuoteList_InactiveCustomer_StationUsersSteps : Quotelist
    {
        CommonMethodsCrm crm = new CommonMethodsCrm();
        int CustomerId;

        [Given(@"I am an sales, sales management, operations, or station owner user (.*),(.*)")]
        public void GivenIAmAnSalesSalesManagementOperationsOrStationOwnerUser(string Username, string Password)
        {
            crm.LoginToCRMApplication(Username, Password);
        }

        [Given(@"I am on the Quote List Page")]
        public void GivenIAmOnTheQuoteListPage()
        {
            Report.WriteLine("Click on the Quote Module");
            Click(attributeName_xpath, QuoteIconModule_Xpath);

            Report.WriteLine("I am on the Quote List Page");
            VerifyElementPresent(attributeName_xpath, QuoteList_PageTitle_Xpath, "Quote List");
        }


        [When(@"I am associated to a CRM customer (.*) in Inactive Status")]
        public void WhenIAmAssociatedToACRMCustomerInInactiveStatus(string Customername)
        {
             CustomerId = DBHelper.GetCustomerSetupId(Customername);

            CRM.UITest.Entities.Proxy.CustomerAccount CustomerAccountStatus = new CRM.UITest.Entities.Proxy.CustomerAccount();
            CustomerAccountStatus =  DBHelper.GetIsActiveIdStatus(CustomerId);
            if(CustomerAccountStatus.IsActive == false)
            {
                Report.WriteLine("Customer is in Inactive Status");
            }
            else
            {
                Report.WriteLine("Customer is in Active Status");
            }


        }


        [When(@"I see a (.*) from the drop down list that is inactive")]
        public void WhenISeeAFromTheDropDownListThatIsInactive(string Customername)
        {
            CRM.UITest.Entities.Proxy.CustomerAccount CustomerAccountStatus = new CRM.UITest.Entities.Proxy.CustomerAccount();
            CustomerAccountStatus = DBHelper.GetIsActiveIdStatus(CustomerId);
            if(CustomerAccountStatus.IsActive == false)
            {
                Report.WriteLine("Select Customer Name from the dropdown list");

                Report.WriteLine("Verified this customer is in Inactive Status");
                Click(attributeName_xpath, QuoteList_CustomerDropdown_Xpath);
                SendKeys(attributeName_xpath, ".//*[@id='CategoryType_chosen']/div/div/input", Customername);
                Click(attributeName_xpath, ".//*[@id='CategoryType_chosen']/div/ul/li[2]");
            
            }

           
        }

        [Then(@"Verify that (.*) will have an indicator that the account is inactive")]
        public void ThenVerifyThatWillHaveAnIndicatorThatTheAccountIsInactive(string Customername)
        {
            string ExpIndicatesColor = "rgba(204, 204, 204, 1)";
            
            Click(attributeName_xpath, QuoteList_CustomerDropdown_Xpath);
            SendKeys(attributeName_xpath, ".//*[@id='CategoryType_chosen']/div/div/input", Customername);
            string Indicatorecolor = GetCSSValue(attributeName_xpath, ".//*[@id='CategoryType_chosen']/div/ul/li[2]", "color");
            Assert.AreEqual(ExpIndicatesColor, Indicatorecolor);
        }
        [When(@"I selects the Inactive Prakash MG from the customer list")]
        public void WhenISelectsTheInactivePrakashMGFromTheCustomerList(string Customername)
        {
            Click(attributeName_xpath, QuoteList_CustomerDropdown_Xpath);

            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_CustomerDropdownList_Xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == Customername)
                {
                    Report.WriteLine("This Customer is in Inactive Status");
                    DropDownList[i].Click();
                    break;
                }
            }
        }


        [Then(@"Verify that SubmitRateRequest Button will be inactive")]
        public void ThenVerifyThatSubmitRateRequestButtonWillBeInactive()
        {
            Report.WriteLine("Submit Rate Request Button is not visible");
            VerifyElementNotEnabled(attributeName_xpath, QuoteSubmitrateRequest_Button_Xpath, "Submit Rate Request");
          

        }

        [When(@"The (.*) has non expired quotes within the past Thirty days")]
        public void WhenTheHasNonExpiredQuotesWithinThePastThirtyDays(string Customername)
        {
            Thread.Sleep(10000);
            List<string> QuoteList = new List<string>();
            IMgQuoteListForSalesUser MGQuotes = new MgQuoteListForSalesUser();

            List<QuoteListExtractModel> QModel = MGQuotes.GetMgQuoteList(Customername, true);

            if (QModel != null)
            {
                for (int j = 0; j < QModel.Count; j++)
                {
                    QuoteList.Add(QModel[j].QuoteReferenceNumber);
                }


                IList<IWebElement> UIQuotes = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_RequestNumberInternal_Values_Xpath));
                List<string> UIValue = new List<string>();

                for (int k = 0; k < UIQuotes.Count; k++)
                {
                    string UIQuoteNumber = UIQuotes[k].Text;
                    UIValue.Add(UIQuoteNumber);
                }
                CollectionAssert.AreEqual(QuoteList.OrderBy(q => q).ToList(), UIValue.OrderBy(q => q).ToList());
                Report.WriteLine("Displaying default quote list in the UI is matching with API results");
            }
            else
            {
                VerifyElementPresent(attributeName_xpath, QuoteList_NoResults_Xpath, "No Results");
                Report.WriteLine("No quotes exists for the selected account");
            }

           
        }

        [When(@"I click on the Expired quotes radio button within the past thirty days")]
        public void WhenIClickOnTheExpiredQuotesRadioButtonWithinThePastThirtyDays()
        {
            Click(attributeName_xpath, QuoteList_ExpiredLabel_Xpath);
        }


        [When(@"I click on the New quotes radio button within the past thirty days")]
        public void WhenIClickOnTheNewQuotesRadioButtonWithinThePastThirtyDays()
        {
            Click(attributeName_xpath, QuoteList_NewLabel_Xpath);

            
        }




        [When(@"I expand the details of any Non Expired LTL Quote")]
        public void WhenIExpandTheDetailsOfAnyNonExpiredLTLQuote()
        {
            Report.WriteLine("Click on New radio button");
            Click(attributeName_xpath, QuoteList_NewLabel_Xpath);
            Thread.Sleep(3000);

            int row = GetCount(attributeName_xpath, ".//*[@id='QuotesGrid']/tbody/tr");
            if(row > 1)
            {
                Report.WriteLine("Expand the first non expired quote from quote list");
                Click(attributeName_xpath, QuoteList_Internal_Expand_FirstRecord_Xpath);
                Thread.Sleep(5000);
            }
        }

        [Then(@"Verify the Create_Shipment Button will be disabled")]
        public void ThenVerifyTheCreate_ShipmentButtonWillBeDisabled()
        {
            int row = GetCount(attributeName_xpath, ".//*[@id='QuotesGrid']/tbody/tr");
           
                String value = Gettext(attributeName_xpath, ".//*[@id='QuotesGrid']/tbody/tr/td");
                if (value.Equals("No Results Found"))
                {
                    Report.WriteLine("No New quotes available for the selected customer");
                }
                else
                {
                    Report.WriteLine("Expand the first non expired quote from quote list");
                    Click(attributeName_xpath, QuoteList_Internal_Expand_FirstRecord_Xpath);
                    Thread.Sleep(5000);
                    Report.WriteLine("Create Shipment Button will be disable");
                    VerifyElementNotEnabled(attributeName_id, QuoteDetails_CreateShipmentButton_Id, "Create Shipment");
                }
           



            
        }

        [When(@"I expand the details of any Expired LTL Quote")]
        public void WhenIExpandTheDetailsOfAnyExpiredLTLQuote()
        {
            Report.WriteLine("Click on Expired radio button");
            Click(attributeName_xpath, QuoteList_ExpiredLabel_Xpath);
            Thread.Sleep(5000);

            int row = GetCount(attributeName_xpath, ".//*[@id='QuotesGrid']/tbody/tr");
            if (row > 1)
            {
                Report.WriteLine("Expand the first expired quote from quote list");
                Click(attributeName_xpath, QuoteList_Expand_FirstRecord_Xpath);
                Thread.Sleep(5000);
            }
        }

        [Then(@"Verify the Re_Quote Button will be disabled")]
        public void ThenVerifyTheRe_QuoteButtonWillBeDisabled()
        {
            int row = GetCount(attributeName_xpath, ".//*[@id='QuotesGrid']/tbody/tr");

            String value = Gettext(attributeName_xpath, ".//*[@id='QuotesGrid']/tbody/tr/td");
            if (value.Equals("No Results Found"))
            {
                Report.WriteLine("No expired quotes available for the selected customer");
            }
            else
            {
                Report.WriteLine("Expand the first non expired quote from quote list");
                Click(attributeName_xpath, QuoteList_Internal_Expand_FirstRecord_Xpath);
                Thread.Sleep(5000);
                Report.WriteLine("Re Quote Button is Disabled");
                VerifyElementNotEnabled(attributeName_id, QuoteDetails_RequoteButton_id, "Re-quote");
            }
            
        }



    }
}
