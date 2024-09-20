using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.IdentityModel.Protocols;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Quote.LTL.Quote_Results_Screen
{
    [Binding]
    public class QuotesResultsLTLPage_ImproveResultsDisplaySteps : Quotelist
    {
        public WebElementOperations objWebElementOperations = new WebElementOperations();
        string userName = null;
        string password = null;

        string OriginCity = "Los Angeles";
        string OriginZip = "90001";
        string OriginState = "CA";       
        string DestinationCity = "Los Angeles";
        string DestinationZip = "90001";
        string DestinationState = "CA";        

        string Classification = "50";
        string Weight = "10";

        [Given(@"I Am a shp\.entry User")]
        public void GivenIAmAShp_EntryUser()
        {
            userName = ConfigurationManager.AppSettings["username-shpentry"].ToString();
            password = ConfigurationManager.AppSettings["password-shpentry"].ToString();
            Report.WriteLine("Login to CRM Application");
            CommonMethodsCrm crm = new CommonMethodsCrm();
            crm.LoginToCRMApplication(userName, password);
        }

        [Given(@"I am a shp\.entry or shp\.inquiry User")]
        public void GivenIAmAShp_EntryOrShp_InquiryUser()
        {
            userName = ConfigurationManager.AppSettings["username-CurrentSprintshpentry"].ToString();
            password = ConfigurationManager.AppSettings["password-CurrentSprintshpentry"].ToString();
            Report.WriteLine("Login to CRM Application");
            CommonMethodsCrm crm = new CommonMethodsCrm();
            crm.LoginToCRMApplication(userName, password);
        }

        [Given(@"I am a operations, station owner or sales Management user")]
        public void GivenIAmAOperationsStationOwnerOrSalesManagementUser()
        {
            userName = ConfigurationManager.AppSettings["InternalUserLogin"].ToString();
            password = ConfigurationManager.AppSettings["InternalUserPassword"].ToString();
            Report.WriteLine("Login to CRM Application");
            CommonMethodsCrm crm = new CommonMethodsCrm();
            crm.LoginToCRMApplication(userName, password);
        }

        [Given(@"I am Sales user")]
        public void GivenIAmSalesUser()
        {
            userName = ConfigurationManager.AppSettings["username-salesdelta"].ToString();
            password = ConfigurationManager.AppSettings["password-salesdelta"].ToString();
            Report.WriteLine("Login to CRM Application");
            CommonMethodsCrm crm = new CommonMethodsCrm();
            crm.LoginToCRMApplication(userName, password);
        }


        [Given(@"I click on Ltl Quote service Tile")]
        public void GivenIClickOnLtlQuoteServiceTile()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, GetQuote_Ltlimage_id);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I Have selected the (.*) from customer dropdown list")]
        public void GivenIHaveSelectedTheFromCustomerDropdownList(string Customer_Name)
        {            
            Report.WriteLine("Select Customer Name from the dropdown list");
            Click(attributeName_xpath, QuoteList_CustomerDropdown_Label_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_xpath, QuoteList_CustomerDropdown_SearchBox_Xpath, Customer_Name);
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_CustomerDropdownValues_Xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == Customer_Name)
                {
                    DropDownList[i].Click();
                    break;
                }
            }            
        }

        [Given(@"I entered a value in the Enter insured value field")]
        public void GivenIEnteredAValueInTheEnterInsuredValueField()
        {
            Report.WriteLine("Entered a value in the Enter insured value... field");            
            Click(attributeName_xpath, QuoteResult_InsuredVal_Xpath);
            SendKeys(attributeName_xpath, QuoteResult_InsuredVal_Xpath, "100");
            GlobalVariables.webDriver.WaitForPageLoad();
        }
       
        [Given(@"the Terms and Conditions link was displayed")]
        public void GivenTheTermsAndConditionsLinkWasDisplayed()
        {
            VerifyElementPresent(attributeName_xpath, LTL_TermsAndConditions_Results_xpath, "Terms and Conditions");
            Report.WriteLine("Terms and Conditions link displays below Enter Insured Value.. Field");
        }

        [Given(@"I enter required data in the Get Quote LTL page")]
        public void GivenIEnterRequiredDataInTheGetQuoteLTLPage()
        {
            //Steps to enter mandatory field values in Get Quote LTL page

            Report.WriteLine("Clicked on Clear Address under Shipping From section to clear auto-populated addresses if any");
            string _selectedAddress = GetValue(attributeName_id, LTL_SavedOriginAddressDropdown_Id, "value");

            if (_selectedAddress != "" || _selectedAddress != string.Empty)
            {
                Click(attributeName_id, ClearAddress_OriginId);
                Thread.Sleep(4000);
            }            

            //Entering Origin details
            Report.WriteLine("Entering data in origin section");
            SendKeys(attributeName_id, LTL_OriginCity_Id, OriginCity);
            Click(attributeName_id, LTL_OriginStateProvince_Id);
            SelectDropdownValueFromList(attributeName_xpath, LTL_OriginStateProvinceValues_Xpath, OriginState);
            SendKeys(attributeName_id, LTL_OriginZipPostal_Id, OriginZip);

            Report.WriteLine("Clicked on Clear Address under Shipping To section to clear auto-populated addresses if any");
            _selectedAddress = GetValue(attributeName_id, LTL_SavedDestinationAddressDropdown_Id, "value");
            if (_selectedAddress != "" || _selectedAddress != string.Empty)
            {
                Click(attributeName_id, ClearAddress_DestId);
                Thread.Sleep(3000);
            }
                     
            //Entering Destination details
            Report.WriteLine("Entering data in destination section");
            SendKeys(attributeName_id, LTL_DestinationCity_Id, DestinationCity);
            Click(attributeName_id, LTL_DestinationStateProvince_Id);
            SelectDropdownValueFromList(attributeName_xpath, LTL_DestinationStateProvinceValues_Xpath, DestinationState);
            SendKeys(attributeName_id, LTL_DestinationZipPostal_Id, DestinationZip);
            Click(attributeName_id, LTL_DestinationCity_Id);

            //Enter Freight Description
            Click(attributeName_id, GetQuote_ClearItem_Button_Id);
            Report.WriteLine("Clicked on Clear Item link to clear the Freight Description fields");
            
            Report.WriteLine("Enter details in item section");
            //Click(attributeName_id, LTL_Weight_Id);
            Click(attributeName_id, LTL_Classification_Id);
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='scrollable-dropdown-menu-Origin']/div/span[1]/span/div/span/div/p"));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == Classification)
                {
                    DropDownList[i].Click();
                    break;
                }
            }
            SendKeys(attributeName_id, LTL_Weight_Id, Weight);
            Thread.Sleep(3000);

        }

        [Given(@"I Click on View Quote Results button")]
        public void GivenIClickOnViewQuoteResultsButton()
        {
            Report.WriteLine("Clicked the View Quote Results button");
            // GlobalVariables.webDriver.WaitForPageLoad();
            
            Click(attributeName_id, ViewQuoteResultsBtn_id);            
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementPresent(attributeName_xpath, LTL_TermsAndConditions_Results_xpath, "Terms and Conditions");
            Thread.Sleep(30000);
        }
        
        [When(@"I click the Terms and Conditions link")]
        public void WhenIClickTheTermsAndConditionsLink()
        {
            Report.WriteLine("Clicked in Terms and Conditions link");
            Click(attributeName_xpath, LTL_TermsAndConditions_Results_xpath);
        }

        [When(@"I click Terms and Conditions link next to Show Insured Rate button")]
        public void WhenIClickTermsAndConditionsLinkNextToShowInsuredRateButton()
        {
            Click(attributeName_xpath, LTL_TermsAndConditions_Results_xpath);
            Report.WriteLine("Clicked on Terms and Conditions link next to Show Insured Rate button");
        }


        [Then]
        public void Then_I_verify_the_carrier_legal_liability_verbiage_is_Carrier_s_legal_liability_per_lb_if_uninsured()
        {
            IList<IWebElement> carriersLegalLiabilityElements = GlobalVariables.webDriver.FindElements(By.XPath(QuoteResults_CarrierLegalLiability_All_XPath));
            List<string> carriersLegalLiabilityValues = objWebElementOperations.GetListFromIWebElement(carriersLegalLiabilityElements);

            for (int i = 0; i < carriersLegalLiabilityValues.Count; i++)
            {
                Report.WriteLine("Verification that the carrier legal liability verbiage is: Carrier's legal liability per lb if uninsured");
                Assert.AreEqual("Carrier's legal liability per lb if uninsured", carriersLegalLiabilityValues[i]);
            }
        }
        
        [Then]
        public void Then_I_verify_the_carrier_max_liability_verbiage_is_Carrier_s_max_liability_if_uninsured()
        {
            IList<IWebElement> carriersMaxLiabilityElements = GlobalVariables.webDriver.FindElements(By.XPath(QuoteResults_CarrierMaxLiability_All_XPath));
            List<string> carriersMaxLiabilityValues = objWebElementOperations.GetListFromIWebElement(carriersMaxLiabilityElements);

            for (int i = 0; i < carriersMaxLiabilityValues.Count; i++)
            {
                Report.WriteLine("Verification that the carrier Max liability verbiage is: Carrier's max liability if uninsured");
                Assert.AreEqual("Carrier's max liability if uninsured", carriersMaxLiabilityValues[i]);
            }
        }
        
        [Then]
        public void Then_I_verify_the_carrier_legal_liability_Currency_value_for_New_is_formatted_to_xxx_xx()
        {
            IList<IWebElement> carriersMaxLiabilityNewElements = GlobalVariables.webDriver.FindElements(By.XPath(QuoteResults_CarrierLegalLiability_New_Values_All_XPath));
            List<string> carrierLegalLiabilityNewValues = objWebElementOperations.GetListFromIWebElement(carriersMaxLiabilityNewElements);

            //Verify that the Carrier's Max Liability New value has 2 decimal places 
            string message = "Verification of 2 decimal places for Carrier's Max Liability New value";

            for (int i = 0; i < carrierLegalLiabilityNewValues.Count; i++)
            {
                if (carrierLegalLiabilityNewValues[i].Contains("Used"))
                {
                    string carriersLegalLiabilityNewValue = carrierLegalLiabilityNewValues[i].Split(new string[] { "\r\n" }, StringSplitOptions.None)?[1];
                    carrierLegalLiabilityNewValues[i] = carriersLegalLiabilityNewValue;
                }
            }

            VerifyTheNumberFormat(carrierLegalLiabilityNewValues, message);
        }
        
        [Then]
        public void Then_I_verify_the_carrier_legal_liability_Currency_value_for_Used_is_formatted_to_xxx_xx()
        {
            IList<IWebElement> carriersMaxLiabilityUsedElements = GlobalVariables.webDriver.FindElements(By.XPath(QuoteResults_CarrierLegalLiability_Used_Values_All_XPath));
            List<string> carriersLegaLiabilityUsedValues = objWebElementOperations.GetListFromIWebElement(carriersMaxLiabilityUsedElements);

            //Verify that the Carrier's Max Liability Used value has 2 decimal places 
            string message = "Verification of 2 decimal places for Carrier's Max Liability Used value";

            for (int i = 0; i < carriersLegaLiabilityUsedValues.Count; i++)
            {
                if (carriersLegaLiabilityUsedValues[i].Contains("New")){
                    string carriersLegalLiabilityUsedValue = carriersLegaLiabilityUsedValues[i].Split(new string[] { "\r\n" }, StringSplitOptions.None)?[1];
                    carriersLegaLiabilityUsedValues[i] = carriersLegalLiabilityUsedValue;
                }
            }

            VerifyTheNumberFormat(carriersLegaLiabilityUsedValues, message);
        }
        
        [Then]
        public void Then_I_verify_the_carrier_max_liability_Currency_value_for_New_is_formatted_to_xxx_xx()
        {
            IList<IWebElement> carriersMaxLiabilityNewElements = GlobalVariables.webDriver.FindElements(By.XPath(QuoteResults_CarrierMaxLiability_New_Values_All_XPath));
            List<string> carriersMaxLiabilityNewValues = objWebElementOperations.GetListFromIWebElement(carriersMaxLiabilityNewElements);

            //Verify that the Carrier's Max Liability New value has 2 decimal places 
            string message = "Verification of 2 decimal places for Carrier's Max Liability New value";

            for(int i = 0; i < carriersMaxLiabilityNewValues.Count; i++)
            {
                string carriersMaxLiabilityNewValue = carriersMaxLiabilityNewValues[i].Split(new string[] { "\r\n" }, StringSplitOptions.None)?[1];
                carriersMaxLiabilityNewValues[i] = carriersMaxLiabilityNewValue;
            }

            VerifyTheNumberFormat(carriersMaxLiabilityNewValues, message);
        }
        
        [Then]
        public void Then_I_verify_the_carrier_max_liability_Currency_value_for_Used_is_formatted_to_xxx_xx()
        {
            IList<IWebElement> carriersMaxLiabilityUsedElements = GlobalVariables.webDriver.FindElements(By.XPath(QuoteResults_CarrierMaxLiability_Used_Values_All_XPath));
            List<string> carriersMaxLiabilityUsedValues = objWebElementOperations.GetListFromIWebElement(carriersMaxLiabilityUsedElements);

            //Verify that the Carrier's Max Liability Used value has 2 decimal places 
            string message = "Verification of 2 decimal places for Carrier's Max Liability Used value";

            for (int i = 0; i < carriersMaxLiabilityUsedValues.Count; i++)
            {
                string carriersMaxLiabilityUsedValue = carriersMaxLiabilityUsedValues[i].Split(new string[] { "\r\n" }, StringSplitOptions.None)?[1];
                carriersMaxLiabilityUsedValues[i] = carriersMaxLiabilityUsedValue;
            }

            VerifyTheNumberFormat(carriersMaxLiabilityUsedValues, message);
        }

        [Then]
        public void Then_I_verify_the_text_color_of_the_carrier_liability_information_is_in_dark_gray()
        {
            string darkgray = "rgba(169, 169, 169, 1)";
            IList<IWebElement> carriersLegalLiabilityElements = GlobalVariables.webDriver.FindElements(By.XPath(QuoteResults_CarrierLegalLiability_All_XPath));
            List<string> carriersLegalLiabilityValues = objWebElementOperations.GetListFromIWebElement(carriersLegalLiabilityElements);

            for (int i = 0; i < carriersLegalLiabilityValues.Count; i++)
            {
                string carrierLiabilityColor = GetCSSValue(attributeName_xpath, QuoteResults_CarrierLegalLiability_All_XPath, "color");
                Report.WriteLine("Verification that the carrier legal liability verbiage is: Carrier's legal liability per lb if uninsured");
                Assert.AreEqual(darkgray, carrierLiabilityColor);
            }
        }
        
        [Then]
        public void Then_I_verify_the_service_days_is_displayed_with_days_to_the_right_of_the_number_of_service_days()
        {
            IList<IWebElement> serviceLaneElements = GlobalVariables.webDriver.FindElements(By.XPath(QuoteResults_Service_Values_All_XPath));
            List<string> serviceLaneValues = objWebElementOperations.GetListFromIWebElement(serviceLaneElements);

            bool isServiceDaysVerbiageSet = true;

            for (int i = 0; i < serviceLaneValues.Count; i++)
            {
                if (!serviceLaneValues[i].Contains("Days"))
                {
                    isServiceDaysVerbiageSet = false;
                    break;
                }
            }

            Report.WriteLine("Verification that the service days are displayed days to the right of the number of service days");
            Assert.IsTrue(isServiceDaysVerbiageSet);
        }

        [Then]
        public void Then_I_verify_the_verbiage_Direct_to_Destination_is_displayed_as_Direct_and_Indirect_to_Destination_is_displayed_as_Indirect()
        {
            IList<IWebElement> serviceLaneElements = GlobalVariables.webDriver.FindElements(By.XPath(QuoteResults_Service_Values_All_XPath));
            List<string> serviceLaneValues = objWebElementOperations.GetListFromIWebElement(serviceLaneElements);

            bool isServiceLaneVerbiageSet = true;

            for (int i = 0; i < serviceLaneValues.Count; i++)
            {
                string[] serviceLanes = serviceLaneValues[i].Split(new string[] { "\r\n" }, StringSplitOptions.None);

                string serviceLane = (serviceLanes != null && serviceLanes.Any()) ? serviceLanes[1] : string.Empty;
                if (serviceLane != "Direct" && serviceLane != "InDirect" && serviceLane != "N/A")
                {
                    isServiceLaneVerbiageSet = false;
                    break;
                }
            }

            Report.WriteLine("Verification that the service Lane is displayed as Direct/Indirect");
            Assert.IsTrue(isServiceLaneVerbiageSet);
        }
        
        [Then]
        public void Then_I_verify_the_Rate_total_is_displayed_in_bold_type()
        {
            string fontWeight = GetCSSValue(attributeName_xpath, QuoteResults_FC_Total_Xpath, "font-weight");

            Report.WriteLine("Verification that the Rate total is displayed in bold type");
            Assert.AreEqual("700", fontWeight);
        }

        [Then(@"I verify Insured Rate total is displayed in bold type for external user")]
        public void ThenIVerifyInsuredRateTotalIsDisplayedInBoldTypeForExternalUser()
        {
            SendKeys(attributeName_id, QuoteResults_ShipmentValue_Id, "100");
            Click(attributeName_id, QuoteResults_ShowInsuredRatesButton_Id);
            GlobalVariables.webDriver.WaitForPageLoad();

            string fontWeight = GetCSSValue(attributeName_xpath, QuoteResults_ExternalUser_FC_InsTotal_Xpath, "font-weight");

            Report.WriteLine("Verification that the Insured Rate total is displayed in bold type");
            Assert.AreEqual("700", fontWeight);
        }

        [Then]
        public void Then_I_verify_Insured_Rate_total_is_displayed_in_bold_type()
        {
            SendKeys(attributeName_id, QuoteResults_ShipmentValue_Id, "100");
            Click(attributeName_id, QuoteResults_ShowInsuredRatesButton_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            //QuoteResults_ExternalUser_FC_InsTotal_Xpath
            string fontWeight = GetCSSValue(attributeName_xpath, QuoteResults_FC_InsTotal_Xpath, "font-weight");

            Report.WriteLine("Verification that the Insured Rate total is displayed in bold type");
            Assert.AreEqual("700", fontWeight);
        }

        [Then(@"I verify the Estimated Rate total is formatted to xxx\.xx and displayed in bold type")]
        public void ThenIVerifyTheEstimatedRateTotalIsFormattedToXxx_XxAndDisplayedInBoldType()
        {
            string fontWeight = GetCSSValue(attributeName_xpath, QuoteResults_InternalFC_EstTotal_Xpath, "font-weight");
            Report.WriteLine("Verification that the Estimated Rate total is formatted to xxx.xx");

            IList<IWebElement> estimateRatesElements = GlobalVariables.webDriver.FindElements(By.XPath(QuoteResults_InternalFC_EstTotal_Xpath));
            List<string> estimateRatesValues = objWebElementOperations.GetListFromIWebElement(estimateRatesElements);

            //Verify that the Estimated margin value has 2 decimal places 
            string message = "Verification of 2 decimal places for Estimated margin value";
            VerifyTheNumberFormat(estimateRatesValues, message);

            Report.WriteLine("Verification that the Estimated Rate total is displayed in bold type");
            Assert.AreEqual("700", fontWeight);
        }

        [Then]
        public void Then_I_verify_the_Terms_and_Conditions_link_and_verbiage_Creating_an_insured_shipment_means_you_agree_to_the_Terms_and_Conditions_is_available_at_the_bottom_of_the_page()
        {
            Report.WriteLine("Verification that the quote insured TermsAndConditions link is present in Quote results page");
            Assert.IsTrue(IsElementPresent(attributeName_xpath, QuoteResults_InsuredTermsAndConditionsTextId, "InsuredTermsAndConditionsTextId"));

            string termsAndConditionsLinkText = Gettext(attributeName_xpath, QuoteResults_InsuredTermsAndConditionsTextId);
            
            Report.WriteLine("Verification that the quote insured TermsAndConditions Text is *Creating an insured quote means you agree to the Terms and Conditions.");
            Assert.AreEqual("terms and conditions", termsAndConditionsLinkText);
        }

        [When(@"I click on TermsAndConditions link at the bottom of the Quote results page")]
        public void WhenIClickOnTermsAndConditionsLinkAtTheBottomOfTheQuoteResultsPage()
        {
            Report.WriteLine("Click on Terms and conditions Link at the bottom of the page");
            GlobalVariables.webDriver.WaitForPageLoad();            
            Click(attributeName_xpath, QuoteResults_InsuredTermsAndConditionsTextId);
        }

        [Then]
        public void Then_I_verify_the_Terms_and_Conditions_applicable_to_default_or_customer_specific_insurance_all_risk_settings_is_displayed()
        {
            string actualTermsAndConditionsForDefaultCustomer = ((IJavaScriptExecutor)GlobalVariables.webDriver).ExecuteScript("return $('.terms-text').text()")?.ToString();
            bool isTermsAndConditionsTextValid = false;

            if (actualTermsAndConditionsForDefaultCustomer.Contains("User understands and agrees by selecting this option, the goods being shipped will be insured for All Risk coverage per the terms and conditions of the policy. The deductible is $0 and includes coverage on goods and/or merchandise consisting of new and used general commodities, including new, used and remanufactured equipment or equipment parts.  If proper exception is not made on the delivery receipt by the consignee, all risk coverage is void."))
            {
                Report.WriteLine("first paragraph is correct");

                if (actualTermsAndConditionsForDefaultCustomer.Contains("“All Risk” is defined as all risk of physical loss or damage from any external cause, excepting those risks excluded by the F.C. & S. and S.R. & C.C. warranties of this policy. “All Risk” excludes marring, chipping, denting, scratching, rust, oxidation, discoloration, electrical and/or mechanical breakdown or derangement and/or any pre-existing condition. User understands and agrees that by exercising this option they are creating time-stamped documentation of coverage and that they may receive a maximum payment based on that insured value that they had insured that shipment for. If partial damage occurs and they did not insure for the full replacement value, the user understands that they will receive a partial payment that is proportionate to the value that they insured for."))
                {
                    Report.WriteLine("second paragraph is correct");

                    if (actualTermsAndConditionsForDefaultCustomer.Contains("User understands and agrees to file any and all claims within 60 days with their DLS Worldwide account rep (or supporting operations team) as soon as possible after the claim becomes known and that when filing claims they are to include a copy of the bill of lading, a copy of the commercial invoice that outlines the replacement value of the shipment and a photo demonstrating that damage did occur during transit."))
                    {
                        Report.WriteLine("third paragraph is correct");
                    }

                    isTermsAndConditionsTextValid = true;
                    Report.WriteLine("Verified that the Terms and conditions are displayed for Default Ins All Risk Customer");
                }
            }

            Assert.IsTrue(isTermsAndConditionsTextValid);
        }

        [Then(@"I verify the Terms and Conditions applicable for default or customer specific insurance all risk settings is displayed")]
        public void ThenIVerifyTheTermsAndConditionsApplicableForDefaultOrCustomerSpecificInsuranceAllRiskSettingsIsDisplayed()
        {
            string actualTermsAndConditionsForDefaultCustomer = ((IJavaScriptExecutor)GlobalVariables.webDriver).ExecuteScript("return $('.terms-text').text()")?.ToString();
            bool isTermsAndConditionsTextValid = false;

            if (actualTermsAndConditionsForDefaultCustomer.Contains("User understands and agrees by selecting this option, the goods being shipped will be insured for All Risk coverage per the terms and conditions of the policy which are attached on page 2. The deductible is $500.00 and includes coverage on goods and/ or merchandise consisting of new and used general commodities, including new, used and remanufactured equipment or equipment parts.See “Evidence of Insurance” page for special insuring conditions as well as excluded commodities."))
            {
                Report.WriteLine("first paragraph is correct");

                if (actualTermsAndConditionsForDefaultCustomer.Contains("User understands and agrees to file any and all claims within 60 days with their DLS Worldwide account rep (or supporting operations team) as soon as possible after the claim becomes known and that when filing claims they are to include all supporting documentation.I.e.copy of the bill of lading, a copy of the delivery receipt, the commercial invoice that outlines the value of the shipment and a photo demonstrating that damage did occur during transit."))
                {
                    Report.WriteLine("second paragraph is correct");

                    if (actualTermsAndConditionsForDefaultCustomer.Contains("User also understands and agrees that DLS Worldwide reserves the right to file a subrogated claim with the carrier and that DLS Worldwide also reserves the right to refuse program access due to inaccurate or fraudulent claims, excessive claims history and/ or failure to complete with recommended shipping and/ or packaging guidelines."))
                    {
                        Report.WriteLine("third paragraph is correct");
                    }

                    isTermsAndConditionsTextValid = true;
                    Report.WriteLine("Verified that the Terms and conditions are displayed for Default Ins All Risk Customer");
                }
            }

            Assert.IsTrue(isTermsAndConditionsTextValid);
        }
        
        [Then]
        public void Then_I_verify_the_Terms_and_Conditions_applicable_to_PPP_insurance_all_risk_settings_is_displayed()
        {
            string actualTermsAndConditionsForNonDefaultCustomer = ((IJavaScriptExecutor)GlobalVariables.webDriver).ExecuteScript("return $('.terms-text').text()")?.ToString();
            bool isTermsAndConditionsTextValid = false;
            
            if (actualTermsAndConditionsForNonDefaultCustomer.Contains("User understands and agrees by selecting this option, the goods being shipped will be insured under our Product Protection Plan (PPP) per the terms and conditions of the policy; which are-detailed after the Terms and Conditions. The deductible is $0 and includes coverage on goods and/or merchandise consisting of new and used general commodities, including new, used and remanufactured equipment or equipment parts. If proper exception is not made on the delivery receipt by the consignee, all risk coverage is void."))
            {
                Report.WriteLine("first paragraph is correct");
                if (actualTermsAndConditionsForNonDefaultCustomer.Contains("“All Risk” is defined as all risk of physical loss or damage from any external cause, excepting those risks excluded by the F.C. & S. and S.R. & C.C. warranties of this policy. “PPP” excludes marring, chipping, denting, scratching, rust, oxidation, discoloration, electrical and/or mechanical breakdown or derangement and/or any pre-existing condition. User understands and agrees that by exercising this option they are creating time-stamped documentation of coverage and that they may receive a maximum payment based on that insured value that they had insured that shipment for. If partial damage occurs and they did not insure for the full replacement value, the user understands that they will receive a partial payment that is proportionate to the value that they insured for."))
                {
                    Report.WriteLine("second paragraph is correct");
                    if (actualTermsAndConditionsForNonDefaultCustomer.Contains("User understands and agrees to file any and all claims within 60 days with their DLS Worldwide account rep (or supporting operations team) as soon as possible after the claim becomes known and that when filing claims they are to include a copy of the bill of lading, a copy of the commercial invoice that outlines the replacement value of the shipment and a photo demonstrating that damage did occur during transit."))
                    {
                        Report.WriteLine("third paragraph is correct");
                        if(actualTermsAndConditionsForNonDefaultCustomer.Contains("User also understands and agrees that DLS Worldwide reserves the right to file a subrogated claim with the carrier and that DLS Worldwide also reserves the right to refuse program access due to inaccurate or fraudulent claims, excessive claims history and/or failure to complete with recommended shipping and/or packaging guidelines."))
                        {
                            Report.WriteLine("fourth paragraph is correct");                            
                            actualTermsAndConditionsForNonDefaultCustomer = Gettext(attributeName_xpath, ".//div[@id = 'shipment-model']//h6");
                            if (actualTermsAndConditionsForNonDefaultCustomer.Contains("AFFIRMATION OF SERVICE TERMS - DLS WORLDWIDE PRODUCT PROTECTION PLAN"))
                            {
                                Report.WriteLine("Affirmation of Service Terms title is correct");
                                actualTermsAndConditionsForNonDefaultCustomer = Gettext(attributeName_xpath, ".//div[@id = 'shipment-model']//p[2]");                                
                                if (actualTermsAndConditionsForNonDefaultCustomer.Contains("As of Jan 1, 2019 the following requirements will be set in place as firm policies and procedures for the Product Protection Plan. This program is a zero-deductible full-coverage insurance option that provides coverage for new, used and remanufactured parts and equipment."))
                                {
                                    Report.WriteLine("First Paragraph under AFFIRMATION OF SERVICE TERMS title is correct");
                                    actualTermsAndConditionsForNonDefaultCustomer = Gettext(attributeName_xpath, ".//div[@id = 'shipment-model']//ol");
                                    if (actualTermsAndConditionsForNonDefaultCustomer.Contains("If freight arrived with damage consignees must sign off on it with damage noted at time of receipt.") &&
                                        actualTermsAndConditionsForNonDefaultCustomer.Contains("If consignee signs off on the shipment as clear at the time of receipt and damage is notated later, customer still has forty-eight business hours to notify their DLS representative directly.") &&
                                       actualTermsAndConditionsForNonDefaultCustomer.Contains("Customers must submit standard DLS claims form that can be found online at DLSWorldwide.com. Customers must submit a commercial invoice demonstrating what the product sold for and may also be reimbursed for original freight costs if the insured value included the freight charges.") &&
                                       actualTermsAndConditionsForNonDefaultCustomer.Contains("Proper packaging is required and claims may be denied for improper packaging.") &&
                                       actualTermsAndConditionsForNonDefaultCustomer.Contains("All shipments with a value of $2500.00 or more will require photos of commodity prior to packing, once packaged and finally at destination showing damages. If pictures are unavailable, the claim can be denied. Everyone has a smart phone these days and if you take a minute to capture a photo of the item before and after it has been packaged it will help accelerate the claims process and eliminate any questions or concerns regarding the condition of the commodity prior to packaging or packaging itself.") &&
                                       actualTermsAndConditionsForNonDefaultCustomer.Contains("All claims will be acknowledged within thirty days by our corporate office. Claims below $2500.00 will be concluded within thirty days and claims above $2500.00 may require an independent inspection and should be concluded within forty-five to sixty days.") &&
                                       actualTermsAndConditionsForNonDefaultCustomer.Contains("If and when claims are honored at full value, DLS Worldwide reserves the right to claim ownership of product and may make arrangement for product to be picked up. If DLS Worldwide does not claim ownership of said product, a disposal certificate may be requested.") &&
                                       actualTermsAndConditionsForNonDefaultCustomer.Contains("A report documenting claims by station and by customer will be provided on a quarterly basis. If a particular customer has an overly excessive claims ratio their ability to participate in this program may be suspended and/or denied.") &&
                                       actualTermsAndConditionsForNonDefaultCustomer.Contains("Maximum insured value shall not exceed $7500.00 per shipment unless prior approval is received. Such approval will be based on volume and packaging procedures.") &&
                                       actualTermsAndConditionsForNonDefaultCustomer.Contains("Any and all appeals to claims rulings must be filed with your DLS Sales Representative who in turn will bring it to the attention of their regional representative and the DLS Worldwide claims department."))
                                    {
                                        Report.WriteLine("Point 1 to 10 under AFFIRMATION OF SERVICE TERMS is correct");
                                        
                                        if (actualTermsAndConditionsForNonDefaultCustomer.Contains("Program does not provide coverage for glass of any kind") &&
                                           actualTermsAndConditionsForNonDefaultCustomer.Contains("Program does not cover products moved by Central Transport or UPS") &&
                                           actualTermsAndConditionsForNonDefaultCustomer.Contains("Claim must be filed within 60 days of delivery or claims may be denied.") &&
                                           actualTermsAndConditionsForNonDefaultCustomer.Contains("Claimant must mitigate the loss down if possible. i.e. repair, salvage allowance.") &&
                                           actualTermsAndConditionsForNonDefaultCustomer.Contains("If shipments are signed off as clear at the time of receipt and damages are not reported to the DLS Worldwide representative within forty-eight business hours claims will be denied.") &&
                                           actualTermsAndConditionsForNonDefaultCustomer.Contains("If shipper or consignee cannot provide some sort of proof that damages occurred during transit claims may be denied.") &&
                                           actualTermsAndConditionsForNonDefaultCustomer.Contains("If commodity is not packaged for normal hazards of transit the claim will be denied due to insufficient packaging.") &&
                                           actualTermsAndConditionsForNonDefaultCustomer.Contains("If any nefarious activities within the packaging, delivery, inspection or documentation processes are suspected claims may be delayed and eventually denied."))
                                        {
                                            Report.WriteLine("All the points under Point 5 of AFFIRMATION OF SERVICE TERMS is correct");
                                        }
                                    }
                                }
                            }
                        }
                    }

                    isTermsAndConditionsTextValid = true;
                    Report.WriteLine("Verified that the Terms and conditions are displayed for Non Default Ins All Risk/PPP Customer");
                }               
            }

            Assert.IsTrue(isTermsAndConditionsTextValid);
        }

        [Then(@"I verify the Terms and Conditions applicable to PPP insurance all risk settings displayed")]
        public void ThenIVerifyTheTermsAndConditionsApplicableToPPPInsuranceAllRiskSettingsDisplayed()
        {
            string actualTermsAndConditionsForNonDefaultCustomer = ((IJavaScriptExecutor)GlobalVariables.webDriver).ExecuteScript("return $('.terms-text').text()")?.ToString();
            bool isTermsAndConditionsTextValid = false;

            if (actualTermsAndConditionsForNonDefaultCustomer.Contains("User understands and agrees by selecting this option, the goods being shipped will be insured under our Product Protection Plan (PPP) per the terms and conditions of the policy; which are-detailed after the Terms and Conditions. The deductible is $0 and includes coverage on goods and/or merchandise consisting of new and used general commodities, including new, used and remanufactured equipment or equipment parts. If proper exception is not made on the delivery receipt by the consignee, all risk coverage is void."))
            {
                Report.WriteLine("first paragraph is correct");
                if (actualTermsAndConditionsForNonDefaultCustomer.Contains("“All Risk” is defined as all risk of physical loss or damage from any external cause, excepting those risks excluded by the F.C. & S. and S.R. & C.C. warranties of this policy. “PPP” excludes marring, chipping, denting, scratching, rust, oxidation, discoloration, electrical and/or mechanical breakdown or derangement and/or any pre-existing condition. User understands and agrees that by exercising this option they are creating time-stamped documentation of coverage and that they may receive a maximum payment based on that insured value that they had insured that shipment for. If partial damage occurs and they did not insure for the full replacement value, the user understands that they will receive a partial payment that is proportionate to the value that they insured for."))
                {
                    Report.WriteLine("second paragraph is correct");
                    if (actualTermsAndConditionsForNonDefaultCustomer.Contains("User understands and agrees to file any and all claims within 60 days with their DLS Worldwide account rep (or supporting operations team) as soon as possible after the claim becomes known and that when filing claims they are to include a copy of the bill of lading, a copy of the commercial invoice that outlines the replacement value of the shipment and a photo demonstrating that damage did occur during transit."))
                    {
                        Report.WriteLine("third paragraph is correct");
                        if (actualTermsAndConditionsForNonDefaultCustomer.Contains("User also understands and agrees that DLS Worldwide reserves the right to file a subrogated claim with the carrier and that DLS Worldwide also reserves the right to refuse program access due to inaccurate or fraudulent claims, excessive claims history and/or failure to complete with recommended shipping and/or packaging guidelines."))
                        {
                            Report.WriteLine("fourth paragraph is correct");
                            actualTermsAndConditionsForNonDefaultCustomer = Gettext(attributeName_xpath, ".//div[@id = 'showModalScrollableCntBtn']//h6");
                            if (actualTermsAndConditionsForNonDefaultCustomer.Contains("AFFIRMATION OF SERVICE TERMS - DLS WORLDWIDE PRODUCT PROTECTION PLAN"))
                            {
                                Report.WriteLine("Affirmation of Service Terms title is correct");
                                actualTermsAndConditionsForNonDefaultCustomer = Gettext(attributeName_xpath, ".//div[@id = 'showModalScrollableCntBtn']//p[2]");
                                if (actualTermsAndConditionsForNonDefaultCustomer.Contains("As of Jan 1, 2019 the following requirements will be set in place as firm policies and procedures for the Product Protection Plan. This program is a zero-deductible full-coverage insurance option that provides coverage for new, used and remanufactured parts and equipment."))
                                {
                                    Report.WriteLine("First Paragraph under AFFIRMATION OF SERVICE TERMS title is correct");
                                    actualTermsAndConditionsForNonDefaultCustomer = Gettext(attributeName_xpath, ".//div[@id = 'showModalScrollableCntBtn']//ol");
                                    if (actualTermsAndConditionsForNonDefaultCustomer.Contains("If freight arrived with damage consignees must sign off on it with damage noted at time of receipt.") &&
                                        actualTermsAndConditionsForNonDefaultCustomer.Contains("If consignee signs off on the shipment as clear at the time of receipt and damage is notated later, customer still has forty-eight business hours to notify their DLS representative directly.") &&
                                       actualTermsAndConditionsForNonDefaultCustomer.Contains("Customers must submit standard DLS claims form that can be found online at DLSWorldwide.com. Customers must submit a commercial invoice demonstrating what the product sold for and may also be reimbursed for original freight costs if the insured value included the freight charges.") &&
                                       actualTermsAndConditionsForNonDefaultCustomer.Contains("Proper packaging is required and claims may be denied for improper packaging.") &&
                                       actualTermsAndConditionsForNonDefaultCustomer.Contains("All shipments with a value of $2500.00 or more will require photos of commodity prior to packing, once packaged and finally at destination showing damages. If pictures are unavailable, the claim can be denied. Everyone has a smart phone these days and if you take a minute to capture a photo of the item before and after it has been packaged it will help accelerate the claims process and eliminate any questions or concerns regarding the condition of the commodity prior to packaging or packaging itself.") &&
                                       actualTermsAndConditionsForNonDefaultCustomer.Contains("All claims will be acknowledged within thirty days by our corporate office. Claims below $2500.00 will be concluded within thirty days and claims above $2500.00 may require an independent inspection and should be concluded within forty-five to sixty days.") &&
                                       actualTermsAndConditionsForNonDefaultCustomer.Contains("If and when claims are honored at full value, DLS Worldwide reserves the right to claim ownership of product and may make arrangement for product to be picked up. If DLS Worldwide does not claim ownership of said product, a disposal certificate may be requested.") &&
                                       actualTermsAndConditionsForNonDefaultCustomer.Contains("A report documenting claims by station and by customer will be provided on a quarterly basis. If a particular customer has an overly excessive claims ratio their ability to participate in this program may be suspended and/or denied.") &&
                                       actualTermsAndConditionsForNonDefaultCustomer.Contains("Maximum insured value shall not exceed $7500.00 per shipment unless prior approval is received. Such approval will be based on volume and packaging procedures.") &&
                                       actualTermsAndConditionsForNonDefaultCustomer.Contains("Any and all appeals to claims rulings must be filed with your DLS Sales Representative who in turn will bring it to the attention of their regional representative and the DLS Worldwide claims department."))
                                    {
                                        Report.WriteLine("Point 1 to 10 under AFFIRMATION OF SERVICE TERMS is correct");

                                        if (actualTermsAndConditionsForNonDefaultCustomer.Contains("Program does not provide coverage for glass of any kind.") &&
                                           actualTermsAndConditionsForNonDefaultCustomer.Contains("Program does not cover products moved by Central Transport or UPS") &&
                                           actualTermsAndConditionsForNonDefaultCustomer.Contains("Claim must be filed within 60 days of delivery or claims may be denied.") &&
                                           actualTermsAndConditionsForNonDefaultCustomer.Contains("Claimant must mitigate the loss down if possible. i.e. repair, salvage allowance") &&
                                           actualTermsAndConditionsForNonDefaultCustomer.Contains("If shipments are signed off as clear at the time of receipt and damages are not reported to the DLS Worldwide representative within forty-eight business hours claims will be denied") &&
                                           actualTermsAndConditionsForNonDefaultCustomer.Contains("If shipper or consignee cannot provide some sort of proof that damages occurred during transit claims may be denied") &&
                                           actualTermsAndConditionsForNonDefaultCustomer.Contains("If commodity is not packaged for normal hazards of transit the claim will be denied due to insufficient packaging") &&
                                           actualTermsAndConditionsForNonDefaultCustomer.Contains("If any nefarious activities within the packaging, delivery, inspection or documentation processes are suspected claims may be delayed and eventually denied"))
                                        {
                                            Report.WriteLine("All the points under Point 5 of AFFIRMATION OF SERVICE TERMS is correct");
                                        }
                                    }
                                }
                            }
                        }
                    }

                    isTermsAndConditionsTextValid = true;
                    Report.WriteLine("Verified that the Terms and conditions are displayed for Non Default Ins All Risk/PPP Customer");
                }
            }

            Assert.IsTrue(isTermsAndConditionsTextValid);
        }


        [Then]
        public void Then_I_verify_the_Estimated_Margin_total_is_formatted_to_xxx_xx()
        {
            IList<IWebElement> estimateMarginElements = GlobalVariables.webDriver.FindElements(By.XPath(QuoteResults_EstimateMargin_Xpath));
            List<string> estimateMarginValues = objWebElementOperations.GetListFromIWebElement(estimateMarginElements);

            //Verify that the Estimated margin value has 2 decimal places 
            string message = "Verification of 2 decimal places for Estimated margin value";

            VerifyTheNumberFormat(estimateMarginValues, message);
        }

        private void VerifyTheNumberFormat(List<string> listItems, string message)
        {
            for (int i = 0; i < listItems.Count; i++)
            {
                Report.WriteLine(message);
                VerifyThatTheNumberFormatIsWithTwoDecimalPlaces(listItems[i]);
            }
        }

        private void VerifyThatTheNumberFormatIsWithTwoDecimalPlaces(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                //Get value after decimal 
                string valueAfterDecimal = value.Split('.')[1];
                valueAfterDecimal = valueAfterDecimal?.Replace("$", "");
                valueAfterDecimal = valueAfterDecimal?.Replace("%", "");
                valueAfterDecimal = valueAfterDecimal.Trim();
                //Verify that the Estimated margin value has 2 decimal places 
                Assert.AreEqual(2, valueAfterDecimal.Length);
            }
        }
    }
}
