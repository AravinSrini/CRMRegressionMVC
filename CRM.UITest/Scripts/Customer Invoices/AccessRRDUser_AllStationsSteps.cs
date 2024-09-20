using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Customer_Invoices
{
    [Binding]
    public class AccessRRDUser_AllStationsSteps : Customer_Invoice
    {
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
        public WebElementOperations ObjWebElementOperations = new WebElementOperations();

        [Then(@"I get all stations in alphabetical order")]
        public void ThenIGetAllStationsInAlphabeticalOrder()
        {
            List<string> expectedNames = new List<string>();
            IList<IWebElement> stationDropdownCustomReport = GlobalVariables.webDriver.FindElements(By.XPath(CustomReportStationDropDownRRDAccessUser));

            foreach (IWebElement element in stationDropdownCustomReport)
            {
                expectedNames.Add(element.Text);
            }

            List<string> stationName = expectedNames;
            stationName.Sort();

            CollectionAssert.AreEqual(expectedNames, stationName);
            Report.WriteLine("The station that I am associated are available in Station Dropdown in alphabetical order");
        }

        [Then(@"I get all stations in alphabetical order under custom report section")]
        public void ThenIGetAllStationsInAlphabeticalOrderUnderCustomReportSection()
        {
            List<string> expectedNames = new List<string>();
            IList<IWebElement> stationDropdownCustomReport = GlobalVariables.webDriver.FindElements(By.XPath(CustomReport_Station_DropDownList));

            foreach (IWebElement element in stationDropdownCustomReport)
            {
                expectedNames.Add(element.Text);
            }

            List<string> stationName = expectedNames;
            stationName.Sort();

            CollectionAssert.AreEqual(expectedNames, stationName);
            Report.WriteLine("The station that I am associated are available in Station Dropdown in alphabetical order");
        }
    }
}
