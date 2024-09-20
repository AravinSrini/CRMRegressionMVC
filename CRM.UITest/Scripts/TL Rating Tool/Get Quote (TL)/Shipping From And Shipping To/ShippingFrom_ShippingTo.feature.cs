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
namespace CRM.UITest.Scripts.TLRatingTool.GetQuoteTL.ShippingFromAndShippingTo
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class ShippingFrom_ShippingToFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "ShippingFrom_ShippingTo.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "ShippingFrom_ShippingTo", null, ProgrammingLanguage.CSharp, new string[] {
                        "ShippingFrom_ShippingTo",
                        "Sprint65",
                        "Functional"});
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "ShippingFrom_ShippingTo")))
            {
                global::CRM.UITest.Scripts.TLRatingTool.GetQuoteTL.ShippingFromAndShippingTo.ShippingFrom_ShippingToFeature.FeatureSetup(null);
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
        
        public virtual void VerifyZipcodeLookupAutoPopulateFunctionalityForTheShippingFromSection(string scenario, string username, string password, string originZipCode, string destinationZipCode, string weight, string validOriginZip, string city, string state, string modifiedCity, string modifiedState, string pickupDate, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "24137",
                    "NinjaSprint17",
                    "41033"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify zipcode lookup auto populate functionality for the Shipping From section", @__tags);
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
 testRunner.Given(string.Format("I am a DLS user and loggedin into application with valid {0} and {1}", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
 testRunner.And("I clicked on Rating Tool icon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 9
 testRunner.When(string.Format("I enter required fields {0},{1},{2} in rating tool page", originZipCode, destinationZipCode, weight), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
 testRunner.And(string.Format("I click on the calender to select the {0}", pickupDate), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
 testRunner.And("Click on GetRate button in rating tool page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
 testRunner.And("I have clicked on Get Quote Now button in rating tool page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
 testRunner.And(string.Format("I enter zipcode {0} and leave focus from the origin section in GetQuote(TL) page", validOriginZip), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
    testRunner.Then(string.Format("City {0} and State {1} fields should be populated in origin section in GetQuote(T" +
                        "L) page", city, state), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 15
 testRunner.And(string.Format("User have the ability to edit the city in shipping from section{0} in GetQuote (T" +
                        "L) page", modifiedCity), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
    testRunner.And(string.Format("User have the option to select a state from the state drop down list in shipping " +
                        "from section{0} in GetQuote(TL) page", modifiedState), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify zipcode lookup auto populate functionality for the Shipping From section: " +
            "S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ShippingFrom_ShippingTo")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("ShippingFrom_ShippingTo")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint65")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("24137")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("NinjaSprint17")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("41033")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Scenario", "S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "stationowner@test.com")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:OriginZipCode", "90001")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DestinationZipCode", "90001")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Weight", "100")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ValidOriginZip", "33126")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:City", "Miami")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:State", "FL")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ModifiedCity", "test")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ModifiedState", "CA")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:PickupDate", "0")]
        public virtual void VerifyZipcodeLookupAutoPopulateFunctionalityForTheShippingFromSection_S1()
        {
#line 6
this.VerifyZipcodeLookupAutoPopulateFunctionalityForTheShippingFromSection("S1", "stationowner@test.com", "Te$t1234", "90001", "90001", "100", "33126", "Miami", "FL", "test", "CA", "0", ((string[])(null)));
#line hidden
        }
        
        public virtual void VerifyZipcodeLookupAutoPopulateFunctionalityForTheShippingToSection(string scenario, string username, string password, string originZipCode, string destinationZipCode, string weight, string validDestinationZip, string city, string state, string modifiedCity, string modifiedState, string pickupDate, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "24140",
                    "NinjaSprint17",
                    "41033"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify zipcode lookup auto populate functionality for the Shipping To section", @__tags);
#line 24
this.ScenarioSetup(scenarioInfo);
#line 25
 testRunner.Given(string.Format("I am a DLS user and loggedin into application with valid {0} and {1}", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 26
 testRunner.And("I clicked on Rating Tool icon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
 testRunner.When(string.Format("I enter required fields {0},{1},{2} in rating tool page", originZipCode, destinationZipCode, weight), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 28
 testRunner.And(string.Format("I click on the calender to select the {0}", pickupDate), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
 testRunner.And("Click on GetRate button in rating tool page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
 testRunner.And("I have clicked on Get Quote Now button in rating tool page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 31
 testRunner.And(string.Format("I enter zipcode {0} and leave focus from the destination section in GetQuote(TL) " +
                        "page", validDestinationZip), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
 testRunner.Then(string.Format("City {0} and State {1} fields should be populated in destination section in GetQu" +
                        "ote(TL) page", city, state), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 33
 testRunner.And(string.Format("User have the ability to edit the city in shipping to section {0} in GetQuote(TL)" +
                        " page", modifiedCity), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 34
    testRunner.And(string.Format("User have the option to select a state from the state drop down list in shipping " +
                        "to section{0} in GetQuote(TL) page", modifiedState), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify zipcode lookup auto populate functionality for the Shipping To section: S1" +
            "")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ShippingFrom_ShippingTo")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("ShippingFrom_ShippingTo")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint65")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("24140")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("NinjaSprint17")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("41033")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Scenario", "S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "stationowner@test.com")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:OriginZipCode", "90001")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DestinationZipCode", "90001")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Weight", "100")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ValidDestinationZip", "85282")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:City", "Tempe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:State", "AZ")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ModifiedCity", "test2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ModifiedState", "CA")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:PickupDate", "0")]
        public virtual void VerifyZipcodeLookupAutoPopulateFunctionalityForTheShippingToSection_S1()
        {
#line 24
this.VerifyZipcodeLookupAutoPopulateFunctionalityForTheShippingToSection("S1", "stationowner@test.com", "Te$t1234", "90001", "90001", "100", "85282", "Tempe", "AZ", "test2", "CA", "0", ((string[])(null)));
#line hidden
        }
        
        public virtual void VerifyZipcodeTextBoxOnEnteringInvalidZipInShippingFromSection(string scenario, string username, string password, string originZipCode, string destinationZipCode, string weight, string invalidOriginZip, string pickupDate, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "GUI",
                    "24137",
                    "NinjaSprint17",
                    "41033"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify zipcode text box on entering invalid zip in Shipping From section", @__tags);
#line 42
this.ScenarioSetup(scenarioInfo);
#line 43
 testRunner.Given(string.Format("I am a DLS user and loggedin into application with valid {0} and {1}", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 44
 testRunner.And("I clicked on Rating Tool icon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 45
 testRunner.When(string.Format("I enter required fields {0},{1},{2} in rating tool page", originZipCode, destinationZipCode, weight), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 46
 testRunner.And(string.Format("I click on the calender to select the {0}", pickupDate), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 47
 testRunner.And("Click on GetRate button in rating tool page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 48
 testRunner.And("I have clicked on Get Quote Now button in rating tool page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 49
 testRunner.And(string.Format("I enter zipcode {0} and leave focus from the origin section in GetQuote(TL) page", invalidOriginZip), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 50
 testRunner.Then("background color of the origin zip code textbox should turn red and error message" +
                    " should be displayed in GetQuote(TL) page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 51
 testRunner.And("the Origin City and State will not Auto populate in GetQuote(TL) page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify zipcode text box on entering invalid zip in Shipping From section: S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ShippingFrom_ShippingTo")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("ShippingFrom_ShippingTo")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint65")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("24137")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("NinjaSprint17")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("41033")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Scenario", "S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "stationowner@test.com")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:OriginZipCode", "90001")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DestinationZipCode", "90001")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Weight", "100")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:InvalidOriginZip", "66666")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:PickupDate", "0")]
        public virtual void VerifyZipcodeTextBoxOnEnteringInvalidZipInShippingFromSection_S1()
        {
#line 42
this.VerifyZipcodeTextBoxOnEnteringInvalidZipInShippingFromSection("S1", "stationowner@test.com", "Te$t1234", "90001", "90001", "100", "66666", "0", ((string[])(null)));
#line hidden
        }
        
        public virtual void VerifyZipcodeTextBoxOnEnteringInvalidZipInShippingToSection(string scenario, string username, string password, string originZipCode, string destinationZipCode, string weight, string invalidDestinationZip, string pickupDate, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "GUI",
                    "24140",
                    "NinjaSprint17",
                    "41033"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify zipcode text box on entering invalid zip in Shipping To section", @__tags);
#line 59
this.ScenarioSetup(scenarioInfo);
#line 60
 testRunner.Given(string.Format("I am a DLS user and loggedin into application with valid {0} and {1}", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 61
 testRunner.And("I clicked on Rating Tool icon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 62
 testRunner.When(string.Format("I enter required fields {0},{1},{2} in rating tool page", originZipCode, destinationZipCode, weight), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 63
 testRunner.And(string.Format("I click on the calender to select the {0}", pickupDate), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 64
 testRunner.And("Click on GetRate button in rating tool page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 65
 testRunner.And("I have clicked on Get Quote Now button in rating tool page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 66
 testRunner.And(string.Format("I enter zipcode {0} and leave focus from the destination section in GetQuote(TL) " +
                        "page", invalidDestinationZip), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 67
 testRunner.Then("background color of the destination zip code textbox should turn red and error me" +
                    "ssage should be displayed in GetQuote(TL) page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 68
 testRunner.And("the Destination City and State will not Auto populate in GetQuote(TL) page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify zipcode text box on entering invalid zip in Shipping To section: S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ShippingFrom_ShippingTo")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("ShippingFrom_ShippingTo")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint65")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("24140")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("NinjaSprint17")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("41033")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Scenario", "S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "stationowner@test.com")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:OriginZipCode", "90001")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DestinationZipCode", "90001")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Weight", "100")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:InvalidDestinationZip", "66666")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:PickupDate", "0")]
        public virtual void VerifyZipcodeTextBoxOnEnteringInvalidZipInShippingToSection_S1()
        {
#line 59
this.VerifyZipcodeTextBoxOnEnteringInvalidZipInShippingToSection("S1", "stationowner@test.com", "Te$t1234", "90001", "90001", "100", "66666", "0", ((string[])(null)));
#line hidden
        }
        
        public virtual void VerifySelectStateProvinceDropDownListWillBePopulatedWithAListOfCanadaProvincesInShippingToSection(string scenario, string username, string password, string originZipCode, string destinationZipCode, string weight, string pickupDate, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "24140"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify Select State/Province drop down list will be populated with a list of Cana" +
                    "da provinces in Shipping To section", @__tags);
#line 76
this.ScenarioSetup(scenarioInfo);
#line 77
    testRunner.Given(string.Format("I am a DLS user and login into application with valid {0} and {1}", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 78
 testRunner.And("I clicked on Rating Tool icon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 79
 testRunner.When(string.Format("I enter required fields {0},{1},{2} in rating tool page", originZipCode, destinationZipCode, weight), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 80
 testRunner.And(string.Format("I click on the calender to select the {0}", pickupDate), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 81
 testRunner.And("Click on GetRate button in rating tool page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 82
 testRunner.And("I have clicked on Get Quote Now button in rating tool page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 83
 testRunner.And("I select Canada Country from destination country dropdown in GetQuote(TL) page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 84
    testRunner.Then("the Select State/Province drop down list will be populated with a list of Canada " +
                    "provinces  in Shipping To section in GetQuote(TL) page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify Select State/Province drop down list will be populated with a list of Cana" +
            "da provinces in Shipping To section: S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ShippingFrom_ShippingTo")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("ShippingFrom_ShippingTo")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint65")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("24140")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Scenario", "S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "stationtest@rrd.com")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:OriginZipCode", "90001")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DestinationZipCode", "90001")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Weight", "100")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:PickupDate", "0")]
        public virtual void VerifySelectStateProvinceDropDownListWillBePopulatedWithAListOfCanadaProvincesInShippingToSection_S1()
        {
#line 76
this.VerifySelectStateProvinceDropDownListWillBePopulatedWithAListOfCanadaProvincesInShippingToSection("S1", "stationtest@rrd.com", "Te$t1234", "90001", "90001", "100", "0", ((string[])(null)));
#line hidden
        }
        
        public virtual void VerifySelectStateProvinceDropDownListWillBePopulatedWithAListOfCanadaProvincesInShippingFromSection(string scenario, string username, string password, string originZipCode, string destinationZipCode, string weight, string pickupDate, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "24137"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify Select State/Province drop down list will be populated with a list of Cana" +
                    "da provinces in Shipping From section", @__tags);
#line 91
this.ScenarioSetup(scenarioInfo);
#line 92
    testRunner.Given(string.Format("I am a DLS user and login into application with valid {0} and {1}", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 93
 testRunner.And("I clicked on Rating Tool icon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 94
 testRunner.When(string.Format("I enter required fields {0},{1},{2} in rating tool page", originZipCode, destinationZipCode, weight), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 95
 testRunner.And(string.Format("I click on the calender to select the {0}", pickupDate), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 96
 testRunner.And("Click on GetRate button in rating tool page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 97
 testRunner.And("I have clicked on Get Quote Now button in rating tool page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 98
 testRunner.And("I select Canada Country from origin country dropdown in GetQuote(TL) page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 99
    testRunner.Then("the Select State/Province drop down list will be populated with a list of Canada " +
                    "provinces in Shipping From section in GetQuote(TL) page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify Select State/Province drop down list will be populated with a list of Cana" +
            "da provinces in Shipping From section: S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ShippingFrom_ShippingTo")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("ShippingFrom_ShippingTo")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint65")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("24137")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Scenario", "S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "stationtest@rrd.com")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:OriginZipCode", "90001")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DestinationZipCode", "90001")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Weight", "100")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:PickupDate", "0")]
        public virtual void VerifySelectStateProvinceDropDownListWillBePopulatedWithAListOfCanadaProvincesInShippingFromSection_S1()
        {
#line 91
this.VerifySelectStateProvinceDropDownListWillBePopulatedWithAListOfCanadaProvincesInShippingFromSection("S1", "stationtest@rrd.com", "Te$t1234", "90001", "90001", "100", "0", ((string[])(null)));
#line hidden
        }
    }
}
#pragma warning restore
#endregion
