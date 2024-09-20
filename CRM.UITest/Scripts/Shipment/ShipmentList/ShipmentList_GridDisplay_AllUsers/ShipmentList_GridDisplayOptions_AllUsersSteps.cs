using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using TechTalk.SpecFlow;
using CRM.UITest.Objects;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Collections.Generic;

namespace CRM.UITest.Scripts.Shipment.ShipmentList.ShipmentList_GridDisplay
{
    [Binding]
    public class ShipmentList_GridDisplayOptions_AllUsersSteps : Shipmentlist
    {
        [When(@"I click on view dropdown present in top grid of shipment list page")]
        public void WhenIClickOnViewDropdownPresentInTopGridOfShipmentListPage()
        {
            Report.WriteLine("Clicking on view dropdown");
            Click(attributeName_xpath, ShipmentList_TopGrid_ViewDropdown_Xpath);           
        }
        
        [When(@"I click on view dropdown present in bottom grid of shipment list page")]
        public void WhenIClickOnViewDropdownPresentInBottomGridOfShipmentListPage()
        {
            Report.WriteLine("Clicking on view dropdown");
            scrollElementIntoView(attributeName_xpath, ShipmentList_BottomGrid_ViewDropdown_Xpath);
            Click(attributeName_xpath, ShipmentList_BottomGrid_ViewDropdown_Xpath);
        }
        
        [When(@"I click on right navigation icon in top grid of shipment list page")]
        public void WhenIClickOnRightNavigationIconInTopGridOfShipmentListPage()
        {
            string totalrecords = Gettext(attributeName_xpath, ShipmentList_TopGrid_DisplayListView_Xpath);
            string displaycount = totalrecords.Substring(totalrecords.LastIndexOf("OF") + 2);
            int DC = Convert.ToInt32(displaycount);
            if (DC > 10)
            {
                Report.WriteLine("Clicking on next icon");
                Click(attributeName_xpath, ShipmentList_TopGrid_RightNavigationIcon_Xpath);
            }
            else
            {
                Report.WriteLine("Unable to click on next icon as number of records are less than 10");
            }
        }
        
        [When(@"I click on right navigation icon in bottom grid of shipment list page")]
        public void WhenIClickOnRightNavigationIconInBottomGridOfShipmentListPage()
        {
            string totalrecords = Gettext(attributeName_xpath, ShipmentList_BottomGrid_DisplayListView_Xpath);
            string displaycount = totalrecords.Substring(totalrecords.LastIndexOf("OF") + 2);
            int DC = Convert.ToInt32(displaycount);
            if (DC > 10)
            {
                Report.WriteLine("Clicking on next icon");
                Click(attributeName_xpath, ShipmentList_BottomGrid_RightNavigationIcon_Xpath);
            }
            else
            {
                Report.WriteLine("Unable to click on next icon as number of records are less than 10");
            }
        }
        
        [When(@"I click on left navigation icon in top grid of shipment list page")]
        public void WhenIClickOnLeftNavigationIconInTopGridOfShipmentListPage()
        {
            string totalrecords = Gettext(attributeName_xpath, ShipmentList_TopGrid_DisplayListView_Xpath);
            string displaycount = totalrecords.Substring(totalrecords.LastIndexOf("OF") + 2);
            int DC = Convert.ToInt32(displaycount);
            if (DC > 10)
            {
                Report.WriteLine("Clicking on previous or left navigation icon");
                Click(attributeName_xpath, ShipmentList_TopGrid_LeftNavigationIcon_Xpath);
            }
            else
            {
                Report.WriteLine("Unable to click on next icon as number of records are less than 10");
            }
        }
        
        [When(@"I click on left navigation icon in bottom grid of shipment list page")]
        public void WhenIClickOnLeftNavigationIconInBottomGridOfShipmentListPage()
        {
            string totalrecords = Gettext(attributeName_xpath, ShipmentList_BottomGrid_DisplayListView_Xpath);
            string displaycount = totalrecords.Substring(totalrecords.LastIndexOf("OF") + 2);
            int DC = Convert.ToInt32(displaycount);
            if (DC > 10)
            {
                Report.WriteLine("Clicking on previous or left navigation icon");
                Click(attributeName_xpath, ShipmentList_BottomGrid_LeftNavigationIcon_Xpath);
            }
            else
            {
                Report.WriteLine("Unable to click on next icon as number of records are less than 10");
            }
        }
        
        [When(@"I select any (.*) from view dropdown present in bottom grid of shipment list page")]
        public void WhenISelectAnyFromViewDropdownPresentInBottomGridOfShipmentListPage(string option)
        {
            Report.WriteLine("Select option from view dropdown");
            SelectDropdownlistvalue(attributeName_xpath, ShipmentList_BottomGrid_ViewDropdownValues_Xpath, option);
        }

        [Then(@"only ten records should be displayed by default in shipment list page")]
        public void ThenOnlyTenRecordsShouldBeDisplayedByDefaultInShipmentListPage()
        {
            Report.WriteLine("Verifying the default records on the page load");
            IJavaScriptExecutor executor = (IJavaScriptExecutor)GlobalVariables.webDriver;
            var defaultOption = executor.ExecuteScript("return $('#ShipmentGrid_length :selected').val()");
            Assert.AreEqual("10", defaultOption);
            Report.WriteLine("Default 10 option is selected in the dropdown");
        }

        [Then(@"I should be able to view (.*) under dropdown in top grid of shipment list page")]
        public void ThenIShouldBeAbleToViewUnderDropdownInTopGridOfShipmentListPage(string options)
        {
            Report.WriteLine("Verifying the options present under view dropdown");
            string[] values = options.Split(',');
            IList<IWebElement> UIValues = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_TopGrid_ViewDropdownValues_Xpath));
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
        
        [Then(@"I should be able to view (.*) under dropdown in bottom grid of shipment list page")]
        public void ThenIShouldBeAbleToViewUnderDropdownInBottomGridOfShipmentListPage(string options)
        {
            Report.WriteLine("Verifying the options present under view dropdown");
            string[] values = options.Split(',');
            IList<IWebElement> UIValues = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_BottomGrid_ViewDropdownValues_Xpath));
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
        
        [Then(@"Next set of records should be displayed in shipment list page")]
        public void ThenNextSetOfRecordsShouldBeDisplayedInShipmentListPage()
        {
            string totalrecords = Gettext(attributeName_xpath, ShipmentList_TopGrid_DisplayListView_Xpath);
            string displaycount = totalrecords.Substring(totalrecords.LastIndexOf("OF") + 2);
            int DC = Convert.ToInt32(displaycount);
            if (DC > 10)
            {
                int toindex = totalrecords.IndexOf("-") + "- ".Length;
                int ofindex = totalrecords.LastIndexOf("OF");

                string selecteValue = totalrecords.Substring(toindex, ofindex - toindex);
                Assert.AreEqual(selecteValue.Trim(), "20");
            }
            else
            {
                Report.WriteLine("Unable to click on next icon as number of records are less than 10");
            }
        }

        [Then(@"left navigation icon should be enabled in top grid of the shipment list page")]
        public void ThenLeftNavigationIconShouldBeEnabledInTopGridOfTheShipmentListPage()
        {
            string totalrecords = Gettext(attributeName_xpath, ShipmentList_TopGrid_DisplayListView_Xpath);
            string displaycount = totalrecords.Substring(totalrecords.LastIndexOf("OF") + 2);
            int DC = Convert.ToInt32(displaycount);
            if (DC > 10)
            {
                Report.WriteLine("Verifying the left navigation in shipment list page");
                VerifyElementPresent(attributeName_xpath, ShipmentList_TopGrid_LeftNavigationIcon_Xpath, "Left navigation icon");
            }
            else
            {
                Report.WriteLine("Unable to verify the left navigation icon functionality as number of records are less than 10");
            }

        }

        [Then(@"left navigation icon should be enabled icon in bottom grid of the shipment list page")]
        public void ThenLeftNavigationIconShouldBeEnabledIconInBottomGridOfTheShipmentListPage()
        {
            string totalrecords = Gettext(attributeName_xpath, ShipmentList_TopGrid_DisplayListView_Xpath);
            string displaycount = totalrecords.Substring(totalrecords.LastIndexOf("OF") + 2);
            int DC = Convert.ToInt32(displaycount);
            if (DC > 10)
            {
                Report.WriteLine("Verifying the left navigation in shipment list page");
                VerifyElementPresent(attributeName_xpath, ShipmentList_BottomGrid_LeftNavigationIcon_Xpath, "Left navigation icon");
            }
            else
            {
                Report.WriteLine("Unable to verify the left navigation icon functionality as number of records are less than 10");
            }
        }

        [Then(@"previous default records should be displayed in shipment list page")]
        public void ThenPreviousDefaultRecordsShouldBeDisplayedInShipmentListPage()
        {
            string totalrecords = Gettext(attributeName_xpath, ShipmentList_TopGrid_DisplayListView_Xpath);
            string displaycount = totalrecords.Substring(totalrecords.LastIndexOf("OF") + 2);
            int DC = Convert.ToInt32(displaycount);
            if (DC > 10)
            {
                int toindex = totalrecords.IndexOf("-") + "- ".Length;
                int ofindex = totalrecords.LastIndexOf("OF");

                string selecteValue = totalrecords.Substring(toindex, ofindex - toindex);
                Assert.AreEqual(selecteValue.Trim(), "10");
                Report.WriteLine("Initial set of records are displaying in page");
            }
            else
            {
                Report.WriteLine("Unable to verify the functionality of left navigation icon as number of records are less than 10");
            }
        }
        
        [Then(@"Selected (.*) records should be displayed in shipment list page")]
        public void ThenSelectedRecordsShouldBeDisplayedInShipmentListPage(string count)
        {
            string totalrecords = Gettext(attributeName_xpath, ShipmentList_TopGrid_DisplayListView_Xpath);
            string displaycount = totalrecords.Substring(totalrecords.LastIndexOf("OF") + 2);
            int DCount = Convert.ToInt32(displaycount);
            int UICount = Convert.ToInt32(count);

            if (DCount > UICount)
            {
                int rowCount = GetCount(attributeName_xpath, ShipmentList_NoOfRows_Xpath);
                Assert.AreEqual(rowCount, UICount);
            }
            else
            {
                Report.WriteLine("Selected view option" + count + " is more than total number of records" + DCount + " exists for the logged in user");
            }
        }
        
        [Then(@"text in top grid should match with selected (.*) in shipment list page")]
        public void ThenTextInTopGridShouldMatchWithSelectedInShipmentListPage(string count)
        {
            string totalrecords = Gettext(attributeName_xpath, ShipmentList_TopGrid_DisplayListView_Xpath);
            string displaycount = totalrecords.Substring(totalrecords.LastIndexOf("OF") + 2);
            int DCount = Convert.ToInt32(displaycount);
            int UICount = Convert.ToInt32(count);

            if (DCount > UICount)
            {
                int toindex = totalrecords.IndexOf("-") + "- ".Length;
                int ofindex = totalrecords.LastIndexOf("OF");

                string selecteValue = totalrecords.Substring(toindex, ofindex - toindex);
                Assert.AreEqual(selecteValue.Trim(), count);
            }
            else
            {
                Report.WriteLine("Unable to verify the text functionality");
                Report.WriteLine("Selected view option" + count + " is more than total number of records" + DCount + " exists for the logged in user");
            }
        }
        
        [Then(@"text in bottom grid should match with selected (.*) in shipment list page")]
        public void ThenTextInBottomGridShouldMatchWithSelectedInShipmentListPage(string count)
        {
            string totalrecords = Gettext(attributeName_xpath, ShipmentList_BottomGrid_DisplayListView_Xpath);
            string displaycount = totalrecords.Substring(totalrecords.LastIndexOf("OF") + 2);
            int DCount = Convert.ToInt32(displaycount);
            int UICount = Convert.ToInt32(count);

            if (DCount > UICount)
            {
                int toindex = totalrecords.IndexOf("-") + "- ".Length;
                int ofindex = totalrecords.LastIndexOf("OF");

                string selecteValue = totalrecords.Substring(toindex, ofindex - toindex);
                Assert.AreEqual(selecteValue.Trim(), count);
            }
            else
            {
                Report.WriteLine("Unable to verify the text functionality");
                Report.WriteLine("Selected view option" + count + " is more than total number of records" + DCount + " exists for the logged in user");
            }
        }
        
        [Then(@"right navigation icon should be disabled in top grid in shipment list page when number of records are less than view (.*)")]
        public void ThenRightNavigationIconShouldBeDisabledInTopGridInShipmentListPageWhenNumberOfRecordsAreLessThanView(string option)
        {
            string totalrecords = Gettext(attributeName_xpath, ShipmentList_TopGrid_DisplayListView_Xpath);
            string displaycount = totalrecords.Substring(totalrecords.LastIndexOf("OF") + 2);
            int DCount = Convert.ToInt32(displaycount);

            if (DCount < 10)
            {
                Report.WriteLine("Verifying the right navigation in shipment list page");
                bool value = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='ShipmentGrid_next'][@class='paginate_button next disabled']")).Displayed;
                Assert.AreEqual("True", value.ToString());
            }
            else
            {
                Report.WriteLine("Unable to right navigation functionality as number of records are more than 10");
            }
        }
        
        [Then(@"right navigation icon should be disabled in bottom grid in shipment list page when number of records are less than view (.*)")]
        public void ThenRightNavigationIconShouldBeDisabledInBottomGridInShipmentListPageWhenNumberOfRecordsAreLessThanView(string p0)
        {
            string totalrecords = Gettext(attributeName_xpath, ShipmentList_TopGrid_DisplayListView_Xpath);
            string displaycount = totalrecords.Substring(totalrecords.LastIndexOf("OF") + 2);
            int DCount = Convert.ToInt32(displaycount);

            if (DCount < 10)
            {
                Report.WriteLine("Verifying the right navigation in shipment list page");
                bool value = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='ShipmentGrid_wrapper']/div[2]/div/div[2]/div[2]/ul/li[@class = 'paginate_button next disabled']")).Displayed;
                Assert.AreEqual("True", value.ToString());
            }
            else
            {
                Report.WriteLine("Unable to right navigation functionality as number of records are more than 10");
            }
        }
        
        [Then(@"left navigation icon should be disabled in top grid in shipment list page")]
        public void ThenLeftNavigationIconShouldBeDisabledInTopGridInShipmentListPage()
        {
            Report.WriteLine("Verifying the left navigation in shipment list page");
            bool value = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='ShipmentGrid_previous'][@class='paginate_button previous disabled']")).Displayed;
            Assert.AreEqual("True", value.ToString());
        }
        
        [Then(@"left navigation icon should be disabled in bottom grid in shipment list page")]
        public void ThenLeftNavigationIconShouldBeDisabledInBottomGridInShipmentListPage()
        {
            Report.WriteLine("Verifying the left navigation in shipment list page");
            bool value = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='ShipmentGrid_wrapper']/div[2]/div/div[2]/div[2]/ul/li[@class='paginate_button previous disabled']")).Displayed;
            Assert.AreEqual("True", value.ToString());
        }
        
        [Then(@"right navigation icon should be disabled in top grid in shipment list page")]
        public void ThenRightNavigationIconShouldBeDisabledInTopGridInShipmentListPage()
        {
            Report.WriteLine("Verifying the right navigation in shipment list page");
            bool value = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='ShipmentGrid_next'][@class='paginate_button next disabled']")).Displayed;
            Assert.AreEqual("True", value.ToString());
        }
        
        [Then(@"right navigation icon should be disabled in bottom grid in shipment list page")]
        public void ThenRightNavigationIconShouldBeDisabledInBottomGridInShipmentListPage()
        {
            Report.WriteLine("Verifying the right navigation in shipment list page");
            bool value = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='ShipmentGrid_wrapper']/div[2]/div/div[2]/div[2]/ul/li[@class = 'paginate_button next disabled']")).Displayed;
            Assert.AreEqual("True", value.ToString());
        }
    }
}
