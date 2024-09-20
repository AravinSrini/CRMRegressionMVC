using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;
using CRM.UITest.Objects;
using CRM.UITest.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using CRM.UITest.CommonMethods;

namespace CRM.UITest.Scripts.Quote.LTL.Quote_Results_Screen
{
    [Binding]
    public class InsuredValue_ExcludedCarrierS_QuotesSteps:ObjectRepository
    {
        [Then(@"insured Quote Cost, Save Insured Rate option,Create Insured Shipment option  will not be displayed for carriers which excluded from Insurance All Risk pricing")]
        public void ThenInsuredQuoteCostSaveInsuredRateOptionCreateInsuredShipmentOptionWillNotBeDisplayedForCarriersWhichExcludedFromInsuranceAllRiskPricing()
        {
            int carriersCount = GetCount(attributeName_xpath, Allcarriername_Xpath);
            if (carriersCount >= 1)
            {
               
                for (int i = 0; i < carriersCount-1; i++)
                {
                    int j = i + 1;
                    string text = ".//*[@id='Grid-Rate-List-Large-NonGuranteed']//tr[" + j + "]/td[1]/ul/li[1]";
                    string ltlCarrierName = Gettext(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-NonGuranteed']//tr[" + j + "]/td[1]/ul/li[1]");
                    bool val = DBHelper.IsInsuredCarrierExcluded(ltlCarrierName);
                    if (val == true)
                    {
                        Report.WriteLine("insured Quote Cost option  will not be displayed for carriers which excluded from Insurance All Risk pricing");
                        VerifyElementNotVisible(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-NonGuranteed']//tr[" + i + "]/td[5]/ul[1]", "insuredquotecost");
                        Report.WriteLine("Save Insured Rate option will not be displayed for carriers which excluded from Insurance All Risk pricing");
                        VerifyElementNotVisible(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-NonGuranteed']//tr[" + i + "]/td[5]/ul[2]", "saveinsuredrateoption");
                        Report.WriteLine("Create Insured Shipment will not be displayed for carriers which excluded from Insurance All Risk pricing");
                        VerifyElementNotVisible(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-NonGuranteed']//tr[" + i + "]/td[5]/button", "insuredshipmentbutton");
                    }
                }
            }            
        }

        [Then(@"I will be displayed with(.*) in insured rate column for excluded carriers")]
        public void ThenIWillBeDisplayedWithInInsuredRateColumnForExcludedCarriers(string text)
        {
            int carriersCount = GetCount(attributeName_xpath, Allcarriername_Xpath);
            if (carriersCount >= 1)
            {

                for (int i = 1; i < carriersCount; i++)
                {
                    Thread.Sleep(10000);
                    string ltlCarrierName = Gettext(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-NonGuranteed']//tr[" + i + "]/td[1]/ul/li[1]");
                    bool val = DBHelper.IsInsuredCarrierExcluded(ltlCarrierName);
                    if (val == true)
                    {
                        Report.WriteLine("IWillBeDisplayedWithTextInInsuredRateColumnForExcludedCarriers");
                        Verifytext(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-NonGuranteed']//tr[" + i + "]/td[5]/div/p", text);
                    }
                }
            }
        }

        [Then(@"insured Quote Cost, Save Insured Rate option,Create Insured Shipment option  will not be displayed for carriers which excluded from Insurance All Risk pricing in guaranteed grid")]
        public void ThenInsuredQuoteCostSaveInsuredRateOptionCreateInsuredShipmentOptionWillNotBeDisplayedForCarriersWhichExcludedFromInsuranceAllRiskPricingInGuaranteedGrid()
        {
            int carriersCount = GetCount(attributeName_xpath, AllcarriernameG_Xpath);
            if (carriersCount >= 1)
            {

                for (int i = 1; i < carriersCount; i++)
                {
                    string ltlCarrierName = Gettext(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-Guranteed']//tr[" + i + "]/td[1]/ul/li[1]");
                    bool val = DBHelper.IsInsuredCarrierExcluded(ltlCarrierName);
                    if (val == true)
                    {
                        MoveToElement(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-Guranteed']//tr[" + i + "]/td[5]/ul[1]");
                        Report.WriteLine("insured Quote Cost option  will not be displayed for carriers which excluded from Insurance All Risk pricing");
                        VerifyElementNotVisible(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-Guranteed']//tr[" + i + "]/td[5]/ul[1]", "insuredquotecost");
                        Report.WriteLine("Save Insured Rate option will not be displayed for carriers which excluded from Insurance All Risk pricing");
                        VerifyElementNotVisible(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-Guranteed']//tr[" + i + "]/td[5]/ul[2]", "saveinsuredrateoption");
                        Report.WriteLine("Create Insured Shipment will not be displayed for carriers which excluded from Insurance All Risk pricing");
                        VerifyElementNotVisible(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-Guranteed']//tr[" + i + "]/td[5]/button", "insuredshipmentbutton");
                    }
                }
            }
        }
        [Then(@"I will be displayed with(.*) in insured rate column for excluded carriers in guaranteed grid")]
        public void ThenIWillBeDisplayedWithInInsuredRateColumnForExcludedCarriersInGuaranteedGrid(string text)
        {

            int carriersCount = GetCount(attributeName_xpath, AllcarriernameG_Xpath);
            if (carriersCount >= 1)
            {
                for (int i = 0; i < carriersCount; i++)
                {
                    MoveToElement(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-Guranteed']//tr[1]/td[1]/ul/li[1]");
                    string ltlCarrierName = Gettext(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-Guranteed']//tr[" + i + "]/td[1]/ul/li[1]");
                    bool val = DBHelper.IsInsuredCarrierExcluded(ltlCarrierName);
                    if (val == true)
                    {
                        Report.WriteLine("IWillBeDisplayedWithTextInInsuredRateColumnForExcludedCarriers");
                        Verifytext(attributeName_xpath, Text_insuredratecolumn_excluded_Xpath, text);
                    }
                }
            }
        }

        [When(@"I entered (.*) on results page")]
        public void WhenIEnteredOnResultsPage(string EnterInsuredValue)
        {
            Report.WriteLine("Entering data in Enter Insured value text box");
            SendKeys(attributeName_xpath, ltlEnterInsuredValueTextbox_xpath, EnterInsuredValue);
            Click(attributeName_id, ltlShowInsuredRateBtn_id);
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_xpath, ltlEnterInsuredValueTextbox_xpath, EnterInsuredValue);
            Click(attributeName_xpath, ltlEnterInsuredValueTextbox_xpath);
            //Thread.Sleep(1000);
           
            Click(attributeName_xpath, ltlQuoteResultsheader_xpath);
            //Thread.Sleep(1000);
            GlobalVariables.webDriver.WaitForPageLoad();

        }

    }
}
