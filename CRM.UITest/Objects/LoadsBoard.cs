using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Objects
{
    public class LoadsBoard : ObjectRepository
    {
        public string rrdDLSLogo_xpath = "//span[@class='elevate-container']/img";
        public string availableLoadsTitle_xpath = "//div[@class='col-md-12']/h1";
        public string claimLoadsInformation_id = "subheading";
        public string refershText_xpath = "//div[@class='col-md-8']/span";
        public string refershButton_xpath = "//div[@class='col-md-8']/button";
        public string searchTextbox_xpath = "//input[@class='LoadAvailableSearch']";
        public string totalRecordsCount_id = "LoadBoardTable_info";
        public string topViewOption_Xpath = "//*[@id='LoadBoardTable_length']/label/select";
        public string topForwardOption_id = "LoadBoardTable_next";
        public string topBackwardOption_id = "LoadBoardTable_previous";
        public string totalRecords_xpath = "//tr/td";
        public string totalRowRecords_xpath = "//tr[@role='row']";

        //Table columns and values
        public string columnReference_xpath = "//th[text()='Ref #']";
        public string columnPickupRange_xpath = "//th[text()='PickUp Range']";
        public string columnDeliveryRange_xpath = "//th[text()='Delivery Range']";
        public string columnOrigin_xpath = "//th[text()='Origin']";
        public string columnDestination_xpath = "//th[text()='Destination']";
        public string columnofPU_xpath = "//th[text()='# Of P/U']";
        public string columnoDrops_xpath = "//th[text()='# Of Drops']";
        public string columnWEIGHT_xpath = "//th[text()='WEIGHT (lbs)']";
        public string columnEquipmentType_xpath = "//th[text()='Equip Type']";
        public string columnContactPhone_xpath = "//th[text()='Contact Phone']";

        //Table First Row grid Values
        public string columnReference_FirstValue_xpath = "//tr[1]/td[2]";
        public string columnPickupRange_FirstValue_xpath = "//tr[1]/td[3]";
        public string columnDeliveryRange_FirstValue_xpath = "//tr[1]/td[4]";
        public string columnOrigin_FirstValue_xpath = "//tr[1]/td[5]";
        public string columnDestination_FirstValue_xpath = "//tr[1]/td[6]";
        public string columnofPU_FirstValue_xpath = "//tr[1]/td[7]";
        public string columnoDrops_FirstValue_xpath = "//tr[1]/td[8]";
        public string columnWEIGHT_FirstValue_xpath = "//tr[1]/td[9]";
        public string columnEquipmentType_FirstValue_xpath = ".//*[@id='LoadBoardTable']//tr[1]/td[10]";
        public string columnEmailOption_FirstValue_xpath = "//tr[1]/td[12]";
        public string columnContactPhone_FirstValue_xpath = "//tr[1]/td[11]";

        //Table First Row email popup values
        public string firstRowEmail_Header_xpath = "//div[@class = 'modal-header']/h3";
        public string firstRowEmail_To_id = "ToEmail";
        public string firstRowEmail_From_id = "From:";
        public string firstRowEmail_Subject_id = "Subject:";
        public string firstRowEmail_Body_id = "Body:";
        public string firstRowEmail_SendButton_id = "email-sendbtn";
        public string firstRowEmail_Cancel_xpath = "//div[@class= 'modal-footer']/a[@class='closeOverlay btn emailpopup-close'] ";
        public string firstRowEmail_ErrorMessage_xpath = "//div[@class='modal-body']/p";

        //Table Column grid values
        public string refColumnValues_xpath = "//tr/td[2]";
        public string contactPhoneColumnValues_xpath = "//tr/td[11]";

        public string AvailableLoadsPageHeader_css = "h1";
    }
}
