using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using TechTalk.SpecFlow;
using CRM.UITest.Entities;
using System.Collections.Generic;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using Rrd.ServiceAccessLayer;
using System;
using System.Threading;
using CRM.UITest.Entities.Proxy;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;

namespace CRM.UITest.Scripts.TL_Rating_Tool.Get_Quote__TL_.Date_and_Time_Selection
{
    [Binding]
    public class TruckloadRatingPageGetQuoteTLPickupDropoffTimesSteps:TruckloadRatingTool
    {
        [Then(@"I should display with pickup start time dropdown")]
        public void ThenIShouldDisplayWithPickupStartTimeDropdown()
        {
            Report.WriteLine("Displaying with PickupStartTimeDropdown");
            VerifyElementVisible(attributeName_xpath, TL_pickstart, "pickstart");
        }
        
        [Then(@"I should displayed with (.*)am default time in pickup start time dropdown")]
        public void ThenIShouldDisplayedWithAmDefaultTimeInPickupStartTimeDropdown(int p0)
        {
            Report.WriteLine("DisplayedWithAmDefaultTimeInPickupStartTimeDropdown");
            string pickstart=Gettext(attributeName_xpath, TL_pickstart);
            String actualstarttime = "8:00 AM";
            Assert.AreEqual(pickstart, actualstarttime);
        }

        [Then(@"I should display with pickup end time dropdown")]
        public void ThenIShouldDisplayWithPickupEndTimeDropdown()
        {
            Report.WriteLine("Displaying with PickupStartTimeDropdown");
            VerifyElementVisible(attributeName_xpath, TL_pickend, "pickend");
        }
  
        [Then(@"I should displayed with Fivepmdefault time in pickup end time dropdown")]
        public void ThenIShouldDisplayedWithFivepmdefaultTimeInPickupEndTimeDropdown()
        {
            Report.WriteLine("DisplayedWithAmDefaultTimeInPickupendTimeDropdown");
            string pickstart = Gettext(attributeName_xpath, TL_pickend);
            String actualstarttime = "5:00 PM";
            Assert.AreEqual(pickstart, actualstarttime);
        }


        [Then(@"I should displayed with (.*)pm default time in pickup end time dropdown")]
        public void ThenIShouldDisplayedWithPmDefaultTimeInPickupEndTimeDropdown()
        {
            Report.WriteLine("DisplayedWithAmDefaultTimeInPickupendTimeDropdown");
            string pickstart = Gettext(attributeName_xpath, TL_pickend);
            String actualstarttime = "5:00 PM";
            Assert.AreEqual(pickstart, actualstarttime);
        }
        
        [Then(@"I should be able to select the any (.*) in pickup start time dropdown")]
        public void ThenIShouldBeAbleToSelectTheAnyInPickupStartTimeDropdown(string pickstarttime)
        {

            Report.WriteLine("AbleToSelectTheAnyInPickupStartTimeDropdown");
            Click(attributeName_xpath, TL_pickstart);
            VerifyElementVisible(attributeName_xpath, TL_pickstartdropvalues, "eg");
            SelectDropdownValueFromList(attributeName_xpath,TL_pickstartdropvalues, "7:00 AM");

        }
        
        [Then(@"I should displayed with (.*)pm default time in pickup start time dropdown")]
        public void ThenIShouldDisplayedWithPmDefaultTimeInPickupStartTimeDropdown(int p0)
        {

            Report.WriteLine("Displaying with PickupStartTimeDropdown");
            VerifyElementVisible(attributeName_xpath, TL_pickstart, "pickstart");
        }

        [Then(@"I should be able to select the any (.*) in pickup end time dropdown")]
        public void ThenIShouldBeAbleToSelectTheAnyInPickupEndTimeDropdown(string pickendtime)
        {

            Report.WriteLine("AbleToSelectTheAnyInPickendTimeDropdown");
            Click(attributeName_xpath, TL_pickend);
            //IList<IWebElement> dropvalues = GlobalVariables.webDriver.FindElements(By.XPath(TL_pickenddropvalues));
            //List<string> pickenddropvalues = new List<string>();
            //foreach (IWebElement element in dropvalues)
            //{
            //    pickenddropvalues.Add((element.Text).ToString());
            //}

            SelectDropdownValueFromList(attributeName_xpath, TL_pickenddropvalues, "6:00 AM");
                       
        }
        
        [Then(@"I should display with Dropoff start time dropdown")]
        public void ThenIShouldDisplayWithDropoffStartTimeDropdown()
        {
            Report.WriteLine("Displaying with PickupendTimeDropdown");
            VerifyElementVisible(attributeName_xpath, TL_pickend, "pickend");

        }
        [Then(@"I should displayed with Eight AM default time in Dropoff start time dropdown")]
        public void ThenIShouldDisplayedWithEightAMDefaultTimeInDropoffStartTimeDropdown()
        {
            Report.WriteLine("DisplayedWithAmDefaultTimeInPickupStartTimeDropdown");
            string pickstart = Gettext(attributeName_xpath, TL_pickstart);
            String actualstarttime = "8:00 AM";
            Assert.AreEqual(pickstart, actualstarttime);
        }


        [Then(@"I should display with Dropoff end time dropdown")]
        public void ThenIShouldDisplayWithDropoffEndTimeDropdown()
        {
            Report.WriteLine("Displaying with DropoffEndTimeDropdown");
            VerifyElementVisible(attributeName_xpath, TL_dropend, "dropend");
        }

        [Then(@"I should displayed with five Pm default time in Dropoff end time dropdown")]
        public void ThenIShouldDisplayedWithFivePmDefaultTimeInDropoffEndTimeDropdown()
        {
            Report.WriteLine("DisplayedWithAmDefaultTimeInPickupStartTimeDropdown");
            string dropend = Gettext(attributeName_xpath, TL_dropend);
            String actualendtime = "5:00 PM";
            Assert.AreEqual(dropend, actualendtime);
        }
             
        [Then(@"I should be able to select the any (.*) in Dropoff start time dropdown")]
        public void ThenIShouldBeAbleToSelectTheAnyInDropoffStartTimeDropdown(string Dpickstarttime)
        {

            Report.WriteLine("AbleToSelectTheAnyInDropoffStartTimeDropdown");
            Click(attributeName_xpath, TL_dropstart);
            SelectDropdownValueFromList(attributeName_xpath,TL_dropstartvalues, Dpickstarttime);
        }
        
        [Then(@"I should displayed with (.*)am default time in Dropoff start time dropdown")]
        public void ThenIShouldDisplayedWithamDefaultTimeInDropoffStartTimeDropdown(int Dpickstarttime)
        {

            Report.WriteLine("DisplayedWithPmDefaultTimeInDropoffStartTimeDropdown");
            string pickstart = Gettext(attributeName_xpath, TL_dropstart);
            String actualstarttime = "8:00 AM";
            Assert.AreEqual(pickstart, actualstarttime);
        }
        
        [Then(@"I should be able to select the any (.*) in Dropoff end time dropdown")]
        public void ThenIShouldBeAbleToSelectTheAnyInDropoffEndTimeDropdown(string Dpickendtime)
        {

            Report.WriteLine("AbleToSelectTheAnyInPickendTimeDropdown");
            Click(attributeName_xpath, TL_dropend);
            SelectDropdownValueFromList(attributeName_xpath, TL_dropendvalues, Dpickendtime);
        }

        [Then(@"I should display with error message when Pickup end time lesser than start time")]
        public void ThenIShouldDisplayWithErrorMessageWhenPickupEndTimeLesserThanStartTime()
        {
            Report.WriteLine("dDisplayWithErrorMessageWhenPickupEndTimeLesserThanStartTime");
            VerifyElementVisible(attributeName_xpath, TL_pickerrorpopup, "pickstart");
            string error = Gettext(attributeName_xpath, TL_pickerrorpopup);
            String actualerror = "Pickup from time cannot be greater than Pickup to time.";
            Assert.AreEqual(error, actualerror);
        }

        [Then(@"I should display with error message when Dropoff end time lesser than start time")]
        public void ThenIShouldDisplayWithErrorMessageWhenDropoffEndTimeLesserThanStartTime()
        {
            Report.WriteLine("DisplayWithErrorMessageWhenDropoffEndTimeLesserThanStartTime");
            VerifyElementVisible(attributeName_xpath, TL_pickstart, "pickstart");
            string error = Gettext(attributeName_xpath, TL_droperrorpopup);
            String actualerror = "Dropoff from time cannot be greater than Dropoff to time.";
            Assert.AreEqual(error, actualerror);
        }

        [Then(@"I click on live quote button")]
        public void ThenIClickOnLiveQuoteButton()
        {
            Click(attributeName_xpath, TL_clicklivequote);
        }


    }
}
