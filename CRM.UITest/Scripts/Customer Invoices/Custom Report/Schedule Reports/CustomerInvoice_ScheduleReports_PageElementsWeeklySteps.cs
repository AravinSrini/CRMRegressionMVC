using System.Collections.Generic;
using System.Configuration;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using CRM.UITest.Entities;

namespace CRM.UITest
{
    [Binding]
    public class CustomerInvoice_ScheduleReports_PageElementsWeeklySteps : Customer_Invoice
    {
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
        CommonmethodFocus Focus = new CommonmethodFocus();
        string email = "zzzext@user.com";
        string activeScheduledCustomReportName = null;

        [Given(@"I am on the Create Custom Report section of scheduled report")]
        public void GivenIAmOnTheCreateCustomReportSectionOfScheduledReport()
        {
            activeScheduledCustomReportName = DBHelper.GetWeeklyActiveCustomReportName(email);
            Click(attributeName_xpath, customerInvoiceIcon_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, customerInvoicesHeader_xpath, "Customer Invoices");
            Click(attributeName_xpath, SelectExistingReportDropdown_xpath);
            SendKeys(attributeName_xpath, ".//*[@id='customReportSelection_chosen']//input[@type='text']", activeScheduledCustomReportName);
            IList<IWebElement> values = GlobalVariables.webDriver.FindElements(By.XPath(SelectExistingReportDropdownValues_xpath));
            values[0].Click();
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, createCustomReportsectionExpandArrow_id);
            GlobalVariables.webDriver.WaitForPageLoad();
        }
        
        [Given(@"I clicked on the Schedule Report button on Create Custom Report section")]
        public void GivenIClickedOnTheScheduleReportButtonOnCreateCustomReportSection()
        {
            Report.WriteLine("Clicked on the Schedule Report button on Create Custom Report section");
            MoveToElement(attributeName_id, scheduleReportButton_id);
            DefineTimeOut(4000);
            WaitForElementPresent(attributeName_id, scheduleReportButton_id,"button");
            Click(attributeName_id, scheduleReportButton_id);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [When(@"I click on the Schedule Report button on modal")]
        public void WhenIClickOnTheScheduleReportButtonOnModal()
        {
            Report.WriteLine("clicked on the Schedule Report button on Create Custom Report section");
            MoveToElement(attributeName_id, scheduleReportButtononmodal_id);
            Click(attributeName_id, scheduleReportButtononmodal_id);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I am a shp\.entry, shp\.entrynortes, shp\.inquiry, shp\.inquirynorates, operations, sales, sales management, station owner, or access rrd user,")]
        public void GivenIAmAShp_EntryShp_EntrynortesShp_InquiryShp_InquirynoratesOperationsSalesSalesManagementStationOwnerOrAccessRrdUser()
        {
            string userName = ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();
            string password = ConfigurationManager.AppSettings["ExternalUserPassword"].ToString();
            CrmLogin.LoginToCRMApplication(userName, password);
            Report.WriteLine("I logged into CRM application with external user credentials");
        }
        
        [Given(@"I am on the Weekly tab of the Schedule Report page")]
        public void GivenIAmOnTheWeeklyTabOfTheScheduleReportPage()
        {
            activeScheduledCustomReportName = DBHelper.GetWeeklyActiveCustomReportName(email);
            Click(attributeName_xpath, customerInvoiceIcon_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, customerInvoicesHeader_xpath, "Customer Invoices");
            Click(attributeName_xpath, SelectExistingReportDropdown_xpath);
            SendKeys(attributeName_xpath, ".//*[@id='customReportSelection_chosen']//input[@type='text']", activeScheduledCustomReportName);
            IList<IWebElement> values = GlobalVariables.webDriver.FindElements(By.XPath(SelectExistingReportDropdownValues_xpath));
            values[0].Click();
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, createCustomReportsectionExpandArrow_id);
            WaitForElementVisible(attributeName_id, scheduleReportButton_id, "Scheduled Report");
            MoveToElement(attributeName_id, scheduleReportButton_id);
            Click(attributeName_id, scheduleReportButton_id);
            WaitForElementVisible(attributeName_id, weeklytab_id, "Weekly");
        }
        
        [Given(@"I have not entered all required information")]
        public void GivenIHaveNotEnteredAllRequiredInformation()
        {
            Report.WriteLine("I have not entered all required information");
            WaitForElementVisible(attributeName_xpath, ScheduleReportmodal_xpath, "ScheduleReportmodal");
            Click(attributeName_xpath, selectTimeHour);
            SelectDropdownValueFromList(attributeName_xpath, selectTimeHourValues, "Select hour...");
            Click(attributeName_xpath, selectTimeMinute);
            SelectDropdownValueFromList(attributeName_xpath, selectTimeMinuteValues, "Select minutes...");
        }
        
        [When(@"I arrive on the Schedule Report modal")]
        public void WhenIArriveOnTheScheduleReportModal()
        {
            Report.WriteLine("arriving on the Schedule Report modal");
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, ScheduleReportmodal_xpath, "ScheduleReportmodal");
        }
        
        [Then(@"I will arrive on the Weekly Time Period tab by Default")]
        public void ThenIWillArriveOnTheWeeklyTimePeriodTabByDefault()
        {
            Report.WriteLine("will be arrived on the weekly time period tab by default");
            WaitForElementVisible(attributeName_id, weeklytab_id, "weekly tab");
            VerifyElementVisible(attributeName_id, weeklytab_id, "weekly tab");
        }
        
        [Then(@"I will see a Select Day drop down list")]
        public void ThenIWillSeeASelectDayDropDownList()
        {
            Report.WriteLine("will be displayed with select dropdown list");
            VerifyElementVisible(attributeName_xpath, selectday, "selectdayoption");
        }
        
        [Then(@"I am required to select a day with options (.*)")]
        public void ThenIAmRequiredToSelectADayWithOptions(string dayOptions)
        {
            Report.WriteLine(" I will be displayed with select day dropdown list with days");
            dayOptions = "Sunday,Monday,Tuesday,Wednesday,Thursday,Friday,Saturday";
            IList <string> DayOptions = dayOptions.Split(',');
            Click(attributeName_xpath, selectday);
            IList<IWebElement> dayOptionsUI = GlobalVariables.webDriver.FindElements(By.XPath(selectdayValues));
            List<string> DayOptionsUI = new List<string>();
            foreach (IWebElement element in dayOptionsUI)
            {
                DayOptionsUI.Add((element.Text).ToString());
            }

            for (int i =0;i<7;i++)
            {
                Assert.AreEqual(DayOptions[i], DayOptionsUI[i]);
            }         
        }
        
        [Then(@"I will see a Select Time section with Hours(.*)")]
        public void ThenIWillSeeASelectTimeSectionWithHours(string timeHourOptions)
        {
            Report.WriteLine(" I will be displayed with select time for hour dropdown list with hours");
            timeHourOptions = "Select hour...,01,02,03,04,05,06,07,08,09,10,11,12";
            IList<string> TimeHourOptions = timeHourOptions.Split(',');
            Click(attributeName_xpath, selectday);
            Click(attributeName_xpath,selectTimeHour);
            IList<IWebElement> timeHourOptionsUI = GlobalVariables.webDriver.FindElements(By.XPath(selectTimeHourValues));
            List<string> TimeHourOptionsUI = new List<string>();
            foreach (IWebElement element in timeHourOptionsUI)
            {
                TimeHourOptionsUI.Add((element.Text).ToString());
            }

            for (int i = 0; i < TimeHourOptions.Count; i++)
            {
                Assert.AreEqual(TimeHourOptions[i], TimeHourOptionsUI[i]);
            }
        }
        
        [Then(@"I will see a Minutes (.*)")]
        public void ThenIWillSeeAMinutes(string timeMinuteOptions)
        {
            Report.WriteLine(" I will be displayed with select time for minute dropdown list with minutes");
            timeMinuteOptions = "Select minutes...,00,15,30,45";
            IList<string> TimeMinuteOptions = timeMinuteOptions.Split(',');
            Click(attributeName_xpath, selectTimeMinute);
            IList<IWebElement> timeMinuteOptionsUI = GlobalVariables.webDriver.FindElements(By.XPath(selectTimeMinuteValues));
            List<string> TimeMinuteOptionsUI = new List<string>();
            foreach (IWebElement element in timeMinuteOptionsUI)
            {
                TimeMinuteOptionsUI.Add((element.Text).ToString());
            }

            for (int i = 0; i < TimeMinuteOptions.Count; i++)
            {
                Assert.AreEqual(TimeMinuteOptions[i], TimeMinuteOptionsUI[i]);
            }
        }
        
        [Then(@"I will see AM/PM radio button with AM as default selected value")]
        public void ThenIWillSeeAMPMRadioButtonWithAMAsDefaultSelectedValue()
        {
            Report.WriteLine("I will see AM / PM radio button with AM as default selected value");
            VerifyElementVisible(attributeName_xpath, selectTimeAM, "selectTimeAMRadiobutton");
            VerifyElementVisible(attributeName_xpath, selectTimePM, "selectTimePMRadiobutton");
            VerifyElementChecked(attributeName_xpath,DefaultRadioCheck,"AMPM");
        }
        
        [Then(@"I have the option of selecting the Monthly Time Period tab")]
        public void ThenIHaveTheOptionOfSelectingTheMonthlyTimePeriodTab()
        {
            Report.WriteLine("I have the option of selecting the Monthly Time Period tab");
            VerifyElementVisible(attributeName_id, tabMonthly_id, "tabMonthly");
        }
        
        [Then(@"I will receive a message (.*)")]
        public void ThenIWillReceiveAMessage(string p0)
        {
            Report.WriteLine("I have the option of selecting the Monthly Time Period tab");
            Verifytext(attributeName_id, errormessage_id, "Please enter all required information");
        }
        
        [Then(@"the page will focus to the first field that is missing required information\.")]
        public void ThenThePageWillFocusToTheFirstFieldThatIsMissingRequiredInformation_()
        {
            Report.WriteLine("page will focus to the first field that is missing required information");
            string Hours = GetAttribute(attributeName_xpath, ".//*[@id='hours_chosen']/a/span", "value");
            GlobalVariables.webDriver.SwitchTo().ActiveElement().Equals(GlobalVariables.webDriver.FindElement(By.XPath(selectTimeHour)));
            Focus.VerifyFocus(attributeName_xpath, Hours);
        }
    }
}
