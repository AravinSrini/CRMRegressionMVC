using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.UAT_Regression.Domestic_Forwarding.Shipment
{
    [Binding]
    public class DomesticForwarding_AddShipment_VerifyDefaultAddressSteps : Mvc4Objects
    {
        CommonMethodsCrm crm = new CommonMethodsCrm();
        AddShipmentLTL ltl = new AddShipmentLTL();

        [Given(@"I am shp\.entry user or shp\.entryNorates - (.*), (.*)")]
        public void GivenIAmShp_EntryUserOrShp_EntryNorates_(string Username, string Password)
        {
            crm.LoginToCRMApplication(Username, Password);
        }

        [When(@"I am on the Add Shipment page for Domestic Forwarding and the customer has default origin address")]
        public void WhenIAmOnTheAddShipmentPageForDomesticForwardingAndTheCustomerHasDefaultOriginAddress()
        {
            ltl.NaviagteToShipmentList();
            Click(attributeName_id, AddShipmentButton_Id);
           
            Click(attributeName_id, DF_ShipTile_Id);
           
            Click(attributeName_xpath, DF_ShipTypeSelect_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, DF_ShipTypeSelectValue_Xpath, "Same Day");
            Click(attributeName_id, DF_ShipTypeContinue_Id);
            Verifytext(attributeName_xpath, DF_ShipPageTitle_Xpath, "Add Shipment");
        }

        [When(@"I am on the Add Shipment page for Domestic Forwarding and the customer has default destination address")]
        public void WhenIAmOnTheAddShipmentPageForDomesticForwardingAndTheCustomerHasDefaultDestinationAddress()
        {
            ltl.NaviagteToShipmentList();
            Click(attributeName_id, AddShipmentButton_Id);
            Thread.Sleep(2000);
            Click(attributeName_id, DF_ShipTile_Id);
            Thread.Sleep(2000);
            Click(attributeName_xpath, DF_ShipTypeSelect_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, DF_ShipTypeSelectValue_Xpath, "Same Day");
            Click(attributeName_id, DF_ShipTypeContinue_Id);
            Verifytext(attributeName_xpath, DF_ShipPageTitle_Xpath, "Add Shipment");
        }

        [Then(@"The default address must be populated in the origin information section and it should match with the default address in DB - '(.*)'")]
        public void ThenTheDefaultAddressMustBePopulatedInTheOriginInformationSectionAndItShouldMatchWithTheDefaultAddressInDB_(string CustomerName)
        {
            Report.WriteLine("Comparing Populated Default Origin Address with DB");
            int setupid = DBHelper.GetAccountIdforAccountName(CustomerName);
            int accountnumber = DBHelper.GetAccountNumber(setupid);
            Address values = DBHelper.Get_DefaultShipperAddressExternalUsers(accountnumber);
            string OriginLocationName = GetValue(attributeName_id, DF_ShipOriginName_Id, "value");
            Assert.AreEqual(values.Name, OriginLocationName);
            string OriginAddress = GetValue(attributeName_id, DF_ShipOriginAddress_Id, "value");
            Assert.AreEqual(values.Address1, OriginAddress);
            string OriginAddress2 = GetValue(attributeName_id, DF_ShipOriginAddress1_Id, "value");
            Assert.AreEqual(values.Address2, OriginAddress2);
            string OriginCountry = Gettext(attributeName_xpath, DF_ShipOriginCountry_Xpath);
            if (OriginCountry.Contains("United States"))
            {
                string OriginCountryRemove = OriginCountry.Remove(13);
                Assert.AreEqual(values.Country, OriginCountryRemove);
                string OriginZip = GetValue(attributeName_id, DF_ShipOriginZip_Id, "value");
                Assert.AreEqual(values.Zip, OriginZip);
                string OriginState = Gettext(attributeName_xpath, DF_ShipOriginState_Xpath);
                string OriginStateRemove = OriginState.Remove(2);
                Assert.AreEqual(values.State, OriginStateRemove);
            }
            else
            {
                string OriginCountryRemove = OriginCountry.Remove(6);
                Assert.AreEqual(values.Country, OriginCountryRemove);
                string OriginPostal = GetValue(attributeName_id, DF_ShipOriginPostal_Id, "value");
                Assert.AreEqual(values.Zip, OriginPostal);
                string OriginProvince = Gettext(attributeName_xpath, DF_ShipOriginProvince_Xpath);
                string OriginProvinceRemove = OriginProvince.Remove(2);
                Assert.AreEqual(values.State, OriginProvinceRemove);
            }         
            string OriginCity = GetValue(attributeName_id, DF_ShipOriginCity_Id, "value");
            Assert.AreEqual(values.City, OriginCity);
        }


        [Then(@"The default address must be populated in the destination information section and it should match with the default address in DB - (.*)")]
        public void ThenTheDefaultAddressMustBePopulatedInTheDestinationInformationSectionAndItShouldMatchWithTheDefaultAddressInDB_(string CustomerName)
        {
            Report.WriteLine("Comparing Populated Default Destination Address with DB");
            int setupid = DBHelper.GetAccountIdforAccountName(CustomerName);
            int accountnumber = DBHelper.GetAccountNumber(setupid);
            Address values = DBHelper.Get_DefaultConsigneeExternalUsers(accountnumber);
            string DesLocationName = GetValue(attributeName_id, DF_ShipDesName_Id, "value");
            Assert.AreEqual(values.Name, DesLocationName);
            string DesAddress = GetValue(attributeName_id, DF_ShipDesAddress_Id, "value");
            Assert.AreEqual(values.Address1, DesAddress);
            string DesAddress2 = GetValue(attributeName_id, DF_ShipDesAddress1_Id, "value");
            Assert.AreEqual(values.Address2, DesAddress2);
            string DesCountry = Gettext(attributeName_xpath, DF_ShipDesCountry_Xpath);
            if (DesCountry.Contains("United States"))
            {
                string DesCountryRemove = DesCountry.Remove(13);
                Assert.AreEqual(values.Country, DesCountryRemove);
                string DesZip = GetValue(attributeName_id, DF_ShipDesZip_Id, "value");
                Assert.AreEqual(values.Zip, DesZip);
                string DesState = Gettext(attributeName_xpath, DF_ShipDesState_Xpath);
                string DesStateRemove = DesState.Remove(2);
                Assert.AreEqual(values.State, DesStateRemove);
            }
            else
            {
                string DesCountryRemove = DesCountry.Remove(6);
                Assert.AreEqual(values.Country, DesCountryRemove);
                string DesPostal = GetValue(attributeName_id, DF_ShipDesPostal_Id, "value");
                Assert.AreEqual(values.Zip, DesPostal);
                string DesProvince = Gettext(attributeName_xpath, DF_ShipDesProvince_Xpath);
                string DesProvinceRemove = DesProvince.Remove(2);
                Assert.AreEqual(values.State, DesProvinceRemove);
            }          
            string DesCity = GetValue(attributeName_id, DF_ShipDesCity_Id, "value");
            Assert.AreEqual(values.City, DesCity);
        }
    }
}
