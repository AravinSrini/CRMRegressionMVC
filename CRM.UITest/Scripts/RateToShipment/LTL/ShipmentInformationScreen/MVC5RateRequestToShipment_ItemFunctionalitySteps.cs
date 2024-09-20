using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text.RegularExpressions;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.RateToShipment.LTL.ShipmentInformationScreen
{
    [Binding]
    public class MVC5RateRequestToShipment_ItemFunctionalitySteps : AddShipments
    {
        CommonMethodsCrm crm = new CommonMethodsCrm();
        RateToShipmentLTL RTS = new RateToShipmentLTL();
        
        [Given(@"I am a shp\.entry, operations, sales, sales management, or station owner user (.*) (.*)")]
        public void GivenIAmAShp_EntryOperationsSalesSalesManagementOrStationOwnerUser(string Username, string Password)
        {
            crm.LoginToCRMApplication(Username, Password);
        }

        [When(@"I have selected Saved Item with Hazmat on the Get Quote \(LTL\) page(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void WhenIHaveSelectedSavedItemWithHazmatOnTheGetQuoteLTLPage(string Usertype, string Accessorial, string CustomerName, string oname, string dname, string Item, string weight, string Quantity, string Insuredvalue, string Date)
        {
            RTS.NaviagteToQuoteList();
            RTS.SelectCustomerFrom_QuotetList(Usertype, CustomerName);
            RTS.ClickOnOriginSavedAddressDropdown_Quote();
            RTS.SearchByNameInTheOriginSavedAddressField_Quote(oname);
            RTS.SelectFirstAddressFromTheOriginSavedAddressDropdown_Quote();
            Thread.Sleep(2000);

            RTS.selectingOriginServiceAndAccessorial_Quote(Accessorial);


            RTS.ClickOnDestinationSavedAddressDropdown_Quote();
            RTS.SearchByNameInTheDestinationSavedAddressField_Quote(dname);
            RTS.SelectFirstAddressFromTheDestinationSavedAddressDropdown_Quote();
            Thread.Sleep(2000);

            RTS.addItem_Quote(Item, Quantity, weight);
            RTS.EnterDataInInsuredField_Quote(Insuredvalue);
            RTS.SelectingDate_Quote(Date);

            RTS.ClickOnViewQuoteResultsButton_Quote();
        }

        [When(@"I added service and accessorial as Hazmat on the Get Quote \(LTL\) page(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void WhenIAddedServiceAndAccessorialAsHazmatOnTheGetQuoteLTLPage(string Usertype, string Accessorial, string CustomerName, string oname, string dname, string Item, string weight, string Quantity, string Insuredvalue, string Date)
        {
            RTS.NaviagteToQuoteList();
            RTS.SelectCustomerFrom_QuotetList(Usertype, CustomerName);
            RTS.ClickOnOriginSavedAddressDropdown_Quote();
            RTS.SearchByNameInTheOriginSavedAddressField_Quote(oname);
            RTS.SelectFirstAddressFromTheOriginSavedAddressDropdown_Quote();
            Thread.Sleep(1000);

            RTS.selectingOriginServiceAndAccessorial_Quote(Accessorial);

            RTS.ClickOnDestinationSavedAddressDropdown_Quote();
            RTS.SearchByNameInTheDestinationSavedAddressField_Quote(dname);
            RTS.SelectFirstAddressFromTheDestinationSavedAddressDropdown_Quote();
            Thread.Sleep(1000);

            RTS.addItem_Quote(Item, Quantity, weight);
            
            RTS.EnterDataInInsuredField_Quote(Insuredvalue);
            RTS.SelectingDate_Quote(Date);
            RTS.ClickOnViewQuoteResultsButton_Quote();
        }
        
        [When(@"I have added additional Item with Hazmat on the Get Quote \(LTL\) page(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void WhenIHaveAddedAdditionalItemWithHazmatOnTheGetQuoteLTLPage(string Usertype, string Accessorial, string CustomerName, string oname, string dname, string Item, string weight, string Quantity, string Insuredvalue, string Item1, string Date)
        {
            RTS.NaviagteToQuoteList();
            RTS.SelectCustomerFrom_QuotetList(Usertype, CustomerName);
            RTS.ClickOnOriginSavedAddressDropdown_Quote();
            RTS.SearchByNameInTheOriginSavedAddressField_Quote(oname);
            RTS.SelectFirstAddressFromTheOriginSavedAddressDropdown_Quote();
            Thread.Sleep(1000);

            RTS.ClickOnDestinationSavedAddressDropdown_Quote();
            RTS.SearchByNameInTheDestinationSavedAddressField_Quote(dname);
            RTS.SelectFirstAddressFromTheDestinationSavedAddressDropdown_Quote();
            Thread.Sleep(1000);

            RTS.addItem_Quote(Item, Quantity, weight);
            RTS.addAdditionalItem1_Quote(Item1, Quantity, weight);
            RTS.EnterDataInInsuredField_Quote(Insuredvalue);
            RTS.SelectingDate_Quote(Date);
            RTS.ClickOnViewQuoteResultsButton_Quote();
        }


        [Then(@"the Hazmat value will be autopopulated in the Add Shipment\(LTL\) page(.*),(.*)")]
        public void ThenTheHazmatValueWillBeAutopopulatedInTheAddShipmentLTLPage(string CustomerName, string Item)
        {

            Thread.Sleep(8000);
            scrollElementIntoView(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id);
            Item _itemDetail = DBHelper.GetItem(CustomerName, Item);
            Thread.Sleep(1000);

            string _hazmatGrp = Gettext(attributeName_xpath, FreightDesp_FirstItem_SelectHazmatPackageGroup_DownDown_xpath);
            if (_hazmatGrp == "")
            {
                Assert.IsNull(_itemDetail.HazMatPackagingGroup);
            }
            else
            {
                Assert.AreEqual((_itemDetail.HazMatPackagingGroup), _hazmatGrp);
            }
            Thread.Sleep(800);

            string _emgContactName = GetValue(attributeName_id, FreightDesp_FirstItem_EmergencyReponseContactName_Id, "value");
            if (_emgContactName == null)
            {
                Assert.IsNull(_itemDetail.EmergencyContactName);
            }
            else
            {
                string.Equals((_itemDetail.EmergencyContactName), _emgContactName, StringComparison.OrdinalIgnoreCase);
            }
            Thread.Sleep(800);

            string _ccnNumber = GetValue(attributeName_id, FreightDesp_FirstItem_CCN_Number_Id, "value");
            if (_ccnNumber == "")
            {
                Assert.IsNull(_itemDetail.CcnNumber);
            }
            else
            {
                Assert.AreEqual((_itemDetail.CcnNumber), _ccnNumber);
            }
            Thread.Sleep(800);

            string _hazmatClass = Gettext(attributeName_xpath, FreightDesp_FirstItem_SelectHazmatClass_DropwDown_xpath);
            if (_hazmatClass == "")
            {
                Assert.IsNull(_itemDetail.HazMatClass);
            }
            else
            {
                Assert.AreEqual((_itemDetail.HazMatClass), _hazmatClass);
            }
            Thread.Sleep(800);

            string _emgPhoneNumber = GetValue(attributeName_id, FreightDesp_FirstItem_EmergencyReponsePhoneNumber_Id, "value");
            if (_emgPhoneNumber == "")
            {
                Assert.IsNull(_itemDetail.EmergencyPhoneNumber);
            }
            else
            {
                string EmergencyPhoneNumberexpected = Regex.Replace(_itemDetail.EmergencyPhoneNumber, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
                string EmergencyPhoneNumberActual = Regex.Replace(_emgPhoneNumber, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
                Assert.AreEqual((EmergencyPhoneNumberexpected), EmergencyPhoneNumberActual);
            }
            Thread.Sleep(800);
        }

        [Then(@"the Hazmat section will be expanded in the Add Shipment\(LTL\) page")]
        public void ThenTheHazmatSectionWillBeExpandedInTheAddShipmentLTLPage()
        {
            Thread.Sleep(10000);
            scrollElementIntoView(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id);
            Thread.Sleep(1000);
            VerifyElementVisible(attributeName_id, FreightDesp_FirstItem_UN_Number_Id, "UNNumber field");
        }

        [Then(@"the Additional Item with Hazmat values are populated in the Additional Item section in Add Shipment\(LTL\) page(.*),(.*)")]
        public void ThenTheAdditionalItemWithHazmatValuesArePopulatedInTheAdditionalItemSectionInAddShipmentLTLPage(string CustomerName, string Item1)
        {
            Thread.Sleep(10000);
            scrollElementIntoView(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id);
            Thread.Sleep(1000);
            Item _itemDetail = DBHelper.GetItem(CustomerName, Item1);
            Thread.Sleep(1000);
            string _class = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_SavedClassItem_DropDown_Id, "value");
            string[] _Classification = _class.Split(' ');
            string _Classification_UI = _Classification[0];
            string _ClassDB = "" + _itemDetail.Classification + "";
            Assert.AreEqual((_ClassDB), _Classification_UI);

            string _nmfc = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_NMFC_Id, "value");
            if (_itemDetail.NmfcCode == null || _itemDetail.NmfcCode == "")
            {
                Assert.AreEqual(_nmfc, "");
            }
            else
            {
                string.Equals((_itemDetail.NmfcCode), _nmfc, StringComparison.OrdinalIgnoreCase);
            }
            Thread.Sleep(1000);

            string _description = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_ItemDescription_Id, "value");
            string.Equals((_itemDetail.ItemDescription), _description, StringComparison.OrdinalIgnoreCase);

            string _quantity = GetValue(attributeName_xpath, FreightDesp_First_AdditionalItem_Quantity_xpath, "value");
            string _QuantityDB = "" + _itemDetail.Quantity + "";
            Assert.AreEqual(_QuantityDB, _quantity);
            Thread.Sleep(1000);

            string ActQuantityUnit = Gettext(attributeName_xpath, FreightDesp_First_AdditionalItem_QuantityType_xpath);
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

            string _weight = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_Weight_Id, "value");
            string _WeightDB = "" + _itemDetail.Weight + "";
            Assert.AreEqual(_WeightDB, _weight);
            Thread.Sleep(1000);

            string _weightType = Gettext(attributeName_xpath, FreightDesp_First_AdditionalItem_WeightType_xpath);
            string.Equals((_itemDetail.WeightUnit), _weightType, StringComparison.OrdinalIgnoreCase);
            Thread.Sleep(1000);

            string _width = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_Width_Id, "value");
            if (_itemDetail.Width == null || _itemDetail.Width == 0)
            {
                Assert.AreEqual(_width, "");
            }
            else
            {
                string _WidthDB = "" + _itemDetail.Width + "";
                Assert.AreEqual((_WidthDB), _width);
            }
            Thread.Sleep(1000);

            string _height = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_Height_Id, "value");
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

            string _dimensionType = Gettext(attributeName_xpath, FreightDesp_First_AdditionalItem_DimensionType_xpath);
            string.Equals((_itemDetail.DimensionUnit), _dimensionType, StringComparison.OrdinalIgnoreCase);

            if (_itemDetail.IsHazardous)
            {
                RadiobuttonChecked(attributeName_xpath, ".//*[@id='1']/div/div[4]/div/div/div/div/div/div[1]/div[1]/input");
            }
            Thread.Sleep(1000);

            string _hazmatGrp = Gettext(attributeName_xpath, FreightDesp_First_AdditionalItem_SelectHazmatPackageGroup_DownDown_xpath);
            if (_itemDetail.HazMatPackagingGroup == null)
            {
                Assert.AreEqual(_hazmatGrp, "");
            }
            else
            {
                Assert.AreEqual((_itemDetail.HazMatPackagingGroup), _hazmatGrp);
            }
            Thread.Sleep(1000);

            string _emgContactName = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_EmergencyReponseContactName_Id, "value");
            if (_itemDetail.EmergencyContactName == null)
            {
                Assert.AreEqual(_emgContactName, "");
            }
            else
            {
                string.Equals((_itemDetail.EmergencyContactName), _emgContactName, StringComparison.OrdinalIgnoreCase);
            }
            Thread.Sleep(1000);

            string _ccnNumber = GetValue(attributeName_id, "txtfreight-CNnnumber-1", "value");
            if (_itemDetail.CcnNumber == null)
            {
                Assert.AreEqual(_ccnNumber, "");
            }
            else
            {
                Assert.AreEqual((_itemDetail.CcnNumber), _ccnNumber);
            }
            Thread.Sleep(1000);

            string _hazmatClass = Gettext(attributeName_xpath, FreightDesp_First_AdditionalItem_SelectHazmatClass_DropwDown_xpath);
            if (_itemDetail.HazMatClass == null)
            {
                Assert.AreEqual(_hazmatClass, "");
            }
            else
            {
                Assert.AreEqual((_itemDetail.HazMatClass), _hazmatClass);
            }
            Thread.Sleep(1000);

            string _emgPhoneNumber = GetValue(attributeName_id, "txtEmrResPhNumber-1", "value");
            if (_itemDetail.EmergencyPhoneNumber == null)
            {
                Assert.AreEqual(_emgPhoneNumber, "");
            }
            else
            {
                string EmergencyPhoneNumberexpected = Regex.Replace(_itemDetail.EmergencyPhoneNumber, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
                string EmergencyPhoneNumberActual = Regex.Replace(_emgPhoneNumber, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
                Assert.AreEqual((EmergencyPhoneNumberexpected), EmergencyPhoneNumberActual);
            }
            Thread.Sleep(1000);
        }
    }
}
