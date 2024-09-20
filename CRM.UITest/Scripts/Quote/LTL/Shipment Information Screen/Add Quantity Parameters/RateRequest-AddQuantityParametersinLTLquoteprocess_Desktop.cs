using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Quote.LTL
{
	[Binding]
	public class RateRequest_AddQuantityParametersinLTLquoteprocess_Desktop : ObjectRepository
	{
		// 18324: Rate Request - Add Quantity Parameters in LTL quote process

		[Then(@"I should be able to see quantity field in the  - Shipment Infomation page")]
		public void ThenIShouldBeAbleToSeeQuantityFieldInThe_ShipmentInfomationPage()
		{
			Report.WriteLine("Verify the existance of Quantity field in Get Quote (LTL) ");
			VerifyElementPresent(attributeName_id, LTL_Quantity_Id, "Quantity field");
		}

		[Then(@"Verify the skids is selected in the Quantity UOM drop down list")]
		public void ThenVerifyTheSkidsIsSelectedInTheQuantityUOMDropDownList()
		{
			Report.WriteLine("Verify the skids is default selected in Quantity UOM drop down list");
			Verifytext(attributeName_xpath, LTL_QuantityUnitField_Xpath, "Skids");
		}

		[When(@"I enter the '(.*)' other than positive integer value")]
		public void WhenIEnterTheOtherThanPositiveIntegerValue(int Positivevalue)
		{
			Report.WriteLine("Verify if i enterd the positive integer value");
			SendKeys(attributeName_id, LTL_Quantity_Id, Positivevalue.ToString());
			string ValueInUI = GetValue(attributeName_id, LTL_Quantity_Id, "value");
			Assert.AreEqual(Positivevalue.ToString(), ValueInUI);
		}

		[Then(@"Verify that quantity field should not accept any negative integer '(.*)'")]
		public void ThenVerifyThatQuantityFieldShouldNotAcceptAnyNegativeInteger(int Negativevalue)
		{
			Report.WriteLine("verify if i entered the negative value it won't accept");
			SendKeys(attributeName_id, LTL_Quantity_Id, Negativevalue.ToString());
			string removeNegative = Math.Abs(Negativevalue).ToString();
			string ValueInUI = GetValue(attributeName_id, LTL_Quantity_Id, "value");
			Assert.AreEqual(removeNegative, ValueInUI);
		}

		[When(@"I enter greater than six (.*) in quantity field")]
		public void WhenIEnterGreaterThanSixInQuantityField(int QuantityValue)
		{

			Report.WriteLine("I enter the value greater than 6 in Quantity field");
			SendKeys(attributeName_id, LTL_Quantity_Id, QuantityValue.ToString());
		}

		[When(@"I select '(.*)' from UOM dropdown field")]
		public void WhenISelectFromUOMDropdownField(string Quantityfield)
		{
			Report.WriteLine("I select the Quantity field from Drop Down list ");
			Click(attributeName_xpath, LTL_QuantityUnitField_Xpath);
			SelectDropdownValueFromList(attributeName_xpath, LTL_QuantityUOMoptions_Xpath, Quantityfield);
		}

		[Then(@"Verify the '(.*)' message for the quantity field")]
		public void ThenVerifyTheMessageForTheQuantityField(string warningmessage)
		{
			Report.WriteLine("Verify the warning message if i enter more than 6 value in Quantity for Skids or pallets");
			string ActualWarningMessageforexceedQuantity = Gettext(attributeName_xpath, LTL_QuantityFieldWarningMessage_Xpath);
			Assert.AreEqual(ActualWarningMessageforexceedQuantity, warningmessage);

		}

		[When(@"I click on saved item dropdown")]
		public void WhenIClickOnSavedItemDropdown()
		{
			Report.WriteLine("Click on select a saved item");
			Click(attributeName_id, LTL_SavedItemDropdown_Id);
		}

		[Then(@"selected quantity value should be populated in quanity fields")]
		public void ThenSelectedQuantityValueShouldBePopulatedInQuanityFields()
		{
			Report.WriteLine("Select quantity value populated in quantity field");
			Click(attributeName_id, LTL_SavedItemDropdown_Id);
			string text = Gettext(attributeName_xpath, LTL_SavedItemDropdownValues_Xpath);
			string ActualText = GetValue(attributeName_id, LTL_Quantity_Id, "value");
			ActualText.Contains(text);
		}

		[When(@"I click on  Quantity field dropdown")]
		public void WhenIClickOnQuantityFieldDropdown()
		{
			Report.WriteLine("clicking on Quantity field drop down");
			Click(attributeName_id, QuantityDropdown_id);
		}

		[Then(@"all the unit field '(.*)' should be displayed in quantity unit field dropdown list")]
		public void ThenAllTheUnitFieldShouldBeDisplayedInQuantityUnitFieldDropdownList(string options)
		{
			Report.WriteLine("All required fields should display in Quantity drop down");
			Click(attributeName_id, QuantityDropdown_id);
			List<string> QuantityDropdownValues_UI = GetDropdownValues(attributeName_id, QuantityDropdown_id, "li");
			List<string> QuantityOptions_Expected = new List<string>(options.Split(','));
			foreach (string Quantity in QuantityOptions_Expected)
			{
				if (QuantityDropdownValues_UI.Contains(Quantity))
				{
					Console.WriteLine(Quantity + "field is present in the dropdown");
				}
				else
				{
					Console.WriteLine("Matching not found for " + Quantity);
				}
			}
		}

		[When(@"I have entered qunatity (.*) and unit (.*)")]
		public void WhenIHaveEnteredQunatityAndUnit(string QunttutyValue, string Unit)
		{
			SendKeys(attributeName_id, LTL_Quantity_Id, QunttutyValue);
		}

		[Then(@"Verify the Quantity field '(.*)','(.*)','(.*)' in the confirmation page matches with entered quantity value")]
		public void ThenVerifyTheQuantityFieldInTheConfirmationPageMatchesWithEnteredQuantityValue(string QuantityFieldText, string QunttutyValue, string Unit)
		{
			if (QunttutyValue != "")
			{
				Thread.Sleep(2000);
				string FrightQuantityColumn_UI = Gettext(attributeName_xpath, LTL_QC_FrightQuantity_Xpath);
				Assert.AreEqual(QuantityFieldText, FrightQuantityColumn_UI);

				string FrightQuantityValue_UI = Gettext(attributeName_xpath, LTL_QC_FrightQuantityValue_Xpath).Trim();


				string QunttutyValue1 = QunttutyValue + " " + Unit;

				Assert.AreEqual(QunttutyValue1, FrightQuantityValue_UI);
			}
			else
			{
				string FrightQuantityColumn_UI = Gettext(attributeName_xpath, LTL_QC_FrightQuantity_Xpath);
				Assert.AreEqual(QuantityFieldText, FrightQuantityColumn_UI);

				string FrightQuantityValue_UI = Gettext(attributeName_xpath, LTL_QC_FrightQuantityValue_Xpath);
				QunttutyValue = "0";

				string QunttutyValue1 = QunttutyValue + " " + Unit;
				Assert.AreEqual(QunttutyValue1.Trim(), FrightQuantityValue_UI.Trim());
			}

		}

	}
}
