using CRM.UITest.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Shipment_Details
{
    [Binding]
    public sealed class Terminal_Information__Null_NaN_Empty_Values_Appear_as_Empty_Strings : AddShipments
    {
        [Then(@"the value for Origin Address2 will be an empty string")]
        public void ThenTheValueForAddressWillBeAnEmptyString()
        {
            Verifytext(attributeName_id, ShipmentDetails_orgTerminalAddress2_Id, "");
        }

        [Then(@"the value for Origin Email will be an empty string")]
        public void ThenTheValueForOriginEmailWillBeAnEmptyString()
        {
            Verifytext(attributeName_id, ShipmentDetails_orgTerminalEmail_Id, "");
        }
    }
}
