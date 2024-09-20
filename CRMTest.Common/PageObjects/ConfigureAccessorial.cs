namespace CRMTest.Common.PageObjects
{
    public class ConfigureAccessorial : MaintenaceTools
    {
        public string maintenanceToolsPage_Xpath = "//h1[text()='Maintenance Tools']";
        public string nameColumnAccessorialGrid_Xpath = ".//*[@id='Grid_ConfigureAccessorial']/tbody/tr/td[1]";
        public string serviceCodeAccessorialGrid_Xpath = ".//*[@id='Grid_ConfigureAccessorial']/tbody/tr/td[2]";
        public string directioneAccessorialGrid_Xpath = ".//*[@id='Grid_ConfigureAccessorial']/tbody/tr/td[5]";

        public string accessorialGridValue_Xpath = ".//*[@id='Grid_ConfigureAccessorial']/tbody/tr/td[1]";
        public string configureAccessorialsTopGridDefaultView_Xpath = "//div[@id='Grid_ConfigureAccessorial_length']//select";
        public string configureAccessorialsTopGridDropDownValues_Xpath = "//div[@id='Grid_ConfigureAccessorial_length']//select/option";
        public string configureAccessorialsBottonGridDefaultView_Xpath = "//div[@class='table-footer-row']//select";
        public string configureAccessorialsBottomGridDropDownValues_Xpath = "//div[@class='table-footer-row']//select/option";
        public string configureAccessorialsGridRecords_Xpath = "//table[@id='Grid_ConfigureAccessorial']//tbody/tr";

        ////-----------------------------------------------------  Cofigure Accessorials Delete Modal---------------------------

        public string deleteModalTitle_Xpath = "//h3[text()='Delete Accessorial']";
        public string deleteModalDisplayedAccessorialName_Xpath = "//div[@id='modelDeleteAccessorial']//div/p";
        public string deleteModalDisplayedVerbiageName_Xpath = "//div[@id='modelDeleteAccessorial']//div/p[3]";
        public string deleteModalCancelButton_Xpath = "//div[@id='modelDeleteAccessorial']//a[text()='Cancel']";
        public string deleteModalDeleteButton_Id = "btnModelDeleteAccessorial";


        public string configureAccessorialsButton_Id = "btnCofigureAccessorials";
        public string configureAccessorialsButtonverbiage_Xpath = "//p[text()='Add, edit or remove accessorials']";
        public string configureAccessorialsPageHeader_Xpath = "//h1[text()='Configure Accessorials']";
        public string configureAccessorialsPageHeaderSubTitle_Xpath = "//p[text()='Add, edit or remove accessorials']";
        public string configureAccessorialsPageBackToMaintenanceToolsButton_Id = "backto-maintenance";
        public string configureAccessorialsPageAddAccessorialButton_Id = "btnAddAccessorial";
        public string configureAccessorialsSearchTexBox_Xpath = " //input[@placeholder='Filter accessorials...']";
        public string configureAccessorialsGridNameColumn_Xpath = "//div[@id='Grid_ConfigureAccessorial_wrapper']//table//th[text()='Name']";
        public string configureAccessorialsGridServiceCodeColumn_Xpath = "//div[@id='Grid_ConfigureAccessorial_wrapper']//table//th[text()='Service Code']";
        public string configureAccessorialsGridMGDescriptionColumn_Xpath = "//div[@id='Grid_ConfigureAccessorial_wrapper']//table//th[text()='MG Description(s)']";
        public string configureAccessorialsGridServiceTypeColumn_Xpath = "//div[@id='Grid_ConfigureAccessorial_wrapper']//table//th[text()='Service Type(s)']";
        public string configureAccessorialsGridDirectionColumn_Xpath = "//div[@id='Grid_ConfigureAccessorial_wrapper']//table//th[text()='Direction']";
        public string configureAccessorialsGridNextDirectionArrow_Id = "Grid_ConfigureAccessorial_next";
        public string configureAccessorialsGridPreviousDirectionArrow_Id = "Grid_ConfigureAccessorial_previous";
        public string configureAccessorialsGridViewOption_Id = "Grid_ConfigureAccessorial_length";
        public string configureAccessorialsGridShowingInfo_Id = "Grid_ConfigureAccessorial_info";

        public string firstNameGridValue_Xpath = ".//*[@id='Grid_ConfigureAccessorial']/tbody/tr[1]/td[1]";
        public string firstServiceCodeValue_Xpath = ".//*[@id='Grid_ConfigureAccessorial']/tbody/tr[1]/td[2]";
        public string firstMGDescriptionGridValue_Xpath = ".//*[@id='Grid_ConfigureAccessorial']/tbody/tr[1]/td[3]";
        public string firstServiceTypeGridValue_Xpath = ".//*[@id='Grid_ConfigureAccessorial']/tbody/tr[1]/td[4]";
        public string firstDirectionGridValue_Xpath = ".//*[@id='Grid_ConfigureAccessorial']/tbody/tr[1]/td[5]";

        public string addAccessorialbutton_Id = "btnAddAccessorial";
        public string addAccesorialModal_Xpath = "//h3[text()='Add Accessorial']";
        public string editAccesorialModal_Xpath = "//h3[text()='Edit Accessorial']";
        public string nameLabel_Accessorial_Xpath = ".//*[@id='accessorial-popup-div']//label[text()='Name']";
        public string nameTextbox_Accessorial_Id = "Name";
        public string serviceCodeLabel_Accessorial_Xpath = ".//*[@id='accessorial-popup-div']//label[text()='Service Code']";
        public string serviceCodeTextbox_Accessorial_Id = "ServiceCode";

        public string firstMGDescriptionLabel_Accessorial_Xpath = "//div[@class='col-md-12 requiredlabel']//label[@class='control-label defaulttransorm']";
        public string firstMGDescriptionTextbox_Accessorial_Xpath = "//div[@class='col-md-12 requiredlabel']//div[@class='form-group']//div//input[@id='MGDescription']";

        public string addAdditionalMgDescriptionLink_Id = "btn-AddAdditionalDescription";



        public string secondMGDescriptionlabel_Accessorial_Xpath = "//div[@class='mg-description-group']//div[@class='col-md-8 requiredlabel']//label[@class='control-label defaulttransorm']";
        public string secondMGDescriptionTextbox_Accessorial_Xpath = "//div[@class='mg-description-group']//div[@class='col-md-8 requiredlabel']//div//input[@id='MGDescription']";
        public string secondAccessorialRemovebutton_Xpath = "//div[@class='mg-description-group']//div[2]//div[@class='col-md-4']//a[@class='btn btn-color remove-btn'][contains(text(),'Remove')]";

        public string serviceTypesLabel_Accessorial_Xpath = ".//*[@id='accessorial-popup-div']//label[text()='Service  Types']";
        public string serviceTypedropdown_Accessorial_Xpath = ".//*[@id='ServiceTypes_chosen']/ul/li";
        //public string applyAccessorialsToLabel_Xpath = "//h6[text()='APPLY ACCESSORIAL TO *']";
        public string applyAccessorialsToLabel_Xpath = "//h6[text()='Apply Accessorial To *']";
        public string shipToRadiobutton_Xpath = ".//*[@id='accessorial-popup-div']//label[text()='Ship To']";
        public string shipFromRadiobutton_Xpath = ".//*[@id='accessorial-popup-div']//label[text()='Ship From']";
        public string bothRadiobutton_Xpath = ".//*[@id='accessorial-popup-div']//label[text()='Both']";
        public string noneFromRadiobutton_Xpath = ".//*[@id='accessorial-popup-div']//label[text()='None']";

        public string cancelbutton_Accessrial_Xpath = ".//*[@id='accessorial-popup-div']//a[1][text()='Cancel']";
        public string savebutton_Accessorial_Id = "AddAccessorial";

    }
}
