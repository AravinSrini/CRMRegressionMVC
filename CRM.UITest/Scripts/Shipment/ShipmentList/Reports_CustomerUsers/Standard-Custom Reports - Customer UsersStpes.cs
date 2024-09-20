using CRM.UITest.CsaServiceReference;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.Common;
using CRM.UITest.Helper.Implementations.ShipmentList;
using CRM.UITest.Helper.Implementations.StandardReport;
using CRM.UITest.Helper.ViewModel.Shipment;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Xml.Linq;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.ShipmentList.Reports_CustomerUsers
{
    [Binding]
    public class Standard_Custom_Reports___Customer_UsersStpes : Shipmentlist
    {
        string CreatedCustomReport;
        string errorMessage=null;


        [Given(@"I click on the Shipment Icon")]
        public void GivenIClickOnTheShipmentIcon()
        {
           
            Click(attributeName_xpath, ShipmentModule_Xpath);
            WaitForElementVisible(attributeName_xpath, ShipmentList_Header_Xpath, "Shipment List");

            bool d = IsElementPresent(attributeName_xpath, ".//*[@id='error']/h2", "Warning");
            if (d)
            {
                Click(attributeName_xpath, ".//*[@id='btn-error-Close']");
            }
        }


        [When(@"I Click on Show Filter link")]
        public void WhenIClickOnShowFilterLink()
        {
            Click(attributeName_id, ShipmentList_ShowFilter_link_Id);


        }

        [Then(@"the Delete and Update button should be in disable mode")]
        public void ThenTheDeleteAndUpdateButtonShouldBeInDisableMode()
        {
            //Need to check?
            bool value = IsElementEnabled(attributeName_id, FilterSection_DeleteReport_button_Id, "Delete Report");
            bool value2 = IsElementEnabled(attributeName_id, FilterSection_UpdateReport_button_Id, "Update Report");

            //IWebElement e2 = GlobalVariables.webDriver.FindElement(By.Id(FilterSection_SaveReport_button_Id));
            //bool b11 = e2.Displayed;
            //bool b111 = e2.dis;           

            //IWebElement e=GlobalVariables.webDriver.FindElement(By.Id(FilterSection_UpdateReport_button_Id));
            //bool b = e.Displayed;
            //bool b1 = e.Enabled;

        }

        [Then(@"I will see services associated to mapped customer TMS type (.*)")]
        public void ThenIWillSeeServicesAssociatedToMappedCustomerTMSType(string TMSType)
        {
            if (TMSType == "MG")
            {
                //Can compare bool value 
                IsElementEnabled(attributeName_xpath, FilterSection_LTL_ServiceType_Checkbox_Xpath, "LTL");
                IsElementEnabled(attributeName_xpath, FilterSection_TL_ServiceType_Checkbox_Xpath, "TRUCKLOAD");
                IsElementEnabled(attributeName_xpath, FilterSection_PTL_ServiceType_Checkbox_Xpath, "PARTIAL TRUCKLOAD");
                IsElementEnabled(attributeName_xpath, FilterSection_IML_ServiceType_Checkbox_Xpath, "INTERMODAL");
            }
            if (TMSType == "CSA")
            {
                IsElementEnabled(attributeName_xpath, FilterSection_DomForwarding_ServiceType_Checkbox_Xpath, "DOMESTIC");
                IsElementEnabled(attributeName_xpath, FilterSection_Intl_ServiceType_Checkbox_Xpath, "INTERNATIONAL");


            }
            if (TMSType == "BOTH")
            {
                IsElementEnabled(attributeName_xpath, FilterSection_LTL_ServiceType_Checkbox_Xpath, "LTL");
                IsElementEnabled(attributeName_xpath, FilterSection_TL_ServiceType_Checkbox_Xpath, "TRUCKLOAD");
                IsElementEnabled(attributeName_xpath, FilterSection_PTL_ServiceType_Checkbox_Xpath, "PARTIAL TRUCKLOAD");
                IsElementEnabled(attributeName_xpath, FilterSection_IML_ServiceType_Checkbox_Xpath, "INTERMODAL");
                IsElementEnabled(attributeName_xpath, FilterSection_DomForwarding_ServiceType_Checkbox_Xpath, "DOMESTIC");
                IsElementEnabled(attributeName_xpath, FilterSection_Intl_ServiceType_Checkbox_Xpath, "INTERNATIONAL");

                // VerifyElementChecked(attributeName_xpath, ReferenceNumber_CheckBox_Xpath, reference_number);

            }
        }



        [When(@"I have selected any custom report from report drop down (.*)")]
        public void WhenIHaveSelectedAnyCustomReportFromReportDropDown(string Standard_ReportName)
        {
            Click(attributeName_xpath, ShipmentList_FilteredReports_Xpath);
            SendKeys(attributeName_xpath, SelectAReportSearchBoxnShipmentList_Xpath, Standard_ReportName);

            Click(attributeName_xpath, "//*[@id='ReportType_chosen']/div/ul/li[2]");
        }



        [When(@"I have selected any standard report from report drop down (.*)")]
        public void WhenIHaveSelectedAnyStandardReportFromReportDropDown(string Standard_ReportName)
        {
            Click(attributeName_xpath, ShipmentList_FilteredReports_Xpath);
            SendKeys(attributeName_xpath, SelectAReportSearchBoxnShipmentList_Xpath, Standard_ReportName);

            Click(attributeName_xpath, "//*[@id='ReportType_chosen']/div/ul/li[2]");
        }


        [Then(@"the shipment list will update the previous (.*) days shipments from MG and CSA (.*),(.*),(.*)")]
        public void ThenTheShipmentListWillUpdateThePreviousDaysShipmentsFromMGAndCSA(int p0, string Customer_Name, string Standard_ReportName, string Standard_MGReportName)
        {
            Click(attributeName_xpath, "//*[@id='ShipmentGrid_length']/label/select");
            SelectDropdownlistvalue(attributeName_xpath, "//*[@id='ShipmentGrid_length']/label/select", "ALL");
            Click(attributeName_xpath, "//*[@id='ShipmentGrid']/thead/tr/th[1]");

            List<String> ShipList = new List<string>();
            int accID = DBHelper.GetAccountIdforAccountName(Customer_Name);
            CustomerSetup value = DBHelper.GetSetupDetails(accID);

            // Building request xml
            ListScreenExtractRequestXML data = new ListScreenExtractRequestXML();
            XElement reqXML = data.GetRequestXMLForShipmentListExternalUser(value.MgAccountNumber, Standard_MGReportName, Customer_Name);

            //Building Client
            BuildHttpClient client = new BuildHttpClient();
            HttpClient headers = client.BuildHttpClientWithHeaders(Customer_Name, "application/xml");



            string uri = $"MercuryGate/ListScreenExtract";
            ShipmentListScreen Slist = new ShipmentListScreen();
            List<ShipmentListViewModel> Sdata = Slist.CallListScreen(uri, headers, reqXML);

            if (Sdata != null)
            {
                for (int j = 1; j < Sdata.Count; j++)
                {
                    ShipList.Add(Sdata[j].PrimaryReference);
                }
            }
            else
            {
                Report.WriteLine("Not received any reposnse from API");
            }


            int SetUpID = DBHelper.GetAccountIdforAccountName(Customer_Name);
            CustomerAccount valueList = DBHelper.GetAccountDetails(SetUpID);
            string TMSType = valueList.TmsSystem;
            // int _number = Convert.ToInt32(Num);


            //string DBdetails = DBHelper.GetStationNameonStationID(StatID[i]);
            //        List<CustomerAccount> listvalue = DBHelper.GetAccountsMappedforStation(DBdetails);


            if (TMSType == "CSA" || TMSType == "BOTH")
            {
                CSAShipmentListReports CSAShip = new CSAShipmentListReports();
                ShipmentListReponse APIShipments = CSAShip.GetCSAShipmentListStandardReport(Convert.ToInt32(valueList.CsaCustomerNumber), out errorMessage, Standard_MGReportName);
                if (APIShipments != null)
                {
                    List<string> ShipValue = APIShipments.Shipments.Select(a => a.Housebill).ToList();
                    foreach (var t in ShipValue)
                    {
                        ShipList.Add(t);
                    }
                }
                else
                {
                    Report.WriteLine("Data not found for the CSA station account number");
                }

            }

            //Getting UI Shipment List
            IList<IWebElement> UIShipments = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentListGrid_RefNumAllValues_Xpath));
            List<string> UIValue = new List<string>();

            if (ShipList.Count > 1)
            {

                for (int k = 0; k < UIShipments.Count; k++)
                {
                    string UIQuoteNumber = UIShipments[k].Text;
                    UIValue.Add(UIQuoteNumber);
                }

                Assert.AreEqual(ShipList.Count, UIValue.Count);
                CollectionAssert.AreEqual(ShipList.OrderBy(q => q).ToList(), UIValue.OrderBy(q => q).ToList());
                Report.WriteLine("Displaying default shipment list in the UI is matching with API results");
            }
            else
            {
                Report.WriteLine("No shipment exists for the selected account");
                VerifyElementPresent(attributeName_xpath, ShipmentList_NoRecords_Xpath, "No Records Found");
            }
        }



        [Then(@"the shipment list will update the previous thirty days shipments from MG(.*),(.*),(.*)")]
        public void ThenTheShipmentListWillUpdateThePreviousThirtyDaysShipmentsFromMG(string Customer_Name, string Standard_ReportName, string Standard_MGReportName)
        {
            Click(attributeName_xpath, "//*[@id='ShipmentGrid_length']/label/select");
            SelectDropdownlistvalue(attributeName_xpath, "//*[@id='ShipmentGrid_length']/label/select", "ALL");
            Click(attributeName_xpath, "//*[@id='ShipmentGrid']/thead/tr/th[1]");

            int accID = DBHelper.GetAccountIdforAccountName(Customer_Name);
            CustomerSetup value = DBHelper.GetSetupDetails(accID);

            // Building request xml
            ListScreenExtractRequestXML data = new ListScreenExtractRequestXML();
            XElement reqXML = data.GetRequestXMLForShipmentListExternalUser(value.MgAccountNumber, Standard_MGReportName, Customer_Name);

            //Building Client
            BuildHttpClient client = new BuildHttpClient();
            HttpClient headers = client.BuildHttpClientWithHeaders(Customer_Name, "application/xml");


            string uri = $"MercuryGate/ListScreenExtract";
            ShipmentListScreen Slist = new ShipmentListScreen();
            List<ShipmentListViewModel> Sdata = Slist.CallListScreen(uri, headers, reqXML);

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
                //UIValue.Reverse();//reversed code
                CollectionAssert.AreEqual(ShipmentList, UIValue);

            }
            else
            {
                Report.WriteLine("Values does not exists in shipment list response");
            }
        }



       


        [Then(@"I will able to select one or multi service check boxes")]
        public void ThenIWillAbleToSelectOneOrMultiServiceCheckBoxes()
        {
            Click(attributeName_xpath, FilterSection_LTL_ServiceType_Checkbox_XpathEU);
            VerifyElementChecked(attributeName_xpath, FilterSection_LTL_ServiceType_Checkbox_XpathEU, "LTL");
            Click(attributeName_xpath, FilterSection_TL_ServiceType_Checkbox_XpathEU);
            VerifyElementChecked(attributeName_xpath, FilterSection_TL_ServiceType_Checkbox_XpathEU, "TRUCKLOAD");
        }



        [When(@"I click on Select All button")]
        public void WhenIClickOnSelectAllButton()
        {
            Click(attributeName_xpath, FilterSection_SelectAll_button_Xpath);
        }


        [Then(@"All service type check boxes should be selected (.*)")]
        public void ThenAllServiceTypeCheckBoxesShouldBeSelected(string TMSType)
        {

            if (TMSType == "Both")
            {
                
              
                VerifyElementChecked(attributeName_xpath, FilterSection_LTL_ServiceType_Checkbox_XpathEU, "LTL");
                VerifyElementChecked(attributeName_xpath, FilterSection_TL_ServiceType_Checkbox_XpathEU, "TRUCKLOAD");
                VerifyElementChecked(attributeName_xpath, FilterSection_PTL_ServiceType_Checkbox_XpathEU, "PARTIAL TRUCKLOAD");
                VerifyElementChecked(attributeName_xpath, FilterSection_IML_ServiceType_Checkbox_XpathEU, "INTERMODAL");
                VerifyElementChecked(attributeName_xpath, FilterSection_DomForwarding_ServiceType_Checkbox_XpathEU, "DOMESTIC");
                VerifyElementChecked(attributeName_xpath, FilterSection_Intl_ServiceType_Checkbox_XpathEU, "INTERNATIONAL");
            }
            if (TMSType == "MG")
            {
                VerifyElementChecked(attributeName_xpath, FilterSection_LTL_ServiceType_Checkbox_XpathEU, "LTL");
                VerifyElementChecked(attributeName_xpath, FilterSection_TL_ServiceType_Checkbox_XpathEU, "TRUCKLOAD");
                VerifyElementChecked(attributeName_xpath, FilterSection_PTL_ServiceType_Checkbox_XpathEU, "PARTIAL TRUCKLOAD");
                VerifyElementChecked(attributeName_xpath, FilterSection_IML_ServiceType_Checkbox_XpathEU, "INTERMODAL");

            }
            if (TMSType == "CSA")
            {
                VerifyElementChecked(attributeName_xpath, FilterSection_DomForwarding_ServiceType_Checkbox_XpathEU, "DOMESTIC");
                VerifyElementChecked(attributeName_xpath, FilterSection_Intl_ServiceType_Checkbox_XpathEU, "INTERNATIONAL");
            }
        }

        [When(@"I click on Clear All button in report section")]
        public void WhenIClickOnClearAllButtonInReportSection()
        {
            Click(attributeName_xpath, FilterSection_ClearAll_button_Xpath);
        }

        [Then(@"All service type check boxes should be UN-checked(.*)")]
        public void ThenAllServiceTypeCheckBoxesShouldBeUN_Checked(string TMSType)
        {
            if (TMSType == "Both")
            {
                VerifyElementNotChecked(attributeName_xpath, FilterSection_LTL_ServiceType_Checkbox_XpathEU, "LTL");
                VerifyElementNotChecked(attributeName_xpath, FilterSection_TL_ServiceType_Checkbox_XpathEU, "TRUCKLOAD");
                VerifyElementNotChecked(attributeName_xpath, FilterSection_PTL_ServiceType_Checkbox_XpathEU, "PARTIAL TRUCKLOAD");
                VerifyElementNotChecked(attributeName_xpath, FilterSection_IML_ServiceType_Checkbox_XpathEU, "INTERMODAL");
                VerifyElementNotChecked(attributeName_xpath, FilterSection_DomForwarding_ServiceType_Checkbox_XpathEU, "DOMESTIC");
                VerifyElementNotChecked(attributeName_xpath, FilterSection_Intl_ServiceType_Checkbox_XpathEU, "INTERNATIONAL");
            }
            if (TMSType == "MG")
            {
                VerifyElementNotChecked(attributeName_xpath, FilterSection_LTL_ServiceType_Checkbox_XpathEU, "LTL");
                VerifyElementNotChecked(attributeName_xpath, FilterSection_TL_ServiceType_Checkbox_XpathEU, "TRUCKLOAD");
                VerifyElementNotChecked(attributeName_xpath, FilterSection_PTL_ServiceType_Checkbox_XpathEU, "PARTIAL TRUCKLOAD");
                VerifyElementNotChecked(attributeName_xpath, FilterSection_IML_ServiceType_Checkbox_XpathEU, "INTERMODAL");

            }
            if (TMSType == "CSA")
            {
                VerifyElementNotChecked(attributeName_xpath, FilterSection_DomForwarding_ServiceType_Checkbox_XpathEU, "DOMESTIC");
                VerifyElementNotChecked(attributeName_xpath, FilterSection_Intl_ServiceType_Checkbox_XpathEU, "INTERNATIONAL");
            }
        }

        [When(@"I have created customized report(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void WhenIHaveCreatedCustomizedReport(string SeviceType, string ReportName, string Date, string OriginCity, string DestinationCity, string Status, string ReferenceNumber)
        {
            Click(attributeName_xpath, FilterSection_LTL_ServiceType_Checkbox_Xpath);
            SendKeys(attributeName_xpath, FilterSection_OriginCity_Textbox_Id, "BEVERLY");

            SendKeys(attributeName_id, FilterSection_ReportName_Text_Id,ReportName);
            Click(attributeName_id, SaveReport_ModalPopUp_Ok_button_Id);
        }

        [Then(@"Data should be filtered based on created custom report (.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void ThenDataShouldBeFilteredBasedOnCreatedCustomReport(string SeviceType, string ReportName, string Date, string OriginCity, string DestinationCity, string Status, string ReferenceNumber)
        {
            if (SeviceType != null)
            {
                IList<IWebElement> UIstaus = GlobalVariables.webDriver.FindElements(By.XPath(FilterSection_StausColumn_Xpath));
                int matchUIstausCount = 0;
                int UIstausCount = UIstaus.Count();
                for(int i=0; i< UIstausCount; i++)
                {
                    if (UIstaus[i].Text== SeviceType)
                    {
                        matchUIstausCount++;
                    }
                }
                if(UIstausCount== matchUIstausCount)
                {

                }
                else
                {

                }
            }
            if (Date != null)
            {
                IList<IWebElement> pickUpDateUI = GlobalVariables.webDriver.FindElements(By.XPath(FilterSection_PicupDateColumn_Xpath));
                int matchpickUpDateUICount = 0;
                int pickUpDateUICount = pickUpDateUI.Count();
                for (int i = 0; i < pickUpDateUICount; i++)
                {
                    if (pickUpDateUI[i].Text == SeviceType)
                    {
                        matchpickUpDateUICount++;
                    }
                }
                if (pickUpDateUICount == matchpickUpDateUICount)
                {

                }
                else
                {

                }
            }
            if (OriginCity != null)
            {
                IList<IWebElement> OriginCityUI = GlobalVariables.webDriver.FindElements(By.XPath(FilterSection_OriginAddColumn_Xpath));
                int matchOriginCityCount = 0;
                int OriginCityUICount = OriginCityUI.Count();
                for (int i = 0; i < OriginCityUICount; i++)
                {
                    if (OriginCityUI[i].Text == SeviceType)
                    {
                        matchOriginCityCount++;
                    }
                }
                if (OriginCityUICount == matchOriginCityCount)
                {

                }
                else
                {

                }

            }
            if (DestinationCity != null)
            {
                IList<IWebElement> DestinationCityUI = GlobalVariables.webDriver.FindElements(By.XPath(FilterSection_DestAddAddColumn_Xpath));
                int matchDestinationCityCount = 0;
                int DestinationCityUICount = DestinationCityUI.Count();
                for (int i = 0; i < DestinationCityUICount; i++)
                {
                    if (DestinationCityUI[i].Text == SeviceType)
                    {
                        matchDestinationCityCount++;
                    }
                }
                if (DestinationCityUICount == matchDestinationCityCount)
                {

                }
                else
                {

                }

            }
            if (Status != null)
            {
                //IList<IWebElement> pickUpDateUI = GlobalVariables.webDriver.FindElements(By.XPath(FilterSection_PicupDateColumn_Xpath));
                //int matchpickUpDateUICount = 0;
                //int pickUpDateUICount = pickUpDateUI.Count();
                //for (int i = 0; i < pickUpDateUICount; i++)
                //{
                //    if (pickUpDateUI[i].Text == SeviceType)
                //    {
                //        matchpickUpDateUICount++;
                //    }
                //}
                //if (pickUpDateUICount == matchpickUpDateUICount)
                //{

                //}
                //else
                //{

                //}


            }
            
           
        }

        [Then(@"Created report should be available in report drop down under custom report section(.*)")]
        public void ThenCreatedReportShouldBeAvailableInReportDropDownUnderCustomReportSection(string ReportName)
        {
            CreatedCustomReport = DBHelper._checkDuplicate_CustomReportName(ReportName);
            SendKeys(attributeName_id, NameThisReport_Textbox_Id, CreatedCustomReport);
            Click(attributeName_xpath, SaveReport_ModalPopUp_Ok_button_Xpath);

            Thread.Sleep(5000);

            //Verifying created report is available in drop down or not
            Click(attributeName_xpath, ShipmentList_FilteredReports_Xpath);
            SendKeys(attributeName_xpath, SelectAReportSearchBoxnShipmentList_Xpath, CreatedCustomReport);

            string ActualTextUI = Gettext(attributeName_xpath, "//*[@id='ReportType_chosen']/div/ul/li[2]");

            Assert.AreEqual(CreatedCustomReport, ActualTextUI);
        }

        [When(@"I given duplicate filter report name(.*)")]
        public void WhenIGivenDuplicateFilterReportName(string ReportName)
        {
           // Click(attributeName_xpath, ShipmentList_ShowFilters_Xpath);
            Click(attributeName_id, FilterSection_SaveReport_button_Id);
            SendKeys(attributeName_id, FilterSection_ReportName_Text_Id,ReportName);
            Click(attributeName_xpath, "//*[@id='Save-Report']/div/div/div[1]/h2");
            Click(attributeName_id, SaveReport_ModalPopUp_Ok_button_Id);
           

        }

        [Then(@"I will be presented with error message")]
        public void ThenIWillBePresentedWithErrorMessage()
        {
            string ActualTextUI = Gettext(attributeName_id, SaveReport_ModalPopUp_warning_message_Id);
            string expectedWarningMSG = "GIVEN REPORT NAME ALREADY EXISTS, PLEASE ENTER NEW REPORT NAME.";
            Assert.AreEqual(expectedWarningMSG, ActualTextUI);
        }


    }
}
