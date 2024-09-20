
using TechTalk.SpecFlow;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using CRM.UITest.CommonMethods;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;



namespace CRM.UITest.Scripts.Quote.LTL.Quote_Confirmation_Screen
{
    [Binding]
    public class GetQuotePage_TabbingToItemfieldSteps : Quotelist
    {

        CommonMethodsCrm crm = new CommonMethodsCrm();
        RateToShipmentLTL RTS = new RateToShipmentLTL();
        AddQuoteLTL AQL = new AddQuoteLTL();

        [Given(@"I am a shp\.entry, shp\.inquiry, operations, sales, sales management, or station owner user (.*),(.*)")]
        public void GivenIAmAShp_EntryShp_InquiryOperationsSalesSalesManagementOrStationOwnerUser(string userName, string password)
        {
            crm.LoginToCRMApplication(userName, password);
        }

        [When(@"I m on Get Quote page (.*),(.*)")]
        public void WhenIMOnGetQuotePage(string UserType, string CustomerName)
        {
            RTS.NaviagteToQuoteList();
            AQL.Add_QuoteLTL(UserType, CustomerName);
            Click(attributeName_id, ClearAddress_OriginId);
        }



        [When(@"I am highlighting a class or saved item from the Select or search for a class or saved item field")]
        public void WhenIAmHighlightingAClassOrSavedItemFromTheSelectOrSearchForAClassOrSavedItemField()
        {

            Click(attributeName_id, SelectSavedItem_Id);
        }


        [When(@"I click on the tab button")]
        public void WhenIClickOnTheTabButton()
        {

            IWebElement _SelectDropDownValue = GlobalVariables.webDriver.FindElement(By.Id(SelectSavedItem_Id));
            _SelectDropDownValue.SendKeys(Keys.Down);
            _SelectDropDownValue.SendKeys(Keys.Tab);
            

        }

        [When(@"I am entering the item value")]
        public void WhenIAmEnteringTheItemValue()
        {

            IWebElement _SelectedDropdownValue = GlobalVariables.webDriver.FindElement(By.Id(SelectSavedItem_Id));
            _SelectedDropdownValue.SendKeys("200");
        }


        [Then(@"the blinking cursor will be displayed at the end of the description displayed in the search field for a class or saved item")]
        public void ThenTheBlinkingCursorWillBeDisplayedAtTheEndOfTheDescriptionDisplayedInTheSearchFieldForAClassOrSavedItem()
        {
            
            IWebElement _activeElementSelectSave_Item = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            string SelectSaveItemId = _activeElementSelectSave_Item.GetAttribute("id");
            Assert.AreEqual(SelectSaveItemId, "Select-saveditem-0");
        }


    }
}
