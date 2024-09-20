using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRM.UITest.CommonMethods;

namespace CRM.UITest.Scripts.Maintenance_Tools.Master_Carrier_Rate_Settings
{
    [Binding]
    public class MasterCarrierRateSettings_MinimumFieldValueTypeSteps : MaintenaceTools
    {
        BumpSurgeAllStationsDisplay bumpSurgeAllStationsDisplay = new BumpSurgeAllStationsDisplay();

        [When(@"I have selected any Customer from Master carrier Rate settings page(.*)")]
        public void WhenIHaveSelectedAnyCustomerFromMasterCarrierRateSettingsPage(string CustomerName)
        {
            bumpSurgeAllStationsDisplay.NavigateTo_MasterCarrierRateSettingsPage();
            bumpSurgeAllStationsDisplay.SelectCustomerFromDropdown_MasterCarrierRateSettingsPage(CustomerName);

        }
        
        [Then(@"the value type for the Minimum field will be defaulted to Percentage")]
        public void ThenTheValueTypeForTheMinimumFieldWillBeDefaultedToPercentage()
        {
            Report.WriteLine("Verification of percentage symbol for Minimum Field value type");
            string ActualMinimumFieldValue_Type = GetAttribute(attributeName_id, "Gainsharevalue", "value");
            Assert.AreEqual("%", ActualMinimumFieldValue_Type);
        }

        [Then(@"I don't have option to select another value type from the Minimum field")]
        public void ThenIDonTHaveOptionToSelectAnotherValueTypeFromTheMinimumField()
        {

            Report.WriteLine("Minimum field Value type is disabled and hence not able to do change values");
            string iSMinimumFieldValueTypeDisabled = GetAttribute(attributeName_id, "Gainsharevalue", "disabled");
            Assert.AreEqual("true", iSMinimumFieldValueTypeDisabled);

        }
    }
}
