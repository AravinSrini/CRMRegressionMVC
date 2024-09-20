using System;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Helper.Common;
using CRM.UITest.Helper.DataModels;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.Configuration;
using CRM.UITest.Entities;


namespace CRM.UITest.Scripts.Insurance_Claims.Claim_Details
{
    [Binding]
    public class InsuranceClaims_DetailsTab_FTLElementsSteps :InsuranceClaim
    {
        string expectedText = null;
        string actualText = null;
        string expectedCharEntered = null;
        string actualCharEntered = null;

        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();

        [Given(@"I am a sales, sales management, operations, station owner, or claims specialist user")]
        public void GivenIAmASalesSalesManagementOperationsStationOwnerOrClaimsSpecialistUser()
        {
            string username = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
            string password = ConfigurationManager.AppSettings["password-crmOperation"].ToString();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"I am sales, sales management, operations, station owner, or claims specialist user")]
        public void GivenIAmSalesSalesManagementOperationsStationOwnerOrClaimsSpecialistUser()
        {
            string userName = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
            string password = ConfigurationManager.AppSettings["password-crmOperation"].ToString();
            CrmLogin.LoginToCRMApplication(userName, password);
            GlobalVariables.webDriver.WaitForPageLoad();
        }


        [Given(@"I clicked on the hyperlink of any displayed claim having shipment as LTL")]
        public void GivenIClickedOnTheHyperlinkOfAnyDisplayedClaimHavingShipmentAsLTL()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, ClaimListGrid_PendingCheckbox_Xpath);
           
            
            IList<IWebElement> RowCount = GlobalVariables.webDriver.FindElements(By.XPath("//*[@id='gridInsuranceClaimList']/tbody/tr"));
            for(int i=1; i<RowCount.Count; i++)
            {
                IWebElement ColumnElement = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='gridInsuranceClaimList']/tbody/tr["+i+"]/td[3]/span[1]/a"));
                string columnValue = ColumnElement.Text;
                if (columnValue.Equals("2018000187"))
                {
                    ColumnElement.Click();
                    break;
                }
            }
        }
        
        [Given(@"I am on the Details tab of the Claim Details page")]
        public void GivenIAmOnTheDetailsTabOfTheClaimDetailsPage()
        {
            expectedText = "DETAILS";
            actualText = Gettext(attributeName_xpath, ClaimDetailsTabText_Xpath);
            Assert.AreEqual(expectedText, actualText);
        }
        
        [Given(@"I clicked on the hyperlink of any displayed claim having shipment mode as Forwarding")]
        public void GivenIClickedOnTheHyperlinkOfAnyDisplayedClaimHavingShipmentModeAsForwarding()
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            GlobalVariables.webDriver.WaitForPageLoad();
            IList<IWebElement> RowCount = GlobalVariables.webDriver.FindElements(By.XPath("//*[@id='gridInsuranceClaimList']/tbody/tr"));
            for(int i=1; i<=RowCount.Count; i++)
            {
                IWebElement ColumnElement = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='gridInsuranceClaimList']/tbody/tr[" + i + "]/td[3]/span[1]/a"));
                string columnValue = ColumnElement.Text;
                if (columnValue.Equals("1123478914"))
                {
                    ColumnElement.Click();
                    break;
                }
            }
        }

        [When(@"I clicked on the hyperlink of any displayed claim having shipment mode as FTL")]
        public void WhenIClickedOnTheHyperlinkOfAnyDisplayedClaimHavingShipmentModeAsFTL()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            scrollpagedown();
            scrollpagedown();
            IList<IWebElement> RowCount = GlobalVariables.webDriver.FindElements(By.XPath("//*[@id='gridInsuranceClaimList']/tbody/tr"));
            for(int i=1; i<RowCount.Count; i++)
            {
               IWebElement ColumnElement = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='gridInsuranceClaimList']/tbody/tr["+i+"]/td[4]"));

                string columnValue = ColumnElement.Text;
                if (columnValue.Equals("1123478913"))
                {

                    ColumnElement.Click();
                    break;
                }
            }
            
        }

        [When(@"I clicked on the hyperlink of any displayed claim having shipment mode as FTL for claim specialist user")]
        public void WhenIClickedOnTheHyperlinkOfAnyDisplayedClaimHavingShipmentModeAsFTLForClaimSpecialistUser()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            scrollpagedown();
            scrollpagedown();
            IList<IWebElement> RowCount = GlobalVariables.webDriver.FindElements(By.XPath("//*[@id='gridInsuranceClaimList']/tbody/tr"));
            for (int i = 1; i < RowCount.Count; i++)
            {
                IWebElement ColumnElement = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='gridInsuranceClaimList']/tbody/tr[" + i + "]/td[3]/span[1]/a"));

                string columnValue = ColumnElement.Text;
                if (columnValue.Equals("1123478913"))
                {

                    ColumnElement.Click();
                    break;
                }
            }
        }


        [When(@"I change the shipment mode to FTL")]
        public void WhenIChangeTheShipmentModeToFTL()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, shipmentMode_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, shipmentMode_Xpath, "FTL");
        }
      
        
        [Then(@"the FTL shipment mode will be pre-selected")]
        public void ThenTheFTLShipmentModeWillBePre_Selected()
        {
            expectedText = "FTL";
            actualText = Gettext(attributeName_xpath, shipmentMode_Xpath);
            Assert.AreEqual(expectedText, actualText);
        }

        

        [Then(@"I can edit the fields: Carrier MC,Seal,Seal Intact,Vehicle from details tab")]
        public void ThenICanEditTheFieldsCarrierMCSealSealIntactVehicleFromDetailsTab()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            scrollpagedown();
            SendKeys(attributeName_id, Carrier_MC_Id, "123xyz");
            SendKeys(attributeName_id, Seal_Number_Id, "test 1234test");
            Click(attributeName_xpath, SealIntact_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, SealIntact_Xpath, "No");
            SendKeys(attributeName_id, VehicleNumber_Id, "12898998GF");
        }


        [Then(@"the Details tab will display the given FTL-Specific fields: Carrier MC,Seal,Seal Intact,Vehicle")]
        public void ThenTheDetailsTabWillDisplayTheGivenFTL_SpecificFieldsCarrierMCSealSealIntactVehicle()
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            IsElementPresent(attributeName_id, Carrier_MC_Id, "CarrierMC#");
            IsElementPresent(attributeName_id, Seal_Number_Id, "Seal#");
            IsElementPresent(attributeName_xpath, SealIntact_Xpath, "SealIntact");
            IsElementPresent(attributeName_id, VehicleNumber_Id, "Vehicle#");
        }
        
        [Then(@"the Details tab will update to display FTL-Specific fields")]
        public void ThenTheDetailsTabWillUpdateToDisplayFTL_SpecificFields()
        {
            scrollpagedown();
            scrollpagedown();
            IsElementPresent(attributeName_id, Carrier_MC_Id, "CarrierMC#");
            IsElementPresent(attributeName_id, Seal_Number_Id, "Seal#");
            IsElementPresent(attributeName_xpath, SealIntact_Xpath, "SealIntact");
            IsElementPresent(attributeName_id, VehicleNumber_Id, "Vehicle#");
        }

        [Then(@"It will allow max (.*) character to enter in Carrier MC number field")]
        public void ThenItWillAllowMaxCharacterToEnterInCarrierMCNumberField(int p0)
        {
            SendKeys(attributeName_id, Carrier_MC_Id, "duedeuue ueu ehuiueuieue ueue gydwgy");
            expectedCharEntered = "duedeuue u";
            actualCharEntered = Gettext(attributeName_id, Carrier_MC_Id);
            Assert.AreNotEqual(expectedCharEntered, actualCharEntered);
        }

        [Then(@"It will allow (.*) character to enter in Seal number and vehicle number field field")]
        public void ThenItWillAllowCharacterToEnterInSealNumberAndVehicleNumberFieldField(int p0)
        {
            SendKeys(attributeName_id, Seal_Number_Id, "duedeuue ueu ehuiueuieue ueue gydwgy");
            expectedCharEntered = "duedeuue9 gywtuuu 67666wtwttt";
            actualCharEntered = Gettext(attributeName_id, Carrier_MC_Id);
            Assert.AreNotEqual(expectedCharEntered, actualCharEntered);
        }


    }
}
