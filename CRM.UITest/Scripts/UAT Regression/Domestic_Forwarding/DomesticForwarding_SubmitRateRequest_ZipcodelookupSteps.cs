using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.UAT_Regression.Domestic_Forwarding
{
    [Binding]
    public class DomesticForwarding_SubmitRateRequest_ZipcodelookupSteps : Mvc4Objects
    {
        [When(@"I enter valid (.*) in the origin section")]
        public void WhenIEnterValidInTheOriginSection(string Ozipcode)
        {
            Report.WriteLine("enter valid origin zip");
            SendKeys(attributeName_id, DF_ZipCode_Id, Ozipcode);
            Click(attributeName_id, DF_Address1_Id);
        }
        
        [When(@"I enter valid (.*) in the destination section")]
        public void WhenIEnterValidInTheDestinationSection(string Dzipcode)
        {
            Report.WriteLine("enter valid destination zip");
            SendKeys(attributeName_id, DF_DesZipcode_Id, Dzipcode);
            Click(attributeName_id, DF_DesAddress1_Id);
           
        }

        [Then(@"Origin Country (.*), State (.*) and City (.*) fields should be autopopulated")]
        public void ThenOriginCountryStateAndCityFieldsShouldBeAutopopulated(string OCountry, string OState, string OCity)
        {
            Report.WriteLine("Origin State And CityFields are autopopulated");
            string expectedstate = Gettext(attributeName_xpath, DF_State_SelectedValue_Xpath);
            Assert.AreEqual(expectedstate, OState);
            string expectedcity = GetValue(attributeName_id, DF_City_Id, "value");
            Assert.AreEqual(expectedcity, OCity);

        }

        [Then(@"Destination Country (.*), State (.*) and City (.*) fields should be autopopulated")]
        public void ThenDestinationCountryStateAndCityFieldsShouldBeAutopopulated(string DCountry, string DState, string DCity)
        {
            Report.WriteLine("Destination State And CityFields are autopopulated");
            string expectedstate = Gettext(attributeName_xpath, DF_DesState_SelectedValue_Xpath);
            Assert.AreEqual(expectedstate, DState);
            string expectedcity = GetValue(attributeName_id, DF_DesCity_Id, "value");
            Assert.AreEqual(expectedcity, DCity);
        }
    }
}
