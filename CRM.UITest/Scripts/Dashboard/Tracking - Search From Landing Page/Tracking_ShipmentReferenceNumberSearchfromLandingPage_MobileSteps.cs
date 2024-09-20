using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;



namespace CRM.UITest.Scripts.Dashboard
{
    [Binding]
    public class Tracking_ShipmentReferenceNumberSearchfromLandingPage_MobileSteps: ObjectRepository
    {       
        
        [When(@"I Re-size the browser to mobile device '(.*)' and '(.*)'")]
        public void WhenIRe_SizeTheBrowserToMobileDeviceAnd(int WindowWidth, int WindowHeight)
        {
            Report.WriteLine("I resize the browser to mobile device");
            setBrowserSize(WindowWidth, WindowHeight);
        }

        [Then(@"I click on the on hamburger menu icon in the mobile device")]
        public void ThenIClickOnTheOnHamburgerMenuIconInTheMobileDevice()
        {
            Report.WriteLine("User click on the on hamburger menu icon");
            WaitForElementVisible(attributeName_xpath, hamburgermenuIcon_xpath, "hamburger menu icon");
            Click(attributeName_xpath, hamburgermenuIcon_xpath);
        }

        [Then(@"I should not be displayed with Upload Button in landing page (.*)")]
        public void ThenIShouldNotBeDisplayedWithUploadButtonInLandingPage(string Upload)
        {
            Report.WriteLine("Upload button is not displayed");
            VerifyElementNotVisible(attributeName_xpath, TrackUploadarehomepage_xpath, "Upload");
        }
        [Then(@"I see the results for the entered single reference number in mobile device '(.*)'")]
        public void ThenISeeTheResultsForTheEnteredSingleReferenceNumberInMobileDevice(string Refno)
        {
            Report.WriteLine("Results are displaying for the entered single reference number in mobile device");
            Thread.Sleep(1000);
            string TrackingRefResults = Gettext(attributeName_xpath, TrackingRefno_xpath);
            Assert.AreEqual(Refno, TrackingRefResults);
        }

        [Then(@"I see the results for the entered reference numbers in mobile device '(.*)'")]
        public void ThenISeeTheResultsForTheEnteredReferenceNumbersInMobileDevice(string Ref)
        {
            Report.WriteLine("Results are displaying for the entered reference number");
            List<string> TrackingNumber_UI = IndividualColumnData(TrackingRefno_xpath);

            string[] valuesexp = Ref.Split(',');

            for (int i = 0; i < TrackingNumber_UI.Count; i++)
            {
                
                if (valuesexp.Contains(TrackingNumber_UI[i]))
                {
                    Report.WriteLine("Entered Reference value and Reference value appearing in the Results are same");
                }
                else
                {
                    throw new System.Exception("Entered Reference value and Reference value appearing in the Results are same");
                }

            }
        }

    }
}
