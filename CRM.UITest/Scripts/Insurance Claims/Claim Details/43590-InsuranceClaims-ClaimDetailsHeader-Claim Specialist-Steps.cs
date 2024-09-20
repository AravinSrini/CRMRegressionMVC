using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Insurance_Claims.Claim_Details
{
    [Binding]
    public class InsuranceClaims_ClaimDetailsHeader_Claim_Specialist_Steps : Objects.InsuranceClaim
    {
        string dlswClaimRep = "Alan Burton";
        string selectedStationName = "ENT";
        string newEnteredDLSRefNumber = "RefNo1234123312";
        string enteredclaimant = "Claiment123";
        string claimReasonValue = "Concealed Damage";
        string carriername = "R & L Carriers";
        string etneredCarrierPro = "123132313";
        string claimNumber_ClaimsList_UI = "";
        string DLSRefNumber = "";
        string actualClaimantValue = "";
        string validSCACCarriername = "";
        string nonSCACCarriername = "";
        string actualCarrierProNo = "";
        string actualCrrierProValue = "";
        string entereCarrierProNo = "";
        string actualInsredValue = "";
        string checkInvalidCarrier;
        string checkValidCarrier;
        string carrierNameValidCarrier;
        List<InsuredRateCarrier> crmCarrierAllDetails = null;
        bool carrierValue;


        [Given(@"I am Claims Specialist User")]
        public void GivenIAmClaimsSpecialistUser()
        {
            string username = ConfigurationManager.AppSettings["username-claimspecialistClaim"].ToString();
            string password = ConfigurationManager.AppSettings["password-claimspecialistClaim"].ToString();
            CommonMethodsCrm crmLogin = new CommonMethodsCrm();
            crmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"I am Non Claims Specialist User")]
        public void GivenIAmNonClaimsSpecialistUser()
        {
            string username = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
            string password = ConfigurationManager.AppSettings["password-crmOperation"].ToString();
            CommonMethodsCrm crmLogin = new CommonMethodsCrm();
            crmLogin.LoginToCRMApplication(username, password);
        }


        [When(@"I am on the Details Tab of the Claim Details")]
        public void WhenIAmOnTheDetailsTabOfTheClaimDetails()
        {
            Click(attributeName_id, ClaimsIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, ClaimsListPage_HeaderText_Xpath, "Claims List Text");


            string GridData = Gettext(attributeName_xpath, ClaimListGridDataCount_Xpath);
            string gridFirstColumnHeader = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/thead/tr/th[1]");
            if (GridData == "No Results Found")
            {
                Report.WriteLine("No Claims List found in the Grid");
                throw new Exception("No datas found in the Claim List Grid");
            }
            else if (gridFirstColumnHeader == "CUSTOMER")
            {

                Report.WriteLine("logged in User is Internal");
                claimNumber_ClaimsList_UI = Gettext(attributeName_xpath, FirstClaimNumber_ClaimsListGrid_Xpath);
                // claimAge_ClaimsList_UI = Gettext(attributeName_xpath, FirstClaimAge_ClaimList_Xpath);
                Report.WriteLine("Clicking on the Claim Number");
                Click(attributeName_xpath, FirstClaimNumber_ClaimsListGrid_Xpath);
            }
            else if (gridFirstColumnHeader == "STA / CUST")
            {

                Report.WriteLine("Reading First data value from Claims List page");
                claimNumber_ClaimsList_UI = Gettext(attributeName_xpath, ClaimSpecilistFirstClaimNumber_ClaimsListGrid_Xpath);
                Report.WriteLine("Clicking on the Claim Number");
                Click(attributeName_xpath, ClaimSpecilistFirstClaimNumber_ClaimsListGrid_Xpath);
            }
        }



        [Given(@"I am on the Details Tab of the Claim Details")]
        public void GivenIAmOnTheDetailsTabOfTheClaimDetails()
        {
            Click(attributeName_id, ClaimsIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, ClaimsListPage_HeaderText_Xpath, "Claims List Text");


            string GridData = Gettext(attributeName_xpath, ClaimListGridDataCount_Xpath);
            string gridFirstColumnHeader = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/thead/tr/th[1]");
            if (GridData == "No Results Found")
            {
                Report.WriteLine("No Claims List found in the Grid");
                throw new Exception("No datas found in the Claim List Grid");
            }
            else if (gridFirstColumnHeader == "CUSTOMER")
            {
               
                Report.WriteLine("logged in User is Internal");
                claimNumber_ClaimsList_UI = Gettext(attributeName_xpath, FirstClaimNumber_ClaimsListGrid_Xpath);
               // claimAge_ClaimsList_UI = Gettext(attributeName_xpath, FirstClaimAge_ClaimList_Xpath);
                Report.WriteLine("Clicking on the Claim Number");
                Click(attributeName_xpath, FirstClaimNumber_ClaimsListGrid_Xpath);
            }
            else if (gridFirstColumnHeader == "STA / CUST")
            {

                Report.WriteLine("Reading First data value from Claims List page");
                claimNumber_ClaimsList_UI = Gettext(attributeName_xpath, ClaimSpecilistFirstClaimNumber_ClaimsListGrid_Xpath);
                Report.WriteLine("Clicking on the Claim Number");
                Click(attributeName_xpath, ClaimSpecilistFirstClaimNumber_ClaimsListGrid_Xpath);           
            }
        }



        [Then(@"DLS Claim Rep drop down list will be editable")]
        public void ThenDLSClaimRepDropDownListWillBeEditable()
        {
            Report.WriteLine("DLS Claim Rep drop down list will be editable");
            // string LTL = Gettext(attributeName_xpath, DlswClaimRep_dropdown_ClaimDetailsPage_Xpath);
            Click(attributeName_xpath, DlswClaimRep_dropdown_ClaimDetailsPage_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, DlswClaimRep_DropdownValues_ClaimDetailsPage_Xpath, dlswClaimRep);
            string LTLNewValue = Gettext(attributeName_xpath, DlswClaimRep_dropdown_ClaimDetailsPage_Xpath);
            Assert.AreEqual(dlswClaimRep, LTLNewValue);

            //or
            //Click(attributeName_id, "");
            //IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(""));
            //int DropDownCount = DropDownList.Count;
            //if (DropDownCount > 1)
            //{
            //    Console.WriteLine("Claim Rep drop down is editable");
            //}
            //else
            //{
            //    Console.WriteLine("Claim Rep drop down is non-editable");
            //}

        }

        [Then(@"Station drop down list will be editable")]
        public void ThenStationDropDownListWillBeEditable()
        {
            Report.WriteLine("Station drop down list will be editable");
            //  VerifyElementEnabled(attributeName_id, "", "Comment"); //to verify element is editable or not
            //string LTL = Gettext(attributeName_id, "");
            Click(attributeName_xpath, Station_Dropdown_ClaimDetailsPage_Xpath);
           // SelectDropdownValueFromList(attributeName_xpath, Station_DropdownValues_ClaimDetailsPage_Xpath, selectedStationName);
            IList<IWebElement> stationDropDownList = GlobalVariables.webDriver.FindElements(By.XPath(Station_DropdownValues_ClaimDetailsPage_Xpath));
            int DropDownCount = stationDropDownList.Count;
            for(int i=0;i< DropDownCount; i++)
            {
                if(stationDropDownList[i].Text== selectedStationName)
                {
                    stationDropDownList[i].Click();
                }

            }
            string sationNameUI = Gettext(attributeName_xpath, Station_Dropdown_ClaimDetailsPage_Xpath);
            Assert.AreEqual(selectedStationName, sationNameUI);

            //or
            //Click(attributeName_id, "");
            //IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(""));
            //int DropDownCount = DropDownList.Count;
            //if (DropDownCount > 1)
            //{
            //    Console.WriteLine("station drop down is editable");
            //}
            //else
            //{
            //    Console.WriteLine("station drop down is non-editable");
            //}
        }

        [Then(@"DLSW Ref \# field will be editable")]
        public void ThenDLSWRefFieldWillBeEditable()
        {
            Report.WriteLine("Station drop down list will be editable");
            SendKeys(attributeName_id, DlswRefNumber_Textbox_ClaimDetailsPage_Id, newEnteredDLSRefNumber);
            string DLSRefNumber = GetAttribute(attributeName_id, DlswRefNumber_Textbox_ClaimDetailsPage_Id, "value");
            Assert.AreEqual(newEnteredDLSRefNumber, DLSRefNumber);
        }

        [Then(@"Claimant field will be editable")]
        public void ThenClaimantFieldWillBeEditable()
        {
            Report.WriteLine("Claimant field will be editable");
            SendKeys(attributeName_id, Claimant_Textbox_ClaimDetailsPage_Id, enteredclaimant);
            string claimant = GetAttribute(attributeName_id, Claimant_Textbox_ClaimDetailsPage_Id, "value");
            Assert.AreEqual(enteredclaimant, claimant);
        }

        [Then(@"Claim Reason drop down list will be editable")]
        public void ThenClaimReasonDropDownListWillBeEditable()
        {
            Report.WriteLine("Claim Reason drop down list will be editable");
            Click(attributeName_xpath, ClaimReason_Dropdown_ClaimDetailsPage_Xpath);
            //SelectDropdownValueFromList(attributeName_xpath, ClaimReason_DropdownValues_ClaimDetailsPage_Xpath, claimReasonValue);
            IList<IWebElement> claimReasonDropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ClaimReason_DropdownValues_ClaimDetailsPage_Xpath));
            int DropDownCount = claimReasonDropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (claimReasonDropDownList[i].Text == claimReasonValue)
                {
                    claimReasonDropDownList[i].Click();
                }

            }
           
            string expectedClaimReasonValue = Gettext(attributeName_xpath, ClaimReason_Dropdown_ClaimDetailsPage_Xpath);
            Assert.AreEqual(expectedClaimReasonValue, claimReasonValue);
        }

        [Then(@"Carrier Name drop down list will be editable")]
        public void ThenCarrierNameDropDownListWillBeEditable()
        {
            Report.WriteLine("Carrier Name drop down list will be editable");
            Click(attributeName_xpath, CarrierName_Dropdown_ClaimDetailsPage_Xpath);
            //SelectDropdownValueFromList(attributeName_xpath, CarrierName_DropdownValues_ClaimDetailsPage_Xpath, carriername);
            IList<IWebElement> carrierNameDropDownList = GlobalVariables.webDriver.FindElements(By.XPath(CarrierName_DropdownValues_ClaimDetailsPage_Xpath));
            int DropDownCount = carrierNameDropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (carrierNameDropDownList[i].Text == carriername)
                {
                    carrierNameDropDownList[i].Click();
                }

            }
            string expectedCarriername = Gettext(attributeName_xpath, CarrierName_Dropdown_ClaimDetailsPage_Xpath);
            Assert.AreEqual(expectedCarriername, carriername);
        }

        [Then(@"Carrier PRO field will be editable")]
        public void ThenCarrierPROFieldWillBeEditable()
        {
            Report.WriteLine("Carrier PRO field will be editable");
            SendKeys(attributeName_id, CarrierPro_Textbox_ClaimDetailsPage_Id, etneredCarrierPro);
            string expectedCarrierPro = GetAttribute(attributeName_id, CarrierPro_Textbox_ClaimDetailsPage_Id, "value");
            Assert.AreEqual(expectedCarrierPro, etneredCarrierPro);
        }

        [Then(@"Insured field will be editable")]
        public void ThenInsuredFieldWillBeEditable()
        {
            Click(attributeName_xpath, Insured_Dropdown_ClaimDetailsPage_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, Insured_DropdownValues_ClaimDetailsPage_Xpath, "Y");
            //IList<IWebElement> insuredValues = GlobalVariables.webDriver.FindElements(By.XPath(""));
            //List<string> insuredValuesList = new List<string>();
            //for (int i = 0; i < insuredValues.Count; i++)
            //{
            //    string data = insuredValues[i].Text;
            //    insuredValuesList.Add(data);
            //}
            //Report.WriteLine("Carrier PRO field will be editable");
            //SendKeys(attributeName_id, "", "Y");
            string expectedInsuredValue = Gettext(attributeName_xpath, Insured_Dropdown_ClaimDetailsPage_Xpath);
            Assert.AreEqual(expectedInsuredValue, "Y");
        }


        [Then(@"DLSW Ref \# field has following validation- free form text, alpha-numeric, special characters, max length (.*)")]
        public void ThenDLSWRefFieldHasFollowingValidation_FreeFormTextAlpha_NumericSpecialCharactersMaxLength(int p0)
        {
            Report.WriteLine("DLSW Ref no field has following validation- free form text, alpha-numeric, special characters, max length 25");
            //Verifying form text, alpha-numeric, special characters validation
            SendKeys(attributeName_id, DlswRefNumber_Textbox_ClaimDetailsPage_Id, newEnteredDLSRefNumber);
            DLSRefNumber = GetAttribute(attributeName_id, DlswRefNumber_Textbox_ClaimDetailsPage_Id, "value");
            Assert.AreEqual(newEnteredDLSRefNumber, DLSRefNumber);

            //Verifying 25 max length validation
            SendKeys(attributeName_id, DlswRefNumber_Textbox_ClaimDetailsPage_Id, "12345678901234567890123456");
            DLSRefNumber = GetAttribute(attributeName_id, DlswRefNumber_Textbox_ClaimDetailsPage_Id, "value");
            Assert.AreEqual("1234567890123456789012345", DLSRefNumber);

            //Verifying only splace is accepted or not
            //SendKeys(attributeName_id, DlswRefNumber_Textbox_ClaimDetailsPage_Id, "    ");
            //DLSRefNumber = GetAttribute(attributeName_id, DlswRefNumber_Textbox_ClaimDetailsPage_Id, "value");
            //Assert.AreEqual(string.Empty, DLSRefNumber);
        }


        [Then(@"Claimant field has following validation- free form text, alpha-numeric, special characters, max length (.*)")]
        public void ThenClaimantFieldHasFollowingValidation_FreeFormTextAlpha_NumericSpecialCharactersMaxLength(int p0)
        {
            Report.WriteLine("Claimant field has following validation- free form text, alpha-numeric, special characters, max length 50");
            //Verifying form text, alpha-numeric, special characters validation
            SendKeys(attributeName_id, Claimant_Textbox_ClaimDetailsPage_Id, enteredclaimant);
            actualClaimantValue = GetAttribute(attributeName_id, Claimant_Textbox_ClaimDetailsPage_Id, "value");
            Assert.AreEqual(enteredclaimant, actualClaimantValue);

            //Verifying 25 max length validation
            SendKeys(attributeName_id, Claimant_Textbox_ClaimDetailsPage_Id, "123456789009876543211234567890098765432112345678901");
            actualClaimantValue = GetAttribute(attributeName_id, Claimant_Textbox_ClaimDetailsPage_Id, "value");
            Assert.AreEqual("12345678900987654321123456789009876543211234567890", actualClaimantValue);

            //Verifying only splace is accepted or not
            //SendKeys(attributeName_id, Claimant_Textbox_ClaimDetailsPage_Id, "    ");
            //actualClaimantValue = GetAttribute(attributeName_id, Claimant_Textbox_ClaimDetailsPage_Id, "value");
            //Assert.AreEqual(string.Empty, actualClaimantValue);
        }

        [Then(@"Carrier PRO field has following validation- Free form text, alpha-numeric, special characters, max length (.*)")]
        public void ThenCarrierPROFieldHasFollowingValidation_FreeFormTextAlpha_NumericSpecialCharactersMaxLength(int p0)
        {
            Report.WriteLine("Carrier PRO field has following validation- Free form text, alpha-numeric, special characters, max length 50");
            //Verifying form text, alpha-numeric, special characters validation
            SendKeys(attributeName_id, CarrierPro_Textbox_ClaimDetailsPage_Id, entereCarrierProNo);
            actualCrrierProValue = GetAttribute(attributeName_id, CarrierPro_Textbox_ClaimDetailsPage_Id, "value");
            Assert.AreEqual(entereCarrierProNo, actualCrrierProValue);

            //Verifying 50 max length validation
            SendKeys(attributeName_id, CarrierPro_Textbox_ClaimDetailsPage_Id, "123456789009876543211234567890098765432112345678901");
            actualCrrierProValue = GetAttribute(attributeName_id, CarrierPro_Textbox_ClaimDetailsPage_Id, "value");
            Assert.AreEqual("12345678900987654321123456789009876543211234567890", actualCrrierProValue);

            //Verifying only splace is accepted or not
            //SendKeys(attributeName_id, CarrierPro_Textbox_ClaimDetailsPage_Id, "    ");
            //actualCrrierProValue = GetAttribute(attributeName_id, CarrierPro_Textbox_ClaimDetailsPage_Id, "value");
            //Assert.AreEqual(string.Empty, actualCrrierProValue);
        }



        [Then(@"Insured is a drop down -Y or N are only accepted option, system will display as upper case\.")]
        public void ThenInsuredIsADropDown_YOrNAreOnlyAcceptedOptionSystemWillDisplayAsUpperCase_()
        {
            Click(attributeName_xpath, Insured_Dropdown_ClaimDetailsPage_Xpath);
            IList<IWebElement> insuredValues = GlobalVariables.webDriver.FindElements(By.XPath(Insured_DropdownValues_ClaimDetailsPage_Xpath));
            List<string> insuredValuesList = new List<string>();
            for (int i = 0; i < insuredValues.Count; i++)
            {
                string data = insuredValues[i].Text;
                insuredValuesList.Add(data);
            }

            List<string> expectedWinsuredValues = new List<string>
            {
                "Y","N"
            };

            CollectionAssert.AreEqual(expectedWinsuredValues, insuredValuesList);

            actualInsredValue = Gettext(attributeName_xpath, Insured_Dropdown_ClaimDetailsPage_Xpath);
            if (actualInsredValue == "Y" || actualInsredValue == "N")
            {
                Report.WriteLine("Insured values are in CAPITAL case");
            }
            else
            {
                Report.WriteFailure("Insured values are in samll case");
            }
        }


        [When(@"I click in the Station drop down field")]
        public void WhenIClickInTheStationDropDownField()
        {         
            Click(attributeName_xpath, Station_Dropdown_ClaimDetailsPage_Xpath);
        }

        [Then(@"the stations will be displayed numerically then alphabetically")]
        public void ThenTheStationsWillBeDisplayedNumericallyThenAlphabetically()
        {
            Report.WriteLine("the stations will be displayed numerically then alphabetically");

            IList<IWebElement> StationDropDownListUI = GlobalVariables.webDriver.FindElements(By.XPath(Station_DropdownValues_ClaimDetailsPage_Xpath));
            List<string> stationUI = new List<string>();
            for (int i = 0; i < StationDropDownListUI.Count; i++)
            {
                string data = StationDropDownListUI[i].Text;
                stationUI.Add(data);
            }
            stationUI.Remove(stationUI[0]);

            IList<CustomerAccount> StationDropDownListDB = DBHelper.GetAllStationDetails();
            List<string> expectedWeekDropDownOptions = new List<string>();
            for (int i = 0; i < StationDropDownListDB.Count; i++)
            {
                string dbStationName = StationDropDownListDB[i].StationId;                
                expectedWeekDropDownOptions.Add(dbStationName);
            }
            expectedWeekDropDownOptions.Sort();
            Assert.IsTrue(stationUI.SequenceEqual(expectedWeekDropDownOptions));
        }


        [Then(@"the Carrier SCAC field will update to display the SCAC of the selected carrier")]
        public void ThenTheCarrierSCACFieldWillUpdateToDisplayTheSCACOfTheSelectedCarrier()
        {
            crmCarrierAllDetails = DBHelper.GetAllCarrierDetails();
            Report.WriteLine("the Carrier SCAC field will update to display the SCAC of the selected carrier");
            InsuredRateCarrier dbCarriers = crmCarrierAllDetails.Where(a => a.CarrierName == carrierNameValidCarrier).FirstOrDefault();
            string carrierSCACUI = GetAttribute(attributeName_id, CarrierSCAC_Textbox_ClaimDetailsPage_Id,"value");
            Assert.AreEqual(dbCarriers.CarrierCode, carrierSCACUI);
        }

        [Then(@"I am unable to edit the SCAC field")]
        public void ThenIAmUnableToEditTheSCACField()
        {
            Report.WriteLine("I am unable to edit the SCAC field");
            VerifyElementNotEnabled(attributeName_id, CarrierSCAC_Textbox_ClaimDetailsPage_Id, "CARRIER SCAC");
        }


        [When(@"a carrier without associated SCAC code is selected from the Carrier Name drop down list")]
        public void WhenACarrierWithoutAssociatedSCACCodeIsSelectedFromTheCarrierNameDropDownList()
        {
            Report.WriteLine("the Carrier SCAC field will update to display the SCAC of the selected carrier");
            IList<IWebElement> dropDownCarrierList = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='gridInsuranceClaimList']/tbody/tr/td[6]"));
            crmCarrierAllDetails = DBHelper.GetAllCarrierDetails();
            List<string> dbCRMCarriers = crmCarrierAllDetails.Select(a => a.CarrierName).ToList();
            for (int i = 1; i <= dropDownCarrierList.Count; i++)
            {
                string CarrierUI = dropDownCarrierList[i].Text;
                if (!dbCRMCarriers.Contains(CarrierUI))
                {
                    nonSCACCarriername = CarrierUI;
                    dropDownCarrierList[i].Click();
                    break;
                }
                checkInvalidCarrier = "Invalid Carrier";
            }
        }


        [Then(@"the SCAC field should be left blank")]
        public void ThenTheSCACFieldShouldBeLeftBlank()
        {
            Report.WriteLine("the SCAC field will be left blank");
            if (carrierValue)
            {
                Verifytext(attributeName_id, CarrierSCAC_Textbox_ClaimDetailsPage_Id, string.Empty);
            }
            else
            {
                Report.WriteLine("No Carrier is invalid in Claim List page");
            }
        }


        [When(@"the drop down list selections of the DLSW Claim Rep")]
        public void WhenTheDropDownListSelectionsOfTheDLSWClaimRep()
        {
            Report.WriteLine("the drop down list selections of the DLSW Claim Rep");
            Click(attributeName_xpath, DlswClaimRep_dropdown_ClaimDetailsPage_Xpath);
        }

        [Then(@"the DLSW Claim Rep drop down list will be configurable")]
        public void ThenTheDLSWClaimRepDropDownListWillBeConfigurable()
        {
            Report.WriteLine("the DLSW Claim Rep drop down list will be configurable");
            IList<IWebElement> dropDownClaimRepUI = GlobalVariables.webDriver.FindElements(By.XPath(DlswClaimRep_DropdownValues_ClaimDetailsPage_Xpath));
            List<string> claimRepUI = new List<string>();
            for (int i = 0; i < dropDownClaimRepUI.Count; i++)
            {
                string data = dropDownClaimRepUI[i].Text;
                data.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
                claimRepUI.Add(data);
            }
            claimRepUI.Remove(claimRepUI[0]);

          

            List<string> availableSalesRep = DBHelper.GetAllClaimSalesRep();
            CollectionAssert.AreEqual(claimRepUI, availableSalesRep);

        }



        [When(@"the drop down list selections of the Carrier Name")]
        public void WhenTheDropDownListSelectionsOfTheCarrierName()
        {
            Report.WriteLine("the drop down list selections of the Carrier Name");
            Click(attributeName_xpath, CarrierName_Dropdown_ClaimDetailsPage_Xpath);
        }


        [Then(@"the Carrier Name drop down list will be configurable")]
        public void ThenTheCarrierNameDropDownListWillBeConfigurable()
        {
            Report.WriteLine("the Carrier Name drop down list will be configurable");
            IList<IWebElement> dropDownCarrierListUI = GlobalVariables.webDriver.FindElements(By.XPath(CarrierName_DropdownValues_ClaimDetailsPage_Xpath));
            List<string> carrierNameUI = new List<string>();
            for (int i = 0; i < dropDownCarrierListUI.Count; i++)
            {
                string data = dropDownCarrierListUI[i].Text;
                data.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
                carrierNameUI.Add(data);
            }

            carrierNameUI.Remove(carrierNameUI[0]);

            List<InsuredRateCarrier> claimCarrier = DBHelper.GetAllCarrierDetails();

            List<InsuredRateCarrier> insuranceClaimCarrier = DBHelper.GetAllCarrierDetails();
            List<string> insuranceClaimCarrierName = new List<string>();
            for (int i = 0; i < insuranceClaimCarrier.Count; i++)
            {
                string data = claimCarrier[i].CarrierName;
                data.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
                insuranceClaimCarrierName.Add(data);
            }


            CollectionAssert.AreEqual(carrierNameUI, insuranceClaimCarrierName);
        }

        [When(@"the drop down list selections of the Claim Reason")]
        public void WhenTheDropDownListSelectionsOfTheClaimReason()
        {
            Report.WriteLine("the drop down list selections of the Claim Reason");
            Click(attributeName_xpath, ClaimReason_Dropdown_ClaimDetailsPage_Xpath);
        }

        [Then(@"the Claim Reason drop down list will be configurable")]
        public void ThenTheClaimReasonDropDownListWillBeConfigurable()
        {
            Report.WriteLine("the Claim Reason drop down list will be configurable");
            IList<IWebElement> carrierReasonListUI = GlobalVariables.webDriver.FindElements(By.XPath(ClaimReason_DropdownValues_ClaimDetailsPage_Xpath));
            List<string> carrierReasonUI = new List<string>();
            for (int i = 0; i < carrierReasonListUI.Count; i++)
            {
                string data = carrierReasonListUI[i].Text;
                data.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
                carrierReasonUI.Add(data);
            }
            carrierReasonUI.Remove(carrierReasonUI[0]);

            List<string> availableReasons = DBHelper.GetAllClaimReasonCodes();

            CollectionAssert.AreEqual(carrierReasonUI, availableReasons);
        }



        [Then(@"DLS Claim Rep drop down list will not be editable")]
        public void ThenDLSClaimRepDropDownListWillNotBeEditable()
        {
            VerifyElementNotEnabled(attributeName_xpath, DlswClaimRep_dropdown_ClaimDetailsPage_Xpath, "DLSW CLAIM REP");
        }

        [Then(@"Station drop down list will not be editable")]
        public void ThenStationDropDownListWillNotBeEditable()
        {
            VerifyElementNotEnabled(attributeName_xpath, Station_Dropdown_ClaimDetailsPage_Xpath, "STATION");
        }

        [Then(@"DLSW Ref \# field will not be editable")]
        public void ThenDLSWRefFieldWillNotBeEditable()
        {
            VerifyElementNotEnabled(attributeName_id, DlswClaimNumber_Textbox_ClaimDetailsPage_Id, "DLS REF #");
        }

        [Then(@"Claimant field will not be editable")]
        public void ThenClaimantFieldWillNotBeEditable()
        {
            VerifyElementNotEnabled(attributeName_id, Claimant_Textbox_ClaimDetailsPage_Id, "CLAIMENT");
        }

        [Then(@"Claim Reason drop down list will not be editable")]
        public void ThenClaimReasonDropDownListWillNotBeEditable()
        {
            VerifyElementNotEnabled(attributeName_xpath, DlswClaimRep_dropdown_ClaimDetailsPage_Xpath, "CALIM REASON");
        }

        [Then(@"Carrier Name drop down list will not be editable")]
        public void ThenCarrierNameDropDownListWillNotBeEditable()
        {
            VerifyElementNotEnabled(attributeName_xpath, CarrierName_Dropdown_ClaimDetailsPage_Xpath, "CARRIER NAME");
        }

        [Then(@"Carrier PRO field will not be editable")]
        public void ThenCarrierPROFieldWillNotBeEditable()
        {
            VerifyElementNotEnabled(attributeName_id, CarrierPro_Textbox_ClaimDetailsPage_Id, "CARRIER PRO");
        }

        [Then(@"Insured field will not be editable")]
        public void ThenInsuredFieldWillNotBeEditable()
        {
            VerifyElementNotEnabled(attributeName_id, Insured_Dropdown_ClaimDetailsPage_Xpath, "INSURED");
           bool value= IsElementEnabled(attributeName_id, Insured_Dropdown_ClaimDetailsPage_Xpath, "INSURED");
        }

        [Then(@"DLSW Claim \# field will not be editable")]
        public void ThenDLSWClaimFieldWillNotBeEditable()
        {
            VerifyElementNotEnabled(attributeName_id, DlswClaimNumber_Textbox_ClaimDetailsPage_Id, "DLSW Claim #");
        }

        [Then(@"Carrier SCAC field will not be editable")]
        public void ThenCarrierSCACFieldWillNotBeEditable()
        {
            VerifyElementNotEnabled(attributeName_id, CarrierSCAC_Textbox_ClaimDetailsPage_Id, "CARRIER SCAC");
        }
    

        [Then(@"Date Requested field will not be editable")]
        public void ThenDateRequestedFieldWillNotBeEditable()
        {
            VerifyElementNotEnabled(attributeName_id, DateRequested_FieldValue_ClaimDetailsPage_Id, "DATE REQUESTED");
        }

        [Then(@"Claim Age field will not be editable")]
        public void ThenClaimAgeFieldWillNotBeEditable()
        {       
            VerifyElementNotEnabled(attributeName_id, ClaimAge_Textbox_ClaimDetailsPage_Id, "CLAIM AGE");
        }


        [Given(@"I clicked on the hyperlink of any Claim number which has valid Carrier has SCAC code from the Claim List page")]
        public void GivenIClickedOnTheHyperlinkOfAnyClaimNumberWhichHasValidCarrierHasSCACCodeFromTheClaimListPage()
        {
            Click(attributeName_id, ClaimsIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, ClaimsListPage_HeaderText_Xpath, "Claims List");
            string claimNumberValidCarrier;
            string gridFirstColumnHeader = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/thead/tr/th[1]");
            if (gridFirstColumnHeader == "CUSTOMER")
            {
                
                Report.WriteLine("logged in User is Internal");
                Click(attributeName_xpath, "//label[@for='FilterByStatusPending']");
                Click(attributeName_xpath, ClaimListGrid_PageViewOption_dropdown_Xpath);
                Click(attributeName_xpath, ".//*[@id='gridInsuranceClaimList_length']/label/select/option[5]");

                IList<IWebElement> GridCarrier = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='gridInsuranceClaimList']/tbody/tr/td[6]"));
                crmCarrierAllDetails = DBHelper.GetAllCarrierDetails();
                List<string> dbCarriers = crmCarrierAllDetails.Select(a => a.CarrierName).ToList();
                for (int i = 1; i <= GridCarrier.Count; i++)
                {
                    string gridCarrier = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr[" + i + "]/td[6]");
                    string[] carrierSplitted = gridCarrier.Split('\r');
                    string uiCarriername = carrierSplitted[0];
                    carrierValue = dbCarriers.Contains(uiCarriername);
                    if (carrierValue)
                    {
                        carrierNameValidCarrier = uiCarriername;
                        claimNumberValidCarrier = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr[" + i + "]/td[4]/span");
                        IWebElement element = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='gridInsuranceClaimList']/tbody/tr[" + i + "]/td[4]/span/a"));
                        IJavaScriptExecutor executor = (IJavaScriptExecutor)GlobalVariables.webDriver;
                        executor.ExecuteScript("arguments[0].click();", element);
                        i = GridCarrier.Count + 1;
                    }
                }
            }
            else if (gridFirstColumnHeader == "STA / CUST")
            {
                
                Report.WriteLine("logged in User is Claim Specialist User");
                Click(attributeName_xpath, "//label[@for='FilterByStatusPending']");
                Click(attributeName_xpath, ClaimListGrid_PageViewOption_dropdown_Xpath);
                Click(attributeName_xpath, ".//*[@id='gridInsuranceClaimList_length']/label/select/option[5]");

                IList<IWebElement> GridCarrier = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='gridInsuranceClaimList']/tbody/tr/td[7]"));
                List<InsuredRateCarrier> crmCarrierAllDetails = DBHelper.GetAllCarrierDetails();
                List<string> dbCarriers = crmCarrierAllDetails.Select(a => a.CarrierName).ToList();
                for (int i = 1; i <= GridCarrier.Count; i++)
                {
                    string gridCarrier = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr[" + i + "]/td[7]");
                    string[] carrierSplitted = gridCarrier.Split('\r');
                    string uiCarriername = carrierSplitted[0];
                    carrierValue = dbCarriers.Contains(uiCarriername);

                    if (carrierValue)
                    {
                        carrierNameValidCarrier = uiCarriername;
                        claimNumberValidCarrier = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr[" + i + "]/td[3]/span[1]/a");
                        IWebElement element = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='gridInsuranceClaimList']/tbody/tr[" + i + "]/td[3]/span[1]/a"));
                        IJavaScriptExecutor executor = (IJavaScriptExecutor)GlobalVariables.webDriver;
                        executor.ExecuteScript("arguments[0].click();", element);
                        i = GridCarrier.Count + 1;
                    }
                }
            }
        }



        [Given(@"I clicked on the hyperlink of any Claim number which has Invalid Carrier has SCAC code from the Claim List page")]
        public void GivenIClickedOnTheHyperlinkOfAnyClaimNumberWhichHasInvalidCarrierHasSCACCodeFromTheClaimListPage()
        {
            Click(attributeName_id, ClaimsIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, ClaimsListPage_HeaderText_Xpath, "Claims List");

            string gridFirstColumnHeader = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/thead/tr/th[1]");
            string claimNumberInvalidCarrier;
            if (gridFirstColumnHeader == "CUSTOMER")
            {
                
                Report.WriteLine("logged in User is Internal");
                Click(attributeName_xpath, "//label[@for='FilterByStatusPending']");
                Click(attributeName_xpath, ClaimListGrid_PageViewOption_dropdown_Xpath);
                Click(attributeName_xpath, ".//*[@id='gridInsuranceClaimList_length']/label/select/option[5]");

                IList<IWebElement> GridCarrier = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='gridInsuranceClaimList']/tbody/tr/td[6]"));
                crmCarrierAllDetails = DBHelper.GetAllCarrierDetails();
                List<string> dbCarriers = crmCarrierAllDetails.Select(a => a.CarrierName).ToList();
                for (int i = 1; i <= GridCarrier.Count; i++)
                {
                    string gridCarrier = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr[" + i + "]/td[6]");
                    string[] carrierSplitted = gridCarrier.Split('\r');
                    string uiCarriername = carrierSplitted[0];
                    carrierValue = !(dbCarriers.Contains(uiCarriername));
                    if (carrierValue)
                    {
                        //carrierNameInvalidCarrier = uiCarriername;
                        claimNumberInvalidCarrier = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr[" + i + "]/td[4]/span/a");
                        IWebElement element = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='gridInsuranceClaimList']/tbody/tr[" + i + "]/td[4]/span/a"));
                        IJavaScriptExecutor executor = (IJavaScriptExecutor)GlobalVariables.webDriver;
                        executor.ExecuteScript("arguments[0].click();", element);
                        i = GridCarrier.Count + 1;
                    }
                }
            }
            else if (gridFirstColumnHeader == "STA / CUST")
            {
               
                Report.WriteLine("logged in User is Claim Specialist User");
                Click(attributeName_xpath, "//label[@for='FilterByStatusPending']");
                Click(attributeName_xpath, ClaimListGrid_PageViewOption_dropdown_Xpath);
                Click(attributeName_xpath, ".//*[@id='gridInsuranceClaimList_length']/label/select/option[5]");

                IList<IWebElement> GridCarrier = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='gridInsuranceClaimList']/tbody/tr/td[7]"));
                List<InsuredRateCarrier> crmCarrierAllDetails = DBHelper.GetAllCarrierDetails();
                List<string> dbCarriers = crmCarrierAllDetails.Select(a => a.CarrierName).ToList();
                for (int i = 1; i <= GridCarrier.Count; i++)
                {
                    string gridCarrier = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr[" + i + "]/td[7]");
                    string[] carrierSplitted = gridCarrier.Split('\r');
                    string uiCarriername = carrierSplitted[0];
                    carrierValue = !(dbCarriers.Contains(uiCarriername));
                    if (carrierValue)
                    {
                        //carrierNameInvalidCarrier = uiCarriername;
                        claimNumberInvalidCarrier = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr[" + i + "]/td[3]/span[1]/a");

                        IWebElement element = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='gridInsuranceClaimList']/tbody/tr[" + i + "]/td[3]/span[1]/a"));
                        IJavaScriptExecutor executor = (IJavaScriptExecutor)GlobalVariables.webDriver;
                        executor.ExecuteScript("arguments[0].click();", element);
                        i = GridCarrier.Count + 1;
                      
                    }
                }
            }
        }

    }
}
