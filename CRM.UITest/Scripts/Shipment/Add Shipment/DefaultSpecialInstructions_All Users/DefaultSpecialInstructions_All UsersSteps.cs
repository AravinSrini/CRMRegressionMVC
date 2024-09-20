using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
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

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.DefaultSpecialInstructions_All_Users
{
    [Binding]
    public class DefaultSpecialInstructions_All_UsersSteps : AddShipments
    {
        [Given(@"I am a shp\.entry,shp\.entrynorates user of defaultinstructions")]
        public void GivenIAmAShp_EntryShp_EntrynoratesUserOfDefaultinstructions()
        {
            string username = ConfigurationManager.AppSettings["username-prakashdefault"].ToString();
            string password = ConfigurationManager.AppSettings["password-prakashdefault"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [Then(@"I should see the Default Special Instruction field")]
        public void ThenIShouldSeeTheDefaultSpecialInstructionField()
        {
            Report.WriteLine("I should see the Default Special Instruction field header");
            scrollElementIntoView(attributeName_xpath, DefaultSpecialIntructions_HeaderText_xpath);
            VerifyElementPresent(attributeName_xpath, DefaultSpecialIntructions_HeaderText_xpath, "Default Special Instruction");
            VerifyElementPresent(attributeName_id, DefaultSpecialIntructions_Comments_Id, "Text field");
        }

        [Then(@"The field is editable")]
        public void ThenTheFieldIsEditable()
        {
            Report.WriteLine("The field is editable");
            SendKeys(attributeName_id, DefaultSpecialIntructions_Comments_Id, "Default Instruction");
        }

        [When(@"I click to the Add Shipment button")]
        public void WhenIClickToTheAddShipmentButton()
        {
            Report.WriteLine("I click on Add Shipment button for the internal users");
            Click(attributeName_id, AddShipmentButtionInternal_Id);
        }


        [When(@"I select the (.*) from the dropdown list")]
        public void WhenISelectTheFromTheDropdownList(string customer)
        {
            Report.WriteLine("I select the Customer from the dropdown list"); ;
            Click(attributeName_xpath, AllCustomerDropdown_Selection_Internal_Xpath);
            Report.WriteLine("Selecting" + customer + "from the Customer dropdown list");

            IList<IWebElement> CustomerDropdown_List = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='CustomerType_chosen']/div/ul/li"));
            int CustomerNameListCount = CustomerDropdown_List.Count;
            for (int i = 0; i < CustomerNameListCount; i++)
            {
                if (CustomerDropdown_List[i].Text == customer)
                {
                    CustomerDropdown_List[i].Click();
                    break;
                }
                else
                {
                    Report.WriteLine("Customer not found in the list");
                }
            }
        }

        [Then(@"I should see the Default Special Instruction field with saved (.*)")]
        public void ThenIShouldSeeTheDefaultSpecialInstructionFieldWithSaved(string default_text)
        {
            Report.WriteLine("I should see the default special instruction text for this customer");
            scrollElementIntoView(attributeName_id, DefaultSpecialIntructions_Comments_Id);           
            String ActualText = GetAttribute(attributeName_id, DefaultSpecialIntructions_Comments_Id, "value");
            Assert.AreEqual(ActualText, default_text);
        }
    }
}
