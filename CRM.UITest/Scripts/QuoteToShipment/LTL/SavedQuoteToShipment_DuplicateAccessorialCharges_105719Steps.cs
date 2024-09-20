using CRM.UITest.CommonMethods;
using CRM.UITest.Helper.Implementations;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.QuoteToShipment.LTL
{
    [Binding]
    public class SavedQuoteToShipment_DuplicateAccessorialCharges_105719Steps : AddShipments
    {

        AddQuoteLTL quote = new AddQuoteLTL();
        QuoteToShipmentLTL quoteToShipment = new QuoteToShipmentLTL();
        int ExpectedInsAllriskPricesheetCount = 1;
        string BOLValue;
        string QuoteRequestNum;
        

        [Given(@"I am a External user")]
        public void GivenIAmAExternalUser()
        {
            Report.WriteLine("Logging in as External User");
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();

            string username = ConfigurationManager.AppSettings["username-InsAllRiskUser"].ToString();
            string password = ConfigurationManager.AppSettings["password-InsAllRiskPwd"].ToString();

            CrmLogin.LoginToCRMApplication(username, password);
            Report.WriteLine("Logged in Successfully as External User");
        }
        
        [Given(@"I have created a Quote")]
        public void GivenIHaveCreatedAQuote()
        {
            Report.WriteLine("Creating Quote");

            quote.NaviagteToQuoteList();
            quote.Add_QuoteLTL("external", "ZZZ - Czar Customer Test");
            quote.EnterOriginZip("90001");
            quote.EnterDestinationZip("90087");

            Click(attributeName_xpath, LTL_Quote_ShippingFrom_ServicesAndAccessorial_dropdown_Xpath);
            string AccessorialField = "//*[@id='servicesaccessorialsfrom_chosen']/div/ul/li[3]";
            Click(attributeName_xpath, AccessorialField);

            quote.EnterItemdata("50", "1");
            SendKeys(attributeName_id, ShipResults_InsuredRateTextbox_Id, "15");
            quote.ClickViewRates();
            Report.WriteLine("I am on Rate Results page");
            quoteToShipment.ClickOnSaveRateAsQuoteLink("External");
            Report.WriteLine("I clicked on Save Rate as Quote Link on Rate Result page");
        }
        
        [When(@"I create a Shipment from non-expired LTL quote")]
        public void WhenICreateAShipmentFromNon_ExpiredLTLQuote()
        {
            Report.WriteLine("I am on the Quote Details Section");
            GlobalVariables.webDriver.WaitForPageLoad();
            QuoteRequestNum = Gettext(attributeName_id, "referenceNumber-value");


            Click(attributeName_id, QuoteIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();

            int Quotelist = 0;

            Report.WriteLine("Clicking on Create Shipment from Quote Details Section");
            SendKeys(attributeName_id, ShipmentListSearchBox_Id, QuoteRequestNum);
            Quotelist = GetCount(attributeName_xpath, ".//*[@id='QuotesGrid']/tbody/tr");
            if (Quotelist > 1)
            {

                Click(attributeName_xpath, Shipment_exandableTrigger_Xpath);

                WaitForElementVisible(attributeName_xpath, QuoteCreateShipment_Xpath, "btn-CreateShipment");

            }
            else
            {
                Report.WriteLine("No records");
            }

            WaitForElementVisible(attributeName_xpath, QuoteCreateShipment_Xpath, "btn-CreateShipment");
            Click(attributeName_xpath, QuoteCreateShipment_Xpath);
            Report.WriteLine("Create Shipment from Quote Details Section Page opened ");
            SendKeys(attributeName_id, ShippingFrom_LocationName_Id, "locationName");
            SendKeys(attributeName_id, ShippingFrom_LocationAddressLine1_Id, "locationAddress");
            SendKeys(attributeName_id, ShippingTo_LocationName_Id, "destinationName");
            SendKeys(attributeName_id, ShippingTo_LocationAddressLine1_Id, "destinationAddress");
            MoveToElement(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id);
            SendKeys(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id, "desc");
            MoveToElement(attributeName_xpath, Shipment_viewresults_Xpath);
            Click(attributeName_xpath, Shipment_viewresults_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, confirmation_CreateShipmentInsured_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, ReviewAndSubmit_SubmitShipment_button_Xpath, "SubmitShipment");
            MoveToElement(attributeName_xpath, ReviewAndSubmit_SubmitShipment_button_Xpath);
            Click(attributeName_xpath, ReviewAndSubmit_SubmitShipment_button_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            BOLValue = Gettext(attributeName_xpath, confirmation_BOLValue_Xpath);
            Report.WriteLine("Shipment Created Successfully with Insurance");
        }
        
        [Then(@"Pricesheet should not contain duplicate charges for accessorials")]
        public void ThenPricesheetShouldNotContainDuplicateChargesForAccessorials()
        {
            Report.WriteLine("Validation of Price Sheet from MG started");
            XDocument shipment = GetShipmentFromMG.getShipment(BOLValue);

            List<XElement> InsAllRiskChargeList = shipment.Elements("MercuryGate").Elements("Shipment").Elements("PriceSheets").Elements("PriceSheet").Elements("Charges").Elements("Charge").Elements("Description").Where(a => a.Value == "All Risk").ToList();
            int Ins_AllRiskPriceSheetCount = InsAllRiskChargeList.Count;
            if (ExpectedInsAllriskPricesheetCount == Ins_AllRiskPriceSheetCount)
            {
                
                Report.WriteLine("Duplicate Accessorials not present");
            }
            else
            {
                Report.WriteLine("Duplicate Accessorials Present");
                Assert.AreEqual(ExpectedInsAllriskPricesheetCount, Ins_AllRiskPriceSheetCount);
                
            }

            Report.WriteLine("Validation of Price Sheet from MG done Successfully");
        }
    }
}
