using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Edit_Shipment
{
    [Scope(Feature = "Edit Shipment_Display Shipment Number And Update Button Names")]
    [Binding]
    public class EditShipment_DisplayShipmentNumberAndUpdateButtonNamesSteps: AddShipments
    {
        public string CustomerName = "ZZZ - GS Customer Test";
        public string shipmentNumber;
        public string actualShipmentNumberInVerbiage;
        public string actualEditShipmentVerbiage;
        public string actualEditingTextInVerbiage;

        [Given(@"I am a DLS Internal user with access to Shipments")]
        public void GivenIAmADLSInternalUserWithAccessToShipments()
        {
            string username = ConfigurationManager.AppSettings["InternalUserLogin"].ToString();
            string password = ConfigurationManager.AppSettings["InternalUserPassword"].ToString();

            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"I am a DLS Sales user with access to Shipments")]
        public void GivenIAmADLSSalesUserWithAccessToShipments()
        {
            string username = ConfigurationManager.AppSettings["username-salesdelta"].ToString();
            string password = ConfigurationManager.AppSettings["password-salesdelta"].ToString();

            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"I am on the Shipment List Page")]
        public void GivenIAmOnTheShipmentListPage()
        {
            Report.WriteLine("Clicked on Shipments icon");
            Click(attributeName_cssselector, ShipmentsIcon_css);
            GlobalVariables.webDriver.WaitForPageLoad();

            Report.WriteLine("Select Customer Name from the dropdown list");
            Click(attributeName_xpath, AllCustomerDropdown_Selection_Internal_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_xpath, AllCustomerDroppdownSearchBox_Internal_Xpath, CustomerName);
            IList<IWebElement> CustomerDropDownList = GlobalVariables.webDriver.FindElements(By.XPath(AllCustomerDroppdownValues_Internal_Xpath));
            int CustomerDropDownCount = CustomerDropDownList.Count;
            for (int i = 0; i < CustomerDropDownCount; i++)
            {
                if (CustomerDropDownList[i].Text == CustomerName)
                {
                    CustomerDropDownList[i].Click();
                    break;
                }
            }
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Shipment List page displays with relevant Shipments");
         }

        [Given(@"I click on the Edit button of any available LTL shipment")]
        public void GivenIClickOnTheEditButtonOfAnyAvailableLTLShipment()
        {
            shipmentNumber = Gettext(attributeName_xpath, ShipmentList_FirstReference_no_Xpath);
            Report.WriteLine("Shipment selected for Edit is: " + shipmentNumber);

            Click(attributeName_cssselector, ShipmentList_EditShipmentButton_Selector);
            Thread.Sleep(10000);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Edit Shipment page displays for shipment: " + shipmentNumber);
        }

        [When(@"I arrive on the Shipment Results \(LTL\) page")]
        public void WhenIArriveOnTheShipmentResultsLTLPage()
        {
            Click(attributeName_id, ShippingFrom_SelectSavedOriginDropDown_Id);
            string _selectedAddress = GetValue(attributeName_id, ShippingFrom_SelectSavedOriginDropDown_Id, "value");

            if (_selectedAddress != "" || _selectedAddress != string.Empty)
            {
                Click(attributeName_id, ClearAddress_OriginId);
            }

            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ShippingFrom_SelectSavedOriginDropDown_Id);
            SendKeys(attributeName_id, ShippingFrom_SelectSavedOriginDropDown_Id, "AIRGAS REFRIGERANTS");
            Thread.Sleep(3000);
            Click(attributeName_xpath, ".//*[@class='tt-dataset-autos'][1]//p");
            GlobalVariables.webDriver.WaitForPageLoad();


            Click(attributeName_id, ShippingTo_SelectSavedDestDropDown_Id);
            _selectedAddress = GetValue(attributeName_id, ShippingTo_SelectSavedDestDropDown_Id, "value");

            if (_selectedAddress != "" || _selectedAddress != string.Empty)
            {
                Click(attributeName_id, ClearAddress_OriginId);
            }

            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ShippingTo_SelectSavedDestDropDown_Id);
            SendKeys(attributeName_id, ShippingTo_SelectSavedDestDropDown_Id, "ACE TRANSPORT");
            Thread.Sleep(3000);
            Click(attributeName_xpath, ".//*[@class='tt-dataset-autos'][1]//p");
            GlobalVariables.webDriver.WaitForPageLoad();

            SendKeys(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id, "TestItemDescription");

            Report.WriteLine("Click on Date picker");            
            Click(attributeName_xpath, PickUpDate_Xpath);
            Report.WriteLine("PickUp date selection");
            Click(attributeName_xpath, ".//*[@class='today day']");
            GlobalVariables.webDriver.WaitForPageLoad();

            //Enter reference numbers
            SendKeys(attributeName_id, ReferenceNumbers_PONumber_Id, "123456");
            SendKeys(attributeName_id, ReferenceNumbers_OrderNumber_Id, "123456");
            SendKeys(attributeName_id, ReferenceNumbers_GLCode_Id, "123456");
            SendKeys(attributeName_id, ReferenceNumbers_BOLNumber_Id, "ZZX002011772");
            SendKeys(attributeName_id, ReferenceNumbers_PRONumber_Id, "123456");
            SendKeys(attributeName_id, ReferenceNumbers_PickUpNumber_Id, "123456");
            SendKeys(attributeName_id, ReferenceNumbers_DeliveryApptNumber_Id, "123456");
            SendKeys(attributeName_xpath, AdditionalReferenceNumber_Value_xpath, "123456");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, Shipments_ViewRatesButton_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Clicked on View Rates Button");            

        }

        [When(@"I arrive on the Review and Submit Shipment \(LTL\) page")]
        public void WhenIArriveOnTheReviewAndSubmitShipmentLTLPage()
        {
            Click(attributeName_id, ShippingFrom_SelectSavedOriginDropDown_Id);
            string _selectedAddress = GetValue(attributeName_id, ShippingFrom_SelectSavedOriginDropDown_Id, "value");

            if (_selectedAddress != "" || _selectedAddress != string.Empty)
            {
                Click(attributeName_id, ClearAddress_OriginId);
            }

            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ShippingFrom_SelectSavedOriginDropDown_Id);
            SendKeys(attributeName_id, ShippingFrom_SelectSavedOriginDropDown_Id, "AIRGAS REFRIGERANTS");
            Thread.Sleep(3000);
            Click(attributeName_xpath, ".//*[@class='tt-dataset-autos'][1]//p");
            GlobalVariables.webDriver.WaitForPageLoad();

            Click(attributeName_id, ShippingTo_SelectSavedDestDropDown_Id);
            _selectedAddress = GetValue(attributeName_id, ShippingTo_SelectSavedDestDropDown_Id, "value");

            if (_selectedAddress != "" || _selectedAddress != string.Empty)
            {
                Click(attributeName_id, ClearAddress_OriginId);
            }

            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ShippingTo_SelectSavedDestDropDown_Id);
            SendKeys(attributeName_id, ShippingTo_SelectSavedDestDropDown_Id, "ACE TRANSPORT");
            Thread.Sleep(3000);
            Click(attributeName_xpath, ".//*[@class='tt-dataset-autos'][1]//p");
            GlobalVariables.webDriver.WaitForPageLoad();

            SendKeys(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id, "TestItemDescription");

            Report.WriteLine("Click on Date picker");            
            Click(attributeName_xpath, PickUpDate_Xpath);
            Report.WriteLine("PickUp date selection");
            Click(attributeName_xpath, ".//*[@class='today day']");
            GlobalVariables.webDriver.WaitForPageLoad();            

            //Enter reference numbers
            SendKeys(attributeName_id, ReferenceNumbers_PONumber_Id, "123456");
            SendKeys(attributeName_id, ReferenceNumbers_OrderNumber_Id, "123456");
            SendKeys(attributeName_id, ReferenceNumbers_GLCode_Id, "123456");
            SendKeys(attributeName_id, ReferenceNumbers_BOLNumber_Id, "ZZX002011772");
            SendKeys(attributeName_id, ReferenceNumbers_PRONumber_Id, "123456");
            SendKeys(attributeName_id, ReferenceNumbers_PickUpNumber_Id, "123456");
            SendKeys(attributeName_id, ReferenceNumbers_DeliveryApptNumber_Id, "123456");
            SendKeys(attributeName_xpath, AdditionalReferenceNumber_Value_xpath, "123456");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, Shipments_ViewRatesButton_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Clicked on View Rates Button");

            Click(attributeName_xpath, ShipResults_UpdateShipButtonFirst_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Clicked on Update Shipment button");
        }


        [Then(@"I should see verbiage below the Add Shipment \(LTL\) page title indicating the Shipment Number being edited")]
        public void ThenIShouldSeeVerbiageBelowTheAddShipmentLTLPageTitleIndicatingTheShipmentNumberBeingEdited()
        {
            actualShipmentNumberInVerbiage = Gettext(attributeName_xpath, EditShipmentVerbiage_ShipmentNumber_xpath);
            actualEditingTextInVerbiage = Gettext(attributeName_xpath, EditShipmentVerbiage_EditingText_xpath);
            actualEditShipmentVerbiage = actualShipmentNumberInVerbiage + " " + actualEditingTextInVerbiage;
            Report.WriteLine("Actual Edit Verbiage: " + actualEditShipmentVerbiage);

            Assert.AreEqual(shipmentNumber + " Editing", actualEditShipmentVerbiage);
            Report.WriteLine("Edit Shipment verbiage displays on Add Shipment (LTL) page");
        }
        
        [Then(@"I should see verbiage below the Shipment Results page title indicating the Shipment Number being edited")]
        public void ThenIShouldSeeVerbiageBelowTheShipmentResultsPageTitleIndicatingTheShipmentNumberBeingEdited()
        {
            actualShipmentNumberInVerbiage = Gettext(attributeName_xpath, EditShipmentVerbiage_ShipmentNumber_xpath);
            actualEditingTextInVerbiage = Gettext(attributeName_xpath, EditShipmentVerbiage_EditingText_xpath);
            actualEditShipmentVerbiage = actualShipmentNumberInVerbiage + " " + actualEditingTextInVerbiage;
            Report.WriteLine("Actual Edit Verbiage: " + actualEditShipmentVerbiage);

            Assert.AreEqual(shipmentNumber + " Editing", actualEditShipmentVerbiage);
            Report.WriteLine("Edit Shipment verbiage displays on Shipment Results (LTL) page");

        }

        [Then(@"I see Create Shipment button renamed to Update Shipment")]
        public void ThenISeeCreateShipmentButtonRenamedToUpdateShipment()
        {
            IList<IWebElement> allUpdateShipmentButtons = GlobalVariables.webDriver.FindElements(By.XPath(ShipResults_UpdateShipButtonAll_Xpath));
            int updateShipmentButtonsCount = allUpdateShipmentButtons.Count;
            for (int i = 1; i < updateShipmentButtonsCount; i++)
            {
                if (allUpdateShipmentButtons[i].Text == "Update Shipment")
                {
                    Report.WriteLine("Button No " + i + " displays as Update Shipment");
                }
                else
                {
                    Assert.Fail("Button No " + i + " displays as Create Shipment");
                }
            }
        }

        [Then(@"I see Create Insured Shipment renamed to Update Insured Shipment")]
        public void ThenISeeCreateInsuredShipmentRenamedToUpdateInsuredShipment()
        {
            SendKeys(attributeName_xpath, ShipResultsInsuredValue_Xpath, "100");
            Click(attributeName_id, ShipResults_ShowInsuredRateButton_Id);
            Report.WriteLine("Entered a Insured value and clicked on Show Insured Rate button");
            GlobalVariables.webDriver.WaitForPageLoad();

            IList<IWebElement> allUpdateInsuredShipmentButtons = GlobalVariables.webDriver.FindElements(By.XPath(ShipResults_CreateShipInsuredButton_Xpath));
            int updateInsuredShipmentButtonsCount = allUpdateInsuredShipmentButtons.Count;
            for (int i = 1; i < updateInsuredShipmentButtonsCount; i++)
            {
                if (allUpdateInsuredShipmentButtons[i].Text == "Update Insured Shipment*")
                {
                    Report.WriteLine("Button No " + i + " displays as Update Insured Shipment*");
                }
                else
                {
                    Assert.Fail("Button No " + i + " displays as Create Insured Shipment*");
                }
            }
        }


        [Then(@"I should see verbiage below the Review And Submit page title indicating the Shipment Number being edited")]
        public void ThenIShouldSeeVerbiageBelowTheReviewAndSubmitPageTitleIndicatingTheShipmentNumberBeingEdited()
        {
            actualShipmentNumberInVerbiage = Gettext(attributeName_xpath, EditShipmentVerbiage_ShipmentNumber_xpath);
            actualEditingTextInVerbiage = Gettext(attributeName_xpath, EditShipmentVerbiage_EditingText_xpath);
            actualEditShipmentVerbiage = actualShipmentNumberInVerbiage + " " + actualEditingTextInVerbiage;
            Report.WriteLine("Actual Edit Verbiage: " + actualEditShipmentVerbiage);

            Assert.AreEqual(shipmentNumber + " Editing", actualEditShipmentVerbiage);
            Report.WriteLine("Edit Shipment verbiage displays on Shipment Results (LTL) page");
        }

        [Then(@"I see Submit Shipment button renamed to Submit Updated Shipment")]
        public void ThenISeeSubmitShipmentButtonRenamedToSubmitUpdatedShipment()
        {
            string actualSubmitUpdatedShipmentBtnLabel = Gettext(attributeName_xpath, ReviewAndSubmit_SubmitShipment_button_Xpath);
            Report.WriteLine("Actual title of the Submit button on Editing a SHipment is: " + actualSubmitUpdatedShipmentBtnLabel);

            Assert.AreEqual("Submit Updated Shipment", actualSubmitUpdatedShipmentBtnLabel);
            Report.WriteLine("Submit Shipment button label is renamed to Submit Updated Shipment while editing a Shipment");
        }

    }
}
