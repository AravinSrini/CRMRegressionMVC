﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.1.0.0
//      SpecFlow Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace CRM.UITest.Scripts.Shipment.ShipmentList.ShipmentList_ShipmentListNavigation_AllUsers
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class ShipmentList_ShipmentListNavigation_AllUsersFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "ShipmentList_ShipmentListNavigation_AllUsers.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner(null, 0);
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "ShipmentList_ShipmentListNavigation_AllUsers", null, ProgrammingLanguage.CSharp, new string[] {
                        "28364",
                        "Sprint68"});
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "ShipmentList_ShipmentListNavigation_AllUsers")))
            {
                CRM.UITest.Scripts.Shipment.ShipmentList.ShipmentList_ShipmentListNavigation_AllUsers.ShipmentList_ShipmentListNavigation_AllUsersFeature.FeatureSetup(null);
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
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void VerifyTheShipmentListNavigationFunctionalityForAllNonAdminUsers(string scenario, string username, string password, string dashboardTitle, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "GUI",
                    "Functional"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify the Shipment List navigation functionality for all non admin users", @__tags);
#line 5
this.ScenarioSetup(scenarioInfo);
#line 6
testRunner.Given(string.Format("I am a DLS user and login into application with valid {0} and {1}", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 7
testRunner.When(string.Format("I am navigated to the dashboard page {0}", dashboardTitle), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 8
testRunner.Then("I should be displayed with Shipments Icon in leftwizard", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 9
testRunner.And("I click on the Shipment icon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
testRunner.And("I should be navigated to Shipment List page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify the Shipment List navigation functionality for all non admin users: S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ShipmentList_ShipmentListNavigation_AllUsers")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("28364")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint68")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Scenario", "S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "crmOperation")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DashboardTitle", "Dashboard")]
        public virtual void VerifyTheShipmentListNavigationFunctionalityForAllNonAdminUsers_S1()
        {
            this.VerifyTheShipmentListNavigationFunctionalityForAllNonAdminUsers("S1", "crmOperation", "Te$t1234", "Dashboard", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify the Shipment List navigation functionality for all non admin users: S2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ShipmentList_ShipmentListNavigation_AllUsers")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("28364")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint68")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "S2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Scenario", "S2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "saleTest")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DashboardTitle", "Dashboard")]
        public virtual void VerifyTheShipmentListNavigationFunctionalityForAllNonAdminUsers_S2()
        {
            this.VerifyTheShipmentListNavigationFunctionalityForAllNonAdminUsers("S2", "saleTest", "Te$t1234", "Dashboard", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify the Shipment List navigation functionality for all non admin users: S3")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ShipmentList_ShipmentListNavigation_AllUsers")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("28364")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint68")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "S3")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Scenario", "S3")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "stationowner")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DashboardTitle", "Dashboard")]
        public virtual void VerifyTheShipmentListNavigationFunctionalityForAllNonAdminUsers_S3()
        {
            this.VerifyTheShipmentListNavigationFunctionalityForAllNonAdminUsers("S3", "stationowner", "Te$t1234", "Dashboard", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify the Shipment List navigation functionality for all non admin users: S4")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ShipmentList_ShipmentListNavigation_AllUsers")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("28364")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint68")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "S4")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Scenario", "S4")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "crmsalesusr")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DashboardTitle", "Dashboard")]
        public virtual void VerifyTheShipmentListNavigationFunctionalityForAllNonAdminUsers_S4()
        {
            this.VerifyTheShipmentListNavigationFunctionalityForAllNonAdminUsers("S4", "crmsalesusr", "Te$t1234", "Dashboard", ((string[])(null)));
#line hidden
        }
        
        public virtual void VerifyTheShipmentListNavigationFunctionalityForAllExternalUsersWithClaim(string scenario, string username, string password, string dashboardTitle, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "GUI",
                    "Functional"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify the Shipment List navigation functionality for all external users with cla" +
                    "im", @__tags);
#line 20
this.ScenarioSetup(scenarioInfo);
#line 21
testRunner.Given(string.Format("I am a DLS user and login into application with valid {0} and {1}", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 22
testRunner.When(string.Format("I am navigated to the dashboard page {0}", dashboardTitle), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 23
testRunner.Then("I should be displayed with Shipments Icon in leftwizard", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 24
testRunner.And("I click on the Shipment icon for external users", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
testRunner.And("I will be navigated to new shipment list screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify the Shipment List navigation functionality for all external users with cla" +
            "im: S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ShipmentList_ShipmentListNavigation_AllUsers")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("28364")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint68")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Scenario", "S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "shpentry")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DashboardTitle", "Dashboard")]
        public virtual void VerifyTheShipmentListNavigationFunctionalityForAllExternalUsersWithClaim_S1()
        {
            this.VerifyTheShipmentListNavigationFunctionalityForAllExternalUsersWithClaim("S1", "shpentry", "Te$t1234", "Dashboard", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify the Shipment List navigation functionality for all external users with cla" +
            "im: s2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ShipmentList_ShipmentListNavigation_AllUsers")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("28364")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint68")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "s2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Scenario", "s2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "ShpInquiry")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DashboardTitle", "Dashboard")]
        public virtual void VerifyTheShipmentListNavigationFunctionalityForAllExternalUsersWithClaim_S2()
        {
            this.VerifyTheShipmentListNavigationFunctionalityForAllExternalUsersWithClaim("s2", "ShpInquiry", "Te$t1234", "Dashboard", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify the Shipment List navigation functionality for all external users with cla" +
            "im: s3")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ShipmentList_ShipmentListNavigation_AllUsers")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("28364")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint68")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "s3")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Scenario", "s3")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "Entyrnorates")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DashboardTitle", "Dashboard")]
        public virtual void VerifyTheShipmentListNavigationFunctionalityForAllExternalUsersWithClaim_S3()
        {
            this.VerifyTheShipmentListNavigationFunctionalityForAllExternalUsersWithClaim("s3", "Entyrnorates", "Te$t1234", "Dashboard", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify the Shipment List navigation functionality for all external users with cla" +
            "im: s4")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ShipmentList_ShipmentListNavigation_AllUsers")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("28364")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint68")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "s4")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Scenario", "s4")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "Inquirynorates")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DashboardTitle", "Dashboard")]
        public virtual void VerifyTheShipmentListNavigationFunctionalityForAllExternalUsersWithClaim_S4()
        {
            this.VerifyTheShipmentListNavigationFunctionalityForAllExternalUsersWithClaim("s4", "Inquirynorates", "Te$t1234", "Dashboard", ((string[])(null)));
#line hidden
        }
        
        public virtual void VerifyTheShipmentListNavigationFunctionalityForAllExternalUsersWithoutClaim(string scenario, string username, string password, string dashboardTitle, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "GUI",
                    "Functional"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify the Shipment List navigation functionality for all external users without " +
                    "claim", @__tags);
#line 35
this.ScenarioSetup(scenarioInfo);
#line 36
testRunner.Given(string.Format("I am a DLS user and login into application with valid {0} and {1}", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 37
testRunner.When(string.Format("I am navigated to the dashboard page {0}", dashboardTitle), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 38
testRunner.Then("I should be displayed with Shipments Icon in leftwizard", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 39
testRunner.And("I click on the Shipment icon for external users", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 40
testRunner.And("I will be navigated to legacy shipment list screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify the Shipment List navigation functionality for all external users without " +
            "claim: s1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ShipmentList_ShipmentListNavigation_AllUsers")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("28364")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint68")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "s1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Scenario", "s1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "shipment.entryuser")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DashboardTitle", "Dashboard")]
        public virtual void VerifyTheShipmentListNavigationFunctionalityForAllExternalUsersWithoutClaim_S1()
        {
            this.VerifyTheShipmentListNavigationFunctionalityForAllExternalUsersWithoutClaim("s1", "shipment.entryuser", "Te$t1234", "Dashboard", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify the Shipment List navigation functionality for all external users without " +
            "claim: s2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ShipmentList_ShipmentListNavigation_AllUsers")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("28364")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint68")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "s2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Scenario", "s2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "shipment.inquiryuser")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DashboardTitle", "Dashboard")]
        public virtual void VerifyTheShipmentListNavigationFunctionalityForAllExternalUsersWithoutClaim_S2()
        {
            this.VerifyTheShipmentListNavigationFunctionalityForAllExternalUsersWithoutClaim("s2", "shipment.inquiryuser", "Te$t1234", "Dashboard", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify the Shipment List navigation functionality for all external users without " +
            "claim: s3")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ShipmentList_ShipmentListNavigation_AllUsers")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("28364")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint68")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "s3")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Scenario", "s3")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "shipment.entryNouser")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DashboardTitle", "Dashboard")]
        public virtual void VerifyTheShipmentListNavigationFunctionalityForAllExternalUsersWithoutClaim_S3()
        {
            this.VerifyTheShipmentListNavigationFunctionalityForAllExternalUsersWithoutClaim("s3", "shipment.entryNouser", "Te$t1234", "Dashboard", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify the Shipment List navigation functionality for all external users without " +
            "claim: s4")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ShipmentList_ShipmentListNavigation_AllUsers")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("28364")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint68")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "s4")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Scenario", "s4")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "shipment.inqNouser")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DashboardTitle", "Dashboard")]
        public virtual void VerifyTheShipmentListNavigationFunctionalityForAllExternalUsersWithoutClaim_S4()
        {
            this.VerifyTheShipmentListNavigationFunctionalityForAllExternalUsersWithoutClaim("s4", "shipment.inqNouser", "Te$t1234", "Dashboard", ((string[])(null)));
#line hidden
        }
    }
}
#pragma warning restore
#endregion
