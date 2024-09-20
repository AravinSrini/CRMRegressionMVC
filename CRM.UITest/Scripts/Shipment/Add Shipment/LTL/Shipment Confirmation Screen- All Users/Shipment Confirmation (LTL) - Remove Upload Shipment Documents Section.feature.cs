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
namespace CRM.UITest.Scripts.Shipment.AddShipment.LTL.ShipmentConfirmationScreen_AllUsers
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class ShipmentConfirmationLTL_RemoveUploadShipmentDocumentsSectionFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "Shipment Confirmation (LTL) - Remove Upload Shipment Documents Section.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Shipment Confirmation (LTL) - Remove Upload Shipment Documents Section", null, ProgrammingLanguage.CSharp, new string[] {
                        "33188",
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "Shipment Confirmation (LTL) - Remove Upload Shipment Documents Section")))
            {
                global::CRM.UITest.Scripts.Shipment.AddShipment.LTL.ShipmentConfirmationScreen_AllUsers.ShipmentConfirmationLTL_RemoveUploadShipmentDocumentsSectionFeature.FeatureSetup(null);
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
        
        public virtual void _33188_TestToVerifyRemoveUploadShipmentDocumentsSection(
                    string usertype, 
                    string dAdd2, 
                    string oZip, 
                    string oName, 
                    string oAdd1, 
                    string oAdd2, 
                    string dName, 
                    string dZip, 
                    string dAdd1, 
                    string customer_Name, 
                    string oComments, 
                    string dComments, 
                    string classification, 
                    string nmfc, 
                    string quantity, 
                    string weight, 
                    string desc, 
                    string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "GUI",
                    "Functional"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("33188_Test to verify Remove Upload Shipment Documents Section", @__tags);
#line 5
this.ScenarioSetup(scenarioInfo);
#line 6
   testRunner.Given("I am a shp.entry, shp.entrynorates, operations, sales, sales management, or stati" +
                    "on owner user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 7
   testRunner.And(string.Format("I am on the Shipment Confirmation (LTL) page  {0}, {1}, {2},{3}, {4}, {5},{6},{7}" +
                        ",{8}, {9},{10}, {11}, {12},{13}, {14}, {15}, {16}", usertype, oAdd2, oZip, oName, oAdd1, dAdd2, dName, dAdd1, customer_Name, oComments, dComments, dZip, classification, nmfc, quantity, weight, desc), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 8
   testRunner.When("I arrive on the Shipment Confirmation page in the shipment process", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 9
   testRunner.Then("I should not be displayed with Upload Shipment Documents Section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("33188_Test to verify Remove Upload Shipment Documents Section: External")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Shipment Confirmation (LTL) - Remove Upload Shipment Documents Section")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("33188")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint71")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "External")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Usertype", "External")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:dAdd2", "asd")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:oZip", "60606")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:oName", "DName")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:oAdd1", "OAddress")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:oAdd2", "")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:dName", "DAddress")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:dZip", "60606")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:dAdd1", "Daddress")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Customer_Name", "")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:oComments", "Dname")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:dComments", "")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:classification", "55")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:nmfc", "q123asd")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:quantity", "1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:weight", "1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:desc", "desc")]
        public virtual void _33188_TestToVerifyRemoveUploadShipmentDocumentsSection_External()
        {
#line 5
this._33188_TestToVerifyRemoveUploadShipmentDocumentsSection("External", "asd", "60606", "DName", "OAddress", "", "DAddress", "60606", "Daddress", "", "Dname", "", "55", "q123asd", "1", "1", "desc", ((string[])(null)));
#line hidden
        }
    }
}
#pragma warning restore
#endregion
