using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.Dls.IdentityServer.Core.Dto;
using Rrd.ServiceAccessLayer;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Insurance_Claims.Claims_List
{
    [Binding]
    public class Insurance_Claims_Claims_List_View_by_UserSteps : InsuranceClaim
    {
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
        string username = null;
        string password = null;
        List<string> ascSort = new List<string>();
        List<string> desSort = new List<string>();
        string Claimnumber;
        InsuranceClaimsubmit CreateClaim = new InsuranceClaimsubmit();
        ClickAndWaitMethods crmWait = new ClickAndWaitMethods();
        IList<IWebElement> CarrierNameValues;
        List<string> carrierNameValuesUI = new List<string>();
        IList<IWebElement> ClaimNumbers;
        List<string> ClaimNumbersUI = new List<string>();


        [Given(@"I am a shp\.inquiry, shp\.inquirynorates, shp\.entry, shp\.entrynorates, Sales Management, Operations, Station Owner, Claim Specialist users")]
        public void GivenIAmAShp_InquiryShp_InquirynoratesShp_EntryShp_EntrynoratesSalesManagementOperationsStationOwnerClaimSpecialistUsers()
        {
            string username = ConfigurationManager.AppSettings["username-salesdelta"].ToString();
            string password = ConfigurationManager.AppSettings["password-salesdelta"].ToString();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [When(@"I arrive on the Claims List page")]
        public void WhenIArriveOnTheClaimsListPage()
        {
            if (username != ("CharlieClaimspecialist"))
            {
                Click(attributeName_id, ClaimsIcon_Id);
            }
            else
            {
                Report.WriteLine("Logged in user is claims specialist user");
            }
            Verifytext(attributeName_xpath, ClaimsListPage_HeaderText_Xpath, "Claims List");
        }

        [Then(@"I can see Open status is selected by default")]
        public void ThenICanSeeOpenStatusIsSelectedByDefault()
        {
            VerifyElementEnabled(attributeName_xpath, ClaimsList_OpenCheckbox_xpath, "Open");
        }

        [Then(@"I have option to select to different status Pending, Denied, Paid, Cancelled")]
        public void ThenIHaveOptionToSelectToDifferentStatusPendingDeniedPaidCancelled()
        {
            Click(attributeName_xpath, ClaimsList_PendingCheckbox_xpath);
            Click(attributeName_xpath, ClaimsList_PaidCheckbox_xpath);
            Click(attributeName_xpath, ClaimsList_DeniedCheckbox_xpath);
            Click(attributeName_xpath, ClaimsList_Cancelled_xpath);

        }

        [Then(@"all the claims in the Open status should be displayed by most recent date")]
        public void ThenAllTheClaimsInTheOpenStatusShouldBeDisplayedByMostRecentDate()
        {
            int row = GetCount(attributeName_xpath, ClaimsList_RowCount_xpath);
            if (row >= 1)
            {
                Report.WriteLine("Reading the values from the Insured Rate columns after ascdending sorting");
                IList<IWebElement> companyNameColCount = GlobalVariables.webDriver.FindElements(By.XPath(ClaimsList_SubmitDateAll_Values_Xpath));
                foreach (IWebElement element in companyNameColCount)
                {
                    ascSort.Add((element.Text).ToString());

                }


                Click(attributeName_xpath, ClaimsList_SubmitDateColClick_Xpath);
                Report.WriteLine("Reading the values from the Insured Rate columns after descending sorting");
                IList<IWebElement> sortedvalues = GlobalVariables.webDriver.FindElements(By.XPath(ClaimsList_SubmitDateAll_Values_Xpath));
                foreach (IWebElement element in sortedvalues)
                {
                    desSort.Add((element.Text).ToString());
                }
                desSort.Sort();
                Report.WriteLine("Comparing the values after sorting");
                ascSort.Sort();
                for (int i = 0; i < sortedvalues.Count; i++)
                {
                    if (ascSort[i] == desSort[i])
                    {
                        Report.WriteLine("Expected value :" + ascSort[i] + " is equal to the actual value: " + desSort[i]);
                    }
                    else
                    {
                        Report.WriteFailure("Sorting is not as expected");
                    }
                }
            }
            else
            {
                Report.WriteLine("No records for company Name column");
            }
        }


        [Then(@"Verify the color code (.*) of (.*) Open, Pending, Denied, Paid, Cancelled in the claims list page")]
        public void ThenVerifyTheColorCodeOfOpenPendingDeniedPaidCancelledInTheClaimsListPage(string Color, string status)
        {

            string noReocrdsCheck = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr/td");
            int Shipmentrowcount = GetCount(attributeName_xpath, ClaimsList_TotalRecords_Xpath);


            if (Shipmentrowcount >= 1 && noReocrdsCheck != "No Results Found")
            {

                if (status.Equals("Open"))
                {

                    IWebElement statusLabel = GlobalVariables.webDriver.FindElement(By.XPath(ClaimsListGrid_OpenStatusColor_xpath));
                    IJavaScriptExecutor executor = (IJavaScriptExecutor)GlobalVariables.webDriver;
                    var openStatusColor = executor.ExecuteScript("return window.getComputedStyle(arguments[0], ':before').getPropertyValue('background-color'); ", statusLabel).ToString();

                    Assert.AreEqual("rgb(79, 129, 189)", openStatusColor);
                    Report.WriteLine("Color matches with the code #4f81bd ");

                }
                else if (status.Equals("Pending"))
                {
                    Click(attributeName_xpath, ClaimsList_OpenCheckbox_xpath);
                    Click(attributeName_xpath, ClaimsList_PendingCheckbox_xpath);

                    IWebElement statusLabel = GlobalVariables.webDriver.FindElement(By.XPath(ClaimsListGrid_PendingStatusColor_xpath));
                    IJavaScriptExecutor executor = (IJavaScriptExecutor)GlobalVariables.webDriver;
                    var pendingStatusColor = executor.ExecuteScript("return window.getComputedStyle(arguments[0], ':before').getPropertyValue('background-color'); ", statusLabel).ToString();

                    Assert.AreEqual("rgb(103, 78, 167)", pendingStatusColor);
                    Report.WriteLine("Color matches with the code #674ea7 ");
                }
                else if (status.Equals("Paid"))
                {
                    Click(attributeName_xpath, ClaimsList_OpenCheckbox_xpath);
                    Click(attributeName_xpath, ClaimsList_PaidCheckbox_xpath);

                    IWebElement statusLabel = GlobalVariables.webDriver.FindElement(By.XPath(ClaimsListGrid_PaidStatusColor_xpath));
                    IJavaScriptExecutor executor = (IJavaScriptExecutor)GlobalVariables.webDriver;
                    var paidStatusColor = executor.ExecuteScript("return window.getComputedStyle(arguments[0], ':before').getPropertyValue('background-color'); ", statusLabel).ToString();

                    Assert.AreEqual("rgb(106, 168, 79)", paidStatusColor);
                    Report.WriteLine("Color matches with the code #6aa84f ");
                }
                else if (status.Equals("Denied"))
                {
                    Click(attributeName_xpath, ClaimsList_OpenCheckbox_xpath);
                    Click(attributeName_xpath, ClaimsList_DeniedCheckbox_xpath);

                    IWebElement statusLabel = GlobalVariables.webDriver.FindElement(By.XPath(ClaimsListGrid_DeniedStatusColor_xpath));
                    IJavaScriptExecutor executor = (IJavaScriptExecutor)GlobalVariables.webDriver;
                    var deniedStatusColor = executor.ExecuteScript("return window.getComputedStyle(arguments[0], ':before').getPropertyValue('background-color'); ", statusLabel).ToString();

                    Assert.AreEqual("rgb(166, 28, 0)", deniedStatusColor);
                    Report.WriteLine("Color matches with the code #a61c00 ");
                }
                else
                {
                    Click(attributeName_xpath, ClaimsList_OpenCheckbox_xpath);
                    Click(attributeName_xpath, ClaimsList_Cancelled_xpath);

                    IWebElement statusLabel = GlobalVariables.webDriver.FindElement(By.XPath(ClaimsListGrid_CancelledStatusColor_xpath));
                    IJavaScriptExecutor executor = (IJavaScriptExecutor)GlobalVariables.webDriver;
                    var cancelledStatusColor = executor.ExecuteScript("return window.getComputedStyle(arguments[0], ':before').getPropertyValue('background-color'); ", statusLabel).ToString();

                    Assert.AreEqual("rgb(246, 178, 107)", cancelledStatusColor);
                    Report.WriteLine("Color matches with the code #f6b26b ");
                }
            }
            else
            {
                Report.WriteLine("No records found");
            }
        }


        [Given(@"I am a shp\.inquiry, shp\.inquirynorates, shp\.entry, or shp\.entrynorates user")]
        public void GivenIAmAShp_InquiryShp_InquirynoratesShp_EntryOrShp_EntrynoratesUser()
        {
            string username = ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();
            string password = ConfigurationManager.AppSettings["ExternalUserPassword"].ToString();
            CrmLogin.LoginToCRMApplication(username, password);

        }

        [Then(@"I should see a list of claims for the customer to which user is associated")]
        public void ThenIShouldSeeAListOfClaimsForTheCustomerToWhichUserIsAssociated()
        {

            Report.WriteLine("User should see Dashboard icon in the left navigation menu of Landing Page");
            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);

            string setupID = IDP.GetClaimValue("zzzext", "dlscrm-CustomerSetUpId");
            int custSetupId = Convert.ToInt32(setupID);



            List<int> DBClaimNum = DBHelper.Get_AssociatedClaimNumber(custSetupId);

            Click(attributeName_xpath, ClaimsList_DeniedCheckbox_xpath);
            Click(attributeName_xpath, ClaimsList_PendingCheckbox_xpath);
            Click(attributeName_xpath, ClaimsList_PaidCheckbox_xpath);
            Click(attributeName_xpath, ClaimsList_Cancelled_xpath);
            Click(attributeName_xpath, ClaimsList_TopGrid_ViewDropdown_Xpath);
            SelectDropdownlistvalue(attributeName_xpath, ClaimsList_TopGrid_ViewDropdownValues_Xpath, "ALL");

            string noReocrdsCheck = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr/td");

            int Shipmentrowcount = GetCount(attributeName_xpath, ClaimsList_TotalRecords_Xpath);
            if (Shipmentrowcount >= 1 && noReocrdsCheck != "No Results Found")
            {

                Click(attributeName_xpath, ClaimsList_DLSWClaimNumberColClick_Xpath);
                Report.WriteLine("Reading the values from the Insured Rate columns after ascdending sorting");
                IList<IWebElement> customerRefNumberColCount = GlobalVariables.webDriver.FindElements(By.XPath(DLSWClaimNumberALLValUI_xpath));
                foreach (IWebElement element in customerRefNumberColCount)
                {
                    ascSort.Add(element.Text);

                }
            }
            else
            {
                Report.WriteLine("No Records found");
            }

            string DBCount = DBClaimNum.Count.ToString();
            string UICount = ascSort.Count.ToString();
            Assert.AreEqual(DBCount, UICount);



            for (int i = 0; i < DBClaimNum.Count; i++)
            {
                if (ascSort[i] == DBClaimNum[i].ToString())
                {
                    Report.WriteLine("Expected value :" + ascSort[i] + " is equal to the actual value: " + DBClaimNum[i]);
                }
                else
                {
                    Report.WriteFailure("Sorting is not as expected");
                }
            }


        }

        [Given(@"I am a sales user")]
        public void GivenIAmASalesUser()
        {
            string username = ConfigurationManager.AppSettings["username-NewScreenSalesUser"].ToString();
            string password = ConfigurationManager.AppSettings["password-NewScreenSalesUser"].ToString();
            CrmLogin.LoginToCRMApplication(username, password);
        }


        [Then(@"I should see a list of claims for the customer\(s\) to which user is associated")]
        public void ThenIShouldSeeAListOfClaimsForTheCustomerSToWhichUserIsAssociated()
        {
            Report.WriteLine("User should see Dashboard icon in the left navigation menu of Landing Page");
            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);


            List<AppUserClaimInfo> claimValue = new List<AppUserClaimInfo>();
            List<AppUserClaimInfo> claimDetails = IDP.GetUserClaimDetails("salesDelta");
            claimValue = claimDetails.Where(x => x.ClaimType == "dlscrm-CustomerSetUpId").Select(x => new AppUserClaimInfo
            {
                ClaimValue = x.ClaimValue,

            }).ToList();
            List<int> custSetupId = claimValue.Select(x => Convert.ToInt32(x.ClaimValue)).ToList();

            List<int> ClaimNumbers = DBHelper.GetClaimNumberforAssociatedCustomers(custSetupId);

            Click(attributeName_xpath, ClaimsList_DeniedCheckbox_xpath);
            Click(attributeName_xpath, ClaimsList_PendingCheckbox_xpath);
            Click(attributeName_xpath, ClaimsList_PaidCheckbox_xpath);
            Click(attributeName_xpath, ClaimsList_Cancelled_xpath);
            Click(attributeName_xpath, ClaimsList_TopGrid_ViewDropdown_Xpath);
            SelectDropdownlistvalue(attributeName_xpath, ClaimsList_TopGrid_ViewDropdownValues_Xpath, "ALL");


            string noReocrdsCheck = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr/td");

            int Shipmentrowcount = GetCount(attributeName_xpath, ClaimsList_TotalRecords_Xpath);
            if (Shipmentrowcount >= 1 && noReocrdsCheck != "No Results Found")
            {
                Click(attributeName_xpath, ClaimsList_DLSWClaimNumberColClick_Xpath);
                Report.WriteLine("Reading the values from the Insured Rate columns after ascdending sorting");
                IList<IWebElement> customerRefNumberColCount = GlobalVariables.webDriver.FindElements(By.XPath(DLSWClaimNumberALLValUI_xpath));

                foreach (IWebElement element in customerRefNumberColCount)
                {
                    ascSort.Add(element.Text);

                }
            }
            else
            {
                Report.WriteLine("No Records found");
            }

            // Assert.IsTrue(ascSort.OrderBy(c => c.Text).SequenceEqual(ClaimNumbers));

            string DBCount = ClaimNumbers.Count.ToString();
            string UICount = ascSort.Count.ToString();
            Assert.AreEqual(DBCount, UICount);

            for (int i = 0; i < ClaimNumbers.Count; i++)
            {
                if (ascSort[i] == ClaimNumbers[i].ToString())
                {
                    Report.WriteLine("Expected value :" + ascSort[i] + " is equal to the actual value: " + ClaimNumbers[i]);
                }
                else
                {
                    Report.WriteFailure("Sorting is not as expected");
                }
            }
        }


        [When(@"I uncheck all the display status options Paid, Open, Pending, Denied, Cancelled")]
        public void WhenIUncheckAllTheDisplayStatusOptionsPaidOpenPendingDeniedCancelled()
        {
            Click(attributeName_xpath, ClaimsList_OpenCheckbox_xpath);
            Click(attributeName_xpath, ClaimsList_TopGrid_ViewDropdown_Xpath);
            SelectDropdownlistvalue(attributeName_xpath, ClaimsList_TopGrid_ViewDropdownValues_Xpath, "ALL");



        }


        [Then(@"Grid should be updated to display all claims for the customer associated to the user")]
        public void ThenGridShouldBeUpdatedToDisplayAllClaimsForTheCustomerAssociatedToTheUser()
        {
            Report.WriteLine("User should see Dashboard icon in the left navigation menu of Landing Page");
            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);

            string setupID = IDP.GetClaimValue("zzzext", "dlscrm-CustomerSetUpId");
            int custSetupId = Convert.ToInt32(setupID);



            List<int> DBClaimNum = DBHelper.Get_AssociatedClaimNumber(custSetupId);


            string noReocrdsCheck = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr/td");

            int Shipmentrowcount = GetCount(attributeName_xpath, ClaimsList_TotalRecords_Xpath);
            if (Shipmentrowcount >= 1 && noReocrdsCheck != "No Results Found")
            {

                Click(attributeName_xpath, ClaimsList_DLSWClaimNumberColClick_Xpath);
                Report.WriteLine("Reading the values from the Insured Rate columns after ascdending sorting");
                IList<IWebElement> customerRefNumberColCount = GlobalVariables.webDriver.FindElements(By.XPath(DLSWClaimNumberALLValUI_xpath));
                foreach (IWebElement element in customerRefNumberColCount)
                {
                    ascSort.Add(element.Text);

                }
            }
            else
            {
                Report.WriteLine("No Records found");
            }

            string DBCount = DBClaimNum.Count.ToString();
            string UICount = ascSort.Count.ToString();
            Assert.AreEqual(DBCount, UICount);



            for (int i = 0; i < DBClaimNum.Count; i++)
            {
                if (ascSort[i] == DBClaimNum[i].ToString())
                {
                    Report.WriteLine("Expected value :" + ascSort[i] + " is equal to the actual value: " + DBClaimNum[i]);
                }
                else
                {
                    Report.WriteFailure("Sorting is not as expected");
                }
            }

        }


        [Then(@"Grid should be updated to display all claims for the customer\(s\) associated to the user")]
        public void ThenGridShouldBeUpdatedToDisplayAllClaimsForTheCustomerSAssociatedToTheUser()
        {
            Report.WriteLine("User should see Dashboard icon in the left navigation menu of Landing Page");
            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);


            List<AppUserClaimInfo> claimValue = new List<AppUserClaimInfo>();
            List<AppUserClaimInfo> claimDetails = IDP.GetUserClaimDetails("salesDelta");
            claimValue = claimDetails.Where(x => x.ClaimType == "dlscrm-CustomerSetUpId").Select(x => new AppUserClaimInfo
            {
                ClaimValue = x.ClaimValue,

            }).ToList();
            List<int> custSetupId = claimValue.Select(x => Convert.ToInt32(x.ClaimValue)).ToList();

            List<int> ClaimNumbers = DBHelper.GetClaimNumberforAssociatedCustomers(custSetupId);

            string noReocrdsCheck = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr/td");

            int Shipmentrowcount = GetCount(attributeName_xpath, ClaimsList_TotalRecords_Xpath);
            if (Shipmentrowcount >= 1 && noReocrdsCheck != "No Results Found")
            {
                Click(attributeName_xpath, ClaimsList_DLSWClaimNumberColClick_Xpath);
                Report.WriteLine("Reading the values from the Insured Rate columns after ascdending sorting");
                IList<IWebElement> customerRefNumberColCount = GlobalVariables.webDriver.FindElements(By.XPath(DLSWClaimNumberALLValUI_xpath));

                foreach (IWebElement element in customerRefNumberColCount)
                {
                    ascSort.Add(element.Text);

                }
            }
            else
            {
                Report.WriteLine("No Records found");
            }

            // Assert.IsTrue(ascSort.OrderBy(c => c.Text).SequenceEqual(ClaimNumbers));

            string DBCount = ClaimNumbers.Count.ToString();
            string UICount = ascSort.Count.ToString();
            Assert.AreEqual(DBCount, UICount);

            for (int i = 0; i < ClaimNumbers.Count; i++)
            {
                if (ascSort[i] == ClaimNumbers[i].ToString())
                {
                    Report.WriteLine("Expected value :" + ascSort[i] + " is equal to the actual value: " + ClaimNumbers[i]);
                }
                else
                {
                    Report.WriteFailure("Sorting is not as expected");
                }
            }
        }

        //----------Sprint 94 Scripts for 108304 - Insurance Claims - Claims List - No Carrier Selected----//

        [Given(@"I have claim\(s\) with (.*) for (.*)")]
        public void GivenIHaveClaimSWithFor(string carrierName, string user)
        {
            Click(attributeName_id, ClaimsIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            ///Claimnumber = CreateClaim.Claimsubmit(user);
            Click(attributeName_xpath, ClaimsList_SubmitDateColClick_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Claimnumber = Gettext(attributeName_xpath, ".//tr[1]//a[@class='DlswClaimNumber']");
            Thread.Sleep(1000);
            if (user == "claimspecialist")
            {
                SendKeys(attributeName_xpath, ClaimList_ClaimNumberSearchBox_Xpath, Claimnumber);
                Click(attributeName_xpath, ClaimList_Grid_ClaimNumbers);
                GlobalVariables.webDriver.WaitForPageLoad();
                scrollPageup();
                scrollPageup();
                GlobalVariables.webDriver.WaitForPageLoad();
                Click(attributeName_xpath, CarrierName_Dropdown_ClaimDetailsPage_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, CarrierName_DropdownValues_ClaimDetailsPage_Xpath, carrierName);
                Thread.Sleep(2000);
                Click(attributeName_id, Details_SubmitClaimDetails_Button_Id);
                Thread.Sleep(2000);
                scrollPageup();
                scrollPageup();
                Click(attributeName_id, BackToClaimsList_Button_ClaimDetails_Id);
                GlobalVariables.webDriver.WaitForPageLoad();
            }
            else
            {
                Click(attributeName_xpath, LoggedinUser_Xpath);
                GlobalVariables.webDriver.WaitForPageLoad();
                Click(attributeName_xpath, SignOut_Xpath);
                GlobalVariables.webDriver.WaitForPageLoad();
                string userName = ConfigurationManager.AppSettings["username-CurrentsprintClaimspecialist"].ToString();
                string password = ConfigurationManager.AppSettings["password-CurrentsprintClaimspecialist"].ToString();
                CrmLogin.LoginToCRMApplication(userName, password);
                SendKeys(attributeName_xpath, ClaimList_ClaimNumberSearchBox_Xpath, Claimnumber);
                Click(attributeName_xpath, ClaimList_Grid_ClaimNumbers);
                GlobalVariables.webDriver.WaitForPageLoad();
                scrollPageup();
                scrollPageup();
                GlobalVariables.webDriver.WaitForPageLoad();
                Click(attributeName_xpath, CarrierName_Dropdown_ClaimDetailsPage_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, CarrierName_DropdownValues_ClaimDetailsPage_Xpath, "Select...");
                Thread.Sleep(2000);
                Click(attributeName_id, Details_SubmitClaimDetails_Button_Id);
                Thread.Sleep(2000);
                scrollPageup();
                scrollPageup();
                Click(attributeName_id, BackToClaimsList_Button_ClaimDetails_Id);
                GlobalVariables.webDriver.WaitForPageLoad();
                Click(attributeName_xpath, LoggedinUser_Xpath);
                GlobalVariables.webDriver.WaitForPageLoad();
                Click(attributeName_xpath, SignOut_Xpath);
                GlobalVariables.webDriver.WaitForPageLoad();
            }
            if (user == "External")
            {
                string userName = ConfigurationManager.AppSettings["username-CurrentSprintshpentry"].ToString();
                string password = ConfigurationManager.AppSettings["password-CurrentSprintshpentry"].ToString();
                CrmLogin.LoginToCRMApplication(userName, password);
                GlobalVariables.webDriver.WaitForPageLoad();
                Click(attributeName_id, ClaimsIcon_Id);

            }
            else if (user == "Internal")
            {
                string userName = ConfigurationManager.AppSettings["username-CurrentSprintOperations"].ToString();
                string password = ConfigurationManager.AppSettings["password-CurrentSprintOperations"].ToString();
                CrmLogin.LoginToCRMApplication(userName, password);
                GlobalVariables.webDriver.WaitForPageLoad();
                Click(attributeName_id, ClaimsIcon_Id);

            }
            else if (user == "Sales")
            {
                string userName = ConfigurationManager.AppSettings["username-CurrentSprintSales"].ToString();
                string password = ConfigurationManager.AppSettings["password-CurrentSprintSales"].ToString();
                CrmLogin.LoginToCRMApplication(userName, password);
                GlobalVariables.webDriver.WaitForPageLoad();
                Click(attributeName_id, ClaimsIcon_Id);

            }
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [When(@"I arrive on claim list page")]
        public void WhenIArriveOnClaimListPage()
        {
            Verifytext(attributeName_xpath, ClaimsListPage_HeaderText_Xpath, "Claims List");
        }

        [Then(@"I will see Not Assigned as the carrier name in the Carrier column for those claims")]
        public void ThenIWillSeeNotAssignedAsTheCarrierNameInTheCarrierColumnForThoseClaims()
        {
            Click(attributeName_xpath, ClaimsList_SubmitDateColClick_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            string noReocrdsCheck = Gettext(attributeName_xpath, ClaimListGridValues_Xpath);
            int Shipmentrowcount = GetCount(attributeName_xpath, ClaimsList_TotalRecords_Xpath);
            if (Shipmentrowcount >= 1 && noReocrdsCheck != "No Results Found")
            {
                GlobalVariables.webDriver.WaitForPageLoad();
                CarrierNameValues = GlobalVariables.webDriver.FindElements(By.XPath(ClaimsList_CarrierNameColAll_Values_Xpath));
                foreach (IWebElement element in CarrierNameValues)
                {
                    carrierNameValuesUI.Add(element.Text.ToString());
                }
                ClaimNumbers = GlobalVariables.webDriver.FindElements(By.XPath(ClaimListDLSWREF_HyperLink_Xpath));

                foreach (IWebElement element in ClaimNumbers)
                {
                    ClaimNumbersUI.Add(element.Text.ToString());
                }
                for (int i = 0; i < carrierNameValuesUI.Count; i++)
                {
                    if (carrierNameValuesUI[i].Contains("Not Assigned"))
                    {
                        Report.WriteLine("Carrier name displayed as " + carrierNameValuesUI[i] + " for the Claim number " + ClaimNumbersUI[i]);
                    }
                    else
                    {
                        Report.WriteLine("Carrier name displayed as " + carrierNameValuesUI[i] + " for the Claim number " + ClaimNumbersUI[i]);
                    }

                }

            }
            else
            {
                Report.WriteFailure("No Claims available for the logged in user");
            }
        }

        [Then(@"I will not see Not Assigned as the carrier name in the Carrier column for those claims")]
        public void ThenIWillNotSeeNotAssignedAsTheCarrierNameInTheCarrierColumnForThoseClaims()
        {
            // SendKeys(attributeName_xpath, ClaimList_ClaimNumberSearchBox_Xpath, Claimnumber.ToString());
            Click(attributeName_xpath, ClaimsList_SubmitDateColClick_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            string noReocrdsCheck = Gettext(attributeName_xpath, ClaimListGridValues_Xpath);
            int Shipmentrowcount = GetCount(attributeName_xpath, ClaimsList_TotalRecords_Xpath);
            if (Shipmentrowcount >= 1 && noReocrdsCheck != "No Results Found")
            {
                GlobalVariables.webDriver.WaitForPageLoad();
                CarrierNameValues = GlobalVariables.webDriver.FindElements(By.XPath(ClaimsList_CarrierNameColAll_Values_Xpath));
                foreach (IWebElement element in CarrierNameValues)
                {
                    carrierNameValuesUI.Add(element.Text.ToString());
                }
                ClaimNumbers = GlobalVariables.webDriver.FindElements(By.XPath(ClaimListDLSWREF_HyperLink_Xpath));
                foreach (IWebElement element in ClaimNumbers)
                {
                    ClaimNumbersUI.Add(element.Text.ToString());
                }
                for (int i = 0; i < carrierNameValuesUI.Count; i++)
                {
                    if (carrierNameValuesUI[i].Contains("Not Assigned"))
                    {
                        Report.WriteLine("Carrier name displayed as " + carrierNameValuesUI[i] + " for the Claim number " + ClaimNumbersUI[i]);
                    }
                    else
                    {
                        Report.WriteLine("Carrier name displayed as " + carrierNameValuesUI[i] + " for the Claim number " + ClaimNumbersUI[i]);
                    }
                }
            }
            else
            {
                Report.WriteFailure("No Claims available for the logged in user");
            }
        }

        [Then(@"I will not be displayed with Select\.\.\. as the carrier name in the Carrier column for those claims")]
        public void ThenIWillNotBeDisplayedWithSelect_AsTheCarrierNameInTheCarrierColumnForThoseClaims()
        {
            for (int i = 0; i < carrierNameValuesUI.Count; i++)
            {
                if (carrierNameValuesUI[i].Contains("Select.."))
                {
                    Report.WriteFailure("Carrier name displayed as " + carrierNameValuesUI[i] + " for the Claim number " + ClaimNumbersUI[i]);
                }
                else
                {
                    Report.WriteLine("Carrier name displayed as " + carrierNameValuesUI[i] + " for the Claim number " + ClaimNumbersUI[i]);
                }
            }

        }
    }
}
