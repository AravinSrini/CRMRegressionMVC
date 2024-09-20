using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using CRM.UITest.Scripts.Shipment.ShipmentList.ShipmentList_CopyLTLOption_AllUsers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.ShipmentList_InternalUsers.ShipmentList_EditShipment
{
    [Binding]
    public class Add_Shipment__LTL____Edit_Option_steps : AddShipments
    {
        CommonMethodsCrm crm = new CommonMethodsCrm();
        ShipmentList_CopyLTLOptionCopyShipmentButton_StationAndEntryUsersSteps copyShip = new ShipmentList_CopyLTLOptionCopyShipmentButton_StationAndEntryUsersSteps();

        [Given(@"I am operations, sales, sales management, or station owner user associated to Active Customer Account(.*),(.*)")]
        public void GivenIAmOperationsSalesSalesManagementOrStationOwnerUserAssociatedToActiveCustomerAccount(string Username, string Password)
        {
            crm.LoginToCRMApplication(Username, Password);
        }

       

        [When(@"Click on the Edit button for any eligible LTL shipment (.*)")]
        public void WhenClickOnTheEditButtonForAnyEligibleLTLShipment(string StationCustomerName)
        {
            Click(attributeName_xpath, ChooseCustomerType_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, ChooseCustomerTypeDropdownValues_Xpath, StationCustomerName);
            Thread.Sleep(90000);
            Report.WriteLine("Click on Edit Shipment button");
            Click(attributeName_xpath, ".//*[@id='ShipmentGrid']/tbody/tr[1]/td[10]/button");
        }

        [Then(@"all of the fields are editable")]
        public void ThenAllOfTheFieldsAreEditable()
        {
            //verifying only mandatory fields are editable or not

            SendKeys(attributeName_id, ShippingFrom_LocationName_Id, "Naini");
            SendKeys(attributeName_id, ShippingFrom_LocationAddressLine1_Id, "Malli");
            SendKeys(attributeName_id, ShippingFrom_LocationAddressLine2_Id, "Malli2");
            SendKeys(attributeName_id, ShippingFrom_zipcode_Id, "90001");

            SendKeys(attributeName_id, ShippingTo_LocationName_Id, "Naini");
            SendKeys(attributeName_id, ShippingTo_LocationAddressLine1_Id, "Malli");
            SendKeys(attributeName_id, ShippingTo_LocationAddressLine2_Id, "Malli2");
            SendKeys(attributeName_id, ShippingTo_zipcode_Id, "90001");


            SendKeys(attributeName_id, FreightDesp_FirstItem_NMFC_Id, "50");
            SendKeys(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id, "Desc");
            SendKeys(attributeName_id, FreightDesp_FirstItem_Quantity_Id, "1");
            SendKeys(attributeName_id, FreightDesp_FirstItem_Weight_Id, "11");
             
             //Verify edited Origin details
            string originLocName = GetValue(attributeName_id, ShippingFrom_LocationName_Id, "value");
            Assert.AreEqual(originLocName, "Naini");
            Report.WriteLine("Edited UN Number " + originLocName + "is displayin in UI" + "Naini");

            string originLocAdd1 = GetValue(attributeName_id, ShippingFrom_LocationAddressLine1_Id, "value");
            Assert.AreEqual(originLocAdd1, "Malli");
            Report.WriteLine("Edited UN Number " + originLocAdd1 + "is displayin in UI" + "Malli");

            string originLocAdd2 = GetValue(attributeName_id, ShippingFrom_LocationAddressLine2_Id, "value");
            Assert.AreEqual(originLocAdd2, "Malli2");
            Report.WriteLine("Edited UN Number " + originLocAdd2 + "is displayin in UI" + "Malli2");

            string originZipCode = GetValue(attributeName_id, ShippingFrom_zipcode_Id, "value");
            Assert.AreEqual(originZipCode, "90001");
            Report.WriteLine("Edited UN Number " + originLocName + "is displayin in UI" + "90001");

            //Verify edited Origin details
            string destLocName = GetValue(attributeName_id, ShippingTo_LocationName_Id, "value");
            Assert.AreEqual(destLocName, "Naini");
            Report.WriteLine("Edited UN Number " + destLocName + "is displayin in UI" + "Naini");

            string destLocAdd1 = GetValue(attributeName_id, ShippingTo_LocationAddressLine1_Id, "value");
            Assert.AreEqual(originLocAdd1, "Malli");
            Report.WriteLine("Edited UN Number " + destLocAdd1 + "is displayin in UI" + "Malli");

            string destLocAdd2 = GetValue(attributeName_id, ShippingTo_LocationAddressLine2_Id, "value");
            Assert.AreEqual(originLocAdd2, "Malli2");
            Report.WriteLine("Edited UN Number " + destLocAdd1 + "is displayin in UI" + "Malli2");

            string destZipCode = GetValue(attributeName_id, ShippingTo_zipcode_Id, "value");
            Assert.AreEqual(destZipCode, "90001");
            Report.WriteLine("Edited UN Number " + destZipCode + "is displayin in UI" + "90001");


            //Verify edited Freight description fields details
            string iteamNMFC = GetValue(attributeName_id, FreightDesp_FirstItem_NMFC_Id, "value");
            Assert.AreEqual(iteamNMFC, "50");
            Report.WriteLine("Edited UN Number " + iteamNMFC + "is displayin in UI" + "50");

            string iteamDEscription = GetValue(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id, "value");
            Assert.AreEqual(iteamDEscription, "Desc");
            Report.WriteLine("Edited UN Number " + iteamDEscription + "is displayin in UI" + "Desc");

            string iteamQuantity = GetValue(attributeName_id, FreightDesp_FirstItem_Quantity_Id, "value");
            Assert.AreEqual(iteamQuantity, "1");
            Report.WriteLine("Edited UN Number " + iteamQuantity + "is displayin in UI" + "1");

            string iteamWeight = GetValue(attributeName_id, FreightDesp_FirstItem_Weight_Id, "value");
            Assert.AreEqual(iteamWeight, "11");
            Report.WriteLine("Edited UN Number " + iteamWeight + "is displayin in UI" + "11");            
        }


        [When(@"I clicked on the View Rates button on the Add Shipment \(LTL\) page")]
        public void WhenIClickedOnTheViewRatesButtonOnTheAddShipmentLTLPage()
        {
            scrollpagedown();
            scrollpagedown();
            // scrollpagedown();
            try
            {
                Click(attributeName_xpath, Shipments_ViewRatesButton_xpath);
            }
            catch(Exception e)
            {
               
                Thread.Sleep(20000);
            }
        }

        [Then(@"I arrive on the Shipment Results \(LTL\) page")]
        public void ThenIArriveOnTheShipmentResultsLTLPage()
        {
            Report.WriteLine("Shipment Results Page");
            Verifytext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div[2]/div[1]/div[1]/h1", "Shipment Results (LTL)");
            Thread.Sleep(5000);
        }

        [Then(@"I have the option to select a displayed carrier(.*)")]
        public void ThenIHaveTheOptionToSelectADisplayedCarrier(string Usertype)
        {
           
           // Click(attributeName_xpath, ShipResults_InternalFC_CreateShipment_Xpath);
            if (Usertype == "Internal")
            {
                int carrierrowcount = GetCount(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr/td[1]/div");
                if (carrierrowcount > 1)
                {
                    Report.WriteLine("Click on the create shipment button");
                    Click(attributeName_xpath, ShipResults_InternalFC_CreateShipment_Xpath);

                }
                else
                {
                    Report.WriteLine("No list of carrier");
                    Click(attributeName_xpath, ShipResults_CreateShipmentWithoutCarrierRate_Button_xpath);
                }
            }
        }

        [When(@"there are no rates available for the shipment,")]
        public void WhenThereAreNoRatesAvailableForTheShipment()
        {
            string configURL = launchUrl;

            string resultPagrURL = configURL + "Shipment/ShipmentResultsLtl";
            if (GetURL() == resultPagrURL)
            {

                IList<IWebElement> row = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='ShipmentResultTable']/tbody/tr"));
                for (int i = 1; i <= row.Count; i++)
                {
                    string verCarrierName = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr/td");
                    if (verCarrierName != "There are no rates available for this shipment.")
                    {
                        string CarrierName = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + i + "]/td[1]/div/div");
                        Report.WriteLine("Carrier Rates are available on the Shipment Results page");
                    }
                    else
                    {
                        Verifytext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr/td", "There are no rates available for this shipment.");
                    }
                    break;
                }
            }
        }

        [Then(@"I have the option to create the shipment without carrier rates\.")]
        public void ThenIHaveTheOptionToCreateTheShipmentWithoutCarrierRates_()
        {
            VerifyElementPresent(attributeName_xpath, ShipResults_CreateShipmentWithoutCarrierRate_Button_xpath, "Create Shipment without carrier Rate button");
        }

        [Then(@"I arrive on review and submit page and click on submit button(.*)")]
        public void ThenIArriveOnReviewAndSubmitPageAndClickOnSubmitButton(string Usertype)
        {
            Report.WriteLine("I arrive on review and submit page");
           

            VerifyElementPresent(attributeName_xpath, ReviewAndSubmit_Title_Xpath, "Review and Submit Shipment(LTL)");
            scrollpagedown();
            scrollpagedown();
            try
            {
                Click(attributeName_xpath, ReviewAndSubmit_SubmitShipment_button_Xpath);
            }
            catch(Exception e)
            {
                Thread.Sleep(20000);
            }
        }

        [Then(@"I arrive on Shipment Confirmation page")]
        public void ThenIArriveOnShipmentConfirmationPage()
        {
            Report.WriteLine("IAmOnConfirmationPageOfTheShipment");
            Thread.Sleep(20000);
            VerifyElementVisible(attributeName_xpath, confirmation_pageheader, "confirmationpage");
        }

    }
}




            

