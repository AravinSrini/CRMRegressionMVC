using CRM.UITest.Objects;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Information_Screen
{
    [Binding]
    public class AddShipmentLTL_MVC5_RemoveItemButton_AllUsersSteps:AddShipments
    {
        [Given(@"I have selected Customer from the dropdown (.*)")]
        public void GivenIHaveSelectedCustomerFromTheDropdown(string Customer_Name)
        {
            Report.WriteLine("Select Customer Name from the dropdown list");
            Click(attributeName_xpath, ShipmentList_CustomerSelection_Xpath);

            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_Customer_dropdownValue_Xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == Customer_Name)
                {
                    DropDownList[i].Click();
                    break;
                }
            }
            Thread.Sleep(5000);
        }
        
        [Given(@"I click Add shipment button")]
        public void GivenIClickAddShipmentButton()
        {
            Report.WriteLine("Click on Add shipment button");
            Click(attributeName_id, ShipmentList_AddShipmentButton_Id);
        }

        [Given(@"I clicked on Add Shipment button for internalusers")]
        public void GivenIClickedOnAddShipmentButtonForInternalusers()
        {
            Report.WriteLine("Click on Add Shipment button Internal users");
            Click(attributeName_id, AddShipmentButtionInternal_Id);
        }

        [Given(@"I have clicked on LTL tile of shipment process")]
        public void GivenIHaveClickedOnLTLTileOfShipmentProcess()
        {
            Report.WriteLine("Click on LTL tile");
            Click(attributeName_id, ShipmentServiceTypeLTL_id);
        }
        
        [When(@"I am taken to Add Shipment LTL page")]
        public void WhenIAmTakenToAddShipmentLTLPage()
        {
            Report.WriteLine("Navigated to Add shipment (LTL) page)");
            VerifyElementVisible(attributeName_xpath, AddShipment_PageTitle_xpath, "Add Shipment (LTL)");
        }
        
        [When(@"I click on Add Additional Item button")]
        public void WhenIClickOnAddAdditionalItemButton()
        {
            Report.WriteLine("Click on Add Additional Item button");
            scrollElementIntoView(attributeName_xpath, FreightDesp_First_AdditionalItem_Button_xpath);
            Click(attributeName_xpath, FreightDesp_First_AdditionalItem_Button_xpath);
            VerifyElementVisible(attributeName_xpath, FreightDesp_First_AdditionalItem_Quantity_xpath, "Quantity");
            SendKeys(attributeName_xpath, FreightDesp_First_AdditionalItem_Quantity_xpath, "5");
        }
        
        [When(@"I click on Remove Item button")]
        public void WhenIClickOnRemoveItemButton()
        {
            Report.WriteLine("Click on Remove Item button");
            Click(attributeName_xpath, FreightDesp_First_Remove_Button_xpath);
            Thread.Sleep(2000);
        }
        
        [Then(@"I should not be displayed with additional item added")]
        public void ThenIShouldNotBeDisplayedWithAdditionalItemAdded()
        {
            Report.WriteLine("I should not be displayed with added additional item");
            VerifyElementNotPresent(attributeName_xpath, FreightDesp_First_AdditionalItem_Quantity_xpath, "Quantity");
        }
        
        [Then(@"I should not be displayed with Remove Item button")]
        public void ThenIShouldNotBeDisplayedWithRemoveItemButton()
        {
            Report.WriteLine("I should not be displayed with Remove Item button");
            VerifyElementNotPresent(attributeName_xpath, FreightDesp_First_Remove_Button_xpath, "Remove");
        }
    }
}
