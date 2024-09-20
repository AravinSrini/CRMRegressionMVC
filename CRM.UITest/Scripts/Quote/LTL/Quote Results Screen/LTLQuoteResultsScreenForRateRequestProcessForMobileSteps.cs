using System;
using TechTalk.SpecFlow;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System.Threading;

namespace CRM.UITest.Scripts.Quote.LTL
{
    [Binding]
    public class LTLQuoteResultsScreenForRateRequestProcessForMobileSteps : ObjectRepository
    {
        
        [Then(@"user should be displayed with Carrier Name, Carrier Logo, Guaranteed Rate Available Link, Service, Distance, Rate, Save Rate As Quote link, Insured Rate and Save Insured Rate as Quote link")]
        public void ThenUserShouldBeDisplayedWithCarrierNameCarrierLogoGuaranteedRateAvailableLinkServiceDistanceRateSaveRateAsQuoteLinkInsuredRateAndSaveInsuredRateAsQuoteLink()
        {
            Report.WriteLine("Display carrier name and carrier logo ,Guaranteed Rate Available Link, Service, Distance, Rate, Save Rate As Quote link, Insured Rate and Save Insured Rate as Quote link");
            VerifyElementVisible(attributeName_xpath, ltlcarrierName_mobile_xpath, "carriername");
            VerifyElementVisible(attributeName_xpath, ltlcarrierLogo_mobile_xpath, "carrierlogo");
            VerifyElementVisible(attributeName_xpath, ltlGuaranteedrateavbl_mobile_xpath, "Guaranteed Rate Available Link");
            VerifyElementVisible(attributeName_xpath, ltlservice_mobile_xpath, "Service");
            VerifyElementVisible(attributeName_xpath, ltldistance_mobile_xpath, "Distance");
            VerifyElementVisible(attributeName_xpath, ltlrate_mobile_xpath, "Rate");
            VerifyElementVisible(attributeName_xpath, ltlsaverateasquote_mobile_xpath, "Save Rate As Quote link");
            VerifyElementVisible(attributeName_xpath, ltlsaveinsuredrateasquote_mobile_xpath, "Save insured Rate As Quote link");
        }

        [Then(@"user should not be visible with Enter insured value label, filtering options, sorting, Extra rate info \(Fuel, line haul, accessorials\), Extra insured rate info \(New, Used\), Back to Quote List button and export button")]
        public void ThenUserShouldNotBeVisibleWithEnterInsuredValueLabelFilteringOptionsSortingExtraRateInfoFuelLineHaulAccessorialsExtraInsuredRateInfoNewUsedBackToQuoteListButtonAndExportButton()
        {
            Report.WriteLine("Enter Insured value, filtering options, sorting, Extra rate info,Fuel, line haul, accessorials, Extra insured rate info,New, Used, Back to Quote List button and export button");
            VerifyElementNotVisible(attributeName_xpath, EnterInsvaltext_xpath, "Enter Insured Value:");            
            VerifyElementNotVisible(attributeName_xpath, ltlQuickestSrvcRadioBtn_xpath, "QuickestSrvcRadioBtn");
            VerifyElementNotVisible(attributeName_xpath, ltlLeastcostRadioBtn_xpath, "LeastcostRadioBtn");
            VerifyElementNotVisible(attributeName_xpath, ltlstdRatesort_xpath, "standardratesort");
            VerifyElementNotVisible(attributeName_xpath, ltlservicedaysheader_xpath, "servicesort");
            VerifyElementNotVisible(attributeName_xpath, ltlstdRateamount_xpath, "insuredrateamount");
            VerifyElementNotVisible(attributeName_xpath, ltlstdFuel_xpath, "fuel");
            VerifyElementNotVisible(attributeName_xpath, ltlstdLinehaul_xpath, "linehaul");
            VerifyElementNotVisible(attributeName_xpath, ltlstdaccessorials_xpath, "accessorials");
            VerifyElementNotVisible(attributeName_xpath, ltlcreateshipmentbtn_xpath, "createshipmentbutton");
            VerifyElementNotVisible(attributeName_xpath, ltlExportBtn_xpath, "exportbutton");
            Thread.Sleep(2000);
            VerifyElementNotPresent(attributeName_xpath, ltlinsrateamount_xpath, "insuredrateamount");
            VerifyElementNotPresent(attributeName_xpath, ltlinsfuel_xpath, "fuel");
            VerifyElementNotPresent(attributeName_xpath, ltlinslinehaul_xpath, "linehaul");
            VerifyElementNotPresent(attributeName_xpath, ltlinsaccessorials_xpath, "accessorials");
            VerifyElementNotVisible(attributeName_xpath, ltlBacktoQuoteListBtn_xpath, "backtoquotelist");
            VerifyElementNotPresent(attributeName_xpath, ltlCarrNewAmt_xpath, "new");
            VerifyElementNotPresent(attributeName_xpath, ltlCarrUsedAmt_xpath, "used");
        }

        
        [Then(@"I click on save rate as quote link  for selected carrier")]
        public void ThenIClickOnSaveRateAsQuoteLinkForSelectedCarrier()
        {
            Report.WriteLine("Click on Save Rate as Quote");
            Click(attributeName_xpath, ltlsaverateasquote_mobile_xpath);
        }

        [Then(@"I click on save insured rate as quote link  for selected carrier")]
        public void ThenIClickOnSaveInsuredRateAsQuoteLinkForSelectedCarrier()
        {
            Report.WriteLine("Click on Save Insured Rate as Quote");
            Click(attributeName_xpath, ltlsaveinsuredrateasquote_mobile_xpath);
        }

        [Then(@"I click on save your quote link when there are no rate results")]
        public void ThenIClickOnSaveYourQuoteLinkWhenThereAreNoRateResults()
        {
            Report.WriteLine("Click on Save your quote link when there are no rate results");
            Click(attributeName_xpath, ltlsavequotenorateslink_xpath);
        }

        [Then(@"I click on update your shipping information link when there are no rate results")]
        public void ThenIClickOnUpdateYourShippingInformationLinkWhenThereAreNoRateResults()
        {
            Report.WriteLine("Click on Update your shipping information link");
            Click(attributeName_xpath, ltlUpdateurShpngInfolnk_xpath);
        }

        [Then(@"I will be navigated to LTL Shipment Information screen")]
        public void ThenIWillBeNavigatedToLTLShipmentInformationScreen()
        {
            Report.WriteLine("Navigating to Shipment Information Screen");
            WaitForElementVisible(attributeName_xpath, ShipmentInformationText_Xpath, "Get Quote (LTL)");
        }

        [When(@"I click on save rate as quote link  for selected carrier on mobile screen")]
        public void WhenIClickOnSaveRateAsQuoteLinkForSelectedCarrierOnMobileScreen()
        {


            Report.WriteLine("Click on Savte Rate as Quote on mobile screen");

            Click(attributeName_xpath, ltlsaverateasquote_mobile_xpath);
        }

        [When(@"I click on save insured rate as quote link  for selected carrier on mobile screen")]
        public void WhenIClickOnSaveInsuredRateAsQuoteLinkForSelectedCarrierOnMobileScreen()
        {
            Report.WriteLine("Click on Save Insured Rate as Quote on mobile screen");
            MoveToElement(attributeName_xpath, ltlsaveinsuredrateasquote_mobile_xpath);
            Click(attributeName_xpath, ltlsaveinsuredrateasquote_mobile_xpath);
        }

        [When(@"I will be navigated to Guaranteed Rate carriers on mobile screen")]
        public void WhenIWillBeNavigatedToGuaranteedRateCarriersOnMobileScreen()
        {
            Report.WriteLine("Navigating to guaranteed rate carrier");
            MoveToElement(attributeName_xpath, mobileguaranteedrate_xpath);
        }

        [When(@"I click on guaranteed save insured rate as quote link  for selected carrier on mobile screen")]
        public void WhenIClickOnGuaranteedSaveInsuredRateAsQuoteLinkForSelectedCarrierOnMobileScreen()
        {
            Report.WriteLine("Click on Save Insured Rate as quote of guaranteed rate");
            Click(attributeName_xpath, mobileguaranteedinssavequote_xpath);
        }

        [When(@"I click on guaranteed save rate as quote link  for selected carrier on mobile screen")]
        public void WhenIClickOnGuaranteedSaveRateAsQuoteLinkForSelectedCarrierOnMobileScreen()
        {
            Report.WriteLine("Click on Save Rate as quote of guaranteed rate");
            Click(attributeName_xpath, mobileguaranteedsavequote_xpath);
        }

        [When(@"I click on save your quote link on mobile screen")]
        public void WhenIClickOnSaveYourQuoteLinkOnMobileScreen()
        {
                Report.WriteLine("Creater shipment for selected carrier when no rate results");
                Click(attributeName_xpath, ltlsavequotenorateslink_xpath);
            
        }


    }
}