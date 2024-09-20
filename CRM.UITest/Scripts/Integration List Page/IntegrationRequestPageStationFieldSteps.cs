using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Integration_List_Page
{
    [Binding]
    public class IntegrationRequestPageStationFieldSteps : Integration
    {
        [Given(@"I arrive on Integration Request page (.*)")]
        public void GivenIArriveOnIntegrationRequestPage(string IntegrationRequestPageTitle)
        {
            Click(attributeName_id, IntegrationIconLink_Dashboard_id);
            Thread.Sleep(3000);
            Click(attributeName_id, IntegrationRequestButton_Id);
            Verifytext(attributeName_xpath, IntegrationRequestPageTitle_Xpath, IntegrationRequestPageTitle);
            Report.WriteLine("Submit Integration Request Page");
        }

        [Then(@"The station must be prepopulated when I have only one station associated")]
        public void ThenTheStationMustBePrepopulatedWhenIHaveOnlyOneStationAssociated()
        {
            string GetStationUI = Gettext(attributeName_id, IntegrationStaionDropdown_Id);
            if (GetStationUI != "Select...")
            {
                Click(attributeName_id, IntegrationStaionDropdown_Id);
                IList<IWebElement> DropDownValUI = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='StationName_chosen']/div/ul/li"));
                int StationCountUI = DropDownValUI.Count;
                if(DropDownValUI.Count > 2)
                {
                    Report.WriteFailure("User is associated to multiple stations");
                    Assert.Fail();
                }
                else
                {
                    Report.WriteLine("Station is selected by default since user is associated to a single station ");
                }
                
            }
            else
            {
                Report.WriteFailure("Station is not selected by default");
                Assert.Fail();
            }
        }

        [When(@"I am associated to multiple station and I select the station field")]
        public void WhenIAmAssociatedToMultipleStationAndISelectTheStationField()
        {
            string GetStationUI = Gettext(attributeName_id, IntegrationStaionDropdown_Id);
            if (GetStationUI == "Select...")
            {
                Report.WriteLine("Station is not selected by default");
            }
            else
            {
                Report.WriteFailure("Some Station is selected by default");
                Assert.Fail();
            }
            Click(attributeName_id, IntegrationStaionDropdown_Id);
            List<string> expectedDropdownValues = new List<string>(new string[] { "TestStation013", "Agile", "Saggezza"});
            IList<IWebElement> DropDownValUI = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='StationName_chosen']/div/ul/li"));
            for (int i = 1; i < DropDownValUI.Count; i++)
            {
                if (expectedDropdownValues.Contains(DropDownValUI[i].Text))
                {
                    Report.WriteLine("Associated Station is displayed in the station dropdown");
                   
                }
                else
                {
                    Report.WriteFailure("Associated Station is not displayed in the station dropdown");
                    Assert.Fail();

                }
            }          
        }

        
        [Then(@"I will only have the option to select stations which I am associated to")]
        public void ThenIWillOnlyHaveTheOptionToSelectStationsWhichIAmAssociatedTo()
        {
            SelectDropdownValueFromList(attributeName_xpath, IntegrationStationDropdownValues_Xpath, "Saggezza");
            Report.WriteLine("Station is selected from the station dropdown list");
        }
        
     
    }
}
