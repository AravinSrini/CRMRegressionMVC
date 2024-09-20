using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Objects
{
    public class Submit_CSR : ObjectRepository
    {
        public string UserManagementIcon_Xpath = "//a[@id='usermanagement']";
        public string AccountManagementPage_Header_Xpath = "//h1[contains(text(),'Account Management')]";
        public string Customerprofiles_Xpath = ".//*[@id='user-mgmt']/li[1]/a";
        public string SearchCustomer_id = "customer-search-input";
        public string SearchedCustomer_Xpath = ".//*[@class='customer-account']//a";
        public string CustomerDetailsHeader_Xpath = ".//*[@class='customer-details']/div/h1";
        public string SubmitReviseCSRBtn_id = "submit-revise";
        public string GeneralRevision_id = "generalRevision";
        public string Revised_Pricing_Model = "//a[contains(@id, 'pricingModel')]";
        public string Loading_Icon_Id = "dvLoading";
        public string Approve_Csr_Button_Xpath = "//button[contains(@id, 'csr-status-approve')]";
        public string Confirm_Yes_Button_Xpath = "//button[contains(@id, 'yes-csr-approval')]";
        public string Creation_Status_Approve_Button_Xpath = "//button[contains(@id, 'pending-creation-status-approve')]";
        public string Approve_Save_Csr_Button_Xpath = "//button[contains(@id, 'save-csr-approve-both')]";
        public string Complete_Csr_Process_Button_Xpath = "//button[contains(@id, 'complete-csr-process')]";
        public string Submit_Csr_Process_Button_Xpath = "//button[contains(@id, 'yes-csr-process')]";
        public string Submit_Complete_Csr_Button_Xpath = "//button[contains(@id, 'submit-csr-approve-request')]";
        public string AccountManagement_List_First_Name = "//*[@id='customer-profile']/table/tbody/tr/td[1]/p/a";

        //---------------------------AccountInformation Page-----------------------
        public string AccountInfoHeader_Xpath = ".//*[@id='main']/div[2]/div/h3";
        public string RevisedCSRNameDisplay_Xpath = ".//*[@id='main']/div[2]/div/h5";
        public string StationId_DropDown_Xpath = ".//*[@id='primary_customer_account']/div/div[1]/div/div[1]/span[2]/span/span[1]";
        public string StationID_DropDown_List_Xpath = ".//*[@id='customer-station-id_listbox']/li";
        public string StationName_Textbox_Xpath = ".//*[@id='customer-station-name']";
        public string SalesRep_DropDown_Xpath = ".//*[@id='primary_customer_account']/div/div[2]/div/div[1]/span[2]/span/span[1]";
        public string SalesRep_DropDownList_Xpath = ".//*[@id='customer-sales-rep_listbox']/li";
        public string SalesRep_Other_Textbox_Xpath = ".//*[@id='sales-description']";
        public string LTLShippingDocument_BOL_Radiobutton_Xpath = ".//*[@id='ltl_shipmentdoc']/div/div/label[1]";
        public string EnterPriseType_DropDown_Xpath = ".//*[@id='main']/div[2]/div/div[1]/div[2]/div[2]/span[2]/span/span[1]";
        public string EnterPrise_DropDownList_Xpath = ".//*[@id='config-Enterprise-modal_listbox']/li";
        public string PrimaryCustomerAccount_Radibutton_Xpath = "//input[contains(@id, 'csr-type-1')]";
        public string SubAccount_CSRType_Radiobutton_Xpath = "//input[contains(@id, 'csr-type-2')]";
        public string PrimaryAccount_Csr_RadioButton_Clickable_Xpath = "//*[@id='main']/div[2]/div/div[1]/div[2]/div[1]/div/div/div[1]/label[1]";
        public string SubAccount_Csr_RadioButton_Clickable_Xpath = "//*[@id='main']/div[2]/div/div[1]/div[2]/div[1]/div/div/div[1]/label[2]";
        public string SelectPrimaryAcctDropDown_Xpath = ".//*[@id='customer_primary_account_select_chosen']/a/span";
        public string SelectPrimaryAcctDropDownValues_Xpath = "//*[@id='customer_primary_account_select_chosen']/div/ul";//or use selectct 1st value click
        public string TMS_Type_MG_Radiobutton_Xpath = ".//*[@id='border-line']/div/div/label[1]";
        public string TMS_Type_CSA_Radiobutton_Xpath = ".//*[@id='border-line']/div/div/label[2]";
        public string TMS_Type_BOTH_Radiobutton_Xpath = ".//*[@id='border-line']/div/div/label[3]";
        public string CustomerAccountName_Textbox = ".//*[@id='customer-account-name']";
        public string ShipmentNotificationEmail_Textbox_Xpath = ".//*[@id='customer-station-email']";
        public string CSA_CustomerNumber_Textbox_Xpath = ".//*[@id='csa-customer-number']";
        public string CustomerInvoiceMethod_Dropdown_Xpath = ".//*[@id='main']/div[2]/div/div[2]/div[1]/div[1]/span[2]/span/span[1]";
        public string CustomerInvoiceMethod_Dropdown_value_Xpath = ".//*[@id='customer-invoice-method_listbox']/li";
        public string CustomerInvoiceBackUp_Dropdown_Xpath = ".//*[@id='main']/div[2]/div/div[2]/div[2]/div[1]/span[2]/span/span[1]";
        public string CustomerInvoiceBackUp_Dropdown_value_Xpath = ".//*[@id='customer-invoice-backup_listbox']/li";
        public string CreditCard_RadioButton_No_Xpath = ".//*[@id='main']/div[2]/div/div[2]/div[2]/div[2]/div/label[2]";
        public string AccountInformation_SaveAndContinueButton_Xpath = ".//*[@id='save-account-information']";

        public string View_Csr_List_Button_Xpath = "//a[contains(@id, 'viewCsrListBtn')]";
        public string Submit_Csr_Button_Xpath = "//a[contains(@id, 'submitCsrBtn')]";
        public string Station_Id_DropDown_Xpath = "//select[contains(@id, 'customer-station-id')]";
        public string Primary_CSR_Type_Xpath = "//label[contains(@for, 'csr-type-1')]";
        public string Primary_Csr_Type_Radio_Xpath = "//input[contains(@id, 'csr-type-1')]";
        public string Sub_CSR_Type_Xpath = "//label[contains(@for, 'csr-type-2')]";

        public string TMS_System_MG_Input_Xpath = "//input[contains(@id, 'tms-systems-1')]";
        public string TMS_System_MG_Xpath = "//label[contains(@for, 'tms-systems-1')]";
        public string Customer_Account_Name_Xpath = "//input[contains(@id, 'customer-account-name')]";
        public string Customer_Invoice_Method_Xpath = "//select[contains(@id, 'customer-invoice-method')]";
        public string Save_And_Continue_Xpath = "//a[contains(@id, 'save-account-information')]";

        public string TMS_System_MG_Clickable_Xpath = "//*[@id='tms-systems-1']";

        //---------------------------------Locations and Contacts Page----------------------
        public string LocationsPage_Header_Xpath = ".//*[@id='main']/div[2]/div/h3";
        public string CustomerLocation_Name_Textbox_Xpath = "//input[contains(@id, 'customer-location-name')]";
        public string CustomerLocation_Address1_Textbox_Xpath = "//input[contains(@id, 'customer-location-address-1')]";
        public string CustomerLocation_Address2_Textbox_Xpath = ".//*[@id='customer-location-address-2']";
        public string CustomerLocation_City_Textbox_Xpath = "//input[contains(@id, 'customer-location-city')]";
        public string CustomerLocation_StateDropDown_Xpath = ".//*[@id='customer-location-form']/div[6]/div[1]/div[1]/span[2]/span/span[1]";
        public string CustomerLocation_StateDropDownList_Xpath = ".//*[@id='state-customer-location-select_listbox']/li";
        public string CustomerLocation_CountryDropDown_Xpath = ".//*[@id='customer-location-form']/div[5]/div/span[2]/span/span[1]";
        public string CustomerLocation_CountryDropdownList_Xpath = ".//*[@id='customer-location-country_listbox']/li";
        public string CustomerLocation_Zip_Textbox_Xpath = "//input[contains(@id, 'customer-location-zip')]";
        public string CustomerContactInformation_Name_Textbox_Xpath = ".//*[@id='customer-contact-name']";
        public string CustomerContactInformation_PhoneNumber_Textbox_Xpath = ".//*[@id='customer-contact-phone']";
        public string CustomerContactInformation_Email_Textbox_Xpath = ".//*[@id='customer-contact-email']";
        public string CustomerContactInformation_FaxNumber_Textbox_Xpath = ".//*[@id='customer-contact-fax']";
        public string CustomerContactInformation_Website_textbox_Xpath = ".//*[@id='customer-contact-website']";
        public string CheckBox_UseCustomerLocation_ContactInformation_for_BillToLocation_Contact_Details = ".//*[@id='main']/div[2]/div/div[2]/div/label";
        public string ResidentialLocation_Checkbox_Xpath = ".//*[@id='customer-location-form']/div[7]/div/label";
        public string CustomerLocation_Comments_Textbox_Xpath = ".//*[@id='customer-location-comments']";
        public string LocationsAndContacts_SaveAndContinueButton_Xpath = ".//*[@id='save-location-contact']";

        //--------------------------------------Pricing--------------------------------

        public string PricingPage_Text_Xpath = ".//*[@id='main']/div[2]/div/h3";
        public string PricingType_DropDown_Xpath = ".//*[@id='main']/div[2]/div/div[1]/div/span[2]/span/span[1]";
        public string PricingType_DropDownDropDownList_Xpath = "//div[@class='k-animation-container km-popup']/div[@id='discount-type-list']/ul[@id='discount-type_listbox']/li";//Check this Xpath
        public string PricingModel_Gainshare_New_Logic_Label_Xpath = "//label[contains(@for, 'gainshare-new-logic-checkbox')]";
        public string PricingModel_Gainshare_New_Logic_Checkbox_Xpath = "//label[contains(@for, 'gainshare-new-logic-checkbox')]";
        public string PricingModel_Gainshare_New_Logic_Checkbox_Input_Xpath = "//input[contains(@id, 'gainshare-new-logic-checkbox')]";
        public string PricingModel_SaveAndContinuebutton = ".//*[@id='save-Pricing-Model']";
        public string PricingModel_Carriers_Excluded_Radio_Xpath = "//label[contains(@for, 'pricing-carriersExclud-no')]";
        public string PricingModel_HouseHold_Goods_Radio_Xpath = "//label[contains(@for, 'pricing-household-no')]";
        public string PricingModel_Minimum_Gainshare_Percentage_Xpath = "//*[@id='pricing-min-amount']";

        //--------------------------------------Gainshare Pricing-----------------------------------

        public string Gainshare_Section_Xpath = "//div[contains(@id, 'gainshare-container')]";
        public string Gainshare_First_Carrier_Individual_Accessorial_Xpath = "//span[contains(@id, 'set-accessorial1')]";
        public string Gainshare_First_Carrier_Individual_Accessorial_Modal_Value_Xpath = "//input[contains(@id, 'flat-over-pricing-setGainshare1')]";
        public string Gainshare_First_Carrier_Section = "//div[contains(@id, 'addtionalItem-0')]";
        public string Gainshare_Set_Individual_Accessorials_Xpath = "//span[contains(@id, 'set-accessorial')]";

        public string Gainshare_Individual_Accessorial_Added_Last_Cost_Xpath = "//div[not(contains(@class, 'hidden'))]/div[not(contains(@class, 'hidden'))]/div[last()][contains(@class, 'addedRow')]/div[contains(@class, 'set-gainshare')]/div[not(contains(@class, 'hidden'))]//input";
        public string Gainshare_Individual_Accessorial_Default_Last_Cost_Xpath = "//div[not(contains(@class, 'hidden'))]/div[not(contains(@class, 'hidden'))]/div[contains(@class, 'AccessorialRow')]/div/div[contains(@id, 'div-gainshare-value')]/div[not(contains(@class, 'hidden'))]//input";
        public string Gainshare_Add_Carrier_Specific_Gainshare_Pricing_Xpath = "//*[@id='add-gainshare-pricing']";

        public string Gainshare_Delete_Individual_Accessorials_Button_Xpath = "//span[contains(@id, 'btnDeleteAccessorials')]";
        public string Gainshare_Delete_Individual_Accessorials_Modal_Xpath = "//div[contains(@id, 'delete-accessorials-modal')]";
        public string Gainshare_Delete_Individual_Accessorials_Accessorial_Prefix_Xpath = "//label[contains(@for, 'FilterByStatus')]";
        public string Gainshare_Delete_Individual_Accessorial_Delete_Button_Xpath = "//a[contains(@id, 'btnModelDeleteAccessorial')]";

        public string Gainshare_Individual_Accessorial_Modal_Xpath = "//div[contains(@id, 'set-accessorial-modal')]";
        public string Gainshare_Individual_Accessorial_First_Accessorial_Name_Xpath = "//div[contains(@id , 'setAccessorial1_chosen')]";
        public string Gainshare_Individual_Accessorial_First_Accessorial_Gainshare_Xpath = "//div[contains(@id , 'setGainShareType1_chosen')]";
        public string Gainshare_Individual_Accessorial_First_Accessorial_Cost_Xpath = "//div[contains(@id , 'pricing-setGainshare1_chosen')]";
        public string Gainshare_Individual_Accessorial_Second_Accessorial_Name_Xpath = "//div[contains(@id , 'setAccessorial1_chosen')]";
        public string Gainshare_Individual_Accessorial_Second_Accessorial_Gainshare_Xpath = "//div[contains(@id , 'setGainShareType1_chosen')]";
        public string Gainshare_Individual_Accessorial_Second_Accessorial_Cost_Xpath = "//div[contains(@id , 'pricing-setGainshare1_chosen')]";
        public string Gainshare_Individual_Accessorial_Modal_Save_Xpath = "//a[contains(@id, 'btn-save-accessorial')]";
        public string Gainshare_Individual_Accessorial_Modal_Pricing_Xpath = "//input[contains(@id, 'pricing-setGainshare1')]";
        public string Gainshare_Individual_Accessorial_Modal_Close_Xpath = "//a[contains(@class, 'submit-csr-cancel-accessorial')]";
        public string Gainshare_Individual_Accessorial_Modal_Add_Accessorial = "//span[contains(@id, 'Add-accessorial')]";

        public string Gainshare_Carrier_Accessorial_List_Xpath = "//div[contains(@id, 'addtionalItem-')]";
        public string Gainshare_Add_Carrier_Pricing_Xpath = "//span[contains(@id, 'add-gainshare-pricing')]";
        public string Gainshare_carrier_Set_Accessorials_Span_Xpath = "//span[contains(@class, 'set-accessorial-modal-class-id')]";
        public string Gainsshare_Carrier_ScacCode_General_Xpath = "//div[contains(@id, 'carrier_scac_code_')]/a/span";
        public string Gainshare_Carrier_ScacCode_1_Xpath = "//*[@id='carrier_scac_code_0_chosen']/a/span";
        public string Gainshare_Carrier_ScacCode_1_DropdownList_Xpath = "//*[@id='carrier_scac_code_0_chosen']/div/ul/li";
        public string Gainshare_Carrier_ScacCode_2_Xpath = "//*[@id='carrier_scac_code_1_chosen']/a/span";
        public string Gainshare_Carrier_ScacCode_2_DropdownList_Xpath = "//*[@id='carrier_scac_code_1_chosen']/div/ul/li";
        public string Gainshare_Carrier_ScacCode_3_Xpath = "//*[@id='carrier_scac_code_2_chosen']/a/span";
        public string Gainshare_Carrier_ScacCode_3_DropdownList_Xpath = "//*[@id='carrier_scac_code_2_chosen']/div/ul/li";

        public string Gainshare_Carrier_Gainshare_Percentage_Field_1_Xpath = "//*[@id='gainshare-percentage-0']";
        public string Gainshare_Carrier_Gainshare_Percentage_Field_2_Xpath = "//*[@id='gainshare-percentage-1']";
        public string Gainshare_Carrier_Gainshare_Percentage_Field_3_Xpath = "//*[@id='gainshare-percentage-2']";

        public string Gainshare_Carrier_SetIndividualAccessorials_1_Xpath = "//*[@id='set-accessorial1']";
        public string Gainshare_Carrier_SetIndividualAccessorials_3_Xpath = "//*[@id='set-accessorial3']";
        public string Gainshare_Carrier_SetIndividualAccessorials_Modal_AccessorialType_Dropdown = "//*[@id='setAccessorial1_chosen']/a/span";
        public string Gainshare_Carrier_SetIndividualAccessorials_Modal_AccessorialType_Dropdown_Values = "//*[@id='setAccessorial1_chosen']/div/ul/li";
        public string Gainshare_Carrier_SetIndividualAccessorials_Modal_AccessorialType_Dropdown_2 = "//*[@id='setAccessorial2_chosen']/a/span";
        public string Gainshare_Carrier_SetIndividualAccessorials_Modal_AccessorialType_Dropdown_Values_2 = "//*[@id='setAccessorial2_chosen']/div/ul/li";
        public string Gainshare_Carrier_SetIndividualAccessorials_Modal_GainshareType_Dropdown = "//*[@id='setGainShareType1_chosen']/a/span";
        public string Gainshare_Carrier_SetIndividualAccessorials_Modal_GainshareType_Dropdown_2 = "//*[@id='setGainShareType2_chosen']/a/span";
        public string Gainshare_Carrier_SetIndividualAccessorials_Modal_GainshareType_Dropdown_Values = "//*[@id='setGainShareType1_chosen']/div/ul/li";
        public string Gainshare_Carrier_SetIndividualAccessorials_Modal_Save = "//*[@id='btn-save-accessorial']";
        public string Gainshare_Carrier_SetIndividualAccessorials_Modal_PercentOverCost = "//*[@id='percentage-over-pricing-setGainshare1']";
        public string Gainshare_Carrier_SetIndividualAccessorials_Modal_FlatOverCost = "//*[@id='flat-over-pricing-setGainshare1']";
        public string Gainshare_Carrier_SetIndividualAccessorials_Modal_FlatOverCost2 = "//*[@id='flat-over-pricing-setGainshare2']";

        public string Gainshare_Carrier_SetIndividualAccessorials_Modal_Overlength_Value_Over8 = "//*[@id='ovl8']";
        public string Gainshare_Carrier_SetIndividualAccessorials_Modal_Overlength_Value_Over9 = "//*[@id='ovl9']";
        public string Gainshare_Carrier_SetIndividualAccessorials_Modal_Overlength_Value_Over10 = "//*[@id='ovl10']";
        public string Gainshare_Carrier_SetIndividualAccessorials_Modal_Overlength_Value_Over11 = "//*[@id='ovl11']";
        public string Gainshare_Carrier_SetIndividualAccessorials_Modal_Overlength_Value_Over12 = "//*[@id='ovl12']";
        public string Gainshare_Carrier_SetIndividualAccessorials_Modal_Overlength_Value_Over13 = "//*[@id='ovl13']";
        public string Gainshare_Carrier_SetIndividualAccessorials_Modal_Overlength_Value_Over14 = "//*[@id='ovl14']";
        public string Gainshare_Carrier_SetIndividualAccessorials_Modal_Overlength_Value_Over15 = "//*[@id='ovl15']";
        public string Gainshare_Carrier_SetIndividualAccessorials_Modal_Overlength_Value_Over16 = "//*[@id='ovl16']";
        public string Gainshare_Carrier_SetIndividualAccessorials_Modal_Overlength_Value_Over17 = "//*[@id='ovl17']";
        public string Gainshare_Carrier_SetIndividualAccessorials_Modal_Overlength_Value_Over18 = "//*[@id='ovl18']";
        public string Gainshare_Carrier_SetIndividualAccessorials_Modal_Overlength_Value_Over19 = "//*[@id='ovl19']";
        public string Gainshare_Carrier_SetIndividualAccessorials_Modal_Overlength_Value_Over20 = "//*[@id='ovl20']";
        public string Gainshare_Carrier_SetIndividualAccessorials_Modal_Overlength_Value_Over21 = "//*[@id='ovl21']";
        public string Gainshare_Carrier_SetIndividualAccessorials_Modal_Overlength_Value_Over22 = "//*[@id='ovl22']";
        public string Gainshare_Carrier_SetIndividualAccessorials_Modal_Overlength_Value_Over23 = "//*[@id='ovl23']";
        public string Gainshare_Carrier_SetIndividualAccessorials_Modal_Overlength_Value_Over24 = "//*[@id='ovl24']";
        public string Gainshare_Carrier_SetIndividualAccessorials_Modal_Overlength_Value_Over25 = "//*[@id='ovl25']";
        public string Gainshare_Carrier_SetIndividualAccessorials_Modal_Overlength_Value_Over26 = "//*[@id='ovl26']";
        public string Gainshare_Carrier_SetIndividualAccessorials_Modal_Overlength_Value_Over27 = "//*[@id='ovl27']";
        public string Gainshare_Carrier_SetIndividualAccessorials_Modal_Overlength_Value_Over28 = "//*[@id='ovl28']";
        public string Gainshare_Carrier_SetIndividualAccessorials_Modal_Overlength_Value_Over29 = "//*[@id='ovl29']";
        public string Gainshare_Carrier_SetIndividualAccessorials_Modal_Overlength_Value_Over30 = "//*[@id='ovl30']";

        public string Gainshare_Added_Individual_Accessorials_Xpath = "//span[contains(@id, 'AccType0')]";
        public string Gainshare_First_Added_Carrier_Individual_Accessorials_Xpath = "//span[contains(@id, 'AccType1')]";
        public string Gainshare_Third_Added_Carrier_Individual_Accessorials_Xpath = "//*[@id='AccType3']";
        public string Gainshare_percentage_Id = "pricing-percentage";
        public string Gainshare_MinThreshold_Charge_Id = "pricing-min-threshold";
        public string Gainshare_MinAmount_Added_Id = "pricing-min-amount";
        public string Gainshare_Minimum_Textbox_xpath = "//input[contains(@id, 'pricing-minimum')]";
        public string Gainshare_Master_Accessorial_Charge_Textbox_Xpath = "//input[contains(@id, 'pricing-master-Acc')]";
        public string Gainshare_carriersExcluded_No_Radiobutton_Xpath = "//input[contains(@id, 'pricing-carriersExclud-no')]";
        public string Gainshare_Household_Goods_No_Radiobutton_Xpath = "//input[contains(@id, 'pricing-household-no')]";
        public string RatingInstructions_RateProvisions_Textbox_Id = "rating-instructions";

        //----------------------------------------Tariff dropdown--------------------------
        public string Tariff_dropdown_Xpath = ".//*[@id='tariff-container']/div/div[1]/div[1]/span[2]/span/span[1]";
        public string Tariff_dropdown_value_Xpath = ".//*[@id='pricing-tariff-select_listbox']/li";
        public string Tariff_discount_Textbox_Xpath = ".//*[@id='tariff-discount']";
        public string Tariff_Minimum_Textbox_Xpath = ".//*[@id='tariff-minimum']";
        public string Tariff_carriers_No_Radiobutton_Xpath = ".//*[@id='tariff-container']/div/div[2]/div[1]/div/label[2]";
        public string Tariff_HouseHold_Goods_No_Radiobutton_Xpath = ".//*[@id='tariff-container']/div/div[2]/div[2]/div/label[2]";
        public string Tariff_SpecialRate_Provisions_Textbox_Xpath = ".//*[@id='tariff-special-provisions']";

        //-------------------------------------SavedItems and Address Page-------------------------------
        public string SavedItemsAddressLeftWizard_id = "customer-saved";
        public string SavetItems_Address_Page_Header_Xpath = ".//*[@id='main']/div[2]/div/h3";
        public string Item_Template_eDropzone_Id = "saved-item-dropzone";//Check this Xpath
        public string Address_Template_Dropzone_Id = "saved-address-dropzone";//Check this Xpath
        public string SavedItemsAndAddresses_SaveAndContinue_button_Xpath = ".//*[@id='save-item-address']";

        public string Create_A_SavedItem_button_Xpath = ".//*[@id='add-item']";
        public string Classification_dropdown_Xpath = ".//*[@id='add-item-modal']/div[1]/div[1]/span[2]/span/span[1]";
        public string Calssification_dropdown_Value_Xpath = ".//*[@id='add-item-classification_listbox']/li";
        public string NMFC_textbox_Xpath = ".//*[@id='add-item-nmfc']";
        public string Item_Description_textbox_Xpath = ".//*[@id='add-item-description']";
        public string HazardousMaterial_No_Radiobutton_Xpath = ".//*[@id='add-item-modal']/div[6]/div/div/label[2]";
        public string Save_Itembutton_Xpath = ".//*[@id='save-new-item']";

        public string Create_A_SavedAddress_button_Xpath = ".//*[@id='add-address']";
        public string Create_A_SavedAddress_Name_textbox_Xpath = ".//*[@id='add-address-name']";
        public string Create_A_SavedAddress_Address1_Textbox_Xpath = ".//*[@id='add-address-address1']";
        public string Create_A_SavedAddress_Address2_Textbox_Xpath = ".//*[@id='add-address-address2']";
        public string Create_A_SavedAddress_City_Textbox_Xpath = ".//*[@id='add-address-city']";
        public string Create_A_SavedAddress_Country_dropdown_Xpath = ".//*[@id='add-address-modal']/div[4]/div[2]/span[2]/span/span[1]";
        public string Create_A_SavedAddress_Country_dropdownList_Xpath = ".//*[@id='add-addres-country_listbox']/li";
        public string Create_A_SavedAddress_State_dropdown_Xpath = ".//*[@id='div-state']/div[1]/span[2]/span/span[1]";
        public string Create_A_SavedAddress_State_dropdownList_Xpath = ".//*[@id='add-address-state_listbox']/li";
        public string Create_A_SavedAddress_Zip_Xpath = ".//*[@id='add-address-zip']";
        public string Create_A_SavedAddress_ContactName_Textbox_Xpath = ".//*[@id='add-address-contact-name']";
        public string Create_A_SavedAddress_ContactPhoneNumber_Textbox_Xpath = ".//*[@id='add-address-contact-phone']";
        public string Create_A_SavedAddress_ContactEmail_Textbox_Xpath = ".//*[@id='add-address-contact-email']";
        public string Create_A_SavedAddress_ContactFaxNumber_Textbox_Xpath = "d='add-address-contact-fax']";
        public string Create_A_SavedAddress_Save_button_Xpath = ".//*[@id='add-address-modal']/div[12]/div[2]/button";
        public string Saved_Address_Back_Button_Xpath = "//a[(@id='btn-back')]";

        //-------------------------------------PortalUsers-------------------------------------
        public string PortalUsersPage_Header_Xpath = ".//*[@id='main']/div[2]/div/h3";
        public string PortalUsers_Yes_Radiobutton_Xpath = ".//*[@id='main']/div[2]/div/div[1]/div/div/label[1]";
        public string PortaUsers_Template_Dropzone_Xpath = ".//*[@id='saved-portal-dropzone']/div";
        public string PortalUsers_SaveAndContinue_button_Xpath = ".//*[@id='save-portal-users']";

        public string Create_A_PortalUser_button_Xpath = ".//*[@id='add-portal']";
        public string Create_A_PortalUser_FirstName_Textbox_Xpath = ".//*[@id='portal-user-first-name']";
        public string Create_A_PortalUser_LastName_Textbox_Xpath = ".//*[@id='portal-user-second-name']";
        public string Create_A_PortalUser_EmailAddress_Textbox_Xpath = ".//*[@id='portal-user-email']";
        public string Create_A_PortalUser_UserType_dropdown_Xpath = ".//*[@id='add-new-user']/div[3]/div/span[2]/span/span[1]";
        public string Create_A_PortalUser_UserType_dropdownList_Xpath = ".//*[@id='portal-user-type-combo_listbox']/li";
        public string Create_A_PortalUser_TMSType_dropdown_Xpath = ".//*[@id='tms_type_select_chosen']/ul/li/input";
        public string Create_A_PortalUser_TMSType_dropdownList_Xpath = ".//*[@id='tms_type_select_chosen']/div/ul/li";
        public string Create_A_PortalUser_OfficeNumber_Textbox_Xpath = ".//*[@id='portal-user-office']";
        public string Create_A_PortalUser_MobileNumber_Textbox_Xpath = ".//*[@id='portal-user-mobile']";
        public string Create_A_PortalUser_FaxNumber_Textbox_Xpath = ".//*[@id='portal-user-fax']";
        public string Create_A_PortalUser_Next_button_Xpath = ".//*[@id='create-new-portal-user']";
        public string Create_A_PortalUser_CreateUser_button_Xpath = ".//*[@id='submit-create-user']";




        //-------------------------------Review And Submit Page
        public string ReviewAndSubmitPage_Header_Xpath = ".//*[@id='main']/div[2]/div/h3";
        public string ReviewSubmitPage_StationId_Value_Xpath = ".//*[@id='dv-station-id']";
        public string ReviewSubmitPage_Station_Name_Value_Xpath = ".//*[@id='dv-station-name']";
        public string ReviewSubmitPage_SalesRep_Value_Text_Xpath = ".//*[@id='dv-sales-rep']";
        public string ReviewSubmitPage_SalesRep_Other_Value_ID = "";
        public string ReviewSubmitPage_EnterpriseType_Value_Xpath = ".//*[@id='dv-enterprise-type']";
        public string ReviewSubmitPage_CustLoc_Name_Value_Xpath = ".//*[@id='Customer-Loc-Name']";
        public string ReviewSubmitPage_CustLoc_Address1_Value_Xpath = ".//*[@id='Customer-Loc-Address1']";
        public string ReviewSubmitPage_CustLoc_Address2_Value_Xpath = ".//*[@id='Customer-Loc-Address2']";
        public string ReviewSubmitPage_CustLoc_CityStateZip_Value_Xpath = ".//*[@id='Customer-Loc-City']";
        public string ReviewSubmitPage_CustLoc_State_Value_Xpath = "";
        public string ReviewSubmitPage_CustLoc_Zip_Value_Xpath = "";
        public string ReviewSubmitPage_CustLoc_Country_Value_Xpath = ".//*[@id='Customer-Loc-Country']";
        public string ReviewSubmitPage_CustLoc_Residential_Location_Value_Xpath = ".//*[@id='Customer-Loc-residential']";
        public string ReviewSubmitPage_CustLoc_Comments_Value_Xpath = ".//*[@id='Customer-Loc-Comments']";
        public string ReviewSubmitPage_Submit_Csr_Button_Xpath = "//a[contains(@id, 'save-account-information')]";

        //---------------------------------Bill to Location

        public string ReviewSubmitPage_BillToLoc_Name_Value_Xpath = ".//*[@id='Bill-Loc-Name']";
        public string ReviewSubmitPage_BillToLoc_Address1_Value_Xpath = ".//*[@id='Bill-Loc-Address1']";
        public string ReviewSubmitPage_BillToLoc_Address2_Value_Xpath = ".//*[@id='Bill-Loc-Address2']";
        public string ReviewSubmitPage_BillToLoc_CityStateZip_Value_Xpath = ".//*[@id='Bill-Loc-City']";
        public string ReviewSubmitPage_BillToLoc_State_Value_Xpath = "";
        public string ReviewSubmitPage_BillToLoc_Country_Value_Xpath = ".//*[@id='Bill-Loc-Country']";
        public string ReviewSubmitPage_BillToLoc_Comments_Value_Xpath = ".//*[@id='Bill-Loc-Comments']";

        //Customer Contact Information
        public string ReviewSubmitPage_CustContactInfo_Name_Value_Xpath = ".//*[@id='Customer-Contact-Name']";
        public string ReviewSubmitPage_CustContactInfo_PhoneNumber_Value_Xpath = ".//*[@id='Customer-Contact-Number']";
        public string ReviewSubmitPage_CustContactInfo_Email_Value_Xpath = ".//*[@id='Customer-Contact-Email']";
        public string ReviewSubmitPage_CustContactInfo_FaxNumber_Value_Xpah = ".//*[@id='Customer-Contact-Fax']";
        public string ReviewSubmitPage_CustContactInfo_Website_Value_Xpath = ".//*[@id='Customer-Contact-Web']";

        //Bill To Contact Information
        public string ReviewSubmitPage_BillToContactInfo_Name_Value_Xpath = ".//*[@id='Bill-Contact-Name']";
        public string ReviewSubmitPage_BillToContactInfo_Phone_Value_Xpath = ".//*[@id='Bill-Contact-Number']";
        public string ReviewSubmitPage_BillToContactInfo_Email_Value_Xpath = ".//*[@id='Bill-Contact-Email']";
        public string ReviewSubmitPage_BillToContactInfo_Fax_Value_Xpath = ".//*[@id='Bill-Contact-Fax']";
        public string ReviewSubmitPage_BillToContactInfo_Website_Value_Xpath = ".//*[@id='Bill-Contact-Web']";

        public string ReviewSubmitPage_CustomerInvoiceMethod_Value_Xpath = ".//*[@id='dv-custinvoice-method']";
        public string ReviewSubmitPage_CustomerInvoiceBackUp_Value_Xpath = ".//*[@id='dv-custinvoice-backup']";
        public string ReviewSubmitPage_CreditCard_Value_Xpath = ".//*[@id='dv-credit-card']";

        public string ReviewSubmitPage_Gainshare_Header_Value_Xpath = ".//*[@id='Pricing-Gainshare-Details']/div/div[1]/h5";
        public string ReviewSubmitPage_percentage_Value_Xpath = ".//*[@id='Percentage']";
        public string ReviewSubmitPage_Gainshare_MinThreshold_Charge_Value_Xpath = ".//*[@id='MinThreshold']";
        public string ReviewSubmitPage_Gainshare_MinAmount_Added_Value_Xpath = ".//*[@id='MinAmount']";
        public string ReviewSubmitPage_Gainshare_carriersExcluded_Value_Xpath = ".//*[@id='ExcludedCarriers']";
        public string ReviewSubmitPage_Gainshare_HouseholdGoods_Value_Xpath = ".//*[@id='HouseholdGoods']";
        public string ReviewSubmitPage_Gainshare_RatingInst_RateProvison_Value_Xpath = ".//*[@id='SpecialInstr']";

        public string ReviewSubmitPage_PricingModel_IndividualCharge_Xpath = "//div[contains(@id, 'CustAccessorial')]";
        public string ReviewSubmitPage_PricingModel_MasterCharge_Xpath = "//div[contains(@id, 'MasterAcceCharge')]";
        public string ReviewSubmitPage_Gainshare_New_Logic_Xpath = "//div[contains(@id, 'Gainshare-New-Logic')]";

        public string ReviewSubmitPage_Tariff_Header_Value_Xpath = ".//*[@id='Pricing-Tariff-Details']/div/div/h5";
        public string ReviewSubmitPage_Tariff_Type_Value_Xpath = ".//*[@id='PricingTariff']";
        public string ReviewSubmitPage_Tariff_Discount_Value_Xpath = ".//*[@id='TariffDiscount']";
        public string ReviewSubmitPage_Tariff_Minimum_Value_Xpath = ".//*[@id='TariffMin']";
        public string ReviewSubmitPage_Tariff_carriersExcluded_Value_Xpath = ".//*[@id='TariffExcludedCarriers']";
        public string ReviewSubmitPage_Tariff_HouseholdGoods_Value_Xpath = ".//*[@id='TariffHouseholdGoods']";
        public string ReviewSubmitPage_Tariff_SpecialRatingProvisions_Value_Xpath = ".//*[@id='TariffSplInstr']";

        public string ReviewSubmitPage_OnlyAddressTemplate_id = "review-address-file";
        public string ReviewSubmitPage_Item_Template_Value_Xpath = "(//span[@id='review-address-file'])[1]";
        public string ReviewSubmitPage_Address_Template_Value_Xpath = "(//span[@id='review-address-file'])[2]";
        public string ReviewSubmitPage_PortalUsers_Template_Value_Xpath = "(//span[@id='review-address-file'])[3]";

        public string ReviewSubmitPage_Item_Classification_Value_Xpath = ".//*[@id='item-table']/table/tbody/tr/td[1]";
        public string ReviewSubmitPage_Item_NMFC_Value_Xpath = ".//*[@id='item-table']/table/tbody/tr/td[2]";
        public string ReviewSubmitPage_Item_description_Value_Xpath = ".//*[@id='item-table']/table/tbody/tr/td[3]";
        public string ReviewSubmitPage_Item_Hazmat_Value_Xpath = ".//*[@id='item-table']/table/tbody/tr/td[4]";


        public string ReviewSubmitPage_Address_Name_Value_Xpath = ".//*[@id='address-table']/table/tbody/tr/td[1]";
        public string ReviewSubmitPage_Address_City_Value_Xpath = ".//*[@id='address-table']/table/tbody/tr/td[2]";
        public string ReviewSubmitPage_Address_State_Province_Value_Xpath = ".//*[@id='address-table']/table/tbody/tr/td[3]";
        public string ReviewSubmitPage_Address_Zip_Value_Xpath = ".//*[@id='address-table']/table/tbody/tr/td[4]";

        public string ReviewSubmitPage_PortalUser_Name_Value_Xpath = ".//*[@id='user-table']/table/tbody/tr/td[1]";
        public string ReviewSubmitPage_PortalUser_UserType_Value_Xpath = ".//*[@id='user-table']/table/tbody/tr/td[2]";
        public string ReviewSubmitPage_PortalUser_TMSType_Value_Xpath = ".//*[@id='user-table']/table/tbody/tr/td[3]";




        public string ReviewSubmitPage_SubmitButton_Xpath = "(//a[@class='steps-link submit-link'])";
        public string CSR_Submitted_Text_Xpath = ".//*[@id='csr-submit']/h3[1]";
        public string ReviewSubmitPage_Close_button_Xpath = "//*[@id='csr-submit']/div/a";

        //----------------------------------------CSR List Page
        public string CSRList_Searchbox_Xpath = ".//*[@id='csr-list-search-input']";
        public string SearchedCustomerAccount_Grid_Xpath = ".//*[@id='csr-list-tbl']/table/tbody/tr/td[1]";
        public string NoSearcheddataforCSR_Grid_Xpath = ".//*[@class='no-highlight']";


        //----------------------------------Customer Details--------------------------
        public string CustomerDetailspageHeader_Xpath = "//h1[contains(text(),'Customer Details')]";
        public string CustomerDetails_CustomerName_Id = "h-customer-name";

        public string CSRSubmittedSuccessfullyText = "This CSR has been submitted";

        //----------------------------------------CSR Details Page
        public string waitingToProcessApproveButton_Xpath = "//*[@id='pending-creation-status-approve']";
        public string waitingToProcessConfirmApprovalButton_Xpath = "//*[@id='yes-csr-approval']";
        public string waitingToProcessMoreInformationApproveButton_Xpath = "//*[@id='save-csr-approve-both']";
        public string completeCSRProcessButton_Xpath = "//*[@id='complete-csr-process']";
        public string completeCSRProcessSubmitButton_Xpath = "//*[@id='yes-csr-process']";
        public string completeCSRProcessCompleteRequestSubmitButton_Xpath = "//*[@id='submit-csr-approve-request']";
        public string completeCSRProcessPricingConfigurationCompleteButton_Xpath = "//*[@id='csr-status-complete']";
        public string completeCSRProcessPricingConfigurationCompleteClose_Xpath = "//*[@id='close-csr-completed']";
        public string CustomerDetails_CRM_Rating_Logic_Value_Xpath = "//span[contains(@id, 'CRMRatingLogicApplied')]";
        public string CustomerDetails_Expand_Pricing_Model_Xpath = "//div[contains(@class, 'customer-details')]/div[3]/div[5]//div[contains(@class, 'dropdown-header-button expand-icon')]";
        public string CustomerDetails_Edit_Gainshare_Span_Xpath = "//div[contains(@id, 'pricing-model-body')]//span[contains(@id, 'gainshare-edit')]/span[contains(@class, 'edit-text')]";
        public string CustomerDetails_Insurance_Section_Xpath = "//div[contains(@id, 'dv-insallrisk-spn')]";
        public string CustomerDetails_Edit_Gainshare_Modal_Xpath = "//div[contains(@id, 'pricing-gainshare')]";

        public string CustomerDetails_Edit_Gainshare_Modal_Apply_Rating_Logic_Checkbox_Input_Xpath = "//input[contains(@id, 'applyCRMRatingLogic')]";
        public string CustomerDetails_Edit_Gainshare_Modal_Apply_Rating_Logic_Checkbox_Label_Xpath = "//label[contains(@for, 'applyCRMRatingLogic')]";
        public string PricingModel_Section_Dropdown_Xpath = "//*[@id='body']/section/div[3]/div[3]/div[5]/div[1]/div/div[3]";
        public string PricingModel_EditGainshare_Xpath = "//*[@id='gainshare-edit']/span";
        public string PricingModel_ApplyCRMRatingLogic_Xpath = "//*[@id='applyCRMRatingLogic']";
        public string PricingModel_SaveEditGainshare_Button_Xpath = "//*[@id='SaveEditGainshare']";
    }
}
