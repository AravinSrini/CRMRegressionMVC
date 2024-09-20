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
namespace CRM.UITest.Scripts.Shipment.AddShipment.LTL.ShipmentInformationScreen
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class AddShipmentLTL_MVC5_RemoveItemButton_AllUsersFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "AddShipmentLTL_MVC5_RemoveItemButton_AllUsers.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner(null, 0);
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "AddShipmentLTL_MVC5_RemoveItemButton_AllUsers", null, ProgrammingLanguage.CSharp, new string[] {
                        "28009",
                        "Sprint69"});
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "AddShipmentLTL_MVC5_RemoveItemButton_AllUsers")))
            {
                CRM.UITest.Scripts.Shipment.AddShipment.LTL.ShipmentInformationScreen.AddShipmentLTL_MVC5_RemoveItemButton_AllUsersFeature.FeatureSetup(null);
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
        
        public virtual void VerifyTheRemoveItemButtonFunctionalityForAllNonAdminUsers(string scenario, string username, string password, string shipmentList_Header, string customer_Name, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "GUI",
                    "Functional"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify the Remove Item button functionality for all non admin users", @__tags);
#line 5
this.ScenarioSetup(scenarioInfo);
#line 6
testRunner.Given(string.Format("I am a DLS user and login into application with valid {0} and {1}", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 7
testRunner.And("I click on the Shipment icon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 8
testRunner.And(string.Format("I navigate to shipment list {0} page", shipmentList_Header), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 9
testRunner.And(string.Format("I have selected Customer from the dropdown {0}", customer_Name), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
testRunner.And("I clicked on Add Shipment button for internalusers", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
testRunner.And("I have clicked on LTL tile of shipment process", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
testRunner.When("I am taken to Add Shipment LTL page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 13
testRunner.And("I click on Add Additional Item button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
testRunner.And("I click on Remove Item button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
testRunner.Then("I should not be displayed with additional item added", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 16
testRunner.And("I should not be displayed with Remove Item button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify the Remove Item button functionality for all non admin users: s1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "AddShipmentLTL_MVC5_RemoveItemButton_AllUsers")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("28009")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint69")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "s1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Scenario", "s1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "crmOperation")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ShipmentList_Header", "Shipment List")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Customer_Name", "ZZZ - GS Customer Test")]
        public virtual void VerifyTheRemoveItemButtonFunctionalityForAllNonAdminUsers_S1()
        {
            this.VerifyTheRemoveItemButtonFunctionalityForAllNonAdminUsers("s1", "crmOperation", "Te$t1234", "Shipment List", "ZZZ - GS Customer Test", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify the Remove Item button functionality for all non admin users: s2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "AddShipmentLTL_MVC5_RemoveItemButton_AllUsers")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("28009")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint69")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "s2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Scenario", "s2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "saleTest")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ShipmentList_Header", "Shipment List")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Customer_Name", "ZZZ - Czar Customer Test")]
        public virtual void VerifyTheRemoveItemButtonFunctionalityForAllNonAdminUsers_S2()
        {
            this.VerifyTheRemoveItemButtonFunctionalityForAllNonAdminUsers("s2", "saleTest", "Te$t1234", "Shipment List", "ZZZ - Czar Customer Test", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify the Remove Item button functionality for all non admin users: s3")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "AddShipmentLTL_MVC5_RemoveItemButton_AllUsers")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("28009")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint69")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "s3")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Scenario", "s3")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "stationowner")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ShipmentList_Header", "Shipment List")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Customer_Name", "ZZZ - GS Customer Test")]
        public virtual void VerifyTheRemoveItemButtonFunctionalityForAllNonAdminUsers_S3()
        {
            this.VerifyTheRemoveItemButtonFunctionalityForAllNonAdminUsers("s3", "stationowner", "Te$t1234", "Shipment List", "ZZZ - GS Customer Test", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify the Remove Item button functionality for all non admin users: s4")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "AddShipmentLTL_MVC5_RemoveItemButton_AllUsers")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("28009")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint69")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "s4")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Scenario", "s4")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "crmsalesusr")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ShipmentList_Header", "Shipment List")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Customer_Name", "ZZZ Sandbox DLS Worldwide")]
        public virtual void VerifyTheRemoveItemButtonFunctionalityForAllNonAdminUsers_S4()
        {
            this.VerifyTheRemoveItemButtonFunctionalityForAllNonAdminUsers("s4", "crmsalesusr", "Te$t1234", "Shipment List", "ZZZ Sandbox DLS Worldwide", ((string[])(null)));
#line hidden
        }
        
        public virtual void VerifyTheRemoveItemButtonFunctionalityForExternalUsers(string scenario, string username, string password, string shipmentList_Header, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "GUI",
                    "Functional"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify the Remove Item button functionality for external users", @__tags);
#line 26
this.ScenarioSetup(scenarioInfo);
#line 27
testRunner.Given(string.Format("I am a DLS user and login into application with valid {0} and {1}", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 28
testRunner.And("I have access to Shipment button for external users", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
testRunner.And(string.Format("I navigate to shipment list {0} page", shipmentList_Header), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
testRunner.And("I clicked on Add Shipment button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 31
testRunner.And("I have clicked on LTL tile of shipment process", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
testRunner.When("I am taken to Add Shipment LTL page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 33
testRunner.And("I click on Add Additional Item button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 34
testRunner.And("I click on Remove Item button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 35
testRunner.Then("I should not be displayed with additional item added", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 36
testRunner.And("I should not be displayed with Remove Item button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify the Remove Item button functionality for external users: s1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "AddShipmentLTL_MVC5_RemoveItemButton_AllUsers")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("28009")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint69")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "s1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Scenario", "s1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "shpent")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ShipmentList_Header", "Shipment List")]
        public virtual void VerifyTheRemoveItemButtonFunctionalityForExternalUsers_S1()
        {
            this.VerifyTheRemoveItemButtonFunctionalityForExternalUsers("s1", "shpent", "Te$t1234", "Shipment List", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify the Remove Item button functionality for external users: s2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "AddShipmentLTL_MVC5_RemoveItemButton_AllUsers")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("28009")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint69")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "s2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Scenario", "s2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "shpentnorts")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ShipmentList_Header", "Shipment List")]
        public virtual void VerifyTheRemoveItemButtonFunctionalityForExternalUsers_S2()
        {
            this.VerifyTheRemoveItemButtonFunctionalityForExternalUsers("s2", "shpentnorts", "Te$t1234", "Shipment List", ((string[])(null)));
#line hidden
        }
    }
}
#pragma warning restore
#endregion
