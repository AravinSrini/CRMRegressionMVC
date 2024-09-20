using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Objects;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Threading;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Results
{
    [Binding]
    public class InsuredValue_ExcludedCarrierS_ShipmentSteps:AddShipments
    {
        AddShipmentLTL ltl = new AddShipmentLTL();
        AddQuoteLTL qltl = new AddQuoteLTL();        

        [When(@"I entered (.*) and click on view rates button")]
        public void WhenIEnteredAndClickOnViewRatesButton(string insuredRate)
        {
            Report.WriteLine("Enter Insured value in add shipment page");
            SendKeys(attributeName_id, InsuredValue_TextBox_Id, insuredRate);
            Report.WriteLine("Click on View Rates button in add shipment page");            
            ltl.ClickViewRates();            
        }
                
        [When(@"I enter (.*) in shipment results page")]
        public void WhenIEnterInShipmentResultsPage(string insuredRate)
        {
            Report.WriteLine("Enter Insured value in add shipment page");            
            SendKeys(attributeName_id, ShipResults_InsuredRateTextbox_Id, insuredRate);
            Click(attributeName_id, ShipResults_ShowInsuredRateButton_Id);
            Thread.Sleep(10000);
            WaitForElementVisible(attributeName_xpath, ShipResults_InsuredRateColumn_Xpath, "Insured Rate");
        }

        [When(@"am on the Rateresults page (.*), (.*), (.*), (.*), (.*), (.*), (.*)and (.*)")]
        public void WhenAmOnTheRateresultsPageAnd(string userType, string customerName, string oZip, string dZip, string classification, string weight, string quantity, string insuredRate)
        {
            
            qltl.NaviagteToQuoteList();
            Report.WriteLine("I have navigated to quote list page");
            qltl.Add_QuoteLTL(userType, customerName);
            Report.WriteLine("Clicked on Submit Rate Request button");
            qltl.EnterOriginZip(oZip);
            Report.WriteLine("I have entered origin zip code on get quote ltl page");
            qltl.EnterDestinationZip(dZip);
            Report.WriteLine("I have entered destination zip code on get quote ltl page");
            qltl.EnterItemdata(classification, weight);
            Report.WriteLine("I have selected classification from dropdown and entered weight on get quote ltl page");
            SendKeys(attributeName_id, LTL_Quantity_Id, quantity);
            Report.WriteLine("I have entered quantity under freight description on get quote ltl page");
            SendKeys(attributeName_id, LTL_EnterInsuredValue_Id, insuredRate);
            Report.WriteLine("I have entered insured values on get quote ltl page");
            qltl.ClickViewRates();            
        }
                
        [When(@"I am on Add Shipment page (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*)")]
        public void WhenIAmOnAddShipmentPage(string oName, string oAdd, string dName, string dAdd, string classification, string nmfc, string quantity, string weight, string desc)
        {
            SendKeys(attributeName_id, ShippingFrom_LocationName_Id, oName);
            Report.WriteLine("I have entered origin name");
            SendKeys(attributeName_id, ShippingFrom_LocationAddressLine1_Id, oAdd);
            Report.WriteLine("I have entered origin address");
            SendKeys(attributeName_id, ShippingTo_LocationName_Id, dName);
            Report.WriteLine("I have entered destination name");
            SendKeys(attributeName_id, ShippingTo_LocationAddressLine1_Id, dAdd);
            Report.WriteLine("I have entered destination address");
            MoveToElement(attributeName_xpath, FreightDesp_SectionText_xpath);            
            ltl.AddShipmentFreightDescription(classification, nmfc, quantity, weight, desc);
            Report.WriteLine("I have entered classification, nmfc, quantity, weight and description");
        }
                
        [When(@"I am on Shipment Results page (.*), (.*), (.*), (.*), (.*), (.*)")]
        public void WhenIAmOnShipmentResultsPage(string oName, string oAdd, string dName, string dAdd, string nmfc, string desc)
        {
            
            //Thread.Sleep(100000);
            string quotenumber = Gettext(attributeName_id, QC_RequestNumber_id);
            Click(attributeName_id, LTL_QC_BackToQuoteListButton_Id);
            //Thread.Sleep(10000);
            Click(attributeName_xpath, ".//*[@id='searchbox']");
            SendKeys(attributeName_xpath, ".//*[@id='searchbox']", quotenumber);
            Click(attributeName_xpath, ".//*[@id='QuotesGrid']//tr/td[9]/button");
            Thread.Sleep(10000);
            try
            {
                Click(attributeName_xpath, ".//*[@id='btn-CreateShipment']");
                Thread.Sleep(10000);
            }
            catch
            {
                Thread.Sleep(10000);
            }            
            SendKeys(attributeName_id, ShippingFrom_LocationName_Id, oName);
            Report.WriteLine("I have entered origin name");
            SendKeys(attributeName_id, ShippingFrom_LocationAddressLine1_Id, oAdd);
            Report.WriteLine("I have entered origin address");
            SendKeys(attributeName_id, ShippingTo_LocationName_Id, dName);
            Report.WriteLine("I have entered destination name");
            SendKeys(attributeName_id, ShippingTo_LocationAddressLine1_Id, dAdd);
            Report.WriteLine("I have entered destination address");
            MoveToElement(attributeName_xpath, FreightDesp_SectionText_xpath);
            SendKeys(attributeName_id, FreightDesp_FirstItem_NMFC_Id, nmfc);
            Report.WriteLine("I have entered nmfc");
            SendKeys(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id, desc);
            Report.WriteLine("I have entered description");
            ltl.ClickViewRates();            
        }
        
        [Then(@"Insured shipment Cost, Create Insured Shipment option will not be displayed")]
        public void ThenInsuredShipmentCostCreateInsuredShipmentOptionWillNotBeDisplayed()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Thread.Sleep(10000);
            int carrierCountUI = GetCount(attributeName_xpath, ShipResults_CarrierColumnValues_Xpath);
            if (carrierCountUI >= 1)
            {
                for (int i = 1; i < carrierCountUI; i++)
                {
                    string carrierName = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']//tr[" + i + "]/td[1]/div/div");
                    bool excludedCarrierDB = DBHelper.IsInsuredCarrierExcluded(carrierName);
                    if (excludedCarrierDB == true)
                    {
                        Report.WriteLine("Insured Shipment Cost option  will not be displayed for excluded carrier from Insurance All Risk pricing");                        
                        VerifyElementNotPresent(attributeName_xpath, ".//*[@id='ShipmentResultTable']//tr[" + i + "]/td[6]/div[@class='totalInsuredRate']", "insuredcost");                        
                        Report.WriteLine("Create Insured Shipment will not be displayed for excluded carriers from Insurance All Risk pricing");
                        VerifyElementNotPresent(attributeName_xpath, ".//*[@id='ShipmentResultTable']//tr[" + i + "]/td[6]/div/button", "createinsuredshipment");
                    }
                }
            }
        }
        
        [Then(@"I am displaying with (.*) in the insured rate column for the excluded carriers")]
        public void ThenIAmDisplayingWithInTheInsuredRateColumnForTheExcludedCarriers(string text)
        {
            int carrierCountUI = GetCount(attributeName_xpath, ShipResults_CarrierColumnValues_Xpath);
            if (carrierCountUI >= 1)
            {
                for (int i = 1; i < carrierCountUI; i++)
                {
                    string carrierName = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']//tr[" + i + "]/td[1]/div/div");
                    bool excludedCarrierDB = DBHelper.IsInsuredCarrierExcluded(carrierName);
                    if (excludedCarrierDB == true)
                    {                        
                        VerifyElementVisible(attributeName_xpath, ".//*[@id='ShipmentResultTable']//tr[" + i + "]/td[6]/div/p", text);
                        Report.WriteLine("I will be displayed with No insured pricing for this carrier text for excluded carrier");
                    }
                }
            }
        }
        
        [Then(@"I am displaying with (.*) in the insured rate column for the excluded carriers in guaranteed grid")]
        public void ThenIAmDisplayingWithInTheInsuredRateColumnForTheExcludedCarriersInGuaranteedGrid(string text)
        {
            int guaranteedCarrierCountUI = GetCount(attributeName_xpath, ShipResults_GuaranteedCarriercolValues_Xpath);
            if (guaranteedCarrierCountUI >= 1)
            {
                for (int i = 1; i < guaranteedCarrierCountUI; i++)
                {
                    string carrierName = Gettext(attributeName_xpath, ".//*[@id='GuaranteedResultTable']//tr[" + i + "]/td[1]/div/div[1]");
                    bool excludedCarrierDB = DBHelper.IsInsuredCarrierExcluded(carrierName);
                    if (excludedCarrierDB == true)
                    {
                        VerifyElementPresent(attributeName_xpath, ".//*[@id='GuaranteedResultTable']//tr[" + i + "]/td[6]/div/p", text);
                        Report.WriteLine("I will be displayed with No insured pricing for this carrier text for excluded carrier");
                    }
                }
            }
        }
    }
}
