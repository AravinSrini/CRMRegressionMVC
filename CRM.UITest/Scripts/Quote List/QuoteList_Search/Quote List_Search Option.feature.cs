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
namespace CRM.UITest.Scripts.QuoteList.QuoteList_Search
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.2.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class QuoteList_SearchOptionFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "Quote List_Search Option.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Quote List_Search Option", null, ProgrammingLanguage.CSharp, new string[] {
                        "26214",
                        "Sprint67"});
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "Quote List_Search Option")))
            {
                global::CRM.UITest.Scripts.QuoteList.QuoteList_Search.QuoteList_SearchOptionFeature.FeatureSetup(null);
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
        
        public virtual void VerifySearchQuotesFieldDropdownOptionsForOperationsSalesSalesManagementOrStationOwnerUser(string username, string password, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "GUI",
                    "Acceptance"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify search quotes field dropdown options for Operations, Sales, Sales Manageme" +
                    "nt, or Station Owner user", @__tags);
#line 5
this.ScenarioSetup(scenarioInfo);
#line 6
 testRunner.Given(string.Format("I am a DLS user and login into application with valid {0} and {1}", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 7
 testRunner.And("I have access to Quotes button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 8
 testRunner.When("I arrive on quotes list page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 9
 testRunner.And("I click on dropdown arrow in the search field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
 testRunner.Then("I should be able to view expected header values for internal users in search drop" +
                    "down", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify search quotes field dropdown options for Operations, Sales, Sales Manageme" +
            "nt, or Station Owner user: crmOperation@user.com")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Quote List_Search Option")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("26214")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint67")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Acceptance")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "crmOperation@user.com")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "crmOperation@user.com")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        public virtual void VerifySearchQuotesFieldDropdownOptionsForOperationsSalesSalesManagementOrStationOwnerUser_CrmOperationUser_Com()
        {
#line 5
this.VerifySearchQuotesFieldDropdownOptionsForOperationsSalesSalesManagementOrStationOwnerUser("crmOperation@user.com", "Te$t1234", ((string[])(null)));
#line hidden
        }
        
        public virtual void TrySelectingMultipleOptionsFromTheSearchQuoteFieldDropdownAndVerifyTheSameInTheGrid(string username, string password, string dropdown, string datesubmitted, string requestedNumber, string status, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Functional",
                    "GUI"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Try selecting multiple options from the search quote field dropdown and verify th" +
                    "e same in the grid", @__tags);
#line 17
this.ScenarioSetup(scenarioInfo);
#line 18
 testRunner.Given(string.Format("I am a DLS user and login into application with valid {0} and {1}", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 19
 testRunner.And("I have access to Quotes button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
 testRunner.When("I arrive on quotes list page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 21
 testRunner.And(string.Format("I do select display account type from the \'{0}\'", dropdown), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
 testRunner.And("I click on dropdown arrow in the search field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
 testRunner.Then("I must be able to click on select all checkbox and unselect all the selected fiel" +
                    "ds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 24
 testRunner.And("I must be able to select fields such as - DateSubmitted,Requested Number,Status f" +
                    "rom the dropdown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
 testRunner.And(string.Format("I must be able to search quotes by typing Datesubmitted values in the search quot" +
                        "e field and it should get highlighted in the grid- \'{0}\'", datesubmitted), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
    testRunner.And(string.Format("I must be able to search quotes by typing RequestedNumber values in the search qu" +
                        "ote field and it should get highlighted in the grid- \'{0}\'", requestedNumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
 testRunner.And(string.Format("I must be able to search quotes by typing Status values in the search quote field" +
                        " and it should get highlighted in the grid- \'{0}\'", status), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Try selecting multiple options from the search quote field dropdown and verify th" +
            "e same in the grid: crmOperation@user.com")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Quote List_Search Option")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("26214")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint67")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "crmOperation@user.com")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "crmOperation@user.com")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:dropdown", "ALL")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Datesubmitted", "9")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:RequestedNumber", "Q")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Status", "Expired")]
        public virtual void TrySelectingMultipleOptionsFromTheSearchQuoteFieldDropdownAndVerifyTheSameInTheGrid_CrmOperationUser_Com()
        {
#line 17
this.TrySelectingMultipleOptionsFromTheSearchQuoteFieldDropdownAndVerifyTheSameInTheGrid("crmOperation@user.com", "Te$t1234", "ALL", "9", "Q", "Expired", ((string[])(null)));
#line hidden
        }
        
        public virtual void VerifyTheExistenceOfClearButtonInTheSearchDropdown(string username, string password, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "GUI"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify the existence of Clear button in the search dropdown", @__tags);
#line 35
this.ScenarioSetup(scenarioInfo);
#line 36
 testRunner.Given(string.Format("I am a DLS user and login into application with valid {0} and {1}", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 37
 testRunner.And("I have access to Quotes button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 38
 testRunner.When("I arrive on quotes list page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 39
 testRunner.And("I click on dropdown arrow in the search field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 40
 testRunner.Then("I must be able to view Clear button in the Search dropdown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify the existence of Clear button in the search dropdown: crmOperation@user.co" +
            "m")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Quote List_Search Option")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("26214")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint67")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "crmOperation@user.com")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "crmOperation@user.com")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        public virtual void VerifyTheExistenceOfClearButtonInTheSearchDropdown_CrmOperationUser_Com()
        {
#line 35
this.VerifyTheExistenceOfClearButtonInTheSearchDropdown("crmOperation@user.com", "Te$t1234", ((string[])(null)));
#line hidden
        }
        
        public virtual void VerifyTheFunctionalityOfClearButttonInTheSearchQuoteFieldDropdown(string username, string password, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Functional"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify the functionality of Clear buttton in the search quote field dropdown", @__tags);
#line 47
this.ScenarioSetup(scenarioInfo);
#line 48
 testRunner.Given(string.Format("I am a DLS user and login into application with valid {0} and {1}", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 49
 testRunner.And("I have access to Quotes button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 50
 testRunner.When("I arrive on quotes list page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 51
 testRunner.And("I click on dropdown arrow in the search field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 52
 testRunner.And("I do click on Clear All button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
 testRunner.Then("All the selected options must get cleared in the search quote field dropdown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify the functionality of Clear buttton in the search quote field dropdown: crm" +
            "Operation@user.com")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Quote List_Search Option")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("26214")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint67")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "crmOperation@user.com")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "crmOperation@user.com")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        public virtual void VerifyTheFunctionalityOfClearButttonInTheSearchQuoteFieldDropdown_CrmOperationUser_Com()
        {
#line 47
this.VerifyTheFunctionalityOfClearButttonInTheSearchQuoteFieldDropdown("crmOperation@user.com", "Te$t1234", ((string[])(null)));
#line hidden
        }
        
        public virtual void VerifySearchQuotesFieldDropdownOptionsForShp_InquiryOrShp_EntryUser(string username, string password, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "GUI",
                    "Acceptance"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify search quotes field dropdown options for shp.inquiry or shp.entry user", @__tags);
#line 61
this.ScenarioSetup(scenarioInfo);
#line 62
 testRunner.Given(string.Format("I am a DLS user and login into application with valid {0} and {1}", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 63
 testRunner.And("I have access to Quotes button for external users", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 64
 testRunner.When("I arrive on quotes list page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 65
 testRunner.And("I click on dropdown arrow in the search field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 66
 testRunner.Then("I must be able to view expected search dropdown values for External Users", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify search quotes field dropdown options for shp.inquiry or shp.entry user: Su" +
            "rShipEntry@user.com")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Quote List_Search Option")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("26214")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint67")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Acceptance")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "SurShipEntry@user.com")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "SurShipEntry@user.com")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        public virtual void VerifySearchQuotesFieldDropdownOptionsForShp_InquiryOrShp_EntryUser_SurShipEntryUser_Com()
        {
#line 61
this.VerifySearchQuotesFieldDropdownOptionsForShp_InquiryOrShp_EntryUser("SurShipEntry@user.com", "Te$t1234", ((string[])(null)));
#line hidden
        }
        
        public virtual void VerifyTheNoteSectionInsideSearchDropdown(string username, string password, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify the note section inside Search Dropdown", exampleTags);
#line 72
this.ScenarioSetup(scenarioInfo);
#line 73
 testRunner.Given(string.Format("I am a DLS user and login into application with valid {0} and {1}", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 74
 testRunner.And("I have access to Quotes button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 75
 testRunner.When("I arrive on quotes list page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 76
 testRunner.And("I click on dropdown arrow in the search field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 77
 testRunner.Then("I must be able to view note within Search dropdown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify the note section inside Search Dropdown: crmOperation@user.com")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Quote List_Search Option")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("26214")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint67")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "crmOperation@user.com")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "crmOperation@user.com")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        public virtual void VerifyTheNoteSectionInsideSearchDropdown_CrmOperationUser_Com()
        {
#line 72
this.VerifyTheNoteSectionInsideSearchDropdown("crmOperation@user.com", "Te$t1234", ((string[])(null)));
#line hidden
        }
    }
}
#pragma warning restore
#endregion
