using CRM.UITest.Helper;
using CRM.UITest.Helper.ViewModel;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using TechTalk.SpecFlow;
using System.Configuration;
using CRM.UITest.CommonMethods;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.AddShipment_PageElements_AllUsers
{
    [Binding]
    public class _83193_AddShipment_ReadyTimeIsLaterThanCloseTimeSteps : AddShipments
    {
        string userType = string.Empty;
        [Given(@"I am a user and login into application with valid (.*) user")]
        public void GivenIAmAUserAndLoginIntoApplicationWithValidUser(string User)
        {
            userType = User;
            string userName = string.Empty;
            string password = string.Empty;
            if (userType == "Sales")
            {
                userName = ConfigurationManager.AppSettings["username-salesdelta"].ToString();
                password = ConfigurationManager.AppSettings["password-salesdelta"].ToString();
                Report.WriteLine("Logging into CRM application with Sales user");
            }
            else
            {
                userName = ConfigurationManager.AppSettings["username-CurrentSprintOperations"].ToString();
                password = ConfigurationManager.AppSettings["password-CurrentSprintOperations"].ToString();
                Report.WriteLine("Logging into CRM application with Operations user");
            }
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(userName, password);
        }


        [Then(@"i should receive a message stating - Please select a Pickup Date Close time that is after the Pickup Date Ready time\.Then I should receive message stating - Please select a Pickup Date Ready time that is before the Pickup Date Close time\.")]
        public void ThenIShouldReceiveAMessageStating_PleaseSelectAPickupDateCloseTimeThatIsAfterThePickupDateReadyTime_ThenIShouldReceiveMessageStating_PleaseSelectAPickupDateReadyTimeThatIsBeforeThePickupDateCloseTime_()
        {
            Report.WriteLine("Display of error message when Pickup date Close time is before Pickup Date Ready time");
            VerifyElementVisible(attributeName_xpath, LTL_PickUpCloseTimeError_Xpath, "Close time");
            string error = Gettext(attributeName_xpath, LTL_PickUpCloseTimeErrorContent_Xpath);
            String actualerror = "Please select a Pickup Date Close time that is after the Pickup Date Ready time.";
            Assert.AreEqual(error, actualerror);
        }

        [When(@"I enter data in the Freight Description (.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void WhenIEnterDataInTheFreightDescription(string Classification, string NMFC, string Quantity, string Weight, string ItemDescription, string user, string OrderNumber, string GLCode, string AdditionalReferenceNumber, string AdditionalReferenceNumber1)
        {
            Report.WriteLine("Clearing if any default Item present in Freight section");
            Thread.Sleep(1000);
            string _selectedAddress = GetValue(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id, "value");

            if (_selectedAddress != "" || _selectedAddress != string.Empty)
            {
                Click(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
                Thread.Sleep(4000);
            }
            Click(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            Click(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id);
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(FreightDesp_FirstItem_SavedClassItem_DropDown_Values_xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == Classification)
                {
                    DropDownList[i].Click();
                    break;
                }
            }

            SendKeys(attributeName_id, FreightDesp_FirstItem_NMFC_Id, NMFC);
            SendKeys(attributeName_id, FreightDesp_FirstItem_Quantity_Id, Quantity);
            SendKeys(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id, ItemDescription);
            SendKeys(attributeName_id, FreightDesp_FirstItem_Weight_Id, Weight);
            if (user == "Sales" || user == "Operations")
            {
                SendKeys(attributeName_id, ReferenceNumbers_OrderNumber_Id, OrderNumber);
                SendKeys(attributeName_id, ReferenceNumbers_GLCode_Id, GLCode);
                SendKeys(attributeName_xpath, AdditionalReferenceNumber_Value_xpath, AdditionalReferenceNumber);
                SendKeys(attributeName_xpath, AdditionalReferenceNumber2_Value_xpath, AdditionalReferenceNumber);
                scrollPageup();
            }


        }
    }
}

