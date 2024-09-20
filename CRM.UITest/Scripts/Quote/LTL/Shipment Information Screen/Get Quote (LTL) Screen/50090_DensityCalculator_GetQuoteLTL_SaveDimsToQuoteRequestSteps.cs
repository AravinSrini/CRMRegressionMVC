using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Collections.Generic;
using System.Configuration;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using OpenQA.Selenium;

namespace CRM.UITest.Scripts.Quote.LTL.Shipment_Information_Screen.Get_Quote__LTL__Screen
{
    [Binding]
    public class _50090_DensityCalculator_GetQuoteLTL_SaveDimsToQuoteRequestSteps : AddShipments
    {
        CommonMethodsCrm crm = new CommonMethodsCrm();
        [Given(@"I am a ship inquiry, ship entry, operations, sales, sales management, or station owner user with a valid ""(.*)"" ""(.*)""")]
        public void GivenIAmAShipInquiryShipEntryOperationsSalesSalesManagementOrStationOwnerUserWithAValid(string user, string pass)
        {
            string username = ConfigurationManager.AppSettings[user].ToString();
            string password = ConfigurationManager.AppSettings[pass].ToString();
            Report.WriteLine("Logging in as " + username);
            crm.LoginToCRMApplication(username, password);
        }

        [Given(@"I navigate to the Get Quote \(LTL\) Page for ""(.*)""")]
        public void GivenINavigateToTheGetQuoteLTLPageFor(string customerAccount)
        {
            Report.WriteLine("Click on the Quote Module");
            Click(attributeName_xpath, QuoteIcon_Xpath);
            Report.WriteLine("Select Customer Name " + customerAccount);
            Click(attributeName_xpath, QuoteCustomerSelectionDropdown_Xpath);
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(QuoteCustomerSelectioDropdownValues_Xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == customerAccount)
                {
                    DropDownList[i].Click();
                    break;
                }
            }

            Report.WriteLine("Click on the Submit Rate Request Button");
            Click(attributeName_id, SubmitRateRequestBtn_id);
            Report.WriteLine("Click on the LTL Tile");
            Click(attributeName_id, ShipmentServiceTypeLTL_id);
            Report.WriteLine("I am on the Get Quote LTL Page");
            VerifyElementPresent(attributeName_xpath, LTLpagetitle_xpath, "Get Quote (LTL)");
        }

        [Given(@"I have opened the Estimated Class Lookup modal")]
        public void GivenIHaveOpenedTheEstimatedClassLookupModal()
        {
            Report.WriteLine("Click on the Estimate Class Button");
            Click(attributeName_xpath, LTL_EstimateClassButton_xpath);
        }

        [Given(@"I have entered the required information for Length, Width, Height, Weight, and Quantity ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)""")]
        public void GivenIHaveEnteredRequiredInformationForLengthWidthHeightWeightAndQuantity(int length, int width, int height, int weight, int quantity)
        {
            Report.WriteLine("Adding required information for Length, Width, Height, Weight, and Quantity");
            WaitForElementPresent(attributeName_xpath, LTL_EstimateClassButton_xpath, LTL_EstimateClass_Width_Id);
            SendKeys(attributeName_id, LTL_EstimateClass_Length_Id, length.ToString());
            SendKeys(attributeName_id, LTL_EstimateClass_Width_Id, width.ToString());
            SendKeys(attributeName_id, LTL_EstimateClass_Height_Id, height.ToString());
            SendKeys(attributeName_id, LTL_EstimateClass_Weight_Id, weight.ToString());
            SendKeys(attributeName_id, LTL_EstimateClass_Quantity_Id, quantity.ToString());
            Click(attributeName_xpath, LTL_EstimateClass_ApplyClass_Xpath);
        }

        [When(@"I click on the Apply Class Button")]
        public void WhenIClickOnTheApplyClassButton()
        {
            Report.WriteLine("Click on the Apply Class Button");
            Click(attributeName_xpath, LTL_EstimateClass_ApplyClass_Xpath);
        }

        [Then(@"the Length value ""(.*)"" will be applied to the Length field on the Get Quote \(LTL\) page")]
        public void ThenTheLengthValueWillBeAppliedToTheLengthFieldOnTheGetQuoteLTLPage(int length)
        {
            string lengthField = GetAttribute(attributeName_id, LTL_Not_Freight_Length_Id, "value");
            Assert.AreEqual(length.ToString(), lengthField);
        }

        [Then(@"the Width value ""(.*)"" will be applied to the Width field on the Get Quote \(LTL\) page")]
        public void ThenTheWidthValueWillBeAppliedToTheWidthFieldOnTheGetQuoteLTLPage(int width)
        {
            string widthField = GetAttribute(attributeName_id, LTL_Not_Freight_Width_Id, "value");
            Assert.AreEqual(width.ToString(), widthField);
        }

        [Then(@"the Height value ""(.*)"" will be applied to the Height field on the Get Quote \(LTL\) page\.")]
        public void ThenTheHeightValueWillBeAppliedToTheHeightFieldOnTheGetQuoteLTLPage_(int height)
        {
            string heightField = GetAttribute(attributeName_id, LTL_Not_Freight_Height_Id, "value");
            Assert.AreEqual(height.ToString(), heightField);
        }

        [Then(@"Overlength service is added to the Click to add services & accessorials field on Get Quote \(LTL\) page")]
        public void ThenOverlengthServiceIsAddedToTheClickToAddServicesAccessorialsFieldOnGetQuoteLTLPage()
        {
            IList<IWebElement> ServicesDropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ShippingFrom_selectedServicesAccessorial_DropDown_xpath));
            if (ServicesDropDownList == null || ServicesDropDownList.Count() == 0)
            {
                Assert.Fail();
            }
            Assert.IsTrue(ServicesDropDownList[0].Text == "Overlength");
        }

        [Given(@"I click on the Add Additional Item Button")]
        public void GivenIClickOnTheAddAdditionalItemButton()
        {
            Report.WriteLine("Click on the Add Additional Item Button");
            Click(attributeName_xpath, AddAdditionalItemBtm_xpath);
        }

        [Given(@"I have opened the Estimated Class Lookup modal for the additional item")]
        public void GivenIHaveOpenedTheEstimatedClassLookupModalForTheAdditionalItem()
        {
            Report.WriteLine("Click on the Estimate Class Button");
            Click(attributeName_id, LTL_Additional_DensityCalculator_Icon_Id);
        }


    }
}
