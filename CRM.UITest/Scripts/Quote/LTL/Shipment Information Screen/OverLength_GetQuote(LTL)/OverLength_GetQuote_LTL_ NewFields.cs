using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Quote.LTL.Shipment_Information_Screen.OverLength_GetQuote_LTL_
{
    [Binding]
    public class OverLength_GetQuote_LTL__NewFields : Quotelist
    {
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();

        [Given(@"I am a shp\.inquiry, shp\.entry, sales, sales management, operations, or station owner user")]
        public void GivenIAmAShp_InquiryShp_EntrySalesSalesManagementOperationsOrStationOwnerUser()
        {
            Report.WriteLine("I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner user");
            string userName = ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();
            string password = ConfigurationManager.AppSettings["password-ExtuserCustDropdown"].ToString();
            CrmLogin.LoginToCRMApplication(userName, password);
            Report.WriteLine("I logged into CRM application with external user credentials");
        }


        [Then(@"I will see new optional Dimension fields in the Freight Description section Length,Height,Width")]
        public void ThenIWillSeeNewOptionalDimensionFieldsInTheFreightDescriptionSectionLengthHeightWidth()
        {
            Report.WriteLine("I will see new optional Dimension fields in the Freight Description section Length,Height,Width");
            VerifyElementPresent(attributeName_id, LTL_Quote_Item_Length_Id, "Length");
            VerifyElementPresent(attributeName_id, LTL_Quote_Item_Width_Id, "Width");
            VerifyElementPresent(attributeName_id, LTL_Quote_Item_Height_Id, "Height");
        }


        [Then(@"I am not allowed to enter Negative value in Length, Width, Height field(.*)")]
        public void ThenIAmNotAllowedToEnterNegativeValueInLengthWidthHeightField(string negativeValue)
        {
            Report.WriteLine("I am not allowed to enter Negative value in Length, Width, Height field");
            string enteredValue = Regex.Replace(negativeValue, @"(\s+|&|'|\(|\)|<|>|#)", "");
            SendKeys(attributeName_id, LTL_Quote_Item_Length_Id, enteredValue);
            SendKeys(attributeName_id, LTL_Quote_Item_Width_Id, enteredValue);
            SendKeys(attributeName_id, LTL_Quote_Item_Height_Id, enteredValue);

            string length = GetAttribute(attributeName_id, LTL_Quote_Item_Length_Id, "value");
            string width = GetAttribute(attributeName_id, LTL_Quote_Item_Width_Id, "value");
            string height = GetAttribute(attributeName_id, LTL_Quote_Item_Height_Id, "value");

            if (Convert.ToInt32(length) > 0)
            {
                Report.WriteLine("Length field is not accepting negative values");
            }
            else
            {
                Report.WriteFailure("Length field is accepting negative values");
            }
            if (Convert.ToInt32(width) > 0)
            {
                Report.WriteLine("Width field is not accepting negative values");
            }
            else
            {
                Report.WriteFailure("width field is accepting negative values");
            }
            if (Convert.ToInt32(height) > 0)
            {
                Report.WriteLine("Height field is not accepting negative values");
            }
            else
            {
                Report.WriteFailure("Height field is accepting negative values");
            }

        }


        [Then(@"I am not allowed to enter Negative value in the added additional Items for Length, Width, Height for (.*)")]
        public void ThenIAmNotAllowedToEnterNegativeValueInTheAddedAdditionalItemsForLengthWidthHeightFor(string negativeValue)
        {
            Report.WriteLine("I am not allowed to enter Negative value in the added additional Items for Length, Width, Height for ****");
            scrollElementIntoView(attributeName_xpath, "//*[text()='Freight Description']");
            string enteredValue = Regex.Replace(negativeValue, @"(\s+|&|'|\(|\)|<|>|#)", "");

            for (int i = 1; i <= 9; i++)
            {

                SendKeys(attributeName_id, "length-" + i, enteredValue);
                SendKeys(attributeName_id, "width-" + i, enteredValue);
                SendKeys(attributeName_id, "height-" + i, enteredValue);

                string length = GetAttribute(attributeName_id, "length-" + i, "value");
                string width = GetAttribute(attributeName_id, "width-" + i, "value");
                string height = GetAttribute(attributeName_id, "height-" + i, "value");

                if (Convert.ToInt32(length) > 0)
                {
                    Report.WriteLine("Length field is not accepting negative values");
                }
                else
                {
                    Report.WriteFailure("Length field is accepting negative values");
                }
                if (Convert.ToInt32(width) > 0)
                {
                    Report.WriteLine("Width field is not accepting negative values");
                }
                else
                {
                    Report.WriteFailure("width field is accepting negative values");
                }
                if (Convert.ToInt32(height) > 0)
                {
                    Report.WriteLine("Height field is not accepting negative values");
                }
                else
                {
                    Report.WriteFailure("Height field is accepting negative values");
                }
            }
        }



        [Then(@"the Minimum value accepted in Length, Width, Height field is (.*)")]
        public void ThenTheMinimumValueAcceptedInLengthWidthHeightFieldIs(int p0)
        {
            Report.WriteLine("the Minimum value accepted in Length, Width, Height field is**");
            string length;
            string width;
            string height;

            SendKeys(attributeName_id, LTL_Quote_Item_Length_Id, "0");
            SendKeys(attributeName_id, LTL_Quote_Item_Width_Id, "0");
            SendKeys(attributeName_id, LTL_Quote_Item_Height_Id, "0");

            length = GetAttribute(attributeName_id, LTL_Quote_Item_Length_Id, "value");
            width = GetAttribute(attributeName_id, LTL_Quote_Item_Width_Id, "value");
            height = GetAttribute(attributeName_id, LTL_Quote_Item_Height_Id, "value");

            if (length == string.Empty && width == string.Empty && height == string.Empty)
            {
                Report.WriteLine("dimeansion fields are not accepting 0");
            }
            else
            {
                Report.WriteFailure("dimeansion fields are accepting 0");
            }


            SendKeys(attributeName_id, LTL_Quote_Item_Length_Id, "1");
            SendKeys(attributeName_id, LTL_Quote_Item_Width_Id, "1");
            SendKeys(attributeName_id, LTL_Quote_Item_Height_Id, "1");

            length = GetAttribute(attributeName_id, LTL_Quote_Item_Length_Id, "value");
            width = GetAttribute(attributeName_id, LTL_Quote_Item_Width_Id, "value");
            height = GetAttribute(attributeName_id, LTL_Quote_Item_Height_Id, "value");

            if (length == "1" && width == "1" && height == "1")
            {
                Report.WriteLine("dimeansion fields are accepting 1");
            }
            else
            {
                Report.WriteFailure("dimeansion fields are not accepting 1");
            }

        }


        [Then(@"the Minimum value accepted in the added additional Items for Length, Width, Height field should accept (.*)")]
        public void ThenTheMinimumValueAcceptedInTheAddedAdditionalItemsForLengthWidthHeightFieldShouldAccept(int p0)
        {
            Report.WriteLine("the Minimum value accepted in the added additional Items for Length, Width, Height field should accept");
            scrollElementIntoView(attributeName_xpath, "//*[text()='Freight Description']");
            string length;
            string width;
            string height;

            for (int i = 1; i <= 9; i++)
            {

                SendKeys(attributeName_id, "length-" + i, "0");
                SendKeys(attributeName_id, "width-" + i, "0");
                SendKeys(attributeName_id, "height-" + i, "0");

                length = GetAttribute(attributeName_id, "length-" + i, "value");
                width = GetAttribute(attributeName_id, "width-" + i, "value");
                height = GetAttribute(attributeName_id, "height-" + i, "value");

                if (length == string.Empty && width == string.Empty && height == string.Empty)
                {
                    Report.WriteLine("dimeansion fields are not accepting 0");
                }
                else
                {
                    Report.WriteFailure("dimeansion fields are accepting 0");
                }

                SendKeys(attributeName_id, "length-" + i, "1");
                SendKeys(attributeName_id, "width-" + i, "1");
                SendKeys(attributeName_id, "height-" + i, "1");

                length = GetAttribute(attributeName_id, "length-" + i, "value");
                width = GetAttribute(attributeName_id, "width-" + i, "value");
                height = GetAttribute(attributeName_id, "height-" + i, "value");

                if (length == "1" && width == "1" && height == "1")
                {
                    Report.WriteLine("dimeansion fields are accepting 1");
                }
                else
                {
                    Report.WriteFailure("dimeansion fields are not accepting 1");
                }
            }
        }


        [Then(@"I am not allowed to enter decimal values in Length, Width, Height field(.*)")]
        public void ThenIAmNotAllowedToEnterDecimalValuesInLengthWidthHeightField(string p0)
        {
            Report.WriteLine("I am not allowed to enter decimal values in Length, Width, Height field");

            SendKeys(attributeName_id, LTL_Quote_Item_Length_Id, "0.1");
            SendKeys(attributeName_id, LTL_Quote_Item_Width_Id, "1.50");
            SendKeys(attributeName_id, LTL_Quote_Item_Height_Id, "12.00");

            string length = GetAttribute(attributeName_id, LTL_Quote_Item_Length_Id, "value");
            string width = GetAttribute(attributeName_id, LTL_Quote_Item_Width_Id, "value");
            string height = GetAttribute(attributeName_id, LTL_Quote_Item_Height_Id, "value");

            if (Convert.ToDouble(length) != 0.1 && Convert.ToDouble(width) != 1.50 && Convert.ToDouble(height) != 12.00)
            {
                Report.WriteLine("Dimension fields are not not accepting decimal values");
            }
            else
            {
                Report.WriteLine("Dimension fields are not accepting decimal values");
            }

        }


        [Then(@"I am not allowed to enter decimal values in the added additional Items for Length, Width, Height field(.*)")]
        public void ThenIAmNotAllowedToEnterDecimalValuesInTheAddedAdditionalItemsForLengthWidthHeightField(string p0)
        {
            Report.WriteLine("I am not allowed to enter decimal values in the added additional Items for Length, Width, Height field");
            scrollElementIntoView(attributeName_xpath, "//*[text()='Freight Description']");
            for (int i = 1; i <= 9; i++)
            {

                SendKeys(attributeName_id, "length-" + i, "0.10");
                SendKeys(attributeName_id, "width-" + i, "1.50");
                SendKeys(attributeName_id, "height-" + i, "12.00");

                string length = GetAttribute(attributeName_id, "length-" + i, "value");
                string width = GetAttribute(attributeName_id, "width-" + i, "value");
                string height = GetAttribute(attributeName_id, "height-" + i, "value");


                if (Convert.ToDouble(length) != 0.1 && Convert.ToDouble(width) != 1.50 && Convert.ToDouble(height) != 12.00)
                {
                    Report.WriteLine("Dimension fields are not not accepting decimal values");
                }
                else
                {
                    Report.WriteLine("Dimension fields are not accepting decimal values");
                }
            }
        }


        [Then(@"the maximum length of Length, Width, Height field is restricted to three digit(.*)")]
        public void ThenTheMaximumLengthOfLengthWidthHeightFieldIsRestrictedToThreeDigit(string p0)
        {
            Report.WriteLine("the maximum length of Length, Width, Height field is restricted to three digit");
            SendKeys(attributeName_id, LTL_Quote_Item_Length_Id, "9999");
            SendKeys(attributeName_id, LTL_Quote_Item_Width_Id, "9999");
            SendKeys(attributeName_id, LTL_Quote_Item_Height_Id, "9999");

            string length = GetAttribute(attributeName_id, LTL_Quote_Item_Length_Id, "value");
            string width = GetAttribute(attributeName_id, LTL_Quote_Item_Width_Id, "value");
            string height = GetAttribute(attributeName_id, LTL_Quote_Item_Height_Id, "value");

            if (Convert.ToInt32(length) == 9999 && Convert.ToInt32(width) == 9999 && Convert.ToInt32(height) == 9999)
            {
                Report.WriteFailure("Dimension is accepting more than 3 interger");
            }
            else if (Convert.ToInt32(length) == 999 && Convert.ToInt32(width) == 999 && Convert.ToInt32(height) == 999)
            {
                Report.WriteLine("Dimension is accepting more than 3 interger");
            }

        }

        [Then(@"the maximum length of Length, Width, Height field in the added additional Items is restricted to three digit(.*)")]
        public void ThenTheMaximumLengthOfLengthWidthHeightFieldInTheAddedAdditionalItemsIsRestrictedToThreeDigit(string p0)
        {
            Report.WriteLine("the maximum length of Length, Width, Height field in the added additional Items is restricted to three digit");
            scrollElementIntoView(attributeName_xpath, "//*[text()='Freight Description']");
            for (int i = 1; i <= 9; i++)
            {

                SendKeys(attributeName_id, "length-" + i, "9999");
                SendKeys(attributeName_id, "width-" + i, "9999");
                SendKeys(attributeName_id, "height-" + i, "9999");

                string length = GetAttribute(attributeName_id, "length-" + i, "value");
                string width = GetAttribute(attributeName_id, "width-" + i, "value");
                string height = GetAttribute(attributeName_id, "height-" + i, "value");

                if (Convert.ToInt32(length) == 9999 && Convert.ToInt32(width) == 9999 && Convert.ToInt32(height) == 9999)
                {
                    Report.WriteFailure("Dimension is accepting more than 3 interger");
                }
                else if (Convert.ToInt32(length) == 999 && Convert.ToInt32(width) == 999 && Convert.ToInt32(height) == 999)
                {
                    Report.WriteLine("Dimension is accepting more than 3 interger");
                }
            }
        }


        [Then(@"I will see a new Dimension Type drop down list,")]
        public void ThenIWillSeeANewDimensionTypeDropDownList()
        {
            Report.WriteLine("I will see a new Dimension Type drop down list");
            VerifyElementVisible(attributeName_xpath, LTL_Quote_Item_DimensionType_dropdown_Xpath, "IN");
        }


        [Then(@"I will see a new Dimension Type drop down list in the added additional items")]
        public void ThenIWillSeeANewDimensionTypeDropDownListInTheAddedAdditionalItems()
        {
            Report.WriteLine("I will see a new Dimension Type drop down list in the added additional items");
            scrollElementIntoView(attributeName_xpath, "//*[text()='Freight Description']");
            for (int i = 1; i <= 9; i++)
            {
                VerifyElementVisible(attributeName_xpath, ".//*[@id='dimensionunit_" + i + "_chosen']/a", "IN");
            }
        }



        [Then(@"the default Dimension Type selection is (.*),")]
        public void ThenTheDefaultDimensionTypeSelectionIs(string p0)
        {
            Report.WriteLine("the default Dimension Type selection is **");
            string defaultDimensionTypeUI = Gettext(attributeName_xpath, LTL_Quote_Item_DimensionType_dropdown_Xpath);
            string expecteddefaultDimensionType = "IN";
            Assert.AreEqual(expecteddefaultDimensionType, defaultDimensionTypeUI);
        }


        [Then(@"the default Dimension Type selection is (.*) in the added additional items")]
        public void ThenTheDefaultDimensionTypeSelectionIsInTheAddedAdditionalItems(string p0)
        {
            Report.WriteLine("the default Dimension Type selection is ** in the added additional items");
            scrollElementIntoView(attributeName_xpath, "//*[text()='Freight Description']");
            string expecteddefaultDimensionType = "IN";
            for (int i = 1; i <= 9; i++)
            {

                string defaultDimensionTypeUI = Gettext(attributeName_xpath, ".//*[@id='dimensionunit_" + i + "_chosen']/a");

                Assert.AreEqual(expecteddefaultDimensionType, defaultDimensionTypeUI);
            }
        }



        [Then(@"I have the option to select (.*) as a Dimension Type\.")]
        public void ThenIHaveTheOptionToSelectAsADimensionType_(string p0)
        {
            Report.WriteLine("I have the option to select ** as a Dimension Type");
            Click(attributeName_xpath, LTL_Quote_Item_DimensionType_dropdown_Xpath);
            IList<IWebElement> weekUI_List = GlobalVariables.webDriver.FindElements(By.XPath(LTL_Quote_Item_DimensionType_dropdownList_Xpath));
            List<string> actualWeekUI_List = weekUI_List.Select(c => c.Text).ToList();
            List<string> expectedWeekDropDownOptions = new List<string>
           {
               "IN", "FT"//, "METER", "CM"
           };
            CollectionAssert.AreEqual(actualWeekUI_List, expectedWeekDropDownOptions);
        }


        [Then(@"I have the option to select (.*) as a Dimension Type in the added additional items")]
        public void ThenIHaveTheOptionToSelectAsADimensionTypeInTheAddedAdditionalItems(string p0)
        {
            Report.WriteLine("I have the option to select ** as a Dimension Type in the added additional items");
            scrollElementIntoView(attributeName_xpath, "//*[text()='Freight Description']");
            for (int i = 1; i <= 9; i++)
            {
                Click(attributeName_xpath, ".//*[@id='dimensionunit_" + i + "_chosen']/a");
                IList<IWebElement> weekUI_List = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='dimensionunit_" + i + "_chosen']/div/ul/li"));
                List<string> actualWeekUI_List = weekUI_List.Select(c => c.Text).ToList();
                List<string> expectedWeekDropDownOptions = new List<string>
           {
               "IN", "FT"//, "METER", "CM"
           };
                CollectionAssert.AreEqual(actualWeekUI_List, expectedWeekDropDownOptions);
            }
        }


        [When(@"I click on the Add Additional Item button")]
        public void WhenIClickOnTheAddAdditionalItemButton()
        {
            Report.WriteLine("I click on the Add Additional Item button");
            for (int i = 0; i < 9; i++)
            {
                Click(attributeName_xpath, LTL_AddAdditionalItemLink_Xpath);
            }
        }

        [Then(@"I will see new optional Dimension fields for added additional Items in the Freight Description section")]
        public void ThenIWillSeeNewOptionalDimensionFieldsForAddedAdditionalItemsInTheFreightDescriptionSection()
        {
            Report.WriteLine("I will see new optional Dimension fields for added additional Items in the Freight Description section");
            scrollElementIntoView(attributeName_xpath, "//*[text()='Freight Description']");
            for (int i = 1; i <= 9; i++)
            {
                VerifyElementPresent(attributeName_id, "length-" + i, "Length");
                VerifyElementPresent(attributeName_id, "width-" + i, "Width");
                VerifyElementPresent(attributeName_id, "height-" + i, "Height");
            }
        }

        [Given(@"I am on the Get Quote \(LTL\) page")]
        public void GivenIAmOnTheGetQuoteLTLPage()
        {
            Report.WriteLine("I am on the Get Quote (LTL) page");

            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, QuoteIconModule_Xpath);
            Report.WriteLine("Navigated to Quote list page");

            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Click on Submit Rate Request");
            Click(attributeName_id, SubmitRateRequestButton_Id);

            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Click on LTL tile");
            Click(attributeName_id, LTL_TileLabel_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [When(@"I am on the Get Quote \(LTL\) page")]
        public void WhenIAmOnTheGetQuoteLTLPage()
        {
            Report.WriteLine("When I am on the Get Quote (LTL) page");

            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, QuoteIconModule_Xpath);
            Report.WriteLine("Navigated to Quote list page");

            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, CustomerDropdownExtuser_Xpath);
            Click(attributeName_xpath, PrimaryCustomerAccountsDropdownValues_Xpath);

            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Click on Submit Rate Request");
            Click(attributeName_id, SubmitRateRequestButton_Id);

            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Click on LTL tile");
            Click(attributeName_id, LTL_TileLabel_Id);

        }

        [When(@"I click Clear Item Link")]
        public void WhenIClickClearItemLink()
        {
            Report.WriteLine("I click Clear Item Link");
            Click(attributeName_id, LTL_ClearItem_Id);
            
        }

        [Given(@"I have changed dimemsion type defalut to Feet (.*)")]
        public void GivenIHaveChangedDimemsionTypeDefalutToFeet(string p0)
        {
            Report.WriteLine("I have changed dimemsion type defalut to Feet");
            Click(attributeName_xpath, LTL_Quote_Item_DimensionType_dropdown_Xpath);
            Click(attributeName_xpath, ".//*[@id='dimensionunit_0_chosen']/div/ul/li[2]");
        }


        [When(@"the Dimension Type will be bind with the default  dimension type (.*)")]
        public void WhenTheDimensionTypeWillBeBindWithTheDefaultDimensionType(string p0)
        {
            Report.WriteLine("the Dimension Type will be bind with the default  dimension type");
            string defaultDimensionTypeUI = Gettext(attributeName_xpath, LTL_Quote_Item_DimensionType_dropdown_Xpath);
            string expecteddefaultDimensionType = "IN";
            Assert.AreEqual(expecteddefaultDimensionType, defaultDimensionTypeUI);
        }

    }


}
