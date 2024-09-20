using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.IDP_Login.CustomerStatus
{
    [Binding]
    public class CustomerDetails_InactivateCustomerAccountSteps : ObjectRepository
    {
        bool _iSActiveCustomer;

        [Given(@"I am ShpEntry, ShpEntryNoRates, ShpInquiry, ShpInquiryNoRates User associated to Inactive Customer Account(.*),(.*),(.*)")]
        public void GivenIAmShpEntryShpEntryNoRatesShpInquiryShpInquiryNoRatesUserAssociatedToInactiveCustomerAccount(string Username, string Password, string CustomerName)
        {
            InactiveOrActiveCustomer AccountStatus = new InactiveOrActiveCustomer();
            _iSActiveCustomer = AccountStatus.GetCustomerStatus(Username, Password, CustomerName);
            
        }

        [When(@"I Try to logging in to the CRM Application")]
        public void WhenITryToLoggingInToTheCRMApplication()
        {
            Click(attributeName_xpath, IDP_Login_Xpath);
            Thread.Sleep(2000);
        }
        
        [Then(@"I will receive a Notification Message and will not be allowed to logging in to the CRM Application")]
        public void ThenIWillReceiveANotificationMessageAndWillNotBeAllowedToLoggingInToTheCRMApplication()
        {
            if (_iSActiveCustomer == false)
            {
                Report.WriteLine("Verifying the Notification Pop-Up");
                VerifyElementPresent(attributeName_id, "error-inactive-customer", "Notification Pop-Up");
                
                Report.WriteLine("Verifying the Notification text message");
                Verifytext(attributeName_xpath, ".//*[@id='error-inactive-customer']/div/div/div/div/div[2]/div/h6", "Unable to access your account at this time. Please contact your DLS representative for assistance.");

                Report.WriteLine("Verifying the presence of close button in the Pop-Up");
                VerifyElementPresent(attributeName_id, "btnOkForErrorInactiveCustomer", "Close button");

                Report.WriteLine("Customer Account is Invalid and the User associated to this Customer not allowed to login in to CRM Application");
            }
            else
            {
                Report.WriteLine("Customer Account is valid and the User associated to this Customer will able to login in to CRM Application");
            }
        }
    }
}
