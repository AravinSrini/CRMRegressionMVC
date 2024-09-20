using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Objects;
using CRM.UITest.Scripts.RateToShipment.LTL.ShipmentInformationScreen;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.AddShipment_PageElements_AllUsers
{
    [Binding]
    public class DisplayCustomerNameOnAllPages_StationUsers_ShipmentSteps : AddShipments
    {
        string SubAccount = "ZZZ - GS Customer Test";
        [Given(@"I clicked on the Add Shipment button")]
        public void GivenIClickedOnTheAddShipmentButton()
        {
            Click(attributeName_id, AddShipmentButtionInternal_Id);
            Report.WriteLine("Clicked on Add shipment button");
        }
        
        [Given(@"I clicked on the LTL tile on the Add Shipment page")]
        public void GivenIClickedOnTheLTLTileOnTheAddShipmentPage()
        {
            Click(attributeName_id, AddShipmentLTL_Button_Id);
            Report.WriteLine("Clicked on LTLT tile on Adds shipment page");
        }
        
        [Given(@"I clicked on the ""(.*)"" button on the Add Shipment \(LTL\) page")]
        public void GivenIClickedOnTheButtonOnTheAddShipmentLTLPage(string p0)
        {
            Click(attributeName_xpath, Shipments_ViewRatesButton_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Clicked on View rates button");
        }
        
        
        
        [Given(@"I clicked on the ""(.*)"" button on the Review and Submit page")]
        public void GivenIClickedOnTheButtonOnTheReviewAndSubmitPage(string p0)
        {
            Click(attributeName_xpath, Shipments_ViewRatesButton_xpath);
            Report.WriteLine("Clicked on View rates button");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, ShipResults_CreateShipButton_Xpath);
            Report.WriteLine("Clicked on create shipment button");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ReviewPage_SubmitButton_id);
            Report.WriteLine("Clicked on Submit button");
        }
        
        [Given(@"I expanded the quote details of a non-expired LTL quote")]
        public void GivenIExpandedTheQuoteDetailsOfANon_ExpiredLTLQuote()
        {
            MoveToElement(attributeName_xpath, QuoteExpandInternal_Xpath);
            Click(attributeName_xpath, QuoteExpandInternal_Xpath);
            Report.WriteLine("quote details of a non-expired LTL quote is expanded");

        }
        
        [Given(@"I clicked on the ""(.*)"" button")]
        public void GivenIClickedOnTheButton(string p0)
        {
            Click(attributeName_id, QuoteCreateShipment_Id);
            Report.WriteLine("Clicked on Create shipment button");
        }
        
        [Given(@"I am submitting an LTL Rate Request")]
        public void GivenIAmSubmittingAnLTLRateRequest()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I am on the Quote Results \(LTL\) page")]
        public void GivenIAmOnTheQuoteResultsLTLPage()
        {
            AddQuoteLTL quoteLtl = new AddQuoteLTL();
            quoteLtl.NaviagteToQuoteList();
            //Navigation from Quote List page
            GlobalVariables.webDriver.WaitForPageLoad();            
            quoteLtl.Add_QuoteLTL("Internal", SubAccount);
            quoteLtl.EnterOriginZip("60606");
            quoteLtl.EnterDestinationZip("33126");
            GlobalVariables.webDriver.WaitForPageLoad();
            quoteLtl.selectShippingfromServices("Notification");
            scrollElementIntoView(attributeName_id, LTL_SavedItemDropdown_Id);
            quoteLtl.EnterItemdata("65", "1200");
            SendKeys(attributeName_id, LTL_InusredRate_Id, "1000");
            Click(attributeName_id, LTL_ViewQuoteResults_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
        }
        
        [Given(@"I clicked on either Create Shipment or Create Insured Shipment buttons for any displayed carrier")]
        public void GivenIClickedOnEitherCreateShipmentOrCreateInsuredShipmentButtonsForAnyDisplayedCarrier()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            RateToShipmentLTL rateToShipment = new RateToShipmentLTL();
            Report.WriteLine("I am on Rate Results page");
            rateToShipment.ClickOnCreateShipmentbutton_Quote("Internal");
            Report.WriteLine("I clicked on Create Shipment button on Rate Results page");
        }
        
        [When(@"I am on the Add Shipment \(LTL\) page")]
        public void WhenIAmOnTheAddShipmentLTLPage()
        {
            Verifytext(attributeName_xpath, AddShipment_PageTitle_xpath, "Add Shipment (LTL)");
            Report.WriteLine("Navigated to Shipment list page");
        }
        
        [When(@"I am on the Shipment Results \(LTL\) page")]
        public void WhenIAmOnTheShipmentResultsLTLPage()
        {
            Verifytext(attributeName_xpath, ".//*[@id='page-content-wrapper']//h1", "Shipment Results (LTL)");
            Report.WriteLine("Navigated to Shipment results page");
        }
        
        [When(@"I am on the Review and Submit \(LTL\) page")]
        public void WhenIAmOnTheReviewAndSubmitLTLPage()
        {
            Verifytext(attributeName_xpath, ReviewAndSubmit_Title_Xpath, "Review and Submit Shipment (LTL)");
            Report.WriteLine("Navigated to Review and Submit page");
        }
        
        [When(@"I am on the Shipment Confirmation \(LTL\) page")]
        public void WhenIAmOnTheShipmentConfirmationLTLPage()
        {
            Verifytext(attributeName_xpath, confirmation_pageheader, "Shipment Confirmation (LTL)");
            Report.WriteLine("Navigated to shipment confirmation page");
        }

        [Then(@"The default selection in the customer list should be ""(.*)""")]
        public void ThenTheDefaultSelectionInTheCustomerListShouldBe(string DefaultSelection)
        {
            Verifytext(attributeName_xpath, AllCustomerDropdown_Selection_Internal_Xpath, DefaultSelection);
            Report.WriteLine("Expected default selection is displayed in the customer list dropdown");
        }


        [Then(@"I should no longer have ""(.*)"" as an option from the customer drop down list")]
        public void ThenIShouldNoLongerHaveAsAnOptionFromTheCustomerDropDownList(string DefaultSelect)
        {
            string GetDefaultSelection = Gettext(attributeName_xpath, AllCustomerDropdown_Selection_Internal_Xpath);
            Assert.AreNotEqual(GetDefaultSelection, DefaultSelect);
            Report.WriteLine("Select... is not displayed as the default selection");
        }

        [Given(@"I have selected a customer from my customer list")]
        public void GivenIHaveSelectedACustomerFromMyCustomerList()
        {
            Click(attributeName_xpath, AllCustomerDropdown_Selection_Internal_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, AllCustomerDroppdownValues_Internal_Xpath, SubAccount);
            Report.WriteLine("Customer is been selected from the dropdown");
        }

        [Given(@"I am creating a LTL shipment")]
        public void GivenIAmCreatingALTLShipment()
        {
            Click(attributeName_xpath, AllCustomerDropdown_Selection_Internal_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, AllCustomerDroppdownValues_Internal_Xpath, SubAccount);
            Report.WriteLine("Customer is been selected from the dropdown");
            Click(attributeName_id, AddShipmentButtionInternal_Id);
            Report.WriteLine("Clicked on Add shipment button");
            Click(attributeName_id, AddShipmentLTL_Button_Id);
            Report.WriteLine("Clicked on LTLT tile on Adds shipment page");
            Verifytext(attributeName_xpath, AddShipment_PageTitle_xpath, "Add Shipment (LTL)");
            Report.WriteLine("Navigated to Shipment list page");
            scrollElementIntoView(attributeName_id, ShippingFrom_ClearAddress_Id);
            SendKeys(attributeName_id, ShippingFrom_LocationName_Id, "test");
            SendKeys(attributeName_id, ShippingFrom_LocationAddressLine1_Id, "Address");
            SendKeys(attributeName_id, ShippingFrom_zipcode_Id, "33126");
            scrollElementIntoView(attributeName_id, ShippingTo_LocationName_Id);
            SendKeys(attributeName_id, ShippingTo_LocationName_Id, "testing");
            SendKeys(attributeName_id, ShippingTo_LocationAddressLine1_Id,"addressdest");
            SendKeys(attributeName_id, ShippingTo_zipcode_Id, "90001");
            scrollElementIntoView(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            Click(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            scrollElementIntoView(attributeName_xpath, FreightDesp_SectionText_xpath);
            MoveToElement(attributeName_xpath, FreightDesp_SectionText_xpath);
            Thread.Sleep(6000);
            Click(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id);
            IList<IWebElement> dropdownValues = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='scrollable-dropdown-menu-Origin']/div/span[1]/span/div/span/div/p"));
            for (int i = 0; i < dropdownValues.Count; i++)
            {
                int z = i + 1;
                string value = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='scrollable-dropdown-menu-Origin']/div/span[1]/span/div/span/div[" + z + "]/p")).Text;
                if (value == "55")
                {
                    GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='scrollable-dropdown-menu-Origin']/div/span[1]/span/div/span/div[" + z + "]/p")).Click();
                    break;
                }
            }
            SendKeys(attributeName_id, FreightDesp_FirstItem_NMFC_Id, "34");
            SendKeys(attributeName_id, FreightDesp_FirstItem_Quantity_Id, "1");
            SendKeys(attributeName_id, FreightDesp_FirstItem_Weight_Id, "5");
            SendKeys(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id, "Description");
            SendKeys(attributeName_id, InsuredValue_TextBox_Id, "10000");
        }

        [Given(@"I clicked on either on Create Shipment or Create Insured Shipment buttons on the Shipment Results \(LTL\) page (.*)")]
        public void GivenIClickedOnEitherOnCreateShipmentOrCreateInsuredShipmentButtonsOnTheShipmentResultsLTLPage(string ShipmentType)
        {
            Click(attributeName_xpath, Shipments_ViewRatesButton_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Clicked on View rates button");
            if (ShipmentType == "CreateShipment")
            {
                Click(attributeName_xpath, ShipResults_CreateShipButton_Xpath);
                Report.WriteLine("Clicked on create shipment button");
            }

            if(ShipmentType == "CreateInsuredShipment")
            {
                Click(attributeName_xpath, ShipResults_CreateShipInsuredButton_Xpath);
                Report.WriteLine("Clicked on create insured shipment button");
            }
            
        }

        [Then(@"I will see the Station - Primary Account - Customer Name displayed on the page")]
        public void ThenIWillSeeTheStation_PrimaryAccount_CustomerNameDisplayedOnThePage()
        {
            string StatioName = DBHelper.GetStationName(SubAccount);
            string PrimaryAccountName = DBHelper.GetPrimaryAccountName(SubAccount);
            string GetStationCustomerDisplayUI = Gettext(attributeName_xpath, AddShipmentStationCustomerDisplay_Xpath);
            string ExpectedStationCustomerDisplay = StatioName + " - " + PrimaryAccountName + " - " + SubAccount;
            Assert.AreEqual(ExpectedStationCustomerDisplay, ExpectedStationCustomerDisplay);
            Report.WriteLine("Station - Primary Account - Customer Name displayed on Add shipment page");
        }

        [Then(@"I will see the Station - Primary Account - Customer Name getting displayed on page")]
        public void ThenIWillSeeTheStation_PrimaryAccount_CustomerNameGettingDisplayedOnPage()
        {
            string StatioName = DBHelper.GetStationName(SubAccount);
            string PrimaryAccountName = DBHelper.GetPrimaryAccountName(SubAccount);
            string GetStationCustomerDisplayUI = Gettext(attributeName_xpath, ShipmentResultPageStationCustomerDisplay_Xpath);
            string ExpectedStationCustomerDisplay = StatioName + " - " + PrimaryAccountName + " - " + SubAccount;
            Assert.AreEqual(ExpectedStationCustomerDisplay, ExpectedStationCustomerDisplay);
            Report.WriteLine("Station - Primary Account - Customer Name displayed on Shipment Results page");
        }


        [Then(@"The Station-Primary Account-Customer Name is not editable\.")]
        public void ThenTheStation_PrimaryAccount_CustomerNameIsNotEditable_()
        {
            IsElementDisabled(attributeName_xpath, AddShipmentStationCustomerDisplay_Xpath,"StationCustomerName");
            Report.WriteLine("Station-Primary Account-Customer Name is not editable");
        }

        [Then(@"The Station-Primary Account-Customer Name is not editable")]
        public void ThenTheStation_PrimaryAccount_CustomerNameIsNotEditable()
        {
            IsElementDisabled(attributeName_xpath, ShipmentResultPageStationCustomerDisplay_Xpath, "StationCustomerName");
            Report.WriteLine("Station-Primary Account-Customer Name is not editable");
        }


        [Then(@"I will see the Station - Primary Account - Customer Name of the saved quote displayed on the page")]
        public void ThenIWillSeeTheStation_PrimaryAccount_CustomerNameOfTheSavedQuoteDisplayedOnThePage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I will see the Station - Primary Account - Customer Name of the rate shop displayed on the page,")]
        public void ThenIWillSeeTheStation_PrimaryAccount_CustomerNameOfTheRateShopDisplayedOnThePage()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
