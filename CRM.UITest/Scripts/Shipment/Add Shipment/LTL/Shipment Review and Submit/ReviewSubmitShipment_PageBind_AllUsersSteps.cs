using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Information_Screen;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Review_and_Submit
{
    [Binding]
    public class ReviewSubmitShipment_PageBind_AllUsersSteps : AddShipments
    {
        public string EstCostOfCarrier;
        public string QuoteNumber;
        public string EstCostOfCarrier_ShipmentResults;
        public string EstCostOfCarrier_ReviewAndSubmitPage;

        [Given(@"I am a DLS user and Login into application as a Station Owner")]
        public void GivenIAmADLSUserAndLoginIntoApplicationAsAStationOwner()
        {
            string userName = ConfigurationManager.AppSettings["InternalUserLogin"].ToString();
            string password = ConfigurationManager.AppSettings["InternalUserPassword"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(userName, password);
            Report.WriteLine("I logged into CRM application as Station Owner");
        }

        [Given(@"I create a Quote (.*)")]
        public void GivenICreateAQuote(string CustomerName)
        {
            Report.WriteLine("Clicked on Quotes icon");
            Click(attributeName_xpath, QuoteIcon_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();

            Report.WriteLine("Select Customer Name from the dropdown list");
            Click(attributeName_xpath, QuoteCustomerSelectionDropdown_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_xpath, QuoteCustomerSelectionDropdownSearchTextBox_Xpath, CustomerName);
            IList<IWebElement> CustomerDropDownList = GlobalVariables.webDriver.FindElements(By.XPath(QuoteCustomerSelectioDropdownValues_Xpath));
            int CustomerDropDownCount = CustomerDropDownList.Count;
            for (int i = 0; i < CustomerDropDownCount; i++)
            {
                if (CustomerDropDownList[i].Text == CustomerName)
                {
                    CustomerDropDownList[i].Click();
                    break;
                }
            }

            Report.WriteLine("Clicked on Submit Rate Request button");
            Click(attributeName_id, SubmitRateRequestBtn_id);
            GlobalVariables.webDriver.WaitForPageLoad();

            Report.WriteLine("Clicked on LTL tile");
            Click(attributeName_id, GetQuote_Ltlimage_id);
            GlobalVariables.webDriver.WaitForPageLoad();

            Report.WriteLine("Clicked on View Quote Results button");
            Click(attributeName_id, LTL_ViewQuoteResults_Id);            
            GlobalVariables.webDriver.WaitForPageLoad();            

            Report.WriteLine("Noted down Estimated cost of the Carrier");
            EstCostOfCarrier = Gettext(attributeName_xpath, QuoteResults_EstCost_FirstCarriervaluec_xpath);

            Report.WriteLine("Selected a carrier and clicked on Save Rate As Quote link");
            Click(attributeName_xpath, ltlsaverateasquotelnkint_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();

            Report.WriteLine("Search the Quote that was created and click on Create Shipment");
            QuoteNumber = Gettext(attributeName_id, QC_RequestNumber_id);
            Click(attributeName_xpath, QuoteIcon_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_xpath, QuoteList_Search_Xpath, QuoteNumber);
            Click(attributeName_xpath, QuoteExpandIcon_Xpath);
            WaitForElementVisible(attributeName_xpath, QuoteCreateShipment_Xpath, "Create Shipment");
            Click(attributeName_xpath, QuoteCreateShipment_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
        }
        
        [When(@"I navigate to Review and Submit page of the Shipment created from the Quote")]
        public void WhenINavigateToReviewAndSubmitPageOfTheShipmentCreatedFromTheQuote()
        {
            SendKeys(attributeName_id, ReferenceNumbers_BOLNumber_Id, "12345678");
            SendKeys(attributeName_id, ReferenceNumbers_DeliveryApptNumber_Id, "12345678");
            SendKeys(attributeName_id, "ltl-reference-num-1", "12345678");
            SendKeys(attributeName_id, "ltl-reference-num-2", "12345678");

            Report.WriteLine("Clicked on View rates on Add Shipment LTL page");
            Click(attributeName_xpath, Shipment_viewresults_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();

            Click(attributeName_id, QuoteCreateShipment_Id);
            GlobalVariables.webDriver.WaitForPageLoad();

            Report.WriteLine("Note down estimated cost for the carrier in Review And Submit page");
            EstCostOfCarrier_ReviewAndSubmitPage = Gettext(attributeName_xpath, ReviewSubmit_CarrierInfo_EstCost_Value_Xpath);
        }

        [When(@"I navigate to the Shipment Rate Results page by creating Shipment from the quote created and")]
        public void WhenINavigateToTheShipmentRateResultsPageByCreatingShipmentFromTheQuoteCreatedAnd()
        {
            SendKeys(attributeName_id, ReferenceNumbers_BOLNumber_Id, "12345678");
            SendKeys(attributeName_id, ReferenceNumbers_DeliveryApptNumber_Id, "12345678");
            SendKeys(attributeName_id, "ltl-reference-num-1", "12345678");
            SendKeys(attributeName_id, "ltl-reference-num-2", "12345678");

            Report.WriteLine("Clicked on View rates on Add Shipment LTL page");
            Click(attributeName_xpath, Shipment_viewresults_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();

            Report.WriteLine("Note down the estimated cost for the carrier in Shipment Results page");
            EstCostOfCarrier_ShipmentResults = Gettext(attributeName_xpath, ShipResults_Internal_EstColumnValues_Xpath);
        }        

        [Then(@"Est Cost value for Shipment in the Review And Submit page should match the Est Cost of the Carrier selected")]
        public void ThenEstCostValueForShipmentInTheReviewAndSubmitPageShouldMatchTheEstCostOfTheCarrierSelected()
        {
            EstCostOfCarrier = EstCostOfCarrier.Replace("*", "");
            EstCostOfCarrier = EstCostOfCarrier.Replace(" ", "");
            if(EstCostOfCarrier_ReviewAndSubmitPage == EstCostOfCarrier)
            {
                Report.WriteLine("Est Cost Value in the Review And Submit page properly binds the Est cost of the Carrier selected");
            }
            else
            {
                Report.WriteFailure("Est Cost Value in the Shipment Rate Results page doesn't properly bind the Est cost of the Carrier selected");
            }
        }


        [Then(@"Est Cost value in the Shipment Rate Results page for Shipment should match the Est Cost of the Carrier selected")]
        public void ThenEstCostValueInTheShipmentRateResultsPageForShipmentShouldMatchTheEstCostOfTheCarrierSelected()
        {
            EstCostOfCarrier = EstCostOfCarrier.Replace("*", "");
            EstCostOfCarrier = EstCostOfCarrier.Replace(" ", "");
            if(EstCostOfCarrier_ShipmentResults == EstCostOfCarrier)
            {
                Report.WriteLine("Est Cost Value in the Shipment Rate Results page properly binds the Est cost of the Carrier selected");
            }
            else
            {
                Report.WriteFailure("Est Cost Value in the Shipment Rate Results page doesn't properly bind the Est cost of the Carrier selected");
            }
        }

        [Given(@"I enter data in required fields in add shipment page  (.*), (.*), (.*),(.*), (.*), (.*),(.*),(.*), (.*),(.*), (.*), (.*), (.*)")]
        public void GivenIEnterDataInRequiredFieldsInAddShipmentPage(string Usertype,
            string CustomerName, string oZip, string oName, string oAdd, string dZip, string dName, string dAdd,
            string classification, string nmfc, string quantity, string weight, string desc)
        {
            Report.WriteLine("Click on shipment icon");
            AddShipmentLTL data = new AddShipmentLTL();
            data.NaviagteToShipmentList();
            data.SelectCustomerFromShipmentList(Usertype, CustomerName);
            data.AddShipmentOriginData(oName, oAdd, oZip);
            data.AddShipmentDestinationData(dName, dAdd, dZip);
            scrollElementIntoView(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            Click(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            data.AddShipmentFreightDescription(classification, nmfc, quantity, weight, desc);
        }

        [Given(@"I click on Create Shipment button (.*)")]
        public void GivenIClickOnCreateShipmentButton(string userType)
        {
            Report.WriteLine("Clicked on Create Shipment button");
            AddShipmentLTL data = new AddShipmentLTL();
            data.ClickOnCreateShipmentButton(userType);
        }

        [Given(@"I click on Submit Shipment button")]
        public void GivenIClickOnSubmitShipmentButton()
        {
            Report.WriteLine("Clicked on Submit Shipment button");
            Click(attributeName_xpath, ReviewAndSubmit_SubmitShipment_button_Xpath);
        }

        [Given(@"I Click on Create Shipment button for any carrier (.*)")]
        public void GivenIClickOnCreateShipmentButtonForAnyCarrierInternal(string userType)
        {
            Report.WriteLine("Clicked on Create Shipment");
            AddShipmentLTL data = new AddShipmentLTL();
            data.ClickOnCreateShipmentButton(userType);
        }

        [When(@"I click on create shipment button for any carrier (.*)")]
        public void WhenIClickOnCreateShipmentButtonForAnyCarrier(string userType)
        {
            Report.WriteLine("Getting the total count of carrier dispalying in results page");            
            AddShipmentLTL data = new AddShipmentLTL();
            data.ClickOnCreateShipmentButton(userType);
        }

        [Given(@"I click on view rates button in add shipment button")]
        public void GivenIClickOnViewRatesButtonInAddShipmentButton()
        {
            AddShipmentLTL data = new AddShipmentLTL();
            data.ClickViewRates();
        }
        
        
        [Given(@"I pass data in remaining fields (.*), (.*),(.*), (.*),(.*), (.*),(.*), (.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void GivenIPassDataInRemainingFields(string ShipFromName, string ShipFromPhone, string ShipFromEmail, 
            string ShipFromFax, string ShipToName, string ShipToPhone, string ShipToEmail, string ShipToFax, 
            string ReadyTime, string ReadyClose, string UNNumb, string CCNNumb, string Group, string HClass, 
            string HConNmame, string HPhone, string DefaultSpecialIns, string InsAmount, string InsType)
        {
            AddShipmentLTL contData = new AddShipmentLTL();
            scrollPageup();
            Click(attributeName_xpath, ShippingFrom_ContactInfo_Expand_xpath);
            contData.AddShippingFromContactSection(ShipFromName, ShipFromPhone, ShipFromEmail, ShipFromFax);
            Click(attributeName_xpath, ShippingTo_ContactInfo_Expand_xpath);
            contData.AddShippingToContactSection(ShipToName, ShipToPhone, ShipToEmail, ShipToFax);

            Report.WriteLine("Select Pickup date Ready time");
            Click(attributeName_xpath, LTL_PickUpReadyTime_Xpath);
            VerifyElementVisible(attributeName_xpath, LTL_PickUpReadyTimeDropdown_Xpath, "Ready Time");
            SelectDropdownValueFromList(attributeName_xpath, LTL_PickUpReadyTimeDropdown_Xpath, ReadyTime);
            Report.WriteLine("PickUp date Close time");
            Thread.Sleep(5000);
            Click(attributeName_xpath, LTL_PickUpCloseTime_Xpath);
            VerifyElementVisible(attributeName_xpath, LTL_PickUpCloseTimeDropdown_Xpath, "Close Time");
            SelectDropdownValueFromList(attributeName_xpath, LTL_PickUpCloseTimeDropdown_Xpath, ReadyClose);

            Report.WriteLine("Passind data in first item hazmat section");
            contData.PassHazmatDetailsforFirstItem(UNNumb, CCNNumb, HClass,Group, HConNmame, HPhone);

            Report.WriteLine("Passing data in insured section");
            SendKeys(attributeName_id, InsuredValue_TextBox_Id, InsAmount);
            Click(attributeName_xpath, InsuredValue_Type_xpath);
            SelectDropdownValueFromList(attributeName_xpath, InsuredValue_Type_Values_xpath, InsType);

            Report.WriteLine("Passing data in special instructions field");
            SendKeys(attributeName_id, DefaultSpecialIntructions_Comments_Id, DefaultSpecialIns);
        }

        [Given(@"I pass data in reference section (.*), (.*), (.*), (.*)")]
        public void GivenIPassDataInReferenceSection(string ref1, string ref2, string movType, string locType)
        {
            Report.WriteLine("Passing data in reference section");
            scrollElementIntoView(attributeName_xpath, ReferenceNumbers_ExpandSection_xpath);
            Click(attributeName_xpath, ReferenceNumbers_ExpandSection_xpath);
            SendKeys(attributeName_id, ReferenceNumbers_PONumber_Id, ref1);
            SendKeys(attributeName_id, ReferenceNumbers_OrderNumber_Id, ref2);
            Click(attributeName_xpath, ReferenceNumbers_MoveType_DropDown_xpath);
            SelectDropdownValueFromList(attributeName_xpath, ReferenceNumbers_MoveType_DropDown_Values_xpath, movType);
            Click(attributeName_xpath, ReferenceNumbers_InventoryLocationType_DropDown_xpath);
            SelectDropdownValueFromList(attributeName_xpath, ReferenceNumbers_InventoryLocationType_DropDown_Values_xpath, locType);
        }
        
        [Then(@"entered data in shipment information page should be displayed in review and submit page (.*), (.*),(.*), (.*), (.*),(.*),(.*),(.*),(.*), (.*), (.*), (.*)")]
        public void ThenEnteredDataInShipmentInformationPageShouldBeDisplayedInReviewAndSubmitPage(string CustomerName,
            string oZip, string oName, string oAdd, string dZip, string dName, string dAdd, 
            string classification, string nmfc, string quantity, string weight, string desc)
        {
            Report.WriteLine("Verifying the data in review and submit page present in shipping from section");
            string actOName = Gettext(attributeName_xpath, ReviewSubmit_ShippingFrom_Name_Xpath);
            Assert.AreEqual(actOName, oName);
            Report.WriteLine("Entered data in add shipment page " + oName + " is displaying in review and submit page " + actOName);

            string actOAdd = Gettext(attributeName_xpath, ReviewSubmit_ShippingFrom_Address_Xpath);
            Assert.AreEqual(actOAdd, oAdd);
            Report.WriteLine("Entered data in add shipment page " + oAdd + " is displaying in review and submit page " + actOAdd);

            string actOZip = Gettext(attributeName_xpath, ReviewSubmit_ShippingFrom_ZIP_Xpath);
            Assert.AreEqual(actOZip, oZip);
            Report.WriteLine("Entered data in add shipment page " + oZip + " is displaying in review and submit page " + actOZip);

            Report.WriteLine("Verifying the data in review and submit page present in shipping To section");
            string actDName = Gettext(attributeName_xpath, ReviewSubmit_ShippingTo_Name_Xpath);
            Assert.AreEqual(actDName, dName);
            Report.WriteLine("Entered data in add shipment page " + oName + " is displaying in review and submit page " + actDName);

            string actDAdd = Gettext(attributeName_xpath, ReviewSubmit_ShippingTo_Address_Xpath);
            Assert.AreEqual(actDAdd, dAdd);
            Report.WriteLine("Entered data in add shipment page " + oAdd + " is displaying in review and submit page " + actDAdd);

            string actDZip = Gettext(attributeName_xpath, ReviewSubmit_ShippingTo_ZIP_Xpath);
            Assert.AreEqual(actDZip, dZip);
            Report.WriteLine("Entered data in add shipment page " + oZip + " is displaying in review and submit page " + actDZip);

            Report.WriteLine("Verifying the data in review and submit page present in item section");
            string actQuantity = Gettext(attributeName_xpath, ReviewSubmit_FreightDescription_Quantity_Xpath);
            string[] QuanValues = actQuantity.Split(' ');
            Assert.AreEqual(QuanValues[0], quantity);
            Report.WriteLine("Entered data in add shipment page " + quantity + " is displaying in review and submit page " + actQuantity);

            string actWeight = Gettext(attributeName_xpath, ReviewSubmit_FreightDescription_Weight_Xpath);
            string[] WeiValues = actWeight.Split(' ');
            Assert.AreEqual(WeiValues[0], weight);
            Report.WriteLine("Entered data in add shipment page " + weight + " is displaying in review and submit page " + actWeight);

            string actClass = Gettext(attributeName_xpath, ReviewSubmit_FreightDescription_Class_Xpath);
            Assert.AreEqual(actClass, classification);
            Report.WriteLine("Entered data in add shipment page " + classification + " is displaying in review and submit page " + actClass);

            string actDesc = Gettext(attributeName_xpath, ReviewSubmit_FreightDescription_Description_Xpath);
            Assert.AreEqual(actDesc, desc);
            Report.WriteLine("Entered data in add shipment page " + desc + " is displaying in review and submit page " + actDesc);

            string actNmfc = Gettext(attributeName_xpath, ReviewSubmit_FreightDescription_NMFC_Xpath);
            Assert.AreEqual(actNmfc, nmfc);
            Report.WriteLine("Entered data in add shipment page " + nmfc + " is displaying in review and submit page " + actNmfc);
        }

        [Then(@"entered optional data should be displayed in review and submit page   (.*), (.*),(.*), (.*),(.*), (.*),(.*), (.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void ThenEnteredOptionalDataShouldBeDisplayedInReviewAndSubmitPage(string ShipFromName, string ShipFromPhone, string ShipFromEmail,
            string ShipFromFax, string ShipToName, string ShipToPhone, string ShipToEmail, string ShipToFax,
            string ReadyTime, string CloseTime, string UNNumb, string CCNNumb, string Group, string HClass,
            string HConNmame, string HPhone, string DefaultSpecialIns, string InsAmount, string InsType)
        {
            //------------------------verifying the data in shipping from section------------
            Report.WriteLine("Verifying the data in review and submit page present in shipping from contact section");
            string actShpFromName = Gettext(attributeName_xpath, ReviewSubmit_ShippingFromContactInfo_Name_Xpath);
            Assert.AreEqual(actShpFromName, ShipFromName);
            Report.WriteLine("Entered data in add shipment page " + ShipFromName + " is displaying in review and submit page " + actShpFromName);

            string actShpFromPhn = Gettext(attributeName_xpath, ReviewSubmit_ShippingFromContactinfo_Phone_Xpath);
            Assert.AreEqual(actShpFromPhn, ShipFromPhone);
            Report.WriteLine("Entered data in add shipment page " + ShipFromPhone + " is displaying in review and submit page " + actShpFromPhn);

            string actShpFromEmail = Gettext(attributeName_xpath, ReviewSubmit_ShippingFromContactinfo_Email_Xpath);
            Assert.AreEqual(ShipFromEmail, actShpFromEmail);
            Report.WriteLine("Entered data in add shipment page " + ShipFromEmail + " is displaying in review and submit page " + actShpFromEmail);

            string actShpFromFax = Gettext(attributeName_xpath, ReviewSubmit_ShippingFromContactinfo_Fax_Xpath);
            Assert.AreEqual(ShipFromFax, actShpFromFax);
            Report.WriteLine("Entered data in add shipment page " + ShipFromFax + " is displaying in review and submit page " + actShpFromFax);

            //----------------------Verifying the data in shipping to section---------------------------------------
            Report.WriteLine("Verifying the data in review and submit page present in shipping to contact section");
            string actShpToName = Gettext(attributeName_xpath, ReviewSubmit_ShippingToContactInfo_Name_Xpath);
            Assert.AreEqual(ShipToName, actShpToName);
            Report.WriteLine("Entered data in add shipment page " + ShipToName + " is displaying in review and submit page " + actShpToName);

            string actShpToPhn = Gettext(attributeName_xpath, ReviewSubmit_ShippingToContactinfo_Phone_Xpath);
            Assert.AreEqual(actShpToPhn, ShipToPhone);
            Report.WriteLine("Entered data in add shipment page " + ShipToPhone + " is displaying in review and submit page " + actShpToPhn);

            string actShpToEmail = Gettext(attributeName_xpath, ReviewSubmit_ShippingToContactinfo_Email_Xpath);
            Assert.AreEqual(ShipToEmail, actShpToEmail);
            Report.WriteLine("Entered data in add shipment page " + ShipToEmail + " is displaying in review and submit page " + actShpToEmail);

            string actShpToFax = Gettext(attributeName_xpath, ReviewSubmit_ShippingToContactinfo_Fax_Xpath);
            Assert.AreEqual(ShipToFax, actShpToFax);
            Report.WriteLine("Entered data in add shipment page " + ShipToFax + " is displaying in review and submit page " + actShpToFax);

            //------------------------Verifying data in ready and close time-------------------------------------
            Report.WriteLine("Verifying the data in review and submit page present for ready and close");
            string actReadyTime = Gettext(attributeName_xpath, ReviewSubmit_PickupDate_Ready_Xpath);
            Assert.AreEqual("Ready "+ ReadyTime, actReadyTime);
            Report.WriteLine("Entered data in add shipment page " + ReadyTime + " is displaying in review and submit page " + actReadyTime);

            string actCloseTime = Gettext(attributeName_xpath, ReviewSubmit_PickupDate_Close_Xpath);
            Assert.AreEqual("Close "+ CloseTime, actCloseTime);
            Report.WriteLine("Entered data in add shipment page " + CloseTime + " is displaying in review and submit page " + actCloseTime);

            //------------------------Verifying data first time hazmat section-------------------------------------
            Report.WriteLine("Verifying the data in review and submit page present for hazmat item section");
            string actUNNumb = Gettext(attributeName_xpath, ReviewSubmit_FreightDescription_HazMat_UNNumberValue_Xpath);
            Assert.AreEqual(UNNumb, actUNNumb);
            Report.WriteLine("Entered data in add shipment page " + UNNumb + " is displaying in review and submit page " + actUNNumb);

            string actCCNNumb = Gettext(attributeName_xpath, ReviewSubmit_FreightDescription_HazMat_CCNNumberValue_Xpath);
            actCCNNumb.Contains("CCN#" + CCNNumb);
            Report.WriteLine("Entered data in add shipment page " + CCNNumb + " is displaying in review and submit page " + actCCNNumb);

            string actGroup = Gettext(attributeName_xpath, ReviewSubmit_FreightDescription_HazMat_PackageGroupValue_Xpath);
            Assert.AreEqual(Group, actGroup);
            Report.WriteLine("Entered data in add shipment page " + Group + " is displaying in review and submit page " + actGroup);

            string actClass = Gettext(attributeName_xpath, ReviewSubmit_FreightDescription_HazMat_ClassValue_Xpath);
            Assert.AreEqual(HClass, actClass);
            Report.WriteLine("Entered data in add shipment page " + HClass + " is displaying in review and submit page " + actClass);

            string actCName = Gettext(attributeName_xpath, ReviewSubmit_FreightDescription_HazMat_ContactNameValue_Xpath);
            Assert.AreEqual(HConNmame, actCName);
            Report.WriteLine("Entered data in add shipment page " + HConNmame + " is displaying in review and submit page " + actCName);

            string actHPhone = Gettext(attributeName_xpath, ReviewSubmit_FreightDescription_HazMat_PhoneValue_Xpath);
            Assert.AreEqual(HPhone, actHPhone);
            Report.WriteLine("Entered data in add shipment page " + HPhone + " is displaying in review and submit page " + actHPhone);

            //------------------------Verifying data in special instructions section-------------------------------------
            Report.WriteLine("Verifying the data in review and submit page present for hazmat item section");
            string actSpcInst = Gettext(attributeName_xpath, ReviewSubmit_DefaultSpecialInstruction_Instruction_Xpath);
            Assert.AreEqual(DefaultSpecialIns, actSpcInst);
            Report.WriteLine("Entered data in add shipment page " + DefaultSpecialIns + " is displaying in review and submit page " + actSpcInst);

            //------------------------Verifying data in insured section section-------------------------------------
            Report.WriteLine("Verifying the data in review and submit page present for hazmat item section");
            string actInsAmount = Gettext(attributeName_xpath, ReviewSubmit_InsuredValue_Value_Xpath);
            actInsAmount.Contains(InsAmount);
        }

        [Then(@"I reference data should be displayed in review and submit page (.*), (.*), (.*), (.*)")]
        public void ThenIReferenceDataShouldBeDisplayedInReviewAndSubmitPage(string ref1, string ref2, string movType, string locType)
        {
            //------------------------Verifying data in reference number section-------------------------------------
            Report.WriteLine("Verifying the data in review and submit page present for hazmat item section");
            string actRef1 = Gettext(attributeName_xpath, ReviewSubmit_FirstReference_Value_Xpath);
            string[] refvalue = actRef1.Split(':');
            Assert.AreEqual(refvalue[1].Trim(), ref1);
            Report.WriteLine("Entered data in add shipment page " + ref1 + " is displaying in review and submit page " + refvalue[1].Trim());

            string actRef2 = Gettext(attributeName_xpath, ReviewSubmit_SecondReference_Value_Xpath);
            string[] ref2value = actRef2.Split(':');
            Assert.AreEqual(ref2, ref2value[1].Trim());
            Report.WriteLine("Entered data in add shipment page " + ref2 + " is displaying in review and submit page " + ref2value[1].Trim());

        }
       
        [Then(@"selected carrier section CarrierName, LiabilityInformation, EstServiceDays>, Distance, EstRevenue, EstCost should be displayed in review and submit page (.*)")]
        public void ThenSelectedCarrierSectionCarrierNameLiabilityInformationEstServiceDaysDistanceEstRevenueEstCostShouldBeDisplayedInReviewAndSubmitPage(string userType)
        {

            AddShipmentLTL data = new AddShipmentLTL();
            string excCarrierName = Gettext(attributeName_xpath, ShipResults_FC_CarrierName_Xpath);
            string excServiceDays = Gettext(attributeName_xpath, ShipResults_FC_ServiceDays_Xpath);
            string excDistance = Gettext(attributeName_xpath, ShipResults_FC_Distance_Xpath);
            string excTotal = Gettext(attributeName_xpath, ShipResults_InternalFC_Total_Xpath);
            string excFuel = Gettext(attributeName_xpath, ShipResults_InternalFC_Fuel_Xpath);
            string excLineHaul = Gettext(attributeName_xpath, ShipResults_InternalFC_Linehaul_Xpath);
            string excAcc = Gettext(attributeName_xpath, ShipResults_InternalFC_Accessories_Xpath);
            string excEstCost = Gettext(attributeName_xpath, ShipResults_FC_EstCost_Xpath);
            string excMargin = Gettext(attributeName_xpath, ShipResults_InternalFC_Margin_Xpath);
            data.ClickOnCreateShipmentButton(userType);

            Report.WriteLine("Verifying the carrier section for the customer users");
            string actCarrierName = Gettext(attributeName_xpath, ReviewSubmit_InternalCarrierInfo_CarrierName_Xpath);
            Assert.AreEqual(excCarrierName, actCarrierName);
            Report.WriteLine("Selected carrier in the results page" + excCarrierName + " is displaying in review and submit page" + actCarrierName);

            string actServicedays = Gettext(attributeName_xpath, ReviewSubmit_CarrierInfo_EstimatedServiceDays_Xpath);
            string[] actServiceValues = actServicedays.Split(':');
            Assert.AreEqual(excServiceDays, actServiceValues[1].Replace("\r\n", string.Empty));

            string actDistance = Gettext(attributeName_xpath, ReviewSubmit_CarrierInfo_Distance_Value_Xpath);
            Assert.AreEqual(excDistance, actDistance);

            string actTotal = Gettext(attributeName_xpath, ReviewSubmit_CarrierInfo_EstRevenue_Value_Xpath);
            Assert.AreEqual(excTotal, actTotal);

            string actFuel = Gettext(attributeName_xpath, ReviewSubmit_CarrierInfo_EstRevenue_FuelValue_Xpath);
            string[] excFuelValue = excFuel.Split(':');
            Assert.AreEqual(excFuelValue[1].Trim(), actFuel);

            string actLineHaul = Gettext(attributeName_xpath, ReviewSubmit_CarrierInfo_EstRevenue_LineHaulValue_Xpath);
            string[] excLineHaulValue = excLineHaul.Split(':');
            Assert.AreEqual(excLineHaulValue[1].Trim(), actLineHaul);

            string actAcc = Gettext(attributeName_xpath, ReviewSubmit_CarrierInfo_EstRevenue_AccessorialValue_Xpath);
            string[] excAccValue = excAcc.Split(':');
            Assert.AreEqual(excAccValue[1].Trim(), actAcc);
            
            string actEstCost = Gettext(attributeName_xpath, ReviewSubmit_CarrierInfo_EstCost_Value_Xpath);
            Assert.AreEqual(excEstCost, actEstCost);
            
            string actMargin = Gettext(attributeName_xpath, ReviewSubmit_CarrierInfo_EstMargin_Value_Xpath);
            string[] excMarValue = excMargin.Split(':');
            Assert.AreEqual(excMarValue[1].Trim(), actMargin.Replace(" ",string.Empty));
        }

        [Then(@"selected carrier section CarrierName, LiabilityInformation, EstServiceDays, Distance, EstCost should be displayed in review and submit page (.*)")]
        public void ThenSelectedCarrierSectionCarrierNameLiabilityInformationEstServiceDaysDistanceEstCostShouldBeDisplayedInReviewAndSubmitPage(string userType)
        {

            AddShipmentLTL data = new AddShipmentLTL();
            string excCarrierName = Gettext(attributeName_xpath, ShipResults_FC_CarrierName_Xpath);
            string excServiceDays = Gettext(attributeName_xpath, ShipResults_FC_ServiceDays_Xpath);
            string excDistance = Gettext(attributeName_xpath, ShipResults_FC_Distance_Xpath);
            string excTotal = Gettext(attributeName_xpath, ShipResults_FC_Total_Xpath);
            string excFuel = Gettext(attributeName_xpath, ShipResults_FC_Fuel_Xpath);
            string excLineHaul = Gettext(attributeName_xpath, ShipResults_FC_Linehaul_Xpath);
            string excAcc = Gettext(attributeName_xpath, ShipResults_FC_Accessories_Xpath);
            data.ClickOnCreateShipmentButton(userType);

            Report.WriteLine("Verifying the carrier section for the customer users");
            string actCarrierName = Gettext(attributeName_xpath, ReviewSubmit_CarrierInfo_CarrierName_Xpath);
            Assert.AreEqual(excCarrierName, actCarrierName);
            Report.WriteLine("Selected carrier in the results page" + excCarrierName + " is displaying in review and submit page" + actCarrierName);

            string actServicedays = Gettext(attributeName_xpath, ReviewSubmit_CarrierInfo_EstimatedServiceDays_Xpath);
            string[] actServiceValues = actServicedays.Split(':');
            Assert.AreEqual(excServiceDays, actServiceValues[1].Replace("\r\n", string.Empty));

            string actDistance = Gettext(attributeName_xpath, ReviewSubmit_CarrierInfo_Distance_Value_Xpath);
            Assert.AreEqual(excDistance, actDistance);

            string actTotal = Gettext(attributeName_xpath, ReviewSubmit_CarrierInfo_EstRevenue_Value_Xpath);
            Assert.AreEqual(excTotal, actTotal);

            string actFuel = Gettext(attributeName_xpath, ReviewSubmit_CarrierInfo_EstRevenue_FuelValue_Xpath);
            string[] excFuelValue = excFuel.Split(':');
            Assert.AreEqual(excFuelValue[1].Trim(), actFuel);

            string actLineHaul = Gettext(attributeName_xpath, ReviewSubmit_CarrierInfo_EstRevenue_LineHaulValue_Xpath);
            string[] excLineHaulValue = excLineHaul.Split(':');
            Assert.AreEqual(excLineHaulValue[1].Trim(), actLineHaul);

            string actAcc = Gettext(attributeName_xpath, ReviewSubmit_CarrierInfo_EstRevenue_AccessorialValue_Xpath);
            string[] excAccValue = excAcc.Split(':');
            Assert.AreEqual(excAccValue[1].Trim(), actAcc);
        }
    }
}
