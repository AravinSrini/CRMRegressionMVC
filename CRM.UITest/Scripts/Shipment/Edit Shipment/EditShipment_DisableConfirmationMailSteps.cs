using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Collections.Generic;
using System.Configuration;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Edit_Shipment
{
    [Binding]
    public class EditShipment_DisableConfirmationMailSteps : AddShipments
    {
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
        AddShipmentLTL ltl = new AddShipmentLTL();
        string customerName = "ZZZ - Czar Customer Test";

        [Given(@"I am a DLS Internal user with access to Shipments")]
        public void GivenIAmADLSInternalUserWithAccessToShipments()
        {
            string userName = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
            string password = ConfigurationManager.AppSettings["password-crmOperation"].ToString();
            CrmLogin.LoginToCRMApplication(userName, password);
            Report.WriteLine("I logged into CRM application with Operation user credentials");
        }

        [Given(@"I am a DLS Salesuser with access to Shipments")]
        public void GivenIAmADLSSalesuserWithAccessToShipments()
        {
            string userName = ConfigurationManager.AppSettings["username-salesdelta"].ToString();
            string password = ConfigurationManager.AppSettings["password-salesdelta"].ToString();
            CrmLogin.LoginToCRMApplication(userName, password);
            Report.WriteLine("I logged into CRM application with Sales user credentials");
        }


        [Given(@"I Am on the ShipmentList page")]
        public void GivenIAmOnTheShipmentListPage()
        {
            Report.WriteLine("Clicked on Shipments icon");
            Click(attributeName_cssselector, ShipmentsIcon_css);
            GlobalVariables.webDriver.WaitForPageLoad();
        }


        [Given(@"I click on the Edit button of any available LTL shipments")]
        public void GivenIClickOnTheEditButtonOfAnyAvailableLTLShipments()
        {
            Report.WriteLine("Selecting " + customerName + " from the dropdown");
            Click(attributeName_xpath, ShipmentList_CustomerOrStationDropdown_Xpath);
            IList<IWebElement> CustomerDropdown_List = GlobalVariables.webDriver.FindElements(By.XPath(CustomerDropdownValesExtuser_Xpath));
            int CustomerNameListCount = CustomerDropdown_List.Count;
            for (int i = 0; i < CustomerNameListCount; i++)
            {
                if (CustomerDropdown_List[i].Text == customerName)
                {
                    CustomerDropdown_List[i].Click();
                    break;
                }
            }
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Click on Edit Shipment button");
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_id, "searchbox", "ZZX002015260");
            Click(attributeName_xpath, ".//*[@id='ShipmentGrid']/tbody/tr/td[10]/button");
            GlobalVariables.webDriver.WaitForPageLoad();
            scrollpagedown();
            scrollpagedown();
            scrollElementIntoView(attributeName_xpath, ViewRatesButton_xpath);
            ltl.ClickViewRates();
            Report.WriteLine("Click on Edit Shipment button");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_cssselector, "#gridLTLresult tr:first-child #createShipment");
        }        

        [Given(@"I click on the Submit Updated Shipment button on the Review and Submit Shipment \(LTL\) page")]
        public void GivenIClickOnTheSubmitUpdatedShipmentButtonOnTheReviewAndSubmitShipmentLTLPage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            scrollpagedown();
            scrollpagedown();
            Click(attributeName_id, "SubmitShipment");
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [When(@"I arrive on the Shipment Confirmation \(LTL\) page")]
        public void WhenIArriveOnTheShipmentConfirmationLTLPage()
        {
            Report.WriteLine("arrived on confirmation page");
            WaitForElementPresent(attributeName_xpath, confirmation_pageheader, "PageHeader");
        }

        [Then(@"I should not see the verbiage ""(.*)""")]
        public void ThenIShouldNotSeeTheVerbiage(string verbiage)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            VerifyElementNotVisible(attributeName_classname, "confirmation-label-text", verbiage);
        }
    }
}
