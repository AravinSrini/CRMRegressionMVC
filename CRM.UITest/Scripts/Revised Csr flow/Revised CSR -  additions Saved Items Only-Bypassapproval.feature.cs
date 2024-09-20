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
namespace CRM.UITest.Scripts.RevisedCsrFlow
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class RevisedCSR_AdditionsSavedItemsOnly_BypassapprovalFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "Revised CSR -  additions Saved Items Only-Bypassapproval.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Revised CSR -  additions Saved Items Only-Bypassapproval", null, ProgrammingLanguage.CSharp, new string[] {
                        "36313",
                        "Sprint75",
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "Revised CSR -  additions Saved Items Only-Bypassapproval")))
            {
                global::CRM.UITest.Scripts.RevisedCsrFlow.RevisedCSR_AdditionsSavedItemsOnly_BypassapprovalFeature.FeatureSetup(null);
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
        
        public virtual void _36313_BypassApprovalForRevisedCSRFlowByAddingSavedItemsTemplateAndModalforSystemadmin(string customer, string classification, string nMFC, string itemDescription, string hazardousMaterials, string itemPath, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Functional",
                    "Regression"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("36313-Bypass approval for revised CSR flow by adding saved items template and mod" +
                    "alfor systemadmin", @__tags);
#line 5
this.ScenarioSetup(scenarioInfo);
#line 6
 testRunner.Given("I LogIn to the application as SystemAdmin", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 7
 testRunner.And("I am on the customer profile page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 8
 testRunner.And(string.Format("I have Clicked on any customer {0} from the customer profile page", customer), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 9
 testRunner.And("I have navigated to saved items and addresses page of revised CSR flow", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
 testRunner.And(string.Format("I Click on Create a Saved Item button and Enter Item Details{0},{1},{2},{3}", classification, nMFC, itemDescription, hazardousMaterials), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
 testRunner.And("I Click on Save and Continue button will be Navigated to Portal Users Page<Portal" +
                    "Users_Text>", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
 testRunner.And("I Click on Save and Continue button will be Navigated to Review and Submit Page<R" +
                    "eviewAndSubmitText>", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
 testRunner.When("I click on the Submit button on review and submit page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 15
 testRunner.Then(string.Format("Revised CSR should be completed {0}", customer), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("36313-Bypass approval for revised CSR flow by adding saved items template and mod" +
            "alfor systemadmin: testingbypass232")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Revised CSR -  additions Saved Items Only-Bypassapproval")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("36313")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint75")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "testingbypass232")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:customer", "testingbypass232")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Classification", "50")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:NMFC", "1823")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ItemDescription", "Test75")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:HazardousMaterials", "No")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ItemPath", "..\\..\\Scripts\\TestData\\SubmitCSR\\ItemTemplate\\Template_Item.xlsx")]
        public virtual void _36313_BypassApprovalForRevisedCSRFlowByAddingSavedItemsTemplateAndModalforSystemadmin_Testingbypass232()
        {
#line 5
this._36313_BypassApprovalForRevisedCSRFlowByAddingSavedItemsTemplateAndModalforSystemadmin("testingbypass232", "50", "1823", "Test75", "No", "..\\..\\Scripts\\TestData\\SubmitCSR\\ItemTemplate\\Template_Item.xlsx", ((string[])(null)));
#line hidden
        }
        
        public virtual void _36313_BypassApprovalForRevisedCSRFlowByAddingSavedItemsAndAddressesBothTemplateAndModalForSysadmin(string customer, string classification, string nMFC, string itemDescription, string hazardousMaterials, string itemPath, string name, string address1, string city, string country, string state, string zip, string addressPath, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Functional",
                    "Regression"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("36313-Bypass approval for revised CSR flow by adding saved items and addresses bo" +
                    "th template and modal for sysadmin", @__tags);
#line 22
this.ScenarioSetup(scenarioInfo);
#line 23
 testRunner.Given("I LogIn to the application as SystemAdmin", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 24
 testRunner.And("I am on the customer profile page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
 testRunner.And(string.Format("I have Clicked on any customer {0} from the customer profile page", customer), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
 testRunner.And("I have navigated to saved items and addresses page of revised CSR flow", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
 testRunner.And(string.Format("I Click on Create a Saved Item button and Enter Item Details{0},{1},{2},{3}", classification, nMFC, itemDescription, hazardousMaterials), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
 testRunner.And(string.Format("I Click Create a Saved Address button and Enter Address Details{0},{1},<Address2>" +
                        ",{2},{3},{4},{5}", name, address1, city, country, state, zip), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 31
 testRunner.And("I Click on Save and Continue button will be Navigated to Portal Users Page<Portal" +
                    "Users_Text>", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
 testRunner.And("I Click on Save and Continue button will be Navigated to Review and Submit Page<R" +
                    "eviewAndSubmitText>", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
 testRunner.When("I click on the Submit button on review and submit page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 34
 testRunner.Then(string.Format("Revised CSR should be completed {0}", customer), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("36313-Bypass approval for revised CSR flow by adding saved items and addresses bo" +
            "th template and modal for sysadmin: testingbypass232")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Revised CSR -  additions Saved Items Only-Bypassapproval")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("36313")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint75")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "testingbypass232")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:customer", "testingbypass232")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Classification", "50")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:NMFC", "1823")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ItemDescription", "Test75")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:HazardousMaterials", "No")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ItemPath", "..\\..\\Scripts\\TestData\\SubmitCSR\\ItemTemplate\\Template_Item.xlsx")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Name", "Sprint75")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Address1", "Sprint75")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:City", "Sprint75")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Country", "United States")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:State", "CA")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Zip", "90001")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:AddressPath", "..\\..\\Scripts\\TestData\\SubmitCSR\\AddressTemplate\\Template_Address.xlsx")]
        public virtual void _36313_BypassApprovalForRevisedCSRFlowByAddingSavedItemsAndAddressesBothTemplateAndModalForSysadmin_Testingbypass232()
        {
#line 22
this._36313_BypassApprovalForRevisedCSRFlowByAddingSavedItemsAndAddressesBothTemplateAndModalForSysadmin("testingbypass232", "50", "1823", "Test75", "No", "..\\..\\Scripts\\TestData\\SubmitCSR\\ItemTemplate\\Template_Item.xlsx", "Sprint75", "Sprint75", "Sprint75", "United States", "CA", "90001", "..\\..\\Scripts\\TestData\\SubmitCSR\\AddressTemplate\\Template_Address.xlsx", ((string[])(null)));
#line hidden
        }
    }
}
#pragma warning restore
#endregion
