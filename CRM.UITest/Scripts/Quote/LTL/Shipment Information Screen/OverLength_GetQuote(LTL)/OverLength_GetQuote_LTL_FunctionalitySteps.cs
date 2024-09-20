using TechTalk.SpecFlow;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System.Threading;
using System.Text.RegularExpressions;

namespace CRM.UITest.Scripts.Quote.LTL.Shipment_Information_Screen.OverLength_GetQuote_LTL_
{
    [Binding]
    public class OverLength_GetQuote_LTL_FunctionalitySteps : ObjectRepository
    {
        [When(@"I selected services and accessorials as Overlength in Shipping From section")]
        public void WhenISelectedServicesAndAccessorialsAsOverlengthInShippingFromSection()
        {
            Click(attributeName_xpath, LTL_ServicesAndAccessorials_ShipFrom_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, LTL_ServicesAndAccessorials_ShipFrom_Xpath, "Overlength");
        }

        [Then(@"Length, Width, Height will becomes required fields for each item")]
        public void ThenLengthWidthHeightWillBecomesRequiredFieldsForEachItem()
        {
            scrollElementIntoView(attributeName_xpath, "//*[text()='Freight Description']");
            Click(attributeName_id, LTL_ClearItem_Id);
            Report.WriteLine("Adding two additional items");
            scrollElementIntoView(attributeName_xpath, LTL_Quote_AdditionalItem_button_Xpath);
            Click(attributeName_xpath, LTL_Quote_AdditionalItem_button_Xpath);
            scrollElementIntoView(attributeName_xpath, LTL_Quote_AdditionalItem_button_Xpath);
            Click(attributeName_xpath, LTL_Quote_AdditionalItem_button_Xpath);

            Report.WriteLine("Clicking on View Quote Results button");
            Click(attributeName_id, LTL_ViewQuoteResults_Id);
            for (int i = 0; i < 3; i++)
            {
                Report.WriteLine("Verifying Red-highlighted background color Length textbox");
                string actualbackgroundcolor_Length = GetCSSValue(attributeName_id, "length-" + i, "background-color");
                string expectedbackgroundcolor = null;
                if (actualbackgroundcolor_Length == "rgba(251, 236, 236, 1)")
                {
                    expectedbackgroundcolor = "rgba(251, 236, 236, 1)";
                }
                else if (actualbackgroundcolor_Length == "rgb(251, 236, 236)")
                {
                    expectedbackgroundcolor = "rgb(251, 236, 236)";
                }

                Assert.AreEqual(expectedbackgroundcolor, actualbackgroundcolor_Length);
                Report.WriteLine("Verifying Orange Color border Length textbox");
                string actualbordercolor_Length = GetCSSValue(attributeName_id, "length-" + i, "border-color");
                string expectedbordercolor = "rgb(255, 184, 69)";
                Assert.AreEqual(expectedbordercolor, actualbordercolor_Length);


                Report.WriteLine("Verifying Red-highlighted background color Width textbox");
                string actualbackgroundcolor_Width = GetCSSValue(attributeName_id, "width-" + i, "background-color");
                Assert.AreEqual(expectedbackgroundcolor, actualbackgroundcolor_Width);
                Report.WriteLine("Verifying Orange Color border Width textbox");
                string actualbordercolor_Width = GetCSSValue(attributeName_id, "width-" + i, "border-color");
                Assert.AreEqual(expectedbordercolor, actualbordercolor_Width);

                Report.WriteLine("Verifying Red-highlighted background color Height textbox");
                string actualbackgroundcolor_Height = GetCSSValue(attributeName_id, "height-" + i, "background-color");
                Assert.AreEqual(expectedbackgroundcolor, actualbackgroundcolor_Height);
                Report.WriteLine("Verifying Orange Color border Height textbox");
                string actualbordercolor_Height = GetCSSValue(attributeName_id, "height-" + i, "border-color");
                Assert.AreEqual(expectedbordercolor, actualbordercolor_Height);
            }
        }

        [When(@"I selected services and accessorials as Overlength in Shipping To section")]
        public void WhenISelectedServicesAndAccessorialsAsOverlengthInShippingToSection()
        {
            Click(attributeName_xpath, LTL_ServicesAndAccessorials_ShipTo_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, LTL_ServicesDropdownValues_ShipTo_Xpath, "Overlength");
        }

        [When(@"I selected services and accessorials as other than Overlength in Shipping From section")]
        public void WhenISelectedServicesAndAccessorialsAsOtherThanOverlengthInShippingFromSection()
        {
            Click(attributeName_xpath, LTL_ServicesAndAccessorials_ShipFrom_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, LTL_ServicesAndAccessorials_ShipFrom_Xpath, "Appointment");
        }

        [Then(@"Length, Width, Height will not be required fields for each item")]
        public void ThenLengthWidthHeightWillNotBeRequiredFieldsForEachItem()
        {
            Report.WriteLine("Adding two additional items");
            scrollElementIntoView(attributeName_xpath, "//*[text()='Freight Description']");
            Click(attributeName_id, LTL_ClearItem_Id);
            Report.WriteLine("Adding two additional items");
            scrollElementIntoView(attributeName_xpath, LTL_Quote_AdditionalItem_button_Xpath);
            Click(attributeName_xpath, LTL_Quote_AdditionalItem_button_Xpath);
            scrollElementIntoView(attributeName_xpath, LTL_Quote_AdditionalItem_button_Xpath);
            Click(attributeName_xpath, LTL_Quote_AdditionalItem_button_Xpath);

            Report.WriteLine("Clicking on View Quote Results button");
            Click(attributeName_id, LTL_ViewQuoteResults_Id);
            for (int i = 0; i < 3; i++)
            {
                Report.WriteLine("Verifying Red-highlighted background color Length textbox");
                string actualbackgroundcolor_Length = GetCSSValue(attributeName_id, "length-" + i, "background-color");
                string expectedbackgroundcolor = "rgba(255, 255, 255, 1)";
                Assert.AreEqual(expectedbackgroundcolor, actualbackgroundcolor_Length);
                Report.WriteLine("Verifying Orange Color border Length textbox");
                string actualbordercolor_Length = GetCSSValue(attributeName_id, "length-" + i, "border-color");
                string expectedbordercolor = "rgb(209, 211, 212)";
                Assert.AreEqual(expectedbordercolor, actualbordercolor_Length);


                Report.WriteLine("Verifying Red-highlighted background color Width textbox");
                string actualbackgroundcolor_Width = GetCSSValue(attributeName_id, "width-" + i, "background-color");
                Assert.AreEqual(expectedbackgroundcolor, actualbackgroundcolor_Width);
                Report.WriteLine("Verifying Orange Color border Width textbox");
                string actualbordercolor_Width = GetCSSValue(attributeName_id, "width-" + i, "border-color");
                Assert.AreEqual(expectedbordercolor, actualbordercolor_Width);

                Report.WriteLine("Verifying Red-highlighted background color Height textbox");
                string actualbackgroundcolor_Height = GetCSSValue(attributeName_id, "height-" + i, "background-color");
                Assert.AreEqual(expectedbackgroundcolor, actualbackgroundcolor_Height);
                Report.WriteLine("Verifying Orange Color border Height textbox");
                string actualbordercolor_Height = GetCSSValue(attributeName_id, "height-" + i, "border-color");
                Assert.AreEqual(expectedbordercolor, actualbordercolor_Height);
            }
        }

        [When(@"I selected services and accessorials as other than Overlength in Shipping To section")]
        public void WhenISelectedServicesAndAccessorialsAsOtherThanOverlengthInShippingToSection()
        {
            Click(attributeName_xpath, LTL_ServicesAndAccessorials_ShipTo_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, LTL_ServicesDropdownValues_ShipTo_Xpath, "Liftgate Delivery");
        }

        [When(@"the entered Length value is greater than 96 Inches")]
        public void WhenTheEnteredLengthValueIsGreaterThanInches()
        {
            scrollElementIntoView(attributeName_xpath, "//*[text()='Freight Description']");
            Report.WriteLine("Adding two additional items");
            Click(attributeName_id, LTL_ClearItem_Id);
            scrollElementIntoView(attributeName_xpath, LTL_Quote_AdditionalItem_button_Xpath);
            Click(attributeName_xpath, LTL_Quote_AdditionalItem_button_Xpath);
            scrollElementIntoView(attributeName_xpath, LTL_Quote_AdditionalItem_button_Xpath);
            Click(attributeName_xpath, LTL_Quote_AdditionalItem_button_Xpath);

            for (int i = 0; i < 3; i++)
            {

                SendKeys(attributeName_id, "length-" + i, "100");

            }
        }

        [Then(@"the Overlength will be auto selected in the Shipping From section services and accessorials field")]
        public void ThenTheOverlengthWillBeAutoSelectedInTheShippingFromSectionServicesAndAccessorialsField()
        {
            string ActualText = Gettext(attributeName_xpath, ".//*[@id='servicesaccessorialsfrom_chosen']/ul");
            Assert.AreEqual(ActualText, "Overlength");
        }

        [Then(@"I have option to remove the Overlength accessorial")]
        public void ThenIHaveOptionToRemoveTheOverlengthAccessorial()
        {
            Click(attributeName_xpath, LTL_Quote_ShippingFrom_Selected_FirstAccessorial_RemoveOption_Xpath);
            Click(attributeName_xpath, ".//*[@id='servicesaccessorialsto_chosen']/ul");
            Thread.Sleep(3000);
            string ActualText = Gettext(attributeName_xpath, ".//*[@id='servicesaccessorialsfrom_chosen']/ul");
            Assert.AreEqual(string.Empty, ActualText);

        }

        [Then(@"I have option to add any other accessorials")]
        public void ThenIHaveOptionToAddAnyOtherAccessorials()
        {
            Click(attributeName_xpath, ".//*[@id='servicesaccessorialsfrom_chosen']/ul");
            SelectDropdownValueFromList(attributeName_xpath, LTL_ServicesAndAccessorials_ShipFrom_Xpath, "Appointment");
        }

        [When(@"the entered Length value is equal to 96 Inches")]
        public void WhenTheEnteredLengthValueIsEqualToInches()
        {
            scrollElementIntoView(attributeName_xpath, "//*[text()='Freight Description']");
            Report.WriteLine("Adding two additional items");
            Click(attributeName_id, LTL_ClearItem_Id);
            scrollElementIntoView(attributeName_xpath, LTL_Quote_AdditionalItem_button_Xpath);
            Click(attributeName_xpath, LTL_Quote_AdditionalItem_button_Xpath);
            scrollElementIntoView(attributeName_xpath, LTL_Quote_AdditionalItem_button_Xpath);
            Click(attributeName_xpath, LTL_Quote_AdditionalItem_button_Xpath);
            for (int i = 0; i < 3; i++)
            {
                if (i != 2)
                {
                    SendKeys(attributeName_id, "length-" + i, "50");
                }
                else
                {
                    SendKeys(attributeName_id, "length-" + i, "96");
                }

            }
        }

        [When(@"the entered Length value is less than 96 Inches")]
        public void WhenTheEnteredLengthValueIsLessThanInches()
        {
            scrollElementIntoView(attributeName_xpath, "//*[text()='Freight Description']");
            Click(attributeName_id, LTL_ClearItem_Id);
            Report.WriteLine("Adding two additional items");
            scrollElementIntoView(attributeName_xpath, LTL_Quote_AdditionalItem_button_Xpath);
            Click(attributeName_xpath, LTL_Quote_AdditionalItem_button_Xpath);
            Click(attributeName_xpath, LTL_Quote_AdditionalItem_button_Xpath);
            for (int i = 0; i < 3; i++)
            {
                SendKeys(attributeName_id, "length-" + i, "50");
            }
        }

        [Then(@"the Overlength will be not be auto selected in the Shipping From section services and accessorials field")]
        public void ThenTheOverlengthWillBeNotBeAutoSelectedInTheShippingFromSectionServicesAndAccessorialsField()
        {
            string ActualText = Gettext(attributeName_xpath, ".//*[@id='servicesaccessorialsfrom_chosen']/ul");
            Assert.AreEqual(string.Empty, ActualText);
        }

        [When(@"the entered Length value is greater than 8 Feet")]
        public void WhenTheEnteredLengthValueIsGreaterThanFeet()
        {
            Report.WriteLine("Entering Length value of 10 Feet in the first Item Length field");
            scrollElementIntoView(attributeName_xpath, "//*[text()='Freight Description']");
            Click(attributeName_id, LTL_ClearItem_Id);
            Click(attributeName_xpath, LTL_Quote_Item_DimensionType_dropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, LTL_Quote_Item_DimensionType_dropdownList_Xpath, "FT");
            SendKeys(attributeName_id, LTL_Quote_Item_Length_Id, "10");
        }

        [When(@"the entered Length value is equal to 8 Feet")]
        public void WhenTheEnteredLengthValueIsEqualToFeet()
        {
            scrollElementIntoView(attributeName_xpath, "//*[text()='Freight Description']");
            Report.WriteLine("Adding two additional items");
            Click(attributeName_id, LTL_ClearItem_Id);
            scrollElementIntoView(attributeName_xpath, LTL_Quote_AdditionalItem_button_Xpath);
            Click(attributeName_xpath, LTL_Quote_AdditionalItem_button_Xpath);
            scrollElementIntoView(attributeName_xpath, LTL_Quote_AdditionalItem_button_Xpath);
            Click(attributeName_xpath, LTL_Quote_AdditionalItem_button_Xpath);
            for (int i = 0; i < 3; i++)
            {
                if (i < 2)
                {
                    Click(attributeName_xpath, ".//*[@id='dimensionunit_" + i + "_chosen']/a");
                    SelectDropdownValueFromList(attributeName_xpath, ".//*[@id='dimensionunit_" + i + "_chosen']/div/ul/li", "FT");
                    SendKeys(attributeName_id, "length-" + i, "2");
                }
                else
                {
                    Click(attributeName_xpath, ".//*[@id='dimensionunit_" + i + "_chosen']/a");
                    SelectDropdownValueFromList(attributeName_xpath, ".//*[@id='dimensionunit_" + i + "_chosen']/div/ul/li", "FT");
                    SendKeys(attributeName_id, "length-" + i, "8");
                }
            }
        }

        [When(@"the entered Length value is less than 8 Feet")]
        public void WhenTheEnteredLengthValueIsLessThanFeet()
        {
            scrollElementIntoView(attributeName_xpath, "//*[text()='Freight Description']");
            Report.WriteLine("Adding two additional items");
            Click(attributeName_id, LTL_ClearItem_Id);
            scrollElementIntoView(attributeName_xpath, LTL_Quote_AdditionalItem_button_Xpath);
            Click(attributeName_xpath, LTL_Quote_AdditionalItem_button_Xpath);
            scrollElementIntoView(attributeName_xpath, LTL_Quote_AdditionalItem_button_Xpath);
            Click(attributeName_xpath, LTL_Quote_AdditionalItem_button_Xpath);
            for (int i = 0; i < 3; i++)
            {
                Click(attributeName_xpath, ".//*[@id='dimensionunit_" + i + "_chosen']/a");
                SelectDropdownValueFromList(attributeName_xpath, ".//*[@id='dimensionunit_" + i + "_chosen']/div/ul/li", "FT");
                SendKeys(attributeName_id, "length-" + i, "2");
            }
        }

        [When(@"the entered value of Length is greater than 96 Inches")]
        public void WhenTheEnteredValueOfLengthIsGreaterThanInches()
        {
            scrollElementIntoView(attributeName_xpath, "//*[text()='Freight Description']");
            Click(attributeName_id, LTL_ClearItem_Id);
            Report.WriteLine("Entering Length value of 100 Inches in the first Item Length field");
            SendKeys(attributeName_id, LTL_Quote_Item_Length_Id, "100");
        }

        [Then(@"I will see a Warning PopUp with Verbiage for the length greater than 96 Inches (.*)")]
        public void ThenIWillSeeAWarningPopUpWithVerbiageForTheLengthGreaterThanInches( string warningMessage)
        {
            string _warningMessage = Regex.Replace(warningMessage, @"(<|>)", "");
            VerifyElementVisible(attributeName_id, LTL_Quote_EnteredLengthExceeds_PopUp_Item_Id, "Warning PopUp for the entered length greater than 96 inches");
            Verifytext(attributeName_id, LTL_Quote_EnteredLengthExceedsPopUp_Message_Item_Id, _warningMessage);
        }

        [Then(@"I have options to remove the Warning PopUp of this entered length greater than 96 Inches")]
        public void ThenIHaveOptionsToRemoveTheWarningPopUpOfThisEnteredLengthGreaterThanInches()
        {
            Report.WriteLine("Verifying the option to remove the Warning PopUp for the entered length greater than 96 Inches");
            Click(attributeName_xpath, LTL_Quote_EnteredLengthExceedsPopUp_RemoveOption_Item_Xpath);
            Thread.Sleep(1000);
            VerifyElementNotVisible(attributeName_id, LTL_Quote_EnteredLengthExceeds_PopUp_Item_Id, "Warning PopUp for the entered length greater than 96 inches");
        }

        [When(@"the entered value of Length is equal to 96 Inches")]
        public void WhenTheEnteredValueOfLengthIsEqualToInches()
        {
            scrollElementIntoView(attributeName_xpath, "//*[text()='Freight Description']");
            Click(attributeName_id, LTL_ClearItem_Id);
            Report.WriteLine("Adding two additional items");
            scrollElementIntoView(attributeName_xpath, LTL_Quote_AdditionalItem_button_Xpath);

            Click(attributeName_xpath, LTL_Quote_AdditionalItem_button_Xpath);
            Click(attributeName_xpath, LTL_Quote_AdditionalItem_button_Xpath);
            for (int i = 0; i < 3; i++)
            {
                if (i < 2)
                {
                    SendKeys(attributeName_id, "length-" + i, "50");
                }
                else
                {
                    SendKeys(attributeName_id, "length-" + i, "96");
                }
            }
        }

        [Then(@"I will see a Warning PopUp with Verbiage for the length equal to 96 Inches (.*)")]
        public void ThenIWillSeeAWarningPopUpWithVerbiageForTheLengthEqualToInches(string warningMessage)
        {
            string _warningMessage = Regex.Replace(warningMessage, @"(<|>)", "");

            VerifyElementVisible(attributeName_id, LTL_Quote_EnteredLengthExceeds_PopUp_AdditionalItem2_Id, "Warning PopUp for the entered length greater than 96 inches");
            Verifytext(attributeName_id, LTL_Quote_EnteredLengthExceedsPopUp_Message_AdditionalItem2_Id, _warningMessage);
        }

        [Then(@"I have options to remove the Warning PopUp of this entered length equal to 96 Inches")]
        public void ThenIHaveOptionsToRemoveTheWarningPopUpOfThisEnteredLengthEqualToInches()
        {
            Click(attributeName_xpath, LTL_Quote_EnteredLengthExceedsPopUp_RemoveOption_AdditionalItem2_Xpath);
            Thread.Sleep(1000);
            VerifyElementNotVisible(attributeName_id, LTL_Quote_EnteredLengthExceeds_PopUp_AdditionalItem2_Id, "Warning PopUp for the entered length equal to 96 inches");
        }

        [When(@"the entered value of Length is less than 96 Inches")]
        public void WhenTheEnteredValueOfLengthIsLessThanInches()
        {
            scrollElementIntoView(attributeName_xpath, "//*[text()='Freight Description']");
            Click(attributeName_id, LTL_ClearItem_Id);
            Report.WriteLine("Adding two additional items");
            scrollElementIntoView(attributeName_xpath, LTL_Quote_AdditionalItem_button_Xpath);

            Click(attributeName_xpath, LTL_Quote_AdditionalItem_button_Xpath);
            Click(attributeName_xpath, LTL_Quote_AdditionalItem_button_Xpath);
            for (int i = 0; i < 3; i++)
            {
                SendKeys(attributeName_id, "length-" + i, "50");
            }
        }

        [Then(@"I will not see a Warning PopUp for the entered length less than 96 Inches")]
        public void ThenIWillNotSeeAWarningPopUpForTheEnteredLengthLessThanInches()
        {
            Report.WriteLine("Verifying the absence of Warning PopUp for the entered length less than 96 Inches");
            for (int i = 0; i < 3; i++)
            {
                VerifyElementNotVisible(attributeName_id, "Length-Exceeds-Warning-" + i, "Entered Length Exceeds Warning PopUp");
            }
        }

        [When(@"the entered value of Length is greater than 8 Feet")]
        public void WhenTheEnteredValueOfLengthIsGreaterThanFeet()
        {
            scrollElementIntoView(attributeName_xpath, "//*[text()='Freight Description']");
            Click(attributeName_id, LTL_ClearItem_Id);
            Report.WriteLine("Entering Length value of 10 Feet in the first Item Length field");
            Click(attributeName_xpath, LTL_Quote_Item_DimensionType_dropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, LTL_Quote_Item_DimensionType_dropdownList_Xpath, "FT");
            SendKeys(attributeName_id, LTL_Quote_Item_Length_Id, "10");
        }

        [Then(@"I will see Warning PopUp with the Verbiage for the entered length greater than 8 Feet(.*)")]
        public void ThenIWillSeeWarningPopUpWithTheVerbiageForTheEnteredLengthGreaterThanFeet(string warningMessage)
        {
            string _warningMessage = Regex.Replace(warningMessage, @"(<|>)", "");
            VerifyElementVisible(attributeName_id, LTL_Quote_EnteredLengthExceeds_PopUp_Item_Id, "Warning PopUp for the entered length greater than 96 inches");
            Verifytext(attributeName_id, LTL_Quote_EnteredLengthExceedsPopUp_Message_Item_Id, _warningMessage);
        }

        [Then(@"I have options to remove the Warning PopUp of this entered length greater than 8 Feet")]
        public void ThenIHaveOptionsToRemoveTheWarningPopUpOfThisEnteredLengthGreaterThanFeet()
        {
            Report.WriteLine("Verifying the option to remove the Warning PopUp for the entered length greater than 96 Inches");
            Click(attributeName_xpath, LTL_Quote_EnteredLengthExceedsPopUp_RemoveOption_Item_Xpath);
            Thread.Sleep(1000);
            VerifyElementNotVisible(attributeName_id, LTL_Quote_EnteredLengthExceeds_PopUp_Item_Id, "Warning PopUp for the entered length greater than 8 Feet");
        }

        [When(@"the entered value of Length is equal to 8 Feet")]
        public void WhenTheEnteredValueOfLengthIsEqualToFeet()
        {
            Report.WriteLine("Adding two additional items");
            scrollElementIntoView(attributeName_xpath, "//*[text()='Freight Description']");
            Click(attributeName_id, LTL_ClearItem_Id);
            Report.WriteLine("Adding two additional items");
            scrollElementIntoView(attributeName_xpath, LTL_Quote_AdditionalItem_button_Xpath);
            Click(attributeName_xpath, LTL_Quote_AdditionalItem_button_Xpath);
            scrollElementIntoView(attributeName_xpath, LTL_Quote_AdditionalItem_button_Xpath);
            Click(attributeName_xpath, LTL_Quote_AdditionalItem_button_Xpath);
            for (int i = 0; i < 3; i++)
            {
                if (i < 2)
                {
                    Click(attributeName_xpath, ".//*[@id='dimensionunit_" + i + "_chosen']/a");
                    SelectDropdownValueFromList(attributeName_xpath, ".//*[@id='dimensionunit_" + i + "_chosen']/div/ul/li", "FT");
                    SendKeys(attributeName_id, "length-" + i, "2");
                }
                else
                {
                    Click(attributeName_xpath, ".//*[@id='dimensionunit_" + i + "_chosen']/a");
                    SelectDropdownValueFromList(attributeName_xpath, ".//*[@id='dimensionunit_" + i + "_chosen']/div/ul/li", "FT");
                    SendKeys(attributeName_id, "length-" + i, "8");
                }
            }
        }

        [Then(@"I will see Warning PopUp with the Verbiage for the entered length equal to 8 Feet(.*)")]
        public void ThenIWillSeeWarningPopUpWithTheVerbiageForTheEnteredLengthEqualToFeet(string warningMessage)
        {
            string _warningMessage = Regex.Replace(warningMessage, @"(<|>)", "");
            VerifyElementVisible(attributeName_id, LTL_Quote_EnteredLengthExceeds_PopUp_AdditionalItem2_Id, "Warning PopUp for the entered length greater than 96 inches");
            Verifytext(attributeName_id, LTL_Quote_EnteredLengthExceedsPopUp_Message_AdditionalItem2_Id, _warningMessage);
        }

        [Then(@"I have options to remove the Warning PopUp of this entered length equal to 8 Feet")]
        public void ThenIHaveOptionsToRemoveTheWarningPopUpOfThisEnteredLengthEqualToFeet()
        {
            Click(attributeName_xpath, LTL_Quote_EnteredLengthExceedsPopUp_RemoveOption_AdditionalItem2_Xpath);
            Thread.Sleep(1000);
            VerifyElementNotVisible(attributeName_id, LTL_Quote_EnteredLengthExceeds_PopUp_AdditionalItem2_Id, "Warning PopUp for the entered length equal to 96 inches");
        }

        [When(@"the entered value of Length is less than 8 Feet")]
        public void WhenTheEnteredValueOfLengthIsLessThanFeet()
        {
            scrollElementIntoView(attributeName_xpath, "//*[text()='Freight Description']");
            Click(attributeName_id, LTL_ClearItem_Id);
            Click(attributeName_xpath, LTL_Quote_Item_DimensionType_dropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, LTL_Quote_Item_DimensionType_dropdownList_Xpath, "FT");
            SendKeys(attributeName_id, LTL_Quote_Item_Length_Id, "4");

            Click(attributeName_xpath, LTL_Quote_AdditionalItem_button_Xpath);
            Click(attributeName_xpath, LTL_Quote_AdditionalItem_button_Xpath);
            for (int i = 1; i < 3; i++)
            {
                Click(attributeName_xpath, ".//*[@id='dimensionunit_" + i + "_chosen']/a");
                SelectDropdownValueFromList(attributeName_xpath, ".//*[@id='dimensionunit_" + i + "_chosen']/div/ul/li", "FT");
                SendKeys(attributeName_id, "length-" + i, "2");
            }
        }

        [Then(@"I will not see a Warning PopUp for the entered length less than 8 Feet")]
        public void ThenIWillNotSeeAWarningPopUpForTheEnteredLengthLessThanFeet()
        {
            for (int i = 0; i < 3; i++)
            {
                VerifyElementNotVisible(attributeName_id, "Length-Exceeds-Warning-" + i, "Warning PopUp for the entered length greater than 8 Feet");
            }
        }

        [Given(@"I selected Services and Accessorials as Overlength in Shipping From section")]
        public void GivenISelectedServicesAndAccessorialsAsOverlengthInShippingFromSection()
        {
            Click(attributeName_xpath, LTL_ServicesAndAccessorials_ShipFrom_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, LTL_ServicesAndAccessorials_ShipFrom_Xpath, "Overlength");
        }

        [When(@"I entered any value in Length field")]
        public void WhenIEnteredAnyValueInLengthField()
        {
            Report.WriteLine("Adding two additional items");
            scrollElementIntoView(attributeName_xpath, "//*[text()='Freight Description']");
            Report.WriteLine("Adding two additional items");
            Click(attributeName_id, LTL_ClearItem_Id);
            scrollElementIntoView(attributeName_xpath, LTL_Quote_AdditionalItem_button_Xpath);
            Click(attributeName_xpath, LTL_Quote_AdditionalItem_button_Xpath);
            scrollElementIntoView(attributeName_xpath, LTL_Quote_AdditionalItem_button_Xpath);
            Click(attributeName_xpath, LTL_Quote_AdditionalItem_button_Xpath);
            for (int i = 0; i < 3; i++)
            {
                if (i < 2)
                {
                    Click(attributeName_xpath, ".//*[@id='dimensionunit_" + (i + 1) + "_chosen']/a");
                    SelectDropdownValueFromList(attributeName_xpath, ".//*[@id='dimensionunit_" + (i + 1) + "_chosen']/div/ul/li", "FT");
                    SendKeys(attributeName_id, "length-" + i, "2");
                }
                else
                {
                    SendKeys(attributeName_id, "length-" + i, "2");
                }
            }
        }

        [Then(@"I will see a Warning PopUp with the Verbiage(.*)")]
        public void ThenIWillSeeAWarningPopUpWithTheVerbiage(string warningMessage)
        {
            for (int i = 0; i < 3; i++)
            {
                string _warningMessage = Regex.Replace(warningMessage, @"(<|>)", "");
                VerifyElementVisible(attributeName_id, "Length-Additional-Warning-" + i, "Warning PopUp for the Additional carrier fees");
                Verifytext(attributeName_id, "Additional-Warning-Message-" + i, _warningMessage);
            }
        }

        [Then(@"I have options to remove a Additional carrier fees may apply due to the selection of the Overlength accessorial Warning PopUp")]
        public void ThenIHaveOptionsToRemoveAAdditionalCarrierFeesMayApplyDueToTheSelectionOfTheOverlengthAccessorialWarningPopUp()
        {
            Click(attributeName_xpath, LTL_Quote_AddtlCarrierFeePopUp_RemoveOption_Item_Xpath);
            Thread.Sleep(1000);
            VerifyElementNotVisible(attributeName_id, LTL_Quote_AddtlCarrierFee_PopUp_Item_Id, "Warning PopUp for first Item");

            Click(attributeName_xpath, LTL_Quote_AddtlCarrierFeePopUp_RemoveOption_AdditionalItem1_Xpath);
            Thread.Sleep(1000);
            VerifyElementNotVisible(attributeName_id, LTL_Quote_AddtlCarrierFee_PopUp_AdditionalItem1_Id, "Warning PopUp for Additional Item1");

            Click(attributeName_xpath, LTL_Quote_AddtlCarrierFeePopUp_RemoveOption_AdditionalItem2_Xpath);
            Thread.Sleep(1000);
            VerifyElementNotVisible(attributeName_id, LTL_Quote_AddtlCarrierFee_PopUp_AdditionalItem2_Id, "Warning PopUp for Additional Item2");
        }

        [Given(@"I did not selected Services and Accessorials as Overlength in Shipping From and Shipping To section")]
        public void GivenIDidNotSelectedServicesAndAccessorialsAsOverlengthInShippingFromAndShippingToSection()
        {
            Click(attributeName_xpath, LTL_ServicesAndAccessorials_ShipFrom_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, LTL_ServicesAndAccessorials_ShipFrom_Xpath, "Appointment");

            Click(attributeName_xpath, LTL_ServicesAndAccessorials_ShipTo_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, LTL_ServicesDropdownValues_ShipTo_Xpath, "Liftgate Delivery");
        }

        [Then(@"I will not see Length field Warning PopUp")]
        public void ThenIWillNotSeeLengthFieldWarningPopUp()
        {
            for (int i = 0; i < 3; i++)
            {
                VerifyElementNotVisible(attributeName_id, "Length-Additional-Warning-" + i + "", "Warning PopUp for the Additional carrier fees");
            }
        }

        [Given(@"I selected Services and Accessorials as Overlength in Shipping To section")]
        public void GivenISelectedServicesAndAccessorialsAsOverlengthInShippingToSection()
        {
            Click(attributeName_xpath, LTL_ServicesAndAccessorials_ShipTo_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, LTL_ServicesDropdownValues_ShipTo_Xpath, "Overlength");
        }

        [Given(@"I entered any value in Length field")]
        public void GivenIEnteredAnyValueInLengthField()
        {
            scrollElementIntoView(attributeName_xpath, "//*[text()='Freight Description']");
            Click(attributeName_id, LTL_ClearItem_Id);
            scrollElementIntoView(attributeName_xpath, LTL_Quote_AdditionalItem_button_Xpath);
            Click(attributeName_xpath, LTL_Quote_AdditionalItem_button_Xpath);
            scrollElementIntoView(attributeName_xpath, LTL_Quote_AdditionalItem_button_Xpath);
            Click(attributeName_xpath, LTL_Quote_AdditionalItem_button_Xpath);
            SendKeys(attributeName_id, LTL_Quote_Item_Length_Id, "4");
            SendKeys(attributeName_id, LTL_Quote_Additional_Item1_Length_Id, "4");
            SendKeys(attributeName_id, LTL_Quote_Additional_Item2_Length_Id, "4");
        }

        [When(@"I clicked on the Clear Item link")]
        public void WhenIClickedOnTheClearItemLink()
        {
            Click(attributeName_id, LTL_ClearItem_Id);
            for (int i = 1; i < 3; i++)
            {
                Click(attributeName_id, "frieghtclearbtn_rates-" + i);
            }
            Thread.Sleep(1000);
        }


        [Then(@"the Length field Warning PopUp will be removed")]
        public void ThenTheLengthFieldWarningPopUpWillBeRemoved()
        {
            for (int i = 0; i < 3; i++)
            {
                VerifyElementNotVisible(attributeName_id, "Length-Additional-Warning-" + i, "Warning PopUp for the Additional carrier fees");
            }
        }

        [Given(@"I entered value of Length is greater equal to greater than 96 Inches")]
        public void GivenIEnteredValueOfLengthIsGreaterEqualToGreaterThanInches()
        {
            scrollElementIntoView(attributeName_xpath, "//*[text()='Freight Description']");
            Click(attributeName_id, LTL_ClearItem_Id);
            scrollElementIntoView(attributeName_xpath, LTL_Quote_AdditionalItem_button_Xpath);
            Click(attributeName_xpath, LTL_Quote_AdditionalItem_button_Xpath);
            scrollElementIntoView(attributeName_xpath, LTL_Quote_AdditionalItem_button_Xpath);
            Click(attributeName_xpath, LTL_Quote_AdditionalItem_button_Xpath);
            SendKeys(attributeName_id, LTL_Quote_Item_Length_Id, "96");
            SendKeys(attributeName_id, LTL_Quote_Additional_Item1_Length_Id, "100");
            SendKeys(attributeName_id, LTL_Quote_Additional_Item2_Length_Id, "999");

        }

        [Then(@"the Length field Warning PopUp will be removed for the length greater than 96 Inches")]
        public void ThenTheLengthFieldWarningPopUpWillBeRemovedForTheLengthGreaterThanInches()
        {
            for (int i = 0; i < 3; i++)
            {
                if (i != 0)
                {
                    VerifyElementNotVisible(attributeName_id, "Length-Additional-Warning-" + i, "Warning PopUp for the Additional carrier fees");
                }
                else
                {
                    VerifyElementNotVisible(attributeName_id, "Length-Exceeds-Warning-" + i, "Warning PopUp for the Additional carrier fees");
                }
            }
        }

        [Given(@"I entered value of Length is greater equal to greater than 8 Feet")]
        public void GivenIEnteredValueOfLengthIsGreaterEqualToGreaterThanFeet()
        {
            scrollElementIntoView(attributeName_xpath, "//*[text()='Freight Description']");
            Click(attributeName_id, LTL_ClearItem_Id);
            scrollElementIntoView(attributeName_xpath, LTL_Quote_AdditionalItem_button_Xpath);
            Click(attributeName_xpath, LTL_Quote_AdditionalItem_button_Xpath);
            scrollElementIntoView(attributeName_xpath, LTL_Quote_AdditionalItem_button_Xpath);
            Click(attributeName_xpath, LTL_Quote_AdditionalItem_button_Xpath);

            for (int i = 0; i < 3; i++)
            {
                Click(attributeName_xpath, ".//*[@id='dimensionunit_" + i + "_chosen']/a");
                SelectDropdownValueFromList(attributeName_xpath, ".//*[@id='dimensionunit_" + i + "_chosen']/div/ul/li", "FT");
                SendKeys(attributeName_id, "length-" + i, "9");
            }
        }

        [Then(@"the Length field Warning PopUp will be removed for the length greater than 8 Feet")]
        public void ThenTheLengthFieldWarningPopUpWillBeRemovedForTheLengthGreaterThanFeet()
        {

            for (int i = 0; i < 3; i++)
            {
                if (i != 0)
                {
                    VerifyElementNotVisible(attributeName_id, "Length-Additional-Warning-" + i + "", "Warning PopUp for the Additional carrier fees");
                }
                else
                {
                    VerifyElementNotVisible(attributeName_id, "Length-Exceeds-Warning-" + i + "", "Warning PopUp for the Additional carrier fees");
                }
            }
        }

        [Given(@"I entered Length greater than 8")]
        public void GivenIEnteredLengthGreaterThan()
        {
            scrollElementIntoView(attributeName_xpath, "//*[text()='Freight Description']");
            Click(attributeName_id, LTL_ClearItem_Id);
            Report.WriteLine("Entering Length value of 10 Feet in the first Item Length field");
            SendKeys(attributeName_id, LTL_Quote_Item_Length_Id, "10");
        }

        [Given(@"I entered Length equal to 8")]
        public void GivenIEnteredLengthEqualTo()
        {
            scrollElementIntoView(attributeName_xpath, "//*[text()='Freight Description']");
            Click(attributeName_id, LTL_ClearItem_Id);
            Report.WriteLine("Entering Length value of 10 Feet in the first Item Length field");
            SendKeys(attributeName_id, LTL_Quote_Item_Length_Id, "8");
        }

        [When(@"I change Dimension type from Inches to Feet")]
        public void WhenIOnchangeDimensionTypeFromInchesToFeet()
        {
            Click(attributeName_xpath, LTL_Quote_Item_DimensionType_dropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, LTL_Quote_Item_DimensionType_dropdownList_Xpath, "FT");
        }

        [Given(@"I entered Length less than 8")]
        public void GivenIEnteredLengthLessThan()
        {
            scrollElementIntoView(attributeName_xpath, "//*[text()='Freight Description']");
            Click(attributeName_id, LTL_ClearItem_Id);
            Report.WriteLine("Entering Length value of 10 Feet in the first Item Length field");
            SendKeys(attributeName_id, LTL_Quote_Item_Length_Id, "4");
        }

        [Then(@"I will not see Warning PopUp for the entered length less than 8 Feet")]
        public void ThenIWillNotSeeWarningPopUpForTheEnteredLengthLessThanFeet()
        {
            VerifyElementNotVisible(attributeName_id, LTL_Quote_EnteredLengthExceeds_PopUp_Item_Id, "Warning PopUp for the entered length greater than 8 FT");
        }
    }
}
