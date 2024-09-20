using System;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Regression.Quotes
{
    [Binding]
    public class Regression_QuoteCreationAndVerificationInQuoteListPageSteps : Quotelist
    {
        private CommonMethodsCrm commonCrmMethods = new CommonMethodsCrm();
        private AddQuoteLTL quote = new AddQuoteLTL();
        string quoteNumber = string.Empty;
        string carrierName = string.Empty;
        string quoteAmount = string.Empty;

        [Given(@"I Navigate to quotelist page")]
        public void GivenINavigateToQuotelistPage()
        {
            //Go to Quote List            
            GlobalVariables.webDriver.WaitForPageLoad();
            try
            {
                Click(attributeName_xpath, QuoteModule_Xpath);
            }
            catch
            {
                GlobalVariables.webDriver.WaitForPageLoad();
            }
            Report.WriteLine("Navigated to Quote list page");
        }

        [Given(@"I Click on Create Quote Button")]
        public void GivenIClickOnCreateQuoteButton()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, SubmitRateRequestButton_Id);
            Report.WriteLine("Navigated to Tiles Page");
        }

        [Given(@"I Click on LTL Tile")]
        public void GivenIClickOnLTLTile()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, LTL_TileLabel_Id);
        }

        [Given(@"I Enter Address information (.*) , (.*)")]
        public void GivenIEnterAddressInformation(string originZipcode, string destinationZipcode)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ClearAddress_OriginId);
            GlobalVariables.webDriver.WaitForPageLoad();
            quote.EnterOriginZip(originZipcode);

            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ClearAddress_DestId);
            GlobalVariables.webDriver.WaitForPageLoad();
            quote.EnterDestinationZip(destinationZipcode);
        }

        [Given(@"I Enter Item Information (.*), (.*), (.*)")]
        public void GivenIEnterItemInformation(string classification, string weight, string quantity)
        {
            quote.EnterItemdata(classification, weight);
            SendKeys(attributeName_classname, "initial-quantity", quantity);
        }

        [Given(@"I Click on View Quotes button")]
        public void GivenIClickOnViewQuotesButton()
        {
            try
            {
                GlobalVariables.webDriver.WaitForPageLoad();
                Click(attributeName_id, GetQuote_ViewQuoteResult_Button_Id);
            }
            catch
            {
                GlobalVariables.webDriver.WaitForPageLoad();
            }      
        }

        [Given(@"I Click on Create Quote for a standard Carrier")]
        public void GivenIClickOnCreateQuoteForAStandardCarrier()
        {
            if (IsElementPresent(attributeName_id, "no-results-save-quote", "No results Page"))
            {
                Report.WriteFailure("No Carriers available");
            }
            else
            {
                GlobalVariables.webDriver.WaitForPageLoad();
                carrierName = Gettext(attributeName_xpath, ltlCarrierName_xpath);
                quoteAmount = Gettext(attributeName_xpath, ltlstandardratesall_xpath);

                Click(attributeName_xpath, QuoteResult_LTL_SaveQuoteLink_Xpath);
            }
        }

        [Given(@"I Click on Create Quote for a standard Guaranteed Carrier")]
        public void GivenIClickOnCreateQuoteForAStandardGuaranteedCarrier()
        {
            if (IsElementPresent(attributeName_id, "no-results-save-quote", "No results Page"))
            {
                Report.WriteFailure("No Carriers available");
            }
            else
            {
                GlobalVariables.webDriver.WaitForPageLoad();
                if (IsElementPresent(attributeName_id, "Grid-Rate-List-Large-Guranteed", "Guaranteed carrier table"))
                {
                    carrierName = Gettext(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-Guranteed']/tbody/tr[1]/td[1]/ul/li[1]");
                    quoteAmount = Gettext(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-Guranteed']/tbody/tr[1]/td[4]/ul[1]/li[1]");
                    Click(attributeName_xpath, saverateasquoteGuaranteed_xpath);
                }
                else
                {
                    Report.WriteFailure("No guaranteed carriers available");
                }
            }
        }

        [Given(@"I click on save insured rate as quote link for carrier")]
        public void GivenIClickOnSaveInsuredRateAsQuoteLinkForCarrier()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            string configURL = launchUrl;
            string resultPagrURL = configURL + "Rate/LtlResultsView";
            carrierName = Gettext(attributeName_xpath, ltlCarrierName_xpath);
            quoteAmount = Gettext(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr/td[button[contains(@id, 'create-std-insured-shipment-btn')]]/ul[1]/li[1]");
            if (GetURL() == resultPagrURL)
            {
                Report.WriteLine("Creater shipment for selected carrier");
                Click(attributeName_xpath, ltlsaveinsrateasquotelnk_xpath);
            }
            else
            {
                Report.WriteFailure("Rates are not available");
            }
        }

        [Given(@"I Arrive on the Quote Confirmation Page")]
        public void GivenIArriveOnTheQuoteConfirmationPage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            quoteNumber = Gettext(attributeName_id, "referenceNumber-value");
            Report.WriteLine("Quote created successfully");
        }

        [When(@"I Navigate to quotelist page")]
        public void WhenINavigateToQuotelistPage()
        {
            //Go to Quote List            
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, QuoteModule_Xpath);
            Report.WriteLine("Navigated to Quote list page");
        }

        [Then(@"Verify that the Quote is available in Quotelist page")]
        public void ThenVerifyThatTheQuoteIsAvailableInQuotelistPage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            if (!string.IsNullOrWhiteSpace(quoteNumber))
            {
                Report.WriteLine("Search the quote number in quote list page");
                SendKeys(attributeName_id, "searchbox", quoteNumber);

                string quoteNumberFromGrid = Gettext(attributeName_xpath, QuoteList_FirstRecord_QuoteNumber_xpath);

                Assert.AreEqual(quoteNumber, quoteNumberFromGrid);
                Report.WriteLine("Quote created is available in quote list page");
            }
        }

        [Then(@"I Verify the quote details in quote details section (.*) , (.*),(.*), (.*), (.*)")]
        public void ThenIVerifyTheQuoteDetailsInQuoteDetailsSection(string originZipcode, string destinationZipcode, string classification, string weight, string quantity)
        {
            //Verify quote details
            //Verify Carrier details
            VerifyCarrierDetailsInQuoteListGrid();
                     
            //Expand quote details section
            int rowcount = GetCount(attributeName_xpath, QuoteList_TotalRecords_Xpath);
            if (rowcount > 1)
            {
                Click(attributeName_xpath, ".//*[@id='QuotesGrid']/tbody/tr[1]/td[contains(@class, 'moreinfocontainer')]/button");//QuoteDetails_Expand_FirstRecord_Xpath);
                Report.WriteLine("Expanded the quote details section");
                GlobalVariables.webDriver.WaitForPageLoad();

                //Address details
                VerifyAddressDetailsInQuoteDetailsSection(originZipcode, destinationZipcode);

                //Verify Item Details
                VerifyItemDetailsInQuoteDetailsSection(classification, weight, quantity);

                //Verify Dates
                VerifyDatesInQuoteDetailsSection();
            }
            else
            {
                Report.WriteLine("No Records found for the LTL quotes for the logged in user");
            }
        }

        private void VerifyCarrierDetailsInQuoteListGrid()
        {
            if (!string.IsNullOrWhiteSpace(carrierName))
            {
                string carrierNameFromGrid = Gettext(attributeName_xpath, ".//*[@id='QuotesGrid']/tbody/tr[1]/td[contains(@class, 'carriername')]");
                Assert.AreEqual(carrierName.ToLower(), carrierNameFromGrid.ToLower());
                Report.WriteLine("Verified carrier name in quote list page");

                //Verify quote Amount
                string quoteAmountFromGrid = Gettext(attributeName_xpath, ".//*[@id='QuotesGrid']/tbody/tr[1]/td[contains(@class, 'quotevalue')]/span[contains(@class, 'quotecontent')]");

                quoteAmount = quoteAmount.Contains("*") ? quoteAmount.Replace("*", string.Empty).Trim() : quoteAmount;
                quoteAmount = quoteAmount.Replace("$", string.Empty).Trim();
                quoteAmountFromGrid = quoteAmountFromGrid.Replace("$", string.Empty).Trim();

                double quoteAmnt, quoteAmntFromGrid;
                if(double.TryParse(quoteAmount, out quoteAmnt) && double.TryParse(quoteAmountFromGrid, out quoteAmntFromGrid))
                {
                    Assert.IsTrue(Math.Abs(quoteAmnt - quoteAmntFromGrid) < 0.02);
                }
                else
                {
                    Report.WriteFailure("Unable to compare the quotes");
                }
              
                Report.WriteLine("Verified quote amount in quote list page");
            }
        }

        private void VerifyItemDetailsInQuoteDetailsSection(string classification, string weight, string quantity)
        {
            //Verify Item details
            string package = Gettext(attributeName_classname, "rateList-pkg");
            Assert.AreEqual("Skids", package);
            Report.WriteLine("Verified item package value");

            //Classification
            string classificationFromGrid = Gettext(attributeName_classname, "rateList-classification");
            Assert.AreEqual(Convert.ToDecimal(classification), Convert.ToDecimal(classificationFromGrid));
            Report.WriteLine("Verified classification");

            //Weight
            string weightFromGrid = Gettext(attributeName_classname, "rateList-weight");
            Assert.AreEqual(weight, weightFromGrid);
            Report.WriteLine("Verified weight value");

            //Quantity
            string quantityFromGrid = Gettext(attributeName_classname, "rateList-qty");
            Assert.AreEqual(quantity, quantityFromGrid);
            Report.WriteLine("Verified Quantity value");
        }

        private void VerifyDatesInQuoteDetailsSection()
        {
            string submittedDate = Gettext(attributeName_classname, "createddate");
            Assert.AreEqual(DateTime.Today.ToString("MM/dd/yyyy"), submittedDate);
            Report.WriteLine("Verified the quote submitted date");

            DateTime pickupDate;
            if(DateTime.TryParse(Gettext(attributeName_id, QuoteList_LTL_PickupDate_Id), out pickupDate))
            {
                Assert.AreEqual(DateTime.Today.ToString("MM/dd/yy"), pickupDate.ToString("MM/dd/yy"));
                Report.WriteLine("Verified the quote pickup date");
            }
            else
            {
                Report.WriteFailure("Unable to verify pickup date");
            }

            DateTime dropOffDate;
            if (DateTime.TryParse(Gettext(attributeName_id, QuoteList_LTL_DropOffDate_Id), out dropOffDate))
            {
                Assert.AreEqual(DateTime.Today.AddDays(3).ToString("MM/dd/yy"), dropOffDate.ToString("MM/dd/yy"));
                Report.WriteLine("Verified the quote drop-off date");
            }
            else
            {
                Report.WriteFailure("Unable to verify drop-off date");
            }

        }

        private void VerifyAddressDetailsInQuoteDetailsSection(string originZipcode, string destinationZipcode)
        {
            //Origin
            string originAddress = Gettext(attributeName_classname, "rateList-originCityState");
            Assert.IsTrue(originAddress.Contains(originZipcode));
            Report.WriteLine("Verified the Origin address zipcode");

            //Destination
            string destinationAddress = Gettext(attributeName_classname, "rateList-destinationCityState");
            Assert.IsTrue(destinationAddress.Contains(destinationZipcode));
            Report.WriteLine("Verified the Origin address zipcode");
        }

        [Given(@"I Click on Create Quote for a Guaranteed Insured Carrier")]
        public void GivenIClickOnCreateQuoteForAGuaranteedInsuredCarrier()
        {
            if (IsElementPresent(attributeName_id, "no-results-save-quote", "No results Page"))
            {
                Report.WriteLine("No Carriers available");
                Click(attributeName_id, "no-results-save-quote");
            }
            else
            {
                GlobalVariables.webDriver.WaitForPageLoad();
                if (IsElementPresent(attributeName_id, "Grid-Rate-List-Large-Guranteed", "Guaranteed carrier table"))
                {
                    carrierName = Gettext(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-Guranteed']/tbody/tr[1]/td[1]/ul/li[1]");
                    quoteAmount = Gettext(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-Guranteed']/tbody/tr[1]/td[5]/ul[1]/li[1]");
                    Click(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-Guranteed']/tbody/tr[1]/td[5]/ul[2]/li/a");
                }
                else
                {
                    Report.WriteLine("No guaranteed carriers available");
                }
            }
        }

    }
}
