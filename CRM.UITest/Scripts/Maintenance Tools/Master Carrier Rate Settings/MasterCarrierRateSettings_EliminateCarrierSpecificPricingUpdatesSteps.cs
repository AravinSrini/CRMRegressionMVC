using System.Collections.Generic;
using System.Linq;
using System.Threading;
using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Maintenance_Tools.Master_Carrier_Rate_Settings
{
    [Binding]
    public class MasterCarrierRateSettings_EliminateCarrierSpecificPricingUpdatesSteps : MaintenaceTools
    {
        private List<GainShareScacCode> carrierValues = new List< GainShareScacCode>();
        private string customerName = string.Empty;
        private Dictionary<string, bool> selectedCarrierScacCodes = new Dictionary<string, bool>();
        public WebElementOperations objWebElementOperations = new WebElementOperations();

        [When(@"I update Surge value (.*)")]
        public void WhenIUpdateSurgeValue(string Surge)
        {
            Report.WriteLine("Updating Surge value");
            SendKeys(attributeName_xpath, SurgeValue_Textbox_Xpath, Surge.ToString());
            Click(attributeName_id, Surgebutton_Id);
            Thread.Sleep(10000);
        }

        [When(@"I update Bump value (.*)")]
        public void WhenIUpdateBumpValue(string Bump)
        {
            Report.WriteLine("Updating Bump value");
            SendKeys(attributeName_xpath, BumpValue_Textbox_Xpath, Bump.ToString());
            Click(attributeName_id, Bumpbutton_Id);
            Thread.Sleep(10000);
        }

        [When(@"I have selected one or more carriers from Master carrier Rate settings page (.*)")]
        public void WhenIHaveSelectedOneOrMoreCarriersFromMasterCarrierRateSettingsPage(string CustomerName)
        {
            Thread.Sleep(10000);
            Report.WriteLine("Verifying Carrier display on Master carrier rate settings page");
            IList<IWebElement> carriersUI = GlobalVariables.webDriver.FindElements(By.XPath(CarrierAllValues_Xpath));
            List<string> carriers = objWebElementOperations.GetListFromIWebElement(carriersUI);
            customerName = CustomerName;

            if (carriersUI.Count > 0)
            {
                Report.WriteLine("Selecting one or more carriers");

                for (int i = 0; i < carriers.Count; i++)
                {
                    if (i == 0)
                    {
                        Click(attributeName_xpath, FirstCarrierSelect_Xpath);
                    }
                    else if (i == 1)
                    {
                        Click(attributeName_xpath, SecondCarrierSelect_Xpath);
                    }
                    else
                    {
                        break;
                    }

                    //Set IsCarrierSpecifcGainshare
                    SetSelectedCarriersGainshareDetails(carriers[i]);
                }
            }
            else
            {
                Report.WriteLine("No Carriers Found");
            }
        }

        [Then(@"the carrier-specific pricing records are not created or updated for the customer")]
        public void ThenTheCarrier_SpecificPricingRecordsAreNotCreatedOrUpdatedForTheCustomer()
        {
            int setUpId = DBHelper.GetCustomerSetupId(customerName);
            int accountId = DBHelper.GetCustomerAccountId(setUpId);
            GainsharePricingModel customeGainshareValues = DBHelper.GetGainsharePricingDataByAID(accountId);
            int pricingModelId = customeGainshareValues.GainsharePricingModelId;

            if (selectedCarrierScacCodes != null && selectedCarrierScacCodes.Any())
            {
                foreach (var carrier in selectedCarrierScacCodes)
                {
                    string carrierScacCode = carrier.Key;
                    bool isCarrierSpecifcGainshare = carrier.Value;

                    //Get carrierSpecific gainshare pricing values
                    GainShareScacCode carrierSpecificValues = DBHelper.GetCarrierSpecificScacCode(pricingModelId, carrierScacCode);

                    if (isCarrierSpecifcGainshare)
                    {
                        GainShareScacCode expected = carrierValues?.Where(m => m.ScacCode == carrierScacCode)?.FirstOrDefault();

                        //Verify carrier specific Gainshare pricing records are not updated
                        Report.WriteLine("Verification that carrier specific Gainshare pricing records are not updated");
                        Assert.AreEqual(expected.ModifiedDate, carrierSpecificValues.ModifiedDate);
                    }
                    else
                    {
                        //Verify carrier specific Gainshare pricing records are not created
                        Report.WriteLine("Verification that carrier specific Gainshare pricing records are not created");
                        Assert.IsNull(carrierSpecificValues);
                    }
                }
            }
            else
            {
                Report.WriteLine("No Carriers Selected for Update");
            }
        }

        private void SetSelectedCarriersGainshareDetails(string carrierName)
        {
            if (!string.IsNullOrWhiteSpace(carrierName))
            {
                carrierName = carrierName.Trim();
                bool isCarrierSpecifcGainshare = false;
                InsuredRateCarrier insuredRateCarrier = DBHelper.GetCarrierScacCodeGivenCarrierName(carrierName);
                string carrierScacCode = insuredRateCarrier?.CarrierCode;
                int setUpId = DBHelper.GetCustomerSetupId(customerName);
                int accountId = DBHelper.GetCustomerAccountId(setUpId);
                GainsharePricingModel customeGainshareValues = DBHelper.GetGainsharePricingDataByAID(accountId);
                int pricingModelId = customeGainshareValues.GainsharePricingModelId;

                //Get carrierSpecific gainshare pricing values
               GainShareScacCode carrierDetails = DBHelper.GetCarrierSpecificScacCode(pricingModelId, carrierScacCode);

                //Check if the customer has carrier specific gainshare pricing record for the selected carrier
                if (carrierDetails != null)
                {
                    carrierValues.Add(carrierDetails);
                    isCarrierSpecifcGainshare = true;
                }

                //Set selected carrier details
                selectedCarrierScacCodes.Add(carrierScacCode, isCarrierSpecifcGainshare);
            }
        }
    }
}
