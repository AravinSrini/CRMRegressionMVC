using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.Common;
using CRM.UITest.Helper.Implementations.ShipmentExtract;
using CRM.UITest.Helper.ViewModel;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.ShipmentList.ShipmentList_CopyLTLOption_AllUsers
{
    [Binding]
    public class ShipmentList_CopyLTLOptionCopyShipmentButton_StationAndEntryUsersSteps : AddShipments
    {
        CommonMethodsCrm crm = new CommonMethodsCrm();
        AddShipmentLTL ltl = new AddShipmentLTL();

        ShipmentExtractViewModel shipmentViewModels = null;
        

        [Given(@"I am a operations, sales, sales management, or station owner user - (.*),(.*)")]
        public void GivenIAmAOperationsSalesSalesManagementOrStationOwnerUser_(string Username, string Password)
        {
            crm.LoginToCRMApplication(Username, Password);
        }

        [When(@"I click on the Copy Shipment button - (.*)")]
        public void WhenIClickOnTheCopyShipmentButton_(string StationCustomerName)
        {
            Click(attributeName_xpath, ChooseCustomerType_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, ChooseCustomerTypeDropdownValues_Xpath, StationCustomerName);
            Thread.Sleep(90000);
            Report.WriteLine("Click on Copy Shipment button");            
            Click(attributeName_xpath, CopyIconFirst_AddShipmentList_Xpath);
            Thread.Sleep(2000);
            Click(attributeName_id, CopyShipmentConfirmButton_Id);
        }


     


        [When(@"I click on Copy Shipment button - (.*),(.*)")]
        public ShipmentExtractViewModel WhenIClickOnCopyShipmentButton_(string UserType, string CustomerName)
        {
            int shipmentlist = 0;
            Report.WriteLine("Clicking on copy shipment icon for LTL shipment");
            if (UserType == "Internal")
            {
                Click(attributeName_xpath, ShipmentList_Customer_dropdown_Xpath);

                IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_Customer_dropdownValue_Xpath));
                int DropDownCount = DropDownList.Count;
                for (int i = 0; i < DropDownCount; i++)
                {
                    if (DropDownList[i].Text == CustomerName)
                    {
                        DropDownList[i].Click();
                        break;
                    }
                }
                Thread.Sleep(90000);
                SendKeys(attributeName_id, ShipmentListSearchBox_Id, "LTL");
                shipmentlist = GetCount(attributeName_xpath, ShipmentList_TotalRecords_Xpath);
                if (shipmentlist > 1)
                {
                    string refNumber = Gettext(attributeName_xpath, Shipmentlist_FirstRow_RefColumn_Xpath);
                    Click(attributeName_xpath, CopyIconFirst_AddShipmentList_Xpath);
                    Thread.Sleep(5000);
                    Verifytext(attributeName_xpath, CopyShipment_ConfirmMessage_Xpath, "Copy the selected shipment and create a new shipment entry?");

                    string uri = $"MercuryGate/OidLookup";

                    //Building Client
                    BuildHttpClient client = new BuildHttpClient();
                    HttpClient headers = client.BuildHttpClientWithHeaders("Admin", "application/xml");

                    ShipmentExtract ext = new ShipmentExtract();
                    shipmentViewModels = ext.getShipmentData(uri, headers, refNumber, "Admin");
                }
                else
                {
                }
            }
            else
            {
                SendKeys(attributeName_id, ShipmentListSearchBox_Id, "LTL");
                shipmentlist = GetCount(attributeName_xpath, ShipmentList_TotalRecords_Xpath);
                if (shipmentlist > 1)
                {
                    string refNumber = Gettext(attributeName_xpath, Shipmentlist_FirstRow_RefColumn_Xpath);
                    Click(attributeName_xpath, CopyIconFirst_AddShipmentList_Xpath);
                    Thread.Sleep(50000);
                    Verifytext(attributeName_xpath, CopyShipment_ConfirmMessage_Xpath, "Copy the selected shipment and create a new shipment entry?");

                    string uri = $"MercuryGate/OidLookup";

                    //Building Client
                    BuildHttpClient client = new BuildHttpClient();
                    HttpClient headers = client.BuildHttpClientWithHeaders(CustomerName, "application/xml");

                    ShipmentExtract ext = new ShipmentExtract();
                    shipmentViewModels = ext.getShipmentData(uri, headers, refNumber, CustomerName);
                }
                else
                {

                }
            }
            return shipmentViewModels;
        }
      
        [When(@"I click on Copy Shipment confirmation button")]
        public void WhenIClickOnCopyShipmentConfirmationButton()
        {
            Report.WriteLine("Click on Copy Shipment button");
            Click(attributeName_id, CopyShipmentConfirmButton_Id);
        }

        [Then(@"I will arrive on the Add Shipment \(LTL\) page")]
        public void ThenIWillArriveOnTheAddShipmentLTLPage()
        {
            Report.WriteLine("Add Shipment page");
            Verifytext(attributeName_xpath, CopyAddShipmentTitle_Xpath, "Add Shipment (LTL)");
            Thread.Sleep(5000);
        }

        [Then(@"I will see the following fields auto-populated in ShipFrom section - Location name,Location address,Location address line (.*),Zip/postal code,Country,City,State/province")]
        public void ThenIWillSeeTheFollowingFieldsAuto_PopulatedInShipFromSection_LocationNameLocationAddressLocationAddressLineZipPostalCodeCountryCityStateProvince(int p0)
        {
            Report.WriteLine("Display of ShipFrom section");
            if (shipmentViewModels.AddressViewModels != null)
            {
                for (var i = 0; i < shipmentViewModels.AddressViewModels.Count; i++)
                {
                    if (shipmentViewModels.AddressViewModels[i].Type.ToLower() == "origin")
                    {
                        string originName = shipmentViewModels.AddressViewModels[i].Name;
                        string ActualOriginName = GetValue(attributeName_id, ShippingFrom_LocationName_Id, "value");
                        Assert.AreEqual(originName.ToUpper(), ActualOriginName.ToUpper());
                        Report.WriteLine("Displaying Origin name in UI " + ActualOriginName + "is matching with API shipping to value " + originName);

                        string OriginAddress = shipmentViewModels.AddressViewModels[i].AddressLine1;
                        string ActualOriginAddress = GetValue(attributeName_id, ShippingFrom_LocationAddressLine1_Id, "value");
                        Assert.AreEqual(OriginAddress.ToUpper(), ActualOriginAddress.ToUpper());
                        Report.WriteLine("Displaying Origin Address line 1 " + ActualOriginAddress + "is matching with API shipping From value " + OriginAddress);

                        string OriginAddress2 = shipmentViewModels.AddressViewModels[i].AddressLine2;
                        string ActualOriginAddress2 = GetValue(attributeName_id, ShippingFrom_LocationAddressLine2_Id, "value");
                        Assert.AreEqual(OriginAddress2.ToUpper(), ActualOriginAddress2.ToUpper());
                        Report.WriteLine("Displaying Origin Address line 2 " + ActualOriginAddress2 + "is matching with API shipping From value " + OriginAddress2);

                        string OriginZipOrPostal = shipmentViewModels.AddressViewModels[i].PostalCode;
                        string ActualOriginZipOrPostal = GetValue(attributeName_id, ShippingFrom_zipcode_Id, "value");
                        Assert.AreEqual(OriginZipOrPostal.ToUpper(), ActualOriginZipOrPostal.ToUpper());
                        Report.WriteLine("Displaying Origin Zip Or Postal " + ActualOriginZipOrPostal + "is matching with API shipping From value " + OriginZipOrPostal);

                        string OriginCountry = shipmentViewModels.AddressViewModels[i].CountryCode;
                        if(OriginCountry == "USA")
                        {
                            string ActualOriginCountry = Gettext(attributeName_xpath, ShippingFrom_CountryDropDown_xpath);
                            Assert.AreEqual(ActualOriginCountry, "United States");
                            Report.WriteLine("Displaying Origin Country " + ActualOriginCountry + "is matching with API shipping From value " + OriginCountry);
                        }
                        else
                        {
                            string ActualOriginCountry = Gettext(attributeName_xpath, ShippingFrom_CountryDropDown_xpath);
                            Assert.AreEqual(ActualOriginCountry, "Cananda");
                            Report.WriteLine("Displaying Origin Country " + ActualOriginCountry + "is matching with API shipping From value " + OriginCountry);

                        }

                        string OriginCity = shipmentViewModels.AddressViewModels[i].City;
                        string ActualOriginCity = GetValue(attributeName_id, ShippingFrom_City_Id, "value");
                        Assert.AreEqual(OriginCity.ToUpper(), ActualOriginCity.ToUpper());
                        Report.WriteLine("Displaying Origin City " + ActualOriginCity + "is matching with API shipping From value " + OriginCity);

                        string OriginStateOrProvince = shipmentViewModels.AddressViewModels[i].StateProvince;
                        string ActualOriginStateOrProvince = Gettext(attributeName_xpath, ShippingFrom_StateDropdwon_xpath);
                        Assert.AreEqual(OriginStateOrProvince.ToUpper(), ActualOriginStateOrProvince.ToUpper());
                        Report.WriteLine("Displaying Origin State or Province " + ActualOriginStateOrProvince + "is matching with API shipping From value " + OriginStateOrProvince);
                    }
                }

            }
        }

        [Then(@"I will see the following fields auto-populated in ShipTo section - Destination name,Destination address,Destination address line (.*),Zip/postal code,Country,City,State/province")]
        public void ThenIWillSeeTheFollowingFieldsAuto_PopulatedInShipToSection_DestinationNameDestinationAddressDestinationAddressLineZipPostalCodeCountryCityStateProvince(int p0)
        {
            Thread.Sleep(5000);
            Report.WriteLine("Display of ShipTo section");
            if (shipmentViewModels.AddressViewModels != null)
            {
                for (var i = 0; i < shipmentViewModels.AddressViewModels.Count; i++)
                {
                    if (shipmentViewModels.AddressViewModels[i].Type.ToLower() == "destination")
                    {
                        string DesName = shipmentViewModels.AddressViewModels[i].Name;
                        string ActualDesName = GetValue(attributeName_id, ShippingTo_LocationName_Id, "value");
                        Assert.AreEqual(DesName.ToUpper(), ActualDesName.ToUpper());
                        Report.WriteLine("Displaying Destination name in UI " + ActualDesName + "is matching with API shipping to value " + DesName);

                        string DesAddress = shipmentViewModels.AddressViewModels[i].AddressLine1;
                        string ActualDesAddress = GetValue(attributeName_id, ShippingTo_LocationAddressLine1_Id, "value");
                        Assert.AreEqual(DesAddress.ToUpper(), ActualDesAddress.ToUpper());
                        Report.WriteLine("Displaying Destination Address line 1 " + ActualDesAddress + "is matching with API shipping From value " + DesAddress);

                        string DesAddress2 = shipmentViewModels.AddressViewModels[i].AddressLine2;
                        string ActualDesAddress2 = GetValue(attributeName_id, ShippingTo_LocationAddressLine2_Id, "value");
                        Assert.AreEqual(DesAddress2.ToUpper(), ActualDesAddress2.ToUpper());
                        Report.WriteLine("Displaying Destination Address line 2 " + ActualDesAddress2 + "is matching with API shipping From value " + DesAddress2);

                        string DesZipOrPostal = shipmentViewModels.AddressViewModels[i].PostalCode;
                        string ActualDesZipOrPostal = GetValue(attributeName_id, ShippingTo_zipcode_Id, "value");
                        Assert.AreEqual(DesZipOrPostal.ToUpper(), ActualDesZipOrPostal.ToUpper());
                        Report.WriteLine("Displaying Destination Zip Or Postal " + ActualDesZipOrPostal + "is matching with API shipping From value " + DesZipOrPostal);

                        string DesCountry = shipmentViewModels.AddressViewModels[i].CountryCode;
                        if (DesCountry == "USA")
                        {
                            string ActualDesCountry = Gettext(attributeName_xpath, ShippingTo_CountryDropDown_xpath);
                            Assert.AreEqual(ActualDesCountry, "United States");
                            Report.WriteLine("Displaying Destination Country " + ActualDesCountry + "is matching with API shipping From value " + DesCountry);
                        }
                        else
                        {
                            string ActualDesCountry = Gettext(attributeName_xpath, ShippingTo_CountryDropDown_xpath);
                            Assert.AreEqual(ActualDesCountry, "Canada");
                            Report.WriteLine("Displaying Destination Country " + ActualDesCountry + "is matching with API shipping From value " + DesCountry);

                        }
                        string DesCity = shipmentViewModels.AddressViewModels[i].City;
                        string ActualDesCity = GetValue(attributeName_id, ShippingTo_City_Id, "value");
                        Assert.AreEqual(DesCity.ToUpper(), ActualDesCity.ToUpper());
                        Report.WriteLine("Displaying Destination City " + ActualDesCity + "is matching with API shipping From value " + DesCity);

                        string DesStateOrProvince = shipmentViewModels.AddressViewModels[i].StateProvince;
                        string ActualDesStateOrProvince = Gettext(attributeName_xpath, ShippingTo_StateDropdwon_xpath);
                        Assert.AreEqual(DesStateOrProvince.ToUpper(), ActualDesStateOrProvince.ToUpper());
                        Report.WriteLine("Displaying Destination State or Province " + ActualDesStateOrProvince + "is matching with API shipping From value " + DesStateOrProvince);
                    }
                }

            }
        }

        [Then(@"I will see PickUp date section auto-populated to default date and default time - PickUpDate,ReadyTime,CloseTime")]
        public void ThenIWillSeePickUpDateSectionAuto_PopulatedToDefaultDateAndDefaultTime_PickUpDateReadyTimeCloseTime()
        {
            Thread.Sleep(5000);
            Report.WriteLine("Default PickUp Date");
            scrollpagedown();
            VerifyElementVisible(attributeName_xpath, PickUpDate_Xpath, "PickUp Date");
            DateTime today = DateTime.Today;
            string s_today = today.ToString("MM/dd/yyyy");
            var PickupDate_UI = GetAttribute(attributeName_id, LTL_PickUpDate_Id, "value");
            Assert.AreEqual(PickupDate_UI, s_today);

            Thread.Sleep(5000);
            Report.WriteLine("Default Ready Time");
            string ReadyTime = Gettext(attributeName_xpath, LTL_PickUpReadyTime_Xpath);
            Assert.AreEqual(ReadyTime, "Ready 8:00 AM");
            string CloseTime = Gettext(attributeName_xpath, LTL_PickUpCloseTime_Xpath);
            Assert.AreEqual(CloseTime, "Close 5:00 PM");
        }

        [Then(@"I will see the following fields auto-populated in the Freight description section - Class,NMFC,Quantity,QuantityType,ItemDescription,Weight,WeightType,HMaterials,DLength,DWidth,DHeight,DType")]
        public void ThenIWillSeeTheFollowingFieldsAuto_PopulatedInTheFreightDescriptionSection_ClassNMFCQuantityQuantityTypeItemDescriptionWeightWeightTypeHMaterialsDLengthDWidthDHeightDType()
        {
            Thread.Sleep(5000);
            if (shipmentViewModels.ItemViewModels != null)
            {
                for (var i = 0; i < shipmentViewModels.ItemViewModels.Count; i++)
                {
                    string Class = shipmentViewModels.ItemViewModels[i].Classification;                   
                    string [] Classi = Class.Split('.');
                    string classification = Classi[0];
                    string ActualClass = GetValue(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id, "value");
                    Assert.AreEqual(classification, ActualClass);

                    string NMFC = shipmentViewModels.ItemViewModels[i].NmfcCode;
                    string ActualNMFC = GetValue(attributeName_id, FreightDesp_FirstItem_NMFC_Id, "value");
                    Assert.AreEqual(NMFC, ActualNMFC);

                    string Quantity = shipmentViewModels.ItemViewModels[i].Quantity;
                    string [] Quan = Quantity.Split('.');
                    string QuantityAPI = Quan[0];
                    string ActualQuantity = GetValue(attributeName_id, FreightDesp_FirstItem_Quantity_Id, "value");
                    Assert.AreEqual(QuantityAPI, ActualQuantity);

                    string QuanType = shipmentViewModels.ItemViewModels[i].QuantityUnit;
                    string ActualQuanType = Gettext(attributeName_xpath, FreightDesp_FirstItem_QuantityType_xpath);
                    GetQuantityType val = new GetQuantityType();
                    string ExpQuantityType = val.Getquantity(QuanType);
                    Assert.AreEqual(ExpQuantityType, ActualQuanType);

                    string ItemDescription = shipmentViewModels.ItemViewModels[i].ItemDescription;
                    string ActualItemDescription = GetValue(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id, "value");
                    Assert.AreEqual(ItemDescription, ActualItemDescription);

                    string Weight = shipmentViewModels.ItemViewModels[i].Weight;
                    string[] weight = Quantity.Split('.');
                    string weightAPI = weight[0];
                    string ActualWeight = GetValue(attributeName_id, FreightDesp_FirstItem_Weight_Id, "value");
                    Assert.AreEqual(weightAPI, ActualWeight);

                    string WeightType = shipmentViewModels.ItemViewModels[i].WeightUnit;
                    string ActualWeightType = Gettext(attributeName_xpath, FreightDesp_FirstItem_WeightType_xpath);
                    GetWeightType vals = new GetWeightType();
                    string ExpWeightType = vals.GetWeight(WeightType);
                    Assert.AreEqual(ExpWeightType, ActualWeightType);

                    bool Hazardous = shipmentViewModels.ItemViewModels[i].IsHazardous;
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

                    string DLength = shipmentViewModels.ItemViewModels[i].Length;
                    string[] dLength = DLength.Split('.');
                    string dLengthtAPI = dLength[0];
                    string ActualDLength = GetValue(attributeName_id, FreightDesp_FirstItem_Length_Id, "value");
                    Assert.AreEqual(dLengthtAPI, ActualDLength);

                    string DWidth = shipmentViewModels.ItemViewModels[i].Width;
                    string[] dWidth = DWidth.Split('.');
                    string dWidthAPI = dWidth[0];
                    string ActualWidth = GetValue(attributeName_id, FreightDesp_FirstItem_Width_Id, "value");
                    Assert.AreEqual(dWidthAPI, ActualWidth);

                    string DHeight = shipmentViewModels.ItemViewModels[i].Height;
                    string[] dHeight = DHeight.Split('.');
                    string dHeightAPI = dHeight[0];
                    string ActualHeight = GetValue(attributeName_id, FreightDesp_FirstItem_Height_Id, "value");
                    Assert.AreEqual(dHeightAPI, ActualHeight);

                    string DType = shipmentViewModels.ItemViewModels[i].DimensionUnit;
                    string DTypeVal = DType.ToUpper();
                    string ActualDType = Gettext(attributeName_xpath, FreightDesp_FirstItem_DimensionType_xpath);
                    Assert.AreEqual(DTypeVal, ActualDType);
                }
            }
        
        }

        [Then(@"I will see the following fields auto-populated in the Reference Number Section - DefaultSpecialInstruction,InsuredValue,InsuredValueType - '(.*)'")]
        public void ThenIWillSeeTheFollowingFieldsAuto_PopulatedInTheReferenceNumberSection_DefaultSpecialInstructionInsuredValueInsuredValueType_(string CustomerName)
        {
            Thread.Sleep(5000);
            Report.WriteLine("Display of Reference Number section");
            scrollpagedown();
            scrollpagedown();
            int accId = DBHelper.GetAccountIdforAccountName(CustomerName);
            CustomerAccount accvalue = DBHelper.GetAccountDetails(accId);
            string actSpcInst = GetValue(attributeName_id, DefaultSpecialIntructions_Comments_Id, "value");
            Assert.AreEqual(accvalue.SpecialInstructions, actSpcInst);

            if (shipmentViewModels.ItemViewModels != null)
            {
                for (var i = 0; i < shipmentViewModels.ItemViewModels.Count; i++)
                {
                    string InsuredValue = shipmentViewModels.ItemViewModels[i].DollarValue;
                    string ActualInsuredValue = GetValue(attributeName_id, InsuredValue_TextBox_Id, "value");
                    Assert.AreEqual(InsuredValue, ActualInsuredValue);
                    if (shipmentViewModels.ReferenceNumbers != null)
                    {
                        for (var j = 0; j < shipmentViewModels.ReferenceNumbers.Count; j++)
                        {
                            if (shipmentViewModels.ReferenceNumbers[j].Type == "InsuredType")
                            {
                                string InsuredType = shipmentViewModels.ReferenceNumbers[j].ReferenceNumber;
                                string ActualInsuredType = Gettext(attributeName_xpath, InsuredValue_TypeLabel_Xpath);
                                Assert.AreEqual(InsuredType, ActualInsuredType);
                            }
                        }
                    }
                    else
                    {
                        Report.WriteLine("No Response");
                    }
                }
            }
            else
            {
                Report.WriteLine("No Response");
            }
          
        }

      
        [Then(@"I will see the following fields auto-populated for the Additional Items section - Class,NMFC,Quantity,QuantityType,ItemDescription,Weight,WeightType,HMaterials,DLength,DWidth,DHeight,DType")]
        public void ThenIWillSeeTheFollowingFieldsAuto_PopulatedForTheAdditionalItemsSection_ClassNMFCQuantityQuantityTypeItemDescriptionWeightWeightTypeHMaterialsDLengthDWidthDHeightDType()
        {
           
            try
            {
                scrollpagedown();
                scrollpagedown();
                VerifyElementPresent(attributeName_id, Freight_secondClearButton_Id, "Clear");
                if (shipmentViewModels.ItemViewModels != null && shipmentViewModels.ItemViewModels.Count > 1)
                {
                    for (var i = 0; i < shipmentViewModels.ItemViewModels.Count; i++)
                    {
                        string itemDesc = shipmentViewModels.ItemViewModels[i].ItemDescription;
                        string ActualItemDescription = GetValue(attributeName_id, AddAdditionalDesc_Id, "value");

                        if (ActualItemDescription == itemDesc)
                        {
                            string Class = shipmentViewModels.ItemViewModels[i].Classification;
                            string[] Classi = Class.Split('.');
                            string classification = Classi[0];
                            string ActualClass = GetValue(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id, "value");
                            Assert.AreEqual(classification, ActualClass);

                            string NMFC = shipmentViewModels.ItemViewModels[i].NmfcCode;
                            string ActualNMFC = GetValue(attributeName_id, AddAdditionalNmfc_Id, "value");
                            Assert.AreEqual(NMFC, ActualNMFC);

                            string Quantity = shipmentViewModels.ItemViewModels[i].Quantity;
                            string[] Quan = Quantity.Split('.');
                            string QuantityAPI = Quan[0];
                            string ActualQuantity = GetValue(attributeName_id, FreightDesp_FirstItem_Quantity_Id, "value");
                            Assert.AreEqual(QuantityAPI, ActualQuantity);

                            string QuanType = shipmentViewModels.ItemViewModels[i].QuantityUnit;
                            string ActualQuanType = Gettext(attributeName_xpath, AddAdditionalQunatityType_Xpath);
                            GetQuantityType val = new GetQuantityType();
                            string ExpQuantityType = val.Getquantity(QuanType);
                            Assert.AreEqual(ActualQuanType, ExpQuantityType);

                            string Weight = shipmentViewModels.ItemViewModels[i].Weight;
                            string ActualWeight = GetValue(attributeName_id, AddAdditionalWeight_Id, "value");
                            Assert.AreEqual(Weight, ActualWeight);

                            string WeightType = shipmentViewModels.ItemViewModels[i].WeightUnit;
                            string ActualWeightType = Gettext(attributeName_xpath, AddAdditionalWeightType_Xpath);
                            GetWeightType vals = new GetWeightType();
                            string ExpWeightType = vals.GetWeight(WeightType);
                            Assert.AreEqual(ExpWeightType, ActualWeightType);


                            bool Hazardous = shipmentViewModels.ItemViewModels[i].IsHazardous;
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

                            string DLength = shipmentViewModels.ItemViewModels[i].Length;
                            string ActualDLength = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_Length_Id, "value");
                            Assert.AreEqual(DLength, ActualDLength);

                            string DWidth = shipmentViewModels.ItemViewModels[i].Width;
                            string ActualWidth = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_Width_Id, "value");
                            Assert.AreEqual(DWidth, ActualWidth);

                            string DHeight = shipmentViewModels.ItemViewModels[i].Height;
                            string ActualHeight = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_Height_Id, "value");
                            Assert.AreEqual(DHeight, ActualHeight);

                            string DType = shipmentViewModels.ItemViewModels[i].DimensionUnit;
                            string DTypeVal = DType.ToUpper();
                            string ActualDType = Gettext(attributeName_xpath, FreightDesp_First_AdditionalItem_DimensionType_xpath);
                            Assert.AreEqual(DTypeVal, ActualDType);
                        }
                    }
                }
                else
                {
                    Report.WriteFailure("No API Response");
                }
            }
            catch(Exception)
            {
                Thread.Sleep(50000);
                Report.WriteLine("Add Additional Items does not exists");
                              
            } 
              
           
        }



        [Then(@"I will see the following fields auto-populated for Additional Items section - (.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void ThenIWillSeeTheFollowingFieldsAuto_PopulatedForAdditionalItemsSection_(string p0, string p1, string p2, string p3, string p4, string p5, string p6, string p7, string p8, string p9, string p10, string p11)
        {
            ScenarioContext.Current.Pending();
        }
        [Then(@"The station name - customer name associated to shipment selected will be displayed - (.*)")]
        public void ThenTheStationName_CustomerNameAssociatedToShipmentSelectedWillBeDisplayed_(string StationCustomerName)
        {
            Report.WriteLine("Station name and Customer name display");
            string StationCusNameUI = Gettext(attributeName_id, CopyAddShipment_StationAndCustomerName_Id);
            if (StationCusNameUI.Contains(StationCustomerName.ToUpper()))
            {
                Report.WriteLine("Station Name and Customer Name associated to the shipment selected are displayed");
            }
            else
            {
                Report.WriteFailure("Station Name and Customer Name associated to the shipment selected are not displayed");
            }
        }

        //Edit Shipment

        [When(@"I click on the Edit button for any eligible LTL shipment (.*),(.*)")]
        public ShipmentExtractViewModel WhenIClickOnTheEditButtonForAnyEligibleLTLShipment(string UserType, string CustomerName)
        {
            int shipmentlist = 0;
            if (UserType == "Internal")
            {
                Click(attributeName_xpath, ShipmentList_Customer_dropdown_Xpath);

                IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_Customer_dropdownValue_Xpath));
                int DropDownCount = DropDownList.Count;
                for (int i = 0; i < DropDownCount; i++)
                {
                    if (DropDownList[i].Text == CustomerName)
                    {
                        DropDownList[i].Click();
                        break;
                    }
                }
                Thread.Sleep(90000);
                SendKeys(attributeName_id, ShipmentListSearchBox_Id, "LTL");
                shipmentlist = GetCount(attributeName_xpath, ShipmentList_TotalRecords_Xpath);
                if (shipmentlist > 1)
                {
                    string refNumber = Gettext(attributeName_xpath, Shipmentlist_FirstRow_RefColumn_Xpath);
                    Click(attributeName_xpath, ".//*[@id='ShipmentGrid']/tbody/tr[1]/td[10]/button");
                    string uri = $"MercuryGate/OidLookup";

                    //Building Client

                    BuildHttpClient client = new BuildHttpClient();
                    HttpClient headers = client.BuildHttpClientWithHeaders(CustomerName, "application/xml");

                    ShipmentExtract ext = new ShipmentExtract();

                    shipmentViewModels = ext.getShipmentData(uri, headers, refNumber, CustomerName);


                }

            }
            return shipmentViewModels;
        }


        [Then(@"Shipping From Contact Info section will be collapsed, if shipment did not contain any Shipping From Contact Info")]
        public void ThenShippingFromContactInfoSectionWillBeCollapsedIfShipmentDidNotContainAnyShippingFromContactInfo()
        {
            scrollpagedown();
            for (var i = 0; i < shipmentViewModels.ContactViewModels.Count; i++)
            {
                if (shipmentViewModels.ContactViewModels[i].ContactType.ToLower() == "origin")
                {
                    if (shipmentViewModels.ContactViewModels[i].Name == string.Empty && shipmentViewModels.ContactViewModels[i].Phone == string.Empty && shipmentViewModels.ContactViewModels[i].Email == string.Empty && shipmentViewModels.ContactViewModels[i].Fax == string.Empty)
                    {
                        VerifyElementNotVisible(attributeName_id, ShippingFrom_ContactName_Id, "Contact Fields");
                    }
                    else
                    {
                        Report.WriteLine("Unable to verify the shipping from contact collapse functionality as shipment has contact info");
                    }
                }
            }
        }


        [Then(@"Shipping To Contact Info section will be collapsed , if shipment did not contain any Shipping From Contact Info")]
        public void ThenShippingToContactInfoSectionWillBeCollapsedIfShipmentDidNotContainAnyShippingFromContactInfo()
        {
            for (var i = 0; i < shipmentViewModels.ContactViewModels.Count; i++)
            {
                if (shipmentViewModels.ContactViewModels[i].ContactType.ToLower() == "destination")
                {
                    if (shipmentViewModels.ContactViewModels[i].Name == string.Empty && shipmentViewModels.ContactViewModels[i].Phone == string.Empty && shipmentViewModels.ContactViewModels[i].Email == string.Empty && shipmentViewModels.ContactViewModels[i].Fax == string.Empty)
                    {
                        VerifyElementNotVisible(attributeName_id, ShippingTo_ContactName_Id, "Contact Fields");
                    }
                    else
                    {
                        Report.WriteLine("Unable to verify the shipping to contact collapse functionality as shipment has contact info");
                    }
                }
            }
        }

        [Then(@"Shipping From Contact Info section will be expanded")]
        public void ThenShippingFromContactInfoSectionWillBeExpanded()
        {
            scrollpagedown();
            if (shipmentViewModels.ContactViewModels != null)
            {
                for (var i = 0; i < shipmentViewModels.ContactViewModels.Count; i++)
                {
                    string ShipFromContactName = shipmentViewModels.ContactViewModels[i].Name;
                    if (ShipFromContactName == string.Empty)
                    {
                        VerifyElementNotVisible(attributeName_id, ShippingFrom_ContactName_Id, "ContactName");
                        Report.WriteLine("ShipFrom Contact section does not contain information hence the section is collaped");
                        break;
                    }
                    else
                    {
                        VerifyElementPresent(attributeName_id, ShippingFrom_ContactName_Id, "ContactName");
                        Report.WriteLine("ShipFrom Contact section contains information hence the section is expanded");

                    }

                }
            }
        }

        [Then(@"fields are auto populated with values from original shipment in ShipFrom Contact section")]
        public void ThenFieldsAreAutoPopulatedWithValuesFromOriginalShipmentInShipFromContactSection()
        {
            Report.WriteLine("ShipFrom Contact Section Values");
            try
            {
                if (shipmentViewModels.ContactViewModels != null)
                {
                    for (var i = 0; i < shipmentViewModels.ContactViewModels.Count; i++)
                    {
                        string ShipFromContactName = shipmentViewModels.ContactViewModels[i].Name;
                        VerifyElementPresent(attributeName_id, ShippingFrom_ContactName_Id, "ContactName");
                        string ShipFromNameUI = GetValue(attributeName_id, ShippingFrom_ContactName_Id, "value");
                        Assert.AreEqual(ShipFromContactName.ToUpper(), ShipFromNameUI.ToUpper());

                        string ShipFromContactPhone = shipmentViewModels.ContactViewModels[i].Phone;
                        string ShipFromPhoneUI = GetValue(attributeName_id, ShippingFrom_ContactPhone_Id, "value");
                        Assert.AreEqual(ShipFromContactPhone, ShipFromPhoneUI);

                        string ShipFromContactEmail = shipmentViewModels.ContactViewModels[i].Email;
                        string ShipFromEmailUI = GetValue(attributeName_id, ShippingFrom_ContactEmail_Id, "value");
                        Assert.AreEqual(ShipFromContactEmail, ShipFromEmailUI);

                        string ShipFromConatctFax = shipmentViewModels.ContactViewModels[i].Fax;
                        string ShipFromFax = GetValue(attributeName_id, ShippingFrom_ContactFax_Id, "value");
                        Assert.AreEqual(ShipFromConatctFax, ShipFromFax);
                    }
                }
                else
                {
                    Report.WriteFailure("No Response");
                }
            }
            catch (Exception)
            {
                Thread.Sleep(2000);
                Report.WriteLine("ShipFrom contact section deos not contain Information");
            }
        }



    }
}
