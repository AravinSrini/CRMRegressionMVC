using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.TL_Rating_Tool.Get_Quote__TL_.Equipment_Type
{
    [Binding]
    public class GetQuote_EquipmentTypeSteps : TruckloadRatingTool
    {
        [Then(@"I should see the (.*) selected as a default Equipment Type in dropdown")]
        public void ThenIShouldSeeTheSelectedAsADefaultEquipmentTypeInDropdown(string defaultEquipment)
        {
            string actualValue = Gettext(attributeName_xpath, TL_EquipmentType_SelectedValue_Xpath);
            Assert.AreEqual(actualValue, defaultEquipment);
            Report.WriteLine(actualValue + " is binding as a default equipment type in the dropdown");
        }

        [Then(@"I should see all the options in Equipment Type dropdown (.*)")]
        public void ThenIShouldSeeAllTheOptionsInEquipmentTypeDropdown(string values)
        {
            Click(attributeName_id, TL_EquipmentType_ID);
            string[] valuesexp = values.Split(',');
            IList<IWebElement> dropdownValues = GlobalVariables.webDriver.FindElements(By.XPath(TL_EquipmentType_DropdownValue_Xpath));
            for (int i = 0; i < dropdownValues.Count; i++)
            {
                if (valuesexp.Contains(dropdownValues[i].Text))
                {
                    Report.WriteLine(dropdownValues[i].Text + " option is displaying in equipment dropdown");
                }
                else
                {
                    Report.WriteLine("Displaying dropdownvalues is not matching with expected values");
                    Assert.IsTrue(false);
                }
            }
        }

        [Then(@"I should able to select any option from the Equipment type dropdown (.*)")]
        public void ThenIShouldAbleToSelectAnyOptionFromTheEquipmentTypeDropdown(string EquiValue)
        {
            Click(attributeName_id, TL_EquipmentType_ID);
            SelectDropdownValueFromList(attributeName_xpath, TL_EquipmentType_DropdownValue_Xpath, EquiValue);
            string acutalvalue = Gettext(attributeName_xpath, TL_EquipmentType_SelectedValue_Xpath);
            Assert.AreEqual(acutalvalue, EquiValue);
            Report.WriteLine("User is able to select equipment type " + EquiValue + " from the dropdown");
        }
    }
}
