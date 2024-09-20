using CRM.UITest.CommonMethods;
using CRM.UITest.CommonMethods.Mvc4Regressions;
using CRM.UITest.Objects;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.UAT_Regression.International.Shipment
{
    [Binding]
    public class International_Add_Shipment_Navigation : Mvc4Objects
    {
        InternationalShipment internationalCommonMethods = new InternationalShipment();
        CommonMethodsCrm crm = new CommonMethodsCrm();

        [Given(@"shp\.entry , shp\.entrynorates user with International service- (.*) and (.*)")]
        public void GivenShp_EntryShp_EntrynoratesUserWithInternationalService_And(string userName, string password)
        {
            crm.LoginToCRMApplication(userName, password);
        }

        [When(@"I land on the dashboard page")]
        public void WhenILandOnTheDashboardPage()
        {
           
            try
            {
                Verifytext(attributeName_xpath, DasboardHeader_Xpath, "Dashboard");
            }
            catch (Exception)
            {
                Thread.Sleep(10000);
            }
        }

        [When(@"I select International from Create A Shipment section(.*),(.*)"),Scope(Tag= "35480")]
        public void WhenISelectInternationalFromCreateAShipmentSection(string Type, string level)
        {
            Thread.Sleep(10000);
            scrollElementIntoView(attributeName_xpath, CreateShipButton_DashboardPage_Xpath);
          

            Click(attributeName_xpath, "//*[@id='showShipment']/div[1]/h4");
            //MoveToElement(attributeName_id, Ship_Intl_Radiobutton_DashboardPage_ID);
            Click(attributeName_id, Ship_Intl_Radiobutton_DashboardPage_ID);
            
            Click(attributeName_id, Ship_Intl_SelectType_dropdown_DashboardPage_Id);
            Thread.Sleep(5000);
            IList<IWebElement> InternationalServiceTypedropdownValues = GlobalVariables.webDriver.FindElements(By.XPath(Ship_Intl_SelectType_dropdown_Values_DashboardPage_Xpath));
            for (int i = 0; i <= InternationalServiceTypedropdownValues.Count; i++)
            {
                if (InternationalServiceTypedropdownValues[i].Text == Type)
                {
                    //  SelectDropdownValueFromList(attributeName_xpath, CustomerSelection_DropdownList_Xpath, customer);
                    InternationalServiceTypedropdownValues[i].Click();
                    break;
                }
                else
                {
                    Report.WriteLine("Customer value does not exists");
                }
            }
            //SelectDropdownValueFromList(attributeName_xpath, Ship_Intl_SelectType_dropdown_Values_DashboardPage_Xpath, Type);

            Click(attributeName_id, Ship_Intl_SelectLevel_dropdown_DashboardPage_Id);

            IList<IWebElement> InternationalServiceLeveldropdownValues = GlobalVariables.webDriver.FindElements(By.XPath(Ship_Intl_SelectLevel_dropdown_Values_DashboardPage_Xpath));
            for (int i = 0; i <= InternationalServiceTypedropdownValues.Count; i++)
            {
                if (InternationalServiceLeveldropdownValues[i].Text == level)
                {
                    //  SelectDropdownValueFromList(attributeName_xpath, CustomerSelection_DropdownList_Xpath, customer);
                    InternationalServiceLeveldropdownValues[i].Click();
                    break;
                }
                else
                {
                    Report.WriteLine("Customer value does not exists");
                }
            }
            //SelectDropdownValueFromList(attributeName_xpath, Ship_Intl_SelectLevel_dropdown_Values_DashboardPage_Xpath, level);

            //internationalCommonMethods.Select_InternationalService_Type_level(Type, level);
        }

        [When(@"I click on Create  Shipment button"),Scope(Tag= "35480")]
        public void WhenIClickOnCreateShipmentButton()
        {
            try
            {
                Click(attributeName_xpath, CreateShipButton_DashboardPage_Xpath);
            }
            catch (Exception)
            {
                Thread.Sleep(20000);
            }
        }

        [Then(@"I must land on the Shipment Locations and Dates page for International")]
        public void ThenIMustLandOnTheShipmentLocationsAndDatesPageForInternational()
        {
            Verifytext(attributeName_xpath, Intl_RateRequestHeader_ShpLoc_And_Dates_Page_Xpath, "Add Shipment");
        }

        [When(@"I click Shipment icon from the menu")]
        public void WhenIClickShipmentIconFromTheMenu()
        {

           // Report.WriteLine("Navigate to MVC5 Shipment list");
            try
            {
               MoveToElement(attributeName_xpath, ShipmentModule_Xpath);
               Click(attributeName_id, ShipmentModule_Id);

            }
            catch (Exception)
            {
                Thread.Sleep(20000);
                Console.WriteLine("error occurred");
            }
        }

        [When(@"I select Add Shipment on the Shipment List page"),Scope(Tag= "35480")]
        public void WhenISelectAddShipmentOnTheShipmentListPage()
        {
            WaitForElementVisible(attributeName_xpath, ShipmentList_Header_Text_Xpath, "Shipment List");
            Thread.Sleep(10000);
            try
            {
                Click(attributeName_id, AddShipment_button_Id);
            }
            catch (Exception)
            {
                Thread.Sleep(10000);
                Report.WriteLine("Error Occurred");
            }
        }

        [When(@"I land on the Add Shipment \(tiles\) page")]
        public void WhenILandOnTheAddShipmentTilesPage()
        {
            Verifytext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div[1]/div[1]/div[1]/h1", "Add Shipment");
        }

        [When(@"I click on International tiles (.*),(.*)")]
        public void WhenIClickOnInternationalTiles(string Type, string level)
        {
            Click(attributeName_id, Int_Shipment_Tile_Id);
            WaitForElementVisible(attributeName_xpath, Int_ServiceType_Modal_Verbiage, "International Type Verbiage");
            Click(attributeName_xpath, Int_Shipment_Type_dropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, Int_Shipment_Type_dropdown_Value_Xpath, Type);
            //Thread.Sleep(2500);
            WaitForElementVisible(attributeName_xpath, Int_Shipment_level_dropdown_Xpath, "International service level dropdown");
            Click(attributeName_xpath, Int_Shipment_level_dropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, Int_Shipment_level_dropdown_value_Xpath, level);
            Click(attributeName_id, Int_Shipment_Continue_button_Id);
        }


    }
}
