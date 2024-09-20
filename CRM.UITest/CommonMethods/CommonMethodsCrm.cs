
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace CRM.UITest.CommonMethods
{
    public class CommonMethodsCrm : AddShipments
    {
        public string SelectionCheck_CMorMeter;
        public string DefaultCheck_CMandMeter;

        string scheduledYear;
        DateTime incrementedScheduledYear;
        int scheduledYearInteger;
        string nextRunDate;
        List<string> checkRunDate = new List<string>();


        #region Login
        public void LoginToCRMApplication(string Username, string Password)
        {
            DefineTimeOut(120000);
            Report.WriteLine("Launch URL");
            LaunchURL();

            GlobalVariables.webDriver.WaitForPageLoad();
            
            bool visible = IsElementPresent(attributeName_xpath, ".//*[@id='cookiescript_accept']","cookie");
            
            if ( visible == true) {
                Click(attributeName_xpath, ".//*[@id='cookiescript_accept']");
            }
            
            Report.WriteLine("Land on Homepage");

            Click(attributeName_id, SignIn_Id);
            Report.WriteLine("Enter valid Username and Password and click on Log in");
            WaitForElementVisible(attributeName_id, IDP_Username_Id, "UserName");
            SendKeys(attributeName_id, IDP_Username_Id, Username);
            SendKeys(attributeName_id, IDP_Password_Id, Password);

            try
            {
                Click(attributeName_xpath, IDP_Login_Xpath);

                if(GlobalVariables.webDriver is FirefoxDriver)
                {
                    Thread.Sleep(1000);
                    GlobalVariables.webDriver.SwitchTo().Alert().Accept();
                    GlobalVariables.webDriver.WaitForPageLoad();

                    if(IsElementPresent(attributeName_id, Loading_Icon_Id, "Loading icon"))
                    {
                        WaitForElementNotVisible(attributeName_id, Loading_Icon_Id, "loading icon");
                    }
                }
            }
            catch
            {
                GlobalVariables.webDriver.WaitForPageLoad();
                WaitForElementNotVisible(attributeName_id, Loading_Icon_Id, "loading icon");
            }
        }

        #endregion Login


        public void Login_CRMApplication(string Username, string Password)
        {
            DefineTimeOut(600000);            
            Report.WriteLine("Land on Homepage");
            Click(attributeName_id, SignIn_Id);
            Report.WriteLine("Enter valid Username and Password and click on Log in");
            WaitForElementVisible(attributeName_id, IDP_Username_Id, "UserName");
            SendKeys(attributeName_id, IDP_Username_Id, Username);
            SendKeys(attributeName_id, IDP_Password_Id, Password);
            try
            {
                Click(attributeName_xpath, IDP_Login_Xpath);
            }
            catch
            {
                GlobalVariables.webDriver.WaitForPageLoad();
            }
        }



        #region AutoFocus
        public Boolean IsElementFocused(string Id)
        {
            IWebElement _activeElement = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            string ElementId = _activeElement.GetAttribute("id");
            return ElementId.Equals(Id);
        }

        public Boolean VerifyFocus(string element, string elementId)
        {
            bool value = false;
            if (string.IsNullOrEmpty(element))
            {
                if (IsElementFocused(elementId))
                {
                    value = true;
                }
            }
            return value;
        }


        #endregion AutoFocus


        public List<string> yearSelectionBasedOnSpecificMonth(string month, string specificDay,  string hours, string minutes, string meridiem)
        {
            List<string> g = new List<string>();
            


            string monthTrimmed = month.Substring(0, 3);
            var datetimeCST = TimeZoneInfo.ConvertTime((DateTime.Now), TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time"));
            int _currentMonthInteger = Convert.ToInt32(datetimeCST.Month.ToString("00"));
            DateTime _month = DateTime.ParseExact(monthTrimmed, "MMM", CultureInfo.InvariantCulture);
            int numericMonth = _month.Month;

            if (numericMonth > _currentMonthInteger)
            {
                scheduledYear = datetimeCST.Year.ToString();

                int integerSpecday = Convert.ToInt32(specificDay);
                if (numericMonth == 2 && ((integerSpecday == 29) || (integerSpecday == 30) || (integerSpecday == 31)))
                {
                    specificDay = "28";
                }

                int SpecDay = Convert.ToInt32(specificDay);
                if (((numericMonth >= 0) && (numericMonth <= 9)) && ((SpecDay >= 0) && (SpecDay <= 9)))
                {
                    numericMonth.ToString();
                    nextRunDate = ("0" + numericMonth).ToString() + "/" + ("0" + SpecDay).ToString() + "/" + scheduledYear;
                }
                else if (((numericMonth >= 0) && (numericMonth <= 9)) && !((SpecDay >= 0) && (SpecDay <= 9)))
                {
                    numericMonth.ToString();
                    nextRunDate = ("0" + numericMonth).ToString() + "/" + (SpecDay).ToString() + "/" + scheduledYear;
                }
                else if (((SpecDay >= 0) && (SpecDay <= 9)) && !((numericMonth >= 0) && (numericMonth <= 9)))
                {
                    nextRunDate = (numericMonth).ToString() + "/" + ("0" + SpecDay).ToString() + "/" + scheduledYear;
                }
                else
                {
                    nextRunDate = numericMonth.ToString() + "/" + specificDay + "/" + scheduledYear;
                }

                checkRunDate.Add(nextRunDate);
            }

            if (numericMonth < _currentMonthInteger)
            {
                incrementedScheduledYear = datetimeCST.AddYears(1);
                scheduledYearInteger = Convert.ToInt32(incrementedScheduledYear.Year);
                scheduledYear = scheduledYearInteger.ToString();

                int integerSpecday = Convert.ToInt32(specificDay);
                if (numericMonth == 2 && ((integerSpecday == 29) || (integerSpecday == 30) || (integerSpecday == 31)))
                {
                    specificDay = "28";
                }

                int SpecDay = Convert.ToInt32(specificDay);
                if (((numericMonth >= 0) && (numericMonth <= 9)) && ((SpecDay >= 0) && (SpecDay <= 9)))
                {
                    numericMonth.ToString();
                    nextRunDate = ("0" + numericMonth).ToString() + "/" + ("0" + SpecDay).ToString() + "/" + scheduledYear;
                }
                else if (((numericMonth >= 0) && (numericMonth <= 9)) && !((SpecDay >= 0) && (SpecDay <= 9)))
                {
                    numericMonth.ToString();
                    nextRunDate = ("0" + numericMonth).ToString() + "/" + (SpecDay).ToString() + "/" + scheduledYear;
                }
                else if (((SpecDay >= 0) && (SpecDay <= 9)) && !((numericMonth >= 0) && (numericMonth <= 9)))
                {
                    nextRunDate = (numericMonth).ToString() + "/" + ("0" + SpecDay).ToString() + "/" + scheduledYear;
                }
                else
                {
                    nextRunDate = numericMonth.ToString() + "/" + specificDay + "/" + scheduledYear;
                }

                checkRunDate.Add(nextRunDate);
            }


            if (numericMonth == _currentMonthInteger)
            {
                int specDay = Convert.ToInt32(specificDay);
                var datetime = datetimeCST;
                int currentDay = datetime.Day;
                if (specDay < currentDay)
                {
                    incrementedScheduledYear = datetimeCST.AddYears(1);
                    scheduledYearInteger = Convert.ToInt32(incrementedScheduledYear.Year);
                    scheduledYear = scheduledYearInteger.ToString();

                    int integerSpecday = Convert.ToInt32(specificDay);
                    if (numericMonth == 2 && ((integerSpecday == 29) || (integerSpecday == 30) || (integerSpecday == 31)))
                    {
                        specificDay = "28";
                    }

                    int SpecDay = Convert.ToInt32(specificDay);
                    if (((numericMonth >= 0) && (numericMonth <= 9)) && ((SpecDay >= 0) && (SpecDay <= 9)))
                    {
                        numericMonth.ToString();
                        nextRunDate = ("0" + numericMonth).ToString() + "/" + ("0" + SpecDay).ToString() + "/" + scheduledYear;
                    }
                    else if (((numericMonth >= 0) && (numericMonth <= 9)) && !((SpecDay >= 0) && (SpecDay <= 9)))
                    {
                        numericMonth.ToString();
                        nextRunDate = ("0" + numericMonth).ToString() + "/" + (SpecDay).ToString() + "/" + scheduledYear;
                    }
                    else if (((SpecDay >= 0) && (SpecDay <= 9)) && !((numericMonth >= 0) && (numericMonth <= 9)))
                    {
                        nextRunDate = (numericMonth).ToString() + "/" + ("0" + SpecDay).ToString() + "/" + scheduledYear;
                    }
                    else
                    {
                        nextRunDate = numericMonth.ToString() + "/" + specificDay + "/" + scheduledYear;
                    }

                    checkRunDate.Add(nextRunDate);
                }
                if (specDay > currentDay)
                {
                    scheduledYear = datetimeCST.Year.ToString();

                    int integerSpecday = Convert.ToInt32(specificDay);
                    if (numericMonth == 2 && ((integerSpecday == 29) || (integerSpecday == 30) || (integerSpecday == 31)))
                    {
                        specificDay = "28";
                    }

                    int SpecDay = Convert.ToInt32(specificDay);
                    if (((numericMonth >= 0) && (numericMonth <= 9)) && ((SpecDay >= 0) && (SpecDay <= 9)))
                    {
                        numericMonth.ToString();
                        nextRunDate = ("0" + numericMonth).ToString() + "/" + ("0" + SpecDay).ToString() + "/" + scheduledYear;
                    }
                    else if (((numericMonth >= 0) && (numericMonth <= 9)) && !((SpecDay >= 0) && (SpecDay <= 9)))
                    {
                        numericMonth.ToString();
                        nextRunDate = ("0" + numericMonth).ToString() + "/" + (SpecDay).ToString() + "/" + scheduledYear;
                    }
                    else if (((SpecDay >= 0) && (SpecDay <= 9)) && !((numericMonth >= 0) && (numericMonth <= 9)))
                    {
                        nextRunDate = (numericMonth).ToString() + "/" + ("0" + SpecDay).ToString() + "/" + scheduledYear;
                    }
                    else
                    {
                        nextRunDate = numericMonth.ToString() + "/" + specificDay + "/" + scheduledYear;
                    }

                    checkRunDate.Add(nextRunDate);
                }
                if (specDay == currentDay)
                {
                    DateTime _currentTime = datetimeCST;
                    var _currentTimeCheck = _currentTime.ToString("hh:mm tt");
                    DateTime currentTime = Convert.ToDateTime(_currentTimeCheck);
                    var timeFormatBefore = hours + ":" + minutes + meridiem;
                    DateTime timeFormatAfter = Convert.ToDateTime(timeFormatBefore);
                    int dt = DateTime.Compare(currentTime, timeFormatAfter);
                    if (dt <= 0)
                    {
                        scheduledYear = datetimeCST.Year.ToString();
                        int integerSpecday = Convert.ToInt32(specificDay);
                        if (numericMonth == 2 && ((integerSpecday == 29) || (integerSpecday == 30) || (integerSpecday == 31)))
                        {
                            specificDay = "28";
                        }

                        int SpecDay = Convert.ToInt32(specificDay);
                        if (((numericMonth >= 0) && (numericMonth <= 9)) && ((SpecDay >= 0) && (SpecDay <= 9)))
                        {
                            numericMonth.ToString();
                            nextRunDate = ("0" + numericMonth).ToString() + "/" + ("0" + SpecDay).ToString() + "/" + scheduledYear;
                        }
                        else if (((numericMonth >= 0) && (numericMonth <= 9)) && !((SpecDay >= 0) && (SpecDay <= 9)))
                        {
                            numericMonth.ToString();
                            nextRunDate = ("0" + numericMonth).ToString() + "/" + (SpecDay).ToString() + "/" + scheduledYear;
                        }
                        else if (((SpecDay >= 0) && (SpecDay <= 9)) && !((numericMonth >= 0) && (numericMonth <= 9)))
                        {
                            nextRunDate = (numericMonth).ToString() + "/" + ("0" + SpecDay).ToString() + "/" + scheduledYear;
                        }
                        else
                        {
                            nextRunDate = numericMonth.ToString() + "/" + specificDay + "/" + scheduledYear;
                        }
                        checkRunDate.Add(nextRunDate);
                    }
                    else
                    {
                        incrementedScheduledYear = datetimeCST.AddYears(1);
                        scheduledYearInteger = Convert.ToInt32(incrementedScheduledYear.Year);
                        scheduledYear = scheduledYearInteger.ToString();

                        int integerSpecday = Convert.ToInt32(specificDay);
                        if (numericMonth == 2 && ((integerSpecday == 29) || (integerSpecday == 30) || (integerSpecday == 31)))
                        {
                            specificDay = "28";
                        }

                        int SpecDay = Convert.ToInt32(specificDay);
                        if (((numericMonth >= 0) && (numericMonth <= 9)) && ((SpecDay >= 0) && (SpecDay <= 9)))
                        {
                            numericMonth.ToString();
                            nextRunDate = ("0" + numericMonth).ToString() + "/" + ("0" + SpecDay).ToString() + "/" + scheduledYear;
                        }
                        else if (((numericMonth >= 0) && (numericMonth <= 9)) && !((SpecDay >= 0) && (SpecDay <= 9)))
                        {
                            numericMonth.ToString();
                            nextRunDate = ("0" + numericMonth).ToString() + "/" + (SpecDay).ToString() + "/" + scheduledYear;
                        }
                        else if (((SpecDay >= 0) && (SpecDay <= 9)) && !((numericMonth >= 0) && (numericMonth <= 9)))
                        {
                            nextRunDate = (numericMonth).ToString() + "/" + ("0" + SpecDay).ToString() + "/" + scheduledYear;
                        }
                        else
                        {
                            nextRunDate = numericMonth.ToString() + "/" + specificDay + "/" + scheduledYear;
                        }

                        checkRunDate.Add(nextRunDate);


                    }
                }

            }

            checkRunDate.Add(nextRunDate);
            return checkRunDate;

        }

        public List<string> yearSelectionBasedOnAllMonth(string month, string specificDay, string hours, string minutes, string meridiem)
        {
            month = "January";

            string monthTrimmed = month.Substring(0, 3);
            var datetimeCST = TimeZoneInfo.ConvertTime((DateTime.Now), TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time"));
            int _currentMonthInteger = Convert.ToInt32(datetimeCST.Month.ToString("00"));

            DateTime _month = DateTime.ParseExact(monthTrimmed, "MMM", CultureInfo.InvariantCulture);
            int numericMonth = _month.Month;

            if (numericMonth < _currentMonthInteger)
            {
                numericMonth = numericMonth + 1;
                if (numericMonth < _currentMonthInteger)
                {
                    numericMonth = numericMonth + 1;
                    if (numericMonth < _currentMonthInteger)
                    {
                        numericMonth = numericMonth + 1;
                        if (numericMonth < _currentMonthInteger)
                        {
                            numericMonth = numericMonth + 1;
                            if (numericMonth < _currentMonthInteger)
                            {
                                numericMonth = numericMonth + 1;
                                if (numericMonth < _currentMonthInteger)
                                {
                                    numericMonth = numericMonth + 1;
                                    if (numericMonth < _currentMonthInteger)
                                    {
                                        numericMonth = numericMonth + 1;
                                        if (numericMonth < _currentMonthInteger)
                                        {
                                            numericMonth = numericMonth + 1;
                                            if (numericMonth < _currentMonthInteger)
                                            {
                                                numericMonth = numericMonth + 1;
                                                if (numericMonth < _currentMonthInteger)
                                                {
                                                    numericMonth = numericMonth + 1;
                                                    if (numericMonth < _currentMonthInteger)
                                                    {
                                                        numericMonth = numericMonth + 1;
                                                        if (numericMonth < _currentMonthInteger)
                                                        {
                                                            incrementedScheduledYear = DateTime.Now.AddYears(1);
                                                            scheduledYearInteger = Convert.ToInt32(incrementedScheduledYear.Year);
                                                            scheduledYear = scheduledYearInteger.ToString();
                                                            nextRunDate = numericMonth.ToString() + "/" + specificDay + "/" + scheduledYear;
                                                            checkRunDate.Add(nextRunDate);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (numericMonth > _currentMonthInteger)
            {
                scheduledYear = datetimeCST.Year.ToString();
                int integerSpecday = Convert.ToInt32(specificDay);
                if (numericMonth == 2 && ((integerSpecday == 29) || (integerSpecday == 30) || (integerSpecday == 31)))
                {
                    specificDay = "28";
                }
                int SpecDay = Convert.ToInt32(specificDay);
                if (((numericMonth >= 0) && (numericMonth <= 9)) && ((SpecDay >= 0) && (SpecDay <= 9)))
                {
                    numericMonth.ToString();
                    nextRunDate = ("0" + numericMonth).ToString() + "/" + ("0" + SpecDay).ToString() + "/" + scheduledYear;
                }
                else if (((numericMonth >= 0) && (numericMonth <= 9)) && !((SpecDay >= 0) && (SpecDay <= 9)))
                {
                    numericMonth.ToString();
                    nextRunDate = ("0" + numericMonth).ToString() + "/" + (SpecDay).ToString() + "/" + scheduledYear;
                }
                else if (((SpecDay >= 0) && (SpecDay <= 9)) && !((numericMonth >= 0) && (numericMonth <= 9)))
                {
                    nextRunDate = (numericMonth).ToString() + "/" + ("0" + SpecDay).ToString() + "/" + scheduledYear;
                }
                else
                {
                    nextRunDate = numericMonth.ToString() + "/" + specificDay + "/" + scheduledYear;
                }
                checkRunDate.Add(nextRunDate);
            }

            if (numericMonth == _currentMonthInteger)
            {
                int specDay = Convert.ToInt32(specificDay);
                int currentDay = datetimeCST.Day;
                if (specDay < currentDay)
                {
                    numericMonth = numericMonth + 1;
                    scheduledYear = datetimeCST.Year.ToString();
                    if (numericMonth >= 12)
                    {
                        incrementedScheduledYear = datetimeCST.AddYears(1);
                        scheduledYearInteger = Convert.ToInt32(incrementedScheduledYear.Year);
                        scheduledYear = scheduledYearInteger.ToString();
                        numericMonth = 1;
                    }
                    int integerSpecday = Convert.ToInt32(specificDay);
                    if (numericMonth == 2 && ((integerSpecday == 29) || (integerSpecday == 30) || (integerSpecday == 31)))
                    {
                        specificDay = "28";
                    }
                    int SpecDay = Convert.ToInt32(specificDay);
                    if (((numericMonth >= 0) && (numericMonth <= 9)) && ((SpecDay >= 0) && (SpecDay <= 9)))
                    {
                        numericMonth.ToString();
                        nextRunDate = ("0" + numericMonth).ToString() + "/" + ("0" + SpecDay).ToString() + "/" + scheduledYear;
                    }
                    else if (((numericMonth >= 0) && (numericMonth <= 9)) && !((SpecDay >= 0) && (SpecDay <= 9)))
                    {
                        numericMonth.ToString();
                        nextRunDate = ("0" + numericMonth).ToString() + "/" + (SpecDay).ToString() + "/" + scheduledYear;
                    }
                    else if (((SpecDay >= 0) && (SpecDay <= 9)) && !((numericMonth >= 0) && (numericMonth <= 9)))
                    {
                        nextRunDate = (numericMonth).ToString() + "/" + ("0" + SpecDay).ToString() + "/" + scheduledYear;
                    }
                    else
                    {
                        nextRunDate = numericMonth.ToString() + "/" + specificDay + "/" + scheduledYear;
                    }
                    checkRunDate.Add(nextRunDate);
                }

                if (specDay > currentDay)
                {
                    scheduledYear = datetimeCST.Year.ToString();
                    int integerSpecday = Convert.ToInt32(specificDay);
                    if (numericMonth == 2 && ((integerSpecday == 29) || (integerSpecday == 30) || (integerSpecday == 31)))
                    {
                        specificDay = "28";
                    }
                    int SpecDay = Convert.ToInt32(specificDay);
                    if (((numericMonth >= 0) && (numericMonth <= 9)) && ((SpecDay >= 0) && (SpecDay <= 9)))
                    {
                        numericMonth.ToString();
                        nextRunDate = ("0" + numericMonth).ToString() + "/" + ("0" + SpecDay).ToString() + "/" + scheduledYear;
                    }
                    else if (((numericMonth >= 0) && (numericMonth <= 9)) && !((SpecDay >= 0) && (SpecDay <= 9)))
                    {
                        numericMonth.ToString();
                        nextRunDate = ("0" + numericMonth).ToString() + "/" + (SpecDay).ToString() + "/" + scheduledYear;
                    }
                    else if (((SpecDay >= 0) && (SpecDay <= 9)) && !((numericMonth >= 0) && (numericMonth <= 9)))
                    {
                        nextRunDate = (numericMonth).ToString() + "/" + ("0" + SpecDay).ToString() + "/" + scheduledYear;
                    }
                    else
                    {
                        nextRunDate = numericMonth.ToString() + "/" + specificDay + "/" + scheduledYear;
                    }
                    checkRunDate.Add(nextRunDate);
                }
                if (specDay == currentDay)
                {
                    DateTime _currentTime = datetimeCST;
                    var _currentTimeCheck = _currentTime.ToString("hh:mm tt");
                    DateTime currentTime = Convert.ToDateTime(_currentTimeCheck);
                    var timeFormatBefore = hours + ":" + minutes + meridiem;
                    DateTime timeFormatAfter = Convert.ToDateTime(timeFormatBefore);
                    int dt = DateTime.Compare(currentTime, timeFormatAfter);
                    if (dt <= 0)
                    {
                        scheduledYear = datetimeCST.Year.ToString();
                        int integerSpecday = Convert.ToInt32(specificDay);
                        if (numericMonth == 2 && ((integerSpecday == 29) || (integerSpecday == 30) || (integerSpecday == 31)))
                        {
                            specificDay = "28";
                        }
                        int SpecDay = Convert.ToInt32(specificDay);
                        if (((numericMonth >= 0) && (numericMonth <= 9)) && ((SpecDay >= 0) && (SpecDay <= 9)))
                        {
                            numericMonth.ToString();
                            nextRunDate = ("0" + numericMonth).ToString() + "/" + ("0" + SpecDay).ToString() + "/" + scheduledYear;
                        }
                        else if (((numericMonth >= 0) && (numericMonth <= 9)) && !((SpecDay >= 0) && (SpecDay <= 9)))
                        {
                            numericMonth.ToString();
                            nextRunDate = ("0" + numericMonth).ToString() + "/" + (SpecDay).ToString() + "/" + scheduledYear;
                        }
                        else if (((SpecDay >= 0) && (SpecDay <= 9)) && !((numericMonth >= 0) && (numericMonth <= 9)))
                        {
                            nextRunDate = (numericMonth).ToString() + "/" + ("0" + SpecDay).ToString() + "/" + scheduledYear;
                        }
                        else
                        {
                            nextRunDate = numericMonth.ToString() + "/" + specificDay + "/" + scheduledYear;
                        }
                        checkRunDate.Add(nextRunDate);
                    }
                    else
                    {
                        numericMonth = numericMonth + 1;
                        scheduledYear = datetimeCST.Year.ToString();
                        if (numericMonth >= 12)
                        {
                            incrementedScheduledYear = datetimeCST.AddYears(1);
                            scheduledYearInteger = Convert.ToInt32(incrementedScheduledYear.Year);
                            scheduledYear = scheduledYearInteger.ToString();
                        }
                        if (numericMonth >= 12)
                        {
                            numericMonth = 1;
                        }

                        int integerSpecday = Convert.ToInt32(specificDay);
                        if (numericMonth == 2 && ((integerSpecday == 29) || (integerSpecday == 30) || (integerSpecday == 31)))
                        {
                            specificDay = "28";
                        }
                        int SpecDay = Convert.ToInt32(specificDay);
                        if (((numericMonth >= 0) && (numericMonth <= 9)) && ((SpecDay >= 0) && (SpecDay <= 9)))
                        {
                            numericMonth.ToString();
                            nextRunDate = ("0" + numericMonth).ToString() + "/" + ("0" + SpecDay).ToString() + "/" + scheduledYear;
                        }
                        else if (((numericMonth >= 0) && (numericMonth <= 9)) && !((SpecDay >= 0) && (SpecDay <= 9)))
                        {
                            numericMonth.ToString();
                            nextRunDate = ("0" + numericMonth).ToString() + "/" + (SpecDay).ToString() + "/" + scheduledYear;
                        }
                        else if (((SpecDay >= 0) && (SpecDay <= 9)) && !((numericMonth >= 0) && (numericMonth <= 9)))
                        {
                            nextRunDate = (numericMonth).ToString() + "/" + ("0" + SpecDay).ToString() + "/" + scheduledYear;
                        }
                        else
                        {
                            nextRunDate = numericMonth.ToString() + "/" + specificDay + "/" + scheduledYear;
                        }
                        checkRunDate.Add(nextRunDate);
                    }
                }
            }

            return checkRunDate;
        }

        public List<string> yearSelectionbasedonMultipleMonths(string month, string[] _monthSplitted, string specificDay, string hours, string minutes, string meridiem)
        {
            var dateTimeCST = TimeZoneInfo.ConvertTime((DateTime.Now), TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time"));


            int numericMonth = 0;
            var sortedMonths = _monthSplitted
   .Select(x => new { Name = x, Sort = DateTime.ParseExact(x, "MMMM", CultureInfo.InvariantCulture) })
   .OrderBy(x => x.Sort.Month)
   .Select(x => x.Name)
   .ToArray();

            int j = 0;
            int q = 0;

            for (int i = 0; (i < sortedMonths.Length) & (q < 2); i++)
            {
                sortedMonths[i].Trim();
                string monthTrimmed = sortedMonths[i].Substring(0, 3);
                int _currentMonthInteger = Convert.ToInt32(dateTimeCST.Month.ToString("00"));
                DateTime _month = DateTime.ParseExact(monthTrimmed, "MMM", CultureInfo.InvariantCulture);
                int numericMonthA = _month.Month;
                int numericMonthB = 0;

                if (numericMonthA < _currentMonthInteger)
                {
                    i = 1;
                    sortedMonths[i].Trim();
                    monthTrimmed = sortedMonths[i].Substring(0, 3);
                    _currentMonthInteger = Convert.ToInt32(DateTime.Now.Month.ToString("00"));
                    _month = DateTime.ParseExact(monthTrimmed, "MMM", CultureInfo.InvariantCulture);
                    numericMonthB = _month.Month;
                    if (numericMonthB < _currentMonthInteger)
                    {
                        if (numericMonthA >= numericMonthB & j == 0)
                        {
                            i = 1;
                            sortedMonths[i].Trim();
                            monthTrimmed = sortedMonths[i].Substring(0, 3);
                            _currentMonthInteger = Convert.ToInt32(dateTimeCST.Month.ToString("00"));
                            _month = DateTime.ParseExact(monthTrimmed, "MMM", CultureInfo.InvariantCulture);
                            numericMonth = _month.Month;
                        }
                        else
                        {
                            i = 0;
                            sortedMonths[i].Trim();
                            monthTrimmed = sortedMonths[i].Substring(0, 3);
                            _currentMonthInteger = Convert.ToInt32(dateTimeCST.Month.ToString("00"));
                            _month = DateTime.ParseExact(monthTrimmed, "MMM", CultureInfo.InvariantCulture);
                            numericMonth = _month.Month;
                        }
                        incrementedScheduledYear = dateTimeCST.AddYears(1);
                        scheduledYearInteger = Convert.ToInt32(incrementedScheduledYear.Year);
                        scheduledYear = scheduledYearInteger.ToString();

                        int integerSpecday = Convert.ToInt32(specificDay);
                        if (numericMonth == 02 && ((integerSpecday == 29) || (integerSpecday == 30) || (integerSpecday == 31)))
                        {
                            specificDay = "28";
                        }

                        int SpecDay = Convert.ToInt32(specificDay);
                        if (((numericMonth >= 0) && (numericMonth <= 9)) && ((SpecDay >= 0) && (SpecDay <= 9)))
                        {
                            numericMonth.ToString();
                            nextRunDate = ("0" + numericMonth).ToString() + "/" + ("0" + SpecDay).ToString() + "/" + scheduledYear;
                        }
                        else if (((numericMonth >= 0) && (numericMonth <= 9)) && !((SpecDay >= 0) && (SpecDay <= 9)))
                        {
                            numericMonth.ToString();
                            nextRunDate = ("0" + numericMonth).ToString() + "/" + (SpecDay).ToString() + "/" + scheduledYear;
                        }
                        else if (((SpecDay >= 0) && (SpecDay <= 9)) && !((numericMonth >= 0) && (numericMonth <= 9)))
                        {
                            nextRunDate = (numericMonth).ToString() + ("0" + SpecDay).ToString() + "/" + scheduledYear;
                        }
                        else
                        {
                            nextRunDate = numericMonth.ToString() + "/" + specificDay + "/" + scheduledYear;
                        }
                        checkRunDate.Add(nextRunDate);
                    }
                }

                sortedMonths[0].Trim();
                string u = sortedMonths[i].Substring(0, 3);
                int ug = Convert.ToInt32(dateTimeCST.Month.ToString("00"));
                DateTime _m = DateTime.ParseExact(u, "MMM", CultureInfo.InvariantCulture);
                int givenMonth = _month.Month;
                if (((numericMonthA > _currentMonthInteger) && (givenMonth != _currentMonthInteger)) || ((numericMonthB > _currentMonthInteger) && (givenMonth != _currentMonthInteger)))
                {
                    i = 1;
                    sortedMonths[i].Trim();
                    monthTrimmed = sortedMonths[i].Substring(0, 3);
                    _currentMonthInteger = Convert.ToInt32(dateTimeCST.Month.ToString("00"));
                    _month = DateTime.ParseExact(monthTrimmed, "MMM", CultureInfo.InvariantCulture);
                    numericMonthB = _month.Month;

                    if (numericMonthB > _currentMonthInteger)
                    {
                        if (numericMonthA >= numericMonthB)
                        {
                            i = 1;
                            sortedMonths[i].Trim();
                            monthTrimmed = sortedMonths[i].Substring(0, 3);
                            _currentMonthInteger = Convert.ToInt32(dateTimeCST.Month.ToString("00"));
                            _month = DateTime.ParseExact(monthTrimmed, "MMM", CultureInfo.InvariantCulture);
                            numericMonth = _month.Month;
                        }

                        //else if(numericMonthA <= numericMonthB)
                        //{
                        //    i = 0;
                        //    sortedMonths[i].Trim();
                        //    monthTrimmed = sortedMonths[i].Substring(0, 3);
                        //    _currentMonthInteger = Convert.ToInt32(dateTimeCST.Month.ToString("00"));
                        //    _month = DateTime.ParseExact(monthTrimmed, "MMM", CultureInfo.InvariantCulture);
                        //    numericMonth = _month.Month;
                        //}
                        else
                        {
                            i = 0;
                            sortedMonths[i].Trim();
                            monthTrimmed = sortedMonths[i].Substring(0, 3);
                            _currentMonthInteger = Convert.ToInt32(dateTimeCST.Month.ToString("00"));
                            _month = DateTime.ParseExact(monthTrimmed, "MMM", CultureInfo.InvariantCulture);
                            numericMonth = _month.Month;
                        }

                        scheduledYear = dateTimeCST.Year.ToString();
                        int integerSpecday = Convert.ToInt32(specificDay);
                        if (numericMonth == 02 && ((integerSpecday == 29) || (integerSpecday == 30) || (integerSpecday == 31)))
                        {
                            specificDay = "28";
                        }

                        int SpecDay = Convert.ToInt32(specificDay);
                        if (((numericMonth >= 0) && (numericMonth <= 9)) && ((SpecDay >= 0) && (SpecDay <= 9)))
                        {
                            numericMonth.ToString();
                            nextRunDate = ("0" + numericMonth).ToString() + "/" + ("0" + SpecDay).ToString() + "/" + scheduledYear;
                        }
                        else if (((numericMonth >= 0) && (numericMonth <= 9)) && !((SpecDay >= 0) && (SpecDay <= 9)))
                        {
                            numericMonth.ToString();
                            nextRunDate = ("0" + numericMonth).ToString() + "/" + (SpecDay).ToString() + "/" + scheduledYear;
                        }
                        else if (((SpecDay >= 0) && (SpecDay <= 9)) && !((numericMonth >= 0) && (numericMonth <= 9)))
                        {
                            nextRunDate = (numericMonth).ToString() + "/" + ("0" + SpecDay).ToString() + "/" + scheduledYear;
                        }
                        else
                        {
                            nextRunDate = numericMonth.ToString() + "/" + specificDay + "/" + scheduledYear;
                        }
                        checkRunDate.Add(nextRunDate);
                    }

                    else
                    {
                        i = 0;
                        sortedMonths[i].Trim();
                        monthTrimmed = sortedMonths[i].Substring(0, 3);
                        _currentMonthInteger = Convert.ToInt32(dateTimeCST.Month.ToString("00"));
                        _month = DateTime.ParseExact(monthTrimmed, "MMM", CultureInfo.InvariantCulture);
                        numericMonthB = _month.Month;
                    }
                    //}

                    //else if (((numericMonthA >= _currentMonthInteger) && (givenMonth == _currentMonthInteger)) || ((numericMonthB >= _currentMonthInteger) && (givenMonth == _currentMonthInteger)))
                    //{
                    //    incrementedScheduledYear = dateTimeCST.AddYears(1);
                    //    scheduledYearInteger = Convert.ToInt32(incrementedScheduledYear.Year);
                    //    scheduledYear = scheduledYearInteger.ToString();
                    //    int integerSpecday = Convert.ToInt32(specificDay);
                    //    if (numericMonthA == 02 && ((integerSpecday == 29) || (integerSpecday == 30) || (integerSpecday == 31)))
                    //    {
                    //        specificDay = "28";
                    //    }

                    //    int SpecDay = Convert.ToInt32(specificDay);
                    //    if (((numericMonthA >= 0) && (numericMonthA <= 9)) && ((SpecDay >= 0) && (SpecDay <= 9)))
                    //    {
                    //        numericMonthA.ToString();
                    //        nextRunDate = ("0" + numericMonthA).ToString() + "/" + ("0" + SpecDay).ToString() + "/" + scheduledYear;
                    //    }
                    //    else if (((numericMonthA >= 0) && (numericMonthA <= 9)) && !((SpecDay >= 0) && (SpecDay <= 9)))
                    //    {
                    //        numericMonthA.ToString();
                    //        nextRunDate = ("0" + numericMonthA).ToString() + (SpecDay).ToString() + "/" + scheduledYear;
                    //    }
                    //    else if (((SpecDay >= 0) && (SpecDay <= 9)) && !((numericMonthA >= 0) && (numericMonthA <= 9)))
                    //    {
                    //        nextRunDate = (numericMonthA).ToString() + ("0" + SpecDay).ToString() + "/" + scheduledYear;
                    //    }
                    //    else
                    //    {
                    //        nextRunDate = numericMonthA.ToString() + "/" + specificDay + "/" + scheduledYear;
                    //    }

                    //    checkRunDate.Add(nextRunDate);
                    //}

                    //If Given Month and Current Month are Equal
                    int _dateCompared = 0;
                    if (numericMonthA == _currentMonthInteger || numericMonthB == _currentMonthInteger)
                    {
                        if (q != 1)
                        {
                            int currentDay = dateTimeCST.Day;
                            int specday = Convert.ToInt32(specificDay);

                            if (specday < currentDay)
                            {
                                i = 1;
                            }
                            if (specday > currentDay)
                            {
                                i = 0;
                            }

                            if (specday == currentDay)
                            {
                                DateTime _currentTime = dateTimeCST;
                                var _currentTimeCheck = _currentTime.ToString("hh:mm tt");
                                DateTime currentTime = Convert.ToDateTime(_currentTimeCheck);
                                var timeFormatBefore = hours + ":" + minutes + meridiem;
                                DateTime timeFormatAfter = Convert.ToDateTime(timeFormatBefore);
                                int dt = DateTime.Compare(currentTime, timeFormatAfter);
                                _dateCompared = dt;
                                if (dt <= 0)
                                {
                                    i = 0;
                                }
                                else
                                {
                                    i = 1;
                                }
                            }
                            sortedMonths[i].Trim();
                            monthTrimmed = sortedMonths[i].Substring(0, 3);
                            _currentMonthInteger = Convert.ToInt32(dateTimeCST.Month.ToString("00"));
                            _month = DateTime.ParseExact(monthTrimmed, "MMM", CultureInfo.InvariantCulture);
                            numericMonthB = _month.Month;
                            numericMonth = numericMonthB;
                            if (i == 1)
                            {
                                i = -1;
                            }
                            scheduledYear = dateTimeCST.Year.ToString();
                            int integerSpecday = Convert.ToInt32(specificDay);
                            if (numericMonth == 02 && ((integerSpecday == 29) || (integerSpecday == 30) || (integerSpecday == 31)))
                            {
                                specificDay = "28";
                            }

                            int SpecDay = Convert.ToInt32(specificDay);
                            if (((numericMonth >= 0) && (numericMonth <= 9)) && (SpecDay >= 0 && SpecDay <= 9))
                            {
                                numericMonth.ToString();
                                nextRunDate = ("0" + numericMonth).ToString() + "/" + ("0" + SpecDay).ToString() + "/" + scheduledYear;
                            }
                            else if (((numericMonth >= 0) && (numericMonth <= 9)) && !(SpecDay >= 0 && SpecDay <= 9))
                            {
                                numericMonth.ToString();
                                nextRunDate = ("0" + numericMonth).ToString() + (SpecDay).ToString() + "/" + scheduledYear;
                            }
                            else if (((SpecDay >= 0) && (SpecDay <= 9)) && !((numericMonth >= 0) && (numericMonth <= 9)))
                            {
                                nextRunDate = (numericMonth).ToString() + ("0" + SpecDay).ToString() + "/" + scheduledYear;
                            }
                            else
                            {
                                nextRunDate = numericMonth.ToString() + "/" + specificDay + "/" + scheduledYear;
                            }
                            checkRunDate.Add(nextRunDate);
                        }
                    }
                    q++;

                }

            }
            checkRunDate.Add(nextRunDate);
            return checkRunDate;
        }

        public List<string> yearSelectionBasedOnWeekAndWeekDay(string month, string week, string weekDay, string hours, string minutes, string meridiem)
        {
            DateTime weekDay_date = new DateTime();

            var datetimeCST = TimeZoneInfo.ConvertTime((DateTime.Now), TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time"));
            int currentMonth = datetimeCST.Month;
            DateTime date = new DateTime();
            int _Year;
            DateTime _date = new DateTime();
            string givenWeek = week.Substring(0, 1);
            int _week = Convert.ToInt32(givenWeek);

            string setDay;
            int setMonth;

            int _year = 0;
            string monthTrimmed = month.Substring(0, 3);
            int _currentMonthInteger = Convert.ToInt32(datetimeCST.Month.ToString("00"));
            DateTime _month = DateTime.ParseExact(monthTrimmed, "MMM", CultureInfo.InvariantCulture);
            int numericMonth = _month.Month;




            if (numericMonth < _currentMonthInteger)
            {
                if (numericMonth < currentMonth)
                {
                    _year = (datetimeCST.Year + 1);
                }
                date = new DateTime(_year, numericMonth, 1);
                for (int i = 0; i < 7; i++)
                {
                    DateTime temp = date.AddDays(i);
                    //if (temp.DayOfWeek == (DayOfWeek.Tuesday))
                    if (temp.DayOfWeek == (DayOfWeek)Enum.Parse(typeof(DayOfWeek), weekDay))
                    {
                        _date = temp.Date;
                        weekDay_date = _date;

                        int checkDay = weekDay_date.Day;
                        int checkMonth = weekDay_date.Month;
                        int years = weekDay_date.Year;


                        if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                        {
                            setDay = "28";
                            nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                        }

                        else
                        {
                            nextRunDate = FormattingDate(checkDay, checkMonth, years);
                        }

                    }

                }
                if (_week == 2)
                {
                    _date = _date.AddDays(7);
                    weekDay_date = _date;

                    int checkDay = weekDay_date.Day;
                    int checkMonth = weekDay_date.Month;
                    int years = weekDay_date.Year;
                    if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                    {
                        setDay = "28";
                        nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                    }
                    //else
                    //{   
                    //    nextRunDate = (weekDay_date.Date).ToString();
                    //}
                    else
                    {
                        nextRunDate = FormattingDate(checkDay, checkMonth, years);
                    }
                }
                if (_week == 3)
                {
                    _date = _date.AddDays(14);
                    weekDay_date = _date;
                    int checkDay = weekDay_date.Day;
                    int checkMonth = weekDay_date.Month;
                    int years = weekDay_date.Year;
                    if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                    {
                        setDay = "28";
                        nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                    }
                    //else
                    //{
                    //    nextRunDate = (weekDay_date.Date).ToString();
                    //}
                    else
                    {
                        nextRunDate = FormattingDate(checkDay, checkMonth, years);
                    }

                }
                if (_week == 4)
                {
                    _date = _date.AddDays(21);
                    weekDay_date = _date; int checkDay = weekDay_date.Day;
                    int checkMonth = weekDay_date.Month;
                    int years = weekDay_date.Year;
                    if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                    {
                        setDay = "28";
                        nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                    }
                    //else
                    //{
                    //    nextRunDate = (weekDay_date.Date).ToString();
                    //}
                    else
                    {
                        nextRunDate = FormattingDate(checkDay, checkMonth, years);
                    }
                }
            }

            if (numericMonth > _currentMonthInteger)
            {
                _year = (datetimeCST.Year);
                date = new DateTime(_year, numericMonth, 1);
                for (int i = 0; i < 7; i++)
                {
                    DateTime temp = date.AddDays(i);
                    if (temp.DayOfWeek == (DayOfWeek)Enum.Parse(typeof(DayOfWeek), weekDay))
                    {
                        _date = temp.Date;
                        weekDay_date = _date;
                        int checkDay = weekDay_date.Day;
                        int checkMonth = weekDay_date.Month;
                        int years = weekDay_date.Year;
                        if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                        {
                            setDay = "28";
                            nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                        }
                        //else
                        //{
                        //    nextRunDate = (weekDay_date.Date).ToString();
                        //}
                        else
                        {
                            nextRunDate = FormattingDate(checkDay, checkMonth, years);
                        }
                    }
                }
                if (_week == 2)
                {
                    _date = _date.AddDays(7);
                    weekDay_date = _date;
                    int checkDay = weekDay_date.Day;
                    int checkMonth = weekDay_date.Month;
                    int years = weekDay_date.Year;
                    if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                    {
                        setDay = "28";
                        nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                    }
                    else
                    {
                        //nextRunDate = (weekDay_date.Date).ToString();
                        nextRunDate = FormattingDate(checkDay, checkMonth, years);
                    }
                }
                if (_week == 3)
                {
                    _date = _date.AddDays(14);
                    weekDay_date = _date;
                    int checkDay = weekDay_date.Day;
                    int checkMonth = weekDay_date.Month;
                    int years = weekDay_date.Year;
                    if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                    {
                        setDay = "28";
                        nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                    }
                    else
                    {
                        //nextRunDate = (weekDay_date.Date).ToString();
                        nextRunDate = FormattingDate(checkDay, checkMonth, years);
                    }
                }
                if (_week == 4)
                {
                    _date = _date.AddDays(21);
                    weekDay_date = _date;
                    int checkDay = weekDay_date.Day;
                    int checkMonth = weekDay_date.Month;
                    int years = weekDay_date.Year;
                    if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                    {
                        setDay = "28";
                        nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                    }
                    else
                    {
                        //nextRunDate = (weekDay_date.Date).ToString();
                        nextRunDate = FormattingDate(checkDay, checkMonth, years);
                    }
                }
            }

            if (numericMonth == _currentMonthInteger)
            {
                _year = (datetimeCST.Year);
                if (numericMonth < currentMonth)
                {
                    _year = (datetimeCST.Year + 1);
                }
                date = new DateTime(_year, numericMonth, 1);
                for (int i = 0; i < 7; i++)
                {
                    DateTime temp = date.AddDays(i);

                    if (temp.DayOfWeek == (DayOfWeek)Enum.Parse(typeof(DayOfWeek), weekDay))
                    {
                        _date = temp.Date;
                        weekDay_date = _date;
                        int checkDay = weekDay_date.Day;
                        int checkMonth = weekDay_date.Month;
                        int years = weekDay_date.Year;
                        if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                        {
                            setDay = "28";
                            nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                        }
                        else
                        {
                            //nextRunDate = (weekDay_date.Date).ToString();
                            nextRunDate = FormattingDate(checkDay, checkMonth, years);
                        }

                    }
                }

                if (_week == 2)
                {
                    _date = _date.AddDays(7);
                    weekDay_date = _date;
                    int checkDay = weekDay_date.Day;
                    int checkMonth = weekDay_date.Month;
                    int years = weekDay_date.Year;
                    if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                    {
                        setDay = "28";
                        nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                    }
                    else
                    {
                        //nextRunDate = (weekDay_date.Date).ToString();
                        nextRunDate = FormattingDate(checkDay, checkMonth, years);
                    }
                }
                if (_week == 3)
                {
                    _date = _date.AddDays(14);
                    weekDay_date = _date;
                    int checkDay = weekDay_date.Day;
                    int checkMonth = weekDay_date.Month;
                    int years = weekDay_date.Year;
                    if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                    {
                        setDay = "28";
                        nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                    }
                    else
                    {
                        //nextRunDate = (weekDay_date.Date).ToString();
                        nextRunDate = FormattingDate(checkDay, checkMonth, years);
                    }
                }
                if (_week == 4)
                {
                    _date = _date.AddDays(21);
                    weekDay_date = _date;
                    int checkDay = weekDay_date.Day;
                    int checkMonth = weekDay_date.Month;
                    int years = weekDay_date.Year;
                    if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                    {
                        setDay = "28";
                        nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                    }
                    else
                    {
                        //nextRunDate = (weekDay_date.Date).ToString();
                        nextRunDate = FormattingDate(checkDay, checkMonth, years);
                    }
                }

                int specDay = weekDay_date.Day;
                var datetime = TimeZoneInfo.ConvertTime((DateTime.Now), TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time"));
                int currentDay = datetime.Day;
                if (specDay < currentDay)
                {
                    _year = (datetimeCST.Year + 1);
                    date = new DateTime(_year, numericMonth, 1);
                    for (int i = 0; i < 7; i++)
                    {
                        DateTime temp = date.AddDays(i);
                        if (temp.DayOfWeek == (DayOfWeek)Enum.Parse(typeof(DayOfWeek), weekDay))
                        {
                            _date = temp.Date;
                            weekDay_date = _date;
                            int checkDay = weekDay_date.Day;
                            int checkMonth = weekDay_date.Month;
                            int years = weekDay_date.Year;
                            if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                            {
                                setDay = "28";
                                nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                            }
                            else
                            {
                                //nextRunDate = (weekDay_date.Date).ToString();
                                nextRunDate = FormattingDate(checkDay, checkMonth, years);
                            }
                        }
                    }
                    if (_week == 2)
                    {
                        _date = _date.AddDays(7);
                        weekDay_date = _date;
                        int checkDay = weekDay_date.Day;
                        int checkMonth = weekDay_date.Month;
                        int years = weekDay_date.Year;
                        if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                        {
                            setDay = "28";
                            nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                        }
                        else
                        {
                            //nextRunDate = (weekDay_date.Date).ToString();
                            nextRunDate = FormattingDate(checkDay, checkMonth, years);
                        }
                    }
                    if (_week == 3)
                    {
                        _date = _date.AddDays(14);
                        weekDay_date = _date;
                        int checkDay = weekDay_date.Day;
                        int checkMonth = weekDay_date.Month;
                        int years = weekDay_date.Year;
                        if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                        {
                            setDay = "28";
                            nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                        }
                        else
                        {
                            //nextRunDate = (weekDay_date.Date).ToString();
                            nextRunDate = FormattingDate(checkDay, checkMonth, years);
                        }
                    }
                    if (_week == 4)
                    {
                        _date = _date.AddDays(21);
                        weekDay_date = _date;
                        int checkDay = weekDay_date.Day;
                        int checkMonth = weekDay_date.Month;
                        int years = weekDay_date.Year;
                        if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                        {
                            setDay = "28";
                            nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                        }
                        else
                        {
                            //nextRunDate = (weekDay_date.Date).ToString();
                            nextRunDate = FormattingDate(checkDay, checkMonth, years);
                        }
                    }
                    //int v = weekDay_date.Day;
                    //int p = weekDay_date.Month;
                    //int y = weekDay_date.Year;
                    //if (p == 2 && ((v == 28) || (v == 28) || (v == 28)))
                    //{
                    //    v = 28;
                    //}
                    //string rundate = p.ToString() + "/" + v.ToString() + "/" + y.ToString();
                }
                if (specDay > currentDay)
                {
                    _year = (DateTime.Now.Year + 0);
                    date = new DateTime(_year, numericMonth, 1);
                    for (int i = 0; i < 7; i++)
                    {
                        DateTime temp = date.AddDays(i);
                        if (temp.DayOfWeek == (DayOfWeek)Enum.Parse(typeof(DayOfWeek), weekDay))
                        {
                            _date = temp.Date;
                            weekDay_date = _date;
                            int checkDay = weekDay_date.Day;
                            int checkMonth = weekDay_date.Month;
                            int years = weekDay_date.Year;
                            if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                            {
                                setDay = "28";
                                nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                            }
                            else
                            {
                                //nextRunDate = (weekDay_date.Date).ToString();
                                nextRunDate = FormattingDate(checkDay, checkMonth, years);
                            }
                        }
                    }
                    if (_week == 2)
                    {
                        _date = _date.AddDays(7);
                        weekDay_date = _date;
                        int checkDay = weekDay_date.Day;
                        int checkMonth = weekDay_date.Month;
                        int years = weekDay_date.Year;
                        if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                        {
                            setDay = "28";
                            nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                        }
                        else
                        {
                            //nextRunDate = (weekDay_date.Date).ToString();
                            nextRunDate = FormattingDate(checkDay, checkMonth, years);
                        }
                    }
                    if (_week == 3)
                    {
                        _date = _date.AddDays(14);
                        weekDay_date = _date;
                        int checkDay = weekDay_date.Day;
                        int checkMonth = weekDay_date.Month;
                        int years = weekDay_date.Year;
                        if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                        {
                            setDay = "28";
                            nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                        }
                        else
                        {
                            //nextRunDate = (weekDay_date.Date).ToString();
                            nextRunDate = FormattingDate(checkDay, checkMonth, years);
                        }
                    }
                    if (_week == 4)
                    {
                        _date = _date.AddDays(21);
                        weekDay_date = _date;
                        int checkDay = weekDay_date.Day;
                        int checkMonth = weekDay_date.Month;
                        int years = weekDay_date.Year;
                        if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                        {
                            setDay = "28";
                            nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                        }
                        else
                        {
                            //nextRunDate = (weekDay_date.Date).ToString();
                            nextRunDate = FormattingDate(checkDay, checkMonth, years);
                        }
                    }
                }
                if (specDay == currentDay)
                {
                    var _currentTimeCheck = datetime.ToString("hh:mm tt");
                    DateTime currentTime = Convert.ToDateTime(_currentTimeCheck);
                    var timeFormatBefore = hours + ":" + minutes + meridiem;
                    DateTime timeFormatAfter = Convert.ToDateTime(timeFormatBefore);
                    int dt = DateTime.Compare(currentTime, timeFormatAfter);
                    if (dt <= 0)
                    {
                        _year = (datetimeCST.Year);
                        date = new DateTime(_year, numericMonth, 1);
                        for (int i = 0; i < 7; i++)
                        {
                            DateTime temp = date.AddDays(i);
                            if (temp.DayOfWeek == (DayOfWeek)Enum.Parse(typeof(DayOfWeek), weekDay))
                            {
                                _date = temp.Date;
                                weekDay_date = _date;
                                int checkDay = weekDay_date.Day;
                                int checkMonth = weekDay_date.Month;
                                int years = weekDay_date.Year;
                                if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                                {
                                    setDay = "28";
                                    nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                                }
                                else
                                {
                                    //nextRunDate = (weekDay_date.Date).ToString();
                                    nextRunDate = FormattingDate(checkDay, checkMonth, years);
                                }
                            }
                        }
                        if (_week == 2)
                        {
                            _date = _date.AddDays(7);
                            weekDay_date = _date;
                            int checkDay = weekDay_date.Day;
                            int checkMonth = weekDay_date.Month;
                            int years = weekDay_date.Year;
                            if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                            {
                                setDay = "28";
                                nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                            }
                            else
                            {
                                //nextRunDate = (weekDay_date.Date).ToString();
                                nextRunDate = FormattingDate(checkDay, checkMonth, years);
                            }
                        }
                        if (_week == 3)
                        {
                            _date = _date.AddDays(14);
                            weekDay_date = _date;
                            int checkDay = weekDay_date.Day;
                            int checkMonth = weekDay_date.Month;
                            int years = weekDay_date.Year;
                            if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                            {
                                setDay = "28";
                                nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                            }
                            else
                            {
                                //nextRunDate = (weekDay_date.Date).ToString();
                                nextRunDate = FormattingDate(checkDay, checkMonth, years);
                            }
                        }
                        if (_week == 4)
                        {
                            _date = _date.AddDays(21);
                            weekDay_date = _date;
                            int checkDay = weekDay_date.Day;
                            int checkMonth = weekDay_date.Month;
                            int years = weekDay_date.Year;
                            if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                            {
                                setDay = "28";
                                nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                            }
                            else
                            {
                                //nextRunDate = (weekDay_date.Date).ToString();
                                nextRunDate = FormattingDate(checkDay, checkMonth, years);
                            }
                        }
                    }
                    else
                    {
                        _year = (datetimeCST.Year + 1);
                        date = new DateTime(_year, numericMonth, 1);
                        for (int i = 0; i < 7; i++)
                        {
                            DateTime temp = date.AddDays(i);
                            if (temp.DayOfWeek == (DayOfWeek)Enum.Parse(typeof(DayOfWeek), weekDay))
                            {
                                _date = temp.Date;
                                weekDay_date = _date;
                                int checkDay = weekDay_date.Day;
                                int checkMonth = weekDay_date.Month;
                                int years = weekDay_date.Year;
                                if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                                {
                                    setDay = "28";
                                    nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                                }
                                else
                                {
                                    //nextRunDate = (weekDay_date.Date).ToString();
                                    nextRunDate = FormattingDate(checkDay, checkMonth, years);
                                }
                            }

                        }
                        if (_week == 2)
                        {
                            _date = _date.AddDays(7);
                            weekDay_date = _date;
                            int checkDay = weekDay_date.Day;
                            int checkMonth = weekDay_date.Month;
                            int years = weekDay_date.Year;
                            if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                            {
                                setDay = "28";
                                nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                            }
                            else
                            {
                                //nextRunDate = (weekDay_date.Date).ToString();
                                nextRunDate = FormattingDate(checkDay, checkMonth, years);
                            }
                        }
                        if (_week == 3)
                        {
                            _date = _date.AddDays(14);
                            weekDay_date = _date;
                            int checkDay = weekDay_date.Day;
                            int checkMonth = weekDay_date.Month;
                            int years = weekDay_date.Year;
                            if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                            {
                                setDay = "28";
                                nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                            }
                            else
                            {
                                //nextRunDate = (weekDay_date.Date).ToString();
                                nextRunDate = FormattingDate(checkDay, checkMonth, years);
                            }
                        }
                        if (_week == 4)
                        {
                            _date = _date.AddDays(21);
                            weekDay_date = _date;
                            int checkDay = weekDay_date.Day;
                            int checkMonth = weekDay_date.Month;
                            int years = weekDay_date.Year;

                            if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                            {
                                setDay = "28";
                                nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                            }
                            else
                            {
                                //nextRunDate = (weekDay_date.Date).ToString();
                                nextRunDate = FormattingDate(checkDay, checkMonth, years);
                            }
                        }
                    }
                }
            }
            checkRunDate.Add(nextRunDate);
            return checkRunDate;
        }


        public string FormattingDate(int checkDay, int checkMonth, int years)
        {



            if (((checkMonth >= 0) && (checkMonth <= 9)) && ((checkDay >= 0) && (checkDay <= 9)))
            {
                //numericMonth.ToString();
                nextRunDate = ("0" + checkMonth).ToString() + "/" + ("0" + checkDay).ToString() + "/" + years;
            }
            else if (((checkMonth >= 0) && (checkMonth <= 9)) && !((checkDay >= 0) && (checkDay <= 9)))
            {
                //numericMonth.ToString();
                nextRunDate = ("0" + checkMonth).ToString() + "/" + (checkDay).ToString() + "/" + years;
            }
            else if (((checkDay >= 0) && (checkDay <= 9)) && !((checkMonth >= 0) && (checkMonth <= 9)))
            {
                nextRunDate = (checkMonth).ToString() + "/" + ("0" + checkDay).ToString() + "/" + years;
            }
            else
            {
                nextRunDate = checkMonth.ToString() + "/" + checkDay + "/" + years;
            }

            return nextRunDate;
        }

        public void SavedItemDimension_CM_Meter(string CustomerName,string DimensionType)
        {
            Item GetDimensionsTypeFromDB = DBHelper.GetItemDetailsBasedDimension(CustomerName, DimensionType);
            if (GetDimensionsTypeFromDB != null)
            {
                SelectionCheck_CMorMeter = DimensionType;
                string ItemClass = GetDimensionsTypeFromDB.Classification.ToString();
                string ItemDescription = GetDimensionsTypeFromDB.ItemDescription;
                string ClassAndItemDescription = ItemClass + " " + ItemDescription;


                scrollpagedown();
                scrollpagedown();
                Click(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);

                Click(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id);
                IList<IWebElement> ClassAndItemDropdown = GlobalVariables.webDriver.FindElements(By.XPath(FreightDescription_ClassList_Xpath));
                int ClassAndItemDropdownCount = ClassAndItemDropdown.Count;
                for (int i = 0; i < ClassAndItemDropdownCount; i++)
                {
                    if (ClassAndItemDropdown[i].Text == ClassAndItemDescription.ToUpper())
                    {
                        ClassAndItemDropdown[i].Click();
                        break;
                    }
                }


            }
            else
            {
                Report.WriteLine("No Record Present in DB with dimension Type of CM ");
            }
        }


        public void DefaultItemDimension_CM_Meter(string CustomerName,string dimension)
        {
            Item GetDimensionsTypeFromDB = DBHelper.GetDefaultItemDetailsBasedDimension(CustomerName);
            if (GetDimensionsTypeFromDB != null)
            {
                if (GetDimensionsTypeFromDB.DimensionUnit == "CM")
                {
                    DefaultCheck_CMandMeter = dimension;
                    string ItemClass = GetDimensionsTypeFromDB.Classification.ToString();
                    string ItemDescription = GetDimensionsTypeFromDB.ItemDescription;
                    string ClassAndItemDescription = ItemClass + " " + ItemDescription;

                    scrollpagedown();
                    scrollpagedown();

                    string ActualClass = GetAttribute(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id, "value");
                    Assert.AreEqual(ClassAndItemDescription.ToUpper(), ActualClass);
                }
                else
                {
                    Report.WriteLine("This customer is not having the Default item vlaue");
                }


            }
            else
            {
                Report.WriteLine("No Default Item Record Present in DB");
            }
        }
    }
}




