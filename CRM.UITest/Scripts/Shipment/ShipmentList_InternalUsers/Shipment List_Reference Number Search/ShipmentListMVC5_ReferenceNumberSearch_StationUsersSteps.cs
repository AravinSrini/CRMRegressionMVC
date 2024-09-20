using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.ShipmentList_InternalUsers.Shipment_List_Reference_Number_Search
{
    [Binding]
    public class ShipmentListMVC5_ReferenceNumberSearch_StationUsersSteps: AddShipments
    {
        CommonMethodsCrm crm = new CommonMethodsCrm();        

        [Given(@"I am an operations, sales, sales management, or station owner user (.*), (.*)")]
        public void GivenIAmAnOperationsSalesSalesManagementOrStationOwnerUser(string Username, string Password)
        {
            crm.LoginToCRMApplication(Username, Password);
        }
        
        [Given(@"I am on the Shipment List page")]
        public void GivenIAmOnTheShipmentListPage()
        {
            Report.WriteLine("Navigate to MVC5 Shipment list");
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, ShipmentModule_Xpath, "Shipment Icon");
            Click(attributeName_xpath, ShipmentModule_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, ShipmentList_Title_Xpath, "Shipment List");            
        }
        
        [Given(@"All Customers is selected")]
        public void GivenAllCustomersIsSelected()
        {
            Report.WriteLine("All customer is selected by default");
            VerifyElementVisible(attributeName_xpath, ShipmentList_CustomerSelection_Xpath, "all customers");
        }
        
        [Given(@"I enter the '(.*)' in Reference Number lookup field")]
        public void GivenIEnterTheInReferenceNumberLookupField(string Ref)
        {
            Report.WriteLine("Enter Reference Numbers");
            SendKeys(attributeName_xpath, ShipmentList_ReferenceNumLookup_Xpath, Ref);
        }
        
        [Then(@"I should be displayed with the results for the entered valid reference numbers '(.*)'")]
        public void ThenIShouldBeDisplayedWithTheResultsForTheEnteredValidReferenceNumbers(string Ref)
        {
            Report.WriteLine("I should see the results in grid for the entered valid reference numbers");
            Thread.Sleep(40000);
            //VerifyElementNotVisible(attributeName_xpath, ShipmentListGrid_loadingIcon_Xpath, "loading icon");
            List<string> ShipmentListRefNumber_UI = IndividualColumnData(ShipmentList_Referencenumbersgrid_Xpath);
            string[] valuesexp = Ref.Split(',');
            for (int i = 0; i < ShipmentListRefNumber_UI.Count; i++)
            {
                if (valuesexp.Contains(ShipmentListRefNumber_UI[i]))
                {
                    Report.WriteLine("Entered Reference number and Reference value appearing in the shipment list grid are same");
                }
                else
                {
                    Report.WriteLine("Entered Reference number and Reference value appearing in the shipment list grid are not same");
                }
            }

            Report.WriteLine("Verifying the PO numbers");
            List<string> ShipmentListPONumber_UI = IndividualColumnData(".//*[@id='ShipmentGrid']/tbody/tr/td[1]/span");
            for (int i = 0; i < ShipmentListPONumber_UI.Count; i++)
            {
                string[] ActualPONumbers = ShipmentListPONumber_UI[i].Split(':');
                if (valuesexp.Contains(ActualPONumbers[1].Trim()))
                {
                    Report.WriteLine("Entered PO number and PO number appearing in the Results are same");
                }
                else
                {
                    Report.WriteLine("Entered PO number and PO number appearing in the Results are not same");
                }
            }

            Report.WriteLine("Verifying the PRO numbers");
            List<string> ShipmentListPRONumber_UI = IndividualColumnData(".//*[@id='ShipmentGrid']/tbody/tr/td[4]/div[2]/a/span");
            for (int i = 0; i < ShipmentListPRONumber_UI.Count; i++)
            {
                if (valuesexp.Contains(ShipmentListPRONumber_UI[i]))
                {
                    Report.WriteLine("Entered PRO number and PRO number appearing in the Results are same");
                }
                else
                {
                    Report.WriteLine("Entered PRO number and PRO number appearing in the Results are not same");
                }
            }            

        }
    }
}
