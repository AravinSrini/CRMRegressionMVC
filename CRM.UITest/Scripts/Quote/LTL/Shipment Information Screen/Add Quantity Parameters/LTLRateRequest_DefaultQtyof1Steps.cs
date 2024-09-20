using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Quote.LTL.Shipment_Information_Screen.Add_Quantity_Parameters
{
    [Binding]
    public class LTLRateRequest_DefaultQtyof1Steps : ObjectRepository
    {
        [Given(@"I am a DLS user and login into crm with valid (.*) and (.*)")]
        public void GivenIAmADLSUserAndLoginIntoCrmWithValidAnd(string Username, string Password)
        {
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(Username, Password);
            Report.WriteLine("I logged into CRM application with RRD access user");
        }

        [Then(@"the Quantity field will be set to one (.*) for the default item")]
        public void ThenTheQuantityFieldWillBeSetToOneForTheDefaultItem(string Customer_Name)
        {
            int setupid = DBHelper.GetAccountIdforAccountName(Customer_Name);
            int accountnumber = DBHelper.GetAccountNumber(setupid);
            Item values = DBHelper.GetDefaultItem(accountnumber);
            if(values.Quantity == null)
            {
                Report.WriteLine("Account " + Customer_Name + " has default item");
                Report.WriteLine("Default item does not have quantity value");
                string ActQuantity = GetAttribute(attributeName_id, LTL_Quantity_Id, "value");
                Assert.AreEqual(ActQuantity, "1");
                Report.WriteLine("Value " + ActQuantity + " is displaying in quantity field");
            }
            else
            {
                Report.WriteLine("Unable to verify the default quantity 1 functionality as account does not have default item");
            }
        }
        
        [Then(@"quantity field is editable (.*)")]
        public void ThenQuantityFieldIsEditable(string quantity)
        {
            Report.WriteLine("Verifying the edit functionality for the quantity field");
            SendKeys(attributeName_id, LTL_Quantity_Id, quantity);
            string ActQuantity = GetAttribute(attributeName_id, LTL_Quantity_Id, "value");
            Assert.AreEqual(ActQuantity, quantity);
            Report.WriteLine("Modified value " + quantity + " is displaying in quantity field");
        }

        [Then(@"I select (.*) from the Select Class field in quote shipment information page")]
        public void ThenISelectFromTheSelectClassFieldInQuoteShipmentInformationPage(string saveditem)
        {
            Report.WriteLine("Selecting saved item from the dropdown");
            scrollElementIntoView(attributeName_id, ClassorSavedItemField_id);
            Click(attributeName_id, LTL_ClearItem_Id);
            Click(attributeName_id, ClassorSavedItemField_id);
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_id, ClassorSavedItemField_id, saveditem);
            //SelectDropdownValueFromList(attributeName_xpath, LTL_ClassificationValues_Xpath, saveditem);


            //SendKeys(attributeName_xpath, selectclasstextbox_xpath, saveditem);
            //SendKeys(attributeName_xpath, LTL_ClassificationValues_Xpath, saveditem);
           Click(attributeName_xpath, ClickOutsideFied_xpath);
        }
    }
}
