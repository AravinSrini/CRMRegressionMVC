﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.3.2.0
//      SpecFlow Generator Version:2.3.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace CRM.UITest.Scripts.Quote.LTL.QuoteResultsScreen
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.2.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class InsAllRiskMax_MaxInsuranceAllRiskCalculationFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "InsAllRiskMax_MaxInsuranceAllRiskCalculation.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "InsAllRiskMax_MaxInsuranceAllRiskCalculation", null, ProgrammingLanguage.CSharp, new string[] {
                        "19275",
                        "Sprint62",
                        "InsAllRiskMax_MaxInsuranceAllRiskCalculation"});
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "InsAllRiskMax_MaxInsuranceAllRiskCalculation")))
            {
                global::CRM.UITest.Scripts.Quote.LTL.QuoteResultsScreen.InsAllRiskMax_MaxInsuranceAllRiskCalculationFeature.FeatureSetup(null);
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
        
        public virtual void VerifyInsuranceRateCalculationWhenValueIsEnteredFromShipmentInformationPage(string scenario, string username, string password, string service, string originZip, string originCity, string originState, string destinationZip, string destinationCity, string destinationState, string classification, string weight, string shipmentValue, string additionalService, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "RegressionSuite"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify Insurance rate calculation when value is entered from shipment information" +
                    " page", @__tags);
#line 5
this.ScenarioSetup(scenarioInfo);
#line 6
 testRunner.Given(string.Format("I am a DLS user and login into application with valid {0} and {1}", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 7
 testRunner.And(string.Format("I clicked on {0} button on the select type screen of rate request process", service), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 8
 testRunner.When("I am taken to the new responsive LTL Shipment Information screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 9
    testRunner.And(string.Format("I enter valid data in Origin section {0}, {1} and {2}", originZip, originCity, originState), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
 testRunner.And(string.Format("I enter valid data in Destination section {0}, {1} and {2}", destinationZip, destinationCity, destinationState), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
 testRunner.And(string.Format("I enter valid data in Item section {0}, {1}, {2} and {3}", classification, weight, shipmentValue, additionalService), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
 testRunner.And("I click on view quote results button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
 testRunner.Then("rate results page should be displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 14
 testRunner.And(string.Format("Insurance calculated value {0} should be added for the accessorial of carrier for" +
                        " the passed {1}", username, shipmentValue), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify Insurance rate calculation when value is entered from shipment information" +
            " page: S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "InsAllRiskMax_MaxInsuranceAllRiskCalculation")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("19275")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint62")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("InsAllRiskMax_MaxInsuranceAllRiskCalculation")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RegressionSuite")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Scenario", "S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "nat")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Service", "LTL")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:OriginZip", "33126")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:OriginCity", "Miami")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:OriginState", "FL")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DestinationZip", "85282")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DestinationCity", "Tempe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DestinationState", "AZ")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Classification", "70")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Weight", "100")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ShipmentValue", "1000")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:AdditionalService", "Appointment")]
        public virtual void VerifyInsuranceRateCalculationWhenValueIsEnteredFromShipmentInformationPage_S1()
        {
#line 5
this.VerifyInsuranceRateCalculationWhenValueIsEnteredFromShipmentInformationPage("S1", "nat", "Te$t1234", "LTL", "33126", "Miami", "FL", "85282", "Tempe", "AZ", "70", "100", "1000", "Appointment", ((string[])(null)));
#line hidden
        }
        
        public virtual void VerifyInsuranceRateCalculationWhenValueIsEnteredFromRateResultsPage(string scenario, string username, string password, string service, string originZip, string originCity, string originState, string destinationZip, string destinationCity, string destinationState, string classification, string weight, string shipmentValue, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "RegressionSuite"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify Insurance rate calculation when value is entered from rate results page", @__tags);
#line 21
this.ScenarioSetup(scenarioInfo);
#line 22
 testRunner.Given(string.Format("I am a DLS user and login into application with valid {0} and {1}", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 23
 testRunner.And(string.Format("I clicked on {0} button on the select type screen of rate request process", service), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
 testRunner.When("I am taken to the new responsive LTL Shipment Information screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 25
    testRunner.And(string.Format("I enter valid data in Origin section {0}, {1} and {2}", originZip, originCity, originState), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
 testRunner.And(string.Format("I enter valid data in Destination section {0}, {1} and {2}", destinationZip, destinationCity, destinationState), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
 testRunner.And(string.Format("I enter valid data only in Item section {0}, {1}", classification, weight), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 28
 testRunner.And("I click on view quote results button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
 testRunner.And(string.Format("I enters the value in {0} Textbox", shipmentValue), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
    testRunner.And("I clicks on Show Insured Rate button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 31
 testRunner.Then(string.Format("Insurance calculated value {0} should be added for the accessorial of carrier for" +
                        " the passed {1}", username, shipmentValue), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify Insurance rate calculation when value is entered from rate results page: S" +
            "1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "InsAllRiskMax_MaxInsuranceAllRiskCalculation")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("19275")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint62")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("InsAllRiskMax_MaxInsuranceAllRiskCalculation")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RegressionSuite")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Scenario", "S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "nat")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Service", "LTL")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:OriginZip", "33126")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:OriginCity", "Miami")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:OriginState", "FL")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DestinationZip", "85282")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DestinationCity", "Tempe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DestinationState", "AZ")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Classification", "70")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Weight", "100")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ShipmentValue", "100")]
        public virtual void VerifyInsuranceRateCalculationWhenValueIsEnteredFromRateResultsPage_S1()
        {
#line 21
this.VerifyInsuranceRateCalculationWhenValueIsEnteredFromRateResultsPage("S1", "nat", "Te$t1234", "LTL", "33126", "Miami", "FL", "85282", "Tempe", "AZ", "70", "100", "100", ((string[])(null)));
#line hidden
        }
    }
}
#pragma warning restore
#endregion
