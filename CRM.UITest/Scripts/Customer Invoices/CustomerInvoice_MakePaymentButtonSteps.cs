using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Customer_Invoices
{
    [Binding]
    public class CustomerInvoice_MakePaymentButtonSteps : ObjectRepository
    {
        [When(@"I click on the Make Payment button")]
        public void WhenIClickOnTheMakePaymentButton()
        {
            Report.WriteLine("click on Payments icon");
            Click(attributeName_id, "btnMakePayment");
        }
    }
}
