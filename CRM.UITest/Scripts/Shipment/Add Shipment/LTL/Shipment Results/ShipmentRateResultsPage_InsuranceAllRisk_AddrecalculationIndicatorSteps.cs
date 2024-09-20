using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Results
{
    [Binding]
    public class ShipmentRateResultsPage_InsuranceAllRisk_AddrecalculationIndicatorSteps : Shipmentlist
    {
        IList<IWebElement> stationValue;
        [Given(@"I am on the shipment Results \(LTL\) page")]
        public void GivenIAmOnTheShipmentResultsLTLPage()
        {
            ClickAndWaitMethods clickndwait = new ClickAndWaitMethods();
            clickndwait.ClickAndWait(attributeName_xpath, ShipmentModule_Xpath);
            Report.WriteLine("Selecting a Customer from dropdown list");
            clickndwait.ClickAndWait(attributeName_xpath, CustomerDropdownExtuser_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, CustomerDropdownValesExtuser_Xpath, "ZZZ - Czar Customer Test");
            Report.WriteLine("Clicking on Add Shipment button");
            clickndwait.ClickAndWait(attributeName_id, ShipmentList_AddShipmentButton_Id);
            clickndwait.ClickAndWait(attributeName_id, ShipmentList_LTLtile_Id);
            clickndwait.ClickAndWait(attributeName_xpath, ViewRateButton_Xpath);           
        }
    }
}
