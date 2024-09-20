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
    public class OverLength_SavedQuoteLTLToShipmentSteps:ObjectRepository
    {
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
        CommonQuoteNavigations navigationtoConfirmationPage_LTL = new CommonQuoteNavigations();
        Quotelist quoteList = new Quotelist();
        AddShipments addShipmentLTL = new AddShipments();
        string userType = "Internal";
        string customerAcc = "ZZZ - Czar Customer Test";
        string userName = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
        string quoteReferenceNumber = null;

        [Given(@"I am a shp\.entry, sales, sales management, operations, or station owner user")]
        public void GivenIAmAShp_EntrySalesSalesManagementOperationsOrStationOwnerUser()
        {
            
            string password = ConfigurationManager.AppSettings["password-crmOperation"].ToString();
            CrmLogin.LoginToCRMApplication(userName, password);
        }

        [Given(@"I am on QuoteList page")]
        public void GivenIAmOnQuoteListPage()
        {
            navigationtoConfirmationPage_LTL.NavigatetoQuoteConfirmationFromQuoteListWithServices(userType, customerAcc, userName, "10", "10", "10", "OverLength");
            WaitForElementVisible(attributeName_xpath, LTL_QuoteConfirmationPageHeader_Xpath, "confirmpage");
            quoteReferenceNumber = Gettext(attributeName_id, QC_RequestNumber_id);
            Click(attributeName_id, QuoteIconClick_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I have a non expired Quote with Dimensions")]
        public void GivenIHaveANonExpiredQuoteWithDimensions()
        {
            Click(attributeName_xpath, quoteList.QuoteList_SearchBox_Xpath);
            SendKeys(attributeName_xpath, quoteList.QuoteList_SearchBox_Xpath, quoteReferenceNumber);
            VerifyElementVisible(attributeName_xpath, quoteList.QuoteList_RequestNumberInternal_Values_Xpath, quoteReferenceNumber);
            Click(attributeName_xpath, quoteList.QuoteList_QuoteDetailsIcon_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_id, quoteList.QuoteDetails_CreateShipmentButton_Id, "Create Shipment");
        }

        [Given(@"I am on the Quote Listpage")]
        public void GivenIAmOnTheQuoteListpage()
        {
            navigationtoConfirmationPage_LTL.NavigatetoQuoteConfirmationFromQuoteListwithoutservices(userType, customerAcc, userName);
            WaitForElementVisible(attributeName_xpath, LTL_QuoteConfirmationPageHeader_Xpath, "confirmpage");
            quoteReferenceNumber = Gettext(attributeName_id, QC_RequestNumber_id);
            Click(attributeName_id, QuoteIconClick_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I have a non expired Quote without Dimensions")]
        public void GivenIHaveANonExpiredQuoteWithoutDimensions()
        {
            Click(attributeName_xpath, quoteList.QuoteList_SearchBox_Xpath);
            SendKeys(attributeName_xpath, quoteList.QuoteList_SearchBox_Xpath, quoteReferenceNumber);
            VerifyElementVisible(attributeName_xpath, quoteList.QuoteList_RequestNumberInternal_Values_Xpath, quoteReferenceNumber);
            Click(attributeName_xpath, quoteList.QuoteList_QuoteDetailsIcon_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_id, quoteList.QuoteDetails_CreateShipmentButton_Id, "Create Shipment");
        }
                
        [When(@"I click on Create shipment button")]
        public void WhenIClickOnCreateShipmentButton()
        {
            Click(attributeName_id, quoteList.QuoteDetails_CreateShipmentButton_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
        }
        
        [Then(@"Length, Width, Height fields and dimension type will be auto populated and those are not editable")]
        public void ThenLengthWidthHeightFieldsAndDimensionTypeWillBeAutoPopulatedAndThoseAreNotEditable()
        {
            scrollElementIntoView(attributeName_id, addShipmentLTL.FreightDesp_FirstItem_Weight_Id);
            Assert.AreEqual(GetValue(attributeName_id, addShipmentLTL.FreightDesp_FirstItem_Length_Id,"value"), "10");
            IsElementDisabled(attributeName_id, addShipmentLTL.FreightDesp_FirstItem_Length_Id, "Length");                   
            Report.WriteLine("Length Field auto populated and non editable");
            Assert.AreEqual(GetValue(attributeName_id, addShipmentLTL.FreightDesp_FirstItem_Width_Id,"value"), "10");
            IsElementDisabled(attributeName_id, addShipmentLTL.FreightDesp_FirstItem_Width_Id,"Width");            
            Report.WriteLine("Width Field auto populated and non editable");
            Assert.AreEqual(GetValue(attributeName_id, addShipmentLTL.FreightDesp_FirstItem_Height_Id, "value"), "10");
            IsElementDisabled(attributeName_id, addShipmentLTL.FreightDesp_FirstItem_Height_Id,"Height");            
            Report.WriteLine("Height Field auto populated and non editable");
        }
        
        [Then(@"Length, Width and Height fields will be blank and non editable")]
        public void ThenLengthWidthAndHeightFieldsWillBeBlankAndNonEditable()
        {
            scrollElementIntoView(attributeName_id, addShipmentLTL.FreightDesp_FirstItem_Weight_Id);
            Report.WriteLine("Length Field Non editable");
            Assert.AreEqual(GetValue(attributeName_id, addShipmentLTL.FreightDesp_FirstItem_Length_Id,"value"), "");
            IsElementDisabled(attributeName_id, addShipmentLTL.FreightDesp_FirstItem_Length_Id,"Length");            
            Report.WriteLine("Width Field Non editable");
            Assert.AreEqual(GetValue(attributeName_id, addShipmentLTL.FreightDesp_FirstItem_Width_Id,"value"), "");
            IsElementDisabled(attributeName_id, addShipmentLTL.FreightDesp_FirstItem_Width_Id,"Width");            
            Report.WriteLine("Height Field Non editable");
            Assert.AreEqual(GetValue(attributeName_id, addShipmentLTL.FreightDesp_FirstItem_Height_Id,"value"), "");
            IsElementDisabled(attributeName_id, addShipmentLTL.FreightDesp_FirstItem_Height_Id,"Height");            
        }
    }
}
