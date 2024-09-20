using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Objects
{
    public class Shipmentlist : ObjectRepository
    {
        public string ErrorPopUpClose_Button_Xpath = ".//*[@id='btn-error-Close']";
        public string ErrorMessage_Xpath = ".//*[@id='error']/div/div/div/div[1]/h3";
        public string ShipmentIcon_Xpath = ".//*[@id='shipment']/i";
        public string ShipmentList_TitleLegacy_Xpath = ".//*[@id='body']/section/div[3]/h1";
        public string ShipmentList_Title_Xpath = ".//*[@id='page-content-wrapper']//h1";
        public string ShipmentList_FilteredReports_Xpath = ".//*[@id='ReportType_chosen']/a";
        public string ShipmentList_ShowFilters_Xpath = ".//*[@id='toggleFilters']";
        public string ShipmentList_HideFilters_Xpath = ".//*[@id='toggleFilters']";
        public string ShipmentList_ReferenceNumLookup_Xpath = ".//*[@id='txtReferenceNumer']";
        public string ShipmentList_SearchGridValuesTexTBox_Xpath = ".//*[@id='searchbox']";
        public string ShipmentList_FilterBy_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div[3]/div/div/div[2]/div/span[1]/label";
        public string ShipmentList_FilterBy_Id = "FILTERby_chosen";
        public string ShipmentList_FilterByDropdown_Xpath = ".//*[@id='FILTERby_chosen']/a";
        public string ShipmentList_FilterByDropdownValues = ".//*[@id='FILTERby_chosen']/div/ul/li";
        public string ShipmentList_ScheduledToDeliver_Xpath = ".//*[@id='FILTERby_chosen']/div/ul/li[1]";
        public string ShipmentList_ScheduledToPickup_Xpath = ".//*[@id='FILTERby_chosen']/div/ul/li[2]";
        public string ShipmentList_StartDate_Xpath = ".//*[@id='Start_Date']";
        public string ShipmentList_EndDate_Xpath = ".//*[@id='End_Date']";
        public string ShipmentList_ExportButton_Id = "menu1";
        public string ShipmentList_ExportOptions_Xpath = ".//*[@id='export-list']/li/a";
        public string ShipmentListSearchBox_XPath = ".//*[@id='toggle-button']";
        public string ShipmentListSearchBox_SelectAll_Xpath = ".//*[@id='dropdown-display']/form/div[1]/div/div[1]/div[1]/label";
        public string ShipmentListSearchBox_AllDropdownValues_Xpath = ".//*[@id='dropdown-display']/form/div[1]/div/div/div";
        public string ShipmentListSearchBox_Id = "searchbox";
        public string ShipmentListGridNoResult_Xpath = "//td[@class='dataTables_empty']";
        public string PROnumberLink_SearchedRefNumber = ".//*[@id='ShipmentGrid']//td[3]//a/span";

        public string ShipmentList_CustomerDropdown_SelectedValue_Xpath = ".//*[@id='CustomerType_chosen']/a/span";
        public string ShipmentListSearchBox_stationname_Xpath = ".//*[@id='dropdown-display']/form/div[1]/div/div[1]/div[3]/label";
        public string ShipmentListSearchBox_Customername_Xpath = ".//*[@id='dropdown-display']/form/div[1]/div/div[1]/div[4]/label";
        public string ShipmentListSearchBox_ESTREVENUE_Xpath = ".//*[@id='dropdown-display']/form/div[1]/div/div[2]/div[7]/label";
        public string ShipmentListSearchBox_ESTCOST_Xpath = ".//*[@id='dropdown-display']/form/div[1]/div/div[2]/div[8]/label";
        public string ShipmentListSearchBox_ESTMARGIN_Xpath = ".//*[@id='dropdown-display']/form/div[1]/div/div[2]/div[9]/label";
        public string ShipmentListSearchBox_ClearAll_Button_Id = "clear-all-btn";
        public string ShipmentList_CustomerSelection_Xpath = "//*[@class='chosen-single chosen-default']//*[text()='Select an account to display...']";
        public string ShipmentList_CustomerSelection_label_Xpath = ".//*[@id='CustomerType_chosen']/a/span";
        public string ShipmentList_CustomerSelection_DropdownSearch_Xpath = ".//*[@id='CustomerType_chosen']//div/input";
        public string ShipmentList_CustomerSelection_Dropdown_Values_Xpath = ".//*[@id='CustomerType_chosen']/div/ul/li";
        public string ShipmentList_CustomerSelection_Dropdown_FirstValue_Xpath = ".//*[@id='CustomerType_chosen']/div/ul/li[4]";
        public string ShipmentList_SearchBox_DropdownArrow_Xpath = ".//*[@id='toggle-button']";
        //public string ShipmentList_Search_ReferenceNumber_Checkbox_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div[2]/div/div[2]/div/div/form/div/div/button";
        //public string ShipmentList_Search_Status_Checkbox_Xpath = "";
        //public string ShipmentList_Search_Service_Checkbox_Xpath = ".//*[@id='dropdown-display']/form/div[1]/div/div[1]/div[8]/label";

        public string ShipmentList_Referencenumber_Searchbox_Id = "txtReference";
        public string ShipmentList_Referencenumber_searcharrow_Id = "btnRefSubmit";
        public string ShipmentList_Referencenumber_errormessage_Xpath = ".//*[@id='error']/p";
        public string ShipmentList_Referencenumbersgrid_Xpath = ".//*[@id='ShipmentGrid']/tbody/tr/td[2]/button";
        public string ShipmentList_GridNoResultsfound_Xpath = ".//*[@id='ShipmentGrid']/tbody/tr/td";
        public string ShipmentList_AddShipmentButton_Id = "add-shipment-btn";
        public string ShipmentList_AddShipmentButtonInternalUser_Id ="shipment-list";


        public string ShipmentList_LTLPage_Header_Xpath = ".//*[@id='page-content-wrapper']//h1";
        public string ShipmentList_LTLtile_Id = "btn_ltl";
        public string ShipmentList_Truckloadtile_Id = "btn_truckload";
        public string ShipmentList_PartialTruckloadtile_Id = "btn_partial_truckload";
        public string ShipmentList_Intermodeltiles_Id = "btn_intermodel";
        public string Addshipment_pageheader_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div[1]/div[1]/div/div/div[1]/h1";
        public string ShipmentList_SearchBox_ToggleButton_Id = "toggle-button";
        public string ShipmentList_Referencenumber_searcharrow_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div[2]/div/div[2]/div/div/form/div/div/button";
        public string ShipmentList_morethan10Refval_Xpath = ".//*[@id='reference-val-validation']/div/div/div[2]/h6";
        
        public string ShipmentList_DatePicker_Remove_Button_xpath = ".//*[@id='reset-datepicker']";
        public string AddShipmentCustomerLabelDropdown_xpath = "//p[@id='stationcustomernamedropdown-external']";
        public string AddShipmentLTLCustomerLabelDropdown_Xpath = "//p[@id='stationcustomernamedropdown-external']";
        public string AddShipmentLTLCustomerLabel_ExternalUser_Xpath = ".//*[@id='stationcustomernamedropdown-external']";
        public string OriginLocationName_Id = "txtOrginName";
        public string OriginAddress_Id = "txtOrginAddr1";
        public string OriginZip_Id = "origin-zip";
        public string destinationLocation_Id = "txtDestName";
        public string destinationAddress_Id = "txtDestAddr1";
        public string destinationZip_Id= "destination-zip";
        public string freightCharges_Id = "freightdescription-0";
        public string description_Id = "freightDesc-0";
        public string freightQuantity_Id = "freightquantity-0";
        public string freightWeight_Id = "freightweight-0";
        public string ReferenceSearchforAllCustomersErrmsg_Xpath = ".//*[@id='ShipmentGrid']/tbody/tr/td";
        public string CustomerNameDisplayed_Copy_AddShipment_Xpath = ".//*[@id='page-content-wrapper']//*[@class='customer-name']/p";

        public string ShipmentList_AddShipmentInactiveMessage_xpath = "";


        //---- ------------------------Grid Search-----------------------------
        public string ShipmentList_Search_ReferenceNumber_Checkbox_Xpath = ".//*[@id='dropdown-display']/form/div[1]/div/div[1]/div[2]/label";
        public string ShipmentList_Search_Status_Checkbox_Xpath = ".//*[@id='dropdown-display']/form/div[1]/div/div[1]/div[3]/label";
        public string ShipmentList_Search_Service_Checkbox_Xpath = ".//*[@id='dropdown-display']/form/div[1]/div/div[1]/div/label[.='SERVICE']";
        public string ShipmentList_SearchBox_AllDropdownValues_Xpath = ".//*[@id='dropdown-display']/form/div[1]/div/div/div/label";
        public string ShipmentList_SearchDropdown_NoteSection_Id = "search-title";
        public string ShipmentList_TotalRecords_Xpath = ".//*[@id='ShipmentGrid']/tbody/tr";

        public string ShipmentList_ExportOption_All_Xpath = ".//*[@id='export-list']/li[1]/a";
        public string ShipmentList_ExportOption_Displayed_Xpath = ".//*[@id='export-list']/li[2]/a";

        public string ShipmentList_Search_StationName_StationUsers_xpath = ".//*[@id='dropdown-display']/form/div[1]/div/div[1]/div[3]/label";
        public string ShipmentList_Search_CustomerName_StationUsers_xpath = ".//*[@id='dropdown-display']/form/div[1]/div/div[1]/div[4]/label";
        public string ShipmentList_Search_PickUp_StationUsers_xpath = ".//*[@id='dropdown-display']/form/div[1]/div/div[1]/div[6]/label";

        //--------------------------Shipment list pagination--------------------------------------------
        public string ShipmentList_TopGrid_ViewDropdown_Xpath = ".//*[@id='ShipmentGrid_length']/label";
        public string ShipmentList_TopGrid_ViewDropdownValues_Xpath = ".//*[@id='ShipmentGrid_length']/label/select/option";
        public string ShipmentList_BottomGrid_ViewDropdown_Xpath = ".//*[@id='ShipmentGrid_wrapper']/div[2]/div/div[2]/div[1]/label";
        public string ShipmentList_BottomGrid_ViewDropdownValues_Xpath = ".//*[@id='ShipmentGrid_wrapper']/div[2]/div/div[2]/div[1]/label/select/option";
        public string ShipmentList_TopGrid_DisplayListView_Xpath = ".//*[@id='ShipmentGrid_info']";
        public string ShipmentList_BottomGrid_DisplayListView_Xpath = ".//*[@id='ShipmentGrid_wrapper']/div[2]/div/div[1]/div";
        public string ShipmentList_TopGrid_RightNavigationIcon_Xpath = ".//*[@id='ShipmentGrid_next']/a";
        public string ShipmentList_TopGrid_LeftNavigationIcon_Xpath = ".//*[@id='ShipmentGrid_previous']/a";
        public string ShipmentList_BottomGrid_RightNavigationIcon_Xpath = ".//*[@id='ShipmentGrid_wrapper']/div[2]/div/div[2]/div[2]/ul/li[2]";
        public string ShipmentList_BottomGrid_LeftNavigationIcon_Xpath = ".//*[@id='ShipmentGrid_wrapper']/div[2]/div/div[2]/div[2]/ul/li[1]";


        //---------------------------Shipment List Table----------------------------------------------------

        public string ShipmentListGrid_loadingIcon_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div[4]/div[1]/span";
        public string ShipmentListGrid_CustomerloadingIcon_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div[5]/div[1]/span";
        public string ShipmentList_NoRecords_Xpath = ".//*[@id='ShipmentGrid']/tbody/tr/td";
        public string ShipmentListGrid_HeaderValues_Xpath = ".//*[@id='ShipmentGrid']/thead/tr/th";
        public string ShipmentListGrid_RefNumHeader_Xpath = ".//*[@id='ShipmentGrid']/thead/tr/th[1]";
        public string ShipmentListGrid_RefNumAllValues_Xpath = ".//*[@id='RefID']";
        public string ShipmentListGrid_StationOrCustomerNameHeader_Xpath = ".//*[@id='ShipmentGrid']/thead/tr/th[2]";
        public string ShipmentListGrid_StationOrCustomerNameAll_Values_Xpath = ".//*[@id='ShipmentGrid']/tbody/tr/td[2]";
        public string ShipmentListGrid_RefValues_Xpath = ".//*[@id='ShipmentGrid']/tbody/tr/td[2]";

        public string ShipmentListGrid_ServiceNameEU_Xpath = ".//*[@id='ShipmentGrid']/tbody/tr/td[2]";
        public string ShipmentListGrid_CustomerNameAll_Values_Xpath = ".//*[@id='ShipmentGrid']/tbody/tr/td[2]/span[2]";
        public string ShipmentListGrid_ServiceHeader_Xpath = "";
        public string ShipmentListGrid_ServiceAllValues_Xpath = "";
        public string ShipmentListGrid_StatusHeader_Header = "";
        public string ShipmentListGrid_StatusAllValues_Xpath = "";
        public string ShipmentListGrid_PickUpHeader_Xpath = "";
        public string ShipmentListGrid_PickUpAllValues_Xpath = "";
        public string ShipmentListGrid_DeliveryHeader_Xpath = "";
        public string ShipmentListGrid_DeliveryAllValues_Xpath = "";
        public string ShipmentListGrid_OriginHeader_Xpath = "";
        public string ShipmentListGrid_OriginAllValues_Xpath = "";
        public string ShipmentListGrid_DestinationHeader_Xpath = "";
        public string ShipmentListGrid_DestinationAllValues_Xpath = "";
        public string ShipmentListGrid_RatesHeader_Xpath = ".//*[@id='ShipmentGrid']/thead/tr/th[9]";
        public string ShipmentListGrid_RatesAllValues_Xpath = ".//*[@id='ShipmentGrid']/tbody/tr/td[9]";
        public string Shipment_ESTREVENUEvalueall_Xpath = ".//*[@id='ShipmentGrid']/tbody/tr/td[9]/span[2]";
        public string ShipmentListGrid_MoreInfoIcon_Id = ".//*[@id='ShipmentGrid']/tbody/tr[1]/td[8]/a[1]";
        public string ShipmentListGrid_MoreInfoIcon_Xpath = ".//*[@id='ShipmentGrid']/tbody/tr[1]/td[8]/a";
        public string ShipmentListGrid_CopyIcon_Xpath = ".//*[@id='ShipmentGrid']/tbody/tr/td/a[2]/span";
        public string ShipmentListGrid_CopyIcon_First_Xpath = ".//*[@id='ShipmentGrid']//tr[1]/td[8]/a[2]";
        public string ShipmentListGrid_ReturnIcon_Xpath = ".//*[@id='ShipmentGrid']/tbody/tr/td[10]/a[3]/img";
        public string ShipmentList_ReferenceNumberColumn_Highlighted_Xpath = ".//*[@id='ShipmentGrid']/tbody/tr[@role = 'row']/td[1]/button";
        public string ShipmentList_ServiceColumn_Highlighted_Xpath = ".//*[@id='ShipmentGrid']/tbody/tr[@role = 'row']/td[2]";
        public string ShipmentList_StatusColumn_Highlighted_Xpath = ".//*[@id='ShipmentGrid']/tbody/tr[@role = 'row']/td[3]/div[1]/span";
        public string ShipmentListGrid_Highlight_Class = "highlight";
        public string ShipmentList_NoOfRows_Xpath = ".//*[@id='ShipmentGrid']/tbody/tr";
        public string ShipmentListGrid_ShipmentDetailsButton_Id = "RefID";
        public string ShipmentListGrid_CopyIcon_Class = "btn btn-icon image-only-sm iconcopy";
        public string ShipmentListGrid_CopyIcons_Xpath = ".//*[@id='ShipmentGrid']/tbody/tr/td[8]/a[2]";
        public string ShipmentListGrid_ReturnIcon_Id = ".//*[@id='ShipmentGrid']/tbody/tr[2]/td[10]/a[3]/img";
        public string ShipmentListGrid_QuantityLabel_Xpath = ".//*[contains(@id,'popover')]/div[2]/table/tbody/tr[1]/td[1]";
        public string ShipmentListGrid_Quantity_Xpath = ".//*[contains(@id,'popover')]/div[2]/table/tbody/tr[1]/td[2]";
        public string ShipmentListGrid_WeightLabel_Xpath = ".//*[contains(@id,'popover')]/div[2]/table/tbody/tr[2]/td[1]";
        public string ShipmentListGrid_Weight_Xpath = ".//*[contains(@id,'popover')]/div[2]/table/tbody/tr[2]/td[2]";
        public string ShipmentListGrid_CarrierLabel_Xpath = ".//*[contains(@id,'popover')]/div[2]/table/tbody/tr[4]/td[1]";
        public string ShipmentListGrid_Carrier_Xpath = ".//*[contains(@id,'popover')]/div[2]/table/tbody/tr[4]/td[2]";
        public string ShipmentListGrid_ShipChargeLabel_Xpath = ".//*[contains(@id,'popover')]/div[2]/table/tbody/tr[3]/td[1]";
        public string ShipmentListGrid_ShipCharge_Xpath = ".//*[contains(@id,'popover')]/div[2]/table/tbody/tr[3]/td[2]";
        public string ShipmentListGrid_ShipChargeLabelCSA_Xpath = ".//*[contains(@id,'popover')]/div[2]/table/tbody/tr[5]/td[1]";
        public string ShipmentListGrid_ShipChargeCSA_Xpath = ".//*[contains(@id,'popover')]/div[2]/table/tbody/tr[5]/td[2]";
        public string ShipmentListGrid_ServiceLevelLabelCSA_Xpath = ".//*[contains(@id,'popover')]/div[2]/table/tbody/tr[4]/td[1]";
        public string ShipmentListGrid_ServiceLevelCSA_Xpath = ".//*[contains(@id,'popover')]/div[2]/table/tbody/tr[4]/td[2]";
        public string ShipmentListGrid_ServiceTypeLabelCSA_Xpath = ".//*[contains(@id,'popover')]/div[2]/table/tbody/tr[3]/td[1]";
        public string ShipmentListGrid_ServiceTypeCSA_Xpath = ".//*[contains(@id,'popover')]/div[2]/table/tbody/tr[3]/td[2]";
        public string ShipmentList_EditShipmentButton_Selector = "#ShipmentGrid > tbody > tr.odd > td.all.RatesColumn > button";

        public string AddShipment_CreditHoldModalLTL_Selector = "#showCreditHoldErrorModelLtlForShipment > div > div > div > div";

        public string ShipmentList_RefNumber_FirstValue_Xpath = "";
        public string ShipmentDetails_Id = "RefID";
        public string ShipmentGrid_FirstRow_Xpath = ".//*[@id='ShipmentGrid']/tbody/tr[1]/td";

        public string ShipmentList_NoOf_Rows_Xpath = ".//*[@id='ShipmentGrid']/tbody/tr";
        public string ShipmentList_CopyIcon_ModelText_Xpath = ".//*[text()='Copy the selected shipment and create a new shipment entry?']";
        public string ShipmentList_CopyIcon_Model_CancelButton_Xpath = ".//*[@id='copy-shipment']//a[1]";
        public string ShipmentList_CopyIcon_Model_CopyShipmentButton_Id = "copy-shipment-Ok";
       

        public string ShipmentListGrid_AllUsers_ReturnIcon_Xpath = ".//tr[1]/td[@class = ' InternalColumn']/a[@class = 'btn btn-icon image-only-sm returnshipment']/img";
        public string ShipmentListGrid_RetrunShipmentIcon_First_Xpath = ".//*[@id='ShipmentGrid']//tr[1]/td[8]/a[3]";
        public string ShipmentListGrid_External_ReturnIcon_Xpath = ".//*[@id='ShipmentGrid']/tbody/tr/td[8]/a[3]/img";
        public string ShipmentList_ReturnShipmentHeaderText_xpath = "//*[text()='Create Return Shipment']";
        public string ShipemntList_ReturnShipment_ConfirmationText_xpath = ".//*[@id='return-shipment']/div/div/div[2]/h6";
        public string ShipmentList_ReturnShipment_Yes_Xpath = "//*[@id='Return-shipment-Ok']";
        public string ShipmentList_ReturnShipment_No_Xpath = ".//*[text()='No']";
        public string ShipmentLocationsandDates_xpath = ".//*[@id='main']/div[2]/div/h3";

        public string ShipmentList_StationNameColumn_Highlighted_StationUsers_Xpath = ".//*[@id='ShipmentGrid']/tbody/tr[@role = 'row']/td[2]/span[1]/span";
        public string ShipmentList_CustomerNameColumn_Highlighted_StationUsers_Xpath = ".//*[@id='ShipmentGrid']/tbody/tr[@role = 'row']/td[2]/span[2]/span";
        public string ShipmentList_PickUpColumn_Highlighted_StationUsers_Xpath = ".//*[@id='ShipmentGrid']/tbody/tr[@role = 'row']/td[5]/span[1]/span";


        //------------------------------ShipmentListFirstRowdata for internal users------------------------------
        public string Shipmentlist_FirstRow_MoreInfoIcon_Xpath = ".//*[@id='ShipmentGrid']/tbody/tr[1]/td[8]/a[1]";
        public string Shipmentlist_FirstRow_RefColumn_Xpath = "//*[@id='ShipmentGrid']/tbody/tr[1]/td[2]/button";
        public string Shipmentlist_FirstRow_ServiceColumn_Xpath = ".//tbody/tr[1]/td[3]";
        public string Shipmentlist_FirstRow_StationColumn_Xpath = ".//tbody/tr[1]/td[2]/span[2]";
        public string Shipmentlist_FirstRow_StatusColumn_Xpath = ".//tbody/tr[1]/td[4]/div/span";
        public string Shipmentlist_FirstRow_PickupColumn_Xpath = ".//tbody/tr[1]/td[5]/span[1]";
        public string Shipmentlist_FirstRow_DeliveryColumn_Xpath = ".//tbody/tr[1]/td[6]/span[1]";
        public string Shipmentlist_FirstRow_OriginColumn_Xpath = ".//tbody/tr[1]/td[7]";
        public string Shipmentlist_FirstRow_DestinationColumn_Xpath = ".//tbody/tr[1]/td[8]";
        public string Shipmentlist_FirstRow_Quantity_Xpath = ".//*[contains(@id,'popover')]/div[2]/table/tbody/tr[1]/td[2]";
        public string Shipmentlist_FirstRow_Weight_Xpath = ".//*[contains(@id,'popover')]/div[2]/table/tbody/tr[2]/td[2]";
        public string Shipmentlist_FirstRow_ShipCharge_Xpath = "";
        public string Shipmentlist_FirstRow_EstCost_Xpath = ".//tbody/tr[1]/td[9]/span[4]";
        public string Shipmentlist_FirstRow_EstRev_Xpath = ".//tbody/tr[1]/td[9]/span[2]";
        public string Shipmentlist_FirstRow_EstMar_Xpath = ".//tbody/tr[1]/td[9]/span[6]";
        public string Shipmentlist_FirstRow_ServiceTypeOCarrier_Xpath = ".//*[contains(@id,'popover')]/div[2]/table/tbody/tr[3]/td[2]";
        public string Shipmentlist_FirstRow_ServiceLevel_Xpath = ".//*[contains(@id,'popover')]/div[2]/table/tbody/tr[4]/td[2]";
        public string Shipmentlist_FirstRow_QuantityLabel_Xpath = ".//*[contains(@id,'popover')]/div[2]/table/tbody/tr[1]/td[1]";
        public string Shipmentlist_FirstRow_WeightLabel_Xpath = ".//*[contains(@id,'popover')]/div[2]/table/tbody/tr[2]/td[1]";
        public string Shipmentlist_FirstRow_ServiceTypeOCarrierLabel_Xpath = ".//*[contains(@id,'popover')]/div[2]/table/tbody/tr[3]/td[1]";
        public string Shipmentlist_FirstRow_ServiceLevelLabel_Xpath = ".//*[contains(@id,'popover')]/div[2]/table/tbody/tr[4]/td[1]";
        public string ShipmentGrid_AllValues_Xpath = ".//*[@id='ShipmentGrid']/tbody/tr/td";
        //Rate column objects for internal users
        public string Shipmentlist_FirstRow_Est_Revenue_Label_Xpath = "//*[@id='ShipmentGrid']/tbody/tr[1]/td[9]/span[1][@id='content']";
        public string Shipmentlist_FirstRow_Est_Revenue_Value_Xpath ="//*[@id='ShipmentGrid']/tbody/tr[1]/td[9]/span[2][@id='contenttable']";

        public string Shipmentlist_FirstRow_Est_Cost_Label_Xpath = "//*[@id='ShipmentGrid']/tbody/tr[1]/td[9]/span[3][@id='content']";
        public string Shipmentlist_FirstRow_Est_Cost_Value_Xpath = "//*[@id='ShipmentGrid']/tbody/tr[1]/td[9]/span[4][@id='contenttable']";

        public string Shipmentlist_FirstRow_Est_Margin_Label_Xpath = "//*[@id='ShipmentGrid']/tbody/tr[1]/td[9]/span[5][@id='content']";
        public string Shipmentlist_FirstRow_Est_Margin_Value_Xpath = "//*[@id='ShipmentGrid']/tbody/tr[1]/td[9]/span[6][@id='contenttable']";
        public string ShipmentList_CustomerDropdownValues_xpath = ".//*[@id='CustomerType_chosen']//ul/li";
        //------------------------------Custom Reports Section--------------------------------------------
        public string ShipmentModule_Xpath = ".//*[@id='shipment']/i";
        public string ShipmentIcon_Id = "shipment";
        public string ShipmentList_Header_Xpath = ".//h1[contains(text(), 'Shipment List')]";
        //public string ShipmentList_Report_dropdown_Xpath = ".//*[@id='reports_select_custom_chosen']/a/span";
        public string ShipmentList_SearchByFilteredReport_Text_Xpath = ".//span[contains(text(), 'Search by Filtered Reports')]";
        //public string ShipmentList_Report_dropdown_Xpath = ".//*[@id='reports_select_custom_chosen']/a";
        public string ShipmentList_Report_dropdown_Xpath = ".//*[@id='ReportType_chosen']/a";

        //public string ShipmentList_Report_dropdown_Values_Xpath = ".//*[@id='reports_select_custom_chosen']/div/ul/li";
        public string ShipmentList_Report_dropdown_Values_Xpath = ".//*[@id='ReportType_chosen']/div/ul/li";
        public string ShipmentList_ShowFilter_link_Id = "toggleFilters";
        public string ShipmentList_HideFilter_link_Id = "toggleFilters";
        public string FilterSection_LTL_ServiceType_Checkbox_Xpath = "(//div[@class='checkbox checkbox tms-csa-remove'])[1]";
        public string FilterSection_TL_ServiceType_Checkbox_Xpath = "(//div[@class='checkbox checkbox tms-csa-remove'])[2]";
        public string FilterSection_PTL_ServiceType_Checkbox_Xpath = "(//div[@class='checkbox checkbox tms-csa-remove'])[3]";
        public string FilterSection_IML_ServiceType_Checkbox_Xpath = "(//div[@class='checkbox checkbox tms-csa-remove'])[4]";
        public string FilterSection_DomForwarding_ServiceType_Checkbox_Xpath = "(//div[@class='checkbox checkbox tms-mg-remove'])[1]";
        public string FilterSection_Intl_ServiceType_Checkbox_Xpath = "(//div[@class='checkbox checkbox tms-mg-remove'])[2]";
        public string FilterSection_SchedulePickUp_Calendar_Xpath = ".//*[@id='SchedulePickupDates']";
        //public string FilterSection_DateRange_Lastweek_button_Xpath = ".//li[contains(text(), 'Last week')]";
        public string FilterSection_DateRange_Lastweek_button_Xpath = "html/body/div[8]/div[3]/ul/li[1]";
        public string FilterSection_DateRange_ThisMonth_button_Xpath = ".//li[contains(text(), 'This Month')]";
        public string FilterSection_DateRange_LastMonth_button_Xpath = ".//li[contains(text(), 'Last Month')]";
        public string FilterSection_DateRange_CustomRange_button_Xpath = ".//li[contains(text(), 'Custom Range')]";
        public string FilterSection_DateRange_Select_button_Xpath = "(//button[@class='applyBtn btn btn-sm btn-default'])";
        public string FilterSection_DateRange_Leftside_Calendar_Xpath = "(//div[@class='calendar left'])";
        public string FilterSection_DateRange_Rightside_Calendar_Xpath = "(//div[@class='calendar right'])";
        public string FilterSection_OriginCity_Textbox_Id = "originCity";
        public string FilterSection_DestCity_Textbox_Id = "destinationCity";


        //public string FilterSection_ClearAll_button_Xpath = ".//button[contains(text(), 'Clear All')]";
        public string FilterSection_ClearAll_button_Xpath = ".//a[contains(text(), 'Clear All')]";
        public string FilterSection_SelectAll_button_Xpath = ".//a[contains(text(), 'Select All')]";

        public string FilterSection_Status_dropdown_Xpath = ".//*[@id='status_select_chosen']/ul/li";
        public string FilterSection_Status_Searchbox_Xpath = ".//*[@id='status_select_chosen']/ul/li[2]/input";
        public string FilterSection_Status_List_Xpath = ".//*[@id='status_select_chosen']/div/ul/li";
        public string FilterSection_RefNumber_Textbox_Id = "ReferenceNumerFilter";
              
        public string ShipmentNotFound_PopUp_Xpath = ".//*[@id='error']/div/div/div/p";
        public string ShipmentNotFoud_PopUp_Close_button_Xpath = ".//*[@id='btn-error-Close']";
        public string FilterSection_DeleteReport_button_Id = "deleteFilterBtn";
        public string FilterSection_UpdateReport_button_Id = "updateFilterBtn";
        public string FilterSection_SaveReport_button_Id = "saveFilterBtn";

        public string SaveReport_ModalPopUp_Text_Xpath = ".//h2[contains(text(), 'Save Report')]";
        public string NameThisReport_Textbox_Id = "filtersetname";
        public string SaveReport_ModalPopUp_Cancel_button_Xpath = ".//*[@id='Save-Report']/div/div/div[3]/a[1]";
        public string SaveReport_ModalPopUp_Ok_button_Xpath = ".//a[contains(text(), 'Ok')]";
        public string FilterSection_ServiceType_Text_Xpath = ".//label[contains(text(), 'SERVICES TYPE')]";


        public string ShipmentList_Customer_dropdown_Xpath = ".//*[@id='CustomerType_chosen']/a/span";
        public string ShipmentList_Customer_dropdownValue_Xpath = ".//*[@id='CustomerType_chosen']/div/ul/li";
        public string ShipmentList_Customer_dropdown_Value_Xpath = ".//*[@id='CustomerType_chosen']//div//li";

        public string FilterSection_CustomReportText_Xpath = ".//*[@id='customer-selection-p']";

        public string FilterSection_PreviewReport_button_Id = "previewFilterResultBtn";

        //  public string FilterSection_ReportName_Text_Id = "NamethisReport";
        public string FilterSection_ReportName_Text_Id = "filtersetname";
        public string FilterSection_DeleteReport_Header_Xpath = ".//*[@id='delete-report']/div/div/div[1]/h2";
        public string FilterSection_DeleteReport_Cancel_Xpath = ".//*[@id='delete-report']/div/div/div[3]/a[1]";
        public string FilterSection_DeleteReport_Yes_Id = "delete-report-yes";

        public string ShipmentList_shareaccess_checkbox_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div[2]/div/div[1]/div/div/div[3]/div[1]/div[2]/div[2]/div[2]/div[1]/div/label";
        public string updatereport_button_Xpath = " .//*[@id='updateFilterBtn']";
        public string updatereportsection = ".//*[@id='page-content-wrapper']/div[2]/div[2]/div/div[1]/div/div/div[3]/div[1]";
        public string Sharedreportnamealreadyexists_error = ".//*[@id='update-error-report-modal']/div/div/div[2]/h6";
        public string Sharedreportnamealreadyexists_error_modal = ".//*[@id='update-error-report-modal']/div/div";
        public string ShipmentList_Reporteditwillbeforall_Xpath = ".//*[@id='customer-selection-p']";

        // public string NameThisReport_Textbox_Id = "";
        public string SaveReport_ModalPopUp_Ok_button_Id = "confirm-Report-Ok";
        public string AllshipmentsTextInShipmentList_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div[1]/div[1]/div[3]/p";

        public string SelectAReportSearchBoxnShipmentList_Xpath = "//*[@id='ReportType_chosen']/div/div/input";
        public string SaveReport_ModalPopUp_warning_message_Id = "warning-missing-info-filter";

        //===================================External Users=================

        public string FilterSection_StausColumn_Xpath = "//*[@id='ShipmentGrid']/tbody/tr/td[3]/div/span";
        public string FilterSection_PicupDateColumn_Xpath = "//*[@id='ShipmentGrid']/tbody/tr/td[4]/span[1]";
        public string FilterSection_DropOffDateColumn_Xpath = "//*[@id='ShipmentGrid']/tbody/tr/td[5]/span[1]";
        public string FilterSection_OriginAddColumn_Xpath = "//*[@id='ShipmentGrid']/tbody/tr/td[6]";
        public string FilterSection_DestAddAddColumn_Xpath = "//*[@id='ShipmentGrid']/tbody/tr/td[7]";


        public string FilterSection_LTL_ServiceType_Checkbox_XpathEU = "//*[@id='page-content-wrapper']/div[2]/div[2]/div/div[1]/div/div/div[3]/div[1]/div[2]/div[1]/div/div[1]/input";
        public string FilterSection_TL_ServiceType_Checkbox_XpathEU = "//*[@id='page-content-wrapper']/div[2]/div[2]/div/div[1]/div/div/div[3]/div[1]/div[2]/div[1]/div/div[2]/input";
        public string FilterSection_PTL_ServiceType_Checkbox_XpathEU = "//*[@id='page-content-wrapper']/div[2]/div[2]/div/div[1]/div/div/div[3]/div[1]/div[2]/div[1]/div/div[3]/input";
        public string FilterSection_IML_ServiceType_Checkbox_XpathEU = "//*[@id='page-content-wrapper']/div[2]/div[2]/div/div[1]/div/div/div[3]/div[1]/div[2]/div[1]/div/div[4]/input";
        public string FilterSection_DomForwarding_ServiceType_Checkbox_XpathEU = "//*[@id='page-content-wrapper']/div[2]/div[2]/div/div[1]/div/div/div[3]/div[1]/div[2]/div[1]/div/div[5]/input";
        public string FilterSection_Intl_ServiceType_Checkbox_XpathEU = "//*[@id='page-content-wrapper']/div[2]/div[2]/div/div[1]/div/div/div[3]/div[1]/div[2]/div[1]/div/div[6]/input";


        ////////////------------Page -Display----/////////////////////////

        //public string gridMessageDisplay = "/html/body/div[3]/div/div[2]/div[5]/div[2]/table/tbody/tr/td";
        public string AddShipmentButton_id = "add-shipment-btn";
        //  public string ShipmentMessage_xpath = "/html/body/div[3]/div/div[2]/div[1]/div[1]/div[3]/p";
        public string ShipmentMessage_xpath =".//*[@id='page-content-wrapper']/div[2]/div[1]/div[1]/div[3]/p";

        public string gridMessageDisplay = ".//*[@id='ShipmentGrid']/tbody/tr/td";
        public string ShipmentListGrid_InvoiceIcon_id = "invoiceicon";
        public string CustomerInvoiceIcon_Xpath = "";
        public string QuoteList_CustomerDropdownList_Xpath = ".//*[@id='CategoryType_chosen']/div/ul/li";

        public string ShipmentList_AllRowsGrid_Xpath = ".//*[@id='ShipmentGrid']//tr";
        public string ShipmentList_MoreIcon_Xpath = ".//*[@id='ShipmentGrid']//a[@class='btn btn-sm btn-icon image-only-sm']";
        public string ShipmentList_CopyShipIcon_Xpath = ".//*[@id='ShipmentGrid']//a[@class='btn btn-icon image-only-sm iconcopy']";
        public string ShipmentList_ReturnShipIcon_Xpath = ".//*[@id='ShipmentGrid']//a[@class='btn btn-icon image-only-sm returnshipment']";
        public string ShipmentListInternal_CustomerDropdown_Xpath = ".//*[@id='CustomerType_chosen']/a";
        public string ShipmentListInternal_CustDropdownVal_Xpath = ".//*[@id='CustomerType_chosen']/div/ul/li";
        public string ShipmentList_CustDropdownOption_Xpath = ".//*[@id='CustomerType_chosen']/div/ul/li[673]";
        //external user dropdown
        public string ShipmentList_CustomerDropdown_Xpath = "//div[@id='CustomerType_chosen']//a[@class='chosen-single chosen-default']//span[contains(text(),'Select')]";
        public string ShipmentList_CustomerDropdownValues_Xpath = ".//*[@id='CustomerType_chosen']/div/ul/li";
        public string ViewRateButton_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div[2]/div[8]/div/button";
        public string ShipmentList_EmptyGridontent_Xpath = ".//*[@id='page-content-wrapper']//p[@class='sub-title']";
        public string ShipmentListExternal_CustomerDropdown_Xpath = "//div[@id='CustomerType_chosen']//a[@class='chosen-single chosen-default']//span[contains(text(),'Select')]";
        

        public string ShipmentList_EmptyGrid_xpath = ".//*[@id='ShipmentGrid']/tbody/tr/td";


        public string CustomerDropdownExtuser_Xpath = ".//*[@id='CustomerType_chosen']/a/span";
        public string CustomerDropdownValesExtuser_Xpath = ".//*[@id='CustomerType_chosen']//li";
        public string FirstlevelSubAccountsDropdownValues_Xpath = ".//li[contains (@class,'level0')]";

        public string Customernameon_AddShipment_LTL_Xpath = ".//*[@class='customer-name']//p";
        //public string ShipmentList_FirstReference_no_Xpath = ".//*[@id='ShipmentGrid']//tr[1]/td[1]//*[@id='RefID']";  -- Not a proper xpath
        public string ShipmentList_FirstReference_no_Xpath = ".//*[@id='ShipmentGrid']//tr[1]/td[2]//*[@id='RefID']";
        public string ShipmentList_FirstReferenceNumber_Selector = "#RefID";
        public string QuoteGridAllOption_Xpath = ".//*[@id='QuotesGrid_length']/label/select/option";
        public string ShipmentList_CustomerOrStationDropdown_Xpath = "//div[@id='CustomerType_chosen']//a[@class='chosen-single chosen-default']";
        public string Shipment_CustomerOrStationDropdown_Selected_Xpath = "//div[@id='CustomerType_chosen']//a[@class='chosen-single']//span";
        public string QuoteIcon_Xpath = "//I[@class='icon icon-quote']";
        public string CustomerOrStationVerbiage_Xpath = "//P[@class='Header-Sub-title'][text()='All shipments for the past 30 days are shown.']";
        public string QuoteCustomerOrStationDropdown_Xpath = ".//*[@id='CategoryType_chosen']/a";
        public string QuoteCustomerOrStationDropdownVal_Xpath = ".//*[@id='CategoryType_chosen']//li";
        public string QuoteGridRefVlaues_Xpath = ".//*[@id='QuotesGrid']/tbody/tr/td[4]/span";
        public string ShipmentResult_CustomerLabel_Xpath = "//p[@id='station-customer-name-external']";
        public string ShipmentResult_CreateShipmentButton_Xpath = ".//*[@id='createShipment']";
        public string InsuredValue_Id= "Insvalue";
        public string ReviewSubmitPage_customerLabel_Xpath = ".//*[@id='station-customer-name']";
        public string SubmitShipmentButton_Id = "SubmitShipment";
        public string ShipmentConfirmation_CustomerLabel_Xpath = ".//*[@id='station-customer-name']";
        public string ShipmentListOption_Xpath = ".//*[@id='CustomerType_chosen']/div/ul/li[8]";
        public string ShipmentServicetype_AddShipmentButton_Xpath = ".//*[@id='add-shipment-btn']";
        public string ShipmentServicetype_EXT_AddShipmentButton_Xpath = ".//*[@id='add-shipment-btn']";
        public string ShipmentServicetype_INT_AddShipmentButton_Xpath = "//button[@id='shipment-list']";

        //public string CreateShipmetWithoutCarrier_Xpath = ".//*[@id='gridLTLresult']/button";
        public string CreateShipmetWithoutCarrier_Xpath = "//*[@id='createShipment']";


       // public string CreateShipmetWithoutCarrier_Xpath = ".//*[@id='gridLTLresult']/button";
        public string ShipmentResult_customerLabel_ExternalUser_Xpath = ".//*[@id='station-customer-name-external']";
        public string ShipmentListRefLookUpArrow_Xpath = ".//*[@id='page-content-wrapper']//button[@class='btnReference colored btn btn-default btn-input-addon']";
        public string LoadingIcon_Xpath = ".//*[@id='page-content-wrapper']//span[@class = 'style-spin fa fa-spinner fa-spin fa-3x fa-fw']";
        public string AddshipmentCreditHoldMessage_Xpath = "//p[contains(text(),'The selected customer is on Credit Hold.')]";
        public string CreditHoldpopup_Xpath = "//h2[contains(text(),'Credit Hold')]";

        public string ShipmentDetails_EstCostValue_Selector = "#Carrierdetails > div.row.CostDetail > div:nth-child(2) > div.EstAmount";
        public string ShipmentDetails_EstMarginValue_Selector = "#Carrierdetails > div.row.CostDetail > div:nth-child(3) > div.Estmargin";
        public string ShpList_CustomerDrpdown_Search_Xpath = "//*[@id='CustomerType_chosen']//input";
        public string ShpList_CustomerDrpdown_SearchedValue_Xpath = "//*[@id='CustomerType_chosen']//ul/li[2]";        
    }
}
