using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.Common;
using CRM.UITest.Helper.DataModels;
using CRM.UITest.Objects;
using CRM.UITest.Scripts.Quote.LTL_InternalUsers.GetQuote_LTL_page;
using CRM.UITest.Scripts.QuoteToShipment.LTL;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.RateToShipment.LTL.ShipmentInformationScreen
{
    [Binding]
    public class RateRequestToShipment_SavedItemDetailsSteps : AddShipments
    {
        private CommonMethodsCrm crmLogin = new CommonMethodsCrm();
        private RateToShipmentLTL rateToShipment = new RateToShipmentLTL();
        private SavedQuoteToShipment_AutoPopulateSavedItemDetailsSteps saveQuoteHelpers = new SavedQuoteToShipment_AutoPopulateSavedItemDetailsSteps();

        string verifyResultsPage = string.Empty;
        bool insuredModal;

        string classification = "70";
        string quantity = "1";
        string weight = "500";

        [Given(@"I am operations, sales, sales management or station owner user logged in to CRM Application (.*)")]
        public void GivenIAmOperationsSalesSalesManagementOrStationOwnerUserLoggedInToCRMApplication(string userType)
        {
            UserCredentialsModel userModel = new UserCredentialsModel();
            UserTypeLoginCredentials userObj = new UserTypeLoginCredentials();
            userModel = userObj.GetCredentials(userType);

            //Logging into CRM Application
            Report.WriteLine("Logging into CRM Application");
            crmLogin.LoginToCRMApplication(userModel.UserName, userModel.Password);
        }

        [Given(@"I arrive at external user Get Quote screen")]
        public void GivenIArriveAtExternalUserGetQuoteScreen()
        {

            //Go to Quote List
            GlobalVariables.webDriver.WaitForPageLoad();
            saveQuoteHelpers.NavigateToQuoteList();

            //Go to LTL shipment information page
            GlobalVariables.webDriver.WaitForPageLoad();
            saveQuoteHelpers.NavigateToShipmentInformationPageFromQuoteList(string.Empty);

            Report.WriteLine("I am on the Get Quote LTL Page");
            VerifyElementPresent(attributeName_xpath, LTLpagetitle_xpath, "Get Quote (LTL)");
        }

        [Given(@"I enter Address data in Get Quote LTL Page")]
        public void GivenIEnterAddressDataInGetQuoteLTLPage()
        {
            //Enter Address information           
            saveQuoteHelpers.EnterAddressData();
        }

        [Given(@"I select a saved item (.*)")]
        public void GivenISelectASavedItem(string item)
        {
            //Enter Item Information
            saveQuoteHelpers.EnterItemInformation(item);
        }

        [Given(@"I Modify Weight field (.*)")]
        public void GivenIModifyWeightField(string weight)
        {
            Report.WriteLine("Modify Length field to " + weight);
            SendKeys(attributeName_id, weight_id, weight);
        }

        [Given(@"I Modify Quantity field (.*)")]
        public void GivenIModifyQuantityField(string quantity)
        {
            Report.WriteLine("Modify Length field to " + quantity);
            SendKeys(attributeName_id, Quantity_id, quantity);
        }

        [Given(@"I arrive at Quote Results screen")]
        public void GivenIArriveAtQuoteResultsScreen()
        {
            try
            {
                //Click on View Rates
                Click(attributeName_id, LTL_ViewQuoteResults_Id);
            }
            catch
            {
                GlobalVariables.webDriver.WaitForPageLoad();
            }
        }

        [Given(@"I click on Create Shipment button for External User")]
        public void GivenIClickOnCreateShipmentButtonForExternalUser()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            rateToShipment.ClickOnCreateShipmentbutton_Quote("External");
        }

        [Given(@"I click on Create Insured Shipment button for External User")]
        public void GivenIClickOnCreateInsuredShipmentButtonForExternalUser()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            rateToShipment.ClickOnCreateInsuredShipmentbutton_Quote("External");
        }

        [Given(@"I click on Create Shipment button for Internal User")]
        public void GivenIClickOnCreateShipmentButtonForInternalUser()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            rateToShipment.ClickOnCreateShipmentbutton_Quote("Internal");
        }

        [Given(@"I click on Create Insured Shipment button for Internal User")]
        public void GivenIClickOnCreateInsuredShipmentButtonForInternalUser()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            rateToShipment.ClickOnCreateInsuredShipmentbutton_Quote("Internal");
        }

        [Then(@"Saved item details are auto-populated in the Freight Description section (.*) (.*)")]
        public void ThenSavedItemDetailsAreAuto_PopulatedInTheFreightDescriptionSection(string customerName, string item)
        {
            Item itemDetails = DBHelper.GetItem(customerName, item);

            Report.WriteLine("Verification that the NMFC code is auto - populated in Add Shipment Page from Saved quote");
            scrollElementIntoView(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id);

            string nmfc = GetValue(attributeName_id, FreightDesp_FirstItem_NMFC_Id, "value");
            itemDetails.NmfcCode = string.IsNullOrWhiteSpace(itemDetails.NmfcCode) ? string.Empty : itemDetails.NmfcCode;
            Assert.AreEqual(itemDetails.NmfcCode, nmfc);

            Report.WriteLine("Verification that the Item Description is auto - populated in Add Shipment Page from Saved quote");
            string itemDescription = GetValue(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id, "value");
            itemDetails.ItemDescription = string.IsNullOrWhiteSpace(itemDetails.ItemDescription) ? string.Empty : itemDetails.ItemDescription;
            Assert.AreEqual(itemDetails.ItemDescription.ToUpper(), itemDescription?.ToUpper());

            Report.WriteLine("Verification that the Item Length is auto - populated in Add Shipment Page from Saved quote");
            string length = GetValue(attributeName_id, FreightDesp_FirstItem_Length_Id, "value");
            itemDetails.Length = (itemDetails.Length == null) ? 0 : itemDetails.Length;
            Assert.AreEqual(itemDetails.Length.ToString(), length);

            Report.WriteLine("Verification that the Item Width is auto - populated in Add Shipment Page from Saved quote");
            string width = GetValue(attributeName_id, FreightDesp_FirstItem_Width_Id, "value");
            itemDetails.Width = (itemDetails.Width == null) ? 0 : itemDetails.Width;
            Assert.AreEqual(itemDetails.Width.ToString(), width);

            Report.WriteLine("Verification that the Item Height is auto - populated in Add Shipment Page from Saved quote");
            string height = GetValue(attributeName_id, FreightDesp_FirstItem_Height_Id, "value");
            itemDetails.Height = (itemDetails.Height == null) ? 0 : itemDetails.Height;
            Assert.AreEqual(itemDetails.Height.ToString(), height);

            Report.WriteLine("Verification that the Item Height is auto - populated in Add Shipment Page from Saved quote");
            string dimensionUnit = Gettext(attributeName_xpath, FreightDesp_FirstItem_DimensionType_SelectedValue_xpath);
            itemDetails.DimensionUnit = string.IsNullOrWhiteSpace(itemDetails.DimensionUnit) ? string.Empty : itemDetails.DimensionUnit;
            Assert.AreEqual(itemDetails.DimensionUnit.ToUpper(), dimensionUnit.ToUpper());
        }

        [Then(@"Hazardous material details are auto-populated in the Freight Description Hazmat section (.*) (.*)")]
        public void ThenHazardousMaterialDetailsAreAuto_PopulatedInTheFreightDescriptionHazmatSection(string customerName, string item)
        {
            Item itemDetails = DBHelper.GetItem(customerName, item);

            Report.WriteLine("Verification that the Hazardous material details section is expanded and the fields are required");
            scrollElementIntoView(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id);

            Report.WriteLine("Verification that the Hazardous material is checked as Yes");
            object hazMatValue = ((IJavaScriptExecutor)GlobalVariables.webDriver).ExecuteScript("return $('[name=\"Hazard-0_Hazard-0\"]:checked').val()");
            Assert.AreEqual("Yes", hazMatValue?.ToString());

            Report.WriteLine("Verification that the UN Number field is required");
            itemDetails.UnNumber = string.IsNullOrWhiteSpace(itemDetails.UnNumber) ? string.Empty : itemDetails.UnNumber;
            Assert.AreEqual(itemDetails.UnNumber, GetValue(attributeName_id, FreightDesp_FirstItem_UN_Number_Id, "value"));

            Report.WriteLine("Verification that the CCN Number field is required");
            itemDetails.CcnNumber = string.IsNullOrWhiteSpace(itemDetails.CcnNumber) ? string.Empty : itemDetails.CcnNumber;
            Assert.AreEqual(itemDetails.CcnNumber, GetValue(attributeName_id, FreightDesp_FirstItem_CCN_Number_Id, "value"));

            Report.WriteLine("Verification that the Hazardous materail Classification field is required");
            itemDetails.HazMatClass = string.IsNullOrWhiteSpace(itemDetails.HazMatClass) ? string.Empty : itemDetails.HazMatClass;
            Assert.AreEqual(itemDetails.HazMatClass, Gettext(attributeName_xpath, FreightDesp_FirstItem_SelectHazmatClass_DropwDown_xpath));

            Report.WriteLine("Verification that the Hazardous materail Packaging group field is required");
            itemDetails.HazMatPackagingGroup = string.IsNullOrWhiteSpace(itemDetails.HazMatPackagingGroup) ? string.Empty : itemDetails.HazMatPackagingGroup;
            Assert.AreEqual(itemDetails.HazMatPackagingGroup, Gettext(attributeName_xpath, FreightDesp_FirstItem_SelectHazmatPackageGroup_DownDown_xpath));

            Report.WriteLine("Verification that the EmergencyContactPhone field is required");
            itemDetails.EmergencyPhoneNumber = string.IsNullOrWhiteSpace(itemDetails.EmergencyPhoneNumber) ? string.Empty : itemDetails.EmergencyPhoneNumber;
            Assert.AreEqual(itemDetails.EmergencyPhoneNumber, GetValue(attributeName_id, FreightDesp_FirstItem_EmergencyReponsePhoneNumber_Id, "value"));

            Report.WriteLine("Verification that the EmergencyContactName field is required");
            itemDetails.EmergencyContactName = string.IsNullOrWhiteSpace(itemDetails.EmergencyContactName) ? string.Empty : itemDetails.EmergencyContactName;
            Assert.AreEqual(itemDetails.EmergencyContactName, GetValue(attributeName_id, FreightDesp_FirstItem_EmergencyReponseContactName_Id, "value"));
        }

        [Then(@"Hazardous material is selected as NO")]
        public void ThenHazardousMaterialIsSelectedAsNO()
        {
            Report.WriteLine("Verification that the Hazardous material is checked as No");
            scrollElementIntoView(attributeName_xpath, FreightDesp_FirstItem_Hazardous_No_RadioButton_xpath);
            object hazMatValue = ((IJavaScriptExecutor)GlobalVariables.webDriver).ExecuteScript("return $('[name=\"Hazard-0_Hazard-0\"]:checked').val()");
            Assert.AreEqual("No", hazMatValue?.ToString());
        }

        [Given(@"I arrive at internal user Get Quote screen (.*)")]
        public void GivenIArriveAtInternalUserGetQuoteScreen(string customerAccount)
        {
            Report.WriteLine("Select Customer Name from the dropdown list");

            //Go to Quote List
            GlobalVariables.webDriver.WaitForPageLoad();
            saveQuoteHelpers.NavigateToQuoteList();

            //Go to LTL shipment information page
            GlobalVariables.webDriver.WaitForPageLoad();
            saveQuoteHelpers.NavigateToShipmentInformationPageFromQuoteList(customerAccount);

            Report.WriteLine("I am on the Get Quote LTL Page");
            VerifyElementPresent(attributeName_xpath, LTLpagetitle_xpath, "Get Quote (LTL)");
        }

        [Given(@"I enter Insured Value (.*)")]
        public void GivenIEnterInsuredValue(string shipmentValue)
        {
            Report.WriteLine("Enter Shipment Value");
            SendKeys(attributeName_id, InsuredValue_id, shipmentValue);
        }

        [Given(@"I am User with access to Rate To Shipment Process")]
        public void GivenIAmUserWithAccessToRateToShipmentProcess()
        {
            string username = ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();
            string password = ConfigurationManager.AppSettings["ExternalUserPassword"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"I arrive at Get Quote\(LTL\) screen")]
        public void GivenIArriveAtGetQuoteLTLScreen()
        {
            if (Gettext(attributeName_xpath, ExternalUserDashboardErrorMessageHeader_Xpath) == "Error")
            {
                Click(attributeName_id, ExternalUserErrorMessageCloseButton_Id);
                Thread.Sleep(1000);
                //GlobalVariables.webDriver.WaitForPageLoad();                
                saveQuoteHelpers.NavigateToQuoteList();
                Report.WriteLine("I have clicked on Submit Rate Request button");
                GlobalVariables.webDriver.WaitForPageLoad();
                Click(attributeName_id, SubmitRateRequestBtn_id);
                GlobalVariables.webDriver.WaitForPageLoad();
                Click(attributeName_id, GetQuote_LTLLabel_Id);
            }
            else
            {
                GlobalVariables.webDriver.WaitForPageLoad();
                saveQuoteHelpers.NavigateToQuoteList();
                Report.WriteLine("I have clicked on Submit Rate Request button");
                GlobalVariables.webDriver.WaitForPageLoad();
                Click(attributeName_id, SubmitRateRequestBtn_id);
                GlobalVariables.webDriver.WaitForPageLoad();
                Click(attributeName_id, GetQuote_LTLLabel_Id);
            }
        }

        [Given(@"I enter the Item details (.*),(.*),(.*)")]
        public void GivenIEnterTheItemDetails(string Classification, string Quantity, string Weight)
        {
            scrollElementIntoView(attributeName_id, LTL_Weight_Id);
            Click(attributeName_id, LTL_ClearItem_Id);
            scrollElementIntoView(attributeName_xpath, LTL_Quote_AdditionalItem_button_Xpath);
            Click(attributeName_id, LTL_Classification_Id);
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(LTL_ClassificationValues_Xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == classification)
                {
                    DropDownList[i].Click();
                    break;
                }
            }
            SendKeys(attributeName_id, LTL_Quan_Id, quantity);
            SendKeys(attributeName_id, LTL_Weight_Id, weight);
        }

        [Given(@"I Click on Create Shipment button")]
        public void GivenIClickOnCreateShipmentButton()
        {
            string configURL = launchUrl;
            string resultPagrURL = configURL + "Rate/LtlResultsView";
            if (GetURL() == resultPagrURL)
            {
                Report.WriteLine("Rate Results available");
                Report.WriteLine("Create shipment for selected carrier");
                WaitForElementVisible(attributeName_xpath, Quote_FirstCreateShipment_Xpath, "Create Shipment");
                Click(attributeName_xpath, Quote_FirstCreateShipment_Xpath);
                verifyResultsPage = "With Results";
            }
            else
            {
                verifyResultsPage = "No Results";
            }
        }

        [Given(@"the Insured Modal popUp Appears")]
        public void GivenTheInsuredModalPopUpAppears()
        {
            if (verifyResultsPage == "With Results")
            {
                GlobalVariables.webDriver.WaitForPageLoad();
                Thread.Sleep(2000);

                insuredModal = GlobalVariables.webDriver.FindElement(By.XPath("//div[@id='insuredCreateShipmentModal']//div[@class='modal-content']")).Displayed;
                if (insuredModal)
                {
                    WaitForElementVisible(attributeName_xpath, ".//h3[contains(text(), 'Insured Rates')]", "Insured Rates Modal PopUp");
                    Verifytext(attributeName_xpath, ".//h3[contains(text(), 'Insured Rates')]", "Insured Rates");
                }
            }
            else
            {
                Report.WriteLine("No Rate Results page");
            }
        }

        [Given(@"I click the Continue without Insured Rates button")]
        public void GivenIClickTheContinueWithoutInsuredRatesButton()
        {
            if (verifyResultsPage == "With Results")
            {
                if (insuredModal)
                {
                    Click(attributeName_id, QuoteContinueWithoutInsuredRates_Id);
                }
            }
            else
            {
                Report.WriteLine("No Rate Results page");
            }
        }

        [Then(@"I will see (.*),(.*),(.*) will be binded in the Freight Description section with data from Get Quote\(LTL\) page")]
        public void ThenIWillSeeWillBeBindedInTheFreightDescriptionSectionWithDataFromGetQuoteLTLPage(string Classification, string Quantity, string Weight)
        {
            if (verifyResultsPage == "With Results")
            {
                scrollElementIntoView(attributeName_id, PickUpDateCalender_Id);
                string actualClassification = GetValue(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id, "value");
                Assert.AreEqual(classification, actualClassification);

                string actualQuantity = GetValue(attributeName_id, FreightDesp_FirstItem_Quantity_Id, "value");
                Assert.AreEqual(quantity, actualQuantity);

                string actualQuantityType = Gettext(attributeName_xpath, ".//*[@id='freightquantitytype_0_chosen']/a");
                Assert.AreEqual("Skids", actualQuantityType);

                string actualWeight = GetValue(attributeName_id, FreightDesp_FirstItem_Weight_Id, "value");
                Assert.AreEqual(weight, actualWeight);
            }
            else
            {
                Report.WriteLine("Unable to Verify Rate to Shipment since its No Rate Results page");
            }
        }

    }
}
