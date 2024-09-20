using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using System.Linq;
using OpenQA.Selenium;
using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;
using System.Configuration;
using CRM.UITest.Entities;
using CRM.UITest.Helper.ViewModel;
using System.Threading;

namespace CRM.UITest.Scripts.Maintenance_Tools.Configure_Accessorials
{
    [Binding]
    public class MaintenanceTools_ConfigureAccessorials_AddSteps : ConfigureAccessorial
    {
        string testDataWith100Characters = "abcdefghijklmnopqrstuvwxyz123451234512345123451234512345123451234512345!@#$%^&*()_-+={[}]|:;<?>./12345123451234512345";

        string accessorialName = "VasAc" + Guid.NewGuid().ToString();
        string accessorialServiceCode = "VasServiceCode" + Guid.NewGuid().ToString();
        string accessorialMGDescription = "VasMGDescription" + Guid.NewGuid().ToString();
        string accessorialAdditionalMGDescription = "VasadditionalMGDescription" + Guid.NewGuid().ToString();
        string accessorialServiceType1 = "LTL";
        string accessorialServiceType2 = "Truckload";
        string accessorialDirection = "Ship To";
        int mgDescriptionCount;
        int serviceTypeCount;
        List<string> totalMGDescription = new List<string>();
        List<string> totalService = new List<string>();

        //[Given(@"that I am a Config Manager user")]
        //public void GivenThatIAmAConfigManagerUser()
        //{



        //    string username = ConfigurationManager.AppSettings["username-SystemAdmin"].ToString();
        //    string password = ConfigurationManager.AppSettings["password-SystemAdmin"].ToString();
        //    CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
        //    CrmLogin.LoginToCRMApplication(username, password);
        //}

        //[Given(@"I am on the Maintenance Tools page")]
        //public void GivenIAmOnTheMaintenanceToolsPage()
        //{
        //    Click(attributeName_xpath, MaintenanceTools_Icon_Xpath);
        //    GlobalVariables.webDriver.WaitForPageLoad();
        //}


        [Given(@"I Clicked On the (.*) button")]
        public void GivenIClickedOnTheButton(string button)
        {
            button = Regex.Replace(button, @"(<|>)", "");

            if (button == "Configure Accessorials")
            {
                scrollElementIntoView(attributeName_id, "btnCorporateReferenceNumberUpload");
                Click(attributeName_id, configureAccessorialsButton_Id);
                GlobalVariables.webDriver.WaitForPageLoad();
            }
            else if (button == "Add Accessorial")
            {
                Click(attributeName_id, addAccessorialbutton_Id);
            }
        }


        //[Given(@"I am on the Configure Accessorials page")]
        //public void GivenIAmOnTheConfigureAccessorialsPage()
        //{
        //    VerifyElementVisible(attributeName_xpath, configureAccessorialsPageHeader_Xpath, "Configure Accessorials");
        //    Report.WriteLine("I am on Configure Accessorials page");
        //}

        [When(@"I Click on the (.*) button")]
        public void WhenIClickOnTheButton(string button)
        {


            button = Regex.Replace(button, @"(<|>)", "");
            if (button == "Add Accessorial")
            {
                Click(attributeName_id, configureAccessorialsPageAddAccessorialButton_Id);
            }
            else if (button == "Remove")
            {
                Click(attributeName_xpath, secondAccessorialRemovebutton_Xpath);
            }
            if (button == "Cancel")
            {
                Click(attributeName_xpath, cancelbutton_Accessrial_Xpath);
            }
            if (button == "Save")
            {
                Click(attributeName_id, savebutton_Accessorial_Id);
            }
        }

        [Then(@"I will be presented with the (.*) modal")]
        public void ThenIWillBePresentedWithTheModal(string addAccessorial)
        {
            WaitForElementVisible(attributeName_xpath, addAccesorialModal_Xpath, addAccessorial);
            VerifyElementPresent(attributeName_xpath, addAccesorialModal_Xpath, addAccessorial);
        }

        [Then(@"the modal will have (.*) field - required, alpha-numeric, special characters, max length (.*) characters")]
        public void ThenTheModalWillHaveField_RequiredAlpha_NumericSpecialCharactersMaxLengthCharacters(string fieldType, int totalLength)
        {
            fieldType = Regex.Replace(fieldType, @"(<|>)", "");

            if (fieldType == "Name")
            {
                string nameLaebl = Gettext(attributeName_xpath, nameLabel_Accessorial_Xpath);
                Assert.AreEqual("Name", nameLaebl);
                VerifyElementPresent(attributeName_id, nameTextbox_Accessorial_Id, fieldType);
                scrollElementIntoView(attributeName_xpath, cancelbutton_Accessrial_Xpath);
                Click(attributeName_id, savebutton_Accessorial_Id);
                string actualNameFieldCSSValue = GetCSSValue(attributeName_id, nameTextbox_Accessorial_Id, "background-color");
                string expectedNameFieldCSSValue = "rgba(251, 236, 237, 1)";
                Assert.AreEqual(actualNameFieldCSSValue, expectedNameFieldCSSValue);

                SendKeys(attributeName_id, nameTextbox_Accessorial_Id, testDataWith100Characters);
                string actualName = GetValue(attributeName_id, nameTextbox_Accessorial_Id, "value");
                Assert.AreEqual(totalLength, actualName.Count());
            }
            else if (fieldType == "MG Description")
            {
                string mgDescriptionLabel = Gettext(attributeName_xpath, firstMGDescriptionLabel_Accessorial_Xpath);
                Assert.AreEqual("MG Description", mgDescriptionLabel);
                VerifyElementPresent(attributeName_xpath, firstMGDescriptionTextbox_Accessorial_Xpath, fieldType);

                scrollElementIntoView(attributeName_xpath, cancelbutton_Accessrial_Xpath);
                Click(attributeName_id, savebutton_Accessorial_Id);
                string actualMGDescriptionFieldCSSValue = GetCSSValue(attributeName_xpath, firstMGDescriptionTextbox_Accessorial_Xpath, "background-color");
                string expectedMGDescriptionFieldCSSValue = "rgba(251, 236, 237, 1)";
                Assert.AreEqual(actualMGDescriptionFieldCSSValue, expectedMGDescriptionFieldCSSValue);

                SendKeys(attributeName_xpath, firstMGDescriptionTextbox_Accessorial_Xpath, testDataWith100Characters);
                string actualMGDescription = GetValue(attributeName_xpath, firstMGDescriptionTextbox_Accessorial_Xpath, "value");
                Assert.AreEqual(totalLength, actualMGDescription.Count());

            }

        }

        [Then(@"the modal will have (.*) field - required, alpha-numeric, max length (.*) characters")]
        public void ThenTheModalWillHaveField_RequiredAlpha_NumericMaxLengthCharacters(string serviceCode, int totalLength)
        {
            Verifytext(attributeName_xpath, serviceCodeLabel_Accessorial_Xpath, "Service Code");
            VerifyElementPresent(attributeName_id, serviceCodeTextbox_Accessorial_Id, serviceCode);


            scrollElementIntoView(attributeName_xpath, cancelbutton_Accessrial_Xpath);
            Click(attributeName_id, savebutton_Accessorial_Id);
            string actualServiceCodeFieldCSSValue = GetCSSValue(attributeName_id, serviceCodeTextbox_Accessorial_Id, "background-color");
            string expectedServiceCodeFieldCSSValue = "rgba(251, 236, 237, 1)";
            Assert.AreEqual(actualServiceCodeFieldCSSValue, expectedServiceCodeFieldCSSValue);

            SendKeys(attributeName_id, serviceCodeTextbox_Accessorial_Id, testDataWith100Characters);
            string actualerviceCode = GetValue(attributeName_id, serviceCodeTextbox_Accessorial_Id, "value");
            Assert.AreEqual(totalLength, actualerviceCode.Count());
        }

        [Then(@"the modal will have (.*) link")]
        public void ThenTheModalWillHaveLink(string mgDescription)
        {
            Verifytext(attributeName_id, addAdditionalMgDescriptionLink_Id, "Add Another MG Description");
            VerifyElementPresent(attributeName_id, addAdditionalMgDescriptionLink_Id, mgDescription);
        }

        [Then(@"the modal will have (.*) required, multi-select as All, LTL, Truckload, Partial Truckload, Intermodal, Domestic Forwarding, International")]
        public void ThenTheModalWillHaveRequiredMulti_SelectAsAllLTLTruckloadPartialTruckloadIntermodalDomesticForwardingInternational(string serviceTypes)
        {
            Verifytext(attributeName_xpath, serviceTypesLabel_Accessorial_Xpath, "Service Types");
            VerifyElementPresent(attributeName_xpath, serviceTypedropdown_Accessorial_Xpath, serviceTypes);
            scrollElementIntoView(attributeName_xpath, cancelbutton_Accessrial_Xpath);
            Click(attributeName_id, savebutton_Accessorial_Id);
            string actualServiceTypeFieldCSSValue = GetCSSValue(attributeName_xpath, serviceTypedropdown_Accessorial_Xpath, "background-color");
            string expectedServiceTypeFieldCSSValue = "rgba(251, 236, 237, 1)";
            Assert.AreEqual(actualServiceTypeFieldCSSValue, expectedServiceTypeFieldCSSValue);
            Click(attributeName_xpath, serviceTypedropdown_Accessorial_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, serviceTypedropdown_Accessorial_Xpath, "LTL");
            Click(attributeName_xpath, serviceTypedropdown_Accessorial_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, serviceTypedropdown_Accessorial_Xpath, "Truckload");
            Click(attributeName_xpath, serviceTypedropdown_Accessorial_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, serviceTypedropdown_Accessorial_Xpath, "Partial Truckload");
            Click(attributeName_xpath, serviceTypedropdown_Accessorial_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, serviceTypedropdown_Accessorial_Xpath, "Intermodal");
            Click(attributeName_xpath, serviceTypedropdown_Accessorial_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, serviceTypedropdown_Accessorial_Xpath, "Domestic Forwarding");
            Click(attributeName_xpath, serviceTypedropdown_Accessorial_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, serviceTypedropdown_Accessorial_Xpath, "International");
            Click(attributeName_xpath, serviceTypedropdown_Accessorial_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, serviceTypedropdown_Accessorial_Xpath, "All");

            //IJavaScriptExecutor executor = (IJavaScriptExecutor)GlobalVariables.webDriver;
            //IWebElement data = GlobalVariables.webDriver.FindElement(By.XPath("//label[@for='ApplyAccessorialToNone']"));
            //executor.ExecuteScript("arguments[0].click();", data);
           // Click(attributeName_xpath, firstMGDescriptionTextbox_Accessorial_Xpath);

           // Click(attributeName_xpath, ".//*[@id='ServiceTypes_chosen']/ul/li[1]/a");

            

        }

        [Then(@"the modal will have (.*) required, options")]
        public void ThenTheModalWillHaveRequiredOptions(string applyAccessorial)
        {
            applyAccessorial = Regex.Replace(applyAccessorial, @"(<|>)", "");

            string applyAccessorialText = Gettext(attributeName_xpath, applyAccessorialsToLabel_Xpath);
            Assert.AreEqual(applyAccessorialText, applyAccessorial+ " *");
            scrollElementIntoView(attributeName_xpath, cancelbutton_Accessrial_Xpath);
            Click(attributeName_id, savebutton_Accessorial_Id);


            IWebElement shpToRadiobuttonElement = GlobalVariables.webDriver.FindElement(By.XPath("//label[@for='ApplyAccessorialToShipTo']"));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)GlobalVariables.webDriver;
            string shpToRadiobuttonColor = executor.ExecuteScript("return window.getComputedStyle(arguments[0], ':before').getPropertyValue('background-color'); ", shpToRadiobuttonElement).ToString();
            Assert.AreEqual("rgb(251, 236, 238)", shpToRadiobuttonColor);

            IWebElement shpFromRadiobuttonElement = GlobalVariables.webDriver.FindElement(By.XPath("//label[@for='ApplyAccessorialToShipFrom']"));
            string shpFromRadiobuttonColor = executor.ExecuteScript("return window.getComputedStyle(arguments[0], ':before').getPropertyValue('background-color'); ", shpToRadiobuttonElement).ToString();
            Assert.AreEqual("rgb(251, 236, 238)", shpFromRadiobuttonColor);

            IWebElement bothRadiobuttonElement = GlobalVariables.webDriver.FindElement(By.XPath("//label[@for='ApplyAccessorialToBoth']"));
            string bothRadiobuttonColor = executor.ExecuteScript("return window.getComputedStyle(arguments[0], ':before').getPropertyValue('background-color'); ", shpToRadiobuttonElement).ToString();
            Assert.AreEqual("rgb(251, 236, 238)", bothRadiobuttonColor);

            IWebElement noneRadiobuttonElement = GlobalVariables.webDriver.FindElement(By.XPath("//label[@for='ApplyAccessorialToNone']"));
            string noneRadiobuttonColor = executor.ExecuteScript("return window.getComputedStyle(arguments[0], ':before').getPropertyValue('background-color'); ", shpToRadiobuttonElement).ToString();
            Assert.AreEqual("rgb(251, 236, 238)", noneRadiobuttonColor);

        }

        [Then(@"the modal will have Cancel button")]
        public void ThenTheModalWillHaveCancelButton()
        {
            VerifyElementPresent(attributeName_xpath, cancelbutton_Accessrial_Xpath, "Cancel button");
            Verifytext(attributeName_xpath, cancelbutton_Accessrial_Xpath, "Cancel");
        }

        [Then(@"the modal will have Save button")]
        public void ThenTheModalWillHaveSaveButton()
        {
            VerifyElementPresent(attributeName_id, savebutton_Accessorial_Id, "Save button");
            Verifytext(attributeName_id, savebutton_Accessorial_Id, "Save");
        }

        [Then(@"I will see options for (.*)")]
        public void ThenIWillSeeOptionsFor(string p0)
        {
            string shpToLabel = Gettext(attributeName_xpath, shipToRadiobutton_Xpath);
            Assert.AreEqual("Ship To", shpToLabel);

            Verifytext(attributeName_xpath, shipFromRadiobutton_Xpath, "Ship From");
            Verifytext(attributeName_xpath, bothRadiobutton_Xpath, "Both");
            Verifytext(attributeName_xpath, noneFromRadiobutton_Xpath, "None");
        }

        [Then(@"the options are (.*), (.*), (.*), (.*)")]
        public void ThenTheOptionsAre(string shipFrom, string shipTo, string both, string none)
        {
            shipFrom = Regex.Replace(shipFrom, @"(<|>)", "");
            shipTo = Regex.Replace(shipTo, @"(<|>)", "");
            both = Regex.Replace(both, @"(<|>)", "");
            none = Regex.Replace(none, @"(<|>)", "");
            Verifytext(attributeName_xpath, shipToRadiobutton_Xpath, "Ship To");
            Verifytext(attributeName_xpath, shipFromRadiobutton_Xpath, "Ship From");
            Verifytext(attributeName_xpath, bothRadiobutton_Xpath, "Both");
            Verifytext(attributeName_xpath, noneFromRadiobutton_Xpath, "None");

            VerifyElementPresent(attributeName_id, "ApplyAccessorialToShipTo", shipTo);
            VerifyElementPresent(attributeName_id, "ApplyAccessorialToShipFrom", shipFrom);
            VerifyElementPresent(attributeName_id, "ApplyAccessorialToBoth", both);
            VerifyElementPresent(attributeName_id, "ApplyAccessorialToNone", none);
        }

        [Then(@"none of the options have been default selected")]
        public void ThenNoneOfTheOptionsHaveBeenDefaultSelected()
        {
            VerifyElementNotChecked(attributeName_id, "ApplyAccessorialToShipTo", "Ship To");
            VerifyElementNotChecked(attributeName_id, "ApplyAccessorialToShipFrom", "Ship From");
            VerifyElementNotChecked(attributeName_id, "ApplyAccessorialToBoth", "Both");
            VerifyElementNotChecked(attributeName_id, "ApplyAccessorialToNone", "None");
        }

        [Then(@"I am required to select an option")]
        public void ThenIAmRequiredToSelectAnOption()
        {
            Click(attributeName_xpath, shipToRadiobutton_Xpath);
        }

        [Given(@"I am in the (.*) modal")]
        public void GivenIAmInTheModal(string accessorial)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            accessorial = Regex.Replace(accessorial, @"(<|>)", "");
            

            if (accessorial == "Add Accessorial")
            {
                WaitForElementVisible(attributeName_xpath, addAccesorialModal_Xpath, accessorial);
                VerifyElementPresent(attributeName_xpath, addAccesorialModal_Xpath, accessorial);
            }
            else if (accessorial == "Edit Accessorial")
            {
                WaitForElementVisible(attributeName_xpath, editAccesorialModal_Xpath, accessorial);
                VerifyElementPresent(attributeName_xpath, editAccesorialModal_Xpath, accessorial);
            }
        }

        [When(@"I click on the Add Another MG Description link")]
        public void WhenIClickOnTheAddMGDescriptionLink()
        {
            Click(attributeName_id, addAdditionalMgDescriptionLink_Id);
        }

        [Then(@"a new (.*) text box will appear")]
        public void ThenANewTextBoxWillAppear(string mGDescription)
        {
            VerifyElementPresent(attributeName_xpath, secondMGDescriptionTextbox_Accessorial_Xpath, "Additional MG Descritpion Textbox");
        }


        [Then(@"I will see (.*) button next to additional MG Description text box")]
        public void ThenIWillSeeButtonNextToAdditionalMGDescriptionTextBox(string removeButton)
        {
            removeButton = Regex.Replace(removeButton, @"(<|>)", "");

            VerifyElementPresent(attributeName_xpath, secondAccessorialRemovebutton_Xpath, removeButton);
            Verifytext(attributeName_xpath, secondAccessorialRemovebutton_Xpath, removeButton);
        }


        [Then(@"the additional MG Description field is required")]
        public void ThenTheAdditionalMGDescriptionFieldIsRequired()
        {
            Clear(attributeName_xpath, secondMGDescriptionTextbox_Accessorial_Xpath);
            scrollElementIntoView(attributeName_xpath, cancelbutton_Accessrial_Xpath);
            Click(attributeName_id, savebutton_Accessorial_Id);
            string actualAdditonalMGDescriptionFieldCSSValue = GetCSSValue(attributeName_xpath, secondMGDescriptionTextbox_Accessorial_Xpath, "background-color");
            string expectedAdditonalMGDescriptionFieldCSSValue = "rgba(251, 236, 237, 1)";
            Assert.AreEqual(actualAdditonalMGDescriptionFieldCSSValue, expectedAdditonalMGDescriptionFieldCSSValue);
        }


        [Given(@"I clicked on the (.*) link")]
        public void GivenIClickedOnTheLink(string addAnotherMGDescription)
        {
            Click(attributeName_id, addAdditionalMgDescriptionLink_Id);
        }

        [Then(@"the additional MG Description field will be removed")]
        public void ThenTheAdditionalMGDescriptionFieldWillBeRemoved()
        {
            //bool a = IsElementVisible(attributeName_xpath, secondMGDescriptionTextbox_Accessorial_Xpath, "Additional MG Description Textbox");
            VerifyElementNotPresent(attributeName_xpath, "//div[@class='mg-description-group']//div[@class='col-md-8 requiredlabel']//input[@id='MGDescription']", "Additional MG Description Textbox");
            //bool checkAdditionalMGDescriptionTextbox = GlobalVariables.webDriver.FindElement(By.XPath(secondMGDescriptionTextbox_Accessorial_Xpath)).Displayed;
            //Assert.IsFalse(checkAdditionalMGDescriptionTextbox);
        }

        [Then(@"the (.*) button will be removed")]
        public void ThenTheButtonWillBeRemoved(string remove)
        {
            VerifyElementNotPresent(attributeName_xpath, secondAccessorialRemovebutton_Xpath, "Remove button");
            //bool checkRemoveTextbox = GlobalVariables.webDriver.FindElement(By.XPath(secondAccessorialRemovebutton_Xpath)).Displayed;
            //Assert.IsFalse(checkRemoveTextbox);
        }

        [Then(@"the modal will close")]
        public void ThenTheModalWillClose()
        {
            Thread.Sleep(2000);
            WaitForElementVisible(attributeName_xpath, configureAccessorialsPageHeader_Xpath, "Configure Accessorials");
            VerifyElementNotVisible(attributeName_xpath, ".//*[@id='accessorial-popup-div']//div[@class='modal-content']", "Accessorial Modal");

        }

        [Given(@"I entered all the required information")]
        public void GivenIEnteredAllTheRequiredInformation()
        {
            SendKeys(attributeName_id, nameTextbox_Accessorial_Id, accessorialName);
            SendKeys(attributeName_id, serviceCodeTextbox_Accessorial_Id, accessorialServiceCode);
            SendKeys(attributeName_xpath, firstMGDescriptionTextbox_Accessorial_Xpath, accessorialMGDescription);
            Click(attributeName_id, addAdditionalMgDescriptionLink_Id);
            SendKeys(attributeName_xpath, secondMGDescriptionTextbox_Accessorial_Xpath, accessorialAdditionalMGDescription);
            Click(attributeName_xpath, serviceTypedropdown_Accessorial_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, serviceTypedropdown_Accessorial_Xpath, accessorialServiceType1);
            if (accessorialDirection == "Ship To")
            {
                Click(attributeName_xpath, shipToRadiobutton_Xpath);
            }

        }

        [Then(@"the data will be saved")]
        public void ThenTheDataWillBeSaved()
        {
            //DBCall and Verify in DB

            ConfigureAccessorialViewModel accModelData = DBHelper.GetAccessorialDetails(accessorialName);
            string accessorialNameModalValueFromDB = accModelData.AccessorialName;
            Assert.AreEqual(accessorialName, accessorialNameModalValueFromDB);

            string accessorialServiceCodeModalValueFromDB = accModelData.AccessorialCode;
            Assert.AreEqual(accessorialServiceCode.Substring(0, 20), accessorialServiceCodeModalValueFromDB);



            for (int i = 0; i < accModelData.MG_Description.Count; i++)
            {

                if (accModelData.MG_Description[i] == accessorialMGDescription)
                {
                    Report.WriteLine("verified MG Description updated in DB");
                }
                else if (accModelData.MG_Description[i] == accessorialAdditionalMGDescription)
                {
                    Report.WriteLine("verified MG Description updated in DB");
                }
                else
                {
                    Assert.Fail("verified MG Description is not updated in DB");
                }

            }
            mgDescriptionCount = accModelData.MG_Description.Count;
            totalMGDescription = accModelData.MG_Description.ToList();
            totalMGDescription.Sort();

            serviceTypeCount = accModelData.ShipmentServiceName.Count;
            totalService = accModelData.ShipmentServiceName.ToList();
            totalService.Sort();

            for (int i = 0; i < accModelData.ShipmentServiceName.Count; i++)
            {

                if (accModelData.ShipmentServiceName[i] == accessorialServiceType1)
                {
                    Report.WriteLine("verified Service Type updated in DB");
                }
                else if (accModelData.ShipmentServiceName[i] == accessorialServiceType2)
                {
                    Report.WriteLine("verified Service Type updated in DB");
                }
                else
                {
                    Assert.Fail("verified Service Type is not updated in DB");
                }

            }

            string accessorialDirectionNameFromDB = accModelData.AccessorialDirectionName;
            if (accessorialDirection == "Ship To")
            {
                Assert.AreEqual("Destination", accessorialDirectionNameFromDB);
            }
            else if (accessorialDirection == "Ship From")
            {
                Assert.AreEqual("Origin", accessorialDirectionNameFromDB);
            }
            else
            {
                Assert.AreEqual(accessorialDirection, accessorialDirectionNameFromDB);
            }

        }

        [Then(@"the Configure Accessorials grid will be updated to display the new accessorial")]
        public void ThenTheConfigureAccessorialsGridWillBeUpdatedToDisplayTheNewAccessorial()
        {
            //Save Data Verify in Grid

            SendKeys(attributeName_xpath, configureAccessorialsSearchTexBox_Xpath, accessorialName);
            string firstNameGridValue = Gettext(attributeName_xpath, firstNameGridValue_Xpath);

            ConfigureAccessorialViewModel accModelData = DBHelper.GetAccessorialDetails(accessorialName);

            Assert.AreEqual(firstNameGridValue, accessorialName);

            string firstServiceCodeGridValue = Gettext(attributeName_xpath, firstServiceCodeValue_Xpath);
            Assert.AreEqual(firstServiceCodeGridValue, accessorialServiceCode.Substring(0, 20));

            string firstMGDescriptionGridValue = Gettext(attributeName_xpath, firstMGDescriptionGridValue_Xpath);
            List<string> accessorialMGDescriptionGridValue = new List<string>();
            if (mgDescriptionCount > 1)
            {
                accessorialMGDescriptionGridValue = firstMGDescriptionGridValue.Split(',').ToList();
                accessorialMGDescriptionGridValue.Sort();
                CollectionAssert.AreEqual(totalMGDescription, accessorialMGDescriptionGridValue);
            }
            else
            {
                Assert.AreEqual(accessorialMGDescription, firstMGDescriptionGridValue);
            }



            //for (int i = 0; i < accessorialMGDescriptionGridValue.Count; i++)
            //{
            //    if (accessorialMGDescriptionGridValue[i] == accessorialMGDescription)
            //    {
            //        Report.WriteLine("verified created MG Description updated in MG Description Grid Cloumn");
            //    }
            //    else if (accessorialMGDescriptionGridValue[i] == accessorialAdditionalMGDescription)
            //    {
            //        Report.WriteLine("verified created MG Description updated in MG Description Grid Cloumn");
            //    }
            //    else
            //    {
            //        Assert.Fail("verified created MG Description is not updated in MG Description Grid Cloumn");
            //    }
            //}

            string firstServiceTypeGridValue = Gettext(attributeName_xpath, firstServiceTypeGridValue_Xpath);

            List<string> accessorialServiceTypeGridValue = new List<string>();
            if (serviceTypeCount > 1)
            {
                accessorialServiceTypeGridValue = firstServiceTypeGridValue.Split(',').ToList();
                accessorialServiceTypeGridValue.Sort();
                CollectionAssert.AreEqual(totalService, accessorialServiceTypeGridValue);
            }
            else
            {

                Assert.AreEqual(accessorialServiceType1, firstServiceTypeGridValue);
            }

            //for (int i = 0; i < accessorialServiceTypeGridValue.Count; i++)
            //{
            //    if (accessorialMGDescriptionGridValue[i] == accessorialServiceType1)
            //    {
            //        Report.WriteLine("verified created Service is  updated in Service Type Grid Cloumn");
            //    }
            //    else if (accessorialServiceTypeGridValue[i] == accessorialServiceType2)
            //    {
            //        Report.WriteLine("verified created Service is  updated in Service Type Grid Cloumn");
            //    }
            //    else
            //    {
            //        Assert.Fail("verified created Service is not updated in Service Type Grid Cloumn");
            //    }
            //}

            string firstDirectionGridValue = Gettext(attributeName_xpath, firstDirectionGridValue_Xpath);
            Assert.AreEqual(firstDirectionGridValue, "Ship To");
        }

        [When(@"I Select (.*) as ALL")]
        public void WhenISelectAsALL(string servicetype)
        {
            Click(attributeName_xpath, serviceTypedropdown_Accessorial_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, serviceTypedropdown_Accessorial_Xpath, "All");
        }

        [Then(@"I am not allowed to Select any other Service Type")]
        public void ThenIAmNotAllowedToSelectAnyOtherServiceType()
        {
            Click(attributeName_xpath, serviceTypedropdown_Accessorial_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, serviceTypedropdown_Accessorial_Xpath, "Intermodal");
            string selectedService = Gettext(attributeName_xpath, ".//*[@id='ServiceTypes_chosen']/ul");
            //Assert.AreEqual("ALL", data);
            bool checkAnyotherServiceSelected = selectedService.Contains("Intermodal");
            Assert.IsFalse(checkAnyotherServiceSelected);
        }

        [When(@"I Select all other services except (.*) ALL")]
        public void WhenISelectAllOtherServicesExceptALL(string serviceType)
        {
            Click(attributeName_xpath, serviceTypedropdown_Accessorial_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, serviceTypedropdown_Accessorial_Xpath, "LTL");
            Click(attributeName_xpath, serviceTypedropdown_Accessorial_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, serviceTypedropdown_Accessorial_Xpath, "Truckload");
            Click(attributeName_xpath, serviceTypedropdown_Accessorial_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, serviceTypedropdown_Accessorial_Xpath, "Partial Truckload");
            Click(attributeName_xpath, serviceTypedropdown_Accessorial_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, serviceTypedropdown_Accessorial_Xpath, "Intermodal");
            Click(attributeName_xpath, serviceTypedropdown_Accessorial_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, serviceTypedropdown_Accessorial_Xpath, "Domestic Forwarding");
            Click(attributeName_xpath, serviceTypedropdown_Accessorial_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, serviceTypedropdown_Accessorial_Xpath, "International");

        }

        [Then(@"the Service Type All will be auto selected")]
        public void ThenTheServiceTypeAllWillBeAutoSelected()
        {
            string selectedService = Gettext(attributeName_xpath, ".//*[@id='ServiceTypes_chosen']/ul");
            Assert.AreEqual("ALL", selectedService);
        }
    }
}
