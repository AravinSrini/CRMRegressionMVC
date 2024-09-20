using System;
using System.Configuration;
using Rrd.SpecflowSelenium.Service.GenericService;

namespace CRM.UITest.Objects
{
    public class ObjectRepository : GenericMethods
    {
        public ObjectRepository()
        {
            launchBrowser = ConfigurationManager.AppSettings["Browser"].ToString();
            launchUrl = ConfigurationManager.AppSettings["BaseUrl"].ToString();
            projectName = ConfigurationManager.AppSettings["ProjectName"].ToString();
        }

        public string IdentityServerBaseUrl = ConfigurationManager.AppSettings["IdentityServerBaseUrl"].ToString();
        public string IdentityAPIClientId = ConfigurationManager.AppSettings["IdentityAPIClientId"].ToString();
        public string IdentityAPIClientSecret = ConfigurationManager.AppSettings["IdentityAPIClientSecret"].ToString();

        //------------------Dashboard-------------------------------

        public string DashBoardCSRCount_Xpath = ".//*[@id='pie-number']/span[1]";
        public string DashBoardCSRPeichart_pendingCSR_Id = "pending_regional_manager_approval";
        public string DashBoardCSrPeichart_inProgress_Id = "in_progress";
        public string DashBoardCSrPeichart_denied_Id = "denied";

        //====================Webdriver Default Attributes =======================

        public String attributeName_classname = "ClassName";
        public String attributeName_cssselector = "CssSelector";
        public String attributeName_id = "Id";
        public String attributeName_linktext = "LinkText";
        public String attributeName_name = "Name";
        public String attributeName_partiallinktext = "PartialLinkText";
        public String attributeName_tagname = "TagName";
        public String attributeName_xpath = "XPath";

        //======================= CRM Variables =======================================

        //-------------- IDP Login-----------------------------

        public string LoadingSymbol_id = "dvLoading";
        public string HomepageText_Xpath = ".//h5[contains(text(), 'Track Up To 10 Shipments by Reference Number')]";
        public string SignIn_Id = "btn_signin";
        public string IDPLoginText_Xpath = ".//h1[contains(text(), 'RR Donnelley Logistics')]";
        public string IDP_Username_Id = "username";
        public string IDP_Password_Id = "password";
        public string IDP_Login_Xpath = ".//button[contains(text(), 'SIGN IN')]";
        public string StnOwnerDashboard_UI_Xpath = ".//h1[contains(text(), 'Account Metrics')]";
        public string DlsParter_Link_Xpath = ".//*[@id='login-page']/div/div/div[1]/div/p[3]/a";


        //---------------------Dashboard Page-------------------------

        public string Quote_LTLRadioButton_Id = "rate-1";
        public string GetQuoteButton_Xpath = ".//*[@id='getRate']";
        public string QuoteIconClick_Id = "raterequest";
        public string RateRequestButtondsh_Id = "";


        public string NewRRDLogo_Xpath = ".//*[@id='header']/div/div/div[1]/a/img";
        public string userProfileDropdown_Xpath = ".//*[@id='dv-loginmenu']/ul/li/a/i";
        public string userProfileDropDownListValues_Xpath = ".//*[@id='dv-loginmenu']/ul/li/ul";
        public string userFullName_Id = "spn-username";
        public string UserDropDownLists_xpath = ".//*[@id='dv-loginmenu']/ul/li/ul/li";

        public string DashboardIcon_css = "i.icon.icon-dashboard";
        public string paymentsicon_id = "payment";
        public string errorforpayments_xpath = "html/body";
        public string DashboardText_css = "#dashboard > span";
        public string DashboardpageTitle_css = "h1";
        public string QuotesIcon_css = "i.icon.icon-quote";
        public string ShipmentsIcon_css = "i.icon.icon-shipments";
        public string ShipmentspageTitle_css = "h1";
        public string TrackingIcon_css = "i.icon.icon-tracking";
        public string TrackingpageTitle_css = "h1";
        public string TrackingpageTitleDescription_css = "div.page-title > p";
        public string UsermanagementIcon_css = "i.icon.icon-csr";
        public string UserManagementpageTitle_css = "h1";
        public string DocumentRepositoryIcon_xpath = "//a[@id='docRepo']/i";
        public string DocumentRepositorypageTitle_css = "h1";
        public string ReportsIcon_css = "i.icon.icon-reports";
        public string ReportspageTitle_css = "h1";
        public string TrainingIcon_css = "i.icon.icon-book";
        public string TrainingpageTitle_css = "h1";
        public string MaintenanceToolIcon_css = "i.icon.icon-configure";
        public string MaintenanceToolsgpageTitle_css = "h1";
        public string RatingtoolsIcon_css = "i.icon.icon-RatingTool";
        public string RatingToolspageTitle_css = "h1";
        public string CommissionsIcon_xpath = "//a[@id='commissions']/i";
        public string CommissionspageTitle_css = "h1";

        public string POManagementOption_xpath = ".//*[@id='dv-loginmenu']/ul/li/ul/li[3]/a";
        public string POManagementOption_Id = "po-management";
        public string TermsOfUseOption_xpath = ".//*[@id='dv-loginmenu']/ul/li/ul/li[4]/a";
        public string SignoutOption_xpath = ".//*[@id='dv-loginmenu']/ul/li/ul/li[5]/a";
        public string TermsofUseText_xpath = ".//*[@id='terms-conditions']/div/div/div/div[1]/h3";
        public string DownloadPDFLink_Id = "terms-download";
        public string TermsofUseCloseButton_Id = "terms-read-close";

        public string NewDashboard_Header_Text_Xpath = ".//h1[contains(text(), 'Dashboard')]";
        public string PendingCSR_Header_Xpath = "//div[@id='accordion']/div/div[1]/h4";
        public string Chart_PendingRMApproval_Id = "pending_regional_manager_approval";
        public string Chart_InProgress_Id = "in_progress";
        public string Chart_WaitingToProcess_Xpath = ".//*[@id='waiting_to_process']";
        public string Chart_PendingSysConfig_Id = "pending_system_configuration";
        public string Chart_PendingPriConfig_Id = "pending_pricing_configuration";
        public string Chart_Denied_Id = "denied";
        public string Chart_TotalCount_Xpath = "//div[@id='pie-number']/span[1]";
        public string Chart_NoCsr_Id = "no_csr";


        public string Dashboard_SelectACSR_Text_Xpath = ".//*[@id='select_a_csr_chosen']/a";
        public string Dashboard_CSR_DropDown_list_Xpath = ".//*[@id='select_a_csr_chosen']/div/ul/li";
        public string Dashboard_Pending_CSR_EXport_Button_Id = "export-csr-btn";

        public string DashboardExpandIcon_Xpath = ".//*[@id='accordion']/div/div[1]/div/div";
        public string Dashboard_ViewAccountMetrics_button_Xpath = ".//a[contains(text(), 'View Account Metrics')]";
        public string Dashboard_CreateCSR_button_Id = "create-csr-btn";
        public string Dashboard_GoToACSR_Text_xpath = ".//*[@id='gotocsr_lbl']";
        public string Dashboard_CSR_DropDown_list_Second_Xpath = ".//*[@id='select_a_csr_chosen']/div/ul/li[2]";
        public string Dashboard_PieChart_TotalCount_Xpath = ".//*[@id='pie-number']/span[1]";
        public string SubmitCSR_AccountInformationPage_Text_Xpath = ".//h3[contains(text(), 'Account Information')]";
        public string CSRDetailsPage_CSRName_Text_Xpath = ".//*[@id='h-customer-name']";
        public string AccountMetricsPage_Text_Xpath = "html/body/div[4]/section/div[4]/div[1]/div/div/h1";
        public string DashboardDropdown_Xpath = ".//*[@id='select_a_csr_chosen']/a";
        public string expandicon_Xpath = ".//*[@id='accordion']/div/div[1]/div/div";
        public string CSRDetailsPageHeader_Text_Xpath = ".//h1[contains(text(), 'CSR Details')]";
        public string Dashboard_CSR_DropDownSearchTextbox_Xpath = ".//*[@id='select_a_csr_chosen']/div/div/input";

        public string Dashboard_ShipmentNotFoundError_Xpath = ".//*[@id='error']/div/div/div/div[1]/h3";
        public string TMS_Launch_Icon_css = "i.icon.tms-icon";
        public string TMS_Launch_MercuryGate_Option_xpath = ".//*[@id='tmslaunch']/span/a[1]";
        public string TMS_Launch_WorldTrak_Option_xpath = ".//*[@id='tmslaunch']/span/a[2]";
        public string TMS_Launch_CarrierWebsite_Option_xpath = ".//*[@id='tmslaunch']/span/a[3]";
        public string Dashboard_ReferenceNumberLookup_Id = "txtReference2";
        public string Dashboard_Referencesubmit_Id = "btnRefSubmit";
        public string ShipmentNotFound_PopUp_Close_button_Xpath = ".//*[@id='btn-error-Close']";

        public string Dashboard_LTLServiceType_Id = "shipment-1";
        public string Dashboard_CreateShipmentButton_Id = "createShipment";
        


        //---------------------LHS Navigation Modules---------------
        //---------------------Menu Icons---------------------------

        public string QuoteList_Search_Xpath = ".//*[@id='input-search-box']//input";
        public string QuoteModule_Xpath = ".//*[@id='raterequest']/i";
        public string DashboardIcon_Id = "";
        public string QuoteIcon_Id = "raterequest";
        public string ShipmentIcon_Id = "shipment";
        public string DashboardModule_Xpath = ".//*[@id='dashboard']/i";
        public string DashboardText_Xpath = ".//h1[contains(text(), 'Dashboard')]";
        public string MenuExpandIcon_Mobile_Xpath = "//div[@id='iconSidebarNav']/a/div/i";

        //---------------------QuoteList Page---------------------------

        public string SubmitRateRequestButton_Id = "rate-list";
        public string ExpiredRadioButton_Xpath = "//div[@id='filter-by']/ul/li[4]/label";
        public string QuoteList_SearchDropdown_Id = "search-dropdown-btn";
        public string QuoteList_ClearAll_Id = "clear-all-btn";
        public string QuoteList_ServiceOption_Id = "//ul[@id='search-dropdown-options']/li[4]/label";
        public string QuoteList_SearchBox_Id = "search-input-fltdate";
        public string QuoteList_NoofRecords_Xpath = "//div[@id='quoteListTable']/table/tbody/tr/td";
        public string QuoteList_FirstQuoteRecord_Xpath = "//div[@id='quoteListTable']/table/tbody/tr[1]/td[2]/p";
        public string QuoteList_FirstRecord_ReQuote_Xpath = "//div[@id='quoteListTable']/table/tbody/tr[2]/td/div/div[1]/a[2]";
        public string QuoteList_FirstRecord_ExpandQuote_Xpath = "//div[@id='quoteListTable']/table/tbody/tr[1]/td[6]/div/div/div/a/span";
        public string QuoteList_Icon_Xpath = ".//*[@id='raterequest']/i";
        public string QuoteList_PageTitle_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div[1]/div[1]/div[1]/h1";
        public string QuoteExpandIcon_Xpath = "(//i[@class='icon-plus'])[1]";

        //---------------------Shipment Service Screen---------------------------
        public string ShipmentServiceScreenTitle_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div[1]/div/div[1]/h1";
        public string GetQuote_Text_Xpath = ".//h1[contains(text(), 'Get Quote')]";
        public string GetQuote_Ltlimage_id = "btn_ltl";
        public string LTL_Tile_Xpath = "";
        public string LTL_TileLabel_Id = "btn_ltl";
        public string TL_TileLabel_Id = "btn_truckload";
        public string TL_TileLabel_xpath = ".//*[@id='btn_truckload']/img";
        public string Partial_TL_TileLabel_Id = "btn_partial_truckload";
        public string Intermodal_TileLabel_Id = "btn_intermodel";
        public string International_TileLabel_Id = "btn_international";
        public string DomesticForwarding_TitleLabel_Id = "btn_domestic_forwarding";
        public string International_TypeDropdown_Xpath = ".//*[@id='rate_international_type_chosen']/a";
        public string International_TypeDropdownValues_Xpath = ".//*[@id='rate_international_type_chosen']/div/ul/li";
        public string International_LevelDropdown_Xpath = ".//*[@id='rate_international_level_chosen']/a";
        public string International_LevelDropdownValues_Xpath = ".//*[@id='rate_international_level_chosen']/div/ul/li";
        public string International_ContinueButton_Id = "btn_submit_rateInternational";
        public string DomForwarding_TypeDropdown_Xpath = ".//*[@id='rate_domestic_forward_type_chosen']/a";
        public string DomForwarding_TypeDropdownValues_Xpath = ".//*[@id='rate_domestic_forward_type_chosen']/div/ul/li";
        public string DomForwarding_ContinueButton_Id = "btn_submit_rateDomesticForwarding";
        public string ShipmentServiceScreenTitle_Id = "";
        //public string DomForwarding_CloseBtn_xpath = ".//*[@id='rateDomesticForwardingContent']/div/div/div/div[3]/a[1]"; ---> Incorrect xpath
        public string DomForwarding_CloseBtn_xpath = ".//*[@id='rateDomesticForwardingContent']//a[contains(text(),'Close')]";
        public string value_SelectedFromDropDown = ".//*[@id='rate_domestic_forward_type_chosen']/a/span";
        //public string DomForwardingErrorMsg_xpath = ".//*[@id='rateDomesticForwardingContent']/div/div/div/div[3]/div"; ---> Incorrect xpath
        public string DomForwardingErrorMsg_xpath = ".//*[@id='rateDomesticForwardingContent']//div[contains(text(),'Please Enter All Required Information')]";
        public string DomFor_ShipmentInfoSectionHeader_xpath = ".//*[@id='main']/div/div/h3";
        public string DomFor_ShipmentInforServiceLevel_xpath = ".//*[@id='main']/div/div/div[1]/h6/span[2]";
        public string ShipmentListGrid_RefNumAllValues_Xpath = ".//*[@id='RefID']";
        public string ShipmentList_TopGrid_ViewDropdown_Xpath = ".//*[@id='ShipmentGrid_length']/label";
        public string ShipmentList_TopGrid_ViewDropdownValues_Xpath = ".//*[@id='ShipmentGrid_length']/label/select/option";
        public string ShipmentListGrid_RefValues_Xpath = ".//*[@id='ShipmentGrid']/tbody/tr/td[2]";
        public string LTLAddShipment_SelectedAccessorial_ShippingFrom_Xpath = ".//*[@id='shippingfromaccessorial_chosen']/ul/li[1]";
        public string CopyAddShipmentTitle_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div[1]/div[1]/div/div/div[1]/h1";

        //---------------------LTL Shipping information Page ---------------------------
        public string LTL_shipmentinformationpageheader_Xpath = "//h1[contains(text(),'Get Quote (LTL)')]";
        public string GetQuote_Header_Id = "";
        public string GetQuoteLTLText_Xpath = ".//h1[contains(text(), 'Get Quote (LTL)')]";
        public string BackToQuoteButton_Id = "Btn_BackQuoteList";
        public string BacktoQuoteListBtn_id = "Btn_BackQuoteList";
        public string LTL_GetQuotePage_CustomerUsersCustomerAccountBinding_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[1]/div[2]/div[@class='customer-name']";
        public string ShipmentModule_Xpath = ".//*[@id='shipment']/i";
        //public string LTL_ShipinformationPage_OriginText_Xpath = ".//*[@id='scrollable-dropdown-menu-Origin']/div/h3";
        public string LTL_ShipInformationPage_WarningMessage_Id = "warning-orange";
        public string LTL_ShipinformationPage_ShippingFrom_Xpath = ".//*[@id='scrollable-dropdown-menu-Origin']/div/h3";
        public string ShipmentList_PageTitle_Xpath = ".//*[@id='page-content-wrapper']//h1";

        //---------------------Origin section---------------
        public string LTL_ShippingFromSelectedSavedAddressFirst_Xpath = ".//div[@class='tt-suggestion']//p";
        public string LTL_SavedOriginAddressDropdown_Id = "txt_OriginAddress_ltlQuote";
        public string LTL_SavedOriginFirstAddressDropdownValue_Xpath = "//div[@id='Origin_address_chosen']/div/ul/li[2]"; //changed after UI change. Use FirstSavedOriginAddress
        public string LTL_SavedOriginAddressDropdownValues_Xpath = "//*[@id='scrollable-dropdown-menu-Origin']//span[1]//p";
        public string LTL_OriginCountryDropdown_Id = "select_origin_country_chosen";
        public string LTL_OriginCountryDropdownValue_Xpath = ".//*[@id='select_origin_country_chosen']/a";
        public string LTL_OriginCountryDropdown_SelectedValue_Xpath = ".//*[@id='select_origin_country_chosen']/a/span";
        public string LTL_OriginCountryDropdownValues_Xpath = "//div[@id='select_origin_country_chosen']/div/ul/li";
        public string LTL_OriginZipPostal_Id = "origin-zip";
        public string LTL_OriginCity_Id = "txtOrginCity";
        public string LTL_OriginStateProvince_Id = "state_origin_select_chosen";
        public string LTL_OriginStateProvince_SelectedValue_Xpath = "//div[@id='state_origin_select_chosen']/a/span";
        public string LTL_OriginStateProvinceValues_Xpath = "//div[@id='state_origin_select_chosen']/div/ul/li";
        public string ClearAddress_OriginId = "clearAddressRateOrgin";
        public string FirstSavedOriginAddress = "//*[@id='scrollable-dropdown-menu-Origin']/div/div/span[1]/span/div/span/div[1]";
        public string FirstSavedOriginAddress_CSS = ".tt-suggestion.tt-cursor>p";
        public string LTL_Origin_AutoPopulate_StateValue_xpath = ".//*[@id='state_origin_select_chosen']/a/span";
        //---------------------Origin postal looup---------------
        public string LTL_OriginLookup_Xpath = "//div[@id='page-content-wrapper']/div[2]/div[2]/div[1]/div/div[2]/div[4]/div/div[1]/div/div/label/span[1]";
        public string LTL_DestinationLookup_Xpath = "//div[@id='page-content-wrapper']/div[2]/div[2]/div[2]/div/div[2]/div[4]/div/div[1]/div/div/label/span[1]";
        public string LTL_Lookup_Header_Xpath = "//div[@id='zip-lookup']/div/div/div/div[2]/div/div[2]/h6[1]";
        public string LTL_OriginCountryDropdown_Xpath = "//*[@id='select_origin_country_chosen']/a";
        public string LTL_OriginCanadaCountryDropdown_Xpath = "//*[@id='select_origin_country_chosen']/div/ul/li[2]";
        public string LTL_Lookup_Address_Id = "txtAddrLookup";
        public string LTL_Lookup_City_Id = "txtCityLookup";
        public string LTL_Lookup_State_Id = "dv_zip_state_chosen";
        public string LTL_Lookup_StateValues_Xpath = "//div[@id='dv_zip_state_chosen']/div/ul/li";
        public string LTL_Lookup_FindZipCodeButton_Xpath = "//div[@class = 'card-front']/div[1]/div[3]/a[2]";
        public string LTL_Lookup_NewLookupButton_Id = "zip-new";
        public string LTL_Lookup_SaveCloseButton_Id = "zip-save";
        public string LTL_Lookup_CancelButton_Xpath = "//div[@class = 'card-front']/div[1]/div[3]/a[1]";
        public string LTL_Lookup_GeneratedZip_Xpath = "//div[@class = 'zip-format']/p";
        public string LTL_Lookup_ErrorMessage_Id = "dvBackErrorMessage";
        public string FirstSavedDestinationAddress = "//*[@id='scrollable-dropdown-menu-Destination']/div/div/span[1]/span/div/span/div[1]/p";

        //---------------------Destination section---------------
        public string LTL_SavedDestinationAddressDropdown_Id = "txt_DestinationAddress_ltlQuote";
        public string LTL_ShipinformationPage_ShippingTo_Xpath = ".//*[@id='scrollable-dropdown-menu-Destination']/div/h3";
        public string LTL_SavedDestinationFirstAddressDropdownValue_Xpath = "//div[@id='Destination_address_chosen']/div/ul/li[2]";//changed after UI change. Use FirstSavedDestinationAddress
        public string LTL_SavedDestinationAddressDropdownValues_Xpath = "//div[@id='Destination_address_chosen']/div/ul/li";
        public string LTL_DestinationCountryDropdown_Id = "select_destination_country_chosen";
        public string LTL_DestinationCountryDropdownValue_Xpath = "//*[@id='select_destination_country_chosen']/a";
        public string LTL_DestinationCountryDropdown_SelectedValue_Xpath = "//*[@id='select_destination_country_chosen']/a/span";
        public string LTL_DestinationCountryDropdownValues_Id = "//div[@id='select_destination_country_chosen']/div/ul/li";
        public string LTL_DestinationCanadaCountryDropdown_Xpath = "//div[@id='select_destination_country_chosen']/div/ul/li[2]";
        public string LTL_DestinationZipPostal_Id = "destination-zip";
        public string LTL_DestinationCity_Id = "txtDestCity";
        public string LTL_DestinationStateProvince_Id = "state_destination_select_chosen";
        public string LTL_DestinationStateProvince_SelectedValue_Xpath = "//div[@id='state_destination_select_chosen']/a/span";
        public string LTL_DestinationStateProvinceValues_Xpath = "//div[@id='state_destination_select_chosen']/div/ul/li";
        public string LTL_PickupDate_Id = "PickupDate";
        public string LTL_OriginSavedAddresses = "//*[@id='scrollable-dropdown-menu-Origin']/div/div/span/span/div/span";
        public string LTL_DestSavedAddresses = ".//*[@id='scrollable-dropdown-menu-Destination']/div/div/span/span/div/span";
        public string ClearAddress_DestId = "clearAddressRateDestination";
        //---------------------Freight Description section---------------
        public string LTL_FreightDescriptionHeader_Xpath = ".//*[@id='page-content-wrapper']//*[text()='Freight Description']";
        public string LTL_SavedItemDropdown_Id = "Select-saveditem-0"; 
        public string LTL_InusredRate_Id = "shipValueNumber";
        public string LTL_SavedItemDropdownValues_Xpath = ".//*[@id='scrollable-dropdown-menu-Origin']/div/span[1]/span/div/span/div[1]/p";
        public string LTL_SavedItemDropdown_SearchBox_Xpath = "//div[@id='Select_saveditem_0_chosen']/div/div/input";
        public string LTL_Classification_Id = "Select-saveditem-0";
        public string LTL_Classification_SelectedValue_Xpath = ".//*[@id='Select_saveditem_0_chosen']/a/span";
        public string LTL_ClassificationValues_Xpath = ".//*[@id='scrollable-dropdown-menu-Origin']//div/p";
        public string LTL_Weight_Id = "weight-0";
        public string LTL_Quan_Id = "quantity-0";
        public string LTL_ClearItem_Id = "frieghtclearbtn_rates";
        public string LTL_Length_Id = "length-0";
        public string LTL_Width_Id = "width-0";
        public string LTL_Height_Id = "height-0";



        public string LTL_AddAdditionalItemLink_Xpath = "//*[text()='Add Additional Item']";

        public string LTL_Additional_SelectClass_Id = "Select-saveditem-1";
        public string LTL_Additinal_Weight_Id = "weight-1";
        public string LTL_Additional_DensityCalculator_Icon_Id = "est-cls-btn-1";
        public string LTL_Additional_Quantity_Id = "quantity-1";
        public string LTL_Additional_QuantityType_Xpath = ".//*[@id='quantity_uom_1_chosen']/a/span";

        public string LTL_RemoveAdditionalItemLink_Xpath = "//div[@id='1']/div[2]/div/div[2]/div[2]/button";
        public string LTL_RemoveItem_Xpath = ".//*[@id='1']/div[2]/div/div[3]/div[2]/button";

        //47871 - Modified the insured value Element xpath as the old one (LTL_EnterInsuredValue_Id) was pointing to the InsuredValue dropdown "New, Used"
        public string LTL_EnterInsuredValue_Xpath = ".//input[@id='shipValueNumber']";

        public string LTL_EnterInsuredValue_Id = "Insvalue"; 
        public string LTL_MaxShipmentValue_Error_Xpath = "//div[@id='shipment-value-warning']/p";
        public string LTL_QuestionMarkIcon_Id = "question-icon";
        public string LTL_TermsAndConditionsLink_Xpath = "//div[@class = 'col-md-6 terms-pad']/div/a";
        public string LTL_Terms_PopupHeader_Xpath = "//div[@id='shipment-model']/div/div/div/div[1]/h3";
        public string LTL_Terms_Popup_Xpath = ".//*[@id='showModalScrollableCntBtn']//div[@class='modal-content']";
        public string LTL_Terms_PopupClose_Xpath = "//div[@id='shipment-model']/div/div/div/div[3]/a";
        public string LTL_EvidenceofInsuranceForm_Id = "terms-download";
        public string LTL_Quantity_Id = "quantity-0";
        public string LTL_QuantityUnitField_Xpath = ".//*[@id='quantity_uom_0_chosen']/a";
        public string LTL_QuantityUnitField_Selectedvalue_Xpath = ".//*[@id='quantity_uom_0_chosen']/a/span";
        public string LTL_QuantityUOMoptions_Xpath = ".//*[@id='quantity_uom_0_chosen']/div/ul/li";
        public string LTL_QuantityFieldWarningMessage_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div[3]/div[1]/div/div[2]/div[1]/div[2]/div[1]/div[2]/p";
        public string LTL_AdditionalQuantity_Id = "quantity-1";
        public string LTL_AdditionalQuantityunit_Xpath = ".//*[@id='quantity_uom_1_chosen']/a";
        public string LTL_AdditionalQuantityunitValues_Xpath = ".//*[@id='quantity_uom_0_chosen']/div/ul/li";
        public string LTL_AdditionalQuantity_Label = ".//*[@id='1']/div[2]/div/div[1]/div[1]/div[1]/label";
        public string QuantityDropdown_id = "quantity_uom_0_chosen";
        public string TagnameforQuatity_Dropdownoptions = "li";
        public string LTL_TermsAndConditionsPopupText_Xpath = "//div[@id='shipment-model']/div/div/div/div[2]/div/p";
        public string LTL_TermsandConditionslink = "btnshipment-model";


        public string InsuredValueToolTip_Id = "";
        public string InsuredType_Xpath = ".//*[@id='Insvalue_chosen']/a";
        public string InsuredValueTypeDropDown_Xpath = ".//*[@id='Insvalue_chosen']/div/ul";
        public string NewOrUsedDropdown = ".//*[@id='Insvalue_chosen']";
        public string InsuredValueDefault = ".//*[@id='Insvalue_chosen']/a/span";

        public string PicupDate_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div[2]/div[9]/div/div/h3";


        //---------------------Estimate Class---------------------
        public string LTL_EstimateClassButton_Id = "est-cls-btn-0"; //same for both Quote and Shipment
        public string LTL_EstimateClassButton_xpath = "//button[@id='est-cls-btn-0']"; //same for both Quote and Shipment
        public string LTL_EstimateClass_HeaderText_Xpath = "//div[@id='estimated-class-calc']/div/div/div/div[1]/h3"; //same for both Quote and Shipment
        public string LTL_EstimateClass_Length_Id = "ec-length"; //same for both Quote and Shipment
        public string LTL_EstimateClass_Width_Id = "ec-width"; //same for both Quote and Shipment
        public string LTL_EstimateClass_Height_Id = "ec-height"; //same for both Quote and Shipment
        public string LTL_EstimateClass_Weight_Id = "ec-weight"; //same for both Quote and Shipment
        public string LTL_EstimateClass_Quantity_Id = "ec-quantity"; //same for both Quote and Shipment
        public string LTL_EstimateClass_Density_Id = "ec-density"; //same for both Quote and Shipment
        public string LTL_EstimateClass_CalculatedClass_Id = "ESTIMATED_CLASS";
        public string LTL_EstimateClass_TableLink_Id = "see-estimated-class"; //same for both Quote and Shipment
        public string LTL_EstimateClass_Table_Id = "estimated-commodity-table"; //same for both Quote and Shipment
        public string LTL_EstimateClass_TableClassificationValues_Xpath = "//table[@id='estimated-commodity-table']/tbody/tr/td[2]"; //same for both Quote and Shipment
        public string LTL_EstimateClass_ApplyClass_Xpath = "//div[@class = 'modal-content']/div[3]/a[2]"; //same for both Quote and Shipment
        public string LTL_EstimateClass_Close_Xpath = "//div[@class = 'modal-content']/div[3]/a[1]"; //same for both Quote and Shipment
        public string LTL_EstimateClass_TableClassification_Xpath = "//table[@id='estimated-commodity-table']/tbody/tr[16]/td[2]"; //same for both Quote and Shipment

        public string LTL_EstimateClassModal_Verbiage_Xpath = ".//*[@id='estimated-class-calc']//*[@class='modal-header']"; //same for both Quote and Shipment
        public string LTL_EstimateClass_Verbiage_Xpath = ".//*[@id='estimated-class-calc']//*[@class='para-EstimateClass']"; //same for both Quote and Shipment
        public string LTL_EstimateClass_Length_Verbiage_Xpath = "//*[@id='estimated-class-calc']/div/div/div/div[2]/div[1]/div[1]/div/div/label"; //same for both Quote and Shipment
        public string LTL_EstimateClass_Width_Verbiage_Xpath = "//*[@id='estimated-class-calc']/div/div/div/div[2]/div[1]/div[2]/div/div/label"; //same for both Quote and Shipment
        public string LTL_EstimateClass_Height_Verbiage_Xpath = "//*[@id='estimated-class-calc']/div/div/div/div[2]/div[1]/div[3]/div/div/label"; //same for both Quote and Shipment
        public string LTL_EstimateClass_Weight_Verbiage_Xpath = "//*[@id='estimated-class-calc']/div/div/div/div[2]/div[3]/div[1]/div/div[1]/label"; //same for both Quote and Shipment
        public string LTL_EstimateClass_Quantity_Verbiage_Xpath = "//*[@id='estimated-class-calc']/div/div/div/div[2]/div[3]/div[2]/div/div[1]/label"; //same for both Quote and Shipment
        public string LTL_EstimateClass_Density_Verbiage_Xpath = "//*[@id='estimated-class-calc']/div/div/div/div[2]/div[3]/div[3]/div/div[1]/label"; //same for both Quote and Shipment
        public string LTL_EstimateClass_CalculatedClass_Verbiage_Id = "estCLassHdr"; //same for both Quote and Shipment
        public string LTL_EstimateClass_DensityTable_Verbiage_Xpath = "//*[@id='estimated-commodity-table']/thead/tr[2]/th[1]"; //same for both Quote and Shipment
        public string LTL_EstimateClass_DensityTable_ClassVerbiage_Xpath = "//*[@id='estimated-commodity-table']/thead/tr[2]/th[2]"; //same for both Quote and Shipment
        public string LTL_EstimateClass_HoverMessage_xpath = "//button[@id='est-cls-btn-0']"; //same for both Quote and Shipment
        public string LTL_EstimatedClass_CommodityClassTable_Verbiage_xpath = ".//*[@id='estimated-commodity-table']/thead/tr[1]/th"; //same for both Quote and Shipment
        public string LTL_EstimatedClass_ErrorMessage_Id = "ec-est-class-error";
        public string LTL_EstimatedClass_Weight_Warning_Message_Id = "ec-weight-error";
        public string LTL_EstimatedClass_Quantity_Warning_Message_Xpath = ".//*[@id='ec-quantity-error']/p";


        //---------------------Services and Accessorials section---------------
        public string LTL_ServicesDropdown_Xpath = ".//*[@id='services_accessorials_chosen']/ul/li";
        public string LTL_ServicesDropdownValues_Xpath = ".//*[@id='services_accessorials_chosen']/ul/li";
        public string LTL_ViewQuoteResults_Id = "view-quote-results";
        public string LTL_RequiredFieldError_Id = "warning-missing-info";
        public string LTL_ServicesAndAccessorials_Id = "Select-saveditem-0";
        public string LTL_ServiceAndAccesc_ShipFrom_Xpath = ".//*[@id='servicesaccessorialsfrom_chosen']/*[@class ='chosen-choices']/*[@class='search-field']";
        public string LTL_ServicesAndAccessorials_ShipFrom_Xpath = ".//*[@id='servicesaccessorialsfrom_chosen']/ul/li";
        public string LTL_ServiceAndAccesc_ShipFromDropdown_Xpath = ".//*[@id='servicesaccessorialsfrom_chosen']/*[@class='chosen-drop']/*[@class='chosen-results']/li";
        public string LTL_ServicesAndAccessorials_ShipTo_Xpath = ".//*[@id='servicesaccessorialsto_chosen']/ul/li";
        public string LTL_ServiceAndAcces_ShipTo_Xpath = ".//*[@id='servicesaccessorialsto_chosen']/*[@class='chosen-choices']/*[@class='search-field']";
        public string LTL_ServiceAndAccesDropdown_ShipTo_Xpath = ".//*[@id='servicesaccessorialsto_chosen']/*[@class='chosen-drop']/*[@class='chosen-results']/li";
        public string LTL_ServicesAndAccessorials_ShipFrom_Del_Xpath = ".//*[@id='servicesaccessorialsfrom_chosen']/ul/li/a";
        public string LTL_ServicesAndAccessorials_ShipTo_Del_Xpath = ".//*[@id='servicesaccessorialsto_chosen']/ul/li/a";
        public string LTL_ServicesDropdownValues_ShipFrom_Xpath = ".//*[@id='servicesaccessorialsfrom_chosen']/div/ul/li";
        public string LTL_ServicesDropdownValues_ShipTo_Xpath = ".//*[@id='servicesaccessorialsto_chosen']/div/ul/li";
        public string LTL_ServicesAndAccessorials_ShipFromText_Xpath = ".//*[@id='servicesaccessorialsfrom_chosen']/ul/li[3]/input";
        public string LTL_ServicesAndAccessorials_ShipFrom_Text_Xpath = ".//*[@id='servicesaccessorialsfrom_chosen']/ul/li/input";
        public string LTL_ServicesAndAccessorials_ShipTo_Text_Xpath = ".//*[@id='servicesaccessorialsto_chosen']/ul/li/input";
        public string LTL_SelectedAccessorialsInShipFrom_Xpath = ".//*[@id='servicesaccessorialsfrom_chosen']//li[1]/span";


        //-------------- Rate results-----------------------------
        public string LtlQuoteResultsPage_Norates_Xpath = ".//*[@id='page-content-wrapper']//h5";
        public string LtlGuaranteedSaveRateAsQuote_Xpath = ".//*[@id='Grid-Rate-List-Large-Guranteed']/tbody/tr/td[4]//a";
        public string LtlGuaranteedSaveInsRateAsQuote_Xpath = ".//*[@id='Grid-Rate-List-Large-Guranteed']/tbody/tr/td[5]//a";
        public string LtlLeastCost_Xpath = ".//*[@id='page-content-wrapper']//div[2]/label";
        public string ltlQuoteResultsheader_xpath = ".//h1[contains(text(), 'Quote Results (LTL)')]";
        public string ltlBacktoQuoteListBtn_xpath = ".//*[@id='Btn_BackQuoteList']";
        public string ltlEnterInsuredValueTextbox_xpath = ".//*[@id='shipValueNumber']";
        public string ltlShowInsuredRateBtn_xpath = ".//*[@id='showInsuredRate']";
        public string ltlShowInsuredRateBtn_id = "showInsuredRate";
        public string ltlerrormsgfornoshipmentvalue_xpath = ".//*[@id='page-content-wrapper']/div[2]/div[2]/div[1]/div[3]/div/form/div[2]/div/p";
        public string ltlTermsandConditionslnk_xpath = ".//*[@id='page-content-wrapper']/div[2]/div[2]/div[1]/div[3]/div/form/div[1]/div/a";
        public string ltldownloadbtn_xpath = ".//*[@id='terms-download']";
        public string ltlQuickestSrvcRadioBtn_xpath = ".//*[@id='page-content-wrapper']/div[2]/div[2]/div[1]/div[5]/div[1]/div/div/div[1]/label";
        public string ltlLeastcostRadioBtn_xpath = ".//*[@id='page-content-wrapper']/div[2]/div[2]/div[1]/div[5]/div[1]/div/div/div[2]/label";
        public string ltlExportBtn_xpath = ".//*[@id='show-export-btn']";
        public string ltlCarriergrid_xpath = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/thead/tr/th[1]";
        public string ltlCarrierName_xpath = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[1]/ul/li[1]";
        public string ltlCarrierLogo_xpath = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[1]/ul/li[1]/img";
        public string ltlCarrNewAmt_xpath = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr/th[1]/ul/li[3]/div";
        public string ltlCarrUsedAmt_xpath = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr/th[1]/ul/li[3]/div";
        public string ltlGuaranteedRateAvbllnk_xpath = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr/td[1]//a";
        public string ltlServiceDaysgrid_xpath = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/thead/tr/th[2]";
        public string ltlNoOfDays_xpath = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[2]/div";
        public string ltlServiceType_xpath = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[2]/div";
        public string ltlSaveurQuotelnk_xpath = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[4]//a";
        public string ltlUpdateurShpngInfolnk_xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[2]/div/div/a";
        public string ltldistancesort_xpath = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/thead/tr/th[3]";
        public string ltldistancevalue_xpath = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[3]/div";
        public string ltlstdRatesort_xpath = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/thead/tr/th[4]";
        public string ltlstdRateamount_xpath = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[4]/ul[1]/li[1]";
        public string ltlstdFuel_xpath = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[4]/ul[1]/li[2]";
        public string ltlstdLinehaul_xpath = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[4]/ul[1]/li[3]";
        public string ltlstdaccessorials_xpath = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[4]/ul[1]/li[4]";
        public string ltlcreateshipmentbtn_xpath = ".//*[@id='create-std-shipment-btn']";
        public string ltlsavequotenorateslink_xpath = ".//*[@id='no-results-save-quote']";
        public string ltlsaverateasquotelnk_xpath = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[4]/ul[2]/li/a";
        public string ltlsaverateasquotelnkint_xpath = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[5]//a";
        public string ltlsaverateasquotelnkStationUsers_xpath = "//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[5]/ul[3]/li/a";
        public string ltlsaverateasquotelnk_CSSPath = ".save-rate-as-quote";
        public string ltlcreateinsshipmentbtn_xpath = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[5]/button";
        public string ltlsaveinsrateasquotelnk_xpath = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[ul/li/a[contains(@class,'save-insured-rate-as-quote')]]/ul[li/a[contains(.,'Save Insured Rate As Quote')]]/li/a";
        public string ltlsaveinsrateasquotelnk_int_xpath = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[6]/ul[3]/li/a";
        public string ltlsaveinsrateasquotelnkStationUsers_xpath = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[6]/ul[3]/li/a";
        public string ltlinsratesort_id = "";
        public string ltlinsrateamount_xpath = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[5]/ul[1]/li[1]";
        public string ltlinsfuel_xpath = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[5]/ul[1]/li[2]";
        public string ltlinslinehaul_xpath = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[5]/ul[1]/li[3]";
        public string ltlinsaccessorials_xpath = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[5]/ul[1]/li[4]";
        public string ltlinsmodal_xpath = ".//*[@id='insuredCreateShipmentModal']/div/div/div";
        public string ltlinsmdlheader_xpath = ".//*[@id='insuredCreateShipmentModal']/div/div/div/div[1]/h3";
        public string ltlinsmdlsubheader_xpath = ".//*[@id='insuredCreateShipmentModal']/div/div/div/div[2]/div[1]/div/h5";
        public string ltlinsmdlshpmentvalue_id = "shipValueNumber-popup-txt";
        public string ltlinsmdlshowinsratebtn_xpath = ".//*[@id='showInsuredRate-popup-btn']";
        public string ltlinsmdlcntuewoutinsrate_xpath = ".//*[@id='create-shipment-btn']";
        public string ltlinsmdldontshowagain_xpath = ".//*[@id='insuredCreateShipmentModal']/div/div/div/div[2]/div[6]/div/div/div/div/label";
        public string ltlNoRateResultstxt_xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[2]/div/h5";
        public string ltlstandardgrid_xpath = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr/th[4]";
        public string ltlinsuredratecolumngrid_xpath = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/thead/tr/th[5]";
        public string ltltermsncndtnspopupheader_xpath = ".//*[@id='showModalScrollableCntBtn']/div/div/div/div[1]/h3";
        public string ltltermsncndtnsbody_xpath = ".//*[@id='showModalScrollableCntBtn']/div/div/div/div[2]/div/p";
        public string ltlDownloadDLSW_xpath = ".//*[@id='terms-download']";
        public string ltltermsncndtnspopupclose_xpath = ".//*[@id='showModalScrollableCntBtn']/div/div/div/div[3]/a";
        public string ltlguarenteedrategrid_xpath = ".//*[@id='Grid-Rate-List-Large-Guranteed_wrapper']/div[2]/div";
        public string ltlresultsgridall_xpath = ".//*[@id='Grid-Rate-List-Large-NonGuranteed_wrapper']/div[2]/div";
        public string ltldistancecolumnall_xpath = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr/td[3]/div";
        public string ltlstandardratesall_xpath = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr/td[4]/ul[1]/li[1]";
        public string ltlinsratesall_xpath = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr/th[5]/ul[1]/li[1]";
        public string ltlservicedaysall_xpath = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr/td[2]/div";
        public string ltlcarriersall_xpath = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr/td[1]/ul/li[1]";
        public string ltlDisclaimer_xpath = ".//*[@id='page-content-wrapper']/div[2]/div[2]/div[4]/p[1]/strong";
        public string ltlcarrierheader_xpath = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/thead/tr/th[1]";
        public string ltlservicedaysheader_xpath = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/thead/tr/th[2]";
        public string ltldistanceheader_xpath = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/thead/tr/th[3]";
        public string ltlrateheader_xpath = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/thead/tr/th[4]";
        public string ltlinsrateheader_xpath = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/thead/tr/th[5]";
        public string ltlnorateresultsheader_xpath = "//div[@id='page-content-wrapper']/div[2]/div/div[2]/div/h5";
        public string ltlsavegaurenteedstdquote_xpath = ".//*[@id='Grid-Rate-List-Large-Guranteed']/tbody/tr[1]/td[4]/ul[2]/li/a";
        public string LTL_getquotemainheader = ".//*[@id='page-content-wrapper']/div[2]/div[1]/div/div[1]/h1";
        public string LTL_createshipmentpageheader_xpath = ".//*[@id='body']/section/div[3]/div[1]/h1";
        public string LTL_shipmentinformationpageheaderc_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div[1]/div/div[1]/h1";
        public string ltlcarrierName_mobile_xpath = ".//*[@class='rate-CarrierName text-bold']";
        public string ltlcarrierLogo_mobile_xpath = ".//*[@id='rate-table']/tbody/tr/td/table[1]/tbody/tr[1]/td/img";
        public string ltlGuaranteedrateavbl_mobile_xpath = ".//*[@id='rate-table']/tbody/tr/td/table[1]/tbody/tr[2]/td/a";
        public string ltlservice_mobile_xpath = ".//*[@class='rate-ServiceDays']";
        public string ltldistance_mobile_xpath = ".//*[@class='rate-Distance']";
        public string ltlrate_mobile_xpath = ".//*[@class='rate-StandardRateTotalCost text-bold']";
        public string ltlsaverateasquote_mobile_xpath = ".//*[@id='rate-table']/tbody/tr/td/table[1]/tbody/tr[5]/td/a";
        public string ltlinsuredrate_mobile_xpath = ".//*[@class='rate-InsuredRateTotalCost text-bold']";
        public string ltlsaveinsuredrateasquote_mobile_xpath = ".//*[@id='rate-table']/tbody/tr/td/table[1]/tbody/tr[7]/td/a";
        public string ltlshipmentOriginName_xpath = ".//*[@id='txtOrginName']";
        public string ltlshipmentOriginAddress_xpath = ".//*[@id='txtOrginAddr1']";
        public string ltlshipmentDestinationName_xpath = ".//*[@id='txtDestName']";
        public string ltlshipmentDestinationAddress_xpath = ".//*[@id='txtDestAddr1']";
        public string ltlshipmentSaveandContinuebtn_xpath = ".//*[@id='saveLocation']";
        public string ltlshipmentBackbtn_xpath = ".//*[@id='backLocation']";
        public string ltlshipmentQuantity_xpath = ".//*[@id='txtquantity']";
        public string ltlshipmentQuantityUnitfield_xpath = ".//*[@id='dv-trans-select']/span[2]/span/span[1]";
        public string ltlshipmentLocationsandDates_xpath = ".//*[@id='main']//div/h3";
        public string ltlquantitydropdown_id = "quantity_uom_0_chosen";
        public string TagName_ltlquantitydropdown = "li";
        public string LTL_TermsAndConditions_Results_xpath = "//a[contains(text(),'Terms and Conditions')]";
        public string LTL_TermsAndConditions_Results_Id = "btnshowModalScrollableCntBtn";
        public string LTL_TermsAndConditionsPopupTextResults_Xpath = "//div[@id='showModalScrollableCntBtn']/div/div/div/div[2]/div/p";
        public string LTL_TermsAndConditionPopupTitle_Xpath = "//h3[contains(text(), 'Terms And Conditions Of Coverage')]";
        public string LTL_TermsAndConditionOverlayGetQuote_Xpath = "//div[@id='shipment-model']";
        public string LTL_TermsAndConditionOverlayQuoteResults_Xpath = "//div[@id='showModalScrollableCntBtn']";

        public string saverateasquoteGuaranteed_xpath = ".//*[@id='Grid-Rate-List-Large-Guranteed']/tbody/tr[1]/td[ul/li/a[contains(@class, 'save-guranteed-rate-as-quote')]]/ul[2]/li/a";
        public string saverateasquoteGuaranteedint_xpath = ".//*[@id='Grid-Rate-List-Large-Guranteed']/tbody/tr[1]/td[5]/ul[3]/li/a";
        public string saveinsrateasquoteGuaranteed_xpath = ".//*[@id='Grid-Rate-List-Large-Guranteed']/tbody/tr[1]/td[5]/ul[2]/li/a";
        public string saveinsrateasquoteGuaranteedint_xpath = ".//*[@id='Grid-Rate-List-Large-Guranteed']/tbody/tr[1]/td[6]/ul[3]/li/a";
        public string ltlInsuredValueTypeDropDown = ".//*[@id='Insvalue_chosen']/a";
        public string ltlEnterInsuredValueText_xpath = ".//*[@id='Insvalue_chosen']/div/ul/li";
        public string mobileguaranteedrate_xpath = ".//*[@id='guaranteed-table']/tbody/tr/td/table[1]/tbody/tr[2]/td";
        public string mobileguaranteedsavequote_xpath = ".//*[@id='guaranteed-table']/tbody/tr/td/table[1]/tbody/tr[6]/td/a";
        public string mobileguaranteedinssavequote_xpath = ".//*[@id='guaranteed-table']/tbody/tr/td/table[1]/tbody/tr[8]/td/a";
        public string InsmodalInsuredType_Xpath = ".//*[@id='InsvalueModal_chosen']/a";
        public string InsmodalInsuredValueTypeDropDown_Xpath = ".//*[@id='InsvalueModal_chosen']/div/ul";
        public string InsmodalNewOrUsedDropdown = ".//*[@id='InsvalueModal_chosen']";
        public string InsmodalInsuredValueDefault = ".//*[@id='InsvalueModal_chosen']/a/span";
        public string EnterInsvaltext_xpath = ".//*[@class='col-md-12 col-lg-12 insured-row-shipment-lbl']/span";
        public string Instypeselected_xpath = ".//*[@class='chosen-single']";
        public string QuoteResultes_Linehaul_Xpath = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[4]/ul[1]/li[1]";
        public string ShipResults_Linehaul_Xpath = ".//*[@id='ShipmentResultTable']/tbody/tr[1]/td[4]/div[3] - line haul";
        public string QuoteResults_Total_Xpath = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[4]/ul[1]/li[1]-total";
        public string ShipResults_Total_Xpath = ".//*[@id='ShipmentResultTable']/tbody/tr[1]/td[4]/div[1]-total";
        public string ShipResultsFuel_Xpath = ".//*[@id='ShipmentResultTable']/tbody/tr[1]/td[4]/div[2]-fuel";
        //---------------------allrates---
        public string ltl_rateamount_NG_S = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr/td[4]/ul[1]/li[1]";
        public string ltl_fuelall_NG_S = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr/td[4]/ul[1]/li[2]";
        public string ltl_alllinehaul_NG_S = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr/td[4]/ul[1]/li[3]";
        public string ltl_Accessorialsall_NG_S = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr/td[4]/ul[1]/li[4]";

        public string ltl_rateamount_NG_I = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr/td[5]/ul[1]/li[1]";
        public string ltl_fuelall_NG_I = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr/td[5]/ul[1]/li[2]";
        public string ltl_alllinehaul_NG_I = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr/td[5]/ul[1]/li[3]";
        public string ltl_Accessorialsall_NG_I = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr/td[5]/ul[1]/li[4]";

        public string ltl_rateamount_G_S = ".//*[@id='Grid-Rate-List-Large-Guranteed']/tbody/tr/td[4]/ul[1]/li[1]";
        public string ltl_fuelall_G_S = ".//*[@id='Grid-Rate-List-Large-Guranteed']/tbody/tr/td[4]/ul[1]/li[2]";
        public string ltl_alllinehaul_G_S = ".//*[@id='Grid-Rate-List-Large-Guranteed']/tbody/tr/td[4]/ul[1]/li[3]";
        public string ltl_Accessorialsall_G_S = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr/td[4]/ul[1]/li[4]";

        public string ltl_ltl_rateamount_G_I = ".//*[@id='Grid-Rate-List-Large-Guranteed']/tbody/tr/td[5]/ul[1]/li[1]";
        public string ltl_fuelall_G_I = ".//*[@id='Grid-Rate-List-Large-Guranteed']/tbody/tr/td[5]/ul[1]/li[2]";
        public string ltl_alllinehaul_G_I = ".//*[@id='Grid-Rate-List-Large-Guranteed']/tbody/tr/td[5]/ul[1]/li[3]";
        public string ltl_Accessorialsall_G_I = "//*[@id='Grid-Rate-List-Large-Guranteed']/tbody/tr/td[5]/ul[1]/li[4]";

        public string ltl_carriernewused = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[2]/td[1]/ul/li[2]/div";
        public string ltl_carriernewused_G = ".//*[@id='Grid-Rate-List-Large-Guranteed']/tbody/tr[2]/td[1]/ul/li[2]/div";


        public string ltl_carriernewused_all = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr/td[1]/ul/li[2]/div";
        public string ltl_carriernewused_G_all = ".//*[@id='Grid-Rate-List-Large-Guranteed']/tbody/tr[2]/td[1]/ul/li[2]/div";

        public string LTL_termsandctext = ".//*[@id='shipment-model']/div/div/div/div[2]/div/p";
        public string LTL_Rtermsandctext = ".//*[@id='showModalScrollableCntBtn']/div/div/div/div[2]/div/p";

        public string LiabilityCostperPound = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr/td[1]/ul/li[2]/span";
        public string MaxLiabilityVerbiage = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[4]/td[1]/ul/li[3]/span";
        public string LiabilityCostperPoundnewused = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr/td[1]/ul/li[2]/div[1]";

        public string LiabilityCostperPound_G = ".//*[@id='Grid-Rate-List-Large-Guranteed']/tbody/tr/td[1]/ul/li[2]/span";
        public string MaxLiabilityVerbiage_G = ".//*[@id='Grid-Rate-List-Large-Guranteed']/tbody/tr/td[1]/ul/li[3]/span";
        public string LiabilityCostperPoundnewused_G = ".//*[@id='Grid-Rate-List-Large-Guranteed']/tbody/tr/td[1]/ul/li[2]/div[1]";
        public string ltlcarriersall_G_xpath = ".//*[@id='Grid-Rate-List-Large-Guranteed']/tbody/tr/td[1]/ul/li[1]";
        
        //------------------------------------internaluserssavequote----------------------
        public string QuoteResults_EstCost_FirstCarriervalue_G_xpath = ".//*[@id='Grid-Rate-List-Large-Guranteed']/tbody/tr[1]/td[4]/ul/li[1]";
        public string QuoteResults_EstMargin_FirstCarriervalue_G_xpath = ".//*[@id='Grid-Rate-List-Large-Guranteed']/tbody/tr[1]/td[5]/ul[2]/li";
        public string QuoteResults_EstCost_FirstCarriervaluec_xpath = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[4]/ul/li[1]";
        public string QuoteResults_EstMargin_FirstCarriervaluec_xpath = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[5]/ul[2]/li";      

        //--------------------LTL Quote Confirmaion(QC) Page---------------
        public string LTL_StationCustomerName_Label_id = "StationCustomerLbl";

        public string LTL_QuoteConfirmationPageHeader_Xpath = "//*[@id='page-content-wrapper']/div[2]/div[1]/div/div[1]/h1";
        public string LTL_QC_ServiceText_Xpath = "//*[@id='page-content-wrapper']/div[2]/div[2]/div/div[1]/div[1]/label";
        public string LTL_QC_Service_Xpath = "//*[@id='page-content-wrapper']/div[2]/div[2]/div/div[1]/div[2]/label";

        public string LTL_QC_PickupText_Xpath = "//*[@id='page-content-wrapper']/div[2]/div[2]/div/div[2]/div[1]/label";
        public string LTL_QC_Pickup_Xpath = "//*[@id='page-content-wrapper']/div[2]/div[2]/div/div[2]/div[2]/label";

        public string LTL_QC_requestnumber_Xpath = "//*[@id='page-content-wrapper']/div[2]/div[2]/div/div[3]/div[1]/label";
        public string LTL_QC_requestnumber_Id = "//*[@id='page-content-wrapper']/div[2]/div[2]/div/div[3]/div[2]/label";
        public string QC_RequestNumber_id = "referenceNumber-value";
        public string LTL_QC_StatusText_Xpath = "//*[@id='page-content-wrapper']/div[2]/div[2]/div/div[4]/div[1]/label";
        public string LTL_QC_Status_Xpath = "//*[@id='page-content-wrapper']/div[2]/div[2]/div/div[4]/div[2]/label";

        public string LTL_QC_BackToQuoteListButton_Id = "Btn_BackQuoteList";

        public string LTL_QC_BackToQuoteListButton_Apath = ".//*[@id='Btn_BackQuoteList']";

        public string LTL_QC_ShowQuoteDetails_Id = "lnk_ShowQuote";
        public string LTL_QC_HideQuoteDetails_Id = "lnk_ShowQuote";

        public string LTL_QC_ShipmentInformationHeader_Xpath = "//*[@id='page-content-wrapper']/div[2]/div[5]/div/div/div[1]/h4";

        public string LTL_QC_CarrierNameHeader_Xpath = "//*[@id='page-content-wrapper']/div[2]/div[5]/div/div/div[2]/div[1]/div[1]/h5";
        public string LTL_QC_CarrierNameText_Xpath = "//*[@id='page-content-wrapper']/div[2]/div[5]/div/div/div[2]/div[1]/div[1]/div/div/div[1]/label";
        public string LTL_QC_CarrierName_Xpath = "//*[@id='page-content-wrapper']/div[2]/div[5]/div/div/div[2]/div[1]/div[1]/div/div/div[2]";

        public string LTL_QC_QuoteAmountHeader_Xpath = "//*[@id='page-content-wrapper']/div[2]/div[5]/div/div/div[2]/div[1]/div[2]/h5";
        public string LTL_QC_QuoteAmountText_Xpath = "//*[@id='page-content-wrapper']/div[2]/div[5]/div/div/div[2]/div[1]/div[2]/div/div/div[1]/label";
        public string LTL_QC_QuoteAmount_Xpath = "//*[@id='page-content-wrapper']/div[2]/div[5]/div/div/div[2]/div[1]/div[2]/div/div/div[2]";


        public string LTL_QC_OriginLocationHeader_Xpath = "//*[@id='page-content-wrapper']/div[2]/div[5]/div/div/div[2]/div[2]/div[1]/h5";
        public string LTL_QC_OriginAddressText_Xpath = "//*[@id='page-content-wrapper']/div[2]/div[5]/div/div/div[2]/div[2]/div[1]/div/div/div[1]/label";
        public string LTL_QC_OriginAddress_Xpath = "//*[@id='page-content-wrapper']/div[2]/div[5]/div/div/div[2]/div[2]/div[1]/div/div/div[2]";

        public string LTL_QC_DestinationLocationHeader_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div[5]/div/div/div[2]/div[2]/div[2]/h5";
        public string LTL_QC_DestinationAddressText_Xpath = "//*[@id='page-content-wrapper']/div[2]/div[5]/div/div/div[2]/div[2]/div[2]/div/div/div[1]/label";
        public string LTL_QC_DestinationAddress_Xpath = "//*[@id='page-content-wrapper']/div[2]/div[5]/div/div/div[2]/div[2]/div[2]/div/div/div[2]";

        public string LTL_QC_DatesHeader_Xpath = "//*[@id='page-content-wrapper']/div[2]/div[5]/div/div/div[2]/div[3]/div[1]/h5";
        public string LTL_QC_PickupDateText_Xpath = "//*[@id='page-content-wrapper']/div[2]/div[5]/div/div/div[2]/div[3]/div[1]/div/div[1]/div[1]/label";
        public string LTL_QC_PickupDate_Xpath = "//*[@id='page-content-wrapper']/div[2]/div[5]/div/div/div[2]/div[3]/div[1]/div/div[1]/div[2]";

        public string LTL_QC_ServicesAndAccessorialsHeader_Xpath = "//*[@id='page-content-wrapper']/div[2]/div[5]/div/div/div[2]/div[3]/div[2]/h5";
        public string LTL_QC_ServicesAndAccessorialNameText_Xpath = "//*[@id='page-content-wrapper']/div[2]/div[5]/div/div/div[2]/div[3]/div[2]/div/div/div[1]/label";
        public string LTL_QC_ServicesAndAccessorialName_Xpath = "//*[@id='page-content-wrapper']/div[2]/div[5]/div/div/div[2]/div[3]/div[2]/div/div/div[2]";

        public string LTL_QC_FrightDescriptionHeader_Xpath = ".//div[@class='col-xs-12 col-sm-12 col-md-12 FrightHdr']/h5";
        public string LTL_QC_FrightQuantity_Xpath = ".//*[@id='GetRateFrieghtInfo']/thead/tr/th[1]";
        public string LTL_QC_FrightWeight_Xpath = ".//*[@id='GetRateFrieghtInfo']/thead/tr/th[2]";
        public string LTL_QC_FrightClass_Xpath = ".//*[@id='GetRateFrieghtInfo']/thead/tr/th[3]";
        public string LTL_QC_FrightInsuredValue_Xpath = ".//*[@id='GetRateFrieghtInfo']/thead/tr/th[4]";
        public string LTL_QC_FrightHazmat_Xpath = ".//*[@id='GetRateFrieghtInfo']/thead/tr/th[6]";
        public string LTL_QC_FrightQuantityValue_Xpath = ".//*[@id='GetRateFrieghtInfo']/tbody/tr/td[1]";
        public string LTL_QC_FrightWeightValue_Xpath = ".//*[@id='GetRateFrieghtInfo']/tbody/tr/td[2]";
        public string LTL_QC_FrightClassValue_Xpath = ".//*[@id='GetRateFrieghtInfo']/tbody/tr/td[3]";
        public string LTL_QC_FrightInsuredValueAmount_Xpath = ".//*[@id='GetRateFrieghtInfo']/tbody/tr/td[4]";
        public string LTL_QC_FrightHazmatValue_Xpath = ".//*[@id='GetRateFrieghtInfo']/tbody/tr/td[6]";
        public string LTL_QC_FreightInsuredtype_Xpath = ".//*[@id='GetRateFrieghtInfo']//th[5]";
        public string LTL_QC_FreightInsuredtypeValue_Xpath = ".//*[@id='GetRateFrieghtInfo']//td[5]";

        public string LTL_QC_FrightInformationCount = "//*[@id='GetRateFrieghtInfo']/tbody/tr";
        public string LTL_QC_FrightWeightEnterdValue_Xpath = "//*[@id='GetRateFrieghtInfo']/tbody/tr[1]/td[2]";
        public string LTL_QC_FrightClasstEnterdValue_Xpath = "//*[@id='GetRateFrieghtInfo']/tbody/tr[1]/td[2]";
        public string LTL_QC_FrightShipmentValueEnterdValue_Xpath = "//*[@id='GetRateFrieghtInfo']/tbody/tr[1]/td[3]";
        public string LTL_QC_HazmatEnterdValue_Xpath = "//*[@id='GetRateFrieghtInfo']/tbody/tr[1]/td[4]";

        public string LTL_QC_GetAnotherQuote_Id = "Btn_GetAnotherQuote";

        public string LTL_QC_VerifyEmailConfirmationText_Xpath = "//*[@id='page-content-wrapper']/div[2]/div[9]/div[1]/p/b";
        public string LTL_QC_VerifyFileTypeMessage_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div[7]/div/p";

        public string LTL_QC_UploadShippingDocumentText_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div[7]/div/h2";
        public string LTL_QC_UploadShippingDocumentDropZoneSection_Xpath = "//*[@id='shipment-document-dropzone']";

        public string LTL_ConfirmationDropZone_Xpath = ".//*[@id='shipment-document-dropzone']";


        public string LTL_QC_shiptoserviceslabel = ".//*[@id='page-content-wrapper']/div[2]/div[5]/div[1]/div/div[2]/div[3]/div[2]/div/div[1]/div[1]/label";
        public string LTL_QC_shipfromserviceslabel = ".//*[@id='page-content-wrapper']/div[2]/div[5]/div[1]/div/div[2]/div[3]/div[2]/div/div[2]/div[1]/label";
        public string LTL_QC_shiptoservicesvalues = ".//*[@id='page-content-wrapper']/div[2]/div[5]/div[1]/div/div[2]/div[3]/div[2]/div/div[1]/div[2]";
        public string LTL_QC_shipfromservicesvalues = ".//*[@id='page-content-wrapper']/div[2]/div[5]/div[1]/div/div[2]/div[3]/div[2]/div/div[2]/div[2]";
        public string LTL_QC_sericesandaccessorials = ".//*[@id='page-content-wrapper']/div[2]/div[5]/div[1]/div/div[2]/div[3]/div[2]/h5";

        public string LTL_QC_QuoteAmountSection = ".//*[@id='page-content-wrapper']/div[2]/div[5]/div/div/div[2]/div[1]/div[2]/div";
        public string LTL_QC_QuoteAmount = ".//*[@id='page-content-wrapper']/div[2]/div[5]/div/div/div[2]/div[1]/div[2]/div/div/div[1]/label";
        public string LTL_QC_EstCost = ".//*[@id='page-content-wrapper']/div[2]/div[5]/div/div/div[2]/div[1]/div[2]/div/div/div[2]/label/span";
        public string LTL_QC_EstMargin = ".//*[@id='page-content-wrapper']/div[2]/div[5]/div/div/div[2]/div[1]/div[2]/div/div/div[3]/label/span";
        public string LTL_QC_FreightDimensions_Xpath = ".//*[@id='GetRateFrieghtInfo']//th[4]";
        public string LTL_QC_FreightDimensionValues_Xpath = "//*[@id='GetRateFrieghtInfo']//td[4]";

        //--------------------LTL Quote Confirmaion(QC) Page---------------

        //--------------------Create shipment page in shipment process


        //-------------------- DLS WorldWide LandingPage/HomePage -----------------------

        public string HomepageHeaderlogo_Xpath = "//img[@alt='DLS Worldwide']";
        public string DLSWorldwideimage_xpath = "//img[@alt='DLS Worldwide']";//"img.dls";
        public string DashboardHeaderlogo_Xpath = "//img[@alt='DLS Worldwide']";
        public string LogoAlignment_Center_css = ".center-align-image-legacy";
        public string LogoAlignment_Left_css = ".dls-container>img";
        public string NewSignIn_Id = "btn_signin";
        public string Logohastext_css = "img[alt=drp_VolumeCustomer]";
        public string Bodytext_xpath = "//div[@id='login-page']/div/div/div/div/p[4]";
        public string TruckImage_css = "img.img-responsive";
        public string TrackHeadingbyReferenceNo_xpath = "//div[@id='page-content-wrapper']/div[2]/div/div/h5";
        public string searchbox_id = "txtReferenceNumer";
        public string TrackParagraphbyReferenceNo_xpath = "//div[@id='page-content-wrapper']/div[2]/div/div/p";
        public string searchbtn_xpath = "//button[@type='button']";
        //public string Entertextspace_xpath = "";
        public string TrackHeadingbyfileupload_xpath = "//div[@id='page-content-wrapper']/div[2]/div/div[2]/h5";
        public string TrackParagraphbyfileupload_xpath = "//div[@id='page-content-wrapper']/div[2]/div/div[2]/p";
        public string DownloadTempalteBtn_id = "btnDownloadTemplate";
        public string UploadBtn_id = "btn-UploadDocument";
        public string HomepageFooterlogo_Xpath = "//div[@id='crmLoginPg']/footer/div/div/div/ul/li/a/img";
        public string Home_xpath = "//a[contains(text(),'Home')]";
        public string ContactUs_xpath = "//a[contains(text(),'Contact Us')]";
        public string PrivacyPolicy_xpath = "//a[contains(text(),'Privacy Policy')]";
        public string TemsofUse_xpath = "//a[contains(text(),'Terms of Use')]";
        public string RRDInfo_xpath = "//div[@id='crmLoginPg']/footer/div/div/div[2]/p";
        public string UserDropdown_id = "spn-username";//"loggedInUserName";
        public string HomepagelinkPartner_xpath = "//a[contains(text(),'Become a DLS Worldwide Partner today.')]";
        public string signuppagetitle_css = "h5";
        public string signuppagesubtitle_css = "div.col-md-12 > p";
        public string SubmitBtn_id = "Partner_Submit";
        public string HomepagelinkPartner_link = "Become a DLS Worldwide Partner today.";

        public string SubmitBtn_css = "";
        public string DashboardPageLogo = ".//*[@id='header']/div/div/div[1]/div/span/img[1]";

        public string TrackingsearchArrow_xpath = "//button[@class='btnReference btn btn-default btn-input-addon']";
        public string TrackingErrorheader_xpath = ".//*[@id='uploadErrModal']/div/div/div/div[1]/h3";
        public string TrackingErrormsg_xpath = ".//*[@id='uploadErrModal']/div/div/div/div[2]/h6";
        public string TrackingErrorpopupclose_xpath = ".//*[@id='uploadErrModal']/div/div/div/div[3]/a";
        public string Errorpopupheader_xpath = ".//*[@id='showModalScrollableCntBtn']/div/div/div/div[1]/h3";
        public string Errorpopupmsg_xpath = ".//*[@id='showModalScrollableCntBtn']/div/div/div/div[2]/h6";
        public string ErrorpopupClose_xpath = ".//*[@id='showModalScrollableCntBtn']/div/div/div/div[3]/a";
        public string TrackingPageHearder_xpath = ".//*[@id='page-content-wrapper']//h1";
        public string TrackingRefnogrid_xpath = ".//*[@id='TrackingDetailGrid']//th[1]";
        public string TrackingRefno_xpath = ".//*[@id='TrackingDetailGrid']/tbody/tr[@role = 'row']/td[1]";
        public string TrackingDetails_xpath = "//div[@class='btn tracking-details two-icon']";
        public string Trackingiconhomepage_xpath = "//a[@id='tracking']";
        public string Dashboard_home_xpath = "//a[@id='dashboard']";
        public string Quotes_home_xpath = "//a[@id='raterequest']";
        public string Shipment_home_xpath = "//a[@id='shipment']";
        public string DocumentRepo_home_xpath = "//a[@id='docRepo']";
        public string UserManagement_home_xpath = "//a[@id='usermanagement']";
        public string TrackUploadarehomepage_xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[2]";
        public string TrackingWarningheader_xpath = ".//*[@id='trackingDetailswarningModal']//div[1]/h3";
        public string TrackingWarningmsg_xpath = ".//*[@id='trackingDetailswarningModal']/div/div/div/div[2]/h6";
        public string TrackingWarningRefNo_xpath = ".//*[@id='trackingDetailswarningModal']//h6";
        public string TrackingWarningpopupClose_xpath = ".//*[@id='trackingDetailswarningModal']//div[3]/a";
        public string Trackingselectfile_xpath = ".//*[@id='modal_uploadDoc']/div/div/div/div[2]/div/div/div[1]/div[1]";
        //-------------------------- LandingPage: Tracking/Upload -------------------------------------------
        public string searchErrorpopup_xpath = "//div[@id='uploadErrModal']/div/div/div/div/h3";
        public string searchErrormessage_xpath = "//div[@id='uploadErrModal']/div/div/div/div[2]/h6";
        public string CloseBtnInSearchErrorpopup_xpath = "(//a[contains(text(),'Close')])[2]";
        public string TrackingResults_xpath = "";
        public string UploadShipmentpopupTitle_xpath = "//div[@id='modal_uploadDoc']/div/div/div/div/h3";
        public string UploadShipmentpopupSubTitle_xpath = "//div[@id='modal_uploadDoc']/div/div/div/div[2]/div/div/h6";
        public string SelectFileUploadpopup_xpath = "//div[@onclick='getFile();']";//".//*[@id='customer-logo-dropzone']/div/span/strong"; //"div.file-upload-btn";
        public string SelectFileUploadLocator_xpath = "//div[@id='customer-logo-dropzone']/div/span/strong";
        public string filesSelectionTxt_css = "div.file-upload-selection";
        public string CalcelBtnUploadpopup_id = "btnfileCancel";
        public string SubmitBtnUploadpopup_id = "upload-save";
        public string errormsginUploadpopup_id = "dv-file-message";
        public string Invalidpopuptitle_xpath = "//div[@id='uploadErrModal']/div/div/div/div/h3";
        public string InvalidpopupErrormessage_xpath = "//div[@id='uploadErrModal']/div/div/div/div[2]/h6";
        public string InvalidpopupClosebtn_xpath = "(//a[contains(text(),'Close')])[2]";

        //International Tile
        public string Quotesmenu_css = "i.icon.icon-quote";
        public string QuotespageHeading_css = "h1";
       // public string Quotespagesubheading_css = "div.page-title > p";
        public string QuotesPageSubheading_xpath = "//div[@class='center-dd-msg']/p[contains(text(),'Submitted rate requests within the past 30 days are shown')]";
        //public string QuotespageHeading_css = "h1";
       // public string QuotespageHeading_css = "h1.quotes-header";
        //public string Quotespagesubheading_css = "div.page-title > p";
        public string Quotespagesubheading_css = "p.Header-Sub-title";
        public string SubmitRateRequestBtn_id = "rate-list";
        public string GetQuotespagetext_css = "h1";
        public string GetQuoteBacktoQuoteListBtn_id = "Btn_BackQuoteList";
        public string InternationalTile_id = "btn_international";
        public string RateRequestHeading_css = "h1";
        public string Subheading_css = "div.page-title > p";
        public string ShipmentInformation_css = "h3";
        public string RateBacktoQuoteListBtn_id = "rate-back";
        public string RateServiceType_id = "h-mode";
        public string InternationalModel_xpath = ".//*[@id='rateInternationalContent']//h3[contains(text(),'International Type')]";
        public string InternationalTypedropdown_id = "station_id_chosen";
        public string InternationalTypedropdown_xpath = ".//*[@id='rate_international_type_chosen']//span[contains(text(),'Select Type...')]";
        public string TagNameforType_Dropdownoptions = "li";
        //public string TypeOption_xpath = "";
        public string InternationalLeveldropdown_id = "rate_international_level_chosen";
        public string InternationalLeveldropdown_xpath = "//div[@id='rate_international_level_chosen']/a/span";
        public string InternationalTypeDropDownValues_xpath = ".//*[@id='rate_international_type_chosen']//ul/li";
        public string InternationalLevelDropDownValues_xpath = ".//*[@id='rate_international_level_chosen']//ul/li";
        public string TagNameforLevel_Dropdownoptions = "li";
        //public string LevelOption_xpath = "";
        public string ContinueBtn_id = "btn_submit_rateInternational";
        public string CancelBtn_xpath = "(//a[contains(text(),'Close')])[2]";
        public string errormessage_css = "div.error-msg";
        public string hamburgermenuIcon_xpath = "//div[@id='iconSidebarNav']/a/div/i";
        public string IntermodelTile_id = "btn_intermodel";




        //-------------------TL,PTL,Intermodal,International ShipmentInformation Headername and service Bubble Stepwizard-------------

        public string ShipmentInformationText_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div[1]/div/div[1]/h1";
        public string ShipmentInformationTextUI_Xpath = ".//h3[contains(text(), 'Shipment Information')]";
        public string ServiceBubble_Xpath = ".//*[@id='Mode']/a[1]";

        public string ShipmentInforPageHeader_xpath = ".//*[@id='Truckload']/div[1]/h1";
        public string TL_RateRequestHeadingSubText = ".//*[@id='Truckload']/div[1]/p";
        public string PTL_RateRequestHeadingSubText = ".//*[@id='Partial Truckload']/div[1]/p";
        public string DomFor_RateRequestHeadingSubText = ".//*[@id='Domestic Forwarding']/div[1]/p";
        public string ShipmentInformationSectionHeader_xpath = ".//*[@id='main']/div[2]/div/h3";
        public string ServicenNameInShipmentInfo_xpath = ".//*[@id='h-mode']/span";





        //---------------------DomForwarding Shipment Location and Dates Page------------------------------

        public string ShipmentLocationAndDatesText_Xpath = ".//h3[contains(text(), 'Shipment Locations and Dates')]";
        public string ServiceNavigationBar_Xpath = ".//*[@id='Mode']/a/span[2]/label";
        // public string DomesticForwardingModalText_xpath = ".//*[@id='rateDomesticForwardingContent']/div/div/div/div[1]/h3"; ---> Incorrect xpath
        public string DomesticForwardingModalText_xpath = ".//*[@id='rateDomesticForwardingContent']/div/div/div/div[1]/div/h3";



        //----------------------------------Tracking Page----------------------------------------------------------------
        public string TrackByReferenceNumber_Textbox_Id = "txtReferenceNumer";
        public string TrackByReferenceNumber_SearchArrow_Xpath = ".//*[@id='trackSubmit']/div[1]/div/div/div/button";
        public string TrackingDescriptionText_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div[3]/div/div[1]/p";
        public string Tracking_Icon_Id = "tracking";
        public string TrackingPage_Header_xpath = ".//*[@id='page-content-wrapper']//h1";
        public string Export_Button_Id = "Btn_export";
        public string Export_All_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div[5]/div/div[2]/span/ul/li[1]/a";
        public string Export_Displayed_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div[5]/div/div[2]/span/ul/li[2]/a";
        public string Tracking_Datatable_Content_Xpath = ".//*[@id='TrackingDetailGrid']/tbody/tr[@role = 'row']/td[1]";
        public string Tracking_Datatable_Header_Xpath = ".//*[@id='TrackingDetailGrid']/thead/tr/th";
        public string TrackingPage_sebHeader_xpath = ".//*[@id='page-content-wrapper']/div[2]/div[3]/div/div[1]/p";
        public string Tracking_MoreInfo_icon_xpath = ".//*[@id='TrackingDetailGrid']/tbody/tr[1]/td[8]/button";


        public string SearchtextboxTrack_id = "txtReferenceNumer";
        public string searchbuttonTrackingLandingpage_xpath = "(//button[@type='button'])[2]";
        public string TrackingPage_UploadTemplate_id = "btn_UploadDocument";
        public string TrackingPage_ReferenceNumSearchArrow_xpath = ".//button[@class='btn-icon btn-default btnReference colored btn colored btn-input-addon']";
        public string TrackingPage_Text_aboveReferenceSearch_xpath = ".//*[@id='page-content-wrapper']//p[contains(text(), 'Perform an additional')]";
        public string TrackingPage_FilterResultsGridHighlighted_classname = "highlight";
        public string TrackingPage_RefColumn_Highlighted_Xpath = ".//*[@id='TrackingDetailGrid']//span[1][@class='highlight']";
        public string TrackingPage_FilterResults_Xpath = ".//*[@id='Txt_TrackDtSearch']";
        public string TrackingPage_FilterResultsPlaced_Xpath = ".//*[@class='dv_FilterShipment']/div[1]";

        //----------------------------------TrackingDetailsPage----------------------------------------------------------------------------------
        public string SearchShipment_Textbox_Id = "Txt_TrackDtSearch";
        public string SearchShipment_Arrow_Id = "Btn_SearchFilter";
        public string ReferenceNumber_CheckBox_Xpath = "//*[@id='table-search']/div[2]/div[1]/div[1]/div[1]/input";
        public string Status_CheckBox_Xpath = ".//*[@id='table-search']/div[2]/div[1]/div[1]/div[2]/input";
        public string ETA_CheckBox_Xpath = "//*[@id='table-search']/div[2]/div[1]/div[1]/div[3]/input";
        public string LocationCheckbox_Xpath = "//*[@id='table-search']/div[2]/div[1]/div[1]/div[4]/input";
        public string Service_CheckBox_Xpath = "//*[@id='table-search']/div[2]/div[1]/div[1]/div[5]/input";
        public string Origin_CheckBox_Xpath = "//*[@id='table-search']/div[2]/div[1]/div[2]/div[1]/input";
        public string Destination_CheckBox_Xpath = "//*[@id='table-search']/div[2]/div[1]/div[2]/div[2]/input";
        public string Carrier_CheckBox_Xpath = "//*[@id='table-search']/div[2]/div[1]/div[2]/div[3]/input";
        public string ScheduledPickUp_CheckBox_Xpath = "//*[@id='table-search']/div[2]/div[1]/div[2]/div[4]/input";
        public string ScheduledDelivery_CheckBox_Xpath = "//*[@id='table-search']/div[2]/div[1]/div[2]/div[5]/input";
        public string ClearAll_Button_Xpath = ".//button[contains(text(), 'Clear All')]";
        public string SelectAll_Button_Xpath = ".//button[contains(text(), 'Select All')]";

        public string ReferenceNumber_CheckBoxText_Xpath = "//*[@id='table-search']/div[2]/div[1]/div[1]/div[1]/label";
        public string Status_CheckBoxText_Xpath = "//*[@id='table-search']/div[2]/div[1]/div[1]/div[2]/label";
        public string ETA_CheckBoxText_Xpath = "//*[@id='table-search']/div[2]/div[1]/div[1]/div[3]/label";
        public string LocationCheckboxText_Xpath = "//*[@id='table-search']/div[2]/div[1]/div[1]/div[4]/label";
        public string Service_CheckBoxText_Xpath = "//*[@id='table-search']/div[2]/div[1]/div[1]/div[5]/label";
        public string Origin_CheckBoxText_Xpath = ".//*[@id='table-search']/div[2]/div[1]/div[2]/div[1]/label";
        public string Destination_CheckBoxText_Xpath = ".//*[@id='table-search']/div[2]/div[1]/div[2]/div[2]/label";
        public string Carrier_CheckBoxText_Xpath = ".//*[@id='table-search']/div[2]/div[1]/div[2]/div[3]/label";
        public string ScheduledPickUp_CheckBoxText_Xpath = ".//*[@id='table-search']/div[2]/div[1]/div[2]/div[4]/label";
        public string ScheduledDelivery_CheckBoxText_Xpath = ".//*[@id='table-search']/div[2]/div[1]/div[2]/div[5]/label";

        public string ShowingResultsNavigator_LeftArrow_Xpath = ".//*[@id='TrackingDetailGrid_wrapper']/div[2]/div[1]/ul/li[1]/a/i";
        public string ShowingResultsNavigator_RightArrow_Xpath = ".//*[@id='TrackingDetailGrid_wrapper']/div[2]/div[1]/ul/li[2]/a/i";
        public string NewSearch_Button_Id = "btn_NewSearch";
        public string FilterBy_Text_Xpath = ".//span[contains(text(), 'Filter By :')]";
        public string ScheduledToDeliver_Text_Xpath = ".//span[contains(text(), 'Scheduled to Deliver')]";
        public string Between_Text_Xpath = ".//span[contains(text(), 'Between :')]";
        public string StartDate_Text_Id = "TrackDtlStartDate";
        public string EndDate_Text_Id = "TrackDtlEndDate";
        public string And_Text_Xpath = ".//span[contains(text(), 'AND :')]";
        public string FilterByStatus_Text_Xpath = ".//span[contains(text(), 'Filter By Status:')]";
        public string OneTime_Text_Xpath = "//*[@id='page-content-wrapper']/div[2]/div[6]/div/div/div[2]/div/div/div[1]/label";
        public string ExceptionsDelays_Text_Xpath = "//*[@id='page-content-wrapper']/div[2]/div[6]/div/div/div[2]/div/div/div[2]/label";
        public string Ref_Text_Xpath = ".//*[@id='TrackingDetailGrid']/thead/tr/th[1]";
        public string Status_Text_Xpath = ".//*[@id='TrackingDetailGrid']/thead/tr/th[2]";
        public string ETA_Text_Xpath = ".//*[@id='TrackingDetailGrid']/thead/tr/th[3]";
        public string Location_Text_Xpath = ".//*[@id='TrackingDetailGrid']/thead/tr/th[4]";
        public string Origin_Text_Xpath = ".//*[@id='TrackingDetailGrid']/thead/tr/th[5]";
        public string Destination_Text_Xpath = ".//*[@id='TrackingDetailGrid']/thead/tr/th[6]";
        public string Service_Text_Xpath = ".//*[@id='TrackingDetailGrid']/thead/tr/th[7]";
        public string IndividualTrackingDetailsExpandable_Arrow_Xpath = ".//*[@id='TrackingDetailGrid']/tbody/tr[1]/td[8]";
        public string IndividualTrackingDetailsExpandableMobile_Arrow_Xpath = ".//*[@id='TrackingDetailGrid']/tbody/tr[1]/td[3]";
        public string MoreInformationIcon_Xpath = ".//*[@id='TrackingDetailGrid']/tbody/tr[1]/td[8]/button";
        public string PrintIcon_Xpath = ".//*[@id='TrackingDetailGrid']/tbody/tr[2]/td/div/div[2]/div[1]/div[1]/div/div[2]/ul/li[1]/button";
        public string TrackingDetailsSection_ExportIcon_Xpath = ".//*[@id='TrackingDetailGrid']/tbody/tr[2]/td/div/div[2]/div[1]/div[1]/div/div[2]/ul/li[2]";
        public string TrackingDetailsSectionDate_Xpath = ".//*[@id='TrackingDetailGrid']/tbody/tr[2]/td/div/div[2]/div[1]/div[2]/div/div/table/thead/tr/th[1]";
        public string TrackingDetailsSection_Details_Xpath = ".//*[@id='TrackingDetailGrid']/tbody/tr[2]/td/div/div[2]/div[1]/div[2]/div/div/table/thead/tr/th[2]";
        public string TrackingDetailsSection_Location_Xpath = ".//*[@id='TrackingDetailGrid']/tbody/tr[2]/td/div/div[2]/div[1]/div[2]/div/div/table/thead/tr/th[3]";
        public string Map_Text_Xpath = ".//h3[contains(text(), 'Map')]";
        public string TrackingDetail_Text_Xpath = ".//h3[contains(text(), 'Tracking Detail')]";
        public string MapSection_Id = "Desktopmapid1";
        public string RefNumberGridValues_Xpath = "//*[@id='TrackingDetailGrid']/tbody/tr/td[1]";
        public string StatusGridValues_Xpath = "//*[@id='TrackingDetailGrid']/tbody/tr/td[2]";
        public string TrackByReference_textbox_Id = "txtReferenceNumer";
        public string TrackByReference_Arrow_Xpath = ".//*[@id='trackSubmit']//button";
        public string login_trackingtext_Xpath = ".//h5[contains(text(), 'Track Up To 10 Shipments by Reference Number')]";
        public string TrackingDetailsOptionsMobile_Xpath = ".//*[@id='TrackingDetailGrid']/tbody/tr/td[3]";


        public string TrackingDetailsOptions_Xpath = ".//*[@id='TrackingDetailGrid']/tbody/tr/td[9]";
        public string trackingInformationIcon_Xpath = "//*[@id='TrackingDetailGrid']/tbody/tr[1]/td[8]/button";
        public string TrckingInformaion_Pro_Number_Xpath = "//*[@id='TrackingDetailGrid']/tbody/tr[1]/td[8]/div/table/tbody/tr[1]/td[1]/span";
        public string TrckingInformaion_PO_Xpath = "//*[@id='TrackingDetailGrid']/tbody/tr[1]/td[8]/div/table/tbody/tr[2]/td[1]/span"; 
        public string TrckingInformaion_Ship_Reference_Xpath = "//*[@id='TrackingDetailGrid']/tbody/tr[1]/td[8]/div/table/tbody/tr[3]/td[1]/span";
        public string TrckingInformaion_Scheduled_Pickup_Xpath = "//*[@id='TrackingDetailGrid']/tbody/tr[1]/td[8]/div/table/tbody/tr[4]/td[1]/span";
        public string TrckingInformaion_Scheduled_Delivery_Xpath = "//*[@id='TrackingDetailGrid']/tbody/tr[1]/td[8]/div/table/tbody/tr[5]/td[1]/span";
        public string TrckingInformaion_Quantity_Xpath = "//*[@id='TrackingDetailGrid']/tbody/tr[1]/td[8]/div/table/tbody/tr[6]/td[1]/span";
        public string TrckingInformaion_Weight_Xpath = "//*[@id='TrackingDetailGrid']/tbody/tr[1]/td[8]/div/table/tbody/tr[7]/td[1]/span";
        public string TrckingInformaion_Carrier_Xpath = "//*[@id='TrackingDetailGrid']/tbody/tr[1]/td[8]/div/table/tbody/tr[8]/td[1]/span";

        public string Tracking_MapHeader_Xpath = ".//*[@id='TrackingDetailGrid']/tbody/tr[2]/td/div/div[1]/div/div[1]/div/div/h3";
        public string Tracking_TrackingDetailsHeader_Xpath = "//*[@id='TrackingDetailGrid']/tbody/tr[2]/td/div/div[2]/div/div[1]/div/div[1]/h3";
        public string Trackiing_RightNavigationButton_Xpath = "//*[@id='TrackingDetailGrid_next']/a/i";
        public string Trackiing_LeftNavigationButton_Xpath = "//*[@id='TrackingDetailGrid_previous']/a/i";
        public string Tracking_Datatable_Values_Xpath = "//*[@id='TrackingDetailGrid']/tbody/tr/td";

        public string DEtails_downArrow_Xpath = "//*[@id='TrackingDetailGrid']/tbody/tr[1]/td[9]";
        public string TrackingExportLink_Xpath = "//*[@id='TrackingDetailGrid']/tbody/tr[2]/td/div/div[2]/div/div[1]/div/div[2]/ul/li[2]/button";
        public string TrackingPrintButton_Xpath = ".//*[@id='TrackingDetailGrid']/tbody/tr[2]/td/div/div[2]/div/div[1]/div/div[2]/ul/li[1]/button";
        public string TrackingDateHeader_Xpath = "//*[@id='TrackingDetailGrid']/tbody/tr[2]/td/div/div[2]/div/div[2]/div/div/table/thead/tr/th[1]";
        public string TrackingDetailsHeader_Xpath = "//*[@id='TrackingDetailGrid']/tbody/tr[2]/td/div/div[2]/div/div[2]/div/div/table/thead/tr/th[2]";
        public string TrackingLocationHeader_Xpath = "//*[@id='TrackingDetailGrid']/tbody/tr[2]/td/div/div[2]/div/div[2]/div/div/table/thead/tr/th[3]";
        public string Tracking_NoResultsFound = "//*[@id='TrackingDetailGrid']/tbody/tr/td";


        public string Griddaterange_Xpath = ".//*[@id='TrackingDetailGrid']/tbody/tr/td[3]";
        public string SelectedstartDate_Xpath = ".//*[@id='TrackDtlStartDate']";
        public string SelectedEndDate_Xpath = ".//*[@id='TrackDtlEndDate']";
        public string Grid_EtaDate_Xpath = ".//*[@id='TrackingDetailGrid']/tbody/tr/td[3]";
        public string FilterArrow_Xpath = ".//*[@id='drp_FilterSc_chosen']/a/span";
        //----------------------------------TrackingDetailsPage----------------------------------------------------------------------------------

        //---------test tracking---------------
        public string trackingicon = ".//*[@id='tracking']/i";
        public string trackingheader = ".//*[@id='page-content-wrapper']/div[2]/div[1]/div/div/h1";
        public string trackinguploadsectionheader = ".//*[@id='page-content-wrapper']/div[2]/div[2]/div[2]/div/div[1]/h4";
        public string trackinguploadsubheader = ".//*[@id='page-content-wrapper']/div[2]/div[3]/div[2]/div/div[2]/div/div/p";
        public string trackinguploadarea = ".//*[@id='page-content-wrapper']/div[2]/div[3]/div[2]/div/div[2]";
        public string trackingdownloadbutton = ".//*[@id='btnDownloadTemplate']";
        public string trackinguploadbutton = ".//*[@id='btn-UploadDocument']";
        public string trackingselectfile = ".//*[@id='modal_uploadDoc']//div[1][@class='file-upload-btn']";
        public string trackinguploadedfilename = ".//*[@id='modal_uploadDoc']/div/div/div/div[2]/div/div/div[1]/div[2]";
        public string trackingsubmitbutton = ".//*[@id='upload-save']";
        public string trackingcancelbutton = ".//*[@id='btnfileCancel']";
        public string trackinguploadmodal = ".//*[@id='modal_uploadDoc']/div/div/div";
        public string trackinguploadmodalheader = ".//*[@id='modal_uploadDoc']//h3";
        public string trackinguploadmodalsubheader = ".//*[@id='modal_uploadDoc']//h6";
        public string trackinguploadmodalnofilelabel = ".//*[@id='modal_uploadDoc']/div/div/div/div[2]/div/div/div[1]/div[2]";
        public string trackingselectfilerrorpoup = ".//*[@id='trackingDetailsErrModal']/div/div/div";
        public string trackingselectfilerrormessage = ".//*[@id='dv-file-message']";
        public string trackingwarningpopupforinvalid = ".//*[@id='trackingDetailswarningModal']/div/div/div";
        public string trackingwarningmessageforinvalid = ".//*[@id='trackingDetailswarningModal']//h6";
        public string trackingwarningpopupclosebutton = ".//*[@id='trackingDetailswarningModal']/div/div/div/div[3]/a";
        public string trackinginvalidextension = ".//*[@id='trackingDetailsErrModal']/div/div/div";
        public string trackingpopupforemptyfile = ".//*[@id='trackingDetailsErrModal']/div/div/div/div[2]/h6";
        public string trackingerrormessageforemptyfile = ".//*[@id='trackingDetailsErrModal']/div/div/div/div[2]/h6";
        public string trackingerrormodalclosebuttonforemptyfile = ".//*[@id='trackingDetailsErrModal']/div/div/div/div[3]/a";
        public string trackingerrormessageformaxnumber = ".//*[@id='trackingDetailsErrModal']/div/div/div/div[2]/h6";
        public string trackingrefernceresults = ".//*[@id='TrackingDetailGrid']/tbody/tr/td[1]";
        //public string trackingrefernceresults = ".//*[@id='TrackingDetailGrid']/tbody/tr[@role = 'row']/td[1]";
        public string trackingerrorforinavlidname = ".//*[@id='trackingDetailsErrModal']/div/div/div/div[2]/h6";
        public string trackingerrorforallinvalid = ".//*[@id='trackingDetailsErrModal']/div/div/div/div[2]/h6";
        public string trackingerrormessageforcombination = ".//*[@id='trackingDetailswarningModal']/div/div/div/div[2]/h6/br[1]";
        public string trackingerrormessageforcombination1 = ".//*[@id='trackingDetailswarningModal']/div/div/div/div[2]/h6/br[2]";
        public string trackingerrormessageforcombinationclose = ".//*[@id='trackingDetailswarningModal']/div/div/div/div[3]/a";
        public string trackingresultslistforinvalid = ".//*[@id='trackingDetailswarningModal']//h6";
        public string trackingErrorPopUpHeader_Xpath = ".//*[@id='trackingDetailsErrModal']//h3";


        //public string trackinguploadmodal = ".//*[@id='upload']";


        //--------------------------------------- Tracking Landing Page --------------------------------------------------
        public string TrackingLandingpageTitle_css = "h1";
        public string TrackingpageLandingTitleDescription_css = "p";
        public string TrackbyReferenceheading_xpath = "//div[@id='page-content-wrapper']/div[2]/div[3]/div/div/div/h4";
        public string ReferenceNumbersDescription_css = "div.panel-body.track-height > div.row > div.col-md-12 > p";
        public string Searchtextbox_id = "txtReferenceNumer";
        public string searchbtnTrackingLandingpage_xpath = "(//button[@type='button'])[2]";
        public string DownloadinTrackingBtn_id = "btnDownloadTemplate";
        public string UploadinTrackingBtn_xpath = "//button[@id='btn-UploadDocument']";
        public string FileUploadHeading_xpath = "//div[@id='page-content-wrapper']/div[2]/div[3]/div[2]/div/div/h4";
        public string ShipmentsDescription_xpath = "//div[@id='page-content-wrapper']/div[2]/div[3]/div[2]/div/div[2]/div/div/p";
        public string NoreferenceErrorpopup_css = "h3";
        public string NoreferenceErrormessage_css = "h6";
        public string CloseBtnInNoreferenceErrorpopup_xpath = "//a[contains(text(),'Close')]";
        //public string ToogleDetailicon_xpath = ".//*[@id='TrackingDetailGrid']//tr[@role='row']//td[@class='control all Initialised Opened']";
        public string TrackingDetailsHeaderforSinglerefNo_xpath = ".//*[@id='TrackingDetailGrid']//h3[text()='Tracking Details']";
        public string TrackingDetailsHeaderforSingleRefNo_xpath = ".//*[@id='TrackingDetailGrid']/tbody/tr[2]/td/div/div[2]/div/div[1]/div/div[1]/h3";
        public string REF_xpath = "//table[@id='TrackingDetailGrid']/thead/tr/th[text()='REF #']";
        public string STATUS_xpath = ".//*[@id='TrackingDetailGrid']/thead/tr/th[text()='Status']";
        public string ETA_xpath = "//table[@id='TrackingDetailGrid']/thead/tr/th[text()='ETA']";
        public string LOCATION_xpath = ".//*[@id='TrackingDetailGrid']/thead/tr/th[text()='Location']";
        public string ORIGIN_xpath = "//table[@id='TrackingDetailGrid']/thead/tr/th[text()='Origin']";
        public string DESTINATION_xpath = "//table[@id='TrackingDetailGrid']/thead/tr/th[text()='Destination']";
        public string SERVICE_xpath = "//table[@id='TrackingDetailGrid']/thead/tr/th[text()='Service']";
        public string ReferencenumberUnderREF_xpath = "//td[@class='all sorting_1']";
        public string DefaultMap_xpath = ".//*[@id='TrackingDetailGrid']//h3[text()='Map']";
        public string Map_xpath = ".//*[@id='TrackingDetailGrid']/tbody/tr[2]/td/div/div[1]/div/div[1]/div/div/h3";
        public string TrackingDetailsPageHeader_css = "h1";
        public string TrackingDetailspageSubtitle_css = "p.hidden-xs.hidden-sm";
        public string NewSearchBtn_id = "btn_NewSearch";
        public string SearchShipmentsBtn_id = "Txt_TrackDtSearch";
        public string ExportBtn_id = "Btn_export";
        public string FilterbyTime_css = "div.dv_FilterWithDates";
        public string FilterbyStatus_css = "div.dv_FilterbyStatus";
        public string PaginationHeader_css = "div.table-header-row";
        public string PaginationFooter_css = "div.table-footer-row";
        public string Referencenumbers_xpath = ".//*[@id='TrackingDetailGrid']//tr[@role='row']//td[@class='all sorting_1']";
        public string warningmessagemorethanTenRefNum_css = "";
        public string TrackingpagesearchErrorpopup_xpath = "";
        public string TrackingpagesearchErrormessage_xpath = "";
        public string TackinpageCloseBtnInSearchErrorpopup_xpath = "";
        public string errormessagemultiInvalidRefNumError_css = "#trackingDetailsErrModal > div.vertical-alignment-helper > div.modal-dialog.vertical-align-center > div.modal-content > div.modal-header > h3";
        public string errormessagemultiInvalidRefNum_css = "#trackingDetailsErrModal > div.vertical-alignment-helper > div.modal-dialog.vertical-align-center > div.modal-content > div.modal-body > h6";
        public string errormessagemultiInvalidRefNumClose_xpath = "(//a[contains(text(),'Close')])[3]";
        public string warningmsgmultiInvalidRefNumClose_xpath = "//a[contains(text(),'Close')]";
        public string warningmsgmultiInvalidRefNum_css = "h6";
        public string warningmsgmultiInvalidRefNumError_css = "div.modal-header > h3";
        public string InfoicontrackingDetails_xpath = "//table[@id='TrackingDetailGrid']/tbody/tr/td[8]/button";
        public string ToogleExpandicon_xpath = "//table[@id='TrackingDetailGrid']/tbody/tr/td[9]";
        public string ToogleExpandiconMobile_xpath = "//table[@id='TrackingDetailGrid']/tbody/tr/td[3]";

        //--------------------------Session timeout----------------------
        public string SessionTimeOutWarningPopUp_Xpath = ".//*[@id='warning-popup']/div/div/div/div[1]/h5";
        public string SessionTimeOutPopUp_Xpath = "";
        public string SessionTimeoutPopUp_Nobutton_Xpath = "//*[@id='warning-popup']/div/div/div/div[3]/a[1]";
        public string SessionTimeoutPopUp_Yesbutton_Xpath = "//*[@id='btn-logout-warning']";
        public string SessionTimeoutPopUp_WarningText_Xpath = "";
        public string SessionExpireDueToInactivity_Text_Xpath = "//*[@id='warning-popup']/div/div/div/div[2]/p[1]";
        public string AreYouSureWantToExit_Text_Xpath = "//*[@id='warning-popup']/div/div/div/div[2]/p[2]";

        public string SessionTimeOutLogoutPopUp_Xpath = ".//*[@id='logout-popup']/div/div/div/div[1]/h5";
        public string SessionTimeOutLogoutPopUpText_Xpath = "//*[@id='logout-popup']/div/div/div/div[2]/p ";
        public string SessionTimeOutLogoutPopUpOKbutton_id = "btn-logout";
        public string SessionTimeOutYesIDPbutton_Xpath = "//fieldset/div/button";

        //-------------------------Maintance tools-Prodcuct Protection Functionality(PPF)-------------------------------------------------
        public string MaintenanceModule_id = "maintenanceTools";
        public string PPFTabMaintenanceOption_id = "btn-ins-allrisk";
        public string AllRisk_PPFTabHeader_Xpath = "//*[@id='page-content-wrapper']/div[2]/div[2]/div/div/div[1]/h1";//not working
        public string PPFTabText_Xpath = "//*[@id='item_1']/a";
        public string PPFTab_Xpath = "//div[4]/section/div[5]/ul/li[2]/a";
        public string PPFTabPPText_Xpath = "//*[@id='page-content-wrapper']/div[2]/div[4]/div/div[1]/h4";
        public string PPFTabStation_Xpath = "//*[@id='StationName_chosen']/a";
        public string PPFTabStationList_Xpath = "//*[@id='StationName_chosen']/div/ul/li";
        public string PPFTabStationLSearchBox_Xpath = "//*[@id='StationName_chosen']/div/div/input";
        public string PPFTabStationLSearchSelect_Xpath = "//*[@id='StationName_chosen']/div/ul/li";
        public string PPFTtabCutomerAccount_Xpath = "//*[@id='CustomerNames_chosen']/ul/li";
        public string PPFTtabCutomerAccountList_Xpath = "//*[@id='CustomerNames_chosen']/div/ul/li";
        public string PPFTtabSaveButton_Id = "btnsave";
        public string CustomerWithProductProtectionText = ".//*[@class='h1_panel']/h1";
        public string PPFGridCustomerNAmecolumn = "//*[@id='ShipmentService']/thead/tr/th[1]";
        public string PPFGridStationIdcolumn = "//*[@id='ShipmentService']/thead/tr/th[2]";
        public string PPFGridStationNAmecolumn = "//*[@id='ShipmentService']/thead/tr/th[3]";
        public string PPFGridDateAssignedcolumn = "//*[@id='ShipmentService']/thead/tr/th[4]";
        public string PPFGridErrorMessage = ".//*[@id='page-content-wrapper']/div[2]/div[4]/div/div[2]/span/p";


        public string PPAllCustomerName_Xpath = "//*[@id='ShipmentService']/tbody/tr/td[1]";
        public string PPFGridView_Xpath = ".//*[@id='ShipmentService_length']/label/select";
        public string PPFGridViewList_Xpath = ".//*[@id='ShipmentService_length']/label/select/option";
        public string PPFGridViewCustomerName_Xpath = "//*[@id='ShipmentService']/tbody/tr/td[1]";
        public string OkButton_DeletePopUp_Xpath = ".//button[contains(text(), 'Ok')]";



        public string PPTabsection_Xpath = "html/body/div[4]/section/div[5]/ul/li[2]/a";
        public string DeleteButtuon1_GridList_Xpath = ".//*[@id='ShipmentService']/tbody/tr[1]/td[5]/button";
        public string StationDropdown_CSS = "a.chosen-single.chosen-default";
        public string StationDropdown_values_Xpath = ".//*[@id='StationName_chosen']/div/ul/li";
        public string searchinput_Xpath = ".//*[@id='CustomerNames_chosen']/ul/li/input";
        public string PPCustomer_SaveButton_Id = "btnsave";
        public string searchIput1stselect_Xpath = ".//*[@id='CustomerNames_chosen']/div/ul/li";
        public string CancelButton_DeletePopUp_Xpath = ".//button[contains(text(), 'Cancel')]";
        public string DeleteConfirmationText_Xpath = "html/body/div[8]/div/div/div[1]";
        public string CustomerName1_GridList_Xpath = ".//*[@id='ShipmentService']/tbody/tr/td[1]";
        public string StationName1_GridList_Xpath = ".//*[@id='ShipmentService']/tbody/tr/td[3]";
        public string CustomerAccount_SearchBox_Xpath = ".//*[@id='CustomerNames_chosen']/ul/li";
        public string smallAc_Xpath = ".//*[@id='CustomerNames_chosen']/ul/li[1]";
        public string CustomerAccountList_SearchBox_Xpath = ".//*[@id='CustomerNames_chosen']/div/ul/li";
        public string PPExportButton_Text_Xpath = ".//*[@id='Custom_1']";
        public string AllDeleteButton_Grid_Xpath = ".//*[@id='ShipmentService']/tbody/tr/td[5]/button";

        public string PPF_CustId = "CustomerNames_chosen";
        public string PPF_CustDropdownList_Xpath = ".//*[@id='CustomerNames_chosen']/div/ul";
        public string PPF_SaveBtn_id = "btnsave";

        public string Pricing_Module_Id = "pricing";

        //------------------------------ Master Carrier Rate Settings Page -------------------------------
        public string MasterCarrier_CustomerDropdown_Xpath = "//*[@id='CategoryType_chosen']";
        public string MasterCarrier_CustomerDropdown_Input_Xpath = "//*[@id='CategoryType_chosen']/div/div/input";
        public string MasterCarrier_CustomerDropdown_FirstItem_Xpath = "//*[@id='CategoryType_chosen']/div/ul/li[2]";
        public string MasterCarrier_CarrierList_CarrierABFL_CheckBox_Xpath = "//*[@id='ABFL']/td[1]/div/label";
        public string MasterCarrier_SetAccessorial_AccessorialDropdown_Xpath = "//*[@id='Accessorial_type_0_chosen']/a";
        public string MasterCarrier_SetAccessorial_AccessorialItems_Xpath = "//*[@id='Accessorial_type_0_chosen']/div";
        public string MasterCarrier_SetAccessorial_GainshareTypeDropdown_Xpath = "//*[@id='Gainshare_type_0_chosen']";
        public string MasterCarrier_SetAccessorial_GainshareTypeItems_Xpath = "//*[@id='Gainshare_type_0_chosen']/div";


        //------------------------------ Customer Specific Branding Page ---------------------------------
        public string CustomerBrandingButton_id = "customer-specific";
        public string CustomerBrandingButtonDescription_xpath = "html/body/div[4]/section/div[5]/div[8]/div/p";
        public string addCustomerSpecificLogoExpandIcon_xpath = ".//*[@id='add_customer_specific_logo']/div/div";
        public string CustBrandingpageTitle_css = "h1";
        public string CustBrandingpageSubTitle_xpath = "//div/p";
        public string BacktoMaintenanceBtn_id = "btn_BackMaintananceTool";
        public string MaintenancePageTitle_xpath = "html/body/div[4]/section/div[5]/div[1]/div/div[1]/h1";
        public string BrandingGridView_Xpath = "//div[@id='dt_CustomerLogoGrid_length']/label";
        public string BrandingGridViewList_Xpath = ".//*[@id='dt_CustomerLogoGrid_length']/label/select/option[5]";//*[@id='dt_CustomerLogoGrid_length']/label/select/option";
        public string BrandingGridViewDD_id = "dt_CustomerLogoGrid_length";
        public string SaveBtn_id = "save_logo";
        public string StationLbl_xpath = ".//*[@id='collapseOne']/div/div[1]/div[1]/div/label";
        public string Selectstation_link = "Select station...";
        public string CustomerLbl_xpath = ".//*[@id='collapseOne']/div/div[1]/div[2]/div/label";
        public string Selectcustomer_link = "Select customer...";
        public string AddLogoFileLbl_xpath = "//div[@id='collapseOne']/div/div[2]/div/label";
        public string browse_xpath = "//div[@id='customer-logo-dropzone']/div/span/strong";
        public string customerlogodropzone_id = "customer-logo-dropzone";
        public string Filesizeinfo_xpath = "//div[@id='collapseOne']/div/div[2]/div[2]/p";
        public string CustomerSpecificLogosLbl_xpath = ".//*[@id='page-content-wrapper']/div[2]/div[3]/div/div/h3";
        public string View_xpath = "//div[@id='dt_CustomerLogoGrid_length']/label";
        public string StationDD_xpath = "//table[@id='dt_CustomerLogoGrid']/thead/tr/th";
        public string CustomernameDD_xpath = "//table[@id='dt_CustomerLogoGrid']/thead/tr/th[2]";
        public string LogoFile_xpath = "//table[@id='dt_CustomerLogoGrid']/thead/tr/th[3]";
        public string ToggleBtn_xpath = ".//*[@id='dt_CustomerLogoGrid']/tbody/tr[1]/td[4]/div";
        public string DeleteBtn_xpath = ".//*[@id='dt_CustomerLogoGrid']/tbody/tr[1]/td[4]/button";
        public string BrandingStationdropdown_id = "station_id_chosen";
        public string SelectStationSearchbox_xpath = ".//*[@id='station_id_chosen']/div/div/input";
        public string StationNameOption_xpath = ".//*[@id='station_id_chosen']/div/ul/li";
        public string CustomerNameOption_xpath = ".//*[@id='customer_id_chosen']/div/ul/li[1]";
        public string TagNameforStation_Dropdownoptions = "li";
        public string BrandingCustomerropdown_id = "customer_id_chosen";
        public string TagNameforCustomer_Dropdownoptions = "li";
        public string logofilenameinList_xpath = "//table[@id='dt_CustomerLogoGrid']/tbody/tr/td[3]";
        public string OnButtonInToggle_xpath = "//table[@id='dt_CustomerLogoGrid']/tbody/tr/td[4]/div/label";
        public string OffButtonInToggle_xpath = "//table[@id='dt_CustomerLogoGrid']/tbody/tr/td[4]/div/label[2]";
        public string addCustomerSpecific_Warningerrormsg_xpath = ".//*[@id='warning-error-msg']";
        public string addCustomerSpecific_LimitWarningerrormsg_xpath = "//*[@id='collapseOne']/div/div[2]/div[1]/div/div[3]/div/ul/li";
        public string addCustomerSpecific_WrongFormatimgerrormsg_xpath = "//*[@id='collapseOne']/div/div[2]/div[1]/div/div[3]/div/ul/li";
        public string deleteConfirm_YesBtn_xpath = ".//*[@id='cus-delete-yes']";
        public string deleteDeny_NoBtn_xpath = ".//*[@id='modal_delete']/div/div/div/div[2]/div/div[2]/a";
        public string deleteConfirmationPopUpMsg_xpath = ".//*[@id='modal_delete']/div/div/div/div[1]/p";
        public string addLogofile_browse_uploading_xpath = ".//*[@id='collapseOne']/div/div[2]/div[1]/div/div[2]/li/div/div[1]/a";
        public string logoFileList_xpath = ".//*[@id='dt_CustomerLogoGrid']/tbody/tr/td[3]";
        public string Logo_Confirmation_YesButton_id = "cus-save-yes";
        public string Logo_Confirmation_NoButton_Xpath = ".//*[@id='modal_save']/div/div/div/div[2]/div/div[2]/a";
        public string Popup_Window_Confirmation_Xpath = ".//*[@id='modal_save']/div/div/div/div[1]/h3";
        public string Popup_Window_Confirmation_Text_xpath = ".//*[@id='modal_save']/div/div/div/div[1]/p";
        public string LogoFileUploadCustomerBranding_Xpath = ".//*[@id='customer-logo-dropzone']/div/span/strong";

        //------------------------------------- MVC5 Dashboard Landing Page ----------------------------------------
        public string PendingCSRSectionHeader_xpath = "//div[@id='accordion']/div/div/h4";
        public string StationSummerySectionHeader_xpath = "//div[@id='page-content-wrapper']/div[2]/div[3]/div/div/div/h4";
        public string ReportsStationMonthlyBreakdown_xpath = ".//*[@id='reports']/div/div";
        public string ViewAccountMetricsBtn_xpath = "//a[contains(text(),'View Account Metrics')]";

        //---------------------------------------CSR List--------------------------

        public string CSRlistHeader_Xpath = "//div[@id='body']/section/div[3]/div[1]/h1";
        public string CSRlist_ViewDropdown_Xpath = "//div[@id='csr-list-pager_top']/span[1]/span";
        public string CSRlist_ViewDropdownOptions_Xpath = "//ul[@id='csr-list-count_listbox']/li";
        public string CSRlist_StatusColumnData_Xpath = "";

        //-----------------------------------------Revamp shipment Information for LTL -----------------------------------
        public string LTLTile_id = "btn_ltl";
        public string GetQuoteLTL_id = "warning-orange";
        public string LTLpagetitle_xpath = ".//*[@id='page-content-wrapper']//h1";
        public string ShippingFromText_xpath = "//div[@id='scrollable-dropdown-menu-Origin']/div/h3";
        public string ShippingToText_xpath = "//div[@id='scrollable-dropdown-menu-Destination']/div/h3";
        public string SearchboxforOrigin_id = "txt_OriginAddress_ltlQuote";
        public string ZipcodeforShippingFrom_id = "origin-zip";
        public string cityforOrigin_id = "txtOrginCity";
        public string countryforOrigin_id = "select_origin_country_chosen";
        public string countryforOrigin_xpath = ".//*[@id='select_origin_country_chosen']/a/span";
        public string stateforOrigin_id = "state_origin_select_chosen";
        public string stateforOrigin_xpath = ".//*[@id='state_origin_select_chosen']/a/span";
        public string servicesforOrigin_id = "servicesaccessorialsfrom_chosen";//"services_accessorials_chosen";
        public string servicesforOrigin_xpath = ".//*[@id='servicesaccessorialsfrom_chosen']/ul/li/input";

        public string SearchboxforDestination_id = "txt_DestinationAddress_ltlQuote";
        public string ZipcodeforShippingTo_id = "destination-zip";
        public string cityforDestination_id = "txtDestCity";
        public string countryforDestination_id = "select_destination_country_chosen";
        public string countryforDestination_xpath = ".//*[@id='select_destination_country_chosen']/a/span";
        public string stateforDestination_id = "state_destination_select_chosen";
        public string stateforDestination_xpath = ".//*[@id='state_destination_select_chosen']/a/span";
        public string servicesforDestination_id = "servicesaccessorialsto_chosen";//"services_accessorials_chosen";
        public string servicesforDestination_xpath = ".//*[@id='servicesaccessorialsfrom_chosen']/ul/li/input";

        public string FreightDescriptionText_xpath = "//div[@id='page-content-wrapper']/div[2]/div[2]/div[3]/div/div/h3";
        public string ClassorSavedItemField_id = "Select-saveditem-0";
        public string ClickOutsideFied_xpath = "//div[@id='scrollable-dropdown-menu-Origin']/div/span/span/div/span/div[2]/p";
        public string ClassorSavedItem_xpath = ".//*[@id='Select_saveditem_0_chosen']//ul/li";
        public string ClassorSavedItemField_link = "Select or search for a class or saved item...";
        public string ClassorSavedItemField_css = ".chosen-single.chosen-default.selecterror";
        public string sample_xpath = "//div[@id='Select_saveditem_0_chosen']/a/div/b";
        public string ClassorSavedItemField_xpath = ".//*[@id='Select_saveditem_0_chosen']/a/span";
        public string weight_id = "weight-0";
        public string Quantity_id = "quantity-0";
        public string QuantityType_id = "quantity_uom_0_chosen";
        public string QuantityType_xpath = ".//*[@id='quantity_uom_0_chosen']/a/span";
        public string InsuredValue_id = "shipValueNumber";
        public string InsuredValueNew_id = "Insvalue_chosen";
        public string InsuredValueNew_xpath = ".//*[@id='Insvalue_chosen']/a/span";
        public string PickupDate_xpath = ".//h3[contains(text(),'Pickup Date')]";
        public string Pickupdate_id = "PickupDate";
        public string ClearAddress_FromId = "clearAddressRateOrgin";
        public string ClearAddress_ToId = "clearAddressRateDestination";
        public string DensityCalculatorIcon_id = "est-cls-btn-0";
        public string AddAdditionalItemBtm_xpath = ".//button[@class='btn_cal add-additional-item btn colored']";
        public string CalendarGrid_xpath = "//body/div[8]";
        public string ViewQuoteResultsBtn_id = "view-quote-results";
        public string tooltipicon_id = "question-icon";
        public string selectclasstextbox_xpath = ".//*[@id='Select_saveditem_0_chosen']/div/div/input";
        public string QuantityTypetextbox_xpath = ".//*[@id='quantity_uom_0_chosen']/div/div/input";
        public string FirstOption_List_xpath = ".//*[@id='Select_saveditem_0_chosen']/div/ul/li[1]";
        public string calendarininformation = "html/body/div[8]";
        //-------------------------relativepathsfor rateresultspage--------------------------

        public string insuredQuoteCostoption_Xpath = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']//td[5]/ul[1]";
        public string SaveInsuredRateoption_Xpath = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']//td[5]/ul[2]";
        public string CreateInsuredShipment_Xpath = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']//td[5]/button";
        public string Allcarriername_Xpath = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']//tr/td[1]/ul/li[1]";
        public string AllcarriernameG_Xpath = ".//*[@id='Grid-Rate-List-Large-Guranteed']/tbody//tr/td[1]/ul/li[1]";
        public string Text_insuredratecolumn_excluded_Xpath = "";

        //-----------------------------------------NonAdmin Users Rate Results(LTL)
        public string QuoteResults_EstCost_Text_Xpath = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/thead/tr/th[4]";

        public string QuoteResults_EstMargin_StdFirstCarrier_Text_Xpath = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[5]/ul[2]/li/b/span";
        public string QuoteResults_EstMargin_StdInsFirstCarrier_Text_Xpath = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[6]/ul[2]/li/b/span";

        public string QuoteResults_Fuel_FirstCarrierText_Xpath = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[4]/ul/li[2]/span";
        public string QuoteResults_LineHaul_FirstCarrierText_Xpath = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[4]/ul/li[3]/span";
        public string QuoteResults_Accessorial_FirstCarrierText_Xpath = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[4]/ul/li[4]/span";

        public string QuoteResults_StandardRates_CreateShipment_button_Id = "create-std-shipment-btn";
        public string QuoteResults_StandardInsuredRates_CreateShipment_button_Id = "create-std-insured-shipment-btn";

        public string QuoteResults_customerName_Id = "StationCustomerLbl";


        //-----------------------------Lenght------------------------------//
        public string LTL_Quote_Item_Length_Id = "length-0";
        public string LTL_Quote_Additional_Item1_Length_Id = "length-1";
        public string LTL_Quote_Additional_Item2_Length_Id = "length-2";
        public string LTL_Quote_Additional_Item3_Length_Id = "length-3";
        public string LTL_Quote_Additional_Item4_Length_Id = "length-4";
        public string LTL_Quote_Additional_Item5_Length_Id = "length-5";
        public string LTL_Quote_Additional_Item6_Length_Id = "length-6";
        public string LTL_Quote_Additional_Item7_Length_Id = "length-7";
        public string LTL_Quote_Additional_Item8_Length_Id = "length-8";
        public string LTL_Quote_Additional_Item9_Length_Id = "length-9";
        //-----------------------------Width------------------------------//
        public string LTL_Quote_Item_Width_Id = "width-0";
        public string LTL_Quote_Additional_Item1_Width_Id = "width-1";
        public string LTL_Quote_Additional_Item2_Width_Id = "width-2";
        public string LTL_Quote_Additional_Item3_Width_Id = "width-3";
        public string LTL_Quote_Additional_Item4_Width_Id = "width-4";
        public string LTL_Quote_Additional_Item5_Width_Id = "width-5";
        public string LTL_Quote_Additional_Item6_Width_Id = "width-6";
        public string LTL_Quote_Additional_Item7_Width_Id = "width-7";
        public string LTL_Quote_Additional_Item8_Width_Id = "width-8";
        public string LTL_Quote_Additional_Item9_Width_Id = "width-9";
        //------------------------------------height--------------------------//
        public string LTL_Quote_Item_Height_Id = "height-0";
        public string LTL_Quote_Additional_Item1_Height_Id = "height-1";
        public string LTL_Quote_Additional_Item2_Height_Id = "height-2";
        public string LTL_Quote_Additional_Item3_Height_Id = "height-3";
        public string LTL_Quote_Additional_Item4_Height_Id = "height-4";
        public string LTL_Quote_Additional_Item5_Height_Id = "height-5";
        public string LTL_Quote_Additional_Item6_Height_Id = "height-6";
        public string LTL_Quote_Additional_Item7_Height_Id = "height-7";
        public string LTL_Quote_Additional_Item8_Height_Id = "height-8";
        public string LTL_Quote_Additional_Item9_Height_Id = "height-9";



        //------Dimension type dropdown-------///
        public string LTL_Quote_Item_DimensionType_dropdown_Xpath = ".//*[@id='dimensionunit_0_chosen']/a";
        public string LTL_Quote_Additional_Item1_DimensionType_dropdown_Xpath = ".//*[@id='dimensionunit_1_chosen']/a";
        public string LTL_Quote_Additional_Item2_DimensionType_dropdown_Xpath = ".//*[@id='dimensionunit_2_chosen']/a";
        public string LTL_Quote_Additional_Item3_DimensionType_dropdown_Xpath = ".//*[@id='dimensionunit_3_chosen']/a";
        public string LTL_Quote_Additional_Item4_DimensionType_dropdown_Xpath = ".//*[@id='dimensionunit_4_chosen']/a";
        public string LTL_Quote_Additional_Item5_DimensionType_dropdown_Xpath = ".//*[@id='dimensionunit_5_chosen']/a";
        public string LTL_Quote_Additional_Item6_DimensionType_dropdown_Xpath = ".//*[@id='dimensionunit_6_chosen']/a";
        public string LTL_Quote_Additional_Item7_DimensionType_dropdown_Xpath = ".//*[@id='dimensionunit_7_chosen']/a";
        public string LTL_Quote_Additional_Item8_DimensionType_dropdown_Xpath = ".//*[@id='dimensionunit_8_chosen']/a";
        public string LTL_Quote_Additional_Item9_DimensionType_dropdown_Xpath = ".//*[@id='dimensionunit_9_chosen']/a";
        //---------------------Dimension type Dropdown list------------------//
        public string LTL_Quote_Item_DimensionType_dropdownList_Xpath = ".//*[@id='dimensionunit_0_chosen']/div/ul/li";
        public string LTL_Quote_Additional_Item1_DimensionType_dropdownList_Xpath = ".//*[@id='dimensionunit_1_chosen']/div/ul/li";
        public string LTL_Quote_Additional_Item2_DimensionType_dropdownList_Xpath = ".//*[@id='dimensionunit_2_chosen']/div/ul/li";
        public string LTL_Quote_Additional_Item3_DimensionType_dropdownList_Xpath = ".//*[@id='dimensionunit_3_chosen']/div/ul/li";
        public string LTL_Quote_Additional_Item4_DimensionType_dropdownList_Xpath = ".//*[@id='dimensionunit_4_chosen']/div/ul/li";
        public string LTL_Quote_Additional_Item5_DimensionType_dropdownList_Xpath = ".//*[@id='dimensionunit_5_chosen']/div/ul/li";
        public string LTL_Quote_Additional_Item6_DimensionType_dropdownList_Xpath = ".//*[@id='dimensionunit_6_chosen']/div/ul/li";
        public string LTL_Quote_Additional_Item7_DimensionType_dropdownList_Xpath = ".//*[@id='dimensionunit_7_chosen']/div/ul/li";
        public string LTL_Quote_Additional_Item8_DimensionType_dropdownList_Xpath = ".//*[@id='dimensionunit_8_chosen']/div/ul/li";
        public string LTL_Quote_Additional_Item9_DimensionType_dropdownList_Xpath = ".//*[@id='dimensionunit_9_chosen']/div/ul/li";

        public string LTL_Quote_AdditionalItem_button_Xpath = "//div[@id='page-content-wrapper']//button[@class='btn_cal add-additional-item btn colored']";

        public string LTL_Quote_ShippingFrom_Selected_First_ServicesAndAccessorials_Xpath = ".//*[@id='servicesaccessorialsfrom_chosen']/ul/li[1]/span";
        public string LTL_Quote_ShippingFrom_Selected_FirstAccessorial_RemoveOption_Xpath = ".//*[@id='servicesaccessorialsfrom_chosen']/ul/li[1]/a";
        public string LTL_Quote_ShippingFrom_ServicesAndAccessorial_dropdown_Xpath = ".//*[@id='servicesaccessorialsfrom_chosen']/ul/li";

        //----------------------------Additional Carrier Fee Warning PopUp-------------------------------//
        public string LTL_Quote_AddtlCarrierFee_PopUp_Item_Id = "Length-Additional-Warning-0";
        public string LTL_Quote_AddtlCarrierFee_PopUp_AdditionalItem1_Id = "Length-Additional-Warning-1";
        public string LTL_Quote_AddtlCarrierFee_PopUp_AdditionalItem2_Id = "Length-Additional-Warning-2";

        public string LTL_Quote_AddtlCarrierFeePopUp_Message_Item_Id = "Additional-Warning-Message-0";
        public string LTL_Quote_AddtlCarrierFeePopUp_Message_AdditionalItem1_Id = "Additional-Warning-Message-1";
        public string LTL_Quote_AddtlCarrierFeePopUp_Message_AdditionalItem2_Id = "Additional-Warning-Message-2";

        public string LTL_Quote_AddtlCarrierFeePopUp_RemoveOption_Item_Xpath = ".//*[@id='Length-Additional-Warning-0']/h4/i[2]";
        public string LTL_Quote_AddtlCarrierFeePopUp_RemoveOption_AdditionalItem1_Xpath = ".//*[@id='Length-Additional-Warning-1']/h4/i[2]";
        public string LTL_Quote_AddtlCarrierFeePopUp_RemoveOption_AdditionalItem2_Xpath = ".//*[@id='Length-Additional-Warning-2']/h4/i[2]";


        //-----------------------------Overlength Exceeds PopUp----------------------------------------------------//
        public string LTL_Quote_EnteredLengthExceeds_PopUp_Item_Id = "Length-Exceeds-Warning-0";
        public string LTL_Quote_EnteredLengthExceeds_PopUp_AdditionalItem1_Id = "Length-Exceeds-Warning-1";
        public string LTL_Quote_EnteredLengthExceeds_PopUp_AdditionalItem2_Id = "Length-Exceeds-Warning-2";

        public string LTL_Quote_EnteredLengthExceedsPopUp_Message_Item_Id = "Exceeds-Warning-Message-0";
        public string LTL_Quote_EnteredLengthExceedsPopUp_Message_AdditionalItem1_Id = "Exceeds-Warning-Message-1";
        public string LTL_Quote_EnteredLengthExceedsPopUp_Message_AdditionalItem2_Id = "Exceeds-Warning-Message-2";

        public string LTL_Quote_EnteredLengthExceedsPopUp_RemoveOption_Item_Xpath = ".//*[@id='Length-Exceeds-Warning-0']/h4/i[2]";
        public string LTL_Quote_EnteredLengthExceedsPopUp_RemoveOption_AdditionalItem1_Xpath = ".//*[@id='Length-Exceeds-Warning-1']/h4/i[2]";
        public string LTL_Quote_EnteredLengthExceedsPopUp_RemoveOption_AdditionalItem2_Xpath = ".//*[@id='Length-Exceeds-Warning-2']/h4/i[2]";

        //---------------------------Credit Hold-------------------------------------------------------------//
        public string GetQuotePage_CreditholdModalPopup_Xpath = ".//*[@id='showCreditHoldErrorModelLtlForRate']/div/div/div/div";
        public string GetQuote_CreditHoldModalpopupOK_Button_Id = "btnOkRedirectToQuoteList";
        public string GetQuotePage_CreditHoldmodalMessage_Xpath = ".//*[@id='showCreditHoldErrorModelLtlForRate']/div/div/div/div/div[2]/div/p";
        public string AddShipment_CreditHoldpopupMessage_Xpath = ".//*[@id='showCreditHoldErrorModelLtlForShipment']//p";
        public string AddShipment_CreditholdModalPopup_Xpath = ".//*[@id='showCreditHoldErrorModelLtlForShipment']/div/div/div/div";
        public string AddShipment_CreditHoldModalpopupOK_Button_Id = "btnOkRedirectToShipmentList";
        public string Dashboard_CreditHoldpopupOK_Button_Id = "btn_CreditHoldClose";


        //----------------------------------------Credit Hold ----------------------------------------------------//
        public string CreditHold_ModalTitle_Xpath = "//h2[contains(text(),'Credit Hold')]";
        public string CreditHold_ModalMessage_Xpath = "//div[@id='modal_CreditHold']//p";
        public string CreditHold_OKButton_Id = "btn_CreditHoldClose";
        public string CreditHoldOverlay_Xpath = "//div[@id='showCreditHoldErrorModel']";
        public string CreditHoldModalOverlay_Dashboard_xpath = "//*[@id='modal_CreditHold']";
        public string CreditHoldModalTitle_Dashboard_Xpath = "//*[@id='modal_CreditHold']//h3";

        //----------------------------------------Cookies accept-------------------------------------------------//

        public string AcceptCookies_Xpath = ".//*[@id='cookiescript_accept']";

        //---------------------------------------CSR Details----------------------------------------------------//
        public string CsrList_First_Name_On_List_Xpath = "//*[@id='csr-list-tbl']/table/tbody/tr[1]/td[1]/p/a";
        public string CsrDetails_PricingModel_Dropdown_Xpath = "//*[@id='pricing - gainshare']/div[2]";
        public string CsrDetails_GainshareNewLogic_Field_Xpath = "//*[@id='pricing-model-body']/div/div/div/div/div[1]/div[11]/span";
        public string CsrDetails_GainshareNewLogic_Field_Value_Xpath = "//*[@id='pricing-model-body']/div/div/div/div/div[1]/div[11]/div/p";
        public string CsrDetails_CrmRatingLogic_Field_Value_Xpath = "//*[@id='pricing-model-body']/div/div/div/div/div[1]/div[6]/div/p";
        public string CsrDetails_RatingInstructionsAndRate_Field_Value_Xpath = "//*[@id='pricing-model-body']/div/div/div/div/div[1]/div[10]/span";
    }
}
