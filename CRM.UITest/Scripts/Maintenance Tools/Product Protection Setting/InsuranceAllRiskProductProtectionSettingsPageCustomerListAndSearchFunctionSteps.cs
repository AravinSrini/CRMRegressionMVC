using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Maintenance_Tools.Product_Protection_Setting
{
    [Binding]
    public class InsuranceAllRiskProductProtectionSettingsPageCustomerListAndSearchFunctionSteps : MaintenaceTools
    {
        CommonMethodsCrm crm = new CommonMethodsCrm();
        public WebElementOperations ObjWebElementOperations = new WebElementOperations();
        [Given(@"I am a system admin user (.*) and (.*)")]
        public void GivenIAmASystemAdminUserAnd(string Username, string Password)
        {
            crm.LoginToCRMApplication(Username, Password);
        }

        [Given(@"I am on the Insurance All Risk/Product Protection Settings page of Maintenance Tools")]
        public void GivenIAmOnTheInsuranceAllRiskProductProtectionSettingsPageOfMaintenanceTools()
        {
            Report.WriteLine("Navigation to Insurance All Risk/Product Protection Settings page ");
            Click(attributeName_id, MaintainanceTools_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_id, InsuranceAllRisk_Id, "Button");
            Click(attributeName_id, InsuranceAllRisk_Id);
            VerifyElementPresent(attributeName_xpath, InsuranceRiskPageTitle_Xpath, "Insurance All Risk / Product Protection Settings");

        }
        [Given(@"I am on the Insurance All Risk Or Product Protection Settings page of Maintenance Tools")]
        public void GivenIAmOnTheInsuranceAllRiskOrProductProtectionSettingsPageOfMaintenanceTools()
        {
            Report.WriteLine("Navigation to Insurance All Risk/Product Protection Settings page ");
            Click(attributeName_id, MaintainanceTools_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_id, InsuranceAllRisk_Id, "Button");
            Click(attributeName_id, InsuranceAllRisk_Id);
            VerifyElementPresent(attributeName_xpath, InsuranceRiskPageTitle_Xpath, "Insurance All Risk / Product Protection Settings");
        }


        [Given(@"I am on the Insurance All Risk tab")]
        public void GivenIAmOnTheInsuranceAllRiskTab()
        {
            WaitForElementVisible(attributeName_xpath, InsuranceAllRiskTab_Xpath, "INSURANCE ALL RISK");
            VerifyElementPresent(attributeName_xpath, InsuranceAllRiskTab_Xpath, "INSURANCE ALL RISK");
            Report.WriteLine("Insurance all risk tab");
        }

        [Given(@"I clicked on the Add Customer-Specific Insurance All Risk Settings button")]
        public void GivenIClickedOnTheAddCustomer_SpecificInsuranceAllRiskSettingsButton()
        {
            Click(attributeName_id, AddCustomer_SpecificButton_Id);
            Report.WriteLine("Clicked on Add Customer-Specific Insurance All Risk Settings button");
        }

        [Given(@"I selected a station (.*)")]
        public void GivenISelectedAStation(string Station)
        {
            scrollpagedown();
            Click(attributeName_xpath, InsuranceStation_xpath);
            SelectDropdownValueFromList(attributeName_xpath, InsuranceStationDropdownVal_xpath, Station);
            Report.WriteLine("Chose station from Station dropdown list");
        }

        [Given(@"I select station for Product Protection Page (.*)")]
        public void GivenISelectStationForProductProtectionPage(string Station)
        {
            Click(attributeName_xpath, PPPStation_xpath);
            SelectDropdownValueFromList(attributeName_xpath, PPPStationDropdownVal_xpath, Station);
            Report.WriteLine("Chose a station from station dropdown list");
        }


        [Given(@"I am on the Product Protection tab,")]
        public void GivenIAmOnTheProductProtectionTab()
        {
            WaitForElementVisible(attributeName_xpath, PPPTabClick_xpath, "PPP Button");
            Click(attributeName_xpath, PPPTabClick_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementPresent(attributeName_xpath, PPPTabVal_xpath, "PPP Button");
            VerifyElementPresent(attributeName_xpath, PPPTabVal_xpath, "PPP Button");
            Report.WriteLine("I am on the PPP Tab");
        }

        [When(@"I am on the Product Protection tab,")]
        public void WhenIAmOnTheProductProtectionTab()
        {
            WaitForElementVisible(attributeName_xpath, PPPTabClick_xpath, "PPP Button");
            Click(attributeName_xpath, PPPTabClick_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementPresent(attributeName_xpath, PPPTabVal_xpath, "PPP Button");
            VerifyElementPresent(attributeName_xpath, PPPTabVal_xpath, "PPP Button");
            Report.WriteLine("I am on the PPP Tab");
        }


        [When(@"I click in the Customer Account field")]
        public void WhenIClickInTheCustomerAccountField()
        {
            WaitForElementVisible(attributeName_xpath, InsuranceCustomer_Xpath, "CustomerSelection");
            Click(attributeName_xpath, InsuranceCustomer_Xpath);
            Report.WriteLine("Clicked on Customer account field");
        }

        [When(@"I click on the details icon \(\+\) of any displayed station with customer-specific insurance all risk,")]
        public void WhenIClickOnTheDetailsIconOfAnyDisplayedStationWithCustomer_SpecificInsuranceAllRisk()
        {
            scrollpagedown();
            Click(attributeName_xpath, InsuranceGridFirstExpandButton_xpath);
            Report.WriteLine("Expanded First details of any displayed station with customer-specific insurance all risk");
        }

        [When(@"I click in the Select Customer account field")]
        public void WhenIClickInTheSelectCustomerAccountField()
        {
            Click(attributeName_xpath, PPPCustomer_xpath);
            Report.WriteLine("Clicked on Customer account field");
        }



        [When(@"I enter any value in the Search field in the Customers With Product Protection section (.*)")]
        public void WhenIEnterAnyValueInTheSearchFieldInTheCustomersWithProductProtectionSection(string SearchVal)
        {

            SendKeys(attributeName_xpath, PPPSearchOption_xpath, SearchVal);
            Report.WriteLine("The value to be searched is passed to the search field");
        }
        [Then(@"any records matching the search criteria will be displayed as I enter values in the search field (.*)\.")]
        public void ThenAnyRecordsMatchingTheSearchCriteriaWillBeDisplayedAsIEnterValuesInTheSearchField_(string SearchVal)
        {
            Report.WriteLine("Verifying the filtered records in UI with search value");
            string CustColumnAllVal = Gettext(attributeName_xpath, PPPSearchFirstCustName_xpath);
            int count = GetCount(attributeName_xpath, PPPSearchfieldCustNameCol_xpath);
            if (count > 0)
            {
                if (CustColumnAllVal.Contains(SearchVal))
                {
                    Report.WriteLine("Passed search value is matching with displaying value");
                    string actColor = GetCSSValue(attributeName_xpath, "//td[1]/span", "background-color");
                    Assert.AreEqual(actColor, "rgba(81, 123, 207, 0.4)");
                }
                else
                {
                    Report.WriteLine("Unable to verify the filtered functionality as passed data does not exits in row");
                    Assert.IsTrue(false);
                }
            }
        }

        [Then(@"The PPP customers will be listed in alphabetical order (.*)")]
        public void ThenThePPPCustomersWillBeListedInAlphabeticalOrder(string Station)
        {
            List<string> ExpAcc = new List<string>();
            List<CustomerSetup> value = DBHelper.GetAllDefaultActiveCustomers(Station);
            for (int j = 1; j < value.Count; j++)
            {
                string custname = value[j].CustomerName;
                ExpAcc.Add(custname);
            }
            IList<IWebElement> CustomerAllUI = GlobalVariables.webDriver.FindElements(By.XPath(PPPAllCustomer_xpath));
            List<string> UICustVal = new List<string>();
            List<string> CustomerListValues = ObjWebElementOperations.GetListFromIWebElement(CustomerAllUI);
            for (int i = 1; i < CustomerListValues.Count; i++)
            {
                UICustVal.Add(CustomerListValues[i]);
            }
            int TotalCustUICount = CustomerAllUI.Count;
            Assert.AreEqual(ExpAcc.Count + 1, TotalCustUICount);
            CollectionAssert.AreEqual(ExpAcc, UICustVal);
            Report.WriteLine("Customers are in Alphabetical order in Product Protection Page");
        }


        [Then(@"The customers will be listed in alphabetical order in the Insurance All Risk page (.*)")]
        public void ThenTheCustomersWillBeListedInAlphabeticalOrderInTheInsuranceAllRiskPage(string Station)
        {
            List<string> ExpAcc = new List<string>();
            List<CustomerSetup> value = DBHelper.GetAllDefaultActiveCustomers(Station);
            for (int j = 1; j < value.Count; j++)
            {
                string custname = value[j].CustomerName;
                ExpAcc.Add(custname);
            }
            IList<IWebElement> CustomerAllUI = GlobalVariables.webDriver.FindElements(By.XPath(InsuranceAllCustomer_xpath));
            List<string> UICustVal = new List<string>();
            List<string> CustomerListValues = ObjWebElementOperations.GetListFromIWebElement(CustomerAllUI);
            for(int i = 1; i< CustomerListValues.Count;i++)
            {
                UICustVal.Add(CustomerListValues[i]);
            }
            int TotalCustUICount = CustomerAllUI.Count;
            Assert.AreEqual(ExpAcc.Count + 1, TotalCustUICount);
            CollectionAssert.AreEqual(ExpAcc, UICustVal);
            Report.WriteLine("Customers are in Alphabetical order in Insurance All Risk Page");
        }

        [Then(@"The customers in PPP will be listed in hierarchy format (.*),")]
        public void ThenTheCustomersInPPPWillBeListedInHierarchyFormat(string Station)
        {
            List<string> ExpAcc = new List<string>();
            List<CustomerSetup> value = DBHelper.GetAllDefaultActiveCustomers(Station);
            for (int j = 0; j < value.Count; j++)
            {
                string custname = value[j].CustomerName;
                ExpAcc.Add(custname);
            }

            IList<IWebElement> CustomerAllUI = GlobalVariables.webDriver.FindElements(By.XPath(PPPAllCustomer_xpath));
            List<string> CustomerListValues = ObjWebElementOperations.GetListFromIWebElement(CustomerAllUI);
            int TotalCustUICount = CustomerAllUI.Count;
            Assert.AreEqual(ExpAcc.Count + 1, TotalCustUICount);
            IList<IWebElement> CustomerUI = GlobalVariables.webDriver.FindElements(By.XPath(PPPPrimaryCustomer_xpath));

            List<string> CustUI = ObjWebElementOperations.GetListFromIWebElement(CustomerUI);
            for (int i = 1; i <= CustomerUI.Count; i++)
            {
                int accID = DBHelper.GetCustomerAccountId(CustUI[i].ToString());
                List<string> val = DBHelper.GetSubAccountDetails(accID);
                if (val.Count > 0)
                {
                    IList<IWebElement> SubCustomerUI = GlobalVariables.webDriver.FindElements(By.XPath(PPPSubAccount_xpath));
                    int UIMatchCount = 0;

                    for (int j = 1; j <= SubCustomerUI.Count; j++)
                    {
                        List<string> SubAccountListValues = ObjWebElementOperations.GetListFromIWebElement(SubCustomerUI);
                        if (val.Contains(SubAccountListValues[j]))
                        {
                            UIMatchCount++;
                            Report.WriteLine("Displayed account is the subaccount of the chosen Primary account " + SubAccountListValues[j] + "");
                        }
                        else
                        {
                            Report.WriteLine("Displayed account is not the subaccount of the chosen primary account");
                        }
                    }
                    if (val.Count == UIMatchCount)
                    {
                        Report.WriteLine("UI Subaccount matches with DB count");
                    }
                    else
                    {
                        Report.WriteFailure("UI Subaccount does not match with DB count");
                        Assert.Fail();
                    }
                }
                else
                {
                    Report.WriteLine("No Subaccounts exists for the chosen primary account");
                    break;
                }
            }
        }

        [Then(@"The customers will be listed in hierarchy format (.*),")]
        public void ThenTheCustomersWillBeListedInHierarchyFormat(string Station)
        {

            List<string> ExpAcc = new List<string>();
            List<CustomerSetup> value = DBHelper.GetAllDefaultActiveCustomers(Station);
            for (int j = 0; j < value.Count; j++)
            {
                string custname = value[j].CustomerName;
                ExpAcc.Add(custname);
            }

            IList<IWebElement> CustomerAllUI = GlobalVariables.webDriver.FindElements(By.XPath(InsuranceAllCustomer_xpath));
            List<string> CustomerListValues = ObjWebElementOperations.GetListFromIWebElement(CustomerAllUI);

            int TotalCustUICount = CustomerAllUI.Count;
            Assert.AreEqual(ExpAcc.Count + 1, TotalCustUICount);
            IList<IWebElement> CustomerUI = GlobalVariables.webDriver.FindElements(By.XPath(InsuranceCustomer_xpath));
            List<string> CustUI = ObjWebElementOperations.GetListFromIWebElement(CustomerUI);

            for (int i = 1; i < CustomerUI.Count; i++)
            {
                int accID = DBHelper.GetCustomerAccountId(CustUI[i].ToString());
                List<string> val = DBHelper.GetSubAccountDetails(accID);
                if (val.Count > 0)
                {
                    IList<IWebElement> SubCustomerUI = GlobalVariables.webDriver.FindElements(By.XPath(InsuranceSubAccount_xpath));
                    int UIMatchCount = 0;

                    for (int j = 0; j < SubCustomerUI.Count; j++)
                    {
                        List<string> SubAccountListValues = ObjWebElementOperations.GetListFromIWebElement(SubCustomerUI);
                        if (val.Contains(SubAccountListValues[j]))
                        {
                            UIMatchCount++;
                            Report.WriteLine("Displayed account is the subaccount of the chosen Primary account " + SubAccountListValues[j] + "");
                        }
                        else
                        {
                            Report.WriteLine("Displayed account is not the subaccount of the chosen primary account");
                        }
                    }
                    if (val.Count == UIMatchCount)
                    {
                        Report.WriteLine("UI Subaccount matches with DB count");
                    }
                    else
                    {
                        Report.WriteFailure("UI Subaccount does not match with DB count");
                        Assert.Fail();
                    }
                }
                else
                {
                    Report.WriteLine("No Subaccounts exists for the chosen primary account");         
                }
            }

        }

       

        [Then(@"The customers will be displayed alphabetically\.")]
        public void ThenTheCustomersWillBeDisplayedAlphabetically_()
        {
            scrollpagedown();
            IList<IWebElement> GridFirstCustomerNameUI = GlobalVariables.webDriver.FindElements(By.XPath(InsuranceGridFirstCustomerName_xpath));
            List<string> GridCustomerNameUI = ObjWebElementOperations.GetListFromIWebElement(GridFirstCustomerNameUI);
            List<string> AlphabeticalArray = new List<string>();
            for (int i = 0; i < GridCustomerNameUI.Count; i++)
            {
                AlphabeticalArray.Add(GridCustomerNameUI[i]);
            }
            GridCustomerNameUI.Sort();
            CollectionAssert.AreEqual(GridCustomerNameUI, AlphabeticalArray);
            Report.WriteLine("Displayed Customers are sorted in acending order");

        }

        [Then(@"I will have a search option in the Customers With Product Protection section\.")]
        public void ThenIWillHaveASearchOptionInTheCustomersWithProductProtectionSection_()
        {
            VerifyElementPresent(attributeName_xpath, PPPSearchOption_xpath, "search option");
            Report.WriteLine("Search option exists in Product protecton page");
        }

        [Then(@"any records matching the search criteria will be displayed as I enter values in the search field\.")]
        public void ThenAnyRecordsMatchingTheSearchCriteriaWillBeDisplayedAsIEnterValuesInTheSearchField_()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
