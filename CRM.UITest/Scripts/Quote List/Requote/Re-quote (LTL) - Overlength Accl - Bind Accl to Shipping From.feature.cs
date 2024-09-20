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
namespace CRM.UITest.Scripts.QuoteList.Requote
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.2.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class Re_QuoteLTL_OverlengthAccl_BindAcclToShippingFromFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "Re-quote (LTL) - Overlength Accl - Bind Accl to Shipping From.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Re-quote (LTL) - Overlength Accl - Bind Accl to Shipping From", null, ProgrammingLanguage.CSharp, new string[] {
                        "48512",
                        "Sprint87"});
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "Re-quote (LTL) - Overlength Accl - Bind Accl to Shipping From")))
            {
                global::CRM.UITest.Scripts.QuoteList.Requote.Re_QuoteLTL_OverlengthAccl_BindAcclToShippingFromFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("48512_Verify the Overlength Accessorial binded in Shipment Information Page while" +
            " doing Re-Quote")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Re-quote (LTL) - Overlength Accl - Bind Accl to Shipping From")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("48512")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint87")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        public virtual void _48512_VerifyTheOverlengthAccessorialBindedInShipmentInformationPageWhileDoingRe_Quote()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("48512_Verify the Overlength Accessorial binded in Shipment Information Page while" +
                    " doing Re-Quote", new string[] {
                        "Functional"});
#line 5
this.ScenarioSetup(scenarioInfo);
#line 6
 testRunner.Given("I am a shp.inquiry, shp.entry, sales, sales management, operations, or station ow" +
                    "ner users", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 7
 testRunner.And("I am in the Quote Details of an expired quote", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 8
 testRunner.And("the expired quote had an Overlength accessorial", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 9
 testRunner.When("i click on the Re-quote button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
 testRunner.Then("I will see an accessorial Overlength selected in the Shipping From section of Get" +
                    " Quote (LTL) Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("48512_Verify the non overlength Accessorial binded in Shipment Information Page w" +
            "hile doing Re-Quote")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Re-quote (LTL) - Overlength Accl - Bind Accl to Shipping From")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("48512")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint87")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        public virtual void _48512_VerifyTheNonOverlengthAccessorialBindedInShipmentInformationPageWhileDoingRe_Quote()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("48512_Verify the non overlength Accessorial binded in Shipment Information Page w" +
                    "hile doing Re-Quote", new string[] {
                        "Functional"});
#line 13
this.ScenarioSetup(scenarioInfo);
#line 14
 testRunner.Given("I am a shp.inquiry, shp.entry, sales, sales management, operations, or station ow" +
                    "ner users", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 15
 testRunner.And("I am in the Quote Details of an expired quote other than overlength", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
 testRunner.And("the expired quote had an accessorial", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
 testRunner.When("i click on the Re-quote button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 18
 testRunner.Then("I will see the selected accessorial in the Shipping From section of Get Quote (LT" +
                    "L) Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
