using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System.Configuration;
using CRM.UITest.CommonMethods;
using CRM.UITest.CsaServiceReference;

namespace CRM.UITest.Scripts.Dashboard.Shipment.LTL.Shipment_List
{
    [Binding]
    public class ShipDashboard_RefNumLookupOnMVC5ShipmentListSteps : ObjectRepository
    {
        [Given(@"I am a shp\.entry, shp\.entrynorates, shp\.inquiry, shp\.inquirynorates mapped to MG customer")]
        public void GivenIAmAShp_EntryShp_EntrynoratesShp_InquiryShp_InquirynoratesMappedToMGCustomer()
        {
            string username = ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();
            string password = ConfigurationManager.AppSettings["ExternalUserPassword"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"I am a shp\.entry, shp\.entrynorates, shp\.inquiry, shp\.inquirynorates mapped to both customer")]
        public void GivenIAmAShp_EntryShp_EntrynoratesShp_InquiryShp_InquirynoratesMappedToBothCustomer()
        {
            string username = ConfigurationManager.AppSettings["username-Both"].ToString();
            string password = ConfigurationManager.AppSettings["password-Both"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [When(@"I am searching (.*) in the Reference Number Lookup field on dashboard")]
        public void WhenIAmSearchingInTheReferenceNumberLookupFieldOnDashboard(string referencenumber)
        {
            Report.WriteLine("Searching In The ReferenceNumber LookupField On Dashboard");
            SendKeys(attributeName_id, Dashboard_ReferenceNumberLookup_Id, referencenumber);
            Click(attributeName_id, Dashboard_Referencesubmit_Id);

        }

        [When(@"I will arrive on a shipment list page")]
        public void WhenIWillArriveOnAShipmentListPage()
        {
            Shipmentlist shipmentList = new Shipmentlist();
            Report.WriteLine("I will arrive on a shipment list page");
            //
            Thread.Sleep(200000);
            VerifyElementVisible(attributeName_xpath, shipmentList.ShipmentList_Title_Xpath, "shipmentlistheader");
        }

        [Then(@"I am searching (.*) in the Reference Number Lookup field on dashboard for csa shipments")]
        public void ThenIAmSearchingInTheReferenceNumberLookupFieldOnDashboardForCsaShipments(string referencenumber)
        {
            Shipmentlist shipmentList = new Shipmentlist();
            int shipmentRowCount = GetCount(attributeName_xpath, shipmentList.ShipmentList_TotalRecords_Xpath);
            if (shipmentRowCount >= 1)
            {
                List<string> ShipmentListRefNumber_UI = IndividualColumnData(shipmentList.ShipmentList_Referencenumbersgrid_Xpath);
                string[] referenceNumbers = referencenumber.Split(',');
                referenceNumbers.Select(int.Parse).ToList();
                List<string> csaShipmentListApi = new List<string>();
                for (int i = 0; i < referenceNumbers.Count(); i++)
                {
                    ShipmentsSoapClient csaClient = new ShipmentsSoapClient();
                    ShipmentListReponse csaCustomerNumbersFromApi = csaClient.ShipmentListByRefNo(referenceNumbers[i]);

                    if (csaCustomerNumbersFromApi != null)
                    {
                        List<string> shipmentValue = csaCustomerNumbersFromApi.Shipments.Select(a => a.Housebill).ToList();
                        foreach (var t in shipmentValue)
                        {
                            csaShipmentListApi.Add(t);
                        }
                    }

                }

                for (int j = 0; j < ShipmentListRefNumber_UI.Count; j++)
                {

                    if (csaShipmentListApi.Contains(ShipmentListRefNumber_UI[j]))
                    {
                        Report.WriteLine("Entered Reference number and Reference value appearing in the shipment list grid are same");
                    }
                    else
                    {
                        throw new Exception("Entered Reference number and Reference value appearing in the shipment list grid are not same");

                    }
                }
            }
        }



        [Then(@"Searched reference number will be displayed in the grid (.*)")]
        public void ThenSearchedReferenceNumberWillBeDisplayedInTheGrid(string referencenumber)
        {
            Shipmentlist shipmentList = new Shipmentlist();
            int shipmentRowCount = GetCount(attributeName_xpath, shipmentList.ShipmentList_TotalRecords_Xpath);
            if (shipmentRowCount >= 1)
            {
                List<string> ShipmentListRefNumber_UI = IndividualColumnData(shipmentList.ShipmentList_Referencenumbersgrid_Xpath);
                string[] referenceNumbers = referencenumber.Split(',');
                for (int i = 0; i < ShipmentListRefNumber_UI.Count; i++)
                {
                    if (referenceNumbers.Contains(ShipmentListRefNumber_UI[i]))
                    {
                        Report.WriteLine("Entered Reference number and Reference value appearing in the shipment list grid are same");
                    }
                    else
                    {
                        throw new Exception("Entered Reference number and Reference value appearing in the shipment list grid are not same");

                    }
                }
            }
        }


    }
}

