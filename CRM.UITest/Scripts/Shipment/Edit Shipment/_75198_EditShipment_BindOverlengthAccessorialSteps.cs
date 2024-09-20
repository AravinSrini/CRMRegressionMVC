using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Configuration;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Edit_Shipment
{
    [Binding]
    public class _75198_EditShipment_BindOverlengthAccessorialSteps : AddShipments
    {
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
        string userName;
        string password;
        public string overlengthAcc = "//span[contains(text(),'Overlength')]";

        [Given(@"I am a shp\.entry , usersales, sales management, operations, or stationowner (.*) user")]
        public void GivenIAmAShp_EntryUsersalesSalesManagementOperationsOrStationownerUser(string UserType)
        {
            if (UserType.Equals("External"))
            {
                userName = ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();
                password = ConfigurationManager.AppSettings["ExternalUserPassword"].ToString();
            }
            else if (UserType.Equals("Internal"))
            {
                userName = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
                password = ConfigurationManager.AppSettings["password-crmOperation"].ToString();
            }
            else
            {

                userName = ConfigurationManager.AppSettings["username-salesdelta"].ToString();
                password = ConfigurationManager.AppSettings["password-salesdelta"].ToString();
            }

            CrmLogin.LoginToCRMApplication(userName, password);
        }

        [Given(@"I clicked on the (.*) Edit button of any displayed LTL shipment,which had an \(Overlength\) accessorial,")]
        public void GivenIClickedOnTheEditButtonOfAnyDisplayedLTLShipmentWhichHadAnOverlengthAccessorial(string UserType)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_id, QuoteSearchBox_Id, "ZZX002016162");
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Verifying one shipment present");
            bool value = IsElementPresent(attributeName_xpath, ShipmentListGridNoResult_Xpath, "No Results Found");
            if (value == true)
            { Assert.Fail("No Shipment found for the selected Customer"); }
            if (UserType.Equals("External"))
            { Click(attributeName_xpath, EditButtonShipmentlistpageExt_Xpath);
            }
            else
            { Click(attributeName_xpath, EditButtonShipmentlistpage_Xpath);
            }
            GlobalVariables.webDriver.WaitForPageLoad();
        }
        
        [Given(@"I am on the (.*) shipment List page for (.*) user")]
        public void GivenIAmOnTheShipmentListPageForUser(string Customer, string UserType)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ShipmentIcon_Id);
            if (UserType.Equals("Internal"))
            {
                Click(attributeName_xpath, ShipmentListInternal_CustomerDropdown_Xpath);
                GlobalVariables.webDriver.WaitForPageLoad();
                SelectDropdownValueFromList(attributeName_xpath, ShipmentList_CustomerDropdownValues_Xpath, Customer);
            }
            else if (UserType.Equals("Sales"))
            {
                Click(attributeName_xpath, ShipmentListInternal_CustomerDropdown_Xpath);
                GlobalVariables.webDriver.WaitForPageLoad();
                SelectDropdownValueFromList(attributeName_xpath, ShipmentList_CustomerDropdownValues_Xpath, Customer);

            }
        }
 
        
        [Then(@"the \(Overlength\) accessorial will be displayed in the \(Click to add services & accessorials\.\.\.\) field of the \(Shipping From\) section\.")]
        public void ThenTheOverlengthAccessorialWillBeDisplayedInTheClickToAddServicesAccessorials_FieldOfTheShippingFromSection_()
        {
        
            Verifytext(attributeName_xpath, overlengthAcc, "Overlength");

        }        
       
    }
}
