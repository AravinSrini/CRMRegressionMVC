using System;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Threading;

namespace CRM.UITest.Scripts.Insurance_Claims.Claim_Details
{
    [Binding]
    public class InsuranceClaims_ClaimDetails_SaveClaimDetailsButtonSteps : InsuranceClaim
    {
        string carrierType = "FTL";
        Customer_Invoice customerInvoice = new Customer_Invoice();

        [Given(@"I am on Claim Details page")]
        public void GivenIAmOnClaimDetailsPage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, ClaimsListPage_HeaderText_Xpath, "Claims List");
            string claimListGridData = Gettext(attributeName_xpath, ClaimListGridDataCount_Xpath);
            if (claimListGridData == "No Results Found")
            {
                Report.WriteLine("No Claims List found in the Grid");
                throw new Exception("No datas found in the Claim List Grid");
            }
            else
            {
                Report.WriteLine("Clicking on the Claim Number");
                Click(attributeName_xpath, ClaimSpecilistFirstClaimNumber_ClaimsListGrid_Xpath);
                GlobalVariables.webDriver.WaitForPageLoad();
            }
        }

        [Given(@"I have updated the fields of Claim Header, FTL-Specific Fields, Forwarding-Specific Fields")]
        public void GivenIHaveUpdatedTheFieldsOfClaimHeaderFTL_SpecificFieldsForwarding_SpecificFields()
        {
            Click(attributeName_xpath, shipmentMode_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, ClaimDetailsModeDropdown_Xpath, carrierType);

            Click(attributeName_xpath, DlswClaimRep_dropdown_ClaimDetailsPage_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, DlswClaimRep_DropdownValues_ClaimDetailsPage_Xpath, "Daksha Parekh");

            Click(attributeName_xpath, Station_Dropdown_ClaimDetailsPage_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, Station_DropdownValues_ClaimDetailsPage_Xpath, "ABC");

            SendKeys(attributeName_id, DlswRefNumber_Textbox_ClaimDetailsPage_Id, "32423");
            SendKeys(attributeName_id, Claimant_Textbox_ClaimDetailsPage_Id, "Test");

            Click(attributeName_xpath, ClaimReason_Dropdown_ClaimDetailsPage_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, ClaimReason_DropdownValues_ClaimDetailsPage_Xpath, "Accident in Transit");

            Click(attributeName_xpath, CarrierName_Dropdown_ClaimDetailsPage_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, CarrierName_DropdownValues_ClaimDetailsPage_Xpath, "R & L Carriers");

            SendKeys(attributeName_id, CarrierPro_Textbox_ClaimDetailsPage_Id, "2311");
            Click(attributeName_xpath, Insured_Dropdown_ClaimDetailsPage_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, Insured_DropdownValues_ClaimDetailsPage_Xpath, "N");
            Report.WriteLine("updated Claim Header fields");

            if (carrierType == "FTL")
            {                
                SendKeys(attributeName_id, Carrier_MC_Id, "1234");
                SendKeys(attributeName_id, Seal_Number_Id, "1234");
                SendKeys(attributeName_id, VehicleNumber_Id, "1234");
                Click(attributeName_xpath, SealIntact_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, SealIntactValues_Xpath, "Yes");
                Report.WriteLine("FTL specific fields updated");
            }
            else if (carrierType == "Forwarding")
            {
                scrollpagedown();
                Click(attributeName_xpath, airlineDropdown_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, airline_values_Xpath, "A & A X-Press, Inc.");

                Click(attributeName_xpath, deliveryCarrierDropdown_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, deliveryCarrier_values_Xpath, "Aim Transportation Services Llc");

                Click(attributeName_xpath, freightForwarderDropdown_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, freightForwarder_values_Xpath, "Chicago Suburban Express");

                Click(attributeName_xpath, pickupCarrierDropdown_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, pickupCarrier_values_Xpath, "BUCEPHAL USA LLC");

                Click(attributeName_xpath, steamShipLineDropdown_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, steamShipLine_values_Xpath, "Dependable Air Cargo Express");

                Click(attributeName_xpath, whiteGloveAgentDropdown_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, whiteGloveAgent_values_Xpath, "Hotline Delivery Systems");
                Report.WriteLine("Updated Forwarding Specific fields");
            }
            else
            {
                Report.WriteLine("No fileds to update, hence selected carrier type is LTL");
            }
        }

        [Given(@"I have updated the fields of Shipper, DLSW OS&D Actions, Insurance Info, Consignee, Carrier OS&D Actions, Key Dates, Remarks")]
        public void GivenIHaveUpdatedTheFieldsOfShipperDLSWOSDActionsInsuranceInfoConsigneeCarrierOSDActionsKeyDatesRemarks()
        {
            scrollpagedown();
            Click(attributeName_xpath, Shipper_Country_dropdown_Xpath);
            SendKeys(attributeName_xpath, Shipper_Country_TextBox_Xpath, "UNITED STATES");
            Click(attributeName_xpath, Shipper_Country_SelectingFirstHighlighted_Xpath);            
            SendKeys(attributeName_xpath, DetailsTab_Edit_Shipper_Name_Xpath, "Test");
            SendKeys(attributeName_xpath, DetailsTab_Edit_Shipper_Address_Xpath, "1000 windham parkway");
            SendKeys(attributeName_xpath, DetailsTab_Edit_Shipper_Zip_Postal_Xpath, "60490");            
            Report.WriteLine("updated the fields of Shipper Section");
            Thread.Sleep(1000);
            Click(attributeName_id, DetailsTab_Edit_Shipper_DateAckToClaimant_Click_Id);
            SendKeys(attributeName_id, DetailsTab_Edit_Shipper_DateAckToClaimant_Click_Id, Keys.Backspace);
            SendKeys(attributeName_id, DetailsTab_Edit_Shipper_DateAckToClaimant_Click_Id, "08/14/2018");
            Click(attributeName_xpath, DetailsTab_Edit_Shipper_Name_Xpath);
            Thread.Sleep(1000);
            Click(attributeName_id, DetailsTab_Edit_Shipper_DateFiled_W_Carrier_click_Id);
            SendKeys(attributeName_id, DetailsTab_Edit_Shipper_DateFiled_W_Carrier_click_Id, Keys.Backspace);
            SendKeys(attributeName_id, DetailsTab_Edit_Shipper_DateFiled_W_Carrier_click_Id, "08/14/2018");
            Click(attributeName_xpath, DetailsTab_Edit_Shipper_Name_Xpath);            
            Report.WriteLine("updated the fields of DLSW OS&D Actions Section");
            Thread.Sleep(1000);
            Click(attributeName_xpath, DetailsTab_Edit_Shipper_Program_Click_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, DetailsTab_Edit_Shipper_Program_ListAll_Xpath, "PPP");
            SendKeys(attributeName_id, DetailsTab_Edit_Shipper_Amount_Id, "123");

            Click(attributeName_xpath, DetailsTab_Edit_Shipper_Company_Click_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, DetailsTab_Edit_Shipper_Company_ListAll_Xpath, "RR Donnelley");
            Report.WriteLine("updated the fields of Insurance Info Section");
            Thread.Sleep(1000);
            scrollpagedown();
            Click(attributeName_xpath, Consignee_Country_dropdown_Xpath);
            SendKeys(attributeName_xpath, Consignee_Country_Textbox_Xpath, "UNITED STATES");
            Click(attributeName_xpath, Consignee_Country_SelectingFirstHighlighted_Xpath);            
            SendKeys(attributeName_id, Consignee_Name_Textbox_Id, "Test");
            SendKeys(attributeName_id, Consignee_Address_Textbox_Id, "1000 windham parkway");
            SendKeys(attributeName_id, Consignee_Zip_Postal_Textbox_Id, "60490");            
            Report.WriteLine("updated the fields of Consignee Section");
            Thread.Sleep(1000);
            Click(attributeName_xpath, CarrierOSDActions_CarrierAck_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, CarrierOSDActions_CarrierAckValues_Xpath, "Y");
            Thread.Sleep(1000);
            Click(attributeName_id, CarrierOSDActions_CarrierAckDate_Id);
            SendKeys(attributeName_id, CarrierOSDActions_CarrierAckDate_Id, Keys.Backspace);
            SendKeys(attributeName_id, CarrierOSDActions_CarrierAckDate_Id, "08/14/2018");
            Click(attributeName_id, Consignee_Name_Textbox_Id);

            SendKeys(attributeName_id, CarrierOSDActions_CarrierClaimNumber_Id, "1234");
            Report.WriteLine("updated the fields of Carrier OS&D Actions Section");

            Click(attributeName_id, KeyDates_CarrierProDate_Id);
            SendKeys(attributeName_id, KeyDates_CarrierProDate_Id, Keys.Backspace);
            SendKeys(attributeName_id, KeyDates_CarrierProDate_Id, "08/14/2018");
            Click(attributeName_id, Consignee_Name_Textbox_Id);
            Thread.Sleep(1000);
            Click(attributeName_id, KeyDates_BOLDate_Id);
            SendKeys(attributeName_id, KeyDates_BOLDate_Id, Keys.Backspace);
            SendKeys(attributeName_id, KeyDates_BOLDate_Id, "08/14/2018");
            Click(attributeName_id, Consignee_Name_Textbox_Id);
            Thread.Sleep(1000);
            Click(attributeName_id, KeyDates_BOLDate_Id);
            SendKeys(attributeName_id, KeyDates_DeliveryDate_Id, Keys.Backspace);
            SendKeys(attributeName_id, KeyDates_DeliveryDate_Id, "08/14/2018");
            Click(attributeName_id, Consignee_Name_Textbox_Id);
            Report.WriteLine("updated the fields of Key Dates Section");

            SendKeys(attributeName_id, Remarks_Id, "Testing Remarks Section");
            Report.WriteLine("updated Remarks field");
        }

        [Given(@"I have updated the fields of Products Claimed, Freight Calculations, Comments")]
        public void GivenIHaveUpdatedTheFieldsOfProductsClaimedFreightCalculationsComments()
        {
            scrollpagedown();
            Click(attributeName_xpath, addAnotherItembutton_xpath);
            Thread.Sleep(1000);
            Click(attributeName_xpath, FirstClaimType_xpath);
            SelectDropdownValueFromList(attributeName_xpath, claimtypevalues_xpath, "Shortage");
            Thread.Sleep(1000);
            Click(attributeName_xpath, FirstArticleType_xpath);
            SelectDropdownValueFromList(attributeName_xpath, ArticlesTypeValues_xpath, "New");

            SendKeys(attributeName_xpath, FirstQuantity_xpath, "12");
            SendKeys(attributeName_xpath, Firstitem_xpath, "Item1");
            SendKeys(attributeName_xpath, firstDescription_claimedarticles_xpath, "Description");
            SendKeys(attributeName_xpath, FirstUnitWgt_xpath, "123");
            SendKeys(attributeName_xpath, firstUnitval_xpath, "11");
            SendKeys(attributeName_xpath, totalshipmentvalue_xpath, "1111");
            Report.WriteLine("updated the fields of Products Claimed section");            
            scrollpagedown();
            Click(attributeName_xpath, Claimable_dropdown_Original_Xpath);
            Thread.Sleep(500);
            Click(attributeName_xpath, ".//*[@id='ORIGINALCLAIMABLE_chosen']//li[1]");
            //SelectDropdownValueFromList(attributeName_xpath, Claimable_dropdownValue_Original_Xpath, "Y");
            SendKeys(attributeName_id, ClaimedFreight_Textbox_Original_Id, "12");
            SendKeys(attributeName_id, CarrierChargesToDLSW_Textbox_Original_Id, "112");
            SendKeys(attributeName_id, DLSWChargesToCust_Textbox_Original_Id, "123");
            SendKeys(attributeName_id, DLSWRefNumeber_Textbox_Original_Id, "12");
            scrollpagedown();
            Click(attributeName_xpath, Claimabledropdown_Return_Xpath);
            Thread.Sleep(500);
            Click(attributeName_xpath, ".//*[@id='RETURNCLAIMABLE_chosen']//li[1]");
            //SelectDropdownValueFromList(attributeName_xpath, ClaimabledropdownValue_Return_Xpath, "Y");
            SendKeys(attributeName_id, ClaimedFreight_Textbox_Return_Id, "122");
            SendKeys(attributeName_id, CarrierChargesToDLSW_Textbox_Return_Id, "1312");
            SendKeys(attributeName_id, DLSWChargesToCust_Textbox_Return_Id, "1333");
            SendKeys(attributeName_id, DLSWRefNumeber_Textbox_Return_Id, "149");
                     
            Click(attributeName_xpath, Claimabledropdown_Replacement_Xpath);
            Thread.Sleep(500);
            Click(attributeName_xpath, ".//*[@id='REPLACEMENTCLAIMABLE_chosen']//li[1]");
            //SelectDropdownValueFromList(attributeName_xpath, ClaimabledropdownValue_Replacement_Xpath, "Y");
            SendKeys(attributeName_id, ClaimedFreight_Textbox_Replacement_Id, "46");
            SendKeys(attributeName_id, CarrierChargesToDLSW_Textbox_Replacement_Id, "222");
            SendKeys(attributeName_id, DLSWChargesToCust_Textbox_Replacement_Id, "1231");
            SendKeys(attributeName_id, DLSWRefNumeber_Textbox_Replacement_Id, "1233");
            Report.WriteLine("updated the fields of Freight Calculations section");

            SendKeys(attributeName_id, DetailsTab_CommentsSection_Edit_id, "Testing Save Claim Details button functionality on editing fields");
            Report.WriteLine("updated the comments section");
        }

        [Given(@"I have edited changes")]
        public void GivenIHaveEditedChanges()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, CarrierName_Dropdown_ClaimDetailsPage_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, CarrierName_DropdownValues_ClaimDetailsPage_Xpath, "Oak Harbor");
            Report.WriteLine("I have edited changes");
        }

        [Given(@"I click on any CRM module")]
        public void GivenIClickOnAnyCRMModule()
        {
            Click(attributeName_xpath, customerInvoice.customerInvoiceIcon_xpath);
            Report.WriteLine("Clicked on Customer Invoice Icon");
        }

        [When(@"I am on Claim Details page")]
        public void WhenIAmOnClaimDetailsPage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, ClaimsListPage_HeaderText_Xpath, "Claims List");
            string claimListGridData = Gettext(attributeName_xpath, ClaimListGridDataCount_Xpath);
            if (claimListGridData == "No Results Found")
            {
                Report.WriteLine("No Claims List found in the Grid");
                throw new Exception("No datas found in the Claim List Grid");
            }
            else
            {
                Report.WriteLine("Clicking on the Claim Number");
                Click(attributeName_xpath, ClaimSpecilistFirstClaimNumber_ClaimsListGrid_Xpath);
            }
        }

        [When(@"I click on Any CRM module")]
        public void WhenIClickOnAnyCRMModule()
        {
            Click(attributeName_xpath, customerInvoice.customerInvoiceIcon_xpath);
            Report.WriteLine("Clicked on another CRM module: Customer Invoice");
        }

        [When(@"I click on Leave Page Without Saving button on Changes Not Saved modal")]
        public void WhenIClickOnLeavePageWithoutSavingButtonOnChangesNotSavedModal()
        {
            WaitForElementVisible(attributeName_id, LeavePageWithoutSavingButton_Id, "Changes Not Saved");
            Click(attributeName_id, LeavePageWithoutSavingButton_Id);
            Report.WriteLine("Clicked on Leave Page Witout Saving button on Changes Not saved modal");
        }

        [When(@"I Click on Return to Claim Details button on Changes Not Saved modal")]
        public void WhenIClickOnReturnToClaimDetailsButtonOnChangesNotSavedModal()
        {
            WaitForElementVisible(attributeName_id, LeavePageWithoutSavingButton_Id, "Changes Not Saved");
            Click(attributeName_id, ReturnToClaimDetailsButton_Id);
            Report.WriteLine("Clicked on Return to Claim Details button on Changes Not saved modal");
        }

        [Then(@"I will see a Save Claim Details button")]
        public void ThenIWillSeeASaveClaimDetailsButton()
        {
            Report.WriteLine("I will be displayed with Save Claim Details button");
            VerifyElementVisible(attributeName_id, SaveClaimDetailsButton_Id, "SaveClaimDetails");
            string saveClaimDeatilsButton = Gettext(attributeName_id, SaveClaimDetailsButton_Id);
            Assert.AreEqual("Save Claim Details", saveClaimDeatilsButton.Replace("\r\n", " "));
        }

        [Then(@"Changes Not Saved modal will display with message")]
        public void ThenChangesNotSavedModalWillDisplayWithMessage()
        {
            string changesNotSavedMessage = "You have not saved your changes to the claim details. Would you like to save your changes before leaving this page?";
            string changesNotSavedNoteMessage = "Note: If you leave without saving you cannot get the changes back.";
            WaitForElementVisible(attributeName_xpath, ChangesNotSavedModal_Xpath, "Changes Not Saved");
            string changesNotSavedModalUIMessage = Gettext(attributeName_xpath, ChangesNotSavedModalText_Xpath);
            Assert.AreEqual(changesNotSavedMessage, changesNotSavedModalUIMessage);
            string changesNotSavedModalNoteUI = Gettext(attributeName_xpath, ChangesNotSavedModalNoteText_Xpath);
            Assert.AreEqual(changesNotSavedNoteMessage, changesNotSavedModalNoteUI);
            Report.WriteLine("Changes Not saved modal displayed with the message");
        }

        [Then(@"Leave Page Without Saving, Return to Claim Details buttons will be displayed in modal pop up")]
        public void ThenLeavePageWithoutSavingReturnToClaimDetailsButtonsWillBeDisplayedInModalPopUp()
        {
            VerifyElementVisible(attributeName_id, LeavePageWithoutSavingButton_Id, "Leave Page Without Saving");
            string leavePageWithOutSavingUI = Gettext(attributeName_id, LeavePageWithoutSavingButton_Id);
            Assert.AreEqual("Leave Page Without Saving", leavePageWithOutSavingUI);

            VerifyElementVisible(attributeName_id, ReturnToClaimDetailsButton_Id, "Return to Claim Details");
            string returnToClaimDetailsUI = Gettext(attributeName_id, ReturnToClaimDetailsButton_Id);
            Assert.AreEqual("Return to Claim Details", returnToClaimDetailsUI);
            Report.WriteLine("Leave Page Without Saving, Return to Claim Details buttons are displayed in modal pop up");
        }

        [Then(@"the modal will be closed")]
        public void ThenTheModalWillBeClosed()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementNotPresent(attributeName_xpath, ChangesNotSavedModal_Xpath, "Changes Not Saved");
            VerifyElementNotPresent(attributeName_xpath, ChangesNotSavedModal_Xpath, "Changes Not Saved");
            Report.WriteLine("Changes not saved modal closed and not visible");            
        }

        [Then(@"the model will be closed")]
        public void ThenTheModelWillBeClosed()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementNotVisible(attributeName_xpath, ChangesNotSavedModal_Xpath, "Changes Not Saved");
            VerifyElementNotVisible(attributeName_xpath, ChangesNotSavedModal_Xpath, "Changes Not Saved");
            Report.WriteLine("Changes not saved modal closed and not visible");
        }
        [Then(@"I will be navigated away from Claim Details Page")]
        public void ThenIWillBeNavigatedAwayFromClaimDetailsPage()
        {     
            VerifyElementVisible(attributeName_xpath, customerInvoice.customerInvoicesHeader_xpath, "Customer Invoices");
            Report.WriteLine("Navigated to Customer Invoices Page from Claim Details page");
        }

        [Then(@"I will be on Claim Details Page itself")]
        public void ThenIWillBeOnClaimDetailsPageItself()
        {            
            WaitForElementPresent(attributeName_xpath, ClaimDetailsPage_Header_Xpath, "Claim Details");
            VerifyElementPresent(attributeName_xpath, ClaimDetailsPage_Header_Xpath, "Claim Details");
            Report.WriteLine("User stayed on Claim Details page itself");
        }
    }
}
