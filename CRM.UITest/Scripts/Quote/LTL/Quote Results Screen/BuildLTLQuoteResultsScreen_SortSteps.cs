using System;
using TechTalk.SpecFlow;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Data;

namespace CRM.UITest.Scripts.Quote.LTL
{
    [Binding]
    public class BuildLTLQuoteResultsScreen_SortSteps : ObjectRepository
    {

        
        [Then(@"I should display with the export button")]
        public void ThenIShouldDisplayWithTheExportButton()
        {
            Report.WriteLine("Display export button");
            VerifyElementPresent(attributeName_xpath, ltlExportBtn_xpath, "export button");
        }

        [Then(@"I click on export button on rate results page and results should be exported in excel")]
        public void ThenIClickOnExportButtonOnRateResultsPageAndResultsShouldBeExportedInExcel()
        {
            Report.WriteLine("clicked on export button");
            //string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            //path = System.IO.Path.Combine(path, "test");
            //if (!Directory.Exists(path))
            //{
            //    Directory.CreateDirectory(path);

            //}
            //string localPath = System.IO.Path.Combine(path, "RateAndCarrier.xls");
            Click(attributeName_xpath, ltlExportBtn_xpath);

            string downloadpath = GetDownloadedFilePath("RateAndCarrier.xls");
            List<string> columns = Excel_ReadColumnname(downloadpath);
            List<string> expectedColumnValues = new List<string>(new string[] { "Carrier", "Estimated Service Days", "Distance", "Fuel Charge", "Line Haul Charge", "Accessorial Charge", "StandardCharge", "InsuredFuelCharge", "InsuredLineHaulCharge", "InsuredAccessorialCharge", "InsuredCharge" }); 

            foreach (var s in columns)
            {
                if(expectedColumnValues.Contains(s))
                {
                    Report.WriteLine("Column name " + s + "displaying in exported excel sheet");
                }
                else
                {
                    Assert.Fail();
                }
            }
           // Excel_ReadAllData(downloadpath);


        }


        [Then(@"grid should be re-sorted by service with the Lowest price first on select leastcost button")]
        public void ThenGridShouldBeRe_SortedByServiceWithTheLowestPriceFirstOnSelectLeastcostButton()
        {

            IList<IWebElement> RateListbefore = GlobalVariables.webDriver.FindElements(By.XPath(ltlstandardratesall_xpath));

            if (RateListbefore.Count > 0)
            {
                List<string> InitialRate = new List<string>();
                foreach (IWebElement element in RateListbefore)
                {
                    InitialRate.Add((element.Text).ToString());
                }
                List<Decimal> Rate = new List<Decimal>();
                int size = InitialRate.Count;
                for (int i = 0; i < size; i++)
                {
                    
                    string[] RateListB = InitialRate[i].Split('*', ' ', '$');//After Click list
                    Decimal RateB = Convert.ToDecimal(RateListB[size]);
                    Rate.Add(RateB);
                }
                
                Rate.Sort();

                //After Click Least Cost Radio button
                Click(attributeName_xpath, ltlLeastcostRadioBtn_xpath);
                IList<IWebElement> rows_table1 = GlobalVariables.webDriver.FindElements(By.XPath(ltlstandardratesall_xpath));
                List<string> validat = new List<string>();
                foreach (IWebElement element in rows_table1)
                {
                    validat.Add(element.Text.ToString());
                }
                int TotalRateCount = 0;
                int sizeaftersort = validat.Count;
                for (int i = 0; i < sizeaftersort; i++)
                {
                    string[] RateListD = validat[i].Split('*', ' ', '$');
                    Decimal ActualRate = Convert.ToDecimal(Rate[i]);
                    Decimal ExpectedRate = Convert.ToDecimal(RateListD[sizeaftersort]);
                    if (ExpectedRate == ActualRate)
                    {
                        TotalRateCount++;
                        Console.WriteLine(ExpectedRate + " : " + ActualRate);
                    }
                }

                if (TotalRateCount == InitialRate.Count)
                {
                    Console.WriteLine("Rate Lists are sorted Successfully");
                }
                else
                {
                    throw new System.Exception("Rate Lists are Not sorted");
                }
            }
            else
            {
                throw new System.Exception("No Carriers with Rate Available");
            }
        }

        [Then(@"grid should be re-sorted by service with the quickest service first on select quickest service")]
        public void ThenGridShouldBeRe_SortedByServiceWithTheQuickestServiceFirstOnSelectQuickestService()
        {
            IList<IWebElement> serviceListbefore = GlobalVariables.webDriver.FindElements(By.XPath(ltlservicedaysall_xpath));

            if (serviceListbefore.Count > 0)
            {
                List<string> IntialDays = new List<string>();
                foreach (IWebElement element in serviceListbefore)
                {
                    IntialDays.Add(element.Text.ToString());
                }

                IntialDays.Sort();

                //after click

                Click(attributeName_xpath, ltlQuickestSrvcRadioBtn_xpath);

                IList<IWebElement> dayslistafter1 = GlobalVariables.webDriver.FindElements(By.XPath(ltlservicedaysall_xpath));

                List<string> validat = new List<string>();

                foreach (IWebElement element in dayslistafter1)
                {
                    validat.Add(element.Text.ToString());
                }

                int TotalDaysCount = 0;

                for (int i = 0; i < validat.Count; i++)
                {
                    string[] dayB = validat[i].Split(' ');
                    int ActualSortedDays = int.Parse(dayB[0]);

                    string[] dayC = IntialDays[i].Split(' ');
                    int ExpectedSortedDays = int.Parse(dayC[0]);

                    if (ExpectedSortedDays == ActualSortedDays)
                    {
                        TotalDaysCount++;
                        Console.WriteLine(ExpectedSortedDays + " : " + ActualSortedDays);
                    }
                }

                if (TotalDaysCount == IntialDays.Count)
                {
                    Console.WriteLine("Day Lists are sorted");
                }
                else
                {
                    throw new System.Exception("Day Lists Not equal");
                }
            }
            else
            {
                throw new System.Exception("No Carriers with Rate Available");

            }
        }


        [When(@"I clicks on the Terms and Conditions link")]
        public void WhenIClicksOnTheTermsAndConditionsLink()
        {
            Report.WriteLine("Click on Terms and conditions link");
            Click(attributeName_xpath, Instypeselected_xpath);
            Click(attributeName_xpath, ltlTermsandConditionslnk_xpath);
        }

        [When(@"Click on Download DLSW Claim Form displaying in Terms and Conditions modal results page")]
        public void WhenClickOnDownloadDLSWClaimFormDisplayingInTermsAndConditionsModalResultsPage()
        {

            Report.WriteLine("Click on Terms and conditions link");
            MoveToElement(attributeName_xpath, ltldownloadbtn_xpath);
            Click(attributeName_xpath, ltldownloadbtn_xpath);
        }


        [Then(@"I should be displayed with the Terms and Conditions Modal")]
        public void ThenIShouldBeDisplayedWithTheTermsAndConditionsModal()
        {
            Report.WriteLine("Display Terms and Conditions modal");
            VerifyElementPresent(attributeName_xpath, ltltermsncndtnspopupheader_xpath, "TERMS AND CONDITIONS OF COVERAGE");
        }

        [Then(@"I should be displayed with Download DLSW Claim Form")]
        public void ThenIShouldBeDisplayedWithDownloadDLSWClaimForm()
        {
            Report.WriteLine("Display Download DLSW Claim Form");
            VerifyElementPresent(attributeName_xpath, ltlDownloadDLSW_xpath, "Download DLSW Claim Form");
        }

        [Then(@"I should be displayed with Close button")]
        public void ThenIShouldBeDisplayedWithCloseButton()
        {
            Report.WriteLine("Display Close button in Terms and Conditions pop up");
            VerifyElementPresent(attributeName_xpath, ltltermsncndtnspopupclose_xpath, "Close");
        }

        [Then(@"I click on the Close button Modal should close")]
        public void ThenIClickOnTheCloseButtonModalShouldClose()
        {
            Report.WriteLine("Click on Close button in Terms and Conditions Modal");
            Thread.Sleep(2000);
            Click(attributeName_xpath, ltltermsncndtnspopupclose_xpath);
            Thread.Sleep(1000);
            VerifyElementNotVisible(attributeName_xpath, Errorpopupheader_xpath,"closed");

        }

        [Then(@"I should be displayed with a grid for Guaranteed Rate carriers")]
        public void ThenIShouldBeDisplayedWithAGridForGuaranteedRateCarriers()
        {
            Report.WriteLine("display gaurenteed rate link");
            VerifyElementPresent(attributeName_xpath, ltlguarenteedrategrid_xpath, "guarenteedratelink");
        }

        [Then(@"I will be displayed with the GUARANTEED RATE under the carrier name")]
        public void ThenIWillBeDisplayedWithTheGUARANTEEDRATEUnderTheCarrierName()
        {
            Report.WriteLine("Display Guaranteed Rate hyperlink");
            VerifyElementPresent(attributeName_xpath, ltlGuaranteedRateAvbllnk_xpath, "Guaranteed Rate Available");
        }

        [Then(@"I click on the Guaranteed Rate carriers hyperlink")]
        public void ThenIClickOnTheGuaranteedRateCarriersHyperlink()
        {
            Report.WriteLine("Click on Guaranteed Rate hyperlink");
            Click(attributeName_xpath, ltlGuaranteedRateAvbllnk_xpath);
        }

        [Then(@"I should be navigated to Guaranteed Rate carriers grid")]
        public void ThenIShouldBeNavigatedToGuaranteedRateCarriersGrid()
        {
            Report.WriteLine("Guaranteed Rate carriers grid");
            MoveToElement(attributeName_xpath, ltlguarenteedrategrid_xpath);
        }

    }
}