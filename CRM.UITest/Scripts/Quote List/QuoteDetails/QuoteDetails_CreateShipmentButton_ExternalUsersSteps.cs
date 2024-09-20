using System;
using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Threading;

namespace CRM.UITest.Scripts.Quote_List.QuoteDetails
{
    [Binding]
    public class QuoteDetails_CreateShipmentButton_ExternalUsersSteps : Quotelist
    {
        [When(@"I expand any new Quote in the Quote list page")]
        public void WhenIExpandAnyNewQuoteInTheQuoteListPage()
        {
            IList<IWebElement> Rowcount = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_NoOfRows_Xpath));
            if (Rowcount.Count > 0)
            {
                Report.WriteLine("Expand Quote Details");
                IList<IWebElement> FirstRow = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_NoOfRows_Xpath));
                Click(attributeName_xpath, QuoteListDetails_ExpandButton_Xpath);




            }
            else
            {
                Report.WriteLine("No data found");
            }

        }

        [Then(@"I should see create shipment button in quote details section")]
        public void ThenIShouldSeeCreateShipmentButtonInQuoteDetailsSection()
        {
            Report.WriteLine("Create Shipment Button");
            VerifyElementPresent(attributeName_id, QuoteDetails_CreateShipButton_Id, "Create Shipment");

        }


        [When(@"I click on create shipment button"), Scope(Feature = "QuoteDetails_CreateShipmentButton_ExternalUsers")]
        public void WhenIClickOnCreateShipmentButton()
        {
            Report.WriteLine("Click Create shipment button");
            Thread.Sleep(5000);
            Click(attributeName_id, QuoteDetails_CreateShipButton_Id);
        }

        [Then(@"Confirmation popup should be displayed")]
        public void ThenConfirmationPopupShouldBeDisplayed()
        {
            Report.WriteLine("Display of confirmation modal");
            Verifytext(attributeName_xpath, QuoteConfirmation_PopupLabel_Xpath, "Confirm Shipment");

        }

        [Then(@"I click on Cancel button")]
        public void ThenIClickOnCancelButton()
        {
            Report.WriteLine("Cancel button");
            Click(attributeName_xpath, QuoteDetails_CancelButton_Xpath);
        }

        [Then(@"User should remain in quote list page")]
        public void ThenUserShouldRemainInQuoteListPage()
        {
            Report.WriteLine("Remain in Quote List page");
            Verifytext(attributeName_xpath, QuoteList_PageTitle_Xpath, "Quotes");
        }

        [Then(@"I click on Yes button")]
        public void ThenIClickOnYesButton()
        {
            Report.WriteLine("Click on YES Button");
            Click(attributeName_id, QuoteDetails_PopUpYes_Button_Id);
        }




        [Then(@"User should be taken to the shipment location and dates page")]
        public void ThenUserShouldBeTakenToTheShipmentLocationAndDatesPage()
        {
            Report.WriteLine("ShipmentLocation and dates page");
            Verifytext(attributeName_xpath, ShipLocationDatepage_Label_Xpath, "Shipment Locations and Dates");

        }

    }
}
