using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;

namespace CRM.UITest.Scripts.Maintenance_Tools.Master_Carrier_Rate_Settings
{
    [Binding]
    public class MasterCarrierRateSettings_ExcludedCarriers_NoRateResultsSteps:AddShipments
    {
        CommonMethodsCrm crm = new CommonMethodsCrm();
        AddShipmentLTL shipmentLtl = new AddShipmentLTL();
        AddQuoteLTL quoteLtl = new AddQuoteLTL();

        [When(@"I am on the Rate Results page (.*), (.*), (.*), (.*), (.*) and (.*)")]
        public void WhenIAmOnTheRateResultsPageAnd(string userType, 
            string customerName, 
            string oZip, 
            string dZip, 
            string classification, 
            string weight)
        {
            //Navigate
            quoteLtl.NaviagteToQuoteList();
            quoteLtl.Add_QuoteLTL(userType, customerName);

            //Enter data in shipping information screen
            Click(attributeName_id, ClearAddress_OriginId);
            Click(attributeName_id, ClearAddress_DestId);
            quoteLtl.EnterOriginZip(oZip);
            quoteLtl.EnterDestinationZip(dZip);
            scrollElementIntoView(attributeName_id, LTL_SavedItemDropdown_Id);
            Click(attributeName_id, LTL_ClearItem_Id);
            quoteLtl.EnterItemdata(classification, weight);
            //Entering insured value
            SendKeys(attributeName_id, LTL_EnterInsuredValue_Id, weight);
            //click on view quote results button
            try
            {
                Click(attributeName_id, LTL_ViewQuoteResults_Id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Thread.Sleep(50000);
            }
        }

        [When(@"I am on the Rate Resultspage (.*), (.*), (.*), (.*), (.*) and (.*)")]
        public void WhenIAmOnTheRateResultspageInternalZZZ_CzarCustomerTestAnd(string userType,
            string customerName,
            string oZip,
            string dZip,
            string classification,
            string weight)
        {
            //Navigate
            quoteLtl.NaviagteToQuoteList();
            quoteLtl.Add_QuoteLTL(userType, customerName);

            //Enter data in shipping information screen
            quoteLtl.EnterOriginZip(oZip);
            quoteLtl.EnterDestinationZip(dZip);
            scrollElementIntoView(attributeName_id, LTL_SavedItemDropdown_Id);
            //Click(attributeName_id, LTL_ClearItem_Id);
            quoteLtl.EnterItemdata(classification, weight);
            //click on view quote results button
            try
            {
                Click(attributeName_id, LTL_ViewQuoteResults_Id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Thread.Sleep(50000);
            }
        }


        [When(@"am on the Shipment results page (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*) and (.*)")]
        public void WhenAmOnTheShipmentResultsPageAnd(string userType, 
            string customerName, 
            string oName, 
            string oAdd1, 
            string oZip, 
            string dName, 
            string dAdd1, 
            string dZip, 
            string classification, 
            string nmfc, 
            string quantity, 
            string weight, 
            string desc)
        {
            //Navigate to Add Shipment page            
            shipmentLtl.NaviagteToShipmentList();
            shipmentLtl.SelectCustomerFromShipmentList(userType, customerName);

            //Enter shipment information
            Click(attributeName_id, ShippingFrom_ClearAddress_Id);
            Click(attributeName_id, ShippingTo_ClearAddress_Id);
            shipmentLtl.AddShipmentOriginData(oName, oAdd1, oZip);
            shipmentLtl.AddShipmentDestinationData(dName, dAdd1, dZip);
            scrollElementIntoView(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            Click(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            shipmentLtl.AddShipmentFreightDescription(classification, nmfc, quantity, weight, desc);
            SendKeys(attributeName_id, InsuredValue_TextBox_Id, quantity); //Entering Insured value

            //added to click on view rate button
            try
            {
                Click(attributeName_xpath, ViewRatesButton_xpath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Thread.Sleep(50000);
            }
        }

        [Then(@"Rate results will not include the carriers that were excluded for the mapped customer (.*)")]
        public void ThenRateResultsWillNotIncludeTheCarriersThatWereExcludedForTheMappedCustomer(string customerName)
        {
            int pricingModelId = DBHelper.GetGainsharePricingId(customerName);
            string excludedCarriers = DBHelper.GetExcludedCarriersforCustomer(pricingModelId);
            string[] excludedCarriersActual = excludedCarriers.Split(',');
            List<string> carriersExcludedDB = new List<string>();

            foreach (string element in excludedCarriersActual)
            {
                carriersExcludedDB.Add(DBHelper.Carriernameforscac(element));                                
            }
                                
            IList<IWebElement> carriersListRate = GlobalVariables.webDriver.FindElements(By.XPath(ltlcarriersall_xpath));
            List<string> carriersExcludedUI = new List<string>();
            foreach (IWebElement element in carriersListRate)
            {
                carriersExcludedUI.Add(element.Text.ToString());
            }

            for (int i=0;i<= carriersExcludedUI.Count;i++)
            {
                if (i <= carriersExcludedDB.Count())
                {
                    if (!carriersExcludedDB.Contains(carriersExcludedUI[i]))
                    {
                        Console.WriteLine("Excluded carriers not displaying in Results Page");
                    }

                    else
                    {
                        throw new System.Exception("Excluded carriers displaying in Results Page");
                    }
                }
                              
            }
            
            Report.WriteLine("Excluded carriers for the selected customer not displaying in Rate Results page");           
        }

        [Then(@"Shipment results will not include the carriers that were excluded for the mapped customer (.*)")]
        public void ThenShipmentResultsWillNotIncludeTheCarriersThatWereExcludedForTheMappedCustomer(string customerName)
        {
            int pricingModelId = DBHelper.GetGainsharePricingId(customerName);
            string excludedCarriers = DBHelper.GetExcludedCarriersforCustomer(pricingModelId);
            string[] excludedCarriersActual = excludedCarriers.Split(',');
            List<string> carriersExcludedDB = new List<string>();

            foreach (string element in excludedCarriersActual)
            {
                carriersExcludedDB.Add(DBHelper.Carriernameforscac(element));
            }

            IList<IWebElement> carriersListShipment = GlobalVariables.webDriver.FindElements(By.XPath(ShipResults_CarrierColumnValues_Xpath));

            List<string> carriersExcludedUI = new List<string>();
            foreach (IWebElement element in carriersListShipment)
            {
                carriersExcludedUI.Add(element.Text.ToString());
            }

            for (int i = 0; i <= carriersExcludedUI.Count; i++)
            {
                if (i <= carriersExcludedDB.Count())
                {
                    if (!carriersExcludedDB.Contains(carriersExcludedUI[i]))
                    {
                        Console.WriteLine("Excluded carriers not displaying in Results Page");
                    }

                    else
                    {
                        throw new System.Exception("Excluded carriers displaying in Results Page");
                    }
                }

            }
            Report.WriteLine("Excluded carriers for the selected customer not displaying in Shipment Results page");
        }
    }
}
