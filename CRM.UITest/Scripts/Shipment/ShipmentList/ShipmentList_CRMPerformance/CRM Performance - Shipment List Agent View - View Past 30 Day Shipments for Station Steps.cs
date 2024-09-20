using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace CRM.UITest.Scripts.Shipment.ShipmentList.ShipmentList_CRMPerformance
{
    [Binding]
    public class CRM_Performance___Shipment_List_Agent_View___View_Past_30_Day_Shipments_for_Station_Steps : Shipmentlist
    {

        [When(@"I choose the station ""(.*)"" from the shipment list account drop down")]
        public void WhenIChooseTheStationFromTheShipmentListAccountDropDown(string customerName)
        {
            Report.WriteLine("Selecting " + customerName + " from the account drop down");
            Click(attributeName_id, ShipmentList_Selected_Customer_DropDown_Id);
            SelectDropdownValueFromList(attributeName_id, ShipmentList_Selected_Customer_DropDown_Id, customerName);
        }


        [Then(@"the grid will display results within (.*) seconds or less after receiving data from source system")]
        public void ThenTheGridWillDisplayResultsWithinSecondsOrLessAfterReceivingDataFromSourceSystem(int maxTime)
        {
            Report.WriteLine("Verifying loading time for shipment list is under  " + maxTime + "  seconds");
            var watch = System.Diagnostics.Stopwatch.StartNew();
            watch.Start();
            WaitForElementNotVisible(attributeName_xpath, LoadingIcon_Xpath, "Loading Icon");
            watch.Stop();
        
            TimeSpan ts = watch.Elapsed;

            int elapsedTime = ts.Seconds;

            if (elapsedTime > (maxTime))
            {
                 Report.WriteFailure("Grid loaded in " + elapsedTime + " seconds, which is too long.");
               

            }

            Report.WriteLine("Grid loaded successfully in" + elapsedTime + " seconds, which is under the max amount of time.");

        }


    }
}
