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
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.ShipmentList_ExternalUsers
{
    [Binding]
    public class ShipmentEntry_AllowCustomerUsers_AccessToSub_Accounts_CopyAndReturnSteps : AddShipments
    {

        ShipmentExtractViewModel shipmentViewModels = null;
        GetQuantityType qType = new GetQuantityType();
        GetWeightType wType = new GetWeightType();
        public string Customernamepassed = null;

        [Given(@"I selected any (.*) Name of (.*) from the customer drop down list on the shipment list page")]
        public void GivenISelectedAnyNameOfFromTheCustomerDropDownListOnTheShipmentListPage(string Sub_Account, string TMS_Type)
        {
            Customernamepassed = Sub_Account;
            Report.WriteLine("Click on the Shipment icon from the left navigation bar");
            Click(attributeName_xpath, ShipmentIcon_Xpath);

            Report.WriteLine("I am on the shipment list page");
            Verifytext(attributeName_xpath, ShipmentList_Title_Xpath, "Shipment List");

            Click(attributeName_xpath, CustomerDropdownExtuser_Xpath);

            if (TMS_Type == "MG")
            {

                Report.WriteLine("Selecting Mg Type" + Sub_Account + "from the Customer drop down list");

                IList<IWebElement> CustomerDropdown_List = GlobalVariables.webDriver.FindElements(By.XPath(CustomerDropdownValesExtuser_Xpath));
                int CustomerNameListCount = CustomerDropdown_List.Count;
                for (int i = 0; i < CustomerNameListCount; i++)
                {
                    if (CustomerDropdown_List[i].Text == Sub_Account)
                    {
                        CustomerDropdown_List[i].Click();
                        break;
                    }
                }
            }
            else 
            {
                Report.WriteLine("Selecting Both type" + Sub_Account + "from the Customer drop down list");

                IList<IWebElement> CustomerDropdown_List = GlobalVariables.webDriver.FindElements(By.XPath(CustomerDropdownValesExtuser_Xpath));
                int CustomerNameListCount = CustomerDropdown_List.Count;
                for (int i = 0; i < CustomerNameListCount; i++)
                {
                    if (CustomerDropdown_List[i].Text == Sub_Account)
                    {
                        CustomerDropdown_List[i].Click();
                        break;
                    }
                }
            }
        }


        [When(@"I click on the Copy Shipment button of any displayed LTL shipment")]
        public void WhenIClickOnTheCopyShipmentButtonOfAnyDisplayedLTLShipment()
        {
            string NoRecordFound = Gettext(attributeName_xpath, ShipmentList_NoRecords_Xpath);
            int records = GetCount(attributeName_xpath, ShipmentList_NoOf_Rows_Xpath);
            if ((records >= 1) && (NoRecordFound != "No Results Found"))
            {
                WaitForElementVisible(attributeName_xpath, ShipmentListGrid_CopyIcon_First_Xpath, "Copy Shipment");
                Report.WriteLine("I click on Copy Shipment Button of Any Displayed LTL Shipment");
                Click(attributeName_xpath, ShipmentListGrid_CopyIcon_First_Xpath);
                DefineTimeOut(5000);

            }

            else
            {
                Report.WriteLine(" No Shipment found ");
            }

        }


        [Then(@"The Copy shipment model will Display")]
        public void ThenTheCopyShipmentModelWillDisplay()
        {
            
            WaitForElementVisible(attributeName_xpath, ShipmentList_CopyIcon_ModelText_Xpath, "Copy the selected shipment and create a new shipment entry?");
            Report.WriteLine("Verify Copy Shipment Model will be displayed with the text");
            Verifytext(attributeName_xpath, ShipmentList_CopyIcon_ModelText_Xpath, "Copy the selected shipment and create a new shipment entry?");
        }


        [When(@"I click on the Cancel button of the Copy Shipment modal")]
        public void WhenIClickOnTheCancelButtonOfTheCopyShipmentModal()
        {
            string NoRecordFound = Gettext(attributeName_xpath, ShipmentList_NoRecords_Xpath);
            int records = GetCount(attributeName_xpath, ShipmentList_NoOf_Rows_Xpath);
            if ((records >= 1) && (NoRecordFound != "No Results Found"))
            {
                WaitForElementVisible(attributeName_xpath, ShipmentListGrid_CopyIcon_First_Xpath, "Copy Shipment");
                Report.WriteLine("I click on Copy Shipment Button of Any Displayed LTL Shipment");
                Click(attributeName_xpath, ShipmentListGrid_CopyIcon_First_Xpath);

                Thread.Sleep(5000);
                WaitForElementVisible(attributeName_xpath, ShipmentList_CopyIcon_Model_CancelButton_Xpath,"Cancel");
                Report.WriteLine("I click on Cancel Button of Copy Shipment Model");
                Click(attributeName_xpath, ShipmentList_CopyIcon_Model_CancelButton_Xpath);

            }
            else
            {
                Report.WriteLine(" No Shipment found ");
            }
        }

        [Then(@"The Copy Shipment modal will close")]
        public void ThenTheCopyShipmentModalWillClose()
        {
            Thread.Sleep(5000);
            Report.WriteLine("Copy Shipment Model will be closed");
            VerifyElementNotVisible(attributeName_xpath, ShipmentList_CopyIcon_Model_CancelButton_Xpath, "Cancel");
        }

        [When(@"I click on the Copy Shipment button of the Copy Shipment modal")]
        public ShipmentExtractViewModel WhenIClickOnTheCopyShipmentButtonOfTheCopyShipmentModal()
        {
            string NoRecordFound = Gettext(attributeName_xpath, ShipmentList_NoRecords_Xpath);
            int records = GetCount(attributeName_xpath, ShipmentList_NoOf_Rows_Xpath);
            if ((records >= 1) && (NoRecordFound != "No Results Found"))
            {

                string refNumber = Gettext(attributeName_xpath, ShipmentList_FirstReference_no_Xpath);

                WaitForElementVisible(attributeName_xpath, ShipmentListGrid_CopyIcon_First_Xpath, "Copy Shipment");
                Report.WriteLine("I click on Copy Shipment Button of Any Displayed LTL Shipment");
                Click(attributeName_xpath, ShipmentListGrid_CopyIcon_First_Xpath);

                WaitForElementVisible(attributeName_id, ShipmentList_CopyIcon_Model_CopyShipmentButton_Id, "Copy Shipment");
                Report.WriteLine("I click on the Copy button of the Copy Shipment Model");
                Click(attributeName_id, ShipmentList_CopyIcon_Model_CopyShipmentButton_Id);
                DefineTimeOut(30000);

                string uri = $"MercuryGate/OidLookup";

                //Building Client
                BuildHttpClient client = new BuildHttpClient();
                HttpClient headers = client.BuildHttpClientWithHeaders(Customernamepassed, "application/xml");

                ShipmentExtract ext = new ShipmentExtract();
                shipmentViewModels = ext.getShipmentData(uri, headers, refNumber, Customernamepassed);

            }
            else
            {
                Report.WriteLine(" No Shipment found ");
            }

            return shipmentViewModels;
        }



        [Then(@"The customer name will be displayed on the page")]
        public void ThenTheCustomerNameWillBeDisplayedOnThePage()
        {
            Report.WriteLine("Customer Name should be displayed");
            
            string CustomerNameDisplayed = Gettext(attributeName_xpath, CustomerNameDisplayed_Copy_AddShipment_Xpath);
            Assert.AreEqual(Customernamepassed, CustomerNameDisplayed);

        }



        [Then(@"The shipment details of the original shipment will be auto_populated on the Add Shipment LTL page")]
        public void ThenTheShipmentDetailsOfTheOriginalShipmentWillBeAuto_PopulatedOnTheAddShipmentLTLPage()
        {
            Report.WriteLine("Original Shipment Will be auto populated on the Add Shipment LTL page ");
            if (shipmentViewModels.AddressViewModels != null)
            {
                // Shipping From and Shipping To Section
                for (var i = 0; i < shipmentViewModels.AddressViewModels.Count; i++)
                {
                    if (shipmentViewModels.AddressViewModels[i].Type.ToLower() == "origin")
                    {
                        Report.WriteLine("Verifying for the Origin - Shipping From Section -Location name,Location address,Location address line 2,Zip/postal code,Country,City,State/province");

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
                             if (OriginCountry == "USA")
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

                        // Shipping from contact info
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
                
               else if (shipmentViewModels.AddressViewModels[i].Type.ToLower() == "destination")
                    {
                        Report.WriteLine("Verifying for the Destination Section - Shipping To - Destination name,Destination address,Destination address line 2,Zip/postal code,Country,City,State/province");

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

                        // Shipping To contact info section
                        string ShipToContactName = shipmentViewModels.ContactViewModels[i].Name;

                        VerifyElementPresent(attributeName_id, ShippingTo_ContactName_Id, "ContactName");
                        string ShipToNameUI = GetValue(attributeName_id, ShippingTo_ContactName_Id, "value");
                        Assert.AreEqual(ShipToContactName.ToUpper(), ShipToNameUI.ToUpper());

                        string ShipToContactPhone = shipmentViewModels.ContactViewModels[i].Phone;
                        string ShipToPhoneUI = GetValue(attributeName_id, ShippingTo_ContactPhone_Id, "value");
                        Assert.AreEqual(ShipToContactPhone, ShipToPhoneUI);

                        string ShipToContactEmail = shipmentViewModels.ContactViewModels[i].Email;
                        string ShipToEmailUI = GetValue(attributeName_id, ShippingTo_ContactEmail_Id, "value");
                        Assert.AreEqual(ShipToContactEmail, ShipToEmailUI);

                        string ShipToConatctFax = shipmentViewModels.ContactViewModels[i].Fax;
                        string ShipToFax = GetValue(attributeName_id, ShippingTo_ContactFax_Id, "value");
                        Assert.AreEqual(ShipToConatctFax, ShipToFax);
                    }
                }


                    // Date Section
                    Report.WriteLine("Default PickUp Date - PickUpDate,ReadyTime,CloseTime");
                    scrollpagedown();

                    VerifyElementVisible(attributeName_xpath, PickUpDate_Xpath, "PickUp Date");
                
                    string Date = shipmentViewModels.EarliestPickupDate;
                    string [] Date1 = Date.Split(' ');
                    string ActualDate = Date1[0];
                  
                    var PickupDate_UI = GetAttribute(attributeName_id, LTL_PickUpDate_Id, "value");
                    Assert.AreEqual(PickupDate_UI, ActualDate);

                    DefineTimeOut(20000);
                    Report.WriteLine("Default Ready Time");
                    string ReadyTime = Gettext(attributeName_xpath, LTL_PickUpReadyTime_Xpath);
                    Assert.AreEqual(ReadyTime, "Ready 08:00 AM");
                    string CloseTime = Gettext(attributeName_xpath, LTL_PickUpCloseTime_Xpath);
                    Assert.AreEqual(CloseTime, "Close 05:00 PM");


                    // Freight Description Section

                    Report.WriteLine("Verifying the Freight Description Section - Class,NMFC,Quantity,QuantityType,ItemDescription,Weight,WeightType,HMaterials,DLength,DWidth,DHeight,DType");
                    for (var j = 0; j < shipmentViewModels.ItemViewModels.Count; j++)
                    {

                        string Class = shipmentViewModels.ItemViewModels[j].Classification;
                        string[] Classi = Class.Split('.');
                        string classification = Classi[0];
                        string ActualClass = GetValue(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id, "value");
                        Assert.AreEqual(classification, ActualClass);

                        string NMFC = shipmentViewModels.ItemViewModels[j].NmfcCode;
                        string ActualNMFC = GetValue(attributeName_id, FreightDesp_FirstItem_NMFC_Id, "value");
                        Assert.AreEqual(NMFC, ActualNMFC);

                        string Quantity = shipmentViewModels.ItemViewModels[j].Quantity;
                        string[] Quan = Quantity.Split('.');
                        string QuantityAPI = Quan[0];
                        string ActualQuantity = GetValue(attributeName_id, FreightDesp_FirstItem_Quantity_Id, "value");
                        Assert.AreEqual(QuantityAPI, ActualQuantity);

                        string QuanType = shipmentViewModels.ItemViewModels[j].QuantityUnit;
                        string ActualQuanType = Gettext(attributeName_xpath, FreightDesp_FirstItem_QuantityType_xpath);
                        GetQuantityType val = new GetQuantityType();
                        string ExpQuantityType = val.Getquantity(QuanType);
                        Assert.AreEqual(ExpQuantityType, ActualQuanType);

                        string ItemDescription = shipmentViewModels.ItemViewModels[j].ItemDescription;
                        string ActualItemDescription = GetValue(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id, "value");
                        Assert.AreEqual(ItemDescription, ActualItemDescription);

                        string Weight = shipmentViewModels.ItemViewModels[j].Weight;
                        string apiweight = Weight;
                        string[] weight = apiweight.Split('.');
                        string weightAPI = weight[0];
                        string ActualWeight = GetValue(attributeName_id, FreightDesp_FirstItem_Weight_Id, "value");
                        Assert.AreEqual(weightAPI, ActualWeight);

                        string WeightType = shipmentViewModels.ItemViewModels[j].WeightUnit;
                        string ActualWeightType = Gettext(attributeName_xpath, FreightDesp_FirstItem_WeightType_xpath);
                        GetWeightType vals = new GetWeightType();
                        string ExpWeightType = vals.GetWeight(WeightType);
                        Assert.AreEqual(ExpWeightType, ActualWeightType);

                        bool Hazardous = shipmentViewModels.ItemViewModels[j].IsHazardous;
                        if (Hazardous == true)
                        {

                            VerifyElementChecked(attributeName_id, FreightDesp_FirstItem_Hazardous_Yes_Input_Id, "Hazardous");

                            Report.WriteLine("Verifying the Hazardous field");

                            VerifyElementPresent(attributeName_id, FreightDesp_FirstItem_UN_Number_Id, "UNNum");
                            string UNNumValue = shipmentViewModels.ItemViewModels[j].ShipmentImportHazMatDetailViewModels.HazMatId;
                            string UNNUMUI = GetValue(attributeName_id, FreightDesp_FirstItem_UN_Number_Id, "value");
                            Assert.AreEqual(UNNumValue, UNNUMUI);

                            string CCNNum = shipmentViewModels.ItemViewModels[j].ShipmentImportHazMatDetailViewModels.ContactPhone;
                            string CCNNumUI = GetValue(attributeName_id, FreightDesp_FirstItem_CCN_Number_Id, "value");
                            if (CCNNum.Contains(CCNNumUI))
                            {
                                Report.WriteLine("CCN number is autopopulated");

                            }
                            else
                            {
                                Report.WriteFailure("Invaild");
                            }


                            string HazGrp = shipmentViewModels.ItemViewModels[j].ShipmentImportHazMatDetailViewModels.PackageGroup;
                            string HazGrpUI = Gettext(attributeName_xpath, FreightDesp_FirstItem_SelectHazmatPackageGroup_DownDown_xpath);
                            Assert.AreEqual(HazGrp, HazGrpUI);

                            string HazClass = shipmentViewModels.ItemViewModels[j].ShipmentImportHazMatDetailViewModels.HazMatClass;
                            string HazClassUI = Gettext(attributeName_xpath, FreightDesp_FirstItem_SelectHazmatClass_DropwDown_xpath);
                            Assert.AreEqual(HazClass, HazClassUI);

                            string EmergencyName = shipmentViewModels.ItemViewModels[j].ShipmentImportHazMatDetailViewModels.ContactName;
                            string EmergencyNameUI = GetValue(attributeName_id, FreightDesp_FirstItem_EmergencyReponseContactName_Id, "value");
                            Assert.AreEqual(EmergencyName.ToUpper(), EmergencyNameUI.ToUpper());

                            string EmergencyPhone = shipmentViewModels.ItemViewModels[j].ShipmentImportHazMatDetailViewModels.ContactPhone;
                            string EmergencyPhoneUI = GetValue(attributeName_id, FreightDesp_FirstItem_EmergencyReponsePhoneNumber_Id, "value");
                            if (EmergencyPhone.Contains(EmergencyPhoneUI))
                            {
                                Report.WriteLine("Phone number is auto populated");
                            }
                            else
                            {
                                Report.WriteFailure("Invalid");
                            }

                        }

                        else if (Hazardous == false)
                        {
                            VerifyElementChecked(attributeName_id, FreightDesp_FirstItem_Hazardous_No_Input_Id, "Hazardous");

                        }
                        else
                        {
                            Report.WriteFailure("Invalid");
                        }

                        string DLength = shipmentViewModels.ItemViewModels[j].Length;
                        string[] dLength = DLength.Split('.');
                        string dLengthtAPI = dLength[0];
                        string ActualDLength = GetValue(attributeName_id, FreightDesp_FirstItem_Length_Id, "value");
                        Assert.AreEqual(dLengthtAPI, ActualDLength);

                        string DWidth = shipmentViewModels.ItemViewModels[j].Width;
                        string[] dWidth = DWidth.Split('.');
                        string dWidthAPI = dWidth[0];
                        string ActualWidth = GetValue(attributeName_id, FreightDesp_FirstItem_Width_Id, "value");
                        Assert.AreEqual(dWidthAPI, ActualWidth);

                        string DHeight = shipmentViewModels.ItemViewModels[j].Height;
                        string[] dHeight = DHeight.Split('.');
                        string dHeightAPI = dHeight[0];
                        string ActualHeight = GetValue(attributeName_id, FreightDesp_FirstItem_Height_Id, "value");
                        Assert.AreEqual(dHeightAPI, ActualHeight);

                        string DType = shipmentViewModels.ItemViewModels[j].DimensionUnit;
                        string DTypeVal = DType.ToUpper();
                        string ActualDType = Gettext(attributeName_xpath, FreightDesp_FirstItem_DimensionType_xpath);
                        Assert.AreEqual(DTypeVal, ActualDType);

                    }

                    scrollpagedown();
                    scrollpagedown();


                    // Reference Numbers Section
                    Report.WriteLine("Verifying the Reference number section");
                    List<String> extRefValue = new List<string>();
                    string refValue = "PO Number, Order Number, GL_Code, Ship Ref, PRO, Pickup Number, Delivery Appt Nbr, Ship Ref, Cons Ref, CustInvRef, Delivery Appt Nbr, GL_Code, Job Name, Job Number, Manifest Nbr, Order Number, Pickup Appt Nbr, Pickup Number, PO Number, PRO, Product Code, Project Number, Release Nbr, Sales Order, Ship Ref, WorkOrderNbr";
                    string[] values = refValue.Split(',');
                    foreach (var v in values)
                    {
                        extRefValue.Add(v);
                    }

                    if (shipmentViewModels.ReferenceNumbers != null)
                    {
                        for (int r = 0; r < shipmentViewModels.ReferenceNumbers.Count; r++)
                        {
                            if (extRefValue.Contains(shipmentViewModels.ReferenceNumbers[r].Type) && shipmentViewModels.ReferenceNumbers[r].Type == "PO Number")
                            {
                                string actPONumber = GetValue(attributeName_id, ReferenceNumbers_PONumber_Id, "value");
                                Assert.AreEqual(shipmentViewModels.ReferenceNumbers[r].ReferenceNumber, actPONumber);
                                Report.WriteLine("Displaying PO number in UI " + actPONumber + "is matching with API " + shipmentViewModels.ReferenceNumbers[r].ReferenceNumber);
                                break;
                            }
                        }
                    }
                    else
                    {
                        Report.WriteLine("Unable to verify the reference number section as selected shipment does not contain reference numbers");
                    }


                    // Special Instruction ,Insured Value and Insured Value type

                    Report.WriteLine("Auto populated field DefaultSpecialInstruction,InsuredValue,InsuredValueType ");
                    scrollpagedown();
                    scrollpagedown();
                    int accId = DBHelper.GetAccountIdforAccountName(Customernamepassed);
                    CustomerAccount accvalue = DBHelper.GetAccountDetails(accId);
                    string actSpcInst = GetValue(attributeName_id, DefaultSpecialIntructions_Comments_Id, "value");
                    string specialIns = accvalue.SpecialInstructions;
                    Assert.AreEqual(specialIns, actSpcInst);

                    if (shipmentViewModels.ItemViewModels != null)
                    {
                        for (var k = 0; k < shipmentViewModels.ItemViewModels.Count; k++)
                        {
                            string InsuredValue = shipmentViewModels.ItemViewModels[k].DollarValue;
                            string ActualInsuredValue = GetValue(attributeName_id, InsuredValue_TextBox_Id, "value");
                            Assert.AreEqual(InsuredValue, ActualInsuredValue);
                            if (shipmentViewModels.ReferenceNumbers != null)
                            {
                                for (var l = 0; l < shipmentViewModels.ReferenceNumbers.Count; l++)
                                {
                                    if (shipmentViewModels.ReferenceNumbers[l].Type == "InsuredType")
                                    {
                                        string InsuredType = shipmentViewModels.ReferenceNumbers[l].ReferenceNumber;
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
            }
        



        [When(@"I click on the Return Shipment button of any displayed LTL shipment")]
        public void WhenIClickOnTheReturnShipmentButtonOfAnyDisplayedLTLShipment()
        {
            string NoRecordFound = Gettext(attributeName_xpath, ShipmentList_NoRecords_Xpath);
            int records = GetCount(attributeName_xpath, ShipmentList_NoOf_Rows_Xpath);
            if ((records >= 1) && (NoRecordFound != "No Results Found"))
            {

                Report.WriteLine("Click on the Return Shipment Button");
                Click(attributeName_xpath, ShipmentListGrid_RetrunShipmentIcon_First_Xpath);
            }
            else
            {
                Report.WriteLine("No Shipment found");
            }
        }

        [Then(@"The Return Shipment Modal will displayed")]
        public void ThenTheReturnShipmentModalWillDisplayed()
        {
            WaitForElementVisible(attributeName_xpath, ShipmentList_ReturnShipmentHeaderText_xpath, "Create Return Shipment");
            Report.WriteLine("Verify Return Shipment model is displayed");
            VerifyElementVisible(attributeName_xpath, ShipmentList_ReturnShipmentHeaderText_xpath, "Create Return Shipment");
        }

        [When(@"I click on the No button of the Create Return Shipment modal")]
        public void WhenIClickOnTheNoButtonOfTheCreateReturnShipmentModal()
        {
            string NoRecordFound = Gettext(attributeName_xpath, ShipmentList_NoRecords_Xpath);
            int records = GetCount(attributeName_xpath, ShipmentList_NoOf_Rows_Xpath);
            if ((records >= 1) && (NoRecordFound != "No Results Found"))
            {

                Report.WriteLine("Click on the Create Return Shipment Button of any Shipment");
                Click(attributeName_xpath, ShipmentListGrid_RetrunShipmentIcon_First_Xpath);

                WaitForElementPresent(attributeName_xpath, ShipmentList_LTLPage_Header_Xpath, "Add Shipment (LTL)");

                Thread.Sleep(3000);
                Report.WriteLine("Click on the No Button of the Create Return Shipment Model");
                Click(attributeName_xpath, ShipmentList_ReturnShipment_No_Xpath);
            }
            else
            {
                Report.WriteLine("No shipment found");
            }
        }


        [Then(@"The Create Return Shipment modal will close")]
        public void ThenTheCreateReturnShipmentModalWillClose()
        {
            Thread.Sleep(3000);
            Report.WriteLine("Create Return Shipment model will be closed");
            VerifyElementNotVisible(attributeName_xpath, ShipmentList_ReturnShipmentHeaderText_xpath, "Create Return Shipment");
        }

        [When(@"I click on the Yes button of the Create Return Shipment modal")]
        public ShipmentExtractViewModel WhenIClickOnTheYesButtonOfTheCreateReturnShipmentModal()
        {
            string NoRecordFound = Gettext(attributeName_xpath, ShipmentList_NoRecords_Xpath);
            int records = GetCount(attributeName_xpath, ShipmentList_NoOf_Rows_Xpath);
            if ((records >= 1) && (NoRecordFound != "No Results Found"))
            {

                string refNumber = Gettext(attributeName_xpath, ShipmentList_FirstReference_no_Xpath);
                Report.WriteLine("Click on the Create Return Shipment Button of any Shipment");
                Click(attributeName_xpath, ShipmentListGrid_RetrunShipmentIcon_First_Xpath);

                WaitForElementVisible(attributeName_xpath, ShipmentList_ReturnShipmentHeaderText_xpath, "Create Return Shipment");
                Report.WriteLine("Click on the Yes button of the Create Return Shipment model");
                Click(attributeName_xpath, ShipmentList_ReturnShipment_Yes_Xpath);

                GlobalVariables.webDriver.WaitForPageLoad();
           
                string uri = $"MercuryGate/OidLookup";

                //Building Client
                BuildHttpClient client = new BuildHttpClient();
                HttpClient headers = client.BuildHttpClientWithHeaders("Admin", "application/xml");

                ShipmentExtract ext = new ShipmentExtract();
                shipmentViewModels = ext.getShipmentData(uri, headers, refNumber, "Admin");
            }


            else
            {
                Report.WriteLine("No Shipment found");
            }
            return shipmentViewModels;
        }


        [Then(@"Shipping To original shipment will be displayed in the Shipping From Location and Shipping From Contact information section")]
        public void ThenShippingToOriginalShipmentWillBeDisplayedInTheShippingFromLocationAndShippingFromContactInformationSection()
        {
            if (shipmentViewModels.AddressViewModels != null)
            {
                for (var i = 1; i < shipmentViewModels.AddressViewModels.Count; i++)
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

                    if (shipmentViewModels.ContactViewModels[i].ContactType.ToLower() == "destination")
                    {
                        if (shipmentViewModels.ContactViewModels[i].Name == string.Empty && shipmentViewModels.ContactViewModels[i].Phone == string.Empty && shipmentViewModels.ContactViewModels[i].Email == string.Empty && shipmentViewModels.ContactViewModels[i].Fax == string.Empty)
                        {
                            Report.WriteLine("Unable to verify the shipping from contact expand functionality as shipment does not have contact info");
                        }
                        else
                        {
                            Report.WriteLine("Verify the Shipping From Contact Info Section for Auto-popup value");
                            for (var a = 1; a < shipmentViewModels.ContactViewModels.Count; a++)
                            {
                                // Shipping From
                                string ShipFromContactName = shipmentViewModels.ContactViewModels[a].Name;
                                VerifyElementPresent(attributeName_id, ShippingFrom_ContactName_Id, "ContactName");
                                string ShipFromNameUI = GetValue(attributeName_id, ShippingFrom_ContactName_Id, "value");
                                Assert.AreEqual(ShipFromContactName.ToUpper(), ShipFromNameUI.ToUpper());

                                string ShipFromContactPhone = shipmentViewModels.ContactViewModels[a].Phone;
                                string ShipFromPhoneUI = GetValue(attributeName_id, ShippingFrom_ContactPhone_Id, "value");
                                Assert.AreEqual(ShipFromContactPhone, ShipFromPhoneUI);

                                string ShipFromContactEmail = shipmentViewModels.ContactViewModels[a].Email;
                                string ShipFromEmailUI = GetValue(attributeName_id, ShippingFrom_ContactEmail_Id, "value");
                                Assert.AreEqual(ShipFromContactEmail, ShipFromEmailUI);

                                string ShipFromConatctFax = shipmentViewModels.ContactViewModels[a].Fax;
                                string ShipFromFax = GetValue(attributeName_id, ShippingFrom_ContactFax_Id, "value");
                                Assert.AreEqual(ShipFromConatctFax, ShipFromFax);

                            }
                        }
                    }
                }
            }

            else
            {
                Report.WriteLine("Address data didnt retrun from API");
                Assert.IsTrue(false);
            }


        }

        [Then(@"Shipping From original shipment will be displayed in the Shipping To Location and Shipping To Contact information section")]
        public void ThenShippingFromOriginalShipmentWillBeDisplayedInTheShippingToLocationAndShippingToContactInformationSection()
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


                    if (shipmentViewModels.ContactViewModels[i].ContactType.ToLower() == "origin")
                    {
                        if (shipmentViewModels.ContactViewModels[i].Name == string.Empty && shipmentViewModels.ContactViewModels[i].Phone == string.Empty && shipmentViewModels.ContactViewModels[i].Email == string.Empty && shipmentViewModels.ContactViewModels[i].Fax == string.Empty)
                        {
                            Report.WriteLine("Unable to verify the shipping To contact expand functionality as shipment does not have contact info");
                        }
                        else
                        {
                            Report.WriteLine("Verify the Shipping To Contact Info Section for Auto-popup value");
                            for (var a = 0; a < shipmentViewModels.ContactViewModels.Count; a++)
                            {
                                // Shipping From
                                string ShipFromContactName = shipmentViewModels.ContactViewModels[a].Name;
                                VerifyElementPresent(attributeName_id, ShippingFrom_ContactName_Id, "ContactName");
                                string ShipFromNameUI = GetValue(attributeName_id, ShippingFrom_ContactName_Id, "value");
                                Assert.AreEqual(ShipFromContactName.ToUpper(), ShipFromNameUI.ToUpper());

                                string ShipFromContactPhone = shipmentViewModels.ContactViewModels[a].Phone;
                                string ShipFromPhoneUI = GetValue(attributeName_id, ShippingFrom_ContactPhone_Id, "value");
                                Assert.AreEqual(ShipFromContactPhone, ShipFromPhoneUI);

                                string ShipFromContactEmail = shipmentViewModels.ContactViewModels[a].Email;
                                string ShipFromEmailUI = GetValue(attributeName_id, ShippingFrom_ContactEmail_Id, "value");
                                Assert.AreEqual(ShipFromContactEmail, ShipFromEmailUI);

                                string ShipFromConatctFax = shipmentViewModels.ContactViewModels[a].Fax;
                                string ShipFromFax = GetValue(attributeName_id, ShippingFrom_ContactFax_Id, "value");
                                Assert.AreEqual(ShipFromConatctFax, ShipFromFax);

                            }
                        }
                    }
                    
                   
                }
            }
            else
            {
                Report.WriteLine("Address data didnt retrun from API");
                Assert.IsTrue(false);
            }
        }


        [Then(@"The Pickup Date will be defaulted to the current date")]
        public void ThenThePickupDateWillBeDefaultedToTheCurrentDate()
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            Report.WriteLine("Verifying default PickUp Date");
            VerifyElementVisible(attributeName_xpath, PickUpDate_Xpath, "PickUp Date");
            DateTime today = DateTime.Today;
            string s_today = today.ToString("MM/dd/yyyy");
            var PickupDate_UI = GetAttribute(attributeName_xpath, PickUpDate_Xpath, "value");
            Assert.AreEqual(PickupDate_UI, s_today);
            Report.WriteLine("Pickup date is binding default to today's date");

            string actualPickReady = Gettext(attributeName_xpath, LTL_PickUpReadyTime_SelectedValue_Xpath);
            string actpickReady = actualPickReady.Remove(0, 5);
            Assert.AreEqual(actpickReady.Trim(), "08:00 AM");
            Report.WriteLine("Binding expected ready time " + actpickReady + "in UI");

            string actualPickClose = Gettext(attributeName_xpath, LTL_PickUpCloseTime_SelectedValue_Xpath);
            string actpickClose = actualPickClose.Remove(0, 5);
            Assert.AreEqual(actpickClose.Trim(), "05:00 PM");
            Report.WriteLine("Binding expected close time " + actpickClose + "in UI");
        }

        [Then(@"The Freight Description information of the original shipment will be auto populated")]
        public void ThenTheFreightDescriptionInformationOfTheOriginalShipmentWillBeAutoPopulated()
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
                        Assert.AreEqual(weight, ActualWeight + ".0");
                        Report.WriteLine("Displaying weight in UI " + ActualWeight + "is matching with API value" + weight);

                        string weightUnitType = shipmentViewModels.ItemViewModels[i].WeightUnit;
                        string weightUnit = wType.GetWeight(weightUnitType);
                        string actualWeightUnit = Gettext(attributeName_xpath, FreightDesp_FirstItem_WeightType_xpath);
                        Assert.AreEqual(weightUnit.ToUpper(), actualWeightUnit.ToUpper());
                        Report.WriteLine("Displaying weight unit in UI " + actualWeightUnit + "is matching with API value" + weightUnit);

                        string length = shipmentViewModels.ItemViewModels[i].Length;
                        string actualLength = GetValue(attributeName_id, FreightDesp_FirstItem_Length_Id, "value");
                        Assert.AreEqual(length, actualLength + ".0");
                        Report.WriteLine("Displaying length in UI " + actualLength + "is matching with API value" + length);

                        string width = shipmentViewModels.ItemViewModels[i].Width;
                        string actualWidth = GetValue(attributeName_id, FreightDesp_FirstItem_Width_Id, "value");
                        Assert.AreEqual(width, actualWidth + ".0");
                        Report.WriteLine("Displaying width in UI " + actualWidth + "is matching with API value" + width);

                        string height = shipmentViewModels.ItemViewModels[i].Height;
                        string actualHeight = GetValue(attributeName_id, FreightDesp_FirstItem_Height_Id, "value");
                        Assert.AreEqual(height, actualHeight + ".0");
                        Report.WriteLine("Displaying height in UI " + actualHeight + "is matching with API value" + height);

                        string dimValue = shipmentViewModels.ItemViewModels[i].DimensionUnit;
                        string actualDimValue = Gettext(attributeName_xpath, FreightDesp_FirstItem_DimensionType_SelectedValue_xpath);
                        Assert.AreEqual(dimValue.ToUpper(), actualDimValue.ToUpper());
                        Report.WriteLine("Displaying dimension value in UI " + actualDimValue + "is matching with API value" + dimValue);

                        bool hazMatValue = shipmentViewModels.ItemViewModels[i].IsHazardous;
                        if (hazMatValue == true)
                        {
                            VerifyElementChecked(attributeName_id, FreightDesp_FirstItem_Hazardous_Yes_Input_Id, "Hazmat Yes");
                            Report.WriteLine("Verifying the Hazardous field");

                            VerifyElementPresent(attributeName_id, FreightDesp_FirstItem_UN_Number_Id, "UNNum");
                            string UNNumValue = shipmentViewModels.ItemViewModels[i].ShipmentImportHazMatDetailViewModels.HazMatId;
                            string UNNUMUI = GetValue(attributeName_id, FreightDesp_FirstItem_UN_Number_Id, "value");
                            Assert.AreEqual(UNNumValue, UNNUMUI);

                            string CCNNum = shipmentViewModels.ItemViewModels[i].ShipmentImportHazMatDetailViewModels.ContactPhone;
                            string CCNNumUI = GetValue(attributeName_id, FreightDesp_FirstItem_CCN_Number_Id, "value");
                            if (CCNNum.Contains(CCNNumUI))
                            {
                                Report.WriteLine("CCN number is autopopulated");

                            }
                            else
                            {
                                Report.WriteFailure("Invaild");
                            }


                            string HazGrp = shipmentViewModels.ItemViewModels[i].ShipmentImportHazMatDetailViewModels.PackageGroup;
                            string HazGrpUI = Gettext(attributeName_xpath, FreightDesp_FirstItem_SelectHazmatPackageGroup_DownDown_xpath);
                            Assert.AreEqual(HazGrp, HazGrpUI);

                            string HazClass = shipmentViewModels.ItemViewModels[i].ShipmentImportHazMatDetailViewModels.HazMatClass;
                            string HazClassUI = Gettext(attributeName_xpath, FreightDesp_FirstItem_SelectHazmatClass_DropwDown_xpath);
                            Assert.AreEqual(HazClass, HazClassUI);

                            string EmergencyName = shipmentViewModels.ItemViewModels[i].ShipmentImportHazMatDetailViewModels.ContactName;
                            string EmergencyNameUI = GetValue(attributeName_id, FreightDesp_FirstItem_EmergencyReponseContactName_Id, "value");
                            Assert.AreEqual(EmergencyName.ToUpper(), EmergencyNameUI.ToUpper());

                            string EmergencyPhone = shipmentViewModels.ItemViewModels[i].ShipmentImportHazMatDetailViewModels.ContactPhone;
                            string EmergencyPhoneUI = GetValue(attributeName_id, FreightDesp_FirstItem_EmergencyReponsePhoneNumber_Id, "value");
                            if (EmergencyPhone.Contains(EmergencyPhoneUI))
                            {
                                Report.WriteLine("Phone number is auto populated");
                            }
                            else
                            {
                                Report.WriteFailure("Invalid");
                            }

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

        [Then(@"The Reference Numbers of the original shipment will be auto populated")]
        public void ThenTheReferenceNumbersOfTheOriginalShipmentWillBeAutoPopulated()
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
                    if (extRefValue.Contains(shipmentViewModels.ReferenceNumbers[i].Type) && shipmentViewModels.ReferenceNumbers[i].Type == "PO Number")
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

        [Then(@"The Special Instructions field will be auto-populated when Special Instructions have be associated to the sub_account")]
        public void ThenTheSpecialInstructionsFieldWillBeAuto_PopulatedWhenSpecialInstructionsHaveBeAssociatedToTheSub_Account()
        {
            int accId = DBHelper.GetAccountIdforAccountName(Customernamepassed);
            CustomerAccount accvalue = DBHelper.GetAccountDetails(accId);
            string actSpcInst = GetValue(attributeName_id, DefaultSpecialIntructions_Comments_Id, "value");
            Assert.AreEqual(accvalue.SpecialInstructions, actSpcInst);
        }


        [Then(@"The Accessorials from the original shipment will not be applied to the Return shipment")]
        public void ThenTheAccessorialsFromTheOriginalShipmentWillNotBeAppliedToTheReturnShipment()
        {
            scrollPageup();
            scrollPageup();
            scrollPageup();
            Report.WriteLine("Accessorials From the Original Shipment Will not be applied");
            string Shippingfrom = GetValue(attributeName_xpath, ShippingFrom_ServicesAccessorial_DropDown_xpath,"value");
            if(Shippingfrom == "Click to add services & accessorials...")
            {
                Report.WriteLine("No Accessorial is selected in shipping From section");
            }
            else
            {
                Report.WriteFailure("Accessorial is present");
            }

            string ShippingTo = GetValue(attributeName_xpath, ShippingTo_ServicesAccessorial_DropDown_xpath,"value");
            if(ShippingTo == "Click to add services & accessorials...")
            {
                Report.WriteLine("No Accessorial is selected in shipping To Section");
 
            }
            else
            {
                Report.WriteFailure("Accessorial is Present");
            }


        }

        [Then(@"The shipment value from the original shipment will not be applied to the Return shipment")]
        public void ThenTheShipmentValueFromTheOriginalShipmentWillNotBeAppliedToTheReturnShipment()
        {

            scrollpagedown();
            scrollpagedown();
            scrollpagedown();

            string OriginalShipmentvalue = GetValue(attributeName_id, InsuredValue_TextBox_Id,"value");
          
            if (OriginalShipmentvalue == "")
            {
                Report.WriteLine("Shipment value show " + OriginalShipmentvalue + "as no value from original shipment");
            }
            else
            {
                Report.WriteFailure("Showing value" + OriginalShipmentvalue);
            }
        }



    }
}


