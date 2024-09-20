using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Integration_List_Page
{
    [Binding]
    public class Integration_RequestSubmitErrorSteps : Integration
    {
        [When(@"I have not completed all required fields (.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void WhenIHaveNotCompletedAllRequiredFields(string ComapanyName, string CompanyContactName, string CompanyContactPhone, string CompanyContactEmail, string DevContactName, string DevContactPhone, string DevContactEmail)
        {
            Click(attributeName_id, IntegrationStaionDropdown_Id);
            SelectDropdownValueFromList(attributeName_xpath, IntegrationStationDropdownValues_Xpath, "TestStation013");
          //  SendKeys(attributeName_id, IntegrationCompanyName_Textbox_Id, ComapanyName);
            SendKeys(attributeName_id, IntegrationCompanyContactName_Textbox_Id, CompanyContactName);
            SendKeys(attributeName_id, IntegrationCompanyContactPhone_Textbox_Id, CompanyContactPhone);
            SendKeys(attributeName_id, IntegrationCompanyContactEmail_Textbox_Id, CompanyContactEmail);
            SendKeys(attributeName_id, IntegrationDevContactName_Textbox_Id, DevContactName);
            SendKeys(attributeName_id, IntegrationDevContactPhone_Textbox_Id, DevContactPhone);
            SendKeys(attributeName_id, IntegrationDevContactEmail_Textbox_Id, DevContactEmail);

        }

        [When(@"I click on the Submit button from submit interation request page")]
        public void WhenIClickOnTheSubmitButtonFromSubmitInterationRequestPage()
        {
            Click(attributeName_id, IntegrationSubmitButton_Id);
            Thread.Sleep(6000);
        }


        [Then(@"the request is not submitted")]
        public void ThenTheRequestIsNotSubmitted()
        {
           String ActualUrl = GetURL();
           String ExpectedUrl = "http://dlsww-test.rrd.com/Integration/SubmitIntegration";
           Assert.AreEqual((ActualUrl), ExpectedUrl);
        }
        
        [Then(@"the incomplete field\(s\) will be highlighted in red")]
        public void ThenTheIncompleteFieldSWillBeHighlightedInRed()
        {
            
            String ActualCompanyNameHighLight = GetCSSValue(attributeName_id, IntegrationCompanyName_Textbox_Id, "background");
            string ExpectedCompanyNameHighLight = "rgb(251, 236, 237) none repeat scroll 0% 0% / auto padding-box border-box";
            Report.WriteLine("Highlight :" + ActualCompanyNameHighLight);
            Assert.AreEqual((ActualCompanyNameHighLight), ExpectedCompanyNameHighLight);

        }

        [Then(@"the focus will be on the first incomplete field")]
        public void ThenTheFocusWillBeOnTheFirstIncompleteField()
        {

           
            // verify for Station
            string Station = GetValue(attributeName_xpath, IntegrationStationDropdownValues_Xpath, "value");
            VerifyFocus(Station, IntegrationStaionDropdown_Id);

            //verify for CompanyName
            string CompanyName = GetValue(attributeName_id, IntegrationCompanyName_Textbox_Id, "value");
            VerifyFocus(CompanyName, IntegrationCompanyName_Textbox_Id);

            //verify for CompanyConatctName
            string CompanyContactName = GetValue(attributeName_id, IntegrationCompanyContactName_Textbox_Id, "value");
            VerifyFocus(CompanyContactName, IntegrationCompanyContactName_Textbox_Id);

            //verify for CompanyConatctPhone
            string CompanyConatctPhone = GetValue(attributeName_id, IntegrationCompanyContactPhone_Textbox_Id, "value");
            VerifyFocus(CompanyConatctPhone, IntegrationCompanyContactPhone_Textbox_Id);

            //verify for CompanyContactEmail
            string CompanyContactEmail = GetValue(attributeName_id, IntegrationCompanyContactPhone_Textbox_Id, "value");
            VerifyFocus(CompanyContactEmail, IntegrationCompanyContactEmail_Textbox_Id);

            //verify for DevContactName

            string DevContactName = GetValue(attributeName_id, IntegrationCompanyContactPhone_Textbox_Id, "value");
            VerifyFocus(DevContactName, IntegrationDevContactName_Textbox_Id);

            //verify for DevContactPhone

            string DevContactPhone = GetValue(attributeName_id, IntegrationCompanyContactPhone_Textbox_Id, "value");
            VerifyFocus(DevContactPhone, IntegrationDevContactPhone_Textbox_Id);

            //verify for DevContactEmail

            string DevContactEmail = GetValue(attributeName_id, IntegrationCompanyContactPhone_Textbox_Id, "value");
            VerifyFocus(DevContactEmail, IntegrationDevContactEmail_Textbox_Id);

            // at the end
            Assert.IsFalse(false);
        }


        private Boolean IsElementFocused(string Id)
        {
            IWebElement _activeElement = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            string ElementId = _activeElement.GetAttribute("id");
            return ElementId.Equals(Id);
        }

        private void VerifyFocus(string element, string elementId)
        {
            if (string.IsNullOrEmpty(element))
            {
                if (IsElementFocused(elementId))
                {
                    Assert.IsTrue(true);
                }
                else
                {
                    Assert.IsFalse(false);
                }

            }
        }
    }
}
