using CRM.UITest.CommonMethods;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Configuration;
using TechTalk.SpecFlow;

namespace CRM.UITest
{
    [Binding]
    public class DisplayQuoteCriteriaSteps : AddQuoteLTL
    {
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();

        [Given(@"I am a shpinquiry, shpentry, sales, sales management, operations, or station owner user")]
        public void GivenIAmAShpinquiryShpentrySalesSalesManagementOperationsOrStationOwnerUser()
        {
            Report.WriteLine("I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner user");
            string userName = ConfigurationManager.AppSettings["username-UkShipEntryTest"].ToString();
            string password = ConfigurationManager.AppSettings["password-UkShipEntryTest"].ToString();
            CrmLogin.LoginToCRMApplication(userName, password);
            Report.WriteLine("I logged into CRM application with external user credentials");
        }

        [Given(@"I Arrive on the Get Quote (LTL) page")]
        public void IArriveOnTheGetQuoteLTLPage()
        {
            Report.WriteLine("Arriving on quote list page");
            Click(attributeName_xpath, QuoteList_Button_Xpath);
            Report.WriteLine("Clicking submit rate request button");
            Click(attributeName_xpath, QuoteList_SubmitQuote_Button_Xpath);
            Report.WriteLine("Clicking LTL tile on get quote page");
            Click(attributeName_xpath, GetQuote_LTLTile_Button_Xpath);            
        }
        
        [Given(@"the quote contains more than one unique class (.*)")]
        public void GivenTheQuoteContainsMoreThanOneUniqueClass(int count, Table items)
        {
            for (int i = 0; i < count; i++)
            {
                var pieces = items.Rows[i][0];
                var weight = items.Rows[i][1];
                var itemClass = items.Rows[i][2];
                Report.WriteLine("Adding new item to get quote");
                SendKeys(attributeName_id, "Select-saveditem-" + i, itemClass);
                SendKeys(attributeName_id, "weight-" + i, weight);
                SendKeys(attributeName_id, "quantity-" + i, pieces);

                if(i < count - 1)
                {
                    Report.WriteLine("Adding new item area");
                    Click(attributeName_xpath, GetQuote_AddAdditionalItem_Button_XPath);
                }
            }
        }

        [Given(@"I Arrive on the Get Quote \(LTL\) page")]
        public void GivenIArriveOnTheGetQuoteLTLPage()
        {
            Report.WriteLine("Arriving on quote list page");
            Click(attributeName_xpath, QuoteList_Button_Xpath);
            Report.WriteLine("Clicking submit rate request button");
            Click(attributeName_xpath, QuoteList_SubmitQuote_Button_Xpath);
            Report.WriteLine("Clicking LTL tile on get quote page");
            Click(attributeName_xpath, GetQuote_LTLTile_Button_Xpath);
        }


        [When(@"I arrive on the Get Quote \(LTL\) page")]
        public void WhenIArriveOnTheGetQuoteLTLPage()
        {
            Report.WriteLine("Arriving on quote list page");
            Click(attributeName_xpath, QuoteList_Button_Xpath);
            Report.WriteLine("Clicking submit rate request button");
            Click(attributeName_xpath, QuoteList_SubmitQuote_Button_Xpath);
            Report.WriteLine("Clicking LTL tile on get quote page");
            Click(attributeName_xpath, GetQuote_LTLTile_Button_Xpath);
        }


        [When(@"the quote contains one unique class")]
        public void WhenTheQuoteContainsOneUniqueClass()
        {
            Report.WriteLine("Verifying there is only one item in the get quote page");
            VerifyElementNotVisible(attributeName_xpath, GetQuote_AdditionalItems_XPath, "AdditionalItems");
        }

        [Given(@"I have chose a pickup date (.*)")]
        [When(@"I have chose a pickup date (.*)")]
        public void IHaveChoseAPickupDate(string date)
        {
            if(date == "Tomorrow")
            {
                int nextDay = DateTime.UtcNow.AddDays(1).Day;
                Click(attributeName_id, GetQuote_PickupDate_Button_Id);
                Click(attributeName_xpath, "//*[@class='datepicker-days']/table/tbody/tr/td[@class='day' and text()='" + nextDay + "']");
            }
        }

        [Given(@"I choose a (.*) (.*) and (.*) for the origin")]
        [When(@"I choose a (.*) (.*) and (.*) for the origin")]
        public void IChooseACityStateAndZipCodeForTheOrigin(string city, string state, string zipCode)
        {
            Report.WriteLine("Clicking the clear address button for origin");
            Click(attributeName_xpath, GetQuote_OriginClearAddress_XPath);

            Report.WriteLine("Entering zip code");
            EnterOriginZip(zipCode);

            Report.WriteLine("Entering " + city + " into the origin input box");
            SendKeys(attributeName_id, GetQuote_OriginCityInput_Id, city);

            Report.WriteLine("Chossing the state " + state + " from the drop down");
            Click(attributeName_xpath, GetQuote_OriginStateDropDown_XPath);
            SelectDropdownValueFromList(attributeName_xpath, GetQuote_OriginStateDropdown_Values_XPath, state);
        }

        [Given(@"I choose a (.*) (.*) and (.*) for the Destination")]
        [When(@"I choose a (.*) (.*) and (.*) for the Destination")]
        public void IChooseACityStateAndZipCodeForTheDestination(string city, string state, string zipCode)
        {
            Report.WriteLine("Clicking the clear address button for origin");
            Click(attributeName_xpath, GetQuote_DestinationClearAddress_XPath);

            Report.WriteLine("Entering zip code");
            EnterDestinationZip(zipCode);

            Report.WriteLine("Entering " + city + " into the origin input box");
            SendKeys(attributeName_id, GetQuote_DestinationCityInput_Id, city);

            Report.WriteLine("Chossing the state " + state + " from the drop down");
            Click(attributeName_xpath, GetQuote_DestinationStateDropDown_XPath);
            SelectDropdownValueFromList(attributeName_xpath, GetQuote_DestinationStateDropdown_Values_XPath, state);
        }
        
        [When(@"I choose a (.*) (.*) (.*) (.*) (.*) and (.*) for the item")]
        public void WhenIChoosePiecesWeightLengthWidthHeightAndClassForTheItem(string pieces, string weight, string length, string width, string height, string itemClass)
        {
            Report.WriteLine("Entering information for the item");
            EnterItemdata(itemClass, weight);
            SendKeys(attributeName_id, GetQuote_QuantityInput_Id, pieces);
        }

        [When(@"I hover over the More Information icon in the Class/Weight field")]
        public void WhenIHoverOverTheMoreInformationIconInTheClassWeightField()
        {
            Report.WriteLine("When I Hover over the more information icon");
            WaitForElementVisible(attributeName_xpath, QuoteResult_LTL_MoreInformationIcon_XPath, "More Info Icon");
            var element = GlobalVariables.webDriver.FindElement(By.XPath(QuoteResult_LTL_MoreInformationIcon_XPath));
            Actions action = new Actions(GlobalVariables.webDriver);
            action.MoveToElement(element).Perform();
        }
        
        [Then(@"I will see the following new fields on the quote results page:")]
        public void ThenIWillSeeTheFollowingNewFields(Table fields)
        {
            var pickupDate = fields.Rows[0][0];
            var origin = fields.Rows[1][0];
            var destination = fields.Rows[2][0];
            var pieces = fields.Rows[3][0];
            var classWeight = fields.Rows[4][0];
            Report.WriteLine("Verify I can see the quote result quote criteria section");
            Verifytext(attributeName_xpath, QuoteResult_LTL_PickupDate_XPath, pickupDate);
            Verifytext(attributeName_xpath, QuoteResult_LTL_Origin_XPath, origin);
            Verifytext(attributeName_xpath, QuoteResult_LTL_Destination_XPath, destination);
            Verifytext(attributeName_xpath, QuoteResult_LTL_Pieces_XPath, pieces);
            Verifytext(attributeName_xpath, QuoteResult_LTL_ClassWeight_XPath, classWeight);
        }
        
        [Then(@"the Pickup Date field will be populated with the Pickup Date selected on the Get Quote \(LTL\) page (.*)")]
        public void ThenTheDateFieldWillBePopulatedWithTheTodaySelectedOnTheGetQuoteLTLPage(string date)
        {
            DateTime pickupDate = DateTime.UtcNow;
            if (date == "Tomorrow")
            {
                pickupDate = pickupDate.AddDays(1);
            }

            string pickupDateString = pickupDate.ToString("MM/dd/yyyy");
            Report.WriteLine("Verify I can see the date correctly on result screen - " + pickupDateString);
            WaitForElementVisibleVerifyTextContains(attributeName_id, QuoteResult_LTL_PickupDateResult_Id, pickupDateString, "PickupDate");
        }
        
        [Then(@"the Origin field will be populated with the City, State and Zip Code from the fields in the Shipping From section of the Get Quote \(LTL\) page (.*) (.*) (.*)")]
        public void ThenTheFieldWillBePopulatedWithTheCityStateAndZipCodeFromTheFieldsInTheShippingFromSectionOfTheGetQuoteLTLPage(string city, string state, string zipCode)
        {
            string originString = city + ", " + state + " " + zipCode;
            Report.WriteLine("Verify I can see the origin correctly - " + originString);
            WaitForElementVisibleVerifyTextContains(attributeName_id, QuoteResult_LTL_OriginResult_Id, originString, "Origin");
        }
        
        [Then(@"the Destination field will be populated with the City, State and Zip Code from the fields in the  Shipping To section of the Get Quote \(LTL\) page (.*) (.*) (.*)")]
        public void ThenTheFieldWillBePopulatedWithTheCityStateAndZipCodeFromTheFieldsInTheShippingToSectionOfTheGetQuoteLTLPage(string city, string state, string zipCode)
        {
            string destinationString = city + ", " + state + " " + zipCode;
            Report.WriteLine("Verify I can see the destination correctly - " + destinationString);
            WaitForElementVisibleVerifyTextContains(attributeName_id, QuoteResult_LTL_DestinationResult_Id, destinationString, "Destination");
        }
        
        [Then(@"the Pieces field will be populated with the total of all values entered in the Enter a quantity\.\.\. fields in the Freight Description section of the Get Quote \(LTL\) page (.*)")]
        public void ThenThePiecesFieldWillBePopulatedWithTheTotalOfAllValuesEnteredInTheEnterAQuantity_FieldsInTheFreightDescriptionSectionOfTheGetQuoteLTLPage(string pieces)
        {
            Report.WriteLine("Verify I can see the pieces correctly - " + pieces);
            WaitForElementVisibleVerifyTextContains(attributeName_id, QuoteResult_LTL_PiecesResult_Id, pieces, "Pieces");
        }
        
        [Then(@"the Class/Weight field will be populated with the class selected in the Select or search for a class or saved item\.\.\. field in the Freight Description section of the Get Quote \(LTL\) page (.*) (.*)")]
        public void ThenTheClassFieldWillBePopulatedWithTheClassSelectedInTheSelectOrSearchForAClassOrSavedItem_FieldInTheFreightDescriptionSectionOfTheGetQuoteLTLPage(string itemClass, string weight)
        {
            string classWeightString = itemClass + "/" + weight + " lbs";
            Report.WriteLine("Verify I can see the class/weight correctly - " + classWeightString);
            WaitForElementVisibleVerifyTextContains(attributeName_id, QuoteResult_LTL_ClassWeightResult_Id, classWeightString, "Class/Weight");
        }
        
        [Then(@"the following new fields are not editable:")]
        public void ThenTheFollowingNewFieldsAreNotEditable(Table fields)
        {
            var pickupDateResult = GlobalVariables.webDriver.FindElement(By.Id(QuoteResult_LTL_PickupDateResult_Id));
            Report.WriteLine("Verify the pickupdate data that has binded is not an input so that it can not be changed");
            Assert.AreNotEqual("input", pickupDateResult.TagName, "Element Tags are the same and should not be - not expected: input, actual: " + pickupDateResult.TagName);

            var originResult = GlobalVariables.webDriver.FindElement(By.Id(QuoteResult_LTL_OriginResult_Id));
            Report.WriteLine("Verify the Origin data that has binded is not an input so that it can not be changed");
            Assert.AreNotEqual("input", originResult.TagName, "Element Tags are the same and should not be - not expected: input, actual: " + originResult.TagName);

            var destinationResult = GlobalVariables.webDriver.FindElement(By.Id(QuoteResult_LTL_DestinationResult_Id));
            Report.WriteLine("Verify the destination data that has binded is not an input so that it can not be changed");
            Assert.AreNotEqual("input", destinationResult.TagName, "Element Tags are the same and should not be - not expected: input, actual: " + destinationResult.TagName);

            var piecesResult = GlobalVariables.webDriver.FindElement(By.Id(QuoteResult_LTL_PiecesResult_Id));
            Report.WriteLine("Verify the pieces data that has binded is not an input so that it can not be changed");
            Assert.AreNotEqual("input", piecesResult.TagName, "Element Tags are the same and should not be - not expected: input, actual: " + piecesResult.TagName);

            var ClassWeightResult = GlobalVariables.webDriver.FindElement(By.Id(QuoteResult_LTL_ClassWeightResult_Id));
            Report.WriteLine("Verify the class/weight data that has binded is not an input so that it can not be changed");
            Assert.AreNotEqual("input", ClassWeightResult.TagName, "Element Tags are the same and should not be - not expected: input, actual: " + ClassWeightResult.TagName);
        }
        
        [Then(@"I will see a More Information icon displayed in the Class/Weight field of the quote criteria")]
        public void ThenIWillSeeAMoreInformationIconDisplayedInTheClassWeightFieldOfTheQuoteCriteria()
        {
            Report.WriteLine("Verify I can see the more information icon");
            WaitForElementVisible(attributeName_xpath, QuoteResult_LTL_MoreInformationIcon_XPath, "More Info Icon");
            VerifyElementVisible(attributeName_xpath, QuoteResult_LTL_MoreInformationIcon_XPath, "More Info Icon");
        }
        
        [Then(@"I will see a pop up displaying the pieces, class, and weight of each unique class (.*)")]
        public void ThenIWillSeeAPopUpDisplayingThePiecesClassAndWeightOfEachUniqueClass(int count, Table items)
        {
            for (int i = 0; i < count; i++)
            {
                var pieces = items.Rows[i][0];
                var classWeight = items.Rows[i][1];
                var c = i + 1;
                Verifytext(attributeName_xpath, "//*[@class='popover-content']/table/tbody/tr[" + c + "]/td[1]", pieces);
                Verifytext(attributeName_xpath, "//*[@class='popover-content']/table/tbody/tr[" + c + "]/td[2]", classWeight);
            }
        }
    }
}
