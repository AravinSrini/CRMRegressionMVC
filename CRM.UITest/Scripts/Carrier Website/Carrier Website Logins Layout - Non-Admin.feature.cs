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
namespace CRM.UITest.Scripts.CarrierWebsite
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.2.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class CarrierWebsiteLoginsLayout_Non_AdminFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "Carrier Website Logins Layout - Non-Admin.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Carrier Website Logins Layout - Non-Admin", null, ProgrammingLanguage.CSharp, new string[] {
                        "CarrierWebsiteLoginLayout_Non_Admin",
                        "30605",
                        "Sprint72"});
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "Carrier Website Logins Layout - Non-Admin")))
            {
                global::CRM.UITest.Scripts.CarrierWebsite.CarrierWebsiteLoginsLayout_Non_AdminFeature.FeatureSetup(null);
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
        
        public virtual void VerifyTheCarrierWebsiteLoginPageLayoutForNonAdminUser(string scenario, string username, string password, string options, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "GUI"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify the Carrier Website Login page Layout for Non Admin user", @__tags);
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
 testRunner.Given(string.Format("I am a Operations, Station Owner or System Configuration user - {0}, {1}", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
 testRunner.When("I am on the Carrier Website Logins page for the non admin user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
 testRunner.Then("I see the RRD DLS Worldwide logo", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 11
 testRunner.And(string.Format("I see the my credentials on the Carrier Website Login page {0}", username), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
 testRunner.And("I should see the column names as SCAC, Carrier Name, Account Number, Website , Lo" +
                    "gin, Password and Notes Column", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
 testRunner.And("I should see all columns SCAC, Carrier Name, Account Number, Website with option " +
                    "Copy to Clipboard icon, Login with Copy to Clipboard icon, Password with Copy to" +
                    " Clipboard icon and Notes Column", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
 testRunner.And("I should see the Search Text Box", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
 testRunner.And(string.Format("I should be able to view {0} under dropdown in top grid of Carrier Website Login " +
                        "page", options), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify the Carrier Website Login page Layout for Non Admin user: S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Carrier Website Logins Layout - Non-Admin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("CarrierWebsiteLoginLayout_Non_Admin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("30605")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint72")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Scenario", "S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "stationown")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Options", "10,20,60,100,ALL")]
        public virtual void VerifyTheCarrierWebsiteLoginPageLayoutForNonAdminUser_S1()
        {
#line 7
this.VerifyTheCarrierWebsiteLoginPageLayoutForNonAdminUser("S1", "stationown", "Te$t1234", "10,20,60,100,ALL", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify the Carrier Website Login page Layout for Non Admin user: S2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Carrier Website Logins Layout - Non-Admin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("CarrierWebsiteLoginLayout_Non_Admin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("30605")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint72")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "S2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Scenario", "S2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "admin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Options", "10,20,60,100,ALL")]
        public virtual void VerifyTheCarrierWebsiteLoginPageLayoutForNonAdminUser_S2()
        {
#line 7
this.VerifyTheCarrierWebsiteLoginPageLayoutForNonAdminUser("S2", "admin", "Te$t1234", "10,20,60,100,ALL", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify the Carrier Website Login page Layout for Non Admin user: S3")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Carrier Website Logins Layout - Non-Admin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("CarrierWebsiteLoginLayout_Non_Admin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("30605")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint72")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "S3")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Scenario", "S3")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "crmOperation")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Options", "10,20,60,100,ALL")]
        public virtual void VerifyTheCarrierWebsiteLoginPageLayoutForNonAdminUser_S3()
        {
#line 7
this.VerifyTheCarrierWebsiteLoginPageLayoutForNonAdminUser("S3", "crmOperation", "Te$t1234", "10,20,60,100,ALL", ((string[])(null)));
#line hidden
        }
        
        public virtual void VerifyTheCarrierWebsiteLoginPageDataWithDBForNonAdminUser(string scenario, string username, string password, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "GUI"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify the Carrier Website Login page data with DB for Non Admin user", @__tags);
#line 25
this.ScenarioSetup(scenarioInfo);
#line 26
 testRunner.Given(string.Format("I am a Operations, Station Owner or System Configuration user - {0}, {1}", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 27
 testRunner.When("I am on the Carrier Website Logins page for the non admin user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 28
 testRunner.Then("the data displayed in the grid should match with the DB", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify the Carrier Website Login page data with DB for Non Admin user: S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Carrier Website Logins Layout - Non-Admin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("CarrierWebsiteLoginLayout_Non_Admin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("30605")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint72")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Scenario", "S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "stationown")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        public virtual void VerifyTheCarrierWebsiteLoginPageDataWithDBForNonAdminUser_S1()
        {
#line 25
this.VerifyTheCarrierWebsiteLoginPageDataWithDBForNonAdminUser("S1", "stationown", "Te$t1234", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify the Carrier Website Login page data with DB for Non Admin user: S2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Carrier Website Logins Layout - Non-Admin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("CarrierWebsiteLoginLayout_Non_Admin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("30605")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint72")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "S2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Scenario", "S2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "admin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        public virtual void VerifyTheCarrierWebsiteLoginPageDataWithDBForNonAdminUser_S2()
        {
#line 25
this.VerifyTheCarrierWebsiteLoginPageDataWithDBForNonAdminUser("S2", "admin", "Te$t1234", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify the Carrier Website Login page data with DB for Non Admin user: S3")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Carrier Website Logins Layout - Non-Admin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("CarrierWebsiteLoginLayout_Non_Admin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("30605")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint72")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "S3")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Scenario", "S3")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "crmOperation")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        public virtual void VerifyTheCarrierWebsiteLoginPageDataWithDBForNonAdminUser_S3()
        {
#line 25
this.VerifyTheCarrierWebsiteLoginPageDataWithDBForNonAdminUser("S3", "crmOperation", "Te$t1234", ((string[])(null)));
#line hidden
        }
    }
}
#pragma warning restore
#endregion
