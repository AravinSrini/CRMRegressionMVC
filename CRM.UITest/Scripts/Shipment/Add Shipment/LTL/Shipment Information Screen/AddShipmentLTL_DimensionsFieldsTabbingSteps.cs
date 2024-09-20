using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Information_Screen
{
    [Binding]
    public class AddShipmentLTL_DimensionsFieldsTabbingSteps : AddShipments
    {
        CommonMethodsCrm crm = new CommonMethodsCrm();

        [Given(@"I am a CRM operations, sales, sales management, or station owner user (.*) (.*)")]
        public void GivenIAmACRMOperationsSalesSalesManagementOrStationOwnerUser(string UserName, string Password)
        {
            Report.WriteLine("Login to CRM Application");
            crm.LoginToCRMApplication(UserName, Password);
        }

        [Given(@"I am a CRM shp\.entry, shp\.entrynorates user (.*) (.*)")]
        public void GivenIAmACRMShp_EntryShp_EntrynoratesUser(string UserName, string Password)
        {
            Report.WriteLine("Login to CRM Application");
            crm.LoginToCRMApplication(UserName, Password);
        }

        [Given(@"I am on the Internal User LTL Add Shipment page (.*)")]
        public void GivenIAmOnTheInternalUserLTLAddShipmentPage(string CustomerAccount)
        {
            Report.WriteLine("Navigate to Shipment List");
            GlobalVariables.webDriver.WaitForPageLoad();
            AddShipmentLTL ltl = new AddShipmentLTL();
            ltl.NaviagteToShipmentList();
            GlobalVariables.webDriver.WaitForPageLoad();

            Report.WriteLine("Navigate to Add Shipment Page");
            ltl.SelectCustomerFromShipmentList("Internal", CustomerAccount);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I am on the External User LTL Add Shipment page")]
        public void GivenIAmOnTheExternalUserLTLAddShipmentPage()
        {
            Report.WriteLine("Navigate to Shipment List");
            GlobalVariables.webDriver.WaitForPageLoad();
            AddShipmentLTL ltl = new AddShipmentLTL();
            ltl.NaviagteToShipmentList();
            GlobalVariables.webDriver.WaitForPageLoad();

            Report.WriteLine("Navigate to Add Shipment Page");
            ltl.SelectCustomerFromShipmentList("External", string.Empty);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I clicked in the Length field in the Freight Description section")]
        public void GivenIClickedInTheLengthFieldInTheFreightDescriptionSection()
        {
            Report.WriteLine("Click on Length field");
            Click(attributeName_id, FreightDesp_FirstItem_Length_Id);
        }

        [Given(@"I clicked in the Width field in the Freight Description section")]
        public void GivenIClickedInTheWidthFieldInTheFreightDescriptionSection()
        {
            Report.WriteLine("Click on Width field");
            Click(attributeName_id, FreightDesp_FirstItem_Width_Id);
        }

        [Given(@"I clicked in the Height field in the Freight Description section")]
        public void GivenIClickedInTheHeightFieldInTheFreightDescriptionSection()
        {
            Report.WriteLine("Click on Height field");
            Click(attributeName_id, FreightDesp_FirstItem_Height_Id);
        }

        [Given(@"there is a value in the Length field (.*)")]
        public void GivenThereIsAValueInTheLengthField(string length)
        {
            Report.WriteLine($"{"Enter"} {length} {"in length field"}");
            SendKeys(attributeName_id, FreightDesp_FirstItem_Length_Id, length);
        }

        [Given(@"there is a value in the Width field (.*)")]
        public void GivenThereIsAValueInTheWidthField(string width)
        {
            Report.WriteLine($"{"Enter"} {width} {"in width field"}");
            SendKeys(attributeName_id, FreightDesp_FirstItem_Width_Id, width);
        }

        [Given(@"there is a value in the Height field (.*)")]
        public void GivenThereIsAValueInTheHeightField(string height)
        {
            Report.WriteLine($"{"Enter"} {height} {"in height field"}");
            SendKeys(attributeName_id, FreightDesp_FirstItem_Height_Id, height);
        }

        [Given(@"I arrive at the Length field by hitting Shift Tab from Width in the Freight Description section")]
        public void GivenIArriveAtTheLengthFieldByHittingShiftTabFromWidthInTheFreightDescriptionSection()
        {
            Report.WriteLine("Click on width field");
            Click(attributeName_id, FreightDesp_FirstItem_Width_Id);

            Report.WriteLine("Hit Shift + Tab");
            IWebElement _activeElement_From = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            _activeElement_From.SendKeys(Keys.Shift + Keys.Tab);

            Report.WriteLine("Arrive on length field");
        }

        [Given(@"I arrive at the Width field by hitting Tab from Length in the Freight Description section")]
        public void GivenIArriveAtTheWidthFieldByHittingTabFromLengthInTheFreightDescriptionSection()
        {
            Report.WriteLine("Click on length field");
            Click(attributeName_id, FreightDesp_FirstItem_Length_Id);

            Report.WriteLine("Hit Tab");
            IWebElement _activeElement_From = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            _activeElement_From.SendKeys(Keys.Tab);

            Report.WriteLine("Arrive on width field");
        }

        [Given(@"I arrive at the Width field by hitting Shift Tab from Height in the Freight Description section")]
        public void GivenIArriveAtTheWidthFieldByHittingShiftTabFromHeightInTheFreightDescriptionSection()
        {
            Report.WriteLine("Click on height field");
            Click(attributeName_id, FreightDesp_FirstItem_Height_Id);

            Report.WriteLine("Hit Shift + Tab");
            IWebElement _activeElement_From = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            _activeElement_From.SendKeys(Keys.Shift + Keys.Tab);

            Report.WriteLine("Arrive on width field");
        }

        [Given(@"I arrive at the Height field by hitting Tab from Width in the Freight Description section")]
        public void GivenIArriveAtTheHeightFieldByHittingTabFromWidthInTheFreightDescriptionSection()
        {
            Report.WriteLine("Click on width field");
            Click(attributeName_id, FreightDesp_FirstItem_Width_Id);

            Report.WriteLine("Hit Tab");
            IWebElement _activeElement_From = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            _activeElement_From.SendKeys(Keys.Tab);

            Report.WriteLine("Arrive on height field");
        }

        [When(@"there is a value in the Length field (.*)")]
        public void WhenThereIsAValueInTheLengthField(string length)
        {
            Report.WriteLine($"{"Enter"} {length} {"in length field"}");
            SendKeys(attributeName_id, FreightDesp_FirstItem_Length_Id, length);
        }

        [When(@"there is a value in the Width field (.*)")]
        public void WhenThereIsAValueInTheWidthField(string width)
        {
            Report.WriteLine($"{"Enter"} {width} {"in width field"}");
            SendKeys(attributeName_id, FreightDesp_FirstItem_Width_Id, width);
        }

        [When(@"there is a value in the Height field (.*)")]
        public void WhenThereIsAValueInTheHeightField(string height)
        {
            Report.WriteLine($"{"Enter"} {height} {"in height field"}");
            SendKeys(attributeName_id, FreightDesp_FirstItem_Height_Id, height);
        }

        [When(@"I arrive at the Length field by hitting Shift Tab from Width in the Freight Description section")]
        public void WhenIArriveAtTheLengthFieldByHittingShiftTabFromWidthInTheFreightDescriptionSection()
        {
            Report.WriteLine("Click on width field");
            Click(attributeName_id, FreightDesp_FirstItem_Width_Id);

            Report.WriteLine("Hit Shift + Tab");
            IWebElement _activeElement_From = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            _activeElement_From.SendKeys(Keys.Shift + Keys.Tab);

            Report.WriteLine("Arrive on length field");
        }

        [When(@"I arrive at the Width field by hitting Tab from Length in the Freight Description section")]
        public void WhenIArriveAtTheWidthFieldByHittingTabFromLengthInTheFreightDescriptionSection()
        {
            Report.WriteLine("Click on length field");
            Click(attributeName_id, FreightDesp_FirstItem_Length_Id);

            Report.WriteLine("Hit Tab");
            IWebElement _activeElement_From = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            _activeElement_From.SendKeys(Keys.Tab);

            Report.WriteLine("Arrive on width field");
        }

        [When(@"I arrive at the Width field by hitting Shift Tab from Height in the Freight Description section")]
        public void WhenIArriveAtTheWidthFieldByHittingShiftTabFromHeightInTheFreightDescriptionSection()
        {
            Report.WriteLine("Click on height field");
            Click(attributeName_id, FreightDesp_FirstItem_Height_Id);

            Report.WriteLine("Hit Shift + Tab");
            IWebElement _activeElement_From = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            _activeElement_From.SendKeys(Keys.Shift + Keys.Tab);

            Report.WriteLine("Arrive on width field");
        }

        [When(@"I arrive at the Height field by hitting Tab from Width in the Freight Description section")]
        public void WhenIArriveAtTheHeightFieldByHittingTabFromWidthInTheFreightDescriptionSection()
        {
            Report.WriteLine("Click on width field");
            Click(attributeName_id, FreightDesp_FirstItem_Width_Id);

            Report.WriteLine("Hit Tab");
            IWebElement _activeElement_From = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            _activeElement_From.SendKeys(Keys.Tab);

            Report.WriteLine("Arrive on height field");
        }

        [When(@"I hit the Tab button")]
        public void WhenIHitTheTabButton()
        {
            IWebElement _activeElement_From = GlobalVariables.webDriver.SwitchTo().ActiveElement();

            Report.WriteLine("Hit Tab");
            _activeElement_From.SendKeys(Keys.Tab);
        }

        [When(@"I back tab out of the field Shift Tab")]
        public void WhenIBackTabOutOfTheFieldShiftTab()
        {
            IWebElement _activeElement_From = GlobalVariables.webDriver.SwitchTo().ActiveElement();

            Report.WriteLine("Hit Shift + Tab");
            _activeElement_From.SendKeys(Keys.Shift + Keys.Tab);
        }

        [When(@"I enter any value in the Length field  (.*)")]
        public void WhenIEnterAnyValueInTheLengthField(string length)
        {
            Report.WriteLine($"{"Enter"} {length} {"in length field"}");
            SendKeys(attributeName_id, FreightDesp_FirstItem_Length_Id, length);
        }

        [When(@"I enter any value in the Width field (.*)")]
        public void WhenIEnterAnyValueInTheWidthField(string width)
        {
            Report.WriteLine($"{"Enter"} {width} {"in width field"}");
            SendKeys(attributeName_id, FreightDesp_FirstItem_Width_Id, width);
        }

        [When(@"I enter any value in the Height field (.*)")]
        public void WhenIEnterAnyValueInTheHeightField(string height)
        {
            Report.WriteLine($"{"Enter"} {height} {"in height field"}");
            SendKeys(attributeName_id, FreightDesp_FirstItem_Height_Id, height);
        }

        [When(@"I hit Backspace")]
        public void WhenIHitBackspace()
        {
            IWebElement _activeElement_From = GlobalVariables.webDriver.SwitchTo().ActiveElement();

            Report.WriteLine("Hit Backspace");
            _activeElement_From.SendKeys(Keys.Backspace);
        }

        [When(@"I hit Space Bar")]
        public void WhenIHitSpaceBar()
        {
            IWebElement _activeElement_From = GlobalVariables.webDriver.SwitchTo().ActiveElement();

            Report.WriteLine("Hit Space bar");
            _activeElement_From.SendKeys(Keys.Space);
        }

        [Then(@"I will arrive in the Width field in the Freight Description section")]
        public void ThenIWillArriveInTheWidthFieldInTheFreightDescriptionSection()
        {
            IWebElement _activeElement_From = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            string activeElementId = _activeElement_From.GetAttribute("id");

            Report.WriteLine("Verification that the active element is Weight field");
            Assert.AreEqual(FreightDesp_FirstItem_Width_Id, activeElementId);
        }

        [Then(@"I will arrive in the Height field in the Freight Description section")]
        public void ThenIWillArriveInTheHeightFieldInTheFreightDescriptionSection()
        {
            IWebElement _activeElement_From = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            string activeElementId = _activeElement_From.GetAttribute("id");

            Report.WriteLine("Verification that the active element is Height field");
            Assert.AreEqual(FreightDesp_FirstItem_Height_Id, activeElementId);
        }

        [Then(@"I will arrive on the View Rates button")]
        public void ThenIWillArriveOnTheViewRatesButton()
        {
            IWebElement _activeElement_From = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            string activeElementClass = _activeElement_From.GetAttribute("class");

            Report.WriteLine("Verification that the active element is Viewrates button");
            Assert.IsTrue(activeElementClass.Contains("viewrates"));
        }

        [Then(@"I will arrive in the Weight field in the Freight Description section")]
        public void ThenIWillArriveInTheWeightFieldInTheFreightDescriptionSection()
        {
            IWebElement _activeElement_From = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            string activeElementId = _activeElement_From.GetAttribute("id");

            Report.WriteLine("Verification that the active element is weight field");
            Assert.AreEqual(FreightDesp_FirstItem_Weight_Id, activeElementId);
        }

        [Then(@"I will arrive in the Length field in the Freight Description section")]
        public void ThenIWillArriveInTheLengthFieldInTheFreightDescriptionSection()
        {
            IWebElement _activeElement_From = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            string activeElementId = _activeElement_From.GetAttribute("id");

            Report.WriteLine("Verification that the active element is length field");
            Assert.AreEqual(FreightDesp_FirstItem_Length_Id, activeElementId);
        }

        [Then(@"the value in the Length field will be highlighted")]
        public void ThenTheValueInTheLengthFieldWillBeHighlighted()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            object selectedTextInBrowser = ((IJavaScriptExecutor)GlobalVariables.webDriver).ExecuteScript("return window.getSelection().toString()");
            string lengthValue = GetValue(attributeName_id, FreightDesp_FirstItem_Length_Id, "value");

            Report.WriteLine("Verification that the length value is highlighted");
            Assert.AreEqual(lengthValue, selectedTextInBrowser.ToString());
        }

        [Then(@"the value in the Width field will be highlighted")]
        public void ThenTheValueInTheWidthFieldWillBeHighlighted()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            object selectedTextInBrowser = ((IJavaScriptExecutor)GlobalVariables.webDriver).ExecuteScript("return window.getSelection().toString()");
            string widthValue = GetValue(attributeName_id, FreightDesp_FirstItem_Width_Id, "value");

            Report.WriteLine("Verification that the width value is highlighted");
            Assert.AreEqual(widthValue, selectedTextInBrowser.ToString());
        }

        [Then(@"the value in the Height field will be highlighted")]
        public void ThenTheValueInTheHeightFieldWillBeHighlighted()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            object selectedTextInBrowser = ((IJavaScriptExecutor)GlobalVariables.webDriver).ExecuteScript("return window.getSelection().toString()");
            string heightValue = GetValue(attributeName_id, FreightDesp_FirstItem_Height_Id, "value");

            Report.WriteLine("Verification that the height value is highlighted");
            Assert.AreEqual(heightValue, selectedTextInBrowser.ToString());
        }

        [Then(@"the previous value in the Length will be over-written (.*)")]
        public void ThenThePreviousValueInTheLengthWillBeOver_Written(string newLengthValue)
        {
            string lengthValue = GetValue(attributeName_id, FreightDesp_FirstItem_Length_Id, "value");

            Report.WriteLine("Verification that the length value is over-written with " + newLengthValue);
            Assert.AreEqual(newLengthValue, lengthValue);
        }

        [Then(@"the previous value in the Width will be over-written (.*)")]
        public void ThenThePreviousValueInTheWidthWillBeOver_Written(string newWidthValue)
        {
            string widthValue = GetValue(attributeName_id, FreightDesp_FirstItem_Width_Id, "value");

            Report.WriteLine("Verification that the width value is over-written with " + newWidthValue);
            Assert.AreEqual(newWidthValue, widthValue);
        }

        [Then(@"the previous value in the Height will be over-written (.*)")]
        public void ThenThePreviousValueInTheHeightWillBeOver_Written(string newHeightValue)
        {
            string heightValue = GetValue(attributeName_id, FreightDesp_FirstItem_Height_Id, "value");

            Report.WriteLine("Verification that the height value is over-written with " + newHeightValue);
            Assert.AreEqual(newHeightValue, heightValue);
        }

        [Then(@"the value in the Length will be removed")]
        public void ThenTheValueInTheLengthWillBeRemoved()
        {
            string lengthValue = GetValue(attributeName_id, FreightDesp_FirstItem_Length_Id, "value")?.Trim();

            Report.WriteLine("Verification that the length value removed");
            Assert.AreEqual(string.Empty, lengthValue);
        }

        [Then(@"the value in the Width will be removed")]
        public void ThenTheValueInTheWidthWillBeRemoved()
        {
            string widthValue = GetValue(attributeName_id, FreightDesp_FirstItem_Width_Id, "value")?.Trim();

            Report.WriteLine("Verification that the width value removed");
            Assert.AreEqual(string.Empty, widthValue);
        }

        [Then(@"the value in the Height will be removed")]
        public void ThenTheValueInTheHeightWillBeRemoved()
        {
            string heightValue = GetValue(attributeName_id, FreightDesp_FirstItem_Height_Id, "value")?.Trim();

            Report.WriteLine("Verification that the height value removed");
            Assert.AreEqual(string.Empty, heightValue);
        }
    }
}
