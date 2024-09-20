using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;


namespace CRM.UITest.Scripts.UAT_Regression.International.Quote
{
    [Binding]
    public class Regression_International_RateRequestNavigationSteps : Mvc4Objects
    {
        [When(@"I select the International from Get a Quote Section")]
        public void WhenISelectTheInternationalFromGetAQuoteSection()
        {
            Report.WriteLine("selecting the International quote from Get a Quote Section");
            Click(attributeName_xpath, IntenationalRadioBtn_Xpath);
           
        }
        
        [When(@"I click on the Type drop down and select  Air Import")]
        public void WhenIClickOnTheTypeDropDownAndSelectAirImport()
        {
            Report.WriteLine("clicking on the Type drop down and select  Air Import");
            MoveToElement(attributeName_xpath, In_Selecttype_Xpath);
            scrollpagedown();
            Click(attributeName_xpath, In_Selecttype_Xpath);
            Thread.Sleep(5000);
            IList<IWebElement> InternationalServiceTypedropdownValues = GlobalVariables.webDriver.FindElements(By.XPath(In_SelecttypeValues_Xpath));
            for (int i = 0; i <= InternationalServiceTypedropdownValues.Count; i++)
            {
                if (InternationalServiceTypedropdownValues[i].Text == "Air - Import")
                {
                   InternationalServiceTypedropdownValues[i].Click();
                    break;
                }
            }
        }
        
        [When(@"I click on the Level drop down and select Air Consolidation")]
        public void WhenIClickOnTheLevelDropDownAndSelectAirConsolidation()
        {
            Report.WriteLine("clicking on the Level drop down and select Air Consolidation");
            Click(attributeName_id, In_airSelect_id);
            IList<IWebElement> InternationalServiceLeveldropdownValues = GlobalVariables.webDriver.FindElements(By.XPath(In_airSelectValues_Xpath));
            for (int i = 0; i <= InternationalServiceLeveldropdownValues.Count; i++)
            {
                if (InternationalServiceLeveldropdownValues[i].Text == "Air Consolidation")
                {
                    InternationalServiceLeveldropdownValues[i].Click();
                    break;
                }
            }
        }
        
        [When(@"I select the get quote")]
        public void WhenISelectTheGetQuote()
        {
            Report.WriteLine("clicking on the get quote");
            Click(attributeName_xpath, QuoteButton_Xpath);
        }
        
        [When(@"I click Continue")]
        public void WhenIClickContinue()
        {
            Report.WriteLine("waiting for page load");
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [When(@"I select International service type, level and Click on Get Quote button from Dashboard page"),Scope(Tag= "35471")]
        public void WhenISelectInternationalServiceTypeLevelAndClickOnGetQuoteButtonFromDashboardPage()
        {
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
        }

        [When(@"I select International service type, level from Get Quote page"), Scope(Tag = "35471")]
        public void WhenISelectInternationalServiceTypeLevelFromGetQuotePage()
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




        [Then(@"I must land on the Rate Request: Shipment Information page for International")]
        public void ThenIMustLandOnTheRateRequestShipmentInformationPageForInternational()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            VerifyElementVisible(attributeName_xpath,ShipDF_AddShipmentHeader_Xpath,"raterequestheader");
            VerifyElementVisible(attributeName_xpath, ShipDF_ShipmentService_Xpath, "Internationalservice");
        }
    }
}
