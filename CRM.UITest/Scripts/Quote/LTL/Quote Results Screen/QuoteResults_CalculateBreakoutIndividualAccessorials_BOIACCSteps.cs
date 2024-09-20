using CRM.UITest.CommonMethods;
using CRM.UITest.Helper.ViewModel;
using CRM.UITest.Objects;
using CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Quote.LTL.Quote_Results_Screen
{
    [Binding]
    public class QuoteResults_CalculateBreakoutIndividualAccessorials_BOIACCSteps : AddShipments
    { 
        RatingCalculationMethods ratingCalculation = new RatingCalculationMethods();
        List<RateResultCarrierViewModel> rlist = null;
        BaseMarkupBreakDownCalcuation baseMarkupDown = null;

        //[Then(@"BOIACC can be calculated(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        //public void ThenBOIACCCanBeCalculated(string CustomerName, string Service, string OriginCity, string OriginZip, string OriginState, string OriginCountry, string DestinationCity, string DestinationZip, string DestinationState, string DestinationCountry, string OAccessorial, string DAccessorial, string Classification, double Quantity, string QuantityUNIT, double Weight, string WeightUnit, string UserType, string CalculationType)
        //{
            
        //    string Username = "salesmanager@stage.com";
        //    baseMarkupDown = new BaseMarkupBreakDownCalcuation();
        //    decimal BOIACC = baseMarkupDown.calculateBaseMarkDownCharges(CustomerName, Service, OriginCity, OriginZip, OriginState, OriginCountry, DestinationCity, DestinationZip, DestinationState, DestinationCountry, OAccessorial, DAccessorial, Classification, Quantity, QuantityUNIT, Weight, WeightUnit, Username, UserType, CalculationType);
        //}

        [Then(@"the BOIACC can be calculated (.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void ThenTheBOIACCCanBeCalculated(string CustomerName, string Username, string OriginCity, string OriginZip, string OriginState, string OriginCountry, string DestinationCity, string DestinationZip, string DestinationState, string DestinationCountry, string OAccessorial, string DAccessorial, string Classification, double Quantity, string QuantityUNIT, double Weight, string Mode, string UserType, string CalculationType)
        {
            //string Username = null;
            //if (UserType == "External")
            //{
            //    Username = "zzzext@user.com";
            //}
            //else if (UserType == "Internal")
            //{
            //    Username = "salesmanager@stage.com";
            //}

                baseMarkupDown = new BaseMarkupBreakDownCalcuation();
                decimal BOIACC = baseMarkupDown.calculateBaseMarkDownCharges(CustomerName, "Service", OriginCity, OriginZip, OriginState, OriginCountry, DestinationCity, DestinationZip, DestinationState, DestinationCountry, OAccessorial, DAccessorial, Classification, Quantity, QuantityUNIT, Weight, Mode, Username, UserType, CalculationType);
        }


    }
}
