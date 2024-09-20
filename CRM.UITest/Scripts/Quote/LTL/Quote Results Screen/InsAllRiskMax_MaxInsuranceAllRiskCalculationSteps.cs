using CRM.UITest.Objects;
using TechTalk.SpecFlow;
using CRM.UITest.Entities;
using Rrd.ServiceAccessLayer;
using System;
using CRM.UITest.Entities.Proxy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CRM.UITest.Scripts.Quote.LTL
{
    [Binding]
    public class InsAllRiskMax_MaxInsuranceAllRiskCalculationSteps : ObjectRepository
    {
        [Then(@"Insurance calculated value (.*) should be added for the accessorial of carrier for the passed (.*)")]
        public void ThenInsuranceCalculatedValueShouldBeAddedForTheAccessorialOfCarrierForThePassed(string Username, string ShipmentValue)
        {
            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);
            string setupID = IDP.GetClaimValue(Username, "dlscrm-CustomerSetUpId");
            int value = Convert.ToInt32(setupID);
            int AccNumb = DBHelper.GetAccountNumber(value);
            CustomerAccount Accvalue = DBHelper.GetAccountDetails(AccNumb);
            Decimal CalcultedShipmentValue = Math.Ceiling(Convert.ToDecimal(ShipmentValue) / 100) * Accvalue.CostPerHundred;
            string actualValue = Gettext(attributeName_xpath, ltlinsaccessorials_xpath);
            string actValue = actualValue.Remove(0, 16);

            if (CalcultedShipmentValue <= Accvalue.MinimumInsCost)
            {
                Assert.AreEqual(actValue, Accvalue.MinimumInsCost.ToString());
            }
            else if (Accvalue.MaximumInsCost == null || CalcultedShipmentValue > Accvalue.MinimumInsCost && CalcultedShipmentValue < Accvalue.MaximumInsCost)
            {
				Assert.AreEqual(actValue, CalcultedShipmentValue.ToString());
            }
            else if(CalcultedShipmentValue >= Accvalue.MaximumInsCost)
            {
				Assert.AreEqual(actValue, Accvalue.MaximumInsCost.ToString());
            }
            else
            {
                Console.WriteLine("Calaculated insured amount is not displaying in UI");
                Assert.IsTrue(false);
            }
        }
    }
}
