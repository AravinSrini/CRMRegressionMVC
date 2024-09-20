using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.ServiceAccessLayer;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.ShipmentList.ShipmentList_ReferenceNumberSearch_AllUsers
{
    [Binding]
    public class ShipmentList_ReferenceNumberSearch_AllUsersSteps : Shipmentlist
    {  
                     
        [When(@"I navigate to shipment list (.*) page")]
        public void WhenINavigateToShipmentListPage(string ShipmentList_Header)
        {
            Report.WriteLine("I navigate to shipment list page");
            VerifyElementVisible(attributeName_xpath, ShipmentList_Title_Xpath, "Shipment List");
            string ShipmentlistHeader_UI = Gettext(attributeName_xpath, ShipmentList_Title_Xpath);
            Assert.AreEqual(ShipmentList_Header, ShipmentlistHeader_UI);
            VerifyElementNotVisible(attributeName_xpath, ShipmentListGrid_loadingIcon_Xpath, "loading icon");
        }
        
        [When(@"I enter the '(.*)' in Reference Number lookup")]
        public void WhenIEnterTheInReferenceNumberLookup(string EnterReferenceNumber)
        {
            Report.WriteLine("I enter reference number in reference number lookup");
            //VerifyElementNotVisible(attributeName_xpath, ShipmentListGrid_loadingIcon_Xpath, "loading icon");            
            SendKeys(attributeName_xpath, ShipmentList_ReferenceNumLookup_Xpath, EnterReferenceNumber);            
        }
        
        [When(@"I click on search arrow of Reference Number lookup")]
        public void WhenIClickOnSearchArrowOfReferenceNumberLookup()
        {
            Report.WriteLine("I click on search arrow of reference number lookup");
            
                Click(attributeName_xpath, ShipmentList_Referencenumber_searcharrow_Xpath);
               Thread.Sleep(120000);
            
          
        }
        
        [When(@"I enter (.*) in the Reference number lookup")]
        public void WhenIEnterInTheReferenceNumberLookup(string MorethanTenReferenceNumbers)
        {
            Report.WriteLine("I enter more than 10 reference numbers in the reference number lookup");
            VerifyElementNotVisible(attributeName_xpath, ShipmentListGrid_loadingIcon_Xpath, "loading icon");
            SendKeys(attributeName_id, ShipmentList_Referencenumber_Searchbox_Id, MorethanTenReferenceNumbers);
        }
        
        [When(@"I enter the invalid Reference numbers '(.*)' in Reference Number lookup")]
        public void WhenIEnterTheInvalidReferenceNumbersInReferenceNumberLookup(string EnterReferenceNumbers)
        {
            Report.WriteLine("I enter the invalid reference numbers in reference number lookup");
            VerifyElementNotVisible(attributeName_xpath, ShipmentListGrid_loadingIcon_Xpath, "loading icon");
            SendKeys(attributeName_xpath, ShipmentList_ReferenceNumLookup_Xpath, EnterReferenceNumbers);
        }
        
        [When(@"I enter the incorrect reference number '(.*)' in Reference Number lookup")]
        public void WhenIEnterTheIncorrectReferenceNumberInReferenceNumberLookup(string EnterReferenceNumbers)
        {
            Report.WriteLine("I enter the incorrect reference number in the lookup");
            VerifyElementNotVisible(attributeName_xpath, ShipmentListGrid_loadingIcon_Xpath, "loading icon");
            SendKeys(attributeName_xpath, ShipmentList_ReferenceNumLookup_Xpath, EnterReferenceNumbers);
        }
        
        [Then(@"I should be displayed with Reference number Lookup")]
        public void ThenIShouldBeDisplayedWithReferenceNumberLookup()
        {
            Report.WriteLine("I should be displayed with Reference number lookup");
            VerifyElementVisible(attributeName_xpath, ShipmentList_ReferenceNumLookup_Xpath, "Reference Number Lookup");
            VerifyElementVisible(attributeName_id, ShipmentList_Referencenumber_Searchbox_Id, "Enter Reference Number(s) Here");
        }
        
        [Then(@"I click on the search arrow of Reference number Lookup")]
        public void ThenIClickOnTheSearchArrowOfReferenceNumberLookup()
        {
            Report.WriteLine("I click on search arrow of reference number lookup");            
            Click(attributeName_xpath, ShipmentList_Referencenumber_searcharrow_Xpath);
        }
        
        [Then(@"I must be displayed with the '(.*)' in the Error pop up")]
        public void ThenIMustBeDisplayedWithTheInTheErrorPopUp(string Errormessage)
        {
            Report.WriteLine("I should be displayed with Error message in Error pop up");
            string ErrormessageinPopUp_UI = Gettext(attributeName_xpath, ShipmentList_Referencenumber_errormessage_Xpath);
            Assert.AreEqual(Errormessage, ErrormessageinPopUp_UI);
        }
                
        [Then(@"I should see results for the entered reference numbers '(.*)'")]
        public void ThenIShouldSeeResultsForTheEnteredReferenceNumbers(string Ref)
        {
            Report.WriteLine("I should see the results in grid for the entered single reference number");
           // VerifyElementNotVisible(attributeName_xpath, ShipmentListGrid_loadingIcon_Xpath, "loading icon");
            List<string> ShipmentListRefNumber_UI = IndividualColumnData(ShipmentList_Referencenumbersgrid_Xpath);
            string[] valuesexp = Ref.Split(',');
            for (int i = 0; i < ShipmentListRefNumber_UI.Count; i++)
            {                
                if (valuesexp.Contains(ShipmentListRefNumber_UI[i]))
                {
                    Report.WriteLine("Entered Reference value and Reference value appearing in the Results are same");
                }
                else
                {
                    throw new System.Exception("Entered Reference value and Reference value appearing in the Results are not same");
                }
            }
        }
        [Then(@"Reference number lookup is accepting maximum of nine commas seperated ten values")]
        public void ThenReferenceNumberLookupIsAcceptingMaximumOfNineCommasSeperatedTenValues()
        {
            Report.WriteLine("I should be able to allow maximum of 9 commas with reference numbers in reference number lookup");
            VerifyElementNotVisible(attributeName_xpath, ShipmentListGrid_loadingIcon_Xpath, "loading icon");
            var morethantenref_UI = GetValue(attributeName_id, ShipmentList_Referencenumber_Searchbox_Id, "value");
            string[] refvalues = morethantenref_UI.Split(',');
            int actcount = refvalues.Count();
            int expcount = 10;
            if (actcount == expcount)
            {
                Report.WriteLine("user passed not more than 10 reference numbers");
                Assert.AreEqual(10, expcount);
            }
            else
            {
                throw new System.Exception("User passed less than 10 refernce numbers");
            }
        }
        
        [Then(@"I can see the '(.*)'")]
        public void ThenICanSeeThe(string Errormessage)
        {
            Report.WriteLine("Then i can see error message");
            VerifyElementVisible(attributeName_xpath, ShipmentList_GridNoResultsfound_Xpath, "No Results Found");
            string Errormsg_UI = Gettext(attributeName_xpath, ShipmentList_GridNoResultsfound_Xpath);
            Assert.AreEqual(Errormessage, Errormsg_UI);
        }
        
        [Then(@"I should be displayed with the results only for the entered valid reference numbers '(.*)'")]
        public void ThenIShouldBeDisplayedWithTheResultsOnlyForTheEnteredValidReferenceNumbers(string Ref)
        {
            Report.WriteLine("I should see the results for the entered valid reference numbers in grid");
            VerifyElementNotVisible(attributeName_xpath, ShipmentListGrid_loadingIcon_Xpath, "loading icon");
            List<string> ShipmentListRefNumber_UI = IndividualColumnData(ShipmentList_Referencenumbersgrid_Xpath);
            string[] valuesexp = Ref.Split(',');
            for (int i = 0; i < ShipmentListRefNumber_UI.Count; i++)
            {
                if (valuesexp.Contains(ShipmentListRefNumber_UI[i]))
                {
                    Report.WriteLine("Entered valid Reference values and Reference values appearing in the grid are same");
                }
                else
                {
                    throw new System.Exception("Entered valid Reference values and Reference values appearing in the grid are not same");
                }
            }
        }
        
        [Then(@"Report dropdown should be defaulted to Select Report")]
        public void ThenReportDropdownShouldBeDefaultedToSelectReport()
        {
            Report.WriteLine("Report dropdown should be defaulted to Select Report");
            string actText = Gettext(attributeName_xpath, ShipmentList_FilteredReports_Xpath);
            Assert.AreEqual(actText, "Select a Report");
        }
                
        [When(@"I have selected Customer from the dropdown (.*)")]
        public void WhenIHaveSelectedCustomerFromTheDropdown(string Customer_Name)
        {
            Report.WriteLine("Select Customer Name from the dropdown list");
            Click(attributeName_xpath, ShipmentList_CustomerSelection_Xpath);
            
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_Customer_dropdownValue_Xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == Customer_Name)
                {
                    DropDownList[i].Click();
                    break;
                }
            }            
            Thread.Sleep(5000);
        }

        [Then(@"I will be displayed with (.*)")]
        public void ThenIWillBeDisplayedWith(string Error_message)
        {
            Report.WriteLine("I should be displayed with Error message in Error pop up");
            string ErrormessageinPopUp_UI = Gettext(attributeName_xpath, ReferenceSearchforAllCustomersErrmsg_Xpath);
            Assert.AreEqual(Error_message, ErrormessageinPopUp_UI);
        }       

    }
}
