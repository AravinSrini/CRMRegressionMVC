using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Information_Screen
{
    [Binding]
    public class AddShipmentLTL_CustSpecificRef_ExpandRefSectionSteps : AddShipments
    {
        AddShipmentLTL ltl = new AddShipmentLTL();
        CommonMethodsCrm crm = new CommonMethodsCrm();

        [Given(@"I am a shp\.entry,shp\.entrynorates, operations, sales, sales management or station user- '(.*)','(.*)'")]
        public void GivenIAmAShp_EntryShp_EntrynoratesOperationsSalesSalesManagementOrStationUser_(string Username, string Password)
        {
            crm.LoginToCRMApplication(Username, Password);
        }

        [When(@"I arrive on the Add Shipment \(LTL\) page - (.*) , (.*)")]
        public void WhenIArriveOnTheAddShipmentLTLPage_(string Usertype, string CustomerName)
        {
            ltl.NaviagteToShipmentList();
            ltl.SelectCustomerFromShipmentList(Usertype, CustomerName);
        }


        [Then(@"The Reference Numbers section will be expanded\.")]
        public void ThenTheReferenceNumbersSectionWillBeExpanded_()
        {
            Report.WriteLine("Expansion of Reference number section");
            scrollElementIntoView(attributeName_xpath, ReferenceNum_section_Xpath);
            VerifyElementPresent(attributeName_xpath, ReferenceNum_section_Xpath, "Reference Section");
            VerifyElementPresent(attributeName_xpath, ReferenceNum_MoveTypeLabel_Xpath, "Move Type");
        }

        [Then(@"The Reference Numbers section will be collapsed\.")]
        public void ThenTheReferenceNumbersSectionWillBeCollapsed_()
        {
            Report.WriteLine("Collape of Reference Number Section");
            scrollElementIntoView(attributeName_xpath, ReferenceNum_section_Xpath);
            VerifyElementPresent(attributeName_xpath, ReferenceNum_section_Xpath, "Reference Section");
            VerifyElementNotVisible(attributeName_xpath, ReferenceNum_MoveTypeLabel_Xpath, "Move Type");

        }

    }
}
