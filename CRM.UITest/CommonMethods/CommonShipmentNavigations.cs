using CRM.UITest.Objects;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Collections.Generic;
using System.Threading;

namespace CRM.UITest.CommonMethods
{
   public class CommonShipmentNavigations :AddShipments
    {
        AddShipmentLTL ltl = new AddShipmentLTL();
        public void NavigatetoShipmentResultsPage(string userType)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Click on shipment icon");
            //ltl.NaviagteToShipmentList();
            //ltl.SelectCustomerFromShipmentList(userType, "ZZZ - GS Customer Test");
            scrollElementIntoView(attributeName_xpath, ".//*[@id='showShipment']");
            Click(attributeName_xpath, ".//input[@id='shipment-1']");
            Thread.Sleep(1000);
            Click(attributeName_xpath, ".//*[@id='createShipment']");

            GlobalVariables.webDriver.WaitForPageLoad();
            ltl.AddShipmentOriginData("oName", "oAdd", "33126");
            ltl.AddShipmentDestinationData("dName", "dAdd", "60606");
            scrollElementIntoView(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            ltl.AddShipmentFreightDescription("60", "1234s", "6", "1200", "description");
            ltl.ClickViewRates();
        }

        public void NavigatetoShipmentReviewandSubmitPage(string userType)
        {
            NavigatetoShipmentResultsPage(userType);
            GlobalVariables.webDriver.WaitForPageLoad();
            //Results page Create Shipment button Click
            ltl.ClickOnCreateShipmentButton(userType);
        }
        public void NavigatetoShipmentConfirmationPage(string userType)
        {
            NavigatetoShipmentReviewandSubmitPage(userType);
            GlobalVariables.webDriver.WaitForPageLoad();
            ltl.ReviewAndSubmit_ClickOnSubmitShipmentButton();
        }
        public void SelectNotificationAccessorialinShippingFrom(string userType)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Click on shipment icon");
            ltl.NaviagteToShipmentList();
            ltl.SelectCustomerFromShipmentList(userType, "ZZZ - GS Customer Test");            
           // Click(attributeName_xpath, ".//*[@id='createShipment']");

            GlobalVariables.webDriver.WaitForPageLoad();
            ltl.AddShipmentOriginData("oName", "oAdd", "33126");
            ltl.AddShipmentDestinationData("dName", "dAdd", "60606");
            Click(attributeName_xpath, ShippingFrom_ServicesAccessorial_DropDown_xpath);

            IList<IWebElement> accessorialDropdownListOFShippingFrom = GlobalVariables.webDriver.FindElements(By.XPath(ShippingFrom_ServicesAccessorial_DropDown_Values_xpath));
            int shippingFromAccessorialDropdownListCount = accessorialDropdownListOFShippingFrom.Count;
            for (int i = 0; i < shippingFromAccessorialDropdownListCount; i++)
            {
                if (accessorialDropdownListOFShippingFrom[i].Text == "Notification")
                {
                    accessorialDropdownListOFShippingFrom[i].Click();
                    break;
                }
            }
            scrollElementIntoView(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            Click(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            ltl.AddShipmentFreightDescription("60", "1234s", "6", "1200", "description");            
        }
        public void SelectNotificationAccessorialinShippingTo(string userType)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Click on shipment icon");
            ltl.NaviagteToShipmentList();
            ltl.SelectCustomerFromShipmentList(userType, "ZZZ - GS Customer Test");            

            GlobalVariables.webDriver.WaitForPageLoad();
            ltl.AddShipmentOriginData("oName", "oAdd", "33126");
            ltl.AddShipmentDestinationData("dName", "dAdd", "60606");
            Click(attributeName_xpath, ShippingTo_ServicesAccessorial_DropDown_xpath);

            IList<IWebElement> accessorialDropdownListOFShippingTo = GlobalVariables.webDriver.FindElements(By.XPath(ShippingTo_ServicesAccessorial_DropDown_Values_xpath));
            int shippingToAccessorialDropdownListCount = accessorialDropdownListOFShippingTo.Count;
            for (int i = 0; i < shippingToAccessorialDropdownListCount; i++)
            {
                if (accessorialDropdownListOFShippingTo[i].Text == "Notification")
                {
                    accessorialDropdownListOFShippingTo[i].Click();
                    break;
                }
            }
            scrollElementIntoView(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            Click(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            ltl.AddShipmentFreightDescription("60", "1234s", "6", "1200", "description");
        }

        public void SelectNotificationAccessorialinShippingFromAndTo(string userType)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Click on shipment icon");
            ltl.NaviagteToShipmentList();
            ltl.SelectCustomerFromShipmentList(userType, "ZZZ - GS Customer Test");            

            GlobalVariables.webDriver.WaitForPageLoad();
            ltl.AddShipmentOriginData("oName", "oAdd", "33126");
            ltl.AddShipmentDestinationData("dName", "dAdd", "60606");
            
            //shipping To section accessorial selection
            Click(attributeName_xpath, ShippingTo_ServicesAccessorial_DropDown_xpath);

            IList<IWebElement> accessorialDropdownListOFShippingTo = GlobalVariables.webDriver.FindElements(By.XPath(ShippingTo_ServicesAccessorial_DropDown_Values_xpath));
            int shippingToAccessorialDropdownListCount = accessorialDropdownListOFShippingTo.Count;
            for (int i = 0; i < shippingToAccessorialDropdownListCount; i++)
            {
                if (accessorialDropdownListOFShippingTo[i].Text == "Notification")
                {
                    accessorialDropdownListOFShippingTo[i].Click();
                    break;
                }
            }

            //Shipping From section accessorial selection
            Click(attributeName_xpath, ShippingFrom_ServicesAccessorial_DropDown_xpath);

            IList<IWebElement> accessorialDropdownListOFShippingFrom = GlobalVariables.webDriver.FindElements(By.XPath(ShippingFrom_ServicesAccessorial_DropDown_Values_xpath));
            int shippingFromAccessorialDropdownListCount = accessorialDropdownListOFShippingFrom.Count;
            for (int i = 0; i < shippingFromAccessorialDropdownListCount; i++)
            {
                if (accessorialDropdownListOFShippingFrom[i].Text == "Notification")
                {
                    accessorialDropdownListOFShippingFrom[i].Click();
                    break;
                }
            }
            GlobalVariables.webDriver.WaitForPageLoad();
            scrollElementIntoView(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            Click(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            ltl.AddShipmentFreightDescription("50", "1234s", "1", "4", "description");
        }
    }
}
