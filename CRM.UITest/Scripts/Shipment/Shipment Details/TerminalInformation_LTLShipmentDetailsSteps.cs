using CRM.UITest.CommonMethods;
using CRM.UITest.Helper;
using CRM.UITest.Helper.Interfaces;
using CRM.UITest.Helper.ViewModel;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Shipment_Details
{
    [Binding]
    public class TerminalInformation_LTLShipmentDetailsSteps : AddShipments
    {   
        string shipmentReferenceNumber = "ZZX002016941";
        string Pickup_countryCode = string.Empty;
        string UI_Pickup_CarrierName = null;
        string UI_Delivery_CarrierName = null;
        string UI_Pickup_Address1 = null;
        string UI_Delivery_Address1 = null;
        string UI_Pickup_Address2 = null;
        string UI_Delivery_Address2 = null;
        string UI_Pickup_City = null;
        string UI_Delivery_City = null;
        string UI_Pickup_StateProvince = null;
        string UI_Delivery_StateProvince = null;
        string UI_Pickup_PostalCode = null;
        string UI_Delivery_PostalCode = null;
        string UI_Pickup_Country = null;
        string UI_Delivery_Country = null;
        string UI_Pickup_ContactName = null;
        string UI_Delivery_ContactName = null;
        string UI_Pickup_ContactPhone = null;
        string UI_Delivery_ContactPhone = null;
        string UI_Pickup_ContactEmail = null;
        string UI_Delivery_ContactEmail = null;

        IDictionary<string, string> TerminalinfosfromApi = new Dictionary<string, string>();
        IInvokeTerminalByPostalCodeApi InvokeAPIMethod = new InvokeTerminalByPostalCodeApi();
        IDictionary<string, string> TerminalRequestInfos = new Dictionary<string, string>();
        AddQuoteLTL quote = new AddQuoteLTL();
        WebDriverWait Wait = new WebDriverWait(GlobalVariables.webDriver, new TimeSpan(0, 0, 30));
        GetTerminalInformation _terminalInformation = new GetTerminalInformation();
        TerminalInformationModel terminalInformationdatas = null;

        [Given(@"I'm a shp\.inquiry, shp\.inquirynorates, shp\.entry, shp\.entrynorates, sales, sales management, operations, or station owner user(.*),(.*),(.*)")]
        public void GivenIMAShp_InquiryShp_InquirynoratesShp_EntryShp_EntrynoratesSalesSalesManagementOperationsOrStationOwnerUser(string usertype, string username, string password)
        {
           
            username = ConfigurationManager.AppSettings[username].ToString();
            password = ConfigurationManager.AppSettings[password].ToString();
            Report.WriteLine("Logged in User is " + usertype);

            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }
        
        [Given(@"I am on the shipment Details page of an LTL shipment(.*),(.*)")]
        public void GivenIAmOnTheShipmentDetailsPageOfAnLTLShipment(string userType, string CustomerName)
        {
            Click(attributeName_xpath, ShipmentModule_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_xpath, ShipmentList_ReferenceNumLookup_Xpath, shipmentReferenceNumber);
            Click(attributeName_xpath, ShipmentList_Referencenumber_searcharrow_Xpath);
            Click(attributeName_xpath, ShipmentListGrid_RefNumAllValues_Xpath);
            Report.WriteLine("Waiting for page load");
            GlobalVariables.webDriver.WaitForPageLoad();
        }
        
        [When(@"I click on the option to display terminal Information")]
        public void WhenIClickOnTheOptionToDisplayTerminalInformation()
        {
            Report.WriteLine("Clicking on the Terminal Information Icon");
            WaitForElementNotVisible(attributeName_id, ShipmentDetails_LoadingIcon_ID, "Loading Icon");
            Click(attributeName_xpath, ShipmentDetails_TerminalIcon_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
        }
        
        [Then(@"I should see page level loading icon")]
        public void ThenIShouldSeePageLevelLoadingIcon()
        {   
            GlobalVariables.webDriver.WaitForPageLoad();
        }
        
        [Then(@"a popup modal is launched to display the terminal information for selected record")]
        public void ThenAPopupModalIsLaunchedToDisplayTheTerminalInformationForSelectedRecord()
        {
            Report.WriteLine("Verifying the Terminal Information Modal Popup");
            VerifyElementVisible(attributeName_id, ShipmentDetails_TerminalInformationModal_Id, "Terminal Information Popup Modal");
            terminalInformationdatas = _terminalInformation.GetTerminalInformationDatas(shipmentReferenceNumber);

            Verifytext(attributeName_id, ShipmentDetails_TerminalInformationModalClosebutton_Xpath, "Terminal Information for" + terminalInformationdatas.ModalHeader);
        }
        
        [Then(@"the page level loading icon will be closed")]
        public void ThenThePageLevelLoadingIconWillBeClosed()
        {
            VerifyElementNotVisible(attributeName_id, ShipmentDetails_LoadingIcon_ID, "Loading Icon");
        }
        
        [Then(@"the modal will display the Original Terminal Fields as ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)""")]
        public void ThenTheModalWillDisplayTheOriginalTerminalFieldsAs(string name, string address1, string address2, string city, string state, string zip, string country, string contactname, string phone, string email)
        {
            Report.WriteLine("Verifying the labels present Original Terminal Information modal");

            string orgTerminalPageHeader = "Origin Terminal";
            string orgTerminalPageHeaderUI = Gettext(attributeName_id, ShipmentDetails_orgTerminalPageHeader_Id);
            Assert.AreEqual(orgTerminalPageHeader, orgTerminalPageHeaderUI);

            string orgTerminalNameUI = Gettext(attributeName_id, ShipmentDetails_orgTerminalName_Id);
            Assert.AreEqual(name, orgTerminalNameUI);
           
            string orgTerminalAddress1UI = Gettext(attributeName_id, ShipmentDetails_orgTerminalAddress1_Id);
            Assert.AreEqual(address1, orgTerminalAddress1UI);
           
            string orgTerminalAddress2UI = Gettext(attributeName_id, ShipmentDetails_orgTerminalAddress2_Id);
            Assert.AreEqual(address2, orgTerminalAddress2UI);
         
            string orgTerminalCityUI = Gettext(attributeName_id, ShipmentDetails_orgTerminalCity_Id);
            Assert.AreEqual(city, orgTerminalCityUI);
          
            string orgTerminalStateUI = Gettext(attributeName_id, ShipmentDetails_orgTerminalState_Id);
            Assert.AreEqual(state, orgTerminalStateUI);
          
            string orgTerminalZipUI = Gettext(attributeName_id, ShipmentDetails_orgTerminalZip_Id);
            Assert.AreEqual(zip, orgTerminalZipUI);
        
            string orgTerminalCountryUI = Gettext(attributeName_id, ShipmentDetails_orgTerminalCountry_Id);
            Assert.AreEqual(country, orgTerminalCountryUI);
          
            string orgTerminalContactNameUI = Gettext(attributeName_id, ShipmentDetails_orgTerminalContactName_Id);
            Assert.AreEqual(contactname, orgTerminalContactNameUI);
           
            string orgTerminalPhoneUI = Gettext(attributeName_id, ShipmentDetails_orgTerminalPhone_Id);
            Assert.AreEqual(phone, orgTerminalPhoneUI);
         
            string orgTerminalEmailUI = Gettext(attributeName_id, ShipmentDetails_orgTerminalEmail_Id);
            Assert.AreEqual(email, orgTerminalEmailUI);

            
            UI_Pickup_CarrierName = Gettext(attributeName_id, ShipmentDetails_orgTerminalName_Id);
            Assert.AreEqual(terminalInformationdatas.PickupTerminalName, UI_Pickup_CarrierName);

            UI_Pickup_Address1 = Gettext(attributeName_id, ShipmentDetails_orgTerminalAddress1_Id);
            Assert.AreEqual(terminalInformationdatas.PickupAddress1, UI_Pickup_Address1);

            UI_Pickup_Address2 = Gettext(attributeName_id, ShipmentDetails_orgTerminalAddress2_Id);
            Assert.AreEqual(terminalInformationdatas.PickupAddress2, UI_Pickup_Address2);

            UI_Pickup_City = Gettext(attributeName_id, ShipmentDetails_orgTerminalCity_Id);
            Assert.AreEqual(terminalInformationdatas.PickupCity, UI_Pickup_City);

            UI_Pickup_StateProvince = Gettext(attributeName_id, ShipmentDetails_orgTerminalState_Id);
            Assert.AreEqual(terminalInformationdatas.PickupStateProvince, UI_Pickup_StateProvince);

            UI_Pickup_PostalCode = Gettext(attributeName_id, ShipmentDetails_orgTerminalZip_Id);
            Assert.AreEqual(terminalInformationdatas.PickupPostalCode, UI_Pickup_PostalCode);

            UI_Pickup_Country = Gettext(attributeName_id, ShipmentDetails_orgTerminalCountry_Id);
            Assert.AreEqual(terminalInformationdatas.PickupCountry, UI_Pickup_Country);

            UI_Pickup_ContactName = Gettext(attributeName_id, ShipmentDetails_orgTerminalContactName_Id);
            Assert.AreEqual(terminalInformationdatas.PickupContactName, UI_Pickup_ContactName);

            UI_Pickup_ContactPhone = Gettext(attributeName_id, ShipmentDetails_orgTerminalPhone_Id).Replace("(", "").Replace(")", "");
            Assert.AreEqual(terminalInformationdatas.PickupContactPhone, UI_Pickup_ContactPhone);

            UI_Pickup_ContactEmail = Gettext(attributeName_id, ShipmentDetails_orgTerminalEmail_Id);
            Assert.AreEqual(terminalInformationdatas.PickupContactEmail, UI_Pickup_ContactEmail);
        }
        
        [Then(@"the modal will display the Destination Terminal Fields as ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)""")]
        public void ThenTheModalWillDisplayTheDestinationTerminalFieldsAs(string name, string address1, string address2, string city, string state, string zip, string country, string contactname, string phone, string email)
        {
            Report.WriteLine("Verifying the labels present Destination Terminal Information modal");

            string desTerminalPageHeader = "Destination Terminal";
            string desTerminalPageHeaderUI = Gettext(attributeName_id, ShipmentDetails_desTerminalPageHeader_Id);
            Assert.AreEqual(desTerminalPageHeader, desTerminalPageHeaderUI);

            string desTerminalNameUI = Gettext(attributeName_id, ShipmentDetails_desTerminalName_Id);
            Assert.AreEqual(name, desTerminalNameUI);

            string desTerminalAddress1UI = Gettext(attributeName_id, ShipmentDetails_desTerminalAddress1_Id);
            Assert.AreEqual(address1, desTerminalAddress1UI);

            string desTerminalAddress2UI = Gettext(attributeName_id, ShipmentDetails_desTerminalAddress2_Id);
            Assert.AreEqual(address2, desTerminalAddress2UI);

            string desTerminalCityUI = Gettext(attributeName_id, ShipmentDetails_desTerminalCity_Id);
            Assert.AreEqual(city, desTerminalCityUI);

            string desTerminalStateUI = Gettext(attributeName_id, ShipmentDetails_desTerminalState_Id);
            Assert.AreEqual(state, desTerminalStateUI);

            string desTerminalZipUI = Gettext(attributeName_id, ShipmentDetails_desTerminalZip_Id);
            Assert.AreEqual(zip, desTerminalZipUI);

            string desTerminalCountryUI = Gettext(attributeName_id, ShipmentDetails_desTerminalCountry_Id);
            Assert.AreEqual(country, desTerminalCountryUI);

            string desTerminalContactNameUI = Gettext(attributeName_id, ShipmentDetails_desTerminalContactName_Id);
            Assert.AreEqual(contactname, desTerminalContactNameUI);

            string desTerminalPhoneUI = Gettext(attributeName_id, ShipmentDetails_desTerminalPhone_Id).Replace("(", "").Replace(")", "");
            Assert.AreEqual(phone, desTerminalPhoneUI);

            string desTerminalEmailUI = Gettext(attributeName_id, ShipmentDetails_desTerminalEmail_Id);
            Assert.AreEqual(email, desTerminalEmailUI);

            UI_Delivery_CarrierName = Gettext(attributeName_id, ShipmentDetails_desTerminalName_Id);
            Assert.AreEqual(terminalInformationdatas.DeliveryTerminalName, UI_Delivery_CarrierName);

            UI_Delivery_Address1 = Gettext(attributeName_id, ShipmentDetails_desTerminalAddress1_Id);
            Assert.AreEqual(terminalInformationdatas.DeliveryAddress1, UI_Delivery_Address1);

            UI_Delivery_Address2 = Gettext(attributeName_id, ShipmentDetails_desTerminalAddress2_Id);
            Assert.AreEqual(terminalInformationdatas.DeliveryAddress2, UI_Delivery_Address2);

            UI_Delivery_City = Gettext(attributeName_id, ShipmentDetails_desTerminalCity_Id);
            Assert.AreEqual(terminalInformationdatas.DeliveryCity, UI_Delivery_City);

            UI_Delivery_StateProvince = Gettext(attributeName_id, ShipmentDetails_desTerminalState_Id);
            Assert.AreEqual(terminalInformationdatas.DeliveryStateProvince, UI_Delivery_StateProvince);

            UI_Delivery_PostalCode = Gettext(attributeName_id, ShipmentDetails_desTerminalZip_Id);
            Assert.AreEqual(terminalInformationdatas.DeliveryPostalCode, UI_Delivery_PostalCode);

            UI_Delivery_Country = Gettext(attributeName_id, ShipmentDetails_desTerminalCountry_Id);
            Assert.AreEqual(terminalInformationdatas.DeliveryCountry, UI_Delivery_Country);

            UI_Delivery_ContactName = Gettext(attributeName_id, ShipmentDetails_desTerminalContactName_Id);
            Assert.AreEqual(terminalInformationdatas.DeliveryContactName, UI_Delivery_ContactName);

            UI_Delivery_ContactPhone = Gettext(attributeName_id, ShipmentDetails_desTerminalPhone_Id);
            Assert.AreEqual(terminalInformationdatas.DeliveryContactPhone, UI_Delivery_ContactPhone);

            UI_Delivery_ContactEmail = Gettext(attributeName_id, ShipmentDetails_desTerminalEmail_Id);
            Assert.AreEqual(terminalInformationdatas.DeliveryContactEmail, UI_Delivery_ContactEmail);
            Report.WriteLine("API and PageFields data are verified successfully");
        }

        [Then(@"I will see (.*) button")]
        public void ThenIWillSeeButton(string closebutton)
        {
            Report.WriteLine("Verifying the Close button in Terminal Information Modal");
            VerifyElementPresent(attributeName_xpath, ShipmentDetails_TerminalInformationModalClosebutton_Xpath, "Close button");
            Verifytext(attributeName_xpath, ShipmentDetails_TerminalInformationModalClosebutton_Xpath, "Close");
        }



        [When(@"I am on the Shipment Details page of an LTL shipment(.*),(.*)")]
        public void WhenIAmOnTheShipmentDetailsPageOfAnLTLShipment(string userType, string CustomerName)
        {
            GivenIAmOnTheShipmentDetailsPageOfAnLTLShipment(userType, CustomerName);
        }

        [Then(@"I will have an option to display Terminal Information")]
        public void ThenIWillHaveAnOptionToDisplayTerminalInformation()
        {
            Report.WriteLine("Verifying Terminal Information Icon");
            VerifyElementPresent(attributeName_xpath, ShipmentDetails_TerminalIcon_Xpath, "Terminal Information Icon");
        }

        [Given(@"I clicked on the Terminal Info Link")]
        public void GivenIClickedOnTheTerminalInfoLink()
        {
            Report.WriteLine("Clicking on the Terminal Information Icon");
            Click(attributeName_xpath, ShipmentDetails_TerminalIcon_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I am in Terminal Information modal")]
        public void GivenIAmInTerminalInformationModal()
        {
            Report.WriteLine("Verifying the Terminal Information Modal Popup");
            VerifyElementVisible(attributeName_id, ShipmentDetails_TerminalInformationModal_Id, "Terminal Information Popup Modal");

        }

        [When(@"I click Close button")]
        public void WhenIClickCloseButton()
        {
            Click(attributeName_xpath, ShipmentDetails_TerminalInformationModalClosebutton_Xpath);
            Thread.Sleep(2000);
        }

        [Then(@"the Terminal Information modal will close")]
        public void ThenTheTerminalInformationModalWillClose()
        {
            Report.WriteLine("Verifying Element Not Visible");
            VerifyElementNotVisible(attributeName_id, ShipmentDetails_TerminalInformationModal_Id, "Terminal Information Popup Modal");
        }

        
    }
}
