using CRM.UITest.CommonMethods;
using CRM.UITest.Helper.Common;
using CRM.UITest.Helper.Implementations.ShipmentExtract;
using CRM.UITest.Helper.ViewModel;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.CRM_Rating_logic___Multiple_item_scenario
{
    [Binding]
    public class CRMRatingLogic_MultipleItemScenarioSteps : AddShipments
    {
        CommonMethodsCrm crm = new CommonMethodsCrm();
        string ratingLogicCustomer = string.Empty;
        string referenceNumber = string.Empty;
        string expectedCustomerCharge = string.Empty;
        ShipmentExtractViewModel shipmentViewModels = null;

        [Given(@"I am user with access to create shipment")]
        public void GivenIAmUserWithAccessToCreateShipment()
        {
            string username = ConfigurationManager.AppSettings["username-OperationsCrm"].ToString();
            string password = ConfigurationManager.AppSettings["password-OperationsCrm"].ToString();
            crm.LoginToCRMApplication(username, password);
        }
        
        [Given(@"The customer I am associated to has CRM rating login on")]
        public void GivenTheCustomerIAmAssociatedToHasCRMRatingLoginOn()
        {
            ratingLogicCustomer = "ZZZ - GS Customer Test";
        }
        
        [Given(@"I am creating a shipment that contains multiple items")]
        public void GivenIAmCreatingAShipmentThatContainsMultipleItems()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ShipmentIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, AllCustomerDropdown_Selection_Internal_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, AllCustomerDroppdownValues_Internal_Xpath, ratingLogicCustomer);
            Report.WriteLine("Customer is been selected from the dropdown");
            Click(attributeName_id, AddShipmentButtionInternal_Id);
            Report.WriteLine("Clicked on Add shipment button");
            Click(attributeName_id, AddShipmentLTL_Button_Id);
            Report.WriteLine("Clicked on LTL tile on Add shipment page");
            Verifytext(attributeName_xpath, AddShipment_PageTitle_xpath, "Add Shipment (LTL)");
            Report.WriteLine("Navigated to Shipment list page");
            SendKeys(attributeName_id, OriginZip_Id, "60606");
            SendKeys(attributeName_id, ShippingTo_zipcode_Id, "60606");
            scrollElementIntoView(attributeName_id, ShippingFrom_ClearAddress_Id);
            SendKeys(attributeName_id, ShippingFrom_LocationName_Id, "test");
            SendKeys(attributeName_id, ShippingFrom_LocationAddressLine1_Id, "Address");
            scrollElementIntoView(attributeName_id, ShippingTo_LocationName_Id);
            SendKeys(attributeName_id, ShippingTo_LocationName_Id, "testing");
            SendKeys(attributeName_id, ShippingTo_LocationAddressLine1_Id, "addressdest");
            scrollpagedown();
            //Item 1 with overlength
            Click(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            MoveToElement(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id);
            Click(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id);
            IList<IWebElement> dropdownValues = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='scrollable-dropdown-menu-Origin']/div/span[1]/span/div/span/div/p"));
            for (int i = 0; i < dropdownValues.Count; i++)
            {
                int z = i + 1;
                string value = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='scrollable-dropdown-menu-Origin']/div/span[1]/span/div/span/div[" + z + "]/p")).Text;
                if (value == "65")
                {
                    GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='scrollable-dropdown-menu-Origin']/div/span[1]/span/div/span/div[" + z + "]/p")).Click();
                    break;
                }
            }
            SendKeys(attributeName_id, FreightDesp_FirstItem_NMFC_Id, "34");
            SendKeys(attributeName_id, FreightDesp_FirstItem_Quantity_Id, "1");
            SendKeys(attributeName_id, FreightDesp_FirstItem_Weight_Id, "5");
            SendKeys(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id, "Description");
            SendKeys(attributeName_id, FreightDesp_FirstItem_Length_Id,"96");
            SendKeys(attributeName_id, FreightDesp_FirstItem_Width_Id,"3");
            SendKeys(attributeName_id, FreightDesp_FirstItem_Height_Id,"2");

            //Item 2 
            Click(attributeName_xpath, AddAdditionalItemButton_xpath);
            scrollpagedown();
            Click(attributeName_id, FreightDesp_First_AdditionalItem_SavedClassItem_DropDown_Id);
            IList<IWebElement> dropdown1Values = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='scrollable-dropdown-menu-Origin']/div/span[1]/span/div/span/div/p"));
            for (int i = 0; i < dropdown1Values.Count; i++)
            {
                int z = i + 1;
                string value = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='scrollable-dropdown-menu-Origin']/div/span[1]/span/div/span/div[" + z + "]/p")).Text;
                if (value == "60")
                {
                    GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='scrollable-dropdown-menu-Origin']/div/span[1]/span/div/span/div[" + z + "]/p")).Click();
                    break;
                }
            }
            SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_NMFC_Id, "34");
            SendKeys(attributeName_xpath, FreightDesp_First_AdditionalItem_Quantity_xpath, "1");
            Click(attributeName_xpath, FreightDesp_First_AdditionalItem_QuantityType_xpath);
            SelectDropdownValueFromList(attributeName_xpath, FreightDesp_First_AdditionalItem_QuantityTypevalues_xpath, "Cylinders");
            SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_Weight_Id, "5");
            Click(attributeName_xpath, FreightDesp_First_AdditionalItem_WeightType_xpath);
            SelectDropdownValueFromList(attributeName_xpath, FreightDesp_First_AdditionalItem_WeightTypevalues_xpath, "KILOS");
            SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_ItemDescription_Id, "Description");
            SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_Length_Id, "9");
            SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_Width_Id, "4");
            SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_Height_Id, "5");

            //Item 3 with Hazardous Materials
            Click(attributeName_xpath, AddAdditionalItemButton_xpath);
            scrollpagedown();
            Click(attributeName_xpath, Freight_ThirdSavedItem_Xpath);
            IList<IWebElement> dropdown2Values = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='scrollable-dropdown-menu-Origin']/div/span[1]/span/div/span/div/p"));
            for (int i = 0; i < dropdown2Values.Count; i++)
            {
                int z = i + 1;
                string value = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='scrollable-dropdown-menu-Origin']/div/span[1]/span/div/span/div[" + z + "]/p")).Text;
                if (value == "55")
                {
                    GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='scrollable-dropdown-menu-Origin']/div/span[1]/span/div/span/div[" + z + "]/p")).Click();
                    break;
                }
            }
            SendKeys(attributeName_xpath, Freight_ThirdNMFC_Xpath, "454");
            SendKeys(attributeName_xpath, Freight_ThirdItemDesc_Xpath, "Test third Item");
            SendKeys(attributeName_xpath, Freight_ThirdQuantity_Xpath, "5");
            SendKeys(attributeName_xpath, Freight_ThirdWeight_Xpath, "4");
            SendKeys(attributeName_id, FreightDesp_ThirdItem_Length_Id, "2");
            SendKeys(attributeName_id, FreightDesp_ThirdItem_Width_Id, "4");
            SendKeys(attributeName_id, FreightDesp_ThirdItem_Height_Id, "1");
            Click(attributeName_xpath, Freight_ThirdHazardousYes_Xpath);
            Click(attributeName_xpath, WarningClose_Xpath);
            SendKeys(attributeName_xpath, Freight_ThirdUANNum_Xpath, "2321");
            SendKeys(attributeName_xpath, Freight_ThirdCCNNum_Xpath, "3346655");
            Click(attributeName_xpath, Freight_ThirdHazmatGrp_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, Freight_ThirdHazmatGrpValues_Xpath, "II");
            Click(attributeName_xpath, Freight_ThirdHazmatClass_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, Freight_ThirdHazmatClassValues_Xpath, "1.2");
            SendKeys(attributeName_xpath, Freight_ThirdEmergencyContactName_Xpath, "Check");
            SendKeys(attributeName_xpath, Freight_ThirdEmergencyPhoneNum_Xpath, "9845674207");

            //Item 4

            Click(attributeName_xpath, AddAdditionalItemButton_xpath);
            scrollpagedown();
            Click(attributeName_xpath, Freight_FourthSavedItem_Xpath);
            IList<IWebElement> dropdown3Values = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='scrollable-dropdown-menu-Origin']/div/span[1]/span/div/span/div/p"));
            for (int i = 0; i < dropdown3Values.Count; i++)
            {
                int z = i + 1;
                string value = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='scrollable-dropdown-menu-Origin']/div/span[1]/span/div/span/div[" + z + "]/p")).Text;
                if (value == "55")
                {
                    GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='scrollable-dropdown-menu-Origin']/div/span[1]/span/div/span/div[" + z + "]/p")).Click();
                    break;
                }
            }
            SendKeys(attributeName_xpath, Freight_FourthItemDesc_Xpath,"4th Item");
            SendKeys(attributeName_xpath, Freight_FourthQuantity_Xpath, "2");
            SendKeys(attributeName_xpath, Freight_FourthWeight_Xpath, "3");
            SendKeys(attributeName_xpath, Freight_FourthLength_Xpath, "5");
            SendKeys(attributeName_xpath, Freight_FourthWidth_Xpath, "4");
            SendKeys(attributeName_xpath, Freight_FourthHeight_Xpath, "3");
            SendKeys(attributeName_id, InsuredValue_TextBox_Id, "14,000.00");
            scrollpagedown();
            Click(attributeName_xpath, ViewRatesButton_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            VerifyElementPresent(attributeName_xpath, ShipResults_PageHeaderText_Relativexpath, "Shipment Results (LTL)");
            Report.WriteLine("Navigated to Shipment Results page");
        }
        
        [When(@"Shipment is created")]
        public void WhenShipmentIsCreated()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            expectedCustomerCharge = Gettext(attributeName_xpath, ShipResultsCarrierRate_Xpath);
            Click(attributeName_xpath, ShipmentResult_CreateShipmentButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Navigated to Review and Submit page");
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            VerifyElementPresent(attributeName_id, SubmitShipmentButton_Id, "Submit Button");
            Click(attributeName_id, SubmitShipmentButton_Id);
            Report.WriteLine("Clicked on Submit Shipment button of Review and Submit Shipment(LTL) page");
            GlobalVariables.webDriver.WaitForPageLoad();
        }
        
        [Then(@"Customer charge in MG should match customer charge displayed in CRM rate results")]
        public void ThenCustomerChargeInMGShouldMatchCustomerChargeDisplayedInCRMRateResults()
        {
            referenceNumber = Gettext(attributeName_id, ShipmentConfirmationNumber_Id);
            string uri = $"MercuryGate/OidLookup";

            //Building Client
            BuildHttpClient client = new BuildHttpClient();
            HttpClient headers = client.BuildHttpClientWithHeaders("Admin", "application/xml");

            ShipmentExtract ext = new ShipmentExtract();
            shipmentViewModels = ext.getShipmentData(uri, headers, referenceNumber, "Admin");
            string mgCustomerCharge = shipmentViewModels.CarrierRatesViewModel.Total;
            Assert.AreEqual(expectedCustomerCharge, "$" + mgCustomerCharge);
            Report.WriteLine("Customer charge in MG is matching customer charge displayed in CRM rate results");

        }
    }
}
