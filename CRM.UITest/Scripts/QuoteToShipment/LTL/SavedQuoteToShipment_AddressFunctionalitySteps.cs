using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.Common;
using CRM.UITest.Helper.Implementations.ShipmentExtract;
using CRM.UITest.Helper.ViewModel;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;

namespace CRM.UITest.Scripts.QuoteToShipment.LTL
{
    [Binding]
    public class SavedQuoteToShipment_AddressFunctionalitySteps : AddShipments
    {
        ShipmentExtractViewModel shipmentViewModels = null;
        
        [Given(@"I am in the Quote Details Section of the non expired LTL quote (.*),(.*)")]
        public ShipmentExtractViewModel GivenIAmInTheQuoteDetailsSectionOfTheNonExpiredLTLQuote(string Account, string UserType)
        {
            Report.WriteLine("I am on the Quote Details Section");
            WaitForElementVisible(attributeName_xpath, ".//*[@id='raterequest']/i","icon");
         
            Click(attributeName_xpath, ".//*[@id='raterequest']/i");
            

            int Quotelist = 0;
            Report.WriteLine("Clicking on Create Shipment from Quote Details Section");

            if (UserType == "Internal")
            {
                Click(attributeName_xpath, ".//*[@id='CategoryType_chosen']/a/span");

                IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='CategoryType_chosen']/div/ul/li"));
                int DropDownCount = DropDownList.Count;
                for (int i = 0; i < DropDownCount; i++)
                {
                    if (DropDownList[i].Text == Account)
                    {
                        DropDownList[i].Click();
                        break;
                    }
                }

                Thread.Sleep(500);
                SendKeys(attributeName_id, ShipmentListSearchBox_Id, "LTL");
                Click(attributeName_xpath, ".//*[@id='QuotesGrid_wrapper']/div[1]/div[3]/label[2]/label");

                Quotelist = GetCount(attributeName_xpath, ".//*[@id='QuotesGrid']/tbody/tr");
                if (Quotelist > 1)
                {

                    string RequestNumber = Gettext(attributeName_xpath, ".//*[@id='QuotesGrid']/tbody/tr[1]/td[4]/span");
                    Report.WriteLine("Expand the Quote frm Quote List");
                    Click(attributeName_xpath, ".//*[@id='QuotesGrid']/tbody/tr[1]//*[@class='btn exandableTrigger image-only-sm']");

                    WaitForElementVisible(attributeName_id, "btn-CreateShipment", "Create Shipment");
                    VerifyElementPresent(attributeName_id, "btn-CreateShipment", "Create Shipment");
                    Thread.Sleep(5000);

                    string uri = $"MercuryGate/OidLookup";

                    //Building Client
                    BuildHttpClient client = new BuildHttpClient();
                    HttpClient headers = client.BuildHttpClientWithHeaders("Admin", "application/xml");

                    ShipmentExtract ext = new ShipmentExtract();
                    shipmentViewModels = ext.getShipmentData(uri, headers, RequestNumber, "Admin");
                }
                else
                {
                    Report.WriteLine("No records");
                }
            }
            else
            {
                SendKeys(attributeName_id, ShipmentListSearchBox_Id, "LTL");
                Click(attributeName_xpath, ".//*[@id='QuotesGrid_wrapper']/div[1]/div[3]/label[2]/label");

                Quotelist = GetCount(attributeName_xpath, ".//*[@id='QuotesGrid']/tbody/tr");
                if (Quotelist > 1)
                {
                    string RequestNumber = Gettext(attributeName_xpath, ".//*[@id='QuotesGrid']/tbody/tr[1]/td[3]");
                    Report.WriteLine("Expand the Quote frm Quote List");
                    Click(attributeName_xpath, ".//*[@id='QuotesGrid']/tbody/tr[1]//*[@class='btn exandableTrigger image-only-sm']");


                    WaitForElementVisible(attributeName_id, "btn-CreateShipment", "Create Shipment");
                    VerifyElementPresent(attributeName_id, "btn-CreateShipment", "Create Shipment");
                    Thread.Sleep(5000);
                    string uri = $"MercuryGate/OidLookup";
                    //Building Client
                    BuildHttpClient client = new BuildHttpClient();
                    HttpClient headers = client.BuildHttpClientWithHeaders(Account, "application/xml");

                    ShipmentExtract ext = new ShipmentExtract();
                    shipmentViewModels = ext.getShipmentData(uri, headers, RequestNumber, Account);
                }
                else
                {
                    Report.WriteLine("No Records");
                }
            }
            return shipmentViewModels;
        }
        [Given(@"I am in the Quote Section of the non expired LTL quote (.*),(.*)")]
        public void GivenIAmInTheQuoteSectionOfTheNonExpiredLTLQuote(string Account, string UserType)
        {
            Report.WriteLine("I am on the Quote Details Section");
            ;
            Click(attributeName_xpath, "raterequest");
          
            int Quotelist = 0;
            Report.WriteLine("Clicking on Create Shipment from Quote Details Section");

            if (UserType == "Internal")
            {
                Click(attributeName_xpath, ".//*[@id='CategoryType_chosen']/a/span");

                IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='CategoryType_chosen']/div/ul/li"));
                int DropDownCount = DropDownList.Count;
                for (int i = 0; i < DropDownCount; i++)
                {
                    if (DropDownList[i].Text == Account)
                    {
                        DropDownList[i].Click();
                        break;
                    }
                }

             
                SendKeys(attributeName_id, ShipmentListSearchBox_Id, "Quoted");                
                Quotelist = GetCount(attributeName_xpath, ".//*[@id='QuotesGrid']/tbody/tr");
                if (Quotelist > 1)
                {                 
                       Click(attributeName_xpath, ".//*[@id='QuotesGrid']/tbody/tr[1]//*[@class='btn exandableTrigger image-only-sm']");
                                         
                }
                else
                {
                    Report.WriteLine("No records");
                }
            }
            else
            {
                
                SendKeys(attributeName_id, ShipmentListSearchBox_Id, "Quoted");                
                Quotelist = GetCount(attributeName_xpath, ".//*[@id='QuotesGrid']/tbody/tr");
                if (Quotelist > 1)
                {
                   
                    Click(attributeName_xpath, ".//*[@id='QuotesGrid']/tbody/tr[1]//*[@class='btn exandableTrigger image-only-sm']");
                   
                    WaitForElementVisible(attributeName_id, QuoteCreateShipment_Id,"CreateShipment");
                                     
                }
                else
                {
                    Report.WriteLine("No records");
                }
            }
           
        }

        [Given(@"I click on the Create Shipment button")]
        public void GivenIClickOnTheCreateShipmentButton()
        {
            Report.WriteLine("Click on Create Shipment");
                     
            WaitForElementVisible(attributeName_id, QuoteCreateShipment_Id, "Create SHipment");
            Click(attributeName_id, QuoteCreateShipment_Id);                
            
                       
        }
        [When(@"I click on the Create Shipment button")]
        public void WhenIClickOnTheCreateShipmentButton()
        {
            Report.WriteLine("Click on Create Shipment");
            
            WaitForElementVisible(attributeName_id, QuoteCreateShipment_Id, "Create SHipment");
            Click(attributeName_id, QuoteCreateShipment_Id);
             
            
        }
        [When(@"I arrive on the Add Shipment LTL page")]
        public void WhenIArriveOnTheAddShipmentLTLPage()
        {
            Report.WriteLine("Add Shipment page");
            
                WaitForElementVisible(attributeName_xpath, CopyAddShipmentTitle_Xpath, "Add Shipment (LTL)");
                Verifytext(attributeName_xpath, CopyAddShipmentTitle_Xpath, "Add Shipment (LTL)");
          
        }

        [Then(@"I should be able to select saved from the Shipping From drop down for the matching zip code of the saved quote (.*)")]
        public void ThenIShouldBeAbleToSelectSavedFromTheShippingFromDropDownForTheMatchingZipCodeOfTheSavedQuote(string Account)
        {
            Report.WriteLine("Checking with the DB");

            if (shipmentViewModels.AddressViewModels != null)
            {
                for (var i = 0; i < shipmentViewModels.AddressViewModels.Count; i++)
                {
                    if (shipmentViewModels.AddressViewModels[i].Type.ToLower() == "origin")
                    {
                        Click(attributeName_xpath, ".//*[@id='txt_OrginAddress_ltlShipment']");
                        int GetUIAddreesCount = GetCount(attributeName_xpath, ".//*[@id='scrollable-dropdown-menu-Origin']/div/span[1]/span/div/span/div/p");
                        Thread.Sleep(3000);

                        string OriginZip = shipmentViewModels.AddressViewModels[i].PostalCode;

                        int CustomerSetupId = DBHelper.GetCustomerSetupId(Account);
                        int CustomerAccountId = DBHelper.GetCustomerAccountId(CustomerSetupId);
                        List<Address> records = DBHelper.GetAddress(CustomerAccountId, OriginZip);
                        int FromDBCount = records.Count();
                        if (GetUIAddreesCount == FromDBCount)
                        {
                            Report.WriteLine("Records are matched");
                        }
                        else
                        {
                            Report.WriteLine("Not Matched with UI");
                        }
                    }
                }
            }
        }
      
        [Then(@"Verify the search functionality for the Shipping From ZipCode (.*)")]
        public void ThenVerifyTheSearchFunctionalityForTheShippingFromZipCode(string Account)
        {
            Thread.Sleep(10000);
            Report.WriteLine("Checking with the DB for Shipping To ");
            if (shipmentViewModels.AddressViewModels != null)
            {
                for (var i = 0; i < shipmentViewModels.AddressViewModels.Count; i++)
                {
                    if (shipmentViewModels.AddressViewModels[i].Type.ToLower() == "origin")
                    {
                        string OriginZip = shipmentViewModels.AddressViewModels[i].PostalCode;
                        int CustomerSetupId = DBHelper.GetCustomerSetupId(Account);
                        int CustomerAccountId = DBHelper.GetCustomerAccountId(CustomerSetupId);
                        List<Address> records = DBHelper.GetAddress(CustomerAccountId, OriginZip);
                        int FromDBCount = records.Count();
                        string FromDBNameSearch = records[0].Name;
                        SendKeys(attributeName_xpath, ".//*[@id='txt_OrginAddress_ltlShipment']", FromDBNameSearch);
                        IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='scrollable-dropdown-menu-Origin']/div/span[1]/span/div/span/div/p"));
                        int DropDownCount = DropDownList.Count;
                        for (int j = 0; j < DropDownCount; j++)
                        {
                            if (DropDownList[j].Text.Contains(FromDBNameSearch))
                            {
                                Report.WriteLine("search functionality is working");
                                break;
                            }
                        }
                    }
                }
            }
        }

        [When(@"I select saved address from the Shipping From for the matching zip code of the saved quote")]
        public void WhenISelectSavedAddressFromTheShippingFromForTheMatchingZipCodeOfTheSavedQuote()
        {
            if (shipmentViewModels.AddressViewModels != null)
            {
                for (var i = 0; i < shipmentViewModels.AddressViewModels.Count; i++)
                {
                    if (shipmentViewModels.AddressViewModels[i].Type.ToLower() == "origin")
                    {
                        string OriginZip = shipmentViewModels.AddressViewModels[i].PostalCode;
                        string OriginZipFromUI = GetValue(attributeName_xpath, ".//*[@id='origin-zip']", "value");
                        Assert.AreEqual(OriginZipFromUI, OriginZip);
                    }
                }
            }
            Report.WriteLine("When i select from saved address from dropdown");
            Click(attributeName_xpath, ".//*[@id='txt_OrginAddress_ltlShipment']");
            int GetUIAddreesCount = GetCount(attributeName_xpath, ".//*[@id='scrollable-dropdown-menu-Origin']/div/span[1]/span/div/span/div/p");
            if (GetUIAddreesCount > 1)
            {
                Click(attributeName_xpath, ".//*[@id='scrollable-dropdown-menu-Origin']/div/span[1]/span/div/span/div[1]/p");
                Thread.Sleep(3000);
            }
            else
            {
                Click(attributeName_xpath, ".//*[@id='scrollable-dropdown-menu-Origin']/div/span[1]/span/div/span/div/p");
            }
        }

        [Then(@"the data LocationName, LocationAddress,LocationAddress(.*) will be populated in the Shipping From section with the saved address and fields will be editable")]
        public void ThenTheDataLocationNameLocationAddressLocationAddressWillBePopulatedInTheShippingFromSectionWithTheSavedAddressAndFieldsWillBeEditable(int p0)
        {
            Report.WriteLine("Fields will be autopopulated");
            string OriginName = GetValue(attributeName_xpath, ".//*[@id='txtOrginName']", "value");
            string Address1 = GetValue(attributeName_xpath, ".//*[@id='txtOrginAddr1']", "value");
            string Address2 = GetValue(attributeName_xpath, ".//*[@id='txtOrginAddr2']", "value");
            Report.WriteLine("OriginName is in field" + OriginName);
            Report.WriteLine("Address1 is in field" + Address1);
            Report.WriteLine("Address 2 is in field" + Address2);
            Report.WriteLine("Fields Can be editable");
            Clear(attributeName_xpath, ".//*[@id='txtOrginName']");
            SendKeys(attributeName_id, ShipmentListSearchBox_Id, "Edited Origin Name");
            Clear(attributeName_xpath, ".//*[@id='txtOrginAddr1']");
            SendKeys(attributeName_id, ShipmentListSearchBox_Id, "Edited Origin Address1");
            Clear(attributeName_xpath, ".//*[@id='txtOrginAddr2']");
            SendKeys(attributeName_id, ShipmentListSearchBox_Id, "Edited Origin Address2");
        }

        [Then(@"I should be able to select saved from the Shipping To drop down for the matching zip code of the saved quote (.*)")]
        public void ThenIShouldBeAbleToSelectSavedFromTheShippingToDropDownForTheMatchingZipCodeOfTheSavedQuote(string Account)
        {
            Report.WriteLine("Checking with the DB for Shipping To ");
            if (shipmentViewModels.AddressViewModels != null)
            {
                for (var i = 0; i < shipmentViewModels.AddressViewModels.Count; i++)
                {
                    if (shipmentViewModels.AddressViewModels[i].Type.ToLower() == "destination")
                    {
                        Click(attributeName_xpath, ".//*[@id='txt_DestinationAddress_ltlShipment']");
                        int GetUIAddreesCount = GetCount(attributeName_xpath, ".//*[@id='scrollable-dropdown-menu-Destination']/div/span[1]/span/div/span/div/p");
                        string DestinationZip = shipmentViewModels.AddressViewModels[i].PostalCode;
                        int CustomerSetupId = DBHelper.GetCustomerSetupId(Account);
                        int CustomerAccountId = DBHelper.GetCustomerAccountId(CustomerSetupId);
                        List<Address> records = DBHelper.GetAddress(CustomerAccountId, DestinationZip);
                        int FromDBCount = records.Count();
                        if (GetUIAddreesCount == FromDBCount)
                        {
                            Report.WriteLine("Records are matched");
                        }
                        else
                        {
                            Report.WriteLine("Not Matched with UI");
                        }
                    }
                }
            }
        }

        [Then(@"Verify the search functionality for the Shipping To ZipCode (.*)")]
        public void ThenVerifyTheSearchFunctionalityForTheShippingToZipCode(string Account)
        {
            Thread.Sleep(10000);
            Report.WriteLine("Checking with the DB for Shipping To ");
            if (shipmentViewModels.AddressViewModels != null)
            {
                for (var i = 0; i < shipmentViewModels.AddressViewModels.Count; i++)
                {
                    if (shipmentViewModels.AddressViewModels[i].Type.ToLower() == "destination")
                    {                      
                        string DestinationZip = shipmentViewModels.AddressViewModels[i].PostalCode;                    
            
                        int CustomerSetupId = DBHelper.GetCustomerSetupId(Account);
                        int CustomerAccountId = DBHelper.GetCustomerAccountId(CustomerSetupId);
                        List<Address> records = DBHelper.GetAddress(CustomerAccountId, DestinationZip);
                        int FromDBCount = records.Count();
                        string FromDBNameSearch = records[0].Name;                       
                        SendKeys(attributeName_xpath, ".//*[@id='txt_DestinationAddress_ltlShipment']", FromDBNameSearch);                        
                        IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='scrollable-dropdown-menu-Destination']/div/span[1]/span/div/span/div/p"));
                        int DropDownCount = DropDownList.Count;
                        for (int j = 0; j < DropDownCount; j++)
                        {
                            if (DropDownList[j].Text.Contains(FromDBNameSearch))
                            {
                                Report.WriteLine("search functionality is working");
                                break;
                            }
                        }
                    }
                }
            }
        }

        [When(@"I select saved address from the Shipping To for the matching zip code of the saved quote")]
        public void WhenISelectSavedAddressFromTheShippingToForTheMatchingZipCodeOfTheSavedQuote()
        {
            if (shipmentViewModels.AddressViewModels != null)
            {
                for (var i = 0; i < shipmentViewModels.AddressViewModels.Count; i++)
                {
                    if (shipmentViewModels.AddressViewModels[i].Type.ToLower() == "destination")
                    {
                        string DestinationZip = shipmentViewModels.AddressViewModels[i].PostalCode;

                        string DestinationZipFromUI = GetValue(attributeName_xpath, ".//*[@id='destination-zip']", "value");
                        Assert.AreEqual(DestinationZipFromUI, DestinationZip);
                    }
                }
            }
            Report.WriteLine("When i select from saved address from dropdown");
            Click(attributeName_xpath, ".//*[@id='txt_DestinationAddress_ltlShipment']");
            int GetUIAddreesCount = GetCount(attributeName_xpath, ".//*[@id='scrollable-dropdown-menu-Destination']/div/span[1]/span/div/span/div/p");
            if (GetUIAddreesCount > 1)
            {
                Click(attributeName_xpath, ".//*[@id='scrollable-dropdown-menu-Destination']/div/span[1]/span/div/span/div[1]/p");
                Thread.Sleep(3000);
            }
            else
            {
                Click(attributeName_xpath, ".//*[@id='scrollable-dropdown-menu-Destination']/div/span[1]/span/div/span/div/p");
            }
        }

        [Then(@"the data LocationName, LocationAddress,LocationAddress(.*) will be populated in the Shipping To section with the saved address and fields will be editable")]
        public void ThenTheDataLocationNameLocationAddressLocationAddressWillBePopulatedInTheShippingToSectionWithTheSavedAddressAndFieldsWillBeEditable(int p0)
        {
            Report.WriteLine("Fields will be autopopulated");
            string OriginName = GetValue(attributeName_xpath, ".//*[@id='txtDestName']", "value");
            string Address1 = GetValue(attributeName_xpath, ".//*[@id='txtDestAddr1']", "value");
            string Address2 = GetValue(attributeName_xpath, ".//*[@id='txtDestAddr2']", "value");
            Report.WriteLine("OriginName is in field" + OriginName);
            Report.WriteLine("Address1 is in field" + Address1);
            Report.WriteLine("Address 2 is in field" + Address2);
            Report.WriteLine("Fields Can be editable");
            Clear(attributeName_xpath, ".//*[@id='txtOrginName']");
            SendKeys(attributeName_xpath, ".//*[@id='txtDestName']", "Edited Des Name");
            Clear(attributeName_xpath, ".//*[@id='txtOrginAddr1']");
            SendKeys(attributeName_xpath, ".//*[@id='txtDestAddr1']", "Edited  Des Address1");
            Clear(attributeName_xpath, ".//*[@id='txtOrginAddr2']");
            SendKeys(attributeName_xpath, ".//*[@id='txtDestAddr2']", "Edited Des Address2");
        }
    }
}
