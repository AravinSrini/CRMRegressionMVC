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
    public partial class InsuranceClaims_ClaimDetails_ShipperFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "Insurance Claims - Claim Details - Shipper.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Insurance Claims - Claim Details - Shipper", null, ProgrammingLanguage.CSharp, new string[] {
                        "44610",
                        "Sprint83",
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "Insurance Claims - Claim Details - Shipper")))
            {
                global::CRM.UITest.Scripts.InsuranceClaims.ClaimDetails.InsuranceClaims_ClaimDetails_ShipperFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("44610_Verify the edits saved for the Shipper when user clicked on Save Claim Deta" +
            "ils")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Insurance Claims - Claim Details - Shipper")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("44610")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint83")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("DB")]
        public virtual void _44610_VerifyTheEditsSavedForTheShipperWhenUserClickedOnSaveClaimDetails()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("44610_Verify the edits saved for the Shipper when user clicked on Save Claim Deta" +
                    "ils", new string[] {
                        "GUI",
                        "DB"});
#line 5
this.ScenarioSetup(scenarioInfo);
#line 6
 testRunner.Given("I am a Claims Specialist user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 7
 testRunner.And("I am on Claim Detailspage", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 8
 testRunner.And("I have updated Name, Address, City, State, Zip, Country in the Shipper Section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 9
 testRunner.And("I have updated Date Ack to Claimant, Date Filed in the DLSW OS&D Actions Section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
 testRunner.And("I have updated Program,Amount,Company in the Insurance Info Section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
 testRunner.When("I click on Save Claim Details button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 12
 testRunner.Then("updated values should be saved in DB", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        public virtual void _44610_VerifyTheEditsSavedForTheAnyFieldFromShipperWhenUserClickedOnSaveClaimDetails(string shippersectionfield, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "GUI",
                    "DB"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("44610_Verify the edits saved for the any field from Shipper when user clicked on " +
                    "Save Claim Details", @__tags);
#line 15
this.ScenarioSetup(scenarioInfo);
#line 16
 testRunner.Given("I am a Claims Specialist user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 17
 testRunner.And("I am on Claim Detailspage", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
 testRunner.And(string.Format("I have updated any {0} in the Shipper Section", shippersectionfield), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
 testRunner.When("I click on Save Claim Details button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 20
 testRunner.Then(string.Format("updated {0} values should be saved in DB", shippersectionfield), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("44610_Verify the edits saved for the any field from Shipper when user clicked on " +
            "Save Claim Details: Name")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Insurance Claims - Claim Details - Shipper")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("44610")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint83")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("DB")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Name")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:shippersectionfield", "Name")]
        public virtual void _44610_VerifyTheEditsSavedForTheAnyFieldFromShipperWhenUserClickedOnSaveClaimDetails_Name()
        {
#line 15
this._44610_VerifyTheEditsSavedForTheAnyFieldFromShipperWhenUserClickedOnSaveClaimDetails("Name", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("44610_Verify the edits saved for the any field from Shipper when user clicked on " +
            "Save Claim Details: Address")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Insurance Claims - Claim Details - Shipper")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("44610")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint83")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("DB")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Address")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:shippersectionfield", "Address")]
        public virtual void _44610_VerifyTheEditsSavedForTheAnyFieldFromShipperWhenUserClickedOnSaveClaimDetails_Address()
        {
#line 15
this._44610_VerifyTheEditsSavedForTheAnyFieldFromShipperWhenUserClickedOnSaveClaimDetails("Address", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("44610_Verify the edits saved for the any field from Shipper when user clicked on " +
            "Save Claim Details: City")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Insurance Claims - Claim Details - Shipper")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("44610")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint83")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("DB")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "City")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:shippersectionfield", "City")]
        public virtual void _44610_VerifyTheEditsSavedForTheAnyFieldFromShipperWhenUserClickedOnSaveClaimDetails_City()
        {
#line 15
this._44610_VerifyTheEditsSavedForTheAnyFieldFromShipperWhenUserClickedOnSaveClaimDetails("City", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("44610_Verify the edits saved for the any field from Shipper when user clicked on " +
            "Save Claim Details: State")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Insurance Claims - Claim Details - Shipper")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("44610")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint83")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("DB")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "State")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:shippersectionfield", "State")]
        public virtual void _44610_VerifyTheEditsSavedForTheAnyFieldFromShipperWhenUserClickedOnSaveClaimDetails_State()
        {
#line 15
this._44610_VerifyTheEditsSavedForTheAnyFieldFromShipperWhenUserClickedOnSaveClaimDetails("State", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("44610_Verify the edits saved for the any field from Shipper when user clicked on " +
            "Save Claim Details: Zip")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Insurance Claims - Claim Details - Shipper")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("44610")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint83")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("DB")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Zip")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:shippersectionfield", "Zip")]
        public virtual void _44610_VerifyTheEditsSavedForTheAnyFieldFromShipperWhenUserClickedOnSaveClaimDetails_Zip()
        {
#line 15
this._44610_VerifyTheEditsSavedForTheAnyFieldFromShipperWhenUserClickedOnSaveClaimDetails("Zip", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("44610_Verify the edits saved for the any field from Shipper when user clicked on " +
            "Save Claim Details: Country")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Insurance Claims - Claim Details - Shipper")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("44610")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint83")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("DB")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Country")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:shippersectionfield", "Country")]
        public virtual void _44610_VerifyTheEditsSavedForTheAnyFieldFromShipperWhenUserClickedOnSaveClaimDetails_Country()
        {
#line 15
this._44610_VerifyTheEditsSavedForTheAnyFieldFromShipperWhenUserClickedOnSaveClaimDetails("Country", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("44610_Verify the edits saved for the any field from Shipper when user clicked on " +
            "Save Claim Details: DateAck")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Insurance Claims - Claim Details - Shipper")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("44610")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint83")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("DB")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "DateAck")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:shippersectionfield", "DateAck")]
        public virtual void _44610_VerifyTheEditsSavedForTheAnyFieldFromShipperWhenUserClickedOnSaveClaimDetails_DateAck()
        {
#line 15
this._44610_VerifyTheEditsSavedForTheAnyFieldFromShipperWhenUserClickedOnSaveClaimDetails("DateAck", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("44610_Verify the edits saved for the any field from Shipper when user clicked on " +
            "Save Claim Details: Date Filed")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Insurance Claims - Claim Details - Shipper")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("44610")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint83")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("DB")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Date Filed")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:shippersectionfield", "Date Filed")]
        public virtual void _44610_VerifyTheEditsSavedForTheAnyFieldFromShipperWhenUserClickedOnSaveClaimDetails_DateFiled()
        {
#line 15
this._44610_VerifyTheEditsSavedForTheAnyFieldFromShipperWhenUserClickedOnSaveClaimDetails("Date Filed", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("44610_Verify the edits saved for the any field from Shipper when user clicked on " +
            "Save Claim Details: Amount")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Insurance Claims - Claim Details - Shipper")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("44610")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint83")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("DB")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Amount")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:shippersectionfield", "Amount")]
        public virtual void _44610_VerifyTheEditsSavedForTheAnyFieldFromShipperWhenUserClickedOnSaveClaimDetails_Amount()
        {
#line 15
this._44610_VerifyTheEditsSavedForTheAnyFieldFromShipperWhenUserClickedOnSaveClaimDetails("Amount", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("91189_Verify the Date Ack To Claimant saved in DB for the claim")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Insurance Claims - Claim Details - Shipper")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("44610")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint83")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("91189")]
        public virtual void _91189_VerifyTheDateAckToClaimantSavedInDBForTheClaim()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("91189_Verify the Date Ack To Claimant saved in DB for the claim", new string[] {
                        "91189"});
#line 36
this.ScenarioSetup(scenarioInfo);
#line 37
 testRunner.Given("I am a claim specialist user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 38
 testRunner.And("I am on the Details Tab of Claim Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 39
 testRunner.And("I selected a date in the Date Ack To Claimant field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 40
 testRunner.When("I click on the Save Claim Details button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 41
 testRunner.Then("the date will be saved to the claim", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("108612_Verify the state/prov field value in claim details screen")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Insurance Claims - Claim Details - Shipper")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("44610")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint83")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("108612")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint92")]
        public virtual void _108612_VerifyTheStateProvFieldValueInClaimDetailsScreen()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("108612_Verify the state/prov field value in claim details screen", new string[] {
                        "108612",
                        "Sprint92"});
#line 35
this.ScenarioSetup(scenarioInfo);
#line 36
testRunner.Given("I am a sales, sales management, operations, station owner, or claim specialist us" +
                    "er", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 37
testRunner.When("I am on the Claim Details page of existing claim submitted2019000158", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 38
testRunner.Then("I verify the State/Prov field in Shipper Information section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 39
testRunner.And("I verify state field value in DB data for claim number2019000158", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
