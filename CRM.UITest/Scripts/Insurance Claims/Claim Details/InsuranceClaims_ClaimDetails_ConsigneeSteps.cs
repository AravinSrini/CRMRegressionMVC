using TechTalk.SpecFlow;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using CRM.UITest.CommonMethods;
using System.Threading;

namespace CRM.UITest.Scripts.Insurance_Claims.Claim_Details
{
    [Binding]
    public class InsuranceClaims_ClaimDetails_ConsigneeSteps : Objects.InsuranceClaim
    {
        string claimNumber = null;
        string name = "Test";
        string address = "1000 windham parkway";
        string city = "Bolingbrook";
        string state = "IL";
        string zip = "60490";
        string country = "United States";
        string carrierAck = "Y";
        string carrierAckDate = "8/28/2018";
        string carrierClaim = "1233432";
        string carrierPRODate = "8/28/2018";
        string bolOrShipDate = "8/28/2018";
        string deliveryDate = "8/28/2018";
        string remarks = "Testing Remarks Section";
        string carrierClaimNumberClaimDetails = string.Empty;

        [Given(@"I am on Claim Detailspage")]
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
                Click(attributeName_xpath, ClaimsList_OpenCheckbox_xpath);
                DefineTimeOut(1000);
                claimNumber = Gettext(attributeName_xpath, ClaimSpecilistFirstClaimNumber_ClaimsListGrid_Xpath);
                Click(attributeName_xpath, ClaimSpecilistFirstClaimNumber_ClaimsListGrid_Xpath);
                GlobalVariables.webDriver.WaitForPageLoad();
            }
        }

        [Given(@"I have updated the fields - Name, Address, City, State, Zip, Country in Consignee Section")]
        public void GivenIHaveUpdatedTheFields_NameAddressCityStateZipCountryInConsigneeSection()
        {
            scrollpagedown();
            Click(attributeName_xpath, Consignee_Country_dropdown_Xpath);
            SendKeys(attributeName_xpath, Consignee_Country_Textbox_Xpath, country);
            Click(attributeName_xpath, Consignee_Country_SelectingFirstHighlighted_Xpath);
            SendKeys(attributeName_id, Consignee_Name_Textbox_Id, name);
            SendKeys(attributeName_id, Consignee_Address_Textbox_Id, address);
            SendKeys(attributeName_id, Consignee_City_Textbox_Id, city);
            //SendKeys(attributeName_id, Consignee_State_Province_Id, state);
            SendKeys(attributeName_id, Consignee_Zip_Postal_Textbox_Id, zip);
            Report.WriteLine("updated the fields of Consignee Section");
        }

     

        [Given(@"I have updated the fields - Carrier PRO Date, BOL/Ship Date, Delivery Date in Key Dates Section")]
        public void GivenIHaveUpdatedTheFields_CarrierPRODateBOLShipDateDeliveryDateInKeyDatesSection()
        {
            Click(attributeName_id, KeyDates_CarrierProDate_Id);
            SendKeys(attributeName_id, KeyDates_CarrierProDate_Id, Keys.Backspace);
            SendKeys(attributeName_id, KeyDates_CarrierProDate_Id, carrierPRODate);
            Click(attributeName_id, Consignee_Name_Textbox_Id);

            Click(attributeName_id, KeyDates_BOLDate_Id);
            SendKeys(attributeName_id, KeyDates_BOLDate_Id, Keys.Backspace);
            SendKeys(attributeName_id, KeyDates_BOLDate_Id, bolOrShipDate);
            Click(attributeName_id, Consignee_Name_Textbox_Id);

            Click(attributeName_id, KeyDates_DeliveryDate_Id);
            SendKeys(attributeName_id, KeyDates_DeliveryDate_Id, Keys.Backspace);
            SendKeys(attributeName_id, KeyDates_DeliveryDate_Id, deliveryDate);
            Click(attributeName_id, Consignee_Name_Textbox_Id);
            Report.WriteLine("updated the fields of Key Dates Section");
        }

        [Given(@"I have updated Remarks field")]
        public void GivenIHaveUpdatedRemarksField()
        {
            SendKeys(attributeName_id, Remarks_Id, remarks);
            Report.WriteLine("updated Remarks field");
        }

        [Given(@"I have edited any of the fields of (.*) section of Details page")]
        public void GivenIHaveEditedAnyOfTheFieldsOfSectionOfDetailsPage(string consignee)
        {
            scrollpagedown();
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("updating any of the below fields of Consignee Section");
            scrollpagedown();
            if (consignee == "Name")
            {
                GlobalVariables.webDriver.WaitForPageLoad();
                Click(attributeName_id, Consignee_Name_Textbox_Id);
                SendKeys(attributeName_id, Consignee_Name_Textbox_Id, name);
            }
            else if (consignee == "Address")
            {
                GlobalVariables.webDriver.WaitForPageLoad();
                Click(attributeName_id, Consignee_Address_Textbox_Id);
                SendKeys(attributeName_id, Consignee_Address_Textbox_Id, address);
            }
            else if (consignee == "City")
            {
                GlobalVariables.webDriver.WaitForPageLoad();
                Click(attributeName_id, Consignee_City_Textbox_Id);
                SendKeys(attributeName_id, Consignee_City_Textbox_Id, city);
            }
            else if (consignee == "State")
            {                
                GlobalVariables.webDriver.WaitForPageLoad();
                Thread.Sleep(4000);
                Click(attributeName_xpath, Consignee_State_Province_dropdown_Xpath);
                SendKeys(attributeName_xpath, Consignee_State_Textbox_Xpath, state);
                Click(attributeName_xpath, Consignee_State_SelectingFirstHighlighted_Xpath);
            }
            else if (consignee == "Zip")
            {                
                GlobalVariables.webDriver.WaitForPageLoad();
                Click(attributeName_id, Consignee_Zip_Postal_Textbox_Id);
                SendKeys(attributeName_id, Consignee_Zip_Postal_Textbox_Id, zip);
            }
            else if (consignee == "Country")
            {   
                GlobalVariables.webDriver.WaitForPageLoad();
                Click(attributeName_xpath, Consignee_Country_dropdown_Xpath);
                SendKeys(attributeName_xpath, Consignee_Country_Textbox_Xpath, country);
                Click(attributeName_xpath, Consignee_Country_SelectingFirstHighlighted_Xpath);
            }
            else if (consignee == "Carrier Ack")
            {                 
                GlobalVariables.webDriver.WaitForPageLoad();
                Thread.Sleep(4000);
                Click(attributeName_xpath, CarrierOSDActions_CarrierAck_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, CarrierOSDActions_CarrierAckValues_Xpath, carrierAck);
            }
            else if (consignee == "Carrier Ack Date")
            {
                GlobalVariables.webDriver.WaitForPageLoad();
                Click(attributeName_id, CarrierOSDActions_CarrierAckDate_Id);
                SendKeys(attributeName_id, CarrierOSDActions_CarrierAckDate_Id, Keys.Backspace);
                SendKeys(attributeName_id, CarrierOSDActions_CarrierAckDate_Id, carrierAckDate);
                Click(attributeName_id, Consignee_Name_Textbox_Id);
            }
            else if (consignee == "Carrier Claim #")
            {                
                scrollpagedown();
                GlobalVariables.webDriver.WaitForPageLoad();
                SendKeys(attributeName_id, CarrierOSDActions_CarrierClaimNumber_Id, carrierClaim);
            }
            else if (consignee == "Carrier PRO Date")
            {
                GlobalVariables.webDriver.WaitForPageLoad();
                Click(attributeName_id, KeyDates_CarrierProDate_Id);
                SendKeys(attributeName_id, KeyDates_CarrierProDate_Id, Keys.Backspace);
                SendKeys(attributeName_id, KeyDates_CarrierProDate_Id, carrierPRODate);
                Click(attributeName_id, Consignee_Name_Textbox_Id);
            }
            else if (consignee == "BOL/Ship Date")
            {
                GlobalVariables.webDriver.WaitForPageLoad();
                Click(attributeName_id, KeyDates_BOLDate_Id);
                SendKeys(attributeName_id, KeyDates_BOLDate_Id, Keys.Backspace);
                SendKeys(attributeName_id, KeyDates_BOLDate_Id, bolOrShipDate);
                Click(attributeName_id, Consignee_Name_Textbox_Id);
            }
            else if (consignee == "Delivery Date")
            {
                GlobalVariables.webDriver.WaitForPageLoad();
                Click(attributeName_id, KeyDates_DeliveryDate_Id);
                SendKeys(attributeName_id, KeyDates_DeliveryDate_Id, Keys.Backspace);
                SendKeys(attributeName_id, KeyDates_DeliveryDate_Id, deliveryDate);
                Click(attributeName_id, Consignee_Name_Textbox_Id);
                Report.WriteLine("updated the fields of Key Dates Section");
            }
            else
            {                
                scrollpagedown();
                GlobalVariables.webDriver.WaitForPageLoad();
                Click(attributeName_id, Remarks_Id);
                SendKeys(attributeName_id, Remarks_Id, remarks);
            }
        }

        [When(@"I click on SaveClaimDetails button")]
        public void WhenIClickOnSaveClaimDetailsButton()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            scrollElementIntoView(attributeName_id, SaveClaimDetailsButton_Id);
            scrollPageup();            
            Click(attributeName_id, SaveClaimDetailsButton_Id);
            Report.WriteLine("Clicked on Save Claim details button");
        }

        [Then(@"Consignee values should be saved with the updated values")]
        public void ThenConsigneeValuesShouldBeSavedWithTheUpdatedValuesInDB()
        {
            InsuranceClaimConsigneeAddress consigneeAddressDetails = DBHelper.GetInsuranceClaimConsigneeAddresses(claimNumber);
            Assert.AreEqual(name, consigneeAddressDetails.Name);
            Assert.AreEqual(address, consigneeAddressDetails.Address);
            Assert.AreEqual(city, consigneeAddressDetails.CityName);
            Assert.AreEqual(state, consigneeAddressDetails.StateName);
            Assert.AreEqual(zip, consigneeAddressDetails.Zip);
            Country consigneeCountry = DBHelper.GetCountryNameDetails(claimNumber);
            Assert.AreEqual(country, consigneeCountry.CountryName);
            Report.WriteLine("Name, Address, City, State, Zip, Country fields of Consignee section updated in DB");

            InsuranceCarrierOsdAction carrierOSDActions = DBHelper.GetCarrierOsdActionsdetails(claimNumber);
            if (carrierOSDActions.CarrierAck == true)
            {
                Report.WriteLine("Carrier Ack: Y");
            }
            else
            {
                Report.WriteLine("Carrier Ack: N");
            }            
            Assert.AreEqual(carrierAckDate, carrierOSDActions.CarrierAckDate.ToString().Replace(" 12:00:00 AM", ""));
            Assert.AreEqual(carrierClaim, carrierOSDActions.CarrierClaimNumber);
            Report.WriteLine("Carrier Ack, Carrier Ack Date, Carrier Claim number fields of Carrier OS&D Actions updated in DB");

            InsuranceClaimCarrier keyDatesDetails = DBHelper.GetInsuranceCarrierDetails(claimNumber);
            string prodate = keyDatesDetails.CarrierProDate.ToString().Replace(" 12:00:00 AM", "");
            Assert.AreEqual(carrierPRODate, prodate);
            string shipdate = keyDatesDetails.DlswShipDate.ToString().Replace(" 12:00:00 AM", "");
            Assert.AreEqual(bolOrShipDate, shipdate);
            string deliverdt = keyDatesDetails.DeliveryDate.ToString().Replace(" 12:00:00 AM", "");
            Assert.AreEqual(deliveryDate, deliverdt);
            Report.WriteLine("Carrier PRO Date, BOL/Ship Date, Deliver Date fields of Key Dates sections updated in DB");

            Entities.Proxy.InsuranceClaim remarksDetails = DBHelper.GetInsuranceCliamDetails(claimNumber);
            Assert.AreEqual(remarks, remarksDetails.Remarks);
            Report.WriteLine("Remarks section updated in DB");
        }

        [Then(@"The Consignee (.*) fields should be saved with the updated values")]
        public void ThenTheConsigneeFieldsShouldBeSavedWithTheUpdatedValues(string consignee)
        {
            DefineTimeOut(10000);
            InsuranceClaimConsigneeAddress consigneeAddressDetails = DBHelper.GetInsuranceClaimConsigneeAddresses(claimNumber);
            Country consigneeCountry = DBHelper.GetCountryNameDetails(claimNumber);
            InsuranceCarrierOsdAction carrierOSDActions = DBHelper.GetCarrierOsdActionsdetails(claimNumber);
            InsuranceClaimCarrier keyDatesDetails = DBHelper.GetInsuranceCarrierDetails(claimNumber);
            Entities.Proxy.InsuranceClaim remarksDetails = DBHelper.GetInsuranceCliamDetails(claimNumber);

            if (consignee == "Name")
            {
                Assert.AreEqual(name, consigneeAddressDetails.Name);
            }
            else if (consignee == "Address")
            {
                Assert.AreEqual(address, consigneeAddressDetails.Address);
            }
            else if (consignee == "City")
            {
                Assert.AreEqual(city, consigneeAddressDetails.CityName);
            }
            else if (consignee == "State")
            {
                Assert.AreEqual(state, consigneeAddressDetails.StateName);
            }
            else if (consignee == "Zip")
            {
                Assert.AreEqual(zip, consigneeAddressDetails.Zip);
            }
            else if (consignee == "Country")
            {
                Assert.AreEqual(country, consigneeCountry.CountryName);
            }
            else if (consignee == "Carrier Ack")
            {
                if (carrierOSDActions.CarrierAck == true)
                {
                    Report.WriteLine("Carrier Ack: Y");
                }
                else
                {
                    Report.WriteLine("Carrier Ack: N");
                }
            }
            else if (consignee == "Carrier Ack Date")
            {
                Assert.AreEqual(carrierAckDate, carrierOSDActions.CarrierAckDate.ToString().Replace(" 12:00:00 AM", ""));
            }
            else if (consignee == "Carrier Claim #")
            {
                Assert.AreEqual(carrierClaim, carrierOSDActions.CarrierClaimNumber);
            }
            else if (consignee == "Carrier PRO Date")
            {
                string prodate = keyDatesDetails.CarrierProDate.ToString().Replace(" 12:00:00 AM", "");
                Assert.AreEqual(carrierPRODate, prodate);
            }
            else if (consignee == "BOL/Ship Date")
            {
                string shipdate = keyDatesDetails.DlswShipDate.ToString().Replace(" 12:00:00 AM", "");
                Assert.AreEqual(bolOrShipDate, shipdate);
            }
            else if (consignee == "Delivery Date")
            {
                string deliverdt = keyDatesDetails.DeliveryDate.ToString().Replace(" 12:00:00 AM", "");
                Assert.AreEqual(deliveryDate, deliverdt);
            }
            else
            {
                Assert.AreEqual(remarks, remarksDetails.Remarks);
            }
        }

        [Given(@"I am on the Claim Details page of a claim")]
        public void GivenIAmOnTheClaimDetailsPageOfAClaim()
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
                DefineTimeOut(1000);
                Click(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']//*[@class ='SubmitClaimDateSort sorting_asc']");
                DefineTimeOut(2000);
                claimNumber = Gettext(attributeName_xpath, ClaimSpecilistFirstClaimNumber_ClaimsListGrid_Xpath);
                Click(attributeName_xpath, ClaimSpecilistFirstClaimNumber_ClaimsListGrid_Xpath);
                GlobalVariables.webDriver.WaitForPageLoad();
            }
        }

        [Given(@"I have edited Carrier Ack, Carrier Ack Date, Carrier Claim Number in the Carrier OS&D Actions section")]
        public void GivenIHaveEditedCarrierAckCarrierAckDateCarrierClaimNumberInTheCarrierOSDActionsSection()
        {
            Report.WriteLine("Editing Carrier Ack field");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, CarrierOSDActions_CarrierAck_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, CarrierOSDActions_CarrierAckValues_Xpath, carrierAck);

            Report.WriteLine("Editing Carrier Ack Date");
            Click(attributeName_id, CarrierOSDActions_CarrierAckDate_Id);
            SendKeys(attributeName_id, CarrierOSDActions_CarrierAckDate_Id, Keys.Backspace);
            SendKeys(attributeName_id, CarrierOSDActions_CarrierAckDate_Id, carrierAckDate);
            Click(attributeName_id, Consignee_Name_Textbox_Id);

            Report.WriteLine("Editing Carrier Claim Number");
            scrollpagedown();
            SendKeys(attributeName_id, CarrierOSDActions_CarrierClaimNumber_Id, carrierClaim);

        }

        [When(@"I have Click the Save Claim Details button")]
        public void WhenIHaveClickTheSaveClaimDetailsButton()
        {
            WhenIClickOnSaveClaimDetailsButton();
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ClaimsIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Then(@"the information will be saved")]
        public void ThenTheInformationWillBeSaved()
        {
            InsuranceCarrierOsdAction carrierOSDActions = DBHelper.GetCarrierOsdActionsdetails(claimNumber);
            string expectedCarrierAckDate = carrierOSDActions.CarrierAckDate.ToString().Replace(" 12:00:00 AM", string.Empty);

            if (carrierOSDActions.CarrierAck == true)
            {
                Report.WriteLine("Carrier Ack as Y is updated in DB");
            }
            else
            {
                Report.WriteFailure("Carrier Ack as Y is not updated in DB");
            }

            
            Assert.AreEqual(carrierAckDate, expectedCarrierAckDate);
            Assert.AreEqual(carrierClaim, carrierOSDActions.CarrierClaimNumber);
            Report.WriteLine("Carrier Ack Date of Carrier OS&D Action section is updated in DB");
        }

        [Given(@"I edited the Carrier Claim Number field of the Carrier OS&D Actions section")]
        public void GivenIEditedTheCarrierClaimNumberFieldOfTheCarrierOSDActionsSection()
        {
            Random rnd = new Random();
            int myRandomNo = rnd.Next(10000000, 99999999);
            carrierClaimNumberClaimDetails = myRandomNo.ToString();
            scrollpagedown();
            SendKeys(attributeName_id, CarrierOSDActions_CarrierClaimNumber_Id, carrierClaimNumberClaimDetails);
        }

        [Given(@"I have Clicked the Save Claim Details button")]
        public void GivenIHaveClickedTheSaveClaimDetailsButton()
        {
            WhenIHaveClickTheSaveClaimDetailsButton();
        }

        [When(@"I arrive on the Claim List page")]
        public void WhenIArriveOnTheClaimListPage()
        {
            Verifytext(attributeName_xpath, ClaimsListPage_HeaderText_Xpath, "Claims List");
        }

        [Then(@"I will see the saved values of the Carrier Claim Number field of the Carrier OS&D Actions section displayed in the Carrier field of the Claim Numbers Column")]
        public void ThenIWillSeeTheSavedValuesOfTheCarrierClaimNumberFieldOfTheCarrierOSDActionsSectionDisplayedInTheCarrierFieldOfTheClaimNumbersColumn()
        {
            SendKeys(attributeName_xpath, ClaimList_ClaimNumberSearchBox_Xpath, claimNumber);
            string carrierClaimNumberFromClaimListPage = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']//span[2]");
            string[] carrierClaimNumber = carrierClaimNumberFromClaimListPage.Split(new char[0]);
            string actualCarrierClaimNumber = carrierClaimNumber[1];
            Assert.AreEqual(carrierClaimNumberClaimDetails, actualCarrierClaimNumber);
        }

    }
}
