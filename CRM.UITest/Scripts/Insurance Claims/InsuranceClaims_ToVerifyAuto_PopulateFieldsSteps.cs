using CRM.UITest.CommonMethods;
using CRM.UITest.CsaServiceReference;
using CRM.UITest.Helper.Common;
using CRM.UITest.Helper.Implementations.CustomReportXML;
using CRM.UITest.Helper.Implementations.ShipmentList;
using CRM.UITest.Helper.ViewModel.Shipment;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Net.Http;
using System.Xml.Linq;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Insurance_Claims
{
    [Binding]
    public class InsuranceClaims_ToVerifyAuto_PopulateFieldsSteps : InsuranceClaim
    {

        List<ShipmentListViewModel> Sdata;
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();

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


        [Given(@"I am a shp\.inquiry, shp\.inquirynorates, shp\.entry, shp\.entrynorates, Sales, Sales Management, Operations, Station Owner, or Claims Specialist user")]
        public void GivenIAmAShp_InquiryShp_InquirynoratesShp_EntryShp_EntrynoratesSalesSalesManagementOperationsStationOwnerOrClaimsSpecialistUser()
        {
            string Username = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
            string Password = ConfigurationManager.AppSettings["ExternalUserPassword"].ToString();

            CrmLogin.LoginToCRMApplication(Username, Password);
        }


        [Given(@"I am a External User-shp\.inquiry")]
        public void GivenIAmAExternalUser_Shp_Inquiry()
        {
            string Username = ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();
            string Password = ConfigurationManager.AppSettings["ExternalUserPassword"].ToString();

            CrmLogin.LoginToCRMApplication(Username, Password);
        }


        [Given(@"I am a Internal User-Operational user")]
        public void GivenIAmAInternalUser_OperationalUser()
        {
            string Username = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
            string Password = ConfigurationManager.AppSettings["password-crmOperation"].ToString();

            CrmLogin.LoginToCRMApplication(Username, Password);
        }



        [When(@"I receive the data for the submitted reference number from MG (.*)")]
        public List<ShipmentListViewModel> WhenIReceiveTheDataForTheSubmittedReferenceNumberFromMG(string BOLNumber)
        {

            BuildHttpClient objBuildHttpClient = new BuildHttpClient();
            HttpClient headers = objBuildHttpClient.BuildHttpClientWithHeaders("Admin", "application/xml");
            GetCustomReportXML _CustXml = new GetCustomReportXML();
            XElement resuestXML = _CustXml.getListExtractRequestXML(BOLNumber);

            string uri = $"MercuryGate/ListScreenExtract";
            ShipmentListScreen Slist = new ShipmentListScreen();
            Sdata = Slist.CallListScreenAutopopulate(uri, headers, resuestXML);


            actualPickup = Sdata[1].ActualPickup;
            actualDelivery = Sdata[1].ActualDelivery;
            primaryReference = Sdata[1].PrimaryReference;
            carrierName = Sdata[1].CarrierName;
            pRONumber = Sdata[1].PRONumber;
            originName = Sdata[1].OriginName;
            originAddress = Sdata[1].OriginAddress;
            originAddress2 = Sdata[1].OriginAddress2;
            originZip = Sdata[1].OriginZip;
            originCountry = Sdata[1].OriginCountry;
            originCity = Sdata[1].OriginCity;
            originState = Sdata[1].OriginState;
            destinationName = Sdata[1].DestinationName;
            destinationAddress = Sdata[1].DestinationAddress;
            destinationAddress2 = Sdata[1].DestinationAddress2;
            destinationZip = Sdata[1].DestinationZip;
            destinationCountry = Sdata[1].DestinationCountry;
            destinationCity = Sdata[1].DestinationCity;
            destinationState = Sdata[1].DestinationState;
            internalID = Sdata[1].InternalID;

            return Sdata;
        }


        [When(@"I receive the data for the submitted reference number from CSA (.*)")]
        public void WhenIReceiveTheDataForTheSubmittedReferenceNumberFromCSA(string csaRefNo)
        {
            ShipmentInquiryOutputV3 result = null;

            using (ShipmentsSoapClient csaClient = new ShipmentsSoapClient())
            {
              
                result = csaClient.ShipmentInquiryV3("", csaRefNo);

                //Extracting Data and storing in variable
                actualPickup = result.ShipInqOutput[0].ShipmentDate;
                primaryReference = result.ShipInqOutput[0].Housebill;        
                int costCount = result.ShipInqOutput[0].Costs.Length;
                if (costCount > 0)
                {
                    carrierName = result.ShipInqOutput[0].Costs[0].VendorName;
                }else
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
            }
        }

     

        [Given(@"I am on Submit a Claim page")]
        public void GivenIAmOnSubmitAClaimPage()
        {
            Click(attributeName_id, ClaimsIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, Submit_A_Claim_button_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, Submit_A_Claim_Page_Header_Text_Xpath, "Submit a Claim");
            VerifyElementPresent(attributeName_xpath, Submit_A_Claim_Page_Header_Text_Xpath, "Submit a Claim");
        }


        [Given(@"I have entered a Invalid DLSW BOL\# (.*)")]
        public void GivenIHaveEnteredAInvalidDLSWBOL(string InvalidDLSWBOLNumber)
        {
            SendKeys(attributeName_id, Enter_DLSW_BOLNumber_Textbox_Id, InvalidDLSWBOLNumber);
        }

        [Given(@"I received a message for Invalid DLSW BOL\# (.*)")]
        public void GivenIReceivedAMessageForInvalidDLSWBOL(string InvalidDLSWBOLNumber)
        {
            SendKeys(attributeName_id, Enter_DLSW_BOLNumber_Textbox_Id, InvalidDLSWBOLNumber);
            Click(attributeName_id, PopulateForm_button_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Verifytext(attributeName_xpath, InvalidBolNumber_Text_Xpath, "Invalid DLSW BOL#. Please enter data manually.");
        }

        [Given(@"I am Sales Management User")]
        public void GivenIAmSalesManagementUser()
        {
            string username = ConfigurationManager.AppSettings["username-SalesManager"].ToString();
            string password = ConfigurationManager.AppSettings["password-SalesManager"].ToString();
            CommonMethodsCrm crmLogin = new CommonMethodsCrm();
            crmLogin.LoginToCRMApplication(username, password);
        }

        [When(@"I clicked on the Populate Form button")]
        public void WhenIClickedOnThePopulateFormButton()
        {
            Click(attributeName_id, PopulateForm_button_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [When(@"I entered new DLSW BOL\# (.*)")]
        public void WhenIEnteredNewDLSWBOL(string DLSWBOLNumber)
        {
            SendKeys(attributeName_id, Enter_DLSW_BOLNumber_Textbox_Id, DLSWBOLNumber);
        }



        [Then(@"I will see the text message notifying user for Invalid BOL number")]
        public void ThenIWillSeeTheTextMessageNotifyingUserForInvalidBOLNumber()
        {
            Verifytext(attributeName_xpath, InvalidBolNumber_Text_Xpath, "Invalid DLSW BOL#. Please enter data manually.");
        }

        [Then(@"the Invalid BOL number text message will be removed")]
        public void ThenTheInvalidBOLNumberTextMessageWillBeRemoved()
        {
            scrollPageup();
            VerifyElementNotVisible(attributeName_xpath, InvalidBolNumber_Text_Xpath, "Invalid DLSW BOL#. Please enter data manually.");
        }

        [When(@"I entered any DLSW Refnumber(.*)")]
        public void WhenIEnteredAnyDLSWRefnumber(string DLSWRefnumber)
        {
            SendKeys(attributeName_id, DLSWBillOfLading_Textbox_Id, DLSWRefnumber);
        }

        [When(@"I entered Carrier Name(.*)")]
        public void WhenIEnteredCarrierName(string carrierName)
        {
            SendKeys(attributeName_id, CarrierName_Textbox_Id, carrierName);
        }


        [When(@"I entered DLSW Ship Date")]
        public void WhenIEnteredDLSWShipDate()
        {
            Click(attributeName_id, DLSW_BOLDate_Field_Id);
            DatePickerFromCalander(attributeName_xpath, DLSW_BOLDate_Field_Values_Xpath, -1, DLSW_BOLDate_Field_LeftArrow_Xpath);
        }

        [When(@"I entered Carrier Pro Date")]
        public void WhenIEnteredCarrierProDate()
        {
            Click(attributeName_id, CarrierProDate_Field_Id);
            DatePickerFromCalander(attributeName_xpath, CarrierProDate_Field_Values_Xpath, -1, CarrierProDate_Field_LeftArrow_Xpath);
        }

        [When(@"I entered Shipper Name(.*)")]
        public void WhenIEnteredShipperName(string Name)
        {
            SendKeys(attributeName_id, Shipper_Name_Textbox_Id, Name);
        }

        [When(@"I entered Shipper Address(.*)")]
        public void WhenIEnteredShipperAddress(string Address)
        {
            scrollpagedown();
            WaitForElementVisible(attributeName_classname, Shipper_Address_Textbox_Class, "Shipper Address field");
            SendKeys(attributeName_classname, Shipper_Address_Textbox_Class, Address);
        }

        [When(@"I have entered Shipper Address two (.*)")]
        public void WhenIHaveEnteredShipperAddressTwo(string Address)
        {
            scrollpagedown();
            WaitForElementVisible(attributeName_id, Shipper_Address2_Textbox_Id, "Shipper Address2 field");
            SendKeys(attributeName_id, Shipper_Address2_Textbox_Id, Address);
        }


        [When(@"I have entered Shipper Zip/Postal (.*)")]
        public void WhenIHaveEnteredShipperZipPostal(string zip)
        {
            scrollpagedown();
            WaitForElementVisible(attributeName_id, Shipper_Zip_Postal_Textbox_Id, "Shipper zip field");
            SendKeys(attributeName_id, Shipper_Zip_Postal_Textbox_Id, zip);
        }

        [When(@"I have entered Shipper Country (.*)")]
        public void WhenIHaveEnteredShipperCountry(string country)
        {
            scrollpagedown();
            WaitForElementVisible(attributeName_xpath, Shipper_Country_dropdown_Xpath, "Shipper Country dropdown");
            Click(attributeName_xpath, Shipper_Country_dropdown_Xpath);
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(Shipper_Country_dropdownValue_Xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == country)
                {
                    DropDownList[i].Click();
                    break;
                }
            }
        }

        [When(@"I have entered Shipper State (.*)")]
        public void WhenIHaveEnteredShipperState(string state)
        {
            scrollpagedown();
            WaitForElementVisible(attributeName_xpath, Shipper_State_Province_dropdown_Xpath, "Shipper State dropdown");
            Click(attributeName_xpath, Shipper_State_Province_dropdown_Xpath);
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(Shipper_State_Province_dropdown_Value_Xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == state)
                {
                    DropDownList[i].Click();
                    break;
                }
            }
        }

        [When(@"I have entered Shipper City (.*)")]
        public void WhenIHaveEnteredShipperCity(string city)
        {
            scrollpagedown();
            WaitForElementVisible(attributeName_id, Shipper_City_Textbox_Id, "Shipper city field");
            SendKeys(attributeName_id, Shipper_City_Textbox_Id, city);
        }

        [When(@"I entered Consignee Name(.*)")]
        public void WhenIEnteredConsigneeName(string Name)
        {
            SendKeys(attributeName_id, Consignee_Name_Textbox_Id, Name);
        }

        [When(@"I entered Consignee Address(.*)")]
        public void WhenIEnteredConsigneeAddress(string Address)
        {
            scrollpagedown();
            WaitForElementVisible(attributeName_id, Consignee_Address_Textbox_Id, "Consignee Address Field");
            SendKeys(attributeName_id, Consignee_Address_Textbox_Id, Address);
        }

        [When(@"I have entered Consignee Address two (.*)")]
        public void WhenIHaveEnteredConsigneeAddressTwo(string Address)
        {
            scrollpagedown();
            WaitForElementVisible(attributeName_id, Consignee_Address2_Textbox_Id, "Address2 field");
            SendKeys(attributeName_id, Consignee_Address2_Textbox_Id, Address);
        }

        [When(@"I have entered Consignee Zip/Postal (.*)")]
        public void WhenIHaveEnteredConsigneeZipPostal(string zip)
        {
            scrollpagedown();
            WaitForElementVisible(attributeName_id, Consignee_Zip_Postal_Textbox_Id, "Consignee zip field");
            SendKeys(attributeName_id, Consignee_Zip_Postal_Textbox_Id, zip);
        }

        [When(@"I have entered Consignee Country (.*)")]
        public void WhenIHaveEnteredConsigneeCountry(string country)
        {
            scrollpagedown();
            WaitForElementVisible(attributeName_xpath, Consignee_Country_dropdown_Xpath, "Country dropdown");
            Click(attributeName_xpath, Consignee_Country_dropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, Consignee_Country_dropdownValue_Xpath, country);
        }

        [When(@"I have entered Consignee State (.*)")]
        public void WhenIHaveEnteredConsigneeState(string state)
        {
            scrollpagedown();
            WaitForElementVisible(attributeName_xpath, Consignee_State_Province_dropdown_Xpath, "State dropdown");
            Click(attributeName_xpath, Consignee_State_Province_dropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, Consignee_State_Province_dropdown_Value_Xpath, state);
        }

        [When(@"I have entered Consignee City (.*)")]
        public void WhenIHaveEnteredConsigneeCity(string city)
        {
            scrollpagedown();
            WaitForElementVisible(attributeName_id, Consignee_City_Textbox_Id, "city textbox");
            SendKeys(attributeName_id, Consignee_City_Textbox_Id, city);
        }


        [Given(@"I have entered a valid DLSW BOL\# (.*)")]
        public void GivenIHaveEnteredAValidDLSWBOL(string DLSWBOLNumber)
        {

            SendKeys(attributeName_id, Enter_DLSW_BOLNumber_Textbox_Id, DLSWBOLNumber);
        }

        [Given(@"I click on the Populate Form button,")]
        public void GivenIClickOnThePopulateFormButton()
        {
            Click(attributeName_id, PopulateForm_button_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Then(@"the Carrier Information Section fields  DLSW Bill of Lading \# ,DLSW BOL Date,Carrier Name,Carrier PRO,Carrier PRO Date will be populated")]
        public void ThenTheCarrierInformationSectionFieldsDLSWBillOfLadingDLSWBOLDateCarrierNameCarrierPROCarrierPRODateWillBePopulated()
        {
            string dLSWBillOfLading_UI = GetValue(attributeName_id, DLSWBillOfLading_Textbox_Id, "value");
            string[] dlswdate = actualPickup.Split(' ');
            string dlswdatedate_APIresponse = dlswdate[0];

            string carrierProDate_UI = GetValue(attributeName_id, CarrierProDate_Field_Id, "value");
            if (dLSWBillOfLading_UI.Length >= 11)
            {
               

                 Assert.AreEqual(primaryReference.Remove(11, 6).ToLower(), dLSWBillOfLading_UI.ToLower());
                 Assert.AreEqual(carrierProDate_UI.ToLower(), dlswdatedate_APIresponse.ToLower());

            }
            else
            {
                DateTime result = DateTime.ParseExact(carrierProDate_UI, "d", CultureInfo.InvariantCulture);
                string carrierProDate_UIConvert = result.ToString().Remove(9, 12);

                Assert.AreEqual(primaryReference.ToLower(), dLSWBillOfLading_UI.ToLower());
                Assert.AreEqual(carrierProDate_UIConvert.ToLower(), dlswdatedate_APIresponse.ToLower());
               
            }

            string carrierName_UI = GetValue(attributeName_id, CarrierName_Textbox_Id, "value");
            Assert.AreEqual(carrierName.ToLower(), carrierName_UI.ToLower());

            string carrierPro_UI = GetValue(attributeName_id, CarrierPro_Textbox_Id, "value");
            Assert.AreEqual(pRONumber.ToLower(), carrierPro_UI.ToLower());
        }

        [Then(@"the Shipper Information Section Name,Address,City,State,Zip,Country will be populated")]
        public void ThenTheShipperInformationSectionNameAddressCityStateZipCountryWillBePopulated()
        {
            string shipper_Name_UI = GetValue(attributeName_id, Shipper_Name_Textbox_Id, "value");
            Assert.AreEqual(originName.ToLower(), shipper_Name_UI.ToLower());

            string shipper_Address_UI = GetValue(attributeName_id, Shipper_Address_Textbox_Id, "value");
            Assert.AreEqual(originAddress.ToLower(), shipper_Address_UI.ToLower());

            string shipper_Address2_UI = GetValue(attributeName_id, Shipper_Address2_Textbox_Id, "value");
            Assert.AreEqual(originAddress2.ToLower(), shipper_Address2_UI.ToLower());

            string shipper_Zip_Postal_UI = GetValue(attributeName_id, Shipper_Zip_Postal_Textbox_Id, "value");
            Assert.AreEqual(originZip.ToLower(), shipper_Zip_Postal_UI.ToLower());

            if (originCountry == "USA" || originCountry.ToLower() == "US".ToLower())
            {
                string shipper_Country_UI = Gettext(attributeName_xpath, Shipper_Country_dropdown_Xpath);
                Assert.AreEqual("United States", shipper_Country_UI);
            }

            else
            {
                string shipper_Country_UI = Gettext(attributeName_xpath, Shipper_Country_dropdown_Xpath);
                Assert.AreEqual(originCountry.ToLower(), shipper_Country_UI.ToLower());
            }

            string shipper_City_UI = GetValue(attributeName_id, Shipper_City_Textbox_Id, "value");
            Assert.AreEqual(originCity.ToLower(), shipper_City_UI.ToLower());

            string shipper_State_Province_dropdown = Gettext(attributeName_xpath, Shipper_State_Province_dropdown_Xpath);
            Assert.AreEqual(originState.ToLower(), shipper_State_Province_dropdown.ToLower());
        }

        [Then(@"the Consignee Information Section Name,Address,City,State,Zip,Country will be populated")]
        public void ThenTheConsigneeInformationSectionNameAddressCityStateZipCountryWillBePopulated()
        {
            string consignee_Name_UI = GetValue(attributeName_id, Consignee_Name_Textbox_Id, "value");
            Assert.AreEqual(destinationName.ToLower(), consignee_Name_UI.ToLower());

            string consignee_Address_UI = GetValue(attributeName_id, Consignee_Address_Textbox_Id, "value");
            Assert.AreEqual(destinationAddress.ToLower(), consignee_Address_UI.ToLower());

            string consignee_Address2_UI = GetValue(attributeName_id, Consignee_Address2_Textbox_Id, "value");
            Assert.AreEqual(destinationAddress2.ToLower(), consignee_Address2_UI.ToLower());

            string consignee_Zip_Postal_UI = GetValue(attributeName_id, Consignee_Zip_Postal_Textbox_Id, "value");
            Assert.AreEqual(destinationZip.ToLower(), consignee_Zip_Postal_UI.ToLower());

            if (destinationCountry == "USA" || destinationCountry.ToLower() == "US".ToLower())
            {
                string consignee_Country_UI = Gettext(attributeName_xpath, Consignee_Country_dropdown_Xpath);
                Assert.AreEqual("United States", consignee_Country_UI);
            }

            else
            {
                string consignee_Country_UI = Gettext(attributeName_xpath, Consignee_Country_dropdown_Xpath);
                Assert.AreEqual(destinationCountry.ToLower(), consignee_Country_UI.ToLower());
            }

            string consignee_City_UI = GetValue(attributeName_id, Consignee_City_Textbox_Id, "value");
            Assert.AreEqual(destinationCity.ToLower(), consignee_City_UI.ToLower());

            string consignee_State_Province_dropdown = Gettext(attributeName_xpath, Consignee_State_Province_dropdown_Xpath);
            Assert.AreEqual(destinationState.ToLower(), consignee_State_Province_dropdown.ToLower());
        }

        [When(@"I entered Carrier Pro field(.*)")]
        public void WhenIEnteredCarrierProField(string CarrierProvalue)
        {
            SendKeys(attributeName_id, CarrierPro_Textbox_Id, CarrierProvalue);
        }


    }
}