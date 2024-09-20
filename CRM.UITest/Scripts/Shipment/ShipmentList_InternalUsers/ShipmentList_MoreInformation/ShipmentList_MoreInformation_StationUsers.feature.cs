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
namespace CRM.UITest.Scripts.Shipment.ShipmentList_InternalUsers.ShipmentList_MoreInformation
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class ShipmentList_MoreInformation_StationUsersFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "ShipmentList_MoreInformation_StationUsers.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "ShipmentList_MoreInformation_StationUsers", null, ProgrammingLanguage.CSharp, new string[] {
                        "Sprint68",
                        "27229"});
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "ShipmentList_MoreInformation_StationUsers")))
            {
                global::CRM.UITest.Scripts.Shipment.ShipmentList_InternalUsers.ShipmentList_MoreInformation.ShipmentList_MoreInformation_StationUsersFeature.FeatureSetup(null);
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
        
        public virtual void VerifyTheDisplayingFieldsUnderMoreInformationIconForMGShipment(string scenario, string username, string password, string data, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Functional",
                    "GUI"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify the displaying fields under more information icon for MG shipment", @__tags);
#line 5
this.ScenarioSetup(scenarioInfo);
#line 6
 testRunner.Given(string.Format("I am a DLS user and login into application with valid {0} and {1}", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 7
 testRunner.When("I click on the Shipment Icon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 8
 testRunner.And(string.Format("I search for any {0} inside shipment search box", data), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 9
 testRunner.And("I click on information icon any MG shipment", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
 testRunner.Then("the information box will be displayed with the following fields - Quantity,Weight" +
                    ",Carrier", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify the displaying fields under more information icon for MG shipment: S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ShipmentList_MoreInformation_StationUsers")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint68")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("27229")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Scenario", "S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "stationown")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Data", "LTL")]
        public virtual void VerifyTheDisplayingFieldsUnderMoreInformationIconForMGShipment_S1()
        {
#line 5
this.VerifyTheDisplayingFieldsUnderMoreInformationIconForMGShipment("S1", "stationown", "Te$t1234", "LTL", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify the displaying fields under more information icon for MG shipment: S2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ShipmentList_MoreInformation_StationUsers")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint68")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("27229")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "S2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Scenario", "S2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "Opstage")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Data", "LTL")]
        public virtual void VerifyTheDisplayingFieldsUnderMoreInformationIconForMGShipment_S2()
        {
#line 5
this.VerifyTheDisplayingFieldsUnderMoreInformationIconForMGShipment("S2", "Opstage", "Te$t1234", "LTL", ((string[])(null)));
#line hidden
        }
        
        public virtual void VerifyTheDisplayingFieldsUnderMoreInformationIconForCSAShipment(string scenario, string username, string password, string data, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Functional",
                    "GUI"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify the displaying fields under more information icon for CSA shipment", @__tags);
#line 19
this.ScenarioSetup(scenarioInfo);
#line 20
 testRunner.Given(string.Format("I am a DLS user and login into application with valid {0} and {1}", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 21
 testRunner.When("I click on the Shipment Icon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 22
 testRunner.And(string.Format("I search for any {0} inside shipment search box", data), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
 testRunner.And("I click on information icon any CSA shipment", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
 testRunner.Then("the information box will be displayed with the following fields - Quantity,Weight" +
                    ",Service Type,Service Level", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify the displaying fields under more information icon for CSA shipment: S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ShipmentList_MoreInformation_StationUsers")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint68")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("27229")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Scenario", "S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "stationown")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Data", "International")]
        public virtual void VerifyTheDisplayingFieldsUnderMoreInformationIconForCSAShipment_S1()
        {
#line 19
this.VerifyTheDisplayingFieldsUnderMoreInformationIconForCSAShipment("S1", "stationown", "Te$t1234", "International", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify the displaying fields under more information icon for CSA shipment: S2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ShipmentList_MoreInformation_StationUsers")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint68")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("27229")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "S2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Scenario", "S2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "Opstage")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Data", "International")]
        public virtual void VerifyTheDisplayingFieldsUnderMoreInformationIconForCSAShipment_S2()
        {
#line 19
this.VerifyTheDisplayingFieldsUnderMoreInformationIconForCSAShipment("S2", "Opstage", "Te$t1234", "International", ((string[])(null)));
#line hidden
        }
        
        public virtual void CompareAndVerifyTheDisplayingDataUnderMoreInformationIconForMGShipmentForStationOwner(string username, string password, string account, string data, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Functional",
                    "Regression",
                    "DBVerification"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Compare and Verify the displaying data under more information icon for MG shipmen" +
                    "t for station owner", @__tags);
#line 33
this.ScenarioSetup(scenarioInfo);
#line 34
 testRunner.Given("I  login into application as StationOwner", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 35
 testRunner.When("I click on the Shipment Icon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 36
 testRunner.And("I click on customer drop down in shipment list page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 37
 testRunner.And(string.Format("I select any customer account {0} from the customer dropdown in shipment list", account), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 38
 testRunner.And(string.Format("I search for any {0} inside shipment search box", data), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 39
 testRunner.And("I click on information icon any MG shipment", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 40
 testRunner.Then(string.Format("displaying data for Quantity,Weight,Carrier fields should match with API {0}", account), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Compare and Verify the displaying data under more information icon for MG shipmen" +
            "t for station owner: stationown")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ShipmentList_MoreInformation_StationUsers")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint68")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("27229")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("DBVerification")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "stationown")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "stationown")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Account", "ZZZ - GS Customer Test")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Data", "LTL")]
        public virtual void CompareAndVerifyTheDisplayingDataUnderMoreInformationIconForMGShipmentForStationOwner_Stationown()
        {
#line 33
this.CompareAndVerifyTheDisplayingDataUnderMoreInformationIconForMGShipmentForStationOwner("stationown", "", "ZZZ - GS Customer Test", "LTL", ((string[])(null)));
#line hidden
        }
        
        public virtual void CompareAndVerifyTheDisplayingDataUnderMoreInformationIconForMGShipmentForOpStageUser(string username, string password, string account, string data, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Functional",
                    "Regression",
                    "DBVerification"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Compare and Verify the displaying data under more information icon for MG shipmen" +
                    "t for OpStage user", @__tags);
#line 49
this.ScenarioSetup(scenarioInfo);
#line 50
 testRunner.Given("I Log in as Opstage user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 51
 testRunner.When("I click on the Shipment Icon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 52
 testRunner.And("I click on customer drop down in shipment list page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
 testRunner.And(string.Format("I select any customer account {0} from the customer dropdown in shipment list", account), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 54
 testRunner.And(string.Format("I search for any {0} inside shipment search box", data), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 55
 testRunner.And("I click on information icon any MG shipment", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 56
 testRunner.Then(string.Format("displaying data for Quantity,Weight,Carrier fields should match with API {0}", account), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Compare and Verify the displaying data under more information icon for MG shipmen" +
            "t for OpStage user: Opstage")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ShipmentList_MoreInformation_StationUsers")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint68")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("27229")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("DBVerification")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Opstage")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "Opstage")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Account", "32SP01-Steve Andrastek")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Data", "LTL")]
        public virtual void CompareAndVerifyTheDisplayingDataUnderMoreInformationIconForMGShipmentForOpStageUser_Opstage()
        {
#line 49
this.CompareAndVerifyTheDisplayingDataUnderMoreInformationIconForMGShipmentForOpStageUser("Opstage", "", "32SP01-Steve Andrastek", "LTL", ((string[])(null)));
#line hidden
        }
        
        public virtual void CompareAndVerifyTheDisplayingDataUnderMoreInformationIconForCSAShipmentForStationowner(string data, string account, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Functional",
                    "Regression",
                    "DBVerification"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Compare and Verify the displaying data under more information icon for CSA shipme" +
                    "nt for stationowner", @__tags);
#line 65
this.ScenarioSetup(scenarioInfo);
#line 66
testRunner.Given("I  login into application as StationOwner", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 67
 testRunner.When("I click on the Shipment Icon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 68
 testRunner.And("I click on customer drop down in shipment list page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 69
 testRunner.And(string.Format("I select any customer account {0} from the customer dropdown in shipment list", account), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 70
 testRunner.And(string.Format("I search for any {0} inside shipment search box", data), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 71
 testRunner.And("I click on information icon any CSA shipment", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 72
 testRunner.Then(string.Format("displaying data for Quantity,Weight,Service Type and Service Level fields should " +
                        "match with API {0}", account), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Compare and Verify the displaying data under more information icon for CSA shipme" +
            "nt for stationowner: International")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ShipmentList_MoreInformation_StationUsers")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint68")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("27229")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("DBVerification")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "International")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Data", "International")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Account", "ZZZ - GS Customer Test")]
        public virtual void CompareAndVerifyTheDisplayingDataUnderMoreInformationIconForCSAShipmentForStationowner_International()
        {
#line 65
this.CompareAndVerifyTheDisplayingDataUnderMoreInformationIconForCSAShipmentForStationowner("International", "ZZZ - GS Customer Test", ((string[])(null)));
#line hidden
        }
    }
}
#pragma warning restore
#endregion
