using System;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System.Threading;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;

namespace CRM.UITest.Scripts.Revised_Csr_flow
{
    [Binding]
    public class RevisedCSR_AdditionsSavedAddressesOnly_BypassapprovalSteps:Submit_CSR
    {
        CommonMethodsCrm crm = new CommonMethodsCrm();

        [Given(@"I have logged into crm application who have access to submit the CSR - (.*), (.*)")]
        public void GivenIHaveLoggedIntoCrmApplicationWhoHaveAccessToSubmitTheCSR_(string userName, string password)
        {
            crm.LoginToCRMApplication(userName, password);            
        }
        
        [Given(@"I am on the customer profile page")]
        public void GivenIAmOnTheCustomerProfilePage()
        {
            Report.WriteLine("I am on Customer Profiles page");
            
           
                Click(attributeName_xpath, UserManagementIcon_Xpath);

            
            WaitForElementVisible(attributeName_xpath, Customerprofiles_Xpath, "Customer Profiles");
        }
        
        [Given(@"I have Clicked on any customer (.*) from the customer profile page")]
        public void GivenIHaveClickedOnAnyCustomerFromTheCustomerProfilePage(string customer)
        {
            Report.WriteLine("Selected the customer from customer profiles");
            SendKeys(attributeName_id, SearchCustomer_id, customer);
           

           Click(attributeName_xpath, SearchedCustomer_Xpath);
         
            Report.WriteLine("Navigated to Customer Details");
            //WaitForElementVisible(attributeName_xpath, CustomerDetailsHeader_Xpath, "Customer Details");
            GlobalVariables.webDriver.WaitForPageLoad();
            Thread.Sleep(5000);

            VerifyElementVisible(attributeName_id, SubmitReviseCSRBtn_id, "Submit a Revised CSR");
            
            
                Click(attributeName_id, SubmitReviseCSRBtn_id);

          
            Click(attributeName_id, GeneralRevision_id);
            
            WaitForElementVisible(attributeName_xpath, AccountInfoHeader_Xpath, "Account Information");
            WaitForElementVisible(attributeName_xpath, RevisedCSRNameDisplay_Xpath, customer);            
        }
        
        [Given(@"I have navigated to saved items and addresses page of revised CSR flow")]
        public void GivenIHaveNavigatedToSavedItemsAndAddressesPageOfRevisedCSRFlow()
        {
            Report.WriteLine("Navigate to Saved Items and Addresses page");
            
            Click(attributeName_id, SavedItemsAddressLeftWizard_id);
                
            
            WaitForElementVisible(attributeName_xpath, Create_A_SavedItem_button_Xpath, "Create a Saved Item");            
            VerifyElementVisible(attributeName_xpath, Create_A_SavedAddress_button_Xpath, "Create a Saved Address");
        }

        [Given(@"I should be displayed with added Addresses and uploaded address template in Review and Submit Page")]
        public void GivenIShouldBeDisplayedWithAddedAddressesAndUploadedAddressTemplateInReviewAndSubmitPage()
        {
            Report.WriteLine("Displaying added Addresses and template");
         
            VerifyElementVisible(attributeName_xpath, ReviewSubmitPage_Address_Name_Value_Xpath, "Name");
            VerifyElementVisible(attributeName_xpath, ReviewSubmitPage_Address_City_Value_Xpath, "City");
            VerifyElementVisible(attributeName_xpath, ReviewSubmitPage_Address_State_Province_Value_Xpath, "State");
            VerifyElementVisible(attributeName_xpath, ReviewSubmitPage_Address_Zip_Value_Xpath, "Zip");
        }

        [When(@"I click on the Submit button on review and submit page")]
        public void WhenIClickOnTheSubmitButtonOnReviewAndSubmitPage()
        {
            Report.WriteLine("Click on Submit button on R&S page");
           
            
            scrollElementIntoView(attributeName_xpath, ReviewSubmitPage_SubmitButton_Xpath);
            
            Click(attributeName_xpath, ReviewSubmitPage_SubmitButton_Xpath);


            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, ".//*[@id='csr-submit']/div/a");
           
        }
        
    }
}
