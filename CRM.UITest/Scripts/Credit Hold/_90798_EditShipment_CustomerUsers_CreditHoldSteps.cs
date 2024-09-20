using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Objects;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Collections.Generic;
using System.Configuration;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Credit_Hold
{
    [Binding]
    public class _90798_EditShipment_CustomerUsers_CreditHoldSteps : Shipmentlist
    {
        CommonMethodsCrm crmLogin = new CommonMethodsCrm();
        List<string> ShipmentStatusList;
        List<string> ShipmentRefIdList;
        IList<IWebElement> ShipmentRefId;
        IList<IWebElement> ShipmentStatus;
        bool checkCustomerIsOnCreditHold;

        [Given(@"I am a shp\.entry or shp\.entrynorates user whose (.*) is on Credit Hold"), Scope(Tag = "90798")]
        public void GivenIAmAShp_EntryOrShp_EntrynoratesUserWhoseIsOnCreditHold(string customer)
        {
            string userName = ConfigurationManager.AppSettings["username-ExternalCredithold"].ToString();
            string password = ConfigurationManager.AppSettings["password-ExternalCredithold"].ToString();
            crmLogin.LoginToCRMApplication(userName, password);
            Report.WriteLine("Logged in as " + userName);

            checkCustomerIsOnCreditHold = DBHelper.GetCreditHoldCustomerDetails(customer);
            
            if (checkCustomerIsOnCreditHold)
            {                
                Report.WriteLine("User associated customer is on Credit Hold");
            }
            else
            {
                Report.WriteFailure("User associated customer is not on Credit Hold");
            }
        }

        [Given(@"I am a shp\.entry or shp\.entrynorates user whose (.*) is not on Credit Hold"), Scope(Tag = "90798")]
        public void GivenIAmAShp_EntryOrShp_EntrynoratesUserWhoseIsNotOnCreditHold(string customer)
        {
            string userName = ConfigurationManager.AppSettings["username-CurrentSprintshpentry"].ToString();
            string password = ConfigurationManager.AppSettings["password-CurrentSprintshpentry"].ToString();
            crmLogin.LoginToCRMApplication(userName, password);
            Report.WriteLine("Logged in as " + userName);

            checkCustomerIsOnCreditHold = DBHelper.GetCreditHoldCustomerDetails(customer);
            if (checkCustomerIsOnCreditHold == false)
            {
                Report.WriteLine("User associated customer is not on Credit Hold");                
            }
            else
            {
                Report.WriteFailure("User associated customer is on Credit Hold");
            }
        }

        [When(@"I navigated to Shipment List page")]
        public void WhenINavigatedToShipmentListPage()
        {
            Report.WriteLine("Click on the Shipment icon from the left navigation bar");
            Click(attributeName_xpath, ShipmentModule_Xpath);

            Report.WriteLine("I am on the shipment list page");
            Verifytext(attributeName_xpath, ShipmentList_PageTitle_Xpath, "Shipment List");
        }

        [Then(@"I will not be displayed with the Edit button for any eligible LTL shipments")]
        public void ThenIWillNotBeDisplayedWithTheEditButtonForAnyEligibleLTLShipments()
        {
            GetShipRefIDandStatus();
            if (ShipmentRefIdList.Count >= 1)
            {

                for (int i = 0; i < ShipmentRefId.Count; i++)
                {
                    ShipmentStatusList[i] = ShipmentStatusList[i].Trim();
                    if (ShipmentStatusList[i] == "Pending" || ShipmentStatusList[i] == "Pre-Plan" || ShipmentStatusList[i] == "Rated" || ShipmentStatusList[i] == "Unscheduled" || ShipmentStatusList[i] == "Tender Rejected" || ShipmentStatusList[i] == "Scheduled")
                    {
                        VerifyElementNotPresent(attributeName_xpath, "//tbody/tr[" + (i + 1) + "]//span[@class='EditShipmentSection']", "EDIT");
                        Report.WriteLine("Edit button not displayed for the eligible shipments");
                    }
                    else
                    {
                        Report.WriteFailure("Edit button displaying for the eligible shipments");
                    }

                }
            }
            else
            {
                Report.WriteFailure("There are no shipments found in the shipment list for the associated customer");
            }
        }


        [Then(@"I will see the Edit button for any eligible LTL shipments")]
        public void ThenIWillSeeTheEditButtonForAnyEligibleLTLShipments()
        {
            GetShipRefIDandStatus();
            if (ShipmentRefIdList.Count >= 1)
            {
                for (int i = 0; i < ShipmentRefId.Count; i++)
                {
                    ShipmentStatusList[i] = ShipmentStatusList[i].Trim();
                    if (ShipmentStatusList[i] == "Pending" || ShipmentStatusList[i] == "Pre-Plan" || ShipmentStatusList[i] == "Rated" || ShipmentStatusList[i] == "Unscheduled" || ShipmentStatusList[i] == "Tender Rejected" || ShipmentStatusList[i] == "Scheduled")
                    {
                        VerifyElementPresent(attributeName_xpath, "//tbody/tr[" + (i + 1) + "]//span[@class='EditShipmentSection']", "EDIT");
                        Report.WriteLine("Edit button displayed for the eligible shipments of " + ShipmentStatusList[i]);
                    }
                    else
                    {
                        Report.WriteLine("Edit button not displayed for the shipments of " + ShipmentStatusList[i]);
                    }

                }
            }
            else
            {
                Report.WriteFailure("There are no shipments found in the shipment list for the associated customer");
            }
        }
        public void GetShipRefIDandStatus()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ShipmentListSearchBox_Id);
            SendKeys(attributeName_id, ShipmentListSearchBox_Id, "LTL");

            ShipmentRefId = GlobalVariables.webDriver.FindElements(By.Id(ShipmentDetails_Id));
            ShipmentRefIdList = new List<string>();
            foreach (var refIDList in ShipmentRefId)
            {
                ShipmentRefIdList.Add(refIDList.Text);
            }

            ShipmentStatus = GlobalVariables.webDriver.FindElements(By.XPath(FilterSection_StausColumn_Xpath));
            ShipmentStatusList = new List<string>();
            foreach (var statusList in ShipmentStatus)
            {
                ShipmentStatusList.Add(statusList.Text);
            }
        }
    }

}
