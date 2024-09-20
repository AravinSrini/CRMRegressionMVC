using CRM.UITest.CommonMethods;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using System.Linq;
using System.Configuration;
using Rrd.ServiceAccessLayer;

namespace CRM.UITest.Scripts.Insurance_Claims.Claims_List
{
    [Binding]
    public class InsuranceClaims_ClaimsList_ClaimHyperlinkSteps : CRM.UITest.Objects.InsuranceClaim
    {
        string claimNumber_ClaimsList_UI;

        [Given(@"I am ShpEntry, ShpEntryNoRates, ShpInquiry, ShpInquiryNoRates, Sales, Sales Management, Operations, Station Owner and Claims Specialist User")]
        public void GivenIAmShpEntryShpEntryNoRatesShpInquiryShpInquiryNoRatesSalesSalesManagementOperationsStationOwnerAndClaimsSpecialistUser()
        {
            string username = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
            string password = ConfigurationManager.AppSettings["password-crmOperation"].ToString();
            CommonMethodsCrm crmLogin = new CommonMethodsCrm();
            crmLogin.LoginToCRMApplication(username, password);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I am ShpEntry, ShpEntryNoRates, ShpInquiry, ShpInquiryNoRates User")]
        public void GivenIAmShpEntryShpEntryNoRatesShpInquiryShpInquiryNoRatesUser()
        {
            string username = ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();
            string password = ConfigurationManager.AppSettings["ExternalUserPassword"].ToString();
            CommonMethodsCrm crmLogin = new CommonMethodsCrm();
            crmLogin.LoginToCRMApplication(username, password);
            GlobalVariables.webDriver.WaitForPageLoad();
        }


        [When(@"I am on the Claims List page")]
        public void WhenIAmOnTheClaimsListPage()
        {
            Click(attributeName_id, ClaimsIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, ClaimsListPage_HeaderText_Xpath, "Claims List");
        }

        [When(@"I clicked any of the DLSW Claim hyperlink")]
        public void WhenIClickedAnyOfTheDLSWClaimHyperlink()
        {
            Click(attributeName_id, ClaimsIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, ClaimsListPage_HeaderText_Xpath, "Claims List");

            string firstGridData = Gettext(attributeName_xpath, ClaimListGridDataCount_Xpath);
            if (firstGridData == "No Results Found")
            {
                Report.WriteLine("No Claims List found in the Grid");
                throw new Exception("No datas found in the Claim List Grid");
            }
            else
            {
                Report.WriteLine("Reading First data value from Claims List page");
                claimNumber_ClaimsList_UI = Gettext(attributeName_xpath, FirstClaimNumber_ClaimsListGrid_Xpath);

                Report.WriteLine("Clicking on the Claim Number");
                Click(attributeName_xpath, FirstClaimNumber_ClaimsListGrid_Xpath);

            }
        }

        [Then(@"the pdf will be opened in new tab and the file name will be the DLSW Claim number pdf")]
        public void ThenThePdfWillBeOpenedInNewTabAndTheFileNameWillBeTheDLSWClaimNumberPdf()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            string configURL = launchUrl;
            Report.WriteLine("Verifying the Pdf opened in new tab");
            WindowHandling(configURL + "InsuranceClaim/ViewClaimDetailsDocument?insuranceClaimNumber=" + claimNumber_ClaimsList_UI);
            string resultPagrURL = configURL + "InsuranceClaim/ViewClaimDetailsDocument?insuranceClaimNumber=" + claimNumber_ClaimsList_UI;
            if (GetURL() == resultPagrURL)
            {
                Report.WriteLine("Submit a Claim form pdf is opened in New Tab");
            }
            else
            {
                Report.WriteLine("Submit a Claim form pdf is not opened in New Tab");
                throw new Exception("Submit a Claim form pdf is not opened in New Tab");

            }
        }


        [Then(@"I will see DLSW claim number is displayed as a hyperlink")]
        public void ThenIWillSeeDLSWClaimNumberIsDisplayedAsAHyperlink()
        {
            string firstGridData = Gettext(attributeName_xpath, FirstClaimNumber_ClaimsListGrid_Xpath);
            if (firstGridData == "No Results Found")
            {
                Report.WriteLine("No Claims List found in the Grid");
                throw new Exception("No datas found in the Claim List Grid");
            }
            else
            {
                Click(attributeName_xpath, ClaimListGrid_PageViewOption_dropdown_Xpath);
                Click(attributeName_xpath, ClaimListGrid_PageViewOption_dropdownValue_All_Xpath);
                IList<IWebElement> checkAnchorTag = GlobalVariables.webDriver.FindElements(By.CssSelector("a[href=\"/InsuranceClaim\"]"));

                List<string> checkFor_anchorTag = checkAnchorTag.Select(a => a.TagName).ToList();


                for (int i = 0; i < checkFor_anchorTag.Count; i++)
                {
                    if (checkFor_anchorTag[i] == "a")
                    {
                        Report.WriteLine("verified Claim number is in hyperlink format");
                    }

                    else
                    {
                        throw new Exception("verified Claim number is in hyperlink format");
                    }
                }
            }
        }


    }
}
