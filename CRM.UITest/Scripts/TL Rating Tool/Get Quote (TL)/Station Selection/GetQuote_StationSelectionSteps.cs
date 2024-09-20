using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.Dls.IdentityServer.Core.Dto;
using Rrd.ServiceAccessLayer;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.TL_Rating_Tool.Get_Quote__TL_.Station_Selection
{
    [Binding]
    public class GetQuote_StationSelectionSteps : TruckloadRatingTool
    {
        [Then(@"the Station I am associated to will be displayed in the station dropdown (.*)")]
        public void ThenTheStationIAmAssociatedToWillBeDisplayedInTheStationDropdown(string Username)
        {
            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);
            List<AppUserClaimInfo> AllClaimDetails = IDP.GetUserClaimDetails(Username);
            List<string> setClaimDetails = AllClaimDetails.Where(c => c.ClaimType == "dlscrm-StationId").Select(a => a.ClaimValue).ToList();
            List<string> values = DBHelper.GetMappedStationList(setClaimDetails);
            string selectedValue = Gettext(attributeName_xpath, TL_StationDropdown_SelectedValue_Xpath);

            if (values.Count == 1)
            {
                Assert.AreEqual(selectedValue, values[0]);
                Report.WriteLine("Logged in user is mapped to one station");
                Report.WriteLine("Mapped station" + selectedValue + " is selected by default in the station dropdown");
            }
             else
            {
                Report.WriteLine("Logged in user is mapped to mulitple stations");
                Assert.IsTrue(false);
            }
        }   

        [Then(@"the Stations I am associated to will be displayed in the station dropdown (.*)")]
        public void ThenTheStationsIAmAssociatedToWillBeDisplayedInTheStationDropdown(string Username)
        {

            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);
            List<AppUserClaimInfo> AllClaimDetails = IDP.GetUserClaimDetails(Username);
            List<string> setClaimDetails = AllClaimDetails.Where(c => c.ClaimType == "dlscrm-StationId").Select(a => a.ClaimValue).ToList();
            List<string> values = DBHelper.GetMappedStationList(setClaimDetails);
            Click(attributeName_id, TL_StationDropdown_ID);
            IList<IWebElement> dropdownValues = GlobalVariables.webDriver.FindElements(By.XPath(TL_StationDropdownValue_Xpath));

            for (int i = 0; i < values.Count; i++)
            {
               if (values.Contains(dropdownValues[i].Text))
                 {
                        Report.WriteLine(dropdownValues[i].Text + " option is displaying in station dropdown");
                 }
                else
                 {
                        Report.WriteLine("Displaying dropdownvalues is not matching with expected values");
                        Assert.IsTrue(false);
                 }
             }
           }

        [Then(@"I should be able to select only one station from the dropdown (.*), (.*)")]
        public void ThenIShouldBeAbleToSelectOnlyOneStationFromTheDropdown(string station1, string station2)
        {
            Click(attributeName_id, TL_StationDropdown_ID);
            IList<IWebElement> dropdownValues = GlobalVariables.webDriver.FindElements(By.XPath(TL_StationDropdownValue_Xpath));
            for (int i = 0; i <= dropdownValues.Count; i++)
            {
                if(dropdownValues[i].Text == station1)
                {
                    SelectDropdownValueFromList(attributeName_xpath, TL_StationDropdownValue_Xpath, station1);
                    break;
                }
                else
                {
                    Report.WriteLine("Passed station value does not exists in dropdown");
                }
            }

            Thread.Sleep(2000);
            Click(attributeName_id, TL_StationDropdown_ID);
            IList<IWebElement> dropdownvalues = GlobalVariables.webDriver.FindElements(By.XPath(TL_StationDropdownValue_Xpath));
            for (int i = 0; i <= dropdownvalues.Count; i++)
            {
                if (dropdownvalues[i].Text == station2)
                {
                    SelectDropdownValueFromList(attributeName_xpath, TL_StationDropdownValue_Xpath, station2);
                    break;
                }
                else
                {
                    Report.WriteLine("Passed station value does not exists in dropdown");
                }
            }

            string acutalText = Gettext(attributeName_xpath, TL_StationDropdown_SelectedValue_Xpath);
            Assert.AreEqual(acutalText, station2);
            Report.WriteLine("User is able to select only one station from the dropdown");
        }

    }
}
