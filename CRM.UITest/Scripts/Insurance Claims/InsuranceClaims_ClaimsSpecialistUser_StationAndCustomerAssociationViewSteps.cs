
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.Dls.IdentityServer.Core.Dto;
using Rrd.ServiceAccessLayer;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml.Linq;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Entities;


namespace CRM.UITest.Scripts.Insurance_Claims
{
    [Binding]
    public class InsuranceClaims_ClaimsSpecialistUser_StationAndCustomerAssociationViewSteps : Objects.InsuranceClaim
    {

        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
        WebElementOperations GetElementList = new WebElementOperations();
        string stationId = "ZZZ";

        [Given(@"that I am a Claims Specialist user")]
        public void GivenThatIAmAClaimsSpecialistUser()
        {
            string username = ConfigurationManager.AppSettings["username-CurrentsprintClaimspecialist"].ToString();
            string password = ConfigurationManager.AppSettings["password-CurrentsprintClaimspecialist"].ToString();
            CrmLogin.LoginToCRMApplication(username, password);
        }
        
        [Given(@"I have selected a station to which I am associated")]
        public void GivenIHaveSelectedAStationToWhichIAmAssociated()
        {
            Click(attributeName_xpath, SubmitaClaim_Stationdropdown_xpath);
            SelectDropdownValueFromList(attributeName_xpath, SubmitaClaim_StatiodropdownValues_xpath, "ZZZ - Web Services Test");
        }
        
        [When(@"I click on the Station field")]
        public void WhenIClickOnTheStationField()
        {
            Click(attributeName_xpath, SubmitaClaim_Stationdropdown_xpath);
        }
        
        [When(@"I click on the Customer field")]
        public void WhenIClickOnTheCustomerField()
        {
            Click(attributeName_xpath, SubmitaClaim_Customerdropdown_xpath);
        }
        
        [Then(@"I will have a drop down list of ALL stations")]
        public void ThenIWillHaveADropDownListOfALLStations()
        {
            List<string> stationNamesUI = new List<string>();
            IList<IWebElement> stationNames = GlobalVariables.webDriver.FindElements(By.XPath(SubmitaClaim_StatiodropdownValues_xpath));


            for (int i =0; i<stationNames.Count; i++)
            {
                IWebElement element = stationNames.ElementAt(i);
                string elementText = element.Text.ToString().Trim();
                // skipping default 'select' option
                if (!elementText.Equals("Select..."))
                {
                    stationNamesUI.Add(stationNames[i].Text);
                }

            }

            List<string> stationNamesDB = DBHelper.StationList();
            Assert.AreEqual(stationNamesUI.Count, stationNamesDB.Count);
           
        }
        
        [Then(@"the stations will be listed in numerical, then alphabetical order")]
        public void ThenTheStationsWillBeListedInNumericalThenAlphabeticalOrder()
        {
            //Click(attributeName_xpath, SubmitaClaim_Stationdropdown_xpath);
            List<string> stationNamesUI = new List<string>();
            IList<IWebElement> stationNames = GlobalVariables.webDriver.FindElements(By.XPath(SubmitaClaim_StatiodropdownValues_xpath));
            Thread.Sleep(2000);
            for (int i = 0; i < stationNames.Count; i++)
            {
                IWebElement element = stationNames.ElementAt(i);
                string elementText = element.Text.ToString().Trim();
                // skipping default 'select' option
                if (!elementText.Equals("Select..."))
                {
                    stationNamesUI.Add(stationNames[i].Text);
                }

            }

            List<string> stationNamesDB = DBHelper.StationList();
            Assert.AreEqual(stationNamesUI.Count, stationNamesDB.Count);
            stationNamesDB.Sort();
            for (int i = 0; i < stationNamesDB.Count; i++)
            {
                //"".Replace()
                try
                {                
                    Assert.AreEqual(Regex.Replace(stationNamesDB.ElementAt(i), "\\s+", " "), 
                                    Regex.Replace(stationNamesUI.ElementAt(i), "\\s+", " "));
                }
                catch (AssertFailedException)
                {

                    Console.WriteLine(stationNamesDB.ElementAt(i)+ "," + stationNamesUI.ElementAt(i));
                }
            }
        }
        
        [Then(@"I will see a list of all customers of the station selected")]
        public void ThenIWillSeeAListOfAllCustomersOfTheStationSelected()
        {
            List<string> custNameList = new List<string>();
            IList<IWebElement> custNamesUI = GlobalVariables.webDriver.FindElements(By.XPath(SubmitaClaim_CustomerdropdownValues_xpath));
            for(int i=1; i< custNamesUI.Count; i++)
            {
                IWebElement element = custNamesUI.ElementAt(i);
                string elementText = element.Text.ToString().Trim();
                if (!elementText.Equals("All Accounts"))
                {
                    custNameList.Add(custNamesUI[i].Text);
                }
            }

            List<CustomerSetup> customerNameDB = DBHelper.GetAllCustomersForTheStations(stationId);
            List<string> cust = customerNameDB.Select(x => x.CustomerName).ToList();
            Assert.AreEqual(cust.Count, custNameList.Count);
        }
        
        [Then(@"the customer will be listed in hierarchy format")]
        public void ThenTheCustomerWillBeListedInHierarchyFormat()
        {
            IList<IWebElement> dropDownList = GlobalVariables.webDriver.FindElements(By.XPath(SubmitaClaim_CustomerdropdownValues_xpath));
            

            string customerNameActual = "35406Test";
            List<string> subAccList = new List<string>();
            List<string> customerNamesList = DBHelper.GetCustomerNameOfSubAccountUnderPrimaryAccount(customerNameActual);
           
            for (int i = 1; i < dropDownList.Count; i++)
            {
                IWebElement customerName = dropDownList.ElementAt(i);
                string customerNameText = customerName.Text.ToString();
                if (customerNameText.Equals("35406Test"))
                {

                    for(int j=0; j<2; j++)
                    {
                        int x = i + j +2;
                        IList<IWebElement> subAcc = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='CustomerNames_chosen']/div/ul/li["+x+"]"));
                        subAccList.Add(subAcc.ToString());

                    }
                }
             }

           

        }

        [Then(@"the customers will be listed in alphabetical format")]
        public void ThenTheCustomersWillBeListedInAlphabeticalFormat()
        {
            IList<IWebElement> dropdownList = GlobalVariables.webDriver.FindElements(By.XPath(".//li[contains (@class,'level0')]"));
            List<string> actualDrodownList = new List<string>();
            List<string> sortedDrodownList = new List<string>();
            foreach (IWebElement element in dropdownList)
            {
                string elementText = element.Text;
                if (!"All Accounts".Equals(elementText))
                {
                    actualDrodownList.Add(elementText);
                    sortedDrodownList.Add(elementText);
                }
            }

            sortedDrodownList.Sort();

            // validating
            for (int pos = 0; pos < actualDrodownList.Count; ++pos)
            {
                if (!actualDrodownList.ElementAt(pos).Equals(sortedDrodownList.ElementAt(pos)))
                {
                    Assert.IsTrue(false);
                }
            }

            Assert.IsTrue(true);
        }
    }
}
