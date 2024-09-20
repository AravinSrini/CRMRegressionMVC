using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper;
using CRM.UITest.Helper.DataModels;
using CRM.UITest.Helper.ViewModel;
using CRM.UITest.Objects;
using CRM.UITest.Scripts.Quote.LTL.Quote_Results_Screen;
using CRM.UITest.Scripts.Quote.LTL.Shipment_Information_Screen.OverLength_GetQuote_LTL_;
using Microsoft.IdentityModel.Protocols;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Information_Screen.OverLength_AddShipment__LTL_
{
    [Binding]
    public class Over_Length___Add_Shipment__LTL____Service_CodesSteps : AddShipments
    {
        bool iSCrmRatingLogic_GainshareCustomer;
        List<RateResultCarrierViewModel> rlist = null;
        List<IndividualAccessorialModel> accessorialapirespone = null;
        string CustomerName = "ZZZ - GS Customer Test";
        //Shipping From Section
        string Service = "LTL";
        string OriginName = "";
        string OriginAddress = "";
        string OriginZIp = "33126";
        string OriginCountry = "USA";
        string OriginPostal = "";
        string OriginCity = "Miami";
        string OriginState = "FL";

        //Shipping To Section
        string DestinationName = "";
        string DestinationAddress = "";
        string DestinationZIp = "85282";
        string DestinationCountry = "USA";
        string DestinationPostal = "";
        string DestinationCity = "Tempe";
        string DestinationState = "AZ";


        //OverLength
        string OAccessorial;
        string DAccessorial;
       // string Accessorial = "Overlength";

        //Freight Description
        string SavedItem = "50";
        double Quantity = 5;
        string ItemDescription = "Check Skids";
        double Weight = 100;
        string WeightUnit;
        string QuantityUNIT = "SKD";


        string Username = "crmOperation@user.com";

        decimal BMAA = 0;
        decimal BOTFACC = 0;
        decimal BTTL = 0;
        decimal Total = 0;
        decimal AACC = 0;//API call 
        decimal BOLH = 0;
        decimal BOFSC = 0;
        decimal MACC = 0;


        AddShipmentLTL AddShipment = new AddShipmentLTL();
        Over_Length___Add_Shipment__LTL____FunctionalitySteps Overlength = new Over_Length___Add_Shipment__LTL____FunctionalitySteps();
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
        _40782_Over_Length___Get_Quote__LTL____Service_Codes_Steps OverlengthAccessorial = new _40782_Over_Length___Get_Quote__LTL____Service_Codes_Steps();

        public WebElementOperations objWebElementOperations = new WebElementOperations();
        CRMRatingLogic_GuaranteedRateCalculation_QuoteResultsSteps crmRating = new CRMRatingLogic_GuaranteedRateCalculation_QuoteResultsSteps();

        List<string> standardCarrierNames = null;
        BumpSurgeCalculationModel bumpSurgeCalculationModel = new BumpSurgeCalculationModel();

        [Given(@"I am a shp\.entry, sales, sales management, operations and station owner user")]
        public void GivenIAmAShp_EntrySalesSalesManagementOperationsAndStationOwnerUser()
        {
            string username = ConfigurationManager.AppSettings["username-ExtuserCustDropdown"].ToString();
            string password = ConfigurationManager.AppSettings["password-ExtuserCustDropdown"].ToString();

            CrmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"Over Length is selected in the (.*) field on the Add shipment LTL page")]
        public void GivenOverLengthIsSelectedInTheFieldOnTheAddShipmentLTLPage(string p0)
        {
            AddShipment.AddShipment_ShippingFromData(OriginName, OriginAddress, OriginZIp, OriginCountry, OriginPostal, OriginCity, OriginState);
            AddShipment.AddShipment_ShippingToData(DestinationName, DestinationAddress, DestinationZIp, DestinationCountry, DestinationPostal, DestinationCity, DestinationState);
            Overlength.WhenISelectOverlengthAsServicesAndAccessorialsFromShippingToSection();
        }


        [Given(@"The values entered in the Length field of an any item is equal to or greater than (.*) IN")]
        public void GivenTheValuesEnteredInTheLengthFieldOfAnAnyItemIsEqualToOrGreaterThanIN(string Value)
        {
            Report.WriteLine("Values entered in the Length field of any item is equal to or greater than");

            scrollpagedown();
            scrollpagedown();

            Click(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);

            Click(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id);
            IList<IWebElement> ClassAndItemDropdown = GlobalVariables.webDriver.FindElements(By.XPath("FreightDescription_ClassList_Xpath"));
            int ClassAndItemDropdownCount = ClassAndItemDropdown.Count;
            for (int i = 0; i < ClassAndItemDropdownCount; i++)
            {
                if (ClassAndItemDropdown[i].Text == SavedItem)
                {
                    ClassAndItemDropdown[i].Click();
                    break;
                }
            }

            SendKeys(attributeName_id, FreightDesp_FirstItem_Quantity_Id, Quantity.ToString());
            SendKeys(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id, ItemDescription);
            SendKeys(attributeName_id, FreightDesp_FirstItem_Weight_Id, Weight.ToString());
            SendKeys(attributeName_id, FreightDesp_FirstItem_Length_Id, Value);
        }

        [When(@"I click on the View Rates button")]
        public void WhenIClickOnTheViewRatesButton()
        {
            Report.WriteLine("Click on View Rates Button");
            Click(attributeName_xpath, Shipments_ViewRatesButton_xpath);
        }

        [Then(@"The CRM will send the associated Over Length Service Code to MG for Shipment (.*),(.*)")]
        public void ThenTheCRMWillSendTheAssociatedOverLengthServiceCodeToMGForShipment(string value, string dimensionType)
        {
            
            dimensionType = Regex.Replace(value, @"(\s+|&|'|\(|\)|<|>|#)", "");
            OAccessorial = OverlengthAccessorial.GetOverlengthAccessorialServiceCode(Convert.ToInt32(value), dimensionType);
            string WeightUnit = "lbs";
            string QuantityUNIT = "skids";
            WeightUnit = "LBS";
            iSCrmRatingLogic_GainshareCustomer = DBHelper.CheckNewCrmRatingLogic(CustomerName);



            if (iSCrmRatingLogic_GainshareCustomer)
            {
                rlist = GetRatesAndCarriersAPICall.CallRateRequestApiWithAccessorials(CustomerName,
                    Service,
                    OriginCity,
                    OriginZIp,
                    OriginState,
                    OriginCountry,
                    DestinationCity,
                    DestinationZIp,
                    DestinationState,
                    DestinationCountry,
                    OAccessorial,
                    DAccessorial,
                    SavedItem,
                    Quantity,
                    QuantityUNIT,
                    Weight,
                    WeightUnit,
                    Username, false);

                accessorialapirespone = GetRatesAndCarriersAPICall.BuildIndividualAccessorialModelFromCarrierPriceSheet(CustomerName,
                Service,
                OriginCity,
                OriginZIp,
                OriginState,
                OriginCountry,
                DestinationCity,
                DestinationZIp,
                DestinationState,
                DestinationCountry,
                OAccessorial,
                DAccessorial,
                SavedItem,
                Quantity,
                QuantityUNIT,
                Weight,
                WeightUnit,
                Username,
                false);

            }
            else
            {
                rlist = GetRatesAndCarriersAPICall.CallRateRequestApiWithAccessorials(CustomerName,
                 Service,
                 OriginCity,
                 OriginZIp,
                 OriginState,
                 OriginCountry,
                 DestinationCity,
                 DestinationZIp,
                 DestinationState,
                 DestinationCountry,
                 OAccessorial,
                 DAccessorial,
                 SavedItem,
                 Quantity,
                 QuantityUNIT,
                 Weight,
                 WeightUnit,
                 Username, false);
            }
        }


        [Then(@"Total cost should be matched with API on Shipment Results page")]
        public void ThenTotalCostShouldBeMatchedWithAPIOnShipmentResultsPage()
        {
            //Getting all the standard carrier name from UI
            IList<IWebElement> standardCarrierNamesUI = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr/td[1]"));
            standardCarrierNames = objWebElementOperations.GetListFromIWebElement(standardCarrierNamesUI);
            standardCarrierNames = standardCarrierNames.Select(m => { return m.Split(new string[] { "\r", "\r\n" }, StringSplitOptions.None)[0]; }).ToList();

            if (iSCrmRatingLogic_GainshareCustomer == false)
            {

                for (int i = 0; i < standardCarrierNamesUI.Count; i++)
                {
                    RateResultCarrierViewModel standardCarrierResponse = rlist.Where(m => (m.CarrierName.ToLower() == standardCarrierNames[i].ToLower())).FirstOrDefault();

                    //Verifying standard rates UI with API response for External users
                    if (standardCarrierNames[i].Equals(standardCarrierResponse.CarrierName))
                    {
                        string carrierRate = Gettext(attributeName_xpath, "//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[" + (i + 1) + "]/td[4]/ul/li[@class='rate-col-tot']");

                        Assert.AreEqual(carrierRate, "* $" + rlist[i].Charges[0].TotalCost);
                    }
                }
            }
            else
            {

                for (int i = 0; i < standardCarrierNamesUI.Count; i++)
                {
                    RateResultCarrierViewModel standardCarrierResponse = rlist.Where(m => (m.CarrierName.ToLower() == standardCarrierNames[i].ToLower())).FirstOrDefault();

                    IndividualAccessorialModel StdCarrier = accessorialapirespone.Where(m => (m.carrierName.ToLower() == standardCarrierNames[i].ToLower())).FirstOrDefault();
                    //RateResultCarrierViewModel stdCarrier = apirespone.Where(m => (m.CarrierName.ToLower() == guaranteedCarrierNames[i].ToLower())).FirstOrDefault();
                    string SASCCode = standardCarrierResponse.ScacCode;


                    if (standardCarrierResponse != null && standardCarrierResponse.CarrierName != null)
                    {
                        string aPIstdtotalcost = StdCarrier.TotalCost;
                        decimal stdtotalcost = Decimal.Parse(aPIstdtotalcost);

                        //calculate guaranteedRate DB
                        decimal guaranteedRate = 0;

                        //Calling BMAA method

                        BMAA = crmRating.GetGuaranteedBMAAValue(CustomerName, Service, OriginCity, OriginZIp, OriginState,
                                                     OriginCountry, DestinationCity, DestinationZIp, DestinationState, DestinationCountry, SavedItem,
                                                     Quantity, QuantityUNIT, Weight, WeightUnit, Username, OAccessorial, DAccessorial,
                                                     standardCarrierResponse.CarrierName, guaranteedRate);

                        // Calling Breakoout method

                        MACC = crmRating.GetMACC(CustomerName, Service, OriginCity, OriginZIp, OriginState,
                                OriginCountry, DestinationCity, DestinationZIp, DestinationState, DestinationCountry, OAccessorial, DAccessorial,
                                SavedItem, Quantity, QuantityUNIT, Weight, Username, standardCarrierResponse.CarrierName);

                        BOLH = crmRating.GetBOLH(standardCarrierResponse.CarrierName, guaranteedRate);
                        bumpSurgeCalculationModel.BreakOutLineHaul = BOLH;



                        BOFSC = crmRating.GetBOFSC(standardCarrierResponse.CarrierName);
                        bumpSurgeCalculationModel.BreakOutFuel = BOFSC;

                        //GuaranteedRateAccessorial with CRM Rating logic
                        //decimal guaranteedRateWithCRMRatingLogic = calculatedGuarantedCalculation_Shipment.GetCRMRatingGuranteedRate(Customer_Name, guaranteedRate, SASCCode);



                        BOTFACC = crmRating.GetBOTFACC(CustomerName, standardCarrierResponse.CarrierName);
                        //bumpSurgeCalculationModel.BreakOutAccessorialsTotal = BOTFACC + guaranteedRateWithCRMRatingLogic;


                        decimal BOTTL = BOLH + BOFSC + BOTFACC;
                        bumpSurgeCalculationModel.BreakOutTotal = BOTTL;



                        //Verifying CRM Rating Logic standard guaranteed with UI
                        // decimal guaranteedCRMLogicBOTFACC = BOTFACC + guaranteedRateWithCRMRatingLogic;
                        decimal CRMLogicBOTTL = BOTFACC + BOLH + BOFSC;

                        //adding bump and surge
                        BumpSurgeCustomerSetUp setup = DBHelper.GetBumpSurgeDetails(SASCCode, CustomerName);

                        bumpSurgeCalculationModel.Bump = (setup?.Bump) / 100 ?? 0;
                        bumpSurgeCalculationModel.Surge = (setup?.Surge) / 100 ?? 0;


                        if (bumpSurgeCalculationModel.Bump > 0 || bumpSurgeCalculationModel.Surge > 0)
                        {
                            SurgeAndBumpCaluclationsClass _surgeAndBumpCaluclationsClass = new SurgeAndBumpCaluclationsClass();
                            FinalBumpSurgeCalculationModel finalModel = _surgeAndBumpCaluclationsClass.SurgeBumpCaluclation(bumpSurgeCalculationModel);
                            BTTL = finalModel.Total;
                            Total = finalModel.Total;
                        }

                        else
                        {
                            Total = CRMLogicBOTTL;
                        }



                        //Makeing DB call to verify the customer Type
                        //bool isDefaultInsAll = DBHelper.DefaultInsuredRates(CustomerName);

                        //if (isDefaultInsAll)
                        //{
                        //    shipmentCoverageValue = calculatedGuarantedCalculation_Shipment.DefaultInsAllCalculation(insuredValue, CustomerName);
                        //}
                        //else
                        //{
                        //    shipmentCoverageValue = calculatedGuarantedCalculation_Shipment.NonDefaultInsAllCalculation(insuredValue);
                        //}

                        //insuredGuaranteedCRMRatingLogicRate = shipmentCoverageValue + Total;

                        //Vrirying guaranteed CRM total cost with UI
                        int j = i + 1;
                        string guaranteedInsuredCRMRatingTotalCost_UI = null;
                        //if (usertype == "External")
                        //{

                        guaranteedInsuredCRMRatingTotalCost_UI = Gettext(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-Guranteed']/tbody/tr[" + j + "]/td[5]/ul[1]/li[1]");
                        //}
                        //else
                        //{
                        //    guaranteedInsuredCRMRatingTotalCost_UI = Gettext(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-Guranteed']/tbody/tr[" + j + "]/td[6]/ul[1]/li[1]");
                        //}
                        string[] ActualGuaranteedTotalcostUI = guaranteedInsuredCRMRatingTotalCost_UI.Split(' ');
                        guaranteedInsuredCRMRatingTotalCost_UI = ActualGuaranteedTotalcostUI[1];

                        string ActualguaranteedCarrierTotalCost = Total.ToString();
                        decimal GarTotalCost = Decimal.Parse(ActualguaranteedCarrierTotalCost);
                        string CalculatedGuaranteed_TotalCost = "$" + Math.Round(GarTotalCost, 2);
                        Assert.AreEqual(guaranteedInsuredCRMRatingTotalCost_UI, CalculatedGuaranteed_TotalCost);

                    }
                }
            }
        }

        [Given(@"The values entered in the Length field of an any item is equal to or greater than (.*) FT")]
        public void GivenTheValuesEnteredInTheLengthFieldOfAnAnyItemIsEqualToOrGreaterThanFT(string Value)
        {
            Report.WriteLine("Values entered in the Length field of any item is equal to or greater than");

            scrollpagedown();
            scrollpagedown();

            Click(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);

            Click(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id);
            IList<IWebElement> ClassAndItemDropdown = GlobalVariables.webDriver.FindElements(By.XPath("FreightDescription_ClassList_Xpath"));
            int ClassAndItemDropdownCount = ClassAndItemDropdown.Count;
            for (int i = 0; i < ClassAndItemDropdownCount; i++)
            {
                if (ClassAndItemDropdown[i].Text == SavedItem)
                {
                    ClassAndItemDropdown[i].Click();
                    break;
                }
            }

            SendKeys(attributeName_id, FreightDesp_FirstItem_Quantity_Id, Quantity.ToString());
            SendKeys(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id, ItemDescription);
            SendKeys(attributeName_id, FreightDesp_FirstItem_Weight_Id, Weight.ToString());
            SendKeys(attributeName_id, FreightDesp_FirstItem_Length_Id, Value);
        }



    }
}
