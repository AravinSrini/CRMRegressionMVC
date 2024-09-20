﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.3.0.0
//      SpecFlow Generator Version:2.3.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace CRM.UITest.Scripts.CustomerInvoices
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class CustomerInvoice_FilterInvoicesByRoleFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "Customer Invoice - Filter Invoices by Role.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Customer Invoice - Filter Invoices by Role", null, ProgrammingLanguage.CSharp, new string[] {
                        "41888",
                        "Sprint78"});
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "Customer Invoice - Filter Invoices by Role")))
            {
                global::CRM.UITest.Scripts.CustomerInvoices.CustomerInvoice_FilterInvoicesByRoleFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify the Customer Invoices filtering for Sales user")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Customer Invoice - Filter Invoices by Role")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("41888")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint78")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        public virtual void VerifyTheCustomerInvoicesFilteringForSalesUser()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify the Customer Invoices filtering for Sales user", new string[] {
                        "Functional"});
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
 testRunner.Given("I am a Sales user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
 testRunner.When("I arrive on the Customer Invoices list page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 9
 testRunner.Then("I should see invoices for the customer account that I am associated to and I can " +
                    "also see invoices for all the sub accounts", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify the customer Invoices filtering for ShipEntry , ShipEntryNoRates, ShipInqu" +
            "iry or ShipInquiryNoRates user")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Customer Invoice - Filter Invoices by Role")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("41888")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint78")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        public virtual void VerifyTheCustomerInvoicesFilteringForShipEntryShipEntryNoRatesShipInquiryOrShipInquiryNoRatesUser()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify the customer Invoices filtering for ShipEntry , ShipEntryNoRates, ShipInqu" +
                    "iry or ShipInquiryNoRates user", new string[] {
                        "Functional"});
#line 12
this.ScenarioSetup(scenarioInfo);
#line 13
    testRunner.Given("I am a Sales, ShipEntry, ShipEntryNoRates, ShipInquiry or ShipInquiryNoRates user" +
                    "", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 14
 testRunner.When("I arrive on the Customer Invoices list page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 15
 testRunner.Then("I should see invoices for the customer account that I am associated to and I can " +
                    "also see invoices for all the sub accounts for ShipEntry, ShipEntryNoRates, Ship" +
                    "Inquiry or ShipInquiryNoRates user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify the Customer Invoices filtering for Sales Management, Operations or Statio" +
            "n Owner user")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Customer Invoice - Filter Invoices by Role")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("41888")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint78")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        public virtual void VerifyTheCustomerInvoicesFilteringForSalesManagementOperationsOrStationOwnerUser()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify the Customer Invoices filtering for Sales Management, Operations or Statio" +
                    "n Owner user", new string[] {
                        "Functional"});
#line 21
this.ScenarioSetup(scenarioInfo);
#line 22
    testRunner.Given("I am a Sales Management, Operations or Station Owner user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 23
 testRunner.When("I arrive on the Customer Invoices list page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 24
 testRunner.Then("I should see only the Invoices for the customers of the stations that I am associ" +
                    "ated to", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
