using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.Common;
using CRM.UITest.Helper.DataModels;
using CRM.UITest.Helper.Implementations.ShipmentList;
using CRM.UITest.Helper.Implementations.StandardReport;
using CRM.UITest.Objects;
using Microsoft.IdentityModel.Protocols;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Xml.Linq;
using TechTalk.SpecFlow;
using CRM.UITest.Helper.ViewModel.Shipment;
using CRM.UITest.Helper.Interfaces.Shipment;
using CRM.UITest.CsaServiceReference;

namespace CRM.UITest.Scripts.Shipment.ShipmentList_ExternalUsers
{
    [Binding]
    public class AllowCustomerUsersaccesstoSub_Accounts_Shipment_List_GridDisplaySteps : Shipmentlist
    {

        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();

        string AllCustomerAccount = "All Customers";
        string Primary_AccountCustomer = "ZZZ - Czar Customer Test";
        public string Customernamepassed;

        [Given(@"I am a shp\.entry,shp\.inquiry,shp\.entrynorates or shp\.inquirynorates user associated to a primary account that has sub accounts")]
        public void GivenIAmAShp_EntryShp_InquiryShp_EntrynoratesOrShp_InquirynoratesUserAssociatedToAPrimaryAccountThatHasSubAccounts()
        {
            string Username = ConfigurationManager.AppSettings["username-ExtuserCustDropdown"].ToString();
            string Password = ConfigurationManager.AppSettings["password-ExtuserCustDropdown"].ToString();

            CrmLogin.LoginToCRMApplication(Username, Password);
        }

        [Given(@"I am a shp\.entry or shp\.entrynorates user associated to a primary account that has sub accounts")]
        public void GivenIAmAShp_EntryOrShp_EntrynoratesUserAssociatedToAPrimaryAccountThatHasSubAccounts()
        {
            string Username = ConfigurationManager.AppSettings["username-ExtuserCustDropdown"].ToString();
            string Password = ConfigurationManager.AppSettings["password-ExtuserCustDropdown"].ToString();

            CrmLogin.LoginToCRMApplication(Username, Password);
        }


        [When(@"I select All Customers from the customer drop down list on shipment list page")]
        public void WhenISelectAllCustomersFromTheCustomerDropDownListOnShipmentListPage()
        {
            Report.WriteLine("Click on the Shipment icon from the left navigation bar");
            Click(attributeName_xpath, ShipmentIcon_Xpath);

            Report.WriteLine("I selected the All customer option from the drop down");

            Click(attributeName_xpath, CustomerDropdownExtuser_Xpath);
            Report.WriteLine("Selecting" + AllCustomerAccount + "from the Customer dropdown list");

            IList<IWebElement> CustomerDropdown_List = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_CustomerDropdownValues_Xpath));
            int CustomerNameListCount = CustomerDropdown_List.Count;
            for (int i = 0; i < CustomerNameListCount; i++)
            {
                if (CustomerDropdown_List[i].Text == AllCustomerAccount)
                {
                    CustomerDropdown_List[i].Click();
                    break;
                }
            }

        }


        [Given(@"I selected the Primary Account Name from the customer drop down list on shipment list page")]
        public void GivenISelectedThePrimaryAccountNameFromTheCustomerDropDownListOnShipmentListPage()
        {
            Report.WriteLine("Click on the Shipment icon from the left navigation bar");
            Click(attributeName_xpath, ShipmentIcon_Xpath);

            Report.WriteLine("I selected the All customer option from the drop down");

            Click(attributeName_xpath, CustomerDropdownExtuser_Xpath);
            Report.WriteLine("Selecting" + Primary_AccountCustomer + "from the Customer dropdown list");

            IList<IWebElement> CustomerDropdown_List = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_CustomerDropdownValues_Xpath));
            int CustomerNameListCount = CustomerDropdown_List.Count;
            for (int i = 0; i < CustomerNameListCount; i++)
            {
                if (CustomerDropdown_List[i].Text == Primary_AccountCustomer)
                {
                    CustomerDropdown_List[i].Click();
                    break;
                }
            }
        }


        [When(@"I select the Primary Account Name from the customer drop down list")]
        public void WhenISelectThePrimaryAccountNameFromTheCustomerDropDownList()
        {
            Report.WriteLine("Click on the Shipment icon from the left navigation bar");
            Click(attributeName_xpath, ShipmentIcon_Xpath);

            Report.WriteLine("I selected the Primary Account option from the drop down");

            Click(attributeName_xpath, CustomerDropdownExtuser_Xpath);
            Report.WriteLine("Selecting" + Primary_AccountCustomer + "from the Customer dropdown list");

            IList<IWebElement> CustomerDropdown_List = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_CustomerDropdownValues_Xpath));
            int CustomerNameListCount = CustomerDropdown_List.Count;
            for (int i = 0; i < CustomerNameListCount; i++)
            {
                if (CustomerDropdown_List[i].Text == Primary_AccountCustomer)
                {
                    CustomerDropdown_List[i].Click();
                    break;
                }
            }
        }

        [When(@"I select any (.*) Name of (.*) from the customer drop down list on shipment list page")]
        public void WhenISelectAnyNameOfFromTheCustomerDropDownListOnShipmentListPage(string Sub_Account, string TMS_Type)
        {
            Customernamepassed = Sub_Account;
            if (TMS_Type == "MG")
            {
                Report.WriteLine("Click on the Shipment icon from the left navigation bar");
                Click(attributeName_xpath, ShipmentIcon_Xpath);

                Click(attributeName_xpath, CustomerDropdownExtuser_Xpath);
                Report.WriteLine("Selecting" + Sub_Account + "from the Customer dropdown list");

                IList<IWebElement> CustomerDropdown_List = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_CustomerDropdownValues_Xpath));
                int CustomerNameListCount = CustomerDropdown_List.Count;
                for (int i = 0; i < CustomerNameListCount; i++)
                {
                    if (CustomerDropdown_List[i].Text == Sub_Account)
                    {
                        CustomerDropdown_List[i].Click();
                        break;
                    }
                }
            }
            else
            {
                Report.WriteLine("Click on the Shipment icon from the left navigation bar");
                Click(attributeName_xpath, ShipmentIcon_Xpath);

                Report.WriteLine("I selected the Sub Account Customer option from the drop down");

                Click(attributeName_xpath, CustomerDropdownExtuser_Xpath);
                Report.WriteLine("Selecting" + Sub_Account + "from the Customer dropdown list");

                IList<IWebElement> CustomerDropdown_List = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_CustomerDropdownValues_Xpath));
                int CustomerNameListCount = CustomerDropdown_List.Count;
                for (int i = 0; i < CustomerNameListCount; i++)
                {
                    if (CustomerDropdown_List[i].Text == Sub_Account)
                    {
                        CustomerDropdown_List[i].Click();
                        break;
                    }
                }
            }
        }


        [Then(@"The Shipment List grid will refresh to display the shipments associated to the primary account and sub_accounts for the past Thirty days")]
        public void ThenTheShipmentListGridWillRefreshToDisplayTheShipmentsAssociatedToThePrimaryAccountAndSub_AccountsForThePastThirtyDays()
        {

            DefineTimeOut(6000);
            //TotalRecords added for all customer
            List<string> ShipmentList = new List<string>();


            Click(attributeName_xpath, CustomerDropdownExtuser_Xpath);
            IList<IWebElement> CustomerDropdown_List = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_CustomerDropdownValues_Xpath));
            int CustomerNameListCount = CustomerDropdown_List.Count;

            List<string> Customers = new List<string>();

            for (int k = 2; k < CustomerNameListCount; k++)
            {
                Customers.Add(CustomerDropdown_List[k].Text);
            }

            for (int i = 0; i < Customers.Count; i++)
            {

                string TocheckCustomer = Customers[i].ToString();

                int accID = DBHelper.GetAccountIdforAccountName(TocheckCustomer);
                CustomerSetup value = DBHelper.GetSetupDetails(accID);

                // Building request xml
                ListScreenExtractRequestXML data = new ListScreenExtractRequestXML();
                XElement reqXML = data.GetRequestXMLForShipmentListExternalUser(value.MgAccountNumber, "CRM-ShpPrev30DaysAgent", TocheckCustomer);

                //Building Client
                BuildHttpClient client = new BuildHttpClient();
                HttpClient headers = client.BuildHttpClientWithHeaders(TocheckCustomer, "application/xml");


                string uri = $"MercuryGate/ListScreenExtract";
                ShipmentListScreen Slist = new ShipmentListScreen();
                List<Helper.ViewModel.Shipment.ShipmentListViewModel> Sdata = Slist.CallListScreen(uri, headers, reqXML);


                List<string> ShipmentLists = new List<string>();

                ShipmentList.AddRange(ShipmentLists);

                if (Sdata != null)
                {

                    for (int j = 0; j < Sdata.Count; j++)
                    {
                        if (Sdata[j].CustomerName.Contains(TocheckCustomer))
                        {
                            ShipmentList.Add(Sdata[j].ToString());

                        }
                    }
                }
                else
                {
                    Report.WriteLine("No Response from API");
                }
            }


            //Match with the UI
            DefineTimeOut(3000);
            Click(attributeName_xpath, ShipmentList_TopGrid_ViewDropdown_Xpath);
            IList<IWebElement> CustomerDropdown_s = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_TopGrid_ViewDropdownValues_Xpath));
            int CustomerDropdown_ship = CustomerDropdown_s.Count;
            for (int i = 0; i < CustomerDropdown_ship; i++)
            {
                if (CustomerDropdown_s[i].Text == "ALL")
                {
                    CustomerDropdown_s[i].Click();
                    break;
                }
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

        
            
        
            

    [Then(@"The Add Shipment button will be hidden")]
        public void ThenTheAddShipmentButtonWillBeHidden()
        {

            Report.WriteLine("Verify add shipment button will be hidden");
            VerifyElementNotVisible(attributeName_id, ShipmentList_AddShipmentButton_Id, "Add Shipment");

        }

        [Then(@"The Copy Shipment button will be hidden")]
        public void ThenTheCopyShipmentButtonWillBeHidden()
        {
            string NoRecordFound = Gettext(attributeName_xpath, ShipmentList_NoRecords_Xpath);
            int records = GetCount(attributeName_xpath, ShipmentList_NoOf_Rows_Xpath);
            if ((records >= 1) && (NoRecordFound != "No Results Found"))
            {
                Report.WriteLine("Verify Copy shipment button will be hidden");
                VerifyElementNotPresent(attributeName_xpath, ShipmentListGrid_CopyIcon_First_Xpath, "Copy Shipment");
                
            }
            else
            {
                Report.WriteLine("No records found in Shipment list");
            }

        }

        [Then(@"The Create Return Shipment button will be hidden")]
        public void ThenTheCreateReturnShipmentButtonWillBeHidden()
        {
            string NoRecordFound = Gettext(attributeName_xpath, ShipmentList_NoRecords_Xpath);
            int records = GetCount(attributeName_xpath, ShipmentList_NoOf_Rows_Xpath);
            if ((records >= 1) && (NoRecordFound != "No Results Found"))
            {
                Report.WriteLine("Verify Return shipment button will be hidden");
                VerifyElementNotPresent(attributeName_xpath, ShipmentListGrid_RetrunShipmentIcon_First_Xpath, "Return Shipment");
       

            }

            else
            {
                Report.WriteLine("No records found in Shipment list");
            }

        }
      

        [Then(@"The Add Shipment button will be visible")]
        public void ThenTheAddShipmentButtonWillBeVisible()
        {
            WaitForElementVisible(attributeName_id, ShipmentList_AddShipmentButton_Id, "Add Shipment");
            Report.WriteLine("Add shipment Button will be visible");
            VerifyElementVisible(attributeName_id, ShipmentList_AddShipmentButton_Id, "Add Shipment");
        }

        [Then(@"The shipment list will refresh to display the shipments associated to the primary account for the past Thirty days")]
        public void ThenTheShipmentListWillRefreshToDisplayTheShipmentsAssociatedToThePrimaryAccountForThePastThirtyDays()
        {
            int accID = DBHelper.GetAccountIdforAccountName(Primary_AccountCustomer);
            CustomerSetup value = DBHelper.GetSetupDetails(accID);

            // Building request xml
            ListScreenExtractRequestXML data = new ListScreenExtractRequestXML();
            XElement reqXML = data.GetRequestXMLForShipmentListExternalUser(value.MgAccountNumber, "CRM-ShpPrev30DaysAgent", Primary_AccountCustomer);

            //Building Client
            BuildHttpClient client = new BuildHttpClient();
            HttpClient headers = client.BuildHttpClientWithHeaders(Primary_AccountCustomer, "application/xml");


            string uri = $"MercuryGate/ListScreenExtract";
            ShipmentListScreen Slist = new ShipmentListScreen();
            List<Helper.ViewModel.Shipment.ShipmentListViewModel> Sdata = Slist.CallListScreen(uri, headers, reqXML);

            List<String> ShipmentList = new List<string>();

            if (Sdata != null)                                                                                                                      
            {

                for (int j = 0; j < Sdata.Count; j++)
                {
                    if (Sdata[j].CustomerName.Contains(Primary_AccountCustomer)){
                        ShipmentList.Add(Sdata[j].ToString());

                        //string customernamepassed = customername.ToLower();

                        //List<ShipmentListViewModel> Filtershipment = (from ship in shipments
                        //                                              where ship.CustomerName.ToLower() == customernamepassed
                        //                                              select ship).ToList();


                        //return Filtershipment;
                    }
                }
            }
            else
            {
                Report.WriteLine("No Response from API");
            }

            Click(attributeName_xpath, ShipmentList_TopGrid_ViewDropdown_Xpath);
            IList<IWebElement> CustomerDropdown_List = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_TopGrid_ViewDropdownValues_Xpath));
            int CustomerNameListCount = CustomerDropdown_List.Count;
            for (int i = 0; i < CustomerNameListCount; i++)
            {
                if (CustomerDropdown_List[i].Text == "ALL")
                {
                    CustomerDropdown_List[i].Click();
                    break;
                }
            }
            DefineTimeOut(4000);
            IList<IWebElement> UIShipmentVal = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentListGrid_RefNumAllValues_Xpath));
            List<string> UIValue = new List<string>();
            if (ShipmentList.Count > 0)
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
    
        [When(@"I click on the Add Shipment Button")]
        public void WhenIClickOnTheAddShipmentButton()
        {
            Report.WriteLine("I click on the Add shipment Button");
            Click(attributeName_id, ShipmentList_AddShipmentButton_Id);
      
        }

        [Then(@"I will arrive on the Add Shipment tile page")]
        public void ThenIWillArriveOnTheAddShipmentTilePage()
        {
            Report.WriteLine("I arrive on the Add Shipment Tiles page");
            Verifytext(attributeName_xpath, ShipmentList_Title_Xpath, "Add Shipment");
        }

        [Then(@"I will see all of the service type selections that I am associated to")]
        public void ThenIWillSeeAllOfTheServiceTypeSelectionsThatIAmAssociatedTo()
        {
            Report.WriteLine("I am MG type customer and have all services");
            VerifyElementPresent(attributeName_id, ShipmentList_LTLtile_Id, "LTL");
            VerifyElementPresent(attributeName_id, ShipmentList_Truckloadtile_Id, "Truckload");
            VerifyElementPresent(attributeName_id, ShipmentList_PartialTruckloadtile_Id, "Partial Truckload");
            VerifyElementPresent(attributeName_id, ShipmentList_Intermodeltiles_Id, "Intermodal");
                
        }


        [Then(@"The shipment list will refresh to display the shipments associated to the sub account selected for the past Thirty days")]
        public void ThenTheShipmentListWillRefreshToDisplayTheShipmentsAssociatedToTheSubAccountSelectedForThePastThirtyDays()
        {

            int accID = DBHelper.GetAccountIdforAccountName(Customernamepassed);
            CustomerSetup value = DBHelper.GetSetupDetails(accID);

            // Building request xml
            ListScreenExtractRequestXML data = new ListScreenExtractRequestXML();
            XElement reqXML = data.GetRequestXMLForShipmentListExternalUser(value.MgAccountNumber, "CRM-ShpPrev30DaysAgent", Customernamepassed);

            //Building Client
            BuildHttpClient client = new BuildHttpClient();
            HttpClient headers = client.BuildHttpClientWithHeaders(Customernamepassed, "application/xml");


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

            DefineTimeOut(4000);
            Click(attributeName_xpath, ShipmentList_TopGrid_ViewDropdown_Xpath);
            IList<IWebElement> CustomerDropdown_List = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_TopGrid_ViewDropdownValues_Xpath));
            int CustomerNameListCount = CustomerDropdown_List.Count;
            for (int i = 0; i < CustomerNameListCount; i++)
            {
                if (CustomerDropdown_List[i].Text == "ALL")
                {
                    CustomerDropdown_List[i].Click();
                    break;
                }

            }
            DefineTimeOut(4000);
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


        [Then(@"I will see any shipment with the Copy Shipment button and Return shipment button")]
        public void ThenIWillSeeAnyShipmentWithTheCopyShipmentButtonAndReturnShipmentButton()
        {
            Report.WriteLine("Any shipment displayed with the LTL service type ");
            
            string NoRecordFound = Gettext(attributeName_xpath, ShipmentList_NoRecords_Xpath);
            int records = GetCount(attributeName_xpath, ShipmentList_NoOf_Rows_Xpath);
            if ((records >= 1) && (NoRecordFound != "No Results Found"))
            {
                WaitForElementVisible(attributeName_xpath, ".//*[@id='ShipmentGrid']//tr[1]/td[8]/a[2]", "Copy Shipment");
                IList<IWebElement> Shipment_Service = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentListGrid_ServiceNameEU_Xpath));
                int ShipmentService_All = Shipment_Service.Count;
                for (int i = 0; i < ShipmentService_All; i++)
                {
                    int j = i + 1;
                    Report.WriteLine("Shipment is displayed for LTL Service type and verified Copy and Return Shipment");
                    VerifyElementPresent(attributeName_xpath, ".//*[@id='ShipmentGrid']//tr[" + j + "]/td[8]/a[2]", "Copy Shipment");
                    VerifyElementPresent(attributeName_xpath, ".//*[@id='ShipmentGrid']//tr[" + j + "]/td[8]/a[3]/span", "Return Shipment");

                }
            }
            else
            {
                Report.WriteLine("No Shipment found");
            }

        }

    }
}

