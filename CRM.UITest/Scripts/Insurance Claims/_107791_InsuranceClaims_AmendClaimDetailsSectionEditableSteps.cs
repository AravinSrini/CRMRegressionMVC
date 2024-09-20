using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Helper.ViewModel;
using CRM.UITest.Entities.DocRepo;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using System.Threading;

namespace CRM.UITest.Scripts.Insurance_Claims
{
    [Binding]
    public class _107791_InsuranceClaims_AmendClaimDetailsSectionEditableSteps : InsuranceClaim
    {
        string _claimnumber = string.Empty;
        public List<string> associated_documentsfromUI = new List<string>();
        public List<string> associated_documentsfromDB = new List<string>();
        List<InsuranceClaimItems> claimItems;
        InsuranceClaimViewModel ClaimDetails = null;
        bool freightCharges;

        [Given(@"I click on the edit icon of a claim in Amend Claim status(.*)")]
        public void GivenIClickOnTheEditIconOfAClaimInAmendClaimStatus(string userName)
        {
            if (userName == "username-CurrentsprintClaimspecialist")
            {
                Click(attributeName_xpath, ClaimlistGridFilterbySubmittedCheckbox_Xpath);
                Click(attributeName_xpath, ClaimsList_AmendCheckbox_xpath);
                Click(attributeName_xpath, ClaimsList_SubmitDateColClick_Xpath);
                GlobalVariables.webDriver.WaitForPageLoad();
                Report.WriteLine("Click on Edit icon");
                string claimnumber = Gettext(attributeName_xpath, ClaimNumber_FirstAmend_Xpath);
                string[] _ClaimNumber = claimnumber.Split(new char[0]);
                _claimnumber = _ClaimNumber[1];
                Click(attributeName_xpath, ClaimListEditIcon_Xpath);
                GlobalVariables.webDriver.WaitForPageLoad();
            }
            else
            {
                Report.WriteLine("Click on Edit icon");
                Click(attributeName_xpath, ClaimlistGridFilterbySubmittedCheckbox_Xpath);
                Click(attributeName_xpath, ClaimsList_AmendCheckbox_xpath);
                Click(attributeName_xpath, ClaimsList_SubmitDateColClick_Xpath);
                GlobalVariables.webDriver.WaitForPageLoad();

                _claimnumber = Gettext(attributeName_xpath, ClaimNumber_FirstAmend_Xpath);
                Click(attributeName_xpath, ClaimListEditIcon_Xpath);
                GlobalVariables.webDriver.WaitForPageLoad();
            }
        }

        [Given(@"I arrive on the Submit a Claim page of Amend claim,")]
        [When(@"I arrive on the Submit a Claim page of Amend claim,")]
        public void IArriveOnTheSubmitAClaimPageOfAmendClaim()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            string expHeader = "Submit a Claim" + " " + "(Claim " + "# " + _claimnumber + ")";            
            string actHeader = Gettext(attributeName_xpath, Submit_A_Claim_Page_Header_Text_Xpath);
            if (expHeader.Equals(actHeader))
            {
                Report.WriteLine("Arrived on the Submit a Claim page of Amend claim");
            }
            else
            {
                Report.WriteFailure("Submit a Claim page of Amend claim is not displayed");
            }
        }

        [Then(@"the Submit a Claim form will be auto-populated with the data of the claim")]
        public void ThenTheSubmitAClaimFormWillBeAuto_PopulatedWithTheDataOfTheClaim()
        {
            Report.WriteLine("Verifying the Claim Details Section of Submit Claim form auto-populated");
            int claimnumber = Convert.ToInt32(_claimnumber);
            ClaimDetails = DBHelper.GetInsuranceClaimValues(claimnumber);
            string outstandingAmountDB = DBHelper.GetOustandingAmount(_claimnumber);

            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();

            //Verifying Articles Insured
            if (ClaimDetails.IsArticlesIns == true)
            {
                VerifyElementChecked(attributeName_xpath, AmendClaim_ArticlesIns_YES_Xpath, "Yes");
                string insuredValueUI = GetValue(attributeName_xpath, AmendClaim_InsuredValue_Xpath, "value");
                Assert.AreEqual("$" + ClaimDetails.InsuredValAmount, insuredValueUI);
            }
            else
            {
                VerifyElementNotChecked(attributeName_xpath, AmendClaim_ArticlesIns_YES_Xpath, "Yes");
                VerifyElementChecked(attributeName_xpath, AmendClaim_ArticlesIns_NO_Xpath, "No");
            }

            claimItems = ClaimDetails.InsuranceclaimItem;
            for (int i = 0; i < claimItems.Count; i++)
            {
                // Verifying Claim Type
                if (claimItems[i].claimTypeId == 1)
                {
                    VerifyElementChecked(attributeName_id, Shortage_Id, "Shortage");
                }
                else if (claimItems[i].claimTypeId == 2)
                {
                    VerifyElementChecked(attributeName_id, Damage_Id, "Damage");
                }

                // Verifying Articles Type
                if (claimItems[i].aritcleTypeId == 1)
                {
                    VerifyElementChecked(attributeName_id, ArticlesNew_Id, "New");
                }
                else if (claimItems[i].aritcleTypeId == 2)
                {
                    VerifyElementChecked(attributeName_id, ArticlesUsed_Id, "Used");
                }

                //Verifying Item/Model#
                string _modelnumberdb = string.Empty;
                string itemModalUI = GetValue(attributeName_id, ItemMode_Number_Id, "value");
                if (!string.IsNullOrWhiteSpace(claimItems[i].itemNum))
                {
                    _modelnumberdb = claimItems[i].itemNum;
                }
                else
                {
                    _modelnumberdb = string.Empty;
                }
                Assert.AreEqual(_modelnumberdb, itemModalUI);//UI and DB

                //Verifying Unit Value
                string _unitvaluedb = claimItems[i].unitVal.ToString();
                string unitValUI = GetValue(attributeName_id, UnitValue_Id, "value");
                string unitValueUI = unitValUI.Replace(",", "");
                Assert.AreEqual("$" + _unitvaluedb, unitValueUI);//UI and DB

                //Verifying Quantity
                string _quantitydb = claimItems[i].quantity.ToString();
                string quantityUI = GetValue(attributeName_id, Quantity_Id, "value");
                string quantityValueUI = quantityUI.Replace(",", "");
                Assert.AreEqual(_quantitydb, quantityValueUI);//UI and DB

                //Verifying Weight
                string _weightdb = claimItems[i].weight.ToString();
                string weightUI = GetValue(attributeName_id, Weight_LBS_Id, "value");
                string weightValueUI = weightUI.Replace(",", "");
                Assert.AreEqual(_weightdb, weightValueUI);//UI and DB

                //Verifying Descripton
                string _description = claimItems[i].description.ToString();
                string descriptionUI = GetValue(attributeName_id, ClaimedArticle_Description_Id, "value");
                string descriptionValueUI = descriptionUI.Replace(",", "");
                Assert.AreEqual(_description, descriptionValueUI);//UI and DB
            }
            scrollpagedown();

            freightCharges = GlobalVariables.webDriver.FindElement(By.XPath(AmendClaim_FreightCharges_YES_Xpath)).Selected; //IsElement Visible method didn't work

            //Freight Charges            
            if (freightCharges)
            {
                Report.WriteLine("Freight Charges added");

                //Verifying Original Freight Charges
                VerifyElementChecked(attributeName_xpath, AmendClaim_OriginalFreightChargesOption_Xpath, "Original Freight Charges");
                string _originalFreightChargedb = string.Empty;
                string _originalFreightChargeUI = GetValue(attributeName_xpath, OriginFreightChargeVal_Xpath, "value");
                string originalFreightChargeValueUI = _originalFreightChargeUI.Replace(",", "");
                if (ClaimDetails.OriginalFreightCharge != null)
                {
                    _originalFreightChargedb = ClaimDetails.OriginalFreightCharge.ToString();
                    Assert.AreEqual("$" + _originalFreightChargedb, originalFreightChargeValueUI);//UI
                }
                else
                {
                    Assert.AreEqual(string.Empty, _originalFreightChargeUI);
                }

                //Verifying Return Freight Charges
                bool _isReturnFreightChargeOptiondb = Convert.ToBoolean(ClaimDetails.IsReturnFreightCharge);
                if (_isReturnFreightChargeOptiondb)
                {
                    VerifyElementChecked(attributeName_xpath, AmendClaim_ReturnFreightChargesOption_Xpath, "Return Freight Charge");
                }
                else
                {
                    VerifyElementNotChecked(attributeName_xpath, AmendClaim_ReturnFreightChargesOption_Xpath, "Return Freight Charge");
                }

                string _returnFreightChargedb = string.Empty;
                string returnFreightChargeUI = GetValue(attributeName_xpath, AmendClaim_ReturnFreightChargesValue_Xpath, "value");
                string returnFreightChargeValueUI = returnFreightChargeUI.Replace(",", "");
                if (ClaimDetails.ReturnFreightCharge != null)
                {
                    _returnFreightChargedb = ClaimDetails.ReturnFreightCharge.ToString();
                    Assert.AreEqual("$" + _returnFreightChargedb, returnFreightChargeValueUI);//UI
                }
                else
                {
                    Assert.AreEqual(string.Empty, returnFreightChargeUI);//UI
                }
                string _returnFreightChargeReferenceValuedb = string.Empty;
                string returnFreightChargeReferenceValueUI = GetValue(attributeName_xpath, AmendClaim_ReturnFreightChargesDLSW_Xpath, "value");
                if (ClaimDetails.ReturnDLSRefNum != null)
                {
                    _returnFreightChargeReferenceValuedb = ClaimDetails.ReturnDLSRefNum;
                    Assert.AreEqual(_returnFreightChargeReferenceValuedb, returnFreightChargeReferenceValueUI);//UI
                }
                else
                {
                    Assert.AreEqual(string.Empty, returnFreightChargeReferenceValueUI);//UI
                }
                scrollpagedown();

                //Verifying Replacement Freight Charges
                bool _isReplacementFrightChargeoption = Convert.ToBoolean(ClaimDetails.IsReplacementFreightCharge);
                if (_isReplacementFrightChargeoption)
                {
                    VerifyElementChecked(attributeName_xpath, AmendClaim_ReplacementFreightChargesOption_Xpath, "Replacement Freight Charge");
                }
                else
                {
                    VerifyElementNotChecked(attributeName_xpath, AmendClaim_ReplacementFreightChargesOption_Xpath, "Replacement Freight Charge");
                }
                string _replacementFreightChargedb = string.Empty;
                string replacementFreightChargeUI = GetValue(attributeName_xpath, AmendClaim_ReplacementFreightChargesValues_Xpath, "value");
                string replacementFreightChargeValueUI = replacementFreightChargeUI.Replace(",", "");
                if (ClaimDetails.ReplacementFreightCharge != null)
                {
                    _replacementFreightChargedb = ClaimDetails.ReplacementFreightCharge.ToString();
                    Assert.AreEqual("$" + _replacementFreightChargedb, replacementFreightChargeValueUI);//UI
                }
                else
                {
                    Assert.AreEqual(string.Empty, replacementFreightChargeUI);//UI
                }
                string _replacementFreightChargeReferenceValuedb = string.Empty;
                string replacementFreightChargeReferenceValueUI = GetValue(attributeName_xpath, AmendClaim_ReplacementFreightChargesDLSW_Xpath, "value");
                if (ClaimDetails.ReplaceDLSWRefNum != null)
                {
                    _replacementFreightChargeReferenceValuedb = ClaimDetails.ReplaceDLSWRefNum;
                    Assert.AreEqual(_replacementFreightChargeReferenceValuedb, replacementFreightChargeReferenceValueUI);//UI
                }
                else
                {
                    Assert.AreEqual(string.Empty, replacementFreightChargeReferenceValueUI);//UI
                }

                //Verifying Subtotal All Claim value
                string subTotalClaimValueUI = GetValue(attributeName_xpath, AmendClaim_SubTotalAllClaimValue_Xpath, "value");
                string subTotalClaimValue = subTotalClaimValueUI.Replace(",", "");
                Assert.AreEqual("$" + outstandingAmountDB, subTotalClaimValue);//UI
            }
            else
            {
                Report.WriteLine("No Freight Charges added");
                VerifyElementChecked(attributeName_xpath, AmendClaim_FreightCharges_NO_Xpath, "No");
            }
        }

        [Then(@"I verify the Claim Type field is editable")]
        public void ThenIVerifyTheClaimTypeFieldIsEditable()
        {
            scrollpagedown();
            VerifyElementEnabled(attributeName_xpath, ClaimTypeField_Xpath, "Claim Type");
            for (int i = 0; i < claimItems.Count; i++)
            {
                // Verifying Claim Type is editable
                if (claimItems[i].claimTypeId == 1)
                {
                    Click(attributeName_xpath, DamageOption_Xpath);
                }
                else
                {
                    Click(attributeName_xpath, ShortageOption_Xpath);
                }
            }
            Report.WriteLine("Claim Type field is editable");
        }

        [Then(@"I verify the Articles Type field is editable")]
        public void ThenIVerifyTheArticlesTypeFieldIsEditable()
        {
            VerifyElementEnabled(attributeName_xpath, ArticlesTypeLabel_Xpath, "Articles Type");
            for (int i = 0; i < claimItems.Count; i++)
            {
                // Verifying Articles Type is editable
                if (claimItems[i].aritcleTypeId == 1)
                {
                    Click(attributeName_xpath, ArticlesTypeUsed_Xpath);
                }
                else
                {
                    Click(attributeName_xpath, ArticlesTypeNew_Xpath);
                }
            }
            Report.WriteLine("Articles Type field is editable");
        }

        [Then(@"I verify the Insured Value Amount field is editable and required if Articles Insured All Risk = Yes, currency formatted")]
        public void ThenIVerifyTheInsuredValueAmountFieldIsEditableAndRequiredIfArticlesInsuredAllRiskYesCurrencyFormatted()
        {
            Report.WriteLine("verify the Insured Value Amount field is editable and required if Articles Insured All Risk = Yes, currency formatted");
            VerifyElementNotChecked(attributeName_xpath, ArticlesInsuredYes_Xpath, "Yes");
            Click(attributeName_xpath, ArticlesInsuredYes_Xpath);
            WaitForElementVisible(attributeName_xpath, AmendClaim_InsuredValue_Xpath, "Insured value");
            SendKeys(attributeName_xpath, AmendClaim_InsuredValue_Xpath, "223");
            Click(attributeName_xpath, ArticlesInsured_Label_Xpath);
            string GetUIVal = GetValue(attributeName_xpath, AmendClaim_InsuredValue_Xpath, "value");
            Assert.AreEqual("$223.00", GetUIVal);


            Report.WriteLine("Verifying the Insured Value Amount field when Articles Insured selected as NO");
            Click(attributeName_xpath, ArticlesInsuredNo_Xpath);
            VerifyElementNotVisible(attributeName_id, InsuredAmount_Id, "Insured value");


        }

        [Then(@"I verify the Item/Model field is editable, alpha-numeric, text, special characters, max length 50")]
        public void ThenIVerifyTheItemModelFieldIsEditableAlpha_NumericTextSpecialCharactersMaxLength50()
        {
            //verification for alpha numeric
            SendKeys(attributeName_id, ItemMode_Number_Id, "abc123");
            string itemOrModelValue = GetValue(attributeName_id, ItemMode_Number_Id, "value");
            Assert.AreEqual(itemOrModelValue, "abc123");

            //verification for text
            SendKeys(attributeName_id, ItemMode_Number_Id, "textverify");
            string itemOrModelValueText = GetValue(attributeName_id, ItemMode_Number_Id, "value");
            Assert.AreEqual(itemOrModelValueText, "textverify");

            //verifcation for special characters
            SendKeys(attributeName_id, ItemMode_Number_Id, "!@#$%");
            string specialCharactersOfItemOrModelValue = GetValue(attributeName_id, ItemMode_Number_Id, "value");
            Assert.AreEqual(specialCharactersOfItemOrModelValue, "!@#$%");

            //verification for maximum length_50
            SendKeys(attributeName_id, ItemMode_Number_Id, "abcdefghijklmnovpqrstuvwxyzabcdefghijklmnovpqrs1U$");
            string maximumLengthOfItemOrModelValue = GetValue(attributeName_id, ItemMode_Number_Id, "value");
            Assert.AreEqual(maximumLengthOfItemOrModelValue, "abcdefghijklmnovpqrstuvwxyzabcdefghijklmnovpqrs1U$");

            //verification for maximum length_more than 50
            SendKeys(attributeName_id, ItemMode_Number_Id, "abcdefghijklmnovpqrstuvwxyzabcdefghijklmnovpqrstuvwxyz");
            string moreThanMaximumLengthOfItemOrModelValue = GetValue(attributeName_id, ItemMode_Number_Id, "value");
            Assert.AreEqual(moreThanMaximumLengthOfItemOrModelValue, "abcdefghijklmnovpqrstuvwxyzabcdefghijklmnovpqrstuv");
        }

        [Then(@"I verify the Unit Value field is editable and currency formated")]
        public void ThenIVerifyTheUnitValueFieldIsEditableAndCurrencyFormated()
        {
            VerifyElementEnabled(attributeName_id, UnitValue_Id, "Unit Value");
            Report.WriteLine("Unit Value is editable");
            SendKeys(attributeName_id, UnitValue_Id, "223");
            Click(attributeName_id, Quantity_Id);
            string unitUIVal = GetValue(attributeName_id, UnitValue_Id, "value");
            Assert.AreEqual("$223.00", unitUIVal);
            Report.WriteLine("Able to pass value to Unit value field and the format is currency");
        }

        [Then(@"I verify the Quantity field is editable, numeric, whole numbers, greater than 0")]
        public void ThenIVerifyTheQuantityFieldIsEditableNumericWholeNumbersGreaterThan0()
        {
            VerifyElementEnabled(attributeName_id, Quantity_Id, "Quantity");
            Report.WriteLine("Verifying Quantity is editable");

            SendKeys(attributeName_id, Quantity_Id, "445");
            Click(attributeName_id, UnitValue_Id);
            string quantityValue = GetValue(attributeName_id, Quantity_Id, "value");
            Assert.AreEqual("445", quantityValue);
            Report.WriteLine("Able to pass value greater than zero in the quantity field");

            SendKeys(attributeName_id, Quantity_Id, "0");
            Click(attributeName_id, UnitValue_Id);
            string GetQuantityVal = GetValue(attributeName_id, Quantity_Id, "value");
            Assert.AreNotEqual("0", GetQuantityVal);
            Report.WriteLine("Quantity field is validated by trying to pass zero");
        }

        [Then(@"I verify the Weight field is editable, numeric, 2 decimal places <xxx,xxx.xx>")]
        public void ThenIVerifyTheWeightFieldIsEditableNumeric2DecimalPlaces()
        {
            VerifyElementEnabled(attributeName_id, Weight_LBS_Id, "Weight");
            Report.WriteLine("Verifying Weight is editable");

            SendKeys(attributeName_id, Weight_LBS_Id, "223");
            Click(attributeName_id, Quantity_Id);
            string GrtUIVal = GetAttribute(attributeName_id, Weight_LBS_Id, "value");
            Assert.AreEqual("223.00", GrtUIVal);
            Report.WriteLine("Able to pass value to value to Weight field and the value is ending with #");

            //verification for numeric only
            SendKeys(attributeName_id, Weight_LBS_Id, "abc123");
            IWebElement activeFromElement = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            activeFromElement.SendKeys(Keys.Tab);
            string weight = GetValue(attributeName_id, Weight_LBS_Id, "value");
            Assert.AreEqual("123.00", weight);
        }

        [Then(@"I verify the Description of Claimed Articles field is editable, alpha-numeric, text, special characters, 500 characters")]
        public void ThenIVerifyTheDescriptionOfClaimedArticlesFieldIsEditableAlpha_NumericTextSpecialCharacters500Characters()
        {
            VerifyElementEnabled(attributeName_id, ClaimedArticle_Description_Id, "Description of Claimed Articles");
            Report.WriteLine("Description of Claimed Articles is editable");

            // Description Maxlength verification
            string Description = "cvdert 12345 !@#$% :{_ vbnmjhgfd tr56789 zaqwertgb chdsf fhmndsf dsfjesfsd fjeyfs f756b cfu75wegfb dsj4y6wsb x@#$%^&*( fdhtfsd fsyrt fuy7ety7832674832 sduyetdgjwtrw fjhew6537rbd asfy3w4trgfjhrt5rfygbestruewf eu3564gdb cxsry3wtrfuwet yrewtr7uwj@$#$#^&*(^&%&FJDSGJFGES7R FUYEF SERUEWF ESRUEWF SE753F CSDR7WUF SDRU4E875346587236 7EWRFGSJDRGWESF 458734ERFBSMRF RESUIRYHESB MR783RFS DFUW4YRFBSDBTR784EF SJERYWEJF EW895YRHEWIT834YWEFN E57834EWFB DSRUIWYEHDJMDSFUJMV FBEWR7TFUVBDSE78RFUCJFGDBCDFJKCJU6gdgddd";
            SendKeys(attributeName_id, ClaimedArticle_Description_Id, Description);
            string getdesUIVal = GetAttribute(attributeName_id, ClaimedArticle_Description_Id, "value");
            Assert.AreEqual(Description, getdesUIVal);
            Report.WriteLine("Able to pass a maximum of 500 alpha-numeric, text, special characters to Description field");

            // Description more than Maxlength verification
            string descriptionMoreThanMaxLength = "cvdert 12345 !@#$% :{_ vbnmjhgfd tr56789 zaqwertgb chdsf fhmndsf dsfjesfsd fjeyfs f756b cfu75wegfb dsj4y6wsb x@#$%^&*( fdhtfsd fsyrt fuy7ety7832674832 sduyetdgjwtrw fjhew6537rbd asfy3w4trgfjhrt5rfygbestruewf eu3564gdb cxsry3wtrfuwet yrewtr7uwj@$#$#^&*(^&%&FJDSGJFGES7R FUYEF SERUEWF ESRUEWF SE753F CSDR7WUF SDRU4E875346587236 7EWRFGSJDRGWESF 458734ERFBSMRF RESUIRYHESB MR783RFS DFUW4YRFBSDBTR784EF SJERYWEJF EW895YRHEWIT834YWEFN E57834EWFB DSRUIWYEHDJMDSFUJMV FBEWR7TFUVBDSE78RFUCJFGDBCDFJKCJU6gdgddd2";
            SendKeys(attributeName_id, ClaimedArticle_Description_Id, descriptionMoreThanMaxLength);
            string getdescriptionValue = GetAttribute(attributeName_id, ClaimedArticle_Description_Id, "value");
            Assert.AreNotEqual(descriptionMoreThanMaxLength, getdescriptionValue);
            Report.WriteLine("Not able to pass a maximum of 500 alpha-numeric, text, special characters to Description field");
        }

        [Then(@"I verify Add Another Item hyperlink is active")]
        public void ThenIVerifyAddAnotherItemHyperlinkIsActive()
        {
            VerifyElementPresent(attributeName_id, AddAditionalClaim_btn_Id, "Add Another Item");
            VerifyElementEnabled(attributeName_id, AddAditionalClaim_btn_Id, "Add Another Item");
            Click(attributeName_id, AddAditionalClaim_btn_Id);
            scrollpagedown();
            Report.WriteLine("Add Another Item hyperlink exists ");
        }

        [Then(@"I verify the Do you wish to add freight charges field is editable")]
        public void ThenIVerifyTheDoYouWishToAddFreightChargesFieldIsEditable()
        {
            scrollpagedown();
            VerifyElementEnabled(attributeName_xpath, FreightChargeLabel_Xpath, "Do you wish to add freight charges? *");
            bool freightCharges = IsElementVisible(attributeName_xpath, AmendClaim_OriginalFreightChargesOption_Xpath, "Original Freight Charges");
            if (freightCharges)
            {
                Click(attributeName_xpath, FreightChargeNo_Xpath);
            }
            else
            {
                Click(attributeName_xpath, FreightChargeYes_Xpath);
            }
            Report.WriteLine("'Do you wish to add freight charges' is editable");
        }

        [Then(@"I verify the Original Freight Charges option field is editable, displayed when Do you wish to add freight charges = Yes")]
        public void ThenIVerifyTheOriginalFreightChargesOptionFieldIsEditableDisplayedWhenDoYouWishToAddFreightChargesYes()
        {
            if (freightCharges)
            {
                Click(attributeName_xpath, FreightChargeYes_Xpath);
                VerifyElementPresent(attributeName_xpath, OriginFreightChargeOption_Xpath, "FreightOption");
                Report.WriteLine("Original Freight Charges option field is present");

                VerifyElementEnabled(attributeName_xpath, OriginFreightChargeOption_Xpath, "Original Freight Charges");
                Report.WriteLine("'Original Freight Charges option' field is editable");
            }
            else
            {
                VerifyElementChecked(attributeName_xpath, AmendClaim_FreightCharges_NO_Xpath, "No");
                Report.WriteLine("Freight Charges - Choosen as No");
            }
        }

        [Then(@"I verify the Original Freight Charges Value field is editable, displayed when Do you wish to add freight charges = Yes, currency format \$xxx,xxx\.xxx")]
        public void ThenIVerifyTheOriginalFreightChargesValueFieldIsEditableDisplayedWhenDoYouWishToAddFreightChargesYesCurrencyFormatXxxXxx_Xxx()
        {
            if (freightCharges)
            {
                VerifyElementPresent(attributeName_xpath, OriginFreightChargeVal_Xpath, "Option");
                Report.WriteLine("Able to view Original Freight Charges Value field ");

                VerifyElementEnabled(attributeName_xpath, OriginFreightChargeVal_Xpath, "Original Freight Charges Value");
                Report.WriteLine("'Original Freight Charges Value' field is editable");
                Thread.Sleep(1000);
                SendKeys(attributeName_xpath, OriginFreightChargeVal_Xpath, "223");
                Click(attributeName_xpath, OptionFreight_Xpath);
                string originFreightCharge = GetValue(attributeName_xpath, OriginFreightChargeVal_Xpath, "value");
                Assert.AreEqual("$223.00", originFreightCharge);
                Report.WriteLine("Able to pass value to Original Freight Charges option field and the format is currency");
            }
            else
            {
                VerifyElementChecked(attributeName_xpath, AmendClaim_FreightCharges_NO_Xpath, "No");
                Report.WriteLine("Freight Charges - Choosen as No");
            }
        }

        [Then(@"I verify the Return Freight Charges option field is editable, displayed when Do you wish to add freight charges = Yes")]
        public void ThenIVerifyTheReturnFreightChargesOptionFieldIsEditableDisplayedWhenDoYouWishToAddFreightChargesYes()
        {
            if (freightCharges)
            {
                Click(attributeName_xpath, ReturnFreightCharge_Xpath);
                VerifyElementPresent(attributeName_xpath, ReturnFreightCharge_Xpath, "Return");
                Report.WriteLine("Able to view Return Freight Charges option ");

                VerifyElementEnabled(attributeName_xpath, FreightChargeLabel_Xpath, "Return Freight Charges option");
                Report.WriteLine("Return Freight Charges option field is editable ");
            }
            else
            {
                VerifyElementChecked(attributeName_xpath, AmendClaim_FreightCharges_NO_Xpath, "No");
                Report.WriteLine("Freight Charges - Choosen as No");
            }
        }

        [Then(@"I verify the Return Freight Charges Value field is editable, displayed when Do you wish to add freight charges = Yes, currency format \$xxx,xxx\.xx")]
        public void ThenIVerifyTheReturnFreightChargesValueFieldIsEditableDisplayedWhenDoYouWishToAddFreightChargesYesCurrencyFormatXxxXxx_Xx()
        {
            if (freightCharges)
            {
                VerifyElementEnabled(attributeName_xpath, AmendClaim_ReturnFreightChargesValue_Xpath, "Return Freight Charges");
                Report.WriteLine("Return Freight Charges option field is editable ");
                DefineTimeOut(1000);
                SendKeys(attributeName_xpath, AmendClaim_ReturnFreightChargesValue_Xpath, "223");
                Click(attributeName_xpath, OptionFreight_Xpath);
                string returnFreightVal = GetValue(attributeName_xpath, AmendClaim_ReturnFreightChargesValue_Xpath, "value");
                Assert.AreEqual("$223.00", returnFreightVal);
                Report.WriteLine("Able to pass Value to Return Freight Charges option field ");
            }
            else
            {
                VerifyElementChecked(attributeName_xpath, AmendClaim_FreightCharges_NO_Xpath, "No");
                Report.WriteLine("Freight Charges - Choosen as No");
            }
        }

        [Then(@"I verify the DLSW Ref \# field is editable, displayed when Do you wish to add freight charges = Yes, alpha-numeric, max length 20")]
        public void ThenIVerifyTheDLSWRefFieldIsEditableDisplayedWhenDoYouWishToAddFreightChargesYesAlpha_NumericMaxLength20()
        {
            if (freightCharges)
            {
                VerifyElementEnabled(attributeName_xpath, AmendClaim_ReturnFreightChargesDLSW_Xpath, "ReturnDLS");
                Report.WriteLine("Able to view DLSW Ref # field");
                DefineTimeOut(1000);
                SendKeys(attributeName_xpath, AmendClaim_ReturnFreightChargesDLSW_Xpath, "45564321236789087654");
                Report.WriteLine("Able to pass 20 digits ");

                string ReturnVal = "4556432123678908765476";
                SendKeys(attributeName_xpath, AmendClaim_ReturnFreightChargesDLSW_Xpath, ReturnVal);
                string GetDLSWRefVal = GetValue(attributeName_xpath, AmendClaim_ReturnFreightChargesDLSW_Xpath, "value");
                Assert.AreNotEqual(ReturnVal, GetDLSWRefVal);
                Report.WriteLine("Validated DLSW Ref field by trying to pass more than 20 digits");
            }
            else
            {
                VerifyElementChecked(attributeName_xpath, AmendClaim_FreightCharges_NO_Xpath, "No");
                Report.WriteLine("Freight Charges - Choosen as No");
            }

        }

        [Then(@"I verify the Replacement Freight Charges option field is editable, displayed when Do you wish to add freight charges = Yes")]
        public void ThenIVerifyTheReplacementFreightChargesOptionFieldIsEditableDisplayedWhenDoYouWishToAddFreightChargesYes()
        {
            if (freightCharges)
            {
                Click(attributeName_xpath, ReplacementFreight_Xpath);
                VerifyElementPresent(attributeName_xpath, ReplacementFreight_Xpath, "Replacement Freight Charges");
                Report.WriteLine("Able to view Replacement Freight Charges option ");

                VerifyElementEnabled(attributeName_xpath, ReplacementFreight_Xpath, "Replacement Freight Charges");
                Report.WriteLine("Able to select Replacement Freight Charges option ");
            }
            else
            {
                VerifyElementChecked(attributeName_xpath, AmendClaim_FreightCharges_NO_Xpath, "No");
                Report.WriteLine("Freight Charges - Choosen as No");
            }
        }

        [Then(@"I verify the Replacement Freight Charges Value field is editable, displayed when Do you wish to add freight charges = Yes, currency format \$xxx,xxx\.xx")]
        public void ThenIVerifyTheReplacementFreightChargesValueFieldIsEditableDisplayedWhenDoYouWishToAddFreightChargesYesCurrencyFormatXxxXxx_Xx()
        {
            if (freightCharges)
            {
                VerifyElementPresent(attributeName_xpath, AmendClaim_ReplacementFreightChargesValues_Xpath, "Replacement Freight Charges");
                Report.WriteLine("Able to view Return Freight Charges Value field");

                VerifyElementEnabled(attributeName_xpath, AmendClaim_ReplacementFreightChargesValues_Xpath, "Replacement Freight Charges");
                Report.WriteLine("Return Freight Charges option field is editable ");
                DefineTimeOut(1000);
                SendKeys(attributeName_xpath, AmendClaim_ReplacementFreightChargesValues_Xpath, "223");
                Click(attributeName_xpath, OptionFreight_Xpath);
                string replaceFreightVal = GetValue(attributeName_xpath, AmendClaim_ReplacementFreightChargesValues_Xpath, "value");
                Assert.AreEqual("$223.00", replaceFreightVal);
                Report.WriteLine("Able to pass Value to Return Freight Charges option field ");
            }
            else
            {
                VerifyElementChecked(attributeName_xpath, AmendClaim_FreightCharges_NO_Xpath, "No");
                Report.WriteLine("Freight Charges - Choosen as No");
            }
        }

        [Then(@"I verify the DLSW Ref \# of Replacement Freight Charges Value field is editable, displayed when Do you wish to add freight charges = Yes, alpha-numeric, max length 20")]
        public void ThenIVerifyTheDLSWRefOfReplacementFreightChargesValueFieldIsEditableDisplayedWhenDoYouWishToAddFreightChargesYesAlpha_NumericMaxLength20()
        {
            if (freightCharges)
            {
                VerifyElementPresent(attributeName_xpath, AmendClaim_ReplacementFreightChargesDLSW_Xpath, "ReplaceDLS");
                Report.WriteLine("Able to view DLSW Ref # field");

                SendKeys(attributeName_xpath, AmendClaim_ReplacementFreightChargesDLSW_Xpath, "45564321236789087654");
                Report.WriteLine("Able to pass 20 digits ");

                string ReplaceDLSVal = "4556432123678908765476";
                SendKeys(attributeName_xpath, AmendClaim_ReplacementFreightChargesDLSW_Xpath, ReplaceDLSVal);
                Click(attributeName_xpath, OptionFreight_Xpath);
                string GetDLSWReplaceVal = GetValue(attributeName_xpath, AmendClaim_ReplacementFreightChargesDLSW_Xpath, "value");
                Assert.AreNotEqual(ReplaceDLSVal, GetDLSWReplaceVal);
                Report.WriteLine("Validated DLSW Ref field by trying to pass more than 20 digits");
            }
            else
            {
                VerifyElementChecked(attributeName_xpath, AmendClaim_FreightCharges_NO_Xpath, "No");
                Report.WriteLine("Freight Charges - Choosen as No");
            }
        }

        [Then(@"I verify the Articles Insured field is editable")]
        public void ThenIVerifyTheArticlesInsuredFieldIsEditable()
        {
            scrollPageup(); //ScrollElementIntoView and MoveToElement methods didn't work
            scrollPageup();
            scrollPageup();

            Report.WriteLine("Verifying Articles Insured field is editable");
            DefineTimeOut(2000);

            if (ClaimDetails.IsArticlesIns == true)
            {
                Click(attributeName_xpath, ArticlesInsuredNo_Xpath);
            }
            else
            {
                Click(attributeName_xpath, ArticlesInsuredYes_Xpath);
            }
        }

        [Then(@"I verify the Subtotal All Claim Value field is uneditable")]
        public void ThenIVerifyTheSubtotalAllClaimValueFieldIsUneditable()
        {

            VerifyElementPresent(attributeName_id, Subtotal_Id, "Subtotal");
            VerifyElementNotEnabled(attributeName_id, Subtotal_Id, "Subtotal");
            Report.WriteLine("'Subtotal All Claim Value' field is un editable");
        }

        [Given(@"I will see Display documents originally submitted with delete icon in documents section")]
        [Then(@"I will see Display documents originally submitted with delete icon in documents section")]
        public void IWillSeeDisplayDocumentsOriginallySubmittedWithDeleteIconInDocumentsSection()
        {
            string claimNumber= Gettext(attributeName_xpath, Submit_A_Claim_Page_Header_Text_Xpath);
            string[] _ClaimNumber = claimNumber.Split('#');
            _claimnumber = _ClaimNumber[1].Replace(")","").TrimStart();
            GlobalVariables.webDriver.WaitForPageLoad();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();

            Thread.Sleep(2000);
            Report.WriteLine("I will see Display documents originally submitted with delete icon in documents section");

            //taking documents list from DB for the claim number
            List<FileInfo> FilenameListfrom_db = DBHelper.GetMetaDateFile("CLAIMNUMBER", _claimnumber);
            for (int i = 0; i < FilenameListfrom_db.Count; i++)
            {
                string filename = FilenameListfrom_db[i].FileName;
                string extension = FilenameListfrom_db[i].FileExtension;
                string fileExtention = "." + extension.TrimEnd();
                string filewithExtension = filename + fileExtention;
                associated_documentsfromDB.Add(filewithExtension);
            }

            //taking the list of documents from UI
            IList<IWebElement> documentsAddedToClaimFromUI = GlobalVariables.webDriver.FindElements(By.XPath(AdditionalUploadedFile_Xpath));
            for (int i = 0; i < documentsAddedToClaimFromUI.Count; i++)
            {
                Report.WriteLine("Document associated to Claim : " + documentsAddedToClaimFromUI[i].Text);
                associated_documentsfromUI.Add(documentsAddedToClaimFromUI[i].Text);
                //verifying the delete icon for each document
                VerifyElementPresent(attributeName_xpath, "(.//a[contains(@class,'deleteSavedDocument')])[" + (i + 1) + "]", "Delete icon");
            }

            for(int j=0;j< associated_documentsfromUI.Count; j++)
            {
                CollectionAssert.Contains(associated_documentsfromUI, associated_documentsfromDB[j]);
            }           
            
        }

        [Then(@"I will see Add Additional Document button in documents section")]
        public void ThenIWillSeeAddAdditionalDocumentButtonInDocumentsSection()
        {
            Report.WriteLine("I will see Add Additional Document button in documents section");
            VerifyElementPresent(attributeName_id, AddAdditionalDocument_Button_Id, "Add Additional Document");
        }

        [Then(@"I verify Remarks field - uneditable in Sign Off Section")]
        public void ThenIVerifyRemarksField_UneditableInSignOffSection()
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();

            Report.WriteLine("Verify Remarks field (un editable) in Sign off section");
            string remarksVal_UI = Gettext(attributeName_id, Remarks_textarea_Id);
            VerifyElementNotEnabled(attributeName_id, RemarksField_Id, remarksVal_UI);
        }

        [Then(@"I will see Resubmit Claim Button in Sign Off Section")]
        public void ThenIWillSeeResubmitClaimButtonInSignOffSection()
        {
            Report.WriteLine("I will see Resubmit Claim Button in Sign Off Section");
            string actualText = Gettext(attributeName_id, Resubmit_button_Id);
            string expectedText = "Resubmit Claim";
            Assert.AreEqual(expectedText, actualText);
        }

        IList<IWebElement> allDeleteButtons;
        IList<IWebElement> allDocumentValidationMessages;

        [Given(@"I did not complete all required fields in the Documents section")]
        public void WhenIDidNotCompleteAllRequiredFieldsInTheDocumentSection()
        {
            // Delete all the documents added in the Amended Claim
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();            
            Report.WriteLine("Deleting all the documents added to the Amended claim");
            allDeleteButtons = GlobalVariables.webDriver.FindElements(By.XPath(AmendClaim_DeleteSavedDocumentAllButtons_Xpath));
            for (int i = allDeleteButtons.Count; i >= 1; i--)
            {                
                Click(attributeName_xpath, "(.//a[contains(@class, 'deleteSavedDocument')])[" + i + "]"); //Clicking on Delete icon
                Thread.Sleep(3000);
                Click(attributeName_id, DocumentDeletePopup_DeleteButton_Id); //Clicking on Delete button in the Delete File pop up  
                Thread.Sleep(2000);                
            }
        }

        [When(@"I click on the Resubmit Claim button,")]
        public void WhenIClickOnTheResubmitClaimButton()
        {
            Report.WriteLine("Clicking on Resubmit Claim button");
            Thread.Sleep(2000);
            scrollpagedown();
            scrollpagedown();
            Click(attributeName_id, Resubmit_button_Id);
        }

        [Then(@"the required field\(s\) missing information will be displayed in red,")]
        public void ThenTheRequiredFieldSMissingInformationWillBeDisplayedInRed()
        {
            allDocumentValidationMessages = GlobalVariables.webDriver.FindElements(By.XPath(AmendClaim_DocumentUploadValidationMessagesAll_Xpath));
            for (int i = 1; i <= allDocumentValidationMessages.Count; i++)
            {
                VerifyElementPresent(attributeName_xpath, "(.//span[contains(text(),'Please add document to claim form')])[" + i + "]", "Document not uploaded validation message");
            }
            if (allDeleteButtons.Count == allDocumentValidationMessages.Count)
            {
                Report.WriteLine("Please add document to claim form message displays for every documents section");
            }
            else
            {
                Report.WriteFailure("Please add document to claim form message does NOT display for every documents section");
            }
        }

        [Then(@"the Submit a Claim page will refocus to the first required field that is missing information")]
        public void ThenTheSubmitAClaimPageWillRefocusToTheFirstRequiredFieldThatIsMissingInformation()
        {
            VerifyElementPresent(attributeName_xpath, AmendClaim_CompleteVendorInvoiceText_Xpath, "Complete Vendor Invoice field");
            Report.WriteLine("Complete Vendor Invoice field of the Documents section is in focus");
        }
    }
}
