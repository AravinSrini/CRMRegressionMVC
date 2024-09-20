using CRM.UITest.Objects;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Threading;

namespace CRM.UITest.CommonMethods
{
    public class CloseCreditHoldWarningPopUp : Shipmentlist
    {
        public CloseCreditHoldWarningPopUp()
        {
        }
        public void CloseCreditHoldPopUp()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            try
            {
                if (GlobalVariables.webDriver.FindElement(By.Id("btn_CreditHoldClose")).Displayed)
                {
                    Report.WriteLine("Closing Credit Hold Modal");
                    Click(attributeName_id, "btn_CreditHoldClose");
                    Thread.Sleep(1000);
                }
            }
            catch(NoSuchElementException)
            {

            }
        }
        
    }
}
