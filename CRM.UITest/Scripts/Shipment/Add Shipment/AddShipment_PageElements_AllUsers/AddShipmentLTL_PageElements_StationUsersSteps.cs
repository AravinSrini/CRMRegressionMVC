using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using CRM.UITest.Objects;
using TechTalk.SpecFlow;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using CRM.UITest.CommonMethods;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.AddShipment_PageElements_AllUsers
{
    [Binding]
    public class AddShipmentLTL_PageElements_StationUsersSteps : AddShipments
    {
        AddShipmentLTL ltl = new AddShipmentLTL();

        [When(@"I click on the Shipment Module")]
        public void WhenIClickOnTheShipmentModule()
        {
             ltl.NaviagteToShipmentList();
        }


        [Given(@"I select a Customer of TMS type MG or Both from the customer selection dropdown list -(.*)")]
        public void GivenISelectACustomerOfTMSTypeMGOrBothFromTheCustomerSelectionDropdownList_(string Customer)
        {
            Report.WriteLine("Customer Selection dropdown");
            Click(attributeName_xpath, AllCustomerDropdown_Selection_Internal_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, AllCustomerDroppdownValues_Internal_Xpath, Customer);

        }
        [Given(@"I click on Add Shipment button for Internal Users")]
        public void GivenIClickOnAddShipmentButtonForInternalUsers()
        {
            Report.WriteLine("Click on Add Shipment button Internal users");
            Click(attributeName_id, AddShipmentButtionInternal_Id);
            
        }

      
        [Then(@"I must be able to view Station name - customer name on Add Shipment\(LTL\) page - (.*)")]
        public void ThenIMustBeAbleToViewStationName_CustomerNameOnAddShipmentLTLPage_(string Customer)
        {
            Report.WriteLine("View Staion name - Customer name");
            string UIName = Gettext(attributeName_xpath, Station_CustomerName_Xpath);
            
            if (UIName.Contains(Customer.ToUpper()))
            {
                Report.WriteLine("Customer name is visible");
            }
            else
            {
                Report.WriteFailure("Customer name does not exists");
            }

        }
    }
}
