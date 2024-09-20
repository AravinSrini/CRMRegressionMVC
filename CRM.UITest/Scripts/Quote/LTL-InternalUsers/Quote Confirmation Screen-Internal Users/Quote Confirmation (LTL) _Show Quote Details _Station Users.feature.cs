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
namespace CRM.UITest.Scripts.Quote.LTL_InternalUsers.QuoteConfirmationScreen_InternalUsers
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.2.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class QuoteConfirmationLTL_ShowQuoteDetails_StationUsersFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "Quote Confirmation (LTL) _Show Quote Details _Station Users.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Quote Confirmation (LTL) _Show Quote Details _Station Users", null, ProgrammingLanguage.CSharp, new string[] {
                        "26523",
                        "Get",
                        "Quote_Page",
                        "Elements",
                        "Sprint67"});
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "Quote Confirmation (LTL) _Show Quote Details _Station Users")))
            {
                global::CRM.UITest.Scripts.Quote.LTL_InternalUsers.QuoteConfirmationScreen_InternalUsers.QuoteConfirmationLTL_ShowQuoteDetails_StationUsersFeature.FeatureSetup(null);
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
        
        public virtual void _26523_TestToVerifyQuoteAmountSectionConfirmationPageWhenStandardRatesSelected(string customer_Name, string shippingFrom, string shippingTo, string classification, string weight, string quoteConfirmationpageText, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "RegressionSuite"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("26523_Test to verify Quote Amount section confirmation page when standard  rates " +
                    "selected", @__tags);
#line 5
this.ScenarioSetup(scenarioInfo);
#line 6
   testRunner.Given("I am a shp.inquiry, shp.entry, sales, sales management, operations, or station ow" +
                    "ner", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 7
   testRunner.And("I click on the Quote Icon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 8
   testRunner.And(string.Format("I have select the {0} from customer dropdown list", customer_Name), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 9
   testRunner.And("I have clicked on Submit Rate Request button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
   testRunner.And("I have clicked on LTL Tile of rate request process", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
   testRunner.When("I am taken to the new responsive LTL Shipment Information screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 12
   testRunner.And(string.Format("I have entered valid zipcode {0} in Shipping From section", shippingFrom), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
   testRunner.And(string.Format("I have entered valid zipcode {0} in Shipping To section", shippingTo), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
   testRunner.And(string.Format("I enter valid data in Item information section {0}, {1}", classification, weight), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
   testRunner.And("I Click on view quote results button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
   testRunner.And("I click on save rate as quote link  for selected carrier in resultsint page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
   testRunner.Then(string.Format("I will be navigated to quote confirmation page \'{0}\'", quoteConfirmationpageText), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 18
   testRunner.And("I click on Show Quote Details link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
   testRunner.And("I will see Quote Amount section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
   testRunner.And("I should be displayed with quote amount", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
   testRunner.And("I should be displayed with Est Cost", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
   testRunner.And("I should be displayed with Est Margin", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("26523_Test to verify Quote Amount section confirmation page when standard  rates " +
            "selected: ZZZ - GS Customer Test")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Quote Confirmation (LTL) _Show Quote Details _Station Users")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("26523")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Get")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Quote_Page")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Elements")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint67")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RegressionSuite")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "ZZZ - GS Customer Test")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Customer_Name", "ZZZ - GS Customer Test")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ShippingFrom", "33126")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ShippingTo", "60563")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Classification", "60")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Weight", "800")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:QuoteConfirmationpageText", "Quote Confirmation")]
        public virtual void _26523_TestToVerifyQuoteAmountSectionConfirmationPageWhenStandardRatesSelected_ZZZ_GSCustomerTest()
        {
#line 5
this._26523_TestToVerifyQuoteAmountSectionConfirmationPageWhenStandardRatesSelected("ZZZ - GS Customer Test", "33126", "60563", "60", "800", "Quote Confirmation", ((string[])(null)));
#line hidden
        }
        
        public virtual void _26523_TestToVerifyQuoteAmountSectionConfirmationPageWhenInsuredRatesSelected(string customer_Name, string shippingFrom, string shippingTo, string classification, string weight, string quoteConfirmationpageText, string insuredvalue, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "RegressionSuite"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("26523_Test to verify Quote Amount section confirmation page when insured rates se" +
                    "lected", @__tags);
#line 29
this.ScenarioSetup(scenarioInfo);
#line 30
   testRunner.Given("I am a shp.inquiry, shp.entry, sales, sales management, operations, or station ow" +
                    "ner", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 31
   testRunner.And("I click on the Quote Icon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
   testRunner.And(string.Format("I have select the {0} from customer dropdown list", customer_Name), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
   testRunner.And("I have clicked on Submit Rate Request button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 34
   testRunner.And("I have clicked on LTL Tile of rate request process", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 35
   testRunner.When("I am taken to the new responsive LTL Shipment Information screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 36
   testRunner.And(string.Format("I have entered valid zipcode {0} in Shipping From section", shippingFrom), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 37
   testRunner.And(string.Format("I have entered valid zipcode {0} in Shipping To section", shippingTo), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 38
   testRunner.And(string.Format("I enter valid data in Item information section {0}, {1}", classification, weight), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 39
   testRunner.And(string.Format("I enter data in {0} field", insuredvalue), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 40
   testRunner.And("I Click on view quote results button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 41
   testRunner.And("I click on save insured rate as quote link  for selected carrierinternaluser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 42
   testRunner.Then(string.Format("I will be navigated to quote confirmation page \'{0}\'", quoteConfirmationpageText), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 43
   testRunner.And("I click on Show Quote Details link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 44
   testRunner.And("I will see Quote Amount section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 45
   testRunner.And("I should be displayed with quote amount", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 46
   testRunner.And("I should be displayed with Est Cost", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 47
   testRunner.And("I should be displayed with Est Margin", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("26523_Test to verify Quote Amount section confirmation page when insured rates se" +
            "lected: ZZZ - GS Customer Test")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Quote Confirmation (LTL) _Show Quote Details _Station Users")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("26523")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Get")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Quote_Page")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Elements")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint67")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RegressionSuite")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "ZZZ - GS Customer Test")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Customer_Name", "ZZZ - GS Customer Test")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ShippingFrom", "33126")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ShippingTo", "60563")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Classification", "60")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Weight", "800")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:QuoteConfirmationpageText", "Quote Confirmation")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Insuredvalue", "100")]
        public virtual void _26523_TestToVerifyQuoteAmountSectionConfirmationPageWhenInsuredRatesSelected_ZZZ_GSCustomerTest()
        {
#line 29
this._26523_TestToVerifyQuoteAmountSectionConfirmationPageWhenInsuredRatesSelected("ZZZ - GS Customer Test", "33126", "60563", "60", "800", "Quote Confirmation", "100", ((string[])(null)));
#line hidden
        }
        
        public virtual void _26523_TestToVerifyFieldsInQuoteAmountSectionConfirmationPageWhenGuaranteedRatesSelected(string customer_Name, string shippingFrom, string shippingTo, string classification, string weight, string quoteConfirmationpageText, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "RegressionSuite"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("26523_Test to verify  fields in Quote Amount section confirmation page when guara" +
                    "nteed  rates selected", @__tags);
#line 54
   this.ScenarioSetup(scenarioInfo);
#line 55
   testRunner.Given("I am a shp.inquiry, shp.entry, sales, sales management, operations, or station ow" +
                    "ner", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 56
   testRunner.And("I click on the Quote Icon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 57
   testRunner.And(string.Format("I have select the {0} from customer dropdown list", customer_Name), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 58
   testRunner.And("I have clicked on Submit Rate Request button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 59
   testRunner.And("I have clicked on LTL Tile of rate request process", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 60
   testRunner.When("I am taken to the new responsive LTL Shipment Information screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 61
   testRunner.And(string.Format("I have entered valid zipcode {0} in Shipping From section", shippingFrom), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 62
   testRunner.And(string.Format("I have entered valid zipcode {0} in Shipping To section", shippingTo), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 63
   testRunner.And(string.Format("I enter valid data in Item information section {0}, {1}", classification, weight), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 64
   testRunner.And("I Click on view quote results button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 65
   testRunner.And("I will be navigated to Guaranteed Rate carriers grid", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 66
   testRunner.And("I click on guaranteed save rate as quote link  for selected carrierintuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 67
   testRunner.Then(string.Format("I will be navigated to quote confirmation page \'{0}\'", quoteConfirmationpageText), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 68
   testRunner.And("I click on Show Quote Details link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 69
   testRunner.And("I will see Quote Amount section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 70
   testRunner.And("I should be displayed with quote amount", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 71
   testRunner.And("I should be displayed with Est Cost", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 72
   testRunner.And("I should be displayed with Est Margin", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("26523_Test to verify  fields in Quote Amount section confirmation page when guara" +
            "nteed  rates selected: ZZZ - GS Customer Test")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Quote Confirmation (LTL) _Show Quote Details _Station Users")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("26523")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Get")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Quote_Page")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Elements")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint67")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RegressionSuite")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "ZZZ - GS Customer Test")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Customer_Name", "ZZZ - GS Customer Test")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ShippingFrom", "33126")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ShippingTo", "60563")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Classification", "60")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Weight", "800")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:QuoteConfirmationpageText", "Quote Confirmation")]
        public virtual void _26523_TestToVerifyFieldsInQuoteAmountSectionConfirmationPageWhenGuaranteedRatesSelected_ZZZ_GSCustomerTest()
        {
#line 54
   this._26523_TestToVerifyFieldsInQuoteAmountSectionConfirmationPageWhenGuaranteedRatesSelected("ZZZ - GS Customer Test", "33126", "60563", "60", "800", "Quote Confirmation", ((string[])(null)));
#line hidden
        }
        
        public virtual void _26523_TestToVerifyFieldsInQuoteAmountSectionConfirmationPageWhenGuaranteedInsuredRatesSelected(string customer_Name, string shippingFrom, string shippingTo, string classification, string weight, string quoteConfirmationpageText, string insuredvalue, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "RegressionSuite"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("26523_Test to verify  fields in Quote Amount section confirmation page when guara" +
                    "nteed insured rates selected", @__tags);
#line 79
this.ScenarioSetup(scenarioInfo);
#line 80
   testRunner.Given("I am a shp.inquiry, shp.entry, sales, sales management, operations, or station ow" +
                    "ner", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 81
   testRunner.And("I click on the Quote Icon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 82
   testRunner.And(string.Format("I have select the {0} from customer dropdown list", customer_Name), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 83
   testRunner.And("I have clicked on Submit Rate Request button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 84
   testRunner.And("I have clicked on LTL Tile of rate request process", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 85
   testRunner.When("I am taken to the new responsive LTL Shipment Information screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 86
   testRunner.And(string.Format("I have entered valid zipcode {0} in Shipping From section", shippingFrom), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 87
   testRunner.And(string.Format("I have entered valid zipcode {0} in Shipping To section", shippingTo), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 88
   testRunner.And(string.Format("I enter valid data in Item information section {0}, {1}", classification, weight), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 89
   testRunner.And(string.Format("I enter data in {0} field", insuredvalue), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 90
   testRunner.And("I Click on view quote results button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 91
   testRunner.And("I will be navigated to Guaranteed Rate carriers grid", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 92
   testRunner.And("I click on guaranteed save insured rate as quote link  for selected carrierintuse" +
                    "r", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 93
   testRunner.Then(string.Format("I will be navigated to quote confirmation page \'{0}\'", quoteConfirmationpageText), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 94
   testRunner.And("I click on Show Quote Details link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 95
   testRunner.And("I will see Quote Amount section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 96
   testRunner.And("I should be displayed with quote amount", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 97
   testRunner.And("I should be displayed with Est Cost", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 98
   testRunner.And("I should be displayed with Est Margin", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("26523_Test to verify  fields in Quote Amount section confirmation page when guara" +
            "nteed insured rates selected: ZZZ - GS Customer Test")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Quote Confirmation (LTL) _Show Quote Details _Station Users")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("26523")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Get")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Quote_Page")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Elements")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint67")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RegressionSuite")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "ZZZ - GS Customer Test")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Customer_Name", "ZZZ - GS Customer Test")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ShippingFrom", "33126")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ShippingTo", "60563")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Classification", "60")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Weight", "800")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:QuoteConfirmationpageText", "Quote Confirmation")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Insuredvalue", "100")]
        public virtual void _26523_TestToVerifyFieldsInQuoteAmountSectionConfirmationPageWhenGuaranteedInsuredRatesSelected_ZZZ_GSCustomerTest()
        {
#line 79
this._26523_TestToVerifyFieldsInQuoteAmountSectionConfirmationPageWhenGuaranteedInsuredRatesSelected("ZZZ - GS Customer Test", "33126", "60563", "60", "800", "Quote Confirmation", "100", ((string[])(null)));
#line hidden
        }
        
        public virtual void _26523_TestToVerifyQuoteAmountSectionValuesInConfirmationPageWhenStandardRatesSelected(string customer_Name, string shippingFrom, string shippingTo, string classification, string weight, string quoteConfirmationpageText, string insuredvalue, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "RegressionSuite"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("26523_Test to verify Quote Amount section values in confirmation page when standa" +
                    "rd  rates selected", @__tags);
#line 105
this.ScenarioSetup(scenarioInfo);
#line 106
   testRunner.Given("I am a shp.inquiry, shp.entry, sales, sales management, operations, or station ow" +
                    "ner", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 107
   testRunner.And("I click on the Quote Icon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 108
   testRunner.And(string.Format("I have select the {0} from customer dropdown list", customer_Name), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 109
   testRunner.And("I have clicked on Submit Rate Request button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 110
   testRunner.And("I have clicked on LTL Tile of rate request process", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 111
   testRunner.When("I am taken to the new responsive LTL Shipment Information screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 112
   testRunner.And(string.Format("I have entered valid zipcode {0} in Shipping From section", shippingFrom), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 113
   testRunner.And(string.Format("I have entered valid zipcode {0} in Shipping To section", shippingTo), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 114
   testRunner.And(string.Format("I enter valid data in Item information section {0}, {1}", classification, weight), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 115
   testRunner.And("I Click on view quote results button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 116
   testRunner.Then("I should disply the quote amount,Est Cost,Est margin values in confirmation page " +
                    "on saving the rate on results page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("26523_Test to verify Quote Amount section values in confirmation page when standa" +
            "rd  rates selected: ZZZ - GS Customer Test")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Quote Confirmation (LTL) _Show Quote Details _Station Users")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("26523")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Get")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Quote_Page")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Elements")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint67")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RegressionSuite")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "ZZZ - GS Customer Test")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Customer_Name", "ZZZ - GS Customer Test")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ShippingFrom", "33126")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ShippingTo", "60563")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Classification", "60")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Weight", "800")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:QuoteConfirmationpageText", "Quote Confirmation")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Insuredvalue", "100")]
        public virtual void _26523_TestToVerifyQuoteAmountSectionValuesInConfirmationPageWhenStandardRatesSelected_ZZZ_GSCustomerTest()
        {
#line 105
this._26523_TestToVerifyQuoteAmountSectionValuesInConfirmationPageWhenStandardRatesSelected("ZZZ - GS Customer Test", "33126", "60563", "60", "800", "Quote Confirmation", "100", ((string[])(null)));
#line hidden
        }
        
        public virtual void _26523_TestToVerifyQuoteAmountSectionValuesInConfirmationPageWhenGuaranteedRatesSelected(string customer_Name, string shippingFrom, string shippingTo, string classification, string weight, string quoteConfirmationpageText, string insuredvalue, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "RegressionSuite"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("26523_Test to verify Quote Amount section values in confirmation page when guaran" +
                    "teed rates selected", @__tags);
#line 123
this.ScenarioSetup(scenarioInfo);
#line 124
   testRunner.Given("I am a shp.inquiry, shp.entry, sales, sales management, operations, or station ow" +
                    "ner", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 125
   testRunner.And("I click on the Quote Icon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 126
   testRunner.And(string.Format("I have select the {0} from customer dropdown list", customer_Name), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 127
   testRunner.And("I have clicked on Submit Rate Request button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 128
   testRunner.And("I have clicked on LTL Tile of rate request process", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 129
   testRunner.When("I am taken to the new responsive LTL Shipment Information screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 130
   testRunner.And(string.Format("I have entered valid zipcode {0} in Shipping From section", shippingFrom), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 131
   testRunner.And(string.Format("I have entered valid zipcode {0} in Shipping To section", shippingTo), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 132
   testRunner.And(string.Format("I enter valid data in Item information section {0}, {1}", classification, weight), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 133
   testRunner.And("I Click on view quote results button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 134
   testRunner.Then("I should disply the quote amount,Est Cost,Est margin values in confirmation page " +
                    "on saving the guaranteed rates on results page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("26523_Test to verify Quote Amount section values in confirmation page when guaran" +
            "teed rates selected: ZZZ - GS Customer Test")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Quote Confirmation (LTL) _Show Quote Details _Station Users")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("26523")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Get")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Quote_Page")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Elements")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint67")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RegressionSuite")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "ZZZ - GS Customer Test")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Customer_Name", "ZZZ - GS Customer Test")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ShippingFrom", "33126")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ShippingTo", "60563")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Classification", "60")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Weight", "800")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:QuoteConfirmationpageText", "Quote Confirmation")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Insuredvalue", "100")]
        public virtual void _26523_TestToVerifyQuoteAmountSectionValuesInConfirmationPageWhenGuaranteedRatesSelected_ZZZ_GSCustomerTest()
        {
#line 123
this._26523_TestToVerifyQuoteAmountSectionValuesInConfirmationPageWhenGuaranteedRatesSelected("ZZZ - GS Customer Test", "33126", "60563", "60", "800", "Quote Confirmation", "100", ((string[])(null)));
#line hidden
        }
    }
}
#pragma warning restore
#endregion
