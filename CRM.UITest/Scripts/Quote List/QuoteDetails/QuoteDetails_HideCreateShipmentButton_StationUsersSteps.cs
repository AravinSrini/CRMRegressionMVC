using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Quote_List.QuoteDetails
{
    [Binding]
    public class QuoteDetails_HideCreateShipmentButton_StationUsersSteps : Quotelist
    {

        [Then(@"I should not be able to see the CreateShipment button in the Quote Details Section")]
        public void ThenIShouldNotBeAbleToSeeTheCreateShipmentButtonInTheQuoteDetailsSection()
        {
           //bool createShipment =  IsElementVisible(attributeName_id, QuoteDetails_CreateShipmentButton_Id, "Create Shipment");
           // if(createShipment == true)
           // {
           //     Report.WriteLine("Create Shipment is visible for Station users");
           //     Assert.Fail();
           // }
           // else
           // {
           //     Report.WriteLine("Create Shipment is not visible for Station users");
           // }
            VerifyElementNotVisible(attributeName_id, QuoteDetails_CreateShipmentButton_Id, "CreateShipmentButton");
        }


    }
}
