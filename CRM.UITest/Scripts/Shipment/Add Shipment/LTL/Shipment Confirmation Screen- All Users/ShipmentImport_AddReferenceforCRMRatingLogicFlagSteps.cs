using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading;
using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Helper.Common;
using CRM.UITest.Helper.DataModels;
using CRM.UITest.Helper.Implementations.ShipmentExtract;
using CRM.UITest.Helper.ViewModel;
using CRM.UITest.Objects;
using CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Add_Shipment___3rd_PartyAPI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Confirmation_Screen__All_Users
{
    [Binding]
    public class ShipmentImport_AddReferenceforCRMRatingLogicFlagSteps : AddShipments
    {
        CommonMethodsCrm crm = new CommonMethodsCrm();
        AddShipmentLTL ltl = new AddShipmentLTL();
        AddAShipment_CountryCodeFormattingSteps getShipDetails = new AddAShipment_CountryCodeFormattingSteps();
        ShipmentExtractViewModel shipmentViewModels = null;

        [Given(@"I am a shp\.entry, shp\.entrynorates, sales, sales management, operations, or station owner user(.*)")]
        public void GivenIAmAShp_EntryShp_EntrynoratesSalesSalesManagementOperationsOrStationOwnerUser(string usertype)
        {
            string username = string.Empty;
            string password = string.Empty;
            if (usertype == "Internal")
            {
                username = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
                password = ConfigurationManager.AppSettings["password-crmOperation"].ToString();
            }
            else if (usertype == "Sales")
            {
                usertype = "Internal";
                username = ConfigurationManager.AppSettings["username-salesdelta"].ToString();
                password = ConfigurationManager.AppSettings["password-salesdelta"].ToString();
            }
            else if (usertype == "External")
            {
                username = ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();
                password = ConfigurationManager.AppSettings["ExternalUserPassword"].ToString();
            }
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"I am creating an LTL shipment in CRM(.*), (.*), (.*),(.*), (.*), (.*),(.*),(.*),(.*), (.*),(.*), (.*), (.*),(.*), (.*), (.*), (.*)")]
        public void GivenIAmCreatingAnLTLShipmentInCRM(string Usertype,
            string oAdd2,
            string oZip,
            string oName,
            string oAdd1,
            string dAdd2,
            string dName,
            string dAdd1,
            string Customer_Name,
            string oComments,
            string dComments,
            string dZip,
            string classification,
            string nmfc,
            string quantity,
            string weight,
            string desc)
        {
            ltl.NaviagteToShipmentList();
            GlobalVariables.webDriver.WaitForPageLoad();
            ltl.SelectCustomerFromShipmentList(Usertype, Customer_Name);
            Click(attributeName_id, ShippingFrom_ClearAddress_Id);
            Click(attributeName_id, ShippingTo_ClearAddress_Id);
            ltl.AddShipmentOriginData(oName, oAdd1, oZip);
            ltl.AddShipmentDestinationData(dName, dAdd1, dZip);
            scrollElementIntoView(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            Click(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            ltl.AddShipmentFreightDescription(classification, nmfc, quantity, weight, desc);
            Click(attributeName_xpath, ViewRatesButton_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            ltl.ClickOnCreateShipmentButton(Usertype);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"the customer account associated to the shipment has CRM rating logic turned on(.*)")]
        public void GivenTheCustomerAccountAssociatedToTheShipmentHasCRMRatingLogicTurnedOn(string Customer_Name)
        {
            bool iSCrmRatingLogic_GainshareCustomer = DBHelper.CheckNewCrmRatingLogic(Customer_Name);
            if (iSCrmRatingLogic_GainshareCustomer)
            {
                Report.WriteLine("CRM Rating logic is Enabled for the Customer");
            }
            else
            {
                Report.WriteLine("Customer is not belongs to CRM Rating Logic");
            }
        }

        [When(@"I click submit shipment from the Review and Submit Shipment \(LTL\) page")]
        public void WhenIClickSubmitShipmentFromTheReviewAndSubmitShipmentLTLPage()
        {
            ltl.ReviewAndSubmit_ClickOnSubmitShipmentButton();
        }

        [Then(@"the shipment will be created in Mercurygate with a reference type of ""(.*)""")]
        public void ThenTheShipmentWillBeCreatedInMercurygateWithAReferenceTypeOf(string crmrl)
        {
            string referenceNumber = Gettext(attributeName_id, ShipmentConfirmationNumber_Id);
            string uri = $"MercuryGate/OidLookup";

            BuildHttpClient client = new BuildHttpClient();
            HttpClient headers = client.BuildHttpClientWithHeaders("Admin", "application/xml");

            ShipmentExtract ext = new ShipmentExtract();
            shipmentViewModels = ext.getShipmentData(uri, headers, referenceNumber, "Admin");
            int i = shipmentViewModels.ReferenceNumbers.Count;
            int q = 1;
            foreach (ShipmentImportReferenceModel a in shipmentViewModels.ReferenceNumbers)
            {
                if (a.Type == "CRMRL")
                {
                    Report.WriteLine("Reference type CRMRL is updated to this Shipment");
                    break;
                }
                else if (a.Type != crmrl && q == i)
                {
                    Assert.Fail();
                }
                q++;
            }
        }

        [Then(@"the reference value will be ""(.*)""")]
        public void ThenTheReferenceValueWillBe(string p0)
        {
            int i = shipmentViewModels.ReferenceNumbers.Count;
            int q = 1;
            foreach (ShipmentImportReferenceModel a in shipmentViewModels.ReferenceNumbers)
            {
                if (a.Type == "CRMRL")
                {
                    Assert.IsTrue(Convert.ToBoolean(a.ReferenceNumber));
                    break;
                }
                else if (a.Type != "CRMRL" && q == i)
                {
                    Assert.Fail();
                }
                q++;
            }
        }

        [Given(@"I am editing an LTL shipment in CRM(.*)")]
        public void GivenIAmEditingAnLTLShipmentInCRM(string customerName)
        {
            ltl.NaviagteToShipmentList();
            Report.WriteLine("Selecting " + customerName + " from the dropdown");
            Click(attributeName_xpath, ShipmentList_CustomerOrStationDropdown_Xpath);
            Thread.Sleep(2000);
            IList<IWebElement> CustomerDropdown_List = GlobalVariables.webDriver.FindElements(By.XPath(CustomerDropdownValesExtuser_Xpath));
            int CustomerNameListCount = CustomerDropdown_List.Count;
            for (int i = 0; i < CustomerNameListCount; i++)
            {
                if (CustomerDropdown_List[i].Text == customerName)
                {
                    CustomerDropdown_List[i].Click();
                    break;
                }
            }
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Click on Edit Shipment button");
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_id, "searchbox", "ZZX002016053");
            Thread.Sleep(5000);
            Click(attributeName_xpath, ".//*[@id='ShipmentGrid']/tbody/tr/td[10]/button");
            GlobalVariables.webDriver.WaitForPageLoad();
            scrollpagedown();
            scrollpagedown();
            scrollElementIntoView(attributeName_xpath, ViewRatesButton_xpath);
            ltl.ClickViewRates();
            Report.WriteLine("Click on Edit Shipment button");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_cssselector, "#gridLTLresult tr:first-child #createShipment");
        }

        [Then(@"the shipment will be updated in Mercurygate with a reference type of ""(.*)""")]
        public void ThenTheShipmentWillBeUpdatedInMercurygateWithAReferenceTypeOf(string crmrl)
        {
            ThenTheShipmentWillBeCreatedInMercurygateWithAReferenceTypeOf(crmrl);
        }

        [Given(@"the customer account associated to the shipment has CRM rating logic turned Off(.*)")]
        public void GivenTheCustomerAccountAssociatedToTheShipmentHasCRMRatingLogicTurnedOff(string Customer_Name)
        {
            bool iSCrmRatingLogic_GainshareCustomer = DBHelper.CheckNewCrmRatingLogic(Customer_Name);
            if (iSCrmRatingLogic_GainshareCustomer)
            {
                Report.WriteLine("Customer is belongs to CRM Rating Logic");
            }
            else
            {
                Report.WriteLine("CRM Rating logic is not Enabled for the Customer");
            }
        }

        [Then(@"the shipment will be created in Mercurygate without a reference type ""(.*)""")]
        public void ThenTheShipmentWillBeCreatedInMercurygateWithoutAReferenceType(string crmrl)
        {
            string referenceNumber = Gettext(attributeName_id, ShipmentConfirmationNumber_Id);
            string uri = $"MercuryGate/OidLookup";
            BuildHttpClient client = new BuildHttpClient();
            HttpClient headers = client.BuildHttpClientWithHeaders("Admin", "application/xml");

            ShipmentExtract ext = new ShipmentExtract();
            shipmentViewModels = ext.getShipmentData(uri, headers, referenceNumber, "Admin");
            foreach (ShipmentImportReferenceModel a in shipmentViewModels.ReferenceNumbers)
            {
                if (a.Type != crmrl)
                {
                    Report.WriteLine("Reference Type CRMRL is not added in MG");
                }
                else if (a.Type == crmrl)
                {
                    Assert.Fail();
                }

            }

        }

        [Given(@"I am Shp\.Entry, Shp\.Entrynorates, Sales, Sales Management, Operations, or Station Owner user(.*)")]
        public void GivenIAmShp_EntryShp_EntrynoratesSalesSalesManagementOperationsOrStationOwnerUser(string usertype)
        {

            string username = string.Empty;
            string password = string.Empty;
            if (usertype == "Internal")
            {
                username = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
                password = ConfigurationManager.AppSettings["password-crmOperation"].ToString();
            }
            else if (usertype == "Sales")
            {
                usertype = "Internal";
                username = ConfigurationManager.AppSettings["username-uat.sales"].ToString();
                password = ConfigurationManager.AppSettings["password-uat.sales"].ToString();
            }
            else if (usertype == "External")
            {
                username = ConfigurationManager.AppSettings["username-shpentryGSDemo"].ToString();
                password = ConfigurationManager.AppSettings["password-shpentryGSDemo"].ToString();
            }
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"I'm sales, salesmanagement, operations, or station owner user(.*)")]
        public void GivenIMSalesSalesmanagementOperationsOrStationOwnerUser(string usertype)
        {
            string username = string.Empty;
            string password = string.Empty;
            if (usertype == "Internal")
            {
                username = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
                password = ConfigurationManager.AppSettings["password-crmOperation"].ToString();
            }
            else if (usertype == "Sales")
            {
                username = ConfigurationManager.AppSettings["username-uat.sales"].ToString();
                password = ConfigurationManager.AppSettings["password-uat.sales"].ToString();
            }
            
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }


        [Given(@"I am creating an LTL shipment for the Customer having CRM Rating Logic off(.*), (.*), (.*),(.*), (.*), (.*),(.*),(.*),(.*), (.*),(.*), (.*), (.*),(.*), (.*), (.*), (.*)")]
        public void GivenIAmCreatingAnLTLShipmentForTheCustomerHavingCRMRatingLogicOff(string Usertype,
            string oAdd2,
            string oZip,
            string oName,
            string oAdd1,
            string dAdd2,
            string dName,
            string dAdd1,
            string Customer_Name,
            string oComments,
            string dComments,
            string dZip,
            string classification,
            string nmfc,
            string quantity,
            string weight,
            string desc)
        {
            bool iSCrmRatingLogic_GainshareCustomer = DBHelper.CheckNewCrmRatingLogic(Customer_Name);
            if (iSCrmRatingLogic_GainshareCustomer)
            {
                Report.WriteLine("Customer is belongs to CRM Rating Logic");
            }
            else
            {
                Report.WriteLine("CRM Rating logic is not Enabled for the Customer");
            }

            ltl.NaviagteToShipmentList();
            ltl.SelectCustomerFromShipmentList(Usertype, Customer_Name);
            Click(attributeName_id, ShippingFrom_ClearAddress_Id);
            Click(attributeName_id, ShippingTo_ClearAddress_Id);
            ltl.AddShipmentOriginData(oName, oAdd1, oZip);
            ltl.AddShipmentDestinationData(dName, dAdd1, dZip);
            scrollElementIntoView(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            Click(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            ltl.AddShipmentFreightDescription(classification, nmfc, quantity, weight, desc);
            Click(attributeName_xpath, ViewRatesButton_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            ltl.ClickOnCreateShipmentButton(Usertype);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I'm Sales, Sales Management, Operations, or Station Owner User(.*)")]
        public void GivenIMSalesSalesManagementOperationsOrStationOwnerUser(string usertype)
        {
            GivenIAmShp_EntryShp_EntrynoratesSalesSalesManagementOperationsOrStationOwnerUser(usertype);
        }

        [Given(@"I am editing LTL shipment belongs to Customer having CRM Rating Logic off(.*)")]
        public void GivenIAmEditingLTLShipmentBelongsToCustomerHavingCRMRatingLogicOff(string customername)
        {
            bool iSCrmRatingLogic_GainshareCustomer = DBHelper.CheckNewCrmRatingLogic(customername);
            if (iSCrmRatingLogic_GainshareCustomer)
            {
                Report.WriteLine("Customer is belongs to CRM Rating Logic");
            }
            else
            {
                Report.WriteLine("CRM Rating logic is not Enabled for the Customer");
            }
            ltl.NaviagteToShipmentList();
            Report.WriteLine("Selecting " + customername + " from the dropdown");
            Click(attributeName_xpath, ShipmentList_CustomerOrStationDropdown_Xpath);
            Thread.Sleep(2000);
            IList<IWebElement> CustomerDropdown_List = GlobalVariables.webDriver.FindElements(By.XPath(CustomerDropdownValesExtuser_Xpath));
            int CustomerNameListCount = CustomerDropdown_List.Count;
            for (int i = 0; i < CustomerNameListCount; i++)
            {
                if (CustomerDropdown_List[i].Text == customername)
                {
                    CustomerDropdown_List[i].Click();
                    break;
                }
            }
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Click on Edit Shipment button");
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_id, "searchbox", "ZZX002016007");
            Thread.Sleep(5000);
            Click(attributeName_xpath, ".//*[@id='ShipmentGrid']/tbody/tr/td[10]/button");
            GlobalVariables.webDriver.WaitForPageLoad();
            scrollpagedown();
            scrollpagedown();
            scrollElementIntoView(attributeName_xpath, ViewRatesButton_xpath);
            ltl.ClickViewRates();
            Report.WriteLine("Click on Edit Shipment button");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_cssselector, "#gridLTLresult tr:first-child #createShipment");
        }
    }
}
