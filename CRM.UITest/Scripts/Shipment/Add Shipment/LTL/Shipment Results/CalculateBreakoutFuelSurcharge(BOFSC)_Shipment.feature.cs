﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.1.0.0
//      SpecFlow Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace CRM.UITest.Scripts.Shipment.AddShipment.LTL.ShipmentResults
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class CalculateBreakoutFuelSurchargeBOFSC_ShipmentFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CalculateBreakoutFuelSurcharge(BOFSC)_Shipment.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner(null, 0);
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "CalculateBreakoutFuelSurcharge(BOFSC)_Shipment", null, ProgrammingLanguage.CSharp, new string[] {
                        "30325",
                        "Sprint72",
                        "CalculateBreakoutFuelSurcharge(BOFSC)_Shipment"});
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((testRunner.FeatureContext != null) 
                        && (testRunner.FeatureContext.FeatureInfo.Title != "CalculateBreakoutFuelSurcharge(BOFSC)_Shipment")))
            {
                CRM.UITest.Scripts.Shipment.AddShipment.LTL.ShipmentResults.CalculateBreakoutFuelSurchargeBOFSC_ShipmentFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void VerifyTheBOFSCCalculationsForShipment(
                    string scenario, 
                    string username, 
                    string password, 
                    string customerName, 
                    string service, 
                    string originCity, 
                    string originZip, 
                    string originState, 
                    string originCountry, 
                    string destinationCity, 
                    string destinationZip, 
                    string destinationState, 
                    string destinationCountry, 
                    string oAccessorial, 
                    string dAccessorial, 
                    string classification, 
                    string quantity, 
                    string quantityUNIT, 
                    string weight, 
                    string mode, 
                    string userType, 
                    string calculationType, 
                    string oName, 
                    string oAdd1, 
                    string dName, 
                    string dAdd1, 
                    string nmfc, 
                    string desc, 
                    string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Functional"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify the BOFSC calculations for Shipment", @__tags);
#line 5
this.ScenarioSetup(scenarioInfo);
#line 6
testRunner.Given(string.Format("I am a DLS user belongs to Gainshare Customer and login into application with val" +
                        "id {0} and {1}", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 7
testRunner.When(string.Format("am on the Shipment results page{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}," +
                        "{12},{13}", customerName, originZip, destinationZip, dAccessorial, classification, quantity, weight, userType, oName, oAdd1, dName, dAdd1, nmfc, desc), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 8
testRunner.Then(string.Format("BOFSC can be calculated and verified in Shipment Results page{0},{1},{2},{3},{4}," +
                        "{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18}", customerName, username, originCity, originZip, originState, originCountry, destinationCity, destinationZip, destinationState, destinationCountry, oAccessorial, dAccessorial, classification, quantity, quantityUNIT, weight, mode, userType, calculationType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify the BOFSC calculations for Shipment: s1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CalculateBreakoutFuelSurcharge(BOFSC)_Shipment")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("30325")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint72")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("CalculateBreakoutFuelSurcharge(BOFSC)_Shipment")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "s1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Scenario", "s1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "zzzext")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:CustomerName", "ZZZ - CZar Customer Test")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Service", "COD")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:OriginCity", "Miami")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:OriginZip", "33126")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:OriginState", "FL")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:OriginCountry", "USA")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DestinationCity", "Tempe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DestinationZip", "85282")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DestinationState", "AZ")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DestinationCountry", "USA")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:OAccessorial", "")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DAccessorial", "COD")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Classification", "50")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Quantity", "1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:QuantityUNIT", "SKD")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Weight", "3")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Mode", "Shipment")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:UserType", "External")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:CalculationType", "BOFSC")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:oName", "otest")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:oAdd1", "oadd1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:dName", "dtest")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:dAdd1", "daadd1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:nmfc", "1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:desc", "dtss")]
        public virtual void VerifyTheBOFSCCalculationsForShipment_S1()
        {
            this.VerifyTheBOFSCCalculationsForShipment("s1", "zzzext", "Te$t1234", "ZZZ - CZar Customer Test", "COD", "Miami", "33126", "FL", "USA", "Tempe", "85282", "AZ", "USA", "", "COD", "50", "1", "SKD", "3", "Shipment", "External", "BOFSC", "otest", "oadd1", "dtest", "daadd1", "1234", "dtss", ((string[])(null)));
#line hidden
        }
    }
}
#pragma warning restore
#endregion
