using System;
using TechTalk.SpecFlow;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using CRM.UITest.Entities;
using OpenQA.Selenium;
using System.Threading;
using System.Collections.Generic;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using CRM.UITest.CommonMethods;

namespace CRM.UITest.Scripts.Quote.LTL
{
    [Binding]
    public class LTLQuoteResultsScreenForRateRequestProcessSteps : ObjectRepository
    {
        [When(@"I enter valid mandatory data in Item section (.*), (.*), (.*)")]
        public void WhenIEnterValidMandatoryDataInItemSection(string Classification, string Weight, string Shipmentvalue)
        {
            Report.WriteLine("Enter details in item section");
            Click(attributeName_id, LTL_Classification_Id);
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
            Thread.Sleep(2000);
            SendKeys(attributeName_id, LTL_EnterInsuredValue_Id, Shipmentvalue);
        }

        [When(@"I enter valid services data in '(.*)' and  COD")]
        public void WhenIEnterValidServicesDataInAndCOD(string AdditionalService)
        {
            Click(attributeName_xpath, LTL_ServicesDropdown_Xpath);
            Thread.Sleep(1000);
            SelectDropdownValueFromList(attributeName_xpath, LTL_ServicesDropdownValues_Xpath, AdditionalService);
            Thread.Sleep(2000);
        }


        [When(@"I Click on view quote results button")]
        public void WhenIClickOnViewQuoteResultsButton()
        {
            Report.WriteLine("Click on Quote Results");
            try
            {
                Click(attributeName_id, LTL_ViewQuoteResults_Id);
                GlobalVariables.webDriver.WaitForPageLoad();
			}
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
                       
            WaitForElementPresent(attributeName_xpath, ltlQuoteResultsheader_xpath, "waitforheader");

        }
        [When(@"I will be navigated results page with rates (.*)")]
        public void WhenIWillBeNavigatedResultsPageWithRates(string url)
        {
            string resultPagrURL = url + "Rate/LtlResultsView";

            if (GetURL() == resultPagrURL)
            {
                Report.WriteLine("Rate Results available");
                VerifyElementPresent(attributeName_xpath, ltlQuoteResultsheader_xpath, "Quote Results (LTL)");
                VerifyElementPresent(attributeName_xpath, ltlresultsgridall_xpath, "ratereults");

            }
            else
            {
                string expected = Gettext(attributeName_xpath, ltlNoRateResultstxt_xpath);
                Assert.AreEqual(expected, "There are no rates available for this shipment.");
                Report.WriteLine("Rate Results nots available");
            }

        }
            


        [When(@"I will be displayed with Save your quote hyperlink and update your shipping information link")]
        public void WhenIWillBeDisplayedWithSaveYourQuoteHyperlinkAndUpdateYourShippingInformationLink()
        {
            
                Report.WriteLine("verify the presence of Save Your Quote");
                VerifyElementPresent(attributeName_xpath, ltlsavequotenorateslink_xpath, "save your quote");

                Report.WriteLine("verify the presence of update your shipping Information");
                VerifyElementPresent(attributeName_xpath, ltlUpdateurShpngInfolnk_xpath, "update your shipping Information");

            
            
        }

        [When(@"I click on update your shipping information link")]
        public void WhenIClickOnUpdateYourShippingInformationLink()
        {
            Report.WriteLine("Click on update your shipping information");
            Click(attributeName_xpath, ltlUpdateurShpngInfolnk_xpath);
        }

        [When(@"I enters the value in (.*) Textbox")]
        public void WhenIEntersTheValueInTextbox(string InsuredRate)
        {
            Report.WriteLine("Enter the Insured Rate");
            SendKeys(attributeName_xpath, ltlEnterInsuredValueTextbox_xpath, InsuredRate);
        }

        [When(@"I clicks on Show Insured Rate button")]
        public void WhenIClicksOnShowInsuredRateButton()
        {
            Report.WriteLine("Click on Show Insured Rate");
            Click(attributeName_xpath, ltlShowInsuredRateBtn_xpath);
        }

        [When(@"I click on Create shipment for selected carrier")]
        public void WhenIClickOnCreateShipmentButtonForSelectedCarrier()
        {
            Report.WriteLine("Creater shipment for selected carrier");
            Click(attributeName_xpath, ltlcreateshipmentbtn_xpath);
        }

        [When(@"I click on Create insured shipment for selected carrier")]
        public void WhenIClickOnCreateInsuredShipmentForSelectedCarrier()
        {
            Report.WriteLine("Create insured shipment for carrier");
            Click(attributeName_xpath, ltlcreateinsshipmentbtn_xpath);
        }

        [When(@"I will be displayed with pop up modal")]
        public void WhenIWillBeDisplayedWithPopUpModal()
        {
            Report.WriteLine("pop up displayed");
            Thread.Sleep(500);
            VerifyElementPresent(attributeName_xpath, ltlinsmodal_xpath, "insuredmodalpopup");
        }

        [When(@"I click on Do not Show button on the modal")]
        public void WhenIClickOnDoNotShowButtonOnTheModal()
        {
            Report.WriteLine("Click on Do not show button on the modal");
            Click(attributeName_xpath, ltlinsmdldontshowagain_xpath);
        }

        [When(@"I select the continue without insured option on modal")]
        public void WhenISelectTheContinueWithoutInsuredOptionOnModal()
        {
            Report.WriteLine("Select Continue without insured rates on modal");
            Thread.Sleep(500);
            VerifyElementVisible(attributeName_xpath, ltlinsmdlcntuewoutinsrate_xpath,"continuewithoutinsrate");
            Click(attributeName_xpath, ltlinsmdlcntuewoutinsrate_xpath);
        }

        [When(@"I click on Create insured shipment button for selected carrier")]
        public void WhenIClickOnCreateInsuredShipmentButtonForSelectedCarrier()
        {
            Report.WriteLine("Creater insured shipment for selected carrier");
            Click(attributeName_xpath, ltlcreateinsshipmentbtn_xpath);
        }

        [When(@"I click on save insured rate as quote link  for selected carrier")]
        public void WhenIClickOnSaveInsuredRateAsQuoteLinkForSelectedCarrier()
        {
            Report.WriteLine("Click on Save insured rate as quote");
            Click(attributeName_xpath, ltlsaveinsrateasquotelnk_xpath);
        }

        [When(@"I click on save insured rate as quote link  for selected carrierinternaluser")]
        public void WhenIClickOnSaveInsuredRateAsQuoteLinkForSelectedCarrierinternaluser()
        {
            Report.WriteLine("Click on Save insured rate as quote");
            Click(attributeName_xpath, ltlsaveinsrateasquotelnk_int_xpath);
        }


        [Then(@"I must be displayed with Back to Quote List button")]
        public void ThenIMustBeDisplayedWithBackToQuoteListButton()
        {
            Report.WriteLine("Display Back to Quote List button");
            VerifyElementPresent(attributeName_xpath, ltlBacktoQuoteListBtn_xpath, "Back to Quote List");
        }

        [Then(@"I must be displayed with textbox of Insured Rate with Show Insured Rate button")]
        public void ThenIMustBeDisplayedWithTextboxOfInsuredRateWithShowInsuredRateButton()
        {
            //Report.WriteLine("Display show insured rate textbox");
            //VerifyElementPresent(attributeName_xpath, ltlEnterInsuredValueTextbox_xpath, "entershipmentvalue");

            Report.WriteLine("Display show insured rate button");
            VerifyElementPresent(attributeName_xpath, ltlShowInsuredRateBtn_xpath, "Show Insured Rate Button");
        }
        
        [Then(@"I must be displayed with label Enter Insured Value")]
        public void ThenIMustBeDisplayedWithLabelEnterInsuredValue()
        {
            Report.WriteLine("Display with label Enter Insured Value");
            VerifyElementPresent(attributeName_xpath, EnterInsvaltext_xpath, "Enter Insured Value:");                       
        }

        [Then(@"I Enter valid data in (.*) field")]
        public void ThenIEnterValidDataInField(string EnterInsuredValue)
        {
            Report.WriteLine("Entering data in Enter Insured value text box");
            Clear(attributeName_xpath, ltlEnterInsuredValueTextbox_xpath);
            SendKeys(attributeName_xpath, ltlEnterInsuredValueTextbox_xpath, EnterInsuredValue);
        }

        [Then(@"I must be displayed with (.*) dropdown")]
        public void ThenIMustBeDisplayedWithDropdown(string InsuredType)
        {
            Report.WriteLine("Select Insured type from dropdown");
            Click(attributeName_xpath, InsuredType_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, InsuredValueTypeDropDown_Xpath, InsuredType);
        }

        [Then(@"I must be displayed with Terms and Conditions hyper link")]
        public void ThenIMustBeDisplayedWithTermsAndConditionsHyperLink()
        {
            Report.WriteLine("Display Terms and conditions link");
            VerifyElementPresent(attributeName_xpath, ltlTermsandConditionslnk_xpath, "TermsandConditions");
        }

        [Then(@"I must be displayed with Quickest Service radio button")]
        public void ThenIMustBeDisplayedWithQuickestServiceRadioButton()
        {
            Report.WriteLine("Quickest Service Radio button selected by default");
            VerifyElementVisible(attributeName_xpath, ltlQuickestSrvcRadioBtn_xpath,"quickestserviceradiobutton");
        }

        [Then(@"I must be displayed with Least cost radio button")]
        public void ThenIMustBeDisplayedWithLeastCostRadioButton()
        {
            Report.WriteLine("Display Least cost Radio button");
            VerifyElementVisible(attributeName_xpath, ltlLeastcostRadioBtn_xpath, "Least cost");
        }

        [Then(@"I must be displayed with DISCLAIMER information at the bottom of the page")]
        public void ThenIMustBeDisplayedWithDISCLAIMERInformationAtTheBottomOfThePage()
        {
            Report.WriteLine("Display the Disclaimer information at the botton of Rate Results Page");
            Verifytext(attributeName_xpath, ltlDisclaimer_xpath, "DISCLAIMER: This quote is valid for 7 days.");
        }
             
        [Then(@"I must be displayed with Carrier Name and Carrier Logo under Carriers column")]
        public void ThenIMustBeDisplayedWithCarrierNameAndCarrierLogoUnderCarriersColumn()
        {
            Report.WriteLine("Display carrier name and carrier logo");
            VerifyElementPresent(attributeName_xpath, ltlCarrierName_xpath, "carriername");
            VerifyElementPresent(attributeName_xpath, ltlCarrierLogo_xpath, "carrierlogo");
        }
        
        [Then(@"I must be displayed with Number of Days and Direct/Indirect under Service Days column")]
        public void ThenIMustBeDisplayedWithNumberOfDaysAndDirectIndirectUnderServiceDaysColumn()
        {
            Report.WriteLine("Display number of days");
            VerifyElementPresent(attributeName_xpath, ltlNoOfDays_xpath, "days");
        }
        
        [Then(@"I must be displayed with Distance in miles under Distance column")]
        public void ThenIMustBeDisplayedWithDistanceInMilesUnderDistanceColumn()
        {
            Report.WriteLine("Display distance");
            VerifyElementPresent(attributeName_xpath,ltldistancevalue_xpath,"distance");
        }
        
        [Then(@"I must be displayed with Rate prefaced with rate value,Fuel, Line Haul, Accessorials, Create Shipment button and Save rate as quote link under Rate column")]
        public void ThenIMustBeDisplayedWithRatePrefacedWithRateValueFuelLineHaulAccessorialsCreateShipmentButtonAndSaveRateAsQuoteLinkUnderRateColumn()
        {
            Report.WriteLine("display rate,fuel,linehaul,accessorials,createshipmentbtn,saverateasquote fields in standard rate column");
            VerifyElementPresent(attributeName_xpath, ltlstdRateamount_xpath, "insuredrateamount");
            VerifyElementPresent(attributeName_xpath, ltlstdFuel_xpath, "fuel");
            VerifyElementPresent(attributeName_xpath, ltlstdLinehaul_xpath, "linehaul");
            VerifyElementPresent(attributeName_xpath, ltlstdaccessorials_xpath, "accessorials");
            VerifyElementPresent(attributeName_xpath, ltlcreateshipmentbtn_xpath, "createshipmentbutton");
            VerifyElementPresent(attributeName_xpath, ltlsaverateasquotelnk_xpath, "saverateasquotelink");
        }
        
        [Then(@"I must be displayed with Insured Rate prefaced rate value,Fuel, Line Haul, Accessorials, Create Insured Shipment button and Save insured rate as quote link under Insured Rate column")]
        public void ThenIMustBeDisplayedWithInsuredRatePrefacedRateValueFuelLineHaulAccessorialsCreateInsuredShipmentButtonAndSaveInsuredRateAsQuoteLinkUnderInsuredRateColumn()
        {
            Report.WriteLine("display rate,fuel,linehaul,accessorials,create insured shipmentbtn,save insuredrateasquote fields in insured rate column");
            VerifyElementPresent(attributeName_xpath, ltlinsrateamount_xpath, "insuredrateamount");
            VerifyElementPresent(attributeName_xpath, ltlinsfuel_xpath, "fuel");
            VerifyElementPresent(attributeName_xpath, ltlinslinehaul_xpath, "linehaul");
            VerifyElementPresent(attributeName_xpath, ltlinsaccessorials_xpath, "accessorials");
            VerifyElementPresent(attributeName_xpath, ltlcreateinsshipmentbtn_xpath, "createinsshipment");
            VerifyElementPresent(attributeName_xpath, ltlsaveinsrateasquotelnk_xpath, "saveinsuredrate");

        }
        
        [Then(@"I will be displayed with Save your quote hyperlink and update your shipping information link")]
        public void ThenIWillBeDisplayedWithSaveYourQuoteHyperlinkAndUpdateYourShippingInformationLink()
        {
            Report.WriteLine("display saveyourquotehyperlink and updateinformationpagelink");
            VerifyElementPresent(attributeName_xpath, ltlsavequotenorateslink_xpath, "saveyourquotehyperlink");
            VerifyElementPresent(attributeName_xpath, ltlUpdateurShpngInfolnk_xpath, "updateinformationpagelink");

        }
        
        [Then(@"I should navigate to shipment information page")]
        public void ThenIShouldNavigateToShipmentInformationPage()
        {
            Report.WriteLine("Navigated to shipment information page");
            VerifyElementVisible(attributeName_id, LTL_shipmentinformationpageheader_Xpath, "shipmentonformationpageheader");
        }


        [Then(@"I should not be displayed with Save your quote hyperlink and update your shipping information link")]
        public void ThenIShouldNotBeDisplayedWithSaveYourQuoteHyperlinkAndUpdateYourShippingInformationLink()
        {
            Report.WriteLine("not displayed saveyourquotehyperlinkwith no rates and updateinformationpagelink ");
            VerifyElementNotPresent(attributeName_xpath, ltlsavequotenorateslink_xpath, "saveyourquotehyperlink");
            VerifyElementNotPresent(attributeName_xpath, ltlUpdateurShpngInfolnk_xpath, "updateinformationpagelink");

        }
        
        [Then(@"I should be displayed with updated Insured rate column in the grid")]
        public void ThenIShouldBeDisplayedWithUpdatedInsuredRateColumnInTheGrid()
        {
            Report.WriteLine("displayed insured rate column");
            VerifyElementPresent(attributeName_xpath,ltlinsuredratecolumngrid_xpath,"insuredratecolumngrid");
        }

        [Then(@"I should not be displayed with updated Insured rate column in the grid")]
        public void ThenIShouldNotBeDisplayedWithUpdatedInsuredRateColumnInTheGrid()
        {
            Report.WriteLine("displayed insured rate column");
            VerifyElementNotPresent(attributeName_xpath, ltlinsuredratecolumngrid_xpath, "insuredratecolumngrid");
        }
        
        [Then(@"I should be displayed with warning message in red color below the Shipment Value text box")]
        public void ThenIShouldBeDisplayedWithWarningMessageInRedColorBelowTheShipmentValueTextBox()
        {
            Report.WriteLine("displayed insured rate column");
            VerifyElementPresent(attributeName_xpath, ltlerrormsgfornoshipmentvalue_xpath, "errormessage");
        }
        
        [Then(@"I will be displayed with pop up modal with options do not show check box,shipment value button,Show Insured Rates and continue without insured rates button")]
        public void ThenIWillBeDisplayedWithPopUpModalWithOptionsDoNotShowCheckBoxShipmentValueButtonShowInsuredRatesAndContinueWithoutInsuredRatesButton()
        {
            Report.WriteLine("displayed ltlinsuredmodal,ltlinsuredmodalheader,ltlinsuredmodalheader,Showinsuredratesbutton,continuewithoutinsuredratesbutton,Dontshowthemessageagain");
            VerifyElementPresent(attributeName_xpath, ltlinsmodal_xpath, "ltlinsuredmodal");
            VerifyElementPresent(attributeName_xpath, ltlinsmdlheader_xpath, "ltlinsuredmodalheader");
            VerifyElementPresent(attributeName_id, ltlinsmdlshpmentvalue_id, "ltlinsuredmodalheader");
            VerifyElementPresent(attributeName_xpath, ltlinsmdlshowinsratebtn_xpath, "Showinsuredratesbutton");
            VerifyElementPresent(attributeName_xpath, ltlinsmdlcntuewoutinsrate_xpath, "continuewithoutinsuredratesbutton");
            VerifyElementPresent(attributeName_xpath, ltlinsmdldontshowagain_xpath, "Dontshowthemessageagain");

        }
        
        [Then(@"I should not be displayed with insuredrate pop up modal")]
        public void ThenIShouldNotBeDisplayedWithInsuredratePopUpModal()
        {
            Report.WriteLine("displyed insuredrate modal popup ");
            VerifyElementNotPresent(attributeName_xpath, ltlinsmodal_xpath, "LTLinsuredmodal");
        }
        
        [Then(@"I should not display with the modal")]
        public void ThenIShouldNotDisplayWithTheModal()
        {
            Report.WriteLine("displyed insuredrate modal popup");
            VerifyElementNotPresent(attributeName_xpath, ltlinsmodal_xpath, "LTLinsuredmodal");
        }
        
        [Then(@"I will navigated to Create shipment screen")]
        public void ThenIWillNavigatedToCreateShipmentScreen()
        {
            Report.WriteLine("navigated to create shipment screen");
            VerifyElementPresent(attributeName_xpath, LTL_createshipmentpageheader_xpath, "createshipmentheader");
        }

        [When(@"I click on save rate as quote link  for selected carrier which has gaurenteed rate")]
        public void WhenIClickOnSaveRateAsQuoteLinkForSelectedCarrierWhichHasGaurenteedRate()
        {
            Report.WriteLine("Click gaurenteed rate");
            MoveToElement(attributeName_xpath, ltlsavegaurenteedstdquote_xpath);
            Click(attributeName_xpath, ltlsavegaurenteedstdquote_xpath);

        }

        [When(@"click on save quote anyway")]
        public void WhenClickOnSaveQuoteAnyway()
        {
            Click(attributeName_xpath, ltlsavequotenorateslink_xpath);
        }

        [Then(@"quote will  navigated to LTL confirmation screen and displayed with saved quoteID")]
        public void ThenQuoteWillNavigatedToLTLConfirmationScreenAndDisplayedWithSavedQuoteID()
        {
              
            Report.WriteLine("Verify the LTL quote Confirmation header");
            string QuoteConfirmationPageHeader_UI = Gettext(attributeName_xpath, LTL_QuoteConfirmationPageHeader_Xpath);
            String QuoteConfirmationpageText = "Quote Confirmation";
            Assert.AreEqual(QuoteConfirmationpageText, QuoteConfirmationPageHeader_UI);
            VerifyElementPresent(attributeName_xpath, LTL_QC_requestnumber_Xpath, "quotereferncenumber");
            string quotenumber = Gettext(attributeName_xpath, LTL_QC_requestnumber_Xpath);
            Report.WriteLine("quote has saved with the refernce number" + quotenumber);
            Console.WriteLine("quote has saved with the refernce number" + quotenumber);

        }
        [Then(@"quote number will be saved in database")]
        public void ThenQuoteNumberWillBeSavedInDatabase()
        {
            string savedquotenumber = DBHelper.GetQuoteNumber();
            Report.WriteLine("quote has saved with the refernce number in DB" + savedquotenumber);


        }
             
        [Then(@"i should navigate back to information page")]
        public void ThenIShouldNavigateBackToInformationPage()
        {
           VerifyElementPresent(attributeName_xpath, LTL_shipmentinformationpageheaderc_Xpath, "Quote Results (LTL)");
        }

        [When(@"I click on save rate as quote link  for selected carrier")]
        public void WhenIClickOnSaveRateAsQuoteLinkForSelectedCarrier()
        {
            Click(attributeName_xpath, ltlsaverateasquotelnk_xpath);
        }

        [Then(@"i click on continue without insured rates button")]
        public void ThenIClickOnContinueWithoutInsuredRatesButton()
        {
            Click(attributeName_xpath, ltlinsmdlcntuewoutinsrate_xpath);
        }

        [Given(@"i login again to the application with same user")]
        public void GivenILoginAgainToTheApplicationWithSameUser()
        {
            Report.WriteLine("Launch URL");
            LaunchURL();
            Report.WriteLine("Land on Homepage");
            Click(attributeName_id, SignIn_Id);
        }
     
        [When(@"I update valid data in Origin section (.*)")]
        public void WhenIUpdateValidDataInOriginSection(string uOriginZip)
        {
            Clear(attributeName_id, LTL_OriginZipPostal_Id);
            SendKeys(attributeName_id, LTL_OriginZipPostal_Id, uOriginZip);
            Thread.Sleep(200);
        }

        [When(@"I update valid data in Destination section (.*)")]
        public void WhenIUpdateValidDataInDestinationSection(string uDestinationZip)
        {
            Clear(attributeName_id, LTL_DestinationZipPostal_Id);
           SendKeys(attributeName_id, LTL_DestinationZipPostal_Id, uDestinationZip);
           Thread.Sleep(200);

        }

        [When(@"I click on the Guaranteed Rate carriers hyperlink")]
        public void WhenIClickOnTheGuaranteedRateCarriersHyperlink()
        {
            Report.WriteLine("Click on Guaranteed Rate hyperlink");
            Click(attributeName_xpath, ltlGuaranteedRateAvbllnk_xpath);
        }

        [When(@"I will be navigated to Guaranteed Rate carriers grid")]
        public void WhenIWillBeNavigatedToGuaranteedRateCarriersGrid()
        {
            Report.WriteLine("Naviagting to Guaranteed Rate carriers grid");
            MoveToElement(attributeName_xpath, ltlguarenteedrategrid_xpath);
        }

        [When(@"I will be navigated Quote results page")]
        public void WhenIWillBeNavigatedQuoteResultsPage()
        {
            string configURL = launchUrl;
            string resultPagrURL = configURL + "Rate/LtlResultsView";
            if (GetURL() == resultPagrURL)
            {
                Report.WriteLine("Rate Results available");
                VerifyElementPresent(attributeName_xpath, ltlQuoteResultsheader_xpath, "Quote Results (LTL)");
                VerifyElementPresent(attributeName_xpath, ltlresultsgridall_xpath, "ratereults");
                Console.WriteLine("rates are displpaying for the given information");

            }
            else
            {
                Report.WriteLine("Rates are not available");
                Console.WriteLine("Rate Results are not available for the given information");
        
                Click(attributeName_xpath, ltlsavequotenorateslink_xpath);
            }
        }

        [Then(@"I have not Entered valid data in (.*) field")]
        public void ThenIHaveNotEnteredValidDataInField(string EnterInsuredValue)
        {
            Report.WriteLine("Not Entering data in Enter Insured value text box");
            SendKeys(attributeName_xpath, ltlEnterInsuredValueTextbox_xpath, EnterInsuredValue);
        }

        [Then(@"I will not be able to select any insured type from dropdown")]
        public void ThenIWillNotBeAbleToSelectAnyInsuredTypeFromDropdown()
        {
            Report.WriteLine("Insured type dropdown not enabled");
            Click(attributeName_xpath, InsuredType_Xpath);
        }

        [Then(@"I will be displayed with pop up modal")]
        public void ThenIWillBeDisplayedWithPopUpModal()
        {
            Report.WriteLine("pop up displayed");
            Thread.Sleep(500);
            VerifyElementPresent(attributeName_xpath, ltlinsmodal_xpath, "insuredmodalpopup");
        }

        [Then(@"(.*) and (.*) must be displayed in Rate Results Page")]
        public void ThenAndMustBeDisplayedInRateResultsPage(string Insuredvalue, string InsuredvalueType)
        {
            Report.WriteLine("Entered Insured value on Get Quote page should be binded");
            string insvall = GetValue(attributeName_id, LTL_EnterInsuredValue_Id, "value");            
            string insval1 = "$" + Insuredvalue + ".00";
            Assert.AreEqual(insval1, insvall);

            Report.WriteLine("Entered Insured value type on Get Quote page should be binded");
            string insvaltype = Gettext(attributeName_xpath, InsuredType_Xpath);
            Assert.AreEqual(InsuredvalueType, insvaltype);
        }



        [Then(@"I should be displayed with Ship From and Ship To fields under the Services and Accessorials section not Services/Accessorials label")]
        public void ThenIShouldBeDisplayedWithShipFromAndShipToFieldsUnderTheServicesAndAccessorialsSectionNotServicesAccessorialsLabel()
        {
            Report.WriteLine("ShouldBeDisplayedWithShipFromAndShipToFieldsUnderTheServicesAndAccessorialsSection");
            Thread.Sleep(2000);
            string shiptolabel = Gettext(attributeName_xpath, LTL_QC_shiptoserviceslabel);
            string shiptolabelexpected = "Ship To";
            Assert.AreEqual(shiptolabel, shiptolabelexpected);
            Thread.Sleep(2000);
            string shipfromlabel = Gettext(attributeName_xpath, LTL_QC_shipfromserviceslabel);
            string shipfromlabelexpected = "Ship From";
            Assert.AreEqual(shipfromlabel, shipfromlabelexpected);
        }

        [Then(@"I should display with NA in Ship From field in Services and Accessorials section")]
        public void ThenIShouldDisplayWithNAInShipFromFieldInServicesAndAccessorialsSection()
        {
            Report.WriteLine("ShouldBeDisplayedWithNAinshipfromfield");
            string expectedna = "N/A";
            Thread.Sleep(2000);
            string actualvalue = Gettext(attributeName_xpath, LTL_QC_shipfromservicesvalues);
            Assert.AreEqual(expectedna, actualvalue);
        }

        [Then(@"I should display with NA in ship to field in Service and Accessorials section")]
        public void ThenIShouldDisplayWithNAInShipToFieldInServiceAndAccessorialsSection()
        {
            Report.WriteLine("ShouldBeDisplayedWithNAinshiptofield");
            string expectedna = "N/A";
            Thread.Sleep(2000);
            string actualvalue = Gettext(attributeName_xpath, LTL_QC_shiptoservicesvalues);
            Assert.AreEqual(expectedna, actualvalue);
        }

        [Then(@"I should be displayed with selected '(.*)' and (.*) Services")]
        public void ThenIShouldBeDisplayedWithSelectedAndServices(string Accessorials1, string Accessorials2)
        {
            string expectedvalue = Accessorials1 + "," + Accessorials2;
            Thread.Sleep(2000);
            string actualvalue = Gettext(attributeName_xpath, LTL_QC_shipfromservicesvalues);
            Assert.AreEqual(expectedvalue, actualvalue);
        }

        [Then(@"I should be displayed with selected to '(.*)' and '(.*)' Service")]
        public void ThenIShouldBeDisplayedWithSelectedToAndService(string Accessorials1, string Accessorials2)
        {
            string expectedvalue = Accessorials1 + "," + Accessorials2;
            Thread.Sleep(2000);
            string actualvalue = Gettext(attributeName_xpath, LTL_QC_shiptoservicesvalues);
            Assert.AreEqual(expectedvalue, actualvalue);
        }


        [Then(@"I should be displyed with selected all '(.*)' and '(.*)' and '(.*)' and '(.*)' in details")]
        public void ThenIShouldBeDisplyedWithSelectedAllAndAndAndInDetails(string Accessorials1, string Accessorials2, string Accessorials3, string Accessorials4)
        {
            string expectedvalue = Accessorials1 + "," + Accessorials2;
            Thread.Sleep(2000);
            string actualvalue = Gettext(attributeName_xpath, LTL_QC_shipfromservicesvalues);
            Assert.AreEqual(expectedvalue, actualvalue);
            string expectedvalue1 = Accessorials3 + "," + Accessorials4;
            Thread.Sleep(2000);
            string actualvalue1 = Gettext(attributeName_xpath, LTL_QC_shiptoservicesvalues);
            Assert.AreEqual(expectedvalue1, actualvalue1);
        }


        [When(@"I navigating to results page")]
        public void WhenINavigatingToResultsPage()
        {
            Thread.Sleep(25000);
        }


        [Then(@"I should be displayed with selected to '(.*)' Services")]
        public void ThenIShouldBeDisplayedWithSelectedToServices(string Accessorials1)
        {
            Report.WriteLine("ShouldBeDisplayedWithNAinshiptofield");
            Thread.Sleep(1000);
            string actualselectedservices = Gettext(attributeName_xpath, LTL_QC_shiptoservicesvalues);
            Assert.AreEqual(actualselectedservices, Accessorials1);
        }


        [Then(@"I should be displayed with selected '(.*)' Services")]
        public void ThenIShouldBeDisplayedWithSelectedServices(string Accessorials1)
        {
            Report.WriteLine("ShouldBeDisplayedWithNAinshiptofield");
            Thread.Sleep(2000);
            string actualselectedservices = Gettext(attributeName_xpath, LTL_QC_shipfromservicesvalues);
            Assert.AreEqual(actualselectedservices, Accessorials1);
        }


        [Then(@"I should be displayed with NA in Ship From and  Ship To field  in Services and Accessorials section\.")]
        public void ThenIShouldBeDisplayedWithNAInShipFromAndShipToFieldInServicesAndAccessorialsSection_()
        {
            Report.WriteLine("ShouldBeDisplayedWithNA");
            string expectedna = "N/A";
            Thread.Sleep(2000);
            string actualvalue = Gettext(attributeName_xpath, LTL_QC_shiptoservicesvalues);
            Assert.AreEqual(expectedna, actualvalue);
            string expectedna1 = "N/A";
            Thread.Sleep(2000);
            string actualvalue1 = Gettext(attributeName_xpath, LTL_QC_shipfromservicesvalues);
            Assert.AreEqual(expectedna1, actualvalue1);
        }

        [Then(@"I should be displyed with selected '(.*)' and '(.*)' in details")]
        public void ThenIShouldBeDisplyedWithSelectedAndInDetails(string Accessorials1, string Accessorials2)
        {
            Report.WriteLine("selectedservicesShouldBeDisplayedindetailsofconfirmation");
            Thread.Sleep(2000);
            string actualselectedservices = Gettext(attributeName_xpath, LTL_QC_shiptoservicesvalues);
            Assert.AreEqual(actualselectedservices, Accessorials2);
            Thread.Sleep(2000);
            string actualselectedservices1 = Gettext(attributeName_xpath, LTL_QC_shipfromservicesvalues);
            Assert.AreEqual(actualselectedservices1, Accessorials1);
        }

        [When(@"I select a service '(.*)' from the ShipTo section dropdown")]
        public void WhenISelectAServiceFromTheShipToSectionDropdown(string Accessorials2)
        {
            Report.WriteLine("Selection of Accessorials and Services");
            SelectDropdownValueFromList(attributeName_xpath, LTL_ServicesDropdownValues_ShipTo_Xpath, Accessorials2);

        }


        [Then(@"I should be displayed with selected '(.*)' in details of confirmation")]
        public void ThenIShouldBeDisplayedWithSelectedInDetailsOfConfirmation(string Accessorials1, string Accessorials2)
        {
            Report.WriteLine("selectedservicesShouldBeDisplayedindetailsofconfirmation");
            Thread.Sleep(2000);
            string actualselectedservices = Gettext(attributeName_xpath, LTL_QC_shiptoservicesvalues);
            Assert.AreEqual(actualselectedservices, Accessorials2);
            Thread.Sleep(2000);
            string actualselectedservices1 = Gettext(attributeName_xpath, LTL_QC_shipfromservicesvalues);
            Assert.AreEqual(actualselectedservices1, Accessorials1);
        }

        [When(@"I click on guaranteed save insured rate as quote link  for selected carrier")]
        public void WhenIClickOnGuaranteedSaveInsuredRateAsQuoteLinkForSelectedCarrier()
        {
            Report.WriteLine("Click on Save insured rate as Quote link of guaranteed grid");
            Click(attributeName_xpath, saveinsrateasquoteGuaranteed_xpath);
        }

        [When(@"I click on guaranteed save insured rate as quote link  for selected carrierintuser")]
        public void WhenIClickOnGuaranteedSaveInsuredRateAsQuoteLinkForSelectedCarrierintuser()
        {
            Report.WriteLine("Click on Save insured rate as Quote link of guaranteed grid");
            Click(attributeName_xpath, saveinsrateasquoteGuaranteedint_xpath);
        }

        [When(@"I click on guaranteed save rate as quote link  for selected carrier")]
        public void WhenIClickOnGuaranteedSaveRateAsQuoteLinkForSelectedCarrier()
        {
            Report.WriteLine("Click on Save rate as Quote link of guaranteed grid");
            Click(attributeName_xpath, saverateasquoteGuaranteed_xpath);
        }

        [When(@"I click on guaranteed save rate as quote link  for selected carrierintuser")]
        public void WhenIClickOnGuaranteedSaveRateAsQuoteLinkForSelectedCarrierintuser()
        {
            Report.WriteLine("Click on Save rate as Quote link of guaranteed grid");
            Click(attributeName_xpath, saverateasquoteGuaranteedint_xpath);
        }



        [Then(@"I Enter valid data in (.*) field of insured modal pop up")]
        public void ThenIEnterValidDataInFieldOfInsuredModalPopUp(string EnterInsuredValue)
        {
            Report.WriteLine("Entering data in Enter Insured value text box");
            SendKeys(attributeName_id, ltlinsmdlshpmentvalue_id, EnterInsuredValue);
        }

        [Then(@"I must be able to see the options New or Used in the Insured Type drop down on modal")]
        public void ThenIMustBeAbleToSeeTheOptionsNewOrUsedInTheInsuredTypeDropDownOnModal()
        {
            Report.WriteLine("Verifying the drop down options New and Used");
            Click(attributeName_xpath, InsmodalNewOrUsedDropdown);
            var InsuredValueDropdown = new List<string> { "New", "Used" };
            List<string> NewOrUsedUI = GetDropdownOptions(attributeName_xpath, InsmodalInsuredValueTypeDropDown_Xpath, "li");
            CollectionAssert.AreEqual(InsuredValueDropdown, NewOrUsedUI);
        }

        [Then(@"the default value must be New on modal")]
        public void ThenTheDefaultValueMustBeNewOnModal()
        {
            Verifytext(attributeName_xpath, InsmodalInsuredValueDefault, "New");
        }

        [Then(@"I must be displayed with (.*) dropdown on modal")]
        public void ThenIMustBeDisplayedWithDropdownOnModal(string InsuredType)
        {
            Report.WriteLine("Select Insured type from dropdown");
            Click(attributeName_xpath, InsmodalInsuredType_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, InsmodalInsuredValueTypeDropDown_Xpath, InsuredType);
                        
        }

        [Then(@"I have not Entered valid data in (.*) field of modal pop up")]
        public void ThenIHaveNotEnteredValidDataInFieldOfModalPopUp(string EnterInsuredValue)
        {
            Report.WriteLine("Not Entering data in Enter Insured value text box");
            SendKeys(attributeName_id, ltlinsmdlshpmentvalue_id, EnterInsuredValue);
        }

        [Then(@"I will not be able to select any insured type from dropdown of modal pop up")]
        public void ThenIWillNotBeAbleToSelectAnyInsuredTypeFromDropdownOfModalPopUp()
        {
            Report.WriteLine("Insured type dropdown not enabled on modal pop up");
            Click(attributeName_xpath, InsmodalInsuredType_Xpath);
        }

        [When(@"I click on save your quote on results page when no rates")]
        public void WhenIClickOnSaveYourQuoteOnResultsPageWhenNoRates()
        {
            Report.WriteLine("Click on save your quote link");
            Thread.Sleep(1000);
            VerifyElementVisible(attributeName_xpath, ltlsavequotenorateslink_xpath, "saveyourquotehyperlink");
            Click(attributeName_xpath, ltlsavequotenorateslink_xpath);
        }

        [Then(@"selected (.*) must be displayed on Rate Results Page")]
        public void ThenSelectedMustBeDisplayedOnRateResultsPage(string InsuredType)
        {
            Report.WriteLine("Selected Insured type must be displayed");
            string instype_UI = Gettext(attributeName_xpath, Instypeselected_xpath);
            Assert.AreEqual(InsuredType, instype_UI);
        }

    }
}
