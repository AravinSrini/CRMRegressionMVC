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
using System.Threading;
using System.Xml;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.ShipmentList.ShipmentList_TerminalInformation
{
    [Binding]
    public class _59886_Terminal_Information_ShipmentListSteps : Shipmentlist
    {
        string SCAC = "EXLA";
        string Pickup_countryCode = "USA";
        string Pickup_postalCode = "60606";
        string Pickup_serviceMethod = "LTL";
        string Pickup_serviceType = "STANDARD";
        string Pickup_terminalType = "PICKUP";

        string Delivery_countryCode = "USA";
        string Delivery_postalCode = "90001";
        string Delivery_serviceMethod = "LTL";
        string Delivery_serviceType = "STANDARD";
        string Delivery_terminalType = "DELIVERY";


        string UI_TerminalHeader = string.Empty;
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
        string TerminalInfoToolTip = string.Empty;
        string Account = "ZZZ - GS Customer Test";
        string ShipmentNumber = "ZZX002016941";
        IWebElement TerminalInfoIcon;
        IWebElement TerminalInfoHeader;

        IDictionary<string, string> TerminalRequestinfo = new Dictionary<string, string>();
        IDictionary<string, string> TerminalinfosfromApi = new Dictionary<string, string>();
        IInvokeTerminalByPostalCodeApi InvokeAPIMethod = new InvokeTerminalByPostalCodeApi();



        [Given(@"I am on the shipment list page (.*)")]
        public void GivenIAmOnTheShipmentListPage(string user)
        {
            Report.WriteLine("Arriving on Shipment list page");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, ShipmentIcon_Xpath);

            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("I should be navigated to shipment list page");
            Thread.Sleep(5000);
            VerifyElementVisible(attributeName_xpath, ShipmentList_Title_Xpath, "Shipment List");

            if (user == "Sales" || user == "Internal")
            {

                Click(attributeName_xpath, ShipmentListInternal_CustomerDropdown_Xpath);
                IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentListInternal_CustDropdownVal_Xpath));
                int DropDownCount = DropDownList.Count;
                for (int i = 0; i < DropDownCount; i++)
                {
                    int j = i - 1;
                    if (DropDownList[i].Text == Account)
                    {
                        DropDownList[i].Click();
                        break;
                    }
                }
                Report.WriteLine("Customer is chosen");
            }

        }


        [Given(@"the shipment list grid is displaying records,")]
        public void GivenTheShipmentListGridIsDisplayingRecords()
        {
            Report.WriteLine("Shipment List Grid Displaying All Records");
            GlobalVariables.webDriver.WaitForPageLoad();

            Thread.Sleep(3000);
            Click(attributeName_xpath, ShipmentList_TopGrid_ViewDropdown_Xpath);

            Click(attributeName_xpath, ShipmentList_TopGrid_ViewDropdownALLValues_Xpath);
            
            Thread.Sleep(3000);
            SendKeys(attributeName_xpath, ShipmentList_SearchGridValuesTexTBox_Xpath, ShipmentNumber);


        }

        [When(@"the shipment list grid is displaying records,")]
        public void WhenTheShipmentListGridIsDisplayingRecords()
        {
            Report.WriteLine("Shipment List Grid Displaying All LTL Records");
            GlobalVariables.webDriver.WaitForPageLoad();
            Thread.Sleep(3000);
            Click(attributeName_xpath, ShipmentList_TopGrid_ViewDropdown_Xpath);
            Click(attributeName_xpath, ShipmentList_TopGrid_ViewDropdownALLValues_Xpath);
            Thread.Sleep(3000);
            SendKeys(attributeName_xpath, ShipmentList_SearchGridValuesTexTBox_Xpath, "LTL");
        }

        [When(@"I click on the option to display terminal Information for a specific LTL record")]
        public void WhenIClickOnTheOptionToDisplayTerminalInformationForASpecificLTLRecord()
        {
            Report.WriteLine("Clicking Terminal Info Icon");
            Click(attributeName_xpath, ShipmentListTerminalInfoIconXpath);

        }

        [Then(@"each LTL shipment will have an option to display Terminal Information")]
        public void ThenEachLTLShipmentWillHaveAnOptionToDisplayTerminalInformation()
        {
            Report.WriteLine("Checking the Terminal Info Icon for all the grid records");
            IList<IWebElement> ShipmentListGridData = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_TotalRecords_Xpath));


            IList<IWebElement> ShipmentListTerminalICon = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentListTerminalInfoIconXpath));

            Assert.AreEqual(ShipmentListGridData.Count, ShipmentListTerminalICon.Count);
        }

        [Then(@"the newly added terminal information icon should have a tooltip “Terminal Information”")]
        public void ThenTheNewlyAddedTerminalInformationIconShouldHaveATooltipTerminalInformation()
        {
            Report.WriteLine("Checking Tool tip for Terminal Info Icon");
            TerminalInfoIcon = GlobalVariables.webDriver.FindElement(By.XPath(ShipmentListTerminalInfoIconXpath));

            TerminalInfoToolTip = TerminalInfoIcon.GetAttribute("data-original-title");

            Assert.AreEqual(TerminalInfoToolTip, "Terminal Information");
        }


        [Then(@"a popup modal is launched to display the terminal information for selected record for shipment")]
        public void ThenAPopupModalIsLaunchedToDisplayTheTerminalInformationForSelectedRecordForShipment()
        {
            //TerminalRequestinfo = InvokeAPIMethod.GetShipmentValues("ZZX002016941");
            //SCAC = TerminalRequestinfo["SCAC"];
            //Pickup_postalCode = TerminalRequestinfo["Pickup_postalCode"];
            //Pickup_countryCode = TerminalRequestinfo["Pickup_countryCode"];
            //Delivery_countryCode = TerminalRequestinfo["Delivery_countryCode"];
            //Delivery_postalCode = TerminalRequestinfo["Delivery_postalCode"];
            TerminalInfoIcon = GlobalVariables.webDriver.FindElement(By.XPath(ShipmentListTerminalInfoIconXpath));
            //SCAC = TerminalInfoIcon.GetAttribute("data-carrierscac");
            //Pickup_postalCode = TerminalInfoIcon.GetAttribute("data-origin-postalcode");
            //Pickup_countryCode = TerminalInfoIcon.GetAttribute("data-origin-country");
            //Delivery_countryCode = TerminalInfoIcon.GetAttribute("data-destination-country");
            //Delivery_postalCode = TerminalInfoIcon.GetAttribute("data-destination-postalcode");


            string requestXml = "<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:web='http://webservices.smc.com' xmlns:ter='http://terminalsbypostalcode.requests.objects.webservice.carrierconnect.smc.com'><soapenv:Header><web:AuthenticationToken><web:licenseKey>6Twv0Ozm4mOA</web:licenseKey><web:password>BZT4ia5z</web:password><web:username>dlswintegration@rrd.com</web:username></web:AuthenticationToken></soapenv:Header><soapenv:Body><web:TerminalsByPostalCode><web:TerminalsByPostalCodeRequest><ter:arrayTerminalByPostalCode><!--Zero or more repetitions:--><ter:TerminalByPostalCode><ter:SCAC>" + SCAC + "</ter:SCAC><ter:countryCode>" + Pickup_countryCode + "</ter:countryCode><ter:postalCode>" + Pickup_postalCode + "</ter:postalCode><ter:serviceMethod>" + Pickup_serviceMethod + "</ter:serviceMethod><ter:serviceType>" + Pickup_serviceType + "</ter:serviceType><ter:terminalType>" + Pickup_terminalType + "</ter:terminalType></ter:TerminalByPostalCode><ter:TerminalByPostalCode><ter:SCAC>" + SCAC + "</ter:SCAC><ter:countryCode>" + Delivery_countryCode + "</ter:countryCode><ter:postalCode>" + Delivery_postalCode + "</ter:postalCode><ter:serviceMethod>" + Delivery_serviceMethod + "</ter:serviceMethod><ter:serviceType>" + Delivery_serviceType + "</ter:serviceType><ter:terminalType>" + Delivery_terminalType + "</ter:terminalType></ter:TerminalByPostalCode></ter:arrayTerminalByPostalCode></web:TerminalsByPostalCodeRequest></web:TerminalsByPostalCode></soapenv:Body></soapenv:Envelope>";
            string error = string.Empty;

            XmlDocument xmlDoc = InvokeAPIMethod.InvokeCarrierTerminalInformation(requestXml, out error);

            TerminalinfosfromApi = InvokeAPIMethod.getTerminalinfomethod(xmlDoc);
            Thread.Sleep(3000);
            TerminalInfoHeader = GlobalVariables.webDriver.FindElement(By.XPath(TerminalInfoHeaderXpath));

            IList<IWebElement> TerminalinfosfromPage = GlobalVariables.webDriver.FindElements(By.XPath(TerminalInfoPageDataXpath));

            UI_TerminalHeader = TerminalInfoHeader.Text.ToString().ToLower();
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

            Assert.AreEqual("terminal information for " + TerminalinfosfromApi["PICKUP_CarrierName"].ToLower(), UI_TerminalHeader.ToLower());
            Assert.AreEqual(TerminalinfosfromApi["PICKUP_TerminalName"].ToLower(), UI_Pickup_CarrierName.ToLower());
            Assert.AreEqual(TerminalinfosfromApi["DELIVERY_TerminalName"].ToLower(), UI_Delivery_CarrierName.ToLower());
            Assert.AreEqual(TerminalinfosfromApi["PICKUP_Address1"].ToLower(), UI_Pickup_Address1.ToLower());
            Assert.AreEqual(TerminalinfosfromApi["DELIVERY_Address1"].ToLower(), UI_Delivery_Address1.ToLower());
            Assert.AreEqual(TerminalinfosfromApi["PICKUP_Address2"].ToLower(), UI_Pickup_Address2.ToLower());
            Assert.AreEqual(TerminalinfosfromApi["DELIVERY_Address2"].ToLower(), UI_Delivery_Address2.ToLower());
            Assert.AreEqual(TerminalinfosfromApi["PICKUP_City"].ToLower(), UI_Pickup_City.ToLower());
            Assert.AreEqual(TerminalinfosfromApi["DELIVERY_City"].ToLower(), UI_Delivery_City.ToLower());
            Assert.AreEqual(TerminalinfosfromApi["PICKUP_StateProvince"].ToLower(), UI_Pickup_StateProvince.ToLower());
            Assert.AreEqual(TerminalinfosfromApi["DELIVERY_StateProvince"].ToLower(), UI_Delivery_StateProvince.ToLower());
            Assert.AreEqual(TerminalinfosfromApi["PICKUP_PostalCode"].ToLower(), UI_Pickup_PostalCode.ToLower());
            Assert.AreEqual(TerminalinfosfromApi["DELIVERY_PostalCode"].ToLower(), UI_Delivery_PostalCode.ToLower());
            Assert.AreEqual(TerminalinfosfromApi["PICKUP_Country"].ToLower(), UI_Pickup_Country.ToLower());
            Assert.AreEqual(TerminalinfosfromApi["DELIVERY_Country"].ToLower(), UI_Delivery_Country.ToLower());
            Assert.AreEqual(TerminalinfosfromApi["PICKUP_ContactName"].ToLower(), UI_Pickup_ContactName.ToLower());
            Assert.AreEqual(TerminalinfosfromApi["DELIVERY_ContactName"].ToLower(), UI_Delivery_ContactName.ToLower());
            Assert.AreEqual(TerminalinfosfromApi["PICKUP_ContactPhone"].ToLower(), UI_Pickup_ContactPhone.ToLower());
            Assert.AreEqual(TerminalinfosfromApi["DELIVERY_ContactPhone"].ToLower(), UI_Delivery_ContactPhone.ToLower());
            Assert.AreEqual(TerminalinfosfromApi["PICKUP_ContactEmail"].ToLower(), UI_Pickup_ContactEmail.ToLower());
            Assert.AreEqual(TerminalinfosfromApi["DELIVERY_ContactEmail"].ToLower(), UI_Delivery_ContactEmail.ToLower());

            Report.WriteLine("API and PageFields data are verified successfully");
        }


    
        [Given(@"I will see a Close button in the Terminal info modal popup")]
        public void GivenIWillSeeACloseButtonInTheTerminalInfoModalPopup()
        {
            bool elementStatus = IsElementEnabled(attributeName_xpath, ShipmentListTerminalInfoCloseButtonXpath, "Terminal Info");

            if (elementStatus)
            {
                Report.WriteLine("Close Element Displayed");
            }
            else
            {
                Report.WriteLine("Close Element not Displayed");
                Assert.Fail();
            }
        }




        [When(@"I click the button Close in the modal popup")]
        public void WhenIClickTheButtonCloseInTheModalPopup()
        {
            Report.WriteLine("Clicking the Close Button");
            Thread.Sleep(2000);
            Click(attributeName_xpath, ShipmentListTerminalInfoCloseButtonXpath);

        }

        [Given(@"I click on the option to display terminal Information for a specific LTL record")]
        public void GivenIClickOnTheOptionToDisplayTerminalInformationForASpecificLTLRecord()
        {
            Report.WriteLine("Clicking the Terminal info icon ");
            Click(attributeName_xpath, ShipmentListTerminalInfoIconXpath);

        }


        [Then(@"I will see a Close button in the Terminal info modal popup")]
        public void ThenIWillSeeACloseButtonInTheTerminalInfoModalPopup()
        {
            bool elementStatus = IsElementEnabled(attributeName_xpath, ShipmentListTerminalInfoCloseButtonXpath, "Terminal Info");

            if (elementStatus)
            {
                Report.WriteLine("Close Element Displayed");
            }
            else
            {
                Report.WriteLine("Close Element not Displayed");
                Assert.Fail();
            }
        }



        [Then(@"the modal should be closed")]
        public void ThenTheModalShouldBeClosed()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Checking the Close Button");
            Thread.Sleep(2000);
            if (GlobalVariables.webDriver.FindElement(By.XPath(ShipmentListTerminalInfoCloseButtonXpath)).Displayed)
            {
                Report.WriteFailure("Element is Visible");
            }
            else
            {
                Report.WriteLine("Element is InVisible");
            }
            Report.WriteLine("Modal closed and not visible");
        }



    }
}

  