using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using CRM.UITest.Objects;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using CRM.UITest.CommonMethods;
using System;

namespace CRM.UITest
{
    [Binding]
    public class InsuranceClaims_DetailsTab_ProductsClaimedSection_ClaimSpecialistSteps : InsuranceClaim
    {
        int ExisteditemsCount = 0;
        [Given(@"I am on the Claim Details Page")]
        public void GivenIAmOnTheClaimDetailsPage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            //Click(attributeName_xpath, ".//*[@id='cookiescript_accept']");
            WaitForElementVisible(attributeName_xpath, ClaimsListPage_HeaderText_Xpath, "Claims List Text");
            string GridData = Gettext(attributeName_xpath, ClaimListGridDataCount_Xpath);
            if (GridData == "No Results Found")
            {
                Report.WriteLine("No Claims List found in the Grid");
                throw new Exception("No datas found in the Claim List Grid");
            }
            else
            {

                SendKeys(attributeName_xpath, ClaimsListSearchField_xpath, "1123478912");
                Report.WriteLine("Clicking on the Claim Number");
                Click(attributeName_xpath, FirstClaimNumber_ClaimsListGid_ClaimSpecialistUser_Xpath);

            }
            WaitForElementVisible(attributeName_xpath, ClaimDetailsTabText_Xpath, "DetailsPage");
            Report.WriteLine("I am on the Claim Details Page");
        }

        [When(@"I am on the Claim Details Page")]
        public void WhenIAmOnTheClaimDetailsPage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            //Click(attributeName_xpath, ".//*[@id='cookiescript_accept']");
            WaitForElementVisible(attributeName_xpath, ClaimsListPage_HeaderText_Xpath, "Claims List Text");
            string GridData = Gettext(attributeName_xpath, ClaimListGridDataCount_Xpath);
            if (GridData == "No Results Found")
            {
                Report.WriteLine("No Claims List found in the Grid");
                throw new Exception("No datas found in the Claim List Grid");
            }
            else
            {

                SendKeys(attributeName_xpath, ClaimsListSearchField_xpath, "1123478912");
                Report.WriteLine("Clicking on the Claim Number");
                Click(attributeName_xpath, FirstClaimNumber_ClaimsListGid_ClaimSpecialistUser_Xpath);

           }
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("I am on the Claim Details Page");
        }

        [Then(@"I can edit Claim Type,Articles Type,Item/Model,Unit Value,Quantity,Weight,Description of Claimed Articles,Total Shipment Weight")]
        public void ThenICanEditClaimTypeArticlesTypeItemModelUnitValueQuantityWeightDescriptionOfClaimedArticlesTotalShipmentWeight()
        {
            Report.WriteLine("I will be displayed with the Claim Type,Articles Type,Item/Model,Unit Value,Quantity,Weight,Description of Claimed Articles,Total Shipment Weight");
            VerifyElementEnabled(attributeName_xpath, FirstClaimType_xpath, "FirstClaimType");
            VerifyElementEnabled(attributeName_xpath, FirstArticleType_xpath, "FirstArticleType");
            VerifyElementEnabled(attributeName_xpath, FirstItemType_xpath, "FirstItemType");
            VerifyElementEnabled(attributeName_xpath, FirstUnitValue_xpath, "FirstUnitValue");
            VerifyElementEnabled(attributeName_xpath, FirstQuantity_xpath, "FirstQuantity");
            VerifyElementEnabled(attributeName_xpath,Firstitem_xpath, "Firstitem");
            VerifyElementEnabled(attributeName_xpath,firstDescription_claimedarticles_xpath, "firstDescription");
            VerifyElementEnabled(attributeName_xpath, totalshipmentvalue_xpath, "totalshipmentvalue");
        }

        [Then(@"I will see the Add Another Item hyper link")]
        public void ThenIWillSeeTheAddAnotherItemHyperLink()
        {
            Report.WriteLine("clicking on add another item button");
            VerifyElementVisible(attributeName_xpath, addAnotherItembutton_xpath,"Button");
        }

        [Then(@"Claim Type is required, select either Shortage or Damage")]
        public void ThenClaimTypeIsRequiredSelectEitherShortageOrDamage()
        {
            Click(attributeName_xpath, FirstClaimType_xpath);
            Click(attributeName_xpath, FirstClaimType_xpath);
            IList<IWebElement> claimTypeValuesList = GlobalVariables.webDriver.FindElements(By.XPath(claimtypevalues_xpath));
            List<string> claimTypeValuesListFromUI = new List<string>();
            foreach (IWebElement element in claimTypeValuesList)
            {
                claimTypeValuesListFromUI.Add((element.Text).ToString());
            }

            List<string> expectedClaimTypeValues = new List<string>(new string[] { "Shortage", "Damage" });
           if(claimTypeValuesListFromUI.Contains(expectedClaimTypeValues[0] )&& claimTypeValuesListFromUI.Contains(expectedClaimTypeValues[1]))
            {
                Report.WriteLine("Claim type shortage or damage options");
            }

        }

        [When(@"I click on the Add Another Item hyper link in the Products Claimed section")]
        public void WhenIClickOnTheAddAnotherItemHyperLinkInTheProductsClaimedSection()
        {
            Report.WriteLine("clicking on add another item button");
            scrollpagedown();
            MoveToElement(attributeName_xpath, addAnotherItembutton_xpath);
            IList<IWebElement> existeditemscount = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@class='productclaimtable']//tr/td[1]"));
            ExisteditemsCount = existeditemscount.Count;
            MoveToElement(attributeName_xpath, addAnotherItembutton_xpath);
            Click(attributeName_xpath, addAnotherItembutton_xpath);
        }
        [When(@"I click on the remove button")]
        public void WhenIClickOnTheRemoveButton()
        {
            Report.WriteLine("clicking on remove button");
            Click(attributeName_xpath, "(.//*[@id='btn_ProductClaimRemove']/span)[" + ExisteditemsCount + "]");

        }

        [Given(@"I have Another additional Item details")]
        public void GivenIHaveAnotherAdditionalItemDetails()
        {
            IList<IWebElement> existeditemscount = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@class='productclaimtable']//tr/td[1]"));
            ExisteditemsCount = existeditemscount.Count;
            MoveToElement(attributeName_xpath, addAnotherItembutton_xpath);
            scrollpagedown();
            Click(attributeName_xpath, addAnotherItembutton_xpath);
            SendKeys(attributeName_xpath, ".//*[@class='productclaimtable']//tr[" + ExisteditemsCount + "]/td[3]//input", "1");
            SendKeys(attributeName_xpath, ".//*[@class='productclaimtable']//tr[" + ExisteditemsCount + "]/td[4]//input", "2");
            SendKeys(attributeName_xpath, ".//*[@class='productclaimtable']//tr[" + ExisteditemsCount + "]/td[5]//input", "3");
            SendKeys(attributeName_xpath, ".//*[@class='productclaimtable']//tr[" + ExisteditemsCount + "]/td[6]//input", "4");
            MoveToElement(attributeName_xpath, ".//*[@class='productclaimtable']//tr[" + ExisteditemsCount + "]/td[8]//input");
            SendKeys(attributeName_xpath, ".//*[@class='productclaimtable']//tr[" + ExisteditemsCount + "]/td[8]//input", "7");
        }
        [When(@"I have Another additional Item details")]
        public void WhenIHaveAnotherAdditionalItemDetails()
        {
            IList<IWebElement> existeditemscount = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@class='productclaimtable']//tr/td[1]"));
            ExisteditemsCount = existeditemscount.Count;
            MoveToElement(attributeName_xpath, addAnotherItembutton_xpath);
            scrollpagedown();
            Click(attributeName_xpath, addAnotherItembutton_xpath);
            SendKeys(attributeName_xpath, ".//*[@class='productclaimtable']//tr[" + ExisteditemsCount + "]/td[3]//input", "1");
            SendKeys(attributeName_xpath, ".//*[@class='productclaimtable']//tr[" + ExisteditemsCount + "]/td[4]//input", "2");
            SendKeys(attributeName_xpath, ".//*[@class='productclaimtable']//tr[" + ExisteditemsCount + "]/td[5]//input", "3");
            SendKeys(attributeName_xpath, ".//*[@class='productclaimtable']//tr[" + ExisteditemsCount + "]/td[6]//input", "4");
            MoveToElement(attributeName_xpath, ".//*[@class='productclaimtable']//tr[" + ExisteditemsCount + "]/td[8]//input");
            SendKeys(attributeName_xpath, ".//*[@class='productclaimtable']//tr[" + ExisteditemsCount + "]/td[8]//input", "7");
        }
        [Then(@"Articles Type is required, select either Used or New")]
        public void ThenArticlesTypeIsRequiredSelectEitherUsedOrNew()
        {
            Report.WriteLine("Articles Type is required, select either Used or New");
            Click(attributeName_xpath, FirstArticleType_xpath);
            IList<IWebElement> articlesTypeValuesList = GlobalVariables.webDriver.FindElements(By.XPath(ArticlesTypeValues_xpath));
            List<string> articlesTypeValuesListFromUI = new List<string>();
            foreach (IWebElement element in articlesTypeValuesList)
            {
                articlesTypeValuesListFromUI.Add((element.Text).ToString());
            }

            List<string> expectedArticlesTypeValues = new List<string>(new string[] { "Used", "New" });
          }

        [Then(@"Item/Model is required, alpha-numeric, text, special characters, max length (.*)")]
        public void ThenItemModelIsRequiredAlpha_NumericTextSpecialCharactersMaxLength(int p0)
        {

            Report.WriteLine("Item/Model is required, alpha-numeric, text, special characters, max length");

            //verification for required fields
            //SendKeys(attributeName_id,FirstItemType_xpath, "");
            //Click(attributeName_id, "saveClaimdetailsButton_id");
            //VerifyElementVisible(attributeName_id, "mandatoryerrormessage_id", "Pleaseenterallrequiredfields");

            //verification for alpha numeric
            SendKeys(attributeName_xpath, FirstItemType_xpath, "abc123");
            string itemOrModelValue = GetValue(attributeName_xpath, FirstItemType_xpath,"value");
            Assert.AreEqual(itemOrModelValue, "abc123");

            //verification for text
            SendKeys(attributeName_xpath, FirstItemType_xpath, "textverify");
            string itemOrModelValueText = GetValue(attributeName_xpath, FirstItemType_xpath, "value");
            Assert.AreEqual(itemOrModelValueText, "textverify");

            //verifcation for special characters
            SendKeys(attributeName_xpath, FirstItemType_xpath, "!@#$%");
            string specialCharactersOfItemOrModelValue = GetValue(attributeName_xpath, FirstItemType_xpath, "value");
            Assert.AreEqual(specialCharactersOfItemOrModelValue, "!@#$%");

            //verification for mximum length_50
            SendKeys(attributeName_xpath, FirstItemType_xpath, "abcdefghijklmnovpqrstuvwxyzabcdefghijklmnovpqrstuv");
            string maximumLengthOfItemOrModelValue = GetValue(attributeName_xpath, FirstItemType_xpath, "value");
            Assert.AreEqual(maximumLengthOfItemOrModelValue, "abcdefghijklmnovpqrstuvwxyzabcdefghijklmnovpqrstuv");

            //verification for mximum length_more than 50
            SendKeys(attributeName_xpath, FirstItemType_xpath, "abcdefghijklmnovpqrstuvwxyzabcdefghijklmnovpqrstuvwxyz");
            string moreThanMaximumLengthOfItemOrModelValue = GetValue(attributeName_xpath, FirstItemType_xpath, "value");
            Assert.AreEqual(moreThanMaximumLengthOfItemOrModelValue, "abcdefghijklmnovpqrstuvwxyzabcdefghijklmnovpqrstuv");
        }

        [Then(@"Unit Value is required, currency,allow up to (.*) decimal places and always display (.*) decimal places, auto fill \$ and (.*) decimal places")]
        public void ThenUnitValueIsRequiredCurrencyAllowUpToDecimalPlacesAndAlwaysDisplayDecimalPlacesAutoFillAndDecimalPlaces(int p0, int p1, int p2)
        {
            Report.WriteLine("Unit Value is required, currency; allow up to 2 decimal places and always display 2 decimal places, auto fill $ and 2 decimal places; $xx,xxx.xx");

            //verification for required fields
            //SendKeys(attributeName_id, "Unit_id", "");
            //Click(attributeName_id, "saveClaimdetailsButton_id");
            //VerifyElementVisible(attributeName_id, "mandatoryerrormessage_id", "Pleaseenterallrequiredfields");

            //verification for allowing upto 2 decimal places only
            SendKeys(attributeName_xpath, firstUnitval_xpath, "123.12");
            IWebElement activeFromElement = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            activeFromElement.SendKeys(Keys.Tab);
            string twoDecimalPlacesOfUnitValue = GetValue(attributeName_xpath, firstUnitval_xpath,"value");
            Assert.AreEqual(twoDecimalPlacesOfUnitValue, "$123.12");

            SendKeys(attributeName_xpath, firstUnitval_xpath, "123.123");
            GlobalVariables.webDriver.SwitchTo().ActiveElement();
            activeFromElement.SendKeys(Keys.Tab);
            string threeDecimalPlacesOfUnitValue = GetValue(attributeName_xpath, firstUnitval_xpath, "value");
            Assert.AreEqual(threeDecimalPlacesOfUnitValue, "$123.12");


            //verification for autofill dollar and 2 decimal places
            SendKeys(attributeName_xpath, firstUnitval_xpath, "12");
            GlobalVariables.webDriver.SwitchTo().ActiveElement();
            activeFromElement.SendKeys(Keys.Tab);
            string dollarAndDecimalValueOfUnitValue = GetValue(attributeName_xpath, firstUnitval_xpath, "value");
            Assert.AreEqual(dollarAndDecimalValueOfUnitValue, "$12.00");

            //verifcation for value equal to three digit
            SendKeys(attributeName_xpath, firstUnitval_xpath, "123");
            activeFromElement.SendKeys(Keys.Tab);
            string maximumValueOfUnitValue = GetValue(attributeName_xpath, firstUnitval_xpath, "value");
            Assert.AreEqual(maximumValueOfUnitValue, "$123.00");

            //verification for more than three digit
            SendKeys(attributeName_xpath, firstUnitval_xpath, "1234");
            activeFromElement.SendKeys(Keys.Tab);
            string moreThanMaximumValueOfUnitValue = GetValue(attributeName_xpath, firstUnitval_xpath, "value");
            Assert.AreEqual(moreThanMaximumValueOfUnitValue, "$1,234.00");
        }

        [Then(@"Quantity is required, numeric only,max length (.*),format with comma when greater than (.*) digits")]
        public void ThenQuantityIsRequiredNumericOnlyMaxLengthFormatWithCommaWhenGreaterThanDigits(int p0, int p1)
        {
            Report.WriteLine("Quantity is required, numeric only,max length (.*),format with comma when greater than 3 digits");
            //verification for required fields
            //SendKeys(attributeName_xpath, "Quantity_id", "");
            //Click(attributeName_id, "saveClaimdetailsButton_id");
            //VerifyElementVisible(attributeName_id, "mandatoryerrormessage_id", "Pleaseenterallrequiredfields");

            //verification for numeric only
            SendKeys(attributeName_xpath, FirstQuantity_xpath, "abc123");
            IWebElement activeFromElement = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            activeFromElement.SendKeys(Keys.Tab);
            string quantity = GetValue(attributeName_xpath, FirstQuantity_xpath,"value");
            Assert.AreEqual(quantity, "123");

            //verification for max length 4
            SendKeys(attributeName_xpath, FirstQuantity_xpath, "1234");
            activeFromElement.SendKeys(Keys.Tab);
            string textOfQuantityField = GetValue(attributeName_xpath, FirstQuantity_xpath, "value");
            Assert.AreEqual(textOfQuantityField, "1,234");

            SendKeys(attributeName_xpath, FirstQuantity_xpath, "12345");
            activeFromElement.SendKeys(Keys.Tab);
            string textOfQuantityfield = GetValue(attributeName_xpath, FirstQuantity_xpath, "value");
            Assert.AreEqual(textOfQuantityfield, "1,234");

            //verifcation for format with comma when greater than 3 digits
            SendKeys(attributeName_xpath, FirstQuantity_xpath, "1234");
            activeFromElement.SendKeys(Keys.Tab);
            string specialCharactersOfQuantity = GetValue(attributeName_xpath, FirstQuantity_xpath, "value");
            Assert.AreEqual(specialCharactersOfQuantity, "1,234");
        }

        [Then(@"Weight is required, numeric only,max length (.*),format with comma when greater than (.*) digits")]
        public void ThenWeightIsRequiredNumericOnlyMaxLengthFormatWithCommaWhenGreaterThanDigits(int p0, int p1)
        {
            Report.WriteLine("Weight is required, numeric only,max length 6,format with comma when greater than 3 digits");
            //verification for required fields
            //SendKeys(attributeName_xpath, FirstUnitWgt_xpath, "");
            //Click(attributeName_id, "saveClaimdetailsButton_id");
            //VerifyElementVisible(attributeName_id, "mandatoryerrormessage_id", "Pleaseenterallrequiredfields");

            //verification for numeric only
            SendKeys(attributeName_xpath, FirstUnitWgt_xpath, "abc123");
            IWebElement activeFromElement = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            activeFromElement.SendKeys(Keys.Tab);
            string weight = GetValue(attributeName_xpath, FirstUnitWgt_xpath, "value");
            Assert.AreEqual(weight, "123.00");

            //verification for max length 6
            SendKeys(attributeName_xpath, FirstUnitWgt_xpath, "123456");
            activeFromElement.SendKeys(Keys.Tab);
            string maximumLengthOfWeight = GetValue(attributeName_xpath, FirstUnitWgt_xpath, "value");
            Assert.AreEqual(maximumLengthOfWeight, "123,456.00");

            SendKeys(attributeName_xpath, FirstUnitWgt_xpath, "1234567");
            activeFromElement.SendKeys(Keys.Tab);
            string moreThanMaximumLengthOfWeight = GetValue(attributeName_xpath, FirstUnitWgt_xpath, "value");
            Assert.AreEqual(moreThanMaximumLengthOfWeight, "123,456.00");

            //verifcation for format with comma when greater than 3 digits
            SendKeys(attributeName_xpath, FirstUnitWgt_xpath, "10000");
            activeFromElement.SendKeys(Keys.Tab);
            string weightWithCommaSeperate = GetValue(attributeName_xpath, FirstUnitWgt_xpath, "value");
            Assert.AreEqual(weightWithCommaSeperate, "10,000.00");
        }

        [Then(@"Description of Claimed Articles is required, alpha-numeric, text, special characters, max length (.*)")]
        public void ThenDescriptionOfClaimedArticlesIsRequiredAlpha_NumericTextSpecialCharactersMaxLength(int p0)
        {

            Report.WriteLine("Description of Claimed Articles is required, alpha-numeric, text, special characters, max length 250");

            //verification for required fields
            //SendKeys(attributeName_id, "ClaimedArticles_id", "");
            //Click(attributeName_id, "saveClaimdetailsButton_id");
            //VerifyElementVisible(attributeName_id, "mandatoryerrormessage_id", "Pleaseenterallrequiredfields");

            //verification for alpha numeric
            SendKeys(attributeName_xpath, firstDescription_claimedarticles_xpath, "abc123");
            IWebElement activeFromElement = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            activeFromElement.SendKeys(Keys.Tab);
            string descriptionOfClaimedArticles = GetValue(attributeName_xpath, firstDescription_claimedarticles_xpath, "value");
            Assert.AreEqual(descriptionOfClaimedArticles, "abc123");

            //verification for text
            SendKeys(attributeName_xpath, firstDescription_claimedarticles_xpath, "textverify");
            activeFromElement.SendKeys(Keys.Tab);
            string descriptionOfClaimedArticlesText = GetValue(attributeName_xpath, firstDescription_claimedarticles_xpath, "value");
            Assert.AreEqual(descriptionOfClaimedArticlesText, "textverify");

            //verifcation for special characters
            SendKeys(attributeName_xpath, firstDescription_claimedarticles_xpath, "!@#$%");
            activeFromElement.SendKeys(Keys.Tab);
            string descriptionOfClaimedArticlesSpecialcharacters = GetValue(attributeName_xpath, firstDescription_claimedarticles_xpath, "value");
            Assert.AreEqual(descriptionOfClaimedArticlesSpecialcharacters, "!@#$%");

            //verification for mximum length_250
            SendKeys(attributeName_xpath, firstDescription_claimedarticles_xpath, "abcdefghijklmnovpqrstuvwxyzabcdefghijklmnovpqrstuvabcdefghijklmnovpqrstuvwxyzabcdefghijklmnovpqrstuvabcdefghijklmnovpqrstuvwxyzabcdefghijklmnovpqrstuvabcdefghijklmnovpqrstuvwxyzabcdefghijklmnovpqrstuvabcdefghijklmnovpqrstuvwxyzabcdefghijklmnovpqrstuv");
            activeFromElement.SendKeys(Keys.Tab);
            string descriptionOfClaimedArticlesMaximumLength = GetValue(attributeName_xpath, firstDescription_claimedarticles_xpath, "value");
            Assert.AreEqual(descriptionOfClaimedArticlesMaximumLength, "abcdefghijklmnovpqrstuvwxyzabcdefghijklmnovpqrstuvabcdefghijklmnovpqrstuvwxyzabcdefghijklmnovpqrstuvabcdefghijklmnovpqrstuvwxyzabcdefghijklmnovpqrstuvabcdefghijklmnovpqrstuvwxyzabcdefghijklmnovpqrstuvabcdefghijklmnovpqrstuvwxyzabcdefghijklmnovpqrstuv");

            //verification for maximum length_more than 250
            SendKeys(attributeName_xpath, firstDescription_claimedarticles_xpath, "abcdefghijklmnovpqrstuvwxyzabcdefghijklmnovpqrstuvabcdefghijklmnovpqrstuvwxyzabcdefghijklmnovpqrstuvabcdefghijklmnovpqrstuvwxyzabcdefghijklmnovpqrstuvabcdefghijklmnovpqrstuvwxyzabcdefghijklmnovpqrstuvabcdefghijklmnovpqrstuvwxyzabcdefghijklmnovpqrstuvmore");
            activeFromElement.SendKeys(Keys.Tab);
            string moreThanMaximumLengthOfDescriptionOfClaimedArticles = GetValue(attributeName_xpath, firstDescription_claimedarticles_xpath, "value");
            Assert.AreEqual(moreThanMaximumLengthOfDescriptionOfClaimedArticles, "abcdefghijklmnovpqrstuvwxyzabcdefghijklmnovpqrstuvabcdefghijklmnovpqrstuvwxyzabcdefghijklmnovpqrstuvabcdefghijklmnovpqrstuvwxyzabcdefghijklmnovpqrstuvabcdefghijklmnovpqrstuvwxyzabcdefghijklmnovpqrstuvabcdefghijklmnovpqrstuvwxyzabcdefghijklmnovpqrstuv");
        }

        [Then(@"Total Shipment Weight is required, numeric only, max length (.*),format with comma when greater than (.*) digits")]
        public void ThenTotalShipmentWeightIsRequiredNumericOnlyMaxLengthFormatWithCommaWhenGreaterThanDigits(int p0, int p1)
        {
            Report.WriteLine("Total Shipment weight is required, numeric only,max length 6,format with comma when greater than 3 digits");
            //verification for required fields
            //SendKeys(attributeName_id,TotalShipmentWeightValue_id, "");
            //Click(attributeName_id, "saveClaimdetailsButton_id");
            //VerifyElementVisible(attributeName_id, "mandatoryerrormessage_id", "Pleaseenterallrequiredfields");

            //verification for numeric only
            SendKeys(attributeName_xpath, totalshipmentvalue_xpath, "abc123");
            IWebElement activeFromElement = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            activeFromElement.SendKeys(Keys.Tab);
            string totalShipmentWeight = GetValue(attributeName_xpath, totalshipmentvalue_xpath, "value");
            Assert.AreEqual(totalShipmentWeight, "123.00");

            //verification for max length 6
            SendKeys(attributeName_xpath, totalshipmentvalue_xpath, "123456");
            activeFromElement.SendKeys(Keys.Tab);
            string maximumTotalShipmentWeight = GetValue(attributeName_xpath, totalshipmentvalue_xpath, "value");
            Assert.AreEqual(maximumTotalShipmentWeight, "123,456.00");

            SendKeys(attributeName_xpath, totalshipmentvalue_xpath, "1234567");
            activeFromElement.SendKeys(Keys.Tab);
            string moreThanMaximumTotalShipmentWeight = GetValue(attributeName_xpath, totalshipmentvalue_xpath, "value");
            Assert.AreEqual(moreThanMaximumTotalShipmentWeight, "123,456.00");

            //verifcation for format with comma when greater than 3 digits
            SendKeys(attributeName_xpath, totalshipmentvalue_xpath, "10000");
            activeFromElement.SendKeys(Keys.Tab);
            string totalShipmentWeightWithComma = GetValue(attributeName_xpath, totalshipmentvalue_xpath, "value");
            Assert.AreEqual(totalShipmentWeightWithComma, "10,000.00");

            //verifcation for two decimal 
            SendKeys(attributeName_xpath, totalshipmentvalue_xpath, "100.123");
            activeFromElement.SendKeys(Keys.Tab);
            string totalShipmentWeightdecimal= GetValue(attributeName_xpath, totalshipmentvalue_xpath, "value");
            Assert.AreEqual(totalShipmentWeightdecimal, "100.12");
        }

        [Then(@"I will be displayed the Claim Type,Articles Type,Item/Model,Unit Value,Quantity,Weight,Description of Claimed Articles,Total Shipment Weight")]
        public void ThenIWillBeDisplayedTheClaimTypeArticlesTypeItemModelUnitValueQuantityWeightDescriptionOfClaimedArticlesTotalShipmentWeight()
        {
            Report.WriteLine("I will be displayed with the Claim Type,Articles Type,Item/Model,Unit Value,Quantity,Weight,Description of Claimed Articles,Total Shipment Weight");
            scrollpagedown();
            VerifyElementPresent(attributeName_xpath, ".//*[@class='productclaimtable']//tr["+ ExisteditemsCount + "]/td[1]//input","");
            VerifyElementPresent(attributeName_xpath,".//*[@class='productclaimtable']//tr["+ ExisteditemsCount + "]/td[2]//input","");
            VerifyElementPresent(attributeName_xpath,".//*[@class='productclaimtable']//tr[" + ExisteditemsCount + "]/td[3]//input","");
            VerifyElementPresent(attributeName_xpath,".//*[@class='productclaimtable']//tr["+ ExisteditemsCount + "]/td[4]//input","");
            VerifyElementPresent(attributeName_xpath,".//*[@class='productclaimtable']//tr[" + ExisteditemsCount + "]/td[5]//input","");
            VerifyElementPresent(attributeName_xpath,".//*[@class='productclaimtable']//tr[" + ExisteditemsCount + "]/td[6]//input","");
            VerifyElementPresent(attributeName_xpath, ".//*[@class='productclaimtable']//tr[" + ExisteditemsCount + "]/td[7]//input", "");
            VerifyElementPresent(attributeName_xpath, ".//*[@class='productclaimtable']//tr[" + ExisteditemsCount + "]/td[8]//input", "");
        }

        [Then(@"I should be displayed with remove button")]
        public void ThenIShouldBeDisplayedWithRemoveButton()
        {
            VerifyElementVisible(attributeName_xpath, RemoveItembutton_xpath, "removeButton");
            Report.WriteLine("Remove button is displayed");
        }

        [Then(@"additional Products Claimed section will be removed")]
        public void ThenAdditionalProductsClaimedSectionWillBeRemoved()
        {
            Report.WriteLine("additional Products Claimed section will be removed");
            VerifyElementNotVisible(attributeName_xpath, ".//*[@class='productclaimtable']//tr[" + ExisteditemsCount + "]/td[3]//input", "1");
            VerifyElementNotVisible(attributeName_xpath, ".//*[@class='productclaimtable']//tr[" + ExisteditemsCount + "]/td[4]//input", "2");
            VerifyElementNotVisible(attributeName_xpath, ".//*[@class='productclaimtable']//tr[" + ExisteditemsCount + "]/td[5]//input", "3");
            VerifyElementNotVisible(attributeName_xpath, ".//*[@class='productclaimtable']//tr[" + ExisteditemsCount + "]/td[6]//input", "4");
            VerifyElementNotVisible(attributeName_xpath, ".//*[@class='productclaimtable']//tr[" + ExisteditemsCount + "]/td[7]//input", "5");
            VerifyElementNotVisible(attributeName_xpath, ".//*[@class='productclaimtable']//tr[" + ExisteditemsCount + "]/td[8]//input", "7");
        }

        [Then(@"Additional item information will be displayed as a separate item in the Products Claimed section")]
        public void ThenAdditionalItemInformationWillBeDisplayedAsASeparateItemInTheProductsClaimedSection()
        {
            Report.WriteLine("additional item information displaying in seperate item of products Claimed section");
            VerifyElementVisible(attributeName_xpath, ".//*[@class='productclaimtable']//tr[" + ExisteditemsCount + "]/td[1]//input", "");
            VerifyElementVisible(attributeName_xpath, ".//*[@class='productclaimtable']//tr[" + ExisteditemsCount + "]/td[2]//input", "");
            VerifyElementVisible(attributeName_xpath, ".//*[@class='productclaimtable']//tr[" + ExisteditemsCount + "]/td[3]//input", "");
            VerifyElementVisible(attributeName_xpath, ".//*[@class='productclaimtable']//tr[" + ExisteditemsCount + "]/td[4]//input", "");
            VerifyElementVisible(attributeName_xpath, ".//*[@class='productclaimtable']//tr[" + ExisteditemsCount + "]/td[5]//input", "");
            VerifyElementVisible(attributeName_xpath, ".//*[@class='productclaimtable']//tr[" + ExisteditemsCount + "]/td[6]//input", "");
            VerifyElementVisible(attributeName_xpath, ".//*[@class='productclaimtable']//tr[" + ExisteditemsCount + "]/td[7]//input", "");
            VerifyElementVisible(attributeName_xpath, ".//*[@class='productclaimtable']//tr[" + ExisteditemsCount + "]/td[8]//input", "");
        }

        [Then(@"Ttl Pcs field will update to display the sum of the Qty of all of the displayed products")]
        public void ThenTtlPcsFieldWillUpdateToDisplayTheSumOfTheQtyOfAllOfTheDisplayedProducts()
        {
            Report.WriteLine("Total Pieces field will update to display the sum of the Quantity of all of the displayed products");
            scrollElementIntoView(attributeName_xpath, ProductsClaimed_Xpath);
            string totalPieces = Gettext(attributeName_xpath, TotalPcs_Xpath);
            scrollPageup();
            IList<IWebElement> listOfQuantityValues = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@class='productclaimtable']//td[3]"));
            List<string> actualListOfAllQuantityValues = new List<string>();
            int qtyTotalUI = 0;
            for (int l = 0; l < listOfQuantityValues.Count-1; l++)
            {
                int j = l + 1;
                string singleQtyValue = GetValue(attributeName_xpath, ".//*[@class='productclaimtable']//tr[" + j + "]/td[3]//input", "value");
                actualListOfAllQuantityValues.Add(singleQtyValue);
                qtyTotalUI = qtyTotalUI + Convert.ToInt32(singleQtyValue);
            }
            Assert.AreEqual(totalPieces, qtyTotalUI.ToString());
        }

        [Then(@"Ttl Wt field will update to display the sum of the Ext Wt of all of the displayed products")]
        public void ThenTtlWtFieldWillUpdateToDisplayTheSumOfTheExtWtOfAllOfTheDisplayedProducts()
        {
            Report.WriteLine("Total Weight field will update to display the sum of the Ext Wt of all of the displayed products");
            string totalWeight = Gettext(attributeName_id, TotalWgt_id);

            IList<IWebElement> listOfExtWgtValues = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@class='productclaimtable']//td[7]"));
            List<string> actualListOfExtWgtValues = new List<string>();
            decimal extWgtValuesUItotal = 0;
            for (int l = 0; l < listOfExtWgtValues.Count-1; l++)
            {
                int j = l + 1;
                string singleExtWgt = GetValue(attributeName_xpath, ".//*[@class='productclaimtable']//tr[" + j + "]/td[7]//input", "value");
                actualListOfExtWgtValues.Add(singleExtWgt);
                extWgtValuesUItotal = extWgtValuesUItotal + Convert.ToDecimal(singleExtWgt);
            }

            Assert.AreEqual(totalWeight.Replace(",", ""), extWgtValuesUItotal.ToString());
        }

        [Then(@"Ttl Val field will update to display the sum of the Ext Val of all of the displayed products")]
        public void ThenTtlValFieldWillUpdateToDisplayTheSumOfTheExtValOfAllOfTheDisplayedProducts()
        {
            Report.WriteLine("Total Value field will update to display the sum of the Ext Val of all of the displayed products");
            string totalValue = Gettext(attributeName_xpath, Totalval_Xpath);
            IList<IWebElement> listOfExtValues = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@class='productclaimtable']//td[8]"));
            List<string> actualListOfExtValues = new List<string>();
            decimal totalValuesUI = 0;
            for (int l = 0; l < listOfExtValues.Count-1; l++)
            {
                int j = l + 1;
                string singleExtVal = GetValue(attributeName_xpath, ".//*[@class='productclaimtable']//tr[" + j + "]/td[9]//input", "value");
                actualListOfExtValues.Add(singleExtVal);
                totalValuesUI = totalValuesUI + Convert.ToDecimal(singleExtVal.Replace("$", ""));
            }
            Assert.AreEqual(totalValue.Replace(",", ""), "$" + totalValuesUI.ToString());
        }
    }
}