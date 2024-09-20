using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Objects
{
    public class MaintenaceTools : ObjectRepository
    {
        //=============== Master Carrier Rate Settings=========================

        public string Pricing_Button_Id = "pricing";
        public string MaintainanceTools_Id = "maintenanceTools";
        public string MaintainanceToolsHeader_Xpath = "//h1[text()='Maintenance Tools']";
        public string InsuranceAllRisk_Id = "btn-ins-allrisk";
        public string InsuranceRiskPageTitle_Xpath = "//div[@class='page-header no-border']//h1";
        public string InsuranceAllRiskTab_Xpath = ".//*[@id='#ins-allrisk']//h4";
        public string PPPTabVal_xpath = ".//*[@id='item_1']/a";
        public string AddCustomer_SpecificButton_Id = "add-customer-specific";
        public string InsuranceStation_xpath = ".//*[@id='station_select_1_chosen']/a";
        public string PPPStation_xpath = ".//*[@id='StationName_chosen']/a";
        public string PPPStationDropdownVal_xpath = ".//*[@id='StationName_chosen']//ul/li";
        public string InsuranceStationDropdownVal_xpath = ".//*[@id='station_select_1_chosen']//ul/li";
        public string InsuranceCustomer_xpath = ".//*[@id='customer_account_select_1_chosen']//li[@class = 'active-result level0']";
        public string PPPPrimaryCustomer_xpath = ".//*[@id='CustomerNames_chosen']/div/ul/li[@class = 'active-result level0']";
        public string PPPCustomer_xpath = ".//*[@id='CustomerNames_chosen']/ul/li";
        public string PPPSearchOption_xpath = ".//*[@id='ShipmentService_wrapper']//input[@class = 'ProductProtectionsearch']";
        public string InsuranceAllCustomer_xpath = ".//*[@id='customer_account_select_1_chosen']/div/ul/li";
        public string PPPAllCustomer_xpath = ".//*[@id='CustomerNames_chosen']/div/ul/li";
        public string InsuranceCustomer_Xpath = ".//*[@id='customer_account_select_1_chosen']/ul/li";
        public string InsuranceSubAccount_xpath = ".//*[@id='customer_account_select_1_chosen']/div/ul/li[@class = 'active-result level1']";
        public string PPPSubAccount_xpath = ".//*[@id='CustomerNames_chosen']/div/ul/li[@class = 'active-result level1']";
        public string InsuranceGridFirstExpandButton_xpath = ".//*[@id='Ins-AllRisk-Table']//tr[1]/td//*[@class = 'btn colored expandableTrigger']";
        public string InsuranceGridFirstCustomerName_xpath = ".//*[@id='Ins-AllRisk-Table']/tbody/tr[2]/td/div/div[2]/div/div[1]";
        public string PPPTabClick_xpath = "//div[@class = 'container-fluid content container-with-sidebar']/ul/li[2]/a";
        public string PPPSearchfieldCustNameCol_xpath = "//td[1]";
        public string PPPSearchFirstCustName_xpath = "//tr[1]/td[1]";

        public string MaterCarrierRateSettingsPage_Title_xpath = ".//h1[contains(text(),'Master Carrier Rate Settings')]";

        public string StationDropdown_Xpath = ".//*[@id='StationType_chosen']/ul/li[3]";
        public string AllStations_Id = "StationType_chosen";
        public string AllStations_SelectedValue_Xpath = ".//*[@id='StationType_chosen']/ul/li/input";
        public string AllStations_DropdownValues_Xpath = ".//*[@id='StationType_chosen']/div/ul/li";
        public string AllStations_DropdownFirstValue_Xpath = ".//*[@id='StationType_chosen']/div/ul/li[1]";
        public string AllCustomers_AllStations_Xpath = ".//*[@id='CategoryType_chosen']/div/ul/li[1]";

        public string CustomerSelectionSearchField_TextBox_Xpath = ".//*[@id='CategoryType_chosen']/div[1]/div/input";
        public string IndividualCustomers_Id = "CategoryType_chosen";
        public string IndividualCustomers_SelectedValue_Xpath = ".//*[@id='CategoryType_chosen']/ul/li/input";
        public string IndividualCustomers_DropdownValues_Xpath = ".//*[@id='CategoryType_chosen']/div/ul/li";
        public string IndividualCustomers_DropdownFirstValue_Xpath = ".//*[@id='CategoryType_chosen']/div/ul/li[2]";

        public string SetAccessorial_Button_Id = "setAccessorials";
        public string SetAccessorial_PopUp_Title_Xpath = ".//*[@id='accessorialset']/div/div/div/div[1]/h3";

        public string Select_Accessorial_Type_DropDown_Xpath = ".//*[@id='Accessorial_type_0_chosen']/a/span";
        public string Select_Accessorial_Type_DropDown_label_Xpath = ".//*[@id='0']/div[1]/label";
        public string SetGainshareFirst_TextBox_Id = "GAINSHARE-0";
        public string SetGainshare_Label_Xpath = ".//*[@id='0']/div[2]/label";

        public string SetGainshareDropDown_Id = "Gainsharevalue-0";
        public string SetGainshareDropDownOption1_Xpath = ".//*[@id='Gainsharevalue-0']/option[1]";
        public string SetGainshareDropDownOption2_Xpath = ".//*[@id='Gainsharevalue-0']/option[2]";

        public string AddAnotherAccessorial_Button_Xpath = ".//*[@id='accessorialset']/div/div/div/div[2]/div/div[2]/a";

        public string Additional_AddAnotherAccessorial_Button_Xpath = ".//*[@id='accessorialset']/div/div/div/div[2]/div/a";
        public string SetAccessorial_CancelButton_Xpath = ".//*[@id='accessorialset']/div/div/div/div[4]/a[1]";
        public string SetAccessorial_SaveButton_Id = "saveaccessorial";

        public string SetAccessorialDropDownValues_Xpath = ".//*[@id='Accessorial_type_0_chosen']/div/ul/li";

        public string FirstAdditional_Select_Accessorial_Type_DropDown_Xpath = ".//*[@id='Accessorial_type_1_chosen']/a/span";
        public string FirtsAdditional_Select_Accessorial_Type_DropDownValues_Xpath = ".//*[@id='Accessorial_type_1_chosen']/div/ul/li[2]";

        public string FirstAdditional_SetGainshare_TextBox_Id = "GAINSHARE-1";
        public string FirstAdditional_SetGainshareDropDown_Id = "Gainsharevalue-1";
        public string FirstAdditional_SetGainshareDropDownOption1_Xpath = ".//*[@id='Gainsharevalue-1']/option[1]";
        public string FirstAdditional_SetGainshareDropDownOption2_Xpath = ".//*[@id='Gainsharevalue-1']/option[2]";

        public string SetAccessorial_RemoveButton_Id = "removeaccessorial";
        public string AddDuplicateAccessorial_errorMsg_Id = "error-msg";

        public string MasterAccessorialChargefieldTextbox_id = "MasterAccessCharge";
        public string MasterAccessorialChargefieldSymbol_id = "MinAmount-value";
        public string MasterAccessorialChargefieldButton_id = "masteraccesschargebtn";
        public string GainhsharefieldButtonId = "gainsharePercentageBtn";
        public string GainhsharefieldSymbol_id = "GainsharePercentage-value";
        public string GainhsharefieldTextbox_id = "GainsharePercentage";

        public string DeleteAccessorial_Button_Id = "btnDeleteAccessorials";



        //--------------- Carrier Rate settings grid --------------------------
        public string Gainshare_Column_Xpath = ".//*[@id='CustomerTable']/thead/tr/th[5]";
        public string Mininum_Column_Xpath = ".//*[@id='CustomerTable']/thead/tr/th[6]";
        public string MininumThreshold_Column_Xpath = ".//*[@id='CustomerTable']/thead/tr/th[7]";
        public string MininumAmount_Column_Xpath = ".//*[@id='CustomerTable']/thead/tr/th[8]";
        public string MasterAccCharge_Column_Xpath = ".//*[@id='CustomerTable']/thead/tr/th[9]";

        public string Mininum_Textbox_Id = "Min";
        public string MininumThreshold_Textbox_Id = "MinThreshold";
        public string MininumAmount_Textbox_Id = "MinAmount";

        public string Mininum_FormatDropdown_Id = "Gainsharevalue";
        public string Mininum_FormatDropdownValues_Xpath = ".//*[@id='Gainsharevalue']/option";
        public string MininumThreshold_FormatDropdown_Id = "MinThreshold-value";
        public string MininumAmount_FormatDropdown_Id = "MinAmount-value";

        public string Mininum_Button_Id = "minbtn";
        public string MininumThreshold_Button_Id = "minthresholdbtn";
        public string MininumAmount_Button_Id = "minamountbtn";
        public string AllCustomer_Dropdown_Search_Xpath = ".//*[@id='CategoryType_chosen']//input";

        public string MinFirstCarrier_Xpath = ".//*[@id='ABFL']/td[6]";
        public string MinThresholdFirstCarrier_Xpath = ".//*[@id='ABFL']/td[7]";
        public string MinAmountFirstCarrier_Xpath = ".//*[@id='ABFL']/td[8]";
        public string MasterAccesFirstCarrier_Xpath = ".//*[@id='ABFL']/td[9]";
        public string FirstCarrier_Checkbox_Xpath = ".//*[@id='ABFL']/td[1]/div/label";
        public string FirstCarrierr1_Checkbox_Xpath = ".//*[@id='ABFL']/td[1]/div/label";
        public string secondCarrier_Checkbox_Xpath = ".//*[@id='AACT']/td[1]/div/label";
        public string ThirdCarrier_Checkbox_Xpath = ".//*[@id='AVRT']/td[1]/div/label";
        public string FirstCarrier_MinColumnValue_Xpath = ".//*[@id='2352']/td[6]";
        public string FirstCarrier_MinThresholdColumnValue_Xpath = ".//*[@id='2352']/td[7]";
        public string FirstCarrier_MinAmountColumnValue_Xpath = ".//*[@id='2352']/td[8]";
        public string FirstCarrier_MasterAccesCharge_Xpath = ".//*[@id='ABFL']/td[9]";
        public string MasterAccesCharge_Text_Id = "MasterAccessCharge";
        public string MasterAccesCharge_Button_Id = "masteraccesschargebtn";
        public string FirstCarrier_SetAccessorial_Xpath = ".//*[@id='CustomerTable']/tbody/tr[1]/td[10]";
        public string SetAccessorials_Button_Id = "setAccessorials";
        public string SetAccessorialType_Xpath = ".//*[@id='Accessorial_type_0_chosen']/a";
        public string SetAccessorailTypeValues_Xpath = ".//*[@id='Accessorial_type_0_chosen']//li[@class='active-result']";
        public string AdditionalSetAccessorialType_Xpath = "//div[@id='Accessorial_type_1_chosen']//a[@class='chosen-single chosen-default']";
        public string AdditionalSetAccessorailTypeValues_Xpath = ".//*[@id='Accessorial_type_1_chosen']/div/ul/li";
        public string SetAccessorialTypeText_Id = "GAINSHARE-0";
        public string SetAccessorials_SaveButton_Id = "saveaccessorial";

        public string Gainshare_ColumnValues_Xpath = ".//*[@id='CustomerTable']/tbody/tr/td[5]";
        public string Minimum_ColumnValues_Xpath = ".//*[@id='CustomerTable']/tbody/tr/td[6]";
        public string MinThreshold_ColumnValues_Xpath = ".//*[@id='CustomerTable']/tbody/tr/td[7]";
        public string MinAmount_ColumnValues_Xpath = ".//*[@id='CustomerTable']/tbody/tr/td[8]";
        public string MasterAccCharge_ColumnValues_Xpath = ".//*[@id='CustomerTable']/tbody/tr/td[9]";
        public string IndividualAcc_Column_Xpath = ".//*[@id='CustomerTable']/thead/tr/th[10]";
        public string IndividualAcc_ColumnValues_Xpath = ".//*[@id='CustomerTable']/tbody/tr/td[10]";
        public string FirstCarrier_Xpath = ".//*[@id='CustomerTable']/tbody/tr[1]/td[1]";
        public string Bump_ColumnValues_Xpath = ".//*[@id='CustomerTable']/tbody/tr/td[4]";
        public string Surge_ColumnValues_Xpath = ".//*[@id='CustomerTable']/tbody/tr/td[3]";
        public string FirstCarrierSelect_Xpath = ".//*[@id='CustomerTable']/tbody/tr[1]/td[1]/div/label";
        public string CarrierSelect_Xpath = ".//*[@id='CustomerTable']/tbody/tr[3]/td[1]/div/label";
        public string FirstSurgeValue_Xpath = ".//*[@id='CustomerTable']/tbody/tr[1]/td[3]";
        public string SurgeValue_Xpath = ".//*[@id='CustomerTable']/tbody/tr[3]/td[3]";
        public string BumpValue_Xpath = ".//*[@id='CustomerTable']/tbody/tr[3]/td[4]";
        public string FirstBumpValue_Xpath = ".//*[@id='CustomerTable']/tbody/tr[1]/td[4]";
        public string CarrierOne_Xpath = ".//*[@id='CustomerTable']/tbody/tr[1]/td[2]";
        public string CarrierTwo_Xpath = ".//*[@id='CustomerTable']/tbody/tr[2]/td[2]";
        public string SecondCarrierSelect_Xpath = ".//*[@id='CustomerTable']/tbody/tr[2]/td[1]/div/label";
        public string AllCarrierSelect_Xpath = ".//*[@id='CustomerTable']//th[1]/div/label";
        public string FirstGainshareValue_Xpath = ".//*[@id='CustomerTable']/tbody/tr[1]/td[5]";
        public string FirstMinimumValue_Xpath = ".//*[@id='CustomerTable']/tbody/tr[1]/td[6]";
        public string FirstMinThresholdValue_Xpath = ".//*[@id='CustomerTable']/tbody/tr[1]/td[7]";
        public string FirstMinAmountValue_Xpath = ".//*[@id='CustomerTable']/tbody/tr[1]/td[8]";
        public string FirstMasterAccessorialChargeValue_Xpath = ".//*[@id='CustomerTable']/tbody/tr[1]/td[9]";
        public string MasterCarrierRateSettingsGrid_Xpath = ".//*[@id='CustomerTable']/tbody";

        //------------------Master Carrier Rate settings page -----------------

        public string MaintenanceTools_Icon_Xpath = ".//*[@id='maintenanceTools']/i";
        public string MaintenanceToolsPage_Title_Xpath = "html/body/div[4]/section/div[5]/div[1]/div/div[1]/h1";
        public string Pricing_Button_Xpath = ".//*[@id='pricing']";
        public string MasterCarrierRatePage_Title_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div[1]/div/div[1]/h1";
        public string MasterCarrierRatePage_SubTitle_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div[1]/div/div[1]/p";
        public string BackToMaintenanceTools_Button_Xpath = ".//*[@id='Btn_BackQuoteList']";
        public string StationTypeSelection_DropdownBox_Xpath = ".//*[@id='StationType_chosen']/ul/li";
        public string StationTypeSelection_DropdownList_Xpath = ".//*[@id='StationType_chosen']/div/ul/li";
        public string CustomerSelection_DropdownBox_Xpath = ".//*[@id='CategoryType_chosen']/a/span";
        public string CustomerSelection_DropdownList_Xpath = ".//*[@id='CategoryType_chosen']/div/ul/li";
        public string StationDefaultValue_Xpath = ".//*[@id='StationType_chosen']/ul/li/input";
        public string CustomerDefaultValue_Xpath = ".//*[@id='CategoryType_chosen']/ul/li/input";
        public string SurgeValue_Textbox_Xpath = ".//*[@id='surge']";
        public string SurgeValueSymbol_Xpath = ".//*[@id='surge-value']";
        public string SurgeButton_Xpath = ".//*[@id='surgebtn']";
        public string Surgebutton_Id = "surgebtn";
        public string BumpValue_Textbox_Xpath = ".//*[@id='Bump']";
        public string BumpValueSymbol_Xpath = ".//*[@id='Bump-value']";
        public string BumpButton_Xpath = ".//*[@id='bumpbtn']";
        public string Bumpbutton_Id = "bumpbtn";
        public string CarrierGridHeaderValues_Xpath = ".//*[@id='CustomerTable']/thead/tr/th";
        public string SelectAllCarriers_Checkbox_Xpath = ".//*[@id='CustomerTable']/thead/tr/th[1]/div/label";
        public string UnSelectAllCarriers_Checkbox_Xpath = ".//*[@id='CustomerTable']/thead/tr/th[1]/div/label";
        public string SelectSpecifiedCarrier_Xpath = ".//*[@id='2343']/td[1]/div/label";
        public string UnSelectSpecifiedCarrier_Xpath = ".//*[@id='2343']/td[1]/div/label";
        public string CarrierAllValues_Xpath = ".//*[@id='CustomerTable']/tbody/tr/td[2]";

        public string CarrierHeaderClick_Xpath = ".//*[@id='CustomerTable']/thead/tr/th[2]";
        public string SurgeColumnValue_Xpath = ".//*[@id='2343']/td[3]";
        public string BumpColumnValue_Xpath = ".//*[@id='2343']/td[4]";
        public string CarrierWebsite_Logins_Id = "carrierwebsitelogin";
        public string TmsLaunch_CarrierWebsiteLogin_Xpath = ".//*[@id='tmslaunch']/span/a[3]";

        public string CustomerSelectionTextBox_xpath = ".//*[@id='CategoryType_chosen']//input[@type='text']";
        public string CustomerCarriersCount_xpath = ".//*[@id='CustomerTable']/tbody/tr";
        public string CustomerColumnCount_xpath = ".//*[@id='CustomerTable']/thead/tr/th";
        public string AccessorialsCount_xpath = ".//*[@id='modelDeleteAccessorial']//div//label";
        public string DeleteAccessorialFirstCheckbox_xpath = ".//*[@id='modelDeleteAccessorial']//div[1]/label";
        public string DeleteAccessorialModalHeadertext_xpath = ".//*[@id='modelDeleteAccessorial']//h3[@class='delete-accessorial-header']";
        public string NoAccessorialError_xpath = ".//*[@id='error-popup']//h3[contains(text(),Error)]";
        public string NoAccessorialErrorVerbiage_xpath = ".//*[@id='error-popup']//p[@class='error-text']";
        public string NoAccessorialErrorClose_xpath = ".//*[@id='error-popup']//a[contains(text(),Close)]";
        public string MasterCarrierRateSettingsPageHeaderText_xpath = ".//*[@id='page-content-wrapper']//h1";
        public string DeleteAccessorialModalVerbiage_xpath = ".//*[@id='modelDeleteAccessorial']//p";
        public string DeleteAccessorialModalCancelBtn_xpath = ".//*[@id='modelDeleteAccessorial']//a[contains(text(),Cancel)]";
        public string CustomerAccessorialFirstCol_xpath = ".//*[@id='CustomerTable']/thead/tr/th[10]";
        public string DeleteAccessorialModalDeleteBtn_Id = "btnModelDeleteAccessorial";
        public string SetAccessorialFirst_xpath = ".//*[@id='Accessorial_type_0_chosen']//ul/li";
        public string SetAccessorialFirstValue_Id = "GAINSHARE-0";

        public string SetAccessorialSecond_xpath = ".//*[@id='Accessorial_type_1_chosen']//ul/li";
        public string SetAccessorialSecondValue_Id = "GAINSHARE-1";

        public string SetAccessorialThird_xpath = ".//*[@id='Accessorial_type_2_chosen']//ul/li";
        public string SetAccessorialThirdValue_Id = "GAINSHARE-2";

        public string SetAccessorialFourth_xpath = ".//*[@id='Accessorial_type_3_chosen']//ul/li";
        public string SetAccessorialFourthValue_Id = "GAINSHARE-3";

        public string SetAccessorialFive_xpath = ".//*[@id='Accessorial_type_4_chosen']//ul/li";
        public string SetAccessorialFiveValue_Id = "GAINSHARE-4";

        public string SetAccessorialSix_xpath = ".//*[@id='Accessorial_type_5_chosen']//ul/li";
        public string SetAccessorialSixValue_Id = "GAINSHARE-5";
        public string SetAccessorialAddAdditionalAccessorialButton_xpath = ".//*[@id='accessorialset']//a[@class='additionalaccessorial']";
        public string SetAccessorial_type1_xpath = ".//*[@id='Accessorial_type_1_chosen']/a";
        public string SetAccessorial_type2_xpath = ".//*[@id='Accessorial_type_2_chosen']/a";
        public string SetAccessorial_type3_xpath = ".//*[@id='Accessorial_type_3_chosen']/a";
        public string SetAccessorial_type4_xpath = ".//*[@id='Accessorial_type_4_chosen']/a";
        public string SetAccessorial_type5_xpath = ".//*[@id='Accessorial_type_5_chosen']/a";
        public string DeleteAccessorialScrollbar_xpath = ".//*[@id='modelDeleteAccessorial']//div[@class='form-group scrollableModalWin']";
        public string SetAccessorialPopup_Id = "accessorialset";

        //---------------------------------------Carrier Website Login page -----------------------
        public string CarrierWebsite_Title_Xpath = ".//*[@id='page-content-wrapper']//*[text()='Admin Carrier Website Logins']";
        public string CarrierWebsite_Title_NonAdmin_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div[1]/div/div/h1";
        public string CarrierWebsite_Button_Id = "carrierwebsitelogin";
        public string CarrierWebsite_TMSLink_Xpath = ".//*[@id='tmslaunch']/span/a[3]";
        public string CarrierWebsite_BackToMaintanance_Id = "Btn_BackQuoteList";
        public string CarrierWebsite_EditIcon_Xpath = ".//tr[1]//a[@id='loginpopup']";
        public string CarrierWebsite_EditModalTitle_Xpath = ".//*[@id='LoginPasswordModal']/div/div/div/div[1]/h3";
        public string CarrierWebsite_EditPasswordTextBox_Id = "modalpasswordchange";
        public string CarrierWebsite_EditModal_SaveButton_Id = "savepassword";
        public string CarrierWbsite_EditModal_CancelButton_Id = "passwordmodalclose";
        public string CarrierWbsite_FirstCarrierScac_Xpath = ".//tr[1]/td[1]/span";
        public string CarrierWebsite_EditModal_NoPasswrd_Error_Id = "passwordfieldval";
        public string CarrierWbsite_EditModal_CloseButton_Id = "passwordmodalclose";
        public string CarrierWebsite_SearchField_Xpath = ".//*[@id='CarrierWebsiteLogin_filter']/label/input";
        public string CarrierWebiste_TableRows_Xpath = ".//*[@id='CarrierWebsiteLogin']/tbody/tr";
        public string CarrierWebsite_FirstWebsiteLink_Xpath = ".//*[@id='CarrierWebsiteLogin']/tbody/tr[1]/td[4]//*[@class='websitestyle']";
        public string CarrierWebsite_FirstWebsiteCopyIcon_Xpath = ".//*[@id='CarrierWebsiteLogin']/tbody/tr[1]/td[4]//*[@class='btn btn-icon image-only-sm']";
        public string CarrierWebsite_FirstLoginCopyIcon_Xpath = ".//*[@id='CarrierWebsiteLogin']/tbody/tr[1]//*[@class='btn btn-icon image-only-sm loginicon']";
        public string CarrierWebsite_FirstPasswordCopyIcon_Xpath = ".//*[@id='CarrierWebsiteLogin']/tbody/tr[1]/td[6]/a[1]";
        public string CarrierWebsite_FirstEditPasswordIcon_Xpath = ".//*[@id='CarrierWebsiteLogin']/tbody/tr[1]//*[@class='icon-edit']";
        public string CarrierWebsite_FirstPasswordEditModel_Password_Id = "modalpasswordchange";
        public string CarrierWebsite_FirstEditPasswordModelHeader_Xpath = ".//*[@id='LoginPasswordModal']//*[text()='Edit Password']";
        public string CarrierWebsite_FirstCarrierName_Xpath = ".//*[@id='CarrierWebsiteLogin']/tbody/tr[1]/td[2]/span";
        public string CarrierWebsite_FirstLogin_Xpath = ".//*[@id='CarrierWebsiteLogin']/tbody/tr[1]/td[5]/span";



        public string CarrierWebsite_SearchTextBox_xpath = ".//*[@id='CarrierWebsiteLogin_filter']/label/input";
        public string CarrierWebsite_ViewOption_xpath = ".//*[@id='CarrierWebsiteLogin_length']";

        public string AccessorialType_Dropdown_Xpath = ".//*[@id='Accessorial_type_0_chosen']/a";
        public string AccessorialType_DropdownValues_Xpath = ".//*[@id='Accessorial_type_0_chosen']/div/ul/li";
        public string OverlenthTypes_Xpath = ".//*[@id='accessorialset']//div[2]/div/div[2]//label";
        public string OverlenthGainshareInput_Xpath = ".//*[@id='accessorialset']//div[2]//div[2]//div[1]/div[1]/div//input";
        public string OverlenthGainshareFirstInput_Xpath = ".//*[@id='accessorialset']//div[2]/div/div[1]/div[1]/div/div[2]/input";
        public string OverlenthGainshareSecondInput_Xpath = ".//*[@id='accessorialset']//div[2]/div/div[1]/div[1]/div/div[3]/input";
        public string OverlenthGainshareThirdInput_Xpath = ".//*[@id='accessorialset']//div[2]/div/div[1]/div[1]/div/div[4]/input";
        public string OverlenthGainshareFourthInput_Xpath = ".//*[@id='accessorialset']//div[2]/div/div[1]/div[1]/div/div[5]/input";
        public string OverlenthGainshareFifthInput_Xpath = ".//*[@id='accessorialset']//div[2]/div/div[1]/div[1]/div/div[6]/input";
        public string OverlenthGainshareSixthInput_Xpath = ".//*[@id='accessorialset']//div[2]/div/div[1]/div[1]/div/div[7]/input";
        public string OverlenthGainshareSeventhInput_Xpath = ".//*[@id='accessorialset']//div[2]/div/div[1]/div[2]/div/div[2]/input";
        public string OverlenthGainshareEighthInput_Xpath = ".//*[@id='accessorialset']//div[2]/div/div[1]/div[2]/div/div[3]/input";
        public string OverlenthGainshareNinethInput_Xpath = ".//*[@id='accessorialset']//div[2]/div/div[1]/div[2]/div/div[4]/input";
        public string OverlenthGainshareTenthInput_Xpath = ".//*[@id='accessorialset']//div[2]/div/div[1]/div[2]/div/div[5]/input";
        public string OverlenthGainshare11Input_Xpath = ".//*[@id='accessorialset']//div[2]/div/div[1]/div[2]/div/div[6]/input";
        public string OverlenthGainshare12Input_Xpath = ".//*[@id='accessorialset']//div[2]/div/div[1]/div[2]/div/div[7]/input";
        public string OverlenthGainshare13Input_Xpath = ".//*[@id='accessorialset']//div[2]/div/div[1]/div[3]/div/div[2]/input";
        public string OverlenthGainshare14Input_Xpath = ".//*[@id='accessorialset']//div[2]/div/div[1]/div[3]/div/div[3]/input";
        public string OverlenthGainshare15Input_Xpath = ".//*[@id='accessorialset']//div[2]/div/div[1]/div[3]/div/div[4]/input";
        public string OverlenthGainshare16Input_Xpath = ".//*[@id='accessorialset']//div[2]/div/div[1]/div[3]/div/div[5]/input";
        public string OverlenthGainshare17Input_Xpath = ".//*[@id='accessorialset']//div[2]/div/div[1]/div[3]/div/div[6]/input";
        public string OverlenthGainshare18Input_Xpath = ".//*[@id='accessorialset']//div[2]/div/div[1]/div[3]/div/div[7]/input";
        public string OverlenthGainshare19Input_Xpath = ".//*[@id='accessorialset']//div[2]/div/div[1]/div[4]/div/div[2]/input";
        public string OverlenthGainshare20Input_Xpath = ".//*[@id='accessorialset']//div[2]/div/div[1]/div[4]/div/div[3]/input";
        public string OverlenthGainshare21Input_Xpath = ".//*[@id='accessorialset']//div[2]/div/div[1]/div[4]/div/div[4]/input";
        public string OverlenthGainshare22Input_Xpath = ".//*[@id='accessorialset']//div[2]/div/div[1]/div[4]/div/div[5]/input";
        public string OverlenthGainshare23Input_Xpath = ".//*[@id='accessorialset']//div[2]/div/div[1]/div[4]/div/div[6]/input";
        public string AccessorialValue_Id = "GAINSHARE-0'";
        public string AddAnotherAccessorialLink_Xpath = ".//*[@id='accessorialset']//div[3]/a";
        public string overCostField_Xpath = "";

        public string OverlenthValidationMessage_Xpath = "//SPAN[text()='All Overlength fields required']";
        public string AccessorialSave_Id = "saveaccessorial";
        public string AccessorialValidationError_Xpath = ".//*[@id='Overlength-Error-msg']";
        public string AccessorialOverlengthValUI_Xpath = "//tr[@id='ABFL']//td";
        public string AccessorialOverlengthType_Xpath = "//th[contains(text(),'OVER')]";
        public string AccessorialAllOverlenth_Xpath = "//tr//td[12]";
        public string OverlengthTypeUI_Xpath = "//*[@id='CustomerTable_wrapper']/table/thead/tr/th[position() >= 10]";
        public string FirstCarrierOverlengthVal_Xpath = "//tr[1]//td";
        public string ThirdCarrierOverlengthVal_Xpath = "//tr[3]//td";
        public string DeleteAccessorialButton_Id = "btnDeleteAccessorials";
        public string DeleteOverlengthOption_Xpath = "//label[@for='FilterByStatusOverlength']";
        public string DeleteAccessButtonModal_Xpath = "//a[@id='btnModelDeleteAccessorial']";
        public string AccessorialGainshareSymbol_Xpath = ".//*[@id='Gainsharevalue-0']";

        public string SetIndividualAccessorials_ModalPopUp_Label_Xpath = "//h3[contains(text(),'Set Individual Accessorials')]";
        public string Add_AnotherAccessorial_Button_Xpath = "//a[contains(text(),'ADD ANOTHER ACCESSORIAL')]";
        public string AdditionaldropdownOne_Value_Xpath = ".//*[@id='Accessorial_type_1_chosen']/div/ul/li";
        public string NotificationAccesssorialCheckbox_SetIndividualAccessorialsModalPopUp_Xpath = "//label[@for='FilterByStatusNotification']";
        public string SelectAllCarrierFromGridCheckbox_Xpath = ".//*[@id='CustomerTable']//label[@for='select_allCustomerTableCARRIER']";
        public string SecondCarrierSelectCheckbox_Xpath = ".//*[@id='CustomerTable']/tbody/tr[2]/td[1]/div/label";
        public string SetGainshareTypeDropdown_Xpath = ".//*[@id='Gainshare_type_0_chosen']/a";
        public string SetGainshareTypeDropdownValues_Xpath = ".//*[@id='Gainshare_type_0_chosen']/div/ul/li";
        public string AdditionalGainshareType_Xpath = "//div[@id='Gainshare_type_1_chosen']/a";
        public string AdditionalGainshareType_Id = "Gainshare-type-1";
        public string AdditionalGainsgareType_ClassName = "chosen-select DropDownBox GainshareTypeSelect";
        public string AdditionalGainshareTypeDropdownValues_Xpath = "//div[@id='1']//*[@id='Gainshare-type-1']/option";
        public string AdditionalPercentageOverCost_Xpath = ".//*[@id='GAINSHARE-1']";
        public string GainshareTypeVal_Xpath = "//input[@id='GAINSHARE-0']";
        public string GainshareTypeValLabel_Xpath = ".//*[@id='divGainShareValue-0']/label";
        public string GainshareTypeValFormat_Xpath = ".//*[@id='Gainsharevalue-0']";
        public string AdditionalGainshareTypeVal_Xpath = "//input[@id='GAINSHARE-1']";
        public string AdditionalGainshareTypeValLabel_Xpath = ".//*[@id='divGainShareValue-1']/label";
        public string AdditionalGainshareTypeValFormat_Xpath = ".//*[@id='Gainsharevalue-1']";

        public string PercentageOverCost_Xpath = "";
        public string AdditionalPercentageOverCostLabel_Xpath = ".//*[@id='divGainShareValue-1']/label";
        public string PercentageOverCostLabel_Xpath = ".//*[@id='GAINSHARE-0']";
        public string AdditionalPercentageFormat_Xpath = "//div[@id='divGainShareValue-1']//input[2]";
        public string PercentageFormat_Xpath = "//div[@id='divGainShareValue-0']//input[2]";
        public string FlatOverCost_Xpath = ".//*[@id='GAINSHARE-0']";
        public string AdditionalFlatOverCost_Xpath = "";
        public string FlatOverCostLabel_Xpath = "";
        public string CurrencyFormat_Xpath = "//body[@class='modal-open']/div[@id='wrapper']/div[@id='page-content-wrapper']/div[@class='container-fluid container-with-sidebar']/div[@class='row']/div[@id='accessorialset']/div[@class='vertical-alignment-helper']/div[@class='modal-dialog vertical-align-center']/div[@class='modal-content']/div[@class='modal-body']/div[@class='col-md-12 colpadding defaultAccessorialpopup']/div[@class='body-left']/div[@id='0']/div[@id='divGainShareValue-0']/input[1]";
        public string SetFlatAmount_Xpath = ".//*[@id='GAINSHARE-0']";
        public string AdditionalFlatOverCostLabel_Xpath = "//label[contains(text(),'Flat over cost')]";
       
        public string AdditionalCurrencyFormat_Xpath = "//body[@class='modal-open']/div[@id='wrapper']/div[@id='page-content-wrapper']/div[@class='container-fluid container-with-sidebar']/div[@class='row']/div[@id='accessorialset']/div[@class='vertical-alignment-helper']/div[@class='modal-dialog vertical-align-center']/div[@class='modal-content']/div[@class='modal-body']/div[@class='col-md-12 colpadding defaultAccessorialpopup']/div[@class='body-left']/div[@id='1']/div[@id='divGainShareValue-1']/input[1]";
      
        public string AdditionalSetFlatAmount_Xpath = "";
        public string SetFlatAmountLabel_Xpath = "";
        public string AdditionalSetFlatAmountLabel_Xpath = "//label[contains(text(),'Set flat amount')]";
        public string FirstCarrierName_Xpath = ".//*[@id='ABFL']/td[2]";
        public string SecondCarrierName_Xpath = ".//*[@id='AACT']/td[2]";
        public string GainshareTypeValUI_Xpath = ".//*[@id='ABFL']/td[10]";
        public string GainshareTypeValue_Xpath = ".//*[@id='ABFL']/td[11]";
      

    }
}
