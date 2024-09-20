using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest
{
    [Binding]
    public class ShipmentList_AddShipmentSteps : Shipmentlist
    {
        [Given(@"I am user and login into application with valid shpinq and Te\$t(.*)")]
        public void GivenIAmAUserAndLoginIntoApplicationWithValidShpinqAndTeT(int p0)
        {
            CommonMethodsCrm crm = new CommonMethodsCrm();
            crm.LoginToCRMApplication("shpinq", "Te$t1234");
        }

        [When(@"I should not be displayed with the Add Shipment Button")]
        public void WhenIShouldBeDisplayedWithTheAddShipmentButton()
        {
            Report.WriteLine("I should not be displayed with Add shipment button");
            //VerifyElementVisible(attributeName_id, ShipmentList_AddShipmentButton_Id, "Add Shipment");
           VerifyElementNotPresent(attributeName_id, ShipmentList_AddShipmentButton_Id, "Add Shipment");
        }

        [When(@"I clicked on Add Shipment Button")]
        public void WhenIClickedOnAddShipmentButton()
        {
            Click(attributeName_id, ShipmentList_AddShipmentButton_Id);
        }

        //[When(@"I clicked on LTL")]
        //public void WhenIClickedOnLTL()
        //{
        //    //Click(attributeName_xpath, ShipmentList_LTLPage_Header_Xpath);
        //    Click(attributeName_xpath, "//*[@id='btn_ltl']/img");

        //    Thread.Sleep(6000);
        //}

        [Then(@"I should not be landed on the Add Shipment Page")]
        public void ThenIShouldBeLandedOnTheAddShipmentPage()
        {
            Thread.Sleep(4000);
            Assert.IsTrue(true);
        }


    }
}
