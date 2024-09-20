using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Threading;
using CRM.UITest.CommonMethods;
using System.Configuration;

namespace CRM.UITest.Scripts.Quote.Domestic_Forwarding
{
    [Binding]
    public class Domestic_Forwarding_tile_on_Shipment_Service_screen_in_rate_request_processSteps_Desktop : ObjectRepository
    {
        [Given(@"I am a DLS User and login into application with valid Username and Password")]
        public void GivenIAmADLSUserAndLoginIntoApplicationWithValidUsernameAndPassword()
        {
            string username = ConfigurationManager.AppSettings["username-ExtuserCustDropdown"].ToString();
            string password = ConfigurationManager.AppSettings["password-ExtuserCustDropdown"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [Then(@"User should be displayed with the Domestic Forwarding Type pop (.*)")]
        public void ThenUserShouldBeDisplayedWithTheDomesticForwardingTypePop(string PopUpHeaderText)
        {
            WaitForElementVisible(attributeName_xpath, DomesticForwardingModalText_xpath, PopUpHeaderText);
            Verifytext(attributeName_xpath, DomesticForwardingModalText_xpath, PopUpHeaderText);
        }


        [Then(@"Verify user is able to see Type Drop down and able to select the option from the drop down '(.*)'")]
        public void ThenVerifyUserIsAbleToSeeTypeDropDownAndAbleToSelectTheOptionFromTheDropDown(string TypeOption)
        {
            VerifyElementPresent(attributeName_xpath, DomForwarding_TypeDropdown_Xpath, "SelectType");
            Click(attributeName_xpath, DomForwarding_TypeDropdown_Xpath);
           
            List<string> TypeDropDownList = GetDropdownValues(attributeName_id, "rate_domestic_forward_type_chosen", "li");
            //TypeDropDownList.Remove("Select Type..."); ---> This function doesn't work on this dropdown. Hence commenting it.            
            for(int i=0; i< TypeDropDownList.Count(); i++)
            {
                if(TypeDropDownList[i].Contains("Next Flight Out"))
                {
                    SelectDropdownValueFromList(attributeName_id, "rate_domestic_forward_type_chosen", TypeDropDownList[i]);
                    break;
                }
            }            
            Report.WriteLine("Verifing Selected Type Value");
            string ActualText = Gettext(attributeName_xpath, value_SelectedFromDropDown);        
            Assert.AreEqual(TypeOption, ActualText);
        }

        [Then(@"Verify user is able to see the Continue button (.*) in the pop up")]
        public void ThenVerifyUserIsAbleToSeeTheContinueButtonInThePopUp(string ContinueBtn)
        {
            Verifytext(attributeName_id, DomForwarding_ContinueButton_Id, ContinueBtn);
        }

        [Then(@"Verify user is able to see the Close button '(.*)' in the pop up")]
        public void ThenVerifyUserIsAbleToSeeTheCloseButtonInThePopUp(string CloseBtn)
        {
            Verifytext(attributeName_xpath, DomForwarding_CloseBtn_xpath, CloseBtn);            
        }

        [When(@"I click on the Continue button in the pop up")]
        public void WhenIClickOnTheContinueButtonInThePopUp()
        {
            WaitForElementVisible(attributeName_id, DomForwarding_ContinueButton_Id, "Continue");
            Click(attributeName_id, DomForwarding_ContinueButton_Id);          
        }

        [Then(@"Verify user is able to see the error message (.*) in the pop up")]
        public void ThenVerifyUserIsAbleToSeeTheErrorMessageInThePopUp(string ErrorMsg)
        {
            Report.WriteLine("Verifing error message");
            string ActualError = Gettext(attributeName_xpath, DomForwardingErrorMsg_xpath);            
            Assert.AreEqual(ErrorMsg.ToUpper(), ActualError);
        }

        [When(@"I click on the Type drop down and select any option '(.*)' from the list")]
        public void WhenIClickOnTheTypeDropDownAndSelectAnyOptionFromTheList(string TypeOption)
        {
            Thread.Sleep(5000);
            Click(attributeName_xpath, DomForwarding_TypeDropdown_Xpath);
            List<string> TypeDropDownList = GetDropdownValues(attributeName_id, "rate_domestic_forward_type_chosen", "li");
            //TypeDropDownList.Remove("Select Type...");  ---> This function doesn't work on this dropdown. Hence commenting out.
            
            for (int i = 0; i < TypeDropDownList.Count(); i++)
            {
                if (TypeDropDownList[i].Contains(TypeOption))
                {
                    SelectDropdownValueFromList(attributeName_id, "rate_domestic_forward_type_chosen", TypeDropDownList[i]);
                    break;
                }
            }
        }

        [Then(@"Verify user is still in the Shipment Services screen (.*)")]
        public void ThenVerifyUserIsStillInTheShipmentServicesScreen(string ServicesPageHeader)
        {
            Verifytext(attributeName_xpath, ShipmentInformationText_Xpath, ServicesPageHeader);
        }

        [When(@"I click on the Close button in the pop up")]
        public void WhenIClickOnTheCloseButtonInThePopUp()
        {
            Click(attributeName_xpath, DomForwarding_CloseBtn_xpath);
        }

        [Given(@"I am able to see the '(.*)' in the Dashboard page for the user")]
        public void GivenIAmAbleToSeeTheInTheDashboardPageForTheUser(string UserDropdown)
        {
            Report.WriteLine("User can see UserDropdown");
            //WaitForElementNotVisible(attributeName_id, LoadingSymbol_id, "loading symbol");
            Verifytext(attributeName_id, UserDropdown_id, UserDropdown);
        }

        [Then(@"User should be navigated to the old Shipment Locations and Dates screen and able to see '(.*)' , '(.*)' and '(.*)'")]
        public void ThenUserShouldBeNavigatedToTheOldShipmentLocationsAndDatesScreenAndAbleToSeeAnd(string RateRequestPageHeader, string RateRequestSubHeadingText, string BacktoQuoteList)
        {
            Report.WriteLine("Rate request page header");
            Verifytext(attributeName_cssselector, RateRequestHeading_css, RateRequestPageHeader);

            VerifyElementPresent(attributeName_xpath, DomFor_RateRequestHeadingSubText, RateRequestSubHeadingText);
            string subheadingOfRateRequest = Gettext(attributeName_xpath, DomFor_RateRequestHeadingSubText);
            string Subheading_UI = subheadingOfRateRequest.Remove(subheadingOfRateRequest.Length - 20);
            Assert.AreEqual(RateRequestSubHeadingText, Subheading_UI);

            Verifytext(attributeName_id, RateBacktoQuoteListBtn_id, BacktoQuoteList);
        }

        [Then(@"I should See the text '(.*)', '(.*)' in the quotes landing page")]
        public void ThenIShouldSeeTheTextInTheQuotesLandingPage(string QuotespageTitle, string QuotespageSubtitle)
        {
            Report.WriteLine("User should navigate to the Quotes landing page");
            Verifytext(attributeName_cssselector, QuotespageHeading_css, QuotespageTitle);
            Verifytext(attributeName_cssselector, Quotespagesubheading_css, QuotespageSubtitle);
        }


        [Then(@"Verify the service Type and level in the Shipment Locations and Dates screen '(.*)', '(.*)' and '(.*)'")]
        public void ThenVerifyTheServiceTypeAndLevelInTheShipmentLocationsAndDatesScreenAnd(string DomFor_SectionHeaderText, string ServiceType, string ServiceLevel)
        {
            Report.WriteLine("Verify the Rate request Section header");
            Verifytext(attributeName_xpath, DomFor_ShipmentInfoSectionHeader_xpath, DomFor_SectionHeaderText);
            
            Report.WriteLine("I should able to see the Service Type as Domestic Forwarding");
            VerifyElementPresent(attributeName_id, RateServiceType_id, ServiceType);
            string Sevicetype_UI = Gettext(attributeName_id, RateServiceType_id);
            string ser = Sevicetype_UI.Remove(0, 9);
            Assert.AreEqual(ser, ServiceType);

            string Sevicelevel_UI = Gettext(attributeName_xpath, DomFor_ShipmentInforServiceLevel_xpath);
            Assert.AreEqual(Sevicelevel_UI, ServiceLevel);
        }


















    }
}
