using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Helper;
using CRM.UITest.Helper.ViewModel;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Add_Shipment__LTL____New_Accessorial___Notification
{
    [Binding]
    public class AddShipmentLTL_NewAccessorial_NotificationSteps : AddShipments
    {
        CommonMethodsCrm crmLogin = new CommonMethodsCrm();
        AddShipmentLTL ltlShipment = new AddShipmentLTL();
        WebElementOperations getListfromWebElement = new WebElementOperations();
        CommonShipmentNavigations shipmentNavigations = new CommonShipmentNavigations();
        string userType = "Internal";
        string customerName = "ZZZ - GS Customer Test";
        string service = "LTL";
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
        string quantityUNIT = "pallets";
        double weight = 4;
        string weightUnit = "LBS";
        string userName = null;
        List<RateResultCarrierViewModel> accessorialApiResponse = null;
        bool iSCrmRatingLogic_GainshareCustomer;

        [Given(@"I am a shp\.entry, shp\.entrynorates, sales, sales management, operations or station owner user")]
        public void GivenIAmAShp_EntryShp_EntrynoratesSalesSalesManagementOperationsOrStationOwnerUser()
        {
            userName = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
            string password = ConfigurationManager.AppSettings["password-crmOperation"].ToString();
            crmLogin.LoginToCRMApplication(userName, password);
        }

        [Given(@"I selected new accessorial Notification in Shipping From section of Add Shipment \(LTL\) page")]
        public void GivenISelectedNewAccessorialNotificationInShippingFromSectionOfAddShipmentLTLPage()
        {
            shipmentNavigations.SelectNotificationAccessorialinShippingFrom(userType);
            Report.WriteLine("selected new accessorial Notification in Shipping From section");
        }

        [Given(@"I selected new accessorial Notification in Shipping To section of Add Shipment \(LTL\) page")]
        public void GivenISelectedNewAccessorialNotificationInShippingToSectionOfAddShipmentLTLPage()
        {
            shipmentNavigations.SelectNotificationAccessorialinShippingTo(userType);
            Report.WriteLine("selected new accessorial Notification in Shipping To section");
        }

        [Given(@"I selected new accessorial Notification in Shipping From and To sections of Add Shipment \(LTL\) page")]
        public void GivenISelectedNewAccessorialNotificationInShippingFromAndToSectionsOfAddShipmentLTLPage()
        {
            shipmentNavigations.SelectNotificationAccessorialinShippingFromAndTo(userType);
            Report.WriteLine("selected new accessorial Notification in Shipping From and To sections");
        }

        [When(@"I click on add services and accessorials drop down of Shipping From section")]
        public void WhenIClickOnAddServicesAndAccessorialsDropDownOfShippingFromSection()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            ltlShipment.AddShipment_ShippingFromData("Test", "Test", originZip, originCountry, "", originCity, originState);
            scrollpagedown();
            Click(attributeName_xpath, ShippingFrom_ServicesAccessorial_DropDown_xpath);
            Report.WriteLine("Clicked on add services and accessorials... drop down in Shipping From section");
        }

        [When(@"I click on add services and accessorials drop down of Shipping To section")]
        public void WhenIClickOnAddServicesAndAccessorialsDropDownOfShippingToSection()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            ltlShipment.AddShipment_ShippingToData("Test", "Test", destinationZip, destinationCountry, "", destinationCity, destinationState);
            scrollpagedown();
            Click(attributeName_xpath, ShippingTo_ServicesAccessorial_DropDown_xpath);
            Report.WriteLine("Clicked on add services and accessorials... drop down in Shipping To section");
        }

        [When(@"I Click on View Rates button")]
        public void WhenIClickOnViewRatesButton()
        {
            scrollElementIntoView(attributeName_xpath, ViewRatesButton_xpath);
            Click(attributeName_xpath, ViewRatesButton_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Clicked on View Rates button");
        }

        [When(@"I click on standard Create Shipment button on Shipment Results Page")]
        public void WhenIClickOnStandardCreateShipmentButtonOnShipmentResultsPage()
        {
            scrollElementIntoView(attributeName_xpath, ViewRatesButton_xpath);
            Click(attributeName_xpath, ViewRatesButton_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            ltlShipment.ClickOnCreateShipmentButton(userType);
            Report.WriteLine("Clicked on standard Create Shipment button");
        }

        [When(@"I click on Create Insured Shipment button on Shipment Results Page")]
        public void WhenIClickOnCreateInsuredShipmentButtonOnShipmentResultsPage()
        {
            scrollElementIntoView(attributeName_xpath, ViewRatesButton_xpath);
            SendKeys(attributeName_id, InsuredValue_TextBox_Id, "1234.05");
            Click(attributeName_xpath, ViewRatesButton_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            ltlShipment.ClickOnCreateInsuredShipmentButton(userType);
            Report.WriteLine("Clicked on Create Insured Shipment button");
        }

        [When(@"I click on Guaranteed Create Shipment button on Shipment Results Page")]
        public void WhenIClickOnGuaranteedCreateShipmentButtonOnShipmentResultsPage()
        {
            scrollElementIntoView(attributeName_xpath, ViewRatesButton_xpath);
            Click(attributeName_xpath, ViewRatesButton_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("I click on create shipment for selected guaranteed carrier");
            Click(attributeName_id, ShipResults_GuaranteedRateAvailableButton_Id);
            Thread.Sleep(2000);
            Click(attributeName_xpath, ShipResultsGuaranteed_standardShipButton_Xpath);
            Report.WriteLine("Clicked on Guaranteed Create Shipment button");
        }

        [When(@"I click on Guaranteed Create Insured Shipment button on Shipment Results Page")]
        public void WhenIClickOnGuaranteedCreateInsuredShipmentButtonOnShipmentResultsPage()
        {
            scrollElementIntoView(attributeName_xpath, ViewRatesButton_xpath);
            SendKeys(attributeName_id, InsuredValue_TextBox_Id, "1234.05");
            Click(attributeName_xpath, ViewRatesButton_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("I click on create insured shipment for selected guaranteed carrier");
            Click(attributeName_id, ShipResults_GuaranteedRateAvailableButton_Id);
            Thread.Sleep(2000);
            Click(attributeName_xpath, ShipResultsGuaranteed_InsuredShipButton_Xpath);
            Report.WriteLine("Clicked on Guaranteed Create Insured Shipment button");
        }

        [Then(@"NOTIFICATION accessorial will be displayed in alphabetically in Shipping From Section")]
        public void ThenNOTIFICATIONAccessorialWillBeDisplayedInAlphabeticallyInShippingFromSection()
        {
            IList<IWebElement> shippingFromAccessorialDropdownList = GlobalVariables.webDriver.FindElements(By.XPath(ShippingFrom_ServicesAccessorial_DropDown_Values_xpath));
            List<string> actualShippingFromAccessorialDropdownList = getListfromWebElement.GetListFromIWebElement(shippingFromAccessorialDropdownList);
            CollectionAssert.AreEqual(actualShippingFromAccessorialDropdownList.OrderBy(q => q).ToList(), actualShippingFromAccessorialDropdownList);
            Report.WriteLine("Displayed new accessorial Notification in alphabetical order in Shipping From section");
        }

        [Then(@"NOTIFICATION accessorial will be displayed in alphabetically in Shipping To Section")]
        public void ThenNOTIFICATIONAccessorialWillBeDisplayedInAlphabeticallyInShippingToSection()
        {
            IList<IWebElement> shippingToAccessorialDropdownList = GlobalVariables.webDriver.FindElements(By.XPath(ShippingTo_ServicesAccessorial_DropDown_Values_xpath));
            List<string> actualShippingToAccessorialDropdownList = getListfromWebElement.GetListFromIWebElement(shippingToAccessorialDropdownList);
            CollectionAssert.AreEqual(actualShippingToAccessorialDropdownList.OrderBy(q => q).ToList(), actualShippingToAccessorialDropdownList);
            Report.WriteLine("Displayed new accessorial Notification in alphabetical order in Shipping To section");
        }

        [Then(@"CRM will send the accessorial service NTFY to MG, it will return carrier charges that include the Accessorial Code NOT to CRM")]
        public void ThenCRMWillSendTheAccessorialServiceNTFYToMGItWillReturnCarrierChargesThatIncludeTheAccessorialCodeNOTToCRM()
        {
            //CRM sending accessorial NTFY to MG request and Mg returning NOT to CRM
            accessorialApiResponse = GetRatesAndCarriersAPICall.CallRateRequestApiWithAccessorials(customerName,
                service,
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
            IList<IWebElement> nonGuaranteedCarrierNamesUI = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='ShipmentResultTable']//tbody/tr/td[1]"));
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
                        Report.WriteLine("Carriers which are providing Notiifcation Services are displaying in Shipment Results Page");
                    }
                }

            }
        }

        [Then(@"Notification will be displayed in accessorial field of Shipping From Section on Review and Submit Shipment \(LTL\) Page")]
        public void ThenNotificationWillBeDisplayedInAccessorialFieldOfShippingFromSectionOnReviewAndSubmitShipmentLTLPage()
        {
            WaitForElementVisible(attributeName_xpath, ReviewAndSubmit_Title_Xpath, "Review and Submit Shipment(LTL)");
            scrollElementIntoView(attributeName_xpath, ReviewSubmit_ShippingFrom_Accessorial_Xpath);
            string shippingFromAccessorial = Gettext(attributeName_xpath, ReviewSubmit_ShippingFrom_Accessorial_Xpath);
            string expAccessorial = "Notification";
            string[] accessorialValues = shippingFromAccessorial.Split(':');
            string actualAccessorialValue = accessorialValues[0];
            Assert.AreEqual(expAccessorial, actualAccessorialValue);
            Report.WriteLine("New Accessorial Notification displayed in Shipping From Section on Review and Submit Page");
        }

        [Then(@"Notification will be displayed in accessorial field of Shipping To Section on Review and Submit Shipment \(LTL\) Page")]
        public void ThenNotificationWillBeDisplayedInAccessorialFieldOfShippingToSectionOnReviewAndSubmitShipmentLTLPage()
        {
            WaitForElementVisible(attributeName_xpath, ReviewAndSubmit_Title_Xpath, "Review and Submit Shipment(LTL)");
            scrollElementIntoView(attributeName_xpath, ReviewSubmit_ShippingTo_Accessorial_Xpath);
            string shippingToAccessorial = Gettext(attributeName_xpath, ReviewSubmit_ShippingTo_Accessorial_Xpath);
            string expAccessorial = "Notification";
            string[] accessorialValues = shippingToAccessorial.Split(':');
            string actualAccessorialValue = accessorialValues[0];
            Assert.AreEqual(expAccessorial, actualAccessorialValue);
            Report.WriteLine("New Accessorial Notification displayed in Shipping To Section on Review and Submit Page");
        }

        [Then(@"Notification will be displayed in accessorial field of Shipping From and To Sections on Review and Submit Shipment \(LTL\) Page")]
        public void ThenNotificationWillBeDisplayedInAccessorialFieldOfShippingFromAndToSectionsOnReviewAndSubmitShipmentLTLPage()
        {
            WaitForElementVisible(attributeName_xpath, ReviewAndSubmit_Title_Xpath, "Review and Submit Shipment(LTL)");
            string shippingFromAccessorial = Gettext(attributeName_xpath, ReviewSubmit_ShippingFrom_Accessorial_Xpath);
            string expAccessorial = "Notification";
            Assert.AreEqual(expAccessorial, shippingFromAccessorial);
            string shippingToAccessorial = Gettext(attributeName_xpath, ReviewSubmit_ShippingTo_Accessorial_Xpath);
            Assert.AreEqual(expAccessorial, shippingToAccessorial);
            Report.WriteLine("New Accessorial Notification displayed in Shipping From and To Sections on Review and Submit Page");
        }

        [Then(@"I will display with new accessorial type NOTIFICATION in Shipping From Section")]
        public void ThenIWillDisplayWithNewAccessorialTypeNOTIFICATIONInShippingFromSection()
        {
            Report.WriteLine("Verifying new accessorial Notification in Shipping From section");
            IList<IWebElement> accessorialDropdownListOFShippingFrom = GlobalVariables.webDriver.FindElements(By.XPath(ShippingFrom_ServicesAccessorial_DropDown_Values_xpath));
            int shippingFromAccessorialDropdownListCount = accessorialDropdownListOFShippingFrom.Count;
            for (int i = 0; i < shippingFromAccessorialDropdownListCount; i++)
            {
                if (accessorialDropdownListOFShippingFrom[i].Text == "Notification")
                {
                    string actualAccessorial = accessorialDropdownListOFShippingFrom[i].Text;
                    Assert.AreEqual("Notification", actualAccessorial);
                    break;
                }
            }
        }

        [Then(@"I will display with new accessorial type NOTIFICATION in Shipping To Section")]
        public void ThenIWillDisplayWithNewAccessorialTypeNOTIFICATIONInShippingToSection()
        {
            Report.WriteLine("Verifying new accessorial Notification in Shipping To section");
            IList<IWebElement> accessorialDropdownListOfShippingTo = GlobalVariables.webDriver.FindElements(By.XPath(ShippingTo_ServicesAccessorial_DropDown_Values_xpath));
            int shippingToAccessorialDropdownListCount = accessorialDropdownListOfShippingTo.Count;
            for (int i = 0; i < shippingToAccessorialDropdownListCount; i++)
            {
                if (accessorialDropdownListOfShippingTo[i].Text == "Notification")
                {
                    string actualAccessorial = accessorialDropdownListOfShippingTo[i].Text;
                    Assert.AreEqual("Notification", actualAccessorial);
                    break;
                }
            }
        }

    }
}
