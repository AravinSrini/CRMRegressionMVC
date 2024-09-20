using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.AddShipment_InsuredValue_AllUsers
{
    [Binding]
    public  class AddShipment_InsuredValue_AllUsersSteps : AddShipments
    {
        [Given(@"I click on Add Shipment button (.*) of (.*)")]
        public void GivenIClickOnAddShipmentButtonOf(string user, string customername)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            if (user == "customer")
            {
                Report.WriteLine("Click on Add shipment button");
                Click(attributeName_id, ShipmentList_AddShipmentButton_Id);

            }
            else if (user == "station")
            {
                Report.WriteLine("I select the Customer from the dropdown list"); 
                Click(attributeName_xpath, AllCustomerDropdown_Selection_Internal_Xpath);
                Report.WriteLine("Selecting" + customername + "from the Customer dropdown list");

                IList<IWebElement> CustomerDropdown_List = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='CustomerType_chosen']/div/ul/li"));
                int CustomerNameListCount = CustomerDropdown_List.Count;
                for (int i = 0; i < CustomerNameListCount; i++)
                {
                    if (CustomerDropdown_List[i].Text == customername)
                    {
                        CustomerDropdown_List[i].Click();
                        break;
                    }
                   
                }

                Report.WriteLine("Click on Add Shipment Button");
                Click(attributeName_id, AddShipmentButtionInternal_Id);
            }
        }

        [Given(@"I entered the (.*) in Insured value field")]
        public void GivenIEnteredTheInInsuredValueField(string value)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            scrollElementIntoView(attributeName_id, InsuredValue_TextBox_Id);
            Report.WriteLine("I entered the value in Isured value field");
            SendKeys(attributeName_id, InsuredValue_TextBox_Id, value);
        }

        [Given(@"I click on Terms and Conditions button")]
        public void GivenIClickOnTermsAndConditionsButton()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("I click on Terms and Conditions");
            Click(attributeName_xpath, InsuredValue_TermsAndConditionsLink_xpath);
        }

        [When(@"I mouser hover on Insure Value tool tip")]
        public void WhenIMouserHoverOnInsureValueToolTip()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            scrollElementIntoView(attributeName_xpath, InsuredValue_ToolTip_xpath);            
            Report.WriteLine("Mouse hover over on Insured Value tool tip");
            OnMouseOver(attributeName_xpath, InsuredValue_ToolTip_xpath);
          
        }

        [When(@"I select the tiles (.*)")]
        public void WhenISelectTheTiles(string service)
        {
            switch (service)
            {
                case "LTL":

                    {
                        Report.WriteLine("Clicking on the LTL tiles");
                        Click(attributeName_id, ShipmentList_LTLtile_Id);
                        break;
                    }

                case "Truckload":

                    {
                        Report.WriteLine("Clicking on the Truckload tiles");
                        Click(attributeName_id, ShipmentList_Truckloadtile_Id);
                        break;
                    }

                case "Partial Truckload":

                    {
                        Report.WriteLine("Clicking on the Partial Truckload tiles");
                        Click(attributeName_id, ShipmentList_PartialTruckloadtile_Id);
                        break;

                    }

                case "Intermodal":
                    {
                        Report.WriteLine("Clicking on the Intermodal tiles");
                        Click(attributeName_id, ShipmentList_Intermodeltiles_Id);
                        break;
                    }
            }

        }

        [When(@"I entered the (.*) in Insured value field")]
        public void WhenIEnteredTheInInsuredValueField(string value)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            scrollElementIntoView(attributeName_id, InsuredValue_TextBox_Id);
            Report.WriteLine("I entered the value in Isured value field");
            SendKeys(attributeName_id, InsuredValue_TextBox_Id, value);
        }

        [When(@"I click on close button from model")]
        public void WhenIClickOnCloseButtonFromModel()
        {
            WaitForElementVisible(attributeName_xpath, InsuredValue_TermsAndCondition_CloseButton_xpath, "Close");
            Report.WriteLine("I click on the close button from DLSW form model");
            Click(attributeName_xpath, InsuredValue_TermsAndCondition_CloseButton_xpath);
        }

        [Then(@"Verify the mouse hover over will display the message (.*)")]
        public void ThenVerifyTheMouseHoverOverWillDisplayTheMessage(string InsuredValueToolTip_Text)
        {
            Report.WriteLine("Verified the mouse hover on tool tip showing message");
            string ActualMessage = GetAttribute(attributeName_xpath, InsuredValue_ToolTip_xpath, "data-title");
            string ActualCap = ActualMessage.ToUpper();
            Assert.AreEqual(InsuredValueToolTip_Text, ActualCap);
        }

        [Then(@"I have (.*) in Insured value field")]
        public void ThenIHaveInInsuredValueField(string EnterValueoption)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            scrollElementIntoView(attributeName_id, InsuredValue_TextBox_Id);
            Report.WriteLine("I have the option to enter insured value in field");            
            string ActualEnterValueOption = GetAttribute(attributeName_id, InsuredValue_TextBox_Id, "placeholder");    
            Assert.AreEqual(EnterValueoption, ActualEnterValueOption);
        }

        [Then(@"Verify the Insured Value field is present and field allows only (.*) and (.*)")]
        public void ThenVerifyTheInsuredValueFieldIsPresentAndFieldAllowsOnlyAnd(string numericaldigit, string decimaldigit)
        {
            Report.WriteLine("Insured Value field is present");
            VerifyElementPresent(attributeName_id, InsuredValue_TextBox_Id, "Insured Value Field");

            Report.WriteLine("Insured Value field taking numerical digit");
            SendKeys(attributeName_id, InsuredValue_TextBox_Id, numericaldigit);
            string ActualNumDigit = GetAttribute(attributeName_id, InsuredValue_TextBox_Id, "value");
            Assert.AreEqual(numericaldigit, ActualNumDigit);
            Clear(attributeName_id, InsuredValue_TextBox_Id);

            Report.WriteLine("Insured Value field taking decimal digit");
            SendKeys(attributeName_id, InsuredValue_TextBox_Id, decimaldigit);
            string ActualDecDigit = GetAttribute(attributeName_id, InsuredValue_TextBox_Id, "value");
            Assert.AreEqual(decimaldigit, ActualDecDigit);
        }
                
        [Then(@"Verify the Dropdown have the (.*)")]
        public void ThenVerifyTheDropdownHaveThe(string InsuredValueType)
        {
            Report.WriteLine("Click on Insured Value Type dropdown");
            Click(attributeName_xpath, InsuredValue_Type_xpath);
            if (InsuredValueType == "New")
            {
                Report.WriteLine("Verify the Dropdown have Used and New option value type");
                String ActualNewOption = Gettext(attributeName_xpath, InsuredValue_TypeNEW_xpath);
                Assert.AreEqual(InsuredValueType, ActualNewOption);
            }
            else if(InsuredValueType == "Used")
            {
                Report.WriteLine("Verify the Dropdown have Used and New option value type");
                String ActualNewOption = Gettext(attributeName_xpath, InsuredValue_TypeUsed_xpath);
                Assert.AreEqual(InsuredValueType, ActualNewOption);
            }


        }

        [Then(@"I will seethe View Term and condition button")]
        public void ThenIWillSeeTheViewTermAndConditionButton()
        {
            Report.WriteLine("I will see the Terms and Condition button");
            VerifyElementPresent(attributeName_xpath, InsuredValue_TermsAndConditionsLink_xpath, "Terms and Conditions");
        }

        [Then(@"Verified the (.*) for exceeds insured value")]
        public void ThenVerifiedTheForExceedsInsuredValue(string error_message)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("I will see the error message");
            string ActualErrorMsg = Gettext(attributeName_xpath, InsuredValue_ValueExceeds_xpath);
            Assert.AreEqual(error_message, ActualErrorMsg);
        }

        [When(@"I click on Terms and Conditions button")]
        public void WhenIClickOnTermsAndConditionsButton()
        {            
            Report.WriteLine("I click on Terms and Conditions");
            Click(attributeName_xpath, InsuredValue_TermsAndConditionsLink_xpath);
        }

        [Then(@"Verify the model with the (.*)")]
        public void ThenVerifyTheModelWithThe(string heading)
        {
            Report.WriteLine("I verified the model heading ");
            WaitForElementVisible(attributeName_xpath, InsuredValue_TermsAndConditions_Heading_xpath, heading);
            String ActualHeading = Gettext(attributeName_xpath, InsuredValue_TermsAndConditions_Heading_xpath);
            Assert.AreEqual(heading, ActualHeading);
        }

        [When(@"I click on Download DLSW Claim Form")]
        public void WhenIClickOnDownloadDLSWClaimForm()
        {
            WaitForElementVisible(attributeName_xpath, InsuredValue_TermsAndConditions_Heading_xpath, "Terms And Conditions Of Coverage");
            scrollElementIntoView(attributeName_xpath, InsuredValue_TermsAndCondition_DownloadForm_xpath);
            Report.WriteLine("Click on the Download DLSW Claim form");
            Click(attributeName_xpath, InsuredValue_TermsAndCondition_DownloadForm_xpath);
        }

        [Then(@"Verified the DLSW Claim Form will be downloaded")]
        public void ThenVerifiedTheDLSWClaimFormWillBeDownloaded()
        {
            Report.WriteLine("Verified the DLSW claim form will be downloaded");
            string downlaodfile = "DownloadDlswwClaimsForm.docx";
            string downloadpath = GetDownloadedFilePath("DownloadDlswwClaimsForm.docx");
            bool Expected = downloadpath.Contains(downlaodfile);
            if(Expected == true)
            {
                Report.WriteLine("DLSWW form has downloaded");
            }
            else
            {
                Report.WriteLine("DLSWW form is not downloaded");
            }

        }


        [Then(@"I should navigated to the Add Shipment LTL page")]
        public void ThenIShouldNavigatedToTheAddShipmentLTLPage()
        {
            Report.WriteLine("I should be Navigated to the Add Shipment (LTL) Page");            
            ScrollToTopElement(attributeName_xpath, AddShipment_PageTitle_xpath);
            VerifyElementPresent(attributeName_xpath, AddShipment_PageTitle_xpath, "Add Shipment (LTL)");
        }

        [Then(@"Verify the dropdown is by default selected as Used")]
        public void ThenVerifyTheDropdownIsByDefaultSelectedAsUsed()
        {
            
            Report.WriteLine("Verified dropdown bydefault selected as Used");
            String ActualInsuredType = Gettext(attributeName_xpath, InsuredValue_Type_xpath);
            Assert.AreEqual("Used", ActualInsuredType);

        }
        [Then(@"I have the option to change Insured Value type as New")]
        public void ThenIHaveTheOptionToChangeInsuredValueTypeAsNew()
        {
            Report.WriteLine("I have option to change the Insured type value");
            Click(attributeName_xpath, InsuredValue_Type_xpath);
            Click(attributeName_xpath, InsuredValue_TypeNEW_xpath);
            String ActualInsuredValueType = Gettext(attributeName_xpath, InsuredValue_Type_xpath);
            Assert.AreEqual("New", ActualInsuredValueType);
        }       

    }
}
