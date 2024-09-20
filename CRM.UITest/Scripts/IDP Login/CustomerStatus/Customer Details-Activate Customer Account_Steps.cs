using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.IDP_Login.CustomerStatus
{
    [Binding]
    public class Customer_Details_Activate_Customer_Account_Steps : ObjectRepository
    {
        bool value = false;
        CommonMethodsCrm crm = new CommonMethodsCrm();

        [Given(@"I am ShpEntry, ShpEntryNoRates, ShpInquiry, ShpInquiryNoRates User associated to Active Customer Account(.*)")]
        public void GivenIAmShpEntryShpEntryNoRatesShpInquiryShpInquiryNoRatesUserAssociatedToActiveCustomerAccount(string customerAccount)
        {
          CustomerAccount accountDetails=  DBHelper.GetAccountDetails_By_CustomerName(customerAccount);
          value = accountDetails.IsActive;
            if (value)
            {
                Report.WriteLine("Customer is Active");
            }
            else
            {
                Report.WriteLine("Customer is In-Active");
            }
        }

        [When(@"I Try to logging in to the CRM Application (.*),(.*)")]
        public void WhenITryToLoggingInToTheCRMApplication(string Username, string Password)
        {
            if (value)
            {
                crm.LoginToCRMApplication(Username, Password);
            }
        }

        [Then(@"I should be able to login successfully in to the CRM Application")]
        public void ThenIShouldBeAbleToLoginSuccessfullyInToTheCRMApplication()
        {
            Thread.Sleep(10000);
            VerifyElementPresent(attributeName_id, UserDropdown_id,"User Name");
        }

    }
}
