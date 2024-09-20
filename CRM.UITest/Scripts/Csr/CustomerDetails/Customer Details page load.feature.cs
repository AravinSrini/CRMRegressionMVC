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
namespace CRM.UITest.Scripts.Csr.CustomerDetails
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.2.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class CustomerDetailsPageLoadFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "Customer Details page load.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Customer Details page load", null, ProgrammingLanguage.CSharp, new string[] {
                        "Sprint92",
                        "108730",
                        "Bug"});
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "Customer Details page load")))
            {
                global::CRM.UITest.Scripts.Csr.CustomerDetails.CustomerDetailsPageLoadFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify if user is able to navigate to Customer details page when user Clicks on a" +
            "ny account from Customer Profiles page_ConfigManager")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Customer Details page load")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint92")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("108730")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Bug")]
        public virtual void VerifyIfUserIsAbleToNavigateToCustomerDetailsPageWhenUserClicksOnAnyAccountFromCustomerProfilesPage_ConfigManager()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify if user is able to navigate to Customer details page when user Clicks on a" +
                    "ny account from Customer Profiles page_ConfigManager", ((string[])(null)));
#line 4
this.ScenarioSetup(scenarioInfo);
#line 5
 testRunner.Given("I am a user who have access to Account Management module \'username-CurrentSprintc" +
                    "onfigmanager\' , \'password-CurrentSprintconfigmanager\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 6
 testRunner.And("I am on Customer Profiles page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 7
 testRunner.When("I click on any account from the customer Profiles page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 8
 testRunner.Then("I should be navigated to Customer Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify if user is able to navigate to Customer details page when user Clicks on a" +
            "ny account from Customer Profiles page_SystemConfig")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Customer Details page load")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint92")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("108730")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Bug")]
        public virtual void VerifyIfUserIsAbleToNavigateToCustomerDetailsPageWhenUserClicksOnAnyAccountFromCustomerProfilesPage_SystemConfig()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify if user is able to navigate to Customer details page when user Clicks on a" +
                    "ny account from Customer Profiles page_SystemConfig", ((string[])(null)));
#line 10
this.ScenarioSetup(scenarioInfo);
#line 11
 testRunner.Given("I am a user who have access to Account Management module \'username-CurrentsprintS" +
                    "ystemconfiguration\' , \'password-CurrentsprintSystemconfiguration\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 12
 testRunner.And("I am on Customer Profiles page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
 testRunner.When("I click on any account from the customer Profiles page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 14
 testRunner.Then("I should be navigated to Customer Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify if user is able to navigate to Customer details page when user Clicks on a" +
            "ny account from Customer Profiles page_PricingConfig")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Customer Details page load")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint92")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("108730")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Bug")]
        public virtual void VerifyIfUserIsAbleToNavigateToCustomerDetailsPageWhenUserClicksOnAnyAccountFromCustomerProfilesPage_PricingConfig()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify if user is able to navigate to Customer details page when user Clicks on a" +
                    "ny account from Customer Profiles page_PricingConfig", ((string[])(null)));
#line 16
this.ScenarioSetup(scenarioInfo);
#line 17
 testRunner.Given("I am a user who have access to Account Management module \'username-CurrentsprintP" +
                    "ricingconfig\' , \'password-CurrentsprintPricingconfig\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 18
 testRunner.And("I am on Customer Profiles page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
 testRunner.When("I click on any account from the customer Profiles page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 20
 testRunner.Then("I should be navigated to Customer Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify if user is able to navigate to Customer details page when user clicks on A" +
            "ccount Management module_Shipentry")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Customer Details page load")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint92")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("108730")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Bug")]
        public virtual void VerifyIfUserIsAbleToNavigateToCustomerDetailsPageWhenUserClicksOnAccountManagementModule_Shipentry()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify if user is able to navigate to Customer details page when user clicks on A" +
                    "ccount Management module_Shipentry", ((string[])(null)));
#line 22
this.ScenarioSetup(scenarioInfo);
#line 23
 testRunner.Given("I am a user who have access to Account Management module \'username-CurrentSprints" +
                    "hpentry\' , \'password-CurrentSprintshpentry\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 24
 testRunner.When("I click on Account Management icon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 25
 testRunner.Then("I should be navigated to the Customer Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify if user is able to navigate to Customer details page when user Clicks on a" +
            "ny account from Customer Profiles page_OperationUser")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Customer Details page load")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint92")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("108730")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Bug")]
        public virtual void VerifyIfUserIsAbleToNavigateToCustomerDetailsPageWhenUserClicksOnAnyAccountFromCustomerProfilesPage_OperationUser()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify if user is able to navigate to Customer details page when user Clicks on a" +
                    "ny account from Customer Profiles page_OperationUser", ((string[])(null)));
#line 27
this.ScenarioSetup(scenarioInfo);
#line 28
 testRunner.Given("I am a user who have access to Account Management module \'username-CurrentSprintO" +
                    "perations\' , \'password-CurrentSprintOperations\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 29
 testRunner.And("I am on Customer Profiles page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
 testRunner.When("I click on an account from the Customer Profiles page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 31
 testRunner.Then("I should be navigated to Customer Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
