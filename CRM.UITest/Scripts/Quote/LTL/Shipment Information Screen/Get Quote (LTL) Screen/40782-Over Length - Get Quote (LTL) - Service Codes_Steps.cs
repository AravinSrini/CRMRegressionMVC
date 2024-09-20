using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper;
using CRM.UITest.Helper.DataModels;
using CRM.UITest.Helper.ViewModel;
using CRM.UITest.Objects;
using CRM.UITest.Scripts.Quote.LTL.Quote_Results_Screen;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Quote.LTL.Shipment_Information_Screen.OverLength_GetQuote_LTL_
{
    [Binding]
    public class _40782_Over_Length___Get_Quote__LTL____Service_Codes_Steps : ObjectRepository
    {
        AddQuoteLTL quote = new AddQuoteLTL();
        string accessorial = "Overlength";
        string CustomerName = "ZZZ - GS Customer Test";
        string Service = "LTL";
        string OriginCity = "Miami";
        string OriginZip = "33126";
        string OriginState = "FL";
        string OriginCountry = "USA";
        string DestinationCity = "Tempe";
        string DestinationZip = "85282";
        string DestinationState = "AZ";
        string DestinationCountry = "USA";
        string OAccessorial;
        string DAccessorial;
        string Classification = "50";
        double Quantity = 1;
        
        double Weight = 4;
       
        string Username = "zzzext";
        List<RateResultCarrierViewModel> rlist = null;
        List<IndividualAccessorialModel> accessorialapirespone = null;
     
        bool iSCrmRatingLogic_GainshareCustomer;
        string dimensionValue;
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();

        [Given(@"I am a shp\.inquiry, shp\.entry, sales, sales management, operations, or station owner user,")]
        public void GivenIAmAShp_InquiryShp_EntrySalesSalesManagementOperationsOrStationOwnerUser()
        {
            Report.WriteLine("I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner user");
            string userName = ConfigurationManager.AppSettings["username-Both"].ToString();
            string password = ConfigurationManager.AppSettings["password-Both"].ToString();
            CrmLogin.LoginToCRMApplication(userName, password);
            Report.WriteLine("I logged into CRM application with external user credentials");
        }

        [Given(@"I am on the Get Quote \(LTL\) page rate request process")]
        public void GivenIAmOnTheGetQuoteLTLPageRateRequestProcess()
        {
            Report.WriteLine("I am on the Get Quote (LTL) page");

            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, ".//*[@id='raterequest']/i");
            Report.WriteLine("Navigated to Quote list page");

            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Click on Submit Rate Request");
            Click(attributeName_id, SubmitRateRequestButton_Id);

            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Click on LTL tile");
            Click(attributeName_id, LTL_TileLabel_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
        }



        public WebElementOperations objWebElementOperations = new WebElementOperations();
        CRMRatingLogic_GuaranteedRateCalculation_QuoteResultsSteps crmRating = new CRMRatingLogic_GuaranteedRateCalculation_QuoteResultsSteps();
        List<string> standardCarrierNames = null;
        BumpSurgeCalculationModel bumpSurgeCalculationModel = new BumpSurgeCalculationModel();

        [Given(@"Over Length is selected in the (.*) field")]
        public void GivenOverLengthIsSelectedInTheField(string p0)
        {
            
            quote.selectShippingfromServices(accessorial);
            quote.EnterOriginZip(OriginZip);
            quote.EnterDestinationZip(DestinationZip);
            quote.EnterItemdata(Classification, Convert.ToString(Weight));

        }


        [Given(@"the values entered in the Length field of an item is equal to or greater (.*) IN")]
        public void GivenTheValuesEnteredInTheLengthFieldOfAnItemIsEqualToOrGreaterIN(string value)
        {
            Report.WriteLine("the values entered in the Length field of an item is equal to or greater (.*) IN");
            string enteredValue = Regex.Replace(value, @"(\s+|&|'|\(|\)|<|>|#)", "");

            EnterValuesinDimentionFiledS(enteredValue);
        }

        [Given(@"the values entered in the Length field of an item is LESS than the ninety six (.*) IN")]
        public void GivenTheValuesEnteredInTheLengthFieldOfAnItemIsLESSThanTheNinetySixIN(string value)
        {
            Report.WriteLine("the values entered in the Length field of an item is equal to or greater (.*) IN");
            string enteredValue = Regex.Replace(value, @"(\s+|&|'|\(|\)|<|>|#)", "");
            EnterValuesinDimentionFiledS(enteredValue);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"the values entered in the Length field of an item is LESS than the eight (.*) FT")]
        public void GivenTheValuesEnteredInTheLengthFieldOfAnItemIsLESSThanTheEightFT(string value)
        {
            Report.WriteLine("the values entered in the Length field of an item is LESS than the eight (.*) FT");
            string enteredValue = Regex.Replace(value, @"(\s+|&|'|\(|\)|<|>|#)", "");
            EnterValuesinDimentionFiledS(enteredValue);
        }



        [Given(@"the values entered in the Length field of an item is equal to or greater (.*) FT")]
        public void GivenTheValuesEnteredInTheLengthFieldOfAnItemIsEqualToOrGreaterFT(string value)
        {
            Report.WriteLine("the values entered in the Length field of an item is equal to or greater (.*) FT");
            string enteredValue = Regex.Replace(value, @"(\s+|&|'|\(|\)|<|>|#)", "");
            Click(attributeName_xpath, LTL_Quote_Item_DimensionType_dropdown_Xpath);
            IList<IWebElement> dimensionUI_List = GlobalVariables.webDriver.FindElements(By.XPath(LTL_Quote_Item_DimensionType_dropdownList_Xpath));
           
            int dimensionListCount = dimensionUI_List.Count;
            for (int i = 0; i < dimensionListCount; i++)
            {
                if (dimensionUI_List[i].Text == "FT")
                {

                    dimensionUI_List[i].Click();
                    break;
                }
            }
            EnterValuesinDimentionFiledS(enteredValue);
        }




        [When(@"I click on the View Quote Results button on Get Quote \(LTL\) page")]
        public void WhenIClickOnTheViewQuoteResultsButtonOnGetQuoteLTLPage()
        {
            Click(attributeName_xpath, "//div[@id='Length-Additional-Warning-0']//i[2]");

            Thread.Sleep(5000);
            //GlobalVariables.webDriver.WaitForPageLoad();
            //WaitForElementVisible(attributeName_id, LTL_ViewQuoteResults_Id,"View Results");
            quote.ClickViewRates();
            GlobalVariables.webDriver.WaitForPageLoad();
        }

      

        [Then(@"CRM will not send any Over Length Service Code to MG (.*),(.*)")]
        public void ThenCRMWillNotSendAnyOverLengthServiceCodeToMG(string value, string dimensionType)
        {
            ThenCRMWillSendTheAssociatedOverLengthServiceCodeToMG(value, dimensionType);
        }


        [Then(@"CRM will send the associated Over Length Service Code to MG (.*),(.*)")]
        public void ThenCRMWillSendTheAssociatedOverLengthServiceCodeToMG(string value, string dimensionType)
        {
            dimensionValue= Regex.Replace(value, @"(\s+|&|'|\(|\)|<|>|#)", "");
            dimensionType = Regex.Replace(dimensionType, @"(\s+|&|'|\(|\)|<|>|#)", "");
            OAccessorial = GetOverlengthAccessorialServiceCode(Convert.ToInt32(dimensionValue), dimensionType);
            string WeightUnit = "lbs";
            string QuantityUNIT = "skids";
            WeightUnit = "LBS";
            iSCrmRatingLogic_GainshareCustomer = DBHelper.CheckNewCrmRatingLogic(CustomerName);

           

            if (iSCrmRatingLogic_GainshareCustomer)
            {
               rlist = GetRatesAndCarriersAPICall.CallRateRequestApiWithAccessorials(CustomerName,
                   Service,
                   OriginCity,
                   OriginZip,
                   OriginState,
                   OriginCountry,
                   DestinationCity,
                   DestinationZip,
                   DestinationState,
                   DestinationCountry,
                   OAccessorial,
                   DAccessorial,
                   Classification,
                   Quantity,
                   QuantityUNIT,
                   Weight,
                   WeightUnit,
                   Username, false);

               accessorialapirespone = GetRatesAndCarriersAPICall.BuildIndividualAccessorialModelFromCarrierPriceSheet(CustomerName,
               Service,
               OriginCity,
               OriginZip,
               OriginState,
               OriginCountry,
               DestinationCity,
               DestinationZip,
               DestinationState,
               DestinationCountry,
               OAccessorial,
               DAccessorial,
               Classification,
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
                 OriginZip,
                 OriginState,
                 OriginCountry,
                 DestinationCity,
                 DestinationZip,
                 DestinationState,
                 DestinationCountry,
                 OAccessorial,
                 DAccessorial,
                 Classification,
                 Quantity,
                 QuantityUNIT,
                 Weight,
                 WeightUnit,
                 Username, false);
            }

        }

        [Then(@"Total cost should be matched with API")]
        public void ThenTotalCostShouldBeMatchedWithAPI()
        {
            //Getting all the standard carrier name from UI
            IList<IWebElement> standardCarrierNamesUI = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr/td[1]"));
            standardCarrierNames = objWebElementOperations.GetListFromIWebElement(standardCarrierNamesUI);
            standardCarrierNames = standardCarrierNames.Select(m => { return m.Split(new string[] { "\r", "\r\n" }, StringSplitOptions.None)[0]; }).ToList();

            if (iSCrmRatingLogic_GainshareCustomer==false) {

                for (int i = 0; i < standardCarrierNamesUI.Count; i++)
                {
                    RateResultCarrierViewModel standardCarrierResponse = rlist.Where(m => (m.CarrierName.ToLower() == standardCarrierNames[i].ToLower() && !m.IsGuaranteedCarrier && !m.IsGuaranteedCarrierPrice)).FirstOrDefault();

                    if (standardCarrierResponse != null && standardCarrierResponse.CarrierName != null)
                    {
                        //Verifying standard rates UI with API response for External users
                        if (standardCarrierNames[i].Equals(standardCarrierResponse.CarrierName))
                        {
                            string carrierRate = Gettext(attributeName_xpath, "//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[" + (i + 1) + "]/td[4]/ul/li[@class='rate-col-tot']");

                            Assert.AreEqual(carrierRate, "* $" + standardCarrierResponse.Charges[0].TotalCost);
                        }
                    }
                }
            }
            else
            {

                Report.WriteLine("Please select the coustmer which has CRM rating logic No");
                //for (int i = 0; i < standardCarrierNamesUI.Count; i++)
                //{
                //    RateResultCarrierViewModel standardCarrierResponse = rlist.Where(m => (m.CarrierName.ToLower() == standardCarrierNames[i].ToLower())).FirstOrDefault();

                //    IndividualAccessorialModel StdCarrier = accessorialapirespone.Where(m => (m.carrierName.ToLower() == standardCarrierNames[i].ToLower())).FirstOrDefault();
                //    //RateResultCarrierViewModel stdCarrier = apirespone.Where(m => (m.CarrierName.ToLower() == guaranteedCarrierNames[i].ToLower())).FirstOrDefault();
                //    string SASCCode = standardCarrierResponse.ScacCode;


                //    if (standardCarrierResponse != null && standardCarrierResponse.CarrierName != null)
                //    {
                //        string aPIstdtotalcost = StdCarrier.TotalCost;
                //        decimal stdtotalcost = Decimal.Parse(aPIstdtotalcost);

                //        //calculate guaranteedRate DB
                //        decimal guaranteedRate = 0;

                //        //Calling BMAA method

                //        crmRating.GetInitilzeApi(accessorialapirespone);

                //        BMAA = crmRating.GetGuaranteedBMAAValue(CustomerName, Service, OriginCity, OriginZip, OriginState,
                //                                     OriginCountry, DestinationCity, DestinationZip, DestinationState, DestinationCountry, Classification,
                //                                     Quantity, QuantityUNIT, Weight, WeightUnit, Username, OAccessorial, DAccessorial,
                //                                     standardCarrierResponse.CarrierName, guaranteedRate);

                //        // Calling Breakoout method

                //        MACC = crmRating.GetMACC(CustomerName, Service, OriginCity, OriginZip, OriginState,
                //                OriginCountry, DestinationCity, DestinationZip, DestinationState, DestinationCountry, OAccessorial, DAccessorial,
                //                Classification, Quantity, QuantityUNIT, Weight, Username, standardCarrierResponse.CarrierName);

                //        BOLH = crmRating.GetBOLH(standardCarrierResponse.CarrierName, guaranteedRate);
                //        bumpSurgeCalculationModel.BreakOutLineHaul = BOLH;



                //        BOFSC = crmRating.GetBOFSC(standardCarrierResponse.CarrierName);
                //        bumpSurgeCalculationModel.BreakOutFuel = BOFSC;

                //        //GuaranteedRateAccessorial with CRM Rating logic
                //        //decimal guaranteedRateWithCRMRatingLogic = calculatedGuarantedCalculation_Shipment.GetCRMRatingGuranteedRate(Customer_Name, guaranteedRate, SASCCode);



                //        BOTFACC = crmRating.GetBOTFACC(CustomerName, standardCarrierResponse.CarrierName);
                //        //bumpSurgeCalculationModel.BreakOutAccessorialsTotal = BOTFACC + guaranteedRateWithCRMRatingLogic;


                //        decimal BOTTL = BOLH + BOFSC + BOTFACC;
                //        bumpSurgeCalculationModel.BreakOutTotal = BOTTL;



                //        //Verifying CRM Rating Logic standard guaranteed with UI
                //       // decimal guaranteedCRMLogicBOTFACC = BOTFACC + guaranteedRateWithCRMRatingLogic;
                //        decimal CRMLogicBOTTL = BOTFACC + BOLH + BOFSC;

                //        //adding bump and surge
                //        BumpSurgeCustomerSetUp setup = DBHelper.GetBumpSurgeDetails(SASCCode, CustomerName);

                //        bumpSurgeCalculationModel.Bump = (setup?.Bump) / 100 ?? 0;
                //        bumpSurgeCalculationModel.Surge = (setup?.Surge) / 100 ?? 0;


                //        if (bumpSurgeCalculationModel.Bump > 0 || bumpSurgeCalculationModel.Surge > 0)
                //        {
                //            SurgeAndBumpCaluclationsClass _surgeAndBumpCaluclationsClass = new SurgeAndBumpCaluclationsClass();
                //            FinalBumpSurgeCalculationModel finalModel = _surgeAndBumpCaluclationsClass.SurgeBumpCaluclation(bumpSurgeCalculationModel);
                //            BTTL = finalModel.Total;
                //            Total = finalModel.Total;
                //        }

                //        else
                //        {
                //            Total = CRMLogicBOTTL;
                //        }



                     

                //        //Vrirying guaranteed CRM total cost with UI
                //        int j = i + 1;
                //        string guaranteedInsuredCRMRatingTotalCost_UI = null;
                       
                //            guaranteedInsuredCRMRatingTotalCost_UI = Gettext(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-Guranteed']/tbody/tr[" + j + "]/td[5]/ul[1]/li[1]");
                      
                //        string[] ActualGuaranteedTotalcostUI = guaranteedInsuredCRMRatingTotalCost_UI.Split(' ');
                //        guaranteedInsuredCRMRatingTotalCost_UI = ActualGuaranteedTotalcostUI[1];

                //        string ActualguaranteedCarrierTotalCost = Total.ToString();
                //        decimal GarTotalCost = Decimal.Parse(ActualguaranteedCarrierTotalCost);
                //        string CalculatedGuaranteed_TotalCost = "$" + Math.Round(GarTotalCost, 2);
                //        Assert.AreEqual(guaranteedInsuredCRMRatingTotalCost_UI, CalculatedGuaranteed_TotalCost);

                //    }
                //}
            }
        }


        public string GetOverlengthAccessorialServiceCode(int value, String DimensionType)
        {
            string serviceCode = null;

            if (DimensionType.Equals("FT") && value>7)
            {
                switch (value)
                {
                    case 8:
                        serviceCode = "OVL08";
                        break;
                    case 9:
                        serviceCode = "OVL09";
                        break;
                    case 10:
                        serviceCode = "OVL" + value;
                        break;
                    case 11:
                        serviceCode = "OVL" + value;
                        break;
                    case 12:
                        serviceCode = "OVL" + value;
                        break;
                    case 13:
                        serviceCode = "OVL" + value;
                        break;
                    case 14:
                        serviceCode = "OVL" + value;
                        break;
                    case 15:
                        serviceCode = "OVL" + value;
                        break;
                    case 16:
                        serviceCode = "OVL" + value;
                        break;
                    case 17:
                        serviceCode = "OVL" + value;
                        break;
                    case 18:
                        serviceCode = "OVL" + value;
                        break;
                    case 19:
                        serviceCode = "OVL" + value;
                        break;
                    case 20:
                        serviceCode = "OVL" + value;
                        break;
                    case 21:
                        serviceCode = "OVL" + value;
                        break;
                    case 22:
                        serviceCode = "OVL" + value;
                        break;
                    case 23:
                        serviceCode = "OVL" + value;
                        break;
                    case 24:
                        serviceCode = "OVL" + value;
                        break;

                    case 25:
                        serviceCode = "OVL" + value;
                        break;
                    case 26:
                        serviceCode = "OVL" + value;
                        break;
                    case 27:
                        serviceCode = "OVL" + value;
                        break;
                    case 28:
                        serviceCode = "OVL" + value;
                        break;
                    case 29:
                        serviceCode = "OVL" + value;
                        break;
                    case 30:
                        serviceCode = "OVL" + value;
                        break;
                    default:
                        serviceCode = "OVL30PLUS";
                        break;


                }

            }
                if (DimensionType.Equals("IN"))
                {
                    if (value >= 96 && value <= 107)
                    {
                        serviceCode = "OVL08";
                    }
                    else if (value >= 108 && value <= 119)
                    {
                        serviceCode = "OVL09";
                    }
                    else if(value >= 120 && value <= 131)
                    {
                        serviceCode = "OVL10";
                    }
                    else if(value >= 132 && value <= 143)
                    {
                        serviceCode = "OVL11";
                    }
                    else if (value >= 144 && value <= 155)
                    {
                        serviceCode = "OVL12";
                    }
                    else if (value >= 156 && value <= 167)
                    {
                        serviceCode = "OVL13";
                    }
                    else if (value >= 168 && value <= 179)
                    {
                        serviceCode = "OVL14";
                    }
                    else if (value >= 180 && value <= 191)
                    {
                        serviceCode = "OVL15";
                    }
                    else if (value >= 192 && value <= 203)
                    {
                        serviceCode = "OVL16";
                    }
                    else if (value >= 204 && value <= 215)
                    {
                        serviceCode = "OVL17";
                    }
                    else if (value >= 216 && value <= 227)
                    {
                        serviceCode = "OVL18";
                    }
                    else if (value >= 119 && value <= 132)
                    {
                        serviceCode = "OVL19";
                    }
                    else if (value >= 229 && value <= 239)
                    {
                        serviceCode = "OVL20";
                    }
                    else if (value >= 240 && value <= 251)
                    {
                        serviceCode = "OVL21";
                    }
                    else if (value >= 252 && value <= 263)
                    {
                        serviceCode = "OVL22";
                    }
                    else if (value >= 276 && value <= 287)
                    {
                        serviceCode = "OVL23";
                    }
                    else if (value >= 288 && value <= 299)
                    {
                        serviceCode = "OVL24";
                    }
                    else if (value >= 300 && value <= 311)
                    {
                        serviceCode = "OVL25";
                    }
                    else if (value >= 312 && value <= 323)
                    {
                        serviceCode = "OVL26";
                    }
                    else if (value >= 324 && value <= 335)
                    {
                        serviceCode = "OVL27";
                    }
                    else if (value >= 336 && value <= 347)
                    {
                        serviceCode = "OVL28";
                    }
                    else if (value >= 348 && value <= 359)
                    {
                        serviceCode = "OVL29";
                    }
                    else if (value >= 360 && value <= 371)
                    {
                        serviceCode = "OVL30";
                    }
                    else if (value >= 372)
                    {
                        serviceCode = "OVL30PLUS";
                    }
                
            }
            return serviceCode;
        }

        public void EnterValuesinDimentionFiledS(string value)
        {
            SendKeys(attributeName_id, LTL_Quote_Item_Length_Id, value);
            SendKeys(attributeName_id, LTL_Quote_Item_Width_Id, value);
            SendKeys(attributeName_id, LTL_Quote_Item_Height_Id, value);
        }


    }
}
