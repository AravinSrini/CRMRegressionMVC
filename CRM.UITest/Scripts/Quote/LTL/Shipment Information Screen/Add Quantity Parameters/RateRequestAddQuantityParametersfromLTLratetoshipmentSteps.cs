using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Quote.LTL
{
    [Binding]
    public class RateRequestAddQuantityParametersfromLTLratetoshipmentSteps: ObjectRepository
    {        

        [When(@"I enter valid data in mandatory Item section (.*), (.*)")]
        public void WhenIEnterValidDataInMandatoryItemSection(string Classification, string Weight)
        {
            Report.WriteLine("Enter details in item section");
            Thread.Sleep(1000);
            scrollElementIntoView(attributeName_id, LTL_Classification_Id);
            Click(attributeName_id, LTL_Classification_Id);
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(LTL_ClassificationValues_Xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == Classification)
                {
                    DropDownList[i].Click();
                    break;
                }
            }
            SendKeys(attributeName_id, LTL_Weight_Id, Weight);            
        }

        [When(@"I enter value in (.*) and select (.*) from dropdown in Freight Description section")]
        public void WhenIEnterValueInAndSelectFromDropdownInFreightDescriptionSection(string Quantity, string Quantity_unit)
        {            
            Report.WriteLine("Select quantity unit from dropdown");
            Click(attributeName_id, ltlquantitydropdown_id);
            List<string> dropdownoptions=GetDropdownOptions(attributeName_id, ltlquantitydropdown_id, TagName_ltlquantitydropdown);
            foreach(var s in dropdownoptions)
            {
                if(Quantity_unit.Contains(s))
                {
                    SelectDropdownValueFromList(attributeName_id, ltlquantitydropdown_id, Quantity_unit);
                    Report.WriteLine("Selected dropdown value is " + s + "displaying");
                    
                }
            }
            Report.WriteLine("Enter details in Quantity field");
            Click(attributeName_id, LTL_Quantity_Id);
            SendKeys(attributeName_id, LTL_Quantity_Id, Quantity);
        }

        [When(@"I enter (.*) under Freight Description section")]
        public void WhenIEnterUnderFreightDescriptionSection(string ShipmentValue)
        {
            Report.WriteLine("Enter Shipment Value");
            SendKeys(attributeName_id, LTL_EnterInsuredValue_Id, ShipmentValue);
        }

        [When(@"I have not entered value in (.*) and select (.*) from dropdown in Freight Description section")]
        public void WhenIHaveNotEnteredValueInAndSelectFromDropdownInFreightDescriptionSection(string Quantity, string Quantity_unit)
        {
            Report.WriteLine("Select quantity unit from dropdown");
            Click(attributeName_id, ltlquantitydropdown_id);
            List<string> dropdownoptions = GetDropdownOptions(attributeName_id, ltlquantitydropdown_id, TagName_ltlquantitydropdown);
            foreach (var s in dropdownoptions)
            {
                if (Quantity_unit.Contains(s))
                {
                    SelectDropdownValueFromList(attributeName_id, ltlquantitydropdown_id, Quantity_unit);
                    Report.WriteLine("Selected dropdown value is " + s + "displaying");

                }
            }
            Report.WriteLine("Enter details in Quantity field");
            Click(attributeName_id, LTL_Quantity_Id);
            SendKeys(attributeName_id, LTL_Quantity_Id, Quantity);
        }

        [When(@"I enter value manually in (.*) and (.*) in Freight Description section")]
        public void WhenIEnterValueManuallyInAndInFreightDescriptionSection(string Quantity, string Quantity_unit)
        {
            Report.WriteLine("Enter quantity unit");
            Click(attributeName_id, ltlquantitydropdown_id);            
            SendKeys(attributeName_id, ltlquantitydropdown_id, Quantity_unit);
            
            Report.WriteLine("Enter details in Quantity field");
            Click(attributeName_id, LTL_Quantity_Id);
            SendKeys(attributeName_id, LTL_Quantity_Id, Quantity);
        }


        [When(@"I click on create shipment")]
        public void WhenIClickOnCreateShipment()
        {
            Report.WriteLine("Click on Create Shipment");
            Click(attributeName_xpath, ltlcreateshipmentbtn_xpath);
        }
        
        [When(@"I click on create insured shipment")]
        public void WhenIClickOnCreateInsuredShipment()
        {
            Report.WriteLine("Click on Create Insured Shipment");
            Click(attributeName_xpath, ltlcreateinsshipmentbtn_xpath);
        }
        
        [When(@"I click on Guaranteed Rate carriers hyperlink")]
        public void WhenIClickOnGuaranteedRateCarriersHyperlink()
        {
            Report.WriteLine("Click on Guaranteed Rate hyperlink");
            Click(attributeName_xpath, ltlGuaranteedRateAvbllnk_xpath);
        }
        
        [When(@"I should be navigated to Guaranteed Rate carriers grid")]
        public void WhenIShouldBeNavigatedToGuaranteedRateCarriersGrid()
        {
            Report.WriteLine("Guaranteed Rate carriers grid");
            MoveToElement(attributeName_xpath, ltlguarenteedrategrid_xpath);
        }
        
        [When(@"I click on create shipment of guaranteed grid")]
        public void WhenIClickOnCreateShipmentOfGuaranteedGrid()
        {
            Report.WriteLine("Click on Create Shipment of guaranteed rate grid");
            Click(attributeName_xpath, ltlcreateshipmentbtn_xpath);
        }
        
        [Then(@"I should navigate to Shipment Locations and Dates of Add Shipment page")]
        public void ThenIShouldNavigateToShipmentLocationsAndDatesOfAddShipmentPage()
        {
            Report.WriteLine("Verifying LTL shipment information page header");
            VerifyElementVisible(attributeName_xpath, LTL_createshipmentpageheader_xpath, "Add Shipment");
            VerifyElementVisible(attributeName_xpath, ltlshipmentLocationsandDates_xpath, "Shipment Locations and Dates");
        }

        [Then(@"I enter the mandatory fields (.*), (.*), (.*) and (.*)")]
        public void ThenIEnterTheMandatoryFieldsAnd(string OriginName, string OriginAddress, string DestinationName, string DestinationAddress)
        {
            Report.WriteLine("Enter Origin Name");
            WaitForElementVisible(attributeName_xpath, ltlshipmentOriginName_xpath, OriginName);
            SendKeys(attributeName_xpath,ltlshipmentOriginName_xpath, OriginName);

            Report.WriteLine("Enter Origin Address");
            SendKeys(attributeName_xpath,ltlshipmentOriginAddress_xpath, OriginAddress);

            Report.WriteLine("Enter Destination Name");
            SendKeys(attributeName_xpath,ltlshipmentDestinationName_xpath, DestinationName);

            Report.WriteLine("Enter Destination Address");
            SendKeys(attributeName_xpath,ltlshipmentDestinationAddress_xpath, DestinationAddress);
            Thread.Sleep(2000);
        }
        
        [Then(@"I click on Save and Continue")]
        public void ThenIClickOnSaveAndContinue()
        {
            Report.WriteLine("Click on Save and Continue");
            WaitForElementVisible(attributeName_xpath, ltlshipmentSaveandContinuebtn_xpath, "Save and Continue");
            Click(attributeName_xpath,ltlshipmentSaveandContinuebtn_xpath);
        }
        
        [Then(@"(.*) and (.*) fields should be auto populated")]
        public void ThenAndFieldsShouldBeAutoPopulated(string Quantity, string Quantity_unit)
        {
            Report.WriteLine("Quantity field should bind");
            WaitForElementVisible(attributeName_xpath, ltlshipmentQuantity_xpath, Quantity);
            string ActualQuantity = Gettext(attributeName_xpath, ltlshipmentQuantity_xpath);
            if(ActualQuantity==Quantity)
            {
                Report.WriteLine("Passed Quantity value during the rate is same as the value displaying after converting rate to shipment");
            }
            else
            {
                throw new System.Exception("Passed Quantity value during the rate is not same as the value displaying after converting rate to shipment");
            }            

            Report.WriteLine("Quantity unit field should bind");
            string ActualQuantityUnit = Gettext(attributeName_id, ltlquantitydropdown_id);
            if (ActualQuantityUnit == Quantity_unit)
            {
                Report.WriteLine("Slected Quantity unit during the rate is same as the unit displaying after converting rate to shipment");
            }
            else
            {
                throw new System.Exception("Selected Quantity unit during the rate is not same as the unit displaying after converting rate to shipment");
            }
            
        }
        
        [Then(@"(.*) and (.*) fields should not be auto populated")]
        public void ThenAndFieldsShouldNotBeAutoPopulated(string Quantity, string Quantity_unit)
        {
            Report.WriteLine("Quantity field should not bind");
            WaitForElementVisible(attributeName_xpath, ltlshipmentQuantity_xpath, Quantity);
            string ActualQuantity = Gettext(attributeName_xpath, ltlshipmentQuantity_xpath);
            if (ActualQuantity == Quantity)
            {
                Report.WriteLine("Passed Quantity value during the rate is same as the value displaying after converting rate to shipment");
            }
            else
            {
                throw new System.Exception("Passed Quantity value during the rate is not same as the value displaying after converting rate to shipment");
            }

            Report.WriteLine("Quantity unit field should bind");
            string ActualQuantityUnit = Gettext(attributeName_id, ltlquantitydropdown_id);
            if (ActualQuantityUnit == Quantity_unit)
            {
                Report.WriteLine("Slected Quantity unit during the rate is same as the unit displaying after converting rate to shipment");
            }
            else
            {
                throw new System.Exception("Selected Quantity unit during the rate is not same as the unit displaying after converting rate to shipment");
            }
        }
    }
}
