using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.AddShipment_PageElements_AllUsers
{
    [Binding]
    public class ShippingHours_Add_Shipment_LTL_Steps: AddShipments    
    {
        string customerName;
        string readyTime;
        string closeTime;
        string openTimeofCustomer;
        string closeTimeofCustomer;
        int addressId;
        string openTimeofSavedAddress;
        string closeTimeofSavedAddress;
        string openTimeofDefaultAddress;
        string closeTimeofDefaultAddress;

        List<TimeSpan> shippingHoursFromDB = null;

        [Given(@"I am a DLS user with access to Shipments")]
        public void GivenIAmADLSUserWithAccessToShipments()
        {
            string username = ConfigurationManager.AppSettings["username-ShipEntry"].ToString();
            string password = ConfigurationManager.AppSettings["password-ShipEntry"].ToString();

            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"I am a DLS user with access to Shipments module")]
        public void GivenIAmADLSUserWithAccessToShipmentsModule()
        {
            string username = ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();
            string password = ConfigurationManager.AppSettings["ExternalUserPassword"].ToString();

            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }
       
        [Given(@"I Am on the Add Shipment LTL page")]
        public void GivenIAmOnTheAddShipmentLTLPage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Clicked on Shipments icon");
            Click(attributeName_id, ShipmentIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();

            Report.WriteLine("Clicked on Add Shipment button");
            WaitForElementVisible(attributeName_id, AddShipment_Button_id, "Add shipment button");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, AddShipment_Button_id);
            GlobalVariables.webDriver.WaitForPageLoad();

            Report.WriteLine("Clicked on LTL tile");
            Click(attributeName_id, AddShipmentLTL_Button_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I Am on the Shipment List page")]
        public void GivenIAmOnTheShipmentListPage()
        {
            Report.WriteLine("Clicked on Shipments icon");
            Click(attributeName_cssselector, ShipmentsIcon_css);
            GlobalVariables.webDriver.WaitForPageLoad();            
        }

        [Given(@"I click on Return Shipment button for any shipment")]
        public void GivenIClickOnReturnShipmentButtonForAnyShipment()
        {
            Report.WriteLine("Clicked on Return Shipments icon");
            Click(attributeName_xpath, ShipmentListGrid_RetrunShipmentIcon_First_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Clicked on Yes on Create Return Shipment pop up");
            Thread.Sleep(3000);
            Click(attributeName_xpath, ShipmentList_ReturnShipment_Yes_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [When(@"I Am on the Add Shipment LTL page")]
        public void WhenIAmOnTheAddShipmentLTLPage()
        {
            Report.WriteLine("Clicked on Shipments icon");
            Click(attributeName_cssselector, ShipmentsIcon_css);
            GlobalVariables.webDriver.WaitForPageLoad();

            Report.WriteLine("Clicked on Add Shipment button");
            Click(attributeName_id, AddShipment_Button_id);
            GlobalVariables.webDriver.WaitForPageLoad();

            Report.WriteLine("Clicked on LTL tile");
            Click(attributeName_id, AddShipmentLTL_Button_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [When(@"I Select a Saved Address in the Shipping From section (.*)")]
        public void WhenISelectASavedAddressinTheShippingFromSection(string savedAddress)
        {
            Report.WriteLine("Clicked on Select or search for a Saved Origin dropdown field");
            Click(attributeName_id, ShippingFrom_SelectSavedOriginDropDown_Id);

            string _selectedAddress = GetValue(attributeName_id, ShippingFrom_SelectSavedOriginDropDown_Id, "value");

            if (_selectedAddress != "" || _selectedAddress != string.Empty)
            {
                Click(attributeName_id, ClearAddress_OriginId);
            }
            
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ShippingFrom_SelectSavedOriginDropDown_Id);            
            SendKeys(attributeName_id, ShippingFrom_SelectSavedOriginDropDown_Id, savedAddress);
            Thread.Sleep(3000);
            Click(attributeName_xpath, ".//*[@class='tt-dataset-autos'][1]//p");                        
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Selected a Saved Address from list of saved addresses");            
        }

        [When(@"the Shipping From address is a Default Shipper address")]
        public void WhenTheShippingFromAddressIsADefaultShipperAddress()
        {
            int customerAccountID = 5;
            Address shippingFromAddressDB = DBHelper.Get_DefaultShipperAddressExternalUsers(customerAccountID);
            string shippingFromAddressStringDB = shippingFromAddressDB.Name + shippingFromAddressDB.Address1 + shippingFromAddressDB.Address2 + shippingFromAddressDB.City + shippingFromAddressDB.State + shippingFromAddressDB.Country + shippingFromAddressDB.Zip;
            shippingFromAddressStringDB = shippingFromAddressStringDB.Replace(" ", "");

            string shippingFromAddressUI = GetAttribute(attributeName_id, ShippingFrom_SelectSavedOriginDropDown_Id, "value");
            shippingFromAddressUI = shippingFromAddressUI.Replace(" ", "");

            Assert.AreEqual(shippingFromAddressUI, shippingFromAddressStringDB);
            Report.WriteLine("Address displayed under Shipping From section is the Default Address of the Customer");
        }

        [When(@"I am on the Add Shipment LTL page of the shipment to be returned")]
        public void WhenIAmOnTheAddShipmentLTLPageOfTheShipmentToBeReturned()
        {
            VerifyElementPresent(attributeName_xpath, AddShipment_PageTitle_xpath, "Add Shipment (LTL)");
            Report.WriteLine("Navigated to Add Shipment (LTL) page");
        }


        [Then(@"the Ready field of the Pickup Date section should be auto-populated with the Open Time of the Customer")]
        public void ThenTheReadyFieldOfThePickupDateSectionShouldBeAuto_PopulatedWithTheOpenTimeOfTheCustomer()
        {            
            readyTime = Gettext(attributeName_xpath, LTL_PickUpReadyTime_SelectedValue_Xpath);
            string[] actReadyTime = readyTime.Split(' ');
            readyTime = actReadyTime[1]+ " ";
            readyTime = readyTime + actReadyTime[2];
            Report.WriteLine("Ready time is: " + readyTime);
           
            customerName = "101 Telco Solutions";
            shippingHoursFromDB = DBHelper.GetShippingHoursForCustomer(customerName);            

            openTimeofCustomer = DateTime.Parse(shippingHoursFromDB[0].ToString()).ToString("hh:mm tt");
            Report.WriteLine("Shipping Open time from DB is: " + openTimeofCustomer);

            Assert.AreEqual(readyTime, openTimeofCustomer);
            Report.WriteLine("Ready time under Shipping From section is auto-populated with Open time of the Customer ");
        }

        [Then(@"the Close field of the Pickup Date section should be auto-populated with the Close Time of the Customer")]
        public void ThenTheCloseFieldOfThePickupDateSectionShouldBeAuto_PopulatedWithTheCloseTimeOfTheCustomer()
        {            
            closeTime = Gettext(attributeName_xpath, LTL_PickUpCloseTime_SelectedValue_Xpath);
            string[] actcloseTime = closeTime.Split(' ');
            closeTime = actcloseTime[1]+ " ";
            closeTime = closeTime + actcloseTime[2];
            Report.WriteLine("Close time is: " + closeTime);
            
            customerName = "101 Telco Solutions";
            shippingHoursFromDB = DBHelper.GetShippingHoursForCustomer(customerName);

            closeTimeofCustomer = DateTime.Parse(shippingHoursFromDB[1].ToString()).ToString("hh:mm tt");
            Report.WriteLine("Shipping Close time from DB is: " + closeTimeofCustomer);

            Assert.AreEqual(closeTime, closeTimeofCustomer);
            Report.WriteLine("Close time under Shipping From section is auto-populated with Close time of the Customer ");
        }

        [Then(@"the Ready field of the Pickup Date section should be auto-populated with the Open Time of the selected Saved address")]
        public void ThenTheReadyFieldOfThePickupDateSectionShouldBeAuto_PopulatedWithTheOpenTimeOfTheSelectedSavedAddress()
        {            
            readyTime = Gettext(attributeName_xpath, LTL_PickUpReadyTime_SelectedValue_Xpath);
            string[] actReadyTime = readyTime.Split(' ');
            readyTime = actReadyTime[1]+ " ";
            readyTime = readyTime + actReadyTime[2];
            Report.WriteLine("Ready time is: " + readyTime);

            customerName = "ZZZ - GS Customer Test";
            addressId = 332486;
            shippingHoursFromDB = DBHelper.GetShippingHoursForSavedAddress(addressId, customerName);

            openTimeofSavedAddress = DateTime.Parse(shippingHoursFromDB[0].ToString()).ToString("hh:mm tt");
            Report.WriteLine("Shipping Open time from DB is: " + openTimeofSavedAddress);

            Assert.AreEqual(readyTime, openTimeofSavedAddress);
            Report.WriteLine("Ready time under Shipping From section is auto-populated with Open time of the selected Saved Address");
        }

        [Then(@"the Close field of the Pickup Date section should be auto-populated with the Close Time of the selected Saved address")]
        public void ThenTheCloseFieldOfThePickupDateSectionShouldBeAuto_PopulatedWithTheCloseTimeOfTheSelectedSavedAddress()
        {
            closeTime = Gettext(attributeName_xpath, LTL_PickUpCloseTime_SelectedValue_Xpath);
            string[] actcloseTime = closeTime.Split(' ');
            closeTime = actcloseTime[1]+ " ";
            closeTime = closeTime + actcloseTime[2];
            Report.WriteLine("Close time is: " + closeTime);
            
            customerName = "ZZZ - GS Customer Test";

            shippingHoursFromDB = DBHelper.GetShippingHoursForSavedAddress(addressId, customerName);
            addressId = 332486;
            closeTimeofSavedAddress = DateTime.Parse(shippingHoursFromDB[1].ToString()).ToString("hh:mm tt");
            Report.WriteLine("Shipping Close time from DB is: " + closeTimeofSavedAddress);
           
            Assert.AreEqual(closeTime, closeTimeofSavedAddress);
            Report.WriteLine("Close time under Shipping From section is auto-populated with Close time of the selected Saved address");
        }

        [Then(@"the Ready field of the Pickup Date section should be auto-populated with the Open Time of the Default Shipper address")]
        public void ThenTheReadyFieldOfThePickupDateSectionShouldBeAuto_PopulatedWithTheOpenTimeOfTheDefaultShipperAddress()
        {
            readyTime = Gettext(attributeName_xpath, LTL_PickUpReadyTime_SelectedValue_Xpath);
            string[] actReadyTime = readyTime.Split(' ');
            readyTime = actReadyTime[1] + " ";
            readyTime = readyTime + actReadyTime[2];
            Report.WriteLine("Ready time is: " + readyTime);

            customerName = "ZZZ - Czar Customer Test";            
            shippingHoursFromDB = DBHelper.GetShippingHoursForDefaultShipperAddress(customerName);

            openTimeofDefaultAddress = DateTime.Parse(shippingHoursFromDB[0].ToString()).ToString("hh:mm tt");
            Report.WriteLine("Shipping Open time from DB is: " + openTimeofDefaultAddress);

            Assert.AreEqual(readyTime, openTimeofDefaultAddress);
            Report.WriteLine("Ready time under Shipping From section is auto-populated with Open time of the Default Shipper Address");
        }

        [Then(@"the Close field of the Pickup Date section should be auto-populated with the Close Time of the Default Shipper address")]
        public void ThenTheCloseFieldOfThePickupDateSectionShouldBeAuto_PopulatedWithTheCloseTimeOfTheDefaultShipperAddress()
        {
            closeTime = Gettext(attributeName_xpath, LTL_PickUpCloseTime_SelectedValue_Xpath);
            string[] actcloseTime = closeTime.Split(' ');
            closeTime = actcloseTime[1] + " ";
            closeTime = closeTime + actcloseTime[2];
            Report.WriteLine("Close time is: " + closeTime);
            
            customerName = "ZZZ - Czar Customer Test";            
            shippingHoursFromDB = DBHelper.GetShippingHoursForDefaultShipperAddress(customerName);

            closeTimeofDefaultAddress = DateTime.Parse(shippingHoursFromDB[1].ToString()).ToString("hh:mm tt");
            Report.WriteLine("Shipping Close time from DB is: " + closeTimeofDefaultAddress);

            Assert.AreEqual(closeTime, closeTimeofDefaultAddress);
            Report.WriteLine("Close time under Shipping From section is autopopulated with Close time of the Default Shipper address");
        }

        [Then(@"the Ready date field of the Pickup Date section should be auto-populated with the Open Time of the Customer")]
        public void ThenTheReadyDateFieldOfThePickupDateSectionShouldBeAuto_PopulatedWithTheOpenTimeOfTheCustomer()
        {
            readyTime = Gettext(attributeName_xpath, LTL_PickUpReadyTime_SelectedValue_Xpath);
            string[] actReadyTime = readyTime.Split(' ');
            readyTime = actReadyTime[1] + " ";
            readyTime = readyTime + actReadyTime[2];
            Report.WriteLine("Ready time is: " + readyTime);
           
            customerName = "ZZZ - Czar Customer Test";
            shippingHoursFromDB = DBHelper.GetShippingHoursForCustomer(customerName);
                    
            openTimeofCustomer = DateTime.Parse(shippingHoursFromDB[0].ToString()).ToString("hh:mm tt");
            Report.WriteLine("Shipping Open time from DB is: " + openTimeofCustomer);

            Assert.AreEqual(readyTime, openTimeofCustomer);
            Report.WriteLine("Ready time under Shipping From section is auto-populated with Open time of the Customer ");
        }

        [Then(@"the Close date field of the Pickup Date section should be auto-populated with the Close Time of the Customer")]
        public void ThenTheCloseDateFieldOfThePickupDateSectionShouldBeAuto_PopulatedWithTheCloseTimeOfTheCustomer()
        {
            closeTime = Gettext(attributeName_xpath, LTL_PickUpCloseTime_SelectedValue_Xpath);
            string[] actcloseTime = closeTime.Split(' ');
            closeTime = actcloseTime[1] + " ";
            closeTime = closeTime + actcloseTime[2];            
            Report.WriteLine("Close time is: " + closeTime);

            customerName = "ZZZ - Czar Customer Test";
            shippingHoursFromDB = DBHelper.GetShippingHoursForCustomer(customerName);            

            closeTimeofCustomer = DateTime.Parse(shippingHoursFromDB[1].ToString()).ToString("hh:mm tt");
            Report.WriteLine("Shipping Close time from DB is: " + closeTimeofCustomer);

            Assert.AreEqual(closeTime, closeTimeofCustomer);
            Report.WriteLine("Close time under Shipping From section is auto-populated with Close time of the Customer ");
        }
    }
}
