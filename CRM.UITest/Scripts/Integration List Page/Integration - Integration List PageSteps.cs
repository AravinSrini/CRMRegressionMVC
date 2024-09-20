using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
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

namespace CRM.UITest.Scripts.Integration_List_Page
{
    [Binding]
    public class Integration___Integration_List_PageSteps : Integration
    {
        CommonMethodsCrm crm = new CommonMethodsCrm();

        [Then(@"I should be see Submit Integration Request Button")]
        public void ThenIShouldBeSeeSubmitIntegrationRequestButton()
        {
            VerifyElementPresent(attributeName_id, IntegrationList_SubmitIntegrationRequest_Button_Id, "SubmitIntegrationRequest");
        }

        [When(@"I click on the filter by status Pending Approval radio button")]
        public void WhenIClickOnTheFilterByStatusPendingApprovalRadioButton()
        {

            Report.WriteLine("Select Pendingapproval requests");
            Thread.Sleep(2000);
            Click(attributeName_xpath, IntegrationList_Filter_PendingApproval_RadioButton_xpath);


        }

        [Then(@"User should see only requests of companies under Station\(s\) that are assigned to me (.*)")]
        public void ThenUserShouldSeeOnlyRequestsOfCompaniesUnderStationSThatAreAssignedToMe(string StationName)
        {
           
            Report.WriteLine("Display option dropdown");
            Click(attributeName_xpath, IntegrationList_TopGrid_DisplayListViewDropdown_Xpath);
            SelectDropdownlistvalue(attributeName_xpath, IntegrationList_TopGrid_DisplayListDropdownOptions_Xpath, "ALL");
            Click(attributeName_xpath, IntegrationList_Filter_All_RadioButton_xpath);

            SendKeys(attributeName_xpath, IntegrationList_SearchTextBox_xpath, StationName);

            int row = GetCount(attributeName_xpath, IntegrationList_StationNameAll_Values_Xpath);
            string noReocrdsCheck = Gettext(attributeName_xpath, ".//*[@id='gridIntegrationList']/tbody/tr/td");
            if ((row >= 1) && (noReocrdsCheck != "No Results Found"))
            {
                List<string> ascSort = new List<string>();
                Report.WriteLine("Clicking on sorting icon");
                //Click(attributeName_xpath, IntegrationList_StationNameClick_Xpath);

                Report.WriteLine("Reading the values from the Insured Rate columns after ascdending sorting");
                IList<IWebElement> stationColCount = GlobalVariables.webDriver.FindElements(By.XPath(IntegrationList_CompanyNameAll_Values_Xpath));
                foreach (IWebElement element in stationColCount)
                {
                    ascSort.Add((element.Text).ToString());

                }
                Thread.Sleep(2000);
                ascSort.Sort();

                List<string> records = DBHelper.GetIntegrationCustomerAccountList(StationName);
                records.Sort();

                Assert.AreEqual(records.Count, ascSort.Count);
                for (int i = 0; i < records.Count; i++)
                {
                    if (records[i].Equals(ascSort[i]))
                    {
                        Report.WriteLine("Count of customers for associated station is matching between UI and DB");
                    }
                    else
                    {
                        throw new System.Exception("Company is mismatching"); 
                    }
                }

            }
        }



        [When(@"I expand the first record details")]
        public void WhenIExpandTheFirstRecordDetails()
        {
            Report.WriteLine("Click on the Expand Icon of First record on Integration Request List Page ");


            Click(attributeName_xpath, FirstrequestexpandIcon_xpath);
        }

        [Then(@"I should be displayed with Status Bar and current status highlighted")]
        public void ThenIShouldBeDisplayedWithStatusBarAndCurrentStatusHighlighted()
        {

        
            var colorofHighlighted_currentstatus = GetCSSValue(attributeName_xpath, pendingRmapprovalstatusbar_xpath, "background-color");
            Assert.AreEqual("rgba(154, 0, 255, 1)", colorofHighlighted_currentstatus);
            Report.WriteLine("display with Status Bar with current status highlighted");
        }

        [Then(@"I can see Pending Approval includes the respective stages")]
        public void ThenICanSeePendingApprovalIncludesTheRespectiveStages()
        {
            string statusforpendingapproval = Gettext(attributeName_xpath, ".//*[@id='gridIntegrationList']/tbody/tr[2]/td/div/div[1]/div/div[1]/div/ul/li[2]/a/span[2]/label");
            Assert.AreEqual(statusforpendingapproval, "Pending RM Approval");
        }

        [Then(@"I can see Company Contact Name, Company Contact Phone and Company Contact Email")]
        public void ThenICanSeeCompanyContactNameCompanyContactPhoneAndCompanyContactEmail()
        {
            Report.WriteLine("displayed with Company Contact Name, Company Contact Phone and Company Contact Email");
            Thread.Sleep(5000);
            VerifyElementVisible(attributeName_id, CompanyContactNameTextbox_id, "textbox");
            Verifytext(attributeName_xpath, CompanyContactNamelabel_xpath, "Company Contact Name".ToUpper());
            VerifyElementVisible(attributeName_id, CompanyContactPhoneTextbox_id, "textbox");
            Verifytext(attributeName_xpath, CompanyContactPhonelabel_xpath, "Company Contact Phone".ToUpper());
            VerifyElementVisible(attributeName_id, CompanyContactEmailTextbox_id, "textbox");
            Verifytext(attributeName_xpath, CompanyContactEmaillabel_xpath, "Company Contact Email".ToUpper());
        }

        [Then(@"I can see IT/developer contact name,IT/developer Contact phone and IT/developer email")]
        public void ThenICanSeeITDeveloperContactNameITDeveloperContactPhoneAndITDeveloperEmail()
        {
            Report.WriteLine("displayed with IT/developer contact name,IT/developer Contact phone and IT/developer email");
            VerifyElementVisible(attributeName_id, IT_developercontactnametextbox_id, "textbox");
            string itcontactName = Gettext(attributeName_xpath, IT_developercontactnamelabel_xpath);

            Verifytext(attributeName_xpath, IT_developercontactnamelabel_xpath, itcontactName);
            VerifyElementVisible(attributeName_id, ITdeveloperContactphonetextbox_id, "textbox");
            string itcontactphone = Gettext(attributeName_xpath, ITdeveloperContactphone_xpath);
            Verifytext(attributeName_xpath, ITdeveloperContactphone_xpath, itcontactphone);
            VerifyElementVisible(attributeName_id, ITdeveloperemailtextbox_id, "textbox");
            string itcontactemail = Gettext(attributeName_xpath, ITdeveloperemaillabel);
            Verifytext(attributeName_xpath, ITdeveloperemaillabel, itcontactemail);
        }

        [Then(@"I can see Type of Integration, Year to Date shipments and Year to Date Revenue")]
        public void ThenICanSeeTypeOfIntegrationYearToDateShipmentsAndYearToDateRevenue()
        {
            Report.WriteLine("displayed with Integration, Year to Date shipments and Year to Date Revenue");
            VerifyElementVisible(attributeName_xpath, TypeofIntegrationdropdown_xpath, "dropdown");
            string typeofIntegration = Gettext(attributeName_xpath, TypeofIntegrationlabel_xpath);
            Verifytext(attributeName_xpath, TypeofIntegrationlabel_xpath, typeofIntegration);
            VerifyElementVisible(attributeName_id, YeartoDateshipmentstextbox_id, "textbox");
            string yeartoDateShipments = Gettext(attributeName_xpath, YeartoDateshipmentslabel_xpath);
            Verifytext(attributeName_xpath, YeartoDateshipmentslabel_xpath, yeartoDateShipments);
            VerifyElementVisible(attributeName_id, YeartoDateRevenuetextbox_id, "textbox");
            string yeartoDateRevenue = Gettext(attributeName_xpath, YeartoDateRevenuelabel_xpath);
            Verifytext(attributeName_xpath, YeartoDateRevenuelabel_xpath, yeartoDateRevenue);
        }

        [Then(@"I can be Potential Revenue, Additional Comments, MG/CSA Total Hours, Integration Team Total Hours and Status")]
        public void ThenICanBePotentialRevenueAdditionalCommentsMGCSATotalHoursIntegrationTeamTotalHoursAndStatus()
        {
            Report.WriteLine("Potential Revenue, Additional Comments, MG/CSA Total Hours, Integration Team Total Hours and Status");
            VerifyElementVisible(attributeName_id, PotentialRevenuetextbox_id, "textbox");
            string potentialRevenue = Gettext(attributeName_xpath, PotentialRevenuelabel_xpath);
            Verifytext(attributeName_xpath, PotentialRevenuelabel_xpath, potentialRevenue);

            VerifyElementVisible(attributeName_id, AdditionalCommentstextbox_id, "textbox");
            string additionalComments = Gettext(attributeName_xpath, AdditionalCommentslabel_xpath);
            Verifytext(attributeName_xpath, AdditionalCommentslabel_xpath, additionalComments);

            //VerifyElementVisible(attributeName_id, MG_CSATotalHourstextbox_id, "textbox");
            //string mgcsatotalHours = Gettext(attributeName_xpath, MG_CSATotalHourslabel_xpath);
            //Verifytext(attributeName_xpath, MG_CSATotalHourslabel_xpath, mgcsatotalHours);

            //VerifyElementVisible(attributeName_id, IntegrationTeamTotalHourstextbox_id, "textbox");
            //string integrationtotalHours = Gettext(attributeName_xpath, IntegrationTeamTotalHourslabel_xpath);
            //Verifytext(attributeName_xpath, IntegrationTeamTotalHourslabel_xpath, integrationtotalHours);

            //VerifyElementVisible(attributeName_xpath, IntegrationTeamStatusdropdown_xpath, "dropdown");
            //string integrationStatus = Gettext(attributeName_xpath, IntegrationTeamStatuslabel_xpath);
            //Verifytext(attributeName_xpath, IntegrationTeamStatuslabel_xpath, integrationStatus);
        }

        [Then(@"I be displaying with integration notes of Comment, Commenter, Date/Time and Public/Private")]
        public void ThenIBeDisplayingWithIntegrationNotesOfCommentCommenterDateTimeAndPublicPrivate()
        {
            Report.WriteLine("integration notes of Comment, Commenter, Date/Time and Public/Private");
            MoveToElement(attributeName_xpath, Commentsheader_xpath);
            string comment = Gettext(attributeName_xpath, Commentsheader_xpath);
            Verifytext(attributeName_xpath, Commentsheader_xpath, comment);

            string commenter = Gettext(attributeName_xpath, Commenterheader_xpath);
            Verifytext(attributeName_xpath, Commenterheader_xpath, commenter);

            string DateTime = Gettext(attributeName_xpath, Date_timeheader_xpath);
            Verifytext(attributeName_xpath, Date_timeheader_xpath, DateTime);

            string publicprivate = Gettext(attributeName_xpath, Public_privateheader_xpath);
            Verifytext(attributeName_xpath, Public_privateheader_xpath, publicprivate);
        }




        [Then(@"I should be see the Export button")]
        public void ThenIShouldBeSeeTheExportButton()
        {
            VerifyElementPresent(attributeName_id, IntegrationList_Export_Button_Id, "Export");
        }

        [Then(@"I should see the search field with search text box")]
        public void ThenIShouldSeeTheSearchFieldWithSearchTextBox()
        {
            VerifyElementPresent(attributeName_xpath, IntegrationList_SearchTextBox_xpath, "Search...");
        }


        [Then(@"I should see the filter radio buttons All, Pending Approval, In Progress , Completed")]
        public void ThenIShouldSeeTheFilterRadioButtonsAllPendingApprovalInProgressCompleted()
        {
            VerifyElementPresent(attributeName_xpath, IntegrationList_Filter_All_RadioButton_xpath, "All");
            VerifyElementPresent(attributeName_xpath, IntegrationList_Filter_PendingApproval_RadioButton_xpath, "Pending Approval");
            VerifyElementPresent(attributeName_xpath, IntegrationList_Filter_InProgress_RadioButton_xpath, "In Progress");
            VerifyElementPresent(attributeName_xpath, IntegrationList_Filter_Completed_RadioButton_xpath, "Completed");

        }

        [Then(@"only ten records should be displayed by default in Integration List page")]
        public void ThenOnlyTenRecordsShouldBeDisplayedByDefaultInIntegrationListPage()
        {

            Report.WriteLine("Verifying the default records on the page load");
            IJavaScriptExecutor executor = (IJavaScriptExecutor)GlobalVariables.webDriver;
            var defaultOption = executor.ExecuteScript("return $('#gridIntegrationList_length :selected').val()");
            Assert.AreEqual("10", defaultOption);
            Report.WriteLine("Default 10 option is selected in the dropdown");
        }


        [Then(@"verify the options (.*) when I click on the view list top grid")]
        public void ThenVerifyTheOptionsWhenIClickOnTheViewListTopGrid(string Options)
        {
            Click(attributeName_xpath, IntegrationList_TopGrid_DisplayListViewDropdown_Xpath);

            Report.WriteLine("Verifying the options present under view dropdown");
            string[] values = Options.Split(',');
            IList<IWebElement> UIValues = GlobalVariables.webDriver.FindElements(By.XPath(IntegrationList_TopGrid_DisplayListDropdownOptions_Xpath));
            List<string> ExpectedVal = new List<string>();

            foreach (var v in values)
            {
                ExpectedVal.Add(v);
            }

            Assert.AreEqual(ExpectedVal.Count, UIValues.Count);
            for (int i = 0; i < UIValues.Count; i++)
            {
                if (ExpectedVal.Contains(UIValues[i].Text))
                {
                    Report.WriteLine("Option" + UIValues[i].Text + " is displaying under view dropdown");
                }
                else
                {
                    Report.WriteLine("Option" + UIValues[i].Text + " displaying under view dropdown is not expected");
                    Assert.IsTrue(false);
                }
            }
        }


        [Then(@"Verify the forward navigation functionality on the top grid")]
        public void ThenVerifyTheForwardNavigationFunctionalityOnTheTopGrid()
        {

            string totalrecords = Gettext(attributeName_xpath, IntegrationList_TopGrid_DisplayListView_Xpath);
            string[] split = totalrecords.Split(new string[] { "of " }, StringSplitOptions.None);
            //string displaycount = totalrecords.Substring(totalrecords.LastIndexOf("OF") + 2);
            int DC = Convert.ToInt32(split[1]);
            if (DC > 10)
            {
                Report.WriteLine("Clicking on next icon");
                Click(attributeName_xpath, IntegrationList_TopGrid_ViewNextIcon_Xpath);
            }
            else
            {
                Report.WriteLine("Unable to click on next icon as number of records are less than 10");
            }
        }


        [Then(@"I click on the backword navigation icon in the top grid of the Integration List page")]
        public void ThenIClickOnTheBackwordNavigationIconInTheTopGridOfTheIntegrationListPage()
        {
            string totalrecords = Gettext(attributeName_xpath, IntegrationList_TopGrid_DisplayListView_Xpath);
            string[] split = totalrecords.Split(new string[] { "of " }, StringSplitOptions.None);
            //string displaycount = totalrecords.Substring(totalrecords.LastIndexOf("OF") + 2);
            int DC = Convert.ToInt32(split[1]);
            if (DC > 10)
            {
                Report.WriteLine("Clicking on previous or left navigation icon");
                Click(attributeName_xpath, IntegrationList_TopGrid_ViewNextIcon_Xpath);
                Click(attributeName_xpath, IntegrationList_TopGrid_ViewPreviousIcon_Xpath);
            }
            else
            {
                Report.WriteLine("Unable to click on next icon as number of records are less than 10");
            }
        }

        [Then(@"Verify the Column names on the Integration list page")]
        public void ThenVerifyTheColumnNamesOnTheIntegrationListPage()
        {

            string stationCol = Gettext(attributeName_xpath, IntegrationList_StationCol_xpath);
            Assert.AreEqual(stationCol, "Station".ToUpper());

            string companyNameCol = Gettext(attributeName_xpath, IntegrationList_CompanyNameCol_xpath);
            Assert.AreEqual(companyNameCol, "Company Name".ToUpper());

            string currentStatusCol = Gettext(attributeName_xpath, IntegrationList_CurrentStatusCol_xpath);
            Assert.AreEqual(currentStatusCol, "Current Status".ToUpper());

            string submitDateCol = Gettext(attributeName_xpath, IntegrationList_SubmitDateCol_xpath);
            Assert.AreEqual(submitDateCol, "Submit Date".ToUpper());

            string lastDateCol = Gettext(attributeName_xpath, IntegrationList_LastDateCol_xpath);
            Assert.AreEqual(lastDateCol, "Last Update Date".ToUpper());


        }

        [Then(@"Verify the color code of the status on the Integration list page")]
        public void ThenVerifyTheColorCodeOfTheStatusOnTheIntegrationListPage()
        {

            Click(attributeName_xpath, ".//*[@id='gridIntegrationList_wrapper']//label[@for='FilterByStatusPendingApproval']");
        

            Report.WriteLine("expanded the Integration Request");
            Click(attributeName_xpath, FirstrequestexpandIcon_xpath);          
             
            var colorofHighlighted_currentstatus = GetCSSValue(attributeName_xpath, pendingRmapprovalstatusbar_xpath, "background-color");
            Assert.AreEqual("rgba(154, 0, 255, 1)", colorofHighlighted_currentstatus);
            Report.WriteLine("display with Status Bar with current status highlighted");
        }

        [Then(@"Verify the color code of the status of the In progress on the Integration list page")]
        public void ThenVerifyTheColorCodeOfTheStatusOfTheInProgressOnTheIntegrationListPage()
        {
            
                Report.WriteLine("expanded the Integration Request");
                Click(attributeName_xpath, FirstrequestexpandIcon_xpath);
            
           
            var colorofHighlighted_currentstatus = GetCSSValue(attributeName_xpath, Inprogressstatusbar_xpath, "background-color");
            try
            {

                Assert.AreEqual("rgba(153, 155, 161, 1)", colorofHighlighted_currentstatus);
            }
            catch
            {

                Assert.AreEqual("rgba(74, 134, 232, 1)", colorofHighlighted_currentstatus);
            }

            Report.WriteLine("display with Status Bar with current status highlighted");

            
        }


        [Then(@"Verify the color code of the status of the Completed on the Integration list page")]
        public void ThenVerifyTheColorCodeOfTheStatusOfTheCompletedOnTheIntegrationListPage()
        {
             
                 WaitForElementVisible(attributeName_xpath, IntegrationList_Filter_Completed_RadioButton_xpath, "radio");
                 Click(attributeName_xpath, IntegrationList_Filter_Completed_RadioButton_xpath);
                
           
                Report.WriteLine("expanded the Integration Request");
                Click(attributeName_xpath, FirstrequestexpandIcon_xpath);
                Thread.Sleep(2000);
           
               

            var colorofHighlighted_currentstatus = GetCSSValue(attributeName_xpath, Completedstatusbar_xpath, "background-color");
            Assert.AreEqual("rgba(153, 155, 161, 1)", colorofHighlighted_currentstatus);
            Report.WriteLine("display with Status Bar with current status highlighted");

        }

        [Then(@"Verify each row has the details icon")]
        public void ThenVerifyEachRowHasTheDetailsIcon()
        {
            Report.WriteLine("User see the Title Integration Request List Page ");
            Click(attributeName_xpath, ".//*[@id='gridIntegrationList_wrapper']//label[@for='FilterByStatusAll']");
           
            int row = GetCount(attributeName_xpath, ".//*[@id='gridIntegrationList']/tbody/tr[@role = 'row']");
            string noReocrdsCheck = Gettext(attributeName_xpath, ".//*[@id='gridIntegrationList']/tbody/tr/td");
            if ((row >= 1) && (noReocrdsCheck != "No Results Found"))
            {
                for (int i = 1; i <= row; i++)
                {
                    VerifyElementPresent(attributeName_xpath, ".//*[@id='gridIntegrationList']/tbody/tr[@role='row']/td[6]/button[@class='btn exandableTrigger image-only-sm']", "Detail Icon");
                }
            }
            else
            {
                Report.WriteLine("No records for Integration Grid ");
            }
        }


        


        [Then(@"Verify the default status selection on the Integration list page")]
        public void ThenVerifyTheDefaultStatusSelectionOnTheIntegrationListPage()
        {
            IsElementEnabled(attributeName_xpath, IntegrationList_Filter_InProgress_RadioButton_xpath, "IN PROGRESS");
         
        }


        [Given(@"I am a operations, sales, sales management,station owner or systemadmin user (.*) and (.*)")]
        public void GivenIAmAOperationsSalesSalesManagementStationOwnerOrSystemadminUserAnd(string UserName, string Password)
        {
            crm.LoginToCRMApplication(UserName, Password);
        }




        [Given(@"I am an operations, sales, or station owner user (.*) and (.*)")]
        public void GivenIAmAnOperationsSalesOrStationOwnerUserAnd(string Username, string Password)
        {
            crm.LoginToCRMApplication(Username, Password);
        }

        [Then(@"Grid should display the entered (.*) and should be highlighted")]
        public void ThenGridShouldDisplayTheEnteredAndShouldBeHighlighted(string EnterData)
        {
            SendKeys(attributeName_xpath, IntegrationList_SearchTextBox_xpath, EnterData);

            //int row = GetCount(attributeName_xpath, IntegrationList_StationNameAll_Values_Xpath);
            //for (int i = 1; i <= row; i++)
            //{

            //    var colorofHighlighted_currentstatus = GetCSSValue(attributeName_classname, ".//*[@id='gridIntegrationList']/tbody/tr[@id="+row+"]/td[2]", "background-color");
            //    Assert.AreEqual("rgba(185, 202, 236, 1)", colorofHighlighted_currentstatus);
            //    Report.WriteLine("display with Status Bar with current status highlighted");

            //    string verifyText = Gettext(attributeName_xpath, ".//*[@id='gridIntegrationList']/tbody/tr[@role = 'row']/td[2]");
            //    if (verifyText.Equals(EnterData))
            //    {
            //        Report.WriteLine("Entered data is filtered in the UI and macthing");
            //    }
            //    else
            //    {
            //        Report.WriteLine("Entered data is not filtered in the UI and not matching");
            //        Assert.Fail();
            //    }
            //}

            int rowcount = GetCount(attributeName_xpath, IntegrationList_StationNameAll_Values_Xpath);
            if (rowcount >= 1)
            {
                IList<IWebElement> SearchedReferenceNumberhighlightedValues = GlobalVariables.webDriver.FindElements(By.XPath(IntegrationList_CompanyNameAll_Values_Xpath));
                int HighlightedRefNameCount = SearchedReferenceNumberhighlightedValues.Count;
                foreach (var val in SearchedReferenceNumberhighlightedValues)
                {
                    if (EnterData.Contains(val.Text))
                    {
                        var colorofHighlighted_ReferenceNumber_Value = GetCSSValue(attributeName_classname, "highlight", "background-color");
                        Assert.AreEqual("rgba(81, 123, 207, 0.4)", colorofHighlighted_ReferenceNumber_Value);
                        Report.WriteLine("Highlighted Reference Number values are appropriate");
                    }

                    else
                    {
                        Assert.Fail();
                    }

                }


            }
            else
            {
                Report.WriteLine("No Records found for the Shipment List for the logged in user so unable to test the scenario");
            }
        }
    }
}


