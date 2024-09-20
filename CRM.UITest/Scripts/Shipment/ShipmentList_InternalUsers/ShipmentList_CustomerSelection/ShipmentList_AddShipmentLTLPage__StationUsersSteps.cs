using CRM.UITest.CommonMethods;
using CRM.UITest.CsaServiceReference;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.Common;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Xml.Linq;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.ShipmentList_InternalUsers.ShipmentList_CustomerSelection
{
    [Binding]
    public class ShipmentList_AddShipmentLTLPage__StationUsersSteps:AddShipments
    {
        [When(@"I select any tms type MG customer (.*) from the customer dropdown in shipment list")]
        public void WhenISelectAnyTmsTypeMGCustomerFromTheCustomerDropdownInShipmentList(string Account)
        {

            Report.WriteLine("Clicking on customer dropdown");
            Click(attributeName_xpath, ShipmentList_CustomerSelection_Xpath);
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_Customer_dropdownValue_Xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == Account)
                {
                    DropDownList[i].Click();
                    break;
                }
            }
        }
        
        [When(@"I select any tms type both customer (.*) from the customer dropdown in shipment list")]
        public void WhenISelectAnyTmsTypeBothCustomerFromTheCustomerDropdownInShipmentList(string Account)
        {
            Report.WriteLine("Clicking on customer dropdown");
            Click(attributeName_xpath, ShipmentList_CustomerSelection_Xpath);
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_Customer_dropdownValue_Xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == Account)
                {
                    DropDownList[i].Click();
                    break;
                }
            }
        }
        

        [When(@"I select any tms type csa customer (.*) from the customer dropdown in shipment list")]
        public void WhenISelectAnyTmsTypeCsaCustomerFromTheCustomerDropdownInShipmentList(string Account)
        {
            Report.WriteLine("Clicking on customer dropdown");
            Click(attributeName_xpath, ShipmentList_CustomerSelection_Xpath);
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_Customer_dropdownValue_Xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == Account)
                {
                    DropDownList[i].Click();
                    break;
                }
            }
        }
        
        [When(@"I click on the add Shipment Button")]
        public void WhenIClickOnTheAddShipmentButton()
        {
            Report.WriteLine("Clicking on TheAddShipmentButton");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, AddShipmentButtionInternal_Id);

        }

        [When(@"I click on LTL tile on the Add Shipment landing page")]
        public void WhenIClickOnLTLTileOnTheAddShipmentLandingPage()
        {
            Report.WriteLine("Clicking on TheAddShipmentButton");
            Click(attributeName_id, ShipmentList_LTLtile_Id);
        }
        
        [Then(@"I should be displayed with Add Shipment option")]
        public void ThenIShouldBeDisplayedWithAddShipmentOption()
        {
            Report.WriteLine("Clicking on TheAddShipmentButton");
            VerifyElementVisible(attributeName_id, AddShipmentButtionInternal_Id, "button");
        }
        
        [Then(@"I should not be displayed with Add Shipment option")]
        public void ThenIShouldNotBeDisplayedWithAddShipmentOption()
        {
            Report.WriteLine("DisplayedWithAddShipmentOption");
            VerifyElementNotVisible(attributeName_id, AddShipmentButtionInternal_Id, "addshipmentbutton");
        }
        
        [Then(@"I should be navigate to Add Shipment landing page")]
        public void ThenIShouldBeNavigateToAddShipmentLandingPage()
        {
            Report.WriteLine("NavigateToAddShipmentLandingPage");
            VerifyElementVisible(attributeName_xpath, Addshipment_pageheader_Xpath, "AddShipmentLandingPage");
            
        }
        
        [Then(@"I should be displayed with LTL tile")]
        public void ThenIShouldBeDisplayedWithLTLTile()
        {
            Report.WriteLine("DisplayedWithLTLTile");
            VerifyElementVisible(attributeName_id, ShipmentList_LTLtile_Id, "LTLtile");
        }
        
        [Then(@"I should navigate to Add Shipment \(LTL\) page")]
        public void ThenIShouldNavigateToAddShipmentLTLPage()
        {
            Report.WriteLine("NavigateToAddShipmentLandingPage");
            VerifyElementVisible(attributeName_xpath, Addshipment_pageheader_Xpath, "AddShipmentLandingPage");
        }
    }
}
