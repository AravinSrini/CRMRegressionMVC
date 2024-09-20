using CRM.UITest.CommonMethods;
using CRM.UITest.Helper.Common;
using CRM.UITest.Helper.DataModels;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Results
{
    [Binding]
    public class ShipmentResultsLTLPage_ImproveResultsDisplaySteps : AddShipments
    {
        public WebElementOperations objWebElementOperations = new WebElementOperations();
        private AddShipmentLTL ltl = new AddShipmentLTL();
        string customer = string.Empty;
        string shipmentType = string.Empty;
        string userType = string.Empty;

        [Given(@"I am a shp\.entry User (.*)")]
        public void GivenIAmAShp_EntryUser(string UserType)
        {
            //Get External User Credentials
            UserTypeLoginCredentials userCredentials = new UserTypeLoginCredentials();
            UserCredentialsModel userModel = userCredentials.GetCredentials(UserType);

            Report.WriteLine("Login to CRM Application");
            CommonMethodsCrm crm = new CommonMethodsCrm();
            crm.LoginToCRMApplication(userModel.UserName, userModel.Password);
        }

        [Given(@"I am a sales, sales management, operations, or station owner user (.*)")]
        public void GivenIAmASalesSalesManagementOperationsOrStationOwnerUser(string UserType)
        {
            //Get Internal User Credentials
            UserTypeLoginCredentials userCredentials = new UserTypeLoginCredentials();
            UserCredentialsModel userModel = userCredentials.GetCredentials(UserType);

            Report.WriteLine("Login to CRM Application");
            CommonMethodsCrm crm = new CommonMethodsCrm();
            crm.LoginToCRMApplication(userModel.UserName, userModel.Password);
        }

        [Given(@"I arrive on the Shipment Results LTL page")]
        public void GivenIArriveOnTheShipmentResultsLTLPage()
        {
            //Click on View rates button
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Clicking on view rate results button");
            scrollElementIntoView(attributeName_xpath, ViewRatesButton_xpath);
            Click(attributeName_xpath, ViewRatesButton_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [When(@"I arrive on the Shipment Results LTL page")]
        public void WhenIArriveOnTheShipmentResultsLTLPage()
        {
            //Click on View rates button
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Clicking on view rate results button");
            scrollElementIntoView(attributeName_xpath, ViewRatesButton_xpath);
            try
            {
                Click(attributeName_xpath, ViewRatesButton_xpath);
            }
            catch
            {
                GlobalVariables.webDriver.WaitForPageLoad();
            }
        }

        [Given(@"I arrive on the External user AddShipments Page")]
        public void GivenIArriveOnTheExternalUserAddShipmentsPage()
        {
            Report.WriteLine("Navigate to Shipment List");
            GlobalVariables.webDriver.WaitForPageLoad();
            ltl.NaviagteToShipmentList();
            GlobalVariables.webDriver.WaitForPageLoad();

            Report.WriteLine("Navigate to Add Shipment Page");
            ltl.SelectCustomerFromShipmentList("External", string.Empty);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I arrive on the Internal user AddShipments Page (.*)")]
        public void GivenIArriveOnTheInternalUserAddShipmentsPage(string CustomerName)
        {
            Report.WriteLine("Navigate to Shipment List");
            GlobalVariables.webDriver.WaitForPageLoad();
            ltl.NaviagteToShipmentList();
            GlobalVariables.webDriver.WaitForPageLoad();

            Report.WriteLine("Navigate to Add Shipment Page");
            ltl.SelectCustomerFromShipmentList("Internal", CustomerName);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I enter data in add LTL Shipment Information page (.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void GivenIEnterDataInAddLTLShipmentInformationPageAndClickOnViewRatesButton(
          string originName,
          string originAddr1,
          string originCity,
          string originState,
          string originZipcode,
          string destinationName,
          string destinationAddr1,
          string destinationCity,
          string destinationState,
          string destinationZipcode,
          string Classification,
          string nmfc,
          string quantity,
          string weight,
          string itemdesc)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Enter all Shipment Information");
            ltl.AddShipmentOriginData(originName, originAddr1, originZipcode);
            ltl.AddShipmentDestinationData(destinationName, destinationAddr1, destinationZipcode);

            scrollElementIntoView(attributeName_xpath, FreightDesp_First_AdditionalItem_Button_xpath);

            Click(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);

            ltl.AddShipmentFreightDescription(Classification, nmfc, quantity, weight, itemdesc);
        }

        [Then(@"the carrier legal liability verbiage is Carrier's legal liability per lb if uninsured")]
        public void ThenTheCarrierLegalLiabilityVerbiageIsCarrierSLegalLiabilityPerLbIfUninsured()
        {
            IList<IWebElement> carriersLegalLiabilityElements = GlobalVariables.webDriver.FindElements(By.XPath("//div[@class = 'col-md-12 carrier-col-maxLiability']/label"));
            List<string> carriersLegalLiabilityValues = objWebElementOperations.GetListFromIWebElement(carriersLegalLiabilityElements);

            for (int i = 0; i < carriersLegalLiabilityValues.Count; i++)
            {
                if (carriersLegalLiabilityValues[i] != "Please contact your DLS representative for carrier liability per pound without insurance")
                {
                    Report.WriteLine("Verification that the carrier legal liability verbiage is: Carrier's legal liability per lb if uninsured");
                    Assert.AreEqual("Carrier's legal liability per lb if uninsured", carriersLegalLiabilityValues[i]);
                }
            }
        }

        [Then(@"the carrier max liability verbiage is Carrier's max liability if uninsured")]
        public void ThenTheCarrierMaxLiabilityVerbiageIsCarrierSMaxLiabilityIfUninsured()
        {
            IList<IWebElement> carriersMaxLiabilityElements = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentResults_CarrierMaxLiability_All_XPath));
            List<string> carriersMaxLiabilityValues = objWebElementOperations.GetListFromIWebElement(carriersMaxLiabilityElements);

            for (int i = 0; i < carriersMaxLiabilityValues.Count; i++)
            {
                Report.WriteLine("Verification that the carrier Max liability verbiage is: Carrier's max liability if uninsured");
                Assert.AreEqual("Carrier's max liability if uninsured", carriersMaxLiabilityValues[i]);
            }
        }

        [Then(@"the carrier legal liability Currency value for Used is formatted to xxx\.xx")]
        public void ThenTheCarrierLegalLiabilityCurrencyValueForUsedIsFormattedToXxx_Xx()
        {
            IList<IWebElement> carriersMaxLiabilityUsedElements = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentResults_CarrierLegalLiability_Used_Values_All_XPath));
            List<string> carriersMaxLiabilityUsedValues = objWebElementOperations.GetListFromIWebElement(carriersMaxLiabilityUsedElements);

            for (int i = 0; i < carriersMaxLiabilityUsedValues.Count; i++)
            {
                //Verify that the Carrier's Max Liability Used value has 2 decimal places 
                Report.WriteLine("Verification of 2 decimal places for Carrier's Max Liability Used value");
                VerifyThatTheNumberFormatIsWithTwoDecimalPlaces(carriersMaxLiabilityUsedValues[i]);
            }
        }

        [Then(@"the carrier legal liability Currency value for New is formatted to xxx\.xx")]
        public void ThenTheCarrierLegalLiabilityCurrencyValueForNewIsFormattedToXxx_Xx()
        {
            IList<IWebElement> carriersMaxLiabilityNewElements = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentResults_CarrierLegalLiability_New_Values_All_XPath));
            List<string> carriersMaxLiabilityNewValues = objWebElementOperations.GetListFromIWebElement(carriersMaxLiabilityNewElements);

            for (int i = 0; i < carriersMaxLiabilityNewValues.Count; i++)
            {
                //Verify that the Carrier's Max Liability New value has 2 decimal places 
                Report.WriteLine("Verification of 2 decimal places for Carrier's Max Liability New value");
                VerifyThatTheNumberFormatIsWithTwoDecimalPlaces(carriersMaxLiabilityNewValues[i]);
            }
        }

        [Then(@"the carrier max liability Currency value for New is formatted to xxx\.xx")]
        public void ThenTheCarrierMaxLiabilityCurrencyValueForNewIsFormattedToXxx_Xx()
        {
            IList<IWebElement> carriersMaxLiabilityNewElements = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentResults_CarrierMaxLiability_New_Values_All_XPath));
            List<string> carriersMaxLiabilityNewValues = objWebElementOperations.GetListFromIWebElement(carriersMaxLiabilityNewElements);

            for (int i = 0; i < carriersMaxLiabilityNewValues.Count; i++)
            {
                //Verify that the Carrier's Max Liability New value has 2 decimal places 
                Report.WriteLine("Verification of 2 decimal places for Carrier's Max Liability New value");
                VerifyThatTheNumberFormatIsWithTwoDecimalPlaces(carriersMaxLiabilityNewValues[i]);
            }
        }

        [Then(@"the carrier max liability Currency value for Used is formatted to xxx\.xx")]
        public void ThenTheCarrierMaxLiabilityCurrencyValueForUsedIsFormattedToXxx_Xx()
        {
            IList<IWebElement> carriersMaxLiabilityUsedElements = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentResults_CarrierMaxLiability_Used_Values_All_XPath));
            List<string> carriersMaxLiabilityUsedValues = objWebElementOperations.GetListFromIWebElement(carriersMaxLiabilityUsedElements);

            for (int i = 0; i < carriersMaxLiabilityUsedValues.Count; i++)
            {
                //Verify that the Carrier's Max Liability Used value has 2 decimal places 
                Report.WriteLine("Verification of 2 decimal places for Carrier's Max Liability Used value");
                VerifyThatTheNumberFormatIsWithTwoDecimalPlaces(carriersMaxLiabilityUsedValues[i]);
            }
        }

        [Then(@"the Estimated Margin total is formatted to xxx\.xx")]
        public void ThenTheEstimatedMarginTotalIsFormattedToXxx_Xx()
        {
            IList<IWebElement> estimateMarginElements = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentResults_EstimateMargin_Xpath));
            List<string> estimateMarginValues = objWebElementOperations.GetListFromIWebElement(estimateMarginElements);

            for (int i = 0; i < estimateMarginValues.Count; i++)
            {
                //Verify that the Estimated margin value has 2 decimal places 
                Report.WriteLine("Verification of 2 decimal places for Estimated margin value");
                VerifyThatTheNumberFormatIsWithTwoDecimalPlaces(estimateMarginValues[i]);
            }
        }

        [Then(@"the text color of the carrier liability information is in dark gray")]
        public void ThenTheTextColorOfTheCarrierLiabilityInformationIsInDarkGray()
        {
            string darkGray = "rgba(169, 169, 169, 1)";
            string carrierLiabilityColor = GetCSSValue(attributeName_xpath, ShipmentResults_FirstCarrierLegalLiability_XPath, "color");
            Report.WriteLine("Verification that the text color of the carrier liability information is dark gray");
            Assert.AreEqual(darkGray, carrierLiabilityColor);
        }

        [Then(@"the Estimated Margin total is displayed in bold type")]
        public void ThenTheEstimatedMarginTotalIsDisplayedInBoldType()
        {
            IList<IWebElement> totalRates = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentResults_EstMarginTotalRate_Xpath));
            List<string> totalRatesValues = objWebElementOperations.GetListFromIWebElement(totalRates);
            IList<IWebElement> carrierNamesUI = GlobalVariables.webDriver.FindElements(By.XPath(ShipResults_CarrierNameColumns_Xpath));
            List<string> carrierNames = objWebElementOperations.GetListFromIWebElement(carrierNamesUI);

            for (int i = 0; i < carrierNames.Count; i++)
            {
                int index = i + 1;
                string fontWeight = GetCSSValue(attributeName_xpath, "//tr[" + index + "]//div[@class = 'totalRate boldText']", "font-weight");

                Report.WriteLine("Verification that the Estimated margin total is displayed in bold type");
                Assert.AreEqual("700", fontWeight);
            }
        }

        [Then(@"the Estimated Rate total is displayed in bold type")]
        public void ThenTheEstimatedRateTotalIsDisplayedInBoldType()
        {
            IList<IWebElement> totalRates = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentResults_EstTotalRate_Xpath));
            List<string> totalRatesValues = objWebElementOperations.GetListFromIWebElement(totalRates);
            IList<IWebElement> carrierNamesUI = GlobalVariables.webDriver.FindElements(By.XPath(ShipResults_CarrierNameColumns_Xpath));
            List<string> carrierNames = objWebElementOperations.GetListFromIWebElement(carrierNamesUI);

            for (int i = 0; i < carrierNames.Count; i++)
            {
                int index = i + 1;
                string fontWeight = GetCSSValue(attributeName_xpath, "//tr[" + index + "]//div[@class = 'totalRate boldText']", "font-weight");

                Report.WriteLine("Verification that the Estimated Rate total is displayed in bold type");
                Assert.AreEqual("700", fontWeight);
            }
        }

        [Then(@"the Rate total is displayed in bold type")]
        public void ThenTheRateTotalIsDisplayedInBoldType()
        {
            IList<IWebElement> totalRates = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentResults_TotalRate_Xpath));
            List<string> totalRatesValues = objWebElementOperations.GetListFromIWebElement(totalRates);
            IList<IWebElement> carrierNamesUI = GlobalVariables.webDriver.FindElements(By.XPath(ShipResults_CarrierNameColumns_Xpath));
            List<string> carrierNames = objWebElementOperations.GetListFromIWebElement(carrierNamesUI);

            for (int i = 0; i < carrierNamesUI.Count; i++)
            {
                int index = i + 1;
                string fontWeight = GetCSSValue(attributeName_xpath, "//tr[" + index + "]//div[@class = 'totalRate boldText']", "font-weight");

                Report.WriteLine("Verification that the Rate total is displayed in bold type");
                Assert.AreEqual("700", fontWeight);
            }
        }

        [Then(@"the Insured Rate total is displayed in bold type")]
        public void ThenTheInsuredRateTotalIsDisplayedInBoldType()
        {
            SendKeys(attributeName_id, ShipResults_INsuredValue_Id, "100");
            Click(attributeName_id, ShipResults_ShowInsuredRateButton_Id);
            GlobalVariables.webDriver.WaitForPageLoad();

            string fontWeight = GetCSSValue(attributeName_xpath, ShipResults_FC_InsTotal_Xpath, "font-weight");

            Report.WriteLine("Verification that the Insured Rate total is displayed in bold type");
            Assert.AreEqual("700", fontWeight);
        }

        [Then(@"the Quote Disclaimer text is removed in the bottom of the Page")]
        public void ThenTheQuoteDisclaimerTextIsRemovedInTheBottomOfThePage()
        {
            Report.WriteLine("Verification that the shipment disclaimer text is removed from Shipment results page");
            Assert.IsTrue(ElementNotPresent(attributeName_id, ShipmentResults_DisclaimerTextId, "ShipmentDisclaimerText"));
        }

        [Then(@"the Quote Expatriation text is removed in the bottom of the Page")]
        public void ThenTheQuoteExpatriationTextIsRemovedInTheBottomOfThePage()
        {
            string termsAndConditionsText = Gettext(attributeName_id, ShipmentResults_InsuredTermsAndConditionsTextId);

            Report.WriteLine("Verification that the Quote Expatriation Text is removed from Shipment results page");
            Assert.IsFalse(termsAndConditionsText.Contains("* Quote expires on the Actual Ship Date if less than the expiration date."));
        }

        [Then(@"the Terms and Conditions applicable to default or customer specific insurance all risk settings is displayed")]
        public void ThenTheTermsAndConditionsApplicableToDefaultOrCustomerSpecificInsuranceAllRiskSettingsIsDisplayed()
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
            else
            {
                Report.WriteLine("Terms and conditions for Default customer is not valid");
            }

            Assert.IsTrue(isTermsAndConditionsTextValid);
            ;
        }

        [Then(@"the Terms and Conditions applicable to PPP insurance all risk settings is displayed")]
        public void ThenTheTermsAndConditionsApplicableToPPPInsuranceAllRiskSettingsIsDisplayed()
        {
            string actualTermsAndConditionsForNonDefaultCustomer = ((IJavaScriptExecutor)GlobalVariables.webDriver).ExecuteScript("return $('.terms-text').text()")?.ToString();
            bool isTermsAndConditionsTextValid = false;

            if (actualTermsAndConditionsForNonDefaultCustomer.Contains("User understands and agrees by selecting this option, the goods being shipped will be insured for All Risk coverage per the terms and conditions of the policy. The deductible is $0 and includes coverage on goods and/or merchandise consisting of new and used general commodities, including new, used and remanufactured equipment or equipment parts.  If proper exception is not made on the delivery receipt by the consignee, all risk coverage is void."))
            {
                Report.WriteLine("first paragraph is correct");

                if (actualTermsAndConditionsForNonDefaultCustomer.Contains("User understands and agrees to file any and all claims within 60 days with their DLS Worldwide account rep (or supporting operations team) as soon as possible after the claim becomes known and that when filing claims they are to include a copy of the bill of lading, a copy of the commercial invoice that outlines the replacement value of the shipment and a photo demonstrating that damage did occur during transit."))
                {
                    Report.WriteLine("second paragraph is correct");

                    if (actualTermsAndConditionsForNonDefaultCustomer.Contains("User also understands and agrees that DLS Worldwide reserves the right to file a subrogated claim with the carrier and that DLS Worldwide also reserves the right to refuse program access due to inaccurate or fraudulent claims, excessive claims history and/or failure to complete with recommended shipping and/or packaging guidelines."))
                    {
                        Report.WriteLine("third paragraph is correct");
                    }

                    isTermsAndConditionsTextValid = true;
                    Report.WriteLine("Verified that the Terms and conditions are displayed for Non Default Ins All Risk/PPP Customer");
                }
            }
            else
            {
                Report.WriteLine("Terms and conditions for PPP customer is not valid");
            }

            Assert.IsTrue(isTermsAndConditionsTextValid);
        }

        [Then(@"the service days is displayed with days to the right of the number of service days")]
        public void ThenTheServiceDaysIsDisplayedWithDaysToTheRightOfTheNumberOfServiceDays()
        {
            IList<IWebElement> serviceLaneElements = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentResults_Service_Values_All_XPath));
            List<string> serviceLaneValues = objWebElementOperations.GetListFromIWebElement(serviceLaneElements);

            bool isServiceDaysVerbiageSet = true;

            for (int i = 0; i < serviceLaneValues.Count; i++)
            {
                if (!serviceLaneValues[i].Contains("days"))
                {
                    isServiceDaysVerbiageSet = false;
                    break;
                }
            }

            if (isServiceDaysVerbiageSet)
            {
                Report.WriteLine("Verified that the service days are displayed days to the right of the number of service days");
            }
            else
            {
                Report.WriteLine("Verification that the service days are displayed days to the right of the number of service days is failed.");
            }
        }

        [Then(@"the verbiage Direct to Destination is displayed as Direct and Indirect to Destination is displayed as Indirect")]
        public void ThenTheVerbiageDirectToDestinationIsDisplayedAsDirectAndIndirectToDestinationIsDisplayedAsIndirect()
        {
            IList<IWebElement> serviceLaneElements = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentResults_ServiceLane_Values_All_XPath));
            List<string> serviceLaneValues = objWebElementOperations.GetListFromIWebElement(serviceLaneElements);

            bool isServiceLaneVerbiageSet = true;

            for (int i = 0; i < serviceLaneValues.Count; i++)
            {
                if (serviceLaneValues[i] != "Direct" && serviceLaneValues[i] != "InDirect")
                {
                    isServiceLaneVerbiageSet = false;
                    break;
                }
            }

            if (isServiceLaneVerbiageSet)
            {
                Report.WriteLine("Verified that the service Lane is displayed as Direct/Indirect");
            }
            else
            {
                Report.WriteLine("The service Lane display verification for Direct/Indirect is failed.");
            }
        }

        [Then(@"the Terms and Conditions link and verbiage Creating an insured shipment means you agree to the Terms and Conditions\. is available at the bottom of the page")]
        public void ThenTheTermsAndConditionsLinkAndVerbiageCreatingAnInsuredShipmentMeansYouAgreeToTheTermsAndConditions_IsAvailableAtTheBottomOfThePage()
        {
            scrollElementIntoView(attributeName_id, ShipmentResults_InsuredTermsAndConditionsTextId);
            Report.WriteLine("Verification that the shipment insured TermsAndConditions link is present in Shipment results page");
            Assert.IsTrue(IsElementPresent(attributeName_id, ShipmentResults_InsuredTermsAndConditionsTextId, "InsuredTermsAndConditionsTextId"));

            string termsAndConditionsLinkText = Gettext(attributeName_id, ShipmentResults_InsuredTermsAndConditionsTextId);

            Report.WriteLine("Verification that the shipment insured TermsAndConditions Text is *Creating an insured shipment means you agree to the Terms and Conditions.");
            Assert.AreEqual("*Creating an insured shipment means you agree to the Terms and Conditions.", termsAndConditionsLinkText);
        }

        [When(@"I click on TermsAndConditions link at the bottom of the page")]
        public void WhenIClickOnTermsAndConditionsLinkAtTheBottomOfThePage()
        {
            Report.WriteLine("Click on TErms and conditions Link at the bottom of the page");
            scrollElementIntoView(attributeName_id, ShipmentResults_InsuredTermsAndConditionsTextId);
            Click(attributeName_classname, ShipmentResults_InsuredTermsAndConditionsLinkClass);
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

        [Given(@"I am associated to a customer with PPP/Non-Default insurance all risk setting(.*)")]
        public void GivenIAmAssociatedToACustomerWithPPPNon_DefaultInsuranceAllRiskSetting(string customername)
        {
            customer = customername;
            Report.WriteLine(customer + "belongs to PPP");
        }

        [Given(@"I'm on the Add Shipment \(LTL\) page(.*),(.*)")]
        public void GivenIMOnTheAddShipmentLTLPage(string shipmentflow, string usertype)
        {
            shipmentType = shipmentflow;
            switch (shipmentflow)
            {
                case "Direct Shipment":
                    {
                        ltl.NaviagteToShipmentList();
                        ltl.SelectCustomerFromShipmentList(usertype, customer);
                        ltl.DirectShipmentEnterShipmentDatas();
                        break;
                    }
                case "Rate To Shipment":
                    {
                        ltl.RateToShipmentNavigation(usertype, customer);
                        break;
                    }
                case "Quote To Shipment":
                    {
                        ltl.QuoteToShipmentNavigation(usertype, customer);
                        break;
                    }
                case "Copy Shipment":
                    {
                        ltl.CopyShipment(usertype, customer);
                        break;
                    }
                case "Return Shipment":
                    {
                        ltl.ReturnShipment(usertype, customer);
                        break;
                    }
                case "Edit Shipment":
                    {
                        ltl.EditShipment(usertype, customer);
                        break;
                    }
            }
        }

      
        [Given(@"I entered value in the Enter insured value field")]
        public void GivenIEnteredValueInTheEnterInsuredValueField()
        {
            {
                ScrollToTopElement(attributeName_id, ShippingFrom_LocationName_Id);
                SendKeys(attributeName_id, ShippingFrom_LocationName_Id, "test");
                SendKeys(attributeName_id, ShippingFrom_LocationAddressLine1_Id, "testadd1");
                scrollPageup();
                SendKeys(attributeName_id, ShippingTo_LocationName_Id, "test");
                SendKeys(attributeName_id, ShippingTo_LocationAddressLine1_Id, "testadd2");
                scrollElementIntoView(attributeName_xpath, FreightDesp_SectionText_xpath);
                SendKeys(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id, "check");
            }

            scrollElementIntoView(attributeName_id, InsuredValue_TextBox_Id);
            if (shipmentType != "Quote To Shipment")
            {
                SendKeys(attributeName_id, InsuredValue_TextBox_Id, "50");
            }
        }


        [Given(@"I entered a value in the Enter insured value field of Shipment Results LTL page")]
        public void GivenIEnteredAValueInTheEnterInsuredValueFieldOfShipmentResultsLTLPage()
        {
           
            WaitForElementVisible(attributeName_xpath, "//h1[@class='page-heading']", "Shipment Results (LTL)");
            //if (shipmentType != "Quote To Shipment")
            //{
                SendKeys(attributeName_id, ShipResults_InsuredRateTextbox_Id, "50");
            //}
            
        }


        [Given(@"""(.*)"" link was displayed")]
        public void GivenLinkWasDisplayed(string termsandconditionslink)
        {
            Verifytext(attributeName_xpath, TermsAndConditionsLink_AddShipmentLTLPage, termsandconditionslink);
        }

        
        [When(@"I have click Terms and Conditions link")]
        public void WhenIHaveClickTermsAndConditionsLink()
        {
            Click(attributeName_xpath, ".//*[@id='page-content-wrapper']//*[@class = 'shipment-terms pull-right terms-condition-pop-up fontSize20']");
        }


        [Then(@"the updated Terms and Conditions associated to customers with the PPP insurance-all risk setting will be displayed in the (.*) modal")]
        public void ThenTheUpdatedTermsAndConditionsAssociatedToCustomersWithThePPPInsurance_AllRiskSettingWillBeDisplayedInTheModal(string termsandconditionsmodalheader)
        {
            WaitForElementVisible(attributeName_xpath, ".//h3[contains(text(), 'Terms And Conditions Of Coverage')]", termsandconditionsmodalheader);
            string actualTermsAndConditionsForNonDefaultCustomer = ((IJavaScriptExecutor)GlobalVariables.webDriver).ExecuteScript("return $('.text-left').text()")?.ToString();
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
                            scrollElementIntoView(attributeName_xpath, ".//*[@id='shipment-model']//*[@class = 'protection-plan-header']");
                            string affirmationheader = Gettext(attributeName_xpath, ".//*[@id='shipment-model']//*[@class = 'protection-plan-header']");
                            if (affirmationheader.Contains("AFFIRMATION OF SERVICE TERMS - DLS WORLDWIDE PRODUCT PROTECTION PLAN"))
                            {
                                Report.WriteLine("Affirmation of Service Terms title is correct");
                                scrollElementIntoView(attributeName_xpath, ".//*[@id='shipment-model']//*[@class = 'text-left'][2]");
                                scrollpagedown();
                                scrollpagedown();
                                string affirmationfirstparagraph = Gettext(attributeName_xpath, ".//*[@id='shipment-model']//*[@class = 'text-left'][2]");
                                if (affirmationfirstparagraph.Contains("As of Jan 1, 2019 the following requirements will be set in place as firm policies and procedures for the Product Protection Plan. This program is a zero-deductible full-coverage insurance option that provides coverage for new, used and remanufactured parts and equipment."))
                                {
                                    Report.WriteLine("First Paragraph under AFFIRMATION OF SERVICE TERMS title is correct");
                                    scrollElementIntoView(attributeName_xpath, ".//*[@id='shipment-model']//ol/li[1]");
                                    string point1inAffirmationParagraph = Gettext(attributeName_xpath, ".//*[@id='shipment-model']//ol/li[1]");
                                    if (point1inAffirmationParagraph.Contains("If freight arrived with damage consignees must sign off on it with damage noted at time of receipt."))
                                    {
                                        Report.WriteLine("Point1 under AFFIRMATION OF SERVICE TERMS is correct");
                                        string point2inAffirmationParagraph = Gettext(attributeName_xpath, ".//*[@id='shipment-model']//ol/li[2]");
                                        if (point2inAffirmationParagraph.Contains("If consignee signs off on the shipment as clear at the time of receipt and damage is notated later, customer still has forty-eight business hours to notify their DLS representative directly."))
                                        {
                                            Report.WriteLine("Point2 under AFFIRMATION OF SERVICE TERMS is correct");
                                            string point3inAffirmationParagraph = Gettext(attributeName_xpath, ".//*[@id='shipment-model']//ol/li[3]");
                                            if (point3inAffirmationParagraph.Contains("Customers must submit standard DLS claims form that can be found online at DLSWorldwide.com. Customers must submit a commercial invoice demonstrating what the product sold for and may also be reimbursed for original freight costs if the insured value included the freight charges."))
                                            {
                                                Report.WriteLine("Point3 under AFFIRMATION OF SERVICE TERMS is correct");
                                                string point4inAffirmationParagraph = Gettext(attributeName_xpath, ".//*[@id='shipment-model']//ol/li[4]");
                                                if (point4inAffirmationParagraph.Contains("Proper packaging is required and claims may be denied for improper packaging."))
                                                {
                                                    Report.WriteLine("Point4 under AFFIRMATION OF SERVICE TERMS is correct");
                                                    string point5inAffirmationParagraph = Gettext(attributeName_xpath, ".//*[@id='shipment-model']//ol/li[5]");
                                                    if (point5inAffirmationParagraph.Contains("All shipments with a value of $2500.00 or more will require photos of commodity prior to packing, once packaged and finally at destination showing damages. If pictures are unavailable, the claim can be denied. Everyone has a smart phone these days and if you take a minute to capture a photo of the item before and after it has been packaged it will help accelerate the claims process and eliminate any questions or concerns regarding the condition of the commodity prior to packaging or packaging itself."))
                                                    {
                                                        Report.WriteLine("Point5 under AFFIRMATION OF SERVICE TERMS is correct");
                                                        string point5AinAffirmationParagraph = Gettext(attributeName_xpath, ".//*[@id='shipment-model']//*[@class = 'tick-list'][1]");
                                                        if (point5AinAffirmationParagraph.Contains("Program does not provide coverage for glass of any kind."))
                                                        {
                                                            Report.WriteLine("Point5A under AFFIRMATION OF SERVICE TERMS is correct");
                                                            string point5BinAffirmationParagraph = Gettext(attributeName_xpath, ".//*[@id='shipment-model']//*[@class = 'tick-list'][2]");
                                                            if (point5BinAffirmationParagraph.Contains("Program does not cover products moved by Central Transport or UPS"))
                                                            {
                                                                Report.WriteLine("Point5B under AFFIRMATION OF SERVICE TERMS is correct");
                                                                string point5CinAffirmationParagraph = Gettext(attributeName_xpath, ".//*[@id='shipment-model']//*[@class = 'tick-list'][3]");
                                                                if (point5CinAffirmationParagraph.Contains("Claim must be filed within 60 days of delivery or claims may be denied."))
                                                                {
                                                                    Report.WriteLine("Point5C under AFFIRMATION OF SERVICE TERMS is correct");
                                                                    string point5DinAffirmationParagraph = Gettext(attributeName_xpath, ".//*[@id='shipment-model']//*[@class = 'tick-list'][4]");
                                                                    if (point5DinAffirmationParagraph.Contains("Claimant must mitigate the loss down if possible. i.e. repair, salvage allowance."))
                                                                    {
                                                                        Report.WriteLine("Point5D under AFFIRMATION OF SERVICE TERMS is correct");
                                                                        string point5EinAffirmationParagraph = Gettext(attributeName_xpath, ".//*[@id='shipment-model']//*[@class = 'tick-list'][5]");
                                                                        if (point5EinAffirmationParagraph.Contains("If shipments are signed off as clear at the time of receipt and damages are not reported to the DLS Worldwide representative within forty-eight business hours claims will be denied."))
                                                                        {
                                                                            Report.WriteLine("Point5E under AFFIRMATION OF SERVICE TERMS is correct");
                                                                            string point5FinAffirmationParagraph = Gettext(attributeName_xpath, ".//*[@id='shipment-model']//*[@class = 'tick-list'][6]");
                                                                            if (point5FinAffirmationParagraph.Contains("If shipper or consignee cannot provide some sort of proof that damages occurred during transit claims may be denied."))
                                                                            {
                                                                                Report.WriteLine("Point5F under AFFIRMATION OF SERVICE TERMS is correct");
                                                                                string point5GinAffirmationParagraph = Gettext(attributeName_xpath, ".//*[@id='shipment-model']//*[@class = 'tick-list'][7]");
                                                                                if (point5GinAffirmationParagraph.Contains("If commodity is not packaged for normal hazards of transit the claim will be denied due to insufficient packaging."))
                                                                                {
                                                                                    Report.WriteLine("Point5G under AFFIRMATION OF SERVICE TERMS is correct");
                                                                                    string point5HinAffirmationParagraph = Gettext(attributeName_xpath, ".//*[@id='shipment-model']//*[@class = 'tick-list'][8]");
                                                                                    if (point5HinAffirmationParagraph.Contains("If any nefarious activities within the packaging, delivery, inspection or documentation processes are suspected claims may be delayed and eventually denied."))
                                                                                    {
                                                                                        Report.WriteLine("Point5H under AFFIRMATION OF SERVICE TERMS is correct");
                                                                                        string point6inAffirmationParagraph = Gettext(attributeName_xpath, ".//*[@id='shipment-model']//ol/li[6]");
                                                                                        if (point6inAffirmationParagraph.Contains("All claims will be acknowledged within thirty days by our corporate office. Claims below $2500.00 will be concluded within thirty days and claims above $2500.00 may require an independent inspection and should be concluded within forty-five to sixty days."))
                                                                                        {
                                                                                            Report.WriteLine("Point6 under AFFIRMATION OF SERVICE TERMS is correct");
                                                                                            string point7inAffirmationParagraph = Gettext(attributeName_xpath, ".//*[@id='shipment-model']//ol/li[7]");
                                                                                            if (point7inAffirmationParagraph.Contains("If and when claims are honored at full value, DLS Worldwide reserves the right to claim ownership of product and may make arrangement for product to be picked up. If DLS Worldwide does not claim ownership of said product, a disposal certificate may be requested."))
                                                                                            {
                                                                                                Report.WriteLine("Point7 under AFFIRMATION OF SERVICE TERMS is correct");
                                                                                                string point8inAffirmationParagraph = Gettext(attributeName_xpath, ".//*[@id='shipment-model']//ol/li[8]");
                                                                                                if (point8inAffirmationParagraph.Contains("A report documenting claims by station and by customer will be provided on a quarterly basis. If a particular customer has an overly excessive claims ratio their ability to participate in this program may be suspended and/or denied."))
                                                                                                {
                                                                                                    Report.WriteLine("Point8 under AFFIRMATION OF SERVICE TERMS is correct");
                                                                                                    string point9inAffirmationParagraph = Gettext(attributeName_xpath, ".//*[@id='shipment-model']//ol/li[9]");
                                                                                                    if (point9inAffirmationParagraph.Contains("Maximum insured value shall not exceed $7500.00 per shipment unless prior approval is received. Such approval will be based on volume and packaging procedures."))
                                                                                                    {
                                                                                                        Report.WriteLine("Point9 under AFFIRMATION OF SERVICE TERMS is correct");
                                                                                                        string point10inAffirmationParagraph = Gettext(attributeName_xpath, ".//*[@id='shipment-model']//ol/li[10]");
                                                                                                        if (point10inAffirmationParagraph.Contains("Any and all appeals to claims rulings must be filed with your DLS Sales Representative who in turn will bring it to the attention of their regional representative and the DLS Worldwide claims department."))
                                                                                                        {
                                                                                                            Report.WriteLine("Point10 under AFFIRMATION OF SERVICE TERMS is correct");
                                                                                                            isTermsAndConditionsTextValid = true;
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                    }
                                }
                            }
                        }
                    }
                }
            }

            Assert.IsTrue(isTermsAndConditionsTextValid);
        }

        [Given(@"I'm shp\.entry, sales, sales management, operations, or stationowner (.*) user")]
        public void GivenIMShp_EntrySalesSalesManagementOperationsOrStationownerUser(string loginUsertype)
        {
            userType = loginUsertype;
            string username = string.Empty;
            string password = string.Empty;
            if (userType == "Internal")
            {
                username = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
                password = ConfigurationManager.AppSettings["password-crmOperation"].ToString();
            }
            else if (userType == "Sales")
            {
                username = ConfigurationManager.AppSettings["username-salesdelta"].ToString();
                password = ConfigurationManager.AppSettings["password-salesdelta"].ToString();
            }
            else if (userType == "External")
            {
                username = ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();
                password = ConfigurationManager.AppSettings["ExternalUserPassword"].ToString();
            }
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"I Clicked the View Rates button")]
        public void GivenIClickedTheViewRatesButton()
        {
            scrollElementIntoView(attributeName_xpath, ViewRatesButton_xpath);
            ltl.ClickViewRates();
        }

        [Given(@"I'm on the Shipment Results \(LTL\) page")]
        public void GivenIMOnTheShipmentResultsLTLPage()
        {
            WaitForElementVisible(attributeName_xpath, "//h1[@class='page-heading']", "Shipment Results (LTL)");
        }

        [When(@"I click the Terms and Conditions link displayed next to the Show Insured Rate button")]
        public void WhenIClickTheTermsAndConditionsLinkDisplayedNextToTheShowInsuredRateButton()
        {
            Click(attributeName_id, "btnshipment-model");

        }

        [Given(@"I am on the Shipment Results \(LTL\) page(.*),(.*)")]
        public void GivenIAmOnTheShipmentResultsLTLPage(string shipmentflow, string usertype)
        {
            GivenIMOnTheAddShipmentLTLPage(shipmentflow, usertype);
            scrollElementIntoView(attributeName_xpath, ViewRatesButton_xpath);
            ltl.ClickViewRates();
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"""(.*)"" link was displayed next to the Show Insured Rate button")]
        public void GivenLinkWasDisplayedNextToTheShowInsuredRateButton(string TermsandConditions)
        {
            Thread.Sleep(2000);
            Verifytext(attributeName_id, "btnshipment-model", TermsandConditions);
        }


        [When(@"I Click the Terms and Conditions link in the Shipment Results \(LTL\) page")]
        public void WhenIClickTheTermsAndConditionsLinkInTheShipmentResultsLTLPage()
        {
            Click(attributeName_id, "btnshipment-model");
        }

        [When(@"I click terms and conditions link embedded in the comment Creating an insured shipment means you agree to the terms and conditions> displayed at the bottom of the page")]
        public void WhenIClickTermsAndConditionsLinkEmbeddedInTheCommentCreatingAnInsuredShipmentMeansYouAgreeToTheTermsAndConditionsDisplayedAtTheBottomOfThePage()
        {
            scrollElementIntoView(attributeName_xpath, ".//*[@id='insuredShipmentTermsAndConditions']/a");
            Click(attributeName_xpath, TermsAndConditionsEmbeddedLinkShipmentResultsLTLPage_Xpath);
        }
    }
}
