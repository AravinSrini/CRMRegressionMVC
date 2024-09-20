using System;
using System.Collections.Generic;
using System.Threading;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Information_Screen
{
    [Binding]
    public class AddShipmentLTLMVC5_SelectClassOrSavedItemSearch_AllUsersSteps : AddShipments
    {
        [Then(@"the class or saved items that match the values will be highlighted in the class for the searchedvalue '(.*)'")]
        public void ThenTheClassOrSavedItemsThatMatchTheValuesWillBeHighlightedInTheClassForTheSearchedvalue(string searchedval)
        {
            scrollElementIntoView(attributeName_xpath, FreightDesp_SectionText_xpath);
            Report.WriteLine("Entering the value in classification searchbox");
            Click(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id);
            SendKeys(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id, searchedval);
            Report.WriteLine("Entered class or saved item should be highlighted");
            //verifying the underline for the search value with the xpath contains the strong tag            
            WaitForElementVisible(attributeName_xpath, ".//*[@id='scrollable-dropdown-menu-Origin']//p/strong", searchedval);
            Report.WriteLine("Taking the UI count of matched search criteria");
            IList<IWebElement> SearchedDropdownValues_UI = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='scrollable-dropdown-menu-Origin']//p/strong"));
            int expcount = 4;
            Assert.AreEqual(SearchedDropdownValues_UI.Count, expcount);
            Report.WriteLine("Seached values are highlighted successfully");
        }

        [Then(@"the class or saved items that match the values will be highlighted in the class of additional item for the searchedvalue '(.*)'")]
        public void ThenTheClassOrSavedItemsThatMatchTheValuesWillBeHighlightedInTheClassOfAdditionalItemForTheSearchedvalue(string searchedval)
        {
            Report.WriteLine("Entering value in Classification seach field");
            Click(attributeName_id, FreightDesp_First_AdditionalItem_SavedClassItem_DropDown_Id);
            SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_SavedClassItem_DropDown_Id, searchedval);
            Report.WriteLine("Entered class or saved item of additional item should be highlighted");
            //verifying the underline for the search value with the xpath contains the strong tag
            WaitForElementVisible(attributeName_xpath, ".//*[@id='scrollable-dropdown-menu-Origin']//p/strong", searchedval);
            Report.WriteLine("Taking UI count of matched search criteria");
            IList<IWebElement> SearchedDropdownValues_UI = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='scrollable-dropdown-menu-Origin']//p/strong"));
            int expcount = 4;
            Assert.AreEqual(SearchedDropdownValues_UI.Count, expcount);
            Report.WriteLine("Seached values are highlighted successfully");
        }

    }
}
