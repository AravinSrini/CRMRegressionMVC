using System;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using System.Threading;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;


namespace CRM.UITest.Scripts.RateToShipment.LTL.ButtonsAndPageElements
{
    [Binding]
    public class RateRequest_To_Shipment_Buttons_PageElementsSteps : AddShipments
    {
        string Dateselected_Quote;
        string _oServiceAccessorial_Quote;
        string _dServiceAccessorial_Quote;
        string Station_CustomerName_Quote;


        CommonMethodsCrm commonMethods = new CommonMethodsCrm();

        RateToShipmentLTL RTS = new RateToShipmentLTL();


        [When(@"I am on the Quote Results \(LTL\)page(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void WhenIAmOnTheQuoteResultsLTLPage(string Usertype, string Accessorial, string CustomerName, string oname, string dname, string Item, string weight, string Quantity, string Insuredvalue, string InsuredType, string Date)
        {

            RTS.NaviagteToQuoteList();
            RTS.SelectCustomerFrom_QuotetList(Usertype, CustomerName);

            RTS.ClickOnOriginSavedAddressDropdown_Quote();
            RTS.SearchByNameInTheOriginSavedAddressField_Quote(oname);
            RTS.SelectFirstAddressFromTheOriginSavedAddressDropdown_Quote();
            Thread.Sleep(2000);

            if (Usertype == "Internal")
            {
                Station_CustomerName_Quote = Gettext(attributeName_id, "StationCustomerLbl");
            }

            Thread.Sleep(1000);

            RTS.selectingOriginServiceAndAccessorial_Quote(Accessorial);
            _oServiceAccessorial_Quote = Gettext(attributeName_xpath, ".//*[@id='servicesaccessorialsfrom_chosen']/ul/li[1]");
            Thread.Sleep(1000);

            RTS.ClickOnDestinationSavedAddressDropdown_Quote();
            RTS.SearchByNameInTheDestinationSavedAddressField_Quote(dname);
            RTS.SelectFirstAddressFromTheDestinationSavedAddressDropdown_Quote();
            Thread.Sleep(2000);

            RTS.selectingDestinationServiceAndAccessorial_Quote(Accessorial);
            _dServiceAccessorial_Quote = Gettext(attributeName_xpath, ".//*[@id='servicesaccessorialsto_chosen']/ul/li[1]");
            Thread.Sleep(1000);

            RTS.addItem_Quote(Item, Quantity, weight);


            Thread.Sleep(1000);
            RTS.EnterInsuredValueAndType_Quote(Insuredvalue, InsuredType);

            Thread.Sleep(1000);
            RTS.SelectingDate_Quote(Date);
            Thread.Sleep(1000);
            Dateselected_Quote = GetValue(attributeName_xpath, ".//*[@id='PickupDate']", "value");


            RTS.ClickOnViewQuoteResultsButton_Quote();

        }



        [Then(@"I must be able to see Create Shipment button (.*)")]
        public void ThenIMustBeAbleToSeeCreateShipmentButton(string Usertype)
        {
            string configURL = launchUrl;
            string resultPagrURL = configURL + "Rate/LtlResultsView";
            Thread.Sleep(2000);
            if (GetURL() == resultPagrURL)
            {
                Report.WriteLine("Rate Results available");

                switch (Usertype)
                {
                    case "External":
                        VerifyElementPresent(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[4]/button", "Create Shipment button");
                        break;

                    case "Internal":
                        VerifyElementPresent(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[5]/button", "Create Shipment button");
                        break;
                }
               
            }
            else
            {
                Report.WriteLine("No Rates Available");
            }
        }

        [Then(@"I must be able to see Create Insured Shipment button (.*)")]
        public void ThenIMustBeAbleToSeeCreateInsuredShipmentButton(string Usertype)
        {

            string configURL = launchUrl;
            string resultPagrURL = configURL + "Rate/LtlResultsView";
            Thread.Sleep(2000);
            if (GetURL() == resultPagrURL)
            {
                Report.WriteLine("Rate Results available");

                switch (Usertype)
                {
                    case "External":
                        VerifyElementPresent(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[5]/button", "Create Insured Shipment button");
                        break;

                    case "Internal":
                        VerifyElementPresent(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[6]/button", "Create Insured Shipment button");
                        break;
                }

            }
            else
            {
                Report.WriteLine("No Rates Available");
            }
        }



        [Then(@"the Shipping From and To Address will be populated in the Add Shipment\(LTL\) page(.*),(.*),(.*)")]
        public void ThenTheShippingFromAndToAddressWillBePopulatedInTheAddShipmentLTLPage(string oname, string dname, string CustomerName)
        {
            Thread.Sleep(10000);
            Address _originaddressDB = DBHelper.GetAddress_By_searchedhName(CustomerName, oname);
            Thread.Sleep(1000);

            string oActualLocationName = GetValue(attributeName_id, ShippingFrom_LocationName_Id, "value");
            string.Equals((_originaddressDB.Name), oActualLocationName, StringComparison.OrdinalIgnoreCase);
            Thread.Sleep(1000);

            string oActualAddress1 = GetValue(attributeName_id, ShippingFrom_LocationAddressLine1_Id, "value");
            string.Equals((_originaddressDB.Address1), oActualAddress1, StringComparison.OrdinalIgnoreCase);
            Thread.Sleep(1000);

            string oActualAddress2 = GetValue(attributeName_id, ShippingFrom_LocationAddressLine2_Id, "value");
            if (_originaddressDB.Address2 == null || _originaddressDB.Address2 == "")
            {
                Assert.AreEqual(oActualAddress2, "");
            }
            else
            {
                string.Equals((_originaddressDB.Address2), oActualAddress2, StringComparison.OrdinalIgnoreCase);
            }
            Thread.Sleep(1000);

            string oActualCity = GetValue(attributeName_id, ShippingFrom_City_Id, "value");
            string.Equals((_originaddressDB.City), oActualCity, StringComparison.OrdinalIgnoreCase);
            Thread.Sleep(1000);

            string oActualState = Gettext(attributeName_xpath, ShippingFrom_StateDropdwon_xpath);
            string.Equals((_originaddressDB.State), oActualState, StringComparison.OrdinalIgnoreCase);
            Thread.Sleep(1000);

            string oActualZipCode = GetValue(attributeName_id, ShippingFrom_zipcode_Id, "value");
            Assert.AreEqual((_originaddressDB.Zip), oActualZipCode);
            Thread.Sleep(1000);

            string oActualCountry = Gettext(attributeName_xpath, ShippingFrom_CountryDropDown_xpath);
            string.Equals((_originaddressDB.Country), oActualCountry, StringComparison.OrdinalIgnoreCase);
            Thread.Sleep(1000);

            string _oServAccessorial_Shipment = Gettext(attributeName_xpath, ".//*[@id='shippingfromaccessorial_chosen']/ul/li[1]");
            Assert.AreEqual(_oServiceAccessorial_Quote, _oServAccessorial_Shipment);
            Thread.Sleep(1000);

            Address _destaddressDB = DBHelper.GetAddress_By_searchedhName(CustomerName, dname);
            Thread.Sleep(1000);

            string dActualLocationName = GetValue(attributeName_id, ShippingTo_LocationName_Id, "value");
            string.Equals((_destaddressDB.Name), dActualLocationName, StringComparison.OrdinalIgnoreCase);
            Thread.Sleep(1000);

            string dActualAddress1 = GetValue(attributeName_id, ShippingTo_LocationAddressLine1_Id, "value");
            string.Equals((_destaddressDB.Address1), dActualAddress1, StringComparison.OrdinalIgnoreCase);
            Thread.Sleep(1000);

            string dActualAddress2 = GetValue(attributeName_id, ShippingTo_LocationAddressLine2_Id, "value");
            if (_destaddressDB.Address2 == null || _destaddressDB.Address2 == "")
            {
                Assert.AreEqual(dActualAddress2, "");
            }
            else
            {
                string.Equals((_destaddressDB.Address2), dActualAddress2, StringComparison.OrdinalIgnoreCase);
            }
            Thread.Sleep(1000);

            string dActualCity = GetValue(attributeName_id, ShippingTo_City_Id, "value");
            string.Equals((_destaddressDB.City), dActualCity, StringComparison.OrdinalIgnoreCase);
            Thread.Sleep(1000);

            string dActualState = Gettext(attributeName_xpath, ShippingTo_StateDropdwon_xpath);
            string.Equals((_destaddressDB.State), dActualState, StringComparison.OrdinalIgnoreCase);
            Thread.Sleep(1000);

            string dActualZipCode = GetValue(attributeName_id, ShippingTo_zipcode_Id, "value");
            Assert.AreEqual((_destaddressDB.Zip), dActualZipCode);
            Thread.Sleep(1000);

            string dActualCountry = Gettext(attributeName_xpath, ShippingTo_CountryDropDown_xpath);
            string.Equals((_destaddressDB.Country), dActualCountry, StringComparison.OrdinalIgnoreCase);
            Thread.Sleep(1000);

            string _dServAccessorial_Shipment = Gettext(attributeName_xpath, ".//*[@id='shippingtoaccessorial_chosen']/ul/li[1]");
            Assert.AreEqual(_dServiceAccessorial_Quote, _dServAccessorial_Shipment);
            Thread.Sleep(1000);
        }

        [Then(@"the Item Information selected from the Quote will be populated(.*),(.*)")]
        public void ThenTheItemInformationSelectedFromTheQuoteWillBePopulated(string CustomerName, string Item)
        {
            Thread.Sleep(10000);
            scrollElementIntoView(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id);
            Thread.Sleep(1000);
            Item _itemDetail = DBHelper.GetItem(CustomerName, Item);
            Thread.Sleep(1000);
            string _class = GetValue(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id, "value");
            string[] _Classification = _class.Split(' ');
            string _Classification_UI = _Classification[0];
            string _ClassDB = "" + _itemDetail.Classification + "";
            Assert.AreEqual((_ClassDB), _Classification_UI);
            Thread.Sleep(1000);

            string _nmfc = GetValue(attributeName_id, FreightDesp_FirstItem_NMFC_Id, "value");
            if (_itemDetail.NmfcCode == null || _itemDetail.NmfcCode == "")
            {
                Assert.AreEqual(_nmfc, "");
            }
            else
            {
                string.Equals((_itemDetail.NmfcCode), _nmfc, StringComparison.OrdinalIgnoreCase);
            }
            Thread.Sleep(1000);

            string _description = GetValue(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id, "value");
            string.Equals((_itemDetail.ItemDescription), _description, StringComparison.OrdinalIgnoreCase);
            Thread.Sleep(1000);

            string _quantity = GetValue(attributeName_id, FreightDesp_FirstItem_Quantity_Id, "value");
            string _QuantityDB = "" + _itemDetail.Quantity + "";
            Assert.AreEqual(_QuantityDB, _quantity);
            Thread.Sleep(1000);

            string ActQuantityUnit = Gettext(attributeName_xpath, FreightDesp_FirstItem_QuantityType_xpath);
            if (ActQuantityUnit == "Skids")
            {
                Assert.AreEqual(_itemDetail.QuantityUnit, "SKD");
            }
            else if (ActQuantityUnit == "Bags")
            {
                Assert.AreEqual(_itemDetail.QuantityUnit, "BAG");
            }
            else if (ActQuantityUnit == "Bundles")
            {
                Assert.AreEqual(_itemDetail.QuantityUnit, "BDL");
            }
            else if (ActQuantityUnit == "Boxes")
            {
                Assert.AreEqual(_itemDetail.QuantityUnit, "BOX");
            }
            else if (ActQuantityUnit == "Cabinets")
            {
                Assert.AreEqual(_itemDetail.QuantityUnit, "CAB");
            }
            else if (ActQuantityUnit == "Cans")
            {
                Assert.AreEqual(_itemDetail.QuantityUnit, "CAN");
            }
            else if (ActQuantityUnit == "Cases")
            {
                Assert.AreEqual(_itemDetail.QuantityUnit, "CAS");
            }
            else if (ActQuantityUnit == "Crates")
            {
                Assert.AreEqual(_itemDetail.QuantityUnit, "CRT");
            }
            else if (ActQuantityUnit == "Cartons")
            {
                Assert.AreEqual(_itemDetail.QuantityUnit, "CTN");
            }
            else if (ActQuantityUnit == "Cylinders")
            {
                Assert.AreEqual(_itemDetail.QuantityUnit, "");
            }
            else if (ActQuantityUnit == "Drums")
            {
                Assert.AreEqual(_itemDetail.QuantityUnit, "DRM");
            }
            else if (ActQuantityUnit == "Pails")
            {
                Assert.AreEqual(_itemDetail.QuantityUnit, "PAL");
            }
            else if (ActQuantityUnit == "Pieces")
            {
                Assert.AreEqual(_itemDetail.QuantityUnit, "");
            }
            else if (ActQuantityUnit == "Pallets")
            {
                Assert.AreEqual(_itemDetail.QuantityUnit, "PLT");
            }
            else if (ActQuantityUnit == "Flat Racks")
            {
                Assert.AreEqual(_itemDetail.QuantityUnit, "RCK");
            }
            else if (ActQuantityUnit == "Reels")
            {
                Assert.AreEqual(_itemDetail.QuantityUnit, "REL");
            }
            else if (ActQuantityUnit == "Rolls")
            {
                Assert.AreEqual(_itemDetail.QuantityUnit, "");
            }
            else if (ActQuantityUnit == "Slip Sheets")
            {
                Assert.AreEqual(_itemDetail.QuantityUnit, "");
            }
            else if (ActQuantityUnit == "Stacks")
            {
                Assert.AreEqual(_itemDetail.QuantityUnit, "");
            }
            else
            {
                Assert.AreEqual(_itemDetail.QuantityUnit, "TBN");
            }
            Thread.Sleep(1000);

            string _weight = GetValue(attributeName_id, FreightDesp_FirstItem_Weight_Id, "value");
            string _WeightDB = "" + _itemDetail.Weight + "";
            Assert.AreEqual(_WeightDB, _weight);
            Thread.Sleep(1000);

            string _weightType = Gettext(attributeName_xpath, FreightDesp_FirstItem_WeightType_xpath);
            string.Equals((_itemDetail.WeightUnit), _weightType, StringComparison.OrdinalIgnoreCase);
            Thread.Sleep(1000);

            string _length = GetValue(attributeName_id, FreightDesp_FirstItem_Length_Id, "value");
            if (_itemDetail.Length == null || _itemDetail.Length == 0)
            {
                Assert.AreEqual(_length, "");
            }
            else
            {
                string _LengthDB = "" + _itemDetail.Length + "";
                Assert.AreEqual((_LengthDB), _length);
            }
            Thread.Sleep(1000);

            string _height = GetValue(attributeName_id, FreightDesp_FirstItem_Height_Id, "value");
            if (_itemDetail.Height == null || _itemDetail.Height == 0)
            {
                Assert.AreEqual(_height, "");
            }
            else
            {
                string _HeightDB = "" + _itemDetail.Height + "";
                Assert.AreEqual((_HeightDB), _height);
            }
            Thread.Sleep(1000);

            string _dimensionType = Gettext(attributeName_xpath, FreightDesp_FirstItem_DimensionType_xpath);
            string.Equals((_itemDetail.DimensionUnit), _dimensionType, StringComparison.OrdinalIgnoreCase);
            Thread.Sleep(1000);


            if (_itemDetail.IsHazardous)
            {
                RadiobuttonChecked(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div[2]/div[4]/div[4]/div/div[1]/div/div/div/div/div[1]/input");
            }
            else
            {
                RadiobuttonChecked(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div[2]/div[4]/div[4]/div/div[1]/div/div/div/div/div[2]/input");
            }

            CustomerAccount CA = DBHelper.GetAccountDetails_By_CustomerName(CustomerName);
            Thread.Sleep(1000);
            string DefaultSpecInstr = GetValue(attributeName_id, DefaultSpecialIntructions_Comments_Id, "value");
            string.Equals((CA.SpecialInstructions), DefaultSpecInstr, StringComparison.OrdinalIgnoreCase);
            Thread.Sleep(1000);
        }

        [Then(@"the PickUp date selected from the Quote will be populated")]
        public void ThenThePickUpDateSelectedFromTheQuoteWillBePopulated()
        {
            Thread.Sleep(20000);
            scrollElementIntoView(attributeName_id, PickUpDateCalender_Id);
            Thread.Sleep(1000);
            string Date_UIShipment = GetValue(attributeName_id, PickUpDateCalender_Id, "value");
            Assert.AreEqual(Date_UIShipment, Dateselected_Quote);

            string ReaadyTime_UIShipment = Gettext(attributeName_xpath, PickUpDate_ReadyTime_xpath);
            Thread.Sleep(1000);
            string CloseTime_UIShipment = Gettext(attributeName_xpath, PickUpDate_CloseTime_xpath);
            Thread.Sleep(1000);
            Assert.AreEqual(ReaadyTime_UIShipment, "Ready 8:00 AM");
            Thread.Sleep(1000);
            Assert.AreEqual(CloseTime_UIShipment, "Close 5:00 PM");
            Thread.Sleep(1000);
        }

        [Then(@"the Insured value from the Quote will be populated(.*),(.*)")]
        public void ThenTheInsuredValueFromTheQuoteWillBePopulated(string Insuredvalue, string InsuredType)
        {
            Thread.Sleep(1000);
            string _insuredValue_UI = GetValue(attributeName_id, InsuredValue_TextBox_Id, "value");
            Assert.AreEqual(_insuredValue_UI, Insuredvalue + ".00");
            Thread.Sleep(1000);

            string _insuredType_UI = Gettext(attributeName_xpath, InsuredValue_Type_xpath);
            Assert.AreEqual(_insuredType_UI, InsuredType);
            Thread.Sleep(1000);
        }

        [Then(@"the Station and Customer Name selected from the Quote will be populated for Internal User(.*)")]
        public void ThenTheStationAndCustomerNameSelectedFromTheQuoteWillBePopulatedForInternalUser(string Usertype)
        {
            Thread.Sleep(1000);
            string Station_CustomerName_Shipment;

            if (Usertype == "Internal")
            {
                Station_CustomerName_Shipment = Gettext(attributeName_id, "stationcustomernamedropdown");
                string.Equals(Station_CustomerName_Quote, Station_CustomerName_Shipment, StringComparison.OrdinalIgnoreCase);
                Thread.Sleep(1000);
            }
        }


    }
}
