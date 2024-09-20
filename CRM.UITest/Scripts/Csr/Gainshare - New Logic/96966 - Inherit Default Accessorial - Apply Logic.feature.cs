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
namespace CRM.UITest.Scripts.Csr.Gainshare_NewLogic
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.2.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class _96966_InheritDefaultAccessorial_ApplyLogicFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "96966 - Inherit Default Accessorial - Apply Logic.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "96966 - Inherit Default Accessorial - Apply Logic", null, ProgrammingLanguage.CSharp, new string[] {
                        "NinjaSprint34",
                        "96966"});
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "96966 - Inherit Default Accessorial - Apply Logic")))
            {
                global::CRM.UITest.Scripts.Csr.Gainshare_NewLogic._96966_InheritDefaultAccessorial_ApplyLogicFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("96966 - CSR Created with Gainshare New Logic has CRM Rating Logic turned On MG")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "96966 - Inherit Default Accessorial - Apply Logic")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("NinjaSprint34")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("96966")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("96966NewGainshareLogicYesDeleteCustomer")]
        public virtual void _96966_CSRCreatedWithGainshareNewLogicHasCRMRatingLogicTurnedOnMG()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("96966 - CSR Created with Gainshare New Logic has CRM Rating Logic turned On MG", new string[] {
                        "96966NewGainshareLogicYesDeleteCustomer"});
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
 testRunner.Given("I am a sales, sales management, operations, station owner, pricing config, or sys" +
                    "tem config user \"username-CurrentSprintconfigmanager\" \"password-CurrentSprintcon" +
                    "figmanager\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
 testRunner.And("I am submitting a new csr", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 9
 testRunner.And("I am on the Pricing Model page for a new CSR \"96966 New Gainshare Logic is Yes MG" +
                    "\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
 testRunner.And("I choose Gainshare from the Select A Pricing Type drop down list", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
 testRunner.And("I check the Gainshare - New Logic checkbox", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
 testRunner.And("I arrive on the Review and Submit page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
 testRunner.When("I Submit and approve the CSR \"96966 New Gainshare Logic is Yes MG\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 14
 testRunner.Then("the value of New CRM Rating Logic in the database will be true for customer \"9696" +
                    "6 New Gainshare Logic is Yes MG\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("96966 - CSR Created without Gainshare New Logic has CRM Rating Logic turned Off M" +
            "G")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "96966 - Inherit Default Accessorial - Apply Logic")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("NinjaSprint34")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("96966")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("96966NewGainshareLogicNoDeleteCustomer")]
        public virtual void _96966_CSRCreatedWithoutGainshareNewLogicHasCRMRatingLogicTurnedOffMG()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("96966 - CSR Created without Gainshare New Logic has CRM Rating Logic turned Off M" +
                    "G", new string[] {
                        "96966NewGainshareLogicNoDeleteCustomer"});
#line 17
this.ScenarioSetup(scenarioInfo);
#line 18
 testRunner.Given("I am a sales, sales management, operations, station owner, pricing config, or sys" +
                    "tem config user \"username-CurrentSprintconfigmanager\" \"password-CurrentSprintcon" +
                    "figmanager\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 19
 testRunner.And("I am submitting a new csr", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
 testRunner.And("I am on the Pricing Model page for a new CSR \"96966 New Gainshare Logic is No MG\"" +
                    "", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
 testRunner.And("I choose Gainshare from the Select A Pricing Type drop down list", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
 testRunner.And("I arrive on the Review and Submit page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
 testRunner.When("I Submit and approve the CSR \"96966 New Gainshare Logic is No MG\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 24
 testRunner.Then("the value of New CRM Rating Logic in the database will be false for customer \"969" +
                    "66 New Gainshare Logic is No MG\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("96966 - CSR Created With Gainshare New Logic turned Off then Revised to turn Gain" +
            "share New Logic On has CRM Rating Logic turned On MG")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "96966 - Inherit Default Accessorial - Apply Logic")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("NinjaSprint34")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("96966")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("96966TurnOffGainshareLogicForCustomer")]
        public virtual void _96966_CSRCreatedWithGainshareNewLogicTurnedOffThenRevisedToTurnGainshareNewLogicOnHasCRMRatingLogicTurnedOnMG()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("96966 - CSR Created With Gainshare New Logic turned Off then Revised to turn Gain" +
                    "share New Logic On has CRM Rating Logic turned On MG", new string[] {
                        "96966TurnOffGainshareLogicForCustomer"});
#line 27
this.ScenarioSetup(scenarioInfo);
#line 28
 testRunner.Given("I am a sales, sales management, operations, station owner, pricing config, or sys" +
                    "tem config user \"username-CurrentSprintconfigmanager\" \"password-CurrentSprintcon" +
                    "figmanager\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 29
 testRunner.And("I am submitting a revised csr for customer \"96966 New Gainshare Logic No Revised\"" +
                    "", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
 testRunner.And("I am on the Pricing Model page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 31
 testRunner.And("I set Gainshare - New Logic to Yes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
 testRunner.And("I arrive on the Review and Submit page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
 testRunner.When("I Submit and approve the CSR \"96966 New Gainshare Logic No Revised\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 34
 testRunner.Then("the value of New CRM Rating Logic in the database will be true for customer \"9696" +
                    "6 New Gainshare Logic No Revised\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("96966 - CSR Created With Gainshare New Logic turned Off then Revised to turn Gain" +
            "share New Logic On has CRM Rating Logic turned On CSA")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "96966 - Inherit Default Accessorial - Apply Logic")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("NinjaSprint34")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("96966")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("96966TurnOffGainshareLogicForCustomer")]
        public virtual void _96966_CSRCreatedWithGainshareNewLogicTurnedOffThenRevisedToTurnGainshareNewLogicOnHasCRMRatingLogicTurnedOnCSA()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("96966 - CSR Created With Gainshare New Logic turned Off then Revised to turn Gain" +
                    "share New Logic On has CRM Rating Logic turned On CSA", new string[] {
                        "96966TurnOffGainshareLogicForCustomer"});
#line 37
this.ScenarioSetup(scenarioInfo);
#line 38
 testRunner.Given("I am a sales, sales management, operations, station owner, pricing config, or sys" +
                    "tem config user \"username-CurrentSprintconfigmanager\" \"password-CurrentSprintcon" +
                    "figmanager\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 39
 testRunner.And("I am submitting a revised csr for customer \"96966 New Gainshare Logic No Revised " +
                    "CSA\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 40
 testRunner.And("I am on the Pricing Model page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 41
 testRunner.And("I set Gainshare - New Logic to Yes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 42
 testRunner.And("I arrive on the Review and Submit page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 43
 testRunner.When("I Submit and approve the CSR \"96966 New Gainshare Logic No Revised CSA\" for CSA", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 44
 testRunner.Then("the value of New CRM Rating Logic in the database will be true for customer \"9696" +
                    "6 New Gainshare Logic No Revised CSA\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("96966 - CSR Created With Gainshare New Logic turned On then Revised to turn Gains" +
            "hare New Logic Off has CRM Rating Logic turned Off MG")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "96966 - Inherit Default Accessorial - Apply Logic")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("NinjaSprint34")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("96966")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("96966TurnOnGainshareLogicForCustomer")]
        public virtual void _96966_CSRCreatedWithGainshareNewLogicTurnedOnThenRevisedToTurnGainshareNewLogicOffHasCRMRatingLogicTurnedOffMG()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("96966 - CSR Created With Gainshare New Logic turned On then Revised to turn Gains" +
                    "hare New Logic Off has CRM Rating Logic turned Off MG", new string[] {
                        "96966TurnOnGainshareLogicForCustomer"});
#line 47
this.ScenarioSetup(scenarioInfo);
#line 48
 testRunner.Given("I am a sales, sales management, operations, station owner, pricing config, or sys" +
                    "tem config user \"username-CurrentSprintconfigmanager\" \"password-CurrentSprintcon" +
                    "figmanager\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 49
 testRunner.And("I am submitting a revised csr for customer \"96966 New Gainshare Logic Yes Revised" +
                    "\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 50
 testRunner.And("I am on the Pricing Model page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 51
 testRunner.And("I set Gainshare - New Logic to No", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 52
 testRunner.And("I arrive on the Review and Submit page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
 testRunner.When("I Submit and approve the CSR \"96966 New Gainshare Logic Yes Revised\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 54
 testRunner.Then("the value of New CRM Rating Logic in the database will be false for customer \"969" +
                    "66 New Gainshare Logic Yes Revised\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("96966 - CSR Created With Gainshare New Logic turned On then Revised to turn Gains" +
            "hare New Logic Off has CRM Rating Logic turned Off CSA")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "96966 - Inherit Default Accessorial - Apply Logic")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("NinjaSprint34")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("96966")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("96966TurnOnGainshareLogicForCustomer")]
        public virtual void _96966_CSRCreatedWithGainshareNewLogicTurnedOnThenRevisedToTurnGainshareNewLogicOffHasCRMRatingLogicTurnedOffCSA()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("96966 - CSR Created With Gainshare New Logic turned On then Revised to turn Gains" +
                    "hare New Logic Off has CRM Rating Logic turned Off CSA", new string[] {
                        "96966TurnOnGainshareLogicForCustomer"});
#line 57
this.ScenarioSetup(scenarioInfo);
#line 58
 testRunner.Given("I am a sales, sales management, operations, station owner, pricing config, or sys" +
                    "tem config user \"username-CurrentSprintconfigmanager\" \"password-CurrentSprintcon" +
                    "figmanager\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 59
 testRunner.And("I am submitting a revised csr for customer \"96966 New Gainshare Logic Yes Revised" +
                    " CSA\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 60
 testRunner.And("I am on the Pricing Model page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 61
 testRunner.And("I set Gainshare - New Logic to No", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 62
 testRunner.And("I arrive on the Review and Submit page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 63
 testRunner.When("I Submit and approve the CSR \"96966 New Gainshare Logic Yes Revised CSA\" for CSA", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 64
 testRunner.Then("the value of New CRM Rating Logic in the database will be false for customer \"969" +
                    "66 New Gainshare Logic Yes Revised CSA\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
