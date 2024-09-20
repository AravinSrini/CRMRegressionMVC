using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using Microsoft.IdentityModel.Protocols;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Insurance_Claims
{
    [Binding]
    public class _91148_InsuranceClaims_SubmitAClaimPage_CalculateClaimCostsSteps : CRM.UITest.Objects.InsuranceClaim
    {
        CommonMethodsCrm crm = new CommonMethodsCrm();
        decimal unitVal = 4;
        decimal quantityVal = 5;
        decimal additionalItemUnitVal = 7;
        decimal additionalItemquantityVal = 32;
        decimal subTotVal = 0;
        decimal originFreightCharge = 65;
        decimal returnFreightCharge = 54;
        decimal replacementFreightCharge = 65;
        decimal subTotalAllClaimValue = 0;
        decimal originChargeVal = 0;
        decimal returnChargeVal = 0;

        string Stationname = "ZZZ - Web Services Test";
        string Customername = "46948TestCustomer";

        string DLSBill = "BillLading123";
        string CarrierName = "Carrier123";
        string CarrierPRO = "123QA";
        string ShipperName = "Testing 1@3";
        string ShipperAddress = "AddressTest!123";
        string ShipperAdd2 = "Address223";
        string ShipperZip = "90001";
        string ConsigneName = "Consigneename";
        string ConsigneAddress = "ConsigneAddress";
        string ConsigneAddress2 = "ConsigneAddress2";
        string ConsigneZip = "33126";
        string ClaimCompanyName = "CompanyName";
        string ClaimAddress = "Address )**(434";
        string ClaimAddress2 = "Address2";
        string ClaimContactName = "ContactName";
        string ClaimPhone = "84324249324";
        string ClaimEmail = "dyafdyu@gmail.com";
        string ClaimWebsite = "www.shua.com";
        string Weight = "23.00";
        string ClaimDescription = "Description Test 123";
        string ReturnDLS = "45564321236789087654";
        string ReplaceDLS = "532756";
        string Remark = "jdhasu5535437hgd$#%^";
        string ClaimZip = "32435";
        int ClaimNumber = 0;
        string UIDLSDate = null;
        string Fullpath = "../../Scripts/TestData/Testfiles_ClaimDocument/QuoteListCheck.txt";

        [Given(@"I am a user that can submit a claim")]
        public void GivenIAmAUserThatCanSubmitAClaim()
        {
            string username = ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();
            string password = ConfigurationManager.AppSettings["ExternalUserPassword"].ToString();
            crm.LoginToCRMApplication(username, password);
        }

        [Given(@"I am a Claim Specialist user who can submit a claim")]
        public void GivenIAmAClaimSpecialistUserWhoCanSubmitAClaim()
        {
            string username = ConfigurationManager.AppSettings["username-CurrentsprintClaimspecialist"].ToString();
            string password = ConfigurationManager.AppSettings["password-CurrentsprintClaimspecialist"].ToString();
            crm.LoginToCRMApplication(username, password);
        }

        [Given(@"I am a external user who can submit a claim")]
        public void GivenIAmAExternalUserWhoCanSubmitAClaim()
        {
            string username = ConfigurationManager.AppSettings["username-CurrentSprintshpentry"].ToString();
            string password = ConfigurationManager.AppSettings["password-CurrentSprintshpentry"].ToString();
            crm.LoginToCRMApplication(username, password);
        }

        [Given(@"I am an internal user who can submit a claim")]
        public void GivenIAmAnInternalUserWhoCanSubmitAClaim()
        {
            string username = ConfigurationManager.AppSettings["username-CurrentSprintOperations"].ToString();
            string password = ConfigurationManager.AppSettings["password-CurrentSprintOperations"].ToString();
            crm.LoginToCRMApplication(username, password);
        }

        [Given(@"I am on the Submit a Claim page for an external user")]
        public void GivenIAmOnTheSubmitAClaimPageForAnExternalUser()
        {
            Click(attributeName_xpath, ClaimIconExternalUser_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Navigated to Claim list page");
            Click(attributeName_xpath, SubmitClaimButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Navigated to Submit a Claim page");
        }

        [Given(@"I clicked on the Add Another Item button in the Claim Details section")]
        public void GivenIClickedOnTheAddAnotherItemButtonInTheClaimDetailsSection()
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            Click(attributeName_xpath, AddAnotherItem_Xpath);
            Report.WriteLine("Clicked on Add Another Item button in the Claim Details section");
        }
        
        [Given(@"I selected Yes for Do you wish to add freight charges\? option in the Claim Details section")]
        public void GivenISelectedYesForDoYouWishToAddFreightChargesOptionInTheClaimDetailsSection()
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            SendKeys(attributeName_id, UnitValue_Id, unitVal.ToString());
            SendKeys(attributeName_id, Quantity_Id, quantityVal.ToString());
            Click(attributeName_xpath, FreightChargeYes_Xpath);
            Report.WriteLine("Selected Yes for Do you wish to add freight charges? option in the Claim Details section");
        }
        
        [Given(@"I selected the Return Freight Charges option")]
        public void GivenISelectedTheReturnFreightChargesOption()
        {
            scrollpagedown();
            Click(attributeName_xpath, ReturnFreightCharge_Xpath);
            Report.WriteLine("Selected Return Freight Charges option");
        }
        
        [Given(@"I selected the Replacement Freight Charges option")]
        public void GivenISelectedTheReplacementFreightChargesOption()
        {
            scrollpagedown();
            Click(attributeName_xpath, ReplacementFreight_Xpath);
            Report.WriteLine("Selected Replacement Freight Charges option");
        }
        
        [Given(@"I completed all required information for an internal user")]
        public void GivenICompletedAllRequiredInformationForAnInternalUser()
        {
            Click(attributeName_xpath, SubmitaClaim_Stationdropdown_xpath);
            SelectDropdownValueFromList(attributeName_xpath, SubmitaClaim_StatiodropdownValues_xpath, Stationname);
            Click(attributeName_xpath, SubmitaClaim_Customerdropdown_xpath);
            Thread.Sleep(5000);
            SelectDropdownValueFromList(attributeName_xpath, SubmitaClaim_CustomerdropdownValues_xpath, Customername);
            submitClaim();
        }

        [Given(@"I completed all required information for an external user")]
        public void GivenICompletedAllRequiredInformationForAnExternalUser()
        {
            submitClaim();
        }

        [Given(@"I completed all required information for ClaimSpecialist User")]
        public void GivenICompletedAllRequiredInformationForClaimSpecialistUser()
        {

            Click(attributeName_xpath, SubmitaClaim_Stationdropdown_xpath);
            SelectDropdownValueFromList(attributeName_xpath, SubmitaClaim_StatiodropdownValues_xpath, Stationname);
            Click(attributeName_xpath, SubmitaClaim_Customerdropdown_xpath);
            Thread.Sleep(3000);
            SelectDropdownValueFromList(attributeName_xpath, SubmitaClaim_CustomerdropdownValues_xpath, Customername);
            submitClaim();
        }

        [When(@"I click on Submit Claim Button")]
        public void WhenIClickOnSubmitClaimButton()
        {
            scrollpagedown();
            Click(attributeName_id, SubmitClaimButton_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Clicked on Submit claim button");
        }

        [When(@"I enter values on Unit Value and Quantity fields of Claim Details section")]
        public void WhenIEnterValuesOnUnitValueAndQuantityFieldsOfClaimDetailsSection()
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            getInitialSubTotalVal();
            SendKeys(attributeName_id, UnitValue_Id, unitVal.ToString());
            SendKeys(attributeName_id, Quantity_Id, quantityVal.ToString());
            Report.WriteLine("Unit and Quantity field value is entered");

        }


        [Given(@"I enter values on Unit Value and Quantity fields of the additional item section of Claim Details section")]
        public void GivenIEnterValuesOnUnitValueAndQuantityFieldsOfTheAdditionalItemSectionOfClaimDetailsSection()
        {
            SendKeys(attributeName_id, UnitValue_Id, unitVal.ToString());
            SendKeys(attributeName_id, Quantity_Id, quantityVal.ToString());
            Report.WriteLine("Unit and Quantity field value is entered");
            SendKeys(attributeName_xpath, FirstAdditionalItemUnitVal_Xpath, additionalItemUnitVal.ToString());
            SendKeys(attributeName_xpath, FirstAdditionalItemQuantityVal_Xpath, additionalItemquantityVal.ToString());
            Report.WriteLine("Unit and Quantity field value is entered for the additional item section of Claim Details section");
            scrollpagedown();
            getInitialSubTotalVal();
        }

        [When(@"I enter values on Original Freight Charges, Return Freight Charges, Replacement Freight Charges fields")]
        public void WhenIEnterValuesOnOriginalFreightChargesReturnFreightChargesReplacementFreightChargesFields()
        {
            Click(attributeName_xpath, FreightChargeYes_Xpath);
            scrollpagedown();
            SendKeys(attributeName_xpath, OriginFreightChargeVal_Xpath, originFreightCharge.ToString());
            Report.WriteLine("Entered value in the Value field of the Original Freight Charges option");
            Click(attributeName_xpath, ReturnFreightCharge_Xpath);
            SendKeys(attributeName_classname, ReturnFreightVal_Class, returnFreightCharge.ToString());
            Report.WriteLine("Entered value in the Value field of the Return Freight Charges option");
            Click(attributeName_xpath, ReplacementFreight_Xpath);
            SendKeys(attributeName_classname, ReplaceFreightVal_Class, replacementFreightCharge.ToString());
            Report.WriteLine("Entered value in the Value field of the Replacement Freight Charges option");

        }

        [When(@"I enter values on Unit Value and Quantity fields of the additional item section of Claim Details section")]
        public void WhenIEnterValuesOnUnitValueAndQuantityFieldsOfTheAdditionalItemSectionOfClaimDetailsSection()
        {
            scrollpagedown();
            getInitialSubTotalVal();
            SendKeys(attributeName_id, UnitValue_Id, unitVal.ToString());
            SendKeys(attributeName_id, Quantity_Id, quantityVal.ToString());
            Report.WriteLine("Unit and Quantity field value is entered");
            SendKeys(attributeName_xpath, FirstAdditionalItemUnitVal_Xpath, additionalItemUnitVal.ToString());
            SendKeys(attributeName_xpath, FirstAdditionalItemQuantityVal_Xpath, additionalItemquantityVal.ToString());
            Report.WriteLine("Unit and Quantity field value is entered for the additional item section of Claim Details section");
        }

        [When(@"I enter a value in the Value field of the Original Freight Charges option")]
        public void WhenIEnterAValueInTheValueFieldOfTheOriginalFreightChargesOption()
        {
            scrollpagedown();
            getInitialSubTotalVal();
            SendKeys(attributeName_xpath, OriginFreightChargeVal_Xpath, originFreightCharge.ToString());
            Report.WriteLine("Entered value in the Value field of the Original Freight Charges option");
        }
        
        [When(@"I enter a value in the Value field of the Return Freight Charges option")]
        public void WhenIEnterAValueInTheValueFieldOfTheReturnFreightChargesOption()
        {
            getInitialSubTotalVal();
            SendKeys(attributeName_classname, ReturnFreightVal_Class, returnFreightCharge.ToString());
            Report.WriteLine("Entered value in the Value field of the Return Freight Charges option");
        }
        
        [When(@"I enter a value in the Value field of the Replacement Freight Charges option")]
        public void WhenIEnterAValueInTheValueFieldOfTheReplacementFreightChargesOption()
        {
            getInitialSubTotalVal();
            SendKeys(attributeName_classname, ReplaceFreightVal_Class, replacementFreightCharge.ToString());
            Report.WriteLine("Entered value in the Value field of the Replacement Freight Charges option");
        }
        
        [Then(@"The Subtotal All Claim Value field will auto-populate using the following calculation : \(Unit Value\*Quantity\)\+\(Current Value of Subtotal All Claim Value field\)")]
        public void ThenTheSubtotalAllClaimValueFieldWillAuto_PopulateUsingTheFollowingCalculationUnitValueQuantityCurrentValueOfSubtotalAllClaimValueField()
        {
            string subTotalValCal = GetValue(attributeName_id, SubtotalAllClaimValue_Textbox_Id, "value");
            decimal subTotalAllClaimValue = (unitVal * quantityVal) + (subTotVal);
            Assert.AreEqual(subTotalValCal, "$" + subTotalAllClaimValue);
            Report.WriteLine("Subtotal All Claim Value field is auto-populated using the formula : (Unit Value*Quantity)+(Current Value of <Subtotal All Claim Value> field)");
        }
        
        [Then(@"The Subtotal All Claim Value field will auto-populate using the following calculation : \(Item(.*) Unit Value\*Quantity\)\+\(Item(.*) Unit Value\*Quantity\)\.\.\.\+\(Current Value of Subtotal All Claim Value field\)")]
        public void ThenTheSubtotalAllClaimValueFieldWillAuto_PopulateUsingTheFollowingCalculationItemUnitValueQuantityItemUnitValueQuantity_CurrentValueOfSubtotalAllClaimValueField(int p0, int p1)
        {
            string subTotalValCal = GetValue(attributeName_id, SubtotalAllClaimValue_Textbox_Id, "value");
            decimal subTotalAllClaimValue = (unitVal * quantityVal) + (additionalItemUnitVal * additionalItemquantityVal) + (subTotVal);
            Assert.AreEqual(subTotalValCal, "$" + subTotalAllClaimValue);
            Report.WriteLine("Subtotal All Claim Value field is auto-populated using the formula :(Item1 Unit Value*Quantity)+(Item2 Unit Value*Quantity).....+(Current Value of <Subtotal All Claim Value> field)");

        }

        [Then(@"The Subtotal All Claim Value field will auto-populate using the following calculation : \(Value of Original Freight Charges\)\+\(Current Value of Subtotal All Claim Value field\)")]
        public void ThenTheSubtotalAllClaimValueFieldWillAuto_PopulateUsingTheFollowingCalculationValueOfOriginalFreightChargesCurrentValueOfSubtotalAllClaimValueField()
        {
            string subTotalValCal = GetValue(attributeName_id, SubtotalAllClaimValue_Textbox_Id, "value");
            decimal subTotalAllClaimValue = (originFreightCharge) + (subTotVal);
            Assert.AreEqual(subTotalValCal, "$" + subTotalAllClaimValue);
            Report.WriteLine("Subtotal All Claim Value field is auto-populated using the formula :(Value of Original Freight Charges)+(Current Value of <Subtotal All Claim Value> field)");

        }

        [Then(@"The Subtotal All Claim Value field will auto-populate using the following calculation : \(Value of Original Freight Charges\)\+\(Value of Return Freight Charges\)\+\(Current Value of Subtotal All Claim Value field\)")]
        public void ThenTheSubtotalAllClaimValueFieldWillAuto_PopulateUsingTheFollowingCalculationValueOfOriginalFreightChargesValueOfReturnFreightChargesCurrentValueOfSubtotalAllClaimValueField()
        {
            string subTotalValCal = GetValue(attributeName_id, SubtotalAllClaimValue_Textbox_Id, "value");
            decimal subTotalAllClaimValue = (originChargeVal) + (returnFreightCharge) + (subTotVal);
            Assert.AreEqual(subTotalValCal, "$" + subTotalAllClaimValue);
            Report.WriteLine("Subtotal All Claim Value field is auto-populated using the formula :(Value of Original Freight Charges)+(Value of Return Freight Charges)+(Current Value of <Subtotal All Claim Value> field)");
        }
        
        [Then(@"The Subtotal All Claim Value field will auto-populate using the following calculation : \(Value of Original Freight Charges\)\+\(Value of Return Freight Charges\)\+\(Value of Replacement Freight Charges\)\+\(Current Value of (.*) field\)")]
        public void ThenTheSubtotalAllClaimValueFieldWillAuto_PopulateUsingTheFollowingCalculationValueOfOriginalFreightChargesValueOfReturnFreightChargesValueOfReplacementFreightChargesCurrentValueOfField(string p0)
        {
            string subTotalValCal = GetValue(attributeName_id, SubtotalAllClaimValue_Textbox_Id, "value");
            decimal subTotalAllClaimValue = (originFreightCharge) + (returnFreightCharge) + (replacementFreightCharge) + (subTotVal);
            Assert.AreEqual(subTotalValCal, "$" + subTotalAllClaimValue);
            Report.WriteLine("Subtotal All Claim Value field is auto-populated using the formula : (Value of Original Freight Charges)+(Value of Return Freight Charges)+(Value of Replacement Freight Charges)+(Current Value of <Subtotal All Claim Value> field)");
        }

        [Then(@"Subtotal All Claim Value field will auto-populate using the following calculation : \(Value of Original Freight Charges\)\+\(Value of Return Freight Charges\)\+\(Value of Replacement Freight Charges\)\+\(Current Value of (.*) field\)")]
        public void ThenSubtotalAllClaimValueFieldWillAuto_PopulateUsingTheFollowingCalculationValueOfOriginalFreightChargesValueOfReturnFreightChargesValueOfReplacementFreightChargesCurrentValueOfField(string p0)
        {
            string subTotalValCal = GetValue(attributeName_id, SubtotalAllClaimValue_Textbox_Id, "value");
            decimal subTotalAllClaimValue = (originChargeVal) + (returnChargeVal) + (replacementFreightCharge) + (subTotVal);
            Assert.AreEqual(subTotalValCal, "$" + subTotalAllClaimValue);
            Report.WriteLine("Subtotal All Claim Value field is auto-populated using the formula : (Value of Original Freight Charges)+(Value of Return Freight Charges)+(Value of Replacement Freight Charges)+(Current Value of <Subtotal All Claim Value> field)");

        }

        [Then(@"The calculated value of the Subtotal All Claim Value will be saved")]
        public void ThenTheCalculatedValueOfTheSubtotalAllClaimValueWillBeSaved()
        {
            //List<InsuranceClaimViewModel> ClaimDetails = DBHelper.GetInsuranceClaimVal(ClaimNumber);
            decimal freightChargeSubtotal = DBHelper.GetSubTotalValFreight(ClaimNumber);
            Assert.AreEqual(freightChargeSubtotal, subTotalAllClaimValue);
            Report.WriteLine("Calculated value of Subtotal All Claim value is saved in DB");
        }
        [Then(@"Calculated value of the Subtotal All Claim Value will be saved to the Total Claimed Freight field of the Claim Details page")]
        public void ThenCalculatedValueOfTheSubtotalAllClaimValueWillBeSavedToTheTotalClaimedFreightFieldOfTheClaimDetailsPage()
        {
            SendKeys(attributeName_xpath, ClaimListPageSearch_Xpath, ClaimNumber.ToString());
            string claimNumberGridVal = Gettext(attributeName_xpath, ClaimListFirstClaimNumberClaimUser_Xpath);
            if (claimNumberGridVal.Contains(ClaimNumber.ToString()))
            {
                Click(attributeName_linktext, claimNumberGridVal);
                GlobalVariables.webDriver.WaitForPageLoad();
                scrollElementIntoView(attributeName_xpath, ClaimDetails_TotalClaimedFreight_Xpath);
                string getTotalClaimedFreightVal = Gettext(attributeName_xpath, ClaimDetails_TotalClaimedFreightVal_Xpath);
                Assert.AreEqual(getTotalClaimedFreightVal, "$" + subTotalAllClaimValue);
                Report.WriteLine("The calculated value of the Subtotal All Claim Value is saved to the Total Claimed Freight field of the Claim Details page");

            }
        }

        [Then(@"The calculated value of the Subtotal All Claim Value will be saved to the Total Claimed Freight field of the Claim Details page")]
        public void ThenTheCalculatedValueOfTheSubtotalAllClaimValueWillBeSavedToTheTotalClaimedFreightFieldOfTheClaimDetailsPage()
        {
            SendKeys(attributeName_xpath, ClaimListPageSearch_Xpath, ClaimNumber.ToString());
            string claimNumberGridVal = Gettext(attributeName_xpath, ClaimListFirstClaimNumberInternal_Xpath);
            if(claimNumberGridVal.Contains(ClaimNumber.ToString()))
            {
                Click(attributeName_linktext, claimNumberGridVal);
                GlobalVariables.webDriver.WaitForPageLoad();
                scrollElementIntoView(attributeName_xpath, ClaimDetails_TotalClaimedFreight_Xpath);
                string getTotalClaimedFreightVal = Gettext(attributeName_xpath, ClaimDetails_TotalClaimedFreightVal_Xpath);
                Assert.AreEqual(getTotalClaimedFreightVal, "$" + subTotalAllClaimValue);
                Report.WriteLine("The calculated value of the Subtotal All Claim Value is saved to the Total Claimed Freight field of the Claim Details page");

            }
        }

        [Then(@"The calculated value of the Subtotal All Claim Value will be displayed to the Total Claimed Freight field of the Claim Details PDF")]
        public void ThenTheCalculatedValueOfTheSubtotalAllClaimValueWillBeDisplayedToTheTotalClaimedFreightFieldOfTheClaimDetailsPDF()
        {
            SendKeys(attributeName_xpath, ClaimListPageSearch_Xpath, ClaimNumber.ToString());
            string claimNumberGridVal = Gettext(attributeName_xpath, ClaimListFirstClaimNumberExternal_Xpath);
            if (claimNumberGridVal.Contains(ClaimNumber.ToString()))
            {
                Click(attributeName_linktext, claimNumberGridVal);
                Thread.Sleep(2000);
                string expectedURL = "http://dlsww-test.rrd.com/InsuranceClaim/ViewClaimDetailsDocument?insuranceClaimNumber=" + ClaimNumber;
                WindowHandling(expectedURL);
                Thread.Sleep(2000);
                string ExpectedURL = GetURL();
                Assert.AreEqual(ExpectedURL, expectedURL);
            }
        }

        public void submitClaim()
        {
            SendKeys(attributeName_id, DLSWBillOfLading_Textbox_Id, DLSBill);
            SendKeys(attributeName_id, CarrierName_Textbox_Id, CarrierName);
            Click(attributeName_id, DLSW_BOLDate_Field_Id);
            AnyNextDatePickerFromDoubleGridCalander(attributeName_xpath, DLSDate_Xpath, -1, DLSDateMonth_Xpath);
            UIDLSDate = Gettext(attributeName_id, DLSW_BOLDate_Field_Id);
            SendKeys(attributeName_id, CarrierPro_Textbox_Id, CarrierPRO);
            Click(attributeName_id, CarrierProDate_Field_Id);
            AnyNextDatePickerFromDoubleGridCalander(attributeName_xpath, CarrierProDate_Field_Values_Xpath, -1, CarrierProDate_Field_LeftArrow_Xpath);
            Report.WriteLine("Carrier information is passed");
            scrollpagedown();
            SendKeys(attributeName_id, Shipper_Name_Textbox_Id, ShipperName);
            SendKeys(attributeName_id, Shipper_Address_Textbox_Id, ShipperAddress);
            SendKeys(attributeName_id, Shipper_Address2_Textbox_Id, ShipperAdd2);
            SendKeys(attributeName_id, Shipper_Zip_Postal_Textbox_Id, ShipperZip);
            Report.WriteLine("Shipper information is passed");
            SendKeys(attributeName_id, Consignee_Name_Textbox_Id, ConsigneName);
            SendKeys(attributeName_id, Consignee_Address_Textbox_Id, ConsigneAddress);
            SendKeys(attributeName_id, Consignee_Address2_Textbox_Id, ConsigneAddress2);
            SendKeys(attributeName_id, Consignee_Zip_Postal_Textbox_Id, ConsigneZip);
            Report.WriteLine("Consignee information is passed");
            scrollpagedown();
            SendKeys(attributeName_id, ClaimPayableTo_CompanyName_Id, ClaimCompanyName);
            SendKeys(attributeName_id, ClaimPayableTo_Address_Id, ClaimAddress);
            SendKeys(attributeName_id, ClaimPayableTo_Address2_Id, ClaimAddress2);
            scrollpagedown();
            SendKeys(attributeName_id, ClaimPayableTo_ZipCode_Id, ClaimZip);
            SendKeys(attributeName_id, ClaimPayableTo_ContactName_Id, ClaimContactName);
            SendKeys(attributeName_id, ClaimPayableTo_ContactPhone_Id, ClaimPhone);
            SendKeys(attributeName_id, ClaimPayableTo_ContactEmail_Id, ClaimEmail);
            SendKeys(attributeName_id, ClaimPayableTo_CompanyWebsite_Id, ClaimWebsite);
            Report.WriteLine("Claim payable to information is passed");
            scrollpagedown();
            Click(attributeName_xpath, ShortageOption_Xpath);
            Click(attributeName_xpath, ArticlesTypeUsed_Xpath);
            SendKeys(attributeName_id, UnitValue_Id, unitVal.ToString());
            SendKeys(attributeName_id, Quantity_Id, quantityVal.ToString());
            SendKeys(attributeName_id, Weight_LBS_Id, Weight);
            SendKeys(attributeName_id, ClaimedArticle_Description_Id, ClaimDescription);
            scrollpagedown();
            getInitialSubTotalVal();
            Click(attributeName_xpath, FreightChargeYes_Xpath);
            scrollpagedown();
            SendKeys(attributeName_classname, OriginFreightChargeOptionField_Class, originFreightCharge.ToString());
            Click(attributeName_xpath, ReturnFreightCharge_Xpath);
            SendKeys(attributeName_classname, ReturnFreightVal_Class, returnFreightCharge.ToString());
            SendKeys(attributeName_id, ReturnDLS_Id, ReturnDLS);
            Click(attributeName_xpath, ReplacementFreight_Xpath);
            SendKeys(attributeName_classname, ReplaceFreightVal_Class, replacementFreightCharge.ToString());
            SendKeys(attributeName_id, ReplaceDLS_Id, ReplaceDLS);
            string subTotalValCal = GetValue(attributeName_id, SubtotalAllClaimValue_Textbox_Id, "value");
            subTotalValCal = subTotalValCal.Substring(1);
            decimal subTotValCal = decimal.Parse(subTotalValCal);
            subTotalAllClaimValue = (originFreightCharge) + (returnFreightCharge) + (replacementFreightCharge) + (subTotVal);
            Assert.AreEqual(subTotValCal, subTotalAllClaimValue);
            Report.WriteLine("Claim details are been passed");
            scrollpagedown();
            scrollpagedown();
            Thread.Sleep(4000);
            string oldPath = Path.GetFullPath("../../Scripts/TestData/Testfiles_ClaimDocument/searcherCheck.txt");
            Thread.Sleep(4000);
            string newPath = Path.GetFullPath("../../Scripts/TestData/Temp/" + Guid.NewGuid().ToString() + "searcherCheck1.txt");
            Thread.Sleep(4000);
            File.Copy(oldPath, newPath, true);
            Thread.Sleep(4000);
            FileUpload(attributeName_xpath, DocumentUploadButton_Xpath, newPath);
            Thread.Sleep(4000);
            File.Delete(newPath);
            Report.WriteLine("Document is uploaded");
            SendKeys(attributeName_id, RemarksField_Id, Remark);
            ClaimNumber = DBHelper.GetClaimNumber();
            ClaimNumber++;
        }
        public void getInitialSubTotalVal()
        {
            string subTotalVal = GetValue(attributeName_id, SubtotalAllClaimValue_Textbox_Id, "value");
            subTotalVal = subTotalVal.Substring(1);
            subTotVal = decimal.Parse(subTotalVal);
        }
    }
}
