using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.CsaServiceReference;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Threading;

namespace CRM.UITest.Scripts.Shipment.ShipmentList.Shipment_List___Display_CSA_Shipments
{
    [Binding]
    public class CRMShipmentList_DisplayCSAShipmentsSteps : Shipmentlist
    {
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
        string Customerno = string.Empty;
        string DateTimeRangeIsDelivery = string.Empty;
        string Mode = string.Empty;
        string ServiceLevel = string.Empty;
        string Status = string.Empty;
        string RefNo = string.Empty;
        string ShipperCity = string.Empty;
        string ConsigneeCity = string.Empty;
        string HandlingStation = "ZZZ";
        List<String> ShipList = new List<string>();
        List<string> shipmentValueListUI = new List<string>();

        [Given(@"I am a shp\.entry, shp\.entrynorates, shp\.inquiry, shp\.inquirynorates, operations, sales, sales management, or station owner user")]
        public void GivenIAmAShp_EntryShp_EntrynoratesShp_InquiryShp_InquirynoratesOperationsSalesSalesManagementOrStationOwnerUser()
        {
            string userName = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
            string password = ConfigurationManager.AppSettings["password-crmOperation"].ToString();
            CrmLogin.LoginToCRMApplication(userName, password);
        }

        [Given(@"I am a sales, sales management, or station owner user")]
        public void GivenIAmASalesSalesManagementOrStationOwnerUser()
        {
            string userName = ConfigurationManager.AppSettings["username-CurrentSprintOperations"].ToString();
            string password = ConfigurationManager.AppSettings["password-CurrentSprintOperations"].ToString();
            CrmLogin.LoginToCRMApplication(userName, password);
        }

        [Given(@"I am on the ShipmentList page")]
        public void GivenIAmOnTheShipmentListPage()
        {
            
            Click(attributeName_xpath, ShipmentIcon_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I have entered reference number (.*)")]
        public void GivenIHaveEnteredReferenceNumber(string refNumber)
        {
            SendKeys(attributeName_xpath, ShipmentList_ReferenceNumLookup_Xpath, refNumber);
        }

        [When(@"I Select (.*) of service types includes(.*)")]
        public void WhenISelectOfServiceTypesIncludes(string reportName, string servicetypes)
        {

            WaitForElementVisible(attributeName_xpath, ShipmentList_Header_Xpath, "Shipment List Header");
            Report.WriteLine("Selecting Custom Report");
            Click(attributeName_xpath, ShipmentList_Report_dropdown_Xpath);
            SendKeys(attributeName_xpath, ".//*[@id='ReportType_chosen']//div/input", reportName);
            IList<IWebElement> customerDropdownList = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_Report_dropdown_Values_Xpath));
            customerDropdownList[1].Click();

            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ShipmentList_ShowFilter_link_Id);
            string[] serviceTypesValue = servicetypes.Split(',');
            if (servicetypes == "Domestic Forwarding")
            { VerifyElementChecked(attributeName_xpath, ".//*[@id='Search_CheckBoxDomesticForwarding']", serviceTypesValue[0]); }
            else if (servicetypes == "International")
             { VerifyElementChecked(attributeName_xpath, "//*[@id='Search_CheckBoxInternational']", serviceTypesValue[0]); }
            else
            {
                VerifyElementChecked(attributeName_xpath, ".//*[@id='Search_CheckBoxDomesticForwarding']", serviceTypesValue[0]);
                VerifyElementChecked(attributeName_xpath, ".//*[@id='Search_CheckBoxInternational']", serviceTypesValue[1]);
            }
        }

        [When(@"I click on arrow")]
        public void WhenIClickOnArrow()
        {
            Click(attributeName_xpath, ".//*[@class='btnReference colored btn btn-default btn-input-addon']");
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [When(@"I select (.*) from customer dropdown of shipment list page")]
        public void WhenISelectFromCustomerDropdownOfShipmentListPage(string station)
        {
            Report.WriteLine("Click on the Shipment icon from the left navigation bar");
            Click(attributeName_xpath, ShipmentIcon_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("I am on the shipment list page");
            Verifytext(attributeName_xpath, ShipmentList_Title_Xpath, "Shipment List");

            Click(attributeName_xpath, CustomerDropdownExtuser_Xpath);

            SendKeys(attributeName_xpath, ShipmentList_CustomerSelection_DropdownSearch_Xpath, station);
            IList<IWebElement> customerDropdownList = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_CustomerSelection_Dropdown_Values_Xpath));
            customerDropdownList[1].Click();
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Then(@"the shipment list will have CSA reference number (.*)")]
        public void ThenTheShipmentListWillHaveCSAReferenceNumber(string refNumber)
        {
            Shipmentlist shipmentList = new Shipmentlist();
            int shipmentRowCount = GetCount(attributeName_xpath, shipmentList.ShipmentList_TotalRecords_Xpath);
            if (shipmentRowCount >= 1)
            {
                List<string> ShipmentListRefNumber_UI = IndividualColumnData(shipmentList.ShipmentList_Referencenumbersgrid_Xpath);
                string[] referenceNumbers = refNumber.Split(',');
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
            else
            {
                Report.WriteLine("Shipment List count is null");
            }
        }
        
        [Then(@"the shipment list will have the CSA shipments for the (.*)")]
        public void ThenTheShipmentListWillHaveTheCSAShipmentsForThe(string customreport)
        {
                        
            IList<IWebElement> shipmentsUI = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentListGrid_RefNumAllValues_Xpath));
            List<string> shipmentListUI = new List<string>();
            IList<IWebElement> ServicesUI = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='ShipmentGrid']/tbody/tr/td[4]"));
            List<string> csaServicesListUI = new List<string>();

            if (shipmentsUI.Count > 1)
            {

                for (int k = 0; k < shipmentsUI.Count; k++)
                {
                    string UIShipNumber = shipmentsUI[k].Text;
                    shipmentListUI.Add(UIShipNumber);
                }
                for(int j = 0; j < ServicesUI.Count; j++)
                {
                    string serviceTypeUI = shipmentsUI[j].Text;
                    csaServicesListUI.Add(serviceTypeUI);
                }
                if (shipmentListUI.Intersect(csaServicesListUI).Any())
                {
                    Report.WriteLine("CSA Shipments displaying in UI for the custom report");
                }

            }
            else
            {
                Report.WriteLine("No shipment exists for the selected custom report");                
            }
        }

        [Then(@"CSA API result should contains the CSA shipment list  showing in Grid  for the follwing values (.*),(.*),(.*),(.*),(.*)")]
        public void ThenCSAAPIResultShouldContainsTheCSAShipmentListShowingInGridForTheFollwingValues(string DateStartTime, string DateStopTime, string OriginCity, string DestinationCity, string Station)
        {
            ShipmentsSoapClient csaClient = new ShipmentsSoapClient();
            ShipmentListReponse csaCustomerNumbersFromApi = csaClient.ShipmentListParm(Customerno, DateStartTime.ToString(), DateStopTime.ToString(), DateTimeRangeIsDelivery, Mode, ServiceLevel, Status, RefNo, ShipperCity, ConsigneeCity, HandlingStation);
            Report.WriteLine("Getting Result for CSA API ");
            List<string> ShipValue = csaCustomerNumbersFromApi.Shipments.Select(a => a.Housebill).ToList();
            foreach (var t in ShipValue)
            {
                ShipList.Add(t);
            }
            scrollpagedown();
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Getting UI Shipment refrence Number List");
            Click(attributeName_xpath, ShipmentGridView_Xpath);           
            SelectDropdownValueFromList(attributeName_xpath, ShipmentGridViewOption_Xpath, "ALL");            
            IList<IWebElement> shipmentsUI = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentListGrid_RefNumAllValues_Xpath));            

            if (shipmentsUI.Count >= 1)
            {

                for (int k = 0; k < shipmentsUI.Count; k++)
                {
                    string ShipmentListFromUI = shipmentsUI[k].Text;
                    shipmentValueListUI.Add(ShipmentListFromUI);
                }

            }
            else
            {
                Report.WriteLine("No shipment exists for the selected account");
                VerifyElementPresent(attributeName_xpath, ShipmentList_NoRecords_Xpath, "No Records Found");
            }


            if (ShipList.Intersect(shipmentValueListUI).Any())
            {
                Report.WriteLine("CSA Shipments displaying in UI");
            }
            else
            { Report.WriteFailure("CSA shipments in grid and from API do not match"); }
        }



        [Then(@"the Shipment list will have the CSA shipments for the customreport associated to Sales user (.*)\.")]
        public void ThenTheShipmentListWillHaveTheCSAShipmentsForTheCustomreportAssociatedToSalesUser_(string customers)
        {
                 
            GlobalVariables.webDriver.WaitForPageLoad();           
            
            IList<IWebElement> CustomerUI = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentListGrid_CustomerName));    
            
            Report.WriteLine("Verifying Grid for mapping customer to sales user");
            if (CustomerUI.Count >= 1)
            {

                for (int k = 1; k <= CustomerUI.Count; k++)
                {
                    string ActualCustomerValue = Gettext(attributeName_xpath, ".//*[@id='ShipmentGrid']/tbody/tr[" + k + "]/td[3]//span[2]");

                    if (ActualCustomerValue == customers)
                    {
                        Report.WriteLine("Shipments belongs to customer name " + customers + " mapped to the sales user ");
                    }
                    else
                    {
                        Report.WriteFailure("Shipments belongs to customer name " + customers + "not mapped to the sales user");
                    }
                }

            }
        }


        [Then(@"shipment list will have the CSA shipments for the selected (.*)")]
        public void ThenShipmentListWillHaveTheCSAShipmentsForTheSelected(string station)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            //Getting UI Shipment List3            
            SelectDropdownlistvalue(attributeName_xpath, ShipmentList_TopGrid_ViewDropdownValues_Xpath, "ALL");

            IList<IWebElement> shipmentsUI = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentListGrid_RefNumAllValues_Xpath));
            List<string> shipmentValueListUI = new List<string>();
            Report.WriteLine("UI values count are: " + shipmentsUI);

            if (shipmentsUI.Count > 1)
            {

                for (int k = 0; k < shipmentsUI.Count; k++)
                {
                    string ShipmentListFromUI = shipmentsUI[k].Text;
                    shipmentValueListUI.Add(ShipmentListFromUI);
                }

            }
            else
            {
                Report.WriteLine("No shipment exists for the selected account");
                VerifyElementPresent(attributeName_xpath, ShipmentList_NoRecords_Xpath, "No Records Found");
            }

            CustomerAccount stationDetails = DBHelper.GetStationDetailsByStationName(station);

            string dbDetails = DBHelper.GetStationNameonStationID(stationDetails.StationId);
            List<CustomerAccount> listOfAccountsForTheStation = DBHelper.GetAccountsMappedforStation(dbDetails);
            List<String> shipmentListAPI = new List<string>();
            for (int k = 0; k < listOfAccountsForTheStation.Count; k++)
            {
                if (listOfAccountsForTheStation[k].TmsSystem == "CSA" || listOfAccountsForTheStation[k].TmsSystem == "BOTH")
                {
                    ShipmentsSoapClient csaClient = new ShipmentsSoapClient();
                    ShipmentListReponse csaShipmentForSelectedStation = csaClient.ShipmentList30Days();
                    Report.WriteLine("CSA API values are: " + csaShipmentForSelectedStation);
                    if (csaShipmentForSelectedStation != null)
                    {
                        List<string> ShipmentListFromApi = csaShipmentForSelectedStation.Shipments.Select(a => a.Housebill).ToList();
                        foreach (var t in ShipmentListFromApi)
                        {
                            shipmentListAPI.Add(t);
                        }
                    }
                    else
                    {
                        Report.WriteLine("Data not found for the CSA station account number" + listOfAccountsForTheStation[k].CsaCustomerNumber);
                    }
                }
            }
            if (shipmentListAPI.Intersect(shipmentValueListUI).Any())
            {
                Console.WriteLine("CSA Shipments displaying in UI");
            }                           
        }
    }
}