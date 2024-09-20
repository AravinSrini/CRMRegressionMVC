using CRM.UITest.CommonMethods;
using CRM.UITest.Helper;
using CRM.UITest.Helper.ViewModel;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Quote.LTL.Shipment_Information_Screen.Get_Quote__LTL__Screen
{
    [Binding]
    public class _44476___Get_Quote__LTL____New_Accessorial___Notification_Steps : AddShipments
    {
        
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
        GetQuoteLTL GetQuoteLTLNavigation = new GetQuoteLTL();
        AddQuoteLTL quoteLtl = new AddQuoteLTL();
        WebElementOperations getListfromWebElement = new WebElementOperations();

        public string Account = "ZZZ - GS Customer Test";
        public string service = "Notification";
        public string Section;
        public string havingrequestcode;
        public string havingresponsecode;

        string userType = "Internal";
        string servicetype = "LTL";
        string originCity = "Miami";
        string originZip = "33126";
        string originState = "FL";
        string originCountry = "USA";
        string destinationCity = "Chicago";
        string destinationZip = "60606";
        string destinationState = "IL";
        string destinationCountry = "USA";
        string oAccessorial = "Notification";
        string dAccessorial = "Notification";
        string classification = "60";
        double quantity = 1;
        string quantityUNIT = "skids";
        double weight = 4;
        string weightUnit = "LBS";
        string userName = null;
        List<RateResultCarrierViewModel> accessorialApiResponse = null;

        [Given(@"I am a shp\.inquiry, shp\.entry, sales, sales management, operations and station owner user")]
        public void GivenIAmAShp_InquiryShp_EntrySalesSalesManagementOperationsAndStationOwnerUser()
        {
            string userName = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
            string password = ConfigurationManager.AppSettings["password-crmOperation"].ToString();
            CrmLogin.LoginToCRMApplication(userName, password);
        }

        [Given(@"I am on the Get Quote LTL page")]
        public void GivenIAmOnTheGetQuoteLTLPage()
        {
            GetQuoteLTLNavigation.GetQuoteLTL_Navigation(Account);
        }

        [Given(@"I click in the (.*) field in either of the following locations: (.*)")]
        public void GivenIClickInTheFieldInEitherOfTheFollowingLocations(string p0, string Sections)
        {
            if(Sections == "Shipping From")
            {
                Section = "ShippingFrom";
                Click(attributeName_xpath, LTL_ServicesAndAccessorials_ShipFrom_Xpath);
            }
            else
            {
                Section = "ShippingTo";
                Click(attributeName_xpath, LTL_ServicesAndAccessorials_ShipTo_Xpath);
            }
        }

        [Then(@"I will see a new selection: (.*) in dropdown")]
        public void ThenIWillSeeANewSelectionInDropdown(string Notification)
        {
            Report.WriteLine("I will see a new selection in dropdown");
            if (Section == "ShippingFrom")
            {
                IList<IWebElement> accessorialsAndServices = GlobalVariables.webDriver.FindElements(By.XPath(LTL_ServicesDropdownValues_ShipFrom_Xpath));
                int CustomerNameListCount = accessorialsAndServices.Count;
                for (int i = 0; i < CustomerNameListCount; i++)
                {
                    if (accessorialsAndServices[i].Text == Notification)
                    {
                        Report.WriteLine("Shipping From : Notification are available in the list");
                        break;
                    }
                }
            }
            else
            {
                IList<IWebElement> accessorialsAndServices = GlobalVariables.webDriver.FindElements(By.XPath(LTL_ServicesDropdownValues_ShipTo_Xpath));
                int CustomerNameListCount = accessorialsAndServices.Count;
                for (int i = 0; i < CustomerNameListCount; i++)
                {
                    if (accessorialsAndServices[i].Text == Notification)
                    {
                        Report.WriteLine("Shipping To : Notification are available in the list");
                        break;
                    }
                }
            }
            
        }

        [Then(@"The new selection (.*) will be displayed alphabetically within the list")]
        public void ThenTheNewSelectionWillBeDisplayedAlphabeticallyWithinTheList(string Notification)
        {      
            if (Section == "ShippingFrom")
            {
                IList<IWebElement> shippingFromAccessorialDropdownList = GlobalVariables.webDriver.FindElements(By.XPath(LTL_ServicesDropdownValues_ShipFrom_Xpath));
                List<string> actualShippingFromAccessorialDropdownList = getListfromWebElement.GetListFromIWebElement(shippingFromAccessorialDropdownList);
                CollectionAssert.AreEqual(actualShippingFromAccessorialDropdownList.OrderBy(q => q).ToList(), actualShippingFromAccessorialDropdownList);
                Report.WriteLine("Displayed new accessorial Notification in alphabetical order in Shipping From section");

            }
            else
            {
                IList<IWebElement> shippingToAccessorialDropdownList = GlobalVariables.webDriver.FindElements(By.XPath(LTL_ServicesDropdownValues_ShipTo_Xpath));
                List<string> actualShippingToAccessorialDropdownList = getListfromWebElement.GetListFromIWebElement(shippingToAccessorialDropdownList);
                CollectionAssert.AreEqual(actualShippingToAccessorialDropdownList.OrderBy(q => q).ToList(), actualShippingToAccessorialDropdownList);
                Report.WriteLine("Displayed new accessorial Notification in alphabetical order in Shipping To section");

            }
        }

        [Given(@"I selected (.*) from dropdown")]
        public void GivenISelectedFromDropdown(string Notification)
        {
            string Notification1 = Notification.Replace(@"<", "");
            string Notificationacc = Notification1.Replace(@">", "");



            if (Section == "ShippingFrom")
            {
                IList<IWebElement> accessorialsAndServices = GlobalVariables.webDriver.FindElements(By.XPath(LTL_ServicesDropdownValues_ShipFrom_Xpath));
                int CustomerNameListCount = accessorialsAndServices.Count;
                for (int i = 0; i < CustomerNameListCount; i++)
                {
                    if (accessorialsAndServices[i].Text == Notificationacc)
                    {
                        Report.WriteLine("Selected Notification from Shipping From section");
                        accessorialsAndServices[i].Click();
                        break;
                        
                    }
                }
            }
            else
            {
                IList<IWebElement> accessorialsAndServices = GlobalVariables.webDriver.FindElements(By.XPath(LTL_ServicesDropdownValues_ShipTo_Xpath));
                int CustomerNameListCount = accessorialsAndServices.Count;
                for (int i = 0; i < CustomerNameListCount; i++)
                {
                    if (accessorialsAndServices[i].Text == Notificationacc)
                    {
                        Report.WriteLine("Selected Notification from Shipping To section");
                        accessorialsAndServices[i].Click();
                        break;
                        
                    }
                }

            }
        }

        [When(@"I click on the (.*) button"), Scope(Tag = "44476")]
        public void WhenIClickOnTheButton(string p0)
        {
            quoteLtl.EnterOriginZip(originZip);
            quoteLtl.EnterDestinationZip(destinationZip);
            scrollElementIntoView(attributeName_id, LTL_SavedItemDropdown_Id);

            Click(attributeName_id, LTL_ClearItem_Id);
            quoteLtl.EnterItemdata(classification, weight.ToString());
            Report.WriteLine("Click on View Quote Result button");
            Click(attributeName_id, ViewQuoteResultsBtn_id);
        }

        [Given(@"I clicked on the View Quote Results button"),Scope(Tag= "44476")]
        public void GivenIClickedOnTheViewQuoteResultsButton()
        {
            quoteLtl.EnterOriginZip(originZip);
            quoteLtl.EnterDestinationZip(destinationZip);
            scrollElementIntoView(attributeName_id, LTL_SavedItemDropdown_Id);

            Click(attributeName_id, LTL_ClearItem_Id);
            quoteLtl.EnterItemdata(classification, weight.ToString());
            Report.WriteLine("Click on View Quote Result button");
            Click(attributeName_id, ViewQuoteResultsBtn_id);
        }


        [Then(@"CRM will send the Accessorial Service (.*) to MG")]
        public void ThenCRMWillSendTheAccessorialServiceToMG(string ServiceCode)
        {
            //CRM sending accessorial NTFY to MG request
            accessorialApiResponse = GetRatesAndCarriersAPICall.CallRateRequestApiWithAccessorials(Account,
                servicetype,
                originCity,
                originZip,
                originState,
                originCountry,
                destinationCity,
                destinationZip,
                destinationState,
                destinationCountry,
                oAccessorial,
                dAccessorial,
                classification,
                quantity,
                quantityUNIT,
                weight,
                weightUnit,
                userName, false);

            //Getting all the carrier names from UI
            IList<IWebElement> nonGuaranteedCarrierNamesUI = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr/td[1]"));
            List<string> nonGuatanteedCarriers = getListfromWebElement.GetListFromIWebElement(nonGuaranteedCarrierNamesUI);
            nonGuatanteedCarriers = nonGuatanteedCarriers.Select(m => { return m.Split(new string[] { "\r", "\r\n" }, StringSplitOptions.None)[0]; }).ToList();

            for (int i = 0; i <= nonGuatanteedCarriers.Count - 1; i++)
            {
                RateResultCarrierViewModel nonGuaranteedCarriersAPI = accessorialApiResponse.Where(m => (m.CarrierName.ToLower() == nonGuatanteedCarriers[i].ToLower() && !m.IsGuaranteedCarrier)).FirstOrDefault();
                if (nonGuaranteedCarriersAPI != null)
                {
                    //Verifying carriers displaying in UI with API response for Notification service
                    if (nonGuatanteedCarriers[i].Equals(nonGuaranteedCarriersAPI.CarrierName))
                    {
                        havingrequestcode = "NTFY";
                        havingresponsecode = "NOT";
                        Report.WriteLine("Carriers which are providing Notiifcation Services are displaying in Shipment Results Page");
                    }
                }

            }
        }

        [When(@"CRM sends the Accessorial Service (.*) to MG")]
        public void WhenCRMSendsTheAccessorialServiceToMG(string Servicecode)
        {
            ThenCRMWillSendTheAccessorialServiceToMG(Servicecode);
            string Notification1 = Servicecode.Replace(@"<", "");
            string ServiceCodeNTFY = Notification1.Replace(@">", "");

            Report.WriteLine("CRM will send the Accessorial Service code NTFY to mg");
            Assert.AreEqual(havingrequestcode, ServiceCodeNTFY);
        }

        [Then(@"MG will return carrier charges that include the Accessorial Code (.*) to CRM")]
        public void ThenMGWillReturnCarrierChargesThatIncludeTheAccessorialCodeToCRM(string Respondcode)
        {
            string Notification1 = Respondcode.Replace(@"<", "");
            string ServiceCodeNOT = Notification1.Replace(@">", "");

            Report.WriteLine("MG will return charges that included the accessorial code to crm - NOT");
            Assert.AreEqual(havingresponsecode, ServiceCodeNOT);
           
        }

    }
}
