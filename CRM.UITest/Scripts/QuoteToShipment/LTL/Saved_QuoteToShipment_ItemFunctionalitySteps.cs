using CRM.UITest.CommonMethods;
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

namespace CRM.UITest.Scripts.QuoteToShipment.LTL
{
    [Binding]
    public class Saved_QuoteToShipment_ItemFunctionalitySteps : AddShipments
    {
        CommonMethodsCrm crm = new CommonMethodsCrm();
        ShipmentExtractViewModel shipmentViewModels = null;

        [Given(@"I am on the Quote details section of an non expired quote - (.*),(.*)")]
        public ShipmentExtractViewModel GivenIAmOnTheQuoteDetailsSectionOfAnNonExpiredQuote_(string Usertype, string CustName)
        {
            Click(attributeName_xpath, QuoteIcon_Xpath);
            Thread.Sleep(5000);
            int QuoteList = 0;
            if (Usertype == "Internal")
            {
                Click(attributeName_xpath, QuoteCustomerSelectionDropdown_Xpath);

                IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(QuoteCustomerSelectioDropdownValues_Xpath));
                int DropDownCount = DropDownList.Count;
                for (int i = 0; i < DropDownCount; i++)
                {
                    if (DropDownList[i].Text == CustName)
                    {
                        DropDownList[i].Click();
                        break;
                    }
                }
                Thread.Sleep(90000);
                Click(attributeName_id, QuoteNew_Id);
                QuoteList = GetCount(attributeName_xpath, QuoteGridAllRecords_Xpath);
                if (QuoteList > 1)
                {
                    string requestNumber = Gettext(attributeName_xpath, QuoteRequestNumInternal_Xpath);
                    Click(attributeName_xpath, QuoteExpandInternal_Xpath);
                    Thread.Sleep(30000);
                    VerifyElementVisible(attributeName_id, QuoteCreateShipment_Id, "CreateShipment");

                    string uri = $"MercuryGate/OidLookup";

                    //Building Client
                    BuildHttpClient client = new BuildHttpClient();
                    HttpClient headers = client.BuildHttpClientWithHeaders("Admin", "application/xml");

                    ShipmentExtract ext = new ShipmentExtract();
                    shipmentViewModels = ext.getShipmentData(uri, headers, requestNumber, "Admin");
                }
                else
                {
                    Report.WriteFailure("No Records found");
                }
            }
            else
            {
                Thread.Sleep(500);
                Click(attributeName_id, QuoteNew_Id);
                QuoteList = GetCount(attributeName_xpath, QuoteGridAllRecords_Xpath);
                if (QuoteList > 1)
                {
                    string requestNumber = Gettext(attributeName_xpath, QuoteRequestNum_Xpath);
                    Click(attributeName_xpath, QuoteExpand_Xpath);
                    Thread.Sleep(30000);
                    VerifyElementVisible(attributeName_id, QuoteCreateShipment_Id, "CreateShipment");
                    string uri = $"MercuryGate/OidLookup";

                    //Building Client
                    BuildHttpClient client = new BuildHttpClient();
                    HttpClient headers = client.BuildHttpClientWithHeaders(CustName, "application/xml");

                    ShipmentExtract ext = new ShipmentExtract();
                    shipmentViewModels = ext.getShipmentData(uri, headers, requestNumber, CustName);
                }
                else
                {
                    Report.WriteFailure("No Records found");
                }
            }
            return shipmentViewModels;
        }


        [Given(@"I am in the Quote Details Section of a non expired LTL quote - ''(.*)'(.*)'")]
        public ShipmentExtractViewModel GivenIAmInTheQuoteDetailsSectionOfANonExpiredLTLQuote_(string UserType, string CusName)
        {
            Click(attributeName_xpath, QuoteIcon_Xpath);
            Thread.Sleep(5000);
            int QuoteList = 0;
            if (UserType == "Internal")
            {
                Click(attributeName_xpath, QuoteCustomerSelectionDropdown_Xpath);

                IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(QuoteCustomerSelectioDropdownValues_Xpath));
                int DropDownCount = DropDownList.Count;
                for (int i = 0; i < DropDownCount; i++)
                {
                    if (DropDownList[i].Text == CusName)
                    {
                        DropDownList[i].Click();
                        break;
                    }
                }
                Thread.Sleep(90000);
                Click(attributeName_id, QuoteNew_Id);
                QuoteList = GetCount(attributeName_xpath, QuoteGridAllRecords_Xpath);
                if (QuoteList > 1)
                {
                    string requestNumber = Gettext(attributeName_xpath, QuoteRequestNumInternal_Xpath);
                    Click(attributeName_xpath, QuoteExpandInternal_Xpath);
                    Thread.Sleep(30000);
                    VerifyElementVisible(attributeName_id, QuoteCreateShipment_Id, "CreateShipment");

                    string uri = $"MercuryGate/OidLookup";

                    //Building Client
                    BuildHttpClient client = new BuildHttpClient();
                    HttpClient headers = client.BuildHttpClientWithHeaders("Admin", "application/xml");

                    ShipmentExtract ext = new ShipmentExtract();
                    shipmentViewModels = ext.getShipmentData(uri, headers, requestNumber, "Admin");
                }
                else
                {
                    Report.WriteFailure("No Records found");
                }
            }
            else
            {
                Thread.Sleep(500);
                Click(attributeName_id, QuoteNew_Id);
                QuoteList = GetCount(attributeName_xpath, QuoteGridAllRecords_Xpath);
                if (QuoteList > 1)
                {
                    string requestNumber = Gettext(attributeName_xpath, QuoteRequestNum_Xpath);
                    Click(attributeName_xpath, QuoteExpand_Xpath);
                    Thread.Sleep(30000);
                    VerifyElementVisible(attributeName_id, QuoteCreateShipment_Id, "CreateShipment");
                    string uri = $"MercuryGate/OidLookup";

                    //Building Client
                    BuildHttpClient client = new BuildHttpClient();
                    HttpClient headers = client.BuildHttpClientWithHeaders(CusName, "application/xml");

                    ShipmentExtract ext = new ShipmentExtract();
                    shipmentViewModels = ext.getShipmentData(uri, headers, requestNumber, CusName);
                }
                else
                {
                    Report.WriteFailure("No Records found");
                }
            }
            return shipmentViewModels;
        }


        [Given(@"I am in the Quote Details Section of a non expired LTL quote which contains an additional item - (.*),(.*)")]
        public ShipmentExtractViewModel GivenIAmInTheQuoteDetailsSectionOfANonExpiredLTLQuoteWhichContainsAnAdditionalItem_(string UserType, string CustomerName)
        {
            Click(attributeName_xpath, QuoteIcon_Xpath);
            Thread.Sleep(5000);
            int QuoteList = 0;
            if (UserType == "Internal")
            {
                Click(attributeName_xpath, QuoteCustomerSelectionDropdown_Xpath);

                IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(QuoteCustomerSelectioDropdownValues_Xpath));
                int DropDownCount = DropDownList.Count;
                for (int i = 0; i < DropDownCount; i++)
                {
                    if (DropDownList[i].Text == CustomerName)
                    {
                        DropDownList[i].Click();
                        break;
                    }
                }
                Thread.Sleep(500);
                Click(attributeName_id, QuoteNew_Id);
                QuoteList = GetCount(attributeName_xpath, QuoteGridAllRecords_Xpath);
                if (QuoteList > 1)
                {
                    string requestNumber = Gettext(attributeName_xpath, QuoteRequestNumInternal_Xpath);
                    Click(attributeName_xpath, QuoteExpandInternal_Xpath);
                    VerifyElementVisible(attributeName_id, QuoteCreateShipment_Id, "CreateShipment");

                    string uri = $"MercuryGate/OidLookup";

                    //Building Client
                    BuildHttpClient client = new BuildHttpClient();
                    HttpClient headers = client.BuildHttpClientWithHeaders("Admin", "application/xml");

                    ShipmentExtract ext = new ShipmentExtract();
                    shipmentViewModels = ext.getShipmentData(uri, headers, requestNumber, "Admin");
                }
                else
                {
                    Report.WriteFailure("No Records found");
                }
            }
            else
            {
                Thread.Sleep(500);
                Click(attributeName_id, QuoteNew_Id);
                QuoteList = GetCount(attributeName_xpath, QuoteGridAllRecords_Xpath);
                if (QuoteList > 1)
                {
                    string requestNumber = Gettext(attributeName_xpath, QuoteRequestNum_Xpath);
                    Click(attributeName_xpath, QuoteExpand_Xpath);
                    Thread.Sleep(30000);
                    VerifyElementVisible(attributeName_id, QuoteCreateShipment_Id, "CreateShipment");
                    string uri = $"MercuryGate/OidLookup";

                    //Building Client
                    BuildHttpClient client = new BuildHttpClient();
                    HttpClient headers = client.BuildHttpClientWithHeaders(CustomerName, "application/xml");

                    ShipmentExtract ext = new ShipmentExtract();
                    shipmentViewModels = ext.getShipmentData(uri, headers, requestNumber, CustomerName);
                }
                else
                {
                    Report.WriteFailure("No Records found");
                }
            }
            return shipmentViewModels;
        }

        [Then(@"The Additional Item sections will be expanded")]
        public void ThenTheAdditionalItemSectionsWillBeExpanded()
        {
            Report.WriteLine("Additional Item Section");
            scrollpagedown();
            scrollpagedown();
            if (shipmentViewModels.ItemViewModels != null)
            {
                for (var i = 0; i < shipmentViewModels.ItemViewModels.Count; i++)
                {
                    string Class = shipmentViewModels.ItemViewModels[i].Classification;
                    if (Class == string.Empty)
                    {
                        VerifyElementNotVisible(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id, "Class");
                        Report.WriteLine("Shipment does not contain Add Additional section");
                    }
                    else
                    {
                        VerifyElementPresent(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id, "Class");
                        Report.WriteLine("Shipment contains Add Additional section");

                    }

                }
            }
        }

        [Then(@"And the following fields in the additional item section will be auto-populated with the item info - Class,Quantity,QuantityType,Weight,HMaterials")]
        public void ThenAndTheFollowingFieldsInTheAdditionalItemSectionWillBeAuto_PopulatedWithTheItemInfo_ClassQuantityQuantityTypeWeightHMaterials()
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
                        Assert.AreEqual(classification, actualClass);
                        Report.WriteLine("Displaying classification in UI " + actualClass + "is matching with API value" + classification);

                        string nmfc = shipmentViewModels.ItemViewModels[i].NmfcCode;
                        string actualnmfc = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_NMFC_Id, "value");
                        Assert.AreEqual(nmfc, actualnmfc);
                        Report.WriteLine("Displaying nmfc in UI " + actualnmfc + "is matching with API value" + nmfc);

                        string quantity = shipmentViewModels.ItemViewModels[i].Quantity;
                        string ActualQuantity = GetValue(attributeName_xpath, FreightDesp_First_AdditionalItem_Quantity_xpath, "value");
                        Assert.AreEqual(quantity, ActualQuantity + ".0");
                        Report.WriteLine("Displaying quantity in UI " + ActualQuantity + "is matching with API value" + quantity);

                        string QuanType = shipmentViewModels.ItemViewModels[i].QuantityUnit;
                        string ActualQuanType = Gettext(attributeName_xpath, FreightDesp_FirstItem_QuantityType_xpath);
                        GetQuantityType val = new GetQuantityType();
                        string ExpQuantityType = val.Getquantity(QuanType);
                        Assert.AreEqual(ExpQuantityType, ActualQuanType);

                        string weight = shipmentViewModels.ItemViewModels[i].Weight;
                        string ActualWeight = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_Weight_Id, "value");
                        Assert.AreEqual(weight, ActualWeight);
                        Report.WriteLine("Displaying weight in UI " + ActualWeight + "is matching with API value" + weight);

                        string WeightType = shipmentViewModels.ItemViewModels[i].WeightUnit;
                        string ActualWeightType = Gettext(attributeName_xpath, FreightDesp_FirstItem_WeightType_xpath);
                        GetWeightType vals = new GetWeightType();
                        string ExpWeightType = vals.GetWeight(WeightType);
                        Assert.AreEqual(ExpWeightType, ActualWeightType);

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

        [Then(@"The fields are not editable - (.*),(.*),(.*),(.*)")]
        public void ThenTheFieldsAreNotEditable_(string p0, string p1, string p2, string p3)
        {
            Report.WriteLine("The fields which are not editable in add additional section");
            try
            {
                VerifyElementNotEnabled(attributeName_id, FreightDesp_First_AdditionalItem_SavedClassItem_DropDown_Id, "Class");
                if (shipmentViewModels.ItemViewModels != null && shipmentViewModels.ItemViewModels.Count > 1)
                {
                    for (var i = 0; i < shipmentViewModels.ItemViewModels.Count; i++)
                    {
                        string Quantity = shipmentViewModels.ItemViewModels[i].Quantity;
                        string Quan = Quantity.Remove(1);
                        string ActualQuantity = GetValue(attributeName_xpath, FreightDesp_First_AdditionalItem_QuantityType_xpath, "value");
                        if (ActualQuantity == Quan)
                        {
                            if (ActualQuantity == string.Empty)
                            {
                                VerifyElementEnabled(attributeName_xpath, FreightDesp_First_AdditionalItem_QuantityType_xpath, "Quantity");
                                SendKeys(attributeName_id, attributeName_xpath, "4");

                            }
                            else
                            {
                                VerifyElementNotEnabled(attributeName_id, FreightDesp_First_AdditionalItem_QuantityType_xpath, "Quantity");
                            }



                        }
                    }
                    VerifyElementNotEnabled(attributeName_id, FreightDesp_First_AdditionalItem_Weight_Id, "Weight");
                    VerifyElementNotEnabled(attributeName_xpath, FreightDesp_First_AdditionalItem_Hazardous_Yes_RadioButton_xpath, "Hazardous");
                    VerifyElementNotEnabled(attributeName_xpath, FreightDesp_First_AdditionalItem_Hazardous_No_RadioButton_xpath, "Hazardous");
                }
            }
            catch (Exception)
            {
                Report.WriteLine("Contains No Add Additional information");
            }
        }

        [Then(@"The following fields will be editable - (.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void ThenTheFollowingFieldsWillBeEditable_(string NMFC, string Description, string WeightType, string Length, string Width, string Height, string DType)
        {
            try
            {
                VerifyElementPresent(attributeName_id, FreightDesp_First_AdditionalItem_NMFC_Id, "NMFC");
                SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_NMFC_Id, NMFC);
                SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_ItemDescription_Id, Description);
                SelectDropdownValueFromList(attributeName_xpath, FreightDesp_First_AdditionalItem_WeightTypevalues_xpath, WeightType);
                SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_Length_Id, Length);
                SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_Width_Id, Width);
                SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_Height_Id, Height);
                SelectDropdownValueFromList(attributeName_xpath, FreightDesp_First_AdditionalItem_DimensionTypevalues_xpath, DType);
            }
            catch (Exception)
            {
                Report.WriteLine("Contains no Additional items");
            }
        }


        [Then(@"I will not see the Remove button for the additional item")]
        public void ThenIWillNotSeeTheRemoveButtonForTheAdditionalItem()
        {
            Report.WriteLine("Hidden Remove Button");
            try
            {
                VerifyElementNotVisible(attributeName_xpath, FreightDesp_First_Remove_Button_xpath, "Remove");
            }
            catch(Exception)
            {
                Report.WriteLine("Contains no Additional items");
            }
        }



        
        [Given(@"I am in the Quote Details Section of a non expired LTL quote which does not contain an saved item - (.*),(.*)")]
        public ShipmentExtractViewModel GivenIAmInTheQuoteDetailsSectionOfANonExpiredLTLQuoteWhichDoesNotContainAnSavedItem_(string p0, string p1)
        {
            return shipmentViewModels;
        }

        [Then(@"The harzardous material section should be expanded when quote contained a Hardous material services and accessorials")]
        public void ThenTheHarzardousMaterialSectionShouldBeExpandedWhenQuoteContainedAHardousMaterialServicesAndAccessorials()
        {
            List<string> apiValue = new List<string>();
            Report.WriteLine("Hazardous Materials section");
            scrollpagedown();
            scrollpagedown();
            Thread.Sleep(5000);
            if (shipmentViewModels.ItemViewModels != null)
            {
                //for (var i = 0; i < shipmentViewModels.ShipmentDetailsViewModel.AdditionalServices.Count; i++)
                //{
                apiValue = shipmentViewModels.ShipmentDetailsViewModel.AdditionalServices;
                if (apiValue.Contains("Hazardous Material"))
                {
                    VerifyElementChecked(attributeName_id, FreightDesp_FirstItem_Hazardous_Yes_Input_Id, "Hazardous");
                    VerifyElementPresent(attributeName_id, FreightDesp_FirstItem_UN_Number_Id, "ID");

                }
                else
                {
                    VerifyElementChecked(attributeName_id, FreightDesp_FirstItem_Hazardous_No_Input_Id, "Hazardous");
                    VerifyElementNotVisible(attributeName_id, FreightDesp_FirstItem_UN_Number_Id, "ID");

                }


            }
            // }
        }


        [Then(@"The harzardous material section should be expanded")]
        public void ThenTheHarzardousMaterialSectionShouldBeExpanded()
        {
            List<string> apiValue = new List<string>();
            Report.WriteLine("Hazardous Materials section");
            scrollpagedown();
            if (shipmentViewModels.ItemViewModels != null)
            {
                for (var i = 0; i < shipmentViewModels.ShipmentDetailsViewModel.AdditionalServices.Count; i++)
                {
                    apiValue = shipmentViewModels.ShipmentDetailsViewModel.AdditionalServices;
                    if (apiValue.Contains("Hazardous Material"))
                    {
                        VerifyElementChecked(attributeName_id, FreightDesp_AdditionalItem_Hazardous_Yes_Input_Id, "Hazardous");
                        VerifyElementPresent(attributeName_id, FreightDesp_FirstItem_UN_Number_Id, "ID");
                    }
                    else
                    {
                        VerifyElementChecked(attributeName_id, FreightDesp_FirstItem_Hazardous_No_RadioButton_xpath, "Hazardous");
                        VerifyElementNotVisible(attributeName_id, FreightDesp_FirstItem_UN_Number_Id, "ID");

                    }


                }
            }
        }

        [Then(@"the Hazardous Materials section will be expanded when quote contained a saved item")]
        public void ThenTheHazardousMaterialsSectionWillBeExpandedWhenQuoteContainedASavedItem()
        {
            Report.WriteLine("Hazardous Materials section");
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            Thread.Sleep(5000);
            if (shipmentViewModels.ItemViewModels != null)
            {
                for (var i = 0; i < shipmentViewModels.ItemViewModels.Count; i++)
                {
                    bool Hazardous = shipmentViewModels.ItemViewModels[i].IsHazardous;
                    if (Hazardous == true)
                    {
                        VerifyElementChecked(attributeName_id, FreightDesp_FirstItem_Hazardous_Yes_Input_Id, "Hazardous");
                        VerifyElementPresent(attributeName_id, FreightDesp_FirstItem_UN_Number_Id, "ID");
                    }

                    else if (Hazardous == false)
                    {
                        VerifyElementChecked(attributeName_id, FreightDesp_FirstItem_Hazardous_No_Input_Id, "Hazardous");
                        VerifyElementNotVisible(attributeName_id, FreightDesp_FirstItem_UN_Number_Id, "ID");

                    }
                    else
                    {
                        Report.WriteFailure("Invalid");
                    }

                }

            }
            else
            {
                Report.WriteFailure("No Response");
            }
        }


        [Then(@"the Hazardous Materials section will be expanded")]
        public void ThenTheHazardousMaterialsSectionWillBeExpanded()
        {
            Report.WriteLine("Hazardous Materials section");
            scrollpagedown();
            if (shipmentViewModels.ItemViewModels != null)
            {
                for (var i = 0; i < shipmentViewModels.ItemViewModels.Count; i++)
                {
                    bool Hazardous = shipmentViewModels.ItemViewModels[i].IsHazardous;
                    if (Hazardous == true)
                    {
                        VerifyElementChecked(attributeName_id, FreightDesp_AdditionalItem_Hazardous_Yes_Input_Id, "Hazardous");
                        VerifyElementPresent(attributeName_id, FreightDesp_FirstItem_UN_Number_Id, "ID");
                    }

                    else if (Hazardous == false)
                    {
                        VerifyElementChecked(attributeName_id, FreightDesp_FirstItem_Hazardous_No_RadioButton_xpath, "Hazardous");
                        VerifyElementNotVisible(attributeName_id, FreightDesp_FirstItem_UN_Number_Id, "ID");

                    }
                    else
                    {
                        Report.WriteFailure("Invalid");
                    }

                }

            }
            else
            {
                Report.WriteFailure("No Response");
            }
        }

        [Then(@"The additional item section should be expanded")]
        public void ThenTheAdditionalItemSectionShouldBeExpanded()
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
                        Assert.AreEqual(classification, actualClass);
                        Report.WriteLine("Displaying classification in UI " + actualClass + "is matching with API value" + classification);

                        string nmfc = shipmentViewModels.ItemViewModels[i].NmfcCode;
                        string actualnmfc = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_NMFC_Id, "value");
                        Assert.AreEqual(nmfc, actualnmfc);
                        Report.WriteLine("Displaying nmfc in UI " + actualnmfc + "is matching with API value" + nmfc);

                        string quantity = shipmentViewModels.ItemViewModels[i].Quantity;
                        string ActualQuantity = GetValue(attributeName_xpath, FreightDesp_First_AdditionalItem_Quantity_xpath, "value");
                        Assert.AreEqual(quantity, ActualQuantity + ".0");
                        Report.WriteLine("Displaying quantity in UI " + ActualQuantity + "is matching with API value" + quantity);

                        string QuanType = shipmentViewModels.ItemViewModels[i].QuantityUnit;
                        string ActualQuanType = Gettext(attributeName_xpath, FreightDesp_FirstItem_QuantityType_xpath);
                        GetQuantityType val = new GetQuantityType();
                        string ExpQuantityType = val.Getquantity(QuanType);
                        Assert.AreEqual(ExpQuantityType, ActualQuanType);

                        string weight = shipmentViewModels.ItemViewModels[i].Weight;
                        string ActualWeight = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_Weight_Id, "value");
                        Assert.AreEqual(weight, ActualWeight);
                        Report.WriteLine("Displaying weight in UI " + ActualWeight + "is matching with API value" + weight);

                        string WeightType = shipmentViewModels.ItemViewModels[i].WeightUnit;
                        string ActualWeightType = Gettext(attributeName_xpath, FreightDesp_FirstItem_WeightType_xpath);
                        GetWeightType vals = new GetWeightType();
                        string ExpWeightType = vals.GetWeight(WeightType);
                        Assert.AreEqual(ExpWeightType, ActualWeightType);

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
        [Then(@"Hazardous Material Yes Radio button will be checked with Hazardous material section auto populated")]
        public void ThenHazardousMaterialYesRadioButtonWillBeCheckedWithHazardousMaterialSectionAutoPopulated()
        {
            List<string> apiValue = new List<string>();
            if (shipmentViewModels.ItemViewModels != null && shipmentViewModels.ItemViewModels.Count > 1)
            {
                for (var i = 0; i < shipmentViewModels.ItemViewModels.Count; i++)
                {
                    {
                        string itemDesc = shipmentViewModels.ItemViewModels[i].ItemDescription;
                        string ActualItemDescription = GetValue(attributeName_id, AddAdditionalDesc_Id, "value");

                        if (ActualItemDescription == itemDesc)
                        {
                            apiValue = shipmentViewModels.ShipmentDetailsViewModel.AdditionalServices;
                            if (apiValue.Contains("Hazardous Material"))
                            {
                                VerifyElementChecked(attributeName_id, FreightDesp_AdditionalItem_Hazardous_Yes_Input_Id, "Hazardous");


                            }
                            else
                            {
                                VerifyElementChecked(attributeName_id, FreightDesp_AdditionalItem_Hazardous_No_Input_Id, "Hazmat No");


                            }
                        }
                    }
                }


            }
        }
    }


}
