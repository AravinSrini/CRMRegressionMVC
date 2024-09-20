﻿using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Quote_List.QuoteList_InternalUsers
{
    [Binding]
    public class QuoteListCustomerSearchFeature_StationUsersSteps : Quotelist
    {

        CommonMethodsCrm crm = new CommonMethodsCrm();

        [Then(@"Customer search option should be visible")]
        public void ThenCustomerSearchOptionShouldBeVisible()
        {
            VerifyElementPresent(attributeName_xpath, ".//*[@id='CategoryType_chosen']/div/div/input", "Customer Search field");
        }


        [When(@"I am on the Quote List page")]
        public void WhenIAmOnTheQuoteListPage()
        {
            Report.WriteLine("Clicking on quote module icon");
            Click(attributeName_xpath, QuoteModule_Xpath);
            Thread.Sleep(2000);

            

        }

        //[When(@"I click on customer drop down list")]
        //public void WhenIClickOnCustomerDropDownList()
        //{
        //    Report.WriteLine("Clicking on customer dropdown list");
        //    Click(attributeName_xpath, QuoteList_CustomerDropdown_Xpath);
        //}


        [Then(@"associated customers should be listed alphabetically for station")]
        public void ThenAssociatedCustomersShouldBeListedAlphabeticallyForStation()
        {
           
            Report.WriteLine("Clicking on customer dropdown list");
            Click(attributeName_xpath, QuoteList_CustomerDropdown_Xpath);
            string stationName = Gettext(attributeName_xpath, ".//*[@id='CategoryType_chosen']/div/ul/li[2]");

            List<CustomerAccount> records = DBHelper.GetAccountsMappedforStation(stationName);
            List<int> setupid = records.Select(s => s.CustomerSetUpId).ToList();


            List<string> options = new List<string>();
            foreach (var s in setupid)
            {
                CustomerSetup account = DBHelper.GetSetupDetails(s);
                options.Add(account.CustomerName);
            }

            options.Sort();

            string[] fromDb = options.ToArray();

            IList<IWebElement> UIAccounts = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='CategoryType_chosen']/div/ul/li"));
           
            ArrayList list = new ArrayList();
            for (int i = 3; i <= UIAccounts.Count; i++)
            {
                string custNames = GetAttribute(attributeName_xpath, ".//*[@id='CategoryType_chosen']/div/ul/li[" + i + "]", "class");

                if (custNames.Contains("active-result group-option"))
                {
                    //int j = i + 1;
                    string custNames1 = Gettext(attributeName_xpath, ".//*[@id='CategoryType_chosen']/div/ul/li[" + i + "]");
                    list.Add(custNames1);

                }
                else
                {
                    break;
                }
            }

            list.Sort();
            if (options.Count.Equals(list.Count))
            {
                Report.WriteLine("Customer Count of UI matches with the DB count for the station");
            }
            else
            {
                Report.WriteLine("Customer Count of UI doe not matches with the DB count for the station");
                Assert.Fail();
            }
 
            for (int i = 0; i < list.Count; i++)
            {
                if (options[i].Equals(list[i]))
                {
                    Report.WriteLine("Expected value :" + options[i] + " is equal to the actual value: " + list[i]);
                }
                else
                {
                    Report.WriteFailure("Sorting is not as expected");
                    Assert.Fail();
                }
            }


        }

        [Then(@"I should not see search box when number of customers is less than ten")]
        public void ThenIShouldNotSeeSearchBoxWhenNumberOfCustomersIsLessThanTen()
        {
            Report.WriteLine("Clicking on station customer dropdown");
            Click(attributeName_xpath, QuoteList_CustomerDropdown_Xpath);
            int cusValues = GetCount(attributeName_xpath, ".//*[contains(@class,'active-result')]");
            if (cusValues < 10)
            {
                Report.WriteLine("Search box is not visible as number of customer accounts is less than 10");
                VerifyElementNotVisible(attributeName_xpath, ".//*[@id='CategoryType_chosen']/div/div/input", "Dropdown Search");
            }
            else
            {
                WaitForElementVisible(attributeName_xpath, ".//*[@id='CategoryType_chosen']/div/div/input", "Dropdown Search");
                Report.WriteLine("Search box is visible as number of customer accounts is more than 10");
            }
        }



    }

}

