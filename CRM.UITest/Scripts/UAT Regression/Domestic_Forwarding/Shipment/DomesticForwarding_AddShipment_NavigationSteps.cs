using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.IdentityModel.Protocols;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.UAT_Regression.Domestic_Forwarding.Shipment
{
    [Binding]
    public  class DomesticForwarding_AddShipment_NavigationSteps : Mvc4Objects
    {
        String Service = " Domestic Forwarding";
        String Type = "Next Day";

        AddShipmentLTL ltl = new AddShipmentLTL();

        [Given(@"I am Ship Entry user")]
        public void GivenIAmShipEntryUser()
        {
            string username = ConfigurationManager.AppSettings["username-Both"].ToString();
            string password = ConfigurationManager.AppSettings["password-Both"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"I am Ship Entry No Rate user")]
        public void GivenIAmShipEntryNoRateUser()
        {
            string username = ConfigurationManager.AppSettings["username-Entyrnorates"].ToString();
            string password = ConfigurationManager.AppSettings["password-Entyrnorates"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [When(@"I Selected Domestic Forwarding and click on Create shipment from Dashboard")]
        public void WhenISelectedDomesticForwardingAndClickOnCreateShipmentFromDashboard()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            scrollpagedown();
            WaitForElementVisible(attributeName_xpath, Ship_DF_DomesticForwarding_Xpath, "Domestic Forwarding");
            Report.WriteLine("Click on Domestic Forwarding Radio Button from Create Shipment section");
            Click(attributeName_xpath, Ship_DF_DomesticForwarding_Xpath);

            DefineTimeOut(20000);
            Report.WriteLine("Click on Domestic Forwarding Dropdown");
            Click(attributeName_id, Ship_DF_SelectType_dropdown_DashboardPage_Id);

            Report.WriteLine("Selected the Service Type from the Dropdown");

            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(Ship_DF_SelectType_dropdown_Values_DashboardPage_Xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == Type)
                {
                    DropDownList[i].Click();
                    break;
                }
            }
            scrollpagedown();
            Report.WriteLine("Click on Create Shipment Button from Dashboard");
            Click(attributeName_id, CreateShipButton_DashboardPage_Id);
        }

        [When(@"I selected Domestic Forwarding Tiles & Type and click on Continue Button from Add Shipment Tiles page")]
        public void WhenISelectedDomesticForwardingTilesTypeAndClickOnContinueButtonFromAddShipmentTilesPage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            ltl.NaviagteToShipmentList();

            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, AddShipmentButton_Id);

            Click(attributeName_id, DF_ShipTile_Id);

            WaitForElementVisible(attributeName_xpath, DF_ShipTypeSelect_Xpath, "Domestic Forwarding");
            Click(attributeName_xpath, DF_ShipTypeSelect_Xpath);

            WaitForElementVisible(attributeName_xpath, DF_ShipTypeSelectValue_Xpath, "Shipment Domestic Forwarding Type");
            Report.WriteLine("Select the Service Type from the Dropdown");
            SelectDropdownValueFromList(attributeName_xpath, DF_ShipTypeSelectValue_Xpath, Type);

            WaitForElementVisible(attributeName_id, DF_ShipTypeContinue_Id, "Continue");
            Report.WriteLine("Click on Continue Button");
            Click(attributeName_id, DF_ShipTypeContinue_Id);

        }


        [Then(@"I must land on the Add Shipment Location and Dates Page for Domestic forwarding")]
        public void ThenIMustLandOnTheAddShipmentLocationAndDatesPageForDomesticForwarding()
        {
            
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("I must land on Add Shipment Locations and Dates Page");
            Verifytext(attributeName_xpath, DF_ShipPageTitle_Xpath, "Add Shipment");
            Verifytext(attributeName_xpath, ShipDF_ShipmentLocationAndDatesPage_Xpath, "Shipment Locations and Dates");

            Report.WriteLine("Selected Service shows in Locations and Dates Page");
            string Service1 = Gettext(attributeName_id, ShipDF_AddShipment_Servie_Id);
            string [] ActualService1 =Service1.Split(':');
            string ActualService = ActualService1[1];
            Assert.AreEqual(Service, ActualService);

        }

        [Then(@"The Type selected must be displayed")]
        public void ThenTheTypeSelectedMustBeDisplayed()
        {
            Report.WriteLine("Type Selected Must be Displayed");
            String ActualType = Gettext(attributeName_xpath, ShipDF_AddShipment_Type_Xpath);
            Assert.AreEqual(Type, ActualType);                 
        }


    }
}
