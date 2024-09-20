using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper;
using CRM.UITest.Helper.ViewModel;
using CRM.UITest.Objects;
using CRM.UITest.Scripts.Quote.LTL.Shipment_Information_Screen.Get_Quote__LTL__Screen;
using CRM.UITest.Scripts.Quote.LTL.Shipment_Information_Screen.OverLength_GetQuote_LTL_;
using CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Information_Screen.OverLength_AddShipment__LTL_;
using CRM.UITest.Scripts.Shipment.ShipmentList_InternalUsers.Shipment_List_Reference_Number_Search;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Information_Screen
{
    [Binding]
    public class ConfigureAccessorials_LTL_DisplayAccessorialShipmentSteps : AddShipments
    {
        _46938_ConfigureAccessorials_LTL_DisplayAccessorial_QuoteSteps quoteConfigAccessorial = new _46938_ConfigureAccessorials_LTL_DisplayAccessorial_QuoteSteps();
        OverLength_AddShipmentLTL_TabOrderSteps directShipmentSteps = new OverLength_AddShipmentLTL_TabOrderSteps();
        AddQuoteLTL getQuote = new AddQuoteLTL();
        RateToShipmentLTL rateToShipment = new RateToShipmentLTL();
        AddShipmentLTL ltl = new AddShipmentLTL();
        AddQuoteLTL accessorialSelection = new AddQuoteLTL();
        Quotelist quoteList = new Quotelist();
        ShipmentList_SearchResultsforSubAccountShipmentsSteps login = new ShipmentList_SearchResultsforSubAccountShipmentsSteps();
        OverLength_GetQuote_LTL__NewFields quoteNavigation = new OverLength_GetQuote_LTL__NewFields();
        string OriginZip = string.Empty;
        string OriginCity = string.Empty;
        string OriginState = string.Empty;
        string OriginCountry = string.Empty;
        string accessorialName = string.Empty;
        string DestinationZip = string.Empty;
        string DestinationCity = string.Empty;
        string DestinationState = string.Empty;
        string DestinationCountry = string.Empty;
        string Classification = string.Empty;
        double Quantity = 0;
        double Weight = 0;
        string QuantityUNIT = string.Empty;
        string WeightUnit = string.Empty;
        string destinationAccessorials = string.Empty;
        string originAccessorials = null;
        string UserType = "Internal";
        string Service = "LTL";
        string Username = "";
        string customerName = "ZZZ - Czar Customer Test";
        string accessorialServiceType = string.Empty;
        IList<IWebElement> accessorialsAndServicesOrigin;
        IList<IWebElement> accessorialsAndServicesDestination;
        List<string> oAccessorial;
        List<string> dAccessorial;
        string quoteNumber = string.Empty;
        string userType = string.Empty;



        [Given(@"I am a user with Access to Add Shipment\(LTL\) page (.*)")]
        public void GivenIAmAUserWithAccessToAddShipmentLTLPage(string Usertype)
        {
            userType = Usertype;
            if (Usertype == "External")
            {
                string username = ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();
                string password = ConfigurationManager.AppSettings["ExternalUserPassword"].ToString();
                CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
                CrmLogin.LoginToCRMApplication(username, password);
            }
            else
            {
                login.GivenIMACRMUserWithAccessToShipmentList(Usertype);
            }
        }


        [Given(@"the accessorial was designated to be applied in ""(.*)"" section")]
        public void GivenTheAccessorialWasDesignatedToBeAppliedInSection(string accessorialDirect)
        {
            if (accessorialDirect == "Ship From" || accessorialDirect == "Ship To")
            {
                accessorialName = quoteConfigAccessorial.AddAccessorial(accessorialDirect);
            }
            else
            {

                List<ConfigureAccessorialViewModel> list = DBHelper.AccessorialList();
                for (int i = 0; i < list.Count; i++)
                {

                    if (list[i].AccessorialDirectionName == accessorialDirect && list[i].ShipmentServiceName.Contains("LTL"))
                    {
                        accessorialName = list[i].AccessorialName;
                        break;
                    }
                }
            }
        }

        [Given(@"I on the Add Shipment \(LTL\) page of (.*)")]
        public void GivenIOnTheAddShipmentLTLPageOf(string shipmentType)
        {
            switch (shipmentType)
            {
                case "Direct Shipment":
                    {
                        if (userType == "Internal" || userType == "Sales")
                        {
                            directShipmentSteps.GivenIAmOnAddShipmentLTLPageAsAInternalUser();
                        }
                        else
                        {
                            Click(attributeName_id, "shipment");
                            GlobalVariables.webDriver.WaitForPageLoad();
                            Click(attributeName_id, "add-shipment-btn");
                            GlobalVariables.webDriver.WaitForPageLoad();
                            Click(attributeName_id, "btn_ltl");
                            GlobalVariables.webDriver.WaitForPageLoad();
                        }
                        break;
                    }
                case "Rate To Shipment":
                    {
                        ltl.RateToShipmentNavigation(userType, customerName);
                        break;
                    }
                case "Edit Shipment":
                    {
                        ltl.SelectCustomerFromShipmentListPage(customerName);
                        SendKeys(attributeName_id, "searchbox", "ZZX002011738");
                        GlobalVariables.webDriver.WaitForPageLoad();
                        Click(attributeName_xpath, ".//*[@id='ShipmentGrid']/tbody/tr/td[10]/button");
                        GlobalVariables.webDriver.WaitForPageLoad();

                        break;
                    }
                case "Copy Shipment":
                    {
                        ltl.SelectCustomerFromShipmentListPage(customerName);
                        SendKeys(attributeName_id, "searchbox", "ZZX002011738");
                        GlobalVariables.webDriver.WaitForPageLoad();
                        Click(attributeName_xpath, ".//*[@id='ShipmentGrid']/tbody/tr/td[11]/a[2]/span");
                        GlobalVariables.webDriver.WaitForPageLoad();
                        WaitForElementVisible(attributeName_id, "copy-shipment-Ok", "Copy Confirmation Ok button");
                        Click(attributeName_id, "copy-shipment-Ok");
                        GlobalVariables.webDriver.WaitForPageLoad();
                        break;
                    }
                case "Return Shipment":
                    {
                        ltl.SelectCustomerFromShipmentListPage(customerName);
                        SendKeys(attributeName_id, "searchbox", "ZZX002011738");
                        GlobalVariables.webDriver.WaitForPageLoad();
                        Click(attributeName_xpath, ".//*[@id='ShipmentGrid']/tbody/tr/td[11]/a[3]");
                        GlobalVariables.webDriver.WaitForPageLoad();
                        WaitForElementVisible(attributeName_id, "Return-shipment-Ok", "Return Confirmation Ok button");
                        Click(attributeName_id, "Return-shipment-Ok");
                        GlobalVariables.webDriver.WaitForPageLoad();
                        break;
                    }
            }
        }

        [Given(@"the accessorial was designated to be applied to ""(.*)"" Service types")]
        public void GivenTheAccessorialWasDesignatedToBeAppliedToServiceTypes(string serviceType)
        {
            accessorialServiceType = serviceType;
        }


        [Given(@"I am creating an LTL Shipment")]
        public void GivenIAmCreatingAnLTLShipment()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I click the Click to add services & accessorials field in the ""(.*)"" section")]
        public void WhenIClickTheClickToAddServicesAccessorialsFieldInTheSection(string accessorialDirection)
        {
            Thread.Sleep(1000);
            switch (accessorialDirection)
            {
                case "Ship From":
                    {
                        Click(attributeName_xpath, ShippingFrom_ServicesAccessorial_DropDown_xpath);
                        accessorialsAndServicesOrigin = GlobalVariables.webDriver.FindElements(By.XPath(ShippingFrom_ServicesAccessorial_DropDown_Values_xpath));
                        oAccessorial = accessorialsAndServicesOrigin.Select(a => a.Text).ToList();
                        break;
                    }
                case "Ship To":
                    {
                        Click(attributeName_xpath, ShippingTo_ServicesAccessorial_DropDown_xpath);
                        accessorialsAndServicesDestination = GlobalVariables.webDriver.FindElements(By.XPath(ShippingTo_ServicesAccessorial_DropDown_Values_xpath));
                        dAccessorial = accessorialsAndServicesDestination.Select(a => a.Text).ToList();
                        break;
                    }
                case "Both":
                    {
                        Click(attributeName_xpath, ShippingFrom_ServicesAccessorial_DropDown_xpath);
                        accessorialsAndServicesOrigin = GlobalVariables.webDriver.FindElements(By.XPath(ShippingFrom_ServicesAccessorial_DropDown_Values_xpath));
                        oAccessorial = accessorialsAndServicesOrigin.Select(a => a.Text).ToList();
                        Click(attributeName_xpath, ShippingTo_ServicesAccessorial_DropDown_xpath);
                        accessorialsAndServicesDestination = GlobalVariables.webDriver.FindElements(By.XPath(ShippingTo_ServicesAccessorial_DropDown_Values_xpath));
                        dAccessorial = accessorialsAndServicesDestination.Select(a => a.Text).ToList();
                        break;
                    }
            }
        }

        [When(@"I click on the View Rates button on the Add Shipment \(LTL\) page")]
        public void WhenIClickOnTheViewRatesButtonOnTheAddShipmentLTLPage()
        {

            Report.WriteLine("Clicking View Rates button");
            scrollElementIntoView(attributeName_xpath, ViewRatesButton_xpath);
            ltl.ClickViewRates();
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Then(@"I will see the accessorial displayed  in the ""(.*)"" drop down list")]
        public void ThenIWillSeeTheAccessorialDisplayedInTheDropDownList(string accessorialDirection)
        {
            switch (accessorialDirection)
            {
                case "Ship From":
                    {
                        bool isPresentInShippingFromAccessorial = oAccessorial.Where(a => a == (accessorialName)).Any();
                        Assert.IsTrue(isPresentInShippingFromAccessorial);
                        break;
                    }
                case "Ship To":
                    {
                        bool isPresentInShippingToAccessorial = dAccessorial.Where(a => a == (accessorialName)).Any();
                        Assert.IsTrue(isPresentInShippingToAccessorial);

                        break;
                    }
                case "Both":
                    {
                        bool isPresentInShippingFromAccessorial = oAccessorial.Where(a => a == (accessorialName)).Any();
                        bool isPresentInShippingToAccessorial = dAccessorial.Where(a => a == (accessorialName)).Any();
                        Assert.IsTrue(isPresentInShippingFromAccessorial && isPresentInShippingToAccessorial);
                        break;
                    }
            }
        }

        [Then(@"I will not see the accessorial displayed in the ""(.*)"" drop down list")]
        public void ThenIWillNotSeeTheAccessorialDisplayedInTheDropDownList(string accessorialDirection)
        {
            switch (accessorialDirection)
            {
                case "Ship To":
                    {
                        IList<IWebElement> accessorialsAndServices = GlobalVariables.webDriver.FindElements(By.XPath(ShippingTo_ServicesAccessorial_DropDown_Values_xpath));
                        bool isNotPresentInShippingToAccessorial = accessorialsAndServices.Where(a => a.Text != (accessorialName)).Any();
                        Assert.IsTrue(isNotPresentInShippingToAccessorial);
                        break;
                    }
                case "Ship From":
                    {
                        IList<IWebElement> accessorialsAndServices = GlobalVariables.webDriver.FindElements(By.XPath(ShippingFrom_ServicesAccessorial_DropDown_Values_xpath));
                        bool isNotPresentInShippingFromAccessorial = accessorialsAndServices.Where(a => a.Text != (accessorialName)).Any();
                        Assert.IsTrue(isNotPresentInShippingFromAccessorial);
                        break;
                    }
            }
        }

        [Given(@"I on Add Shipment \(LTL\) page of (.*)")]
        public void GivenIOnAddShipmentLTLPageOf(string shipment)
        {
            switch (shipment)
            {
                case "Direct Shipment":
                    {
                        if (userType == "Internal" || userType == "Sales")
                        {
                            AddShipmentLTL ltl = new AddShipmentLTL();
                            ltl.SelectCustomerFromShipmentListPage(customerName);
                            Click(attributeName_id, AddShipmentButtionInternal_Id);
                            Click(attributeName_id, AddShipmentLTL_Button_Id);
                        }
                        else
                        {
                            Click(attributeName_id, "shipment");
                            GlobalVariables.webDriver.WaitForPageLoad();
                            Click(attributeName_id, "add-shipment-btn");
                            GlobalVariables.webDriver.WaitForPageLoad();
                            Click(attributeName_id, "btn_ltl");
                        }
                        ltl.DirectShipmentEnterShipmentDatas();
                        GetAddShipmentLTLPageDatas();
                        break;
                    }
                case "Rate To Shipment":
                    {
                        ltl.RateToShipmentNavigation(userType, customerName);
                        GetAddShipmentLTLPageDatas();
                        break;
                    }

                case "Quote To Shipment":
                    {
                        ltl.QuoteToShipmentNavigation(userType, customerName);
                        GetAddShipmentLTLPageDatas();
                        break;
                    }
                case "Edit Shipment":
                    {
                        ltl.SelectCustomerFromShipmentListPage(customerName);
                        SendKeys(attributeName_id, "searchbox", "ZZX002011738");
                        GlobalVariables.webDriver.WaitForPageLoad();
                        Click(attributeName_xpath, ".//*[@id='ShipmentGrid']/tbody/tr/td[10]/button");
                        GlobalVariables.webDriver.WaitForPageLoad();
                        GetAddShipmentLTLPageDatas();
                        break;
                    }
                case "Copy Shipment":
                    {
                        ltl.SelectCustomerFromShipmentListPage(customerName);
                        SendKeys(attributeName_id, "searchbox", "ZZX002011738");
                        GlobalVariables.webDriver.WaitForPageLoad();
                        Click(attributeName_xpath, ".//*[@id='ShipmentGrid']/tbody/tr/td[11]/a[2]/span");
                        GlobalVariables.webDriver.WaitForPageLoad();
                        WaitForElementVisible(attributeName_id, "copy-shipment-Ok", "Copy Confirmation Ok button");
                        Click(attributeName_id, "copy-shipment-Ok");
                        GlobalVariables.webDriver.WaitForPageLoad();
                        GetAddShipmentLTLPageDatas();
                        break;
                    }
                case "Return Shipment":
                    {
                        ltl.SelectCustomerFromShipmentListPage(customerName);
                        SendKeys(attributeName_id, "searchbox", "ZZX002011738");
                        GlobalVariables.webDriver.WaitForPageLoad();
                        Click(attributeName_xpath, ".//*[@id='ShipmentGrid']/tbody/tr/td[11]/a[3]");
                        GlobalVariables.webDriver.WaitForPageLoad();
                        WaitForElementVisible(attributeName_id, "Return-shipment-Ok", "Return Confirmation Ok button");
                        Click(attributeName_id, "Return-shipment-Ok");
                        GlobalVariables.webDriver.WaitForPageLoad();
                        GetAddShipmentLTLPageDatas();
                        scrollPageup();

                        Click(attributeName_xpath, Overlength_ShippingTo_ServicesAccessorial_DropDown_xpath);
                        IList<IWebElement> AccessorialDropdown_List = GlobalVariables.webDriver.FindElements(By.XPath(Overlength_ShippingTo_ServicesAccessorial_DropDown_Values_xpath));
                        int AccessorialDropdownListCount = AccessorialDropdown_List.Count;
                        for (int i = 0; i < AccessorialDropdownListCount; i++)
                        {
                            if (AccessorialDropdown_List[i].Text == "Inside Delivery")
                            {
                                AccessorialDropdown_List[i].Click();
                                break;
                            }
                        }
                        destinationAccessorials = Gettext(attributeName_xpath, ".//*[@id='shippingtoaccessorial_chosen']/ul/li[1]");
                        break;
                    }
            }
        }


        [Then(@"CRM will send the New Service Code")]
        public void ThenCRMWillSendTheNewServiceCode()
        {
            List<IndividualAccessorialModel> rateResponse;
            rateResponse = GetRatesAndCarriersAPICall.BuildIndividualAccessorialModelFromCostPriceSheet(customerName, Service, OriginCity, OriginZip, OriginState, OriginCountry,
                DestinationCity, DestinationZip, DestinationState, DestinationCountry, originAccessorials, destinationAccessorials, Classification, Quantity, QuantityUNIT, Weight, WeightUnit, Username, true);

            string mgDescription = string.Empty;
            foreach (IndividualAccessorialModel priceSheetModel in rateResponse)
            {
                if (priceSheetModel.AccessorialCode == "IDL")
                {
                    mgDescription = priceSheetModel.discription;
                    break;
                }
            }
            AccessorialMGDescription mgDescriptionTableDatas = DBHelper.GetMGDescriptionData("IDL");
            Assert.AreEqual(mgDescription, mgDescriptionTableDatas.MGDescription);
        }


        [Given(@"the accessorial was not designated LTL Service types")]
        public void GivenTheAccessorialWasNotDesignatedLTLServiceTypes()
        {
            accessorialServiceType = "Non LTL";
        }

        [Given(@"the accessorial was designated to Non LTL ""(.*)"" section")]
        public void GivenTheAccessorialWasDesignatedToNonLTLSection(string accessorialDirect)
        {
            if (accessorialDirect != "Both")
            {
                string accessorialDirection = accessorialDirect;
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

                    if (list[i].AccessorialDirectionName == accessorialDirection && !(list[i].ShipmentServiceName.Contains("LTL")))
                    {
                        accessorialName = list[i].AccessorialName;
                        break;
                    }
                }
            }
            else
            {
                List<ConfigureAccessorialViewModel> list = DBHelper.AccessorialList();
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].AccessorialDirectionName == accessorialDirect && !(list[i].ShipmentServiceName.Contains("LTL")))
                    {
                        accessorialName = list[i].AccessorialName;
                        break;
                    }
                }
            }
        }

        [Then(@"I will not see the accessorial in the ""(.*)"" drop down list")]
        public void ThenIWillNotSeeTheAccessorialInTheDropDownList(string accessorialDirection)
        {
            switch (accessorialDirection)
            {
                case "Ship From":
                    {
                        IList<IWebElement> accessorialsAndServices = GlobalVariables.webDriver.FindElements(By.XPath(ShippingFrom_ServicesAccessorial_DropDown_Values_xpath));

                        bool isPresentInShippingFromAccessorial = accessorialsAndServices.Where(a => a.Text != (accessorialName)).Any();
                        Assert.IsTrue(isPresentInShippingFromAccessorial);
                        break;
                    }
                case "Ship To":
                    {
                        IList<IWebElement> accessorialsAndServices = GlobalVariables.webDriver.FindElements(By.XPath(ShippingTo_ServicesAccessorial_DropDown_Values_xpath));

                        bool isPresentInShippingToAccessorial = accessorialsAndServices.Where(a => a.Text != (accessorialName)).Any();
                        Assert.IsTrue(isPresentInShippingToAccessorial);

                        break;
                    }
                case "Both":
                    {
                        bool isPresentInShippingFromAccessorial = oAccessorial.Where(a => a != (accessorialName)).Any();
                        bool isPresentInShippingToAccessorial = dAccessorial.Where(a => a != (accessorialName)).Any();
                        Assert.IsTrue(isPresentInShippingFromAccessorial && isPresentInShippingToAccessorial);
                        break;
                    }
            }
        }
        public void GetAddShipmentLTLPageDatas()
        {
            OriginZip = GetValue(attributeName_id, ShippingFrom_zipcode_Id, "value");
            OriginCity = GetValue(attributeName_id, ShippingTo_City_Id, "value");
            OriginState = Gettext(attributeName_xpath, ShippingFrom_StateDropdwon_xpath);
            OriginCountry = "USA";

            DestinationZip = GetValue(attributeName_id, ShippingTo_zipcode_Id, "value");
            DestinationCity = GetValue(attributeName_id, ShippingTo_City_Id, "value");
            DestinationState = Gettext(attributeName_xpath, ShippingTo_StateDropdwon_xpath);
            DestinationCountry = "USA";

            destinationAccessorials = Gettext(attributeName_xpath, ".//*[@id='shippingtoaccessorial_chosen']/ul/li[1]");
            scrollpagedown();
            scrollpagedown();

            Classification = GetValue(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id, "value");
            Quantity = Convert.ToDouble(GetValue(attributeName_id, FreightDesp_FirstItem_Quantity_Id, "value"));
            Weight = Convert.ToDouble(GetValue(attributeName_id, FreightDesp_FirstItem_Weight_Id, "value"));
            QuantityUNIT = Gettext(attributeName_xpath, FreightDesp_FirstItem_QuantityType_xpath);
            WeightUnit = Gettext(attributeName_xpath, FreightDesp_FirstItem_WeightType_xpath);
        }
    }
}
