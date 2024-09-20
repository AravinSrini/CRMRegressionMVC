using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment
{
    [Binding]
    public class Shipment_InsuredValue_TermsAndConditionsModal_ShouldNotCloseOnClickingOutside: AddShipments
    {

        [Given(@"I am a DLS user and Login to application as a user with access to Shipments")]
        public void GivenIAmADLSUserAndLoginToApplicationAsAUserWithAccessToShipments()
        {
            string userName = ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();
            string password = ConfigurationManager.AppSettings["ExternalUserPassword"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(userName, password);
            Report.WriteLine("User logged into CRM application");
        }

        [Given(@"I Am on Add Shipment LTL page")]
        public void GivenIAmOnAddShipmentLTLPage()
        {
            Report.WriteLine("Clicked on Shipments icon");
            Click(attributeName_cssselector, ShipmentsIcon_css);
            GlobalVariables.webDriver.WaitForPageLoad();

            Report.WriteLine("Clicked on Add Shipment button");
            Click(attributeName_id, AddShipment_Button_id);
            GlobalVariables.webDriver.WaitForPageLoad();

            Report.WriteLine("Clicked on LTL tile");
            Click(attributeName_id, AddShipmentLTL_Button_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I Enter a value in Enter Insured Value field (.*)")]
        public void GivenIEnterAValueInEnterInsuredValueField(string insuredValue)
        {
            Report.WriteLine("Entered a valid data in Enter Insured Value field");
            SendKeys(attributeName_id, InsuredValue_TextBox_Id, insuredValue);
        }

        [Given(@"I am on Shipment Results LTL page")]
        public void GivenIAmOnShipmentResultsLTLPage()
        {
            Report.WriteLine("Clicked on View Rates button");
            Click(attributeName_xpath, ViewRatesButton_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
        }
    }
}
