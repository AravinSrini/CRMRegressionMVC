﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.3.0.0
//      SpecFlow Generator Version:2.3.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace CRM.UITest.Scripts.Shipment.AddShipment.LTL.ShipmentReviewAndSubmit
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class ReviewSubmitShipmentLTLPage_ImproveReadabilityFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "ReviewSubmitShipmentLTLPage_ImproveReadability.feature"
#line hidden
        
        public virtual Microsoft.VisualStudio.TestTools.UnitTesting.TestContext TestContext
        {
            get
            {
                return this._testContext;
            }
            set
            {
                this._testContext = value;
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner(null, 0);
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "ReviewSubmitShipmentLTLPage_ImproveReadability", null, ProgrammingLanguage.CSharp, new string[] {
                        "NinjaSprint13",
                        "40718"});
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "ReviewSubmitShipmentLTLPage_ImproveReadability")))
            {
                global::CRM.UITest.Scripts.Shipment.AddShipment.LTL.ShipmentReviewAndSubmit.ReviewSubmitShipmentLTLPage_ImproveReadabilityFeature.FeatureSetup(null);
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
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Microsoft.VisualStudio.TestTools.UnitTesting.TestContext>(TestContext);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void _40718_Verify_Labels_And_Values_In_Black_For_External_Users(
                    string scenario, 
                    string userType, 
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
                    string classification, 
                    string nmfc, 
                    string quantity, 
                    string weight, 
                    string itemdesc, 
                    string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "GUI"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("40718_Verify_Labels_And_Values_In_Black_for_External_Users", @__tags);
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
 testRunner.Given(string.Format("I am a shp.entry User {0}", userType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
 testRunner.And("I arrive on the External user AddShipments Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 9
 testRunner.And(string.Format("I enter data in add LTL Shipment Information page {0},{1},{2},{3},{4},{5},{6},{7}" +
                        ",{8},{9},{10},{11},{12},{13},{14}", originName, originAddr1, originCity, originState, originZipcode, destinationName, destinationAddr1, destinationCity, destinationState, destinationZipcode, classification, nmfc, quantity, weight, itemdesc), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
 testRunner.When("I arrive on the Shipment Results LTL page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 11
 testRunner.Then("I verify the labels and values will be black.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("40718_Verify_Labels_And_Values_In_Black_for_External_Users: s1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ReviewSubmitShipmentLTLPage_ImproveReadability")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("NinjaSprint13")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("40718")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "s1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Scenario", "s1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:UserType", "shipentry")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:originName", "Oname")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:originAddr1", "Oname1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:originCity", "LOS ANGELS")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:originState", "CA")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:originZipcode", "90001")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:destinationName", "Dname")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:destinationAddr1", "Dname2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:destinationCity", "LOS ANGELS")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:destinationState", "CA")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:destinationZipcode", "90001")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Classification", "55")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:nmfc", "6789-01")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:quantity", "5")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:weight", "100")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:itemdesc", "CLEANING WIPES")]
        public virtual void _40718_Verify_Labels_And_Values_In_Black_For_External_Users_S1()
        {
#line 6
this._40718_Verify_Labels_And_Values_In_Black_For_External_Users("s1", "shipentry", "Oname", "Oname1", "LOS ANGELS", "CA", "90001", "Dname", "Dname2", "LOS ANGELS", "CA", "90001", "55", "6789-01", "5", "100", "CLEANING WIPES", ((string[])(null)));
#line hidden
        }
        
        public virtual void _40718_Verify_Labels_And_Values_In_Black_For_Internal_Users(
                    string scenario, 
                    string userType, 
                    string customerName, 
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
                    string classification, 
                    string nmfc, 
                    string quantity, 
                    string weight, 
                    string itemdesc, 
                    string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "GUI"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("40718_Verify_Labels_And_Values_In_Black_for_Internal_Users", @__tags);
#line 19
this.ScenarioSetup(scenarioInfo);
#line 20
 testRunner.Given(string.Format("I am a sales, sales management, operations, or station owner user {0}", userType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 21
 testRunner.And(string.Format("I arrive on the Internal user AddShipments Page {0}", customerName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
 testRunner.And(string.Format("I enter data in add LTL Shipment Information page {0},{1},{2},{3},{4},{5},{6},{7}" +
                        ",{8},{9},{10},{11},{12},{13},{14}", originName, originAddr1, originCity, originState, originZipcode, destinationName, destinationAddr1, destinationCity, destinationState, destinationZipcode, classification, nmfc, quantity, weight, itemdesc), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
 testRunner.When("I arrive on the Shipment Results LTL page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 24
 testRunner.Then("I verify the labels and values will be black for Internal User.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("40718_Verify_Labels_And_Values_In_Black_for_Internal_Users: s1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ReviewSubmitShipmentLTLPage_ImproveReadability")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("NinjaSprint13")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("40718")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "s1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Scenario", "s1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:UserType", "stationowner")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:CustomerName", "ZZZ - GS Customer Test")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:originName", "Oname")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:originAddr1", "Oname1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:originCity", "LOS ANGELS")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:originState", "CA")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:originZipcode", "90001")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:destinationName", "Dname")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:destinationAddr1", "Dname2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:destinationCity", "LOS ANGELS")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:destinationState", "CA")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:destinationZipcode", "90001")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Classification", "55")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:nmfc", "6789-01")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:quantity", "5")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:weight", "100")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:itemdesc", "CLEANING WIPES")]
        public virtual void _40718_Verify_Labels_And_Values_In_Black_For_Internal_Users_S1()
        {
#line 19
this._40718_Verify_Labels_And_Values_In_Black_For_Internal_Users("s1", "stationowner", "ZZZ - GS Customer Test", "Oname", "Oname1", "LOS ANGELS", "CA", "90001", "Dname", "Dname2", "LOS ANGELS", "CA", "90001", "55", "6789-01", "5", "100", "CLEANING WIPES", ((string[])(null)));
#line hidden
        }
    }
}
#pragma warning restore
#endregion
