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
    public partial class RevisedCSR_AdditionsSavedAddressesOnly_BypassapprovalFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "Revised CSR -  additions Saved Addresses Only-Bypassapproval.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Revised CSR -  additions Saved Addresses Only-Bypassapproval", null, ProgrammingLanguage.CSharp, new string[] {
                        "37019",
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "Revised CSR -  additions Saved Addresses Only-Bypassapproval")))
            {
                global::CRM.UITest.Scripts.RevisedCsrFlow.RevisedCSR_AdditionsSavedAddressesOnly_BypassapprovalFeature.FeatureSetup(null);
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
        
        public virtual void BypassApprovalForRevisedCSRFlowByAddingSavedAddressesTemplateAndModalForSystemAdmin(string customer, string name, string address1, string address2, string city, string country, string state, string zip, string addressPath, string portalUsers_Text, string reviewAndSubmitText, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Functional",
                    "Regression"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Bypass approval for revised CSR flow by adding saved addresses template and modal" +
                    " for systemAdmin", @__tags);
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
 testRunner.And(string.Format("I Click Create a Saved Address button and Enter Address Details{0},{1},{2},{3},{4" +
                        "},{5},{6}", name, address1, address2, city, country, state, zip), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
 testRunner.And(string.Format("I Click on Save and Continue button will be Navigated to Portal Users Page{0}", portalUsers_Text), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
 testRunner.And(string.Format("I Click on Save and Continue button will be Navigated to Review and Submit Page{0" +
                        "}", reviewAndSubmitText), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
 testRunner.And("I should be displayed with added Addresses and uploaded address template in Revie" +
                    "w and Submit Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
 testRunner.When("I click on the Submit button on review and submit page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 16
    testRunner.Then(string.Format("CSR should be completed {0}", customer), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Bypass approval for revised CSR flow by adding saved addresses template and modal" +
            " for systemAdmin: BypassforaddressmodalAut")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Revised CSR -  additions Saved Addresses Only-Bypassapproval")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("37019")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint75")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "BypassforaddressmodalAut")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:customer", "BypassforaddressmodalAut")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Name", "CSR")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Address1", "TestAd1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Address2", "TestAd2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:City", "Miami")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Country", "United States")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:State", "FL")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Zip", "33126")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:AddressPath", "..\\..\\Scripts\\TestData\\SubmitCSR\\AddressTemplate\\Template_Address.xlsx")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:PortalUsers_Text", "Portal Users")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ReviewAndSubmitText", "Review and Submit")]
        public virtual void BypassApprovalForRevisedCSRFlowByAddingSavedAddressesTemplateAndModalForSystemAdmin_BypassforaddressmodalAut()
        {
#line 5
this.BypassApprovalForRevisedCSRFlowByAddingSavedAddressesTemplateAndModalForSystemAdmin("BypassforaddressmodalAut", "CSR", "TestAd1", "TestAd2", "Miami", "United States", "FL", "33126", "..\\..\\Scripts\\TestData\\SubmitCSR\\AddressTemplate\\Template_Address.xlsx", "Portal Users", "Review and Submit", ((string[])(null)));
#line hidden
        }
    }
}
#pragma warning restore
#endregion
