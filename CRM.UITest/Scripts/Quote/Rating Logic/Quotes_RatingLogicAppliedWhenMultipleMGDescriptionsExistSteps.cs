using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;

namespace CRM.UITest.Scripts.Quote.Rating_Logic
{
    [Binding]
    public class Quotes_RatingLogicAppliedWhenMultipleMGDescriptionsExistSteps : ObjectRepository
    {
        string dimensionValue = "9";
        string insuredValue = "1234.50";
        string mode = "Quote";
        string customerName = "ZZZ - GS Customer Test";
        string service = "LTL";
        string originCity = "Miami";
        string originZip = "33126";
        string originState = "FL";
        string originCountry = "USA";
        string destinationCity = "Tempe";
        string destinationZip = "85282";
        string destinationState = "AZ";
        string destinationCountry = "USA";
        string classification = "50";
        double quantity = 6;
        string quantityUnit = "SKD";
        double weight = 300;
        string weightUnit = "LBS";
        string username = "Quote";
        string userType = "Internal";
        decimal Total = 0;
        string accessorialValue = null;
        AddQuoteLTL getQuoteLTL = new AddQuoteLTL();
        List<IndividualAccessorialModel> accessorialapirespone = new List<IndividualAccessorialModel>();
        List<IndividualAccessorialModel> standardCarriers = null;
        WebElementOperations objWebElementOperations = new WebElementOperations();
        List<string> carrierNames = null;
        List<string> mgDescriptionFromDB = null;
        RatingCalculation rc = new RatingCalculation();
        CommonMethodsCrm crm = new CommonMethodsCrm();
        decimal calculatedValues;

        [Given(@"I am a shp\.inquiry, shp\.entry, sales, sales management, operations, or station owner users")]
        public void GivenIAmAShp_InquiryShp_EntrySalesSalesManagementOperationsOrStationOwnerUsers()
        {
            string Username = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
            string Password = ConfigurationManager.AppSettings["password-crmOperation"].ToString();
            crm.LoginToCRMApplication(Username, Password);
        }

        [Given(@"I am submitting a rate request for LTL service type")]
        public void GivenIAmSubmittingARateRequestForLTLServiceType()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            GetQuoteLTL navigation = new GetQuoteLTL();
            navigation.GetQuoteLTL_Navigation(customerName);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ClearAddress_FromId);
            getQuoteLTL.EnterOriginZip(originZip);
            Click(attributeName_id, ClearAddress_DestId);
            getQuoteLTL.EnterDestinationZip(destinationZip);
            Report.WriteLine("I am on Get Quote(LTL) page and passed zip codes");
        }

        [Given(@"I selected an accessorial with (.*)")]
        public void GivenISelectedAnAccessorialWith(string mgDescription)
        {
            accessorialValue = mgDescription;
            DefineTimeOut(3000);
            getQuoteLTL.selectShippingToServices(mgDescription);

            Click(attributeName_id, LTL_OriginZipPostal_Id);
            getQuoteLTL.EnterItemdata(classification, weight.ToString());
            SendKeys(attributeName_id, LTL_Quantity_Id, quantity.ToString());
            string enteredValue = Regex.Replace(dimensionValue, @"(\s+|&|'|\(|\)|<|>|#)", "");
            getQuoteLTL.EnterLWH(enteredValue, enteredValue, enteredValue, "");
            List<string> AccessorialUIValues = new List<string>();
            IList<IWebElement> AccessorialListUI = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='servicesaccessorialsfrom_chosen']//ul/li/span"));
            int AccessorialListUICount = AccessorialListUI.Count;
            for (int a = 0; a < AccessorialListUICount; a++)
            {
                string stationNameUI = AccessorialListUI[a].Text.ToString();
                AccessorialUIValues.Add(stationNameUI);
            }

            for (int i = 0; i < AccessorialListUICount; i++)
            {
                if (AccessorialListUI[i].Text.Equals("Overlength"))
                {
                    Click(attributeName_xpath, LTL_Quote_EnteredLengthExceedsPopUp_RemoveOption_Item_Xpath);
                }
            }            
            SendKeys(attributeName_xpath, LTL_EnterInsuredValue_Xpath, insuredValue);
        }

        [Given(@"the CRM Rating Logic is selected Yes for the customer")]
        public void GivenTheCRMRatingLogicIsSelectedYesForTheCustomer()
        {            
            bool iSCrmRatingLogicGainshareCustomer = DBHelper.CheckNewCrmRatingLogic(customerName);
            if (iSCrmRatingLogicGainshareCustomer)
            {
                Report.WriteLine("Selected Customer is assigned with CRM Rating Logic Yes");
            }
            else
            {
                Report.WriteFailure("Selected Customer is assigned with CRM Rating Logic Yes");
            }
        }

        [When(@"I submit the request")]
        public void WhenISubmitTheRequest()
        {
            Report.WriteLine("Click on Submit Rate Request button");
            scrollpagedown();
            try
            {
                Click(attributeName_id, LTL_ViewQuoteResults_Id);
            }
            catch
            {
                GlobalVariables.webDriver.WaitForPageLoad();
            }

        }

        [When(@"CRM receives one of the MG Descriptions of the selected accessorial")]
        public void WhenCRMReceivesOneOfTheMGDescriptionsOfTheSelectedAccessorial()
        {
            Report.WriteLine("CRM receives one of the MG Descriptions of the selected accessorial");
            mgDescriptionFromDB = DBHelper.GetAccessorialMGDescriptions(accessorialValue);
        }

        [Then(@"the Individual Accessorial Charge will be applied to all carrier rates")]
        public void ThenTheIndividualAccessorialChargeWillBeAppliedToAllCarrierRates()
        {
            Report.WriteLine("the Individual Accessorial Charge will be applied to all carrier rates");
            scrollElementIntoView(attributeName_id, "Grid-Rate-List-Large-NonGuranteed");
            IList<IWebElement> standardCarrierNamesUI = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr/td[1]"));
            carrierNames = objWebElementOperations.GetListFromIWebElement(standardCarrierNamesUI);
            carrierNames = carrierNames.Select(m => { return m.Split(new string[] { "\r", "\r\n" }, StringSplitOptions.None)[0]; }).ToList();

            accessorialapirespone = GetRatesAndCarriersAPICall.BuildIndividualAccessorialModelFromCarrierPriceSheet(customerName,
            service, originCity, originZip, originState, originCountry, destinationCity, destinationZip, destinationState, destinationCountry,
            accessorialValue, accessorialValue, classification, quantity, quantityUnit, weight, weightUnit, username, false);

            for (int i = 0; i < standardCarrierNamesUI.Count; i++)
            {
                standardCarriers = accessorialapirespone.Where(m => (m.carrierName.ToLower() == carrierNames[i].ToLower())).ToList();
                for (int j = 0; j < standardCarriers.Count; j++)
                {
                    string scacCode = standardCarriers[j].CarrierScac;
                    if (standardCarriers != null && standardCarriers[j].carrierName != null)
                    {
                        if (mgDescriptionFromDB.Contains(standardCarriers[j].discription))
                        {
                            calculatedValues = rc.CRMRatingLogicWithMGDescription(mode, customerName, service, originCity, originZip, originState, originCountry,
                                destinationCity, destinationZip, destinationState, destinationCountry, classification, quantity, quantityUnit,
                                weight, weightUnit, username, accessorialValue, accessorialValue, standardCarriers[j].carrierName, scacCode);

                            decimal standardTotalCost = Decimal.Parse(calculatedValues.ToString());

                            //Verifying standard CRM total cost with UI
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
                            string calculatedStandardTotalCost = "$" + Math.Round(standardTotalCost, 2);
                            Assert.AreEqual(standardCRMRatingLogicTotalCostUI, calculatedStandardTotalCost);
                            Report.WriteLine("UI Rate " + standardCRMRatingLogicTotalCostUI + "API Calculated Rate " + calculatedStandardTotalCost + "matching for the Carrier");
                        }

                    }
                }
            }
        }

        [Then(@"the Individual Accessorial Charge will be applied to the carrier rate")]
        public void ThenTheIndividualAccessorialChargeWillBeAppliedToTheCarrierRate()
        {
            Report.WriteLine("the Individual Accessorial Charge will be applied to the carrier rate");
            scrollElementIntoView(attributeName_id, "Grid-Rate-List-Large-NonGuranteed");
            IList<IWebElement> standardCarrierNamesUI = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr/td[1]"));
            carrierNames = objWebElementOperations.GetListFromIWebElement(standardCarrierNamesUI);
            carrierNames = carrierNames.Select(m => { return m.Split(new string[] { "\r", "\r\n" }, StringSplitOptions.None)[0]; }).ToList();

            accessorialapirespone = GetRatesAndCarriersAPICall.BuildIndividualAccessorialModelFromCarrierPriceSheet(customerName,
            service, originCity, originZip, originState, originCountry, destinationCity, destinationZip, destinationState, destinationCountry,
            accessorialValue, accessorialValue, classification, quantity, quantityUnit, weight, weightUnit, username, false);

            for (int i = 0; i < standardCarrierNamesUI.Count; i++)
            {
                standardCarriers = accessorialapirespone.Where(m => (m.carrierName.ToLower() == carrierNames[i].ToLower())).ToList();
                for (int j = 0; j < standardCarriers.Count; j++)
                {
                    string scacCode = standardCarriers[j].CarrierScac;
                    if (standardCarriers != null && standardCarriers[j].carrierName != null)
                    {
                        if (mgDescriptionFromDB.Contains(standardCarriers[j].discription))
                        {
                            calculatedValues = rc.CRMRatingLogicWithMGDescription(mode, customerName, service, originCity, originZip, originState, originCountry,
                                destinationCity, destinationZip, destinationState, destinationCountry, classification, quantity, quantityUnit,
                                weight, weightUnit, username, accessorialValue, accessorialValue, standardCarriers[j].carrierName, scacCode);

                            decimal standardTotalCost = Decimal.Parse(calculatedValues.ToString());
                            //Verifying standard CRM total cost with UI
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

                            string calculatedStandardTotalCost = "$" + Math.Round(standardTotalCost, 2);
                            Assert.AreEqual(standardCRMRatingLogicTotalCostUI, calculatedStandardTotalCost);
                            Report.WriteLine("UI Rate " + standardCRMRatingLogicTotalCostUI + "API Calculated Rate " + calculatedStandardTotalCost + "matching for the Carrier");
                        }

                    }
                }
            }

        }

        [Then(@"the Individual Accessorial Charge will not be applied to all carrier rates")]
        public void ThenTheIndividualAccessorialChargeWillNotBeAppliedToAllCarrierRates()
        {
            Report.WriteLine("the Individual Accessorial Charge will not be applied to all carrier rates");
            scrollElementIntoView(attributeName_id, "Grid-Rate-List-Large-NonGuranteed");
            IList<IWebElement> standardCarrierNamesUI = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr/td[1]"));
            carrierNames = objWebElementOperations.GetListFromIWebElement(standardCarrierNamesUI);
            carrierNames = carrierNames.Select(m => { return m.Split(new string[] { "\r", "\r\n" }, StringSplitOptions.None)[0]; }).ToList();

            accessorialapirespone = GetRatesAndCarriersAPICall.BuildIndividualAccessorialModelFromCarrierPriceSheet(customerName,
            service, originCity, originZip, originState, originCountry, destinationCity, destinationZip, destinationState, destinationCountry,
            accessorialValue, accessorialValue, classification, quantity, quantityUnit, weight, weightUnit, username, false);

            for (int i = 0; i < standardCarrierNamesUI.Count; i++)
            {
                standardCarriers = accessorialapirespone.Where(m => (m.carrierName.ToLower() == carrierNames[i].ToLower())).ToList();
                for (int j = 0; j < standardCarriers.Count; j++)
                {
                    string scacCode = standardCarriers[j].CarrierScac;
                    if (standardCarriers != null && standardCarriers[j].carrierName != null)
                    {

                        if (mgDescriptionFromDB != null)
                        {
                            calculatedValues = rc.CRMRatingLogic(mode, customerName, service, originCity, originZip, originState, originCountry,
                            destinationCity, destinationZip, destinationState, destinationCountry, classification, quantity, quantityUnit,
                            weight, weightUnit, username, accessorialValue, accessorialValue, standardCarriers[j].carrierName, scacCode);

                            decimal standardTotalCost = Decimal.Parse(calculatedValues.ToString());
                            //Verifying standard CRM total cost with UI
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

                            string calculatedStandardTotalCost = "$" + Math.Round(standardTotalCost, 2);
                            Assert.AreEqual(standardCRMRatingLogicTotalCostUI, calculatedStandardTotalCost);
                            Report.WriteLine("UI Rate " + standardCRMRatingLogicTotalCostUI + "API Calculated Rate " + calculatedStandardTotalCost + "matching for the Carrier");
                        }
                        else
                        {
                            Report.WriteLine("No calculation required");
                        }
                    }
                }
            }
        }


        [Then(@"the Individual Accessorial Charge will not be applied to the carrier rate")]
        public void ThenTheIndividualAccessorialChargeWillNotBeAppliedToTheCarrierRate()
        {
            Report.WriteLine("the Individual Accessorial Charge will not be applied to the carrier rates");
            scrollElementIntoView(attributeName_id, "Grid-Rate-List-Large-NonGuranteed");
            IList<IWebElement> standardCarrierNamesUI = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr/td[1]"));
            carrierNames = objWebElementOperations.GetListFromIWebElement(standardCarrierNamesUI);
            carrierNames = carrierNames.Select(m => { return m.Split(new string[] { "\r", "\r\n" }, StringSplitOptions.None)[0]; }).ToList();

            accessorialapirespone = GetRatesAndCarriersAPICall.BuildIndividualAccessorialModelFromCarrierPriceSheet(customerName,
            service, originCity, originZip, originState, originCountry, destinationCity, destinationZip, destinationState, destinationCountry,
            accessorialValue, accessorialValue, classification, quantity, quantityUnit, weight, weightUnit, username, false);

            for (int i = 0; i < standardCarrierNamesUI.Count; i++)
            {
                standardCarriers = accessorialapirespone.Where(m => (m.carrierName.ToLower() == carrierNames[i].ToLower())).ToList();
                for (int j = 0; j < standardCarriers.Count; j++)
                {
                    string scacCode = standardCarriers[j].CarrierScac;
                    if (standardCarriers != null && standardCarriers[j].carrierName != null)
                    {
                        if (mgDescriptionFromDB != null)
                        {
                            calculatedValues = rc.CRMRatingLogic(mode, customerName, service, originCity, originZip, originState, originCountry,
                            destinationCity, destinationZip, destinationState, destinationCountry, classification, quantity, quantityUnit,
                            weight, weightUnit, username, accessorialValue, accessorialValue, standardCarriers[j].carrierName, scacCode);

                            decimal standardTotalCost = Decimal.Parse(calculatedValues.ToString());
                            //Verifying standard CRM total cost with UI
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

                            string calculatedStandardTotalCost = "$" + Math.Round(standardTotalCost, 2);
                            Assert.AreEqual(standardCRMRatingLogicTotalCostUI, calculatedStandardTotalCost);
                            Report.WriteLine("UI Rate " + standardCRMRatingLogicTotalCostUI + "API Calculated Rate " + calculatedStandardTotalCost + "matching for the carrierName");
                        }
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
