using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Results
{
    [Binding]
    public class CalculateBreakoutTotalFinalAccessorialsBOTFACC_ShipmentSteps : AddShipments
    {
        CommonMethodsCrm crm = new CommonMethodsCrm();
        AddShipmentLTL ltl = new AddShipmentLTL();
        BaseMarkupBreakDownCalcuation baseMarkupDown = null;
        AddShipmentLTL data = new AddShipmentLTL();

        [When(@"am on the Shipment results page(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void WhenAmOnTheShipmentResultsPage(string CustomerName, string OriginZip, string DestinationZip, string DAccessorial, string Classification, double Quantity, double Weight, string UserType, string oName, string oAdd1,string dName, string dAdd1, string nmfc, string desc)
        {
           
            GlobalVariables.webDriver.WaitForPageLoad();
            DefineTimeOut(30000);
            ltl.NaviagteToShipmentList();
            ltl.SelectingCustomerFromShipmentList(UserType, CustomerName);
            Click(attributeName_id, ShippingFrom_ClearAddress_Id);
            Click(attributeName_id, ShippingTo_ClearAddress_Id);
            ltl.AddShipmentOriginData(oName, oAdd1, OriginZip);
            ltl.AddShipmentDestinationData(dName, dAdd1, DestinationZip);          
            DefineTimeOut(1000);
            Click(attributeName_xpath, ".//*[@id='shippingtoaccessorial_chosen']/ul/li/input");
            Click(attributeName_xpath, ".//*[@id='shippingtoaccessorial_chosen']/div/ul/li[text()='"+DAccessorial+"']");
            
            DefineTimeOut(1000);

            scrollElementIntoView(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            Click(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            Thread.Sleep(1000);
            string _Quantity = Quantity.ToString();
            string _Weight = Weight.ToString();
            ltl.AddShipmentFreightDescription(Classification, nmfc, _Quantity, _Weight, desc);
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

        [Then(@"BOTFACC can be calculated and Verified in the Shipment Results page(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public decimal ThenBOTFACCCanBeCalculatedAndVerifiedInTheShipmentResultsPage(string CustomerName, string Username, string OriginCity, string OriginZip, string OriginState, string OriginCountry, string DestinationCity, string DestinationZip, string DestinationState, string DestinationCountry, string OAccessorial, string DAccessorial, string Classification, double Quantity, string QuantityUNIT, double Weight, string Mode, string UserType, string CalculationType)
        {
           
            baseMarkupDown = new BaseMarkupBreakDownCalcuation();
            decimal BOTFACC = baseMarkupDown.calculateBaseMarkDownCharges(CustomerName, "Service", OriginCity, OriginZip, OriginState, OriginCountry, DestinationCity, DestinationZip, DestinationState, DestinationCountry, OAccessorial, DAccessorial, Classification, Quantity, QuantityUNIT, Weight, Mode, Username, UserType, CalculationType);
            //Frame UI verifications of BOTFACC
            if (UserType == "External")
            {
                string Accessorial_UI = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[1]/td[4]/div[4]");
                string ActualBOTFACC = BOTFACC.ToString();
                string FinalBOTFACC = "Accessorials: $" + Math.Round(BOTFACC, 2); 
                Assert.AreEqual(Accessorial_UI, FinalBOTFACC);
            }
            else if (UserType == "Internal")
            {
                string Accessorial_UI = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[1]/td[5]/div[4]");
                string ActualBOTFACC = BOTFACC.ToString();
                string FinalBOTFACC = "Accessorials: $" + Math.Round(BOTFACC, 2);
                Assert.AreEqual(Accessorial_UI, FinalBOTFACC);
            }
            return BOTFACC;
        }
    }
}
