using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.Shipment_Service_Tiles_Screen
{
    [Binding]
    public class Service_TILE_page___Customer_Users_Steps : AddShipments
    {
        [Then(@"I Can see the services associated to the customer(.*)")]
        public void ThenICanSeeTheServicesAssociatedToTheCustomer(string TMS_Type)
        {
            Thread.Sleep(3000);
            Report.WriteLine("LTL Service option");
            if (TMS_Type == "MG")
            {
               
                VerifyElementPresent(attributeName_id, ShipmentServiceTypeLTL_id, "LTL");
                VerifyElementPresent(attributeName_id, ShipmentServiceTypeTL_id, "Truckload");
                VerifyElementPresent(attributeName_id, ShipmentServiceTypePTL_id, "Partial Truckload");
                VerifyElementPresent(attributeName_id, ShipmentServiceTypeIntermodal_id,"Intermodal");
            }
            if (TMS_Type == "CSA")
            {
                VerifyElementPresent(attributeName_id, ShipmentServiceTypeDom_id, "Domestic");
                VerifyElementPresent(attributeName_id, ShipmentServiceTypeIntn_id, "International");
            }
            if (TMS_Type == "BOTH")
            {
                VerifyElementPresent(attributeName_id, ShipmentServiceTypeLTL_id, "LTL");
                VerifyElementPresent(attributeName_id, ShipmentServiceTypeTL_id, "Truckload");
                VerifyElementPresent(attributeName_id, ShipmentServiceTypePTL_id, "Partial Truckload");
                VerifyElementPresent(attributeName_id, ShipmentServiceTypeIntermodal_id, "Intermodal");
                VerifyElementPresent(attributeName_id, ShipmentServiceTypeDom_id, "Domestic");
                VerifyElementPresent(attributeName_id, ShipmentServiceTypeIntn_id, "International");
            }
            

        }

    }
}
