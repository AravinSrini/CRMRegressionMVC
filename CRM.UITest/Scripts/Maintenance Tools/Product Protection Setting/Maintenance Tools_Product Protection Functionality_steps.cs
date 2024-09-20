using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Maintenance_Tools.Product_Protection_Setting
{
	[Binding]
	public sealed class Maintenance_Tools_Product_Protection_Functionality_steps : ObjectRepository
	{
		[Given(@"I am a DLS system admin user and login into application with valid (.*),(.*)")]
		public void GivenIAmADLSSystemAdminUserAndLoginIntoApplicationWithValid(string Username, string Password)
		{


			Report.WriteLine("Launch URL");
			LaunchURL();
			Report.WriteLine("Land on Homepage");
			Click(attributeName_id, SignIn_Id);
			Report.WriteLine("Enter valid Username and Password and click on Log in");
			SendKeys(attributeName_id, IDP_Username_Id, Username);
			SendKeys(attributeName_id, IDP_Password_Id, Password);
			Click(attributeName_xpath, IDP_Login_Xpath);
            Thread.Sleep(2000);
		}

		[When(@"I Click on the Maintenance tool icon in the navigation menu")]
		public void WhenIClickOnTheMaintenanceToolIconInTheNavigationMenu()
		{
			Click(attributeName_id, MaintenanceModule_id);
		}
		
		[Then(@"I will have a Product Protection option")]
		public void ThenIWillHaveAProductProtectionOption()
		{
			Click(attributeName_id, PPFTabMaintenanceOption_id);
		}

		[Then(@"I have clicked on PRODUCTION PROTECTION tab")]
		public void ThenIHaveClickedOnPRODUCTIONPROTECTIONTab()
		{
			Click(attributeName_xpath, PPFTab_Xpath);
		}


		[Then(@"I click on Product Protection option")]
		public void ThenIClickOnProductProtectionOption()
		{
			Click(attributeName_xpath, PPFTab_Xpath);
		}

		[Then(@"I will arrive on the Product Protection settings page")]
		public void ThenIWillArriveOnTheProductProtectionSettingsPage()
		{
			Report.WriteLine("Verify I will arrive on the Product Protection settings page");
			string expectedText = "Insurance All Risk / Product Protection Settings";
			string actualtext = Gettext(attributeName_xpath, AllRisk_PPFTabHeader_Xpath);
			Assert.AreEqual(expectedText, actualtext);
		}

		[Then(@"I can see Product Protection section")]
		public void ThenICanSeeProductProtectionSection()
		{
			Verifytext(attributeName_xpath, PPFTabPPText_Xpath, "PRODUCT PROTECTION");
		}


		[Then(@"I have clicked on station drop down")]
		public void ThenIHaveClickedOnStationDropDown()
		{
			Click(attributeName_xpath, PPFTabStation_Xpath);
		}

		[Then(@"I have selected any station (.*)")]
		public void ThenIHaveSelectedAnyStation(string stationName)
		{

			SelectDropdownValueFromList(attributeName_xpath, PPFTabStationList_Xpath, stationName);

		}


		[Then(@"Try to select multiple account for the selected station (.*)")]
		public void ThenTryToSelectMultipleAccountForTheSelectedStation(string account_name)
		{
			Report.WriteLine("Verify able to select multiple account for the selected station");

			string s = account_name;
			string[] values = s.Split(',');
			for (int i = 0; i < values.Length; i++)
			{
				values[i] = values[i].Trim();
				Click(attributeName_xpath, PPFTtabCutomerAccount_Xpath);
				//SelectDropdownValueFromList(attributeName_xpath, PPFTtabCutomerAccountList_Xpath, values[i]);
				SelectOptionFromMultiSelectDropDown(attributeName_id, PPF_CustId, attributeName_xpath, PPF_CustDropdownList_Xpath, "//li", values[i]);
				//SelectOptionFromMultiSelectDropDown(attributeName_id, PPF_CustId, attributeName_xpath, PPF_CustDropdownList_Xpath, "//li", values[1]);
			}
		}


		[Then(@"I have clicked on save button without enter customer name")]
		public void ThenIHaveClickedOnSaveButtonWithoutEnterCustomerName()
		{
			Click(attributeName_id, PPF_SaveBtn_id);
		}


		[Then(@"User should be presented with error message")]
		public void ThenUserShouldBePresentedWithErrorMessage()
		{
			Report.WriteLine("Verify error message");
			string expectedErrormsgUI = "PLEASE ENTER ALL REQUIRED INFORMATION";
			string actualCustomer_name = Gettext(attributeName_xpath, PPFGridErrorMessage);
			Assert.AreEqual(expectedErrormsgUI, actualCustomer_name);
		}
		

		[Then(@"I have clicked on save button without enter station name")]
		public void ThenIHaveClickedOnSaveButtonWithoutEnterStationName()
		{
			Click(attributeName_id, PPF_SaveBtn_id);
		}


		[Then(@"I have clicked on save button wihout enter customer name")]
		public void ThenIHaveClickedOnSaveButtonWihoutEnterCustomerName()
		{
			Click(attributeName_id, PPF_SaveBtn_id);
		}

		[Then(@"I can see select a station option")]
		public void ThenICanSeeSelectAStationOption()
		{
			IsElementPresent(attributeName_xpath, PPFTabStation_Xpath, "station drop down");
		}

		[Then(@"I can see select coustomer account serach box")]
		public void ThenICanSeeSelectCoustomerAccountSerachBox()
		{
			IsElementPresent(attributeName_xpath, PPFTtabCutomerAccount_Xpath, "account drop down");
		}

		[Then(@"I can see save button")]
		public void ThenICanSeeSaveButton()
		{
			IsElementPresent(attributeName_xpath, PPFTtabCutomerAccount_Xpath, "account drop down");
		}



		[Then(@"Verify account dispalying under Product Protection gird")]
		public void ThenVerifyaccountsDispalyingUnderProductProtectionGird()
		{
			Report.WriteLine("verifying PP account dispalying under Product Protection gird");
			Click(attributeName_xpath, PPFGridView_Xpath);
			SelectDropdownlistvalue(attributeName_xpath, PPFGridViewList_Xpath, "ALL");

			List<string> CustomernameUI = IndividualColumnData(PPFGridViewCustomerName_Xpath);
			CustomernameUI.Sort();
			List<string> CustomernameUIDB = DBHelper.GetAllNonDefaultaccountListBasedOnStation();
			CustomernameUIDB.Sort();
			if (CustomernameUI.Count > 0)
			{

				if (CustomernameUI.Count == CustomernameUIDB.Count)
				{
					for (int i = 1; i < CustomernameUI.Count; i++)
					{
						if (CustomernameUI[i] == CustomernameUIDB[i])
						{
							Report.WriteLine("PPF accounts are in grid matching with DB");
						}
						else
						{
							throw new Exception("PPF accounts are in grid not matching with DB");
						}
					}

				}
			}
			else
			{
				Report.WriteLine("No accounts available within gird");
			}
		}




		[Then(@"I have clicked on save button and account should be listed as Non default customer(.*)")]
		public void ThenIHaveClickedOnSaveButtonAndAccountShouldBeListedAsNonDefaultCustomer(string sationName)
		{
			Report.WriteLine("verifying saved account should be listed as Non default customer");
			Click(attributeName_id, PPF_SaveBtn_id);
			Thread.Sleep(7000);
			Click(attributeName_xpath, PPFGridView_Xpath);
			SelectDropdownlistvalue(attributeName_xpath, PPFGridViewList_Xpath, "ALL");

			List<string> stationnameUI = IndividualColumnData("//*[@id='ShipmentService']/tbody/tr/td[1]");
			for (int i = 1; i < stationnameUI.Count; i++)
			{
				if (stationnameUI[i] == sationName)
				{
					Report.WriteLine("saved account is present in the grid" + sationName);
					Click(attributeName_xpath, "//*[@id='ShipmentService']/tbody/tr[" + i + "]/td[5]/button");
					Thread.Sleep(2000);
					Click(attributeName_xpath, OkButton_DeletePopUp_Xpath);
				}

			}
		}



		[Then(@"Verify columns in product protection grid (.*),(.*),(.*),(.*)")]
		public void ThenVerifyColumnsInProductProtectionGrid(string Customer_name, string Staiton_Id, string Station_Name, string Date_Assigned)
		{
			Report.WriteLine("verifying columns in product protection grid");
			string CustomerWithProductProtectionExpected = "Customers with Product Protection";
			string actualCustomerWithProductProtectionText = Gettext(attributeName_xpath, CustomerWithProductProtectionText);
			Assert.AreEqual(CustomerWithProductProtectionExpected, actualCustomerWithProductProtectionText);

			string actualCustomer_name = Gettext(attributeName_xpath, PPFGridCustomerNAmecolumn);
			Assert.AreEqual(Customer_name, actualCustomer_name);

			string actualStaiton_Id = Gettext(attributeName_xpath, PPFGridStationIdcolumn);
			Assert.AreEqual(Staiton_Id, actualStaiton_Id);

			string actualStation_Name = Gettext(attributeName_xpath, PPFGridStationNAmecolumn);
			Assert.AreEqual(Station_Name, actualStation_Name);

			string actualDate_Assigned = Gettext(attributeName_xpath, PPFGridDateAssignedcolumn);
			Assert.AreEqual(Date_Assigned, actualDate_Assigned);
		}


		[Then(@"Station name displayed in UI should match with database")]
		public void ThenStationNameDisplayedInUIShouldMatchWithDatabase()
		{
			Report.WriteLine("verifying Station name displayed in UI should match with database");
			List<string> stationnameUI = IndividualColumnData(PPFTabStationList_Xpath);
			stationnameUI.RemoveAt(0);
			stationnameUI.Sort();
			List<CustomerAccount> stationnameDB = DBHelper.GetAllStationList();
			List<string> stationNames = stationnameDB.Select(p => p.StationName).ToList();
			stationNames.Sort();

			for (int i = 0; i < stationnameUI.Count; i++)
			{
				//string staionname = stationnameDB.ElementAt(i);
				string UIDate = stationnameUI[i];


				if (UIDate == stationNames[i])
				{

				}
			}
		}



		[Then(@"Click on customer account text box list of customer name should be displayed associated to selected station name (.*)")]
		public void ThenClickOnCustomerAccountTextBoxListOfCustomerNameShouldBeDisplayedAssociatedToSelectedStationName(string stationName)
		{
			Report.WriteLine("verifying  customer account text box list of customer name should be displayed associated to selected station name");
			Click(attributeName_xpath, PPFTtabCutomerAccount_Xpath);
			List<string> accountNameUI = IndividualColumnData(PPFTtabCutomerAccountList_Xpath);

			accountNameUI.RemoveAt(0);//Removing hard coaded value "All Account"


			accountNameUI.Sort();
			List<string> accountNameDB = DBHelper.GetAllDefaultaccountListBasedOnStation(stationName);
			accountNameDB.Sort();

			if (accountNameDB.Count == 0)
			{
				Report.WriteLine("No accounts available");
			}
			else
			{
				for (int i = 0; i < accountNameUI.Count; i++)
				{

					if (accountNameUI[i] == accountNameDB[i])
					{
						Report.WriteLine("Displayed accounts are not mapped to selected staion");
					}
					else
					{
						throw new Exception("Displayed accounts are not not mapped to selected staion");
					}
				}
			}
		}


	}

}


