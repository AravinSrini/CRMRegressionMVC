using CRM.UITest.CommonMethods;
using CRM.UITest.Helper.Common;
using CRM.UITest.Helper.DataModels;
using CRM.UITest.Helper.Implementations.ShipmentExtract;
using CRM.UITest.Helper.Implementations.ShipmentImportThirdparty;
using CRM.UITest.Helper.ViewModel;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Script.Serialization;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Add_Shipment___3rd_PartyAPI
{
    [Binding]
    public class AddAShipment_CountryCodeFormattingSteps : AddShipments
    {
        CommonMethodsCrm crm = new CommonMethodsCrm();
        ShipmentExtractViewModel shipmentViewModels = null;
        string referenceNumber = string.Empty;
        string thirdPartyCustomerName = string.Empty;
        string thirdPartyV1CustomerName = string.Empty;
        ShipmentImportViewModel shipmentModel = null;
        ShipmentImportMockDataViewModel _shipmentImportMockDataViewModel = new ShipmentImportMockDataViewModel();

        [Given(@"I am a shp\.entry, shp\.entrynorates, sales, sales management, operations, or Station Owner user")]
        public void GivenIAmAShp_EntryShp_EntrynoratesSalesSalesManagementOperationsOrStationOwnerUser()
        {
            string username = ConfigurationManager.AppSettings["username-OperationsCrm"].ToString();
            string password = ConfigurationManager.AppSettings["password-OperationsCrm"].ToString();
            crm.LoginToCRMApplication(username, password);
        }

        [Given(@"I am creating a Shipment for MG Shipment Service Type LTL")]
        public void GivenIAmCreatingAShipmentForMGShipmentServiceTypeLTL()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ShipmentIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, AllCustomerDropdown_Selection_Internal_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, AllCustomerDroppdownValues_Internal_Xpath, "ZZZ - Czar Customer Test");
            Report.WriteLine("Customer is been selected from the dropdown");
            Click(attributeName_id, AddShipmentButtionInternal_Id);
            Report.WriteLine("Clicked on Add shipment button");
            Click(attributeName_id, AddShipmentLTL_Button_Id);
            Report.WriteLine("Clicked on LTL tile on Add shipment page");
            Verifytext(attributeName_xpath, AddShipment_PageTitle_xpath, "Add Shipment (LTL)");
            Report.WriteLine("Navigated to Shipment list page");
        }

        [Given(@"The Shipping From location country is Canada")]
        public void GivenTheShippingFromLocationCountryIsCanada()
        {
            Click(attributeName_xpath, ShippingFrom_CountryDropDown_xpath);
            SelectDropdownValueFromList(attributeName_xpath, ShippingFrom_CanadaCountryDropdown_Xpath, "Canada");
            SendKeys(attributeName_id, OriginZip_Id, "A1A 1A1");
            SendKeys(attributeName_id, ShippingFrom_City_Id, "St. john");
            Click(attributeName_xpath, ShippingFrom_StateDropdwon_xpath);
            SelectDropdownValueFromList(attributeName_xpath, ShippingFrom_StateDropdwon_Values_xpath, "NL");
            Report.WriteLine("Shipping From location country is selected as Canada");
            SendKeys(attributeName_id, ShippingTo_zipcode_Id, "60606");
            ShipInformation();
           
        }

        [Given(@"The Shipping From, Shipment To location country is Canada")]
        public void GivenTheShippingFromShipmentToLocationCountryIsCanada()
        {
            Click(attributeName_xpath, ShippingFrom_CountryDropDown_xpath);
            SelectDropdownValueFromList(attributeName_xpath, ShippingFrom_CanadaCountryDropdown_Xpath, "Canada");
            SendKeys(attributeName_id, OriginZip_Id, "A1A 1A1");
            SendKeys(attributeName_id, ShippingFrom_City_Id, "St. john");
            Click(attributeName_xpath, ShippingFrom_StateDropdwon_xpath);
            SelectDropdownValueFromList(attributeName_xpath, ShippingFrom_StateDropdwon_Values_xpath, "NL");
            Report.WriteLine("Shipping From location country is selected as Canada");
            Click(attributeName_xpath, ShippingTo_CountryDropDown_xpath);
            SelectDropdownValueFromList(attributeName_xpath, ShippingTo_CanadaCountryDropdown_Xpath, "Canada");
            SendKeys(attributeName_id, destinationZip_Id, "A1A 1A1");
            SendKeys(attributeName_id, ShippingTo_City_Id, "St. john");
            Click(attributeName_xpath, ShippingTo_StateDropdwon_xpath);
            SelectDropdownValueFromList(attributeName_xpath, ShippingTo_StateDropdwon_Values_xpath, "NL");
            Report.WriteLine("Shipping To location country is selected as Canada");
            ShipInformation();
          }

        [Given(@"I am on the Review and Submit \(LTL\) shipment page")]
        public void GivenIAmOnTheReviewAndSubmitLTLShipmentPage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, ShipResults_CreateShipmentWithoutCarrierRate_Button_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Navigated to Review and Submit Shipment(LTL) page");
        }

        [Given(@"The Shipping To location country is Canada")]
        public void GivenTheShippingToLocationCountryIsCanada()
        {
            
            Click(attributeName_xpath, ShippingTo_CountryDropDown_xpath);
            SelectDropdownValueFromList(attributeName_xpath, ShippingTo_CanadaCountryDropdown_Xpath, "Canada");
            SendKeys(attributeName_id, destinationZip_Id, "A1A 1A1");
            SendKeys(attributeName_id, ShippingTo_City_Id, "St. john");
            Click(attributeName_xpath, ShippingTo_StateDropdwon_xpath);
            SelectDropdownValueFromList(attributeName_xpath, ShippingTo_StateDropdwon_Values_xpath, "NL");
            Report.WriteLine("Shipping To location country is selected as Canada");
            SendKeys(attributeName_id, ShippingFrom_zipcode_Id, "60606");
            ShipInformation();
         }

        [Given(@"I am on Review and Submit LTL Shipment page")]
        public void GivenIAmOnReviewAndSubmitLTLShipmentPage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, ShipmentResult_CreateShipmentButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Navigated to Review and Submit page");

        }

        [Given(@"I am a third party Integration customer set up in CRM with new CRM rating logic")]
        public void GivenIAmAThirdPartyIntegrationCustomerSetUpInCRMWithNewCRMRatingLogic()
        {
            thirdPartyCustomerName = "ZZZ Sandbox DLS Worldwide";
        }

        [Given(@"I am a third party Integration customer set up in CRM without CRM rating logic")]
        public void GivenIAmAThirdPartyIntegrationCustomerSetUpInCRMWithoutCRMRatingLogic()
        {
            thirdPartyV1CustomerName = "Medallion - AHH20";
        }

        [Given(@"I am creating a shipment where the ShippingFrom location country is Canada")]
        public void GivenIAmCreatingAShipmentWhereTheShippingFromLocationCountryIsCanada()
        {
            shipmentModel = _shipmentImportMockDataViewModel.GenerateModel();
            shipmentModel.Consignee.CountryCode = "USA";
            shipmentModel.Consignee.PostalCode = "07029";
            shipmentModel.Consignee.City = "HARRISON";
            shipmentModel.Consignee.StateProvince = "NJ";
        }

        [Given(@"I am creating a shipment where the ShippingTo location country is Canada")]
        public void GivenIAmCreatingAShipmentWhereTheShippingToLocationCountryIsCanada()
        {
            shipmentModel = _shipmentImportMockDataViewModel.GenerateModel();
            shipmentModel.Shipper.CountryCode = "USA";
            shipmentModel.Shipper.PostalCode = "07029";
            shipmentModel.Shipper.City = "HARRISON";
            shipmentModel.Shipper.StateProvince = "NJ";
        }

        [Given(@"I am creating a shipment where the ShippingFrom, ShippingTo location country is Canada")]
        public void GivenIAmCreatingAShipmentWhereTheShippingFromShippingToLocationCountryIsCanada()
        {
            shipmentModel = _shipmentImportMockDataViewModel.GenerateModel();
        }

        [When(@"I click ""(.*)"" from the Review and Submit Shipment \(LTL\) page")]
        public void WhenIClickFromTheReviewAndSubmitShipmentLTLPage(string SubmitButton)
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            VerifyElementPresent(attributeName_id, SubmitShipmentButton_Id, SubmitButton);
            Click(attributeName_id, SubmitShipmentButton_Id);
            Report.WriteLine("Clicked on Submit Shipment button of Review and Submit Shipment(LTL) page");
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [When(@"I send the shipment import request")]
        public void WhenISendTheShipmentImportRequest()
        {
            HttpClient client = new HttpClient();
            string proxyApiUrl = ConfigurationManager.AppSettings["ProxyWebApiUrlVersion2"];
            string proxyUserName = ConfigurationManager.AppSettings["ProxyUserName"];
            string proxyApiKey = ConfigurationManager.AppSettings["ProxyApiKey"];
            client.Timeout = TimeSpan.FromSeconds(700000);
            client.BaseAddress = new Uri(proxyApiUrl);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("CustomerName", "ZZZ Sandbox DLS Worldwide");
            client.DefaultRequestHeaders.Add("Username", proxyUserName);
            client.DefaultRequestHeaders.Add("apiKey", proxyApiKey);
            var rateRequestJson = JsonConvert.SerializeObject(shipmentModel);
            HttpResponseMessage response = client.PostAsync("Shipment/Import", new StringContent(
            new JavaScriptSerializer().Serialize(shipmentModel), Encoding.UTF8, "application/json")).Result;
            var responseString = response.Content.ReadAsStringAsync();
            var responseJson = JsonConvert.DeserializeObject<dynamic>(responseString.Result);
            if (responseJson != null)
            {
                referenceNumber = responseJson["PrimaryReference"];
            }
        }

        [When(@"I send shipment import request")]
        public void WhenISendShipmentImportRequest()
        {
            HttpClient client = new HttpClient();
            string proxyApiUrlV1 = ConfigurationManager.AppSettings["ProxyWebApiUrl"];
            string proxyUserName = ConfigurationManager.AppSettings["ProxyUserName"];
            string proxyApiKey = ConfigurationManager.AppSettings["ProxyApiKey"];
            client.Timeout = TimeSpan.FromSeconds(700000);
            client.BaseAddress = new Uri(proxyApiUrlV1);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("CustomerName", "ZZZ Sandbox DLS Worldwide");
            client.DefaultRequestHeaders.Add("Username", proxyUserName);
            client.DefaultRequestHeaders.Add("apiKey", proxyApiKey);
            var rateRequestJson = JsonConvert.SerializeObject(shipmentModel);
            HttpResponseMessage response = client.PostAsync("Shipment/Import", new StringContent(
            new JavaScriptSerializer().Serialize(shipmentModel), Encoding.UTF8, "application/json")).Result;
            var responseString = response.Content.ReadAsStringAsync();
            var responseJson = JsonConvert.DeserializeObject<dynamic>(responseString.Result);
            if (responseJson != null)
            {
                referenceNumber = responseJson["PrimaryReference"];
            }
        }


        [Then(@"The shipment in MG should return shipper/consignor\(From\) section country as '(.*)'")]
        public void ThenTheShipmentInMGShouldReturnShipperConsignorFromSectionCountryAs(string Origin)
        {
            referenceNumber = Gettext(attributeName_id, ShipmentConfirmationNumber_Id);
            GetShipmentDetails();
            if (shipmentViewModels.AddressViewModels[0].Type.ToLower() == "origin")
            {
                string ActualShipFromCountry = shipmentViewModels.AddressViewModels[0].CountryCode;
                Assert.AreEqual(ActualShipFromCountry, "CANADA");
                Report.WriteLine("Shipment in MG returned shipper/consignor(From) section country as  " + Origin + " ");

            }
        }

        [Then(@"The shipment in MG should return Consignee \(To\) section country as '(.*)'")]
        public void ThenTheShipmentInMGShouldReturnConsigneeToSectionCountryAs(string Destination)
        {
            referenceNumber = Gettext(attributeName_id, ShipmentConfirmationNumber_Id);
            GetShipmentDetails();
            if (shipmentViewModels.AddressViewModels[1].Type.ToLower() == "destination")
            {
                string ActualShipToCountry = shipmentViewModels.AddressViewModels[1].CountryCode;
                Assert.AreEqual(ActualShipToCountry, "CANADA");
                Report.WriteLine("Shipment in MG returned Consignee (TO) section country as  " + Destination + " ");
            }

        }

        [Then(@"The shipment in MG should return shipper/consignor\(From\) section country as '(.*)' for the shipment created by third party")]
        public void ThenTheShipmentInMGShouldReturnShipperConsignorFromSectionCountryAsForTheShipmentCreatedByThirdParty(string Origin)
        {
            GetShipmentDetails();
            if (shipmentViewModels.AddressViewModels[0].Type.ToLower() == "origin")
            {
                string ActualShipFromCountry = shipmentViewModels.AddressViewModels[0].CountryCode;
                Assert.AreEqual(ActualShipFromCountry, "CANADA");
                Report.WriteLine("Shipment in MG returned shipper/consignor(From) section country as  " + Origin + " for the shipment created by 3rd party");
            }
        }

        [Then(@"The shipment in MG should return Consignee \(To\) section country as '(.*)' for the shipment created by third party")]
        public void ThenTheShipmentInMGShouldReturnConsigneeToSectionCountryAsForTheShipmentCreatedByThirdParty(string Destination)
        {
            GetShipmentDetails();
            if (shipmentViewModels.AddressViewModels[1].Type.ToLower() == "destination")
            {
                string ActualShipToCountry = shipmentViewModels.AddressViewModels[1].CountryCode;
                Assert.AreEqual(ActualShipToCountry, "CANADA");
                Report.WriteLine("Shipment in MG returned Consignee (TO) section country as  " + Destination + " for the shipment created by 3rd party");
            }
        }
        public void GetShipmentDetails()
        {
            string uri = $"MercuryGate/OidLookup";

            //Building Client
            BuildHttpClient client = new BuildHttpClient();
            HttpClient headers = client.BuildHttpClientWithHeaders("Admin", "application/xml");

            ShipmentExtract ext = new ShipmentExtract();
            shipmentViewModels = ext.getShipmentData(uri, headers, referenceNumber, "Admin");

        }

        public void ShipInformation()
        {
            scrollElementIntoView(attributeName_id, ShippingFrom_ClearAddress_Id);
            SendKeys(attributeName_id, ShippingFrom_LocationName_Id, "test");
            SendKeys(attributeName_id, ShippingFrom_LocationAddressLine1_Id, "Address");
            scrollElementIntoView(attributeName_id, ShippingTo_LocationName_Id);
            SendKeys(attributeName_id, ShippingTo_LocationName_Id, "testing");
            SendKeys(attributeName_id, ShippingTo_LocationAddressLine1_Id, "addressdest");
            scrollpagedown();
            Click(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            MoveToElement(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id);
            Click(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id);
            IList<IWebElement> dropdownValues = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='scrollable-dropdown-menu-Origin']/div/span[1]/span/div/span/div/p"));
            for (int i = 0; i < dropdownValues.Count; i++)
            {
                int z = i + 1;
                string value = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='scrollable-dropdown-menu-Origin']/div/span[1]/span/div/span/div[" + z + "]/p")).Text;
                if (value == "65")
                {
                    GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='scrollable-dropdown-menu-Origin']/div/span[1]/span/div/span/div[" + z + "]/p")).Click();
                    break;
                }
            }
            scrollpagedown();
            SendKeys(attributeName_id, FreightDesp_FirstItem_NMFC_Id, "34");
            SendKeys(attributeName_id, FreightDesp_FirstItem_Quantity_Id, "1");
            SendKeys(attributeName_id, FreightDesp_FirstItem_Weight_Id, "5");
            SendKeys(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id, "Description");
            Clear(attributeName_id, FreightDesp_FirstItem_Length_Id);
            Clear(attributeName_id, FreightDesp_FirstItem_Width_Id);
            Clear(attributeName_id, FreightDesp_FirstItem_Height_Id);
            SendKeys(attributeName_id, InsuredValue_TextBox_Id, "16,000.00");
            Click(attributeName_xpath, ViewRatesButton_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            VerifyElementPresent(attributeName_xpath, ShipResults_PageHeaderText_Relativexpath, "Shipment Results (LTL)");
            Report.WriteLine("Navigated to Shipment Results page");


        }
    }
}
