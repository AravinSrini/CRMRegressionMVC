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
namespace CRM.UITest.Scripts.InsuranceClaims.ClaimDetails
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.2.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class InsuranceClaims_PaymentTab_AddPaymentFunctionalityFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "Insurance Claims - Payment Tab - Add Payment Functionality.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Insurance Claims - Payment Tab - Add Payment Functionality", null, ProgrammingLanguage.CSharp, new string[] {
                        "Sprint84",
                        "40718"});
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "Insurance Claims - Payment Tab - Add Payment Functionality")))
            {
                global::CRM.UITest.Scripts.InsuranceClaims.ClaimDetails.InsuranceClaims_PaymentTab_AddPaymentFunctionalityFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("40718 - Verify the display and validations of expected fields on Add Payment moda" +
            "l")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Insurance Claims - Payment Tab - Add Payment Functionality")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint84")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("40718")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        public virtual void _40718_VerifyTheDisplayAndValidationsOfExpectedFieldsOnAddPaymentModal()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("40718 - Verify the display and validations of expected fields on Add Payment moda" +
                    "l", new string[] {
                        "GUI"});
#line 5
this.ScenarioSetup(scenarioInfo);
#line 6
testRunner.Given("I am a claims specialist user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 7
testRunner.And("I am on the Claims List page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 8
testRunner.And("I clicked on the hyperlink of a displayed claim", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 9
testRunner.And("I arrive on the Details tab of the selected claim", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
testRunner.And("Clicked on the Payments Tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
testRunner.When("I click on Add Payment button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 12
testRunner.Then("The Add Payment modal will open", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 13
testRunner.And("I will be able to see Payment Type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
testRunner.And("I will be able to see Payment Amount", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
testRunner.And("I will be able to see Payment Date", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
testRunner.And("I will be able to see Check Number", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
testRunner.And("I will be able to see Check Date", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
testRunner.And("I will be able to see Comments", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
testRunner.And("I will be able to see \'Cancel\' button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
testRunner.And("I will be able to see \'Add\' button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
testRunner.And("The following will be required fields : Payment Type, Payment Amount, Payment Dat" +
                    "e, Check Number, Check Date, Comments", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
testRunner.And("The PaymentType will be a selectable dropdown list", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
testRunner.And("The Payment Amount field format will be currency", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
testRunner.And("The Payment Amount field will allow upto two decimal places", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
testRunner.And("The Payment Amount field will auto fill with $ and two decimal places", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
testRunner.And("Payment Date calender will not allow to select a future date", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
testRunner.And("The Payment Date field will be editable with the format -  mm/dd/yyyy", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 28
testRunner.And("The Check Number field will be free form text - allowing a max length of 50 alpha" +
                    "-numeric and special characters", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
testRunner.And("Check Date calender will not allow to select a future date", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
testRunner.And("The Check Date field will be editable with the format -  mm/dd/yyyy", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 31
testRunner.And("The Comments field format will be free form text - allowing a max length of 500 a" +
                    "lpha-numeric and special characters", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("40718 - Verify the existence of Payment Type dropdown values on Add Payment modal" +
            "")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Insurance Claims - Payment Tab - Add Payment Functionality")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint84")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("40718")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("DB")]
        public virtual void _40718_VerifyTheExistenceOfPaymentTypeDropdownValuesOnAddPaymentModal()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("40718 - Verify the existence of Payment Type dropdown values on Add Payment modal" +
                    "", new string[] {
                        "GUI",
                        "DB"});
#line 35
this.ScenarioSetup(scenarioInfo);
#line 36
testRunner.Given("I am a claims specialist user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 37
testRunner.And("I am on the Claims List page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 38
testRunner.And("I clicked on the hyperlink of a displayed claim", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 39
testRunner.And("I arrive on the Details tab of the selected claim", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 40
testRunner.And("Clicked on the Payments Tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 41
testRunner.And("I clicked on the Add Payment button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 42
testRunner.And("The Add Payment modal opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 43
testRunner.When("I click in the  Payment Type field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 44
testRunner.Then(@"I will see a list of payment types <Carrier Direct Pay To Claimant>, <Carrier Payment To DLSW>, <Credit>, <Debit>, <DLSW Payment to Claimant>, <Expected Recovery>, <Expense>, <Insurance Direct Pay To Claimant>, <Other, See Comment>, <Reimbursement>, <Salvage Allowance>, <Subrogation>", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 45
testRunner.And("The payment type list is configurable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        public virtual void _40718_VerifyTheDisplayOfOptionalFieldsOnAddPaymentModalWhenUserSelectsEitherExpectedRecoveryOrSalvageAllowanceAsPaymentType(string paymentType, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "GUI"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("40718 - Verify the display of optional fields on Add Payment modal when user sele" +
                    "cts either \'Expected Recovery\' or \'Salvage Allowance\' as Payment Type", @__tags);
#line 48
this.ScenarioSetup(scenarioInfo);
#line 49
testRunner.Given("I am a claims specialist user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 50
testRunner.And("I am on the Claims List page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 51
testRunner.And("I clicked on the hyperlink of a displayed claim", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 52
testRunner.And("I arrive on the Details tab of the selected claim", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
testRunner.And("I clicked on the Payments Tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 54
testRunner.And("Arrived on the Payments Tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 55
testRunner.And("I clicked on the Add Payment button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 56
testRunner.And("The Add Payment modal opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 57
testRunner.When(string.Format("I select {0}", paymentType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 58
testRunner.Then("Payment Date is optional", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 59
testRunner.And("Check Number is optional", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 60
testRunner.And("Check Date is optional", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("40718 - Verify the display of optional fields on Add Payment modal when user sele" +
            "cts either \'Expected Recovery\' or \'Salvage Allowance\' as Payment Type: Expected " +
            "Recovery")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Insurance Claims - Payment Tab - Add Payment Functionality")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint84")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("40718")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Expected Recovery")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:PaymentType", "Expected Recovery")]
        public virtual void _40718_VerifyTheDisplayOfOptionalFieldsOnAddPaymentModalWhenUserSelectsEitherExpectedRecoveryOrSalvageAllowanceAsPaymentType_ExpectedRecovery()
        {
#line 48
this._40718_VerifyTheDisplayOfOptionalFieldsOnAddPaymentModalWhenUserSelectsEitherExpectedRecoveryOrSalvageAllowanceAsPaymentType("Expected Recovery", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("40718 - Verify the display of optional fields on Add Payment modal when user sele" +
            "cts either \'Expected Recovery\' or \'Salvage Allowance\' as Payment Type: Salvage A" +
            "llowance")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Insurance Claims - Payment Tab - Add Payment Functionality")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint84")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("40718")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Salvage Allowance")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:PaymentType", "Salvage Allowance")]
        public virtual void _40718_VerifyTheDisplayOfOptionalFieldsOnAddPaymentModalWhenUserSelectsEitherExpectedRecoveryOrSalvageAllowanceAsPaymentType_SalvageAllowance()
        {
#line 48
this._40718_VerifyTheDisplayOfOptionalFieldsOnAddPaymentModalWhenUserSelectsEitherExpectedRecoveryOrSalvageAllowanceAsPaymentType("Salvage Allowance", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("40718 - Verify the functionality of Cancel button on Add Payment modal")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Insurance Claims - Payment Tab - Add Payment Functionality")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint84")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("40718")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        public virtual void _40718_VerifyTheFunctionalityOfCancelButtonOnAddPaymentModal()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("40718 - Verify the functionality of Cancel button on Add Payment modal", new string[] {
                        "Functional"});
#line 68
this.ScenarioSetup(scenarioInfo);
#line 69
testRunner.Given("I am a claims specialist user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 70
testRunner.And("I am on the Claims List page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 71
testRunner.And("I clicked on the hyperlink of a displayed claim", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 72
testRunner.And("I arrive on the Details tab of the selected claim", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 73
testRunner.And("I clicked on the Payments Tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 74
testRunner.And("Arrived on Payments Tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 75
testRunner.And("I clicked on the Add Payment button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 76
testRunner.And("The Add Payment modal opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 77
testRunner.When("I click on Cancel button of Add Payemnt Modal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 78
testRunner.Then("The modal will close", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 79
testRunner.And("No new payment entry is created.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("40718 - Verify the functionality of Save button on Add Payment modal when user pa" +
            "sses values to all required fields")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Insurance Claims - Payment Tab - Add Payment Functionality")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint84")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("40718")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        public virtual void _40718_VerifyTheFunctionalityOfSaveButtonOnAddPaymentModalWhenUserPassesValuesToAllRequiredFields()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("40718 - Verify the functionality of Save button on Add Payment modal when user pa" +
                    "sses values to all required fields", new string[] {
                        "Functional"});
#line 82
this.ScenarioSetup(scenarioInfo);
#line 83
testRunner.Given("I am a claims specialist user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 84
testRunner.And("I am on the Claims List page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 85
testRunner.And("I clicked on the hyperlink of a displayed claim", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 86
testRunner.And("I arrive on the Details tab of the selected claim", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 87
testRunner.And("I clicked on the Payments Tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 88
testRunner.And("Arrived on the Payments Tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 89
testRunner.And("I clicked on the Add Payment button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 90
testRunner.And("The Add Payment modal opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 91
testRunner.And("I entered all required information", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 92
testRunner.When("I click on Save button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 93
testRunner.Then("The modal will close", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 94
testRunner.And("The new payment entry will be displayed in the Payment grid.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("40718 - Verify the functionality of Save button on Add Payment modal when user do" +
            "esn\'t pass values to all required fields")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Insurance Claims - Payment Tab - Add Payment Functionality")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint84")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("40718")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        public virtual void _40718_VerifyTheFunctionalityOfSaveButtonOnAddPaymentModalWhenUserDoesntPassValuesToAllRequiredFields()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("40718 - Verify the functionality of Save button on Add Payment modal when user do" +
                    "esn\'t pass values to all required fields", new string[] {
                        "Functional"});
#line 97
this.ScenarioSetup(scenarioInfo);
#line 98
testRunner.Given("I am a claims specialist user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 99
testRunner.And("I am on the Claims List page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 100
testRunner.And("I clicked on the hyperlink of a displayed claim", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 101
testRunner.And("I arrive on the Details tab of the selected claim", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 102
testRunner.And("I clicked on the Payments Tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 103
testRunner.And("Arrived on the Payments Tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 104
testRunner.And("I clicked on the Add Payment button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 105
testRunner.And("The Add Payment modal opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 106
testRunner.And("I did not enter all required information", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 107
testRunner.When("I click on Save button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 108
testRunner.Then("I will receive message <Please complete all required information>", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 109
testRunner.And("The required fields missing information will be highlighted in red.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
