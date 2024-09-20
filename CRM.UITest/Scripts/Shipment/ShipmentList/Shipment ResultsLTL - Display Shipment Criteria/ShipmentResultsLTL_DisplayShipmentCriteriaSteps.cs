using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Configuration;
using TechTalk.SpecFlow;
using System;
using OpenQA.Selenium.Interactions;

namespace CRMUITest
{
    [Binding]
    public class ShipmentResultsLTL_DisplayShipmentCriteriaSteps : Shipmentlist
    {
        CommonMethodsCrm crm = new CommonMethodsCrm();
        CommonQuoteNavigations quoteNavigations = new CommonQuoteNavigations();
        string selectedCustomerNameIdForRequote = string.Empty;

        [Given(@"I am a shpentry sales sales management operations or station owner user")]
        public void GivenIAmAShpentrySalesSalesManagementOperationsOrStationOwnerUser()
        {
            string Username = ConfigurationManager.AppSettings["username-UkShipEntryTest"].ToString();
            string Password = ConfigurationManager.AppSettings["password-UkShipEntryTest"].ToString();
            crm.LoginToCRMApplication(Username, Password);
        }

        [Given(@"I am on the Shipment Results LTL page and have entered (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*)")]
        [Given(@"I am on the Shipment Results LTL page")]       
        public void GivenIAmOnTheShipmentResultsLTLPage(string date, string originName, string originCity, string originState, string originAddress, string originZip,
            string destinationName, string destinationCity, string destinationState, string destinationAddress, string destinationZip, string Class, 
            string Description, string Quantity, string Weight)
        {
            Report.WriteLine("Click on the Shipments button");
            Click(attributeName_xpath, ShipmentIcon_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            IList<IWebElement> dropdownList = GlobalVariables.webDriver.FindElements(By.XPath("//*[@id='CustomerType_chosen']/div/ul"));
            if (dropdownList.Count > 0)
            {
                dropdownList[1].Click();
            }
            Click(attributeName_xpath, "//*[@id='add-shipment-btn']");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, "//*[@id='btn_ltl']");
            GlobalVariables.webDriver.WaitForPageLoad();

            AddShipmentLTL addShipment = new AddShipmentLTL();
            Report.WriteLine("Adding origin data");
            addShipment.AddShipmentOriginData(originName, originAddress, originZip);
            SendKeys(attributeName_xpath, "//*[@id='txtOrginCity']", originCity);
            Report.WriteLine("Selecting state " + originState);
            Click(attributeName_xpath, "//*[@id='page-content-wrapper']/div[2]/div[2]/div[1]/div[1]/div[5]/div/div[2]/div[2]/div/div");
            SelectDropdownValueFromList(attributeName_xpath, "//*[@id='state_origin_select_chosen']/div/ul", originState);

            Report.WriteLine("Adding destination data");
            addShipment.AddShipmentDestinationData(destinationName, destinationAddress, destinationZip);
            SendKeys(attributeName_xpath, "//*[@id='txtDestCity']", destinationCity);
            Report.WriteLine("Selecting state " + destinationState);
            Click(attributeName_xpath, "//*[@id='page-content-wrapper']/div[2]/div[2]/div[1]/div[2]/div[5]/div/div[2]/div[2]/div/div");
            SelectDropdownValueFromList(attributeName_xpath, "//*[@id='state_destination_select_chosen']/div/ul", destinationState);

            Report.WriteLine("Select Date from datepicker");
            DateTime dateTime = DateTime.Now;
            int day = dateTime.Day;
            if(date.Equals("Tomorrow"))
            {
                day += 1;
            }

            Click(attributeName_xpath, "//*[@id='PickupDate']");
            Click(attributeName_xpath, "//*[@class='datepicker-days']/table/tbody/tr/td[not(@class='disabled') and text()='" + day + "']");

            Report.WriteLine("Adding Freight Description");
            addShipment.AddShipmentFreightDescription(Class, "100", Quantity, Weight, Description);
        }

        [Given(@"I am on the Shipment Results LTL page (.*), (.*), (.*), (.*), (.*)")]
        public void GivenIAmOnTheShipmentResultsLTLPage(int itemCount, string itemClass, string description, string quantity, string weight, Table table)
        {
            Report.WriteLine("Click on the Shipments button");
            Click(attributeName_xpath, ShipmentIcon_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            IList<IWebElement> dropdownList = GlobalVariables.webDriver.FindElements(By.XPath("//*[@id='CustomerType_chosen']/div/ul"));
            if (dropdownList.Count > 0)
            {
                dropdownList[1].Click();
            }
            Click(attributeName_xpath, "//*[@id='add-shipment-btn']");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, "//*[@id='btn_ltl']");
            GlobalVariables.webDriver.WaitForPageLoad();

            AddShipmentLTL addShipment = new AddShipmentLTL();
            Report.WriteLine("Adding origin data");
            addShipment.AddShipmentOriginData("#1 MORGAN HIGHWAY AUTO PA" , "400 MORGAN HWY", "18508");
            SendKeys(attributeName_xpath, "//*[@id='txtOrginCity']", "Chicago");
            Report.WriteLine("Selecting state " + "IL");
            Click(attributeName_xpath, "//*[@id='page-content-wrapper']/div[2]/div[2]/div[1]/div[1]/div[5]/div/div[2]/div[2]/div/div");
            SelectDropdownValueFromList(attributeName_xpath, "//*[@id='state_origin_select_chosen']/div/ul", "IL");

            Report.WriteLine("Adding destination data");
            addShipment.AddShipmentDestinationData("11THNAME", "11thName12", "90087");
            SendKeys(attributeName_xpath, "//*[@id='txtDestCity']", "Los Angeles");
            Report.WriteLine("Selecting state " + "CA");
            Click(attributeName_xpath, "//*[@id='page-content-wrapper']/div[2]/div[2]/div[1]/div[2]/div[5]/div/div[2]/div[2]/div/div");
            SelectDropdownValueFromList(attributeName_xpath, "//*[@id='state_destination_select_chosen']/div/ul", "CA");

            Report.WriteLine("Select Date from datepicker");
            DateTime dateTime = DateTime.Now;
            int day = dateTime.Day;

            Click(attributeName_xpath, "//*[@id='PickupDate']");
            Click(attributeName_xpath, "//*[@class='datepicker-days']/table/tbody/tr/td[not(@class='disabled') and text()='" + day + "']");

            for(int i = 0; i < itemCount; i++)
            {
                string Class = table.Rows[i][0];
                string itemDescription = table.Rows[i][1];
                string itemQuantity = table.Rows[i][2];
                string itemWeight = table.Rows[i][3];

                Report.WriteLine("Adding Freight Description");
                SendKeys(attributeName_id, "freightdescription-" + i, Class);
                SendKeys(attributeName_id, "freightDesc-" + i, itemDescription);
                SendKeys(attributeName_id, "freightquantity-" + i, itemQuantity);
                SendKeys(attributeName_id, "freightweight-" + i, itemWeight);
                if (i != itemCount - 1)
                {
                    Click(attributeName_xpath, "//*[@id='0']/div[7]/button");
                }
                GlobalVariables.webDriver.WaitForPageLoad();
            }
        }
        
        [Given(@"the shipment contains more than one unique class")]
        public void GivenIAmOnTheShipmentResultsLTLPage(int count, Table table)
        {
            string itemClass, description, quantity, weight;
            Report.WriteLine("Click on the Shipments button");
            Click(attributeName_xpath, ShipmentIcon_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            IList<IWebElement> dropdownList = GlobalVariables.webDriver.FindElements(By.XPath("//*[@id='CustomerType_chosen']/div/ul"));
            if (dropdownList.Count > 0)
            {
                dropdownList[1].Click();
            }
            Click(attributeName_xpath, "//*[@id='add-shipment-btn']");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, "//*[@id='btn_ltl']");
            GlobalVariables.webDriver.WaitForPageLoad();

            AddShipmentLTL addShipment = new AddShipmentLTL();
            Report.WriteLine("Adding origin data");
            addShipment.AddShipmentOriginData("#1 MORGAN HIGHWAY AUTO PA", "400 MORGAN HWY", "18508");
            Report.WriteLine("Adding destination data");
            addShipment.AddShipmentDestinationData("11THNAME", "11thName12", "90087");
            Report.WriteLine("Adding Freight Description for first item");
            addShipment.AddShipmentFreightDescription("50", "500", "20", "200", "test");

            for(int i = 1; i < count; i++)
            {
                Click(attributeName_xpath, "//*[@id=" + (i - 1) + "]/div[7]/button");
                var row = table.Rows[i - 1];
                row.TryGetValue("Class", out itemClass);
                row.TryGetValue("Class", out description);
                row.TryGetValue("Class", out quantity);
                row.TryGetValue("Class", out weight);
                addShipment.AddShipmentFreightDescription(itemClass, "100", description, quantity, weight);
            }
        }

        [When(@"I arrive on the Shipment Results LTL page (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*)")]
        public void WhenIArriveOnTheShipmentResultsLTLPage(string date, string originName, string originCity, 
            string originState, string originAddress, string originZip, string destinationName, string destinationCity, string destinationState, 
            string destinationAddress, string destinationZip, string Class, string Description, string Quantity, string Weight)
        {
            Report.WriteLine("Click on the Shipments button");
            Click(attributeName_xpath, ShipmentIcon_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            IList<IWebElement> dropdownList = GlobalVariables.webDriver.FindElements(By.XPath("//*[@id='CustomerType_chosen']/div/ul"));
            if (dropdownList.Count > 0)
            {
                dropdownList[1].Click();
            }
            Click(attributeName_xpath, "//*[@id='add-shipment-btn']");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, "//*[@id='btn_ltl']");
            GlobalVariables.webDriver.WaitForPageLoad();

            AddShipmentLTL addShipment = new AddShipmentLTL();
            Report.WriteLine("Adding origin data");
            addShipment.AddShipmentOriginData(originName, originAddress, originZip);
            SendKeys(attributeName_xpath, "//*[@id='txtOrginCity']", originCity);
            Report.WriteLine("Selecting state " + originState);
            Click(attributeName_xpath, "//*[@id='page-content-wrapper']/div[2]/div[2]/div[1]/div[1]/div[5]/div/div[2]/div[2]/div/div");
            SelectDropdownValueFromList(attributeName_xpath, "//*[@id='state_origin_select_chosen']/div/ul", originState);

            Report.WriteLine("Adding destination data");
            addShipment.AddShipmentDestinationData(destinationName, destinationAddress, destinationZip);
            SendKeys(attributeName_xpath, "//*[@id='txtDestCity']", destinationCity);
            Report.WriteLine("Selecting state " + destinationState);
            Click(attributeName_xpath, "//*[@id='page-content-wrapper']/div[2]/div[2]/div[1]/div[2]/div[5]/div/div[2]/div[2]/div/div");
            SelectDropdownValueFromList(attributeName_xpath, "//*[@id='state_destination_select_chosen']/div/ul", destinationState);

            Report.WriteLine("Select Date from datepicker");
            DateTime dateTime = DateTime.Now;
            int day = dateTime.Day;
            if (date.Equals("Tomorrow"))
            {
                day += 1;
            }

            Click(attributeName_xpath, "//*[@id='PickupDate']");
            Click(attributeName_xpath, "//*[@class='datepicker-days']/table/tbody/tr/td[not(@class='disabled') and text()='" + day + "']");

            Report.WriteLine("Adding Freight Description");
            addShipment.AddShipmentFreightDescription(Class, "100", Quantity, Weight, Description);

            Click(attributeName_xpath, "//*[@id='page-content-wrapper']/div[2]/div[2]/div[8]/div/button");
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [When(@"the shipment contains one unique class")]
        public void WhenTheShipmentContainsOneUniqueClass()
        {
            Report.WriteLine("Verify the additional item area is not visible");
            VerifyElementNotPresent(attributeName_xpath, "/*[@id='1']/div/div[6]/div/div/button", "Additional Information box");
            //*[@id="page-content-wrapper"]/div[2]/div[2]/div[8]/div/button
            Click(attributeName_xpath, "//*[@id='page-content-wrapper']/div[2]/div[2]/div[8]/div/button");
            GlobalVariables.webDriver.WaitForPageLoad();
        }
                
        [When(@"the shipment contains more than one unique class")]
        public void WhenTheShipmentContainsMoreThanOneUniqueClass()
        {
            Report.WriteLine("Verify the addition item area is visible");
            VerifyElementVisible(attributeName_xpath, "//*[@id='1']/div/div[6]/div/div/button", "Additional Information box");

            AddShipmentLTL addshipments = new AddShipmentLTL();

            addshipments.ClickViewRates();
            GlobalVariables.webDriver.WaitForPageLoad();
        }
        /*
        [When(@"I hover over the More Information icon in the Class Weight field")]
        public void WhenIHoverOverTheMoreInformationIconInTheClassWeightField()
        {
            Report.WriteLine("Hover over the more information button");
            Actions action = new Actions(GlobalVariables.webDriver);
            IWebElement moreInformation = GlobalVariables.webDriver.FindElement(By.XPath("//*[@id='btn-information']"));
            action.MoveToElement(moreInformation).Perform();
        }*/

        [Then(@"I will see the following new fields:")]
        public void ThenIWillSeeTheFollowingNewFields(Table table)
        {
            string pickupDate = table.Rows[0][0];
            string origin = table.Rows[1][0];
            string destination = table.Rows[2][0];
            string quantity = table.Rows[3][0];
            string itemClassWeight = table.Rows[4][0];
            Report.WriteLine("Verify the fields are displayed in the shipment criteria bar");
            Verifytext(attributeName_xpath, "//*[@id='page-content-wrapper']/div[2]/div[2]/div[5]/div[1]/span[@class='text-bold']", pickupDate);
            Verifytext(attributeName_xpath, "//*[@id='page-content-wrapper']/div[2]/div[2]/div[5]/div[2]/span[1]", origin);
            Verifytext(attributeName_xpath, "//*[@id='page-content-wrapper']/div[2]/div[2]/div[5]/div[3]/span[1]", destination);
            Verifytext(attributeName_xpath, "//*[@id='page-content-wrapper']/div[2]/div[2]/div[5]/div[4]/span[1]", quantity);
            Verifytext(attributeName_xpath, "//*[@id='page-content-wrapper']/div[2]/div[2]/div[5]/div[5]/span[1]", itemClassWeight);
        }

        [Then(@"The elements are not editable")]
        public void ThenTheElementsAreNotEditable()
        {
            Report.WriteLine("Verify the fields in the shipment criteria bar are not editable");
            Assert.AreNotEqual("input", GlobalVariables.webDriver.FindElement(By.XPath("//*[@id='page-content-wrapper']/div[2]/div[2]/div[5]/div[1]/span[@class='text-bold']")).TagName);
            Assert.AreNotEqual("input", GlobalVariables.webDriver.FindElement(By.XPath("//*[@id='page-content-wrapper']/div[2]/div[2]/div[5]/div[2]/span[1]")).TagName);
            Assert.AreNotEqual("input", GlobalVariables.webDriver.FindElement(By.XPath("//*[@id='page-content-wrapper']/div[2]/div[2]/div[5]/div[3]/span[1]")).TagName);
            Assert.AreNotEqual("input", GlobalVariables.webDriver.FindElement(By.XPath("//*[@id='page-content-wrapper']/div[2]/div[2]/div[5]/div[4]/span[1]")).TagName);
            Assert.AreNotEqual("input", GlobalVariables.webDriver.FindElement(By.XPath("//*[@id='page-content-wrapper']/div[2]/div[2]/div[5]/div[5]/span[1]")).TagName);
        }

        [Then(@"the Pickup Date field will be populated with the (.*) selected on the Add Shipment LTL page")]
        public void ThenThePickupDateFieldWillBePopulatedWithThePickupDateSelectedOnTheAddShipmentLTLPage(string date)
        {
            DateTime dateTime = DateTime.Now;
            int day = dateTime.Day;
            if (date.Equals("Tomorrow"))
            {
                day += 1;
            }

            DateTime newDateTime = new DateTime(dateTime.Year, dateTime.Month, day);
            Report.WriteLine("Verify the pick up date is correct");
            Verifytext(attributeName_xpath, "//*[@id='shipment-criteria-pickup-date']", newDateTime.ToString("MM/dd/yyyy"));
        }
        
        [Then(@"the Originfield will be populated with the (.*), (.*), (.*) from the of the Add Shipment LTL page")]
        public void ThenTheOriginfieldWillBePopulatedWithTheCitySTZipInformationEnteredInTheEnterCitySelectStateProvinceAndEnterZipPostalCodeFieldsInTheShippingFromSectionOfTheAddShipmentLTLPage(string originCity, string originState, string originZip)
        {
            Report.WriteLine("Verify the origin details are displayed correctly");
            Verifytext(attributeName_xpath, "//*[@id='shipment-criteria-origin']", originCity + ", " + originState + " " + originZip);
        }
        
        [Then(@"the Destination field will be populated with the (.*), (.*), (.*) fields from the Shipping To section of the Add Shipment LTL page")]
        public void ThenTheDestinationFieldWillBePopulatedWithTheCitySTZipInformationEnteredInTheEnterCitySelectStateProvinceAndEnterZipPostalCodeFieldsInTheShippingToSectionOfTheAddShipmentLTLPage(string destinationCity, string destinationState, string destinationZip)
        {
            Report.WriteLine("Verify the destination details are dislayed correctly");
            Verifytext(attributeName_xpath, "//*[@id='shipment-criteria-destination']", destinationCity + ", " + destinationState + " " + destinationZip);
        }
        
        [Then(@"the Pieces field will be populated with the total of all values entered in the Enter a (.*) fields in the Freight Description section of the Add Shipment LTL page")]
        public void ThenThePiecesFieldWillBePopulatedWithTheTotalOfAllValuesEnteredInTheEnterAQuantityFieldsInTheFreightDescriptionSectionOfTheAddShipmentLTLPage(string quantity)
        {
            Report.WriteLine("Verify the pieces field is dispalyed and populated correctly");
            Verifytext(attributeName_xpath, "//*[@id='shipment-criteria-pieces']", quantity);
        }
        
        [Then(@"the Class/Weight field will be populated with the values entered in the class and weight fields in the previous form (.*), (.*)")]
        public void ThenTheWeightFieldWillBePopulatedWithTheTotalOfAllValuesEnteredInTheEnterAWeightFieldsInTheFreightDescriptionSectionOfTheAddShipmentLTLPage(string itemClass, string weight)
        {
            Report.WriteLine("Verify the class/weight field is displayed and populated correctly");
            Verifytext(attributeName_xpath, "//*[@id='shipment-criteria-class-weight']", itemClass + "/" + weight + " LBS");
        }

        [Then(@"I will not see a More Information icon displayed in the Class Weight field of the shipment criteria")]
        public void ThenIWillNotSeeAMoreInformationIconDisplayedInTheClassWeightFieldOfTheShipmentCriteria()
        {
            Report.WriteLine("Verify the more information icon is not displayed when there is only one unique item class");
            VerifyElementNotPresent(attributeName_xpath, "//*[@id='btn-information']", "More information icon");
        }

        [Then(@"I will see a More Information icon displayed in the Class Weight field of the shipment criteria")]
        public void ThenIWillSeeAMoreInformationIconDisplayedInTheClassWeightFieldOfTheShipmentCriteria_()
        {            
            Report.WriteLine("Verify the more information icon is displayed when there is more than one unique item");
            VerifyElementPresent(attributeName_xpath, "//*[@id='shipment-criteria-class-weight']", "More information icon");
        }
        
        [Then(@"I will see a pop up displaying the pieces class and weight of each unique class when I hover over the more information icon (.*)")]
        public void ThenIWillSeeAPopUpDisplayingThePiecesClassAndWeightOfEachUniqueClass_(int count, Table items)
        {
            Report.WriteLine("Hover over the more information button");
            Actions action = new Actions(GlobalVariables.webDriver);
            IWebElement moreInformation = GlobalVariables.webDriver.FindElement(By.XPath("//*[@id='btn-information']"));
            action.MoveToElement(moreInformation).Perform();
            for (int i = 0; i < count; i++)
            {
                var classWeight = items.Rows[i][0];
                var pieces = items.Rows[i][1];
                var c = i + 1;
                Verifytext(attributeName_xpath, "//*[@class='popover-content']/table/tbody/tr[" + c + "]/td[1]", pieces);
                Verifytext(attributeName_xpath, "//*[@class='popover-content']/table/tbody/tr[" + c + "]/td[2]", classWeight);
            }
        }
    }
}