using CRM.UITest.CommonMethods;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Linq;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Insurance_Claims.Claim_Details
{
    [Binding]
    public class InsuranceClaimsDetailsTab_FrtCalcSectionEditingSteps : CRM.UITest.Objects.InsuranceClaim
    {
        string alphaNumerics = "ABCDEFGHIJ12345abcdefgh";

        [Given(@"I on the clicked any dlsw claim reference hyper link on the Claims List page")]
        public void GivenIOnTheClickedAnyDlswClaimReferenceHyperLinkOnTheClaimsListPage()
        {
            Click(attributeName_id, ClaimsIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, ClaimsListPage_HeaderText_Xpath, "Claims List");
            string gridFirstColumnHeader = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/thead/tr/th[1]");

            if (gridFirstColumnHeader == "CUSTOMER")
            {
                Report.WriteLine("logged in User is Internal");
                Click(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr[1]/td[4]/span/a");
            }
            else if (gridFirstColumnHeader == "STA / CUST")
            {
                Report.WriteLine("logged in User is Claim Specialist User");
                Click(attributeName_xpath, "//label[@for='FilterByStatusPending']");
                Click(attributeName_xpath, ClaimListGrid_PageViewOption_dropdown_Xpath);
                Click(attributeName_xpath, ".//*[@id='gridInsuranceClaimList_length']/label/select/option[5]");
                Click(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr[1]/td[3]/span[1]/a");
            }
            GlobalVariables.webDriver.WaitForPageLoad();
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, ClaimDetailsPage_Header_Xpath, "Claim Details");
        }


        [When(@"the Claimable field is Y for any of the Freight(.*)")]
        public void WhenTheClaimableFieldIsYForAnyOfTheFreight(string Type)
        {
            scrollElementIntoView(attributeName_xpath, FreightClauclulations_Label_Xpath);
            if (Type == "Original")
            {
                Click(attributeName_xpath, Claimable_dropdown_Original_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, Claimable_dropdownValue_Original_Xpath, "Y");
            }
            else if (Type == "Return")
            {
                Click(attributeName_xpath, Claimabledropdown_Return_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, ClaimabledropdownValue_Return_Xpath, "Y");
            }
            else if (Type == "Replacement")
            {
                Click(attributeName_xpath, Claimabledropdown_Replacement_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, ClaimabledropdownValue_Replacement_Xpath, "Y");
            }
        }

        [Then(@"the Claimed Freight will be editable as for each Freight(.*) as Optional, currency formatted, always display (.*) decimal places, always display (.*) before the value - \$xx,xxx\.xx")]
        public void ThenTheClaimedFreightWillBeEditableAsForEachFreightAsOptionalCurrencyFormattedAlwaysDisplayDecimalPlacesAlwaysDisplayBeforeTheValue_XxXxx_Xx(string Type, int p1, string p2)
        {
            if (Type == "Original")
            {
                Clear(attributeName_id, ClaimedFreight_Textbox_Original_Id);
                SendKeys(attributeName_id, ClaimedFreight_Textbox_Original_Id, "21");
                Click(attributeName_id, ClaimedFreight_Textbox_Return_Id);
                string claimedFreightValue = GetValue(attributeName_id, ClaimedFreight_Textbox_Original_Id, "value");
                string[] enteredValue_withdeciaml = claimedFreightValue.Split('.');
                string checking_TwoDeciaml_Places = enteredValue_withdeciaml[1].ToString();
                int checking_TwoDecial_Places_Count = checking_TwoDeciaml_Places.Count();
                string checkForTwoZero = checking_TwoDeciaml_Places.Substring(0, 2);
                Assert.AreEqual("00", checkForTwoZero);

                Report.WriteLine("Verifying Currency Format and its prefixed before the Claimed Freight Value");
                string currencyBeforeClaimedFreightValue = claimedFreightValue.Substring(0, 1);
                Assert.AreEqual("$", currencyBeforeClaimedFreightValue);


                if (checking_TwoDecial_Places_Count == 2)
                {
                    Report.WriteLine("Original Claimed Freight field is formatted to 2 decimal places");
                }
                else
                {
                    Assert.Fail("Original Claimed Freight field is not formatted to 2 decimal places");
                }
            }

            else if (Type == "Return")
            {
                Clear(attributeName_id, ClaimedFreight_Textbox_Return_Id);
                SendKeys(attributeName_id, ClaimedFreight_Textbox_Return_Id, "21");
                Click(attributeName_id, ClaimedFreight_Textbox_Original_Id);
                string claimedFreightValue = GetValue(attributeName_id, ClaimedFreight_Textbox_Return_Id, "value");
                string[] enteredValue_withdeciaml = claimedFreightValue.Split('.');
                string checking_TwoDeciaml_Places = enteredValue_withdeciaml[1].ToString();
                int checking_TwoDecial_Places_Count = checking_TwoDeciaml_Places.Count();
                string checkForTwoZero = checking_TwoDeciaml_Places.Substring(0, 2);
                Assert.AreEqual("00", checkForTwoZero);

                Report.WriteLine("Verifying Currency Format and its prefixed before the Claimed Freight Value");
                string currencyBeforeClaimedFreightValue = claimedFreightValue.Substring(0, 1);
                Assert.AreEqual("$", currencyBeforeClaimedFreightValue);


                if (checking_TwoDecial_Places_Count == 2)
                {
                    Report.WriteLine("Return Claimed Freight field is formatted to 2 decimal places");
                }
                else
                {
                    Assert.Fail("Return Claimed Freight field is not formatted to 2 decimal places");
                }
            }

            else if (Type == "Replacement")
            {
                Clear(attributeName_id, ClaimedFreight_Textbox_Replacement_Id);
                SendKeys(attributeName_id, ClaimedFreight_Textbox_Replacement_Id, "21");
                Click(attributeName_id, ClaimedFreight_Textbox_Replacement_Id);
                string claimedFreightValue = GetValue(attributeName_id, ClaimedFreight_Textbox_Replacement_Id, "value");
                string[] enteredValue_withdeciaml = claimedFreightValue.Split('.');
                string checking_TwoDeciaml_Places = enteredValue_withdeciaml[1].ToString();
                int checking_TwoDecial_Places_Count = checking_TwoDeciaml_Places.Count();
                string checkForTwoZero = checking_TwoDeciaml_Places.Substring(0, 2);
                Assert.AreEqual("00", checkForTwoZero);

                Report.WriteLine("Verifying Currency Format and its prefixed before the Claimed Freight Value");
                string currencyBeforeClaimedFreightValue = claimedFreightValue.Substring(0, 1);
                Assert.AreEqual("$", currencyBeforeClaimedFreightValue);


                if (checking_TwoDecial_Places_Count == 2)
                {
                    Report.WriteLine("Replacement Claimed Freight field is formatted to 2 decimal places");
                }
                else
                {
                    Assert.Fail("Replacement Claimed Freight field is not formatted to 2 decimal places");
                }
            }
        }

        [Then(@"the Carrier Charges to DLSW will be editable for each Freight(.*) as Optional, currency formatted, always display (.*) decimal places, always display (.*) before the value - \$xx,xxx\.xx")]
        public void ThenTheCarrierChargesToDLSWWillBeEditableForEachFreightAsOptionalCurrencyFormattedAlwaysDisplayDecimalPlacesAlwaysDisplayBeforeTheValue_XxXxx_Xx(string Type, int p1, string p2)
        {
            if (Type == "Original")
            {
                Clear(attributeName_id, CarrierChargesToDLSW_Textbox_Original_Id);
                SendKeys(attributeName_id, CarrierChargesToDLSW_Textbox_Original_Id, "22");
                Click(attributeName_id, ClaimedFreight_Textbox_Return_Id);
                string carreirChargesToDlswValue = GetValue(attributeName_id, CarrierChargesToDLSW_Textbox_Original_Id, "value");
                string[] enteredValue_withdeciaml = carreirChargesToDlswValue.Split('.');
                string checking_TwoDeciaml_Places = enteredValue_withdeciaml[1].ToString();
                int checking_TwoDecial_Places_Count = checking_TwoDeciaml_Places.Count();
                string checkForTwoZero = checking_TwoDeciaml_Places.Substring(0, 2);
                Assert.AreEqual("00", checkForTwoZero);

                Report.WriteLine("Verifying Currency Format and its prefixed before the Carrier Charges to Dlsw Value");
                string currencyBeforeClaimedFreightValue = carreirChargesToDlswValue.Substring(0, 1);
                Assert.AreEqual("$", currencyBeforeClaimedFreightValue);


                if (checking_TwoDecial_Places_Count == 2)
                {
                    Report.WriteLine("Carrier Charges to Dlsw field is formatted to 2 decimal places");
                }
                else
                {
                    Assert.Fail("Carrier Charges to Dlsw field is not formatted to 2 decimal places");
                }
            }

            else if (Type == "Return")
            {
                Clear(attributeName_id, CarrierChargesToDLSW_Textbox_Return_Id);
                SendKeys(attributeName_id, CarrierChargesToDLSW_Textbox_Return_Id, "22");
                Click(attributeName_id, ClaimedFreight_Textbox_Return_Id);
                string carrierChargesToDlswValue = GetValue(attributeName_id, CarrierChargesToDLSW_Textbox_Return_Id, "value");
                string[] enteredValue_withdeciaml = carrierChargesToDlswValue.Split('.');
                string checking_TwoDeciaml_Places = enteredValue_withdeciaml[1].ToString();
                int checking_TwoDecial_Places_Count = checking_TwoDeciaml_Places.Count();
                string checkForTwoZero = checking_TwoDeciaml_Places.Substring(0, 2);
                Assert.AreEqual("00", checkForTwoZero);

                Report.WriteLine("Verifying Currency Format and its prefixed before the Carrier Charges to Dlsw Value");
                string currencyBeforeClaimedFreightValue = carrierChargesToDlswValue.Substring(0, 1);
                Assert.AreEqual("$", currencyBeforeClaimedFreightValue);


                if (checking_TwoDecial_Places_Count == 2)
                {
                    Report.WriteLine("Carrier Charges to Dlsw field is formatted to 2 decimal places");
                }
                else
                {
                    Assert.Fail("Carrier Charges to Dlsw field is not formatted to 2 decimal places");
                }
            }

            else if (Type == "Replacement")
            {
                Clear(attributeName_id, CarrierChargesToDLSW_Textbox_Replacement_Id);
                SendKeys(attributeName_id, CarrierChargesToDLSW_Textbox_Replacement_Id, "22");
                Click(attributeName_id, ClaimedFreight_Textbox_Return_Id);
                string carrierChargesToDlswValue = GetValue(attributeName_id, CarrierChargesToDLSW_Textbox_Replacement_Id, "value");
                string[] enteredValue_withdeciaml = carrierChargesToDlswValue.Split('.');
                string checking_TwoDeciaml_Places = enteredValue_withdeciaml[1].ToString();
                int checking_TwoDecial_Places_Count = checking_TwoDeciaml_Places.Count();
                string checkForTwoZero = checking_TwoDeciaml_Places.Substring(0, 2);
                Assert.AreEqual("00", checkForTwoZero);

                Report.WriteLine("Verifying Currency Format and its prefixed before the Carrier Charges to Dlsw Value");
                string currencyBeforeClaimedFreightValue = carrierChargesToDlswValue.Substring(0, 1);
                Assert.AreEqual("$", currencyBeforeClaimedFreightValue);


                if (checking_TwoDecial_Places_Count == 2)
                {
                    Report.WriteLine("Carrier Charges to Dlsw field is formatted to 2 decimal places");
                }
                else
                {
                    Assert.Fail("Carrier Charges to Dlsw field is not formatted to 2 decimal places");
                }
            }
        }

        [Then(@"the Charges to Cust will be editable for each Freight(.*) as Optional, currency formatted, always display (.*) decimal places, always display (.*) before the value - \$xx,xxx\.xx")]
        public void ThenTheChargesToCustWillBeEditableForEachFreightAsOptionalCurrencyFormattedAlwaysDisplayDecimalPlacesAlwaysDisplayBeforeTheValue_XxXxx_Xx(string Type, int p1, string p2)
        {
            if (Type == "Original")
            {
                Clear(attributeName_id, DLSWChargesToCust_Textbox_Original_Id);
                SendKeys(attributeName_id, DLSWChargesToCust_Textbox_Original_Id, "23");
                Click(attributeName_id, ClaimedFreight_Textbox_Return_Id);
                string dlswChargesToCustValue = GetValue(attributeName_id, DLSWChargesToCust_Textbox_Original_Id, "value");
                string[] enteredValue_withdeciaml = dlswChargesToCustValue.Split('.');
                string checking_TwoDeciaml_Places = enteredValue_withdeciaml[1].ToString();
                int checking_TwoDecial_Places_Count = checking_TwoDeciaml_Places.Count();
                string checkForTwoZero = checking_TwoDeciaml_Places.Substring(0, 2);
                Assert.AreEqual("00", checkForTwoZero);

                Report.WriteLine("Verifying Currency Format and its prefixed before the Dlsw Charges to Cust Value");
                string currencyBeforeClaimedFreightValue = dlswChargesToCustValue.Substring(0, 1);
                Assert.AreEqual("$", currencyBeforeClaimedFreightValue);


                if (checking_TwoDecial_Places_Count == 2)
                {
                    Report.WriteLine("Dlsw Charges to Cust field is formatted to 2 decimal places");
                }
                else
                {
                    Assert.Fail("Dlsw Charges to Cust field is not formatted to 2 decimal places");
                }
            }

            else if (Type == "Return")
            {
                Clear(attributeName_id, DLSWChargesToCust_Textbox_Return_Id);
                SendKeys(attributeName_id, DLSWChargesToCust_Textbox_Return_Id, "23");
                Click(attributeName_id, ClaimedFreight_Textbox_Return_Id);
                string dlswChargesToCustValue = GetValue(attributeName_id, DLSWChargesToCust_Textbox_Return_Id, "value");
                string[] enteredValue_withdeciaml = dlswChargesToCustValue.Split('.');
                string checking_TwoDeciaml_Places = enteredValue_withdeciaml[1].ToString();
                int checking_TwoDecial_Places_Count = checking_TwoDeciaml_Places.Count();
                string checkForTwoZero = checking_TwoDeciaml_Places.Substring(0, 2);
                Assert.AreEqual("00", checkForTwoZero);

                Report.WriteLine("Verifying Currency Format and its prefixed before the Dlsw Charges to Cust Value");
                string currencyBeforeClaimedFreightValue = dlswChargesToCustValue.Substring(0, 1);
                Assert.AreEqual("$", currencyBeforeClaimedFreightValue);


                if (checking_TwoDecial_Places_Count == 2)
                {
                    Report.WriteLine("Dlsw Charges to Cust field is formatted to 2 decimal places");
                }
                else
                {
                    Assert.Fail("Dlsw Charges to Cust field is not formatted to 2 decimal places");
                }
            }

            else if (Type == "Replacement")
            {
                Clear(attributeName_id, DLSWChargesToCust_Textbox_Replacement_Id);
                SendKeys(attributeName_id, DLSWChargesToCust_Textbox_Replacement_Id, "23");
                Click(attributeName_id, ClaimedFreight_Textbox_Return_Id);
                string dlswChargesToCustValue = GetValue(attributeName_id, DLSWChargesToCust_Textbox_Replacement_Id, "value");
                string[] enteredValue_withdeciaml = dlswChargesToCustValue.Split('.');
                string checking_TwoDeciaml_Places = enteredValue_withdeciaml[1].ToString();
                int checking_TwoDecial_Places_Count = checking_TwoDeciaml_Places.Count();
                string checkForTwoZero = checking_TwoDeciaml_Places.Substring(0, 2);
                Assert.AreEqual("00", checkForTwoZero);

                Report.WriteLine("Verifying Currency Format and its prefixed before the Dlsw Charges to Cust Value");
                string currencyBeforeClaimedFreightValue = dlswChargesToCustValue.Substring(0, 1);
                Assert.AreEqual("$", currencyBeforeClaimedFreightValue);


                if (checking_TwoDecial_Places_Count == 2)
                {
                    Report.WriteLine("Dlsw Charges to Cust field is formatted to 2 decimal places");
                }
                else
                {
                    Assert.Fail("Dlsw Charges to Cust field is not formatted to 2 decimal places");
                }
            }
        }

        [Then(@"the DLSW Ref \# will be editable for each Freight(.*) as Optional, alpha-numeric, text, max length (.*) characters")]
        public void ThenTheDLSWRefWillBeEditableForEachFreightAsOptionalAlpha_NumericTextMaxLengthCharacters(string Type, int p1)
        {
            if (Type == "Original")
            {
                Clear(attributeName_id, DLSWRefNumeber_Textbox_Original_Id);
                SendKeys(attributeName_id, DLSWRefNumeber_Textbox_Original_Id, alphaNumerics);
                string maxCharactersDLSWRefNumeberOriginalField = GetValue(attributeName_id, DLSWRefNumeber_Textbox_Original_Id, "value");
                int count = maxCharactersDLSWRefNumeberOriginalField.Count();
                if (count == 20)
                {
                    Report.WriteLine("Original Type DLSW Ref field Max Character is 20");
                }
                else
                {
                    Assert.Fail("Original Type DLSW Ref field Max Character is not 20");
                }
            }

            else if (Type == "Return")
            {
                Clear(attributeName_id, DLSWRefNumeber_Textbox_Return_Id);
                SendKeys(attributeName_id, DLSWRefNumeber_Textbox_Return_Id, alphaNumerics);
                string maxCharactersDLSWRefNumeberOriginalField = GetValue(attributeName_id, DLSWRefNumeber_Textbox_Return_Id, "value");
                int count = maxCharactersDLSWRefNumeberOriginalField.Count();
                if (count == 20)
                {
                    Report.WriteLine("Return Type DLSW Ref field Max Character is 20");
                }
                else
                {
                    Assert.Fail("Return Type DLSW Ref field Max Character is not 20");
                }
            }
            else if (Type == "Replacement")
            {
                Clear(attributeName_id, DLSWRefNumeber_Textbox_Replacement_Id);
                SendKeys(attributeName_id, DLSWRefNumeber_Textbox_Replacement_Id, alphaNumerics);
                string maxCharactersDLSWRefNumeberOriginalField = GetValue(attributeName_id, DLSWRefNumeber_Textbox_Replacement_Id, "value");
                int count = maxCharactersDLSWRefNumeberOriginalField.Count();
                if (count == 20)
                {
                    Report.WriteLine("Return Type DLSW Ref field Max Character is 20");
                }
                else
                {
                    Assert.Fail("Return Type DLSW Ref field Max Character is not 20");
                }
            }
        }

        [When(@"the Claimable field is N for any of the FreightTypes(.*)")]
        public void WhenTheClaimableFieldIsNForAnyOfTheFreightTypes(string Type)
        {
            if (Type == "Original")
            {
                scrollElementIntoView(attributeName_xpath, FreightClauclulations_Label_Xpath);
                Click(attributeName_xpath, Claimable_dropdown_Original_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, Claimable_dropdownValue_Original_Xpath, "N");
            }
            else if (Type == "Return")
            {
                scrollElementIntoView(attributeName_xpath, FreightClauclulations_Label_Xpath);
                Click(attributeName_xpath, Claimabledropdown_Return_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, ClaimabledropdownValue_Return_Xpath, "N");
            }
            else if (Type == "Replacement")
            {
                scrollElementIntoView(attributeName_xpath, FreightClauclulations_Label_Xpath);
                Click(attributeName_xpath, Claimabledropdown_Replacement_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, ClaimabledropdownValue_Replacement_Xpath, "N");
            }
        }

        [Then(@"the Claimed Freight field be Non-editable for each Freight(.*)")]
        public void ThenTheClaimedFreightFieldBeNon_EditableForEachFreight(string Type)
        {
            if (Type == "Original")
            {   
                VerifyElementNotEnabled(attributeName_id, ClaimedFreight_Textbox_Original_Id, "Original Claimed Freight textbox");
            }
            else if (Type == "Return")
            {
                VerifyElementNotEnabled(attributeName_id, ClaimedFreight_Textbox_Return_Id, "Return Claimed Freight Textbox");
            }
            else if (Type == "Replacement")
            {
                VerifyElementNotEnabled(attributeName_id, ClaimedFreight_Textbox_Replacement_Id, "Replacement Claimed Freight Textbox");
            }
        }


        [Then(@"the Carrier Charges to DLSW field will be Non-editable for each Freight(.*)")]
        public void ThenTheCarrierChargesToDLSWFieldWillBeNon_EditableForEachFreight(string Type)
        {
            if (Type == "Original")
            {
                VerifyElementNotEnabled(attributeName_id, CarrierChargesToDLSW_Textbox_Original_Id, "Original Carrier Charges to DLSW Textbox");
            }
            else if (Type == "Return")
            {
                VerifyElementNotEnabled(attributeName_id, CarrierChargesToDLSW_Textbox_Return_Id, "Return Carrier Charges to DLSW Textbox");
            }
            else if (Type == "Replacement")
            {
                VerifyElementNotEnabled(attributeName_id, CarrierChargesToDLSW_Textbox_Replacement_Id, "Replacement Carrier Charges to DLSW Textbox");
            }
        }


        [Then(@"the DLSW Charges to Cust field will be Non-editable for each Freight(.*)")]
        public void ThenTheDLSWChargesToCustFieldWillBeNon_EditableForEachFreight(string Type)
        {
            if (Type == "Original")
            {
                VerifyElementNotEnabled(attributeName_id, DLSWChargesToCust_Textbox_Original_Id, "Original DLSW Charges to Cust Textbox");
            }
            else if (Type == "Return")
            {
                VerifyElementNotEnabled(attributeName_id, DLSWChargesToCust_Textbox_Return_Id, "Return DLSW Charges to Cust Textbox");
            }
            else if (Type == "Replacement")
            {
                VerifyElementNotEnabled(attributeName_id, DLSWChargesToCust_Textbox_Replacement_Id, "Replacement DLSW Charges to Cust Textbox");
            }
        }

        [Then(@"the DLSW Ref \# field will be Non-editable for each Freight(.*)")]
        public void ThenTheDLSWRefFieldWillBeNon_EditableForEachFreight(string Type)
        {
            if (Type == "Original")
            {
                VerifyElementNotEnabled(attributeName_id, DLSWRefNumeber_Textbox_Original_Id, "Original DLSW Reference Number Textbox");
            }
            else if (Type == "Return")
            {
                VerifyElementNotEnabled(attributeName_id, DLSWRefNumeber_Textbox_Return_Id, "Return DLSW Reference Number Textbox");
            }
            else if (Type == "Replacement")
            {
                VerifyElementNotEnabled(attributeName_id, DLSWRefNumeber_Textbox_Replacement_Id, "Replacement DLSW Reference Number Textbox");
            }
        }
        

        [Then(@"the Claimable Freight Type will be Non-editable for each Freight(.*)")]
        public void ThenTheClaimableFreightTypeWillBeNon_EditableForEachFreight(string Type)
        {
            scrollElementIntoView(attributeName_xpath, FreightClauclulations_Label_Xpath);
            if (Type == "Original")
            {
                bool disableCheck = IsElementDisabled(attributeName_xpath, Claimable_dropdown_Original_Xpath, "Original Claimable Tye dropdown");
                Assert.IsTrue(disableCheck);
            }
            else if (Type == "Return")
            {
                bool disableCheck = IsElementDisabled(attributeName_xpath, Claimabledropdown_Return_Xpath, "Return Claimable Tye dropdown");
                Assert.IsTrue(disableCheck);
            }
            else if (Type == "Replacement")
            {
                bool disableCheck = IsElementDisabled(attributeName_xpath, Claimabledropdown_Replacement_Xpath, "Replacement Claimable Tye dropdown");
                Assert.IsTrue(disableCheck);
            }
        }
    }
}
