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
namespace CRM.UITest.Scripts.Quote.RatingLogic
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.2.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class Quotes_RatingLogicAppliedWhenMultipleMGDescriptionsExistFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "Quotes - Rating Logic Applied When Multiple MG Descriptions Exist.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Quotes - Rating Logic Applied When Multiple MG Descriptions Exist", null, ProgrammingLanguage.CSharp, new string[] {
                        "47871",
                        "Sprint85"});
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "Quotes - Rating Logic Applied When Multiple MG Descriptions Exist")))
            {
                global::CRM.UITest.Scripts.Quote.RatingLogic.Quotes_RatingLogicAppliedWhenMultipleMGDescriptionsExistFeature.FeatureSetup(null);
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
        
        public virtual void _47871_TestToVerifyTheCRMRatingLogicAppliedWhenMultipleMGDescriptionExistForAllCarriers(string mGDescription, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "RegressionSuite"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("47871_Test to Verify the CRM rating logic applied when multiple MG Description Ex" +
                    "ist for all carriers", @__tags);
#line 5
this.ScenarioSetup(scenarioInfo);
#line 6
 testRunner.Given("I am a shp.inquiry, shp.entry, sales, sales management, operations, or station ow" +
                    "ner users", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 7
 testRunner.And("I am submitting a rate request for LTL service type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 8
 testRunner.And(string.Format("I selected an accessorial with {0}", mGDescription), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 9
 testRunner.And("the CRM Rating Logic is selected Yes for the customer", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
 testRunner.When("I submit the request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 11
 testRunner.And("CRM receives one of the MG Descriptions of the selected accessorial", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
 testRunner.Then("the Individual Accessorial Charge will be applied to all carrier rates", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("47871_Test to Verify the CRM rating logic applied when multiple MG Description Ex" +
            "ist for all carriers: COD")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Quotes - Rating Logic Applied When Multiple MG Descriptions Exist")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("47871")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint85")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RegressionSuite")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "COD")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:MG Description", "COD")]
        public virtual void _47871_TestToVerifyTheCRMRatingLogicAppliedWhenMultipleMGDescriptionExistForAllCarriers_COD()
        {
#line 5
this._47871_TestToVerifyTheCRMRatingLogicAppliedWhenMultipleMGDescriptionExistForAllCarriers("COD", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("47871_Test to Verify the CRM rating logic applied when multiple MG Description Ex" +
            "ist for all carriers: Liftgate Delivery")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Quotes - Rating Logic Applied When Multiple MG Descriptions Exist")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("47871")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint85")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RegressionSuite")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Liftgate Delivery")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:MG Description", "Liftgate Delivery")]
        public virtual void _47871_TestToVerifyTheCRMRatingLogicAppliedWhenMultipleMGDescriptionExistForAllCarriers_LiftgateDelivery()
        {
#line 5
this._47871_TestToVerifyTheCRMRatingLogicAppliedWhenMultipleMGDescriptionExistForAllCarriers("Liftgate Delivery", ((string[])(null)));
#line hidden
        }
        
        public virtual void _47871_TestToVerifyTheCRMRatingLogicAppliedWhenMultipleMGDescriptionExistForASpecificCarrier(string mGDescription, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "RegressionSuite"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("47871_Test to Verify the CRM rating logic applied when multiple MG Description ex" +
                    "ist for a specific carrier", @__tags);
#line 20
this.ScenarioSetup(scenarioInfo);
#line 21
 testRunner.Given("I am a shp.inquiry, shp.entry, sales, sales management, operations, or station ow" +
                    "ner users", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 22
 testRunner.And("I am submitting a rate request for LTL service type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
 testRunner.And(string.Format("I selected an accessorial with {0}", mGDescription), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
 testRunner.And("the CRM Rating Logic is selected Yes for the customer", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
 testRunner.When("I submit the request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 26
 testRunner.And("CRM receives one of the MG Descriptions of the selected accessorial", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
 testRunner.Then("the Individual Accessorial Charge will be applied to the carrier rate", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("47871_Test to Verify the CRM rating logic applied when multiple MG Description ex" +
            "ist for a specific carrier: COD")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Quotes - Rating Logic Applied When Multiple MG Descriptions Exist")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("47871")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint85")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RegressionSuite")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "COD")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:MG Description", "COD")]
        public virtual void _47871_TestToVerifyTheCRMRatingLogicAppliedWhenMultipleMGDescriptionExistForASpecificCarrier_COD()
        {
#line 20
this._47871_TestToVerifyTheCRMRatingLogicAppliedWhenMultipleMGDescriptionExistForASpecificCarrier("COD", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("47871_Test to Verify the CRM rating logic applied when multiple MG Description ex" +
            "ist for a specific carrier: Liftgate Delivery")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Quotes - Rating Logic Applied When Multiple MG Descriptions Exist")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("47871")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint85")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RegressionSuite")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Liftgate Delivery")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:MG Description", "Liftgate Delivery")]
        public virtual void _47871_TestToVerifyTheCRMRatingLogicAppliedWhenMultipleMGDescriptionExistForASpecificCarrier_LiftgateDelivery()
        {
#line 20
this._47871_TestToVerifyTheCRMRatingLogicAppliedWhenMultipleMGDescriptionExistForASpecificCarrier("Liftgate Delivery", ((string[])(null)));
#line hidden
        }
        
        public virtual void _47871_TestToVerifyTheCRMRatingLogicAppliedWhenNoMGDescriptionExistForAllCarriers(string noMGDescription, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "RegressionSuite"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("47871_Test to Verify the CRM rating logic applied when No MG Description Exist fo" +
                    "r all carriers", @__tags);
#line 35
this.ScenarioSetup(scenarioInfo);
#line 36
 testRunner.Given("I am a shp.inquiry, shp.entry, sales, sales management, operations, or station ow" +
                    "ner users", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 37
 testRunner.And("I am submitting a rate request for LTL service type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 38
 testRunner.And(string.Format("I selected an accessorial with {0}", noMGDescription), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 39
 testRunner.And("the CRM Rating Logic is selected Yes for the customer", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 40
 testRunner.When("I submit the request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 41
 testRunner.Then("the Individual Accessorial Charge will not be applied to all carrier rates", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("47871_Test to Verify the CRM rating logic applied when No MG Description Exist fo" +
            "r all carriers: ")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Quotes - Rating Logic Applied When Multiple MG Descriptions Exist")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("47871")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint85")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RegressionSuite")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:No MG Description", "")]
        public virtual void _47871_TestToVerifyTheCRMRatingLogicAppliedWhenNoMGDescriptionExistForAllCarriers_()
        {
#line 35
this._47871_TestToVerifyTheCRMRatingLogicAppliedWhenNoMGDescriptionExistForAllCarriers("", ((string[])(null)));
#line hidden
        }
        
        public virtual void _47871_TestToVerifyTheCRMRatingLogicAppliedWhenNoMGDescriptionExistForASpecificCarrier(string noMGDescription, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "RegressionSuite"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("47871_Test to Verify the CRM rating logic applied when No MG Description exist fo" +
                    "r a specific carrier", @__tags);
#line 48
this.ScenarioSetup(scenarioInfo);
#line 49
 testRunner.Given("I am a shp.inquiry, shp.entry, sales, sales management, operations, or station ow" +
                    "ner users", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 50
 testRunner.And("I am submitting a rate request for LTL service type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 51
 testRunner.And(string.Format("I selected an accessorial with {0}", noMGDescription), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 52
 testRunner.And("the CRM Rating Logic is selected Yes for the customer", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
 testRunner.When("I submit the request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 54
 testRunner.Then("the Individual Accessorial Charge will not be applied to the carrier rate", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("47871_Test to Verify the CRM rating logic applied when No MG Description exist fo" +
            "r a specific carrier: ")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Quotes - Rating Logic Applied When Multiple MG Descriptions Exist")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("47871")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint85")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RegressionSuite")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:No MG Description", "")]
        public virtual void _47871_TestToVerifyTheCRMRatingLogicAppliedWhenNoMGDescriptionExistForASpecificCarrier_()
        {
#line 48
this._47871_TestToVerifyTheCRMRatingLogicAppliedWhenNoMGDescriptionExistForASpecificCarrier("", ((string[])(null)));
#line hidden
        }
    }
}
#pragma warning restore
#endregion
