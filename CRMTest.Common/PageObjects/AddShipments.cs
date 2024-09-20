using System;

namespace CRMTest.Common.PageObjects
{
    public class AddShipments : Shipmentlist
    {
        //-------------------Tile page------------------------------------------
        public string ShipmentList_title_Xpath = "//*[@id='page-content-wrapper']//*[text()='Shipment List']";
        public string Shipment_viewresults_Xpath = ".//*[@id='page-content-wrapper']//*[text()='View Rates']";
        public string Shipment_exandableTrigger_Xpath = ".//*[@id='QuotesGrid']/tbody/tr[1]//*[@class='btn exandableTrigger image-only-sm']";
        public string AddShipment_Button_id = "add-shipment-btn";
        public string AddShipmentButtionInternal_Id = "shipment-list";
        public string AddShipmentLTL_Button_Id = "btn_ltl";
        public string AddShipmentTilepage_Header_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div[1]/div[1]/div[1]/h1";
        public string AddShipment_CustomerName_Header_Xpath = "//*[@id='page-content-wrapper']/div[2]/div[1]/div[1]/div/div/div[1]/h1";
        public string AddShipmentReviewAndSubmitPage_Xpath = "//h1[@class='shipment-header']";
        public string DomesticServiceTile_Id = "btn_domestic_forwarding";
        public string Domestic_TypeDropdown_Xpath = ".//*[@id='shipment_domestic_forward_type_chosen']/a";
        public string Domestic_TypeDropdownValues_Xpath = ".//*[@id='shipment_domestic_forward_type_chosen']/div/ul/li";
        public string Domestic_CloseButton_Xpath = ".//*[@id='shipmentDomesticForwardingContent']/div/div/div/div[3]/a[1]";
        public string Domestic_ContinueButton_Id = "btn_submit_shipmentDomesticForwarding";
        public string Domestic_ErrorMessage_Xpath = ".//*[@id='shipmentDomesticForwardingContent']/div/div/div/div[3]/div";
        public string AddShipmentIcon_Xpath = ".//*[@id='shipment']/i";
        public string AddShipmentButton_Xpath = ".//*[@id='shipment-list']";
        public string Loading_Icon_Id = "dvLoading";


        public string ShipmentList_ReferenceSearchButton_Selector = "#page-content-wrapper > div.container-fluid.container-with-sidebar > div.col-lg-12 > div > div.col-md-3 > div > div > form > div > div > button";
        public string ShipmentList_SearchBox_Id = "searchbox";
        public string ShipmentList_SelectReport_Xpath = "//a[@class='chosen-single chosen-default']";
        public string ShipmentList_ReportSearch_Xpath = "//div[@id='ReportType_chosen']//input[@type='text']";
        public string ShipmentList_ReportDropdown_Xpath = "//*[@id='ReportType_chosen']";
        public string ShipmentList_ReportDropdown_Search_Xpath = "//*[@id='ReportType_chosen']/div/div/input";
        public string ShipmentList_ReportDropdown_FirstSearchedOption_Xpath = "//*[@id='ReportType_chosen']/div/ul/li[2]";
        public string ShipmentList_SelectReportDropdownVal_Xpath = ".//*[@id='ReportType_chosen']/div/ul/li";
        public string ShipmentList_EditButton_ExternalUser_Xpath = "(//BUTTON[@class='btn btn-default colored btn-sm btn-EditShipmentExtUsers'][text()='Edit'][text()='Edit'])[1]";
        public string ShipmentList_CustomerSearch_Xpath = "//*[@id='CustomerType_chosen']/div/div/input";
        public string ShipmentList_FirstStatus_Xpath = "//tbody//tr[1]//td[3]//div[1]//span[1]";
        public string AddShipment_PageTitle_xpath = "//*[@id='page-content-wrapper']//*[text()='Add Shipment (LTL)']";
        public string EditShipmentVerbiage_ShipmentNumber_xpath = ".//*[@id='bol-number-text']";
        public string EditShipmentVerbiage_EditingText_xpath = ".//*[@id='bol-number-text-wrapper']/span[2]";
        public string RequiredField_WarningMessage_Id = "warning-orange";
        public string ShippingFromSectionText_xpath = "//h3[text() = 'Shipping From']";
        public string ShippingToSectionText_xpath = "//h3[text() = 'Shipping To']";

        public string ShippingFrom_SelectSavedOriginDropDown_Id = "txt_OrginAddress_ltlShipment";
        public string ShippingFrom_SelectSavedOriginDropDown_Values_xpath = ".//*[@id='scrollable-dropdown-menu-Origin']/div/span[1]/span/div/span/div/p";
        public string ShippingFrom_ClearAddress_Id = "clearAddressShipmentOrgin1";
        public string ShippingFrom_LocationName_Id = "txtOrginName";
        public string ShippingFrom_LocationAddressLine1_Id = "txtOrginAddr1";
        public string ShippingFrom_LocationAddressLine2_Id = "txtOrginAddr2";
        public string ShippingFrom_zipcode_Id = "origin-zip";
        public string ShippingFrom_PostalCode_Class = "postal-code";
        public string ShippingFrom_CountryDropDown_xpath = "//div[@id='select_origin_country_chosen']/a";
        public string ShippingFrom_CountryDropDown_SelectedValue_xpath = "//div[@id='select_origin_country_chosen']/a/span";
        public string ShippingFrom_CountryDropDown_Values_xpath = ".//*[@id='select_origin_country_chosen']/div/ul/li";
        public string ShippingFrom_CanadaCountryDropdown_Xpath = ".//*[@id='select_origin_country_chosen']/div/ul/li[2]";
        public string ShippingFrom_City_Id = "txtOrginCity";
        public string ShippingFrom_StateDropdwon_xpath = ".//*[@id='state_origin_select_chosen']/a";
        public string ShippingFrom_StateDropdwon_SelectedValue_xpath = "//div[@id='state_origin_select_chosen']/a/span";
        public string ShippingFrom_StateDropdwon_Values_xpath = ".//*[@id='state_origin_select_chosen']/div/ul/li";
        public string ShippingFrom_ServicesAccessorial_DropDown_xpath = "//div[@id='shippingfromaccessorial_chosen']/ul/li/input";
        public string ShippingFrom_selectedServicesAccessorial_DropDown_xpath = ".//*[@id='shippingfromaccessorial_chosen']/ul/li[1]/span";
        public string ShippingFrom_ServicesAccessorial_DropDown2_xpath = "//*[@id='shippingfromaccessorial_chosen']/ul/li[2]/input";
        public string ShippingFrom_ServicesAccessorial_DropDown_Values_xpath = ".//*[@id='shippingfromaccessorial_chosen']/div/ul/li";
        public string ShippingFrom_AccessorialsDropDown_Values_xpath = ".//*[@id='shippingfromaccessorial_chosen']/ul/li";
        public string ShippingFrom_ServicesAccessorial_Delete_Icon_xpath = ".//*[@id='shippingfromaccessorial_chosen']/ul/li[1]/a";
        public string ShippingFrom_AccessorialsDropDown_Overlength_xpath = ".//*[@id='shippingfromaccessorial_chosen']/ul/li[span[.='Overlength']]/a";
        public string ShippingFrom_Accessorial_List_xpath = "//*[@id='shippingfromaccessorial_chosen']/div";
        public string ShippingFrom_Comments_Id = "txtOrginComments";
        public string ShippingFrom_SaveOriginInfo_Checkbox_xpath = "//label[@for='Saveorigininformation']";
        public string ShippingFrom_SaveOrigin_Checkbox_Id = "Saveorigininformation";
        public string ShippingFrom_ViewOriginLocationMap_Id = "origin-google-map";
        public string ShippingFrom_AddressWindow_Map_Xpath = ".//*[@id='gs_htif50']";
        public string ShippingFrom_MapValidation_Message_Xpath = ".//*[@id='originmaplocation']/div/div/div[2]/h6";
        public string ShippingFrom_MapClose_Button_Xpath = ".//*[@id='originmaplocation']/div/div/div[3]/a";

        public string ShippingTo_SelectSavedDestDropDown_Id = "txt_DestinationAddress_ltlShipment";
        public string ShippingTo_SelectSavedDestDropDown_Values_xpath = ".//*[@id='scrollable-dropdown-menu-Destination']/div/span[1]/span/div/span/div/p";
        public string ShippingTo_ClearAddress_Id = "clearAddressShipmentdestination";
        public string ShippingTo_LocationName_Id = "txtDestName";
        public string ShippingTo_LocationAddressLine1_Id = "txtDestAddr1";
        public string ShippingTo_LocationAddressLine2_Id = "txtDestAddr2";
        public string ShippingTo_zipcode_Id = "destination-zip";
        public string ShippingTo_PostalCode_Name = "destinationzip/postalcode";
        public string ShippingTo_CountryDropDown_xpath = ".//*[@id='select_destination_country_chosen']/a";
        public string ShippingTo_CountryDropDown_SelectedValue_xpath = "//div[@id='select_destination_country_chosen']/a/span";
        public string ShippingTo_CountryDropDown_Values_xpath = ".//*[@id='select_destination_country_chosen']/div/ul/li";
        public string ShippingTo_CanadaCountryDropdown_Xpath = ".//*[@id='select_destination_country_chosen']/div/ul/li[2]";
        public string ShippingTo_City_Id = "txtDestCity";
        public string ShippingTo_StateDropdwon_xpath = ".//*[@id='state_destination_select_chosen']/a";
        public string ShippingTo_StateDropdwon_SelectedValue_xpath = "//div[@id='state_destination_select_chosen']/a/span";
        public string ShippingTo_StateDropdwon_Values_xpath = ".//*[@id='state_destination_select_chosen']/div/ul/li";
        public string ShippingTo_ServicesAccessorial_DropDown_xpath = "(//INPUT[@type='text'])[23]";
        public string ShippingTo_selectedServicesAccessorial_DropDown_xpath = ".//*[@id='shippingtoaccessorial_chosen']/ul/li[1]/span";
        // public string ShippingTo_ServicesAccessorial_DropDown_Values_xpath = ".//*[@id='shippingtoaccessorial_chosen']/*[@class ='chosen-drop']/*[@class ='chosen-results']/*[@class ='active-result']";
        public string ShippingTo_ServicesAccessorial_DropDown_Values_xpath = ".//*[@id='shippingtoaccessorial_chosen']/div/ul/li";
        public string Overlength_ShippingTo_ServicesAccessorial_DropDown_xpath = "//div[@id='shippingtoaccessorial_chosen']/ul/li/input";
        public string Overlength_ShippingTo_ServicesAccessorial_DropDown_Values_xpath = ".//*[@id='shippingtoaccessorial_chosen']/*[@class ='chosen-drop']/*[@class ='chosen-results']/li";
        public string ShippingTo_ServicesAccessorial_Delete_Icon_xpath = ".//*[@id='shippingtoaccessorial_chosen']/ul/li[1]/a";
        public string ShippingTo_Comments_Id = "txtDestComments";
        public string ShippingTo_SaveDestInfo_Checkbox_xpath = "//label[@for='Savedestinationinformation']";
        public string ShippingFrom_SaveDestination_Checkbox_Id = "Savedestinationinformation";
        public string ShippingTo_ViewDestLocationMap_Id = "destination-google-map";
        public string ShippingTo_MapValidation_Message_Xpath = ".//*[@id='originmaplocation']/div/div/div[2]/h6";
        public string ShippingTo_MapClose_Button_Xpath = ".//*[@id='originmaplocation']/div/div/div[3]/a";

        public string ShippingFrom_FirstSavedOriginAddress_Xpath = ".//*[@id='scrollable-dropdown-menu-Origin']/div/span[1]/span/div/span/div[1]/p";
        public string ShippingFrom_FirstSavedDestAddress_Xpath = ".//*[@id='scrollable-dropdown-menu-Destination']/div/span[1]/span/div/span/div[1]/p";

        public string ShipmentServiceTypeLTL_id = "btn_ltl";
        public string ShipmentServiceTypeTL_id = "btn_truckload";
        public string ShipmentServiceTypePTL_id = "btn_partial_truckload";
        public string ShipmentServiceTypeIntermodal_id = "btn_intermodel";
        public string ShipmentServiceTypeDom_id = "btn_domestic_forwarding";
        public string ShipmentServiceTypeIntn_id = "btn_international";

        public string ShipmentServicePageTitle_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[1]/div[1]/h1";
        public string AddShipmentStationCustomerDisplay_Xpath = ".//*[@id='stationcustomernamedropdown']";
        public string ShipmentResultPageStationCustomerDisplay_Xpath = ".//*[@id='station-customer-name']";
        public string ShippingFrom_ContactInfo_SectionText_xpath = ".//*[@id='Accordionorigin']/div/div[1]/h4";
        public string ShippingTo_ContactInfo_SectionText_xpath = ".//*[@id='Accordiondestination']/div/div[1]/h4";

        public string ShippingFrom_ContactInfo_Expand_xpath = ".//*[@id='Accordionorigin']/div/div[1]/div/div/span";
        public string ShippingTo_ContactInfo_Expand_xpath = ".//*[@id='Accordiondestination']/div/div[1]/div/div/span";
        public string ShippingFrom_ContactName_Id = "txtorgcntName";
        public string ShippingFrom_ContactEmail_Id = "txtorgcntEmail";
        public string ShippingFrom_ContactPhone_Id = "txtorgcntPhnNumber";
        public string ShippingFrom_ContactFax_Id = "txtorgcntFaxNumber";

        public string ShippingTo_ContactName_Id = "txtdescntName";
        public string ShippingTo_ContactEmail_Id = "txtdescntEmail";
        public string ShippingTo_ContactPhone_Id = "txtdescntPhnNumber";
        public string ShippingTo_ContactFax_Id = "txtdescntFaxNumber";

        public string ShippingFrom_InvalidEmailError_Xpath = ".//*[@id='shippingfromerrormessage']/ul/li[3]";
        public string ShippingFrom_InvalidPhoneError_Xpath = ".//*[@id='shippingfromerrormessage']/ul/li[1]";
        public string ShippingFrom_InvalidFaxError_Xpath = ".//*[@id='shippingfromerrormessage']/ul/li[2]";

        public string ShippingTo_InvalidEmailError_Xpath = ".//*[@id='shippingtoerrormessage']/ul/li[3]";
        public string ShippingTo_InvalidPhoneError_Xpath = ".//*[@id='shippingtoerrormessage']/ul/li[1]";
        public string ShippingTo_InvalidFaxError_Xpath = ".//*[@id='shippingtoerrormessage']/ul/li[2]";


        public string PickUpDateCalender_Id = "PickupDate";
        public string PickUpDate_ReadyTime_xpath = ".//*[@id='pickupreadytime_chosen']/a/span";
        public string PickUpDate_CloseTime_xpath = ".//*[@id='pickupclosetime_chosen']/a/span";
        public string PickUpDate_Xpath = ".//*[@id='PickupDate']";
        //public string LTLSelectingDates_Xpath = "html/body/div[8]/div[1]/table/tbody/tr/td"; --> Incorrect xpath
        public string LTLSelectingDates_Xpath = "html/body/div[9]/div[1]/table/tbody/tr/td";
        public string LTL_PickUpDate_Id = "PickupDate";
        public string LTL_selectingmonth_xpath = "html/body/div[8]/div[1]/table/thead/tr[1]/th[3]/i";
        public string LTL_PickUpReadyTime_Xpath = ".//*[@id='pickupreadytime_chosen']/a";
        public string LTL_PickUpCloseTime_Xpath = ".//*[@id='pickupclosetime_chosen']/a";
        public string LTL_PickUpReadyTime_SelectedValue_Xpath = ".//*[@id='pickupreadytime_chosen']/a/span";
        public string LTL_PickUpCloseTime_SelectedValue_Xpath = ".//*[@id='pickupclosetime_chosen']/a/span";
        public string LTL_PickUpReadyTimeDropdown_Xpath = ".//*[@id='pickupreadytime_chosen']/div/ul/li";
        public string LTL_PickUpCloseTimeDropdown_Xpath = ".//*[@id='pickupclosetime_chosen']/div/ul/li";
        public string LTL_PickUpCloseTimeError_Xpath = ".//*[@id='close-time-validation-warning']";
        public string LTL_PickUpCloseTimeErrorContent_Xpath = ".//*[@id='close-time-validation-warning']/p";
        public string LTL_PickUpReadyTimeError_Xpath = ".//*[@id='pickup-time-validation-warning']";
        public string LTL_PickUpReadyTimeErrorContent_Xpath = ".//*[@id='pickup-time-validation-warning']/p";

        public string AllCustomerDropdown_Selection_Internal_Xpath = ".//*[@id='CustomerType_chosen']/a";
        public string AllCustomerDroppdownValues_Internal_Xpath = ".//*[@id='CustomerType_chosen']/div/ul/li";
        public string AllCustomerDroppdownSearchBox_Internal_Xpath = ".//*[@id='CustomerType_chosen']/div/div/input";


        public string FreightDesp_SectionText_xpath = ".//*[@id='page-content-wrapper']/div[2]/div[2]/div[4]/div[1]/div/div[1]/h3";
        public string FreightDesp_FirstItem_SavedClassItem_DropDown_Id = "freightdescription-0";
        public string FreightDesp_FirstItem_SavedClassItem_DropDown_Xpath = "//*[@id='freightdescription-0']";
        public string FreightDesp_FirstItem_SavedClassItem_DropDown_Values_xpath = ".//*[@id='scrollable-dropdown-menu-Origin']/div/span[1]/span/div/span/div/p";
        public string FreightDesp_FirstItem_NMFC_Id = "freightNMFC-0";
        public string FreightDesp_FirstItem_ItemDescription_Id = "freightDesc-0";
        public string FreightDesp_FirstItem_Quantity_Id = "freightquantity-0";
        public string FreightDesp_FirstItem_QuantityType_xpath = ".//*[@id='freightquantitytype_0_chosen']/a/span";
        public string FreightDesp_FirstItem_QuantityTypevalues_xpath = ".//*[@id='freightquantitytype_0_chosen']/div/ul/li";
        public string FreightDesp_FirstItem_Quantity_Warning_xpath = ".//*[@id='quantity-skd-error']/p";
        public string FreightDesp_FirstItem_Weight_Id = "freightweight-0";
        public string FreightDesp_FirstItem_WeightType_xpath = ".//*[@id='freightweighttype_0_chosen']/a/span";
        public string FreightDesp_FirstItem_WeightTypevalues_xpath = ".//*[@id='freightweighttype_0_chosen']/div/ul/li";
        public string FreightDesp_FirstItem_Weight_Warning_xpath = ".//*[@id='weight-error']/p";
        public string FreightDesp_FirstItem_EstimateClassButton_Id = "est-cls-btn-0";
        public string FreightDesp_FirstItem_ClearItem_Button_Id = "frieghtclearbtn-0";
        public string FreightDesp_FirstItem_Length_Id = "freightlength-0";
        public string FreightDesp_FirstItem_Width_Id = "freightwidth-0";
        public string FreightDesp_FirstItem_Height_Id = "freightheight-0";
        public string FreightDesp_FirstItem_Length_Div_xpath = "//*[@id='freightlength-0']/../..";
        public string FreightDesp_FirstItem_Width_Div_xpath = "//*[@id='freightwidth-0']/../..";
        public string FreightDesp_FirstItem_Height_Div_xpath = "//*[@id='freightheight-0']/../..";
        public string FrieghtDesp_AdditionalClass_Id = "freightdescription-1";
        public string FreightDesp_FirstItem_DimensionType_xpath = ".//*[@id='freightdimensiontype_0_chosen']/a";
        public string FreightDesp_FirstItem_DimensionType_SelectedValue_xpath = ".//*[@id='freightdimensiontype_0_chosen']/a/span";
        public string FreightDesp_FirstItem_DimensionType_Values_xpath = ".//*[@id='freightdimensiontype_0_chosen']/div/ul/li";
        public string FreightDesp_SecondItem_DimensionType_xpath = ".//*[@id='freightdimensiontype_1_chosen']/a";
        public string FreightDesp_SecondItem_DimensionType_Values_xpath = ".//*[@id='freightdimensiontype_1_chosen']/div/ul/li";
        public string FreightDesp_FirstItem_Hazardous_Yes_RadioButton_xpath = ".//*[@id='page-content-wrapper']/div[2]/div[2]/div[4]/div[4]/div/div[1]/div/div/div/div/div[1]/label";
        public string FreightDesp_FirstItem_Hazardous_Yes_Input_Id = "Hazard-0_Hazard-0Yes";
        public string FreightDesp_FirstItem_Hazardous_No_Input_Id = "Hazard-0_Hazard-0No";
        public string FreightDesp_FirstItem_Hazardous_No_RadioButton_xpath = ".//*[@id='page-content-wrapper']/div[2]/div[2]/div[4]/div[4]/div/div[1]/div/div/div/div/div[2]/input";
        public string FreightDesp_FirstItem_UN_Number_Id = "txtUNNumber-0";
        public string FreightDesp_FirstItem_SelectHazmatPackageGroup_DownDown_xpath = ".//*[@id='Hazmatpackagegroup_0_chosen']/a/span";
        public string FreightDesp_FirstItem_SelectHazmatPackageGroup_DownDownOutline_xpath = ".//*[@id='Hazmatpackagegroup_0_chosen']/a";
        public string FreightDesp_FirstItem_SelectHazmatPackageGroup_DownDown_Values_xpath = ".//*[@id='Hazmatpackagegroup_0_chosen']/div/ul/li";
        public string FreightDesp_FirstItem_EmergencyReponseContactName_Id = "txtEmrResContName-0";
        public string FreightDesp_FirstItem_CCN_Number_Id = "txtfreight-CNnnumber-0";
        public string FreightDesp_FirstItem_SelectHazmatClass_DropwDown_xpath = ".//*[@id='HazmatClass_0_chosen']/a";
        public string FreightDesp_FirstItem_SelectHazmatClass_DropwDown_Values_xpath = ".//*[@id='HazmatClass_0_chosen']/div/ul/li";
        public string FreightDesp_FirstItem_EmergencyReponsePhoneNumber_Id = "txtEmrResPhNumber-0";
        public string FreightDesp_QuantityDropdownValues_Xpath = ".//*[@id='freightquantitytype_0_chosen']/div/ul/li";
        public string FreightDesp_ClearItem_Button_Class = "frieghtclearbtn";
        public string FreightDesp_RemoveItem_Button_Class = "additional-freightdescription-section-remove-btn";
        public string WeightWarningLbs_xpath = ".//*[@id='weight-error']/p[1]";
        public string WeightWarningKilos_xpath = ".//*[@id='weight-error']/p[2]";
        public string Freight_RemoveButton_Xpath = ".//*[@id='1']/div/div[6]/div/div/button";
        public string Freight_secondClearButton_Id = "frieghtclearbtn-1";
        public string FrightDescription_SavedItemDropdown_XPath = ".//*[@id='Select-saveditem-0']";
        public string FreightDesp_First_AdditionalItem_Button_xpath = ".//*[@id='page-content-wrapper']//div[7]/button";
        public string FreightDesp_First_Remove_Button_xpath = ".//*[@id='1']/div/div[6]/div/div/button";
        public string LTL_Length_Id = "freightlength-0";
        public string LTL_Width_Id = "freightwidth-0";
        public string LTL_Height_Id = "freightheight-0";
        public string LTL_Not_Freight_Length_Id = "length-0";
        public string LTL_Not_Freight_Width_Id = "width-0";
        public string LTL_Not_Freight_Height_Id = "height-0";
        public string LTL_Not_Freight_Length_Id_Additonal_Item = "length-1";
        public string LTL_Not_Freight_Width_Id_Additonal_Item = "width-1";
        public string LTL_Not_Freight_Height_Id_Additonal_Item = "height-1";
        public string WarningClose_Xpath = "(//I[@class='icon-close right'])[13]";

        public string Hazardous_Materials_Section_Selector = "#\\30 > div.hazmat-section-0.container-fluid > div > div";
        public string Chosen_Accessorial_Selector = "#shippingfromaccessorial_chosen > ul";
        public string Remove_Accessorial_Selector = "#shippingfromaccessorial_chosen > ul > li:nth-child(1) > a";

        public string Required_Input_Field = "required-input-field";
        public string Required_Input_Field_Shipment = "required";

        public string FreightDesp_First_AdditionalItem_SavedClassItem_DropDown_Id = "freightdescription-1";
        public string FreightDesp_First_AdditionalItem_SavedClassItem_DropDown_Values_xpath = "";
        public string FreightDesp_First_AdditionalItem_NMFC_Id = "freightNMFC-1";
        public string FreightDesp_First_AdditionalItem_ItemDescription_Id = "freightDesc-1";
        public string FreightDesp_First_AdditionalItem_Quantity_xpath = ".//*[@id='freightquantity-1']";
        public string FreightDesp_First_AdditionalItem_QuantityType_xpath = ".//*[@id='freightquantitytype_1_chosen']/a/span";
        public string FreightDesp_First_AdditionalItem_QuantityTypevalues_xpath = ".//*[@id='freightquantitytype_1_chosen']/div/ul/li";
        public string FreightDesp_First_AdditionalItem_Weight_Id = "freightweight-1";
        public string FreightDesp_First_AdditionalItem_WeightType_xpath = ".//*[@id='freightweighttype_1_chosen']/a/span";
        public string FreightDesp_First_AdditionalItem_WeightTypevalues_xpath = ".//*[@id='freightweighttype_1_chosen']/div/ul/li";
        public string FreightDesp_First_AdditionalItem_EstimateClassButton_Id = "est-cls-btn-1";
        public string FreightDesp_First_AdditionalItem_ClearItem_Button_Id = "frieghtclearbtn-1";
        public string FreightDesp_First_AdditionalItem_Length_Id = "freightlength-1";
        public string FreightDesp_First_AdditionalItem_Width_Id = "freightwidth-1";
        public string FreightDesp_First_AdditionalItem_Height_Id = "freightheight-1";
        public string FreightDesp_First_AdditionalItem_Length_Div_xpath = "//*[@id='freightlength-1']/../..";
        public string FreightDesp_First_AdditionalItem_Width_Div_xpath = "//*[@id='freightwidth-1']/../..";
        public string FreightDesp_First_AdditionalItem_Height_Div_xpath = "//*[@id='freightheight-1']/../..";
        public string FreightDesp_First_AdditionalItem_DimensionType_xpath = ".//*[@id='freightdimensiontype_1_chosen']/a";
        public string FreightDesp_First_AdditionalItem_DimensionType_Selected_xpath = ".//*[@id='freightdimensiontype_1_chosen']/a/span";
        public string FreightDesp_First_AdditionalItem_DimensionTypevalues_xpath = ".//*[@id='freightdimensiontype_1_chosen']/div/ul/li";
        public string FreightDesp_First_AdditionalItem_Hazardous_Yes_RadioButton_xpath = ".//*[@id='1']/div/div[4]/div/div/div/div/div/div[1]/div[1]/label";
        public string FreightDesp_First_AdditionalItem_Hazardous_No_RadioButton_xpath = ".//*[@id='1']/div/div[4]/div/div/div/div/div/div[1]/div[2]/input";
        public string FreightDesp_AdditionalItem_Hazardous_Yes_Input_Id = "Hazard-1_Hazard-1Yes";
        public string FreightDesp_AdditionalItem_Hazardous_No_Input_Id = "Hazard-1_Hazard-1No";
        public string FreightDesp_First_AdditionalItem_UN_Number_Id = "txtUNNumber-1";
        public string FreightDesp_First_AdditionalItem_SelectHazmatPackageGroup_DownDown_xpath = ".//*[@id='Hazmatpackagegroup_1_chosen']/a";
        public string FreightDesp_First_AdditionalItem_SelectHazmatPackageGroup_SelectedValue_xpath = ".//*[@id='Hazmatpackagegroup_1_chosen']/a/span";
        public string FreightDesp_First_AdditionalItem_SelectHazmatPackageGroup_DownDown_Values_xpath = ".//*[@id='Hazmatpackagegroup_1_chosen']/div/ul/li";
        public string FreightDesp_First_AdditionalItem_EmergencyReponseContactName_Id = "txtEmrResContName-1";
        public string FreightDesp_First_AdditionalItem_CCN_Number_Id = "txtfreight-CNnnumber-1";
        public string FreightDesp_First_AdditionalItem_SelectHazmatClass_DropwDown_xpath = ".//*[@id='HazmatClass_1_chosen']/a";
        public string FreightDesp_First_AdditionalItem_SelectHazmatClass_Selectedvalue_xpath = ".//*[@id='HazmatClass_1_chosen']/a/span";
        public string FreightDesp_First_AdditionalItem_SelectHazmatClass_DropwDown_Values_xpath = ".//*[@id='HazmatClass_1_chosen']/div/ul/li";
        public string FreightDesp_First_AdditionalItem_EmergencyReponsePhoneNumber_Id = "txtEmrResPhNumber-1";
        public string FreightDesp_First_AdditionalItem_clearbutton_xpath = ".//*[@id='frieghtclearbtn-1']";
        //  public string FreightDesp_First_AdditionalItem_WeightTypevalues_xpath = ".//*[@id='freightweighttype_0_chosen']/div/ul/li";
        public string FreightDesp_First_AdditionalItem_CCN_Number_xpath = "txtfreight-CNnnumber-1";
        public string FreightDesp_First_AdditionalItem_EmergencyReponsePhoneNumber_xpath = "txtEmrResPhNumber-1";
        public string FreightDescription_ClassList_Xpath = ".//*[@id='scrollable-dropdown-menu-Origin']//div/p";


        public string ReferenceNum_section_Xpath = ".//*[@id='referenceExpand']/h4";
        public string ReferenceNum_MoveTypeLabel_Xpath = ".//*[@id='Accordion22']/div/div[1]/div[1]/div/div/div[1]/label";
        public string ReferenceNumbers_HeaderText_xpath = ".//*[@id='Referencenumbersection']/div/div[1]/h4";
        public string ReferenceNumbers_ExpandSection_xpath = ".//*[@id='Referencenumbersection']/div/div[1]/div/div";
        public string ReferenceNumbers_MoveType_DropDown_xpath = ".//*[@id='MoveType_chosen']/a";
        public string ReferenceNumbers_MoveType_DropDown_Values_xpath = ".//*[@id='MoveType_chosen']/div/ul/li";
        public string ReferenceNumbers_InventoryLocationType_DropDown_xpath = ".//*[@id='InvLocType_chosen']/a";
        public string ReferenceNumbers_InventoryLocationType_DropDown_Values_xpath = ".//*[@id='InvLocType_chosen']/div/ul/li";
        public string ReferenceNumbers_PONumber_Id = "PONumber";
        public string ReferenceNumbers_OrderNumber_Id = "orderNumber";
        public string ReferenceNumbers_GLCode_Id = "glcode";
        public string ReferenceNumbers_BOLNumber_Id = "bolnum";
        public string ReferenceNumbers_PRONumber_Id = "PRONumber";
        public string ReferenceNumbers_PickUpNumber_Id = "PickupNumber";
        public string ReferenceNumbers_DeliveryApptNumber_Id = "deliveryapptnumber";

        public string AddAdditionalReference_Button_xpath = ".//*[@id='Accordion22']/div/div[3]/div/div/button";
        public string Remove_AdditionalReference_Button_xpath = ".//*[@id='Accordion22']/div/div[2]/div/div/div/div/div[3]/button";
        public string Additional_SelectReferenceType_DropDown_xpath = ".//*[@id='ltl_reference_type_select_1_chosen']/a";
        public string Additional_SelectReferenceType_DropDown_Values_xpath = ".//*[@id='ltl_reference_type_select_1_chosen']/div/ul/li";
        public string AdditionalReferenceNumber_Value_xpath = ".//*[@id='ltl-reference-num-1']";
        public string AdditionalReferenceNumber2_Value_xpath = ".//*[@id='ltl-reference-num-2']";
        public string DefaultSpecialIntructions_HeaderText_xpath = ".//*[@id='page-content-wrapper']/div[2]/div[2]/div[6]/div/div/div[1]/h3";
        public string DefaultSpecialIntructions_Comments_Id = "specialinstruction";
        public string InusredValue_Text_xpath = ".//*[@id='page-content-wrapper']/div[2]/div[2]/div[6]/div/div/div[2]/div/div[1]/h3";
        public string InsuredValue_TextBox_Id = "Insvalue";
        public string InsuredValue_Type_xpath = ".//*[@id='instype_chosen']/a";
        public string InsuredValue_TypeLabel_Xpath = ".//*[@id='instype_chosen']/a/span";
        public string InsuredValue_Type_Values_xpath = ".//*[@id='instype_chosen']/div/ul/li";
        public string InsuredValue_ToolTip_xpath = ".//*[@id='page-content-wrapper']/div[2]/div[2]/div[6]/div/div/div[2]/div/div[3]/button";
        public string InsuredValue_TermsAndConditionsLink_xpath = ".//*[@id='page-content-wrapper']/div[2]/div[2]/div[6]/div/div/div[2]/div/div[1]/a";
        public string Shipments_ViewRatesButton_xpath = ".//*[@id='page-content-wrapper']/div[2]/div[2]/div[8]/div/button";
        public string Shipments_ViewRatesButton_classname = "//*[@class='btn viewrates fontSize20 btn btn-block btn-warning btn-sm']";
        public string ViewRatesButton_xpath = "//div[@class = 'container-fluid']/div[8]/div/button";
        public string ViewQuoteResults_xpath = "//*[@id='view-quote-results']";
        public string BackToShipmentListButton_Id = "back-btn-shipment-list";
        public string InsuredValue_ToolTip_CSS = ".tooltip-btn.btn.btn-primary.image-only-sm";
        public string InsuredValue_TypeNEW_xpath = ".//*[@id='instype_chosen']/div/ul/li[1]";
        public string InsuredValue_TypeUsed_xpath = ".//*[@id='instype_chosen']/div/ul/li[2]";
        public string InsuredValue_ValueExceeds_xpath = ".//*[@id='shipment-value-warning']/p";
        public string InsuredValue_TermsAndConditions_Heading_xpath = ".//*[@id='shipment-model']//h3";
        public string InsuredValue_TermsAndCondition_DownloadForm_xpath = ".//*[@id='terms-download']";
        public string InsuredValue_TermsAndCondition_CloseButton_xpath = ".//*[@id='shipment-model']//div[3]/a";

        public string ShipmentNum_EditAddShipPage_Xpath = "//span[@id='lbl_EditingShipmentRefNum']";
        public string ShipmentNum_Results_EditAddShipPage_Xpath = "//span[@id='bol-number-text']";
        public string ShipmentNum_ReviewPage_EditAddShipPage_Xpath = "//span[@class='shipmentNumber-text']";
        public string ShipNumEditVerbiage_EditShipPage_Xpath = "//span[contains(text(),'Editing')]";
        public string Station_CustomerName_Xpath = ".//*[@id='stationcustomernamedropdown']";
        public string ErrorMessageReferenceType_Xpath = "";
        public string ReferenceType_Highlight_Id = "ltl-reference-num-1";

        public string ReferenceNumberSection_Xpath = ".//*[@id='Accordion22']/div";
        public string TotalAdditionalReferencesection_Xpath = ".//*[@class='additional-item--referencesection-container fontSize20']/div";

        public string CreateShipmentButton_Id = "";
        public string ErrorHeadingInsured_Xpath = "//div[@id='shipment-value-warning']//h4";
        public string ErrorMessageInsured_Xpath = "//div[@id='shipment-value-warning']//p[@class='message'][contains(text(),'Plea')]";
        public string ErrorMessageCloseIcon_Xpath = "//div[@id='shipment-value-warning']//i[@class='icon-close right']";
        //--------------Shipment confirmation--------//
        //  public string ShipmentCoverageButton_Id = "";
        public string ShipmentConfirmationNumber_Id = "ref-num-label";
        public string confirmation_ViewShipmentCoverageButton_Id = "btn_ViewShipCoverage";
        public string confirmation_CreateShipmentInsured_Id = "btncreateinsuredshipment";

        //--------------Shipment Details--------//

        public string ShipmentDetails_LoadingIcon_ID = "dvLoading";
        public string ShipmentDetails_TerminalIcon_Xpath = "//span[@class='icon-local']";
        public string ShipmentDetails_TerminalInformationModal_Id = "showModalTerminalInfo";
        public string ShipmentDetails_TerminalInformation_Modal_Header_Xpath = ".//div[@id='showModalTerminalInfo']//div[@class='modal-header']//h3";

        public string ShipmentDetails_orgTerminalPageHeader_Id = "origin-header-title";

        public string ShipmentDetails_orgTerminalName_Label_Id = "origin-name-label";
        public string ShipmentDetails_orgTerminalAddress1_Label_Id = "origin-address1-label";
        public string ShipmentDetails_orgTerminalAddress2_Label_Id = "origin-address2-label";
        public string ShipmentDetails_orgTerminalCity_Label_Id = "origin-city-label";
        public string ShipmentDetails_orgTerminalState_Label_Id = "origin-state-label";
        public string ShipmentDetails_orgTerminalZip_Label_Id = "origin-zip-label";
        public string ShipmentDetails_orgTerminalCountry_Label_Id = "origin-country-label";
        public string ShipmentDetails_orgTerminalContactName_Label_Id = "origin-contactname-label";
        public string ShipmentDetails_orgTerminalPhone_Label_Id = "origin-phone-label";
        public string ShipmentDetails_orgTerminalEmail_Label_Id = "origin-email-label";

        public string ShipmentDetails_orgTerminalName_Id = "origin-name";
        public string ShipmentDetails_orgTerminalAddress1_Id = "origin-address1";
        public string ShipmentDetails_orgTerminalAddress2_Id = "origin-address2";
        public string ShipmentDetails_orgTerminalCity_Id = "origin-city";
        public string ShipmentDetails_orgTerminalState_Id = "origin-state";
        public string ShipmentDetails_orgTerminalZip_Id = "origin-zip";
        public string ShipmentDetails_orgTerminalCountry_Id = "origin-country";
        public string ShipmentDetails_orgTerminalContactName_Id = "origin-contactname";
        public string ShipmentDetails_orgTerminalPhone_Id = "origin-phone";
        public string ShipmentDetails_orgTerminalEmail_Id = "origin-email";

        public string ShipmentDetails_desTerminalPageHeader_Id = "destination-header-title";

        public string ShipmentDetails_desTerminalName_Label_Id = "destination-name-label";
        public string ShipmentDetails_desTerminalAddress1_Label_Id = "destination-address1-label";
        public string ShipmentDetails_desTerminalAddress2_Label_Id = "destination-address2-label";
        public string ShipmentDetails_desTerminalCity_Label_Id = "destination-city-label";
        public string ShipmentDetails_desTerminalState_Label_Id = "destination-state-label";
        public string ShipmentDetails_desTerminalZip_Label_Id = "destination-zip-label";
        public string ShipmentDetails_desTerminalCountry_Label_Id = "destination-country-label";
        public string ShipmentDetails_desTerminalContactName_Label_Id = "destination-contactname-label";
        public string ShipmentDetails_desTerminalPhone_Label_Id = "destination-phone-label";
        public string ShipmentDetails_desTerminalEmail_Label_Id = "destination-email-label";

        public string ShipmentDetails_desTerminalName_Id = "destination-name";
        public string ShipmentDetails_desTerminalAddress1_Id = "destination-address1";
        public string ShipmentDetails_desTerminalAddress2_Id = "destination-address2";
        public string ShipmentDetails_desTerminalCity_Id = "destination-city";
        public string ShipmentDetails_desTerminalState_Id = "destination-state";
        public string ShipmentDetails_desTerminalZip_Id = "destination-zip";
        public string ShipmentDetails_desTerminalCountry_Id = "destination-country";
        public string ShipmentDetails_desTerminalContactName_Id = "destination-contactname";
        public string ShipmentDetails_desTerminalPhone_Id = "destination-phone";
        public string ShipmentDetails_desTerminalEmail_Id = "destination-email";

        public string ShipmentDetails_TerminalInformationModalClosebutton_Xpath = "//a[@class='closeOverlay btn colored']";

        //--------------Estimate Class------------

        public string Calculatedclass_Id = "ec-est-class";
        public string CloseBtnPopUpEstimateclass_xpath = ".//*[@id='estimated-class-calc']/div/div/div/div[3]/a[1]";

        ////------------------Results page-------------------------------------------------
        public string ShipResults_PageHeaderText_xpath = "//h1[@class='page-heading']";//"//*[@class='page-heading']//*[text()='Shipment Results (LTL)']";//'col-md-8 col-sm-6 col-xs-9 heading-div']
        public string ShipResults_PageHeaderText_Relativexpath = "//H1[@class='page-heading'][text()='Shipment Results (LTL)']";
        public string ShipResults_Back_To_AddShipment_Button_Id = "Btn_BackAddShipment";
        public string ShipResults_Back_To_ShipmentList_Button_Id = "Btn_BackShipmentList";
        public string ShipResultsInsuredValue_Xpath = "//input[@id='shipValueNumber']";
        public string ShipResultsInsuredValueError_Xpath = "//P[@class='shipmentValu-popup-lbl error-msg insuredMaxValueErrorMessage'][text()='The entered shipment value exceeds $15,000. Please contact your DLS representative.']";
        public string ShipResultsInsuredValModal_Xpath = "//input[@id='shipValueNumber-popup-txt']";
        public string ShipResultsShowInsuredRateButton_Modal_Xpath = "//button[@id='showInsuredRate-popup-btn']";
        public string ShipResultsInsuredRatesModalErrorMessage_Xpath = "//p[@class='error-msg shipmentValu-popup-lbl']";
        public string ShipResultsModalWithoutInsuredRates_Xpath = "//button[@id='create-shipment-btn']";
        public string EditShipResult_UpdateStandardShip_Xpath = "//div[@id='ShipmentResultTable_wrapper']//tbody//tr[1]//td[4]//div[5]//button[1]";
        public string EditShipResult_UpdateInsuredShip_Xpath = "//div[@id='ShipmentResultTable_wrapper']//tbody//tr[1]//td[5]//div[5]//button[1]";
        public string EditShipResult_NoRates_Xpath = "//button[@class='btn shipmentwithoutrates btn btn-warning']";
        public string EditShipConfirmationPage_Verbiage_Xpath = "";

        public string ShipResults_StationName_Id = "station-customer-name";
        public string ShipResults_InsuredValueNote_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[4]/div[1]/p";
        public string ShipResults_EnterInsuredValueText_Xpath = "//*[@id='page-content-wrapper']/div[2]/div/div[3]/div[2]/form/div[1]/div[1]/p";
        public string ShipResults_InsuredRateTextbox_Id = "shipValueNumber";
        public string ShipResults_InsuredValueDropdown_Id = "shipValueType_chosen";
        public string ShipResults_InsuredValueDropdownValues_Xpath = ".//*[@id='shipValueType_chosen']/div/ul/li";
        public string ShipResults_ShowInsuredRateButton_Id = "showInsuredRate";
        public String ShipResults_Internal_Rate_Column_Xpath = ".//*[@id='ShipmentResultTable']/thead/tr/th[6]";
        public string ShipResults_External_Rate_Column_Xpath = ".//*[@id='ShipmentResultTable']/thead/tr/th[5]";

        public string ShipResults_TermsandConditions_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[4]/div[2]/form/div[1]/div[5]/a";
        public string ShipResults_ExportButton_Xpath = ".//*[@id='show-export-btn'][@class = 'btn-icon colored btn_shipExport btn btn-icon']";
        public string ShipResults_BackToShipmentListButton_Id = "Btn_BackShipmentList";
        public string ShipResults_FilterCarrierBy_Xpath = "//*[@class='col-md-10 filter-carrier-lbl']//*[text()='Filter Carriers By:']";
        public string ShipResults_QuickestService_Xpath = "//*[@class='radio inline-element']//*[text()='Quickest Service']";
        public string ShipResults_LeastCost_Xpath = "//*[@class='radio inline-element']//*[text()='Least Cost']";
        public string ShipResults_CarrierColumn_Xpath = ".//*[@id='ShipmentResultTable']/thead/tr/th[1]";
        public string ShipResults_ServiceDaysColumn_Xpath = ".//*[@id='ShipmentResultTable']/thead/tr/th[2]";
        public string ShipResults_DistanceColumn_Xpath = ".//*[@id='ShipmentResultTable']/thead/tr/th[3]";
        public string ShipResults_EstCostColumn_Xpath = ".//*[@id='ShipmentResultTable']/thead/tr/th[4]";
        public string ShipResults_RateColumn_Xpath = "//*[@id='ShipmentResultTable']//*[text()='Insured Rate']";
        public string ShipResults_InsuredRateColumn_Xpath = ".//*[@id='ShipmentResultTable']/thead/tr/th[6]";


        public string ShipResults_CarrierColumnValues_Xpath = ".//*[@id='ShipmentResultTable']/tbody/tr/td[1]/div[@class = 'row']/div[@class = 'col-md-12 carrier-name-col']";
        public string ShipResults_GuaranteedCarriercolValues_Xpath = ".//*[@id='GuaranteedResultTable']//tr/td[1]/div/div[@class='col-md-12 carrier-name-col']";
        public string ShipResults_ServicedaysColumnValues_Xpath = ".//*[@id='ShipmentResultTable']/tbody/tr/td[2]/div[1]";
        public string ShipResults_DistanceColumnValues_Xpath = ".//*[@id='ShipmentResultTable']/tbody/tr/td[3]/div[1]";
        public string ShipResults_RateColumnValues_Xpath = ".//*[@id='ShipmentResultTable']/tbody/tr/td[4]/div[1]";
        public string ShipResults_Internal_EstColumnValues_Xpath = ".//*[@id='ShipmentResultTable']/tbody/tr/td[4]/div[1]";
        public string ShipResults_Internal_RateColumnValues_Xpath = ".//*[@id='ShipmentResultTable']/tbody/tr/td[5]/div[1]";
        public string ShipResults_Internal_InsRateColumnValues_Xpath = ".//*[@id='ShipmentResultTable']/tbody/tr/td[6]/div[1]";

        public string ShipResults_External_CreateShipButton_xpath = ".//*[@id='ShipmentResultTable']/tbody/tr/td[4]/div[5]/button";
        public string ShipResults_Internal_CreateShipButton_xpath = ".//*[@id='ShipmentResultTable']/tbody/tr/td[5]/div[5]/button";
        public string ShipResults_External_CreateInsuredShipButton_xpath = ".//*[@id='ShipmentResultTable']/tbody/tr/td[5]/div[5]/button";
        public string ShipResults_Internal_CreateInsuredShipButton_xpath = ".//*[@id='ShipmentResultTable']/tbody/tr/td[6]/div[5]/button";
        public string ShipResults_External_GuaranteedColumnHeader_RATE_Xpath = "";
        public string ShipResults_External_RateColumn_Xpath = "";
        public string ShipResults_CreateShipButton_Id = "createShipment";
        public string ShipResults_CreateShipInsuredButton_Id = "";

        //public string ShipResults_CreateShipButton_Xpath = ".//*[@id='createShipment']";
        public string ShipResults_UpdateShipButtonFirst_Xpath = ".//*[@id='ShipmentResultTable_wrapper']/table//tbody/tr[1]//button[@id='createShipment']";
        public string ShipResults_UpdateShipButtonAll_Xpath = ".//*[@id='ShipmentResultTable_wrapper']/table//tbody/tr//button[@id='createShipment']";
        public string ShipResults_CreateShipButton_Xpath = ".//*[@id='btnAddAccessorial']";
        public string ShipResults_CreateShipInsuredButton_Xpath = ".//*[@id='btncreateinsuredshipment']";
        public string ShipResults_InsuredValue_Xpath = ".//*[@id='shipValueNumber']";
        public string ShipResults_ShowInsuredRateButton_Xpath = ".//*[@id='showInsuredRate']";
        public string ExcludedcarrierInsRateText_Xpath = ".//*[@id='ShipmentResultTable']//tr/td[6]/div/p";
        public string GuaranteedExcludedcarrierInsRateText_Xpath = ".//*[@id='GuaranteedResultTable']//tr/td[6]/div/p";

        public string ShipmentResults_Guaranteed_CarrierLegalLiability_All_XPath = ".//*[@id='GuaranteedResultTable']/tbody/tr/td[1]/div/div[2]/label";
        public string ShipmentResults_Guaranteed_FirstCarrierLegalLiability_XPath = ".//*[@id='GuaranteedResultTable']/tbody/tr[1]/td[1]/div/div[2]/label";
        public string ShipmentResults_Guaranteed_CarrierLegalLiability_New_Values_All_XPath = ".//*[@id='GuaranteedResultTable']/tbody/tr/td[1]/div/div[2]/span[1]";
        public string ShipmentResults_Guaranteed_CarrierLegalLiability_Used_Values_All_XPath = ".//*[@id='GuaranteedResultTable']/tbody/tr/td[1]/div/div[2]/span[2]";
        public string ShipmentResults_Guaranteed_CarrierMaxLiability_All_XPath = ".//*[@id='GuaranteedResultTable']/tbody/tr/td[1]/div/div[4]/label";
        public string ShipmentResults_Guaranteed_CarrierMaxLiability_New_Values_All_XPath = ".//*[@id='GuaranteedResultTable']/tbody/tr/td[1]/div/div[3]/span[1]";
        public string ShipmentResults_Guaranteed_CarrierMaxLiability_Used_Values_All_XPath = ".//*[@id='GuaranteedResultTable']/tbody/tr/td[1]/div/div[3]/span[2]";
        public string ShipmentResults_Guaranteed_Service_Values_All_XPath = ".//*[@id='GuaranteedResultTable']/tbody/tr[2]/td[2]/div[1]";
        public string ShipmentResults_Guaranteed_ServiceLane_Values_All_XPath = ".//*[@id='GuaranteedResultTable']/tbody/tr[2]/td[2]/div[2]";

        public string ShipmentResults_CarrierLegalLiability_All_XPath = ".//*[@id='ShipmentResultTable']/tbody/tr/td[1]/div/div[3]/label";
        public string ShipmentResults_FirstCarrierLegalLiability_XPath = "//table[@id='ShipmentResultTable']/tbody/tr[1]/td[1]/div/div[2]/label";
        public string ShipmentResults_CarrierLegalLiability_New_Values_All_XPath = "//table[@id='ShipmentResultTable']/tbody/tr/td[1]/div/div[3]/div[1]";
        public string ShipmentResults_CarrierLegalLiability_Used_Values_All_XPath = "//table[@id='ShipmentResultTable']/tbody/tr/td[1]/div/div[3]/div[2]";
        public string ShipmentResults_CarrierMaxLiability_All_XPath = "//table[@id='ShipmentResultTable']/tbody/tr/td[1]/div/div[4]/label";
        public string ShipmentResults_CarrierMaxLiability_New_Values_All_XPath = "//table[@id='ShipmentResultTable']/tbody/tr/td[1]/div/div[4]/div[1]";
        public string ShipmentResults_CarrierMaxLiability_Used_Values_All_XPath = "//table[@id='ShipmentResultTable']/tbody/tr/td[1]/div/div[4]/div[2]";
        public string ShipmentResults_Service_Values_All_XPath = "//table[@id='ShipmentResultTable']/tbody/tr/td[2]/div[1]";
        public string ShipmentResults_ServiceLane_Values_All_XPath = "//table[@id='ShipmentResultTable']/tbody/tr/td[2]/div[2]";
        public string ShipmentResults_EstimateMargin_Xpath = "//table[@id='ShipmentResultTable']/tbody/tr/td[5]/div[6]";
        public string ShipResults_CarrierNameColumns_Xpath = ".//*[@id='ShipmentResultTable']/tbody/tr/td[1]";
        public string ShipmentResults_TotalRate_Xpath = "//div[@class = 'totalRate boldText']";
        public string ShipmentResults_InsRate_Xpath = "//div[@class = 'totalInsuredRate boldText']";
        public string ShipmentResults_EstMarginTotalRate_Xpath = "//div[@class = 'totalRate boldText']";
        public string ShipmentResults_EstTotalRate_Xpath = "//tr/td[4]/div[@class ='totalRate boldText']";

        public string ShipmentResults_DisclaimerTextId = "shipment-Disclaimer-Text";
        public string ShipmentResults_InsuredTermsAndConditionsTextId = "insuredShipmentTermsAndConditions";
        public string ShipmentResults_InsuredTermsAndConditionsLinkClass = "btn-distC";

        public string ShipmentResults_SaveRateAsQuoteButton_Xpath = "//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[2]/td[4]/ul[2]/li/a";
        public string ShipmentResults_SaveInsuredRateAsQuoteButton_Xpath = "//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[5]/ul[2]/li/a";

        //------------------Results page -- Insured Value -----------------------------------
        public string ShipResults_TermsandCondition_Button_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div[2]/div[4]/div[2]/form/div[1]/div[5]/a";
        public string ShipResults_InsuredValueType_Dropdown_Xpath = ".//*[@id='shipValueType_chosen']/a";
        public string ShipResults_InsuredType_New_Xpath = ".//*[@id='shipValueType_chosen']/div/ul/li[1]";
        public string ShipResults_InsuredType_Used_Xpath = ".//*[@id='shipValueType_chosen']/div/ul/li[2]";
        public string ShipResults_INsuredValue_Id = "shipValueNumber";
        public string Shipresults_TermsandCondition_Xpath = "//*[@class='col-md-2 col-sm-12 col-xs-12 no-padding-left terms-cond-link']//*[text()='Terms and Conditions']";
        public string ShipResults_Shipmodel_Heading_Xpath = "//h3[contains(text(),'Terms And Conditions Of Coverage')]";//".//*[@id='shipment-model']/div/div/div/div[1]/h3"
        public string ShipResults_Model_DLSWForm_Xpath = ".//*[@id='terms-download']";
        public string ShipResults_Model_Close_Button_Xpath = ".//*[@id='shipment-model']/div/div/div/div/div[3]/a[@class='closeOverlay btn colored']";
        public string ShipResults_Both_InsuredRateColumn_Xpath = ".//*[@id='ShipmentResultTable']/tbody/tr//div[@class='totalInsuredRate']";
        public string ShipResults_Both_GuaranteedInsuredRateColumn_Xpath = ".//*[@id='GuaranteedResultTable']/tbody/tr//div[@class='totalInsuredRate']";



        //------------------Results page -- FirstCarrierColumnFields---------------------------
        public string ShipResults_FC_CarrierName_Xpath = ".//*[@id='ShipmentResultTable']/tbody/tr[1]/td[1]/div[@class = 'row']/div[@class = 'col-md-12 carrier-name-col boldText']";
        public string ShipResults_FC_ServiceDays_Xpath = ".//*[@id='ShipmentResultTable']/tbody/tr[1]/td[2]/div[1]";
        public string ShipResults_FC_Distance_Xpath = ".//*[@id='ShipmentResultTable']/tbody/tr[1]/td[3]/div";
        public string ShipResults_FC_Total_Xpath = ".//*[@id='ShipmentResultTable']/tbody/tr[1]/td[4]/div[1]";
        public string ShipResults_FC_Fuel_Xpath = ".//*[@id='ShipmentResultTable']/tbody/tr[1]/td[4]/div[2]";
        public string ShipResults_FC_Linehaul_Xpath = ".//*[@id='ShipmentResultTable']/tbody/tr[1]/td[4]/div[3]";
        public string ShipResults_FC_Accessories_Xpath = ".//*[@id='ShipmentResultTable']/tbody/tr[1]/td[4]/div[4]";
        public string ShipResults_FC_InsFuel_Xpath = ".//*[@id='ShipmentResultTable']/tbody/tr[1]/td[4]/div[2]";
        public string ShipResults_FC_InsLinehaul_Xpath = ".//*[@id='ShipmentResultTable']/tbody/tr[1]/td[4]/div[3]";
        public string ShipResults_FC_InsAccessories_Xpath = ".//*[@id='ShipmentResultTable']/tbody/tr[1]/td[5]/div[4]";
        public string ShipResults_FC_InsTotal_Xpath = ".//*[@id='ShipmentResultTable']/tbody/tr[1]/td[5]/div[1]";
        public string ShipResults_FC_EstimateMargin_Xpath = ".//*[@id='ShipmentResultTable']/tbody/tr[1]/td[5]/div[6]";
        public string ShipResults_FC_EstCost_Xpath = ".//*[@id='ShipmentResultTable']/tbody/tr[1]/td[4]/div[1]";

        //------------------Results page -- FirstCarrierColumnFields -- Internal Users---------------------------
        public string ShipResults_InternalFC_EstTotal_Xpath = ".//*[@id='ShipmentResultTable']/tbody/tr[1]/td[4]/div[1]";
        public string ShipResults_InternalFC_EstFuel_Xpath = ".//*[@id='ShipmentResultTable']/tbody/tr[1]/td[4]/div[2]";
        public string ShipResults_InternalFC_EstLinehaul_Xpath = ".//*[@id='ShipmentResultTable']/tbody/tr[1]/td[4]/div[3]";
        public string ShipResults_InternalFC_EstAccessories_Xpath = ".//*[@id='ShipmentResultTable']/tbody/tr[1]/td[4]/div[4]";
        public string ShipResults_InternalFC_Total_Xpath = ".//*[@id='ShipmentResultTable']/tbody/tr[1]/td[5]/div[1]";
        public string ShipResults_InternalFC_Fuel_Xpath = ".//*[@id='ShipmentResultTable']/tbody/tr[1]/td[5]/div[2]";
        public string ShipResults_InternalFC_Linehaul_Xpath = ".//*[@id='ShipmentResultTable']/tbody/tr[1]/td[5]/div[3]";
        public string ShipResults_InternalFC_Accessories_Xpath = ".//*[@id='ShipmentResultTable']/tbody/tr[1]/td[5]/div[4]";
        public string ShipResults_InternalFC_Margin_Xpath = ".//*[@id='ShipmentResultTable']/tbody/tr[1]/td[5]/div[6]";
        public string ShipResults_InternalFC_InsFuel_Xpath = ".//*[@id='ShipmentResultTable']/tbody/tr[1]/td[6]/div[2]";
        public string ShipResults_InternalFC_InsLinehaul_Xpath = ".//*[@id='ShipmentResultTable']/tbody/tr[1]/td[6]/div[3]";
        public string ShipResults_InternalFC_InsAccessories_Xpath = ".//*[@id='ShipmentResultTable']/tbody/tr[1]/td[6]/div[4]";
        public string ShipResults_InternalFC_InsTotal_Xpath = ".//*[@id='ShipmentResultTable']/tbody/tr[1]/td[6]/div[1]";
        public string ShipResults_InternalFC_InsMargin_Xpath = ".//*[@id='ShipmentResultTable']/tbody/tr[1]/td[6]/div[6]";



        public string ShipResults_FC_ExternalCreateShipment_Xpath = ".//*[@id='ShipmentResultTable']/tbody/tr[1]/td[4]/div[5]/button";
        public string ShipResults_FC_CreateShipment_Xpath = ".//*[@id='ShipmentResultTable']/tbody/tr[1]/td[4]/div[5]/button";
        public string ShipResults_InternalFC_CreateShipment_Xpath = ".//*[@id='ShipmentResultTable']/tbody/tr[1]/td[5]/div[5]/button";
        public string ShipResults_FC_CreateInsuredShipment_Xpath = ".//*[@id='ShipmentResultTable']/tbody/tr[1]/td[6]/div[5]/button";
        public string ShipResults_FC_GuaranteedRateAvailable_Xpath = ".//*[@id='ShipmentResultTable']/tbody/tr/td[1]/div/div[4]";
        public string ShipResults_FC_NonGuaranteedCarrierName_Xpath = ".//*[@id='ShipmentResultTable']/tbody/tr/td[1]/div/div[1]";
        public string ShipResults_FC_GuaranteedCarrierName_Xpath = ".//*[@id='GuaranteedResultTable']/tbody/tr/td[1]/div/div[1]";

        public string ShipResults_InsRatePopUp_InsuredRate_Text_Xpath = ".//*[@id='insuredCreateShipmentModal']/div/div/div/div[1]/h3";
        public string ShipResults_InsRatePopUp_ContinueWithoutInsuredRate_button_Id = "create-shipment-btn";
        public string ShipResults_NoShipmentsAvailable_Text_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div[3]/div/h3";
        public string ShipResults_InsRatePopUp_DontShowMeThisAgain_Checkbox_Xpath = ".//*[@id='insuredCreateShipmentModal']/div/div/div/div[2]/div[7]/div/div/div/div/label";


        public string ShipmentTilesPage_Header_Xpath = ".//h1[contains(text(), 'Add Shipment')]";
        public string Shipment_International_Tile_Id = "btn_international";
        public string Shipment_InternationalTile_TypePopUP_Header_Xpath = ".//*[@id='tile-international-content']/div/div/div/div[1]/h3";
        public string Shipment_InternationalTile_Type_dropdown_Xpath = ".//*[@id='shipment_international_type_chosen']/a/span";
        public string Shipment_InternationalTile_Type_dropdownValue_Xpath = ".//*[@id='shipment_international_type_chosen']/div/ul/li";
        public string Shipment_InternationalTile_Level_dropdown_Xpath = ".//*[@id='rate_international_level_chosen']/a/span";
        public string Shipment_InternationalTile_Level_dropdownValue_Xpath = ".//*[@id='rate_international_level_chosen']/div/ul/li";
        public string Shipment_InternationalTile_Type_Closebutton_Xpath = ".//*[@id='tile-international-content']/div/div/div/div[3]/a[1]";
        public string Shipment_InternationalTile_Type_Continuebutton_Xpath = ".//*[@id='btnSubmitShipmentInternational']";
        public string Shipment_Tile_PleaseEnterrequired_Info_Text_Xpath = ".//*[@id='tile-international-content']/div/div/div/div[3]/div    ";
        public string Shipment_International_Locations_And_Dates_Page_Header_Xpath = ".//*[@id='main']/div[2]/div/h3";
        public string Shipment_International_Locations_And_Dates_Page_ServiceType_Xpath = ".//*[@id='h-mode']";
        public string Shipment_International_Locations_And_Dates_Page_Service_Type_Level_Xpath = ".//*[@id='main']/div[2]/div/h6[2]/span[2]";
        public string Shipment_International_Locations_And_Dates_Page_International_Text_Xpath = ".//*[@id='h-mode']";
        public string ShipResults_GuaranteedColumnHeader_CARRIER_Xpath = ".//*[@id='GuaranteedResultTable']/thead/tr/th[1]";
        public string ShipResults_GuaranteedColumnHeader_SERVICEDAYS_Xpath = ".//*[@id='GuaranteedResultTable']/thead/tr/th[2]";
        public string ShipResults_GuaranteedColumnHeader_DISTANCE_Xpath = ".//*[@id='GuaranteedResultTable']/thead/tr/th[3]";
        public string ShipResults_GuaranteedColumnHeader_ESTCOST_Xpath = ".//*[@id='GuaranteedResultTable']/thead/tr/th[4]";
        public string ShipResults_GuaranteedColumnHeader_RATE_Xpath = ".//*[@id='GuaranteedResultTable']//*[text()='Insured Rate']";
        public string ShipResults_GuaranteedRateAvailableButton_Id = "guaranteedratebtn";
        public string ShipResults_GuaranteedRate_Label_Xpath = ".//*[@id='GuaranteedResultTable']/tbody/tr/td[1]/div/div[4]/span/span";
        public string ShipResults_GuaranteedColumn_ESTCOST_Xpath = ".//*[@id='GuaranteedResultTable']/tbody/tr/th[4]";
        public string ShipResults_GuaranteedCarrier_ESTCOSTColumns_Xpath = ".//*[@id='GuaranteedResultTable']/tbody/tr/td[4]";
        public string ShipResults_GuaranteedCarrier_CarrierNameColumns_Xpath = ".//*[@id='GuaranteedResultTable']/tbody/tr/td[1]";
        public string ShipResultsGuaranteed_InsuredShipButton_Xpath = ".//*[@id='GuaranteedResultTable']//tr[1]/td[6]//button";
        public string ShipResultsGuaranteed_standardShipButton_Xpath = ".//*[@id='GuaranteedResultTable']//tr[1]/td[5]//button";


        //-----------------------Domestic add shipment page elements---------------------------
        public string DomesticShipment_TypeValue_Xpath = ".//*[@id='main']/div/div/h6[2]/span[2]";
        public string DomesticShipment_LocationDatesHeader_Xpath = ".//*[@id='main']/div/div/h3";

        //------------------------Review and Submit page elements-----------------------------------
        public string ReviewAndSubmit_Title_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[1]/div/div/div/h1";
        public string ReviewSubmit_EditInfoButton_Id = "";
        public string ReviewSubmit_EditCarrier_Xpath = ".//*[@id='backtoshipmentresultbtn']/span";
        public string ReviewAndSubmit_SubmitShipment_button_Xpath = ".//*[@id='SubmitShipment']";

        public string ReviewSubmit_Section_ShippingFrom_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[1]/div[1]/h3[1]";
        public string ReviewSubmit_ShippingFrom_Name_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[1]/div[1]/span[1]/span";
        public string ReviewSubmit_ShippingFrom_Address_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[1]/div[1]/span[2]";
        public string ReviewSubmit_ShippingFrom_City_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[1]/div[1]/span[3]";
        public string ReviewSubmit_ShippingFrom_State_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[1]/div[1]/span[4]";
        public string ReviewSubmit_ShippingFrom_ZIP_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[1]/div[1]/span[5]";
        public string ReviewSubmit_ShippingFrom_Accessorial_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[1]/div[1]/span[6]/span";
        public string ReviewSubmit_ShippingFrom_Comments_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[1]/div[1]/span[7]/span";

        public string ReviewSubmit_Section_ShippingFromContactInfo_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[1]/div[1]/h3[2]";
        public string ReviewSubmit_ShippingFromContactInfo_Name_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[1]/div[1]/span[8]/span";
        public string ReviewSubmit_ShippingFromContactinfo_Phone_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[1]/div[1]/span[9]/span";
        public string ReviewSubmit_ShippingFromContactinfo_Email_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[1]/div[1]/span[10]/span";
        public string ReviewSubmit_ShippingFromContactinfo_Fax_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[1]/div[1]/span[11]/span";


        public string ReviewSubmit_Section_ShippingTo_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[1]/div[2]/h3[1]";
        public string ReviewSubmit_ShippingTo_Name_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[1]/div[2]/span[1]";
        public string ReviewSubmit_ShippingTo_Address_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[1]/div[2]/span[2]";
        public string ReviewSubmit_ShippingTo_City_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[1]/div[2]/span[3]";
        public string ReviewSubmit_ShippingTo_State_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[1]/div[2]/span[4]";
        public string ReviewSubmit_ShippingTo_ZIP_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[1]/div[2]/span[5]";
        public string ReviewSubmit_ShippingTo_Accessorial_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[1]/div[2]/span[6]/span";
        public string ReviewSubmit_ShippingTo_Comments_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[1]/div[2]/span[7]/span";

        public string ReviewSubmit_Section_ShippingToContactInfo_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[1]/div[2]/h3[2]";
        public string ReviewSubmit_ShippingToContactInfo_Name_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[1]/div[2]/span[8]/span";
        public string ReviewSubmit_ShippingToContactinfo_Phone_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[1]/div[2]/span[9]/span";
        public string ReviewSubmit_ShippingToContactinfo_Email_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[1]/div[2]/span[10]/span";
        public string ReviewSubmit_ShippingToContactinfo_Fax_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[1]/div[2]/span[11]/span";


        public string ReviewSubmit_Section_PickupDate_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[3]/div/h3";
        public string ReviewSubmit_PickupDate_Date_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[3]/div/div/div/div/div[1]/span";
        public string ReviewSubmit_PickupDate_Ready_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[3]/div/div/div/div/div[2]/span";
        public string ReviewSubmit_PickupDate_Close_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[3]/div/div/div/div/div[3]/span";


        public string ReviewSubmit_Section_FreightDescription_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[5]/h3";
        public string ReviewSubmit_FreightDescription_Class_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[5]/div/div/div/div[1]/div/div/div[1]/span/span";
        public string ReviewSubmit_FreightDescription_NMFC_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[5]/div/div/div/div[1]/div/div/div[2]/span/span";
        public string ReviewSubmit_FreightDescription_Quantity_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[5]/div/div/div/div[1]/div/div/div[3]/span/span";
        public string ReviewSubmit_FreightDescription_Weight_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[5]/div/div/div/div[1]/div/div/div[4]/span/span";
        public string ReviewSubmit_FreightDescription_HazMat_NO_Yes_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[5]/div/div/div/div[2]/div/div/div/div/div[1]/span/span";
        public string ReviewSubmit_FreightDescription_HazMat_UNNumberValue_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[5]/div/div/div/div[3]/div/div[1]/div/div/div/div/div[1]/span/span";
        public string ReviewSubmit_FreightDescription_HazMat_CCNNumberValue_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[5]/div/div/div/div[3]/div/div[1]/div/div/div/div/div[2]/span/span";
        public string ReviewSubmit_FreightDescription_HazMat_PackageGroupValue_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[5]/div/div/div/div[3]/div/div[1]/div/div/div/div/div[3]/span/span";
        public string ReviewSubmit_FreightDescription_HazMat_ClassValue_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[5]/div/div/div/div[3]/div/div[2]/div/div/div/div/div[1]/span/span";
        public string ReviewSubmit_FreightDescription_HazMat_ContactNameValue_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[5]/div/div/div/div[3]/div/div[2]/div/div/div/div/div[2]/span/span";
        public string ReviewSubmit_FreightDescription_HazMat_PhoneValue_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[5]/div/div/div/div[3]/div/div[2]/div/div/div/div/div[3]/span/span";
        public string ReviewSubmit_FreightDescription_Length_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[5]/div/div/div/div[2]/div/div/div/div/div[2]/span/span";
        public string ReviewSubmit_FreightDescription_Width_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[5]/div/div/div/div[2]/div/div/div/div/div[3]/span/span";
        public string ReviewSubmit_FreightDescription_Height_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[5]/div/div/div/div[2]/div/div/div/div/div[4]/span/span";
        public string ReviewSubmit_FreightDescription_Description_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[5]/div/div/div/div[3]/div/div/div/div/div/span/span";



        public string ReviewSubmit_Section_ReferenceNumber_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[6]/div/h3";
        public string ReviewSubmit_ReferenceNumber_Number_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[6]/div/div/div/div/div/div";
        public string ReviewSubmit_CustomerSpecifcReferenceHeader_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[8]/div[1]/div/h3";
        public string ReviewSubmit_CustomerSpecificReference_MoveType_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[8]/div[1]/div/div/div[1]/span";
        public string ReviewSubmit_CustomerSpecificReference_InventoryLocation_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[8]/div[1]/div/div/div[2]/span";
        public string ReviewSubmit_FirstReference_Value_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[6]/div/div/div/div/div/div[1]/span/span[1]";
        public string ReviewSubmit_SecondReference_Value_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[6]/div/div/div/div/div/div[2]/span/span[1]";

        public string ReviewSubmit_Section_DefaultSpecialInstruction_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[9]/div/div/div[1]/h3";
        public string ReviewSubmit_DefaultSpecialInstruction_Instruction_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[9]/div/div/div[1]/span";

        public string ReviewSubmit_Section_InsuredValue_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[9]/div/div/div[2]/h3";
        public string ReviewSubmit_InsuredValue_Value_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[9]/div/div/div[2]/span";

        public string ReviewSubmit_Section_CarrierInfo_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[4]/div/div/div[1]/h4";
        public string ReviewSubmit_CarrierInfo_CarrierName_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[4]/div/div/div[2]/div/div/div[1]/div/span";
        public string ReviewSubmit_InternalCarrierInfo_CarrierName_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[4]/div/div/div[2]/div/div/div[1]/span";
        public string ReviewSubmit_CarrierInfo_CarrierLogo_Id = "carrierlogo";
        public string ReviewSubmit_CarrierInfo_LegalLiabilityText_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[4]/div/div/div[2]/div/div/div[1]/div/span[1]";
        public string ReviewSubmit_CarrierInfo_LegalNew_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[4]/div/div/div[2]/div/div/div[1]/div/span[2]";
        public string ReviewSubmit_CarrierInfo_LegalUsed_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[4]/div/div/div[2]/div/div/div[1]/div/span[3]";
        public string ReviewSubmit_CarrierInfo_MaxLiabilityText_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[4]/div/div/div[2]/div/div/div[1]/div/span[4]";
        public string ReviewSubmit_CarrierInfo_MaxNew_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[4]/div/div/div[2]/div/div/div[1]/div/span[5]";
        public string ReviewSubmit_CarrierInfo_MaxUsed_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[4]/div/div/div[2]/div/div/div[1]/div/span[6]";


        public string ReviewSubmit_CarrierInfo_EstimatedServiceDays_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[4]/div/div/div[2]/div/div/div[2]";
        public string ReviewSubmit_CarrierInfo_Distance_Xpath = ".//*[@id='page-content-wrapper']//div[3]/span/b";
        public string ReviewSubmit_CarrierInfo_Distance_Value_Xpath = ".//div[@class='lineadjustment Distanceestimated margintopline']";
        public string ReviewSubmit_CarrierInfo_EstRevenue_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[4]/div/div/div[2]/div/div/div[4]/span[1]/b";
        public string ReviewSubmit_CarrierInfo_EstRevenue_Value_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[4]/div/div/div[2]/div/div/div[4]/h2";
        public string ReviewSubmit_CarrierInfo_EstRevenue_FuelValue_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[4]/div/div/div[2]/div/div/div[4]/span[2]/span";
        public string ReviewSubmit_CarrierInfo_EstRevenue_LineHaulValue_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[4]/div/div/div[2]/div/div/div[4]/span[3]/span";
        public string ReviewSubmit_CarrierInfo_EstRevenue_AccessorialValue_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[4]/div/div/div[2]/div/div/div[4]/span[4]/span";

        public string ReviewSubmit_CarrierInfo_EstCost_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[4]/div/div/div[2]/div/div/div[5]/span[1]/b";
        public string ReviewSubmit_CarrierInfo_EstCost_Value_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[4]/div/div/div[2]/div/div/div[5]/h2";
        public string ReviewSubmit_CarrierInfo_EstCost_FuelValue_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[4]/div/div/div[2]/div/div/div[5]/span[2]/span";
        public string ReviewSubmit_CarrierInfo_EstCost_LineHaulValue_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[4]/div/div/div[2]/div/div/div[5]/span[3]/span";
        public string ReviewSubmit_CarrierInfo_EstCost_AccessorialsValue_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[4]/div/div/div[2]/div/div/div[5]/span[4]/span";


        public string ReviewSubmit_CarrierInfo_EstMargin_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[4]/div/div/div[2]/div/div/div[6]/span/b";
        public string ReviewSubmit_CarrierInfo_EstMargin_Value_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[4]/div/div/div[2]/div/div/div[6]/h1";

        public string ReviewSubmit_EditInfoButton_Xpath = ".//*[@id='backtoaddshipmentbtn']/span";
        public string ReviewSubmit_EditSippingInfo_Button_Id = "backtoaddshipmentbtn";
        public string ReviewSubmit_EditCarrierInfo_Button_Id = "backtoshipmentresultbtn";
        public string ReviewSubmit_SubmitShipment_Button_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/button";



        public string ReviewPage_SubmitButton_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/button";
        public string ReviewPage_SubmitButton_id = "SubmitShipment";
        public string ReviewSubmit_EditShipment_Xpath = ".//*[@id='backtoaddshipmentbtn']/span";
        //------------------------Confirmation page elements----------------------------------------

        public string Confirmation_PrintShippingLabel_button = "//*[@id='page-content-wrapper']/div[2]/div[1]/div[8]/div[2]/div[3]/button";
        public string Confirmation_PrintShippingLabelInternalUser_button = "//*[@id='printLabelBtnDiv']/button";
        public string ReviewSubmit_Full_Page_Lable_Id = "btn_FullPageLabel";
        public string ReviewSubmit_2Label_Par_Page_Id = "btn_2LabelPerPage";
        public string ReviewSubmit_4Label_Par_Page_Id = "btn_4LabelPerPage";
        public string ReviewSubmit_6Label_Par_Page_Id = "btn_6LabelPerPage";
        public string ViewBillOfLandining_Option_Id = "btn_ViewBOl";

        //------------------------Confirmation page elements-----------------------------------
        public string confirmation_pageheader = ".//*[@id='page-content-wrapper']/div[2]/div[1]/div[1]/div[1]/h1";
        public string confirmation_Serviceslabel = ".//*[@id='page-content-wrapper']/div[2]/div[1]/div[2]/div[1]/p";
        public string confirmation_ServicesInternalLabel_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div[1]/div[3]/div[1]/p";
        public string confirmation_ServicesValue_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div[1]/div[2]/div[2]/p";
        public string confirmation_ServicevalueInternal_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div[1]/div[3]/div[2]/p";
        public string confirmation_BOLNumberlabelInternal_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div[1]/div[4]/div[1]/p";
        public string confirmation_BOLNumberlabel = ".//*[@id='page-content-wrapper']/div[2]/div[1]/div[3]/div[1]/p";
        public string confirmation_BOLValue_Xpath = ".//*[@id='ref-num-label']";
        public string confirmation_stationcustomerlabel = ".//*[@id='page-content-wrapper']/div[2]/div[1]/div[2]/div[1]/p";
        public string confirmation_StatusLabelInternal_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div[1]/div[5]/div[1]/p";
        public string confirmation_Statuslabel = ".//*[@id='page-content-wrapper']/div[2]/div[1]/div[4]/div[1]/p";
        public string confirmation_StatusValueInternal_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div[1]/div[5]/div[2]/p";
        public string confirmation_StatusValue_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div[1]/div[4]/div[2]/p";
        public string LTL_StationCustomerName_value_xpath = ".//*[@id='stat-cust-label']";
        public string confirmation_uploaddocumentsection = ".//*[@id='shipment-document-dropzone']";
        public string confirmation_Noteverbiage = ".//*[@id='page-content-wrapper']/div[2]/div[1]/div[6]/div/p";
        public string confirmation_dropzoneheader = ".//*[@id='shipment-document-dropzone']/div";
        public string confirmation_Noteverbiage_internal = ".//*[@id='page-content-wrapper']/div[2]/div[1]/div[7]/div/p";
        public string confirmation_dropzoneheader_internal = ".//*[@id='shipment-document-dropzone']/div";
        public string confirmation_confirmmessage = ".//*[@id='page-content-wrapper']/div[2]/div[1]/div[8]/div[1]/p[1]";
        public string confirmation_confirmmessageinternal = ".//*[@id='page-content-wrapper']/div[2]/div[1]/div[9]/div[1]/p[1]";
        public string confirmation_confirmmessageemail = ".//*[@id='page-content-wrapper']/div[2]/div[1]/div[8]/div[1]/p[2]";
        public string confirmation_confirmmessageemail_internal = ".//*[@id='page-content-wrapper']/div[2]/div[1]/div[9]/div[1]/p[2]";
        public string confirmation_addanothershipmentbutton = ".//*[@id='Btn_AddAnotherShipment']";
        public string confirmation_viewshipmentdetailsbutton = ".//*[@id='btn_ViewShipDetails']";
        public string confirmation_printshippinglabelbutton = ".//*[@id='page-content-wrapper']/div[2]/div[1]/div[8]/div[2]/div[3]/button";
        public string confirmation_linktobrowse = ".//*[@id='shipment-document-dropzone']/div/span/strong";
        public string confirmation_linktobrowse_internal = ".//*[@id='shipment-document-dropzone']/div/span/strong";
        public string confirmation_BOLbutton = ".//*[@id='billOfLadingBtnDiv']/button";
        public string confirmation_BOLdropvalues = ".//*[@id='billOfLadingBtnDiv']/ul/li";
        public string confirmation_summarybutton = ".//*[@id='shipSummaryBtnDiv']/button";
        public string confirmation_BOLdropdown_Xpath = ".//*[@id='billOfLadingBtnDiv']/button";
        public string confirmation_ViewBOL_xpath = ".//*[@id='btn_ViewBOl']";
        public string confirmation_EmailBOL_xpath = ".//*[@id='btn_EmailBOL']";
        public string confirmation_Shpsummarydrpdown_xpath = ".//*[@id='shipSummaryBtnDiv']/ul/li";
        public string confirmation_ViewShpsummary_xpath = ".//*[@id='btn_ViewShipSummary']";
        public string confirmation_EmailShpsummary_xpath = ".//*[@id='btn_EmailShipDoc']";

        //--------------Insured Value Reminder Modal Pop Up --------------------
        public string InsuredValueModalHeaderTest_xpath = ".//*[@id='insuredCreateShipmentModal']/div/div/div/div[1]/h3";
        public string InsuredValueModalTextMessage_xpath = ".//*[@id='insuredCreateShipmentModal']/div/div/div/div[2]/div[1]/div/h5";
        public string InsuredValueModal_insuredvalueTextbox_xpath = ".//*[@id='shipValueNumber-popup-txt']";
        public string InsuredValueModal_DefualtInsuredTypeSelection_xpath = ".//*[@id='InsvalueModal_chosen']/a/span";
        public string InsuredValueModal_ShowInsuredRateButton_id = "showInsuredRate-popup-btn";
        public string InsuredValueModal_ContinueWithoutRateButton_id = "create-shipment-btn";
        public string InusredValueModal_DontShowMeThisAgain_xpath = ".//*[@id='insuredCreateShipmentModal']/div/div/div/div[2]/div[7]/div/div/div/div/label";
        public string InsuredValueModal_InsuredTypeSelectionOptions_xpath = ".//*[@id='InsvalueModal_chosen']/div/ul/li";
        public string InsuredValueModal_InsuredTypeSelection_New_xpath = ".//*[@id='InsvalueModal_chosen']/div/ul/li[1]";
        public string InsuredValueModal_InsuredTypeSelection_Used_xpath = ".//*[@id='InsvalueModal_chosen']/div/ul/li[1]";

        public string InsuredRateColumn_xpath = ".//*[@id='ShipmentResultTable']/thead/tr/th[5]";
        //public string ShipResults_NoShipmentsAvailable_Text_Xpath = "";
        public string ShipResults_CreateShipmentWithoutCarrierRate_Button_xpath = ".//*[@id='gridLTLresult']/button";


        // ------------------------------------------------------------------
        public string EmailmodalPopup_xpath = ".//*[@id='modal_EmailShipDoc']/div/div/div";
        public string EmailmodalPopupheader_xpath = ".//*[@id='modal_EmailShipDoc']/div/div/div/div[1]/h2";
        public string Emailmodal_emailtextbox_id = "Email_ShpDoc";
        public string Emailmodal_additionalemailbutton = "btn_AddAdditionalEmail_ShpDoc";
        public string Emailmodal_additionalemailtextbox1 = ".//*[@id='modal_EmailShipDoc']/div/div/div/div[2]/div[1]/div/div[1]/input";
        public string Emailmodal_additionalemailtextbox2 = ".//*[@id='modal_EmailShipDoc']/div/div/div/div[2]/div[1]/div[2]/div[1]/input";
        public string Emailmodal_additionalRemove1 = ".//*[@id='modal_EmailShipDoc']/div/div/div/div[2]/div[1]/div[1]/div[2]/button";
        public string Emailmodal_additionalRemove2 = ".//*[@id='modal_EmailShipDoc']/div/div/div/div[2]/div[1]/div[2]/div[2]/button";
        public string Emailmodal_messagebox_id = "email-message";
        public string Emailmodal_sendcopycheckinput_xpath = ".//*[@id='modal_EmailShipDoc']/div/div/div/div[2]/div[2]/input";
        public string Emailmodal_sendcopycheck_xpath = ".//*[@id='modal_EmailShipDoc']/div/div/div/div[2]/div[2]/label";
        public string Emailmodal_cancel_id = "confirm_Report_cancel_ShpDoc";
        public string Emailmodal_sendemail_id = "btn_ConfirmReportOk";
        public string Emailmodal_errorforinvalid_xpath = ".//*[@id='warning-missing-info-filter']";
        public string Emailmodal_errorformandatory_xpath = ".//*[@id='warning-missing-info-filter']";
        public string Confimrationpopup_emails_xpath = ".//*[@id='modal_EmailConfirmation']/div/div/div";
        public string Confimrationpopup_header_xpath = ".//*[@id='modal_EmailConfirmation']/div/div/div/div[1]/h3";
        public string Confimrationpopup_cancel_xpath = ".//*[@id='cancel_success_modal']";
        public string Confimrationpopup_email1_xpath = ".//*[@id='modal_EmailConfirmation']/div/div/div/div[2]/p[1]";
        public string Confimrationpopup_email2_xpath = ".//*[@id='modal_EmailConfirmation']/div/div/div/div[2]/p[2]";

        //---------------------------------------------------------------
        public string ConfrimationFileUpload_Xpath = "//*[@id='shipment-document-dropzone']/div/p";
        public string FileUploadErrorpopupheader_Xpath = ".//*[@id='UploadError-PopUp']//h3";
        public string FileUploadErrorMsg_Xpath = ".//*[@class='rules_upload']";
        public string FileUploadinvalidfile_Xpath = ".//*[@class='error-message-upload']/p";
        public string FileUploadpopupClose_Xpath = ".//a[@class='closeOverlay btn']";
        public string FirstSavedFile_Xpath = ".//*[@id='page-content-wrapper']/div[2]//div[1]/a";
        public string FirstSavedFile_SavedBtn_Xpath = ".//div[@class='shipmetSuccess']/span";
        public string FirstSavedFile_RemoveBtn_Xpath = ".//*[@id='page-content-wrapper']/div[2]//div[3]/div/i";

        public string FirstSavedFilelink_Xpath = ".//*[@id='page-content-wrapper']/div[2]//div[1]/a";
        public string FirstSavedsuccess_Xpath = ".//*[@class='shipmetSuccess']";
        //public string Fileremove_Xpath = ".//*[@class='dz-remove file-remove']";
        public string Fileremove_Xpath = ".//*[@id='page-content-wrapper']/div[2]//div[3]/div/i";
        // public string Fileremove_Xpath = ".//*[@class='dz-remove file-remove']";

        //----------------------------------------------------------------------------
        public string CopyIconFirst_AddShipmentList_Xpath = ".//*[@id='ShipmentGrid']/tbody/tr[1]/td/a[2]";
        public string CopyIconAllUsers_AddShipment_Xpath = ".//*[@id='ShipmentGrid']/tbody/tr[1]/td[/a[2]";
        public string CopyShipment_ConfirmMessage_Xpath = ".//*[@id='copy-shipment']/div/div/div[1]/h6";
        public string CopyShipmentConfirmButton_Id = "copy-shipment-Ok";
        public string CopyAddShipment_StationAndCustomerName_Id = "stationcustomernamedropdown";
        public string CopyAddShipmentTitle_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div[1]/div[1]/div/div/div[1]/h1";
        public string AddShipGridFirstStationName_Xpath = ".//*[@id='ShipmentGrid']/tbody/tr[1]/td[2]";
        public string ChooseCustomerType_Xpath = ".//*[@id='CustomerType_chosen']/a";
        public string ChooseCustomerTypeDropdownValues_Xpath = ".//*[@id='CustomerType_chosen']/div/ul/li";
        public string AddAdditioanlItemClass_Id = "freightdescription-1";
        public string AddAdditionalNmfc_Id = "freightNMFC-1";
        public string AddAdditionalDesc_Id = "freightDesc-1";
        public string AddAdditionalQuantity_Id = "freightquantity-1";
        public string AddAdditionalWeight_Id = "freightweight-1";
        public string AddAdditionalQunatityType_Xpath = ".//*[@id='freightquantitytype_1_chosen']/a";
        public string AddAdditionalWeightType_Xpath = ".//*[@id='freightweighttype_1_chosen']/a";
        public string AddAdditionalDimensionType_Xpath = ".//*[@id='freightdimensiontype_1_chosen']/a";

        public string QuoteIcon_Xpath = ".//*[@id='raterequest']/i";
        public string QuoteSearchBox_Id = "searchbox";
        public string QuoteNew_Id = "showNew";
        public string QuoteFirstRowValues_Xpath = ".//*[@id='QuotesGrid']/tbody/tr[1]/td";
        public string QuoteRequestNum_Xpath = ".//*[@id='QuotesGrid']/tbody/tr[1]/td[3]";
        public string QuoteRequestNumInternal_Xpath = ".//*[@id='QuotesGrid']/tbody/tr[1]/td[4]";
        public string QuoteExpand_Xpath = ".//*[@id='QuotesGrid']/tbody/tr[1]/td[8]/button";
        public string QuoteExpandInternal_Xpath = ".//*[@id='QuotesGrid']/tbody/tr[1]/td[9]/button";
        public string QuoteCreateShipment_Id = "createShipment";
        public string QuoteCustomerSelectionDropdown_Xpath = ".//*[@id='CategoryType_chosen']/a";
        public string QuoteCustomerSelectionDropdownSearchTextBox_Xpath = ".//*[@id='CategoryType_chosen']/div/div/input";
        public string QuoteCustomerSelectioDropdownValues_Xpath = ".//*[@id='CategoryType_chosen']/div/ul/li";
        public string QuoteGridAllRecords_Xpath = ".//*[@id='QuotesGrid']/tbody/tr/td";
        public string QuoteCreateShipment_Xpath = ".//*[@id='btn-CreateShipment']";


        public string GetQuote_LTLLabel_Id = "btn_ltl";
        public string Quote_FirstCreateShipment_Xpath = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[4]/button";
        public string Quote_InsuredModalPopUp_Xpath = ".//h3[contains(text(), 'Insured Rates')]";
        public string QuoteContinueWithoutInsuredRates_Id = "create-shipment-btn";
        public string ExternalUserDashboardErrorMessageHeader_Xpath = ".//*[@id='error']//h3";
        public string ExternalUserErrorMessageCloseButton_Id = "btn-error-Close";

        //----- Shipment Information Screen------//

        public string LTL_ShipinformationPage_TermsandCond_Xpath = "//*[@class='btn-distC']";

        public string LTL_ShipinformationPage_VerbiageText_Xpath = ".//*[@id='page-content-wrapper']//*[contains(text(),'Quote expires')]";
        //  public string LTL_ShipinformationPage_ModalHeader_Xpath = "//*[@class='modal-header']//*[contains(text(), 'Terms And Conditions')]";
        public string LTL_ShipinformationPage_ModalHeader_Xpath = "//*[@class='modal-header']//*[contains(text(), 'Terms And Conditions')]";
        public string LTL_QuoteInformationPage_TermsandCond_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div[2]/div[4]/div/p[2]/a";
        public string LTL_QuoteIformationPage_ModalHeader_Xpath = ".//*[@id='showModalScrollableCntBtn']/div/div/div/div/div[1]/h3";

        // Review and Submit Page
        public string ReviewSubmitShippingToInformation = "//div[@class='panel-body']/div/div[@class = 'col-md-12']/div[1]";
        public string ReviewSubmitPickupDetails = "//div[@class='panel-body']/div/div[@class = 'col-md-12']/div[3]";
        public string ReviewSubmitFrieghtDescriptionHeading = "//h3[@class = 'shipping_color'][text() = 'Freight Description']";
        public string ReviewSubmitFrieghtDescription = "//div[@class = 'HazardcontentSection']/div[@class = 'row']/div[@class= 'col-md-12']/div[1]";
        public string ReviewSubmitFrieghtDescriptionHazmat = "//div[5]/div/div/div/div[3]";
        public string ReviewSubmitReferenceNumberSection = "//div[@class='panel-body']/div/div[@class = 'col-md-12']/div[6]";
        public string ReviewSubmitInstructionAndInsuredValueSection = "//div[@class='panel-body']/div/div[@class = 'col-md-12']/div[9]";
        public string ReviewSubmitCarrierInformationSection = "//div[@class = 'col-md-12 externaluser']//div[@class = 'col-md-12']";
        public string ReviewSubmitCarrierInformationSection_InternalUser = "//div[@class = 'col-md-12 internaluser']//div[@class = 'col-md-12']";

        public string CreateShipmemtIdShipResults = "createShipment";
        public string ShipmentIcon_Id = "shipment";

        //Overlength 
        public string ServicesAccessorialsOverlengthSelected_xpath = ".//*[@id='shippingfromaccessorial_chosen']/ul/li[1]";
        public string ServicesAccessorialsOverlengthRemoval_xpath = ".//*[@id='shippingfromaccessorial_chosen']/ul/li[1]/a";
        public string OverlengthWarningPopup_xpath = "//h4[@class='message']";
        public string OverLenghtWarningPopupMessage_xpath = ".//*[@class='length-validation pointer-icon-left']//p[@class='message']";
        public string OverLengthWarningMessageRemovalButton_xpath = "//div[@class='length-validation pointer-icon-left']/h4//i[@class='icon-close right']";

        public string AddAdditionalItemButton_xpath = "//button[@class='btn-sm addtional additional-item-shipment btn btn-primary']";

        public string FreightDesp_SecondItem_Length_Id = "freightlength-1";
        public string FreightDesp_SecondItem_Width_Id = "freightwidth-1";
        public string FreightDesp_SecondItem_Height_Id = "freightheight-1";

        public string FreightDesp_ThirdItem_Length_Id = "freightlength-2";
        public string FreightDesp_ThirdItem_Width_Id = "freightwidth-2";
        public string FreightDesp_ThirdItem_Height_Id = "freightheight-2";

        public string Freight_ThirdSavedItem_Xpath = ".//*[@id='freightdescription-2']";
        public string Freight_ThirdNMFC_Xpath = ".//*[@id='freightNMFC-2']";
        public string Freight_ThirdItemDesc_Xpath = ".//*[@id='freightDesc-2']";
        public string Freight_ThirdQuantity_Xpath = ".//*[@id='freightquantity-2']";
        public string Freight_ThirdWeight_Xpath = ".//*[@id='freightweight-2']";
        public string Freight_ThirdHazardousYes_Xpath = "//LABEL[@for='Hazard-2_Hazard-2Yes'][text()='Yes']";
        public string Freight_ThirdUANNum_Xpath = ".//*[@id='txtUNNumber-2']";
        public string Freight_ThirdCCNNum_Xpath = ".//*[@id='txtfreight-CNnnumber-2']";
        public string Freight_ThirdHazmatGrp_Xpath = "//div[@id='Hazmatpackagegroup_2_chosen']//span[contains(text(),'Select hazmat packaging group...')]";
        public string Freight_ThirdHazmatGrpValues_Xpath = ".//*[@id='Hazmatpackagegroup_2_chosen']//ul/li";
        public string Freight_ThirdHazmatClass_Xpath = "//div[@id='HazmatClass_2_chosen']//span[contains(text(),'Select hazmat class...')]";
        public string Freight_ThirdHazmatClassValues_Xpath = ".//*[@id='HazmatClass_2_chosen']//ul/li";
        public string Freight_ThirdEmergencyContactName_Xpath = ".//*[@id='txtEmrResContName-2']";
        public string Freight_ThirdEmergencyPhoneNum_Xpath = ".//*[@id='txtEmrResPhNumber-2']";

        public string Freight_FourthSavedItem_Xpath = ".//*[@id='freightdescription-3']";
        public string Freight_FourthItemDesc_Xpath = ".//*[@id='freightDesc-3']";
        public string Freight_FourthQuantity_Xpath = ".//*[@id='freightquantity-3']";
        public string Freight_FourthWeight_Xpath = ".//*[@id='freightweight-3']";
        public string Freight_FourthLength_Xpath = ".//*[@id='freightlength-3']";
        public string Freight_FourthWidth_Xpath = ".//*[@id='freightwidth-3']";
        public string Freight_FourthHeight_Xpath = ".//*[@id='freightheight-3']";
        public string ShipResultsCarrierRate_Xpath = ".//*[@id='ShipmentResultTable']//tr[1]/td[5]/div[1]";
        public string EditButtonShipmentlistpage_Xpath = "//button[@class='btn btn-default colored btn-sm editShipmentBtn']";
        public string EditButtonShipmentlistpageExt_Xpath = "//button[@class='btn btn-default colored btn-sm btn-EditShipmentExtUsers']";

        public string BOLNum_Xpath = "//input[@id='bolnum']";
        public string AddShip_InsuredVal_Xpath = "//input[@id='Insvalue']";

        //---------- AddShipment new screen 2019---------------//

        public string ShippingFrom_SelectedSavedAddress_Id = "ShippingFrom_SavedAddress";
        public string ShippingFrom_LocationName_NewScreen_Id = "ShippingFrom_Name";
        public string ShippingFrom_LocationAddressLine1_NewScreen_Id = "ShippingFrom_Address1";
        public string ShippingFrom_LocationAddressLine2_NewScreen_Id = "ShippingFrom_Address2";
        public string ShippingFrom_zipcode_NewScreen_Id = "ShippingFrom_ZipCode";
        public string ShippingFrom_CountryDropDown_NewScreen_Id = "ShippingFrom_Country";
        public string ShippingFrom_CountryDropDown_NewScreen_xpath = ".//*[@id='ShippingFrom_Country_chosen']/a";
        public string ShippingFrom_City_NewScreen_Id = "ShippingFrom_City";
        public string ShippingFrom_StateDropdwon_NewScreen_Id = "ShippingFrom_State";
        public string ShippingFrom_StateDropdwon_NewScreen_Xpath = ".//*[@id='ShippingFrom_State_chosen']/a";
        public string ShippingFrom_StateDropdwon_SelectedValue_NewScreen_xpath = ".//*[@id='ShippingFrom_State_chosen']/div/ul/li";
        public string ShippingFrom_Canada_SelectStateProvinceNewScreen_xpath = ".//*[@id='ShippingFrom_State']";
        public string ShippingFrom_ContactName_NewScreen_Id = "ShippingFrom_ContactName";
        public string ShippingFrom_ContactPhone_NewScreen_Id = "ShippingFrom_PhoneNumber";
        public string ShippingFrom_ContactEmail_NewScreen_Id = "ShippingFrom_Email";
        public string ShippingFrom_ContactFax_NewScreen_Id = "ShippingFrom_FaxNumber";
        public string ShippingFrom_ContactPhoneExt_NewScreen_Id = "ShippingFrom_PhoneNumberExt";
        public string ShippingFrom_ContactFaxExt_NewScreen_Id = "ShippingFrom_FaxNumberExt";
        public string ShippingTo_SelectedSavedAddress_Id = "ShippingTo_SavedAddress";
        public string ShippingTo_LocationName_NewScreen_Id = "ShippingTo_Name";
        public string ShippingTo_LocationAddressLine1_NewScreen_Id = "ShippingTo_Address1";
        public string ShippingTo_LocationAddressLine2_NewScreen_Id = "ShippingTo_Address2";
        public string ShippingTo_zipcode_NewScreen_Id = "ShippingTo_ZipCode";
        public string ShippingTo_CountryDropDown_NewScreen_xpath = ".//*[@id='ShippingTo_Country_chosen']/a";
        public string ShippingTo_City_NewScreen_Id = "ShippingTo_City";
        public string ShippingTo_StateDropdwon_NewScreen_Id = "ShippingTo_State";
        public string ShippingTo_StateDropdwon_NewScreen_Xpath = ".//*[@id='ShippingTo_State_chosen']/a";
        public string ShippingTo_StateDropdwon_SelectedValue_NewScreen_xpath = ".//*[@id='ShippingTo_State_chosen']/div/ul/li";
        public string ShippingTo_Canada_SelectStateProvinceNewScreen_xpath = ".//*[@id='ShippingTo_State']";
        public string ShippingTo_ContactName_NewScreen_Id = "ShippingTo_ContactName";
        public string ShippingTo_ContactPhone_NewScreen_Id = "ShippingTo_PhoneNumber";
        public string ShippingTo_ContactEmail_NewScreen_Id = "ShippingTo_Email";
        public string ShippingTo_ContactFax_NewScreen_Id = "ShippingTo_FaxNumber";
        public string ShippingTo_ContactPhoneExt_NewScreen_Id = "ShippingTo_PhoneNumberExt";
        public string ShippingTo_ContactFaxExt_NewScreen_Id = "ShippingTo_FaxNumberExt";
        public string ShippingTo_AccessorialDropdown_Id = "ShippingTo_ddlServicesList_chosen";
        public string ShippingFrom_AccessorialDropdown_Id = "ShippingFrom_ddlServicesList_chosen";
        public string ShippingFrom_Accessorial_Xpath = ".//*[@id='ShippingFrom_ddlServicesList_chosen']/ul/li/input";
        public string ShippingFrom_AccessorialDropdownValues_Xpath = ".//*[@id='ShippingFrom_ddlServicesList_chosen']/div/ul";
        public string ShippingFrom_RemoveAccessorial_Xpath = ".//*[@id='ShippingFrom_ddlServicesList_chosen']/ul/li[2]/a";
        public string ShippingFrom_SelectedAccessorial_Xpath = ".//*[@id='ShippingFrom_ddlServicesList_chosen']/ul/li";
        public string ShippingTo_AccessorialDropdownValues_Xpath = ".//*[@id='ShippingTo_ddlServicesList_chosen']/div/ul";
        public string ShippingTo_SelectedAccessorial_Xpath = ".//*[@id='ShippingTo_ddlServicesList_chosen']/ul/li";
        public string ShippingTo_RemoveAccessorial_Xpath = ".//*[@id='ShippingTo_ddlServicesList_chosen']/ul/li[2]/a";


        public string ShipppingFrom_SaveOrigin_NewScreen_Xpath = "//input[@placeholder='Select or search for a saved origin...']";
        public string ShippingFrom_SavedOrigin_NewScreen_Xpath = "//input[@id='ShippingFrom_SavedAddress']";
        public string ShippingFrom_ClearAddress_NewScreen_Xpath = "(//A[text()='Clear Address'][text()='Clear Address'])[1]";
        public string ShippingTo_CountryDropDown_NewScreen_Id = "ShippingTo_Country";
        public string ShippingFrom_SaveOriginInfo_Checkbox_Xpath = "//input[@id='ShippingFrom_SaveAddress']";
        public string ShippingFrom_SaveOriginInfo_Label_Xpath = "//label[contains(text(),'Save Origin Info')]";
        public string ShippingFrom_Map_NewScreen_Xpath = "//a[contains(text(),'View Origin on Map')]";
        public string ShippingFrom_MapLabel_NewScreen_Xpath = "//a[contains(text(),'View Origin on Map')]";
        public string ShippingFrom_ContactPhoneHighlight_NewScreen_Xpath = "//div[@class='form-group has-error']//div//input[@placeholder='Contact phone...']";
        public string ShippingFrom_ContactPhoneHighlight_classname = "form-group has-error";
        public string ShippingFrom_CommentsNewScreen_Xpath = "//input[@id='ShippingFrom_Comments']";
        public string ShippingFrom_CommentsPopup_Xpath = ".//*[@class='popover-content']";
        public string ShippingTo_SavedDestination_NewScreen_Xpath = "//INPUT[@id='ShippingTo_SavedAddress']";
        public string ShippingTo_ClearAddress_NewScreen_Xpath = "(//A[text()='Clear Address'][text()='Clear Address'])[2]";
        //public string ShippingTo_StateDropdwon_SelectedValue_NewScreen_xpath = ".//*[@id='ShippingTo_ddlState_chosen']/div/ul";
        public string ShippingTo_SaveDestinationInfo_Checkbox_Xpath = "//input[@id='ShippingTo_SaveAddress']";
        public string ShippingTo_SaveDestinationInfo_Label_Xpath = "//label[contains(text(),'Save Destination Info')]";
        public string ShippingTo_Map_NewScreen_Xpath = "//a[contains(text(),'View Destination on Map')]";
        public string ShippingTo_MapLabel_NewScreen_Xpath = "//a[contains(text(),'View Destination on Map')]";
        public string ShippingTo_Accessorial_Xpath = ".//*[@id='ShippingTo_ddlServicesList_chosen']/ul/li/input";
        public string ShippingFrom_AccessorialDropdownVal_Xpath = ".//*[@id='ShippingFrom_ddlServicesList_chosen']/div/ul/li";
        public string ShippingFrom_ErrorMessage_NewScreen_Xpath = "//span[@class='field-validation-error']//span[@id='ShippingFrom_PhoneNumber-error']";
        public string ShippingFrom_FaxError_NewScreen_Xpath = "//span[@class='field-validation-error']//span[@id='ShippingFrom_FaxNumber-error']";
        public string ShippingFrom_EmailError_NewScreen_Xpath = "//span[@class='field-validation-error']//span[@id='ShippingFrom_Email-error']";
        public string ShippingTo_ErrorMessage_NewScreen_Xpath = "//span[@class='field-validation-error']//span[@id='ShippingTo_PhoneNumber-error']";
        public string ShippingTo_FaxError_NewScreen_Xpath = "//span[@class='field-validation-error']//span[@id='ShippingTo_FaxNumber-error']";
        public string ShippingTo_EmailError_NewScreen_Xpath = "//span[@class='field-validation-error']//span[@id='ShippingTo_Email-error']";

        public string ShippingTo_CommentsNewScreen_Xpath = "//input[@id='ShippingTo_Comments']";
        public string ShippingTo_CommentsPopup_Xpath = ".//*[@class='popover-content']";
        public string ShippingFrom_ServiceAccessorialSearchType_Xpath = "//div[@id='ShippingFrom_ddlServicesList_chosen']/ul/li/input";
        public string Shipping_ViewRates_Xpath = "//button[@class='btn btn-block btn-warning']";











        public string AddShipment_LTL_2019_PageTitle_xpath = "//h1[@class='shipment-header']";
        public string AddShipmentLTL_2019_RquiredFieldVerbiage_xpath = ".//p[@class='primary fontBold']";
        public string BacktoShipmentList_2019_Id = "back-btn-shipment-list";
        public string AddShipmentLTL_2019_ShippingFromSectionTitle_xpath = "//form/div[1]//div[1]/div/div[1]/h4";
        public string AddShipmentLTL_2019_ShippingToSectionTitle_xpath = "//form/div[1]//div[2]/div/div[1]/h4";
        public string AddShipmentLTL_2019_PickupDateSectionTitle_xpath = "//form//div[3]/div[1]/div[1]/h4";
        public string AddShipmentLTL_2019_SpecialInstructionsSectionTitle_xpath = "//form//div[3]/div[2]/div[1]/h4";
        public string AddShipmentLTL_2019_InsuredValueSectionTitle_xpath = "//form//div[3]/div[3]/div[1]/h4";
        public string AddShipmentLTL_2019_ReferenceNumberSectionTitle_xpath = "//form//div[3]/div[4]/div[1]/h4";
        public string AddShipmentLTL_2019_FreightDescriptionSectionTitle_xpath = "//form/div[2]/div/div/div[1]/h4";
        public string AddShipmentLTL_2019_ViewRatesButton_xpath = ".//button[@class='btn btn-block btn-warning']";
        public string AddShipmentLTL_2019_StationandCustomerName_Id = "txt_StationCustomerName";
        public string ShipmentListHeader_2019_css = "h1";
        public string AddShipmentLTL_StationCustomerNotEditable_2019_xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[1]/div[2]/div";

        public string ShippingFrom_CountryDropDownValues_2019_xpath = ".//*[@id='ShippingFrom_Country_chosen']/div/ul/li";
        public string ShippingTo_CountryDropDownValues_2019_xpath = ".//*[@id='ShippingTo_Country_chosen']/div/ul/li";
        public string ShippingFrom_CanadaStateDropDownValues_2019_xpath = ".//*[@id='ShippingFrom_State']/option";

        //------Shipping Saved Addresses--------

        public string AddShipmentLTL_2019_ShippingFromSavedAddressDropDown_Id = "ShippingFrom_SavedAddress";
        public string AddShipmentLTL_2019_ShippingFromSavedAddressDropDownValues_xpath = ".//*[@id='scrollable-dropdown-menu-Origin']/div//div[@class='tt-dataset-autos']//div/p";
        public string AddShipmentLTL_2019_ShippingFromFirstSavedAddressValue_xpath = ".//*[@id='scrollable-dropdown-menu-Origin']/div//div[@class='tt-dataset-autos']//div[1]/p";
        public string AddShipmentLTL_2019_ShippingToSavedAddressDropDown_Id = "ShippingTo_SavedAddress";
        public string AddShipmentLTL_2019_ShippingToSavedAddressDropDownValues_xpath = ".//*[@id='scrollable-dropdown-menu-Destination']/div//div[@class='tt-dataset-autos']//div/p";
        public string AddShipmentLTL_2019_ShippingToFirstSavedAddressValue_xpath = ".//*[@id='scrollable-dropdown-menu-Destination']/div//div[@class='tt-dataset-autos']//div[1]/p";

        public string SpecialInstructionsTitle_NewScreen_Xpath = ".//h4[text()='Special Instructions']";
        public string SpecialInstructionsTextBox_NewScreen_Id = "specialinstruction";
        public string SpecialInstructionsTextBox_NewScreen_Xpath = "//textarea[@placeholder='Enter any special instructions...']";

        public string ShippingFrom_SavedAdress_Id = "ShippingFrom_SavedAddress";
        public string ShippingFrom_Accessorial_NewScreen_Xpath = "(//input[@value='Select Some Options'])[1]";
        public string ShippingFrom_Comments_NewScreen_Id = "ShippingFrom_Comments";
        public string ShippingFrom_Checkedbox_NewScreen_Id = "ShippingFrom_SaveOriginInfo";
        public string ShippingTo_SavedAdress_Id = "ShippingTo_SavedAddress";
        public string ShippingTo_Comments_NewScreen_Id = "ShippingTo_Comments";
        public string ShippingTo_Accessorial_NewScreen_Xpath = "(//input[@value='Select Some Options'])[2]";
        public string ShippingTo_Checkedbox_NewScreen_Id = "ShippingTo_SaveOriginInfo";
        public string ShippingTo_ClearAddress_Xpath = "(//a[contains(text(),'Clear Address')])[2]";
        public string ShippingFrom_ClearAddress_Xpath = "(//a[contains(text(),'Clear Address')])[1]";
        public string ShippingFrom_ViewOriginLocationMap_newScreen_Xpath = "//a[contains(text(),'View Origin on Map')]";
        public string ShippingTo_ViewOriginLocationMap_newScreen_Xpath = "//a[contains(text(),'View Destination on Map')]";
        public string ShippingFrom_MapClose_Button_NewScreen_Xpath = "//a[@class='closeOverlay btn colored']";
        public string SatelliteImage_Xpath = "//div[@id='minimap']/div/div[2]/button";
        public string ShippingTo_MapValidation_Message_NewScreen_Xpath = "//h6[contains(text(),'Please enter all required destination address fields')]";
        public string ShippingFrom_MapValidation_Message_NewScreen_Xpath = "//h6[contains(text(),'Please enter all required origin address fields')]";

        public string CopyiconFirstRecord_shipmentlist_Xpath = ".//*[@id='ShipmentGrid']/tbody/tr[1]//*[@class = 'icon-copy']";
        public string CopyShipmentOkModalPopup_Id = "copy-shipment-Ok";
        public string ReturniconFirstRecord_shipmentlist_Xpath = ".//*[@id='ShipmentGrid']/tbody/tr[1]//*[@class = 'Return Shipment']";
        public string ReturnShipmentYesModalPopup_Id = "Return-shipment-Ok";
        public string EditShipmentFirstRecord_Shipmentlist_Xpath = ".//*[@id='ShipmentGrid']/tbody/tr[1]//*[@class = 'btn btn-default colored btn-sm editShipmentBtn']";
        public string TermsAndConditionsLink_AddShipmentLTLPage = ".//*[@id='page-content-wrapper']//*[@class = 'shipment-terms pull-right terms-condition-pop-up fontSize20']";
        public string TermsAndConditionsEmbeddedLinkShipmentResultsLTLPage_Xpath = ".//*[@id='insuredShipmentTermsAndConditions']/a";

        //-----------------Shipment Results Terminal modal-----------------
        public string ShipmentResultTerminalLink_Xpath = "//div[@id='ShipmentResultTable_wrapper']//tr[2]//td[3]//a[1]";
        public string ShipmentResultsTerminalPopupCloseButton_Xpath = "//div[@class='modal-dialog modal-lg']//a[@class='closeOverlay btn colored'][contains(text(),'Close')]";
        public string ShipmentResultsCarriers_Xpath = "//div[@id='ShipmentResultTable_wrapper']//tr";
        public string ShipmentResultsCarrierName_Xpath = "//*[@id='ShipmentResultTable']/tbody/tr[2]/td[1]/div/div[2]";
        public string ShipmentSelectIten_Xpath = "//div[@id='scrollable-dropdown-menu-Origin']/div/span/span/div/span/div[4]/p";
        public string ShipmentResultsTerminalModalHeader_Xpath = "//*[@id='showModalTerminalInfo']//div[1]/h3";
        
    }

}
