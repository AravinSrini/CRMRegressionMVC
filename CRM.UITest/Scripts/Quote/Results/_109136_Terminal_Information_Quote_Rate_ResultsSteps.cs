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

namespace CRM.UITest.Scripts.Quote.Results
{
    [Binding]
    public class _109136_Terminal_Information_Quote_Rate_ResultsSteps : Quotelist
    {
        string Pickup_SCAC = null;
        string Pickup_countryCode = "USA";
        string Pickup_postalCode = "33136";
        string Pickup_serviceMethod = "LTL";
        string Pickup_serviceType = "STANDARD";
        string Pickup_terminalType = "PICKUP";
        string Delivery_SCAC = "EXLA";
        string Delivery_countryCode = "USA";
        string Delivery_postalCode = "85282";
        string Delivery_serviceMethod = "LTL";
        string Delivery_serviceType = "STANDARD";
        string Delivery_terminalType = "DELIVERY";


        string UI_Pickup_SCACTYPE = null;
        string UI_Delivery_SCACTYPE = null;
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
        string Account = "ZZZ - GS Customer Test";

        IDictionary<string, string> TerminalinfosfromApi = new Dictionary<string, string>();
        IInvokeTerminalByPostalCodeApi InvokeAPIMethod = new InvokeTerminalByPostalCodeApi();
        AddQuoteLTL quote = new AddQuoteLTL();
        WebDriverWait Wait = new WebDriverWait(GlobalVariables.webDriver, new TimeSpan(0, 0, 30));

       

        [Given(@"I am on the Create Quote for LTL page (.*)")]
        public void GivenIAmOnTheCreateQuoteForLTLPage(string user)
        {
            Report.WriteLine("Arriving on quote list page");
            GlobalVariables.webDriver.WaitForPageLoad();
            //string Username = GlobalVariables.webDriver.FindElement(By.XPath("//*[@id='spn-username']")).Text.ToString();
            Click(attributeName_xpath, QuoteList_Button_Xpath);

            GlobalVariables.webDriver.WaitForPageLoad();


            if (user == "Internal" || user == "Sales")
            {
                Report.WriteLine("Selecting Customer");
                Click(attributeName_xpath, QuoteList_CustomerDropdown_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, QuoteList_CustomerDropdownValues_Xpath, Account);
            }


            Report.WriteLine("Clicking submit rate request button");

            Thread.Sleep(10000);
            //WaitForElementPresent(attributeName_xpath, QuoteList_SubmitQuote_Button_Xpath,"Submit Quote");           

            //new WebDriverWait(GlobalVariables.webDriver, TimeSpan.FromSeconds(10000)).Until(ExpectedConditions.PresenceOfAllElementsLocatedBy((By.Id("rate-list"))));
            //Wait.Until(c => c.FindElement(By.XPath(QuoteList_SubmitQuote_Button_Xpath)));

            Click(attributeName_xpath, QuoteList_SubmitQuote_Button_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Clicking LTL tile on get quote page");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, GetQuote_LTLTile_Button_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
        }



        [Given(@"I have entered all required information")]
        public void GivenIHaveEnteredAllRequiredInformation()
        {

            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_id, QuoteDetails_Origin_AddressZip_Id, Pickup_postalCode);
            SendKeys(attributeName_id, QuoteDetails_Destination_AddressZip_Id, Delivery_postalCode);
            SendKeys(attributeName_xpath, QuoteWeight_Xpath, "5");
        }

        [Given(@"I have clicked on the View Quote Results button")]
        public void GivenIHaveClickedOnTheViewQuoteResultsButton()
        {

            Click(attributeName_id, GetQuote_ViewQuoteResult_Button_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
        }


        [Given(@"I clicked on the Terminal Info Link for a specific carrier rate,")]
        public void GivenIClickedOnTheTerminalInfoLinkForASpecificCarrierRate()
        {
            Report.WriteLine("Clicking on Terminal Link");
            Click(attributeName_xpath, GetQuote_FirstTerminalLink_Xpath);
        }

        [Given(@"I am in the Terminal Information modal,")]
        public void GivenIAmInTheTerminalInformationModal()
        {
            Report.WriteLine("Verifying User in Terminal Information modal");
            WaitForElementVisible(attributeName_xpath, GetQuote_TerminalModal_heading_Xpath, "Terminal Information For");
            VerifyElementVisible(attributeName_xpath, GetQuote_TerminalModal_heading_Xpath, "Terminal Information For");
        }

        [When(@"I arrive on the Quote Results \(LTL\) page")]
        public void WhenIArriveOnTheQuoteResultsLTLPage()
        {
            VerifyElementVisible(attributeName_xpath, QuoteResult_Title_Xpath, "Quote Results (LTL)");
        }

        [When(@"I click on the Close button,")]
        public void WhenIClickOnTheCloseButton()
        {
            Report.WriteLine("Clicking on Close button of Terminal Modal");
            Click(attributeName_xpath, GetQuote_TerminalModal_CloseButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
        }
        [Then(@"the Terminal modal will close")]
        public void ThenTheTerminalModalWillClose()
        {
            Report.WriteLine("Verifying Terminal modal is closed");
            VerifyElementVisible(attributeName_xpath, QuoteResult_Title_Xpath, "Quote Results (LTL)");
        }

        [When(@"I click on the Terminal Info Link for a specific carrier rate")]
        public void WhenIClickOnTheTerminalInfoLinkForASpecificCarrierRate()
        {
            Click(attributeName_xpath, GetQuote_FirstTerminalLink_Xpath);

            IWebElement TerminalElement = GlobalVariables.webDriver.FindElement(By.XPath(GetQuote_FirstTerminalLink_Xpath));

            Pickup_SCAC = TerminalElement.GetAttribute("data-scaccode");
            
        }

        [Then(@"I will see a link on each carrier rate labeled '(.*)'")]
        public void ThenIWillSeeALinkOnEachCarrierRateLabeled(string p0)
        {
            IList<IWebElement> TerminalInfoList = GlobalVariables.webDriver.FindElements(By.XPath("//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr/td/a"));
            for (int i = 1; i < TerminalInfoList.Count; i++)
            {
                string ActaulTerminalValue = Gettext(attributeName_xpath, "//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[" + i + "]/td[3]/a");
                if (ActaulTerminalValue.Equals("Terminal Info"))
                {
                    bool elementStatus = IsElementEnabled(attributeName_xpath, "//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[" + i + "]/td[3]/a", "Terminal Info");
                    if (elementStatus is true)
                    {
                        Report.WriteLine("Terminal Info link is clickable");
                    }
                    else
                    {
                        Report.WriteFailure("Terminal Info link is not clickable");
                    }
                }
            }
        }

        [Then(@"I will see page level loading icon\.")]
        public void ThenIWillSeePageLevelLoadingIcon_()
        {
            Report.WriteLine("Verifying Page Loading Icon");
            VerifyElementVisible(attributeName_xpath, QuoteList_LoadingIcon_Xpath, "loading icon");
        }

        [Then(@"a popup modal is launched that displays the terminal information for selected carrier record")]
        public void ThenAPopupModalIsLaunchedThatDisplaysTheTerminalInformationForSelectedCarrierRecord()
        {
            string requestXml = "<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:web='http://webservices.smc.com' xmlns:ter='http://terminalsbypostalcode.requests.objects.webservice.carrierconnect.smc.com'><soapenv:Header><web:AuthenticationToken><web:licenseKey>6Twv0Ozm4mOA</web:licenseKey><web:password>BZT4ia5z</web:password><web:username>dlswintegration@rrd.com</web:username></web:AuthenticationToken></soapenv:Header><soapenv:Body><web:TerminalsByPostalCode><web:TerminalsByPostalCodeRequest><ter:arrayTerminalByPostalCode><!--Zero or more repetitions:--><ter:TerminalByPostalCode><ter:SCAC>" + Pickup_SCAC + "</ter:SCAC><ter:countryCode>" + Pickup_countryCode + "</ter:countryCode><ter:postalCode>" + Pickup_postalCode + "</ter:postalCode><ter:serviceMethod>" + Pickup_serviceMethod + "</ter:serviceMethod><ter:serviceType>" + Pickup_serviceType + "</ter:serviceType><ter:terminalType>" + Pickup_terminalType + "</ter:terminalType></ter:TerminalByPostalCode><ter:TerminalByPostalCode><ter:SCAC>" + Delivery_SCAC + "</ter:SCAC><ter:countryCode>" + Delivery_countryCode + "</ter:countryCode><ter:postalCode>" + Delivery_postalCode + "</ter:postalCode><ter:serviceMethod>" + Delivery_serviceMethod + "</ter:serviceMethod><ter:serviceType>" + Delivery_serviceType + "</ter:serviceType><ter:terminalType>" + Delivery_terminalType + "</ter:terminalType></ter:TerminalByPostalCode></ter:arrayTerminalByPostalCode></web:TerminalsByPostalCodeRequest></web:TerminalsByPostalCode></soapenv:Body></soapenv:Envelope>";
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
            //UI_Pickup_ContactPhone = TerminalinfosfromPage[16].Text.ToString().Replace("(", "").Replace(")", "");
            //UI_Delivery_ContactPhone = TerminalinfosfromPage[17].Text.ToString().Replace("(", "").Replace(")", "");
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

            Report.WriteLine("API and PageFields data are verified successfully");
        }

        [Then(@"I will see a Close button\.")]
        public void ThenIWillSeeACloseButton_()
        {
            Report.WriteLine("Verifying Close Button");
            VerifyElementVisible(attributeName_xpath, GetQuote_TerminalModal_CloseButton_Xpath, "Close");
        }

    }
}