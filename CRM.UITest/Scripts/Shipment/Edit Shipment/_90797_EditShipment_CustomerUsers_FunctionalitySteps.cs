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
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Script.Serialization;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Edit_Shipment
{
    [Binding]
    public class _90797_EditShipment_CustomerUsers_FunctionalitySteps : AddShipments
    {
        CommonMethodsCrm crm = new CommonMethodsCrm();
        ShipmentImportMockDataViewModel _shipmentImportMockDataViewModel = new ShipmentImportMockDataViewModel();
        ShipmentImportViewModel shipmentModel = null;
        ShipmentExtractViewModel shipmentViewModels = null;
        string referenceNumber = string.Empty;

        [Given(@"I am a Shp\.entry, Shp\.entrynorates user")]
        public void GivenIAmAShp_EntryShp_EntrynoratesUser()
        {
            string username = ConfigurationManager.AppSettings["username-Both"].ToString();
            string password = ConfigurationManager.AppSettings["password-Both"].ToString();
            crm.LoginToCRMApplication(username, password);
        }

        [Given(@"I am a shp\.entry User")]
        public void GivenIAmAShp_EntryUser()
        {
            string username = ConfigurationManager.AppSettings["username-CurrentSprintshpentry"].ToString();
            string password = ConfigurationManager.AppSettings["password-CurrentSprintshpentry"].ToString();
            crm.LoginToCRMApplication(username, password);

        }

        [When(@"The displayed LTL Shipment is in (.*) status")]
        public void WhenTheDisplayedLTLShipmentIsInStatus(string StatusType)
        {
            Click(attributeName_xpath, AllCustomerDropdown_Selection_Internal_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, AllCustomerDroppdownValues_Internal_Xpath, "ZZZ - GS Customer Test");
            Report.WriteLine("Customer is been selected from the dropdown");
            GlobalVariables.webDriver.WaitForPageLoad();
            if (StatusType == "Pending")
            {
                SendKeys(attributeName_id, ShipmentList_SearchBox_Id, "Pending");
                Verifytext(attributeName_xpath, ShipmentList_FirstStatus_Xpath, " Pending");
                Report.WriteLine("Displayed LTL Shipment is in pending status");
            }

            if(StatusType == "Scheduled")
            {
                Click(attributeName_xpath, ShipmentList_SelectReport_Xpath);
                SendKeys(attributeName_xpath, ShipmentList_ReportSearch_Xpath, "Shipments Scheduled not Rated");
                SelectDropdownValueFromList(attributeName_xpath, ShipmentList_SelectReportDropdownVal_Xpath, "Shipments Scheduled not Rated");
                Verifytext(attributeName_xpath, ShipmentList_FirstStatus_Xpath, " Scheduled");
                Report.WriteLine("Displayed LTL Shipment is in scheduled status");
            }

            if(StatusType == "Unscheduled")
            {
                Click(attributeName_xpath, ShipmentList_SelectReport_Xpath);
                SendKeys(attributeName_xpath, ShipmentList_ReportSearch_Xpath, "Shipments Unscheduled");
                SelectDropdownValueFromList(attributeName_xpath, ShipmentList_SelectReportDropdownVal_Xpath, "Shipments Unscheduled");
                Verifytext(attributeName_xpath, ShipmentList_FirstStatus_Xpath, " Unscheduled");
                Report.WriteLine("Displayed LTL Shipment is in Unscheduled status");

            }

        }

        [When(@"Displayed LTL Shipment is in (.*) status")]
        public void WhenDisplayedLTLShipmentIsInStatus(string statusType)
        {
            if (statusType == "InTransit")
            {
                SendKeys(attributeName_id, ShipmentList_SearchBox_Id, "In Transit");
                Verifytext(attributeName_xpath, ShipmentList_FirstStatus_Xpath, "In Transit");
                Report.WriteLine("Displayed LTL Shipment is in In Transit status");
            }

            if (statusType == "Delivered")
            {

                SendKeys(attributeName_id, ShipmentList_SearchBox_Id, "Delivered");
                Verifytext(attributeName_xpath, ShipmentList_FirstStatus_Xpath, "Delivered");
                Report.WriteLine("Displayed LTL Shipment is in Delivered status");
            }

            if (statusType == "Booked")
            {
                SendKeys(attributeName_id, ShipmentList_SearchBox_Id, "Booked");
                Verifytext(attributeName_xpath, ShipmentList_FirstStatus_Xpath, "Booked");
                Report.WriteLine("Displayed LTL Shipment is in Booked status");

            }
        }

        [Given(@"I clicked on Edit button for any eligible LTL shipment")]
        public void GivenIClickedOnEditButtonForAnyEligibleLTLShipment()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            shipmentModel = _shipmentImportMockDataViewModel.GenerateModel();
            string ePDate = DateTime.Now.AddDays(5).ToString("yyyy-MM-dd hh:mm");
            shipmentModel.Dates.EarliestPickupDate = Convert.ToDateTime(ePDate);
            string lPDate = DateTime.Now.AddDays(5).ToString("yyyy-MM-dd hh:mm");
            shipmentModel.Dates.LatestPickupDate = Convert.ToDateTime(lPDate);
            string eDDate = DateTime.Now.AddDays(5).ToString("yyyy-MM-dd hh:mm");
            shipmentModel.Dates.EarliestDropDate = Convert.ToDateTime(eDDate);
            string lDDate = DateTime.Now.AddDays(5).ToString("yyyy-MM-dd hh:mm");
            shipmentModel.Dates.LatestDropDate = Convert.ToDateTime(lDDate);
            CreateShipment();
        }

        [Given(@"I clicked on the Edit button for any eligible LTL shipment")]
        public void GivenIClickedOnTheEditButtonForAnyEligibleLTLShipment()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            shipmentModel = _shipmentImportMockDataViewModel.GenerateModel();
            shipmentModel.Consignee.CountryCode = "USA";
            shipmentModel.Consignee.PostalCode = "07029";
            shipmentModel.Consignee.City = "HARRISON";
            shipmentModel.Consignee.StateProvince = "NJ";
            shipmentModel.Shipper.CountryCode = "USA";
            shipmentModel.Shipper.PostalCode = "07029";
            shipmentModel.Shipper.City = "HARRISON";
            shipmentModel.Shipper.StateProvince = "NJ";
            string ePDate = DateTime.Now.AddDays(5).ToString("yyyy-MM-dd hh:mm");
            shipmentModel.Dates.EarliestPickupDate = Convert.ToDateTime(ePDate);
            string lPDate = DateTime.Now.AddDays(5).ToString("yyyy-MM-dd hh:mm");
            shipmentModel.Dates.LatestPickupDate = Convert.ToDateTime(lPDate);
            string eDDate = DateTime.Now.AddDays(5).ToString("yyyy-MM-dd hh:mm");
            shipmentModel.Dates.EarliestDropDate = Convert.ToDateTime(eDDate);
            string lDDate = DateTime.Now.AddDays(5).ToString("yyyy-MM-dd hh:mm");
            shipmentModel.Dates.LatestDropDate = Convert.ToDateTime(lDDate);
            CreateShipment();
        }

       
        [Given(@"I am on Shipment Results \(LTL\) page")]
        public void GivenIAmOnShipmentResultsLTLPage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Verifytext(attributeName_xpath, ShipResults_PageHeaderText_Relativexpath, "Shipment Results (LTL)");
            Report.WriteLine("Arrived on Shipment Results page");

        }

        [Given(@"I clicked on the View Rates button on the Add Shipment \(LTL\) page")]
        public void GivenIClickedOnTheViewRatesButtonOnTheAddShipmentLTLPage()
        {
            scrollpagedown();
            Click(attributeName_xpath, LTL_PickUpReadyTime_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, LTL_PickUpReadyTimeDropdown_Xpath, "12:30 AM");
            Click(attributeName_xpath, LTL_PickUpCloseTime_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, LTL_PickUpCloseTimeDropdown_Xpath, "01:00 AM");
            scrollElementIntoView(attributeName_xpath, Shipments_ViewRatesButton_xpath);
            SendKeys(attributeName_xpath, AddShip_InsuredVal_Xpath, "2345");
            Click(attributeName_xpath, Shipments_ViewRatesButton_xpath);
            Report.WriteLine("Clicked on View rates button");
        }
        
        [Given(@"clicked on the (.*) button of an eligible LTL shipment")]
        public void GivenClickedOnTheButtonOfAnEligibleLTLShipment(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I arrived on the Shipment Results \(LTL\) page")]
        public void GivenIArrivedOnTheShipmentResultsLTLPage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Verifytext(attributeName_xpath, ShipResults_PageHeaderText_Relativexpath, "Shipment Results (LTL)");
            Report.WriteLine("Arrived on Shipment Results page");

        }

        [Given(@"I am a shp\.entrynorates user")]
        public void GivenIAmAShp_EntrynoratesUser()
        {
            string username = ConfigurationManager.AppSettings["username-NoratesGscustomer"].ToString();
            string password = ConfigurationManager.AppSettings["password-NoratesGscustomer"].ToString();
            crm.LoginToCRMApplication(username, password);
        }
  
        [Given(@"I am on the Review and Submit \(LTL\) page")]
        public void GivenIAmOnTheReviewAndSubmitLTLPage()
        {
            scrollpagedown();
            Click(attributeName_xpath, LTL_PickUpReadyTime_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, LTL_PickUpReadyTimeDropdown_Xpath, "12:30 AM");
            Click(attributeName_xpath, LTL_PickUpCloseTime_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, LTL_PickUpCloseTimeDropdown_Xpath, "01:00 AM");
            scrollElementIntoView(attributeName_xpath, Shipments_ViewRatesButton_xpath);
            SendKeys(attributeName_xpath, AddShip_InsuredVal_Xpath, "2345");
            Click(attributeName_xpath, Shipments_ViewRatesButton_xpath);
            Report.WriteLine("Clicked on View rates button");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, EditShipResult_UpdateStandardShip_Xpath);
            Verifytext(attributeName_xpath, ReviewAndSubmit_Title_Xpath, "Review and Submit Shipment (LTL)");
            Report.WriteLine("Navigated to Review and Submit page");
        }
        
        [Given(@"I Clicked on Submit Updated Shipment Button")]
        public void GivenIClickedOnSubmitUpdatedShipmentButton()
        {
            scrollElementIntoView(attributeName_id, ReviewPage_SubmitButton_id);
            Click(attributeName_id, ReviewPage_SubmitButton_id);
            Report.WriteLine("Clicked on Submit updated shipment button");
            GlobalVariables.webDriver.WaitForPageLoad();
        }
              
        [When(@"I click on the Edit button for any eligible LTL shipment")]
        public void WhenIClickOnTheEditButtonForAnyEligibleLTLShipment()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            shipmentModel = _shipmentImportMockDataViewModel.GenerateModel();
            shipmentModel.Consignee.CountryCode = "USA";
            shipmentModel.Consignee.PostalCode = "07029";
            shipmentModel.Consignee.City = "HARRISON";
            shipmentModel.Consignee.StateProvince = "NJ";
            shipmentModel.Shipper.CountryCode = "USA";
            shipmentModel.Shipper.PostalCode = "07029";
            shipmentModel.Shipper.City = "HARRISON";
            shipmentModel.Shipper.StateProvince = "NJ";
            string ePDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm");
            shipmentModel.Dates.EarliestPickupDate = Convert.ToDateTime(ePDate);
            string lPDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm");
            shipmentModel.Dates.LatestPickupDate = Convert.ToDateTime(lPDate);
            string eDDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm");
            shipmentModel.Dates.EarliestDropDate = Convert.ToDateTime(eDDate);
            string lDDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm");
            shipmentModel.Dates.LatestDropDate = Convert.ToDateTime(lDDate);
            CreateShipment();            
        }

        [When(@"I click on the Pickup Date calendar")]
        public void WhenIClickOnThePickupDateCalendar()
        {
            Click(attributeName_xpath, PickUpDate_Xpath);
            Report.WriteLine("Clicked on Pickup Date Calender");
        }
        
        [When(@"I arrive on the Shipment Results \(LTL\) page")]
        public void WhenIArriveOnTheShipmentResultsLTLPage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Verifytext(attributeName_xpath, ShipResults_PageHeaderText_Relativexpath, "Shipment Results (LTL)");
            Report.WriteLine("Arrived on Shipment Results page");
        }

        [Then(@"I have the option to select displayed carrier")]
        public void ThenIHaveTheOptionToSelectDisplayedCarrier()
        {

            VerifyElementPresent(attributeName_xpath, EditShipResult_UpdateStandardShip_Xpath, "Carrier");
            Report.WriteLine("User has the option to select displayed carrier");
        }

        [When(@"I click on View Rates button on the Add Shipment \(LTL\) page")]
        public void WhenIClickOnViewRatesButtonOnTheAddShipmentLTLPage()
        {
            scrollpagedown();
            Click(attributeName_xpath, LTL_PickUpReadyTime_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, LTL_PickUpReadyTimeDropdown_Xpath, "12:30 AM");
            Click(attributeName_xpath, LTL_PickUpCloseTime_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, LTL_PickUpCloseTimeDropdown_Xpath, "01:00 AM");
            scrollElementIntoView(attributeName_xpath, Shipments_ViewRatesButton_xpath);
            SendKeys(attributeName_xpath, AddShip_InsuredVal_Xpath, "2345");
            Click(attributeName_xpath, Shipments_ViewRatesButton_xpath);
            Report.WriteLine("Clicked on View rates button");
        }

        [When(@"I click on either of the following buttons for any displayed carrier - (.*)")]
        public void WhenIClickOnEitherOfTheFollowingButtonsForAnyDisplayedCarrier_(string shipmentType)
        {
            if(shipmentType == "Update Shipment")
            {
                Click(attributeName_xpath, EditShipResult_UpdateStandardShip_Xpath);
                Report.WriteLine("Clicked on Update Shipment button");
                GlobalVariables.webDriver.WaitForPageLoad();
            }

            if(shipmentType == "Update Insured Shipment")
            {
                Click(attributeName_xpath, EditShipResult_UpdateInsuredShip_Xpath);
                Report.WriteLine("Clicked on Update Insured Shipment button");
                GlobalVariables.webDriver.WaitForPageLoad();
            }
        }
        
        [When(@"There are no rates available for the shipment")]
        public void WhenThereAreNoRatesAvailableForTheShipment()
        {
            VerifyElementNotPresent(attributeName_xpath, EditShipResult_UpdateStandardShip_Xpath, "NoRates");
            Report.WriteLine("No rates are available for the shipment");
        }
        
        [Then(@"I will have the option to edit the shipment")]
        public void ThenIWillHaveTheOptionToEditTheShipment()
        {
            VerifyElementPresent(attributeName_xpath, ShipmentList_EditButton_ExternalUser_Xpath, "Edit");
            Report.WriteLine("Edit button is visible");
        }

        [Then(@"I will not have an option to edit the shipment")]
        public void ThenIWillNotHaveAnOptionToEditTheShipment()
        {
            VerifyElementNotPresent(attributeName_xpath, ShipmentList_EditButton_ExternalUser_Xpath, "Edit");
            Report.WriteLine("Edit button is not visible");

        }

        [Then(@"All of the data from the shipment will be auto-populated on the Add Shipment \(LTL\) page")]
        public void ThenAllOfTheDataFromTheShipmentWillBeAuto_PopulatedOnTheAddShipmentLTLPage()
        {
            string uri = $"MercuryGate/OidLookup";
            //Building Client
            BuildHttpClient client = new BuildHttpClient();
            HttpClient headers = client.BuildHttpClientWithHeaders("Admin", "application/xml");

            ShipmentExtract ext = new ShipmentExtract();
            shipmentViewModels = ext.getShipmentData(uri, headers, referenceNumber, "Admin");
            if (shipmentViewModels.AddressViewModels[0].Type.ToLower() == "origin")
            {
                string originName = shipmentViewModels.AddressViewModels[0].Name;
                string ActualOriginName = GetValue(attributeName_id, ShippingFrom_LocationName_Id, "value");
                Assert.AreEqual(originName.ToUpper(), ActualOriginName.ToUpper());
                Report.WriteLine("Displaying Origin name in UI " + ActualOriginName + "is matching with API shipping to value " + originName);

                string OriginAddress = shipmentViewModels.AddressViewModels[0].AddressLine1;
                string ActualOriginAddress = GetValue(attributeName_id, ShippingFrom_LocationAddressLine1_Id, "value");
                Assert.AreEqual(OriginAddress.ToUpper(), ActualOriginAddress.ToUpper());
                Report.WriteLine("Displaying Origin Address line 1 " + ActualOriginAddress + "is matching with API shipping From value " + OriginAddress);

                string OriginAddress2 = shipmentViewModels.AddressViewModels[0].AddressLine2;
                string ActualOriginAddress2 = GetValue(attributeName_id, ShippingFrom_LocationAddressLine2_Id, "value");
                Assert.AreEqual(OriginAddress2.ToUpper(), ActualOriginAddress2.ToUpper());
                Report.WriteLine("Displaying Origin Address line 2 " + ActualOriginAddress2 + "is matching with API shipping From value " + OriginAddress2);

                string OriginZipOrPostal = shipmentViewModels.AddressViewModels[0].PostalCode;
                string ActualOriginZipOrPostal = GetValue(attributeName_id, ShippingFrom_zipcode_Id, "value");
                Assert.AreEqual(OriginZipOrPostal.ToUpper(), ActualOriginZipOrPostal.ToUpper());
                Report.WriteLine("Displaying Origin Zip Or Postal " + ActualOriginZipOrPostal + "is matching with API shipping From value " + OriginZipOrPostal);

                string OriginCountry = shipmentViewModels.AddressViewModels[0].CountryCode;
                if (OriginCountry == "USA")
                {
                    string ActualOriginCountry = Gettext(attributeName_xpath, ShippingFrom_CountryDropDown_xpath);
                    Assert.AreEqual(ActualOriginCountry, "United States");
                    Report.WriteLine("Displaying Origin Country " + ActualOriginCountry + "is matching with API shipping From value " + OriginCountry);
                }
                else
                {
                    string ActualOriginCountry = Gettext(attributeName_xpath, ShippingFrom_CountryDropDown_xpath);
                    Assert.AreEqual(ActualOriginCountry, "Canada");
                    Report.WriteLine("Displaying Origin Country " + ActualOriginCountry + "is matching with API shipping From value " + OriginCountry);

                }

                string OriginCity = shipmentViewModels.AddressViewModels[0].City;
                string ActualOriginCity = GetValue(attributeName_id, ShippingFrom_City_Id, "value");
                Assert.AreEqual(OriginCity.ToUpper(), ActualOriginCity.ToUpper());
                Report.WriteLine("Displaying Origin City " + ActualOriginCity + "is matching with API shipping From value " + OriginCity);

                string OriginStateOrProvince = shipmentViewModels.AddressViewModels[0].StateProvince;
                string ActualOriginStateOrProvince = Gettext(attributeName_xpath, ShippingFrom_StateDropdwon_xpath);
                Assert.AreEqual(OriginStateOrProvince.ToUpper(), ActualOriginStateOrProvince.ToUpper());
                Report.WriteLine("Displaying Origin State or Province " + ActualOriginStateOrProvince + "is matching with API shipping From value " + OriginStateOrProvince);

                if (shipmentViewModels.AddressViewModels[1].Type.ToLower() == "destination")
                {
                    string DesName = shipmentViewModels.AddressViewModels[1].Name;
                    string ActualDesName = GetValue(attributeName_id, ShippingTo_LocationName_Id, "value");
                    Assert.AreEqual(DesName.ToUpper(), ActualDesName.ToUpper());
                    Report.WriteLine("Displaying Destination name in UI " + ActualDesName + "is matching with API shipping to value " + DesName);

                    string DesAddress = shipmentViewModels.AddressViewModels[1].AddressLine1;
                    string ActualDesAddress = GetValue(attributeName_id, ShippingTo_LocationAddressLine1_Id, "value");
                    Assert.AreEqual(DesAddress.ToUpper(), ActualDesAddress.ToUpper());
                    Report.WriteLine("Displaying Destination Address line 1 " + ActualDesAddress + "is matching with API shipping From value " + DesAddress);

                    string DesAddress2 = shipmentViewModels.AddressViewModels[1].AddressLine2;
                    string ActualDesAddress2 = GetValue(attributeName_id, ShippingTo_LocationAddressLine2_Id, "value");
                    Assert.AreEqual(DesAddress2.ToUpper(), ActualDesAddress2.ToUpper());
                    Report.WriteLine("Displaying Destination Address line 2 " + ActualDesAddress2 + "is matching with API shipping From value " + DesAddress2);

                    string DesZipOrPostal = shipmentViewModels.AddressViewModels[1].PostalCode;
                    string ActualDesZipOrPostal = GetValue(attributeName_id, ShippingTo_zipcode_Id, "value");
                    Assert.AreEqual(DesZipOrPostal.ToUpper(), ActualDesZipOrPostal.ToUpper());
                    Report.WriteLine("Displaying Destination Zip Or Postal " + ActualDesZipOrPostal + "is matching with API shipping From value " + DesZipOrPostal);

                    string DesCountry = shipmentViewModels.AddressViewModels[1].CountryCode;
                    if (DesCountry == "USA")
                    {
                        string ActualDesCountry = Gettext(attributeName_xpath, ShippingTo_CountryDropDown_xpath);
                        Assert.AreEqual(ActualDesCountry, "United States");
                        Report.WriteLine("Displaying Destination Country " + ActualDesCountry + "is matching with API shipping From value " + DesCountry);
                    }
                    else
                    {
                        string ActualDesCountry = Gettext(attributeName_xpath, ShippingTo_CountryDropDown_xpath);
                        Assert.AreEqual(ActualDesCountry, "CANADA");
                        Report.WriteLine("Displaying Destination Country " + ActualDesCountry + "is matching with API shipping From value " + DesCountry);

                    }
                    string DesCity = shipmentViewModels.AddressViewModels[1].City;
                    string ActualDesCity = GetValue(attributeName_id, ShippingTo_City_Id, "value");
                    Assert.AreEqual(DesCity.ToUpper(), ActualDesCity.ToUpper());
                    Report.WriteLine("Displaying Destination City " + ActualDesCity + "is matching with API shipping From value " + DesCity);

                    string DesStateOrProvince = shipmentViewModels.AddressViewModels[1].StateProvince;
                    string ActualDesStateOrProvince = Gettext(attributeName_xpath, ShippingTo_StateDropdwon_xpath);
                    Assert.AreEqual(DesStateOrProvince.ToUpper(), ActualDesStateOrProvince.ToUpper());
                    Report.WriteLine("Displaying Destination State or Province " + ActualDesStateOrProvince + "is matching with API shipping From value " + DesStateOrProvince);
                }

                scrollpagedown();
                scrollpagedown();
                string Class = shipmentViewModels.ItemViewModels[0].Classification;
                string[] Classi = Class.Split('.');
                string classification = Classi[0];
                string ActualClass = GetValue(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id, "value");
                Assert.AreEqual(classification, ActualClass);

                string NMFC = shipmentViewModels.ItemViewModels[0].NmfcCode;
                string ActualNMFC = GetValue(attributeName_id, FreightDesp_FirstItem_NMFC_Id, "value");
                Assert.AreEqual(NMFC, ActualNMFC);

                string Quantity = shipmentViewModels.ItemViewModels[0].Quantity;
                string[] Quan = Quantity.Split('.');
                string QuantityAPI = Quan[0];
                string ActualQuantity = GetValue(attributeName_id, FreightDesp_FirstItem_Quantity_Id, "value");
                Assert.AreEqual(QuantityAPI, ActualQuantity);

                string QuanType = shipmentViewModels.ItemViewModels[0].QuantityUnit;
                string ActualQuanType = Gettext(attributeName_xpath, FreightDesp_FirstItem_QuantityType_xpath);
                GetQuantityType val = new GetQuantityType();
                string ExpQuantityType = val.Getquantity(QuanType);
                Assert.AreEqual(ExpQuantityType, ActualQuanType);

                string ItemDescription = shipmentViewModels.ItemViewModels[0].ItemDescription;
                string ActualItemDescription = GetValue(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id, "value");
                Assert.AreEqual(ItemDescription, ActualItemDescription);

                string Weight = shipmentViewModels.ItemViewModels[0].Weight;
                string[] weight = Weight.Split('.');
                string weightAPI = weight[0];
                string ActualWeight = GetValue(attributeName_id, FreightDesp_FirstItem_Weight_Id, "value");
                Assert.AreEqual(weightAPI, ActualWeight);

                string WeightType = shipmentViewModels.ItemViewModels[0].WeightUnit;
                string ActualWeightType = Gettext(attributeName_xpath, FreightDesp_FirstItem_WeightType_xpath);
                GetWeightType vals = new GetWeightType();
                string ExpWeightType = vals.GetWeight(WeightType);
                Assert.AreEqual(ExpWeightType, ActualWeightType);

                bool Hazardous = shipmentViewModels.ItemViewModels[0].IsHazardous;
                if (Hazardous == true)
                {
                    scrollpagedown();
                    VerifyElementChecked(attributeName_id, FreightDesp_FirstItem_Hazardous_Yes_Input_Id, "Hazardous");
                }

                else if (Hazardous == false)
                {
                    VerifyElementChecked(attributeName_id, FreightDesp_FirstItem_Hazardous_No_Input_Id, "Hazardous");

                }
                else
                {
                    Report.WriteFailure("Invalid");
                }

                string DLength = shipmentViewModels.ItemViewModels[0].Length;
                string[] dLength = DLength.Split('.');
                string dLengthtAPI = dLength[0];
                string ActualDLength = GetValue(attributeName_id, FreightDesp_FirstItem_Length_Id, "value");
                Assert.AreEqual(dLengthtAPI, ActualDLength);

                string DWidth = shipmentViewModels.ItemViewModels[0].Width;
                string[] dWidth = DWidth.Split('.');
                string dWidthAPI = dWidth[0];
                string ActualWidth = GetValue(attributeName_id, FreightDesp_FirstItem_Width_Id, "value");
                Assert.AreEqual(dWidthAPI, ActualWidth);

                string DHeight = shipmentViewModels.ItemViewModels[0].Height;
                string[] dHeight = DHeight.Split('.');
                string dHeightAPI = dHeight[0];
                string ActualHeight = GetValue(attributeName_id, FreightDesp_FirstItem_Height_Id, "value");
                Assert.AreEqual(dHeightAPI, ActualHeight);

                string DType = shipmentViewModels.ItemViewModels[0].DimensionUnit;
                string DTypeVal = DType.ToUpper();
                string ActualDType = Gettext(attributeName_xpath, FreightDesp_FirstItem_DimensionType_xpath);
                Assert.AreEqual(DTypeVal, ActualDType);
                Report.WriteLine("All the data is autopopulated on Edit Shipment page");
            }


          }

        [Then(@"All of the fields are editable")]
        public void ThenAllOfTheFieldsAreEditable()
        {
            scrollPageup();
            scrollPageup();
            SendKeys(attributeName_id, ShippingFrom_LocationName_Id, "test");
            SendKeys(attributeName_id, ShippingFrom_LocationAddressLine1_Id, "Address");
            scrollElementIntoView(attributeName_id, ShippingTo_LocationName_Id);
            SendKeys(attributeName_id, ShippingTo_LocationName_Id, "testing");
            SendKeys(attributeName_id, ShippingTo_LocationAddressLine1_Id, "addressdest");
            Click(attributeName_xpath, ShippingFrom_CountryDropDown_xpath);
            SelectDropdownValueFromList(attributeName_xpath, ShippingFrom_CanadaCountryDropdown_Xpath, "Canada");
            SendKeys(attributeName_id, OriginZip_Id, "A1A 1A1");
            SendKeys(attributeName_id, ShippingFrom_City_Id, "St. john");
            Click(attributeName_xpath, ShippingFrom_StateDropdwon_xpath);
            SelectDropdownValueFromList(attributeName_xpath, ShippingFrom_StateDropdwon_Values_xpath, "NL");
            Click(attributeName_xpath, ShippingTo_CountryDropDown_xpath);
            SelectDropdownValueFromList(attributeName_xpath, ShippingTo_CanadaCountryDropdown_Xpath, "Canada");
            SendKeys(attributeName_id, destinationZip_Id, "A1A 1A1");
            SendKeys(attributeName_id, ShippingTo_City_Id, "St. john");
            Click(attributeName_xpath, ShippingTo_StateDropdwon_xpath);
            SelectDropdownValueFromList(attributeName_xpath, ShippingTo_StateDropdwon_Values_xpath, "NL");
            scrollpagedown();
            Click(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            MoveToElement(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id);
            Click(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id);
            GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='scrollable-dropdown-menu-Origin']/div/span[1]/span/div/span/div[" + 1 + "]/p")).Click();
            scrollpagedown();
            SendKeys(attributeName_id, FreightDesp_FirstItem_NMFC_Id, "34");
            SendKeys(attributeName_id, FreightDesp_FirstItem_Quantity_Id, "1");
            SendKeys(attributeName_id, FreightDesp_FirstItem_Weight_Id, "5");
            SendKeys(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id, "Description");
            SendKeys(attributeName_id, FreightDesp_FirstItem_Length_Id,"2");
            SendKeys(attributeName_id, FreightDesp_FirstItem_Width_Id,"4");
            SendKeys(attributeName_id, FreightDesp_FirstItem_Height_Id,"2");
            SendKeys(attributeName_id, InsuredValue_TextBox_Id, "16,000.00");
            Report.WriteLine("All the fields on Add Shipment page is editable");
        }
        
        [Then(@"I will see the shipment number displayed")]
        public void ThenIWillSeeTheShipmentNumberDisplayed()
        {
            scrollElementIntoView(attributeName_xpath, ShipmentNum_EditAddShipPage_Xpath);
            scrollPageup();
            Verifytext(attributeName_xpath, ShipmentNum_EditAddShipPage_Xpath, referenceNumber);
            Report.WriteLine("Shipment Number is displayed on edit shipment page");
        }

        [Then(@"I will see the shipment number displayed on Review and Shipment page")]
        public void ThenIWillSeeTheShipmentNumberDisplayedOnReviewAndShipmentPage()
        {
            Verifytext(attributeName_xpath, ShipmentNum_ReviewPage_EditAddShipPage_Xpath, referenceNumber);
            Report.WriteLine("Shipment Number is displayed on Review and Submit shipment page");

        }

        [Then(@"I will see a Shipment Number displayed on shipment results page")]
        public void ThenIWillSeeAShipmentNumberDisplayedOnShipmentResultsPage()
        {
            Verifytext(attributeName_xpath, ShipmentNum_Results_EditAddShipPage_Xpath, referenceNumber);
            Report.WriteLine("Shipment Number is displayed on edit shipment results page");

        }

        [Then(@"I will see verbiage indicating that the shipment is being edited")]
        public void ThenIWillSeeVerbiageIndicatingThatTheShipmentIsBeingEdited()
        {
            string getEditShipNum = Gettext(attributeName_xpath, ShipmentNum_EditAddShipPage_Xpath);
            string getEditShipVerbiage = Gettext(attributeName_xpath, ShipNumEditVerbiage_EditShipPage_Xpath);
            Assert.AreEqual(getEditShipNum + getEditShipVerbiage, referenceNumber + "Editing");
            Report.WriteLine("Verbiage indicating that the shipment is been edited is displayed");

        }

       [Then(@"I will see a Verbiage on Shipment Results page indicating that the shipment is being edited")]
        public void ThenIWillSeeAVerbiageOnShipmentResultsPageIndicatingThatTheShipmentIsBeingEdited()
        {
            string getEditShipNum = Gettext(attributeName_xpath, ShipmentNum_Results_EditAddShipPage_Xpath);
            string getEditShipVerbiage = Gettext(attributeName_xpath, ShipNumEditVerbiage_EditShipPage_Xpath);
            Assert.AreEqual(getEditShipNum + getEditShipVerbiage, referenceNumber + "Editing");
            Report.WriteLine("Verbiage indicating that the shipment is been edited is displayed on shipment results page");

        }

        [Then(@"I will see verbiage on Review and Submit page indicating that the shipment is being edited")]
        public void ThenIWillSeeVerbiageOnReviewAndSubmitPageIndicatingThatTheShipmentIsBeingEdited()
        {
            string getEditShipNum = Gettext(attributeName_xpath, ShipmentNum_ReviewPage_EditAddShipPage_Xpath);
            string getEditShipVerbiage = Gettext(attributeName_xpath, ShipNumEditVerbiage_EditShipPage_Xpath);
            Assert.AreEqual(getEditShipNum + getEditShipVerbiage, referenceNumber + "Editing");
            Report.WriteLine("Verbiage indicating that the shipment is been edited is displayed on Review and Submit page");

        }


        [Then(@"I am Unable to Select a date prior to the date of the original shipment")]
        public void ThenIAmUnableToSelectADatePriorToTheDateOfTheOriginalShipment()
        {
            PreviousDisabledDate(attributeName_xpath, LTLSelectingDates_Xpath, 3, "");
            Report.WriteLine("Unable to select a date prior to the date of the original shipment");
        }
        
        [Then(@"The Create Shipment button\(s\) will be renamed Update Shipment")]
        public void ThenTheCreateShipmentButtonSWillBeRenamedUpdateShipment()
        {
            VerifyElementPresent(attributeName_xpath, EditShipResult_UpdateStandardShip_Xpath, "Update Shipment");
            Verifytext(attributeName_xpath, EditShipResult_UpdateStandardShip_Xpath, "Update Shipment");
            Report.WriteLine("Create shipment button is renamed to Update Shipment");
        }
        
        [Then(@"The Create Insured Shipment button will be renamed Update Insured Shipment")]
        public void ThenTheCreateInsuredShipmentButtonWillBeRenamedUpdateInsuredShipment()
        {
            VerifyElementPresent(attributeName_xpath, EditShipResult_UpdateInsuredShip_Xpath, "Update Insured Shipment");
            Verifytext(attributeName_xpath, EditShipResult_UpdateInsuredShip_Xpath, "Update Insured Shipment*");
            Report.WriteLine("Create Insured shipment button is renamed to Update Insured Shipment");

        }

        [Then(@"I will arrive on the Review and Submit \(LTL\) page")]
        public void ThenIWillArriveOnTheReviewAndSubmitLTLPage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Verifytext(attributeName_xpath, ReviewAndSubmit_Title_Xpath, "Review and Submit Shipment (LTL)");
            Report.WriteLine("Navigated to Review and Submit (LTL) page");
        }
        
        [Then(@"The Submit Shipment button will be renamed to Submit Updated Shipment button")]
        public void ThenTheSubmitShipmentButtonWillBeRenamedToSubmitUpdatedShipmentButton()
        {
            scrollElementIntoView(attributeName_id, ReviewPage_SubmitButton_id);
            Verifytext(attributeName_id, ReviewPage_SubmitButton_id, "Submit Updated Shipment");
            Report.WriteLine("Submit Shipment button is renamed to Submit Updated Shipment button");
        }
        
        [Then(@"I have the option to update the shipment without carrier rates")]
        public void ThenIHaveTheOptionToUpdateTheShipmentWithoutCarrierRates()
        {
            VerifyElementPresent(attributeName_xpath, EditShipResult_NoRates_Xpath, "No Rates");
            Report.WriteLine("User has the option to update shipment without carrier rates");
           
        }

        [Then(@"Create Shipment without Carrier rate button will be renamed Update Shipment without Carrier rate button")]
        public void ThenCreateShipmentWithoutCarrierRateButtonWillBeRenamedUpdateShipmentWithoutCarrierRateButton()
        {
            Verifytext(attributeName_xpath, EditShipResult_NoRates_Xpath, "Update Shipment without Carrier Rate");
            Report.WriteLine("Create Shipment without Carrier rate button is renamed to Update Shipment without Carrier rate button");
        }

        [Then(@"I will not see the Verbiage (.*) on Shipment confirmation page")]
        public void ThenIWillNotSeeTheVerbiageOnShipmentConfirmationPage(string verbiage)
        {
            VerifyElementNotPresent(attributeName_xpath, EditShipConfirmationPage_Verbiage_Xpath, "Verbiage");
            Report.WriteLine("You will receive a confirmation email shortly with the Bill of Lading attached verbiage id not displayed on Shipment confirmation page");
        }

        public void CreateShipment()
        {
           
            HttpClient client = new HttpClient();
            string proxyApiUrl = ConfigurationManager.AppSettings["ProxyWebApiUrlVersion2"];
            string proxyUserName = ConfigurationManager.AppSettings["ProxyUserName"];
            string proxyApiKey = ConfigurationManager.AppSettings["ProxyApiKey"];
            client.Timeout = TimeSpan.FromSeconds(700000);
            client.BaseAddress = new Uri(proxyApiUrl);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("CustomerName", "ZZZ - GS Customer Test");
            client.DefaultRequestHeaders.Add("Username", proxyUserName);
            client.DefaultRequestHeaders.Add("apiKey", proxyApiKey);
            HttpResponseMessage response = client.PostAsync("Shipment/Import", new StringContent(
            new JavaScriptSerializer().Serialize(shipmentModel), Encoding.UTF8, "application/json")).Result;
            var responseString = response.Content.ReadAsStringAsync();
            var responseJson = JsonConvert.DeserializeObject<dynamic>(responseString.Result);
            if (responseJson != null)
            {
                referenceNumber = responseJson["PrimaryReference"];
            }

            refreshBrowser();
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_id, ShipmentList_SearchBox_Id, referenceNumber);
            Click(attributeName_xpath, ShipmentList_EditButton_ExternalUser_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
        }
    }
}
