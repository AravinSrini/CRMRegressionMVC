using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Configuration;
using TechTalk.SpecFlow;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;

namespace CRM.UITest.Scripts.Shipment.ShipmentList.Shipment_List___Show_loading_icon
{
    [Binding]
    public class ShipmentList_ShowLoadingIconWhenSearchingReferenceNumberSteps : Shipmentlist
    {
        string referenceNumber = "ZZX00209941";
        
        [Given(@"I am a User with access to Shipment List page")]
        public void GivenIAmAUserWithAccessToShipmentListPage()
        {
            string username = ConfigurationManager.AppSettings["username-Both"].ToString();
            string password = ConfigurationManager.AppSettings["password-Both"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }


        [Given(@"I searched for any shipment of a customer with a sub-account that I am associated to on the reference number input")]
        public void GivenISearchedForAnyShipmentOfACustomerWithASub_AccountThatIAmAssociatedToOnTheReferenceNumberInput()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_xpath, ShipmentList_ReferenceNumLookup_Xpath, referenceNumber);
            Click(attributeName_xpath, ShipmentListRefLookUpArrow_Xpath);
        }
        
        [When(@"I search for any shipment of a customer with a sub-account that I am associated to on the reference number input")]
        public void WhenISearchForAnyShipmentOfACustomerWithASub_AccountThatIAmAssociatedToOnTheReferenceNumberInput()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_xpath, ShipmentList_ReferenceNumLookup_Xpath, referenceNumber);
            Click(attributeName_xpath, ShipmentListRefLookUpArrow_Xpath);
        }
        
        [When(@"CRM receives the results from that search")]
        public void WhenCRMReceivesTheResultsFromThatSearch()
        {
            ThenTheResultsWillShowInTheTable();
        }
        
        [Then(@"I will see the loading icon")]
        public void ThenIWillSeeTheLoadingIcon()
        {
            WaitForElementVisible(attributeName_xpath, LoadingIcon_Xpath, "Loading Icon");
            VerifyElementVisible(attributeName_xpath, LoadingIcon_Xpath, "Loading Icon");
        }
        
        [Then(@"I will see the loading icon will be hidden")]
        public void ThenIWillSeeTheLoadingIconWillBeHidden()
        {
            VerifyElementNotVisible(attributeName_xpath, LoadingIcon_Xpath, "Loading Icon");
            
        }
        
        [Then(@"the results will show in the table")]
        public void ThenTheResultsWillShowInTheTable()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            String GridRefValue = Gettext(attributeName_xpath, ShipmentListGrid_RefNumAllValues_Xpath);
            Assert.AreEqual(referenceNumber, GridRefValue);
        }

        [When(@"I click the Shipment List Icon on the navigation menu")]
        public void WhenIClickTheShipmentListIconOnTheNavigationMenu()
        {
            Click(attributeName_xpath, ShipmentIcon_Xpath);
        }

        [Then(@"I will see a loading overlay while the page is loading")]
        public void ThenIWillSeeALoadingOverlayWhileThePageIsLoading()
        {
            WaitForElementVisible(attributeName_xpath, ShipmentList_LoadingIcon_Xpath, "Loading Icon");
            VerifyElementVisible(attributeName_xpath, ShipmentList_LoadingIcon_Xpath, "Loading Icon");
        }

        [When(@"the page is loaded")]
        public void WhenThePageIsLoaded()
        {
            Report.WriteLine("navigate to shipmentlist page");
            VerifyElementPresent(attributeName_xpath, ShipmentList_Title_Xpath, "shipmentpage");
        }

        [Then(@"I will no longer see the loading overlay")]
        public void ThenIWillNoLongerSeeTheLoadingOverlay()
        {
            VerifyElementNotVisible(attributeName_xpath, ShipmentList_LoadingIcon_Xpath, "Loading Icon");
        }

    }
}
