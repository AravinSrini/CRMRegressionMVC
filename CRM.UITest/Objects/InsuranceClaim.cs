using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Objects
{
    public class InsuranceClaim : ObjectRepository
    {
        public string Submit_A_Claim_Page_Header_Text_Xpath = ".//h1[contains(text(), 'Submit a Claim')]";
        public string Amend_Page_Header_Text_Xpath = ".//h1[contains(text(), 'Submit a Claim (#ClaimNumber)')]";
        public string Enter_DLSW_BOLNumber_Textbox_Id = "DlswProcess";
        public string PopulateForm_button_Id = "btn-PopulateForm";
        public string InvalidBolNumber_Text_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div[3]/p";
        public string DLSWBillOfLading_Textbox_Id = "DlswBillLading";
        public string CarrierName_Textbox_Id = "CarrierName";
        public string Shipper_Address_Textbox_Id = "ShipperAddress";
        public string Resubmit_button_Id = "btnSubmitClaim";
        public string customer_claim_ref_Id = "CustomerClaimReferenceNumber";
        public string claimlist_customerref_xpath = ".//*[@id='gridInsuranceClaimList']//td[2]";
        public string submitAClaimPage_ClaimDetailsHeader_xpath = ".//h2[contains(text(), 'Claim Details')]";
        public string submitAClaimPage_UnitWeightName_Xpath = "(.//*[normalize-space(text()) and normalize-space(.)='Quantity'])[1]/following::label[1]";
        public string submitAClaimPage_CustomerRefLabel_xpath = "//label[contains(text(),'Customer Claim Ref #')]";
        //public string submitAClaimPage_UnitWeightName_Xpath = "//*[@id='page-content-wrapper']/div[2]/div[1]/div[15]/div/div[2]/div[4]/label";
        //public string ResubmitAClaimPage_UnitWeightName_Xpath = "//*[@id='page-content-wrapper']/div[2]/div[1]/div[13]/div/div[2]/div[4]/label";
        public string ResubmitAClaimPage_UnitWeightName_Xpath = "(.//*[normalize-space(text()) and normalize-space(.)='Quantity'])[1]/following::label[1]";
        public string submitAClaimPage_AnotherItemUnitWeightName_Xpath = "//*[@id='page-content-wrapper']/div[2]/div[1]/div[16]/div/div[2]/div[4]/label";
        public string ResubmitAClaimPage_AnotherItemUnitWeightName_Xpath = "//*[@id='page-content-wrapper']/div[2]/div[1]/div[14]/div/div[2]/div[4]/label";

        public string ClaimsIcon_Id = "claims";
        public string ClaimsIcon_Text_Xpath = ".//*[@id='claims']/span";

        public string ClaimsListPage_HeaderText_Xpath = ".//h1[contains(text(), 'Claims List')]";

        public string Submit_A_Claim_button_Id = "submitClaim";

        public string DLSW_BOLDate_Field_Id = "DlswBolDate";
        public string DLSW_BOLDate_Field_Values_Xpath = "html/body/div[8]/div[1]/table/tbody/tr/td";
        public string DLSW_BOLDate_Field_LeftArrow_Xpath = "html/body/div[8]/div[1]/table/thead/tr[2]/th[1]";
        public string CarrierPro_Textbox_Id = "CarrierPro";
        public string CarrierProDate_Field_Id = "CarrierProDate";
        public string CarrierProDate_Field_Values_Xpath = "html/body/div[9]/div[1]/table/tbody/tr/td";
        public string CarrierProDate_Field_LeftArrow_Xpath = "html/body/div[9]/div[1]/table/thead/tr[2]/th[1]";

        public string Shipper_Name_Textbox_Id = "Name";
        public string Shipper_Address_Textbox_Class = "ShipperAddress";
        public string Shipper_Address2_Textbox_Id = "Address2";
        public string Shipper_Zip_Postal_Textbox_Id = "ShipperZip";
        public string Shipper_Country_dropdown_Id = "ShipperCountry_chosen";
        //public string Shipper_Country_dropdown_Xpath = ".//*[@id='Country_chosen']/a";
        public string Shipper_Country_dropdown_Xpath = ".//*[@id='ShipperCountry_chosen']/a";
        public string Shipper_CountryDefaultSelection_Xpath = "//*[@id='Country_chosen']//*[text()='United States']";
        public string Shipper_SelectingUnitedStates_Xpath = "//div[@id='ClaimCountry_chosen']//span[contains(text(),'United States')]";
        public string Shipper_Country_dropdownValue_Xpath = ".//*[@id='Country_chosen']//div/ul/li";
        public string Shipper_Country_TextBox_Xpath = ".//*[@id='Country_chosen']//input";
        public string Shipper_Country_SelectingFirstHighlighted_Xpath = ".//*[@id='Country_chosen']//li[1]/em";
        public string Shipper_Country_NoCountrySelected_Xpath = ".//*[@id='Country_chosen']//li[1]";
        public string Shipper_City_Textbox_Id = "ShipperCity";

        //public string Shipper_State_Province_dropdown_Xpath = ".//*[@id='State_chosen']/a";
        public string Shipper_State_Province_dropdown_Xpath = ".//*[@id='Shipperstate_chosen']/a";
        public string Shipper_State_Province_dropdown_Value_Xpath = ".//*[@id='Shipperstate_chosen']/div/ul/li";
        public string Shipper_State_Textbox_Xpath= ".//*[@id='State_chosen']//input";
        public string Shipper_State_SelectingFirstHighlighted_Xpath= ".//*[@id='State_chosen']//li[1]";


        public string Consignee_Name_Textbox_Id = "ConsigneeName";
        public string Consignee_Address_Textbox_Id = "ConsigneeAddress";
        public string Consignee_Address2_Textbox_Id = "ConsigneeAddress2";
        public string Consignee_Zip_Postal_Textbox_Id = "ConsigneeZip";
        public string Consignee_Country_dropdown_Xpath = ".//*[@id='ConsigneeCountry_chosen']/a";
        public string Consignee_Country_Textbox_Xpath = ".//*[@id='ConsigneeCountry_chosen']//input";
        public string Consignee_Country_SelectingFirstHighlighted_Xpath = ".//*[@id='ConsigneeCountry_chosen']//li[1]/em";
        public string Consignee_Country_dropdownValue_Xpath = ".//*[@id='ConsigneeCountry_chosen']/div/ul/li";
        public string Consignee_City_Textbox_Id = "ConsigneeCity";
        public string Consignee_State_Province_dropdown_Xpath = ".//*[@id='Consigneestate_chosen']/a";
        public string Consignee_State_Textbox_Xpath = ".//*[@id='ConsigneeStatedrpdown_chosen']//input";
        public string Consignee_State_SelectingFirstHighlighted_Xpath= ".//*[@id='ConsigneeStatedrpdown_chosen']//li[1]";
        public string Consingee_State_SelectingFirstHighlighted_Click_Xpath = ".//*[@id='ConsigneeStatedrpdown_chosen']//li[2]";
        public string Consignee_State_Province_dropdown_Value_Xpath = ".//*[@id='Consigneestate_chosen']/div/ul/li";
        public string Consignee_State_Province_Id = "ConsigneeStateText";


        public string ShipmentIcon_Xpath = ".//*[@id='shipment']//*[@class='icon icon-shipments']";


        public string ClaimPage_Header_Verbiage_xpath = ".//*[@id='page-content-wrapper']//p[contains(text(),'Submit a motor carrier shortage or damage claim')]";
        public string ClaimPageInlineLabelFont_Xpath = ".//*[@id='page-content-wrapper']//*[@class = 'control-label defaulttransorm']";
        public string Submit_Claim_Page_Header_xpath = ".//*[@id='page-content-wrapper']//p[contains(text(),'Amend a previously submitted motor carrier shortage or damage claim')]";


        public string BackToClaimListPage_Button_Xpath = "//*[@class='backButtonClaimList pull-right hidden-xs hidden-sm invert-btn btn-icon click-disable btn btn-icon']";

        public string DLSWShipDate_Id = "DlswBolDate";
        public string DLSWShipDate_Xpath = "html/body/div[8]/div[1]/table/tbody/tr[1]/td[1]";


        public string Shiper_State_Province_dropdown_Xpath = "//*[@id='Shipperstate_chosen']//*[@class='chosen-single chosen-default']";
        public string Shipper_provinceDropdown_values_Xpath = "//*[@id='Shipperstate_chosen']//*[@class='active-result group-option']";


        public string Consignee_provinceDropdown_values_Xpath = ".//*[@id='Consigneestate_chosen']//*[@class='active-result group-option']";

        public string ClaimPayableTo_CompanyName_Id = "ClaimCompanyName";
        public string ClaimPayableToVerbiage_Xpath = ".//*[@id='page-content-wrapper']//p[contains(text(),'Claim must be made payable to party on the bill of lading')]";
        public string ClaimPayableTo_Address_Id = "ClaimAddress";
        public string ClaimPayableTo_Address2_Id = "ClaimAddress2";
        public string ClaimPayableTo_ZipCode_Id = "ClaimZip";
        public string ClaimPayableTo_City_Id = "ClaimCity";
        public string ClaimPayableTo_Country_dropdownValue_Xpath = ".//*[@id='ClaimCountry_chosen']/div/ul/li";
        public string ClaimPayableTo_Country_dropdown_Xpath = "//*[@id='ClaimCountry_chosen']//*[@class='chosen-single']";
        public string ClaimPayableTo_Country_dropdown_Id = "ClaimCountry_chosen";
        public string ClaimPayableTo_State_Province_dropdown_xpath = ".//*[@id='ClaimPayableState_chosen']//*[@class='chosen-single']";
        public string ClaimPayableTo_provinceDropdown_values_Xpath = ".//*[@id='ClaimPayableState_chosen']//*[@class='active-result group-option']";
        public string ClaimPayableTo_provinceSelected_value_Xpath = ".//*[@id='ClaimPayableState_chosen']/a/span";
        public string ClaimPayableTo_ContactName_Id = "ClaimContactName";
        public string ClaimPayableTo_ContactPhone_Id = "ContactPhone";
        public string ClaimPayableTo_ContactEmail_Id = "ContactEmail";
        public string ClaimPayableTo_CompanyWebsite_Id = "CompanyWebsite";
        public string ClaimDetailsVerbiage_Xpath = ".//*[@id='page-content-wrapper']//*[@class='claimPayableSectionTitle']";

        public string AddAditionalClaim_btn_Id = "btn-AddAdditionalClaim";
        public string RemoveButtonAddAdditionalItem_Xpath = ".//*[@id='btn-ClaimDetailsAdditionalRemove']";
        public string AddAdditionalRemove_btn_Id = "btn-ClaimDetailsAdditionalRemove";
        public string SubtotalAllClaimValue_Textbox_Id = "SubtotalAllClaimValue";
        public string ClaimType_Shortage_Id = "btn-claimtypeShortage";
        public string ClaimType_Shortage_xpath = "//label[@for='btn-claimtypeShortage']";
        public string ClaimType_Shortage_Xpath = "//*[@id='page-content-wrapper']//*[text()='Shortage']";
        public string ClaimType_Damage_Id = "btn-claimtypeDamage";
        public string ArticleType_Used_Id = "btn-articlestypeUsed";
        public string ArticleType_Used_Xpath = "//*[@id='page-content-wrapper']//*[text()='Used']";
        public string ArticleType_New_Id = "btn-articlestypeNew";
        public string ItemMode_Number_Id = "Item/Model#";
        public string UnitValue_Id = "UnitValue";
        public string Quantity_Id = "Quantity";
        public string Weight_LBS_Id = "Weight";
        public string ClaimedArticle_Description_Id = "DescriptionofClaimedArticles";
        public string ArticlesInsured_Label_Xpath = ".//*[@id='page-content-wrapper']//label[contains(text(),'Articles  Insured *')]";
        public string ArticlesInsuredNo_Xpath = ".//*[@id='page-content-wrapper']//*[@for = 'btn-articlesallriskNo']";
        public string ArticlesInsuredNo_Id = "btn-articlesallriskNo";
        public string Shortage_Id = "btn-claimtypeShortage";
        public string Damage_Id = "btn-claimtypeDamage";
        public string ArticlesUsed_Id = "btn-articlestypeUsed";
        public string ArticlesNew_Id = "btn-articlestypeNew";
        public string FreightChargeNo_Id = "btn-freightchargesNo";
        public string FreightChargeYes_Id = "btn-freightchargesYes";
        public string ArticlesInsuredYes_Xpath = ".//*[@id='page-content-wrapper']//*[@for = 'btn-articlesallriskYes']";
        public string ArticlesInsuredYes_Id = "btn-articlesallriskYes";
        public string InsuredAmount_Id = "InsuredValueAmount";
        public string ClaimTypeField_Xpath = ".//*[@id='page-content-wrapper']//*[@for = 'ClaimTypeName']";
        public string ShortageOption_Xpath = ".//*[@id='page-content-wrapper']//*[@for = 'btn-claimtypeShortage']";
        public string DamageOption_Xpath = ".//*[@id='page-content-wrapper']//*[@for = 'btn-claimtypeDamage']";
        public string ArticlesTypeLabel_Xpath = ".//*[@id='page-content-wrapper']//*[@for = 'ArticlesType']";
        public string ArticlesTypeUsed_Xpath = ".//*[@id='page-content-wrapper']//*[@for ='btn-articlestypeUsed']";
        public string ArticlesTypeNew_Xpath = ".//*[@id='page-content-wrapper']//*[@for ='btn-articlestypeNew']";
        public string FreightChargeLabel_Xpath = ".//*[@id='page-content-wrapper']//*[@for = 'freightcharges']";
        public string FreightChargeNo_Xpath = ".//*[@id='page-content-wrapper']//*[@for = 'btn-freightchargesNo']";
        public string FreightChargeYes_Xpath = ".//*[@id='page-content-wrapper']//*[@for = 'btn-freightchargesYes']";
        public string OriginFreightChargeOption_Xpath = ".//*[@id='page-content-wrapper']//*[@for = 'btn-OriginalFreightchargesOriginalFreightCharges']";
        public string OriginFreightCharge_Id = "btn-OriginalFreightchargesOriginalFreightCharges";
        public string OriginFreightChargeOptionField_Class = "originalFreightChargesValue";
        public string OriginFreightChargeVal_Xpath = "//input[@id='value*']";
        public string OptionFreight_Xpath = ".//*[@id='page-content-wrapper']//*[@for = 'OriginalFreightcharges']";
        public string ReturnFreightCharge_Xpath = ".//*[@id='page-content-wrapper']//*[@for = 'btn-returnFreightchargesReturnFreightCharges']";
        public string ReturnFreightVal_Class = "returnFreightChargesValue validateFreightInput";
        public string ReturnFreightVal_Id = "value";
        public string ReplacementFreight_Xpath = ".//*[@id='page-content-wrapper']//*[@for = 'btn-replacementFreightchargesReplacementFreightCharges']";
        public string ReplaceFreightVal_Class = "replaceFreightChargesValue validateFreightInput";
        public string ReplaceFreightVal_Xpath = "xpath=(//input[@id='value'])[2]";
        public string ReturnDLS_Id = "dlswreturnbol";
        public string ReplaceDLS_Id = "dlswreplacementbol";
        public string Subtotal_Id = "SubtotalAllClaimValue";
        public string DLSDate_Xpath = "html/body/div[9]/div[1]/table/tbody/tr/td";
        public string DLSDateMonth_Xpath = "html/body/div[9]/div[1]/table/thead/tr[2]/th[1]";
        public string ReturnCheckBox_Xpath = "//label[@for='btn-returnFreightchargesReturnFreightCharges']";
        public string ReplacementCheckBox_Xpath = "//label[@for='btn-replacementFreightchargesReplacementFreightCharges']";


        public string Remarks_textarea_Id = "signoffRemarks)";
        public string SignOff_Checkbox_Id = "btn-signOffAgrement";
        public string SignOffRemark_verbiage_Xpath = "//p[@class='claimPayableSectionTitle'][contains(text(),'By submitting this claim, I acknowledge that all s')]";
        public string SignOff_Checkbox_Xpath = "//*[@id='page-content-wrapper']//*[@for='btn-signOffAgrement']";
        public string Signature_Id = "btn-signature";
        public string SubmitClaimPage_validationMsg_Xpath = "//*[@id='page-content-wrapper']//*[@class='SubmitClaimErrorMsg']";
        public string SubmitClaimButton_Id = "btnSubmitClaim";
        public string SignOffVerbiageText_Xpath = "//*[@id='page-content-wrapper']//*[@class='checkbox checkbox signOffAgrement inline-element']";
        public string Enter_DLSW_BOLNumber_Textbox_Label_Xpath = ".//*[@id='page-content-wrapper']//label[contains(text(),'Enter DLSW Ref # to Start Process')]";
        public string PopulateFormButton_Verbiage_Xpath = ".//*[@id='page-content-wrapper']//p[contains(text(),'Or fill out the form below manually')]";
        public string ShipperState_Id = "Shipperstate_chosen";
        public string ShipperState_Xpath = ".//*[@id='Shipperstate_chosen']/a";
        public string ShipperProvince_Id = "Shipperprovince";
        public string ConsigneProvince_Id = "Consigneeprovince";
        public string ClaimState_Id = "ClaimPayableState_chosen";
        public string ClaimProvince_Id = "ClaimPayableprovince";
        public string Font_Xpath = "//*[@id='page-content-wrapper']//*[@class='container-fluid claimlist']";
        public string FreightTootTip_Xpath = ".//*[@id='page-content-wrapper']//*[@class = 'btn btn-color btn-sm freightTooltip']";
        public string ToolTipInfo_Icon_ClaimPayable_Id = "btn-claimpayabletooltip";
        public string RemarkVerbiage_Xpath = ".//*[@id='page-content-wrapper']//*[@for = 'signoffremarks']";
        public string RemarksField_Id = "signoffRemarks)";
        public string ConfirmationVerbiage_Xpath = "//label[@id='AccuracyVerbiage']";
        public string ClaimDetail2ndDoctypeName_Xpath = "//label[@class='lable-saved-document']";

        public string DocumentTab_Xpath = "//a[contains(text(),'Documents')]";
        public string DocumentSectionText_Xpath = "//*[@class='row header-section Document-section']//*[text()='Documents']";
        public string Verbiage_BeneathDocumentsSectionHeader_Xpath = "//p[@class='claimPayableSectionTitle'][contains(text(),'Note: Claim should be supported by the following d')]";
        public string CompleteVendorInvoice_verbiage_Xpath = "//p[@class='documentheadingpadding documentTypeTitle']";
        public string InformationHover_Icon_First_Xpath = "//div[@class='form-inline']//div[@class='form-group']//button[@class='btn btn-color btn-sm documenttooltip']//i[@class='icon-i']";
        public string DocumentUploadButton_Xpath = "//*[@id='page-content-wrapper']//button[@class='btn btn-color btn-document-upload']";
        public string VerbiageNextToDocumentUploadButton_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div[1]/div[19]/div[3]/div[1]/div[2]/div/div[2]/p/span";
        public string AddAdditionalDocument_Button_Id = "btn-DocAdditional";
        public string Detailstab_AddAdditionalDocumnebt_Button_id = "btnAddAdditionalDoc";
        public string ToolTip_Verbiage_First_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div[1]/div[19]/div[3]/div[1]/div[1]/div/div[2]/button";
        public string DeleteDocument_Button_First_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div[1]/div[19]/div[3]/div[1]/div[2]/div/div[2]/p/div/div/a";
        public string DeleteDocument_Button_second_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div[1]/div[19]/div[3]/div[2]/div/div[2]/div/div[2]/p/div/div/a";
        public string DocumentLink_linkText = "Claim.xlsx";
        public string PDFDocument_linkText = "Visio-Rating Calculations.pdf";
        public string DocumentDeletePopup_Verbiage_Xpath = "//H6[text()='Are you sure you want to delete this file?']";
        public string DocumentDeletePopup_CancelButton_Xpath = "//html//div[@id='delete-Document-uploaded']//a[1]";
        public string DocumentDeletePopup_DeleteButton_Id = "delete-document-yes";


        //--------------Claims List page objects-------------------
        public string ClaimsList_Pageheading_Xpath = "//h1[@class='page-heading']";
        public string ClaimsList_InstructionalVerbiage_xpath = "//p[@class='Header-Sub-title']";
        public string ClaimsListSearchField_xpath = "//input[@class='form-control input-sm']";
        public string ClaimsListExportButton_xpath = "//button[@id='btnExortInsuranceClaimList']";
        public string ClaimsListTopGridViewOption_xpath = "//div[@id='gridInsuranceClaimList_length']//label/div/a";
        public string ClaimsListBottonGridViewOption_xpath = "//div[contains(@class,'footerPosition')]//div[@class='dataTables_length']//label";
        public string ClaimList_ClaimNumberSearchBox_Xpath = ".//*[@id='gridInsuranceClaimList_filter']//input";
        public string ClaimsList_TopGrid_ViewDropdown_Xpath = "//div[@id='gridInsuranceClaimList_length']//label//select[@name='gridInsuranceClaimList_length']";
        public string ClaimsList_TopGrid_ViewDropdownValues_Xpath = ".//*[@id='gridInsuranceClaimList_length']/label/select/option";

        public string ClaimsList_BottomGrid_ViewDropdown_Xpath = "//div[contains(@class,'footerPosition')]//div[@class='dataTables_length']//label/select";
        public string ClaimsList_BottomGrid_ViewDropdownValues_Xpath = "//div[contains(@class,'footerPosition')]//div[@class='dataTables_length']//label/select/option";

        public string ClaimsList_TopGrid_DisplayListView_Xpath = ".//*[@id='gridInsuranceClaimList_info']";
        public string ClaimsList_TopGrid_RightNavigationIcon_Xpath = ".//*[@id='gridInsuranceClaimList_next']/a";
        public string ClaimsList_TopGrid_LeftNavigationIcon_Xpath = ".//*[@id='gridInsuranceClaimList_previous']/a/span";

        public string ClaimsList_ExportAllOption_xpath = "//a[@onclick='return ClaimList.ExportAll()']";
        public string ClaimsList_ExportDisplayedOption_xpath = "//a[@onclick='return ClaimList.ExportDisplayed()()']";

        public string ClaimsList_ExportButtonDropdownValues_Xpath = ".//*[@id='gridInsuranceClaimList_wrapper']//ul[@aria-labelledby='btnExortInsuranceClaimList']/li";

        public string CustomerValUi_xpath = ".//*[@id='gridInsuranceClaimList']//tr[1]/td[1]";
        public string CustomerRefNumberUi_xpath = ".//*[@id='gridInsuranceClaimList']//tr[1]/td[2]";
        public string InsuredValUi_xpath = ".//*[@id='gridInsuranceClaimList']//tr[1]/td[3]";
        public string DLSWCLaimNumberValUi_xpath = ".//*[@id='gridInsuranceClaimList']//tr[1]/td[4]/span/a";
        public string DLSWClaimNumberALLValUI_xpath = ".//tr/td/span[contains(@class,'dlsw-claim-number')]";
        public string DLSWRef_NumberValUi_xpath = ".//*[@id='gridInsuranceClaimList']//tr[1]/td[5]";
        public string CarrierNameValUi_xpath = ".//*[@id='gridInsuranceClaimList']//tr[1]/td[6]";
        public string CarrierPROValUi_xpath = ".//*[@id='gridInsuranceClaimList']//tr[1]/td[6]";
        public string OriginalAmtValUi_xpath = ".//*[@id='gridInsuranceClaimList']//tr[1]/td[7]";
        public string StatusValUi_xpath = ".//*[@id='gridInsuranceClaimList']//tr[1]/td[8]/span";
        public string StatusAllValues_Xpath = ".//tr/td[contains(@class,'td-status')]";
        public string SubmitDateValUi_xpath = ".//*[@id='gridInsuranceClaimList']//tr[1]/td[9]";
        public string ClaimAgeValUi_xpath = ".//*[@id='gridInsuranceClaimList']//tr[1]/td[10]";

        public string ClaimsListColumns_xpath = ".//*[@id='gridInsuranceClaimList']/tbody/tr/td[1]";
        public string ClaimsList_TotalRecords_Xpath = ".//*[@id='gridInsuranceClaimList']/tbody/tr";
        public string ClaimsList_CustomerColumn_Highlighted_Xpath = "";
        public string ClaimsListGrid_Highlight_Class = "highlight";

        public string ClaimsListGrid_OpenStatusColor_xpath = ".//*[@id='gridInsuranceClaimList']//tr[1]/td[8]/span[@class='insured-status insured-status-open pull-left']";
        public string ClaimsListGrid_PendingStatusColor_xpath = ".//*[@id='gridInsuranceClaimList']//tr[1]/td[8]/span[@class='insured-status insured-status-pending pull-left']";
        public string ClaimsListGrid_PaidStatusColor_xpath = ".//*[@id='gridInsuranceClaimList']//tr[1]/td[8]/span[@class='insured-status insured-status-paid pull-left']";
        public string ClaimsListGrid_DeniedStatusColor_xpath = ".//*[@id='gridInsuranceClaimList']//tr[1]/td[8]/span[@class='insured-status insured-status-denied pull-left']";
        public string ClaimsListGrid_CancelledStatusColor_xpath = ".//*[@id='gridInsuranceClaimList']//tr/td[8]/span[@class='insured-status insured-status-cancelled pull-left']";
        public string ClaimListGrid_PendingCheckbox_Xpath = ".//*[@id='gridInsuranceClaimList_wrapper']//*[@class='checkbox inline-element']//*[text()='Pending']";
        public string ClaimsList_OpenStatusColor_xpath = "//*[@id='gridInsuranceClaimList']/tbody/tr[1]/td[8]/span";


        public string ClaimListPageSearch_Xpath = "//input[@placeholder='Search...']";
        public string ClaimListFirstClaimNumber_Xpath = "//tbody//tr[1]//td[3]//span[1]";
        public string ClaimListFirstClaimNumberExternal_Xpath = "//tbody//tr[1]//td[4]//a";
        public string ClaimListFirstClaimNumberInternal_Xpath = "//tbody//tr[1]//td[4]//a";
        public string ClaimListFirstClaimNumberClaimUser_Xpath = "//tbody//tr[1]//td[3]//a";


        public string ClaimsList_RowCount_xpath = ".//*[@id='gridInsuranceClaimList']/tbody/tr";
        public string ClaimsList_CustomerNameClick_Xpath = ".//*[@id='gridInsuranceClaimList']/thead/tr/th[1]";
        public string ClaimsList_CustomerNameAll_Values_Xpath = ".//*[@id='gridInsuranceClaimList']/tbody/tr[@role = 'row']/td[1]";
        public string ClaimsList_CustomerRefNumberClick_Xpath = ".//*[@id='gridInsuranceClaimList']/thead/tr/th[2]";
        public string ClaimsList_CustomerRefNumberAll_Values_Xpath = ".//*[@id='gridInsuranceClaimList']/tbody/tr[@role = 'row']/td[2]";
        public string ClaimsList_InsuredColClick_Xpath = ".//*[@id='gridInsuranceClaimList']/thead/tr/th[3]";
        public string ClaimsList_InsuredColAll_Values_Xpath = ".//*[@id='gridInsuranceClaimList']/tbody/tr[@role = 'row']/td[3]";
        public string ClaimsList_DLSWClaimNumberColClick_Xpath = ".//*[@id='gridInsuranceClaimList']/thead/tr/th[4]"; 
        public string ClaimsList_DLSWClaimNumberColAll_Values_Xpath = ".//*[@id='gridInsuranceClaimList']/tbody/tr[@role = 'row']/td[4]";
        public string ClaimsList_DLSWRefNumberColClick_Xpath = ".//*[@id='gridInsuranceClaimList']/thead/tr/th[5]";
        public string ClaimsList_DLSWRefNumberColAll_Values_Xpath = ".//*[@id='gridInsuranceClaimList']/tbody/tr[@role = 'row']/td[5]";
        public string ClaimsList_AmountColClick_Xpath = ".//*[@id='gridInsuranceClaimList']/thead/tr/th[7]";
        public string ClaimsList_AmountColAll_Values_Xpath = ".//*[@id='gridInsuranceClaimList']/tbody/tr[@role = 'row']/td[7]";
        public string ClaimsList_CarrierColClick_Xpath = ".//*[@id='gridInsuranceClaimList']/thead/tr/th[6]";
        public string ClaimsList_CarrierNameColAll_Values_Xpath = ".//*[@id='gridInsuranceClaimList']/tbody/tr[@role = 'row']/td[6]";
        public string ClaimsList_StatusColClick_Xpath = ".//*[@id='gridInsuranceClaimList']/thead/tr/th[8]";
        public string ClaimsList_StatusColAll_Values_Xpath = ".//*[@id='gridInsuranceClaimList']/tbody/tr[@role = 'row']/td[8]";
        public string ClaimsList_SubmitDateColClick_Xpath = ".//thead/tr/th[contains(@class,'SubmitClaimDateSort')]";
        public string ClaimsList_SubmitDateAll_Values_Xpath = ".//*[@id='gridInsuranceClaimList']/tbody/tr[@role = 'row']/td[9]";
        public string ClaimsList_ClaimsAgeColClick_Xpath = ".//*[@id='gridInsuranceClaimList']/thead/tr/th[10]";
        public string ClaimsList_ClaimAgeAll_Values_Xpath = ".//*[@id='gridInsuranceClaimList']/tbody/tr[@role = 'row']/td[10]";

        public string ClaimsList_OpenStatusCheckbox_xpath = "//label[@for='FilterByStatusOpen']";

        public string ClaimsList_OpenCheckbox_xpath = ".//label[contains(@for,'FilterByStatusOpen')]";
        public string ClaimsList_DeniedCheckbox_xpath = ".//label[contains(@for,'FilterByStatusDenied')]";
        public string ClaimsList_PendingCheckbox_xpath = ".//label[contains(@for,'FilterByStatusPending')]";
        public string ClaimsList_PaidCheckbox_xpath = ".//label[contains(@for,'FilterByStatusPaid')]";
        public string ClaimsList_Cancelled_xpath = ".//label[contains(@for,'FilterByStatusCancelled')]";

        public string ClaimsList_InformationIcon_xpath = ".//button[@class='icon-circle-info icon-i btn btn-info icon-circle']";

        public string ClaimsList_InformationIconPaid_xpath = ".//*[@id='gridInsuranceClaimList']//tr/td[10]//button[@class='icon-circle-info icon-i btn btn-info icon-circle']";


        public string StationCustomerColClick_xpath = ".//*[@id='gridInsuranceClaimList']//tr/th[1]";
        public string DatesColClick_xpath = ".//*[@id='gridInsuranceClaimList']//tr/th[2]";
        public string ClaimNumbersColClick_xpath = ".//*[@id='gridInsuranceClaimList']//tr/th[3]";
        public string InsuredColClick_xpath = ".//*[@id='gridInsuranceClaimList']//tr/th[4]";
        public string AmountColClick_xpath = ".//*[@id='gridInsuranceClaimList']//tr/th[5]";
        public string DLSWRefNumColClick_xpath = ".//*[@id='gridInsuranceClaimList']//tr/th[6]";
        public string CarrierColClick_xpath = ".//*[@id='gridInsuranceClaimList']//tr/th[7]";
        public string DLSWClaimSpecColClick_xpath = ".//*[@id='gridInsuranceClaimList']//tr/th[8]";
        public string SubmittedByColClick_xpath = ".//*[@id='gridInsuranceClaimList']//tr/th[9]";
        public string statusColClick_xptah = ".//*[@id='gridInsuranceClaimList']//tr/th[10]";


        public string ClaimsList_Station_ALLValues_Xpath = ".//*[@id='gridInsuranceClaimList']//tr[@role = 'row']/td[1]";
        public string ClaimsList_Customer_ALLValues_Xpath = ".//*[@id='gridInsuranceClaimList']//tr[@role = 'row']/td[1]/br";
        public string ClaimsList_Dates_ALLValues_xpath = ".//*[@id='gridInsuranceClaimList']//tr[@role = 'row']/td[2]";
        public string ClaimsList_DLSWClaimsNumber_ALLValues_xpath = ".//*[@id='gridInsuranceClaimList']//tr[@role = 'row']/td[3]/span[1]/a";
        public string ClaimsList_Insured_ALLValues_xpath = ".//*[@id='gridInsuranceClaimList']//tr[@role = 'row']/td[4]";
        public string ClaimsList_Amount_ALLValues_xpath = ".//*[@id='gridInsuranceClaimList']//tr[@role = 'row']/td[5]";
        public string ClaimsList_DLSWRefNumber_ALLValues_xpath = ".//*[@id='gridInsuranceClaimList']//tr[@role = 'row']/td[6]";
        public string ClaimsList_Carrier_ALLValues_xpath = ".//*[@id='gridInsuranceClaimList']//tr[@role = 'row']/td[7]";
        public string ClaimsList_DLSWClaimSpec_ALLValues_xpath = ".//*[@id='gridInsuranceClaimList']//tr[@role = 'row']/td[8]";
        public string ClaimsList_SubmittedBy_ALLValues_xpath = ".//*[@id='gridInsuranceClaimList']//tr[@role = 'row']/td[9]";
        public string ClaimsList_Status_ALLValues_xpath = ".//*[@id='gridInsuranceClaimList']//tr[@role = 'row']/td[10]/span";

        public string ClaimsList_FirstVal_DLSWClaimNum_xpath = ".//*[@id='gridInsuranceClaimList']//tr[1]/td[3]/span[1]/a";
        public string ClaimsList_FirstVal_DLSWClaimNumber_stationUser_xpath = ".//*[@id='gridInsuranceClaimList']//tr/td[4]/span/a";


        public string StationValUi_xpath = ".//*[@id='gridInsuranceClaimList']//tr[1]/td[1]";
        public string CustValUIXpath = ".//*[@id='gridInsuranceClaimList']//tr[1]/td[1]";
        public string SubmitDateValUIXpath = ".//*[@id='gridInsuranceClaimList']//tr[1]/td[2]";
        public string ACKDateValUIXpath = ".//*[@id='gridInsuranceClaimList']//tr[1]/td[2]";
        public string DLSW_CLaimNumberValUi_xpath = ".//*[@id='gridInsuranceClaimList']//tr[1]/td[3]/span[1]/a";
        public string CarrierCLaimNumberValUi_xpath = ".//*[@id='gridInsuranceClaimList']//tr[1]/td[3]/span[2]";
        public string InsuredCol_ValUi_xpath = ".//*[@id='gridInsuranceClaimList']//tr[1]/td[4]";
        public string OriginalAmt_ValUi_xpath = ".//*[@id='gridInsuranceClaimList']//tr[1]/td[5]";
        public string DLSWRefNumberValUi_xpath = ".//*[@id='gridInsuranceClaimList']//tr[1]/td[6]";
        public string Carrier_NameValUi_xpath = ".//*[@id='gridInsuranceClaimList']//tr[1]/td[7]";
        public string Carrier_PROValUI_xpath = ".//*[@id='gridInsuranceClaimList']/tbody/tr[1]/td[7]";
        public string DLSWClaimSpec_ValUi_xpath = ".//*[@id='gridInsuranceClaimList']//tr[1]/td[8]";
        public string SubmittedBy_ValUi_xpath = ".//*[@id='gridInsuranceClaimList']//tr[1]/td[9]";
        public string Status_valUI_xpath = ".//*[@id='gridInsuranceClaimList']//tr[1]/td[10]/span";


        public string ClaimListGridAmendSavedFormLink_ClassName = "DlswClaimNumberAmend";
        public string CliamListGridOriginalSavedFormLink_ClassName = "DlswClaimNumber";
        public string ClaimListClaimMouseHover_ClassName = "tooltip-inner";



        public string DocumentSectionText_Id = "";
        public string RequiredDocumentDisplay_Message_Xpath = "";
        public string InformationHover_Icon_Xpath = "";
        public string DocumentUploadButton_Id = "";
        public string ToolTip_Verbiage_Xpath = "";



        public string DocumentDropdown_Xpath = ".//*[@id='DocType_0_chosen']/a";
        public string DocumentDropdownValues_Xpath = ".//*[@id='DocType_0_chosen']//*[@class = 'chosen-results']/*[@class ='active-result']";
        public string AdditionalUploadButton_Xpath = "//div[@class='DocumentAddtionalSectionAppend']//div[@class='col-md-12 documentsectionpadding']//div[@class='col-md-8']//div[@class='form-inline']//div[@class='form-group']//button[@class='btn btn-color btn-document-upload']";
        public string AdditionalUploadButton_Css = "div.col-md-12.documentsectionpadding.NewSavedDocument > div.col-md-8 > div.form-inline > div.form-group > button.btn.btn-color.btn-document-upload > i.fa.fa-upload";
        public string AdditionalUpload_NofileMessage_Xpath = "(//SPAN[text()='No file currently uploaded'][text()='No file currently uploaded'])[2]";
        public string AdditionalRemoveButton_Xpath = "//BUTTON[@id='btn-DocumentSectionAdditionalRemove']";
        public string AdditionalTooltip_Xpath = "(//BUTTON[@class='btn btn-color btn-sm documenttooltip'])[2]";
        public string AdditionalUploadedFile_Xpath = "//a[@class='documentLinkPreview']";
        public string AdditionalDeleteButton_Xpath = "(//A[@class='dz-remove fa fa-trash'])[1]";
        public string AdditionalDeleteConfirmationModal_Xpath = "//H3[text()='Delete File']";
        public string AdditionalModalDeleteButton_Id = "Add-delete-document-yes";
        public string AdditionalModalCancelButton_Xpath = "//a[@href='javascript:void(0)'][contains(text(),'Cancel')]";
        public string DocumentDeletePopup_Xpath = "//*[@class='modal-header']";
        public string DocumentValidation_Message_Xpath = "//*[@class='form-group filetypeInvalid']";
        public string ClaminDetailsConfigurableVerbiage_Xpath = "//p[@class='claimPayableSectionTitle'][contains(text(),'Claims must be supported by a detailed statement s')]";
        public string AdditionalDocMessageSubmit_Xpath = "(//SPAN[text()='Please add document to claim form'][text()='Please add document to claim form'])[2]";

        public string ClaimListSearchTextBox_xpath = ".//*[@id='gridInsuranceClaimList_filter']/label/input";
        public string ClaimListClaimNumberHyperLink_xpath = ".//*[@id='gridInsuranceClaimList']//tr/td[3]/span[1]/a/span";
        public string ClaimListClaimNumberHyperLink_AfterSearch_Xpath = ".//*[@id='gridInsuranceClaimList']//td[3]//a/span";
        public string ClaimListClaimNumberHyperLinkStationUsers_xpath = ".//*[@id='gridInsuranceClaimList']//td[4]/span/a";
        public string ClaimListDLSWClaimSpecialist_Xpath = ".//*[@id='gridInsuranceClaimList']//td[8]";
        public string ClaimListSpecialistUserAmount_Xpath = "//tr[1]//td[5]";

        //----------------------Claims List New status options ------------------------------------------//
        public string ClaimsList_SubmittedStatusCheckBox_Xpath = ".//label[contains(@for,'FilterByStatusSubmitted')]";
        public string ClaimsList_AmendStatusCheckBox_Xpath = ".//label[contains(@for,'FilterByStatusAmend')]";
        public string ClaimList_AmendStatusCheckbox_Id = "FilterByStatusAmend";
        public string ClaimsList_SelectAllCheckBox_Xpath = ".//label[contains(@for,'FilterByStatusSelectAll')]";
        public string ClaimsListGrid_SubmittedStatusColor_xpath = ".//tr[1]/td[@class=' td-status']/span";
        public string ClaimsListGrid_AmendStatusColor_xpath = ".//tr[1]/td[@class=' td-status']/span";
        public string ClaimListGridValues_Xpath = ".//*[@id='gridInsuranceClaimList']/tbody/tr/td";
        public string ClaimListDateSortValues_Xpath = ".//tr/td[contains(@class,'SubmitClaimDateSort')]";
        public string ClaimListAmendCheckBox_Xpath = ".//input[@id='FilterByStatusAmend']";
        public string ClaimListSubmittedCheckBox_Xpath = ".//input[@id='FilterByStatusSubmitted']";
        public string ClaimListOpenCheckBox_Xpath = ".//input[@id='FilterByStatusOpen']";
        public string ClaimListPaidCheckBox_Xpath = ".//input[@id='FilterByStatusPaid']";
        public string ClaimListDeniedCheckBox_Xpath = ".//input[@id='FilterByStatusDenied']";
        public string ClaimListCancelledCheckBox_Xpath = ".//input[@id='FilterByStatusCancelled']";
        public string ClaimListSelectAllCheckBox_Xpath = ".//input[@id='FilterByStatusSelectAll']";
        public string ClaimListEditIcon_Xpath = ".//tr[1]//i[@class='icon-edit amend-icon']";
        public string ClaimList_ShowStatusAllOptions_Xpath = "//*[@id='gridInsuranceClaimList_wrapper']//label[contains(@for,'FilterByStatus')]";
        public string ClaimList_Ack_HoverSpan_Xpath = "//*[@id='gridInsuranceClaimList']/tbody/tr/td[2]/span";
        public string ClaimList_Ack_HoverMessage_ClaimSpecialist_Xpath = "//*[@id='gridInsuranceClaimList']/tbody/tr/td[2]/div/div[2]";
        public string ClaimList_Ack_HoverMessage_NonClaimSpecialist_Xpath = "//*[@id='gridInsuranceClaimList']/tbody/tr[1]/td[1]/a/div/div[2]";
        public string ClaimList_Ack_Link_Xpath = "//*[@id='gridInsuranceClaimList']/tbody/tr/td[2]/span/a";
        public string ClaimList_Grid_ClaimNumbers = "//*[@id='gridInsuranceClaimList']/tbody/tr/td/span/a";
        public string ClaimList_Grid_First_Row_AckDate_Xpath= "//*[@id='gridInsuranceClaimList']/tbody/tr[1]/td[2]/span/a";
        public string ClaimAmendedByCustomerTabReportExportButton_Xpath = "//ul[@id='export-list-profile']//li/a[text()='Claim Amended By Customer']";
        public string ClaimList_AmendGrid_FirstClaimNumber_Xpath = "(.//a[@class = 'DlswClaimNumber'])[1]";
        public string AmendEditIcon_Xpath = "//*[@id='gridInsuranceClaimList']/tbody/tr/td[4]/span[2]/i";
        

        //-------------------Claim Details Page------------------------------------------------------//
        public string ClaimsListGrid_Info_Id = "gridInsuranceClaimList";
        public string FirstClaimNumber_ClaimsListGrid_Xpath = ".//*[@id='gridInsuranceClaimList']/tbody/tr[1]/td[4]/span/a";
        public string ClaimSpecilistFirstClaimNumber_ClaimsListGrid_Xpath = "//*[@id='gridInsuranceClaimList']/tbody/tr[1]/td[3]/span/a";
        public string FirstClaimNumber_ClaimsListGid_ClaimSpecialistUser_Xpath = ".//*[@id='gridInsuranceClaimList']/tbody/tr[1]/td[3]/span[1]/a";
        public string FirstClaimAge_ClaimList_Xpath = ".//*[@id='gridInsuranceClaimList']/tbody/tr[1]/td[10]";

        public string ClaimDetailsPage_Header_Xpath = ".//h1[contains(text(), 'Claim Details')]";
        public string VerbiageAssociatedToClaimHeader_ClaimDetails_Xpath = "//*[@id='page-content-wrapper']//*[@data-headersubtitle]";
        public string DlswClaimNumber_Label_ClaimDetails_Id = "lbl_dlswClaimNum";
        public string CarrierName_Label_ClaimDetails_Id = "lbl_carrierName";
        public string ClaimRep_Label_ClaimDetails_Id = "lbl_claimRep";
        public string Insured_Label_ClaimDetails_Id = "lbl_insured";
        public string Claimant_Label_ClaimDetails_Id = "lbl_claimant";
        public string ClaimAge_Label_ClaimDetails_Id = "lbl_claimAge";
        public string ClaimDetailsPage_CustomerClaimReferenceNumber_Label_Id = "customer-claim-reference-label";   

        public string DlswClaimNumber_Value_ClaimDetails_Id = "dlswClaim";
        public string CarrierName_Value_ClaimDetails_Id = "carrierName";
        public string ClaimRep_Value_ClaimDetails_Id = "claimRep";
        public string Insured_Value_ClaimDetails_Id = "insured";
        public string Claimant_Value_ClaimDetails_Id = "Claimant";
        public string ClaimAge_Value_ClaimDetails_Id = "ClaimAge";
        public string ClaimDetailsPage_CustomerClaimReferenceNumber_Value_Id = "CustomerClaimReferenceNumber";

        public string BackToClaimsList_Button_ClaimDetails_Id = "btn_backToClaimList";
        public string EditButton_class = "icon-edit";
        public string Edit_Button_ClaimDetails_Id = "editClaimDetails";
        public string Print_Button_ClaimDetails_Id = "btn-Print";
        public string ClaimNumber_ClaimListCount = ".//*[@id='gridInsuranceClaimList']/tbody/tr/td[4]";
        public string ClaimListGridDataCount_Xpath = ".//*[@id='gridInsuranceClaimList']/tbody/tr[1]/td";

        public string ClaimListGrid_PageViewOption_dropdown_Xpath = ".//*[@id='gridInsuranceClaimList_length']/label/select";
        public string ClaimListGrid_PageViewOption_dropdownAnchor_Xpath = ".//*[@id='gridInsuranceClaimList_length']//*[@class ='chosen-single']";
        public string ClaimListGrid_PageViewOption_dropdownSelectlabel_Xpath = ".//*[@id='gridInsuranceClaimList_length']/label//li";
        public string ClaimListGrid_PageViewOption_dropdownValue_All_Xpath = ".//*[@id='gridInsuranceClaimList_length']/label/select/option[5]";
        public string SaveClaimDetailsButton_Id = "btnSaveClaimDetails";
        public string SaveClaimDetailsButton_Xpath = "//BUTTON[@id='btnSaveClaimDetails']";
        public string ChangesNotSavedModal_Xpath = ".//*[@id='modalPageLeavingWarning']//h3";
        public string ChangesNotSavedModalText_Xpath = ".//*[@id='modalPageLeavingWarning']//p[1]";
        public string ChangesNotSavedModalNoteText_Xpath = ".//*[@id='modalPageLeavingWarning']//p[2]";
        public string LeavePageWithoutSavingButton_Id = "btnLeave";
        public string ReturnToClaimDetailsButton_Id = "btnStay";

        //---------------------Claim Details page,Details tab -------------------------------------//
        public string ClaimDetailsButton_Xpath = "//a[@data-toggle='tab'][contains(text(),'Details')]";
        public string ClaimGrid_DLSW_Total_ClaimNumber_Xpath = "//td[4]/span[@class='dlsw-claim-number']";
        public string ClaimGrid_DLSW_First_ClaimNumber_Xpath = "//tr[1]/td[4]//*[@class='DlswClaimNumber']";

        public string ClaimGrid_DLSW_Total_ClaimNumber_ClaimSpecialist_Xpath = "//td[3]/span[@class='dlsw-claim-number']";
     //   public string ClaimGrid_DLSW_First_ClaimNumber_ClaimSpecialist_Xpath = "//tr[1]/td[3]//*[@class='DlswClaimNumber']";
        public string ClaimGrid_DLSW_First_ClaimNumber_ClaimSpecialist_Xpath = ".//*[@id='gridInsuranceClaimList']/tbody/tr[1]/td[3]/span[1]/a";
        public string ClaimGrid_DLSW_First_ClaimNumber_Non_ClaimSpecialist_Xpath = "//*[@id='gridInsuranceClaimList']/tbody/tr[1]/td[4]/span/a";
        public string ClaimList_Grid_First_Acknowledgement_Icon = "//*[@id='gridInsuranceClaimList']/tbody/tr[1]/td[1]/a/img";
        //Claim Details page,Details tab

        public string ClaimDetails_PageLebel_Xpath = ".//*[@id='page-content-wrapper']//*[@class='page-heading']";
        public string DetailsPage_verbiageBeneathPageLebel_Xpath = "//div[@class='col-md-3 col-sm-6 col-xs-9 heading-div']//*[contains(text(),'The details for this claim')]";
        public string ClaimDetails_ShipmentMode_DropdownValues_Xpath = "";
        public string ClaimStatus_Xpath = ".//*[@id='CarrierMode_chosen']//a";
        public string ClaimStatusDropdownValues_Xpath = ".//*[@id='CarrierMode_chosen']//li";

        public string ClaimDetailsTabText_Xpath = ".//*[@id='page-content-wrapper']//*[@id='tabClaimDetailDetails']";
        public string Consignee_Xpath = ".//*[@id='page-content-wrapper']//*[text()='Consignee']";
        public string Consignee_Name_Id = "ConsigneeName";
        public string Consignee_Address_Id = "ConsigneeAddress";
        public string Consignee_City_Id = "ConsigneeCity";
        public string Consignee_State_Id = "ConsigneeStateText";
        public string Consignee_StateDropdown_Xpath = ".//*[@id='ConsigneeStatedrpdown_chosen']/a";
        public string Consignee_StateValue_Xpath = ".//*[@id='ConsigneeStatedrpdown_chosen']//*[@class='group-result']";
        public string Consignee_Zip_Id = "ConsigneeZip";
        public string Consignee_Country_Xpath = ".//*[@id='ConsigneeCountry_chosen']//a";
        public string Consignee_CountryValues_Xpath = ".//*[@id='ConsigneeCountry_chosen']//*[@class='chosen-results']";
        public string Consignee_Country_NoCountrySelected_Xpath = ".//*[@id='ConsigneeCountry_chosen']//*[@class='chosen-results']//li[1]";
        public string DLSW_OSD_Actions_Xpath = ".//*[@id='page-content-wrapper']//*[text()='Carrier OS&D Actions']";
        public string CarrierOSDActions_CarrierAck_Id = "CarrierAck";
        public string CarrierOSDActions_CarrierAck_Xpath = ".//*[@id='CarrierAck_chosen']/a";
        public string CarrierOSDActions_CarrierAckValues_Xpath= ".//*[@id='CarrierAck_chosen']//li";
        public string CarrierOSDActions_CarrierAck_SecondValue_Xpath = ".//*[@id='CarrierAck_chosen']//li[text()='N']";
        public string CarrierOSDActions_CarrierAck_FirstValue_Xpath = ".//*[@id='CarrierAck_chosen']//li[Text()='Y']";
        public string CarrierOSDActions_CarrierAckDate_Id = "CarrierAckDate";
        public string CarrierOSDActions_CarrierClaimNumber_Id = "CarrierClaimNumber";
        public string KeyDates_Xpath = ".//*[@id='page-content-wrapper']//*[text()='Key Dates']";
        public string KeyDates_CarrierProDate_Id = "CarrierProDate";
        public string KeyDates_BOLDate_Id = "BolDate";
        public string KeyDates_DeliveryDate_Id = "DeliveryDate";

        public string Consignee_Name_Xpath = "//input[@id='ConsigneeName']";
        public string Consignee_Address_Xpath = "//input[@id='ConsigneeAddress']";
        public string Consignee_City_Xpath = "//input[@id='ConsigneeCity']";
        public string Consignee_State_Xpath = "//input[@id='ConsigneeStateText']";
        public string Consignee_Zip_Xpath = "//input[@id='ConsigneeZip']";

        public string Remarks_Id = "ConsigneeRemartksField";
        public string Details_SubmitClaimDetails_Button_Id = "btnSaveClaimDetails";
        public string shipmentMode_Id = "CarrierType";
        public string shipmentMode_Xpath = ".//*[@id='CarrierType_chosen']//span";
        public string shipmentModeFirstOption_Xpath = ".//*[@id='CarrierType_chosen']/div/ul/li[1]";
        public string shipmentModeSecondOption_Xpath = ".//*[@id='CarrierType_chosen']/div/ul/li[2]";
        public string shipmentModeThirdOption_Xpath = ".//*[@id='CarrierType_chosen']/div/ul/li[3]";
        public string shipmentMode_type_Xpath = ".//*[@id='CarrierMode_chosen']//span";
        public string selectButton_id = "btnSelect";
        public string StatusClaim_Xpath = ".//*[@id='CarrierMode_chosen']/a";
        public string StatusClaimValues_Xpath = ".//*[@id='CarrierMode_chosen']/div/ul/li";
        public string StatusOpen_Xpath = ".//*[@id='CarrierMode_chosen']/div/ul/li[1]";
        public string StatusDenied_Xpath = ".//*[@id='CarrierMode_chosen']/div/ul/li[32]";
        public string StatusCancelled_Xpath = ".//*[@id='CarrierMode_chosen']/div/ul/li[15]";
        public string airline_label_Xpath = ".//label[@for='airline']";
        public string pickupCarrier_label_Xpath = ".//label[@for='pickupcarrier']";
        public string deliveryCarrier_label_Xpath = ".//label[@for='deliverycarrier']";
        public string steamShipLine_label_Xpath = ".//label[@for='steamshipline']";
        public string freightForwarder_label_Xpath = ".//label[@for='freightforwarder']";
        public string whiteGloveAgent_label_Xpath = ".//label[@for='whitegloveagent']";
        public string airline_values_Xpath = ".//*[@id='airline_chosen']//ul/li";
        public string airline_Id = "airline_chosen";
        public string pickupCarrier_Id = "pickupcarrier_chosen";
        public string pickupCarrier_values_Xpath = ".//*[@id='pickupcarrier_chosen']//ul/li";
        public string deliveryCarrier_values_Xpath = ".//*[@id='deliverycarrier_chosen']//ul/li";
        public string deliveryCarrier_Id = "deliverycarrier_chosen";
        public string steamShipLine_values_Xpath = ".//*[@id='steamshipline_chosen']//ul/li";
        public string steamshipLine_Id = "steamshipline_chosen";
        public string freightForwarder_values_Xpath = ".//*[@id='freightforwarder_chosen']//ul/li";
        public string freightForwarder_Id = "freightforwarder_chosen";
        public string whiteGloveAgent_values_Xpath = ".//*[@id='whitegloveagent_chosen']//ul/li";
        public string whiteGloveAgent_Id = "whitegloveagent_chosen";
        public string airlineDropdown_Xpath = ".//*[@id='airline_chosen']//span";
        public string pickupCarrierDropdown_Xpath = ".//*[@id='pickupcarrier_chosen']//span";
        public string deliveryCarrierDropdown_Xpath = ".//*[@id='deliverycarrier_chosen']//span";
        public string steamShipLineDropdown_Xpath = ".//*[@id='steamshipline_chosen']//span";
        public string freightForwarderDropdown_Xpath = ".//*[@id='freightforwarder_chosen']//span";
        public string whiteGloveAgentDropdown_Xpath = ".//*[@id='whitegloveagent_chosen']//span";
        public string DLSWClmRefNoListCount_Xpath = ".//*[@id='gridInsuranceClaimList']//tr[@role = 'row']/td[3]/span/a";

        public string Forwarding_SpecificFields_Header_Xpath = ".//*[@id='ForwardingSectionWrapper']//h5";
        public string ClaimListDLSWREF_HyperLink_Xpath = "//A[@class='DlswClaimNumber']";
        public string CarrierColumn_Xpath = ".//*[@id='gridInsuranceClaimList']/tbody/tr/td[7]";

        public string FirstClaimNumber_ClaimsListGrid_InternalUser_Xpath = ".//*[@id='gridInsuranceClaimList']/tbody/tr[1]/td[4]/span/a";
        public string FirstClaimNumber_ClaimsListGrid_ClaimSpecialistUser_Xpath = ".//*[@id='gridInsuranceClaimList']/tbody/tr/td[3]/span[1]/a";
        public string ViewFormbutton_Id = "btnClaimForm";

        public string DlswClaimNumber_Label_ClaimDetailsPage_Xpath = ".//label[contains(text(), 'DLSW Claim #')]";
        public string Claimant_Label_ClaimDetailsPage_Xpath = ".//label[contains(text(), 'Claimant')]";
        public string CarrierSCAC_Label_ClaimDetailsPage_Xpath = ".//label[contains(text(), 'Carrier SCAC')]";
        public string DlswClaimRep_Label_ClaimDetailsPage_Xpath = ".//label[contains(text(), 'DLSW Claim Rep')]";
        public string ClaimReason_Label_ClaimDetailsPage_Xpath = ".//label[contains(text(), 'Claim  Reason')]";
        public string CarrierName_Label_ClaimDetailsPage_Xpath = ".//label[contains(text(), 'Carrier  Name')]";
        public string Station_Label_ClaimDetailsPage_Xpath = ".//label[contains(text(), 'Station')]";
        public string DateRequested_Label_ClaimDetailsPage_Xpath = ".//label[contains(text(), 'Date  Requested')]";
        public string CarrierPro_Label_ClaimDetailsPage_Xpath = ".//label[contains(text(), 'Carrier PRO #')]";
        public string DlswRefNumber_Label_ClaimDetailsPage_Xpath = ".//label[contains(text(), 'DLSW Ref #')]";
        public string ClaimAge_Label_ClaimDetailsPage_Xpath = ".//label[contains(text(), 'Claim  Age')]";
        public string Insured_Label_ClaimDetailsPage_Xpath = ".//label[contains(text(), 'Insured')]";

        public string DlswClaimNumber_Textbox_ClaimDetailsPage_Id = "DlswClaim";
        public string Claimant_Textbox_ClaimDetailsPage_Id = "Claimant";
        public string CarrierSCAC_Textbox_ClaimDetailsPage_Id = "CarrierScac";
        public string DlswClaimRep_dropdown_ClaimDetailsPage_Xpath = ".//*[@id='DlswClaimRep_chosen']/a";
        public string DlswClaimRep_DropdownValues_ClaimDetailsPage_Xpath = "//*[@id='DlswClaimRep_chosen']/div/ul/li";
        public string ClaimReason_Dropdown_ClaimDetailsPage_Xpath = ".//*[@id='ClaimReason_chosen']/a";
        public string ClaimReason_DropdownValues_ClaimDetailsPage_Xpath = ".//*[@id='ClaimReason_chosen']/div/ul/li";
        public string CarrierName_Dropdown_ClaimDetailsPage_Xpath = ".//*[@id='CarrierName_chosen']/a";
        public string CarrierName_DropdownValues_ClaimDetailsPage_Xpath = ".//*[@id='CarrierName_chosen']/div/ul/li";
        public string Station_Dropdown_ClaimDetailsPage_Xpath = ".//*[@id='Station_chosen']/a";
        public string Station_DropdownValues_ClaimDetailsPage_Xpath = ".//*[@id='Station_chosen']/div/ul/li";
        public string DateRequested_FieldValue_ClaimDetailsPage_Id = "DateRequested";
        public string CarrierPro_Textbox_ClaimDetailsPage_Id = "CarrierPro";
        public string DlswRefNumber_Textbox_ClaimDetailsPage_Id = "DlswRef";
        public string ClaimAge_Textbox_ClaimDetailsPage_Id = "ClaimAge";
        public string Insured_Dropdown_ClaimDetailsPage_Xpath = ".//*[@id='Insured_chosen']/a";
        public string Insured_DropdownValues_ClaimDetailsPage_Xpath = ".//*[@id='Insured_chosen']/div/ul/li";


        public string FreightClauclulations_Label_Xpath = ".//h2[contains(text(), 'Freight Calculations')]";
        public string ProrationLabel_ClaimDetailsPage_Xpath = ".//h5[contains(text(), 'PRORATION %')]";
        public string Information_Icon_ClaimDetailsPage_Xpath = "//BUTTON[@class='btn btn-padding btn-color btn-sm freightTooltip']";
        public string ToolTip_Message_Xpath = "//i[@class='icon-i info-padding']";
        public string Type_ColumnHeader_FreightCalculation_Xpath = ".//th[contains(text(), 'Type')]";
        public string Claimable_ColumnHeader_FreightCalculation_Xpath = ".//th[contains(text(), 'CLAIMABLE?')]";
        public string ClaimedFreight_ColumnHeader_FreightCalculation_Xpath = "//th[contains(text(), 'CLAIMED FREIGHT')]";
        public string CarrierChargesTODLSW_ColumnHeader_FreightCalculation_Xpath = ".//th[contains(text(), 'CARRIER CHARGES TO DLSW')]";
        public string DLSWChargesToCust_ColumnHeader_FreightCalculation_Xpath = ".//th[contains(text(), 'DLSW CHARGES TO CUST')]";
        public string DLSWReferenceNumber_ColumnHeader_FreightCalculation_Xpath = ".//th[contains(text(), 'DLSW REF #')]";

        public string Original_Row_label_Xpath = ".//td[contains(text(), 'Original')]";
        public string Return_Row_label = ".//td[contains(text(), 'Return')]";
        public string Replacement_Row_label = ".//td[contains(text(), 'Replacement')]";

        public string Claimable_dropdown_Original_Xpath = ".//*[@id='ORIGINALCLAIMABLE_chosen']/a";
        public string Claimable_dropdownValue_Original_Xpath = "//*[@id='ORIGINALCLAIMABLE_chosen']/div/ul/li";
        public string Claimabledropdown_Return_Xpath = ".//*[@id='RETURNCLAIMABLE_chosen']/a";
        public string ClaimabledropdownValue_Return_Xpath = ".//*[@id='RETURNCLAIMABLE_chosen']/div/ul/li";
        public string Claimabledropdown_Replacement_Xpath = ".//*[@id='REPLACEMENTCLAIMABLE_chosen']/a";
        public string ClaimabledropdownValue_Replacement_Xpath = ".//*[@id='REPLACEMENTCLAIMABLE_chosen']/div/ul/li";

        public string ClaimedFreight_Textbox_Original_Id = "ORIGINALCLAIMEDFREIGHT";
        public string CarrierChargesToDLSW_Textbox_Original_Id = "ORIGINALCARRIERCHARGESTODLSW";
        public string DLSWChargesToCust_Textbox_Original_Id = "ORIGINALDLSWCHARGESTOCUST";
        public string DLSWRefNumeber_Textbox_Original_Id = "ORIGINALDLSWREF";

        public string FrieghtCal_TTLWeight_Id = "TTLWGT";
        public string FrieghtCal_TotalShipmentWEIGHT_Xpath = "//input[@class='form-control totalshpwht']";

        public string ClaimedFreight_Textbox_Return_Id = "RETURNCLAIMEDFREIGHT";
        public string CarrierChargesToDLSW_Textbox_Return_Id = "RETURNCARRIERCHARGESTODLSW";
        public string DLSWChargesToCust_Textbox_Return_Id = "RETURNDLSWCHARGESTOCUST";
        public string DLSWRefNumeber_Textbox_Return_Id = "RETURNDLSWREF";

        public string ClaimedFreight_Textbox_Replacement_Id = "REPLACEMENTFREIGHT";
        public string CarrierChargesToDLSW_Textbox_Replacement_Id = "REPLACEMENTCARRIERCHARGESTODLSW";
        public string DLSWChargesToCust_Textbox_Replacement_Id = "REPLACEMENTDLSWCHARGESTOCUST";
        public string DLSWRefNumeber_Textbox_Replacement_Id = "REPLACEMENTLSWREF";
        public string KeyDates_CarrierProDate_CalenderIcon_Xpath = "";
        public string KeyDates_CarrierProDate_CalenderRightArrow_Xpath = "";
        public string KeyDates_CarrierProDate_futureDate_Xpath = "";
        public string KeyDates_BOLDate_CalenderIcon_Xpath = "";
        public string KeyDates_BOLDate_CalenderRightArrow_Xpath = "";
        public string KeyDates_BOLDate_futureDate_Xpath = "";
        public string KeyDates_DeliveryDate_CalenderIcon_Xpath = "";
        public string KeyDates_DeliveryDate_CalenderRightArrow_Xpath = "";
        public string KeyDates_DeliveryDate_futureDate_Xpath = "";

        public string InsuranceInfo_Xpath = "";
        public string ProductClaimed_Xpath = "";
        public string FreightCalculation_Xpath = "";
        public string Comments_Xpath = "";

        //Products Claimed scetion
        public string ProductClaimed_CLMTYP_Value_Xpath = ".//*[@id='CLMTypeDropdown_0_chosen']//a[@class='chosen-single']";
        public string ProductClaimed_ARTTYP_Value_Xpath = ".//*[@id='ArticleTypeDropdown_0_chosen']//a[@class='chosen-single']";
        public string ProductClaimed_QTY_Id = "QTY";
        public string ProductClaimed_ITEM_Id = "ITEM#";
        public string ProductClaimed_DESC_Id = "DESC";
        public string ProductClaimed_UNITWGT_Id = "UNITWGT";
        public string ProductClaimed_UNITVAL_Id = "UNITVAL";

        public string ProductClaimed_CLMTYP_LastRowValue_Xpath = "//table[@class='productclaimtable']/tbody/tr[@class='productclaimborder'][last()]/td[1]/div";
        public string ProductClaimed_ARTTYP_LastRowValue_Xpath = "//table[@class='productclaimtable']/tbody/tr[@class='productclaimborder'][last()]/td[2]/div";
        public string ProductClaimed_QTY_LastRowValue_Xpath = "//table[@class='productclaimtable']/tbody/tr[@class='productclaimborder'][last()]//input[@id='QTY']";
        public string ProductClaimed_ITEM_LastRowValue_Xpath = "//table[@class='productclaimtable']/tbody/tr[@class='productclaimborder'][last()]//input[@id='ITEM#']";
        public string ProductClaimed_DESC_LastRowValue_Xpath = "//table[@class='productclaimtable']/tbody/tr[@class='productclaimborder'][last()]//input[@id='DESC']";
        public string ProductClaimed_UNITWGT_LastRowValue_Xpath = "//table[@class='productclaimtable']/tbody/tr[@class='productclaimborder'][last()]//input[@id='UNITWGT']";
        public string ProductClaimed_UNITVAL_LastRowValue_Xpath = "//table[@class='productclaimtable']/tbody/tr[@class='productclaimborder'][last()]//input[@id='UNITVAL']";
        
        public string FirstClaimType_xpath = ".//*[@id='CLMTypeDropdown_0_chosen']/a";
        public string FirstArticleType_xpath = ".//*[@id='ArticleTypeDropdown_0_chosen']/a";
        public string FirstItemType_xpath = ".//*[@class='productclaimtable']//tr[1]/td[4]//input";
        public string FirstUnitValue_xpath = ".//*[@class='productclaimtable']//tr[1]/td[6]//input";
        public string FirstQuantity_xpath = ".//*[@class='productclaimtable']//tr[1]/td[3]//input";
        public string Firstitem_xpath = ".//*[@class='productclaimtable']//tr[1]/td[4]//input";
        public string firstDescription_claimedarticles_xpath = ".//*[@class='productclaimtable']//tr[1]/td[5]//input";
        public string FirstUnitWgt_xpath = ".//*[@class='productclaimtable']//tr[1]/td[6]//input";
        public string FirstExtwgt_xpath = ".//*[@class='productclaimtable']//tr[1]/td[7]//input";
        public string firstUnitval_xpath = ".//*[@class='productclaimtable']//tr[1]/td[8]//input";
        public string firstextval_xpath = ".//*[@class='productclaimtable']//tr[1]/td[9]//input";
        public string totalshipmentvalue_xpath = ".//*[@class='form-control totalshpwht']";
        public string addAnotherItembutton_xpath = ".//*[@class='btn_AnotherItemPC']";
        public string AddAnotherItem_Xpath = "//a[@id='btn-AddAdditionalClaim']";
        public string FirstAdditionalItemUnitVal_Xpath = "//div[@class='ClaimAdditionalSectionAppend']//div[@class='ClaimItemSection']//div[@class='row']//div[@class='col-md-3 requiredlabel']//div[@class='form-group']//div//input[@id='UnitValue']";
        public string FirstAdditionalItemQuantityVal_Xpath = "//div[@class='ClaimAdditionalSectionAppend']//div[@class='ClaimItemSection']//div[@class='row']//div[@class='col-md-3 requiredlabel']//div[@class='form-group']//div//input[@id='Quantity']";
        public string claimtypevalues_xpath = ".//*[@id='CLMTypeDropdown_0_chosen']/div/ul/li";
        public string ArticlesTypeValues_xpath = ".//*[@id='ArticleTypeDropdown_0_chosen']/div/ul/li";

        public string ProductsClaimed_Xpath = ".//div[@class='col-md-12 PClaimedPadding']/h2";
        public string ClmType_Header_Xpath = ".//*[@class='productclaimtable']//th[1]";
        public string ArtType_Header_Xpath = ".//*[@class='productclaimtable']//th[2]";
        public string Qty_Header_Xpath = ".//*[@class='productclaimtable']//th[3]";
        public string Item_Header_Xpath = ".//*[@class='productclaimtable']//th[4]";
        public string Desc_Header_Xpath = ".//*[@class='productclaimtable']//th[5]";
        public string UnitWgt_Header_Xpath = ".//*[@class='productclaimtable']//th[6]";
        public string ExtWgt_Header_Xpath = ".//*[@class='productclaimtable']//th[7]";
        public string UnitVal_Header_Xpath = ".//*[@class='productclaimtable']//th[8]";
        public string ExtVal_Header_Xpath = ".//*[@class='productclaimtable']//th[9]";
        public string UnitWgtValuesList_Xpath = ".//*[@class='productclaimtable']//td[6]//input";
        public string ExtWgtValuesList_Xpath = ".//*[@class='productclaimtable']//td[7]//input[@disabled='disabled']";
        public string UnitValList_Xpath = ".//*[@class='productclaimtable']//td[8]//input[@disabled='disabled']";
        public string ExtValList_Xpath = ".//*[@class='productclaimtable']//td[8]//input[@disabled='disabled']";
        public string TotalPcsLabel_Xpath = ".//*[@class='row productclaimborder AdditionalItemPC']/div[2]/label";
        public string TotalPcs_Xpath = ".//*[@class='Totalpcslbl']";
        public string TotalWgtLabel_Xpath = ".//*[@class='row productclaimborder AdditionalItemPC']/div[3]/label";
        public string TotalWgt_id = "TTLWGT";
        public string TotalValLabel_Xpath = ".//*[@class='row productclaimborder AdditionalItemPC']/div[4]/label";
        public string Totalval_Xpath = ".//*[@class='TotalVALlbl']";
        public string TotalShipmentWeightLabel_Xpath = ".//*[@class='lblShipmentWeight']";
        public string TotalShipmentWeightValue_id = "totalShipmentWeight";
        public string RemoveItembutton_xpath = ".//*[@class='productclaimtable']//tr[1]/td[10]//*[@id='btn_ProductClaimRemove']";
        public string QtyValuesList_Xpath = ".//*[@class='productclaimtable']//td[3]//input[@disabled='disabled']";
        public string ItemList_Xpath = ".//*[@class='productclaimtable']//td[4]//input[@disabled='disabled']";
        public string DescList_Xpath = ".//*[@class='productclaimtable']//td[5]//input[@disabled='disabled']";
        public string TotalShipmentWeightValue_xpath = ".//*[@class='form-control totalshpwht']";
        //FTL Specific fields
        public string FTL_Specific_Fields_Header_xpath = ".//*[@id='FtlPlaceHolder']//h2";
        public string Carrier_MC_Id = "CarrierMc";
        public string Seal_Number_Id = "Seal";
        public string SealIntact_Xpath = ".//*[@id='SealIntact_chosen']/a";
        public string SealIntactValues_Xpath = ".//*[@id='SealIntact_chosen']//ul/li";
        public string VehicleNumber_Id = "Vehicle";
        public string ClaimDetails_DetailsTab_xpath = ".//*[@id='tabClaimDetail']//a[@href='#Tab_tabClaimDetailDetails']";



        //---------------------------Document Tab----------------------------------------//

        public string CustomerDetails_Documents_Xpath = ".//*[@id='page-content-wrapper']//*[@class='nav nav-tabs']//a[text()='Status/History']";
        public string ClaimDetails_Documenttab_xpath = ".//*[@id='tabClaimDetailDocuments']/a";
        public string ClaimDetails_DeleteDocumentIcon_xpath = ".//*[@id='divDocuments']/div[2]/div[2]/a[2]";
        public string ClaimDetails_DeleteDocumentModalMessage_xpath = ".//*[@id='deleteDocumentUploaded']/div//div[2]/div/h6";
        public string ClaimDetails_DeleteDocModal_CancelButton_xpath = ".//*[@id='deleteDocumentUploaded']//div/div[3]/a[1]";
        public string ClaimDetails_DeleteDocModal_DeleteButton_xpath = ".//*[@id='deleteSavedDocument']";
        public string ClaimDetails_FirstDocumentname_xpath = ".//*[@id='divDocuments']/div[2]/div[2]/a[1]";
        public string ClaimDetails_DeleteModalTitle_xpath = ".//*[@id='deleteDocumentUploaded']//div[1]/h3";
        public string ClaimDetails_NoFileCurrentlyUploaded_xpath = ".//*[@id='#divFilePreviewContainer1']/div[2]/p/span";
        public string ClaimDetails_DocTab_AddAdditionalDocButton_Id = "btnAddAdditionalDoc";
        public string ClaimDetaisl_DocTab_DocumentTypeDropDownList_xpath = ".//*[@id='divNewSelectedDocumentType']//div/label";
        public string ClaimDetails_DocTab_SelectDocumentTypeDefaultText_xpath = ".//div[@id='DocType1_chosen']/a[@class='chosen-single chosen-default']/span";
        public string ClaimDetails_DocTab_InactiveUploadButton_xpath = ".//*[@id='divNewSelectedDocumentType']//*[@class='btn-color btn-document-upload btn']";
        public string ClaimsDetails_DocTab_NofileuploadedVerbiage_xpath = ".//*[@id='divNewSelectedDocumentType']//*[text()='No file currently uploaded']";
        public string ClaimDetails_DocTab_RemoveButton_xpath = ".//*[@id='divNewSelectedDocumentType']//*[text()='Remove']";
        public string ClaimsDetails_DocTab_DocumentTypedropdownValues_xpath = ".//*[@id='DocType1_chosen']/div/ul/li";
        public string DetailsTab_DocumentsTab_Xpath = ".//*[@id='tabClaimDetailDocuments']/a";
        public string DetailsTab_DocumentsTab_RequiredDocument_Xpath = ".//*[@id='divDocuments']/div/div[1]/label";
        public string DetailsTab_DocumentsTab_Defaultone_Xpath = ".//*[@id='divDocuments']/div[2]//label";
        public string DetailsTab_DocumentsTab_AssciateDocument_Xpath = ".//*[@id='divDocuments']/div/div[2]/a[1]";
        public string DetailsTab_DocumentsTab_Note_Xpath = ".//*[@id='divDocuments']/div[1]//p";
        public string DetailsTab_DocumentTab_FirstDocument_Xpath = ".//*[@id='divDocuments']/div[2]/div[2]/a[1]";
        public string ClaimDetails_TotalClaimedFreight_Xpath = "//label[@class='lblClaimTotalClaim']";
        public string ClaimDetails_TotalClaimedFreightVal_Xpath = "//label[@class='totalClaimedlbl']";

        //--------------------------Status/History Tab----------------------------------//

        public string CustomerDetails_StatusOrHistory_Xpath = ".//li[@id='tabClaimDetailStatusHistory']/a";
        public string ClaimDetailsMode_Xpath = "//div[@id='CarrierType_chosen']//a[@class='chosen-single']";
        public string ClaimDetailsModeDropdown_Xpath = ".//*[@id='CarrierType_chosen']//ul/li";
        public string ClaimListPendingStatus_Xpath = "//LABEL[@for='FilterByStatusPending'][text()='Pending']";
        public string AddComment_Id = "btnAddComment";
        public string editIcon_HistoryTab_Xpath = ".//*[@id='InsuranceClaimHistoryGrid']//tr[1]/td[5]/a";
        public string Category_Xpath = ".//*[@id='InsuranceClaimHistoryGrid']//th[3]";
        public string CategoryValues_Xpath = ".//*[@id='InsuranceClaimHistoryGrid']//td[3]";
        public string LatestCategoryValue_Xpath = ".//*[@id='InsuranceClaimHistoryGrid']//tr[1]/td[3]";
        public string LatestDateTimeValue_Xpath = ".//*[@id='InsuranceClaimHistoryGrid']//tr[1]/td[1]";
        public string LatestupdatedByValue_Xpath = ".//*[@id='InsuranceClaimHistoryGrid']//tr[1]/td[2]";
        public string LatestCommentValue_Xpath = ".//*[@id='InsuranceClaimHistoryGrid']//tr[1]/td[4]";
        public string AddCommentPopupHeader_Xpath = ".//*[@id='modal_addComment']//h3";
        public string AddCommentPopup_CategoryLabel_Xpath = ".//*[@id='modal_addComment']//label[contains(text(),'CATEGORY')]";
        public string AddCommentPopup_Category_Xpath = ".//*[@id='CategoryType_chosen']/a";
        public string AddCommentPopup_CategoryValues_Xpath = ".//*[@id='CategoryType_chosen']//li";
        public string AddCommentPopup_CommentsLabel_Xpath = ".//*[@id='modal_addComment']//label[contains(text(),'COMMENT')]";
        public string AddCommentPopup_CommentSection_Xpath = ".//*[@id='HistoryComment']";
        public string AddComment_CancelButton_id = "btnCancel";
        public string AddComment_AddButton_Id = "btnSave";
        public string AddComment_ErrorMessage_Xpath = ".//*[@id='divHistoryCommentPopups']//p";

        //------History Tab -Elements/Edit Icon  ----
        public string AddButtonToSave = "btnSave";
        public string HistoryTab = "tabClaimDetailStatusHistory";
        public string HistoryTab_DateRangePlaceHolder = ".//*[@id='InsuranceClaimHistoryGrid']/tbody/tr[1]/td[1]";
        public string HistoryTab_Comments = ".//*[@id='InsuranceClaimHistoryGrid']/tbody/tr[1]/td[4]/p";
        public string HistoryTab_ViewMore_link = ".//*[@id='InsuranceClaimHistoryGrid']/tbody/tr[1]/td[4]/p/a";
        public string HistoryTab_OriginalComment = ".//*[@id='InsuranceClaimHistoryGrid']/tbody/tr[1]/td[4]/p";
        public string HistoryTab_Category_Xpath = ".//*[@id='InsuranceClaimHistoryGrid']/thead/tr/th[3]";
        public string HistoryTab_scrollbar = ".checkout-mini-cart";
        public string HistoryTab_UpdatedBy = ".//*[@id='InsuranceClaimHistoryGrid']/thead/tr/th[2]";
        public string HistoryTab_FistAndLastName = ".//*[@id='InsuranceClaimHistoryGrid']/tbody/tr[1]/td[2]";
        public string HistoryTab_EditCommentModal = ".//*[@id='modal_editComment']//h3";
        public string HistoryTab_CancelButton = "btnEditCancel";
        public string HistoryTab_SaveButton = "btnEditSave";
        public string HistoryTab_CategoryOption = ".//*[@id='InsuranceClaimHistoryGrid']/tbody/tr[1]/td[3]";
        public string HistoryTab_EditIcon = ".//*[@id='InsuranceClaimHistoryGrid']/tbody/tr[1]/td[5]/a/span";
        public string HistoryTab_SaveButton_Id = "btnEditSave";
        public string HistoryTab_ErrorMessage_id = "error-msg";
        public string HistoryTab_CategoryOptions = "CategoryType";
        public string HistoryTab_AddCommentTextBox = "HistoryComment";
        public string EditComment_ErrorMessage_Xpath = ".//*[@id='modal_editComment']//p";
        public string EditComment_CategoryLabel_Xpath = ".//*[@id='modal_editComment']//label[contains(text(),'CATEGORY')]";
        public string EditComment_CommentLabel_Xpath = ".//*[@id='modal_editComment']//label[contains(text(),'COMMENT')]";
        // Claim Details Page, Shipper Section - Fields Text
        public string DetailsTab_Shipper_ShipperSection_Xpath = ".//*[@id='formShipperDLSWOSAndActionsInsuranceInfoSection']//*[text()='Shipper']";
        public string DetailsTab_Shipper_Name_Xpath = ".//*[@id='formShipperDLSWOSAndActionsInsuranceInfoSection']//*[text()='Name']";
        public string DetailsTab_Shipper_Address_Xpath = ".//*[@id='formShipperDLSWOSAndActionsInsuranceInfoSection']//*[text()='Address']";
        public string DetailsTab_Shipper_Zip_Postal_Xpath = ".//*[@id='formShipperDLSWOSAndActionsInsuranceInfoSection']//*[text()='Zip/Postal']";
        public string DetailsTab_Shipper_Country_Xpath = ".//*[@id='formShipperDLSWOSAndActionsInsuranceInfoSection']//*[text()='Country']";
        public string DetailsTab_Shipper_City_Xpath = ".//*[@id='formShipperDLSWOSAndActionsInsuranceInfoSection']//*[text()='City']";
        public string DetailsTab_Shipper_State_Province_Xpath = ".//*[@id='formShipperDLSWOSAndActionsInsuranceInfoSection']//*[text()='State/Prov']";

        public string DetailsTab_Shipper_DLSW_OS_D_Actions_Xpath = ".//*[@id='formShipperDLSWOSAndActionsInsuranceInfoSection']//*[text()='DLSW OS&D Actions']";
        public string DetailsTab_Shipper_DateAckToClaimant_Xpath = ".//*[@id='formShipperDLSWOSAndActionsInsuranceInfoSection']//*[text()='Date  Ack to  Claimant']";
        public string DetailsTab_Shipper_DateFiled_W_CarrierXpath = ".//*[@id='formShipperDLSWOSAndActionsInsuranceInfoSection']//*[text()='Date Filed w/Carrier']";
        public string DetailsTab_Shipper_CycleTime_Xpath = ".//*[@id='formShipperDLSWOSAndActionsInsuranceInfoSection']//*[text()='Cycle  Time']";

        public string DetailsTab_Shipper_InsuranceInfo_Xpath = ".//*[@id='formShipperDLSWOSAndActionsInsuranceInfoSection']//*[text()='Insurance Info']";
        public string DetailsTab_Shipper_Program_Xpath = ".//*[@id='formShipperDLSWOSAndActionsInsuranceInfoSection']//*[text()='Program']";
        public string DetailsTab_Shipper_Amount_Xpath = ".//*[@id='formShipperDLSWOSAndActionsInsuranceInfoSection']//*[text()='Amount']";
        public string DetailsTab_Shipper_Company_Xpath = ".//*[@id='formShipperDLSWOSAndActionsInsuranceInfoSection']//*[text()='Company']";

        // Claims Details Page, Shipper Section - Fields Edit

        public string DetailsTab_Edit_Shipper_Name_Xpath = ".//*[@id='formShipperDLSWOSAndActionsInsuranceInfoSection']//*[@id='Name']";
        public string DetailsTab_Edit_Shipper_Address_Xpath = ".//*[@id='formShipperDLSWOSAndActionsInsuranceInfoSection']//*[@id='Address']";
        public string DetailsTab_Edit_Shipper_Zip_Postal_Xpath = ".//*[@id='formShipperDLSWOSAndActionsInsuranceInfoSection']//*[@id='ZipCode']";
        public string DetailsTab_Edit_Shipper_Country_Xpath = ".//*[@id='Country_chosen']//span";
        public string DetailsTab_Edit_Shipper_CountryDropdown_Xpath = ".//*[@id='Country_chosen']//a";
        public string DetailsTab_Edit_Shipper_CountryDD_Xpath = "//div[@id='Country_chosen']//a[@class='chosen-single chosen-default']";
        public string DetaislTab_Edit_Shipper_Country_Click_Xpath = ".//*[@id='formShipperDLSWOSAndActionsInsuranceInfoSection']//*[@id='Country_chosen']//span";
        public string DetailsTab_Edit_Shipper_CountryList_All_Xpath = ".//*[@id='Country_chosen']//*[@class='chosen-results']";
        public string DetailsTab_Edit_Shipper_City_Xpath = ".//*[@id='formShipperDLSWOSAndActionsInsuranceInfoSection']//*[@id='City']";
        public string DetailsTab_Edit_Shipper_Country_Value_Enter_Xpath = ".//*[@id='Country_chosen']//input";
        public string DetailsTab_Edit_Shipper_Country_EnterValue_Click_Xpath = ".//*[@id='Country_chosen']//ul/li[1]/em";
        public string DetailsTab_Edit_Shipper_State_Province_Xpath = "";
        public string DetailsTab_Edit_Shipper_State_Province_Click_Xpath = ".//*[@id='State_chosen']//span";
        public string DetailsTab_Edit_Shipper_state_Provice_All_Xpath = ".//*[@id='State_chosen']/div/ul/li";
        public string DetailsTab_Edit_Shipper_State_Province_TextBox_Value_Xpath = ".//*[@id='formShipperDLSWOSAndActionsInsuranceInfoSection']//*[@id='State']";

        public string DetailsTab_Edit_Shipper_DateAckToClaimant_Click_Id = "DateAckToClaimant";
        public string DetailsTab_Edit_Shipper_DateAckToClaimant_Month_Year_Xpath = ".//*[@class='datepicker-days']//tr[2]/th[2]";
        public string DetailsTab_Edit_Shipper_DateAckToClaimant_AllDate_Xpath = ".//*[@class='datepicker-days']//tr/td";
        public string DetailsTab_Edit_Shipper_DateFiled_W_Carrier_click_Id = "DateFiledWCarrier";
        public string DetailsTab_Edit_Shipper_DateFiled_w_Carrier_Month_Year_Xpath = ".//*[@class='datepicker-days']//tr[2]/th[2]";
        public string DetailsTab_Edit_Shipper_DateFiled_w_Carrier_AllDate_Xpath = ".//*[@class='datepicker-days']//tr/td";
        public string DetailsTab_Edit_Shipper_CycleTime_Id = "CycleTime";


        //Comments Section
        public string DetailsTab_CommentsSection_Text_Xpath = ".//*[@id='page-content-wrapper']//*[text()='Comments (5,000 chars max)']";
        public string DetailsTab_CommentsSection_Edit_id = "Comments";
        public string DetailsTab_ExportButton_id = "btnExport";
        public string DetailsTab_ClaimFormButton_id = "btnClaimForm";
        public string DetailsTab_SaveClaimDetails_Button_id = "btnSaveClaimDetails";
        public string DifferentTypeReportExportButton_id = "btnExortInsuranceClaimDetails";
        public string DifferentTypeReportExportOptions_Xpath = "//ul[@id='export-list-profile']/li";
        public string PaymentTabReportExportButton_Xpath = "//ul[@id='export-list-profile']//li/a[text()='Payment Tab']";
        public string HistoryTabReportExportButton_Xpath = "//ul[@id='export-list-profile']//li/a[text()='History Tab']";
        public string ClaimSubmittedByCustomerTabReportExportButton_Xpath = "//ul[@id='export-list-profile']//li/a[text()='Claim Submitted by Customer']";
        //public string ClaimAmendedByCustomerTabReportExportButton_Xpath = "//ul[@id='export-list-profile']//li/a[text()='Claim Amended By Customer']";
        //Claim Packet - Select Documents for Export Modal
        public string ClaimPacketFromExportButton_Xpath = "//ul[@id='export-list-profile']//li/a[contains (text(),'Claim Packet')]";
        public string SelectDocumentsForExportModalHeader_Xpath = ".//h3[text() = 'Select Documents for Export']";
        public string FirstDocumenttype_Xpath = "(.//div[@id = 'divClaimPacket']//label[@class = 'container'])[1]";
        public string FirstDocumentwithExtension_Xpath = "(.//div[@id = 'divClaimPacket']//label[@class = 'claim-pkt-label'])[1]";
        public string DocumentsList_Xpath = ".//div[@id = 'divClaimPacket']//label[@class = 'container']";
        public string DocumentswithExtensionList_Xpath = ".//div[@id = 'divClaimPacket']//label[@class = 'claim-pkt-label']";
        public string Note_SelectDocumentsForExportModal_Xpath = ".//b[contains(text(), 'Note: Claim form PDF will be automatically included')]";
        public string CancelButton_SelectDocumentsForExportModal_Id = "btnClaimPacketCancel";
        public string DownloadButton_SelectDocumentsForExportModal_Id = "btnClaimPacketDownload";
        public string FirstCheckBox_Xpath = "(.//div[@id = 'btnClaimPacketModal']//span)[1]";
        public string AllCheckBoxes_Xpath = ".//div[@id = 'btnClaimPacketModal']//span";
        public string FirstCheckBoxInputField_Xpath = "(.//input[@class = 'chkdocuments'])[1]";
        public string AllCheckBoxesInputField_Xpath = ".//input[@class = 'chkdocuments']";
        public string SelectDocumentsForExportModalOverlay_Xpath = ".//div[@id = 'btnClaimPacketModal']";


        public string DetailsTab_Edit_Shipper_Program_Click_Xpath = ".//*[@id='InsuranceClaimProgramName_chosen']//span";
        public string DetailsTab_Edit_Shipper_Program_ListAll_Xpath = ".//*[@id='InsuranceClaimProgramName_chosen']//ul/li";
        public string DetailsTab_Edit_Shipper_Amount_Id = "Amount";
        public string DetailsTab_Edit_Shipper_Company_Click_Xpath = ".//*[@id='InsuranceClaimCompanyName_chosen']//span";
        public string DetailsTab_Edit_Shipper_Company_ListAll_Xpath = ".//*[@id='InsuranceClaimCompanyName_chosen']//ul/li";

        public string SubmitaClaim_StationDropDownLable_xpath = ".//*[@id='page-content-wrapper']//div[5]/div[1]/div/label";
        public string SubmitaClaim_CustomerDropDownLable_xpath = ".//*[@id='page-content-wrapper']//div[5]/div[2]//label";
        public string SubmitaClaim_StationName_id = "StationName";
        public string SubmitaClaim_CustomerName_id = "CustomerNames";

        public string SubmitaClaim_Stationdropdown_xpath = ".//*[@id='StationName_chosen']/a/span";
        public string SubmitaClaim_Customerdropdown_xpath = ".//*[@id='CustomerNames_chosen']/a/span";
        public string SubmitaClaim_StatiodropdownValues_xpath = ".//*[@id='StationName_chosen']/div/ul/li";
        public string SubmitaClaim_CustomerdropdownValues_xpath = ".//*[@id='CustomerNames_chosen']/div/ul/li";

        public string SubmitaClaim_Stationdropdownsearch_xpath = ".//*[@id='StationName_chosen']//input";
        public string SubmitaClaim_Customerdropdownsearch_xpath = ".//*[@id='CustomerNames_chosen']//input";

        public string SubmitaClaim_StationdropdownInternal_id = "StationName_chosen";
        public string SubmitaClaim_StationdropdownInternalValues_xpath = ".//select[@id =  'StationName']/option";

        public string SubmitaClaim_popup_errorText_id = "submitClaimErrorText";
        public string SubmitaClaim_popup_pageHeader_id = "submit-claim-changed-status-Alert";
        public string SubmitaClaim_popup_closeButton_id = "close-button-alert-popup";
        //----------------------------Payment Tab---------------------------------------//
        public string CustomerDetails_PaymentTab_Xpath = ".//*[@id='tabClaimDetailPayments']/a";
        public string ClaimDetails_PaymentTab_Xpath = ".//*[@id='tabClaimDetailPayments']/a";
        public string PaymentType_Xpath = ".//*[@id='PaymentGrid']//*[text()='Payment Type']";
        public string PaymentDate_Xpath = ".//*[@id='PaymentGrid']//*[text()='Payment Date']";
        public string Comment_Xpath = ".//*[@id='PaymentGrid']//*[text()='Comment']";
        public string FirstCommentValue_Xpath = ".//*[@id='PaymentGrid']/tbody/tr[1]/td[3]";
        public string CheckNumber_Xpath = ".//*[@id='PaymentGrid']//*[text()='Check Number']";
        public string CheckDate_Xpath = ".//*[@id='PaymentGrid']//*[text()='Check Date']";
        public string PaymentAmount_Xpath = ".//*[@id='PaymentGrid']//*[text()='Payment Amount']";
        public string OutstandingAmount_Id = "OutstandingAmount";
        public string OustandingAmountLabel_Xpath = "//div[@class='col-md-12 payment-div']//div//label[@class='control-label']";
        public string AddPaymentButton_Id = "addPayment";
        public string PaymentAmountValue_Xpath = ".//*[@id='PaymentGrid']/tbody/tr[1]/td[6]";
        public string PaymentDateValue_Xpath = ".//*[@id='PaymentGrid']/tbody/tr[1]/td[2]";
        public string CheckDateValue_Xpath = ".//*[@id='PaymentGrid']/tbody/tr[1]/td[5]";
        public string OutstandingAmountLabel_Xpath = "//div[@class='col-md-12 payment-div']//div//label[@class='control-label']";
        public string PaymentModalTitle_Xpath = "//H3[@class='modal-title'][text()=' Add Payment']";
        public string PaymentTypeDropdown_Xpath = ".//*[@id='PaymentType_chosen']/a";
        public string PaymentTypeDropdown_Label_Xpath = ".//*[@id='AddPaymentModel']//div[1]/div/div/div/label";
        public string PaymentAmountModal_Xpath = ".//*[@id='PaymentAmount']";
        public string PaymentAmountModal_Id = "PaymentAmount";
        public string PaymentDateUI_Xpath = "html/body/div[10]/div[1]/table/tbody/tr/td";
        public string PaymentDateMonth_Xpath = "html/body/div[10]/div[1]/table/thead/tr[2]/th[1]";
        public string PaymentAmountModal_Label_Xpath = ".//*[@id='AddPaymentModel']//div[2]/div[1]/div/div/label";
        public string PaymentDateModal_Xpath = "//INPUT[@id='PaymentDate']";
        public string PaymentDateSelectModal_Xpath = "//td[@class='today active day']";
        public string PaymentDateModal_Lebel_Id = "PaymentDate";
        public string PaymentDate_DatePicker_SelectDate_Xpath = "html/body/div[10]/div[1]/table/tbody/tr[1]/td[1]";
        public string PaymentDate_DatePicker_FutureDisabledDate_Xpath = "html/body/div[10]/div[1]/table/tbody/tr[6]/td[6]";
        public string CheckDate_DatePicker_FutureDisabledDate_Xpath = "html/body/div[10]/div[1]/table/tbody/tr[6]/td[6]";
        public string PaymentDateModal_Label_Xpath = ".//*[@id='AddPaymentModel']//div[2]/div[2]/div/div/label";
        public string CheckNumberModal_Xpath = "//INPUT[@id='CheckNumber']";
        public string CheckNumModal_Label_Xpath = ".//*[@id='AddPaymentModel']//div[3]/div[1]/div/div/label";
        public string CheckDateModal_Xpath = "//INPUT[@id='CheckDate']";
        public string CheckDateModal_Lebel_Id = "CheckDate";
        public string CheckDateSelect_Xpath = "//td[@class='today day']";
        public string CheckDate_DatePicker_Selectdate_Xpath = "html/body/div[10]/div[1]/table/tbody/tr[1]/td[1]";
        public string CheckDateModal_Label_Xpath = ".//*[@id='AddPaymentModel']//div[3]/div[2]/div/div/label";
        public string PaymentCommentModal_Xpath = "//INPUT[@id='PaymentComments']";
        public string PaymentCommentModal_Label_Xpath = ".//*[@id='AddPaymentModel']//div[4]//div/div/label";
        public string PaymentModalCancelButton_Xpath = "//A[@class='btn closeOverlay modal-cancel'][text()='Cancel']";
        public string AddNewPaymentButtonModal_Xpath = "//A[@id='AddNewPayment']";
        public string PaymentTypeDropdownValues_Xpath = ".//*[@id='PaymentType_chosen']/div/ul/li";
        public string PaymentTypeList_Xpath = ".//*[@id='PaymentGrid']//tr/td[1]";
        public string PayemntModalErrorMessage = ".//*[@id='error-msg']";
        public string PaymentTableRow_Xpath = ".//*[@id='PaymentGrid']/tbody/tr";


        public string ClaimIconExternalUser_Xpath = "//i[@class='icon icon-claims']";
        public string SubmitClaimButton_Xpath = "//button[@id='submitClaim']";

        public string ClaimlistGridFilterbySubmittedCheckbox_Xpath = "//*[@for= 'FilterByStatusSubmitted']";
        public string ClaimsList_AmendCheckbox_xpath = ".//*[@id='gridInsuranceClaimList_wrapper']//div[1]/label[@for='FilterByStatusAmend']";
        public string sortarrowSubmitDate_Claimlistpage_Xpath = ".//*[@id='gridInsuranceClaimList']//*[@class = 'double-line-header SubmitClaimDateSort sorting_asc']";
        public string sortarrowDate_Claimlistpage_Xpath = ".//*[@id='gridInsuranceClaimList']//*[@class ='SubmitClaimDateSort sorting_asc']";
        public string ClaimList_Submittedstatus_xpath = "//*[@id='gridInsuranceClaimList']/tbody/tr/td[10]/span";
        public string Claimlist_NoResult_xpath = "//td[@class='dataTables_empty']";
        public string ClaimDetails_DropDown_Xpath = "//*[@id='CarrierMode_chosen']/a/span";
        public string ClaimDetails_AmendDropDown_Xpath = "//*[@id='CarrierMode_chosen']/div/ul/li[2]";
        public string ClaimDetails_Username_Xpath = ".//*[@id='loggedInUserName']/b";
        public string ClaimDetails_SignoutList_Xpath = ".//*[@id='dv-loginmenu']/ul/li/ul/li";
        public string ClaimDetails_AmendEdit_Xpath = "//*[@class='amend-claim-icon']";
        public string ClaimDetails_BackbuttonErrorMsg_Xpath = "//*[@class='body-inner']/p[contains(text(),'leave')]";
        public string ClaimDetails_ErrorMsgYesButton_Xpath = "//*[@id='btnLeaveFromPage']";
        public string ClaimDetails_ErrorMsgNoButton_Xpath = "//*[@id='btnStayOnPage']";
        public string ClaimNumber_FirstAmend_Xpath = ".//tr[1]//*[@class='dlsw-claim-number']";
        public string AmendClaim_ArticlesIns_YES_Xpath = ".//input[@id='btn-articlesallriskYes']";
        public string AmendClaim_ArticlesIns_NO_Xpath = ".//input[@id='btn-articlesallriskNo']";
        public string AmendClaim_InsuredValue_Xpath = ".//input[@id='InsuredValueAmount']";
        public string AmendClaim_FreightCharges_YES_Xpath = ".//input[@id = 'btn-freightchargesYes']";
        public string AmendClaim_FreightCharges_NO_Xpath = ".//input[@id = 'btn-freightchargesNo']";
        public string AmendClaim_OriginalFreightChargesOption_Xpath = ".//input[@id='btn-OriginalFreightchargesOriginalFreightCharges']";
        public string AmendClaim_ReturnFreightChargesOption_Xpath = ".//input[@id='btn-returnFreightchargesReturnFreightCharges']";
        public string AmendClaim_ReturnFreightChargesValue_Xpath = ".//input[@class='returnFreightChargesValue validateFreightInput']";
        public string AmendClaim_ReturnFreightChargesDLSW_Xpath = ".//input[@class='returndlswValue validateFreightInput']";
        public string AmendClaim_ReplacementFreightChargesOption_Xpath = ".//input[@id='btn-replacementFreightchargesReplacementFreightCharges']";
        public string AmendClaim_ReplacementFreightChargesValues_Xpath = ".//input[@class='replaceFreightChargesValue validateFreightInput']";
        public string AmendClaim_ReplacementFreightChargesDLSW_Xpath = ".//input[@id='dlswreplacementbol']";
        public string AmendClaim_SubTotalAllClaimValue_Xpath = ".//input[@id='SubtotalAllClaimValue']";

        public string AmendClaim_DeleteSavedDocumentAllButtons_Xpath = ".//a[contains(@class, 'deleteSavedDocument')]";
        public string AmendClaim_CompleteVendorInvoiceText_Xpath = ".//p[contains(text(),'Complete Vendor Invoice')]";
        public string AmendClaim_DocumentUploadValidationMessagesAll_Xpath = ".//span[contains(text(),'Please add document to claim form')]";
        public string AmendClaim_DeleteDocIcon_Xpath = ".//h3[contains(text(),'Delete File')]";
        public string AmendClaim_DeleteModal_Cancel_Id = "delete-document-cancel";
        public string AmendClaim_DeleteModal_Delete_Id = "delete-document-yes";
        public string AmendClaim_DocumentLink_Xpath = ".//a[@class='documentLinkPreview']";
        public string AmendClaim_DocumentUpload_Xpath = ".//button[contains(@class,'btn-document-upload')]";
        public string AmendClaim_DocumentName_Xpath = ".//p[@class='documentheadingpadding documentTypeTitle']";
        public string AmendClaim_UploadDocumentIcon_Xpath = ".//span[contains(text(),'No file currently uploaded')]";
    }

}

