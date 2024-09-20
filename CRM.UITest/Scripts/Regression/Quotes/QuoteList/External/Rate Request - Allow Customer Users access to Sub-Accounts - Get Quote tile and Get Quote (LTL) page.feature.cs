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
namespace CRM.UITest.Scripts.Regression.Quotes.QuoteList.External
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.2.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class RateRequest_AllowCustomerUsersAccessToSub_Accounts_GetQuoteTileAndGetQuoteLTLPageFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "Rate Request - Allow Customer Users access to Sub-Accounts - Get Quote tile and Get Quote (LTL) page.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Rate Request - Allow Customer Users access to Sub-Accounts - Get Quote tile and G" +
                    "et Quote (LTL) page", null, ProgrammingLanguage.CSharp, new string[] {
                        "Regression",
                        "Quote",
                        "29507",
                        "NinjaSprint16"});
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "Rate Request - Allow Customer Users access to Sub-Accounts - Get Quote tile and G" +
                            "et Quote (LTL) page")))
            {
                global::CRM.UITest.Scripts.Regression.Quotes.QuoteList.External.RateRequest_AllowCustomerUsersAccessToSub_Accounts_GetQuoteTileAndGetQuoteLTLPageFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("29507_Test to verify Get Quote tile navigation when user selects the primary acco" +
            "unt of MG")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Rate Request - Allow Customer Users access to Sub-Accounts - Get Quote tile and G" +
            "et Quote (LTL) page")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Quote")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("29507")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("NinjaSprint16")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Acceptance")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        public virtual void _29507_TestToVerifyGetQuoteTileNavigationWhenUserSelectsThePrimaryAccountOfMG()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("29507_Test to verify Get Quote tile navigation when user selects the primary acco" +
                    "unt of MG", new string[] {
                        "Acceptance",
                        "GUI",
                        "Functional"});
#line 5
this.ScenarioSetup(scenarioInfo);
#line 6
        testRunner.Given("I am a shp.entry or shp.inquiry user associated to a primary account of TmsType M" +
                    "G that has sub-accounts", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 7
        testRunner.And("I am on the QuoteList page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 8
  testRunner.And("I select primary-Customer ZZZ - Czar Customer Test from the customer drop down li" +
                    "st of QuoteList page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 9
        testRunner.When("I click on Submit Rate Request button in Quotes page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
        testRunner.Then("I will arrive on the Get Quote tile page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 11
        testRunner.And("I will see the associated service type selections for TmsType Mg", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
  testRunner.And("I will see the customer name displayed on the Get Quote tile page ZZZ - Czar Cust" +
                    "omer Test", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("29507_Test to verify Get Quote tile navigation when user selects the primary acco" +
            "unt of Tms type Both")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Rate Request - Allow Customer Users access to Sub-Accounts - Get Quote tile and G" +
            "et Quote (LTL) page")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Quote")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("29507")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("NinjaSprint16")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Acceptance")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        public virtual void _29507_TestToVerifyGetQuoteTileNavigationWhenUserSelectsThePrimaryAccountOfTmsTypeBoth()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("29507_Test to verify Get Quote tile navigation when user selects the primary acco" +
                    "unt of Tms type Both", new string[] {
                        "Acceptance",
                        "GUI",
                        "Functional"});
#line 15
this.ScenarioSetup(scenarioInfo);
#line 16
        testRunner.Given("I am a shp.entry or shp.inquiry user associated to a primary account of TmsType B" +
                    "oth that has sub-accounts", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 17
        testRunner.And("I am on the QuoteList page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
  testRunner.And("I select primary-Customer ZZZ - GS Customer Test from the customer drop down list" +
                    " of QuoteList page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
        testRunner.When("I click on Submit Rate Request button in Quotes page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 20
        testRunner.Then("I will arrive on the Get Quote tile page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 21
        testRunner.And("I will see the associated service type selections for TmsType Both", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
  testRunner.And("I will see the customer name displayed on the Get Quote tile page ZZZ - GS Custom" +
                    "er Test", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("29507_Test to verify Get Quote tile navigation when user selects the sub account " +
            "of TmsType MG")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Rate Request - Allow Customer Users access to Sub-Accounts - Get Quote tile and G" +
            "et Quote (LTL) page")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Quote")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("29507")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("NinjaSprint16")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Acceptance")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        public virtual void _29507_TestToVerifyGetQuoteTileNavigationWhenUserSelectsTheSubAccountOfTmsTypeMG()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("29507_Test to verify Get Quote tile navigation when user selects the sub account " +
                    "of TmsType MG", new string[] {
                        "Acceptance",
                        "GUI",
                        "Functional"});
#line 25
this.ScenarioSetup(scenarioInfo);
#line 26
        testRunner.Given("I am a shp.entry or shp.inquiry user associated to a primary account of TmsType M" +
                    "G that has sub-accounts", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 27
        testRunner.And("I am on the QuoteList page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 28
  testRunner.And("I select sub-Customer SubAccountOfTypeMg from the customer drop down list of Quot" +
                    "eList page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
        testRunner.When("I click on Submit Rate Request button in Quotes page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 30
        testRunner.Then("I will arrive on the Get Quote tile page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 31
        testRunner.And("I will see only LTL service type option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
        testRunner.And("I will see the customer name displayed on the Get Quote tile page ZZZ - Czar Cust" +
                    "omer Test - SubAccountOfTypeMg", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("29507_Test to verify Get Quote tile navigation when user selects the sub account " +
            "of TmsType both")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Rate Request - Allow Customer Users access to Sub-Accounts - Get Quote tile and G" +
            "et Quote (LTL) page")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Quote")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("29507")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("NinjaSprint16")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Acceptance")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        public virtual void _29507_TestToVerifyGetQuoteTileNavigationWhenUserSelectsTheSubAccountOfTmsTypeBoth()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("29507_Test to verify Get Quote tile navigation when user selects the sub account " +
                    "of TmsType both", new string[] {
                        "Acceptance",
                        "GUI",
                        "Functional"});
#line 35
this.ScenarioSetup(scenarioInfo);
#line 36
        testRunner.Given("I am a shp.entry or shp.inquiry user associated to a primary account of TmsType M" +
                    "G that has sub-accounts", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 37
        testRunner.And("I am on the QuoteList page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 38
  testRunner.And("I select sub-Customer SubAccountOfTypeBoth from the customer drop down list of Qu" +
                    "oteList page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 39
        testRunner.When("I click on Submit Rate Request button in Quotes page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 40
        testRunner.Then("I will arrive on the Get Quote tile page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 41
        testRunner.And("I will see only LTL service type option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 42
        testRunner.And("I will see the customer name displayed on the Get Quote tile page ZZZ - Czar Cust" +
                    "omer Test - SubAccountOfTypeBoth", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("29507_Test to verify Get Quote (LTL) page navigations when user selects the prima" +
            "ry account of MG or both type")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Rate Request - Allow Customer Users access to Sub-Accounts - Get Quote tile and G" +
            "et Quote (LTL) page")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Quote")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("29507")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("NinjaSprint16")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Acceptance")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        public virtual void _29507_TestToVerifyGetQuoteLTLPageNavigationsWhenUserSelectsThePrimaryAccountOfMGOrBothType()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("29507_Test to verify Get Quote (LTL) page navigations when user selects the prima" +
                    "ry account of MG or both type", new string[] {
                        "Acceptance",
                        "GUI",
                        "Functional"});
#line 45
this.ScenarioSetup(scenarioInfo);
#line 46
        testRunner.Given("I am a shp.entry or shp.inquiry user associated to a primary account that has sub" +
                    "-accounts", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 47
        testRunner.And("I am on the Get Quote Tile page for a primary customer ZZZ - Czar Customer Test", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 48
        testRunner.When("I will click on LTL tile", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 49
        testRunner.Then("I will arrive on the Get Quote (LTL) page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 50
        testRunner.And("I will see the customer name displayed on the Get Quote (LTL) page ZZZ - Czar Cus" +
                    "tomer Test", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("29507_Test to verify Get Quote (LTL) page navigations when user selects the sub a" +
            "ccount of MG or both type")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Rate Request - Allow Customer Users access to Sub-Accounts - Get Quote tile and G" +
            "et Quote (LTL) page")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Quote")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("29507")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("NinjaSprint16")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Acceptance")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        public virtual void _29507_TestToVerifyGetQuoteLTLPageNavigationsWhenUserSelectsTheSubAccountOfMGOrBothType()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("29507_Test to verify Get Quote (LTL) page navigations when user selects the sub a" +
                    "ccount of MG or both type", new string[] {
                        "Acceptance",
                        "GUI",
                        "Functional"});
#line 53
this.ScenarioSetup(scenarioInfo);
#line 54
        testRunner.Given("I am a shp.entry or shp.inquiry user associated to a primary account that has sub" +
                    "-accounts", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 55
        testRunner.And("I am on the Get Quote Tile page for a sub customer SubAccountOfTypeBoth", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 56
        testRunner.When("I will click on LTL tile", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 57
        testRunner.Then("I will arrive on the Get Quote (LTL) page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 58
        testRunner.And("I will see the customer name displayed on the Get Quote (LTL) page ZZZ - Czar Cus" +
                    "tomer Test - SubAccountOfTypeBoth", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
