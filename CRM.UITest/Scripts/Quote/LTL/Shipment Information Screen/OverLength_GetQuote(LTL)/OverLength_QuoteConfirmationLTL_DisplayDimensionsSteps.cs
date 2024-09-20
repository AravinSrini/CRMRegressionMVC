using System;
using System.Threading;
using System.Collections.Generic;
using System.Configuration;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;

namespace CRM.UITest.Scripts.Quote.LTL.Shipment_Information_Screen.OverLength_GetQuote_LTL_
{
    [Binding]
    public class OverLength_QuoteConfirmationLTL_DisplayDimensionsSteps:ObjectRepository
    {
        CommonQuoteNavigations navigationtoConfirmationPage_LTL = new CommonQuoteNavigations();
        string userName = ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();
        string userType = "External";
        string customerAcc = "ZZZ - Czar Customer Test";
        [Given(@"I am on Quote Confirmation LTL page")]
        public void GivenIAmOnQuoteConfirmationLTLPage()
        {
            navigationtoConfirmationPage_LTL.NavigatetoQuoteConfirmationFromQuoteListWithServices(userType, customerAcc, userName,"10","11","12", "Overlength");
            WaitForElementVisible(attributeName_xpath, LTL_QuoteConfirmationPageHeader_Xpath, "confirmpage");
        }

        [Given(@"I am on LTL Quote Confirmation Page which contains Dimension values")]
        public void GivenIAmOnLTLQuoteConfirmationPageWhichContainsDimensionValues()
        {
            navigationtoConfirmationPage_LTL.NavigatetoQuoteConfirmationFromQuoteListWithServices(userType, customerAcc, userName, "10", "10", "10", "Overlength");
            WaitForElementVisible(attributeName_xpath, LTL_QuoteConfirmationPageHeader_Xpath, "confirmpage");
        }

        [Given(@"I am on LTL Quote Confirmation Page which do not have Dimension values")]
        public void GivenIAmOnLTLQuoteConfirmationPageWhichDoNotHaveDimensionValues()
        {
            navigationtoConfirmationPage_LTL.NavigatetoQuoteConfirmationFromQuoteListwithoutservices(userType, customerAcc, userName);
            WaitForElementVisible(attributeName_xpath, LTL_QuoteConfirmationPageHeader_Xpath, "confirmpage");
        }

        [Given(@"I am on Get Quote LTL page with no dimension values passed for selected accessorial type Overlength")]
        public void GivenIAmOnGetQuoteLTLPageWithNoDimensionValuesPassedForSelectedAccessorialTypeOverlength()
        {
            navigationtoConfirmationPage_LTL.QuotewithOverLengthNoDimensions(userType, customerAcc, "Overlength");
        }

        [Given(@"I am on LTL Quote Confirmation Page with an accessorial type other than overlength")]
        public void GivenIAmOnLTLQuoteConfirmationPageWithAnAccessorialTypeOtherThanOverlength()
        {
            navigationtoConfirmationPage_LTL.NavigatetoQuoteConfirmationFromQuoteListWithServices(userType, customerAcc, userName, "10", "10", "10", "Appointment");
            WaitForElementVisible(attributeName_xpath, LTL_QuoteConfirmationPageHeader_Xpath, "confirmpage");
        }              
        
        [When(@"I expand the View Quote Details section")]
        public void WhenIExpandTheViewQuoteDetailsSection()
        {
            Report.WriteLine("Expand the Quote details section");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, LTL_QC_ShowQuoteDetails_Id);
            WaitForElementVisible(attributeName_xpath, LTL_QC_ShipmentInformationHeader_Xpath, "Shipment Information");
        }

        [When(@"I click on View Quote Resultsbutton")]
        public void WhenIClickOnViewQuoteResultsbutton()
        {
            Click(attributeName_id, LTL_ViewQuoteResults_Id);
        }

        [Then(@"Dimensions will be displayed under Freight Information section between Class and Value columns")]
        public void ThenDimensionsWillBeDisplayedUnderFreightInformationSectionBetweenClassAndValueColumns()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            scrollElementIntoView(attributeName_xpath, LTL_QC_FrightDescriptionHeader_Xpath);
            string FrightDimensionscolumn_UI = Gettext(attributeName_xpath, LTL_QC_FreightDimensions_Xpath);
            Assert.AreEqual("Dimensions".ToUpper(), FrightDimensionscolumn_UI);
        }
        
        [Then(@"dimensions L W H will be displayed in bold")]
        public void ThenDimensionsLWHWillBeDisplayedInBold()
        {
            scrollElementIntoView(attributeName_xpath, LTL_QC_FrightDescriptionHeader_Xpath);
            IList<IWebElement> dimensionValues=GlobalVariables.webDriver.FindElements(By.XPath("//*[@id='GetRateFrieghtInfo']//td[4]/span[@style='font-weight:bold']"));
            List<string> dimensionvaluesUI = new List<string>();
            foreach (IWebElement element in dimensionValues)
            {
                dimensionvaluesUI.Add((element.Text));
            }

            for (int i = 0; i < dimensionvaluesUI.Count; i++)
            {
                if (dimensionvaluesUI[i].Contains("L")&&dimensionvaluesUI[i].Contains("W") && dimensionvaluesUI[i].Contains("H"))
                {                    
                    Report.WriteLine("Dimension Length, width and height are displaying in bold");
                }
                else
                {
                    Report.WriteLine("Dimension Length, width and height are not displaying in bold");
                }
            }
        }
        
        [Then(@"the values displayed next to L W H and dimensions type")]
        public void ThenTheValuesDisplayedNextToLWHAndDimensionsType()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            scrollElementIntoView(attributeName_xpath, LTL_QC_FrightDescriptionHeader_Xpath);
            IList<IWebElement> dimensionValues = GlobalVariables.webDriver.FindElements(By.XPath("//*[@id='GetRateFrieghtInfo']//td[4]/span"));
            Thread.Sleep(1000);
            List<string> dimensionvaluesUI = new List<string>();
            foreach (IWebElement element in dimensionValues)
            {
                dimensionvaluesUI.Add((element.Text).ToString());
            }
            
            Assert.AreEqual(dimensionvaluesUI[1], " 10");
            Assert.AreEqual(dimensionvaluesUI[3], " 10");
            Assert.AreEqual(dimensionvaluesUI[5], " 10");
            Assert.AreEqual(dimensionvaluesUI[6], " IN");
            Report.WriteLine("Length, width, height values displaying next to L W H");
        }
        
        [Then(@"'(.*)' will be displayed next to L W H and dimensions type")]
        public void ThenWillBeDisplayedNextToLWHAndDimensionsType(string p0)
        {
            scrollElementIntoView(attributeName_xpath, LTL_QC_FrightDescriptionHeader_Xpath);
            IList<IWebElement> dimensionValues = GlobalVariables.webDriver.FindElements(By.XPath("//*[@id='GetRateFrieghtInfo']//td[4]/span"));
            List<string> dimensionvaluesUI = new List<string>();
            foreach (IWebElement element in dimensionValues)
            {
                dimensionvaluesUI.Add((element.Text).ToString());
            }
            Assert.AreEqual(dimensionvaluesUI[1], " --");
            Assert.AreEqual(dimensionvaluesUI[3], " --");
            Assert.AreEqual(dimensionvaluesUI[5], " --");
            Assert.AreEqual(dimensionvaluesUI[6], " IN");
            Report.WriteLine("Length, width, height values displaying as -- next to L W H");
        }


        [Then(@"Length, Width and Height fields will highlight")]
        public void ThenLengthWidthAndHeightFieldsWillHighlight()
        {
            var lengthColor = GetCSSValue(attributeName_id, LTL_Length_Id, "background");
            var widthColor = GetCSSValue(attributeName_id, LTL_Width_Id, "background");
            var heightColor = GetCSSValue(attributeName_id, LTL_Height_Id, "background");
            if (lengthColor.Contains("rgb(251, 236, 236)")&& widthColor.Contains("rgb(251, 236, 236)")&& heightColor.Contains("rgb(251, 236, 236)"))
            {
                Report.WriteLine("Length, Width, Height highlighted in red color - user selected OverLength");
            }

            else
            {
                throw new Exception("Length, Width, Height not highlighted - user selected OverLength");
            }
        }
    }
}
