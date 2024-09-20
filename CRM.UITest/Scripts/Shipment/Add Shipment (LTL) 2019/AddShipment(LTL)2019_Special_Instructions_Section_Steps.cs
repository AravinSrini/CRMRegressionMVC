using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using System;
using System.Collections.Generic;
using System.Configuration;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment__LTL__2019
{
    [Binding]
    public class AddShipment_LTL_2019_Special_Instructions_Section_Steps: AddShipments
    {
        public string userName;
        public string password;
        CommonMethodsCrm crmLogin = new CommonMethodsCrm();
        public string userType;

        [Given(@"I am an operations or station owner user")]
        public void GivenIAmAnOperationsOrStationOwnerUser()
        {
            userType = "internal";
            userName = ConfigurationManager.AppSettings["username-NewScreenCrmOperationUser"].ToString();
            password = ConfigurationManager.AppSettings["password-NewScreenCrmOperationUser"].ToString();
            crmLogin.LoginToCRMApplication(userName, password);            
        }

        [Given(@"I am a shp\.entry or shp\.entrynorates user (.*)")]
        public void GivenIAmAShp_EntryOrShp_EntrynoratesUserNo(string defaultSpecialInstructions)
        {
            userType = "external";
            if (defaultSpecialInstructions == "No")
            {
                userName = ConfigurationManager.AppSettings["username-NewScreenShipEntryUserNoSplInstruction"].ToString();
                password = ConfigurationManager.AppSettings["password-NewScreenShipEntryUserNoSplInstruction"].ToString();
                crmLogin.LoginToCRMApplication(userName, password);
            }
            else if(defaultSpecialInstructions == "Yes")
            {
                userName = ConfigurationManager.AppSettings["username-NewScreenShipEntryUserWithSplInstruction"].ToString();
                password = ConfigurationManager.AppSettings["password-NewScreenShipEntryUserWithSplInstruction"].ToString();
                crmLogin.LoginToCRMApplication(userName, password);
            }
        }        

        [Given(@"I am a Sales or Sales Management user")]
        public void GivenIAmASalesOrSalesManagementUser()
        {
            userType = "sales";
            userName = ConfigurationManager.AppSettings["username-NewScreenSalesUser"].ToString();
            password = ConfigurationManager.AppSettings["password-NewScreenSalesUser"].ToString();
            crmLogin.LoginToCRMApplication(userName, password);
        }

        [Given(@"I am associated to a customer in which Default Special Instructions have NOT been saved (.*)")]
        public void GivenIAmAssociatedToACustomerInWhichDefaultSpecialInstructionsHaveNOTBeenSaved(string customerName)
        {
            Report.WriteLine("Clicking on Shipments link in left navigation bar");
            Click(attributeName_xpath, ShipmentIcon_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();

            if (userType == "internal" || userType == "sales")
            {                
                Report.WriteLine("Selecting Customer Name from the dropdown list");
                Click(attributeName_xpath, ShipmentListInternal_CustomerDropdown_Xpath);
                GlobalVariables.webDriver.WaitForPageLoad();
                SendKeys(attributeName_xpath, ShipmentList_CustomerSelection_DropdownSearch_Xpath, customerName);
                IList<IWebElement> CustomerDropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentListInternal_CustDropdownVal_Xpath));
                int CustomerDropDownCount = CustomerDropDownList.Count;
                for (int i = 0; i < CustomerDropDownCount; i++)
                {
                    if (CustomerDropDownList[i].Text == customerName)
                    {
                        CustomerDropDownList[i].Click();
                        break;
                    }
                }
                GlobalVariables.webDriver.WaitForPageLoad();
            }
            else if (userType == "external")
            {
                Report.WriteLine("Clicking Add Shipment button");
                Click(attributeName_id, ShipmentList_AddShipmentButton_Id);
                GlobalVariables.webDriver.WaitForPageLoad();                
            }
            else 
            {
                Report.WriteFailure("Invalid user login");
            }
        }

        [Given(@"I am associated to a customer in which Default Special Instructions has been saved (.*)")]
        public void GivenIAmAssociatedToACustomerInWhichDefaultSpecialInstructionsHasBeenSaved(string customerName)
        {
            Report.WriteLine("Clicking on Shipments link in left navigation bar");
            Click(attributeName_xpath, ShipmentIcon_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();

            if (userType == "internal" || userType == "sales")
            {
                Report.WriteLine("Selecting Customer Name from the dropdown list");
                Click(attributeName_xpath, ShipmentListInternal_CustomerDropdown_Xpath);
                GlobalVariables.webDriver.WaitForPageLoad();
                SendKeys(attributeName_xpath, ShipmentList_CustomerSelection_DropdownSearch_Xpath, customerName);
                IList<IWebElement> CustomerDropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentListInternal_CustDropdownVal_Xpath));
                int CustomerDropDownCount = CustomerDropDownList.Count;
                for (int i = 0; i < CustomerDropDownCount; i++)
                {
                    if (CustomerDropDownList[i].Text == customerName)
                    {
                        CustomerDropDownList[i].Click();
                        break;
                    }
                }
                GlobalVariables.webDriver.WaitForPageLoad();
            }
            else if (userType == "external")
            {
                Report.WriteLine("Clicking Add Shipment button");
                Click(attributeName_id, ShipmentList_AddShipmentButton_Id);
                GlobalVariables.webDriver.WaitForPageLoad();
            }
            else
            {
                Report.WriteFailure("Invalid User Login");
            }
        }
       

        [When(@"I arrive on the Add Shipment \(LTL\) 2019 page")]
        public void WhenIArriveOnTheAddShipmentLTLPage2019()
        {
                      
            if(userType == "internal" || userType == "sales")
            {
                Report.WriteLine("Clicking Add Shipment button");
                Click(attributeName_id, ShipmentList_AddShipmentButtonInternalUser_Id);
                GlobalVariables.webDriver.WaitForPageLoad();

                Report.WriteLine("Clicking LTL tile");
                Click(attributeName_id, ShipmentList_LTLtile_Id);
                GlobalVariables.webDriver.WaitForPageLoad();

            }      
            else if(userType == "external")
            {                
                Report.WriteLine("Clicking LTL tile");
                Click(attributeName_id, ShipmentList_LTLtile_Id);
                GlobalVariables.webDriver.WaitForPageLoad();
            }
            else
            {
                Report.WriteFailure("Invalid Operation");
            }

        }

        [Then(@"I will see the Special Instructions text box")]
        public void ThenIWillSeeTheSpecialInstructionsTextBox()
        {
            VerifyElementPresent(attributeName_xpath, SpecialInstructionsTitle_NewScreen_Xpath, "Special Instructions Field");
            Report.WriteLine("Special Instructions field is present");         
        }

        [Then(@"I will see the watermark verbiage Enter any special instructions\.\.\. displayed in the Special Instructions text box")]
        public void ThenIWillSeeTheWatermarkVerbiageEnterAnySpecialInstructions_DisplayedInTheSpecialInstructionsTextBox()
        {            
            string specialInstructionFieldValue = GetAttribute(attributeName_xpath, SpecialInstructionsTextBox_NewScreen_Xpath, "placeholder");
            Assert.AreEqual("Enter any special instructions...", specialInstructionFieldValue);
        }
        
        [Then(@"I will see the Special Instructions field with\tsaved information")]
        public void ThenIWillSeeTheSpecialInstructionsFieldWithSavedInformation()
        {
            VerifyElementPresent(attributeName_xpath, SpecialInstructionsTitle_NewScreen_Xpath, "Special Instructions Field");
            Report.WriteLine("Special Instructions field is present");            
            string specialInstructionFieldValue = Gettext(attributeName_id, SpecialInstructionsTextBox_NewScreen_Id);        
            Report.WriteLine("Special Instruction Field displays saved text: " + specialInstructionFieldValue);
        }

        [Then(@"the Special Instructions field is editable")]
        public void ThenTheSpecialInstructionsFieldIsEditable()
        {
            VerifyElementEnabled(attributeName_id, SpecialInstructionsTextBox_NewScreen_Id, "Special Instruction Field");
            Report.WriteLine("Special Instruction field is editable");
        }

    }
}
