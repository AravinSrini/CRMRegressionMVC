using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using TechTalk.SpecFlow;


namespace CRM.UITest.Scripts.Shipment.ShipmentList_InternalUsers.Shipment_List_Reference_Number_Search
{
    [Binding]
    public class ShipmentList_SearchResultsforSubAccountShipmentsSteps : Shipmentlist
    {
        string[] testDataRefNumber;
        
        [Given(@"I'm a CRM User with access to Shipment List(.*)")]
        public void GivenIMACRMUserWithAccessToShipmentList(string Usertype)
        {
            if (Usertype == "External")
            {
                string username = ConfigurationManager.AppSettings["username-Both"].ToString();
                string password = ConfigurationManager.AppSettings["password-Both"].ToString();
                CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
                CrmLogin.LoginToCRMApplication(username, password);
            }
            else if (Usertype == "Internal")
            {
                string username = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
                string password = ConfigurationManager.AppSettings["password-crmOperation"].ToString();
                CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
                CrmLogin.LoginToCRMApplication(username, password);
            }
            else if(Usertype == "Sales")
            {
                string username = ConfigurationManager.AppSettings["username-salesdelta"].ToString();
                string password = ConfigurationManager.AppSettings["password-salesdelta"].ToString();
                CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
                CrmLogin.LoginToCRMApplication(username, password);
            }
        }

        [Then(@"I will see the Shipment List related to that Sub-Customer(.*)")]
        public void ThenIWillSeeTheShipmentListRelatedToThatSub_Customer(string Usertype)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            string gridTableColumn = Gettext(attributeName_xpath, ".//*[@id='ShipmentGrid']/thead/tr/th[2]");
            string userType = string.Empty;
            List<string> ShipmentListRefNumber_UI;

            if (Usertype == "External")
            {
                userType = "External";
                ShipmentListRefNumber_UI = IndividualColumnData(".//*[@id='ShipmentGrid']/tbody/tr/td[1]/button");
                for (int i = 0; i < ShipmentListRefNumber_UI.Count; i++)
                {
                    if (testDataRefNumber.Contains(ShipmentListRefNumber_UI[i]))
                    {
                        Report.WriteLine("Searched Reference is aapeared in the Grid");
                    }
                    else
                    {
                        Assert.Fail();
                    }
                }
            }
            else if(Usertype == "Internal" || Usertype == "Sales")
            {
                userType = "Internal";
                ShipmentListRefNumber_UI = IndividualColumnData(".//*[@id='ShipmentGrid']/tbody/tr/td[2]/button");
                for (int i = 0; i < ShipmentListRefNumber_UI.Count; i++)
                {
                    if (testDataRefNumber.Contains(ShipmentListRefNumber_UI[i]))
                    {
                        Report.WriteLine("Searched Reference is aapeared in the Grid");
                    }
                    else
                    {
                        Assert.Fail();
                    }
                }
            }
        }

        [When(@"I search for any sub account shipment with  that I am associated to (.*)")]
        public void WhenISearchForAnySubAccountShipmentWithThatIAmAssociatedTo(string refNumber)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_xpath, ShipmentList_ReferenceNumLookup_Xpath, refNumber);
            Click(attributeName_xpath, ShipmentListRefLookUpArrow_Xpath);
            testDataRefNumber = refNumber.Split(',');
        }
    }
}
