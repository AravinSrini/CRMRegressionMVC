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
namespace CRM.UITest.Scripts.Quote.Results
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.2.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class _109136_Terminal_Information_Quote_Rate_ResultsFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "109136_Terminal_Information_Quote_Rate_Results.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "109136_Terminal_Information_Quote_Rate_Results", null, ProgrammingLanguage.CSharp, new string[] {
                        "Sprint94",
                        "109136",
                        "0007Arav"});
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "109136_Terminal_Information_Quote_Rate_Results")))
            {
                global::CRM.UITest.Scripts.Quote.Results._109136_Terminal_Information_Quote_Rate_ResultsFeature.FeatureSetup(null);
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
        
        public virtual void _109136_VerifyTerminalInfoLinkInQuoteResultLTLPage(string user, string username, string password, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("109136_Verify Terminal Info link in Quote result (LTL) Page", exampleTags);
#line 4
this.ScenarioSetup(scenarioInfo);
#line 5
 testRunner.Given(string.Format("I am a user and login into application with valid {0} and {1},", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 6
 testRunner.And(string.Format("I am on the Create Quote for LTL page {0}", user), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 7
 testRunner.And("I have entered all required information", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 8
 testRunner.And("I have clicked on the View Quote Results button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 9
 testRunner.When("I arrive on the Quote Results (LTL) page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
 testRunner.Then("I will see a link on each carrier rate labeled \'Terminal Info\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("109136_Verify Terminal Info link in Quote result (LTL) Page: Sales")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "109136_Terminal_Information_Quote_Rate_Results")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint94")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("109136")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("0007Arav")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Sales")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:user", "Sales")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "username-CurrentSprintSales")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "password-CurrentSprintSales")]
        public virtual void _109136_VerifyTerminalInfoLinkInQuoteResultLTLPage_Sales()
        {
#line 4
this._109136_VerifyTerminalInfoLinkInQuoteResultLTLPage("Sales", "username-CurrentSprintSales", "password-CurrentSprintSales", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("109136_Verify Terminal Info link in Quote result (LTL) Page: External")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "109136_Terminal_Information_Quote_Rate_Results")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint94")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("109136")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("0007Arav")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "External")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:user", "External")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "username-CurrentSprintshpentry")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "password-CurrentSprintshpentry")]
        public virtual void _109136_VerifyTerminalInfoLinkInQuoteResultLTLPage_External()
        {
#line 4
this._109136_VerifyTerminalInfoLinkInQuoteResultLTLPage("External", "username-CurrentSprintshpentry", "password-CurrentSprintshpentry", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("109136_Verify Terminal Info link in Quote result (LTL) Page: Internal")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "109136_Terminal_Information_Quote_Rate_Results")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint94")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("109136")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("0007Arav")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Internal")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:user", "Internal")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "username-CurrentSprintOperations")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "password-CurrentSprintOperations")]
        public virtual void _109136_VerifyTerminalInfoLinkInQuoteResultLTLPage_Internal()
        {
#line 4
this._109136_VerifyTerminalInfoLinkInQuoteResultLTLPage("Internal", "username-CurrentSprintOperations", "password-CurrentSprintOperations", ((string[])(null)));
#line hidden
        }
        
        public virtual void _109136_VerifyModalWillCloseForTerminalInformationModalWhenClickOnCloseButton(string user, string username, string password, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("109136_Verify Modal will close for Terminal Information modal when click on close" +
                    " button", exampleTags);
#line 18
this.ScenarioSetup(scenarioInfo);
#line 19
 testRunner.Given(string.Format("I am a user and login into application with valid {0} and {1},", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 20
 testRunner.And(string.Format("I am on the Create Quote for LTL page {0}", user), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
 testRunner.And("I have entered all required information", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
 testRunner.And("I have clicked on the View Quote Results button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
 testRunner.And("I clicked on the Terminal Info Link for a specific carrier rate,", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
 testRunner.And("I am in the Terminal Information modal,", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
 testRunner.When("I click on the Close button,", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 26
 testRunner.Then("the Terminal modal will close", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("109136_Verify Modal will close for Terminal Information modal when click on close" +
            " button: Sales")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "109136_Terminal_Information_Quote_Rate_Results")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint94")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("109136")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("0007Arav")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Sales")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:user", "Sales")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "username-CurrentSprintSales")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "password-CurrentSprintSales")]
        public virtual void _109136_VerifyModalWillCloseForTerminalInformationModalWhenClickOnCloseButton_Sales()
        {
#line 18
this._109136_VerifyModalWillCloseForTerminalInformationModalWhenClickOnCloseButton("Sales", "username-CurrentSprintSales", "password-CurrentSprintSales", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("109136_Verify Modal will close for Terminal Information modal when click on close" +
            " button: External")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "109136_Terminal_Information_Quote_Rate_Results")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint94")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("109136")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("0007Arav")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "External")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:user", "External")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "username-CurrentSprintshpentry")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "password-CurrentSprintshpentry")]
        public virtual void _109136_VerifyModalWillCloseForTerminalInformationModalWhenClickOnCloseButton_External()
        {
#line 18
this._109136_VerifyModalWillCloseForTerminalInformationModalWhenClickOnCloseButton("External", "username-CurrentSprintshpentry", "password-CurrentSprintshpentry", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("109136_Verify Modal will close for Terminal Information modal when click on close" +
            " button: Internal")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "109136_Terminal_Information_Quote_Rate_Results")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint94")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("109136")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("0007Arav")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Internal")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:user", "Internal")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "username-CurrentSprintOperations")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "password-CurrentSprintOperations")]
        public virtual void _109136_VerifyModalWillCloseForTerminalInformationModalWhenClickOnCloseButton_Internal()
        {
#line 18
this._109136_VerifyModalWillCloseForTerminalInformationModalWhenClickOnCloseButton("Internal", "username-CurrentSprintOperations", "password-CurrentSprintOperations", ((string[])(null)));
#line hidden
        }
        
        public virtual void _109136_VerifyTerminalInformationInModalPopUp(string user, string username, string password, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("109136_Verify terminal information in modal pop up", exampleTags);
#line 35
this.ScenarioSetup(scenarioInfo);
#line 36
 testRunner.Given(string.Format("I am a user and login into application with valid {0} and {1},", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 37
 testRunner.And(string.Format("I am on the Create Quote for LTL page {0}", user), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 38
 testRunner.And("I have entered all required information", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 39
 testRunner.And("I have clicked on the View Quote Results button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 40
 testRunner.When("I click on the Terminal Info Link for a specific carrier rate", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 41
 testRunner.Then("a popup modal is launched that displays the terminal information for selected car" +
                    "rier record", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 42
 testRunner.And("I will see a Close button.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("109136_Verify terminal information in modal pop up: Sales")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "109136_Terminal_Information_Quote_Rate_Results")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint94")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("109136")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("0007Arav")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Sales")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:user", "Sales")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "username-CurrentSprintSales")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "password-CurrentSprintSales")]
        public virtual void _109136_VerifyTerminalInformationInModalPopUp_Sales()
        {
#line 35
this._109136_VerifyTerminalInformationInModalPopUp("Sales", "username-CurrentSprintSales", "password-CurrentSprintSales", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("109136_Verify terminal information in modal pop up: External")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "109136_Terminal_Information_Quote_Rate_Results")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint94")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("109136")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("0007Arav")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "External")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:user", "External")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "username-CurrentSprintshpentry")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "password-CurrentSprintshpentry")]
        public virtual void _109136_VerifyTerminalInformationInModalPopUp_External()
        {
#line 35
this._109136_VerifyTerminalInformationInModalPopUp("External", "username-CurrentSprintshpentry", "password-CurrentSprintshpentry", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("109136_Verify terminal information in modal pop up: Internal")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "109136_Terminal_Information_Quote_Rate_Results")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint94")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("109136")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("0007Arav")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Internal")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:user", "Internal")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "username-CurrentSprintOperations")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "password-CurrentSprintOperations")]
        public virtual void _109136_VerifyTerminalInformationInModalPopUp_Internal()
        {
#line 35
this._109136_VerifyTerminalInformationInModalPopUp("Internal", "username-CurrentSprintOperations", "password-CurrentSprintOperations", ((string[])(null)));
#line hidden
        }
    }
}
#pragma warning restore
#endregion

