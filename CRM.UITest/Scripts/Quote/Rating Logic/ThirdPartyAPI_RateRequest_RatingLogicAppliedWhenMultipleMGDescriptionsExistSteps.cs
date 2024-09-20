using CRM.UITest.Objects;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using CRM.UITest.Helper.Common;
using CRM.UITest.Scripts.Quote.LTL.Shipment_Information_Screen.OverLength_GetQuote_LTL_;
using System.Text.RegularExpressions;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using OpenQA.Selenium;
using System.Linq;
using System;
using CRM.UITest.Entities.Proxy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CRM.UITest.Scripts.Quote.Rating_Logic
{
    [Binding]
    public class ThirdPartyAPI_RateRequest_RatingLogicAppliedWhenMultipleMGDescriptionsExistSteps : ObjectRepository
    {
        string dimensionValue = "9";
        string customerName = "ZZZ - GS Customer Test";
        string service = "LTL";
        double quantity = 6;
        string quantityUnit = "SKD";
        double weight = 300;
        string weightUnit = "LBS";
        string pickUpCityName = "Miami";
        string pickUpZipCode = "33126";
        string pickUpStateCode = "FL";
        string pickUpCountry = "USA";
        string dropUpCityName = "Tempe";
        string dropUpZipCode = "85282";
        string dropUpStateCode = "AZ";
        string dropUpCountry = "USA";
        string freightClass = "55";
        AddQuoteLTL getQuoteLTL = new AddQuoteLTL();
        WebElementOperations objWebElementOperations = new WebElementOperations();
        List<string> mgDescriptionFromDB = null;
        List<string> carrierNames;
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
        List<IndividualAccessorialModel> accessorialApiResonse = new List<IndividualAccessorialModel>();
        string userType = "Internal";
        string accessorialValue = null;
        List<IndividualAccessorialModel> standardCarriers = null;

        [Given(@"that a user has submitted a request to the RateShop API via proxy (.*)")]
        public void GivenThatAUserHasSubmittedARequestToTheRateShopAPIViaProxy(string accessorial)
        {
            Quotes_RatingLogicAppliedWhenMultipleMGDescriptionsExistSteps login = new Quotes_RatingLogicAppliedWhenMultipleMGDescriptionsExistSteps();
            login.GivenIAmAShp_InquiryShp_EntrySalesSalesManagementOperationsOrStationOwnerUsers();
            login.GivenIAmSubmittingARateRequestForLTLServiceType();
            DefineTimeOut(3000);
            accessorialValue = accessorial;
            getQuoteLTL.selectShippingToServices(accessorialValue);
            Click(attributeName_id, LTL_DestinationZipPostal_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            getQuoteLTL.EnterItemdata(freightClass, weight.ToString());
            SendKeys(attributeName_id, LTL_Quantity_Id, quantity.ToString());
            string enteredValue = Regex.Replace(dimensionValue, @"(\s+|&|'|\(|\)|<|>|#)", "");

            getQuoteLTL.EnterLWH(enteredValue, enteredValue, enteredValue, "");
            try
            {
                Click(attributeName_id, LTL_ViewQuoteResults_Id);
            }
            catch
            {
                GlobalVariables.webDriver.WaitForPageLoad();
            }
            Report.WriteLine("User has submitted a request");
        }

        [Given(@"the request contains an accessorial with (.*)")]
        public void GivenTheRequestContainsAnAccessorialWith(string mgDescription)
        {
            Report.WriteLine("the request contains an accessorial");
            mgDescriptionFromDB = DBHelper.GetAccessorialMGDescriptions(accessorialValue);
        }

        [When(@"the request is processed")]
        public void WhenTheRequestIsProcessed()
        {
            accessorialApiResonse = ProxyWebApiMgDescription.CallRateShopApi(customerName, service, pickUpCityName,
                   pickUpZipCode, pickUpStateCode, pickUpCountry, dropUpCityName, dropUpZipCode, dropUpStateCode,
                   dropUpCountry, freightClass, quantity, quantityUnit, weight, weightUnit, accessorialValue, accessorialValue);
            Report.WriteLine("the request is processed via Proxy");
        }

        [Then(@"the Individual Accessorial Charge will be applied to all carrier rates of Rate Request")]
        public void ThenTheIndividualAccessorialChargeWillBeAppliedToAllCarrierRatesOfRateRequest()
        {
            Report.WriteLine("the Individual Accessorial Charge will be applied to all carrier rates");
            scrollElementIntoView(attributeName_id, "Grid-Rate-List-Large-NonGuranteed");
            IList<IWebElement> standardCarrierNamesUI = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr/td[1]"));
            carrierNames = objWebElementOperations.GetListFromIWebElement(standardCarrierNamesUI);
            carrierNames = carrierNames.Select(m => { return m.Split(new string[] { "\r", "\r\n" }, StringSplitOptions.None)[0]; }).ToList();
            for (int i = 0; i < standardCarrierNamesUI.Count; i++)
            {
                standardCarriers = accessorialApiResonse.Where(m => (m.carrierName.ToLower() == carrierNames[i].ToLower())).ToList();
                for (int j = 0; j < standardCarriers.Count; j++)
                {
                    if (standardCarriers != null && standardCarriers[j].carrierName != null)
                    {
                        if (mgDescriptionFromDB.Contains(standardCarriers[j].discription))
                        {
                            int k = i + 1;
                            string standardCRMRatingLogicTotalCostUI = null;
                            if (userType == "External")
                            {

                                standardCRMRatingLogicTotalCostUI = Gettext(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[" + k + "]/td[4]/ul[1]/li[1]");
                            }
                            else
                            {
                                standardCRMRatingLogicTotalCostUI = Gettext(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[" + k + "]/td[5]/ul[1]/li[1]");
                            }
                            string[] actualStandardTotalcostUI = standardCRMRatingLogicTotalCostUI.Split(' ');
                            standardCRMRatingLogicTotalCostUI = actualStandardTotalcostUI[1];
                            string aPIstdtotalcost = standardCarriers[j].TotalCost;
                            decimal stdtotalcost = Decimal.Parse(aPIstdtotalcost);
                            string totalCostFromAPI = "$" + Math.Round(stdtotalcost, 2);
                            Assert.AreEqual(standardCRMRatingLogicTotalCostUI, totalCostFromAPI);
                            Report.WriteLine("UI Rate " + standardCRMRatingLogicTotalCostUI + "API Calculated Rate " + totalCostFromAPI + " matching for the carrier: "+ carrierNames[i]);
                        }
                    }
                }

            }
        }

        [Then(@"the Individual Accessorial Charge will be applied to the carrier rate of Rate Request")]
        public void ThenTheIndividualAccessorialChargeWillBeAppliedToTheCarrierRateOfRateRequest()
        {
            Report.WriteLine("the Individual Accessorial Charge will be applied to the carrier rates");
            scrollElementIntoView(attributeName_id, "Grid-Rate-List-Large-NonGuranteed");
            IList<IWebElement> standardCarrierNamesUI = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr/td[1]"));
            carrierNames = objWebElementOperations.GetListFromIWebElement(standardCarrierNamesUI);
            carrierNames = carrierNames.Select(m => { return m.Split(new string[] { "\r", "\r\n" }, StringSplitOptions.None)[0]; }).ToList();
            for (int i = 0; i < standardCarrierNamesUI.Count; i++)
            {
                standardCarriers = accessorialApiResonse.Where(m => (m.carrierName.ToLower() == carrierNames[i].ToLower())).ToList();
                for (int j = 0; j < standardCarriers.Count; j++)
                {
                    if (standardCarriers != null && standardCarriers[j].carrierName != null)
                    {
                        if (mgDescriptionFromDB.Contains(standardCarriers[j].discription))
                        {
                            int k = i + 1;
                            string standardCRMRatingLogicTotalCostUI = null;
                            if (userType == "External")
                            {

                                standardCRMRatingLogicTotalCostUI = Gettext(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[" + k + "]/td[4]/ul[1]/li[1]");
                            }
                            else
                            {
                                standardCRMRatingLogicTotalCostUI = Gettext(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[" + k + "]/td[5]/ul[1]/li[1]");
                            }
                            string[] actualStandardTotalcostUI = standardCRMRatingLogicTotalCostUI.Split(' ');
                            standardCRMRatingLogicTotalCostUI = actualStandardTotalcostUI[1];
                            string aPIstdtotalcost = standardCarriers[j].TotalCost;
                            decimal stdtotalcost = Decimal.Parse(aPIstdtotalcost);
                            string totalCostFromAPI = "$" + Math.Round(stdtotalcost, 2);
                            Assert.AreEqual(standardCRMRatingLogicTotalCostUI, totalCostFromAPI);
                            Report.WriteLine("UI Rate " + standardCRMRatingLogicTotalCostUI + "API Calculated Rate " + totalCostFromAPI + " matching for the carrier: " + carrierNames[i]);                         
                        }
                    }
                }

            }
        }

        [Then(@"the Individual Accessorial Charge will not be applied to all carrier rates of Rate Request")]
        public void ThenTheIndividualAccessorialChargeWillNotBeAppliedToAllCarrierRatesOfRateRequest()
        {
            Report.WriteLine("the Individual Accessorial Charge will not be applied to all carrier rates");
            scrollElementIntoView(attributeName_id, "Grid-Rate-List-Large-NonGuranteed");
            IList<IWebElement> standardCarrierNamesUI = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr/td[1]"));
            carrierNames = objWebElementOperations.GetListFromIWebElement(standardCarrierNamesUI);
            carrierNames = carrierNames.Select(m => { return m.Split(new string[] { "\r", "\r\n" }, StringSplitOptions.None)[0]; }).ToList();
            for (int i = 0; i < standardCarrierNamesUI.Count; i++)
            {
                standardCarriers = accessorialApiResonse.Where(m => (m.carrierName.ToLower() == carrierNames[i].ToLower())).ToList();
                for (int j = 0; j < standardCarriers.Count; j++)
                {
                    if (standardCarriers != null && standardCarriers[j].carrierName != null)
                    {
                        if (mgDescriptionFromDB != null)
                        {
                            int k = i + 1;
                            string standardCRMRatingLogicTotalCostUI = null;
                            if (userType == "External")
                            {

                                standardCRMRatingLogicTotalCostUI = Gettext(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[" + k + "]/td[4]/ul[1]/li[1]");
                            }
                            else
                            {
                                standardCRMRatingLogicTotalCostUI = Gettext(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[" + k + "]/td[5]/ul[1]/li[1]");
                            }
                            string[] actualStandardTotalcostUI = standardCRMRatingLogicTotalCostUI.Split(' ');
                            standardCRMRatingLogicTotalCostUI = actualStandardTotalcostUI[1];
                            string aPIstdtotalcost = standardCarriers[j].TotalCost;
                            decimal stdtotalcost = Decimal.Parse(aPIstdtotalcost);
                            string totalCostFromAPI = "$" + Math.Round(stdtotalcost, 2);
                            Assert.AreEqual(standardCRMRatingLogicTotalCostUI, totalCostFromAPI);
                            Report.WriteLine("UI Rate " + standardCRMRatingLogicTotalCostUI + "API Calculated Rate " + totalCostFromAPI + " matching for the carrier: " + carrierNames[i]);                            
                        }
                        else
                        {
                            Report.WriteLine("Calculation not required");
                        }
                    }
                }

            }
        }

        [Then(@"the Individual Accessorial Charge will not be applied to the carrier rate of Rate Request")]
        public void ThenTheIndividualAccessorialChargeWillNotBeAppliedToTheCarrierRateOfRateRequest()
        {
            Report.WriteLine("the Individual Accessorial Charge will not be applied to the carrier rates");
            scrollElementIntoView(attributeName_id, "Grid-Rate-List-Large-NonGuranteed");
            IList<IWebElement> standardCarrierNamesUI = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr/td[1]"));
            carrierNames = objWebElementOperations.GetListFromIWebElement(standardCarrierNamesUI);
            carrierNames = carrierNames.Select(m => { return m.Split(new string[] { "\r", "\r\n" }, StringSplitOptions.None)[0]; }).ToList();
            for (int i = 0; i < standardCarrierNamesUI.Count; i++)
            {
                standardCarriers = accessorialApiResonse.Where(m => (m.carrierName.ToLower() == carrierNames[i].ToLower())).ToList();
                for (int j = 0; j < standardCarriers.Count; j++)
                {
                    if (standardCarriers != null && standardCarriers[j].carrierName != null)
                    {
                        if (mgDescriptionFromDB != null)
                        {
                            int k = i + 1;
                            string standardCRMRatingLogicTotalCostUI = null;
                            if (userType == "External")
                            {

                                standardCRMRatingLogicTotalCostUI = Gettext(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[" + k + "]/td[4]/ul[1]/li[1]");
                            }
                            else
                            {
                                standardCRMRatingLogicTotalCostUI = Gettext(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[" + k + "]/td[5]/ul[1]/li[1]");
                            }
                            string[] actualStandardTotalcostUI = standardCRMRatingLogicTotalCostUI.Split(' ');
                            standardCRMRatingLogicTotalCostUI = actualStandardTotalcostUI[1];
                            string aPIstdtotalcost = standardCarriers[j].TotalCost;
                            decimal stdtotalcost = Decimal.Parse(aPIstdtotalcost);
                            string totalCostFromAPI = "$" + Math.Round(stdtotalcost, 2);
                            Assert.AreEqual(standardCRMRatingLogicTotalCostUI, totalCostFromAPI);
                            Report.WriteLine("UI Rate " + standardCRMRatingLogicTotalCostUI + "API Calculated Rate " + totalCostFromAPI + " matching for the carrier: " + carrierNames[i]);
                        }
                        else
                        {
                            Report.WriteLine("Calculation not required");
                        }
                    }
                }

            }
        }

    }
}
