using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.UAT_Regression.Domestic_Forwarding.Shipment
{
    [Binding]
    public class Regression_DomesticForwarding_AddShipment_SelectSavedItemSteps:Mvc4Objects
    { 
        CommonMethodsCrm crm = new CommonMethodsCrm();
        AddShipmentLTL ltl = new AddShipmentLTL();
    
        [Given(@"I am on the Add Shipment page for Domestic Forwarding")]
        public void GivenIAmOnTheAddShipmentPageForDomesticForwarding()
        {
            Report.WriteLine("I am on the Add Shipment page for Domestic Forwarding");
            ltl.NaviagteToShipmentList();
            Click(attributeName_id, AddShipmentButton_Id);
            Thread.Sleep(2000);
            Click(attributeName_id, DF_ShipTile_Id);
            Thread.Sleep(2000);
            Click(attributeName_xpath, DF_ShipTypeSelect_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, DF_ShipTypeSelectValue_Xpath, "Same Day");
            Click(attributeName_id, DF_ShipTypeContinue_Id);
            Verifytext(attributeName_xpath, DF_ShipPageTitle_Xpath, "Add Shipment");
        }

        [When(@"I select the saved item '(.*)' on addshipment page")]
        public void WhenISelectTheSavedItemOnAddshipmentPage(string ItemDesc)

        {
            Report.WriteLine("I Select The Saved Item On Add shipmentPage");
            scrollElementIntoView(attributeName_xpath, ShipDF_ItemDropdown_Xpath);
            Thread.Sleep(1000);
            Report.WriteLine("clicking on Class field");
            Click(attributeName_xpath, ShipDF_ItemDropdown_Xpath);
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='saved_item_select_chosen']/div/ul/li"));
            int DropDownCount = DropDownList.Count;
            Report.WriteLine("dropdown value Selecting in Class field");

            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == ItemDesc.ToUpper())
                {
                    DropDownList[i].Click();
                    break;
                }
            }
        }

        [Then(@"The following fields Pieces, Weight, Dimensions and Description must be populated with correct DB data '(.*)','(.*)'")]
        public void ThenTheFollowingFieldsPiecesWeightDimensionsAndDescriptionMustBePopulatedWithCorrectDBData(string itemDesc, string accName)
        {
            Report.WriteLine("Verifying the populated data with database");
            int setupId = DBHelper.GetAccountIdforAccountName(accName);
            int accId = DBHelper.GetAccountNumber(setupId);
            Item itemValue = DBHelper.GetItemDetails(accId, itemDesc);

            string actQuantity = GetAttribute(attributeName_id, DF_Pieces_Id, "value");
            Assert.AreEqual(itemValue.Quantity.ToString(), actQuantity);
            Report.WriteLine("Displaying quantity " + actQuantity + " is matching with expected value " + itemValue.Quantity);

            string actWeight = GetAttribute(attributeName_id, DF_Weight_Id, "value");
            Assert.AreEqual(itemValue.Weight.ToString(), actWeight);
            Report.WriteLine("Displaying weight " + actWeight + " is matching with expected value " + itemValue.Weight);

            string actLength = GetAttribute(attributeName_id, DF_DimensionLength_Id, "value");
            Assert.AreEqual(itemValue.Length.ToString(), actLength);
            Report.WriteLine("Displaying length " + actLength + " is matching with expected value " + itemValue.Length);

            string actWidth = GetAttribute(attributeName_id, DF_DimensionWidth_Id, "value");
            Assert.AreEqual(itemValue.Width.ToString(), actWidth);
            Report.WriteLine("Displaying width " + actWidth + " is matching with expected value " + itemValue.Width);

            string actHeight = GetAttribute(attributeName_id, DF_DimensionHeight_Id, "value");
            Assert.AreEqual(itemValue.Height.ToString(), actHeight);
            Report.WriteLine("Displaying height " + actHeight + " is matching with expected value " + itemValue.Height);

            string actDesc = GetAttribute(attributeName_id, DF_Description_Id, "value");
            Assert.AreEqual(itemValue.ItemDescription.ToUpper(), actDesc.ToUpper());
            Report.WriteLine("Displaying description " + actDesc + " is matching with expected value " + itemValue.ItemDescription);
        }
    }
}
