using CRM.UITest.CommonMethods;
using CRM.UITest.Helper;
using CRM.UITest.Helper.Interfaces;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using System.Xml;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Results
{
    [Binding]
    public class _110721_TerminalInformation_ShipmentRateResultsSteps : AddShipments
    {
        CommonMethodsCrm crmLogin = new CommonMethodsCrm();
        string SCAC = string.Empty;
        string Pickup_countryCode = "USA";
        string Pickup_postalCode = "33136";
        string Pickup_serviceMethod = "LTL";
        string Pickup_serviceType = "STANDARD";
        string Pickup_terminalType = "PICKUP";
        string Delivery_countryCode = "USA";
        string Delivery_postalCode = "85282";
        string Delivery_serviceMethod = "LTL";
        string Delivery_serviceType = "STANDARD";
        string Delivery_terminalType = "DELIVERY";

        string UI_Pickup_CarrierName = string.Empty;
        string UI_Delivery_CarrierName = string.Empty;
        string UI_Pickup_Address1 = string.Empty;
        string UI_Delivery_Address1 = string.Empty;
        string UI_Pickup_Address2 = string.Empty;
        string UI_Delivery_Address2 = string.Empty;
        string UI_Pickup_City = string.Empty;
        string UI_Delivery_City = string.Empty;
        string UI_Pickup_StateProvince = string.Empty;
        string UI_Delivery_StateProvince = string.Empty;
        string UI_Pickup_PostalCode = string.Empty;
        string UI_Delivery_PostalCode = string.Empty;
        string UI_Pickup_Country = string.Empty;
        string UI_Delivery_Country = string.Empty;
        string UI_Pickup_ContactName = string.Empty;
        string UI_Delivery_ContactName = string.Empty;
        string UI_Pickup_ContactPhone = string.Empty;
        string UI_Delivery_ContactPhone = string.Empty;
        string UI_Pickup_ContactEmail = string.Empty;
        string UI_Delivery_ContactEmail = string.Empty;
        string Account = "ZZZ - GS Customer Test";
        string CarrierName = string.Empty;


        IDictionary<string, string> TerminalinfosfromApi = new Dictionary<string, string>();
        IInvokeTerminalByPostalCodeApi InvokeAPIMethod = new InvokeTerminalByPostalCodeApi();
        AddQuoteLTL quote = new AddQuoteLTL();
        WebDriverWait Wait = new WebDriverWait(GlobalVariables.webDriver, new TimeSpan(0, 0, 30));

        [Given(@"I am a user who have access to Shipments Module '(.*)' '(.*)'")]
        public void GivenIAmAUserWhoHaveAccessToShipmentsModule(string userName, string passWord)
        {
            string username = ConfigurationManager.AppSettings[userName].ToString();
            string password = ConfigurationManager.AppSettings[passWord].ToString();
            crmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"I am on the Add Shipment LTL page for an external user")]
        public void GivenIAmOnTheAddShipmentLTLPageForAnExternalUser()
        {
            Click(attributeName_cssselector, ShipmentsIcon_css);
            Report.WriteLine("Clicked on Shipments icon");
            GlobalVariables.webDriver.WaitForPageLoad();

            Click(attributeName_id, AddShipment_Button_id);
            Report.WriteLine("Clicked on Add Shipment button");
            GlobalVariables.webDriver.WaitForPageLoad();

            Click(attributeName_id, AddShipmentLTL_Button_Id);
            Report.WriteLine("Clicked on LTL tile on Add shipment page");
            GlobalVariables.webDriver.WaitForPageLoad();
            Verifytext(attributeName_xpath, AddShipment_PageTitle_xpath, "Add Shipment (LTL)");
            Report.WriteLine("Navigated to Add Shipment LTL page");
        }

        [Given(@"I am on the Add Shipment LTL page for an internal user")]
        public void GivenIAmOnTheAddShipmentLTLPageForAnInternalUser()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ShipmentIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, AllCustomerDropdown_Selection_Internal_Xpath);
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentListInternal_CustDropdownVal_Xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == Account)
                {
                    DropDownList[i].Click();
                    break;
                }
            }
            Report.WriteLine("Customer is been selected from the dropdown");
            Click(attributeName_id, AddShipmentButtionInternal_Id);
            Report.WriteLine("Clicked on Add shipment button");
            Click(attributeName_id, AddShipmentLTL_Button_Id);
            Report.WriteLine("Clicked on LTL tile on Add shipment page");
            Verifytext(attributeName_xpath, AddShipment_PageTitle_xpath, "Add Shipment (LTL)");
            Report.WriteLine("Navigated to Shipment list page");
        }

        [Given(@"I have entered all required information on Add Shipment LTL page")]
        public void GivenIHaveEnteredAllRequiredInformationOnAddShipmentLTLPage()
        {
            Click(attributeName_id, ShippingFrom_ClearAddress_Id);
            SendKeys(attributeName_id, ShippingFrom_LocationName_Id, "test");
            SendKeys(attributeName_id, ShippingFrom_LocationAddressLine1_Id, "Address");
            SendKeys(attributeName_id, OriginZip_Id, "33126");
            Click(attributeName_id, ShippingTo_ClearAddress_Id);
            SendKeys(attributeName_id, ShippingTo_LocationName_Id, "testing");
            SendKeys(attributeName_id, ShippingTo_LocationAddressLine1_Id, "addressdest");
            SendKeys(attributeName_id, destinationZip_Id, "85282");
            scrollpagedown();
            Click(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            MoveToElement(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id);
            scrollpagedown();
            Click(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id);
            Thread.Sleep(5000);
            Click(attributeName_xpath, ShipmentSelectIten_Xpath);
            scrollpagedown();
            SendKeys(attributeName_id, FreightDesp_FirstItem_Quantity_Id, "1");
            SendKeys(attributeName_id, FreightDesp_FirstItem_Weight_Id, "1");
            SendKeys(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id, "Description");
            Report.WriteLine("Passed values to Add Shipment LTL page");
        }

        [Given(@"I have clicked on the View Rates button")]
        public void GivenIHaveClickedOnTheViewRatesButton()
        {
            Click(attributeName_xpath, ViewRatesButton_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Clicked on View Rates button");
        }

        [When(@"I arrive on Shipment Results LTL page")]
        public void WhenIArriveOnShipmentResultsLTLPage()
        {
            VerifyElementPresent(attributeName_xpath, ShipResults_PageHeaderText_Relativexpath, "Shipment Results (LTL)");
            Report.WriteLine("Navigated to Shipment Results page");
        }

        [Given(@"I am on shipment results LTL page for an external user")]
        public void GivenIAmOnShipmentResultsLTLPageForAnExternalUser()
        {
            GivenIAmOnTheAddShipmentLTLPageForAnExternalUser();
            GivenIHaveEnteredAllRequiredInformationOnAddShipmentLTLPage();
            GivenIHaveClickedOnTheViewRatesButton();
            WhenIArriveOnShipmentResultsLTLPage();
            Report.WriteLine("Navigated to Shipment Results page");
        }

        [Given(@"I am on shipment results LTL page for an internal user")]
        public void GivenIAmOnShipmentResultsLTLPageForAnInternalUser()
        {
            GivenIAmOnTheAddShipmentLTLPageForAnInternalUser();
            GivenIHaveEnteredAllRequiredInformationOnAddShipmentLTLPage();
            GivenIHaveClickedOnTheViewRatesButton();
            WhenIArriveOnShipmentResultsLTLPage();
            CarrierName = Gettext(attributeName_xpath, ShipmentResultsCarrierName_Xpath);
            Report.WriteLine("Navigated to Shipment Results page");
        }


        [When(@"I click on Terminal Info Link for a specific carrier rate on Shipment Results page")]
        public void WhenIClickOnTerminalInfoLinkForASpecificCarrierRateOnShipmentResultsPage()
        {
            Click(attributeName_xpath, ShipmentResultTerminalLink_Xpath);
            IWebElement TerminalElement = GlobalVariables.webDriver.FindElement(By.XPath(ShipmentResultTerminalLink_Xpath));
            SCAC = TerminalElement.GetAttribute("data-scaccode");
            Report.WriteLine("Clicked on Terminal Infor Link");
        }

        [Given(@"I am on Terminal Information modal")]
        public void GivenIAmOnTerminalInformationModal()
        {
            VerifyElementPresent(attributeName_xpath, ShipmentResultsTerminalModalHeader_Xpath, "Modal");
            Report.WriteLine("Terminal Information modal is opened");
        }

        [Given(@"I clicked on Terminal Info Link for a specific carrier rate on Shipment Results page")]
        public void GivenIClickedOnTerminalInfoLinkForASpecificCarrierRateOnShipmentResultsPage()
        {
            Click(attributeName_xpath, ShipmentResultTerminalLink_Xpath);
            Report.WriteLine("Clicked on Terminal Infor Link");
        }

        [When(@"I click on Close button from the Terminal Information modal")]
        public void WhenIClickOnCloseButtonFromTheTerminalInformationModal()
        {
            WaitForElementVisible(attributeName_xpath, ShipmentResultsTerminalPopupCloseButton_Xpath,"Close Button");
            Click(attributeName_xpath, ShipmentResultsTerminalPopupCloseButton_Xpath);
            Report.WriteLine("Clicked on Close button from the Terminal Information modal");
        }
        
        [Then(@"I will see a link on each carrier rate labeled '(.*)' on the Shipment results screen")]
        public void ThenIWillSeeALinkOnEachCarrierRateLabeledOnTheShipmentResultsScreen(string TerminalInfo)
        {
            IList<IWebElement> TerminalInfoList = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentResultsCarriers_Xpath));
            for (int i = 1; i < TerminalInfoList.Count; i++)
            {
                string ActaulTerminalValue = Gettext(attributeName_xpath, "//div[@id='ShipmentResultTable_wrapper']//tr[" + i + "]//td[3]//a[1]");
                if (ActaulTerminalValue.Equals(TerminalInfo))
                {
                    Report.WriteLine("Terminal Info link is present");
                    bool elementStatus = IsElementEnabled(attributeName_xpath, "//div[@id='ShipmentResultTable_wrapper']//tr[" + i + "]//td[3]//a[1]", TerminalInfo);
                    if (elementStatus is true)
                    {
                        Report.WriteLine("Terminal Info link is clickable");
                    }
                    else
                    {
                        Report.WriteFailure("Terminal Info link is not clickable");
                    }
                }
                else
                {
                    Report.WriteFailure("Terminal Info link is not present");
                }
            }
        }

        [Then(@"A popup modal is launched that displays the terminal information for selected record on Shipment Results page")]
        public void ThenAPopupModalIsLaunchedThatDisplaysTheTerminalInformationForSelectedRecordOnShipmentResultsPage()
        {
            WaitForElementVisible(attributeName_xpath, ShipmentResultsTerminalModalHeader_Xpath,"Modal Popup");
            string getCarrierNameTerminalModalHeader = Gettext(attributeName_xpath, ShipmentResultsTerminalModalHeader_Xpath);
            if (getCarrierNameTerminalModalHeader.Contains("Terminal Information for " + CarrierName))
            {
                Report.WriteLine("Modal Title is displayed with the carrier name");
            }
            else
            {
                Report.WriteFailure("Modal Title is not displayed with the carrier name");
            }
              
            string requestXml = "<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:web='http://webservices.smc.com' xmlns:ter='http://terminalsbypostalcode.requests.objects.webservice.carrierconnect.smc.com'><soapenv:Header><web:AuthenticationToken><web:licenseKey>6Twv0Ozm4mOA</web:licenseKey><web:password>BZT4ia5z</web:password><web:username>dlswintegration@rrd.com</web:username></web:AuthenticationToken></soapenv:Header><soapenv:Body><web:TerminalsByPostalCode><web:TerminalsByPostalCodeRequest><ter:arrayTerminalByPostalCode><!--Zero or more repetitions:--><ter:TerminalByPostalCode><ter:SCAC>" + SCAC + "</ter:SCAC><ter:countryCode>" + Pickup_countryCode + "</ter:countryCode><ter:postalCode>" + Pickup_postalCode + "</ter:postalCode><ter:serviceMethod>" + Pickup_serviceMethod + "</ter:serviceMethod><ter:serviceType>" + Pickup_serviceType + "</ter:serviceType><ter:terminalType>" + Pickup_terminalType + "</ter:terminalType></ter:TerminalByPostalCode><ter:TerminalByPostalCode><ter:SCAC>" + SCAC + "</ter:SCAC><ter:countryCode>" + Delivery_countryCode + "</ter:countryCode><ter:postalCode>" + Delivery_postalCode + "</ter:postalCode><ter:serviceMethod>" + Delivery_serviceMethod + "</ter:serviceMethod><ter:serviceType>" + Delivery_serviceType + "</ter:serviceType><ter:terminalType>" + Delivery_terminalType + "</ter:terminalType></ter:TerminalByPostalCode></ter:arrayTerminalByPostalCode></web:TerminalsByPostalCodeRequest></web:TerminalsByPostalCode></soapenv:Body></soapenv:Envelope>";
            string error = string.Empty;
            XmlDocument xmlDoc = InvokeAPIMethod.InvokeCarrierTerminalInformation(requestXml, out error);
            TerminalinfosfromApi = InvokeAPIMethod.getTerminalinfomethod(xmlDoc);
            IList<IWebElement> TerminalinfosfromPage = GlobalVariables.webDriver.FindElements(By.XPath("//div[@class='col-lg-8']/p"));
            UI_Pickup_CarrierName = TerminalinfosfromPage[0].Text.ToString();
            UI_Delivery_CarrierName = TerminalinfosfromPage[1].Text.ToString();
            UI_Pickup_Address1 = TerminalinfosfromPage[2].Text.ToString();
            UI_Delivery_Address1 = TerminalinfosfromPage[3].Text.ToString();
            UI_Pickup_Address2 = TerminalinfosfromPage[4].Text.ToString();
            UI_Delivery_Address2 = TerminalinfosfromPage[5].Text.ToString();
            UI_Pickup_City = TerminalinfosfromPage[6].Text.ToString();
            UI_Delivery_City = TerminalinfosfromPage[7].Text.ToString();
            UI_Pickup_StateProvince = TerminalinfosfromPage[8].Text.ToString();
            UI_Delivery_StateProvince = TerminalinfosfromPage[9].Text.ToString();
            UI_Pickup_PostalCode = TerminalinfosfromPage[10].Text.ToString();
            UI_Delivery_PostalCode = TerminalinfosfromPage[11].Text.ToString();
            UI_Pickup_Country = TerminalinfosfromPage[12].Text.ToString();
            UI_Delivery_Country = TerminalinfosfromPage[13].Text.ToString();
            UI_Pickup_ContactName = TerminalinfosfromPage[14].Text.ToString();
            UI_Delivery_ContactName = TerminalinfosfromPage[15].Text.ToString();
            UI_Pickup_ContactPhone = TerminalinfosfromPage[16].Text.ToString();
            UI_Delivery_ContactPhone = TerminalinfosfromPage[17].Text.ToString();
            UI_Pickup_ContactEmail = TerminalinfosfromPage[18].Text.ToString();
            UI_Delivery_ContactEmail = TerminalinfosfromPage[19].Text.ToString();


            Assert.AreEqual(TerminalinfosfromApi["PICKUP_TerminalName"], UI_Pickup_CarrierName);
            Assert.AreEqual(TerminalinfosfromApi["DELIVERY_TerminalName"], UI_Delivery_CarrierName);
            Assert.AreEqual(TerminalinfosfromApi["PICKUP_Address1"], UI_Pickup_Address1);
            Assert.AreEqual(TerminalinfosfromApi["DELIVERY_Address1"], UI_Delivery_Address1);
            Assert.AreEqual(TerminalinfosfromApi["PICKUP_Address2"], UI_Pickup_Address2);
            Assert.AreEqual(TerminalinfosfromApi["DELIVERY_Address2"], UI_Delivery_Address2);
            Assert.AreEqual(TerminalinfosfromApi["PICKUP_City"], UI_Pickup_City);
            Assert.AreEqual(TerminalinfosfromApi["DELIVERY_City"], UI_Delivery_City);
            Assert.AreEqual(TerminalinfosfromApi["PICKUP_StateProvince"], UI_Pickup_StateProvince);
            Assert.AreEqual(TerminalinfosfromApi["DELIVERY_StateProvince"], UI_Delivery_StateProvince);
            Assert.AreEqual(TerminalinfosfromApi["PICKUP_PostalCode"], UI_Pickup_PostalCode);
            Assert.AreEqual(TerminalinfosfromApi["DELIVERY_PostalCode"], UI_Delivery_PostalCode);
            Assert.AreEqual(TerminalinfosfromApi["PICKUP_Country"], UI_Pickup_Country);
            Assert.AreEqual(TerminalinfosfromApi["DELIVERY_Country"], UI_Delivery_Country);
            Assert.AreEqual(TerminalinfosfromApi["PICKUP_ContactName"], UI_Pickup_ContactName);
            Assert.AreEqual(TerminalinfosfromApi["DELIVERY_ContactName"], UI_Delivery_ContactName);
            Assert.AreEqual(TerminalinfosfromApi["PICKUP_ContactPhone"], UI_Pickup_ContactPhone);
            Assert.AreEqual(TerminalinfosfromApi["DELIVERY_ContactPhone"], UI_Delivery_ContactPhone);
            Assert.AreEqual(TerminalinfosfromApi["PICKUP_ContactEmail"], UI_Pickup_ContactEmail);
            Assert.AreEqual(TerminalinfosfromApi["DELIVERY_ContactEmail"], UI_Delivery_ContactEmail);
            Report.WriteLine("Terminal info for the selected report is displayed");
        }
       
        [Then(@"I will See a close button on Terminal information modal")]
        public void ThenIWillSeeACloseButtonOnTerminalInformationModal()
        {
            VerifyElementPresent(attributeName_xpath, ShipmentResultsTerminalPopupCloseButton_Xpath, "TerminalClose");
            Report.WriteLine("Close Button is present on Terminal information modal");
        }
        
        [Then(@"The Terminal Information modal will close")]
        public void ThenTheTerminalInformationModalWillClose()
        {
            VerifyElementPresent(attributeName_xpath, ShipResults_PageHeaderText_Relativexpath, "Shipment Results (LTL)");
            Report.WriteLine("Terminal Information modal is not present");

        }
    }
}
