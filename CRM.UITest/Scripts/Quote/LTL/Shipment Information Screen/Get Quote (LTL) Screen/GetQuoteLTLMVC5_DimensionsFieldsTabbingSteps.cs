using TechTalk.SpecFlow;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;

namespace CRM.UITest.Scripts.Quote.LTL.Shipment_Information_Screen.Get_Quote__LTL__Screen
{
    [Binding]
    public class GetQuoteLTLMVC5_DimensionsFieldsTabbingSteps : ObjectRepository
    {
        string length = "15";
        string width = "15";
        string height = "15";

        [Given(@"I clicked on the (.*) field in the Freight Description section")]
        public void GivenIClickedOnTheFieldInTheFreightDescriptionSection(string dimension)
        {
            if (dimension == "Length")
            {
                Report.WriteLine("Click on Length field");
                Click(attributeName_id, LTL_Length_Id);
            }
            else if (dimension == "Width")
            {
                Report.WriteLine("Click on Width field");
                Click(attributeName_id, LTL_Width_Id);
            }
            else if (dimension == "Height")
            {
                Report.WriteLine("Click on Height field");
                Click(attributeName_id, LTL_Height_Id);
            }
        }

        [Given(@"I arrive at any of the (.*) fields in the Freight Description section")]
        public void GivenIArriveAtAnyOfTheFieldsInTheFreightDescriptionSection(string dimension)
        {
            if (dimension == "Length")
            {
                Report.WriteLine($"{"Enter"} {length} {"in length field"}");
                SendKeys(attributeName_id, LTL_Length_Id, length);

                Report.WriteLine("Hit Tab");
                IWebElement _activeElement_From = GlobalVariables.webDriver.SwitchTo().ActiveElement();
                _activeElement_From.SendKeys(Keys.Tab);
                IWebElement _activeElementFrom = GlobalVariables.webDriver.SwitchTo().ActiveElement();
                _activeElementFrom.SendKeys(Keys.Shift + Keys.Tab);

                Report.WriteLine("Arrive on Length field");
            }
            else if (dimension == "Width")
            {
                Report.WriteLine($"{"Enter"} {width} {"in width field"}");
                SendKeys(attributeName_id, LTL_Width_Id, width);
                Report.WriteLine("Hit Tab");
                IWebElement _activeElement_From = GlobalVariables.webDriver.SwitchTo().ActiveElement();
                _activeElement_From.SendKeys(Keys.Tab);
                IWebElement _activeElementFrom = GlobalVariables.webDriver.SwitchTo().ActiveElement();
                _activeElementFrom.SendKeys(Keys.Shift + Keys.Tab);

                Report.WriteLine("Arrive on Width field");
            }
            else if (dimension == "Height")
            {
                Report.WriteLine($"{"Enter"} {height} {"in height field"}");
                SendKeys(attributeName_id, LTL_Height_Id, height);
                Report.WriteLine("Hit Tab");
                IWebElement _activeElement_From = GlobalVariables.webDriver.SwitchTo().ActiveElement();
                _activeElement_From.SendKeys(Keys.Tab);
                IWebElement _activeElementFrom = GlobalVariables.webDriver.SwitchTo().ActiveElement();
                _activeElementFrom.SendKeys(Keys.Shift + Keys.Tab);

                Report.WriteLine("Arrive on Height field");
            }
        }

        [Given(@"There is (.*) value in the field")]
        public void GivenThereIsValueInTheField(string dimension)
        {
            if (dimension == "Length")
            {
                Report.WriteLine($"{"Enter"} {length} {"in length field"}");
                SendKeys(attributeName_id, LTL_Length_Id, length);
            }
            else if (dimension == "Width")
            {
                Report.WriteLine($"{"Enter"} {width} {"in with field"}");
                SendKeys(attributeName_id, LTL_Width_Id, width);
            }
            else if (dimension == "Height")
            {
                Report.WriteLine($"{"Enter"} {height} {"in height field"}");
                SendKeys(attributeName_id, LTL_Height_Id, height);
            }
        }

        [Given(@"I arrive at any of the (.*) fields having values in the Freight Description section")]
        public void GivenIArriveAtAnyOfTheFieldsHavingValuesInTheFreightDescriptionSection(string dimension)
        {
            if (dimension == "Length")
            {
                Report.WriteLine($"{"Enter"} {length} {"in length field"}");
                SendKeys(attributeName_id, LTL_Length_Id, length);
                Report.WriteLine("Hit Tab");
                IWebElement _activeElement_From = GlobalVariables.webDriver.SwitchTo().ActiveElement();
                _activeElement_From.SendKeys(Keys.Tab);
                IWebElement _activeElementFrom = GlobalVariables.webDriver.SwitchTo().ActiveElement();
                _activeElementFrom.SendKeys(Keys.Shift + Keys.Tab);
            }
            else if (dimension == "Width")
            {
                Report.WriteLine($"{"Enter"} {width} {"in width field"}");
                SendKeys(attributeName_id, LTL_Width_Id, width);
                Report.WriteLine("Hit Tab");
                IWebElement _activeElement_From = GlobalVariables.webDriver.SwitchTo().ActiveElement();
                _activeElement_From.SendKeys(Keys.Tab);
                IWebElement _activeElementFrom = GlobalVariables.webDriver.SwitchTo().ActiveElement();
                _activeElementFrom.SendKeys(Keys.Shift + Keys.Tab);
            }
            else if (dimension == "Height")
            {
                Report.WriteLine($"{"Enter"} {height} {"in height field"}");
                SendKeys(attributeName_id, LTL_Height_Id, height);
                Report.WriteLine("Hit Tab");
                IWebElement _activeElement_From = GlobalVariables.webDriver.SwitchTo().ActiveElement();
                _activeElement_From.SendKeys(Keys.Shift + Keys.Tab);
                IWebElement _activeElementFrom = GlobalVariables.webDriver.SwitchTo().ActiveElement();
                _activeElementFrom.SendKeys(Keys.Tab);
            }
        }

        [When(@"I hit the Tab button on Get Quote Page")]
        public void WhenIHitTheTabButtonOnGetQuotePage()
        {
            IWebElement _activeElement_From = GlobalVariables.webDriver.SwitchTo().ActiveElement();

            Report.WriteLine("Hit Tab");
            _activeElement_From.SendKeys(Keys.Tab);
        }

        [When(@"I enter value (.*) in the field (.*)")]
        public void WhenIEnterValueInTheField(string dimensionOldValue, string dimension)
        {
            if (dimension == "Length")
            {
                Report.WriteLine($"{"Enter"} {dimensionOldValue} {"in length field"}");
                SendKeys(attributeName_id, LTL_Length_Id, dimensionOldValue);
            }
            else if (dimension == "Width")
            {
                Report.WriteLine($"{"Enter"} {dimensionOldValue} {"in width field"}");
                SendKeys(attributeName_id, LTL_Width_Id, dimensionOldValue);
            }
            else if (dimension == "Height")
            {
                Report.WriteLine($"{"Enter"} {dimensionOldValue} {"in height field"}");
                SendKeys(attributeName_id, LTL_Height_Id, dimensionOldValue);
            }
        }

        [When(@"I back tab out of the field Shift \+ Tab")]
        public void WhenIBackTabOutOfTheFieldShiftTab()
        {
            IWebElement _activeElement_From = GlobalVariables.webDriver.SwitchTo().ActiveElement();

            Report.WriteLine("Hit Shift + Tab");
            _activeElement_From.SendKeys(Keys.Shift + Keys.Tab);
        }

        [When(@"there is a value in the field (.*)")]
        public void WhenThereIsAValueInTheField(string dimension)
        {
            if (dimension == "Length")
            {
                Report.WriteLine($"{"Enter"} {length} {"in length field"}");
                SendKeys(attributeName_id, LTL_Length_Id, length);
                Report.WriteLine("Hit Tab");
                IWebElement _activeElement_From = GlobalVariables.webDriver.SwitchTo().ActiveElement();
                _activeElement_From.SendKeys(Keys.Shift + Keys.Tab);
                IWebElement _activeElementFrom = GlobalVariables.webDriver.SwitchTo().ActiveElement();
                _activeElementFrom.SendKeys(Keys.Tab);
            }
            else if (dimension == "Width")
            {
                Report.WriteLine($"{"Enter"} {width} {"in width field"}");
                SendKeys(attributeName_id, LTL_Width_Id, width);
                Report.WriteLine("Hit Tab");
                IWebElement _activeElement_From = GlobalVariables.webDriver.SwitchTo().ActiveElement();
                _activeElement_From.SendKeys(Keys.Shift + Keys.Tab);
                IWebElement _activeElementFrom = GlobalVariables.webDriver.SwitchTo().ActiveElement();
                _activeElementFrom.SendKeys(Keys.Tab);
            }
            else if (dimension == "Height")
            {
                Report.WriteLine($"{"Enter"} {height} {"in height field"}");
                SendKeys(attributeName_id, LTL_Height_Id, height);
                Report.WriteLine("Hit Tab");
                IWebElement _activeElement_From = GlobalVariables.webDriver.SwitchTo().ActiveElement();
                _activeElement_From.SendKeys(Keys.Shift + Keys.Tab);
                IWebElement _activeElementFrom = GlobalVariables.webDriver.SwitchTo().ActiveElement();
                _activeElementFrom.SendKeys(Keys.Tab);
            }
        }

        [When(@"I click on backspace")]
        public void WhenIClickOnBackspace()
        {
            IWebElement _activeElement_From = GlobalVariables.webDriver.SwitchTo().ActiveElement();

            Report.WriteLine("Hit Backspace");
            _activeElement_From.SendKeys(Keys.Backspace);
        }

        [When(@"I click on Space Bar")]
        public void WhenIClickOnSpaceBar()
        {
            IWebElement _activeElement_From = GlobalVariables.webDriver.SwitchTo().ActiveElement();

            Report.WriteLine("Hit Space bar");
            _activeElement_From.SendKeys(Keys.Space);
        }

        [Then(@"I will arrive on (.*) field in the Freight Description section")]
        public void ThenIWillArriveOnFieldInTheFreightDescriptionSection(string nextDimension)
        {
            if (nextDimension == "Width")
            {
                IWebElement _activeElement_From = GlobalVariables.webDriver.SwitchTo().ActiveElement();
                string activeElementId = _activeElement_From.GetAttribute("id");

                Report.WriteLine("Verifying that the active element is Width field");
                Assert.AreEqual(LTL_Width_Id, activeElementId);
            }
            else if (nextDimension == "Height")
            {
                IWebElement _activeElement_From = GlobalVariables.webDriver.SwitchTo().ActiveElement();
                string activeElementId = _activeElement_From.GetAttribute("id");

                Report.WriteLine("Verifying that the active element is Height field");
                Assert.AreEqual(LTL_Height_Id, activeElementId);
            }
            else if (nextDimension == "View Quote Results")
            {
                IWebElement _activeElement_From = GlobalVariables.webDriver.SwitchTo().ActiveElement();
                string activeElementId = _activeElement_From.GetAttribute("id");

                Report.WriteLine("Verifying that the active element is View Quote Results field");
                Assert.AreEqual(LTL_ViewQuoteResults_Id, activeElementId);
            }
        }

        [Then(@"I will arrive on field (.*) in Freight Description section")]
        public void ThenIWillArriveOnFieldInFreightDescriptionSection(string previousDimension)
        {
            if (previousDimension == "Weight")
            {
                IWebElement _activeElement_From = GlobalVariables.webDriver.SwitchTo().ActiveElement();
                string activeElementId = _activeElement_From.GetAttribute("id");

                Report.WriteLine("Verifying that the active element is weight field");
                Assert.AreEqual(LTL_Weight_Id, activeElementId);
            }
            else if (previousDimension == "Length")
            {
                IWebElement _activeElement_From = GlobalVariables.webDriver.SwitchTo().ActiveElement();
                string activeElementId = _activeElement_From.GetAttribute("id");

                Report.WriteLine("Verifying that the active element is Length field");
                Assert.AreEqual(LTL_Length_Id, activeElementId);
            }
            else if (previousDimension == "Width")
            {
                IWebElement _activeElement_From = GlobalVariables.webDriver.SwitchTo().ActiveElement();
                string activeElementId = _activeElement_From.GetAttribute("id");

                Report.WriteLine("Verifying that the active element is Width field");
                Assert.AreEqual(LTL_Width_Id, activeElementId);
            }
        }

        [Then(@"the (.*) value in the field will be highlighted")]
        public void ThenTheValueInTheFieldWillBeHighlighted_(string dimension)
        {
            if (dimension == "Length")
            {
                object selectedTextInBrowser = ((IJavaScriptExecutor)GlobalVariables.webDriver).ExecuteScript("return window.getSelection().toString()");
                string lengthValueFromUI = GetValue(attributeName_id, LTL_Length_Id, "value");

                Report.WriteLine("Verifying that the length value is highlighted");
                Assert.AreEqual(lengthValueFromUI, selectedTextInBrowser.ToString());
            }
            else if (dimension == "Width")
            {
                object selectedTextInBrowser = ((IJavaScriptExecutor)GlobalVariables.webDriver).ExecuteScript("return window.getSelection().toString()");
                string widthValueFromUI = GetValue(attributeName_id, LTL_Width_Id, "value");

                Report.WriteLine("Verifying that the width value is highlighted");
                Assert.AreEqual(widthValueFromUI, selectedTextInBrowser.ToString());
            }
            else if (dimension == "Height")
            {
                object selectedTextInBrowser = ((IJavaScriptExecutor)GlobalVariables.webDriver).ExecuteScript("return window.getSelection().toString()");
                string heightValueFromUI = GetValue(attributeName_id, LTL_Height_Id, "value");

                Report.WriteLine("Verifying that the height value is highlighted");
                Assert.AreEqual(heightValueFromUI, selectedTextInBrowser.ToString());
            }
        }

        [Then(@"previous values will be over-written with (.*) in the field (.*)")]
        public void ThenPreviousValuesWillBeOver_WrittenWithInTheField(string dimensionNewValue, string dimension)
        {
            if (dimension == "Length")
            {
                string lengthValue = GetValue(attributeName_id, LTL_Length_Id, "value");

                Report.WriteLine("Verifying that the length value is over-written with " + dimensionNewValue);
                Assert.AreEqual(dimensionNewValue, lengthValue);
            }
            else if (dimension == "Width")
            {
                string widthValue = GetValue(attributeName_id, LTL_Width_Id, "value");

                Report.WriteLine("Verifying that the width value is over-written with " + dimensionNewValue);
                Assert.AreEqual(dimensionNewValue, widthValue);
            }
            else if (dimension == "Height")
            {
                string heightValue = GetValue(attributeName_id, LTL_Height_Id, "value");

                Report.WriteLine("Verifying that the height value is over-written with " + dimensionNewValue);
                Assert.AreEqual(dimensionNewValue, heightValue);
            }
        }

        [Then(@"the (.*) value will be removed")]
        public void ThenTheValueWillBeRemoved(string dimension)
        {
            if (dimension == "Length")
            {
                string lengthValueFromUI = GetValue(attributeName_id, LTL_Length_Id, "value")?.Trim();

                Report.WriteLine("Verifying that the length value removed");
                Assert.AreEqual(string.Empty, lengthValueFromUI);
            }
            else if (dimension == "Width")
            {
                string widthValueFromUI = GetValue(attributeName_id, LTL_Width_Id, "value")?.Trim();

                Report.WriteLine("Verifying that the Width value removed");
                Assert.AreEqual(string.Empty, widthValueFromUI);
            }
            if (dimension == "Height")
            {
                string heightValueFromUI = GetValue(attributeName_id, LTL_Height_Id, "value")?.Trim();

                Report.WriteLine("Verifying that the Height value removed");
                Assert.AreEqual(string.Empty, heightValueFromUI);
            }
        }

    }
}
