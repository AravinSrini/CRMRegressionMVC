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
namespace CRM.UITest.Scripts.TLRatingTool.GetQuoteTL
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class GetQuote_TruckloadFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "GetQuote_Truckload.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner(null, 0);
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "GetQuote_Truckload", null, ProgrammingLanguage.CSharp, ((string[])(null)));
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "GetQuote_Truckload")))
            {
                CRM.UITest.Scripts.TLRatingTool.GetQuoteTL.GetQuote_TruckloadFeature.FeatureSetup(null);
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
        
        public virtual void VerifyZipcodeLookupAutoPopulateFunctionalityForTheShippingFromSection(string scenario, string username, string password, string service, string validZip, string city, string state, string modifiedCity, string modifiedState, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Functional",
                    "Sprint65",
                    "24137"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify zipcode lookup auto populate functionality for the Shipping From section", @__tags);
#line 5
this.ScenarioSetup(scenarioInfo);
#line 6
 testRunner.Given(string.Format("I am a DLS user and login into application with valid {0} and {1}", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 7
 testRunner.And("I clicked on Rating Tool icon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 8
 testRunner.When("I enter required fields <OriginZipCode>,<DestinationZipCode>,<Weight> in rating t" +
                    "ool page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 9
 testRunner.And("Click on Get Rate button in rating tool page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
 testRunner.And("I have click on Get Quote New button in rating tool page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
 testRunner.And(string.Format("I enter zipcode {0} and leave focus from the origin section in GetQuote(TL) page", validZip), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
    testRunner.Then(string.Format("City {0} and State {1} fields should be populated in origin section in GetQuote(T" +
                        "L) page", city, state), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 13
 testRunner.And(string.Format("User have the ability to edit the city in shipping from section{0} in GetQuote (T" +
                        "L) page", modifiedCity), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
    testRunner.And(string.Format("User have the option to select a state from the state drop down list in shipping " +
                        "from section{0} in GetQuote(TL) page", modifiedState), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify zipcode lookup auto populate functionality for the Shipping From section: " +
            "S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "GetQuote_Truckload")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint65")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("24137")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Scenario", "S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "nat@extuser.com")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Service", "LTL")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ValidZip", "33126")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:City", "Miami")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:State", "FL")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ModifiedCity", "test")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ModifiedState", "CA")]
        public virtual void VerifyZipcodeLookupAutoPopulateFunctionalityForTheShippingFromSection_S1()
        {
            this.VerifyZipcodeLookupAutoPopulateFunctionalityForTheShippingFromSection("S1", "nat@extuser.com", "Te$t1234", "LTL", "33126", "Miami", "FL", "test", "CA", ((string[])(null)));
#line hidden
        }
        
        public virtual void VerifyZipcodeLookupAutoPopulateFunctionalityForTheShippingToSection(string scenario, string username, string password, string service, string validZip, string city, string state, string modifiedCity, string modifiedState, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Functional",
                    "Sprint65",
                    "24140"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify zipcode lookup auto populate functionality for the Shipping To section", @__tags);
#line 22
this.ScenarioSetup(scenarioInfo);
#line 23
 testRunner.Given(string.Format("I am a DLS user and login into application with valid {0} and {1}", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 24
 testRunner.And("I clicked on Rating Tool icon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
 testRunner.When("I enter required fields <OriginZipCode>,<DestinationZipCode>,<Weight> in rating t" +
                    "ool page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 26
 testRunner.And("Click on Get Rate button in rating tool page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
 testRunner.And("I have click on Get Quote New button in rating tool page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 28
 testRunner.And(string.Format("I enter zipcode {0} and leave focus from the destination section in GetQuote(TL) " +
                        "page", validZip), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
 testRunner.Then(string.Format("City {0} and State {1} fields should be populated in destination section in GetQu" +
                        "ote(TL) page", city, state), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 30
 testRunner.And(string.Format("User have the ability to edit the city in shipping to section {0} in GetQuote(TL)" +
                        " page", modifiedCity), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 31
    testRunner.And(string.Format("User have the option to select a state from the state drop down list in shipping " +
                        "to section{0} in GetQuote(TL) page", modifiedState), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify zipcode lookup auto populate functionality for the Shipping To section: S1" +
            "")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "GetQuote_Truckload")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint65")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("24140")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Scenario", "S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "nat@extuser.com")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Service", "LTL")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ValidZip", "85282")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:City", "Tempe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:State", "AZ")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ModifiedCity", "test2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ModifiedState", "CA")]
        public virtual void VerifyZipcodeLookupAutoPopulateFunctionalityForTheShippingToSection_S1()
        {
            this.VerifyZipcodeLookupAutoPopulateFunctionalityForTheShippingToSection("S1", "nat@extuser.com", "Te$t1234", "LTL", "85282", "Tempe", "AZ", "test2", "CA", ((string[])(null)));
#line hidden
        }
        
        public virtual void VerifyZipcodeTextBoxOnEnteringInvalidZipInShippingFromSection(string scenario, string username, string password, string service, string invalidZip, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Functional",
                    "Sprint65",
                    "24137"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify zipcode text box on entering invalid zip in Shipping From section", @__tags);
#line 38
this.ScenarioSetup(scenarioInfo);
#line 39
 testRunner.Given(string.Format("I am a DLS user and login into application with valid {0} and {1}", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 40
 testRunner.And("I clicked on Rating Tool icon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 41
 testRunner.When("I enter required fields <OriginZipCode>,<DestinationZipCode>,<Weight> in rating t" +
                    "ool page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 42
 testRunner.And("Click on Get Rate button in rating tool page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 43
 testRunner.And("I have click on Get Quote New button in rating tool page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 44
 testRunner.And(string.Format("I enter zipcode {0} and leave focus from the origin section in GetQuote(TL) page", invalidZip), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 45
 testRunner.Then("background color of the origin zip code textbox should turn red and error message" +
                    " should be displayed in GetQuote(TL) page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 46
 testRunner.And("the Origin City and State will not Auto populate in GetQuote(TL) page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify zipcode text box on entering invalid zip in Shipping From section: S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "GetQuote_Truckload")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint65")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("24137")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Scenario", "S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "nat@extuser.com")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Service", "LTL")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:InvalidZip", "66666")]
        public virtual void VerifyZipcodeTextBoxOnEnteringInvalidZipInShippingFromSection_S1()
        {
            this.VerifyZipcodeTextBoxOnEnteringInvalidZipInShippingFromSection("S1", "nat@extuser.com", "Te$t1234", "LTL", "66666", ((string[])(null)));
#line hidden
        }
        
        public virtual void VerifyZipcodeTextBoxOnEnteringInvalidZipInShippingToSection(string scenario, string username, string password, string service, string invalidZip, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Functional",
                    "Sprint65",
                    "24140"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify zipcode text box on entering invalid zip in Shipping To section", @__tags);
#line 53
this.ScenarioSetup(scenarioInfo);
#line 54
 testRunner.Given(string.Format("I am a DLS user and login into application with valid {0} and {1}", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 55
 testRunner.And("I clicked on Rating Tool icon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 56
 testRunner.When("I enter required fields <OriginZipCode>,<DestinationZipCode>,<Weight> in rating t" +
                    "ool page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 57
 testRunner.And("Click on Get Rate button in rating tool page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 58
 testRunner.And("I have click on Get Quote New button in rating tool page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 59
 testRunner.And(string.Format("I enter zipcode {0} and leave focus To the zipcode text box in GetQuote(TL) page", invalidZip), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 60
 testRunner.Then("background color of the destination zip code textbox should turn red and error me" +
                    "ssage should be displayed in GetQuote(TL) page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 61
 testRunner.And("the Destination City and State will not Auto populate in GetQuote(TL) page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify zipcode text box on entering invalid zip in Shipping To section: S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "GetQuote_Truckload")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint65")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("24140")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Scenario", "S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "nat@extuser.com")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Service", "LTL")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:InvalidZip", "66666")]
        public virtual void VerifyZipcodeTextBoxOnEnteringInvalidZipInShippingToSection_S1()
        {
            this.VerifyZipcodeTextBoxOnEnteringInvalidZipInShippingToSection("S1", "nat@extuser.com", "Te$t1234", "LTL", "66666", ((string[])(null)));
#line hidden
        }
        
        public virtual void VerifySelectStateProvinceDropDownListWillBePopulatedWithAListOfCanadaProvincesInShippingToSection(string scenario, string username, string password, string service, string invalidZip, string country, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Functional",
                    "Sprint65",
                    "24140"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify Select State/Province drop down list will be populated with a list of Cana" +
                    "da provinces in Shipping To section", @__tags);
#line 70
this.ScenarioSetup(scenarioInfo);
#line 71
    testRunner.Given(string.Format("I am a DLS user and login into application with valid {0} and {1}", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 72
 testRunner.And("I clicked on Rating Tool icon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 73
 testRunner.When("I enter required fields <OriginZipCode>,<DestinationZipCode>,<Weight> in rating t" +
                    "ool page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 74
 testRunner.And("Click on Get Rate button in rating tool page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 75
 testRunner.And("I have click on Get Quote New button in rating tool page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 76
 testRunner.And("I select Canada Country from destination country dropdown in GetQuote(TL) page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 77
    testRunner.Then("the Select State/Province drop down list will be populated with a list of Canada " +
                    "provinces  in Shipping To section in GetQuote(TL) page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify Select State/Province drop down list will be populated with a list of Cana" +
            "da provinces in Shipping To section: S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "GetQuote_Truckload")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint65")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("24140")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Scenario", "S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "nat@extuser.com")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Service", "LTL")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:InvalidZip", "66666")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Country", "Canada")]
        public virtual void VerifySelectStateProvinceDropDownListWillBePopulatedWithAListOfCanadaProvincesInShippingToSection_S1()
        {
            this.VerifySelectStateProvinceDropDownListWillBePopulatedWithAListOfCanadaProvincesInShippingToSection("S1", "nat@extuser.com", "Te$t1234", "LTL", "66666", "Canada", ((string[])(null)));
#line hidden
        }
        
        public virtual void VerifySelectStateProvinceDropDownListWillBePopulatedWithAListOfCanadaProvincesInShippingFromSection(string scenario, string username, string password, string service, string invalidZip, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Functional",
                    "Sprint65",
                    "24137"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify Select State/Province drop down list will be populated with a list of Cana" +
                    "da provinces in Shipping From section", @__tags);
#line 84
this.ScenarioSetup(scenarioInfo);
#line 85
    testRunner.Given(string.Format("I am a DLS user and login into application with valid {0} and {1}", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 86
 testRunner.And("I clicked on Rating Tool icon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 87
 testRunner.When("I enter required fields <OriginZipCode>,<DestinationZipCode>,<Weight> in rating t" +
                    "ool page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 88
 testRunner.And("Click on Get Rate button in rating tool page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 89
 testRunner.And("I have click on Get Quote New button in rating tool page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 90
 testRunner.And("I select Canada Country from origin country dropdown in GetQuote(TL) page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 91
    testRunner.Then("the Select State/Province drop down list will be populated with a list of Canada " +
                    "provinces in Shipping From section in GetQuote(TL) page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify Select State/Province drop down list will be populated with a list of Cana" +
            "da provinces in Shipping From section: S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "GetQuote_Truckload")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint65")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("24137")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Scenario", "S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "nat@extuser.com")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Service", "LTL")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:InvalidZip", "66666")]
        public virtual void VerifySelectStateProvinceDropDownListWillBePopulatedWithAListOfCanadaProvincesInShippingFromSection_S1()
        {
            this.VerifySelectStateProvinceDropDownListWillBePopulatedWithAListOfCanadaProvincesInShippingFromSection("S1", "nat@extuser.com", "Te$t1234", "LTL", "66666", ((string[])(null)));
#line hidden
        }
    }
}
#pragma warning restore
#endregion
