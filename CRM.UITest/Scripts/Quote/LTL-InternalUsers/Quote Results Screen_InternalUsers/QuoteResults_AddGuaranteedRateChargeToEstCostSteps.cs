using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Threading;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Helper;
using CRM.UITest.Helper.ViewModel;
using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;

namespace CRM.UITest.Scripts.Quote.LTL_InternalUsers.Quote_Results_Screen_InternalUsers
{
    [Binding]
    public class QuoteResults_AddGuaranteedRateChargeToEstCostSteps : Quotelist
    {
        string Account = "";
        string Service = "LTL";
        string OriginCity = "";
        string OriginZip = "";
        string OriginState = "";
        string OriginCountry = "";
        string DestinationCity = "";
        string DestinationZip = "";
        string DestinationState = "";
        string DestinationCountry = "";
        string Classification = "";
        double Quantity = 1;
        string QuantityUNIT = "";
        double Weight = 1;
        string WeightUnit = "";
        string Username = "";
        public WebElementOperations objWebElementOperations = new WebElementOperations();
     
        [Given(@"I have selected the (.*) from customer dropdown list")]
        public void GivenIHaveSelectedTheFromCustomerDropdownList(string Customer_Name)
        {
            //
            Account = Customer_Name;
            Report.WriteLine("Select Customer Name from the dropdown list");
            Click(attributeName_xpath, QuoteList_CustomerDropdown_Label_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_xpath, ".//*[@id='CategoryType_chosen']/div/div/input", Customer_Name);
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_CustomerDropdownList_Xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == Customer_Name)
                {
                    DropDownList[i].Click();
                    break;
                }
            }
        }

        [When(@"I enter data in Origin section (.*), (.*) and (.*), (.*)")]
        public void WhenIEnterDataInOriginSectionAnd(string Zip, string City, string State, string Country)
        {
            OriginCity = City;
            OriginZip = Zip;
            OriginState = State;
            OriginCountry = Country;
            Report.WriteLine("Clearing if any default Address present in Origin section");
            Thread.Sleep(1000);
            string _selectedAddress = GetValue(attributeName_id, LTL_SavedOriginAddressDropdown_Id, "value");

            if (_selectedAddress != "" || _selectedAddress != string.Empty)
            {
                Click(attributeName_id, ClearAddress_OriginId);
                Thread.Sleep(4000);
            }
            Report.WriteLine("Entering data in origin section");
            SendKeys(attributeName_id, LTL_OriginCity_Id, City);
            Click(attributeName_id, LTL_OriginStateProvince_Id);
            SelectDropdownValueFromList(attributeName_xpath, LTL_OriginStateProvinceValues_Xpath, State);
            SendKeys(attributeName_id, LTL_OriginZipPostal_Id, Zip);
        }

        [When(@"I enter data in Destination section (.*), (.*) and (.*),(.*)")]
        public void WhenIEnterDataInDestinationSectionAnd(string Zip, string City, string State, string Country)
        {
            DestinationCity = City;
            DestinationZip = Zip;
            DestinationState = State;
            DestinationCountry = Country;
            Report.WriteLine("Clearing if any default Address present in Destination section");
            string _selectedAddress = GetValue(attributeName_id, LTL_SavedDestinationAddressDropdown_Id, "value");

            if (_selectedAddress != "" || _selectedAddress != string.Empty)
            {
                Click(attributeName_id, ClearAddress_DestId);
                Thread.Sleep(3000);
            }
            Report.WriteLine("Entering data in destination section");
            SendKeys(attributeName_id, LTL_DestinationCity_Id, City);
            Click(attributeName_id, LTL_DestinationStateProvince_Id);
            SelectDropdownValueFromList(attributeName_xpath, LTL_DestinationStateProvinceValues_Xpath, State);
            SendKeys(attributeName_id, LTL_DestinationZipPostal_Id, Zip);
            Click(attributeName_id, LTL_DestinationCity_Id);
            Thread.Sleep(2000);
        }

        [When(@"I enter data in Item information section (.*), (.*), (.*), (.*), (.*)")]
        public void WhenIEnterDataInItemInformationSection(string classification, string weight, string weightUnit, string quantity, string quantityUNIT)
        {
            Classification = classification;
            Weight = Convert.ToDouble(weight);
            WeightUnit = weightUnit;
            Quantity = Convert.ToDouble(quantity);
            QuantityUNIT = quantityUNIT;
            Report.WriteLine("Enter details in item section");
            Click(attributeName_id, LTL_Weight_Id);
            Click(attributeName_id, LTL_Classification_Id);
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='scrollable-dropdown-menu-Origin']/div/span[1]/span/div/span/div/p"));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == Classification)
                {
                    DropDownList[i].Click();
                    break;
                }
            }
            SendKeys(attributeName_id, LTL_Weight_Id, Weight.ToString());
            Thread.Sleep(3000);
        }


        [Then(@"I will see the guaranteed rate charge applied to the Est Cost total for any carrier displaying a guaranteed rate\.")]
        public void ThenIWillSeeTheGuaranteedRateChargeAppliedToTheEstCostTotalForAnyCarrierDisplayingAGuaranteedRate_()
        {
            Report.WriteLine("Naviagting to Guaranteed Rate carriers grid");
            MoveToElement(attributeName_xpath, ltlguarenteedrategrid_xpath);

            // Call Rate Request Api to get Assessorial charges
            List<RateResultCarrierViewModel> rateResults = GetRatesAndCarriersAPICall.CallRateRequestApi(Account, Service, OriginCity, OriginZip, OriginState, OriginCountry, DestinationCity, DestinationZip, DestinationState, DestinationCountry, Classification, Quantity, QuantityUNIT, Weight, WeightUnit, Username,true);

            //get guaranteed Est cost elements
            IList<IWebElement> guaranteedEstCostValuesUI = GlobalVariables.webDriver.FindElements(By.XPath(QuoteResults_GuaranteedCarrier_ESTCOSTColumns_Xpath));
            List<string> guaranteedEstCostValues = objWebElementOperations.GetListFromIWebElement(guaranteedEstCostValuesUI);
            guaranteedEstCostValues = guaranteedEstCostValues.Select(m => { return m.Split(new string[] { "\r", "\r\n" }, StringSplitOptions.None)[0]; }).ToList();

            //Get guaranteed carrier names,scac
            IList<IWebElement> guaranteedCarrierNamesUI = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='Grid-Rate-List-Large-Guranteed']/tbody/tr/td[1]"));
            List<string> guaranteedCarrierNames = objWebElementOperations.GetListFromIWebElement(guaranteedCarrierNamesUI);
            guaranteedCarrierNames = guaranteedCarrierNames.Select(m => { return m.Split(new string[] { "\r", "\r\n" }, StringSplitOptions.None)[0]; }).ToList();

            for (int i = 0; i < guaranteedEstCostValuesUI.Count; i++)
            {
                RateResultCarrierViewModel guaranteedCarrier = rateResults.Where(m => (m.CarrierName.ToLower() == guaranteedCarrierNames[i].ToLower() && m.IsGuaranteedCarrier && m.IsGuaranteedCarrierPrice)).FirstOrDefault();
                RateResultCarrierViewModel stdCarrier = rateResults.Where(m => (m.CarrierName.ToLower() == guaranteedCarrierNames[i].ToLower() && m.IsGuaranteedCarrier)).FirstOrDefault();

                if (stdCarrier != null && stdCarrier.EstCharges != null && stdCarrier.EstCharges.Any())
                {
                    decimal totalCost = stdCarrier.Charges[0].TotalCost;

                    //calculate guaranteedRate
                    decimal guaranteedRate = GetGuaranteedRate(totalCost, Convert.ToDecimal(guaranteedCarrier.MarkupPercentage), Convert.ToDecimal(guaranteedCarrier.MinAmountCharge));
                    decimal guaranteedCarrierEstCost = stdCarrier.EstCharges[0].TotalCost + guaranteedRate;

                    //Verify guaranteed rate charge applied to the Est Cost total 
                    Report.WriteLine("Verify guaranteed rate charge applied to the Est Cost total");
                    Assert.AreEqual("$" + (guaranteedCarrierEstCost).ToString("0.00"), guaranteedEstCostValues[i].Replace("*","").Trim());
                }
            }
        }

        [Then(@"The guaranteed charge will be applied to the rate details as an accessorial on rates results\.")]
        public void ThenTheGuaranteedChargeWillBeAppliedToTheRateDetailsAsAnAccessorialOnRatesResults_()
        {
            // Call Rate Request Api to get Assessorial charges
            List<RateResultCarrierViewModel> rateResults = GetRatesAndCarriersAPICall.CallRateRequestApi(Account, Service, OriginCity, OriginZip, OriginState, OriginCountry, DestinationCity, DestinationZip, DestinationState, DestinationCountry, Classification, Quantity, QuantityUNIT, Weight, WeightUnit, Username,true);

            //get guaranteed Est cost elements
            IList<IWebElement> guaranteedAssessorialValuesUI = GlobalVariables.webDriver.FindElements(By.XPath(QuoteResults_GuaranteedCarrier_AssessorialColumns_Xpath));
            List<string> guaranteedAssessorialValues = objWebElementOperations.GetListFromIWebElement(guaranteedAssessorialValuesUI);
            guaranteedAssessorialValues = guaranteedAssessorialValues.Select(m => { return m.Split(new string[] { "\r", "\r\n" }, StringSplitOptions.None)[0]; }).ToList();

            //Get guaranteed carrier names,scac
            IList<IWebElement> guaranteedCarrierNamesUI = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='Grid-Rate-List-Large-Guranteed']/tbody/tr/td[1]"));
            List<string> guaranteedCarrierNames = objWebElementOperations.GetListFromIWebElement(guaranteedCarrierNamesUI);
            guaranteedCarrierNames = guaranteedCarrierNames.Select(m => { return m.Split(new string[] { "\r", "\r\n" }, StringSplitOptions.None)[0]; }).ToList();

            for (int i = 0; i < guaranteedAssessorialValuesUI.Count; i++)
            {
                RateResultCarrierViewModel guaranteedCarrier = rateResults.Where(m => (m.CarrierName.ToLower() == guaranteedCarrierNames[i].ToLower() && m.IsGuaranteedCarrier && m.IsGuaranteedCarrierPrice)).FirstOrDefault();
                RateResultCarrierViewModel stdCarrier = rateResults.Where(m => (m.CarrierName.ToLower() == guaranteedCarrierNames[i].ToLower() && m.IsGuaranteedCarrier)).FirstOrDefault();

                if (stdCarrier != null && stdCarrier.EstCharges[0] != null && stdCarrier.EstCharges.Any())
                {
                    decimal totalCost = stdCarrier.Charges[0].TotalCost;

                    //calculate guaranteedRate
                    decimal guaranteedRate = GetGuaranteedRate(totalCost, Convert.ToDecimal(guaranteedCarrier.MarkupPercentage), Convert.ToDecimal(guaranteedCarrier.MinAmountCharge));
                    decimal guaranteedCarrierAssessorialCost = stdCarrier.EstCharges[0].Assessorial + guaranteedRate;

                    //Verify assessorialCost
                    Report.WriteLine("Verify assessorialCost applied to the Est Cost");
                    Assert.AreEqual("Accessorials: $ " + (guaranteedCarrierAssessorialCost).ToString("0.00"), guaranteedAssessorialValues[i]);
                }
            }
        }

        private static decimal GetGuaranteedRate(decimal totalCost, decimal percentage, decimal minCharge)
        {
            decimal guaranteeRate = (percentage / 100) * (totalCost);
            guaranteeRate = guaranteeRate >= minCharge ? guaranteeRate : minCharge;
            decimal totalGuaranteeRate = Math.Round(Convert.ToDecimal(guaranteeRate), 2);

            return totalGuaranteeRate;
        }
    }
}
