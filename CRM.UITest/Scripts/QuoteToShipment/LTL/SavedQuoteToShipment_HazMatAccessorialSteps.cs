using System.Collections.Generic;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.QuoteToShipment.LTL
{
    [Binding]
    public class SavedQuoteToShipment_HazMatAccessorialSteps : AddShipments
    {
        private SavedQuoteToShipment_AutoPopulateSavedItemDetailsSteps saveQuoteHelpers = new SavedQuoteToShipment_AutoPopulateSavedItemDetailsSteps();
        private static string savedQuoteNumber = string.Empty;

        [Given(@"I have a quote with Saved Item with Hazmat as accessorial for External user (.*)")]
        public void GivenIHaveAQuoteWithSavedItemWithHazmatAsAccessorialForExternalUser(string item)
        {
            CreateQuoteForGivenItem(string.Empty, item);
        }

        [Then(@"the Hazardous Materials Yes button will be checked")]
        public void ThenTheHazardousMaterialsYesButtonWillBeChecked()
        {
            Report.WriteLine("Verification that the Hazardous material is checked as Yes");
            scrollElementIntoView(attributeName_xpath, FreightDesp_FirstItem_Hazardous_Yes_RadioButton_xpath);
            object hazMatValue = ((IJavaScriptExecutor)GlobalVariables.webDriver).ExecuteScript("return $('[name=\"Hazard-0_Hazard-0\"]:checked').val()");
            Assert.AreEqual("Yes", hazMatValue?.ToString());
        }

        [Then(@"I am unable to edit the Hazardous Materials to No")]
        public void ThenIAmUnableToEditTheHazardousMaterialsToNo()
        {
            bool hazMatNoCheckbox = IsElementDisabled(attributeName_xpath, FreightDesp_FirstItem_Hazardous_No_RadioButton_xpath, "HazmatRadioButton");
            Report.WriteLine("Verification that the Hazardous material is not editable to No");
            Assert.IsTrue(hazMatNoCheckbox);
        }

        [Then(@"the Hazardous Materials section in the Add Shipment Page is expanded")]
        public void ThenTheHazardousMaterialsSectionInTheAddShipmentPageIsExpanded()
        {
            Report.WriteLine("Verification that the Hazardous material details section is expanded and the fields are required");
            Report.WriteLine("Verification that the UN Numebr field is required");
            Assert.IsTrue(IsElementVisible(attributeName_id, FreightDesp_FirstItem_UN_Number_Id, "UNNumber"));

            Report.WriteLine("Verification that the CCN Number field is required");
            Assert.IsTrue(IsElementVisible(attributeName_id, FreightDesp_FirstItem_CCN_Number_Id, "CCNNumber"));

            Report.WriteLine("Verification that the Hazardous materail Classification field is required");
            Assert.IsTrue(IsElementVisible(attributeName_xpath, FreightDesp_FirstItem_SelectHazmatClass_DropwDown_xpath, "HazmatClass"));

            Report.WriteLine("Verification that the Hazmat Packaging Group field is required");
            Assert.IsTrue(IsElementVisible(attributeName_xpath, FreightDesp_FirstItem_SelectHazmatPackageGroup_DownDown_xpath, "HazmatPackagingGroup"));

            Report.WriteLine("Verification that the EmergencyContactPhone field is required");
            Assert.IsTrue(IsElementVisible(attributeName_id, FreightDesp_FirstItem_EmergencyReponsePhoneNumber_Id, "EmergencyContactPhone"));

            Report.WriteLine("Verification that the EmergencyContactName field is required");
            Assert.IsTrue(IsElementVisible(attributeName_id, FreightDesp_FirstItem_EmergencyReponseContactName_Id, "EmergencyContactName"));
        }

        [Given(@"I have a quote with Saved Item with Hazmat as accessorial for Internal user (.*) (.*)")]
        public void GivenIHaveAQuoteWithSavedItemWithHazmatAsAccessorialForInternalUser(string customerName, string item)
        {
            CreateQuoteForGivenItem(customerName, item);
        }

        [Given(@"I am in the Quote Details Section of a LTL non expired quote with Saved Item For External user")]
        public void GivenIAmInTheQuoteDetailsSectionOfALTLNonExpiredQuoteWithSavedItemForExternalUser()
        {
            //Go to Quote List
            Report.WriteLine("Clicking on quote module icon");
            saveQuoteHelpers.NavigateToQuoteList();

            //Search for the quote number with saved item
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_id, "searchbox", savedQuoteNumber);

            //Click on Expand Quote          
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, QuoteExpand_Xpath);
        }

        [Given(@"I am in the Quote Details Section of a LTL non expired quote with Saved Item For Internal user (.*)")]
        public void GivenIAmInTheQuoteDetailsSectionOfALTLNonExpiredQuoteWithSavedItemForInternalUser(string customerName)
        {
            //Go to Quote List
            Report.WriteLine("Clicking on quote module icon");
            saveQuoteHelpers.NavigateToQuoteList();
            GlobalVariables.webDriver.WaitForPageLoad();
            saveQuoteHelpers.SelectCustomerInQuoteList(customerName);

            //Search for the quote number with saved item
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_id, "searchbox", savedQuoteNumber);

            //Click on Expand Quote          
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, QuoteExpandInternal_Xpath);
        }

        private void CreateQuoteForGivenItem(string customerName, string item)
        {
            //Go to Quote List
            saveQuoteHelpers.NavigateToQuoteList();

            //Go to LTL shipment information page
            GlobalVariables.webDriver.WaitForPageLoad();
            saveQuoteHelpers.NavigateToShipmentInformationPageFromQuoteList(customerName);

            //Enter Address and Item Information
            GlobalVariables.webDriver.WaitForPageLoad();
            saveQuoteHelpers.EnterAddressData();
            saveQuoteHelpers.EnterItemInformation(item);

            //Enter Accessorials
            EnterServicesAndAccessorials("Hazardous Material");

            //Click on View Rates
            GlobalVariables.webDriver.WaitForPageLoad();
            saveQuoteHelpers.ViewQuoteResults();

            //Create Quote
            GlobalVariables.webDriver.WaitForPageLoad();
            saveQuoteHelpers.CreateQuote(customerName);

            //Set the Quote Number
            GlobalVariables.webDriver.WaitForPageLoad();
            savedQuoteNumber = Gettext(attributeName_id, QC_RequestNumber_id);
        }

        private void EnterServicesAndAccessorials(string accessorial)
        {
            //Enter Services and Accessorials Information
            Click(attributeName_xpath, LTL_ServicesAndAccessorials_ShipFrom_Text_Xpath);

            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, LTL_ServicesDropdownValues_ShipFrom_Xpath, "Services and accessorials dropdown");

            IList<IWebElement> accessorialsDropDownList = GlobalVariables.webDriver.FindElements(By.XPath(LTL_ServicesDropdownValues_ShipFrom_Xpath));
            int accessorialsDropDownCount = accessorialsDropDownList.Count;

            for (int i = 0; i < accessorialsDropDownCount; i++)
            {
                if (accessorialsDropDownList[i].Text == accessorial)
                {
                    accessorialsDropDownList[i].Click();
                    break;
                }
            }
        }
    }
}
