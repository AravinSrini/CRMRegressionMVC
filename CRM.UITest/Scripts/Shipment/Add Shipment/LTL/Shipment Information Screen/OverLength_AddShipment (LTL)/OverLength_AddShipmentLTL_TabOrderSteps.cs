using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Information_Screen.OverLength_AddShipment__LTL_
{
    [Binding]
    public class OverLength_AddShipmentLTL_TabOrderSteps : AddShipments 
    {
        public string CustomerName = "ZZZ - Czar Customer Test";

        [Given(@"I have logged in as a shp\.entry, shp\.entrynorates, operations, sales, sales management, or station owner user")]
        public void GivenIHaveLoggedInAsAShp_EntryShp_EntrynoratesOperationsSalesSalesManagementOrStationOwnerUser()
        {
            string username = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
            string password = ConfigurationManager.AppSettings["password-crmOperation"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"I am on Add Shipment \(LTL\) page")]
        public void GivenIAmOnAddShipmentLTLPage()
        {

            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ShipmentIcon_Id);
           
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, AddShipment_Button_id);
            Click(attributeName_id, AddShipmentLTL_Button_Id);
        }

        [Given(@"I am on Add Shipment \(LTL\) page as a internal user")]
        public void GivenIAmOnAddShipmentLTLPageAsAInternalUser()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ShipmentIcon_Id);
            Click(attributeName_xpath, AllCustomerDropdown_Selection_Internal_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, AllCustomerDroppdownValues_Internal_Xpath, CustomerName);
            Click(attributeName_id, AddShipmentButtionInternal_Id);          
            Click(attributeName_id, AddShipmentLTL_Button_Id);
        }


        [When(@"(.*) has been selected for both shipping from and Shipping To fields")]
        public void WhenHasBeenSelectedForBothShippingFromAndShippingToFields(string p0)
        {
            Click(attributeName_xpath, ShippingFrom_ServicesAccessorial_DropDown_xpath);
            SelectDropdownValueFromList(attributeName_xpath, ShippingFrom_ServicesAccessorial_DropDown_Values_xpath, "Overlength");

            Click(attributeName_xpath, ShippingTo_ServicesAccessorial_DropDown_xpath);
            SelectDropdownValueFromList(attributeName_xpath, ShippingTo_ServicesAccessorial_DropDown_Values_xpath, "Overlength");

        }
        
        
        [Then(@"the tab order will follow the given sequence\. Enter location name ,Enter location address, Enter zip/postal code \(Shipping From section\) , Enter destination name, Enter destination address, Enter zip/postal code \(Shipping To  section\), Select or search for a class or saved item field, Enter a quantity , Enter item description ,Enter a weight, Length, Width, Height")]
        public void ThenTheTabOrderWillFollowTheGivenSequence_EnterLocationNameEnterLocationAddressEnterZipPostalCodeShippingFromSectionEnterDestinationNameEnterDestinationAddressEnterZipPostalCodeShippingToSectionSelectOrSearchForAClassOrSavedItemFieldEnterAQuantityEnterItemDescriptionEnterAWeightLengthWidthHeight()
        {
            Report.WriteLine("Verifying the Tab order in Shipment information page");

            GlobalVariables.webDriver.WaitForPageLoad();
            IWebElement shippingFromLocationName = GlobalVariables.webDriver.FindElement(By.Id(ShippingFrom_LocationName_Id));
            shippingFromLocationName.SendKeys(Keys.Tab);

            IWebElement shippingFromLocationAddress = GlobalVariables.webDriver.FindElement(By.Id(ShippingFrom_LocationAddressLine1_Id));
            shippingFromLocationAddress.SendKeys(Keys.Tab);

            IWebElement shippingFromLocationZipCode = GlobalVariables.webDriver.FindElement(By.Id(ShippingFrom_zipcode_Id));
            shippingFromLocationZipCode.SendKeys(Keys.Tab);

            IWebElement shippingToLocationName = GlobalVariables.webDriver.FindElement(By.Id(ShippingTo_LocationName_Id));
            shippingToLocationName.SendKeys(Keys.Tab);

            IWebElement shippingToAddress = GlobalVariables.webDriver.FindElement(By.Id(ShippingTo_LocationAddressLine1_Id));
            shippingToAddress.SendKeys(Keys.Tab);

            IWebElement shippingToZipCode = GlobalVariables.webDriver.FindElement(By.Id(ShippingTo_zipcode_Id));
            shippingToZipCode.SendKeys(Keys.Tab);

            IWebElement savedItemField = GlobalVariables.webDriver.FindElement(By.Id(FreightDesp_FirstItem_SavedClassItem_DropDown_Id));
            savedItemField.SendKeys(Keys.Tab);

            IWebElement quantity = GlobalVariables.webDriver.FindElement(By.Id(FreightDesp_FirstItem_Quantity_Id));
            quantity.SendKeys(Keys.Tab);

            IWebElement itemDescription = GlobalVariables.webDriver.FindElement(By.Id(FreightDesp_FirstItem_ItemDescription_Id));
            itemDescription.SendKeys(Keys.Tab);

            IWebElement itemWeight = GlobalVariables.webDriver.FindElement(By.Id(FreightDesp_FirstItem_Weight_Id));
            itemWeight.SendKeys(Keys.Tab);

            IWebElement itemLength = GlobalVariables.webDriver.FindElement(By.Id(FreightDesp_FirstItem_Length_Id));
            itemLength.SendKeys(Keys.Tab);


            IWebElement itemWidth = GlobalVariables.webDriver.FindElement(By.Id(FreightDesp_FirstItem_Width_Id));
            itemWidth.SendKeys(Keys.Tab);

            IWebElement itemHeight = GlobalVariables.webDriver.FindElement(By.Id(FreightDesp_FirstItem_Height_Id));
            itemHeight.SendKeys(Keys.Tab);

        }

        [Then(@"the tab order will follow the given sequence for additionally added items\. Select or search for a class or saved item field , Enter a quantity, Enter item description, Enter a weight, Length, Width, Height, View Rates button")]
        public void ThenTheTabOrderWillFollowTheGivenSequenceForAdditionallyAddedItems_SelectOrSearchForAClassOrSavedItemFieldEnterAQuantityEnterItemDescriptionEnterAWeightLengthWidthHeightViewRatesButton()
        {
            Report.WriteLine("Verifying the Tab order in item details section");

            GlobalVariables.webDriver.WaitForPageLoad();
            IWebElement savedItemField = GlobalVariables.webDriver.FindElement(By.Id(FreightDesp_FirstItem_SavedClassItem_DropDown_Id));
            savedItemField.SendKeys(Keys.Tab);

            IWebElement quantity = GlobalVariables.webDriver.FindElement(By.Id(FreightDesp_FirstItem_Quantity_Id));
            quantity.SendKeys(Keys.Tab);

            IWebElement itemDescription = GlobalVariables.webDriver.FindElement(By.Id(FreightDesp_FirstItem_ItemDescription_Id));
            itemDescription.SendKeys(Keys.Tab);

            IWebElement itemWeight = GlobalVariables.webDriver.FindElement(By.Id(FreightDesp_FirstItem_Weight_Id));
            itemWeight.SendKeys(Keys.Tab);

            IWebElement itemLength = GlobalVariables.webDriver.FindElement(By.Id(FreightDesp_FirstItem_Length_Id));
            itemLength.SendKeys(Keys.Tab);


            IWebElement itemWidth = GlobalVariables.webDriver.FindElement(By.Id(FreightDesp_FirstItem_Width_Id));
            itemWidth.SendKeys(Keys.Tab);

            IWebElement itemHeight = GlobalVariables.webDriver.FindElement(By.Id(FreightDesp_FirstItem_Height_Id));
            itemHeight.SendKeys(Keys.Tab);


            IWebElement viewRateButton = GlobalVariables.webDriver.FindElement(By.XPath(Shipments_ViewRatesButton_xpath));
            viewRateButton.SendKeys(Keys.Tab);
        }

        [Then(@"the back tab order will follow the given sequesnce for additionally added items\. View Rates button, Height, Width, Length , Enter a weight, Enter item description, Enter a quantity , Select or search for a class or saved item, Enter zip/postal code \(Shipping To section\) , Enter destination address, Enter destination name, Enter zip/postal code \(Shipping From section\) , Enter location address, Enter location name")]
        public void ThenTheBackTabOrderWillFollowTheGivenSequesnceForAdditionallyAddedItems_ViewRatesButtonHeightWidthLengthEnterAWeightEnterItemDescriptionEnterAQuantitySelectOrSearchForAClassOrSavedItemEnterZipPostalCodeShippingToSectionEnterDestinationAddressEnterDestinationNameEnterZipPostalCodeShippingFromSectionEnterLocationAddressEnterLocationName()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Back Tab order in shipment information page");
            IWebElement viewRateButton = GlobalVariables.webDriver.FindElement(By.XPath(Shipments_ViewRatesButton_xpath));
            viewRateButton.SendKeys(Keys.Shift + Keys.Tab);

            IWebElement itemHeight = GlobalVariables.webDriver.FindElement(By.Id(FreightDesp_FirstItem_Height_Id));
            itemHeight.SendKeys(Keys.Shift + Keys.Tab);

            IWebElement itemWidth = GlobalVariables.webDriver.FindElement(By.Id(FreightDesp_FirstItem_Width_Id));
            itemWidth.SendKeys(Keys.Shift + Keys.Tab);

            IWebElement itemLength = GlobalVariables.webDriver.FindElement(By.Id(FreightDesp_FirstItem_Length_Id));
            itemLength.SendKeys(Keys.Shift + Keys.Tab);

            IWebElement itemWeight = GlobalVariables.webDriver.FindElement(By.Id(FreightDesp_FirstItem_Weight_Id));
            itemWeight.SendKeys(Keys.Shift + Keys.Tab);

            IWebElement itemDescription = GlobalVariables.webDriver.FindElement(By.Id(FreightDesp_FirstItem_ItemDescription_Id));
            itemDescription.SendKeys(Keys.Shift + Keys.Tab);

            IWebElement quantity = GlobalVariables.webDriver.FindElement(By.Id(FreightDesp_FirstItem_Quantity_Id));
            quantity.SendKeys(Keys.Shift + Keys.Tab);

            IWebElement savedItemField = GlobalVariables.webDriver.FindElement(By.Id(FreightDesp_FirstItem_SavedClassItem_DropDown_Id));
            savedItemField.SendKeys(Keys.Shift + Keys.Tab);

            IWebElement shippingToZipCode = GlobalVariables.webDriver.FindElement(By.Id(ShippingTo_zipcode_Id));
            shippingToZipCode.SendKeys(Keys.Shift + Keys.Tab);

            IWebElement shippingToAddress = GlobalVariables.webDriver.FindElement(By.Id(ShippingTo_LocationAddressLine1_Id));
            shippingToAddress.SendKeys(Keys.Shift + Keys.Tab);

            IWebElement shippingToLocationName = GlobalVariables.webDriver.FindElement(By.Id(ShippingTo_LocationName_Id));
            shippingToLocationName.SendKeys(Keys.Shift + Keys.Tab);

            IWebElement shippingFromLocationZipCode = GlobalVariables.webDriver.FindElement(By.Id(ShippingFrom_zipcode_Id));
            shippingFromLocationZipCode.SendKeys(Keys.Shift + Keys.Tab);

            IWebElement shippingFromLocationAddress = GlobalVariables.webDriver.FindElement(By.Id(ShippingFrom_LocationAddressLine1_Id));
            shippingFromLocationAddress.SendKeys(Keys.Shift + Keys.Tab);

            IWebElement shippingFromLocationName = GlobalVariables.webDriver.FindElement(By.Id(ShippingFrom_LocationName_Id));
            shippingFromLocationName.SendKeys(Keys.Shift + Keys.Tab);
        }



        [Then(@"the back tab order will follow the given sequence\. View Rates button, Height, Width, Length , Enter a weight, Enter item description , Enter a quantity , Select or search for a class or saved item")]
        public void ThenTheBackTabOrderWillFollowTheGivenSequence_ViewRatesButtonHeightWidthLengthEnterAWeightEnterItemDescriptionEnterAQuantitySelectOrSearchForAClassOrSavedItem()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            IWebElement viewRateButton = GlobalVariables.webDriver.FindElement(By.XPath(Shipments_ViewRatesButton_xpath));
            viewRateButton.SendKeys(Keys.Shift + Keys.Tab);

            IWebElement itemHeight = GlobalVariables.webDriver.FindElement(By.Id(FreightDesp_FirstItem_Height_Id));
            itemHeight.SendKeys(Keys.Shift + Keys.Tab);

            IWebElement itemWidth = GlobalVariables.webDriver.FindElement(By.Id(FreightDesp_FirstItem_Width_Id));
            itemWidth.SendKeys(Keys.Shift + Keys.Tab);

            IWebElement itemLength = GlobalVariables.webDriver.FindElement(By.Id(FreightDesp_FirstItem_Length_Id));
            itemLength.SendKeys(Keys.Shift + Keys.Tab);

            IWebElement itemWeight = GlobalVariables.webDriver.FindElement(By.Id(FreightDesp_FirstItem_Weight_Id));
            itemWeight.SendKeys(Keys.Shift + Keys.Tab);

            IWebElement itemDescription = GlobalVariables.webDriver.FindElement(By.Id(FreightDesp_FirstItem_ItemDescription_Id));
            itemDescription.SendKeys(Keys.Shift + Keys.Tab);

            IWebElement quantity = GlobalVariables.webDriver.FindElement(By.Id(FreightDesp_FirstItem_Quantity_Id));
            quantity.SendKeys(Keys.Shift + Keys.Tab);

            IWebElement savedItemField = GlobalVariables.webDriver.FindElement(By.Id(FreightDesp_FirstItem_SavedClassItem_DropDown_Id));
            savedItemField.SendKeys(Keys.Shift + Keys.Tab);


        }
    }
}
