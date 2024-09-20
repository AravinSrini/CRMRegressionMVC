using System;
using System.Configuration;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Information_Screen
{
    [Binding]
    public class AddShipmentLTLMVC5_DimensionsFieldsTabbingAddtionalItemSteps: AddShipments
    {
        [Given(@"I am an operations, sales, sales management, or station owner user")]
        public void GivenIAmAnOperationsSalesSalesManagementOrStationOwnerUser()
        {
            string username = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
            string password = ConfigurationManager.AppSettings["password-crmOperation"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"I am a shp\.entry,shp\.inquiry user")]
        public void GivenIAmAShp_EntryShp_InquiryUser()
        {
            string username = ConfigurationManager.AppSettings["username-CurrentSprintshpentry"].ToString();
            string password = ConfigurationManager.AppSettings["password-CurrentSprintshpentry"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"I am on the Internal User LTL Add Shipment page")]
        public void GivenIAmOnTheInternalUserLTLAddShipmentPage()
        {
            Report.WriteLine("Navigate to Shipment List");
            GlobalVariables.webDriver.WaitForPageLoad();
            AddShipmentLTL ltl = new AddShipmentLTL();
            ltl.NaviagteToShipmentList();
            GlobalVariables.webDriver.WaitForPageLoad();

            Report.WriteLine("Navigate to Add Shipment Page");
            ltl.SelectCustomerFromShipmentList("Internal", "Dunkin Donuts");
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I clicked on the Add Additional Item button in the Freight Description section")]
        public void GivenIClickedOnTheAddAdditionalItemButtonInTheFreightDescriptionSection()
        {
            Report.WriteLine("I clicked on the Add Additional Item button in the Freight Description section");
            MoveToElement(attributeName_xpath, FreightDesp_First_AdditionalItem_Button_xpath);
            Click(attributeName_xpath, FreightDesp_First_AdditionalItem_Button_xpath);
        }
        
        [Given(@"I clicked in the Length field of the additional item in the Freight Description section")]
        public void GivenIClickedInTheLengthFieldOfTheAdditionalItemInTheFreightDescriptionSection()
        {
            Report.WriteLine("Click on Length field of First Additional Item");
            Click(attributeName_id, FreightDesp_First_AdditionalItem_Length_Id);
        }
        
        [Then(@"I will arrive in the Width field of the additional item in the Freight Description section")]
        public void ThenIWillArriveInTheWidthFieldOfTheAdditionalItemInTheFreightDescriptionSection()
        {
            IWebElement activeFromElement = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            string activeElementId = activeFromElement.GetAttribute("id");

            Report.WriteLine("Verifying Weight field element is active");
            Assert.AreEqual(FreightDesp_First_AdditionalItem_Width_Id, activeElementId);
        }

        [Given(@"I clicked in the Width field of the additional item in the Freight Description section")]
        public void GivenIClickedInTheWidthFieldOfTheAdditionalItemInTheFreightDescriptionSection()
        {
            Report.WriteLine("Click on Width field of First Additional Item");
            Click(attributeName_id, FreightDesp_First_AdditionalItem_Width_Id);
        }

        [Then(@"I will arrive in the Height field of the additional item in the Freight Description section")]
        public void ThenIWillArriveInTheHeightFieldOfTheAdditionalItemInTheFreightDescriptionSection()
        {
            IWebElement activeFromElement = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            string activeElementId = activeFromElement.GetAttribute("id");

            Report.WriteLine("Verifying Height field element is active");
            Assert.AreEqual(FreightDesp_First_AdditionalItem_Height_Id, activeElementId);
        }

        [Given(@"I clicked in the Height field of the additional item in the Freight Description section")]
        public void GivenIClickedInTheHeightFieldOfTheAdditionalItemInTheFreightDescriptionSection()
        {
            Report.WriteLine("Click on Height field of First Additional Item");
            Click(attributeName_id, FreightDesp_First_AdditionalItem_Height_Id);
        }

        [Then(@"I will arrive in the Weight field of the additional item in the Freight Description section")]
        public void ThenIWillArriveInTheWeightFieldOfTheAdditionalItemInTheFreightDescriptionSection()
        {
            IWebElement activeFromElement = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            string activeElementId = activeFromElement.GetAttribute("id");

            Report.WriteLine("Verifying Weight field element is active");
            Assert.AreEqual(FreightDesp_First_AdditionalItem_Weight_Id, activeElementId);
        }

        [Then(@"I will arrive in the Length field of the additional item in the Freight Description section")]
        public void ThenIWillArriveInTheLengthFieldOfTheAdditionalItemInTheFreightDescriptionSection()
        {
            IWebElement activeFromElement = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            string activeElementId = activeFromElement.GetAttribute("id");

            Report.WriteLine("Verifying Length field element is active");
            Assert.AreEqual(FreightDesp_First_AdditionalItem_Length_Id, activeElementId);
        }

        [When(@"there is value in Length field")]
        public void WhenThereIsValueInLengthField()
        {
            Report.WriteLine("Enter value in length field");
            SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_Length_Id, "10");
        }

        [When(@"I arrive on Length field by hitting Shift Tab from Width")]
        public void WhenIArriveOnLengthFieldByHittingShiftTabFromWidth()
        {
            Report.WriteLine("Click on width field of first additional item");
            Click(attributeName_id, FreightDesp_First_AdditionalItem_Width_Id);

            Report.WriteLine("Hit Shift + Tab");
            IWebElement activeFromElement = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            activeFromElement.SendKeys(Keys.Shift + Keys.Tab);

            Report.WriteLine("Arrive on length field of first additional item");
        }

        [Then(@"the value in the Length field of additional items will be highlighted")]
        public void ThenTheValueInTheLengthFieldOfAdditionalItemsWillBeHighlighted()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            object selectedTextInBrowser = ((IJavaScriptExecutor)GlobalVariables.webDriver).ExecuteScript("return window.getSelection().toString()");
            string lengthValue = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_Length_Id, "value");

            Report.WriteLine("Verifying the length value is highlighted in first additional item");
            Assert.AreEqual(lengthValue, selectedTextInBrowser.ToString());
        }               

        [When(@"there is a value in Width field")]
        public void WhenThereIsAValueInWidthField()
        {
            Report.WriteLine("Enter value in width field");
            SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_Width_Id, "10");
        }

        [When(@"I arrive on Width field by hitting Tab from Length")]
        public void WhenIArriveOnWidthFieldByHittingTabFromLength()
        {
            Report.WriteLine("Click on length field of first additional item");
            Click(attributeName_id, FreightDesp_First_AdditionalItem_Length_Id);

            Report.WriteLine("Hit Tab");
            IWebElement activeFromElement = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            activeFromElement.SendKeys(Keys.Tab);

            Report.WriteLine("Arrive on width field");
        }

        [Then(@"the value in the Width field of add additional item will be highlighted")]
        public void ThenTheValueInTheWidthFieldOfAddAdditionalItemWillBeHighlighted()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            object selectedTextInBrowser = ((IJavaScriptExecutor)GlobalVariables.webDriver).ExecuteScript("return window.getSelection().toString()");
            string widthValue = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_Width_Id, "value");

            Report.WriteLine("Verifying the width value is highlighted for first additional item");
            Assert.AreEqual(widthValue, selectedTextInBrowser.ToString());
        }        

        [When(@"I arrive on the Width field by hitting Shift Tab from Height")]
        public void WhenIArriveOnTheWidthFieldByHittingShiftTabFromHeight()
        {
            Report.WriteLine("Click on height field of first additional item");
            Click(attributeName_id, FreightDesp_First_AdditionalItem_Height_Id);

            Report.WriteLine("Hit Shift + Tab");
            IWebElement activeFromElement = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            activeFromElement.SendKeys(Keys.Shift + Keys.Tab);

            Report.WriteLine("Arrive on width field of first additional item");
        }

        [When(@"there is a value in the Height field")]
        public void WhenThereIsAValueInTheHeightField()
        {
            Report.WriteLine("Enter value in Height field");
            SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_Height_Id, "10");
        }

        [When(@"I arrive at the Height field by hitting Tab from Width")]
        public void WhenIArriveAtTheHeightFieldByHittingTabFromWidth()
        {
            Report.WriteLine("Click on width field");
            Click(attributeName_id, FreightDesp_First_AdditionalItem_Width_Id);

            Report.WriteLine("Hit Tab");
            IWebElement activeFromElement = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            activeFromElement.SendKeys(Keys.Tab);

            Report.WriteLine("Arrive on height field");
        }

        [Then(@"the value in the Height field of add additional item will be highlighted")]
        public void ThenTheValueInTheHeightFieldOfAddAdditionalItemWillBeHighlighted()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            object selectedTextInBrowser = ((IJavaScriptExecutor)GlobalVariables.webDriver).ExecuteScript("return window.getSelection().toString()");
            string heightValue = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_Height_Id, "value");

            Report.WriteLine("Verification that the height value is highlighted");
            Assert.AreEqual(heightValue, selectedTextInBrowser.ToString());
        }

        [Given(@"there is a value in the Length field")]
        public void GivenThereIsAValueInTheLengthField()
        {
            Report.WriteLine("Enter value in length field");
            SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_Length_Id, "10");
        }

        [Given(@"I arrive at the Length field by hitting Shift Tab from Width")]
        public void GivenIArriveAtTheLengthFieldByHittingShiftTabFromWidth()
        {
            Report.WriteLine("Click on width field of first additional item");
            Click(attributeName_id, FreightDesp_First_AdditionalItem_Width_Id);

            Report.WriteLine("Hit Shift + Tab");
            IWebElement activeFromElement = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            activeFromElement.SendKeys(Keys.Shift + Keys.Tab);

            Report.WriteLine("Arrive on length field of first additional item");
        }

        [Given(@"there is a value in the Width field")]
        public void GivenThereIsAValueInTheWidthField()
        {
            Report.WriteLine("Enter value in Width field");
            SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_Width_Id, "10");
        }

        [Given(@"I arrive at the Width field by hitting Tab from Length")]
        public void GivenIArriveAtTheWidthFieldByHittingTabFromLength()
        {
            Report.WriteLine("Click on length field of first additional item");
            Click(attributeName_id, FreightDesp_First_AdditionalItem_Length_Id);

            Report.WriteLine("Hit Tab");
            IWebElement activeFromElement = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            activeFromElement.SendKeys(Keys.Tab);

            Report.WriteLine("Arrive on width field");
        }

        [Given(@"I arrive at the Width field by hitting Shift Tab from Height")]
        public void GivenIArriveAtTheWidthFieldByHittingShiftTabFromHeight()
        {
            Report.WriteLine("Click on height field of first additional item");
            Click(attributeName_id, FreightDesp_First_AdditionalItem_Height_Id);

            Report.WriteLine("Hit Shift + Tab");
            IWebElement activeFromElement = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            activeFromElement.SendKeys(Keys.Shift + Keys.Tab);

            Report.WriteLine("Arrive on width field of first additional item");
        }

        [Given(@"there is a value in the Height field")]
        public void GivenThereIsAValueInTheHeightField()
        {
            Report.WriteLine("Enter value in Height field");
            SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_Height_Id, "10");
        }

        [Given(@"I arrive at the Height field by hitting Tab from Width")]
        public void GivenIArriveAtTheHeightFieldByHittingTabFromWidth()
        {
            Report.WriteLine("Click on width field");
            Click(attributeName_id, FreightDesp_First_AdditionalItem_Width_Id);

            Report.WriteLine("Hit Tab");
            IWebElement activeFromElement = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            activeFromElement.SendKeys(Keys.Tab);

            Report.WriteLine("Arrive on height field");
        }

        [When(@"I enter any value in the Length field of Additional Item  (.*)")]
        public void WhenIEnterAnyValueInTheLengthFieldOfAdditionalItem(string dimensionValueNew)
        {
            Report.WriteLine("Enter new value in length field");
            SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_Length_Id, dimensionValueNew);
        }

        [When(@"I enter any value in the Width fieldof Additional Item (.*)")]
        public void WhenIEnterAnyValueInTheWidthFieldofAdditionalItem(string dimensionValueNew)
        {
            Report.WriteLine("Enter new value in Width field");
            SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_Width_Id, dimensionValueNew);
        }

        [When(@"I enter any value in the Height fieldof Additional Item (.*)")]
        public void WhenIEnterAnyValueInTheHeightFieldofAdditionalItem(string dimensionValueNew)
        {
            Report.WriteLine("Enter new value in Height field");
            SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_Height_Id, dimensionValueNew);
        }


        [Then(@"the previous value in the Length of Additional Item will be over-written (.*)")]
        public void ThenThePreviousValueInTheLengthOfAdditionalItemWillBeOver_Written(string dimensionValueNew)
        {
            string lengthValue = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_Length_Id, "value");

            Report.WriteLine("Verification that the length value is over-written with " + dimensionValueNew);
            Assert.AreEqual(dimensionValueNew, lengthValue);
        }

        [Then(@"the previous value in the Width of Additional Item  will be over-written (.*)")]
        public void ThenThePreviousValueInTheWidthOfAdditionalItemWillBeOver_Written(string dimensionValueNew)
        {
            string widthValue = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_Width_Id, "value");

            Report.WriteLine("Verification that the width value is over-written with " + dimensionValueNew);
            Assert.AreEqual(dimensionValueNew, widthValue);
        }

        [Then(@"the previous value in the Height of Additional Item  will be over-written (.*)")]
        public void ThenThePreviousValueInTheHeightOfAdditionalItemWillBeOver_Written(string dimensionValueNew)
        {
            string heightValue = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_Height_Id, "value");

            Report.WriteLine("Verification that the height value is over-written with " + dimensionValueNew);
            Assert.AreEqual(dimensionValueNew, heightValue);
        }

        [Then(@"the value in the Length of Additional Item will be removed")]
        public void ThenTheValueInTheLengthOfAdditionalItemWillBeRemoved()
        {
            string lengthValue = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_Length_Id, "value")?.Trim();

            Report.WriteLine("Verification that the length value removed");
            Assert.AreEqual(string.Empty, lengthValue);
        }

        [Then(@"the value in the Width of Additional Item will be removed")]
        public void ThenTheValueInTheWidthOfAdditionalItemWillBeRemoved()
        {
            string widthValue = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_Width_Id, "value")?.Trim();

            Report.WriteLine("Verification that the width value removed");
            Assert.AreEqual(string.Empty, widthValue);
        }

        [Then(@"the value in the Height of Additional Item will be removed")]
        public void ThenTheValueInTheHeightOfAdditionalItemWillBeRemoved()
        {
            string heightValue = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_Height_Id, "value")?.Trim();

            Report.WriteLine("Verification that the height value removed");
            Assert.AreEqual(string.Empty, heightValue);
        }

    }
}
