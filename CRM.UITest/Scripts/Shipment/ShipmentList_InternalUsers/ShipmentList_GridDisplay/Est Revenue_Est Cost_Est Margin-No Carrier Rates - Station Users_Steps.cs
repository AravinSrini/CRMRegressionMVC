using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.ShipmentList_InternalUsers.ShipmentList_GridDisplay
{
    [Binding]
    public class Est_Revenue_Est_Cost_Est_Margin_No_Carrier_Rates___Station_Users_Steps : Shipmentlist
    {
        CommonMethodsCrm crm = new CommonMethodsCrm();

        [Given(@"I am a sales, sales management, operations, or station owner user (.*) (.*)")]
        public void GivenIAmASalesSalesManagementOperationsOrStationOwnerUser(string Username, string Password)
        {
            crm.LoginToCRMApplication(Username, Password);
        }



        [Then(@"the Est Revenue,Est Cost and Est Margin fields should be displayed as N/A")]
        public void ThenTheEstRevenueEstCostAndEstMarginFieldsShouldBeDisplayedAsNA()
        {
            
            Verifytext(attributeName_xpath, Shipmentlist_FirstRow_Est_Revenue_Label_Xpath, "Est Revenue:");
            Verifytext(attributeName_xpath, Shipmentlist_FirstRow_Est_Revenue_Value_Xpath, "N/A");

            // string st = Gettext(attributeName_xpath, Shipmentlist_FirstRow_Est_Revenue_Value_Xpath);

            Verifytext(attributeName_xpath, Shipmentlist_FirstRow_Est_Cost_Label_Xpath, "Est Cost:");
            Verifytext(attributeName_xpath, Shipmentlist_FirstRow_Est_Cost_Value_Xpath, "N/A");

            Verifytext(attributeName_xpath, Shipmentlist_FirstRow_Est_Margin_Label_Xpath, "Est Margin %:");
            Verifytext(attributeName_xpath, Shipmentlist_FirstRow_Est_Margin_Value_Xpath, "N/A");
        }

    }
}
