namespace CRMTest.Common.PageObjects
{
    public class AddShipments2019 : AddShipments
    {
        public string PickUpDateCalender2019_Id = "PickupDate";
        public string PickUpDateCalendarPopUp2019_Xpath = "html/body/div[5]";
        public string PickUpDateCalendarPopUpForwardToggleArrow2019_Xpath = "html//div[1]//tr[2]/th[3]";
        public string PickUpDateCalendarPopUpBackwardToggleArrow2019_Xpath = "html//div[1]//thead[1]//tr[2]/th[1]";
        public string PickUpDateCalendarPopUpValue2019_Xpath = "html//table/tbody/tr/td";
        public string PickUpDate_ReadyTime2019_xpath = ".//*[@id='pickupreadytime_chosen']/a";
        public string PickUpDate_CloseTime2019_xpath = ".//*[@id='pickupclosetime_chosen']/a";
        public string PickupDateSection2019_Xpath = ".//h4[contains(text(), 'Pickup Date')]";
        public string PickupReadyTimeValue2019_Xpath = ".//*[@id='pickupreadytime_chosen']/a/span";
        public string PickupCloseTimeValue2019_Xpath = ".//*[@id='pickupclosetime_chosen']/a/span";
        public string PickupReadyTimedropdownValue2019_Xpath = ".//*[@id='pickupreadytime_chosen']/div/ul/li";
        public string PickupCloseTimedropdownValue2019_Xpath = ".//*[@id='pickupclosetime_chosen']/div/ul/li";
        public string PickupReadyTimePopUpError2019_Xpath = "//*[@id='pickup-time-validation-warning']/h4";
        public string PickupCloseTimePopUpError2019_Xpath = ".//*[@id='close-time-validation-warning']/h4";
        public string PickupReadyTimePopUpErrorMessage2019_Xpath = ".//*[@id='pickup-time-validation-warning']/p";
        public string PickupCloseTimePopUpErrorMessage2019_Xpath = ".//*[@id='close-time-validation-warning']/p";
        public string PickupReadyTimePopUpAlertCloseOption2019_Xpath = ".//*[@id='pickup-time-validation-warning']/h4/i[2]";
        public string PickupCloseTimePopUpAlertCloseOption2019_Xpath = ".//*[@id='close-time-validation-warning']/h4/i[2]";
        public string ViewRatesbutton2019_Xpath = ".//*[@id='page-content-wrapper']//button[@class = 'btn btn-block btn-warning']";
        public string PickupCloseTimeValidationMessagePageAtbottom_Xpath = "//*[@id='page-content-wrapper']//form//span[6]";
        public string PickupReadyTimeValidationMessagePageAtbottom_Xpath = ".//*[@id='page-content-wrapper']//form//span[5]";
        public string AddShipmentCustomerLabel_Xpath = ".//*[@class='StationCustomerLabel']//p";
        public string AddShipmentPopOverMessage_Xpath = ".//*[@class='popover-content']";
    }
}
