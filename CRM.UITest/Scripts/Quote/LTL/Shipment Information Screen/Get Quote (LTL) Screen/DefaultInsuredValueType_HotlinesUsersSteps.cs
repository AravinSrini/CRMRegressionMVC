using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Quote.LTL.Shipment_Information_Screen.Get_Quote__LTL__Screen
{
    [Binding]
    public class DefaultInsuredValueType_HotlinesUsersSteps: ObjectRepository
    {
        [Given(@"I am a DLS auto-login user and login into application with valid (.*) and (.*)")]
        public void GivenIAmADLSAuto_LoginUserAndLoginIntoApplicationWithValidNatAndTeT(string UserName, string Password)
        {
            string userName = UserName;
            string password = Password;
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(userName, password);
        }

        [Given(@"I am taken to the new responsive Get Quote LTL screen")]
        public void GivenIAmTakenToTheNewResponsiveGetQuoteLTLScreen()
        {
            Report.WriteLine("Verifying Get Quote (LTL) page text");
            VerifyElementVisible(attributeName_xpath, LTL_shipmentinformationpageheader_Xpath, "Get Quote (LTL)");
        }


        [Given(@"I am taken to the new responsive LTL Shipment Information screen")]
        public void GivenIAmTakenToTheNewResponsiveLTLShipmentInformationScreen()
        {
            Report.WriteLine("Verifying LTL shipment information page text");
            VerifyElementVisible(attributeName_xpath, LTL_shipmentinformationpageheader_Xpath, "Get Quote (LTL)");           
        }

        [When(@"I enter a value in the Enter Insured Value field (.*)")]
        public void WhenIEnterAValueInTheEnterInsuredValueField(string InsuredValue)
        {
            Report.WriteLine("Entering data in Enter Insured value text box");
            SendKeys(attributeName_id, LTL_InusredRate_Id, InsuredValue);            
        }

        [Then(@"Insured Value type should be default to used type in Get Quote ltl screen")]
        public void ThenInsuredValueTypeShouldBeDefaultToUsedTypeInGetQuoteLtlScreen()
        {
            Report.WriteLine("Verifying the default selected insured type dropdown value");
            Verifytext(attributeName_xpath, InsuredValueDefault, "Used");
        }


        [Then(@"Insured Value type should be default to used type in ltl shipment information screen")]
        public void ThenInsuredValueTypeShouldBeDefaultToUsedTypeInLtlShipmentInformationScreen()
        {
            Report.WriteLine("Verifying the default selected insured type dropdown value");
            Verifytext(attributeName_xpath, InsuredValueDefault, "Used");
        }
        
        [Then(@"passed '(.*)' valud should be selected in the dropdown")]
        public void ThenPassedValudShouldBeSelectedInTheDropdown(string ExpValue)
        {
            Report.WriteLine("Verifying the selected insured type dropdown value");
            Verifytext(attributeName_xpath, InsuredValueDefault, ExpValue);
        }
    }
}
