namespace CRMTest.Common.PageObjects
{
    public class Quotelist : ObjectRepository
    {
        public string GetQuote_LTLTile_Button_Xpath = "//*[@id='btn_ltl']";
        public string GetQuote_LTL_Title_Xpath = "//h1[@class='page-heading quote-header']";
        public string GetQuote_OriginClearAddress_XPath = "//*[@id='clearAddressRateOrgin']";
        public string GetQuote_OriginCityInput_Id = "txtOrginCity";
        public string GetQuote_OriginStateDropDown_XPath = "//*[@id='state_origin_select_chosen']";

        public string GetQuote_OriginStateValues_Xpath = "//*[@id='state_origin_select_chosen']/div/ul";

        public string GetQuote_OriginStateDropdown_Values_XPath = "//*[@id='state_origin_select_chosen']/div/ul/li";
        public string GetQuote_DestinationClearAddress_XPath = "//*[@id='clearAddressRateDestination']";
        public string GetQuote_DestinationZip_Id = "destination-zip";
        public string GetQuote_DestinationCityInput_Id = "txtDestCity";
        public string GetQuote_DestinationStateDropDown_XPath = "//*[@id='state_destination_select_chosen']";
        public string GetQuote_DestinationStateDropdown_Values_XPath = "//*[@id='state_destination_select_chosen']/div/ul/li";
        public string GetQuote_AdditionalItems_XPath = "//*[@class='additional-item-container']";
        public string GetQuote_PickupDate_Button_Id = "PickupDate";
        public string GetQuote_QuantityInput_Id = "quantity-0";
        public string GetQuote_AddAdditionalItem_Button_XPath = "//*[@id='page-content-wrapper']/div[2]/div[1]/div[3]/div[7]/div/button";
        public string GetQuote_ServiceAccessorialDrodown_Xpath = ".//*[@id='servicesaccessorialsfrom_chosen']/ul/li/input";
        public string GetQuote_ServiceAccessorialDrodownValues_Xpath = ".//*[@id='servicesaccessorialsfrom_chosen']/div/ul";
        public string GetQuote_ServiceAccessorial_FromShipmentDrodownValues_Xpath = ".//*[@id='servicesaccessorialsto_chosen']/ul/li/input";

        public string MobileNavigationButton_Selector = "#iconSidebarNav > a > div > i";
        public string QuoteClassification_xpath = "//*[@id='scrollable-dropdown-menu-Origin']/div/span[1]/span/div";
        public string QuoteResult_LTL_PickupDate_XPath = "//*[@id='page-content-wrapper']/div[2]/div[2]/div[1]/div[5]/div[1]/span[1]";
        public string QuoteResult_LTL_Origin_XPath = "//*[@id='page-content-wrapper']/div[2]/div[2]/div[1]/div[5]/div[2]/span[1]";
        public string QuoteResult_LTL_Destination_XPath = "//*[@id='page-content-wrapper']/div[2]/div[2]/div[1]/div[5]/div[3]/span[1]";
        public string QuoteResult_LTL_Pieces_XPath = "//*[@id='page-content-wrapper']/div[2]/div[2]/div[1]/div[5]/div[4]/span[1]";
        public string QuoteResult_LTL_ClassWeight_XPath = "//*[@id='page-content-wrapper']/div[2]/div[2]/div[1]/div[5]/div[5]/span[1]";
        public string QuoteResult_LTL_PickupDateResult_Id = "quote-criteria-pickup-date";        
        public string QuoteResult_LTL_OriginResult_Id = "quote-criteria-origin";
        public string QuoteResult_LTL_DestinationResult_Id = "quote-criteria-destination";
        public string QuoteResult_LTL_PiecesResult_Id = "quote-criteria-pieces";
        public string QuoteResult_LTL_ClassWeightResult_Id = "quote-criteria-class-weight";
        public string QuoteResult_LTL_MoreInformationIcon_XPath = "//*[@id='btn-information']/span";
        public string QuoteResult_LTL_SaveQuoteLink_Xpath = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[ul/li/a[contains(@class, 'save-rate-as-quote')]]/ul[2]/li/a";

        public string QuoteOriginCity_Selector = "#txtOrginCity";

        public string QuoteList_LoadingIcon_Xpath = ".//*[@id='page-content-wrapper']//span[@class = 'style-spin fa fa-spinner fa-spin fa-3x fa-fw']";
        public string QuoteList_Button_Xpath = "//*[@id='raterequest']";
        public string QuoteList_SubmitQuote_Button_Xpath = "//*[@id='rate-list']";
        public string QuoteList_PageTitle_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div[1]/div[1]/div[1]/h1";
        public string QuoteListPage_Subtitle_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div[1]/div[1]/div[1]/p";
        public string QuoteList_Export_Button_Id = "menu1";
        public string QuoteList_AllRadioButton_Id = "showAll";
        public string QuoteList_NewRadioButton_Id = "showNew";
        public string QuoteList_ExpiredButton_Id = "showExp";
        public string QuoteList_Past24Hours_Id = "showPast";
        public string QuoteList_SubtitleInternalUser_Xpath = ".//*[@class='Header-Sub-title']";
        public string QuoteList_CustomerDropdown_Label_Xpath = ".//*[@id='CategoryType_chosen']/a/span";
        public string QuoteList_CustomerDropdown_Xpath = ".//*[@id='CategoryType_chosen']/a";
        public string QuoteList_CustomerDropdownList_Xpath = ".//*[@id='CategoryType_chosen']/div/ul/li";
       // public string QuoteList_CustomerDropdownList_InternalUser_Xpath = "//DIV[@class='col-md-4 col-sm-12 col-xs-12 Customer-Dropdown-Container no-print']";
        public string QuoteList_CustomerDropdownList_InternalUser_Xpath = "//a[@class='chosen-single chosen-default']";
        public string QuoteList_CustomerDropdownValues_Xpath = ".//*[@id='CategoryType_chosen']/div/ul/li";
       // public string QuoteList_CustomerDropdownValues_Xpath = ".//*[@id='CategoryType_chosen']/div/ul/li";
        public string QuoteList_AllLabel_Xpath = ".//*[@id='QuotesGrid_wrapper']/div[1]/div[3]/label[1]/label";
        public string QuoteList_NewLabel_Xpath = ".//*[@id='QuotesGrid_wrapper']/div[1]/div[3]/label[2]/label";
        public string QuoteList_ExpiredLabel_Xpath = ".//*[@id='QuotesGrid_wrapper']/div[1]/div[3]/label[3]/label";
        public string QuoteList_Past24HoursLabel_Xpath = ".//*[@id='QuotesGrid_wrapper']/div[1]/div[3]/label[4]/label";
        public string QuoteList_FiltersLabel_Xpath = ".//*[@id='QuotesGrid_wrapper']/div[1]/div[3]/label/label";
        public string QuoteList_SearchBox_Xpath = ".//*[@id='searchbox']";
        public string QuoteList_SearchBox_DropdownArrow_Xpath = ".//*[@id='toggle-button']";
        public string QuoteList_SearchBox_AllDropdownValues_Xpath = ".//*[@id='dropdown-display']/form/div[1]/div/div/div/label";
        public string QuoteList_TopGrid_DisplayListView_Xpath = ".//*[@id='QuotesGrid_info']";
        public string QuoteList_TopGrid_expandquote_Xpath = ".//*[@id='QuotesGrid']/tbody/tr[1]//*[@class='btn exandableTrigger image-only-sm']";
        public string QuoteList_customerDropdownVerbiage_Xpath = "//p[@class='Header-Sub-title']";
        public string PreselectedCustomer_Xpath = "//html//div[@id='CategoryType_chosen']//span";
        public string QuoteList_CustomerDropdownNameDisplay_Xpath = "//a[@class='chosen-single chosen-default']";
        public string QuoteList_CustomerDropdownName_Xpath = "//a[@class='chosen-single']//span[1]";
        public string QuoteList_CustomerDropdownOptions_Xpath = ".//*[@id='CategoryType_chosen']/div/ul/li[670]";
        public string QuoteList_CustomerDropdownOptionValues_Xpath = ".//*[@id='CategoryType_chosen']/div/ul";
        public string QuoteList_CustomerDropdown_SearchBox_Xpath = ".//*[@id='CategoryType_chosen']/div/div/input";        

        public string Deshboard_QuoteText_xpath = ".//*[@id='raterequest']";
        public string QuoteList_HeaderText_xpath = ".//*[@id='page-content-wrapper']//h1";
        public string QuoteList_ClickCustomerDropdown_xpath = ".//*[@id='CategoryType_chosen']/a";
        public string GetQuote_LTL_StationCustomerName_Label_id = "StationCustomerLbl";
        public string QuoteList_Service_Option_Xpath = ".//*[@id='dropdown-display']/form/div[1]/div/div[2]/div[3]/label";
        public string QuoteList_Search_Box_Id = "searchbox";
        public string QuoteList_AllNoOfRecords_xpath = "//*[@id='QuotesGrid']/thead/tr/th";
        public string QuoteList_FirstQuote_StationCustomerName_xpath = ".//*[@id='QuotesGrid']/tbody/tr[1]/td[2]";
        public string QuoteListDashboardError_Xpath = ".//*[@id='error']/div/div/div/div[1]/h3";
        public string ErrorPopUpClose_Button_Xpath = ".//*[@id='btn-error-Close']";
        public string QuoteList_Search_ClearButton_Id = "clear-all-btn";
        public string QuoteList_Search_SelectAll_Checkbox_Xpath = ".//*[@id='dropdown-display']/form/div[1]/div/div[1]/div[1]/label";
        public string QuoteList_Search_DateSubmitted_Checkbox_Xpath = ".//*[@id='dropdown-display']/form/div[1]/div/div[1]/div[2]/label";
        public string Quote_List_Search_RequestedNumber_Checkbox_Xpath = ".//*[@id='dropdown-display']/form/div[1]/div/div[2]/div[2]/label";
        public string Quote_List_Search_Status_Checkbox_Xpath = ".//*[@id='dropdown-display']/form/div[1]/div/div[1]/div[5]/label";
        public string QuoteList_SearchDropdown_NoteSection_Id = "search-title";
        public string QuoteIconModule_Xpath = ".//*[@id='raterequest']/i";
        public string QuoteIconModule_Id = "raterequest";
        public string QuoteSubmitrateRequest_Button_Xpath = ".//*[@id='rate-list']";
        public string GetQuote_Ltlimage_id = "btn_ltl";
        public string GetQuote_LtlButton_Xpath = ".//*[@id='btn_ltl']";
        public string GetQuote_ViewQuoteResult_Button_Id = "view-quote-results";
        public string GetQuote_CustomerLabelExtUser_Xpath = "//p[@id='StationCustomerLbl-external']";
        public string GetQuote_CustomerLabelItlUser_Xpath = "//p[@id='StationCustomerLbl']";
        public string QuoteLTLPage_SavedItem3_xpath = ".//*[@id='Select-saveditem-2']";
        public string MgErrorErrorCheck_Xpath = "//H3[@class='error-header coloredModalHeader'][text()='Error']";
        public string MgErrorCloseButton_Xpath = "//div[@id='error']//div[@class='modal-footer']";

        public string SaveRateAsQuoteLink_Selector = "#Grid-Rate-List-Large-NonGuranteed > tbody > tr:nth-child(1) > td:nth-child(5) > ul:nth-child(4) > li > a";
        public string QuoteResult_SaveRateAsQuoteLinkMobile_Selector = "#rate-table > tbody > tr > td > table:nth-child(1) > tbody > tr:last-child > td > a";
        public string BacktoQuoteListButton_Selector = "#Btn_BackQuoteList";
        //---------------------------Quote List Table----------------------------------------------------
        public string Dashboard_pagetitle_xpath = ".//h1[contains(text(), 'Dashboard')]";
        public string QuoteList_TopGrid_DisplayListViewDropdown_Xpath = ".//*[@id='QuotesGrid_length']/label/select";
        public string QuoteList_TopGrid_DisplayListDropdownOptions_Xpath = ".//*[@id='QuotesGrid_length']/label/select/option";
        public string QuoteList_BottomGrid_DisplayListView_Xpath = ".//*[@id='QuotesGrid_wrapper']/div[2]/div/div[1]/div";
        public string QuoteList_BottomGrid_DisplayListViewDropdown_Xpath = ".//*[@id='QuotesGrid_wrapper']/div[2]/div/div[2]/div[1]/label/select";
        public string QuoteList_BottomGrid_DisplayListDropdownOptions_Xpath = ".//*[@id='QuotesGrid_wrapper']/div[2]/div/div[2]/div[1]/label/select/option";
        public string QuoteList_TopGrid_ViewNextIcon_Xpath = ".//*[@id='QuotesGrid_next']";
        public string QuoteList_TopGrid_ViewPreviousIcon_Xpath = ".//*[@id='QuotesGrid_previous']";
        public string QuoteList_BottomGrid_ViewNextIcon_Xpath = ".//*[@id='QuotesGrid_wrapper']/div[2]/div/div[2]/div[2]/ul/li[2]/a";
        public string QuoteList_BottomGrid_ViewPreviousIcon_Xpath = ".//*[@id='QuotesGrid_wrapper']/div[2]/div/div[2]/div[2]/ul/li[1]/a";
        public string QuoteList_GridHeaderValues_Xpath = ".//*[@id='QuotesGrid']/thead/tr/th";
        public string QuoteList_CompleteGridContent_Xpath = ".//*[@id='QuotesGrid']/thead/tr/th";
        public string QuoteList_FirstRowGridValues_Xpath = ".//*[@id='QuotesGrid']/tbody/tr[1]/td";
        public string QuoteList_SearchDropdownValue1_Xpath = ".//*[@id='dropdown-display']/form/div[1]/div/div[1]/div[5]/label";
        public string QuoteList_SearchDropdown_SelectAllCheckbox_Xpath = ".//*[@id='dropdown-display']/form/div[1]/div/div[1]/div[1]/label";
        public string QuoteList_Rates_QuoteLabel_Xpath = ".//*[@id='QuotesGrid']/tbody/tr[1]/td[8]/span[1]";
        public string QuoteList_Rates_EstCostLabel_Xpath = ".//*[@id='QuotesGrid']/tbody/tr[1]/td[8]/span[3]";
        public string QuoteList_Rates_EstMarginLabel_Xpath = ".//*[@id='QuotesGrid']/tbody/tr[1]/td[8]/span[5]";
        public string QuoteList_QuoteDetailsIcon_Xpath = ".//*[@id='QuotesGrid']/tbody/tr[1]/td[9]/button";
        public string QuoteList_NoOfRows_Xpath = ".//*[@id='QuotesGrid']/tbody/tr[@role = 'row']";
        public string QuoteList_FirstQuote_StationName_xpath = ".//*[@id='QuotesGrid']/tbody/tr[1]/td[2]/span[1]";
        public string QuoteList_FirstQuote_CustomerName_xpath = ".//*[@id='QuotesGrid']/tbody/tr[1]/td[2]/span[2]";
       
        public string QuoteDetails_PrintButton_id = "btn-Print-Quote";
        public string QuoteDetails_RequoteButton_id = "btn-quote";
        public string QuoteDetails_Expand_FirstRecord_Xpath = ".//*[@id='QuotesGrid']/tbody/tr[1]/td[9]/button";

        public string QuoteList_DateSubmittedColumnClick_Xpath = ".//*[@id='QuotesGrid']/thead/tr/th[1]";
        public string QuoteList_DateSubmittedAll_Values_Xpath = ".//*[@id='QuotesGrid']/tbody/tr[@role = 'row']/td[1]";
        public string QuoteList_StationOrCustomerNameClick_Xpath = ".//*[@id='QuotesGrid']/thead/tr/th[2]";
        public string QuoteList_StationOrCustomerNameAll_Values_Xpath = ".//*[@id='QuotesGrid']/tbody/tr/td[2]";
        public string QuoteList_RequestNumberClick_Xpath = ".//*[@id='QuotesGrid']/thead/tr/th[4]";
        public string QuoteList_RequestNumberAll_Values_Xpath = ".//*[@id='QuotesGrid']/tbody/tr/td[3]/span";
        public string QuoteList_RequestNumberAll_Values_New_Xpath = ".//*[@id='QuotesGrid']/tbody/tr/td[4]/span";
        public string QuoteList_RequestNumberInternal_Values_Xpath = ".//*[@id='QuotesGrid']/tbody/tr/td[4]/span";
        public string QuoteList_RequestNumberInternal_Values_New_Xpath = ".//*[@id='QuotesGrid']/tbody/tr/td[5]/span";
        public string QuoteList_StatusClick_Xpath = ".//*[@id='QuotesGrid']/thead/tr/th[5]";
        public string QuoteList_StatusAll_Values_Xpath = ".//*[@id='QuotesGrid']/tbody/tr/td[5]";
        public string QuoteList_ServiceClick_Xpath = ".//*[@id='QuotesGrid']/thead/tr/th[6]";
        public string QuoteList_ServiceAll_Values_Xpath = ".//*[@id='QuotesGrid']/tbody/tr/td[6]";
        public string QuoteList_CarrierNameClick_Xpath = ".//*[@id='QuotesGrid']/thead/tr/th[7]";
        public string QuoteList_CarrierNameAll_Values_Xpath = ".//*[@id='QuotesGrid']/tbody/tr/td[7]";
        public string QuoteList_RatesClick_Xpath = ".//*[@id='QuotesGrid']/thead/tr/th[8]";
        public string QuoteList_RatesAll_Values_Xpath = ".//*[@id='QuotesGrid']/tbody/tr/td[8]";


        public string QuoteList_NoResults_Xpath = ".//*[@id='QuotesGrid']/tbody/tr/td";
        public string QuotleList_DateSubmittedColumn_Highlighted_Xpath = ".//*[@id='QuotesGrid']/tbody/tr[@role = 'row']/td[1]/span/span";
        public string QuoteList_RequestedNumberColumn_Highlighted_Xpath = ".//*[@id='QuotesGrid']/tbody/tr/td[3]/span/span";
        public string QuoteList_StatusColumn_Highlighted_Xpath = ".//*[@id='QuotesGrid']/tbody/tr/td[4]/span/span";
        public string QuoteList_SearchboxClose_Xpath = ".//*[@id='input-search-box']/div/div/label/span";
        public string QuoteListGrid_Highlight_Class = "highlight";
        public string QuoteList_InfoIcon_Id = "btn-information";
        public string QuoteList_Info_Service_Label = ".//*[contains(@id,'popover')]";
        public string QuoteList_LTL_PickupDate_Id = "pickup-date";
        public string QuoteList_LTL_DropOffDate_Id = "dropoff-date";
        
        public string QuoteDetails_PrintButton_Id = "btn-Print";

        public string QuoteDetails_CreateShipmentButton_Id = "btn-CreateShipment";

        public string QuoteList_TotalRecords_Xpath = ".//*[@id='QuotesGrid']/tbody/tr";
        public string QuoteList_FirstRecord_QuoteNumber_xpath = "//*[@id='QuotesGrid']/tbody/tr[1]/td[contains(@class, 'RequestedNumber')]";
        public string QuoteList_Expand_FirstRecord_Xpath = ".//*[@id='QuotesGrid']/tbody/tr[1]/td[8]/button";
        public string QuoteList_Internal_Expand_FirstRecord_Xpath = ".//*[@id='QuotesGrid']/tbody/tr[1]/td[9]/button";

        public string QuoteList_ExportButton_xpath = ".//*[@id='menu1']";
        public string QuoteList_Export_AllOption_xpath = ".//*[@id='export-list']/li[1]/a";
        public string QuoteList_Export_DisplayedOption_xpath = ".//*[@id='export-list']/li[2]/a";

        public string QuoteList_Search_Dropdown_Id = "toggle-button";

        public string QuoteDetails_SubmittedBy_Xpath = ".//*[@id='QuotesGrid']/tbody/tr[2]/td/div/div/div[1]/div[2]/p";
        public string QuoteDetails_OriginLocation_xpath = ".//*[@id='quoteContentPrint']/div[1]/div[1]/div[1]/h6";
        public string QuoteDetails_DestinationLocation_xpath = ".//*[@id='quoteContentPrint']/div[1]/div[2]/div[1]/h6";
        public string QuoteDetails_Origin_AddressZip_label_xpath = ".//*[@id='originlocdetails']/div/span";
        public string QuoteDetails_Origin_AddressZip_Id = "origin-zip";
        public string QuoteDetails_Destination_AddressZip_label_xpath = ".//*[@id='destinationlocdetails']/div/span";
        public string QuoteDetails_Destination_AddressZip_Id = "destination-zip";
        public string QuoteDetails_Dates_xpath = ".//*[@id='quoteContentPrint']/div[1]/div[3]/div[1]/h6";
        public string QuoteDetails_PickUpDate_Label_xpath = ".//*[@id='datesdetails']/div[1]/span";
        public string QuoteDetails_DropOffDate_Label_xpath = ".//*[@id='datesdetails']/div[2]/span";
        public string QuoteDetails_FreightInfo_xpath = ".//*[@id='quoteContentPrint']/div[2]/div/div[1]/h6";
        public string QuoteDetails_FreightInfo_Quantity_xpath = ".//*[@id='tblFreight']/thead/tr/th[1]";
        public string QuoteDetails_FreightInfo_Package_xpath = ".//*[@id='tblFreight']/thead/tr/th[2]";
        public string QuoteDetails_FreightInfo_Weight_xpath = ".//*[@id='tblFreight']/thead/tr/th[3]";
        public string QuoteDetails_FreightInfo_Weightfield_id = "weight-0";
        public string QuoteDetails_FreightInfo_ItemDesc_xpath = ".//*[@id='tblFreight']/thead/tr/th[4]";
        public string QuoteDetails_FreightInfo_Classification_xpath = ".//*[@id='tblFreight']/thead/tr/th[5]";
        public string QuoteDetails_FreightInfo_NMFC_xpath = ".//*[@id='tblFreight']/thead/tr/th[6]";
        public string QuoteDetails_FreightInfo_HazardousMaterial_xpath = ".//*[@id='tblFreight']/thead/tr/th[7]";
        public string QuoteDetails_AdditionalServicesAndAccessorials_xpath = ".//*[@id='QuotesGrid']/tbody/tr[2]/td/div/div/div[2]/div[3]/div/div[1]/h6";
        public string QuoteListDetails_ExpandButton_Xpath = ".//*[@id='QuotesGrid']/tbody/tr[1]/td[9]/button";
        public string QuoteDetails_CreateShipButton_Id = "btn-CreateShipment";
        public string QuoteConfirmation_PopupLabel_Xpath = ".//*[@id='create-shipment-modal']/div/div/div/h2";
        public string QuoteDetails_CancelButton_Xpath = ".//*[@id='create-shipment-modal']/div/div/div/div/div[1]/a";
        public string QuoteDetails_PopUpYes_Button_Id = "confirm-shipment-yes";
        public string ShipLocationDatepage_Label_Xpath = ".//*[@id='main']/div/div/h3";
        public string QuoteList_RequestedNumber_FirstValue_Xpath = ".//*[@id='QuotesGrid']/tbody/tr[1]/td[3]";
        public string ShipConfirmation_Xpath = "";
        public string GetQuote_ShippingFrom_ServicesAccessorial_DropDown_xpath = "//div[@id='servicesaccessorialsfrom_chosen']//input[@placeholder='Click to add services & accessorials...']";
        public string GetQuote_ShippingFrom_ServicesAccessorial_DropDown_Value_xpath = "//*[@id='servicesaccessorialsfrom_chosen']/div/ul/li";
        public string GetQuote_ShippingTo_ServicesAccessorial_DropDown_xpath = "//div[@id='servicesaccessorialsto_chosen']//input[@placeholder='Click to add services & accessorials...']";
        public string GetQuote_ShippingTo_ServicesAccessorial_DropDown_Value_xpath = "//*[@id='servicesaccessorialsto_chosen']/div/ul/li";


        public string QuoteDetails_FreightInfo_Quantity_Value_xpath = ".//*[@id='tblFreight']/tbody/tr/td[1]";
        public string QuoteDetails_FreightInfo_Package_Value_xpath = ".//*[@id='tblFreight']/tbody/tr/td[2]";
        public string QuoteDetails_FreightInfo_Weight_value_xpath = ".//*[@id='tblFreight']/tbody/tr/td[3]";
        public string QuoteDetails_FreightInfo_ItemDesc_value_xpath = ".//*[@id='tblFreight']/tbody/tr/td[4]";
        public string QuoteDetails_FreightInfo_Classification_value_xpath = ".//*[@id='tblFreight']/tbody/tr/td[5]";
        public string QuoteDetails_FreightInfo_NMFC_value_xpath = ".//*[@id='tblFreight']/tbody/tr/td[6]";
        public string QuoteDetails_FreightInfo_HazardousMaterial_value_xpath = ".//*[@id='tblFreight']/tbody/tr/td[7]";
        public string QuoteDetails_AdditionalServicesAndAccessorials_value_xpath = ".//*[@id='additional-service-content']";
        public string QuoteDetails_AdditionlaServicesAndAccessorials_Header_Xpath = ".//*[@id='quoteContentPrint']//*[text()='ADDITIONAL SERVICES AND ACCESSORIALS']";

        public string QuoteList_Datatable_Content_xpath = ".//*[@id='QuotesGrid']/tbody/tr[@role = 'row']";
        public string SelectSavedItem_Id = "Select-saveditem-0";
        public string SelectSaveItemValue_xpath = ".//*[@id='scrollable-dropdown-menu-Origin']/div/span[1]/span/div/span/div[1]/p";
        public string SaveItemValueFromDropDown_xpath = ".//*[@id='Select_saveditem_0_chosen']//*[text()='50']";
        public string QuoteResults_GuaranteedCarrier_ESTCOSTColumns_Xpath = ".//*[@id='Grid-Rate-List-Large-Guranteed']/tbody/tr/td[4]/ul/li[1]";
        public string QuoteResults_GuaranteedCarrier_AssessorialColumns_Xpath = ".//*[@id='Grid-Rate-List-Large-Guranteed']/tbody/tr/td[4]/ul/li[4]";

        public string QuoteResults_CarrierLegalLiability_All_XPath = "//tr/td[1]/ul/div[1]/li/span";
        public string QuoteResults_CarrierMaxLiability_All_XPath = "//tr/td[1]/ul/div[2]/li/span";
        public string QuoteResults_CarrierLegalLiability_New_Values_All_XPath = "//tr/td[1]/ul/div[1]/li/div[1]";
        public string QuoteResults_CarrierLegalLiability_Used_Values_All_XPath = "//tr/td[1]/ul/div[1]/li/div[2]";
        public string QuoteResults_CarrierMaxLiability_New_Values_All_XPath = "//tr/td[1]/ul/div[2]/li/div[1]";
        public string QuoteResults_CarrierMaxLiability_Used_Values_All_XPath = "//tr/td[1]/ul/div[2]/li/div[2]";
        public string QuoteResults_Service_Values_All_XPath = "//tbody/tr/td[2]/div";
        public string QuoteResults_FC_Total_Xpath = "//tr/td[5]/ul[1]/li[1]";
        public string QuoteResults_FC_InsTotal_Xpath = "//tr/td[6]/ul[1]/li[1]";
        public string QuoteResults_ExternalUser_FC_InsTotal_Xpath = "//tr/td[5]/ul[1]/li[1]";
        public string QuoteResults_InternalFC_EstTotal_Xpath = "//tr/td[4]/ul/li[1]";
        public string QuoteResults_InsuredTermsAndConditionsTextId = "//a[contains(text(), 'terms and conditions')]"; //Updated xpath from "//div/div/div/div/p[2]/a"; to "//a[contains(text(), 'terms and conditions')]"
        public string QuoteResults_EstimateMargin_Xpath = "//tr/td/ul[2]/li/b";
        public string QuoteResults_FirstCarrierLegalLiability_XPath = "//tr/td[1]/ul[2]/div/li/span";
        public string QuoteResults_ShipmentValue_Id = "shipValueNumber";        
        public string QuoteResults_ShowInsuredRatesButton_Id = "showInsuredRate";
        public string QuoteGridRefVlaues_Xpath = ".//*[@id='QuotesGrid']/tbody/tr/td[4]/span";
        public string QuoteRestults_MobileEstMargin_Selector = "#rate-table > tbody > tr > td > table:nth-child(1) > tbody > tr:nth-child(6) > td > ul > li > b";
        public string EstimatedCostCSSSelector = "#rate-table > tbody > tr > td > table:nth-child(1) > tbody > tr:nth-child(5) > td > b";

        //------------Quote List External User --------------
        public string CustomerDropdownExtuser_Xpath = ".//*[@id='ExtUserCustomerType_chosen']/a/span";        
        public string CustomerDropdownOptionExtUser_Xpath = ".//*[@id='ExtUserCustomerType_chosen']/div/ul/li[8]";
        public string CustomerDropdownValesExtuser_Xpath = ".//*[@id='ExtUserCustomerType_chosen']//li";
        public string QuoteListPageSelectAll = ".//*[@id='showAll']";
        public string FirstlevelSubAccountsDropdownValues_Xpath = ".//li[contains (@class,'level1')]";
        public string PrimaryCustomerAccountsDropdownValues_Xpath = ".//li[contains (@class,'level0')]";
        public string QuoteLTLPage_Length_Id = "length-0";
        public string QuoteLTLPage_Width_Id = "width-0";
        public string QuoteLTLPage_Height_Id = "height-0";
        public string QuoteLTLPage_Length_Id_Additional = "length-1";
        public string QuoteLTLPage_Width_Id_Additional = "width-1";
        public string QuoteLTLPage_Height_Id_Additional = "height-1";
        public string QuoteLTLPage_Length_Id_Second_Additional = "length-2";
        public string QuoteLTLPage_Width_Id_Second_Additional = "width-2";
        public string QuoteLTLPage_Height_Id_Second_Additional = "height-2";
        public string QuoteLTLPage_SavedItem_Xpath = ".//*[@id='Select-saveditem-0']";
        public string QuoteLTLPage_DimensionType_Xpath = "//div[@id='dimensionunit_0_chosen']//a[@class='chosen-single']";
        public string QuoteLTLPage_DimDropDown_Xpath = "//li[@class='active-result']";
        public string QuoteResultNoRatesUpdateLink_Xpath = "//A[@class='updateShippingInfolink'][text()='update your shipping information']";
        public string QuoteLTLOriginZip_Xpath = "//INPUT[@id='origin-zip']";
        public string QuoteLTLDestinationZip_Xpath = "//INPUT[@id='destination-zip']";
        public string QuoteDetailsDimValues_Xpath = ".//*[@id='tblFreight']//tr[1]/td[@class = 'rateList-dimension']";
        public string QuoteExpandIcon_Xpath = "(//I[@class='icon-plus'])[1]";
        public string QuoteListDropdownXpath = "/html/body/div/div/div/div/div/div/div/div/div/div/ul/li";
        public string QuoteListRequoteCustomerName = "//tbody//tr[1]//td[2]//span[2]";
        public string ReQuoteButtonExpand = "//tbody//tr[1]//td//button[1]";
        public string ReQuoteButtonId = "//button[@id='btn-quote']";
        public string StationCustomerName = "//p[@id='station-customer-name-external']";
        public string StationCustomerNameLabel = "//p[@id='StationCustomerLbl']";
        public string QuoteResultCustomerNameLabel_Xpath = ".//*[@id='StationCustomerLbl-external']";
        public string QuoteResult_NoRecordSaveQuote_Xpath = ".//*[@id='no-results-save-quote']";
        public string QuoteConfirmation_CustomerLabelExtrUser_Xpath = "//p[@id='StationCustomerLbl-external']";
        public string QuoteConfirmation_CustomerLabelItlUser_Xpath = "//p[@id='StationCustomerLblForDropdown']";
        public string QuoteConfirmation_CustomerLabelUser_Xpath = "//p[@id='StationCustomerLblForDropdown-external']";
        //public string QuoteResult_saveQuote_Xpath = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[3]/ul[1]/li/a";
        public string QuoteResult_saveQuote_Xpath = "//div[@id='Grid-Rate-List-Large-NonGuranteed_wrapper']//tbody//tr[1]//td[4]//ul[2]//li[1]//a[1]";
        public string QuoteResult_saveQuoteItl_Xpath = "//div[@id='Grid-Rate-List-Large-NonGuranteed_wrapper']//tbody//tr[1]//td[5]//ul[3]//li[1]//a[1]";
        public string StationCustomerNameLabelConfirmationPage = "//p[@id='StationCustomerLblForDropdown']";
        public string QuoteClassification_Selector = "#Select-saveditem-0";
        //-------------------Quote Confirmation ---------------------------

        public string QuoteConfirmation_BackToQuoteListButton_Xpath = ".//*[@id='Btn_BackQuoteList']";
        public string GetQuoteInsuredVal_Xpath = "//input[@id='shipValueNumber']";
        public string GetQuoteInsuredValError_Xpath = "//div[@id='shipment-value-warning']//h4";
        public string GetQuoteInsuredValErrorMessage_Xpath = ".//*[@id='shipment-value-warning']/p";
        public string GetQuoteInsuredValWarning_Xpath = "//div[@id='shipment-value-warning']";
        public string GetQuoteInsuredValErrorMesssage_Remove_Xpath = "//div[@id='shipment-value-warning']//i[@class='icon-close right']";
        public string QuoteResult_Title_Xpath = "//H1[text()='Quote Results (LTL)']";
        public string QuoteResult_InsuredVal_Xpath = "//input[@id='shipValueNumber']";
        public string QuoteResult_InsuredValErrorMessage_Xpath = "//p[@class='shipmentValu-popup-lbl error-msg']";
        public string QuoteResultShowInsuredRateButton_Xpath = "//button[@id='showInsuredRate']";
        public string QuoteResultCreateShipment_Button_Xpath = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[5]/button";
        public string InsuredValueModal_Xpath = "//INPUT[@id='shipValueNumber-popup-txt']";
        public string QuoteResultsModalShowInsuredButton_Xpath = "//BUTTON[@id='showInsuredRate-popup-btn']";
        public string InsuredValModal_ErrorMessage_Xpath = "//BUTTON[@id='showInsuredRate-popup-btn']"; 
        public string InsuredValueModalWithoutInsured_Button_Xpath = "//BUTTON[@id='create-shipment-btn']";
        public string QuoteOriginZip = ".//*[@id='origin-zip']";
        public string QuoteDestinationZip = ".//*[@id='destination-zip']";
        public string QuoteWeight_Xpath = ".//*[@id='weight-0']";
        public string PickupDate_Xpath = ".//*[@id='PickupDate']";
        public string PickupDate_Id = "PickupDate";

        public string QuoteConfirmation_RequestNumber_Xpath = ".//*[@id='referenceNumber-value']";
        public string InsuredRateLoadingIcon_Xpath = "//div[@id='dv-loader']/img";

        public string CreditHoldMessage_SubmitRateButton_Xpath = ".//*[@id='showCreditHoldErrorModel']//div[2]//p";
        public string QuoteGridServiceColumnVal_Xpath = ".//*[@id='QuotesGrid']//tr/td[6]";
        public string QuoteList_CustomerDrpdown_Search_Xpath = "//*[@id='CategoryType_chosen']//input";
        public string QuoteList_CustomerDrpdown_SearchedValue_Xpath = "//*[@id='CategoryType_chosen']//ul/li[2]";

        public string GetQuote_ClearItem_Button_Id = "frieghtclearbtn_rates";
        public string GetQuote_ClearItem_Button_Id_Additional = "frieghtclearbtn_rates-1";

        public string GetQuote_FirstTerminalLink_Xpath = "//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[3]/td[3]/a";
        public string GetQuote_TerminalModal_heading_Xpath = "//h3[contains(text(),'Terminal Information for')]";
        public string GetQuote_TerminalModal_CloseButton_Xpath = "(//a[contains(text(),'Close')])[3]";

    }
}
