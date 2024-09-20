using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;

namespace CRM.UITest.Scripts.Mercury_Gate
{
    [Binding]
    public sealed class _78278___External_API_Call_to_MercuryGate_Steps
    {
        string username = string.Empty;
        string result = string.Empty;

        [Given(@"I am a user named ""(.*)""")]
        public void GivenIAmAUserNamed(string user)
        {
            Report.WriteLine("Getting a request with the user " + user);
            username = user;
        }

        [When(@"I make a call to the Mercury Gate method ""(.*)"" with an ApiKey ""(.*)"" and Customer ""(.*)"" for ""(.*)""")]
        public void WhenIMakeACallToTheMercuryGateMethodWithAnApiKeyAndCustomerFor(string method, string apiKey, string customerName, string mgVersion)
        {
            Report.WriteLine("Building a request for the MG method " + method);
            MgCalls mg = new MgCalls();
            result = mg.getRequestXmlResponse(username, method, apiKey, customerName, mgVersion);
        }

        [Then(@"I will be blocked and given a 401 response")]
        public void ThenIWillBeBlockedAndGivenA401Response()
        {
            if(result == "401")
            {
                Report.WriteLine("Passed: MercuryGate request was correctly blocked and given 401 response");
            }
            else
            {
                Report.WriteFailure("MercuryGate request was incorrectly given the response " + result);
            }
        }

        [Then(@"I will not be blocked")]
        public void ThenIWillNotBeBlocked()
        {
            if(result == "200")
            {
                Report.WriteLine("Passed: MercuryGate request was correctly not blocked");
            }
            else
            {
                Report.WriteFailure("MercuryGate request was incorrectly given the response " + result);
            }
        }

    }
}
