using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Quote.LTL.Shipment_Information_Screen.OverLength_GetQuote_LTL_
{
    [Binding]
    public class _40832_Over_Length___Get_Quote__LTL____Saved_Item_with_Dimensions_Steps : ObjectRepository
    {
        Item itemDB;
        string customerName = "ZZZ - Czar Customer Test";
        AddQuoteLTL quote = new AddQuoteLTL();

        [Then(@"the Length,Width,Height dimension fields will be blank")]
        public void ThenTheLengthWidthHeightDimensionFieldsWillBeBlank()
        {
            Report.WriteLine("the Length,Width,Height dimension fields will be blank");
            string length = GetAttribute(attributeName_id, LTL_Quote_Item_Length_Id, "value");
            string width = GetAttribute(attributeName_id, LTL_Quote_Item_Width_Id, "value");
            string height = GetAttribute(attributeName_id, LTL_Quote_Item_Height_Id, "value");

            Assert.AreEqual(length, string.Empty);
            Assert.AreEqual(width, string.Empty);
            Assert.AreEqual(height, string.Empty);
        }

        [Then(@"the dimension type will be defaulted to (.*)")]
        public void ThenTheDimensionTypeWillBeDefaultedTo(string dimensionType)
        {
            Report.WriteLine("the dimension type will be defaulted to IN");
            string expecteddefaultDimensionType = Regex.Replace(dimensionType, @"(\s+|&|'|\(|\)|<|>|#)", "");
            string defaultDimensionTypeUI = Gettext(attributeName_xpath, LTL_Quote_Item_DimensionType_dropdown_Xpath);
            Assert.AreEqual(expecteddefaultDimensionType, defaultDimensionTypeUI);
        }

        [Given(@"I have selected a saved item included dimension and dimension type(.*) values")]
        public void GivenIHaveSelectedASavedItemIncludedDimensionAndDimensionTypeValues(string dimensionType)
        {
            Report.WriteLine("I have selected a saved item included dimension and dimension type(.*) values");
            string DimensionType = Regex.Replace(dimensionType, @"(\s+|&|'|\(|\)|<|>|#)", "");
            Click(attributeName_id, LTL_ClearItem_Id);
            itemDB = DBHelper.GetItemDetailsBasedDimension(customerName, DimensionType);
            if (itemDB == null)
            {
                Report.WriteFailure("No record is available for for demensionType " + dimensionType);
            }
            else
            {
                Report.WriteLine("Entering a search criteria in item dropdown");
                string itemDescription = itemDB.Classification + " " + itemDB.ItemDescription;
                Click(attributeName_id, LTL_Classification_Id);
                // SendKeys(attributeName_id, LTL_Classification_Id,itemDiscription);
                //Click(attributeName_xpath, "//p[contains(text(),'itemDiscription')]");
                Thread.Sleep(5000);
                IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='scrollable-dropdown-menu-Origin']//span/div/p"));
                int DropDownCount = DropDownList.Count;
                for (int i = 0; i < DropDownCount; i++)
                {
                    if (DropDownList[i].Text.ToLower() == itemDescription.ToLower())
                    {
                        DropDownList[i].Click();
                        break;
                    }
                }
            }

        }

        [Given(@"the customer has a default item included dimensions and dimension type(.*) values")]
        public void GivenTheCustomerHasADefaultItemIncludedDimensionsAndDimensionTypeValues(string dimensionType)
        {
            Report.WriteLine("the customer has a default item included dimensions and dimension type(.*) values");
            string DimensionType = Regex.Replace(dimensionType, @"(\s+|&|'|\(|\)|<|>|#)", "");
            Click(attributeName_id, LTL_ClearItem_Id);
            itemDB = DBHelper.GetDefaultItemDetailsBasedDimension(customerName);
            Report.WriteLine("Entering a search criteria in item dropdown");
            //SendKeys(attributeName_xpath, LTL_SavedItemDropdown_SearchBox_Xpath, itemDB.ItemDescription);
        }


        [When(@"the dimension type of the saved item is (.*)")]
        public void WhenTheDimensionTypeOfTheSavedItemIs(string dimensionType)
        {
            Report.WriteLine("the dimension type of the saved item is IN/FT/Meter/CM");
            string DimensionType = Regex.Replace(dimensionType, @"(\s+|&|'|\(|\)|<|>|#)", "");
            if ( itemDB.DimensionUnit== DimensionType)
            {
                Report.WriteLine("Dimension Type is " + DimensionType);
            }
           else
            {
                Report.WriteLine("Dimension Type is not" + DimensionType);
            }
        }




        [Then(@"the Length,Width,Height,Dimension type dimension fields will get bind (.*)")]
        public void ThenTheLengthWidthHeightDimensionTypeDimensionFieldsWillGetBind(string dimensionType)
        {
            Report.WriteLine("the Length,Width,Height,Dimension type dimension fields will get bind");
            string DimensionType = Regex.Replace(dimensionType, @"(\s+|&|'|\(|\)|<|>|#)", "");

            if (itemDB.DimensionUnit == DimensionType)
            {
                string itemLengthUI = GetValue(attributeName_id, LTL_Quote_Item_Length_Id, "value");
                if (itemDB.Length != null && itemDB.Length>0)
                {
                    Assert.AreEqual(Convert.ToInt32(itemDB.Length).ToString(), itemLengthUI);
                }
                else 
                {
                    Assert.AreEqual(string.Empty, itemLengthUI);
                }

                string itemWidthUI = GetValue(attributeName_id, LTL_Quote_Item_Width_Id, "value");
                if (itemDB.Width != null && itemDB.Width > 0)
                {

                    Assert.AreEqual(Convert.ToInt32(itemDB.Width).ToString(), itemWidthUI);
                }
                else
                {
                    Assert.AreEqual(string.Empty, itemWidthUI);
                }

                string itemHeightUI = GetValue(attributeName_id, LTL_Quote_Item_Height_Id, "value");
                if (itemDB.Height != null && itemDB.Height > 0)
                {

                    Assert.AreEqual(Convert.ToInt32(itemDB.Height).ToString(), itemHeightUI);
                }
                else
                {
                    Assert.AreEqual(string.Empty, itemHeightUI);
                }
            }
            else
            {
                Report.WriteLine("the dimension type of the saved item is not"+ DimensionType);
            }
        }
    }
}
