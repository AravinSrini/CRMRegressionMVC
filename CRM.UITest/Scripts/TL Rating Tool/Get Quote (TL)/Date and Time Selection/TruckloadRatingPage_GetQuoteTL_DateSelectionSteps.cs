using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.TL_Rating_Tool.Get_Quote__TL_.Date_and_Time_Selection
{
    [Binding]
    public class TruckloadRatingPage_GetQuoteTL_DateSelectionSteps: TruckloadRatingTool
    {
        [When(@"I click on Dropoff calendar")]
        public void WhenIClickOnDropoffCalendar()
        {
            Report.WriteLine("Click on Dropoff calendar");
            Click(attributeName_id, TL_DropoffDate_Id);
        }

        [When(@"I should be displayed with popup of calendar in month format from dropoff")]
        public void WhenIShouldBeDisplayedWithPopupOfCalendarInMonthFormatFromDropoff()
        {
            Report.WriteLine("Dropoff Month calendar should be displayed in popup");
            VerifyElementPresent(attributeName_xpath, TL_DropoffCalendarPopup_xpath, "datepicker-days");
        }

        [When(@"I should be displayed with popup of calendar in month format from pickup")]
        public void WhenIShouldBeDisplayedWithPopupOfCalendarInMonthFormatFromPickup()
        {
            Report.WriteLine("Pickup Month calendar should be displayed in popup");
            VerifyElementPresent(attributeName_xpath, TL_PickupCalendarPopup_xpath, "datepicker_days");
        }

        [When(@"I select new date")]
        public void WhenISelectNewDate()
        {
            Report.WriteLine("Select new date from calendar");
            DatePickerFromCalander(attributeName_xpath, TL_Selectingdates_xpath, 1, TL_selectingmonth_xpath);        
        }
        
        [When(@"I click on Pickup calendar")]
        public void WhenIClickOnPickupCalendar()
        {
            Report.WriteLine("Click on Pickup calendar");
            Click(attributeName_id, TL_PickupDate_Id);
        }
        
        [When(@"I select pick up date greater than dropoff date")]
        public void WhenISelectPickUpDateGreaterThanDropoffDate()
        {
            Report.WriteLine("Select pickup date more than dropoff date");
            DatePickerFromCalander(attributeName_xpath, TL_Selectingdates_xpath, 3, TL_selectingmonth_xpath);
        }

        [When(@"I click on the Get Live Quote button")]
        public void WhenIClickOnTheGetLiveQuoteButton()
        {
            Report.WriteLine("Click on get live quote button");
            Click(attributeName_xpath, TL_GetLiveQuote_Button_Xpath);
        }

        [Then(@"I must see the pickup date calendar in Shipping From section")]
        public void ThenIMustSeeThePickupDateCalendarInShippingFromSection()
        {
            Report.WriteLine("Pickup date calendar must be displayed");
            VerifyElementVisible(attributeName_id, TL_PickupDate_Id, "PickupDate");
        }
        
        [Then(@"I must see the dropoff date calendar in Shipping To section")]
        public void ThenIMustSeeTheDropoffDateCalendarInShippingToSection()
        {
            Report.WriteLine("Dropoff date calendar must be displayed");
            VerifyElementVisible(attributeName_id, TL_DropoffDate_Id, "DropoffDate");
        }
        
        [Then(@"I click on Pickup calendar")]
        public void ThenIClickOnPickupCalendar()
        {
            Report.WriteLine("Click on Pickup calendar");
            Click(attributeName_id, TL_PickupDate_Id);
        }
        
        [Then(@"I should be displayed with popup of calendar in month format from pickup")]
        public void ThenIShouldBeDisplayedWithPopupOfCalendarInMonthFormatFromPickup()
        {
            Report.WriteLine("Pickup Month calendar should be displayed in popup");
            VerifyElementPresent(attributeName_xpath, TL_PickupCalendarPopup_xpath, "datepicker_days");
        }
        
        [Then(@"I click on Dropoff calendar")]
        public void ThenIClickOnDropoffCalendar()
        {
            Report.WriteLine("Click on Dropoff calendar");
            Click(attributeName_id, TL_DropoffDate_Id);
        }

        [Then(@"I should be displayed with popup of calendar in month format from dropoff")]
        public void ThenIShouldBeDisplayedWithPopupOfCalendarInMonthFormatFromDropoff()
        {
            Report.WriteLine("Dropoff Month calendar should be displayed in popup");
            VerifyElementPresent(attributeName_xpath, TL_DropoffCalendarPopup_xpath, "datepicker-days");
        }

        [Then(@"Pick up date should be displayed by default as current date")]
        public void ThenPickUpDateShouldBeDisplayedByDefaultAsCurrentDate()
        {
            Report.WriteLine("Pickup date should be displayed as current date by default");           
            DateTime today = DateTime.Today;
            string s_today = today.ToString("MM/dd/yyyy");
            var PickupDate_UI = GetAttribute(attributeName_id, TL_PickupDate_Id, "value");
            Assert.AreEqual(PickupDate_UI, s_today);
        }
        
        [Then(@"Dropoff date should be displayed by default as current date")]
        public void ThenDropoffDateShouldBeDisplayedByDefaultAsCurrentDate()
        {
            Report.WriteLine("Dropoff date should be displayed as current date by default");            
            var DropoffDate_format = DateTime.Today.ToString("MM/dd/yyyy");
            var DropoffDate_UI = GetAttribute(attributeName_id, TL_DropoffDate_Id, "value");
            Assert.AreEqual(DropoffDate_UI, DropoffDate_format);
        }
        
        [Then(@"I should be able to select new date")]
        public void ThenIShouldBeAbleToSelectNewDate()
        {
            Report.WriteLine("New date should be selected");
            DatePickerFromCalander(attributeName_xpath, TL_Selectingdates_xpath, 1, TL_selectingmonth_xpath);            
        }
        
        [Then(@"I should not be able to select the dates in past")]
        public void ThenIShouldNotBeAbleToSelectTheDatesInPast()
        {
            Report.WriteLine("Should not be able to select the past dates");            
            PreviousDisabledDate(attributeName_xpath, TL_Selectingdates_xpath, -1, "");
        }
        
        [Then(@"I should be displayed with the ErrorMessage")]
        public void ThenIShouldBeDisplayedWithTheErrorMessage()
        {
            Report.WriteLine("Error message should be displayed");
            VerifyElementVisible(attributeName_xpath, TL_Errormsgheader_xpath, "ERROR");
            string ActualError = Gettext(attributeName_xpath, TL_ErrormsgCalendar_xpath);
            string ExpectedError = "Pickup Date should not be greater than Dropoff Date.";
            Assert.AreEqual(ExpectedError, ActualError);
        }
    }
}
