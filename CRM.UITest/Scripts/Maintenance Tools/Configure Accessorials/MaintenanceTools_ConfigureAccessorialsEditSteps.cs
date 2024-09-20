using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Helper.ViewModel;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Maintenance_Tools.Configure_Accessorials
{
    [Binding]
    public class MaintenanceTools_ConfigureAccessorialsEditSteps : ConfigureAccessorial
    {
        MaintenanceTools_ConfigureAccessorials_AddSteps addAccessorialClass = new MaintenanceTools_ConfigureAccessorials_AddSteps();

        string testDataWith100Characters = "abcdefghijklmnopqrstuvwxyz123451234512345123451234512345123451234512345!@#$%^&*()_-+={[}]|:;<?>./12345123451234512345";
        int actualMGDescriptiontextboxCount;
        int actualMGDescriptionRemoveButtonCount;

        string accessorialName = "VasaAcc" + Guid.NewGuid().ToString();
        string accessorialServiceCode = "VasaServiceCode" + Guid.NewGuid().ToString();
        string accessorialMGDescription = "VasaMGDescription" + Guid.NewGuid().ToString();
        string accessorialService = "LTL";
        string accessorialDirection = "Ship To";

        string editedAccessorialName = "VaAcc" + Guid.NewGuid().ToString();
        string editedAccessorialServiceCode = "VaServiceCode" + Guid.NewGuid().ToString();
        string editedAccessorialMGDescription = "VaMGDescription" + Guid.NewGuid().ToString();
        string editedAdditionalAccessorialMGDescription = "VaAddtnlDescrp" + Guid.NewGuid().ToString();
        string editedAccessorialServiceType = "Intermodal";
        string editedAccessorialDirection = "None";
        int dbServiceCount;
        string editedField = string.Empty;
        string fieldToEdit = string.Empty;
        List<string> totalMGDescription = new List<string>();
        int mgDescriptionCount;
        ConfigureAccessorialViewModel accModelData = new ConfigureAccessorialViewModel();


        [When(@"I click on the (.*) icon of any displayed accessorial")]
        public void WhenIClickOnTheIconOfAnyDisplayedAccessorial(string edit)
        {
            Click(attributeName_id, addAccessorialbutton_Id);
            WaitForElementVisible(attributeName_xpath, addAccesorialModal_Xpath, "Add Accessorial Modal");
            VerifyElementPresent(attributeName_xpath, addAccesorialModal_Xpath, "Add Accessorial Modal");

            SendKeys(attributeName_id, nameTextbox_Accessorial_Id, accessorialName);
            SendKeys(attributeName_id, serviceCodeTextbox_Accessorial_Id, accessorialServiceCode);
            SendKeys(attributeName_xpath, firstMGDescriptionTextbox_Accessorial_Xpath, accessorialMGDescription);
            Click(attributeName_xpath, serviceTypedropdown_Accessorial_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, serviceTypedropdown_Accessorial_Xpath, accessorialService);
            if (accessorialDirection == "Ship To")
            {

                IWebElement element = GlobalVariables.webDriver.FindElement(By.Id("ApplyAccessorialToShipTo"));
                IJavaScriptExecutor executor = (IJavaScriptExecutor)GlobalVariables.webDriver;
                executor.ExecuteScript("arguments[0].click();", element);


                //Click(attributeName_xpath, shipToRadiobutton_Xpath);
            }
            Click(attributeName_id, savebutton_Accessorial_Id);

            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_xpath, configureAccessorialsSearchTexBox_Xpath, accessorialName);
            //string firstNameGridValue = Gettext(attributeName_xpath, firstNameGridValue_Xpath);
            Click(attributeName_xpath, ".//*[@id='Grid_ConfigureAccessorial']//tr[1]//span[@class = 'icon-edit']");
        }

        [Then(@"the (.*) modal will open")]
        public void ThenTheModalWillOpen(string editAccesssorialModal)
        {
            WaitForElementVisible(attributeName_xpath, editAccesorialModal_Xpath, editAccesssorialModal);
        }

        [Then(@"I will see (.*) field - required, alpha-numeric, special characters, max length (.*) characters")]
        public void ThenIWillSeeField_RequiredAlpha_NumericSpecialCharactersMaxLengthCharacters(string fieldType, int totalLength)
        {
            fieldType = Regex.Replace(fieldType, @"(<|>)", "");

            if (fieldType == "Name")
            {
                Clear(attributeName_id, nameTextbox_Accessorial_Id);
                string nameLaebl = Gettext(attributeName_xpath, nameLabel_Accessorial_Xpath);
                Assert.AreEqual("Name", nameLaebl);
                VerifyElementPresent(attributeName_id, nameTextbox_Accessorial_Id, fieldType);


                //Verifying field as required by clicking Save button and Verify color code for Name field
                scrollElementIntoView(attributeName_xpath, cancelbutton_Accessrial_Xpath);
                Click(attributeName_id, "EditAccessorial");
                string actualNameFieldCSSValue = GetCSSValue(attributeName_id, nameTextbox_Accessorial_Id, "background-color");
                string expectedNameFieldCSSValue = "rgba(251, 236, 237, 1)";//rgb(251, 236, 237)";
                Assert.AreEqual(actualNameFieldCSSValue, expectedNameFieldCSSValue);

                SendKeys(attributeName_id, nameTextbox_Accessorial_Id, testDataWith100Characters);
                string actualName = GetValue(attributeName_id, nameTextbox_Accessorial_Id, "value");
                Assert.AreEqual(totalLength, actualName.Count());
            }
            else if (fieldType == "MG Description")
            {
                Clear(attributeName_xpath, firstMGDescriptionTextbox_Accessorial_Xpath);
                string mgDescriptionLabel = Gettext(attributeName_xpath, firstMGDescriptionLabel_Accessorial_Xpath);
                Assert.AreEqual("MG Description", mgDescriptionLabel);
                VerifyElementPresent(attributeName_xpath, firstMGDescriptionTextbox_Accessorial_Xpath, fieldType);

                scrollElementIntoView(attributeName_xpath, cancelbutton_Accessrial_Xpath);
                Click(attributeName_id, "EditAccessorial");
                string actualMGDescriptionFieldCSSValue = GetCSSValue(attributeName_xpath, firstMGDescriptionTextbox_Accessorial_Xpath, "background-color");
                string expectedMGDescriptionFieldCSSValue = "rgba(251, 236, 237, 1)";
                Assert.AreEqual(actualMGDescriptionFieldCSSValue, expectedMGDescriptionFieldCSSValue);

                SendKeys(attributeName_xpath, firstMGDescriptionTextbox_Accessorial_Xpath, testDataWith100Characters);
                string actualName = GetValue(attributeName_xpath, firstMGDescriptionTextbox_Accessorial_Xpath, "value");
                Assert.AreEqual(totalLength, actualName.Count());
            }
        }

        [Then(@"I will see (.*) field - required, alpha-numeric, max length (.*) characters")]
        public void ThenIWillSeeField_RequiredAlpha_NumericMaxLengthCharacters(string serviceCode, int totalLength)
        {
            Clear(attributeName_id, serviceCodeTextbox_Accessorial_Id);
            Verifytext(attributeName_xpath, serviceCodeLabel_Accessorial_Xpath, "Service Code");
            VerifyElementPresent(attributeName_id, serviceCodeTextbox_Accessorial_Id, serviceCode);


            scrollElementIntoView(attributeName_xpath, cancelbutton_Accessrial_Xpath);
            Click(attributeName_id, "EditAccessorial");
            string actualServiceCodeFieldCSSValue = GetCSSValue(attributeName_id, serviceCodeTextbox_Accessorial_Id, "background-color");
            string expectedServiceCodeFieldCSSValue = "rgba(251, 236, 237, 1)";
            Assert.AreEqual(actualServiceCodeFieldCSSValue, expectedServiceCodeFieldCSSValue);

            SendKeys(attributeName_id, serviceCodeTextbox_Accessorial_Id, testDataWith100Characters);
            string actualName = GetValue(attributeName_id, serviceCodeTextbox_Accessorial_Id, "value");
            Assert.AreEqual(totalLength, actualName.Count());
        }

        [Then(@"I will see Add Another MG Description link")]
        public void ThenIWillSeeAddAnotherMGDescriptionLink()
        {
            Verifytext(attributeName_id, addAdditionalMgDescriptionLink_Id, "Add Another MG Description");
            VerifyElementPresent(attributeName_id, addAdditionalMgDescriptionLink_Id, "Add Another MG Description");
        }

        [Then(@"I will see (.*) required, multi-select as LTL, Truckload, Partial truckload, Intermodal, Domestic Forwarding, International or All")]
        public void ThenIWillSeeRequiredMulti_SelectAsLTLTruckloadPartialTruckloadIntermodalDomesticForwardingInternationalOrAll(string serviceTypes)
        {

            IJavaScriptExecutor executor = (IJavaScriptExecutor)GlobalVariables.webDriver;
            IWebElement element = GlobalVariables.webDriver.FindElement(By.XPath(serviceTypedropdown_Accessorial_Xpath));
            executor.ExecuteScript("arguments[0].click();", element);
            Click(attributeName_xpath, firstMGDescriptionTextbox_Accessorial_Xpath);
            executor.ExecuteScript("arguments[0].click();", element);
            SelectDropdownValueFromList(attributeName_xpath, serviceTypedropdown_Accessorial_Xpath, "LTL");
            //Click(attributeName_xpath, firstMGDescriptionTextbox_Accessorial_Xpath);
            Thread.Sleep(1000);
            //Click(attributeName_xpath, ".//*[@id='ServiceTypes_chosen']/ul/li[2]/a");
            //Thread.Sleep(1000);
            executor.ExecuteScript("arguments[0].click();", element);
            SelectDropdownValueFromList(attributeName_xpath, serviceTypedropdown_Accessorial_Xpath, "Truckload");
            Thread.Sleep(1000);
            //Click(attributeName_xpath, ".//*[@id='ServiceTypes_chosen']/ul/li[3]/a");
            //Thread.Sleep(1000);
            executor.ExecuteScript("arguments[0].click();", element);
            SelectDropdownValueFromList(attributeName_xpath, serviceTypedropdown_Accessorial_Xpath, "Partial Truckload");
            Thread.Sleep(1000);
            executor.ExecuteScript("arguments[0].click();", element);
            SelectDropdownValueFromList(attributeName_xpath, serviceTypedropdown_Accessorial_Xpath, "Intermodal");
            Thread.Sleep(1000);
            executor.ExecuteScript("arguments[0].click();", element);
            SelectDropdownValueFromList(attributeName_xpath, serviceTypedropdown_Accessorial_Xpath, "Domestic Forwarding");
            Thread.Sleep(1000);
            executor.ExecuteScript("arguments[0].click();", element);
            SelectDropdownValueFromList(attributeName_xpath, serviceTypedropdown_Accessorial_Xpath, "International");
            Thread.Sleep(1000);
            executor.ExecuteScript("arguments[0].click();", element);
            SelectDropdownValueFromList(attributeName_xpath, serviceTypedropdown_Accessorial_Xpath, "All");
            IWebElement data = GlobalVariables.webDriver.FindElement(By.XPath("//label[@for='ApplyAccessorialToNone']"));
            executor.ExecuteScript("arguments[0].click();", data);
            Click(attributeName_xpath, ".//*[@id='ServiceTypes_chosen']/ul/li[1]/a");

            Click(attributeName_xpath, firstMGDescriptionTextbox_Accessorial_Xpath);

            Click(attributeName_id, "EditAccessorial");

            IWebElement shpToRadiobuttonElement = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='ServiceTypes_chosen']/ul/li[@class = 'search-field inputError']"));

            string actualServiceTypeFieldCSSValue = executor.ExecuteScript("return window.getComputedStyle(arguments[0], '').getPropertyValue('background-color'); ", shpToRadiobuttonElement).ToString();
            string expectedServiceTypeFieldCSSValue = "rgb(251, 236, 237)";

            Assert.AreEqual(actualServiceTypeFieldCSSValue, expectedServiceTypeFieldCSSValue);


        }

        [Then(@"the fields will display the data associated to the accessorial")]
        public void ThenTheFieldsWillDisplayTheDataAssociatedToTheAccessorial()
        {
            ////Click(attributeName_xpath, shipToRadiobutton_Xpath);
            //IWebElement element = GlobalVariables.webDriver.FindElement(By.Id("ApplyAccessorialToNone"));
            //IJavaScriptExecutor executor = (IJavaScriptExecutor)GlobalVariables.webDriver;
            //executor.ExecuteScript("arguments[0].click();", element);

            Click(attributeName_xpath, cancelbutton_Accessrial_Xpath);
            Thread.Sleep(2000);
            GlobalVariables.webDriver.WaitForPageLoad();
            //DB Call Take the Accessorial name from edit Modal order by descending
            Click(attributeName_xpath, ".//*[@id='Grid_ConfigureAccessorial']//tr[1]//span[@class = 'icon-edit']");
            WaitForElementVisible(attributeName_xpath, editAccesorialModal_Xpath, "Edit Accessorial");
            string actualName = GetValue(attributeName_id, nameTextbox_Accessorial_Id, "value");
            Assert.AreEqual(accessorialName, actualName);

            string actualerviceCode = GetValue(attributeName_id, serviceCodeTextbox_Accessorial_Id, "value");
            Assert.AreEqual(accessorialServiceCode.Substring(0, 20), actualerviceCode);

            string actualMGDescription = GetValue(attributeName_xpath, firstMGDescriptionTextbox_Accessorial_Xpath, "value");
            Assert.AreEqual(accessorialMGDescription, actualMGDescription);

            string selectedService = Gettext(attributeName_xpath, ".//*[@id='ServiceTypes_chosen']/ul");
            Assert.AreEqual(selectedService, accessorialService);

            if (accessorialDirection == "Ship To")
            {
                VerifyElementChecked(attributeName_id, "ApplyAccessorialToShipTo", accessorialDirection);
            }
            if (accessorialDirection == "Ship From")
            {
                VerifyElementChecked(attributeName_id, "ApplyAccessorialToShipFrom", accessorialDirection);
            }
            if (accessorialDirection == "Both")
            {
                VerifyElementChecked(attributeName_id, "ApplyAccessorialToBoth", accessorialDirection);
            }
            if (accessorialDirection == "None")
            {
                VerifyElementChecked(attributeName_id, "ApplyAccessorialToNone", accessorialDirection);
            }
        }

        [Then(@"the fields are editable")]
        public void ThenTheFieldsAreEditable()
        {
            Clear(attributeName_id, nameTextbox_Accessorial_Id);
            SendKeys(attributeName_id, nameTextbox_Accessorial_Id, "TestAcc");
            string editedAccessroalName = GetValue(attributeName_id, nameTextbox_Accessorial_Id, "value");
            Assert.AreEqual("TestAcc".ToLower(), editedAccessroalName.ToLower());

            Clear(attributeName_id, serviceCodeTextbox_Accessorial_Id);
            SendKeys(attributeName_id, serviceCodeTextbox_Accessorial_Id, "TestServiceCode");
            string editedServiceCode = GetValue(attributeName_id, serviceCodeTextbox_Accessorial_Id, "value");
            Assert.AreEqual("TestServiceCode".ToLower(), editedServiceCode.ToLower());

            Clear(attributeName_xpath, firstMGDescriptionTextbox_Accessorial_Xpath);
            SendKeys(attributeName_xpath, firstMGDescriptionTextbox_Accessorial_Xpath, "TestMGDescription");
            string editedMGDescription = GetValue(attributeName_xpath, firstMGDescriptionTextbox_Accessorial_Xpath, "value");
            Assert.AreEqual("TestMGDescription".ToLower(), editedMGDescription.ToLower());



            IJavaScriptExecutor executor = (IJavaScriptExecutor)GlobalVariables.webDriver;
            IWebElement element = GlobalVariables.webDriver.FindElement(By.XPath(serviceTypedropdown_Accessorial_Xpath));
            executor.ExecuteScript("arguments[0].click();", element);
            Click(attributeName_xpath, firstMGDescriptionTextbox_Accessorial_Xpath);
            executor.ExecuteScript("arguments[0].click();", element);
            SelectDropdownValueFromList(attributeName_xpath, serviceTypedropdown_Accessorial_Xpath, "Truckload");
            //Click(attributeName_xpath, firstMGDescriptionTextbox_Accessorial_Xpath);
            Thread.Sleep(1000);

            string selectedService = Gettext(attributeName_xpath, ".//*[@id='ServiceTypes_chosen']/ul");
            Assert.IsTrue(selectedService.Contains("Truckload"));

            //Clicking Apply Accessorial From radio button
            IWebElement elements = GlobalVariables.webDriver.FindElement(By.Id("ApplyAccessorialToShipFrom"));
            //IJavaScriptExecutor executor = (IJavaScriptExecutor)GlobalVariables.webDriver;
            executor.ExecuteScript("arguments[0].click();", elements);
            VerifyElementChecked(attributeName_id, "ApplyAccessorialToShipFrom", "Ship From");

        }

        [Then(@"I will see the (.*) and (.*) buttons")]
        public void ThenIWillSeeTheAndButtons(string cancel, string save)
        {
            cancel = Regex.Replace(cancel, @"(<|>)", "");
            save = Regex.Replace(save, @"(<|>)", "");

            VerifyElementPresent(attributeName_xpath, cancelbutton_Accessrial_Xpath, cancel);
            Verifytext(attributeName_xpath, cancelbutton_Accessrial_Xpath, cancel);

            VerifyElementPresent(attributeName_id, "EditAccessorial", save);
            Verifytext(attributeName_id, "EditAccessorial", save);


        }

        [Given(@"I clicked on the (.*) icon of any displayed accessorial")]
        public void GivenIClickedOnTheIconOfAnyDisplayedAccessorial(string edit)
        {
            WhenIClickOnTheIconOfAnyDisplayedAccessorial(edit);
        }

        [When(@"I Click on the (.*) link")]
        public void WhenIClickOnTheLink(string addAnotherMGDescription)
        {
            //IList<IWebElement> mgDescriptiontextbox = GlobalVariables.webDriver.FindElements(By.XPath(""));
            //IList<IWebElement> mgDescriptionRemoveButton = GlobalVariables.webDriver.FindElements(By.XPath(""));
            //actualMGDescriptiontextboxCount = mgDescriptiontextbox.Count();
            //actualMGDescriptionRemoveButtonCount = mgDescriptionRemoveButton.Count();
            //scrollElementIntoView(attributeName_id, "");
            //Click(attributeName_id, "");
            Click(attributeName_id, addAdditionalMgDescriptionLink_Id);
        }


        [Then(@"a New (.*) text box will appear")]
        public void ThenANewTextBoxWillAppear(string mgDescriptionTextbox)
        {
            IList<IWebElement> addedAnotherMGDescriptiontextbox = GlobalVariables.webDriver.FindElements(By.XPath(""));
            if (addedAnotherMGDescriptiontextbox.Count > actualMGDescriptiontextboxCount)
            {
                Report.WriteLine("New MG Description Textbox has been added");
            }
            else
            {
                Assert.Fail("New MG Description Textbox has not been added");
            }
        }

        [Then(@"I will see (.*) button next to the additional MG Description text box")]
        public void ThenIWillSeeButtonNextToTheAdditionalMGDescriptionTextBox(string removebutton)
        {
            IList<IWebElement> addedAnotherMGDescriptionRemovebutton = GlobalVariables.webDriver.FindElements(By.XPath(""));
            if (addedAnotherMGDescriptionRemovebutton.Count > actualMGDescriptionRemoveButtonCount)
            {
                Report.WriteLine("Remove button has been appeared next to MG Decription Textbox");
            }
            else
            {
                Assert.Fail("Remove button has not been appeared next to MG Decription Textbox");
            }
        }

        [Given(@"the (.*) modal opened")]
        public void GivenTheModalOpened(string editAccessorialModal)
        {
            editAccessorialModal = Regex.Replace(editAccessorialModal, @"(<|>)", "");
            WaitForElementVisible(attributeName_xpath, editAccesorialModal_Xpath, editAccessorialModal);
            VerifyElementPresent(attributeName_xpath, editAccesorialModal_Xpath, editAccessorialModal);
        }


        [Then(@"the modal will Close")]
        public void ThenTheModalWillClose()
        {
            VerifyElementNotPresent(attributeName_xpath, "", "Edit Accessorial");
        }

        [Given(@"I edited any field (.*) , (.*), (.*), (.*), (.*)")]
        public void GivenIEditedAnyField(string name, string serviceCode, string mgDescription, string serviceType, string Direction)
        {
            //SendKeys(attributeName_id, "", accessorialName);
            //SendKeys(attributeName_id, "", accessorialServiceCode);
            //SendKeys(attributeName_id, "", accessorialMGDescription);
            //Click(attributeName_id, "");
            //SelectDropdownValueFromList(attributeName_id, "", "LTL");
            //Click(attributeName_id, "");

            Clear(attributeName_id, nameTextbox_Accessorial_Id);
            SendKeys(attributeName_id, nameTextbox_Accessorial_Id, editedAccessorialName);

            Clear(attributeName_id, serviceCodeTextbox_Accessorial_Id);
            SendKeys(attributeName_id, serviceCodeTextbox_Accessorial_Id, editedAccessorialServiceCode);

            Clear(attributeName_xpath, firstMGDescriptionTextbox_Accessorial_Xpath);
            SendKeys(attributeName_xpath, firstMGDescriptionTextbox_Accessorial_Xpath, editedAccessorialMGDescription);

            Click(attributeName_xpath, serviceTypedropdown_Accessorial_Xpath);
            Click(attributeName_xpath, ".//*[@id='ServiceTypes_chosen']/ul/li[1]/a");
            Click(attributeName_xpath, serviceTypedropdown_Accessorial_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, serviceTypedropdown_Accessorial_Xpath, editedAccessorialServiceType);


        }


        [Given(@"I edited any (.*)")]
        public void GivenIEditedAny(string field)
        {
            fieldToEdit = field;
            if (field == "Name")
            {
                Clear(attributeName_id, nameTextbox_Accessorial_Id);
                SendKeys(attributeName_id, nameTextbox_Accessorial_Id, editedAccessorialName);
            }
            if (field == "ServiceCode")
            {
                Clear(attributeName_id, serviceCodeTextbox_Accessorial_Id);
                SendKeys(attributeName_id, serviceCodeTextbox_Accessorial_Id, editedAccessorialServiceCode);
            }
            if (field == "MGdescription")
            {
                Clear(attributeName_xpath, firstMGDescriptionTextbox_Accessorial_Xpath);
                SendKeys(attributeName_xpath, firstMGDescriptionTextbox_Accessorial_Xpath, editedAccessorialMGDescription);
            }
            if (field == "ServiceType")
            {
                Click(attributeName_xpath, serviceTypedropdown_Accessorial_Xpath);
                Click(attributeName_xpath, ".//*[@id='ServiceTypes_chosen']/ul/li[1]/a");
                Click(attributeName_xpath, serviceTypedropdown_Accessorial_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, serviceTypedropdown_Accessorial_Xpath, editedAccessorialServiceType);
            }
            if (field == "Direction")
            {
                switch (editedAccessorialServiceType)
                {
                    case "Ship To":
                        {
                            IWebElement element = GlobalVariables.webDriver.FindElement(By.Id("ApplyAccessorialToShipTo"));
                            IJavaScriptExecutor executor = (IJavaScriptExecutor)GlobalVariables.webDriver;
                            executor.ExecuteScript("arguments[0].click();", element);

                            break;
                        }
                    case "Ship From":
                        {
                            IWebElement element = GlobalVariables.webDriver.FindElement(By.Id("ApplyAccessorialToShipFrom"));
                            IJavaScriptExecutor executor = (IJavaScriptExecutor)GlobalVariables.webDriver;
                            executor.ExecuteScript("arguments[0].click();", element);

                            break;
                        }
                    case "Both":
                        {
                            IWebElement element = GlobalVariables.webDriver.FindElement(By.Id("ApplyAccessorialToBoth"));
                            IJavaScriptExecutor executor = (IJavaScriptExecutor)GlobalVariables.webDriver;
                            executor.ExecuteScript("arguments[0].click();", element);

                            Click(attributeName_id, "ApplyAccessorialToBoth");
                            break;
                        }
                    case "None":
                        {
                            IWebElement element = GlobalVariables.webDriver.FindElement(By.Id("ApplyAccessorialToNone"));
                            IJavaScriptExecutor executor = (IJavaScriptExecutor)GlobalVariables.webDriver;
                            executor.ExecuteScript("arguments[0].click();", element);

                            //Click(attributeName_id, "ApplyAccessorialToNone");
                            break;
                        }
                }

            }
        }


        [Given(@"I have completed all the required fields")]
        public void GivenIHaveCompletedAllTheRequiredFields()
        {
            Click(attributeName_id, addAdditionalMgDescriptionLink_Id);
            SendKeys(attributeName_xpath, secondMGDescriptionTextbox_Accessorial_Xpath, editedAdditionalAccessorialMGDescription);




            editedAccessorialName = GetValue(attributeName_id, nameTextbox_Accessorial_Id, "value");
            editedAccessorialServiceCode = GetValue(attributeName_id, serviceCodeTextbox_Accessorial_Id, "value");
            editedAccessorialMGDescription = GetValue(attributeName_xpath, firstMGDescriptionTextbox_Accessorial_Xpath, "value");
            editedAdditionalAccessorialMGDescription = GetValue(attributeName_xpath, secondMGDescriptionTextbox_Accessorial_Xpath, "value");
            editedAccessorialServiceType = Gettext(attributeName_xpath, ".//*[@id='ServiceTypes_chosen']/ul");

        }

        [When(@"I click on the Save button in the (.*) Modal")]
        public void WhenIClickOnTheSaveButtonInTheModal(string editAccessorialModal)
        {
            Click(attributeName_id, "EditAccessorial");
        }

        [Then(@"the edits will be saved")]
        public void ThenTheEditsWillBeSaved()
        {

            accModelData = DBHelper.GetAccessorialDetails(editedAccessorialName);

            //string accessorialNameModalValueFromDB = accModelData.AccessorialName;
            Assert.AreEqual(editedAccessorialName, accModelData.AccessorialName);
            //string accessorialServiceCodeModalValueFromDB = accModelData.AccessorialCode;
            Assert.AreEqual(editedAccessorialServiceCode, accModelData.AccessorialCode);

            for (int i = 0; i < accModelData.ShipmentServiceName.Count; i++)
            {

                if (accModelData.ShipmentServiceName[i] == editedAccessorialServiceType)
                {
                    Report.WriteLine("verified Service Type updated in DB");
                }
            }


            for (int i = 0; i < accModelData.MG_Description.Count; i++)
            {

                if (accModelData.MG_Description[i] == editedAccessorialMGDescription)
                {
                    Report.WriteLine("verified MG Description updated in DB");
                }

                else if (accModelData.MG_Description[i] == editedAdditionalAccessorialMGDescription)
                {
                    Report.WriteLine("verified Additional MG Description updated in DB");
                }
                else
                {
                    Assert.Fail();
                }
            }

            mgDescriptionCount = accModelData.MG_Description.Count;
            totalMGDescription = accModelData.MG_Description.ToList();
            totalMGDescription.Sort();


            string accessorialDirectionNameFromDB = accModelData.AccessorialDirectionName;
            //if (accessorialDirection == "Ship To")
            //{
            //    Assert.AreEqual("Destination", accessorialDirectionNameFromDB);
            //}
            if (fieldToEdit == "Direction")
            {


                if (editedAccessorialServiceType == "Ship To")
                {
                    Assert.AreEqual(accessorialDirectionNameFromDB, "Destination");
                }
                else if (editedAccessorialServiceType == "Ship From")
                {
                    Assert.AreEqual(accessorialDirectionNameFromDB, "Origin");
                }
                else if (accessorialDirectionNameFromDB == "Both")
                {
                    Assert.AreEqual(accessorialDirectionNameFromDB, editedAccessorialServiceType);
                }
                else if (accessorialDirectionNameFromDB == "None")
                {
                    Assert.AreEqual(accessorialDirectionNameFromDB, editedAccessorialServiceType);
                }
            }
            else
            {
                Assert.AreEqual(accessorialDirectionNameFromDB, "Destination");
            }


        }

        [Then(@"the Configure Accessorials grid will be updated to display the edited accessorial")]
        public void ThenTheConfigureAccessorialsGridWillBeUpdatedToDisplayTheEditedAccessorial()
        {
            SendKeys(attributeName_xpath, configureAccessorialsSearchTexBox_Xpath, editedAccessorialName);
            string firstNameGridValue = Gettext(attributeName_xpath, firstNameGridValue_Xpath);
            Assert.AreEqual(firstNameGridValue, editedAccessorialName);

            string firstServiceCodeGridValue = Gettext(attributeName_xpath, firstServiceCodeValue_Xpath);
            Assert.AreEqual(firstServiceCodeGridValue, editedAccessorialServiceCode);

            //string firstMGDescriptionGridValue = Gettext(attributeName_xpath, firstMGDescriptionGridValue_Xpath);

            //List<string> accessorialMGDescriptionGridValue = new List<string>();

            //for (int i = 0; i < accessorialMGDescriptionGridValue.Count; i++)
            //{
            //    if (accessorialMGDescriptionGridValue[i] == editedAccessorialMGDescription)
            //    {
            //        Report.WriteLine("verified created MG Description updated in MG Description Grid Cloumn");
            //    }

            //    else
            //    {
            //        Assert.Fail("verified created MG Description is not updated in MG Description Grid Cloumn");
            //    }
            //}


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
                Assert.AreEqual(editedAccessorialMGDescription, firstMGDescriptionGridValue);
            }


            string firstServiceTypeGridValue = Gettext(attributeName_xpath, firstServiceTypeGridValue_Xpath);
            Assert.AreEqual(editedAccessorialServiceType.ToLower(), firstServiceTypeGridValue.ToLower());

            string firstDirectionGridValue = Gettext(attributeName_xpath, firstDirectionGridValue_Xpath);
            string accessorialDirectionNameFromDB = accModelData.AccessorialDirectionName;

            if (accessorialDirectionNameFromDB == "Origin")
            {
                Assert.AreEqual(firstDirectionGridValue, "Ship From");
            }
            else if (accessorialDirectionNameFromDB == "Destination")
            {
                Assert.AreEqual(firstDirectionGridValue, "Ship To");
            }
            else
            {
                Assert.AreEqual(firstDirectionGridValue, accessorialDirectionNameFromDB);
            }
        }


        [Given(@"I am on the (.*) modal")]
        public void GivenIAmOnTheModal(string accessorial)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            accessorial = Regex.Replace(accessorial, @"(<|>)", "");

            WaitForElementVisible(attributeName_xpath, editAccesorialModal_Xpath, accessorial);
            VerifyElementPresent(attributeName_xpath, editAccesorialModal_Xpath, accessorial);
        }

        [Given(@"I Selected any (.*) apart from ALL")]
        public void GivenISelectedAnyApartFromALL(string serviceType)
        {

            Click(attributeName_xpath, serviceTypedropdown_Accessorial_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, serviceTypedropdown_Accessorial_Xpath, "LTL");

            Click(attributeName_xpath, serviceTypedropdown_Accessorial_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, serviceTypedropdown_Accessorial_Xpath, "Truckload");

        }

        [When(@"I Select Service Type as All")]
        public void WhenISelectServiceTypeAsAll()
        {
            Click(attributeName_xpath, serviceTypedropdown_Accessorial_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, serviceTypedropdown_Accessorial_Xpath, "All");

        }

        [Then(@"the Service Type apart from All will be removed from the Service type dropdown")]
        public void ThenTheServiceTypeApartFromAllWillBeRemovedFromTheServiceTypeDropdown()
        {
            string selectedService = Gettext(attributeName_xpath, ".//*[@id='ServiceTypes_chosen']/ul");
            Assert.AreEqual("All", selectedService);
        }

        [Then(@"the Additional MG Description field is required")]
        public void ThenTheAdditionalMGDescriptionFieldIsRequired()
        {
            Clear(attributeName_xpath, secondMGDescriptionTextbox_Accessorial_Xpath);
            scrollElementIntoView(attributeName_xpath, cancelbutton_Accessrial_Xpath);
            Click(attributeName_id, "EditAccessorial");
            string actualAdditonalMGDescriptionFieldCSSValue = GetCSSValue(attributeName_xpath, secondMGDescriptionTextbox_Accessorial_Xpath, "background-color");
            string expectedAdditonalMGDescriptionFieldCSSValue = "rgba(251, 236, 237, 1)";
            Assert.AreEqual(actualAdditonalMGDescriptionFieldCSSValue, expectedAdditonalMGDescriptionFieldCSSValue);
        }



    }
}
