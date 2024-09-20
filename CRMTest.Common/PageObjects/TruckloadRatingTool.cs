namespace CRMTest.Common.PageObjects
{
    public class TruckloadRatingTool : ObjectRepository
    {

        public string RatingToolIcon_Id = "ratingTools";        
        public string ProjectedAmount_OriginZip_Textbox_Id = "OriginZipId";
        public string ProjectedAmount_DestinationZip_Textbox_Id = "DestinationZipId";
        public string ProjectedAmount_Weight_Textbox_Id = "txt-weight";
        public string ProjectedAmount_GetRate_Button_ID = "btn-GetRate";       
        public string ProjectedAmount_GetQuoteNow_Button_ID = "btn-livequote";
        public string ProjectedAmount_Calendar_css = "i.icon-calendar";
        public string ProjectedAmount_Activeday_xpath = "//table/tbody/tr/td";
        public string ProjectedAmount_RightClickCalendar_xpath = "//table/thead/tr[1]/th[3]/i";
        public string ProjectedAmount_GetQuote_Truckload_Header_xpath = ".//*[@id='page-content-wrapper']/div[2]/div[1]/div[1]/div[1]/h1";
        public string TL_EquipmentType_ID = "EquipmentType_chosen";
        public string TL_EquipmentType_SelectedValue_Xpath = ".//*[@id='EquipmentType_chosen']/a/span";
        public string TL_EquipmentType_DropdownValue_Xpath = ".//*[@id='EquipmentType_chosen']/div/ul/li";
        public string TL_StationDropdown_ID = "stationname_chosen";
        public string TL_StationDropdown_SelectedValue_Xpath = ".//*[@id='stationname_chosen']/a/span";
        public string TL_StationDropdownValue_Xpath = ".//*[@id='stationname_chosen']/div/ul/li";


        public string TL_ShippingFrom_Lable_xpath = ".//*[@id='page-content-wrapper']/div[2]/div[2]/div[3]/div[1]/h3";
        public string TL_ShippingTo_Lable_xpath = ".//*[@id='page-content-wrapper']/div[2]/div[2]/div[3]/div[2]/h3";
        public string TL_ShippingFromZip_Textbox_ID = "origin-zip";
        public string TL_ShippingToZip_Textbox_ID = "destination-zip";
        public string TL_ShippingFrom_Country_Dropdown_Xpath = ".//*[@id='select_origin_country_chosen']/a/span";
        public string TL_ShippingFrom_CanadaCountry_Dropdown_Xpath = ".//*[@id='select_origin_country_chosen']/div/ul/li[2]";
        public string TL_ShippingTo_Country_Dropdown_Xpath = ".//*[@id='select_destination_country_chosen']/a/span";
        public string TL_ShippingTo_CanadaCountry_Dropdown_Xpath = ".//*[@id='select_destination_country_chosen']/div/ul/li[2]";
        public string TL_ShippingFrom_City_Textbox_ID = "txtOrginCity";
        public string TL_ShippingTo_City_Textbox_ID = "txtDestCity";
        public string TL_ShippingFrom_StateProvince_Dropdown_Xpath = ".//*[@id='state_origin_select_chosen']/a/span";
        public string TL_ShippingFrom_StateProvince_DropdownValue_Xpath = ".//*[@id='state_origin_select_chosen']/div/ul/li";
        public string TL_ShippingTo_StateProvince_Dropdown_Xpath = ".//*[@id='state_destination_select_chosen']/a/span";
        public string TL_ShippingTo_StateProvince_DropdownValue_Xpath = ".//*[@id='state_destination_select_chosen']/div/ul/li";
        public string TL_BackToRatingTools_Button_Xpath = ".//*[@id='Btn_BackQuoteList']";
        public string TL_WarningMessage_Orange_xpath = ".//*[@id='warning-orange']";
        public string TL_GetQuote_Title_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div[1]/div[1]/div[1]/h1";
        public string TL_ProjectedAmountPage_Title_Xpath = "html/body/div[4]/section/div[4]/div/div[1]/div/h1";
        public string ProjectedAmount_GetQuoteNow_Button_Xpath = ".//*[@id='btn-livequote']";
        public string TL_SpecialInstructions_Xpath = ".//*[@id='specialInstruction']";


        public string TL_MaxInsuredValue_Error_Xpath = ".//*[@id='shipment-value-warning']/p";
        public string TL_Maxinsval_Errorheader_xpath = ".//*[@id='shipment-value-warning']/h4";        
        public string TL_tooltipicon_xpath = ".//*[@class='icon-question']";
        public string TL_tooltipiconmsg_xpath = ".//*[@id='page-content-wrapper']/div[2]/div[2]/div[9]/div[1]/div/div[2]/button";
        public string TL_EnterInsuredValue_Id = "Insvalue";        
        public string TL_PickupDate_Id = "PickupDate";
        public string TL_PickupCalendar_xpath = "html/body/div[8]/div[1]/table/thead/tr[1]/th[2]";
        public string TL_DropoffCalendar_xpath = "html/body/div[8]/div[1]/table/thead/tr[1]/th[2]";
        public string TL_DropoffDate_Id = "DropoffDate";
        public string TL_PickupCalendarPopup_xpath = ".//*[@class='datepicker datepicker-dropdown dropdown-menu datepicker-orient-left datepicker-orient-bottom']/div[1]";
        public string TL_Selectingdates_xpath = "html/body/div[8]/div[1]/table/tbody/tr/td";
        public string TL_selectingmonth_xpath = "html/body/div[8]/div[1]/table/thead/tr[1]/th[3]/i";
        public string TL_ErrormsgCalendar_xpath = ".//*[@id='date-validation-warning']/p";
        public string TL_DropoffCalendarPopup_xpath = ".//*[@class='datepicker datepicker-dropdown dropdown-menu datepicker-orient-left datepicker-orient-bottom']/div[1]";
        public string TL_disbaleddates_xpath = ".//*[@class='day disabled old']";
        public string TL_Errormsgheader_xpath = ".//*[@id='date-validation-warning']/h4";


        public string TL_StationName_Xpath = ".//*[@id='stationname_chosen']/a";
        public string TL_EquipmentType_Xpath = ".//*[@id='EquipmentType_chosen']/a";
        public string TL_SpecialInstructions_Id = "specialInstruction";


        //--------------------------- Frieght Description Section ------------------------------
        public string FreightDescriptionlable_xpath = "//div[@id='0']/div/div/div/h3";
        public string EnterDescriptionField_id = "FreightDescription-0";
        public string TLQuantity_id = "quantity-0";
        public string TLQuantityType_id = "quantityunit_0_chosen";
        public string TLQuantityType_xpath = ".//*[@id='quantityunit_0_chosen']/a/span";
        public string TLQuantityTypetextbox_xpath = ".//*[@id='quantityunit_0_chosen']/div/div/input";
        public string TLQuantityTypeFirstOption_xpath = ".//*[@id='quantityunit_0_chosen']/div/ul/li[1]";
        public string TLweight_id = "weight-0";
        public string TLWeightType_id = "weightunit_0_chosen";
        public string TLWeightTypeSecondOption_xpath = ".//*[@id='weightunit_0_chosen']/div/ul/li[2]";
        public string TLWeightType_xpath = ".//*[@id='weightunit_0_chosen']/a/span";
       public string TL_Description_Textbox_Id = "FreightDescription-0";
        public string TL_Quantity_Textbox_Id = "quantity-0";
        public string TL_Weight_Textbox_Id = "weight-0";
        public string TL_GetLiveQuote_Button_Xpath = ".//button[contains(text(), 'Get Live Quote')]";
        public string TL_InsuranceValue = ".//*[@id='Insvalue']";


        public string TL_pickstart = ".//*[@id='PickupreadyTo_chosen']/a";
        public string TL_pickstartdropvalues = ".//*[@id='PickupreadyTo_chosen']/div/ul/li";

        public string TL_pickend = ".//*[@id='PickupcloseFrom_chosen']/a";
        public string TL_pickenddropvalues = ".//*[@id='PickupcloseFrom_chosen']/div/ul/li";

        public string TL_dropstart = ".//*[@id='Pickupreadyshippingto_chosen']/a";
        public string TL_dropstartvalues = ".//*[@id='Pickupreadyshippingto_chosen']/div/ul/li";

        public string TL_dropend = ".//*[@id='PickupcloseshippingFrom_chosen']/a";
        public string TL_dropendvalues = ".//*[@id='PickupcloseshippingFrom_chosen']/div/ul/li";

        public string TL_pickerrorpopup = ".//*[@id='time-validation-warning']/p";
        public string TL_droperrorpopup = ".//*[@id='drop-time-validation-warning']/p";
        public string TL_clicklivequote = ".//*[@id='page-content-wrapper']/div[2]/div[2]/div[10]/div/button";
        public string TL_PickUpDate_Lable_xpath = ".//*[@id='page-content-wrapper']/div[2]/div[2]/div[3]/div[1]/div[4]/div[1]/h3";
        public string TL_DropOffDate_Lable_xpath = ".//*[@id='page-content-wrapper']/div[2]/div[2]/div[3]/div[2]/div[4]/div[1]/h3";

        public string TL_Hazmat_YesButton_xpath = ".//*[@id='0']/div[1]/div/div[2]/div/div[2]/div/div/div[1]/label";
        public string TL_Hazmat_NoButton_xpath = ".//*[@id='0']/div[1]/div/div[2]/div/div[2]/div/div/div[2]/label";


        //----------------------------------Hazmat

        public string TL_HazardousMaterials_Yes_Button_Xpath = ".//*[@id='0']/div[1]/div/div[2]/div/div[2]/div/div/div[1]/label";
        public string TL_HazardousMaterials_No_Button_Xpath = ".//*[@id='0']/div[1]/div/div[2]/div/div[2]/div/div/div[2]/label";
        public string TL_HazardousMaterials_UN_Number_Xpath = ".//*[@id='txtUNNumber-0']";
        public string TL_HazardousMaterials_CCN_Number_Xpath = ".//*[@id='txtfreight-CNnnumber-0']";
        public string TL_HazardousMaterials_HazMatPackageGroup_Dropdown_Xpath = ".//*[@id='Hazmatpackagegroup_0_chosen']/a";
        public string TL_HazardousMaterials_HazMatClass_Dropdown_Xpath = ".//*[@id='HazmatClass_0_chosen']/a";
        public string TL_HazardousMaterials_ResponseContactName_Xpath = ".//*[@id='txtEmrResContName-0']";
        public string TL_HazardousMaterials_EmergencyResponsePhone_Number_Xpath = ".//*[@id='txtEmrResPhNumber-0']";

        public string TL_GetLiveQuoteButton_xpath = ".//*[@id='page-content-wrapper']/div[2]/div[2]/div[10]/div/button";

        public string TL_AddAdditionalItem_Button_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div[2]/div[9]/div[2]/div/div/div/button";
        public string TL_AddAdditional_FreightDescription_Xpath = ".//*[@id='FreightDescription-1']";
        public string TL_AddAdditional_HazMatNo_RadioButton_Xpath = ".//*[@id='1']/div/div/div[2]/label";
        public string TL_AddAdditional_HazMatYes_RadioButton_Xpath = ".//*[@id='1']/div/div/div[1]/label";
        public string TL_AddAdditional_Quantity_Xpath = ".//*[@id='quantity-1']";
        public string TL_AddAdditional_QuantityType_Xpath = ".//*[@id='quantityunit_1_chosen']/a/span";
        public string TL_AddAdditional_Weight_Xpath = ".//*[@id='weight-1']";
        public string TL_AddAdditional_WeightType_Xpath = ".//*[@id='weightunit_1_chosen']/a/span";
        public string TL_AddAdditional_Remove_Button_Xpath = ".//*[@id='1']/div[3]/div/div/button";

        public string TL_AddAdditionalHazMat_UN_Number_Xpath = ".//*[@id='txtUNNumber-1']";
        public string TL_AddAdditionalHazMat_CCN_Number_Xpath = ".//*[@id='txtfreight-CNnnumber-1']";
        public string TL_AddAdditionalHazMat_HazMatPackageGroup_Dropdown_Xpath = ".//*[@id='Hazmatpackagegroup_1_chosen']/a/span";
        public string TL_AddAdditionalHazMat_HazMatClass_Dropdown_Xpath = ".//*[@id='HazmatClass_1_chosen']/a/span";
        public string TL_AddAdditionalHazMat_ResponseContactName_Xpath = ".//*[@id='txtEmrResContName-1']";
        public string TL_AddAdditionalHazMat_EmergencyResponsePhone_Number_Xpath = ".//*[@id='txtEmrResPhNumber-1']";

        public string TL_GetQuoteLiveButton_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div[2]/div[10]/div/button";
        public string TL_GetQuoteLiveButtonDisabled_Class = "btn livequote btn btn-warning";
        public string TL_LiveQuoteNotificationModal_Xpath = ".//*[@id='getlivequoteheader']";
        public string TL_LiveQuoteNotificationContent_Xpath = ".//*[@id='Email-content']";
        public string TL_LiveQuoteNotificationQuoteNum_Xpath = ".//*[@id='Email-quote']";
        public string TL_LiveQuoteNotificationOKButton_Xpath = ".//*[@id='Confirmation-mail-id']/div/div/div/div[3]/a";


    }



}
