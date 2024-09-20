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
namespace CRM.UITest.Scripts.IntegrationListPage
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class IntegrationListPage_AcceptOrDenyFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "IntegrationListPage_AcceptOrDeny.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "IntegrationListPage_AcceptOrDeny", null, ProgrammingLanguage.CSharp, new string[] {
                        "Sprint75",
                        "34284"});
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "IntegrationListPage_AcceptOrDeny")))
            {
                global::CRM.UITest.Scripts.IntegrationListPage.IntegrationListPage_AcceptOrDenyFeature.FeatureSetup(null);
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
        
        public virtual void IntergrationApprove1_VerifyTheApproveButtonAvailableAfterExpandingTheDetailsOfAnIntegrationRequestListPage(string scenario, string username, string password, string dashboardTitle, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "mytag"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("IntergrationApprove1->Verify the Approve button available after expanding the det" +
                    "ails of an Integration request list page", @__tags);
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
 testRunner.Given(string.Format("I am a Sales Management or a System Admin user logged in with {0} and {1}", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
    testRunner.When("I arrive on the Dashboard page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 9
    testRunner.And("I click on Integration Menu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
 testRunner.And("I select the status as Pending approval radio button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
 testRunner.And("I expand the station details section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
 testRunner.Then("I should see the approve button available", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("IntergrationApprove1->Verify the Approve button available after expanding the det" +
            "ails of an Integration request list page: s1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "IntegrationListPage_AcceptOrDeny")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint75")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("34284")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("mytag")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "s1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Scenario", "s1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "Systemadmin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DashboardTitle", "Dashboard")]
        public virtual void IntergrationApprove1_VerifyTheApproveButtonAvailableAfterExpandingTheDetailsOfAnIntegrationRequestListPage_S1()
        {
#line 6
this.IntergrationApprove1_VerifyTheApproveButtonAvailableAfterExpandingTheDetailsOfAnIntegrationRequestListPage("s1", "Systemadmin", "Te$t1234", "Dashboard", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("IntergrationApprove1->Verify the Approve button available after expanding the det" +
            "ails of an Integration request list page: s2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "IntegrationListPage_AcceptOrDeny")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint75")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("34284")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("mytag")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "s2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Scenario", "s2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "SalesManager@stage.com")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DashboardTitle", "Dashboard")]
        public virtual void IntergrationApprove1_VerifyTheApproveButtonAvailableAfterExpandingTheDetailsOfAnIntegrationRequestListPage_S2()
        {
#line 6
this.IntergrationApprove1_VerifyTheApproveButtonAvailableAfterExpandingTheDetailsOfAnIntegrationRequestListPage("s2", "SalesManager@stage.com", "Te$t1234", "Dashboard", ((string[])(null)));
#line hidden
        }
        
        public virtual void IntegrationDeny2_VerifyTheDenyButtonAvailableAfterExpandingTheDetailsOfAnIntegrationRequestListPage(string scenario, string username, string password, string dashboardTitle, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("IntegrationDeny2->Verify the Deny button available after expanding the details of" +
                    " an Integration request list page", exampleTags);
#line 18
this.ScenarioSetup(scenarioInfo);
#line 19
 testRunner.Given(string.Format("I am a Sales Management or a System Admin user logged in with {0} and {1}", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 20
    testRunner.When("I arrive on the Dashboard page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 21
    testRunner.And("I click on Integration Menu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
 testRunner.And("I select the status as Pending approval radio button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
 testRunner.And("I expand the station details section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
 testRunner.Then("I should see the deny button available", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("IntegrationDeny2->Verify the Deny button available after expanding the details of" +
            " an Integration request list page: s1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "IntegrationListPage_AcceptOrDeny")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint75")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("34284")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "s1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Scenario", "s1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "Systemadmin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DashboardTitle", "Dashboard")]
        public virtual void IntegrationDeny2_VerifyTheDenyButtonAvailableAfterExpandingTheDetailsOfAnIntegrationRequestListPage_S1()
        {
#line 18
this.IntegrationDeny2_VerifyTheDenyButtonAvailableAfterExpandingTheDetailsOfAnIntegrationRequestListPage("s1", "Systemadmin", "Te$t1234", "Dashboard", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("IntegrationDeny2->Verify the Deny button available after expanding the details of" +
            " an Integration request list page: s2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "IntegrationListPage_AcceptOrDeny")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint75")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("34284")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "s2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Scenario", "s2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "SalesManager@stage.com")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DashboardTitle", "Dashboard")]
        public virtual void IntegrationDeny2_VerifyTheDenyButtonAvailableAfterExpandingTheDetailsOfAnIntegrationRequestListPage_S2()
        {
#line 18
this.IntegrationDeny2_VerifyTheDenyButtonAvailableAfterExpandingTheDetailsOfAnIntegrationRequestListPage("s2", "SalesManager@stage.com", "Te$t1234", "Dashboard", ((string[])(null)));
#line hidden
        }
        
        public virtual void IntergrationApprove3_VerifyTheApproveButtonFunctionalityForAdminAndSalesManagementUsersInDetailsOfAnIntegrationRequestSection(string scenario, string username, string password, string dashboardTitle, string waitingStatus, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("IntergrationApprove3-> Verify the Approve button functionality for admin and sale" +
                    "s management users in details of an integration request Section", exampleTags);
#line 33
this.ScenarioSetup(scenarioInfo);
#line 34
    testRunner.Given(string.Format("I am a Sales Management or a System Admin user logged in with {0} and {1}", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 35
    testRunner.When("I arrive on the Dashboard page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 36
    testRunner.And("I click on Integration Menu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 37
 testRunner.And("I select the status as Pending approval radio button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 38
 testRunner.And("I expand the station details section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 39
 testRunner.And("I click on Approve Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 40
 testRunner.Then(string.Format("Verify the status of the request will change from -Pending Regional Manager Appro" +
                        "val to In Progress{0}", waitingStatus), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("IntergrationApprove3-> Verify the Approve button functionality for admin and sale" +
            "s management users in details of an integration request Section: s1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "IntegrationListPage_AcceptOrDeny")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint75")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("34284")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "s1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Scenario", "s1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "Systemadmin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DashboardTitle", "Dashboard")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:WaitingStatus", "In Progress: Waiting On Integration Team")]
        public virtual void IntergrationApprove3_VerifyTheApproveButtonFunctionalityForAdminAndSalesManagementUsersInDetailsOfAnIntegrationRequestSection_S1()
        {
#line 33
this.IntergrationApprove3_VerifyTheApproveButtonFunctionalityForAdminAndSalesManagementUsersInDetailsOfAnIntegrationRequestSection("s1", "Systemadmin", "Te$t1234", "Dashboard", "In Progress: Waiting On Integration Team", ((string[])(null)));
#line hidden
        }
        
        public virtual void IntergrationApprove4_VerifyTheDenyButtonFunctionalityForAdminAndSalesManagementUsersInDetailsOfAnIntegrationRequestSection(string scenario, string username, string password, string dashboardTitle, string completedStatus, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("IntergrationApprove4-> Verify the Deny button functionality for admin and sales m" +
                    "anagement users in details of an integration request Section", exampleTags);
#line 48
this.ScenarioSetup(scenarioInfo);
#line 49
    testRunner.Given(string.Format("I am a Sales Management or a System Admin user logged in with {0} and {1}", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 50
    testRunner.When("I arrive on the Dashboard page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 51
    testRunner.And("I click on Integration Menu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 52
 testRunner.And("I select the status as Pending approval radio button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
 testRunner.And("I expand the station details section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 54
 testRunner.And("I click on Deny Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 55
 testRunner.Then(string.Format("the status of the request in the Integration List Page will change from Pending R" +
                        "egional Manager Approval to Completed status{0}", completedStatus), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("IntergrationApprove4-> Verify the Deny button functionality for admin and sales m" +
            "anagement users in details of an integration request Section: s1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "IntegrationListPage_AcceptOrDeny")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint75")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("34284")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "s1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Scenario", "s1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "Systemadmin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DashboardTitle", "Dashboard")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:CompletedStatus", "Completed: Denied")]
        public virtual void IntergrationApprove4_VerifyTheDenyButtonFunctionalityForAdminAndSalesManagementUsersInDetailsOfAnIntegrationRequestSection_S1()
        {
#line 48
this.IntergrationApprove4_VerifyTheDenyButtonFunctionalityForAdminAndSalesManagementUsersInDetailsOfAnIntegrationRequestSection("s1", "Systemadmin", "Te$t1234", "Dashboard", "Completed: Denied", ((string[])(null)));
#line hidden
        }
    }
}
#pragma warning restore
#endregion
