using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.Common;
using CRM.UITest.Helper.DataModels;
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
using System.Text;
using System.Xml.Linq;
using TechTalk.SpecFlow;
using CRM.UITest.Helper.ViewModel.Shipment;
using CRM.UITest.Helper.Interfaces.Shipment;
using CRM.UITest.CsaServiceReference;
using CRM.UITest.CommonMethods;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Results
{
    [Binding]
    public  class ShipmentResults_LTL_Backbuttons_AllUsersSteps : AddShipments
    {
        private string errorMessage;
        CommonMethodsCrm crm = new CommonMethodsCrm();
        [Given(@"I am a operations, sales, sales management or station user (.*) (.*)")]
        public void GivenIAmAOperationsSalesSalesManagementOrStationUser(string Username, string Password)
        {
            crm.LoginToCRMApplication(Username, Password);
        }

    

        [When(@"I am navigated to the Shipment Results LTL page")]
        public void WhenIAmNavigatedToTheShipmentResultsLTLPage()
        {
            Report.WriteLine("I am on the Shipment Result Page ");
            VerifyElementPresent(attributeName_xpath, ShipResults_PageHeaderText_xpath, "Shipment Results LTL");
        }

        [Then(@"I will see the (.*) and (.*) button")]
        public void ThenIWillSeeTheAndButton(string Back_to_AddShipment, string Back_to_ShipmentList)
        {
            Report.WriteLine("I will see the Back to Add Shipment and Back to Shipment List Button on Shipment Result LTL Page");
            string Actual_Back_To_AddShipment = Gettext(attributeName_id, ShipResults_Back_To_AddShipment_Button_Id);
            Assert.AreEqual(Back_to_AddShipment, Actual_Back_To_AddShipment);

            string Actual_Back_To_ShipmentList = Gettext(attributeName_id, ShipResults_Back_To_ShipmentList_Button_Id);
            Assert.AreEqual(Back_to_ShipmentList, Actual_Back_To_ShipmentList);

        }

        [When(@"I click on Back to Add Shipment button")]
        public void WhenIClickOnBackToAddShipmentButton()
        {
            Report.WriteLine("I click on Back to Add Shipment Button");
            Click(attributeName_id, ShipResults_Back_To_AddShipment_Button_Id);
                
        }

        [Then(@"I must be arrive on Add Shipment LTL page")]
        public void ThenIMustBeArriveOnAddShipmentLTLPage()
        {
            Report.WriteLine("I am navigated to the Add Shipment LTL page ");
            VerifyElementPresent(attributeName_xpath, AddShipment_PageTitle_xpath, "Add Shipment LTL Page");

        }
       

        [Then(@"Verified previously entered information on Add shipment LTL Page will be displayed (.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void ThenVerifiedPreviouslyEnteredInformationOnAddShipmentLTLPageWillBeDisplayed(string originName, string originAddr1, string originZipcode, string destinationName, string destinationAddr1, string destinationZipcode, string Classification, string nmfc, string quantity, string weight, string itemdesc)
        {
            Report.WriteLine("I verifiy all previously entered information on Add Shipment page will be display");

            string Actual_LocationName_ShippingFrom = GetValue(attributeName_id, ShippingFrom_LocationName_Id, "value");
            string Actual_LocationAddress_ShippingFrom = GetValue(attributeName_id, ShippingFrom_LocationAddressLine1_Id, "value");
            string Actual_OriginZip_ShippingFrom = GetValue(attributeName_id, ShippingFrom_zipcode_Id, "value");
            string Actual_LocationName_ShippingTo = GetValue(attributeName_id, ShippingTo_LocationName_Id, "value");
            string Actual_LocationAddress_ShippingTo = GetValue(attributeName_id, ShippingTo_LocationAddressLine1_Id, "value");
            string Actual_DestinationZip_ShippingTo = GetValue(attributeName_id, ShippingTo_zipcode_Id, "value");
            string Actual_Classification = GetValue(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id, "value");
            string Actual_NMFC = GetValue(attributeName_id, FreightDesp_FirstItem_NMFC_Id, "value");
            string Actual_Quantity = GetValue(attributeName_id, FreightDesp_FirstItem_Quantity_Id, "value");
            string Actual_ItemDescription = GetValue(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id, "value");
            string Actual_Weight = GetValue(attributeName_id, FreightDesp_FirstItem_Weight_Id, "value");

            Assert.AreEqual(originName, Actual_LocationName_ShippingFrom);
            Assert.AreEqual(originAddr1, Actual_LocationAddress_ShippingFrom);
            Assert.AreEqual(originZipcode, Actual_OriginZip_ShippingFrom);
            Assert.AreEqual(destinationName, Actual_LocationName_ShippingTo);
            Assert.AreEqual(destinationAddr1, Actual_LocationAddress_ShippingTo);
            Assert.AreEqual(destinationZipcode, Actual_DestinationZip_ShippingTo);
            Assert.AreEqual(Classification, Actual_Classification);
            Assert.AreEqual(nmfc, Actual_NMFC);
            Assert.AreEqual(quantity, Actual_Quantity);
            Assert.AreEqual(itemdesc, Actual_ItemDescription);
            Assert.AreEqual(weight, Actual_Weight);
        }



       
        [When(@"I click on Back to Shipment List button")]
        public void WhenIClickOnBackToShipmentListButton()
        {
            Report.WriteLine("I click on Back to Shipment List Button");

            Click(attributeName_id, ShipResults_Back_To_ShipmentList_Button_Id);
        }

        [Then(@"I must be arrive to the Shipment List page")]
        public void ThenIMustBeArriveToTheShipmentListPage()
        {
            Report.WriteLine("I must be navigated to the Shipment List Page");
            VerifyElementPresent(attributeName_xpath, ShipmentList_title_Xpath, "Shipment List");
        }

        [Then(@"Previously selected (.*) must be display in customer list")]
        public void ThenPreviouslySelectedMustBeDisplayInCustomerList(string CustomerName)
        {
            Report.WriteLine("Customer is Bydefault selected as previously selected from dropdown");
            string ActualCustomer_Name = Gettext(attributeName_xpath, AllCustomerDropdown_Selection_Internal_Xpath);
            bool CustomerSelected = ActualCustomer_Name.Contains(CustomerName);
            if(CustomerSelected == true)
            {
                Report.WriteLine("Customer is displaying in the dropdown box");
            }
            else
            {
                Report.WriteLine("Customer is not Displaying");
            }
        }

        [Then(@"The Shipment List will be shows default to the previous Thirty days shipment data (.*),(.*)")]
        public void ThenTheShipmentListWillBeShowsDefaultToThePreviousThirtyDaysShipmentData(string Account, string option)
        {
            int row = GetCount(attributeName_xpath, ShipmentList_GridNoResultsfound_Xpath);
            if (row >= 1)
            {

                Report.WriteLine("Selecting value from view dropdown");
                SelectDropdownlistvalue(attributeName_xpath, ShipmentList_TopGrid_ViewDropdownValues_Xpath, option);

                int accID = DBHelper.GetAccountIdforAccountName(Account);
                CustomerSetup value = DBHelper.GetSetupDetails(accID);

                // Building request xml
                ListScreenExtractRequestXML data = new ListScreenExtractRequestXML();
                XElement reqXML = data.GetRequestXMLForShipmentListExternalUser(value.MgAccountNumber, "CRM-ShpPrev30DaysAgent", Account);

                //Building Client
                BuildHttpClient client = new BuildHttpClient();
                HttpClient headers = client.BuildHttpClientWithHeaders(Account, "application/xml");


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
            else
            {
                Report.WriteLine("No Record found");
            }

        }


        [Then(@"The Shipment list will display shipments from the previous Thirty days for the customer selected (.*) (.*)")]
        public void ThenTheShipmentListWillDisplayShipmentsFromThePreviousThirtyDaysForTheCustomerSelected(string CustomerName, string Option)
        {
            int row = GetCount(attributeName_xpath, ShipmentList_GridNoResultsfound_Xpath);
            if (row >= 1)
            {
                Report.WriteLine("Selecting value from view dropdown");
                SelectDropdownlistvalue(attributeName_xpath, ShipmentList_TopGrid_ViewDropdownValues_Xpath, Option);


                List<String> ShipList = new List<string>();
                int accID = DBHelper.GetAccountIdforAccountName(CustomerName);
                CustomerSetup value = DBHelper.GetSetupDetails(accID);

                // Building request xml
                ListScreenExtractRequestXML data = new ListScreenExtractRequestXML();
                XElement reqXML = data.GetRequestXMLForShipmentListStationUser(value.MgAccountNumber, "CRM-ShpPrev30DaysAgent");

                //Building Client
                BuildHttpClient client = new BuildHttpClient();
                HttpClient headers = client.BuildHttpClientWithHeaders("Admin", "application/xml");


                string uri = $"MercuryGate/ListScreenExtract";
                ShipmentListScreen Slist = new ShipmentListScreen();
                List<Helper.ViewModel.Shipment.ShipmentListViewModel> Sdata = Slist.CallListScreen(uri, headers, reqXML);

                if (Sdata != null)
                {
                    for (int j = 1; j < Sdata.Count; j++)
                    {
                        ShipList.Add(Sdata[j].PrimaryReference);
                    }
                }
                else
                {
                    Report.WriteLine("Not received any reposnse from API for Station ID: " + value.MgAccountNumber);
                }

                CustomerAccount valued = DBHelper.GetAccountDetails(accID);
                int csaNumb = Convert.ToInt32(valued.CsaCustomerNumber);

                ICsaShipmentListByLast30Days CSAShip = new CsaShipmentListByLast30Days();
                ShipmentListReponse APIShipments = CSAShip.GetCsaShipmentListByLast30Days(csaNumb, out errorMessage);
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
                    Report.WriteLine("Data not found for the CSA station account number" + csaNumb);
                }

                IList<IWebElement> UIShipments = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentListGrid_RefNumAllValues_Xpath));
                List<string> UIValue = new List<string>();

                if (ShipList.Count > 1)
                {

                    for (int k = 0; k < UIShipments.Count; k++)
                    {
                        string UIShipNumber = UIShipments[k].Text;
                        UIValue.Add(UIShipNumber);
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
            else
            {
                Report.WriteLine("No Record Found");
            }

        }




    }
}
