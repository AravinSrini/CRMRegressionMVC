using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest
{
    [Binding]
    public class CRMInvoicing_PaymentIconCustomerUsersSteps : ObjectRepository
    {
        CommonMethodsCrm crm = new CommonMethodsCrm();
        [Given(@"I am a shp\.entry or shp\.inquiry user with access to Payment (.*) and (.*)")]
        public void GivenIAmAShp_EntryOrShp_InquiryUserWithAccessToPaymentAnd(string userName, string password)
        {
            crm.LoginToCRMApplication(userName, password);
        }

        [When(@"I am on dashboard page")]
        public void WhenIAmOnDashboardPage()
        {
            Report.WriteLine("user is on dashboard page");
            WaitForElementVisible(attributeName_xpath, NewDashboard_Header_Text_Xpath, "dashboard");
        }

        [When(@"I click on Payments icon on the left navigational pane")]
        public void WhenIClickOnPaymentsIconOnTheLeftNavigationalPane()
        {
            Report.WriteLine("click on Payments icon");
            Click(attributeName_id, paymentsicon_id);
        }

        [When(@"I click on Payments icon on the left navigational pane&PNC url is not present")]
        public void WhenIClickOnPaymentsIconOnTheLeftNavigationalPanePNCUrlIsNotPresent()
        {
            Report.WriteLine("click on Payments icon");
            Click(attributeName_id, paymentsicon_id);
        }

        [Then(@"I should be displayed with Payments icon on the left navigational pane")]
        public void ThenIShouldBeDisplayedWithPaymentsIconOnTheLeftNavigationalPane()
        {
            Report.WriteLine("Displayed With PaymentsIcon On The LeftNavigationalPane");
            VerifyElementVisible(attributeName_id, paymentsicon_id, "paymentsicon");
        }

        [Then(@"I will be auto login & launch the PNC website in a new browser tab")]
        public void ThenIWillBeAutoLoginLaunchThePNCWebsiteInANewBrowserTab()
        {            
            string url = "https://pncdemo.payerexpress.net/ebp/RRDONNELLEY/BillPay";
            Report.WriteLine("Website will be navigated to the New Tab");
            Thread.Sleep(20000);
            bool val=WindowHandling(url);
            if (val==true)
            {
                Report.WriteLine("URL is matching in New Tab");
            }
        }

        [Then(@"(.*) will be displayed")]
        public void ThenWillBeDisplayed(string error)
        {
            Report.WriteLine("I will be displayed with error message");
            Thread.Sleep(20000);
            VerifyElementVisible(attributeName_xpath, errorforpayments_xpath, error);            
        }
        
    }
    
}
