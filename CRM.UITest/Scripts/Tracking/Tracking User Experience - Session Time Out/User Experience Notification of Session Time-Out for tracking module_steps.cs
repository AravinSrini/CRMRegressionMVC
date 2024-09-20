using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Tracking
{
    [Binding]
    public sealed class User_Experience_Notification_of_Session_Time_Out_for_tracking_module_steps : ObjectRepository
    {

        [Then(@"I will be able to see Yes and Cancel button in the PopUp")]
        public void ThenIWillBeAbleToSeeYesAndCancelButtonInThePopUp()
        {
            Report.WriteLine("Verify Yes button present in the PopUp");
            VerifyElementPresent(attributeName_xpath, SessionTimeoutPopUp_Yesbutton_Xpath, "Session TimeOut PopUp Yes button");

            Report.WriteLine("Verify No button present in the PopUp");
            VerifyElementPresent(attributeName_xpath, SessionTimeoutPopUp_Nobutton_Xpath, "Session TimeOut PopUp No button");
        }


        [Then(@"I Click on Yes button in the Notification PopUp")]
        public void ThenIClickOnYesButtonInTheNotificationPopUp()
        {
            Click(attributeName_xpath, SessionTimeoutPopUp_Yesbutton_Xpath);
            Thread.Sleep(3000);
        }

        [Then(@"I will be redirecting to CRM Landing Page")]
        public void ThenIWillBeRedirectingToCRMLandingPage()
        {
            Thread.Sleep(6000);
            //Click(attributeName_xpath, SessionTimeOutYesIDPbutton_Xpath);
            string configURL = launchUrl;
            Report.WriteLine("Verifying the Navigation to CRM Landing Page");
            string ExpectedResultPagrURL = launchUrl;
            if (GetURL() == ExpectedResultPagrURL)
            {
                Report.WriteLine("User is Navigated to CRM Landing Page");
            }
            else
            {
                Report.WriteLine("User is not Navigated to CRM Landing Page");
                throw new Exception("User is not Navigated to CRM Landing Page");

            }
        }

        [Then(@"I Click on No button in the Notification PopUp")]
        public void ThenIClickOnNoButtonInTheNotificationPopUp()
        {
            Click(attributeName_xpath, SessionTimeoutPopUp_Nobutton_Xpath);

            Thread.Sleep(3000);
        }


        [Then(@"I will remain in the same active page and my session will be continued")]
        public void ThenIWillRemainInTheSameActivePageAndMySessionWillBeContinued()
        {
            string configURL = launchUrl;
            Report.WriteLine("Verifying user's section is active or not");
            string LandingPagrURL = configURL;
            if (GetURL() != LandingPagrURL)
            {
                Report.WriteLine("User is in same page");
                Click(attributeName_cssselector, TrackingIcon_css);
                

               
                Report.WriteLine("Verifying user session is active or not");
                string resultPagrURL = configURL + "Tracking/TrackingIndex";
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

        [Then(@"I can see warning message which notify to user that session is going to expire in one minute")]
        public void ThenICanSeeWarningMessageWhichNotifyToUserThatSessionIsGoingToExpireInOneMinute()
        {
            string exp1 = "Your session is going to expire in one minute due to inactivity.";
            string exp2 = "Are you sure you want to exit the session?";
            string act1=Gettext(attributeName_xpath, SessionExpireDueToInactivity_Text_Xpath);
            string act2 = Gettext(attributeName_xpath, AreYouSureWantToExit_Text_Xpath);
            if(exp1== act1)
            {
                Report.WriteLine("verified message:Your session is going to expire in one minute due to inactivity.");
            }
            else
            {
                throw new Exception("Unable to verified message:Your session is going to expire in one minute due to inactivity.");
            }
            if (exp2 == act2)
            {
                Report.WriteLine("verified message:Are you sure you want to exit the session?");
            }
            else
            {
                throw new Exception("Unable to verified message:Are you sure you want to exit the session?");
            }
            //Verifytext(attributeName_xpath, SessionExpireDueToInactivity_Text_Xpath, "Your session is going to expire in one minute due to inactivity.");
            //Verifytext(attributeName_xpath, AreYouSureWantToExit_Text_Xpath, "Are you sure you want to exit the session?");
        }


        [Then(@"I am inactive for another one more minute")]
        public void ThenIAmInactiveForAnotherOneMoreMinute()
        {

            Report.WriteLine("Wait another one more Minutes");
            Thread.Sleep(60000);
            //ImplicitWait(60000);
        }

        [Then(@"I will receive a logout popup says that session has been expired due to inactivity")]
        public void ThenIWillReceiveALogoutPopupSaysThatSessionHasBeenExpiredDueToInactivity()
        {
            Report.WriteLine("Verifying warning message pop up text message");
            Verifytext(attributeName_xpath,SessionTimeOutLogoutPopUp_Xpath, "LOGOUT");
        }

        [Then(@"I will receive a notification says that session has been expired due to inactivity")]
        public void ThenIWillReceiveANotificationSaysThatSessionHasBeenExpiredDueToInactivity()
        {
            //ScenarioContext.Current.Pending();
            string expected = "Your session has expired due to inactivity.";
            string actual=Gettext(attributeName_xpath, SessionTimeOutLogoutPopUpText_Xpath);
            Assert.AreEqual(expected, actual);
            //Verifytext(attributeName_xpath,SessionTimeOutLogoutPopUpText_Xpath, "Your session has expired due to inactivity.");
        }

        [Then(@"I will be able to see OK button in pop up")]
        public void ThenIWillBeAbleToSeeOKButtonInPopUp()
        {
            Report.WriteLine("Verify OK button present in the PopUp");
            VerifyElementPresent(attributeName_id,SessionTimeOutLogoutPopUpOKbutton_id, "Session TimeOut PopUp OK button");
        }

        [Then(@"I have clicked on OK button")]
        public void ThenIHaveClickedOnOKButton()
        {
            Click(attributeName_id,SessionTimeOutLogoutPopUpOKbutton_id);
        }




    }
}
