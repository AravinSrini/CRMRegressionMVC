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
namespace CRM.UITest.Scripts.Quote.LTL
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.2.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class QuoteLTL_AllRiskInsReminder_PPPAndStdCustomersFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "Quote (LTL)_All Risk Ins Reminder_PPP and Std Customers.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Quote (LTL)_All Risk Ins Reminder_PPP and Std Customers", null, ProgrammingLanguage.CSharp, new string[] {
                        "Sprint85",
                        "47690"});
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "Quote (LTL)_All Risk Ins Reminder_PPP and Std Customers")))
            {
                global::CRM.UITest.Scripts.Quote.LTL.QuoteLTL_AllRiskInsReminder_PPPAndStdCustomersFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("47690 - Verify the display of expected All Risk Ins Reminder for standard custome" +
            "rs on Get Quote(LTL) page")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Quote (LTL)_All Risk Ins Reminder_PPP and Std Customers")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint85")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("47690")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RegressionSuite")]
        public virtual void _47690_VerifyTheDisplayOfExpectedAllRiskInsReminderForStandardCustomersOnGetQuoteLTLPage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("47690 - Verify the display of expected All Risk Ins Reminder for standard custome" +
                    "rs on Get Quote(LTL) page", new string[] {
                        "RegressionSuite"});
#line 5
this.ScenarioSetup(scenarioInfo);
#line 6
 testRunner.Given("I am a shp.inquiry, shp.entry, sales, sales management, operations, or a station " +
                    "owner user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 7
 testRunner.And("The customer in which I am associated does not have a PPP all-risk insurance sett" +
                    "ing", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 8
 testRunner.And("I am submitting an LTL quote", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 9
 testRunner.And("I am on Get Quote (LTL) Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
 testRunner.When("I enter a value greater than $100,000 in the <Enter insured value...> field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 11
 testRunner.Then("I will receive a message: \'Error\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 12
 testRunner.And("The error message will read \'The entered shipment value exceeds $100,000. Please " +
                    "contact your DLS representative.\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("47690 - Verify the display of expected All Risk Ins Reminder for PPP customers on" +
            " Get Quote(LTL) page")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Quote (LTL)_All Risk Ins Reminder_PPP and Std Customers")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint85")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("47690")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RegressionSuite")]
        public virtual void _47690_VerifyTheDisplayOfExpectedAllRiskInsReminderForPPPCustomersOnGetQuoteLTLPage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("47690 - Verify the display of expected All Risk Ins Reminder for PPP customers on" +
                    " Get Quote(LTL) page", new string[] {
                        "RegressionSuite"});
#line 15
this.ScenarioSetup(scenarioInfo);
#line 16
 testRunner.Given("I am a shp.inquiry, shp.entry, sales, sales management, operations, or a station " +
                    "owner user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 17
 testRunner.And("I am associated to a customer with a PPP all-risk insurance setting", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
 testRunner.And("I am submitting an LTL quote", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
 testRunner.And("I am on Get Quote (LTL) Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
 testRunner.When("I enter a value greater than $15,000.00 in the <Enter insured value...>field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 21
 testRunner.Then("I will receive a message: \'Error\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 22
 testRunner.And("The error message will read \'The entered shipment value exceeds $15,000. Please c" +
                    "ontact your DLS representative.\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
 testRunner.And("I have the option to remove the message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
 testRunner.And("I am unable to <View Quote Results>", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("47690 - Verify the display of expected All Risk Ins Reminder for Standard custome" +
            "rs on Quote Results(LTL) page")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Quote (LTL)_All Risk Ins Reminder_PPP and Std Customers")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint85")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("47690")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RegressionSuite")]
        public virtual void _47690_VerifyTheDisplayOfExpectedAllRiskInsReminderForStandardCustomersOnQuoteResultsLTLPage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("47690 - Verify the display of expected All Risk Ins Reminder for Standard custome" +
                    "rs on Quote Results(LTL) page", new string[] {
                        "RegressionSuite"});
#line 27
this.ScenarioSetup(scenarioInfo);
#line 28
 testRunner.Given("I am a shp.inquiry, shp.entry, sales, sales management, operations, or a station " +
                    "owner user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 29
 testRunner.And("The customer in which I am associated does not have a PPP all-risk insurance sett" +
                    "ing", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
 testRunner.And("I am submitting an LTL quote", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 31
 testRunner.And("I am on Quote Results (LTL) page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
 testRunner.When("I enter value greater than $100,000 in the <Enter insured value:> field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 33
 testRunner.Then("I will receive a message:\'The entered shipment value exceeds $100,000. Please con" +
                    "tact your DLS representative.\' beneath insured value field of Quote results page" +
                    "", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("47690 - Verify the display of expected All Risk Ins Reminder for PPP customers on" +
            " Quote Results(LTL) page")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Quote (LTL)_All Risk Ins Reminder_PPP and Std Customers")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint85")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("47690")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RegressionSuite")]
        public virtual void _47690_VerifyTheDisplayOfExpectedAllRiskInsReminderForPPPCustomersOnQuoteResultsLTLPage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("47690 - Verify the display of expected All Risk Ins Reminder for PPP customers on" +
                    " Quote Results(LTL) page", new string[] {
                        "RegressionSuite"});
#line 36
this.ScenarioSetup(scenarioInfo);
#line 37
 testRunner.Given("I am a shp.inquiry, shp.entry, sales, sales management, operations, or a station " +
                    "owner user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 38
 testRunner.And("I am associated to a customer with a PPP all-risk insurance setting", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 39
 testRunner.And("I am submitting an LTL quote", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 40
 testRunner.And("I did not enter an insured value on the Get Quote (LTL) page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 41
 testRunner.And("I am on Quote Results (LTL) page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 42
 testRunner.When("I enter value greater than $15,000.00 in the <Enter insured value:>field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 43
 testRunner.Then("I will receive a message:\'The entered shipment value exceeds $15,000. Please cont" +
                    "act your DLS representative.\' beneath insured value field of Quote results page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("47690 - Verify the display of expected All Risk Ins Reminder for Standard custome" +
            "rs on Insured rates modal of Quote Results(LTL) page")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Quote (LTL)_All Risk Ins Reminder_PPP and Std Customers")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint85")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("47690")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RegressionSuite")]
        public virtual void _47690_VerifyTheDisplayOfExpectedAllRiskInsReminderForStandardCustomersOnInsuredRatesModalOfQuoteResultsLTLPage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("47690 - Verify the display of expected All Risk Ins Reminder for Standard custome" +
                    "rs on Insured rates modal of Quote Results(LTL) page", new string[] {
                        "RegressionSuite"});
#line 46
this.ScenarioSetup(scenarioInfo);
#line 47
 testRunner.Given("I am a shp.entry, sales, sales management, operations, or a stationowner user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 48
 testRunner.And("The customer in which I am associated does not have a PPP all-risk insurance sett" +
                    "ing", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 49
 testRunner.And("I am submitting an LTL quote", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 50
 testRunner.And("I am on Quote Results (LTL) page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 51
 testRunner.And("I did not enter a value on <Enter insured value:> field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 52
 testRunner.And("I clicked on <Create Shipment>button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
 testRunner.And("I entered value greater than $100,000.00 in the <Insured Value> field of the Insu" +
                    "red Rates modal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 54
 testRunner.When("I click on <Show Insured Rate>button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 55
 testRunner.Then("I will receive a message:\'The entered shipment value exceeds $100,000. Please con" +
                    "tact your DLS representative.\' beneath the Insured value field of modal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 56
 testRunner.And("I have the option to continue without insured rates.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("47690 - Verify the display of expected All Risk Ins Reminder for PPP customers on" +
            " Insured rates modal of Quote Results(LTL) page")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Quote (LTL)_All Risk Ins Reminder_PPP and Std Customers")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint85")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("47690")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RegressionSuite")]
        public virtual void _47690_VerifyTheDisplayOfExpectedAllRiskInsReminderForPPPCustomersOnInsuredRatesModalOfQuoteResultsLTLPage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("47690 - Verify the display of expected All Risk Ins Reminder for PPP customers on" +
                    " Insured rates modal of Quote Results(LTL) page", new string[] {
                        "RegressionSuite"});
#line 59
this.ScenarioSetup(scenarioInfo);
#line 60
 testRunner.Given("I am a shp.entry, sales, sales management, operations, or a stationowner user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 61
 testRunner.And("I am associated to a customer with a PPP all-risk insurance setting", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 62
 testRunner.And("I am submitting an LTL quote", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 63
 testRunner.And("I am on Quote Results (LTL) page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 64
 testRunner.And("I did not enter a value in the <Enter insured value:> field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 65
 testRunner.And("I clicked on <Create Shipment>button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 66
 testRunner.And("I entered value greater than $15,000.00 in the <Insured Value> field of the Insur" +
                    "ed rates modal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 67
 testRunner.When("I click on <Show Insured Rate>button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 68
 testRunner.Then("I will receive a message:\'The entered shipment value exceeds $15,000. Please cont" +
                    "act your DLS representative.\' beneath the Insured value field of modal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 69
 testRunner.And("I have the option to continue without insured rates.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("47690 - Verify if All Risk Ins Reminder is displayed when user passes less than t" +
            "he expected insured value for PPP customers on Get Quote(LTL) page")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Quote (LTL)_All Risk Ins Reminder_PPP and Std Customers")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint85")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("47690")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RegressionSuite")]
        public virtual void _47690_VerifyIfAllRiskInsReminderIsDisplayedWhenUserPassesLessThanTheExpectedInsuredValueForPPPCustomersOnGetQuoteLTLPage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("47690 - Verify if All Risk Ins Reminder is displayed when user passes less than t" +
                    "he expected insured value for PPP customers on Get Quote(LTL) page", new string[] {
                        "RegressionSuite"});
#line 72
this.ScenarioSetup(scenarioInfo);
#line 73
 testRunner.Given("I am a shp.entry, sales, sales management, operations, or station owner user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 74
 testRunner.And("I am associated to a customer with a PPP all-risk insurance setting", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 75
 testRunner.And("I am submitting an LTL quote", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 76
 testRunner.And("I am on Get Quote (LTL) Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 77
 testRunner.When("I enter a value less than $15,000.00 in the <Enter insured value...>field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 78
 testRunner.Then("All Risk Ins Reminder message will not be displayed on Get Quote (LTL) page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("47690 - Verify if All Risk Ins Reminder is displayed when user passes a value equ" +
            "al to the expected insured value for PPP customers on Get Quote(LTL) page")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Quote (LTL)_All Risk Ins Reminder_PPP and Std Customers")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint85")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("47690")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RegressionSuite")]
        public virtual void _47690_VerifyIfAllRiskInsReminderIsDisplayedWhenUserPassesAValueEqualToTheExpectedInsuredValueForPPPCustomersOnGetQuoteLTLPage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("47690 - Verify if All Risk Ins Reminder is displayed when user passes a value equ" +
                    "al to the expected insured value for PPP customers on Get Quote(LTL) page", new string[] {
                        "RegressionSuite"});
#line 81
this.ScenarioSetup(scenarioInfo);
#line 82
 testRunner.Given("I am a shp.entry, sales, sales management, operations, or station owner user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 83
 testRunner.And("I am associated to a customer with a PPP all-risk insurance setting", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 84
 testRunner.And("I am submitting an LTL quote", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 85
 testRunner.And("I am on Get Quote (LTL) Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 86
 testRunner.When("I enter a value equal to $15,000.00 in <Enter insured value...>field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 87
 testRunner.Then("All Risk Ins Reminder message will not be displayed on Get Quote (LTL) page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("47690 - Verify if All Risk Ins Reminder is displayed when user passes less than t" +
            "he expected insured value for PPP customers on Quote Results page")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Quote (LTL)_All Risk Ins Reminder_PPP and Std Customers")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint85")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("47690")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RegressionSuite")]
        public virtual void _47690_VerifyIfAllRiskInsReminderIsDisplayedWhenUserPassesLessThanTheExpectedInsuredValueForPPPCustomersOnQuoteResultsPage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("47690 - Verify if All Risk Ins Reminder is displayed when user passes less than t" +
                    "he expected insured value for PPP customers on Quote Results page", new string[] {
                        "RegressionSuite"});
#line 90
this.ScenarioSetup(scenarioInfo);
#line 91
 testRunner.Given("I am a shp.entry, sales, sales management, operations, or station owner user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 92
 testRunner.And("I am associated to a customer with a PPP all-risk insurance setting", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 93
 testRunner.And("I am submitting an LTL quote", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 94
 testRunner.And("I am on Quote Results (LTL) page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 95
 testRunner.When("I enter a value less than $15,000.00 on <Enter insured value...>field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 96
 testRunner.Then("All Risk Ins Reminder message will not be displayed on Quote results page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("47690 - Verify if All Risk Ins Reminder is displayed when user passes a value equ" +
            "al to the expected insured value for PPP customers on Quote Results page")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Quote (LTL)_All Risk Ins Reminder_PPP and Std Customers")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint85")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("47690")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RegressionSuite")]
        public virtual void _47690_VerifyIfAllRiskInsReminderIsDisplayedWhenUserPassesAValueEqualToTheExpectedInsuredValueForPPPCustomersOnQuoteResultsPage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("47690 - Verify if All Risk Ins Reminder is displayed when user passes a value equ" +
                    "al to the expected insured value for PPP customers on Quote Results page", new string[] {
                        "RegressionSuite"});
#line 99
this.ScenarioSetup(scenarioInfo);
#line 100
 testRunner.Given("I am a shp.entry, sales, sales management, operations, or station owner user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 101
 testRunner.And("I am associated to a customer with a PPP all-risk insurance setting", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 102
 testRunner.And("I am submitting an LTL quote", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 103
 testRunner.And("I am on Quote Results (LTL) page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 104
 testRunner.When("I enter a value equal to $15,000.00 on the <Enter insured value...>field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 105
 testRunner.Then("All Risk Ins Reminder message will not be displayed on Quote results page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("47690 - Verify if All Risk Ins Reminder is displayed when user passes less than t" +
            "he expected insured value for PPP customers on Insured rates modal")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Quote (LTL)_All Risk Ins Reminder_PPP and Std Customers")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint85")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("47690")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RegressionSuite")]
        public virtual void _47690_VerifyIfAllRiskInsReminderIsDisplayedWhenUserPassesLessThanTheExpectedInsuredValueForPPPCustomersOnInsuredRatesModal()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("47690 - Verify if All Risk Ins Reminder is displayed when user passes less than t" +
                    "he expected insured value for PPP customers on Insured rates modal", new string[] {
                        "RegressionSuite"});
#line 108
this.ScenarioSetup(scenarioInfo);
#line 109
 testRunner.Given("I am a shp.entry, sales, sales management, operations, or a stationowner user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 110
 testRunner.And("I am associated to a customer with a PPP all-risk insurance setting", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 111
 testRunner.And("I am submitting an LTL quote", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 112
 testRunner.And("I am on Quote Results (LTL) page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 113
 testRunner.When("I enter value less than $15,000.00 in the <Enter insured value...>field of Insure" +
                    "d Rates modal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 114
 testRunner.Then("All Risk Ins Reminder message will not be displayed on Insured Rates modal of Quo" +
                    "te Results page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("47690 - Verify if All Risk Ins Reminder is displayed when user passes a value equ" +
            "al to the expected insured value for PPP customers on Insured rates modal")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Quote (LTL)_All Risk Ins Reminder_PPP and Std Customers")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint85")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("47690")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RegressionSuite")]
        public virtual void _47690_VerifyIfAllRiskInsReminderIsDisplayedWhenUserPassesAValueEqualToTheExpectedInsuredValueForPPPCustomersOnInsuredRatesModal()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("47690 - Verify if All Risk Ins Reminder is displayed when user passes a value equ" +
                    "al to the expected insured value for PPP customers on Insured rates modal", new string[] {
                        "RegressionSuite"});
#line 117
this.ScenarioSetup(scenarioInfo);
#line 118
 testRunner.Given("I am a shp.entry, sales, sales management, operations, or a stationowner user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 119
 testRunner.And("I am associated to a customer with a PPP all-risk insurance setting", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 120
 testRunner.And("I am submitting an LTL quote", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 121
 testRunner.And("I am on Quote Results (LTL) page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 122
 testRunner.When("I enter a value equal to $15,000.00 in <Enter insured value...>field of Insured R" +
                    "ates modal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 123
 testRunner.Then("All Risk Ins Reminder message will not be displayed on Insured Rates modal of Quo" +
                    "te Results page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
