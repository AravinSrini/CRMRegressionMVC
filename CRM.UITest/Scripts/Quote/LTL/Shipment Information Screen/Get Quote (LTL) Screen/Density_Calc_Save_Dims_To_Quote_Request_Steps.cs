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
using System.Threading;

namespace CRM.UITest.Scripts.Quote.LTL.Shipment_Information_Screen.Get_Quote__LTL__Screen
{
    [Binding]
    public sealed class Density_Calc_Save_Dims_To_Quote_Request_Steps : AddShipments
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

            SelectDropdownValueFromList(attributeName_xpath, QuoteCustomerSelectioDropdownValues_Xpath, customerAccount);

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
        public void GivenIHaveEnteredRequiredInformationForLengthWidthHeightWeightAndQuantity(string length, string width, string height, string weight, string quantity)
        {
            Report.WriteLine("Adding required information for Length, Width, Height, Weight, and Quantity");
            WaitForElementVisible(attributeName_id, LTL_EstimateClass_Length_Id, LTL_EstimateClass_Length_Id);
            Thread.Sleep(1000);
            SendKeys(attributeName_id, LTL_EstimateClass_Length_Id, length);
            Thread.Sleep(1000);
            SendKeys(attributeName_id, LTL_EstimateClass_Width_Id, width);
            Thread.Sleep(500);
            SendKeys(attributeName_id, LTL_EstimateClass_Height_Id, height);
            Thread.Sleep(500);
            SendKeys(attributeName_id, LTL_EstimateClass_Weight_Id, weight);
            Thread.Sleep(500);
            SendKeys(attributeName_id, LTL_EstimateClass_Quantity_Id, quantity);
            Click(attributeName_id, "apply-class");
        }

        [When(@"I click on the Apply Class Button")]
        public void WhenIClickOnTheApplyClassButton()
        {
            Report.WriteLine("Click on the Apply Class Button");
            Thread.Sleep(500);
            if(IsElementVisible(attributeName_id, "apply-class", "Apply Class Button"))
                Click(attributeName_id, "apply-class");
        }

        [Then(@"the Length value ""(.*)"" will be applied to the Length field on the Get Quote \(LTL\) page")]
        public void ThenTheLengthValueWillBeAppliedToTheLengthFieldOnTheGetQuoteLTLPage(string length)
        {
            string lengthField = GetAttribute(attributeName_id, LTL_Not_Freight_Length_Id, "value");
            Assert.AreEqual(length, lengthField);
        }

        [Then(@"the Width value ""(.*)"" will be applied to the Width field on the Get Quote \(LTL\) page")]
        public void ThenTheWidthValueWillBeAppliedToTheWidthFieldOnTheGetQuoteLTLPage(string width)
        {
            string widthField = GetAttribute(attributeName_id, LTL_Not_Freight_Width_Id, "value");
            Assert.AreEqual(width, widthField);
        }

        [Then(@"the Height value ""(.*)"" will be applied to the Height field on the Get Quote \(LTL\) page\.")]
        public void ThenTheHeightValueWillBeAppliedToTheHeightFieldOnTheGetQuoteLTLPage_(string height)
        {
            string heightField = GetAttribute(attributeName_id, LTL_Not_Freight_Height_Id, "value");
            Assert.AreEqual(height, heightField);
        }

        [Then(@"the Length value ""(.*)"" will be applied to the Length field on the Get Quote \(LTL\) page for the additional item")]
        public void ThenTheLengthValueWillBeAppliedToTheLengthFieldOnTheGetQuoteLTLPageForTheAdditionalItem(string length)
        {
            string lengthField = GetAttribute(attributeName_id, LTL_Not_Freight_Length_Id_Additonal_Item, "value");
            Assert.AreEqual(length, lengthField);
        }

        [Then(@"the Width value ""(.*)"" will be applied to the Width field on the Get Quote \(LTL\) page for the additional item")]
        public void ThenTheWidthValueWillBeAppliedToTheWidthFieldOnTheGetQuoteLTLPageForTheAdditionalItem(string width)
        {
            string widthField = GetAttribute(attributeName_id, LTL_Not_Freight_Width_Id_Additonal_Item, "value");
            Assert.AreEqual(width, widthField);
        }

        [Then(@"the Height value ""(.*)"" will be applied to the Height field on the Get Quote \(LTL\) page for the additional item")]
        public void ThenTheHeightValueWillBeAppliedToTheHeightFieldOnTheGetQuoteLTLPageForTheAdditionalItem(string height)
        {
            string heightField = GetAttribute(attributeName_id, LTL_Not_Freight_Height_Id_Additonal_Item, "value");
            Assert.AreEqual(height, heightField);
        }


        [Then(@"Overlength service is added to the Click to add services & accessorials field on Get Quote \(LTL\) page")]
        public void ThenOverlengthServiceIsAddedToTheClickToAddServicesAccessorialsFieldOnGetQuoteLTLPage()
        {
            IList<IWebElement> ServicesDropDownList = GlobalVariables.webDriver.FindElements(By.XPath("//*[@id='servicesaccessorialsfrom_chosen']/ul/li[@class='search-choice']"));
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
