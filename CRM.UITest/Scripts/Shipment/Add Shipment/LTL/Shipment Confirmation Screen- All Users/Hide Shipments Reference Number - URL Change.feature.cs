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
    public partial class HideShipmentsReferenceNumber_URLChangeFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "Hide Shipments Reference Number - URL Change.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Hide Shipments Reference Number - URL Change", null, ProgrammingLanguage.CSharp, new string[] {
                        "32964"});
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "Hide Shipments Reference Number - URL Change")))
            {
                global::CRM.UITest.Scripts.Shipment.AddShipment.LTL.ShipmentConfirmationScreen_AllUsers.HideShipmentsReferenceNumber_URLChangeFeature.FeatureSetup(null);
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
        
        public virtual void _32964_VerifyTheURLFromShipmentDetailsPage(
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
                    "Regression"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("32964 - Verify the URL from shipment details page", @__tags);
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
 testRunner.Given("I am a shp.entry, shp.entrynorates, operations, sales, sales management, or stati" +
                    "on owner user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
 testRunner.And(string.Format("I am on the Shipment Confirmation (LTL) page  {0}, {1}, {2},{3}, {4}, {5},{6},{7}" +
                        ",{8}, {9},{10}, {11}, {12},{13}, {14}, {15}, {16}", usertype, oAdd2, oZip, oName, oAdd1, dAdd2, dName, dAdd1, customer_Name, oComments, dComments, dZip, classification, nmfc, quantity, weight, desc), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 9
 testRunner.When("I click on the View Shipment Details button on the confirmation page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
 testRunner.Then("the BOL number will not be displayed in the URL details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("32964 - Verify the URL from shipment details page: External")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Hide Shipments Reference Number - URL Change")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("32964")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
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
        public virtual void _32964_VerifyTheURLFromShipmentDetailsPage_External()
        {
#line 6
this._32964_VerifyTheURLFromShipmentDetailsPage("External", "asd", "60606", "DName", "OAddress", "", "DAddress", "60606", "Daddress", "", "Dname", "", "55", "q123asd", "1", "1", "desc", ((string[])(null)));
#line hidden
        }
        
        public virtual void _32964_VerifyTheURLForTheViewBillOfLanding(
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
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("32964 - Verify the URL for the View Bill Of Landing", exampleTags);
#line 17
this.ScenarioSetup(scenarioInfo);
#line 18
 testRunner.Given("I am a shp.entry, shp.entrynorates, operations, sales, sales management, or stati" +
                    "on owner user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 19
 testRunner.And(string.Format("I am on the Shipment Confirmation (LTL) page  {0}, {1}, {2},{3}, {4}, {5},{6},{7}" +
                        ",{8}, {9},{10}, {11}, {12},{13}, {14}, {15}, {16}", usertype, oAdd2, oZip, oName, oAdd1, dAdd2, dName, dAdd1, customer_Name, oComments, dComments, dZip, classification, nmfc, quantity, weight, desc), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
 testRunner.When("I click on the drop down arrow of the Bill of Lading button and select View Bill " +
                    "of Landing option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 21
 testRunner.When("I click on the drop down arrow of the Bill of Lading button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 23
 testRunner.Then("the BOL number will not be displayed in the URL of View Bill Of Landing page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("32964 - Verify the URL for the View Bill Of Landing: External")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Hide Shipments Reference Number - URL Change")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("32964")]
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
        public virtual void _32964_VerifyTheURLForTheViewBillOfLanding_External()
        {
#line 17
this._32964_VerifyTheURLForTheViewBillOfLanding("External", "asd", "60606", "DName", "OAddress", "", "DAddress", "60606", "Daddress", "", "Dname", "", "55", "q123asd", "1", "1", "desc", ((string[])(null)));
#line hidden
        }
        
        public virtual void _32964_VerifyTheURLForPrintShiippingLabel(
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
                    string label_Name, 
                    string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("32964 - Verify the URL for Print Shiipping Label", exampleTags);
#line 30
this.ScenarioSetup(scenarioInfo);
#line 31
 testRunner.Given("I am a shp.entry, shp.entrynorates, operations, sales, sales management, or stati" +
                    "on owner user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 32
 testRunner.And(string.Format("I am on the Shipment Confirmation (LTL) page  {0}, {1}, {2},{3}, {4}, {5},{6},{7}" +
                        ",{8}, {9},{10}, {11}, {12},{13}, {14}, {15}, {16}", usertype, oAdd2, oZip, oName, oAdd1, dAdd2, dName, dAdd1, customer_Name, oComments, dComments, dZip, classification, nmfc, quantity, weight, desc), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
 testRunner.When(string.Format("I click on the drop down arrow of the Print Shipping Labels {0} button  and make " +
                        "any selection from the drop down {1}", usertype, label_Name), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 36
 testRunner.Then("BOL number will not be displayed in the URL of Print Shiipping Label", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("32964 - Verify the URL for Print Shiipping Label: External")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Hide Shipments Reference Number - URL Change")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("32964")]
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Label_Name", "Full Page Label")]
        public virtual void _32964_VerifyTheURLForPrintShiippingLabel_External()
        {
#line 30
this._32964_VerifyTheURLForPrintShiippingLabel("External", "asd", "60606", "DName", "OAddress", "", "DAddress", "60606", "Daddress", "", "Dname", "", "55", "q123asd", "1", "1", "desc", "Full Page Label", ((string[])(null)));
#line hidden
        }
        
        public virtual void _32964_VerifyTheURLForShipmentSummaryPage(
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
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("32964 - Verify the URL for shipment summary page", exampleTags);
#line 42
this.ScenarioSetup(scenarioInfo);
#line 43
 testRunner.Given("I am a shp.entry, shp.entrynorates, operations, sales, sales management, or stati" +
                    "on owner user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 44
 testRunner.And(string.Format("I am on the Shipment Confirmation (LTL) page  {0}, {1}, {2},{3}, {4}, {5},{6},{7}" +
                        ",{8}, {9},{10}, {11}, {12},{13}, {14}, {15}, {16}", usertype, oAdd2, oZip, oName, oAdd1, dAdd2, dName, dAdd1, customer_Name, oComments, dComments, dZip, classification, nmfc, quantity, weight, desc), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 45
 testRunner.When("I click on the drop down arrow of the View shipment Summary button and select Vie" +
                    "w Shipment Summary button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 46
 testRunner.Then("the BOL number will not be displayed in the URL shipment summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("32964 - Verify the URL for shipment summary page: External")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Hide Shipments Reference Number - URL Change")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("32964")]
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
        public virtual void _32964_VerifyTheURLForShipmentSummaryPage_External()
        {
#line 42
this._32964_VerifyTheURLForShipmentSummaryPage("External", "asd", "60606", "DName", "OAddress", "", "DAddress", "60606", "Daddress", "", "Dname", "", "55", "q123asd", "1", "1", "desc", ((string[])(null)));
#line hidden
        }
        
        public virtual void _32964_VerifyTheURLOfShipmentCoverageDocumentPage(
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
                    "Ignore"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("32964 - Verify the URL of shipment coverage document page", @__tags);
#line 53
this.ScenarioSetup(scenarioInfo);
#line 54
 testRunner.Given("I am a shp.entry, shp.entrynorates, operations, sales, sales management, or stati" +
                    "on owner user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 55
 testRunner.And(string.Format("I click on the insured shipment and navigate to the Shipment Confirmation (LTL) p" +
                        "age  {0}, {1}, {2},{3}, {4}, {5},{6},{7},{8}, {9},{10}, {11}, {12},{13}, {14}, {" +
                        "15}, {16}", usertype, oAdd2, oZip, oName, oAdd1, dAdd2, dName, dAdd1, customer_Name, oComments, dComments, dZip, classification, nmfc, quantity, weight, desc), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 56
 testRunner.When("I click on the View Shipment Coverage button on the Shipment Confirmation page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 57
 testRunner.Then("the BOL number will not be displayed in the URL Shipment Coverage page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("32964 - Verify the URL of shipment coverage document page: External")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Hide Shipments Reference Number - URL Change")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("32964")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.IgnoreAttribute()]
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
        public virtual void _32964_VerifyTheURLOfShipmentCoverageDocumentPage_External()
        {
#line 53
this._32964_VerifyTheURLOfShipmentCoverageDocumentPage("External", "asd", "60606", "DName", "OAddress", "", "DAddress", "60606", "Daddress", "", "Dname", "", "55", "q123asd", "1", "1", "desc", ((string[])(null)));
#line hidden
        }
    }
}
#pragma warning restore
#endregion
