using CRM.UITest.CommonMethods;
using CRM.UITest.CsaServiceReference;
using CRM.UITest.Entities;
using CRM.UITest.Helper.ViewModel.Shipment;
using CRM.UITest.Objects;
using CRM.UITest.Scripts.Insurance_Claims.Claim_Details;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Insurance_Claims
{
    [Binding]
    public class _44590_InsuranceClaims_SubmitAClaimPageAutoPopulateDely_Date_Stpes : InsuranceClaim
    {
        InsuranceClaims_ToVerifyAuto_PopulateFieldsSteps inuredClaimPopulateDely_Date;

       string bOLNumber = null;
        int claimNumber=0;
        List<ShipmentListViewModel> Sdata;
        List<InsuranceClaimViewModel> claimModel;
        InsuranceClaims_ClaimDetails_ShipmentModeDisplaySteps saveInfo;

        string actualPickup;
        string actualDelivery;
        string primaryReference;
        string carrierName;
        string pRONumber;
        string originName;
        string originAddress;
        string originAddress2;
        string originZip;
        string originCountry;
        string originCity;
        string originState;
        string destinationName;
        string destinationAddress;
        string destinationAddress2;
        string destinationZip;
        string destinationCountry;
        string destinationCity;
        string destinationState;
        string internalID;


        [When(@"I click on the Submit Claim Form button on submit claim page")]
        public void WhenIClickOnTheSubmitClaimFormButtonOnSubmitClaimPage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            ClaimNonPopulateFileds();
            scrollpagedown();
            Click(attributeName_id, SubmitClaimButton_Id);
            claimNumber = DBHelper.GetClaimNumber();
            Report.WriteLine("Clicked on Submit claim button");
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, ClaimsList_InstructionalVerbiage_xpath, "Cliam list");
        }

        [Given(@"And I Clicked the Populate Form Button")]
        public void GivenAndIClickedThePopulateFormButton()
        {
            Click(attributeName_id, PopulateForm_button_Id);
        }


        [Then(@"CRM will retrieve and store the Actual Delivery Date from valid CSA Reference number (.*)")]
        public void ThenCRMWillRetrieveAndStoreTheActualDeliveryDateFromValidCSAReferenceNumber(string BOLNumber)
        {
            Report.WriteLine("Verifying CRM will retrieve and store the Actual Delivery Date from valid CSA Reference number");

            bOLNumber = Regex.Replace(BOLNumber, @"(\s+|&|'|\(|\)|<|>|#)", "");
            inuredClaimPopulateDely_Date = new InsuranceClaims_ToVerifyAuto_PopulateFieldsSteps();

            ShipmentInquiryOutputV3 result = null;

            using (ShipmentsSoapClient csaClient = new ShipmentsSoapClient())
            {

                result = csaClient.ShipmentInquiryV3("", bOLNumber);

                //Extracting Data and storing in variable
                actualPickup = result.ShipInqOutput[0].ShipmentDate;
                primaryReference = result.ShipInqOutput[0].Housebill;
                int costCount = result.ShipInqOutput[0].Costs.Length;
                if (costCount > 0)
                {
                    carrierName = result.ShipInqOutput[0].Costs[0].VendorName;
                }
                else
                {
                    carrierName = "";
                }

                int refCount = result.ShipInqOutput[0].References.Length;
                if (refCount > 0)
                {
                    pRONumber = result.ShipInqOutput[0].References[0].RefNo;
                }
                else
                {
                    pRONumber = "";
                }
                originName = result.ShipInqOutput[0].ShipperName;
                originAddress = result.ShipInqOutput[0].ShipperAddress1;
                originAddress2 = result.ShipInqOutput[0].ShipperAddress2;
                originZip = result.ShipInqOutput[0].ShipperZip;
                originCountry = result.ShipInqOutput[0].ShipperCountry;
                originCity = result.ShipInqOutput[0].ShipperCity;
                originState = result.ShipInqOutput[0].ShipperState;
                destinationName = result.ShipInqOutput[0].ConsigneeName;
                destinationAddress = result.ShipInqOutput[0].ConsigneeAddress1;
                destinationAddress2 = result.ShipInqOutput[0].ConsigneeAddress2;
                destinationZip = result.ShipInqOutput[0].ConsigneeZip;
                destinationCountry = result.ShipInqOutput[0].ConsigneeCountry;
                destinationCity = result.ShipInqOutput[0].ConsigneeCity;
                destinationState = result.ShipInqOutput[0].ConsigneeState;
                actualDelivery = result.ShipInqOutput[0].ScheduledDeliveryDate;

                //verifying API and DB Actual delivery date
                claimModel = DBHelper.GetInsuranceClaimVal(claimNumber);
                DateTime dateDB = Convert.ToDateTime(claimModel[0].ActualDeliveryDate);
                DateTime dateAPI = Convert.ToDateTime(actualDelivery);
                Assert.AreEqual(dateDB.ToShortDateString(), dateAPI.ToShortDateString());


                ActualDeliveryDateVerification();

            }
        }


        [Then(@"CRM will retrieve and store the Actual Delivery Date form valid MG BOL number (.*)")]
        public void ThenCRMWillRetrieveAndStoreTheActualDeliveryDateFormValidMGBOLNumber(string BOLNumber)
        {
            Report.WriteLine("Verifying CRM will retrieve and store the Actual Delivery Date from valid MG BOL number");
            bOLNumber = Regex.Replace(BOLNumber, @"(\s+|&|'|\(|\)|<|>|#)", "");
            inuredClaimPopulateDely_Date = new InsuranceClaims_ToVerifyAuto_PopulateFieldsSteps();
            Sdata = inuredClaimPopulateDely_Date.WhenIReceiveTheDataForTheSubmittedReferenceNumberFromMG(bOLNumber);

            //verifying API and DB Actual delivery date
            claimModel = DBHelper.GetInsuranceClaimVal(claimNumber);
            DateTime dateDB = Convert.ToDateTime(claimModel[0].ActualDeliveryDate);
            DateTime dateAPI = Convert.ToDateTime(Sdata[1].ActualDelivery);
            Assert.AreEqual(dateDB.ToShortDateString(), dateAPI.ToShortDateString());

            //verifying DB and UI Actual delivery date
            ActualDeliveryDateVerification();


        }

        public void ActualDeliveryDateVerification()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, ClaimListPendingStatus_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_xpath, ClaimsListSearchField_xpath, Convert.ToString(claimNumber));
            Click(attributeName_xpath, ClaimGrid_DLSW_First_ClaimNumber_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            string deliveryDateInUI = GetAttribute(attributeName_id, KeyDates_DeliveryDate_Id, "value");
            DateTime dateDB = Convert.ToDateTime(claimModel[0].ActualDeliveryDate);
            DateTime dateUI = Convert.ToDateTime(deliveryDateInUI);

            //For Internal user
            scrollElementIntoView(attributeName_id, KeyDates_DeliveryDate_Id);

            Assert.AreEqual(dateDB.ToShortDateString(), dateUI.ToShortDateString());
        }

    
        [Given(@"I have entered a valid DLSW BOL number (.*)")]
        public void GivenIHaveEnteredAValidDLSWBOLNumber(string DLSWBOLNumber)
        {
            bOLNumber = Regex.Replace(DLSWBOLNumber, @"(\s+|&|'|\(|\)|<|>|#)", "");
            SendKeys(attributeName_id, Enter_DLSW_BOLNumber_Textbox_Id, bOLNumber);
        }

        public string stationName = "ZZZ - Web Services Test";
        public string customerName = "ZZZ - GS Customer Test";
       

        [Given(@"I have manually entered all required fields (.*)")]
        public void GivenIHaveManuallyEnteredAllRequiredFields(string bolNumber)
        {
            bOLNumber = Regex.Replace(bolNumber, @"(\s+|&|'|\(|\)|<|>|#)", "");

            Click(attributeName_xpath, SubmitaClaim_Stationdropdown_xpath);
            IList<IWebElement> stationValues = GlobalVariables.webDriver.FindElements(By.XPath(SubmitaClaim_StatiodropdownValues_xpath));
            int stnDropDownCount = stationValues.Count;
            for (int i = 0; i < stnDropDownCount; i++)
            {
                if (stationValues[i].Text == stationName)
                {
                    stationValues[i].Click();
                    break;
                }
            }

            Thread.Sleep(2000);


            Click(attributeName_xpath, SubmitaClaim_Customerdropdown_xpath);
            IList<IWebElement> customerValues = GlobalVariables.webDriver.FindElements(By.XPath(SubmitaClaim_CustomerdropdownValues_xpath));
            int custDropDownCount = customerValues.Count;
            for (int i = 0; i < custDropDownCount; i++)
            {
                if (customerValues[i].Text == customerName)
                {
                    customerValues[i].Click();
                    break;
                }
            }

            SendKeys(attributeName_id, DLSWBillOfLading_Textbox_Id, bOLNumber);
            SendKeys(attributeName_id, CarrierName_Textbox_Id, "Carrier123");
            Click(attributeName_id, DLSW_BOLDate_Field_Id);
            AnyNextDatePickerFromDoubleGridCalander(attributeName_xpath, DLSDate_Xpath, -1, DLSDateMonth_Xpath);
            string UIDLSDate = Gettext(attributeName_id, DLSW_BOLDate_Field_Id);
            SendKeys(attributeName_id, CarrierPro_Textbox_Id, "123QA");
            Click(attributeName_id, CarrierProDate_Field_Id);
            AnyNextDatePickerFromDoubleGridCalander(attributeName_xpath, CarrierProDate_Field_Values_Xpath, -1, CarrierProDate_Field_LeftArrow_Xpath);
            Report.WriteLine("Carrier information is passed");

            scrollpagedown();
            SendKeys(attributeName_id, Shipper_Name_Textbox_Id, "Testing 1@3");
            SendKeys(attributeName_id, Shipper_Address_Textbox_Id, "AddressTest!123");
            SendKeys(attributeName_id, Shipper_Address2_Textbox_Id, "Address223");
            SendKeys(attributeName_id, Shipper_Zip_Postal_Textbox_Id, "90001");
            Report.WriteLine("Shipper information is passed");
            SendKeys(attributeName_id, Consignee_Name_Textbox_Id, "Consigneename");
            SendKeys(attributeName_id, Consignee_Address_Textbox_Id, "ConsigneAddress");
            SendKeys(attributeName_id, Consignee_Address2_Textbox_Id, "ConsigneAddress2");
            SendKeys(attributeName_id, Consignee_Zip_Postal_Textbox_Id, "33126");
            Report.WriteLine("Consignee information is passed");
           
        }


        public void ClaimNonPopulateFileds()
        {
            Report.WriteLine("MG Shipment is passed");
          
            GlobalVariables.webDriver.WaitForPageLoad();
            scrollElementIntoView(attributeName_id, ClaimPayableTo_CompanyName_Id);
            SendKeys(attributeName_id, ClaimPayableTo_CompanyName_Id, "CompanyName");
            SendKeys(attributeName_id, ClaimPayableTo_Address_Id, "Address )**(434");
            SendKeys(attributeName_id, ClaimPayableTo_Address2_Id, "Address2");
            SendKeys(attributeName_id, ClaimPayableTo_ZipCode_Id, "32435");
            SendKeys(attributeName_id, ClaimPayableTo_City_Id, "City");
            Click(attributeName_xpath, ClaimPayableTo_Country_dropdown_Xpath);
            Thread.Sleep(5000);
            SelectDropdownValueFromList(attributeName_xpath, ClaimPayableTo_Country_dropdownValue_Xpath, "United States");
            SendKeys(attributeName_id, ClaimPayableTo_ContactName_Id, "ContactName");
            SendKeys(attributeName_id, ClaimPayableTo_ContactPhone_Id, "84324249324");
            SendKeys(attributeName_id, ClaimPayableTo_ContactEmail_Id, "dyafdyu@gmail.com");
            SendKeys(attributeName_id, ClaimPayableTo_CompanyWebsite_Id, "www.shua.com");
            Report.WriteLine("Claim payable to information is passed");
            Click(attributeName_xpath, ArticlesInsuredYes_Xpath);
            SendKeys(attributeName_id, InsuredAmount_Id, "23.00");
            Click(attributeName_xpath, ShortageOption_Xpath);
            Click(attributeName_xpath, ArticlesTypeUsed_Xpath);
            SendKeys(attributeName_id, UnitValue_Id, "23.00");
            SendKeys(attributeName_id, Quantity_Id, "45");
            SendKeys(attributeName_id, Weight_LBS_Id, "23.00");
            SendKeys(attributeName_id, ClaimedArticle_Description_Id, "Description Test 123");
            Click(attributeName_xpath, FreightChargeYes_Xpath);
            scrollpagedown();
            scrollpagedown();
            SendKeys(attributeName_classname, OriginFreightChargeOptionField_Class, "23.00");
           // SendKeys(attributeName_classname, ReturnFreightVal_Class, "23.00");
           // SendKeys(attributeName_id, ReturnDLS_Id, "45564321236789087654");
           // SendKeys(attributeName_classname, ReplaceFreightVal_Class, "20.00");
           // SendKeys(attributeName_id, ReplaceDLS_Id, "532756");
            Report.WriteLine("Claim details are been passed");
            scrollpagedown();
            scrollpagedown();
            Thread.Sleep(3000);
            string oldPath = Path.GetFullPath("../../Scripts/TestData/Testfiles_ClaimDocument/searcherCheck.txt");
            Thread.Sleep(3000);
            string newPath = Path.GetFullPath("../../Scripts/TestData/Temp/" + Guid.NewGuid().ToString() + "searcherCheck1.txt");
            Thread.Sleep(3000);
            File.Copy(oldPath, newPath, true);
            FileUpload(attributeName_xpath, DocumentUploadButton_Xpath, newPath);
            Thread.Sleep(3000);
            File.Delete(newPath);
            scrollElementIntoView(attributeName_id, AddAdditionalDocument_Button_Id);
            Report.WriteLine("Documents are uploaded");
            SendKeys(attributeName_id, RemarksField_Id, "jdhasu5535437hgd$#%^");
            claimNumber = DBHelper.GetClaimNumber();
            claimNumber++;
        }

    }
}
