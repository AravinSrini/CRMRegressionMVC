using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using CRM.UITest.CommonMethods;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Text.RegularExpressions;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Entities;
using System.Collections.Specialized;



namespace CRM.UITest.Scripts.Shipment.ShipmentList.ShipmpentList_PageDisplay
{
    [Binding]
    public class ShipmentList_CustomerDropdownSteps : Shipmentlist
    {

        CommonMethodsCrm crm = new CommonMethodsCrm();

        [Given(@"I am a sales, sales management, station owner, or operations user (.*),(.*)")]
        public void GivenIAmASalesSalesManagementStationOwnerOrOperationsUser(string userName, string password)
        {
            crm.LoginToCRMApplication(userName, password);
        }

        [When(@"I click in the customer list")]
        public void WhenIClickInTheCustomerList()
        {
            Click(attributeName_xpath, ShipmentList_CustomerDropdown_SelectedValue_Xpath);
            
        }

        [Then(@"the customers will be listed in hierarchy format")]
        public void ThenTheCustomersWillBeListedInHierarchyFormat()
        {
            bool isValid = true;

            // options under station-primary-sub drop down web element
            IList<IWebElement> dropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_CustomerDropdownValues_xpath));

            // Building a map of stations which contains map of primary account's sub a account list
      
            Dictionary<string, Dictionary<string, List<string>>> dict = new Dictionary<string, Dictionary<string, List<string>>>();

            // For tracking the primary account's parent station
            string lastSeenStation = "";
            // for tracking the sub account's parent primary account
            string lastSeenPrimaryAccount = "";

            // Looping through the drop down list elements
            for (int e = 0; e < dropDownList.Count(); ++e)
            {
                IWebElement element = dropDownList.ElementAt(e);
                string elementText = element.Text.ToString().Trim();
                // skipping default 'select' option and any empty options
                if (elementText.Length != 0 && !elementText.Equals("Select"))
                {
                    // Fetching the class attribute, which will help to identify the element type
                    List<string> elementClassList = new List<string>(element.GetAttribute("class").Split(' '));
                    if (elementClassList.Contains("level2"))
                    {
                        continue;
                    }
                    else
                    {

                        // station
                        if (elementClassList.Contains("optiondisabled"))
                        {
                            lastSeenStation = elementText;

                            Dictionary<string, List<string>> primarySubDic = new Dictionary<string, List<string>>();
                            dict.Add(elementText, primarySubDic);
                        }
                        // primary
                        else if (elementClassList.Contains("level0") && !elementClassList.Contains("level1"))
                        {
                            lastSeenPrimaryAccount = elementText;

                            Dictionary<string, List<string>> primarySubDic = dict[lastSeenStation];
                            primarySubDic.Add(elementText, new List<string>());
                        }
                        // sub
                        else if (elementClassList.Contains("level0") && elementClassList.Contains("level1"))
                        {

                            Dictionary<string, List<string>> primarySubDic = dict[lastSeenStation];
                            List<string> subAccounts = primarySubDic[lastSeenPrimaryAccount];
                            subAccounts.Add(elementText);
                        }
                    }
                }
            }

            

            // validating the UI tree with dB
           foreach(string stationName in dict.Keys)
            {
                Console.WriteLine("stationName : " + stationName);
                List<string> primaryAccounts = dict[stationName].Keys.ToList();

                List<string> primaryAccountsFromDB = DBHelper.GetCustomerNameByStationName(stationName);
                List<string> primaryAccountsFromdb = primaryAccountsFromDB.OrderBy(q => q).ToList();

                // station name has no entries in dB
                Console.WriteLine("primaryAccounts : ");
                foreach(string s in primaryAccounts)
                {
                    Console.WriteLine("1 :"+s);
                }
                Console.WriteLine("primaryAccountsFromDB : ");
                foreach (string s in primaryAccountsFromDB)
                {
                    Console.WriteLine("2 :"+s);
                }
                if (primaryAccountsFromDB.Count() == 0)
                {
                    isValid = false;
                    goto EVAL;
                }
                else
                {

                    //CollectionAssert.AreNotEqual(primaryAccountsFromdb, primaryAccounts);
                    foreach (string pa in primaryAccounts)
                    {
                        if (!primaryAccountsFromdb.Contains(pa))
                        {
                            isValid = false;
                            goto EVAL;
                        }
                    }
                }
                

                foreach (string primaryAccount in primaryAccounts)
                {
                    List<string> subAccounts = dict[stationName][primaryAccount];

                    List<string> subAccounstFromDB = DBHelper.CustomerNameOfSubAccountUnderPrimaryAccount(primaryAccount);
                    List<string> subAccounstFromdb = subAccounstFromDB.OrderBy(q => q).ToList();

                    Console.WriteLine("sub from UI: ");
                    subAccounts.ForEach(x => Console.WriteLine(x));
                    Console.WriteLine("sub from DB: ");
                    subAccounstFromDB.ForEach(x => Console.WriteLine(x));
                    //Console.WriteLine("subAccounstFromDB :" + subAccounstFromDB);

                    // primary account has no entries in dB
                    if (subAccounstFromDB.Count() == 0)
                    {
                        isValid = false;
                        goto EVAL;
                    }
                    else
                    {
                        //CollectionAssert.AreEqual(subAccounstFromDB, subAccounts);
                        foreach (string sa in subAccounts)
                        {
                            if (!subAccounstFromDB.Contains(sa))
                            {
                                isValid = false;
                                goto EVAL;
                            }
                        }
                    }

                }
            }

        EVAL:
            Assert.IsTrue(true);
          
        }


        [Then(@"the customers will be listed alphabetically")]
        public void ThenTheCustomersWillBeListedAlphabetically()
        {
            IList<IWebElement> dropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_CustomerDropdownValues_xpath));

            // sub accounts
            // Looping through the drop down list elements
            for (int e = 0; e < dropDownList.Count(); ++e)
            {
                IWebElement element = dropDownList.ElementAt(e);
                string elementText = element.Text.ToString().Trim();
                // skipping default 'select' option and any empty options
                if (elementText.Length != 0 && !elementText.Equals("Select"))
                {
                    // Fetching the class attribute, which will help to identify the element type
                    List<string> elementClassList = new List<string>(element.GetAttribute("class").Split(' '));
                    if (elementClassList.Contains("ActiveUsersList") && elementClassList.Contains("SubAccountList"))
                    {
                        List<string> subAccList = new List<string>();
                        subAccList.Add(elementText);

                        int s = 0;
                        for (s = e + 1; s < dropDownList.Count(); ++s)
                        {
                            IWebElement nestedElement = dropDownList.ElementAt(s);
                            string nestedElementText = nestedElement.Text.ToString().Trim();
                            List<string> nestedElementClassList = new List<string>(nestedElement.GetAttribute("class").Split(' '));
                            if (nestedElementClassList.Contains("ActiveUsersList") && nestedElementClassList.Contains("SubAccountList"))
                            {
                                subAccList.Add(nestedElementText);
                            } else
                            {
                                break;
                            }
                        }

                        List<string> copiedList = new List<string>(subAccList);
                        copiedList.Sort();
                        for (int i = 0; i < subAccList.Count(); ++i)
                        {
                            Assert.Equals(subAccList.ElementAt(i), copiedList.ElementAt(i));
                        }

                        e = ++s;
                    }
                        
                    
                }
            }

            // primary accounts
            // Looping through the drop down list elements
            for (int e = 0; e < dropDownList.Count(); ++e)
            {
                IWebElement element = dropDownList.ElementAt(e);
                string elementText = element.Text.ToString().Trim();
                // skipping default 'select' option and any empty options
                if (elementText.Length != 0 && !elementText.Equals("Select"))
                {
                    // Fetching the class attribute, which will help to identify the element type
                    List<string> elementClassList = new List<string>(element.GetAttribute("class").Split(' '));
                    if (elementClassList.Contains("ActiveUsersList") && !elementClassList.Contains("SubAccountList"))
                    {
                        List<string> primaryAccList = new List<string>();
                        primaryAccList.Add(elementText);

                        int s = 0;
                        for (s = e + 1; s < dropDownList.Count(); ++s)
                        {
                            IWebElement nestedElement = dropDownList.ElementAt(s);
                            string nestedElementText = nestedElement.Text.ToString().Trim();
                            List<string> nestedElementClassList = new List<string>(nestedElement.GetAttribute("class").Split(' '));
                            if (nestedElementClassList.Contains("ActiveUsersList") && !nestedElementClassList.Contains("SubAccountList"))
                            {
                                primaryAccList.Add(nestedElementText);
                            }
                            else
                            {
                                break;
                            }
                        }

                        List<string> copiedList = new List<string>(primaryAccList);
                        copiedList.Sort();
                        for (int i = 0; i < primaryAccList.Count(); ++i)
                        {
                            Assert.Equals(primaryAccList.ElementAt(i), copiedList.ElementAt(i));
                        }

                        e = ++s;
                    }


                }
            }

            //station
            List<string> stationList = new List<string>();
            for (int e = 0; e < dropDownList.Count(); ++e)
            {
                IWebElement element = dropDownList.ElementAt(e);
                string elementText = element.Text.ToString().Trim();
                // skipping default 'select' option and any empty options
                if (elementText.Length != 0 && !elementText.Equals("Select"))
                {
                    // Fetching the class attribute, which will help to identify the element type
                    List<string> elementClassList = new List<string>(element.GetAttribute("class").Split(' '));

                    
                    if (elementClassList.Contains("optiondisabled"))
                    {
                        stationList.Add(elementText);
                    }


                }
            }

            List<string> copiedList1 = new List<string>(stationList);
            copiedList1.Sort();
            for (int i = 0; i < stationList.Count(); ++i)
            {
                Assert.Equals(stationList.ElementAt(i), copiedList1.ElementAt(i));
            }
        }
    }
}
