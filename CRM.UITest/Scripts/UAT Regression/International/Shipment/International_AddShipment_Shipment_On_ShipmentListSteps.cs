using CRM.UITest.CommonMethods;
using CRM.UITest.CommonMethods.Mvc4Regressions;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.UAT_Regression.International.Shipment
{
    [Binding]
    public class International_AddShipment_Shipment_On_ShipmentListSteps : Mvc4Objects
    {
        InternationalShipment _internationalCommonMethods = new InternationalShipment();
        CommonMethodsCrm _crm = new CommonMethodsCrm();

        string Expected_HousebillNumber;

        [Given(@"I am a shp\.entry No Rates user - (.*) and (.*)")]
        public void GivenIAmAShp_EntryNoRatesUser_And(string userName, string password)
        {
            _crm.LoginToCRMApplication(userName, password);
        }
        
        [Given(@"I selected International service for shipment creation(.*),(.*)")]
        public void GivenISelectedInternationalServiceForShipmentCreation(string Type, string level)
        {
            _internationalCommonMethods.Select_InternationalService_Type_level(Type, level);
        }
        
        [Given(@"I created the International Shipment(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void GivenICreatedTheInternationalShipment(string OName, string OAddress, string OCountry, string OCity, string OState, string OZip, string DName, string DAddress, string DCountry, string DCity, string DState, string DZip, string Pieces, string Weight, string Length, string Width, string Height, string Description, string CommercialInvoiceValue)
        {
            _internationalCommonMethods.Entering_Datas_in_International_ShipmentLocationAndDates_Page(OName, OAddress, OCountry, OCity, OState, OZip, DName, DAddress, DCountry, DCity, DState, DZip);
            _internationalCommonMethods.Entering_Datas_in_Iternational_ItemInformation_Page(Pieces, Weight, Length, Width, Height, Description, CommercialInvoiceValue);

            //--------------------Unable to Submit International Shipment---------------------------------
            //Once Bug fixed will Execute
           
            Expected_HousebillNumber = Gettext(attributeName_id, Int_Shipment_HousebillNumber_Id);
        }
        
        [When(@"I am on the Shipment list page")]
        public void WhenIAmOnTheShipmentListPage()
        {
            Report.WriteLine("Navigate to MVC5 Shipment list");
            try
            {
                Click(attributeName_xpath, ShipmentModule_Xpath);

            }
            catch (Exception)
            {
                Thread.Sleep(20000);
                Console.WriteLine("error occurred");
            }
            WaitForElementVisible(attributeName_xpath, ShipmentList_Header_Text_Xpath, "Shipment List");
        }
        
        [Then(@"I will be able to see this created new Shipment")]
        public void ThenIWillBeAbleToSeeThisCreatedNewShipment()
        {
            SendKeys(attributeName_id, ShipmentList_Searchbox_Id, Expected_HousebillNumber);
            Thread.Sleep(4000);
            string Actual_HousebillNumber = Gettext(attributeName_id, ShipmentList_SearchedRefereceNumber_Id);
            Assert.AreEqual(Expected_HousebillNumber, Actual_HousebillNumber);

        }
    }
}
