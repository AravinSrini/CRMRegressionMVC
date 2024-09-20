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
namespace CRM.UITest.Scripts.CustomerInvoices.CustomReport
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.2.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class CustomerInvoice_CustomReport_DaysPastDueFieldFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "Customer Invoice - Custom Report - Days Past Due Field.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Customer Invoice - Custom Report - Days Past Due Field", null, ProgrammingLanguage.CSharp, new string[] {
                        "38915",
                        "NinjaSprint16"});
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "Customer Invoice - Custom Report - Days Past Due Field")))
            {
                global::CRM.UITest.Scripts.CustomerInvoices.CustomReport.CustomerInvoice_CustomReport_DaysPastDueFieldFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("38915_Verify that the Days Past Due field is a numeric control with increments of" +
            " + or - one and allows whole numbers with values of zero or greater")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Customer Invoice - Custom Report - Days Past Due Field")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("38915")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("NinjaSprint16")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        public virtual void _38915_VerifyThatTheDaysPastDueFieldIsANumericControlWithIncrementsOfOr_OneAndAllowsWholeNumbersWithValuesOfZeroOrGreater()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("38915_Verify that the Days Past Due field is a numeric control with increments of" +
                    " + or - one and allows whole numbers with values of zero or greater", new string[] {
                        "GUI",
                        "Functional"});
#line 5
this.ScenarioSetup(scenarioInfo);
#line 6
 testRunner.Given("I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, s" +
                    "ales, sales management, station owner, or access rrd user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 7
 testRunner.And("I arrived on Customer Invoice List page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 8
 testRunner.When("I expanded the Create Custom Report section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 9
 testRunner.Then("I have the option to enter the Days Past Due using a numeric control with increme" +
                    "nts of + or - one", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 10
 testRunner.And("I can only enter whole numbers with values of zero or greater", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("38915_Verify that the Invoice value field is formatted as US currency like $x,xxx" +
            ".xx")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Customer Invoice - Custom Report - Days Past Due Field")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("38915")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("NinjaSprint16")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        public virtual void _38915_VerifyThatTheInvoiceValueFieldIsFormattedAsUSCurrencyLikeXXxx_Xx()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("38915_Verify that the Invoice value field is formatted as US currency like $x,xxx" +
                    ".xx", new string[] {
                        "GUI",
                        "Functional"});
#line 13
this.ScenarioSetup(scenarioInfo);
#line 14
 testRunner.Given("I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, s" +
                    "ales, sales management, station owner, or access rrd user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 15
 testRunner.And("I arrived on Customer Invoice List page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
 testRunner.When("I expanded the Create Custom Report section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 17
 testRunner.Then("I will have the option to enter a numeric Invoice Value formatted as US currency " +
                    "like $x,xxx.xx", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("38915_Verify that the Invoice value Range selector dropdown has 2 values > and < " +
            "and is defaulted to >")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Customer Invoice - Custom Report - Days Past Due Field")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("38915")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("NinjaSprint16")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        public virtual void _38915_VerifyThatTheInvoiceValueRangeSelectorDropdownHas2ValuesAndAndIsDefaultedTo()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("38915_Verify that the Invoice value Range selector dropdown has 2 values > and < " +
                    "and is defaulted to >", new string[] {
                        "GUI",
                        "Functional"});
#line 20
this.ScenarioSetup(scenarioInfo);
#line 21
 testRunner.Given("I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, s" +
                    "ales, sales management, station owner, or access rrd user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 22
 testRunner.And("I arrived on Customer Invoice List page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
 testRunner.When("I expanded the Create Custom Report section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 24
 testRunner.Then("The Invoice Value will have a range selector with the following selectors Greater" +
                    "Than > and LessThan <", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 25
 testRunner.And("Greater than symbol > is selected by default", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("52650-Verify the Days Past Due data is equal to or greater than the entered value" +
            " in the Days Past Due field while Create Customer Report Section")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Customer Invoice - Custom Report - Days Past Due Field")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("38915")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("NinjaSprint16")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("52650")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint87")]
        public virtual void _52650_VerifyTheDaysPastDueDataIsEqualToOrGreaterThanTheEnteredValueInTheDaysPastDueFieldWhileCreateCustomerReportSection()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("52650-Verify the Days Past Due data is equal to or greater than the entered value" +
                    " in the Days Past Due field while Create Customer Report Section", new string[] {
                        "52650",
                        "Sprint87"});
#line 29
this.ScenarioSetup(scenarioInfo);
#line 30
    testRunner.Given("I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, s" +
                    "ales, sales management, station owner, or access rrd user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 31
    testRunner.And("I am on the Customer Invoices page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
 testRunner.And("I am on the Create Customer Report Section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
 testRunner.And("I selected Invoice type is Open", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 34
 testRunner.And("I entered a value in the DaysPastDue field along with all required fields", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 35
 testRunner.When("I Click on the button Preview/Run", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 36
 testRunner.Then("the grid should display invoices with the DaysPastDue equal to or greater than th" +
                    "e value entered in the DaysPastDue field in Create Custom Report Section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("52650-Verify the Days Past Due data is equal to or greater than the Days Past Due" +
            " field When I select the Existing Custom Report")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Customer Invoice - Custom Report - Days Past Due Field")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("38915")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("NinjaSprint16")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("52650")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint87")]
        public virtual void _52650_VerifyTheDaysPastDueDataIsEqualToOrGreaterThanTheDaysPastDueFieldWhenISelectTheExistingCustomReport()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("52650-Verify the Days Past Due data is equal to or greater than the Days Past Due" +
                    " field When I select the Existing Custom Report", new string[] {
                        "52650",
                        "Sprint87"});
#line 39
this.ScenarioSetup(scenarioInfo);
#line 40
    testRunner.Given("I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, s" +
                    "ales, sales management, station owner, or access rrd user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 41
    testRunner.And("I am on the Customer Invoices page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 42
 testRunner.And("I have Custom Report that includes <DayPastDueReportTesting> criteria", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 43
    testRunner.When("I Select the Custome Report <DayPastDueReportTesting> from the existing list", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 44
 testRunner.Then("the grid should display invoices with the DaysPastDue equal to or greater than th" +
                    "e value entered in the DaysPastDue field in the existing Report Criteria", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
