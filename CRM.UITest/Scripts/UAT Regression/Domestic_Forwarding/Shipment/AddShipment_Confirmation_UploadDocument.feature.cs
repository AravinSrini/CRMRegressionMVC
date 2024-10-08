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
    [Microsoft.VisualStudio.TestTools.UnitTesting.IgnoreAttribute()]
    public partial class AddShipment_Confirmation_UploadDocumentFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "AddShipment_Confirmation_UploadDocument.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "AddShipment_Confirmation_UploadDocument", null, ProgrammingLanguage.CSharp, new string[] {
                        "32147",
                        "Regression",
                        "Sprint71",
                        "Ignore"});
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "AddShipment_Confirmation_UploadDocument")))
            {
                global::CRM.UITest.Scripts.UATRegression.Domestic_Forwarding.Shipment.AddShipment_Confirmation_UploadDocumentFeature.FeatureSetup(null);
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
        
        public virtual void _32147_VerifyTheUploadedDocumentInRecentlyAddedPagePresentInDocumentRepository(
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
                    string path, 
                    string docName, 
                    string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("32147- Verify the uploaded document in recently added page present in document re" +
                    "pository", exampleTags);
#line 5
this.ScenarioSetup(scenarioInfo);
#line 6
 testRunner.Given(string.Format("I am on the Confirmation page of the Add Shipment process {0}, {1}, {2}, {3}, {4}" +
                        ",{5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17} and {18" +
                        "}", username, password, type, oLocationName, oLocationAdd, oZip, dLocationName, dLocationAdd, dZip, pickupReady, pickupClose, deliveryReady, deliveryClose, pieces, weight, length, width, height, itemDesc), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 7
 testRunner.And(string.Format("I have uploaded a document {0}", path), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 8
 testRunner.When("I arrive on the Document repository page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 9
 testRunner.Then(string.Format("the recently uploaded document must be listed in the grid {0}", docName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 10
 testRunner.And(string.Format("the reference number must be the primary reference number of the shipment {0}", docName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("32147- Verify the uploaded document in recently added page present in document re" +
            "pository: both")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "AddShipment_Confirmation_UploadDocument")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("32147")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint71")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "both")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "both")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Type", "Same Day")]
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Path", "..\\..\\Scripts\\TestData\\ShipmentConfirmation_Doc\\TestDoc.xls")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:docName", "TestDoc")]
        public virtual void _32147_VerifyTheUploadedDocumentInRecentlyAddedPagePresentInDocumentRepository_Both()
        {
#line 5
this._32147_VerifyTheUploadedDocumentInRecentlyAddedPagePresentInDocumentRepository("both", "Te$t1234", "Same Day", "o location name", "o add", "33126", "d location name", "d add", "85282", "10:00 AM", "11:00 AM", "5:00 PM", "6:00 PM", "2", "100", "10", "10", "10", "item 1", "..\\..\\Scripts\\TestData\\ShipmentConfirmation_Doc\\TestDoc.xls", "TestDoc", ((string[])(null)));
#line hidden
        }
        
        public virtual void _32147_VerifyTheUploadedDocumentInBOLSectionPresentInDocumentRepository(
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
                    string path, 
                    string docName, 
                    string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("32147 - Verify the uploaded document in BOL section present in document repositor" +
                    "y", exampleTags);
#line 16
this.ScenarioSetup(scenarioInfo);
#line 17
 testRunner.Given(string.Format("I am on the Confirmation page of the Add Shipment process {0}, {1}, {2}, {3}, {4}" +
                        ",{5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17} and {18" +
                        "}", username, password, type, oLocationName, oLocationAdd, oZip, dLocationName, dLocationAdd, dZip, pickupReady, pickupClose, deliveryReady, deliveryClose, pieces, weight, length, width, height, itemDesc), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 18
 testRunner.And(string.Format("I have uploaded a document {0}", path), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
 testRunner.When("I arrive on the Document repository page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 20
 testRunner.And("I open the BOL folder", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
 testRunner.Then(string.Format("the document is displayed {0}", docName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 22
 testRunner.And(string.Format("the reference number must be the primary reference number of the shipment {0}", docName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("32147 - Verify the uploaded document in BOL section present in document repositor" +
            "y: both")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "AddShipment_Confirmation_UploadDocument")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("32147")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint71")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "both")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "both")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Type", "Same Day")]
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Path", "..\\..\\Scripts\\TestData\\ShipmentConfirmation_Doc\\TestDoc.xls")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:docName", "TestDoc")]
        public virtual void _32147_VerifyTheUploadedDocumentInBOLSectionPresentInDocumentRepository_Both()
        {
#line 16
this._32147_VerifyTheUploadedDocumentInBOLSectionPresentInDocumentRepository("both", "Te$t1234", "Same Day", "o location name", "o add", "33126", "d location name", "d add", "85282", "10:00 AM", "11:00 AM", "5:00 PM", "6:00 PM", "2", "100", "10", "10", "10", "item 1", "..\\..\\Scripts\\TestData\\ShipmentConfirmation_Doc\\TestDoc.xls", "TestDoc", ((string[])(null)));
#line hidden
        }
    }
}
#pragma warning restore
#endregion
