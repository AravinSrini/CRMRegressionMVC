using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Tracking
{
    [Binding]
    public sealed class TrackingDetailsPageForMobile_steps : ObjectRepository
    {
       
        [When(@"I have entered valid tracking numbers in login page(.*)")]
        public void WhenIHaveEnteredValidTrackingNumbersInLoginPage(string TrackingNumber)
        {

            scrollpagedown();
            scrollpagedown();
            SendKeys(attributeName_id, TrackByReference_textbox_Id, TrackingNumber);
            Click(attributeName_xpath, TrackByReference_Arrow_Xpath);
        }


        [Given(@"I clicked on Tracking Module from hamburger menu icon")]
        public void GivenIClickedOnTrackingModuleFromHamburgerMenuIcon()
        {

            WaitForElementNotVisible(attributeName_id, LoadingSymbol_id, "loading symbol");
            WaitForElementNotVisible(attributeName_id, LoadingSymbol_id, "loading symbol");
            WaitForElementNotVisible(attributeName_id, LoadingSymbol_id, "loading symbol");
            WaitForElementVisible(attributeName_xpath, MenuExpandIcon_Mobile_Xpath, "Menu Icon");
            WaitForElementVisible(attributeName_xpath, MenuExpandIcon_Mobile_Xpath, "Menu Icon");
            Click(attributeName_xpath, MenuExpandIcon_Mobile_Xpath);
            WaitForElementNotVisible(attributeName_id, LoadingSymbol_id, "loading symbol");
            WaitForElementNotVisible(attributeName_id, LoadingSymbol_id, "loading symbol");
            Report.WriteLine("Click on Tracking module");
            WaitForElementVisible(attributeName_id, Tracking_Icon_Id, "Tracking Icon");
            Click(attributeName_id, Tracking_Icon_Id);


        }

        [Then(@"I will be able to see Tracking Deatils Page Header (.*)")]
        public void ThenIWillBeAbleToSeeTrackingDeatilsPageHeader(string TrackingTitleText)
        {

            Report.WriteLine("Verifying Tracking Header");
            WaitForElementVisible(attributeName_xpath, TrackingPage_Header_xpath, "TrackingHeader");
            VerifyElementPresent(attributeName_xpath, TrackingPage_Header_xpath, TrackingTitleText);
        }

        [Then(@"I will be able to see  Reference and status column in grid (.*), (.*)")]
        public void ThenIWillBeAbleToSeeReferenceAndStatusColumnInGrid(string RefText, string StatusText)
        {

            Report.WriteLine("Verifying RefText Grid Header");
            VerifyElementPresent(attributeName_xpath, Ref_Text_Xpath, RefText);
            string RefText_UI = Gettext(attributeName_xpath, Ref_Text_Xpath);
            Assert.AreEqual(RefText_UI, RefText);
            Report.WriteLine("Verifying StatusText Grid Header");
            VerifyElementPresent(attributeName_xpath, Status_Text_Xpath, StatusText);
            string StatusText_UI = Gettext(attributeName_xpath, Status_Text_Xpath);
            Assert.AreEqual(StatusText_UI, StatusText);
        }

        [Then(@"I will not be able to see export and print button")]
        public void ThenIWillNotBeAbleToSeeExportAndPrintButton()
        {
            scrollpagedown();
            scrollpagedown();
            VerifyElementNotPresent(attributeName_xpath, PrintIcon_Xpath, "Print Icon");
            Report.WriteLine("Verifying Export icon not present");
            VerifyElementNotPresent(attributeName_xpath, TrackingDetailsSection_ExportIcon_Xpath, "Export Icon");

        }

        [Then(@"I will not be able to see more information icon")]
        public void ThenIWillNotBeAbleToSeeMoreInformationIcon()
        {
            Report.WriteLine("Verifying More information icon not present");
            VerifyElementNotPresent(attributeName_xpath, MoreInformationIcon_Xpath, "More information icon");
        }

        [Then(@"I will not be able to see Filter By section")]
        public void ThenIWillNotBeAbleToSeeFilterBySection()
        {
            Report.WriteLine("Verifying FilterBy Text Not Present");
            VerifyElementNotVisible(attributeName_xpath, FilterBy_Text_Xpath, "FilterBy Text");
            Report.WriteLine("Verifying ScheduledToDeliver Text Not Present");
            VerifyElementNotVisible(attributeName_xpath, ScheduledToDeliver_Text_Xpath, "ScheduledToDeliver Text");
            Report.WriteLine("Verifying Between Text Not Present");
            VerifyElementNotVisible(attributeName_xpath, Between_Text_Xpath, "Between Text");
            Report.WriteLine("Verifying StartDate Not Present");
            VerifyElementNotVisible(attributeName_id, StartDate_Text_Id, "StartDate");
            Report.WriteLine("Verifying EndDate Not Present");
            VerifyElementNotVisible(attributeName_id, EndDate_Text_Id, "EndDate");
            Report.WriteLine("Verifying And Text Not Present");
            VerifyElementNotVisible(attributeName_xpath, And_Text_Xpath, "And Text");
            Report.WriteLine("Verifying FilterByStatus resentText Not Present");
            VerifyElementNotVisible(attributeName_xpath, FilterByStatus_Text_Xpath, "FilterByStatus Text");
            Report.WriteLine("Verifying OneTime Check Box Not Present");
            VerifyElementNotVisible(attributeName_xpath, OneTime_Text_Xpath, "OneTime Check Box");
            Report.WriteLine("Verifying ExceptionsDelays Check Box Not Present");
            VerifyElementNotVisible(attributeName_xpath, ExceptionsDelays_Text_Xpath, "ExceptionsDelays Check Box");
        }

        [Then(@"I will not be able to see arrow button next to Search shipments text field")]
        public void ThenIWillNotBeAbleToSeeArrowButtonNextToSearchShipmentsTextField()
        {
            Report.WriteLine("Verifying Search Arrow not present");
            VerifyElementNotVisible(attributeName_id, SearchShipment_Arrow_Id, "SearchShipment Arrow");
        }

        [Then(@"I will be able to see Tracking Details Arrow button on shipment record")]
        public void ThenIWillBeAbleToSeeTrackingDetailsArrowButtonOnShipmentRecord()
        {

            Report.WriteLine("Verifying Tracking Details Arrow");
            int Statuscount = GetCount(attributeName_xpath, StatusGridValues_Xpath);
            int TrackingDetails_Count = GetCount(attributeName_xpath, TrackingDetailsOptionsMobile_Xpath);
            if (Statuscount == TrackingDetails_Count)
            {
                Console.WriteLine("Tracking details Arrow Button is found for each shipment  record");
            }

            else
            {
                throw new Exception("Tracking Details Arrow Button not appears for each shipment record");
            }

        }

        [Then(@"I am able to search any data through Search Textbox (.*),(.*)")]
        public void ThenIAmAbleToSearchAnyDataThroughSearchTextbox(string SearchCriteria, string TestData)
        {
            SendKeys(attributeName_id, SearchShipment_Textbox_Id, TestData);

            switch (SearchCriteria)
            {
                case "RefNumber":
                    {
                        int FirstRefNumber = 1;
                        int IncrementingRefNumber = 1;
                        int count = GetCount(attributeName_xpath, "//*[@id='TrackingDetailGrid']/tbody/tr/td[1]");
                        for (int i = 1; i <= count - 1; i++)
                        {
                            if (i == 1)
                            {
                                Click(attributeName_xpath, ".//*[@id='TrackingDetailGrid']/tbody/tr[1]/td[2]/span");
                                string text = Gettext(attributeName_xpath, "//*[@id='TrackingDetailGrid']/tbody/tr[" + FirstRefNumber + "]/td[1]");
                                if (text.Contains(TestData))
                                {
                                    Report.WriteLine("Filtered results contains the entered data");
                                }
                                else
                                {
                                    Report.WriteLine("Filtered results does not contain the entered data");
                                    Assert.IsTrue(false);
                                }
                                FirstRefNumber += 2;
                                IncrementingRefNumber += 2;
                            }
                            else if (i >= 2)
                            {
                                string text = Gettext(attributeName_xpath, "//*[@id='TrackingDetailGrid']/tbody/tr[" + IncrementingRefNumber + "]/td[1]");
                                if (text.Contains(TestData))
                                {
                                    Report.WriteLine("Filtered results contains the entered data");
                                }
                                else
                                {
                                    Report.WriteLine("Filtered results does not contain the entered data");
                                    Assert.IsTrue(false);
                                }
                                FirstRefNumber += 2;
                                IncrementingRefNumber += 2;
                            }
                        }
                        break;
                    }



                case "Status":
                    {
                        int FirstStatus = 1;
                        int IncrementingStatus = 1;
                        int count = GetCount(attributeName_xpath, "//*[@id='TrackingDetailGrid']/tbody/tr/td[2]");
                        for (int i = 1; i <= count; i++)
                        {
                            if (i == 1)
                            {
                                Click(attributeName_xpath, ".//*[@id='TrackingDetailGrid']/tbody/tr[1]/td[2]/span");
                                string text = Gettext(attributeName_xpath, "//*[@id='TrackingDetailGrid']/tbody/tr[" + FirstStatus + "]/td[2]");//.//*[@id='TrackingDetailGrid']/tbody/tr[" + ct1 + "]/td/table/tbody/tr[1]/td/div/div[2]
                                if (text.Contains(TestData))
                                {
                                    Report.WriteLine("Filtered results contains the entered data");
                                }
                                else
                                {
                                    Report.WriteLine("Filtered results does not contain the entered data");
                                    Assert.IsTrue(false);
                                }
                                FirstStatus += 2;
                                IncrementingStatus += 2;
                            }
                            else if (i >= 2)
                            {
                                string text = Gettext(attributeName_xpath, "//*[@id='TrackingDetailGrid']/tbody/tr[" + IncrementingStatus + "]/td[2]");
                                if (text.Contains(TestData))
                                {
                                    Report.WriteLine("Filtered results contains the entered data");
                                }
                                else
                                {
                                    Report.WriteLine("Filtered results does not contain the entered data");
                                    Assert.IsTrue(false);
                                }
                                FirstStatus += 2;
                                IncrementingStatus += 2;
                            }
                        }
                        break;
                    }



                case "ETA":
                    {
                        int FirstETA = 1;
                        int IncrementingETA = 2;
                        int count = GetCount(attributeName_xpath, "//*[@id='TrackingDetailGrid']/tbody/tr/td[2]");
                        for (int i = 1; i <= count; i++)
                        {
                            if (i == 1)
                            {
                                Click(attributeName_xpath, ".//*[@id='TrackingDetailGrid']/tbody/tr[1]/td[2]/span");
                                MoveToElementClick(attributeName_xpath, ".//*[@id='TrackingDetailGrid']/tbody/tr[" + FirstETA + "]/td[3]");
                                string text = Gettext(attributeName_xpath, ".//*[@id='TrackingDetailGrid']/tbody/tr[" + IncrementingETA + "]/td/table/tbody/tr[1]/td/div/div[2]");
                                if (text.Contains(TestData))
                                {
                                    Report.WriteLine("Filtered results contains the entered data");
                                }
                                else
                                {
                                    Report.WriteLine("Filtered results does not contain the entered data");
                                    Assert.IsTrue(false);
                                }
                                MoveToElementClick(attributeName_xpath, ".//*[@id='TrackingDetailGrid']/tbody/tr[" + FirstETA + "]/td[3]");
                                FirstETA += 2;
                                IncrementingETA += 2;
                            }
                            else if (i >= 2)
                            {
                                MoveToElementClick(attributeName_xpath, ".//*[@id='TrackingDetailGrid']/tbody/tr[" + FirstETA + "]/td[3]");
                                string text = Gettext(attributeName_xpath, ".//*[@id='TrackingDetailGrid']/tbody/tr[" + IncrementingETA + "]/td/table/tbody/tr[2]/td/div/div[2]");
                                if (text.Contains(TestData))
                                {
                                    Report.WriteLine("Filtered results contains the entered data");
                                }
                                else
                                {
                                    Report.WriteLine("Filtered results does not contain the entered data");
                                }
                                MoveToElementClick(attributeName_xpath, ".//*[@id='TrackingDetailGrid']/tbody/tr[" + FirstETA + "]/td[3]");
                                FirstETA += 2;
                                IncrementingETA += 2;
                            }
                        }
                        break;
                    }


                case "Location":
                    {
                        int FirstLocation = 1;
                        int IncrementingLocation = 2;
                        int count = GetCount(attributeName_xpath, "//*[@id='TrackingDetailGrid']/tbody/tr/td[2]");
                        for (int i = 1; i <= count; i++)
                        {
                            if (i == 1)
                            {
                                Click(attributeName_xpath, ".//*[@id='TrackingDetailGrid']/tbody/tr[1]/td[2]/span");
                                MoveToElementClick(attributeName_xpath, ".//*[@id='TrackingDetailGrid']/tbody/tr[" + FirstLocation + "]/td[3]");
                                string text = Gettext(attributeName_xpath, ".//*[@id='TrackingDetailGrid']/tbody/tr[" + IncrementingLocation + "]/td/table/tbody/tr[2]/td/div/div[2]");
                                if (text.Contains(TestData))
                                {
                                    Report.WriteLine("Filtered results contains the entered data");
                                }
                                else
                                {
                                    Report.WriteLine("Filtered results does not contain the entered data");
                                    Assert.IsTrue(false);
                                }
                                MoveToElementClick(attributeName_xpath, ".//*[@id='TrackingDetailGrid']/tbody/tr[" + FirstLocation + "]/td[3]");
                                FirstLocation += 2;
                                IncrementingLocation += 2;
                            }
                            else if (i >= 2)

                            {
                                MoveToElementClick(attributeName_xpath, ".//*[@id='TrackingDetailGrid']/tbody/tr[" + FirstLocation + "]/td[3]");
                                string text = Gettext(attributeName_xpath, ".//*[@id='TrackingDetailGrid']/tbody/tr[" + IncrementingLocation + "]/td/table/tbody/tr[2]/td/div/div[2]");
                                if (text.Contains(TestData))
                                {
                                    Report.WriteLine("Filtered results contains the entered data");
                                }
                                else
                                {
                                    Report.WriteLine("Filtered results does not contain the entered data");
                                }
                                MoveToElementClick(attributeName_xpath, ".//*[@id='TrackingDetailGrid']/tbody/tr[" + FirstLocation + "]/td[3]");
                                FirstLocation += 2;
                                IncrementingLocation += 2;
                            }
                        }
                        break;
                    }


                case "Service":
                    {
                        int FirstService = 1;
                        int IncrementingService = 2;
                        int count = GetCount(attributeName_xpath, "//*[@id='TrackingDetailGrid']/tbody/tr/td[2]");
                        for (int i = 1; i <= count; i++)
                        {
                            if (i == 1)
                            {
                                Click(attributeName_xpath, ".//*[@id='TrackingDetailGrid']/tbody/tr[1]/td[2]/span");
                                MoveToElementClick(attributeName_xpath, ".//*[@id='TrackingDetailGrid']/tbody/tr[" + FirstService + "]/td[3]");
                                string text = Gettext(attributeName_xpath, ".//*[@id='TrackingDetailGrid']/tbody/tr[" + IncrementingService + "]/td/table/tbody/tr[5]/td/div/div[2]");
                                if (text.Contains(TestData))
                                {
                                    Report.WriteLine("Filtered results contains the entered data");
                                }
                                else
                                {
                                    Report.WriteLine("Filtered results does not contain the entered data");
                                    Assert.IsTrue(false);
                                }
                                MoveToElementClick(attributeName_xpath, ".//*[@id='TrackingDetailGrid']/tbody/tr[" + FirstService + "]/td[3]");
                                FirstService += 2;
                                IncrementingService += 2;
                            }

                            else if (i >= 2)
                            {
                                MoveToElementClick(attributeName_xpath, ".//*[@id='TrackingDetailGrid']/tbody/tr[" + FirstService + "]/td[3]");
                                string text = Gettext(attributeName_xpath, ".//*[@id='TrackingDetailGrid']/tbody/tr[" + IncrementingService + "]/td/table/tbody/tr[5]/td/div/div[2]");
                                if (text.Contains(TestData))
                                {
                                    Report.WriteLine("Filtered results contains the entered data");
                                }
                                else
                                {
                                    Report.WriteLine("Filtered results does not contain the entered data");
                                    Assert.IsTrue(false);
                                }

                                MoveToElementClick(attributeName_xpath, ".//*[@id='TrackingDetailGrid']/tbody/tr[" + FirstService + "]/td[3]");
                                FirstService += 2;
                                IncrementingService += 2;
                            }
                        }
                        break;
                    }


                case "Destination":
                    {
                        int FirstDestination = 1;
                        int IncrementingDestination = 2;
                        int count = GetCount(attributeName_xpath, "//*[@id='TrackingDetailGrid']/tbody/tr/td[2]");
                        for (int i = 1; i <= count; i++)
                        {
                            if (i == 1)
                            {
                                Click(attributeName_xpath, ".//*[@id='TrackingDetailGrid']/tbody/tr[1]/td[2]/span");
                                MoveToElementClick(attributeName_xpath, ".//*[@id='TrackingDetailGrid']/tbody/tr[" + FirstDestination + "]/td[3]");
                                string text = Gettext(attributeName_xpath, ".//*[@id='TrackingDetailGrid']/tbody/tr[" + IncrementingDestination + "]/td/table/tbody/tr[4]/td/div/div[2]");
                                if (text.Contains(TestData))
                                {
                                    Report.WriteLine("Filtered results contains the entered data");
                                }
                                else
                                {
                                    Report.WriteLine("Filtered results does not contain the entered data");
                                    Assert.IsTrue(false);
                                }
                                MoveToElementClick(attributeName_xpath, ".//*[@id='TrackingDetailGrid']/tbody/tr[" + FirstDestination + "]/td[3]");
                                FirstDestination += 2;
                                IncrementingDestination += 2;
                            }
                            else if (i >= 2)
                            {
                                MoveToElementClick(attributeName_xpath, ".//*[@id='TrackingDetailGrid']/tbody/tr[" + FirstDestination + "]/td[3]");
                                string text = Gettext(attributeName_xpath, ".//*[@id='TrackingDetailGrid']/tbody/tr[" + IncrementingDestination + "]/td/table/tbody/tr[4]/td/div/div[2]");
                                if (text.Contains(TestData))
                                {
                                    Report.WriteLine("Filtered results contains the entered data");
                                }
                                else
                                {
                                    Report.WriteLine("Filtered results does not contain the entered data");
                                }

                                MoveToElementClick(attributeName_xpath, ".//*[@id='TrackingDetailGrid']/tbody/tr[" + FirstDestination + "]/td[3]");
                                FirstDestination += 2;
                                IncrementingDestination += 2;
                            }
                        }
                        break;
                    }


                case "Origin":
                    {
                        int FirstOrigin = 1;
                        int IncrementingOrigin = 2;
                        int count = GetCount(attributeName_xpath, "//*[@id='TrackingDetailGrid']/tbody/tr/td[2]");
                        for (int i = 1; i <= count; i++)
                        {
                            if (i == 1)
                            {
                                Click(attributeName_xpath, ".//*[@id='TrackingDetailGrid']/tbody/tr[1]/td[2]/span");
                                MoveToElementClick(attributeName_xpath, ".//*[@id='TrackingDetailGrid']/tbody/tr[" + FirstOrigin + "]/td[3]");
                                string text = Gettext(attributeName_xpath, ".//*[@id='TrackingDetailGrid']/tbody/tr[" + IncrementingOrigin + "]/td/table/tbody/tr[3]/td/div/div[2]");
                                if (text.Contains(TestData))
                                {
                                    Report.WriteLine("Filtered results contains the entered data");
                                }
                                else
                                {
                                    Report.WriteLine("Filtered results does not contain the entered data");
                                    Assert.IsTrue(false);
                                }
                                MoveToElementClick(attributeName_xpath, ".//*[@id='TrackingDetailGrid']/tbody/tr[" + FirstOrigin + "]/td[3]");
                                FirstOrigin += 2;
                                IncrementingOrigin += 2;
                            }
                            else if (i >= 2)
                            {
                                MoveToElementClick(attributeName_xpath, ".//*[@id='TrackingDetailGrid']/tbody/tr[" + FirstOrigin + "]/td[3]");
                                string text = Gettext(attributeName_xpath, ".//*[@id='TrackingDetailGrid']/tbody/tr[" + IncrementingOrigin + "]/td/table/tbody/tr[3]/td/div/div[2]");
                                if (text.Contains(TestData))
                                {
                                    Report.WriteLine("Filtered results contains the entered data");
                                }
                                else
                                {
                                    Report.WriteLine("Filtered results does not contain the entered data");
                                    Assert.IsTrue(false);
                                }
                                MoveToElementClick(attributeName_xpath, ".//*[@id='TrackingDetailGrid']/tbody/tr[" + FirstOrigin + "]/td[3]");
                                FirstOrigin += 2;
                                IncrementingOrigin += 2;
                            }
                        }
                        break;
                    }
            }
        }
        [Then(@"I will not be able to see export button")]
        public void ThenIWillNotBeAbleToSeeExportButton()
        {
            Report.WriteLine("Verify Export Button not present");
            VerifyElementNotVisible(attributeName_id, Export_Button_Id, "ExportButton");
        }

        

        [Then(@"Expandable details will be expanded by default(.*)")]
        public void ThenExpandableDetailsWillBeExpandedByDefault(string MapHeader)
        {
            Report.WriteLine("Verify Tracking Details section expansion by Map Header");
            string MapHeader_UI = Gettext(attributeName_xpath, Map_Text_Xpath);
            Assert.AreEqual(MapHeader_UI, MapHeader);
        }


        [Then(@"I will have option for creating a New  Search (.*),(.*),(.*)")]
        public void ThenIWillHaveOptionForCreatingANewSearch(string NewSearchOption, string App_Url, string View)
        {
            Report.WriteLine("Verifying Tracking Header");
            VerifyElementPresent(attributeName_id, NewSearch_Button_Id, NewSearchOption);
            Assert.AreEqual((Gettext(attributeName_id, NewSearch_Button_Id)), NewSearchOption);
            Click(attributeName_id, NewSearch_Button_Id);
            switch (View)
            {
                case "Applicationloggedin":
                    {
                        Report.WriteLine("Verify User Navigated back to Tracking Page");
                        string resultPageURL = App_Url + "Tracking/TrackingIndex";
                        if (GetURL() == resultPageURL)
                        {

                            Report.WriteLine("Verified the Navigation back to tracking page");
                            VerifyElementPresent(attributeName_xpath, TrackingPage_Header_xpath, "Tracking");
                        }
                        else
                        {
                            Report.WriteLine("Verify the User is not Navigated back to Tracking page");
                            throw new Exception("User is not Navigated back to Tracking page");
                        }
                        break;
                    }

                case "ApplicationNotloggedin":
                    {
                        Report.WriteLine("Verify User Navigated back to Tracking section in Login Page");
                        string resultPagrURL = App_Url + "Login/Index";
                        if (GetURL() == resultPagrURL)
                        {

                            Report.WriteLine("Verified the Navigation back to Tracking section in Login Page");
                            VerifyElementPresent(attributeName_xpath, login_trackingtext_Xpath, "Tracking");
                        }
                        else
                        {
                            Report.WriteLine("Verify the User is not Navigated back to Tracking section in Login Page");
                            throw new Exception("User is not Navigated back to Tracking section in Login Page");
                        }
                        break;
                    }
            }


        }
    }
}
