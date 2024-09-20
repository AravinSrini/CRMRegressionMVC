using System.Collections.Generic;
using System.Configuration;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;

namespace CRM.UITest.Scripts.Insurance_Claims.Claims_List
{
    [Binding]
    public class InsuranceClaims_ClaimsListProDisplaySteps : Objects.InsuranceClaim
    {
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
        IList<IWebElement> carrierColumnValuesUI = null;
        List<string> expectedCarrierColumnValues = null;

        [Given(@"I am a shp\.inquiry, shpinquirynorates, shp\.entry, shp\.entrynorates, sales, sales management, operations, station owner, or claim specialist user")]
        public void GivenIAmAShp_InquiryShpinquirynoratesShp_EntryShp_EntrynoratesSalesSalesManagementOperationsStationOwnerOrClaimSpecialistUser()
        {
            string userName = ConfigurationManager.AppSettings["username-claimspecialistClaim"].ToString();
            string password = ConfigurationManager.AppSettings["password-claimspecialistClaim"].ToString();
            CrmLogin.LoginToCRMApplication(userName, password);
            Report.WriteLine("Logged in to CRM with claim specialist user credentials");
        }

        [When(@"a Pro number is available for any displayed carrier in the Carrier column")]
        public void WhenAProNumberIsAvailableForAnyDisplayedCarrierInTheCarrierColumn()
        {
            WaitForElementVisible(attributeName_xpath, ClaimsListPage_HeaderText_Xpath, "Claims List");

            string firstGridData = Gettext(attributeName_xpath, ClaimListGridDataCount_Xpath);
            if (firstGridData == "No Results Found")
            {
                Report.WriteFailure("No data found in the Claim List Grid");
            }
            else
            {
                Click(attributeName_xpath, ClaimListGrid_PageViewOption_dropdown_Xpath);
                Click(attributeName_xpath, ClaimListGrid_PageViewOption_dropdownValue_All_Xpath);
                carrierColumnValuesUI = GlobalVariables.webDriver.FindElements(By.XPath(CarrierColumn_Xpath));
                expectedCarrierColumnValues = new List<string>();

                foreach (var proNumbers in carrierColumnValuesUI)
                {
                    expectedCarrierColumnValues.Add(proNumbers.Text);
                }

                for (int i = 0; i < carrierColumnValuesUI.Count; i++)
                {
                    if (expectedCarrierColumnValues.Contains(carrierColumnValuesUI[i].Text))
                    {
                        string[] values = expectedCarrierColumnValues[i].Split('\n');
                        Report.WriteLine("Pro number is available for the Carrier");
                    }
                    else
                    {
                        Report.WriteLine("Pro number is not available for the Carrier");
                    }
                }
            }
        }

        [Then(@"I should be displayed with a space between the colon and the first character of the carrier pro")]
        public void ThenIShouldBeDisplayedWithASpaceBetweenTheColonAndTheFirstCharacterOfTheCarrierPro()
        {
            for (int i = 0; i < carrierColumnValuesUI.Count; i++)
            {
                if (expectedCarrierColumnValues.Contains(carrierColumnValuesUI[i].Text))
                {
                    string[] values = expectedCarrierColumnValues[i].Split('\n');
                    string[] PRO = values[1].Split(':');
                    if (PRO[1].StartsWith(" "))
                    {
                        Report.WriteLine("Space is available between colon and the first character of PRO number");                        
                    }
                    else
                    {
                        Report.WriteLine("No Space is available between colon and the first character of PRO number");
                        Assert.Fail();
                    }

                }

            }
        }
    }
}
