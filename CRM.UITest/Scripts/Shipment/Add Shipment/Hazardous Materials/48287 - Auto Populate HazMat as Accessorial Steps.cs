using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.Hazardous_Materials
{
    [Binding]
    public sealed class _48287___Auto_populate_HazMat_as_accessorial : AddShipments
    {
        GetChosenAccessorials getChosenAccessorials = new GetChosenAccessorials();

        int accessorialCount = 0;

        [Given(@"the hazardous material accessorial is auto-selected")]
        [Then(@"the Hazardous Materials accessorial will be auto-selected in the shipping from section")]
        public void ThenTheHazardousMaterialsAccessorialWillBeAuto_SelectedInTheShippingSection()
        {
            IList<IWebElement> chosenAccessorials = getChosenAccessorials.GetShippingFromChosenAccessorials();
            bool isHazardousMaterial = false;
            foreach (IWebElement accessorial in chosenAccessorials)
            {
                if (accessorial.FindElement(By.TagName("span")).Text.Equals("Hazardous Material"))
                {
                    isHazardousMaterial = true;
                }
            }
            if(isHazardousMaterial)
            {
                Report.WriteLine("Hazardous Material accessorial was selected");

            }
            else
            {
                Report.WriteFailure("Hazardous material accessorial not selected");
            }
        }

        [When(@"I add multiple items with at least one flagged as hazardous material")]
        [When(@"I add an addition item to the shipment and both items are flagged as hazardous material")]
        public void WhenIAddMultipleItemsWithAtLeastOneFlaggedAsHazardousMaterial()
        {
            Report.WriteLine("Setting the first item as hazardous material");
            Click(attributeName_xpath, FreightDesp_FirstItem_Hazardous_Yes_RadioButton_xpath);
            Thread.Sleep(500);
            Report.WriteLine("Adding an additional item");
            Click(attributeName_xpath, AddAdditionalItemButton_xpath);
            Thread.Sleep(500);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Setting the second item as hazardous material");
            Click(attributeName_xpath, FreightDesp_First_AdditionalItem_Hazardous_Yes_RadioButton_xpath);
        }
        
        [Given(@"I add an additional item")]
        [When(@"I add an addition item to the shipment")]
        public void WhenIAddAnAdditionItemToTheShipment()
        {
            Report.WriteLine("Adding an additional item");
            Click(attributeName_xpath, AddAdditionalItemButton_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Thread.Sleep(500);
        }

        [Given(@"I add an accessorial to the shipment")]
        public void GivenIAddAnAccessorialToTheShipment()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, LTLAddShipment_SelectedAccessorial_ShippingFrom_Xpath, "Accessorial");
            Report.WriteLine("Selecting Appointment accessorial");
            WaitForElementVisible(attributeName_xpath, LTLAddShipment_SelectedAccessorial_ShippingFrom_Xpath, "Shipping From Accessorial Dropdown");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, LTLAddShipment_SelectedAccessorial_ShippingFrom_Xpath);
            WaitForElementVisible(attributeName_cssselector, "#shippingfromaccessorial_chosen > div", "Accessorial dropdown list");
            SendKeys(attributeName_xpath, ShippingFrom_ServicesAccessorial_DropDown_xpath, "Appointment");
            SelectDropdownValueFromList(attributeName_xpath, LTLAddShipment_SelectedAccessorial_ShippingFrom_Xpath, "Appointment");

            IList<IWebElement> chosenAccessorials = getChosenAccessorials.GetShippingFromChosenAccessorials();
            accessorialCount = chosenAccessorials.Count;
            Report.WriteLine(accessorialCount + " added accessorials");
        }

        [Given(@"I flag the additional item as hazardous material")]
        [When(@"I flag the additional item as hazardous material")]
        public void WhenIFlagTheAdditionalItemAsHazardousMaterial()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Setting the second item as hazardous material");
            Click(attributeName_xpath, FreightDesp_First_AdditionalItem_Hazardous_Yes_RadioButton_xpath);
            Thread.Sleep(500);
        }

        [When(@"I remove the hazardous material flagged additional item")]
        public void WhenIRemoveTheHazardousMaterialFlaggedAdditionalItem()
        {
            Report.WriteLine("Removing additional item");
            Click(attributeName_classname, FreightDesp_RemoveItem_Button_Class);
            WaitForElementNotPresent(attributeName_classname, FreightDesp_RemoveItem_Button_Class, "Remove button");
        }

        [Then(@"the chosen accessorials other than hazardous materials remain selected")]
        public void ThenTheChosenAccessorialsOtherThanHazardousMaterialsRemainSelected()
        {
            IList<IWebElement> chosenAccessorials = getChosenAccessorials.GetShippingFromChosenAccessorials();

            Assert.AreEqual(accessorialCount + 1, chosenAccessorials.Count);
        }

        [Then(@"all items are no longer flagged as hazardous material")]
        public void ThenAllItemsAreNoLongerFlaggedAsHazardousMaterial()
        {
            VerifyElementNotChecked(attributeName_xpath, FreightDesp_FirstItem_Hazardous_Yes_RadioButton_xpath, "First item No option selected");
            Report.WriteLine("First item hazardous material no option was selected");
            VerifyElementNotChecked(attributeName_xpath, FreightDesp_First_AdditionalItem_Hazardous_Yes_RadioButton_xpath, "Additional item No option selected");
            Report.WriteLine("Additional item hazardous material no option was selected");
        }

        [Then(@"the first item is flagged as hazardous material")]
        public void ThenTheFirstItemIsFlaggedAsHazardousMaterial()
        {
            VerifyElementChecked(attributeName_id, "Hazard-0_Hazard-0Yes", "Hazardous Yes Option");
            Report.WriteLine("First item hazardous material yes option was selected");
        }

        [Then(@"the second item is not flagged as hazardous material")]
        public void ThenTheSecondItemIsNotFlaggedAsHazardousMaterial()
        {
            VerifyElementNotChecked(attributeName_xpath, FreightDesp_First_AdditionalItem_Hazardous_Yes_RadioButton_xpath, "Additional item No option");
            Report.WriteLine("Additional item hazardous material no option was selected");
        }

        [Then(@"the hazardous material accessorial is added only once")]
        public void ThenTheHazardousMaterialAccessorialIsAddedOnlyOnce()
        {
            IList<IWebElement> chosenAccessorials = getChosenAccessorials.GetShippingFromChosenAccessorials();
            IList<IWebElement> hazarousMaterialAccessorials = chosenAccessorials.Where(x => x.FindElement(By.TagName("span")).Text.Equals("Hazardous Material")).ToList();
            if (chosenAccessorials.Count > 1)
            {
                Report.WriteFailure("The hazardous material accessorial was added more than once");
            }
            Report.WriteLine("Hazarous material accessorial not added multiple times");
        }

        [Then(@"I will have the option to remove the hazardous material accessorial")]
        public void ThenIWillHaveTheOptionToRemoveTheHazardousMaterialAccessorial()
        {
            IList<IWebElement> chosenAccessorials = getChosenAccessorials.GetShippingFromChosenAccessorials();
            int counter = 1;
            foreach (IWebElement accessorial in chosenAccessorials)
            {
                if (accessorial.FindElement(By.TagName("span")).Text.Equals("Hazardous Material"))
                {
                    Report.WriteLine("Hazardous Material accessorial was selected");
                    scrollPageup();
                    Click(attributeName_cssselector, "#shippingfromaccessorial_chosen > ul > li:nth-child(" + counter + ") > a");
                    break;
                }
                counter++;
            }
            Thread.Sleep(500);
            VerifyElementNotVisible(attributeName_cssselector, "#shippingfromaccessorial_chosen > ul > li:nth-child(" + counter + ") > a", "Remove accessorial button");
        }
    }
}
 