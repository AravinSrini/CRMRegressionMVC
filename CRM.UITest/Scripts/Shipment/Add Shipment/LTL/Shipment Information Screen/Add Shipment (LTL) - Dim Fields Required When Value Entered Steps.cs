using CRM.UITest.Objects;
using iTextSharp.text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Information_Screen
{
    [Binding]
    public class Add_Shipment__LTL____Dim_Fields_Required_When_Value_Entered_Steps : AddShipments
    {
        [When(@"I enter the following values in the Freight length width and height fields ""(.*)"", ""(.*)"", ""(.*)""")]
        public void WhenIEnterTheFollowingValuesInTheFreightLengthWidthAndHeightFields(string length, string width, string height)
        {
            Thread.Sleep(10000);
            if(!length.Equals(""))
            {
                SendKeys(attributeName_id, FreightDesp_FirstItem_Length_Id, length);
            }
            else
            {
                Clear(attributeName_id, FreightDesp_FirstItem_Length_Id);
            }
            Thread.Sleep(1000);
            if (!width.Equals(""))
            {
                SendKeys(attributeName_id, FreightDesp_FirstItem_Width_Id, width);
            }
            else
            {
                Clear(attributeName_id, FreightDesp_FirstItem_Width_Id);
            }
            Thread.Sleep(1000);
            if (!height.Equals(""))
            {
                SendKeys(attributeName_id, FreightDesp_FirstItem_Height_Id, height);
            }
            else
            {
                Clear(attributeName_id, FreightDesp_FirstItem_Height_Id);
            }
        }

        [When(@"I enter the following values in the Freight length width and height fields for an additional item ""(.*)"", ""(.*)"", ""(.*)""")]
        public void WhenIEnterTheFollowingValuesInTheFreightLengthWidthAndHeightFieldsForAnAdditionalItem(string length, string width, string height)
        {
            Thread.Sleep(10000);
            Click(attributeName_xpath, AddAdditionalItemButton_xpath);

            if(!length.Equals(""))
            {
                SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_Length_Id, length);
            }
            else
            {
                Clear(attributeName_id, FreightDesp_First_AdditionalItem_Length_Id);
            }
            Thread.Sleep(1000);
            if (!width.Equals(""))
            {
                SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_Width_Id, width);
            }
            else
            {
                Clear(attributeName_id, FreightDesp_First_AdditionalItem_Width_Id);
            }
            Thread.Sleep(1000);
            if (!height.Equals(""))
            {
                SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_Height_Id, height);
            }
            else
            {
                Clear(attributeName_id, FreightDesp_First_AdditionalItem_Height_Id);
            }
        }

        [Given(@"I have NOT selected Overlength as a freight accessorial in either of the following sections: Shipping From, Shipping To")]
        public void GivenIHaveNOTSelectedOverlengthAsAFreightAccessorialInEitherOfTheFollowingSectionsShippingFromShippingTo()
        {
            Thread.Sleep(10000);
            Report.WriteLine("Overlength has not selected as accessorial");
            Click(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            if (GlobalVariables.webDriver.FindElements(By.XPath(ShippingFrom_AccessorialsDropDown_Overlength_xpath)).Count > 0)
                Click(attributeName_xpath, ShippingFrom_AccessorialsDropDown_Overlength_xpath);
        }

        [When(@"I have selected Overlength as a freight accessorial in the Shipping From field")]
        public void WhenIHaveSelectedOverlengthAsAFreightAccessorialInTheShippingFromField()
        {
            scrollElementIntoView(attributeName_xpath, ShippingFrom_ServicesAccessorial_DropDown_xpath);
            scrollPageup();
            Click(attributeName_xpath, ShippingFrom_AccessorialsDropDown_Values_xpath);
            SendKeys(attributeName_xpath, ShippingFrom_ServicesAccessorial_DropDown_xpath, "Overlength");
            SendKeys(attributeName_xpath, ShippingFrom_ServicesAccessorial_DropDown_xpath, Keys.Enter);
        }

        [When(@"I have un-selected Overlength as a freight accessorial in the Shipping From field")]
        public void WhenIHaveUn_SelectedOverlengthAsAFreightAccessorialInTheShippingFromField()
        {
            Thread.Sleep(1000);
            Click(attributeName_xpath, ShippingFrom_AccessorialsDropDown_Overlength_xpath);
        }

        [When(@"I remove the freight value for Length")]
        public void WhenIRemoveTheFreightValueForLength()
        {
            Thread.Sleep(1000);
            GlobalVariables.webDriver.FindElement(By.Id(FreightDesp_FirstItem_Length_Id)).SendKeys(Keys.Backspace);
        }

        [When(@"I remove the value for freight Length for the additional item")]
        public void WhenIRemoveTheValueForFreightLengthForTheAdditionalItem()
        {
            Thread.Sleep(1000);
            GlobalVariables.webDriver.FindElement(By.Id(FreightDesp_First_AdditionalItem_Length_Id)).SendKeys(Keys.Backspace);
        }

        [When(@"I click Clear Item for the freight item")]
        public void WhenIClickClearItemForTheFreightItem()
        {
            Click(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
        }

        [When(@"I click Clear Item for the freight additional item")]
        public void WhenIClickClearItemForTheFreightAdditionalItem()
        {
            Click(attributeName_id, FreightDesp_First_AdditionalItem_ClearItem_Button_Id);
        }


        [Then(@"the Freight Length, Width, and Height fields will be required")]
        public void ThenTheFreightLengthWidthAndHeightFieldsWillBeRequired()
        {
            Thread.Sleep(1000);
            var lengthElement = GlobalVariables.webDriver.FindElement(By.XPath(FreightDesp_FirstItem_Length_Div_xpath));
            var widthElement = GlobalVariables.webDriver.FindElement(By.XPath(FreightDesp_FirstItem_Width_Div_xpath));
            var heightElement = GlobalVariables.webDriver.FindElement(By.XPath(FreightDesp_FirstItem_Height_Div_xpath));

            Assert.IsTrue(elementHasClass(lengthElement, Required_Input_Field_Shipment));
            Assert.IsTrue(elementHasClass(widthElement, Required_Input_Field_Shipment));
            Assert.IsTrue(elementHasClass(heightElement, Required_Input_Field_Shipment));
        }

        [Then(@"the Freight Length, Width, and Height fields will not be required")]
        public void ThenTheFreightLengthWidthAndHeightFieldsWillNotBeRequired()
        {
            Thread.Sleep(5000);
            var lengthElement = GlobalVariables.webDriver.FindElement(By.XPath(FreightDesp_FirstItem_Length_Div_xpath));
            var widthElement = GlobalVariables.webDriver.FindElement(By.XPath(FreightDesp_FirstItem_Width_Div_xpath));
            var heightElement = GlobalVariables.webDriver.FindElement(By.XPath(FreightDesp_FirstItem_Height_Div_xpath));

            Assert.IsFalse(elementHasClass(lengthElement, Required_Input_Field_Shipment));
            Assert.IsFalse(elementHasClass(widthElement, Required_Input_Field_Shipment));
            Assert.IsFalse(elementHasClass(heightElement, Required_Input_Field_Shipment));
        }

        [Then(@"the Freight Length, Width, and Height fields will be required for the additional item")]
        public void ThenTheFreightLengthWidthAndHeightFieldsWillBeRequiredForTheAdditionalItem()
        {
            Thread.Sleep(1000);
            var lengthElement = GlobalVariables.webDriver.FindElement(By.XPath(FreightDesp_First_AdditionalItem_Length_Div_xpath));
            var widthElement = GlobalVariables.webDriver.FindElement(By.XPath(FreightDesp_First_AdditionalItem_Width_Div_xpath));
            var heightElement = GlobalVariables.webDriver.FindElement(By.XPath(FreightDesp_First_AdditionalItem_Height_Div_xpath));

            Assert.IsTrue(elementHasClass(lengthElement, Required_Input_Field_Shipment));
            Assert.IsTrue(elementHasClass(widthElement, Required_Input_Field_Shipment));
            Assert.IsTrue(elementHasClass(heightElement, Required_Input_Field_Shipment));
        }

        [Then(@"the Freight Length, Width, and Height fields will not be required for the additional item")]
        public void ThenTheFreightLengthWidthAndHeightFieldsWillNotBeRequiredForTheAdditionalItem()
        {
            Thread.Sleep(1000);
            var lengthElement = GlobalVariables.webDriver.FindElement(By.XPath(FreightDesp_First_AdditionalItem_Length_Div_xpath));
            var widthElement = GlobalVariables.webDriver.FindElement(By.XPath(FreightDesp_First_AdditionalItem_Width_Div_xpath));
            var heightElement = GlobalVariables.webDriver.FindElement(By.XPath(FreightDesp_First_AdditionalItem_Height_Div_xpath));

            Assert.IsFalse(elementHasClass(lengthElement, Required_Input_Field_Shipment));
            Assert.IsFalse(elementHasClass(widthElement, Required_Input_Field_Shipment));
            Assert.IsFalse(elementHasClass(heightElement, Required_Input_Field_Shipment));
        }

        public bool elementHasClass(IWebElement element, string requiredInput) { return element.GetAttribute("class").Contains(requiredInput); }
    }
}
