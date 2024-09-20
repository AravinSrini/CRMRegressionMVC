using System;
using TechTalk.SpecFlow;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System.Threading;
using System.Collections.Generic;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;

namespace CRM.UITest.Scripts.Shipment.ShipmentList.ShipmentList_PageFilters_AllUsers
{
    [Binding]
    public class ShipmentList_PageFilters_AllUsersSteps : Shipmentlist
    {


        [When(@"I have option to filter with date range '(.*)'")]
        public void WhenIHaveOptionToFilterWithDateRange(string Pickup)
        {

            if (Pickup != "SCHEDULED TO DELIVER")
            {
                Click(attributeName_xpath, ShipmentList_FilterByDropdown_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, ShipmentList_ScheduledToPickup_Xpath, "SCHEDULED TO PICKUP");
            }

            string CurrentDate = DateTime.Now.AddDays(0).ToString();
            string[] Date = CurrentDate.Split('/');
            string Day = Date[1];
            int ConvertedDay = Convert.ToInt32(Day);

            int StartDate = 0;
            int EndDate = 1;

            Click(attributeName_xpath, ShipmentList_StartDate_Xpath);
            DatePickerFromCalander(attributeName_xpath, "html/body/div[9]/div[1]/table/tbody/tr/td", StartDate, "html/body/div[9]/div[1]/table/thead/tr[1]/th[3]/i");
            Thread.Sleep(2000);

            Click(attributeName_xpath, ShipmentList_EndDate_Xpath);
            DatePickerFromCalander(attributeName_xpath, "html/body/div[9]/div[1]/table/tbody/tr[3]/td[3]", EndDate, "html/body/div[9]/div[1]/table/thead/tr[1]/th[3]/i");
            Thread.Sleep(2000);
        }



        [Then(@"I must be able to view Scheduled to Deliver as default filter value with no dates selected -(.*),(.*),(.*)")]
        public void ThenIMustBeAbleToViewScheduledToDeliverAsDefaultFilterValueWithNoDatesSelected_(string ScheduledDeliver, string StartDate, string EndDate)
        {
            Report.WriteLine("Verify the default options to filter the Shipments");
            Verifytext(attributeName_xpath, ShipmentList_FilterByDropdown_Xpath, ScheduledDeliver);

            var DefaultText_StartDate = GetAttribute(attributeName_xpath, ShipmentList_StartDate_Xpath, "placeholder");
            Assert.AreEqual(StartDate, DefaultText_StartDate);

            var DefaultText_EndDate = GetAttribute(attributeName_xpath, ShipmentList_EndDate_Xpath, "placeholder");
            Assert.AreEqual(EndDate, DefaultText_EndDate);

        }


        [Then(@"I must be able to change default scheduled to deliver option to scheduled to pickup or viceversa")]
        public void ThenIMustBeAbleToChangeDefaultScheduledToDeliverOptionToScheduledToPickupOrViceversa()
        {
            Report.WriteLine("Changing from Default Scheduled To Deliver Option To Scheduled To Pickup Or Viceversa");
            Click(attributeName_xpath, ShipmentList_FilterByDropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, ShipmentList_ScheduledToPickup_Xpath, "SCHEDULED TO PICKUP");
            string ActualValue = Gettext(attributeName_xpath, ".//*[@id='FILTERby_chosen']/a/span");
            Assert.AreEqual("SCHEDULED TO PICKUP", ActualValue);

            Click(attributeName_xpath, ShipmentList_FilterByDropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, ShipmentList_ScheduledToDeliver_Xpath, "SCHEDULED TO DELIVER");
            string ActualValue1 = Gettext(attributeName_xpath, ".//*[@id='FILTERby_chosen']/a/span");
            Assert.AreEqual("SCHEDULED TO DELIVER", ActualValue1);


        }


        [Then(@"I must be able to view Remove button")]
        public void ThenIMustBeAbleToViewRemoveButton()
        {
            VerifyElementPresent(attributeName_xpath, ShipmentList_DatePicker_Remove_Button_xpath, "REMOVE");
        }

        [Then(@"When I click remove button, the grid and the filter options should set back to default")]
        public void ThenWhenIClickRemoveButtonTheGridAndTheFilterOptionsShouldSetBackToDefault()
        {
            Click(attributeName_xpath, ShipmentList_DatePicker_Remove_Button_xpath);
            Thread.Sleep(2000);

            Report.WriteLine("Verify the default options to filter the Shipments");
            Verifytext(attributeName_xpath, ShipmentList_FilterByDropdown_Xpath, "SCHEDULED TO DELIVER");

            var DefaultText_StartDate = GetAttribute(attributeName_xpath, ShipmentList_StartDate_Xpath, "placeholder");
            Assert.AreEqual("START DATE", DefaultText_StartDate);

            var DefaultText_EndDate = GetAttribute(attributeName_xpath, ShipmentList_EndDate_Xpath, "placeholder");
            Assert.AreEqual("END DATE", DefaultText_EndDate);

        }


        [Then(@"all the shipments for the ScheduledToPickup option '(.*)' should be filtered based on the date range")]
        public void ThenAllTheShipmentsForTheScheduledToPickupOptionShouldBeFilteredBasedOnTheDateRange(string ScheduledToPickup)
        {

            bool ETADate = IsElementPresent(attributeName_xpath, ".//*[@id='ShipmentGrid']/tbody/tr[1]/td[4]", "Grid Shipment Values for 1 row");
            if (ETADate == true)
            {
                //if (ScheduledToPickup != "SCHEDULED TO DELIVER")
                //{
                    Click(attributeName_xpath, ShipmentList_FilterByDropdown_Xpath);
                    SelectDropdownValueFromList(attributeName_xpath, ShipmentList_ScheduledToPickup_Xpath, "SCHEDULED TO PICKUP");
                //}


                string CurrentDate = DateTime.Now.AddDays(0).ToString();
                string[] Date = CurrentDate.Split('/');
                string Day = Date[1];
                int ConvertedDay = Convert.ToInt32(Day);

                Click(attributeName_xpath, ShipmentList_StartDate_Xpath);
                DatePickerFromCalander(attributeName_xpath, "html/body/div[9]/div[1]/table/tbody/tr/td", -4, "html/body/div[9]/div[1]/table/thead/tr[1]/th[3]/i");
                Thread.Sleep(2000);

                Click(attributeName_xpath, ShipmentList_EndDate_Xpath);
                DatePickerFromCalander(attributeName_xpath, "html/body/div[9]/div[1]/table/tbody/tr/td", 5, "html/body/div[9]/div[1]/table/thead/tr[1]/th[3]/i");
                Thread.Sleep(2000);

                DateTime SelectedStartDate_UI = Convert.ToDateTime(GetValue(attributeName_xpath, ShipmentList_StartDate_Xpath, "value"));
                //DateTime dateonly = SelectedStartDate_UI.Date;
                //string dd = dateonly.ToString("d");
                //DateTime startdate = Convert.ToDateTime(dd);


                DateTime SelectedEndDate_UI = Convert.ToDateTime(GetValue(attributeName_xpath, ShipmentList_EndDate_Xpath, "value"));
                //DateTime dateonly1 = SelectedEndDate_UI.Date;
                //string dd1 = dateonly1.ToString("d");
                //DateTime enddate = Convert.ToDateTime(dd1);

               
                IList<IWebElement> PickGridDates = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='ShipmentGrid']/tbody/tr/td[5]/span[1]"));
                
                List<DateTime> DateList = new List<DateTime>();

                if (PickGridDates.Count > 0)
                {
                    foreach (IWebElement element in PickGridDates)
                    {
                        DateTime ff = Convert.ToDateTime(element.Text);
                        DateList.Add((Convert.ToDateTime(element.Text)));
                    }


                    int size = DateList.Count;
                    for (int i = 0; i < size; i++)
                    {
                        DateTime A = DateList[i];
                        DateTime StartDatevalue = SelectedStartDate_UI.Date;
                        DateTime EndDatevalue = SelectedEndDate_UI.Date;
                        if ((DateList[i].Date >= SelectedStartDate_UI.Date) && (DateList[i].Date <= SelectedEndDate_UI.Date))
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



        [Then(@"all the shipments for the ScheduledToDelivery selected option '(.*)' should be filtered based on the date range")]
        public void ThenAllTheShipmentsForTheScheduledToDeliverySelectedOptionShouldBeFilteredBasedOnTheDateRange(string ScheduledToDelivery)
        {
            bool ETADate = IsElementPresent(attributeName_xpath, ".//*[@id='ShipmentGrid']/tbody/tr[1]/td[5]", "Grid Shipment Values for 1 row");
            if (ETADate == true)
            {
                //if (ScheduledToDelivery != "SCHEDULED TO DELIVER")
                //{
                //    Click(attributeName_xpath, ShipmentList_FilterByDropdown_Xpath);
                //    SelectDropdownValueFromList(attributeName_xpath, ShipmentList_ScheduledToPickup_Xpath, "SCHEDULED TO PICKUP");
                //}


                string CurrentDate = DateTime.Now.AddDays(0).ToString();
                string[] Date = CurrentDate.Split('/');
                string Day = Date[1];
                int ConvertedDay = Convert.ToInt32(Day);

                Click(attributeName_xpath, ShipmentList_StartDate_Xpath);
                DatePickerFromCalander(attributeName_xpath, "html/body/div[9]/div[1]/table/tbody/tr/td", -4, "html/body/div[9]/div[1]/table/thead/tr[1]/th[3]/i");
                Thread.Sleep(2000);

                Click(attributeName_xpath, ShipmentList_EndDate_Xpath);
                DatePickerFromCalander(attributeName_xpath, "html/body/div[9]/div[1]/table/tbody/tr/td", 5, "html/body/div[9]/div[1]/table/thead/tr[1]/th[3]/i");
                Thread.Sleep(2000);

                DateTime SelectedStartDate_UI = Convert.ToDateTime(GetValue(attributeName_xpath, ShipmentList_StartDate_Xpath, "value"));
                //DateTime dateonly = SelectedStartDate_UI.Date;
                //string dd = dateonly.ToString("d");
                //DateTime startdate = Convert.ToDateTime(dd);


                DateTime SelectedEndDate_UI = Convert.ToDateTime(GetValue(attributeName_xpath, ShipmentList_EndDate_Xpath, "value"));
                //DateTime dateonly1 = SelectedEndDate_UI.Date;
                //string dd1 = dateonly1.ToString("d");
                //DateTime enddate = Convert.ToDateTime(dd1);

                IList<IWebElement> PickGridDates = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='ShipmentGrid']/tbody/tr[1]/td[5]/span[1]"));

                List<DateTime> DateList = new List<DateTime>();

                if (PickGridDates.Count > 0)
                {
                    foreach (IWebElement element in PickGridDates)
                    {
                        DateTime ff = Convert.ToDateTime(element.Text);
                        DateList.Add((Convert.ToDateTime(element.Text)));
                    }


                    int size = DateList.Count;
                    for (int i = 0; i < size; i++)
                    {
                        DateTime A = DateList[i];
                        DateTime StartDatevalue = SelectedStartDate_UI.Date;
                        DateTime EndDatevalue = SelectedEndDate_UI.Date;
                        if ((DateList[i].Date >= SelectedStartDate_UI.Date) && (DateList[i].Date <= SelectedEndDate_UI.Date))
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
 


    

