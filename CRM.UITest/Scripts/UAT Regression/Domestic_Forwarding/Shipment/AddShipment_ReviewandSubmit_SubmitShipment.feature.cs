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
namespace CRM.UITest.Scripts.UATRegression.Domestic_Forwarding.Shipment
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class AddShipment_ReviewandSubmit_SubmitShipmentFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "AddShipment_ReviewandSubmit_SubmitShipment.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "AddShipment_ReviewandSubmit_SubmitShipment", null, ProgrammingLanguage.CSharp, new string[] {
                        "32146",
                        "Regression",
                        "Sprint71"});
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "AddShipment_ReviewandSubmit_SubmitShipment")))
            {
                global::CRM.UITest.Scripts.UATRegression.Domestic_Forwarding.Shipment.AddShipment_ReviewandSubmit_SubmitShipmentFeature.FeatureSetup(null);
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
        
        public virtual void _32146_VerifyTheSubmitButtonFunctionalityInReviewAndSubmitPage(
                    string username, 
                    string password, 
                    string type, 
                    string oLocationName, 
                    string oLocationAdd, 
                    string oZip, 
                    string dLocationName, 
                    string dLocationAdd, 
                    string dZip, 
                    string pickupReady, 
                    string pickupClose, 
                    string deliveryReady, 
                    string deliveryClose, 
                    string pieces, 
                    string weight, 
                    string length, 
                    string width, 
                    string height, 
                    string itemDesc, 
                    string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("32146_Verify the submit button functionality in Review and Submit Page", exampleTags);
#line 4
this.ScenarioSetup(scenarioInfo);
#line 5
 testRunner.Given(string.Format("I am a shp.entry,shp.entrynorates, operations, sales, sales management or a stati" +
                        "on user- \'{0}\',\'{1}\'", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 6
 testRunner.And(string.Format("I am on Review and Submit Page of Add Shipment process {0}, {1}, {2},{3}, {4}, {5" +
                        "}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15} and {16}", type, oLocationName, oLocationAdd, oZip, dLocationName, dLocationAdd, dZip, pickupReady, pickupClose, deliveryReady, deliveryClose, pieces, weight, length, width, height, itemDesc), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 7
 testRunner.When("I click on Submit button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 8
 testRunner.Then("I must be displayed with Service, Type, Pick up date, House bill number and statu" +
                    "s on confirmation page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 9
 testRunner.And("View Shipment details and House bill buttons must be displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("32146_Verify the submit button functionality in Review and Submit Page: both")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "AddShipment_ReviewandSubmit_SubmitShipment")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("32146")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint71")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "both")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "both")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:type", "Same Day")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:OLocationName", "o location name")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:OLocationAdd", "o add")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:OZip", "33126")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DLocationName", "d location name")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DLocationAdd", "d add")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DZip", "85282")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:PickupReady", "10:00 AM")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:PickupClose", "11:00 AM")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DeliveryReady", "5:00 PM")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DeliveryClose", "6:00 PM")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Pieces", "2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Weight", "100")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Length", "10")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Width", "10")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Height", "10")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ItemDesc", "item 1")]
        public virtual void _32146_VerifyTheSubmitButtonFunctionalityInReviewAndSubmitPage_Both()
        {
#line 4
this._32146_VerifyTheSubmitButtonFunctionalityInReviewAndSubmitPage("both", "Te$t1234", "Same Day", "o location name", "o add", "33126", "d location name", "d add", "85282", "10:00 AM", "11:00 AM", "5:00 PM", "6:00 PM", "2", "100", "10", "10", "10", "item 1", ((string[])(null)));
#line hidden
        }
        
        public virtual void _32146_VerifyTheStartNewShipmentEntryButtonFunctionalityOnConfirmationPage(
                    string username, 
                    string password, 
                    string type, 
                    string oLocationName, 
                    string oLocationAdd, 
                    string oZip, 
                    string dLocationName, 
                    string dLocationAdd, 
                    string dZip, 
                    string pickupReady, 
                    string pickupClose, 
                    string deliveryReady, 
                    string deliveryClose, 
                    string pieces, 
                    string weight, 
                    string length, 
                    string width, 
                    string height, 
                    string itemDesc, 
                    string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("32146_Verify the Start New Shipment Entry button functionality on Confirmation pa" +
                    "ge", exampleTags);
#line 15
this.ScenarioSetup(scenarioInfo);
#line 16
 testRunner.Given(string.Format("I am a shp.entry,shp.entrynorates, operations, sales, sales management or a stati" +
                        "on user- \'{0}\',\'{1}\'", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 17
 testRunner.And(string.Format("I am on Confirmation Page of Add Shipment process {0}, {1}, {2},{3}, {4}, {5}, {6" +
                        "}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15} and {16}", type, oLocationName, oLocationAdd, oZip, dLocationName, dLocationAdd, dZip, pickupReady, pickupClose, deliveryReady, deliveryClose, pieces, weight, length, width, height, itemDesc), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
 testRunner.When("I Click on Start New Shipment Entry button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 19
 testRunner.Then("I must be navigated to Add Shipment Shipment Service page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("32146_Verify the Start New Shipment Entry button functionality on Confirmation pa" +
            "ge: both")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "AddShipment_ReviewandSubmit_SubmitShipment")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("32146")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint71")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "both")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "both")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:type", "Same Day")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:OLocationName", "o location name")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:OLocationAdd", "o add")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:OZip", "33126")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DLocationName", "d location name")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DLocationAdd", "d add")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DZip", "85282")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:PickupReady", "10:00 AM")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:PickupClose", "11:00 AM")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DeliveryReady", "5:00 PM")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DeliveryClose", "6:00 PM")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Pieces", "2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Weight", "100")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Length", "10")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Width", "10")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Height", "10")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ItemDesc", "item 1")]
        public virtual void _32146_VerifyTheStartNewShipmentEntryButtonFunctionalityOnConfirmationPage_Both()
        {
#line 15
this._32146_VerifyTheStartNewShipmentEntryButtonFunctionalityOnConfirmationPage("both", "Te$t1234", "Same Day", "o location name", "o add", "33126", "d location name", "d add", "85282", "10:00 AM", "11:00 AM", "5:00 PM", "6:00 PM", "2", "100", "10", "10", "10", "item 1", ((string[])(null)));
#line hidden
        }
    }
}
#pragma warning restore
#endregion
