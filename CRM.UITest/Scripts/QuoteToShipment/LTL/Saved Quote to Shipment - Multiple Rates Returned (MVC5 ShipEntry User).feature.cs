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
namespace CRM.UITest.Scripts.QuoteToShipment.LTL
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class SavedQuoteToShipment_MultipleRatesReturnedMVC5ShipEntryUserFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "Saved Quote to Shipment - Multiple Rates Returned (MVC5 ShipEntry User).feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Saved Quote to Shipment - Multiple Rates Returned (MVC5 ShipEntry User)", null, ProgrammingLanguage.CSharp, new string[] {
                        "32308",
                        "Sprint79"});
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "Saved Quote to Shipment - Multiple Rates Returned (MVC5 ShipEntry User)")))
            {
                global::CRM.UITest.Scripts.QuoteToShipment.LTL.SavedQuoteToShipment_MultipleRatesReturnedMVC5ShipEntryUserFeature.FeatureSetup(null);
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
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("32308_Test to verify the Rates Returned (MVC5 ShipEntry User)_Saved Quote to Ship" +
            "ment")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Saved Quote to Shipment - Multiple Rates Returned (MVC5 ShipEntry User)")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("32308")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint79")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        public virtual void _32308_TestToVerifyTheRatesReturnedMVC5ShipEntryUser_SavedQuoteToShipment()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("32308_Test to verify the Rates Returned (MVC5 ShipEntry User)_Saved Quote to Ship" +
                    "ment", new string[] {
                        "Functional"});
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
testRunner.Given("I am a shp.entry user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
testRunner.When("I am on shipment results page of saved quote to shipment process", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 9
testRunner.Then("I should be displayed with the only one carrier which i saved in quote process", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("32308_Test to verify Show Insured Rates functionality_Saved standard Quote to Shi" +
            "pment")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Saved Quote to Shipment - Multiple Rates Returned (MVC5 ShipEntry User)")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("32308")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint79")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        public virtual void _32308_TestToVerifyShowInsuredRatesFunctionality_SavedStandardQuoteToShipment()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("32308_Test to verify Show Insured Rates functionality_Saved standard Quote to Shi" +
                    "pment", new string[] {
                        "Functional"});
#line 13
this.ScenarioSetup(scenarioInfo);
#line 14
testRunner.Given("I am a shp.entry user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 15
testRunner.And("I am on shipment results page of saved standard quote to shipment process", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
testRunner.And("I Enter an insured Value", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
testRunner.When("I click on the Show Insured Rate Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 18
testRunner.Then("insured rate for selected carrier should be displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("32308_Test to verify Show Insured Rates functionality_Saved insured Quote to Ship" +
            "ment")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Saved Quote to Shipment - Multiple Rates Returned (MVC5 ShipEntry User)")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("32308")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint79")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        public virtual void _32308_TestToVerifyShowInsuredRatesFunctionality_SavedInsuredQuoteToShipment()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("32308_Test to verify Show Insured Rates functionality_Saved insured Quote to Ship" +
                    "ment", new string[] {
                        "Functional"});
#line 22
this.ScenarioSetup(scenarioInfo);
#line 23
testRunner.Given("I am a shp.entry user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 24
testRunner.When("I am on shipment results page of saved insured quote to shipment process", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 25
testRunner.Then("insured Value textbox will be non-editable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 26
testRunner.And("Show Insured Rate Button will be non-clickable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
