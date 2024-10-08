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
namespace CRM.UITest.Scripts.Quote.LTL.QuoteResultsScreen
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.2.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class RateRequest_ViewTC_EvidenceOfInsuranceLinkFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "Rate Request - View TC - Evidence of Insurance Link.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Rate Request - View TC - Evidence of Insurance Link", null, ProgrammingLanguage.CSharp, new string[] {
                        "34397",
                        "Sprint76"});
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "Rate Request - View TC - Evidence of Insurance Link")))
            {
                global::CRM.UITest.Scripts.Quote.LTL.QuoteResultsScreen.RateRequest_ViewTC_EvidenceOfInsuranceLinkFeature.FeatureSetup(null);
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
        
        public virtual void VerifyTheEvidenceOfInsuranceLink_TermsAndConditionsOfCoverage_GetQuoteLTLPage(string scenario, string userName, string password, string service, string userType, string customerName, string insuredvalue, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "RegressionSuite"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify the Evidence of Insurance Link_TermsAndConditions of Coverage_Get Quote (L" +
                    "TL) page", @__tags);
#line 5
this.ScenarioSetup(scenarioInfo);
#line 6
testRunner.Given(string.Format("I am a DLS user and login into application with valid {0} and {1}", userName, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 7
testRunner.When(string.Format("I am on Get Quote (LTL) page {0},{1},{2}", service, userType, customerName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 8
testRunner.And(string.Format("I have entered an {0} on the Get Quote (LTL) page", insuredvalue), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 9
testRunner.And("I am on Terms & Conditions of Coverage", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
testRunner.Then("I will be presented with an option to download the \'Evidence of Insurance\' form", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify the Evidence of Insurance Link_TermsAndConditions of Coverage_Get Quote (L" +
            "TL) page: s1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Rate Request - View TC - Evidence of Insurance Link")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("34397")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint76")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RegressionSuite")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "s1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Scenario", "s1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:userName", "zzzext")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:password", "Te$t1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Service", "LTL")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:UserType", "External")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:CustomerName", "ZZZ - Czar Customer Test")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Insuredvalue", "100")]
        public virtual void VerifyTheEvidenceOfInsuranceLink_TermsAndConditionsOfCoverage_GetQuoteLTLPage_S1()
        {
#line 5
this.VerifyTheEvidenceOfInsuranceLink_TermsAndConditionsOfCoverage_GetQuoteLTLPage("s1", "zzzext", "Te$t1234", "LTL", "External", "ZZZ - Czar Customer Test", "100", ((string[])(null)));
#line hidden
        }
        
        public virtual void VerifyTheEvidenceOfInsuranceLink_TermsAndConditionsOfCoverage_QuoteResultsPage(
                    string scenario, 
                    string userName, 
                    string password, 
                    string customerName, 
                    string service, 
                    string originCity, 
                    string originZip, 
                    string originState, 
                    string originCountry, 
                    string destinationCity, 
                    string destinationZip, 
                    string destinationState, 
                    string destinationCountry, 
                    string oAccessorial, 
                    string dAccessorial, 
                    string classification, 
                    string quantity, 
                    string quantityUNIT, 
                    string weight, 
                    string text, 
                    string enterInsuredValue, 
                    string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "RegressionSuite"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify the Evidence of Insurance Link_TermsAndConditions of Coverage_Quote result" +
                    "s page", @__tags);
#line 17
this.ScenarioSetup(scenarioInfo);
#line 18
testRunner.Given(string.Format("I am a DLS user and login into application with valid {0} and {1}", userName, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 19
testRunner.When(string.Format("I am on the quotes results page{0},{1},{2},{3},{4},{5},{6},{7},{8},<UserType>,<in" +
                        "suredvalue>", customerName, service, originZip, destinationZip, oAccessorial, dAccessorial, classification, quantity, weight), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 20
testRunner.And(string.Format("I entered {0} on results page", enterInsuredValue), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
testRunner.And("I am on Terms & Conditions of Coverage modal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
testRunner.Then("I will be presented with an option to download the \'Evidence of Insurance\' form", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify the Evidence of Insurance Link_TermsAndConditions of Coverage_Quote result" +
            "s page: s1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Rate Request - View TC - Evidence of Insurance Link")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("34397")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint76")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RegressionSuite")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "s1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Scenario", "s1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:userName", "zzzext")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:CustomerName", "ZZZ - Czar Customer Test")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Service", "COD")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:OriginCity", "Miami")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:OriginZip", "33126")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:OriginState", "FL")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:OriginCountry", "USA")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DestinationCity", "Tempe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DestinationZip", "85282")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DestinationState", "AZ")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DestinationCountry", "USA")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:OAccessorial", "")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DAccessorial", "COD")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Classification", "50")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Quantity", "1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:QuantityUNIT", "SKD")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Weight", "3")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:text", "No insured pricing for this carrier.")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:EnterInsuredValue", "1000")]
        public virtual void VerifyTheEvidenceOfInsuranceLink_TermsAndConditionsOfCoverage_QuoteResultsPage_S1()
        {
#line 17
this.VerifyTheEvidenceOfInsuranceLink_TermsAndConditionsOfCoverage_QuoteResultsPage("s1", "zzzext", "Te$t1234", "ZZZ - Czar Customer Test", "COD", "Miami", "33126", "FL", "USA", "Tempe", "85282", "AZ", "USA", "", "COD", "50", "1", "SKD", "3", "No insured pricing for this carrier.", "1000", ((string[])(null)));
#line hidden
        }
        
        public virtual void VerifyTheEvidenceOfInsuranceLink_TermsAndConditionsOfCoverage_QuoteResultsPage_HaveInsuredvalueOnInformationPage(
                    string scenario, 
                    string userName, 
                    string password, 
                    string customerName, 
                    string service, 
                    string originCity, 
                    string originZip, 
                    string originState, 
                    string originCountry, 
                    string destinationCity, 
                    string destinationZip, 
                    string destinationState, 
                    string destinationCountry, 
                    string oAccessorial, 
                    string dAccessorial, 
                    string classification, 
                    string quantity, 
                    string quantityUNIT, 
                    string weight, 
                    string text, 
                    string insuredvalue, 
                    string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "RegressionSuite"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify the Evidence of Insurance Link_TermsAndConditions of Coverage_Quote result" +
                    "s page_have Insuredvalue on information page", @__tags);
#line 31
this.ScenarioSetup(scenarioInfo);
#line 32
testRunner.Given(string.Format("I am a DLS user and login into application with valid {0} and {1}", userName, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 33
testRunner.When(string.Format("I am on the quotes results page{0},{1},{2},{3},{4},{5},{6},{7},{8},<UserType>,{9}" +
                        "", customerName, service, originZip, destinationZip, oAccessorial, dAccessorial, classification, quantity, weight, insuredvalue), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 34
testRunner.And("I am on Terms & Conditions of Coverage modal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 35
testRunner.Then("I will be presented with an option to download the \'Evidence of Insurance\' form", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify the Evidence of Insurance Link_TermsAndConditions of Coverage_Quote result" +
            "s page_have Insuredvalue on information page: s1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Rate Request - View TC - Evidence of Insurance Link")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("34397")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint76")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RegressionSuite")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "s1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Scenario", "s1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:userName", "zzzext")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:CustomerName", "ZZZ - Czar Customer Test")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Service", "COD")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:OriginCity", "Miami")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:OriginZip", "33126")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:OriginState", "FL")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:OriginCountry", "USA")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DestinationCity", "Tempe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DestinationZip", "85282")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DestinationState", "AZ")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DestinationCountry", "USA")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:OAccessorial", "")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DAccessorial", "COD")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Classification", "50")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Quantity", "1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:QuantityUNIT", "SKD")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Weight", "3")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:text", "No insured pricing for this carrier.")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:insuredvalue", "100")]
        public virtual void VerifyTheEvidenceOfInsuranceLink_TermsAndConditionsOfCoverage_QuoteResultsPage_HaveInsuredvalueOnInformationPage_S1()
        {
#line 31
this.VerifyTheEvidenceOfInsuranceLink_TermsAndConditionsOfCoverage_QuoteResultsPage_HaveInsuredvalueOnInformationPage("s1", "zzzext", "Te$t1234", "ZZZ - Czar Customer Test", "COD", "Miami", "33126", "FL", "USA", "Tempe", "85282", "AZ", "USA", "", "COD", "50", "1", "SKD", "3", "No insured pricing for this carrier.", "100", ((string[])(null)));
#line hidden
        }
    }
}
#pragma warning restore
#endregion
