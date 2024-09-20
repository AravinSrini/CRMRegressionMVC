using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Objects;
using CRM.UITest.Scripts.Insurance_Claims;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Customer_Invoices.Custom_Report.Schedule_Reports
{
    [Binding]
    public sealed class Customer_Invoice___Schedule_Reports___Monthly___Page_Elements_Stpes : Customer_Invoice
    {
        InsuranceClaims_SubmitClaimPageFunctionsSteps asaa = new InsuranceClaims_SubmitClaimPageFunctionsSteps();
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
        string email = ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();
        IWebElement element;
        string customReportName;
        string ReportName = Guid.NewGuid().ToString() + "VTst";


        [Given(@"I have selected a Custom report from the Select Existing Custom Report list")]
        public void GivenIHaveSelectedACustomReportFromTheSelectExistingCustomReportList()
        {
            Click(attributeName_xpath, customerInvoiceIcon_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("I have navigated to Customer Invoices list page");
            VerifyElementVisible(attributeName_xpath, customerInvoicesHeader_xpath, "Customer Invoices");
            Report.WriteLine("Select Existing Custom Report from drop down");

            customReportName = DBHelper.GetNotScheduledCustomReportName(email);
            if (customReportName != null)
            {
                Click(attributeName_xpath, SelectExistingReportDropdown_xpath);

                IList<IWebElement> CustInvoiceReportList = GlobalVariables.webDriver.FindElements(By.XPath(SelectExistingReportDropdownValues_xpath));
                for (int i = 1; i <= CustInvoiceReportList.Count; i++)
                {
                    if (CustInvoiceReportList[i].Text.Equals(customReportName))
                    {

                        CustInvoiceReportList[i].Click();
                        break;
                    }
                }
            }

            else
            {
                Click(attributeName_xpath, SelectExistingReportDropdown_xpath);
                Click(attributeName_id, createCustomReportsectionExpandArrow_id);
                WaitForElementVisible(attributeName_id, CreateReportNewButton_Id, "Create New button");
                Report.WriteLine("Create Custom Report section is expanded");
                WaitForElementVisible(attributeName_xpath, ReportName_Xpath, "Report Section");
                SendKeys(attributeName_id, DaysPastDue_Id, "5");
                SendKeys(attributeName_id, InvoiceVal_Id, "4");
                Click(attributeName_xpath, ReportAccount_Xpath);
                Click(attributeName_xpath, "//div[@id='ReportAccounts_chosen']//ul[@class='chosen-results']/li[2]");
                //SelectDropdownValueFromList(attributeName_xpath, ReportAccountDropdownVal_Xpath, "ZZZ - Czar Customer Test");

                SendKeys(attributeName_xpath, ReportName_Xpath, ReportName);
                string checkreport = ReportName;

                Report.WriteLine("Values are passed to all the fields");
                Click(attributeName_id, CreateReportNewButton_Id);
                WaitForElementVisible(attributeName_xpath, SelectExistingReportDropdown_xpath, "SELECT EXISTING CUSTOM REPORT");

                Click(attributeName_xpath, SelectExistingReportDropdown_xpath);

                IList<IWebElement> CustInvoiceReportList = GlobalVariables.webDriver.FindElements(By.XPath(SelectExistingReportDropdownValues_xpath));
                for (int i = 1; i <= CustInvoiceReportList.Count; i++)
                {
                    if (CustInvoiceReportList[i].Text.Equals(checkreport))
                    {

                        CustInvoiceReportList[i].Click();
                        break;
                    }
                }
            }


            Report.WriteLine("expanding the Create Custom Report section");
            Click(attributeName_id, createCustomReportsectionExpandArrow_id);
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_id, scheduleReportButton_id, "Schedule Report");
            Click(attributeName_id, scheduleReportButton_id);
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_id, scheduleReportButton_id, "Schedule Report");
        }


        [Given(@"I arrived on the default Weekly tab of the Schedule Report page,")]
        public void GivenIArrivedOnTheDefaultWeeklyTabOfTheScheduleReportPage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, CustomerInvoice_WeeklyTab_Xpath, "WEEKLY");
            Verifytext(attributeName_xpath, CustomerInvoice_WeeklyTab_Xpath, "WEEKLY");
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I am on the  Monthly tab of the Schedule Report page")]
        public void GivenIAmOnTheMonthlyTabOfTheScheduleReportPage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, CustomerInvoice_MonthlyTab_Xpath);
            Verifytext(attributeName_xpath, CustomerInvoice_MonthlyTab_Xpath, "MONTHLY");
        }

        [When(@"I click on the Monthly tab")]
        public void WhenIClickOnTheMonthlyTab()
        {
         
            Click(attributeName_xpath, CustomerInvoice_MonthlyTab_Xpath);
            WaitForElementVisible(attributeName_xpath, CustomerInvoice_SelectMonths_Label_Xpath, "SELECT MONTHS *");
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Then(@"I will have the option to select one or more months")]
        public void ThenIWillHaveTheOptionToSelectOneOrMoreMonths()
        {
            IsElementPresent(attributeName_xpath, CustomerInvoice_SelectMonths_Label_Xpath, "SELECT MONTHS*");
            IsElementPresent(attributeName_xpath, CustomerInvoice_JanuaryCheckbox_Xpath, "January");
            IsElementPresent(attributeName_xpath, CustomerInvoice_FebuaryCheckbox_Xpath, "February");
            IsElementPresent(attributeName_xpath, CustomerInvoice_MarchCheckbox_Xpath, "March");
            IsElementPresent(attributeName_xpath, CustomerInvoice_AprilCheckbox_Xpath, "April");
            IsElementPresent(attributeName_xpath, CustomerInvoice_MayCheckbox_Xpath, "May");
            IsElementPresent(attributeName_xpath, CustomerInvoice_JuneCheckbox_Xpath, "June");
            IsElementPresent(attributeName_xpath, CustomerInvoice_JulyCheckbox_Xpath, "July");
            IsElementPresent(attributeName_xpath, CustomerInvoice_AugustCheckbox_Xpath, "August");
            IsElementPresent(attributeName_xpath, CustomerInvoice_SeptemberCheckbox_Xpath, "September");
            IsElementPresent(attributeName_xpath, CustomerInvoice_OctoberCheckbox_Xpath, "October");
            IsElementPresent(attributeName_xpath, CustomerInvoice_NovemberCheckbox_Xpath, "November");
            IsElementPresent(attributeName_xpath, CustomerInvoice_DecemberCheckbox_Xpath, "December");

           
        }

        [Then(@"I am required to select at least one month")]
        public void ThenIAmRequiredToSelectAtLeastOneMonth()
        {
            string getMonths=Gettext(attributeName_xpath, CustomerInvoice_SelectMonths_Label_Xpath);
            if (getMonths.Contains("*"))
            {
                Report.WriteLine("Select months is required field");
            }
        }



        [Then(@"I will see a Select Day section")]
        public void ThenIWillSeeASelectDaySection()
        {
            Verifytext(attributeName_xpath, CustomerInvoice_SelectDay_Label_Xpath, "SELECT DAY *");
            Verifytext(attributeName_xpath, CustomerInvoice_SelectDayMonthlyWeek_Label_Xpath, "WEEK");
            Verifytext(attributeName_xpath, CustomerInvoice_SelectDayMonthlyWeekDay_Label_Xpath, "WEEK DAY");
            Verifytext(attributeName_xpath, CustomerInvoice_SelectSpecificDayOfMonth_Label_Xpath, "SPECIFIC DAY OF MONTH");
        }

        [Then(@"I am required to select a day")]
        public void ThenIAmRequiredToSelectADay()
        {
            string getMonths = Gettext(attributeName_xpath, CustomerInvoice_SelectDay_Label_Xpath);
            if (getMonths.Contains("*"))
            {
                Report.WriteLine("SELECT DAY is required field");
            }
        }

        [Then(@"I will see a Select Time section")]
        public void ThenIWillSeeASelectTimeSection()
        {
            Verifytext(attributeName_xpath, CustomerInvoice_SelectSelectTimeLabelMonthly_DropDown_Xpath, "SELECT TIME *");
            Verifytext(attributeName_xpath, CustomerInvoice_SelectTimeMonthlyHours_Label_Xpath, "HOURS");
            Verifytext(attributeName_xpath, CustomerInvoice_SelectTimeMonthlyMinutes_Label_Xpath, "MINUTES");
            Verifytext(attributeName_xpath, CustomerInvoice_SelectTimeMonthlyAM_Label_Xpath, "AM");
            Verifytext(attributeName_xpath, CustomerInvoice_SelectTimeMonthlyPM_Label_Xpath, "PM");
        }

        [Then(@"I am required to select the time")]
        public void ThenIAmRequiredToSelectTheTime()
        {
            string getMonths = Gettext(attributeName_xpath, CustomerInvoice_SelectSelectTimeLabelMonthly_DropDown_Xpath);
            if (getMonths.Contains("*"))
            {
                Report.WriteLine("SELECT TIME is required field");
            }
        }


        [Then(@"I have the option to select the Weekly Time Period tab")]
        public void ThenIHaveTheOptionToSelectTheWeeklyTimePeriodTab()
        {
            Verifytext(attributeName_xpath, CustomerInvoice_WeeklyTab_Xpath, "WEEKLY");
        }


        [Then(@"I will see a chronological list of months")]
        public void ThenIWillSeeAChronologicalListOfMonths()
        {
            Verifytext(attributeName_xpath, CustomerInvoice_MonthlyTab_Xpath, "MONTHLY");
            IList<IWebElement> value=GlobalVariables.webDriver.FindElements(By.XPath("//div[@id='Tab_tabMonthly']//div[@class='checkbox month inline-element']"));
            List<string> rows = new List<string>();
            for (int i = 0; i < value.Count; i++) {
                string data = value[i].Text;
                data.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
                rows.Add(data);
            }
            List<string> expectedWeekDropDownOptions = new List<string>
           {
               "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"
              
           };

            CollectionAssert.AreEqual(rows, expectedWeekDropDownOptions);
        }

        [Then(@"by default all of the months are selected")]
        public void ThenByDefaultAllOfTheMonthsAreSelected()
        {
            VerifyElementChecked(attributeName_xpath, CustomerInvoice_JanuaryCheckbox_Xpath, "January");
            VerifyElementChecked(attributeName_xpath, CustomerInvoice_FebuaryCheckbox_Xpath, "February");
            VerifyElementChecked(attributeName_xpath, CustomerInvoice_MarchCheckbox_Xpath, "March");
            VerifyElementChecked(attributeName_xpath, CustomerInvoice_AprilCheckbox_Xpath, "April");
            VerifyElementChecked(attributeName_xpath, CustomerInvoice_MayCheckbox_Xpath, "May");
            VerifyElementChecked(attributeName_xpath, CustomerInvoice_JuneCheckbox_Xpath, "June");
            VerifyElementChecked(attributeName_xpath, CustomerInvoice_JulyCheckbox_Xpath, "July");
            VerifyElementChecked(attributeName_xpath, CustomerInvoice_AugustCheckbox_Xpath, "August");
            VerifyElementChecked(attributeName_xpath, CustomerInvoice_SeptemberCheckbox_Xpath, "September");
            VerifyElementChecked(attributeName_xpath, CustomerInvoice_OctoberCheckbox_Xpath, "October");
            VerifyElementChecked(attributeName_xpath, CustomerInvoice_NovemberCheckbox_Xpath, "November");
            VerifyElementChecked(attributeName_xpath, CustomerInvoice_DecemberCheckbox_Xpath, "December");
        }

        [Then(@"I have the option to deselect months")]
        public void ThenIHaveTheOptionToDeselectMonths()
        {
            //Diselect check box and verify 
            Click(attributeName_xpath, CustomerInvoice_JanuaryCheckbox_Label_Xpath);
            VerifyElementNotChecked(attributeName_xpath, CustomerInvoice_JanuaryCheckbox_Xpath, "January");

            Click(attributeName_xpath, CustomerInvoice_FebuaryCheckbox_Label_Xpath);
            VerifyElementNotChecked(attributeName_xpath, CustomerInvoice_FebuaryCheckbox_Xpath, "February");

            Click(attributeName_xpath, CustomerInvoice_MarchCheckbox_Label_Xpath);
            VerifyElementNotChecked(attributeName_xpath, CustomerInvoice_MarchCheckbox_Xpath, "March");

            Click(attributeName_xpath, CustomerInvoice_AprilCheckbox_Label_Xpath);
            VerifyElementNotChecked(attributeName_xpath, CustomerInvoice_AprilCheckbox_Xpath, "April");

            Click(attributeName_xpath, CustomerInvoice_MayCheckbox_Label_Xpath);
            VerifyElementNotChecked(attributeName_xpath, CustomerInvoice_MayCheckbox_Xpath, "May");

            Click(attributeName_xpath, CustomerInvoice_JuneCheckbox_Label_Xpath);
            VerifyElementNotChecked(attributeName_xpath, CustomerInvoice_JuneCheckbox_Xpath, "June");

            Click(attributeName_xpath, CustomerInvoice_JulyCheckbox_Label_Xpath);
            VerifyElementNotChecked(attributeName_xpath, CustomerInvoice_JulyCheckbox_Xpath, "July");

            Click(attributeName_xpath, CustomerInvoice_AugustCheckbox_Label_Xpath);
            VerifyElementNotChecked(attributeName_xpath, CustomerInvoice_AugustCheckbox_Xpath, "August");

            Click(attributeName_xpath, CustomerInvoice_SeptemberCheckbox_Label_Xpath);
            VerifyElementNotChecked(attributeName_xpath, CustomerInvoice_SeptemberCheckbox_Xpath, "September");

            Click(attributeName_xpath, CustomerInvoice_OctoberCheckbox_Label_Xpath);
            VerifyElementNotChecked(attributeName_xpath, CustomerInvoice_OctoberCheckbox_Xpath, "October");

            Click(attributeName_xpath, CustomerInvoice_NovemberCheckbox_Label_Xpath);
            VerifyElementNotChecked(attributeName_xpath, CustomerInvoice_NovemberCheckbox_Xpath, "November");

            Click(attributeName_xpath, CustomerInvoice_DecemberCheckbox_Label_Xpath);
            VerifyElementNotChecked(attributeName_xpath, CustomerInvoice_DecemberCheckbox_Xpath, "December");
        }

        [Then(@"I have the option to select months")]
        public void ThenIHaveTheOptionToSelectMonths()
        {
            Click(attributeName_xpath, CustomerInvoice_JanuaryCheckbox_Label_Xpath);
            VerifyElementChecked(attributeName_xpath, CustomerInvoice_JanuaryCheckbox_Xpath, "January");

            Click(attributeName_xpath, CustomerInvoice_FebuaryCheckbox_Label_Xpath);
            VerifyElementChecked(attributeName_xpath, CustomerInvoice_FebuaryCheckbox_Xpath , "February");

            Click(attributeName_xpath, CustomerInvoice_MarchCheckbox_Label_Xpath);
            VerifyElementChecked(attributeName_xpath, CustomerInvoice_MarchCheckbox_Xpath, "March");

            Click(attributeName_xpath, CustomerInvoice_AprilCheckbox_Label_Xpath);
            VerifyElementChecked(attributeName_xpath, CustomerInvoice_AprilCheckbox_Xpath , "April");

            Click(attributeName_xpath, CustomerInvoice_MayCheckbox_Label_Xpath);
            VerifyElementChecked(attributeName_xpath, CustomerInvoice_MayCheckbox_Xpath, "May");

            Click(attributeName_xpath, CustomerInvoice_JuneCheckbox_Label_Xpath);
            VerifyElementChecked(attributeName_xpath, CustomerInvoice_JuneCheckbox_Xpath, "June");

            Click(attributeName_xpath, CustomerInvoice_JulyCheckbox_Label_Xpath);
            VerifyElementChecked(attributeName_xpath, CustomerInvoice_JulyCheckbox_Xpath,  "July");

            Click(attributeName_xpath, CustomerInvoice_AugustCheckbox_Label_Xpath);
            VerifyElementChecked(attributeName_xpath, CustomerInvoice_AugustCheckbox_Xpath, "August");

            Click(attributeName_xpath, CustomerInvoice_SeptemberCheckbox_Label_Xpath);
            VerifyElementChecked(attributeName_xpath, CustomerInvoice_SeptemberCheckbox_Xpath, "September");

            Click(attributeName_xpath, CustomerInvoice_OctoberCheckbox_Label_Xpath);
            VerifyElementChecked(attributeName_xpath, CustomerInvoice_OctoberCheckbox_Xpath, "October");

            Click(attributeName_xpath, CustomerInvoice_NovemberCheckbox_Label_Xpath);
            VerifyElementChecked(attributeName_xpath, CustomerInvoice_NovemberCheckbox_Xpath, "November");

            Click(attributeName_xpath, CustomerInvoice_DecemberCheckbox_Label_Xpath);
            VerifyElementChecked(attributeName_xpath, CustomerInvoice_DecemberCheckbox_Xpath, "December");
        }

        [Then(@"I have option to select the week of the month or specific day of the month")]
        public void ThenIHaveOptionToSelectTheWeekOfTheMonthOrSpecificDayOfTheMonth()
        {
            IsElementPresent(attributeName_xpath, CustomerInvoice_SelectDayMonthlyWeeks_RadioButton_Xpath, "Select Day week option");

            IsElementPresent(attributeName_xpath, CustomerInvoice_SelectSpecificDayOfMonth_DropDown_Xpath, "Select Day specific day option");
        }


        [Then(@"I have the option to select week option from the drop down list (.*)")]
        public void ThenIHaveTheOptionToSelectWeekOptionFromTheDropDownList(string p0)
        {

           
            string defaultValue = Gettext(attributeName_xpath, "//div[@id='MonthlyWeek_chosen']/a/span");
            string expecteddefaultValue = "1st";
            Assert.AreEqual(expecteddefaultValue, defaultValue);


            Click(attributeName_xpath, CustomerInvoice_SelectDayMonthlyWeek_DropDown_Xpath);
            IList<IWebElement> weekUI_List = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoice_SelectDayMonthlyWeek_DropDownValues_Xpath));
            List<string> actualWeekUI_List = weekUI_List.Select(c => c.Text).ToList();
            List<string> expectedWeekDropDownOptions = new List<string>
           {
               "1st", "2nd", "3rd", "4th"
           };
            CollectionAssert.AreEqual(actualWeekUI_List, expectedWeekDropDownOptions);
            
        }

        [Then(@"I have the option to select a day with options (.*)")]
        public void ThenIHaveTheOptionToSelectADayWithOptions(string p0)
        {
            string defaultValue = Gettext(attributeName_xpath, CustomerInvoice_SelectDayMonthlyWeekDay_DropDown_Xpath);
           
            string expecteddefaultValue = "Sunday";
            Assert.AreEqual(expecteddefaultValue, defaultValue);

            Click(attributeName_xpath, CustomerInvoice_SelectDayMonthlyWeekDay_DropDown_Xpath);
            IList<IWebElement> weekDayUI_List = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoice_SelectDayMonthlyWeekDay_DropDownValues_Xpath));
            List<string> actualWeekDayUI_List = weekDayUI_List.Select(c => c.Text).ToList();
            List<string> expectedWeekDayDropDownOptions = new List<string>
           {
               "Sunday","Monday","Tuesday","Wednesday","Thursday","Friday","Saturday"
           };
            CollectionAssert.AreEqual(actualWeekDayUI_List, expectedWeekDayDropDownOptions);
        }

        [Then(@"I have the option to select the day beginning with (.*) and ending with (.*) and (.*) will be defaulted")]
        public void ThenIHaveTheOptionToSelectTheDayBeginningWithAndEndingWithAndWillBeDefaulted(string p0, string p1, string p2)
        {
          
            IWebElement element = GlobalVariables.webDriver.FindElement(By.XPath("//label[@for='radioBtnMonthlyTypeDays']"));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)GlobalVariables.webDriver;
            executor.ExecuteScript("arguments[0].click();", element);
           
            string defaultValue = GetAttribute(attributeName_xpath, CustomerInvoice_SelectSpecificDayOfMonth_DropDown_Xpath, "value");
            string expecteddefaultValue = "1";
            Assert.AreEqual(expecteddefaultValue, defaultValue);

           
            List<string> actualDayUI_List = new List<string>();
            for (int i = 1; i < 32; i++)
            {
               
                string value= GetAttribute(attributeName_xpath, CustomerInvoice_SelectSpecificDayOfMonth_DropDown_Xpath, "value");
                actualDayUI_List.Add(value);
                Click(attributeName_id, "upArrowMonthlyDays");

            }

            if (Convert.ToInt32(actualDayUI_List[30]) == 31)
            {
                Report.WriteFailure("User able to select more than 30 days in a month");
                
            }
            else
            {
                actualDayUI_List.Remove(actualDayUI_List[30]);
            }
           
            List<string> expectedDayDropDownOptions = new List<string>
           {
               "1","2","3","4","5","6","7", "8","9","10","11","12","13","14","15","16","17","18","19","20","21","22","23","24","25","26","27","28","29","30"
           };
            CollectionAssert.AreEqual(actualDayUI_List, expectedDayDropDownOptions);
        }

        [Then(@"I have the option to Select Time section with Hours(.*)")]
        public void ThenIHaveTheOptionToSelectTimeSectionWithHours(string p0)
        {
            Click(attributeName_xpath, CustomerInvoice_SelectTimeMonthlyHours_DropDown_Xpath);
            IList<IWebElement> hoursUI_List = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoice_SelectTimeMonthlyHours_DropDownValues_Xpath));
            List<string> actualHoursUI_List = hoursUI_List.Skip(1).Select(c => c.Text).ToList();
            List<string> expectedHoursDropDownOptions = new List<string>
           {
               "01","02","03","04","05","06","07", "08","09","10","11","12"
           };
            CollectionAssert.AreEqual(actualHoursUI_List, expectedHoursDropDownOptions);
        }

        [Then(@"I have the option to see a Minutes (.*)")]
        public void ThenIHaveTheOptionToSeeAMinutes(string p0)
        {
            Click(attributeName_xpath, CustomerInvoice_SelectTimeMonthlyMinutes_DropDown_Xpath);
            IList<IWebElement> minutesUI_List = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoice_SelectTimeMonthlyMinutes_DropDownValues_Xpath));
            List<string> actualMinutesUI_List = minutesUI_List.Skip(1).Select(c => c.Text).ToList();
            List<string> expectedMinutesDropDownOptions = new List<string>
           {
               "00","15","30","45"
           };
            CollectionAssert.AreEqual(actualMinutesUI_List, expectedMinutesDropDownOptions);
        }

        [Then(@"I have the option to see AM/PM radio button with AM as default selected value")]
        public void ThenIHaveTheOptionToSeeAMPMRadioButtonWithAMAsDefaultSelectedValue()
        {
            IsElementPresent(attributeName_id, CustomerInvoice_SelectTimeMonthlyAM_Label_Xpath, "AM");

            IsElementPresent(attributeName_id, CustomerInvoice_SelectTimeMonthlyPM_Label_Xpath, "PM");

         
            IWebElement am = GlobalVariables.webDriver.FindElement(By.XPath(CustomerInvoice_SelectTimeMonthlyAM_Button_Xpath));
            if (am.Selected)
            {
                Report.WriteLine("Radio button is selected defaultly");
            }
            else
            {
                Report.WriteFailure("Radio button is not selected defaultly");
            }
        }

        


        [Then(@"I will receive a error message (.*)")]
        public void ThenIWillReceiveAErrorMessage(string p0)
        {
            element = GlobalVariables.webDriver.FindElement(By.CssSelector("#toEmail"));
            string toEmail = element.GetCssValue("background-image");
            if (toEmail.Contains("rgb(251, 236, 236)"))
            {
                Report.WriteLine("background is highlighted in red");

            }
            else
            {
                Report.WriteFailure("background is not highlighted in red");
            }

            //element = GlobalVariables.webDriver.FindElement(By.CssSelector(CustomerInvoice_SelectTimeMonthlyHours_DropDown_Xpath));
            //string monthyHours = element.GetCssValue("background");
            //if (monthyHours.Contains("rgb(251, 236, 236)"))
            //{
            //    Report.WriteLine("background is highlighted in red");

            //}
            //else
            //{
            //    Report.WriteFailure("background is not highlighted in red");
            //}

            //element = GlobalVariables.webDriver.FindElement(By.XPath(CustomerInvoice_SelectTimeMonthlyHours_DropDown_Xpath));
            //string monthyMinute = element.GetCssValue("background-image");
            //if (monthyMinute.Contains("rgb(251, 236, 236)"))
            //{
            //    Report.WriteLine("background is highlighted in red");

            //}
            //else
            //{
            //    Report.WriteFailure("background is not highlighted in red");
            //}


            Verifytext(attributeName_xpath, CustomerInvoice_ValidationErrorMessage_Xpath, "Please enter all required information");

            
          
        }

        [Then(@"the page will focus to the first field that is missing required information")]
        public void ThenThePageWillFocusToTheFirstFieldThatIsMissingRequiredInformation()
        {
            // WaitForElementVisible(attributeName_xpath, CustomerInvoice_SelectSelectTimeLabelMonthly_DropDown_Xpath, "SELECT TIME *");

            //Click(attributeName_xpath, CustomerInvoice_SelectTimeMonthlyHours_DropDown_Xpath);
            //Click(attributeName_xpath, "//div[@id='monthlyhours_chosen']//div[@class='chosen-drop']//li[2]");



            //Click(attributeName_xpath, CustomerInvoice_SelectTimeMonthlyMinutes_DropDown_Xpath);
            //Click(attributeName_xpath, "//div[@id='monthlyminutes_chosen']//li[2]");

            //Click(attributeName_xpath, schedulePageScheduleReportButton_Xpath);

            //string minutesValue = GetValue(attributeName_id, "minutes_chosen", "value");
            //bool valueMinutes = CrmLogin.VerifyFocus(minutesValue, "minutes_chosen");
            //if (valueMinutes)
            //{
            //    Report.WriteLine("Field is auto focused");
            //}
            //else
            //{
            //    Report.WriteFailure("Field is not auto focused");
            //}

            //string hoursValue = GetValue(attributeName_id, "hours_chosen", "value");
            //bool valueHours = CrmLogin.VerifyFocus(hoursValue, "hours_chosen");
            //if (valueHours)
            //{
            //    Report.WriteLine("Field is auto focused");
            //}
            //else
            //{
            //    Report.WriteFailure("Field is not auto focused");
            //}

            //string toMailValue = GetValue(attributeName_id, "toEmail", "value");
            //bool valueToMail= CrmLogin.VerifyFocus(toMailValue, "toEmail");
            //if (valueToMail)
            //{
            //    Report.WriteLine("Field is auto focused");
            //}
            //else
            //{
            //    Report.WriteFailure("Field is not auto focused");
            //}

            


        }


    }
}
