using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Quote.International
{
    [Binding]
    public class International_Quote_Air_Default_Service_Level_to_Air_DirectSteps : Mvc4Objects
    {

        [Given(@"I am a Ship\.entry user - (.*) and (.*)")]
        public void GivenIAmAShip_EntryUser_And(string UserName, string Password)
        {
            string username = ConfigurationManager.AppSettings["username-Both"].ToString();
            string password = ConfigurationManager.AppSettings["password-Both"].ToString();
           CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
           CrmLogin.LoginToCRMApplication(username, password);

        }


        [Given(@"I am a Ship\.Inquiry user (.*) and (.*)")]
        public void GivenIAmAShip_InquiryUserAnd(string UserName, string Password)
        {
            string username = ConfigurationManager.AppSettings["username-shpInquiry"].ToString();
            string password = ConfigurationManager.AppSettings["password-shpInquiry"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }



        [When(@"I arrive on the Get Quote Tiles page")]
        public void WhenIArriveOnTheGetQuoteTilesPage()
        {
            Report.WriteLine("click on the Quotes Module");
            Click(attributeName_cssselector, Quotesmenu_css);

            Report.WriteLine("click on the Submit Rate Request button");
            Click(attributeName_id, SubmitRateRequestBtn_id);
        }

        [When(@"I select the International tile type")]
        public void WhenISelectTheInternationalTileType()
        {
            Report.WriteLine("Clicks on the International tile");
            Click(attributeName_id, InternationalTile_id);
            WaitForElementVisible(attributeName_xpath, InternationalModel_xpath, "International Type");

        }

        [Then(@"service level should be defaulted to Air Direct when I select Air Import type")]
        public void ThenServiceLevelShouldBeDefaultedToAirDirectWhenISelectAirImportType()
        {
            Report.WriteLine("User select valid option in Type drop down");
            Click(attributeName_xpath, InternationalTypedropdown_xpath);
            Report.WriteLine("User selects first option in the Type drop down list");

            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(InternationalTypeDropDownValues_xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == "Air - Import")
                {
                    DropDownList[i].Click();
                    break;
                }
            }
            WaitForElementVisible(attributeName_xpath, InternationalLeveldropdown_xpath, "Air Direct");

            Verifytext(attributeName_xpath, InternationalLeveldropdown_xpath, "Air Direct");
        }



        [Then(@"service level should be defaulted to Air Direct when I select Air Export type")]
        public void ThenServiceLevelShouldBeDefaultedToAirDirectWhenISelectAirExportType()
        {
            Report.WriteLine("User select valid option in Type drop down");
            Click(attributeName_xpath, InternationalTypedropdown_xpath);
            Report.WriteLine("User selects first option in the Type drop down list");

            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(InternationalTypeDropDownValues_xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == "Air - Export")
                {
                    DropDownList[i].Click();
                    break;
                }
            }

            WaitForElementVisible(attributeName_xpath, InternationalLeveldropdown_xpath, "Air Direct");
            Verifytext(attributeName_xpath, InternationalLeveldropdown_xpath, "Air Direct");
        }


        [Then(@"there will not be an option of Select Level")]
        public void ThenThereWillNotBeAnOptionOfSelectLevel()
        {
            List<string> serviceLevel = new List<string>();

            Click(attributeName_xpath, InternationalLeveldropdown_xpath);

            Report.WriteLine("Reading the values from the Insured Rate columns after ascdending sorting");
            IList<IWebElement> levelCount = GlobalVariables.webDriver.FindElements(By.XPath(InternationalLevelDropDownValues_xpath));
            foreach (IWebElement element in levelCount)
            {
                serviceLevel.Add((element.Text).ToString());

            }

            for (int i = 0; i < levelCount.Count; i++)
            {
                if (serviceLevel[i] != "Select Level...")
                {
                    Report.WriteLine("Service level drop down does not contains option Select Level...");
                }
                else
                {
                    throw new System.Exception("Service level drop down does contains option Select Level...");
                }

            }

        }
    }
}
