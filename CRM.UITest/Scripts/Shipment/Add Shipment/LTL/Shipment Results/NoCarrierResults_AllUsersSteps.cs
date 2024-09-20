using CRM.UITest.Helper;
using CRM.UITest.Helper.ViewModel;
using CRM.UITest.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using CRM.UITest.CommonMethods;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Results
{
    [Binding]
    public class NoCarrierResults_AllUsersSteps : AddShipments
    {
        CommonMethodsCrm crm = new CommonMethodsCrm();
        AddShipmentLTL ltl = new AddShipmentLTL();

        [Then(@"I will see the message as There are no rates available for this shipment")]
        public void ThenIWillSeeTheMessageAsThereAreNoRatesAvailableForThisShipment()
        {
            string configURL = launchUrl;

            string resultPagrURL = configURL + "Shipment/ShipmentResultsLtl";
            if (GetURL() == resultPagrURL)
            {

                IList<IWebElement> row = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='ShipmentResultTable']/tbody/tr"));
                for (int i = 1; i <= row.Count; i++)
                {
                    string verCarrierName = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr/td");
                    if (verCarrierName != "There are no rates available for this shipment.")
                    {
                        string CarrierName = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + i + "]/td[1]/div/div");
                        Report.WriteLine("Carrier Rates are available on the Shipment Results page");
                    }
                    else
                    {
                        Verifytext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr/td", "There are no rates available for this shipment.");
                    }
                    break;
                }
            }
        }


        [Then(@"I have option to Create the shipment without rates")]
        public void ThenIHaveOptionToCreateTheShipmentWithoutRates()
        {
            VerifyElementPresent(attributeName_xpath, ShipResults_CreateShipmentWithoutCarrierRate_Button_xpath, "Create Shipment without carrier Rate button");
        }


        [Then(@"I have option to Create the shipment without rates (.*), (.*) ,(.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*),(.*),(.*), (.*), (.*),(.*),(.*)")]
        public void ThenIHaveOptionToCreateTheShipmentWithoutRates(string CustomerName, string Service, string OriginCity, string OriginZip, string OriginState, string OriginCountry, string DestinationCity, string DestinationZip, string DestinationState, string DestinationCountry, string Classification, double Quantity, string QuantityUNIT, double Weight, string WeightUnit, string Username)
        {

            List<RateResultCarrierViewModel> apirespone = GetRatesAndCarriersAPICall.CallRateRequestApi(CustomerName, Service, OriginCity, OriginZip, OriginState, OriginCountry,
                DestinationCity, DestinationZip, DestinationState, DestinationCountry, Classification, Quantity, QuantityUNIT, Weight, WeightUnit, Username, false);
            List<string> carrierNames = apirespone.Select(p => p.CarrierName).ToList();
            int APICount = carrierNames.Count;
            if (APICount > 0)
            {
                Report.WriteLine("Shipment Results have the Carrier Rates");
            }
            else
            {
                VerifyElementPresent(attributeName_xpath, ShipResults_CreateShipmentWithoutCarrierRate_Button_xpath, "Create Shipment without carrier Rate button");
            }


        }

        [When(@"I click on the Create Shipment without Carrier Rate")]
        public void WhenIClickOnTheCreateShipmentWithoutCarrierRate()
        {
            string configURL = launchUrl;

            string resultPagrURL = configURL + "Shipment/ShipmentResultsLtl";
            if (GetURL() == resultPagrURL)
            {

                IList<IWebElement> row = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='ShipmentResultTable']/tbody/tr"));
                for (int i = 1; i <= row.Count; i++)
                {
                    string verCarrierName = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr/td");
                    if (verCarrierName != "There are no rates available for this shipment.")
                    {

                        Report.WriteLine("Carrier Rates are available on the Shipment Results page");
                    }
                    else
                    {
                        Report.WriteLine("Navigating to the Review and Submit page");
                        Click(attributeName_xpath, ShipResults_CreateShipmentWithoutCarrierRate_Button_xpath);
                    }
                    break;
                }
            }

        }

        [Then(@"I will arrive on the Review and Submit LTL page")]
        public void ThenIWillArriveOnTheReviewAndSubmitLTLPage()
        {
            VerifyElementPresent(attributeName_xpath, ReviewAndSubmit_Title_Xpath, "Review and Submit Page");
        }

        [Then(@"there will be no Carrier Information section")]
        public void ThenThereWillBeNoCarrierInformationSection()
        {
            VerifyElementNotVisible(attributeName_xpath, ReviewSubmit_Section_CarrierInfo_Xpath, "Carrier Info Section");
        }

        [Given(@"I enter required data in add shipment ltl page (.*), (.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*), (.*), (.*)")]
        public void GivenIEnterRequiredDataInAddShipmentLtlPage(string Usertype,
            string CustomerName,
            string oName,
            string oAddr1,
            string oZipcode,
            string dName,
            string dAddr1,
            string dZipcode,
            string Classification,
            string nmfc,
            string quantity,
            string weight,
            string weightType,
            string itemdesc,
            string Country,
            string Postal,
            string city,
            string state)
        {
            ltl.NaviagteToShipmentList();
            ltl.SelectCustomerFromShipmentList(Usertype, CustomerName);
            ltl.AddShipment_ShippingFromData(oName, oAddr1, oZipcode, Country, Postal, city, state);
            ltl.AddShipment_ShippingToData(dName, dAddr1, dZipcode, Country, Postal, city, state);

            Report.WriteLine("Passing data in freight description section");
            scrollElementIntoView(attributeName_xpath, FreightDesp_SectionText_xpath);
            Click(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            Click(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id);
            IList<IWebElement> dropdownValues = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='scrollable-dropdown-menu-Origin']/div/span[1]/span/div/span/div/p"));
            for (int i = 0; i < dropdownValues.Count; i++)
            {
                int z = i + 1;
                string value = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='scrollable-dropdown-menu-Origin']/div/span[1]/span/div/span/div[" + z + "]/p")).Text;
                if (value == Classification)
                {
                    GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='scrollable-dropdown-menu-Origin']/div/span[1]/span/div/span/div[" + z + "]/p")).Click();
                    break;
                }
            }
            SendKeys(attributeName_id, FreightDesp_FirstItem_NMFC_Id, nmfc);
            SendKeys(attributeName_id, FreightDesp_FirstItem_Quantity_Id, quantity);
            SendKeys(attributeName_id, FreightDesp_FirstItem_Weight_Id, weight);
            string weight_type = Gettext(attributeName_xpath, FreightDesp_FirstItem_WeightType_xpath);
            if (weight_type != (weightType))
            {
                Click(attributeName_xpath, FreightDesp_FirstItem_WeightType_xpath);
                IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(FreightDesp_FirstItem_WeightTypevalues_xpath));
                int DropDownCount = DropDownList.Count;
                for (int i = 0; i < DropDownCount; i++)
                {
                    if (DropDownList[i].Text == weightType)
                    {
                        DropDownList[i].Click();
                        break;
                    }
                }
            }
            SendKeys(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id, itemdesc);

        }


        //-----------------------------------API 

        [Then(@"I will see the message as There are no rates available for this shipment (.*), (.*) ,(.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*),(.*),(.*), (.*), (.*),(.*),(.*)")]
        public void ThenIWillSeeTheMessageAsThereAreNoRatesAvailableForThisShipment(string CustomerName, string Service, string OriginCity, string OriginZip, string OriginState, string OriginCountry, string DestinationCity, string DestinationZip, string DestinationState, string DestinationCountry, string Classification, double Quantity, string QuantityUNIT, double Weight, string WeightUnit, string Username)
        {
            List<RateResultCarrierViewModel> apirespone = GetRatesAndCarriersAPICall.CallRateRequestApi(CustomerName, Service, OriginCity, OriginZip, OriginState, OriginCountry,
                DestinationCity, DestinationZip, DestinationState, DestinationCountry, Classification, Quantity,
                QuantityUNIT, Weight, WeightUnit, Username, false);
            List<string> carrierNames = apirespone.Select(p => p.CarrierName).ToList();
            int APICount = carrierNames.Count;
            if (APICount > 0)
            {
                Report.WriteLine("Shipment Results have the Carrier Rates");
            }
            else
            {
                Verifytext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr/td", "There are no rates available for this shipment.");
                VerifyElementPresent(attributeName_xpath, ShipResults_CreateShipmentWithoutCarrierRate_Button_xpath, "Create Shipment without carrier Rate button");
            }
        }

        [Then(@"I click on the Create Shipment without Carrier Rate  when no rates for the shipment (.*), (.*) ,(.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*),(.*),(.*), (.*), (.*),(.*),(.*)")]
        public void ThenIClickOnTheCreateShipmentWithoutCarrierRateWhenNoRatesForTheShipment(string CustomerName, string Service, string OriginCity, string OriginZip, string OriginState, string OriginCountry, string DestinationCity, string DestinationZip, string DestinationState, string DestinationCountry, string Classification, double Quantity, string QuantityUNIT, double Weight, string WeightUnit, string Username)
        {
            List<RateResultCarrierViewModel> apirespone = GetRatesAndCarriersAPICall.CallRateRequestApi(CustomerName, Service, OriginCity, OriginZip, OriginState, OriginCountry,
                DestinationCity, DestinationZip, DestinationState, DestinationCountry, Classification, Quantity,
                QuantityUNIT, Weight, WeightUnit, Username, false);

            List<string> carrierNames = apirespone.Select(p => p.CarrierName).ToList();
            int APICount = carrierNames.Count;
            if (APICount > 0)
            {
                Report.WriteLine("Shipment Results have the Carrier Rates");
            }
            else
            {
                Click(attributeName_xpath, ShipResults_CreateShipmentWithoutCarrierRate_Button_xpath);
                VerifyElementPresent(attributeName_xpath, ReviewAndSubmit_Title_Xpath, "Review and Submit Page");
                VerifyElementNotVisible(attributeName_xpath, ReviewSubmit_Section_CarrierInfo_Xpath, "Carrier Info Section");

            }
        }
    }
}
