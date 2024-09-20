using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper;
using CRM.UITest.Helper.DataModels;
using CRM.UITest.Helper.Implementations;
using CRM.UITest.Helper.Interfaces;
using CRM.UITest.Helper.ViewModel;
using CRM.UITest.Objects;
using CRM.UITest.Scripts.Quote.LTL.Quote_Results_Screen;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Results
{
    [Binding]
    public class CRM_Rating_Logic_Guaranteed_Rate_Calculation_Shipment_Results : AddShipments
    {
        public WebElementOperations objWebElementOperations = new WebElementOperations();
        ShipResults_CalculateBumpTotal_BTTLSteps bttl = new ShipResults_CalculateBumpTotal_BTTLSteps();
        RatingCalculationMethods ratingCalculation = new RatingCalculationMethods();
        List<string> standardCarrierTotalCost = null;
        List<string> guaranteedCarrierNames = null;
        List<string> guaranteedServiceDays = null;
        List<RateResultCarrierViewModel> apirespone = null;

        //CRM_Rating_Logic_Guaranteed_Rate_Calculation_Shipment_Results guaranteedRates = new CRM_Rating_Logic_Guaranteed_Rate_Calculation_Shipment_Results();
        decimal BMAA = 0;
        decimal BOTFACC = 0;
        List<IndividualAccessorialModel> accessorialapirespone = null;
        List<IndividualAccessorialModel> accessorialModelByCarrier = null;
        decimal BTTL = 0;
        decimal Toootal = 0;

        BumpSurgeCalculationModel bumpSurgeCalculationModel = new BumpSurgeCalculationModel();

        [When(@"I arrive on the Shipment Results \(LTL\) page,")]
        public void WhenIArriveOnTheShipmentResultsLTLPage()
        {
            Report.WriteLine("Verifying shipment results page");
            Verifytext(attributeName_xpath, ".//h1[contains(text(), 'Shipment Results (LTL)')]", "Shipment Results (LTL)");
        }


        [Then(@"the Rate \(customer charge\) will be determined by applying the CRM Rating calculation to the guaranteed rate amount(.*), (.*) ,(.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*),(.*),(.*), (.*), (.*),(.*),(.*) (.*)")]
        public void ThenTheRateCustomerChargeWillBeDeterminedByApplyingTheCRMRatingCalculationToTheGuaranteedRateAmount(string Customer_Name, string Service, string OriginCity, string OriginZip, string OriginState, string OriginCountry, string DestinationCity, string DestinationZip, string DestinationState, string DestinationCountry, string Classification, double Quantity, string QuantityUNIT, double Weight, string WeightUnit, string Username, string usertype)
        {
            Report.WriteLine("Verifying New rating Guaranteed Rate");

            bool iSCrmRatingLogic_GainshareCustomer = DBHelper.CheckNewCrmRatingLogic(Customer_Name);

            if (iSCrmRatingLogic_GainshareCustomer)
            {

                apirespone = GetRatesAndCarriersAPICall.CallRateRequestApi(Customer_Name, Service, OriginCity, OriginZip, OriginState, OriginCountry, DestinationCity, DestinationZip, DestinationState, DestinationCountry, Classification, Quantity, QuantityUNIT, Weight, WeightUnit, Username, false);

                IList<IWebElement> standardCarrierNameUI = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='ShipmentResultTable']/tbody/tr/td[1]"));
                List<string> standardCarrier = objWebElementOperations.GetListFromIWebElement(standardCarrierNameUI);
                standardCarrier = standardCarrier.Select(m => { return m.Split(new string[] { "\r", "\r\n" }, StringSplitOptions.None)[0]; }).ToList();

                if (usertype == "External")
                {
                    IList<IWebElement> standardCarrierTotalCostUI = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='ShipmentResultTable']/tbody/tr/td[4]"));
                    standardCarrierTotalCost = objWebElementOperations.GetListFromIWebElement(standardCarrierTotalCostUI);
                    standardCarrierTotalCost = standardCarrierTotalCost.Select(m => { return m.Split(new string[] { "\r", "\r\n" }, StringSplitOptions.None)[0]; }).ToList();
                }
                else
                {
                    IList<IWebElement> standardCarrierTotalCostUI = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='ShipmentResultTable']/tbody/tr/td[5]"));
                    standardCarrierTotalCost = objWebElementOperations.GetListFromIWebElement(standardCarrierTotalCostUI);
                    standardCarrierTotalCost = standardCarrierTotalCost.Select(m => { return m.Split(new string[] { "\r", "\r\n" }, StringSplitOptions.None)[0]; }).ToList();
                }


                //Get guaranteed carrier names,scac
                scrollElementIntoView(attributeName_id, "GuaranteedResultTable");
                IList<IWebElement> guaranteedCarrierNamesUI = GlobalVariables.webDriver.FindElements(By.XPath(ShipResults_GuaranteedCarrier_CarrierNameColumns_Xpath));
                guaranteedCarrierNames = objWebElementOperations.GetListFromIWebElement(guaranteedCarrierNamesUI);
                guaranteedCarrierNames = guaranteedCarrierNames.Select(m => { return m.Split(new string[] { "\r", "\r\n" }, StringSplitOptions.None)[0]; }).ToList();

                //Get guaranteed service days
                IList<IWebElement> guaranteedServiceDaysUI = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='GuaranteedResultTable']/tbody/tr/td[2]"));
                guaranteedServiceDays = objWebElementOperations.GetListFromIWebElement(guaranteedServiceDaysUI);
                guaranteedServiceDays = guaranteedServiceDays.Select(m => { return m.Split(new string[] { "\r", "\r\n" }, StringSplitOptions.None)[0]; }).ToList();

                //storing UI Values in Model
                List<IndividualAccessorialModel> individualAccessorials = new List<IndividualAccessorialModel>();
                for (int i = 0; i < standardCarrierNameUI.Count; i++)
                {
                    IndividualAccessorialModel individualAccessorial = new IndividualAccessorialModel
                    {
                        carrierName = standardCarrier[i],

                        TotalCost = standardCarrierTotalCost[i],
                    };

                    individualAccessorials.Add(individualAccessorial);
                }

                for (int i = 0; i < guaranteedCarrierNamesUI.Count; i++)
                {
                    RateResultCarrierViewModel guaranteedCarrier = apirespone.Where(m => (m.CarrierName.ToLower() == guaranteedCarrierNames[i].ToLower() && m.IsGuaranteedCarrier && m.IsGuaranteedCarrierPrice)).FirstOrDefault();
                    IndividualAccessorialModel stdCarrier = individualAccessorials.Where(m => (m.carrierName.ToLower() == guaranteedCarrierNames[i].ToLower())).FirstOrDefault();
                    string SCACCode = guaranteedCarrier.ScacCode;
                    double guaranteedDays = guaranteedCarrier.ServiceDays;

                    string GSDays = guaranteedServiceDays[i];
                    double GServicedaysUI = Double.Parse(GSDays);


                    if (stdCarrier != null && stdCarrier.carrierName != null && stdCarrier.TotalCost.Any())
                    {
                        string totalCostSt = stdCarrier.TotalCost;

                        string[] tc = totalCostSt.Split('$');
                        string totalcostst = tc[1];

                        decimal totalCost = Decimal.Parse(totalcostst);

                        //calculate guaranteedRate
                        decimal guaranteedRate = GetGuaranteedRate(totalCost, Convert.ToDecimal(guaranteedCarrier.MarkupPercentage), Convert.ToDecimal(guaranteedCarrier.MinAmountCharge));

                        decimal calguaranteedRate = GetCRMRatingGuranteedRate(Customer_Name, guaranteedRate, SCACCode);

                        //Verifying CRM Rating Logic standard guaranteed with UI
                        decimal guaranteedCarrierTotalCost = totalCost + calguaranteedRate;
                        int j = i + 1;
                        string guaranteedCarrierTotalCost_UI = null;
                        if (usertype == "External")
                        {

                            guaranteedCarrierTotalCost_UI = Gettext(attributeName_xpath, ".//*[@id='GuaranteedResultTable']/tbody/tr[" + j + "]/td[4]/div[1]");
                        }
                        else
                        {
                            guaranteedCarrierTotalCost_UI = Gettext(attributeName_xpath, ".//*[@id='GuaranteedResultTable']/tbody/tr[" + j + "]/td[5]/div[1]");
                        }

                        //Verifying total cost
                        string ActualguaranteedCarrierTotalCost = guaranteedCarrierTotalCost.ToString();
                        string CalculatedGuaranteed_TotalCost = "$" + Math.Round(guaranteedCarrierTotalCost, 2);
                        Assert.AreEqual(guaranteedCarrierTotalCost_UI, CalculatedGuaranteed_TotalCost);

                        //Verifying guaranteed service days
                        Assert.AreEqual(GServicedaysUI, guaranteedDays);
                    }
                }

            }
            else
            {
                Report.WriteLine("Custoemer is not type of gainshare customer");
            }
        }


        [When(@"I arrive on the Shipment Results \(LTL\) page and enter Insured Value (.*)")]
        public void WhenIArriveOnTheShipmentResultsLTLPageAndEnterInsuredValue(string InsuredValue)
        {
            Report.WriteLine("Verifying shipment results page and enter insured value");
            GlobalVariables.webDriver.WaitForPageLoad();

            Verifytext(attributeName_xpath, ".//h1[contains(text(), 'Shipment Results (LTL)')]", "Shipment Results (LTL)");

            SendKeys(attributeName_id, ShipResults_InsuredRateTextbox_Id, InsuredValue);
            Click(attributeName_id, ShipResults_ShowInsuredRateButton_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
        }


        [Then(@"the Rate \(customer charge\) will be determined by applying the CRM Rating calculation to the guaranteed rate amount(.*), (.*) ,(.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*),(.*),(.*), (.*),(.*),(.*),(.*),(.*)")]
        public void ThenTheRateCustomerChargeWillBeDeterminedByApplyingTheCRMRatingCalculationToTheGuaranteedRateAmount(string Customer_Name, string Service, string OriginCity, string OriginZip, string OriginState,
            string OriginCountry, string DestinationCity, string DestinationZip, string DestinationState, string DestinationCountry, string Classification,
            double Quantity, double Weight, string Username, string usertype, string originAccessorials, string destinationAccessorials)
        {
          
            string QuantityUNIT = "skids";
            string WeightUnit = "LBS";
            bool iSCrmRatingLogic_GainshareCustomer = DBHelper.CheckNewCrmRatingLogic(Customer_Name);

            if (iSCrmRatingLogic_GainshareCustomer)
            {
           apirespone = GetRatesAndCarriersAPICall.CallRateRequestApi(Customer_Name, Service, OriginCity, OriginZip, OriginState, OriginCountry, DestinationCity, DestinationZip, DestinationState, DestinationCountry, Classification, Quantity, QuantityUNIT, Weight, WeightUnit, Username, false);
           //apirespone = GetRatesAndCarriersAPICall.CallRateRequestApi_WithInsuredValue(Customer_Name, Service, OriginCity, OriginZip, OriginState, OriginCountry, DestinationCity, DestinationZip, DestinationState, DestinationCountry, Classification, Quantity, QuantityUNIT, Weight, WeightUnit, Username, false,11);



                accessorialapirespone = GetRatesAndCarriersAPICall.BuildIndividualAccessorialModelFromCarrierPriceSheet(Customer_Name,
           Service,
           OriginCity,
           OriginZip,
           OriginState,
           OriginCountry,
           DestinationCity,
           DestinationZip,
           DestinationState,
           DestinationCountry,
           originAccessorials,
           destinationAccessorials,
           Classification,
           Quantity,
           QuantityUNIT,
           Weight,
           WeightUnit,
           Username,
           false);

                //Get guaranteed carrier names,scac
                scrollElementIntoView(attributeName_id, "GuaranteedResultTable");
                IList<IWebElement> guaranteedCarrierNamesUI = GlobalVariables.webDriver.FindElements(By.XPath(ShipResults_GuaranteedCarrier_CarrierNameColumns_Xpath));
                guaranteedCarrierNames = objWebElementOperations.GetListFromIWebElement(guaranteedCarrierNamesUI);
                guaranteedCarrierNames = guaranteedCarrierNames.Select(m => { return m.Split(new string[] { "\r", "\r\n" }, StringSplitOptions.None)[0]; }).ToList();
                //storing UI Values in Model -NOT NEEDED NOW
                List<IndividualAccessorialModel> individualAccessorials = new List<IndividualAccessorialModel>();
                for (int i = 0; i < guaranteedCarrierNamesUI.Count; i++)
                {
                    RateResultCarrierViewModel guaranteedCarrier = apirespone.Where(m => (m.CarrierName.ToLower() == guaranteedCarrierNames[i].ToLower() && m.IsGuaranteedCarrier && m.IsGuaranteedCarrierPrice)).FirstOrDefault();

                    IndividualAccessorialModel StdCarrier = accessorialapirespone.Where(m => (m.carrierName.ToLower() == guaranteedCarrierNames[i].ToLower())).FirstOrDefault();
                    //RateResultCarrierViewModel stdCarrier = apirespone.Where(m => (m.CarrierName.ToLower() == guaranteedCarrierNames[i].ToLower())).FirstOrDefault();
                    string SASCCode = guaranteedCarrier.ScacCode;
             
                    if (guaranteedCarrier != null && guaranteedCarrier.CarrierName != null )
                    {
                        string aPIstdtotalcost = StdCarrier.TotalCost;
                        decimal stdtotalcost = Decimal.Parse(aPIstdtotalcost);

                        //calculate guaranteedRate DB
                        decimal guaranteedRate = GetGuaranteedRate(stdtotalcost, Convert.ToDecimal(guaranteedCarrier.MarkupPercentage), Convert.ToDecimal(guaranteedCarrier.MinAmountCharge));

                        //Calling BMAA method

                        BMAA = GetGuaranteedBMAAValue(Customer_Name, Service, OriginCity, OriginZip, OriginState,
                                                     OriginCountry, DestinationCity, DestinationZip, DestinationState, DestinationCountry, Classification,
                                                     Quantity, QuantityUNIT, Weight, WeightUnit, Username, originAccessorials, destinationAccessorials,
                                                     guaranteedCarrier.CarrierName, guaranteedRate);

                        // Calling Breakoout method

                        MACC=GetMACC(Customer_Name, Service, OriginCity, OriginZip, OriginState,
                                OriginCountry, DestinationCity, DestinationZip, DestinationState, DestinationCountry, originAccessorials, destinationAccessorials,
                                Classification, Quantity, QuantityUNIT, Weight, Username, guaranteedCarrier.CarrierName);

                        BOLH = GetBOLH(guaranteedCarrier.CarrierName, guaranteedRate);
                        bumpSurgeCalculationModel.BreakOutLineHaul = BOLH;

                        BOFSC = GetBOFSC(guaranteedCarrier.CarrierName);
                        bumpSurgeCalculationModel.BreakOutFuel = BOFSC;

                        //GuaranteedRateAccessorial with CRM Rating logic
                        decimal guaranteedRateWithCRMRatingLogic = GetCRMRatingGuranteedRate(Customer_Name, guaranteedRate, SASCCode);

                        BOTFACC =GetBOTFACC(Customer_Name, guaranteedCarrier.CarrierName);
                        bumpSurgeCalculationModel.BreakOutAccessorialsTotal = BOTFACC+ guaranteedRateWithCRMRatingLogic;
                     
                        decimal BOTTL = BOLH + BOFSC + BOTFACC;
                        bumpSurgeCalculationModel.BreakOutTotal = BOTTL;

                        //Verifying CRM Rating Logic standard guaranteed with UI
                        decimal guaranteedCRMLogicBOTFACC = BOTFACC + guaranteedRateWithCRMRatingLogic;
                        decimal guaranteedCRMLogicBOTTL = guaranteedCRMLogicBOTFACC + BOLH + BOFSC;

                        //adding bump and surge
                        BumpSurgeCustomerSetUp setup = DBHelper.GetBumpSurgeDetails(SASCCode, Customer_Name);
                        
                        bumpSurgeCalculationModel.Bump = (setup?.Bump) / 100 ?? 0;
                        bumpSurgeCalculationModel.Surge = (setup?.Surge) / 100 ?? 0;
                        
                        if (bumpSurgeCalculationModel.Bump > 0 || bumpSurgeCalculationModel.Surge > 0)
                        {
                            SurgeAndBumpCaluclationsClass _surgeAndBumpCaluclationsClass = new SurgeAndBumpCaluclationsClass();
                            FinalBumpSurgeCalculationModel finalModel = _surgeAndBumpCaluclationsClass.SurgeBumpCaluclation(bumpSurgeCalculationModel);
                            BTTL = finalModel.Total;
                            Toootal = finalModel.Total;
                        }

                        else
                        {
                            Toootal = guaranteedCRMLogicBOTTL;
                        }

                        //Vrirying guaranteed CRM total cost with UI
                        int j = i + 1;
                        string guaranteedCRMRatingLogicTotalCost_UI = null;
                        if (usertype == "External")
                        {

                            guaranteedCRMRatingLogicTotalCost_UI = Gettext(attributeName_xpath, ".//*[@id='GuaranteedResultTable']/tbody/tr[" + j + "]/td[4]/div[1]");
                        }
                        else
                        {
                            guaranteedCRMRatingLogicTotalCost_UI = Gettext(attributeName_xpath, ".//*[@id='GuaranteedResultTable']/tbody/tr[" + j + "]/td[5]/div[1]");
                        }
                        //string ActualguaranteedCarrierTotalCost = guaranteedCRMLogicBOTFACC.ToString();
                        string CalculatedGuaranteedCRMRatingLogic_TotalCost = "$" + Math.Round(Toootal, 2);
                        Assert.AreEqual(guaranteedCRMRatingLogicTotalCost_UI, CalculatedGuaranteedCRMRatingLogic_TotalCost);
                    }
                   
                }
                
            }
            else
            {
                Report.WriteLine("Customer is not type of gainshare customer");
            }
        
        }



        //Insured GuaranteedCRMRatingLogic Calcuation 

        decimal shipmentCoverageValue = 0;
        decimal insuredGuaranteedCRMRatingLogicRate = 0;


        [Then(@"the Rate \(customer charge\) will be determined by applying the CRM Rating calculation to the Insured guaranteed rate amount(.*), (.*) ,(.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*),(.*),(.*), (.*),(.*),(.*),(.*),(.*),(.*)")]
        public void ThenTheRateCustomerChargeWillBeDeterminedByApplyingTheCRMRatingCalculationToTheInsuredGuaranteedRateAmount(string Customer_Name, string Service, string OriginCity, string OriginZip, string OriginState,
            string OriginCountry, string DestinationCity, string DestinationZip, string DestinationState, string DestinationCountry, string Classification,
            double Quantity, double Weight, string Username, string usertype, string originAccessorials, string destinationAccessorials, double insuredValue)
        {

            string QuantityUNIT = "skids";
            string WeightUnit = "LBS";
            bool iSCrmRatingLogic_GainshareCustomer = DBHelper.CheckNewCrmRatingLogic(Customer_Name);

            if (iSCrmRatingLogic_GainshareCustomer)
            {
                apirespone = GetRatesAndCarriersAPICall.CallRateRequestApi(Customer_Name, Service, OriginCity, OriginZip, OriginState, OriginCountry, DestinationCity, DestinationZip, DestinationState, DestinationCountry, Classification, Quantity, QuantityUNIT, Weight, WeightUnit, Username, false);
                //apirespone = GetRatesAndCarriersAPICall.CallRateRequestApi_WithInsuredValue(Customer_Name, Service, OriginCity, OriginZip, OriginState, OriginCountry, DestinationCity, DestinationZip, DestinationState, DestinationCountry, Classification, Quantity, QuantityUNIT, Weight, WeightUnit, Username, false,11);



                accessorialapirespone = GetRatesAndCarriersAPICall.BuildIndividualAccessorialModelFromCarrierPriceSheet(Customer_Name,
           Service,
           OriginCity,
           OriginZip,
           OriginState,
           OriginCountry,
           DestinationCity,
           DestinationZip,
           DestinationState,
           DestinationCountry,
           originAccessorials,
           destinationAccessorials,
           Classification,
           Quantity,
           QuantityUNIT,
           Weight,
           WeightUnit,
           Username,
           false);

                //Get guaranteed carrier names,scac
                scrollElementIntoView(attributeName_id, "GuaranteedResultTable");
                IList<IWebElement> guaranteedCarrierNamesUI = GlobalVariables.webDriver.FindElements(By.XPath(ShipResults_GuaranteedCarrier_CarrierNameColumns_Xpath));
                guaranteedCarrierNames = objWebElementOperations.GetListFromIWebElement(guaranteedCarrierNamesUI);
                guaranteedCarrierNames = guaranteedCarrierNames.Select(m => { return m.Split(new string[] { "\r", "\r\n" }, StringSplitOptions.None)[0]; }).ToList();


                //storing UI Values in Model -NOT NEEDED NOW
                List<IndividualAccessorialModel> individualAccessorials = new List<IndividualAccessorialModel>();


                for (int i = 0; i < guaranteedCarrierNamesUI.Count; i++)
                {
                    RateResultCarrierViewModel guaranteedCarrier = apirespone.Where(m => (m.CarrierName.ToLower() == guaranteedCarrierNames[i].ToLower() && m.IsGuaranteedCarrier && m.IsGuaranteedCarrierPrice)).FirstOrDefault();

                    IndividualAccessorialModel StdCarrier = accessorialapirespone.Where(m => (m.carrierName.ToLower() == guaranteedCarrierNames[i].ToLower())).FirstOrDefault();
                    //RateResultCarrierViewModel stdCarrier = apirespone.Where(m => (m.CarrierName.ToLower() == guaranteedCarrierNames[i].ToLower())).FirstOrDefault();
                    string SASCCode = guaranteedCarrier.ScacCode;


                    if (guaranteedCarrier != null && guaranteedCarrier.CarrierName != null)
                    {
                        string aPIstdtotalcost = StdCarrier.TotalCost;
                        decimal stdtotalcost = Decimal.Parse(aPIstdtotalcost);

                        //calculate guaranteedRate DB
                        decimal guaranteedRate = GetGuaranteedRate(stdtotalcost, Convert.ToDecimal(guaranteedCarrier.MarkupPercentage), Convert.ToDecimal(guaranteedCarrier.MinAmountCharge));

                        //Calling BMAA method

                        BMAA = GetGuaranteedBMAAValue(Customer_Name, Service, OriginCity, OriginZip, OriginState,
                                                     OriginCountry, DestinationCity, DestinationZip, DestinationState, DestinationCountry, Classification,
                                                     Quantity, QuantityUNIT, Weight, WeightUnit, Username, originAccessorials, destinationAccessorials,
                                                     guaranteedCarrier.CarrierName, guaranteedRate);

                        // Calling Breakoout method

                        MACC = GetMACC(Customer_Name, Service, OriginCity, OriginZip, OriginState,
                                OriginCountry, DestinationCity, DestinationZip, DestinationState, DestinationCountry, originAccessorials, destinationAccessorials,
                                Classification, Quantity, QuantityUNIT, Weight, Username, guaranteedCarrier.CarrierName);

                        BOLH = GetBOLH(guaranteedCarrier.CarrierName, guaranteedRate);
                        bumpSurgeCalculationModel.BreakOutLineHaul = BOLH;



                        BOFSC = GetBOFSC(guaranteedCarrier.CarrierName);
                        bumpSurgeCalculationModel.BreakOutFuel = BOFSC;

                        //GuaranteedRateAccessorial with CRM Rating logic
                        decimal guaranteedRateWithCRMRatingLogic = GetCRMRatingGuranteedRate(Customer_Name, guaranteedRate, SASCCode);



                        BOTFACC = GetBOTFACC(Customer_Name, guaranteedCarrier.CarrierName);
                        bumpSurgeCalculationModel.BreakOutAccessorialsTotal = BOTFACC + guaranteedRateWithCRMRatingLogic;


                        decimal BOTTL = BOLH + BOFSC + BOTFACC;
                        bumpSurgeCalculationModel.BreakOutTotal = BOTTL;



                        //Verifying CRM Rating Logic standard guaranteed with UI
                        decimal guaranteedCRMLogicBOTFACC = BOTFACC + guaranteedRateWithCRMRatingLogic;
                        decimal guaranteedCRMLogicBOTTL = guaranteedCRMLogicBOTFACC + BOLH + BOFSC;

                        //adding bump and surge
                        BumpSurgeCustomerSetUp setup = DBHelper.GetBumpSurgeDetails(SASCCode, Customer_Name);

                        bumpSurgeCalculationModel.Bump = (setup?.Bump) / 100 ?? 0;
                        bumpSurgeCalculationModel.Surge = (setup?.Surge) / 100 ?? 0;


                        if (bumpSurgeCalculationModel.Bump > 0 || bumpSurgeCalculationModel.Surge > 0)
                        {
                            SurgeAndBumpCaluclationsClass _surgeAndBumpCaluclationsClass = new SurgeAndBumpCaluclationsClass();
                            FinalBumpSurgeCalculationModel finalModel = _surgeAndBumpCaluclationsClass.SurgeBumpCaluclation(bumpSurgeCalculationModel);
                            BTTL = finalModel.Total;
                            Toootal = finalModel.Total;
                        }

                        else
                        {
                            Toootal = guaranteedCRMLogicBOTTL;
                        }



                        //Makeing DB call to verify the customer Type
                        bool isDefaultInsAll = DBHelper.DefaultInsuredRates(Customer_Name);

                        if (isDefaultInsAll)
                        {
                            shipmentCoverageValue = DefaultInsAllCalculation(insuredValue, Customer_Name);
                        }
                        else
                        {
                            shipmentCoverageValue = NonDefaultInsAllCalculation(insuredValue);
                        }

                        insuredGuaranteedCRMRatingLogicRate = shipmentCoverageValue + Toootal;

                        //Vrirying guaranteed CRM total cost with UI
                        int j = i + 1;
                        string guaranteedInsuredCRMRatingTotalCost_UI = null;
                        if (usertype == "External")
                        {

                            guaranteedInsuredCRMRatingTotalCost_UI = Gettext(attributeName_xpath, ".//*[@id='GuaranteedResultTable']/tbody/tr[" + j + "]/td[5]/div[1]");
                        }
                        else
                        {
                            guaranteedInsuredCRMRatingTotalCost_UI = Gettext(attributeName_xpath, ".//*[@id='GuaranteedResultTable']/tbody/tr[" + j + "]/td[6]/div[1]");
                        }
                        //string ActualguaranteedCarrierTotalCost = guaranteedCRMLogicBOTFACC.ToString();
                        string CalculatedGuaranteedCRMRatingInsured_TotalCost = "$" + Math.Round(insuredGuaranteedCRMRatingLogicRate, 2);
                        Assert.AreEqual(guaranteedInsuredCRMRatingTotalCost_UI, CalculatedGuaranteedCRMRatingInsured_TotalCost);

                    }
                }
            }
        }

       
       
        GetShipementCoverageForDefaultInsAllRisk _getShipementCoverageForDefaultInsAllRisk = new GetShipementCoverageForDefaultInsAllRisk();
        public decimal DefaultInsAllCalculation(double shipmentValueInsure, string customerName)
        {
            IGetDefaultInsAllRiskDetails _getDefaultInsAllRiskDetails = new GetDefaultInsAllRiskDetails();
            IGetInsAllRiskParameters _getInsAllRiskParameters = new GetInsAllRiskParameters(_getDefaultInsAllRiskDetails);
            //decimal shipmentCoverage = 0;
            int setUpId = DBHelper.GetCustomerSetupId(customerName);
            int customerAccountId = DBHelper.GetCustomerAccountId(setUpId);

            InsAllRiskViewModel insuranceAllRiskModel = DBHelper.GetCustomerInsuranceAllRisk(customerAccountId);

            CustomerSpecificInsAllRiskDetailsViewModel customerSpecificInsAllRiskDetailsViewModel = (insuranceAllRiskModel.CustomerSpecificInsAllRisk?.Count > 0
               && insuranceAllRiskModel.CustomerSpecificInsAllRisk[0]?.CustomerSpecificInsAllRiskDetails?.Count > 0)
               ? insuranceAllRiskModel.CustomerSpecificInsAllRisk?[0]?.CustomerSpecificInsAllRiskDetails[0] : null;

               InsAllRiskModel insAllRiskModel = _getInsAllRiskParameters.GetInsAllRiskCalculationParameters(customerSpecificInsAllRiskDetailsViewModel);
            bool isValidInsAllParameters = (insAllRiskModel?.MinimumCost == 0 && (insAllRiskModel?.MaximumCost == null || insAllRiskModel?.MaximumCost == 0));

            if (!isValidInsAllParameters)
            {
                shipmentCoverageValue = _getShipementCoverageForDefaultInsAllRisk.GetShipmentCoverageValue(insAllRiskModel, shipmentValueInsure);
            }

            return shipmentCoverageValue;


        }

        public decimal NonDefaultInsAllCalculation(double insuredValue)
        {
            decimal insAllCost = 0;
            if (insuredValue <= 500)
            {
                insAllCost = Convert.ToDecimal("8.00");
            }
            else if (insuredValue <= 750)
            {
                insAllCost = Convert.ToDecimal("11.00");
            }
            else if (insuredValue <= 1000)
            {
                insAllCost = Convert.ToDecimal("11.20");
            }
            else if (insuredValue <= 1500)
            {
                insAllCost = Convert.ToDecimal("14.25");
            }
            else if (insuredValue <= 2000)
            {
                insAllCost = Convert.ToDecimal("19.00");
            }
            else if (insuredValue <= 2500)
            {
                insAllCost = Convert.ToDecimal("23.75");
            }
            else if (insuredValue <= 3000)
            {
                insAllCost = Convert.ToDecimal("28.50");
            }
            else if (insuredValue <= 5000)
            {
                insAllCost = Convert.ToDecimal("37.50");
            }
            else if (insuredValue <= 7000)
            {
                insAllCost = Convert.ToDecimal("45.50");
            }
            else if (insuredValue <= 10000)
            {
                insAllCost = Convert.ToDecimal("65.00");
            }
            else if (insuredValue <= 15000)
            {
                insAllCost = Convert.ToDecimal("90.00");
            }
            else if (insuredValue <= 20000)
            {
                insAllCost = Convert.ToDecimal("110.00");
            }
            else if (insuredValue <= 25000)
            {
                insAllCost = Convert.ToDecimal("137.50");
            }
            else if (insuredValue <= 30000)
            {
                insAllCost = Convert.ToDecimal("150.00");
            }
            else if (insuredValue > 30000)
            {
                insAllCost = Convert.ToDecimal("150.00");
            }

            return insAllCost;
        }


        public decimal GetGuaranteedRate(decimal totalCost, decimal percentage, decimal minCharge)
        {
            decimal guaranteeRate = (percentage / 100) * (totalCost);
            guaranteeRate = guaranteeRate >= minCharge ? guaranteeRate : minCharge;
            decimal totalGuaranteeRate = Math.Round(Convert.ToDecimal(guaranteeRate), 2);
            return totalGuaranteeRate;
        }


        public decimal GetCRMRatingGuranteedRate(string CustomerName, decimal guaranteedRateAccessrial, string SASCCode)
        {
            decimal MACC = 0;


            int setUpId = DBHelper.GetCustomerSetupId(CustomerName);
            int accId = DBHelper.GetCustomerAccountId(setUpId);
            CRM.UITest.Entities.Proxy.GainsharePricingModel custValues = new CRM.UITest.Entities.Proxy.GainsharePricingModel();
            custValues = DBHelper.GetGainsharePricingDataByAID(accId);

            int pricingmodelid = custValues.GainsharePricingModelId;
            GainShareScacCode carrierValues = DBHelper.GetCarrierSpecificScacCode(pricingmodelid, SASCCode);

            if (carrierValues == null)
            {
                MACC = custValues.MasterAccessorialCharge;
            }
            else
            {

                //Taking MACC value from carrier table
                MACC = carrierValues.MasterAccessorialCharge;
            }

            decimal GuaranteedRateWithCRMRatingLogic = guaranteedRateAccessrial * (1 + (MACC / 100));
            return GuaranteedRateWithCRMRatingLogic;

        }


        //################################################## Get BMAA value ##################################################



        public decimal GetGuaranteedBMAAValue(string CustomerName, string Service, string OriginCity, string OriginZip, string OriginState,
            string OriginCountry, string DestinationCity, string DestinationZip, string DestinationState, string DestinationCountry, string Classification,
            double Quantity, string QuantityUNIT, double Weight, string WeightUnit, string Username, string originAccessorials, string destinationAccessorials, string guaranteedCarrierName, decimal guaranteedAccessorial)
        {
            RatingCalculationMethods cal = new RatingCalculationMethods();



            int setUpId = DBHelper.GetCustomerSetupId(CustomerName);
            int accId = DBHelper.GetCustomerAccountId(setUpId);


            CRM.UITest.Entities.Proxy.GainsharePricingModel custValues = new CRM.UITest.Entities.Proxy.GainsharePricingModel();
            custValues = DBHelper.GetGainsharePricingDataByAID(accId);

            int pricingmodelid = custValues.GainsharePricingModelId;
            decimal custMin = custValues.Minimum;
            decimal custMinAmt = Convert.ToDecimal(custValues.MinAmountAdded);
            decimal custMinThreshold = Convert.ToDecimal(custValues.MinThresholdCharge);
            decimal custGainshare = Convert.ToDecimal(custValues.Percentage);
            decimal custMasterAcc = custValues.MasterAccessorialCharge;



         
            List<string> carrierNames = accessorialapirespone.Select(p => p.carrierName).ToList();

            decimal totalAccessorial = 0;
            //Thread.Sleep(1000);
            for (int i = 0; i < carrierNames.Count; i++)
            {
                if (accessorialapirespone[i].carrierName == guaranteedCarrierName && accessorialapirespone[i].chargeType.Equals("ACCESSORIAL_FUEL"))
                {
                    string type = accessorialapirespone[i].chargeType;
                    string linehaul = accessorialapirespone[i].TotalLineHaul;
                    decimal lh = Decimal.Parse(linehaul);
                    decimal fuelSurcharge = Convert.ToDecimal(accessorialapirespone[i].amount);
                    bool accType = accessorialapirespone[i].IsAccessorial;
                    totalAccessorial = Convert.ToDecimal(accessorialapirespone[i].accessorialsTotal);
                    totalAccessorial = +guaranteedAccessorial;//adding guaranteed accessorial
                    decimal totalCost = Convert.ToDecimal(accessorialapirespone[i].TotalCost);
                    string scaccode = accessorialapirespone[i].CarrierScac;
                    GainShareScacCode carrierValues = DBHelper.GetCarrierSpecificScacCode(pricingmodelid, scaccode);


                    {
                        if (carrierValues != null)
                        {
                            decimal carrierMin = carrierValues.Minimum;
                            decimal carrierMinAmt = Convert.ToDecimal(carrierValues.CarrierSpecificMinimumAmount);
                            decimal carrierMinThreshold = Convert.ToDecimal(carrierValues.CarrierSpecificMinimumThreshold);
                            decimal carrierGainshare = Convert.ToDecimal(carrierValues.GainsharePercentage);
                            double cgs = Convert.ToDouble(carrierValues.GainsharePercentage);
                            decimal carrierMasterAcc = carrierValues.MasterAccessorialCharge;

                            decimal LHBFSC = cal.LHBFSC_LinehaulBeforeFuelSurcharge(type, carrierMin, carrierGainshare, lh);
                            decimal BMSBTL = cal.BMSBTL_BaseMarkupSubTotal(fuelSurcharge, LHBFSC);
                            decimal BM = cal.BM_BaseMarkup(accType, BMSBTL, totalAccessorial, carrierMasterAcc);
                            decimal BMAT = cal.BMAT_BaseMarkupAfterThreshold(BM, carrierMinThreshold);
                            decimal BMATC = cal.BMATC_BaseMarkupAfterThresholdCalculation(BMAT, totalCost);
                            BMAA = cal.BMAA_BaseMarkupMinimumAmount(BMATC, BMAT, totalCost, carrierMinAmt);

                        }
                        else
                        {

                            decimal LHBFSC = cal.LHBFSC_LinehaulBeforeFuelSurcharge(type, custMin, custGainshare, lh);
                            decimal BMSBTL = cal.BMSBTL_BaseMarkupSubTotal(fuelSurcharge, LHBFSC);
                            decimal BM = cal.BM_BaseMarkup(accType, BMSBTL, totalAccessorial, custMasterAcc);
                            decimal BMAT = cal.BMAT_BaseMarkupAfterThreshold(BM, custMinThreshold);
                            decimal BMATC = cal.BMATC_BaseMarkupAfterThresholdCalculation(BMAT, totalCost);
                            BMAA = cal.BMAA_BaseMarkupMinimumAmount(BMATC, BMAT, totalCost, custMinAmt);
                        }


                    }
                    break;
                }

            }


            return BMAA;

        }


        //############################################## BOLH and BOFSC calculation #############################################
        decimal MACC = 0; //Db call
        decimal IACC = 0;
        public decimal GetMACC(string CustomerName, string Service, string OriginCity, string OriginZip, string OriginState,
            string OriginCountry, string DestinationCity, string DestinationZip, string DestinationState, string DestinationCountry, string OAccessorial, string DAccessorial,
            string Classification, Double Quantity, string QuantityUNIT, Double Weight, string Username, string guaranteedCarrierName)
        {
           
            int CODPresent_XML = 0;
            string CARSCAC_COde = null;//CNWY


            for (int i = 0; i < accessorialapirespone.Count; i++)
            {

                if (accessorialapirespone[i].carrierName == guaranteedCarrierName)//XPO
                {


                    string individualAccAmountDiscription = accessorialapirespone[i].chargeType;

                    if (individualAccAmountDiscription.Equals("ACCESSORIAL") && accessorialapirespone[i].carrierName == guaranteedCarrierName)
                    {

                        CODPresent_XML += 1;
                        CARSCAC_COde = accessorialapirespone[i].CarrierScac;
                    }
                   
                }
            }



            //MACC value from Carrier
            if (CARSCAC_COde != null)
            {
                //carrierScacCode = scacCodeCarrier.CarrierCode;
                int setUpId = DBHelper.GetCustomerSetupId(CustomerName);
                int accId = DBHelper.GetCustomerAccountId(setUpId);
                CRM.UITest.Entities.Proxy.GainsharePricingModel custValues = new CRM.UITest.Entities.Proxy.GainsharePricingModel();
                custValues = DBHelper.GetGainsharePricingDataByAID(accId);

                int pricingmodelid = custValues.GainsharePricingModelId;
                //GainShareScacCode carrierValues = DBHelper.GetCarrierSpecificScacCode(pricingmodelid, carrierScacCode);
                GainShareScacCode carrierValues = DBHelper.GetCarrierSpecificScacCode(pricingmodelid, CARSCAC_COde);

                if (carrierValues == null)
                {
                    MACC = custValues.MasterAccessorialCharge;
                }
                else
                {

                    //Taking MACC value from carrier table
                    MACC = carrierValues.MasterAccessorialCharge;
                }

            }
            else
            {
                //MACC value from Customer
                //CustomerName = "gainsharetestswa1";
                int setUpId = DBHelper.GetCustomerSetupId(CustomerName);
                int accId = DBHelper.GetCustomerAccountId(setUpId);

                // //customer based values from DB
                CRM.UITest.Entities.Proxy.GainsharePricingModel custValues = new CRM.UITest.Entities.Proxy.GainsharePricingModel();
                custValues = DBHelper.GetGainsharePricingDataByAID(accId);

                int pricingmodelid = custValues.GainsharePricingModelId;
                MACC = custValues.MasterAccessorialCharge;


            }
            return MACC;
        }



        decimal AACC = 0;//API call 
        decimal BOLH = 0;
        decimal BOFSC = 0;
        
        public decimal GetBOLH(string guaranteedCarrierName, decimal guaranteedAccessorial)
        {
            for (int i = 0; i < accessorialapirespone.Count; i++)
            {
                if (accessorialapirespone[i].carrierName == guaranteedCarrierName)
                {
                    AACC = Decimal.Parse(accessorialapirespone[i].accessorialsTotal);//adding guaranteed accessorial
                    AACC = +guaranteedAccessorial;


                    string dis = accessorialapirespone[i].discription;

                    if (dis.Contains("Fuel"))
                    {
                        string amount = accessorialapirespone[i].amount;
                        decimal FSCAmount = Decimal.Parse(amount);
                        BOLH = ratingCalculation.BOLH_BaseMarkupMinimumAmount(BMAA, AACC, MACC, FSCAmount);//136.61
                                                                                                           //break;
                    }

                }
            }
            return BOLH;

        }


        public decimal GetBOFSC(string guaranteedCarrierName)
        {
            //decimal bOLH = GetBOLH(guaranteedCarrierName, guaranteedAccessorial);
            for (int i = 0; i < accessorialapirespone.Count; i++)
            {
                if (accessorialapirespone[i].carrierName == guaranteedCarrierName)
                {
     

                    string dis = accessorialapirespone[i].discription;

                    if (dis.Contains("Fuel"))
                    {
                      
                        string amount = accessorialapirespone[i].amount;
                        decimal FSCAmount = Decimal.Parse(amount);
                        BOFSC = ratingCalculation.BOFSC_BaseMarkupMinimumAmount(BOLH, FSCAmount);
                    }
                   
                }
            }
            return BOFSC;

        }

        decimal BOIFACC = 0;
        decimal IACC_Override = 0;

        public decimal GetBOTFACC(string customerName, string guaranteedCarrierName)
        {
            for (int i = 0; i < accessorialapirespone.Count; i++)
            {
                if (accessorialapirespone[i].carrierName == guaranteedCarrierName)
                {
                    //AACC = Decimal.Parse(accessorialapirespone[i].accessorialsTotal);
                    //AACC = +23;

                    int CODPresent_XML = 0;
                    string CARSCAC_COdeB = null;//CNWY

                    //for (int j = 0; j < accessorialapirespone.Count; j++)//2
                    //{

                        //string individualAccAmountDiscription = rlist[i].discription;
                        string individualAccAmountDiscription = accessorialapirespone[i].chargeType;

                        if (individualAccAmountDiscription.Equals("ACCESSORIAL") && accessorialapirespone[i].carrierName == guaranteedCarrierName)
                        {

                            CODPresent_XML += 1;
                            CARSCAC_COdeB = accessorialapirespone[i].CarrierScac;
                        }
                   // }


                    
                    AccessorialSetUp GettheAssCode = null;





                    //for (int k = 0; k < accessorialapirespone.Count; k++)//2
                    //{
                       
                        string CARSCAC = CARSCAC_COdeB;
                        
                        accessorialModelByCarrier = DBHelper.CarrierAcc(customerName, CARSCAC);

                       
                        if (accessorialapirespone[i].chargeType.Equals("ACCESSORIAL") && accessorialapirespone[i].carrierName == guaranteedCarrierName)
                        {
                            GettheAssCode = DBHelper.AccessorialNameToCodeUsingMgDescription(accessorialapirespone[i].discription);
                            
                            // string j=GettheAssCode.AccessorialCode;

                            decimal? IACC1 = accessorialModelByCarrier?.Where(a => a.AccessorialCode == (GettheAssCode.AccessorialCode))?.Select(a => a?.AccessorialValue).FirstOrDefault();

                            if (IACC1 == null)
                            {
                                accessorialModelByCarrier = DBHelper.CustAccessor(customerName);
                                // IACC1 = accessorialModelByCarrier?.Where(a => a?.AccessorialCode == "COD")?.Select(a => a?.AccessorialValue).FirstOrDefault();
                                IACC1 = accessorialModelByCarrier?.Where(a => a.AccessorialCode == GettheAssCode.AccessorialCode)?.Select(a => a?.AccessorialValue).FirstOrDefault();

                                if (IACC1 == null)
                                {
                                    //string individualAccAmountDiscription = accessorialapirespone[i].chargeType;

                                    if (individualAccAmountDiscription.Equals("ACCESSORIAL"))
                                    {
                                        string amount = accessorialapirespone[i].amount;
                                        IACC_Override = Decimal.Parse(amount);
                                        BOIFACC = IACC_Override * (1 + (MACC / 100));
                                       

                                    }
                                }
                                else
                                {
                                    BOIFACC += (decimal)IACC1;
                                   
                                }

                            }
                            else
                            {
                                BOIFACC += (decimal)IACC1;
                             
                            }
                        }
                    //}
                   

                }
                
            }
            return BOIFACC;
        }
    }
}

        

