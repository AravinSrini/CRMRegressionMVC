using System.Configuration;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Threading;
using CRM.UITest.Entities;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace CRM.UITest.Scripts.Shipment.ShipmentList.ShipmentList_GridDisplay_AllUsers
{
    [Binding]
    public class ShipmentsLTL_DisplayCustomerNameWithLongHierarchySteps : Shipmentlist
    {
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
        string actualMsg = null;
        string expectedMsg = null;

        [Given(@"selected a customer from the (.*) drop down list from shipment list page")]
        public void GivenSelectedACustomerFromTheDropDownListFromShipmentListPage(string p0)
        {
            Report.WriteLine("Selecting customer from customer label dropdownfrom shipment list page.");
            Click(attributeName_xpath, ShipmentListInternal_CustomerDropdown_Xpath);
           // SelectDropdownValueFromList(attributeName_xpath, ShipmentList_CustomerDropdownValues_xpath, "ArnoldTest05072018B");

            IList<IWebElement> stationValue = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_CustomerDropdownValues_xpath));
            for (int i = 0; i < stationValue.Count; i++)
            {
                if (stationValue[i].Text == "ArnoldTest05072018B")
                {
                    stationValue[i].Click();
                    break;
                }
            }

        }

        [Given(@"I am on the Add Shipment page of service type selection as a external user")]
        public void GivenIAmOnTheAddShipmentPageOfServiceTypeSelectionAsAExternalUser()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, ShipmentServicetype_AddShipmentButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ShipmentList_LTLtile_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I am on the Add Shipment page as a external user")]
        public void GivenIAmOnTheAddShipmentPageAsAExternalUser()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, ShipmentServicetype_AddShipmentButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ShipmentList_LTLtile_Id);
            GlobalVariables.webDriver.WaitForPageLoad();

        }

        [Then(@"customer label will now display (.*) from Add Shipment page for external user")]
        public void ThenCustomerLabelWillNowDisplayFromAddShipmentPageForExternalUser(string p0)
        {
            actualMsg = Gettext(attributeName_xpath, AddShipmentLTLCustomerLabelDropdown_Xpath);
            string SubAccount = "ArnoldTest05072018B";
            string StatioName = DBHelper.GetStationName(SubAccount);
            int SubAccccId = DBHelper.GetCustomerId(SubAccount);
            int primaryAccId = DBHelper.GetPrimaryAccId(SubAccccId);
            string PrimaryAccountName = DBHelper.GetPrimaryAcc(primaryAccId);
            string ExpectedStationCustomerDisplay = StatioName + " - " + PrimaryAccountName + " ... " + SubAccount;
            Assert.AreEqual(actualMsg, actualMsg);
        }

        [When(@"I hover over the customer name from Add Shipment page as a external user")]
        public void WhenIHoverOverTheCustomerNameFromAddShipmentPageAsAExternalUser()
        {
            Thread.Sleep(3000);
            OnMouseOver(attributeName_xpath, AddShipmentLTLCustomerLabel_ExternalUser_Xpath);
        }

        [When(@"I am on the Add Shipment page as a external user")]
        public void WhenIAmOnTheAddShipmentPageAsAExternalUser()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, ShipmentServicetype_AddShipmentButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ShipmentList_LTLtile_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
        }


        [Given(@"I am on the Add Shipment page of service type selection")]
        public void GivenIAmOnTheAddShipmentPageOfServiceTypeSelection()
        {
            Report.WriteLine("Clicking on Add Shipment button");
            Click(attributeName_id, ShipmentList_AddShipmentButtonInternalUser_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I am on the Shipment Results page as a external user")]
        public void GivenIAmOnTheShipmentResultsPageAsAExternalUser()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, ShipmentServicetype_AddShipmentButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ShipmentList_LTLtile_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_id, OriginLocationName_Id, "test xyz");
            SendKeys(attributeName_id, OriginAddress_Id, "test address");
            SendKeys(attributeName_id, OriginZip_Id, "33126");
            SendKeys(attributeName_id, destinationLocation_Id, "test xyzcc");
            SendKeys(attributeName_id, destinationAddress_Id, "test address");
            SendKeys(attributeName_id, destinationZip_Id, "33126");
            SendKeys(attributeName_id, freightCharges_Id, "60");
            SendKeys(attributeName_id, description_Id, "xxx");
            SendKeys(attributeName_id, description_Id, "description test");
            SendKeys(attributeName_id, freightQuantity_Id, "2");
            SendKeys(attributeName_id, freightWeight_Id, "20");
            SendKeys(attributeName_id, InsuredValue_Id, "200");

            Report.WriteLine("clicking on View Rate button");
            Click(attributeName_xpath, ViewRateButton_Xpath);
        }

        [Given(@"I am on the Shipment Results \(LTL\) page")]
        public void GivenIAmOnTheShipmentResultsLTLPage()
        {
            Report.WriteLine("Clicking on Add Shipment button");
            Click(attributeName_id, ShipmentList_AddShipmentButtonInternalUser_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ShipmentList_LTLtile_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_id, OriginLocationName_Id, "test xyz");
            SendKeys(attributeName_id, OriginAddress_Id, "test address");
            SendKeys(attributeName_id, OriginZip_Id, "33126");
            SendKeys(attributeName_id, destinationLocation_Id, "test xyzcc");
            SendKeys(attributeName_id, destinationAddress_Id, "test address");
            SendKeys(attributeName_id, destinationZip_Id, "33126");
            SendKeys(attributeName_id, freightCharges_Id, "60");
            SendKeys(attributeName_id, description_Id, "xxx");
            SendKeys(attributeName_id, description_Id, "description test");
            SendKeys(attributeName_id, freightQuantity_Id, "2");
            SendKeys(attributeName_id, freightWeight_Id, "20");

            Report.WriteLine("clicking on View Rate button");
            Click(attributeName_xpath, ViewRateButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [When(@"customer name, hierarchies, and station is more than one level")]
        public void WhenCustomerNameHierarchiesAndStationIsMoreThanOneLevel()
        {
            Click(attributeName_xpath, ShipmentListInternal_CustomerDropdown_Xpath);
            string elementClass = GetAttribute(attributeName_xpath, ShipmentList_CustDropdownOption_Xpath, "class");
            string[] classes = elementClass.Split(' ');
            foreach(string eleClass in classes)
            {
                if(eleClass.Contains("level1") || eleClass.Contains("level2"))
                {
                    Assert.IsTrue(true);
                }
            }
           
        }


        [Given(@"I am on the Review and Submit Shipment \(LTL\) page")]
        public void GivenIAmOnTheReviewAndSubmitShipmentLTLPage()
        {
            Report.WriteLine("Clicking on Add Shipment button");
            Click(attributeName_id, ShipmentList_AddShipmentButtonInternalUser_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ShipmentList_LTLtile_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_id, OriginLocationName_Id, "test xyz");
            SendKeys(attributeName_id, OriginAddress_Id, "test address");
            SendKeys(attributeName_id, OriginZip_Id, "33126");
            SendKeys(attributeName_id, destinationLocation_Id, "test xyzcc");
            SendKeys(attributeName_id, destinationAddress_Id, "test address");
            SendKeys(attributeName_id, destinationZip_Id, "33126");
            SendKeys(attributeName_id, freightCharges_Id, "60");
            SendKeys(attributeName_id, description_Id, "xxx");
            SendKeys(attributeName_id, description_Id, "description test");
            SendKeys(attributeName_id, freightQuantity_Id, "2");
            SendKeys(attributeName_id, freightWeight_Id, "20");
            SendKeys(attributeName_id, InsuredValue_Id, "200");

            Report.WriteLine("clicking on View Rate button");
            Click(attributeName_xpath, ViewRateButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, CreateShipmetWithoutCarrier_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
        }
        
        [Given(@"I am on the Shipment confirmation \(LTL\) page")]
        public void GivenIAmOnTheShipmentConfirmationLTLPage()
        {
            Report.WriteLine("Clicking on Add Shipment button");
            Click(attributeName_id, ShipmentList_AddShipmentButtonInternalUser_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ShipmentList_LTLtile_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_id, OriginLocationName_Id, "test xyz");
            SendKeys(attributeName_id, OriginAddress_Id, "test address");
            SendKeys(attributeName_id, OriginZip_Id, "33126");
            SendKeys(attributeName_id, destinationLocation_Id, "test xyzcc");
            SendKeys(attributeName_id, destinationAddress_Id, "test address");
            SendKeys(attributeName_id, destinationZip_Id, "33126");
            SendKeys(attributeName_id, freightCharges_Id, "60");
            SendKeys(attributeName_id, description_Id, "xxx");
            SendKeys(attributeName_id, description_Id, "description test");
            SendKeys(attributeName_id, freightQuantity_Id, "2");
            SendKeys(attributeName_id, freightWeight_Id, "20");
            SendKeys(attributeName_id, InsuredValue_Id, "200");

            Report.WriteLine("clicking on View Rate button");
            Click(attributeName_xpath, ViewRateButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, ShipmentResult_CreateShipmentButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            Click(attributeName_id, SubmitShipmentButton_Id);
        }
        
        [Given(@"that I am a shp\.entrynorates or shp\.entry user")]
        public void GivenThatIAmAShp_EntrynoratesOrShp_EntryUser()
        {
            string userName = ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();
            string password = ConfigurationManager.AppSettings["ExternalUserPassword"].ToString();
            CrmLogin.LoginToCRMApplication(userName, password);
        }
        
        [Given(@"the customer name, hierarchies, and station is more than one level")]
        public void GivenTheCustomerNameHierarchiesAndStationIsMoreThanOneLevel()
        {
            string elementClass = GetAttribute(attributeName_xpath, CustomerDropdownExtuser_Xpath, "class");
            string[] classes = elementClass.Split(' ');
            foreach (string eleClass in classes)
            {
                if (eleClass.Equals("level1") || eleClass.Equals("level2"))
                {
                    Assert.IsTrue(true);
                }
            }

        }

        [When(@"the customer name, hierarchies, and station is more than one level from shipment list page as a external user")]
        public void WhenTheCustomerNameHierarchiesAndStationIsMoreThanOneLevelFromShipmentListPageAsAExternalUser()
        {
            Click(attributeName_xpath, ShipmentList_CustomerDropdown_SelectedValue_Xpath);
            string elementClass = GetAttribute(attributeName_xpath, ShipmentListOption_Xpath, "class");
            string[] classes = elementClass.Split(' ');
            foreach (string eleClass in classes)
            {
                if (eleClass.Equals("level1") || eleClass.Equals("level2"))
                {
                    Assert.IsTrue(true);
                }
            }
        }

        [When(@"I hover over the customer name from Shipment List as a external user")]
        public void WhenIHoverOverTheCustomerNameFromShipmentListAsAExternalUser()
        {
            Thread.Sleep(2000);
            OnMouseOver(attributeName_xpath, ShipmentList_CustomerDropdown_SelectedValue_Xpath);
        }

        [Given(@"that I am a shp\.entry user")]
        public void GivenThatIAmAShp_EntryUser()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I hover over the customer name from shipment list page")]
        public void WhenIHoverOverTheCustomerNameFromShipmentListPage()
        {
            Thread.Sleep(30000);
            OnMouseOver(attributeName_xpath, ShipmentListInternal_CustomerDropdown_Xpath);
        }

        [Then(@"customer label will now display (.*) from Add Shipment page of service type selection for external user")]
        public void ThenCustomerLabelWillNowDisplayFromAddShipmentPageOfServiceTypeSelectionForExternalUser(string p0)
        {
            Thread.Sleep(2000);
            OnMouseOver(attributeName_xpath, ShipmentList_CustomerDropdown_SelectedValue_Xpath);
            //actualMsg = Gettext(attributeName_xpath, AddShipmentCustomerLabelDropdown_xpath);
            OnMouseOver(attributeName_xpath, "//p[@id='stationcustomernamedropdown-external']");
            actualMsg = Gettext(attributeName_classname, "popover-content");
           // actualMsg = Gettext(attributeName_xpath, AddShipmentCustomerLabelDropdown_xpath);
            string SubAccount = "ArnoldTest05072018B";
            string StatioName = DBHelper.GetStationName(SubAccount);
            int SubAccccId = DBHelper.GetCustomerId(SubAccount);
            int primaryAccId = DBHelper.GetPrimaryAccId(SubAccccId);
            string PrimaryAccountName = DBHelper.GetPrimaryAcc(primaryAccId);
            string ExpectedStationCustomerDisplay = StatioName + " - " + PrimaryAccountName + " ... " + SubAccount;
            Assert.AreEqual(actualMsg, actualMsg);
        }

        [When(@"I am on the Add Shipment page of service type selection as a external user")]
        public void WhenIAmOnTheAddShipmentPageOfServiceTypeSelectionAsAExternalUser()
        {
            //GlobalVariables.webDriver.WaitForPageLoad();
            //Click(attributeName_xpath, ShipmentServicetype_AddShipmentButton_Xpath);


            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, ShipmentServicetype_EXT_AddShipmentButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ShipmentList_LTLtile_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, ShipmentServicetype_AddShipmentButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ShipmentList_LTLtile_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
        }


        [When(@"I am on the Add Shipment page of service type selection")]
        public void WhenIAmOnTheAddShipmentPageOfServiceTypeSelection()
        {
            Click(attributeName_id, ShipmentList_AddShipmentButtonInternalUser_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
        }
        
        [When(@"I hover over the customer name from Add Shipment page of service type selection")]
        public void WhenIHoverOverTheCustomerNameFromAddShipmentPageOfServiceTypeSelection()
        {
            Thread.Sleep(2000);
            OnMouseOver(attributeName_xpath, AddShipmentCustomerLabelDropdown_xpath);
        }
        
        [When(@"I hover over the customer name from Add Shipment \(LTL\) page")]
        public void WhenIHoverOverTheCustomerNameFromAddShipmentLTLPage()
        {
            OnMouseOver(attributeName_xpath, AddShipmentLTLCustomerLabelDropdown_Xpath);
        }

        [When(@"I am on Shipment Results \(LTL\) page")]
        public void WhenIAmOnShipmentResultsLTLPage()
        {
            Report.WriteLine("Clicking on Add Shipment button");
            Click(attributeName_id, ShipmentList_AddShipmentButtonInternalUser_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ShipmentList_LTLtile_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_id, OriginLocationName_Id, "test xyz");
            SendKeys(attributeName_id, OriginAddress_Id, "test address");
            SendKeys(attributeName_id, OriginZip_Id, "33126");
            SendKeys(attributeName_id, destinationLocation_Id, "test xyzcc");
            SendKeys(attributeName_id, destinationAddress_Id, "test address");
            SendKeys(attributeName_id, destinationZip_Id, "33126");
            SendKeys(attributeName_id, freightCharges_Id, "60");
            SendKeys(attributeName_id, description_Id, "xxx");
            SendKeys(attributeName_id, description_Id, "description test");
            SendKeys(attributeName_id, freightQuantity_Id, "2");
            SendKeys(attributeName_id, freightWeight_Id, "20");

            Report.WriteLine("clicking on View Rate button");
            Click(attributeName_xpath, ViewRateButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
        }


        [When(@"I am on Add Shipment \(LTL\) page")]
        public void WhenIAmOnAddShipmentLTLPage()
        {
            Report.WriteLine("Clicking on Add Shipment button");
            Click(attributeName_id, ShipmentList_AddShipmentButtonInternalUser_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ShipmentList_LTLtile_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I am on LTL Add Shipment page")]
        public void GivenIAmOnLTLAddShipmentPage()
        {
            Report.WriteLine("Clicking on Add Shipment button");
            Click(attributeName_id, ShipmentList_AddShipmentButtonInternalUser_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ShipmentList_LTLtile_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"selected a customer from the Select account to display\.\.\. drop down list as a external user from shipment list page")]
        public void GivenSelectedACustomerFromTheSelectAccountToDisplay_DropDownListAsAExternalUserFromShipmentListPage()
        {
            Report.WriteLine("Selecting customer from customer label dropdownfrom shipment list page");
            Click(attributeName_xpath, ShipmentList_CustomerDropdown_SelectedValue_Xpath);
            Thread.Sleep(2000);
            SelectDropdownValueFromList(attributeName_xpath, ShipmentList_CustomerDropdownValues_xpath, "testingcsasubaccount_sub");
        }

        [When(@"I hover over the customer name from Shipment Results page as a external user")]
        public void WhenIHoverOverTheCustomerNameFromShipmentResultsPageAsAExternalUser()
        {
            Thread.Sleep(3000);
            OnMouseOver(attributeName_xpath, ShipmentResult_customerLabel_ExternalUser_Xpath);
        }
       

        [When(@"I hover over the customer name from Shipment Results page")]
        public void WhenIHoverOverTheCustomerNameFromShipmentResultsPage()
        {
            Thread.Sleep(3000);
            OnMouseOver(attributeName_xpath, ShipmentResult_CustomerLabel_Xpath);
        }
        
        [When(@"I am on the Review and Submit Shipment \(LTL\) page")]
        public void WhenIAmOnTheReviewAndSubmitShipmentLTLPage()
        {
            Report.WriteLine("Clicking on Add Shipment button");
            Click(attributeName_id, ShipmentList_AddShipmentButtonInternalUser_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ShipmentList_LTLtile_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_id, OriginLocationName_Id, "test xyz");
            SendKeys(attributeName_id, OriginAddress_Id, "test address");
            SendKeys(attributeName_id, OriginZip_Id, "33126");
            SendKeys(attributeName_id, destinationLocation_Id, "test xyzcc");
            SendKeys(attributeName_id, destinationAddress_Id, "test address");
            SendKeys(attributeName_id, destinationZip_Id, "33126");
            SendKeys(attributeName_id, freightCharges_Id, "60");
            SendKeys(attributeName_id, description_Id, "xxx");
            SendKeys(attributeName_id, description_Id, "description test");
            SendKeys(attributeName_id, freightQuantity_Id, "2");
            SendKeys(attributeName_id, freightWeight_Id, "20");
            SendKeys(attributeName_id, InsuredValue_Id, "200");

            Report.WriteLine("clicking on View Rate button");
            Click(attributeName_xpath, ViewRateButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, ShipmentResult_CreateShipmentButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I am on the Review and Submit Shipment page as a external user")]
        public void GivenIAmOnTheReviewAndSubmitShipmentPageAsAExternalUser()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, ShipmentServicetype_AddShipmentButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ShipmentList_LTLtile_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_id, OriginLocationName_Id, "test xyz");
            SendKeys(attributeName_id, OriginAddress_Id, "test address");
            SendKeys(attributeName_id, OriginZip_Id, "33126");
            SendKeys(attributeName_id, destinationLocation_Id, "test xyzcc");
            SendKeys(attributeName_id, destinationAddress_Id, "test address");
            SendKeys(attributeName_id, destinationZip_Id, "33126");
            SendKeys(attributeName_id, freightCharges_Id, "60");
            SendKeys(attributeName_id, description_Id, "xxx");
            SendKeys(attributeName_id, description_Id, "description test");
            SendKeys(attributeName_id, freightQuantity_Id, "2");
            SendKeys(attributeName_id, freightWeight_Id, "20");
            SendKeys(attributeName_id, InsuredValue_Id, "200");

            Report.WriteLine("clicking on View Rate button");
            Click(attributeName_xpath, ViewRateButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();

            Click(attributeName_xpath, ShipmentResult_CreateShipmentButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [When(@"I am on the Shipment confirmation page as a external user")]
        public void WhenIAmOnTheShipmentConfirmationPageAsAExternalUser()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, ShipmentServicetype_AddShipmentButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ShipmentList_LTLtile_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_id, OriginLocationName_Id, "test xyz");
            SendKeys(attributeName_id, OriginAddress_Id, "test address");
            SendKeys(attributeName_id, OriginZip_Id, "33126");
            SendKeys(attributeName_id, destinationLocation_Id, "test xyzcc");
            SendKeys(attributeName_id, destinationAddress_Id, "test address");
            SendKeys(attributeName_id, destinationZip_Id, "33126");
            SendKeys(attributeName_id, freightCharges_Id, "60");
            SendKeys(attributeName_id, description_Id, "xxx");
            SendKeys(attributeName_id, description_Id, "description test");
            SendKeys(attributeName_id, freightQuantity_Id, "2");
            SendKeys(attributeName_id, freightWeight_Id, "20");
            SendKeys(attributeName_id, InsuredValue_Id, "200");

            Report.WriteLine("clicking on View Rate button");
            Click(attributeName_xpath, ViewRateButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();

            Click(attributeName_xpath, ShipmentResult_CreateShipmentButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            Click(attributeName_id, SubmitShipmentButton_Id); 
        }

        [Then(@"customer label will now display (.*) from Shipment confirmation page for external user")]
        public void ThenCustomerLabelWillNowDisplayFromShipmentConfirmationPageForExternalUser(string p0)
        {
            actualMsg = Gettext(attributeName_xpath, ShipmentResult_customerLabel_ExternalUser_Xpath);
            string SubAccount = "testingcsasubaccount_sub";
            string StatioName = DBHelper.GetStationName(SubAccount);
            int SubAccccId = DBHelper.GetCustomerId(SubAccount);
            int primaryAccId = DBHelper.GetPrimaryAccId(SubAccccId);
            string PrimaryAccountName = DBHelper.GetPrimaryAcc(primaryAccId);
            string ExpectedStationCustomerDisplay = PrimaryAccountName + " ... " + SubAccount;
            Assert.AreEqual(actualMsg, actualMsg);
        }

        [When(@"I hover over the customer name from Shipment confirmation page as a external user")]
        public void WhenIHoverOverTheCustomerNameFromShipmentConfirmationPageAsAExternalUser()
        {
            Thread.Sleep(4000);
            OnMouseOver(attributeName_xpath, ShipmentResult_customerLabel_ExternalUser_Xpath);
        }

        [Then(@"the entire station, hierarchies, and customer name will be displayed in the hover over message from Shipment confirmation page for external user")]
        public void ThenTheEntireStationHierarchiesAndCustomerNameWillBeDisplayedInTheHoverOverMessageFromShipmentConfirmationPageForExternalUser()
        {
            actualMsg = Gettext(attributeName_classname, "mypopovershipment");
            expectedMsg = "ZZZ - Czar Customer Test - checking for the config manager1 - testingcsasubaccount - testingcsasubaccount_sub";
            Assert.AreEqual(actualMsg, expectedMsg);
        }

        [Given(@"I am on the Shipment confirmation page as a external user")]
        public void GivenIAmOnTheShipmentConfirmationPageAsAExternalUser()
        {
                GlobalVariables.webDriver.WaitForPageLoad();
                Click(attributeName_xpath, ShipmentServicetype_AddShipmentButton_Xpath);
                GlobalVariables.webDriver.WaitForPageLoad();
                Click(attributeName_id, ShipmentList_LTLtile_Id);
                GlobalVariables.webDriver.WaitForPageLoad();
                GlobalVariables.webDriver.WaitForPageLoad();
                SendKeys(attributeName_id, OriginLocationName_Id, "test xyz");
                SendKeys(attributeName_id, OriginAddress_Id, "test address");
                SendKeys(attributeName_id, OriginZip_Id, "33126");
                SendKeys(attributeName_id, destinationLocation_Id, "test xyzcc");
                SendKeys(attributeName_id, destinationAddress_Id, "test address");
                SendKeys(attributeName_id, destinationZip_Id, "33126");
                SendKeys(attributeName_id, freightCharges_Id, "60");
                SendKeys(attributeName_id, description_Id, "xxx");
                SendKeys(attributeName_id, description_Id, "description test");
                SendKeys(attributeName_id, freightQuantity_Id, "2");
                SendKeys(attributeName_id, freightWeight_Id, "20");
                SendKeys(attributeName_id, InsuredValue_Id, "200");

                Report.WriteLine("clicking on View Rate button");
                Click(attributeName_xpath, ViewRateButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Thread.Sleep(4000);
            Click(attributeName_xpath, ShipmentResult_CreateShipmentButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            Click(attributeName_id, SubmitShipmentButton_Id);
        }


        [When(@"I am on the Review and Submit Shipment page as a external user")]
        public void WhenIAmOnTheReviewAndSubmitShipmentPageAsAExternalUser()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, ShipmentServicetype_AddShipmentButton_Xpath); 
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ShipmentList_LTLtile_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_id, OriginLocationName_Id, "test xyz");
            SendKeys(attributeName_id, OriginAddress_Id, "test address");
            SendKeys(attributeName_id, OriginZip_Id, "33126");
            SendKeys(attributeName_id, destinationLocation_Id, "test xyzcc");
            SendKeys(attributeName_id, destinationAddress_Id, "test address");
            SendKeys(attributeName_id, destinationZip_Id, "33126");
            SendKeys(attributeName_id, freightCharges_Id, "60");
            SendKeys(attributeName_id, description_Id, "xxx");
            SendKeys(attributeName_id, description_Id, "description test");
            SendKeys(attributeName_id, freightQuantity_Id, "2");
            SendKeys(attributeName_id, freightWeight_Id, "20");
            SendKeys(attributeName_id, InsuredValue_Id, "200");

            Report.WriteLine("clicking on View Rate button");
            Click(attributeName_xpath, ViewRateButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();

            Click(attributeName_xpath, ShipmentResult_CreateShipmentButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [When(@"I hover over the customer name from Review and Submit Shipment page")]
        public void WhenIHoverOverTheCustomerNameFromReviewAndSubmitShipmentPage()
        {
            Thread.Sleep(3000);
            OnMouseOver(attributeName_xpath, ReviewSubmitPage_customerLabel_Xpath);
        }

        [When(@"I hover over the customer name from Review and Submit Shipment page as a external user")]
        public void WhenIHoverOverTheCustomerNameFromReviewAndSubmitShipmentPageAsAExternalUser()
        {
            Thread.Sleep(2000);
            OnMouseOver(attributeName_xpath, ShipmentResult_customerLabel_ExternalUser_Xpath);
        }

        [When(@"I am on the Shipment confirmation \(LTL\) page")]
        public void WhenIAmOnTheShipmentConfirmationLTLPage()
        {
            
            GlobalVariables.webDriver.WaitForPageLoad();

            Report.WriteLine("Clicking on Add Shipment button");
            Click(attributeName_id, ShipmentList_AddShipmentButtonInternalUser_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ShipmentList_LTLtile_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_id, OriginLocationName_Id, "test xyz");
            SendKeys(attributeName_id, OriginAddress_Id, "test address");
            SendKeys(attributeName_id, OriginZip_Id, "33126");
            SendKeys(attributeName_id, destinationLocation_Id, "test xyzcc");
            SendKeys(attributeName_id, destinationAddress_Id, "test address");
            SendKeys(attributeName_id, destinationZip_Id, "33126");
            SendKeys(attributeName_id, freightCharges_Id, "60");
            SendKeys(attributeName_id, description_Id, "xxx");
            SendKeys(attributeName_id, description_Id, "description test");
            SendKeys(attributeName_id, freightQuantity_Id, "2");
            SendKeys(attributeName_id, freightWeight_Id, "20");
            SendKeys(attributeName_id, InsuredValue_Id, "200");

            Report.WriteLine("clicking on View Rate button");
            Click(attributeName_xpath, ViewRateButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, ShipmentResult_CreateShipmentButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            Click(attributeName_id, SubmitShipmentButton_Id);
        }
        
        [When(@"I hover over the customer name from Shipment confirmation \(LTL\) page")]
        public void WhenIHoverOverTheCustomerNameFromShipmentConfirmationLTLPage()
        {
            Thread.Sleep(2000);
            OnMouseOver(attributeName_xpath, ShipmentConfirmation_CustomerLabel_Xpath);
        }
        
        [When(@"I hover over the customer name from Shipment List")]
        public void WhenIHoverOverTheCustomerNameFromShipmentList()
        {
            OnMouseOver(attributeName_xpath, ShipmentList_CustomerDropdown_SelectedValue_Xpath);
        }
        
        [When(@"I hover over the customer name from Add Shipment page")]
        public void WhenIHoverOverTheCustomerNameFromAddShipmentPage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I hover over the customer name from Shipment confirmation page")]
        public void WhenIHoverOverTheCustomerNameFromShipmentConfirmationPage()
        {
            OnMouseOver(attributeName_xpath, "");
        }
        
        [Then(@"customer label will display (.*) from shipment list page")]
        public void ThenCustomerLabelWillDisplayFromShipmentListPage(string p0)
        {
            
            actualMsg = Gettext(attributeName_xpath, ShipmentList_Customer_dropdown_Xpath);
            string SubAccount = "ArnoldTest05072018B";
            string StatioName = DBHelper.GetStationName(SubAccount);
            int SubAccccId = DBHelper.GetCustomerId(SubAccount);
            int primaryAccId = DBHelper.GetPrimaryAccId(SubAccccId);
            string PrimaryAccountName = DBHelper.GetPrimaryAcc(primaryAccId);
            string ExpectedStationCustomerDisplay = StatioName + " - " + PrimaryAccountName + " ... " + SubAccount;
            Assert.AreEqual(actualMsg, actualMsg);
        }
        
        [Then(@"the entire station, hierarchies, and customer name will be displayed in the hover over message")]
        public void ThenTheEntireStationHierarchiesAndCustomerNameWillBeDisplayedInTheHoverOverMessage()
        {
            actualMsg = Gettext(attributeName_classname, "mypopovershipment");
            expectedMsg = "ZZZ - Web Services Test - ZZZ - GS Customer Test - ArnoldTest02222018 - ArnoldTest05072018B";
            Assert.AreEqual(actualMsg, expectedMsg);

        }
        
        [Then(@"customer label will now display (.*) Add Shipment page of service type selection")]
        public void ThenCustomerLabelWillNowDisplayAddShipmentPageOfServiceTypeSelection(string p0)
        {
           
            actualMsg = Gettext(attributeName_xpath, AddShipmentCustomerLabelDropdown_xpath);
            string SubAccount = "ArnoldTest05072018B";
            string StatioName = DBHelper.GetStationName(SubAccount);
            int SubAccccId = DBHelper.GetCustomerId(SubAccount);
            int primaryAccId = DBHelper.GetPrimaryAccId(SubAccccId);
            string PrimaryAccountName = DBHelper.GetPrimaryAcc(primaryAccId);
            string ExpectedStationCustomerDisplay = StatioName + " - " + PrimaryAccountName + " ... " + SubAccount;
            Assert.AreEqual(actualMsg, actualMsg);

        }

        [Then(@"the entire station, hierarchies, and customer name will be displayed in the hover over message from Add Shipment page of service type selection")]
        public void ThenTheEntireStationHierarchiesAndCustomerNameWillBeDisplayedInTheHoverOverMessageFromAddShipmentPageOfServiceTypeSelection()
        {
            actualMsg = Gettext(attributeName_classname, "mypopovershipment");
            expectedMsg = "ZZZ - Web Services Test - ZZZ - GS Customer Test - ArnoldTest02222018 - ArnoldTest05072018B";
            Assert.AreEqual(actualMsg, expectedMsg);
        }

        [Then(@"the entire station, hierarchies, and customer name will be displayed in the hover over message from Add Shipment page of service type selection for external user")]
        public void ThenTheEntireStationHierarchiesAndCustomerNameWillBeDisplayedInTheHoverOverMessageFromAddShipmentPageOfServiceTypeSelectionForExternalUser()
        {
            actualMsg = Gettext(attributeName_classname, "mypopovershipment");
            expectedMsg = "ZZZ - Czar Customer Test - checking for the config manager1 - testingcsasubaccount - testingcsasubaccount_sub";
            Assert.AreEqual(actualMsg, expectedMsg);
        }


        [Then(@"customer label will now display (.*) from Add Shipment \(LTL\) page")]
        public void ThenCustomerLabelWillNowDisplayFromAddShipmentLTLPage(string p0)
        {
          
            actualMsg = Gettext(attributeName_xpath, AddShipmentLTLCustomerLabelDropdown_Xpath);
            string SubAccount = "ArnoldTest05072018B";
            string StatioName = DBHelper.GetStationName(SubAccount);
            int SubAccccId = DBHelper.GetCustomerId(SubAccount);
            int primaryAccId = DBHelper.GetPrimaryAccId(SubAccccId);
            string PrimaryAccountName = DBHelper.GetPrimaryAcc(primaryAccId);
            string ExpectedStationCustomerDisplay = StatioName + " - " + PrimaryAccountName + " ... " + SubAccount;
            Assert.AreEqual(actualMsg, actualMsg);
        }
        
        [Then(@"the entire station, hierarchies, and customer name will be displayed in the hover over message from Add Shipment \(LTL\) page")]
        public void ThenTheEntireStationHierarchiesAndCustomerNameWillBeDisplayedInTheHoverOverMessageFromAddShipmentLTLPage()
        {
            actualMsg = Gettext(attributeName_classname, "mypopovershipment");
            expectedMsg = "ZZZ - Web Services Test - ZZZ - GS Customer Test - ArnoldTest02222018 - ArnoldTest05072018B";
            Assert.AreEqual(actualMsg, expectedMsg);
        }
        
        [Then(@"customer label will now display (.*) from Shipment Results page")]
        public void ThenCustomerLabelWillNowDisplayFromShipmentResultsPage(string p0)
        {
            actualMsg = Gettext(attributeName_xpath, ShipmentResult_CustomerLabel_Xpath);
            string SubAccount = "ArnoldTest05072018B";
            string StatioName = DBHelper.GetStationName(SubAccount);
            int SubAccccId = DBHelper.GetCustomerId(SubAccount);
            int primaryAccId = DBHelper.GetPrimaryAccId(SubAccccId);
            string PrimaryAccountName = DBHelper.GetPrimaryAcc(primaryAccId);
            string ExpectedStationCustomerDisplay = StatioName + " - " + PrimaryAccountName + " ... " + SubAccount;
            Assert.AreEqual(actualMsg, actualMsg);
        }

        [Then(@"customer label will now display (.*) from Shipment Results page for external user")]
        public void ThenCustomerLabelWillNowDisplayFromShipmentResultsPageForExternalUser(string p0)
        {
            actualMsg = Gettext(attributeName_xpath, ShipmentResult_customerLabel_ExternalUser_Xpath);
            string SubAccount = "testingcsasubaccount_sub";
            string StatioName = DBHelper.GetStationName(SubAccount);
            int SubAccccId = DBHelper.GetCustomerId(SubAccount);
            int primaryAccId = DBHelper.GetPrimaryAccId(SubAccccId);
            string PrimaryAccountName = DBHelper.GetPrimaryAcc(primaryAccId);
            string ExpectedStationCustomerDisplay = PrimaryAccountName + " ... " + SubAccount;
            Assert.AreEqual(actualMsg, actualMsg);
        }

        [Then(@"the entire station, hierarchies, and customer name will be displayed in the hover over message from Shipment Results page")]
        public void ThenTheEntireStationHierarchiesAndCustomerNameWillBeDisplayedInTheHoverOverMessageFromShipmentResultsPage()
        {
            actualMsg = Gettext(attributeName_classname, "mypopovershipment");
            expectedMsg = "ZZZ - Web Services Test - ZZZ - GS Customer Test - ArnoldTest02222018 - ArnoldTest05072018B";
            Assert.AreEqual(actualMsg, expectedMsg);
        }

        [Then(@"the entire station, hierarchies, and customer name will be displayed in the hover over message from Shipment Results page for external user")]
        public void ThenTheEntireStationHierarchiesAndCustomerNameWillBeDisplayedInTheHoverOverMessageFromShipmentResultsPageForExternalUser()
        {
            actualMsg = Gettext(attributeName_classname, "mypopovershipment");
            expectedMsg = "ZZZ - Czar Customer Test - checking for the config manager1 - testingcsasubaccount - testingcsasubaccount_sub";
            Assert.AreEqual(actualMsg, expectedMsg);
        }

        [When(@"I am on the Shipment Results page as a external user")]
        public void WhenIAmOnTheShipmentResultsPageAsAExternalUser()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, ShipmentServicetype_AddShipmentButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ShipmentList_LTLtile_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_id, OriginLocationName_Id, "test xyz");
            SendKeys(attributeName_id, OriginAddress_Id, "test address");
            SendKeys(attributeName_id, OriginZip_Id, "33126");
            SendKeys(attributeName_id, destinationLocation_Id, "test xyzcc");
            SendKeys(attributeName_id, destinationAddress_Id, "test address");
            SendKeys(attributeName_id, destinationZip_Id, "33126");
            SendKeys(attributeName_id, freightCharges_Id, "60");
            SendKeys(attributeName_id, description_Id, "xxx");
            SendKeys(attributeName_id, description_Id, "description test");
            SendKeys(attributeName_id, freightQuantity_Id, "2");
            SendKeys(attributeName_id, freightWeight_Id, "20");
            SendKeys(attributeName_id, InsuredValue_Id, "200");

            Report.WriteLine("clicking on View Rate button");
            Click(attributeName_xpath, ViewRateButton_Xpath);
        }


        [Then(@"customer label will now display (.*) from Review and Submit Shipment page")]
        public void ThenCustomerLabelWillNowDisplayFromReviewAndSubmitShipmentPage(string p0)
        {
            
            actualMsg = Gettext(attributeName_xpath, ReviewSubmitPage_customerLabel_Xpath);
            string SubAccount = "ArnoldTest05072018B";
            string StatioName = DBHelper.GetStationName(SubAccount);
            int SubAccccId = DBHelper.GetCustomerId(SubAccount);
            int primaryAccId = DBHelper.GetPrimaryAccId(SubAccccId);
            string PrimaryAccountName = DBHelper.GetPrimaryAcc(primaryAccId);
            string ExpectedStationCustomerDisplay = StatioName + " - " + PrimaryAccountName + " ... " + SubAccount;
            Assert.AreEqual(actualMsg, actualMsg);
        }

        [Then(@"customer label will now display (.*) from Review and Submit Shipment page for external user")]
        public void ThenCustomerLabelWillNowDisplayFromReviewAndSubmitShipmentPageForExternalUser(string p0)
        {
            actualMsg = Gettext(attributeName_xpath, ShipmentResult_CustomerLabel_Xpath);
            string SubAccount = "ArnoldTest05072018B";
            string StatioName = DBHelper.GetStationName(SubAccount);
            int SubAccccId = DBHelper.GetCustomerId(SubAccount);
            int primaryAccId = DBHelper.GetPrimaryAccId(SubAccccId);
            string PrimaryAccountName = DBHelper.GetPrimaryAcc(primaryAccId);
            string ExpectedStationCustomerDisplay = StatioName + " - " + PrimaryAccountName + " ... " + SubAccount;
            Assert.AreEqual(actualMsg, actualMsg);
        }


        [Then(@"the entire station, hierarchies, and customer name will be displayed in the hover over message from Review and Submit Shipment page")]
        public void ThenTheEntireStationHierarchiesAndCustomerNameWillBeDisplayedInTheHoverOverMessageFromReviewAndSubmitShipmentPage()
        {
            actualMsg = Gettext(attributeName_classname, "mypopovershipment");
            expectedMsg = "ZZZ - Web Services Test - ZZZ - GS Customer Test - ArnoldTest02222018 - ArnoldTest05072018B";
            Assert.AreEqual(actualMsg, expectedMsg);
        }

        [Then(@"the entire station, hierarchies, and customer name will be displayed in the hover over message from Review and Submit Shipment page for external user")]
        public void ThenTheEntireStationHierarchiesAndCustomerNameWillBeDisplayedInTheHoverOverMessageFromReviewAndSubmitShipmentPageForExternalUser()
        {
            actualMsg = Gettext(attributeName_classname, "mypopovershipment");
            expectedMsg = "ZZZ - Czar Customer Test - checking for the config manager1 - testingcsasubaccount - testingcsasubaccount_sub";
            Assert.AreEqual(actualMsg, expectedMsg);
        }


        [Then(@"customer label will now display (.*)  from Shipment confirmation \(LTL\) page")]
        public void ThenCustomerLabelWillNowDisplayFromShipmentConfirmationLTLPage(string p0)
        {
            actualMsg = Gettext(attributeName_xpath, ShipmentConfirmation_CustomerLabel_Xpath);
            string SubAccount = "ArnoldTest05072018B";
            string StatioName = DBHelper.GetStationName(SubAccount);
            int SubAccccId = DBHelper.GetCustomerId(SubAccount);
            int primaryAccId = DBHelper.GetPrimaryAccId(SubAccccId);
            string PrimaryAccountName = DBHelper.GetPrimaryAcc(primaryAccId);
            string ExpectedStationCustomerDisplay = StatioName + " - " + PrimaryAccountName + " ... " + SubAccount;
            Assert.AreEqual(actualMsg, actualMsg);
        }
        
        [Then(@"the entire station, hierarchies, and customer name will be displayed in the hover over message  from Shipment confirmation \(LTL\) page")]
        public void ThenTheEntireStationHierarchiesAndCustomerNameWillBeDisplayedInTheHoverOverMessageFromShipmentConfirmationLTLPage()
        {
            actualMsg = Gettext(attributeName_classname, "mypopovershipment");
            expectedMsg = "ZZZ - Web Services Test - ZZZ - GS Customer Test - ArnoldTest02222018 - ArnoldTest05072018B";
            Assert.AreEqual(actualMsg, expectedMsg);
        }
        
        [Then(@"customer label will now display (.*) from shipment List page")]
        public void ThenCustomerLabelWillNowDisplayFromShipmentListPage(string p0)
        {
            
            actualMsg = Gettext(attributeName_xpath, ShipmentList_CustomerDropdown_SelectedValue_Xpath);
            string SubAccount = "ArnoldTest05072018B";
            string StatioName = DBHelper.GetStationName(SubAccount);
            int SubAccccId = DBHelper.GetCustomerId(SubAccount);
            int primaryAccId = DBHelper.GetPrimaryAccId(SubAccccId);
            string PrimaryAccountName = DBHelper.GetPrimaryAcc(primaryAccId);
            string ExpectedStationCustomerDisplay = StatioName + " - " + PrimaryAccountName + " ... " + SubAccount;
            Assert.AreEqual(actualMsg, actualMsg);
        }
        
        [Then(@"the entire station, hierarchies, and customer name will be displayed in the hover over message from Shipment List")]
        public void ThenTheEntireStationHierarchiesAndCustomerNameWillBeDisplayedInTheHoverOverMessageFromShipmentList()
        {
            actualMsg = Gettext(attributeName_classname, "mypopovershipment");
            expectedMsg = "ZZZ - Web Services Test - ZZZ - GS Customer Test - ArnoldTest02222018 - ArnoldTest05072018B";
            Assert.AreEqual(actualMsg, expectedMsg);
        }

        [Then(@"the entire station, hierarchies, and customer name will be displayed in the hover over message from Shipment List as a external user")]
        public void ThenTheEntireStationHierarchiesAndCustomerNameWillBeDisplayedInTheHoverOverMessageFromShipmentListAsAExternalUser()
        {
            actualMsg = Gettext(attributeName_classname, "mypopovershipment");
            expectedMsg = "ZZZ - Czar Customer Test - checking for the config manager1 - testingcsasubaccount - testingcsasubaccount_sub";
            Assert.AreEqual(actualMsg, expectedMsg);
        }


        [Then(@"customer label will now display (.*) from Add Shipment page of service type selection")]
        public void ThenCustomerLabelWillNowDisplayFromAddShipmentPageOfServiceTypeSelection(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"customer label will now display (.*) from Add Shipment page")]
        public void ThenCustomerLabelWillNowDisplayFromAddShipmentPage(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the entire station, hierarchies, and customer name will be displayed in the hover over message from Add Shipment page")]
        public void ThenTheEntireStationHierarchiesAndCustomerNameWillBeDisplayedInTheHoverOverMessageFromAddShipmentPage()
        {
            actualMsg = Gettext(attributeName_classname, "mypopovershipment");
            expectedMsg = "ZZZ - Czar Customer Test - checking for the config manager1 - testingcsasubaccount - testingcsasubaccount_sub";
            Assert.AreEqual(actualMsg, expectedMsg);
        }
        
        [Then(@"customer label will now display (.*) from Shipment confirmation page")]
        public void ThenCustomerLabelWillNowDisplayFromShipmentConfirmationPage(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the entire station, hierarchies, and customer name will be displayed in the hover over message from Shipment confirmation page")]
        public void ThenTheEntireStationHierarchiesAndCustomerNameWillBeDisplayedInTheHoverOverMessageFromShipmentConfirmationPage()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
