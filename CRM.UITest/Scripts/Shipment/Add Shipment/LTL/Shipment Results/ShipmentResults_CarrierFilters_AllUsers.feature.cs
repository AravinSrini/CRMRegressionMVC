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
namespace CRM.UITest.Scripts.Shipment.AddShipment.LTL.ShipmentResults
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class ShipmentResults_CarrierFilters_AllUsersFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "ShipmentResults_CarrierFilters_AllUsers.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner(null, 0);
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "ShipmentResults_CarrierFilters_AllUsers", null, ProgrammingLanguage.CSharp, new string[] {
                        "ShipmentResults_CarrierFilters_AllUsers",
                        "28162",
                        "Sprint70"});
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "ShipmentResults_CarrierFilters_AllUsers")))
            {
                CRM.UITest.Scripts.Shipment.AddShipment.LTL.ShipmentResults.ShipmentResults_CarrierFilters_AllUsersFeature.FeatureSetup(null);
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
        
        public virtual void VerifyTheCarrierFilterSelectedByDefaultOnShipmentResultLTLPageForAllUser(
                    string scenario, 
                    string username, 
                    string password, 
                    string usertype, 
                    string customerName, 
                    string originName, 
                    string originAddr1, 
                    string originZipcode, 
                    string destinationName, 
                    string destinationAddr1, 
                    string destinationZipcode, 
                    string classification, 
                    string nmfc, 
                    string quantity, 
                    string weight, 
                    string itemdesc, 
                    string quickest_Service, 
                    string least_Cost, 
                    string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "GUI"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify the carrier filter selected by default on shipment result LTL page for All" +
                    " user", @__tags);
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
 testRunner.Given(string.Format("I am a shp.entry, operations, sales, sales management or station user {0} {1}", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
 testRunner.And(string.Format("I enter data in add shipment ltl page {0}, {1},{2},{3},{4},{5},{6},{7},{8},{9},{1" +
                        "0},{11},{12}", usertype, customerName, originName, originAddr1, originZipcode, destinationName, destinationAddr1, destinationZipcode, classification, nmfc, quantity, weight, itemdesc), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 9
 testRunner.When("I click on View rates button in add shipment ltl page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
 testRunner.Then(string.Format("I will see the {0} and {1} carrier filter", quickest_Service, least_Cost), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 11
 testRunner.And("Verified that Quickest Service carrier filter is selected by default", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify the carrier filter selected by default on shipment result LTL page for All" +
            " user: S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ShipmentResults_CarrierFilters_AllUsers")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("ShipmentResults_CarrierFilters_AllUsers")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("28162")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint70")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Scenario", "S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "crmOperation@user.com")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Usertype", "Internal")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:CustomerName", "ZZZ - GS Customer Test")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:originName", "Oname")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:originAddr1", "Oname1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:originZipcode", "33126")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:destinationName", "Dname")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:destinationAddr1", "Dname2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:destinationZipcode", "85282")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Classification", "55")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:nmfc", "6789-01")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:quantity", "5")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:weight", "100")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:itemdesc", "CLEANING WIPES")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Quickest_Service", "Quickest Service")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Least_Cost", "Least Cost")]
        public virtual void VerifyTheCarrierFilterSelectedByDefaultOnShipmentResultLTLPageForAllUser_S1()
        {
            this.VerifyTheCarrierFilterSelectedByDefaultOnShipmentResultLTLPageForAllUser("S1", "crmOperation@user.com", "Te$t1234", "Internal", "ZZZ - GS Customer Test", "Oname", "Oname1", "33126", "Dname", "Dname2", "85282", "55", "6789-01", "5", "100", "CLEANING WIPES", "Quickest Service", "Least Cost", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify the carrier filter selected by default on shipment result LTL page for All" +
            " user: S2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ShipmentResults_CarrierFilters_AllUsers")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("ShipmentResults_CarrierFilters_AllUsers")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("28162")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint70")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "S2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Scenario", "S2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "shp.entry")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Usertype", "")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:CustomerName", "")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:originName", "Oname")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:originAddr1", "Oname1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:originZipcode", "33126")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:destinationName", "Dname")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:destinationAddr1", "Dname2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:destinationZipcode", "85282")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Classification", "55")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:nmfc", "6789-01")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:quantity", "5")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:weight", "100")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:itemdesc", "CLEANING WIPES")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Quickest_Service", "Quickest Service")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Least_Cost", "Least Cost")]
        public virtual void VerifyTheCarrierFilterSelectedByDefaultOnShipmentResultLTLPageForAllUser_S2()
        {
            this.VerifyTheCarrierFilterSelectedByDefaultOnShipmentResultLTLPageForAllUser("S2", "shp.entry", "Te$t1234", "", "", "Oname", "Oname1", "33126", "Dname", "Dname2", "85282", "55", "6789-01", "5", "100", "CLEANING WIPES", "Quickest Service", "Least Cost", ((string[])(null)));
#line hidden
        }
        
        public virtual void VerifyTheClickFunctionalityOfLeastCostCarrierFilterOnShipmentResultLTLPageForAllUser(
                    string scenario, 
                    string username, 
                    string password, 
                    string usertype, 
                    string customerName, 
                    string originName, 
                    string originAddr1, 
                    string originZipcode, 
                    string destinationName, 
                    string destinationAddr1, 
                    string destinationZipcode, 
                    string classification, 
                    string nmfc, 
                    string quantity, 
                    string weight, 
                    string itemdesc, 
                    string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "GUI",
                    "Functional"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify the Click functionality of Least Cost carrier filter on shipment result LT" +
                    "L page for All user", @__tags);
#line 20
this.ScenarioSetup(scenarioInfo);
#line 21
 testRunner.Given(string.Format("I am a shp.entry, operations, sales, sales management or station user {0} {1}", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 22
 testRunner.And(string.Format("I enter data in add shipment ltl page {0}, {1},{2},{3},{4},{5},{6},{7},{8},{9},{1" +
                        "0},{11},{12}", usertype, customerName, originName, originAddr1, originZipcode, destinationName, destinationAddr1, destinationZipcode, classification, nmfc, quantity, weight, itemdesc), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
 testRunner.When("I click on View rates button in add shipment ltl page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 24
 testRunner.Then(string.Format("Verify that by selecting the Least cost on Result page will resort to display the" +
                        " carrier options begning with least cost {0}", usertype), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify the Click functionality of Least Cost carrier filter on shipment result LT" +
            "L page for All user: S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ShipmentResults_CarrierFilters_AllUsers")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("ShipmentResults_CarrierFilters_AllUsers")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("28162")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint70")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Scenario", "S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "crmOperation@user.com")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Usertype", "Internal")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:CustomerName", "ZZZ - GS Customer Test")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:originName", "Oname")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:originAddr1", "Oname1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:originZipcode", "33126")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:destinationName", "Dname")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:destinationAddr1", "Dname2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:destinationZipcode", "85282")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Classification", "55")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:nmfc", "6789-01")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:quantity", "5")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:weight", "100")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:itemdesc", "CLEANING WIPES")]
        public virtual void VerifyTheClickFunctionalityOfLeastCostCarrierFilterOnShipmentResultLTLPageForAllUser_S1()
        {
            this.VerifyTheClickFunctionalityOfLeastCostCarrierFilterOnShipmentResultLTLPageForAllUser("S1", "crmOperation@user.com", "Te$t1234", "Internal", "ZZZ - GS Customer Test", "Oname", "Oname1", "33126", "Dname", "Dname2", "85282", "55", "6789-01", "5", "100", "CLEANING WIPES", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify the Click functionality of Least Cost carrier filter on shipment result LT" +
            "L page for All user: S2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ShipmentResults_CarrierFilters_AllUsers")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("ShipmentResults_CarrierFilters_AllUsers")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("28162")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint70")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "S2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Scenario", "S2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "shp.entry")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Usertype", "")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:CustomerName", "")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:originName", "Oname")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:originAddr1", "Oname1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:originZipcode", "33126")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:destinationName", "Dname")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:destinationAddr1", "Dname2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:destinationZipcode", "85282")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Classification", "55")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:nmfc", "6789-01")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:quantity", "5")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:weight", "100")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:itemdesc", "CLEANING WIPES")]
        public virtual void VerifyTheClickFunctionalityOfLeastCostCarrierFilterOnShipmentResultLTLPageForAllUser_S2()
        {
            this.VerifyTheClickFunctionalityOfLeastCostCarrierFilterOnShipmentResultLTLPageForAllUser("S2", "shp.entry", "Te$t1234", "", "", "Oname", "Oname1", "33126", "Dname", "Dname2", "85282", "55", "6789-01", "5", "100", "CLEANING WIPES", ((string[])(null)));
#line hidden
        }
        
        public virtual void VerifyTheClickFunctionalityOfQuickestServiceCarrierFilterOnShipmentResultLTLPageForAllUser(
                    string scenario, 
                    string username, 
                    string password, 
                    string usertype, 
                    string customerName, 
                    string originName, 
                    string originAddr1, 
                    string originZipcode, 
                    string destinationName, 
                    string destinationAddr1, 
                    string destinationZipcode, 
                    string classification, 
                    string nmfc, 
                    string quantity, 
                    string weight, 
                    string itemdesc, 
                    string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "GUI",
                    "Functional"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify the Click functionality of Quickest Service carrier filter on shipment res" +
                    "ult LTL page for All user", @__tags);
#line 33
this.ScenarioSetup(scenarioInfo);
#line 34
 testRunner.Given(string.Format("I am a shp.entry, operations, sales, sales management or station user {0} {1}", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 35
 testRunner.And(string.Format("I enter data in add shipment ltl page {0}, {1},{2},{3},{4},{5},{6},{7},{8},{9},{1" +
                        "0},{11},{12}", usertype, customerName, originName, originAddr1, originZipcode, destinationName, destinationAddr1, destinationZipcode, classification, nmfc, quantity, weight, itemdesc), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 36
 testRunner.When("I click on View rates button in add shipment ltl page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 37
 testRunner.Then(string.Format("Verify that by selecting the Quickest Service on results page will resort to disp" +
                        "lay the carrier options begning with the lowest number of service days and least" +
                        " cost {0}", usertype), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify the Click functionality of Quickest Service carrier filter on shipment res" +
            "ult LTL page for All user: S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ShipmentResults_CarrierFilters_AllUsers")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("ShipmentResults_CarrierFilters_AllUsers")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("28162")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint70")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Scenario", "S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "crmOperation@user.com")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Usertype", "Internal")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:CustomerName", "ZZZ - GS Customer Test")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:originName", "Oname")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:originAddr1", "Oname1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:originZipcode", "30013")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:destinationName", "Dname")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:destinationAddr1", "Dname2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:destinationZipcode", "30013")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Classification", "55 CLEANING WIPES")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:nmfc", "6789-01")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:quantity", "5")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:weight", "100")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:itemdesc", "CLEANING WIPES")]
        public virtual void VerifyTheClickFunctionalityOfQuickestServiceCarrierFilterOnShipmentResultLTLPageForAllUser_S1()
        {
            this.VerifyTheClickFunctionalityOfQuickestServiceCarrierFilterOnShipmentResultLTLPageForAllUser("S1", "crmOperation@user.com", "Te$t1234", "Internal", "ZZZ - GS Customer Test", "Oname", "Oname1", "30013", "Dname", "Dname2", "30013", "55 CLEANING WIPES", "6789-01", "5", "100", "CLEANING WIPES", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify the Click functionality of Quickest Service carrier filter on shipment res" +
            "ult LTL page for All user: S2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ShipmentResults_CarrierFilters_AllUsers")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("ShipmentResults_CarrierFilters_AllUsers")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("28162")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint70")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "S2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Scenario", "S2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "shp.entry")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Usertype", "")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:CustomerName", "")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:originName", "Oname")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:originAddr1", "Oname1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:originZipcode", "30013")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:destinationName", "Dname")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:destinationAddr1", "Dname2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:destinationZipcode", "30013")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Classification", "55 CLEANING WIPES")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:nmfc", "6789-01")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:quantity", "5")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:weight", "100")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:itemdesc", "CLEANING WIPES")]
        public virtual void VerifyTheClickFunctionalityOfQuickestServiceCarrierFilterOnShipmentResultLTLPageForAllUser_S2()
        {
            this.VerifyTheClickFunctionalityOfQuickestServiceCarrierFilterOnShipmentResultLTLPageForAllUser("S2", "shp.entry", "Te$t1234", "", "", "Oname", "Oname1", "30013", "Dname", "Dname2", "30013", "55 CLEANING WIPES", "6789-01", "5", "100", "CLEANING WIPES", ((string[])(null)));
#line hidden
        }
    }
}
#pragma warning restore
#endregion
