using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Configuration;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Carrier_Website
{
    [Binding]
    public class CarrierWebsiteLoginsEdit_PasswordSteps :MaintenaceTools
    {
        CommonMethodsCrm crm = new CommonMethodsCrm();
        [Given(@"I am a System Admin or Pricing Configuration user")]
        public void GivenIAmASystemAdminOrPricingConfigurationUser()
        {
            string userName = ConfigurationManager.AppSettings["username-SystemAdmin"].ToString();
            string password = ConfigurationManager.AppSettings["password-SystemAdmin"].ToString();
            crm.LoginToCRMApplication(userName, password);
            GlobalVariables.webDriver.WaitForPageLoad();            
        }
        
        [Given(@"I am on the Carrier Website Logins Edit Password page")]
        public void GivenIAmOnTheCarrierWebsiteLoginsEditPasswordPage()
        {
            Report.WriteLine("Click on Maintanence Tools icon");
            Click(attributeName_cssselector, MaintenanceToolIcon_css);
            Report.WriteLine("Clicking on Carrier website button");
            scrollElementIntoView(attributeName_id, CarrierWebsite_Button_Id);
            Click(attributeName_id, CarrierWebsite_Button_Id);
            Report.WriteLine("Carrier Website Login page");
            Verifytext(attributeName_xpath, CarrierWebsite_Title_Xpath, "Admin Carrier Website Logins");
            Report.WriteLine("Clicking on edit icon for any page");
            Click(attributeName_xpath, CarrierWebsite_EditIcon_Xpath);
            Thread.Sleep(5000);
        }
        
        [Given(@"I have entered my new Password value into the input field - (.*)")]
        public void GivenIHaveEnteredMyNewPasswordValueIntoTheInputField_(string NPassword)
        {
            Report.WriteLine("Enter New password");
            SendKeys(attributeName_id, CarrierWebsite_EditPasswordTextBox_Id, NPassword);
        }
        
        [When(@"I click inside the text field")]
        public void WhenIClickInsideTheTextField()
        {
           
            VerifyElementPresent(attributeName_id, CarrierWebsite_EditPasswordTextBox_Id, "New Password");
            Click(attributeName_id, CarrierWebsite_EditPasswordTextBox_Id);
            Thread.Sleep(2000);
        }
        
        [When(@"I select the option to Cancel")]
        public void WhenISelectTheOptionToCancel()
        {
            Report.WriteLine("Click on Cancel Button");
            Click(attributeName_id, CarrierWbsite_EditModal_CancelButton_Id);
            Thread.Sleep(3000);
        }
        
        [When(@"I select the option to Save")]
        public void WhenISelectTheOptionToSave()
        {
            Report.WriteLine("Click on Save button");
            Click(attributeName_id, CarrierWebsite_EditModal_SaveButton_Id);
            Thread.Sleep(3000);
        }
        
        [Then(@"I will be able to type my new Password value - (.*)")]
        public void ThenIWillBeAbleToTypeMyNewPasswordValue_(string NPassoword)
        {
            Report.WriteLine("Entering New Password");
            SendKeys(attributeName_id, CarrierWebsite_EditPasswordTextBox_Id, NPassoword);
        }
        
        [Then(@"I will return to the Carrier Website Logins page - (.*)")]
        public void ThenIWillReturnToTheCarrierWebsiteLoginsPage_(string CarrierPageTitle)
        {
            Report.WriteLine("Carrier Website page");
            Verifytext(attributeName_xpath, CarrierWebsite_Title_Xpath, CarrierPageTitle);
        }
        
        [Then(@"my new Password value will be saved - (.*)")]
        public void ThenMyNewPasswordValueWillBeSaved_(string NPassword)
        {
            string FirstCarrierScac = Gettext(attributeName_xpath, CarrierWbsite_FirstCarrierScac_Xpath);
            CRM.UITest.Entities.Proxy.CarrierWebsite carrierValue = new CRM.UITest.Entities.Proxy.CarrierWebsite();
            carrierValue = DBHelper.GetCarrierDetails(FirstCarrierScac);
            Assert.AreEqual(carrierValue.Password, NPassword);
            Report.WriteLine("Edited password value in UI " + NPassword + "is matching with db value " + carrierValue.Password);


        }
        [Given(@"my new Password value is empty")]
        public void GivenMyNewPasswordValueIsEmpty()
        {
            Report.WriteLine("Emptying Password field");
            Clear(attributeName_id, CarrierWebsite_EditPasswordTextBox_Id);
        }

        [Then(@"I will see an error message displaying - Password Field is Required\.")]
        public void ThenIWillSeeAnErrorMessageDisplaying_PasswordFieldIsRequired_()
        {
            Report.WriteLine("Error Message for Empty Field");
            Verifytext(attributeName_id, CarrierWebsite_EditModal_NoPasswrd_Error_Id, "Password Field is Required.");
        }

        [Then(@"The field will be highlighted in red")]
        public void ThenTheFieldWillBeHighlightedInRed()
        {
            Report.WriteLine("Highlighting of Empty field on click of save button");
            string UIPasswordFieldColour = GetCSSValue(attributeName_id, CarrierWebsite_EditPasswordTextBox_Id, "background-color");
            string ActualPasswordFieldColour = "rgba(255, 240, 243, 1)";
            Assert.AreEqual(UIPasswordFieldColour, ActualPasswordFieldColour);

        }


    }
}
