using System.Collections.Generic;
using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Helper.ViewModel;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Availabe_Loads_Board
{
    [Binding]
    public class _95866_CreateFeatureFile_AvailableLoads_UpdateEmailModalSteps : LoadsBoard
    {
        string uri = null;
        string errormessage;
        List<AvailableLoadsViewModel> availableModel;
        IList<IWebElement> refValues;
        List<string> refValuesUI;
        string emailFromDB = null;
        string emailFromUI = string.Empty;
        string carrierSCAC = string.Empty;
        int referenceCount = 0;
        ListScreenExtractResponseFromMGForAvailableLoads ListScreenExtractFromMG = new ListScreenExtractResponseFromMGForAvailableLoads();

        [Given(@"that I navigate to the CRM Available Loads page")]
        public void GivenThatINavigateToTheCRMAvailableLoadsPage()
        {
            string configURL = launchUrl;
            GlobalVariables.webDriver.Navigate().GoToUrl(configURL + "availableLoads");

            bool visible = IsElementPresent(attributeName_xpath, ".//*[@id='cookiescript_accept']", "cookie");

            if (visible == true)
            {
                Click(attributeName_xpath, ".//*[@id='cookiescript_accept']");
            }
        }

        [Given(@"I click on the email button of any displayed load from the grid (.*)")]
        public void GivenIClickOnTheEmailButtonOfAnyDisplayedLoadFromTheGrid(string reference)
        {
            availableModel = ListScreenExtractFromMG.ListScreenExtractFromMGForAvailableLoads();
            GlobalVariables.webDriver.WaitForPageLoad();
            VerifyElementVisible(attributeName_xpath, availableLoadsTitle_xpath, "Available Loads");
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Available loads page loaded");
            refValues = GlobalVariables.webDriver.FindElements(By.XPath(refColumnValues_xpath));
            refValuesUI = new List<string>();
            foreach (var refValueList in refValues)
            {
                refValuesUI.Add(refValueList.Text);
            }
            for (int i = 0; i < refValues.Count; i++)
            {
                if (refValuesUI[i] == reference)
                {
                    scrollpagedown();
                    Click(attributeName_xpath, "//tr[" + (i + 1) + "]/td[12]");
                    Report.WriteLine("Email modal clicked");
                    referenceCount++;
                }

                if (availableModel[i].PrimaryReference == reference)
                {
                    carrierSCAC = availableModel[i].CarrierSCAC;
                    referenceCount++;
                }
            }

            if(referenceCount == 0)
            {
                Assert.Fail("Reference number does not exist");
            }
        }

        [When(@"the email modal is launched")]
        public void WhenTheEmailModalIsLaunched()
        {
            Report.WriteLine("Verifying the header of the email popup");
            WaitForElementVisible(attributeName_xpath, firstRowEmail_Header_xpath, "Claim Load");
            Verifytext(attributeName_xpath, firstRowEmail_Header_xpath, "Claim Load");
        }

        [Given(@"corresponding station is not available for load in CRM")]
        public void GivenCorrespondingStationIsNotAvailableForLoadInCRM()
        {
            Report.WriteLine("Verifying the email from DB");
            emailFromDB = DBHelper.GetToEmail(carrierSCAC);
        }

        [Then(@"the To will display the value from Available Load Email of the associated station details")]
        public void ThenTheToWillDisplayTheValueFromAvailableLoadEmailOfTheAssociatedStationDetails()
        {

            Report.WriteLine("Verifying the display of To email text box");
            VerifyElementVisible(attributeName_id, firstRowEmail_To_id, "To email textbox");
            VerifyElementNotEnabled(attributeName_id, firstRowEmail_To_id, "To email textbox");
            Report.WriteLine("To email text box is not editable");
            emailFromUI = GetValue(attributeName_id, firstRowEmail_To_id, "value");
            Report.WriteLine("Verifying the To email with UI");
            emailFromDB = DBHelper.GetToEmail(carrierSCAC);
            if (emailFromDB != null)
            {
                Assert.AreEqual(emailFromDB, emailFromUI);
                Report.WriteLine("Displaying To email in UI " + emailFromUI + " is matching with DB To email " + emailFromDB);
                Report.WriteLine("Verifying the send button");
                bool value = IsElementEnabled(attributeName_id, firstRowEmail_SendButton_id, "Send Button");
                Assert.AreEqual(value.ToString(), "True");
                Report.WriteLine("Send button is active");
            }
            else
            {
                Assert.Fail("DB To email is" + emailFromDB);
            }

        }

        [Then(@"the To field will be empty")]
        public void ThenTheToFieldWillBeEmpty()
        {
            Report.WriteLine("Verifying the To email with UI");
            if (emailFromDB == null)
            {
                emailFromUI = GetValue(attributeName_id, firstRowEmail_To_id, "value");
                if (emailFromUI == "")
                {
                    Report.WriteLine("corresponding station to a Load is not available in CRM " + carrierSCAC);
                }
            }
            else
            {
                Assert.Fail("corresponding station to a Load is available in CRM " + carrierSCAC);
            }
        }

        [Then(@"the Send button is inactive")]
        public void ThenTheSendButtonIsInactive()
        {
            Report.WriteLine("Verifying the send button");
            bool value = IsElementDisabled(attributeName_id, firstRowEmail_SendButton_id, "Send Button");
            Assert.AreEqual(value.ToString(), "True");
            Report.WriteLine("Send button is inactive");

        }

       
    }
}

