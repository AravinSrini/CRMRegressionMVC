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
namespace CRM.UITest.Scripts.TLRatingTool.QuoteConfirmationTL.QuoteConfirmationNotification
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class TruckloadRatingPage_QuoteConfirmationNotificationFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "Truckload Rating Page - Quote Confirmation Notification.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Truckload Rating Page - Quote Confirmation Notification", null, ProgrammingLanguage.CSharp, new string[] {
                        "24143",
                        "Sprint65"});
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "Truckload Rating Page - Quote Confirmation Notification")))
            {
                global::CRM.UITest.Scripts.TLRatingTool.QuoteConfirmationTL.QuoteConfirmationNotification.TruckloadRatingPage_QuoteConfirmationNotificationFeature.FeatureSetup(null);
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
        
        public virtual void VerifyExistenceOfConfirmationScreenOnClickingGetLiveQuoteButton(string username, string password, string originZipCode, string destinationZipCode, string weight, string getQuoteTitle, string pickupDate, string shipFrom, string shipTo, string frieghtDescription, string quantity, string weightTL, string quoteConfirmation, string insuredvalue, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "GUI",
                    "Regression"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify existence of confirmation screen on Clicking Get Live Quote button", @__tags);
#line 5
this.ScenarioSetup(scenarioInfo);
#line 6
testRunner.Given("I  login into application as StationOwner", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 7
testRunner.And("I clicked on Rating Tool icon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 8
testRunner.And(string.Format("I have entered required fields \'{0}\',\'{1}\',\'{2}\',\'{3}\' in TL Rating Tool Projecte" +
                        "d amount page", originZipCode, destinationZipCode, pickupDate, weight), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 9
testRunner.And("I have Clicked on Get Rate button in TL Rating Tool Projected amount page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
testRunner.And("I have clicked on Get Quote New button in rating tool page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
testRunner.When(string.Format("I have arrived on Get Quote (TL) \'{0}\' page", getQuoteTitle), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 12
testRunner.And(string.Format("I pass data to all the required fields \'{0}\',\'{1}\',\'{2}\',\'{3}\',\'{4}\',\'{5}\'", shipFrom, shipTo, frieghtDescription, quantity, weightTL, insuredvalue), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
testRunner.And("I have clicked on Get Live Quote button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
testRunner.Then(string.Format("I must be able to view a {0} screen for the quote submitted", quoteConfirmation), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify existence of confirmation screen on Clicking Get Live Quote button: Statio" +
            "nOwner")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Truckload Rating Page - Quote Confirmation Notification")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("24143")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint65")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "StationOwner")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "StationOwner")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:OriginZipCode", "90001")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DestinationZipCode", "90001")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Weight", "3000")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:GetQuoteTitle", "Get Quote (Truckload)")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:PickupDate", "0")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ShipFrom", "90001")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ShipTo", "90001")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:FrieghtDescription", "try")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Quantity", "2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:WeightTL", "3")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:QuoteConfirmation", "Get Live Quote")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Insuredvalue", "1000")]
        public virtual void VerifyExistenceOfConfirmationScreenOnClickingGetLiveQuoteButton_StationOwner()
        {
#line 5
this.VerifyExistenceOfConfirmationScreenOnClickingGetLiveQuoteButton("StationOwner", "", "90001", "90001", "3000", "Get Quote (Truckload)", "0", "90001", "90001", "try", "2", "3", "Get Live Quote", "1000", ((string[])(null)));
#line hidden
        }
        
        public virtual void VerifyTheFunctionalityOfOKButtonOnTheQuoteConfirmationScreen(
                    string scenario, 
                    string username, 
                    string password, 
                    string originZipCode, 
                    string destinationZipCode, 
                    string weight, 
                    string getQuoteTitle, 
                    string pickupDate, 
                    string shipFrom, 
                    string shipTo, 
                    string frieghtDescription, 
                    string quantity, 
                    string weightTL, 
                    string projectedAmount, 
                    string insuredvalue, 
                    string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Functional"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify the functionality of OK button on the Quote Confirmation screen", @__tags);
#line 22
this.ScenarioSetup(scenarioInfo);
#line 23
testRunner.Given(string.Format("I am a DLS user and login into application with valid {0} and {1}", username, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 24
testRunner.And("I clicked on Rating Tool icon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
testRunner.And(string.Format("I have entered required fields \'{0}\',\'{1}\',\'{2}\',\'{3}\' in TL Rating Tool Projecte" +
                        "d amount page", originZipCode, destinationZipCode, pickupDate, weight), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
testRunner.And("I have Clicked on Get Rate button in TL Rating Tool Projected amount page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
testRunner.And("I have clicked on Get Quote New button in rating tool page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 28
testRunner.When(string.Format("I have arrived on Get Quote (TL) \'{0}\' page", getQuoteTitle), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 29
testRunner.And(string.Format("I pass data to all the required fields \'{0}\',\'{1}\',\'{2}\',\'{3}\',\'{4}\',\'{5}\'", shipFrom, shipTo, frieghtDescription, quantity, weightTL, insuredvalue), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
testRunner.And("I have clicked on Get Live Quote button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 31
testRunner.Then("I must be able to view OK button on the Quote Confirmation screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 32
testRunner.And(string.Format("when I click on OK button i must be navigated back to TL Rating Tool {0} page.", projectedAmount), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify the functionality of OK button on the Quote Confirmation screen: S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Truckload Rating Page - Quote Confirmation Notification")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("24143")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint65")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Functional")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Scenario", "S1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "stationtest@rrd.com")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:OriginZipCode", "90001")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DestinationZipCode", "90001")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Weight", "3000")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:GetQuoteTitle", "Get Quote (Truckload)")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:PickupDate", "0")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ShipFrom", "90001")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ShipTo", "90001")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:FrieghtDescription", "TRY")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Quantity", "2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:WeightTL", "3")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ProjectedAmount", "Projected Amount")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Insuredvalue", "1000")]
        public virtual void VerifyTheFunctionalityOfOKButtonOnTheQuoteConfirmationScreen_S1()
        {
#line 22
this.VerifyTheFunctionalityOfOKButtonOnTheQuoteConfirmationScreen("S1", "stationtest@rrd.com", "Te$t1234", "90001", "90001", "3000", "Get Quote (Truckload)", "0", "90001", "90001", "TRY", "2", "3", "Projected Amount", "1000", ((string[])(null)));
#line hidden
        }
        
        public virtual void VerifyQuoteReferenceNumberFromQuoteConfirmationScreenWithDatabase(string username, string password, string originZipCode, string destinationZipCode, string weight, string getQuoteTitle, string pickupDate, string shipFrom, string shipTo, string frieghtDescription, string quantity, string weightTL, string insuredvalue, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Acceptance",
                    "DBVerification",
                    "Regression"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify Quote Reference number from Quote confirmation screen with database", @__tags);
#line 40
this.ScenarioSetup(scenarioInfo);
#line 41
testRunner.Given("I  login into application as StationOwner", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 42
testRunner.And("I clicked on Rating Tool icon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 43
testRunner.And(string.Format("I have entered required fields \'{0}\',\'{1}\',\'{2}\',\'{3}\' in TL Rating Tool Projecte" +
                        "d amount page", originZipCode, destinationZipCode, pickupDate, weight), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 44
testRunner.And("I have Clicked on Get Rate button in TL Rating Tool Projected amount page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 45
testRunner.And("I have clicked on Get Quote New button in rating tool page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 46
testRunner.When(string.Format("I have arrived on Get Quote (TL) \'{0}\' page", getQuoteTitle), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 47
testRunner.And(string.Format("I pass data to all the required fields \'{0}\',\'{1}\',\'{2}\',\'{3}\',\'{4}\',\'{5}\'", shipFrom, shipTo, frieghtDescription, quantity, weightTL, insuredvalue), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 48
testRunner.And("I have clicked on Get Live Quote button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 49
testRunner.Then("The Quote Reference number in the Quote Confirmation modal must match with the da" +
                    "tabase", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify Quote Reference number from Quote confirmation screen with database: Stati" +
            "onOwner")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Truckload Rating Page - Quote Confirmation Notification")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("24143")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint65")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Acceptance")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("DBVerification")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "StationOwner")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "StationOwner")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:OriginZipCode", "90001")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DestinationZipCode", "90001")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Weight", "3000")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:GetQuoteTitle", "Get Quote (Truckload)")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:PickupDate", "0")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ShipFrom", "90001")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:ShipTo", "90001")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:FrieghtDescription", "try")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Quantity", "2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:WeightTL", "4")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Insuredvalue", "1000")]
        public virtual void VerifyQuoteReferenceNumberFromQuoteConfirmationScreenWithDatabase_StationOwner()
        {
#line 40
this.VerifyQuoteReferenceNumberFromQuoteConfirmationScreenWithDatabase("StationOwner", "", "90001", "90001", "3000", "Get Quote (Truckload)", "0", "90001", "90001", "try", "2", "4", "1000", ((string[])(null)));
#line hidden
        }
        
        public virtual void VerifyWithoutEnteringAnyDatasInMandatoryFieldsAndTryToClickOnGetLiveQuoteButton(string username, string password, string originZipCode, string destinationZipCode, string weight, string pickupDate, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "GUI",
                    "Regression",
                    "25765"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify without entering any data\'s in Mandatory fields and try to click on GetLiv" +
                    "eQuote button", @__tags);
#line 56
this.ScenarioSetup(scenarioInfo);
#line 57
testRunner.Given("I  login into application as StationOwner", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 58
testRunner.And("I clicked on Rating Tool icon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 59
testRunner.When(string.Format("I enter required fields {0},{1},{2} in rating tool page", originZipCode, destinationZipCode, weight), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 60
testRunner.And(string.Format("I click on the calender to select the {0}", pickupDate), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 61
testRunner.And("Click on Get Rate button in rating tool page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 62
testRunner.And("I have click on Get Quote Now button in rating tool page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 63
testRunner.And("I have clicked on GetLiveQuote button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 64
testRunner.Then("background color of the origin zip code textbox should turn red and error message" +
                    " should be displayed in GetQuote(TL) page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 65
testRunner.And("background color of the destination zip code textbox should turn red and error me" +
                    "ssage should be displayed in GetQuote(TL) page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 66
testRunner.And("background color of the Item Description textbox should turn red highlighted", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 67
testRunner.And("background color of the Quantity textbox should turn red highlighted", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 68
testRunner.And("background color of the Weight textbox should turn red highlighted", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify without entering any data\'s in Mandatory fields and try to click on GetLiv" +
            "eQuote button: StationOwner")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Truckload Rating Page - Quote Confirmation Notification")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("24143")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Sprint65")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("GUI")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("25765")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "StationOwner")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Username", "StationOwner")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "Te$t1234")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:OriginZipCode", "90001")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DestinationZipCode", "90001")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Weight", "100")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:PickupDate", "0")]
        public virtual void VerifyWithoutEnteringAnyDatasInMandatoryFieldsAndTryToClickOnGetLiveQuoteButton_StationOwner()
        {
#line 56
this.VerifyWithoutEnteringAnyDatasInMandatoryFieldsAndTryToClickOnGetLiveQuoteButton("StationOwner", "Te$t1234", "90001", "90001", "100", "0", ((string[])(null)));
#line hidden
        }
    }
}
#pragma warning restore
#endregion
