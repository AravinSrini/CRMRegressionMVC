using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Tracking
{
    [Binding]
    public sealed class TrackingDetailsPage_Steps : ObjectRepository
    {

        [Given(@"I am a DLS user and launch crm url")]
        public void GivenIAmADLSUserAndLaunchCrmUrl()
        {
            Report.WriteLine("Launch URL");
            LaunchURL();
            Report.WriteLine("Land on Homepage");
        }


        [Then(@"I have clicked on more informaation icon for any availabe record")]
        public void ThenIHaveClickedOnMoreInformaationIconForAnyAvailabeRecord()
        {
            Click(attributeName_xpath, trackingInformationIcon_Xpath);
        }


        [Then(@"I will be able to see field within information modal (.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void ThenIWillBeAbleToSeeFieldWithinInformationModal(string Pro_Number, string PO, string Ship_Reference, string Scheduled_Pickup, string Scheduled_Delivery, string Quantity, string Weight, string Carrier)
        {
            Verifytext(attributeName_xpath, TrckingInformaion_Pro_Number_Xpath, Pro_Number);
            Verifytext(attributeName_xpath, TrckingInformaion_PO_Xpath,PO);
            Verifytext(attributeName_xpath, TrckingInformaion_Ship_Reference_Xpath, Ship_Reference);
            Verifytext(attributeName_xpath, TrckingInformaion_Scheduled_Pickup_Xpath, Scheduled_Pickup);
            Verifytext(attributeName_xpath, TrckingInformaion_Scheduled_Delivery_Xpath, Scheduled_Delivery);
            Verifytext(attributeName_xpath, TrckingInformaion_Quantity_Xpath, Quantity);
            Verifytext(attributeName_xpath, TrckingInformaion_Weight_Xpath, Weight);
            Verifytext(attributeName_xpath, TrckingInformaion_Carrier_Xpath, Carrier);
        }


        [When(@"I am on (.*) tracking page")]
        public void WhenIAmOnTrackingPage(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I have entered valid tracking numbers in track by reference number text box and click on search arrow button(.*)")]
        public void WhenIHaveEnteredValidTrackingNumbersInTrackByReferenceNumberTextBoxAndClickOnSearchArrowButton(string TrackingNumber)
        {
            SendKeys(attributeName_id, TrackByReferenceNumber_Textbox_Id, TrackingNumber);
            MoveToElementClick(attributeName_xpath, TrackByReferenceNumber_SearchArrow_Xpath);
        }

       

        [Then(@"I have arrived on the tracking details page")]
        public void ThenIHaveArrivedOnTheTrackingDetailsPage()
        {
            string configURL = launchUrl;
            Report.WriteLine("Verifying the Navigation to Tracking Page");
            string resultPagrURL = configURL + "Tracking/TrackingDetails";
            if (GetURL() == resultPagrURL)
            {
                Report.WriteLine("User is in Trackinng details page");
            }
            else
            {
                Report.WriteLine("Trackinng details page is not available");
                throw new Exception("Trackinng details is not available");

            }
        }


        [When(@"I click on the search button")]
        public void WhenIClickOnTheSearchButton()
        {
            Report.WriteLine("click on the search button in the Tracking page");
            Click(attributeName_xpath, TrackByReferenceNumber_SearchArrow_Xpath);
        }


        [Then(@"I will be able to see A title of Tracking with a description (.*) and (.*)")]
        public void ThenIWillBeAbleToSeeATitleOfTrackingWithADescriptionAnd(string ExpectedTrackingTitleText, string ExpectedTrackingDescriptionText)
        {
            string TrackingPage_Header_UI = Gettext(attributeName_xpath, TrackingPage_Header_xpath);
            Assert.AreEqual(ExpectedTrackingTitleText, TrackingPage_Header_UI);

            string TrackingDescription_UI = Gettext(attributeName_xpath, TrackingDescriptionText_Xpath);
            Assert.AreEqual(ExpectedTrackingDescriptionText, TrackingDescription_UI);
        }

        [Then(@"I will be able to see An option for creating a New  Search (.*),(.*)")]
        public void ThenIWillBeAbleToSeeAnOptionForCreatingANewSearch(string App_Url,string NewSearchOption)
        {
            Report.WriteLine("Verifying Tracking Header");
            //WaitForElementVisible(attributeName_id, TrackingPage_Header_xpath, "TrackingHeader");
            VerifyElementPresent(attributeName_id, NewSearch_Button_Id, NewSearchOption);
            Click(attributeName_id, NewSearch_Button_Id);
            string resultPagrURL = App_Url + "Tracking/TrackingIndex";
            if (GetURL() == resultPagrURL)
            {
                Report.WriteLine("User is in Trackinng page");
            }
            else
            {
                Report.WriteLine("Trackinng page is not available");
                throw new Exception("Trackinng page is not available");

            }

        }

        [Then(@"Verify New  Search and its functionality (.*),(.*)")]
        public void ThenVerifyNewSearchAndItsFunctionality(string App_Url, string NewSearchOption)
        {
            Report.WriteLine("Verifying Tracking Header");
            //WaitForElementVisible(attributeName_id, TrackingPage_Header_xpath, "TrackingHeader");
            VerifyElementPresent(attributeName_id, NewSearch_Button_Id, NewSearchOption);
            Click(attributeName_id, NewSearch_Button_Id);
            string resultPagrURL = App_Url + "Login/Index";
            if (GetURL() == resultPagrURL)
            {
                Report.WriteLine("User is in Trackinng page");
            }
            else
            {
                Report.WriteLine("Trackinng page is not available");
                throw new Exception("Trackinng page is not available");

            }
        }


        [Then(@"I will be able to see An option to export the search results(.*)")]
        public void ThenIWillBeAbleToSeeAnOptionToExportTheSearchResults(string ExportButton)
        {
            string Ref_Text_UI = Gettext(attributeName_id, Export_Button_Id);
            Assert.AreEqual(ExportButton, Ref_Text_UI);
            
        }

        [Then(@"I will be able to see  (.*), (.*), (.*), (.*), (.*), (.*), (.*) within tracking details grid")]
        public void ThenIWillBeAbleToSeeWithinTrackingDetailsGrid(string ExpctedRefText, string ExpctedStatusText, string ExpctedETAText, string ExpctedLocationText, string ExpctedOriginText, string ExpctedDestinationText, string ExpctedServiceText)
        {
            string Ref_Text_UI = Gettext(attributeName_xpath, Ref_Text_Xpath);
            Assert.AreEqual(ExpctedRefText, Ref_Text_UI);

            string Status_Text_UI = Gettext(attributeName_xpath, Status_Text_Xpath);
            Assert.AreEqual(ExpctedStatusText, Status_Text_UI);

            string ETA_Text_UI = Gettext(attributeName_xpath, ETA_Text_Xpath);
            Assert.AreEqual(ETA_Text_UI, ETA_Text_UI);

            string Location_Text_UI = Gettext(attributeName_xpath, Location_Text_Xpath);
            Assert.AreEqual(ExpctedLocationText, Location_Text_UI);

            string Origin_Text_UI = Gettext(attributeName_xpath, Origin_Text_Xpath);
            Assert.AreEqual(ExpctedOriginText, Origin_Text_UI);

            string Destination_Text_UI = Gettext(attributeName_xpath, Destination_Text_Xpath);
            Assert.AreEqual(ExpctedDestinationText, Destination_Text_UI);

            string Service_Text_UI = Gettext(attributeName_xpath, Service_Text_Xpath);
            Assert.AreEqual(ExpctedServiceText, Service_Text_UI);
        }

        [Then(@"I will be able to see '(.*)' button on each shipment record")]
        public void ThenIWillBeAbleToSeeButtonOnEachShipmentRecord(string p0)
        {
            int k = 1;
            int rowCount = GetCount(attributeName_xpath, TrackingDetailsOptions_Xpath);
            for (int i = 1; i <= rowCount; i++)
            {
                
                if (i == 1){
                    bool value = IsHtmlElementIsExist(attributeName_xpath, ".//*[@id='TrackingDetailGrid']/tbody/tr[" + i + "]/td[9]");
                    if (value)
                    {
                        Report.WriteLine("Element present");
                    }
                    else
                    {
                        throw new Exception("Element not present");
                    }
                }
                else
                {
                    bool value1 = IsHtmlElementIsExist(attributeName_xpath, ".//*[@id='TrackingDetailGrid']/tbody/tr[" +(k+2) + "]/td[9]");
                    if (value1)
                    {
                        Report.WriteLine("Element present");
                        k++; 
                    }
                    else
                    {
                        throw new Exception("Element not present");
                    }
                    k++;
                }
            }
        }


        [Then(@"I will be able to see search shipment text box in tracking details page")]
        public void ThenIWillBeAbleToSeeSearchShipmentTextBoxInTrackingDetailsPage()
        {
            bool value = IsHtmlElementIsExist(attributeName_id, SearchShipment_Textbox_Id);
            if (value)
            {
                Report.WriteLine("Element present");
            }
            else
            {
                throw new Exception("Element not present");
            }
        }

        [Then(@"I will be able to see different avaiable options to filter the tracing details (.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void ThenIWillBeAbleToSeeDifferentAvaiableOptionsToFilterTheTracingDetails(string ExpectedFilterByText, string ExpectedScheduleToDeliver, string ExpectedBetweenText, string ExpectedStartDateText, string ExpectedAndText, string ExpectedEndDateText, string ExpectedOntimeCheckBoxOption, string ExpectedExceptiondelaysOption)
        {
            string FilterBy_Text_UI = Gettext(attributeName_xpath, FilterBy_Text_Xpath);
            Assert.AreEqual(ExpectedFilterByText, FilterBy_Text_UI);

            string ScheduledToDeliver_Text_UI = Gettext(attributeName_xpath, ScheduledToDeliver_Text_Xpath);
            Assert.AreEqual(ExpectedScheduleToDeliver, ScheduledToDeliver_Text_UI);

            string Between_Text_UI = Gettext(attributeName_xpath, Between_Text_Xpath);
            Assert.AreEqual(ExpectedBetweenText, Between_Text_UI);

            string StartDate_Text_UI = GetValue(attributeName_id, StartDate_Text_Id, "placeholder").ToUpper();
            Assert.AreEqual(ExpectedStartDateText, StartDate_Text_UI);

             string EndDate_Text_UI = GetValue(attributeName_id, EndDate_Text_Id,"placeholder").ToUpper();
             Assert.AreEqual(ExpectedEndDateText, EndDate_Text_UI);

            string And_Text_UI = Gettext(attributeName_xpath, And_Text_Xpath);
            Assert.AreEqual(ExpectedAndText, And_Text_UI);

            string OneTime_Text_UI = Gettext(attributeName_xpath, OneTime_Text_Xpath);
            Assert.AreEqual(ExpectedOntimeCheckBoxOption.ToUpper(), OneTime_Text_UI.ToUpper());

            string ExceptionsDelays_Text_UI = Gettext(attributeName_xpath, ExceptionsDelays_Text_Xpath);
            Assert.AreEqual(ExpectedExceptiondelaysOption.ToUpper(), ExceptionsDelays_Text_UI.ToUpper());


        }


        

        [Then(@"I have clicked on arrow in the search bar")]
        public void ThenIHaveClickedOnArrowInTheSearchBar()
        {
            Click(attributeName_id, SearchShipment_Arrow_Id);
        }

        [Then(@"I can see different avaiable search checkboxes (.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void ThenICanSeeDifferentAvaiableSearchCheckboxes(string Expextedselect_all, string Expextedreference_number, string Expextedstatus, string Expextedeta, string Expextedlocation, string Expextedservice, string Expextedorigin, string Expexteddestination, string Expextedcarrier, string Expextedscheduled_pickup, string Expextedscheduled_delivery, string Expextedclear_all)
        {
            Thread.Sleep(3000);
            string SelectAll_Button_UI = Gettext(attributeName_xpath, SelectAll_Button_Xpath);
            Assert.AreEqual(Expextedselect_all, SelectAll_Button_UI);

            string ReferenceNumber_CheckBox_UI = Gettext(attributeName_xpath, ReferenceNumber_CheckBoxText_Xpath);
            Assert.AreEqual(Expextedreference_number, ReferenceNumber_CheckBox_UI);

            string Status_CheckBox_UI = Gettext(attributeName_xpath, Status_CheckBoxText_Xpath);
            Assert.AreEqual(Expextedstatus, Status_CheckBox_UI);

            string ETA_CheckBox_UI = Gettext(attributeName_xpath, ETA_CheckBoxText_Xpath);
            Assert.AreEqual(Expextedeta, ETA_CheckBox_UI);

            string Location_UI = Gettext(attributeName_xpath, LocationCheckboxText_Xpath);
            Assert.AreEqual(Expextedlocation, Location_UI);

            string Service_CheckBox_UI = Gettext(attributeName_xpath, Service_CheckBoxText_Xpath);
            Assert.AreEqual(Expextedservice, Service_CheckBox_UI);

            string Origin_CheckBox_UI = Gettext(attributeName_xpath, Origin_CheckBoxText_Xpath);
            Assert.AreEqual(Expextedorigin, Origin_CheckBox_UI);

            string Destination_CheckBox_UI = Gettext(attributeName_xpath, Destination_CheckBoxText_Xpath);
            Assert.AreEqual(Expexteddestination, Destination_CheckBox_UI);

            string Carrier_CheckBox_UI = Gettext(attributeName_xpath, Carrier_CheckBoxText_Xpath);
            Assert.AreEqual(Expextedcarrier, Carrier_CheckBox_UI);

            string ScheduledPickUp_CheckBox_UI = Gettext(attributeName_xpath, ScheduledPickUp_CheckBoxText_Xpath);
            Assert.AreEqual(Expextedscheduled_pickup, ScheduledPickUp_CheckBox_UI);

            string ScheduledDelivery_CheckBox_UI = Gettext(attributeName_xpath, ScheduledDelivery_CheckBoxText_Xpath);
            Assert.AreEqual(Expextedscheduled_delivery, ScheduledDelivery_CheckBox_UI);

            string ClearAll_Button_UI = Gettext(attributeName_xpath, ClearAll_Button_Xpath);
            Assert.AreEqual(Expextedclear_all, ClearAll_Button_UI);
        }


        [Then(@"Check box (.*),(.*),(.*),(.*),(.*),(.*),(.*)(.*),(.*),(.*) should be selected by default")]
        public void ThenCheckBoxShouldBeSelectedByDefault(string reference_number, string status, string eta, string location, string service, string origin, string destination, string carrier, string scheduled_pickup, string scheduled_delivery)
        {
            VerifyElementChecked(attributeName_xpath, ReferenceNumber_CheckBox_Xpath, reference_number);
            VerifyElementChecked(attributeName_xpath, Status_CheckBox_Xpath, status);
            VerifyElementChecked(attributeName_xpath, ETA_CheckBox_Xpath, eta);
            VerifyElementChecked(attributeName_xpath, LocationCheckbox_Xpath, location);
            VerifyElementChecked(attributeName_xpath, Service_CheckBox_Xpath, service);
            VerifyElementChecked(attributeName_xpath, Origin_CheckBox_Xpath, origin);
            VerifyElementChecked(attributeName_xpath, Destination_CheckBox_Xpath, destination);

            VerifyElementNotChecked(attributeName_xpath, Carrier_CheckBox_Xpath, carrier);
            VerifyElementNotChecked(attributeName_xpath, ScheduledPickUp_CheckBox_Xpath, scheduled_pickup);
            VerifyElementNotChecked(attributeName_xpath, ScheduledDelivery_CheckBox_Xpath, scheduled_delivery);

        }

        



        [Then(@"I have clikced on clear all check box (.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void ThenIHaveClikcedOnClearAllCheckBox(string reference_number, string status, string eta, string location, string service, string origin, string destination, string carrier, string scheduled_pickup, string scheduled_delivery)
        {
            Thread.Sleep(3000);
            Click(attributeName_xpath, ClearAll_Button_Xpath);
            VerifyElementNotChecked(attributeName_xpath, ReferenceNumber_CheckBox_Xpath, reference_number);
            VerifyElementNotChecked(attributeName_xpath, Status_CheckBox_Xpath, status);
            VerifyElementNotChecked(attributeName_xpath, ETA_CheckBox_Xpath, eta);
            VerifyElementNotChecked(attributeName_xpath, LocationCheckbox_Xpath, location);
            VerifyElementNotChecked(attributeName_xpath, Service_CheckBox_Xpath, service);
            VerifyElementNotChecked(attributeName_xpath, Origin_CheckBox_Xpath, origin);
            VerifyElementNotChecked(attributeName_xpath, Destination_CheckBox_Xpath, destination);
            VerifyElementNotChecked(attributeName_xpath, Carrier_CheckBox_Xpath, carrier);
            VerifyElementNotChecked(attributeName_xpath, ScheduledPickUp_CheckBox_Xpath, scheduled_pickup);
            VerifyElementNotChecked(attributeName_xpath, ScheduledDelivery_CheckBox_Xpath, scheduled_delivery);

            
        }




        [Then(@"I have clicked on select all check box (.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void ThenIHaveClickedOnSelectAllCheckBox(string reference_number, string status, string eta, string location, string service, string origin, string destination, string carrier, string scheduled_pickup, string scheduled_delivery)
        {
            Click(attributeName_xpath, SelectAll_Button_Xpath);
            //GlobalVariables.webDriver.
            VerifyElementChecked(attributeName_xpath, ReferenceNumber_CheckBox_Xpath, reference_number);
            VerifyElementChecked(attributeName_xpath, Status_CheckBox_Xpath, status);
            VerifyElementChecked(attributeName_xpath, ETA_CheckBox_Xpath, eta);
            VerifyElementChecked(attributeName_xpath, LocationCheckbox_Xpath, location);
            VerifyElementChecked(attributeName_xpath, Service_CheckBox_Xpath, service);
            VerifyElementChecked(attributeName_xpath, Origin_CheckBox_Xpath, origin);
            VerifyElementChecked(attributeName_xpath, Destination_CheckBox_Xpath, destination);
            VerifyElementChecked(attributeName_xpath, Carrier_CheckBox_Xpath, carrier);
            VerifyElementChecked(attributeName_xpath, ScheduledPickUp_CheckBox_Xpath, scheduled_pickup);
            VerifyElementChecked(attributeName_xpath, ScheduledDelivery_CheckBox_Xpath, scheduled_delivery);

            //bool value = GlobalVariables.webDriver.FindElement(By.XPath(ReferenceNumber_CheckBox_Xpath)).Selected;
            //if (value)
            //{
            //    Report.WriteLine("chekbox is checked");
            //}
            //else
            //{
            //    throw new Exception("chekbox is not checked");
            //}

            //bool value1 = GlobalVariables.webDriver.FindElement(By.XPath(Status_CheckBox_Xpath)).Selected;
            //if (value1)
            //{
            //    Report.WriteLine("chekbox is checked");
            //}
            //else
            //{
            //    throw new Exception("chekbox is not checked");
            //}

            //bool value2 = GlobalVariables.webDriver.FindElement(By.XPath(ETA_CheckBox_Xpath)).Selected;
            //if (value2)
            //{
            //    Report.WriteLine("chekbox is checked");
            //}
            //else
            //{
            //    throw new Exception("chekbox is not checked");
            //}

            //bool value3 = GlobalVariables.webDriver.FindElement(By.XPath(LocationCheckbox_Xpath)).Selected;
            //if (value3)
            //{
            //    Report.WriteLine("chekbox is checked");
            //}
            //else
            //{
            //    throw new Exception("chekbox is not checked");
            //}

            //bool value4 = GlobalVariables.webDriver.FindElement(By.XPath(Service_CheckBox_Xpath)).Selected;
            //if (value4)
            //{
            //    Report.WriteLine("chekbox is checked");
            //}
            //else
            //{
            //    throw new Exception("chekbox is not checked");
            //}

            //bool value5 = GlobalVariables.webDriver.FindElement(By.XPath(Origin_CheckBox_Xpath)).Selected;
            //if (value5)
            //{
            //    Report.WriteLine("chekbox is checked");
            //}
            //else
            //{
            //    throw new Exception("chekbox is not checked");
            //}

            //bool value6 = GlobalVariables.webDriver.FindElement(By.XPath(Destination_CheckBox_Xpath)).Selected;
            //if (value6)
            //{
            //    Report.WriteLine("chekbox is checked");
            //}
            //else
            //{
            //    throw new Exception("chekbox is not checked");
            //}


            //bool value7 = GlobalVariables.webDriver.FindElement(By.XPath(Carrier_CheckBox_Xpath)).Selected;
            //if (value7)
            //{
            //    Report.WriteLine("chekbox is checked");
            //}
            //else
            //{
            //    throw new Exception("chekbox is not checked");
            //}

            //bool value8 = GlobalVariables.webDriver.FindElement(By.XPath(ScheduledPickUp_CheckBox_Xpath)).Selected;
            //if (value8)
            //{
            //    Report.WriteLine("chekbox is checked");
            //}
            //else
            //{
            //    throw new Exception("chekbox is not checked");
            //}

            //bool value9 = GlobalVariables.webDriver.FindElement(By.XPath(ScheduledDelivery_CheckBox_Xpath)).Selected;
            //if (value9)
            //{
            //    Report.WriteLine("chekbox is checked");
            //}
            //else
            //{
            //    throw new Exception("chekbox is not checked");
            //}
        }


        [Then(@"I will be able to filer tracking details by entering different availabe option (.*),(.*)")]
        public void ThenIWillBeAbleToFilerTrackingDetailsByEnteringDifferentAvailabeOption(string searchOption, string data)
        {
            Thread.Sleep(3000);


            bool value = GlobalVariables.webDriver.FindElement(By.XPath(ReferenceNumber_CheckBox_Xpath)).Selected;
            bool value1 = GlobalVariables.webDriver.FindElement(By.XPath(Status_CheckBox_Xpath)).Selected;
            bool value2 = GlobalVariables.webDriver.FindElement(By.XPath(ETA_CheckBox_Xpath)).Selected;
            bool value3 = GlobalVariables.webDriver.FindElement(By.XPath(LocationCheckbox_Xpath)).Selected;
            bool value4 = GlobalVariables.webDriver.FindElement(By.XPath(Service_CheckBox_Xpath)).Selected;
            bool value5 = GlobalVariables.webDriver.FindElement(By.XPath(Origin_CheckBox_Xpath)).Selected;
            bool value6 = GlobalVariables.webDriver.FindElement(By.XPath(Destination_CheckBox_Xpath)).Selected;
            bool value7 = GlobalVariables.webDriver.FindElement(By.XPath(Carrier_CheckBox_Xpath)).Selected;
            bool value8 = GlobalVariables.webDriver.FindElement(By.XPath(ScheduledPickUp_CheckBox_Xpath)).Selected;
            bool value9 = GlobalVariables.webDriver.FindElement(By.XPath(ScheduledDelivery_CheckBox_Xpath)).Selected;


            Click(attributeName_id, SearchShipment_Arrow_Id);
            SendKeys(attributeName_id, SearchShipment_Textbox_Id, data);
            if (searchOption.ToUpper() == "REFERENCE NUMBER")
            {
                if (value)
                {
                    int k = 1;
                    int count = GetCount(attributeName_xpath, "//*[@id='TrackingDetailGrid']/tbody/tr/td[2]");
                    for (int i = 1; i <= count; i++)
                    {
                        if (i == 1)
                        {
                            string text = Gettext(attributeName_xpath, "//*[@id='TrackingDetailGrid']/tbody/tr[" + i + "]/td[1]");

                            if (text.Contains(data))
                            {
                                Report.WriteLine("Filtered results contains the entered data");
                            }
                            else
                            {
                                Report.WriteLine("Filtered results does not contain the entered data");
                                Assert.IsTrue(false);
                            }
                        }
                        else
                        {
                            if (i >= 2)
                            {
                                string text1 = Gettext(attributeName_xpath, "//*[@id='TrackingDetailGrid']/tbody/tr[" + (k + 2) + "]/td[1]");
                                if (text1.Contains(data))
                                {
                                    Report.WriteLine("Filtered results contains the entered data");
                                    k++;
                                }
                                else
                                {
                                    Report.WriteLine("Filtered results does not contain the entered data");
                                    Assert.IsTrue(false);
                                }
                                k++;
                            }
                        }
                    }
                }
                else
                {
                    Verifytext(attributeName_xpath, Tracking_NoResultsFound, "No results found");
                }
            }
            else if (searchOption.ToUpper() == "STATUS")
            {
                if (value1)
                {
                    int k = 1;
                    int count = GetCount(attributeName_xpath, "//*[@id='TrackingDetailGrid']/tbody/tr/td[2]");
                    for (int i = 1; i <= count; i++)
                    {
                        if (i == 1)
                        {
                            string text = Gettext(attributeName_xpath, "//*[@id='TrackingDetailGrid']/tbody/tr[" + i + "]/td[2]");

                            if (text.Contains(data))
                            {
                                Report.WriteLine("Filtered results contains the entered data");
                            }
                            else
                            {
                                Report.WriteLine("Filtered results does not contain the entered data");
                                Assert.IsTrue(false);
                            }
                        }
                        else
                        {
                            if (i >= 2)
                            {
                                string text1 = Gettext(attributeName_xpath, "//*[@id='TrackingDetailGrid']/tbody/tr[" + (k + 2) + "]/td[2]");
                                if (text1.Contains(data))
                                {
                                    Report.WriteLine("Filtered results contains the entered data");
                                    k++;
                                }
                                else
                                {
                                    Report.WriteLine("Filtered results does not contain the entered data");
                                    Assert.IsTrue(false);
                                }
                                k++;
                            }
                        }
                    }
                }
                else
                {
                    Verifytext(attributeName_xpath, Tracking_NoResultsFound, "No results found");
                }
            }

            else if (searchOption.ToUpper() == "ETA")
            {

                if (value2)
                {
                    int k = 1;
                    int count = GetCount(attributeName_xpath, "//*[@id='TrackingDetailGrid']/tbody/tr/td[3]");
                    for (int i = 1; i <= count; i++)
                    {
                        if (i == 1)
                        {
                            string text = Gettext(attributeName_xpath, "//*[@id='TrackingDetailGrid']/tbody/tr[" + i + "]/td[3]");

                            if (text.Contains(data))
                            {
                                Report.WriteLine("Filtered results contains the entered data");
                            }
                            else
                            {
                                Report.WriteLine("Filtered results does not contain the entered data");
                                Assert.IsTrue(false);
                            }
                        }
                        else
                        {
                            if (i >= 2)
                            {
                                string text1 = Gettext(attributeName_xpath, "//*[@id='TrackingDetailGrid']/tbody/tr[" + (k + 2) + "]/td[3]");
                                if (text1.Contains(data))
                                {
                                    Report.WriteLine("Filtered results contains the entered data");
                                    k++;
                                }
                                else
                                {
                                    Report.WriteLine("Filtered results does not contain the entered data");
                                    Assert.IsTrue(false);
                                }
                                k++;
                            }
                        }
                    }
                }
                else
                {
                    Verifytext(attributeName_xpath, Tracking_NoResultsFound, "No results found");
                }
            }

            else if (searchOption.ToUpper() == "LOCATION")
            {
                if (value3)
                {
                    int k = 1;
                    int count = GetCount(attributeName_xpath, "//*[@id='TrackingDetailGrid']/tbody/tr/td[4]");
                    for (int i = 1; i <= count; i++)
                    {
                        if (i == 1)
                        {
                            string text = Gettext(attributeName_xpath, "//*[@id='TrackingDetailGrid']/tbody/tr[" + i + "]/td[4]");

                            if (text.Contains(data))
                            {
                                Report.WriteLine("Filtered results contains the entered data");
                            }
                            else
                            {
                                Report.WriteLine("Filtered results does not contain the entered data");
                                Assert.IsTrue(false);
                            }
                        }
                        else
                        {
                            if (i >= 2)
                            {
                                string text1 = Gettext(attributeName_xpath, "//*[@id='TrackingDetailGrid']/tbody/tr[" + (k + 2) + "]/td[4]");
                                if (text1.Contains(data))
                                {
                                    Report.WriteLine("Filtered results contains the entered data");
                                    k++;
                                }
                                else
                                {
                                    Report.WriteLine("Filtered results does not contain the entered data");
                                    Assert.IsTrue(false);
                                }
                                k++;
                            }
                        }
                    }
                }
                else
                {
                    Verifytext(attributeName_xpath, Tracking_NoResultsFound, "No results found");
                }
            }

            else if (searchOption.ToUpper() == "SERVICE")
            {
                if (value4)
                {
                    int k = 1;
                    int count = GetCount(attributeName_xpath, "//*[@id='TrackingDetailGrid']/tbody/tr/td[7]");
                    for (int i = 1; i <= count; i++)
                    {
                        if (i == 1)
                        {
                            string text = Gettext(attributeName_xpath, "//*[@id='TrackingDetailGrid']/tbody/tr[" + i + "]/td[7]");

                            if (text.Contains(data))
                            {
                                Report.WriteLine("Filtered results contains the entered data");
                            }
                            else
                            {
                                Report.WriteLine("Filtered results does not contain the entered data");
                                Assert.IsTrue(false);
                            }
                        }
                        else
                        {
                            if (i >= 2)
                            {
                                string text1 = Gettext(attributeName_xpath, "//*[@id='TrackingDetailGrid']/tbody/tr[" + (k + 2) + "]/td[7]");
                                if (text1.Contains(data))
                                {
                                    Report.WriteLine("Filtered results contains the entered data");
                                    k++;
                                }
                                else
                                {
                                    Report.WriteLine("Filtered results does not contain the entered data");
                                    Assert.IsTrue(false);
                                }
                                k++;
                            }
                        }
                    }
                }
                else
                {
                    Verifytext(attributeName_xpath, Tracking_NoResultsFound, "No results found");
                }
            }

            else if (searchOption.ToUpper() == "ORIGIN")
            {
                if (value5)
                {
                    int k = 1;
                    int count = GetCount(attributeName_xpath, "//*[@id='TrackingDetailGrid']/tbody/tr/td[5]");
                    for (int i = 1; i <= count; i++)
                    {
                        if (i == 1)
                        {
                            string text = Gettext(attributeName_xpath, "//*[@id='TrackingDetailGrid']/tbody/tr[" + i + "]/td[5]");

                            if (text.Contains(data))
                            {
                                Report.WriteLine("Filtered results contains the entered data");
                            }
                            else
                            {
                                Report.WriteLine("Filtered results does not contain the entered data");
                                Assert.IsTrue(false);
                            }
                        }
                        else
                        {
                            if (i >= 2)
                            {
                                string text1 = Gettext(attributeName_xpath, "//*[@id='TrackingDetailGrid']/tbody/tr[" + (k + 2) + "]/td[5]");
                                if (text1.Contains(data))
                                {
                                    Report.WriteLine("Filtered results contains the entered data");
                                    k++;
                                }
                                else
                                {
                                    Report.WriteLine("Filtered results does not contain the entered data");
                                    Assert.IsTrue(false);
                                }
                                k++;
                            }
                        }
                    }
                }
                else
                {
                    Verifytext(attributeName_xpath, Tracking_NoResultsFound, "No results found");
                }
            }

            else if (searchOption.ToUpper() == "DESTINATION")
            {
                if (value6)
                {
                    int k = 1;
                    int count = GetCount(attributeName_xpath, "//*[@id='TrackingDetailGrid']/tbody/tr/td[6]");
                    for (int i = 1; i <= count; i++)
                    {
                        if (i == 1)
                        {
                            string text = Gettext(attributeName_xpath, "//*[@id='TrackingDetailGrid']/tbody/tr[" + i + "]/td[6]");

                            if (text.Contains(data))
                            {
                                Report.WriteLine("Filtered results contains the entered data");
                            }
                            else
                            {
                                Report.WriteLine("Filtered results does not contain the entered data");
                                Assert.IsTrue(false);
                            }
                        }
                        else
                        {
                            if (i >= 2)
                            {
                                string text1 = Gettext(attributeName_xpath, "//*[@id='TrackingDetailGrid']/tbody/tr[" + (k + 2) + "]/td[6]");
                                if (text1.Contains(data))
                                {
                                    Report.WriteLine("Filtered results contains the entered data");
                                    k++;
                                }
                                else
                                {
                                    Report.WriteLine("Filtered results does not contain the entered data");
                                    Assert.IsTrue(false);
                                }
                                k++;
                            }
                        }
                    }
                }
                else
                {
                    Verifytext(attributeName_xpath, Tracking_NoResultsFound, "No results found");
                }
            }

            else if (searchOption.ToUpper() == "CARRIER")
            {
                if (value7)
                {
                    int k = 1;
                    int count = GetCount(attributeName_xpath, "//*[@id='TrackingDetailGrid']/tbody/tr/td[7]");

                    for (int i = 1; i <= count; i++)
                    {
                        if (i == 1)
                        {
                            Thread.Sleep(3000);
                            Click(attributeName_xpath, "//*[@id='TrackingDetailGrid']/tbody/tr[" + i + "]/td[8]/button/i");

                            string text = Gettext(attributeName_xpath, "//*[@id='TrackingDetailGrid']/tbody/tr[" + i + "]/td[8]/div/table/tbody/tr[8]/td[2]/span");
                            Click(attributeName_xpath, "//*[@id='TrackingDetailGrid']/tbody/tr[" + i + "]/td[8]/div/a/span");
                            if (text.Contains(data))
                            {
                                Report.WriteLine("Filtered results contains the entered data");
                            }
                            else
                            {
                                Report.WriteLine("Filtered results does not contain the entered data");
                                Assert.IsTrue(false);
                            }
                        }
                        if (i >= 2)
                        {
                            Thread.Sleep(3000);
                            Click(attributeName_xpath, "//*[@id='TrackingDetailGrid']/tbody/tr[" + (k + 2) + "]/td[8]/button/i");

                            string text = Gettext(attributeName_xpath, "//*[@id='TrackingDetailGrid']/tbody/tr[" + (k + 2) + "]/td[8]/div/table/tbody/tr[8]/td[2]/span");
                            Click(attributeName_xpath, "//*[@id='TrackingDetailGrid']/tbody/tr[" + (k + 2) + "]/td[8]/div/a/span");
                            if (text.Contains(data))
                            {
                                Report.WriteLine("Filtered results contains the entered data");
                                k++;
                            }
                            else
                            {
                                Report.WriteLine("Filtered results does not contain the entered data");
                                Assert.IsTrue(false);
                            }
                            k++;
                        }
                    
                    }
                }
                else
                {
                    Verifytext(attributeName_xpath, Tracking_NoResultsFound, "No results found");
                }

            }

            else if (searchOption.ToUpper() == "SCHEDULED PICKUP")
            {
                if (value8)
                {
                    int k = 1;
                    int count = GetCount(attributeName_xpath, "//*[@id='TrackingDetailGrid']/tbody/tr/td[8]");
                    for (int i = 1; i <= count; i++)
                    {
                        if (i == 1)
                        {
                            Click(attributeName_xpath, "//*[@id='TrackingDetailGrid']/tbody/tr[" + i + "]/td[8]/button/i");

                            string text = Gettext(attributeName_xpath, "//*[@id='TrackingDetailGrid']/tbody/tr[" + i + "]/td[8]/div/table/tbody/tr[4]/td[2]/span");
                            Click(attributeName_xpath, "//*[@id='TrackingDetailGrid']/tbody/tr[" + i + "]/td[8]/div/a/span");
                            if (text.Contains(data))
                            {
                                Report.WriteLine("Filtered results contains the entered data");
                            }
                            else
                            {
                                Report.WriteLine("Filtered results does not contain the entered data");
                                Assert.IsTrue(false);
                            }
                        }
                        if (i >= 2)
                        {
                            Click(attributeName_xpath, "//*[@id='TrackingDetailGrid']/tbody/tr[" + (k + 2) + "]/td[8]/button/i");

                            string text = Gettext(attributeName_xpath, "//*[@id='TrackingDetailGrid']/tbody/tr[" + (k + 2) + "]/td[8]/div/table/tbody/tr[4]/td[2]/span");
                            Click(attributeName_xpath, "//*[@id='TrackingDetailGrid']/tbody/tr[" + (k + 2) + "]/td[8]/div/a/span");
                            if (text.Contains(data))
                            {
                                Report.WriteLine("Filtered results contains the entered data");
                                k++;
                            }
                            else
                            {
                                Report.WriteLine("Filtered results does not contain the entered data");
                                Assert.IsTrue(false);
                            }
                            k++;
                        }
                    }
                }
                else
                {
                    Verifytext(attributeName_xpath, Tracking_NoResultsFound, "No results found");
                }
            }

            else if (searchOption.ToUpper() == "SCHEDULED DELIVERY")
            {
                if (value9)
                {
                    int k = 1;
                    int count = GetCount(attributeName_xpath, "//*[@id='TrackingDetailGrid']/tbody/tr/td[10]");
                    for (int i = 1; i <= count; i++)
                    {
                        if (i == 1)
                        {
                            Click(attributeName_xpath, "//*[@id='TrackingDetailGrid']/tbody/tr[" + i + "]/td[8]/button/i");

                            string text = Gettext(attributeName_xpath, ".//*[@id='TrackingDetailGrid']/tbody/tr[" + i + " ]/td[8]/div/table/tbody/tr[5]/td[2]/span");
                            Click(attributeName_xpath, "//*[@id='TrackingDetailGrid']/tbody/tr[" + i + "]/td[8]/div/a/span");
                            if (text.Contains(data))
                            {
                                Report.WriteLine("Filtered results contains the entered data");
                            }
                            else
                            {
                                Report.WriteLine("Filtered results does not contain the entered data");
                                Assert.IsTrue(false);
                            }
                        }
                        if (i >= 2)
                        {
                            Click(attributeName_xpath, "//*[@id='TrackingDetailGrid']/tbody/tr[" + (k + 2) + "]/td[8]/button/i");

                            string text = Gettext(attributeName_xpath, ".//*[@id='TrackingDetailGrid']/tbody/tr[" + (k + 2) + " ]/td[8]/div/table/tbody/tr[5]/td[2]/span");
                            Click(attributeName_xpath, "//*[@id='TrackingDetailGrid']/tbody/tr[" + (k + 2) + "]/td[8]/div/a/span");
                            if (text.Contains(data))
                            {
                                Report.WriteLine("Filtered results contains the entered data");
                                k++;
                            }
                            else
                            {
                                Report.WriteLine("Filtered results does not contain the entered data");
                                Assert.IsTrue(false);
                            }
                            k++;
                        }
                    }
                }
                else
                {
                    Verifytext(attributeName_xpath, Tracking_NoResultsFound, "No results found");
                }
            }
        }




        [Then(@"I have clicked on more iformaation icon for recodrd icon for any availabe record")]
        public void ThenIHaveClickedOnMoreIformaationIconForRecodrdIconForAnyAvailabeRecord()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I will be able to see field within information icon (.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void ThenIWillBeAbleToSeeFieldWithinInformationIcon(string p0, string p1, string p2, string p3, string p4, string p5, string p6)
        {
            ScenarioContext.Current.Pending();
        }

       

        [Then(@"the expandable details will be expanded by default (.*),(.*)")]
        public void ThenTheExpandableDetailsWillBeExpandedByDefault(string MApHeader, string TrackingDetailHeader)
        {
			WaitForElementVisible(attributeName_xpath, Tracking_MapHeader_Xpath, MApHeader);
            Verifytext(attributeName_xpath, Tracking_MapHeader_Xpath, MApHeader);
            scrollpagedown();
            Verifytext(attributeName_xpath, Tracking_TrackingDetailsHeader_Xpath, TrackingDetailHeader);
        }


      
        [Then(@"Vefiy right navigation icon visibility")]
        public void ThenVefiyRightNavigationIconVisibility()
        {
            int totalRecords = GetCount(attributeName_xpath, TrackingDetailsOptions_Xpath);
            bool value = IsElementVisible(attributeName_xpath, Trackiing_RightNavigationButton_Xpath, "class");
            if (totalRecords < 10 && value)
            {
                Report.WriteLine("Button is not visible");
            }
            else
            {

                throw new Exception("Right navigation option is visible but total number of records are less than 10");
            }
        }
        

       
        [Then(@"Vefiy left navigation icon visibility")]
        public void ThenVefiyLeftNavigationIconVisibility()
        {
            int totalRecords = GetCount(attributeName_xpath, TrackingDetailsOptions_Xpath);
            bool value = IsElementVisible(attributeName_xpath, Trackiing_LeftNavigationButton_Xpath, "class");
            if (totalRecords < 10 && value)
            {
                Report.WriteLine("Button is visible");
            }
            else
            {

                throw new Exception("Left navigation option is visible but total number of records are less than 10");
            }
        }


        [Then(@"I have uncheck all checboxes and try to search results (.*)")]
        public void ThenIHaveUncheckAllChecboxesAndTryToSearchResults(string data)
        {

            Click(attributeName_xpath, ClearAll_Button_Xpath);
            SendKeys(attributeName_id, SearchShipment_Textbox_Id, data);
            Verifytext(attributeName_xpath, Tracking_NoResultsFound, "No results found");

        }

        [Then(@"I have otpion to filer with date range '(.*)'")]
        public void ThenIHaveOtpionToFilerWithDateRange(string Pickup)
        {


            bool ETADate = IsElementPresent(attributeName_xpath, Grid_EtaDate_Xpath, "Grid ETA Values for 1 row");
            if (ETADate == true)
            {
                Click(attributeName_xpath, FilterArrow_Xpath);
                if (Pickup != "Scheduled to Deliver")
                {
                    SelectDropdownValueFromList(attributeName_xpath, ".//*[@id='drp_FilterSc_chosen']/div/ul/li", "Scheduled to Pickup");
                }
                Click(attributeName_xpath, SelectedstartDate_Xpath);

                string CurrentDate = DateTime.Now.AddDays(0).ToString();
                string[] Date = CurrentDate.Split('/');
                string Day = Date[1];
                int ConvertedDay = Convert.ToInt32(Day);

                int FinalStartDay = -(30 + ConvertedDay - 1);
                Click(attributeName_xpath, "html/body/div[5]/div[1]/table/thead/tr[1]/th[1]");
                DatePickerFromCalander(attributeName_xpath, "html/body/div[5]/div[1]/table/tbody/tr/td", FinalStartDay, "html/body/div[5]/div[1]/table/thead/tr[1]/th[1]");
                //Thread.Sleep(4000);
                Click(attributeName_xpath, SelectedEndDate_Xpath);
                Click(attributeName_xpath, "html/body/div[5]/div[1]/table/thead/tr[1]/th[3]");

                int FinalEndDay = (60 - ConvertedDay + 1);
                DatePickerFromCalander(attributeName_xpath, "html/body/div[5]/div[1]/table/tbody/tr/td", FinalEndDay, "html/body/div[5]/div[1]/table/thead/tr[1]/th[3]");
                //Thread.Sleep(4000);
                DateTime SelectedStartDate_UI = Convert.ToDateTime(GetValue(attributeName_xpath, SelectedstartDate_Xpath, "value"));
                DateTime SelectedEndDate_UI = Convert.ToDateTime(GetValue(attributeName_xpath, SelectedEndDate_Xpath, "value"));

                IList<IWebElement> GridDates = GlobalVariables.webDriver.FindElements(By.XPath(Griddaterange_Xpath));
                List<DateTime> DateList = new List<DateTime>();

                if (GridDates.Count > 0)
                {
                    foreach (IWebElement element in GridDates)
                    {
                        DateList.Add((Convert.ToDateTime(element.Text)));
                    }


                    int size = DateList.Count;
                    for (int i = 0; i < size; i++)
                    {
                        DateTime A = DateList[i];
                        DateTime StartDatevalue = SelectedStartDate_UI.Date;
                        DateTime EndDatevalue = SelectedEndDate_UI.Date;
                        if ((DateList[i].Date >= SelectedStartDate_UI.Date) && (DateList[i].Date < SelectedEndDate_UI.Date))
                        {
                            Console.WriteLine("selected datevalue range is present  in Grid");
                        }
                        else
                        {
                            Console.WriteLine("Selected Date Range value is not present");
                            throw new Exception("Filter Data not available");
                        }
                    }
                }

                else
                {
                    Console.WriteLine("No Data appears for the selected Dates");
                }
            }

            else
            {
                Console.WriteLine("No data found in the Grid");
            }
        }
        
    }
}
