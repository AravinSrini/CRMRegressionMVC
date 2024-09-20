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
    public partial class _91197_InsuranceClaimsLabels_SubmitAClaimForm_UpdateWeightLabelToUnitWeightFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "91197-Insurance Claims (Labels)-Submit a Claim Form-Update Weight Label to Unit Weight.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "91197-Insurance Claims (Labels)-Submit a Claim Form-Update Weight Label to Unit W" +
                    "eight", null, ProgrammingLanguage.CSharp, new string[] {
                        "Sprint94",
                        "91197"});
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "91197-Insurance Claims (Labels)-Submit a Claim Form-Update Weight Label to Unit W" +
                            "eight")))
            {
                global::CRM.UITest.Scripts.InsuranceClaims.ClaimDetails._91197_InsuranceClaimsLabels_SubmitAClaimForm_UpdateWeightLabelToUnitWeightFeature.FeatureSetup(null);
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
        
        public virtual void _91197_VerifyRenamedWeightToUnitWeightForSubmitClaimPage(string username, string password, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("91197-Verify renamed weight to Unit weight for submit claim page", exampleTags);
#line 4
this.ScenarioSetup(scenarioInfo);
#line 5
testRunner.Given(string.Format("I am a user and login into application with valid {0} and {1},", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 6
testRunner.And("I am on the Claims List,", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 7
testRunner.And("I clicked on the Submit a Claim button,", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 8
testRunner.When("I arrive on the Submit a Claim page,", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 9
testRunner.Then("the Weight (LBS) field in the Claim Details section will be renamed Unit Weight (" +
                    "LBS).", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("91197-Verify renamed weight to Unit weight for submit claim page: username-Curren" +
            "tsprintClaimspecialist")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "91197-Insurance Claims (Labels)-Submit a Claim Form-Update Weight Label to Unit W" +
            "eight")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint94")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("91197")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "username-CurrentsprintClaimspecialist")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "username-CurrentsprintClaimspecialist")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "password-CurrentsprintClaimspecialist")]
        public virtual void _91197_VerifyRenamedWeightToUnitWeightForSubmitClaimPage_Username_CurrentsprintClaimspecialist()
        {
#line 4
this._91197_VerifyRenamedWeightToUnitWeightForSubmitClaimPage("username-CurrentsprintClaimspecialist", "password-CurrentsprintClaimspecialist", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("91197-Verify renamed weight to Unit weight for submit claim page: username-Curren" +
            "tSprintshpentry")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "91197-Insurance Claims (Labels)-Submit a Claim Form-Update Weight Label to Unit W" +
            "eight")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint94")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("91197")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "username-CurrentSprintshpentry")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "username-CurrentSprintshpentry")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "password-CurrentSprintshpentry")]
        public virtual void _91197_VerifyRenamedWeightToUnitWeightForSubmitClaimPage_Username_CurrentSprintshpentry()
        {
#line 4
this._91197_VerifyRenamedWeightToUnitWeightForSubmitClaimPage("username-CurrentSprintshpentry", "password-CurrentSprintshpentry", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("91197-Verify renamed weight to Unit weight for submit claim page: username-Curren" +
            "tSprintOperations")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "91197-Insurance Claims (Labels)-Submit a Claim Form-Update Weight Label to Unit W" +
            "eight")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint94")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("91197")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "username-CurrentSprintOperations")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "username-CurrentSprintOperations")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "password-CurrentSprintOperations")]
        public virtual void _91197_VerifyRenamedWeightToUnitWeightForSubmitClaimPage_Username_CurrentSprintOperations()
        {
#line 4
this._91197_VerifyRenamedWeightToUnitWeightForSubmitClaimPage("username-CurrentSprintOperations", "password-CurrentSprintOperations", ((string[])(null)));
#line hidden
        }
        
        public virtual void _91197_VerifyRenamedWeightToUnitWeightForSubmitClaimPageWithAdditonalItem(string username, string password, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("91197-Verify renamed weight to Unit weight for submit claim page with Additonal i" +
                    "tem", exampleTags);
#line 17
this.ScenarioSetup(scenarioInfo);
#line 18
testRunner.Given(string.Format("I am a user and login into application with valid {0} and {1},", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 19
testRunner.And("I am on the Claims List,", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
testRunner.And("I clicked on the Submit a Claim button,", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
testRunner.And("I am on the submit a Claim page,", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
testRunner.When("I click on the Add Another Item button in the Claim Details section,", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 23
testRunner.Then("the Weight (LBS) field of the additional item will be renamed Unit Weight (LBS).", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("91197-Verify renamed weight to Unit weight for submit claim page with Additonal i" +
            "tem: username-CurrentsprintClaimspecialist")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "91197-Insurance Claims (Labels)-Submit a Claim Form-Update Weight Label to Unit W" +
            "eight")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint94")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("91197")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "username-CurrentsprintClaimspecialist")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "username-CurrentsprintClaimspecialist")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "password-CurrentsprintClaimspecialist")]
        public virtual void _91197_VerifyRenamedWeightToUnitWeightForSubmitClaimPageWithAdditonalItem_Username_CurrentsprintClaimspecialist()
        {
#line 17
this._91197_VerifyRenamedWeightToUnitWeightForSubmitClaimPageWithAdditonalItem("username-CurrentsprintClaimspecialist", "password-CurrentsprintClaimspecialist", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("91197-Verify renamed weight to Unit weight for submit claim page with Additonal i" +
            "tem: username-CurrentSprintshpentry")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "91197-Insurance Claims (Labels)-Submit a Claim Form-Update Weight Label to Unit W" +
            "eight")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint94")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("91197")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "username-CurrentSprintshpentry")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "username-CurrentSprintshpentry")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "password-CurrentSprintshpentry")]
        public virtual void _91197_VerifyRenamedWeightToUnitWeightForSubmitClaimPageWithAdditonalItem_Username_CurrentSprintshpentry()
        {
#line 17
this._91197_VerifyRenamedWeightToUnitWeightForSubmitClaimPageWithAdditonalItem("username-CurrentSprintshpentry", "password-CurrentSprintshpentry", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("91197-Verify renamed weight to Unit weight for submit claim page with Additonal i" +
            "tem: username-CurrentSprintOperations")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "91197-Insurance Claims (Labels)-Submit a Claim Form-Update Weight Label to Unit W" +
            "eight")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint94")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("91197")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "username-CurrentSprintOperations")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "username-CurrentSprintOperations")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "password-CurrentSprintOperations")]
        public virtual void _91197_VerifyRenamedWeightToUnitWeightForSubmitClaimPageWithAdditonalItem_Username_CurrentSprintOperations()
        {
#line 17
this._91197_VerifyRenamedWeightToUnitWeightForSubmitClaimPageWithAdditonalItem("username-CurrentSprintOperations", "password-CurrentSprintOperations", ((string[])(null)));
#line hidden
        }
        
        public virtual void _91197_VerifyRenamedWeightToUnitWeightForResubmitClaimPage(string user, string username, string password, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("91197-Verify renamed weight to Unit weight for resubmit claim page", exampleTags);
#line 31
this.ScenarioSetup(scenarioInfo);
#line 32
testRunner.Given(string.Format("I am a user and login into application with valid {0} and {1},", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 33
testRunner.And("I am on the Claims List,", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 34
testRunner.And("in Show Status Amend box is checked", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 35
testRunner.And(string.Format("I clicked on Edit button of a claim that is in Amend status for {0}", user), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 36
testRunner.When("I arrive on the Resubmit a Claim page,", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 37
testRunner.Then("the Weight (LBS) field in the Claim Details section of resubmit page will be rena" +
                    "med Unit Weight (LBS).", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("91197-Verify renamed weight to Unit weight for resubmit claim page: claimspeciali" +
            "st")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "91197-Insurance Claims (Labels)-Submit a Claim Form-Update Weight Label to Unit W" +
            "eight")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint94")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("91197")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "claimspecialist")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:user", "claimspecialist")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "username-CurrentsprintClaimspecialist")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "password-CurrentsprintClaimspecialist")]
        public virtual void _91197_VerifyRenamedWeightToUnitWeightForResubmitClaimPage_Claimspecialist()
        {
#line 31
this._91197_VerifyRenamedWeightToUnitWeightForResubmitClaimPage("claimspecialist", "username-CurrentsprintClaimspecialist", "password-CurrentsprintClaimspecialist", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("91197-Verify renamed weight to Unit weight for resubmit claim page: External")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "91197-Insurance Claims (Labels)-Submit a Claim Form-Update Weight Label to Unit W" +
            "eight")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint94")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("91197")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "External")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:user", "External")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "username-CurrentSprintshpentry")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "password-CurrentSprintshpentry")]
        public virtual void _91197_VerifyRenamedWeightToUnitWeightForResubmitClaimPage_External()
        {
#line 31
this._91197_VerifyRenamedWeightToUnitWeightForResubmitClaimPage("External", "username-CurrentSprintshpentry", "password-CurrentSprintshpentry", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("91197-Verify renamed weight to Unit weight for resubmit claim page: Internal")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "91197-Insurance Claims (Labels)-Submit a Claim Form-Update Weight Label to Unit W" +
            "eight")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint94")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("91197")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Internal")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:user", "Internal")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "username-CurrentSprintOperations")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "password-CurrentSprintOperations")]
        public virtual void _91197_VerifyRenamedWeightToUnitWeightForResubmitClaimPage_Internal()
        {
#line 31
this._91197_VerifyRenamedWeightToUnitWeightForResubmitClaimPage("Internal", "username-CurrentSprintOperations", "password-CurrentSprintOperations", ((string[])(null)));
#line hidden
        }
        
        public virtual void _91197_VerifyRenamedWeightToUnitWeightForResubmitClaimPageWithAdditonalItem(string user, string username, string password, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("91197-Verify renamed weight to Unit weight for resubmit claim page with Additonal" +
                    " item", exampleTags);
#line 47
this.ScenarioSetup(scenarioInfo);
#line 48
testRunner.Given(string.Format("I am a user and login into application with valid {0} and {1},", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 49
testRunner.And("I am on the Claims List,", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 50
testRunner.And("in Show Status Amend box is checked", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 51
testRunner.And(string.Format("I clicked on Edit button of a claim that is in Amend status for {0}", user), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 52
testRunner.And("I am on the Submit a Claim page,", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
testRunner.When("I click on the Add Another Item button in the Claim Details section,", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 54
testRunner.Then("the Weight (LBS) field of the additional item of resubmit page will be renamed Un" +
                    "it Weight (LBS).", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("91197-Verify renamed weight to Unit weight for resubmit claim page with Additonal" +
            " item: claimspecialist")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "91197-Insurance Claims (Labels)-Submit a Claim Form-Update Weight Label to Unit W" +
            "eight")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint94")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("91197")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "claimspecialist")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:user", "claimspecialist")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "username-CurrentsprintClaimspecialist")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "password-CurrentsprintClaimspecialist")]
        public virtual void _91197_VerifyRenamedWeightToUnitWeightForResubmitClaimPageWithAdditonalItem_Claimspecialist()
        {
#line 47
this._91197_VerifyRenamedWeightToUnitWeightForResubmitClaimPageWithAdditonalItem("claimspecialist", "username-CurrentsprintClaimspecialist", "password-CurrentsprintClaimspecialist", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("91197-Verify renamed weight to Unit weight for resubmit claim page with Additonal" +
            " item: External")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "91197-Insurance Claims (Labels)-Submit a Claim Form-Update Weight Label to Unit W" +
            "eight")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint94")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("91197")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "External")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:user", "External")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "username-CurrentSprintshpentry")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "password-CurrentSprintshpentry")]
        public virtual void _91197_VerifyRenamedWeightToUnitWeightForResubmitClaimPageWithAdditonalItem_External()
        {
#line 47
this._91197_VerifyRenamedWeightToUnitWeightForResubmitClaimPageWithAdditonalItem("External", "username-CurrentSprintshpentry", "password-CurrentSprintshpentry", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("91197-Verify renamed weight to Unit weight for resubmit claim page with Additonal" +
            " item: Internal")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "91197-Insurance Claims (Labels)-Submit a Claim Form-Update Weight Label to Unit W" +
            "eight")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint94")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("91197")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Internal")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:user", "Internal")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "username-CurrentSprintOperations")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "password-CurrentSprintOperations")]
        public virtual void _91197_VerifyRenamedWeightToUnitWeightForResubmitClaimPageWithAdditonalItem_Internal()
        {
#line 47
this._91197_VerifyRenamedWeightToUnitWeightForResubmitClaimPageWithAdditonalItem("Internal", "username-CurrentSprintOperations", "password-CurrentSprintOperations", ((string[])(null)));
#line hidden
        }
    }
}
#pragma warning restore
#endregion

