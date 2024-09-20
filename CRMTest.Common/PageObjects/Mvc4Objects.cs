namespace CRMTest.Common.PageObjects
{
    public class Mvc4Objects : ObjectRepository
    {
        //---------------------------------Dashboard Page-----------------------------------------
        public string DasboardHeader_Xpath = "//*[@id='dashboard-container']//h1";
        public string AddShipmentButton_Id = "add-shipment-btn";
        public string DF_ShipTile_Id = "btn_domestic_forwarding";
        public string DF_ShipTypeSelect_Xpath = ".//*[@id='shipment_domestic_forward_type_chosen']/a";
        public string DF_ShipTypeSelectValue_Xpath = ".//*[@id='shipment_domestic_forward_type_chosen']//ul/li";
        public string DF_ShipTypeContinue_Id = "btn_submit_shipmentDomesticForwarding";
        public string DF_ShipPageTitle_Xpath = ".//*[@id='Domestic Forwarding']/div[1]/h1";
        public string Quote_DF_Radiobutton_Id = "domestic";
        public string Quote_DF_SelectType_dropdown_Id = "domesticForwardRateselect";
        public string Quote_DF_SelectType_dropdown_Values_Xpath = ".//*[@id='domesticForwardRateselect']/option";
        public string QuoteButton_Xpath = ".//*[@id='getRate']";

        public string CreateShipButton_DashboardPage_Id  = "createShipment";
        public string Ship_DF_Radiobutton_DashboardPage_ID = "shipment-6";
        public string Ship_DF_DomesticForwarding_Xpath = ".//*[@id='showShipment']//*[text()='Domestic Forwarding']";
        public string Ship_Intl_Radiobutton_DashboardPage_ID = "shipment-5";
        public string Ship_DF_SelectType_dropdown_DashboardPage_Id = "domesticForwardShipselect";
        public string Ship_DF_SelectType_dropdown_Values_DashboardPage_Xpath = ".//*[@id='domesticForwardShipselect']/option";
        public string Ship_Intl_SelectType_dropdown_DashboardPage_Id = "internationalShipSelect";
        public string Ship_Intl_SelectType_dropdown_Values_DashboardPage_Xpath = "//*[@id='internationalShipSelect']/option";

        public string Ship_Intl_SelectLevel_dropdown_DashboardPage_Id = "airShipSelect";
        public string Ship_Intl_SelectLevel_dropdown_Values_DashboardPage_Xpath = ".//*[@id='airShipSelect']/option";

        public string CreateShipButton_DashboardPage_Xpath = ".//*[@id='createShipment']";

        //---------------------Quote DomForwarding Shipment Location and Dates Page----------------------------
        public string DF_RateRequestHeader_ShpLoc_And_Dates_Page_Xpath = ".//*[@id='Domestic Forwarding']/div[1]/h1";
        public string Intl_RateRequestHeader_ShpLoc_And_Dates_Page_Xpath = "//*[@id='International']/div[1]/h1";
        public string DF_ShipmentLocation_and_Dates_Header_Xpath = ".//h3[contains(text(), 'Shipment Locations and Dates')]";
        public string DF_Service_ShpLoc_And_Dates_Page_Xpath = ".//*[@id='h-mode']";
        public string DF_OriginAddress_Dropdown_Xpath = ".//*[@id='select_save_orgin_chosen']/a";
        public string DF_OriginAddress_DropdownSearch_Xpath = ".//*[@id='select_save_orgin_chosen']/div/div/input";
        public string DF_OriginAddress_DropdownFirstValue_Xpath = ".//*[@id='select_save_orgin_chosen']/div/ul/li[1]";
        public string DF_OriginAddress_DropdownValues = ".//*[@id='select_save_orgin_chosen']/div/ul/li";
        public string DF_LocationName_Id = "txtorigin-name";
        public string DF_Address1_Id = "txtOrginAddr1";
        public string DF_Country_Xpath = ".//*[@id='origin']/div[6]/div[1]/div/span[2]/span";
        public string DF_OriginCountry_Xpath = ".//*[@id='dvOriginCountry']/span[2]/span/span[1]";
        public string DF_CountryDropdownValues_Xpath = ".//*[@id='country-origin-select_listbox']/li";
        public string DF_ZipCode_Id = "origin-zip";
        public string DF_ClickOut_xpath = ".//*[@id='origin']/div[2]/div[2]/div/span";
        public string DF_State_Xpath = ".//*[@id='origin']/div[7]/div[1]/div[1]/span[2]/span";
        public string DF_OriginState_Xpath = ".//*[@id='origin']//span[@aria-owns='state-origin-select_listbox']/span/span[1]";
        public string DF_State_SelectedValue_Xpath = ".//*[@id='origin']/div[7]/div[1]/div[1]/span[2]/span/span[1]";
        public string DF_StateDropdownValues = ".//*[@id='state-origin-select_listbox']/li";
        public string DF_City_Id = "txtOrginCity";
        public string DF_DestinationAddress_Dropdown_Xpath = ".//*[@id='select_save_destination_chosen']/a";
        public string DF_DestinationAddress_DropdownSearch_Xpath = ".//*[@id='select_save_destination_chosen']/div/div/input";
        public string DF_DestinationAddress_FirstValue_Xpath = ".//*[@id='select_save_destination_chosen']/div/ul/li[1]";
        public string DF_Destination_DropdownValues_Xpath = ".//*[@id='select_save_destination_chosen']/div/ul/li";
        public string DF_DesLocationName_Id = "txtdestin-name";
        public string DF_DesAddress1_Id = "txtDestAddr1";
        public string DF_DesCountry_Xpath = ".//*[@id='destination']/div[6]/div[1]/div/span[2]/span";
        public string DF_DestinationCountry_Xpath = ".//*[@id='dvDestCountry']/span[2]/span/span[1]";
        public string DF_DesCountryDropdownValues_Xpath = ".//*[@id='country-destination-select_listbox']/li";
        public string DF_DesZipcode_Id = "destination-zip";
        public string DF_DesState_Xpath = ".//*[@id='destination']/div[7]/div[1]/div[1]/span[2]/span";
        public string DF_DestinationState_Xpath = ".//*[@id='destination']//span[@aria-owns='state-destination-select_listbox']/span/span[1]";
        public string DF_DesState_SelectedValue_Xpath = ".//*[@id='destination']/div[7]/div[1]/div[1]/span[2]/span[1]/span[1]";
        public string DF_DesStateDropdownValues_Xpath = ".//*[@id='state-destination-select_listbox']/li";
        public string DF_DesCity_Id = "txtDestCity";
        public string DF_SavedItem_Xpath = ".//*[@id='dom_saved_item_select_chosen']/a";
        public string DF_SavedItem_Search_Xpath = ".//*[@id='dom_saved_item_select_chosen']/div/div/input";
        public string DF_SavedItenDropdown_FirstValue_Xpath = ".//*[@id='dom_saved_item_select_chosen']/div/ul/li[1]";
        public string DF_SavedItenDropdownValues_Xpath = ".//*[@id='dom_saved_item_select_chosen']/div/ul/li";
        public string DF_Pieces_Id = "quantity";
        public string DF_PiecesType_Xpath = ".//*[@id='main']/div/div/div[1]/div[2]/div/div[1]/div[3]/span[2]/span";
        public string DF_Weight_Id = "weight";
        public string DF_DimensionLength_Id = "txtlength";
        public string DF_DimensionWidth_Id = "txtwidth";
        public string DF_DimensionHeight_Id = "txtheight";
        public string DF_Description_Id = "commodity";
        public string DF_OriginContactName_Id = "txtorig-cont-name";
        public string DF_OriginPhoneNum_Id = "txtorig-phonenumber";
        public string DF_DesContactName_Id = "txtdestin-cont-name";
        public string DF_DesPhoneNum_Id = "txtdest-phonenumber";
        public string DF_SaveAndContinue_Button_Id = "save-continue";

        //----------Added from here
        public string DF_Add_Additional_Piece_Id = "add-additional-piece";
        public string DF_First_SavedItem_Xpath = ".//*[@id='dom_saved_item_select_1_chosen']/a/span";
        public string DF_First_SavedItem_Search_Xpath = ".//*[@id='dom_saved_item_select_1_chosen']/div/div/input";
        public string DF_First_SavedItemDropdown_FirstValue_Xpath = ".//*[@id='dom_saved_item_select_1_chosen']/div/ul/li[1]";
        public string DF_First_SavedItemDropdownValues_Xpath = ".//*[@id='dom_saved_item_select_1_chosen']/div/ul/li";
        public string DF_First_Pieces_Id = "quantity-1";
        public string DF_First_PiecesType_Xpath = ".//*[@id='addtionalpiece-1']/div[1]/div[3]/span[2]/span";
        public string DF_First_Weight_Id = "weight-1";
        public string DF_First_DimensionLength_Id = "txtlength-1";
        public string DF_First_DimensionWidth_Id = "txtwidth-1";
        public string DF_First_DimensionHeight_Id = "txtheight-1";
        public string DF_First_Description_Id = "commodity-1";

        public string DF_Total_Pieces_Id = "txtnumber-pieces";
        public string DF_Total_Weight_Id = "totalweight";
        public string DF_ReferenceType_DropDown_xpath = ".//*[@id='main']/div/div/div[1]/div[3]/div[1]/div/div/div[2]/div/div[1]/div[1]/span[2]/span";
        public string DF_ReferenceType_DropDownValues_xpath = ".//*[@id='reference-type-select_listbox']/li";
        public string DF_Reference_Number_Id = "reference-num";
        public string DF_Reference_Number_Yes_RadioButton_xpath = ".//*[@id='main']/div/div/div[1]/div[3]/div[1]/div/div/div[1]/div/div/label[1]";
        public string DF_Reference_Number_No_RadioButton_xpath = ".//*[@id='main']/div/div/div[1]/div[3]/div[1]/div/div/div[1]/div/div/label[2]";

        public string DF_CustomerType_DropDown_xpath = ".//*[@id='main']/div/div/div[1]/div[3]/div[1]/div/div/div[2]/div/div[1]/div[3]/span[2]/span";
        public string DF_CustomerType_FirstDropDown_values_xpath = ".//*[@id='customer-type-select_listbox']/li[1]";
        public string DF_CustomerType_DropDown_values_xpath = ".//*[@id='customer-type-select_listbox']/li";

        public string DF_ServicesAccessorials_Yes_RadioButton_xpath = ".//*[@id='main']/div/div/div[1]/div[3]/div[2]/div/div/div[1]/div/label[1]";
        public string DF_ServicesAccessorials_No_RadioButton_xpath = ".//*[@id='main']/div/div/div[1]/div[3]/div[2]/div/div/div[1]/div/label[2]";

        public string DF_ServicesAccessorials_SearchBox_xpath = ".//*[@id='service_select_chosen']/ul/li/input";
        public string DF_ServicesAccessorials_FirstValue_xpath = ".//*[@id='service_select_chosen']/div/ul/li[1]";
        public string DF_ShipmentValue_xpath = ".//*[@id='shipValueNumber']";
        public string DF_DefaultSpecialInstructions_Id = "txtSpecialInstructions";

        //------------------------------Review and Submit page---------------------------------

        public string DF_ReviewPageTitle_Xpath = ".//*[@id='main']/div/div/h3";
        public string DF_ReviewPage_OriginAddresss_Xpath = ".//*[@id='originlocdetails']/div[1]/div/ul/li[1]";
        public string DF_ReviewPage_OriginCity_State_Zip_Xpath = ".//*[@id='originlocdetails']/div[1]/div/ul/li[3]";
        public string DF_ReviewPage_OriginCountry_Xpath = ".//*[@id='originlocdetails']/div[1]/div/ul/li[4]";
        public string DF_ReviewPage_DesAddress_Xpath = ".//*[@id='destinationlocdetails']/div[1]/div/ul/li[1]";
        public string DF_ReviewPage_DesCity_State_Zip_Xpath = ".//*[@id='destinationlocdetails']/div[1]/div/ul/li[3]";
        public string DF_ReviewPage_DesCountry_Xpath = ".//*[@id='destinationlocdetails']/div[1]/div/ul/li[4]";
        public string DF_ReviewPage_OriginContactName_Xpath = ".//*[@id='origin-contact']/div/div/ul/li[1]";
        public string DF_ReviewPage_OriginPhoneNum_Xpath = ".//*[@id='origin-contact']/div/div/ul/li[2]";
        public string DF_ReviewPage_DesContactName_Xpath = ".//*[@id='destination-contact']/div/div/ul/li[1]";
        public string DF_ReviewPage_DesPhoneNum_Xpath = ".//*[@id='destination-contact']/div/div/ul/li[2]";
        public string DF_ReviewPage_Pieces_Xpath = ".//*[@id='tblFreight']/tbody/tr/td[1]";
        public string DF_ReviewPage_Weight_Xpath = ".//*[@id='tblFreight']/tbody/tr/td[3]";
        public string DF_ReviewPage_Description = ".//*[@id='tblFreight']/tbody/tr/td[4]";

        public string DF_Submit_Button_Id = "submit-btn";
        public string DF_Back_Button_Id = "submit-back-btn";

        //----------------------Confirmation Page ---------------------------

        public string DF_ConfirmationPageTitle_xpath = ".//*[@id='main']/div/div/h3";
        public string DF_ServiceName_xpath = ".//*[@id='rate-Mode']";
        public string DF_UploadArea_browse_xpath = ".//*[@id='main']/div/div/div[2]/div/div/div/div[1]/div/div/span/b";
        public string DF_UploadArea_xpath = ".//*[@id='main']/div/div/div[2]/div/div/div/div[1]/div";

        //--------------------Shipment Module-------------------------------------
        public string ShipmentModule_Xpath = ".//*[@id='shipment']/i";
        public string ShipmentModule_Id = "shipment";
        public string AddShipmentbtn_Id = "add-shipment-btn";


        public string ShipDF_SelectType_Xpath = ".//*[@id='shipment_domestic_forward_type_chosen']/a/span";
        public string ShipDF_SelectTypeValues_Xpath = ".//*[@id='shipment_domestic_forward_type_chosen']/div/ul/li";
        public string ShipDF_Continuebutton_ID = "btn_submit_shipmentDomesticForwarding";

        public string ShipDF_AddShipmentHeader_Xpath = ".//*[@id='body']//h1";
        public string ShipDF_ShipmentService_Xpath = ".//*[@id='main']//h3";

        //-----------------------Shipment Domestic forwarding location and dates page------------------------
        public string ShipDF_Service_ShpLoc_And_Dates_Page_Xpath = ".//*[@id='h-mode']";
        //---------------------------------Shipment Domestic Forwarding Location Dates page-------------
        public string ShipDF_AddShipmentPageTitle_Xpath = ".//*[@id='Domestic Forwarding']//*[text()='Add Shipment']";
        public string ShipDF_ShipmentLocationAndDatesPage_Xpath = ".//*[@id='main']//*[text()='Shipment Locations and Dates']";
        public string ShipDF_AddShipment_Type_Xpath = ".//*[@id='main']//*[@class='int-dom type']";
        public string ShipDF_AddShipment_Servie_Id = "h-mode";
        public string DF_ShipOriginName_Id = "txtorigin-name";
        public string DF_ShipOriginAddress_Id = "txtOrginAddr1";
        public string DF_ShipOriginAddress1_Id = "txtOrginAddr2";
        public string DF_ShipOriginCountry_Xpath = ".//*[@id='dvOriginCountry']/span[2]/span";
        public string DF_ShipOriginZip_Id = "origin-zip";
        public string DF_ShipOriginState_Xpath = ".//*[@id='origin']/div[2]/div[1]/div[1]/span[2]/span";
        public string DF_ShipOriginCity_Id = "txtOrginCity";
        public string DF_ShipDesName_Id = "txtdestin-name";
        public string DF_ShipDesAddress_Id = "txtDestAddr1";
        public string DF_ShipDesAddress1_Id = "txtDestAddr2";
        public string DF_ShipDesCountry_Xpath = ".//*[@id='dvDestCountry']/span[2]/span";
        public string DF_ShipDesZip_Id = "destination-zip";
        public string DF_ShipDesState_Xpath = ".//*[@id='destination']/div[2]/div[1]/div[1]/span[2]/span";
        public string DF_ShipDesCity_Id = "txtDestCity";
        public string DF_ShipDesPostal_Id = "postal-destination";
        public string DF_ShipOriginPostal_Id = "postal-origin";
        public string DF_ShipDesProvince_Xpath = ".//*[@id='destination']/div[2]/div[1]/div[2]/span[2]/span";
        public string DF_ShipOriginProvince_Xpath = ".//*[@id='origin']/div[2]/div[1]/div[2]/span[2]/span";

        public string ShipDF_OrgClearAddressButton_ID = "clearAddressOrginDom";
        public string ShipDF_OriginAddressDropdown_Xpath = ".//*[@id='select_save_orgin_chosen']/a/span";
        public string ShipDF_FirstOriginAddressFromDropdown_Xpath = ".//*[@id='select_save_orgin_chosen']/div/ul/li[1]";

        public string ShipDF_DestClearAddressButton_ID = "clearAddressDestinationDom";
        public string ShipDF_DestAddressDropdown_Xpath = ".//*[@id='select_save_destination_chosen']/a/span";
        public string ShipDF_FirstDestAddressFromDropdown_Xpath = ".//*[@id='select_save_destination_chosen']/div/ul/li[1]";

        public string ShipDF_OrgAccessorial_Dropdown_Xpath = ".//*[@id='service_select_origin_chosen']/ul/li/input";
        public string ShipDF_OrgAccessorial_DropdownValue_Xpath = ".//*[@id='service_select_origin_chosen']/div/ul/li";

        public string ShipDF_DestAccessorial_Dropdown_Xpath = ".//*[@id='service_select_destination_chosen']/ul/li/input";
        public string ShipDF_DestAccessorial_DropdownValue_Xpath = ".//*[@id='service_select_destination_chosen']/div/ul/li";

        public string ShipDF_OriginLocationName_Id = "txtorigin-name";
        public string ShipDF_OriginAddress_Id = "txtOrginAddr1";
        public string ShipDF_OriginZip_Id = "origin-zip";
        public string ShipDF_DestLocationName_Id = "txtdestin-name";
        public string ShipDF_DestAddress_Id = "txtDestAddr1";
        public string ShipDF_DestZip_Id = "destination-zip";
        public string ShipDF_PickReady_Dropdown_Xpath = ".//*[@id='pickup-date']/div/div[2]/span[2]/span";
        public string ShipDF_PickReady_DropdownValues_Xpath = ".//div/div[@id = 'ready-origin-select-list']/ul[@id='ready-origin-select_listbox']/li";
        public string ShipDF_PickClose_Dropdown_Xpath = ".//*[@id='pickup-date']/div/div[3]/span[2]/span";
        public string ShipDF_PickClose_DropdownValues_Xpath = ".//div/div/ul[@id='close-origin-select_listbox']/li";
        public string ShipDF_DelReady_Dropdown_Xpath = ".//*[@id='delivery-date']/div/div[2]/span[2]/span";
        public string ShipDF_DelReady_DropdownValues_Xpath = ".//div/div/ul[@id='ready-delivery-select_listbox']/li";
        public string ShipDF_DelClose_Dropdown_Xpath = ".//*[@id='delivery-date']/div/div[3]/span[2]/span";
        public string ShipDF_DelClose_DropdownValues_Xpath = ".//div/div/ul[@id='close-delivery-select_listbox']/li";

        //-----------------------Shipment Domestic forwarding Item information page------------------------
        public string ShipDF_ItemDropdown_Xpath = ".//*[@id='saved_item_select_chosen']/a/span";
        public string ShipDF_ItemDropdownValue_Xpath = ".//*[@id='saved_item_select_chosen']/div/ul/li";

        public string ShipDF_Quantity_Id = "quantity";
        public string ShipDF_Weight_Id = "weight";
        public string ShipDF_Length_Id = "txtlength";
        public string ShipDF_Width_Id = "txtwidth";
        public string ShipDF_Height_Id = "txtheight";
        public string ShipDF_Desc_Id = "commodity";

        public string ShipDF_SaveContinueButton_Id = "save-continue-Location";

        //-----------------------Shipment Domestic forwarding Review And Submit Page-----------------------
        public string ShipDFReview_And_SubmitPage_Header_Xpath = ".//h3[contains(text(), 'Review and Submit')]";
        public string ShipDF_Service_ReviewAndSubmitPage_Id = "h-mode";

        //-----------------------Shipment Domestic forwarding Item information page------------------------

        public string ShipDF_SubmitButton_Id = "submitShipment";


        //-----------------------Shipment Domestic forwarding Confirmation page------------------------

        public string ShipDF_ConfirmationTitle_Xpath = ".//*[@id='confirmation-Shipment']/h3";
        public string ShipDF_ServiceVerbiage_Xpath = ".//*[@id='confirmation-Shipment']/h6[1]/span[1]";
        public string ShipDF_ServiceType_Xpath = ".//*[@id='service']";
        public string ShipDF_typeVerbiage_Xpath = ".//*[@id='confirmation-Shipment']/h6[2]/span[1]";
        public string ShipDF_type_Xpath = ".//*[@id='type']";
        public string PickupDateVerbiage_Xpath = ".//*[@id='confirmation-Shipment']/h6[3]/span[1]";
        public string pickupDate_Xpath = ".//*[@id='pickupdate']";
        public string ShipDF_HouseBillNumVerbiage_Xpath = ".//*[@id='confirmation-Shipment']/h6[4]/span[1]";
        public string ShipDF_HouseBillNum_Xpath = ".//*[@id='requestNumber']";
        public string ShipDF_statusVerbiage_Xpath = ".//*[@id='confirmation-Shipment']/h6[5]/span[1]";
        public string ShipDF_status_Xpath = ".//*[@id='statusData']";
        public string ShipDF_ViewShipmentDetail_Xpath = ".//*[@id='shipment-confirm-txt']/a";
        public string ShipDF_HouseBill_Id = "housebill";
        public string ShipDF_ViewHouseBill_Xpath = ".//*[@id='housebill-content']/li/a";
        public string ShipDF_StartNewShipEntry_Id = "newShipment";
        public string ShipDF_BrowseFile_Xpath = ".//div[@class = 'k-dropzone']";
        public string ShipDF_Fileupload_Xpath = ".//li[@class = 'k-file k-file-success']";
        public string ShipDF_FileSavedText_Xpath = ".//span[@class = 'k-upload-pct']/a";
        public string ShipDF_RefNum_Text = "requestNumber";

        //-----------------------Document Repository Module ---------------------------------------------

        public string DocRepo_icon_Id = "docRepo";
        public string DocRepo_RecentlyAddedtitlt_Id = "table-title";
        public string DocRepo_SearchBox_Id = "search-input";
        public string DocRepo_Firstrow_FileName_Xpath = ".//tbody/tr[1]/td[3]/div[2]/span";
        public string DocRepo_Firstrow_Ref_Xpath = ".//tbody/tr[1]/td[2]/span[1]/a";
        public string DocRepo_BOLTab_Xpath = ".//div[@class = 'left-menu-box']/div[2]";

        //----------------------Quote International from Dashboard ----------------------------------------

        public string IntenationalRadioBtn_Xpath = ".//input[@id='international']";
        public string In_Selecttype_Xpath = ".//*[@id='internationalRateSelect']";
        public string In_SelecttypeValues_Xpath = ".//*[@id='internationalRateSelect']/option";
        public string In_airSelect_id = "airRateSelect";
        public string In_airSelectValues_Xpath = ".//*[@id='airRateSelect']/option";
        public string In_oceanSelect_id = "oceanRateSelect";
        public string In_oceanSelectValues_Xpath = ".//*[@id='oceanRateSelect']/option";

        //--------------------International Shipment Information page -------------------------------------

        public string In_OLocationName_id = "txtorigin-name";
        public string In_OContactName_id = "txtorig-cont-name";
        public string In_OAddress1_id = "txtOrginAddr1";
        public string In_OEmail_id = "origin-emailId";
        public string In_OCountry_Xpath = ".//*[@class='span4 location-country']//span[contains(text(), 'Select Country')]";
        public string In_OCountryValues_Xpath = ".//*[@id='country-origin-select_listbox']/li";
        public string In_OPhoneNo_id = "txtorig-phonenumber";
        public string In_OZip_id = "origin-zip";
        public string In_dLocationName_id = "txtdestin-name";
        public string In_dContactName_id = "txtdestin-cont-name";
        public string In_dAddress1_id = "txtDestAddr1";
        public string In_dEmail_id = "destination-emailId";
        public string In_dCountry_Xpath = ".//*[@id='destination']/div[5]/div/span[2]/span";
        public string In_dCountryValues_Xpath = ".//*[@id='country-destination-select_listbox']/li";
        public string In_dPhoneNo_id = "txtdest-phonenumber";
        public string In_dZip_id = "destination-zip";
        public string In_incotermsValues_Xpath = "html/body/div[6]/div/ul/li";
        public string In_incoterms_Xpath = ".//*[@id='main']/div[2]/div/div[4]/div/div[3]/div[1]/span[2]/span";
        public string In_commercialInvoiceVal_id = "Commercial-air-Value";
        public string In_pieces_id = "quantity";
        public string In_weight_id = "weight";
        public string In_length_id = "txtlength";
        public string In_width_id = "txtwidth";
        public string In_height_id = "txtheight";
        public string In_description_Xpath = ".//*[@class='commodity']";
        public string In_HazMat_Xpath = ".//*[@class='span4 haz-mat']/div/label";
        public string In_HazMat_Yes_Xpath = ".//*[@id='main']/div[2]/div/div[5]/div/div[6]/div/div/label[1]";
        public string In_HazMat_No_Xpath = ".//*[@id='main']/div[2]/div/div[5]/div/div[6]/div/div/label[2]";
        public string In_ApplyInsAllRisk_Xpath = ".//*[@class='span1']/div/label";
        public string In_ApplyInsAllRisk_Yes_Xpath = ".//*[@id='main']/div[2]/div/div[6]/div/div/div[1]/div/label[1]";
        public string In_ApplyInsAllRisk_No_Xpath = ".//*[@id='main']/div[2]/div/div[6]/div/div/div[1]/div/label[2]";
        public string In_declaredVal_id = "shipValueNumber";
        public string In_comments_id = "txtSpecialInstructions";
        public string In_SaveandContinueBtn_id = "save-continue";
        public string In_BackBtn_id = "btn-back";

        //--------------------International Review and Submit page -------------------------------------
        public string In_EditBtn_Xpath = ".//*[@id='locations-container']/h5/a";
        public string In_SumitBtn_id = "submit-btn";
        public string In_RSBackBtn_id = "submit-back-btn";

        //---------------------International Confirmation page -----------------------------------------
        public string In_Confirmation_Header_Xpath = ".//*[@class='content ship-container form-container']/h3";
        public string In_ConfirmationPage_NewShipment_Xpath = ".//*[@id='newShipment']";

        //---------------------International Shipment Tile ------------------------------
        public string Int_Shipment_Tile_Id = "btn_international";
        public string Int_ServiceType_Modal_Verbiage = ".//h3[contains(text(), 'International Type')]";
        public string Int_Shipment_Type_dropdown_Xpath = ".//*[@id='shipment_international_type_chosen']/a";
        public string Int_Shipment_Type_dropdown_Value_Xpath = ".//*[@id='shipment_international_type_chosen']/div/ul/li";
        public string Int_Shipment_level_dropdown_Xpath = ".//*[@id='rate_international_level_chosen']/a";
        public string Int_Shipment_level_dropdown_value_Xpath = ".//*[@id='rate_international_level_chosen']/div/ul/li";
        public string Int_Shipment_Continue_button_Id = "btnSubmitShipmentInternational";


        //-----------------International Shipment Shipment Location and Dates page--------------
        public string Int_Shipment_LocationAndDates_Text_Xpath = ".//h3[contains(text(), 'Shipment Locations and Dates')]";
        public string Int_Shipment_OringinClearAddress_button_Id = "clearAddressOrgin";
        public string Int_Shipment_OriginName_Textbox_Id = "txtorigin-name";
        public string Int_Shipment_OriginAddress_Textbox_Id = "txtOrginAddr1";
        public string Int_Shipment_OriginCountry_dropdown_Xpath = ".//*[@id='dvOriginCountry']/span[2]/span";
        public string Int_Shipment_OriginCountry_dropdown_value_Xpath = ".//*[@id='country-origin-select_listbox']/li";
        public string Int_Shipment_OriginZip_Textbox_Id = "origin-zip";
        public string Int_Shipment_OriginCity_Textbox_Id = "txtOrginCity";
        public string Int_Shipment_OriginState_dropdown_Xpath = ".//*[@id='origin']/div[7]/div/div[1]/span[2]/span";
        public string Int_Shipment_OriginState_dropdown_value_Xpath = "//div[@class='k-animation-container km-popup']/div[@id = 'state-origin-select-list']/ul/li";


        public string Int_Shipment_DestinationClearAddress_button_Id = "clearAddressDestination";
        public string Int_Shipment_DestinationName_Textbox_Id = "txtdestin-name";
        public string Int_Shipment_DestinationAddress_Textbox_Id = "txtDestAddr1";
        public string Int_Shipment_DestinationCountry_dropdown_Xpath = ".//*[@id='dvDestCountry']/span[2]/span";
        public string Int_Shipment_DestinationCountry_dropdown_value_Xpath = ".//*[@id='country-destination-select_listbox']/li";
        public string Int_Shipment_DestinationZip_Textbox_Id = "destination-zip";
        public string Int_Shipment_DestinationCity_Textbox_Id = "txtDestCity";
        public string Int_Shipment_DestinationState_dropdown_Xpath = ".//*[@id='destination']/div[7]/div/div[1]/span[2]/span";
        public string Int_Shipment_DestinationState_dropdown_value_Xpath = "//div[@class='k-animation-container km-popup']/div[@id = 'state-destination-select-list']/ul/li";


        public string Int_Shipment_PickUp_ReadyTime_dropdown_Xpath = ".//*[@id='pickup-date']/div/div[2]/span[2]/span";
        public string Int_Shipment_PickUp_CloseTime_dropdown_Xpath = ".//*[@id='pickup-date']/div/div[5]/span[2]/span";
        public string Int_Shipment_Delivery_ReadyTime_dropdown_Xpath = ".//*[@id='delivery-date']/div/div[2]/span[2]/span";
        public string Int_Shipment_Delivery_CloseTime_dropdown_Xpath = ".//*[@id='delivery-date']/div/div[5]/span[2]/span";

        public string Int_Shipment_PickUp_ReadyTime_dropdown_value_Xpath = "//div[@class='k-animation-container km-popup']/div[@id = 'ready-origin-select-list']/ul/li[2]";
        public string Int_Shipment_PickUp_CloseTime_dropdown_value_Xpath = "//div[@class='k-animation-container km-popup']/div[@id = 'close-origin-select-list']/ul/li[3]";
        public string Int_Shipment_Delivery_ReadyTime_dropdown_value_Xpath = "//div[@class='k-animation-container km-popup']/div[@id = 'ready-delivery-select-list']/ul/li[4]";
        public string Int_Shipment_Delivery_CloseTime_dropdown_value_Xpath = "//div[@class='k-animation-container km-popup']/div[@id = 'close-delivery-select-list']/ul/li[5]";

        public string Int_Shipment_LocationAndDates_Page_SaveAndContinue_button_Id = "save-continue-Location";

        //--------------------International Shipment Item Information Page---------------------------------
        public string Int_Shipment_ItemInformation_Textbox_Xpath = ".//h3[contains(text(), 'Item Information')]";
        public string Int_Shipment_Pieces_Textbox_Id = "quantity";
        public string Int_Shipment_Weight_Textbox_Id = "weight";
        public string Int_Shipment_Length_Textbox_Id = "txtlength";
        public string Int_Shipment_Width_Textbox_Id = "txtwidth";
        public string Int_Shipment_Height_Textbox_Id = "txtheight";
        public string Int_Shipment_Description_Textbox_Xpath = ".//*[@id='main']/div[2]/div/div[1]/div/div[6]/div/input";

        public string Int_Shipment_IncoTerms_dropdown_Xpath = ".//*[@id='main']/div[2]/div/div[3]/div/div[3]/div[1]/span[2]/span";
        public string Int_Shipment_First_IncoTerms_dropdown_Value = ".//*[@id='inco-air-select_listbox']/li[2]";
        public string Int_shipment_CommercialValue_Textbox_Id = "Commercial-air-Value";

        public string Int_Shipment_ItemInformation_Page_SaveAndContinue_button_Id = "save-continue";

        //-----------------International Shipment Review and Submit page------------------------
        public string Int_Shipment_ReviewAndSubmitPage_Text_Xpath = ".//h3[contains(text(), 'Review and Submit')]";
        public string Int_Shipment_Submit_button_Id = "submitShipment";
        public string Int_Shipment_HousebillNumber_Id = "requestNumber";
        //-----------------Shipment List Page-----------------------------------------------------
        public string Shipment_Module_Navigation_Icon_Xpath = ".//*[@id='shipment']/i";
        public string ShipmentList_Header_Text_Xpath = ".//h1[contains(text(), 'Shipment List')]";
        public string AddShipment_button_Id = "add-shipment-btn";
        public string AddShipmentTiles_Page_Header_Xpath = ".//h1[contains(text(), 'Add Shipment')]";
        public string ShipmentList_Searchbox_Id = "searchbox";
        public string ShipmentList_SearchedRefereceNumber_Id = "RefID";

        //------------------Shipment Details Page -------------------------------------------------
        public string ShipmentDetails_Header_Xpath = "html/body//h1";


    }
}
