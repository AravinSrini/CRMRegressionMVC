using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.Dls.IdentityServer.Core.Dto;
using Rrd.ServiceAccessLayer;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Maintenance_Tools.Customer_Specific_Branding
{
	[Binding]
	public sealed class CRMCustomerSpecficBrandingConfiguration_Desktop : ObjectRepository
	{

		private string stationName = string.Empty;
		private string customerAccount = string.Empty;
		private string imageName = null;

		[When(@"I click on the Maintenance Tools Menu available in the Landing Page navigate to Maintenance Tools landing page if '(.*)' have claim")]
		public void WhenIClickOnTheMaintenanceToolsMenuAvailableInTheLandingPageNavigateToMaintenanceToolsLandingPageIfHaveClaim(string Username)
		{
			Report.WriteLine("User should see Maintenance Tools icon in the left navigation menu of Landing Page");
			IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);

			var MaintenanceToolsClaim_MaintenanceToolsView = IDP.VerifyIfUserHasClaim(Username, "dlscrm-role", "MaintenanceToolsView");

			if (MaintenanceToolsClaim_MaintenanceToolsView == true)
			{
				VerifyElementPresent(attributeName_cssselector, MaintenanceToolIcon_css, "Maintenance Tools");
				Report.WriteLine("Maintenance Tools icon is present with proper claims");

				Report.WriteLine("Click on the Maintenance Tools Menu available in the Landing Page");
				Click(attributeName_cssselector, MaintenanceToolIcon_css);

				Report.WriteLine("User should navigate to the Maintenance Tools module");
				WaitForElementVisible(attributeName_id, CustomerBrandingButton_id, "Customer Specific\r\nBranding");
				Verifytext(attributeName_cssselector, MaintenanceToolsgpageTitle_css, "Maintenance Tools");
			}
			else
			{
				VerifyElementNotPresent(attributeName_cssselector, MaintenanceToolIcon_css, "Maintenance Tools");
			}
		}

		[Then(@"I will have the option '(.*)' to configure Customer Specific Branding")]
		public void ThenIWillHaveTheOptionToConfigureCustomerSpecificBranding(string CustomerSpecificBranding)
		{
			Report.WriteLine("I will have the option configure Customer Specific Branding");
			Verifytext(attributeName_id, CustomerBrandingButton_id, "Customer Specific\r\nBranding");
		}

		[Then(@"I will have the '(.*)' for the Customer Specific Branding option")]
		public void ThenIWillHaveTheForTheCustomerSpecificBrandingOption(string description)
		{
			Report.WriteLine("I will have the description for the option configure Customer Specific Branding");
			Verifytext(attributeName_xpath, CustomerBrandingButtonDescription_xpath, description);
		}

		[Then(@"I am able to click CustomerSpecificBranding button and able to navigate to the Customer Specific Branding page when '(.*)' have the required claim")]
		public void ThenIAmAbleToClickCustomerSpecificBrandingButtonAndAbleToNavigateToTheCustomerSpecificBrandingPageWhenHaveTheRequiredClaim(string Username)
		{
			Report.WriteLine("I am verifying the required claim to configure Customer Specific Branding");

			IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);

			var CustomerBrandingClaim_MvcMaintainceCustomerBranding = IDP.VerifyIfUserHasClaim(Username, "dlscrm-role", "MvcMaintainceCustomerBranding");

            if (CustomerBrandingClaim_MvcMaintainceCustomerBranding == true)
            {
                Report.WriteLine("I should see the Customer Specific Branding button in enabled state");
                var CustomerSpecificBrandingButtonstate = IsElementEnabled(attributeName_id, CustomerBrandingButton_id, "CustomerSpecificBranding");
                Assert.IsTrue(IsElementEnabled(attributeName_id, CustomerBrandingButton_id, "Customer Specific Branding"));

				Report.WriteLine("I click on the option CustomerSpecificBranding to configure Customer Specific Branding");
				Click(attributeName_id, CustomerBrandingButton_id);

				Report.WriteLine("I should navigate to the Customer Specific Branding page");
				Verifytext(attributeName_cssselector, CustBrandingpageTitle_css, "Customer Specific Branding");
			}

            else
            {
                Assert.IsFalse(IsElementEnabled(attributeName_id, CustomerBrandingButton_id, "Customer Specific Branding"));
            }
        }

		[When(@"I am able to click CustomerSpecificBranding button and able to navigate to the Customer Specific Branding page when '(.*)' have the required claim")]
		public void WhenIAmAbleToClickCustomerSpecificBrandingButtonAndAbleToNavigateToTheCustomerSpecificBrandingPageWhenHaveTheRequiredClaim(string Username)
		{
			Report.WriteLine("I am verifying the required claim to configure Customer Specific Branding");

			IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);

			var CustomerBrandingClaim_MvcMaintainceCustomerBranding = IDP.VerifyIfUserHasClaim(Username, "dlscrm-role", "MvcMaintainceCustomerBranding");

			if (CustomerBrandingClaim_MvcMaintainceCustomerBranding == true)
			{
				Report.WriteLine("I should see the Customer Specific Branding button in enabled state");
				var CustomerSpecificBrandingButtonstate = IsElementEnabled(attributeName_id, CustomerBrandingButton_id, "CustomerSpecificBranding");
				Assert.IsTrue(IsElementEnabled(attributeName_id, CustomerBrandingButton_id, "Customer Specific Branding"));

				Report.WriteLine("I click on the option CustomerSpecificBranding to configure Customer Specific Branding");
				Click(attributeName_id, CustomerBrandingButton_id);
				WaitForElementVisible(attributeName_id, SaveBtn_id, "Save");

				Report.WriteLine("I should navigate to the Customer Specific Branding page");
				Verifytext(attributeName_cssselector, CustBrandingpageTitle_css, "Customer Specific Branding");
				Verifytext(attributeName_xpath, CustBrandingpageSubTitle_xpath, "Add a customer logo to replace the DLS logo for a specific customer.");
			}

			else
			{
				Assert.IsFalse(IsElementEnabled(attributeName_id, CustomerBrandingButton_id, "Customer Specific Branding"));
			}
		}

		[Then(@"I should see an option to go back to the Maintenance Tool Screen with the default text as '(.*)'")]
		public void ThenIShouldSeeAnOptionToGoBackToTheMaintenanceToolScreenWithTheDefaultTextAs(string backtoMaintenanceTool)
		{
			Report.WriteLine("I should see an option to go back to the Maintenance Tool Screen");
			Verifytext(attributeName_id, BacktoMaintenanceBtn_id, backtoMaintenanceTool);
		}

		[Then(@"I should see an option to select a station with lable '(.*)' and '(.*)' as default text")]
		public void ThenIShouldSeeAnOptionToSelectAStationWithLableAndAsDefaultText(string StationLbl, string Selectstation)
		{
			Report.WriteLine("I should see an option to select a station with lable and default text");
			Verifytext(attributeName_xpath, StationLbl_xpath, StationLbl);
			Verifytext(attributeName_linktext, Selectstation_link, Selectstation);
		}

		[Then(@"I should see an option to select a customer account based on the station that was selected with lable '(.*)' and with the default text as '(.*)'")]
		public void ThenIShouldSeeAnOptionToSelectACustomerAccountBasedOnTheStationThatWasSelectedWithLableAndWithTheDefaultTextAs(string CustomerLbl, string Selectcustomer)
		{
			Report.WriteLine("I should see an option to select a customer with lable and default text");
			Verifytext(attributeName_xpath, CustomerLbl_xpath, CustomerLbl);
			Verifytext(attributeName_linktext, Selectcustomer_link, Selectcustomer);
		}

		[Then(@"I should see an option to upload a custom logo and with the lable '(.*)', default text to '(.*)' and '(.*)'")]
		public void ThenIShouldSeeAnOptionToUploadACustomLogoAndWithTheLableDefaultTextToAnd(string AddLogoFileLbl, string browse, string Filesizeinfo)
		{
			Report.WriteLine("I should see an option to upload a custom logo with lable and default text and file size information");
			string logo = Gettext(attributeName_xpath, AddLogoFileLbl_xpath);
			Verifytext(attributeName_xpath, AddLogoFileLbl_xpath, AddLogoFileLbl);
			Verifytext(attributeName_xpath, browse_xpath, browse);
			Verifytext(attributeName_id, customerlogodropzone_id, "Drag file here or browse to a file to upload");
			string file = Gettext(attributeName_xpath, Filesizeinfo_xpath);
			Verifytext(attributeName_xpath, Filesizeinfo_xpath, file);
		}

		[Then(@"I should see an option to Save the uploaded file with the default text as '(.*)'")]
		public void ThenIShouldSeeAnOptionToSaveTheUploadedFileWithTheDefaultTextAs(string Save)
		{
			Report.WriteLine("I should see an option to Save the uploaded file");
			Verifytext(attributeName_id, SaveBtn_id, Save);
		}

		[Then(@"I should see list of existing Customer Specific Logos with lable '(.*)', Pagination header view '(.*)', '(.*)', '(.*)', '(.*)'")]
		public void ThenIShouldSeeListOfExistingCustomerSpecificLogosWithLablePaginationHeaderView(string CustomerSpecificLogosLbl, string View, string StationDD, string CustomernameDD, string LogoFile)
		{
			Report.WriteLine("I should see list of existing Customer Specific Logos with lable and Grid");
			Verifytext(attributeName_xpath, CustomerSpecificLogosLbl_xpath, CustomerSpecificLogosLbl);
			VerifyElementPresent(attributeName_xpath, View_xpath, View);
			Verifytext(attributeName_xpath, StationDD_xpath, StationDD);
			Verifytext(attributeName_xpath, CustomernameDD_xpath, CustomernameDD);
			Verifytext(attributeName_xpath, LogoFile_xpath, LogoFile);
			VerifyElementPresent(attributeName_xpath, ToggleBtn_xpath, "ToggleBtn");
			VerifyElementPresent(attributeName_xpath, DeleteBtn_xpath, "DeleteBtn");
		}

		[When(@"I click on the station drop down and select one station from drop down list")]
		public void WhenIClickOnTheStationDropDownAndSelectOneStationFromDropDownList()
		{
			Report.WriteLine("I click on the station drop down and select one station from drop down list");
			Click(attributeName_id, BrandingStationdropdown_id);
			List<string> ListofStationsinCustomerBranding_UI = GetDropdownValues(attributeName_id, BrandingStationdropdown_id, TagNameforStation_Dropdownoptions);
			ListofStationsinCustomerBranding_UI.Remove("Select station...");

			List<string> ListofStationsinCustomerBranding_DB = DBHelper.GetAllStationList().Select(x => x.StationName).ToList();
			stationName = ListofStationsinCustomerBranding_DB.FirstOrDefault();

			if (ListofStationsinCustomerBranding_UI.Count == ListofStationsinCustomerBranding_DB.Count)
			{
				Report.WriteLine("Station drop down list is same in UI and DB");
				SendKeys(attributeName_xpath, SelectStationSearchbox_xpath, stationName);
				Click(attributeName_xpath, StationNameOption_xpath);
			}
		}

		[When(@"I click on the station drop down and select the '(.*)' from the drop down list")]
		public void WhenIClickOnTheStationDropDownAndSelectTheFromTheDropDownList(string station)
		{
			stationName = station;
			Report.WriteLine("I click on the station drop down and select one station from drop down list");
			Click(attributeName_id, BrandingStationdropdown_id);
			IList<IWebElement> stationNameList = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='station_id_chosen']/div/ul/li"));
			int stationNameCount = stationNameList.Count;
			for (int i = 0; i < stationNameCount; i++)
			{
				if (stationNameList[i].Text == station)
				{
					stationNameList[i].Click();
					break;
				}
			}
		}

		[When(@"I click on the customer drop down and select the '(.*)' from the drop down list")]
		public void WhenIClickOnTheCustomerDropDownAndSelectTheFromTheDropDownList(string customeraccount)
		{
			customerAccount = customeraccount;
			Report.WriteLine("I click on the customer account drop down and select one customer account from drop down list");
			Click(attributeName_id, BrandingCustomerropdown_id);
			IList<IWebElement> customerAccountList = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='customer_id_chosen']/div/ul/li"));
			int customerAccountCount = customerAccountList.Count;
			for (int i = 0; i < customerAccountCount; i++)
			{
				if (customerAccountList[i].Text == customeraccount)
				{
					customerAccountList[i].Click();
					break;
				}
			}
		}

		[When(@"I delete the customer account if present in the customer specific logos grid")]
		public void WhenIDeleteTheCustomerAccountIfPresentInTheCustomerSpecificLogosGrid()
		{
			Report.WriteLine("I delete the customer account if present in the customer specific logos grid");
			SelectDropdownlistvalue(attributeName_id, BrandingGridViewDD_id, "All");

			List<string> rowdata = IndividualColumnData(".//*[@id='dt_CustomerLogoGrid']/tbody/tr");
			for (int i = 1; i <= rowdata.Count; i++)
			{
				string CustNameValue = Gettext(attributeName_xpath, ".//*[@id='dt_CustomerLogoGrid']/tbody/tr[" + i + "]/td[2]");
				if (CustNameValue == customerAccount)
				{
					Report.WriteLine("Customer account is present in the grid");
					Click(attributeName_xpath, ".//*[@id='dt_CustomerLogoGrid']/tbody/tr[" + i + "]/td[4]/button");
					WaitForElementVisible(attributeName_xpath, deleteConfirm_YesBtn_xpath, "Delete Confirm Button");
					Click(attributeName_xpath, deleteConfirm_YesBtn_xpath);
					Thread.Sleep(3000);

					Click(attributeName_id, BrandingStationdropdown_id);
					SendKeys(attributeName_xpath, SelectStationSearchbox_xpath, stationName);
					Click(attributeName_xpath, StationNameOption_xpath);
					Click(attributeName_id, BrandingCustomerropdown_id);
					SelectDropdownValueFromList(attributeName_id, BrandingCustomerropdown_id, customerAccount);
					break;
				}
			}
		}

		[Then(@"Delete the uploaded logo by click on the delete button in the Customer Specific Logo section")]
		public void ThenDeleteTheUploadedLogoByClickOnTheDeleteButtonInTheCustomerSpecificLogoSection()
		{
			Report.WriteLine("I Delete the uploaded logo by click on the delete button in the Customer Specific Logo section");
			SelectDropdownlistvalue(attributeName_id, BrandingGridViewDD_id, "All");

			List<string> rowdata = IndividualColumnData(".//*[@id='dt_CustomerLogoGrid']/tbody/tr");
			for (int i = 1; i <= rowdata.Count; i++)
			{
				string CustNameValue = Gettext(attributeName_xpath, ".//*[@id='dt_CustomerLogoGrid']/tbody/tr[" + i + "]/td[2]");
				if (CustNameValue == customerAccount)
				{
					Report.WriteLine("Customer account is present in the grid");
					Click(attributeName_xpath, ".//*[@id='dt_CustomerLogoGrid']/tbody/tr[" + i + "]/td[4]/button");
					WaitForElementVisible(attributeName_xpath, deleteConfirm_YesBtn_xpath, "Yes Button");
					Click(attributeName_xpath, deleteConfirm_YesBtn_xpath);
					Thread.Sleep(3000);
					break;
				}
			}
		}

		[Then(@"Verify the uploaded '(.*)' must not be present in the grid")]
		public void ThenVerifyTheUploadedMustNotBePresentInTheGrid(string Filename)
		{
			Report.WriteLine("Verify the customer account has already uploaded logo");
			SelectDropdownlistvalue(attributeName_id, BrandingGridViewDD_id, "All");

            List<string> rowdata = IndividualColumnData(".//*[@id='dt_CustomerLogoGrid']/tbody/tr");
            for (int i = 1; i <= rowdata.Count; i++)
            {
                string CustNameValue = Gettext(attributeName_xpath, ".//*[@id='dt_CustomerLogoGrid']/tbody/tr[" + i + "]/td[2]");
                if (CustNameValue == customerAccount)
                {
                    string LogofileName_UI = Gettext(attributeName_xpath, ".//*[@id='dt_CustomerLogoGrid']/tbody/tr[" + i + "]/td[3]");
                    string[] LogoName_Splitted = LogofileName_UI.Split('_');
                    string Filename_Actual = LogoName_Splitted[1].Trim();
                    if (Filename_Actual == Filename)
                    {
                        throw new Exception("Uploaded file for the"+ customerAccount + "not deleted from the Grid");
                    }
                    else
                    {
                        Report.WriteLine(Filename + " is Uploaded for the customer account deleted from the grid");
                    }
                }
            }
            
        }

		[When(@"Verify the customer account has already uploaded with '(.*)'")]
		public void WhenVerifyTheCustomerAccountHasAlreadyUploadedWith(string Filename)
		{
			Report.WriteLine("Verify the customer account has already uploaded logo");
			SelectDropdownlistvalue(attributeName_id, BrandingGridViewDD_id, "All");

			List<string> rowdata = IndividualColumnData(".//*[@id='dt_CustomerLogoGrid']/tbody/tr");
			int i;
			for (i = 1; i <= rowdata.Count; i++)
			{
				string CustNameValue = Gettext(attributeName_xpath, ".//*[@id='dt_CustomerLogoGrid']/tbody/tr[" + i + "]/td[2]");
				if (CustNameValue == customerAccount)
				{
					Report.WriteLine("Customer Account already uploaded with some Logo");
					break;
				}
			}
			if (i == rowdata.Count + 1)
			{
				Report.WriteLine("Upload file through file explorer");
				string FilePath = Path.GetFullPath("../../Scripts/TestData/Testfiles_MaintenanceUpload/ValidFiles/" + Filename);
				Thread.Sleep(3000);
				FileUpload(attributeName_xpath, LogoFileUploadCustomerBranding_Xpath, FilePath);
				Thread.Sleep(5000);
				Click(attributeName_id, SaveBtn_id);
				Click(attributeName_id, BrandingStationdropdown_id);
				SendKeys(attributeName_xpath, SelectStationSearchbox_xpath, stationName);
				Click(attributeName_xpath, StationNameOption_xpath);
				Click(attributeName_id, BrandingCustomerropdown_id);
				SelectDropdownValueFromList(attributeName_id, BrandingCustomerropdown_id, customerAccount);
			}
		}


		[When(@"I click on the customer drop down and select one customer from drop down list")]
		public void WhenIClickOnTheCustomerDropDownAndSelectOneCustomerFromDropDownList()
		{
			Report.WriteLine("I click on the customer drop down and select one station from drop down list");
			Click(attributeName_id, BrandingCustomerropdown_id);
			List<string> ListofCustomerinCustomerBranding_UI = GetDropdownValues(attributeName_id, BrandingCustomerropdown_id, TagNameforCustomer_Dropdownoptions);
			ListofCustomerinCustomerBranding_UI.Remove("Select customer...");
			DBHelper dbhelper = new DBHelper();

			List<string> ListofCustomerinCustomerBranding_DB = dbhelper.GetCustomers(stationName).Select(x => x.Name).ToList();
			customerAccount = ListofCustomerinCustomerBranding_DB.FirstOrDefault();

			if (ListofCustomerinCustomerBranding_UI.Count == ListofCustomerinCustomerBranding_DB.Count)
			{
				Report.WriteLine("Station drop down list is same in UI and DB");
				SelectDropdownValueFromList(attributeName_id, BrandingCustomerropdown_id, customerAccount);
			}
		}

		[When(@"I upload a file with '(.*)' through file explorer")]
		public void WhenIUploadAFileWithThroughFileExplorer(string Filename_path)
		{
			Report.WriteLine("Upload file through file explorer");
			string FilePath = Path.GetFullPath(Filename_path);
			Thread.Sleep(3000);
			FileUpload(attributeName_xpath, LogoFileUploadCustomerBranding_Xpath, FilePath);
			Thread.Sleep(5000);
		}


		[When(@"I click on the save button")]
		public void WhenIClickOnTheSaveButton()
		{
			Report.WriteLine("I click on the save button");
			Click(attributeName_id, SaveBtn_id);
		}


		[Then(@"Verify the logo name '(.*)' updated in the Customer Specific Logos list and Custom logo flag set to On by default")]
		public void ThenVerifyTheLogoNameUpdatedInTheCustomerSpecificLogosListAndCustomLogoFlagSetToOnByDefault(string Filename)
		{
			Report.WriteLine("verifying saved image file name should be customer specific logo grid");
			SelectDropdownlistvalue(attributeName_id, BrandingGridViewDD_id, "All");

			List<string> rowdata = IndividualColumnData(".//*[@id='dt_CustomerLogoGrid']/tbody/tr");
			for (int i = 1; i < rowdata.Count; i++)
			{
				string CustNameValue = Gettext(attributeName_xpath, ".//*[@id='dt_CustomerLogoGrid']/tbody/tr[" + i + "]/td[2]");
				if (CustNameValue == customerAccount)
				{
					string LogofileName_UI = Gettext(attributeName_xpath, ".//*[@id='dt_CustomerLogoGrid']/tbody/tr[" + i + "]/td[3]");
					string[] LogoName_Splitted = LogofileName_UI.Split('_');
					string Filename_Actual = LogoName_Splitted[1].Trim();
					if (Filename_Actual == Filename)
					{
						Report.WriteLine(Filename + " is Uploaded for the customer account and present in the grid");

						Report.WriteLine("Custom logo flag should be set to On by default");
						Assert.IsTrue(IsElementEnabled(attributeName_xpath, ".//*[@id='dt_CustomerLogoGrid']/tbody/tr[" + i + "]/td[4]/div/label[1]", "ON"));
						break;
					}
				}
			}
		}

		[Then(@"Verify the Toggle on '(.*)' button state")]
		public void ThenVerifyTheToggleOnButtonState(string ON)
		{
			Report.WriteLine("Verify the Toggle on button state");
			var Onstate = IsElementEnabled(attributeName_xpath, OnButtonInToggle_xpath, ON);
			if (Onstate == true)
			{
				Assert.IsTrue(IsElementEnabled(attributeName_xpath, OnButtonInToggle_xpath, ON));
			}
			else
			{
				Click(attributeName_xpath, OnButtonInToggle_xpath);
				Assert.IsTrue(IsElementEnabled(attributeName_xpath, OnButtonInToggle_xpath, ON));
			}
		}

		[Then(@"Verify the Toggle off '(.*)' button  state")]
		public void ThenVerifyTheToggleOffButtonState(string OFF)
		{
			Report.WriteLine("Verify the Toggle on button state");
			var Onstate = IsElementEnabled(attributeName_xpath, OffButtonInToggle_xpath, OFF);
			if (Onstate == true)
			{
				Assert.IsTrue(IsElementEnabled(attributeName_xpath, OffButtonInToggle_xpath, OFF));
			}
			else
			{
				Click(attributeName_xpath, OffButtonInToggle_xpath);
				Assert.IsTrue(IsElementEnabled(attributeName_xpath, OffButtonInToggle_xpath, OFF));
			}
		}

		[Then(@"Verify toggle button have '(.*)' and '(.*)' lables")]
		public void ThenVerifyToggleButtonHaveAndLables(string ON, string OFF)
		{
			Report.WriteLine("Verify toggle button have ON and OFF lables");
			Verifytext(attributeName_xpath, OnButtonInToggle_xpath, ON);
			Verifytext(attributeName_xpath, OffButtonInToggle_xpath, OFF);
		}

		[When(@"I click on the station drop down and select one station from drop down list for '(.*)'")]
		public void WhenIClickOnTheStationDropDownAndSelectOneStationFromDropDownListFor(string Username)
		{
			Report.WriteLine("I click on the station drop down and select one station from drop down list");
			IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);
			List<AppUserClaimInfo> abc = IDP.GetUserClaimDetails(Username);
			var Email = IDP.GetClaimValue(Username, "email");
			string setupID = IDP.GetClaimValue(Username, "dlscrm-CustomerSetUpId");
			int value = Convert.ToInt32(setupID);

		}

		[Then(@"verify the pop up window with '(.*)', '(.*)' and buttons with '(.*)' and '(.*)'")]
		public void ThenVerifyThePopUpWindowWithAndButtonsWithAnd(string overwrite, string OverwriteDescription, string Yes, string No)
		{
			Report.WriteLine("verify the confirmation pop up");
			WaitForElementVisible(attributeName_xpath, Popup_Window_Confirmation_Xpath, overwrite);
			Verifytext(attributeName_xpath, Popup_Window_Confirmation_Text_xpath, OverwriteDescription);
			Verifytext(attributeName_id, Logo_Confirmation_YesButton_id, Yes);
			Verifytext(attributeName_xpath, Logo_Confirmation_NoButton_Xpath, No);
		}

		[When(@"I click on the yes button")]
		public void WhenIClickOnTheYesButton()
		{
			Report.WriteLine("Click to yes button");
			WaitForElementVisible(attributeName_id, Logo_Confirmation_YesButton_id, "Yes button");
			Click(attributeName_id, Logo_Confirmation_YesButton_id);
		}

		[When(@"I click on the No button")]
		public void WhenIClickOnTheNoButton()
		{
			Report.WriteLine("Click to no button");
			WaitForElementVisible(attributeName_xpath, Logo_Confirmation_NoButton_Xpath,"No Button");
			Click(attributeName_xpath, Logo_Confirmation_NoButton_Xpath);
		}

		[Then(@"Verify the pop up should close")]
		public void ThenVerifyThePopUpShouldClose()
		{
			Report.WriteLine("Verifying the Popup window has closed");
			WaitForElementNotVisible(attributeName_xpath, Popup_Window_Confirmation_Xpath, "Confirmation");
			VerifyElementNotVisible(attributeName_xpath, Popup_Window_Confirmation_Text_xpath, "Are you sure you want to overwrite the logo?");
			VerifyElementNotVisible(attributeName_id, Logo_Confirmation_YesButton_id, "Yes");
			VerifyElementNotVisible(attributeName_xpath, Logo_Confirmation_NoButton_Xpath, "No");
		}

		[Then(@"Verify the old logo file name '(.*)' should overwritten by the new logo file name '(.*)'")]
		public void ThenVerifyTheOldLogoFileNameShouldOverwrittenByTheNewLogoFileName(string Filename, string NewFilename)
		{
			Report.WriteLine("Verify file name overwritten or not");
			SelectDropdownlistvalue(attributeName_id, BrandingGridViewDD_id, "All");

			List<string> rowdata = IndividualColumnData(".//*[@id='dt_CustomerLogoGrid']/tbody/tr");
			for (int i = 1; i < rowdata.Count; i++)
			{
				string CustNameValue = Gettext(attributeName_xpath, ".//*[@id='dt_CustomerLogoGrid']/tbody/tr[" + i + "]/td[2]");
				if (CustNameValue == customerAccount)
				{
					string LogofileName_UI = Gettext(attributeName_xpath, ".//*[@id='dt_CustomerLogoGrid']/tbody/tr[" + i + "]/td[3]");
					string[] LogoName_Splitted = LogofileName_UI.Split('_');
					string Filename_Actual = LogoName_Splitted[1].Trim();
					if (Filename_Actual == NewFilename)
					{
						Report.WriteLine(NewFilename + " is Uploaded for the customer account and present in the grid");

						break;
					}
				}
			}
		}

		[When(@"I click on the backtoMaintenanceTool button")]
		public void WhenIClickOnTheBacktoMaintenanceToolButton()
		{
			Report.WriteLine("I click on the backtoMaintenanceTool button");
			Click(attributeName_id, BacktoMaintenanceBtn_id);
		}

		[Then(@"I should navigate to the Maintenance Tools landing page '(.*)'")]
		public void ThenIShouldNavigateToTheMaintenanceToolsLandingPage(string MaintenanceTools)
		{
			Report.WriteLine("Verify page is navigated back to the MaintenanceTools page");
			string maintenancePage = Gettext(attributeName_xpath, MaintenancePageTitle_xpath);
			Assert.AreEqual(maintenancePage, MaintenanceTools);
		}

        [When(@"I upload a file from '(.*)' through file explorer")]
        public void WhenIUploadAFileFromThroughFileExplorer(string filepath)
        {
            Report.WriteLine("Upload file through file explorer");
            string FilePath = Path.GetFullPath(filepath);
            Thread.Sleep(3000);
            FileUpload(attributeName_xpath, SelectFileUploadLocator_xpath, FilePath);
            Thread.Sleep(5000);
        }

		[Then(@"I should see the '(.*)' error message in the add customer specific logo section")]
		public void ThenIShouldSeeTheErrorMessageInTheAddCustomerSpecificLogoSection(string errormsg)
		{
			Report.WriteLine("I able to see the Error message in the Add Customer Specific Logo Section");
			Verifytext(attributeName_xpath, addCustomerSpecific_Warningerrormsg_xpath, errormsg);
		}

		[Then(@"I should see the '(.*)' error message in the add customer specific logo section when image size exceed limits")]
		public void ThenIShouldSeeTheErrorMessageInTheAddCustomerSpecificLogoSectionWhenImageSizeExceedLimits(string errormsg)
		{
			Report.WriteLine("Verify the error message if we upload image more than 20 MB");
			Verifytext(attributeName_xpath, addCustomerSpecific_LimitWarningerrormsg_xpath, errormsg);
		}

		[Then(@"I should see the '(.*)' error message in the add customer specific logo section when image wrong format")]
		public void ThenIShouldSeeTheErrorMessageInTheAddCustomerSpecificLogoSectionWhenImageWrongFormat(string errormsg)
		{
			Report.WriteLine("Verify the error message if we upload other format of image ");
			Verifytext(attributeName_xpath, addCustomerSpecific_WrongFormatimgerrormsg_xpath, errormsg);
		}

		[When(@"When I click on the add customer specific logo expand or collapse button")]
		public void WhenWhenIClickOnTheAddCustomerSpecificLogoExpandOrCollapseButton()
		{
			Report.WriteLine("Click on the toggle up button in add customer specific logo header section");
			Click(attributeName_xpath, addCustomerSpecificLogoExpandIcon_xpath);
			Thread.Sleep(3000);
		}

		[When(@"I should not see an option to select a station with lable'(.*)' and with the default text as '(.*)'")]
		public void WhenIShouldNotSeeAnOptionToSelectAStationWithLableAndWithTheDefaultTextAs(string StationLbl, string Selectstation)
		{
			Report.WriteLine("User should not able to see the Option Station or Select a station under the  Add customer specific logo header section");
			ElementNotPresent(attributeName_xpath, StationLbl_xpath, StationLbl);
			ElementNotPresent(attributeName_linktext, Selectstation_link, Selectstation);
		}

		[When(@"Verify the logo file name for the selected customer in the Customer Specific Logos list")]
		public void WhenVerifyTheLogoFileNameForTheSelectedCustomerInTheCustomerSpecificLogosList()
		{
			Report.WriteLine("Verify the logo file name for the selected customer in the Customer specific logo list");
			imageName = Gettext(attributeName_xpath, addLogofile_browse_uploading_xpath);
			List<string> imageLogoFileList = IndividualColumnData(".//*[@id='dt_CustomerLogoGrid']/tbody/tr/td[3]");
			bool isConditionSatisfied = imageLogoFileList.Any(x => x.Contains(imageName));
			Assert.IsTrue(isConditionSatisfied);
		}

		[Then(@"I should see all the required labels (.*), (.*), (.*), (.*) and (.*) buttons")]
		public void ThenIShouldSeeAllTheRequiredLabelsAndButtons(string StationLbl, string CustomerLbl, string AddLogoFileLbl, string browse, string Save)
		{
			Report.WriteLine("I should see all the required labels and buttons");
			Verifytext(attributeName_xpath, StationLbl_xpath, StationLbl);
			Verifytext(attributeName_xpath, CustomerLbl_xpath, CustomerLbl);
			Verifytext(attributeName_xpath, AddLogoFileLbl_xpath, AddLogoFileLbl);
			Verifytext(attributeName_xpath, browse_xpath, browse);
			Verifytext(attributeName_id, SaveBtn_id, Save);
		}
	}
}
