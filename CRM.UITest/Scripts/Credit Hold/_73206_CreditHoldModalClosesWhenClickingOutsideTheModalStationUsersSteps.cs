using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Helper.Common;
using CRM.UITest.Helper.Implementations.QuoteList;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Xml.Linq;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Credit_Hold
{
    [Binding, Scope(Tag = "73206")]
    public class _73206_CreditHoldModalClosesWhenClickingOutsideTheModalStationUsersSteps: ObjectRepository
    {
        Quotelist quotelistobjects = new Quotelist();
        Shipmentlist shipmentlistobjects = new Shipmentlist();
        string quoteNumber = string.Empty;
        string pickUpDate = string.Empty;
        string customerName = "swathi_CreditHoldVerfication";

        [Given(@"I am on the Quote list page")]
        public void GivenIAmOnTheQuoteListPage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, quotelistobjects.QuoteIconModule_Xpath);
            WaitForElementVisible(attributeName_xpath, quotelistobjects.QuoteList_HeaderText_xpath, "Quote List");
            Report.WriteLine("I am on the Quote list page");
        }

        [Given(@"I click on Submit Rate Request button for the Credit Hold Customer")]
        public void GivenIClickOnSubmitRateRequestButtonForTheCreditHoldCustomer()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, quotelistobjects.QuoteList_CustomerDropdown_Label_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_xpath, quotelistobjects.QuoteList_CustomerDrpdown_Search_Xpath, customerName);
            Click(attributeName_xpath, quotelistobjects.QuoteList_CustomerDrpdown_SearchedValue_Xpath);                        
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, quotelistobjects.SubmitRateRequestBtn_id);            
            Report.WriteLine("Clicked on Submit Rate Request button on Quote List page");
        }
        
        [Given(@"I click on Add Shipment button for the Credit Hold Customer")]
        public void GivenIClickOnAddShipmentButtonForTheCreditHoldCustomer()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, shipmentlistobjects.ShipmentList_Customer_dropdown_Xpath);
            SendKeys(attributeName_xpath, shipmentlistobjects.ShpList_CustomerDrpdown_Search_Xpath, customerName);
            Click(attributeName_xpath, shipmentlistobjects.ShpList_CustomerDrpdown_SearchedValue_Xpath);            
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, shipmentlistobjects.ShipmentList_AddShipmentButtonInternalUser_Id);            
            Report.WriteLine("Clicked on Add Shipment button on Shipment List page");
        }
        
        [Given(@"I click on Copy Shipment button for the Credit Hold Customer")]
        public void GivenIClickOnCopyShipmentButtonForTheCreditHoldCustomer()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, shipmentlistobjects.ShipmentList_Customer_dropdown_Xpath);
            SendKeys(attributeName_xpath, shipmentlistobjects.ShpList_CustomerDrpdown_Search_Xpath, customerName);
            Click(attributeName_xpath, shipmentlistobjects.ShpList_CustomerDrpdown_SearchedValue_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, shipmentlistobjects.ShipmentList_CopyShipIcon_Xpath);            
            Report.WriteLine("Clicked on Copy Shipment button on Shipment List page");
        }
        
        [Given(@"I click on Return Shipment button for the Credit Hold Customer")]
        public void GivenIClickOnReturnShipmentButtonForTheCreditHoldCustomer()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, shipmentlistobjects.ShipmentList_Customer_dropdown_Xpath);
            SendKeys(attributeName_xpath, shipmentlistobjects.ShpList_CustomerDrpdown_Search_Xpath, customerName);
            Click(attributeName_xpath, shipmentlistobjects.ShpList_CustomerDrpdown_SearchedValue_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, shipmentlistobjects.ShipmentList_ReturnShipIcon_Xpath);            
            Report.WriteLine("Clicked on Return Shipment button on Shipment List page");
        }
        
        [Given(@"I click on Re-Quote button for the Credit Hold Customer")]
        public void GivenIClickOnRe_QuoteButtonForTheCreditHoldCustomer()
        {
            pickUpDate = DateTime.UtcNow.AddDays(-1).ToString("MM/dd/yyyy HH:mm");
            //Generate Random quote Number
            Random rnd = new Random();
            int myRandomNo = rnd.Next(10000000, 99999999);
            quoteNumber = "QTWB" + myRandomNo.ToString();

            //Create a Quote using API
            CreateLTLQuote createQuote = new CreateLTLQuote();
            XElement requestxml = createQuote.CreateQuoteXml(quoteNumber, pickUpDate, customerName);
            BuildHttpClient client = new BuildHttpClient();
            HttpClient buildClient = client.BuildHttpClientWithHeaders(customerName, "application/xml");
            HttpResponseMessage responseMessage = buildClient.PostAsXmlAsync<XElement>("MercuryGate/ShipmentImport", requestxml).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                XElement responseXml = responseMessage.Content.ReadAsAsync<XElement>().Result;
                refreshBrowser();
                GlobalVariables.webDriver.WaitForPageLoad();
                Click(attributeName_xpath, quotelistobjects.QuoteList_CustomerDropdown_Label_Xpath);
                GlobalVariables.webDriver.WaitForPageLoad();
                SendKeys(attributeName_xpath, quotelistobjects.QuoteList_CustomerDrpdown_Search_Xpath, customerName);
                Click(attributeName_xpath, quotelistobjects.QuoteList_CustomerDrpdown_SearchedValue_Xpath);
                GlobalVariables.webDriver.WaitForPageLoad();
                Report.WriteLine("Quote is created");
                SendKeys(attributeName_id, quotelistobjects.QuoteList_Search_Box_Id, quoteNumber);
                GlobalVariables.webDriver.WaitForPageLoad();
                Click(attributeName_xpath, quotelistobjects.QuoteList_TopGrid_expandquote_Xpath);
                GlobalVariables.webDriver.WaitForPageLoad();
                Report.WriteLine("LTL quote is expanded");
            }
            else
            {
                Assert.Fail();
                Report.WriteLine("Successcode is not true and not created Quote via API");
            }                        
            Click(attributeName_id, quotelistobjects.QuoteDetails_RequoteButton_id);            
            Report.WriteLine("Clicked on Re-Quote button of any expired quote on Quote List page");
        }
        
        [Given(@"I click on the Create Shipment button for the Credit Hold Customer")]
        public void GivenIClickOnTheCreateShipmentButtonForTheCreditHoldCustomer()
        {
            pickUpDate = DateTime.UtcNow.AddDays(0).ToString("MM/dd/yyyy HH:mm");

            //Generate Random quote Number
            Random rnd = new Random();
            int myRandomNo = rnd.Next(10000000, 99999999);
            quoteNumber = "QTWB" + myRandomNo.ToString();

            //Create a Quote using API
            CreateLTLQuote createQuote = new CreateLTLQuote();
            XElement requestxml = createQuote.CreateQuoteXml(quoteNumber, pickUpDate, customerName);
            BuildHttpClient client = new BuildHttpClient();
            HttpClient buildClient = client.BuildHttpClientWithHeaders(customerName, "application/xml");
            HttpResponseMessage responseMessage = buildClient.PostAsXmlAsync<XElement>("MercuryGate/ShipmentImport", requestxml).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                XElement responseXml = responseMessage.Content.ReadAsAsync<XElement>().Result;
                refreshBrowser();
                GlobalVariables.webDriver.WaitForPageLoad();
                Click(attributeName_xpath, quotelistobjects.QuoteList_CustomerDropdown_Label_Xpath);
                GlobalVariables.webDriver.WaitForPageLoad();
                SendKeys(attributeName_xpath, quotelistobjects.QuoteList_CustomerDrpdown_Search_Xpath, customerName);
                Click(attributeName_xpath, quotelistobjects.QuoteList_CustomerDrpdown_SearchedValue_Xpath);
                GlobalVariables.webDriver.WaitForPageLoad();
                Report.WriteLine("Quote is created");
                SendKeys(attributeName_id, quotelistobjects.QuoteList_Search_Box_Id, quoteNumber);
                GlobalVariables.webDriver.WaitForPageLoad();
                Click(attributeName_xpath, quotelistobjects.QuoteList_TopGrid_expandquote_Xpath);
                GlobalVariables.webDriver.WaitForPageLoad();
                Report.WriteLine("LTL quote is expanded");
            }
            else
            {
                Assert.Fail();
                Report.WriteLine("Successcode is not true and not created Quote via API");
            }                                   
            Click(attributeName_id, quotelistobjects.QuoteDetails_CreateShipButton_Id);            
            Report.WriteLine("Clicked on Create Shipment button of a saved quote on Quote List page");
        }
        
        [When(@"I click out side the Credit Hold modal pop up")]
        public void WhenIClickOutSideTheCreditHoldModalPopUp()
        {
            Thread.Sleep(2000);
            Click(attributeName_xpath, CreditHoldOverlay_Xpath);
            Report.WriteLine("Clicked outside the Credit Hold pop up");
        }

        [When(@"I click out side the Credit Hold modal pop up on Dashboard")]
        public void WhenIClickOutSideTheCreditHoldModalPopUpOnDashboard()
        {
            Click(attributeName_xpath, CreditHoldModalOverlay_Dashboard_xpath);
            Report.WriteLine("Clicked outside the Credit Hold pop up");
        }

        [Then(@"Credit Hold modal pop up should not close")]
        public void ThenCreditHoldModalPopUpShouldNotClose()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            bool modal = IsElementPresent(attributeName_xpath, CreditHold_ModalTitle_Xpath, "Credit Hold");
                       
            if (modal)
            {                   
                Report.WriteLine("Credit Hold pop up displays");
            }
            else
            {                
                Report.WriteFailure("Credit Hold pop up Closed");
            }
        }

        [Then(@"Credit Hold modal pop up should not close on Dashboard")]
        public void ThenCreditHoldModalPopUpShouldNotCloseOnDashboard()
        {            
            bool modal = IsElementPresent(attributeName_xpath, CreditHoldModalTitle_Dashboard_Xpath, "Credit Hold");

            if (modal)
            {
                Report.WriteLine("Credit Hold pop up displays");
            }
            else
            {
                Report.WriteFailure("Credit Hold pop up Closed");
            }
        }


    }
}
