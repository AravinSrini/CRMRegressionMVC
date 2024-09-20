using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;
using CRM.UITest.Entities;

namespace CRM.UITest.Scripts.Maintenance_Tools.Master_Carrier_Rate_Settings
{
    [Binding]
    public class MasterCarrierRateSettings_NewAccessorial_NotificationSteps : MaintenaceTools
    {
        Random random = new Random();

        IList<IWebElement> accessorialDropdownValues = null;
        List<string> dropdownValueAccessorialValueUI = null;
        string notificationValue;
        int iValue;
        string carriers = string.Empty;
        int firstCarrierRowCount;
        int secondCarrierRowCount;
        MasterCarrierRateSettings_OverlengthAccessorialTypesSteps stepsFromMasterCarrierRateSettingsOverlengthAccessorialType = new MasterCarrierRateSettings_OverlengthAccessorialTypesSteps();

        [Given(@"I have selected Customer in Master Carrier Rate settings page")]
        public void GivenIHaveSelectedCustomerInMasterCarrierRateSettingsPage()
        {
            Click(attributeName_xpath, MaintenanceTools_Icon_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, Pricing_Button_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            VerifyElementVisible(attributeName_xpath, MasterCarrierRatePage_Title_Xpath, "Master Carrier Rate Settings page");
            Report.WriteLine("I am on Master Carrier Rate Settings page");

            //List<string> dbGainshareCustomer = DBHelper.GetGainshareCustomer();
            //Click(attributeName_xpath, CustomerSelection_DropdownBox_Xpath);
            //IList<IWebElement> totalCustomerDropdownValues = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='CategoryType_chosen']/div/ul/li"));

            //List <string> _DropdownValue_CustomerName = totalCustomerDropdownValues.Skip(1).Select(a => a.Text).ToList();
            // string h = _DropdownValue_CustomerName.Where(p1 => dbGainshareCustomer.Any(p2 => p1 == p2)).FirstOrDefault();
            //SelectDropdownValueFromList(attributeName_xpath, CustomerSelection_DropdownList_Xpath, h);

            List<string> dbCustomers = DBHelper.GetCustomers();
            Click(attributeName_xpath, CustomerSelection_DropdownBox_Xpath);
            IList<IWebElement> totalCustomerDropdownValues = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='CategoryType_chosen']/div/ul/li"));

            List<string> uiCutomerlist = totalCustomerDropdownValues.Skip(1).Select(a => a.Text).Take(100).ToList();
            for (int i = 0; i < uiCutomerlist.Count; i++)
            {
                Report.WriteLine("Selecting Customer by Filtering out Station");
                if (dbCustomers.Contains(uiCutomerlist[i]))
                {
                    //Click(attributeName_id, "surge");
                    //Click(attributeName_xpath, CustomerSelection_DropdownBox_Xpath);
                    SelectDropdownValueFromList(attributeName_xpath, CustomerSelection_DropdownList_Xpath, uiCutomerlist[i]);
                    GlobalVariables.webDriver.WaitForPageLoad();
                    Thread.Sleep(2500);
                    string gridNoDataCheck = Gettext(attributeName_xpath, ".//*[@id='CustomerTable']/tbody/tr");
                    if (gridNoDataCheck != "No data available in table")
                    {
                        break;
                    }
                    else
                    {
                        Click(attributeName_xpath, CustomerSelection_DropdownBox_Xpath);
                    }
                }
            }
        }

        [Given(@"I have selected one or more(.*)")]
        public void GivenIHaveSelectedOneOrMore(string Carriers)
        {
            if (Carriers == "Single")
            {
                carriers = Carriers;
                IList<IWebElement> gridColumnHeaderNames = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='CustomerTable']/tbody/tr/td[2]"));
                for (int i = 1; i <= gridColumnHeaderNames.Count; i++)
                {
                    string checkNone = Gettext(attributeName_xpath, ".//*[@id='CustomerTable']/tbody/tr[" + i + "]/td[5]");
                    if (checkNone != "None")
                    {
                        Thread.Sleep(2000);
                        Click(attributeName_xpath, ".//*[@id='CustomerTable']/tbody/tr[" + i + "]/td[1]/div/label");
                        Report.WriteLine("One Carrier is selected");
                        firstCarrierRowCount = i;
                        break;
                    }
                }


            }
            else
            {
                carriers = Carriers;
                Thread.Sleep(2000);
                IList<IWebElement> gridCarrierList = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='CustomerTable']/tbody/tr/td[2]"));
                for (int i = 1; i <= gridCarrierList.Count; i++)
                {
                    string checkNone = Gettext(attributeName_xpath, ".//*[@id='CustomerTable']/tbody/tr[" + i + "]/td[5]");
                    if (checkNone != "None")
                    {
                        Click(attributeName_xpath, ".//*[@id='CustomerTable']/tbody/tr[" + i + "]/td[1]/div/label");
                        Report.WriteLine("First is selected");
                        firstCarrierRowCount = i;
                        for (int j = i + 1; j <= gridCarrierList.Count; j++)
                        {
                            string checkNone2 = Gettext(attributeName_xpath, ".//*[@id='CustomerTable']/tbody/tr[" + j + "]/td[5]");
                            if (checkNone2 != "None")
                            {
                                Click(attributeName_xpath, ".//*[@id='CustomerTable']/tbody/tr[" + j + "]/td[1]/div/label");
                                Report.WriteLine("2nd Carrier is selected");
                                secondCarrierRowCount = j;
                                i = gridCarrierList.Count + 1;
                                break;
                            }
                        }

                    }
                }
            }
        }

        [Given(@"I clicked on the Set Accessorials button")]
        public void GivenIClickedOnTheSetAccessorialsButton()
        {
            Click(attributeName_id, SetAccessorials_Button_Id);
            Report.WriteLine("Set accessorials button is been clicked");
        }

        [Given(@"the Set Individual Accessorials modal is displayed")]
        public void GivenTheSetIndividualAccessorialsModalIsDisplayed()
        {
            WaitForElementVisible(attributeName_xpath, SetIndividualAccessorials_ModalPopUp_Label_Xpath, "Set Individual Accessorials");
            Verifytext(attributeName_xpath, SetIndividualAccessorials_ModalPopUp_Label_Xpath, "Set Individual Accessorials");
        }

        [When(@"I click Select Accessorial Type dropdown")]
        public void WhenIClickSelectAccessorialTypeDropdown()
        {
            Thread.Sleep(2000);
            Click(attributeName_xpath, AccessorialType_Dropdown_Xpath);
            accessorialDropdownValues = GlobalVariables.webDriver.FindElements(By.XPath(AccessorialType_DropdownValues_Xpath));
            dropdownValueAccessorialValueUI = accessorialDropdownValues.Skip(1).Select(a => a.Text).ToList();
        }

        [Then(@"I will see Notification as one of the Accessorial in the Select Accessorial Type dropdown list")]
        public void ThenIWillSeeNotificationAsOneOfTheAccessorialInTheSelectAccessorialTypeDropdownList()
        {
            bool verifyNotificationAccessorialInDropdown = dropdownValueAccessorialValueUI.Any(a => a.Equals("Notification"));
            Assert.IsTrue(verifyNotificationAccessorialInDropdown);
        }

        [Then(@"the Notification Accessorial will be displayed alphabetically within the Select Accessorial Type dropdown list")]
        public void ThenTheNotificationAccessorialWillBeDisplayedAlphabeticallyWithinTheSelectAccessorialTypeDropdownList()
        {
            var orderedByAsc = dropdownValueAccessorialValueUI.OrderBy(a => a);
            if (dropdownValueAccessorialValueUI.SequenceEqual(orderedByAsc))
            {
                Console.WriteLine("Accessorials list is placed in Alphabetical Order");
            }
        }

        [Given(@"I clicked on the Add Another Accessorial button")]
        public void GivenIClickedOnTheAddAnotherAccessorialButton()
        {
            Click(attributeName_xpath, Add_AnotherAccessorial_Button_Xpath);
        }

        [When(@"I click the added additional Select Accessorial Type dropdown")]
        public void WhenIClickTheAddedAdditionalSelectAccessorialTypeDropdown()
        {
            Click(attributeName_xpath, SetAccessorial_type1_xpath);
            accessorialDropdownValues = GlobalVariables.webDriver.FindElements(By.XPath(AdditionaldropdownOne_Value_Xpath));
            dropdownValueAccessorialValueUI = accessorialDropdownValues.Skip(1).Select(a => a.Text).ToList();
        }

        [Then(@"I will see Notification as one of the Accessorial in the added additional Select Accessorial Type dropdown list")]
        public void ThenIWillSeeNotificationAsOneOfTheAccessorialInTheAddedAdditionalSelectAccessorialTypeDropdownList()
        {
            ThenIWillSeeNotificationAsOneOfTheAccessorialInTheSelectAccessorialTypeDropdownList();
        }

        [Then(@"the Notification Accessorial will be displayed alphabetically within the added additional Select Accessorial Type dropdown list")]
        public void ThenTheNotificationAccessorialWillBeDisplayedAlphabeticallyWithinTheAddedAdditionalSelectAccessorialTypeDropdownList()
        {
            ThenTheNotificationAccessorialWillBeDisplayedAlphabeticallyWithinTheSelectAccessorialTypeDropdownList();
        }

        [Given(@"I selected as Notification Accessorial from the Select Accessorial Type dropdown")]
        public void GivenISelectedAsNotificationAccessorialFromTheSelectAccessorialTypeDropdown()
        {
            Thread.Sleep(2000);
            Click(attributeName_xpath, AccessorialType_Dropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, AccessorialType_DropdownValues_Xpath, "Notification");
            Report.WriteLine("Notification is selected as Accessorial Type");
        }

        [Given(@"I entered valid data in Accessorial value field")]
        public void GivenIEnteredValidDataInAccessorialValueField()
        {
            double randomNumber = random.NextDouble();
            notificationValue = randomNumber.ToString("0.00");
            SendKeys(attributeName_id, SetGainshareFirst_TextBox_Id, notificationValue);
        }

        [Then(@"the Notification Accessorial will be displayed as one of the column in the grid")]
        public void ThenTheNotificationAccessorialWillBeDisplayedAsOneOfTheColumnInTheGrid()
        {
            Thread.Sleep(2000);
            IList<IWebElement> gridColumnHeaderNames = GlobalVariables.webDriver.FindElements(By.XPath(CarrierGridHeaderValues_Xpath));
            for (int i = 10; i <= gridColumnHeaderNames.Count; i++)
            {
                string headervalue = Gettext(attributeName_xpath, "//*[@id='CustomerTable_wrapper']/table/thead/tr/th[" + i + "]");
                if (headervalue == "NOTIFICATION")
                {
                    Report.WriteLine("Notification Accessorial is appeared in the grid");
                    iValue = i;
                    break;
                }

                else if ((i == gridColumnHeaderNames.Count) && (headervalue != "NOTIFICATION"))
                {
                    Assert.Fail("Notification Accessorial is not appeared in the grid");
                }
            }
        }

        [Then(@"the value will be displayed for each carrier selected in the grid")]
        public void ThenTheValueWillBeDisplayedForEachCarrierSelectedInTheGrid()
        {
            if (carriers == "Single")
            {
                Report.WriteLine("Verifying the Notification value for 1st Carrier");
                //string firstCarrierNotificationValue = Gettext(attributeName_xpath, ".//*[@id='CustomerTable']/tbody/tr[1]/td[" + iValue + "]");
                string firstCarrierNotificationValue = Gettext(attributeName_xpath, ".//*[@id='CustomerTable']/tbody/tr[" + firstCarrierRowCount + "]/td[" + iValue + "]");
                Assert.AreEqual("$" + notificationValue, firstCarrierNotificationValue);
            }
            else
            {
                Report.WriteLine("Verifying the Notification value for 1st Carrier");
                string firstCarrierNotificationValue = Gettext(attributeName_xpath, ".//*[@id='CustomerTable']/tbody/tr[" + firstCarrierRowCount + "]/ td[" + iValue + "]");
                Assert.AreEqual("$" + notificationValue, firstCarrierNotificationValue);

                Report.WriteLine("Verifying the Notification value for 2nd Carrier");
                string secondCarrierNotificationValue = Gettext(attributeName_xpath, ".//*[@id='CustomerTable']/tbody/tr[" + secondCarrierRowCount + "]/td[" + iValue + "]");
                Assert.AreEqual("$" + notificationValue, secondCarrierNotificationValue);
            }
        }

        [Given(@"I clicked on the Delete Accessorials button")]
        public void GivenIClickedOnTheDeleteAccessorialsButton()
        {
            Click(attributeName_id, DeleteAccessorialButton_Id);
        }

        [When(@"the Delete Individual Accessorials modal is displayed")]
        public void WhenTheDeleteIndividualAccessorialsModalIsDisplayed()
        {
            WaitForElementVisible(attributeName_xpath, DeleteAccessorialModalHeadertext_xpath, "Delete Individual Accessorials Modal");
        }

        [Then(@"I will see the Notification Accessorial is displayed in the Delete Individual Accessorial Modal Pop-Up")]
        public void ThenIWillSeeTheNotificationAccessorialIsDisplayedInTheDeleteIndividualAccessorialModalPop_Up()
        {
            VerifyElementPresent(attributeName_xpath, NotificationAccesssorialCheckbox_SetIndividualAccessorialsModalPopUp_Xpath, "Notification Accessorial");
        }

        [Given(@"I have selected Notification Accessorial from the Delete Individual Accessorials modal PopUp")]
        public void GivenIHaveSelectedNotificationAccessorialFromTheDeleteIndividualAccessorialsModalPopUp()
        {
            WaitForElementVisible(attributeName_xpath, DeleteAccessorialModalHeadertext_xpath, "Delete Individual Accessorials Modal");
            Click(attributeName_xpath, NotificationAccesssorialCheckbox_SetIndividualAccessorialsModalPopUp_Xpath);
        }

        [When(@"I click the Delete button")]
        public void WhenIClickTheDeleteButton()
        {
            Click(attributeName_id, DeleteAccessorialModalDeleteBtn_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Then(@"the value N/A will be displayed for the Notification Accessorial column in the grid for each selected Carrier")]
        public void ThenTheValueNAWillBeDisplayedForTheNotificationAccessorialColumnInTheGridForEachSelectedCarrier()
        {
            ThenTheNotificationAccessorialWillBeDisplayedAsOneOfTheColumnInTheGrid();
            if (carriers == "Single")
            {
                string firstCarrierNotificationAccessorialValue = Gettext(attributeName_xpath, ".//*[@id='CustomerTable']/tbody/tr[" + firstCarrierRowCount + "]/td[" + iValue + "]");
                Assert.AreEqual("N/A", firstCarrierNotificationAccessorialValue);
            }
            else
            {
                string firstCarrierNotificationAccessorialValue = Gettext(attributeName_xpath, ".//*[@id='CustomerTable']/tbody/tr[" + firstCarrierRowCount + "]/td[" + iValue + "]");
                Assert.AreEqual("N/A", firstCarrierNotificationAccessorialValue);

                string secondCarrierNotificationAccessorialValue = Gettext(attributeName_xpath, ".//*[@id='CustomerTable']/tbody/tr[" + secondCarrierRowCount + "]/td[" + iValue + "]");
                Assert.AreEqual("N/A", secondCarrierNotificationAccessorialValue);
            }
        }


        [Given(@"I have selected Customer with Notification Accessorial in Master Carrier Rate settings page")]
        public void GivenIHaveSelectedCustomerWithNotificationAccessorialInMasterCarrierRateSettingsPage()
        {
            GivenIHaveSelectedCustomerInMasterCarrierRateSettingsPage();
            GlobalVariables.webDriver.WaitForPageLoad();
            Thread.Sleep(3000);
            Click(attributeName_xpath, SelectAllCarrierFromGridCheckbox_Xpath);
            GivenIClickedOnTheSetAccessorialsButton();
            GivenISelectedAsNotificationAccessorialFromTheSelectAccessorialTypeDropdown();
            GivenIEnteredValidDataInAccessorialValueField();
            stepsFromMasterCarrierRateSettingsOverlengthAccessorialType.WhenIClickOnSaveButton();
            GlobalVariables.webDriver.WaitForPageLoad();
            Thread.Sleep(2000);
        }



        [Given(@"I have selected all Carriers")]
        public void GivenIHaveSelectedAllCarriers()
        {
            Click(attributeName_xpath, SelectAllCarrierFromGridCheckbox_Xpath);
        }

        [Then(@"the Notification Accessorial column will not be displayed in the grid for all the Carriers")]
        public void ThenTheNotificationAccessorialColumnWillNotBeDisplayedInTheGridForAllTheCarriers()
        {
            IList<IWebElement> gridColumnHeaderNames = GlobalVariables.webDriver.FindElements(By.XPath(CarrierGridHeaderValues_Xpath));
            bool verifyNotificationAccessorialHeaderColumn = !gridColumnHeaderNames.Where(a => a.Text == "Notification").Any();
            Assert.IsTrue(verifyNotificationAccessorialHeaderColumn);
        }
    }
}
