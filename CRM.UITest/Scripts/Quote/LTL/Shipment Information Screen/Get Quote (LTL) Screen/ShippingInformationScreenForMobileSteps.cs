using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Quote.LTL
{
    [Binding]
    public class ShippingInformationScreenForMobileSteps : ObjectRepository
    {
        [Given(@"I re-size the browser to mobile device '(.*)' and  '(.*)'")]
        public void GivenIRe_SizeTheBrowserToMobileDeviceAnd(int WindowWidth, int WindowHeight)
        {
            setBrowserSize(WindowWidth, WindowHeight);
        }

        [When(@"I am taken to the new responsive LTL Shipment Information screen")]
        public void WhenIAmTakenToTheNewResponsiveLTLShipmentInformationScreen()
        {
            Report.WriteLine("Verifying LTL shipment information page text");
            VerifyElementVisible(attributeName_xpath, LTL_shipmentinformationpageheader_Xpath, "Get Quote (LTL)");
        }

        [Given(@"I clicked on (.*) button on the select type screen of rate request process from mobile device")]
        public void GivenIClickedOnButtonOnTheSelectTypeScreenOfRateRequestProcessFromMobileDevice(string Service)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementNotVisible(attributeName_id, LoadingSymbol_id, "loading symbol");
            WaitForElementNotVisible(attributeName_id, LoadingSymbol_id, "loading symbol");
            WaitForElementVisible(attributeName_xpath, MenuExpandIcon_Mobile_Xpath, "Menu Icon");
            Click(attributeName_xpath, MenuExpandIcon_Mobile_Xpath);
            WaitForElementNotVisible(attributeName_id, LoadingSymbol_id, "loading symbol");
            Report.WriteLine("Click on quotes module");
            WaitForElementVisible(attributeName_id, QuoteIcon_Id, "Quote Icon");
            Click(attributeName_id, QuoteIcon_Id);

            GlobalVariables.webDriver.WaitForPageLoad();

            Report.WriteLine("Navigate to rate request service page");
            Click(attributeName_id, SubmitRateRequestButton_Id);

            Report.WriteLine("Selecting service from shipment service screen");
            if (Service.ToUpper() == "LTL")
            {
                WaitForElementVisible(attributeName_id, LTL_TileLabel_Id, "LTL Tile");
                Click(attributeName_id, LTL_TileLabel_Id);
            }
            else
            {

            }
        }
        
        [Then(@"I should be able to verify all the fields in the mobile device - Origin Country,Origin Zip/Postal code, Origin City, Origin State/Province, Destination Country, Destination Zip/Postal Code, Destination City, Destination State/Province, Classification, Weight, Pickup date, Services/accessorials, Shipment value, Terms & Conditions link, Add additional item button and View Quote Results button")]
        public void ThenIShouldBeAbleToVerifyAllTheFieldsInTheMobileDevice_OriginCountryOriginZipPostalCodeOriginCityOriginStateProvinceDestinationCountryDestinationZipPostalCodeDestinationCityDestinationStateProvinceClassificationWeightPickupDateServicesAccessorialsShipmentValueTermsConditionsLinkAddAdditionalItemButtonAndViewQuoteResultsButton()
        {
            Report.WriteLine("Verifing the fields present under origin section");
            VerifyElementPresent(attributeName_id, LTL_OriginCountryDropdown_Id, "Origin Country dropdown");
            VerifyElementPresent(attributeName_id, LTL_OriginZipPostal_Id, "Origin Zip or Postal text box");
            VerifyElementPresent(attributeName_id, LTL_OriginStateProvince_Id, "Origin State or Province text box");
            VerifyElementPresent(attributeName_id, LTL_OriginCity_Id, "Origin city text box");

            Report.WriteLine("Verifing the fields present under destination section");
            VerifyElementPresent(attributeName_id, LTL_DestinationCountryDropdown_Id, "Destination Country dropdown");
            VerifyElementPresent(attributeName_id, LTL_DestinationZipPostal_Id, "Destination Zip or Postal text box");
            VerifyElementPresent(attributeName_id, LTL_DestinationStateProvince_Id, "Destination State or Province text box");
            VerifyElementPresent(attributeName_id, LTL_DestinationCity_Id, "Destination city text box");

            Report.WriteLine("Verifing the fields present under freight description section");
            VerifyElementPresent(attributeName_id, LTL_Classification_Id, "Classification dropdown");
            VerifyElementPresent(attributeName_id, LTL_Weight_Id, "Weight text box");
            VerifyElementPresent(attributeName_xpath, LTL_AddAdditionalItemLink_Xpath, "Add Additional item button");
            VerifyElementPresent(attributeName_id, LTL_EnterInsuredValue_Id, "Shipment Value text box");
            VerifyElementPresent(attributeName_id, LTL_QuestionMarkIcon_Id, "Shipment Value - question mark icon");
            VerifyElementPresent(attributeName_xpath, LTL_TermsAndConditionsLink_Xpath, "Terms and Conditions link");

            Report.WriteLine("Verifing the fields present Services and Accessorials section");
            VerifyElementPresent(attributeName_xpath, LTL_ServicesDropdown_Xpath, "Additional services dropdown");
        }
        
        [Then(@"Select a saved origin address, Select a saved destination address, Select a saved item, Zip/Postal lookups, Estimated Class Lookups, Shipment Value \? icon,  and Back to Quote List button should be hidden")]
        public void ThenSelectASavedOriginAddressSelectASavedDestinationAddressSelectASavedItemZipPostalLookupsEstimatedClassLookupsShipmentValueIconAndBackToQuoteListButtonShouldBeHidden()
        {
            Report.WriteLine("Verifing the hidden fields in shipment information section");
            ElementNotPresent(attributeName_id, LTL_SavedOriginAddressDropdown_Id, "Saved Origin Address dropdown");
            ElementNotPresent(attributeName_id, LTL_SavedDestinationAddressDropdown_Id, "Saved Destination Address dropdown");
            ElementNotPresent(attributeName_id, LTL_SavedItemDropdown_Id, "Saved Item dropdown");
            ElementNotPresent(attributeName_id, LTL_OriginLookup_Xpath, "Origin lookup");
            ElementNotPresent(attributeName_id, LTL_DestinationLookup_Xpath, "Destination lookup");
            ElementNotPresent(attributeName_id, BackToQuoteButton_Id, "Back to quote list button");
            ElementNotPresent(attributeName_id, LTL_QuestionMarkIcon_Id, "Shipment Value - question mark icon");
        }



        [Then(@"another set of Select Class , Weight, Quantity , Quantity_Type , Add Addition Item and Remove Item button should be displayed for mobile")]
        public void ThenAnotherSetOfSelectClassWeightQuantityQuantity_TypeAddAdditionItemAndRemoveItemButtonShouldBeDisplayedForMobile()
        {
            WaitForElementVisible(attributeName_id, LTL_Additinal_Weight_Id, "Additional Weight Field");
            WaitForElementVisible(attributeName_id, LTL_Additional_Quantity_Id, "Additional Quanity Field");
            Verifytext(attributeName_xpath, LTL_Additional_QuantityType_Xpath, "Skids");
            WaitForElementVisible(attributeName_xpath, LTL_RemoveAdditionalItemLink_Xpath, "Remove Item");
            WaitForElementVisible(attributeName_id, LTL_Additional_SelectClass_Id, "Select Class");

        }

        [Then(@"another set of Select Class , Weight, Quantity , Quantity_Type , Add Addition Item and Remove Item button should disappear for mobile")]
        public void ThenAnotherSetOfSelectClassWeightQuantityQuantity_TypeAddAdditionItemAndRemoveItemButtonShouldDisappearForMobile()
        {
            WaitForElementNotPresent(attributeName_id, LTL_Additinal_Weight_Id, "Additional Weight Field");
            WaitForElementNotPresent(attributeName_id, LTL_Additional_Quantity_Id, "Additional Quanity Field");
            WaitForElementNotPresent(attributeName_xpath, LTL_RemoveAdditionalItemLink_Xpath, "Remove Item");
            WaitForElementNotPresent(attributeName_id, LTL_Additional_SelectClass_Id, "Select Class");
            WaitForElementNotPresent(attributeName_xpath, LTL_Additional_QuantityType_Xpath, "Skids");
        }
    }
}
