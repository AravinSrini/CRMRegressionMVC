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

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Information_Screen
{
    [Binding]
    public sealed class Services_and_Accessorials___All_Users_Stpes : AddShipments
    {
        [Then(@"I must be able to view Services & Accessorials multi select field in the Shipping From section")]
        public void ThenIMustBeAbleToViewServicesAccessorialsMultiSelectFieldInTheShippingFromSection()
        {
            Report.WriteLine("Display of Services And Accessorials Multi Select dropdown in ShipFrom Section");
            VerifyElementPresent(attributeName_xpath, ShippingFrom_ServicesAccessorial_DropDown_xpath, "ShipFrom Multi select dropdown");
        }

        [When(@"I click services and accessorials drop down on Shipping From section")]
        public void WhenIClickServicesAndAccessorialsDropDownOnShippingFromSection()
        {
            Report.WriteLine("Click on Services and Accessorials");
            Click(attributeName_xpath, ShippingFrom_ServicesAccessorial_DropDown_xpath);
        }


        [When(@"I select a service (.*) from the Shipping To section dropdown")]
        public void WhenISelectAServiceFromTheShippingToSectionDropdown(string Accessorials)
        {
            Report.WriteLine("Selection of Accessorials and Services");
            SelectDropdownValueFromList(attributeName_xpath, ShippingTo_ServicesAccessorial_DropDown_xpath, Accessorials);
        }



        [Then(@"I should be able to select services '(.*)' and '(.*)' from Shipping From Section")]
        public void ThenIShouldBeAbleToSelectServicesAndFromShippingFromSection(string Accessorials1, string Accessorials2)
        {
            SelectDropdownValueFromList(attributeName_xpath, ShippingFrom_ServicesAccessorial_DropDown_Values_xpath, Accessorials1);
            Click(attributeName_xpath, ShippingFrom_ServicesAccessorial_DropDown_xpath);
            SelectDropdownValueFromList(attributeName_xpath, ShippingFrom_ServicesAccessorial_DropDown_Values_xpath, Accessorials2);
        }

        [When(@"I select a service (.*) from the Shipping From section dropdown")]
        public void WhenISelectAServiceFromTheShippingFromSectionDropdown(string Accessorials)
        {
            Report.WriteLine("Selection of Accessorials and Services");
            SelectDropdownValueFromList(attributeName_xpath, ShippingFrom_ServicesAccessorial_DropDown_xpath, Accessorials);
        }

        [Then(@"I must have an option to delete the service selected from the Shipping From drop down")]
        public void ThenIMustHaveAnOptionToDeleteTheServiceSelectedFromTheShippingFromDropDown()
        {
            Report.WriteLine("Deltion of Accessorials and services selected");
            Click(attributeName_xpath, ShippingFrom_ServicesAccessorial_Delete_Icon_xpath);
        }

        [Then(@"I should be able to view specified Shipping From services in the drop down")]
        public void ThenIShouldBeAbleToViewSpecifiedShippingFromServicesInTheDropDown()
        {
            Report.WriteLine("Verification of Ship.From dropdown values");
            //Need to change xpath
            IList<IWebElement> ShipFromDropdownList = GlobalVariables.webDriver.FindElements(By.XPath("//*[@id='shippingfromaccessorial_chosen']/div/ul/li"));
            List<string> ShipFromValues = new List<string>(new string[] { "Appointment", "Construction Site", "Convention-Exhibition Site Pickup", "Excessive Overlength (LKVL Only)", "Inside Pickup", "Liftgate Pickup", "Limited Access Pickup", "Origin Sort and Segregate", "Overlength", "Protect From Freeze", "Residential Pickup" });
            int ShipFromCountUI = ShipFromDropdownList.Count;

            foreach (var val in ShipFromDropdownList)
            {
                if (ShipFromValues.Contains(val.Text))
                {
                    Report.WriteLine("Display of" + val.Text + " Ship.From values");

                }
                else
                {
                    Assert.Fail();

                }
            }
        }


        [Then(@"I must be able to view Services & Accessorials multi select field in the Shipping To section")]
        public void ThenIMustBeAbleToViewServicesAccessorialsMultiSelectFieldInTheShippingToSection()
        {
            Report.WriteLine("Display of Services And Accessorials Multi Select dropdown in ShipFrom Section");
            VerifyElementPresent(attributeName_xpath, ShippingTo_ServicesAccessorial_DropDown_xpath, "ShipFrom Multi select dropdown");
        }

        [When(@"I click services and accessorials drop down on Shipping To section")]
        public void WhenIClickServicesAndAccessorialsDropDownOnShippingToSection()
        {
            Report.WriteLine("Click on Services and Accessorials");
            Click(attributeName_xpath, ShippingTo_ServicesAccessorial_DropDown_xpath);
        }

        [Then(@"I should be able to select services '(.*)' and '(.*)' from Shipping To Section")]
        public void ThenIShouldBeAbleToSelectServicesAndFromShippingToSection(string Accessorials1, string Accessorials2)
        {
            SelectDropdownValueFromList(attributeName_xpath, ShippingTo_ServicesAccessorial_DropDown_Values_xpath, Accessorials1);
            Click(attributeName_xpath, ShippingTo_ServicesAccessorial_DropDown_xpath);
            SelectDropdownValueFromList(attributeName_xpath, ShippingTo_ServicesAccessorial_DropDown_Values_xpath, Accessorials2);
        }

        [Then(@"I must have an option to delete the service selected from the Shipping To drop down")]
        public void ThenIMustHaveAnOptionToDeleteTheServiceSelectedFromTheShippingToDropDown()
        {
            Report.WriteLine("Deltion of Accessorials and services selected");
            Click(attributeName_xpath, ShippingTo_ServicesAccessorial_Delete_Icon_xpath);
        }

        [Then(@"I should be able to view specified Shipping To services in the drop down")]
        public void ThenIShouldBeAbleToViewSpecifiedShippingToServicesInTheDropDown()
        {
            Report.WriteLine("Verification of Ship.From dropdown values");
        
            //Need to change xpath
            IList<IWebElement> ShipFromDropdownList = GlobalVariables.webDriver.FindElements(By.XPath("//*[@id='shippingtoaccessorial_chosen']/div/ul/li"));
            List<string> ShipFromValues = new List<string>(new string[] { "Appointment", "COD", "Construction Site", "Convention-Exhibition Site Delivery", "Excessive Overlength (LKVL Only)", "Inside Delivery", "Liftgate Delivery", "Limited Access Delivery", "Overlength", "Protect From Freeze", "Residential Delivery", "Sort And Segregate", "Special Delivery" });
            int ShipFromCountUI = ShipFromDropdownList.Count;

            foreach (var val in ShipFromDropdownList)
            {
                if (ShipFromValues.Contains(val.Text))
                {
                    Report.WriteLine("Display of" + val.Text + " Ship.From values");

                }
                else
                {
                    Assert.Fail();

                }
            }
        }

    }
}
