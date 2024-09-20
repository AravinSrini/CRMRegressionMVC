using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using System.Text;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Information_Screen
{
    [Binding]
    public class CarrierResults_TermsAndConditionDisclaimerSteps : AddShipments
    {
        CommonMethodsCrm crm = new CommonMethodsCrm();
        AddShipmentLTL ltl = new AddShipmentLTL();
        AddShipmentLTL data = new AddShipmentLTL();

        [When(@"I click on the '(.*)' hyperlink")]
        public void WhenIClickOnTheHyperlink(string p0)
        {
            scrollElementIntoView(attributeName_xpath, LTL_ShipinformationPage_TermsandCond_Xpath);
            Click(attributeName_xpath, LTL_ShipinformationPage_TermsandCond_Xpath);
        }

        [Then(@"I will be presented with a Disclaimer noting that ""By creating an Insured Shipment you agree to the Terms & Conditions\.")]
        public void ThenIWillBePresentedWithADisclaimerNotingThatByCreatingAnInsuredShipmentYouAgreeToTheTermsConditions_()
        {
           
            scrollElementIntoView(attributeName_xpath, LTL_ShipinformationPage_TermsandCond_Xpath);
            MoveToElement(attributeName_xpath, LTL_ShipinformationPage_TermsandCond_Xpath);
            String expectedText = "* Quote expires on the Actual Ship Date if less than the expiration date.\r \n ** Creating an insured shipment means you agree to the terms and conditions";
            String actualText = Gettext(attributeName_xpath, LTL_ShipinformationPage_VerbiageText_Xpath);

            actualText.Contains(expectedText);
            Report.WriteLine("Text is available");

        }

        [Then(@"the verbiage Terms & Conditions should be hyperlinked")]
        public void ThenTheVerbiageTermsConditionsShouldBeHyperlinked()
        {
            
            Click(attributeName_xpath, LTL_ShipinformationPage_TermsandCond_Xpath);
        }

        [Then(@"I will be presented with the T&C modal")]
        public void ThenIWillBePresentedWithTheTCModal()
        {

            String expectedText = "Terms And Conditions Of Coverage";
            String actualText = Gettext(attributeName_xpath, LTL_ShipinformationPage_ModalHeader_Xpath);
            //Assert.AreEqual((actualText), expectedText);
            actualText.Contains(expectedText);
            Report.WriteLine("Terms and Condition modal has opened");


        }

        [When(@"I click on the '(.*)' hyperlink from quote result page")]
        public void WhenIClickOnTheHyperlinkFromQuoteResultPage(string p0)
        {
            
            scrollElementIntoView(attributeName_xpath, LTL_QuoteInformationPage_TermsandCond_Xpath);
            MoveToElement(attributeName_xpath, LTL_QuoteInformationPage_TermsandCond_Xpath);
            Click(attributeName_xpath, LTL_QuoteInformationPage_TermsandCond_Xpath);



        }



        [Then(@"I will be presented with the T&C modal from quote result page")]
        public void ThenIWillBePresentedWithTheTCModalFromQuoteResultPage()
        {
            
            String expectedtext = "Terms And Conditions Of Coverage";
            String actualText = Gettext(attributeName_xpath, LTL_QuoteIformationPage_ModalHeader_Xpath);
            actualText.Contains(expectedtext);
          
            Report.WriteLine("Terms and Condition modal has opened");



        }
    }
}
