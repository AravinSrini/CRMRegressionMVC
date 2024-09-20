using System;
using System.Collections.Generic;
using System.Threading;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Information_Screen
{
    [Binding]
    public class AddShipmentLTLMVC5_FreightDescription_DisplayTextWaterMarkFieldsSteps : AddShipments
    {
        [When(@"I have selected saved item which contains nullorzero values '(.*)'")]
        public void WhenIHaveSelectedSavedItemWhichContainsNullorzeroValues(string saveditem)
        {
            Report.WriteLine("I select saved item then the saved item should auto-fill in the Select Class field");
            Thread.Sleep(1000);
            Report.WriteLine("clicking on Class field");
            scrollElementIntoView(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id);
            Click(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id);
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='scrollable-dropdown-menu-Origin']/div/span[1]/span/div/span/div/p"));
            int DropDownCount = DropDownList.Count;
            Report.WriteLine("dropdown value Selecting in Class field");
            try
            {
                for (int i = 0; i < DropDownCount; i++)
                {
                    if (DropDownList[i].Text == saveditem)
                    {
                        DropDownList[i].Click();
                        break;
                    }
                }
            }
            catch (Exception)
            {
              Console.WriteLine("dropdownclosed");
            }
            Thread.Sleep(500);
        }

        [When(@"I have selected saved item which contains nullorzero values '(.*)' additional item section")]
        public void WhenIHaveSelectedSavedItemWhichContainsNullorzeroValuesAdditionalItemSection(string saveditem)
        {
            Report.WriteLine("I select saved item then the saved item should auto-fill in the Select Class field");
            scrollElementIntoView(attributeName_id, FreightDesp_First_AdditionalItem_SavedClassItem_DropDown_Id);
            Click(attributeName_id, FreightDesp_First_AdditionalItem_SavedClassItem_DropDown_Id);
            Report.WriteLine("dropdown value Selected in Class field");
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='scrollable-dropdown-menu-Origin']/div/span[1]/span/div/span/div/p"));
            int DropDownCount = DropDownList.Count;
            try
            {
                for (int i = 0; i < DropDownCount; i++)
                {
                    if (DropDownList[i].Text == saveditem)
                    {
                        DropDownList[i].Click();
                        break;
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("dropdownclosed");
            }
            Thread.Sleep(500);
        }

        [Then(@"item fields should display the text water marks which defaultitem contains nullorzero values")]
        public void ThenItemFieldsShouldDisplayTheTextWaterMarksWhichDefaultitemContainsNullorzeroValues()
        {
            Report.WriteLine("item fields should display the text water marks which defaultitem contains nullorzero values");
            scrollElementIntoView(attributeName_id, FreightDesp_FirstItem_Quantity_Id);
            string quantitytextlabel = GetAttribute(attributeName_xpath, "//input[@placeholder='Enter a quantity...']", "placeholder");
            String expQ = "Enter a quantity...";
            Assert.AreEqual(quantitytextlabel, expQ);
            string weighttextlabel = GetAttribute(attributeName_xpath, "//input[@placeholder='Enter a weight...']", "placeholder");
            string expWt = "Enter a weight...";
            Assert.AreEqual(weighttextlabel, expWt);
            string lengthtextlabel = GetAttribute(attributeName_xpath, "//input[@placeholder='Length...']", "placeholder");
            string expL = "Length...";
            Assert.AreEqual(lengthtextlabel, expL);
            string widthtextlabel = GetAttribute(attributeName_xpath, "//input[@placeholder='Width...']", "placeholder");
            string expW = "Width...";
            Assert.AreEqual(widthtextlabel, expW);
            string hieghttextlabel = GetAttribute(attributeName_xpath, "//input[@placeholder='Height...']", "placeholder");
            string expH = "Height...";
            Assert.AreEqual(hieghttextlabel, expH);


        }

        [Then(@"item fields should display the text water marks which saveditem contains nullorzero values")]
        public void ThenItemFieldsShouldDisplayTheTextWaterMarksWhichSaveditemContainsNullorzeroValues()
        {
            Report.WriteLine("item fields should display the text water marks which saveditem contains nullorzero values");
            scrollElementIntoView(attributeName_id, FreightDesp_FirstItem_Quantity_Id);
            string quantitytextlabel = GetAttribute(attributeName_xpath, "//input[@placeholder='Enter a quantity...']", "placeholder");
            String expQ = "Enter a quantity...";
            Assert.AreEqual(quantitytextlabel, expQ);
            string weighttextlabel = GetAttribute(attributeName_xpath, "//input[@placeholder='Enter a weight...']", "placeholder");
            string expWt = "Enter a weight...";
            Assert.AreEqual(weighttextlabel, expWt);
            string lengthtextlabel = GetAttribute(attributeName_xpath, "//input[@placeholder='Length...']", "placeholder");
            string expL = "Length...";
            Assert.AreEqual(lengthtextlabel, expL);
            string widthtextlabel = GetAttribute(attributeName_xpath, "//input[@placeholder='Width...']", "placeholder");
            string expW = "Width...";
            Assert.AreEqual(widthtextlabel, expW);
            string hieghttextlabel = GetAttribute(attributeName_xpath, "//input[@placeholder='Height...']", "placeholder");
            string expH = "Height...";
            Assert.AreEqual(hieghttextlabel, expH);

        }

        [Then(@"item fields should display the text water marks which saveditem contains nullorzero values additional item section")]
        public void ThenItemFieldsShouldDisplayTheTextWaterMarksWhichSaveditemContainsNullorzeroValuesAdditionalItemSection()
        {
            Report.WriteLine("item fields should display the text water marks which saveditem contains nullorzero values");
            scrollElementIntoView(attributeName_id, FreightDesp_First_AdditionalItem_SavedClassItem_DropDown_Id);
            string quantitytextlabel = GetAttribute(attributeName_xpath, " //input[@id='freightquantity-1'] [@placeholder='Enter a quantity...']", "placeholder");
            String expQ = "Enter a quantity...";
            Assert.AreEqual(quantitytextlabel, expQ);
            string weighttextlabel = GetAttribute(attributeName_xpath, "//input[@id='freightweight-1'] [@placeholder='Enter a weight...']", "placeholder");
            string expWt = "Enter a weight...";
            Assert.AreEqual(weighttextlabel, expWt);
            string lengthtextlabel = GetAttribute(attributeName_xpath, "//input[@id='freightlength-1'] [@placeholder='Length...']", "placeholder");
            string expL = "Length...";
            Assert.AreEqual(lengthtextlabel, expL);
            string widthtextlabel = GetAttribute(attributeName_xpath, "//input[@id='freightwidth-1'] [@placeholder='Width...']", "placeholder");
            string expW = "Width...";
            Assert.AreEqual(widthtextlabel, expW);
            string hieghttextlabel = GetAttribute(attributeName_xpath, "//input[@id='freightheight-1'] [@placeholder='Height...']", "placeholder");
            string expH = "Height...";
            Assert.AreEqual(hieghttextlabel, expH);
        }

    }
}
