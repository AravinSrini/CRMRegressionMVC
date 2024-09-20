using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.Common;
using CRM.UITest.Helper.DataModels;
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

namespace CRM.UITest.Scripts.Shipment.ShipmentList.ShipmentList_ReturnShipment
{
    [Binding]
    public class ShipmentList_ReturnShipmentSteps : AddShipments
    {
        ShipmentExtractViewModel shipmentViewModels = null;
        AddShipmentLTL ship = new AddShipmentLTL();
        GetQuantityType qType = new GetQuantityType();
        GetWeightType wType = new GetWeightType();

        [Given(@"I am on the Shipment List page,")]
        public void GivenIAmOnTheShipmentListPage()
        {
            ship.NaviagteToShipmentList();
        }

        [Given(@"I have clicked on the Return Shipment button of an LTL shipment (.*) (.*)")]
        public ShipmentExtractViewModel GivenIHaveClickedOnTheReturnShipmentButtonOfAnLTLShipment(string custAcc, string userType)
        {
            int shipmentlist = 0;
            Report.WriteLine("Clicking on return shipment icon for LTL shipment");
            if (userType == "Internal")
            {
                Click(attributeName_xpath, ShipmentList_Customer_dropdown_Xpath);

                IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_Customer_dropdownValue_Xpath));
                int DropDownCount = DropDownList.Count;
                for (int i = 0; i < DropDownCount; i++)
                {
                    if (DropDownList[i].Text == custAcc)
                    {
                        DropDownList[i].Click();
                        break;
                    }
                }
                Thread.Sleep(500);
                WaitForElementNotVisible(attributeName_xpath, ShipmentListGrid_CustomerloadingIcon_Xpath, "Loading Icon");
                SendKeys(attributeName_id, ShipmentListSearchBox_Id, "LTL");
                shipmentlist = GetCount(attributeName_xpath, ShipmentList_TotalRecords_Xpath);
                if (shipmentlist > 1)
                {
                    string refNumber = Gettext(attributeName_xpath, Shipmentlist_FirstRow_RefColumn_Xpath);
                    Click(attributeName_xpath, ShipmentListGrid_AllUsers_ReturnIcon_Xpath);
                    WaitForElementVisible(attributeName_xpath, ShipmentList_ReturnShipmentHeaderText_xpath, "Return Shipment");
                    Verifytext(attributeName_xpath, ShipmentList_ReturnShipmentHeaderText_xpath, "Create Return Shipment");

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
                        Click(attributeName_xpath, ShipmentListGrid_AllUsers_ReturnIcon_Xpath);
                        WaitForElementVisible(attributeName_xpath, ShipmentList_ReturnShipmentHeaderText_xpath, "Return Shipment");
                        Verifytext(attributeName_xpath, ShipmentList_ReturnShipmentHeaderText_xpath, "Create Return Shipment");

                        string uri = $"MercuryGate/OidLookup";

                        //Building Client
                        BuildHttpClient client = new BuildHttpClient();
                        HttpClient headers = client.BuildHttpClientWithHeaders(custAcc, "application/xml");

                        ShipmentExtract ext = new ShipmentExtract();
                        shipmentViewModels = ext.getShipmentData(uri, headers, refNumber, custAcc);
                    }
                    else
                    {

                    }
                }           
            return shipmentViewModels;
        }           
        
        [Given(@"I clicked on the Yes button in the return shipment popup box,")]
        public void GivenIClickedOnTheYesButtonInTheReturnShipmentPopupBox()
        {
            WaitForElementVisible(attributeName_xpath, ShipmentList_ReturnShipment_Yes_Xpath, "Return shipment yes button");
            Report.WriteLine("Clicking on yes for return shipment icon for LTL shipment");
            Click(attributeName_xpath, ShipmentList_ReturnShipment_Yes_Xpath);
        }

        [Then(@"the Hazardous Materials section will be expanded, if the shipment contained hazardous materials")]
        public void ThenTheHazardousMaterialsSectionWillBeExpandedIfTheShipmentContainedHazardousMaterials()
        {
            if (shipmentViewModels.ItemViewModels != null)
            {
                for (var i = 0; i < shipmentViewModels.ItemViewModels.Count; i++)
                {
                    string itemDesc = shipmentViewModels.ItemViewModels[i].ItemDescription;
                    string ActualDesc = GetValue(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id, "value");

                    if (ActualDesc == itemDesc)
                    {
                        bool hazMatValue = shipmentViewModels.ItemViewModels[i].IsHazardous;
                        if (hazMatValue == true)
                        {
                            VerifyElementVisible(attributeName_id, FreightDesp_FirstItem_UN_Number_Id, "UNNumber");
                        }
                        else
                        {
                            Report.WriteLine("Unable to verify the hazmat edit funcitonality as selectedshipment does not contain hazmat details");
                        }
                    }
                }
            }
        }

        
        [When(@"I click on the Yes button in the return shipment popup box,")]
        public void WhenIClickOnTheYesButtonInTheReturnShipmentPopupBox()
        {
            Report.WriteLine("Clicking on yes for return shipment icon for LTL shipment");
            Click(attributeName_xpath, ShipmentList_ReturnShipment_Yes_Xpath);
        }
        
        [When(@"I arrive on the Add Shipment \(LTL\) page,")]
        public void WhenIArriveOnTheAddShipmentLTLPage()
        {
            Report.WriteLine("Verifying the navigation to add shipment LTL page");
            WaitForElementVisible(attributeName_xpath, AddShipment_PageTitle_xpath, "Add Shipment LTL page");
        }
        
        [Then(@"I will arrive on the Add Shipment \(LTL\) page,")]
        public void ThenIWillArriveOnTheAddShipmentLTLPage()
        {
            Report.WriteLine("Verifying the navigation to add shipment LTL page");
            WaitForElementVisible(attributeName_xpath, AddShipment_PageTitle_xpath, "Add Shipment LTL page");
        }
        
        [Then(@"I will see Shipping From section Location name,Location address, Location address line (.*), Zip/postal code, Country, City, State/province  populated with Shipping To details of the original shipment")]
        public void ThenIWillSeeShippingFromSectionLocationNameLocationAddressLocationAddressLineZipPostalCodeCountryCityStateProvincePopulatedWithShippingToDetailsOfTheOriginalShipment(int p0)
        {
            if (shipmentViewModels.AddressViewModels != null)
            {
                for (var i = 0; i < shipmentViewModels.AddressViewModels.Count; i++)
                {
                    if (shipmentViewModels.AddressViewModels[i].Type.ToLower() == "destination")
                    {
                        string originName = shipmentViewModels.AddressViewModels[i].Name;
                        string ActualOriginName = GetValue(attributeName_id, ShippingFrom_LocationName_Id, "value");
                        Assert.AreEqual(originName.ToUpper(), ActualOriginName.ToUpper());
                        Report.WriteLine("Displaying Origin name in UI " + ActualOriginName + "is matching with API shipping to value " + originName);

                        string originAdd = shipmentViewModels.AddressViewModels[i].AddressLine1;
                        string ActOriginAdd = GetValue(attributeName_id, ShippingFrom_LocationAddressLine1_Id, "value");
                        Assert.AreEqual(originAdd.ToUpper(), ActOriginAdd.ToUpper());
                        Report.WriteLine("Displaying Origin address in UI " + ActOriginAdd + "is matching with API shipping to value " + originAdd);

                        string originAdd1 = shipmentViewModels.AddressViewModels[i].AddressLine2;
                        string ActualOriginAdd1 = GetValue(attributeName_id, ShippingFrom_LocationAddressLine2_Id, "value");
                        Assert.AreEqual(originAdd1.ToUpper(), ActualOriginAdd1.ToUpper());
                        Report.WriteLine("Displaying Origin name in UI " + ActualOriginAdd1 + "is matching with API shipping to value " + originAdd1);

                        string originCity = shipmentViewModels.AddressViewModels[i].City;
                        var ActualOriginCity = GetValue(attributeName_id, ShippingFrom_City_Id, "value");
                        Assert.AreEqual(originCity.ToUpper(), ActualOriginCity.ToUpper());
                        Report.WriteLine("Displaying Origin city in UI " + ActualOriginCity + "is matching with API shipping to value " + originCity);

                        string originState = shipmentViewModels.AddressViewModels[i].StateProvince;
                        string ActualOriginState = Gettext(attributeName_xpath, ShippingFrom_StateDropdwon_SelectedValue_xpath);
                        Assert.AreEqual(originState, ActualOriginState);
                        Report.WriteLine("Displaying Origin state/province in UI " + ActualOriginState + "is matching with API shipping to value " + originState);

                        string originZipCode = shipmentViewModels.AddressViewModels[i].PostalCode;
                        string ActualOriginZipCode = GetValue(attributeName_id, ShippingFrom_zipcode_Id, "value");
                        Assert.AreEqual(originZipCode.ToUpper(), originZipCode.ToUpper());
                        Report.WriteLine("Displaying Origin zip/postal in UI " + ActualOriginZipCode + "is matching with API shipping to value " + originZipCode);

                        string originCountry = shipmentViewModels.AddressViewModels[i].CountryCode;
                        string ActualOriginCountry = Gettext(attributeName_xpath, ShippingFrom_CountryDropDown_SelectedValue_xpath);
                        if (originCountry == "USA")
                        {
                            Assert.AreEqual("United States", ActualOriginCountry);
                        }
                        else
                        {
                            Assert.AreEqual("Canada".ToUpper(), ActualOriginCountry.ToUpper());
                        }
                        Report.WriteLine("Displaying Origin Country in UI " + ActualOriginCountry + "is matching with API value" + originCountry);
                    }
                  }
                }
                else
                {
                    Report.WriteLine("Address data didnt retrun from API");
                    Assert.IsTrue(false);
                }
            }


        [Then(@"I will see Shipping to section Location name,Location address, Location address line (.*), Zip/postal code, Country, City, State/province  populated with Shipping from details of the original shipment")]
        public void ThenIWillSeeShippingToSectionLocationNameLocationAddressLocationAddressLineZipPostalCodeCountryCityStateProvincePopulatedWithShippingFromDetailsOfTheOriginalShipment(int p0)
        {
            if (shipmentViewModels.AddressViewModels != null)
            {
                for (var i = 0; i < shipmentViewModels.AddressViewModels.Count; i++)
                {
                    if (shipmentViewModels.AddressViewModels[i].Type.ToLower() == "origin")
                    {
                        string originName = shipmentViewModels.AddressViewModels[i].Name;
                        string ActualOriginName = GetValue(attributeName_id, ShippingTo_LocationName_Id, "value");
                        Assert.AreEqual(originName.ToUpper(), ActualOriginName.ToUpper());
                        Report.WriteLine("Displaying destination name in UI " + ActualOriginName + "is matching with API shipping to value " + originName);

                        string originAdd = shipmentViewModels.AddressViewModels[i].AddressLine1;
                        string ActOriginAdd = GetValue(attributeName_id, ShippingTo_LocationAddressLine1_Id, "value");
                        Assert.AreEqual(originAdd.ToUpper(), ActOriginAdd.ToUpper());
                        Report.WriteLine("Displaying destination address in UI " + ActOriginAdd + "is matching with API shipping to value " + originAdd);

                        string originAdd1 = shipmentViewModels.AddressViewModels[i].AddressLine2;
                        string ActualOriginAdd1 = GetValue(attributeName_id, ShippingTo_LocationAddressLine2_Id, "value");
                        Assert.AreEqual(originAdd1.ToUpper(), ActualOriginAdd1.ToUpper());
                        Report.WriteLine("Displaying destination name in UI " + ActualOriginAdd1 + "is matching with API shipping to value " + originAdd1);

                        string originCity = shipmentViewModels.AddressViewModels[i].City;
                        var ActualOriginCity = GetValue(attributeName_id, ShippingTo_City_Id, "value");
                        Assert.AreEqual(originCity.ToUpper(), ActualOriginCity.ToUpper());
                        Report.WriteLine("Displaying destination city in UI " + ActualOriginCity + "is matching with API shipping to value " + originCity);

                        string originState = shipmentViewModels.AddressViewModels[i].StateProvince;
                        string ActualOriginState = Gettext(attributeName_xpath, ShippingTo_StateDropdwon_SelectedValue_xpath);
                        Assert.AreEqual(originState, ActualOriginState);
                        Report.WriteLine("Displaying destination state/province in UI " + ActualOriginState + "is matching with API shipping to value " + originState);

                        string originZipCode = shipmentViewModels.AddressViewModels[i].PostalCode;
                        string ActualOriginZipCode = GetValue(attributeName_id, ShippingTo_zipcode_Id, "value");
                        Assert.AreEqual(originZipCode.ToUpper(), originZipCode.ToUpper());
                        Report.WriteLine("Displaying destination zip/postal in UI " + ActualOriginZipCode + "is matching with API shipping to value " + originZipCode);

                        string originCountry = shipmentViewModels.AddressViewModels[i].CountryCode;
                        string ActualOriginCountry = Gettext(attributeName_xpath, ShippingTo_CountryDropDown_SelectedValue_xpath);
                        if (originCountry == "USA")
                        {
                            Assert.AreEqual("United States", ActualOriginCountry);
                        }
                        else
                        {
                            Assert.AreEqual("Canada".ToUpper(), ActualOriginCountry.ToUpper());
                        }
                        Report.WriteLine("Displaying destination Country in UI " + ActualOriginCountry + "is matching with API value" + originCountry);
                    }
                }
            }
            else
            {
                Report.WriteLine("Address data didnt retrun from API");
                Assert.IsTrue(false);
            }
        }
        
        [Then(@"I will see default Pickup Date to today's date, ready time to (.*)PM and close time to (.*)PM")]
        public void ThenIWillSeeDefaultPickupDateToTodaySDateReadyTimeToPMAndCloseTimeToPM(int p0, int p1)
        {
            Report.WriteLine("Verifying default PickUp Date");
            VerifyElementVisible(attributeName_xpath, PickUpDate_Xpath, "PickUp Date");
            DateTime today = DateTime.Today;
            string s_today = today.ToString("MM/dd/yyyy");
            var PickupDate_UI = GetAttribute(attributeName_xpath, PickUpDate_Xpath, "value");
            Assert.AreEqual(PickupDate_UI, s_today);
            Report.WriteLine("Pickup date is binding default to today's date");

            string actualPickReady = Gettext(attributeName_xpath, LTL_PickUpReadyTime_SelectedValue_Xpath);
            string actpickReady = actualPickReady.Remove(0, 5);
            Assert.AreEqual(actpickReady.Trim(), "8:00 AM");
            Report.WriteLine("Binding expected ready time " + actpickReady + "in UI");

            string actualPickClose = Gettext(attributeName_xpath, LTL_PickUpCloseTime_SelectedValue_Xpath);
            string actpickClose = actualPickClose.Remove(0, 5);
            Assert.AreEqual(actpickClose.Trim(), "5:00 PM");
            Report.WriteLine("Binding expected close time " + actpickClose + "in UI");
        }

        [Then(@"I will see Class, NMFC, Quantity, QuantityType, Item description, Weight, WeightType, Hazmat, Dimensions, Dimensions type of original shipment")]
        public void ThenIWillSeeClassNMFCQuantityQuantityTypeItemDescriptionWeightWeightTypeHazmatDimensionsDimensionsTypeOfOriginalShipment()
        {
            if (shipmentViewModels.ItemViewModels != null && shipmentViewModels.ItemViewModels.Count > 0)
            {
                for (var i = 0; i < shipmentViewModels.ItemViewModels.Count; i++)
                {
                    string itemDesc = shipmentViewModels.ItemViewModels[i].ItemDescription;
                    string ActualDesc = GetValue(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id, "value");

                    if (ActualDesc == itemDesc)
                    {

                        string classification = shipmentViewModels.ItemViewModels[i].Classification;
                        string actualClass = GetValue(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id, "value");
                        classification.Contains(actualClass);
                        Report.WriteLine("Displaying nmfc in UI " + actualClass + "is matching with API value" + classification);

                        string nmfc = shipmentViewModels.ItemViewModels[i].NmfcCode;
                        string actualnmfc = GetValue(attributeName_id, FreightDesp_FirstItem_NMFC_Id, "value");
                        Assert.AreEqual(nmfc, actualnmfc);
                        Report.WriteLine("Displaying nmfc in UI " + actualnmfc + "is matching with API value" + nmfc);

                        string quantity = shipmentViewModels.ItemViewModels[i].Quantity;
                        string ActualQuantity = GetValue(attributeName_id, FreightDesp_FirstItem_Quantity_Id, "value");
                        Assert.AreEqual(quantity, ActualQuantity + ".0");
                        Report.WriteLine("Displaying quantity in UI " + ActualQuantity + "is matching with API value" + quantity);

                        string quantityUnitType = shipmentViewModels.ItemViewModels[i].QuantityUnit;
                        string quantityUnit = qType.Getquantity(quantityUnitType);
                        string ActualQuantityUnit = Gettext(attributeName_xpath, FreightDesp_FirstItem_QuantityType_xpath);
                        Assert.AreEqual(quantityUnit.ToUpper(), ActualQuantityUnit.ToUpper());
                        Report.WriteLine("Displaying quantity unit in UI " + ActualQuantityUnit + "is matching with API value" + quantityUnit);

                        string weight = shipmentViewModels.ItemViewModels[i].Weight;
                        string ActualWeight = GetValue(attributeName_id, FreightDesp_FirstItem_Weight_Id, "value");
                        Assert.AreEqual(weight, ActualWeight);
                        Report.WriteLine("Displaying weight in UI " + ActualWeight + "is matching with API value" + weight);

                        string weightUnitType = shipmentViewModels.ItemViewModels[i].WeightUnit;
                        string weightUnit = wType.GetWeight(weightUnitType);
                        string actualWeightUnit = Gettext(attributeName_xpath, FreightDesp_FirstItem_WeightType_xpath);
                        Assert.AreEqual(weightUnit.ToUpper(), actualWeightUnit.ToUpper());
                        Report.WriteLine("Displaying weight unit in UI " + actualWeightUnit + "is matching with API value" + weightUnit);

                        string length = shipmentViewModels.ItemViewModels[i].Length;
                        string actualLength = GetValue(attributeName_id, FreightDesp_FirstItem_Length_Id, "value");
                        Assert.AreEqual(length, actualLength);
                        Report.WriteLine("Displaying length in UI " + actualLength + "is matching with API value" + length);

                        string width = shipmentViewModels.ItemViewModels[i].Width;
                        string actualWidth = GetValue(attributeName_id, FreightDesp_FirstItem_Width_Id, "value");
                        Assert.AreEqual(width, actualWidth);
                        Report.WriteLine("Displaying width in UI " + actualWidth + "is matching with API value" + width);

                        string height = shipmentViewModels.ItemViewModels[i].Height;
                        string actualHeight = GetValue(attributeName_id, FreightDesp_FirstItem_Height_Id, "value");
                        Assert.AreEqual(height, actualHeight);
                        Report.WriteLine("Displaying height in UI " + actualHeight + "is matching with API value" + height);

                        string dimValue = shipmentViewModels.ItemViewModels[i].DimensionUnit;
                        string actualDimValue = Gettext(attributeName_xpath, FreightDesp_FirstItem_DimensionType_SelectedValue_xpath);
                        Assert.AreEqual(dimValue.ToUpper(), actualDimValue.ToUpper());
                        Report.WriteLine("Displaying dimension value in UI " + actualDimValue + "is matching with API value" + dimValue);

                        bool hazMatValue = shipmentViewModels.ItemViewModels[i].IsHazardous;
                        if (hazMatValue == true)
                        {
                            VerifyElementChecked(attributeName_id, FreightDesp_FirstItem_Hazardous_Yes_Input_Id, "Hazmat Yes");
                        }
                        else
                        {
                            VerifyElementChecked(attributeName_id, FreightDesp_FirstItem_Hazardous_No_Input_Id, "Hazmat No");
                        }
                        break;
                    }
                    else
                    {
                        Report.WriteLine("Item values displaying in UI is not matching with API value");
                        Assert.IsTrue(false);
                    }
                }
            }
            else
            {
                Report.WriteLine("Item model is null");
                Assert.IsTrue(false);
            }
        }


        [Then(@"I will see default special instructions from the original shipment will be displayed (.*)")]
        public void ThenIWillSeeDefaultSpecialInstructionsFromTheOriginalShipmentWillBeDisplayed(string accName)
        {
            int accId = DBHelper.GetAccountIdforAccountName(accName);
            CustomerAccount accvalue = DBHelper.GetAccountDetails(accId);
            string actSpcInst = GetValue(attributeName_id, DefaultSpecialIntructions_Comments_Id, "value");
            Assert.AreEqual(accvalue.SpecialInstructions, actSpcInst);
        }
        
        [Then(@"I will able to edit Shipping From section (.*),(.*), (.*), (.*), (.*), (.*) and (.*)  populated data")]
        public void ThenIWillAbleToEditShippingFromSectionAndPopulatedData(string SFLocationName, string SFLocationAddress, 
            string SFLocationAddressLine2, string SFZipPostalCode, string SFCountry, string SFCity, string SFStateProvince)
        {
            Report.WriteLine("Editing data in shipping from section");
            Click(attributeName_xpath, ShippingFrom_CountryDropDown_xpath);
            SelectDropdownValueFromList(attributeName_xpath, ShippingFrom_CountryDropDown_xpath, SFCountry);
            ship.AddShipmentOriginData(SFLocationName, SFLocationAddress, SFZipPostalCode);
            SendKeys(attributeName_id, ShippingFrom_LocationAddressLine2_Id, SFLocationAddressLine2);

            string ActualOriginName = GetValue(attributeName_id, ShippingFrom_LocationName_Id, "value");
            Assert.AreEqual(SFLocationName.ToUpper(), ActualOriginName.ToUpper());
            Report.WriteLine("Edited shipping from name " + SFLocationName + "is displaying in UI " + ActualOriginName);

            string ActOriginAdd = GetValue(attributeName_id, ShippingFrom_LocationAddressLine1_Id, "value");
            Assert.AreEqual(SFLocationAddress.ToUpper(), ActOriginAdd.ToUpper());
            Report.WriteLine("Edited shipping from address 1 " + SFLocationAddress + "is displaying in UI " + ActOriginAdd);

            string ActualOriginAdd1 = GetValue(attributeName_id, ShippingFrom_LocationAddressLine2_Id, "value");
            Assert.AreEqual(SFLocationAddressLine2.ToUpper(), ActualOriginAdd1.ToUpper());
            Report.WriteLine("Edited shipping from address 1 " + SFLocationAddressLine2 + "is displaying in UI " + ActualOriginAdd1);

            var ActualOriginCity = GetValue(attributeName_id, ShippingFrom_City_Id, "value");
            Assert.AreEqual(SFCity, ActualOriginCity);
            Report.WriteLine("Edited shipping from City " + SFCity + "is displaying in UI " + ActualOriginCity);

            string ActualOriginState = Gettext(attributeName_xpath, ShippingFrom_StateDropdwon_SelectedValue_xpath);
            Assert.AreEqual(SFStateProvince, ActualOriginState);
            Report.WriteLine("Edited shipping from state " + SFStateProvince + "is displaying in UI " + ActualOriginState);

            string ActualOriginZipCode = GetValue(attributeName_id, ShippingFrom_zipcode_Id, "value");
            Assert.AreEqual(SFZipPostalCode.ToUpper(), ActualOriginZipCode.ToUpper());
            Report.WriteLine("Edited shipping from zip" + SFZipPostalCode + "is displaying in UI " + ActualOriginZipCode);

        }

        [Then(@"I will able to edit Shipping To section (.*), (.*), (.*), (.*), (.*), (.*) and (.*) populated data")]
        public void ThenIWillAbleToEditShippingToSectionAndPopulatedData(string STLocationName, string STLocationAddress, 
            string STLocationAddressLine2, 
            string STZipPostalCode, string STCountry, string STCity, string STStateProvince)
        {
            Report.WriteLine("Editing data in shipping to section");
            Click(attributeName_xpath, ShippingTo_CountryDropDown_xpath);
            SelectDropdownValueFromList(attributeName_xpath, ShippingTo_CountryDropDown_xpath, STCountry);
            ship.AddShipmentDestinationData(STLocationName, STLocationAddress, STZipPostalCode);
            SendKeys(attributeName_id, ShippingTo_LocationAddressLine2_Id, STLocationAddressLine2);

            string ActualDestName = GetValue(attributeName_id, ShippingTo_LocationName_Id, "value");
            Assert.AreEqual(STLocationName.ToUpper(), ActualDestName.ToUpper());
            Report.WriteLine("Edited shipping from name " + STLocationName + "is displaying in UI " + ActualDestName);

            string ActDestAdd = GetValue(attributeName_id, ShippingTo_LocationAddressLine1_Id, "value");
            Assert.AreEqual(STLocationAddress.ToUpper(), ActDestAdd.ToUpper());
            Report.WriteLine("Edited shipping from address 1 " + STLocationAddress + "is displaying in UI " + ActDestAdd);

            string ActualDestAdd1 = GetValue(attributeName_id, ShippingTo_LocationAddressLine2_Id, "value");
            Assert.AreEqual(STLocationAddressLine2.ToUpper(), ActualDestAdd1.ToUpper());
            Report.WriteLine("Edited shipping from address 1 " + STLocationAddressLine2 + "is displaying in UI " + ActualDestAdd1);

            var ActualDestCity = GetValue(attributeName_id, ShippingTo_City_Id, "value");
            Assert.AreEqual(STCity, ActualDestCity);
            Report.WriteLine("Edited shipping from City " + STCity + "is displaying in UI " + ActualDestCity);

            string ActualDestState = Gettext(attributeName_xpath, ShippingTo_StateDropdwon_SelectedValue_xpath);
            Assert.AreEqual(STStateProvince, ActualDestState);
            Report.WriteLine("Edited shipping from state " + STStateProvince + "is displaying in UI " + ActualDestState);

            string ActualDestZipCode = GetValue(attributeName_id, ShippingTo_zipcode_Id, "value");
            Assert.AreEqual(STZipPostalCode.ToUpper(), ActualDestZipCode.ToUpper());
            Report.WriteLine("Edited shipping from zip" + STZipPostalCode + "is displaying in UI " + ActualDestZipCode);

        }

        [Then(@"I will able to edit (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*) and (.*) populated data")]
        public void ThenIWillAbleToEditAndPopulatedData(string Classification, string NMFC, string Quantity, string QuantityType, 
            string ItemDesc, string Weight, string WeightType, string Hazmat, string Length, string Width, 
            string Height, string DimensionType)
        {
            
            Click(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            ship.AddShipmentFreightDescription(Classification, NMFC, Quantity, Weight, ItemDesc);
            scrollElementIntoView(attributeName_xpath, FreightDesp_FirstItem_QuantityType_xpath);
            Click(attributeName_xpath, FreightDesp_FirstItem_QuantityType_xpath);
            SelectDropdownValueFromList(attributeName_xpath, FreightDesp_FirstItem_QuantityTypevalues_xpath, QuantityType);
            Click(attributeName_xpath, FreightDesp_FirstItem_WeightType_xpath);
            SelectDropdownValueFromList(attributeName_xpath, FreightDesp_FirstItem_WeightTypevalues_xpath, WeightType);
            SendKeys(attributeName_id, FreightDesp_FirstItem_Length_Id, Length);
            SendKeys(attributeName_id, FreightDesp_FirstItem_Width_Id, Length);
            SendKeys(attributeName_id, FreightDesp_FirstItem_Height_Id, Length);
            Click(attributeName_xpath, FreightDesp_FirstItem_DimensionType_xpath);
            SelectDropdownValueFromList(attributeName_xpath, FreightDesp_FirstItem_DimensionType_Values_xpath, DimensionType);

            string actClassification = GetValue(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id, "value");
            Assert.AreEqual(actClassification, Classification);
            Report.WriteLine("Edited classification" + Classification + "is displaying in UI " + actClassification);

            string actNMFC = GetValue(attributeName_id, FreightDesp_FirstItem_NMFC_Id, "value");
            Assert.AreEqual(actNMFC, NMFC);
            Report.WriteLine("Edited nmfc" + NMFC + "is displaying in UI " + actNMFC);

            string actQuantity = GetValue(attributeName_id, FreightDesp_FirstItem_Quantity_Id, "value");
            Assert.AreEqual(actQuantity, Quantity);
            Report.WriteLine("Edited quantity" + Quantity + "is displaying in UI " + actQuantity);

            string actQuantityType = Gettext(attributeName_xpath, FreightDesp_FirstItem_QuantityType_xpath);
            Assert.AreEqual(actQuantityType, QuantityType);
            Report.WriteLine("Edited quantity type" + QuantityType + "is displaying in UI " + actQuantityType);

            string actWeight = GetValue(attributeName_id, FreightDesp_FirstItem_Weight_Id,"value");
            Assert.AreEqual(actWeight, Weight);
            Report.WriteLine("Edited weight" + Weight + "is displaying in UI " + actWeight);

            string actWeightType = Gettext(attributeName_xpath, FreightDesp_FirstItem_WeightType_xpath);
            Assert.AreEqual(actWeightType, WeightType);
            Report.WriteLine("Edited weight type" + WeightType + "is displaying in UI " + actWeightType);

            string actLength = GetValue(attributeName_id, FreightDesp_FirstItem_Length_Id, "value");
            Assert.AreEqual(actLength, Length);
            Report.WriteLine("Edited length" + Length + "is displaying in UI " + actLength);

            string actWidth = GetValue(attributeName_id, FreightDesp_FirstItem_Width_Id, "value");
            Assert.AreEqual(actWidth, Width);
            Report.WriteLine("Edited width" + Width + "is displaying in UI " + actWidth);

            string actHeight = GetValue(attributeName_id, FreightDesp_FirstItem_Height_Id, "value");
            Assert.AreEqual(actHeight, Height);
            Report.WriteLine("Edited width" + Height + "is displaying in UI " + actHeight);

            string actDimType = Gettext(attributeName_xpath, FreightDesp_FirstItem_DimensionType_SelectedValue_xpath);
            Assert.AreEqual(actDimType, DimensionType);
            Report.WriteLine("Edited width" + DimensionType + "is displaying in UI " + actDimType);

            string actItemDesc = GetValue(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id, "value");
            Assert.AreEqual(actItemDesc, ItemDesc);
            Report.WriteLine("Edited width" + ItemDesc + "is displaying in UI " + actItemDesc);
        }
        
        [Then(@"I will abe able to edit (.*) populated data")]
        public void ThenIWillAbeAbleToEditPopulatedData(string spclInst)
        {
            scrollElementIntoView(attributeName_id, DefaultSpecialIntructions_Comments_Id);
            SendKeys(attributeName_id, DefaultSpecialIntructions_Comments_Id, spclInst);
            string actSpecialInst = GetValue(attributeName_id, DefaultSpecialIntructions_Comments_Id, "value");
            Assert.AreEqual(actSpecialInst, spclInst);
            Report.WriteLine("Edited special instruction " + spclInst + "is displaying in UI " + actSpecialInst);
        }
        
        [Then(@"I will see the Clear Address button in the Shipping From section,")]
        public void ThenIWillSeeTheClearAddressButtonInTheShippingFromSection()
        {
            Report.WriteLine("Verify the display of clear address in shipping from section");
            VerifyElementVisible(attributeName_id, ShippingFrom_ClearAddress_Id, "Clear Address");
        }
        
        [Then(@"I will see the Clear Address button in the Shipping To section,")]
        public void ThenIWillSeeTheClearAddressButtonInTheShippingToSection()
        {
            Report.WriteLine("Verify the display of clear address in shipping to section");
            VerifyElementVisible(attributeName_id, ShippingTo_ClearAddress_Id, "Clear Address");
        }
        
        [Then(@"I will see the Clear Item button in the Freight Description section,")]
        public void ThenIWillSeeTheClearItemButtonInTheFreightDescriptionSection()
        {
            Report.WriteLine("Verify the display of clear item in shipping to section");
            VerifyElementVisible(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id, "Clear Item");
        }
        
        [Then(@"I am able to add additional reference numbers\.")]
        public void ThenIAmAbleToAddAdditionalReferenceNumbers_()
        {
            List<String> extRefValue = new List<string>();
            string refValue = "PO Number, Order Number, GL_Code, Ship Ref, PRO, Pickup Number, Delivery Appt Nbr, Ship Ref, Cons Ref, CustInvRef, Delivery Appt Nbr, GL_Code, Job Name, Job Number, Manifest Nbr, Order Number, Pickup Appt Nbr, Pickup Number, PO Number, PRO, Product Code, Project Number, Release Nbr, Sales Order, Ship Ref, WorkOrderNbr";
            string[] values = refValue.Split(',');
            foreach (var v in values)
            {
                extRefValue.Add(v.Trim());
            }

            if (shipmentViewModels.ReferenceNumbers != null)
            {
                for (int i = 0; i < shipmentViewModels.ReferenceNumbers.Count; i++)
                {
                    if (extRefValue.Contains(shipmentViewModels.ReferenceNumbers[i].Type))
                    {
                        VerifyElementVisible(attributeName_xpath, AddAdditionalReference_Button_xpath, "Reference number section");
                        Report.WriteLine("Add additional reference number button is displaying");
                        break;
                    }
                }
            }
            else
            {
                Report.WriteLine("Unable to verify the reference number section as selected shipment does not contain reference numbers");
            }
        }

        [Then(@"the Shipping From Contact Info section will be collapsed, if shipment did not contain any Shipping From Contact Info")]
        public void ThenTheShippingFromContactInfoSectionWillBeCollapsedIfShipmentDidNotContainAnyShippingFromContactInfo()
        {
            for (var i = 0; i < shipmentViewModels.ContactViewModels.Count; i++)
            {
                if (shipmentViewModels.ContactViewModels[i].ContactType.ToLower() == "destination")
                {
                    if (shipmentViewModels.ContactViewModels[i].Name == null && shipmentViewModels.ContactViewModels[i].Phone == null && shipmentViewModels.ContactViewModels[i].Email == null && shipmentViewModels.ContactViewModels[i].Fax == null)
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

        [Then(@"the Shipping To Contact Info section will be collapsed , if shipment did not contain any Shipping From Contact Info")]
        public void ThenTheShippingToContactInfoSectionWillBeCollapsedIfShipmentDidNotContainAnyShippingFromContactInfo()
        {
            for (var i = 0; i < shipmentViewModels.ContactViewModels.Count; i++)
            {
                if (shipmentViewModels.ContactViewModels[i].ContactType.ToLower() == "destination")
                {
                    if (shipmentViewModels.ContactViewModels[i].Name == null && shipmentViewModels.ContactViewModels[i].Phone == null && shipmentViewModels.ContactViewModels[i].Email == null && shipmentViewModels.ContactViewModels[i].Fax == null)
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


        [Then(@"the Shipping From Contact Info section will be expanded, if shipment contained Shipping From Contact Info")]
        public void ThenTheShippingFromContactInfoSectionWillBeExpandedIfShipmentContainedShippingFromContactInfo()
        {
            for (var i = 0; i < shipmentViewModels.ContactViewModels.Count; i++)
            {
                if (shipmentViewModels.ContactViewModels[i].ContactType.ToLower() == "destination")
                {
                    if (shipmentViewModels.ContactViewModels[i].Name == string.Empty && shipmentViewModels.ContactViewModels[i].Phone == string.Empty && shipmentViewModels.ContactViewModels[i].Email == string.Empty && shipmentViewModels.ContactViewModels[i].Fax == string.Empty)
                    {
                        Report.WriteLine("Unable to verify the shipping from contact expand functionality as shipment does not have contact info");
                    }
                    else
                    {
                        VerifyElementVisible(attributeName_id, ShippingFrom_ContactName_Id, "Contact Fields");
                    }
                }
            }
        }

        [Then(@"all the fields in shipping from contact section (.*), (.*), (.*) and (.*) are editable\.")]
        public void ThenAllTheFieldsInShippingFromContactSectionAndAreEditable_(string sfContactName, string sfContactPhone, string sfContactEmail, string sfContactFax)
        {
            for (var i = 0; i < shipmentViewModels.ContactViewModels.Count; i++)
            {
                if (shipmentViewModels.ContactViewModels[i].ContactType.ToLower() == "destination")
                {
                    if (shipmentViewModels.ContactViewModels[i].Name == string.Empty && shipmentViewModels.ContactViewModels[i].Phone == string.Empty && shipmentViewModels.ContactViewModels[i].Email == string.Empty && shipmentViewModels.ContactViewModels[i].Fax == string.Empty)
                    {
                        Report.WriteLine("Unable to verify the shipping from contact expand functionality as shipment does not have contact info");
                    }
                    else
                    {
                        SendKeys(attributeName_id, ShippingFrom_ContactName_Id, sfContactName);
                        SendKeys(attributeName_id, ShippingFrom_ContactPhone_Id, sfContactPhone);
                        SendKeys(attributeName_id, ShippingFrom_ContactFax_Id, sfContactFax);
                        SendKeys(attributeName_id, ShippingFrom_ContactEmail_Id, sfContactEmail);

                        Report.WriteLine("Verify the editing functionality in shipping from contact section");
                        string actSFConName = GetValue(attributeName_id, ShippingFrom_ContactName_Id, "value");
                        Assert.AreEqual(actSFConName, sfContactName);
                        Report.WriteLine("Edited contact name " + actSFConName + "is displaying in UI " + sfContactName);

                        string actSFConPhone = GetValue(attributeName_id, ShippingFrom_ContactPhone_Id, "value");
                        Assert.AreEqual(sfContactPhone, actSFConPhone);
                        Report.WriteLine("Edited contact phone " + sfContactPhone + "is displaying in UI " + actSFConPhone);

                        string actSFConFax = GetValue(attributeName_id, ShippingFrom_ContactFax_Id, "value");
                        Assert.AreEqual(sfContactFax, actSFConFax);
                        Report.WriteLine("Edited contact fax " + sfContactFax + "is displaying in UI " + actSFConFax);

                        string actSFConEmail = GetValue(attributeName_id, ShippingFrom_ContactEmail_Id, "value");
                        Assert.AreEqual(sfContactEmail, actSFConEmail);
                        Report.WriteLine("Edited contact email " + sfContactEmail + "is displaying in UI " + actSFConEmail);
                        break;
                    }
                }
            }
        }

        [Then(@"all the fields shipping to contact section (.*), (.*), (.*) and (.*) are editable\.")]
        public void ThenAllTheFieldsShippingToContactSectionAndAreEditable_(string stContactName, string stContactPhone, string stContactEmail, string stContactFax)
        {
            for (var i = 0; i < shipmentViewModels.ContactViewModels.Count; i++)
            {
                if (shipmentViewModels.ContactViewModels[i].ContactType.ToLower() == "origin")
                {
                    if (shipmentViewModels.ContactViewModels[i].Name == string.Empty && shipmentViewModels.ContactViewModels[i].Phone == string.Empty && shipmentViewModels.ContactViewModels[i].Email == string.Empty && shipmentViewModels.ContactViewModels[i].Fax == string.Empty)
                    {
                        Report.WriteLine("Unable to verify the shipping to contact expand functionality as shipment does not have contact info");
                    }
                    else
                    {
                        SendKeys(attributeName_id, ShippingTo_ContactName_Id, stContactName);
                        SendKeys(attributeName_id, ShippingTo_ContactPhone_Id, stContactPhone);
                        SendKeys(attributeName_id, ShippingTo_ContactFax_Id, stContactFax);
                        SendKeys(attributeName_id, ShippingTo_ContactEmail_Id, stContactEmail);

                        Report.WriteLine("Verify the editing functionality in shipping to contact section");
                        string actStConName = GetValue(attributeName_id, ShippingTo_ContactName_Id, "value");
                        Assert.AreEqual(actStConName, stContactName);
                        Report.WriteLine("Edited contact name " + actStConName + "is displaying in UI " + stContactName);

                        string actStConPhone = GetValue(attributeName_id, ShippingTo_ContactPhone_Id, "value");
                        Assert.AreEqual(stContactPhone, actStConPhone);
                        Report.WriteLine("Edited contact phone " + stContactPhone + "is displaying in UI " + actStConPhone);

                        string actStConFax = GetValue(attributeName_id, ShippingTo_ContactFax_Id, "value");
                        Assert.AreEqual(stContactFax, actStConFax);
                        Report.WriteLine("Edited contact fax " + stContactFax + "is displaying in UI " + actStConFax);

                        string actStConEmail = GetValue(attributeName_id, ShippingTo_ContactEmail_Id, "value");
                        Assert.AreEqual(stContactEmail, actStConEmail);
                        Report.WriteLine("Edited contact email " + stContactEmail + "is displaying in UI " + actStConEmail);
                    }
                }
            }
        }

        [Then(@"the Shipping To Contact Info section will be expanded, if shipment contained Shipping To Contact Info")]
        public void ThenTheShippingToContactInfoSectionWillBeExpandedIfShipmentContainedShippingToContactInfo()
        {
            for (var i = 0; i < shipmentViewModels.ContactViewModels.Count; i++)
            {
                if (shipmentViewModels.ContactViewModels[i].ContactType.ToLower() == "origin")
                {
                    if (shipmentViewModels.ContactViewModels[i].Name == string.Empty && shipmentViewModels.ContactViewModels[i].Phone == string.Empty && shipmentViewModels.ContactViewModels[i].Email == string.Empty && shipmentViewModels.ContactViewModels[i].Fax == string.Empty)
                    {
                        Report.WriteLine("Unable to verify the shipping to contact expand functionality as shipment does not have contact info");
                    }
                    else
                    {
                        VerifyElementVisible(attributeName_id, ShippingTo_ContactName_Id, "Contact Fields");
                    }
                }
            }
        }

        
        [Then(@"the Hazardous Materials fields (.*), (.*), (.*), (.*), (.*) and (.*) are editable\.")]
        public void ThenTheHazardousMaterialsFieldsAndAreEditable_(string unNumb, string ccnNumb, string hazGroup, 
            string hazClass, string hazName, string hazPhone)
        {
            if (shipmentViewModels.ItemViewModels != null)
            {
                for (var i = 0; i < shipmentViewModels.ItemViewModels.Count; i++)
                {
                    string itemDesc = shipmentViewModels.ItemViewModels[i].ItemDescription;
                    string ActualDesc = GetValue(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id, "value");

                    if (ActualDesc == itemDesc)
                    {
                        bool hazMatValue = shipmentViewModels.ItemViewModels[i].IsHazardous;
                        if (hazMatValue == true)
                        {
                            SendKeys(attributeName_id, FreightDesp_FirstItem_UN_Number_Id, unNumb);
                            SendKeys(attributeName_id, FreightDesp_FirstItem_CCN_Number_Id, ccnNumb);
                            SendKeys(attributeName_id, FreightDesp_FirstItem_EmergencyReponseContactName_Id, hazName);
                            SendKeys(attributeName_id, FreightDesp_FirstItem_EmergencyReponsePhoneNumber_Id, hazPhone);
                            Click(attributeName_xpath, FreightDesp_FirstItem_SelectHazmatPackageGroup_DownDown_xpath);
                            SelectDropdownValueFromList(attributeName_xpath, FreightDesp_FirstItem_SelectHazmatPackageGroup_DownDown_Values_xpath, hazGroup);
                            Click(attributeName_xpath, FreightDesp_FirstItem_SelectHazmatClass_DropwDown_xpath);
                            SelectDropdownValueFromList(attributeName_xpath, FreightDesp_FirstItem_SelectHazmatClass_DropwDown_Values_xpath, hazClass);

                            string actUNNumb = GetValue(attributeName_id, FreightDesp_FirstItem_UN_Number_Id, "value");
                            Assert.AreEqual(actUNNumb, unNumb);
                            Report.WriteLine("Edited UN Number " + actUNNumb + "is displayin in UI" + unNumb);

                            string actCCNNumb = GetValue(attributeName_id, FreightDesp_FirstItem_CCN_Number_Id, "value");
                            actCCNNumb.Contains(ccnNumb);

                            string actphone = GetValue(attributeName_id, FreightDesp_FirstItem_EmergencyReponsePhoneNumber_Id, "value");
                            Assert.AreEqual(actphone, hazPhone);
                            Report.WriteLine("Edited phone " + actphone + "is displayin in UI" + hazPhone);

                            string actName = GetValue(attributeName_id, FreightDesp_FirstItem_EmergencyReponseContactName_Id, "value");
                            Assert.AreEqual(actName, hazName);
                            Report.WriteLine("Edited name " + actName + "is displayin in UI" + hazName);

                            string actGroup = Gettext(attributeName_xpath, FreightDesp_FirstItem_SelectHazmatPackageGroup_DownDown_xpath);
                            Assert.AreEqual(actGroup, hazGroup);
                            Report.WriteLine("Edited hazmat group " + actGroup + "is displayin in UI" + hazGroup);

                            string actClass = Gettext(attributeName_xpath, FreightDesp_FirstItem_SelectHazmatClass_DropwDown_xpath);
                            Assert.AreEqual(actClass, hazClass);
                            Report.WriteLine("Edited hazmat class " + actClass + "is displayin in UI" + hazClass);
                        }
                        else
                        {
                            Report.WriteLine("Unable to verify the hazmat edit funcitonality as selectedshipment does not contain hazmat details");
                        }
                    }
                }
            }
        }

        [Then(@"the Additional Item section will be expanded in the Freight Description section, if the shipment contained additional items")]
        public void ThenTheAdditionalItemSectionWillBeExpandedInTheFreightDescriptionSectionIfTheShipmentContainedAdditionalItems()
        {
            if (shipmentViewModels.ItemViewModels != null && shipmentViewModels.ItemViewModels.Count > 1)
            {
                VerifyElementVisible(attributeName_id, FreightDesp_First_AdditionalItem_SavedClassItem_DropDown_Id, "Additional Item");
                for (var i = 0; i < shipmentViewModels.ItemViewModels.Count; i++)
                {
                    string itemDesc = shipmentViewModels.ItemViewModels[i].ItemDescription;
                    string ActualDesc = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_ItemDescription_Id, "value");

                    if (ActualDesc == itemDesc)
                    {
                        scrollpagedown();
                        scrollpagedown();
                        scrollpagedown();

                        string classification = shipmentViewModels.ItemViewModels[i].Classification;
                        string actualClass = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_SavedClassItem_DropDown_Id, "value");
                        classification.Contains(actualClass);
                        Report.WriteLine("Displaying classification in UI " + actualClass + "is matching with API value" + classification);

                        string nmfc = shipmentViewModels.ItemViewModels[i].NmfcCode;
                        string actualnmfc = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_NMFC_Id, "value");
                        Assert.AreEqual(nmfc, actualnmfc);
                        Report.WriteLine("Displaying nmfc in UI " + actualnmfc + "is matching with API value" + nmfc);

                        string quantity = shipmentViewModels.ItemViewModels[i].Quantity;
                        string ActualQuantity = GetValue(attributeName_xpath, FreightDesp_First_AdditionalItem_Quantity_xpath, "value");
                        Assert.AreEqual(quantity, ActualQuantity+".0");
                        Report.WriteLine("Displaying quantity in UI " + ActualQuantity + "is matching with API value" + quantity);

                        string quantityUnitType = shipmentViewModels.ItemViewModels[i].QuantityUnit;
                        string quantityUnit = qType.Getquantity(quantityUnitType);
                        string ActualQuantityUnit = Gettext(attributeName_xpath, FreightDesp_First_AdditionalItem_QuantityType_xpath);
                        Assert.AreEqual(quantityUnit.ToUpper(), ActualQuantityUnit.ToUpper());
                        Report.WriteLine("Displaying quantity unit in UI " + ActualQuantityUnit + "is matching with API value" + quantityUnit);

                        string weight = shipmentViewModels.ItemViewModels[i].Weight;
                        string ActualWeight = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_Weight_Id, "value");
                        Assert.AreEqual(weight, ActualWeight);
                        Report.WriteLine("Displaying weight in UI " + ActualWeight + "is matching with API value" + weight);

                        string weightUnitType = shipmentViewModels.ItemViewModels[i].WeightUnit;
                        string weightUnit = wType.GetWeight(weightUnitType);
                        string actualWeightUnit = Gettext(attributeName_xpath, FreightDesp_First_AdditionalItem_WeightType_xpath);
                        Assert.AreEqual(weightUnit.ToUpper(), actualWeightUnit.ToUpper());
                        Report.WriteLine("Displaying weight unit in UI " + actualWeightUnit + "is matching with API value" + weightUnit);

                        string length = shipmentViewModels.ItemViewModels[i].Length;
                        string actualLength = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_Length_Id, "value");
                        Assert.AreEqual(length, actualLength);
                        Report.WriteLine("Displaying length in UI " + actualLength + "is matching with API value" + length);

                        string width = shipmentViewModels.ItemViewModels[i].Width;
                        string actualWidth = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_Width_Id, "value");
                        Assert.AreEqual(width, actualWidth);
                        Report.WriteLine("Displaying width in UI " + actualWidth + "is matching with API value" + width);

                        string height = shipmentViewModels.ItemViewModels[i].Height;
                        string actualHeight = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_Height_Id, "value");
                        Assert.AreEqual(height, actualHeight);
                        Report.WriteLine("Displaying height in UI " + actualHeight + "is matching with API value" + height);

                        string dimValue = shipmentViewModels.ItemViewModels[i].DimensionUnit;
                        string actualDimValue = Gettext(attributeName_xpath, FreightDesp_First_AdditionalItem_DimensionType_Selected_xpath);
                        Assert.AreEqual(dimValue.ToUpper(), actualDimValue);
                        Report.WriteLine("Displaying dimension value in UI " + actualDimValue + "is matching with API value" + dimValue);

                        bool hazMatValue = shipmentViewModels.ItemViewModels[i].IsHazardous;
                        if (hazMatValue == true)
                        {
                            VerifyElementChecked(attributeName_id, FreightDesp_AdditionalItem_Hazardous_Yes_Input_Id, "Hazmat Yes");
                        }
                        else
                        {
                            VerifyElementChecked(attributeName_id, FreightDesp_AdditionalItem_Hazardous_No_Input_Id, "Hazmat No");
                        }
                        break;
                    }
                    else
                    {

                    }
                }
            }
            else
            {
                Report.WriteLine("Unable to verify additional item functionality as additional item does not exists for the selected shipment");
            }
        }


        [Then(@"I will see the Remove Item button,")]
        public void ThenIWillSeeTheRemoveItemButton()
        {
            if (shipmentViewModels.ItemViewModels != null && shipmentViewModels.ItemViewModels.Count > 1)
            {
                VerifyElementVisible(attributeName_xpath, FreightDesp_First_Remove_Button_xpath, "Additional Item");
                Report.WriteLine("Remove button is displaing in UI");
            }
            else
            {
                Report.WriteLine("Unable to verify remove button functionality as additional item does not exists for the selected shipment");
            }
        }

        [Then(@"I am able to edit any information (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*) and (.*) in the Additional Item section\.")]
        public void ThenIAmAbleToEditAnyInformationAndInTheAdditionalItemSection_(string Classification, string NMFC, string Quantity, string QuantityType,
            string ItemDesc, string Weight, string WeightType, string Hazmat, string Length, string Width,
            string Height, string DimensionType)
        {
            if (shipmentViewModels.ItemViewModels != null && shipmentViewModels.ItemViewModels.Count > 1)
            {
                for (var i = 0; i < shipmentViewModels.ItemViewModels.Count; i++)
                {
                    string itemDesc = shipmentViewModels.ItemViewModels[i].ItemDescription;
                    string ActualDesc = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_ItemDescription_Id, "value");

                    if (ActualDesc == itemDesc)
                    {
                        Click(attributeName_id, FreightDesp_First_AdditionalItem_ClearItem_Button_Id);
                        Report.WriteLine("Passing data in freight description section");
                        Click(attributeName_id, FreightDesp_First_AdditionalItem_SavedClassItem_DropDown_Id);
                        IList<IWebElement> dropdownValues = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='scrollable-dropdown-menu-Origin']/div/span[1]/span/div/span/div/p"));
                        for (int j = 0; j < dropdownValues.Count; j++)
                        {
                            int z = j + 1;
                            string value = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='scrollable-dropdown-menu-Origin']/div/span[1]/span/div/span/div[" + z + "]/p")).Text;
                            if (value == Classification)
                            {
                                GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='scrollable-dropdown-menu-Origin']/div/span[1]/span/div/span/div[" + z + "]/p")).Click();
                                break;
                            }
                        }
                        SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_NMFC_Id, NMFC);
                        SendKeys(attributeName_xpath, FreightDesp_First_AdditionalItem_Quantity_xpath, Quantity);
                        SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_Weight_Id, Weight);
                        SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_ItemDescription_Id, ItemDesc);
                        SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_Length_Id, Length);
                        SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_Width_Id, Width);
                        SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_Height_Id, Height);
                        scrollpagedown();
                        Click(attributeName_xpath, FreightDesp_First_AdditionalItem_QuantityType_xpath);
                        SelectDropdownValueFromList(attributeName_xpath, FreightDesp_First_AdditionalItem_QuantityTypevalues_xpath, QuantityType);
                        Click(attributeName_xpath, FreightDesp_First_AdditionalItem_WeightType_xpath);
                        SelectDropdownValueFromList(attributeName_xpath, FreightDesp_First_AdditionalItem_WeightTypevalues_xpath, WeightType);
                        Click(attributeName_xpath, FreightDesp_First_AdditionalItem_DimensionType_xpath);
                        SelectDropdownValueFromList(attributeName_xpath, FreightDesp_First_AdditionalItem_DimensionTypevalues_xpath, DimensionType);
                        
                        string actualClass = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_SavedClassItem_DropDown_Id, "value");
                        Assert.AreEqual(Classification, actualClass);
                        Report.WriteLine("Displaying nmfc in UI " + actualClass + "is matching with API value" + Classification);

                        string actualnmfc = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_NMFC_Id, "value");
                        Assert.AreEqual(NMFC, actualnmfc);
                        Report.WriteLine("Displaying nmfc in UI " + actualnmfc + "is matching with API value" + NMFC);

                        string ActualQuantity = GetValue(attributeName_xpath, FreightDesp_First_AdditionalItem_Quantity_xpath, "value");
                        Assert.AreEqual(Quantity, ActualQuantity);
                        Report.WriteLine("Displaying quantity in UI " + ActualQuantity + "is matching with API value" + Quantity);

                        string ActualQuantityUnit = Gettext(attributeName_xpath, FreightDesp_First_AdditionalItem_QuantityType_xpath);
                        Assert.AreEqual(QuantityType, ActualQuantityUnit);
                        Report.WriteLine("Displaying quantity unit in UI " + ActualQuantityUnit + "is matching with API value" + QuantityType);

                        string ActualWeight = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_Weight_Id, "value");
                        Assert.AreEqual(Weight, ActualWeight);
                        Report.WriteLine("Displaying weight in UI " + ActualWeight + "is matching with API value" + Weight);

                        string actualWeightUnit = Gettext(attributeName_xpath, FreightDesp_First_AdditionalItem_WeightType_xpath);
                        Assert.AreEqual(WeightType, actualWeightUnit);
                        Report.WriteLine("Displaying weight unit in UI " + actualWeightUnit + "is matching with API value" + WeightType);

                        string actualLength = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_Length_Id, "value");
                        Assert.AreEqual(Length, actualLength);
                        Report.WriteLine("Displaying length in UI " + actualLength + "is matching with API value" + Length);

                        string actualWidth = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_Width_Id, "value");
                        Assert.AreEqual(Width, actualWidth);
                        Report.WriteLine("Displaying width in UI " + actualWidth + "is matching with API value" + Width);

                        string actualHeight = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_Height_Id, "value");
                        Assert.AreEqual(Height, actualHeight);
                        Report.WriteLine("Displaying height in UI " + actualHeight + "is matching with API value" + Height);

                        string actualDimValue = Gettext(attributeName_xpath, FreightDesp_First_AdditionalItem_DimensionType_Selected_xpath);
                        Assert.AreEqual(DimensionType, actualDimValue);
                        Report.WriteLine("Displaying dimension value in UI " + actualDimValue + "is matching with API value" + DimensionType);

                        break;
                    }
                    else
                    {
                    }
                }

            }
        }

        [Then(@"the Hazardous Materials section of the additional item will be expanded,, if the shipment contained additional hazmat")]
        public void ThenTheHazardousMaterialsSectionOfTheAdditionalItemWillBeExpandedIfTheShipmentContainedAdditionalHazmat()
        {
            if (shipmentViewModels.ItemViewModels != null && shipmentViewModels.ItemViewModels.Count > 1)
            {
                for (var i = 0; i < shipmentViewModels.ItemViewModels.Count; i++)
                {
                    string itemDesc = shipmentViewModels.ItemViewModels[i].ItemDescription;
                    string ActualDesc = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_ItemDescription_Id, "value");

                    if (ActualDesc == itemDesc && shipmentViewModels.ItemViewModels[i].IsHazardous == true)
                    {
                        VerifyElementVisible(attributeName_id, FreightDesp_First_AdditionalItem_UN_Number_Id, "Additional hazmat details");
                        Report.WriteLine("Additional item hazmat details expanded");

                        string unNumb = shipmentViewModels.ItemViewModels[i].ShipmentImportHazMatDetailViewModels.HazMatId;
                        string actUNNumber = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_UN_Number_Id, "value");
                        Assert.AreEqual(unNumb, actUNNumber);
                        Report.WriteLine("Displaying un number in UI " + actUNNumber + " is matching with API " + unNumb);

                        string ccNumber = shipmentViewModels.ItemViewModels[i].ShipmentImportHazMatDetailViewModels.ContactPhone;
                        string actccnNumber = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_CCN_Number_Id, "value");
                        ccNumber.Contains(actccnNumber);
                        Report.WriteLine("Displaying ccn number in UI " + actccnNumber + " is matching with API " + ccNumber);

                        string hazGroup = shipmentViewModels.ItemViewModels[i].ShipmentImportHazMatDetailViewModels.PackageGroup;
                        string actGroup = Gettext(attributeName_xpath, FreightDesp_First_AdditionalItem_SelectHazmatPackageGroup_SelectedValue_xpath);
                        Assert.AreEqual(hazGroup, actGroup);
                        Report.WriteLine("Displaying hazmat group in UI " + actGroup + " is matching with API " + hazGroup);

                        string hazClass= shipmentViewModels.ItemViewModels[i].ShipmentImportHazMatDetailViewModels.HazMatClass;
                        string actClass = Gettext(attributeName_xpath, FreightDesp_First_AdditionalItem_SelectHazmatClass_Selectedvalue_xpath);
                        Assert.AreEqual(hazClass, actClass);
                        Report.WriteLine("Displaying hazmat calss in UI " + actClass + " is matching with API " + hazClass);

                        string conPhone = shipmentViewModels.ItemViewModels[i].ShipmentImportHazMatDetailViewModels.ContactPhone;
                        string actConPhone = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_EmergencyReponsePhoneNumber_Id, "value");
                        conPhone.Contains(actConPhone);
                        Report.WriteLine("Displaying hazmat contact phone in UI " + actConPhone + " is matching with API " + conPhone);

                        string conName = shipmentViewModels.ItemViewModels[i].ShipmentImportHazMatDetailViewModels.ContactName;
                        string actConName = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_EmergencyReponseContactName_Id, "value");
                        Assert.AreEqual(conName, actConName);
                        Report.WriteLine("Displaying hazmat contact phone in UI " + actConName + " is matching with API " + conName);
                    }
                    else
                    {
                        Report.WriteLine("Unable to verify additional hazmat details section as selected shipment does not contain additional hazmat details");
                    }
                }
            }
            else
            {
                Report.WriteLine("Unable to verify additional hazmat details section as selected shipment does not contain additional items");
            }
        }

        [Then(@"the additional Hazardous Materials fields (.*), (.*), (.*), (.*), (.*) and (.*) are editable\.")]
        public void ThenTheAdditionalHazardousMaterialsFieldsAndAreEditable_(string unNumb, string ccnNumb, string hazGroup,
            string hazClass, string hazName, string hazPhone)
        {
            if (shipmentViewModels.ItemViewModels != null && shipmentViewModels.ItemViewModels.Count > 1)
            {
                for (var i = 0; i < shipmentViewModels.ItemViewModels.Count; i++)
                {
                    string itemDesc = shipmentViewModels.ItemViewModels[i].ItemDescription;
                    string ActualDesc = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_ItemDescription_Id, "value");

                    if (ActualDesc == itemDesc && shipmentViewModels.ItemViewModels[i].IsHazardous == true)
                    {
                        bool hazMatValue = shipmentViewModels.ItemViewModels[i].IsHazardous;
                        if (hazMatValue == true)
                        {
                            scrollpagedown();
                            scrollpagedown();
                            SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_UN_Number_Id, unNumb);
                            SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_CCN_Number_Id, ccnNumb);
                            SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_EmergencyReponseContactName_Id, hazName);
                            SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_EmergencyReponsePhoneNumber_Id, hazPhone);
                            Click(attributeName_xpath, FreightDesp_First_AdditionalItem_SelectHazmatPackageGroup_DownDown_xpath);
                            SelectDropdownValueFromList(attributeName_xpath, FreightDesp_First_AdditionalItem_SelectHazmatPackageGroup_DownDown_Values_xpath, hazGroup);
                            Click(attributeName_xpath, FreightDesp_First_AdditionalItem_SelectHazmatClass_DropwDown_xpath);
                            SelectDropdownValueFromList(attributeName_xpath, FreightDesp_First_AdditionalItem_SelectHazmatClass_DropwDown_Values_xpath, hazClass);

                            string actUNNumb = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_UN_Number_Id, "value");
                            Assert.AreEqual(actUNNumb, unNumb);
                            Report.WriteLine("Edited UN Number " + actUNNumb + "is displayin in UI" + unNumb);

                            string actphone = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_EmergencyReponsePhoneNumber_Id, "value");
                            Assert.AreEqual(actphone, hazPhone);
                            Report.WriteLine("Edited contact phone " + actphone + "is displayin in UI" + hazPhone);

                            string actName = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_EmergencyReponseContactName_Id, "value");
                            Assert.AreEqual(actName, hazName);
                            Report.WriteLine("Edited contact name " + actName + "is displayin in UI" + hazName);

                            string actGroup = Gettext(attributeName_xpath, FreightDesp_First_AdditionalItem_SelectHazmatPackageGroup_SelectedValue_xpath);
                            Assert.AreEqual(actGroup, hazGroup);
                            Report.WriteLine("Edited hazmat group " + actGroup + "is displayin in UI" + hazGroup);

                            string actClass = Gettext(attributeName_xpath, FreightDesp_First_AdditionalItem_SelectHazmatClass_Selectedvalue_xpath);
                            Assert.AreEqual(actClass, hazClass);
                            Report.WriteLine("Edited hazmat class " + actClass + "is displayin in UI" + hazClass);
                        }
                        else
                        {
                            Report.WriteLine("Unable to verify additional hazmat details section as selected shipment does not contain additional hazmat details");
                        }
                    }
                }
            }
            else
            {
                Report.WriteLine("Unable to verify additional hazmat details section as selected shipment does not contain additional items");
            }
        }

        [Then(@"the Reference Numbers section will be expanded, if the shipment contained reference numbers")]
        public void ThenTheReferenceNumbersSectionWillBeExpandedIfTheShipmentContainedReferenceNumbers()
        {
            List<String> extRefValue = new List<string>();
            string refValue = "PO Number, Order Number, GL_Code, Ship Ref, PRO, Pickup Number, Delivery Appt Nbr, Ship Ref, Cons Ref, CustInvRef, Delivery Appt Nbr, GL_Code, Job Name, Job Number, Manifest Nbr, Order Number, Pickup Appt Nbr, Pickup Number, PO Number, PRO, Product Code, Project Number, Release Nbr, Sales Order, Ship Ref, WorkOrderNbr";
            string[] values = refValue.Split(',');
            foreach(var v in values)
            {
                extRefValue.Add(v);
            }

            if (shipmentViewModels.ReferenceNumbers != null)
            {
                for(int i = 0; i < shipmentViewModels.ReferenceNumbers.Count; i++)
                {
                    if(extRefValue.Contains(shipmentViewModels.ReferenceNumbers[i].Type))
                    {
                        VerifyElementVisible(attributeName_id, ReferenceNumbers_PONumber_Id, "Reference number section");
                        break;
                    }
                }
            }
            else
            {
                Report.WriteLine("Unable to verify the reference number section as selected shipment does not contain reference numbers");
            }
        }

        [Then(@"the reference numbers from the previous shipment will be populated in the corresponding reference number fields of the return shipment,")]
        public void ThenTheReferenceNumbersFromThePreviousShipmentWillBePopulatedInTheCorrespondingReferenceNumberFieldsOfTheReturnShipment()
        {
            List<String> extRefValue = new List<string>();
            string refValue = "PO Number, Order Number, GL_Code, Ship Ref, PRO, Pickup Number, Delivery Appt Nbr, Ship Ref, Cons Ref, CustInvRef, Delivery Appt Nbr, GL_Code, Job Name, Job Number, Manifest Nbr, Order Number, Pickup Appt Nbr, Pickup Number, PO Number, PRO, Product Code, Project Number, Release Nbr, Sales Order, Ship Ref, WorkOrderNbr";
            string[] values = refValue.Split(',');
            foreach (var v in values)
            {
                extRefValue.Add(v);
            }

            if (shipmentViewModels.ReferenceNumbers != null)
            {
                for (int i = 0; i < shipmentViewModels.ReferenceNumbers.Count; i++)
                {
                    if (extRefValue.Contains(shipmentViewModels.ReferenceNumbers[i].Type) && shipmentViewModels.ReferenceNumbers[i].Type == "PO Number" )
                    {
                        string actPONumber = GetValue(attributeName_id, ReferenceNumbers_PONumber_Id, "value");
                        Assert.AreEqual(shipmentViewModels.ReferenceNumbers[i].ReferenceNumber, actPONumber);
                        Report.WriteLine("Displaying PO number in UI " + actPONumber + "is matching with API " + shipmentViewModels.ReferenceNumbers[i].ReferenceNumber);
                        break;
                    }
                }
            }
            else
            {
                Report.WriteLine("Unable to verify the reference number section as selected shipment does not contain reference numbers");
            }
        }
        
        [Then(@"I am able to edit any of the (.*), (.*) reference numbers,")]
        public void ThenIAmAbleToEditAnyOfTheReferenceNumbers(string poNumb, string p1)
        {
            List<String> extRefValue = new List<String>();
            string refValue = "PO Number, Order Number, GL_Code, Ship Ref, PRO, Pickup Number, Delivery Appt Nbr, Ship Ref, Cons Ref, CustInvRef, Delivery Appt Nbr, GL_Code, Job Name, Job Number, Manifest Nbr, Order Number, Pickup Appt Nbr, Pickup Number, PO Number, PRO, Product Code, Project Number, Release Nbr, Sales Order, Ship Ref, WorkOrderNbr";
            string[] values = refValue.Split(',');
            foreach (var v in values)
            {
                extRefValue.Add(v);
            }

            if (shipmentViewModels.ReferenceNumbers != null)
            {
                for (int i = 0; i < shipmentViewModels.ReferenceNumbers.Count; i++)
                {
                    if (extRefValue.Contains(shipmentViewModels.ReferenceNumbers[i].Type) && shipmentViewModels.ReferenceNumbers[i].Type == "PO Number")
                    {
                        scrollElementIntoView(attributeName_id, ReferenceNumbers_PONumber_Id);
                        SendKeys(attributeName_id, ReferenceNumbers_PONumber_Id, poNumb);
                        string actPONumber = GetValue(attributeName_id, ReferenceNumbers_PONumber_Id, "value");
                        Assert.AreEqual(poNumb, actPONumber);
                        Report.WriteLine("Edited PO number in UI " + poNumb + "is matching with UI " + actPONumber);
                        break;
                    }
                }
            }
            else
            {
                Report.WriteLine("Unable to verify the reference number section as selected shipment does not contain reference numbers");
            }
        }

        [Then(@"the station name - customer name associated to shipment selected will be displayed (.*)")]
        public void ThenTheStationName_CustomerNameAssociatedToShipmentSelectedWillBeDisplayed(string account)
        {
            Report.WriteLine("Verifying the binding customer name in add shipment page");
            string actStation = Gettext(attributeName_xpath, Station_CustomerName_Xpath);
            if(actStation.Contains(account.ToUpper()))
            {
                Report.WriteLine("Displaying customer name in add shipment page");
            }
            else
            {
                Report.WriteLine("Displaying invalid customer name in add shipment page");
                Assert.IsTrue(false);
            }
        }

    }
}
