using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper;
using CRM.UITest.Helper.ViewModel;
using CRM.UITest.Objects;
using CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Quote.LTL.Quote_Results_Screen
{
    [Binding]
    public class _73930_GuaranteedRateCalculationForFedExSteps : AddShipments
    {
        CommonMethodsCrm crm = new CommonMethodsCrm();
        List<RateResultCarrierViewModel> apiresponse = null;
        List<IndividualAccessorialModel> accessorialapiresponse = null;
        List<string> guaranteedCarrierNames = null;
        CRM_Rating_Logic_Guaranteed_Rate_Calculation_Shipment_Results calculatedGuarantedCalculation_Shipment = new CRM_Rating_Logic_Guaranteed_Rate_Calculation_Shipment_Results();
        public WebElementOperations objWebElementOperations = new WebElementOperations();
        [Given(@"I am a DLS user that belongs to Gainshare Customer and login into application with valid ""(.*)"" and ""(.*)""")]
        public void GivenIAmADLSUserThatBelongsToGainshareCustomerAndLoginIntoApplicationWithValidAnd(string Username, string Password)
        {
            Report.WriteLine("I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner user");
            string userName = ConfigurationManager.AppSettings[Username].ToString();
            string password = ConfigurationManager.AppSettings[Password].ToString();
            crm.LoginToCRMApplication(userName, password);
            Report.WriteLine("I logged into CRM application with external user credentials");
        }

        [Given(@"I navigate to the Get Quote \(LTL\) page for ""(.*)""")]
        public void GivenINavigateToTheGetQuoteLTLPage(string customerAccount)
        {
            Report.WriteLine("Click on the Quote Module");
            Click(attributeName_xpath, QuoteIcon_Xpath);
            Click(attributeName_xpath, QuoteCustomerSelectionDropdown_Xpath);
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(QuoteCustomerSelectioDropdownValues_Xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == customerAccount)
                {
                    DropDownList[i].Click();
                    break;
                }
            }
            Report.WriteLine("Click on the Submit Rate Request Button");
            Click(attributeName_id, SubmitRateRequestBtn_id);
            Report.WriteLine("Click on the LTL Tile");
            Click(attributeName_id, ShipmentServiceTypeLTL_id);
            Report.WriteLine("I am on the Get Quote LTL Page");
            VerifyElementPresent(attributeName_xpath, LTLpagetitle_xpath, "Get Quote (LTL)");
        }

        [When(@"I am on the quote results page for Calculating Guaranteed Total Cost ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)""")]
        public void WhenIAmOnQuoteResultsPageForCalculatingGauranteedTotalCost(string Customer_Name, string UserType, string OriginZip, string DestinationZip, string Classification, string Quantity, string Weight, string originAccessorials, string destinationAccessorials)
        {
            AddQuoteLTL quote = new AddQuoteLTL();
            quote.EnterOriginZip(OriginZip);
            Click(attributeName_id, ClearAddress_DestId);
            GlobalVariables.webDriver.WaitForPageLoad();
            quote.EnterDestinationZip(DestinationZip);
            if (originAccessorials != "")
                quote.selectShippingfromServices(originAccessorials);
            if (destinationAccessorials != "")
                quote.selectShippingToServices(destinationAccessorials);
            quote.EnterItemdata(Classification, Weight);
            quote.ClickViewRates();
        }

        [Then(@"Rate \(customer charge\) will be determined by applying the CRM Rating calculation to the guaranteed rate amount for the Quote ""(.*)"", ""(.*)"" , ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"",""(.*)"",""(.*)"", ""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)""")]
        public void ThenRateCustomerChargeWillBeDeterminedByApplyingTheCRMRatingCalculationToTheGuaranteedRateAmountForTheQuote(string Customer_Name, string Service, string OriginCity, string OriginZip, string OriginState,
            string OriginCountry, string DestinationCity, string DestinationZip, string DestinationState, string DestinationCountry, string Classification,
            double Quantity, double Weight, string Username, string usertype, string originAccessorials, string destinationAccessorials)
        {
            string QuantityUNIT = "skids";
            string WeightUnit = "LBS";

            bool iSCrmRatingLogic_GainshareCustomer = DBHelper.CheckNewCrmRatingLogic(Customer_Name);

            apiresponse = _73930_GetRatesAndCarriersAPICall.CallRateRequestApi(Customer_Name, Service, OriginCity, OriginZip, OriginState, OriginCountry, DestinationCity, DestinationZip, DestinationState, DestinationCountry, Classification, Quantity, QuantityUNIT, Weight, WeightUnit, Username, iSCrmRatingLogic_GainshareCustomer,
                destinationAccessorials, originAccessorials);

            //Get guaranteed carrier names,scac
            scrollElementIntoView(attributeName_id, "Grid-Rate-List-Large-Guranteed");
            IList<IWebElement> guaranteedCarrierNamesUI = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='Grid-Rate-List-Large-Guranteed']/tbody/tr/td[1]"));
            guaranteedCarrierNames = objWebElementOperations.GetListFromIWebElement(guaranteedCarrierNamesUI);
            guaranteedCarrierNames = guaranteedCarrierNames.Select(m => { return m.Split(new string[] { "\r", "\r\n" }, StringSplitOptions.None)[0]; }).ToList();

            for(int i = 0; i < guaranteedCarrierNamesUI.Count; i++)
            {
                RateResultCarrierViewModel guaranteedCarrier = apiresponse.Where(m => (m.CarrierName.ToLower() == guaranteedCarrierNames[i].ToLower() && m.IsGuaranteedCarrier && m.IsGuaranteedCarrierPrice)).FirstOrDefault();
                string CalculatedGuaranteed_TotalCost = "$" + guaranteedCarrier.Charges[0].TotalCost.ToString("F");
                string CalculatedGuaranteed_Fuel = "$ " + guaranteedCarrier.Charges[0].FuelCost.ToString("F");
                string CalculatedGuaranteed_LineHaul = "$ " + guaranteedCarrier.Charges[0].LineHaul.ToString("F");
                string CalculatedGuaranteed_Accessorial = "$ " + guaranteedCarrier.Charges[0].Assessorial.ToString("F");


                int j = i + 1;
                string guaranteedCRMRatingLogicTotalCost_UI = null;
                string guaranteedCRMRatingLogicFuel_UI = null;
                string guaranteedCRMRatingLogicLineHaul_UI = null;
                string guaranteedCRMRatingLogicAccessorial_UI = null;
                if (usertype == "External")
                {

                    guaranteedCRMRatingLogicTotalCost_UI = Gettext(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-Guranteed']/tbody/tr[" + j + "]/td[4]/ul[1]/li[1]");
                    guaranteedCRMRatingLogicFuel_UI = Gettext(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-Guranteed']/tbody/tr[" + j + "]/td[4]/ul[1]/li[2]");
                    guaranteedCRMRatingLogicLineHaul_UI = Gettext(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-Guranteed']/tbody/tr[" + j + "]/td[4]/ul[1]/li[3]");
                    guaranteedCRMRatingLogicAccessorial_UI = Gettext(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-Guranteed']/tbody/tr[" + j + "]/td[4]/ul[1]/li[4]");
                }
                else
                {
                    guaranteedCRMRatingLogicTotalCost_UI = Gettext(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-Guranteed']/tbody/tr[" + j + "]/td[5]/ul[1]/li[1]");
                    guaranteedCRMRatingLogicFuel_UI = Gettext(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-Guranteed']/tbody/tr[" + j + "]/td[5]/ul[1]/li[2]");
                    guaranteedCRMRatingLogicLineHaul_UI = Gettext(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-Guranteed']/tbody/tr[" + j + "]/td[5]/ul[1]/li[3]");
                    guaranteedCRMRatingLogicAccessorial_UI = Gettext(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-Guranteed']/tbody/tr[" + j + "]/td[5]/ul[1]/li[4]");
                }
                string[] ActualGuaranteedTotalcostUI = guaranteedCRMRatingLogicTotalCost_UI.Split(' ');
                string[] ActualGuaranteedFuelUI = guaranteedCRMRatingLogicFuel_UI.Split(' ');
                string[] ActualGuaranteedLineHaulUI = guaranteedCRMRatingLogicLineHaul_UI.Split(' ');
                string[] ActualGuaranteedAccessorialUI = guaranteedCRMRatingLogicAccessorial_UI.Split(' ');
                guaranteedCRMRatingLogicTotalCost_UI = ActualGuaranteedTotalcostUI[1];
                guaranteedCRMRatingLogicFuel_UI = ActualGuaranteedFuelUI[1] + " " + ActualGuaranteedFuelUI[2];
                guaranteedCRMRatingLogicLineHaul_UI = ActualGuaranteedLineHaulUI[2] + " " + ActualGuaranteedLineHaulUI[3];
                guaranteedCRMRatingLogicAccessorial_UI = ActualGuaranteedAccessorialUI[1] + " " + ActualGuaranteedAccessorialUI[2];
                Assert.AreEqual(guaranteedCRMRatingLogicTotalCost_UI, CalculatedGuaranteed_TotalCost);
                Assert.AreEqual(guaranteedCRMRatingLogicFuel_UI, CalculatedGuaranteed_Fuel);
                Assert.AreEqual(guaranteedCRMRatingLogicLineHaul_UI, CalculatedGuaranteed_LineHaul);
                Assert.AreEqual(guaranteedCRMRatingLogicAccessorial_UI, CalculatedGuaranteed_Accessorial);
            }
        }

    }
}
