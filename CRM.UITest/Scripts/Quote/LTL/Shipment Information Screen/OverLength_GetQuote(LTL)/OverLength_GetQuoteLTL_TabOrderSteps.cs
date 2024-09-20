using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Configuration;
using System.Threading;

namespace CRM.UITest.Scripts.Quote.LTL.Shipment_Information_Screen.OverLength_GetQuote_LTL_
{
    [Binding]
    public class OverLength_GetQuoteLTL_TabOrderSteps: ObjectRepository
    {
        AddQuoteLTL quoteLtl = new AddQuoteLTL();
        string userType = "Internal";
        string customerAcc = "ZZZ - Czar Customer Test";        
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();

        [Given(@"I am a shp\.inquiry,shp\.entry, operations, sales, sales management, or station owner user")]
        public void GivenIAmAShp_InquiryShp_EntryOperationsSalesSalesManagementOrStationOwnerUser()
        {
            string username = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
            string password = ConfigurationManager.AppSettings["password-crmOperation"].ToString();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"I am on get Quote LTL page")]
        public void GivenIAmOnGetQuoteLTLPage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            quoteLtl.NaviagteToQuoteList();
            quoteLtl.Add_QuoteLTL(userType, customerAcc);
        }
        
        [When(@"I have selected Overlength in Shipping From section")]
        public void WhenIHaveSelectedOverlengthInShippingFromSection()
        {
            quoteLtl.selectShippingfromServices("Overlength");
        }

        [When(@"I have selected Overlength in Shipping To section")]
        public void WhenIHaveSelectedOverlengthInShippingToSection()
        {
            quoteLtl.selectShippingToServices("Overlength");
        }

        [When(@"I have not selected Overlength services and accessorials in Shipping From section")]
        public void WhenIHaveNotSelectedOverlengthServicesAndAccessorialsInShippingFromSection()
        {
            quoteLtl.selectShippingfromServices("Appointment");            
        }

        [When(@"I have not selected Overlength services and accessorials in Shipping To section")]
        public void WhenIHaveNotSelectedOverlengthServicesAndAccessorialsInShippingToSection()
        {
            quoteLtl.selectShippingToServices("Appointment");
        }

        [When(@"I have not selected any services and accessorials in Shipping From section")]
        public void WhenIHaveNotSelectedAnyServicesAndAccessorialsInShippingFromSection()
        {
            Click(attributeName_xpath, LTL_ServicesAndAccessorials_ShipFrom_Xpath);
        }

        [When(@"I have not selected any services and accessorials in Shipping To section")]
        public void WhenIHaveNotSelectedAnyServicesAndAccessorialsInShippingToSection()
        {
            Click(attributeName_xpath, LTL_ServicesAndAccessorials_ShipTo_Xpath);
        }
        
        [Then(@"Tab order will be from Shipping From, Shipping To zip/postal code, classification, weight, length, width, height and View Quote Results button")]
        public void ThenTabOrderWillBeFromShippingFromShippingToZipPostalCodeClassificationWeightLengthWidthHeightAndViewQuoteResultsButton()
        {
            Report.WriteLine("Hit Tab");
            Click(attributeName_id, ClearAddress_OriginId);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ClearAddress_DestId);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, LTL_ClearItem_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, LTL_OriginZipPostal_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            IWebElement _activeElement = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            _activeElement.SendKeys(Keys.Tab);
            IWebElement _activeElementTo = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            string activeElementIdForShippingToZip = _activeElementTo.GetAttribute("id");
            Assert.AreEqual(ZipcodeforShippingTo_id, activeElementIdForShippingToZip);
            Report.WriteLine("Arrived on Shipping To Enter zip/postal code... field on hitting Tab");
            _activeElementTo.SendKeys(Keys.Tab);            
            IWebElement _activeElementItem = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            string activeElementIdForClassification = _activeElementItem.GetAttribute("id");            
            Assert.AreEqual(ClassorSavedItemField_id, activeElementIdForClassification);
            Report.WriteLine("Arrived on Select or search for a class or saved item... field on hitting Tab");
            _activeElementItem.SendKeys(Keys.Tab);
            IWebElement _activeElementWeight = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            string activeElementIdForWeight = _activeElementWeight.GetAttribute("id");
            Assert.AreEqual(weight_id, activeElementIdForWeight);
            Report.WriteLine("Arrived on Enter a Weight field on hitting Tab");
            _activeElementWeight.SendKeys(Keys.Tab);
            IWebElement _activeElementLength = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            string activeElementIdForLength = _activeElementLength.GetAttribute("id");
            Assert.AreEqual(LTL_Length_Id, activeElementIdForLength);
            Report.WriteLine("Arrived on Length... field on hitting Tab");
            _activeElementLength.SendKeys(Keys.Tab);
            IWebElement _activeElementWidth = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            string activeElementIdForWidth = _activeElementWidth.GetAttribute("id");
            Assert.AreEqual(LTL_Width_Id, activeElementIdForWidth);
            Report.WriteLine("Arrived on Width... field on hitting Tab");
            _activeElementWidth.SendKeys(Keys.Tab);
            IWebElement _activeElementHeight = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            string activeElementIdForHeight = _activeElementHeight.GetAttribute("id");
            Assert.AreEqual(LTL_Height_Id, activeElementIdForHeight);
            Report.WriteLine("Arrived on Height... field on hitting Tab");
            _activeElementHeight.SendKeys(Keys.Tab);
            IWebElement _activeElementQuoteResults = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            string activeElementIdForViewQuoteResults = _activeElementQuoteResults.GetAttribute("id");
            Assert.AreEqual(LTL_ViewQuoteResults_Id, activeElementIdForViewQuoteResults);
            Report.WriteLine("Arrived on View Quote Results button on hitting Tab");
        }

        [Then(@"Tab order for additional Item from classification, weight, length, width, height and View Quote Results button")]
        public void ThenTabOrderForAdditionalItemFromClassificationWeightLengthWidthHeightAndViewQuoteResultsButton()
        {
            MoveToElement(attributeName_xpath, LTL_AddAdditionalItemLink_Xpath);
            Click(attributeName_xpath, LTL_AddAdditionalItemLink_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Hit Tab");
            Click(attributeName_id, LTL_Additional_SelectClass_Id);
            IWebElement _activeElement = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            _activeElement.SendKeys(Keys.Tab);
            IWebElement _activeElementWeight = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            string activeElementIdForFirstAdditionalItemWeight = _activeElementWeight.GetAttribute("id");
            Assert.AreEqual(LTL_Additinal_Weight_Id, activeElementIdForFirstAdditionalItemWeight);
            Report.WriteLine("Arrived on Enter a Weight field of First additional Item on hitting Tab");
            _activeElementWeight.SendKeys(Keys.Tab);
            IWebElement _activeElementLength = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            string activeElementIdForFirstAdditionalItemLength = _activeElementLength.GetAttribute("id");
            Assert.AreEqual(LTL_Quote_Additional_Item1_Length_Id, activeElementIdForFirstAdditionalItemLength);
            Report.WriteLine("Arrived on Length... field of First additional Item on hitting Tab");
            _activeElementLength.SendKeys(Keys.Tab);
            IWebElement _activeElementWidth = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            string activeElementIdForFirstAdditionalItemWidth = _activeElementWidth.GetAttribute("id");
            Assert.AreEqual(LTL_Quote_Additional_Item1_Width_Id, activeElementIdForFirstAdditionalItemWidth);
            Report.WriteLine("Arrived on Width... field of First additional Item on hitting Tab");
            _activeElementWidth.SendKeys(Keys.Tab);
            IWebElement _activeElementHeight = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            string activeElementIdForFirstAdditionalItemHeight = _activeElementHeight.GetAttribute("id");
            Assert.AreEqual(LTL_Quote_Additional_Item1_Height_Id, activeElementIdForFirstAdditionalItemHeight);
            Report.WriteLine("Arrived on Height... field of First additional Item on hitting Tab");
            _activeElementHeight.SendKeys(Keys.Tab);
            IWebElement _activeElementQuoteResults = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            string activeElementId = _activeElementQuoteResults.GetAttribute("id");
            Assert.AreEqual(LTL_ViewQuoteResults_Id, activeElementId);
            Report.WriteLine("Arrived on View Quote Results button on hitting Tab");
        }
        
        [Then(@"Back Tab order will be from View Quote Results button, Height, Width, Length, Weight, Classification, ShippingTo and shippingFrom zip/postal code")]
        public void ThenBackTabOrderWillBeFromViewQuoteResultsButtonHeightWidthLengthWeightClassificationShippingToAndShippingFromZipPostalCode()
        {
            Click(attributeName_id, ClearAddress_OriginId);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ClearAddress_DestId);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, LTL_ClearItem_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, LTL_Height_Id);
            IWebElement _activeElement = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            _activeElement.SendKeys(Keys.Tab);
            IWebElement _activeElementQuoteResults = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            string activeElementId = _activeElementQuoteResults.GetAttribute("id");
            Assert.AreEqual(LTL_ViewQuoteResults_Id, activeElementId);
            Report.WriteLine("On View Quote Results button");
            _activeElementQuoteResults.SendKeys(Keys.Shift + Keys.Tab);
            IWebElement _activeElementHeight = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            Report.WriteLine("Arrived on Height... field on hitting Shift+Tab");
            string activeElementIdForHeight = _activeElementHeight.GetAttribute("id");
            Assert.AreEqual(LTL_Height_Id, activeElementIdForHeight);
            _activeElementHeight.SendKeys(Keys.Shift + Keys.Tab);
            IWebElement _activeElementWidth = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            Report.WriteLine("Arrived on Width... field on hitting Shift+Tab");
            string activeElementIdForWidth = _activeElementWidth.GetAttribute("id");
            Assert.AreEqual(LTL_Width_Id, activeElementIdForWidth);
            _activeElementWidth.SendKeys(Keys.Shift + Keys.Tab);
            IWebElement _activeElementLength = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            Report.WriteLine("Arrived on Length... field on hitting Shift+Tab");
            string activeElementIdForLength = _activeElementLength.GetAttribute("id");
            Assert.AreEqual(LTL_Length_Id, activeElementIdForLength);
            _activeElementLength.SendKeys(Keys.Shift + Keys.Tab);
            Report.WriteLine("Arrived on Enter a Weight field on hitting Shift+Tab");
            IWebElement _activeElementWeight = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            string activeElementIdForWeight = _activeElementWeight.GetAttribute("id");
            Assert.AreEqual(weight_id, activeElementIdForWeight);
            _activeElementWeight.SendKeys(Keys.Shift + Keys.Tab);
            IWebElement _activeElementItem = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            Report.WriteLine("Arrived on Select or search for a class or saved item... field on hitting Shift+Tab");
            string activeElementIdForClassification = _activeElementItem.GetAttribute("id");
            Assert.AreEqual(ClassorSavedItemField_id, activeElementIdForClassification);
            _activeElementItem.SendKeys(Keys.Shift + Keys.Tab);
            IWebElement _activeElementDestinationZip = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            Report.WriteLine("Arrived on Shipping To Enter zip/postal code... field on hitting Shift+Tab");
            string activeElementIdForShippingToZip = _activeElementDestinationZip.GetAttribute("id");
            Assert.AreEqual(ZipcodeforShippingTo_id, activeElementIdForShippingToZip);
            _activeElementDestinationZip.SendKeys(Keys.Shift + Keys.Tab);
            IWebElement _activeElementOriginZip = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            Report.WriteLine("Arrived on Shipping From Enter zip/postal code... field on hitting Shift+Tab");
            string activeElementIdForShippingFromZip = _activeElementOriginZip.GetAttribute("id");
            Assert.AreEqual(ZipcodeforShippingFrom_id, activeElementIdForShippingFromZip);
        }
        
        [Then(@"Back Tab order for additional Item from View Quote Results Button, Height, Width, Length, Weight, classification")]
        public void ThenBackTabOrderForAdditionalItemFromViewQuoteResultsButtonHeightWidthLengthWeightClassification()
        {
            MoveToElement(attributeName_xpath, LTL_AddAdditionalItemLink_Xpath);
            Click(attributeName_xpath, LTL_AddAdditionalItemLink_Xpath);
            WaitForElementVisible(attributeName_id, LTL_Additional_SelectClass_Id, "classification");
            Click(attributeName_id, LTL_Quote_Additional_Item1_Height_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            IWebElement _activeElement = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            _activeElement.SendKeys(Keys.Tab);
            IWebElement _activeElementQuoteResults = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            string activeElementId = _activeElementQuoteResults.GetAttribute("id");
            Assert.AreEqual(LTL_ViewQuoteResults_Id, activeElementId);
            Report.WriteLine("On View Quote Results button");
            _activeElementQuoteResults.SendKeys(Keys.Shift + Keys.Tab);
            IWebElement _activeElementHeight = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            Report.WriteLine("Arrived on Add Additional Item First Height... field on hitting Shift+Tab");
            string activeElementIdForFirstAdditionalItemHeight = _activeElementHeight.GetAttribute("id");
            Assert.AreEqual(LTL_Quote_Additional_Item1_Height_Id, activeElementIdForFirstAdditionalItemHeight);
            _activeElementHeight.SendKeys(Keys.Shift + Keys.Tab);
            IWebElement _activeElementWidth = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            Report.WriteLine("Arrived on Add Additional Item First Width... field on hitting Shift+Tab");
            string activeElementIdForFirstAdditionalItemWidth = _activeElementWidth.GetAttribute("id");
            Assert.AreEqual(LTL_Quote_Additional_Item1_Width_Id, activeElementIdForFirstAdditionalItemWidth);
            _activeElementWidth.SendKeys(Keys.Shift + Keys.Tab);
            IWebElement _activeElementLength = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            Report.WriteLine("Arrived on Add Additional Item First Length... field on hitting Shift+Tab");
            string activeElementIdForFirstAdditionalItemLength = _activeElementLength.GetAttribute("id");
            Assert.AreEqual(LTL_Quote_Additional_Item1_Length_Id, activeElementIdForFirstAdditionalItemLength);
            _activeElementLength.SendKeys(Keys.Shift + Keys.Tab);
            IWebElement _activeElementWeight = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            Report.WriteLine("Arrived on Add Additional Item First -Enter a Weight field on hitting Shift+Tab");
            string activeElementIdForFirstAdditionalItemWeight = _activeElementWeight.GetAttribute("id");
            Assert.AreEqual(LTL_Additinal_Weight_Id, activeElementIdForFirstAdditionalItemWeight);
            _activeElementWeight.SendKeys(Keys.Shift + Keys.Tab);
            IWebElement _activeElementItem = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            Report.WriteLine("Arrived on Add Additional Item First -Select or search for a class or saved item... field on hitting Shift+Tab");
            string activeElementIdForFirstAdditionalItemClassification = _activeElementItem.GetAttribute("id");
            Assert.AreEqual(LTL_Additional_SelectClass_Id, activeElementIdForFirstAdditionalItemClassification);            
        }
        
        [Then(@"Tab order will be from Shipping From, Shipping To zip/postal code, classification, weight and View Quote Results button")]
        public void ThenTabOrderWillBeFromShippingFromShippingToZipPostalCodeClassificationWeightAndViewQuoteResultsButton()
        {
            Click(attributeName_id, ClearAddress_OriginId);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ClearAddress_DestId);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, LTL_ClearItem_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Hit Tab");
            Click(attributeName_id, LTL_OriginZipPostal_Id);
            IWebElement _activeElement = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            _activeElement.SendKeys(Keys.Tab);
            IWebElement _activeElementDestinationZip = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            string activeElementIdForShippingToZip = _activeElementDestinationZip.GetAttribute("id");
            Assert.AreEqual(ZipcodeforShippingTo_id, activeElementIdForShippingToZip);
            Report.WriteLine("Arrived on Shipping To Enter zip/postal code... field");
            _activeElementDestinationZip.SendKeys(Keys.Tab);
            IWebElement _activeElementItem = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            string activeElementIdForClassification = _activeElementItem.GetAttribute("id");
            Assert.AreEqual(ClassorSavedItemField_id, activeElementIdForClassification);
            Report.WriteLine("Arrived on Select or search for a class or saved item... field");
            _activeElementItem.SendKeys(Keys.Tab);
            IWebElement _activeElementWeight = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            string activeElementIdForWeight = _activeElementWeight.GetAttribute("id");
            Assert.AreEqual(weight_id, activeElementIdForWeight);
            Report.WriteLine("Arrived on Enter a Weight field");
            _activeElementWeight.SendKeys(Keys.Tab);
            IWebElement _activeElementQuoteResults = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            string activeElementIdForViewQuoteResults = _activeElementQuoteResults.GetAttribute("id");
            Assert.AreEqual(LTL_ViewQuoteResults_Id, activeElementIdForViewQuoteResults);
            Report.WriteLine("Arrived on View Quote Results button");
        }
        
        [Then(@"Additional Item tab order will be from classification, weight and View Quote Results button")]
        public void ThenAdditionalItemTabOrderWillBeFromClassificationWeightAndViewQuoteResultsButton()
        {
            MoveToElement(attributeName_xpath, LTL_AddAdditionalItemLink_Xpath);
            Click(attributeName_xpath, LTL_AddAdditionalItemLink_Xpath);
            WaitForElementVisible(attributeName_id, LTL_Additional_SelectClass_Id, "classification");
            Report.WriteLine("Hit Tab");
            Click(attributeName_id, LTL_Additional_SelectClass_Id);
            IWebElement _activeElement = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            _activeElement.SendKeys(Keys.Tab);
            IWebElement _activeElementWeight = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            string activeElementIdForFirstAdditionalItemWeight = _activeElementWeight.GetAttribute("id");
            Assert.AreEqual(LTL_Additinal_Weight_Id, activeElementIdForFirstAdditionalItemWeight);
            Report.WriteLine("Arrived on Enter a Weight field of First additional Item");
            _activeElementWeight.SendKeys(Keys.Tab);
            IWebElement _activeElementQuoteResults = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            string activeElementId = _activeElementQuoteResults.GetAttribute("id");
            Assert.AreEqual(LTL_ViewQuoteResults_Id, activeElementId);
            Report.WriteLine("Arrived on View Quote Results button");
        }
        
        [Then(@"Back Tab order will be from View Quote Results button, Weight, Classification, Shipping To and shipping From zip/postal code")]
        public void ThenBackTabOrderWillBeFromViewQuoteResultsButtonWeightClassificationShippingToAndShippingFromZipPostalCode()
        {
            Click(attributeName_id, ClearAddress_OriginId);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ClearAddress_DestId);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, LTL_ClearItem_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, weight_id);
            IWebElement _activeElement = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            _activeElement.SendKeys(Keys.Tab);
            IWebElement _activeElementQuoteResults = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            string activeElementId = _activeElementQuoteResults.GetAttribute("id");
            Assert.AreEqual(LTL_ViewQuoteResults_Id, activeElementId);
            Report.WriteLine("On View Quote Results button");
            _activeElementQuoteResults.SendKeys(Keys.Shift + Keys.Tab);
            IWebElement _activeElementWeight = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            Report.WriteLine("Arrived on Enter a Weight field on hitting Shift+Tab");
            string activeElementIdForWeight = _activeElementWeight.GetAttribute("id");
            Assert.AreEqual(weight_id, activeElementIdForWeight);
            _activeElementWeight.SendKeys(Keys.Shift + Keys.Tab);
            IWebElement _activeElementItem = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            Report.WriteLine("Arrived on Select or search for a class or saved item... field on hitting Shift+Tab");
            string activeElementIdForClassification = _activeElementItem.GetAttribute("id");
            Assert.AreEqual(ClassorSavedItemField_id, activeElementIdForClassification);
            _activeElementItem.SendKeys(Keys.Shift + Keys.Tab);
            IWebElement _activeElementDestinationZip = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            Report.WriteLine("Arrived on Shipping To Enter zip/postal code... field on hitting Shift+Tab");
            string activeElementIdForShippingToZip = _activeElementDestinationZip.GetAttribute("id");
            Assert.AreEqual(ZipcodeforShippingTo_id, activeElementIdForShippingToZip);
            _activeElementDestinationZip.SendKeys(Keys.Shift + Keys.Tab);
            IWebElement _activeElementOriginZip = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            Report.WriteLine("Arrived on Shipping From Enter zip/postal code... field on hitting Shift+Tab");
            string activeElementIdForShippingFromZip = _activeElementOriginZip.GetAttribute("id");
            Assert.AreEqual(ZipcodeforShippingFrom_id, activeElementIdForShippingFromZip);
        }
        
        [Then(@"Back Tab order for additional Item from View Quote Results Button, Weight, classification")]
        public void ThenBackTabOrderForAdditionalItemFromViewQuoteResultsButtonWeightClassification()
        {
            MoveToElement(attributeName_xpath, LTL_AddAdditionalItemLink_Xpath);
            Click(attributeName_xpath, LTL_AddAdditionalItemLink_Xpath);
            WaitForElementVisible(attributeName_id, LTL_Additional_SelectClass_Id, "classification");
            Click(attributeName_id, LTL_Additinal_Weight_Id);
            IWebElement _activeElement = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            _activeElement.SendKeys(Keys.Tab);
            IWebElement _activeElementQuoteResults = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            string activeElementId = _activeElementQuoteResults.GetAttribute("id");
            Assert.AreEqual(LTL_ViewQuoteResults_Id, activeElementId);
            Report.WriteLine("On View Quote Results button");
            _activeElementQuoteResults.SendKeys(Keys.Shift + Keys.Tab);
            IWebElement _activeElementWeight = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            Report.WriteLine("Arrived on Add Additional Item First -Enter a Weight field on hitting Shift+Tab");
            string activeElementIdForFirstAdditionalItemWeight = _activeElementWeight.GetAttribute("id");
            Assert.AreEqual(LTL_Additinal_Weight_Id, activeElementIdForFirstAdditionalItemWeight);
            _activeElementWeight.SendKeys(Keys.Shift + Keys.Tab);
            IWebElement _activeElementItem = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            Report.WriteLine("Arrived on Add Additional Item First -Select or search for a class or saved item... field on hitting Shift+Tab");
            string activeElementIdForFirstAdditionalItemClassification = _activeElementItem.GetAttribute("id");
            Assert.AreEqual(LTL_Additional_SelectClass_Id, activeElementIdForFirstAdditionalItemClassification);
        }
    }
}
