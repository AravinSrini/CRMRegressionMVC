using System;
using System.Threading;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Quote.LTL
{
    [Binding]
    public class UserExperienceNotificationofSessionTimeOut_LTLSteps : ObjectRepository
    {
        [When(@"I am inactive for Fourteen minutes")]
        public void WhenIAmInactiveForFourteenMinutes()
        {
            Report.WriteLine("Wait for 14 Minutes");

			//set time to 4 min for testing
			//Thread.Sleep(240000);

			//time for testing when idle for 14 min
			Thread.Sleep(840000);
			
        }

        [Then(@"I will receive a notification saying that my session will terminate in one minute due to inactivity")]
        public void ThenIWillReceiveANotificationSayingThatMySessionWillTerminateInOneMinuteDueToInactivity()
        {
            Thread.Sleep(2000);
            string ExpectedText = "Warning";
            string UIActualText = Gettext(attributeName_xpath, SessionTimeOutWarningPopUp_Xpath);
            Verifytext(attributeName_xpath, SessionTimeOutWarningPopUp_Xpath, "Warning");
            if (ExpectedText == UIActualText)
            {
                Report.WriteLine("Session TimeOut Notification Pop-up appears at 14th Minute");
            }
            else
            {
                Report.WriteLine("Session TimeOut Notification Pop-up is not appeared at 14th Minute");
                throw new Exception("Session TimeOut Notification Pop-up not appears at 14th Minute");
            }
        }

        [Then(@"I will remain in the same active page and my session will be continued in Shipment Information Page")]
        public void ThenIWillRemainInTheSameActivePageAndMySessionWillBeContinuedInShipmentInformationPage()
        {
            string configURL = launchUrl;
            Report.WriteLine("Verifying user's section is active or not");
            string LandingPagrURL = configURL;
            if (GetURL() != LandingPagrURL)
            {
                Report.WriteLine("User is in same page");
                Assert.AreEqual("Get Quote (LTL)", Gettext(attributeName_xpath, GetQuoteLTLText_Xpath));

                Report.WriteLine("Verifying user session is active or not");
                string resultPagrURL = configURL + "Rate/ShipmentInformation";
                if (GetURL() == resultPagrURL)
                {
                    Report.WriteLine("User's session is active");
                }
                else
                {
                    Report.WriteLine("User's session has been terminated");
                    throw new Exception("User's session has been terminated" + GetURL());
                }
            }
            else
            {
                throw new Exception("User is Navigated to CRM Landing Page");
            }
        }
    }
}
