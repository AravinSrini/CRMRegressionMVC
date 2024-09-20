using System;
using TechTalk.SpecFlow;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System.Threading;

namespace CRM.UITest.Scripts.Quote.LTL
{
    [Binding]
    public class BuildShipmentServiceScreenForRateRequest_MobileSteps : ObjectRepository
    {
        
        [Given(@"I have access to Quotes")]
        public void GivenIHaveAccessToQuotes()
        {
            Report.WriteLine("Access to Quotes");
            Click(attributeName_id, QuoteIconClick_Id);
            //WaitForElementNotVisible(attributeName_id, LoadingSymbol_id, "loading symbol");
            Click(attributeName_id, SubmitRateRequestButton_Id);
        }
        [Given(@"I Click on Quotes icon from the navigation bar")]
        public void GivenIClickOnQuotesIconFromTheNavigationBar()
        {
            
            WaitForElementVisible(attributeName_xpath, MenuExpandIcon_Mobile_Xpath, "Menu Icon");
            WaitForElementNotVisible(attributeName_id, LoadingSymbol_id, "loading symbol");
            Click(attributeName_xpath, MenuExpandIcon_Mobile_Xpath);
            WaitForElementNotVisible(attributeName_id, LoadingSymbol_id, "loading symbol");
            Report.WriteLine("Click on quotes module");
            WaitForElementVisible(attributeName_id, QuoteIcon_Id, "Quote Icon");
            Click(attributeName_id, QuoteIcon_Id);
            //WaitForElementNotVisible(attributeName_id, LoadingSymbol_id, "loading symbol");
            //WaitForElementNotVisible(attributeName_id, LoadingSymbol_id, "loading symbol");
        }

       

        [When(@"I click on the Submit Rate Request button")] [Scope(Tag = "17387")]
        public void WhenIClickOnTheSubmitRateRequestButton()
        {
            Report.WriteLine("Click on Submit Rate Request");
            Click(attributeName_id, SubmitRateRequestButton_Id);
        }


        [Then(@"The (.*) list button should be hidden for the mobile view on Shipment service screen")]
        public void ThenTheListButtonShouldBeHiddenForTheMobileViewOnShipmentServiceScreen(string BacktoQuote)
        {
            Report.WriteLine("Visibility of Back to Quote button");
            VerifyElementNotVisible(attributeName_id, BackToQuoteButton_Id, BacktoQuote);

        }


        [Then(@"I must be able to view (.*), (.*), (.*) and (.*) tile on the Shipment service screen")]
        public void ThenIMustBeAbleToViewAndTileOnTheShipmentServiceScreen(string LTL, string Truckload, string PartialTruckLoad, string Intermodal)
        {
            Report.WriteLine("Shipment Service Screen tile view for MG Users");
            VerifyElementPresent(attributeName_id, LTL_TileLabel_Id, LTL);
            string MG_LTLView = Gettext(attributeName_id, LTL_TileLabel_Id);
            Assert.AreEqual(LTL, MG_LTLView);
            VerifyElementPresent(attributeName_id, TL_TileLabel_Id, Truckload);
            string MG_TLView = Gettext(attributeName_id, TL_TileLabel_Id);
            Assert.AreEqual(Truckload, MG_TLView);
            VerifyElementPresent(attributeName_id, Partial_TL_TileLabel_Id, PartialTruckLoad);
            string MG_PTLView = Gettext(attributeName_id, Partial_TL_TileLabel_Id);
            Assert.AreEqual(PartialTruckLoad, MG_PTLView);
            VerifyElementPresent(attributeName_id, Intermodal_TileLabel_Id, Intermodal);
            string MG_IntermodalView = Gettext(attributeName_id, Intermodal_TileLabel_Id);
            Assert.AreEqual(Intermodal, MG_IntermodalView);

        }

        [Then(@"I must be able to see (.*), (.*), (.*), (.*), (.*) and (.*) tiles on the Shipment service screen")]
        public void ThenIMustBeAbleToSeeAndTilesOnTheShipmentServiceScreen(string LTL, string Truckload, string PartialTruckLoad, string Intermodal, string International, string DomesticForwarding)
        {
            Report.WriteLine("Shipment Service Screen tile view for ALL Users");
            VerifyElementPresent(attributeName_id, LTL_TileLabel_Id, LTL);
            string Both_Tile_LTLView = Gettext(attributeName_id, LTL_TileLabel_Id);
            Assert.AreEqual(LTL, Both_Tile_LTLView);
            VerifyElementPresent(attributeName_id, TL_TileLabel_Id, Truckload);
            string Both_Tile_TLView = Gettext(attributeName_id, TL_TileLabel_Id);
            Assert.AreEqual(Truckload, Both_Tile_TLView);
            VerifyElementPresent(attributeName_id, Partial_TL_TileLabel_Id, PartialTruckLoad);
            string Both_Tile_PTLView = Gettext(attributeName_id, Partial_TL_TileLabel_Id);
            Assert.AreEqual(PartialTruckLoad, Both_Tile_PTLView);
            VerifyElementPresent(attributeName_id, Intermodal_TileLabel_Id, Intermodal);
            string Both_Tile_IntermodalView = Gettext(attributeName_id, Intermodal_TileLabel_Id);
            Assert.AreEqual(Intermodal, Both_Tile_IntermodalView);
            VerifyElementPresent(attributeName_id, International_TileLabel_Id, International);
            string Both_InternationalView = Gettext(attributeName_id, International_TileLabel_Id);
            Assert.AreEqual(International, Both_InternationalView);
            VerifyElementPresent(attributeName_id, DomesticForwarding_TitleLabel_Id, DomesticForwarding);
            string Both_DomesticView = Gettext(attributeName_id, DomesticForwarding_TitleLabel_Id);
            Assert.AreEqual(DomesticForwarding, Both_DomesticView);
        }

        [Then(@"I must be able to view (.*) and (.*) tiles on the Shipment service screen")]
        public void ThenIMustBeAbleToViewAndTilesOnTheShipmentServiceScreen(string International, string DomesticForwarding)
        {
            Report.WriteLine("Shipment Service Screen tile view for CSA Users");
            VerifyElementPresent(attributeName_id, International_TileLabel_Id, International);
            string CSA_InternationalView = Gettext(attributeName_id, International_TileLabel_Id);
            Assert.AreEqual(International, CSA_InternationalView);
            VerifyElementPresent(attributeName_id, DomesticForwarding_TitleLabel_Id, DomesticForwarding);
            string CSA_DomesticView = Gettext(attributeName_id, DomesticForwarding_TitleLabel_Id);
            Assert.AreEqual(DomesticForwarding, CSA_DomesticView);
        }
    }
}
