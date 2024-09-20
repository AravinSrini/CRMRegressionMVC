using System.Linq;
using OpenQA.Selenium;
using System.Threading;
using TechTalk.SpecFlow;
using CRM.UITest.Objects;
using System.Collections.Generic;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using CRM.UITest.CommonMethods;

namespace CRM.UITest.Scripts.Csr.CsrDetails
{
    [Binding]
    public sealed class _104654___New_CSR___Carrier_Specific_Delete_Individual_Accessorials_link_not_clickable_step : Submit_CSR
    {
        [When(@"I add a customer specific gainshare with accessorial ""(.*)""")]
        public void WhenIAddACustomerSpecificGainshareWithAccessorial(string accessorial)
        {
            Report.WriteLine("Selecting Gainshare as the pricing type");
            Click(attributeName_xpath, PricingType_DropDown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, PricingType_DropDownDropDownList_Xpath, "Gainshare");
            GlobalVariables.webDriver.WaitForPageLoad();

            WaitForElementVisible(attributeName_xpath, Gainshare_Set_Individual_Accessorials_Xpath, "Gainshare section");
            Report.WriteLine("Opening individual accessorials modal");
            Click(attributeName_xpath, Gainshare_Set_Individual_Accessorials_Xpath);
            WaitForElementVisible(attributeName_xpath, Gainshare_Individual_Accessorial_Modal_Xpath, "Individual accessorials modal");

            Report.WriteLine("Entering 50 as the gainshare percentage");
            SendKeys(attributeName_id, Gainshare_percentage_Id, "50");

            Report.WriteLine("Selecting " + accessorial + " accessorial from dropdown menu");
            Click(attributeName_xpath, Gainshare_Individual_Accessorial_First_Accessorial_Name_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, Gainshare_Individual_Accessorial_First_Accessorial_Name_Xpath, accessorial);

            Report.WriteLine("Selecting flat over cost as the gainshare type");
            Click(attributeName_xpath, Gainshare_Individual_Accessorial_First_Accessorial_Gainshare_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, Gainshare_Individual_Accessorial_First_Accessorial_Gainshare_Xpath, "FLAT OVER COST");

            Report.WriteLine("Entering 20 as the flat over cost value");
            SendKeys(attributeName_xpath, Gainshare_First_Carrier_Individual_Accessorial_Modal_Value_Xpath, "20");

            Report.WriteLine("Saving Customer Specific Accessorial");
            Click(attributeName_xpath, Gainshare_Individual_Accessorial_Modal_Save_Xpath);
            WaitForElementNotVisible(attributeName_xpath, Gainshare_Individual_Accessorial_Modal_Xpath, "Individual accessorial modal");
        }

        [When(@"I add a carrier ""(.*)"" with the individual accessorials ""(.*)"" and the SCAC ""(.*)""")]
        public void WhenIAddACarrierWithTheIndividualAccessorialsAndTheSCAC(string carrierNum, List<string> accessorials, string scacCode)
        {
            Thread.Sleep(500);
            Report.WriteLine("Setting carrier accessorials");
            Click(attributeName_xpath, Gainshare_Add_Carrier_Pricing_Xpath);

            List<IWebElement> carrierAccessorialSections = GlobalVariables.webDriver.FindElements(By.XPath(Gainshare_Carrier_Accessorial_List_Xpath)).ToList();


            Report.WriteLine("Selecting SCAC for carrier " + carrierAccessorialSections.Count);
            scrollElementIntoView(attributeName_xpath, "//*[@id='carrier_scac_code_" + (carrierAccessorialSections.Count - 1) + "_chosen']");
            Click(attributeName_xpath, "//div[contains(@id, 'carrier_scac_code_" + (carrierAccessorialSections.Count - 1) + "_chosen')]");
            SelectDropdownValueFromList(attributeName_xpath, "//div[contains(@id, 'carrier_scac_code_" + (carrierAccessorialSections.Count - 1) + "_chosen')]", scacCode);

            if (accessorials.First() != "")
            {
                Report.WriteLine("Opening individual accessorials modal for carrier");
                Click(attributeName_xpath, "//*[@id='set-accessorial" + (carrierNum) + "']");

                for (int i = 0; i < accessorials.Count; i++)
                {
                    if (i > 0)
                    {
                        Click(attributeName_xpath, Gainshare_Individual_Accessorial_Modal_Add_Accessorial);
                    }
                    Report.WriteLine("Setting accessorial " + i);
                    Report.WriteLine("Selecting " + accessorials[i] + " accessorial from dropdown menu");
                    Click(attributeName_xpath, "//div[contains(@id , 'setAccessorial" + (i + 1) + "_chosen')]");
                    SelectDropdownValueFromList(attributeName_xpath, "//div[contains(@id , 'setAccessorial" + (i + 1) + "_chosen')]", accessorials[i]);

                    Report.WriteLine("Selecting flat over cost as the gainshare type");
                    Click(attributeName_xpath, "//div[contains(@id , 'setGainShareType" + (i + 1) + "_chosen')]");
                    SelectDropdownValueFromList(attributeName_xpath, "//div[contains(@id , 'setGainShareType" + (i + 1) + "_chosen')]", "FLAT OVER COST");

                    Report.WriteLine("Entering 20 as the flat over cost value");
                    SendKeys(attributeName_xpath, "//*[@id='flat-over-pricing-setGainshare" + (i + 1) + "']", "20");
                }

                Report.WriteLine("Saving Carrier Specific Accessorial for " + scacCode);
                Click(attributeName_xpath, Gainshare_Individual_Accessorial_Modal_Save_Xpath);
                WaitForElementNotVisible(attributeName_xpath, Gainshare_Individual_Accessorial_Modal_Xpath, "Individual accessorial modal");
            }
            else
            {
                Report.WriteLine("No accessorials added to " + scacCode);
            }
        }


        [When(@"I click on delete individual accessorials for carrier ""(.*)""")]
        public void WhenIClickOnDeleteIndividualAccessorialsForCarrier(int carrierNumber)
        {
            Report.WriteLine("Clicking on delete individual accessorials for carrier " + carrierNumber);
            Thread.Sleep(500);
            Click(attributeName_xpath, "//span[contains(@id, 'btnDeleteAccessorials" + carrierNumber + "')]");
        }

        [Then(@"the delete individual accessorials modal is displayed")]
        public void ThenTheDeleteIndividualAccessorialsModalIsDisplayed()
        {
            Report.WriteLine("Verifying that the delete accessorial modal is displayed");
            VerifyElementVisible(attributeName_xpath, Gainshare_Delete_Individual_Accessorials_Modal_Xpath, "Delete individual accessorial modal");
        }

        [StepArgumentTransformation]
        public List<string> TransformToListOfString(string commaSeparatedList)
        {
            return commaSeparatedList.Split(':').ToList();
        }
    }
}