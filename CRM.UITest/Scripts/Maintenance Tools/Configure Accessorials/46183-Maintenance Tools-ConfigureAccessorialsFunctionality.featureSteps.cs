using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.ViewModel;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Maintenance_Tools.Configure_Accessorials
{
    [Binding]
    public class _46183_Maintenance_Tools_ConfigureAccessorialsFunctionality : ConfigureAccessorial
    {
        bool value;
        IList<IWebElement> RateListbefore;
        List<ConfigureAccessorialViewModel> list = null;

        string testDataSortableColumn = string.Empty;
        List<string> beforeSortingDirection = new List<string>();
        List<string> afterDirectionSort = new List<string>();
        char searchLetter = 'a';
        string searchData = "GLTL";

        List<string> beforeSortingName = new List<string>();
        List<string> afterSortingName = new List<string>();

        List<string> beforeSortingServiceCode = new List<string>();
        List<string> afterSortingServiceCode = new List<string>();

        [Given(@"that I am a Config Manager user")]
        public void GivenThatIAmAConfigManagerUser()
        {
            Report.WriteLine("Verifying that I am a Config Manager user");
            string username = ConfigurationManager.AppSettings["username-SystemAdmin"].ToString();
            string password = ConfigurationManager.AppSettings["password-SystemAdmin"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [When(@"I am on the Maintenance Tools page")]
        public void WhenIAmOnTheMaintenanceToolsPage()
        {
            Report.WriteLine("Verifying I am on the Maintenance Tools page");
            Click(attributeName_id, MaintainanceTools_Id);
            Verifytext(attributeName_xpath, MaintainanceToolsHeader_Xpath, "Maintenance Tools");
        }


        [Then(@"I will see Configure Accessorials button")]
        public void ThenIWillSeeConfigureAccessorialsButton()
        {
            Report.WriteLine("Verifying Configure Accessorials button");
            VerifyElementVisible(attributeName_id, configureAccessorialsButton_Id, "Configure Accessorials");
        }


        [Then(@"the verbiage (.*) is displayed next to the Configure Accessorial button")]
        public void ThenTheVerbiageIsDisplayedNextToTheConfigureAccessorialButton(string p0)
        {
            Report.WriteLine("Verifying the verbiage 'Add, edit or remove accessorials' is displayed next to the Configure Accessorial button");
            Verifytext(attributeName_xpath, configureAccessorialsButtonverbiage_Xpath, "Add, edit or remove accessorials");
        }

        [Given(@"I am on the Maintenance Tools page")]
        public void GivenIAmOnTheMaintenanceToolsPage()
        {
            Report.WriteLine("Verifying I am on the Maintenance Tools page");
            Click(attributeName_id, MaintainanceTools_Id);
            Verifytext(attributeName_xpath, MaintainanceToolsHeader_Xpath, "Maintenance Tools");
        }


        [When(@"I click on the Configure Accessorials Button")]
        public void WhenIClickOnTheConfigureAccessorialsButton()
        {
            Report.WriteLine("click on the Configure Accessorials Button");
            Click(attributeName_id, configureAccessorialsButton_Id);
        }


        [Then(@"I will arrive on the Configure Accessorials page")]
        public void ThenIWillArriveOnTheConfigureAccessorialsPage()
        {
            Report.WriteLine("I will arrive on the Configure Accessorials page");
            Verifytext(attributeName_xpath, configureAccessorialsPageHeader_Xpath, "Configure Accessorials");
            Verifytext(attributeName_xpath, configureAccessorialsPageHeaderSubTitle_Xpath, "Add, edit or remove accessorials");
        }

        [Given(@"I clicked On the Configure Accessorials Button")]
        public void GivenIClickedOnTheConfigureAccessorialsButton()
        {
            Report.WriteLine(" clicked on the Configure Accessorials button");
            Click(attributeName_id, configureAccessorialsButton_Id);
        }



        [Given(@"I am on the Configure Accessorials page")]
        public void GivenIAmOnTheConfigureAccessorialsPage()
        {
            Report.WriteLine("I am on the Configure Accessorials page");
            Verifytext(attributeName_xpath, configureAccessorialsPageHeader_Xpath, "Configure Accessorials");
        }


        [Then(@"The list of current accessorials will include the following columns: Name,Service Code,MG Description\(s\),Service Type\(s\),Direction")]
        public void ThenTheListOfCurrentAccessorialsWillIncludeTheFollowingColumnsNameServiceCodeMGDescriptionSServiceTypeSDirection()
        {
            Report.WriteLine("The list of current accessorials will include the following columns: Name,Service Code,MG Description(s),Service Type(s),Direction");
            Verifytext(attributeName_xpath, configureAccessorialsGridNameColumn_Xpath, "NAME");
            Verifytext(attributeName_xpath, configureAccessorialsGridServiceCodeColumn_Xpath, "SERVICE CODE");
            Verifytext(attributeName_xpath, configureAccessorialsGridMGDescriptionColumn_Xpath, "MG DESCRIPTION(S)");
            Verifytext(attributeName_xpath, configureAccessorialsGridServiceTypeColumn_Xpath, "SERVICE TYPE(S)");
            Verifytext(attributeName_xpath, configureAccessorialsGridDirectionColumn_Xpath, "DIRECTION");
        }

        [Then(@"the default display will be based on the Name column \(alphabetically\)")]
        public void ThenTheDefaultDisplayWillBeBasedOnTheNameColumnAlphabetically()
        {
            Report.WriteLine("the default display will be based on the Name column (alphabetically)");
            IList<IWebElement> RateListbefore = GlobalVariables.webDriver.FindElements(By.XPath("//table[@id='Grid_ConfigureAccessorial']/tbody/tr/td[1]"));
            var sorted = RateListbefore.OrderBy(s => s.Text);
            CollectionAssert.AreEqual(sorted.ToList(), RateListbefore.ToList());
        }

        [Then(@"following columns will have a sort option: Name,Service Code,Direction")]
        public void ThenFollowingColumnsWillHaveASortOptionNameServiceCodeDirection()
        {
            Report.WriteLine("following columns will have a sort option: Name,Service Code,Direction)");
            String nameIcon = "return window.getComputedStyle(document.querySelector('th.Col_Name.all.sorting_asc'),'::after').getPropertyValue('content')";
            IJavaScriptExecutor js = (IJavaScriptExecutor)GlobalVariables.webDriver;
            Assert.Inconclusive((String)js.ExecuteScript(nameIcon));

            String serviceCodeIcon = "return window.getComputedStyle(document.querySelector('th.Col_ServiceCode.all.sorting'),'::after').getPropertyValue('content')";
            IJavaScriptExecutor js2 = (IJavaScriptExecutor)GlobalVariables.webDriver;
            Assert.Inconclusive((String)js2.ExecuteScript(serviceCodeIcon));

            String directionIcon = "return window.getComputedStyle(document.querySelector('th.Col_Direction.all.sorting'),'::after').getPropertyValue('content')";
            IJavaScriptExecutor js3 = (IJavaScriptExecutor)GlobalVariables.webDriver;
            Assert.Inconclusive((String)js3.ExecuteScript(directionIcon));
        }


        [Then(@"I will see an Edit button associated with each displayed accessorial")]
        public void ThenIWillSeeAnEditButtonAssociatedWithEachDisplayedAccessorial()
        {
            Report.WriteLine("I will see an Edit button associated with each displayed accessorial)");
            GetTheListOfGrid();
            if (value == false)
            {
                for (int i = 1; i < RateListbefore.Count; i++)
                {
                    VerifyElementPresent(attributeName_xpath, "//table[@id='Grid_ConfigureAccessorial']//tbody//tr[" + i + "]//div/a[1]/span", "Edit button");
                }
            }
            else
            {

            }
        }


        [Then(@"I will see a Delete button associated with each displayed accessorial")]
        public void ThenIWillSeeADeleteButtonAssociatedWithEachDisplayedAccessorial()
        {
            Report.WriteLine("I will see a Delete button associated with each displayed accessorial)");
            GetTheListOfGrid();
            if (value == false)
            {
                for (int i = 1; i < RateListbefore.Count; i++)
                {
                    VerifyElementPresent(attributeName_xpath, "//table[@id='Grid_ConfigureAccessorial']//tbody//tr[" + i + "]//div/a[2]/span", "Delete button");
                }
            }
            else
            {

            }
        }


        public bool GetTheListOfGrid()
        {
            RateListbefore = GlobalVariables.webDriver.FindElements(By.XPath("//table[@id='Grid_ConfigureAccessorial']/tbody/tr"));
            string uiValue = Gettext(attributeName_xpath, "//table[@id='Grid_ConfigureAccessorial']/tbody/tr");
            if (uiValue == "No accessorials to display.")
            {
                value = true;
            }
            else
            {
                value = false;
            }
            return value;
        }

       
        [Then(@"I will see an Add Accessorial Button")]
        public void ThenIWillSeeAnAddAccessorialButton()
        {
            Report.WriteLine("I will see an Add Accessorial Button");
            VerifyElementPresent(attributeName_id, configureAccessorialsPageAddAccessorialButton_Id, "Add Accessorial button");
        }



        [Then(@"I will see a Back to Maintenance Tools Button")]
        public void ThenIWillSeeABackToMaintenanceToolsButton()
        {
            Report.WriteLine("I will see a Back to Maintenance Tools Button");
            VerifyElementPresent(attributeName_id, configureAccessorialsPageBackToMaintenanceToolsButton_Id, "Back to Maintenance Tools button");
        }


        [Then(@"I will see a Filter accessorials\.\.\. field")]
        public void ThenIWillSeeAFilterAccessorials_Field()
        {
            Report.WriteLine(" will see a Filter accessorials field");
            VerifyElementPresent(attributeName_xpath, configureAccessorialsSearchTexBox_Xpath, "Filter accessorials");
        }


        [Then(@"I will see grid display options")]
        public void ThenIWillSeeGridDisplayOptions()
        {
            Report.WriteLine("I will see grid display options");
            VerifyElementPresent(attributeName_id, configureAccessorialsGridNextDirectionArrow_Id, "Grid Next Button");
            VerifyElementPresent(attributeName_id, configureAccessorialsGridPreviousDirectionArrow_Id, "Grid Previous Button");
            VerifyElementPresent(attributeName_id, configureAccessorialsGridViewOption_Id, "View Option");
            VerifyElementPresent(attributeName_id, configureAccessorialsGridShowingInfo_Id, "Showing Info");
        }


        [Then(@"I will see a list of current accessorials")]
        public void ThenIWillSeeAListOfCurrentAccessorials()
        {
            Report.WriteLine("I will see a list of current accessorial");
            list = DBHelper.AccessorialList();

            Click(attributeName_xpath, configureAccessorialsTopGridDefaultView_Xpath);

            Click(attributeName_xpath, "//div[@id='Grid_ConfigureAccessorial_length']//select/option[5]");
            GlobalVariables.webDriver.WaitForPageLoad();

            for (int i = 0; i < list.Count; i++)
            {
                string uiAccessrialName = Gettext(attributeName_xpath, "//table[@id='Grid_ConfigureAccessorial']//tr[" + (i+1) + "]/td[1]");
                Assert.AreEqual(list[i].AccessorialName, uiAccessrialName);

                string uiServiceCode = Gettext(attributeName_xpath, "//table[@id='Grid_ConfigureAccessorial']//tr[" + (i + 1) + "]/td[2]");
                Assert.AreEqual(list[i].AccessorialCode, uiServiceCode);

                string uiMGDescription = Gettext(attributeName_xpath, "//table[@id='Grid_ConfigureAccessorial']//tr[" + (i + 1) + "]/td[3]");
                if (list[i].MG_Description.Count > 0)
                {
                    for(int j=0;j< list[i].MG_Description.Count; j++)
                    Assert.IsTrue(uiMGDescription.Contains(list[i].MG_Description[j]));
                }
                else
                {
                    Assert.AreEqual(string.Empty, uiMGDescription);
                }


                string uiServiceType = Gettext(attributeName_xpath, "//table[@id='Grid_ConfigureAccessorial']//tr[" + (i + 1) + "]/td[4]");
                if (list[i].ShipmentServiceName.Count > 0)
                {
                    for (int j = 0; j < list[i].ShipmentServiceName.Count; j++)
                    Assert.IsTrue(uiServiceType.ToUpper().Contains(list[i].ShipmentServiceName[j].ToUpper()));
                }
                else
                {
                    Assert.AreEqual(string.Empty, uiServiceType);
                }
                

                string uiDirection = Gettext(attributeName_xpath, "//table[@id='Grid_ConfigureAccessorial']//tr[" + (i+1) + "]/td[5]");
                if (list[i].AccessorialDirectionName == "Destination")
                {
                    Assert.AreEqual("Ship To", uiDirection);
                }else if(list[i].AccessorialDirectionName == "Origin")
                {
                    Assert.AreEqual("Ship From", uiDirection);
                }
                else
                {
                    Assert.AreEqual(list[i].AccessorialDirectionName, uiDirection);
                }

            }
        }


        [When(@"there are no accessorials to display")]
        public void WhenThereAreNoAccessorialsToDisplay()
        {
           list = DBHelper.AccessorialList();
           
        }

        [Then(@"I will see the  (.*) message displayed in the Configure Accessorials grid")]
        public void ThenIWillSeeTheMessageDisplayedInTheConfigureAccessorialsGrid(string expectedMessage)
        {
            Report.WriteLine("I will see the  (.*) message displayed in the Configure Accessorials grid");
            string expectedMessageUI = Regex.Replace(expectedMessage, @"(\s+|&|'|\(|\)|<|>|#)", "");
            if (list.Count == 0)
            {
                string uiNoResultsMessage = Gettext(attributeName_xpath, "//table[@id='Grid_ConfigureAccessorial']//tr[1]/td[1]");
                Assert.AreEqual(expectedMessageUI, uiNoResultsMessage);
            }
        }

        [When(@"I arrive on the Configure Accessorials page")]
        public void WhenIArriveOnTheConfigureAccessorialsPage()
        {
            Verifytext(attributeName_xpath, configureAccessorialsPageHeader_Xpath, "Configure Accessorials");
        }

        [Then(@"the accessorial grid display will default to (.*)")]
        public void ThenTheAccessorialGridDisplayWillDefaultTo(int p0)
        {
            Report.WriteLine("The accessorial grid display will default to 10");
            IList<IWebElement> rowS = GlobalVariables.webDriver.FindElements(By.XPath("//table[@id='Grid_ConfigureAccessorial']//tr/td[1]"));
            if (rowS.Count <= 10)
            {
                Console.WriteLine("he accessorial grid displing default to 10");
            }
            else
            {
                Assert.Fail("The accessorial grid display si not default to 10");
            }
        }

        [Then(@"I have the option to change the grid display (.*)")]
        public void ThenIHaveTheOptionToChangeTheGridDisplay(string viewGridFilterOption)
        {

            Report.WriteLine("Verifying the grid sort based on option selected from view drop down");
            list = DBHelper.AccessorialList();
            Click(attributeName_xpath, configureAccessorialsTopGridDefaultView_Xpath);
            IList<IWebElement> viewDropDowmValues = GlobalVariables.webDriver.FindElements(By.XPath(configureAccessorialsTopGridDropDownValues_Xpath));

            for (int i = 0; i < viewDropDowmValues.Count; i++)
            {
                if (viewDropDowmValues[i].Text == viewGridFilterOption)
                {
                    Click(attributeName_xpath, "//div[@id='Grid_ConfigureAccessorial_length']//select/option[" +(i+1) + "]");
                    break;
                }

            }

            IList<IWebElement> recordsInGrid = GlobalVariables.webDriver.FindElements(By.XPath(configureAccessorialsGridRecords_Xpath));
            int recordsCountInGrid = recordsInGrid.Count;
            if (viewGridFilterOption == "ALL")
            {
                Assert.AreEqual(list.Count, recordsCountInGrid);
            }
            else if (list.Count >= Convert.ToInt32(viewGridFilterOption))
            {

                Assert.AreEqual(Convert.ToInt32(viewGridFilterOption), recordsCountInGrid);

            }
            else
            {
                Assert.AreEqual(list.Count, recordsCountInGrid);
            }
        }


        [Then(@"I have option to change the grid display the options are: (.*),(.*),All")]
        public void ThenIHaveOptionToChangeTheGridDisplayTheOptionsAreAll(Decimal p0, Decimal p1)
        {
            Report.WriteLine("Verifying the top and botton grid View drop down Options");

            Click(attributeName_xpath, configureAccessorialsTopGridDefaultView_Xpath);

            IList<IWebElement> topGridviewDropDowmValues = GlobalVariables.webDriver.FindElements(By.XPath(configureAccessorialsTopGridDropDownValues_Xpath));

            List<string> actualtopGridviewDropDowmValues = new List<string>();
            for (int i = 0; i < topGridviewDropDowmValues.Count; i++)
            {
                string data = topGridviewDropDowmValues[i].Text;
                data.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
                actualtopGridviewDropDowmValues.Add(data);
            }
            List<string> expectedViewDropDownOptions = new List<string>
               {
                   "10", "20", "60", "100", "ALL"

               };

            CollectionAssert.AreEqual(actualtopGridviewDropDowmValues, expectedViewDropDownOptions);


            Click(attributeName_xpath, configureAccessorialsBottonGridDefaultView_Xpath);

            IList<IWebElement> bottonGridactualViewDropDowm = GlobalVariables.webDriver.FindElements(By.XPath(configureAccessorialsBottomGridDropDownValues_Xpath));

            List<string> actualBottonGridactualViewDropDowm = new List<string>();
            for (int i = 0; i < bottonGridactualViewDropDowm.Count; i++)
            {
                string data = bottonGridactualViewDropDowm[i].Text;
                data.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
                actualBottonGridactualViewDropDowm.Add(data);
            }
           

            CollectionAssert.AreEqual(actualBottonGridactualViewDropDowm, expectedViewDropDownOptions);
        }

        [Then(@"I have the option to advance to the next page")]
        public void ThenIHaveTheOptionToAdvanceToTheNextPage()
        {
            Report.WriteLine("I have the option to advance to the next page");
            string totalrecords = Gettext(attributeName_id, configureAccessorialsGridShowingInfo_Id);
            string displaycount = totalrecords.Substring(totalrecords.LastIndexOf("of") + 2);
            int displayCountUI = Convert.ToInt32(displaycount);
            if (displayCountUI > 10)
            {
                Report.WriteLine("Clicking on next icon");
                scrollElementIntoView(attributeName_id, configureAccessorialsGridNextDirectionArrow_Id);
                Click(attributeName_id, configureAccessorialsGridNextDirectionArrow_Id);
            }
            else
            {
                Report.WriteLine("Unable to click on next icon as number of records are less than 10");
            }
        }


        [Then(@"I have the option to return to a Previous page")]
        public void ThenIHaveTheOptionToReturnToAPreviousPage()
        {
            Report.WriteLine("I have the option to return to a Previous page");
            string totalrecords = Gettext(attributeName_id, configureAccessorialsGridShowingInfo_Id);
            string displaycount = totalrecords.Substring(totalrecords.LastIndexOf("of") + 2);
            int displayCountUI = Convert.ToInt32(displaycount);
            if (displayCountUI > 10)
            {
                Report.WriteLine("Verifying the left navigation in shipment list page");
                VerifyElementEnabled(attributeName_id, configureAccessorialsGridPreviousDirectionArrow_Id, "Left navigation icon");
                Click(attributeName_id, configureAccessorialsGridPreviousDirectionArrow_Id);
            }
            else
            {
                Report.WriteLine("Unable to verify the left navigation icon functionality as number of records are less than 10");
            }
        }


        [Then(@"the grid options are displayed at the top and bottom of the grid")]
        public void ThenTheGridOptionsAreDisplayedAtTheTopAndBottomOfTheGrid()
        {
            Report.WriteLine("Verifying the grid View drop down Options");
            string gridOptions = Gettext(attributeName_id, configureAccessorialsGridShowingInfo_Id);
            Assert.IsTrue(gridOptions.Contains("Showing"));
            Assert.IsTrue(gridOptions.Contains("of"));

            string gridViewOptions = Gettext(attributeName_id, "Grid_ConfigureAccessorial_length");
            Assert.IsTrue(gridViewOptions.Contains("View"));

            string gridViewOptions1 = Gettext(attributeName_xpath, "//div[@class='table-footer-row']");
            Assert.IsTrue(gridViewOptions1.Contains("Showing"));
            Assert.IsTrue(gridViewOptions1.Contains("of"));
            Assert.IsTrue(gridViewOptions1.Contains("View"));
        }


        [When(@"I click on the sort arrow of any column (.*)")]
        public void WhenIClickOnTheSortArrowOfAnyColumn(string sortableColumn)
        {
            Report.WriteLine("I click on the sort arrow of any column ");
            Click(attributeName_xpath, ".//*[@id='Grid_ConfigureAccessorial_length']/label/select");
            Click(attributeName_xpath, ".//*[@id='Grid_ConfigureAccessorial_length']/label/select/option[5]");

            testDataSortableColumn = sortableColumn;
            switch (sortableColumn)
            {
                case "Name":
                    {
                        string gridValues = Gettext(attributeName_xpath, accessorialGridValue_Xpath);
                        if (gridValues != "No accessorials to display.")
                        {
                            IList<IWebElement> nameColumn = GlobalVariables.webDriver.FindElements(By.XPath(nameColumnAccessorialGrid_Xpath));
                            beforeSortingName = nameColumn.Select(a => a.Text).ToList();
                        }
                        else
                        {
                            Report.WriteLine("No Data found in the Grid");
                        }
                        break;
                    }

                case "Service Code":
                    {
                        string gridValues = Gettext(attributeName_xpath, accessorialGridValue_Xpath);
                        if (gridValues != "No accessorials to display.")
                        {
                            IList<IWebElement> serviceCode = GlobalVariables.webDriver.FindElements(By.XPath(serviceCodeAccessorialGrid_Xpath));
                            beforeSortingServiceCode = serviceCode.Select(a => a.Text).ToList();
                            Click(attributeName_xpath, ".//*[@id='Grid_ConfigureAccessorial']/thead/tr/th[2]");
                        }
                        else
                        {
                            Report.WriteLine("No Data found in the Grid");
                        }
                        break;
                    }

                case "Direction":
                    {
                        string gridValues = Gettext(attributeName_xpath, ".//*[@id='Grid_ConfigureAccessorial']/tbody/tr[1]/td");
                        if (gridValues != "No accessorials to display.")
                        {
                            IList<IWebElement> beforeSortingDirectionValues = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='Grid_ConfigureAccessorial']/tbody/tr/td[5]"));
                            beforeSortingDirection = beforeSortingDirectionValues.Select(a => a.Text).ToList();
                            Click(attributeName_xpath, ".//*[@id='Grid_ConfigureAccessorial']/thead/tr/th[5]");
                        }
                        else
                        {
                            Report.WriteLine("No Data found in the Grid");
                        }
                        break;
                    }
            }
        }

        [Then(@"the grid will be sorted numerically lowest to highest or alphabetically A to Z")]
        public void ThenTheGridWillBeSortedNumericallyLowestToHighestOrAlphabeticallyAToZ()
        {
            Report.WriteLine("the grid will be sorted numerically lowest to highest or alphabetically A to Z ");
            switch (testDataSortableColumn)
            {
                case "Name":
                    {
                        string gridValues = Gettext(attributeName_xpath, accessorialGridValue_Xpath);
                        if (gridValues != "No accessorials to display.")
                        {
                            afterSortingName = beforeSortingName.Select(a => a).ToList();
                            afterSortingName.Sort();
                            IList<IWebElement> nameColumn = GlobalVariables.webDriver.FindElements(By.XPath(nameColumnAccessorialGrid_Xpath));
                            List<string> uiAfterNameSort = nameColumn.Select(a => a.Text).ToList();
                            CollectionAssert.AreEqual(afterSortingName, uiAfterNameSort);
                        }
                        else
                        {
                            Report.WriteLine("No Data found in the Grid");
                        }
                        break;
                    }
                case "Service Code":
                    {
                        List<string> uiAfterServiceCodeSort = new List<string>();
                        string gridValues = Gettext(attributeName_xpath, accessorialGridValue_Xpath);
                        if (gridValues != "No accessorials to display.")
                        {
                            afterSortingServiceCode = beforeSortingServiceCode.Select(a => a).ToList();
                            afterSortingServiceCode.Sort();
                            IList<IWebElement> uiServiceCode = GlobalVariables.webDriver.FindElements(By.XPath(serviceCodeAccessorialGrid_Xpath));
                            uiAfterServiceCodeSort = uiServiceCode.Select(a => a.Text).ToList();
                            CollectionAssert.AreEqual(afterSortingServiceCode, uiAfterServiceCodeSort);
                        }
                        else
                        {
                            Report.WriteLine("No Data found in the Grid");
                        }
                        break;
                    }
                case "Direction":
                    {
                        List<string> uiAfterDirectionSort = new List<string>();
                        string gridValues = Gettext(attributeName_xpath, ".//*[@id='Grid_ConfigureAccessorial']/tbody/tr[1]/td");
                        if (gridValues != "No accessorials to display.")
                        {
                            afterDirectionSort = beforeSortingDirection.Select(a => a).ToList();
                            afterDirectionSort.Sort();
                            IList<IWebElement> uiDirection = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='Grid_ConfigureAccessorial']/tbody/tr/td[5]"));
                            uiAfterDirectionSort = uiDirection.Select(a => a.Text).ToList();
                            CollectionAssert.AreEqual(afterDirectionSort, uiAfterDirectionSort);
                        }
                        else
                        {
                            Report.WriteLine("No Data found in the Grid");
                        }
                        break;
                    }
            }
        }

        [Then(@"clicking on the same column a second time will sort the grid numerically highest to lowest or alphabetically Z to A")]
        public void ThenClickingOnTheSameColumnASecondTimeWillSortTheGridNumericallyHighestToLowestOrAlphabeticallyZToA()
        {
            Report.WriteLine("clicking on the same column a second time will sort the grid numerically highest to lowest or alphabetically Z to A ");
            string gridValues = Gettext(attributeName_xpath, ".//*[@id='Grid_ConfigureAccessorial']/tbody/tr[1]/td");
            if (gridValues != "No accessorials to display.")
            {
                switch (testDataSortableColumn)
                {
                    case "Name":
                        {
                            afterSortingName.Reverse();

                            List<string> uiNameReverseSort = new List<string>();
                            Click(attributeName_xpath, ".//*[@id='Grid_ConfigureAccessorial']/thead/tr/th[2]");
                            Click(attributeName_xpath, ".//*[@id='Grid_ConfigureAccessorial']/thead/tr/th[1]");
                            //MoveToElement(attributeName_xpath, ".//*[@id='Grid_ConfigureAccessorial']/thead/tr/th[1]");
                            Click(attributeName_xpath, ".//*[@id='Grid_ConfigureAccessorial']/thead/tr/th[1]");
                            IList<IWebElement> uiName = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='Grid_ConfigureAccessorial']/tbody/tr/td[1]"));
                            uiNameReverseSort = uiName.Select(a => a.Text).ToList();
                            CollectionAssert.AreEqual(afterSortingName, uiNameReverseSort);
                            break;
                        }

                    case "Service Code":
                        {
                            afterSortingServiceCode.Reverse();

                            List<string> uiServiceCodeReverseSort = new List<string>();
                            Click(attributeName_xpath, ".//*[@id='Grid_ConfigureAccessorial']/thead/tr/th[2]");
                            IList<IWebElement> uiService = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='Grid_ConfigureAccessorial']/tbody/tr/td[2]"));
                            uiServiceCodeReverseSort = uiService.Select(a => a.Text).ToList();
                            CollectionAssert.AreEqual(afterSortingServiceCode, uiServiceCodeReverseSort);
                            break;
                        }

                    case "Direction":
                        {
                            afterDirectionSort.Reverse();

                            List<string> uiDirectionReverseSort = new List<string>();
                            Click(attributeName_xpath, ".//*[@id='Grid_ConfigureAccessorial']/thead/tr/th[5]");
                            IList<IWebElement> uiDirection = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='Grid_ConfigureAccessorial']/tbody/tr/td[5]"));
                            uiDirectionReverseSort = uiDirection.Select(a => a.Text).ToList();
                            CollectionAssert.AreEqual(afterDirectionSort, uiDirectionReverseSort);
                            break;
                        }
                }
            }
            else
            {
                Report.WriteLine("No Data found in the Grid");
            }
        }

        [When(@"I click in the (.*) field")]
        public void WhenIClickInTheField(string search)
        {
            Click(attributeName_xpath, configureAccessorialsSearchTexBox_Xpath);
        }

        [Then(@"I have the option to type in any value")]
        public void ThenIHaveTheOptionToTypeInAnyValue()
        {

            SendKeys(attributeName_xpath, configureAccessorialsSearchTexBox_Xpath, searchData);
        }

        [Then(@"grid will show rows that contain the values")]
        public void ThenGridWillShowRowsThatContainTheValues()
        {
            Report.WriteLine("grid will show rows that contain the values ");
            string checkGridDataPresent = Gettext(attributeName_xpath, ".//*[@id='Grid_ConfigureAccessorial']/tbody/tr[1]/td[1]");
            if (checkGridDataPresent != "No accessorials to display.")
            {
                //Verifying Searched data in Name Column
                IList<IWebElement> searchedNamehighlightedValues = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='Grid_ConfigureAccessorial']/tbody/tr/td[1]"));
                foreach (var val in searchedNamehighlightedValues)
                {
                    if ((val.Text != null) && (val.Text).Contains(searchData))
                    {
                        Report.WriteLine("Searched data is present in Name Column");
                    }

                    else
                    {
                        Report.WriteLine("Searched Data not Present in Name Column");
                    }

                }

                //Verifying Searched data in Service Code Column
                IList<IWebElement> searchedServiceCodehighlightedValues = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='Grid_ConfigureAccessorial']/tbody/tr/td[2]"));
                foreach (var val in searchedServiceCodehighlightedValues)
                {
                    if ((val.Text != null) && (val.Text).Contains(searchData))
                    {
                        Report.WriteLine("Searched data is present in Service Code Column");
                    }

                    else
                    {
                        Report.WriteLine("Searched data is not present in Service Code Column");
                    }
                }

                //Verifying Searched data present in Mg Description column
                IList<IWebElement> searchedMGDescriptionhighlightedValues = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='Grid_ConfigureAccessorial']/tbody/tr/td[3]"));
                foreach (var val in searchedMGDescriptionhighlightedValues)
                {
                    if ((val.Text != null) && (val.Text).Contains(searchData))
                    {
                        Report.WriteLine("Searched data is present in MG Decription Column");
                    }
                    else
                    {
                        Report.WriteLine("Searched data is not present in MG Decription Column");
                    }
                }

                //Verifying Searched data present in Service Type column
                IList<IWebElement> searchedServiceTypehighlightedValues = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='Grid_ConfigureAccessorial']/tbody/tr/td[4]"));
                foreach (var val in searchedServiceTypehighlightedValues)
                {
                    if ((val.Text != null) && (val.Text).Contains(searchData))
                    {
                        Report.WriteLine("Searched data is present in Service Type Column");
                    }
                    else
                    {
                        Report.WriteLine("Searched data is not present in Service Type Column");
                    }
                }

                //Verifying Searched data present in Direction column
                IList<IWebElement> searchedDirectionhighlightedValues = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='Grid_ConfigureAccessorial']/tbody/tr/td[5]"));
                foreach (var val in searchedDirectionhighlightedValues)
                {
                    if ((val.Text != null) && (val.Text).Contains(searchData))
                    {
                        Report.WriteLine("Searched data is present in Direction Type Column");
                    }
                    else
                    {
                        Report.WriteLine("Searched data is not present in Direction Type Column");
                    }
                }
            }
        }


        [Then(@"entered text will be highlighted")]
        public void ThenEnteredTextWillBeHighlighted()
        {
            Report.WriteLine("entered text will be highlighted ");
            string gridValues = Gettext(attributeName_xpath, ".//*[@id='Grid_ConfigureAccessorial']/tbody/tr[1]/td");
            if (gridValues != "No accessorials to display.")
            {
                //Verifying Text Highlight in Name Column
                IList<IWebElement> searchedNamehighlightedValues = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='Grid_ConfigureAccessorial']/tbody/tr/td[1]"));
                foreach (var val in searchedNamehighlightedValues)
                {
                    if ((val.Text != null) && (val.Text).Contains(searchData))
                    {
                        var colorofHighlightedValue = GetCSSValue(attributeName_classname, "highlight", "background-color");
                        Assert.AreEqual("rgba(81, 123, 207, 0.4)", colorofHighlightedValue);
                        Report.WriteLine("Searched data is present in Name Column and the text has been highlighted");
                    }

                    else
                    {
                        Report.WriteLine("Searched Data not Present in Name Column");
                    }
                }

                //Verifying Text Highlight in Service Code Column
                IList<IWebElement> searchedServiceCodehighlightedValues = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='Grid_ConfigureAccessorial']/tbody/tr/td[2]"));
                foreach (var val in searchedServiceCodehighlightedValues)
                {
                    if ((val.Text != null) && (val.Text).Contains(searchData))
                    {
                        var colorofHighlightedValue = GetCSSValue(attributeName_classname, "highlight", "background-color");
                        Assert.AreEqual("rgba(81, 123, 207, 0.4)", colorofHighlightedValue);
                        Report.WriteLine("Searched data is present in Service Code Column and the text has been highlighted");
                    }

                    else
                    {
                        Report.WriteLine("Searched data is not present in Service Code Column");
                    }
                }

                //Verifying Text Highlight in MG Description Column
                IList<IWebElement> searchedMGDescriptionhighlightedValues = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='Grid_ConfigureAccessorial']/tbody/tr/td[3]"));
                foreach (var val in searchedMGDescriptionhighlightedValues)
                {
                    if ((val.Text != null) && (val.Text).Contains(searchData))
                    {
                        var colorofHighlightedValue = GetCSSValue(attributeName_classname, "highlight", "background-color");
                        Assert.AreEqual("rgba(81, 123, 207, 0.4)", colorofHighlightedValue);
                        Report.WriteLine("Searched data is present in MG Description Column and the text has been highlighted");
                    }
                    else
                    {
                        Report.WriteLine("Searched data is not present in Service Code Column and the text has been highlighted");
                    }
                }

                //Verifying Text Highlight in Service Type Column
                IList<IWebElement> searchedServiceTypehighlightedValues = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='Grid_ConfigureAccessorial']/tbody/tr/td[4]"));
                foreach (var val in searchedServiceTypehighlightedValues)
                {
                    if ((val.Text != null) && (val.Text).Contains(searchData))
                    {
                        var colorofHighlightedValue = GetCSSValue(attributeName_classname, "highlight", "background-color");
                        Assert.AreEqual("rgba(81, 123, 207, 0.4)", colorofHighlightedValue);
                        Report.WriteLine("Searched data is present in Service Type Column and the text has been highlighted");
                    }
                    else
                    {
                        Report.WriteLine("Searched data is not present in Service Type Column and the text has been highlighted");
                    }
                }

                IList<IWebElement> searchedDirectionhighlightedValues = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='Grid_ConfigureAccessorial']/tbody/tr/td[5]"));
                foreach (var val in searchedDirectionhighlightedValues)
                {
                    if ((val.Text != null) && (val.Text).Contains(searchData))
                    {
                        var colorofHighlightedValue = GetCSSValue(attributeName_classname, "highlight", "background-color");
                        Assert.AreEqual("rgba(81, 123, 207, 0.4)", colorofHighlightedValue);
                        Report.WriteLine("Searched data is present in Service Type Column and the text has been highlighted");
                    }
                    else
                    {
                        Report.WriteLine("Searched data is not present in Service Type Column and the text has been highlighted");
                    }
                }
            }
        }


        [When(@"I click on the Back to Maintenance Tools Button")]
        public void WhenIClickOnTheBackToMaintenanceToolsButton()
        {
            Click(attributeName_id, configureAccessorialsPageBackToMaintenanceToolsButton_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
        }


        [Then(@"I will arrive on the Maintenance Tools page")]
        public void ThenIWillArriveOnTheMaintenanceToolsPage()
        {
            WaitForElementVisible(attributeName_xpath, maintenanceToolsPage_Xpath, "Maintenance Tools");
            Verifytext(attributeName_xpath, maintenanceToolsPage_Xpath, "Maintenance Tools");
        }

    }
}
