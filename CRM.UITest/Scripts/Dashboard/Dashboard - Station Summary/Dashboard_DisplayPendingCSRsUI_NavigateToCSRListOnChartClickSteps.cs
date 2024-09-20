using CRM.UITest.Objects;
using TechTalk.SpecFlow;
using CRM.UITest.Entities;
using Rrd.ServiceAccessLayer;
using System.Collections.Generic;
using CRM.UITest.Entities.Proxy;
using Rrd.Dls.IdentityServer.Core.Dto;
using System.Linq;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using OpenQA.Selenium;
using CRM.UITest.CommonMethods;
using System.Configuration;

namespace CRM.UITest.Scripts.Dashboard
{
	[Binding]
	public class Dashboard_DisplayPendingCSRsUI_NavigateToCSRListOnChartClickSteps : ObjectRepository
	{
		int totalCount = 0;
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();

        [Given(@"I am sales user")]
        public void GivenIAmSalesUser()
        {
            string username = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
            string password = ConfigurationManager.AppSettings["password-crmOperation"].ToString();
            CrmLogin.LoginToCRMApplication(username, password);
        }


        [When(@"I arrive on the Dashboard landing page")]
		public void WhenIArriveOnTheDashboardLandingPage()
		{
			Report.WriteLine("Verifying the dashboard screen");
			Verifytext(attributeName_xpath, NewDashboard_Header_Text_Xpath, "Dashboard");
		}

		[Then(@"I will see a Pending CSR section")]
		public void ThenIWillSeeAPendingCSRSection()
		{
			Report.WriteLine("Verifying the Pending CSR section present in dashboard");
			Verifytext(attributeName_xpath, PendingCSR_Header_Xpath, "PENDING CSRs");
			//Click(attributeName_xpath, PendingCSR_Header_Xpath);
		}

		[Then(@"Pending CSR section will display a chart of the CSR statuses of all open CSR’s for which (.*) Station Owner, Operations, Sales and Sales Management Users is assosiated")]
		public int ThenPendingCSRSectionWillDisplayAChartOfTheCSRStatusesOfAllOpenCSRSForWhichStationOwnerOperationsSalesAndSalesManagementUsersIsAssosiated(string Username)
		{
			IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);
			List<AppUserClaimInfo> AllClaimDetails = IDP.GetUserClaimDetails(ConfigurationManager.AppSettings["username-crmOperation"].ToString());
			List<string> setClaimDetails = AllClaimDetails.Where(c => c.ClaimType == "dlscrm-StationId").Select(a => a.ClaimValue).ToList();
			List<int> setupid = DBHelper.GetAccountsMappedforStations(setClaimDetails);

			List<int> listStatusId = new List<int>();
			listStatusId.Add(1); listStatusId.Add(2); listStatusId.Add(3); listStatusId.Add(5); listStatusId.Add(11); listStatusId.Add(13);

			List<CsrSetup> value = DBHelper.GetCSRList_NonadminInternalUser(setupid, listStatusId);
			totalCount = value.Count;
			return totalCount;
		}

		[Then(@"Total assosiated CSR's count will be displayed in the center of the chart")]
		public void ThenTotalAssosiatedCSRSCountWillBeDisplayedInTheCenterOfTheChart()
		{
			Report.WriteLine("Comparing the UI CSR count with database count");
			string ActualCount = Gettext(attributeName_xpath, Chart_TotalCount_Xpath);
			Assert.AreEqual(totalCount.ToString(), ActualCount);

		}

		[Then(@"Pending CSR section will display a chart of the CSR statuses of all open CSR’s for which system configuration user is assosiated")]
		public int ThenPendingCSRSectionWillDisplayAChartOfTheCSRStatusesOfAllOpenCSRSForWhichSystemConfigurationUserIsAssosiated()
		{
			Report.WriteLine("Getting total CSR count for the logged in system config user");
			List<int> listStatusId = new List<int>();
			listStatusId.Add(11); listStatusId.Add(2); listStatusId.Add(3); listStatusId.Add(5); listStatusId.Add(13);

			List<CsrSetup> value = DBHelper.GetCSRListForStatusIds(listStatusId);
			return totalCount = value.Count;
		}

		[Then(@"Pending CSR section will display a chart of the CSR statuses of all open CSR’s for which pricing configuration user is assosiated")]
		public int ThenPendingCSRSectionWillDisplayAChartOfTheCSRStatusesOfAllOpenCSRSForWhichPricingConfigurationUserIsAssosiated()
		{
			Report.WriteLine("Getting total CSR count for the logged in pricing config user");
			List<int> listStatusId = new List<int>();
			listStatusId.Add(13); listStatusId.Add(3);

			List<CsrSetup> value = DBHelper.GetCSRListForStatusIds(listStatusId);
			return totalCount = value.Count;
		}

		[Then(@"Pending CSR section will display a chart of the CSR statuses of all open CSR’s for which system admin user is assosiated")]
		public int ThenPendingCSRSectionWillDisplayAChartOfTheCSRStatusesOfAllOpenCSRSForWhichSystemAdminUserIsAssosiated()
		{
			Report.WriteLine("Getting total CSR count for the logged in system admin user");
			List<int> listStatusId = new List<int>();
			listStatusId.Add(11); listStatusId.Add(2); listStatusId.Add(3); listStatusId.Add(5); listStatusId.Add(1); listStatusId.Add(13);

			List<CsrSetup> value = DBHelper.GetCSRListForStatusIds(listStatusId);
			return totalCount = value.Count;
		}

		[Then(@"I hover over a CSR status on the chart for the (.*)")]
		public int ThenIHoverOverACSRStatusOnTheChartForThe(string status)
		{
			Report.WriteLine("Mouse over on the status " + status);
			List<int> listStatusId = new List<int>();

			if (status == "Pending Regional Manager Approval")
			{
				OnMouseOver(attributeName_id, Chart_PendingRMApproval_Id);
				listStatusId.Add(1);
				totalCount = DBHelper.GetCSRListForStatusIds(listStatusId).Count;
			}
			else if (status == "Waiting to Process")
			{
				OnMouseOver(attributeName_cssselector, Chart_WaitingToProcess_Xpath);
				listStatusId.Add(11);
				totalCount = DBHelper.GetCSRListForStatusIds(listStatusId).Count;
			}
			else if (status == "In Progress")
			{
				OnMouseOver(attributeName_id, Chart_InProgress_Id);
				listStatusId.Add(13);
				totalCount = DBHelper.GetCSRListForStatusIds(listStatusId).Count;
			}
			else if (status == "Pending System Configuration")
			{
				OnMouseOver(attributeName_id, Chart_PendingSysConfig_Id);
				listStatusId.Add(2);
				totalCount = DBHelper.GetCSRListForStatusIds(listStatusId).Count;
			}
			else if (status == "Pending Pricing Configuration")
			{
				OnMouseOver(attributeName_id, Chart_PendingPriConfig_Id);
				listStatusId.Add(3);
				totalCount = DBHelper.GetCSRListForStatusIds(listStatusId).Count;
			}
			else if (status == "Denied")
			{
				OnMouseOver(attributeName_id, Chart_Denied_Id);
				listStatusId.Add(5);
				totalCount = DBHelper.GetCSRListForStatusIds(listStatusId).Count;
			}
			else
			{
				Report.WriteLine("Passed Status is not matching");
				Assert.IsTrue(false);
			}
			return totalCount;
		}

		[Then(@"the corresponding portion of data within the chart will be enlarged slightly to illustrate the connection and the data displayed in the center will reflect the number of CSR's for the corresponding CSR status")]
		public void ThenTheCorrespondingPortionOfDataWithinTheChartWillBeEnlargedSlightlyToIllustrateTheConnectionAndTheDataDisplayedInTheCenterWillReflectTheNumberOfCSRSForTheCorrespondingCSRStatus()
		{
			Report.WriteLine("Comparing the UI CSR count with database count");
			string ActualCount = Gettext(attributeName_xpath, Chart_TotalCount_Xpath);
			Assert.AreEqual(totalCount.ToString(), ActualCount);

		}

		[When(@"I click on Pending regional manager status from the chart")]
		public int WhenIClickOnPendingRegionalManagerStatusFromTheChart()
		{
			OnMouseOver(attributeName_id, Chart_PendingRMApproval_Id);
			string ActualCount = Gettext(attributeName_xpath, Chart_TotalCount_Xpath);
			totalCount = Convert.ToInt32(ActualCount);
			Report.WriteLine("Click on CSR with Pending Regional Manager status");
			IJavaScriptExecutor executor = (IJavaScriptExecutor)GlobalVariables.webDriver;
			executor.ExecuteScript("$('#pending_regional_manager_approval').click();");
			return totalCount;
		}

		[Then(@"I will navigate to CSR list")]
		public void ThenIWillNavigateToCSRList()
		{
			Report.WriteLine("Verifying CSR list page header");
			Verifytext(attributeName_xpath, CSRlistHeader_Xpath, "CSR List");
		}

		[Then(@"CSR’s of the selected status (.*) will be displayed and count should match from dashboard")]
		public void ThenCSRSOfTheSelectedStatusWillBeDisplayedAndCountShouldMatchFromDashboard(string status)
		{
			Click(attributeName_xpath, CSRlist_ViewDropdown_Xpath);
			SelectDropdownValueFromList(attributeName_xpath, CSRlist_ViewDropdownOptions_Xpath, "All");
			List<string> statusValue = IndividualColumnData("//div[@id='csr-list-tbl']/table/tbody/tr");
			Assert.AreEqual(statusValue.Count.ToString(), totalCount.ToString());

			for (int i = 1; i <= statusValue.Count; i++)
			{
				string value = Gettext(attributeName_xpath, "//div[@id='csr-list-tbl']/table/tbody/tr[" + i + "]/td[3]");
				if (value.Equals(status))
				{
					Report.WriteLine("Displaying" + status + "is matching with UI status" + value);
				}
				else
				{
					Report.WriteLine("Displaying" + status + " is not matching with UI status" + value);
					Assert.IsTrue(false);
				}
			}
		}

		[When(@"I click on In Progress status from the chart")]
		public int WhenIClickOnInProgressStatusFromTheChart()
		{
			OnMouseOver(attributeName_id, Chart_InProgress_Id);
			string ActualCount = Gettext(attributeName_xpath, Chart_TotalCount_Xpath);
			totalCount = Convert.ToInt32(ActualCount);
			Report.WriteLine("Click on chart for CSR's with In Progress status");
			IJavaScriptExecutor executor = (IJavaScriptExecutor)GlobalVariables.webDriver;
			executor.ExecuteScript("$('#in_progress').click();");
			return totalCount;
		}

		[When(@"I click on Denied status from the chart")]
		public int WhenIClickOnDeniedStatusFromTheChart()
		{
			OnMouseOver(attributeName_id, Chart_Denied_Id);
			string ActualCount = Gettext(attributeName_xpath, Chart_TotalCount_Xpath);
			totalCount = Convert.ToInt32(ActualCount);
			Report.WriteLine("Click on chart for CSR's with Denied status");
			IJavaScriptExecutor executor = (IJavaScriptExecutor)GlobalVariables.webDriver;
			executor.ExecuteScript("$('#denied').click();");
			return totalCount;
		}

		[When(@"I click on Waiting to Process status from the chart")]
		public int WhenIClickOnWaitingToProcessStatusFromTheChart()
		{
			VerifyElementEnabled(attributeName_xpath, Chart_WaitingToProcess_Xpath, "waiting to process");
			OnMouseOver(attributeName_xpath, Chart_WaitingToProcess_Xpath);
			string ActualCount = Gettext(attributeName_xpath, Chart_TotalCount_Xpath);
			totalCount = Convert.ToInt32(ActualCount);
			Report.WriteLine("Click on chart for CSR's with wiating to process status");
			Click(attributeName_xpath, Chart_TotalCount_Xpath);

			IJavaScriptExecutor executor = (IJavaScriptExecutor)GlobalVariables.webDriver;
			executor.ExecuteScript("$('#waiting_to_process').click();");

			return totalCount;
		}

		[When(@"I click on Pending System Configuration status from the chart")]
		public int WhenIClickOnPendingSystemConfigurationStatusFromTheChart()
		{
			OnMouseOver(attributeName_id, Chart_PendingSysConfig_Id);
			string ActualCount = Gettext(attributeName_xpath, Chart_TotalCount_Xpath);
			totalCount = Convert.ToInt32(ActualCount);
			Report.WriteLine("Click on chart for CSR's with pending system configuration status");
			IJavaScriptExecutor executor = (IJavaScriptExecutor)GlobalVariables.webDriver;
			executor.ExecuteScript("$('#pending_system_configuration').click();");
			return totalCount;
		}

		[When(@"I click on Pending Pricing Configuration status from the chart")]
		public int WhenIClickOnPendingPricingConfigurationStatusFromTheChart()
		{
			OnMouseOver(attributeName_id, Chart_PendingPriConfig_Id);
			string ActualCount = Gettext(attributeName_xpath, Chart_TotalCount_Xpath);
			totalCount = Convert.ToInt32(ActualCount);
			Report.WriteLine("Click on chart for CSR's with pending pricing configuration status");
			IJavaScriptExecutor executor = (IJavaScriptExecutor)GlobalVariables.webDriver;
			executor.ExecuteScript("$('#pending_pricing_configuration').click();");
			return totalCount;
		}

		[Then(@"zero will be displayed in the center of the chart")]
		public void ThenZeroWillBeDisplayedInTheCenterOfTheChart()
		{
			string ActualCount = Gettext(attributeName_xpath, Chart_TotalCount_Xpath);
			Assert.AreEqual(ActualCount, "0");

		}

		[Then(@"pie circle will display in gray color")]
		public void ThenPieCircleWillDisplayInGrayColor()
		{
			string color = GetCSSValue(attributeName_id, Chart_NoCsr_Id, "fill");
			Assert.AreEqual(color, "rgb(128, 128, 128)");

		}

	}
}
