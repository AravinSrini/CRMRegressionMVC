using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System.Threading;
using TechTalk.SpecFlow;
using System.Collections.Generic;

namespace CRM.UITest.Scripts.Quote.LTL
{
	[Binding]
	public class InsuredValue_LTLRateRequestSteps : ObjectRepository
	{
		[Then(@"I must be able to see the options New or Used in the Insured Type drop down")]
		public void ThenIMustBeAbleToSeeTheOptionsNewOrUsedInTheInsuredTypeDropDown()
		{
			Report.WriteLine("Verifying the drop down options New and Used");
			Click(attributeName_xpath, NewOrUsedDropdown);
			var InsuredValueDropdown = new List<string> { "New", "Used" };
			List<string> NewOrUsedUI = GetDropdownOptions(attributeName_xpath, InsuredValueTypeDropDown_Xpath, "li");
			CollectionAssert.AreEqual(InsuredValueDropdown, NewOrUsedUI);
		}

		[Then(@"the default value must be New")]
		public void ThenTheDefaultValueMustBeNew()
		{
			Verifytext(attributeName_xpath, InsuredValueDefault, "New");
		}

		[Then(@"I must be able to select an option New or Used")]
		public void ThenIMustBeAbleToSelectAnOptionNewOrUsed()
		{
			SelectDropdownValueFromList(attributeName_id, "Insvalue_chosen", "Used");
			Click(attributeName_xpath, NewOrUsedDropdown);
			SelectDropdownValueFromList(attributeName_id, "Insvalue_chosen", "New");
		}


		[Then(@"the Insured Type drop down must be disabled as Insured Value is not entered yet")]
		public void ThenTheInsuredTypeDropDownMustBeDisabledAsInsuredValueIsNotEnteredYet()
		{
			IsElementDisabled(attributeName_xpath, InsuredValueTypeDropDown_Xpath, "InsuredValueType");
		}
	}
}
