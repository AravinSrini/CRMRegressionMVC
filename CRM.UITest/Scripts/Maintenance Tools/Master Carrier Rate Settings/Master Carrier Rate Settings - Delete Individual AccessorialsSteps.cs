using CRM.UITest.CommonMethods;
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

namespace CRM.UITest.Scripts.Maintenance_Tools.Master_Carrier_Rate_Settings
{
    [Binding]
    public class Master_Carrier_Rate_Settings___Delete_Individual_AccessorialsSteps : MaintenaceTools
    {
        CommonMethodsCrm crm = new CommonMethodsCrm();

        [Given(@"I am System admin or Pricing Configuration User (.*) and (.*)")]
        public void GivenIAmSystemAdminOrPricingConfigurationUserAnd(string Username, string Password)
        {
            crm.LoginToCRMApplication(Username, Password);
        }


        [When(@"I am on the Master Carrier Rate Settings page")]
        public void WhenIAmOnTheMasterCarrierRateSettingsPage()
        {

            Click(attributeName_id, MaintenanceModule_id);
            GlobalVariables.webDriver.WaitForPageLoad();
            scrollpagedown();
            Report.WriteLine("Click on pricing button");

            Click(attributeName_id, "pricing");
            GlobalVariables.webDriver.WaitForPageLoad();


        }

        [When(@"I select (.*) from the Customer drop down list")]
        public void WhenISelectFromTheCustomerDropDownList(string Customer)
        {
            Report.WriteLine("Selecting " + Customer + " from All customers dropdown");
            Click(attributeName_id, IndividualCustomers_Id);
            SendKeys(attributeName_xpath, CustomerSelectionTextBox_xpath, Customer);
            Click(attributeName_xpath, IndividualCustomers_DropdownFirstValue_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();


        }

        [Then(@"Verify I should be able to see the Delete Accessorial button")]
        public void ThenVerifyIShouldBeAbleToSeeTheDeleteAccessorialButton()
        {
            VerifyElementPresent(attributeName_id, DeleteAccessorial_Button_Id, "Delete Accessorials");
        }

        [Then(@"I should not be able to see the Delete Accessorial button")]
        public void ThenIShouldNotBeAbleToSeeTheDeleteAccessorialButton()
        {
            DefineTimeOut(100000);
            VerifyElementNotVisible(attributeName_id, DeleteAccessorial_Button_Id, "Delete Accessorials");
        }

        [When(@"I select any one of the listed carriers from the grid")]
        public void WhenISelectAnyOneOfTheListedCarriersFromTheGrid()
        {


            Report.WriteLine("Verifying Carrier display on Master carrier rate settings page");
            IList<IWebElement> carriersUI = GlobalVariables.webDriver.FindElements(By.XPath(CustomerCarriersCount_xpath));
            string Gridtext = Gettext(attributeName_xpath, CustomerCarriersCount_xpath);
            int CarrierCount = carriersUI.Count();
            if (carriersUI.Count >= 1 && Gridtext != "No data available in table")
            {
                for (int i = 1; i <= CarrierCount; i++)
                {
                    if (carriersUI[i].Selected.ToString().Contains((ConsoleColor.Gray).ToString()))
                    {
                        Report.WriteLine("Carrier is deactivated in Grid ");
                    }
                    else
                    {
                        Report.WriteLine("Selected the Carrier from the Grid");
                        Click(attributeName_xpath, ".//*[@id='CustomerTable']//tbody/tr[" + i + "]//label");


                        break;
                    }


                }
            }
            else
            {
                Report.WriteLine("No Carriers Found");
            }


        }

        [Then(@"Verify the Delete Accessorial button is in Active state")]
        public void ThenVerifyTheDeleteAccessorialButtonIsInActiveState()
        {
            Report.WriteLine("Verifying Carrier display on Master carrier rate settings page");
            IList<IWebElement> carriersUI = GlobalVariables.webDriver.FindElements(By.XPath(CustomerCarriersCount_xpath));
            string Gridtext = Gettext(attributeName_xpath, CustomerCarriersCount_xpath);
            int CarrierCount = carriersUI.Count();
            if (carriersUI.Count >= 1 && Gridtext != "No data available in table")
            {
                VerifyElementEnabled(attributeName_id, DeleteAccessorial_Button_Id, "Delete Accessorials");
            }
            else
            {
                Report.WriteLine("No Carriers Found");
            }
        }

        [Then(@"Verify the Delete Accessorial button is in InActive State")]
        public void ThenVerifyTheDeleteAccessorialButtonIsInInActiveState()
        {
            VerifyElementNotEnabled(attributeName_id, DeleteAccessorial_Button_Id, "Delete Accessorials");
        }

        [Then(@"I can see the Delete Accessorial modal with the associated accessorials of the single carrier")]
        public void ThenICanSeeTheDeleteAccessorialModalWithTheAssociatedAccessorialsOfTheSingleCarrier()
        {

            Report.WriteLine("Verifying Carrier display on Master carrier rate settings page");
            IList<IWebElement> CarrierRow = GlobalVariables.webDriver.FindElements(By.XPath(CustomerCarriersCount_xpath));
            string Gridtext = Gettext(attributeName_xpath, CustomerCarriersCount_xpath);
            int CarrierCount = CarrierRow.Count();

            if (CarrierRow.Count >= 1 && Gridtext != "No data available in table")
            {
                
                Report.WriteLine("Verifying Carrier display on Master carrier rate settings page");
                IList<IWebElement> ColumnName = GlobalVariables.webDriver.FindElements(By.XPath(CustomerColumnCount_xpath));
                List<string> CarrierList = new List<string>();
                if (ColumnName.Count >= 10)
                {
                    int i;
                    for (i = 1; i <= ColumnName.Count; i++)
                    {
                        if (i >= 10)
                        {

                            string gg = Gettext(attributeName_xpath, ".//*[@id='CustomerTable']/thead/tr/th[" + i + "]");
                            CarrierList.Add((gg));

                        }
                    }

                    Click(attributeName_id, DeleteAccessorial_Button_Id);

                    IList<IWebElement> AccessCount = GlobalVariables.webDriver.FindElements(By.XPath(AccessorialsCount_xpath));
                    List<string> accList = new List<string>();
                    for (int j = 1; j <= AccessCount.Count; j++)
                    {

                        string tt = Gettext(attributeName_xpath, ".//*[@id='modelDeleteAccessorial']//div[" + j + "]/label");
                        accList.Add((tt));

                    }

                    if (CarrierList.Count.Equals(accList.Count))
                    {
                        for (int k = 0; k < CarrierList.Count; k++)
                        {
                            if (CarrierList[k] == accList[k].ToUpper())
                            {
                                Report.WriteLine("Accessorials displayed in the DeleteAccessorials modal matches with the associated accessorials for the single selected carrier");

                            }
                            else
                            {
                                Report.WriteLine("Accessorials displayed in the DeleteAccessorials modal matches with the associated accessorials for the single selected carrier");

                            }

                        }

                    }
                    else
                    {
                        Report.WriteLine("Accessorials count does not match");
                        Assert.Fail();
                    }
                }else
                {
                    Report.WriteLine("Carrier do not have the accessorials");
                }
            }
            else
            {
                Report.WriteLine("No Carriers Found");
            }


        }

        [When(@"I select multiple carriers of the listed carriers from the grid")]
        public void WhenISelectMultipleCarriersOfTheListedCarriersFromTheGrid()
        {
            Report.WriteLine("Verifying Carrier display on Master carrier rate settings page");
            IList<IWebElement> carriersUI = GlobalVariables.webDriver.FindElements(By.XPath(CustomerCarriersCount_xpath));
            string Gridtext = Gettext(attributeName_xpath, CustomerCarriersCount_xpath);
            int CarrierCount = carriersUI.Count();
            if (carriersUI.Count >= 1 && Gridtext != "No data available in table")
            {
                for (int i = 1; i <= CarrierCount; i++)
                {
                    if (carriersUI[i].Selected.ToString().Contains((ConsoleColor.Gray).ToString()))
                    {
                        Report.WriteLine("Carrier is deactivated in Grid ");
                    }
                    else
                    {
                        Report.WriteLine("Selected the Carrier from the Grid");
                        Click(attributeName_xpath, ".//*[@id='CustomerTable']//tbody/tr[" + i + "]//label");


                        if (i == 3)
                        {

                            break;
                        }
                    }


                }
            }
            else
            {
                Report.WriteLine("No Carriers Found");
            }
        }


        [Then(@"I can be able to see the Delete Accessorial modal with the associated accessorials for multiple carrier")]
        public void ThenICanBeAbleToSeeTheDeleteAccessorialModalWithTheAssociatedAccessorialsForMultipleCarrier()
        {
            Report.WriteLine("Verifying Carrier display on Master carrier rate settings page");
            IList<IWebElement> CarrierRow = GlobalVariables.webDriver.FindElements(By.XPath(CustomerCarriersCount_xpath));
            string Gridtext = Gettext(attributeName_xpath, CustomerCarriersCount_xpath);
            int CarrierCount = CarrierRow.Count();

            if (CarrierRow.Count >= 1 && Gridtext != "No data available in table")
            {

                Report.WriteLine("Verifying Carrier display on Master carrier rate settings page");
                IList<IWebElement> ColumnName = GlobalVariables.webDriver.FindElements(By.XPath(CustomerColumnCount_xpath));
                string rowtext = Gettext(attributeName_xpath, CustomerCarriersCount_xpath);


                if (ColumnName.Count >= 10)
                {
                    List<string> CarrierList = new List<string>();
                    for (int i = 1; i <= ColumnName.Count; i++)
                    {
                        if (i >= 10)
                        {

                            string gg = Gettext(attributeName_xpath, ".//*[@id='CustomerTable']/thead/tr/th[" + i + "]");
                            CarrierList.Add((gg));

                        }
                    }

                    Click(attributeName_id, DeleteAccessorial_Button_Id);

                    IList<IWebElement> Access = GlobalVariables.webDriver.FindElements(By.XPath(AccessorialsCount_xpath));
                    List<string> accList = new List<string>();
                    for (int j = 1; j <= Access.Count; j++)
                    {

                        string tt = Gettext(attributeName_xpath, ".//*[@id='modelDeleteAccessorial']//div[" + j + "]/label");
                        accList.Add((tt));

                    }

                    if (CarrierList.Count.Equals(accList.Count))
                    {
                        for (int k = 0; k < CarrierList.Count; k++)
                        {
                            if (CarrierList[k] == accList[k].ToUpper())
                            {
                                Report.WriteLine("Accessorials displayed in the DeleteAccessorials modal matches with the associated accessorials for the single selected carrier");

                            }
                            else
                            {
                                Report.WriteLine("Accessorials displayed in the DeleteAccessorials modal matches with the associated accessorials for the single selected carrier");

                            }

                        }

                    }
                    else
                    {
                        Report.WriteLine("Accessorials count does not match");
                        Assert.Fail();
                    }

                }
                else
                {
                    Report.WriteLine("Carrier do not have the accessorials");
                }
            }

            else
            {
                Report.WriteLine("No Carriers Found");
            }



        }


        [When(@"I select any carrier which does not have accessorials")]
        public void WhenISelectAnyCarrierWhichDoesNotHaveAccessorials()
        {
            Report.WriteLine("Verifying Carrier display on Master carrier rate settings page");
            IList<IWebElement> carriersUI = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='CustomerTable']/tbody/tr"));
            string Gridtext = Gettext(attributeName_xpath, ".//*[@id='CustomerTable']/tbody/tr");
            int CarrierCount = carriersUI.Count();
            if (carriersUI.Count >= 1 && Gridtext != "No data available in table")
            {
                for (int i = 1; i <= CarrierCount; i++)
                {
                    if (carriersUI[i].Selected.ToString().Contains((ConsoleColor.Gray).ToString()))
                    {
                        Report.WriteLine("Carrier is deactivated in Grid ");
                    }
                    else
                    {


                        Report.WriteLine("Selected the Carrier from the Grid");
                        Click(attributeName_xpath, ".//*[@id='CustomerTable']//tbody/tr[" + i + "]//label");

                        break;

                    }


                }
            }
            else
            {
                Report.WriteLine("No Carriers Found");
            }
        }


        [Then(@"I should see message (.*) for the carrier selected which does not have any individual accessorials")]
        public void ThenIShouldSeeMessageForTheCarrierSelectedWhichDoesNotHaveAnyIndividualAccessorials(string ErrorMessage)
        {
            Report.WriteLine("Verifying Carrier display on Master carrier rate settings page");
            IList<IWebElement> carriersUI = GlobalVariables.webDriver.FindElements(By.XPath(CustomerCarriersCount_xpath));
            string Gridtext = Gettext(attributeName_xpath, CustomerCarriersCount_xpath);
            int CarrierCount = carriersUI.Count();
            if (carriersUI.Count >= 1 && Gridtext != "No data available in table")
            {
                Report.WriteLine("Verifying Carrier display on Master carrier rate settings page");
                IList<IWebElement> ColumnName = GlobalVariables.webDriver.FindElements(By.XPath(CustomerColumnCount_xpath));
                List<string> CarrierList = new List<string>();
                if (ColumnName.Count >= 10)
                {
                    Report.WriteLine("Selected carrier contains the accessorials");
                    WaitForElementVisible(attributeName_xpath, DeleteAccessorialModalHeadertext_xpath, "Delete Individual Accessorials");
                }
                else
                {
                    Report.WriteLine("Selected carrier does not contains accessorials");
                    WaitForElementVisible(attributeName_xpath, NoAccessorialError_xpath, "Error");
                    Verifytext(attributeName_xpath, NoAccessorialError_xpath, "Error");
                    string errorVerbiage = Gettext(attributeName_xpath, NoAccessorialErrorVerbiage_xpath);
                    Assert.AreEqual(errorVerbiage, ErrorMessage);

                }
            }
            else
            {
                Report.WriteLine("No Carriers Found");
            }



            
           
           // Verifytext(attributeName_xpath, NoAccessorialErrorVerbiage_xpath, "The carrier(s) selected do not have any individual accessorials");
           

        }

        [When(@"I Click on the Delete Accessorials button")]
        public void WhenIClickOnTheDeleteAccessorialsButton()
        {
            Report.WriteLine("Verifying Carrier display on Master carrier rate settings page");
            IList<IWebElement> carriersUI = GlobalVariables.webDriver.FindElements(By.XPath(CustomerCarriersCount_xpath));
            string Gridtext = Gettext(attributeName_xpath, CustomerCarriersCount_xpath);
            int CarrierCount = carriersUI.Count();
            if (carriersUI.Count >= 1 && Gridtext != "No data available in table")
            {
                Report.WriteLine("Verifying Carrier display on Master carrier rate settings page");
                IList<IWebElement> ColumnName = GlobalVariables.webDriver.FindElements(By.XPath(CustomerColumnCount_xpath));
                List<string> CarrierList = new List<string>();
                if (ColumnName.Count >= 10)
                {
                    Report.WriteLine("Selected carrier contains accessorials");
                    Click(attributeName_id, DeleteAccessorial_Button_Id);
                    WaitForElementVisible(attributeName_xpath, DeleteAccessorialModalHeadertext_xpath, "Delete Individual Accessorials");
                }
                else
                {
                    Report.WriteLine("Selected carrier does not contains accessorials");
                    Click(attributeName_id, DeleteAccessorial_Button_Id);
                    WaitForElementVisible(attributeName_xpath, NoAccessorialError_xpath, "Error");

                }
            }
            else
            {
                Report.WriteLine("No Carriers Found");
            }



            //Click(attributeName_id, DeleteAccessorial_Button_Id);
            //WaitForElementVisible(attributeName_xpath, DeleteAccessorialModalHeadertext_xpath, "Delete Individual Accessorials");


        }


        [When(@"I Click on the Delete Accessorials button for no accessorials")]
        public void WhenIClickOnTheDeleteAccessorialsButtonForNoAccessorials()
        {
            Report.WriteLine("Verifying Carrier display on Master carrier rate settings page");
            IList<IWebElement> carriersUI = GlobalVariables.webDriver.FindElements(By.XPath(CustomerCarriersCount_xpath));
            string Gridtext = Gettext(attributeName_xpath, CustomerCarriersCount_xpath);
            int CarrierCount = carriersUI.Count();
            if (carriersUI.Count >= 1 && Gridtext != "No data available in table")
            {
                Report.WriteLine("Verifying Carrier display on Master carrier rate settings page");
                IList<IWebElement> ColumnName = GlobalVariables.webDriver.FindElements(By.XPath(CustomerColumnCount_xpath));
                List<string> CarrierList = new List<string>();
                if (ColumnName.Count >= 10)
                {
                    Report.WriteLine("Selected carrier contains accessorials");
                    Click(attributeName_id, DeleteAccessorial_Button_Id);
                    WaitForElementVisible(attributeName_xpath, DeleteAccessorialModalHeadertext_xpath, "Delete Individual Accessorials");
                }
                else
                {
                    Report.WriteLine("Selected carrier does not contains accessorials");
                    Click(attributeName_id, DeleteAccessorial_Button_Id);
                    WaitForElementVisible(attributeName_xpath, NoAccessorialError_xpath, "Error");
                   
                }
            }
            else
            {
                Report.WriteLine("No Carriers Found");
            }
        }




        [When(@"when I acknowledge the error message")]
        public void WhenWhenIAcknowledgeTheErrorMessage()
        {
            Report.WriteLine("Verifying Carrier display on Master carrier rate settings page");
            IList<IWebElement> carriersUI = GlobalVariables.webDriver.FindElements(By.XPath(CustomerCarriersCount_xpath));
            string Gridtext = Gettext(attributeName_xpath, CustomerCarriersCount_xpath);
            int CarrierCount = carriersUI.Count();
            if (carriersUI.Count >= 1 && Gridtext != "No data available in table")
            {
                Report.WriteLine("Verifying Carrier display on Master carrier rate settings page");
                IList<IWebElement> ColumnName = GlobalVariables.webDriver.FindElements(By.XPath(CustomerColumnCount_xpath));
                List<string> CarrierList = new List<string>();
                if (ColumnName.Count >= 10)
                {
                    Report.WriteLine("Selected carrier contains accessorials");
                    WaitForElementVisible(attributeName_xpath, DeleteAccessorialModalHeadertext_xpath, "Delete Individual Accessorials");
                    Click(attributeName_xpath, DeleteAccessorialModalCancelBtn_xpath);
                }
                else
                {
                    Report.WriteLine("Selected carrier does not contains accessorials");                    
                    WaitForElementVisible(attributeName_xpath, NoAccessorialError_xpath, "Error");
                    Click(attributeName_xpath, NoAccessorialErrorClose_xpath);

                }
            }
            else
            {
                Report.WriteLine("No Carriers Found");
            }
 
            
        }

        [Then(@"I should be navigated to the Master Carrier Rate Settings page (.*)")]
        public void ThenIShouldBeNavigatedToTheMasterCarrierRateSettingsPage(string PageHeaderText)
        {
            WaitForElementVisible(attributeName_xpath, MasterCarrierRateSettingsPageHeaderText_xpath, PageHeaderText);
            Verifytext(attributeName_xpath, MasterCarrierRateSettingsPageHeaderText_xpath, PageHeaderText);
        }



        [Then(@"Delete Accessorial modal should be displayed (.*)")]
        public void ThenDeleteAccessorialModalShouldBeDisplayed(string DeleteAccessorialHeaderText)
        {
            WaitForElementVisible(attributeName_xpath, DeleteAccessorialModalHeadertext_xpath, DeleteAccessorialHeaderText);
            Verifytext(attributeName_xpath, DeleteAccessorialModalHeadertext_xpath, DeleteAccessorialHeaderText);
        }

        [Then(@"I can see the verbiage instructing to select the accessorials (.*)")]
        public void ThenICanSeeTheVerbiageInstructingToSelectTheAccessorials(string Verbiage)
        {
            Verifytext(attributeName_xpath, DeleteAccessorialModalVerbiage_xpath, Verbiage);
        }


        [Then(@"I should see the Cancel and Delete button")]
        public void ThenIShouldSeeTheCancelAndDeleteButton()
        {
            Verifytext(attributeName_xpath, DeleteAccessorialModalCancelBtn_xpath, "Cancel");
            Verifytext(attributeName_id, DeleteAccessorialModalDeleteBtn_Id, "Delete");
        }


        [When(@"I click on the Set Accessorial button to add the accessorials more than five (.*),(.*),(.*),(.*),(.*),(.*)")]
        public void WhenIClickOnTheSetAccessorialButtonToAddTheAccessorialsMoreThanFive(string Accessorial1, string Accessorial2, string Accessorial3, string Accessorial4, string Accessorial5, string Accessorial6)
        {
            Report.WriteLine("Click on Set Accessorial");
            WaitForElementVisible(attributeName_id, SetAccessorial_Button_Id, "Set Accessorial");
            Click(attributeName_id, SetAccessorial_Button_Id);

            WaitForElementVisible(attributeName_xpath, SetAccessorialType_Xpath, "Set Accessorial");
            Click(attributeName_xpath, SetAccessorialType_Xpath);

            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(SetAccessorialFirst_xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == Accessorial1)
                {
                    DropDownList[i].Click();
                    break;
                }
            }

            SendKeys(attributeName_id, SetAccessorialFirstValue_Id, "5");

            Click(attributeName_xpath, SetAccessorialAddAdditionalAccessorialButton_xpath);

            Click(attributeName_xpath, SetAccessorial_type1_xpath);
            IList<IWebElement> DropDownList1 = GlobalVariables.webDriver.FindElements(By.XPath(SetAccessorialSecond_xpath));
            int DropDownCount1 = DropDownList1.Count;
            for (int i = 0; i < DropDownCount1; i++)
            {
                if (DropDownList1[i].Text == Accessorial2)
                {
                    DropDownList1[i].Click();
                    break;
                }
            }
            SendKeys(attributeName_id, SetAccessorialSecondValue_Id, "6");

            Click(attributeName_xpath, SetAccessorialAddAdditionalAccessorialButton_xpath);

            Click(attributeName_xpath, SetAccessorial_type2_xpath);
            IList<IWebElement> DropDownList2 = GlobalVariables.webDriver.FindElements(By.XPath(SetAccessorialThird_xpath));
            int DropDownCount2 = DropDownList2.Count;
            for (int i = 0; i < DropDownCount2; i++)
            {
                if (DropDownList2[i].Text == Accessorial3)
                {
                    DropDownList2[i].Click();
                    break;
                }
            }
            SendKeys(attributeName_id, SetAccessorialThirdValue_Id, "7");


            Click(attributeName_xpath, SetAccessorialAddAdditionalAccessorialButton_xpath);

            Click(attributeName_xpath, SetAccessorial_type3_xpath);
            IList<IWebElement> DropDownList3 = GlobalVariables.webDriver.FindElements(By.XPath(SetAccessorialFourth_xpath));
            int DropDownCount3 = DropDownList3.Count;
            for (int i = 0; i < DropDownCount3; i++)
            {
                if (DropDownList3[i].Text == Accessorial4)
                {
                    DropDownList3[i].Click();
                    break;
                }
            }
            SendKeys(attributeName_id, SetAccessorialFourthValue_Id, "8");

            Click(attributeName_xpath, SetAccessorialAddAdditionalAccessorialButton_xpath);

            Click(attributeName_xpath, SetAccessorial_type4_xpath);
            IList<IWebElement> DropDownList4 = GlobalVariables.webDriver.FindElements(By.XPath(SetAccessorialFive_xpath));
            int DropDownCount4 = DropDownList4.Count;
            for (int i = 0; i < DropDownCount4; i++)
            {
                if (DropDownList4[i].Text == Accessorial5)
                {
                    DropDownList4[i].Click();
                    break;
                }
            }
            SendKeys(attributeName_id, SetAccessorialFiveValue_Id, "9");

            Click(attributeName_xpath, SetAccessorialAddAdditionalAccessorialButton_xpath);

            Click(attributeName_xpath, SetAccessorial_type5_xpath);
            IList<IWebElement> DropDownList5 = GlobalVariables.webDriver.FindElements(By.XPath(SetAccessorialSix_xpath));
            int DropDownCount5 = DropDownList5.Count;
            for (int i = 0; i < DropDownCount5; i++)
            {
                if (DropDownList5[i].Text == Accessorial6)
                {
                    DropDownList5[i].Click();
                    break;
                }
            }
            SendKeys(attributeName_id, SetAccessorialSixValue_Id, "10");

            Click(attributeName_id, SetAccessorials_SaveButton_Id);
            WaitForElementVisible(attributeName_xpath, MasterCarrierRateSettingsPageHeaderText_xpath, "Master Carrier Rate settings");


        }




        [Then(@"I should see the scroll bar when accessorials is more than five")]
        public void ThenIShouldSeeTheScrollBarWhenAccessorialsIsMoreThanFive()
        {
            WaitForElementVisible(attributeName_xpath, DeleteAccessorialModalHeadertext_xpath, "Delete Individual Accessorials");
            VerifyElementPresent(attributeName_xpath, DeleteAccessorialScrollbar_xpath, "ScrollBar");
        }


        [Then(@"Verify the Cancel button functionality")]
        public void ThenVerifyTheCancelButtonFunctionality()
        {

            Report.WriteLine("Verifying Carrier display on Master carrier rate settings page");
            IList<IWebElement> carriersUI = GlobalVariables.webDriver.FindElements(By.XPath(CustomerColumnCount_xpath));
            string Gridtext = Gettext(attributeName_xpath, CustomerCarriersCount_xpath);
            if (carriersUI.Count >= 1 && Gridtext != "No data available in table")
            {
                Report.WriteLine("Verifying Carrier display on Master carrier rate settings page");
                IList<IWebElement> ColumnName = GlobalVariables.webDriver.FindElements(By.XPath(CustomerColumnCount_xpath));
                
                if (ColumnName.Count >= 10)
                {
                    Report.WriteLine("Selected carrier contians accessorials");
                    List<string> CarrierList = new List<string>();
                    int i;
                    for (i = 1; i <= carriersUI.Count; i++)
                    {
                        if (i >= 10)
                        {

                            string gg = Gettext(attributeName_xpath, ".//*[@id='CustomerTable']/thead/tr/th[" + i + "]");
                            CarrierList.Add((gg));

                        }
                    }

                    Click(attributeName_id, DeleteAccessorial_Button_Id);
                    WaitForElementVisible(attributeName_xpath, DeleteAccessorialModalHeadertext_xpath, "Delete Individual Accessorials");

                    Click(attributeName_xpath, DeleteAccessorialFirstCheckbox_xpath);
                    Click(attributeName_xpath, DeleteAccessorialModalCancelBtn_xpath);
                    WaitForElementVisible(attributeName_xpath, MasterCarrierRateSettingsPageHeaderText_xpath, "Master carrier Rate settings page");

                    String Access = Gettext(attributeName_xpath, CustomerAccessorialFirstCol_xpath);
                    if (CarrierList[0].Equals(Access))
                    {
                        Report.WriteLine("Cancel functionality is working and no changes saved for the accessorials");
                    }
                    else
                    {
                        Report.WriteLine("Cancel functionality is not working and deleted accessorials are saved");
                        Assert.Fail();
                    }
                }
                else
                {
                    Report.WriteLine("Selected carrier does not contians accessorials");

                }
            }
            else
            {
                Report.WriteLine("No Carriers Found");
            }

        }


        [When(@"I click on the Set Accessorial button and add the accessorials (.*),(.*),(.*),(.*)")]
        public void WhenIClickOnTheSetAccessorialButtonAndAddTheAccessorials(string Accessorial1, string Accessorial2, string Accessorial3, string Accessorial4)
        {
            Report.WriteLine("Click on Set Accessorial");
            WaitForElementVisible(attributeName_id, SetAccessorial_Button_Id, "Set Accessorial");
            Click(attributeName_id, SetAccessorial_Button_Id);

            WaitForElementVisible(attributeName_xpath, SetAccessorialType_Xpath, "Set Accessorial");
            Click(attributeName_xpath, SetAccessorialType_Xpath);

            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(SetAccessorialFirst_xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == Accessorial1)
                {
                    DropDownList[i].Click();
                    break;
                }
            }

            SendKeys(attributeName_id, SetAccessorialFirstValue_Id, "5");

            Click(attributeName_xpath, SetAccessorialAddAdditionalAccessorialButton_xpath);

            Click(attributeName_xpath, SetAccessorial_type1_xpath);
            IList<IWebElement> DropDownList1 = GlobalVariables.webDriver.FindElements(By.XPath(SetAccessorialSecond_xpath));
            int DropDownCount1 = DropDownList1.Count;
            for (int i = 0; i < DropDownCount1; i++)
            {
                if (DropDownList1[i].Text == Accessorial2)
                {
                    DropDownList1[i].Click();
                    break;
                }
            }
            SendKeys(attributeName_id, SetAccessorialSecondValue_Id, "6");

            Click(attributeName_xpath, SetAccessorialAddAdditionalAccessorialButton_xpath);

            Click(attributeName_xpath, SetAccessorial_type2_xpath);
            IList<IWebElement> DropDownList2 = GlobalVariables.webDriver.FindElements(By.XPath(SetAccessorialThird_xpath));
            int DropDownCount2 = DropDownList2.Count;
            for (int i = 0; i < DropDownCount2; i++)
            {
                if (DropDownList2[i].Text == Accessorial3)
                {
                    DropDownList2[i].Click();
                    break;
                }
            }
            SendKeys(attributeName_id, SetAccessorialThirdValue_Id, "7");


            Click(attributeName_xpath, SetAccessorialAddAdditionalAccessorialButton_xpath);

            Click(attributeName_xpath, SetAccessorial_type3_xpath);
            IList<IWebElement> DropDownList3 = GlobalVariables.webDriver.FindElements(By.XPath(SetAccessorialFourth_xpath));
            int DropDownCount3 = DropDownList3.Count;
            for (int i = 0; i < DropDownCount3; i++)
            {
                if (DropDownList3[i].Text == Accessorial4)
                {
                    DropDownList3[i].Click();
                    break;
                }
            }
            SendKeys(attributeName_id, SetAccessorialFourthValue_Id, "8");

            Click(attributeName_id, SetAccessorials_SaveButton_Id);
            WaitForElementVisible(attributeName_xpath, MasterCarrierRateSettingsPageHeaderText_xpath, "Master Carrier Rate settings");
            WaitForElementNotPresent(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div[3]/span", "Please Wait Saving Updated Carrier Details to Database.");

        }



        [Then(@"I should not be able to see the Deleted accessorials in the grid and it should display NA for the deleted accessorials of the selected carriers")]
        public void ThenIShouldNotBeAbleToSeeTheDeletedAccessorialsInTheGridAndItShouldDisplayNAForTheDeletedAccessorialsOfTheSelectedCarriers()
        {
            Report.WriteLine("Verifying Carrier display on Master carrier rate settings page");
            IList<IWebElement> carriersUI = GlobalVariables.webDriver.FindElements(By.XPath(CustomerColumnCount_xpath));
            string Gridtext = Gettext(attributeName_xpath, CustomerCarriersCount_xpath);
            if (carriersUI.Count >= 1 && Gridtext != "No data available in table")
            {
                Report.WriteLine("Verifying Carrier display on Master carrier rate settings page");
                IList<IWebElement> ColumnName = GlobalVariables.webDriver.FindElements(By.XPath(CustomerColumnCount_xpath));

                if (ColumnName.Count >= 10)
                {
                    Report.WriteLine("Selected carrier contians accessorials");
                    List<string> CarrierList = new List<string>();

                    for (int i = 1; i <= carriersUI.Count; i++)
                    {
                        if (i >= 10)
                        {

                            string gg = Gettext(attributeName_xpath, ".//*[@id='CustomerTable']/thead/tr/th[" + i + "]");
                            CarrierList.Add((gg));

                        }
                    }

                    Click(attributeName_id, DeleteAccessorial_Button_Id);
                    WaitForElementVisible(attributeName_xpath, DeleteAccessorialModalHeadertext_xpath, "Delete Individual Accessorials");


                    Click(attributeName_xpath, DeleteAccessorialFirstCheckbox_xpath);
                    Click(attributeName_id, DeleteAccessorialModalDeleteBtn_Id);

                    WaitForElementVisible(attributeName_xpath, MasterCarrierRateSettingsPageHeaderText_xpath, "Master Carrier Rate settings");
                    String Access = Gettext(attributeName_xpath, CustomerAccessorialFirstCol_xpath);
                    if (CarrierList[0] != Access.ToUpper())
                    {
                        Report.WriteLine("Delete functionality is working and changes saved for the accessorials");

                    }
                    else
                    {
                        Report.WriteLine("Delete functionality is not working and deleted accessorials are not saved");
                        Assert.Fail();
                    }
                }
                else
                {
                    Report.WriteLine("Selected carrier does not contians accessorials");
                }
            }
            else
            {
                Report.WriteLine("No Carriers Found");
            }
        }


        [When(@"I select all the carriers in the list")]
        public void WhenISelectAllTheCarriersInTheList()
        {
           
            Report.WriteLine("Verifying Carrier display on Master carrier rate settings page");
            IList<IWebElement> carriersUI = GlobalVariables.webDriver.FindElements(By.XPath(CustomerCarriersCount_xpath));
            string Gridtext = Gettext(attributeName_xpath, CustomerCarriersCount_xpath);
            int CarrierCount = carriersUI.Count();
            if (carriersUI.Count >= 1 && Gridtext != "No data available in table")
            {
                Click(attributeName_xpath, AllCarrierSelect_Xpath);
                Thread.Sleep(3000);
            } else
            {
                Report.WriteLine("No Carrier Records available in the table");
            }
        }



        [Then(@"no individual accessorials will be displayed in the refreshed grid when I delete all the individual accessorials")]
        public void ThenNoIndividualAccessorialsWillBeDisplayedInTheRefreshedGridWhenIDeleteAllTheIndividualAccessorials()
        {
                
            Report.WriteLine("Verifying Carrier display on Master carrier rate settings page");
            IList<IWebElement> carriersUI = GlobalVariables.webDriver.FindElements(By.XPath(CustomerColumnCount_xpath));
            string Gridtext = Gettext(attributeName_xpath, CustomerCarriersCount_xpath);
            if (carriersUI.Count >= 1 && Gridtext != "No data available in table")
            {
                Report.WriteLine("Verifying Carrier display on Master carrier rate settings page");
                IList<IWebElement> ColumnName = GlobalVariables.webDriver.FindElements(By.XPath(CustomerColumnCount_xpath));

                if (ColumnName.Count >= 10)
                {


                    Report.WriteLine("Selected carrier contians accessorials");
                    List<string> CarrierList = new List<string>();
                    int i;
                    for (i = 1; i <= carriersUI.Count; i++)
                    {
                        if (i >= 10)
                        {

                            string gg = Gettext(attributeName_xpath, ".//*[@id='CustomerTable']/thead/tr/th[" + i + "]");
                            CarrierList.Add((gg));

                        }
                    }

                    Click(attributeName_id, DeleteAccessorial_Button_Id);
                    WaitForElementVisible(attributeName_xpath, DeleteAccessorialModalHeadertext_xpath, "Delete Individual Accessorials");

                    IList<IWebElement> Access = GlobalVariables.webDriver.FindElements(By.XPath(AccessorialsCount_xpath));
                    List<string> accList = new List<string>();
                    for (int j = 1; j <= Access.Count; j++)
                    {

                        string tt = Gettext(attributeName_xpath, ".//*[@id='modelDeleteAccessorial']//div[" + j + "]/label");
                        accList.Add((tt));

                    }

                    if (CarrierList.Count.Equals(accList.Count))
                    {
                        for (int k = 0; k < CarrierList.Count; k++)
                        {
                            if (CarrierList[k] == accList[k].ToUpper())
                            {
                                int l = k + 1;
                                Report.WriteLine("Accessorials displayed in the DeleteAccessorials modal matches with the associated accessorials for the single selected carrier");
                                Click(attributeName_xpath, ".//*[@id='modelDeleteAccessorial']//div[" + l + "]/label");
                            }
                            else
                            {
                                Report.WriteLine("Accessorials displayed in the DeleteAccessorials modal matches with the associated accessorials for the single selected carrier");

                            }

                        }

                        Click(attributeName_id, "btnModelDeleteAccessorial");
                        WaitForElementNotPresent(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div[3]/span", "Please Wait Deleting Carrier Details from Database.");


                        IList<IWebElement> carriersUIAfterDelete = GlobalVariables.webDriver.FindElements(By.XPath(CustomerColumnCount_xpath));

                        if (carriersUIAfterDelete.Count > 9)
                        {
                            Report.WriteLine("Deleting all the accessorials did not work");
                            Assert.Fail();
                        }
                        else
                        {
                            Report.WriteLine("Deleted all the Accessorials for the carriers");
                        }



                    }
                    else
                    {
                        Report.WriteLine("Accessorials count does not match");
                    }


                }
                else
                {
                    Report.WriteLine("Selected carrier does not contians accessorials");

                }
            }

            else
            {
                Report.WriteLine("No Carriers Found");
            }
        }

    

      


    }
}
