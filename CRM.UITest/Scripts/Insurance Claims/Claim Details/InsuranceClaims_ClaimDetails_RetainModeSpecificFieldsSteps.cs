using System;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.IdentityModel.Protocols;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;

using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using System.Threading;

namespace CRM.UITest.Scripts.Insurance_Claims.Claim_Details
{
    [Binding]
    public class InsuranceClaims_ClaimDetails_RetainModeSpecificFieldsSteps : Objects.InsuranceClaim
    {
        int claimNumber = 0;
       
        
        [Given(@"I clicked on the hyperlink of any displayed claim having shipment mode as FTL")]
        public void GivenIClickedOnTheHyperlinkOfAnyDisplayedClaimHavingShipmentModeAsFTL()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            scrollpagedown();
            scrollpagedown();
            Entities.Proxy.InsuranceClaim claimNumber = DBHelper.GetFtlClaimNumber();
            IList<IWebElement> RowCount = GlobalVariables.webDriver.FindElements(By.XPath("//*[@id='gridInsuranceClaimList']/tbody/tr"));
            for (int i = 1; i < RowCount.Count; i++)
            {
                IWebElement ColumnElement = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='gridInsuranceClaimList']/tbody/tr[" + i + "]/td[3]/span[1]/a"));

                string columnValue = ColumnElement.Text;
                if (columnValue.Equals(claimNumber))
                {

                    ColumnElement.Click();
                    break;
                }
            }
        }
        
      

        [When(@"I change the Claim Mode")]
        public void WhenIChangeTheClaimMode()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            string claimModeUI = GetAttribute(attributeName_id, shipmentMode_Id, "value");
            if (claimModeUI.Equals("LTL"))
            {
                Click(attributeName_xpath, shipmentMode_Xpath);
                Click(attributeName_xpath, shipmentModeThirdOption_Xpath);
            }
            else if (claimModeUI.Equals("FTL"))
            {
                Click(attributeName_xpath, shipmentMode_Xpath);
                Click(attributeName_xpath, shipmentModeFirstOption_Xpath);
            }
            else
            {
                Click(attributeName_xpath, shipmentMode_Xpath);
                Click(attributeName_xpath, shipmentModeSecondOption_Xpath);
            }
            
        }

        [Given(@"I clicked on the hyperlink of any displayed claim from Claim List page")]
        public void GivenIClickedOnTheHyperlinkOfAnyDisplayedClaimFromClaimListPage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, ClaimListGrid_PendingCheckbox_Xpath);
            int claimNumber = DBHelper.GetRecentClaimNumber();
            IList<IWebElement> RowCount = GlobalVariables.webDriver.FindElements(By.XPath("//*[@id='gridInsuranceClaimList']/tbody/tr"));
            for (int i = 1; i < RowCount.Count; i++)
            {
                IWebElement ColumnElement = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='gridInsuranceClaimList']/tbody/tr[" + i + "]/td[3]/span[1]/a"));
                string columnValue = ColumnElement.Text;
                int claimNubmerUI = Convert.ToInt32(columnValue);
                if (claimNubmerUI == claimNumber)
                {
                    ColumnElement.Click();
                    break;
                }
            }
        }


        [Then(@"the Claim Mode will be updated for the claim")]
        public void ThenTheClaimModeWillBeUpdatedForTheClaim()
        {
            string claimNumberUI = GetAttribute(attributeName_id, DlswClaimNumber_Textbox_ClaimDetailsPage_Id, "value");
            int claimNumber = Convert.ToInt32(claimNumberUI);
            Report.WriteLine("Getting data from DB");
            Entities.Proxy.InsuranceClaim claimMode = DBHelper.GetShipmentMode(claimNumber);

            Report.WriteLine("Getting data from UI");
            string claimModeUI = GetAttribute(attributeName_id, shipmentMode_Id, "value"); 
            if (claimMode.ShipmentMode.Equals(claimModeUI))
            {
                Assert.IsTrue(true);
            }

        }
    }
}
