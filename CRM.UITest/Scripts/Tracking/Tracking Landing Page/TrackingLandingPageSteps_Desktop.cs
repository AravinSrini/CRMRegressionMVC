using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Tracking
{
    [Binding]
    public sealed class TrackingLandingPageSteps_Desktop : ObjectRepository
    {
        string WarningMessage_InvalidNumbers;

        [When(@"I Click on the Tracking icon in the navigation menu")]
        public void WhenIClickOnTheTrackingIconInTheNavigationMenu()
        {
            Report.WriteLine("Click on the Tracking icon available in the menu");
            WaitForElementVisible(attributeName_cssselector, TrackingIcon_css, "Tracking");
            WaitForElementNotVisible(attributeName_id, LoadingSymbol_id, "loading symbol");
            Click(attributeName_cssselector, TrackingIcon_css);
        }

        [Then(@"I must navigate to the Tracking page and must see '(.*)', '(.*)'")]
        public void ThenIMustNavigateToTheTrackingPageAndMustSee(string Title, string SubTitle)
        {
            Report.WriteLine("Able to navigate to the Tracking page");
            Verifytext(attributeName_cssselector, TrackingLandingpageTitle_css, Title);
            Verifytext(attributeName_cssselector, TrackingpageLandingTitleDescription_css, SubTitle);
        }

        [Then(@"I must see the Track By Reference Number section '(.*)', '(.*)' and '(.*)' and search arrow button")]
        public void ThenIMustSeeTheTrackByReferenceNumberSessionAndAndSearchArrowButton(string ReferenceNumberHeading, string ReferenceNumbersDescription, string Searchtextbox)
        {
            Report.WriteLine("Must see the Track By Reference Number section");
            Verifytext(attributeName_xpath, TrackbyReferenceheading_xpath, ReferenceNumberHeading);
            Verifytext(attributeName_cssselector, ReferenceNumbersDescription_css, ReferenceNumbersDescription);
            VerifyElementPresent(attributeName_id, Searchtextbox_id, Searchtextbox);
            string SeachBtnDefaulttext_UI = GetValue(attributeName_id, Searchtextbox_id, "placeholder");
            Assert.AreEqual(Searchtextbox, SeachBtnDefaulttext_UI);
        }

        [Then(@"I must see the Track file by upload section '(.*)' , '(.*)' , '(.*)' and '(.*)'")]
        public void ThenIMustSeeTheTrackFileByUploadSectionAnd(string FileUploadHeading, string ShipmentsDescription, string DownloadBtn, string UploadBtn)
        {
            Report.WriteLine("Must see the Track file by upload section");
            Verifytext(attributeName_xpath, FileUploadHeading_xpath, FileUploadHeading);
            Verifytext(attributeName_xpath, ShipmentsDescription_xpath, ShipmentsDescription);
            Verifytext(attributeName_id, DownloadinTrackingBtn_id, DownloadBtn);
            Verifytext(attributeName_xpath, UploadinTrackingBtn_xpath, UploadBtn);
        }

        [When(@"I click on the search button in the Tracking page")]
        public void WhenIClickOnTheSearchButtonInTheTrackingPage()
        {
            Report.WriteLine("click on the search button in the Tracking page");
            Click(attributeName_xpath, searchbtnTrackingLandingpage_xpath);
        }

        [Then(@"I must see the '(.*)' in the Error pop up")]
        public void ThenIMustSeeTheInTheErrorPopUp(string errormessage)
        {
            Report.WriteLine("I must see the error message saying that no data found for reference number");
            WaitForElementVisibleVerifyTextContains(attributeName_cssselector, NoreferenceErrorpopup_css, "Error", "Pop up");
            Verifytext(attributeName_cssselector, NoreferenceErrorpopup_css, "Error");
            Verifytext(attributeName_cssselector, NoreferenceErrormessage_css, errormessage);
            Verifytext(attributeName_xpath, CloseBtnInNoreferenceErrorpopup_xpath, "Close");
        }

        [When(@"I enter the '(.*)' in the search box")]
        public void WhenIEnterTheInTheSearchBox(string ValidReferenceNumber)
        {
            Report.WriteLine("Enter valid reference number in the search box");
            SendKeys(attributeName_id, Searchtextbox_id, ValidReferenceNumber);
        }

        [Then(@"I must see the Information is expanded by default when only one shipment is tracked in '(.*)' section")]
        public void ThenIMustSeeTheInformationIsExpandedByDefaultWhenOnlyOneShipmentIsTrackedInSection(string TrackingDetails)
        {
            Report.WriteLine("Must Navigate To The Tracking Page And Must see the icon expanded by default");
            WaitForElementVisible(attributeName_xpath, ToogleExpandicon_xpath, "AlreadyExpanded");
            VerifyElementVisible(attributeName_xpath, ToogleExpandicon_xpath, "AlreadyExpanded");
            Verifytext(attributeName_xpath, TrackingDetailsHeaderforSingleRefNo_xpath, TrackingDetails);
            Verifytext(attributeName_xpath, Map_xpath, "Map");
        }

        [Then(@"I must see the information headers '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)' and '(.*)' at top of the page")]
        public void ThenIMustSeeTheInformationHeadersAndAtTopOfThePage(string REF, string STATUS, string ETA, string LOCATION, string ORIGIN, string DESTINATION, string SERVICE)
        {
            Report.WriteLine("Must see the tracking information headers");
            Verifytext(attributeName_xpath, REF_xpath, REF);
            Verifytext(attributeName_xpath, STATUS_xpath, STATUS);
            Verifytext(attributeName_xpath, ETA_xpath, ETA);
            Verifytext(attributeName_xpath, LOCATION_xpath, LOCATION);
            Verifytext(attributeName_xpath, ORIGIN_xpath, ORIGIN);
            Verifytext(attributeName_xpath, DESTINATION_xpath, DESTINATION);
            Verifytext(attributeName_xpath, SERVICE_xpath, SERVICE);
        }

        [Then(@"I must see the '(.*)' below to the REF number column")]
        public void ThenIMustSeeTheBelowToTheREFNumberColumn(string ValidReferenceNumber)
        {
            Report.WriteLine("Must see the entered reference number below to the REF number column");
            string ReferenceNoDetails_UI = Gettext(attributeName_xpath, ReferencenumberUnderREF_xpath);
            string[] ActaulReferenceNoDetails_UI = ReferenceNoDetails_UI.Split(' ');
            Assert.AreEqual(ValidReferenceNumber, ActaulReferenceNoDetails_UI[0]);
        }

        [Then(@"I must navigate to the Tracking Details page and must see '(.*)', '(.*)'")]
        public void ThenIMustNavigateToTheTrackingDetailsPageAndMustSee(string Title, string SubTitle)
        {
            Report.WriteLine("Must navigate to the Tracking Details page");
            Verifytext(attributeName_cssselector, TrackingDetailsPageHeader_css, Title);
            Verifytext(attributeName_cssselector, TrackingDetailspageSubtitle_css, SubTitle);
        }

        [Then(@"I must see the '(.*)' button in the top right corner")]
        public void ThenIMustSeeTheButtonInTheTopRightCorner(string NewSearch)
        {
            Report.WriteLine("Must see the Newsearch button in the details page");
            Verifytext(attributeName_id, NewSearchBtn_id, NewSearch);
        }

        [Then(@"I must see the '(.*)' button below to the Title description and also must see the '(.*)' button")]
        public void ThenIMustSeeTheButtonBelowToTheTitleDescriptionAndAlsoMustSeeTheButton(string SearchShipments, string Export)
        {
            Report.WriteLine("Must see the SearchShipments button and Export button");
            VerifyElementPresent(attributeName_id, SearchShipmentsBtn_id, SearchShipments);
            string Actualtext = GetAttribute(attributeName_id, SearchShipmentsBtn_id, "placeholder");
            Assert.AreEqual(SearchShipments, Actualtext);
            Verifytext(attributeName_id, ExportBtn_id, Export);
        }

        [Then(@"I must see the filter by time and filter by status headers below to the search shipments button")]
        public void ThenIMustSeeTheFilterByTimeAndFilterByStatusHeadersBelowToTheSearchShipmentsButton()
        {
            Report.WriteLine("Must see the filter by header below to the search shipments button");
            VerifyElementVisible(attributeName_cssselector, FilterbyTime_css, "FILTER BY");
            VerifyElementVisible(attributeName_cssselector, FilterbyStatus_css, "FILTER BY STATUS");
        }

        [Then(@"I must see the pagination header in the Tracking Details page")]
        public void ThenIMustSeeThePaginationHeaderInTheTrackingDetailsPage()
        {
            Report.WriteLine("Must see the pagination header in the Tracking Details page");
            VerifyElementPresent(attributeName_cssselector, PaginationHeader_css, "PaginationHeader");
        }

        [Then(@"I must see the Tracking Details Grid with headers '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)' and '(.*)'")]
        public void ThenIMustSeeTheTrackingDetailsGridWithHeadersAnd(string REF, string STATUS, string ETA, string LOCATION, string ORIGIN, string DESTINATION, string SERVICE)
        {
            Report.WriteLine("Must see the Tracking Details Grid with headers");
            Verifytext(attributeName_xpath, REF_xpath, REF);
            Verifytext(attributeName_xpath, STATUS_xpath, STATUS);
            Verifytext(attributeName_xpath, ETA_xpath, ETA);
            Verifytext(attributeName_xpath, LOCATION_xpath, LOCATION);
            Verifytext(attributeName_xpath, ORIGIN_xpath, ORIGIN);
            Verifytext(attributeName_xpath, DESTINATION_xpath, DESTINATION);
            Verifytext(attributeName_xpath, SERVICE_xpath, SERVICE);
        }

        [Then(@"I must see the pagination footer in the Tracking Details page")]
        public void ThenIMustSeeThePaginationFooterInTheTrackingDetailsPage()
        {
            Report.WriteLine("Must see the pagination footer in the Tracking Details page");
            VerifyElementPresent(attributeName_cssselector, PaginationFooter_css, "PaginationFooter");
        }

        [Then(@"I must see all the tracking numbers '(.*)' in the Grid")]
        public void ThenIMustSeeAllTheTrackingNumbersInTheGrid(string MultipleValidReferenceNumbers)
        {
            Report.WriteLine("Must see all the tracking numbers in the Grid with info icon and expand icon for each reference number");

            List<string> ExpectedMultipleReferenceNumbers = new List<string>(MultipleValidReferenceNumbers.Split(','));
            List<string> ActualReferenceNumbers_UI = IndividualColumnData(Referencenumbers_xpath);

            int j = 0;
            foreach (string refeencenumber in ActualReferenceNumbers_UI)
            {
                string[] ReferenceNumber_UI = refeencenumber.Split(' ');
                string ActualReferenceNumber_UI = ReferenceNumber_UI[0];
                if (ExpectedMultipleReferenceNumbers.Contains(ActualReferenceNumber_UI))
                {
                    Assert.AreEqual(ActualReferenceNumber_UI, ExpectedMultipleReferenceNumbers[j]);
                    ++j;
                }
            }
        }

        //[Then(@"I must see all the tracking numbers '(.*)' in the Grid with info icon and expand icon for each reference number")]
        //public void ThenIMustSeeAllTheTrackingNumbersInTheGridWithInfoIconAndExpandIconForEachReferenceNumber(string MultipleValidReferenceNumbers)
        //{
        //    Report.WriteLine("Must see all the tracking numbers in the Grid with info icon and expand icon for each reference number");
            
        //    List<string> ExpectedMultipleReferenceNumbers = new List<string>(MultipleValidReferenceNumbers.Split(','));
        //    List<string> ActualReferenceNumbers_UI = IndividualColumnData(Referencenumbers_xpath);

        //        int j = 0;
        //        foreach (string refeencenumber in ActualReferenceNumbers_UI)
        //        {
        //            string[] ReferenceNumber_UI = refeencenumber.Split(' ');
        //            string ActualReferenceNumber_UI = ReferenceNumber_UI[0];
        //            if (ExpectedMultipleReferenceNumbers.Contains(ActualReferenceNumber_UI))
        //            {
        //                Assert.AreEqual(ActualReferenceNumber_UI, ExpectedMultipleReferenceNumbers[j]);
        //                ++j;
        //            }
        //        }
        //}

        [Then(@"I must see the only '(.*)' commas in search field of Tracking Laning page")]
        public void ThenIMustSeeTheOnlyCommasInSearchFieldOfTrackingLaningPage(int nine)
        {
            Report.WriteLine("Must see only 9 commas in search field");
            var Number = GetValue(attributeName_id, Searchtextbox_id, "value").Count();
            Assert.AreEqual(nine, Number);
        }

        [When(@"I enter the multi'(.*)' in the search box")]
        public void WhenIEnterTheMultiInTheSearchBox(string MultipleValidReferenceNumbers)
        {
            Report.WriteLine(" Enter multi tracking numbers in the search field");
            SendKeys(attributeName_id, Searchtextbox_id, MultipleValidReferenceNumbers);
        }

        [When(@"I enter the more than ten'(.*)' in the search box")]
        public void WhenIEnterTheMoreThanTenInTheSearchBox(string MorethanTenReferenceNumbers)
        {
            Report.WriteLine(" Enter more than 10 tracking numbers in the search field");
            SendKeys(attributeName_id, Searchtextbox_id, MorethanTenReferenceNumbers);
        }

        [Then(@"I must see the '(.*)' saying No data found for entered reference numbers")]
        public void ThenIMustSeeTheSayingNoDataFoundForEnteredReferenceNumbers(string errormessage)
        {
            Report.WriteLine("I must see the error message when enter multiple invalid reference numbers");
            Verifytext(attributeName_cssselector, errormessagemultiInvalidRefNumError_css, "Error");
            Verifytext(attributeName_cssselector, errormessagemultiInvalidRefNum_css, errormessage);
            Verifytext(attributeName_xpath, errormessagemultiInvalidRefNumClose_xpath, "Close");
        }

        [Then(@"I must see the '(.*)' saying Tracking details were not found for the following tracking numbers")]
        public void ThenIMustSeeTheSayingTrackingDetailsWereNotFoundForTheFollowingTrackingNumbers(string warningmessage)
        {
            Report.WriteLine("I must see the warning message when enter multiple invalid reference numbers");
            Verifytext(attributeName_cssselector, warningmsgmultiInvalidRefNumError_css, "Warning");

            string WarningMessage_InvalidNumbers = Gettext(attributeName_cssselector, warningmsgmultiInvalidRefNum_css);
            List<string> Warningmessage = new List<string>(WarningMessage_InvalidNumbers.Split('\r'));
            Assert.AreEqual(warningmessage, Warningmessage[0]);

            Verifytext(attributeName_xpath, warningmsgmultiInvalidRefNumClose_xpath, "Close");
        }

        [Then(@"I click on close button in the warning pop up")]
        public void ThenIClickOnCloseButtonInTheWarningPopUp()
        {
            Report.WriteLine("click on close button in the warning pop up");
            Click(attributeName_xpath, warningmsgmultiInvalidRefNumClose_xpath);
        }

        [When(@"I enter valid and invalid tracking numbers '(.*)' in the search field")]
        public void WhenIEnterValidAndInvalidTrackingNumbersInTheSearchField(string ValidandInvalidReferenceNumbers)
        {
            Report.WriteLine(" Enter valid and invalid tracking numbers in the search field");
            SendKeys(attributeName_id, Searchtextbox_id, ValidandInvalidReferenceNumbers);
        }

        [When(@"I enter invalid '(.*)' in the search field")]
        public void WhenIEnterInvalidInTheSearchField(string MultipleInvalidTrackingNumbers)
        {
            Report.WriteLine(" Enter invalid tracking numbers in the search field");
            SendKeys(attributeName_id, Searchtextbox_id, MultipleInvalidTrackingNumbers);
        }

        [Then(@"I must see the list of all the tracking numbers that do not exist in the pop up '(.*)'")]
        public void ThenIMustSeeTheListOfAllTheTrackingNumbersThatDoNotExistInThePopUp(string ValidandInvalidReferenceNumbers)
        {
            Report.WriteLine("Must see the list of all the tracking numbers that do not exists in the pop up");
            WarningMessage_InvalidNumbers = Gettext(attributeName_cssselector, warningmsgmultiInvalidRefNum_css);
            List<string> ActualInvalidNumbers_UI = new List<string>(WarningMessage_InvalidNumbers.Split('\r'));
            var Actuallist = new List<string>();
            for (int i = 2; i< ActualInvalidNumbers_UI.Count(); i++)
            {
                Actuallist.Add(string.Format(ActualInvalidNumbers_UI[i]).Substring(1));
            }

            List<string> EnteredReferenceNumbers = new List<string>(ValidandInvalidReferenceNumbers.Split(','));

            foreach (var ActualInvalidrefeencenumber in Actuallist)
            {
                if (EnteredReferenceNumbers.Contains(ActualInvalidrefeencenumber))
                {
                    Console.WriteLine(ActualInvalidrefeencenumber +"is displayed in error pop up");
                }
                else
                {
                    Console.WriteLine(ActualInvalidrefeencenumber + "is not  displayed in error pop up");
                }
            }
        }

        [Then(@"I must see all the valid tracking numbers '(.*)' in the Grid")]
        public void ThenIMustSeeAllTheValidTrackingNumbersInTheGrid(string ValidandInvalidReferenceNumbers)
        {
            Report.WriteLine("Must see all the tracking numbers in the Grid with info icon and expand icon for each reference number");

            List<string> ExpectedMultipleReferenceNumbers = new List<string>(ValidandInvalidReferenceNumbers.Split(','));
            List<string> ActualReferenceNumbers_UI = IndividualColumnData(Referencenumbers_xpath);

            List<string> ActualInvalidNumbers_UI = new List<string>(WarningMessage_InvalidNumbers.Split('\r'));
            var Actuallist = new List<string>();
            for (int i = 2; i < ActualInvalidNumbers_UI.Count(); i++)
            {
                Actuallist.Add(string.Format(ActualInvalidNumbers_UI[i]).Substring(1));
            }

            int j = Actuallist.Count();
            foreach (string refeencenumber in ActualReferenceNumbers_UI)
            {
                string[] ReferenceNumber_UI = refeencenumber.Split(' ');
                string ActualReferenceNumber_UI = ReferenceNumber_UI[0];
                if (ExpectedMultipleReferenceNumbers.Contains(ActualReferenceNumber_UI))
                {
                    Assert.AreEqual(ActualReferenceNumber_UI, ExpectedMultipleReferenceNumbers[j]);
                    ++j;
                }
            }
        }

        [Then(@"I must see information icon and expand icon for each reference number")]
        public void ThenIMustSeeInformationIconAndExpandIconForEachReferenceNumber()
        {
            Report.WriteLine("Must see the info icon in tracking details page");
            VerifyElementPresent(attributeName_xpath, InfoicontrackingDetails_xpath, "InfoIcon");

            Report.WriteLine("Must see the expand icon in the tracking details page");
            VerifyElementPresent(attributeName_xpath, ToogleExpandicon_xpath, "NeedtoExpand");
        }
    }
}
