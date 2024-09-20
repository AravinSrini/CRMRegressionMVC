﻿using CRM.UITest.CommonMethods;
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
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Results
{
    [Binding]
    public class ShipResults_CalculateBumpTotal_BTTLSteps : AddShipments
    {
        public ShipmentInformationModel _ShipmentInformationModel = new ShipmentInformationModel();
        AddShipmentLTL data = new AddShipmentLTL();
        List<IndividualAccessorialModel> rlist = null;
        RatingCalculationMethods rateCal = new RatingCalculationMethods();
        public BumpSurgeCalculationModel bumpSurgeCalculationModel = new BumpSurgeCalculationModel();
        decimal BTTL = 0;
        decimal BOFSC = 0;
        decimal BOLH = 0;
        decimal BMAA = 0;
        decimal BOTFACC = 0;
        decimal BOACC = 0;
        decimal BOTTL = 0;
        [When(@"I am passing Classification information and i arrive on shipement result page for BTTL (.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*)")]
        public void WhenIAmPassingClassificationInformationAndIArriveOnShipementResultPageForBTTL(string Usertype, string CustomerName, string oCity, string oZip, string oState, string dCity, string dZip, string dState, string classification, string nmfc, string quantity, string weight, string Username, string oServices, string dServices, string desc, string CalculationType)
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
            scrollElementIntoView(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            Click(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            data.AddShipmentFreightDescription(classification, nmfc, quantity, weight, desc);
            data.ClickViewRates();
            

            CommonCalculations_LHBFC_BMSBTL_BM_BMAT_BMATC_BMMASteps steps = new CommonCalculations_LHBFC_BMSBTL_BM_BMAT_BMATC_BMMASteps();
            decimal BMAA = steps.ThenBMAAShouldBeCalculated("Shipment", _ShipmentInformationModel.CustomerName, "LTL", _ShipmentInformationModel.oCity, _ShipmentInformationModel.oZip, _ShipmentInformationModel.oState, "USA", _ShipmentInformationModel.dCity,
                _ShipmentInformationModel.dZip, _ShipmentInformationModel.dState, "USA", _ShipmentInformationModel.classification, Convert.ToDouble(quantity), "skids", Convert.ToDouble(weight), "LBS", _ShipmentInformationModel.Username, _ShipmentInformationModel.oServices, _ShipmentInformationModel.dServices);

            BaseMarkupBreakDownCalcuation step = new BaseMarkupBreakDownCalcuation();
            BOFSC = step.calculateBaseMarkDownCharges(_ShipmentInformationModel.CustomerName, "service", _ShipmentInformationModel.oCity, _ShipmentInformationModel.oZip, _ShipmentInformationModel.oState, "USA",
                _ShipmentInformationModel.dCity, _ShipmentInformationModel.dZip, _ShipmentInformationModel.dState, "USA", _ShipmentInformationModel.oServices, _ShipmentInformationModel.dServices, classification, Convert.ToDouble(quantity), "skids", Convert.ToDouble(weight), "Shipment",
                _ShipmentInformationModel.Username, _ShipmentInformationModel.Usertype, "BOFSC");
            bumpSurgeCalculationModel.BreakOutFuel = BOFSC;
            //BaseMarkupBreakDownCalcuation step1 = new BaseMarkupBreakDownCalcuation();
            BOLH = step.calculateBaseMarkDownCharges(_ShipmentInformationModel.CustomerName, "service", _ShipmentInformationModel.oCity, _ShipmentInformationModel.oZip, _ShipmentInformationModel.oState, "USA",
                _ShipmentInformationModel.dCity, _ShipmentInformationModel.dZip, _ShipmentInformationModel.dState, "USA", _ShipmentInformationModel.oServices, _ShipmentInformationModel.dServices, classification, Convert.ToDouble(quantity), "skids", Convert.ToDouble(weight), "Shipment",
                _ShipmentInformationModel.Username, _ShipmentInformationModel.Usertype, "BOLH");
            bumpSurgeCalculationModel.BreakOutLineHaul = BOLH;
           // BaseMarkupBreakDownCalcuation step2 = new BaseMarkupBreakDownCalcuation();
            BOTFACC = step.calculateBaseMarkDownCharges(_ShipmentInformationModel.CustomerName, "service", _ShipmentInformationModel.oCity, _ShipmentInformationModel.oZip, _ShipmentInformationModel.oState, "USA",
                _ShipmentInformationModel.dCity, _ShipmentInformationModel.dZip, _ShipmentInformationModel.dState, "USA", _ShipmentInformationModel.oServices, _ShipmentInformationModel.dServices, classification, Convert.ToDouble(quantity), "skids", Convert.ToDouble(weight), "Shipment",
                _ShipmentInformationModel.Username, _ShipmentInformationModel.Usertype, "BOTFACC");
            bumpSurgeCalculationModel.BreakOutAccessorialsTotal = BOTFACC;
            //BaseMarkupBreakDownCalcuation step3 = new BaseMarkupBreakDownCalcuation();
            BOACC = step.calculateBaseMarkDownCharges(_ShipmentInformationModel.CustomerName, "service", _ShipmentInformationModel.oCity, _ShipmentInformationModel.oZip, _ShipmentInformationModel.oState, "USA",
                _ShipmentInformationModel.dCity, _ShipmentInformationModel.dZip, _ShipmentInformationModel.dState, "USA", _ShipmentInformationModel.oServices, _ShipmentInformationModel.dServices, classification, Convert.ToDouble(quantity), "skids", Convert.ToDouble(weight), "Shipment",
                _ShipmentInformationModel.Username, _ShipmentInformationModel.Usertype, "BOACC");
            BOTTL = step.calculateBaseMarkDownCharges(_ShipmentInformationModel.CustomerName, "service", _ShipmentInformationModel.oCity, _ShipmentInformationModel.oZip, _ShipmentInformationModel.oState, "USA",
               _ShipmentInformationModel.dCity, _ShipmentInformationModel.dZip, _ShipmentInformationModel.dState, "USA", _ShipmentInformationModel.oServices, _ShipmentInformationModel.dServices, classification, Convert.ToDouble(quantity), "skids", Convert.ToDouble(weight), "Shipment",
               _ShipmentInformationModel.Username, _ShipmentInformationModel.Usertype, "BOTTL");
            bumpSurgeCalculationModel.BreakOutTotal = BOTTL;
        }


        [Then(@"BTTL for shipment should be calculated (.*)")]
        public decimal ThenBTTLForShipmentShouldBeCalculated(string CustomerName)
        {
            string firstCarrier = null;
            rlist = GetRatesAndCarriersAPICall.BuildIndividualAccessorialModelFromCarrierPriceSheet(CustomerName, "service", _ShipmentInformationModel.oCity, _ShipmentInformationModel.oZip, _ShipmentInformationModel.oState, "USA", _ShipmentInformationModel.dCity,
                _ShipmentInformationModel.dZip, _ShipmentInformationModel.dState, "USA", _ShipmentInformationModel.oServices, _ShipmentInformationModel.dServices,
                _ShipmentInformationModel.classification, Convert.ToDouble(_ShipmentInformationModel.quantity), "skids", Convert.ToDouble(_ShipmentInformationModel.weight),
                "LBS", _ShipmentInformationModel.Username, false);

            firstCarrier = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[1]/td[1]/div[@class = 'row']/div[@class = 'col-md-12 carrier-name-col']");
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
            BTTL = finalModel.Total;
            return finalModel.Total;

        }

        [Then(@"displaying carrier total value in shipment results should match with calculated BTTL value (.*)")]
        public void ThenDisplayingCarrierTotalValueInShipmentResultsShouldMatchWithCalculatedBTTLValue(string userType)
        {
           
            if (userType == "Internal")
            {
                string firstCarrierInternalFuel = Gettext(attributeName_xpath, ShipResults_InternalFC_Fuel_Xpath);
                Report.WriteLine("Verifying the BTTL calculation with UI value");
                string FinalBTTL = "$" + Math.Round(BTTL, 2);
                Assert.AreEqual(firstCarrierInternalFuel, FinalBTTL);
            }
            else
            {
                string firstCarrierFuel = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[1]/td[4]/div[1]");
                Report.WriteLine("Verifying the BTTL calculation with UI value");
                string FinalBTTL = "$" + Math.Round(BTTL, 2);
                Assert.AreEqual(firstCarrierFuel, FinalBTTL);
            }
        }

    }
}
