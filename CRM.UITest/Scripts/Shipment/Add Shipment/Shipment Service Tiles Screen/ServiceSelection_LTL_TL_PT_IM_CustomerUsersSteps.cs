using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;


namespace CRM.UITest.Scripts.Shipment.Add_Shipment.Shipment_Service_Tiles_Screen
{
    [Binding]
    public class ServiceSelection_LTL_TL_PT_IM_CustomerUsersSteps : AddShipments
    {
        [Then(@"I must be arrive on the add shipment for the selected service (.*)")]
    public void ThenIMustBeArriveOnTheAddShipmentForTheSelectedService(string service)
    {

       if(service == "LTL")
            {
                Report.WriteLine("Page navigated to the Add Shipment (LTL)");
                VerifyElementPresent(attributeName_xpath, Addshipment_pageheader_Xpath, "Add shipment(LTL)");
            }
       else if(service == "Truckload")
            {
                Report.WriteLine("Page navigated to the Locations and Date page");
                GlobalVariables.webDriver.WaitForPageLoad();
                VerifyElementPresent(attributeName_xpath, ShipmentLocationsandDates_xpath, "Locations and Dates Page");
                String Actualservice = Gettext(attributeName_xpath, Shipment_International_Locations_And_Dates_Page_ServiceType_Xpath);
                GlobalVariables.webDriver.WaitForPageLoad();
                Assert.AreEqual(Actualservice, "Service: Truckload");
            }
       else if(service == "Partial Truckload")
            {
                Report.WriteLine("Page navigated to the Locations and Date page");
                GlobalVariables.webDriver.WaitForPageLoad();
                VerifyElementPresent(attributeName_xpath, ShipmentLocationsandDates_xpath, "Locations and Dates Page");
                String Actualservice = Gettext(attributeName_xpath, Shipment_International_Locations_And_Dates_Page_ServiceType_Xpath);
                GlobalVariables.webDriver.WaitForPageLoad();
                Assert.AreEqual(Actualservice, "Service: Partial Truckload");
            }
     
       else if(service == "Intermodal")
            {
                Report.WriteLine("Page naviagtes to the Location and Dates page");
                GlobalVariables.webDriver.WaitForPageLoad();
                VerifyElementPresent(attributeName_xpath, ShipmentLocationsandDates_xpath,"Locations and Dates Page");
                String Actualservice = Gettext(attributeName_xpath, Shipment_International_Locations_And_Dates_Page_ServiceType_Xpath);
                GlobalVariables.webDriver.WaitForPageLoad();
                Assert.AreEqual(Actualservice, "Service: Intermodal");
            }
    }

}
}
