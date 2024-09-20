using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Results
{
    [Binding]
    public class ValidationOf_ShipmentValuein_ShipmentResultspageSteps : AddShipments
    {
        [Given(@"I select (.*) and (.*) depending on the Customer Specific references (.*)")]
        public void GivenISelectAndDependingOnTheCustomerSpecificReferences(string MoveType, string InventoryLocationType, string CustSpecRef)
        {
            if (CustSpecRef == "Yes")
            {
                Report.WriteLine("Selecting the Move Type Value");
                scrollpagedown();
                Click(attributeName_xpath, ReferenceNumbers_MoveType_DropDown_xpath);
                IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ReferenceNumbers_MoveType_DropDown_Values_xpath));
                int DropDownCount = DropDownList.Count;
                for (int i = 0; i < DropDownCount; i++)
                {
                    if (DropDownList[i].Text == MoveType)
                    {
                        DropDownList[i].Click();
                        break;
                    }
                }

                Report.WriteLine("Selecting the Move Type Value");
                Click(attributeName_xpath, ReferenceNumbers_InventoryLocationType_DropDown_xpath);
                IList<IWebElement> DropDownList1 = GlobalVariables.webDriver.FindElements(By.XPath(ReferenceNumbers_InventoryLocationType_DropDown_Values_xpath));
                int DropDownCount1 = DropDownList1.Count;
                for (int i = 0; i < DropDownCount; i++)
                {
                    if (DropDownList1[i].Text == InventoryLocationType)
                    {
                        DropDownList1[i].Click();
                        break;
                    }
                }



            }
            

        }


        [When(@"I enter the Shipment value in shipment results page (.*)")]
        public void WhenIEnterTheShipmentValueInShipmentResultsPage(string ShipmentValue)
        {
            SendKeys(attributeName_id, ShipResults_InsuredRateTextbox_Id, ShipmentValue);
        }



        [Then(@"Shipment value text box should be highlighted in red")]
        public void ThenShipmentValueTextBoxShouldBeHighlightedInRed()
        {
            Report.WriteLine("Highlighted with the pink color");
            var colorofHighlighted_ShipmentResults_ShipmentValueText_value = GetCSSValue(attributeName_id, ShipResults_InsuredRateTextbox_Id, "background-color");
            Assert.AreEqual("rgba(251, 236, 236, 1)", colorofHighlighted_ShipmentResults_ShipmentValueText_value);
        }


    }
}
