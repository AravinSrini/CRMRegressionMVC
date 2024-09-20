using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using CRM.UITest.Objects;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRM.UITest.CommonMethods;
using System.Threading;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Confirmation_Screen__All_Users
{
    [Binding]
    public class ShipmentConfirmationLTL_PageBind_AllUsersSteps :AddShipments
    {
        CommonMethodsCrm crm = new CommonMethodsCrm();
        AddShipmentLTL ltl = new AddShipmentLTL();

        [Given(@"I am an operations, sales, sales management, or station owner user - (.*) and (.*)")]
        public void GivenIAmAnOperationsSalesSalesManagementOrStationOwnerUser_And(string Username, string Password)
        {
            crm.LoginToCRMApplication(Username, Password);
        }
        
        [When(@"I click on Submit button on Review and Submit page")]
        public void WhenIClickOnSubmitButtonOnReviewAndSubmitPage()
        {
            Report.WriteLine("Click on Submit shipment button");
            scrollpagedown();
            Thread.Sleep(2000);
            scrollpagedown();
            Thread.Sleep(2000);
            scrollpagedown();
            Click(attributeName_xpath, ReviewPage_SubmitButton_Xpath);
        }
        
        [When(@"I arrive on the Shipment Confirmation page")]
        public void WhenIArriveOnTheShipmentConfirmationPage()
        {
            Report.WriteLine("Shipment confirmation page");
            Verifytext(attributeName_xpath, confirmation_pageheader, "Shipment Confirmation (LTL)");
        }

        [Then(@"The following fields should be binded - '(.*)' ,'(.*)' and BOLNumber")]
        public void ThenTheFollowingFieldsShouldBeBinded_AndBOLNumber(string Service, string Status)
        {
            Report.WriteLine("Binding of Shipment Confirmation page values");
            Verifytext(attributeName_xpath, confirmation_Serviceslabel, "SERVICE:");
            string service = Gettext(attributeName_xpath, confirmation_ServicesValue_Xpath);
            Assert.AreEqual(service, Service);
            Verifytext(attributeName_xpath, confirmation_BOLNumberlabel, "BOL NUMBER:");
            string BOL = Gettext(attributeName_xpath, confirmation_BOLValue_Xpath);
            Verifytext(attributeName_xpath, confirmation_Statuslabel, "STATUS:");
            string status = Gettext(attributeName_xpath, confirmation_StatusValue_Xpath);
            Assert.AreEqual(status, status);
        }

        [Then(@"The following fields should be binded to internal users - '(.*)' ,'(.*)' and BOLNumber")]
        public void ThenTheFollowingFieldsShouldBeBindedToInternalUsers_AndBOLNumber(string Service, string Status)
        {
            Report.WriteLine("Binding of Shipment Confirmation page values for internal users");
            Verifytext(attributeName_xpath, confirmation_ServicesInternalLabel_Xpath, "SERVICE:");
            string service = Gettext(attributeName_xpath, confirmation_ServicevalueInternal_Xpath);
            Assert.AreEqual(service, Service);
            Verifytext(attributeName_xpath, confirmation_BOLNumberlabelInternal_Xpath, "BOL NUMBER:");
            string BOL = Gettext(attributeName_xpath, confirmation_BOLValue_Xpath);
            Verifytext(attributeName_xpath, confirmation_StatusLabelInternal_Xpath, "STATUS:");
            string status = Gettext(attributeName_xpath, confirmation_StatusValueInternal_Xpath);
            Assert.AreEqual(status, status);
        }





    }
}
