using System;
using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using TechTalk.SpecFlow;
using System.Collections.Generic;
using CRM.UITest.Entities.Proxy;
using System.Linq;
using System.IO;
using System.Threading;
using OpenQA.Selenium;
using CRM.UITest.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CRM.UITest.Scripts.TL_Rating_Tool.Quote_Confirmation_TL_.Quote_confirmation_notification
{
    [Binding]
    public class TruckloadRatingPage_QuoteConfirmationNotificationSteps : TruckloadRatingTool
    {
        
        [When(@"I pass data to all the required fields '(.*)','(.*)','(.*)','(.*)','(.*)','(.*)'")]
        public void WhenIPassDataToAllTheRequiredFields(string ShipFrom, string ShipTo, string FrieghtDescription, string Quantity, string WeightTL, string Insuredvalue)
        {
            SendKeys(attributeName_id, TL_ShippingFromZip_Textbox_ID, ShipFrom);
            WaitForElementPresent(attributeName_id, TL_ShippingToZip_Textbox_ID,"Shipping To");
            SendKeys(attributeName_id, TL_ShippingToZip_Textbox_ID, ShipTo);
            Click(attributeName_id, TL_PickupDate_Id);
            VerifyElementPresent(attributeName_xpath, TL_PickupCalendarPopup_xpath, "datepicker_days");
            DatePickerFromCalander(attributeName_xpath, TL_Selectingdates_xpath, 1, TL_selectingmonth_xpath);
            Click(attributeName_id, TL_DropoffDate_Id);
            VerifyElementPresent(attributeName_xpath, TL_DropoffCalendarPopup_xpath, "datepicker-days");
            DatePickerFromCalander(attributeName_xpath, TL_Selectingdates_xpath, 1, TL_selectingmonth_xpath);
            SendKeys(attributeName_id, EnterDescriptionField_id, FrieghtDescription);
            SendKeys(attributeName_id, TLQuantity_id, Quantity);
            SendKeys(attributeName_id, TLweight_id, WeightTL);
            SendKeys(attributeName_xpath, TL_InsuranceValue, Insuredvalue);
            WaitForElementPresent(attributeName_xpath, TL_GetQuoteLiveButton_Xpath, "Get Live Quote");

        }

        [When(@"I have clicked on Get Live Quote button")]
        public void WhenIHaveClickedOnGetLiveQuoteButton()
        {
            Report.WriteLine("Click on Get Live Quote Button");
        
            try
			{
                Click(attributeName_xpath, TL_GetQuoteLiveButton_Xpath);
                WaitForElementPresent(attributeName_xpath, TL_GetQuoteLiveButton_Xpath, "Get Live Quote");
                IsElementDisabled(attributeName_xpath, TL_GetQuoteLiveButton_Xpath, "Get Live Quote");
                WaitForElementPresent(attributeName_xpath, TL_LiveQuoteNotificationModal_Xpath, "Get Live Quote");
            }
			catch(Exception e)
			{
				Console.WriteLine(e);
			}
            
            WaitForElementPresent(attributeName_xpath, TL_LiveQuoteNotificationModal_Xpath, "Get Live Quote");
            Thread.Sleep(20000);
        }

        [Then(@"I must be able to view a (.*) screen for the quote submitted")]
        public void ThenIMustBeAbleToViewAScreenForTheQuoteSubmitted(string QuoteConfirmation)
        {
            Report.WriteLine("Quote confirmation Notification");
            
            WaitForElementPresent(attributeName_xpath, TL_LiveQuoteNotificationModal_Xpath, "Get Live Quote");
            try
            {
                Thread.Sleep(8000);
                Verifytext(attributeName_xpath, TL_LiveQuoteNotificationModal_Xpath, QuoteConfirmation);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }

        [Then(@"I must be able to view OK button on the Quote Confirmation screen")]
        public void ThenIMustBeAbleToViewOKButtonOnTheQuoteConfirmationScreen()
        {
            Report.WriteLine("View of OK button in Quote confirmation notification");
            Verifytext(attributeName_xpath, TL_LiveQuoteNotificationOKButton_Xpath, "OK");
        }
        
        [Then(@"when I click on OK button i must be navigated back to TL Rating Tool (.*) page\.")]
        public void ThenWhenIClickOnOKButtonIMustBeNavigatedBackToTLRatingToolPage_(string ProjectedAmount)
        {
            Report.WriteLine("Click on OK button in Quote confirmtion modal");
            Click(attributeName_xpath, TL_LiveQuoteNotificationOKButton_Xpath);
            Thread.Sleep(5000);
            WaitForElementPresent(attributeName_xpath, TL_ProjectedAmountPage_Title_Xpath, ProjectedAmount);
            Verifytext(attributeName_xpath, TL_ProjectedAmountPage_Title_Xpath, ProjectedAmount);
        }
        
       
        [Then(@"The Quote Reference number in the Quote Confirmation modal must match with the database")]
        public void ThenTheQuoteReferenceNumberInTheQuoteConfirmationModalMustMatchWithTheDatabase()
        {
            Report.WriteLine("Quote reference number");
            string ReferenceNum = Gettext(attributeName_xpath, TL_LiveQuoteNotificationQuoteNum_Xpath);
            string[] values = ReferenceNum.Split(':');
            string QuoteNumber = values[1];
            string quoteNumber = DBHelper.GetQuoteNumber();
            Assert.AreEqual(QuoteNumber, quoteNumber);           
        }

        [Then(@"background color of the origin zip code textbox should turn red and error message should be displayed in GetQuote\(TL\) page")]
        public void ThenBackgroundColorOfTheOriginZipCodeTextboxShouldTurnRedAndErrorMessageShouldBeDisplayedInGetQuoteTLPage()
        {
            var ActualbackgroundColor = GetCSSValue(attributeName_id, TL_ShippingFromZip_Textbox_ID, "background-color");
            string ExpectedbackgroundColor = "rgba(251, 236, 236, 1)";
            Assert.AreEqual(ExpectedbackgroundColor, ActualbackgroundColor);
        }

        [Then(@"background color of the destination zip code textbox should turn red and error message should be displayed in GetQuote\(TL\) page")]
        public void ThenBackgroundColorOfTheDestinationZipCodeTextboxShouldTurnRedAndErrorMessageShouldBeDisplayedInGetQuoteTLPage()
        {
            string ActualbackgroundColor = GetCSSValue(attributeName_id, TL_ShippingToZip_Textbox_ID, "background-color");
            string ExpectedbackgroundColor = "rgba(251, 236, 236, 1)";
            Assert.AreEqual(ExpectedbackgroundColor, ActualbackgroundColor);
        }

        [Then(@"background color of the Item Description textbox should turn red highlighted")]
        public void ThenBackgroundColorOfTheItemDescriptionTextboxShouldTurnRedHighlighted()
        {
            string ActualbackgroundColor = GetCSSValue(attributeName_id, EnterDescriptionField_id, "background-image");
            string ExpectedbackgroundColor = "url(\"http://dlsww-dev.rrd.com/images/formicons.png\"), linear-gradient(rgb(251, 236, 236), rgb(251, 236, 236))";
            Assert.AreEqual(ExpectedbackgroundColor, ActualbackgroundColor);
        }

        [Then(@"background color of the Quantity textbox should turn red highlighted")]
        public void ThenBackgroundColorOfTheQuantityTextboxShouldTurnRedHighlighted()
        {
            string ActualbackgroundColor = GetCSSValue(attributeName_id, TLQuantity_id, "background-image");
            string ExpectedbackgroundColor = "url(\"http://dlsww-dev.rrd.com/images/formicons.png\"), linear-gradient(rgb(251, 236, 236), rgb(251, 236, 236))";
            Assert.AreEqual(ExpectedbackgroundColor, ActualbackgroundColor);
        }

        [Then(@"background color of the Weight textbox should turn red highlighted")]
        public void ThenBackgroundColorOfTheWeightTextboxShouldTurnRedHighlighted()
        {
            string ActualbackgroundColor = GetCSSValue(attributeName_id, TLweight_id, "background-image");
            string ExpectedbackgroundColor = "url(\"http://dlsww-dev.rrd.com/images/formicons.png\"), linear-gradient(rgb(251, 236, 236), rgb(251, 236, 236))";
            Assert.AreEqual(ExpectedbackgroundColor, ActualbackgroundColor);
        }

    }
}
