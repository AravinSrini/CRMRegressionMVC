using System;
using System.Collections.Generic;
using System.Configuration;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;

namespace CRM.UITest.Scripts.QuoteToShipment.LTL
{
    [Binding]
    public class SavedQuoteToShipment_MultipleRatesReturnedMVC5ShipEntryUserSteps : AddShipments
    {
        AddQuoteLTL quote = new AddQuoteLTL();
        QuoteToShipmentLTL quoteToShipment = new QuoteToShipmentLTL();

        [Given(@"I am a shp\.entry user")]
        public void GivenIAmAShp_EntryUser()
        {
            string username = ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();
            string password = ConfigurationManager.AppSettings["ExternalUserPassword"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [When(@"I am on shipment results page of saved quote to shipment process")]
        public void WhenIAmOnShipmentResultsPageOfSavedQuoteToShipmentProcess()
        {
            quote.NaviagteToQuoteList();
            quote.Add_QuoteLTL("external", "ZZZ - Czar Customer Test");
            quote.EnterOriginZip("90001");
            quote.EnterDestinationZip("90087");
            quote.EnterItemdata("50", "1");
            quote.ClickViewRates();
            Report.WriteLine("I am on Rate Results page");
            Report.WriteLine("I clicked on Save Rate as Quote Link on Rate Result page");
            quoteToShipment.ClickOnSaveRateAsQuoteLink("External");
            Report.WriteLine("I am on the Quote Details Section");
            GlobalVariables.webDriver.WaitForPageLoad();
            string QuoteRequestNum = Gettext(attributeName_id, "referenceNumber-value");
            Click(attributeName_id,QuoteIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();

            int Quotelist = 0;
            Report.WriteLine("Clicking on Create Shipment from Quote Details Section");

            SendKeys(attributeName_id, ShipmentListSearchBox_Id, QuoteRequestNum);
            Quotelist = GetCount(attributeName_xpath, ".//*[@id='QuotesGrid']/tbody/tr");
            if (Quotelist > 1)
            {

                Click(attributeName_xpath, Shipment_exandableTrigger_Xpath);

                WaitForElementVisible(attributeName_id, QuoteCreateShipment_Id, "CreateShipment");

            }
            else
            {
                Report.WriteLine("No records");
            }

            WaitForElementVisible(attributeName_id, QuoteCreateShipment_Id, "Create SHipment");
            Click(attributeName_id, QuoteCreateShipment_Id);
            SendKeys(attributeName_id, ShippingFrom_LocationName_Id, "locationName");
            SendKeys(attributeName_id, ShippingFrom_LocationAddressLine1_Id, "locationAddress");
            SendKeys(attributeName_id, ShippingTo_LocationName_Id, "destinationName");
            SendKeys(attributeName_id, ShippingTo_LocationAddressLine1_Id, "destinationAddress");
            MoveToElement(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id);
            SendKeys(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id, "desc");
            MoveToElement(attributeName_xpath, Shipment_viewresults_Xpath);
            Click(attributeName_xpath, Shipment_viewresults_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I am on shipment results page of saved standard quote to shipment process")]
        public void GivenIAmOnShipmentResultsPageOfSavedStandardQuoteToShipmentProcess()
        {
            quote.NaviagteToQuoteList();
            quote.Add_QuoteLTL("external", "ZZZ - Czar Customer Test");
            quote.EnterOriginZip("90001");
            quote.EnterDestinationZip("90087");
            quote.EnterItemdata("50", "1");
            quote.ClickViewRates();
            Report.WriteLine("I am on Rate Results page");
            quoteToShipment.ClickOnSaveRateAsQuoteLink("External");
            Report.WriteLine("I clicked on Save Rate as Quote Link on Rate Result page");

            Report.WriteLine("I am on the Quote Details Section");
            GlobalVariables.webDriver.WaitForPageLoad();
            string QuoteRequestNum = Gettext(attributeName_id, "referenceNumber-value");
            Click(attributeName_id, QuoteIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();

            int Quotelist = 0;
            Report.WriteLine("Clicking on Create Shipment from Quote Details Section");

            SendKeys(attributeName_id, ShipmentListSearchBox_Id,QuoteRequestNum);
            Quotelist = GetCount(attributeName_xpath, ".//*[@id='QuotesGrid']/tbody/tr");
            if (Quotelist > 1)
            {

                Click(attributeName_xpath, Shipment_exandableTrigger_Xpath);

                WaitForElementVisible(attributeName_id, QuoteCreateShipment_Id, "CreateShipment");

            }
            else
            {
                Report.WriteLine("No records");
            }

            WaitForElementVisible(attributeName_id, QuoteCreateShipment_Id, "Create SHipment");
            Click(attributeName_id, QuoteCreateShipment_Id);
            SendKeys(attributeName_id, ShippingFrom_LocationName_Id, "locationName");
            SendKeys(attributeName_id, ShippingFrom_LocationAddressLine1_Id, "locationAddress");
            SendKeys(attributeName_id, ShippingTo_LocationName_Id, "destinationName");
            SendKeys(attributeName_id, ShippingTo_LocationAddressLine1_Id, "destinationAddress");
            MoveToElement(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id);
            SendKeys(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id, "desc");
            MoveToElement(attributeName_xpath, Shipment_viewresults_Xpath);
            Click(attributeName_xpath, Shipment_viewresults_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I Enter an insured Value")]
        public void GivenIEnterAnInsuredValue()
        {
            Report.WriteLine("Entering Insured Value");
            SendKeys(attributeName_id, ShipResults_InsuredRateTextbox_Id, "100");
        }

        [When(@"I click on the Show Insured Rate Button")]
        public void WhenIClickOnTheShowInsuredRateButton()
        {
            Report.WriteLine("clicking on the Show Insured Rate Button");
            Click(attributeName_id, ShipResults_ShowInsuredRateButton_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [When(@"I am on shipment results page of saved insured quote to shipment process")]
        public void WhenIAmOnShipmentResultsPageOfSavedInsuredQuoteToShipmentProcess()
        {
            quote.NaviagteToQuoteList();
            quote.Add_QuoteLTL("external", "ZZZ - Czar Customer Test");
            quote.EnterOriginZip("90001");
            quote.EnterDestinationZip("90087");
            quote.EnterItemdata("50", "1");
            SendKeys(attributeName_id, LTL_EnterInsuredValue_Id, "1000");
            quote.ClickViewRates();
            Report.WriteLine("I am on Rate Results page");
            Click(attributeName_xpath, quoteToShipment.SaveInsuredRateoption_Xpath);
            Report.WriteLine("I clicked on Save insured Rate as Quote Link on Rate Result page");
            Report.WriteLine("I am on the Quote Details Section");
            GlobalVariables.webDriver.WaitForPageLoad();
            string QuoteRequestNum = Gettext(attributeName_id, "referenceNumber-value");
            Click(attributeName_id, QuoteIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            int Quotelist = 0;
            Report.WriteLine("Clicking on Create Shipment from Quote Details Section");

            SendKeys(attributeName_id, ShipmentListSearchBox_Id, QuoteRequestNum);
            Report.WriteLine("Sending quote number");
            Quotelist = GetCount(attributeName_xpath, ".//*[@id='QuotesGrid']/tbody/tr");
            if (Quotelist > 1)
            {
                Report.WriteLine("exand theTrigger");
                DefineTimeOut(5000);
                MoveToElement(attributeName_xpath, Shipment_exandableTrigger_Xpath);
                Click(attributeName_xpath, Shipment_exandableTrigger_Xpath);
                WaitForElementVisible(attributeName_id, QuoteCreateShipment_Id, "CreateShipment");

            }
            else
            {
                Report.WriteLine("No records");
            }
            DefineTimeOut(5000);
            MoveToElement(attributeName_id, QuoteCreateShipment_Id);
            Click(attributeName_id, QuoteCreateShipment_Id);
            SendKeys(attributeName_id, ShippingFrom_LocationName_Id, "locationName");
            SendKeys(attributeName_id, ShippingFrom_LocationAddressLine1_Id, "locationAddress");
            SendKeys(attributeName_id, ShippingTo_LocationName_Id, "destinationName");
            SendKeys(attributeName_id, ShippingTo_LocationAddressLine1_Id, "destinationAddress");
            MoveToElement(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id);
            SendKeys(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id, "desc");
            MoveToElement(attributeName_xpath, Shipment_viewresults_Xpath);
            Click(attributeName_xpath, Shipment_viewresults_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Then(@"insured Value textbox will be non-editable")]
        public void ThenInsuredValueTextboxWillBeNon_Editable()
        {
            Report.WriteLine("insured Value textbox is non-editable");
            VerifyElementNotEnabled(attributeName_id, ShipResults_InsuredRateTextbox_Id,"textbox");
        }

        [Then(@"Show Insured Rate Button will be non-clickable")]
        public void ThenShowInsuredRateButtonWillBeNon_Clickable()
        {
            Report.WriteLine("Show Insured Rate Button is non-clickable");
            VerifyElementNotEnabled(attributeName_id, ShipResults_ShowInsuredRateButton_Id,"Button");
        }

        [Then(@"insured rate for selected carrier should be displayed")]
        public void ThenInsuredRateForSelectedCarrierShouldBeDisplayed()
        {
            Report.WriteLine("insured rate for selected carrier should be displayed");
            VerifyElementVisible(attributeName_xpath,ShipResults_RateColumn_Xpath, "insuredvaluecolumn");
        }

        [Then(@"I should be displayed with the only one carrier which i saved in quote process")]
        public void ThenIShouldBeDisplayedWithTheOnlyOneCarrierWhichISavedInQuoteProcess()
        {
            int row = GetCount(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr");
            if (row >1)
            {
                throw new Exception("Multiple Rates Returned in saved quote to shipment process");

            }
            else
            {
                Console.WriteLine("single Rate only Returned in saved quote to shipment process");
            }
        }
    }
}
