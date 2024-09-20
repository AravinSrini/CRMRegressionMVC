using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper;
using CRM.UITest.Helper.DataModels;
using CRM.UITest.Helper.ViewModel;
using CRM.UITest.Helper.ViewModel.Shipment;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Results
{
    [Binding]
    public class ShipResults_CalculateBumpFuelSurcharge_BFSCSteps : AddShipments
    {
        AddShipmentLTL data = new AddShipmentLTL();
        List<IndividualAccessorialModel> rlist = null;
        RatingCalculationMethods rateCal = new RatingCalculationMethods();
        public BumpSurgeCalculationModel bumpSurgeCalculationModel = new BumpSurgeCalculationModel();        
        public ShipmentInformationModel _ShipmentInformationModel = new ShipmentInformationModel();
        decimal BOFSC = 0;
        decimal BFSC = 0;
        decimal BOTFACC = 0;
        decimal BOLH = 0;
        decimal BOTTL = 0;
        string firstCarrierval = null;
        decimal fuelSurcharge = 0;

        [When(@"I am passing the required information (.*), (.*), (.*)")]
        public void WhenIAmPassingTheRequiredInformation(string Username, string CustomerName, string Usertype)
        {
            _ShipmentInformationModel.CustomerName = CustomerName;
            _ShipmentInformationModel.Username = Username;
            _ShipmentInformationModel.Usertype = Usertype;
            data.NaviagteToShipmentList();
            data.SelectCustomerFromShipmentList(Usertype, CustomerName);


        }

        [When(@"I am passing ShipFrom Information (.*), (.*), (.*), (.*), (.*), (.*)")]
        public void WhenIAmPassingShipFromInformation(string oZip, string oCity, string oState, string oName, string oAdd, string oServices)
        {
            _ShipmentInformationModel.oZip = oZip;
            _ShipmentInformationModel.oCity = oCity;
            _ShipmentInformationModel.oState = oState;
            _ShipmentInformationModel.oName = oName;
            _ShipmentInformationModel.oAdd = oAdd;
            _ShipmentInformationModel.oServices = oServices;
            Click(attributeName_id, ShippingFrom_ClearAddress_Id);
            data.AddShipmentOriginData(oName, oAdd, oZip);
            data.selectShippingfromServices(oServices);

        }

        [When(@"I am passing ShipTo information (.*), (.*), (.*), (.*), (.*), (.*)")]
        public void WhenIAmPassingShipToInformation(string dZip, string dCity, string dState, string dName, string dAdd, string dServices)
        {
            _ShipmentInformationModel.dZip = dZip;
            _ShipmentInformationModel.dCity = dCity;
            _ShipmentInformationModel.dState = dState;
            _ShipmentInformationModel.dName = dName;
            _ShipmentInformationModel.dAdd = dAdd;
            _ShipmentInformationModel.dServices = dServices;
            data.AddShipmentDestinationData(dName, dAdd, dZip);
            data.selectShippingToServices(dServices);
            Thread.Sleep(5000);
        }

        [When(@"I am passing Classification information and i arrive on shipement result page for BFSC (.*), (.*), (.*), (.*), (.*), (.*)")]
        public decimal WhenIAmPassingClassificationInformationAndIArriveOnShipementResultPageForBFSC(string classification, string nmfc, string quantity, string weight, string desc, string CalculationType)
        {
            _ShipmentInformationModel.classification = classification;
            _ShipmentInformationModel.nmfc = nmfc;
            _ShipmentInformationModel.quantity = quantity;
            _ShipmentInformationModel.weight = weight;
            _ShipmentInformationModel.desc = desc;
            scrollElementIntoView(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            Click(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            data.AddShipmentFreightDescription(classification, nmfc, quantity, weight, desc);
            data.ClickViewRates();
            CommonCalculations_LHBFC_BMSBTL_BM_BMAT_BMATC_BMMASteps steps = new CommonCalculations_LHBFC_BMSBTL_BM_BMAT_BMATC_BMMASteps();
            decimal BMAA = steps.ThenBMAAShouldBeCalculated("Shipment", _ShipmentInformationModel.CustomerName, "LTL", _ShipmentInformationModel.oCity, _ShipmentInformationModel.oZip, _ShipmentInformationModel.oState, "USA", _ShipmentInformationModel.dCity,
                _ShipmentInformationModel.dZip, _ShipmentInformationModel.dState, "USA", _ShipmentInformationModel.classification, Convert.ToDouble(quantity), "skids", Convert.ToDouble(weight), "LBS", _ShipmentInformationModel.Username, _ShipmentInformationModel.oServices, _ShipmentInformationModel.dServices);
            BaseMarkupBreakDownCalcuation step = new BaseMarkupBreakDownCalcuation();
            BOFSC = step.calculateBaseMarkDownCharges(_ShipmentInformationModel.CustomerName, "service", _ShipmentInformationModel.oCity,
                _ShipmentInformationModel.oZip, _ShipmentInformationModel.oState, "USA",
                _ShipmentInformationModel.dCity, _ShipmentInformationModel.dZip, _ShipmentInformationModel.dState, "USA",
                _ShipmentInformationModel.oServices, _ShipmentInformationModel.dServices, classification, Convert.ToDouble(quantity), "skids",
                Convert.ToDouble(weight), "Shipment",
                _ShipmentInformationModel.Username, _ShipmentInformationModel.Usertype, "BOFSC");
            bumpSurgeCalculationModel.BreakOutFuel = BOFSC;

            BaseMarkupBreakDownCalcuation step1 = new BaseMarkupBreakDownCalcuation();
             BOLH = step1.calculateBaseMarkDownCharges(_ShipmentInformationModel.CustomerName, "service", _ShipmentInformationModel.oCity, _ShipmentInformationModel.oZip, _ShipmentInformationModel.oState, "USA",
                _ShipmentInformationModel.dCity, _ShipmentInformationModel.dZip, _ShipmentInformationModel.dState, "USA", _ShipmentInformationModel.oServices, _ShipmentInformationModel.dServices, classification, Convert.ToDouble(quantity), "skids", Convert.ToDouble(weight), "Shipment",
                _ShipmentInformationModel.Username, _ShipmentInformationModel.Usertype, "BOLH");
            bumpSurgeCalculationModel.BreakOutLineHaul = BOLH;
            //BaseMarkupBreakDownCalcuation step2 = new BaseMarkupBreakDownCalcuation();
             BOTFACC = step1.calculateBaseMarkDownCharges(_ShipmentInformationModel.CustomerName, "service", _ShipmentInformationModel.oCity, _ShipmentInformationModel.oZip, _ShipmentInformationModel.oState, "USA",
                _ShipmentInformationModel.dCity, _ShipmentInformationModel.dZip, _ShipmentInformationModel.dState, "USA", _ShipmentInformationModel.oServices, _ShipmentInformationModel.dServices, classification, Convert.ToDouble(quantity), "skids", Convert.ToDouble(weight), "Shipment",
                _ShipmentInformationModel.Username, _ShipmentInformationModel.Usertype, "BOTFACC");
            bumpSurgeCalculationModel.BreakOutAccessorialsTotal = BOTFACC;
            //BaseMarkupBreakDownCalcuation step3 = new BaseMarkupBreakDownCalcuation();
            decimal BOACC = step1.calculateBaseMarkDownCharges(_ShipmentInformationModel.CustomerName, "service", _ShipmentInformationModel.oCity, _ShipmentInformationModel.oZip, _ShipmentInformationModel.oState, "USA",
                _ShipmentInformationModel.dCity, _ShipmentInformationModel.dZip, _ShipmentInformationModel.dState, "USA", _ShipmentInformationModel.oServices, _ShipmentInformationModel.dServices, classification, Convert.ToDouble(quantity), "skids", Convert.ToDouble(weight), "Shipment",
                _ShipmentInformationModel.Username, _ShipmentInformationModel.Usertype, "BOACC");

             BOTTL = step1.calculateBaseMarkDownCharges(_ShipmentInformationModel.CustomerName, "service", _ShipmentInformationModel.oCity, _ShipmentInformationModel.oZip, _ShipmentInformationModel.oState, "USA",
               _ShipmentInformationModel.dCity, _ShipmentInformationModel.dZip, _ShipmentInformationModel.dState, "USA", _ShipmentInformationModel.oServices, _ShipmentInformationModel.dServices, classification, Convert.ToDouble(quantity), "skids", Convert.ToDouble(weight), "Shipment",
               _ShipmentInformationModel.Username, _ShipmentInformationModel.Usertype, "BOTTL");
            bumpSurgeCalculationModel.BreakOutTotal = BOTTL;
            return BOTTL;
        }


        [Then(@"BFSC should be calculated for shipment when bump is available and surge is not available (.*),(.*)")]
        public decimal ThenBFSCShouldBeCalculatedForShipmentWhenBumpIsAvailableAndSurgeIsNotAvailable(string CustomerName, string userType)
        {
            List<IndividualAccessorialModel> apirespone = GetRatesAndCarriersAPICall.BuildIndividualAccessorialModelFromCarrierPriceSheet("ZZZ - GS Customer Test",
                "service", "Miami", "33126", "FL", "USA", "Tempe", "85282", "AZ", "USA", "Appointment", "COD", "50", Convert.ToDouble("2"), "skids",
                Convert.ToDouble("3"), "LBS", "both", false);
            firstCarrierval = Gettext(attributeName_xpath, ShipResults_FC_CarrierName_Xpath);
            List<string> carrierNames = apirespone.Select(p => p.carrierName).ToList();
            for (int i = 0; i < carrierNames.Count; i++)
            {
                if (apirespone[i].carrierName == firstCarrierval)
                {
                    fuelSurcharge = Convert.ToDecimal(apirespone[i].amount);
                    bumpSurgeCalculationModel.FuelSurgeCharge = fuelSurcharge;
                }
            }

            string firstCarrier = null;

            rlist = GetRatesAndCarriersAPICall.BuildIndividualAccessorialModelFromCarrierPriceSheet(CustomerName, "service", _ShipmentInformationModel.oCity, _ShipmentInformationModel.oZip, _ShipmentInformationModel.oState, "USA", _ShipmentInformationModel.dCity,
                _ShipmentInformationModel.dZip, _ShipmentInformationModel.dState, "USA", _ShipmentInformationModel.oServices, _ShipmentInformationModel.dServices, 
                _ShipmentInformationModel.classification, Convert.ToDouble(_ShipmentInformationModel.quantity), "skids", Convert.ToDouble(_ShipmentInformationModel.weight),
                "LBS", _ShipmentInformationModel.Username, false);


            firstCarrier = Gettext(attributeName_xpath, ShipResults_FC_CarrierName_Xpath);

            int carriercount = 0;
            for (int j = 0; j < rlist.Count; j++)
            {

                if (rlist[j].carrierName == firstCarrier)//XPO
                {
                    carriercount += 1;
                }
            }

            string CARSCAC_COde = null;//CNWY

            for (int i = 0; i < rlist.Count; i++)//2
            {
                if (rlist[i].carrierName == firstCarrier)//XPO
                {
                    CARSCAC_COde = rlist[i].CarrierScac;
                }
            }

     
            BumpSurgeCustomerSetUp setup = DBHelper.GetBumpSurgeDetails(CARSCAC_COde, CustomerName);
            bumpSurgeCalculationModel.Bump = (setup?.Bump) / 100 ?? 0;
            bumpSurgeCalculationModel.Surge = (setup?.Surge) / 100 ?? 0;

            SurgeAndBumpCaluclationsClass _surgeAndBumpCaluclationsClass = new SurgeAndBumpCaluclationsClass();
            FinalBumpSurgeCalculationModel finalModel = _surgeAndBumpCaluclationsClass.SurgeBumpCaluclation(bumpSurgeCalculationModel);

            BFSC = finalModel.Fuel;
            return finalModel.Fuel;
        }

        [Then(@"fuel value of carrier in shipment results should be equal to BFSC (.*)")]
        public void ThenFuelValueOfCarrierInShipmentResultsShouldBeEqualToBFSC(string userType)
        {
           
           

            if (userType == "Internal")
            {
                Report.WriteLine("Verifying the BFSC calculation with UI value");
                //string ActualBOTFACC = BOFSC.ToString();
                string firstCarrierInternalFuel = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[1]/td[5]/div[2]");
                string FinalBFSC = "Fuel: $ " + Math.Round(BFSC, 2);
                Assert.AreEqual(firstCarrierInternalFuel, FinalBFSC);
            }
            else
            {
                Report.WriteLine("Verifying the BFSC calculation with UI value");
                string firstCarrierFuel = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[1]/td[4]/div[2]");
                string FinalBFSC = "Fuel: $" + Math.Round(BFSC, 2);
                Assert.AreEqual(firstCarrierFuel, FinalBFSC);
            }
        }
    }
}
