using System;
using System.Collections.Generic;
using System.Linq;
using CRM.UITest.CommonMethods;
using CRM.UITest.Helper.Implementations;
using CRM.UITest.Helper.ViewModel;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Results
{
    [Binding]
    public class ShipmentResults_AddGuaranteedRateChargeToEstCostSteps : AddShipments
    {
        private string SelectedGuaranteedCarrierName = string.Empty;
        public WebElementOperations objWebElementOperations = new WebElementOperations();
        List<RateResultCarrierViewModel> rateResults = new List<RateResultCarrierViewModel>();

        [When(@"I arrive on the Shipment Results page and scroll the page for Guaranteed Rates Section")]
        public void WhenIArriveOnTheShipmentResultsPageAndScrollThePageForGuaranteedRatesSection()
        {
            Report.WriteLine("Scroll page for the Guaranteed Rate Section");
            scrollElementIntoView(attributeName_xpath, ShipResults_GuaranteedColumnHeader_CARRIER_Xpath);
        }

        [Given(@"I arrive on the Shipment Results page and scroll the page for Guaranteed Rates Section")]
        public void GivenIArriveOnTheShipmentResultsPageAndScrollThePageForGuaranteedRatesSection()
        {
            Report.WriteLine("Scroll page for the Guaranteed Rate Section");
            scrollElementIntoView(attributeName_xpath, ShipResults_GuaranteedColumnHeader_CARRIER_Xpath);
        }
        
        [Given(@"I enter data in add LTL Shipment Information page (.*), (.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*) and Click on View rates button")]
        public void GivenIEnterDataInAddLTLShipmentInformationPageAndClickOnViewRatesButton(string Usertype,
          string CustomerName,
          string originName,
          string originAddr1,
          string originCity,
          string originState,
          string originZipcode,
          string destinationName,
          string destinationAddr1,
          string destinationCity,
          string destinationState,
          string destinationZipcode,
          string Classification,
          string nmfc,
          string quantity,
          string weight,
          string itemdesc)
        {
            AddShipmentLTL ltl = new AddShipmentLTL();
            ltl.NaviagteToShipmentList();
            GlobalVariables.webDriver.WaitForPageLoad();

            ltl.SelectCustomerFromShipmentList(Usertype, CustomerName);
            GlobalVariables.webDriver.WaitForPageLoad();

            ltl.AddShipmentOriginData(originName, originAddr1, originZipcode);
            ltl.AddShipmentDestinationData(destinationName, destinationAddr1, destinationZipcode);

            scrollElementIntoView(attributeName_xpath, FreightDesp_First_AdditionalItem_Button_xpath);

            Click(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            ltl.AddShipmentFreightDescription(Classification, nmfc, quantity, weight, itemdesc);

            //Click on View rates button
            Report.WriteLine("Clicking on view rate results button");
            scrollElementIntoView(attributeName_xpath, ViewRatesButton_xpath);
            try
            {
                Click(attributeName_xpath, ViewRatesButton_xpath);
                GlobalVariables.webDriver.WaitForPageLoad();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                GlobalVariables.webDriver.WaitForPageLoad();
            }

            //Build rateRequest model
            rateResults = GetRatesAndCarriersUsingAPI.CallRateRequestApi(CustomerName, "LTL", originCity, originZipcode, originState, "USA", destinationCity, destinationZipcode, destinationState,
                "USA", Classification, Convert.ToDouble(quantity), "SKD", Convert.ToDouble(weight), "LBS", string.Empty,true);

            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I select a guaranteed carrier rate on the Shipment Results page")]
        public void GivenISelectAGuaranteedCarrierRateOnTheShipmentResultsPage()
        {
            //Get guaranteed carrier Names
            IList<IWebElement> guaranteedCarrierNamesUI = GlobalVariables.webDriver.FindElements(By.XPath(ShipResults_GuaranteedCarrier_CarrierNameColumns_Xpath));
            List<string> guaranteedCarrierNames = objWebElementOperations.GetListFromIWebElement(guaranteedCarrierNamesUI);
            guaranteedCarrierNames = guaranteedCarrierNames.Select(m => { return m.Split(new string[] { "\r", "\r\n" }, StringSplitOptions.None)[0]; }).ToList();

            if (guaranteedCarrierNames.Count() >= 1)
            {
                IList<IWebElement> guaranteedEstCostValuesUI = GlobalVariables.webDriver.FindElements(By.XPath(ShipResults_GuaranteedCarrier_ESTCOSTColumns_Xpath));
                List<string> guaranteedEstCostValues = objWebElementOperations.GetListFromIWebElement(guaranteedEstCostValuesUI);
                guaranteedEstCostValues = guaranteedEstCostValues.Select(m => { return m.Split(new string[] { "\r", "\r\n" }, StringSplitOptions.None)[0]; }).ToList();

                int rowfindNA = guaranteedEstCostValues.Count();
                bool carrierWithEstCostExists = false;

                for (int i = 1; i < rowfindNA + 1; i++)
                {
                    if (!guaranteedEstCostValues[i].Contains("N/A"))
                    {
                        // Set the selected guaranteed carrier name
                        SelectedGuaranteedCarrierName = guaranteedCarrierNames[i - 1];
                        string guaranteedCarrierSelectionXpath = ".//*[@id='GuaranteedResultTable']/tbody/tr[" + i + "]//*[@id='createShipment']";
                        Click(attributeName_xpath, guaranteedCarrierSelectionXpath);
                        carrierWithEstCostExists = true;
                        break;
                    }
                }

                if (!carrierWithEstCostExists)
                {
                    Report.WriteLine("No Guaranteed carriers with Estimated cost found on Results Page");
                }
            }
            else
            {
                Report.WriteLine("No Guaranteed carriers found on Results Page");
            }
        }

        [Then(@"I will see the guaranteed rate charge applied to the Est Cost total for any carrier displaying a guaranteed rate in Guaranteed carriers section")]
        public void ThenIWillSeeTheGuaranteedRateChargeAppliedToTheEstCostTotalForAnyCarrierDisplayingAGuaranteedRateInGuaranteedCarriersSection()
        {
            //get guaranteed Est cost elements
            IList<IWebElement> guaranteedEstCostValuesUI = GlobalVariables.webDriver.FindElements(By.XPath(ShipResults_GuaranteedCarrier_ESTCOSTColumns_Xpath));
            List<string> guaranteedEstCostValues = objWebElementOperations.GetListFromIWebElement(guaranteedEstCostValuesUI);
            guaranteedEstCostValues = guaranteedEstCostValues.Select(m => { return m.Split(new string[] { "\r", "\r\n" }, StringSplitOptions.None)[0]; }).ToList();

            //Get guaranteed carrier names,scac
            IList<IWebElement> guaranteedCarrierNamesUI = GlobalVariables.webDriver.FindElements(By.XPath(ShipResults_GuaranteedCarrier_CarrierNameColumns_Xpath));
            List<string> guaranteedCarrierNames = objWebElementOperations.GetListFromIWebElement(guaranteedCarrierNamesUI);
            guaranteedCarrierNames = guaranteedCarrierNames.Select(m => { return m.Split(new string[] { "\r", "\r\n" }, StringSplitOptions.None)[0]; }).ToList();

            for (int i = 0; i < guaranteedEstCostValuesUI.Count; i++)
            {
                RateResultCarrierViewModel guaranteedCarrier = rateResults.Where(m => (m.CarrierName.ToLower() == guaranteedCarrierNames[i].ToLower() && m.IsGuaranteedCarrier && m.IsGuaranteedCarrierPrice)).FirstOrDefault();
                RateResultCarrierViewModel stdCarrier = rateResults.Where(m => (m.CarrierName.ToLower() == guaranteedCarrierNames[i].ToLower() && m.IsGuaranteedCarrier)).FirstOrDefault();

                if (stdCarrier != null && stdCarrier.EstCharges != null && stdCarrier.EstCharges.Any())
                {
                    decimal totalCost = stdCarrier.Charges[0].TotalCost;

                    //calculate guaranteedRate
                    decimal guaranteedRate = GetGuaranteedRate(totalCost, Convert.ToDecimal(guaranteedCarrier.MarkupPercentage), Convert.ToDecimal(guaranteedCarrier.MinAmountCharge));
                    decimal guaranteedCarrierEstCost = stdCarrier.EstCharges[0].TotalCost + guaranteedRate;

                    //Verify guaranteed rate charge applied to the Est Cost total 
                    Report.WriteLine("Verify guaranteed rate charge is applied to the Est Cost total for carrier: " + guaranteedCarrier.CarrierName);
                    Assert.AreEqual("$" + (guaranteedCarrierEstCost).ToString("0.00"), guaranteedEstCostValues[i]);
                }
            }
        }

        [Then(@"The guaranteed charge will be applied to the rate details as an accessorial\.")]
        public void ThenTheGuaranteedChargeWillBeAppliedToTheRateDetailsAsAnAccessorial_()
        {
            //get guaranteed Accessorial elements
            IList<IWebElement> guaranteedAccessorialValuesUI = GlobalVariables.webDriver.FindElements(By.XPath(ShipResults_GuaranteedCarrier_ESTCOSTColumns_Xpath));
            List<string> guaranteedAccessorialValues = objWebElementOperations.GetListFromIWebElement(guaranteedAccessorialValuesUI);
            guaranteedAccessorialValues = guaranteedAccessorialValues.Select(m =>
            {
                string[] estValues = m.Split(new string[] { "\r", "\r\n" }, StringSplitOptions.None);
                if (estValues.Count() > 2)
                {
                    return estValues[3]?.Replace("Accessorials:", string.Empty)?.Trim();
                }
                return null;
            }).Distinct().ToList();

            //Get guaranteed carrier names,scac
            IList<IWebElement> guaranteedCarrierNamesUI = GlobalVariables.webDriver.FindElements(By.XPath(ShipResults_GuaranteedCarrier_CarrierNameColumns_Xpath));
            List<string> guaranteedCarrierNames = objWebElementOperations.GetListFromIWebElement(guaranteedCarrierNamesUI);
            guaranteedCarrierNames = guaranteedCarrierNames.Select(m => { return m.Split(new string[] { "\r", "\r\n" }, StringSplitOptions.None)[0]; }).ToList();

            for (int i = 0; i < guaranteedAccessorialValues.Count; i++)
            {
                RateResultCarrierViewModel guaranteedCarrier = rateResults.Where(m => (m.CarrierName.ToLower() == guaranteedCarrierNames[i].ToLower() && m.IsGuaranteedCarrier && m.IsGuaranteedCarrierPrice)).FirstOrDefault();
                RateResultCarrierViewModel stdCarrier = rateResults.Where(m => (m.CarrierName.ToLower() == guaranteedCarrierNames[i].ToLower() && m.IsGuaranteedCarrier)).FirstOrDefault();
                if (stdCarrier != null && stdCarrier.EstCharges != null && stdCarrier.EstCharges.Any())
                {
                    decimal totalCost = stdCarrier.Charges[0].TotalCost;

                    //calculate guaranteedRate
                    decimal guaranteedRate = GetGuaranteedRate(totalCost, Convert.ToDecimal(guaranteedCarrier.MarkupPercentage), Convert.ToDecimal(guaranteedCarrier.MinAmountCharge));
                    decimal guaranteedCarrierAccessorial = stdCarrier.EstCharges[0].Assessorial + guaranteedRate;
                   
                    //Verify guaranteed rate charge applied to the Accessorial Cost  
                    Report.WriteLine("Verify guaranteed rate charge is applied to the Accessorial Cost for carrier: " + guaranteedCarrier.CarrierName);
                    Assert.AreEqual("$" + (guaranteedCarrierAccessorial).ToString("0.00"), guaranteedAccessorialValues[i]);
                }
            }
        }

        [Then(@"I will see the guaranteed rate charge applied to the Est Cost total in Review and submit page")]
        public void ThenIWillSeeTheGuaranteedRateChargeAppliedToTheEstCostTotalInReviewAndSubmitPage()
        {
            RateResultCarrierViewModel guaranteedCarrier = rateResults.Where(m => (m.CarrierName.ToLower() == SelectedGuaranteedCarrierName.ToLower() && m.IsGuaranteedCarrier && m.IsGuaranteedCarrierPrice)).FirstOrDefault();
            RateResultCarrierViewModel stdCarrier = rateResults.Where(m => (m.CarrierName.ToLower() == SelectedGuaranteedCarrierName.ToLower() && m.IsGuaranteedCarrier)).FirstOrDefault();

            //Get guaranteedEstCost from UI
            string estCost = Gettext(attributeName_xpath, ReviewSubmit_CarrierInfo_EstCost_Value_Xpath);

            //Get guaranteedCarrierAccessorial from UI
            string accessorialCharge = Gettext(attributeName_xpath, ReviewSubmit_CarrierInfo_EstCost_AccessorialsValue_Xpath);

            if (stdCarrier != null && stdCarrier.EstCharges != null && stdCarrier.EstCharges.Any())
            {
                decimal totalCost = stdCarrier.Charges[0].TotalCost;

                //Calculate GuaranteedRate for selected carrier
                decimal guaranteedRate = GetGuaranteedRate(totalCost, Convert.ToDecimal(guaranteedCarrier.MarkupPercentage), Convert.ToDecimal(guaranteedCarrier.MinAmountCharge));
                decimal guaranteedCarrierAccessorial = stdCarrier.EstCharges[0].Assessorial + guaranteedRate;
                decimal guaranteedCarrierEstCost = stdCarrier.EstCharges[0].TotalCost + guaranteedRate;

                //Verify  GuaranteedRate charge is added to EstCost in Review and Submit Page     
                Report.WriteLine("Verification that GuaranteedRate charge is added to EstCost in Review and Submit Page");
                Assert.AreEqual("$" + (guaranteedCarrierEstCost).ToString("0.00"), estCost);

                //Verify  GuaranteedRate charge is added to Accessorial in Review and Submit Page     
                Report.WriteLine("Verification that GuaranteedRate charge is added to Accessorial in Review and Submit Page");
                Assert.AreEqual("$" + (guaranteedCarrierAccessorial).ToString("0.00"), accessorialCharge);
            }
        }

        private static decimal GetGuaranteedRate(decimal totalCost, decimal percentage, decimal minCharge)
        {
            decimal guaranteeRate = (percentage / 100) * (totalCost);
            guaranteeRate = guaranteeRate >= minCharge ? guaranteeRate : minCharge;
            decimal totalGuaranteeRate = Math.Round(Convert.ToDecimal(guaranteeRate), 2);

            return totalGuaranteeRate;
        }
    }
}
