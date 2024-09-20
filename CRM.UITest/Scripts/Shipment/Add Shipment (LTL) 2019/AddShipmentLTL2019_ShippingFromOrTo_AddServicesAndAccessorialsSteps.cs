using System;
using TechTalk.SpecFlow;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using CRM.UITest.CommonMethods;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Text.RegularExpressions;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Entities;
using System.Collections.Specialized;
using System.Configuration;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.AddShipment_PageElements_AllUsers
{
    [Binding]
    public class AddShipmentLTL2019_ShippingFromOrTo_AddServicesAndAccessorialsSteps : AddShipments
    {
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();

        [Given(@"I am an operations or a station owner user")]
        public void GivenIAmAnOperationsOrAStationOwnerUser()
        {
            string username = ConfigurationManager.AppSettings["username-NewpageOperations"].ToString();
            string password = ConfigurationManager.AppSettings["password-NewpageOperations"].ToString();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"I am a  shp\.entry, shp\.entrynorates user")]
        public void GivenIAmAShp_EntryShp_EntrynoratesUser()
        {
            string username = ConfigurationManager.AppSettings["username-NewpageShipEntry"].ToString();
            string password = ConfigurationManager.AppSettings["password-NewpageShipEntry"].ToString();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"I am a sales, sales management user")]
        public void GivenIAmASalesSalesManagementUser()
        {
            string username = ConfigurationManager.AppSettings["username-NewpageSales"].ToString();
            string password = ConfigurationManager.AppSettings["password-NewpageSales"].ToString();
            CrmLogin.LoginToCRMApplication(username, password);
        }


        [Given(@"I am on the Add Shipment page")]
        public void GivenIAmOnTheAddShipmentPage()
        {
            Click(attributeName_xpath, AddShipmentIcon_Xpath);
            Click(attributeName_xpath, AllCustomerDropdown_Selection_Internal_Xpath);
            SendKeys(attributeName_xpath, AllCustomerDroppdownSearchBox_Internal_Xpath, "ZZZ - Czar Customer Test");
            SelectDropdownValueFromList(attributeName_xpath, AllCustomerDroppdownValues_Internal_Xpath, "ZZZ - Czar Customer Test");
            Click(attributeName_xpath, AddShipmentButton_Xpath);
            Click(attributeName_id, ShipmentServiceTypeLTL_id);
        }


        [When(@"I am on the Add Shipment page for a Sales user")]
        public void WhenIAmOnTheAddShipmentPageForASalesUser()
        {
            Click(attributeName_xpath, AddShipmentIcon_Xpath);
            Click(attributeName_xpath, AllCustomerDropdown_Selection_Internal_Xpath);
            SendKeys(attributeName_xpath, AllCustomerDroppdownSearchBox_Internal_Xpath, "ZZZ - Czar Customer Test");
            SelectDropdownValueFromList(attributeName_xpath, AllCustomerDroppdownValues_Internal_Xpath, "ZZZ - Czar Customer Test");
            Click(attributeName_xpath, AddShipmentButton_Xpath);
            Click(attributeName_id, ShipmentServiceTypeLTL_id);
        }

        [Given(@"I am on the Add Shipment page for a Sales user")]
        public void GivenIAmOnTheAddShipmentPageForASalesUser()
        {
            Click(attributeName_xpath, AddShipmentIcon_Xpath);
            Click(attributeName_xpath, AllCustomerDropdown_Selection_Internal_Xpath);
            SendKeys(attributeName_xpath, AllCustomerDroppdownSearchBox_Internal_Xpath, "ZZZ - Czar Customer Test");
            SelectDropdownValueFromList(attributeName_xpath, AllCustomerDroppdownValues_Internal_Xpath, "ZZZ - Czar Customer Test");
            Click(attributeName_xpath, AddShipmentButton_Xpath);
            Click(attributeName_id, ShipmentServiceTypeLTL_id);
        }

        [When(@"I enter value in the Click to add services & accessorials\.\.\. field in the Shipping From section")]
        public void WhenIEnterValueInTheClickToAddServicesAccessorials_FieldInTheShippingFromSection()
        {
            Click(attributeName_xpath, ShippingFrom_Accessorial_Xpath);
            SendKeys(attributeName_xpath, ShippingFrom_Accessorial_Xpath, "Gua");
        }

        [When(@"I enter value in the Click to add services & accessorials\.\.\. field in the Shipping To section")]
        public void WhenIEnterValueInTheClickToAddServicesAccessorials_FieldInTheShippingToSection()
        {
            Click(attributeName_xpath, ShippingTo_Accessorial_Xpath);
            SendKeys(attributeName_xpath, ShippingTo_Accessorial_Xpath, "Gua");
        }

        [Then(@"I have the option to select multiple services and accessorials from the searchable list field in the Shipping From section")]
        public void ThenIHaveTheOptionToSelectMultipleServicesAndAccessorialsFromTheSearchableListFieldInTheShippingFromSection()
        {
            Click(attributeName_xpath, ShippingFrom_Accessorial_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, ShippingFrom_AccessorialDropdownValues_Xpath, "Appointment");
            Click(attributeName_xpath, ShippingFrom_Accessorial_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, ShippingFrom_AccessorialDropdownValues_Xpath, "From LTL Int");
            string accessorials = Gettext(attributeName_id, ShippingFrom_AccessorialDropdown_Id);
            string accessval = accessorials.Replace("\r\n", " ");
            string selectedAccessorial = "Appointment From LTL Int";
            Assert.AreEqual(accessval, selectedAccessorial);
        }

        [Then(@"I have the option to remove previously selected services and accessorials from Shipping From section")]
        public void ThenIHaveTheOptionToRemovePreviouslySelectedServicesAndAccessorialsFromShippingFromSection()
        {
            Click(attributeName_xpath, ShippingFrom_RemoveAccessorial_Xpath);
            string accessorial = Gettext(attributeName_xpath, ShippingFrom_SelectedAccessorial_Xpath);
            string selectedAccessorial = "Appointment";
            Assert.AreEqual(accessorial, selectedAccessorial);
        }

        [Then(@"the results will be filtered in the Click to add services & accessorials\.\. field in Shipping From section")]
        public void ThenTheResultsWillBeFilteredInTheClickToAddServicesAccessorials_FieldInShippingFromSection()
        {
            IList<IWebElement> accessorialList = GlobalVariables.webDriver.FindElements(By.XPath(ShippingFrom_AccessorialDropdownVal_Xpath));
            int itemCount = accessorialList.Count;
            for (int i = 0; i < itemCount; i++)
            {
                string accessorialName = accessorialList[i].Text;
                if (accessorialName.StartsWith("Gua"))
                {
                    Assert.IsTrue(true);
                }
                else
                {
                    Assert.Fail();
                }

            }
        }

        [Then(@"I have the option to select multiple services and accessorials from the searchable list  field in the Shipping To section")]
        public void ThenIHaveTheOptionToSelectMultipleServicesAndAccessorialsFromTheSearchableListFieldInTheShippingToSection()
        {
            Click(attributeName_xpath, ShippingTo_Accessorial_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, ShippingTo_AccessorialDropdownValues_Xpath, "Notification");
            Click(attributeName_xpath, ShippingTo_Accessorial_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, ShippingTo_AccessorialDropdownValues_Xpath, "Liftgate Delivery");
            string accessorial = Gettext(attributeName_id, ShippingTo_AccessorialDropdown_Id);
            string accessval = accessorial.Replace("\r\n", " ");
            string selectedAccessorial = "Notification Liftgate Delivery";
            Assert.AreEqual(accessval, selectedAccessorial);
        }

        [Then(@"I have the option to remove previously selected services and accessorials from Shipping To section")]
        public void ThenIHaveTheOptionToRemovePreviouslySelectedServicesAndAccessorialsFromShippingToSection()
        {
            Click(attributeName_xpath, ShippingTo_RemoveAccessorial_Xpath);
            string accessorial = Gettext(attributeName_xpath, ShippingTo_SelectedAccessorial_Xpath);
            string selectedAccessorial = "Notification";
            Assert.AreEqual(accessorial, selectedAccessorial);
        }

        [Then(@"the results will be filtered in the Click to add services & accessorials\.\.\. field in Shipping To section")]
        public void ThenTheResultsWillBeFilteredInTheClickToAddServicesAccessorials_FieldInShippingToSection()
        {
            IList<IWebElement> accessorialList = GlobalVariables.webDriver.FindElements(By.XPath(ShippingFrom_AccessorialDropdownVal_Xpath));
            int itemCount = accessorialList.Count;
            for (int i = 0; i < itemCount; i++)
            {
                string accessorialName = accessorialList[i].Text;
                if (accessorialName.StartsWith("Gua"))
                {
                    Assert.IsTrue(true);
                }
                else
                {
                    Assert.Fail();
                }

            }
        }


    }
}
