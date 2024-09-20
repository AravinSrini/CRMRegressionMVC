using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper;
using CRM.UITest.Helper.DataModels;
using CRM.UITest.Objects;
using CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Results;
using Microsoft.IdentityModel.Protocols;
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
    public class BLHCalculationSteps : Quotelist
    {
        List<IndividualAccessorialModel> rlist = null;
        RatingCalculationMethods rateCal = new RatingCalculationMethods();
        public BumpSurgeCalculationModel bumpSurgeCalculationModel = new BumpSurgeCalculationModel();
        decimal BOLH = 0;
        decimal BOTFACC = 0;
        decimal BLH = 0;
        decimal BOTTL = 0;
        string username = null;
        decimal fuelSurcharge = 0;
        string firstCarrierval = null;

        [Given(@"I am an DLS user who have access to the application")]
        public void GivenIAmAnDLSUserWhoHaveAccessToTheApplication()
        {
            username = ConfigurationManager.AppSettings["username-Both"].ToString();
            string password = ConfigurationManager.AppSettings["password-Both"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"I pass values to all the required fields in the quotes information page")]
        public void GivenIPassValuesToAllTheRequiredFieldsInTheQuotesInformationPage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, QuoteIcon_Id);
            Report.WriteLine("Navigated to Quote List Page");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, SubmitRateRequestButton_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, LTL_TileLabel_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ClearAddress_OriginId);
            SendKeys(attributeName_id, LTL_OriginZipPostal_Id, "33126");
            Click(attributeName_id, ClearAddress_DestId);
            SendKeys(attributeName_id, LTL_DestinationZipPostal_Id, "85282");
            Click(attributeName_xpath, LTL_ServiceAndAccesc_ShipFrom_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, LTL_ServiceAndAccesc_ShipFromDropdown_Xpath, "Appointment");
            Click(attributeName_xpath, LTL_ServiceAndAcces_ShipTo_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, LTL_ServiceAndAccesDropdown_ShipTo_Xpath, "COD");
            Click(attributeName_id, LTL_ClearItem_Id);
            scrollElementIntoView(attributeName_id, LTL_Classification_Id);
            Click(attributeName_id, LTL_Classification_Id);
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(LTL_ClassificationValues_Xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == "50")
                {
                    DropDownList[i].Click();
                    break;
                }
            }
            SendKeys(attributeName_id, LTL_Quan_Id, "2");
            SendKeys(attributeName_id, LTL_Weight_Id, "3");

        }

        [When(@"I Click on view rates and arrive on quotes results page")]
        public void WhenIClickOnViewRatesAndArriveOnQuotesResultsPage()
        {
            Report.WriteLine("Click on Quote Results");
            scrollElementIntoView(attributeName_id, LTL_ViewQuoteResults_Id);
            Click(attributeName_id, LTL_ViewQuoteResults_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Verifytext(attributeName_xpath, ltlQuoteResultsheader_xpath, "Quote Results (LTL)");
            Click(attributeName_xpath, LtlLeastCost_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Then(@"BLH value will be calculated")]
        public decimal ThenBLHValueWillBeCalculated()
        {
            CommonCalculations_LHBFC_BMSBTL_BM_BMAT_BMATC_BMMASteps steps = new CommonCalculations_LHBFC_BMSBTL_BM_BMAT_BMATC_BMMASteps();
            decimal BMAA = steps.ThenBMAAShouldBeCalculated("Quote", "ZZZ - GS Customer Test", "LTL", "Miami", "33126", "FL", "USA", "Tempe",
                "85282", "AZ", "USA", "50", Convert.ToDouble("2"), "skids", Convert.ToDouble("3"), "LBS", username, "Appointment", "COD");
            BaseMarkupBreakDownCalcuation step = new BaseMarkupBreakDownCalcuation();
            BOLH = step.calculateBaseMarkDownCharges("ZZZ - GS Customer Test", "service", "Miami", "33126", "FL", "USA",
                "Tempe", "85282", "AZ", "USA", "Appointment", "COD", "50", Convert.ToDouble("2"), "skids", Convert.ToDouble("3"), "Quote",
                 username, "External", "BOLH");
            bumpSurgeCalculationModel.BreakOutLineHaul = BOLH;

            BOTFACC = step.calculateBaseMarkDownCharges("ZZZ - GS Customer Test", "service", "Miami", "33126", "FL", "USA",
                "Tempe", "85282", "AZ", "USA", "Appointment", "COD", "50", Convert.ToDouble("2"), "skids", Convert.ToDouble("3"), "Quote",
                 username, "External", "BOTFACC");
            bumpSurgeCalculationModel.BreakOutAccessorialsTotal = BOTFACC;

            decimal BOFSC = step.calculateBaseMarkDownCharges("ZZZ - GS Customer Test", "service", "Miami", "33126", "FL", "USA",
                "Tempe", "85282", "AZ", "USA", "Appointment", "COD", "50", Convert.ToDouble("2"), "skids", Convert.ToDouble("3"), "Quote",
                 username, "External", "BOFSC");
            bumpSurgeCalculationModel.BreakOutFuel = BOFSC;

            BOTTL = step.calculateBaseMarkDownCharges("ZZZ - GS Customer Test", "service", "Miami", "33126", "FL", "USA",
                "Tempe", "85282", "AZ", "USA", "Appointment", "COD", "50", Convert.ToDouble("2"), "skids", Convert.ToDouble("3"), "Quote",
                 username, "External", "BOTTL");
            bumpSurgeCalculationModel.BreakOutTotal = BOTTL;


            List<IndividualAccessorialModel> apirespone = GetRatesAndCarriersAPICall.BuildIndividualAccessorialModelFromCarrierPriceSheet("ZZZ - GS Customer Test",
                "service", "Miami", "33126", "FL", "USA", "Tempe", "85282", "AZ", "USA", "Appointment", "COD", "50", Convert.ToDouble("2"), "skids",
                Convert.ToDouble("3"), "LBS", username, false);
            firstCarrierval = Gettext(attributeName_xpath, ltlCarrierName_xpath);
            List<string> carrierNames = apirespone.Select(p => p.carrierName).ToList();
            for (int i = 0; i < carrierNames.Count; i++)
            {
                if (apirespone[i].carrierName == firstCarrierval)
                {
                    fuelSurcharge = Convert.ToDecimal(apirespone[i].amount);
                    bumpSurgeCalculationModel.FuelSurgeCharge = fuelSurcharge;
                }
            }
            //return BOTFACC;
            Report.WriteLine("Calculating Bump Linehaul");
            string firstCarrier = null;


            rlist = GetRatesAndCarriersAPICall.BuildIndividualAccessorialModelFromCarrierPriceSheet("ZZZ - GS Customer Test", "service", "Miami", "33126", "FL", "USA", "Tempe", "85282", "AZ",
                "USA", "Appointment", "COD", "50", Convert.ToDouble("2"), "skids", Convert.ToDouble("3"), "LBS", username, false);
            firstCarrier = Gettext(attributeName_xpath, ltlCarrierName_xpath);
            int carriercount = 0;
            for (int j = 0; j < rlist.Count; j++)
            {

                if (rlist[j].carrierName == firstCarrier)//XPO
                {
                    carriercount += 1;
                }
            }

            string CARSCAC_COde = null;//CNWY

            for (int i = 0; i < rlist.Count; i++)//2
            {
                if (rlist[i].carrierName == firstCarrier)
                {
                    CARSCAC_COde = rlist[i].CarrierScac;
                }
            }

            CustomerAccount acc = DBHelper.GetAccountDetails_By_CustomerName("ZZZ - GS Customer Test");
            BumpSurgeCustomerSetUp setup = DBHelper.GetBumpSurgeDetails(CARSCAC_COde, "ZZZ - GS Customer Test");
            bumpSurgeCalculationModel.Bump = (setup?.Bump) / 100 ?? 0;
            bumpSurgeCalculationModel.Surge = (setup?.Surge) / 100 ?? 0;

            SurgeAndBumpCaluclationsClass _surgeAndBumpCaluclationsClass = new SurgeAndBumpCaluclationsClass();
            FinalBumpSurgeCalculationModel finalModel = _surgeAndBumpCaluclationsClass.SurgeBumpCaluclation(bumpSurgeCalculationModel);
            BLH = finalModel.LineHaul;
            return finalModel.LineHaul;
        }

        [Then(@"Calculated BLH value should match with the displayed Linehaul value in the quotes results page")]
        public void ThenCalculatedBLHValueShouldMatchWithTheDisplayedLinehaulValueInTheQuotesResultsPage()
        {
            Report.WriteLine("Calculated Bump Value should match with the UI");
            string UIBumpLineHaul = Gettext(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[4]/ul[1]/li[3]");
            Report.WriteLine("Matching displayed Bump Linehaul value with UI");
            string FinalBLH = "Line Haul: $ " + Math.Round(BLH, 2);
            Assert.AreEqual(UIBumpLineHaul, FinalBLH);
        }
    }
}