using TechTalk.SpecFlow;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRM.UITest.Objects;
using System;
using System.Threading;
using System.Collections.Generic;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Text.RegularExpressions;
using CRM.UITest.CommonMethods;

namespace CRM.UITest.Scripts.Quote.LTL
{
    [Binding]
    public sealed class QuoteConfirmationPage_Steps : ObjectRepository
    {

        string carrierName = null;
        string carrierStandardAmount = null;
        string carrierInsuredAmount = null;
        string Shipment_Value = null;
        string Additional_Services = null;

        [Then(@"I will be able to see '(.*)' and name on Quote Confimation page '(.*)'")]
        public void ThenIWillBeAbleToSeeAndNameOnQuoteConfimationPage(string servicefieldText, string Service)
        {
            Report.WriteLine("Verify service text on confirmation page");
            string ServiceText_UI = Gettext(attributeName_xpath, LTL_QC_ServiceText_Xpath);
            Assert.AreEqual(servicefieldText, ServiceText_UI);
            //Verify Service Title name
            Report.WriteLine("Verify service text on confirmation page");
            string Service_UI = Gettext(attributeName_xpath, LTL_QC_Service_Xpath);
            //change to actual parameter
            Assert.AreEqual(Service, Service_UI);
        }

        [When(@"I enter valid data in Item information section (.*), (.*)")]
        public void WhenIEnterValidDataInItemInformationSection(string Classification, string Weight)
        {
            Report.WriteLine("Enter details in item section");            
            Click(attributeName_id, LTL_Weight_Id);
            Click(attributeName_id, LTL_Classification_Id);
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(LTL_ClassificationValues_Xpath));
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
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Then(@"I will be able to see Pickup field and date page header Quote confirmation page (.*)")]
        public void ThenIWillBeAbleToSeePickupFieldAndDatePageHeaderQuoteConfirmationPage(string Pickup_Date_Text)
        {
            //Verify pickup field text
            Report.WriteLine("Verify pickup date text on confirmation page");
            string Pickup_UI = Gettext(attributeName_xpath, LTL_QC_PickupText_Xpath);
            Assert.AreEqual(Pickup_Date_Text, Pickup_UI);
        }

        [Then(@"I will be able to see request number on Quote confirmation page (.*)")]
        public void ThenIWillBeAbleToSeeRequestNumberOnQuoteConfirmationPage(string request_number_Text)
        {
            //Verify request number field text
            ScenarioContext.Current.Pending(); Report.WriteLine("Verify request number text on confirmation page");
            string Request_UI = Gettext(attributeName_xpath, LTL_QC_requestnumber_Xpath);
            Assert.AreEqual(request_number_Text, Request_UI);
        }

        [When(@"I click on save rate as quotelink ofselected carrier in results page of '(.*)'")]
        public void WhenIClickOnSaveRateAsQuotelinkOfselectedCarrierInResultsPageOf(string UserType)
        {
            string configURL = launchUrl;
            string resultPagrURL = configURL + "Rate/LtlResultsView";
            if (GetURL() == resultPagrURL )
            {
                Report.WriteLine("Rate Results available");
                VerifyElementPresent(attributeName_xpath, ltlQuoteResultsheader_xpath, "Quote Results (LTL)");
                VerifyElementPresent(attributeName_xpath, ltlresultsgridall_xpath, "ratereults");
                Console.WriteLine("rates are displpaying for the given information");

                carrierName = Gettext(attributeName_xpath, ltlCarrierName_xpath);
                carrierStandardAmount = Gettext(attributeName_xpath, ltlstdRateamount_xpath);
                Report.WriteLine("Creater shipment for selected carrier");
               
                if (UserType == "Internal")
                {
                    Click(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[5]/ul[3]/li/a");
                }
                else
                {
                    Click(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[4]/ul[2]/li/a");

                }
            }
            else
            {
                Report.WriteLine("Rates are not available");
                Console.WriteLine("Rate Results are not available for the given information");
                carrierName = "N/A";
                carrierStandardAmount = "N/A";
                carrierInsuredAmount = "N/A";
                Report.WriteLine("Creater shipment for selected carrier");
                
                Click(attributeName_xpath, ltlsavequotenorateslink_xpath);
            }
        }

        [When(@"I click on save rate as quote link  for selected carrier in results page")]
        public void WhenIClickOnSaveRateAsQuoteLinkForSelectedCarrierInResultsPage()
        {
            string configURL = launchUrl;
            string resultPagrURL = configURL + "Rate/LtlResultsView";
            if (GetURL() == resultPagrURL)
            {
                Report.WriteLine("Rate Results available");
                VerifyElementPresent(attributeName_xpath, ltlQuoteResultsheader_xpath, "Quote Results (LTL)");
                VerifyElementPresent(attributeName_xpath, ltlresultsgridall_xpath, "ratereults");
                Console.WriteLine("rates are displpaying for the given information");

                carrierName = Gettext(attributeName_xpath, ltlCarrierName_xpath);
                carrierStandardAmount = Gettext(attributeName_xpath, ltlstdRateamount_xpath);
                Report.WriteLine("Creater shipment for selected carrier");
             
                Click(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[5]/ul[3]/li/a");
            }
            else
            {
                Report.WriteLine("Rates are not available");
                Console.WriteLine("Rate Results are not available for the given information");
                carrierName = "N/A";
                carrierStandardAmount = "N/A";
                carrierInsuredAmount = "N/A";
                Report.WriteLine("Creater shipment for selected carrier");
                
                Click(attributeName_xpath, ltlsavequotenorateslink_xpath);
            }
        }

        [When(@"I click on save rate as quote link  for selected carrier in resultsint page")]
        public void WhenIClickOnSaveRateAsQuoteLinkForSelectedCarrierInResultsintPage()
        {
            string configURL = launchUrl;
            string resultPagrURL = configURL + "Rate/LtlResultsView";
            if (GetURL() == resultPagrURL)
            {
                Report.WriteLine("Rate Results available");
                VerifyElementPresent(attributeName_xpath, ltlQuoteResultsheader_xpath, "Quote Results (LTL)");
                VerifyElementPresent(attributeName_xpath, ltlresultsgridall_xpath, "ratereults");
                Console.WriteLine("rates are displpaying for the given information");

                carrierName = Gettext(attributeName_xpath, ltlCarrierName_xpath);
                carrierStandardAmount = Gettext(attributeName_xpath, ltlstdRateamount_xpath);
                Report.WriteLine("Creater shipment for selected carrier");
                Click(attributeName_xpath, ltlsaverateasquotelnkint_xpath);
            }
            else
            {
                Report.WriteLine("Rates are not available");
                Console.WriteLine("Rate Results are not available for the given information");
                carrierName = "N/A";
                carrierStandardAmount = "N/A";
                carrierInsuredAmount = "N/A";
                Report.WriteLine("Creater shipment for selected carrier");
                Click(attributeName_xpath, ltlsavequotenorateslink_xpath);
            }
        }

        [Then(@"I will be able to see status '(.*)' on Quote confirmation page")]
        public void ThenIWillBeAbleToSeeStatusOnQuoteConfirmationPage(string status_Text)
        {
            //Verify status Text field text
            Report.WriteLine("Verify status text on confirmation page");
            string status_UI = Gettext(attributeName_xpath, LTL_QC_StatusText_Xpath);
            Assert.AreEqual(status_Text, status_UI);
        }

        [Then(@"I will be able to see '(.*)' field page header Quote confirmation page")]
        public void ThenIWillBeAbleToSeeFieldPageHeaderQuoteConfirmationPage(string UploadShippingDocumentstext)
        {
            //Verify UploadShippingDocument Text field text
            Report.WriteLine("Verify status text on confirmation page");
            string UploadShippingDocumentstext_UI = Gettext(attributeName_xpath, LTL_QC_UploadShippingDocumentText_Xpath);
            Assert.AreEqual(UploadShippingDocumentstext, UploadShippingDocumentstext_UI);           
        }

        [Then(@"I will be able to see '(.*)' on Quote confirmation page")]
        public void ThenIWillBeAbleToSeeOnQuoteConfirmationPage(string request_number_Text)
        {
            //Verify request number Text field text
            Report.WriteLine("Verify request number text on confirmation page");
            string requestnumber_UI = Gettext(attributeName_xpath, LTL_QC_requestnumber_Xpath);
            Assert.AreEqual(request_number_Text, requestnumber_UI);
        }        

        [Then(@"I will be navigated to quote confirmation page '(.*)'")]
        public void ThenIWillBeNavigatedToQuoteConfirmationPage(string QuoteConfirmationpageText)
        {
            Report.WriteLine("Verify the LTL quote Confirmation header");
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, LTL_QuoteConfirmationPageHeader_Xpath,"confirmpage");
            string QuoteConfirmationPageHeader_UI = Gettext(attributeName_xpath, LTL_QuoteConfirmationPageHeader_Xpath);
            Assert.AreEqual(QuoteConfirmationpageText, QuoteConfirmationPageHeader_UI);
        }

        [Then(@"I will be able to see '(.*)' expand/collapse link on Quote confirmation page")]
        public void ThenIWillBeAbleToSeeExpandCollapseLinkOnQuoteConfirmationPage(string ShowQuoteDetails_link)
        {
            Report.WriteLine("Verify the ShowQuoteDetails on Confirmation page");
            string QuoteConfirmationPageHeader_UI = Gettext(attributeName_id, LTL_QC_ShowQuoteDetails_Id);
            Assert.AreEqual(ShowQuoteDetails_link, QuoteConfirmationPageHeader_UI);            
        }

        [Then(@"I will be able to see Dropzone on Quote confirmation page")]
        public void ThenIWillBeAbleToSeeDropzoneOnQuoteConfirmationPage()
        {
            //Need to check getting false
            Report.WriteLine("Verify the Dropzone sction on Confirmation page");
            bool value = OnMouseOver(attributeName_xpath, LTL_QC_UploadShippingDocumentDropZoneSection_Xpath);
            if (value)
            {
                Report.WriteLine("Verify the Dropzone sction is present");
            }
            else
            {
                Report.WriteLine("Verify the Dropzone sction is not present");
                throw new Exception("Verify the Dropzone sction is not present");
            }
        }

        [Then(@"I will be able see email confirmation page on quote confirmation page")]
        public void ThenIWillBeAbleSeeEmailConfirmationPageOnQuoteConfirmationPage()
        {
            String Confirmationemail_expected = "Your quote has been submitted. You will receive a confirmation email shortly";
            String Confirmationemail_UI = Gettext(attributeName_xpath, LTL_QC_VerifyEmailConfirmationText_Xpath);
            Assert.AreEqual(Confirmationemail_expected, Confirmationemail_UI);

            String ExpextedFileTypeMessage_expected = "Note: This step is optional. There is a maximum of 10 documents allowed.\r\nFile extensions must be JPG, JPEG, PNG, CSV, PDF, DOC, DOCX, XLS or XLSX. Files must be less than 10 MB and the file name cannot exceed 70 characters.";
            String ActualFileTypeMessage_UI = Gettext(attributeName_xpath, LTL_QC_VerifyFileTypeMessage_Xpath);
            Assert.AreEqual(ExpextedFileTypeMessage_expected, ActualFileTypeMessage_UI);
        }

        [Then(@"I click on Show Quote Details link")]
        public void ThenIClickOnShowQuoteDetailsLink()
        {
            //Click on show quote link
            Report.WriteLine("Verify Show Quote Details link functionality on Confirmation page");           
            Click(attributeName_id, LTL_QC_ShowQuoteDetails_Id);
        }

        [Then(@"Show Quote Details link should be expandedShipment information '(.*)'")]
        public void ThenShowQuoteDetailsLinkShouldBeExpandedShipmentInformation(string ShipmentInfromationHeader)
        {
            //Click(attributeName_id, LTL_QC_ShowQuoteDetails_Id);
            //Verify shipement information header
            string QuoteshipmentInformationHeader_UI = Gettext(attributeName_xpath, LTL_QC_ShipmentInformationHeader_Xpath);
            Assert.AreEqual(ShipmentInfromationHeader, QuoteshipmentInformationHeader_UI);
        }

        //==============================================
        [Then(@"I will see Origin location '(.*)' field within Quote details")]
        public void ThenIWillSeeOriginLocationFieldWithinQuoteDetails(string OriginLocation_Text)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Verify the origin location header on Confirmation header");
            string OriginLocaiton_UI = Gettext(attributeName_xpath, LTL_QC_OriginLocationHeader_Xpath);
            Assert.AreEqual(OriginLocation_Text, OriginLocaiton_UI);
        }

        [Then(@"I will see Origin Location details next to  Origin Location field '(.*)','(.*)','(.*)','(.*)'")]
        public void ThenIWillSeeOriginLocationDetailsNextToOriginLocationField(string Country, string OriginCity, string OriginState, int OriginZip)
        {
            Report.WriteLine("Verify origin details on Confirmation page");
            string OriginLocaiton_UI = Gettext(attributeName_xpath, LTL_QC_OriginAddress_Xpath);
           
            string combiningValues = OriginCity +", "+ OriginState + ", " + OriginZip + ", " + Country;
            //Verifying if its equal
            bool vale = OriginLocaiton_UI.Equals(combiningValues);
            if (vale)
            {
                Report.WriteLine("Verify the origin address displayed on Confirmation page same as enterd on quote LTL page");                
            }
            else
            {
               throw new Exception("Verify the origin address displayed on Confirmation page not same as enterd on quote LTL page");
            }
        }

        [Then(@"I will see destination Location details next to  Destination Location field '(.*)','(.*)','(.*)','(.*)'")]
        public void ThenIWillSeeDestinationLocationDetailsNextToDestinationLocationField(string Country, string DestinationCity, string DestinationState, int DestinationZip)
        {
            Report.WriteLine("Verify destination details on Confirmation page");
            string DestinationLocaiton_UI = Gettext(attributeName_xpath, LTL_QC_DestinationAddress_Xpath);
            string combiningValues = DestinationCity + ", " + DestinationState + ", " + DestinationZip + ", " + Country;

            Assert.AreEqual(combiningValues, DestinationLocaiton_UI);
        }

        [Then(@"I will see destination'(.*)'Location field within Quote details")]
        public void ThenIWillSeeDestinationLocationFieldWithinQuoteDetails(string Destination_Text)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Verify the origin location header on Confirmation header");
            string DestLocaiton_UI = Gettext(attributeName_xpath, LTL_QC_DestinationLocationHeader_Xpath);
            Assert.AreEqual(Destination_Text, DestLocaiton_UI);
        }      

        [Then(@"I will be able to see GetAnotherQuotebutton '(.*)' on Quote confirmation page")]
        public void ThenIWillBeAbleToSeeGetAnotherQuotebuttonOnQuoteConfirmationPage(string GetAnotherQuotebutton)
        {
            Report.WriteLine("Verify the GetAnotherQuotebutton on Confirmation header");
            VerifyElementPresent(attributeName_id, LTL_QC_GetAnotherQuote_Id, GetAnotherQuotebutton);            
        }

        [Then(@"I will see N/A Carrier name next to Carrier Name field")]
        public void ThenIWillSeeNACarrierNameNextToCarrierNameField()
        {  
            string CarrierNameText_UI = Gettext(attributeName_xpath, LTL_QC_CarrierNameText_Xpath);         
            //need to write carrier name from results page
            string Service_UI = Gettext(attributeName_xpath, LTL_QC_CarrierName_Xpath);
            Assert.AreEqual(carrierName, Service_UI);
        }

        [Then(@"I will see N/A Carrier name next to Carrier Name field '(.*)'")]
        public void ThenIWillSeeNACarrierNameNextToCarrierNameField(string App_Url)
        {
            string resultPagrURL = App_Url + "Rate/LtlResultsView";
            if (GetURL() == resultPagrURL)
            {
                Report.WriteLine("Rate Results available");
                VerifyElementPresent(attributeName_xpath, ltlQuoteResultsheader_xpath, "Quote Results (LTL)");
                VerifyElementPresent(attributeName_xpath, ltlresultsgridall_xpath, "ratereults");
                Console.WriteLine("rates are displpaying for the given information");

                carrierName = Gettext(attributeName_xpath, ltlCarrierName_xpath);
                carrierStandardAmount = Gettext(attributeName_xpath, ltlstdRateamount_xpath);
                Report.WriteLine("Creater shipment for selected carrier");
                Click(attributeName_xpath, ltlsaverateasquotelnk_xpath);
            }
            else
            {
                Report.WriteLine("Rates are not available");
                Console.WriteLine("Rate Results are not available for the given information");
                carrierName = "N/A";
                carrierStandardAmount = "N/A";
                carrierInsuredAmount = "N/A";
                Report.WriteLine("Creater shipment for selected carrier");
                Click(attributeName_xpath, ltlsavequotenorateslink_xpath);
            }
        }

        [When(@"I click on save Insured rate as quote link  for selected carrier")]
        public void WhenIClickOnSaveInsuredRateAsQuoteLinkForSelectedCarrier()
        {
            Click(attributeName_xpath, ltlsaveinsrateasquotelnk_xpath);
        }


        [Then(@"I will see FreightInformation '(.*)' field within Quote details")]
        public void ThenIWillSeeFreightInformationFieldWithinQuoteDetails(string FreightInformation)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            string frightdescipter_UI = Gettext(attributeName_xpath, LTL_QC_FrightDescriptionHeader_Xpath);
            Assert.AreEqual(FreightInformation, frightdescipter_UI);
        }

        [Then(@"I will see AdditionalServicesandAccessorials '(.*)' field within Quote details")]
        public void ThenIWillSeeAdditionalServicesandAccessorialsFieldWithinQuoteDetails(string AdditionalServicesandAccessorials)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            string ServicesAndAccessorialsHeader_UI = Gettext(attributeName_xpath, LTL_QC_ServicesAndAccessorialsHeader_Xpath);
            Assert.AreEqual(AdditionalServicesandAccessorials, ServicesAndAccessorialsHeader_UI);
        }

        [When(@"I will enter shipment value '(.*)'")]
        public void WhenIWillEnterShipmentValue(string ShipmentValue)
        {
            if (ShipmentValue != "")
            {
                SendKeys(attributeName_xpath, ltlEnterInsuredValueTextbox_xpath, ShipmentValue);
                Shipment_Value = ShipmentValue;
            }
            else
            {
                Shipment_Value = "N/A";
            }
        }

        [When(@"I have entered accessorials '(.*)'")]
        public void WhenIHaveEnteredAccessorials(string AdditionalService)
        {
            if (AdditionalService != "")
            {
                string s = AdditionalService;
                string[] values = s.Split(',');
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = values[i].Trim();
                    Click(attributeName_xpath, LTL_ServicesDropdown_Xpath);
                    SelectDropdownValueFromList(attributeName_xpath, LTL_ServicesDropdownValues_Xpath, values[i]);
                    Thread.Sleep(3000);
                }
                
                Additional_Services = AdditionalService;
            }
            else
            {
                Additional_Services = "N/A";
            }
        }

        
        [Then(@"I will see Freight Information details (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*)")]
        public void ThenIWillSeeFreightInformationDetails(string WeightColumnText, string ClassColumnText, string InsuredValueColumnText, string InsuredTypeColumnText, string HazmatColumnText, double classification, double weight, string Insuredvalue, string InsuredvalueType)
        {
            string FrightWeightcolumn_UI = Gettext(attributeName_xpath, LTL_QC_FrightWeight_Xpath);
            Assert.AreEqual(WeightColumnText, FrightWeightcolumn_UI);

            string FrightClassColumn_UI = Gettext(attributeName_xpath, LTL_QC_FrightClass_Xpath);
            Assert.AreEqual(ClassColumnText, FrightClassColumn_UI);

            string FrightInsuredValueColumn_UI = Gettext(attributeName_xpath, LTL_QC_FrightInsuredValue_Xpath);
            Assert.AreEqual(InsuredValueColumnText, FrightInsuredValueColumn_UI);

            string FreightInsuredTypeColumn_UI = Gettext(attributeName_xpath, LTL_QC_FreightInsuredtype_Xpath);
            Assert.AreEqual(InsuredTypeColumnText, FreightInsuredTypeColumn_UI);

            string FrightHazMatColumn_UI = Gettext(attributeName_xpath, LTL_QC_FrightHazmat_Xpath);
            Assert.AreEqual(HazmatColumnText, FrightHazMatColumn_UI);

            int rowCount = CountOfNoOfRows(attributeName_xpath, LTL_QC_FrightInformationCount);

            string FrightWeightValue_UI = Gettext(attributeName_xpath, LTL_QC_FrightWeightValue_Xpath);
            double ConWeight = double.Parse(FrightWeightValue_UI);
            Assert.AreEqual(weight, ConWeight);

            string FrightClassValue_UI = Gettext(attributeName_xpath, LTL_QC_FrightClassValue_Xpath);
            double ConClass = double.Parse(FrightClassValue_UI);
            Assert.AreEqual(classification, ConClass);

            string FrightInsuredValue_UI = Gettext(attributeName_xpath, LTL_QC_FrightInsuredValueAmount_Xpath);
            string insval = " $" + Insuredvalue + ".00";
            Assert.AreEqual(FrightInsuredValue_UI, insval);

            string FrightInsuredType_UI = Gettext(attributeName_xpath, LTL_QC_FreightInsuredtypeValue_Xpath);
            Assert.AreEqual(InsuredvalueType, FrightInsuredType_UI);
        }
                
        [When(@"I cick on Hide Quote Details link")]
        public void WhenICickOnHideQuoteDetailsLink()
        {
            Click(attributeName_id, LTL_QC_ShowQuoteDetails_Id);
            Click(attributeName_id,LTL_QC_HideQuoteDetails_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Then(@"The shipment information will be hidden")]
        public void ThenTheShipmentInformationWillBeHidden()
        {
            VerifyElementNotVisible(attributeName_xpath, LTL_QC_ShipmentInformationHeader_Xpath, "SHIPMENT INFORMATION");
        }

        [When(@"I click on the Get Another Quote button")]
        public void WhenIClickOnTheGetAnotherQuoteButton()
        {
            Click(attributeName_id, LTL_QC_GetAnotherQuote_Id);
        }

        [When(@"I click on the Back to Quote List button")]
        public void WhenIClickOnTheBackToQuoteListButton()
        {
            Click(attributeName_id, LTL_QC_BackToQuoteListButton_Id);
        }


        [Then(@"I will see Carrier name'(.*)' field")]
        public void ThenIWillSeeCarrierNameField(string CarrierName)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            string CarrierName_UI = Gettext(attributeName_xpath, LTL_QC_CarrierNameHeader_Xpath);
            Assert.AreEqual(CarrierName, CarrierName_UI);
        }

        [Then(@"I will see Carrier name next to Carrier Name field '(.*)'")]
        public void ThenIWillSeeCarrierNameNextToCarrierNameField(string carrierNameText)
        {   
            string CarrierNameText_UI = Gettext(attributeName_xpath, LTL_QC_CarrierNameText_Xpath);
            Assert.AreEqual(carrierNameText, CarrierNameText_UI);
            //need to write carrier name from results page
            string Service_UI = Gettext(attributeName_xpath, LTL_QC_CarrierName_Xpath);
            Assert.AreEqual(carrierName, Service_UI);
        }


        [Then(@"I will see Quote Amount next to Quote Amount field")]
        public void ThenIWillSeeQuoteAmountNextToQuoteAmountField()
        {
            //Need to write take quote amount from resuts page and veiry in confirmation page
            ScenarioContext.Current.Pending();
        }

        [Then(@"I will see Quote Amount '(.*)' field")]
        public void ThenIWillSeeQuoteAmountField(string QuoteAmount)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            string QuoteAmount_UI = Gettext(attributeName_xpath, LTL_QC_QuoteAmountHeader_Xpath);
            Assert.AreEqual(QuoteAmount, QuoteAmount_UI);
        }

        [Then(@"I will see Date header'(.*)' field within Quote details")]
        public void ThenIWillSeeDateHeaderFieldWithinQuoteDetails(string PickupDateHeader)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            string DateHeader_UI = Gettext(attributeName_xpath, LTL_QC_DatesHeader_Xpath);
            Assert.AreEqual(PickupDateHeader, DateHeader_UI);
        }

        [Then(@"I will see Pickup Date'(.*)' field within Quote details")]
        public void ThenIWillSeePickupDateFieldWithinQuoteDetails(string PickupDate)
        {
            string PickupDate_UI = Gettext(attributeName_xpath, LTL_QC_PickupDateText_Xpath);
            Assert.AreEqual(PickupDate, PickupDate_UI);
        }

        [Then(@"I will see N/A as Additional Services and Accessorials details next to Additional Services and Accessorials field")]
        public void ThenIWillSeeNAAsAdditionalServicesAndAccessorialsDetailsNextToAdditionalServicesAndAccessorialsField()
        {
            string additional_serviceUI = Gettext(attributeName_xpath, LTL_QC_ServicesAndAccessorialName_Xpath);
            Assert.AreEqual( Additional_Services, additional_serviceUI);
        }

        [Then(@"I will see Additional Services and Accessorials details next to Additional Services and Accessorials field")]
        public void ThenIWillSeeAdditionalServicesAndAccessorialsDetailsNextToAdditionalServicesAndAccessorialsField()
        {
            string additional_serviceUI = Gettext(attributeName_xpath, LTL_QC_ServicesAndAccessorialName_Xpath);
            Assert.AreEqual(Additional_Services, additional_serviceUI);
        }
        
        [Then(@"I click on the Back to Quote List button")]
        public void ThenIClickOnTheBackToQuoteListButton()
        {
            Click(attributeName_id, LTL_QC_BackToQuoteListButton_Id);
        }
       
        [Then(@"I will return to the Quote list page of legacy application '(.*)','(.*)'")]
        public void ThenIWillReturnToTheQuoteListPageOfLegacyApplication(string QuoteListHeader, string App_Url)
        {
            App_Url = launchUrl;
            string ratelisturl = App_Url + "L/Rate/RateList";
            if (GetURL() == ratelisturl)
            {
                Report.WriteLine("User is retrun to quote list page fo legacy aplication");
            }
        }

        [Then(@"I click on the Get Another Quote button")]
        public void ThenIClickOnTheGetAnotherQuoteButton()
        {
            Click(attributeName_id, LTL_QC_GetAnotherQuote_Id);
        }       

        [Then(@"I will see Quote Amount header'(.*)' field")]
        public void ThenIWillSeeQuoteAmountHeaderField(string QuoteAmountHeader)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            string quoteAmountHeader_UI = Gettext(attributeName_xpath, LTL_QC_QuoteAmountHeader_Xpath);
            Assert.AreEqual(QuoteAmountHeader, quoteAmountHeader_UI);
        }

        [Then(@"I will see Quote Amount next to Quote Amount field '(.*)'")]
        public void ThenIWillSeeQuoteAmountNextToQuoteAmountField(string AmountText)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            string quoteAmountText_UI = Gettext(attributeName_xpath, LTL_QC_QuoteAmountText_Xpath);            
            Assert.AreEqual(AmountText, quoteAmountText_UI);
            string quoteAmount_UI = Gettext(attributeName_xpath, LTL_QC_QuoteAmount_Xpath);
            string ManualqutoeAmount = "* " + quoteAmount_UI;
            Assert.AreEqual(carrierStandardAmount, ManualqutoeAmount);
        }

        [When(@"I click on save insured rate as quote link  for carrier '(.*)'")]
        public void WhenIClickOnSaveInsuredRateAsQuoteLinkForCarrier(string ShipmentValue)
        {
            string configURL = launchUrl;

            string resultPagrURL = configURL + "Rate/LtlResultsView";
            if (GetURL() == resultPagrURL)
            {
                Report.WriteLine("Rate Results available");
                VerifyElementPresent(attributeName_xpath, ltlQuoteResultsheader_xpath, "Quote Results (LTL)");
                VerifyElementPresent(attributeName_xpath, ltlresultsgridall_xpath, "ratereults");
                Console.WriteLine("rates are displpaying for the given information");

                Report.WriteLine("Enter the Insured Rate");
                SendKeys(attributeName_xpath, ltlEnterInsuredValueTextbox_xpath, ShipmentValue);

                Report.WriteLine("Enter the Insured Rate");
                Click(attributeName_xpath, ltlShowInsuredRateBtn_xpath);

                carrierName = Gettext(attributeName_xpath, ltlCarrierName_xpath);
                carrierInsuredAmount = Gettext(attributeName_xpath, ltlinsrateamount_xpath);
                Report.WriteLine("Creater shipment for selected carrier");
                Click(attributeName_xpath, ltlsaveinsrateasquotelnk_xpath);
            }
            else
            {

                Report.WriteLine("Rates are not available");
                Console.WriteLine("Rate Results are not available for the given information");
                carrierName = "N/A";
                carrierInsuredAmount = "N/A";
                carrierStandardAmount = "N/A";
                Report.WriteLine("Creater shipment for selected carrier");
                Click(attributeName_xpath, ltlsaverateasquotelnk_xpath);
            }
        }

        [Then(@"I will see Insred Quote Amount next to Quote Amount field '(.*)'")]
        public void ThenIWillSeeInsredQuoteAmountNextToQuoteAmountField(string AmountText)
        {
            string quoteAmountText_UI = Gettext(attributeName_xpath, LTL_QC_QuoteAmountText_Xpath);
            Assert.AreEqual(AmountText, quoteAmountText_UI);
            string quoteAmount_UI = Gettext(attributeName_xpath, LTL_QC_QuoteAmount_Xpath);
            if (quoteAmount_UI != "N/A")
            {
                string quteoamount = "* " + quoteAmount_UI;
                Assert.AreEqual(carrierInsuredAmount, quteoamount);
            }
            else
            {
                Assert.AreEqual(carrierInsuredAmount, quoteAmount_UI);
            }

        }

        [Then(@"I will see Get Another Quote'(.*)' button")]
        public void ThenIWillSeeGetAnotherQuoteButton(string GetAnotherQuote)
        {
            VerifyElementPresent(attributeName_id, LTL_QC_GetAnotherQuote_Id, GetAnotherQuote);
        }

        [Then(@"I will return to the Service Tile selection screen in the rate request process '(.*)'")]
        public void ThenIWillReturnToTheServiceTileSelectionScreenInTheRateRequestProcess(string GetQuoteTilePage)
        {
            string QuoteTilePage_UI = Gettext(attributeName_xpath, LTL_QuoteConfirmationPageHeader_Xpath);
            Assert.AreEqual(GetQuoteTilePage, QuoteTilePage_UI);
        }

        [Then(@"I will see Back To Quote List button'(.*)' button")]
        public void ThenIWillSeeBackToQuoteListButtonButton(string BacktoQuoteList)
        {
            VerifyElementPresent(attributeName_id, LTL_QC_BackToQuoteListButton_Id, BacktoQuoteList);
        }

        [Then(@"I will be displayed with N/A under '(.*)' in FreightInformation section")]
        public void ThenIWillBeDisplayedWithNAUnderInFreightInformationSection(string InsuredType)
        {
            Report.WriteLine("N/A will be displayed in Insured type column");
            string FreightInsuredType_UI = Gettext(attributeName_xpath, LTL_QC_FreightInsuredtypeValue_Xpath);
            Assert.AreEqual(InsuredType, FreightInsuredType_UI);
        }

        [Then(@"I will be displayed with New under '(.*)' in FreightInformation section")]
        public void ThenIWillBeDisplayedWithNewUnderInFreightInformationSection(string InsuredType)
        {
            Report.WriteLine("New will be displayed in Insured type column");
            string FreightInsuredType_UI = Gettext(attributeName_xpath, LTL_QC_FreightInsuredtypeValue_Xpath);
            Assert.AreEqual(InsuredType, FreightInsuredType_UI);
        }

        [Then(@"I will be displayed with Used under '(.*)' in FreightInformation section")]
        public void ThenIWillBeDisplayedWithUsedUnderInFreightInformationSection(string InsuredType)
        {
            Report.WriteLine("Used will be displayed in Insured type column");
            string FreightInsuredType_UI = Gettext(attributeName_xpath, LTL_QC_FreightInsuredtypeValue_Xpath);
            Assert.AreEqual(InsuredType, FreightInsuredType_UI);
        }

        [Then(@"I will be displayed with the selected insuredtype under '(.*)' in FreightInformation section")]
        public void ThenIWillBeDisplayedWithTheSelectedInsuredtypeUnderInFreightInformationSection(string InsuredType)
        {
            Report.WriteLine("Used will be displayed in Insured type column");
            string FreightInsuredType_UI = Gettext(attributeName_xpath, LTL_QC_FreightInsuredtypeValue_Xpath);
            Assert.AreEqual(InsuredType, FreightInsuredType_UI);
        }
    }
}
