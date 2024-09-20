using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using TechTalk.SpecFlow;
using System.Threading;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment__LTL__2019
{
    [Binding]
    public class AddShipmentLTL2019_PickupDateSectionSteps : AddShipments2019
    {
        AddShipmentLTL ltl = new AddShipmentLTL();
        List<string> uiReadyTimeList = null;
        List<string> uiCloseTimeList = null;

        string usertype = string.Empty;
        [Given(@"I am a shp\.entry shp\.entrynorates, sales, sales management, operations, or stationowner (.*) user")]
        public void GivenIAmAShp_EntryShp_EntrynoratesSalesSalesManagementOperationsOrStationownerUser(string user)
        {
            
            usertype = user;
           
            if (user == "External")
            {
                string username = ConfigurationManager.AppSettings["username-NewScreenShipEntryUser"].ToString();
                string password = ConfigurationManager.AppSettings["password-NewScreenShipEntryUser"].ToString();
                CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
                CrmLogin.LoginToCRMApplication(username, password);
            }
            else if (user == "Internal")
            {  
                string username = ConfigurationManager.AppSettings["username-NewScreenCrmOperationUser"].ToString();
                string password = ConfigurationManager.AppSettings["password-NewScreenCrmOperationUser"].ToString();
                CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
                CrmLogin.LoginToCRMApplication(username, password);
            }
            else if (user == "Sales")
            {
                usertype = "Internal";
                string username = ConfigurationManager.AppSettings["username-NewScreenSalesUser"].ToString();
                string password = ConfigurationManager.AppSettings["password-NewScreenSalesUser"].ToString();
                CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
                CrmLogin.LoginToCRMApplication(username, password);
            }
        }


        [When(@"I arrive to the Add Shipment \(LTL\) page")]
        public void WhenIArriveToTheAddShipmentLTLPage()
        { 
            ltl.NaviagteToShipmentList();
            ltl.SelectCustomerFromShipmentList(usertype, "ZZZ - GS Customer Test");
        }

        [Then(@"today's date will be the default selection in the ""(.*)"" section")]
        public void ThenTodaySDateWillBeTheDefaultSelectionInTheSection(string pickupdate)
        {
            string CurrentDate = DateTime.Now.AddDays(0).ToString("MM/dd/yyyy");
            string[] Date = CurrentDate.Split(' ');
            string Day = Date[0];
            VerifyElementPresent(attributeName_id, PickUpDateCalender2019_Id, "PickUpDate");
            string expected = GetValue(attributeName_id, PickUpDateCalender2019_Id, "value");
            Assert.AreEqual(expected, Day);
        }

        [Then(@"""(.*)"" will be the default Ready selection in the ""(.*)"" section")]
        public void ThenWillBeTheDefaultReadySelectionInTheSection(string readytime, string pickupdate)
        {
            Verifytext(attributeName_xpath, PickupDateSection2019_Xpath, pickupdate);
            VerifyElementPresent(attributeName_xpath, PickUpDate_ReadyTime2019_xpath, "PickUpDateReadyTime");
            string expected = Gettext(attributeName_xpath, PickUpDate_ReadyTime2019_xpath);
            Assert.AreEqual(expected, "Ready 08:00 AM");
        }

        [Then(@"I have the option to select another Ready time from the drop down list")]
        public void ThenIHaveTheOptionToSelectAnotherReadyTimeFromTheDropDownList()
        {
            Click(attributeName_xpath, PickUpDate_ReadyTime2019_xpath);
            IList<IWebElement> uiReadyTime = GlobalVariables.webDriver.FindElements(By.XPath(PickupReadyTimedropdownValue2019_Xpath));
            uiReadyTimeList = uiReadyTime.Select(a => a.Text).ToList();
            SelectDropdownValueFromList(attributeName_xpath, PickupReadyTimeValue2019_Xpath, "01:00 AM");
        }

        [Then(@"the Ready options are displayed in (.*) minute intervals beginning at ""(.*)"" and ending at ""(.*)""")]
        public void ThenTheReadyOptionsAreDisplayedInMinuteIntervalsBeginningAtAndEndingAt(int p0, string p1, string p2)
        {
            List<string> expectedReadyTimeList = new List<string>()
            { "12:00 AM", "12:30 AM", "01:00 AM", "01:30 AM", "02:00 AM", "02:30 AM", "03:00 AM", "03:30 AM", "04:00 AM", "04:30 AM", "05:00 AM", "05:30 AM", "06:00 AM", "06:30 AM", "07:00 AM", "07:30 AM", "08:00 AM", "08:30 AM", "09:00 AM", "09:30 AM", "10:00 AM", "10:30 AM", "11:00 AM", "11:30 AM",
              "12:00 PM", "12:30 PM", "01:00 PM", "01:30 PM", "02:00 PM", "02:30 PM", "03:00 PM", "03:30 PM", "04:00 PM", "04:30 PM", "05:00 PM", "05:30 PM", "06:00 PM", "06:30 PM", "07:00 PM", "07:30 PM", "08:00 PM", "08:30 PM", "09:00 PM", "09:30 PM", "10:00 PM", "10:30 PM", "11:00 PM", "11:30 PM" };
            //Click(attributeName_xpath, PickUpDate_ReadyTime2019_xpath);
            CollectionAssert.AreEqual(expectedReadyTimeList, uiReadyTimeList);
        }

        [Then(@"""(.*)"" will be the default Close selection in the ""(.*)"" section")]
        public void ThenWillBeTheDefaultCloseSelectionInTheSection(string closetime, string pickupdate)
        {
            Verifytext(attributeName_xpath, PickupDateSection2019_Xpath, pickupdate);
            
            string expected = Gettext(attributeName_xpath, PickupCloseTimeValue2019_Xpath);
            Assert.AreEqual(expected, closetime);
        }

        [Then(@"I have the option to select another Close time from the drop down list")]
        public void ThenIHaveTheOptionToSelectAnotherCloseTimeFromTheDropDownList()
        {
            Click(attributeName_xpath, PickupCloseTimeValue2019_Xpath);
            IList<IWebElement> uiCloseTime = GlobalVariables.webDriver.FindElements(By.XPath(PickupCloseTimedropdownValue2019_Xpath));
            uiCloseTimeList = uiCloseTime.Select(a => a.Text).ToList();
            SelectDropdownValueFromList(attributeName_xpath, PickupCloseTimedropdownValue2019_Xpath, "02:00 AM");
        }

        [Then(@"the Close options are displayed in (.*) minute intervals beginning at ""(.*)"" and ending at ""(.*)""")]
        public void ThenTheCloseOptionsAreDisplayedInMinuteIntervalsBeginningAtAndEndingAt(int p0, string p1, string p2)
        {
            List<string> expectedCloseTimeList = new List<string>()
            { "12:00 AM", "12:30 AM", "01:00 AM", "01:30 AM", "02:00 AM", "02:30 AM", "03:00 AM", "03:30 AM", "04:00 AM", "04:30 AM", "05:00 AM", "05:30 AM", "06:00 AM", "06:30 AM", "07:00 AM", "07:30 AM", "08:00 AM", "08:30 AM", "09:00 AM", "09:30 AM", "10:00 AM", "10:30 AM", "11:00 AM", "11:30 AM",
              "12:00 PM", "12:30 PM", "01:00 PM", "01:30 PM", "02:00 PM", "02:30 PM", "03:00 PM", "03:30 PM", "04:00 PM", "04:30 PM", "05:00 PM", "05:30 PM", "06:00 PM", "06:30 PM", "07:00 PM", "07:30 PM", "08:00 PM", "08:30 PM", "09:00 PM", "09:30 PM", "10:00 PM", "10:30 PM", "11:00 PM", "11:30 PM"   };

            //Click(attributeName_xpath, PickupCloseTimeValue2019_Xpath);
            
            CollectionAssert.AreEqual(expectedCloseTimeList, uiCloseTimeList);
        }

        [Given(@"I fill the required fields in shipping From section")]
        public void GivenIFillTheRequiredFieldsInShippingFromSection()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            //Click(attributeName_xpath, ShippingFrom_ClearAddress_Xpath);
            SendKeys(attributeName_id, ShippingFrom_LocationName_NewScreen_Id, "testoriginname");
            SendKeys(attributeName_id, ShippingFrom_LocationAddressLine1_NewScreen_Id, "testadd1");
            SendKeys(attributeName_id, ShippingFrom_LocationAddressLine2_NewScreen_Id, "testadd2");
            SendKeys(attributeName_id, ShippingFrom_zipcode_NewScreen_Id, "90001");
        }

        [Given(@"I fill the required fileds in shipping To section")]
        public void GivenIFillTheRequiredFiledsInShippingToSection()
        {
            Thread.Sleep(2000);
            //Click(attributeName_xpath, ShippingTo_ClearAddress_Xpath);
            SendKeys(attributeName_id, ShippingTo_LocationName_NewScreen_Id, "testdestinationname");
            SendKeys(attributeName_id, ShippingTo_LocationAddressLine1_NewScreen_Id, "testadd3");
            SendKeys(attributeName_id, ShippingTo_LocationAddressLine2_NewScreen_Id, "testadd4");
            SendKeys(attributeName_id, ShippingTo_zipcode_NewScreen_Id, "90002");
        }


        [Given(@"I arrived to the Add Shipment \(LTL\) page")]
        public void GivenIArrivedToTheAddShipmentLTLPage()
        {
            ltl.NaviagteToShipmentList();
            ltl.SelectCustomerFromShipmentList(usertype, "ZZZ - GS Customer Test");
        }

        [When(@"I click on the Date Picker icon in the Pickup Date section")]
        public void WhenIClickOnTheDatePickerIconInThePickupDateSection()
        {
            Click(attributeName_id, PickUpDateCalender2019_Id);
        }

        [Then(@"a popup calendar will appear")]
        public void ThenAPopupCalendarWillAppear()
        {
            VerifyElementPresent(attributeName_xpath, PickUpDateCalendarPopUp2019_Xpath, "PickUpDate Calendar popUp");
        }

        [Then(@"I am Unable to select a date prior to today")]
        public void ThenIAmUnableToSelectADatePriorToToday()
        {   
            //PreviousDisabledDate(attributeName_xpath, PickUpDateCalendarPopUpValue2019_Xpath, -1, PickUpDateCalendarPopUpForwardToggleArrow2019_Xpath);
            DatePickerFromCalander(attributeName_xpath, PickUpDateCalendarPopUpValue2019_Xpath, -1, PickUpDateCalendarPopUpForwardToggleArrow2019_Xpath);
            string CurrentDate = DateTime.Now.AddDays(0).ToString("MM/dd/yyyy");
            string[] Date = CurrentDate.Split(' ');
            string Day = Date[0];
            VerifyElementPresent(attributeName_id, PickUpDateCalender2019_Id, "PickUpDate");
            string expected = GetValue(attributeName_id, PickUpDateCalender2019_Id, "value");
            Assert.AreEqual(expected, Day);

        }

        [Then(@"I am Unable to toggle backward to any month prior to the current month")]
        public void ThenIAmUnableToToggleBackwardToAnyMonthPriorToTheCurrentMonth()
        {
            VerifyElementNotVisible(attributeName_xpath, PickUpDateCalendarPopUpBackwardToggleArrow2019_Xpath, "Backward Toggle");
        }

        [Then(@"I have the option to toggle to future months")]
        public void ThenIHaveTheOptionToToggleToFutureMonths()
        {
            VerifyElementVisible(attributeName_xpath, PickUpDateCalendarPopUpForwardToggleArrow2019_Xpath, "Forward Toggle");
        }

        [Then(@"I have the option to toggle backward to previous months")]
        public void ThenIHaveTheOptionToToggleBackwardToPreviousMonths()
        {
            Click(attributeName_xpath, PickUpDateCalendarPopUpForwardToggleArrow2019_Xpath);
            VerifyElementVisible(attributeName_xpath, PickUpDateCalendarPopUpBackwardToggleArrow2019_Xpath, "Backward Toggle");
        }

        [Given(@"I clicked on the Date Picker icon in the Pickup Date section")]
        public void GivenIClickedOnTheDatePickerIconInThePickupDateSection()
        {
            Click(attributeName_id, PickUpDateCalender2019_Id);

        }

        [When(@"I Select any allowable day from the calendar")]
        public void WhenISelectAnyAllowableDayFromTheCalendar()
        {
            DatePickerFromCalander(attributeName_xpath, PickUpDateCalendarPopUpValue2019_Xpath, 1, PickUpDateCalendarPopUpForwardToggleArrow2019_Xpath);

        }

        [Then(@"the date picker calendar will close")]
        public void ThenTheDatePickerCalendarWillClose()
        {
            VerifyElementNotVisible(attributeName_xpath, PickUpDateCalendarPopUp2019_Xpath, "PickUpDate Calendar popUp");
        }

        [Then(@"the selected date will be displayed in the Pickup Date section")]
        public void ThenTheSelectedDateWillBeDisplayedInThePickupDateSection()
        {
            string CurrentDate = DateTime.Now.AddDays(1).ToString("MM/dd/yyyy");
            string[] Date = CurrentDate.Split(' ');
            string Day = Date[0];
            VerifyElementPresent(attributeName_id, PickUpDateCalender2019_Id, "PickUpDate");
            string expected = GetValue(attributeName_id, PickUpDateCalender2019_Id, "value");
            Assert.AreEqual(expected, Day);
        }

        [When(@"I Select a Close time ""(.*)"" in the Pickup Date section that is earlier than the Ready time ""(.*)""")]
        public void WhenISelectACloseTimeInThePickupDateSectionThatIsEarlierThanTheReadyTime(string closetime, string readytime)
        {
            Click(attributeName_xpath, PickUpDate_ReadyTime2019_xpath);
            SelectDropdownValueFromList(attributeName_xpath, PickupReadyTimeValue2019_Xpath, readytime);
            Click(attributeName_xpath, PickupCloseTimeValue2019_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, PickupCloseTimedropdownValue2019_Xpath, closetime);
        }

        [Then(@"I will receive an error message: Error ""(.*)""")]
        public void ThenIWillReceiveAnErrorMessageError(string alertMessage)
        {
            string uiCloseTimePopUpAlert = Gettext(attributeName_xpath, PickupCloseTimePopUpError2019_Xpath);
            Assert.AreEqual(uiCloseTimePopUpAlert, "ERROR");
            string uiCloseTimePopUpAlertMessage = Gettext(attributeName_xpath, PickupCloseTimePopUpErrorMessage2019_Xpath);
            Assert.AreEqual(uiCloseTimePopUpAlertMessage, alertMessage);
        }

        [Then(@"I have the option to close the error message")]
        public void ThenIHaveTheOptionToCloseTheErrorMessage()
        {
            VerifyElementPresent(attributeName_xpath, PickupCloseTimePopUpAlertCloseOption2019_Xpath, "Close time Alert Popup Close Option");
        }

        [Given(@"I selected a Close time ""(.*)"" in the Pickup Date section that is earlier than the Ready time ""(.*)""")]
        public void GivenISelectedACloseTimeInThePickupDateSectionThatIsEarlierThanTheReadyTime(string closetime, string readytime)
        {
            WhenISelectACloseTimeInThePickupDateSectionThatIsEarlierThanTheReadyTime(closetime, readytime);
        }

        [Given(@"I closed the Error ""Please select a Pickup Date Close time that is after the Pickup Date Ready time\. message")]
        public void GivenIClosedTheErrorPleaseSelectAPickupDateCloseTimeThatIsAfterThePickupDateReadyTime_Message()
        {
            Click(attributeName_xpath, PickupCloseTimePopUpAlertCloseOption2019_Xpath);
        }

        [When(@"I have click the View Rates button")]
        public void WhenIHaveClickTheViewRatesButton()
        {
            scrollElementIntoView(attributeName_xpath, ViewRatesbutton2019_Xpath);
            Click(attributeName_xpath, ViewRatesbutton2019_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
        }


        [Then(@"the Error  ""(.*)"" message will displayed")]
        public void ThenTheErrorMessageWillDisplayed(string alertMessage)
        {
            scrollElementIntoView(attributeName_xpath, ViewRatesbutton2019_Xpath);
            string expectedReadyTimeValidationMessage = "Please select a Pickup Date Ready time that is before the Pickup Date Close time.";

            string expectedCloseTimeValidationMessage = "Please select a Pickup Date Close time that is after the Pickup Date Ready time.";
            //ThenIWillReceiveAnErrorMessageError(alertMessage);
            string readyTimeValidationMessage = Gettext(attributeName_xpath, PickupReadyTimeValidationMessagePageAtbottom_Xpath);
            string closeTimeValidationMessage = Gettext(attributeName_xpath, PickupCloseTimeValidationMessagePageAtbottom_Xpath);
            Assert.AreEqual(expectedReadyTimeValidationMessage, readyTimeValidationMessage);
            Assert.AreEqual(expectedCloseTimeValidationMessage, closeTimeValidationMessage);
        }

        [When(@"I Select a Ready time ""(.*)"" in the Pickup Date section that is later than the Close time ""(.*)""")]
        public void WhenISelectAReadyTimeInThePickupDateSectionThatIsLaterThanTheCloseTime(string readytime, string closetime)
        {
            Click(attributeName_xpath, PickupCloseTimeValue2019_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, PickupCloseTimedropdownValue2019_Xpath, closetime);
            Click(attributeName_xpath, PickUpDate_ReadyTime2019_xpath);
            SelectDropdownValueFromList(attributeName_xpath, PickupReadyTimeValue2019_Xpath, readytime);
        }

        [Then(@"I Will receive error message: Error ""(.*)""")]
        public void ThenIWillReceiveErrorMessageError(string alertMessage)
        {
            string uiReadyTimePopUpAlert = Gettext(attributeName_xpath, PickupReadyTimePopUpError2019_Xpath);
            Assert.AreEqual(uiReadyTimePopUpAlert, "ERROR");
            string uiReadyTimePopUpAlertMessage = Gettext(attributeName_xpath, PickupReadyTimePopUpErrorMessage2019_Xpath);
            Assert.AreEqual(uiReadyTimePopUpAlertMessage, alertMessage);
        }

        [Then(@"I've the option to close the error message")]
        public void ThenIVeTheOptionToCloseTheErrorMessage()
        {
            VerifyElementPresent(attributeName_xpath, PickupReadyTimePopUpAlertCloseOption2019_Xpath, "Ready time Alert Popup Close Option");
        }

        [Given(@"I selected a Ready time ""(.*)"" in the Pickup Date section that is later than the Close time ""(.*)""")]
        public void GivenISelectedAReadyTimeInThePickupDateSectionThatIsLaterThanTheCloseTime(string readytime, string closetime)
        {   
            WhenISelectAReadyTimeInThePickupDateSectionThatIsLaterThanTheCloseTime(readytime, closetime);
        }

        [Given(@"I closed the Error ""Please select a Pickup Date Ready time that is before the Pickup Date Close time\. message")]
        public void GivenIClosedTheErrorPleaseSelectAPickupDateReadyTimeThatIsBeforeThePickupDateCloseTime_Message()
        {
            Click(attributeName_xpath, PickupReadyTimePopUpAlertCloseOption2019_Xpath);
        }

        [Then(@"an Error ""(.*)"" message will displayed")]
        public void ThenAnErrorMessageWillDisplayed(string alertMessage)
        {   
            ThenIWillReceiveErrorMessageError(alertMessage);
        }

        [When(@"I Select a Close time ""(.*)"" in the Pickup Date section that is later than the Ready time ""(.*)""")]
        public void WhenISelectACloseTimeInThePickupDateSectionThatIsLaterThanTheReadyTime(string closetime, string readytime)
        {
            WhenISelectACloseTimeInThePickupDateSectionThatIsEarlierThanTheReadyTime(closetime, readytime);
        }

        [Then(@"I will not receive an error message: Error ""(.*)""")]
        public void ThenIWillNotReceiveAnErrorMessageError(string p0)
        {
            VerifyElementNotVisible(attributeName_id, "close-time-validation-warning", "Close time Alert Popup");
        }

        [When(@"I Select a Ready time ""(.*)"" in the Pickup Date section that is equal to the Close time ""(.*)""")]
        public void WhenISelectAReadyTimeInThePickupDateSectionThatIsEqualToTheCloseTime(string readytime, string closetime)
        {
            Click(attributeName_xpath, PickUpDate_ReadyTime2019_xpath);
            SelectDropdownValueFromList(attributeName_xpath, PickupReadyTimeValue2019_Xpath, readytime);
            Click(attributeName_xpath, PickupCloseTimeValue2019_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, PickupCloseTimedropdownValue2019_Xpath, closetime);
        }

        [Given(@"I selected a Ready time ""(.*)"" in the Pickup Date section that is equal to the Close time ""(.*)""")]
        public void GivenISelectedAReadyTimeInThePickupDateSectionThatIsEqualToTheCloseTime(string readytime, string closetime)
        {
            WhenISelectAReadyTimeInThePickupDateSectionThatIsEqualToTheCloseTime(readytime, closetime);
        }
    }
}
