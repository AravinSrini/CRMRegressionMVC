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
namespace CRM.UITest.Scripts.Quote.LTL.ShipmentInformationScreen.GetQuoteLTLScreen
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.2.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class _50090_DensityCalculator_GetQuoteLTL_SaveDimsToQuoteRequestFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "Density_Calc_Save_Dims_To_Quote_Request.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "50090_Density Calculator - Get Quote (LTL) - Save Dims to Quote request", null, ProgrammingLanguage.CSharp, new string[] {
                        "50090",
                        "NinjaSprint29",
                        "Regression"});
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "50090_Density Calculator - Get Quote (LTL) - Save Dims to Quote request")))
            {
                global::CRM.UITest.Scripts.Quote.LTL.ShipmentInformationScreen.GetQuoteLTLScreen._50090_DensityCalculator_GetQuoteLTL_SaveDimsToQuoteRequestFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("50090_Verify_Values_For_Length_Width_And_Height_In_Estimated_Class_Lookup_Modal_A" +
            "re_Applied_To_Respective_Fields_On_Get_Quote_LTL_Page")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "50090_Density Calculator - Get Quote (LTL) - Save Dims to Quote request")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("50090")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("NinjaSprint29")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        public virtual void _50090_Verify_Values_For_Length_Width_And_Height_In_Estimated_Class_Lookup_Modal_Are_Applied_To_Respective_Fields_On_Get_Quote_LTL_Page()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("50090_Verify_Values_For_Length_Width_And_Height_In_Estimated_Class_Lookup_Modal_A" +
                    "re_Applied_To_Respective_Fields_On_Get_Quote_LTL_Page", ((string[])(null)));
#line 4
this.ScenarioSetup(scenarioInfo);
#line 5
testRunner.Given("I am a ship inquiry, ship entry, operations, sales, sales management, or station " +
                    "owner user with a valid \"username-CurrentsprintOperations\" \"password-Currentspri" +
                    "ntOperations\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 6
testRunner.And("I navigate to the Get Quote (LTL) Page for \"ZZZ - GS Customer Test\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 7
testRunner.And("I have opened the Estimated Class Lookup modal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 8
testRunner.And("I have entered the required information for Length, Width, Height, Weight, and Qu" +
                    "antity \"30\", \"20\", \"10\", \"100\", \"1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 9
testRunner.When("I click on the Apply Class Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
testRunner.Then("the Length value \"30.00\" will be applied to the Length field on the Get Quote (LT" +
                    "L) page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 11
testRunner.And("the Width value \"20.00\" will be applied to the Width field on the Get Quote (LTL)" +
                    " page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
testRunner.And("the Height value \"10.00\" will be applied to the Height field on the Get Quote (LT" +
                    "L) page.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("50090_Verify_Overlength_Service_Is_Selected_In_Get_Quote_Page_When_Length_In_Esti" +
            "mated_Class_Modal_Exceeds_95")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "50090_Density Calculator - Get Quote (LTL) - Save Dims to Quote request")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("50090")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("NinjaSprint29")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        public virtual void _50090_Verify_Overlength_Service_Is_Selected_In_Get_Quote_Page_When_Length_In_Estimated_Class_Modal_Exceeds_95()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("50090_Verify_Overlength_Service_Is_Selected_In_Get_Quote_Page_When_Length_In_Esti" +
                    "mated_Class_Modal_Exceeds_95", ((string[])(null)));
#line 14
this.ScenarioSetup(scenarioInfo);
#line 15
testRunner.Given("I am a ship inquiry, ship entry, operations, sales, sales management, or station " +
                    "owner user with a valid \"username-CurrentsprintOperations\" \"password-Currentspri" +
                    "ntOperations\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 16
testRunner.And("I navigate to the Get Quote (LTL) Page for \"ZZZ - GS Customer Test\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
testRunner.And("I have opened the Estimated Class Lookup modal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
testRunner.And("I have entered the required information for Length, Width, Height, Weight, and Qu" +
                    "antity \"96\", \"20\", \"10\", \"100\", \"1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
testRunner.When("I click on the Apply Class Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 20
testRunner.Then("Overlength service is added to the Click to add services & accessorials field on " +
                    "Get Quote (LTL) page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("50090_Verify_Values_For_Length_Width_And_Height_In_Estimated_Class_Lookup_Modal_A" +
            "re_Applied_To_Respective_Fields_On_Get_Quote_LTL_Page_Add_Additional_Item_Select" +
            "ed")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "50090_Density Calculator - Get Quote (LTL) - Save Dims to Quote request")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("50090")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("NinjaSprint29")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        public virtual void _50090_Verify_Values_For_Length_Width_And_Height_In_Estimated_Class_Lookup_Modal_Are_Applied_To_Respective_Fields_On_Get_Quote_LTL_Page_Add_Additional_Item_Selected()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("50090_Verify_Values_For_Length_Width_And_Height_In_Estimated_Class_Lookup_Modal_A" +
                    "re_Applied_To_Respective_Fields_On_Get_Quote_LTL_Page_Add_Additional_Item_Select" +
                    "ed", ((string[])(null)));
#line 22
this.ScenarioSetup(scenarioInfo);
#line 23
testRunner.Given("I am a ship inquiry, ship entry, operations, sales, sales management, or station " +
                    "owner user with a valid \"username-CurrentsprintOperations\" \"password-Currentspri" +
                    "ntOperations\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 24
testRunner.And("I navigate to the Get Quote (LTL) Page for \"ZZZ - GS Customer Test\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
testRunner.And("I click on the Add Additional Item Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
testRunner.And("I have opened the Estimated Class Lookup modal for the additional item", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
testRunner.And("I have entered the required information for Length, Width, Height, Weight, and Qu" +
                    "antity \"30\", \"20\", \"10\", \"100\", \"1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 28
testRunner.When("I click on the Apply Class Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 29
testRunner.Then("the Length value \"30.00\" will be applied to the Length field on the Get Quote (LT" +
                    "L) page for the additional item", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 30
testRunner.And("the Width value \"20.00\" will be applied to the Width field on the Get Quote (LTL)" +
                    " page for the additional item", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 31
testRunner.And("the Height value \"10.00\" will be applied to the Height field on the Get Quote (LT" +
                    "L) page for the additional item", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("50090_Verify_Overlength_Service_Is_Selected_In_Get_Quote_Page_When_Length_In_Esti" +
            "mated_Class_Modal_Exceeds_95_Add_Additional_Item_Selected")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "50090_Density Calculator - Get Quote (LTL) - Save Dims to Quote request")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("50090")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("NinjaSprint29")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Regression")]
        public virtual void _50090_Verify_Overlength_Service_Is_Selected_In_Get_Quote_Page_When_Length_In_Estimated_Class_Modal_Exceeds_95_Add_Additional_Item_Selected()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("50090_Verify_Overlength_Service_Is_Selected_In_Get_Quote_Page_When_Length_In_Esti" +
                    "mated_Class_Modal_Exceeds_95_Add_Additional_Item_Selected", ((string[])(null)));
#line 33
this.ScenarioSetup(scenarioInfo);
#line 34
testRunner.Given("I am a ship inquiry, ship entry, operations, sales, sales management, or station " +
                    "owner user with a valid \"username-CurrentsprintOperations\" \"password-Currentspri" +
                    "ntOperations\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 35
testRunner.And("I navigate to the Get Quote (LTL) Page for \"ZZZ - GS Customer Test\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 36
testRunner.And("I click on the Add Additional Item Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 37
testRunner.And("I have opened the Estimated Class Lookup modal for the additional item", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 38
testRunner.And("I have entered the required information for Length, Width, Height, Weight, and Qu" +
                    "antity \"96\", \"20\", \"10\", \"100\", \"1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 39
testRunner.When("I click on the Apply Class Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 40
testRunner.Then("Overlength service is added to the Click to add services & accessorials field on " +
                    "Get Quote (LTL) page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
