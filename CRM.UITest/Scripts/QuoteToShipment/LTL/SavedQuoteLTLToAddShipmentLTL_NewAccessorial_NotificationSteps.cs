using System.Configuration;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;

namespace CRM.UITest.Scripts.QuoteToShipment.LTL
{
    [Binding]
    public class SavedQuoteLTLToAddShipmentLTL_NewAccessorial_NotificationSteps : ObjectRepository
    {
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
        AddShipments addshipment = new AddShipments();
        CommonQuoteNavigations navigationtoConfirmationPage_LTL = new CommonQuoteNavigations();
        Quotelist quoteList = new Quotelist();
        AddShipments addShipmentLTL = new AddShipments();
        string userType = "Internal";
        string customerAcc = "ZZZ - Czar Customer Test";
        string userName = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
        string quoteReferenceNumber = null;

        [Given(@"I am on QuoteList page having saved quote of notification accesorials in shipfrom section")]
        public void GivenIAmOnQuoteListPageHavingSavedQuoteOfNotificationAccesorialsInShipfromSection()
        {
            navigationtoConfirmationPage_LTL.NavigatetoQuoteConfirmationFromQuoteListWithaccessorialfromsection(userType, customerAcc, userName,"Notification");
            WaitForElementVisible(attributeName_xpath, LTL_QuoteConfirmationPageHeader_Xpath, "confirmpage");
            quoteReferenceNumber = Gettext(attributeName_id, QC_RequestNumber_id);
            Click(attributeName_id, QuoteIconClick_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I am on QuoteList page having saved quote of notification accesorials in shipTo section")]
        public void GivenIAmOnQuoteListPageHavingSavedQuoteOfNotificationAccesorialsInShipToSection()
        {
            navigationtoConfirmationPage_LTL.NavigatetoQuoteConfirmationFromQuoteListWithaccessorialTOsection(userType, customerAcc, userName, "Notification");
            WaitForElementVisible(attributeName_xpath, LTL_QuoteConfirmationPageHeader_Xpath, "confirmpage");
            quoteReferenceNumber = Gettext(attributeName_id, QC_RequestNumber_id);
            Click(attributeName_id, QuoteIconClick_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I am expanded non expired Quote with Notification accessorial")]
        public void GivenIAmExpandedNonExpiredQuoteWithNotificationAccessorial()
        {
            navigationtoConfirmationPage_LTL.NavigatetoQuoteConfirmationFromQuoteListWithaccessorialfromsection(userType, customerAcc, userName,"Notification");
            WaitForElementVisible(attributeName_xpath, LTL_QuoteConfirmationPageHeader_Xpath, "confirmpage");
            quoteReferenceNumber = Gettext(attributeName_id, QC_RequestNumber_id);
            Click(attributeName_id, QuoteIconClick_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, quoteList.QuoteList_SearchBox_Xpath);
            SendKeys(attributeName_xpath, quoteList.QuoteList_SearchBox_Xpath, quoteReferenceNumber);
            VerifyElementVisible(attributeName_xpath, quoteList.QuoteList_RequestNumberInternal_Values_Xpath, quoteReferenceNumber);
            Click(attributeName_xpath, quoteList.QuoteList_QuoteDetailsIcon_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_id, quoteList.QuoteDetails_CreateShipmentButton_Id, "Create Shipment");
        }

       
        [Then(@"I will see the Notification accessorial auto populated in  add services & accessorials field of the Shipping From section")]
        public void ThenIWillSeeTheNotificationAccessorialAutoPopulatedInAddServicesAccessorialsFieldOfTheShippingFromSection()
        {
            scrollElementIntoView(attributeName_id, addShipmentLTL.FreightDesp_FirstItem_Weight_Id);
            Report.WriteLine("I will see the Notification accessorial auto populated in  add services & accessorials field of the Shipping from section");
            Assert.AreEqual(Gettext(attributeName_xpath, addshipment.ShippingTo_selectedServicesAccessorial_DropDown_xpath), "Notification");
        }
        
        [Then(@"I should not able to remove the Notification accessorial")]
        public void ThenIShouldNotAbleToRemoveTheNotificationAccessorial()
        {
            Report.WriteLine("I should not able to remove the Notification accessorial");
            VerifyElementNotEnabled(attributeName_xpath,addshipment.ShippingFrom_ServicesAccessorial_DropDown_xpath, "value");
        }
        
        [Then(@"I will see the Notification accessorial auto populated in  add services & accessorials field of the Shipping To section")]
        public void ThenIWillSeeTheNotificationAccessorialAutoPopulatedInAddServicesAccessorialsFieldOfTheShippingToSection()
        {
            scrollElementIntoView(attributeName_id, addShipmentLTL.FreightDesp_FirstItem_Weight_Id);
            Report.WriteLine("I will see the Notification accessorial auto populated in  add services & accessorials field of the Shipping To section");
           Assert.AreEqual(Gettext(attributeName_xpath, addshipment.ShippingFrom_selectedServicesAccessorial_DropDown_xpath), "Notification");

        }
    }
}
