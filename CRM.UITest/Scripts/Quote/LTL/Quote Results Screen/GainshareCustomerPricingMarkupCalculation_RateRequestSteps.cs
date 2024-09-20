using System;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Quote.LTL.Quote_Results_Screen
{
    [Binding]
    public class GainshareCustomerPricingMarkupCalculation_RateRequestSteps
    {

        //[Then(@"the Customer charges in the Rate results page is calculated based on new rating calculation(.*),(.*)")]
        //public void ThenTheCustomerChargesInTheRateResultsPageIsCalculatedBasedOnNewRatingCalculation(string CustomerAccount, string UserType)
        //{
        //    //No Bump and Surge
        //    double BOLH = 166000.90;
        //    double BOFSC = 0;
        //    double BOACC = 0;
        //    double BOTTL = BOLH + BOFSC + BOACC;
        //    //Verify in UI Total cost and BOTTL

        //    //With Bump
        //    double BLH = 95000.78;
        //    double BFSC = 787090.67;
        //    double BACC = 86890;
        //    double BTTL = BLH + BFSC + BACC;
        //    //Verify in UI Total cost and BTTL

        //    //with Surge
        //    double SLH = 79688.29;
        //    double SFSC = 89898.22;
        //    double SACC = 66978.22;
        //    double STTL = SLH + SFSC + SACC;
        //    //Verify in UI Total cost and STTL
        //}

        [Then(@"the Customer charges in the Rate results page is calculated based on new rating calculation(.*)(.*)(.*)")]
        public void ThenTheCustomerChargesInTheRateResultsPageIsCalculatedBasedOnNewRatingCalculation(string p0, string p1, string p2)
        {
            ScenarioContext.Current.Pending();
        }

    }
}
