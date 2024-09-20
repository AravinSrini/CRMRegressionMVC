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
namespace CRM.UITest.Scripts.MaintenanceTools.ConfigureAccessorials
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.2.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class MaintenanceTools_ConfigureAccessorialsEditFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "MaintenanceTools _ConfigureAccessorialsEdit.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "MaintenanceTools _ConfigureAccessorialsEdit", null, ProgrammingLanguage.CSharp, new string[] {
                        "Sprint85",
                        "48167"});
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "MaintenanceTools _ConfigureAccessorialsEdit")))
            {
                global::CRM.UITest.Scripts.MaintenanceTools.ConfigureAccessorials.MaintenanceTools_ConfigureAccessorialsEditFeature.FeatureSetup(null);
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
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("48167 Verify the Elements in Edit Accessorial Modal")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "MaintenanceTools _ConfigureAccessorialsEdit")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint85")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("48167")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        public virtual void _48167VerifyTheElementsInEditAccessorialModal()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("48167 Verify the Elements in Edit Accessorial Modal", new string[] {
                        "GUI"});
#line 5
 this.ScenarioSetup(scenarioInfo);
#line 6
 testRunner.Given("that I am a Config Manager user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 7
 testRunner.And("I am on the Maintenance Tools page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 8
 testRunner.And("I Clicked On the <Configure Accessorials> button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 9
 testRunner.And("I am on the Configure Accessorials page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
 testRunner.When("I click on the <Edit> icon of any displayed accessorial", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 11
 testRunner.Then("the <Edit Accessorial> modal will open", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 12
 testRunner.And("I will see <Name> field - required, alpha-numeric, special characters, max length" +
                    " 100 characters", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
 testRunner.And("I will see <Service Code> field - required, alpha-numeric, max length 20 characte" +
                    "rs", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
 testRunner.And("I will see <MG Description> field - required, alpha-numeric, special characters, " +
                    "max length 100 characters", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
 testRunner.And("I will see Add Another MG Description link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
 testRunner.And("I will see <Service Types> required, multi-select as LTL, Truckload, Partial truc" +
                    "kload, Intermodal, Domestic Forwarding, International or All", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
 testRunner.And("I will see options for <Direction>", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
 testRunner.And("the options are <Shipping From>, <Shipping To>, <Both>, <None>", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
 testRunner.And("the fields will display the data associated to the accessorial", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
 testRunner.And("the fields are editable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
 testRunner.And("I will see the <Cancel> and <Save> buttons", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("48167 Verify Additional MG Description textbox appears and its required along wit" +
            "h Remove button upon click on the Add Another MG Description link")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "MaintenanceTools _ConfigureAccessorialsEdit")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint85")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("48167")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        public virtual void _48167VerifyAdditionalMGDescriptionTextboxAppearsAndItsRequiredAlongWithRemoveButtonUponClickOnTheAddAnotherMGDescriptionLink()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("48167 Verify Additional MG Description textbox appears and its required along wit" +
                    "h Remove button upon click on the Add Another MG Description link", new string[] {
                        "GUI"});
#line 24
 this.ScenarioSetup(scenarioInfo);
#line 25
 testRunner.Given("that I am a Config Manager user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 26
 testRunner.And("I am on the Maintenance Tools page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
 testRunner.And("I Clicked On the <Configure Accessorials> button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 28
 testRunner.And("I am on the Configure Accessorials page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
 testRunner.And("I clicked on the <Edit> icon of any displayed accessorial", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
 testRunner.And("I am in the <Edit Accessorial> modal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 31
 testRunner.When("I click on the Add Another MG Description link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 32
 testRunner.Then("a new <MG Description> text box will appear", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 33
 testRunner.And("I will see <Remove> button next to additional MG Description text box", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 34
 testRunner.And("the Additional MG Description field is required", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("48167 Verify the Edit Accessorial Modal closes upon click on the Cancel button in" +
            " the Edit Accessorial Modal")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "MaintenanceTools _ConfigureAccessorialsEdit")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint85")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("48167")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        public virtual void _48167VerifyTheEditAccessorialModalClosesUponClickOnTheCancelButtonInTheEditAccessorialModal()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("48167 Verify the Edit Accessorial Modal closes upon click on the Cancel button in" +
                    " the Edit Accessorial Modal", new string[] {
                        "GUI"});
#line 37
 this.ScenarioSetup(scenarioInfo);
#line 38
 testRunner.Given("that I am a Config Manager user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 39
 testRunner.And("I am on the Maintenance Tools page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 40
 testRunner.And("I Clicked On the <Configure Accessorials> button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 41
 testRunner.And("I am on the Configure Accessorials page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 42
 testRunner.And("I clicked on the <Edit> icon of any displayed accessorial", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 43
 testRunner.And("the <Edit Accessorial> modal opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 44
 testRunner.When("I Click on the <Cancel> button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 45
 testRunner.Then("the modal will close", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        public virtual void _48167VerifyTheConfigureAccessorialsGridWillBeUpdatedToDisplayTheEditedAccessorial(string field, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Functional"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("48167 Verify the Configure Accessorials grid will be updated to display the edite" +
                    "d accessorial", @__tags);
#line 48
 this.ScenarioSetup(scenarioInfo);
#line 49
 testRunner.Given("that I am a Config Manager user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 50
 testRunner.And("I am on the Maintenance Tools page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 51
 testRunner.And("I Clicked On the <Configure Accessorials> button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 52
 testRunner.And("I am on the Configure Accessorials page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
 testRunner.And("I clicked on the <Edit> icon of any displayed accessorial", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 54
 testRunner.And("the <Edit Accessorial> modal opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 55
 testRunner.And(string.Format("I edited any {0}", field), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 56
 testRunner.And("I have completed all the required fields", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 57
 testRunner.When("I click on the Save button in the <Edit Accessorial> Modal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 58
 testRunner.Then("the modal will close", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 59
 testRunner.And("the edits will be saved", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 60
 testRunner.And("the Configure Accessorials grid will be updated to display the edited accessorial" +
                    "", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("48167 Verify the Configure Accessorials grid will be updated to display the edite" +
            "d accessorial: Name")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "MaintenanceTools _ConfigureAccessorialsEdit")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint85")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("48167")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Name")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:field", "Name")]
        public virtual void _48167VerifyTheConfigureAccessorialsGridWillBeUpdatedToDisplayTheEditedAccessorial_Name()
        {
#line 48
 this._48167VerifyTheConfigureAccessorialsGridWillBeUpdatedToDisplayTheEditedAccessorial("Name", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("48167 Verify the Configure Accessorials grid will be updated to display the edite" +
            "d accessorial: ServiceCode")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "MaintenanceTools _ConfigureAccessorialsEdit")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint85")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("48167")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "ServiceCode")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:field", "ServiceCode")]
        public virtual void _48167VerifyTheConfigureAccessorialsGridWillBeUpdatedToDisplayTheEditedAccessorial_ServiceCode()
        {
#line 48
 this._48167VerifyTheConfigureAccessorialsGridWillBeUpdatedToDisplayTheEditedAccessorial("ServiceCode", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("48167 Verify the Configure Accessorials grid will be updated to display the edite" +
            "d accessorial: MGdescription")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "MaintenanceTools _ConfigureAccessorialsEdit")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint85")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("48167")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "MGdescription")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:field", "MGdescription")]
        public virtual void _48167VerifyTheConfigureAccessorialsGridWillBeUpdatedToDisplayTheEditedAccessorial_MGdescription()
        {
#line 48
 this._48167VerifyTheConfigureAccessorialsGridWillBeUpdatedToDisplayTheEditedAccessorial("MGdescription", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("48167 Verify the Configure Accessorials grid will be updated to display the edite" +
            "d accessorial: ServiceType")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "MaintenanceTools _ConfigureAccessorialsEdit")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint85")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("48167")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "ServiceType")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:field", "ServiceType")]
        public virtual void _48167VerifyTheConfigureAccessorialsGridWillBeUpdatedToDisplayTheEditedAccessorial_ServiceType()
        {
#line 48
 this._48167VerifyTheConfigureAccessorialsGridWillBeUpdatedToDisplayTheEditedAccessorial("ServiceType", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("48167 Verify the Configure Accessorials grid will be updated to display the edite" +
            "d accessorial: Direction")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "MaintenanceTools _ConfigureAccessorialsEdit")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint85")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("48167")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Direction")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:field", "Direction")]
        public virtual void _48167VerifyTheConfigureAccessorialsGridWillBeUpdatedToDisplayTheEditedAccessorial_Direction()
        {
#line 48
 this._48167VerifyTheConfigureAccessorialsGridWillBeUpdatedToDisplayTheEditedAccessorial("Direction", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("48167 Verify User not able to select any other Service Type, When the Service Typ" +
            "e All is selected in the Edit Accessorial Modal")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "MaintenanceTools _ConfigureAccessorialsEdit")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint85")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("48167")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        public virtual void _48167VerifyUserNotAbleToSelectAnyOtherServiceTypeWhenTheServiceTypeAllIsSelectedInTheEditAccessorialModal()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("48167 Verify User not able to select any other Service Type, When the Service Typ" +
                    "e All is selected in the Edit Accessorial Modal", new string[] {
                        "GUI"});
#line 72
 this.ScenarioSetup(scenarioInfo);
#line 73
 testRunner.Given("that I am a Config Manager user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 74
 testRunner.And("I am on the Maintenance Tools page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 75
 testRunner.And("I Clicked On the <Configure Accessorials> button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 76
 testRunner.And("I am on the Configure Accessorials page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 77
 testRunner.And("I clicked on the <Edit> icon of any displayed accessorial", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 78
 testRunner.And("I am on the <Edit Accessorial> modal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 79
 testRunner.When("I Select <Service Types> as ALL", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 80
 testRunner.Then("I am not allowed to Select any other Service Type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("48167 Verify all other selected Service Type gets removed from the Service Type d" +
            "ropdown upon selecting Service Type as All")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "MaintenanceTools _ConfigureAccessorialsEdit")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint85")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("48167")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        public virtual void _48167VerifyAllOtherSelectedServiceTypeGetsRemovedFromTheServiceTypeDropdownUponSelectingServiceTypeAsAll()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("48167 Verify all other selected Service Type gets removed from the Service Type d" +
                    "ropdown upon selecting Service Type as All", new string[] {
                        "GUI"});
#line 83
 this.ScenarioSetup(scenarioInfo);
#line 84
 testRunner.Given("that I am a Config Manager user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 85
 testRunner.And("I am on the Maintenance Tools page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 86
 testRunner.And("I Clicked On the <Configure Accessorials> button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 87
 testRunner.And("I am on the Configure Accessorials page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 88
 testRunner.And("I clicked on the <Edit> icon of any displayed accessorial", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 89
 testRunner.And("I am on the <Edit Accessorial> modal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 90
 testRunner.And("I Selected any <Service Type> apart from ALL", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 91
 testRunner.When("I Select Service Type as All", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 92
 testRunner.Then("the Service Type apart from All will be removed from the Service type dropdown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion

