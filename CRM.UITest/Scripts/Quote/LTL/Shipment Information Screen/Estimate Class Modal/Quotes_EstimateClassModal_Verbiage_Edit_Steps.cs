using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Quote.LTL
{
	[Binding]
	public sealed class Quotes_EstimateClassModal_Verbiage_Edit_Steps : ObjectRepository
	{

		[Then(@"I will be able to see Estimated class modal (.*)")]
		public void ThenIWillBeAbleToSeeEstimatedClassModal(string Estimated_Classs_Modal)
		{
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Verifying Estimated class modal");
            string ActualExtimatedModalText = Gettext(attributeName_xpath,LTL_EstimateClassModal_Verbiage_Xpath);   
            Assert.AreEqual(Estimated_Classs_Modal, ActualExtimatedModalText);
		}


		[Then(@"I will be able to see verbiage under Estimated Class header (.*)")]
		public void ThenIWillBeAbleToSeeVerbiageUnderEstimatedClassHeader(string Estimated_Classs_Modal_Verbiage)
		{
			Report.WriteLine("Verifying verbiage under Estimated Class header");
			string ActualExtimatedModalText = Gettext(attributeName_xpath, LTL_EstimateClass_Verbiage_Xpath);
			Assert.AreEqual(Estimated_Classs_Modal_Verbiage, ActualExtimatedModalText);
		}



		[Then(@"I will be able to see all fields within Estimated Class Modal (.*),(.*),(.*),(.*),(.*),(.*)")]
		public void ThenIWillBeAbleToSeeAllFieldsWithinEstimatedClassModal(string Length, string Width, string Height, string Weight, string Quantity, string ESTIMATED_CLASS)
		{
			Report.WriteLine("Verifying all fields verbiage within Estimated Class Modal");

			Verifytext(attributeName_xpath, LTL_EstimateClass_Length_Verbiage_Xpath, Length);
			Verifytext(attributeName_xpath, LTL_EstimateClass_Width_Verbiage_Xpath, Width);
			Verifytext(attributeName_xpath, LTL_EstimateClass_Height_Verbiage_Xpath, Height);
			Verifytext(attributeName_xpath, LTL_EstimateClass_Weight_Verbiage_Xpath, Weight);
			Verifytext(attributeName_xpath, LTL_EstimateClass_Quantity_Verbiage_Xpath, Quantity);
			Verifytext(attributeName_id, LTL_EstimateClass_CalculatedClass_Verbiage_Id, ESTIMATED_CLASS);
		}


		[Then(@"I will Density verbiage above the Density calculation field (.*)")]
		public void ThenIWillDensityVerbiageAboveTheDensityCalculationField(string Density)
		{
			Report.WriteLine("Verifying Density verbiage above the Density calculation field");
			string ActualDensityText = Gettext(attributeName_xpath, LTL_EstimateClass_Density_Verbiage_Xpath);
			Assert.AreEqual(Density, ActualDensityText);
			//Verifytext(attributeName_xpath, LTL_EstimateClass_Density_Verbiage_Xpath, Density);
		}


		[Then(@"I will be able to see Density verbiage above the Density Class Table (.*),(.*)")]
		public void ThenIWillBeAbleToSeeDensityVerbiageAboveTheDensityClassTable(string Density_table, string Class)
		{
			Report.WriteLine("Verifying  Density verbiage above the Density Class Table");
			string ActualDensity_tableText = Gettext(attributeName_xpath, LTL_EstimateClass_DensityTable_Verbiage_Xpath);
			Assert.AreEqual(Density_table, ActualDensity_tableText);
			string ActualClassText = Gettext(attributeName_xpath, LTL_EstimateClass_DensityTable_ClassVerbiage_Xpath);
			Assert.AreEqual(Class, ActualClassText);
		}

		[Then(@"I will be able to see the Estimated class Commodity Table Verbiage '(.*)'")]
		public void ThenIWillBeAbleToSeeTheEstimatedClassCommodityTableVerbiage(string Estimated_Classs_Commodity_Table)
		{
			Report.WriteLine("Verifying  Estimated Class Commodity Table verbiage above the Density Class Table");
			string ActualDensity_tableText = Gettext(attributeName_xpath, LTL_EstimatedClass_CommodityClassTable_Verbiage_xpath);
			Assert.AreEqual(Estimated_Classs_Commodity_Table, ActualDensity_tableText);
		}

		[When(@"I click on the Density calculator Icon")]
		public void WhenIClickOnTheDensityCalculatorIcon()
		{
			Report.WriteLine("Click on Density Calculator icon");
			Click(attributeName_id, LTL_EstimateClassButton_Id);
			//WaitForElementVisible(attributeName_xpath, LTL_EstimateClass_HeaderText_Xpath, "Estimate Class Lookup");
		}
	}
}
