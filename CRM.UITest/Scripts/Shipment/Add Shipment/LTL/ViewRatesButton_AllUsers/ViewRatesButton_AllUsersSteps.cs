using CRM.UITest.Helper;
using CRM.UITest.Helper.ViewModel;
using CRM.UITest.Objects;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.ViewRatesButton_AllUsers
{
    [Binding]
    public class ViewRatesButton_AllUsersSteps : AddShipments
    {


        [When(@"I enter data in the Origin Section (.*),(.*),(.*)")]
        public void WhenIEnterDataInTheOriginSection(string OlocationName, string OLocationAddress, string OzipCode)
        {
            Report.WriteLine("Clearing if any default Address present in Origin section");
            Thread.Sleep(1000);
            string _selectedAddress = GetValue(attributeName_id, ShippingFrom_SelectSavedOriginDropDown_Id, "value");

            if (_selectedAddress != "" || _selectedAddress != string.Empty)
            {
                Click(attributeName_id, ShippingFrom_ClearAddress_Id);
                Thread.Sleep(4000);
            }
            SendKeys(attributeName_id, ShippingFrom_LocationName_Id, OlocationName);
            SendKeys(attributeName_id, ShippingFrom_LocationAddressLine1_Id, OLocationAddress);
            SendKeys(attributeName_id, ShippingFrom_zipcode_Id, OzipCode);
        }

        [When(@"I enter data in the Destination Section (.*),(.*),(.*)")]
        public void WhenIEnterDataInTheDestinationSection(string DDestinationName, string DDestinationAddress, string DzipCode)
        {
            Report.WriteLine("Clearing if any default Address present in Destination section");
            Thread.Sleep(1000);
            string _selectedAddress = GetValue(attributeName_id, ShippingTo_SelectSavedDestDropDown_Id, "value");

            if (_selectedAddress != "" || _selectedAddress != string.Empty)
            {
                Click(attributeName_id, ShippingTo_ClearAddress_Id);
                Thread.Sleep(4000);
            }
            SendKeys(attributeName_id, ShippingTo_LocationName_Id, DDestinationName);
            SendKeys(attributeName_id, ShippingTo_LocationAddressLine1_Id, DDestinationAddress);
            SendKeys(attributeName_id, ShippingTo_zipcode_Id, DzipCode);
        }


        [When(@"I enter data in the Freight Description section (.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void WhenIEnterDataInTheFreightDescriptionSection(string Classification, string NMFC, string Quantity, string QuantityUnit, string ItemDescription, string Weight, string WeightUnit)
        {
            Report.WriteLine("Clearing if any default Item present in Freight section");
            Thread.Sleep(1000);
            string _selectedAddress = GetValue(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id, "value");

            if (_selectedAddress != "" || _selectedAddress != string.Empty)
            {
                Click(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
                Thread.Sleep(4000);
            }
            Click(attributeName_id,FreightDesp_FirstItem_ClearItem_Button_Id);
            Click(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id);
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(FreightDesp_FirstItem_SavedClassItem_DropDown_Values_xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == Classification)
                {
                    DropDownList[i].Click();
                    break;
                }
            }
            
            SendKeys(attributeName_id, FreightDesp_FirstItem_NMFC_Id, NMFC);            
            SendKeys(attributeName_id, FreightDesp_FirstItem_Quantity_Id, Quantity);            
            SendKeys(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id, ItemDescription);
            SendKeys(attributeName_id, FreightDesp_FirstItem_Weight_Id, Weight);
            SendKeys(attributeName_id, InsuredValue_TextBox_Id, "1000");
           
        }

        [Then(@"API Response of the shipment results should match with UI(.*), (.*) ,(.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*),(.*),(.*), (.*), (.*),(.*),(.*)")]
        public void ThenAPIResponseOfTheShipmentResultsShouldMatchWithUI(string Account, string Service, string OriginCity, string OriginZip, string OriginState, string OriginCountry, string DestinationCity, string DestinationZip, string DestinationState, string DestinationCountry, string Classification, double Quantity, string QuantityUNIT, double Weight, string WeightUnit, string Username)
        {
            List<RateResultCarrierViewModel> apirespone = GetRatesAndCarriersAPICall.CallRateRequestApi(Account, Service, OriginCity, OriginZip, OriginState, OriginCountry,
                DestinationCity, DestinationZip, DestinationState, DestinationCountry, Classification, Quantity, QuantityUNIT, Weight, WeightUnit, Username, false);
            List<string> carrierNames = apirespone.Select(p => p.CarrierName).ToList();
            List<string> carrierNames1 = apirespone.Select(p => p.EstMargin).ToList();
            string carriername = apirespone[0].CarrierName;
            //Getting est cost values from API for first carrier
            decimal FuelCost = apirespone[0].EstCharges[0].FuelCost;
            decimal LineHaul = apirespone[0].EstCharges[0].LineHaul;
            decimal Assessorial = apirespone[0].EstCharges[0].Assessorial;
            decimal TotalCost = apirespone[0].EstCharges[0].TotalCost;
            string EstMargin = apirespone[0].EstMargin;

            if (FuelCost == null)
            {
                string FuelCostUI = GlobalVariables.webDriver.FindElement(By.XPath("//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[4]/ul[1]/li[2]")).Text;
                FuelCostUI.Equals("N/A");
            }
            else
            {
                //Getting Fuel Cost from UI First row and matching with API
                string FuelCostUI = GlobalVariables.webDriver.FindElement(By.XPath("//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[4]/ul[1]/li[2]")).Text;
                string FuelCostUI1 = Regex.Replace(FuelCostUI, @"[^0-9.]+", "");
                double FuelCostUI11 = double.Parse(FuelCostUI1);
                FuelCostUI11.Equals(FuelCost);
            }

            if (LineHaul == null)
            {
                string LineHaulUI = GlobalVariables.webDriver.FindElement(By.XPath("//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[4]/ul[1]/li[3]")).Text;
                LineHaulUI.Equals("N/A");
            }
            else
            {
                //Getting Line haul Cost from UI First row and matching with API
                string LineHaulUI = GlobalVariables.webDriver.FindElement(By.XPath("//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[4]/ul[1]/li[3]")).Text;
                string LineHaulUI1 = Regex.Replace(LineHaulUI, @"[^0-9.]+", "");
                double LineHaulUI11 = double.Parse(LineHaulUI1);
                LineHaulUI1.Equals(LineHaul);
            }

            if (TotalCost == null)
            {
                string TotalCostUI = GlobalVariables.webDriver.FindElement(By.XPath("//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[4]/ul[1]/li[1]")).Text;
                TotalCostUI.Equals("N/A");
            }
            else
            {
                //Getting Total Cost from UI First row and matching with API
                string TotalCostUI = GlobalVariables.webDriver.FindElement(By.XPath("//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[4]/ul[1]/li[1]")).Text;
                string TotalCostUI1 = Regex.Replace(TotalCostUI, @"[^0-9.]+", "");
                double TotalCostUI11 = double.Parse(TotalCostUI1);
                TotalCostUI11.Equals(TotalCost);
            }
            if (Assessorial == null)
            {
                string AssessorialUI = GlobalVariables.webDriver.FindElement(By.XPath("//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[4]/ul[1]/li[4]")).Text;
                AssessorialUI.Equals("N/A");
            }
            else
            {
                //Getting Assessorial from UI First row and matching with API
                string AssessorialUI = GlobalVariables.webDriver.FindElement(By.XPath("//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[4]/ul[1]/li[4]")).Text;
                string AssessorialUI1 = Regex.Replace(AssessorialUI, @"[^0-9.]+", "");
                double AssessorialUI11 = double.Parse(AssessorialUI1);
                AssessorialUI11.Equals(Assessorial);
            }

            if (EstMargin == null)
            {
                string EstMarginUI = GlobalVariables.webDriver.FindElement(By.XPath("//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[5]/ul[2]/li/b")).Text;
                EstMarginUI.Equals("N/A");
            }
            else
            {
                //Getting Est Margin Cost from UI First row and matching with API
                string EstMarginUI = GlobalVariables.webDriver.FindElement(By.XPath("//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[5]/ul[2]/li/b")).Text;
                string EstMarginUI1 = Regex.Replace(EstMarginUI, @"[^0-9.]+", "");
                double EstMarginUI111 = double.Parse(EstMarginUI1);
                EstMarginUI111.Equals(EstMargin);
            }



            int APICount = carrierNames.Count;
            IList<IWebElement> carrierNameUI = GlobalVariables.webDriver.FindElements(By.XPath(ltlcarriersall_xpath));
            int carrierNameCountUI = carrierNameUI.Count();

            string firstCarrierUI = carrierNameUI[0].Text;
            carriername.Contains(firstCarrierUI);

        }


    }
}
