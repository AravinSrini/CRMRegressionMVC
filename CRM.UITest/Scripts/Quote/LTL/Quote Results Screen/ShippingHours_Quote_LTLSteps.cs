using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.Common;
using CRM.UITest.Helper.Implementations.ShipmentExtract;
using CRM.UITest.Helper.ViewModel;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Threading;

namespace CRM.UITest.Scripts.Quote.LTL.Quote_Results_Screen
{
    [Binding]
    public class ShippingHours_Quote_LTLSteps : ObjectRepository
    {
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
        string customerName = "ZZZ - GS Customer Test";
        AddQuoteLTL getQuoteLTL = new AddQuoteLTL();
        string originZip = "90001";
        string destinationZip = "85282";
        string guaranteedLink;
        ShipmentExtractViewModel shipmentViewModels = null;
        string referenceNumber = string.Empty;
        string savedAddress = "AMERICAN WATER"; //AMERICAN WATER 8835 General Drive  Woodridge IL  United States 60517
        int addressId = 34007;

        [Given(@"I am a shp\.inquiry, shp\.entry, sales, sales management, operations or station owner user")]
        public void GivenIAmAShp_InquiryShp_EntrySalesSalesManagementOperationsOrStationOwnerUser()
        {
            string userName = ConfigurationManager.AppSettings["InternalUserLogin"].ToString();
            string password = ConfigurationManager.AppSettings["InternalUserPassword"].ToString();
            CrmLogin.LoginToCRMApplication(userName, password);
            Report.WriteLine("I logged into CRM application with station user credentials");
        }

        [Given(@"I did not select a saved address in the Shipping From section")]
        public void GivenIDidNotSelectASavedAddressInTheShippingFromSection()
        {
            Report.WriteLine("I have entered the Shipping From section address manually");
            Click(attributeName_id, ClearAddress_OriginId);
            getQuoteLTL.EnterOriginZip(originZip);
            getQuoteLTL.EnterDestinationZip(destinationZip);
            Click(attributeName_id, LTL_ClearItem_Id);
            Thread.Sleep(3000);
            getQuoteLTL.EnterItemdata("50","600");
            SendKeys(attributeName_id, InsuredValue_id, "800");
            Thread.Sleep(3000);            
        }

        [Given(@"I am on the Quote Results\(LTL\) page")]
        public void GivenIAmOnTheQuoteResultsLTLPage()
        {
            Thread.Sleep(3000);
            getQuoteLTL.ClickViewRates();
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("I am on Quote Results Page");
        }

        [Given(@"I have selected saved address in the Shipping From section")]
        public void GivenIHaveSelectedSavedAddressInTheShippingFromSection()
        {
            string _selectedAddress = GetValue(attributeName_id, LTL_SavedOriginAddressDropdown_Id, "value");

            if (_selectedAddress != "" || _selectedAddress != string.Empty)
            {
                Click(attributeName_id, ClearAddress_OriginId);
            }
            Click(attributeName_xpath, LTL_ShipinformationPage_ShippingFrom_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, LTL_SavedOriginAddressDropdown_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_id, LTL_SavedOriginAddressDropdown_Id, savedAddress); ////*[@id="scrollable-dropdown-menu-Origin"]/div/div/span[1]/span/div
            Thread.Sleep(3000);
            Click(attributeName_xpath, ".//*[@class='tt-dataset-autos'][1]//p");
            Report.WriteLine("I have selected saved address from Shipping From section");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ClearAddress_DestId);
            getQuoteLTL.EnterDestinationZip(destinationZip);
            Report.WriteLine("I have entered Shipping To section manually");
            Click(attributeName_id, LTL_ClearItem_Id);
            Thread.Sleep(3000);
            getQuoteLTL.EnterItemdata("50", "600");
            SendKeys(attributeName_id, InsuredValue_id, "800");
            Thread.Sleep(3000);
        }

        [Given(@"the Shipping From address was populated with a Default Shipper")]
        public void GivenTheShippingFromAddressWasPopulatedWithADefaultShipper()
        {
            Address Addvalue = DBHelper.Get_ShipperAddressInternalUsers(customerName);

            if (Addvalue != null)
            {
                var actualOriginCity = GetValue(attributeName_id, LTL_OriginCity_Id, "value");
                Assert.AreEqual(Addvalue.City, actualOriginCity);
                Report.WriteLine("Displaying Origin city in UI " + actualOriginCity + "is matching with DB value" + Addvalue.City);

                string actualOriginState = Gettext(attributeName_xpath, LTL_OriginStateProvince_SelectedValue_Xpath);
                Assert.AreEqual(Addvalue.State, actualOriginState);
                Report.WriteLine("Displaying Origin state/province in UI " + actualOriginState + "is matching with DB value" + Addvalue.State);

                string actualOriginZipCode = GetValue(attributeName_id, LTL_OriginZipPostal_Id, "value");
                Assert.AreEqual(Addvalue.Zip.ToUpper(), actualOriginZipCode.ToUpper());
                Report.WriteLine("Displaying Origin zip/postal in UI " + actualOriginZipCode + "is matching with DB value" + Addvalue.Zip);

                Report.WriteLine("The Shipping From address was populated with a Default Shipper");
            }
            else
            {
                Report.WriteFailure("The Shipping From address was not populated with a Default Shipper");
            }

            string _selectedAddress = GetValue(attributeName_id, LTL_SavedDestinationAddressDropdown_Id, "value");

            if (_selectedAddress != "" || _selectedAddress != string.Empty)
            {
                Click(attributeName_id, ClearAddress_DestId);

            }
            //Click(attributeName_xpath, LTL_ShipinformationPage_ShippingTo_Xpath);
            //GlobalVariables.webDriver.WaitForPageLoad();
            //Click(attributeName_id, LTL_SavedDestinationAddressDropdown_Id);
            //GlobalVariables.webDriver.WaitForPageLoad();
            //Click(attributeName_xpath, FirstSavedDestinationAddress);
            getQuoteLTL.EnterDestinationZip(destinationZip);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("I have selected Shipping To section");
            Click(attributeName_id, LTL_ClearItem_Id);
            Thread.Sleep(3000);
            getQuoteLTL.EnterItemdata("50", "600");
            SendKeys(attributeName_id, InsuredValue_id, "800");
            Thread.Sleep(3000);
        }

        [When(@"I click on the (.*)"), Scope(Tag = "53753")]
        public void WhenIClickOnThe(string button)
        {
            string verifyQuotes = Gettext(attributeName_xpath, LtlQuoteResultsPage_Norates_Xpath);
            if (verifyQuotes.Equals("There are no rates available for this shipment."))
            {
                Report.WriteLine("There are no rates available for this shipment.");
                Thread.Sleep(5000);
                Click(attributeName_xpath, ltlsavequotenorateslink_xpath);
                GlobalVariables.webDriver.WaitForPageLoad();
            }
            else
            {
                if (button.Equals("Save Rate as Quote"))
                {
                    Thread.Sleep(5000);
                    Click(attributeName_cssselector, "#Grid-Rate-List-Large-NonGuranteed > tbody > tr:nth-child(1) > td:nth-child(5) > ul:nth-child(4) > li > a"); GlobalVariables.webDriver.WaitForPageLoad();
                    Report.WriteLine("Click on Save Rate as Quote Link");
                }
                else if (button.Equals("Save Insured Rate as Quote"))
                {
                    Thread.Sleep(5000);
                    Click(attributeName_xpath, ltlsaverateasquotelnkint_xpath);
                    Report.WriteLine("Click on Save Insured Rate as Quote Link");
                    GlobalVariables.webDriver.WaitForPageLoad();
                }
                else if (button.Equals("Guaranteed Save Rate as Quote"))
                {
                    guaranteedLink = Gettext(attributeName_xpath, ltlGuaranteedRateAvbllnk_xpath);
                    if (guaranteedLink.Equals("Guaranteed Rate Available"))
                    {                       
                        Thread.Sleep(5000);
                        Click(attributeName_cssselector, "#Grid-Rate-List-Large-Guranteed > tbody > tr > td:nth-child(5) > ul:nth-child(4) > li > a");
                        Report.WriteLine("Click on Guaranteed Save Rate as Quote Link");
                        GlobalVariables.webDriver.WaitForPageLoad();

                    }
                    else
                    {
                        Report.WriteLine("No Guaranteed Rates Available");
                        Assert.Fail();
                    }
                }
                else if ((button.Equals("Guaranteed Save Insured Rate as Quote")))
                {
                    guaranteedLink = Gettext(attributeName_xpath, ltlGuaranteedRateAvbllnk_xpath);
                    if (guaranteedLink.Equals("Guaranteed Rate Available"))
                    {
                        Thread.Sleep(5000);
                        Click(attributeName_xpath, LtlGuaranteedSaveInsRateAsQuote_Xpath);
                        Report.WriteLine("Click on Guaranteed Save Insured Rate as Quote Link");
                        GlobalVariables.webDriver.WaitForPageLoad();
                    }
                    else
                    {
                        Report.WriteLine("No Guaranteed Rates Available");
                        Assert.Fail();
                    }
                }
                GlobalVariables.webDriver.WaitForPageLoad();
            }


        }

        [Then(@"CRM will send the Open Time of the customer to the MG Pickup Date Range - Early field")]
        public void ThenCRMWillSendTheOpenTimeOfTheCustomerToTheMGPickupDateRange_EarlyField()
        {
            Report.WriteLine("CRM will send the Open Time of the customer to the MG Pickup Date Range - Early field");
            GetShippingHoursFromMG();
            TimeSpan timeFromAPI = DateTime.Parse(shipmentViewModels.EarliestPickupDate).TimeOfDay;
            
            List<TimeSpan> shippingHoursFromDB = DBHelper.GetShippingHoursForCustomer(customerName);

            Assert.AreEqual(timeFromAPI, shippingHoursFromDB[0]);
        }

        [Then(@"CRM will send the Close Time of the customer to the MG Pickup Date Range - Late field")]
        public void ThenCRMWillSendTheCloseTimeOfTheCustomerToTheMGPickupDateRange_LateField()
        {
            Report.WriteLine("CRM will send the Close Time of the customer to the MG Pickup Date Range - Late field");
            GetShippingHoursFromMG();
            TimeSpan timeFromAPI = DateTime.Parse(shipmentViewModels.LatestPickupDate).TimeOfDay;
                        
            List<TimeSpan> shippingHoursFromDB = DBHelper.GetShippingHoursForCustomer(customerName);

            Assert.AreEqual(timeFromAPI, shippingHoursFromDB[1]);
        }

        [Then(@"CRM will send the Open Time of the selected saved address to the MG Pickup Date Range - Early field")]
        public void ThenCRMWillSendTheOpenTimeOfTheSelectedSavedAddressToTheMGPickupDateRange_EarlyField()
        {
            Report.WriteLine("CRM will send the Open Time of the selected saved address to the MG Pickup Date Range - Early field");
            GetShippingHoursFromMG();
            TimeSpan timeFromAPI = DateTime.Parse(shipmentViewModels.EarliestPickupDate).TimeOfDay;

            List<TimeSpan> shippingHoursFromDB = DBHelper.GetShippingHoursForSavedAddress(addressId, customerName);

            Assert.AreEqual(timeFromAPI, shippingHoursFromDB[0]);
        }

        [Then(@"CRM will send the Close Time of the selected saved address to the MG Pickup Date Range - Late field")]
        public void ThenCRMWillSendTheCloseTimeOfTheSelectedSavedAddressToTheMGPickupDateRange_LateField()
        {
            Report.WriteLine("CRM will send the Close Time of the selected saved address to the MG Pickup Date Range - Late field");
            GetShippingHoursFromMG();
            TimeSpan timeFromAPI = DateTime.Parse(shipmentViewModels.LatestPickupDate).TimeOfDay;

            List<TimeSpan> shippingHoursFromDB = DBHelper.GetShippingHoursForSavedAddress(addressId, customerName);

            Assert.AreEqual(timeFromAPI, shippingHoursFromDB[1]);
        }

        [Then(@"CRM will send the Open Time of the Default Shipper address to the MG Pickup Date Range - Early field")]
        public void ThenCRMWillSendTheOpenTimeOfTheDefaultShipperAddressToTheMGPickupDateRange_EarlyField()
        {
            Report.WriteLine("CRM will send the Open Time of the Default Shipper address to the MG Pickup Date Range - Early field");
            GetShippingHoursFromMG();
            TimeSpan timeFromAPI = DateTime.Parse(shipmentViewModels.EarliestPickupDate).TimeOfDay;

            List<TimeSpan> shippingHoursFromDB = DBHelper.GetShippingHoursForDefaultShipperAddress(customerName);

            Assert.AreEqual(timeFromAPI, shippingHoursFromDB[0]);
        }

        [Then(@"CRM will send the Close Time of the Default Shipper address to the MG Pickup Date Range - Late field")]
        public void ThenCRMWillSendTheCloseTimeOfTheDefaultShipperAddressToTheMGPickupDateRange_LateField()
        {
            Report.WriteLine("CRM will send the Close Time of the Default Shipper address to the MG Pickup Date Range - Late field");
            GetShippingHoursFromMG();
            TimeSpan timeFromAPI = DateTime.Parse(shipmentViewModels.LatestPickupDate).TimeOfDay;
           
            List<TimeSpan> shippingHoursFromDB = DBHelper.GetShippingHoursForDefaultShipperAddress(customerName);

            Assert.AreEqual(timeFromAPI, shippingHoursFromDB[1]);
        }

        public void GetShippingHoursFromMG()
        {
            referenceNumber = Gettext(attributeName_id, QC_RequestNumber_id);
            string uri = $"MercuryGate/OidLookup";
            
            BuildHttpClient client = new BuildHttpClient();
            HttpClient headers = client.BuildHttpClientWithHeaders("Admin", "application/xml");

            ShipmentExtract ext = new ShipmentExtract();
            shipmentViewModels = ext.getShipmentData(uri, headers, referenceNumber, "Admin");
        }

    }
}
