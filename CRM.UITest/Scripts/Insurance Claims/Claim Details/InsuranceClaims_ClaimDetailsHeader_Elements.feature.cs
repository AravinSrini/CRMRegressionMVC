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
    public partial class InsuranceClaims_ClaimDetailsHeader_ElementsFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "InsuranceClaims_ClaimDetailsHeader_Elements.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "InsuranceClaims_ClaimDetailsHeader_Elements", null, ProgrammingLanguage.CSharp, new string[] {
                        "Sprint82",
                        "22092",
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "InsuranceClaims_ClaimDetailsHeader_Elements")))
            {
                global::CRM.UITest.Scripts.InsuranceClaims.ClaimDetails.InsuranceClaims_ClaimDetailsHeader_ElementsFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("22092 - Verify the Claim Details Header Fields")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "InsuranceClaims_ClaimDetailsHeader_Elements")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint82")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("22092")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        public virtual void _22092_VerifyTheClaimDetailsHeaderFields()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("22092 - Verify the Claim Details Header Fields", new string[] {
                        "GUI"});
#line 5
this.ScenarioSetup(scenarioInfo);
#line 6
 testRunner.Given("I am Sales, Sales Management, Operations, Station Owner or Claims Specialist User" +
                    "", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 7
 testRunner.And("I clicked on the hyperlink of any Claim number from the Claim List page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 8
 testRunner.When("I am on the Details tab of the Claim in Claim Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 9
 testRunner.Then("I will see Claim Header Informations", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("22092 - Verify the Header field values are Auto-populated from the Claim Form")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "InsuranceClaims_ClaimDetailsHeader_Elements")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint82")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("22092")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        public virtual void _22092_VerifyTheHeaderFieldValuesAreAuto_PopulatedFromTheClaimForm()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("22092 - Verify the Header field values are Auto-populated from the Claim Form", new string[] {
                        "Functional"});
#line 12
this.ScenarioSetup(scenarioInfo);
#line 13
 testRunner.Given("I am Sales, Sales Management, Operations, Station Owner or Claims Specialist User" +
                    "", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 14
 testRunner.And("I clicked on the hyperlink of any Claim number from the Claim List page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
 testRunner.When("I am on the Details tab of the Claim in Claim Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 16
 testRunner.Then("I will see Header Field values are Auto-populated from the Claim Form", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("22092 - Verify the presence of Claim Form button")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "InsuranceClaims_ClaimDetailsHeader_Elements")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint82")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("22092")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        public virtual void _22092_VerifyThePresenceOfClaimFormButton()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("22092 - Verify the presence of Claim Form button", new string[] {
                        "GUI"});
#line 19
this.ScenarioSetup(scenarioInfo);
#line 20
 testRunner.Given("I am Sales, Sales Management, Operations, Station Owner or Claims Specialist User" +
                    "", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 21
 testRunner.And("I clicked on the hyperlink of any Claim number from the Claim List page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
 testRunner.When("I am on the Details tab of the Claim in Claim Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 23
 testRunner.Then("I will see Claim Form button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("22092 - Verify the Claim Age binded in the Claim Details Page Header section")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "InsuranceClaims_ClaimDetailsHeader_Elements")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint82")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("22092")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        public virtual void _22092_VerifyTheClaimAgeBindedInTheClaimDetailsPageHeaderSection()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("22092 - Verify the Claim Age binded in the Claim Details Page Header section", new string[] {
                        "GUI"});
#line 26
this.ScenarioSetup(scenarioInfo);
#line 27
 testRunner.Given("I am Sales, Sales Management, Operations, Station Owner or Claims Specialist User" +
                    "", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 28
 testRunner.And("I clicked on the hyperlink of any Claim number from the Claim List page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
 testRunner.When("I am on the Details tab of the Claim in Claim Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 30
 testRunner.Then("the Claim Age will be difference in Current Date and Claim Date Submitted", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("22092 - Verify the Carrier Name binding when entered Carrier name is found in CRM" +
            "")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "InsuranceClaims_ClaimDetailsHeader_Elements")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint82")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("22092")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        public virtual void _22092_VerifyTheCarrierNameBindingWhenEnteredCarrierNameIsFoundInCRM()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("22092 - Verify the Carrier Name binding when entered Carrier name is found in CRM" +
                    "", new string[] {
                        "GUI"});
#line 33
this.ScenarioSetup(scenarioInfo);
#line 34
 testRunner.Given("I am Sales, Sales Management, Operations, Station Owner or Claims Specialist User" +
                    "", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 35
 testRunner.And("I clicked on the hyperlink of any Claim number which has valid Carrier from the C" +
                    "laim List page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 36
 testRunner.When("I am on the Claim Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 37
 testRunner.Then("Carrier Name will be binded in the Claim Details Header section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("22092 - Verify the Carrier Name field will display Select when entered Carrier na" +
            "me is not found in CRM")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "InsuranceClaims_ClaimDetailsHeader_Elements")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint82")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("22092")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        public virtual void _22092_VerifyTheCarrierNameFieldWillDisplaySelectWhenEnteredCarrierNameIsNotFoundInCRM()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("22092 - Verify the Carrier Name field will display Select when entered Carrier na" +
                    "me is not found in CRM", new string[] {
                        "GUI"});
#line 40
this.ScenarioSetup(scenarioInfo);
#line 41
 testRunner.Given("I am Sales, Sales Management, Operations, Station Owner or Claims Specialist User" +
                    "", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 42
 testRunner.And("I clicked on the hyperlink of any Claim number which has invalid Carrier from the" +
                    " Claim List page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 43
 testRunner.When("I am on the Claim Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 44
 testRunner.Then("Carrier Name field will display Select verbiage in the Claim Details Header secti" +
                    "on", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("22092 - Verify the associated Carrier SCAC Code binded in the SCAC field when the" +
            " Carrier field has a valid Carrier")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "InsuranceClaims_ClaimDetailsHeader_Elements")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint82")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("22092")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        public virtual void _22092_VerifyTheAssociatedCarrierSCACCodeBindedInTheSCACFieldWhenTheCarrierFieldHasAValidCarrier()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("22092 - Verify the associated Carrier SCAC Code binded in the SCAC field when the" +
                    " Carrier field has a valid Carrier", new string[] {
                        "GUI"});
#line 47
this.ScenarioSetup(scenarioInfo);
#line 48
 testRunner.Given("I am Sales, Sales Management, Operations, Station Owner or Claims Specialist User" +
                    "", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 49
 testRunner.And("I clicked on the hyperlink of any Claim number which has valid Carrier from the C" +
                    "laim List page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 50
 testRunner.When("I am on the Claim Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 51
 testRunner.Then("associated SCAC code of that Carrier will be binded in SCAC field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("22092 - Verify the SCAC field is blank when the Carrier field has invalid Carrier" +
            "")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "InsuranceClaims_ClaimDetailsHeader_Elements")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint82")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("22092")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        public virtual void _22092_VerifyTheSCACFieldIsBlankWhenTheCarrierFieldHasInvalidCarrier()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("22092 - Verify the SCAC field is blank when the Carrier field has invalid Carrier" +
                    "", new string[] {
                        "GUI"});
#line 54
this.ScenarioSetup(scenarioInfo);
#line 55
 testRunner.Given("I am Sales, Sales Management, Operations, Station Owner or Claims Specialist User" +
                    "", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 56
 testRunner.And("I clicked on the hyperlink of any Claim number which has invalid Carrier from the" +
                    " Claim List page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 57
 testRunner.When("I am on the Claim Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 58
 testRunner.Then("the SCAC field will be left blank", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        public virtual void _107653_VerifyCustomerClaimRefFieldIsBindingForInternalUser(string userType, string userName, string password, string claimNumber, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "GUI",
                    "Functional",
                    "Sprint94",
                    "107653"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("107653-Verify Customer Claim Ref # Field Is Binding For Internal User", @__tags);
#line 62
this.ScenarioSetup(scenarioInfo);
#line 63
 testRunner.Given(string.Format("I am a sales, sales management, operations, station owner user {0},{1},{2}", userType, userName, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 64
 testRunner.And("I am on the Claims List page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 65
 testRunner.And(string.Format("I clicked on the link of any displayed claim {0},{1}", userType, claimNumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 66
 testRunner.When("I arrive on the Claim Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 67
 testRunner.Then("I will see the field Customer Claim Ref #", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 68
 testRunner.And("the field is not editable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 69
 testRunner.And(string.Format("the value of the Customer Claim Ref # field of the Submit A Claim page will be pu" +
                        "shed to the Customer Claim Ref # field of the Claim Details page {0}", claimNumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("107653-Verify Customer Claim Ref # Field Is Binding For Internal User: Sales")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "InsuranceClaims_ClaimDetailsHeader_Elements")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint82")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("22092")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint94")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("107653")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Sales")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:UserType", "Sales")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:UserName", "username-CurrentSprintSales")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "password-CurrentSprintSales")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ClaimNumber", "2019000637")]
        public virtual void _107653_VerifyCustomerClaimRefFieldIsBindingForInternalUser_Sales()
        {
#line 62
this._107653_VerifyCustomerClaimRefFieldIsBindingForInternalUser("Sales", "username-CurrentSprintSales", "password-CurrentSprintSales", "2019000637", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("107653-Verify Customer Claim Ref # Field Is Binding For Internal User: Internal")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "InsuranceClaims_ClaimDetailsHeader_Elements")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint82")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("22092")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint94")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("107653")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Internal")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:UserType", "Internal")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:UserName", "username-CurrentSprintOperations")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "password-CurrentSprintOperations")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ClaimNumber", "2019000637")]
        public virtual void _107653_VerifyCustomerClaimRefFieldIsBindingForInternalUser_Internal()
        {
#line 62
this._107653_VerifyCustomerClaimRefFieldIsBindingForInternalUser("Internal", "username-CurrentSprintOperations", "password-CurrentSprintOperations", "2019000637", ((string[])(null)));
#line hidden
        }
        
        public virtual void _107653_VerifyCustomerClaimRefFieldIsBindingForClaimSpecialistUser(string userType, string userName, string password, string claimNumber, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "GUI",
                    "Functional",
                    "Sprint94",
                    "107653"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("107653-Verify Customer Claim Ref # Field Is Binding For Claim Specialist User", @__tags);
#line 77
this.ScenarioSetup(scenarioInfo);
#line 78
 testRunner.Given(string.Format("I am a claim specialist user {0},{1},{2}", userType, userName, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 79
 testRunner.And("I am on the Claims List page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 80
 testRunner.And(string.Format("I clicked on the link of any displayed claim {0},{1}", userType, claimNumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 81
 testRunner.When("I arrive on the Claim Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 82
 testRunner.Then("I will see the optional field Customer Claim Ref #", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 83
 testRunner.And("the field is editable (alpha-numeric, text, special characters, max length 20)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 84
 testRunner.And(string.Format("the value of the Customer Claim Ref # field of the Submit A Claim page will be pu" +
                        "shed to the Customer Claim Ref # field of the Claim Details page {0}", claimNumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("107653-Verify Customer Claim Ref # Field Is Binding For Claim Specialist User: Cl" +
            "aimSpecialist")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "InsuranceClaims_ClaimDetailsHeader_Elements")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint82")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("22092")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint94")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("107653")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "ClaimSpecialist")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:UserType", "ClaimSpecialist")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:UserName", "username-CurrentsprintClaimspecialist")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "password-CurrentsprintClaimspecialist")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ClaimNumber", "2019000637")]
        public virtual void _107653_VerifyCustomerClaimRefFieldIsBindingForClaimSpecialistUser_ClaimSpecialist()
        {
#line 77
this._107653_VerifyCustomerClaimRefFieldIsBindingForClaimSpecialistUser("ClaimSpecialist", "username-CurrentsprintClaimspecialist", "password-CurrentsprintClaimspecialist", "2019000637", ((string[])(null)));
#line hidden
        }
        
        public virtual void _107653_VerifyCustomerClaimRefFieldIsGettingSavedForClaimSpecialistUser(string userType, string userName, string password, string claimNumber, string initialValueForCustomerClaimReferenceNumber, string editedValueForCustomerClaimReferenceNumber, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Functional",
                    "Sprint94",
                    "107653"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("107653-Verify Customer Claim Ref # Field is getting saved for Claim Specialist Us" +
                    "er", @__tags);
#line 90
this.ScenarioSetup(scenarioInfo);
#line 91
 testRunner.Given(string.Format("I am a claim specialist user {0},{1},{2}", userType, userName, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 92
 testRunner.And("I am on the Claims List page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 93
 testRunner.And(string.Format("I clicked on the link of any displayed claim {0},{1}", userType, claimNumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 94
 testRunner.When("I arrive on the Claim Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 95
 testRunner.And(string.Format("I edit Customer Claim Ref # {0},{1},{2}", claimNumber, initialValueForCustomerClaimReferenceNumber, editedValueForCustomerClaimReferenceNumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 96
 testRunner.When("I click on Save Claim Details", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 97
 testRunner.Then(string.Format("Customer Claim Ref # will be saved to Claim {0},{1}", claimNumber, editedValueForCustomerClaimReferenceNumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("107653-Verify Customer Claim Ref # Field is getting saved for Claim Specialist Us" +
            "er: ClaimSpecialist")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "InsuranceClaims_ClaimDetailsHeader_Elements")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint82")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("22092")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint94")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("107653")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "ClaimSpecialist")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:UserType", "ClaimSpecialist")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:UserName", "username-CurrentsprintClaimspecialist")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "password-CurrentsprintClaimspecialist")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ClaimNumber", "2019000637")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:InitialValueForCustomerClaimReferenceNumber", "InitialRefNo")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:EditedValueForCustomerClaimReferenceNumber", "EditedRefNo")]
        public virtual void _107653_VerifyCustomerClaimRefFieldIsGettingSavedForClaimSpecialistUser_ClaimSpecialist()
        {
#line 90
this._107653_VerifyCustomerClaimRefFieldIsGettingSavedForClaimSpecialistUser("ClaimSpecialist", "username-CurrentsprintClaimspecialist", "password-CurrentsprintClaimspecialist", "2019000637", "InitialRefNo", "EditedRefNo", ((string[])(null)));
#line hidden
        }
    }
}
#pragma warning restore
#endregion

