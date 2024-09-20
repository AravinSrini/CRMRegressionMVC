using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Tracking
{
    [Binding]
    public sealed class TrackingLandingPageSteps_Mobile : ObjectRepository
    {
        string WarningMessage_InvalidNumbers;
        [Then(@"I must navigate to the Tracking page and must see '(.*)', and not see '(.*)'")]
        public void ThenIMustNavigateToTheTrackingPageAndMustSeeAndNotSee(string Title, string SubTitle)
        {
            Report.WriteLine("Able to navigate to the Tracking page");
            Verifytext(attributeName_cssselector, TrackingpageTitle_css, Title);
            VerifyElementNotPresent(attributeName_cssselector, TrackingpageTitleDescription_css, SubTitle);
        }

        [Then(@"I must see the Track shipments By Number section '(.*)', '(.*)' and '(.*)' and search arrow button")]
        public void ThenIMustSeeTheTrackShipmentsByNumberSectionAndAndSearchArrowButton(string ReferenceNumberHeading, string ReferenceNumbersDescription, string Searchtextbox)
        {
            Report.WriteLine("Must see the Track By Reference Number section");
            Verifytext(attributeName_xpath, TrackbyReferenceheading_xpath, ReferenceNumberHeading);
            Verifytext(attributeName_cssselector, ReferenceNumbersDescription_css, ReferenceNumbersDescription);
            VerifyElementPresent(attributeName_id, Searchtextbox_id, Searchtextbox);
            string SeachBtnDefaulttext_UI = GetValue(attributeName_id, Searchtextbox_id, "placeholder");
            Assert.AreEqual(Searchtextbox, SeachBtnDefaulttext_UI);
        }

        [Then(@"I must not see the '(.*)' and '(.*)'")]
        public void ThenIMustNotSeeTheAnd(string DownloadBtn, string UploadBtn)
        {
            Report.WriteLine("Must not see the Track file by upload section");
            VerifyElementNotVisible(attributeName_id, DownloadinTrackingBtn_id, DownloadBtn);
            VerifyElementNotVisible(attributeName_xpath, UploadinTrackingBtn_xpath, UploadBtn);
        }

        [Then(@"I must navigate to the Tracking Details page and must see '(.*)', and not see'(.*)'")]
        public void ThenIMustNavigateToTheTrackingDetailsPageAndMustSeeAndNotSee(string Title, string SubTitle)
        {
            Report.WriteLine("Must navigate to the Tracking Details page");
            Verifytext(attributeName_cssselector, TrackingDetailsPageHeader_css, Title);
            VerifyElementNotVisible(attributeName_cssselector, TrackingDetailspageSubtitle_css, SubTitle);
        }

        [Then(@"I must see the '(.*)' button below to the Title description and also must not see the '(.*)' button")]
        public void ThenIMustSeeTheButtonBelowToTheTitleDescriptionAndAlsoMustNotSeeTheButton(string SearchShipments, string Export)
        {
            Report.WriteLine("Must see the SearchShipments button and Export button");
            VerifyElementPresent(attributeName_id, SearchShipmentsBtn_id, SearchShipments);
            string Actualtext = GetAttribute(attributeName_id, SearchShipmentsBtn_id, "placeholder");
            Assert.AreEqual(SearchShipments, Actualtext);
            VerifyElementNotVisible(attributeName_id, ExportBtn_id, Export);
        }

        [Then(@"I must not see the filter by time and filter by status headers below to the search shipments button")]
        public void ThenIMustNotSeeTheFilterByTimeAndFilterByStatusHeadersBelowToTheSearchShipmentsButton()
        {
            Report.WriteLine("Must not see the filter by header below to the search shipments button");
            VerifyElementNotVisible(attributeName_cssselector, FilterbyTime_css, "FILTER BY");
            VerifyElementNotVisible(attributeName_cssselector, FilterbyStatus_css, "FILTER BY STATUS");
        }

        [Then(@"I must not see the pagination header in the Tracking Details page")]
        public void ThenIMustNotSeeThePaginationHeaderInTheTrackingDetailsPage()
        {
            Report.WriteLine("Must not see the pagination header in the Tracking Details page");
            VerifyElementNotVisible(attributeName_cssselector, PaginationHeader_css, "PaginationHeader");
        }

        [Then(@"I must see the Tracking Details Grid with headers '(.*)', '(.*)', and nust not see '(.*)', '(.*)', '(.*)', '(.*)' and '(.*)'")]
        public void ThenIMustSeeTheTrackingDetailsGridWithHeadersAndNustNotSeeAnd(string REF, string STATUS, string ETA, string LOCATION, string ORIGIN, string DESTINATION, string SERVICE)
        {
            Report.WriteLine("Must see the Tracking Details Grid with headers");
            WaitForElementNotPresent(attributeName_xpath, ETA_xpath, ETA);
            Verifytext(attributeName_xpath, REF_xpath, REF);
            Verifytext(attributeName_xpath, STATUS_xpath, STATUS);
            VerifyElementNotPresent(attributeName_xpath, ETA_xpath, ETA);
            VerifyElementNotPresent(attributeName_xpath, LOCATION_xpath, LOCATION);
            VerifyElementNotPresent(attributeName_xpath, ORIGIN_xpath, ORIGIN);
            VerifyElementNotPresent(attributeName_xpath, DESTINATION_xpath, DESTINATION);
            VerifyElementNotPresent(attributeName_xpath, SERVICE_xpath, SERVICE);
        }

        [Then(@"I must not see the pagination footer in the Tracking Details page")]
        public void ThenIMustNotSeeThePaginationFooterInTheTrackingDetailsPage()
        {
            Report.WriteLine("Must not see the pagination footer in the Tracking Details page");
            VerifyElementNotVisible(attributeName_cssselector, PaginationFooter_css, "PaginationFooter");
        }

        [Then(@"I must see all the tracking numbers in the Grid without info icon and with expand icon for each reference number")]
        public void ThenIMustSeeAllTheTrackingNumbersInTheGridWithoutInfoIconAndWithExpandIconForEachReferenceNumber()
        {
            Report.WriteLine("Must see all the tracking numbers in the Grid with info icon and expand icon for each reference number");
            List<string> ReferenceNumbers = getIndividiualRows(attributeName_xpath, Referencenumbers_xpath, attributeName_tagname, "td").OrderBy(x => x).ToList();

            Report.WriteLine("Must see the info icon in tracking details page");
            VerifyElementNotVisible(attributeName_xpath, InfoicontrackingDetails_xpath, "InfoIcon");

            Report.WriteLine("Must see the expand icon in the tracking details page");
            VerifyElementPresent(attributeName_xpath, ToogleExpandicon_xpath, "NeedtoExpand");
        }

        [Then(@"I must see the Information is expanded by default when only one shipment is tracked in '(.*)' section in mobile")]
        public void ThenIMustSeeTheInformationIsExpandedByDefaultWhenOnlyOneShipmentIsTrackedInSectionInMobile(string TrackingDetails)
        {
            Report.WriteLine("Must Navigate To The Tracking Page And Must see the icon expanded by default");
            WaitForElementVisible(attributeName_xpath, ToogleExpandiconMobile_xpath, "AlreadyExpanded");
            VerifyElementVisible(attributeName_xpath, ToogleExpandiconMobile_xpath, "AlreadyExpanded");
            Verifytext(attributeName_xpath, TrackingDetailsHeaderforSinglerefNo_xpath, TrackingDetails);
            Verifytext(attributeName_xpath, DefaultMap_xpath, "Map");
        }

        [Then(@"I must not see information icon and must see expand icon for each reference number")]
        public void ThenIMustNotSeeInformationIconAndMustSeeExpandIconForEachReferenceNumber()
        {
            Report.WriteLine("Must see the info icon in tracking details page");
            VerifyElementNotPresent(attributeName_xpath, InfoicontrackingDetails_xpath, "InfoIcon");

            Report.WriteLine("Must see the expand icon in the tracking details page");
            VerifyElementPresent(attributeName_xpath, ToogleExpandiconMobile_xpath, "NeedtoExpand");
        }
    }
}
