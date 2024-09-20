using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.ViewModel;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Insurance_Claims.Claim_Details
{
    [Binding]
    public class InsuranceClaims_DetailsTab_FrtCalcSectionDisplay_FieldValuesSteps : Objects.InsuranceClaim
    {
        string uiClaimNumbersFreightCharge;
        string originalFreightChargesValues_DB;
        string returnFreightChargesValues_DB;
        string returnFreightChargesDLSWNumebr_DB;
        string replacementFreightChargesValues_DB;
        string replacementFreightChargesDLSWNumebr_DB;
        string userType;
        InsuranceClaimDetailsHeaderViewModel insClaimViewModel = null;



        [Then(@"I will see Type,Claimable\?,Claimed Freight,Carreier Charges to DLSW,DLSW Charges to Cust,DLSW Ref\# Header Column and its field value is formatted")]
        public void ThenIWillSeeTypeClaimableClaimedFreightCarreierChargesToDLSWDLSWChargesToCustDLSWRefHeaderColumnAndItsFieldValueIsFormatted()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I will see Proration % and Total Claimed Freight and its value formatted")]
        public void ThenIWillSeeProrationAndTotalClaimedFreightAndItsValueFormatted()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I will an information icon displayed next to the Proration % field label")]
        public void ThenIWillAnInformationIconDisplayedNextToTheProrationFieldLabel()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I clicked any Claim reference hyperlink contains Freight Charges with Original Freight Charge")]
        public void GivenIClickedAnyClaimReferenceHyperlinkContainsFreightChargesWithOriginalFreightCharge()
        {


            Click(attributeName_id, ClaimsIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, ClaimsListPage_HeaderText_Xpath, "Claims List");
            string gridFirstColumnHeader = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/thead/tr/th[1]");
            string claimNumberInvalidCarrier;
            if (gridFirstColumnHeader == "CUSTOMER")
            {
                userType = "Internal User";
                Report.WriteLine("logged in User is Internal");
                Click(attributeName_xpath, "//label[@for='FilterByStatusPending']");
                Click(attributeName_xpath, ClaimListGrid_PageViewOption_dropdown_Xpath);
                Click(attributeName_xpath, ".//*[@id='gridInsuranceClaimList_length']/label/select/option[5]");

                List<InsuranceClaimFreight> originalFrieghtChargesDetails = DBHelper.GetOriginalFreightCharges();
                IList<IWebElement> gridClaimNumbers = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='gridInsuranceClaimList']/tbody/tr/td[4]/span/a"));
                for (int i = 1; i <= gridClaimNumbers.Count; i++)
                {
                    string uiClaimNumebrs = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr[" + i + "]/td[4]/span/a");

                    var originalFreightCheck = originalFrieghtChargesDetails.Where(x => x.ClaimNumber == Convert.ToInt32(uiClaimNumebrs)).Select(x => x.IsOriginalFreightCharges).FirstOrDefault();
                    //decimal Convert.ToDecimal(originalFreightChages);
                    if (Convert.ToBoolean(originalFreightCheck))
                    {
                        var originalFreightChages = originalFrieghtChargesDetails.Where(x => x.ClaimNumber == Convert.ToInt32(uiClaimNumebrs)).Select(x => x.OriginalFreightChargesValue).FirstOrDefault();
                        originalFreightChargesValues_DB = originalFreightChages.ToString();

                        uiClaimNumbersFreightCharge = uiClaimNumebrs;
                        insClaimViewModel = DBHelper.GetInsuranceClaimDetailsHeader(Convert.ToInt32(uiClaimNumbersFreightCharge));
                        i = gridClaimNumbers.Count + 1;
                    }
                }

                SendKeys(attributeName_xpath, ".//*[@id='gridInsuranceClaimList_filter']/label/input", uiClaimNumbersFreightCharge);
                Click(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr/td[4]/span/a/span");
            }



            else if (gridFirstColumnHeader == "STA / CUST")
            {
                userType = "Claim Specialist User";
                Report.WriteLine("logged in User is Claim Specialist User");
                Click(attributeName_xpath, "//label[@for='FilterByStatusPending']");
                Click(attributeName_xpath, ClaimListGrid_PageViewOption_dropdown_Xpath);
                Click(attributeName_xpath, ".//*[@id='gridInsuranceClaimList_length']/label/select/option[5]");
                List<InsuranceClaimFreight> originalFrieghtChargesDetails = DBHelper.GetOriginalFreightCharges();

                IList<IWebElement> gridClaimNumbers = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='gridInsuranceClaimList']/tbody/tr/td[3]/span[1]/a"));
                for (int i = 1; i <= gridClaimNumbers.Count; i++)
                {
                    string uiClaimNumebrs = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr[" + i + "]/td[3]/span[1]/a");

                    var originalFreightCheck = originalFrieghtChargesDetails.Where(x => x.ClaimNumber == Convert.ToInt32(uiClaimNumebrs)).Select(x => x.IsOriginalFreightCharges).FirstOrDefault();
                    //decimal Convert.ToDecimal(originalFreightChages);
                    if (Convert.ToBoolean(originalFreightCheck))
                    {
                        var originalFreightChages = originalFrieghtChargesDetails.Where(x => x.ClaimNumber == Convert.ToInt32(uiClaimNumebrs)).Select(x => x.OriginalFreightChargesValue).FirstOrDefault();
                        originalFreightChargesValues_DB = originalFreightChages.ToString();
                        uiClaimNumbersFreightCharge = uiClaimNumebrs;
                        insClaimViewModel = DBHelper.GetInsuranceClaimDetailsHeader(Convert.ToInt32(uiClaimNumbersFreightCharge));
                        i = gridClaimNumbers.Count + 1;
                    }
                }

                SendKeys(attributeName_xpath, ".//*[@id='gridInsuranceClaimList_filter']/label/input", uiClaimNumbersFreightCharge);
                Click(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr[1]/td[3]/span[1]/a");
                
            }
        }

        [Given(@"I clicked any Claim reference hyperlink contains Freight Charges with Return Freight Charge")]
        public void GivenIClickedAnyClaimReferenceHyperlinkContainsFreightChargesWithReturnFreightCharge()
        {
            Click(attributeName_id, ClaimsIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, ClaimsListPage_HeaderText_Xpath, "Claims List");
            string gridFirstColumnHeader = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/thead/tr/th[1]");
            string claimNumberInvalidCarrier;
            if (gridFirstColumnHeader == "CUSTOMER")
            {
                userType = "Internal User";
                Report.WriteLine("logged in User is Internal");
                Click(attributeName_xpath, "//label[@for='FilterByStatusPending']");
                Click(attributeName_xpath, ClaimListGrid_PageViewOption_dropdown_Xpath);
                Click(attributeName_xpath, ".//*[@id='gridInsuranceClaimList_length']/label/select/option[5]");




                List<InsuranceClaimFreight> returnFrieghtChargesDetails = DBHelper.GetReturnFreightCharges();
                IList<IWebElement> gridClaimNumbers = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='gridInsuranceClaimList']/tbody/tr/td[4]/span/a"));
                for (int i = 1; i <= gridClaimNumbers.Count; i++)
                {
                    string uiClaimNumebrs = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr[" + i + "]/td[4]/span/a");

                    var returnFreightCheck = returnFrieghtChargesDetails.Where(x => x.ClaimNumber == Convert.ToInt32(uiClaimNumebrs)).Select(x => x.IsReturnFreightCharges).FirstOrDefault();
                    //decimal Convert.ToDecimal(originalFreightChages);
                    if (Convert.ToBoolean(returnFreightCheck))
                    {
                        var returnFreightChages = returnFrieghtChargesDetails.Where(x => x.ClaimNumber == Convert.ToInt32(uiClaimNumebrs)).Select(x => x.ReturnFreightChargesValue).FirstOrDefault();
                        returnFreightChargesValues_DB = returnFreightChages.ToString();
                        var returnFreightChagesDLSWReference = returnFrieghtChargesDetails.Where(x => x.ClaimNumber == Convert.ToInt32(uiClaimNumebrs)).Select(x => x.ReturnFreightChargesDlswRefNumber).FirstOrDefault();
                        returnFreightChargesDLSWNumebr_DB = returnFreightChagesDLSWReference;
                        uiClaimNumbersFreightCharge = uiClaimNumebrs;
                        
                        i = gridClaimNumbers.Count + 1;
                    }
                }

                SendKeys(attributeName_xpath, ".//*[@id='gridInsuranceClaimList_filter']/label/input", uiClaimNumbersFreightCharge);
                Click(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr/td[4]/span/a/span");
            }

            else if (gridFirstColumnHeader == "STA / CUST")
            {
                userType = "Claim Specialist User";
                Report.WriteLine("logged in User is Claim Specialist User");
                Click(attributeName_xpath, "//label[@for='FilterByStatusPending']");
                Click(attributeName_xpath, ClaimListGrid_PageViewOption_dropdown_Xpath);
                Click(attributeName_xpath, ".//*[@id='gridInsuranceClaimList_length']/label/select/option[5]");
                List<InsuranceClaimFreight> returnFrieghtChargesDetails = DBHelper.GetReturnFreightCharges();
                IList<IWebElement> gridClaimNumbers = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='gridInsuranceClaimList']/tbody/tr/td[3]/span[1]/a"));
                for (int i = 1; i <= gridClaimNumbers.Count; i++)
                {
                    string uiClaimNumebrs = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr[" + i + "]/td[3]/span[1]/a");
                    var returnFreightCheck = returnFrieghtChargesDetails.Where(x => x.ClaimNumber == Convert.ToInt32(uiClaimNumebrs)).Select(x => x.IsReturnFreightCharges).FirstOrDefault();
                    //decimal Convert.ToDecimal(originalFreightChages);
                    if (Convert.ToBoolean(returnFreightCheck))
                    {
                        var returnFreightChages = returnFrieghtChargesDetails.Where(x => x.ClaimNumber == Convert.ToInt32(uiClaimNumebrs)).Select(x => x.ReturnFreightChargesValue).FirstOrDefault();
                        returnFreightChargesValues_DB = returnFreightChages.ToString();
                        var returnFreightChagesDLSWReference = returnFrieghtChargesDetails.Where(x => x.ClaimNumber == Convert.ToInt32(uiClaimNumebrs)).Select(x => x.ReturnFreightChargesDlswRefNumber).FirstOrDefault();
                        returnFreightChargesDLSWNumebr_DB = returnFreightChagesDLSWReference;
                        uiClaimNumbersFreightCharge = uiClaimNumebrs;

                        
                        i = gridClaimNumbers.Count + 1;
                    }
                }
            }
        }

        [Given(@"I clicked any Claim reference hyperlink contains Freight Charges with Replacement Freight Charge")]
        public void GivenIClickedAnyClaimReferenceHyperlinkContainsFreightChargesWithReplacementFreightCharge()
        {
            Click(attributeName_id, ClaimsIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, ClaimsListPage_HeaderText_Xpath, "Claims List");
            string gridFirstColumnHeader = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/thead/tr/th[1]");
           
            if (gridFirstColumnHeader == "CUSTOMER")
            {
                Click(attributeName_xpath, "//label[@for='FilterByStatusPending']");
                Click(attributeName_xpath, ClaimListGrid_PageViewOption_dropdown_Xpath);
                Click(attributeName_xpath, ".//*[@id='gridInsuranceClaimList_length']/label/select/option[5]");

                List<InsuranceClaimFreight> replacementFrieghtChargesDetails = DBHelper.GetReplacementFreightCharges();
                IList<IWebElement> gridClaimNumbers = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='gridInsuranceClaimList']/tbody/tr/td[4]/span/a"));
                for (int i = 1; i <= gridClaimNumbers.Count; i++)
                {
                    string uiClaimNumebrs = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr[" + i + "]/td[4]/span/a");

                    var replacementFreightCheck = replacementFrieghtChargesDetails.Where(x => x.ClaimNumber == Convert.ToInt32(uiClaimNumebrs)).Select(x => x.IsReplacementFreightCharges).FirstOrDefault();
                  
                    if (Convert.ToBoolean(replacementFreightCheck))
                    {
                        var replacementFreightChages = replacementFrieghtChargesDetails.Where(x => x.ClaimNumber == Convert.ToInt32(uiClaimNumebrs)).Select(x => x.ReplacementFreightChargesValue).FirstOrDefault();
                        replacementFreightChargesValues_DB = replacementFreightChages.ToString();
                        var replacementFreightChagesDLSWReference = replacementFrieghtChargesDetails.Where(x => x.ClaimNumber == Convert.ToInt32(uiClaimNumebrs)).Select(x => x.ReplacementFreightDlswRefNumber).FirstOrDefault();
                        replacementFreightChargesDLSWNumebr_DB = replacementFreightChagesDLSWReference;
                        uiClaimNumbersFreightCharge = uiClaimNumebrs;
                        i = gridClaimNumbers.Count + 1;
                    }
                }

                SendKeys(attributeName_xpath, ".//*[@id='gridInsuranceClaimList_filter']/label/input", uiClaimNumbersFreightCharge);
                Click(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr/td[4]/span/a/span");
            }
            else if (gridFirstColumnHeader == "STA / CUST")
            {
               
                Click(attributeName_xpath, "//label[@for='FilterByStatusPending']");
                Click(attributeName_xpath, ClaimListGrid_PageViewOption_dropdown_Xpath);
                Click(attributeName_xpath, ".//*[@id='gridInsuranceClaimList_length']/label/select/option[5]");
                List<InsuranceClaimFreight> replacementFrieghtChargesDetails = DBHelper.GetReplacementFreightCharges();
                IList<IWebElement> gridClaimNumbers = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='gridInsuranceClaimList']/tbody/tr/td[3]/span[1]/a"));
                for (int i = 1; i <= gridClaimNumbers.Count; i++)
                {
                    string uiClaimNumebrs = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr[" + i + "]/td[3]/span[1]/a");

                    var replacementFreightCheck = replacementFrieghtChargesDetails.Where(x => x.ClaimNumber == Convert.ToInt32(uiClaimNumebrs)).Select(x => x.IsReplacementFreightCharges).FirstOrDefault();
                  
                    if (Convert.ToBoolean(replacementFreightCheck))
                    {
                        var replacementFreightChages = replacementFrieghtChargesDetails.Where(x => x.ClaimNumber == Convert.ToInt32(uiClaimNumebrs)).Select(x => x.ReplacementFreightChargesValue).FirstOrDefault();
                        replacementFreightChargesValues_DB = replacementFreightChages.ToString();
                        var replacementFreightChagesDLSWReference = replacementFrieghtChargesDetails.Where(x => x.ClaimNumber == Convert.ToInt32(uiClaimNumebrs)).Select(x => x.ReplacementFreightDlswRefNumber).FirstOrDefault();
                        replacementFreightChargesDLSWNumebr_DB = replacementFreightChagesDLSWReference;
                        uiClaimNumbersFreightCharge = uiClaimNumebrs;
                        i = gridClaimNumbers.Count + 1;
                    }
                }

                SendKeys(attributeName_xpath, ".//*[@id='gridInsuranceClaimList_filter']/label/input", uiClaimNumbersFreightCharge);
                Click(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr[1]/td[3]/span[1]/a");
            }

        }



        [When(@"I hover over the Proration % information icon in the Claim Details page")]
        public void WhenIHoverOverTheProrationInformationIconInTheClaimDetailsPage()
        {
            scrollElementIntoView(attributeName_xpath, Information_Icon_ClaimDetailsPage_Xpath);
            OnMouseOver(attributeName_xpath, Information_Icon_ClaimDetailsPage_Xpath);
        }



        [Given(@"I clicked any claim reference hyperlink with No Freight Charge on the Claims List page")]
        public void GivenIClickedAnyClaimReferenceHyperlinkWithNoFreightChargeOnTheClaimsListPage()
        {
            List<int> claimNumbersofFreight_DB = DBHelper.GetAllClaimNumbersOfFreightCalculation();
            IList<IWebElement> gridClaimNumbers = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='gridInsuranceClaimList']/tbody/tr/td[4]/span/a"));
            for (int i = 1; i <= gridClaimNumbers.Count; i++)
            {
                string uiClaimNumebrs = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr[" + i + "]/td[4]/span/a");

                if (!(claimNumbersofFreight_DB.Contains(Convert.ToInt32(uiClaimNumebrs))))
                {
                    Click(attributeName_xpath, uiClaimNumebrs);
                    i = gridClaimNumbers.Count + 1;

                }

            }
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I clicked any Claim reference hyperlink with Freight Charges contains all Claimable\? types are flagged to Y")]
        public void GivenIClickedAnyClaimReferenceHyperlinkWithFreightChargesContainsAllClaimableTypesAreFlaggedToY()
        {
            List<int> claimNumbersWith_Original_Return_ReplacementFreight = DBHelper.GetAllClaimNumbersWith_Original_Return_Replacement_Freight();
            IList<IWebElement> gridClaimNumbers = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='gridInsuranceClaimList']/tbody/tr/td[4]/span/a"));
            for (int i = 1; i <= gridClaimNumbers.Count; i++)
            {
                string uiClaimNumebrs = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr[" + i + "]/td[4]/span/a");

                if (claimNumbersWith_Original_Return_ReplacementFreight.Contains(Convert.ToInt32(uiClaimNumebrs)))
                {
                    Click(attributeName_xpath, uiClaimNumebrs);
                    i = gridClaimNumbers.Count + 1;
                }

            }
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Then(@"the Proration value will be calculated as TTL WGT field divided by Total Shipment Weight from Products Claimed section")]
        public void ThenTheProrationValueWillBeCalculatedAsTTLWGTFieldDividedByTotalShipmentWeightFromProductsClaimedSection()
        {
            scrollElementIntoView(attributeName_xpath, Information_Icon_ClaimDetailsPage_Xpath);
            string tttWGT = Gettext(attributeName_id, FrieghtCal_TTLWeight_Id);
            string totalShipmentWeight = Gettext(attributeName_xpath, FrieghtCal_TotalShipmentWEIGHT_Xpath);
            string ProrationVAlueUI = Gettext(attributeName_id, "prorationpercent");
            if (totalShipmentWeight == string.Empty)
            {
                Assert.AreEqual("N/A", ProrationVAlueUI);
            }
            else
            {
                int calculatedProrationVAlue = (Convert.ToInt32(tttWGT) / Convert.ToInt32(totalShipmentWeight)) * 100;

                Assert.AreEqual(calculatedProrationVAlue, ProrationVAlueUI);
            }
        }

        [Then(@"I will see the message as (.*)")]
        public void ThenIWillSeeTheMessageAs(string p0)
        {
            Verifytext(attributeName_xpath, "//div[@class='tooltip-inner']", "The proration % is determined by dividing the Total claimed weight by the Total shipment weight");
        }


        [Then(@"I will see Freight Calculation grid rows Original,Return,Replacement")]
        public void ThenIWillSeeFreightCalculationGridRowsOriginalReturnReplacement()
        {
            Verifytext(attributeName_xpath, Original_Row_label_Xpath, "Original");
            Verifytext(attributeName_xpath, Return_Row_label, "Return");
            Verifytext(attributeName_xpath, Replacement_Row_label, "Replacement");
        }

        [Then(@"I will see Original,Return,Replacement of Claimable Columns are flagged to N in the Freight description section")]
        public void ThenIWillSeeOriginalReturnReplacementOfClaimableColumnsAreFlaggedToNInTheFreightDescriptionSection()
        {
            string originalClaimable = Gettext(attributeName_xpath, Claimable_dropdown_Original_Xpath);
            string returnClaimable = Gettext(attributeName_xpath, Claimabledropdown_Return_Xpath);
            string replacementClaimable = Gettext(attributeName_xpath, Claimabledropdown_Replacement_Xpath);
            Assert.AreEqual("N", originalClaimable);
            Assert.AreEqual("N", returnClaimable);
            Assert.AreEqual("N", replacementClaimable);
        }

        [Then(@"the field value for each row of the Claimed Freight column will be blank")]
        public void ThenTheFieldValueForEachRowOfTheClaimedFreightColumnWillBeBlank()
        {

            //ElementNotPresent(attributeName_id, ClaimedFreight_Textbox_Original_Id, "CLAIMED FREIGHT");
            //ElementNotPresent(attributeName_id, ClaimedFreight_Textbox_Return_Id, "CLAIMED FREIGHT");
            //ElementNotPresent(attributeName_id, ClaimedFreight_Textbox_Replacement_Id, "CLAIMED FREIGHT");

            string originalClaimedFrightValue = GetAttribute(attributeName_id, ClaimedFreight_Textbox_Original_Id, "value");
            Assert.AreEqual("$", originalClaimedFrightValue);

            string replacementclaimedFrightValue = GetAttribute(attributeName_id, ClaimedFreight_Textbox_Return_Id, "value");
            Assert.AreEqual("$", replacementclaimedFrightValue);

            string retrunclaimedFrightValue = GetAttribute(attributeName_id, ClaimedFreight_Textbox_Replacement_Id, "value");
            Assert.AreEqual("$", retrunclaimedFrightValue);


        }
        [Then(@"the field value for each row of the Carrier Charges to DLSW column will be blank")]
        public void ThenTheFieldValueForEachRowOfTheCarrierChargesToDLSWColumnWillBeBlank()
        {
            //ElementNotPresent(attributeName_id, CarrierChargesToDLSW_Textbox_Original_Id, "CARRIER CHARGES TO DLSW");
            //ElementNotPresent(attributeName_id, CarrierChargesToDLSW_Textbox_Return_Id, "CARRIER CHARGES TO DLSW");
            //ElementNotPresent(attributeName_id, CarrierChargesToDLSW_Textbox_Replacement_Id, "CARRIER CHARGES TO DLSW");

            string originalChargesToDLSW = GetAttribute(attributeName_id, CarrierChargesToDLSW_Textbox_Original_Id, "value");
            Assert.AreEqual("$", originalChargesToDLSW);

            string replacementChargesToDLSW = GetAttribute(attributeName_id, CarrierChargesToDLSW_Textbox_Return_Id, "value");
            Assert.AreEqual("$", replacementChargesToDLSW);

            string retrunChargesToDLSW = GetAttribute(attributeName_id, CarrierChargesToDLSW_Textbox_Replacement_Id, "value");
            Assert.AreEqual("$", retrunChargesToDLSW);
        }


        [Then(@"the field value for each row of the DLW Charges to Cust will be blank")]
        public void ThenTheFieldValueForEachRowOfTheDLWChargesToCustWillBeBlank()
        {
            //ElementNotPresent(attributeName_id, DLSWChargesToCust_Textbox_Original_Id, "DLSW CHARGES TO CUST");
            //ElementNotPresent(attributeName_id, DLSWChargesToCust_Textbox_Return_Id, "DLSW CHARGES TO CUST");
            //ElementNotPresent(attributeName_id, DLSWChargesToCust_Textbox_Replacement_Id, "DLSW CHARGES TO CUST");

            string originalDLSWChargesToCUST = GetAttribute(attributeName_id, DLSWChargesToCust_Textbox_Original_Id, "value");
            Assert.AreEqual("$", originalDLSWChargesToCUST);

            string replacementDLSWChargesToCUST = GetAttribute(attributeName_id, DLSWChargesToCust_Textbox_Return_Id, "value");
            Assert.AreEqual("$", replacementDLSWChargesToCUST);

            string retrunDLSWChargesToCUST = GetAttribute(attributeName_id, DLSWChargesToCust_Textbox_Replacement_Id, "value");
            Assert.AreEqual("$", retrunDLSWChargesToCUST);
        }

        [Then(@"the field value of the DLSW Ref\# field will be blank")]
        public void ThenTheFieldValueOfTheDLSWRefFieldWillBeBlank()
        {
            //ElementNotPresent(attributeName_id, DLSWRefNumeber_Textbox_Original_Id, "DLSW REF #");
            //ElementNotPresent(attributeName_id, DLSWRefNumeber_Textbox_Return_Id, "DLSW REF #");
            //ElementNotPresent(attributeName_id, DLSWRefNumeber_Textbox_Replacement_Id, "DLSW REF #");

            string originalDLSWRefNo= GetAttribute(attributeName_id, DLSWRefNumeber_Textbox_Original_Id,"value");
            Assert.AreEqual("$", originalDLSWRefNo);

            string replacementDLSWRefNo = GetAttribute(attributeName_id, DLSWRefNumeber_Textbox_Return_Id, "value");
            Assert.AreEqual("$", replacementDLSWRefNo);

            string retrunDLSWRefNo = GetAttribute(attributeName_id, DLSWRefNumeber_Textbox_Replacement_Id, "value");
            Assert.AreEqual("$", retrunDLSWRefNo);

        }

        [Then(@"the field value of the Total Claimed Freight field will be blank")]
        public void ThenTheFieldValueOfTheTotalClaimedFreightFieldWillBeBlank()
        {
            string totalClaimedFreight = Gettext(attributeName_xpath, "");
            Assert.AreEqual(string.Empty, totalClaimedFreight);
        }

        [Then(@"I will see Claimable field of the Replacement row on the Freight Calculations grid will be flagged Y")]
        public void ThenIWillSeeClaimableFieldOfTheReplacementRowOnTheFreightCalculationsGridWillBeFlaggedY()
        {

            string replacementClaimable = Gettext(attributeName_xpath, Claimabledropdown_Replacement_Xpath);
            Assert.AreEqual("Y", replacementClaimable);

        }

        [Then(@"the Claimed Freight field of the Replacement row will be blank")]
        public void ThenTheClaimedFreightFieldOfTheReplacementRowWillBeBlank()
        {
            string claimedFrightValue = GetAttribute(attributeName_id, ClaimedFreight_Textbox_Replacement_Id,"value");
            Assert.AreEqual(string.Empty, claimedFrightValue);
        }

        [Then(@"the Carrier Charges to DLSW field of the Replacement row will be blank")]
        public void ThenTheCarrierChargesToDLSWFieldOfTheReplacementRowWillBeBlank()
        {
            string carrierChargesToDLSWValue = Gettext(attributeName_id, CarrierChargesToDLSW_Textbox_Replacement_Id);
            Assert.AreEqual(string.Empty, carrierChargesToDLSWValue);
        }

        [Then(@"the DLSW Charges to Cust field of the Replacement row will be blank")]
        public void ThenTheDLSWChargesToCustFieldOfTheReplacementRowWillBeBlank()
        {
            string dLSWChargesToCustValue = Gettext(attributeName_id, DLSWChargesToCust_Textbox_Replacement_Id);
            Assert.AreEqual(string.Empty, dLSWChargesToCustValue);
        }

        [Then(@"the DLSW Ref \# field of the Replacement row will display the DLSW Ref \# of the Replacement shipment from the Submit A Claim form")]
        public void ThenTheDLSWRefFieldOfTheReplacementRowWillDisplayTheDLSWRefOfTheReplacementShipmentFromTheSubmitAClaimForm()
        {
            string dLSWRefNumebertValue = Gettext(attributeName_id, DLSWRefNumeber_Textbox_Replacement_Id);
            Assert.AreEqual(replacementFreightChargesDLSWNumebr_DB, dLSWRefNumebertValue);
        }

        [Then(@"I will see Freight Calculation grid values in red font")]
        public void ThenIWillSeeFreightCalculationGridValuesInRedFont()
        {
            String originCLaimedFreightColor = GetCSSValue(attributeName_id, ClaimedFreight_Textbox_Original_Id, "CLAIMED FREIGHT");
            Assert.AreEqual("#FFFFFF", originCLaimedFreightColor);

            String returnCLaimedFreightColor = GetCSSValue(attributeName_id, ClaimedFreight_Textbox_Return_Id, "CLAIMED FREIGHT");
            Assert.AreEqual("#FFFFFF", returnCLaimedFreightColor);

            String replacementCLaimedFreightColor = GetCSSValue(attributeName_id, ClaimedFreight_Textbox_Replacement_Id, "CLAIMED FREIGHT");
            Assert.AreEqual("#FFFFFF", replacementCLaimedFreightColor);

            String originCarrierChargesToDLSWColor = GetCSSValue(attributeName_id, CarrierChargesToDLSW_Textbox_Original_Id, "CARRIER CHARGES TO DLSW");
            Assert.AreEqual("#FFFFFF", originCarrierChargesToDLSWColor);

            String returnCarrierChargesToDLSWColor = GetCSSValue(attributeName_id, CarrierChargesToDLSW_Textbox_Return_Id, "CARRIER CHARGES TO DLSW");
            Assert.AreEqual("#FFFFFF", returnCarrierChargesToDLSWColor);

            String replacementCarrierChargesToDLSWColor = GetCSSValue(attributeName_id, CarrierChargesToDLSW_Textbox_Replacement_Id, "CARRIER CHARGES TO DLSW");
            Assert.AreEqual("#FFFFFF", replacementCarrierChargesToDLSWColor);




            String originDLSWChargesToCustColor = GetCSSValue(attributeName_id, DLSWChargesToCust_Textbox_Original_Id, "DLSW CHARGES TO CUST");
            Assert.AreEqual("#FFFFFF", originDLSWChargesToCustColor);

            String returnDLSWChargesToCustColor = GetCSSValue(attributeName_id, DLSWChargesToCust_Textbox_Return_Id, "DLSW CHARGES TO CUST");
            Assert.AreEqual("#FFFFFF", returnDLSWChargesToCustColor);

            String replacementDLSWChargesToCustColor = GetCSSValue(attributeName_id, DLSWChargesToCust_Textbox_Replacement_Id, "DLSW CHARGES TO CUST");
            Assert.AreEqual("#FFFFFF", replacementDLSWChargesToCustColor);




            String originDLSWRefNoColor = GetCSSValue(attributeName_id, DLSWRefNumeber_Textbox_Original_Id, "DLSW REF #");
            Assert.AreEqual("#FFFFFF", originDLSWRefNoColor);

            String returnDLSWRefNoColor = GetCSSValue(attributeName_id, DLSWRefNumeber_Textbox_Return_Id, "DLSW REF #");
            Assert.AreEqual("#FFFFFF", returnDLSWRefNoColor);

            String replacementDLSWRefNoColor = GetCSSValue(attributeName_id, DLSWRefNumeber_Textbox_Replacement_Id, "DLSW REF #");
            Assert.AreEqual("#FFFFFF", replacementDLSWRefNoColor);

        }

        [Then(@"I will see Claimable \? field of the Original row on the Freight Calculations grid will be flagged Y")]
        public void ThenIWillSeeClaimableFieldOfTheOriginalRowOnTheFreightCalculationsGridWillBeFlaggedY()
        {
            scrollElementIntoView(attributeName_xpath, FreightClauclulations_Label_Xpath);
            string uiOriginalClaimableType = Gettext(attributeName_xpath, Claimable_dropdown_Original_Xpath);
            Assert.AreEqual("Y", uiOriginalClaimableType);
        }

        [Then(@"the Claimed Freight field of the Original row of the Freight Calculation grid will display the value entered in the Original Freight Charges/ Value field of the Submit A Claim page")]
        public void ThenTheClaimedFreightFieldOfTheOriginalRowOfTheFreightCalculationGridWillDisplayTheValueEnteredInTheOriginalFreightChargesValueFieldOfTheSubmitAClaimPage()
        {
            string uiOriginalClaimedFreight = GetValue(attributeName_id, ClaimedFreight_Textbox_Original_Id, "value");
            Assert.AreEqual("$"+ originalFreightChargesValues_DB, uiOriginalClaimedFreight);
        }

        [Then(@"the Carrier Charges to DLSW field of the Original row will be blank")]
        public void ThenTheCarrierChargesToDLSWFieldOfTheOriginalRowWillBeBlank()
        {
            string uiOriginalCarrierChargesToDLSW = GetValue(attributeName_id, CarrierChargesToDLSW_Textbox_Original_Id, "value");
            Assert.AreEqual(string.Empty, uiOriginalCarrierChargesToDLSW);
        }

        [Then(@"the DLSW Charges to Cust field of the Original row will be blank")]
        public void ThenTheDLSWChargesToCustFieldOfTheOriginalRowWillBeBlank()
        {
            string uiOriginalDLSWChargesToCUST = GetValue(attributeName_id, DLSWChargesToCust_Textbox_Original_Id, "value");
            Assert.AreEqual(string.Empty, uiOriginalDLSWChargesToCUST);
        }

        [Then(@"the DLSW Ref \# field of the Original row on the Freight Calculations grid will display the DLSW Ref \# of the claim")]
        public void ThenTheDLSWRefFieldOfTheOriginalRowOnTheFreightCalculationsGridWillDisplayTheDLSWRefOfTheClaim()
        {
            string uiOriginalDLSWRefNumber = GetValue(attributeName_id, DLSWRefNumeber_Textbox_Original_Id, "value");
            Assert.AreEqual((insClaimViewModel.DLSWReferenceNumber).ToLower(), uiOriginalDLSWRefNumber.ToLower());
        }

        [Then(@"I will see Claimable \? field of the Return row on the Freight Calculations grid will be flagged Y")]
        public void ThenIWillSeeClaimableFieldOfTheReturnRowOnTheFreightCalculationsGridWillBeFlaggedY()
        {
            scrollElementIntoView(attributeName_xpath, FreightClauclulations_Label_Xpath);
            string uiReturnClaimableType = Gettext(attributeName_xpath, Claimabledropdown_Return_Xpath);
            Assert.AreEqual("Y", uiReturnClaimableType);
        }

        [Then(@"the Claimed Freight field of the Return row will be blank")]
        public void ThenTheClaimedFreightFieldOfTheReturnRowWillBeBlank()
        {
            string uiReturnClaimedFreight = GetValue(attributeName_id, ClaimedFreight_Textbox_Return_Id, "value");
            Assert.AreEqual(string.Empty, uiReturnClaimedFreight);
        }

        [Then(@"the Carrier Charges to DLSW field of the Return row will be blank")]
        public void ThenTheCarrierChargesToDLSWFieldOfTheReturnRowWillBeBlank()
        {
            string uiReturnCarrierChargesToDLSW = GetValue(attributeName_id, CarrierChargesToDLSW_Textbox_Return_Id, "value");
            Assert.AreEqual(string.Empty, uiReturnCarrierChargesToDLSW);
        }

        [Then(@"the DLSW Charges to Cust field of the Return row will be blank")]
        public void ThenTheDLSWChargesToCustFieldOfTheReturnRowWillBeBlank()
        {
            string uiReturnDLSWChargesToCUST = GetValue(attributeName_id, DLSWChargesToCust_Textbox_Return_Id, "value");
            Assert.AreEqual(string.Empty, uiReturnDLSWChargesToCUST);
        }

        [Then(@"the DLSW Ref \# field of the Return row will display the DLSW Ref \# of the Return shipment from the Submit A Claim form")]
        public void ThenTheDLSWRefFieldOfTheReturnRowWillDisplayTheDLSWRefOfTheReturnShipmentFromTheSubmitAClaimForm()
        {
            string uiReturnDLSWRefNumber = GetValue(attributeName_id, DLSWRefNumeber_Textbox_Return_Id, "value");
            if (!string.IsNullOrEmpty(uiReturnDLSWRefNumber))
            {
                Assert.AreEqual(returnFreightChargesDLSWNumebr_DB, uiReturnDLSWRefNumber);
            }
            else
            {
                Assert.AreEqual(string.Empty, uiReturnDLSWRefNumber);
            }
        }


    }
}
