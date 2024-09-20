using CRM.UITest.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Maintenance_Tools.Master_Carrier_Rate_Settings
{
    [Binding]
    public class CarrierRateSettings_AddPricingButtonToMaintenanceTools_Steps : MaintenaceTools
    {
        [Then(@"I will have the option '(.*)' to configure Master Carrier Rate Settings")]
        public void ThenIWillHaveTheOptionToConfigureMasterCarrierRateSettings(string Pricing)
        {
            Verifytext(attributeName_id, Pricing_Button_Id, Pricing);
        }


        [Then(@"User should be navigated to the (.*) page")]
        public void ThenUserShouldBeNavigatedToThePage(string MasterCarrierRateSettings)
        {
            Verifytext(attributeName_xpath, MaterCarrierRateSettingsPage_Title_xpath, MasterCarrierRateSettings);
        }




    }
}
