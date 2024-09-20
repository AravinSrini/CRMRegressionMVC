using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Quote.LTL.Shipment_Information_Screen.Get_Quote__LTL__Screen
{
    [Binding]
    public class RevampLTLRateRequestShippingInfoPage_PageElements_Desktop : ObjectRepository
    {
        [When(@"I must see the LTL '(.*)' tile in the Quotes landing page")]
        public void WhenIMustSeeTheLTLTileInTheQuotesLandingPage(string LTL)
        {
            Report.WriteLine("I must see LTL tile");
            Verifytext(attributeName_id, LTLTile_id, LTL);
        }

        [When(@"I click on the LTL tile")]
        public void WhenIClickOnTheLTLTile()
        {
            Report.WriteLine("User clicks on the LTL tile");
            Click(attributeName_id, LTLTile_id);
            WaitForElementVisible(attributeName_id, GetQuoteLTL_id, "LTLOrangemessage");
        }

        [Then(@"I should be arraive on the Get Quote LTL '(.*)' screen")]
        public void ThenIShouldBeArraiveOnTheGetQuoteLTLScreen(string LTLPagetitle)
        {
            Report.WriteLine("I should be arraive on the Get Quote LTL screen");
            VerifyElementVisible(attributeName_id, GetQuoteLTL_id, "LTLOrangemessage");

            Report.WriteLine("I should see the orange color message in the Get Quote LTL screen");
            var colorofthewarningmessage = GetCSSValue(attributeName_id, GetQuoteLTL_id, "color");
            Assert.AreEqual("rgba(255, 184, 69, 1)", colorofthewarningmessage);

            Report.WriteLine("I should see the Get Quote (LTL) screen");
            Verifytext(attributeName_xpath, LTLpagetitle_xpath, LTLPagetitle);
        }

        [Then(@"I must see the the '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)' and '(.*)'")]
        public void ThenIMustSeeTheTheAnd(string ShippingFrom, string zip, string city, string country, string state, string services, string ShippingTo, string FreightDescription, string SelectClassorSavedItem, string EnterWeight, string Quantity, string QuantityType, string InsuredValue, string InsuredValueNew, string PickupDate)
        {
            Report.WriteLine("Verifying the elements in the Get Quote (LTL) page");

            //----------------------- Shipping From Section ----------------------------------

            Report.WriteLine("Verifying the ShippingFrom text in the Get Quote (LTL) page");
            Verifytext(attributeName_xpath, ShippingFromText_xpath, ShippingFrom);

            Report.WriteLine("Verifying the ShippingFrom SearchBox and default text");
            VerifyElementPresent(attributeName_id, SearchboxforOrigin_id, "SearchBoxforShippingFrom");
            var Defaulttext_Search_From = GetAttribute(attributeName_id, SearchboxforOrigin_id, "placeholder");
            Assert.AreEqual("Select or search for a saved origin...", Defaulttext_Search_From);

            Report.WriteLine("Verifying the ShippingFrom Zipcode field and default text");
            VerifyElementPresent(attributeName_id, ZipcodeforShippingFrom_id, "ZipcodeforShippingFrom");
            var Defaulttext_Zip_From = GetAttribute(attributeName_id, ZipcodeforShippingFrom_id, "placeholder");
            Assert.AreEqual(zip, Defaulttext_Zip_From);

            Report.WriteLine("I should see the orange color rounded rectangle for the Zip code field");
            var coloroftheZipField_From = GetCSSValue(attributeName_id, ZipcodeforShippingFrom_id, "border-bottom-color");
            Assert.AreEqual("rgba(255, 184, 69, 1)", coloroftheZipField_From);

            Report.WriteLine("Verifying the ShippingFrom city field and default text");
            VerifyElementPresent(attributeName_id, cityforOrigin_id, "cityforShippingFrom");
            var Defaulttext_city_From = GetAttribute(attributeName_id, cityforOrigin_id, "placeholder");
            Assert.AreEqual(city, Defaulttext_city_From);

            Report.WriteLine("Verifying the ShippingFrom country field and default text");
            VerifyElementPresent(attributeName_id, countryforOrigin_id, "countryforShippingFrom");
            var Defaulttext_country_From = Gettext(attributeName_xpath, countryforOrigin_xpath);
            Assert.AreEqual(country, Defaulttext_country_From);

            Report.WriteLine("Verifying the ShippingFrom state field and default text");
            VerifyElementPresent(attributeName_id, stateforOrigin_id, "stateforShippingFrom");
            var Defaulttext_state_From = Gettext(attributeName_xpath, stateforOrigin_xpath);
            Assert.AreEqual(state, Defaulttext_state_From);

            Report.WriteLine("Verifying the ShippingFrom services field and default text");
            VerifyElementPresent(attributeName_id, servicesforOrigin_id, "servicesforShippingFrom");
            var Defaulttext_services_From = GetValue(attributeName_xpath, servicesforOrigin_xpath, "value");
            Assert.AreEqual(services, Defaulttext_services_From);

            //----------------------- Shipping To Section ----------------------------------

            Report.WriteLine("Verifying the ShippingTo text in the Get Quote (LTL) page");
            Verifytext(attributeName_xpath, ShippingToText_xpath, ShippingTo);

            Report.WriteLine("Verifying the ShippingTo SearchBox and default text");
            VerifyElementPresent(attributeName_id, SearchboxforDestination_id, "SearchBoxforShippingTo");
            var Defaulttext_Search_To = GetAttribute(attributeName_id, SearchboxforDestination_id, "placeholder");
            Assert.AreEqual("Select or search for a saved destination...", Defaulttext_Search_To);

            Report.WriteLine("Verifying the ShippingTo Zipcode field and default text");
            VerifyElementPresent(attributeName_id, ZipcodeforShippingTo_id, "ZipcodeforShippingTo");
            var Defaulttext_Zip_To = GetAttribute(attributeName_id, ZipcodeforShippingTo_id, "placeholder");
            Assert.AreEqual(zip, Defaulttext_Zip_To);

            Report.WriteLine("I should see the orange color rounded rectangle for the Zip code field");
            var coloroftheZipField_To = GetCSSValue(attributeName_id, ZipcodeforShippingTo_id, "border-bottom-color");
            Assert.AreEqual("rgba(255, 184, 69, 1)", coloroftheZipField_To);

            Report.WriteLine("Verifying the ShippingTo city field and default text");
            VerifyElementPresent(attributeName_id, cityforDestination_id, "cityforShippingTo");
            var Defaulttext_city_To = GetAttribute(attributeName_id, cityforDestination_id, "placeholder");
            Assert.AreEqual(city, Defaulttext_city_To);

            Report.WriteLine("Verifying the ShippingTo country field and default text");
            VerifyElementPresent(attributeName_id, countryforDestination_id, "countryforShippingTo");
            var Defaulttext_country_To = Gettext(attributeName_xpath, countryforDestination_xpath);
            Assert.AreEqual(country, Defaulttext_country_To);

            Report.WriteLine("Verifying the ShippingTo state field and default text");
            VerifyElementPresent(attributeName_id, stateforDestination_id, "stateforShippingTo");
            var Defaulttext_state_To = Gettext(attributeName_xpath, stateforDestination_xpath);
            Assert.AreEqual(state, Defaulttext_state_To);

            Report.WriteLine("Verifying the ShippingTo services field and default text");
            VerifyElementPresent(attributeName_id, servicesforDestination_id, "servicesforShippingTo");
            var Defaulttext_services_To = GetValue(attributeName_xpath, servicesforDestination_xpath, "value");
            Assert.AreEqual(services, Defaulttext_services_To);

            //------------------------------- Freight Description Section -----------------------------

            Report.WriteLine("Verifying the Freight Description text in the Get Quote (LTL) page");
            Verifytext(attributeName_xpath, FreightDescriptionText_xpath, FreightDescription);

            Report.WriteLine("Verifying the Select or search for a class or saved item field in the Freight Description");
            VerifyElementPresent(attributeName_id, ClassorSavedItemField_id, "SavedItemField");
            var DefaultText_ClassorSavedItem = Gettext(attributeName_xpath, ClassorSavedItemField_xpath);
            Assert.AreEqual(SelectClassorSavedItem, DefaultText_ClassorSavedItem);

            Report.WriteLine("I should see the orange color rounded rectangle for the Select Class field");
            var coloroftheSelectClass_Field = GetCSSValue(attributeName_linktext, ClassorSavedItemField_link, "border-bottom-color");
            Assert.AreEqual("rgba(255, 184, 69, 1)", coloroftheSelectClass_Field);

            Report.WriteLine("Verifying the weight field in the Frieght Description section");
            VerifyElementPresent(attributeName_id, weight_id, "weight");
            var Defaulttext_weight = GetAttribute(attributeName_id, weight_id, "placeholder");
            Assert.AreEqual(EnterWeight, Defaulttext_weight);

            Report.WriteLine("I should see the orange color rounded rectangle for the Enter Weight field");
            var coloroftheweight_Field = GetCSSValue(attributeName_id, weight_id, "border-bottom-color");
            Assert.AreEqual("rgba(255, 184, 69, 1)", coloroftheweight_Field);

            Report.WriteLine("Verifying the Quantity field in the Frieght Description section");
            VerifyElementPresent(attributeName_id, Quantity_id, "Quantity");
            var Defaulttext_Quantity = GetAttribute(attributeName_id, Quantity_id, "placeholder");
            Assert.AreEqual(Quantity, Defaulttext_Quantity);

            Report.WriteLine("Verifying the Quantity Type field in the Frieght Description section and default select Skids");
            VerifyElementPresent(attributeName_id, QuantityType_id, "QuantityType");
            var Defaulttext_QuantityType = Gettext(attributeName_xpath, QuantityType_xpath);
            Assert.AreEqual(QuantityType, Defaulttext_QuantityType);

            Report.WriteLine("Verifying the InsuredValue and default text in the Frieght Description section");
            VerifyElementPresent(attributeName_id, InsuredValue_id, "InsuredValue");
            var Defaulttext_InsuredValue = GetAttribute(attributeName_id, InsuredValue_id, "placeholder");
            Assert.AreEqual(InsuredValue, Defaulttext_InsuredValue);

            Report.WriteLine("Verifying the InsuredValueNew field in the Frieght Description section and default select New");
            VerifyElementPresent(attributeName_id, InsuredValueNew_id, "InsuredValueNew");
            var Defaulttext_InsuredValueNew = Gettext(attributeName_xpath, InsuredValueNew_xpath);
            Assert.AreEqual(InsuredValueNew, Defaulttext_InsuredValueNew);

            Report.WriteLine("Verifying the PickupDate field in the Frieght Description section and default date todays date");
            Verifytext(attributeName_xpath, PickupDate_xpath, PickupDate);
            //DateTime today = DateTime.Now;
            var TodaysDate_System = DateTime.Today.ToString("MM/dd/yyyy");
            var TodaysDate_UI = GetAttribute(attributeName_id, Pickupdate_id, "value");
            Assert.AreEqual(TodaysDate_UI, TodaysDate_System);
        }

        [Then(@"I must also see the clear address buttons for '(.*)' both Shipping From and Shipping To also Density Calculator, '(.*)', Calendar, '(.*)', '(.*)'")]
        public void ThenIMustAlsoSeeTheClearAddressButtonsForBothShippingFromAndShippingToAlsoDensityCalculatorCalendar(string clear, string AddAdditionalItem, string BacktoQuoteList, string ViewQuoteResults)
        {
            Report.WriteLine("Verify the Shipping From Clear Address button in the Get Quote (LTL) page");
            Verifytext(attributeName_id, ClearAddress_FromId, clear);

            Report.WriteLine("Verify the Shipping To Clear Address button in the Get Quote (LTL) page");
            Verifytext(attributeName_id, ClearAddress_ToId, clear);

            Report.WriteLine("Verify the Density Calculator Icon in the Get Quote (LTL) page");
            VerifyElementPresent(attributeName_id, DensityCalculatorIcon_id, "ESTIMATE CLASS");

            Report.WriteLine("Verify the Add Additional Item button in the Get Quote (LTL) page");
            Verifytext(attributeName_xpath, AddAdditionalItemBtm_xpath, AddAdditionalItem);

            Report.WriteLine("Verify the Calendar Icon in the Get Quote (LTL) page");
            Click(attributeName_id, Pickupdate_id);
            VerifyElementVisible(attributeName_xpath, CalendarGrid_xpath, "Calendar");

            Report.WriteLine("Verify the Back to Quote List button in the Get Quote (LTL) page");
            Verifytext(attributeName_id, BacktoQuoteListBtn_id, BacktoQuoteList);

            Report.WriteLine("Verify theView Quote Results button in the Get Quote (LTL) page");
            Verifytext(attributeName_id, ViewQuoteResultsBtn_id, ViewQuoteResults);
        }

        [Then(@"I must see the tool tip '(.*)' when mousehover on the Question mark icon")]
        public void ThenIMustSeeTheToolTipWhenMousehoverOnTheQuestionMarkIcon(string message)
        {
            Report.WriteLine("Verifying tool tip when mousehover on the Question mark icon");
            OnMouseOver(attributeName_id, tooltipicon_id);
            var TooltipMessage_UI = GetAttribute(attributeName_id, tooltipicon_id, "data-title");
            Assert.AreEqual(message, TooltipMessage_UI);
        }

        [Then(@"All the Required fields should be highlight in the pink color")]
        public void ThenAllTheRequiredFieldsShouldBeHighlightInThePinkColor()
        {
            Report.WriteLine("All the Required fields should be highlight in the pink color");
            var coloroftheZipField_From = GetCSSValue(attributeName_id, ZipcodeforShippingFrom_id, "background-color");
            var coloroftheZipField_To = GetCSSValue(attributeName_id, ZipcodeforShippingTo_id, "background-color");
            Assert.AreEqual("rgba(251, 236, 236, 1)", coloroftheZipField_From);
            Assert.AreEqual("rgba(251, 236, 236, 1)", coloroftheZipField_To);
        }

    }
}
