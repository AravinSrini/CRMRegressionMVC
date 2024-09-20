using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Confirmation_Screen__All_Users
{
    [Binding]
    public sealed class Add_Another_Shipment_button___All_Users_steps : AddShipments
    {
        [When(@"I click on the Add Another Shipment button")]
        public void WhenIClickOnTheAddAnotherShipmentButton()
        {
            Report.WriteLine("Verifying and Clicking on Add Another Shipment button");
            VerifyElementVisible(attributeName_xpath, confirmation_addanothershipmentbutton, "Add Another Shipment");
            Click(attributeName_xpath, confirmation_addanothershipmentbutton);
        }



        [Then(@"I will arrive on the Add Shipment page(.*)")]
        public void ThenIWillArriveOnTheAddShipmentPage(string Usertype)
        {
            Report.WriteLine("Verifying functionality of arrive on the Add Shipment page.");

            string configURL = launchUrl;
            if (Usertype == "External")
            {
                string expectedPagrURL = configURL + "Shipment/AddShipment?mode=LTL";
                string actualURL = GetURL();
                Assert.AreEqual(expectedPagrURL, actualURL);
            }
            else
            {
                string expectedPagrURL = configURL + "Shipment/AddShipment?mode=LTL&selectedCustomerName=";
                string actualURL = GetURL();
                actualURL.Contains(expectedPagrURL);

            }
        }
    }
}
