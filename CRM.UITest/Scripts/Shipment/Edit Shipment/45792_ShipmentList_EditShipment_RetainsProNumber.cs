using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Edit_Shipment
{
    [Binding]
    public sealed class _45792_ShipmentList_EditShipment_RetainsProNumber : AddShipments
    {
        string customerName = "ZZZ - Czar Customer Test";

        [Given(@"I click on the Edit button of a shipment that contains a pro number")]
        public void GivenIClickOnTheEditButtonOfAShipment()
        {
            Click(attributeName_xpath, ShipmentList_CustomerOrStationDropdown_Xpath);
            Thread.Sleep(2000);
            IList<IWebElement> CustomerDropdown_List = GlobalVariables.webDriver.FindElements(By.XPath(CustomerDropdownValesExtuser_Xpath));
            int CustomerNameListCount = CustomerDropdown_List.Count;
            for (int i = 0; i < CustomerNameListCount; i++)
            {
                if (CustomerDropdown_List[i].Text == customerName)
                {
                    CustomerDropdown_List[i].Click();
                    break;
                }
            }
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_id, "searchbox", "ZZX002015260");
            Thread.Sleep(5000);
            Click(attributeName_xpath, ".//*[@id='ShipmentGrid']/tbody/tr/td[10]/button");
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Then(@"the pro number field will be filled")]
        public void ThenTheProNumberFieldWillBeFilled()
        {
            string proNumberField = GetValue(attributeName_id, ReferenceNumbers_PRONumber_Id, "value");

            Assert.AreNotEqual("", proNumberField);
        }

    }
}
