using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;

namespace CRM.UITest
{
    [Binding]
    public class Shipments_RatingLogicAppliedWhenMultipleMGDescriptionsExistSteps : AddShipments
    {
        string dimensionValue = "9";
        string insuredValue = "1234.50";
        string mode = "Shipment";
        string customerName = "ZZZ - GS Customer Test";
        string service = "LTL";
        string originCity = "Miami";
        string originZip = "33126";
        string originState = "FL";
        string originCountry = "USA";
        string destinationCity = "Tempe";
        string destinationZip = "85282";
        string destinationState = "AZ";
        string destinationCountry = "USA";
        string classification = "50";
        double quantity = 6;
        string quantityUnit = "SKD";
        double weight = 300;
        string weightUnit = "LBS";
        string username = "Shipment";
        string accessorialValue = null;
        string userType = "Internal";
        decimal Total = 0;                
        AddShipmentLTL getShipmentLTL = new AddShipmentLTL();
        List<IndividualAccessorialModel> accessorialapirespone = new List<IndividualAccessorialModel>();
        WebElementOperations objWebElementOperations = new WebElementOperations();
        List<string> carrierNames = null;
        List<string> mgDescriptionFromDB = null;
        RatingCalculation rc = new RatingCalculation();
        List<IndividualAccessorialModel> standardCarriers = null;
        decimal calculatedValues;

        [Given(@"I am submitting a Shipment request for LTL service type")]
        public void GivenIAmSubmittingAShipmentRequestForLTLServiceType()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ShipmentIcon_Id);
            Click(attributeName_xpath, AllCustomerDropdown_Selection_Internal_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, AllCustomerDroppdownValues_Internal_Xpath, customerName);
            Click(attributeName_id, AddShipmentButtionInternal_Id);
            Click(attributeName_id, AddShipmentLTL_Button_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ShippingFrom_ClearAddress_Id);
            getShipmentLTL.AddShipmentOriginData("OName", "OAddress", originZip);
            scrollPageup();
            Click(attributeName_id, ShippingTo_ClearAddress_Id);
            getShipmentLTL.AddShipmentDestinationData("DName", "DAddress", destinationZip);
            Report.WriteLine("I am on Add Shipment(LTL) page and passed zip codes");
        }

        [Given(@"I selected an accessorial for the Shipment with (.*)")]
        public void GivenISelectedAnAccessorialForTheShipmentWith(string mgDescription)
        {            
            accessorialValue = mgDescription;
            DefineTimeOut(3000);            
            getShipmentLTL.selectShippingToServices(mgDescription);
            Click(attributeName_id, LTL_OriginZipPostal_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            scrollpagedown();
            Click(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            getShipmentLTL.AddShipmentFreightDescription(classification, "NMFC1", quantity.ToString(), weight.ToString(), "descriptions");
                       
            SendKeys(attributeName_id, LTL_Length_Id, dimensionValue);
            SendKeys(attributeName_id, LTL_Width_Id, dimensionValue);
            SendKeys(attributeName_id, LTL_Height_Id, dimensionValue);            
            SendKeys(attributeName_id, LTL_EnterInsuredValue_Id, insuredValue);
        }

        [Given(@"the CRM Rating Logic is selected Yes for the customer for Shipment")]
        public void GivenTheCRMRatingLogicIsSelectedYesForTheCustomerForShipment()
        {            
            bool iSCrmRatingLogicGainshareCustomer = DBHelper.CheckNewCrmRatingLogic(customerName);
            if (iSCrmRatingLogicGainshareCustomer)
            {
                Report.WriteLine("Selected Customer is assigned with CRM Rating Logic Yes");
            }
            else
            {
                Report.WriteFailure("Selected Customer is assigned with CRM Rating Logic Yes");
            }
        }

        [When(@"I submit the request for Shipment")]
        public void WhenISubmitTheRequestForShipment()
        {
            Report.WriteLine("I submit the request for Shipment");
            scrollpagedown();
            try
            {
                Click(attributeName_xpath, Shipment_viewresults_Xpath);
            }
            catch
            {
                GlobalVariables.webDriver.WaitForPageLoad();
            }
        }

        [When(@"CRM receives one of the MG Descriptions of the selected accessorial for Shipment")]
        public void WhenCRMReceivesOneOfTheMGDescriptionsOfTheSelectedAccessorialForShipment()
        {
            Report.WriteLine("CRM receives one of the MG Descriptions of the selected accessorial");
            mgDescriptionFromDB = DBHelper.GetAccessorialMGDescriptions(accessorialValue);
        }

        [Then(@"the Individual Accessorial Charge will be applied to all carrier rates for Shipment")]
        public void ThenTheIndividualAccessorialChargeWillBeAppliedToAllCarrierRatesForShipment()
        {
            Report.WriteLine("the Individual Accessorial Charge will be applied to all carrier rates for shipment");                       
            scrollElementIntoView(attributeName_id, "ShipmentResultTable");
            IList<IWebElement> standardCarrierNamesUI = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='ShipmentResultTable']/tbody/tr/td[1]"));
            carrierNames = objWebElementOperations.GetListFromIWebElement(standardCarrierNamesUI);
            carrierNames = carrierNames.Select(m => { return m.Split(new string[] { "\r", "\r\n" }, StringSplitOptions.None)[0]; }).ToList();

            accessorialapirespone = GetRatesAndCarriersAPICall.BuildIndividualAccessorialModelFromCarrierPriceSheet(customerName,
            service, originCity, originZip, originState, originCountry, destinationCity, destinationZip, destinationState, destinationCountry,
            accessorialValue, accessorialValue, classification, quantity, quantityUnit, weight, weightUnit, username, false);

            for (int i = 0; i < standardCarrierNamesUI.Count; i++)
            {
                standardCarriers = accessorialapirespone.Where(m => (m.carrierName.ToLower() == carrierNames[i].ToLower())).ToList();
                for (int j = 0; j < standardCarriers.Count; j++)
                {
                    string scacCode = standardCarriers[j].CarrierScac;
                    if (standardCarriers != null && standardCarriers[j].carrierName != null)
                    {
                        if (mgDescriptionFromDB.Contains(standardCarriers[j].discription))
                        {
                            calculatedValues = rc.CRMRatingLogicWithMGDescription(mode, customerName, service, originCity, originZip, originState, originCountry,
                                destinationCity, destinationZip, destinationState, destinationCountry, classification, quantity, quantityUnit,
                                weight, weightUnit, username, accessorialValue, accessorialValue, standardCarriers[j].carrierName, scacCode);
                                                        
                            decimal standardTotalCost = Decimal.Parse(calculatedValues.ToString());                            

                            //Verifying standard CRM total cost with UI
                            int k = i + 1;
                            string standardCRMRatingLogicTotalCostUI = null;
                            if (userType == "External")
                            {
                                standardCRMRatingLogicTotalCostUI = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + k + "]/td[4]/div[1]");
                            }
                            else
                            {
                                standardCRMRatingLogicTotalCostUI = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + k + "]/td[5]/div[1]");
                            }
                            string[] actualStandardTotalcostUI = standardCRMRatingLogicTotalCostUI.Split(' ');
                            standardCRMRatingLogicTotalCostUI = actualStandardTotalcostUI[0];
                                                        
                            string calculatedStandardTotalCost = "$" + Math.Round(standardTotalCost, 2);
                            Assert.AreEqual(standardCRMRatingLogicTotalCostUI, calculatedStandardTotalCost);
                            Report.WriteLine("UI Rate " + standardCRMRatingLogicTotalCostUI + "API Calculated Rate " + calculatedStandardTotalCost + "matching for the Carrier");
                        }
                    }
                }
            }
        }

        [Then(@"the Individual Accessorial Charge will be applied to the carrier rate for Shipment")]
        public void ThenTheIndividualAccessorialChargeWillBeAppliedToTheCarrierRateForShipment()
        {
            Report.WriteLine("the Individual Accessorial Charge will be applied to the carrier rate for shipment");                  
            scrollElementIntoView(attributeName_id, "ShipmentResultTable");
            IList<IWebElement> standardCarrierNamesUI = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='ShipmentResultTable']/tbody/tr/td[1]"));
            carrierNames = objWebElementOperations.GetListFromIWebElement(standardCarrierNamesUI);
            carrierNames = carrierNames.Select(m => { return m.Split(new string[] { "\r", "\r\n" }, StringSplitOptions.None)[0]; }).ToList();

            accessorialapirespone = GetRatesAndCarriersAPICall.BuildIndividualAccessorialModelFromCarrierPriceSheet(customerName,
            service, originCity, originZip, originState, originCountry, destinationCity, destinationZip, destinationState, destinationCountry,
            accessorialValue, accessorialValue, classification, quantity, quantityUnit, weight, weightUnit, username, false);

            for (int i = 0; i < standardCarrierNamesUI.Count; i++)
            {
                standardCarriers = accessorialapirespone.Where(m => (m.carrierName.ToLower() == carrierNames[i].ToLower())).ToList();
                for (int j = 0; j < standardCarriers.Count; j++)
                {
                    string scacCode = standardCarriers[j].CarrierScac;
                    if (standardCarriers != null && standardCarriers[j].carrierName != null)
                    {
                        if (mgDescriptionFromDB.Contains(standardCarriers[j].discription))
                        {
                            calculatedValues = rc.CRMRatingLogicWithMGDescription(mode, customerName, service, originCity, originZip, originState, originCountry,
                                destinationCity, destinationZip, destinationState, destinationCountry, classification, quantity, quantityUnit,
                                weight, weightUnit, username, accessorialValue, accessorialValue, standardCarriers[j].carrierName, scacCode);

                            decimal standardTotalCost = Decimal.Parse(calculatedValues.ToString());

                            //Verifying standard CRM total cost with UI
                            int k = i + 1;
                            string standardCRMRatingLogicTotalCostUI = null;
                            if (userType == "External")
                            {
                                standardCRMRatingLogicTotalCostUI = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + k + "]/td[4]/div[1]");
                            }
                            else
                            {
                                standardCRMRatingLogicTotalCostUI = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + k + "]/td[5]/div[1]");
                            }
                            string[] actualStandardTotalcostUI = standardCRMRatingLogicTotalCostUI.Split(' ');
                            standardCRMRatingLogicTotalCostUI = actualStandardTotalcostUI[0];

                            string calculatedStandardTotalCost = "$" + Math.Round(standardTotalCost, 2);
                            Assert.AreEqual(standardCRMRatingLogicTotalCostUI, calculatedStandardTotalCost);
                            Report.WriteLine("UI Rate " + standardCRMRatingLogicTotalCostUI + "API Calculated Rate " + calculatedStandardTotalCost + "matching for the Carrier");
                        }
                    }
                }
            }
        }

        [Then(@"the Individual Accessorial Charge will not be applied to all carrier rates for Shipment")]
        public void ThenTheIndividualAccessorialChargeWillNotBeAppliedToAllCarrierRatesForShipment()
        {
            Report.WriteLine("the Individual Accessorial Charge will not be applied to all carrier rates for shipment");                    
            scrollElementIntoView(attributeName_id, "ShipmentResultTable");
            IList<IWebElement> standardCarrierNamesUI = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='ShipmentResultTable']/tbody/tr/td[1]"));
            carrierNames = objWebElementOperations.GetListFromIWebElement(standardCarrierNamesUI);
            carrierNames = carrierNames.Select(m => { return m.Split(new string[] { "\r", "\r\n" }, StringSplitOptions.None)[0]; }).ToList();

            accessorialapirespone = GetRatesAndCarriersAPICall.BuildIndividualAccessorialModelFromCarrierPriceSheet(customerName,
            service, originCity, originZip, originState, originCountry, destinationCity, destinationZip, destinationState, destinationCountry,
            accessorialValue, accessorialValue, classification, quantity, quantityUnit, weight, weightUnit, username, false);

            for (int i = 0; i < standardCarrierNamesUI.Count; i++)
            {
                standardCarriers = accessorialapirespone.Where(m => (m.carrierName.ToLower() == carrierNames[i].ToLower())).ToList();
                for (int j = 0; j < standardCarriers.Count; j++)
                {
                    string scacCode = standardCarriers[j].CarrierScac;
                    if (standardCarriers != null && standardCarriers[j].carrierName != null)
                    {
                        if (mgDescriptionFromDB!=null)
                        {
                            calculatedValues = rc.CRMRatingLogicWithMGDescription(mode, customerName, service, originCity, originZip, originState, originCountry,
                                destinationCity, destinationZip, destinationState, destinationCountry, classification, quantity, quantityUnit,
                                weight, weightUnit, username, accessorialValue, accessorialValue, standardCarriers[j].carrierName, scacCode);

                            decimal standardTotalCost = Decimal.Parse(calculatedValues.ToString());
                            
                            //Verifying standard CRM total cost with UI
                            int k = i + 1;
                            string standardCRMRatingLogicTotalCostUI = null;
                            if (userType == "External")
                            {
                                standardCRMRatingLogicTotalCostUI = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + k + "]/td[4]/div[1]");
                            }
                            else
                            {
                                standardCRMRatingLogicTotalCostUI = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + k + "]/td[5]/div[1]");
                            }
                            string[] actualStandardTotalcostUI = standardCRMRatingLogicTotalCostUI.Split(' ');
                            standardCRMRatingLogicTotalCostUI = actualStandardTotalcostUI[0];

                            string calculatedStandardTotalCost = "$" + Math.Round(standardTotalCost, 2);
                            Assert.AreEqual(standardCRMRatingLogicTotalCostUI, calculatedStandardTotalCost);
                            Report.WriteLine("UI Rate " + standardCRMRatingLogicTotalCostUI + "API Calculated Rate " + calculatedStandardTotalCost + "matching for the Carrier");
                        }
                        else
                        {
                            Report.WriteLine("the Individual Accessorial Charge not applied to carrier rates for shipment");
                        }
                    }
                }
            }
        }

        [Then(@"the Individual Accessorial Charge will not be applied to the carrier rate for Shipment")]
        public void ThenTheIndividualAccessorialChargeWillNotBeAppliedToTheCarrierRateForShipment()
        {
            Report.WriteLine("the Individual Accessorial Charge will not be applied to the carrier rate for shipment");                   
            scrollElementIntoView(attributeName_id, "ShipmentResultTable");
            IList<IWebElement> standardCarrierNamesUI = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='ShipmentResultTable']/tbody/tr/td[1]"));
            carrierNames = objWebElementOperations.GetListFromIWebElement(standardCarrierNamesUI);
            carrierNames = carrierNames.Select(m => { return m.Split(new string[] { "\r", "\r\n" }, StringSplitOptions.None)[0]; }).ToList();

            accessorialapirespone = GetRatesAndCarriersAPICall.BuildIndividualAccessorialModelFromCarrierPriceSheet(customerName,
            service, originCity, originZip, originState, originCountry, destinationCity, destinationZip, destinationState, destinationCountry,
            accessorialValue, accessorialValue, classification, quantity, quantityUnit, weight, weightUnit, username, false);

            for (int i = 0; i < standardCarrierNamesUI.Count; i++)
            {
                standardCarriers = accessorialapirespone.Where(m => (m.carrierName.ToLower() == carrierNames[i].ToLower())).ToList();
                for (int j = 0; j < standardCarriers.Count; j++)
                {
                    string scacCode = standardCarriers[j].CarrierScac;
                    if (standardCarriers != null && standardCarriers[j].carrierName != null)
                    {
                        if (mgDescriptionFromDB!=null)
                        {
                            calculatedValues = rc.CRMRatingLogicWithMGDescription(mode, customerName, service, originCity, originZip, originState, originCountry,
                                destinationCity, destinationZip, destinationState, destinationCountry, classification, quantity, quantityUnit,
                                weight, weightUnit, username, accessorialValue, accessorialValue, standardCarriers[j].carrierName, scacCode);

                            decimal standardTotalCost = Decimal.Parse(calculatedValues.ToString());
                            //Verifying standard CRM total cost with UI
                            int k = i + 1;
                            string standardCRMRatingLogicTotalCostUI = null;
                            if (userType == "External")
                            {
                                standardCRMRatingLogicTotalCostUI = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + k + "]/td[4]/div[1]");
                            }
                            else
                            {
                                standardCRMRatingLogicTotalCostUI = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + k + "]/td[5]/div[1]");
                            }
                            string[] actualStandardTotalcostUI = standardCRMRatingLogicTotalCostUI.Split(' ');
                            standardCRMRatingLogicTotalCostUI = actualStandardTotalcostUI[0];
                            string calculatedStandardTotalCost = "$" + Math.Round(standardTotalCost, 2);
                            Assert.AreEqual(standardCRMRatingLogicTotalCostUI, calculatedStandardTotalCost);
                            Report.WriteLine("UI Rate " + standardCRMRatingLogicTotalCostUI + "API Calculated Rate " + calculatedStandardTotalCost + "matching for the Carrier");
                        }
                        else
                        {
                            Report.WriteLine("the Individual Accessorial Charge not applied to carrier rate for shipment");
                        }
                    }
                }
            }
        }
    }
}
