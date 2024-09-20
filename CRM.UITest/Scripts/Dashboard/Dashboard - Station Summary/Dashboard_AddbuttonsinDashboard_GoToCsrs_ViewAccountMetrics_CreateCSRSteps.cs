using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRM.UITest.Objects;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using OpenQA.Selenium;
using Rrd.Dls.IdentityServer.Core.Dto;
using Rrd.ServiceAccessLayer;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;



namespace CRM.UITest.Scripts.Dashboard
{
    [Binding]
    public class Dashboard_AddbuttonsinDashboard_GoToCsrs_ViewAccountMetrics_CreateCSRSteps : ObjectRepository
    {
        [When(@"I click on the create CSr button")]
        public void WhenIClickOnTheCreateCSrButton()
        {
            Report.WriteLine("Verifying Click Functionality of Create CSR button");
            WaitForElementVisible(attributeName_id, Dashboard_CreateCSR_button_Id, "Create CSR button");
            Click(attributeName_id, Dashboard_CreateCSR_button_Id);
        }

        [When(@"I Click on the View Account Metrics button")]
        public void WhenIClickOnTheViewAccountMetricsButton()
        {
            Report.WriteLine("Verifying Click Functionality of View Account Metrics button");
            Click(attributeName_xpath, Dashboard_ViewAccountMetrics_button_Xpath);
            WaitForElementVisible(attributeName_xpath, AccountMetricsPage_Text_Xpath, "Account Metrics");
        }

        [Then(@"I will be see View Account Metrics button(.*)based on User types(.*)")]
        public void ThenIWillBeSeeViewAccountMetricsButtonbasedOnUserTypes(string ViewAccountMetrics, string UserType)
        {
            Report.WriteLine("Verify the presence of View Account Metrics button");
            if (UserType == "StationUser")
            {

                VerifyElementPresent(attributeName_xpath, Dashboard_ViewAccountMetrics_button_Xpath, "View Account Metrics button");
                string ViewAccountMetrics_Button_Text_UI = Gettext(attributeName_xpath, Dashboard_ViewAccountMetrics_button_Xpath);
                Assert.AreEqual(ViewAccountMetrics_Button_Text_UI, ViewAccountMetrics);
            }
            else
            {
                VerifyElementNotPresent(attributeName_xpath, Dashboard_ViewAccountMetrics_button_Xpath, "View Account Metrics button");
            }
        }

        [Then(@"I will be able to see Create CSR button(.*)")]
        public void ThenIWillBeAbleToSeeCreateCSRButton(string CreateCSR_text)
        {
            Report.WriteLine("Verify the presence of View Create CSR button");
            WaitForElementVisible(attributeName_id, Dashboard_CreateCSR_button_Id, "Create CSR button");
            string CreateCSR_button_UI = Gettext(attributeName_id, Dashboard_CreateCSR_button_Id);
            Assert.AreEqual(CreateCSR_button_UI, CreateCSR_text);
        }

        [Then(@"I will be able to see select a CSR text in the dropdown field (.*)")]
        public void ThenIWillBeAbleToSeeSelectACSRTextInTheDropdownField(string SelectAcsr_text)
        {
            Report.WriteLine("Verify the presence of Select a CSR Text");
            WaitForElementVisible(attributeName_xpath, Dashboard_SelectACSR_Text_Xpath, "Select a CSR Text from Dropdown");
            string SelectACSR_Text_UI = Gettext(attributeName_xpath, Dashboard_SelectACSR_Text_Xpath);
            Assert.AreEqual(SelectACSR_Text_UI, SelectAcsr_text);
        }

        [Then(@"I will be able to see Go to a CSR Text(.*)")]
        public void ThenIWillBeAbleToSeeGoToACSRText(string GoToACsr_text)
        {
            Report.WriteLine("Verify the presence of Select Go To a CSR Text");
            WaitForElementVisible(attributeName_xpath, Dashboard_GoToACSR_Text_xpath, "Go To A CSR");
            string GoToACSR_Text_UI = Gettext(attributeName_xpath, Dashboard_GoToACSR_Text_xpath);
            Assert.AreEqual(GoToACSR_Text_UI, GoToACsr_text);
        }

        [Then(@"the Customer Names from the dropdown matches with Database Customer Names(.*)based on the(.*)")]
        public void ThenTheCustomerNamesFromTheDropdownMatchesWithDatabaseCustomerNamesbasedOnThe(string Username, string UserType)
        {
            switch (UserType)
            {
                case "NonAdmins":
                    {
                        Report.WriteLine("Verifying Customer Name from the drodpdown matches with Database");
                        WaitForElementVisible(attributeName_xpath, Dashboard_SelectACSR_Text_Xpath, "Select a CSR Text from Dropdown");
                        Click(attributeName_xpath, Dashboard_SelectACSR_Text_Xpath);
                        IList<IWebElement> DropDownValue = (GlobalVariables.webDriver.FindElements(By.XPath(Dashboard_CSR_DropDown_list_Xpath)));
                        if (DropDownValue.Count > 1)
                        {
                            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);
                            List<AppUserClaimInfo> AllClaimDetails = IDP.GetUserClaimDetails(Username);
                            List<string> setClaimDetails = AllClaimDetails.Where(c => c.ClaimType == "dlscrm-StationId").Select(a => a.ClaimValue).ToList();

                            List<string> _CSRStageCustomerName_based_on_StationId = DBHelper.GetCSRStageCustomerName_based_on_StationId(setClaimDetails);
                            List<string> _DropdownValue_CustomerName = DropDownValue.Skip(1).Select(a => a.Text).ToList();
                            _DropdownValue_CustomerName.Sort();
                            _CSRStageCustomerName_based_on_StationId.Sort();
                            CollectionAssert.AreEqual(_DropdownValue_CustomerName, _CSRStageCustomerName_based_on_StationId);
                        }
                        else
                        {
                            Report.WriteLine("No CSR present in the Select a CSR dropdown");
                        }
                        break;
                    }

                case "SYSAdmins":
                    {
                        Report.WriteLine("Verifying Customer Name of first 100 from the drodpdown matches with first 100 Customer Names from the Database");
                        WaitForElementVisible(attributeName_xpath, Dashboard_SelectACSR_Text_Xpath, "Select a CSR Text from Dropdown");
                        Click(attributeName_xpath, Dashboard_SelectACSR_Text_Xpath);
                        IList<IWebElement> DropDownValue = (GlobalVariables.webDriver.FindElements(By.XPath(Dashboard_CSR_DropDown_list_Xpath)));
                        if (DropDownValue.Count > 1)
                        {
                            List<string> CustomerName_Stage = DBHelper.GetCSRStageCustomerName();
                            List<string> _DropdownValue_CustomerName = DropDownValue.Skip(1).Select(a => a.Text).ToList();
                            _DropdownValue_CustomerName.Sort();
                            _DropdownValue_CustomerName = _DropdownValue_CustomerName.Take(100).Select(a => a).ToList();
                            CollectionAssert.AreEqual(_DropdownValue_CustomerName, CustomerName_Stage);
                        }
                        else
                        {
                            Report.WriteLine("No CSR present in the Select a CSR dropdown");
                        }
                        break;
                    }

                case "PricingConfiguration":
                    {
                        Report.WriteLine("Verifying Customer Name of first 20 from the drodpdown matches with first 20 Customer Names from the Database");
                        WaitForElementVisible(attributeName_xpath, Dashboard_SelectACSR_Text_Xpath, "Select a CSR Text from Dropdown");
                        Click(attributeName_xpath, Dashboard_SelectACSR_Text_Xpath);
                        IList<IWebElement> DropDownValue = (GlobalVariables.webDriver.FindElements(By.XPath(Dashboard_CSR_DropDown_list_Xpath)));
                        if (DropDownValue.Count > 1)
                        {
                            List<int> listStatusId = new List<int>();
                            listStatusId.Add(13); listStatusId.Add(3);                       
                            List<CsrSetup> _cSRSetUp = DBHelper.GetCSRListForStatusIds(listStatusId);
                            List<string> _CustomerName = _cSRSetUp.Select(t => t.CustomerName).ToList();
                            _CustomerName.Sort();
                            List<string> _customerNameFirstTwenty = _CustomerName.Take(20).ToList();
                            List<string> _DropdownValue_CustomerName = DropDownValue.Skip(1).Select(a => a.Text).ToList();
                            _DropdownValue_CustomerName.Sort();
                            _DropdownValue_CustomerName = _DropdownValue_CustomerName.Take(20).Select(a => a).ToList();
                            CollectionAssert.AreEqual(_DropdownValue_CustomerName, _customerNameFirstTwenty);
                        }
                        else
                        {
                            Report.WriteLine("No CSR present in the Select a CSR dropdown");
                        }
                        break;
                    }

                case "SystemConfiguration":
                    {
                        Report.WriteLine("Verifying Customer Name of first 20 from the drodpdown matches with first 20 Customer Names from the Database");
                        WaitForElementVisible(attributeName_xpath, Dashboard_SelectACSR_Text_Xpath, "Select a CSR Text from Dropdown");
                        Click(attributeName_xpath, Dashboard_SelectACSR_Text_Xpath);
                        IList<IWebElement> DropDownValue = (GlobalVariables.webDriver.FindElements(By.XPath(Dashboard_CSR_DropDown_list_Xpath)));
                        if (DropDownValue.Count > 1)
                        {
                            List<int> listStatusId = new List<int>();
                            listStatusId.Add(11); listStatusId.Add(2); listStatusId.Add(3); listStatusId.Add(5); listStatusId.Add(13);
                            List<CsrSetup> _cSRSetUp = DBHelper.GetCSRListForStatusIds(listStatusId);
                            List<string> _CustomerName = _cSRSetUp.Select(t => t.CustomerName).ToList();
                            _CustomerName.Sort();
                            List<string> _customerNameFirstTwenty = _CustomerName.Take(20).ToList();
                            List<string> _DropdownValue_CustomerName = DropDownValue.Skip(1).Select(a => a.Text).ToList();
                            _DropdownValue_CustomerName.Sort();
                            _DropdownValue_CustomerName = _DropdownValue_CustomerName.Take(20).Select(a => a).ToList();
                            CollectionAssert.AreEqual(_DropdownValue_CustomerName, _customerNameFirstTwenty);
                        }
                        else
                        {
                            Report.WriteLine("No CSR present in the Select a CSR dropdown");
                        }
                        break;
                    }
            }
        }

        [Then(@"the count of CSR from the dropdown matches with total PieChart count")]
        public void ThenTheCountOfCSRFromTheDropdownMatchesWithTotalPieChartCount()
        {
            Report.WriteLine("Verifying Piechart total count and Dropdown CSR total Count are same");
            string TotalPieChartCount = Gettext(attributeName_xpath, Dashboard_PieChart_TotalCount_Xpath);
            int TotalPieChartCount_UI = Convert.ToInt32(TotalPieChartCount);
            WaitForElementVisible(attributeName_xpath, Dashboard_SelectACSR_Text_Xpath, "Select a CSR Text from Dropdown");
            Click(attributeName_xpath, Dashboard_SelectACSR_Text_Xpath);
            IList<IWebElement> DropDownValue = (GlobalVariables.webDriver.FindElements(By.XPath(Dashboard_CSR_DropDown_list_Xpath)));
            Assert.AreEqual(TotalPieChartCount_UI, DropDownValue.Count - 1);
        }

        [Then(@"I will be navigated to the Account Information page(.*)")]
        public void ThenIWillBeNavigatedToTheAccountInformationPage(string AccountInformation_text)
        {
            string configURL = launchUrl;
            string resultPagrURL = configURL + "L/Customer/AccountInformation";
            Report.WriteLine("Verifying User Navigated to Account Information page by URL");
            WaitForElementVisible(attributeName_xpath, SubmitCSR_AccountInformationPage_Text_Xpath, "Account Information Text");
            if (GetURL() == resultPagrURL)
            {
                Report.WriteLine("Verified User Navigated to Account Information page");
                string SubmitCSR_AccountInformationPage_Text_UI = Gettext(attributeName_xpath, SubmitCSR_AccountInformationPage_Text_Xpath);
                Assert.AreEqual(SubmitCSR_AccountInformationPage_Text_UI, AccountInformation_text);
            }
            else
            {
                Report.WriteLine("Verified User not Navigated to Account Information page");
                throw new Exception("Failed to Navigate to the Account Information page");
            }
        }

        [Then(@"I able to search the CSR from the dropdown(.*)and(.*)")]
        public void ThenIAbleToSearchTheCSRFromTheDropdownand(string Search_text, string UserType)
        {
            switch (UserType)
            {
                case "NonAdmins":
                    {
                        Click(attributeName_xpath, Dashboard_SelectACSR_Text_Xpath);
                        SendKeys(attributeName_xpath, Dashboard_CSR_DropDownSearchTextbox_Xpath, Search_text);
                        IList<IWebElement> DropDownValueA = (GlobalVariables.webDriver.FindElements(By.XPath(Dashboard_CSR_DropDown_list_Xpath)));
                        if (DropDownValueA.Count > 0)
                        {
                            List<string> _DropdownValue_B = DropDownValueA.Select(s => s.Text.ToUpper()).ToList();

                            for (int j = 0; j < _DropdownValue_B.Count; j++)
                            {
                                if (_DropdownValue_B[j].Contains(Search_text.ToUpper()))
                                {
                                    Report.WriteLine("filtered data is populated in the dropdown for the entered search");
                                }
                                else
                                {
                                    Report.WriteLine("filtered data is not populated in the dropdown for the entered search");
                                    throw new Exception("filtered data is not populated in the dropdown for the entered search");
                                }
                            }
                        }
                        else
                        {
                            Report.WriteLine("No Data found for the entered search");
                        }
                        break;
                    }

                case "Admins":
                    {
                        Click(attributeName_xpath, Dashboard_SelectACSR_Text_Xpath);
                        SendKeys(attributeName_xpath, Dashboard_CSR_DropDownSearchTextbox_Xpath, Search_text);
                        IList<IWebElement> DropDownValueA = (GlobalVariables.webDriver.FindElements(By.XPath(Dashboard_CSR_DropDown_list_Xpath)));
                        if (DropDownValueA.Count > 0)
                        {
                            List<string> _DropdownValue_B = DropDownValueA.Select(s => s.Text.ToUpper()).ToList();
                            for (int j = 0; j < _DropdownValue_B.Count; j++)
                            {
                                if (_DropdownValue_B[j].Contains(Search_text.ToUpper()))
                                {
                                    Report.WriteLine("filtered data is populated in the dropdown for the entered search");
                                }
                                else
                                {
                                    Report.WriteLine("filtered data is not populated in the dropdown for the entered search");
                                    throw new Exception("filtered data is not populated in the dropdown for the entered search");
                                }
                            }
                        }
                        else
                        {
                            Report.WriteLine("No Data found for the entered search");
                        }
                        break;
                    }
            }
        }

        [Then(@"I will be navigated to the Account Metrics page(.*)")]
        public void ThenIWillBeNavigatedToTheAccountMetricsPage(string AccountMetrics_text)
        {
            Report.WriteLine("Verifying User Navigated to Account Metrics page");
            WaitForElementVisible(attributeName_xpath, AccountMetricsPage_Text_Xpath, "Account Metrics Page Header");
            string AccountMetricsPage_Text_UI = Gettext(attributeName_xpath, AccountMetricsPage_Text_Xpath);
            string[] b = AccountMetricsPage_Text_UI.Split('\r');
            string AccountMetrics_Splitted = b[0];
            Assert.AreEqual(AccountMetrics_Splitted, AccountMetrics_text);
        }

        [Then(@"selecting of any CSR from the dropdown will be navigated to the corresponding CSR Details page")]
        public void ThenSelectingOfAnyCSRFromTheDropdownWillBeNavigatedToTheCorrespondingCSRDetailsPage()
        {
            WaitForElementVisible(attributeName_xpath, Dashboard_SelectACSR_Text_Xpath, "Select a CSR Text from Dropdown");
            Click(attributeName_xpath, Dashboard_SelectACSR_Text_Xpath);
            IList<IWebElement> DropDownValue = (GlobalVariables.webDriver.FindElements(By.XPath(Dashboard_CSR_DropDown_list_Xpath)));

            if (DropDownValue.Count > 1)
            {
                string Dashboard_CSR_DropDown_value = Gettext(attributeName_xpath, Dashboard_CSR_DropDown_list_Second_Xpath);
                Click(attributeName_xpath, Dashboard_CSR_DropDown_list_Second_Xpath);
                WaitForElementVisible(attributeName_xpath, CSRDetailsPageHeader_Text_Xpath, "CSR Details");
                string CSRDetails_Text_UI = Gettext(attributeName_xpath, CSRDetailsPage_CSRName_Text_Xpath);
                Report.WriteLine("Verifying the Navigation to CSR Details Page");
                Assert.AreEqual(CSRDetails_Text_UI, Dashboard_CSR_DropDown_value);
            }
            else
            {
                Report.WriteLine("No CSR present in the Dropdown");
            }

        }
    }
}
