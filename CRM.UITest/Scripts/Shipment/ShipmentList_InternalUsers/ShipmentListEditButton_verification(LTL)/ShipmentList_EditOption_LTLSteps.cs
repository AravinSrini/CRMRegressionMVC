using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.ShipmentList_InternalUsers.ShipmentListEditButton_verification_LTL_
{
    [Binding]
    public class ShipmentList_EditOption_LTLSteps : Shipmentlist
    {
        AddShipmentLTL ltl = new AddShipmentLTL();

        [When(@"I am navigated to the Shipment List page(.*),(.*)")]
        public void WhenIAmNavigatedToTheShipmentListPage(string UserType, string CustomerName)
        {
            ltl.NaviagteToShipmentList();

            if (UserType == "Internal")
            {
                Click(attributeName_xpath, ShipmentList_Customer_dropdown_Xpath);

                IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_Customer_dropdownValue_Xpath));
                int DropDownCount = DropDownList.Count;
                for (int i = 0; i < DropDownCount; i++)
                {
                    if (DropDownList[i].Text == CustomerName)
                    {
                        DropDownList[i].Click();
                        break;
                    }
                }
                Thread.Sleep(90000);
                SendKeys(attributeName_id, ShipmentListSearchBox_Id, "LTL");
                Thread.Sleep(4000);
            }
        }
        
        
        [Then(@"I will see Edit button for the Shipment Pending,PrePlan,Rated,UnScheduled,TenderRejected,Scheduled Status")]
        public void ThenIWillSeeEditButtonForTheShipmentPendingPrePlanRatedUnScheduledTenderRejectedScheduledStatus()
        {
            int rowcount = GetCount(attributeName_xpath, ShipmentList_NoOf_Rows_Xpath);
            if (rowcount >= 1)
            {
                IList<IWebElement> ShipmentList = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='ShipmentGrid']/tbody/tr/td[1]"));
                for (int i = 0; i < ShipmentList.Count; i++)
                {   
                    string ShipmentStatus = Gettext(attributeName_xpath, ".//*[@id='ShipmentGrid']/tbody/tr[" + (i+1) + "]/td[5]/div/span");
                    if (ShipmentStatus == " Pending" || ShipmentStatus == " Pre-Plan" || ShipmentStatus == " Rated" || ShipmentStatus == " Unscheduled" || ShipmentStatus == " Tender Rejected" || ShipmentStatus == " Scheduled")
                    {
                        VerifyElementPresent(attributeName_xpath, ".//*[@id='ShipmentGrid']/tbody/tr[" + (i + 1) + "]/td[10]/button", "Edit button");
                    }
                    else
                    {
                        VerifyElementNotPresent(attributeName_xpath, ".//*[@id='ShipmentGrid']/tbody/tr[" + (i + 1) + "]/td[10]/button", "Edit button");
                    }
                }
            }
        }
    }
}
