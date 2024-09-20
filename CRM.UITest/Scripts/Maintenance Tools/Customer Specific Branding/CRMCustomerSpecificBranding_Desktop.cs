using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Maintenance_Tools.Customer_Specific_Branding
{
    [Binding]
    public class CRMCustomerSpecificBranding_Desktop : ObjectRepository
    {

        [Then(@"Verify the customer account is updated with the customer specific logo")]
        public void ThenVerifyTheCustomerAccountIsUpdatedWithTheCustomerSpecificLogo()
        {
            Report.WriteLine("Customer Specific logo is updated for the Customer Account");
            IList<IWebElement> IconList = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='iconSidebarNav']/div/ul/li"));
            for (int i = 3; i < IconList.Count; i++)
            {
                Click(attributeName_xpath, ".//*[@id='iconSidebarNav']/div/ul/li[" + i + "]/a");
                VerifyElementNotPresent(attributeName_xpath, DashboardHeaderlogo_Xpath, "DLSWorldwide");
				Thread.Sleep(7000);
                Click(attributeName_cssselector, DashboardIcon_css);
            }
        }

        [When(@"I land on the Dashboard")]
        public void WhenILandOnTheDashboard()
        {
            Verifytext(attributeName_xpath, NewDashboard_Header_Text_Xpath, "Dashboard");
        }
 
      
        [Then(@"Verify that the UI displays the logo as left aligned")]
        public void ThenVerifyThatTheUIDisplaysTheLogoAsLeftAligned()
        {
            Report.WriteLine("Verifying that the logo is left aligned by default when flag in DB is false");
            bool CustomerLogoAlignment_DB = DBHelper.GetCustomerLogoAlignment(1209);
            {
                if (CustomerLogoAlignment_DB == false)
                {
                    Report.WriteLine("verifying logo should be placed in Left");
                    VerifyElementPresent(attributeName_cssselector, LogoAlignment_Left_css, "src");
                }
            }

        }

        [Then(@"Verify that the UI displays the logo as center aligned for the logged in customer with header logo changed to center")]
        public void ThenVerifyThatTheUIDisplaysTheLogoAsCenterAlignedForTheLoggedInCustomerWithHeaderLogoChangedToCenter()
        {
            Report.WriteLine("Verifying that the logo is Center aligned when flag in DB is false ");

            bool CustomerLogoAlignment_DB = DBHelper.GetCustomerLogoAlignment(771);
            {
                if (CustomerLogoAlignment_DB == true)
                {
                    Report.WriteLine("verifying Logo should be placed in center");
                    VerifyElementPresent(attributeName_cssselector, LogoAlignment_Center_css, "src");
                }
            }
        }

    }
}