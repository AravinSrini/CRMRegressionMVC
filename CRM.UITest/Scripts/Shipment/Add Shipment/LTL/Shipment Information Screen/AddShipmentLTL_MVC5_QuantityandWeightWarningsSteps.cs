using System;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System.Threading;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Information_Screen
{
    [Binding]
    public class AddShipmentLTL_MVC5_QuantityandWeightWarningsSteps: AddShipments
    {        
        AddShipmentLTL ltl = new AddShipmentLTL();
        
        [Given(@"I am on the Add Shipment \(LTL\) page (.*), (.*)")]
        public void GivenIAmOnTheAddShipmentLTLPage(string Usertype, string CustomerName)
        {
            //Navigate to Add shipment (LTL) page       
            ltl.NaviagteToShipmentList();
            ltl.SelectCustomerFromShipmentList(Usertype, CustomerName);
        }
        
        [Given(@"the Quantity type is skids")]
        public void GivenTheQuantityTypeIsSkids()
        {
            Report.WriteLine("Quantity type is Skids by default");
            scrollElementIntoView(attributeName_xpath, FreightDesp_SectionText_xpath);
            VerifyElementVisible(attributeName_xpath, FreightDesp_FirstItem_QuantityType_xpath, "Skids");            
        }
        
        [Given(@"the Quantity type is pallets")]
        public void GivenTheQuantityTypeIsPallets()
        {
            Report.WriteLine("Select Quantity type as Pallets");
            scrollElementIntoView(attributeName_xpath, FreightDesp_SectionText_xpath);
            Click(attributeName_xpath, FreightDesp_FirstItem_QuantityType_xpath);
            SelectDropdownValueFromList(attributeName_xpath, FreightDesp_QuantityDropdownValues_Xpath, "Pallets");
        }
        
        [Given(@"the Weight type is LBS")]
        public void GivenTheWeightTypeIsLBS()
        {
            Report.WriteLine("Weight type if LBS be default");
            scrollElementIntoView(attributeName_xpath, FreightDesp_SectionText_xpath);
            Click(attributeName_xpath, FreightDesp_FirstItem_WeightType_xpath);
            SelectDropdownValueFromList(attributeName_xpath, FreightDesp_FirstItem_WeightType_xpath, "LBS");
        }
        
        [Given(@"the Weight type is KILOS")]
        public void GivenTheWeightTypeIsKILOS()
        {
            Report.WriteLine("Select Weight type as Kilos");
            scrollElementIntoView(attributeName_xpath, FreightDesp_SectionText_xpath);
            Click(attributeName_xpath, FreightDesp_FirstItem_WeightType_xpath);
            SelectDropdownValueFromList(attributeName_xpath, FreightDesp_FirstItem_WeightType_xpath, "KILOS");
        }
        
        [When(@"the Quantity is greater than threshold value")]
        public void WhenTheQuantityIsGreaterThanThresholdValue()
        {
            Report.WriteLine("Entered Quantity is greater than 6");
            SendKeys(attributeName_id, FreightDesp_FirstItem_Quantity_Id, "7");            
        }

        [When(@"the Weight is greater than (.*)")]
        public void WhenTheWeightIsGreaterThan(string Threshold_value)
        {
            Report.WriteLine("Entered Weight is greater than threshold value");
            SendKeys(attributeName_id, FreightDesp_FirstItem_Weight_Id, Threshold_value);
        }
        
        [Then(@"I will display with (.*) in Add Shipment \(LTL\) page")]
        public void ThenIWillDisplayWithInAddShipmentLTLPage(string Quantity_WarningMessage)
        {
            Report.WriteLine("Quantity Warning message will be diaplyed");
            string Actual_Quantity_WarningMsg = Gettext(attributeName_xpath, FreightDesp_FirstItem_Quantity_Warning_xpath);
            Assert.AreEqual(Actual_Quantity_WarningMsg, Quantity_WarningMessage);
        }
        
        [Then(@"I will displayed with lbs (.*) in Add Shipment \(LTL\) page")]
        public void ThenIWillDisplayedWithLbsInAddShipmentLTLPage(string Weight_WarningMessage)
        {
            Report.WriteLine("Weight warning message will be displayed");
            Thread.Sleep(1000);
            string Actual_Weight_WarningMsg = Gettext(attributeName_xpath, WeightWarningLbs_xpath);
            Assert.AreEqual(Actual_Weight_WarningMsg, Weight_WarningMessage);
        }

        [Then(@"I will displayed with Kilos (.*) in Add Shipment \(LTL\) page")]
        public void ThenIWillDisplayedWithKilosInAddShipmentLTLPage(string Weight_WarningMessage)
        {
            Report.WriteLine("Weight warning message will be displayed");
            Thread.Sleep(1000);
            string Actual_Weight_WarningMsg = Gettext(attributeName_xpath, WeightWarningKilos_xpath);
            Assert.AreEqual(Actual_Weight_WarningMsg, Weight_WarningMessage);
        }
    }
}
