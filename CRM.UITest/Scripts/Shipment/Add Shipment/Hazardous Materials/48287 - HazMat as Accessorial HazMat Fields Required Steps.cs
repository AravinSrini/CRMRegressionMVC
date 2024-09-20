using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.Hazardous_Materials
{
    [Binding]
    public sealed class _48287___Auto_Select_HazMat_as_Accessorial_Steps : AddShipments
    {
        GetChosenAccessorials getChosenAccessorials = new GetChosenAccessorials();

        [Given(@"I am an admin user ""(.*)"" ""(.*)""")]
        [Given(@"I am a sales, sales management, operations, station owner, pricing config, or system config user ""(.*)"" ""(.*)""")]
        [Given(@"I am a sales, sales management, operations, station owner, pricing config, system config, or config manager user ""(.*)"" ""(.*)""")]
        [Given(@"that I am a shp.entry, shp.entrynorates, sales, sales management, operations, or station owner user ""(.*)"" ""(.*)""")]
        [Given(@"I am a shp\.inquiry, shp\.inquirynorates, shp\.entry, shp\.entrynorates, sales, sales management, operations, or a station owner (.*) (.*)")]
        [Given(@"I am a shp\.inquiry, shp\.inquirynorates, shp\.entry or shp\.entrynorates user ""(.*)"" ""(.*)""")]
        public void GivenThatIAmAShp_EntryShp_EntrynoratesSalesSalesManagementOperationsOrStationOwnerUser(string Username, string Password)
        {
            CommonMethodsCrm crm = new CommonMethodsCrm();
            string username = ConfigurationManager.AppSettings[Username].ToString();
            string password = ConfigurationManager.AppSettings[Password].ToString();
            Report.WriteLine("Logging in as " + username);
            crm.LoginToCRMApplication(username, password);
        }

        [Given(@"I am on the Add Shipment \(LTL\) page ""(.*)""")]
        [Given(@"I am on the Add Shipment \(LTL\) page as a customer who has a default item that is flagged as a hazardous material ""(.*)""")]
        [When(@"I am on the Add Shipment \(LTL\) page as a customer who has a default item that is flagged as a hazardous material ""(.*)""")]
        public void GivenIAmOnTheAddShipmentLTLPage(string customerName)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Clicked on Shipments icon");
            Click(attributeName_id, ShipmentIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();

            Click(attributeName_xpath, AllCustomerDropdown_Selection_Internal_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, AllCustomerDroppdownValues_Internal_Xpath, customerName);

            Report.WriteLine("Clicked on Add Shipment button");
            WaitForElementVisible(attributeName_id, AddShipmentButtionInternal_Id, "Add shipment button");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, AddShipmentButtionInternal_Id);
            GlobalVariables.webDriver.WaitForPageLoad();

            Report.WriteLine("Clicked on LTL tile");
            Click(attributeName_id, AddShipmentLTL_Button_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
        }


        [Given(@"I choose the accessorial Hazardous Materials in the Click to add services & accessorials field in from or to (.*)")]
        [When(@"I choose the accessorial Hazardous Materials in the Click to add services & accessorials field in from or to (.*)")]
        public void WhenIChooseTheAccessorialHazardousMaterialsInTheClickToAddServicesAccessorialsFieldInFromOrTo(string location)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, LTLAddShipment_SelectedAccessorial_ShippingFrom_Xpath, "Accessorial");
            Report.WriteLine("Selecting Hazardous Materials accessorial");
            if (location.Equals("from"))
            {
                WaitForElementVisible(attributeName_xpath, LTLAddShipment_SelectedAccessorial_ShippingFrom_Xpath, "Shipping From Accessorial Dropdown");
                GlobalVariables.webDriver.WaitForPageLoad();
                scrollPageup();
                Click(attributeName_xpath, LTLAddShipment_SelectedAccessorial_ShippingFrom_Xpath);
                SendKeys(attributeName_xpath, ShippingFrom_ServicesAccessorial_DropDown_xpath, "Hazardous Material");
                SelectDropdownValueFromList(attributeName_xpath, LTLAddShipment_SelectedAccessorial_ShippingFrom_Xpath, "Hazardous Material");
            }
            else
            {
                WaitForElementVisible(attributeName_xpath, Overlength_ShippingTo_ServicesAccessorial_DropDown_xpath, "Shipping From Accessorial Dropdown");
                GlobalVariables.webDriver.WaitForPageLoad();
                scrollPageup();
                Click(attributeName_xpath, Overlength_ShippingTo_ServicesAccessorial_DropDown_xpath);
                SendKeys(attributeName_xpath, Overlength_ShippingTo_ServicesAccessorial_DropDown_xpath, "Hazardous Material");
                SelectDropdownValueFromList(attributeName_xpath, Overlength_ShippingTo_ServicesAccessorial_DropDown_xpath, "Hazardous Material");                
            }
            Thread.Sleep(500);
        }

        [Given(@"I choose a saved item that is flagged as a hazardous material")]
        [When(@"I choose a saved item that is flagged as a hazardous material")]
        public void GivenIChooseASavedItemThatIsFlaggedAsAHazardousMaterial()
        {
            Click(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            
            SendKeys(attributeName_xpath, FreightDesp_FirstItem_SavedClassItem_DropDown_Xpath, "HAZMAT ITEM");
            Thread.Sleep(1000);
            Click(attributeName_xpath, FreightDesp_FirstItem_SavedClassItem_DropDown_Values_xpath);
        }


        [When(@"I choose the Hazardous Materials No option in the Freight Description section")]
        public void WhenIChooseTheHazardousMaterialsNoOptionInTheFreightDescriptionSection()
        {
            Report.WriteLine("Clicking the hazardous material no option");
            Click(attributeName_xpath, "//*[@id='0']/div[4]/div/div[1]/div/div/div/div/div[2]/label");
        }

        [When(@"the Hazardous Materials yes option is selected")]
        public void WhenTheHazardousMaterialsYesOptionIsSelected()
        {
            Report.WriteLine("Clicking the hazardous material yes option");
            Click(attributeName_xpath, FreightDesp_FirstItem_Hazardous_Yes_RadioButton_xpath);
        }

        [When(@"I remove the Hazardous Materials accessorial")]
        public void WhenIRemoveTheHazardousMaterialsAccessorial()
        {
            Report.WriteLine("Removing Hazardous Material accessorial from shipping from and shipping to");

            scrollPageup();
            int counter = 0;

            IList<IWebElement> chosenShippingFromAccessorials = getChosenAccessorials.GetShippingFromChosenAccessorials();

            foreach (IWebElement accessorial in chosenShippingFromAccessorials)
            {
                counter++;
                if (accessorial.FindElement(By.TagName("span")).Text.Equals("Hazardous Material"))
                {
                    break;
                }
                
            }

            if (counter > 0)
            {
                Click(attributeName_xpath, "//*[@id='shippingfromaccessorial_chosen']/ul/li[" + counter + "]/a");
            }

            counter = 0;

            IList<IWebElement> chosenShippingToAccessorials = getChosenAccessorials.GetShippingToChosenAccessorials();

            foreach(IWebElement accessorial in chosenShippingToAccessorials)
            {
                counter++;
                if (accessorial.FindElement(By.TagName("span")).Text.Equals("Hazardous Material"))
                {
                    break;
                }

            }

            if (counter > 0)
            {
                Click(attributeName_xpath, "//*[@id='shippingtoaccessorial_chosen']/ul/li["+ counter + "]/a");
            }
        }
                     
        [Given(@"the Hazardous Materials Yes option was auto-selected in the Freight Description section")]
        [When(@"the Hazardous Materials Yes option was auto-selected in the Freight Description section")]
        [Then(@"the Hazardous Materials Yes option will be auto-selected in the Freight Description section")]
        public void ThenTheHazardousMaterialsYesOptionWillBeAuto_SelectedInTheFreightDescriptionSection()
        {
            VerifyElementChecked(attributeName_id, "Hazard-0_Hazard-0Yes", "Hazardous Yes Option");
            Thread.Sleep(500);
            Report.WriteLine("Hazardous material yes option was selected");
        }

        [Then(@"the Hazardous Materials No option will be auto-selected in the Freight Description section")]
        public void ThenTheHazardousMaterialsNoOptionWillBeAuto_SelectedInTheFreightDescriptionSection()
        {
            Assert.IsTrue(GlobalVariables.webDriver.FindElement(By.XPath(FreightDesp_FirstItem_Hazardous_No_RadioButton_xpath)).Selected);
            Thread.Sleep(500);
            Report.WriteLine("All hazardous material no option was selected");
        }

        [Then(@"the Hazardous Materials details section will be expanded")]
        public void ThenTheHazardousMaterialsDetailsSectionWillBeExpanded()
        {
            VerifyElementVisible(attributeName_cssselector, Hazardous_Materials_Section_Selector, "Hazardous materials section");
            Report.WriteLine("The hazardous material section was expanded");
        }

        [Then(@"I have the option to select the hazardous material accessorial")]
        public void ThenIHaveTheOptionToSelectTheHazardousMaterialAccessorial()
        {
            scrollPageup();
            Click(attributeName_xpath, ShippingFrom_ServicesAccessorial_DropDown2_xpath);
            SendKeys(attributeName_xpath, ShippingFrom_ServicesAccessorial_DropDown_xpath, "Hazardous Material");
            IList<IWebElement> accessorialList = GlobalVariables.webDriver.FindElements(By.XPath(ShippingFrom_Accessorial_List_xpath));

            if(accessorialList.Count < 1)
            {
                Report.WriteFailure("Unable to select the hazardous material accessorial");
            }
        }

        [Then(@"the hazarous material accessorial will be removed from the accessorial field from either shipping from or to")]
        public void ThenTheAccessorialWillBeRemovedFromTheAccessorialFieldFromEitherShippingFromOrTo()
        {
            Thread.Sleep(500);
            IList<IWebElement> chosenShippingFromAccessorials = getChosenAccessorials.GetShippingFromChosenAccessorials();

            foreach (IWebElement accessorial in chosenShippingFromAccessorials)
            {
                if(accessorial.FindElement(By.TagName("span")).Text.Equals("Hazardous Material"))
                {
                    Report.WriteFailure("Hazardous Material accessorial was not removed from shipping from");
                }
            }

            IList<IWebElement> chosenShippingToAccessorials = GlobalVariables.webDriver.FindElements(By.XPath("//*[@id='shippingtoaccessorial_chosen']/ul/li[@class='search-choice']"));
            foreach (IWebElement accessorial in chosenShippingFromAccessorials)
            {
                if (accessorial.FindElement(By.TagName("span")).Text.Equals("Hazardous Material"))
                {
                    Report.WriteFailure("Hazardous Material accessorial was not removed from shipping to");
                }
            }
            Report.WriteLine("Test Passed: Hazardous Material Accessorial was removed");
        }

        [Then(@"the Hazardous Materials details section will be collapsed")]
        public void ThenTheHazardousMaterialsDetailsSectionWillBeCollapsed()
        {
            VerifyElementNotVisible(attributeName_cssselector, Hazardous_Materials_Section_Selector, "Hazardous ");
            Report.WriteLine("Test Passed: All hazardous material section was collapsed");
        }

        [Then(@"any input data in the section will be removed")]
        public void ThenAnyInputDataInTheSectionWillBeRemoved()
        {
            IList<IWebElement> hazardousMaterialInputs = GetHazardousMaterialInputs();

            foreach (IWebElement input in hazardousMaterialInputs)
            {
                if (!input.Text.Equals(""))
                {
                    Report.WriteFailure("Hazardous material input was not emptied");
                }
            }

            Report.WriteLine("Test Passed: All hazardous material inputs were empty");
        }

        [Then(@"the hazardous material input fields are no longer required")]
        public void ThenTheHazardousMaterialInputFieldsAreNoLongerRequired()
        {
            Report.WriteLine("All hazardous inputs cleared");

            Click(attributeName_xpath, Shipments_ViewRatesButton_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            VerifyElementNotPresent(attributeName_xpath, "//*[@id='page-content-wrapper']/[*[contains(., 'Add Shipment (LTL)')]]", "Add shipment ltl title");
        }

        [Then(@"all of the fields in the Hazardous Materials details section will be required")]
        public void ThenAllOfTheFieldsInTheHazardousMaterialsDetailsSectionWillBeRequired()
        {
            Report.WriteLine("All hazardous inputs cleared");

            Click(attributeName_xpath, Shipments_ViewRatesButton_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();

            string ExpectedbackgroundColor = "url(\"http://dlsww-test.rrd.com/images/formicons.png\"), linear-gradient(rgb(251, 236, 236), rgb(251, 236, 236))";
            Report.WriteLine("I should be able to see all required field background color in red ");
            string ActualUNbackgroundColor = GetCSSValue(attributeName_id, FreightDesp_FirstItem_CCN_Number_Id, "background-image");
            Assert.AreEqual(ExpectedbackgroundColor, ActualUNbackgroundColor, true, CultureInfo.CurrentCulture);

            string ActualCCNbackgroundColor = GetCSSValue(attributeName_id, FreightDesp_FirstItem_UN_Number_Id, "background-image");
            Assert.AreEqual(ExpectedbackgroundColor, ActualCCNbackgroundColor, true, CultureInfo.CurrentCulture);

            string ExpectedbackgrounddrpColor = "url(\"http://dlsww-test.rrd.com/Content/images/formicons.png\"), linear-gradient(rgb(251, 236, 236), rgb(251, 236, 236))";
            string ActualHazMatpackagegrpbackgroundColor = GetCSSValue(attributeName_xpath, "//*[@id='Hazmatpackagegroup_0_chosen']/a", "background-image");
            Assert.AreEqual(ExpectedbackgrounddrpColor, ActualHazMatpackagegrpbackgroundColor, true, CultureInfo.CurrentCulture);

            string ActualHazMatClassbackgroundColor = GetCSSValue(attributeName_xpath, FreightDesp_FirstItem_SelectHazmatClass_DropwDown_xpath, "background-image");
            Assert.AreEqual(ExpectedbackgrounddrpColor, ActualHazMatClassbackgroundColor, true, CultureInfo.CurrentCulture);

            string ActualResponsecntctbackgroundColor = GetCSSValue(attributeName_id, FreightDesp_FirstItem_EmergencyReponseContactName_Id, "background-image");
            Assert.AreEqual(ExpectedbackgroundColor, ActualResponsecntctbackgroundColor, true, CultureInfo.CurrentCulture);

            string ActualEmergencyphonebackgroundColor = GetCSSValue(attributeName_id, FreightDesp_FirstItem_EmergencyReponsePhoneNumber_Id, "background-image");
            Assert.AreEqual(ExpectedbackgroundColor, ActualEmergencyphonebackgroundColor, true, CultureInfo.CurrentCulture);
        }


        private IList<IWebElement> GetHazardousMaterialInputs()
        {
            IList<IWebElement> hazardousMaterialInputs = GlobalVariables.webDriver.FindElements(By.XPath("//div[@class='hazmat-section-0 container-fluid']/div/div/div/div/div/div/div"));

            return hazardousMaterialInputs;
        }       
    }
}