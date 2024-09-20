using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Review_and_Submit
{
    [Binding]
    public class ReviewandSubmitShipment_PageElements_AllUsersSteps : AddShipments
    {
        CommonMethodsCrm crm = new CommonMethodsCrm();

        [Given(@"I am a operations, sales, sales management or station owner user (.*) (.*)")]
        public void GivenIAmAOperationsSalesSalesManagementOrStationOwnerUser(string Username, string Password)
        {
            crm.LoginToCRMApplication(Username, Password);
        }

        [When(@"I arrive on Review and Submit Shipment LTL page (.*)")]
        public void WhenIArriveOnReviewAndSubmitShipmentLTLPage(string Usertype)
        {
            Report.WriteLine("I arrive on review and submit page");
            if (Usertype == "Internal")
            {
                int carrierrowcount = GetCount(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr/td[1]/div");
                if (carrierrowcount > 1)
                {
                    Report.WriteLine("Click on the create shipment button");
                    Click(attributeName_xpath, ShipResults_Internal_CreateShipButton_xpath);

                    VerifyElementPresent(attributeName_xpath, ReviewAndSubmit_Title_Xpath, "Review and Submit Shipment(LTL)");

                }
                else
                {
                    Report.WriteLine("No list of carrier");
                }
            }
            else 
            {
                int carrierrowcount = GetCount(attributeName_xpath, ShipResults_FC_GuaranteedCarrierName_Xpath);
                if (carrierrowcount > 1)
                {
                    Report.WriteLine("Click on the create shipment button");
                    Click(attributeName_xpath, ShipResults_External_CreateShipButton_xpath);

                  
                    VerifyElementPresent(attributeName_xpath, ReviewAndSubmit_Title_Xpath, "Review and Submit Shipment(LTL)");

                }
                else
                {
                    Report.WriteLine("No list of carrier");
                }
            }
            
        }

        [Then(@"I verified (.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*) and fields on review and submit page")]
        public void ThenIVerifiedAndFieldsOnReviewAndSubmitPage(string shippingfrom, string shippingfromcontact_info, string shippingTo, string shippingTocontact_info, string pickupDate, string FreightDesc, string ReferenceNo, string DefaultSpecialInstruction, string InsuredValue, string carrierinfo)
        {
            Report.WriteLine("Verify the Shipping Info Section");
            string ExpectedSectionShipping = "Shipping Info";
            string ShippingINfo = Gettext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[1]/h4");
            Assert.AreEqual(ExpectedSectionShipping, ShippingINfo);

            Report.WriteLine("Verified the Shipping From Sections");
            string ShippingFromExpected = Gettext(attributeName_xpath, ReviewSubmit_Section_ShippingFrom_Xpath);
            Assert.AreEqual(shippingfrom, ShippingFromExpected);

            string ActualAccessorial = "Accessorials";
            string AccessorialExp = Gettext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[1]/div[1]/span[6]");
            string[] ExpectedAccessorials = AccessorialExp.Split(':');
            string AccessorialsLabel = ExpectedAccessorials[0];
            Assert.AreEqual(ActualAccessorial, AccessorialsLabel);

            string ActualComments = "Comments";
            string CommentsExp = Gettext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[1]/div[1]/span[7]");
            string[] ExpectedComments = CommentsExp.Split(':');
            string CommentsLabel = ExpectedComments[0];
            Assert.AreEqual(ActualComments, CommentsLabel);

            string ShippingFromContactsINfo = Gettext(attributeName_xpath, ReviewSubmit_Section_ShippingFromContactInfo_Xpath);
            Assert.AreEqual(shippingfromcontact_info, ShippingFromContactsINfo);

            string FromName = "Name";
            string FromNameText = Gettext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[1]/div[1]/span[8]");
            string[] ExpectedFromName = FromNameText.Split(':');
            string FromNameLabel = ExpectedFromName[0];
            Assert.AreEqual(FromName, FromNameLabel);

            string FromPhone = "Phone";
            string FromPhoneText = Gettext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[1]/div[1]/span[9]");
            string[] ExpectedFromPhone = FromPhoneText.Split(':');
            string FromPhoneLabel = ExpectedFromPhone[0];
            Assert.AreEqual(FromPhone, FromPhoneLabel);

            string FromEmail = "Email";
            string FromEmailText = Gettext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[1]/div[1]/span[10]");
            string[] ExpectedFromEmail = FromEmailText.Split(':');
            string FromEmailLabel = ExpectedFromEmail[0];
            Assert.AreEqual(FromEmail, FromEmailLabel);

            string FromFax = "FAX";
            string FromFaxText = Gettext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[1]/div[1]/span[11]");
            string[] ExpectedFromFax = FromFaxText.Split(':');
            string FromFaxLabel = ExpectedFromFax[0];
            Assert.AreEqual(FromFax, FromFaxLabel);





            Report.WriteLine("Verified the Shipping To Sections");
            string ShippingToExpected = Gettext(attributeName_xpath, ReviewSubmit_Section_ShippingTo_Xpath);
            Assert.AreEqual(shippingTo, ShippingToExpected);

            string ToActualAccessorial = "Accessorials";
            string ToAccessorialExp = Gettext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[1]/div[2]/span[6]");
            string[] ToExpectedAccessorials = ToAccessorialExp.Split(':');
            string ToAccessorialsLabel = ToExpectedAccessorials[0];
            Assert.AreEqual(ToActualAccessorial, ToAccessorialsLabel);

            string ToActualComments = "Comments";
            string ToCommentsExp = Gettext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[1]/div[1]/span[7]");
            string[] ToExpectedComments = ToCommentsExp.Split(':');
            string ToCommentsLabel = ToExpectedComments[0];
            Assert.AreEqual(ToActualComments, ToCommentsLabel);

            string ShippingToContactsINfo = Gettext(attributeName_xpath, ReviewSubmit_Section_ShippingToContactInfo_Xpath);
            Assert.AreEqual(shippingTocontact_info, ShippingToContactsINfo);

            string ToName = "Name";
            string ToNameText = Gettext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[1]/div[2]/span[8]");
            string[] ExpectedToName = FromNameText.Split(':');
            string ToNameLabel = ExpectedFromName[0];
            Assert.AreEqual(ToName, ToNameLabel);

            string ToPhone = "Phone";
            string ToPhoneText = Gettext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[1]/div[2]/span[9]");
            string[] ExpectedToPhone = ToPhoneText.Split(':');
            string ToPhoneLabel = ExpectedToPhone[0];
            Assert.AreEqual(ToPhone, ToPhoneLabel);

            string ToEmail = "Email";
            string ToEmailText = Gettext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[1]/div[2]/span[10]");
            string[] ExpectedToEmail = ToEmailText.Split(':');
            string ToEmailLabel = ExpectedToEmail[0];
            Assert.AreEqual(ToEmail, ToEmailLabel);

            string ToFax = "FAX";
            string ToFaxText = Gettext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[1]/div[2]/span[11]");
            string[] ExpectedToFax = ToFaxText.Split(':');
            string ToFaxLabel = ExpectedToFax[0];
            Assert.AreEqual(ToFax, ToFaxLabel);

            Report.WriteLine("Verify the Pickup date section");
            string PickupdateActual = Gettext(attributeName_xpath, ReviewSubmit_Section_PickupDate_Xpath);
            Assert.AreEqual(pickupDate, PickupdateActual);

            Report.WriteLine("Verify the Freight Description section");
            string FreightDescActual = Gettext(attributeName_xpath, ReviewSubmit_Section_FreightDescription_Xpath);
            Assert.AreEqual(FreightDesc, FreightDescActual);

            string FreightClass = "Class";
            string FreightClassText = Gettext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[5]/div/div/div/div[1]/div/div/div[1]/span");
            string[] ExpectedFreightClass = FreightClassText.Split(':');
            string FreightClassLabel = ExpectedFreightClass[0];
            Assert.AreEqual(FreightClass, FreightClassLabel);

            string FreightNMFC = "NMFC";
            string FreightNMFCText = Gettext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[5]/div/div/div/div[1]/div/div/div[2]/span");
            string[] ExpectedFreightNMFC = FreightNMFCText.Split(':');
            string FreightNMFCLabel = ExpectedFreightNMFC[0];
            Assert.AreEqual(FreightNMFC, FreightNMFCLabel);

            string FreightQuantity = "Quantity";
            string FreightQuantityText = Gettext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[5]/div/div/div/div[1]/div/div/div[3]/span");
            string[] ExpectedFreightQuantity = FreightQuantityText.Split(':');
            string FreightQuantityLabel = ExpectedFreightQuantity[0];
            Assert.AreEqual(FreightQuantity, FreightQuantityLabel);

            string FreightWeight = "Weight";
            string FreightWeightText = Gettext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[5]/div/div/div/div[1]/div/div/div[4]/span");
            string[] ExpectedFreightWeight = FreightWeightText.Split(':');
            string FreightWeightLabel = ExpectedFreightWeight[0];
            Assert.AreEqual(FreightWeight, FreightWeightLabel);

            string FreightHazmat = "Hazardous Materials";
            string FreightHazmatText = Gettext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[5]/div/div/div/div[2]/div/div/div/div/div[1]/span");
            string[] ExpectedFreightHazmat = FreightHazmatText.Split(':');
            string FreightHazmatLabel = ExpectedFreightHazmat[0];
            Assert.AreEqual(FreightHazmat, FreightHazmatLabel);

            string FreightLength = "Length";
            string FreightLengthText = Gettext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[5]/div/div/div/div[2]/div/div/div/div/div[2]/span");
            string[] ExpectedFreightLength = FreightLengthText.Split(':');
            string FreightLengthLabel = ExpectedFreightLength[0];
            Assert.AreEqual(FreightLength, FreightLengthLabel);

            string FreightWidth = "Width";
            string FreightWidthText = Gettext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[5]/div/div/div/div[2]/div/div/div/div/div[3]/span");
            string[] ExpectedFreightWidthText = FreightWidthText.Split(':');
            string FreightWidthTextLabel = ExpectedFreightWidthText[0];
            Assert.AreEqual(FreightWidth, FreightWidthTextLabel);

            string FreightDescription = "Description";
            string FreightDescriptionText = Gettext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[5]/div/div/div/div[3]/div/div/div/div/div/span");
            string[] ExpectedFreightDescriptionText = FreightDescriptionText.Split(':');
            string FreightDescriptionTextLabel = ExpectedFreightDescriptionText[0];
            Assert.AreEqual(FreightDescription, FreightDescriptionTextLabel);

            scrollElementIntoView(attributeName_xpath, ReviewSubmit_SubmitShipment_Button_Xpath);

            Report.WriteLine("Verify the Reference no section");
            string ReferenceNumberActual = Gettext(attributeName_xpath, ReviewSubmit_Section_ReferenceNumber_Xpath);
            Assert.AreEqual(ReferenceNo, ReferenceNumberActual);

            Report.WriteLine("Verify the Dafault special Instruction section");
            string DefaultSpecialInsActual = Gettext(attributeName_xpath, ReviewSubmit_Section_DefaultSpecialInstruction_Xpath);
            Assert.AreEqual(DefaultSpecialInstruction, DefaultSpecialInsActual);

            Report.WriteLine("Verify the Insured Value Section");
            string InsuredValueActual = Gettext(attributeName_xpath, ReviewSubmit_Section_InsuredValue_Xpath);
            Assert.AreEqual(InsuredValue, InsuredValueActual);

            Report.WriteLine("Verify the Carrier INfo Section");
            string CarrierInfoSectionActual = Gettext(attributeName_xpath, ReviewSubmit_Section_CarrierInfo_Xpath);
            Assert.AreEqual(carrierinfo, CarrierInfoSectionActual);

        }



        [Then(@"I will see the Edit Shipping Info button")]
        public void ThenIWillSeeTheEditShippingInfoButton()
        {
            ScrollToTopElement(attributeName_xpath, ReviewSubmit_EditShipment_Xpath);
            Report.WriteLine("Verify the Edit sipping info section");
            VerifyElementPresent(attributeName_xpath, ReviewSubmit_EditShipment_Xpath, "Shipping Info Edit Button");
        }

        [Then(@"I will see the Submit Shipment button")]
        public void ThenIWillSeeTheSubmitShipmentButton()
        {
            scrollElementIntoView(attributeName_xpath, ReviewSubmit_SubmitShipment_Button_Xpath);
            Report.WriteLine("Verify the Submit Shipment Page on Review and Submit Page");
            VerifyElementPresent(attributeName_xpath, ReviewSubmit_SubmitShipment_Button_Xpath,"Submit Shipment Button");
            
        }


        [Given(@"I select the Hazardous Materials as yes (.*),(.*),(.*),(.*),(.*),(.*)")]
        public void GivenISelectTheHazardousMaterialsAsYes(string UNnumber, string CCN, string hazmatPackaging_Group, string hazmat_class, string hazmat_contactName, string hazmat_Phoneno)
        {
            Report.WriteLine("Click on Hazmat Yes Radio Button");
            Click(attributeName_xpath, FreightDesp_FirstItem_Hazardous_Yes_RadioButton_xpath);

            Report.WriteLine("Enter the UN number");
            SendKeys(attributeName_id, FreightDesp_FirstItem_UN_Number_Id, UNnumber);

            Report.WriteLine("Enter the CCN number");
            SendKeys(attributeName_id, FreightDesp_FirstItem_CCN_Number_Id, CCN);

            Report.WriteLine("Select the Hazmat package group");
            Click(attributeName_xpath, FreightDesp_FirstItem_SelectHazmatPackageGroup_DownDown_xpath);
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(FreightDesp_FirstItem_SelectHazmatPackageGroup_DownDown_Values_xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == hazmatPackaging_Group)
                {
                    DropDownList[i].Click();
                    break;
                }
            }

            Report.WriteLine("Select the Hazmat Class ");
            Click(attributeName_xpath, FreightDesp_FirstItem_SelectHazmatClass_DropwDown_xpath);
            IList<IWebElement> DropDownListClass = GlobalVariables.webDriver.FindElements(By.XPath(FreightDesp_FirstItem_SelectHazmatClass_DropwDown_Values_xpath));
            int DropDownClassCount = DropDownListClass.Count;
            for (int i = 0; i < DropDownClassCount; i++)
            {
                if (DropDownListClass[i].Text == hazmat_class)
                {
                    DropDownListClass[i].Click();
                    break;
                }
            }

            Report.WriteLine("Enter the Hazmat Contact Name");
            SendKeys(attributeName_id, FreightDesp_FirstItem_EmergencyReponseContactName_Id, hazmat_contactName);

            Report.WriteLine("Enter the Hazmat Phone no ");
            SendKeys(attributeName_id, FreightDesp_FirstItem_EmergencyReponsePhoneNumber_Id, hazmat_Phoneno);

        }

        [Then(@"Verify I should see the (.*),(.*),(.*),(.*),(.*),(.*) of Hazardous Materials on review and submit page")]
        public void ThenVerifyIShouldSeeTheOfHazardousMaterialsOnReviewAndSubmitPage(string un_number, string ccn_number, string hazmat_package, string hazmatclass, string em_contactname, string em_phone)
        {
            Report.WriteLine("Verify the all field for Hazardous Materials ");

            string UNnoText = Gettext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[5]/div/div/div/div[3]/div/div[1]/div/div/div/div/div[1]/span");
            string[] ExpectedUNno = UNnoText.Split(':');
            string UNnoTextLabel = ExpectedUNno[0];
            Assert.AreEqual(un_number, UNnoTextLabel);

            string CCNnoText = Gettext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[5]/div/div/div/div[3]/div/div[1]/div/div/div/div/div[2]/span");
            string[] ExpectedCCNno = CCNnoText.Split(':');
            string CCNnoTextLabel = ExpectedCCNno[0];
            Assert.AreEqual(ccn_number, CCNnoTextLabel);

            string HazmatPackageText = Gettext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[5]/div/div/div/div[3]/div/div[1]/div/div/div/div/div[3]/span");
            string[] ExpectedHazmatPackageText = HazmatPackageText.Split(':');
            string HazmatPackageTextLabel = ExpectedHazmatPackageText[0];
            Assert.AreEqual(hazmat_package, HazmatPackageTextLabel);

            string hazmatclassText = Gettext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[5]/div/div/div/div[3]/div/div[2]/div/div/div/div/div[1]/span");
            string[] Expectedhazmatclass = hazmatclassText.Split(':');
            string hazmatclassTextLabel = Expectedhazmatclass[0];
            Assert.AreEqual(hazmatclass, hazmatclassTextLabel);

            string em_contactnameText = Gettext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[5]/div/div/div/div[3]/div/div[2]/div/div/div/div/div[2]/span");
            string[] Expectedem_contactname = em_contactnameText.Split(':');
            string em_contactnameTextLabel = Expectedem_contactname[0];
            Assert.AreEqual(em_contactname, em_contactnameTextLabel);

            string em_phoneText = Gettext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[5]/div/div/div/div[3]/div/div[2]/div/div/div/div/div[3]/span");
            string[] Expectedem_phone = em_phoneText.Split(':');
            string em_phoneTextLabel = Expectedem_phone[0];
            Assert.AreEqual(em_phone, em_phoneTextLabel);

        }

        [Then(@"Verify I should see the defined (.*) on review and submit page")]
        public void ThenVerifyIShouldSeeTheDefinedOnReviewAndSubmitPage(string defaultspecialinstruction)
        {
            VerifyElementPresent(attributeName_xpath, ReviewSubmit_Section_DefaultSpecialInstruction_Xpath, "Default special instruction");
            Report.WriteLine("Verified the default special instruction shows on Review and Submit page for associated customer");
            string defaultspecialActual = Gettext(attributeName_xpath, ReviewSubmit_DefaultSpecialInstruction_Instruction_Xpath);
            Assert.AreEqual(defaultspecialinstruction, defaultspecialActual);
        }

        [Given(@"I enter the (.*) and (.*) in Add shipment page")]
        public void GivenIEnterTheAndInAddShipmentPage(string insuredvalue, string insuredtype)
        {
            
            Report.WriteLine("Enter the values in Insured Value");
            SendKeys(attributeName_id, InsuredValue_TextBox_Id, insuredvalue);


            Report.WriteLine("Select the Insured Value type");
            Click(attributeName_xpath, InsuredValue_Type_xpath);
            IList<IWebElement> DropDownListClass = GlobalVariables.webDriver.FindElements(By.XPath(InsuredValue_Type_Values_xpath));
            int DropDownClassCount = DropDownListClass.Count;
            for (int i = 0; i < DropDownClassCount; i++)
            {
                if (DropDownListClass[i].Text == insuredtype)
                {
                    DropDownListClass[i].Click();
                    break;
                }
               
            }


        }
       


        [Then(@"Verify I should see the (.*) and (.*) on review and submit page")]
        public void ThenVerifyIShouldSeeTheAndOnReviewAndSubmitPage(string insuredvalue, string insuredtype)
        {

            string Insuredvalue = Gettext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[9]/div/div/div[2]/span");
            string[] InsuredValue = Insuredvalue.Split('.');
            string[] InsuredValueType = Insuredvalue.Split(' ');
            string InsuredtypeActual = InsuredValueType[1];

            
            

            string aaaaaaaaa = InsuredValue[0];

            string[] INsuredValue = aaaaaaaaa.Split('$');
            string InsuredValueExpected = INsuredValue[1];
           

            Report.WriteLine("Insured Value is matched");
            Assert.AreEqual(insuredvalue, InsuredValueExpected);
                
            Report.WriteLine("Insured Value type is matched");
            Assert.AreEqual(insuredtype,InsuredtypeActual);


        }

        [Given(@"I expand Reference number section and select (.*),(.*)")]
        public void GivenIExpandReferenceNumberSectionAndSelect(string movetype, string inventorylocationtype)
        {
            scrollElementIntoView(attributeName_xpath, ".//*[@id='referenceExpand']/h4");
            Report.WriteLine("Expand the Reference Number section");
            Click(attributeName_xpath, ".//*[@id='referenceExpand']/h4");

            Report.WriteLine("Select the Move Type");
            Click(attributeName_xpath, ".//*[@id='MoveType_chosen']/a");
            IList<IWebElement> DropDownListClass = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='MoveType_chosen']/div/ul/li"));
            int DropDownClassCount = DropDownListClass.Count;
            for (int i = 0; i < DropDownClassCount; i++)
            {
                if (DropDownListClass[i].Text == movetype)
                {
                    DropDownListClass[i].Click();
                    break;
                }

            }

            Report.WriteLine("Select the Inventry Loaction Type");
            Click(attributeName_xpath, ".//*[@id='InvLocType_chosen']/a");
            IList<IWebElement> DropDownListtype = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='InvLocType_chosen']/div/ul/li"));
            int DropDownCount = DropDownListtype.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownListtype[i].Text == inventorylocationtype)
                {
                    DropDownListtype[i].Click();
                    break;
                }

            }



        }
       
        [Then(@"Verify customer specific reference with Move Type and Inventory Location Type on review and submit page")]
        public void ThenVerifyCustomerSpecificReferenceWithMoveTypeAndInventoryLocationTypeOnReviewAndSubmitPage()
        {
            string movetype = "Move Type";
            string inventorylocationtype = "Inventory Location Type";
            Report.WriteLine("Verify the Reference Number Section and all field");
            VerifyElementPresent(attributeName_xpath, ReviewSubmit_CustomerSpecifcReferenceHeader_Xpath, "Customer Specific Reference");
            string movetypetext = Gettext(attributeName_xpath, ReviewSubmit_CustomerSpecificReference_MoveType_Xpath);
            string[] movetype1 = movetypetext.Split(':');
            string MovetypeActual = movetype1[0];

            Assert.AreEqual(movetype, MovetypeActual);

            string inventorytext = Gettext(attributeName_xpath, ReviewSubmit_CustomerSpecificReference_InventoryLocation_Xpath);
            string[] Inventory1 = inventorytext.Split(':');
            string InventoryTypeActual = Inventory1[0];

            Assert.AreEqual(inventorylocationtype, InventoryTypeActual);
        }

        [Then(@"Verify the carrier info section on review and submit page")]
        public void ThenVerifyTheCarrierInfoSectionOnReviewAndSubmitPage()
        {
            scrollElementIntoView(attributeName_xpath, ReviewSubmit_Section_CarrierInfo_Xpath);
            Report.WriteLine("Verify the Carrier Info Section");
            VerifyElementPresent(attributeName_xpath, ReviewSubmit_Section_CarrierInfo_Xpath, "Carrier Info Section");

            VerifyElementPresent(attributeName_xpath, ReviewSubmit_CarrierInfo_CarrierName_Xpath, "Carrier Name");

          

            VerifyElementPresent(attributeName_xpath, ReviewSubmit_CarrierInfo_EstimatedServiceDays_Xpath, "Estimated Service Days");

            VerifyElementPresent(attributeName_xpath, ReviewSubmit_CarrierInfo_Distance_Xpath, "Distance");

            VerifyElementPresent(attributeName_xpath, ReviewSubmit_CarrierInfo_EstRevenue_Xpath, "Est Revenue");
            string EstRevenue_Fuel_Expected = "Fuel";
            string EstRFuel = Gettext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[4]/div/div/div[2]/div/div/div[4]/span[2]");
            string[] EstRFuel1 = EstRFuel.Split(':');
            string EstRActual = EstRFuel1[0];

            Assert.AreEqual(EstRevenue_Fuel_Expected, EstRActual);

            string EstRevenue_LineHaul_Expected = "Line Haul";
            string EstRLineHaul = Gettext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[4]/div/div/div[2]/div/div/div[4]/span[3]");
            string[] EstLineHaul1 = EstRLineHaul.Split(':');
            string EstRLineHaulActual = EstLineHaul1[0];

            Assert.AreEqual(EstRevenue_LineHaul_Expected, EstRLineHaulActual);

            string EstRevenue_Accessorials_Expected = "Accessorials";
            string EstRAccessorial = Gettext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[4]/div/div/div[2]/div/div/div[4]/span[4]");
            string[] EstRAccessorial1 = EstRAccessorial.Split(':');
            string EstRevenue_Accessorials_Actual = EstRAccessorial1[0];

            Assert.AreEqual(EstRevenue_Accessorials_Expected, EstRevenue_Accessorials_Actual);


            VerifyElementPresent(attributeName_xpath, ReviewSubmit_CarrierInfo_EstCost_Xpath, "Est Cost");

            string EstCost_Fuel_Expected = "Fuel";
            string EstCFuel = Gettext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[4]/div/div/div[2]/div/div/div[5]/span[2]");
            string[] EstCFuel1 = EstCFuel.Split(':');
            string EstCActual = EstCFuel1[0];

            Assert.AreEqual(EstCost_Fuel_Expected, EstCActual);

            string EstCost_LineHaul_Expected = "Line Haul";
            string EstCLineHaul = Gettext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[4]/div/div/div[2]/div/div/div[5]/span[3]");
            string[] EstCostLineHaul1 = EstCLineHaul.Split(':');
            string CostLineHaulActual = EstCostLineHaul1[0];

            Assert.AreEqual(EstCost_LineHaul_Expected, CostLineHaulActual);

            string EstCost_Accessorials_Expected = "Accessorials";
            string EstCostAccessorial = Gettext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[4]/div/div/div[2]/div/div/div[5]/span[4]");
            string[] EstCostAccessorial1 = EstCostAccessorial.Split(':');
            string EstCost_Accessorials_Actual = EstCostAccessorial1[0];

            Assert.AreEqual(EstCost_Accessorials_Expected, EstCost_Accessorials_Actual);

            VerifyElementPresent(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[4]/div/div/div[2]/div/div/div[6]/span/b", "Est Margin");


        }
        [Then(@"I will see the edit carrier info icon")]
        public void ThenIWillSeeTheEditCarrierInfoIcon()
        {
            VerifyElementPresent(attributeName_id, ReviewSubmit_EditCarrierInfo_Button_Id, "Edit carrier info Icon");
        }

        [Then(@"Verify the carrier info section on review and submit page for ship entry user")]
        public void ThenVerifyTheCarrierInfoSectionOnReviewAndSubmitPageForShipEntryUser()
        {
            string FuelExpected = "Fuel";
            string LineHaulExpected = "Line Haul";
            string AccessorialsExpected = "Accessorials";
            Report.WriteLine("Verify the carrier info section");
            VerifyElementPresent(attributeName_xpath, ReviewSubmit_Section_CarrierInfo_Xpath, "Carrier Info");
            VerifyElementPresent(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[4]/div/div/div[2]/div/div/div[1]/div/span", "Carrier Name");
            VerifyElementPresent(attributeName_id, ReviewSubmit_CarrierInfo_CarrierLogo_Id, "Carrier Logo");
             VerifyElementPresent(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[4]/div/div/div[2]/div/div/div[2]/span[1]/b", "Estimated Service Days");
            VerifyElementPresent(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[4]/div/div/div[2]/div/div/div[3]/span[1]/b", "Distance");
            VerifyElementPresent(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[4]/div/div/div[2]/div/div/div[4]/span[1]/b", "Rate");

          
            string FuelExpected1 = Gettext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[4]/div/div/div[2]/div/div/div[4]/span[2]");
            string[] FuelExp1 = FuelExpected1.Split(':');
            string FuelActual = FuelExp1[0];

            Assert.AreEqual(FuelExpected, FuelActual);

           
            string LineHaulExpected1 = Gettext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[4]/div/div/div[2]/div/div/div[4]/span[3]");
            string[] LineHaulExp = LineHaulExpected1.Split(':');
            string LineHaulExpActual = LineHaulExp[0];

            Assert.AreEqual(LineHaulExpected, LineHaulExpActual);

            string AccessorialsExpected1 = Gettext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[4]/div/div/div[2]/div/div/div[4]/span[4]");
            string[] AccessorialsExp = AccessorialsExpected1.Split(':');
            string AccessorialsExpActual = AccessorialsExp[0];

            Assert.AreEqual(AccessorialsExpected, AccessorialsExpActual);


        }






    }

}
