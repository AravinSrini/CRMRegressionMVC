using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using CRM.UITest.Objects;
using TechTalk.SpecFlow;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Information_Screen
{
    [Binding]
    public class AddShipmentLTL_PickupDateAndTime_AllUsersSteps : AddShipments
    {


        [Given(@"I arrive and Shipment list page")]
        public void GivenIArriveAndShipmentListPage()
        {
            Report.WriteLine("Shipment List page");
            Verifytext(attributeName_xpath, ShipmentList_title_Xpath, "Shipment List");

        }
        [Then(@"I click on Date Picker")]
        public void ThenIClickOnDatePicker()
        {
            Report.WriteLine("Click on Date picker");
            scrollpagedown();
            Thread.Sleep(2000);
            Click(attributeName_xpath, PickUpDate_Xpath);
        }


        [When(@"I click on Add Shipment Button")]
        public void WhenIClickOnAddShipmentButton()
        {
            Report.WriteLine("Click on Add Shipment Button");
            Click(attributeName_id, AddShipmentButton_id);
        }


        [When(@"I click on Add Shipment button for Internal Users")]
        public void WhenIClickOnAddShipmentButtonForInternalUsers()
        {
            Report.WriteLine("Click on Add Shipment button Internal users");
            Click(attributeName_id, AddShipmentButtionInternal_Id);
        }


        [Given(@"I select a customer of TMS type MG or Both from the customer selection dropdown")]
        public void GivenISelectACustomerOfTMSTypeMGOrBothFromTheCustomerSelectionDropdown()
        {
            Report.WriteLine("Customer Selection dropdown");
            Click(attributeName_xpath, AllCustomerDropdown_Selection_Internal_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, AllCustomerDroppdownValues_Internal_Xpath, "ZZZ - GS Customer Test");
        }

        [When(@"I Click on LTL service type")]
        public void WhenIClickOnLTLServiceType()
        {
            Report.WriteLine("Click on LTL tile");
            Click(attributeName_id, ShipmentServiceTypeLTL_id);
        }

        [Then(@"I should be able to select PickUp date")]
        public void ThenIShouldBeAbleToSelectPickUpDate()
        {
            Report.WriteLine("PickUp date selection");
            DatePickerFromCalander(attributeName_xpath, LTLSelectingDates_Xpath, 1, LTL_selectingmonth_xpath);
        }


        [When(@"I arrive on Add shipment LTL page")]
        public void WhenIArriveOnAddShipmentLTLPage()
        {
            Report.WriteLine("Add Shipment LTL page");
            Verifytext(attributeName_xpath, AddShipment_PageTitle_xpath, "Add Shipment (LTL)");
        }


        [Then(@"I should be able to select Pickup date (.*)")]
        public void ThenIShouldBeAbleToSelectPickupDate(string Readytime)
        {
            Report.WriteLine("Select Pickup date Ready time");
            scrollpagedown();
            Thread.Sleep(2000);
            Click(attributeName_xpath, LTL_PickUpReadyTime_Xpath);
            VerifyElementVisible(attributeName_xpath, LTL_PickUpReadyTimeDropdown_Xpath, "Ready Time");
            SelectDropdownValueFromList(attributeName_xpath, LTL_PickUpReadyTimeDropdown_Xpath, Readytime);
        }

        [Then(@"I must be able to select Pickup date (.*)")]
        public void ThenIMustBeAbleToSelectPickupDate(string Closetime)
        {
            Report.WriteLine("PickUp date Close time");
            Thread.Sleep(5000);
            Click(attributeName_xpath, LTL_PickUpCloseTime_Xpath);
            VerifyElementVisible(attributeName_xpath, LTL_PickUpCloseTimeDropdown_Xpath, "Close Time");
            SelectDropdownValueFromList(attributeName_xpath, LTL_PickUpCloseTimeDropdown_Xpath, Closetime);
        }


        [Then(@"I should be able to choose PickUp date (.*) that is after PickUp Date Ready time")]
        public void ThenIShouldBeAbleToChoosePickUpDateThatIsAfterPickUpDateReadyTime(string Closetime)
        {
            Report.WriteLine("PickUp date Close time");
            Click(attributeName_xpath, LTL_PickUpCloseTime_Xpath);
            VerifyElementVisible(attributeName_xpath, LTL_PickUpCloseTimeDropdown_Xpath, "Close Time");
            SelectDropdownValueFromList(attributeName_xpath, LTL_PickUpCloseTimeDropdown_Xpath, Closetime);
        }

        [Then(@"I select PickUp date (.*) that is before PickUp date Ready time")]
        public void ThenISelectPickUpDateThatIsBeforePickUpDateReadyTime(string Closetime)
        {
            Report.WriteLine("PickUp date Close time");
            Click(attributeName_xpath, LTL_PickUpCloseTime_Xpath);
            VerifyElementVisible(attributeName_xpath, LTL_PickUpCloseTimeDropdown_Xpath, "Close Time");
            SelectDropdownValueFromList(attributeName_xpath, LTL_PickUpCloseTimeDropdown_Xpath, Closetime);
        }


        [Then(@"I should be able to view Pickup Date defaulted to the current date")]
        public void ThenIShouldBeAbleToViewPickupDateDefaultedToTheCurrentDate()
        {
            Report.WriteLine("PickUp Date");
            VerifyElementVisible(attributeName_xpath, PickUpDate_Xpath, "PickUp Date");
            DateTime today = DateTime.Today;
            string s_today = today.ToString("MM/dd/yyyy");
            var PickupDate_UI = GetAttribute(attributeName_xpath, PickUpDate_Xpath, "value");
            Assert.AreEqual(PickupDate_UI, s_today);

        }

        [Then(@"I should not be able to select a date prior to the current defaulted date")]
        public void ThenIShouldNotBeAbleToSelectADatePriorToTheCurrentDefaultedDate()
        {
            Report.WriteLine("Should not be able to select prior date to current date");
            PreviousDisabledDate(attributeName_xpath, LTLSelectingDates_Xpath, -1, "");


        }


        [Then(@"I select Pickup date Ready time")]
        public void ThenISelectPickupDateReadyTime()
        {
            Report.WriteLine("Select Pickup date Ready time");
            Click(attributeName_xpath, LTL_PickUpReadyTime_Xpath);
            VerifyElementVisible(attributeName_xpath, LTL_PickUpReadyTimeDropdown_Xpath, "Ready Time");
            SelectDropdownValueFromList(attributeName_xpath, LTL_PickUpReadyTimeDropdown_Xpath, "4:00 AM");
        }


        [Then(@"I select Pickup date (.*)")]
        public void ThenISelectPickupDate(string Closetime)
        {
            Report.WriteLine("Select Pickup date Ready time");
           // scrollpagedown();
            Thread.Sleep(2000);
            Click(attributeName_xpath, LTL_PickUpCloseTime_Xpath);
            VerifyElementVisible(attributeName_xpath, LTL_PickUpCloseTimeDropdown_Xpath, "Close Time");
            SelectDropdownValueFromList(attributeName_xpath, LTL_PickUpCloseTimeDropdown_Xpath, Closetime);
        }


        [Then(@"Then i should recieve a message stating - Please select a Pickup Date Close time that is after the Pickup Date Ready time\.")]
        public void ThenThenIShouldRecieveAMessageStating_PleaseSelectAPickupDateCloseTimeThatIsAfterThePickupDateReadyTime_()
        {
            Report.WriteLine("Display of error message when Pickup date Close time is before Pickup Date Ready time");
            VerifyElementVisible(attributeName_xpath, LTL_PickUpCloseTimeError_Xpath, "Close time");
            string error = Gettext(attributeName_xpath, LTL_PickUpCloseTimeErrorContent_Xpath);
            String actualerror = "Please select a Pickup Date Close time that is after the Pickup Date Ready time.";
            Assert.AreEqual(error, actualerror);
        }

        [Then(@"I should be able to select PickUp date (.*) that is before Pickup Date Close time")]
        public void ThenIShouldBeAbleToSelectPickUpDateThatIsBeforePickupDateCloseTime(string Readytime)
        {
            Report.WriteLine("Select Pickup date Ready time");
            Click(attributeName_xpath, LTL_PickUpReadyTime_Xpath);
            VerifyElementVisible(attributeName_xpath, LTL_PickUpReadyTimeDropdown_Xpath, "Ready Time");
            SelectDropdownValueFromList(attributeName_xpath, LTL_PickUpReadyTimeDropdown_Xpath, Readytime);
        }
        [Then(@"I select PickUp date (.*) that is after Pickup Date Close time")]
        public void ThenISelectPickUpDateThatIsAfterPickupDateCloseTime(string Readytime)
        {
            Report.WriteLine("Select Pickup date Ready time");
            Click(attributeName_xpath, LTL_PickUpReadyTime_Xpath);
            VerifyElementVisible(attributeName_xpath, LTL_PickUpReadyTimeDropdown_Xpath, "Ready Time");
            SelectDropdownValueFromList(attributeName_xpath, LTL_PickUpReadyTimeDropdown_Xpath, Readytime);
        }


        [Then(@"Then i should receive message stating - Please select a Pickup Date Ready time that is before the Pickup Date Close time\.")]
        public void ThenThenIShouldReceiveMessageStating_PleaseSelectAPickupDateReadyTimeThatIsBeforeThePickupDateCloseTime_()
        {
            Report.WriteLine("Display of error message when Pickup date Close time is before Pickup Date Ready time");
            VerifyElementVisible(attributeName_xpath, LTL_PickUpReadyTimeError_Xpath, "ReadyTime");
            string error = Gettext(attributeName_xpath, LTL_PickUpReadyTimeErrorContent_Xpath);
            string actualerror = "Please select a Pickup Date Ready time that is before the Pickup Date Close time.";
            Assert.AreEqual(error, actualerror);
        }
    }
}
