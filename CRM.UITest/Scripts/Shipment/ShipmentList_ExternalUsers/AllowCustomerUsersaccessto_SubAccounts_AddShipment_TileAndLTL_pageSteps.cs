using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.Implementations.ShipmentList;
using CRM.UITest.Helper.Implementations.StandardReport;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Xml.Linq;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Helper.Common;
using CRM.UITest.Helper.DataModels;

namespace CRM.UITest.Scripts.Shipment.ShipmentList_ExternalUsers
{
    [Binding]
    public  class AllowCustomerUsersaccessto_SubAccounts_AddShipment_TileAndLTL_pageSteps : AddShipments
    {

        string AllCustomerAccount = "";
        string Primary_AccountCustomer = "ZZZ - Czar Customer Test";
         string Sub_AccountCustomer = "36691 scenario1 subacc";
        string CustomerfromDropdown = "";

        public string passedcustomer;

        [Given(@"I am on the service selection tiles page")]
        public void GivenIAmOnTheServiceSelectionTilesPage()
        {
            Report.WriteLine("Click on Add Shipment Button");
            Click(attributeName_id, ShipmentList_AddShipmentButton_Id);

            Report.WriteLine("I am on the Add Shipment Tiles page");
            VerifyElementVisible(attributeName_xpath, ShipmentList_Title_Xpath, "Add Shipment");
        }



        [When(@"I will arrive on the Add Shipment LTL page")]
        public void WhenIWillArriveOnTheAddShipmentLTLPage()
        {
            Report.WriteLine("Add Shipment page");
            WaitForElementVisible(attributeName_xpath, ShipmentList_LTLPage_Header_Xpath, "Add Shipment (LTL)");
            Verifytext(attributeName_xpath, ShipmentList_LTLPage_Header_Xpath, "Add Shipment (LTL)");

        }

        [When(@"I am on the Add Shipment LTL page")]
        public void WhenIAmOnTheAddShipmentLTLPage()
        {
            Report.WriteLine("Click on Add Shipment Button");
            Click(attributeName_id, ShipmentList_AddShipmentButton_Id);

            Report.WriteLine("Click on LTL option on tiles page");
            Click(attributeName_id, ShipmentList_LTLtile_Id);

            Report.WriteLine("I am on the Add Shipment LTL Page");
            WaitForElementVisible(attributeName_xpath, ShipmentList_LTLPage_Header_Xpath, "Add Shipment (LTL)");
            Verifytext(attributeName_xpath, ShipmentList_LTLPage_Header_Xpath, "Add Shipment (LTL)");
        }


        [Then(@"I will arrive on the Add Shipment Tile Page")]
        public void ThenIWillArriveOnTheAddShipmentTilePage()
        {
            Report.WriteLine("I will arrive on add shipment tiles page");
            VerifyElementPresent(attributeName_xpath, ShipmentList_Title_Xpath, "Add Shipment");
        }

        [Then(@"I will only see the LTL Service Type Option")]
        public void ThenIWillOnlySeeTheLTLServiceTypeOption()
        {
            Report.WriteLine("I will see the LTL Service type option");
            VerifyElementPresent(attributeName_id, ShipmentList_LTLtile_Id, "LTL");

        }


        [When(@"I click on the LTL option on the tiles page")]
        public void WhenIClickOnTheLTLOptionOnTheTilesPage()
        {
            Report.WriteLine("Click on LTL option on tiles page");
            Click(attributeName_id, ShipmentList_LTLtile_Id);

        }

        [Then(@"I will arrive on the Add Shipment LTL page")]
        public void ThenIWillArriveOnTheAddShipmentLTLPage()
        {
            WaitForElementVisible(attributeName_xpath, ShipmentList_LTLPage_Header_Xpath, "Add Shipment (LTL)");
            Report.WriteLine("I arrive on Add Shipment LTL Page");
            Verifytext(attributeName_xpath, ShipmentList_LTLPage_Header_Xpath, "Add Shipment (LTL)");
        }

        [Given(@"I selected any Primary Account from the customer drop down list on the shipment list page")]
        public void GivenISelectedAnyPrimaryAccountFromTheCustomerDropDownListOnTheShipmentListPage()
        {
            Report.WriteLine("Click on the Shipment icon from the left navigation bar");
            Click(attributeName_xpath, ShipmentIcon_Xpath);

            Report.WriteLine("I selected the Primary Account option from the drop down");

            Click(attributeName_xpath, CustomerDropdownExtuser_Xpath);
            Report.WriteLine("Selecting" + Primary_AccountCustomer + "from the Customer dropdown list");

            IList<IWebElement> CustomerDropdown_List = GlobalVariables.webDriver.FindElements(By.XPath(CustomerDropdownValesExtuser_Xpath));
            int CustomerNameListCount = CustomerDropdown_List.Count;
            for (int i = 0; i < CustomerNameListCount; i++)
            {
                if (CustomerDropdown_List[i].Text == Primary_AccountCustomer)
                {
                    CustomerDropdown_List[i].Click();
                    break;
                }
            }

            Report.WriteLine("Click on Add Shipment Button");
            Click(attributeName_id, ShipmentList_AddShipmentButton_Id);

            Report.WriteLine("Click on LTL option on tiles page");
            Click(attributeName_id, ShipmentList_LTLtile_Id);
        }

        [Then(@"I will see the Primary Account customer name displayed on the Add Shipment LTL page")]
        public void ThenIWillSeeThePrimaryAccountCustomerNameDisplayedOnTheAddShipmentLTLPage()
        {
           
            Report.WriteLine("Primary Account Customer Name should be displayed on the Add Shipment LTL page");
            string CustomerNameDisplayed = Gettext(attributeName_xpath, Customernameon_AddShipment_LTL_Xpath);
            Assert.AreEqual(Primary_AccountCustomer, CustomerNameDisplayed);

        }

        [Then(@"I will see the Sub Account customer name displayed on the Add Shipment LTL page")]
        public void ThenIWillSeeTheSubAccountCustomerNameDisplayedOnTheAddShipmentLTLPage()
        {
          
            Report.WriteLine("Sub Account Customer Name should be displayed on the Add Shipment LTL page");
            string CustomerNameDisplayed = Gettext(attributeName_xpath, Customernameon_AddShipment_LTL_Xpath);
            Assert.AreEqual(Sub_AccountCustomer, CustomerNameDisplayed);

        }

        [Given(@"I have selected a (.*) with (.*) on the Shipment List page and navigated away from shipment list page")]
        public void GivenIHaveSelectedAWithOnTheShipmentListPageAndNavigatedAwayFromShipmentListPage(string Customer, string TMS_Type)
        {
            passedcustomer = Customer;

            if (TMS_Type == "MG")
            {
                Report.WriteLine("Click on the Shipment icon from the left navigation bar");
                Click(attributeName_xpath, ShipmentIcon_Xpath);

                Click(attributeName_xpath, CustomerDropdownExtuser_Xpath);
                Report.WriteLine("Selecting" + Sub_AccountCustomer + "from the Customer dropdown list");

                IList<IWebElement> CustomerDropdown_List = GlobalVariables.webDriver.FindElements(By.XPath(CustomerDropdownValesExtuser_Xpath));
                int CustomerNameListCount = CustomerDropdown_List.Count;
                for (int i = 0; i < CustomerNameListCount; i++)
                {
                    if (CustomerDropdown_List[i].Text == Sub_AccountCustomer)
                    {
                        CustomerDropdown_List[i].Click();
                        break;
                    }
                }

                Report.WriteLine("Navigated away from the shipment list page");
                Click(attributeName_xpath, ".//*[@id='raterequest']/i");
                Verifytext(attributeName_xpath, "//*[text()='Quotes']", "Quotes");
            }
            else
            {
                Report.WriteLine("Click on the Shipment icon from the left navigation bar");
                Click(attributeName_xpath, ShipmentIcon_Xpath);

                Click(attributeName_xpath, CustomerDropdownExtuser_Xpath);
                Report.WriteLine("Selecting" + Sub_AccountCustomer + "from the Customer dropdown list");

                IList<IWebElement> CustomerDropdown_List = GlobalVariables.webDriver.FindElements(By.XPath(CustomerDropdownValesExtuser_Xpath));
                int CustomerNameListCount = CustomerDropdown_List.Count;
                for (int i = 0; i < CustomerNameListCount; i++)
                {
                    if (CustomerDropdown_List[i].Text == Sub_AccountCustomer)
                    {
                        CustomerDropdown_List[i].Click();
                        break;
                    }
                }

                Report.WriteLine("Navigated away from the shipment list page");
                Click(attributeName_xpath, ".//*[@id='raterequest']/i");
                Verifytext(attributeName_xpath, ".//*[@id='page-content-wrapper']//h1","Quotes");
            }
        }


        [When(@"I return to the Shipment List page")]
        public void WhenIReturnToTheShipmentListPage()
        {
            Click(attributeName_xpath, ShipmentModule_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("I return back to Shipment List Page");
            Verifytext(attributeName_xpath, ShipmentList_Header_Xpath, "Shipment List");
        }

        [Then(@"The customer previously selected will be selected in the customer drop down list")]
        public void ThenTheCustomerPreviouslySelectedWillBeSelectedInTheCustomerDropDownList()
        {
            Report.WriteLine("Previously selected customer from the dropdown that only selected");
            string SelectedCustomer = Gettext(attributeName_xpath, CustomerDropdownExtuser_Xpath);
            string [] Customer_Selected = SelectedCustomer.Split('-');
            string PreviouslySelectedCustomer = Customer_Selected[2];
            string ActualSelectedCustomer = PreviouslySelectedCustomer.TrimStart();
           
            Assert.AreEqual(passedcustomer, ActualSelectedCustomer);
        }

        [Then(@"The shipment list will display any shipments associated to the customer for the previous Thirty days")]
        public void ThenTheShipmentListWillDisplayAnyShipmentsAssociatedToTheCustomerForThePreviousThirtyDays()
        {

            int accID = DBHelper.GetAccountIdforAccountName(passedcustomer);
            CustomerSetup value = DBHelper.GetSetupDetails(accID);

            // Building request xml
            ListScreenExtractRequestXML data = new ListScreenExtractRequestXML();
            XElement reqXML = data.GetRequestXMLForShipmentListExternalUser(value.MgAccountNumber, "CRM-ShpPrev30DaysAgent", passedcustomer);

            //Building Client
            BuildHttpClient client = new BuildHttpClient();
            HttpClient headers = client.BuildHttpClientWithHeaders(passedcustomer, "application/xml");


            string uri = $"MercuryGate/ListScreenExtract";
            ShipmentListScreen Slist = new ShipmentListScreen();
            List<Helper.ViewModel.Shipment.ShipmentListViewModel> Sdata = Slist.CallListScreen(uri, headers, reqXML);

            List<String> ShipmentList = new List<string>();

            if (Sdata != null)
            {

                for (int j = 1; j < Sdata.Count; j++)
                {
                    ShipmentList.Add(Sdata[j].PrimaryReference);
                }
            }
            else
            {
                Report.WriteLine("No Response from API");
            }

            IList<IWebElement> UIShipmentVal = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentListGrid_RefNumAllValues_Xpath));
            List<string> UIValue = new List<string>();
            if (ShipmentList.Count > 1)
            {
                for (int k = 0; k < UIShipmentVal.Count; k++)
                {
                    string UIShipNum = UIShipmentVal[k].Text;
                    UIValue.Add(UIShipNum);
                }

                Assert.AreEqual(ShipmentList.Count, UIValue.Count);

            }
            else
            {
                Report.WriteLine("Values does not exist in shipment list response");
            }
        }

        

        [Given(@"I have selected a (.*) with (.*)on the Shipment List page")]
        public void GivenIHaveSelectedAWithOnTheShipmentListPage(string Customer, string TMS_Type)
        {
            passedcustomer = Customer;
            if (TMS_Type == "MG")
            {
                Report.WriteLine("Click on the Shipment icon from the left navigation bar");
                Click(attributeName_xpath, ShipmentIcon_Xpath);

                Click(attributeName_xpath,CustomerDropdownExtuser_Xpath);
                Report.WriteLine("Selecting" + Customer + "from the Customer dropdown list");

                IList<IWebElement> CustomerDropdown_List = GlobalVariables.webDriver.FindElements(By.XPath(CustomerDropdownValesExtuser_Xpath));
                int CustomerNameListCount = CustomerDropdown_List.Count;
                for (int i = 0; i < CustomerNameListCount; i++)
                {
                    if (CustomerDropdown_List[i].Text == Customer)
                    {
                        CustomerDropdown_List[i].Click();
                        break;
                    }
                }

                Report.WriteLine("Click on Quote module");
                Click(attributeName_xpath, ".//*[@id='raterequest']/i");
            }
            else
            {
                Report.WriteLine("Click on the Shipment icon from the left navigation bar");
                Click(attributeName_xpath, ShipmentIcon_Xpath);

                Click(attributeName_xpath, CustomerDropdownExtuser_Xpath);
                Report.WriteLine("Selecting" + Customer + "from the Customer dropdown list");

                IList<IWebElement> CustomerDropdown_List = GlobalVariables.webDriver.FindElements(By.XPath(CustomerDropdownValesExtuser_Xpath));
                int CustomerNameListCount = CustomerDropdown_List.Count;
                for (int i = 0; i < CustomerNameListCount; i++)
                {
                    if (CustomerDropdown_List[i].Text == Customer)
                    {
                        CustomerDropdown_List[i].Click();
                        break;
                    }
                }

                Report.WriteLine("Click on Quote module");
                Click(attributeName_xpath, ".//*[@id='raterequest']/i");
            }

        }


        [When(@"I arrive on the Quote List page")]
        public void WhenIArriveOnTheQuoteListPage()
        {
            Report.WriteLine("I arrive on the Quote List Page");
            Verifytext(attributeName_xpath, ".//*[@id='page-content-wrapper']//h1", "Quotes");
        }

        [Then(@"The customer selected on the Shipment List page will be pre_selected")]
        public void ThenTheCustomerSelectedOnTheShipmentListPageWillBePre_Selected()
        {
            Report.WriteLine("Selected Customer in Shipment List page that should be auto populated in Quote list customer drop down ");
            string AutopopupCustomerFromQuote = Gettext(attributeName_xpath, ".//*[@id='ExtUserCustomerType_chosen']/a/span");
            string[] Customer_Selected = AutopopupCustomerFromQuote.Split('-');
            string PreviouslySelectedCustomer = Customer_Selected[2];
            string ActualSelectedCustomer = PreviouslySelectedCustomer.TrimStart();
            Assert.AreEqual(passedcustomer, ActualSelectedCustomer);
        }


        [Then(@"The Quote List will display any shipments associated to the customer for the previous Thirty days")]
        public void ThenTheQuoteListWillDisplayAnyShipmentsAssociatedToTheCustomerForThePreviousThirtyDays()
        {

                GetListScreenDetails getListScreenDetails = new GetListScreenDetails();
                IList<CRM.UITest.Helper.ViewModel.Shipment.ShipmentListViewModel> quoteData = getListScreenDetails.GetListScreenDetailsMG(passedcustomer);
                List<String> quoteList = new List<string>();
                if (quoteData != null)
                {
                    for (int j = 1; j < quoteData.Count; j++)
                    {
                        quoteList.Add(quoteData[j].PrimaryReference);
                    }
                }
                else
                {
                    Report.WriteLine("Not received any response from API for selected Customer");
                }

                SelectDropdownlistvalue(attributeName_xpath,".//*[@id='QuotesGrid_length']/label/select/option", "ALL");
                GlobalVariables.webDriver.WaitForPageLoad();
                IList<IWebElement> quoteListUI = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='QuotesGrid']/tbody/tr/td[4]/span"));
            string norecordfound = Gettext(attributeName_xpath, ".//*[@id='QuotesGrid']/tbody/tr/td");
            List <string> actualQuoteList = new List<string>();
                Report.WriteLine("UI values count are: " + quoteListUI);

                if (quoteList.Count >=1 && norecordfound != "No Records Found")
                {
                    for (int k = 0; k < quoteListUI.Count; k++)
                    {
                        string UIShipValues = quoteListUI[k].Text;
                        actualQuoteList.Add(UIShipValues);
                    }
                }
                else
                {
                    Report.WriteLine("No Quotes exists for the selected station");
                    VerifyElementPresent(attributeName_xpath, ".//*[@id='QuotesGrid']/tbody/tr/td", "No Records Found");
                }
                Assert.AreEqual(quoteList.Count, actualQuoteList.Count);
               // CollectionAssert.AreEqual(quoteList.OrderBy(q => q).ToList(), actualQuoteList.OrderBy(q => q).ToList());
                Report.WriteLine("Displaying quote list in the UI is matching with API results");

            }
         }

    }



