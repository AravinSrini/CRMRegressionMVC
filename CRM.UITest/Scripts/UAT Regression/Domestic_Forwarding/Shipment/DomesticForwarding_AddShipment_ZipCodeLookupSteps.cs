using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Threading;
using TechTalk.SpecFlow;
namespace CRM.UITest.Scripts.UAT_Regression.Domestic_Forwarding.Shipment
{
    [Binding]
    public class DomesticForwarding_AddShipment_ZipcodeLookupSteps : Mvc4Objects
    {
        [Then(@"origine city,state and country autopopulated for valid zipcode (.*),(.*),(.*),(.*)")]
        public void ThenOrigineCityStateAndCountryAutopopulatedForValidZipcode(string ocity, string ostate, string ocountry, string ozip)
        {
            Report.WriteLine("enter valid origin zip");
            Thread.Sleep(6000);
            WaitForElementVisible(attributeName_xpath, DF_ShipmentLocation_and_Dates_Header_Xpath, "Shipments Locations and Dates");
            Click(attributeName_id, ShipDF_OrgClearAddressButton_ID);
            Thread.Sleep(1500);
            SendKeys(attributeName_id, DF_ShipOriginZip_Id, ozip);
            Click(attributeName_xpath, DF_ClickOut_xpath);
            Thread.Sleep(2000);

            Report.WriteLine("Origin State And CityFields are autopopulated");
            string expectedstate = Gettext(attributeName_xpath, ".//*[@id='origin']/div[2]/div[1]/div[1]/span[2]/span/span[1]");
            Assert.AreEqual(expectedstate, ostate);
            Thread.Sleep(800);
            string expectedcity = GetValue(attributeName_id, DF_ShipOriginCity_Id, "value");
            Assert.AreEqual(expectedcity, ocity);
            Thread.Sleep(800);
            string expectedcountry = Gettext(attributeName_xpath, ".//*[@id='dvOriginCountry']/span[2]/span/span[1]");
            Assert.AreEqual(expectedcountry, ocountry);
            Thread.Sleep(800);

        }

        [Then(@"destination country, state and city fields must be populated for valid zipcode (.*), (.*), (.*), (.*)")]
        public void ThenDestinationCountryStateAndCityFieldsMustBePopulatedForValidZipcode(string dcity, string dstate, string dcountry, string dzip)
        {
            Report.WriteLine("enter valid destination zip");
            Click(attributeName_id, ShipDF_DestClearAddressButton_ID);
            Thread.Sleep(1500);
            SendKeys(attributeName_id, DF_ShipDesZip_Id, dzip);
            Click(attributeName_xpath, ".//*[@id='destination']/div[2]/div[2]/div/span");
          
            Thread.Sleep(2000);
            Report.WriteLine("Origin State And CityFields are autopopulated");
            string expectedstate = Gettext(attributeName_xpath, ".//*[@id='destination']/div[2]/div[1]/div[1]/span[2]/span/span[1]");
            Assert.AreEqual(expectedstate, dstate);
            Thread.Sleep(800);
            string expectedcity = GetValue(attributeName_id, DF_ShipDesCity_Id, "value");
            Assert.AreEqual(expectedcity, dcity);
            Thread.Sleep(800);
            string expectedcountry = Gettext(attributeName_xpath, ".//*[@id='dvDestCountry']/span[2]/span/span[1]");
            Assert.AreEqual(expectedcountry, dcountry);
        }
    }
}
