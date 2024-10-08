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
    public partial class InsuranceClaims_ClaimDetails_CreateClaimPacketForCarrierSubmissionFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "Insurance Claims - Claim Details - Create Claim Packet For Carrier Submission.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Insurance Claims - Claim Details - Create Claim Packet For Carrier Submission", null, ProgrammingLanguage.CSharp, new string[] {
                        "90440",
                        "Sprint94",
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "Insurance Claims - Claim Details - Create Claim Packet For Carrier Submission")))
            {
                global::CRM.UITest.Scripts.InsuranceClaims.ClaimDetails.InsuranceClaims_ClaimDetails_CreateClaimPacketForCarrierSubmissionFeature.FeatureSetup(null);
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
        
        public virtual void _90440_VerifyExportDropdownOptionsOfANonAmendedClaimForClaimSpecialistUser(string claimNumber, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("90440_Verify Export dropdown options of a non amended claim for Claim Specialist " +
                    "user", exampleTags);
#line 4
this.ScenarioSetup(scenarioInfo);
#line 5
 testRunner.Given("I am a claim specialist user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 6
 testRunner.And(string.Format("I am on Claim Details page of a claim that was not previously amended {0}", claimNumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 7
 testRunner.When("I clicked on the Export button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 8
 testRunner.Then("I will see Claim Packet new option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 9
 testRunner.And("I will see the options listed in following order Claim Submitted By Customer, His" +
                    "tory Tab, Claim Packet and Payment Tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("90440_Verify Export dropdown options of a non amended claim for Claim Specialist " +
            "user: 2019000712")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Insurance Claims - Claim Details - Create Claim Packet For Carrier Submission")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("90440")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint94")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "2019000712")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:claimNumber", "2019000712")]
        public virtual void _90440_VerifyExportDropdownOptionsOfANonAmendedClaimForClaimSpecialistUser_2019000712()
        {
#line 4
this._90440_VerifyExportDropdownOptionsOfANonAmendedClaimForClaimSpecialistUser("2019000712", ((string[])(null)));
#line hidden
        }
        
        public virtual void _90440_VerifyExportDropdownOptionsOfAnAmendedClaimForClaimSpecialistUser(string claimNumber, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("90440_Verify Export dropdown options of an amended claim for Claim Specialist use" +
                    "r", exampleTags);
#line 15
this.ScenarioSetup(scenarioInfo);
#line 16
 testRunner.Given("I am a claim specialist user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 17
 testRunner.And(string.Format("I am on the Claim Details page of a claim that was previously amended {0}", claimNumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
 testRunner.When("I clicked on the Export button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 19
 testRunner.Then("I will see Claim Packet new option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 20
 testRunner.And("I will see the options listed in following order Claim Submitted By Customer, Cla" +
                    "im Amended By Customer, History Tab, Claim Packet and Payment Tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("90440_Verify Export dropdown options of an amended claim for Claim Specialist use" +
            "r: 2019000695")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Insurance Claims - Claim Details - Create Claim Packet For Carrier Submission")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("90440")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint94")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "2019000695")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:claimNumber", "2019000695")]
        public virtual void _90440_VerifyExportDropdownOptionsOfAnAmendedClaimForClaimSpecialistUser_2019000695()
        {
#line 15
this._90440_VerifyExportDropdownOptionsOfAnAmendedClaimForClaimSpecialistUser("2019000695", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("90440_Verify the Select Document for Export modal for Claim Specialist user")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Insurance Claims - Claim Details - Create Claim Packet For Carrier Submission")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("90440")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint94")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        public virtual void _90440_VerifyTheSelectDocumentForExportModalForClaimSpecialistUser()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("90440_Verify the Select Document for Export modal for Claim Specialist user", ((string[])(null)));
#line 26
this.ScenarioSetup(scenarioInfo);
#line 27
 testRunner.Given("I am a claim specialist user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 28
 testRunner.And("I am on Claim Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
 testRunner.And("I clicked on the Export button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
 testRunner.When("I selected Claim Packet", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 31
 testRunner.Then("I will see a Select Documents for Export modal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        public virtual void _90440_VerifyTheDetailsOfSelectDocumentForExportModalForClaimSpecialistUser(string claimNumber, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("90440_Verify the Details of Select Document for Export modal for Claim Specialist" +
                    " user", exampleTags);
#line 33
this.ScenarioSetup(scenarioInfo);
#line 34
 testRunner.Given("I am a claim specialist user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 35
 testRunner.And(string.Format("I am on the Claim Details page of a claim that was previously amended {0}", claimNumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 36
 testRunner.And("I clicked on the Export button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 37
 testRunner.When("I selected Claim Packet", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 38
 testRunner.Then("I will see the list of documents that have been saved to the claim include the Do" +
                    "cument type and Document Name.extension in the modal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 39
 testRunner.And("Each document will have a check box, its selectable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 40
 testRunner.And("by default displayed documents will be auto-selected", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 41
 testRunner.And("I will see the verbiage- Note: Claim form PDF will be automatically included", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 42
 testRunner.And("I will see a Cancel, Download buttons", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("90440_Verify the Details of Select Document for Export modal for Claim Specialist" +
            " user: 2019000695")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Insurance Claims - Claim Details - Create Claim Packet For Carrier Submission")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("90440")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint94")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "2019000695")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:claimNumber", "2019000695")]
        public virtual void _90440_VerifyTheDetailsOfSelectDocumentForExportModalForClaimSpecialistUser_2019000695()
        {
#line 33
this._90440_VerifyTheDetailsOfSelectDocumentForExportModalForClaimSpecialistUser("2019000695", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("90440_Verify the Cancel button functionality of Select Document for Export modal " +
            "for Claim Specialist user")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Insurance Claims - Claim Details - Create Claim Packet For Carrier Submission")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("90440")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint94")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        public virtual void _90440_VerifyTheCancelButtonFunctionalityOfSelectDocumentForExportModalForClaimSpecialistUser()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("90440_Verify the Cancel button functionality of Select Document for Export modal " +
                    "for Claim Specialist user", ((string[])(null)));
#line 48
this.ScenarioSetup(scenarioInfo);
#line 49
 testRunner.Given("I am a claim specialist user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 50
 testRunner.And("I am on Claim Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 51
 testRunner.And("I clicked on the Export button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 52
 testRunner.And("I selected Claim Packet", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
 testRunner.When("I click on the Cancel button of Select Documents for Export modal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 54
 testRunner.Then("the modal will close", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("90440_Verify Select Documents for Export modal not closing on clicking outside th" +
            "e modal")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Insurance Claims - Claim Details - Create Claim Packet For Carrier Submission")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("90440")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint94")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        public virtual void _90440_VerifySelectDocumentsForExportModalNotClosingOnClickingOutsideTheModal()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("90440_Verify Select Documents for Export modal not closing on clicking outside th" +
                    "e modal", ((string[])(null)));
#line 56
this.ScenarioSetup(scenarioInfo);
#line 57
 testRunner.Given("I am a claim specialist user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 58
 testRunner.And("I am on Claim Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 59
 testRunner.And("I clicked on the Export button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 60
 testRunner.And("I selected Claim Packet", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 61
 testRunner.And("I will see a Select Documents for Export modal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 62
 testRunner.When("I click anywhere outside the modal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 63
 testRunner.Then("the modal should not close", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        public virtual void _90440_VerifyTheClaimPacketOptionInNonAmendedClaimForTheUsersOtherThanClaimSpecialist(string userName, string password, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("90440_Verify the claim packet option in non amended claim for the users other tha" +
                    "n claim specialist", exampleTags);
#line 65
this.ScenarioSetup(scenarioInfo);
#line 66
 testRunner.Given(string.Format("I am an operations, sales, sales management or station owner user {0},{1}", userName, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 67
 testRunner.And("I am on the Claim List page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 68
 testRunner.And("I am on the Claim Details page of a claim that was not previously amended", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 69
 testRunner.When("I clicked on the Export button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 70
 testRunner.Then("I will not see a new option Claim Packet", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("90440_Verify the claim packet option in non amended claim for the users other tha" +
            "n claim specialist: username-CurrentSprintOperations")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Insurance Claims - Claim Details - Create Claim Packet For Carrier Submission")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("90440")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint94")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "username-CurrentSprintOperations")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:UserName", "username-CurrentSprintOperations")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "password-CurrentSprintOperations")]
        public virtual void _90440_VerifyTheClaimPacketOptionInNonAmendedClaimForTheUsersOtherThanClaimSpecialist_Username_CurrentSprintOperations()
        {
#line 65
this._90440_VerifyTheClaimPacketOptionInNonAmendedClaimForTheUsersOtherThanClaimSpecialist("username-CurrentSprintOperations", "password-CurrentSprintOperations", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("90440_Verify the claim packet option in non amended claim for the users other tha" +
            "n claim specialist: username-CurrentSprintSales")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Insurance Claims - Claim Details - Create Claim Packet For Carrier Submission")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("90440")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint94")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "username-CurrentSprintSales")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:UserName", "username-CurrentSprintSales")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "password-CurrentSprintSales")]
        public virtual void _90440_VerifyTheClaimPacketOptionInNonAmendedClaimForTheUsersOtherThanClaimSpecialist_Username_CurrentSprintSales()
        {
#line 65
this._90440_VerifyTheClaimPacketOptionInNonAmendedClaimForTheUsersOtherThanClaimSpecialist("username-CurrentSprintSales", "password-CurrentSprintSales", ((string[])(null)));
#line hidden
        }
        
        public virtual void _90440_VerifyTheClaimPacketOptionInAmendedClaimForTheUsersOtherThanClaimSpecialist(string userName, string password, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("90440_Verify the claim packet option in amended claim for the users other than cl" +
                    "aim specialist", exampleTags);
#line 77
this.ScenarioSetup(scenarioInfo);
#line 78
 testRunner.Given(string.Format("I am an operations, sales, sales management or station owner user {0},{1}", userName, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 79
 testRunner.And("I am on the Claim List page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 80
 testRunner.And("I am on Claim Details page of a claim that was previously amended", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 81
 testRunner.When("I clicked on the Export button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 82
 testRunner.Then("I will not see a new option Claim Packet", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("90440_Verify the claim packet option in amended claim for the users other than cl" +
            "aim specialist: username-CurrentSprintOperations")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Insurance Claims - Claim Details - Create Claim Packet For Carrier Submission")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("90440")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint94")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "username-CurrentSprintOperations")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:UserName", "username-CurrentSprintOperations")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "password-CurrentSprintOperations")]
        public virtual void _90440_VerifyTheClaimPacketOptionInAmendedClaimForTheUsersOtherThanClaimSpecialist_Username_CurrentSprintOperations()
        {
#line 77
this._90440_VerifyTheClaimPacketOptionInAmendedClaimForTheUsersOtherThanClaimSpecialist("username-CurrentSprintOperations", "password-CurrentSprintOperations", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("90440_Verify the claim packet option in amended claim for the users other than cl" +
            "aim specialist: username-CurrentSprintSales")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Insurance Claims - Claim Details - Create Claim Packet For Carrier Submission")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("90440")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint94")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "username-CurrentSprintSales")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:UserName", "username-CurrentSprintSales")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "password-CurrentSprintSales")]
        public virtual void _90440_VerifyTheClaimPacketOptionInAmendedClaimForTheUsersOtherThanClaimSpecialist_Username_CurrentSprintSales()
        {
#line 77
this._90440_VerifyTheClaimPacketOptionInAmendedClaimForTheUsersOtherThanClaimSpecialist("username-CurrentSprintSales", "password-CurrentSprintSales", ((string[])(null)));
#line hidden
        }
    }
}
#pragma warning restore
#endregion

