using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using TechTalk.SpecFlow;
using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using CRM.UITest.Helper.ViewModel;
using CRM.UITest.CommonMethods;
using OpenQA.Selenium;
using CRM.UITest.Entities;

namespace CRM.UITest.Scripts.Availabe_Loads_Board
{
    [Binding]
    public class AvailableLoadsBoard_UIElementsSteps : LoadsBoard
    {
        List<AvailableLoadsViewModel> availableModel;
        IList<IWebElement> refValues;
        List<string> refValuesUI;
        string contactPhoneFromDB = null;
        string contactPhoneFromUI = null;
        string referenceNumberfromAPI = null;
        ListScreenExtractResponseFromMGForAvailableLoads ListScreenExtractFromMG = new ListScreenExtractResponseFromMGForAvailableLoads();

        [Given(@"that I am any user,")]
        public void GivenThatIAmAnyUser()
        {

        }

        [When(@"I open the Available Loads URL (.*),")]
        public void WhenIOpenTheAvailableLoadsURL(string url)
        {
            GlobalVariables.webDriver.Navigate().GoToUrl(url);
        }

        [When(@"I type in any value in the Search field  (.*)")]
        public void WhenITypeInAnyValueInTheSearchField(string searchValue)
        {
            Report.WriteLine("Passing data inside the search box");
            SendKeys(attributeName_xpath, searchTextbox_xpath, searchValue);
        }

        [When(@"I select any view (.*)"), Scope(Tag = "35208")]
        public void WhenISelectAnyView(string option)
        {
            Report.WriteLine("Verifying the view filtering functionality");
            WaitForElementVisible(attributeName_xpath, topViewOption_Xpath, option);
            SelectByValue(attributeName_xpath, topViewOption_Xpath, option);
        }

        [When(@"I click on refresh button"), Scope(Tag = "35208")]
        public void WhenIClickOnRefreshButton()
        {
            Report.WriteLine("Clicking on view option");
            Click(attributeName_xpath, refershButton_xpath);
        }

        [Then(@"I will arrive on the Available Loads page\.")]
        public void ThenIWillArriveOnTheAvailableLoadsPage_()
        {
            WaitForElementVisible(attributeName_xpath, totalRecords_xpath, "Grid Loading");
            Report.WriteLine("Verifying the title text in available loads page");
            string actText = Gettext(attributeName_xpath, availableLoadsTitle_xpath);
            Assert.AreEqual(actText, "Available Loads");
            Report.WriteLine("Displaying " + actText + "is matching with expected text Available Loads");
        }

        [Then(@"I will see the rrd DLS Worldwide logo,")]
        public void ThenIWillSeeTheRrdDLSWorldwideLogo()
        {
            Report.WriteLine("Verifying the displaying RRD logo");
            VerifyElementVisible(attributeName_xpath, rrdDLSLogo_xpath, "RRD Logo");
        }

        [Then(@"I will see  DLS contact phone information (.*),")]
        public void ThenIWillSeeDLSContactPhoneInformation(string p0)
        {
            Report.WriteLine("Verifying the contact verbiage in available loads page");
            string actText = Gettext(attributeName_id, claimLoadsInformation_id);
            Assert.AreEqual(actText, "To claim a load, call 844-221-6724 or click");
            Report.WriteLine("Displaying " + actText + "is matching with expected text To claim a load, call 844-221-6724 or click");
        }

        [Then(@"I will see the Available Loads grid display options,")]
        public void ThenIWillSeeTheAvailableLoadsGridDisplayOptions()
        {
            Report.WriteLine("Verifying the grid display verbiage");
            WaitForElementVisible(attributeName_id, totalRecordsCount_id, "Grid total records count");
            VerifyElementVisible(attributeName_id, totalRecordsCount_id, "Grid total records count");
        }

        [Then(@"I have the option to page forward or backward,")]
        public void ThenIHaveTheOptionToPageForwardOrBackward()
        {
            Report.WriteLine("Verifying the grid forward and backward options");
            VerifyElementVisible(attributeName_id, topForwardOption_id, "Forward Option");
            VerifyElementVisible(attributeName_id, topBackwardOption_id, "Backward Option");
        }

        [Then(@"I will see a search option,")]
        public void ThenIWillSeeASearchOption()
        {
            Report.WriteLine("Verifying the display of search option");
            VerifyElementVisible(attributeName_xpath, searchTextbox_xpath, "Search Box");
        }


        [Then(@"the grid will display the following columns Ref \#, Pickup Range, Delivery Range, Origin, Destination, \# of P/U, \# of Drops, Weight\(LBS\), Equip Type")]
        public void ThenTheGridWillDisplayTheFollowingColumnsRefPickupRangeDeliveryRangeOriginDestinationOfPUOfDropsWeightLBSEquipType()
        {
            Report.WriteLine("Verifying the displaying columns in grid");
            Verifytext(attributeName_xpath, columnReference_xpath, "REF #");
            Verifytext(attributeName_xpath, columnPickupRange_xpath, "PICKUP RANGE");
            Verifytext(attributeName_xpath, columnDeliveryRange_xpath, "DELIVERY RANGE");
            Verifytext(attributeName_xpath, columnOrigin_xpath, "ORIGIN");
            Verifytext(attributeName_xpath, columnDestination_xpath, "DESTINATION");
            Verifytext(attributeName_xpath, columnofPU_xpath, "# OF P/U");
            Verifytext(attributeName_xpath, columnoDrops_xpath, "# OF DROPS");
            Verifytext(attributeName_xpath, columnWEIGHT_xpath, "WEIGHT (lbs)");
            Verifytext(attributeName_xpath, columnEquipmentType_xpath, "EQUIP TYPE");
        }

        [Then(@"each available load displayed will have an email button,")]
        public void ThenEachAvailableLoadDisplayedWillHaveAnEmailButton()
        {
            Report.WriteLine("Verifying the displaying email option in grid");
            VerifyElementVisible(attributeName_xpath, columnEmailOption_FirstValue_xpath, "Email Option");
        }

        [Then(@"I will have an option to refresh the available loads page\.")]
        public void ThenIWillHaveAnOptionToRefreshTheAvailableLoadsPage_()
        {
            Report.WriteLine("Verifying the refresh button and its text");
            Verifytext(attributeName_xpath, refershText_xpath, " Refresh available loads");
            VerifyElementVisible(attributeName_xpath, refershButton_xpath, "Refresh Button");
        }

        [Then(@"the grid should be filtered and highlighted for matching values in all the columns (.*)")]
        public void ThenTheGridShouldBeFilteredAndHighlightedForMatchingValuesInAllTheColumns(string searchValue)
        {
            Report.WriteLine("Verifying the filtered records in UI with search value");
            string actText = Gettext(attributeName_xpath, columnofPU_FirstValue_xpath);
            int count = GetCount(attributeName_xpath, totalRecords_xpath);
            if (count > 2)
            {
                if (actText.Contains(searchValue))
                {
                    Report.WriteLine("Passed search value is matching with displaying value");
                    string actColor = GetCSSValue(attributeName_xpath, "//tr[1]/td[6]/span", "background-color");
                    Assert.AreEqual(actColor, "rgba(81, 123, 207, 0.4)");
                }
                else
                {
                    Report.WriteLine("Unable to verify the filtered functionality as passed data does not exits in row");
                    Assert.IsTrue(false);
                }
            }
            else
            {
                Report.WriteLine("No matching records found for the passed search value");
            }
        }

        [Then(@"any displayed rows that contain the values that were entered will be highlighted (.*)")]
        public void ThenAnyDisplayedRowsThatContainTheValuesThatWereEnteredWillBeHighlighted(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"no results found message should be displayed")]
        public void ThenNoResultsFoundMessageShouldBeDisplayed()
        {
            string actError = Gettext(attributeName_xpath, totalRecords_xpath);
            Assert.AreEqual(actError, "No Results Found");
            Report.WriteLine("No Results Found message is displayeing when invalid search value is entered");
        }

        [Then(@"selected view (.*) should be filtered in the grid")]
        public void ThenSelectedViewShouldBeFilteredInTheGrid(string option)
        {
            string totalrecords = Gettext(attributeName_id, totalRecordsCount_id);
            string displaycount = totalrecords.Substring(totalrecords.LastIndexOf("OF") + 2);
            int DC = Convert.ToInt32(displaycount);
            if (DC > 10)
            {
                Assert.AreEqual(displaycount, option);
            }
            else
            {
                Report.WriteLine("Unable to verify the view option funcitonality as number of records is less than selected option");
            }
        }

        [Then(@"Displaying Pickup and Delivery date should match with API")]
        public void ThenDisplayingPickupAndDeliveryDateShouldMatchWithAPI()
        {
            availableModel = ListScreenExtractFromMG.ListScreenExtractFromMGForAvailableLoads();
            //Verifying the first row UI data with API response 
            string firstRef = Gettext(attributeName_xpath, columnReference_FirstValue_xpath);

            int rowsCount = GetCount(attributeName_xpath, totalRowRecords_xpath);
            Assert.AreEqual(availableModel.Count, rowsCount - 1);
            Report.WriteLine("Displaying total records count in UI is matching with API total records count");

            for (int i = 0; i < availableModel.Count; i++)
            {
                if (availableModel[i].PrimaryReference == firstRef)
                {
                    Report.WriteLine("Verifying the pickup range API data with UI");
                    string actPickUPRange = Gettext(attributeName_xpath, columnPickupRange_FirstValue_xpath);
                    string expPickupRange = availableModel[i].PickupRange;
                    string[] pData = expPickupRange.Split('-');
                    Assert.AreEqual(actPickUPRange, pData[0].ToUpper() + " - " + pData[1].ToUpper());
                    Report.WriteLine("Displaying UI data " + actPickUPRange + "is matching with API data " + pData[0] + " - " + pData[1]);

                    Report.WriteLine("Verifying the delivery range API data with UI");
                    string actDelRange = Gettext(attributeName_xpath, columnDeliveryRange_FirstValue_xpath);
                    string expDelRange = availableModel[i].DeliveryRange;
                    string[] dData = expDelRange.Split('-');
                    Assert.AreEqual(actDelRange, dData[0].ToUpper() + " - " + dData[1].ToUpper());
                    Report.WriteLine("Displaying UI data " + actDelRange + "is matching with API data " + dData[0] + " - " + dData[1]);
                    break;
                }
            }
        }

        [Then(@"displaying values in the grid should match with API")]
        public void ThenDisplayingValuesInTheGridShouldMatchWithAPI()
        {
            availableModel = ListScreenExtractFromMG.ListScreenExtractFromMGForAvailableLoads();
            //Verifying the first row UI data with API response 
            string firstRef = Gettext(attributeName_xpath, columnReference_FirstValue_xpath);

            int rowsCount = GetCount(attributeName_xpath, totalRowRecords_xpath);
            Assert.AreEqual(availableModel.Count, rowsCount - 1);
            Report.WriteLine("Displaying total records count in UI is matching with API total records count");

            for (int i = 0; i < availableModel.Count; i++)
            {
                if (availableModel[i].PrimaryReference == firstRef)
                {
                    Report.WriteLine("Verifying the pickup range API data with UI");
                    string actPickUPRange = Gettext(attributeName_xpath, columnPickupRange_FirstValue_xpath);
                    string expPickupRange = availableModel[i].PickupRange;
                    string[] pData = expPickupRange.Split('-');
                    //string[] pDataNew = pData[1].Split(' ');
                    Assert.AreEqual(actPickUPRange, pData[0].ToUpper() + " - " + pData[1].ToUpper());
                    Report.WriteLine("Displaying UI data " + actPickUPRange + "is matching with API data " + pData[0] + " - " + pData[1]);

                    Report.WriteLine("Verifying the delivery range API data with UI");
                    string actDelRange = Gettext(attributeName_xpath, columnDeliveryRange_FirstValue_xpath);
                    string expDelRange = availableModel[i].DeliveryRange;
                    string[] dData = expDelRange.Split('-');
                    // string[] dDataNew = dData[1].Split(' ');
                    Assert.AreEqual(actDelRange, dData[0].ToUpper() + " - " + dData[1].ToUpper());
                    Report.WriteLine("Displaying UI data " + actDelRange + "is matching with API data " + dData[0] + " - " + dData[1]);

                    Report.WriteLine("Verifying the origin data with UI");
                    string actOrigin = Gettext(attributeName_xpath, columnOrigin_FirstValue_xpath);
                    string expOrigin = availableModel[i].OriginCity + "," + availableModel[i].OriginState + " " + availableModel[i].OriginZip;
                    Assert.AreEqual(actOrigin, expOrigin);
                    Report.WriteLine("Displaying UI data " + actOrigin + "is matching with API data " + expOrigin);

                    Report.WriteLine("Verifying the destination data with UI");
                    string actDest = Gettext(attributeName_xpath, columnDestination_FirstValue_xpath);
                    string expDest = availableModel[i].DestinationCity + "," + availableModel[i].DestinationState + " " + availableModel[i].DestinationZip;
                    Assert.AreEqual(actDest, expDest);
                    Report.WriteLine("Displaying UI data " + actDest + "is matching with API data " + expDest);

                    Report.WriteLine("Verifying the # of P/U data with UI");
                    string actPU = Gettext(attributeName_xpath, columnofPU_FirstValue_xpath);
                    Assert.AreEqual(actPU, availableModel[i].NoOfPickup);
                    Report.WriteLine("Displaying UI data " + actPU + "is matching with API data " + availableModel[i].NoOfPickup);

                    Report.WriteLine("Verifying the # of drops data with UI");
                    string actDrop = Gettext(attributeName_xpath, columnoDrops_FirstValue_xpath);
                    Assert.AreEqual(actDrop, availableModel[i].NoOfDrops);
                    Report.WriteLine("Displaying UI data " + actDrop + "is matching with API data " + availableModel[i].NoOfDrops);

                    Report.WriteLine("Verifying the equipment data with UI");
                    string actEquip = Gettext(attributeName_xpath, columnEquipmentType_FirstValue_xpath);
                    Assert.AreEqual(actEquip, availableModel[i].EquipmentType);
                    Report.WriteLine("Displaying UI data " + actEquip + "is matching with API data " + availableModel[i].EquipmentType);
                    break;
                }
            }
        }

        //---------------------------77434 - Available Loads - Add Phone Number to Grid Script ---------------------------//

        [Given(@"that I navigate to the CRM Available Loads web page"), Scope(Tag = "77434")]
        public void GivenThatINavigateToTheCRMAvailableLoadsWebPage()
        {
            string availableLoadsURL = launchUrl + "availableLoads";
            GlobalVariables.webDriver.Navigate().GoToUrl(availableLoadsURL);
            bool visible = IsElementPresent(attributeName_xpath, AcceptCookies_Xpath, "cookie");
            if (visible == true)
            {
                Click(attributeName_xpath, AcceptCookies_Xpath);
            }
            Report.WriteLine("Land on Available Loads page");
        }

        [When(@"the page loads"), Scope(Tag = "77434")]
        public void WhenThePageLoads()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            VerifyElementVisible(attributeName_xpath, availableLoadsTitle_xpath, "Available Loads");
            Report.WriteLine("Available loads page loaded");
        }

        [Given(@"corresponding station to a Load is not available in CRM")]
        public void GivenCorrespondingStationToALoadIsNotAvailableInCRM()
        {
            availableModel = ListScreenExtractFromMG.ListScreenExtractFromMGForAvailableLoads();
            //SelectByVisibleText(attributeName_xpath, topViewOption_Xpath, "ALL");

            refValues = GlobalVariables.webDriver.FindElements(By.XPath(refColumnValues_xpath));
            refValuesUI = new List<string>();
            foreach (var contactPhoneList in refValues)
            {
                refValuesUI.Add(contactPhoneList.Text);
            }
            if (availableModel.Count > 0)
            {
                for (int i = 0; i < availableModel.Count; i++)
                {
                    if (availableModel[i].PrimaryReference == refValuesUI[i])
                    {
                        contactPhoneFromDB = DBHelper.GetContactPhoneOnAvailableLoadPage(availableModel[i].CarrierSCAC);
                        if (contactPhoneFromDB == null)
                        {
                            referenceNumberfromAPI = availableModel[i].PrimaryReference;
                            contactPhoneFromUI = Gettext(attributeName_xpath, "//tr[" + (i + 1) + "]/td[11]");
                            Report.WriteLine("corresponding station to a Load is not available in CRM " + availableModel[i].CarrierSCAC);
                        }
                    }
                }
            }
            else
            {
                Report.WriteFailure("There are no records found for available loads");
            }

        }

        [Then(@"the Contact Phone Column will be displayed to the right of Equip Type"), Scope(Tag = "77434")]
        public void ThenTheContactPhoneColumnWillBeDisplayedToTheRightOfEquipType()
        {
            Report.WriteLine("the Contact Phone Column will be displayed to the right of Equip Type in grid");
            Verifytext(attributeName_xpath, columnContactPhone_xpath, "CONTACT PHONE");
        }

        [Then(@"the value for Contact Phone will be the Available Load Phone from the associated Station details")]
        public void ThenTheValueForContactPhoneWillBeTheAvailableLoadPhoneFromTheAssociatedStationDetails()
        {
            availableModel = ListScreenExtractFromMG.ListScreenExtractFromMGForAvailableLoads();
            //Verifying the Contact Phone from API
            //SelectByVisibleText(attributeName_xpath, topViewOption_Xpath, "ALL");
            GlobalVariables.webDriver.WaitForPageLoad();
            if (availableModel.Count > 0)
            {
                Report.WriteLine("Verifying the number of records from UI with API");
                int rowsCount = GetCount(attributeName_xpath, totalRowRecords_xpath);
                Assert.AreEqual(availableModel.Count, rowsCount - 1);

                refValues = GlobalVariables.webDriver.FindElements(By.XPath(refColumnValues_xpath));
                refValuesUI = new List<string>();
                foreach (var contactPhoneList in refValues)
                {
                    refValuesUI.Add(contactPhoneList.Text);
                }

                for (int i = 0; i < availableModel.Count; i++)
                {
                    if (availableModel[i].PrimaryReference == refValuesUI[i])
                    {
                        Report.WriteLine("Verifying the Contact Phone data with UI");
                        contactPhoneFromDB = DBHelper.GetContactPhoneOnAvailableLoadPage(availableModel[i].CarrierSCAC);
                        if (contactPhoneFromDB != null)
                        {
                            contactPhoneFromUI = Gettext(attributeName_xpath, "//tr[" + (i + 1) + "]/td[11]");
                            Assert.AreEqual(contactPhoneFromDB, contactPhoneFromUI);
                            Report.WriteLine("Displaying Contact Phone in UI " + contactPhoneFromUI + " is matching with DB Contact Phone " + contactPhoneFromDB);
                        }
                    }
                }
            }
            else
            {
                Report.WriteFailure("There are no records found for available loads");
            }

        }

        [Then(@"I will see the Contact Number with empty value for that load")]
        public void ThenIWillSeeTheContactNumberWithEmptyValueForThatLoad()
        {
            Assert.AreEqual("", contactPhoneFromUI);
            Report.WriteLine("Contact Phone number is empty for " + referenceNumberfromAPI);
        }
    }
}
