using CRM.UITest.CommonMethods;
using CRM.UITest.Helper.Common;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Configuration;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Csr.CsrDetails
{
    [Binding]
    public sealed class _96965___Inherit_Default_Accessorial___CSR_Details_Steps : Submit_CSR
    {
        ClickAndWaitMethods clickMethods = new ClickAndWaitMethods();
        [Given(@"I am on the CSR List screen")]
        public void GivenIAmOnTheCSRListScreen()
        {
            Report.WriteLine("Navigating to CSR List");
            string baseURL = ConfigurationManager.AppSettings["BaseUrl"];
            GlobalVariables.webDriver.Url = baseURL + "/L/Csr/CsrList";
        }

        [Given(@"I am on the CSR Details screen for the CSR ""(.*)""")]
        public void GivenIAmOnTheCSRDetailsScreenForTheCSR(string csrName)
        {
            Report.WriteLine("Searching for csrName");
            SendKeys(attributeName_xpath, CSRList_Searchbox_Xpath, csrName);
            Thread.Sleep(500);

            Report.WriteLine("Click on CSR Name");
            Click(attributeName_xpath, CsrList_First_Name_On_List_Xpath);
        }

        [Given(@"I am on the CSR Details screen for the CSR: (.*)")]
        public void GivenIAmOnTheCSRDetailsScreenForTheCSR2(string csrName)
        {
            Report.WriteLine("Searching for csrName");
            SendKeys(attributeName_xpath, CSRList_Searchbox_Xpath, csrName);
            Thread.Sleep(500);

            Report.WriteLine("Click on CSR Name");
            Click(attributeName_xpath, CsrList_First_Name_On_List_Xpath);
        }


        [When(@"I expand the Pricing Model section for ""(.*)""")]
        public void WhenIExpandThePricingModelSectionFor(string pricingType)
        {
            Report.WriteLine("Expanding Pricing Model dropdown");
            WaitForElementVisible(attributeName_xpath, CSRDetailsPage_CSRName_Text_Xpath, "CSR Name");
            WaitForElementNotVisible(attributeName_id, Loading_Icon_Id, "Loading Icon");
            scrollElementIntoView(attributeName_xpath, CsrDetails_PricingModel_Dropdown_Scrollable_Xpath);
            Thread.Sleep(2000);
            if (pricingType == "Gainshare")
            {
                WebDriverHelpers.ClickElement(GlobalVariables.webDriver.FindElement(By.XPath(CsrDetails_PricingModel_Dropdown_Gainshare_Xpath)));
            }
            else
            {
                WebDriverHelpers.ClickElement(GlobalVariables.webDriver.FindElement(By.XPath(CsrDetails_PricingModel_Dropdown_NonGainshare_Xpath)));
            }
        }


        [Then(@"I will see the Gainshare - New Logic Field")]
        public void ThenIWillSeeTheGainshare_NewLogicField()
        {
            Report.WriteLine("Verifying the Gainshare - New Logic field is visible");
            WaitForElementVisible(attributeName_xpath, CsrDetails_RatingInstructionsAndRate_Field_Value_Xpath, "Rating Instruction and Rate Provisions Field");
            VerifyElementVisible(attributeName_xpath, CsrDetails_GainshareNewLogic_Field_Xpath, "Gainshare New Logic Field");
        }

        [Then(@"the field will be displayed below the Rating Instruction and Rate Provisions field")]
        public void ThenTheFieldWillBeDisplayedBelowTheRatingInstructionAndRateProvisionsField()
        {
            int newLogicYCoord = GlobalVariables.webDriver.FindElement(By.XPath(CsrDetails_GainshareNewLogic_Field_Xpath)).Location.Y;
            int ratingInstructionsAndRateYCoord = GlobalVariables.webDriver.FindElement(By.XPath(CsrDetails_RatingInstructionsAndRate_Field_Value_Xpath)).Location.Y;

            if ((newLogicYCoord < ratingInstructionsAndRateYCoord))
                Report.WriteFailure("Gainshare - New Logic was not below Rating InStructions and Rate Provisions");
        }

        [Then(@"the Gainshare - New Logic field value will be Yes")]
        public void ThenTheGainshare_NewLogicFieldValueWillBeYes()
        {
            Report.WriteLine("Verifying New Logic field value is Yes");
            WaitForElementVisible(attributeName_xpath, CsrDetails_GainshareNewLogic_Field_Value_Xpath, "Gainshare New Logic Field");
            string gainshareLogic = GlobalVariables.webDriver.FindElement(By.XPath(CsrDetails_GainshareNewLogic_Field_Value_Xpath)).Text;
            Assert.AreEqual("Yes", gainshareLogic);
        }

        [Then(@"the CRM Rating Logic field will be Yes")]
        public void ThenTheCRMRatingLogicFieldWillBeYes()
        {
            Report.WriteLine("Verifying CRM Rating Logic field is Yes");
            string crmRating = GlobalVariables.webDriver.FindElement(By.XPath(CsrDetails_CrmRatingLogic_Field_Value_Xpath)).Text;
            Assert.AreEqual("Yes", crmRating);
        }

        [Then(@"the Gainshare - New Logic field value will be No")]
        public void ThenTheGainshare_NewLogicFieldValueWillBeNo()
        {
            Report.WriteLine("Verifying New Logic field value is No");
            WaitForElementVisible(attributeName_xpath, CsrDetails_GainshareNewLogic_Field_Value_Xpath, "Gainshare New Logic Field");
            string gainshareLogic = GlobalVariables.webDriver.FindElement(By.ClassName(CsrDetails_GainshareNewLogic_Field_Value_Class)).Text;
            Assert.AreEqual("No", gainshareLogic);
        }

        [Then(@"the CRM Rating Logic field will be No")]
        public void ThenTheCRMRatingLogicFieldWillBeNo()
        {
            Report.WriteLine("Verifying CRM Rating Logic field is No");
            string crmRating = GlobalVariables.webDriver.FindElement(By.XPath(CsrDetails_CrmRatingLogic_Field_Value_Xpath)).Text;
            Assert.AreEqual("No", crmRating);
        }

        [Then(@"the Gainshare New Logic field will not be present")]
        public void ThenTheGainshareNewLogicFieldWillNotBePresent()
        {
            Report.WriteLine("Verifying Gainshare - New Logic field is not present");
            WaitForElementVisible(attributeName_xpath, CsrDetails_PricingModel_Body_Xpath, "Pricing Model Body");
            VerifyElementNotPresent(attributeName_xpath, CsrDetails_GainshareNewLogic_Field_Value_Xpath, "Gainshare - New Logic field");
        }


    }
}
