using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;


namespace CRM.UITest.Scripts.Shipment.ShipmentList.Shipment_List_Carrier_PRO_All_Users
{
    [Binding]
    public class ShipmentList_CarrierPRO_AllUsersSteps : Shipmentlist
    {
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
        string subAccountShipmentPro = "ZZX00209933";

        [Given(@"I am a shp\.entry,shp\.entrynorates user")]
        public void GivenIAmAShp_EntryShp_EntrynoratesUser()
        {
            string username = ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();
            string password = ConfigurationManager.AppSettings["ExternalUserPassword"].ToString();
            CrmLogin.LoginToCRMApplication(username, password);
        }


        [When(@"I mouse hover on any displayed pro no in the status column")]
        public void WhenIMouseHoverOnAnyDisplayedProNoInTheStatusColumn()
        {
            Click(attributeName_id, ShipmentList_SearchBox_ToggleButton_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ShipmentListSearchBox_ClearAll_Button_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, ShipmentList_Search_Service_Checkbox_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_xpath, ShipmentList_SearchGridValuesTexTBox_Xpath, "LTL");
            string prono = "PRO #";
            int Shipmentrowcount = GetCount(attributeName_xpath, ShipmentList_TotalRecords_Xpath);
            if (Shipmentrowcount > 1)
            {
                Click(attributeName_xpath, ".//*[@id='ShipmentGrid_length']/label/select");
                IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='ShipmentGrid_length']/label/select/option"));
                int DropDownCount = DropDownList.Count;
                for (int i = 0; i < DropDownCount; i++)
                {
                    if (DropDownList[i].Text == "ALL")
                    {
                        DropDownList[i].Click();
                        break;
                    }
                }

                IList<IWebElement> SearchedPROnoinrows = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='ShipmentGrid']/tbody/tr/td/div[2]"));
                int HighlightedProNo = SearchedPROnoinrows.Count;
                foreach (var val in SearchedPROnoinrows)
                {
                    string expectedValue = val.Text;
                    string value = expectedValue.ToString();
                    string[] value1 = value.Split(':');

                    if (prono == (value1[0]))
                    {

                        Report.WriteLine("Pro # is present for this shipment and I mouse hover on Pro no");
                        OnMouseOver(attributeName_xpath, ".//*[@id='ShipmentGrid']/tbody/tr/td/div[2]/a/span");
                        break;
                    }
                    else
                    {
                        Assert.Fail();
                    }
                }
            }
            else
            {
                Report.WriteLine("No Records found for the Shipment List for the logged in user so unable to test the scenario");
            }
        }

        [Then(@"I should see the pro no and verbiagepop up message of any shipment")]
        public void ThenIShouldSeeTheProNoAndVerbiagepopUpMessageOfAnyShipment()
        {
            string VerbiageTrack = "Track Shipment";
            String Prono = Gettext(attributeName_xpath, ".//*[@id='ShipmentGrid']/tbody/tr/td/div[2]");
            string[] PronoOnly = Prono.Split('\n');
            string ExpectedProVerbage = PronoOnly[1];
            string[] digit = ExpectedProVerbage.Split('T');
            string pronodigit = digit[0];
            string actualproverbage = (pronodigit + VerbiageTrack);
            String expectedpronoVerbage = Gettext(attributeName_xpath, ".//*[@id='ShipmentGrid']/tbody/tr/td/div[2]/div/h3");
            Assert.AreEqual(actualproverbage, expectedpronoVerbage);
        }
        [When(@"I click on the displayed pro in the status column")]
        public void WhenIClickOnTheDisplayedProInTheStatusColumn()
        {
            Report.WriteLine("I click on displayed prono ");
            Click(attributeName_xpath, ".//*[@id='ShipmentGrid']/tbody/tr/td/div[2]/a/span");
        }

        [Then(@"I must navigated to the tacking details page of any selected shipment")]
        public void ThenIMustNavigatedToTheTackingDetailsPageOfAnySelectedShipment()
        {
            Report.WriteLine("I must be navigated to the Tracking details page");
            VerifyElementPresent(attributeName_xpath, TrackingPage_Header_xpath, "Tracking");
        }

        //===================== Priority Sprint 2
        
        [Given(@"I am a CRM user associated to a customer with sub-accounts")]
        public void GivenIAmACRMUserAssociatedToACustomerWithSub_Accounts()
        {
            string userName = ConfigurationManager.AppSettings["username-ExtuserCustDropdown"].ToString();
            string password = ConfigurationManager.AppSettings["password-ExtuserCustDropdown"].ToString();
            CrmLogin.LoginToCRMApplication(userName, password);
        }

        [Given(@"I am on the Tracking page")]
        public void GivenIAmOnTheTrackingPage()
        {
            Report.WriteLine("I click on Tracking Icon");
            Click(attributeName_cssselector, TrackingIcon_css);
            Report.WriteLine("I am to Tracking page");            
            WaitForElementVisible(attributeName_xpath, TrackingPage_Header_xpath, "Tracking");
        }

        [When(@"I click on any PRO link associated to a shipment of a sub-account")]
        public void WhenIClickOnAnyPROLinkAssociatedToAShipmentOfASub_Account()
        {
            Report.WriteLine("Select the all customers from dropdown");
            Click(attributeName_xpath, CustomerDropdownExtuser_Xpath);
            IList<IWebElement> CustomerDropdown_List = GlobalVariables.webDriver.FindElements(By.XPath(CustomerDropdownValesExtuser_Xpath));
            int CustomerNameListCount = CustomerDropdown_List.Count;
            for (int i = 0; i < CustomerNameListCount; i++)
            {
                if (CustomerDropdown_List[i].Text == "All Customers")
                {
                    CustomerDropdown_List[i].Click();
                    break;
                }
            }
            Report.WriteLine("Passed the Shipment reference number - having PRO number");
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_id, ShipmentListSearchBox_Id, subAccountShipmentPro);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("I click on any PRO link associated to a shipment of a sub-account");
            Click(attributeName_xpath, PROnumberLink_SearchedRefNumber);
        }

        [When(@"I track a CRM reference number associated to a shipment of a sub-account")]
        public void WhenITrackACRMReferenceNumberAssociatedToAShipmentOfASub_Account()
        {
            Report.WriteLine("Entered Reference number(s) associated to a shipment of subaccount and click on search arrow button");
            SendKeys(attributeName_id, TrackByReference_textbox_Id, subAccountShipmentPro);
            Click(attributeName_xpath, TrackByReference_Arrow_Xpath);
        }

        [Then(@"I will see the tracking details")]
        public void ThenIWillSeeTheTrackingDetails()
        {
            Report.WriteLine("I navigated to Tracking page");
            WaitForElementVisible(attributeName_xpath, TrackingPage_Header_xpath, "Tracking");
            if (IsElementPresent(attributeName_xpath, trackingErrorPopUpHeader_Xpath,"Error"))
            {
                Click(attributeName_xpath, errormessagemultiInvalidRefNumClose_xpath);
                Report.WriteFailure("No data found for the Entered Reference Number(s)");
            }
            else
            {
                int rowCount = GetCount(attributeName_xpath, RefNumberGridValues_Xpath);
                for (int i = 1; i <= rowCount; i++)
                {
                    string referenceNumber = Gettext(attributeName_xpath, ".//*[@id='TrackingDetailGrid']/tbody/tr[" + i + "]/td[1]");
                    string[] referenceNumberUI = referenceNumber.Split(' ');
                    Assert.AreEqual(referenceNumberUI[0], subAccountShipmentPro);
                    Report.WriteLine("Tracking details for the reference number present");
                    break;
                }
            }
        }
    }
}
