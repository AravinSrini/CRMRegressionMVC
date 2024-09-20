using Rrd.SpecflowSelenium.Service.GenericService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Objects
{
    public class Integration : ObjectRepository
    {
        public string IntegrationRequestButton_Id = "btnSubmitIntegrationRequest";
        public string SubmitIntegrationRequestPage_Header_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[1]/div[1]/h1";
        public string IntegrationIconLink_Dashboard_id = "integrationrequest";
        public string IntegrationMenuIcon = ".//*[@id='integrationrequest']/i";
        public string IntegrationListPageTitle_xpath = ".//*[@id='page-content-wrapper']/div[2]/div[2]/div[1]/div/h1";
        public string CustomerIntegrationText = ".//*[@id='integrationrequest']/span";
        public string IntegrationExportButton = "btnExortIntegrationRequest";
        public string IntegrationPendingApproval_RadioButton = ".//*[@id='gridIntegrationList_wrapper']/div[2]/div[2]/div/div/div[2]/label";
        public string IntegrationExpanbutton = ".//*[@id='gridIntegrationList']/tbody/tr[1]/td[6]/button";
        public string IntegrationApprovebutton = "btnApprove";
        public string IntegrationDenybutton = "btnDeny";
        public string IntegrationCompanyContactName = "CompanyContactName";
        public string IntegrationStationName = ".//*[@id='gridIntegrationList']/tbody/tr[1]/td[1]";
        public string IntegrationCompanyContactEmail = "CompanyContactEmail";
        public string IntegrationCompanyContactPhone = "CompanyContactPhone";
        public string IntegrationItDeveloperContactName = "it/devcontactname";
        public string IntegrationItDeveloperContactEmail= "it/devcontactemail";
        public string IntegrationItDeveloperContactPhone = "it/devcontactphone";
        public string IntegrationCompanyName = ".//*[@id='gridIntegrationList']/tbody/tr[1]/td[2]";
        public string IntegrationYearToDateShipments = "YearToDateShipments";
        public string IntegrationYearToDateRevenue = "YearToDateRevenue";
        public string IntegrationPotentialRevenue = "PotentialRevenue";
        public string IntegrationAdditionalComments = "AdditionalComments";
        public string IntegrationStatus = ".//*[@id='gridIntegrationList_wrapper']/div[2]/div[2]/div/div/div[3]/label";
        public string IntegrationTypeOfIntegration = ".//*[@id='TypeofIntegration_chosen']/ul/li";
        public string IntegrationList_InProgress_RadioButton_xpath = ".//*[@id='gridIntegrationList_wrapper']/div[2]/div[2]/div/div/div[3]/label";
        public string IntegrationMGandCSAHour = "MG/CSATotalHours";
        public string IntegrationTeamTotalHours = "IntegrationTeamTotalHours";
        public string ApproveInProgressWaitingOnIntegrationTeam = ".//*[@id='2']/td[3]/span[2]";
            //".//*[@id='gridIntegrationList']/tbody/tr[2]/td/div/div[1]/div/div[1]/div/ul/li[3]/a/span[2]/label";
        public string DeniedStatus = ".//*[@id='gridIntegrationList']/tbody/tr[2]/td/div/div[1]/div/div[1]/div/ul/li[4]/a/span[2]/label";
        public string SearchIntegration = ".//*[@id='gridIntegrationList_wrapper']/div[1]/div[2]/div/input";
        public string IntegrationInprogressStatus = ".//*[@id='gridIntegrationList']/tbody/tr[2]/td/div/div[1]/div/div[1]/div/ul/li[3]/a/span/label";
        public string approveAftreCompleted = ".//*[@id='1']/td[1]";
        public string stationNameInTheGrid = ".//*[@id='gridIntegrationList']/tbody/tr[1]/td[1]";
        public string IntegrationDeniedStatus = ".//*[@id='gridIntegrationList']/tbody/tr[2]/td/div/div[1]/div/div[1]/div/ul/li[4]/a/span[2]/label";
        public string IntegrationList_complete_RadioButton_xpath = ".//*[@id='gridIntegrationList_wrapper']/div[2]/div[2]/div/div/div[4]/label";
        public string FirstStationName_Xpath = ".//*[@id='gridIntegrationList']/tbody/tr[1]/td[1]";
        public string FisrtCompanyName_Xpath = ".//*[@id='gridIntegrationList']/tbody/tr[1]/td[2]";

        //----------------------Submit Integration Request page -------------------------------------------------
        public string IntegrationRequestPageTitle_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[1]/div[1]/h1";
        public string IntegrationStationLabel_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[2]/div[1]/label";
        public string IntegrationStaionDropdown_Id = "StationName_chosen";
        public string IntegrationStationDropdownValues_Xpath = ".//*[@id='StationName_chosen']/div/ul/li";
        public string IntegrationCompanyNameLabel_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[2]/div[2]/label";
        public string IntegrationCompanyName_Textbox_Id = "CompanyName";
        public string IntegrationCompanyContactNameLabel_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div[1]/label";
        public string IntegrationCompanyContactName_Textbox_Id = "companyContactName";
        public string IntegrationCompanyContactPhoneLabel_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div[2]/label";
        public string IntegrationCompanyContactPhone_Textbox_Id = "companyContactPhone";
        public string IntegrationCompanyContactEmailLabel_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div[3]/label";
        public string IntegrationCompanyContactEmail_Textbox_Id = "companyContactEmail";
        public string IntegrationDevContactNameLabel_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[4]/div[1]/label";
        public string IntegrationDevContactName_Textbox_Id = "ITContactName";
        public string IntegrationDevContactPhoneLabel_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[4]/div[2]/label";
        public string IntegrationDevContactPhone_Textbox_Id = "ITContactPhone";
        public string IntegrationDevContactEmailLabel_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[4]/div[3]/label";
        public string IntegrationDevContactEmail_Textbox_Id = "ITContactEmail";
        public string IntegrationStartDateLabel_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[5]/div[1]/label";
        public string IntegrationStartDatePicker_Id = "startDate";
        public string IntegrationDateSelection_Xpath = "html/body/div[8]/div[1]/table/tbody/tr/td";
        public string IntegrationDateMonth_Xpath = "html/body/div[8]/div[1]/table/thead/tr[2]/th[3]";
        public string IntegrationTypeOfIntegrationLabel_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[5]/div[2]/label";
        public string IntegrationTypeOfIntegration_MultiSelectBox_Id = "IntegrationType_chosen";
        public string IntegrationTypeOfIntegration_DropdownValues_Xpath = ".//*[@id='IntegrationType_chosen']/div/ul/li";
        public string IntegrationYearToDateShipLabel_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[6]/div[1]/label";
        public string IntegrationYearToDateShip_Textbox_Id = "YTDShipments";
        public string IntegrationYearToDateRevenueLabel_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[6]/div[2]/label";
        public string IntegrationYearToDateRevenue_Textbox_Id = "YTDRevenue";
        public string IntegrationPotentialValLabel_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[6]/div[3]/label";
        public string IntegrationPotentialVal_Textbox_Id = "potentialRevenue";
        public string IntegrationAdditionalCommentsLabel_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div/div[7]/div/label";
        public string IntegrationAdditionalComments_Textbox_Id = "additionalComment:";
        public string IntegrationSubmitButton_Id = "btnSubmitIntegration";
        public string BackToIntegrationListPageButton_Id = "Btn_BackIntegrateList";
        public string IntegratioListPageTitle_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div[2]/div[1]/div/h1";
        public string IntegrationListHeader_Xpath = ".//*[@id='page-content-wrapper']/div[2]/div[1]/div[1]/div/h1";

        public string FirstrequestexpandIcon_xpath = ".//*[@id='gridIntegrationList']/tbody/tr[1]/td[6]/button[@class='btn exandableTrigger image-only-sm']";
        public string statusbar_xpath = ".//*[@id='gridIntegrationList']/tbody/tr[2]/td/div/div[1]";
        public string pendingRmapprovalstatusbar_xpath = ".//*[@id='gridIntegrationList']//li[2]/a";
        public string Inprogressstatusbar_xpath = ".//*[@id='gridIntegrationList']//li[3]";
        public string Completedstatusbar_xpath = ".//*[@id='gridIntegrationList']//li[4]";
        public string pendingRmapprovalstatusbar_label_xpath = ".//*[@id='gridIntegrationList']/tbody//li[2]//label";
        public string Inprogressstatusbar_label_xpath = ".//*[@id='gridIntegrationList']//li[3]//label";
        public string Completedstatusbar_label_xpath = ".//*[@id='gridIntegrationList']//li[4]//label";
        public string CompanyContactNameTextbox_id = "CompanyContactName";
        public string CompanyContactNamelabel_xpath = ".//*[@id='gridIntegrationList']/tbody/tr[2]/td/div/div[2]/div/div[1]/div[1]/div/label";
        public string CompanyContactPhoneTextbox_id = "CompanyContactPhone";
        public string CompanyContactPhonelabel_xpath = ".//*[@class='form-group required']/label[contains(text(),'Company Contact Phone')]";
        public string CompanyContactEmailTextbox_id = "CompanyContactEmail";
        public string CompanyContactEmaillabel_xpath = ".//*[@class='form-group required']/label[contains(text(),'Company Contact Email')]";
        public string IT_developercontactnametextbox_id = "it/devcontactname";
        public string IT_developercontactnamelabel_xpath = ".//*[@class='form-group required']/label[contains(text(),'it/dev contact name')]";
        public string ITdeveloperContactphonetextbox_id = "it/devcontactphone";
        public string ITdeveloperContactphone_xpath = ".//*[@class='form-group required']/label[contains(text(),'it/dev contact phone')]";
        public string ITdeveloperemailtextbox_id = "it/devcontactemail";
        public string ITdeveloperemaillabel = ".//*[@class='form-group required']/label[contains(text(),'it/dev contact email')]";
        public string TypeofIntegrationdropdown_xpath = ".//*[@id='TypeofIntegration_chosen']/ul/li";
        public string TypeofIntegrationlabel_xpath = ".//*[@class='form-group required']/label[contains(text(),'Type of  Integration')]";
        public string YeartoDateshipmentstextbox_id = "YearToDateShipments";
        public string YeartoDateshipmentslabel_xpath = ".//*[@class='form-group']/label[contains(text(),'Year To Date Shipments')]";
        public string YeartoDateRevenuetextbox_id = "YearToDateRevenue";
        public string YeartoDateRevenuelabel_xpath = ".//*[@class='form-group']/label[contains(text(),'Year To Date Revenue')]";
        public string PotentialRevenuetextbox_id = "PotentialRevenue";
        public string PotentialRevenuelabel_xpath = ".//*[@class='form-group required']/label[contains(text(),'Potential Revenue')]";
        public string AdditionalCommentstextbox_id = "AdditionalComments";
        public string AdditionalCommentslabel_xpath = ".//*[@id='gridIntegrationList']/tbody/tr[2]/td/div/div[2]/div/div[3]/div[2]/div/label";
        public string MG_CSATotalHourstextbox_id= "MG/CSATotalHours";
        public string MG_CSATotalHourslabel_xpath= ".//*[@class='form-group required']/label[contains(text(),'mg/csa total hours')]";
        public string IntegrationTeamTotalHourstextbox_id = "IntegrationTeamTotalHours";
        public string IntegrationTeamTotalHourslabel_xpath = ".//*[@class='form-group required']/label[contains(text(),'Integration Team Total Hours')]";
        public string IntegrationTeamStatusdropdown_xpath = ".//*[@id='IntegrationStatus_chosen']/a";
        public string IntegrationTeamStatuslabel_xpath = ".//*[@class='form-group required']/label[contains(text(),'Integration Status')]";
        public string Commentsheader_xpath = ".//*[@id='gridIntegrationList']/tbody/tr[2]/td/div/div[3]/div/table/thead/tr/th[1]/label";
        public string Commenterheader_xpath = ".//*[@id='gridIntegrationList']/tbody/tr[2]/td/div/div[3]/div/table/thead/tr/th[2]/label";
        public string Date_timeheader_xpath = ".//*[@id='gridIntegrationList']/tbody/tr[2]/td/div/div[3]/div/table/thead/tr/th[3]/label";
        public string Public_privateheader_xpath = ".//*[@id='gridIntegrationList']/tbody/tr[2]/td/div/div[3]/div/table/thead/tr/th[4]/label";
        public string Public_table_xpath = ".//*[@class='table dt-responsive table-striped dataTable'][@table id='tableTraking1']";
        public string publicorprivate_Xpath = ".//*[@class='table dt-responsive table-striped dataTable']/tbody//td[4]";
        public string Allcomments_Xpath = ".//*[@class='table dt-responsive table-striped dataTable']/tbody//td[1]";

        //--------------------------------------------Integration List page---------------------------------------------
        public string AddCommentButton_Id = "btnAddComment";
        public string StatusCommentModal_Xpath = "";
        public string StatueModal_HeaderNameLabel_Xpath = ".//*[@id='popUpStatusComment']//div[1]/h3";
        public string StatusModal_StatusLabel_Xpath = ".//*[@id='popUpStatusComment']//div[1]/label";
        public string StatusModal_StatusValue_Xpath = ".//*[@id='popUpStatusComment']//div[1]/label/span";
        public string StatusModal_CommentsLabel_Xpath = ".//*[@id='popUpStatusComment']//div[2]/div/label";
        public string StatusModal_CommentsTextBox_Id = "Comment";
        public string StatusModal_PublicLabel_Xpath = "";
        public string StatusModal_PublicRadioButton_Xpath = ".//*[@id='Private']/label[2]";
        public string StatusModal_PrivateLabel_Xpath = "";
        public string StatusModal_PrivateRadioButton_Xpath = ".//*[@id='Private']/label[1]";
        public string StatusModal_CancelButton_Xpath = ".//*[@id='popUpStatusComment']//div[3]/button[1]";
        public string StatusModal_SubmitButton_Xpath = ".//*[@id='popUpStatusComment']//div[3]/button[2]";
        public string CommentView_Xpath = ".//*[@id='gridIntegrationList']/tbody/tr[2]/td/div/div[3]/div/table/tbody/tr/td[1]";
        public string CommenterView_Xpath = ".//*[@id='gridIntegrationList']/tbody/tr[2]/td/div/div[3]/div/table/tbody/tr/td[2]";
        public string DateTimeView_Xpath = ".//*[@id='gridIntegrationList']/tbody/tr[2]/td/div/div[3]/div/table/tbody/tr/td[3]";
        public string PrivatePublicView_Xpath = ".//*[@id='gridIntegrationList']/tbody/tr[2]/td/div/div[3]/div/table/tbody/tr/td[4]";
        public string StatusbarValueInprogress_Xpath = ".//*[@id='gridIntegrationList']/tbody/tr[2]//ul/li[3]/a/span/label";
        //-------------------------Integration List Page

        public string IntegrationList_SubmitIntegrationRequest_Button_Id = "btnSubmitIntegrationRequest";
        public string IntegrationList_Export_Button_Id = "btnExortIntegrationRequest";
        public string IntegrationList_Filter_All_RadioButton_xpath = ".//*[@id='gridIntegrationList_wrapper']//label[@for='FilterByStatusAll']";
        public string IntegrationList_Filter_PendingApproval_RadioButton_xpath = ".//*[@id='gridIntegrationList_wrapper']//label[@for='FilterByStatusPendingApproval']";

        public string IntegrationList_Filter_InProgress_RadioButton_xpath = ".//*[@id='gridIntegrationList_wrapper']//label[@for='FilterByStatusInProgress']";
        public string IntegrationList_Filter_Completed_RadioButton_xpath = ".//*[@id='gridIntegrationList_wrapper']//label[@for='FilterByStatusCompleted']";

        public string IntegrationList_SearchTextBox_xpath = ".//*[@id='gridIntegrationList_wrapper']/div[1]/div[2]/div/input";

        public string IntegrationList_TopGrid_DisplayListViewDropdown_Xpath = ".//*[@id='gridIntegrationList_length']/label/select";
        public string IntegrationList_TopGrid_DisplayListDropdownOptions_Xpath = ".//*[@id='gridIntegrationList_length']/label/select/option";

        public string IntegrationList_TopGrid_DisplayListView_Xpath = ".//*[@id='gridIntegrationList_info']";
        public string IntegrationList_TopGrid_ViewNextIcon_Xpath = ".//*[@id='gridIntegrationList_next']";
        public string IntegrationList_TopGrid_ViewPreviousIcon_Xpath = ".//*[@id='gridIntegrationList_previous']";

        public string IntegrationList_RowCount_xpath = ".//*[@id='gridIntegrationList']/tbody/tr[@role = 'row']";
        public string IntegrationList_StationCol_xpath = ".//*[@id='gridIntegrationList']/thead/tr/th[1]";
        public string IntegrationList_CompanyNameCol_xpath = ".//*[@id='gridIntegrationList']/thead/tr/th[2]";
        public string IntegrationList_CurrentStatusCol_xpath = ".//*[@id='gridIntegrationList']/thead/tr/th[3]";
        public string IntegrationList_SubmitDateCol_xpath = ".//*[@id='gridIntegrationList']/thead/tr/th[4]";
        public string IntegrationList_LastDateCol_xpath = ".//*[@id='gridIntegrationList']/thead/tr/th[5]";

        public string IntegrationList_StationNameClick_Xpath = ".//*[@id='gridIntegrationList']/thead/tr/th[1]";
        public string IntegrationList_StationNameAll_Values_Xpath = ".//*[@id='gridIntegrationList']/tbody/tr[@role = 'row']/td[1]";

        public string IntegrationList_CompanyNameClick_Xpath = ".//*[@id='gridIntegrationList']/thead/tr/th[2]";
        public string IntegrationList_CompanyNameAll_Values_Xpath = ".//*[@id='gridIntegrationList']/tbody/tr[@role = 'row']/td[2]";

        public string IntegrationList_CurrentStatusClick_Xpath = ".//*[@id='gridIntegrationList']/thead/tr/th[3]";
        public string IntegrationList_CurrentStatusAll_Values_Xpath = ".//*[@id='gridIntegrationList']/tbody/tr[@role = 'row']/td[3]/span[2]";

        public string IntegrationList_SubmitDateClick_Xpath = ".//*[@id='gridIntegrationList']/thead/tr/th[4]";
        public string IntegrationList_SubmitDateAll_Values_Xpath = ".//*[@id='gridIntegrationList']/tbody/tr[@role = 'row']/td[4]";

        public string IntegrationList_LastDateClick_Xpath = ".//*[@id='gridIntegrationList']/thead/tr/th[5]";
        public string IntegrationList_LastDateAll_Values_Xpath = ".//*[@id='gridIntegrationList']/tbody/tr[@role = 'row']/td[5]";

        public string IntegrationList_DetailIcon_xpath = ".//*[@id='gridIntegrationList']/tbody/tr[@role = 'row']/td[6]/button";
        public string IntegrationDetails_SubmitButton_Id = "btnSubmitUpdates";
        public string IntegrationDetails_AddCommentBtn_Id = "btnAddComment";
    }
}
