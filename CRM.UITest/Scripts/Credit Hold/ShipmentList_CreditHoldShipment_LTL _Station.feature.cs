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
    public partial class ShipmentList_CreditHoldShipment_LTL_Station_Feature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "ShipmentList_CreditHoldShipment_LTL _Station.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "ShipmentList_CreditHoldShipment_LTL _Station.", null, ProgrammingLanguage.CSharp, new string[] {
                        "47063",
                        "Sprint86",
                        "Regression"});
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "ShipmentList_CreditHoldShipment_LTL _Station.")))
            {
                global::CRM.UITest.Scripts.CreditHold.ShipmentList_CreditHoldShipment_LTL_Station_Feature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("47063_Verify Credit Hold indicator in select drop down list for the the customer(" +
            "for both Parent and sub Account) which is on credit hold")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ShipmentList_CreditHoldShipment_LTL _Station.")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("47063")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint86")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        public virtual void _47063_VerifyCreditHoldIndicatorInSelectDropDownListForTheTheCustomerForBothParentAndSubAccountWhichIsOnCreditHold()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("47063_Verify Credit Hold indicator in select drop down list for the the customer(" +
                    "for both Parent and sub Account) which is on credit hold", ((string[])(null)));
#line 5
this.ScenarioSetup(scenarioInfo);
#line 6
 testRunner.Given("that I am a sales, sales management, operation, or station owner user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 7
    testRunner.And("I am on the shipment List page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 8
 testRunner.And("I clicked in the Select drop down list", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 9
 testRunner.When("any associated customer has been placed on credit Hold", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
 testRunner.Then("I will see an indicator that the customer is on credit Hold", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("47063_Verify the message \"The selected customer is on Credit Hold\" when clicking " +
            "on Add shipment button for the Credit hold customer")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ShipmentList_CreditHoldShipment_LTL _Station.")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("47063")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint86")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        public virtual void _47063_VerifyTheMessageTheSelectedCustomerIsOnCreditHoldWhenClickingOnAddShipmentButtonForTheCreditHoldCustomer()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("47063_Verify the message \"The selected customer is on Credit Hold\" when clicking " +
                    "on Add shipment button for the Credit hold customer", ((string[])(null)));
#line 13
this.ScenarioSetup(scenarioInfo);
#line 14
 testRunner.Given("that I am a sales, sales management, operation, or station owner user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 15
 testRunner.And("I am on the Shipment List page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
 testRunner.And("I clicked in the Select drop down list", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
 testRunner.And("I Selected a customer that is on Credit Hold", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
 testRunner.When("I clicked on the Add Shipment button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 19
 testRunner.Then("I will receive a Message As The selected customer is on Credit Hold", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        public virtual void _47063_VerifyTheMessageTheSelectedCustomerIsOnCreditHoldWhenClickingOnCopyShipmentOrReturnShipmentInShipmentForTheCreditHoldCustomer(string button, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("47063_Verify the message \"The selected customer is on Credit Hold\" when clicking " +
                    "on copy shipment or Return shipment in shipment for the credit hold customer", exampleTags);
#line 22
this.ScenarioSetup(scenarioInfo);
#line 23
 testRunner.Given("that I am a sales, sales management, operation, or station owner user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 24
 testRunner.And("I am on the Shipment List page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
 testRunner.And("I clicked in the Select drop down list", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
 testRunner.And("I Selected a customer that is on Credit Hold", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
 testRunner.And("the Shipment List refreshed to display at least one shipment", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 28
 testRunner.When(string.Format("I Click on the {0} of a displayed shipment", button), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 29
 testRunner.Then("I will receive a Message As The selected customer is on Credit Hold", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("47063_Verify the message \"The selected customer is on Credit Hold\" when clicking " +
            "on copy shipment or Return shipment in shipment for the credit hold customer: Co" +
            "py Shipment")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ShipmentList_CreditHoldShipment_LTL _Station.")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("47063")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint86")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Copy Shipment")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:button", "Copy Shipment")]
        public virtual void _47063_VerifyTheMessageTheSelectedCustomerIsOnCreditHoldWhenClickingOnCopyShipmentOrReturnShipmentInShipmentForTheCreditHoldCustomer_CopyShipment()
        {
#line 22
this._47063_VerifyTheMessageTheSelectedCustomerIsOnCreditHoldWhenClickingOnCopyShipmentOrReturnShipmentInShipmentForTheCreditHoldCustomer("Copy Shipment", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("47063_Verify the message \"The selected customer is on Credit Hold\" when clicking " +
            "on copy shipment or Return shipment in shipment for the credit hold customer: Re" +
            "turn Shipment")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ShipmentList_CreditHoldShipment_LTL _Station.")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("47063")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint86")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Return Shipment")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:button", "Return Shipment")]
        public virtual void _47063_VerifyTheMessageTheSelectedCustomerIsOnCreditHoldWhenClickingOnCopyShipmentOrReturnShipmentInShipmentForTheCreditHoldCustomer_ReturnShipment()
        {
#line 22
this._47063_VerifyTheMessageTheSelectedCustomerIsOnCreditHoldWhenClickingOnCopyShipmentOrReturnShipmentInShipmentForTheCreditHoldCustomer("Return Shipment", ((string[])(null)));
#line hidden
        }
    }
}
#pragma warning restore
#endregion
