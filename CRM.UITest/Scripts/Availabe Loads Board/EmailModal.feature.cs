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
namespace CRM.UITest.Scripts.AvailabeLoadsBoard
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.2.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class EmailModalFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "EmailModal.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "EmailModal", null, ProgrammingLanguage.CSharp, new string[] {
                        "Sprint8_Ninja",
                        "35434"});
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "EmailModal")))
            {
                global::CRM.UITest.Scripts.AvailabeLoadsBoard.EmailModalFeature.FeatureSetup(null);
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
        
        public virtual void _35434_VerifyTheUIFieldsOfEmailModalNavigatedFromTheAvailableLoadBoardPage(string uRL, string toEmailId, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "GUI"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("35434 - Verify the UI fields of email modal navigated from the Available LoadBoar" +
                    "d page", @__tags);
#line 5
this.ScenarioSetup(scenarioInfo);
#line 6
testRunner.Given(string.Format("I am any user and on the Available Loads page{0} ,", uRL), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 7
testRunner.When("I click on the email button of any displayed load from the grid,", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 8
testRunner.Then("an email modal will open,", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 9
testRunner.And(string.Format("I should see To email address non editable text box with pre filled email id {0} " +
                        "as a default value", toEmailId), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
testRunner.And("I should see From email address editable text box", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
testRunner.And("I should see Subject non editable text box with pre filled value", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
testRunner.And("I should see the body of the email editable text box", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
testRunner.And("I should see a send and cancel Buttons", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("35434 - Verify the UI fields of email modal navigated from the Available LoadBoar" +
            "d page: http://dlscrm-test.rrd.com/AvailableLoads/Index")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "EmailModal")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint8_Ninja")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("35434")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "http://dlscrm-test.rrd.com/AvailableLoads/Index")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:URL", "http://dlscrm-test.rrd.com/AvailableLoads/Index")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ToEmailId", "tst.admnsys16@gmail.com")]
        public virtual void _35434_VerifyTheUIFieldsOfEmailModalNavigatedFromTheAvailableLoadBoardPage_HttpDlscrm_Test_Rrd_ComAvailableLoadsIndex()
        {
#line 5
this._35434_VerifyTheUIFieldsOfEmailModalNavigatedFromTheAvailableLoadBoardPage("http://dlscrm-test.rrd.com/AvailableLoads/Index", "tst.admnsys16@gmail.com", ((string[])(null)));
#line hidden
        }
        
        public virtual void _35434_VerifyMaxLengthForTheBodyOfTheEmailTextBox(string uRL, string text, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "GUI"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("35434 - Verify max length for the body of the email text box", @__tags);
#line 20
this.ScenarioSetup(scenarioInfo);
#line 21
testRunner.Given(string.Format("I am any user and on the Available Loads page{0} ,", uRL), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 22
testRunner.When("I click on the email button of any displayed load from the grid,", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 23
testRunner.Then("an email modal will open,", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 24
testRunner.And(string.Format("I should be able to enter only 250 alphanumeric and special characters {0}", text), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("35434 - Verify max length for the body of the email text box: http://dlscrm-test." +
            "rrd.com/AvailableLoads/Index")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "EmailModal")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint8_Ninja")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("35434")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "http://dlscrm-test.rrd.com/AvailableLoads/Index")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:URL", "http://dlscrm-test.rrd.com/AvailableLoads/Index")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Text", "Test@123")]
        public virtual void _35434_VerifyMaxLengthForTheBodyOfTheEmailTextBox_HttpDlscrm_Test_Rrd_ComAvailableLoadsIndex()
        {
#line 20
this._35434_VerifyMaxLengthForTheBodyOfTheEmailTextBox("http://dlscrm-test.rrd.com/AvailableLoads/Index", "Test@123", ((string[])(null)));
#line hidden
        }
        
        public virtual void _35434_VerifyTheInvalidEmailValidationForFromAddressTextBox(string uRL, string invalidEmail, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "GUI"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("35434 - Verify the invalid email validation for from address text box", @__tags);
#line 31
this.ScenarioSetup(scenarioInfo);
#line 32
testRunner.Given(string.Format("I am any user and on the Available Loads page{0} ,", uRL), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 33
testRunner.When("I click on the email button of any displayed load from the grid,", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 34
testRunner.Then("an email modal will open,", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 35
testRunner.And(string.Format("I enter invalid email \'{0}\' in From email text box", invalidEmail), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 36
testRunner.And("I click on Send button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 37
testRunner.Then("email text box should be highlighted and displayed with error message for invalid" +
                    "", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("35434 - Verify the invalid email validation for from address text box: http://dls" +
            "crm-test.rrd.com/AvailableLoads/Index")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "EmailModal")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint8_Ninja")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("35434")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "http://dlscrm-test.rrd.com/AvailableLoads/Index")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:URL", "http://dlscrm-test.rrd.com/AvailableLoads/Index")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:InvalidEmail", "test")]
        public virtual void _35434_VerifyTheInvalidEmailValidationForFromAddressTextBox_HttpDlscrm_Test_Rrd_ComAvailableLoadsIndex()
        {
#line 31
this._35434_VerifyTheInvalidEmailValidationForFromAddressTextBox("http://dlscrm-test.rrd.com/AvailableLoads/Index", "test", ((string[])(null)));
#line hidden
        }
        
        public virtual void _35434_VerifyTheFunctionalityOfCancelButtonWithinEmailPopup(string uRL, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "GUI"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("35434 - Verify the functionality of cancel button within email popup", @__tags);
#line 44
this.ScenarioSetup(scenarioInfo);
#line 45
testRunner.Given(string.Format("I am any user and on the Available Loads page{0} ,", uRL), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 46
testRunner.When("I click on the email button of any displayed load from the grid,", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 47
testRunner.Then("an email modal will open,", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 48
testRunner.And("I Click on cancel button within email model popup", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 49
testRunner.Then("I will arrive on the Available Loads page.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("35434 - Verify the functionality of cancel button within email popup: http://dlsc" +
            "rm-test.rrd.com/AvailableLoads/Index")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "EmailModal")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint8_Ninja")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("35434")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "http://dlscrm-test.rrd.com/AvailableLoads/Index")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:URL", "http://dlscrm-test.rrd.com/AvailableLoads/Index")]
        public virtual void _35434_VerifyTheFunctionalityOfCancelButtonWithinEmailPopup_HttpDlscrm_Test_Rrd_ComAvailableLoadsIndex()
        {
#line 44
this._35434_VerifyTheFunctionalityOfCancelButtonWithinEmailPopup("http://dlscrm-test.rrd.com/AvailableLoads/Index", ((string[])(null)));
#line hidden
        }
    }
}
#pragma warning restore
#endregion
