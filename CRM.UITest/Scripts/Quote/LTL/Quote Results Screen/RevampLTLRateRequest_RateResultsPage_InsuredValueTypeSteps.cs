using System;
using System.Threading;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using CRM.UITest.Objects;
using CRM.UITest.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Linq;

namespace CRM.UITest.Scripts.Quote.LTL.Quote_Results_Screen 
{
    [Binding]
    public class RevampLTLRateRequest_RateResultsPage_InsuredValueTypeSteps : ObjectRepository
    {
        
        [Then(@"I should be display with the rates for new type only for all carriers on results page")]
        public void ThenIShouldBeDisplayWithTheRatesForNewTypeOnlyForAllCarriersOnResultsPage()
        {

            Report.WriteLine("User displaying with New and Used amount decimal to two places");
            IList<IWebElement> list = GlobalVariables.webDriver.FindElements(By.XPath(ltl_carriernewused_all));

            if (list.Count > 0)
            {

                IList<IWebElement> ltlcarriernew = GlobalVariables.webDriver.FindElements(By.XPath(ltl_carriernewused_all));
                List<string> ltlcarriernew1 = new List<string>();
                foreach (IWebElement element in ltlcarriernew)
                {

                    ltlcarriernew1.Add((element.Text).ToString());


                }

                int size1 = ltlcarriernew1.Count;
                for (int i = 0; i < size1; i++)
                {

                    var onlyLetters = new String(ltlcarriernew1[i].Where(Char.IsLetter).ToArray());
                    string expected = "New";
                    Assert.AreEqual(onlyLetters, expected);


                }


            }
        }

    [Then(@"I should be display with the rates for used type only for all carriers on results page")]
        public void ThenIShouldBeDisplayWithTheRatesForUsedTypeOnlyForAllCarriersOnResultsPage()
        {
            Report.WriteLine("User displaying with New and Used amount decimal to two places");
            IList<IWebElement> list = GlobalVariables.webDriver.FindElements(By.XPath(ltl_carriernewused_all));

            if (list.Count > 0)
            {

                IList<IWebElement> ltlcarriernew = GlobalVariables.webDriver.FindElements(By.XPath(ltl_carriernewused_all));
                List<string> ltlcarriernew1 = new List<string>();
                foreach (IWebElement element in ltlcarriernew)
                {

                    ltlcarriernew1.Add((element.Text).ToString());


                }

                int size1 = ltlcarriernew1.Count;
                for (int i = 0; i < size1; i++)
                {

                    var onlyLetters = new String(ltlcarriernew1[i].Where(Char.IsLetter).ToArray());
                    string expected = "Used";
                    Assert.AreEqual(onlyLetters, expected);


                }


            }
        }
        
        [Then(@"I should be display with the rates for new and  used types for all carriers on  results page")]
        public void ThenIShouldBeDisplayWithTheRatesForNewAndUsedTypesForAllCarriersOnResultsPage()
        {
            Report.WriteLine("User displaying with New and Used amount decimal to two places");
            IList<IWebElement> list = GlobalVariables.webDriver.FindElements(By.XPath(ltl_carriernewused_all));

            if (list.Count > 0)
            {

                IList<IWebElement> ltlcarriernew = GlobalVariables.webDriver.FindElements(By.XPath(ltl_carriernewused_all));
                List<string> ltlcarriernew1 = new List<string>();
                foreach (IWebElement element in ltlcarriernew)
                {

                    ltlcarriernew1.Add((element.Text).ToString());


                }

                int size1 = ltlcarriernew1.Count;
                for (int i = 0; i < size1; i++)
                {

                    var onlyLetters = new String(ltlcarriernew1[i].Where(Char.IsLetter).ToArray());
                    string expected = "NewUsed";
                    Assert.AreEqual(onlyLetters, expected);


                }


            }
        }

        [Then(@"I should be display with the rates for new type only for all carriers on guaranteed grid results page")]
        public void ThenIShouldBeDisplayWithTheRatesForNewTypeOnlyForAllCarriersOnGuaranteedGridResultsPage()
        {
            Report.WriteLine("User displaying with New and Used amount decimal to two places");
            IList<IWebElement> list = GlobalVariables.webDriver.FindElements(By.XPath(ltl_carriernewused_G_all));

            if (list.Count > 0)
            {

                IList<IWebElement> ltlcarriernew = GlobalVariables.webDriver.FindElements(By.XPath(ltl_carriernewused_G_all));
                List<string> ltlcarriernew1 = new List<string>();
                foreach (IWebElement element in ltlcarriernew)
                {

                    ltlcarriernew1.Add((element.Text).ToString());


                }

                int size1 = ltlcarriernew1.Count;
                for (int i = 0; i < size1; i++)
                {

                    var onlyLetters = new String(ltlcarriernew1[i].Where(Char.IsLetter).ToArray());
                    string expected = "New";
                    Assert.AreEqual(onlyLetters, expected);


                }


            }
        }


        [Then(@"I should be display with the rates for used type only for all carriers on guaranteed grid results page")]
        public void ThenIShouldBeDisplayWithTheRatesForUsedTypeOnlyForAllCarriersOnGuaranteedGridResultsPage()
        {
            Report.WriteLine("User displaying with New and Used amount decimal to two places");
            IList<IWebElement> list = GlobalVariables.webDriver.FindElements(By.XPath(ltl_carriernewused_G_all));

            if (list.Count > 0)
            {

                IList<IWebElement> ltlcarriernew = GlobalVariables.webDriver.FindElements(By.XPath(ltl_carriernewused_G_all));
                List<string> ltlcarriernew1 = new List<string>();
                foreach (IWebElement element in ltlcarriernew)
                {

                    ltlcarriernew1.Add((element.Text).ToString());


                }

                int size1 = ltlcarriernew1.Count;
                for (int i = 0; i < size1; i++)
                {

                    var onlyLetters = new String(ltlcarriernew1[i].Where(Char.IsLetter).ToArray());
                    string expected = "Used";
                    Assert.AreEqual(onlyLetters, expected);


                }


            }
        }
        
        [Then(@"I should be display with the rates for new and  used types for all carriers on guaranteed grid results page")]
        public void ThenIShouldBeDisplayWithTheRatesForNewAndUsedTypesForAllCarriersOnGuaranteedGridResultsPage()
        {
            Report.WriteLine("User displaying with New and Used amount decimal to two places");
            IList<IWebElement> list = GlobalVariables.webDriver.FindElements(By.XPath(ltl_carriernewused_G_all));

            if (list.Count > 0)
            {

                IList<IWebElement> ltlcarriernew = GlobalVariables.webDriver.FindElements(By.XPath(ltl_carriernewused_G_all));
                List<string> ltlcarriernew1 = new List<string>();
                foreach (IWebElement element in ltlcarriernew)
                {

                    ltlcarriernew1.Add((element.Text).ToString());


                }

                int size1 = ltlcarriernew1.Count;
                for (int i = 0; i < size1; i++)
                {

                    var onlyLetters = new String(ltlcarriernew1[i].Where(Char.IsLetter).ToArray());
                    string expected = "NewUsed";
                    Assert.AreEqual(onlyLetters, expected);


                }


            }
        }
        [When(@"I Select New insured type from '(.*)' dropdown")]
        public void WhenISelectNewInsuredTypeFromDropdown(string InsuredvalueType)
        {
            
                Report.WriteLine("Select Insured type from dropdown");
                Click(attributeName_xpath, InsuredType_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, InsuredValueTypeDropDown_Xpath, InsuredvalueType);
            
        }
        [When(@"I Click On view quote results button")]
        public void WhenIClickOnViewQuoteResultsButton()
        {
            Report.WriteLine("Click on Quote Results");
            try
            {
                Click(attributeName_id, LTL_ViewQuoteResults_Id);
                Thread.Sleep(70000);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            WaitForElementPresent(attributeName_xpath, ltlQuoteResultsheader_xpath, "waitforheader");
        }
        [When(@"I Select Used insured type from '(.*)' dropdown")]
        public void WhenISelectUsedInsuredTypeFromDropdown(string InsuredvalueType)
        {
            Report.WriteLine("Select Insured type from dropdown");
            Click(attributeName_xpath, InsuredType_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, InsuredValueTypeDropDown_Xpath, InsuredvalueType);
        }



        [Then(@"I select '(.*)' on the Create shipment modal")]
        public void ThenISelectOnTheCreateShipmentModal(string InsuredType)
        {
            Report.WriteLine("Select Insured type from dropdown");
            Click(attributeName_xpath, InsmodalInsuredType_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, InsmodalInsuredValueTypeDropDown_Xpath, InsuredType);
        }
        [Then(@"I Will be displayed with pop up modal")]
        public void ThenIWillBeDisplayedWithPopUpModal()
        {
            Report.WriteLine("pop up displayed");
            Thread.Sleep(500);
            VerifyElementPresent(attributeName_xpath, ltlinsmodal_xpath, "insuredmodalpopup");
        }
        [Then(@"I selected '(.*)' on Rate Results Page")]
        public void ThenISelectedOnRateResultsPage(string InsuredType)
        {
            Report.WriteLine("Select Insured type from dropdown");
            Click(attributeName_xpath, InsuredType_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, InsuredValueTypeDropDown_Xpath, InsuredType);
        }

    }
}
