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

namespace CRM.UITest.Scripts.Quote.LTL
{
    [Binding]
    public class RateRequest_QuoteResults_DisplayDecimaltoTwoPlacesSteps : ObjectRepository
    {
        [Then(@"I must be displayed with New and Used amount decimal to two places")]
        public void ThenIMustBeDisplayedWithNewAndUsedAmountDecimalToTwoPlaces()
        {
            Report.WriteLine("User displaying with New and Used amount decimal to two places");
            IList<IWebElement> standardratelist = GlobalVariables.webDriver.FindElements(By.XPath(ltl_rateamount_NG_S));

            if (standardratelist.Count > 0)
            {

                IList<IWebElement> ltlcarriernew = GlobalVariables.webDriver.FindElements(By.XPath(ltl_carriernewused));
                List<string> ltlcarriernew1 = new List<string>();
                foreach (IWebElement element in ltlcarriernew)
                {

                    ltlcarriernew1.Add((element.Text).ToString());

                }

                int size1 = ltlcarriernew1.Count;
                for (int i = 0; i < size1; i++)
                {
                    string[] a = ltlcarriernew1[i].Split(new char[] { ' ', '.' });
                    int decimals = a[3].Length;
                    int expectedlenght = 2;
                    Assert.AreEqual(decimals, expectedlenght);
                    Console.WriteLine("rate Results Displaying Decimal to Two Places");
                }

                IList<IWebElement> ltlcarrierused = GlobalVariables.webDriver.FindElements(By.XPath(ltl_carriernewused));
                List<string> ltlcarrierused1 = new List<string>();
                foreach (IWebElement element in ltlcarriernew)
                {

                    ltlcarriernew1.Add((element.Text).ToString());

                }

                int size2 = ltlcarrierused1.Count;
                for (int i = 0; i < size2; i++)
                {
                    string[] a = ltlcarrierused1[i].Split(new char[] { ' ', '.' });
                    int decimals = a[7].Length;
                    int expectedlenght = 2;
                    Assert.AreEqual(decimals, expectedlenght);
                    Console.WriteLine("rate Results Displaying Decimal to Two Places");
                }

            }
        }



        [Then(@"I must be displayed with Rate, Fuel, Line Haul and Accessorials decimal to two places of Rate grid")]
        public void ThenIMustBeDisplayedWithRateFuelLineHaulAndAccessorialsDecimalToTwoPlacesOfRateGrid()
        {
            Report.WriteLine("User displaying with Rate Fuel LineHaul And Accessorials to two places");
            IList<IWebElement> standardratelist = GlobalVariables.webDriver.FindElements(By.XPath(ltl_rateamount_NG_S));

            if (standardratelist.Count > 0)
            {
                List<string> standardratelist1 = new List<string>();
                foreach (IWebElement element in standardratelist)
                {

                    standardratelist1.Add((element.Text).ToString().Remove(0, 3));

                }

                int size0 = standardratelist1.Count;
                for (int i = 0; i < size0; i++)
                {
                    string[] a = standardratelist1[i].Split(new char[] { '.' });
                    int decimals = a[1].Length;
                    int expectedlenght = 2;
                    Assert.AreEqual(decimals, expectedlenght);
                    Console.WriteLine("rate Results Displaying Decimal to Two Places");
                }

                IList<IWebElement> ltlfuelalllist = GlobalVariables.webDriver.FindElements(By.XPath(ltl_fuelall_NG_S));
                List<string> ltlfuelalllist1 = new List<string>();
                foreach (IWebElement element in ltlfuelalllist)
                {
                    ltlfuelalllist1.Add((element.Text).ToString().Remove(0, 8));
                }

                int size = ltlfuelalllist1.Count;
                for (int i = 0; i < size; i++)
                {

                    string[] a = ltlfuelalllist1[i].Split(new char[] { '.' });
                    int decimals = a[1].Length;
                    int expectedlenght = 2;
                    Assert.AreEqual(decimals, expectedlenght);
                    Console.WriteLine("rate Results Displaying Decimal to Two Places");
                }

                IList<IWebElement> alllinehaullist = GlobalVariables.webDriver.FindElements(By.XPath(ltl_alllinehaul_NG_S));
                List<string> alllinehaullist1 = new List<string>();
                foreach (IWebElement element in ltlfuelalllist)
                {
                    ltlfuelalllist1.Add((element.Text).ToString());
                }

                int size1 = ltlfuelalllist1.Count;
                for (int i = 0; i < size1; i++)
                {
                    string[] a = ltlfuelalllist1[i].Split(new char[] { '.' });
                    int decimals = a[1].Length;
                    int expectedlenght = 2;
                    Assert.AreEqual(decimals, expectedlenght);
                    Console.WriteLine("rate Results Displaying Decimal to Two Places");
                }


                IList<IWebElement> Accessorialsalllist = GlobalVariables.webDriver.FindElements(By.XPath(ltl_Accessorialsall_NG_S));
                List<string> Accessorialsalllist1 = new List<string>();
                foreach (IWebElement element in Accessorialsalllist)
                {
                    Accessorialsalllist1.Add((element.Text).ToString());
                }

                int size2 = Accessorialsalllist1.Count;
                for (int i = 0; i < size2; i++)
                {
                    string[] a = Accessorialsalllist1[i].Split(new char[] { '.' });
                    int decimals = a[1].Length;
                    int expectedlenght = 2;
                    Assert.AreEqual(decimals, expectedlenght);
                    Console.WriteLine("rate Results Displaying Decimal to Two Places");
                }


            }
        }


        [Then(@"I must be displayed with Insured Rate, Fuel, Line Haul and Accessorials decimal to two places of Insured Rate grid")]
        public void ThenIMustBeDisplayedWithInsuredRateFuelLineHaulAndAccessorialsDecimalToTwoPlacesOfInsuredRateGrid()
        {
            Report.WriteLine("User displaying with Insured Rate Fuel LineHaul And Accessorials to two places");
            IList<IWebElement> ltlrateamountlistins = GlobalVariables.webDriver.FindElements(By.XPath(ltl_rateamount_NG_I));


            if (ltlrateamountlistins.Count > 0)
            {
                List<string> ltlrateamountlistins1 = new List<string>();
                foreach (IWebElement element in ltlrateamountlistins)
                {

                    ltlrateamountlistins1.Add((element.Text).ToString().Remove(0, 3));

                }

                int size0 = ltlrateamountlistins1.Count;
                for (int i = 0; i < size0; i++)
                {
                    string[] a = ltlrateamountlistins1[i].Split(new char[] { '.' });
                    int decimals = a[1].Length;
                    int expectedlenght = 2;
                    Assert.AreEqual(decimals, expectedlenght);
                    Console.WriteLine("rate Results Displaying Decimal to Two Places");
                }

                IList<IWebElement> ltlfuelallinslist = GlobalVariables.webDriver.FindElements(By.XPath(ltl_fuelall_NG_I));

                List<string> ltlfuelalllist1 = new List<string>();
                foreach (IWebElement element in ltlfuelallinslist)
                {
                    ltlfuelalllist1.Add((element.Text).ToString().Remove(0, 8));
                }

                int size = ltlfuelalllist1.Count;
                for (int i = 0; i < size; i++)
                {

                    string[] a = ltlfuelalllist1[i].Split(new char[] { '.' });
                    int decimals = a[1].Length;
                    int expectedlenght = 2;
                    Assert.AreEqual(decimals, expectedlenght);
                    Console.WriteLine("rate Results Displaying Decimal to Two Places");
                }

                IList<IWebElement> alllinehaulinslist = GlobalVariables.webDriver.FindElements(By.XPath(ltl_alllinehaul_NG_I));
                List<string> alllinehaullist1 = new List<string>();
                foreach (IWebElement element in alllinehaulinslist)
                {
                    ltlfuelalllist1.Add((element.Text).ToString().Remove(0, 13));
                }

                int size1 = ltlfuelalllist1.Count;
                for (int i = 0; i < size1; i++)
                {
                    string[] a = ltlfuelalllist1[i].Split(new char[] { '.' });
                    int decimals = a[1].Length;
                    int expectedlenght = 2;
                    Assert.AreEqual(decimals, expectedlenght);
                    Console.WriteLine("rate Results Displaying Decimal to Two Places");
                }


                IList<IWebElement> Accessorialsalllist = GlobalVariables.webDriver.FindElements(By.XPath(ltl_Accessorialsall_NG_I));
                List<string> Accessorialsalllist1 = new List<string>();
                foreach (IWebElement element in Accessorialsalllist)
                {
                    Accessorialsalllist1.Add((element.Text).ToString().Remove(0, 16));
                }

                int size2 = Accessorialsalllist1.Count;
                for (int i = 0; i < size2; i++)
                {
                    string[] a = Accessorialsalllist1[i].Split(new char[] { '.' });
                    int decimals = a[1].Length;
                    int expectedlenght = 2;
                    Assert.AreEqual(decimals, expectedlenght);
                    Console.WriteLine("rate Results Displaying Decimal to Two Places");
                }


            }

        }

        [Then(@"I must be displayed with New and Used amount decimal to two places of Guaranteed Carrier Grid")]
        public void ThenIMustBeDisplayedWithNewAndUsedAmountDecimalToTwoPlacesOfGuaranteedCarrierGrid()
        {
            Report.WriteLine("User displaying with Guaranteed new and used amounts to two decimal places");
            IList<IWebElement> ltlcarriernewgua = GlobalVariables.webDriver.FindElements(By.XPath(ltl_carriernewused_G));

            if (ltlcarriernewgua.Count > 0)
            {
                                
                List<string> ltlcarriernewgua1 = new List<string>();
                foreach (IWebElement element in ltlcarriernewgua)
                {

                    ltlcarriernewgua1.Add((element.Text).ToString());

                }

                int size1 = ltlcarriernewgua1.Count;
                for (int i = 0; i < size1; i++)
                {
                    string[] a = ltlcarriernewgua1[i].Split(new char[] { ' ', '.' });
                    int decimals = a[3].Length;
                    int expectedlenght = 2;
                    Assert.AreEqual(decimals, expectedlenght);
                    Console.WriteLine("rate Results Displaying Decimal to Two Places");
                }

                IList<IWebElement> ltlcarrierusedgua = GlobalVariables.webDriver.FindElements(By.XPath(ltl_carriernewused));
                List<string> ltlcarrierusedgua1 = new List<string>();
                foreach (IWebElement element in ltlcarriernewgua)
                {

                    ltlcarriernewgua1.Add((element.Text).ToString());

                }

                int size2 = ltlcarrierusedgua1.Count;
                for (int i = 0; i < size2; i++)
                {
                    string[] a = ltlcarrierusedgua1[i].Split(new char[] { ' ', '.' });
                    int decimals = a[7].Length;
                    int expectedlenght = 2;
                    Assert.AreEqual(decimals, expectedlenght);
                    Console.WriteLine("rate Results Displaying Decimal to Two Places");
                }

            }
        }

        [Then(@"I should able to enter decimal value in (.*) text box")]
        public void ThenIShouldAbleToEnterDecimalValueInTextBox(String ShipmentValue)
        {

            Report.WriteLine("Shipment Value Text box should accept values");
            SendKeys(attributeName_xpath, ltlEnterInsuredValueTextbox_xpath, ShipmentValue);
            Thread.Sleep(1000);
        }

        [Then(@"I must be displayed all rates with two decimal points")]
        public void ThenIMustBeDisplayedAllRatesWithTwoDecimalPoints()
        {
            Report.WriteLine("User displaying with Rate Fuel LineHaul And Accessorials to two places");
            IList<IWebElement> standardratelist = GlobalVariables.webDriver.FindElements(By.XPath(ltl_rateamount_NG_S));

            if (standardratelist.Count > 0)
            {
                List<string> standardratelist1 = new List<string>();
                foreach (IWebElement element in standardratelist)
                {

                    standardratelist1.Add((element.Text).ToString().Remove(0, 3));

                }

                int size0 = standardratelist1.Count;
                for (int i = 0; i < size0; i++)
                {
                    string[] a = standardratelist1[i].Split(new char[] { '.' });
                    int decimals = a[1].Length;
                    int expectedlenght = 2;
                    Assert.AreEqual(decimals, expectedlenght);
                    Console.WriteLine("rate Results Displaying Decimal to Two Places");
                }

                IList<IWebElement> ltlfuelalllist = GlobalVariables.webDriver.FindElements(By.XPath(ltl_fuelall_NG_S));
                List<string> ltlfuelalllist1 = new List<string>();
                foreach (IWebElement element in ltlfuelalllist)
                {
                    ltlfuelalllist1.Add((element.Text).ToString().Remove(0, 8));
                }

                int size = ltlfuelalllist1.Count;
                for (int i = 0; i < size; i++)
                {

                    string[] a = ltlfuelalllist1[i].Split(new char[] { '.' });
                    int decimals = a[1].Length;
                    int expectedlenght = 2;
                    Assert.AreEqual(decimals, expectedlenght);
                    Console.WriteLine("rate Results Displaying Decimal to Two Places");
                }

                IList<IWebElement> alllinehaullist = GlobalVariables.webDriver.FindElements(By.XPath(ltl_alllinehaul_NG_S));
                List<string> alllinehaullist1 = new List<string>();
                foreach (IWebElement element in ltlfuelalllist)
                {
                    ltlfuelalllist1.Add((element.Text).ToString());
                }

                int size1 = ltlfuelalllist1.Count;
                for (int i = 0; i < size1; i++)
                {
                    string[] a = ltlfuelalllist1[i].Split(new char[] { '.' });
                    int decimals = a[1].Length;
                    int expectedlenght = 2;
                    Assert.AreEqual(decimals, expectedlenght);
                    Console.WriteLine("rate Results Displaying Decimal to Two Places");
                }


                IList<IWebElement> Accessorialsalllist = GlobalVariables.webDriver.FindElements(By.XPath(ltl_Accessorialsall_NG_S));
                List<string> Accessorialsalllist1 = new List<string>();
                foreach (IWebElement element in Accessorialsalllist)
                {
                    Accessorialsalllist1.Add((element.Text).ToString());
                }

                int size2 = Accessorialsalllist1.Count;
                for (int i = 0; i < size2; i++)
                {
                    string[] a = Accessorialsalllist1[i].Split(new char[] { '.' });
                    int decimals = a[1].Length;
                    int expectedlenght = 2;
                    Assert.AreEqual(decimals, expectedlenght);
                    Console.WriteLine("rate Results Displaying Decimal to Two Places");
                }


            }
            IList<IWebElement> ltlrateamountlistins = GlobalVariables.webDriver.FindElements(By.XPath(ltl_rateamount_NG_I));


            if (ltlrateamountlistins.Count > 0)
            {
                List<string> ltlrateamountlistins1 = new List<string>();
                foreach (IWebElement element in ltlrateamountlistins)
                {

                    ltlrateamountlistins1.Add((element.Text).ToString().Remove(0, 3));

                }

                int size0 = ltlrateamountlistins1.Count;
                for (int i = 0; i < size0; i++)
                {
                    string[] a = ltlrateamountlistins1[i].Split(new char[] { '.' });
                    int decimals = a[1].Length;
                    int expectedlenght = 2;
                    Assert.AreEqual(decimals, expectedlenght);
                    Console.WriteLine("rate Results Displaying Decimal to Two Places");
                }

                IList<IWebElement> ltlfuelallinslist = GlobalVariables.webDriver.FindElements(By.XPath(ltl_fuelall_NG_I));

                List<string> ltlfuelalllist1 = new List<string>();
                foreach (IWebElement element in ltlfuelallinslist)
                {
                    ltlfuelalllist1.Add((element.Text).ToString().Remove(0, 8));
                }

                int size = ltlfuelalllist1.Count;
                for (int i = 0; i < size; i++)
                {

                    string[] a = ltlfuelalllist1[i].Split(new char[] { '.' });
                    int decimals = a[1].Length;
                    int expectedlenght = 2;
                    Assert.AreEqual(decimals, expectedlenght);
                    Console.WriteLine("rate Results Displaying Decimal to Two Places");
                }

                IList<IWebElement> alllinehaulinslist = GlobalVariables.webDriver.FindElements(By.XPath(ltl_alllinehaul_NG_I));
                List<string> alllinehaullist1 = new List<string>();
                foreach (IWebElement element in alllinehaulinslist)
                {
                    ltlfuelalllist1.Add((element.Text).ToString().Remove(0, 13));
                }

                int size1 = ltlfuelalllist1.Count;
                for (int i = 0; i < size1; i++)
                {
                    string[] a = ltlfuelalllist1[i].Split(new char[] { '.' });
                    int decimals = a[1].Length;
                    int expectedlenght = 2;
                    Assert.AreEqual(decimals, expectedlenght);
                    Console.WriteLine("rate Results Displaying Decimal to Two Places");
                }


                IList<IWebElement> Accessorialsalllist = GlobalVariables.webDriver.FindElements(By.XPath(ltl_Accessorialsall_NG_I));
                List<string> Accessorialsalllist1 = new List<string>();
                foreach (IWebElement element in Accessorialsalllist)
                {
                    Accessorialsalllist1.Add((element.Text).ToString().Remove(0, 16));
                }

                int size2 = Accessorialsalllist1.Count;
                for (int i = 0; i < size2; i++)
                {
                    string[] a = Accessorialsalllist1[i].Split(new char[] { '.' });
                    int decimals = a[1].Length;
                    int expectedlenght = 2;
                    Assert.AreEqual(decimals, expectedlenght);
                    Console.WriteLine("rate Results Displaying Decimal to Two Places");
                }


            }
        }

        [Then(@"I must be displayed with Rate, Fuel, Line Haul and Accessorials decimal to two places of Guaranteed Rate grid")]
        public void ThenIMustBeDisplayedWithRateFuelLineHaulAndAccessorialsDecimalToTwoPlacesOfGuaranteedRateGrid()
        {

            Report.WriteLine("User displaying with Guaranteed Rate Fuel LineHaul And Accessorials to two places");
            IList<IWebElement> ltlgaurntrateslist = GlobalVariables.webDriver.FindElements(By.XPath(ltl_rateamount_G_S));


            if (ltlgaurntrateslist.Count > 0)
            {
                List<string> ltlgaurntrateslist1 = new List<string>();
                foreach (IWebElement element in ltlgaurntrateslist)
                {

                    ltlgaurntrateslist1.Add((element.Text).ToString().Remove(0, 3));

                }

                int size0 = ltlgaurntrateslist1.Count;
                for (int i = 0; i < size0; i++)
                {
                    string[] a = ltlgaurntrateslist1[i].Split(new char[] { '.' });
                    int decimals = a[1].Length;
                    int expectedlenght = 2;
                    Assert.AreEqual(decimals, expectedlenght);
                    Console.WriteLine("rate Results Displaying Decimal to Two Places");
                }
                IList<IWebElement> ltlfuelalllist = GlobalVariables.webDriver.FindElements(By.XPath(ltl_fuelall_G_S));
                List<string> ltlfuelalllist1 = new List<string>();
                foreach (IWebElement element in ltlfuelalllist)
                {
                    ltlfuelalllist1.Add((element.Text).ToString());
                }
                List<Decimal> ltlfuelalllist2 = new List<Decimal>();
                int size = ltlfuelalllist1.Count;
                for (int i = 0; i < size; i++)
                {

                    string[] a = ltlfuelalllist1[i].Split(new char[] { '.' });
                    int decimals = a[1].Length;
                    int expectedlenght = 2;
                    Assert.AreEqual(decimals, expectedlenght);
                    Console.WriteLine("rate Results Displaying Decimal to Two Places");
                }

                IList<IWebElement> alllinehaullist = GlobalVariables.webDriver.FindElements(By.XPath(ltl_alllinehaul_G_S));
                List<string> alllinehaullist1 = new List<string>();
                foreach (IWebElement element in ltlfuelalllist)
                {
                    ltlfuelalllist1.Add((element.Text).ToString());
                }
                List<Decimal> alllinehaullist2 = new List<Decimal>();
                int size1 = ltlfuelalllist1.Count;
                for (int i = 0; i < size1; i++)
                {
                    string[] a = ltlfuelalllist1[i].Split(new char[] { '.' });
                    int decimals = a[1].Length;
                    int expectedlenght = 2;
                    Assert.AreEqual(decimals, expectedlenght);
                    Console.WriteLine("rate Results Displaying Decimal to Two Places");
                }

                IList<IWebElement> Accessorialsalllist = GlobalVariables.webDriver.FindElements(By.XPath(ltl_Accessorialsall_G_S));
                List<string> Accessorialsalllist1 = new List<string>();
                foreach (IWebElement element in Accessorialsalllist)
                {
                    Accessorialsalllist1.Add((element.Text).ToString());
                }
                List<Decimal> Accessorialsalllist2 = new List<Decimal>();
                int size2 = Accessorialsalllist1.Count;
                for (int i = 0; i < size2; i++)
                {
                    string[] a = Accessorialsalllist1[i].Split(new char[] { '.' });
                    int decimals = a[1].Length;
                    int expectedlenght = 2;
                    Assert.AreEqual(decimals, expectedlenght);
                    Console.WriteLine("rate Results Displaying Decimal to Two Places");
                }
            }
        }

        [Then(@"I must be displayed with Insured Rate, Fuel, Line Haul and Accessorials decimal to two places of Guaranteed Insured Rate grid")]
        public void ThenIMustBeDisplayedWithInsuredRateFuelLineHaulAndAccessorialsDecimalToTwoPlacesOfGuaranteedInsuredRateGrid()
        {
            Report.WriteLine("User displaying with Guaranteed Insured Rate Fuel LineHaul And Accessorials to two places");
            IList<IWebElement> ltlguarantinsratelist = GlobalVariables.webDriver.FindElements(By.XPath(ltl_ltl_rateamount_G_I));
            if (ltlguarantinsratelist.Count > 0)
            {
                if (ltlguarantinsratelist.Count > 0)
                {
                    List<string> ltlguarantinsratelist1 = new List<string>();
                    foreach (IWebElement element in ltlguarantinsratelist)
                    {

                        ltlguarantinsratelist1.Add((element.Text).ToString().Remove(0, 3));

                    }

                    int size0 = ltlguarantinsratelist1.Count;
                    for (int i = 0; i < size0; i++)
                    {
                        string[] a = ltlguarantinsratelist1[i].Split(new char[] { '.' });
                        int decimals = a[1].Length;
                        int expectedlenght = 2;
                        Assert.AreEqual(decimals, expectedlenght);
                        Console.WriteLine("rate Results Displaying Decimal to Two Places");
                    }
                    IList<IWebElement> ltlfuelallinslist = GlobalVariables.webDriver.FindElements(By.XPath(ltl_fuelall_G_I));
                    List<string> ltlfuelallinslist1 = new List<string>();
                    foreach (IWebElement element in ltlfuelallinslist)
                    {
                        ltlfuelallinslist1.Add((element.Text).ToString());
                    }
                    List<Decimal> ltlfuelallinslist2 = new List<Decimal>();
                    int size = ltlfuelallinslist1.Count;
                    for (int i = 0; i < size; i++)
                    {

                        string[] a = ltlfuelallinslist1[i].Split(new char[] { '.' });
                        int decimals = a[1].Length;
                        int expectedlenght = 2;
                        Assert.AreEqual(decimals, expectedlenght);
                        Console.WriteLine("rate Results Displaying Decimal to Two Places");
                    }

                    IList<IWebElement> alllinehaulinslist = GlobalVariables.webDriver.FindElements(By.XPath(ltl_alllinehaul_G_I));
                    List<string> alllinehaullist1 = new List<string>();
                    foreach (IWebElement element in alllinehaulinslist)
                    {
                        alllinehaullist1.Add((element.Text).ToString());
                    }

                    int size1 = alllinehaullist1.Count;
                    for (int i = 0; i < size1; i++)
                    {

                        string[] a = alllinehaullist1[i].Split(new char[] { '.' });
                        int decimals = a[1].Length;
                        int expectedlenght = 2;
                        Assert.AreEqual(decimals, expectedlenght);
                        Console.WriteLine("rate Results Displaying Decimal to Two Places");
                    }


                    IList<IWebElement> Accessorialsalllist = GlobalVariables.webDriver.FindElements(By.XPath(ltl_Accessorialsall_G_I));
                    List<string> Accessorialsalllist1 = new List<string>();
                    foreach (IWebElement element in Accessorialsalllist)
                    {
                        Accessorialsalllist1.Add((element.Text).ToString());
                    }
                    List<Decimal> Accessorialsalllist2 = new List<Decimal>();
                    int size2 = Accessorialsalllist1.Count;
                    for (int i = 0; i < size2; i++)
                    {
                        string[] a = Accessorialsalllist1[i].Split(new char[] { '.' });
                        int decimals = a[1].Length;
                        int expectedlenght = 2;
                        Assert.AreEqual(decimals, expectedlenght);
                        Console.WriteLine("rate Results Displaying Decimal to Two Places");
                    }



                }

            }
        }
    }
}
