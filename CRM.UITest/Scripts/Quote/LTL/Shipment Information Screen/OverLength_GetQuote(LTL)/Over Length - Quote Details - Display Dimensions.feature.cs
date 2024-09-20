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
namespace CRM.UITest.Scripts.Quote.LTL.ShipmentInformationScreen.OverLength_GetQuoteLTL
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.2.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class OverLength_QuoteDetails_DisplayDimensionsFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "Over Length - Quote Details - Display Dimensions.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Over Length - Quote Details - Display Dimensions", null, ProgrammingLanguage.CSharp, new string[] {
                        "Sprint80",
                        "40781"});
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "Over Length - Quote Details - Display Dimensions")))
            {
                global::CRM.UITest.Scripts.Quote.LTL.ShipmentInformationScreen.OverLength_GetQuoteLTL.OverLength_QuoteDetails_DisplayDimensionsFeature.FeatureSetup(null);
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
        
        public virtual void FeatureBackground()
        {
#line 4
#line 5
testRunner.Given("I am a shp.inquiry, shp.entry, operations, sales, sales management, or station ow" +
                    "ner user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("40781_Verify the Dimensions type and values in Quote Details section of Quote Lis" +
            "t page_with Dimensions")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Over Length - Quote Details - Display Dimensions")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint80")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("40781")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RegressionSuite")]
        public virtual void _40781_VerifyTheDimensionsTypeAndValuesInQuoteDetailsSectionOfQuoteListPage_WithDimensions()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("40781_Verify the Dimensions type and values in Quote Details section of Quote Lis" +
                    "t page_with Dimensions", new string[] {
                        "RegressionSuite"});
#line 8
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 9
testRunner.When("I am Quote Details section of saved quote with Dimensions", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
testRunner.Then("Dimensions column will be displayed between the Classification and NMFC", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 11
testRunner.And("dimensions L W H will be displayed in bold in Quote Details", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
testRunner.And("the values displayed next to L W H and dimensions type in Quote Details", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("40781_Verify the Dimensions types,values displayed in Quote Details section of Qu" +
            "ote List page_without Dimensions")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Over Length - Quote Details - Display Dimensions")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint80")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("40781")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RegressionSuite")]
        public virtual void _40781_VerifyTheDimensionsTypesValuesDisplayedInQuoteDetailsSectionOfQuoteListPage_WithoutDimensions()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("40781_Verify the Dimensions types,values displayed in Quote Details section of Qu" +
                    "ote List page_without Dimensions", new string[] {
                        "RegressionSuite"});
#line 15
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 16
testRunner.When("I am Quote Details section of saved quote without Dimensions", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 17
testRunner.Then("Dimensions column will be displayed between the Classification and NMFC", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 18
testRunner.And("dimensions L W H will be displayed in bold in Quote Details", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
testRunner.And("\'--\' displayed next to L W H and dimensions type in Quote Details", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
