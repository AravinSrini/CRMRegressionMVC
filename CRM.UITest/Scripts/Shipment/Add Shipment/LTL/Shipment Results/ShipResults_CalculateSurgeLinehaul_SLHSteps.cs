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
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Results
{
    [Binding]
    public class ShipResults_CalculateSurgeLinehaul_SLHSteps : AddShipments
    {
        //List<RateResultCarrierViewModel> rlist = null;
        List<IndividualAccessorialModel> rlist = null;
        AddShipmentLTL data = new AddShipmentLTL();
        decimal BOTFACC = 0;
        decimal BOLH = 0;
        decimal BOFSC = 0;
        decimal BOTTL = 0;
        decimal SLH = 0;
        decimal fuelSurcharge = 0;
        string firstCarrierval = null;
        public ShipmentInformationModel _ShipmentInformationModel = new ShipmentInformationModel();
        RatingCalculationMethods rateCal = new RatingCalculationMethods();
        public BumpSurgeCalculationModel bumpSurgeCalculationModel = new BumpSurgeCalculationModel();



        [Then(@"linehaul value for carrrier in shipment results should be equal to SLH (.*)")]
        public void ThenLinehaulValueForCarrrierInShipmentResultsShouldBeEqualToSLH(string userType)
        {
            

            if (userType == "Internal")
            {
                Report.WriteLine("Verifying the BTTL calculation with UI value");
                string firstCarrierInternallineHaul = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[1]/td[5]/div[3]");
                string FinalSLH = "Line Haul: $" + Math.Round(SLH, 2);
                Assert.AreEqual(firstCarrierInternallineHaul, FinalSLH);
            }
            else
            {
                Report.WriteLine("Verifying the BTTL calculation with UI value");
                string firstCarrierLineHaul = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[1]/td[4]/div[3]");
                string FinalSLH = "Line Haul: $" + Math.Round(SLH, 2);
                Assert.AreEqual(firstCarrierLineHaul, FinalSLH);
            }
        }


        //[When(@"I am passing Classification information and i arrive on shipement result page for SLH (.*), (.*), (.*), (.*), (.*), (.*), (.*)")]
        //public decimal WhenIAmPassingClassificationInformationAndIArriveOnShipementResultPageForSLH(string CustomerName, string classification, string nmfc, string quantity, string weight, string desc, string CalculationType)
        //{

        [When(@"I am passing Classification information and i arrive on shipement result page for SLH (.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*)")]
        public decimal WhenIAmPassingClassificationInformationAndIArriveOnShipementResultPageForSLH(string Usertype, string CustomerName, string oCity, string oZip, string oState, string dCity, string dZip, string dState, string classification, string nmfc, string quantity, string weight, string Username, string oServices, string dServices, string desc, string CalculationType)
        {
            _ShipmentInformationModel.classification = classification;
            _ShipmentInformationModel.nmfc = nmfc;
            _ShipmentInformationModel.quantity = quantity;
            _ShipmentInformationModel.weight = weight;
            _ShipmentInformationModel.desc = desc;
            _ShipmentInformationModel.CustomerName = CustomerName;
            _ShipmentInformationModel.oServices = oServices;
            _ShipmentInformationModel.dServices = dServices;
            _ShipmentInformationModel.Username = Username;
            _ShipmentInformationModel.oCity = oCity;
            _ShipmentInformationModel.oState = oState;
            _ShipmentInformationModel.oZip = oZip;
            _ShipmentInformationModel.dCity = dCity;
            _ShipmentInformationModel.dState = dState;
            _ShipmentInformationModel.dZip = dZip;
            _ShipmentInformationModel.Usertype = Usertype;


            // _ShipmentInformationModel.oCity = 

            scrollElementIntoView(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            Click(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            data.AddShipmentFreightDescription(classification, nmfc, quantity, weight, desc);
            data.ClickViewRates();
            CommonCalculations_LHBFC_BMSBTL_BM_BMAT_BMATC_BMMASteps steps = new CommonCalculations_LHBFC_BMSBTL_BM_BMAT_BMATC_BMMASteps();
            decimal BMAA = steps.ThenBMAAShouldBeCalculated("Shipment", _ShipmentInformationModel.CustomerName, "LTL", _ShipmentInformationModel.oCity, _ShipmentInformationModel.oZip, _ShipmentInformationModel.oState, "USA", _ShipmentInformationModel.dCity,
                _ShipmentInformationModel.dZip, _ShipmentInformationModel.dState, "USA", _ShipmentInformationModel.classification, Convert.ToDouble(quantity), "skids", Convert.ToDouble(weight), "LBS", _ShipmentInformationModel.Username, _ShipmentInformationModel.oServices, _ShipmentInformationModel.dServices);

            BaseMarkupBreakDownCalcuation step1 = new BaseMarkupBreakDownCalcuation();
            BOLH = step1.calculateBaseMarkDownCharges(_ShipmentInformationModel.CustomerName, "service", _ShipmentInformationModel.oCity, _ShipmentInformationModel.oZip, _ShipmentInformationModel.oState, "USA",
                _ShipmentInformationModel.dCity, _ShipmentInformationModel.dZip, _ShipmentInformationModel.dState, "USA", _ShipmentInformationModel.oServices, _ShipmentInformationModel.dServices, classification,
                Convert.ToDouble(quantity), "skids", Convert.ToDouble(weight), "Shipment",
                _ShipmentInformationModel.Username, _ShipmentInformationModel.Usertype, "BOLH");
            bumpSurgeCalculationModel.BreakOutLineHaul = BOLH;
          //  BaseMarkupBreakDownCalcuation step2 = new BaseMarkupBreakDownCalcuation();
            BOTFACC = step1.calculateBaseMarkDownCharges(_ShipmentInformationModel.CustomerName, "service", _ShipmentInformationModel.oCity, _ShipmentInformationModel.oZip, _ShipmentInformationModel.oState, "USA",
                _ShipmentInformationModel.dCity, _ShipmentInformationModel.dZip, _ShipmentInformationModel.dState, "USA", _ShipmentInformationModel.oServices, _ShipmentInformationModel.dServices, classification,
                Convert.ToDouble(quantity), "skids", Convert.ToDouble(weight), "Shipment",
                _ShipmentInformationModel.Username, _ShipmentInformationModel.Usertype, CalculationType);
            bumpSurgeCalculationModel.BreakOutAccessorialsTotal = BOTFACC;
             BOFSC = step1.calculateBaseMarkDownCharges(_ShipmentInformationModel.CustomerName, "service", _ShipmentInformationModel.oCity, _ShipmentInformationModel.oZip, _ShipmentInformationModel.oState, "USA",
  _ShipmentInformationModel.dCity, _ShipmentInformationModel.dZip, _ShipmentInformationModel.dState, "USA", _ShipmentInformationModel.oServices, _ShipmentInformationModel.dServices, classification, Convert.ToDouble(quantity), "skids", Convert.ToDouble(weight), "Shipment",
  _ShipmentInformationModel.Username, _ShipmentInformationModel.Usertype, "BOFSC");
            bumpSurgeCalculationModel.BreakOutFuel = BOFSC;
            //  BaseMarkupBreakDownCalcuation step3 = new BaseMarkupBreakDownCalcuation();
             BOTTL = step1.calculateBaseMarkDownCharges(_ShipmentInformationModel.CustomerName, "service", _ShipmentInformationModel.oCity, _ShipmentInformationModel.oZip, _ShipmentInformationModel.oState, "USA",
               _ShipmentInformationModel.dCity, _ShipmentInformationModel.dZip, _ShipmentInformationModel.dState, "USA", _ShipmentInformationModel.oServices, _ShipmentInformationModel.dServices, classification, Convert.ToDouble(quantity), "skids", Convert.ToDouble(weight), "Shipment",
               _ShipmentInformationModel.Username, _ShipmentInformationModel.Usertype, "BOTTL");
            bumpSurgeCalculationModel.BreakOutTotal = BOTTL;
            return BOTTL;
        }
        [Then(@"SLH should be calculated (.*) when surge value is greater than zero and bump value is equal to zero")]
        public decimal ThenSLHShouldBeCalculatedWhenSurgeValueIsGreaterThanZeroAndBumpValueIsEqualToZero(string CustomerName)
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
            rlist = GetRatesAndCarriersAPICall.BuildIndividualAccessorialModelFromCarrierPriceSheet(CustomerName, "service",
                _ShipmentInformationModel.oCity,
                _ShipmentInformationModel.oZip, _ShipmentInformationModel.oState, "USA", _ShipmentInformationModel.dCity,
                _ShipmentInformationModel.dZip, _ShipmentInformationModel.dState, "USA",
                _ShipmentInformationModel.oServices, _ShipmentInformationModel.dServices, _ShipmentInformationModel.classification,
                 Convert.ToDouble(_ShipmentInformationModel.quantity), "skids",
                 Convert.ToDouble(_ShipmentInformationModel.weight), "LBS", _ShipmentInformationModel.Username, false);

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
                if (rlist[i].carrierName == firstCarrier)
                {
                    CARSCAC_COde = rlist[i].CarrierScac;
                }
            }

            BumpSurgeCustomerSetUp setup = DBHelper.GetBumpSurgeDetails(CARSCAC_COde, CustomerName);
            bumpSurgeCalculationModel.Bump = (setup?.Bump) / 100 ?? 0;
            bumpSurgeCalculationModel.Surge = (setup?.Surge) / 100 ?? 0;

            SurgeAndBumpCaluclationsClass _surgeAndBumpCaluclationsClass = new SurgeAndBumpCaluclationsClass();
            FinalBumpSurgeCalculationModel finalModel = _surgeAndBumpCaluclationsClass.SurgeBumpCaluclation(bumpSurgeCalculationModel);
            SLH = finalModel.LineHaul;
            return SLH;
        }
    }
}
