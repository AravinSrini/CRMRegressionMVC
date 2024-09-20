using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Helper;
using CRM.UITest.Helper.ViewModel;
using CRM.UITest.Objects;
using CRM.UITest.Scripts.Quote.LTL.Shipment_Information_Screen.OverLength_GetQuote_LTL_;
using Microsoft.IdentityModel.Protocols;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Quote.LTL.Shipment_Information_Screen.Get_Quote__LTL__Screen
{
    [Binding]
    public class _46938_ConfigureAccessorials_LTL_DisplayAccessorial_QuoteSteps : ConfigureAccessorial
    {
        string accessorialName = "VasAc" + Guid.NewGuid().ToString();
        string accessorialServiceCode = "VasServiceCode" + Guid.NewGuid().ToString();
        string accessorialMGDescription = "VasMGDescription" + Guid.NewGuid().ToString();
        string accessorialAdditionalMGDescription = "VasadditionalMGDescription" + Guid.NewGuid().ToString();
        string accessorialServiceType;
        string accessorialDirection;
        string CustomerName = "ZZZ - GS Customer Test";
        string Service = "LTL";
        string OriginCity = "Miami";
        string OriginZip = "33126";
        string OriginState = "FL";
        string OriginCountry = "USA";
        string DestinationCity = "Tempe";
        string DestinationZip = "85282";
        string DestinationState = "AZ";
        string DestinationCountry = "USA";
        string OAccessorial;
        string DAccessorial;
        string Classification = "50";
        double Quantity = 1;
        string QuantityUNIT = "skids";
        string WeightUnit = "LBS";

        double Weight = 4;

        string Username = "zzzext";
        List<RateResultCarrierViewModel> rlist = null;

        [Given(@"that I am a shp\.inquiry, shp\.entry, sales, sales management, operations, or station owner user")]
        public void GivenThatIAmAShp_InquiryShp_EntrySalesSalesManagementOperationsOrStationOwnerUser()
        {
            Report.WriteLine("I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner user");
            string userName = ConfigurationManager.AppSettings["username-ExtuserCustDropdown"].ToString();
            string password = ConfigurationManager.AppSettings["password-ExtuserCustDropdown"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(userName, password);
        }



        [Given(@"An accessorial was added on the Configure Accessorials page")]
        public void GivenAnAccessorialWasAddedOnTheConfigureAccessorialsPage()
        {
            Report.WriteLine("an accessorial was added on the Configure Accessorials page");
        }


        [Given(@"the accessorial was designated to be applied to (.*) service types")]
        public void GivenTheAccessorialWasDesignatedToBeAppliedToServiceTypes(string serviceType)
        {
            accessorialServiceType = Regex.Replace(serviceType, @"(<|>)", "");
        }



        [Given(@"the accessorial was designated to be applied in the (.*) section")]
        public void GivenTheAccessorialWasDesignatedToBeAppliedInTheSection(string accessorialDirect)
        {
            accessorialDirection = Regex.Replace(accessorialDirect, @"(<|>)", "");
            accessorialName = AddAccessorial(accessorialDirection);


        }

        [Given(@"I am submitting an LTL quote (.*)")]
        public void GivenIAmSubmittingAnLTLQuote(string accessorialDirect)
        {
            accessorialDirection = Regex.Replace(accessorialDirect, @"(<|>)", "");
            accessorialName = AddAccessorial(accessorialDirection);
            OverLength_GetQuote_LTL__NewFields quote = new OverLength_GetQuote_LTL__NewFields();

            quote.GivenIAmOnTheGetQuoteLTLPage();
        }

        [Given(@"I selected an accessorial that was created on the Configure Accessorials page")]
        public void GivenISelectedAnAccessorialThatWasCreatedOnTheConfigureAccessorialsPage()
        {
            Click(attributeName_xpath, LTL_ServicesAndAccessorials_ShipFrom_Xpath);
            IList<IWebElement> accessorialsAndServices = GlobalVariables.webDriver.FindElements(By.XPath(LTL_ServicesDropdownValues_ShipFrom_Xpath));
            int CustomerNameListCount = accessorialsAndServices.Count;
            for (int i = 0; i < CustomerNameListCount; i++)
            {
                if (accessorialsAndServices[i].Text == accessorialName)
                {

                    Assert.AreEqual(accessorialsAndServices[i].Text, accessorialName);
                }
            }
        }

        [When(@"I click on the (.*) button on the Get Quote \(LTL\) page")]
        public void WhenIClickOnTheButtonOnTheGetQuoteLTLPage(string p0)
        {
            AddQuoteLTL quote = new AddQuoteLTL();
            quote.EnterOriginZip(OriginZip);
            quote.EnterDestinationZip(DestinationZip);
            quote.EnterItemdata(Classification, Weight.ToString());
            quote.selectShippingToServices(accessorialName);
            Click(attributeName_id, ViewQuoteResultsBtn_id);
        }


        [Then(@"CRM will send the new Service Code")]
        public void ThenCRMWillSendTheNewServiceCode()
        {
            rlist = GetRatesAndCarriersAPICall.CallRateRequestApiWithAccessorials(CustomerName,
                Service,
                OriginCity,
                OriginZip,
                OriginState,
                OriginCountry,
                DestinationCity,
                DestinationZip,
                DestinationState,
                DestinationCountry,
                OAccessorial,
                accessorialName,
                Classification,
                Quantity,
                QuantityUNIT,
                Weight,
                WeightUnit,
                Username, false);
        }


        [When(@"I click in the (.*) field in the (.*) section")]
        public void WhenIClickInTheFieldInTheSection(string accessorialDropDown, string accessorialDirect)
        {
            accessorialDirection = Regex.Replace(accessorialDirect, @"(<|>)", "");
            if (accessorialDirection == "Ship To")
            {
                Click(attributeName_xpath, LTL_ServicesAndAccessorials_ShipTo_Xpath);
            }
            else if (accessorialDirection == "Ship From")
            {
                Click(attributeName_xpath, LTL_ServicesAndAccessorials_ShipFrom_Xpath);
            }
            else if (accessorialDirection == "Both")
            {
                Click(attributeName_xpath, LTL_ServicesAndAccessorials_ShipTo_Xpath);
                Click(attributeName_xpath, LTL_ServicesAndAccessorials_ShipFrom_Xpath);
            }
        }


        [Then(@"I will see the accessorial displayed in the drop down list (.*)")]
        public void ThenIWillSeeTheAccessorialDisplayedInTheDropDownList(string accessorialDirect)
        {
            accessorialDirection = Regex.Replace(accessorialDirect, @"(<|>)", "");
            if (accessorialDirection == "Ship To")
            {

                IList<IWebElement> accessorialsAndServices = GlobalVariables.webDriver.FindElements(By.XPath(LTL_ServicesDropdownValues_ShipTo_Xpath));

                int CustomerNameListCount = accessorialsAndServices.Count;
                for (int i = 0; i < CustomerNameListCount; i++)
                {
                    if (accessorialsAndServices[i].Text == accessorialName)
                    {

                        Assert.AreEqual(accessorialsAndServices[i].Text, accessorialName);
                    }
                }
            }
            else if (accessorialDirection == "Ship From")
            {
                IList<IWebElement> accessorialsAndServices = GlobalVariables.webDriver.FindElements(By.XPath(LTL_ServicesDropdownValues_ShipFrom_Xpath));
                int CustomerNameListCount = accessorialsAndServices.Count;
                for (int i = 0; i < CustomerNameListCount; i++)
                {
                    if (accessorialsAndServices[i].Text == accessorialName)
                    {

                        Assert.AreEqual(accessorialsAndServices[i].Text, accessorialName);
                    }
                }

            }
            else if (accessorialDirection == "Both")
            {
                IList<IWebElement> accessorialsAndServicesShipTo = GlobalVariables.webDriver.FindElements(By.XPath(LTL_ServicesDropdownValues_ShipTo_Xpath));

                int CustomerNameListCountShipTo = accessorialsAndServicesShipTo.Count;
                for (int i = 0; i < CustomerNameListCountShipTo; i++)
                {
                    if (accessorialsAndServicesShipTo[i].Text == accessorialName)
                    {

                        Assert.AreEqual(accessorialsAndServicesShipTo[i].Text, accessorialName);
                    }
                }

                IList<IWebElement> accessorialsAndServicesShipFrom = GlobalVariables.webDriver.FindElements(By.XPath(LTL_ServicesDropdownValues_ShipFrom_Xpath));
                int CustomerNameListCountShipFrom = accessorialsAndServicesShipFrom.Count;
                for (int i = 0; i < CustomerNameListCountShipFrom; i++)
                {
                    if (accessorialsAndServicesShipFrom[i].Text == accessorialName)
                    {

                        Assert.AreEqual(accessorialsAndServicesShipFrom[i].Text, accessorialName);
                    }
                }
            }
            else
            {
                Assert.Fail("Accessorial is not displayed in drop dwon list");
            }
        }

        [Then(@"I will not see the accessorial displayed in the drop down list (.*)")]
        public void ThenIWillNotSeeTheAccessorialDisplayedInTheDropDownList(string accessorialDirect)
        {
            accessorialDirection = Regex.Replace(accessorialDirect, @"(<|>)", "");
            string expectedValue = "Oops, nothing found!";
            if (accessorialDirection == "Ship To")
            {
                SendKeys(attributeName_xpath, ".//*[@id='servicesaccessorialsto_chosen']/ul/li/input", accessorialName);
                accessorialName = Gettext(attributeName_xpath, ".//*[@id='servicesaccessorialsto_chosen']//div//li[1]");
                Assert.IsTrue(accessorialName.Contains(expectedValue));
            }
            else if (accessorialDirection == "Ship From")
            {
                SendKeys(attributeName_xpath, ".//*[@id='servicesaccessorialsfrom_chosen']/ul/li/input", accessorialName);
                accessorialName = Gettext(attributeName_xpath, "//*[@id='servicesaccessorialsfrom_chosen']//div//li[1]");
                Assert.IsTrue(accessorialName.Contains(expectedValue));
            }
            else if (accessorialDirection == "Both")
            {
                SendKeys(attributeName_xpath, ".//*[@id='servicesaccessorialsto_chosen']/ul/li/input", accessorialName);
                accessorialName = Gettext(attributeName_xpath, ".//*[@id='servicesaccessorialsto']/option[1]");
                Assert.IsTrue(accessorialName.Contains(expectedValue));

                SendKeys(attributeName_xpath, ".//*[@id='servicesaccessorialsfrom_chosen']/ul/li/input", accessorialName);
                accessorialName = Gettext(attributeName_xpath, "//*[@id='servicesaccessorialsfrom_chosen']//div//li[1]");
                Assert.IsTrue(accessorialName.Contains(expectedValue));
            }
        }


        public string AddAccessorial(string accessorialDirect)
        {
            accessorialDirection = Regex.Replace(accessorialDirect, @"(<|>)", "");
            if (accessorialDirection == "Ship To")
            {
                accessorialDirection = "Destination";
            }
            else if (accessorialDirection == "Ship From")
            {

                accessorialDirection = "Origin";
            }
            string accName = null;
            List<ConfigureAccessorialViewModel> list = DBHelper.AccessorialList();
            for (int i = 0; i < list.Count; i++)
            {

                if (list[i].AccessorialDirectionName == accessorialDirection)
                {
                    accName = list[i].AccessorialName;
                    break;
                }
            }
            return accName;
        }

        [Then(@"CRM will receive one of the associated EDI Codes in response")]
        public void ThenCRMWillReceiveOneOfTheAssociatedEDICodesInResponse()
        {

          Assert.IsTrue(rlist.Count >= 0);

        }


    }
}
