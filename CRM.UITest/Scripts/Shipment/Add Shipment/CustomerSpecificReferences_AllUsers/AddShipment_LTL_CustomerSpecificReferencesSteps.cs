using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

using CRM.UITest.Entities;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using CRM.UITest.CommonMethods;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.CustomerSpecificReferences_AllUsers
{
    [Binding]
    public class AddShipment_LTL_CustomerSpecificReferencesSteps : AddShipments
    {
        [When(@"I click on addshipment button")]
        public void WhenIClickOnAddshipmentButton()
        {
            Report.WriteLine("click on addshipment button");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ShipmentList_AddShipmentButton_Id);
        }


        [Then(@"I can see the Customer Specific References Move Type and Inventory Location Type drop downs")]
        public void ThenICanSeeTheCustomerSpecificReferencesMoveTypeAndInventoryLocationTypeDropDowns()
        {

            VerifyElementPresent(attributeName_xpath, ReferenceNumbers_MoveType_DropDown_xpath,"Move Type");
            VerifyElementPresent(attributeName_xpath, ReferenceNumbers_InventoryLocationType_DropDown_xpath, "Inventory Location Type");

        }




        [Then(@"Customer specific references Move Type and Inventory Location Types are the required fields")]
        public void ThenCustomerSpecificReferencesMoveTypeAndInventoryLocationTypesAreTheRequiredFields()
        {
            var colorofHighlighted_MoveType_value = GetCSSValue(attributeName_xpath, ReferenceNumbers_MoveType_DropDown_xpath, "border-color");
            //Assert.AreEqual("rgb(255, 184, 69)", colorofHighlighted_MoveType_value);

            var colorofHighlighted_InvLocationType_value = GetCSSValue(attributeName_xpath, ReferenceNumbers_InventoryLocationType_DropDown_xpath, "border-color");
            //Assert.AreEqual("rgb(255, 184, 69)", colorofHighlighted_InvLocationType_value);


        }


        [When(@"I click on the Move Type drop down")]
        public void WhenIClickOnTheMoveTypeDropDown()
        {
            Click(attributeName_xpath, ReferenceNumbers_MoveType_DropDown_xpath);
        }

        [Then(@"I can the see the drop down options of Move Type")]
        public void ThenICanTheSeeTheDropDownOptionsOfMoveType()
        {
            string WTvalues = "Enter move type...,Cust,Non-Cust";
            string[] values = WTvalues.Split(',');

            IList<IWebElement> UIValues = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='MoveType_chosen']/div/ul/li"));
            List<string> ExpectedVal = new List<string>();

            foreach (var v in values)
            {

                ExpectedVal.Add(v);
            }
            Assert.AreEqual(ExpectedVal.Count, UIValues.Count);
            for (int i = 0; i < UIValues.Count; i++)
            {
                if (ExpectedVal.Contains(UIValues[i].Text))
                {
                    Report.WriteLine("Option" + UIValues[i].Text + " is displaying under view dropdown");
                }
                else
                {
                    Report.WriteLine("Option" + UIValues[i].Text + " displaying under view dropdown is not expected");
                    Assert.IsTrue(false);
                }
            }
        }


        [Then(@"I click on the Inventory Type drop down")]
        public void ThenIClickOnTheInventoryTypeDropDown()
        {
            Click(attributeName_xpath, ReferenceNumbers_InventoryLocationType_DropDown_xpath);
        }


        [Then(@"I can see the drop down options of Inventory Location Type")]
        public void ThenICanSeeTheDropDownOptionsOfInventoryLocationType()
        {
            string WTvalues = "Enter inventory location type...,01 – Downing,02 – Black Creek,03 – Fort Atkinson,04 – Salem,05 – Bridgeport,06 – Hendricks,07 – Sikeston,08 – De Soto,10 – Lake Mills,81 – Web,82 – eBay,83 – Amazon,R04 – Salem Rebuild,R09 – Lake Mills Rebuild,Distribution Center,Warranty";
            string[] values = WTvalues.Split(',');

            IList<IWebElement> UIValues = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='InvLocType_chosen']/div/ul/li"));
            List<string> ExpectedVal = new List<string>();

            foreach (var v in values)
            {

                ExpectedVal.Add(v);
            }
            Assert.AreEqual(ExpectedVal.Count, UIValues.Count);
            for (int i = 0; i < UIValues.Count; i++)
            {
                if (ExpectedVal.Contains(UIValues[i].Text))
                {
                    Report.WriteLine("Option" + UIValues[i].Text + " is displaying under view dropdown");
                }
                else
                {
                    Report.WriteLine("Option" + UIValues[i].Text + " displaying under view dropdown is not expected");
                    Assert.IsTrue(false);
                }
            }
        }


        [Then(@"I can see not the Customer Specific References Move Type and Inventory Location Type drop downs")]
        public void ThenICanSeeNotTheCustomerSpecificReferencesMoveTypeAndInventoryLocationTypeDropDowns()
        {
            VerifyElementNotVisible(attributeName_xpath, ReferenceNumbers_MoveType_DropDown_xpath,"Move Type");
            VerifyElementNotVisible(attributeName_xpath, ReferenceNumbers_InventoryLocationType_DropDown_xpath, "Inventory Location Type");
        }








    }
}
