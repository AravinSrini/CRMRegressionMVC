using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Confirmation_Screen__All_Users
{
    [Binding]
    public class ViewShipmentDetailsButtonAllUsersSteps : AddShipments
    {
        string refereneNo = null;

        [When(@"I click on the View Shipment Details button")]
        public void WhenIClickOnTheViewShipmentDetailsButton()
        {
            refereneNo=Gettext(attributeName_xpath, confirmation_BOLValue_Xpath);

            scrollElementIntoView(attributeName_xpath, confirmation_viewshipmentdetailsbutton);
            try
            {
                Click(attributeName_xpath, confirmation_viewshipmentdetailsbutton);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                Thread.Sleep(10000);
            }
        }
        
        [Then(@"I will arrive on the Shipment Details page")]
        public void ThenIWillArriveOnTheShipmentDetailsPage()
        {
            Report.WriteLine("Shipment Details page Header");
            VerifyElementPresent(attributeName_xpath, "//*[@id='pageTitle']/h1", "Shipment Details");
            string refrenceNoOnShpDtlspge=Gettext(attributeName_xpath, "//*[@id='bolnumberdata']/h2");
            refrenceNoOnShpDtlspge.Contains(refereneNo);

        }
    }
}
