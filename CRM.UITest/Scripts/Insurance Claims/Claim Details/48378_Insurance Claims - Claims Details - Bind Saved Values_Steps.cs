using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Helper.ViewModel;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Insurance_Claims.Claim_Details
{
    [Binding]
    public class _48378_Insurance_Claims___Claims_Details___Bind_Saved_Values_Steps : InsuranceClaim
    {
        CommonMethodsCrm crmLogin = new CommonMethodsCrm();
        ClaimDetailsPage claimdetailspage = new ClaimDetailsPage();        

        public string userName;
        public string password;
        public string loggedInUserType;

        public string StationName = "ZZZ - Web Services Test";
        public string CustomerName = "ZZZ - GS Customer Test";
        int ClaimNumber = 0;
        public string tab;
        public string replacementClaimable;
        public string returnClaimable;
        public string originalClaimable;

        public int specificClaimBasedOnTab;
        int ftl_ClaimNumber = 2018000335;
        int ftl_ClaimNumber1 = 2018000340;
        int forwarding_ClaimNumber = 2018000336;


        //Header section
        string DLSW_ClaimRep = "Alan Burton";
        string stationname = "ZZZ";

        public string DLSW_Ref = "ZZZGS1234";
        string claimant = "ZZZ12";
        string claimReason = "Damaged";
        public string carrierName = "R & L Carriers";
        public string carrierPRO = "ZZ1234";
        string insured = "Y";

        //FTL- Specific fields
        string carrierMC = "CarrierMC1";
        string sealIntact = "Yes";
        string seal = "Seal111";
        string vehicle = "Turbo226";

        //Forwarding - Specific fields
        string airline = "AAA Cooper";
        string pickupCarrier = "Aberdeen Express";
        string deliveryCarrier = "A1 Transport Network Inc";
        string steamshipLine = "Air France";
        string freightForwarder = "Air Surface Express";
        string whiteGloveAgent = "Aloha Freight";

        //Shipper
        string shipperName = "Shipper Name";
        string shipperAddress = "Shipper Address";
        string shipperZip = "33126";
        string shipperCity = "Miami";
        string shipperCountry = "UNITED STATES";
        string shipperState = "FL";
        string dateAcktoClaimant = "09/23/2018";
        string dateFiledw_carrier = "09/22/2018";
        string program = "PPP";
        string amount = "10000.20";
        string company = "RR Donnelley";

        //Consignee
        string consigneeName = "Consignee Name";
        string consigneeAddress = "Consignee Address";
        string consigneeZip = "85282";
        string consigneeCity = "Tempe";
        string consigneeCountry = "UNITED STATES";
        string consigneeState = "AZ";
        string carrierAck = "Y";
        string carrierAckDate = "09/23/2018";
        string carrierClaim = "Claim128";
        string carrierPRODate = "09/18/2018";
        string bolShipDate = "09/19/2018";
        string deliveryDate = "09/24/2018";
        string remarks = "Remarks checked";

        //Claim Payable To
        string companyName = "Company Name";
        string companyAddress = "Company Address";
        string companyZip = "33126";
        string claimContactName = "Contact Name";
        string claimContactPhone = "2222222222";
        string claimContactEmail = "contact@email.com";

        //Product Claimed
        string clmType = "Damaged";
        string artType = "New";
        string qty = "2000";
        string item = "5.00";
        string desc = "Item - Steels";
        string unitWT = "200.00";
        string unitValue = "5.00";
        string totalShipmentWeight = "1500.00";

        //Product Claimed - Additional Item
        string clmTypeItem2 = "Shortage";
        string artTypeItem2 = "Used";
        string qtyItem2 = "1000";
        string itemItem2 = "5.00";
        string descItem2 = "Item - 2";
        string unitWTItem2 = "100.00";
        string unitValueItem2 = "6.00";
        string totalShipmentWeightItem2 = "1000.00";

        //Freight Calculations
        string o_ClaimedFreight = "10.00";
        string o_CarrierChargestoDLSW = "20.00";
        string o_DLSWChargestoCust = "30.00";
        string o_DLSWRef = "ZZZ1234";

        string ret_ClaimedFreight = "20.00";
        string ret_CarrierChargestoDLSW = "30.00";
        string ret_DLSWChargestoCust = "40.00";
        string ret_DLSWRef = "ZZZ4567";

        string rep_ClaimedFreight = "30.00";
        string rep_CarrierChargestoDLSW = "40.00";
        string rep_DLSWChargestoCust = "50.00";
        string rep_DLSWRef = "ZZZ0001";

        public string subTotalAllClaimValues;

        bool isChecked_OriginalFreightCharges;
        bool isChecked_RetFreightCharges;
        bool isChecked_RepFreightCharges;

        //Comments
        string comments = "Claim All fields checked";

        [Given(@"I am a Sales, Sales Management, Operations, Station Owner or Claims Specialist user (.*)")]
        public void GivenIAmASalesSalesManagementOperationsStationOwnerOrClaimsSpecialistUser(string userType)
        {
            loggedInUserType = userType;
            if (userType == "Internal")
            {
                userName = ConfigurationManager.AppSettings["username-CurrentSprintOperations"].ToString();
                password = ConfigurationManager.AppSettings["password-CurrentSprintOperations"].ToString();
                Report.WriteLine("Logging in as " + userName);
            }
            else if (userType == "Sales")
            {
                userName = ConfigurationManager.AppSettings["username-CurrentSprintSales"].ToString();
                password = ConfigurationManager.AppSettings["password-CurrentSprintSales"].ToString();
                Report.WriteLine("Logging in as " + userName);
            }
            else
            {
                userName = ConfigurationManager.AppSettings["username-CurrentsprintClaimspecialist"].ToString();
                password = ConfigurationManager.AppSettings["password-CurrentsprintClaimspecialist"].ToString();
                Report.WriteLine("Logging in as " + userName);
            }
            crmLogin.LoginToCRMApplication(userName, password);
        }


        [Given(@"I have completed all required information")]
        public void GivenIHaveCompletedAllRequiredInformation()
        {
            Report.WriteLine("Submit a Claim form displays");

            //Fill up all mandatory fields and all fields under "Freight Charges" and "Claimed Items" section

            if (loggedInUserType == "Internal")
            {
                //Selecting Station for internal users
                Click(attributeName_xpath, SubmitaClaim_Stationdropdown_xpath);                
                SelectDropdownValueFromList(attributeName_xpath, SubmitaClaim_StationdropdownInternalValues_xpath, StationName);                
            }
            else if(loggedInUserType == "Sales")
            {
                //Selecting Station
                Click(attributeName_xpath, SubmitaClaim_Stationdropdown_xpath);
                SelectDropdownValueFromList(attributeName_xpath, SubmitaClaim_StatiodropdownValues_xpath, StationName);
            }
            else
            { 
                //Selecting Station
                Click(attributeName_xpath, SubmitaClaim_Stationdropdown_xpath);
                SendKeys(attributeName_xpath, SubmitaClaim_Stationdropdownsearch_xpath, StationName);
                SelectDropdownValueFromList(attributeName_xpath, SubmitaClaim_StatiodropdownValues_xpath, StationName);            
            }

            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Selected Station: " + StationName);

            //Selecting Customer
            Click(attributeName_xpath, SubmitaClaim_Customerdropdown_xpath);
            SendKeys(attributeName_xpath, SubmitaClaim_Customerdropdownsearch_xpath, CustomerName);
            SelectDropdownValueFromList(attributeName_xpath, SubmitaClaim_CustomerdropdownValues_xpath, CustomerName);            
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Selected Customer: " + CustomerName);

            //Entering data for fields under Carrier Information section

            SendKeys(attributeName_id, DLSWBillOfLading_Textbox_Id, DLSW_Ref);
            Click(attributeName_id, DLSWShipDate_Id);
            AnyNextDatePickerFromDoubleGridCalander(attributeName_xpath, DLSDate_Xpath, -1, DLSDateMonth_Xpath);           
            SendKeys(attributeName_id, CarrierName_Textbox_Id, carrierName);
            SendKeys(attributeName_id, CarrierPro_Textbox_Id, carrierPRO);

            //Entering data for fields under Shipper Information section
            SendKeys(attributeName_classname, "ShipperName", shipperName);
            SendKeys(attributeName_id, "ShipperAddress", shipperAddress);

            SendKeys(attributeName_id, "ShipperZip", shipperZip);
            GlobalVariables.webDriver.WaitForPageLoad();

            //Entering data for fields under Consignee Information section
            SendKeys(attributeName_id, "ConsigneeName", consigneeName);
            SendKeys(attributeName_id, "ConsigneeAddress", consigneeAddress);
            SendKeys(attributeName_id, "ConsigneeZip", consigneeZip);
            GlobalVariables.webDriver.WaitForPageLoad();

            //Entering data for fields under Claim Payable To section
            SendKeys(attributeName_id, "ClaimCompanyName", companyName);
            SendKeys(attributeName_id, "ClaimAddress", companyAddress);
            SendKeys(attributeName_id, "ClaimZip", companyZip);
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_id, "ClaimContactName", claimContactName);
            SendKeys(attributeName_id, "ContactPhone", claimContactPhone);
            SendKeys(attributeName_id, "ContactEmail", claimContactEmail);
            scrollpagedown();
            scrollpagedown();

            //Entering data for fields under Claim Details section
            //Item 1
            Click(attributeName_xpath, DamageOption_Xpath); //selecting Damage radio button
            Click(attributeName_xpath, ArticlesTypeNew_Xpath); //selecting New radio button
            SendKeys(attributeName_xpath, "(//input[@id = 'Item/Model#'])[1]", desc);
            SendKeys(attributeName_xpath, "(//input[@id = 'UnitValue'])[1]", unitValue);
            SendKeys(attributeName_xpath, "(//input[@id = 'Quantity'])[1]", qty);
            SendKeys(attributeName_xpath, "(//input[@id = 'Weight'])[1]", unitWT);
            SendKeys(attributeName_xpath, "(.//textarea[@id = 'DescriptionofClaimedArticles'])[1]", "Description - Claimed Articles - Item 1");
            
            //Additional Item - Item 2
            Click(attributeName_xpath, AddAnotherItem_Xpath);
            Click(attributeName_xpath, ".//*[@id='page-content-wrapper']//*[@for = 'btn-claimtypeShortage0']");
            Click(attributeName_xpath, ".//*[@id='page-content-wrapper']//*[@for = 'btn-articlestypeUsed0']");
            SendKeys(attributeName_xpath, "(//input[@id = 'Item/Model#'])[2]", descItem2);
            SendKeys(attributeName_xpath, "(//input[@id = 'UnitValue'])[2]", unitValueItem2);
            SendKeys(attributeName_xpath, "(//input[@id = 'Quantity'])[2]", qtyItem2);
            SendKeys(attributeName_xpath, "(//input[@id = 'Weight'])[2]", unitWTItem2);
            SendKeys(attributeName_xpath, "(.//textarea[@id = 'DescriptionofClaimedArticles'])[2]", "Description - Claimed Articles - Item 2");

            //Entering data for fields under "Do you wish to add freight charges?" section
            Click(attributeName_xpath, FreightChargeYes_Xpath);
            scrollpagedown();
            scrollpagedown();
            Click(attributeName_xpath, OriginFreightChargeOption_Xpath);
            string OrgFrtChrg_isCheckedStrVal= Gettext(attributeName_xpath, OriginFreightChargeOption_Xpath);
            if(OrgFrtChrg_isCheckedStrVal == "Original Freight Charges")
            {
                isChecked_OriginalFreightCharges = true;
            }
            SendKeys(attributeName_classname, OriginFreightChargeOptionField_Class, o_ClaimedFreight);

            Click(attributeName_xpath, ReturnFreightCharge_Xpath);
            string RetFrtChrg_isCheckedStrVal = Gettext(attributeName_xpath, ReturnFreightCharge_Xpath);
            if (RetFrtChrg_isCheckedStrVal == "Return Freight Charges")
            {
                isChecked_RetFreightCharges = true;
            }
            SendKeys(attributeName_classname, ReturnFreightVal_Class, ret_ClaimedFreight);
            SendKeys(attributeName_id, ReturnDLS_Id, DLSW_Ref);

            Click(attributeName_xpath, ReplacementFreight_Xpath);
            string RepFrtChrg_isCheckedStrVal = Gettext(attributeName_xpath, ReplacementFreight_Xpath);
            if (RepFrtChrg_isCheckedStrVal == "Replacement Freight Charges")
            {
                isChecked_RepFreightCharges = true;
            }
            SendKeys(attributeName_classname, ReplaceFreightVal_Class, rep_ClaimedFreight);            
            SendKeys(attributeName_id, ReplaceDLS_Id, DLSW_Ref);

            subTotalAllClaimValues = GetAttribute(attributeName_id, Subtotal_Id, "value");

            //Upload document for a claim
            Thread.Sleep(4000);
            string oldPath = Path.GetFullPath("../../Scripts/TestData/Testfiles_ClaimDocument/searcherCheck.txt");
            Thread.Sleep(4000);
            string newPath = Path.GetFullPath("../../Scripts/TestData/Temp/" + Guid.NewGuid().ToString() + "searcherCheck1.txt");
            Thread.Sleep(4000);
            File.Copy(oldPath, newPath, true);
            Thread.Sleep(4000);
            FileUpload(attributeName_xpath, DocumentUploadButton_Xpath, newPath);
            Thread.Sleep(6000);
            File.Delete(newPath);
            Report.WriteLine("Document is uploaded");
            scrollpagedown();
            scrollpagedown();
        }


        [Given(@"I am on the Claim Details page of any existing claim (.*)")]
        public void GivenIAmOnTheClaimDetailsPageOfAnyExistingClaim(string Tab)
        {
            Report.WriteLine("I am on the Claims List Page");
            Click(attributeName_id, ClaimsIcon_Id);
            VerifyElementPresent(attributeName_xpath, ClaimsListPage_HeaderText_Xpath, "Claims List");

            //Click(attributeName_xpath, ClaimsList_OpenCheckbox_xpath);
            Click(attributeName_xpath, ClaimsList_PendingCheckbox_xpath);

            if (Tab == "FTL")
            {
                tab = "FTL-Tab";
                SendKeys(attributeName_xpath, ClaimListSearchTextBox_xpath, ftl_ClaimNumber1.ToString());
                Click(attributeName_xpath, ClaimsList_FirstVal_DLSWClaimNum_xpath);
                GlobalVariables.webDriver.WaitForPageLoad();
                scrollElementIntoView(attributeName_xpath, ClaimDetailsPage_Header_Xpath);
                Verifytext(attributeName_xpath, ClaimDetailsPage_Header_Xpath, "Claim Details");

            }
            else
            {
                tab = "Forwarding-Tab";
                SendKeys(attributeName_xpath, ClaimListSearchTextBox_xpath, forwarding_ClaimNumber.ToString());
                Click(attributeName_xpath, ClaimsList_FirstVal_DLSWClaimNum_xpath);
                GlobalVariables.webDriver.WaitForPageLoad();
                scrollPageup();
                scrollPageup();
                // scrollElementIntoView(attributeName_xpath, ClaimDetailsPage_Header_Xpath);
                Verifytext(attributeName_xpath, ClaimDetailsPage_Header_Xpath, "Claim Details");
            }


        }

        [Given(@"I have edited the Header Section - \(DLSW Claim Rep, DLSW Ref \#, Claimant, Claim Reason, Carrier Name, Carrier PRO \#, Insured\)")]
        public void GivenIHaveEditedTheHeaderSection_DLSWClaimRepDLSWRefClaimantClaimReasonCarrierNameCarrierPROInsured()
        {
            claimdetailspage.ClaimHeader(DLSW_ClaimRep, stationname, DLSW_Ref, claimant, claimReason, carrierName, carrierPRO, insured);
        }

        [Given(@"I have edited the (.*) FTL Tab -\(Carrier MC \#, Seal Intact, Seal \#, Vehicle \#\), Forwarding Tab - \(Airline, Pickup Carrier, Delivery Carrier, Steamship Line, Freight Forwarder, White Glove Agent\)")]
        public void GivenIHaveEditedTheFTLTab_CarrierMCSealIntactSealVehicleForwardingTab_AirlinePickupCarrierDeliveryCarrierSteamshipLineFreightForwarderWhiteGloveAgent(string Tab)
        {
            if (Tab == "FTL")
            {
                tab = "FTL-Tab";
                GlobalVariables.webDriver.WaitForPageLoad();
                ScrollToTopElement(attributeName_xpath, shipmentMode_Xpath);
                Click(attributeName_xpath, shipmentMode_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, ClaimDetailsModeDropdown_Xpath, "FTL");
                scrollpagedown();
                Verifytext(attributeName_xpath, FTL_Specific_Fields_Header_xpath, "FTL-Specific Fields");
                claimdetailspage.FTL_SpecificFields(carrierMC, sealIntact, seal, vehicle);

            }
            else
            {
                tab = "Forwarding-Tab";
                GlobalVariables.webDriver.WaitForPageLoad();
                Click(attributeName_xpath, shipmentMode_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, ClaimDetailsModeDropdown_Xpath, "Forwarding");
                scrollpagedown();
                Verifytext(attributeName_xpath, Forwarding_SpecificFields_Header_Xpath, "Forwarding-Specific Fields");
                claimdetailspage.ForwardingTab(airline, pickupCarrier, deliveryCarrier, steamshipLine, freightForwarder, whiteGloveAgent);
            }

        }

        [Given(@"I have edited the Shipper Section - \(Name, Address, City, State, Zip, Country\),DLSW OS&D Actions\(Date Ack to Claimant, Date Filed with Carrier\), Insurance Info - \(Program, Amount, Company\)")]
        public void GivenIHaveEditedTheShipperSection_NameAddressCityStateZipCountryDLSWOSDActionsDateAckToClaimantDateFiledWithCarrierInsuranceInfo_ProgramAmountCompany()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            scrollpagedown();
            claimdetailspage.Shipper(shipperName, shipperAddress, shipperZip, shipperCity, shipperCountry, shipperState, dateAcktoClaimant, dateFiledw_carrier, program, amount, company);
        }

        [Given(@"I have edited the Consignee Section - \(Name, Address, City, State, Zip, Country\) , Carrier OS&D Actions - \(Carrier Ack, Carrier Ack Date, Carrier Claim \#\), Key Dates - \(Carrier PRO Date, BOL/Ship Date, Delivery Date\), Remarks")]
        public void GivenIHaveEditedTheConsigneeSection_NameAddressCityStateZipCountryCarrierOSDActions_CarrierAckCarrierAckDateCarrierClaimKeyDates_CarrierPRODateBOLShipDateDeliveryDateRemarks()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            scrollpagedown();
            claimdetailspage.Consignee(consigneeName, consigneeAddress, consigneeZip, consigneeCity, consigneeCountry, consigneeState, carrierAck, carrierAckDate, carrierClaim, carrierPRODate, bolShipDate, deliveryDate, remarks);
        }

        [Given(@"I have edited the Products Claimed Section - \(Clm Type, Art Type, Qty, Item \#, Desc, Unit Wt,  Unit Val, Total Shipment Weight\)")]
        public void GivenIHaveEditedTheProductsClaimedSection_ClmTypeArtTypeQtyItemDescUnitWtUnitValTotalShipmentWeight()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            scrollpagedown();
            claimdetailspage.ProductClaimed(clmType, artType, qty, item, desc, unitWT, unitValue, totalShipmentWeight);
        }

        [Given(@"I have edited the Freight Calculations: Original Row - Claimable (.*) \(Claimed Freight, Carrier Charges to DLSW, DLSW Charges to Cust, DLSW Ref \#\)")]
        public void GivenIHaveEditedTheFreightCalculationsOriginalRow_ClaimableClaimedFreightCarrierChargesToDLSWDLSWChargesToCustDLSWRef(string claimable)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            scrollpagedown();
            scrollpagedown();

            string clamable1 = claimable.Replace(@"<", "");
            string clamable_Y_N = clamable1.Replace(@">", "");

            if (clamable_Y_N == "Y")
            {
                originalClaimable = "Y";
                Click(attributeName_xpath, Claimable_dropdown_Original_Xpath);
                IList<IWebElement> originalDropDownList = GlobalVariables.webDriver.FindElements(By.XPath(Claimable_dropdownValue_Original_Xpath));
                for (int i = 0; i < originalDropDownList.Count; i++)
                {
                    if (originalDropDownList[i].Text == clamable_Y_N)
                    {
                        originalDropDownList[i].Click();
                        break;
                    }

                }

                claimdetailspage.FreightCalculations_Original(o_ClaimedFreight, o_CarrierChargestoDLSW, o_DLSWChargestoCust, o_DLSWRef);

            }
            else
            {
                Report.WriteLine("Freight Calculations - Original - Fields will be blanks");

            }
        }

        [Given(@"I have edited the Freight Calculations: Return Row - Claimable (.*) \(Claimed Freight, Carrier Charges to DLSW, DLSW Charges to Cust, DLSW Ref \#\)")]
        public void GivenIHaveEditedTheFreightCalculationsReturnRow_ClaimableClaimedFreightCarrierChargesToDLSWDLSWChargesToCustDLSWRef(string claimable)
        {
            string clamable1 = claimable.Replace(@"<", "");
            string clamable_Y_N = clamable1.Replace(@">", "");

            GlobalVariables.webDriver.WaitForPageLoad();
            if (clamable_Y_N == "Y")
            {
                returnClaimable = "Y";
                Click(attributeName_xpath, Claimabledropdown_Return_Xpath);
                IList<IWebElement> returnDropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ClaimabledropdownValue_Return_Xpath));
                for (int i = 0; i < returnDropDownList.Count; i++)
                {
                    if (returnDropDownList[i].Text == clamable_Y_N)
                    {
                        returnDropDownList[i].Click();
                        break;
                    }

                }
                claimdetailspage.FreightCalculations_Return(ret_ClaimedFreight, ret_CarrierChargestoDLSW, ret_DLSWChargestoCust, ret_DLSWRef);

            }
            else
            {
                Report.WriteLine("Freight Calculations - Return - Fields will be blanks");

            }
        }

        [Given(@"I have edited the Freight Calculations: Replacement Row - Claimable (.*) \(Claimed Freight, Carrier Charges to DLSW, DLSW Charges to Cust, DLSW Ref \#\)")]
        public void GivenIHaveEditedTheFreightCalculationsReplacementRow_ClaimableClaimedFreightCarrierChargesToDLSWDLSWChargesToCustDLSWRef(string claimable)
        {
            string clamable1 = claimable.Replace(@"<", "");
            string clamable_Y_N = clamable1.Replace(@">", "");

            GlobalVariables.webDriver.WaitForPageLoad();
            if (clamable_Y_N == "Y")
            {
                replacementClaimable = "Y";
                Click(attributeName_xpath, Claimabledropdown_Replacement_Xpath);
                IList<IWebElement> replacementDropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ClaimabledropdownValue_Replacement_Xpath));
                for (int i = 0; i < replacementDropDownList.Count; i++)
                {
                    if (replacementDropDownList[i].Text == clamable_Y_N)
                    {
                        replacementDropDownList[i].Click();
                        break;
                    }

                }
                claimdetailspage.FreightCalculations_Replacement(rep_ClaimedFreight, rep_CarrierChargestoDLSW, rep_DLSWChargestoCust, rep_DLSWRef);

            }
            else
            {
                Report.WriteLine("Freight Calculations - Replacement - Fields will be blanks");

            }
        }

        [Given(@"I have edited the Freight Calculations: Comments")]
        public void GivenIHaveEditedTheFreightCalculationsComments()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            claimdetailspage.Comments(comments);
            scrollPageup();
            scrollPageup();
            scrollPageup();
        }

        [Then(@"All edited fields should get saved")]
        public void ThenAllEditedFieldsShouldGetSaved()
        {

            //FTL - Tab
            if (tab == "FTL-Tab")
            {
                specificClaimBasedOnTab = ftl_ClaimNumber;
                Entities.Proxy.InusranceFtlMode ftlFielVal = DBHelper.GetFTLFieldsValClaimDetails(ftl_ClaimNumber.ToString());

                Assert.AreEqual(ftlFielVal.CarrierMcNumber, carrierMC);
                Report.WriteLine("Edited Carrier MC number is saved in DB");

                if (sealIntact == "Yes")
                {
                    Assert.AreEqual(ftlFielVal.SealIntact, true);
                    Report.WriteLine("Edited Seal Intact is saved in DB");
                }
                else
                {
                    Assert.AreEqual(ftlFielVal.SealIntact, false);
                    Report.WriteLine("Edited Seal Intact is saved in DB");
                }

                Assert.AreEqual(ftlFielVal.Seal, seal);
                Report.WriteLine("Edited Seal number is saved in DB");

                Assert.AreEqual(ftlFielVal.Vehicle, vehicle);
                Report.WriteLine("Edited Vehicle number is saved in DB");

            }

            // Forwarding - Tab
            else
            {
                specificClaimBasedOnTab = forwarding_ClaimNumber;
                Entities.Proxy.InsuranceForwardingMode ForwardingSpecificData = DBHelper.GetForwardingModeDetails(forwarding_ClaimNumber);
                Assert.AreEqual(ForwardingSpecificData.Airline, airline);
                Report.WriteLine("Edited airline field is saved in DB");

                Assert.AreEqual(ForwardingSpecificData.PickupCarrier, pickupCarrier);
                Report.WriteLine("Edited pickupCarrier field is saved in DB");

                Assert.AreEqual(ForwardingSpecificData.DeliveryCarrier, deliveryCarrier);
                Report.WriteLine("Edited deliveryCarrier field is saved in DB");

                Assert.AreEqual(ForwardingSpecificData.SteamshipLine, steamshipLine);
                Report.WriteLine("Edited steamshipLine field is saved in DB");

                Assert.AreEqual(ForwardingSpecificData.FreightForwarder, freightForwarder);
                Report.WriteLine("Edited freightForwarder field is saved in DB");

                Assert.AreEqual(ForwardingSpecificData.WhiteGloveAgent, whiteGloveAgent);
                Report.WriteLine("Edited whiteGloveAgent field is saved in DB");
            }


            //Claim Header Section
            Report.WriteLine("Header Section all fields should get saved");

            int claimNumber = Convert.ToInt32(ftl_ClaimNumber);
            InsuranceClaimDetailsHeaderViewModel insuranceClaimDetailsHeaderViewModel = DBHelper.GetInsuranceClaimDetailsHeader(specificClaimBasedOnTab);

            Assert.AreEqual(insuranceClaimDetailsHeaderViewModel.ClaimRep, DLSW_ClaimRep);
            Report.WriteLine("Edited DLSW_ClaimRep field is saved in DB");

            //station is pending 

            Assert.AreEqual(insuranceClaimDetailsHeaderViewModel.DLSWReferenceNumber, DLSW_Ref);
            Report.WriteLine("Edited DLSW_Ref field is saved in DB");

            Assert.AreEqual(insuranceClaimDetailsHeaderViewModel.Claimant, claimant);
            Report.WriteLine("Edited claimant field is saved in DB");

            Assert.AreEqual(insuranceClaimDetailsHeaderViewModel.ClaimReason, claimReason);
            Report.WriteLine("Edited claimReason field is saved in DB");

            Assert.AreEqual(insuranceClaimDetailsHeaderViewModel.Carriername, carrierName);
            Report.WriteLine("Edited carrierName field is saved in DB");

            Assert.AreEqual(insuranceClaimDetailsHeaderViewModel.CarrierPro, carrierPRO);
            Report.WriteLine("Edited carrierPRO field is saved in DB");

            if (insured == "Y")
            {
                Assert.AreEqual(insuranceClaimDetailsHeaderViewModel.IsClaimInsured, true);
                Report.WriteLine("Edited Claim Insured type selected as Yes field is saved in DB");
            }
            else
            {
                Assert.AreEqual(insuranceClaimDetailsHeaderViewModel.IsClaimInsured, false);
                Report.WriteLine("Edited claim Insured type selected as No field is saved in DB");
            }

            //Shipper Section  
            List<InsuranceClaimViewModel> ClaimDetails = DBHelper.GetInsuranceClaimVal(specificClaimBasedOnTab);
            Assert.AreEqual(ClaimDetails.FirstOrDefault().ShipperName, shipperName);
            Report.WriteLine("Edited shipperName field is saved in DB");

            Assert.AreEqual(ClaimDetails.FirstOrDefault().ShipperAddress, shipperAddress);
            Report.WriteLine("Edited shipperAddress field is saved in DB");

            Assert.AreEqual(ClaimDetails.FirstOrDefault().ShipperZip, shipperZip);
            Report.WriteLine("Edited shipperZip field is saved in DB");

            Assert.AreEqual(ClaimDetails.FirstOrDefault().ShipperCity, shipperCity);
            Report.WriteLine("Edited shipperCity field is saved in DB");

            Assert.AreEqual(ClaimDetails.FirstOrDefault().ShipperCountry.ToUpper(), shipperCountry);
            Report.WriteLine("Edited shipperCountry field is saved in DB");

            Assert.AreEqual(ClaimDetails.FirstOrDefault().ShipperState, shipperState);
            Report.WriteLine("Edited shipperState field is saved in DB");

            DateTime dateDB = Convert.ToDateTime(ClaimDetails.FirstOrDefault().DateAckToClaimant);
            string DB_Month = dateDB.Month.ToString();
            string DB_Day = dateDB.Day.ToString();
            string DB_Year = dateDB.Year.ToString();
            string db_dateacktoClaiment = DB_Month + "/" + DB_Day + "/" + DB_Year;

            Assert.AreEqual(dateAcktoClaimant.Contains(db_dateacktoClaiment), true);
            Report.WriteLine("Edited dateAcktoClaimant field is saved in DB");

            DateTime dateDB1 = Convert.ToDateTime(ClaimDetails.FirstOrDefault().DateFiledWCarrier);
            string DB_Month1 = dateDB1.Month.ToString();
            string DB_Day2 = dateDB1.Day.ToString();
            string DB_Year3 = dateDB1.Year.ToString();
            string db_DateFiledWCarrier = DB_Month1 + "/" + DB_Day2 + "/" + DB_Year3;

            Assert.AreEqual(dateFiledw_carrier.Contains(db_DateFiledWCarrier), true);
            Report.WriteLine("Edited dateFiledw_carrier field is saved in DB");

            string insuranceClaimProgram_Id = ClaimDetails.FirstOrDefault().InsuranceClaimProgramId;
            string insuranceClaimCompany_Id = ClaimDetails.FirstOrDefault().InsuranceClaimCompanyId;
            string db_programName = DBHelper.GetInsuranceClaimProgramName(int.Parse(insuranceClaimProgram_Id));
            string db_companyName = DBHelper.GetInsuranceClaimCompanyName(int.Parse(insuranceClaimCompany_Id));

            Assert.AreEqual(db_programName, program);
            Report.WriteLine("Edited program field is saved in DB");
            string db_amount = ClaimDetails.FirstOrDefault().InsuredValAmount.ToString();

            Assert.AreEqual(db_amount, amount);
            Report.WriteLine("Edited Amount field is saved in DB");

            Assert.AreEqual(db_companyName, company);
            Report.WriteLine("Edited company field is saved in DB");

            //Consignee Section
            Assert.AreEqual(ClaimDetails.FirstOrDefault().ConsigneName, consigneeName);
            Report.WriteLine("Edited consigneeName field is saved in DB");

            Assert.AreEqual(ClaimDetails.FirstOrDefault().ConsigneAddress, consigneeAddress);
            Report.WriteLine("Edited consigneeAddress field is saved in DB");

            Assert.AreEqual(ClaimDetails.FirstOrDefault().ConsigneZip, consigneeZip);
            Report.WriteLine("Edited consigneeZip field is saved in DB");

            Assert.AreEqual(ClaimDetails.FirstOrDefault().ConsigneCity, consigneeCity);
            Report.WriteLine("Edited consigneeCity field is saved in DB");

            Assert.AreEqual(ClaimDetails.FirstOrDefault().ConsigneState, consigneeState);
            Report.WriteLine("Edited consigneeState field is saved in DB");

            if (carrierAck.Equals("Y"))
            {
                Assert.AreEqual(ClaimDetails.FirstOrDefault().CarrierAck, "True");
                Report.WriteLine("Edited carrierAck field is saved in DB");

            }
            else
            {
                Assert.AreEqual(ClaimDetails.FirstOrDefault().CarrierAck, "False");
                Report.WriteLine("Edited carrierAck field is saved in DB");
            }



            DateTime dateDB2 = Convert.ToDateTime(ClaimDetails.FirstOrDefault().CarrierAckDate);
            string DB_Month2 = dateDB2.Month.ToString();
            string DB_Day3 = dateDB2.Day.ToString();
            string DB_Year4 = dateDB2.Year.ToString();
            string db_CarrierAckDate = DB_Month2 + "/" + DB_Day3 + "/" + DB_Year4;

            Assert.AreEqual(carrierAckDate.Contains(db_CarrierAckDate), Convert.ToBoolean("True"));
            Report.WriteLine("Edited carrierAckDate field is saved in DB");

            Assert.AreEqual(ClaimDetails.FirstOrDefault().CarrierClaimNumber, carrierClaim);
            Report.WriteLine("Edited carrierClaim field is saved in DB");

            DateTime dateDB3 = Convert.ToDateTime(ClaimDetails.FirstOrDefault().ShipDate);
            string DB_Month3 = dateDB3.Month.ToString();
            string DB_Day4 = dateDB3.Day.ToString();
            string DB_Year5 = dateDB3.Year.ToString();
            string db_ShipDate = DB_Month3 + "/" + DB_Day4 + "/" + DB_Year5;

            Assert.AreEqual(bolShipDate.Contains(db_ShipDate), true);
            Report.WriteLine("Edited bolShipDate field is saved in DB");

            DateTime dateDB4 = Convert.ToDateTime(ClaimDetails.FirstOrDefault().DeliveryDate);
            string DB_Month4 = dateDB4.Month.ToString();
            string DB_Day5 = dateDB4.Day.ToString();
            string DB_Year6 = dateDB4.Year.ToString();
            string db_DeliveryDate = DB_Month4 + "/" + DB_Day5 + "/" + DB_Year6;

            Assert.AreEqual(deliveryDate.Contains(db_DeliveryDate), true);
            Report.WriteLine("Edited deliveryDate field is saved in DB");

            Assert.AreEqual(ClaimDetails.FirstOrDefault().Remarks, remarks);
            Report.WriteLine("Edited remarks field is saved in DB");

            //Product Claimed
            //string totalShipmentWeight = "1500";

            Entities.Proxy.InsuranceClaimItem insuranceClaim_item = DBHelper.GetInsuranceClaimItemdetails(specificClaimBasedOnTab.ToString());
            int claimtypeId = insuranceClaim_item.InsuranceClaimTypeId;
            string db_claimType = DBHelper.GetInsuranceClaimType(claimtypeId);
            int arttypeId = insuranceClaim_item.InsuranceClaimArticleTypeId;
            string db_artType = DBHelper.GetInsuranceArtType(arttypeId);

            Assert.AreEqual(clmType.Contains(db_claimType), true);
            Report.WriteLine("Edited clmType field is saved in DB");

            Assert.AreEqual(db_artType, artType);
            Report.WriteLine("Edited artType field is saved in DB");

            string db_quantity = insuranceClaim_item.Quantity.ToString();
            Assert.AreEqual(db_quantity, "2000");
            Report.WriteLine("Edited qty field is saved in DB");

            string db_item = insuranceClaim_item.ItemNumber.ToString();
            Assert.AreEqual(db_item, item);
            Report.WriteLine("Edited item field is saved in DB");

            Assert.AreEqual(insuranceClaim_item.description, desc);
            Report.WriteLine("Edited description field is saved in DB");

            string db_weight = insuranceClaim_item.Weight.ToString();
            Assert.AreEqual(db_weight, unitWT);
            Report.WriteLine("Edited unitWT field is saved in DB");

            string db_uvalue = insuranceClaim_item.UnitValue.ToString();
            Assert.AreEqual(db_uvalue, unitValue);
            Report.WriteLine("Edited unitValue field is saved in DB");

            //Freight Calculations
            if (originalClaimable == "Y")
            {
                Assert.AreEqual(ClaimDetails.FirstOrDefault().OriginalFreightCharge.ToString(), o_ClaimedFreight);
                Report.WriteLine("Edited Original Claimed Freight field is saved in DB");
                Assert.AreEqual(ClaimDetails.FirstOrDefault().OriginalCarrierChargesToDLSWValue.ToString(), o_CarrierChargestoDLSW);
                Report.WriteLine("Edited Original Carrier Charges To DLSW field is saved in DB");
                Assert.AreEqual(ClaimDetails.FirstOrDefault().OriginalDLSWChargesToCustomerValue.ToString(), o_DLSWChargestoCust);
                Report.WriteLine("Edited Original DLSW Charges To Customer field is saved in DB");
                Report.WriteLine("Original DLSW Ref# will be binded from DLSW Ref#");
            }
            else
            {
                Report.WriteLine("Original Claimable is selected N");
            }
            if (returnClaimable == "Y")
            {
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ReturnFreightCharge.ToString(), ret_ClaimedFreight);
                Report.WriteLine("Edited Return Claimed Freight field is saved in DB");
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ReturnCarrierChargesToDLSWValue.ToString(), ret_CarrierChargestoDLSW);
                Report.WriteLine("Edited Return Carrier Charges To DLSW field is saved in DB");
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ReturnDLSWChargesToCustomerValue.ToString(), ret_DLSWChargestoCust);
                Report.WriteLine("Edited Return DLSW Charges To Customer field is saved in DB");
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ReturnDLSRefNum.ToString(), ret_DLSWRef);
                Report.WriteLine("Edited Return DLSW Ref# field is saved in DB");

            }
            else
            {
                Report.WriteLine("Return Claimable is selected N");
            }
            if (replacementClaimable == "Y")
            {
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ReplacementFreightCharge.ToString(), rep_ClaimedFreight);
                Report.WriteLine("Edited Replacement Claimed Freight field is saved in DB");
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ReplacementCarrierChargesToDLSWValue.ToString(), rep_CarrierChargestoDLSW);
                Report.WriteLine("Edited Replacement Carrier Charges To DLSW field is saved in DB");
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ReplacementDLSWChargesToCustomerValue.ToString(), rep_DLSWChargestoCust);
                Report.WriteLine("Edited Replacement DLSW Charges To Customer field is saved in DB");
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ReplaceDLSWRefNum.ToString(), rep_DLSWRef);
                Report.WriteLine("Edited Replacement DLSW Ref# field is saved in DB");
            }
            else
            {
                Report.WriteLine("Replacement Claimable is selected N");
            }

            //Comments
            Assert.AreEqual(ClaimDetails.FirstOrDefault().Comments, comments);

        }
        [Given(@"I am a  sales, sales management, operations and station owner user")]
        public void GivenIAmASalesSalesManagementOperationsAndStationOwnerUser()
        {
            string userName = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
            string password = ConfigurationManager.AppSettings["password-crmOperation"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(userName, password);
            Report.WriteLine("I have logged into CRM application");
        }

        [Given(@"I have access to view claims (.*)")]
        public void GivenIHaveAccessToViewClaims(string Tab)
        {
            //GivenIAmOnTheClaimDetailsPageOfAnyExistingClaim(Tab);

            Report.WriteLine("I am on the Claims List Page");
            Click(attributeName_id, ClaimsIcon_Id);
            VerifyElementPresent(attributeName_xpath, ClaimsListPage_HeaderText_Xpath, "Claims List");

            //Click(attributeName_xpath, ClaimsList_OpenCheckbox_xpath);
            Click(attributeName_xpath, ClaimsList_PendingCheckbox_xpath);

            if (Tab == "FTL")
            {
                tab = "FTL-Tab";
                SendKeys(attributeName_xpath, ClaimListSearchTextBox_xpath, ftl_ClaimNumber1.ToString());
                Click(attributeName_xpath, ClaimsList_FirstVal_DLSWClaimNumber_stationUser_xpath);
                GlobalVariables.webDriver.WaitForPageLoad();
                scrollElementIntoView(attributeName_xpath, ClaimDetailsPage_Header_Xpath);
                Verifytext(attributeName_xpath, ClaimDetailsPage_Header_Xpath, "Claim Details");

            }
            else
            {
                tab = "Forwarding-Tab";
                SendKeys(attributeName_xpath, ClaimListSearchTextBox_xpath, forwarding_ClaimNumber.ToString());
                Click(attributeName_xpath, ClaimsList_FirstVal_DLSWClaimNumber_stationUser_xpath);
                GlobalVariables.webDriver.WaitForPageLoad();
                scrollPageup();
                scrollPageup();
                // scrollElementIntoView(attributeName_xpath, ClaimDetailsPage_Header_Xpath);
                Verifytext(attributeName_xpath, ClaimDetailsPage_Header_Xpath, "Claim Details");
            }
        }

        [Then(@"All fields will be displayed with the previously edited and saved values")]
        public void ThenAllFieldsWillBeDisplayedWithThePreviouslyEditedAndSavedValues()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            scrollPageup();
            scrollPageup();
            //Header section
            string ui_DLSW_ClaimRep = Gettext(attributeName_xpath, DlswClaimRep_dropdown_ClaimDetailsPage_Xpath);
            string ui_stationname = Gettext(attributeName_xpath, Station_Dropdown_ClaimDetailsPage_Xpath);
            string ui_DLSW_Ref = GetAttribute(attributeName_id, DlswRefNumber_Textbox_ClaimDetailsPage_Id, "value");
            string ui_claimant = GetAttribute(attributeName_id, Claimant_Value_ClaimDetails_Id, "value");
            string ui_claimReason = Gettext(attributeName_xpath, ClaimReason_Dropdown_ClaimDetailsPage_Xpath);
            string ui_carrierName = Gettext(attributeName_xpath, CarrierName_Dropdown_ClaimDetailsPage_Xpath);
            string ui_carrierPRO = GetAttribute(attributeName_id, CarrierPro_Textbox_ClaimDetailsPage_Id, "value");
            string ui_insured = Gettext(attributeName_xpath, Insured_Dropdown_ClaimDetailsPage_Xpath);

            Assert.AreEqual(DLSW_ClaimRep, ui_DLSW_ClaimRep);
            Report.WriteLine("Edited field DLSW_ClaimRep is binded");
            Assert.AreEqual(stationname, ui_stationname);
            Report.WriteLine("Edited field station name is binded");
            Assert.AreEqual(DLSW_Ref, ui_DLSW_Ref);
            Report.WriteLine("Edited field DLSW_Ref is binded");
            Assert.AreEqual(claimant, ui_claimant);
            Report.WriteLine("Edited field claimant is binded");
            Assert.AreEqual(claimReason, ui_claimReason);
            Report.WriteLine("Edited field claimReason is binded");
            Assert.AreEqual(carrierName, ui_carrierName);
            Report.WriteLine("Edited field carrierName is binded");
            Assert.AreEqual(carrierPRO, ui_carrierPRO);
            Report.WriteLine("Edited field carrierPRO is binded");
            Assert.AreEqual(insured, ui_insured);
            Report.WriteLine("Edited field insured is binded");

            scrollpagedown();
            //FTL- Specific fields
            if (tab == "FTL-Tab")
            {

                string ui_carrierMC = GetAttribute(attributeName_id, Carrier_MC_Id, "value");
                string ui_sealIntact = Gettext(attributeName_xpath, SealIntact_Xpath);
                string ui_seal = GetAttribute(attributeName_id, Seal_Number_Id, "value");
                string ui_vehicle = GetAttribute(attributeName_id, VehicleNumber_Id, "value");

                Assert.AreEqual(carrierMC, ui_carrierMC);
                Report.WriteLine("Edited field carrierMC is binded");
                Assert.AreEqual(sealIntact, ui_sealIntact);
                Report.WriteLine("Edited field sealIntact is binded");
                Assert.AreEqual(seal, ui_seal);
                Report.WriteLine("Edited field seal is binded");
                Assert.AreEqual(vehicle, ui_vehicle);
                Report.WriteLine("Edited field vehicle is binded");
            }

            //Forwarding - Specific fields
            else
            {
                string ui_airline = Gettext(attributeName_xpath, airlineDropdown_Xpath);
                string ui_pickupCarrier = Gettext(attributeName_xpath, pickupCarrierDropdown_Xpath);
                string ui_deliveryCarrier = Gettext(attributeName_xpath, deliveryCarrierDropdown_Xpath);
                string ui_steamshipLine = Gettext(attributeName_xpath, steamShipLineDropdown_Xpath);
                string ui_freightForwarder = Gettext(attributeName_xpath, freightForwarderDropdown_Xpath);
                string ui_whiteGloveAgent = Gettext(attributeName_xpath, whiteGloveAgentDropdown_Xpath);

                Assert.AreEqual(airline, ui_airline);
                Report.WriteLine("Edited field airline is binded");
                Assert.AreEqual(pickupCarrier, ui_pickupCarrier);
                Report.WriteLine("Edited field pickupCarrier is binded");
                Assert.AreEqual(deliveryCarrier, ui_deliveryCarrier);
                Report.WriteLine("Edited field deliveryCarrier is binded");
                Assert.AreEqual(steamshipLine, ui_steamshipLine);
                Report.WriteLine("Edited field steamshipLine is binded");
                Assert.AreEqual(freightForwarder, ui_freightForwarder);
                Report.WriteLine("Edited field freightForwarder is binded");
                Assert.AreEqual(whiteGloveAgent, ui_whiteGloveAgent);
                Report.WriteLine("Edited field whiteGloveAgent is binded");
            }

            scrollpagedown();
            //Shipper       
            string ui_shipperName = GetAttribute(attributeName_xpath, DetailsTab_Edit_Shipper_Name_Xpath, "value");
            string ui_shipperAddress = GetAttribute(attributeName_xpath, DetailsTab_Edit_Shipper_Address_Xpath, "value");
            string ui_shipperZip = GetAttribute(attributeName_xpath, DetailsTab_Edit_Shipper_Zip_Postal_Xpath, "value");
            string ui_shipperCity = GetAttribute(attributeName_xpath, DetailsTab_Edit_Shipper_City_Xpath, "value");
            string ui_shipperCountry = Gettext(attributeName_xpath, DetailsTab_Edit_Shipper_Country_Xpath);
            string ui_shipperState = Gettext(attributeName_xpath, DetailsTab_Edit_Shipper_State_Province_Click_Xpath);
            string ui_dateAcktoClaimant = GetAttribute(attributeName_id, DetailsTab_Edit_Shipper_DateAckToClaimant_Click_Id, "data-oldvalue");
            string ui_dateFiledw_carrier = GetAttribute(attributeName_id, DetailsTab_Edit_Shipper_DateFiled_W_Carrier_click_Id, "data-oldvalue");
            string ui_program = Gettext(attributeName_xpath, DetailsTab_Edit_Shipper_Program_Click_Xpath);
            string ui_amount = GetAttribute(attributeName_id, DetailsTab_Edit_Shipper_Amount_Id, "value");
            string ui_company = Gettext(attributeName_xpath, DetailsTab_Edit_Shipper_Company_Click_Xpath);

            Assert.AreEqual(shipperName, ui_shipperName);
            Report.WriteLine("Edited field shipperName is binded");
            Assert.AreEqual(shipperAddress, ui_shipperAddress);
            Report.WriteLine("Edited field shipperAddress is binded");
            Assert.AreEqual(shipperZip, ui_shipperZip);
            Report.WriteLine("Edited field shipperZip is binded");
            Assert.AreEqual(shipperCity, ui_shipperCity);
            Report.WriteLine("Edited field shipperCity is binded");
            Assert.AreEqual(shipperCountry, ui_shipperCountry);
            Report.WriteLine("Edited field shipperCountry is binded");
            Assert.AreEqual(shipperState, ui_shipperState);
            Report.WriteLine("Edited field shipperState is binded");
            Assert.AreEqual(dateAcktoClaimant, ui_dateAcktoClaimant);
            Report.WriteLine("Edited field dateAcktoClaimant is binded");
            Assert.AreEqual(dateFiledw_carrier, ui_dateFiledw_carrier);
            Report.WriteLine("Edited field dateFiledw_carrier is binded");
            Assert.AreEqual(program, ui_program);
            Report.WriteLine("Edited field program is binded");
            string ui_Amt = ui_amount.Replace(",", "");
            string uiAmount = ui_Amt.Remove(0, 1);
            Assert.AreEqual(amount, uiAmount);
            Report.WriteLine("Edited field amount is binded");
            Assert.AreEqual(company, ui_company);
            Report.WriteLine("Edited field company is binded");

            scrollpagedown();
            scrollpagedown();
            //Consignee        
            string ui_consigneeName = GetAttribute(attributeName_id, Consignee_Name_Id, "value");
            string ui_consigneeAddress = GetAttribute(attributeName_id, Consignee_Address_Id, "value");
            string ui_consigneeZip = GetAttribute(attributeName_id, Consignee_Zip_Id, "value");
            string ui_consigneeCity = GetAttribute(attributeName_id, Consignee_City_Id, "value");
            string ui_consigneeCountry = Gettext(attributeName_xpath, Consignee_Country_Xpath);
            string ui_consigneeState = Gettext(attributeName_xpath, Consignee_StateDropdown_Xpath);
            string ui_carrierAck = Gettext(attributeName_xpath, CarrierOSDActions_CarrierAck_Xpath);
            string ui_carrierAckDate = GetAttribute(attributeName_id, CarrierOSDActions_CarrierAckDate_Id, "data-oldvalue");
            string ui_carrierClaim = GetAttribute(attributeName_id, CarrierOSDActions_CarrierClaimNumber_Id, "data-oldvalue");
            string ui_carrierPRODate = GetAttribute(attributeName_id, KeyDates_CarrierProDate_Id, "data-oldvalue");
            string ui_bolShipDate = GetAttribute(attributeName_id, KeyDates_BOLDate_Id, "data-oldvalue");
            string ui_deliveryDate = GetAttribute(attributeName_id, KeyDates_DeliveryDate_Id, "data-oldvalue");
            string ui_remarks = Gettext(attributeName_id, Remarks_Id);

            Assert.AreEqual(consigneeName, ui_consigneeName);
            Report.WriteLine("Edited field consigneeName is binded");
            Assert.AreEqual(consigneeAddress, ui_consigneeAddress);
            Report.WriteLine("Edited field consigneeAddress is binded");
            Assert.AreEqual(consigneeZip, ui_consigneeZip);
            Report.WriteLine("Edited field consigneeZip is binded");
            Assert.AreEqual(consigneeCity, ui_consigneeCity);
            Report.WriteLine("Edited field consigneeCity is binded");
            Assert.AreEqual(consigneeCountry, ui_consigneeCountry);
            Report.WriteLine("Edited field consigneeCountry is binded");
            Assert.AreEqual(consigneeState, ui_consigneeState);
            Report.WriteLine("Edited field consigneeState is binded");
            Assert.AreEqual(carrierAck, ui_carrierAck);
            Report.WriteLine("Edited field carrierAck is binded");
            Assert.AreEqual(carrierAckDate, ui_carrierAckDate);
            Report.WriteLine("Edited field carrierAckDate is binded");
            Assert.AreEqual(carrierClaim, ui_carrierClaim);
            Report.WriteLine("Edited field carrierClaim is binded");
            Assert.AreEqual(carrierPRODate, ui_carrierPRODate);
            Report.WriteLine("Edited field carrierPRODate is binded");
            Assert.AreEqual(bolShipDate, ui_bolShipDate);
            Report.WriteLine("Edited field bolShipDate is binded");
            Assert.AreEqual(deliveryDate, ui_deliveryDate);
            Report.WriteLine("Edited field deliveryDate is binded");
            Assert.AreEqual(remarks, ui_remarks);
            Report.WriteLine("Edited field remarks is binded");

            scrollpagedown();
            //Product Claimed
            string ui_clmType = Gettext(attributeName_xpath, ProductClaimed_CLMTYP_Value_Xpath);
            string ui_artType = Gettext(attributeName_xpath, ProductClaimed_ARTTYP_Value_Xpath);
            string ui_qty = GetAttribute(attributeName_id, ProductClaimed_QTY_Id, "value");
            string ui_item = GetAttribute(attributeName_id, ProductClaimed_ITEM_Id, "value");
            string ui_desc = GetAttribute(attributeName_id, ProductClaimed_DESC_Id, "value");
            string ui_unitWT = GetAttribute(attributeName_id, ProductClaimed_UNITWGT_Id, "value");
            string ui_unitValue = GetAttribute(attributeName_id, ProductClaimed_UNITVAL_Id, "value");
            string ui_totalShipmentWeight = GetValue(attributeName_id, TotalShipmentWeightValue_id, "data-oldvalue");

            Assert.AreEqual(clmType, ui_clmType);
            Report.WriteLine("Edited field clmType is binded");
            Assert.AreEqual(artType, ui_artType);
            Report.WriteLine("Edited field artType is binded");
            string uiqty = ui_qty.Replace(",", "");
            Assert.AreEqual(qty, uiqty);
            Report.WriteLine("Edited field qty is binded");
            Assert.AreEqual(item, ui_item);
            Report.WriteLine("Edited field item is binded");
            Assert.AreEqual(desc, ui_desc);
            Report.WriteLine("Edited field description is binded");
            Assert.AreEqual(unitWT, ui_unitWT);
            Report.WriteLine("Edited field unitWT is binded");
            string uiValue = ui_unitValue.Remove(0, 1);
            Assert.AreEqual(unitValue, uiValue);
            Report.WriteLine("Edited field unitValue is binded");
            //Assert.AreEqual(totalShipmentWeight, ui_totalShipmentWeight);
            Report.WriteLine("Edited field totalShipmentWeight is binded");

            scrollpagedown();
            scrollpagedown();
            //Freight Calculations
            //Original Type
            string ui_o_ClaimedFreight = GetAttribute(attributeName_id, ClaimedFreight_Textbox_Original_Id, "value");
            string ui_o_CarrierChargestoDLSW = GetAttribute(attributeName_id, CarrierChargesToDLSW_Textbox_Original_Id, "value");
            string ui_o_DLSWChargestoCust = GetAttribute(attributeName_id, DLSWChargesToCust_Textbox_Original_Id, "value");
            string ui_o_DLSWRef = GetAttribute(attributeName_id, DLSWRefNumeber_Textbox_Original_Id, "value");

            Assert.AreEqual(o_ClaimedFreight, ui_o_ClaimedFreight.Remove(0, 1));
            Report.WriteLine("Edited field Original ClaimedFreight is binded");
            Assert.AreEqual(o_CarrierChargestoDLSW, ui_o_CarrierChargestoDLSW.Remove(0, 1));
            Report.WriteLine("Edited field Original CarrierChargestoDLSW is binded");
            Assert.AreEqual(o_DLSWChargestoCust, ui_o_DLSWChargestoCust.Remove(0, 1));
            Report.WriteLine("Edited field Original DLSWChargestoCust is binded");
            Assert.AreEqual(DLSW_Ref, ui_o_DLSWRef);
            Report.WriteLine("Original DLSWRef should bind in Original DLSWREF field");

            //Return Type
            string ui_ret_ClaimedFreight = GetAttribute(attributeName_id, ClaimedFreight_Textbox_Return_Id, "value");
            string ui_ret_CarrierChargestoDLSW = GetAttribute(attributeName_id, CarrierChargesToDLSW_Textbox_Return_Id, "value");
            string ui_ret_DLSWChargestoCust = GetAttribute(attributeName_id, DLSWChargesToCust_Textbox_Return_Id, "value");
            string ui_ret_DLSWRef = GetAttribute(attributeName_id, DLSWRefNumeber_Textbox_Return_Id, "value");

            Assert.AreEqual(ret_ClaimedFreight, ui_ret_ClaimedFreight.Remove(0, 1));
            Report.WriteLine("Edited field Return ClaimedFreight is binded");
            Assert.AreEqual(ret_CarrierChargestoDLSW, ui_ret_CarrierChargestoDLSW.Remove(0, 1));
            Report.WriteLine("Edited field Return CarrierChargestoDLSW is binded");
            Assert.AreEqual(ret_DLSWChargestoCust, ui_ret_DLSWChargestoCust.Remove(0, 1));
            Report.WriteLine("Edited field Return DLSWChargestoCust is binded");
            Assert.AreEqual(ret_DLSWRef, ui_ret_DLSWRef);
            Report.WriteLine("Edited field Return DLSWREF is binded");

            //Replacement
            string ui_rep_ClaimedFreight = GetAttribute(attributeName_id, ClaimedFreight_Textbox_Replacement_Id, "value");
            string ui_rep_CarrierChargestoDLSW = GetAttribute(attributeName_id, CarrierChargesToDLSW_Textbox_Replacement_Id, "value");
            string ui_rep_DLSWChargestoCust = GetAttribute(attributeName_id, DLSWChargesToCust_Textbox_Replacement_Id, "value");
            string ui_rep_DLSWRef = GetAttribute(attributeName_id, DLSWRefNumeber_Textbox_Replacement_Id, "value");

            Assert.AreEqual(rep_ClaimedFreight, ui_rep_ClaimedFreight.Remove(0, 1));
            Report.WriteLine("Edited field Replacement ClaimedFreight is binded");
            Assert.AreEqual(rep_CarrierChargestoDLSW, ui_rep_CarrierChargestoDLSW.Remove(0, 1));
            Report.WriteLine("Edited field Replacement CarrierChargestoDLSW is binded");
            Assert.AreEqual(rep_DLSWChargestoCust, ui_rep_DLSWChargestoCust.Remove(0, 1));
            Report.WriteLine("Edited field Replacement DLSWChargestoCust is binded");
            Assert.AreEqual(rep_DLSWRef, ui_rep_DLSWRef);
            Report.WriteLine("Edited field Replacement DLSWREF is binded");

            //Comments
            string comments = "Claim All fields checked";
            string ui_comments = Gettext(attributeName_id, DetailsTab_CommentsSection_Edit_id);
            Assert.AreEqual(comments, ui_comments);
            Report.WriteLine("Edited field Comments is binded");

        }

        [When(@"I click the Submit Claim button")]
        public void WhenIClickTheSubmitClaimButton()
        {
            Click(attributeName_id, SubmitClaimButton_Id);
            Report.WriteLine("Clicked on Submit Claim button");
            GlobalVariables.webDriver.WaitForPageLoad();
            
            //To get the claim number of the claim submitted from the DB
            ClaimNumber = DBHelper.GetClaimNumber();            
        }

        [Then(@"the claimed item\(s\) and freight charge\(s\) will be saved to the Claim Details page per the attached mapping document")]
        public void ThenTheClaimedItemSAndFreightChargeSWillBeSavedToTheClaimDetailsPagePerTheAttachedMappingDocument()
        {
            //Search for the Claim generated under Claim list page
            Report.WriteLine("Search for the claim created");
            Click(attributeName_xpath, ClaimsListSearchField_xpath);
            SendKeys(attributeName_xpath, ClaimsListSearchField_xpath, ClaimNumber.ToString());

            //Clicking on claim number to display the Claim details page
            if (loggedInUserType == "Sales" || loggedInUserType == "Internal")
            {
                Click(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']//tr[1]/td[4]/span/a");
            }            
            else
            {
                Click(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']//tr[1]/td[3]/span/a");
            }
            GlobalVariables.webDriver.WaitForPageLoad();

            //Asserting the values for the field under claimed item(s) and freight charge(s) section
            //Claimed item(s) section - Item 1                       
            string act_clmType = Gettext(attributeName_xpath, ".//*[@id='CLMTypeDropdown_0_chosen']//span");
            string ui_artType = Gettext(attributeName_xpath, ".//*[@id='ArticleTypeDropdown_0_chosen']//span");
            string ui_qty = GetAttribute(attributeName_xpath, ".//tbody[@class = 'ProductClaimBinding']/tr[1]//input[@id = 'QTY']", "value");
            string ui_item = GetAttribute(attributeName_xpath, ".//tbody[@class = 'ProductClaimBinding']/tr[1]//input[@id = 'ITEM#']", "value");
            string ui_desc = GetAttribute(attributeName_xpath, ".//tbody[@class = 'ProductClaimBinding']/tr[1]//input[@id = 'DESC']", "value");
            string ui_unitWT = GetAttribute(attributeName_xpath, ".//tbody[@class = 'ProductClaimBinding']/tr[1]//input[@id = 'UNITWGT']", "value");
            string ui_unitValue = GetAttribute(attributeName_xpath, ".//tbody[@class = 'ProductClaimBinding']/tr[1]//input[@id = 'UNITVAL']", "value");
            string ui_unitExtWT = GetAttribute(attributeName_xpath, ".//tbody[@class = 'ProductClaimBinding']/tr[1]//input[@id = 'EXTWGT']", "value");
            string ui_unitExtValue = GetAttribute(attributeName_xpath, ".//tbody[@class = 'ProductClaimBinding']/tr[1]//input[@id = 'EXTVAL']", "value");            
            
            Assert.AreEqual(clmType, act_clmType);
            Assert.AreEqual(artType, ui_artType);
            ui_qty = ui_qty.Replace(",", "");
            Assert.AreEqual(qty, ui_qty);
            Assert.AreEqual(desc, ui_item);
            Assert.AreEqual("Description - Claimed Articles - Item 1", ui_desc);
            Assert.AreEqual(unitWT, ui_unitWT);
            ui_unitValue = ui_unitValue.Remove(0, 1);
            Assert.AreEqual(unitValue, ui_unitValue);
            Report.WriteLine("All values for Item 1 matches");

            //Claimed item(s) section - Item 2                       
            string act_clmTypeItem2 = Gettext(attributeName_xpath, ".//*[@id = 'CLMTypeDropdown_1_chosen']//span");
            string ui_artTypeItem2 = Gettext(attributeName_xpath, ".//*[@id='ArticleTypeDropdown_1_chosen']//span");
            string ui_qtyItem2 = GetAttribute(attributeName_xpath, ".//tbody[@class = 'ProductClaimBinding']/tr[2]//input[@id = 'QTY']", "value");
            string ui_itemItem2 = GetAttribute(attributeName_xpath, ".//tbody[@class = 'ProductClaimBinding']/tr[2]//input[@id = 'ITEM#']", "value");
            string ui_descItem2 = GetAttribute(attributeName_xpath, ".//tbody[@class = 'ProductClaimBinding']/tr[2]//input[@id = 'DESC']", "value");
            string ui_unitWTItem2 = GetAttribute(attributeName_xpath, ".//tbody[@class = 'ProductClaimBinding']/tr[2]//input[@id = 'UNITWGT']", "value");
            string ui_unitValueItem2 = GetAttribute(attributeName_xpath, ".//tbody[@class = 'ProductClaimBinding']/tr[2]//input[@id = 'UNITVAL']", "value");
            string ui_unitExtWTItem2 = GetAttribute(attributeName_xpath, ".//tbody[@class = 'ProductClaimBinding']/tr[2]//input[@id = 'EXTWGT']", "value");
            string ui_unitExtValueItem2 = GetAttribute(attributeName_xpath, ".//tbody[@class = 'ProductClaimBinding']/tr[2]//input[@id = 'EXTVAL']", "value");

            Assert.AreEqual(clmTypeItem2, act_clmTypeItem2);
            Assert.AreEqual(artTypeItem2, ui_artTypeItem2);
            ui_qtyItem2 = ui_qtyItem2.Replace(",", "");
            Assert.AreEqual(qtyItem2, ui_qtyItem2);
            Assert.AreEqual(descItem2, ui_itemItem2);
            Assert.AreEqual("Description - Claimed Articles - Item 2", ui_descItem2);
            Assert.AreEqual(unitWTItem2, ui_unitWTItem2);
            ui_unitValueItem2 = ui_unitValueItem2.Remove(0, 1);
            Assert.AreEqual(unitValueItem2, ui_unitValueItem2);
            Report.WriteLine("All vaues for Item 2 macthes");

            //Total UI values in Claim details (Quantity, Weight and ExtWeight)
            string ui_TTL_PCS = Gettext(attributeName_xpath, TotalPcs_Xpath);
            string ui_TTL_WGT = Gettext(attributeName_id, TotalWgt_id);
            ui_TTL_WGT = ui_TTL_WGT.Replace(",", "");
            
            string ui_TTL_VAL = Gettext(attributeName_xpath, Totalval_Xpath);
            ui_TTL_VAL = ui_TTL_VAL.Replace(",", "");
            ui_TTL_VAL = ui_TTL_VAL.Remove(0, 1);

            //Total expected values in double format (Quantity, Weight and ExtWeight)
            double TTL_PCS;            
            double.TryParse(qty, out double QtyItem1);            
            double.TryParse(qtyItem2, out double QtyItem2);
            TTL_PCS = QtyItem1 + QtyItem2;

            double TTL_WGT;            
            double.TryParse(unitWT, out double WgtItem1);
            double.TryParse(unitWTItem2, out double WgtItem2);
            
            TTL_WGT = (WgtItem1 * QtyItem1) + (WgtItem2 * QtyItem2);

            double TTL_VAL;
            double.TryParse(unitValue, out double unitValItem1);
            double.TryParse(unitValueItem2, out double unitValItem2);
            double ExtValItem1 = unitValItem1 * QtyItem1;
            double ExtValItem2 = unitValItem2 * QtyItem2;
            TTL_VAL = ExtValItem1 + ExtValItem2;

            //Comparing UI Total values
            Assert.AreEqual(TTL_PCS.ToString(), ui_TTL_PCS);
            Assert.AreEqual(TTL_WGT.ToString()+".00", ui_TTL_WGT);
            Assert.AreEqual(TTL_VAL.ToString()+".00", ui_TTL_VAL);
            Report.WriteLine("Total Values are correct");

            //Comparing Freight Calculations section
            string ui_OriginalType = Gettext(attributeName_xpath, ".//div[@id ='ORIGINALCLAIMABLE_chosen']/a/span");
            string ui_ReturnType = Gettext(attributeName_xpath, ".//div[@id ='RETURNCLAIMABLE_chosen']/a/span");
            string ui_ReplacementType = Gettext(attributeName_xpath, ".//div[@id ='REPLACEMENTCLAIMABLE_chosen']/a/span");

            if(isChecked_OriginalFreightCharges && ui_OriginalType == "Y") //Checking OriginalFrieghtCharges type
            {
                Report.WriteLine("Original Type selection matches");
                string ui_OriginalClaimedFreightVal = GetAttribute(attributeName_id, "ORIGINALCLAIMEDFREIGHT", "value");
                ui_OriginalClaimedFreightVal = ui_OriginalClaimedFreightVal.Remove(0, 1);
                Assert.AreEqual(o_ClaimedFreight, ui_OriginalClaimedFreightVal);
            }
            if (isChecked_RetFreightCharges && ui_ReturnType == "Y") //Checking ReturnFrieghtCharges type
            {
                Report.WriteLine("Return Type selection matches");
                string ui_ReturnClaimedFreightVal = GetAttribute(attributeName_id, "RETURNCLAIMEDFREIGHT", "value");
                ui_ReturnClaimedFreightVal = ui_ReturnClaimedFreightVal.Remove(0, 1);
                Assert.AreEqual(ret_ClaimedFreight, ui_ReturnClaimedFreightVal);
            }
            if (isChecked_RepFreightCharges && ui_ReplacementType == "Y") //Checking ReplacementFrieghtCharges type
            {
                Report.WriteLine("Replacement Type selection matches");
                string ui_ReplacementClaimedFreightVal = GetAttribute(attributeName_id, "REPLACEMENTFREIGHT", "value");
                ui_ReplacementClaimedFreightVal = ui_ReplacementClaimedFreightVal.Remove(0, 1);
                Assert.AreEqual(rep_ClaimedFreight, ui_ReplacementClaimedFreightVal);                
            }

            //Comparing Sub total All Claimed Value with TOTAL CLAIMED FREIGHT
            string ui_TotalClaimedFreight = Gettext(attributeName_xpath, ".//*[@class = 'totalClaimedlbl']");
            Assert.AreEqual(subTotalAllClaimValues, ui_TotalClaimedFreight);
            Report.WriteLine("TOTAL CLAIMED FREIGHT in Claim details matches Sub total All Claimed Value in Submit a Claim page");

        }

    }
}
