using System;
using System.Threading;
using TechTalk.SpecFlow;
using CRM.UITest.Objects;
using CRM.UITest.Helper.ViewModel.RateModel;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using CRM.UITest.CommonMethods;
using System.Configuration;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace CRM.UITest.Scripts.UAT_Regression.International.Quote
{
    [Binding]
    public class International_StartNewRateRequestButtonSteps: Mvc4Objects
    {
        [Given(@"I am ashp\.inquiry user")]
        public void GivenIAmAshp_InquiryUser()
        {
            string username = ConfigurationManager.AppSettings["username-Both"].ToString();
            string password = ConfigurationManager.AppSettings["password-Both"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"I select International service type, level and Click on Get Quote button from Dashboard page")]
        public void GivenISelectInternationalServiceTypeLevelAndClickOnGetQuoteButtonFromDashboardPage()
        {
            //Selecting International from Dashboard  
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, DasboardHeader_Xpath, "Dashboard");            
            Report.WriteLine("Selecting international type");            
            scrollElementIntoView(attributeName_xpath, IntenationalRadioBtn_Xpath);
            WaitForElementVisible(attributeName_xpath, DasboardHeader_Xpath, "International");
            Click(attributeName_xpath, IntenationalRadioBtn_Xpath);
            WaitForElementVisible(attributeName_xpath, In_Selecttype_Xpath, "Select Type...");
            Click(attributeName_xpath, In_Selecttype_Xpath);
            SelectDropdownlistvalue(attributeName_xpath, In_SelecttypeValues_Xpath, "Air - Import");                        
            Report.WriteLine("Selecting international level");
            Click(attributeName_id, In_airSelect_id);
            SelectDropdownlistvalue(attributeName_xpath, In_airSelectValues_Xpath, "Air Consolidation");            
            Click(attributeName_xpath, QuoteButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
        }               

        [Given(@"I select International service type, level from Get Quote page")]
        public void GivenISelectInternationalServiceTypeLevelFromGetQuotePage()
        {
            //Selecting International from Quote module
            Report.WriteLine("Click on quotes module");
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementNotVisible(attributeName_id, LoadingSymbol_id, "loading symbol");
            WaitForElementNotVisible(attributeName_id, LoadingSymbol_id, "loading symbol");
            Click(attributeName_id, QuoteIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Navigate to rate request service page");
            Click(attributeName_id, SubmitRateRequestButton_Id);
            WaitForElementVisible(attributeName_id, International_TileLabel_Id, "International");
            Click(attributeName_id, International_TileLabel_Id);
            WaitForElementVisible(attributeName_xpath, International_TypeDropdown_Xpath, "Select Type...");
            Click(attributeName_xpath, International_TypeDropdown_Xpath);            
            IList<IWebElement> DropDownList_type = GlobalVariables.webDriver.FindElements(By.XPath(International_TypeDropdownValues_Xpath));
            int DropDownCount = DropDownList_type.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList_type[i].Text == "Air - Import")
                {
                    DropDownList_type[i].Click();
                    break;
                }
            }
            WaitForElementVisible(attributeName_xpath, International_LevelDropdown_Xpath, "Select Level...");
            Click(attributeName_xpath, International_LevelDropdown_Xpath);
            
            IList<IWebElement> DropDownList_level = GlobalVariables.webDriver.FindElements(By.XPath(International_LevelDropdownValues_Xpath));
            int DropDownCount_level = DropDownList_level.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList_level[i].Text == "Air Consolidation")
                {
                    DropDownList_level[i].Click();
                    break;
                }
            }
            Click(attributeName_id, International_ContinueButton_Id);
        }

        [Given(@"I am on International Shipment Information page of RateRequest")]
        public void GivenIAmOnInternationalShipmentInformationPageOfRateRequest()
        {
            //Entering data in Origin Location Section
            Report.WriteLine("Entering data in Origin location section");
            GlobalVariables.webDriver.WaitForPageLoad();            
            WaitForElementVisible(attributeName_id, In_OLocationName_id, "oLocationName");
            SendKeys(attributeName_id, In_OLocationName_id, "OLName");
            SendKeys(attributeName_id, In_OAddress1_id, "OAddress");
            scrollpagedown();
            Click(attributeName_xpath, In_OCountry_Xpath);            
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(In_OCountryValues_Xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == "United States")
                {
                    DropDownList[i].Click();
                    break;
                }
            }            
            SendKeys(attributeName_id, In_OZip_id, "33126");

            //Entering data in Origin Contact Information Section
            Report.WriteLine("Entering data in Origin contact section");
            Click(attributeName_id, In_OContactName_id);
            SendKeys(attributeName_id, In_OContactName_id, "OContactName");
            SendKeys(attributeName_id, In_OEmail_id, "test@rrd.com");
            SendKeys(attributeName_id, In_OPhoneNo_id, "9086567890");
        }

        [Given(@"I entered data in Destination section of International RateRequest")]
        public void GivenIEnteredDataInDestinationSectionOfInternationalRateRequest()
        {
            //Entering data in Destination Location Details Section
            Report.WriteLine("Entering data in Destination location section");
            scrollElementIntoView(attributeName_id, In_dLocationName_id);            
            SendKeys(attributeName_id, In_dLocationName_id, "DLName");
            SendKeys(attributeName_id, In_dAddress1_id, "DAddress");
            Click(attributeName_xpath, In_dCountry_Xpath);            
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(In_dCountryValues_Xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == "United States")
                {
                    DropDownList[i].Click();
                    break;
                }
            }            
            SendKeys(attributeName_id, In_dZip_id, "60606");

            //Entering data in Destination Contact Details Section
            Report.WriteLine("Entering data in Destination contact section");
            Click(attributeName_id, In_dContactName_id);
            SendKeys(attributeName_id, In_dContactName_id, "DContactName");
            SendKeys(attributeName_id, In_dEmail_id, "test@rrd.com");
            SendKeys(attributeName_id, In_dPhoneNo_id, "9086567999");
        }

        [Given(@"I entered data in Shipment Details and Freight Description section")]
        public void GivenIEnteredDataInShipmentDetailsAndFreightDescriptionSection()
        {
            //Entering data in Shipment details
            Report.WriteLine("Entering data in Shipment details");
            MoveToElement(attributeName_xpath, In_incoterms_Xpath);
            Click(attributeName_xpath, In_incoterms_Xpath);
            
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(In_incotermsValues_Xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == "FCA - Free Carrier")
                {
                    DropDownList[i].Click();
                    break;
                }
            }
            SendKeys(attributeName_id, In_commercialInvoiceVal_id, "12");

            //Entering data in Freight Description section
            Report.WriteLine("Entering data in Freight Description section");
            scrollpagedown();
            Click(attributeName_id, In_pieces_id);
            SendKeys(attributeName_id, In_pieces_id, "2");
            SendKeys(attributeName_id, In_weight_id, "1200");
            SendKeys(attributeName_id, In_length_id, "10");
            SendKeys(attributeName_id, In_width_id, "10");
            SendKeys(attributeName_id, In_height_id, "10");
            scrollpagedown();
            SendKeys(attributeName_xpath, In_description_Xpath, "test");
            
        }

        [Given(@"I navigated to Confirmation page")]
        public void GivenINavigatedToConfirmationPage()
        {
            scrollpagedown();            
            SendKeys(attributeName_id, In_declaredVal_id, "12");

            //Click on save button
            Report.WriteLine("Click on Save and Continue button");
            MoveToElement(attributeName_id, In_SaveandContinueBtn_id);
            Click(attributeName_id, In_SaveandContinueBtn_id);

            //Click on submit button in Review and Submit Page
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Click on Save button in Review and Submit Page");
            MoveToElement(attributeName_id, In_SumitBtn_id);
            Click(attributeName_id, In_SumitBtn_id);
        }
        
        [When(@"I click on Start New Rate Request button"), Scope(Tag = "35476")]
        public void WhenIClickOnStartNewRateRequestButton()
        {            
            Report.WriteLine("Click on Start New Shipment button-Confirmation Page");
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, In_Confirmation_Header_Xpath, "Confirmation");
            MoveToElement(attributeName_xpath, In_ConfirmationPage_NewShipment_Xpath);
            Click(attributeName_xpath, In_ConfirmationPage_NewShipment_Xpath);
        }
        
        [Then(@"I should be navigating back to Get Quote tiles page")]
        public void ThenIShouldBeNavigatingBackToGetQuoteTilesPage()
        {            
            Report.WriteLine("Navigated to Quote Tiles page");
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_id, Int_Shipment_Tile_Id, "International");
            VerifyElementVisible(attributeName_id, Int_Shipment_Tile_Id, "International");
        }
    }
}
