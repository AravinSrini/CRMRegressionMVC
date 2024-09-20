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
namespace CRM.UITest.Scripts.CreditHold
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.2.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class CreditHold_AccessingQuoteAndShipmentPages_LTLServicesFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "Credit Hold - Accessing Quote and Shipment Pages- LTL Services.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Credit Hold - Accessing Quote and Shipment Pages- LTL Services", null, ProgrammingLanguage.CSharp, new string[] {
                        "51424",
                        "Sprint86"});
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "Credit Hold - Accessing Quote and Shipment Pages- LTL Services")))
            {
                global::CRM.UITest.Scripts.CreditHold.CreditHold_AccessingQuoteAndShipmentPages_LTLServicesFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("51424 - Verify the modal message and close modal option on Credit Hold modal from" +
            " Get Quote page for external user")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Credit Hold - Accessing Quote and Shipment Pages- LTL Services")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("51424")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint86")]
        public virtual void _51424_VerifyTheModalMessageAndCloseModalOptionOnCreditHoldModalFromGetQuotePageForExternalUser()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("51424 - Verify the modal message and close modal option on Credit Hold modal from" +
                    " Get Quote page for external user", ((string[])(null)));
#line 5
this.ScenarioSetup(scenarioInfo);
#line 6
 testRunner.Given("I am a Credit Hold customer", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 7
 testRunner.When("I am on Get Quote LTL page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 8
 testRunner.Then("I will see a Credit Hold modal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 9
 testRunner.And("I will see a message in the modal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
 testRunner.And("I have the option to close the modal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("51424 - Verify by clicking on OK button on Credit Hold modal from Get Quote page " +
            "as a external user")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Credit Hold - Accessing Quote and Shipment Pages- LTL Services")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("51424")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint86")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.IgnoreAttribute()]
        public virtual void _51424_VerifyByClickingOnOKButtonOnCreditHoldModalFromGetQuotePageAsAExternalUser()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("51424 - Verify by clicking on OK button on Credit Hold modal from Get Quote page " +
                    "as a external user", new string[] {
                        "ignore"});
#line 13
this.ScenarioSetup(scenarioInfo);
#line 14
 testRunner.Given("I am a Credit Hold customer", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 15
 testRunner.And("I am on the GetQuote LTL page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
 testRunner.And("I received the Credit Hold modal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
 testRunner.When("I click on OK button in the Credit Hold modal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 18
 testRunner.Then("I arrive on the QuoteList page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("51424 - Verify the modal message and close modal option on Credit Hold modal from" +
            " Add Shipment page for external user")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Credit Hold - Accessing Quote and Shipment Pages- LTL Services")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("51424")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint86")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.IgnoreAttribute()]
        public virtual void _51424_VerifyTheModalMessageAndCloseModalOptionOnCreditHoldModalFromAddShipmentPageForExternalUser()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("51424 - Verify the modal message and close modal option on Credit Hold modal from" +
                    " Add Shipment page for external user", new string[] {
                        "ignore"});
#line 21
this.ScenarioSetup(scenarioInfo);
#line 22
 testRunner.Given("I am a Credit Hold customer", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 23
 testRunner.When("arrive on the Add Shipment LTL page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 24
 testRunner.Then("I will see a Credit Hold modal in Add Shipment page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 25
 testRunner.And("I will see a message in credit hold modal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
 testRunner.And("I have the option to close the credit hold modal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("51424 - Verify by clicking on OK button on Credit Hold modal from Add Shipment pa" +
            "ge as a external user")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Credit Hold - Accessing Quote and Shipment Pages- LTL Services")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("51424")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint86")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.IgnoreAttribute()]
        public virtual void _51424_VerifyByClickingOnOKButtonOnCreditHoldModalFromAddShipmentPageAsAExternalUser()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("51424 - Verify by clicking on OK button on Credit Hold modal from Add Shipment pa" +
                    "ge as a external user", new string[] {
                        "ignore"});
#line 29
this.ScenarioSetup(scenarioInfo);
#line 30
 testRunner.Given("I am a Credit Hold customer", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 31
 testRunner.And("I am on the Add Shipment LTL page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
 testRunner.And("I received the Credit Hold modal in Add Shipment page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
 testRunner.When("I click on the OK button in the Credit Hold modal from Add Shipment page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 34
 testRunner.Then("I will arrive on the Shipment List page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("51424 - Verify the modal message and close modal option on Credit Hold modal from" +
            " Get Quote page for internal user")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Credit Hold - Accessing Quote and Shipment Pages- LTL Services")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("51424")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint86")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.IgnoreAttribute()]
        public virtual void _51424_VerifyTheModalMessageAndCloseModalOptionOnCreditHoldModalFromGetQuotePageForInternalUser()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("51424 - Verify the modal message and close modal option on Credit Hold modal from" +
                    " Get Quote page for internal user", new string[] {
                        "ignore"});
#line 37
this.ScenarioSetup(scenarioInfo);
#line 38
 testRunner.Given("I am a sales management, operations, or station owner user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 39
 testRunner.And("I am sending a credit hold customer name along with page url", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 40
 testRunner.When("I arrive on the Get Quote LTL page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 41
 testRunner.Then("I will see a Credit Hold modal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 42
 testRunner.And("I will see a message in the modal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 43
 testRunner.And("I have the option to close the modal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("51424 - Verify by clicking on OK button on Credit Hold modal from Get Quote page " +
            "as a internal user")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Credit Hold - Accessing Quote and Shipment Pages- LTL Services")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("51424")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint86")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.IgnoreAttribute()]
        public virtual void _51424_VerifyByClickingOnOKButtonOnCreditHoldModalFromGetQuotePageAsAInternalUser()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("51424 - Verify by clicking on OK button on Credit Hold modal from Get Quote page " +
                    "as a internal user", new string[] {
                        "ignore"});
#line 46
this.ScenarioSetup(scenarioInfo);
#line 47
 testRunner.Given("I am a sales management, operations, or station owner user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 48
 testRunner.And("I am sending a credit hold customer name along with page url", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 49
 testRunner.And("I arrive on the Get Quote LTL page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 50
 testRunner.And("I received the Credit Hold modal in Get Quote page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 51
 testRunner.When("I click on OK button in the Credit Hold modal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 52
 testRunner.Then("I will arrive on the Quote List page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("51424 - Verify the modal message and close modal option on Credit Hold modal from" +
            " Add Shipment page for internal user")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Credit Hold - Accessing Quote and Shipment Pages- LTL Services")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("51424")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint86")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.IgnoreAttribute()]
        public virtual void _51424_VerifyTheModalMessageAndCloseModalOptionOnCreditHoldModalFromAddShipmentPageForInternalUser()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("51424 - Verify the modal message and close modal option on Credit Hold modal from" +
                    " Add Shipment page for internal user", new string[] {
                        "ignore"});
#line 55
this.ScenarioSetup(scenarioInfo);
#line 56
 testRunner.Given("I am a sales management, operations, or station owner user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 57
 testRunner.When("I am sending a credit hold customer name along with the page url", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 58
 testRunner.Then("I will see a Credit Hold modal in Add Shipment page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 59
 testRunner.And("I will see a message in the modal from Add Shipment page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 60
 testRunner.And("I have the option to close the modal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("51424 - Verify by clicking on OK button on Credit Hold modal from Add Shipment pa" +
            "ge as a internal user")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Credit Hold - Accessing Quote and Shipment Pages- LTL Services")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("51424")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint86")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.IgnoreAttribute()]
        public virtual void _51424_VerifyByClickingOnOKButtonOnCreditHoldModalFromAddShipmentPageAsAInternalUser()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("51424 - Verify by clicking on OK button on Credit Hold modal from Add Shipment pa" +
                    "ge as a internal user", new string[] {
                        "ignore"});
#line 63
this.ScenarioSetup(scenarioInfo);
#line 64
 testRunner.Given("I am a sales management, operations, or station owner user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 65
 testRunner.And("I am sending a credit hold customer name along with the page url", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 66
 testRunner.And("I received the Credit Hold modal in Add Shipment page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 67
 testRunner.When("I click on the OK button in Credit Hold modal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 68
 testRunner.Then("I will arrive on Shipment List page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
