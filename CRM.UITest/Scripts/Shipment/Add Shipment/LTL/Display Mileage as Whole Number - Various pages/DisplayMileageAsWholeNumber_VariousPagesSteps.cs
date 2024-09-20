using System;
using System.Collections.Generic;
using System.Configuration;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;


namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Display_Mileage_as_Whole_Number___Various_pages
{
    [Binding]
    public class DisplayMileageAsWholeNumber_VariousPagesSteps : AddShipments
    {
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
        CommonShipmentNavigations shipmentnavigationsteps = new CommonShipmentNavigations();
        CommonQuoteNavigations quoteNavigationsteps = new CommonQuoteNavigations();
        string userType = "External";

        [Given(@"I am a shp\.entry, operations, sales, sales management, or station owner user")]
        public void GivenIAmAShp_EntryOperationsSalesSalesManagementOrStationOwnerUser()
        {
            string username = ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();
            string password = ConfigurationManager.AppSettings["ExternalUserPassword"].ToString();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"I am a shp\.inquiry, shp\.entry, operations, sales, sales management, or station owner user")]
        public void GivenIAmAShp_InquiryShp_EntryOperationsSalesSalesManagementOrStationOwnerUser()
        {
            string username = ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();
            string password = ConfigurationManager.AppSettings["ExternalUserPassword"].ToString();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"I am a shp\.inquiry, shp\.inquirynorates, shp\.entry, shp\.entrynorates, operations, sales, sales management, or station owner user")]
        public void GivenIAmAShp_InquiryShp_InquirynoratesShp_EntryShp_EntrynoratesOperationsSalesSalesManagementOrStationOwnerUser()
        {
            string username = ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();
            string password = ConfigurationManager.AppSettings["ExternalUserPassword"].ToString();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"I clicked on the View Shipment Details button of any displayed shipment on Shipment List Page")]
        public void GivenIClickedOnTheViewShipmentDetailsButtonOfAnyDisplayedShipmentOnShipmentListPage()
        {            
            Click(attributeName_cssselector, ShipmentsIcon_css);            
            Click(attributeName_xpath, ShipmentListGrid_RefNumAllValues_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
        }
        [When(@"I arrive on the LTL Shipment Results page")]
        public void WhenIArriveOnTheLTLShipmentResultsPage()
        {
            shipmentnavigationsteps.NavigatetoShipmentResultsPage(userType);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [When(@"I arrive on the Review and Submit page of LTL")]
        public void WhenIArriveOnTheReviewAndSubmitPageOfLTL()
        {
            shipmentnavigationsteps.NavigatetoShipmentReviewandSubmitPage(userType);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [When(@"I arrive on the Shipment Details page")]
        public void WhenIArriveOnTheShipmentDetailsPage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Mvc4Objects legacyObjects = new Mvc4Objects();
            VerifyElementVisible(attributeName_xpath, legacyObjects.ShipmentDetails_Header_Xpath, "Shipment Details");
        }

        [When(@"I arrive on the LTL Quote Results page")]
        public void WhenIArriveOnTheLTLQuoteResultsPage()
        {
            quoteNavigationsteps.NavigatetoQuoteResultsPage(userType);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Then(@"the mileage will be rounded as whole numbers on Results Page")]
        public void ThenTheMileageWillBeRoundedAsWholeNumbersOnResultsPage()
        {
            IList<IWebElement> distanceUI = GlobalVariables.webDriver.FindElements(By.XPath(ShipResults_DistanceColumnValues_Xpath));
            List<string> actualDistance = new List<string>();

            foreach (IWebElement element in distanceUI)
            {
                actualDistance.Add((element.Text).ToString().Replace(" miles", string.Empty).Replace(",", string.Empty));
            }
            List<string> distanceroundedvalues = new List<string>();

            for (int i = 0; i < actualDistance.Count; i++)
            {
                decimal roundedDistance = Math.Round(decimal.Parse(actualDistance[i]));
                distanceroundedvalues.Add(roundedDistance.ToString());
            }
            CollectionAssert.AreEqual(actualDistance, distanceroundedvalues);
            Report.WriteLine("Distance values are rounded whole numbers in Shipment Results Page");
                        
        }

        [Then(@"the mileage will be displayed with comma separated for greater than (.*) miles on Results Page")]
        public void ThenTheMileageWillBeDisplayedWithCommaSeparatedForGreaterThanMilesOnResultsPage(int p0)
        {
            IList<IWebElement> distanceUI = GlobalVariables.webDriver.FindElements(By.XPath(ShipResults_DistanceColumnValues_Xpath));
            List<string> actualDistance = new List<string>();
            foreach (IWebElement element in distanceUI)
            {
                actualDistance.Add((element.Text).ToString().Replace(" miles", string.Empty));
            }            

            for (int i = 0; i < actualDistance.Count; i++)
            {
                if (actualDistance[i].Contains(","))
                {                    
                    Console.WriteLine("Distance values separated with comma in Shipment Results Page");
                }
                else
                {
                    decimal expectedLength = 3;
                    decimal distanceLength=actualDistance[i].Length;
                    if (distanceLength > expectedLength)
                    {
                        Report.WriteFailure("Distance value is more than 999 but comma is not displayed in Shipment Results Page");
                    }
                    else
                    {
                        Console.WriteLine("Distance value is less than 999 hence comma is not expected in Shipment Results Page");
                    }
                    
                }                
            }
        }

        [Then(@"the mileage will be rounded as whole numbers on Review and Submit Page")]
        public void ThenTheMileageWillBeRoundedAsWholeNumbersOnReviewAndSubmitPage()
        {
            scrollElementIntoView(attributeName_xpath, ReviewSubmit_CarrierInfo_Distance_Xpath);
            string distanceinRSPage = Gettext(attributeName_xpath, ReviewSubmit_CarrierInfo_Distance_Value_Xpath);
            string actualdistanceinRSPage = distanceinRSPage.Replace(" miles", string.Empty).Replace(",", string.Empty);
            string roundedDistance=Math.Round(decimal.Parse(actualdistanceinRSPage)).ToString();
            Assert.AreEqual(roundedDistance, actualdistanceinRSPage);
            Report.WriteLine("Distance value rounded whole number in Review and Submit page");
        }

        [Then(@"the mileage will be displayed with comma separated for greater than (.*) miles on Review and Submit Page")]
        public void ThenTheMileageWillBeDisplayedWithCommaSeparatedForGreaterThanMilesOnReviewAndSubmitPage(int p0)
        {
            string distanceinRSPage = Gettext(attributeName_xpath, ReviewSubmit_CarrierInfo_Distance_Value_Xpath);
            string actualdistanceinRSPage = distanceinRSPage.Replace(" miles", string.Empty);
            if (actualdistanceinRSPage.Contains(","))
            {                
                Console.WriteLine("Distance value in Review and Submit Page separated with comma");
            }
            else
            {
                decimal expectedLength = 3;
                decimal distanceLength = actualdistanceinRSPage.Length;
                if (distanceLength > expectedLength)
                {
                    Report.WriteFailure("Distance value is more than 999 but comma is not displayed in Review and Submit Page");
                }
                else
                {
                    Console.WriteLine("Distance value is less than 999 hence comma is not expected in Review and Submit Page");
                }

            }
        }

        [Then(@"the mileage will be rounded as whole numbers on Shipment Details Page")]
        public void ThenTheMileageWillBeRoundedAsWholeNumbersOnShipmentDetailsPage()
        {
            string distanceinShipDetails=Gettext(attributeName_xpath, ".//*[@id='Carrierdetails']//div[3]");
            string actualdistanceinShipDetails = distanceinShipDetails.Replace(" miles", string.Empty).Replace(",", string.Empty);
            string roundedDistance = Math.Round(decimal.Parse(actualdistanceinShipDetails)).ToString();
            Assert.AreEqual(roundedDistance, actualdistanceinShipDetails);
            Report.WriteLine("Distance value rounded whole number in Shipment Details Page");
        }

        [Then(@"the mileage will be displayed with comma separated for greater than (.*) miles on Shipment Details Page")]
        public void ThenTheMileageWillBeDisplayedWithCommaSeparatedForGreaterThanMilesOnShipmentDetailsPage(int p0)
        {
            string distanceinShipDetails = Gettext(attributeName_xpath, ".//*[@id='Carrierdetails']//div[3]");
            string actualdistanceinShipDetails=distanceinShipDetails.Replace(" miles", string.Empty);
            if (actualdistanceinShipDetails.Contains(","))
            {        
                Console.WriteLine("Distance value in Shipment Details Page separated with comma");
            }
            else
            {
                decimal expectedLength = 3;
                decimal distanceLength = actualdistanceinShipDetails.Length;
                if (distanceLength > expectedLength)
                {
                    Report.WriteFailure("Distance value is more than 999 but comma is not displayed in Shipment Details Page");
                }
                else
                {
                    Console.WriteLine("Distance value is less than 999 hence comma is not expected in Shipment Details Page");
                }
            }
        }

        [Then(@"the mileage will be rounded as whole numbers on Quote Results page")]
        public void ThenTheMileageWillBeRoundedAsWholeNumbersOnQuoteResultsPage()
        {
            IList<IWebElement> distanceUI = GlobalVariables.webDriver.FindElements(By.XPath(ltldistancecolumnall_xpath));
            List<string> actualDistance = new List<string>();

            foreach (IWebElement element in distanceUI)
            {                
                actualDistance.Add((element.Text).ToString().Replace(" miles", string.Empty).Replace(",", string.Empty));
            }
            List<string> roundedDistanceValues = new List<string>();
            
            for (int i = 0; i < actualDistance.Count; i++)
            {               
                decimal roundedDistance = Math.Round(decimal.Parse(actualDistance[i]));
                roundedDistanceValues.Add(roundedDistance.ToString());
            }

            CollectionAssert.AreEqual(actualDistance, roundedDistanceValues);
            Report.WriteLine("Distance values are rounded whole numbers in Quote Results Page");
        }

        [Then(@"the mileage will be displayed with comma separated for greater than (.*) miles on Quote Results page")]
        public void ThenTheMileageWillBeDisplayedWithCommaSeparatedForGreaterThanMilesOnQuoteResultsPage(int p0)
        {
            IList<IWebElement> distanceUI = GlobalVariables.webDriver.FindElements(By.XPath(ltldistancecolumnall_xpath));
            List<string> actualDistance = new List<string>();
            foreach (IWebElement element in distanceUI)
            {
                actualDistance.Add((element.Text).ToString().Replace(" miles", string.Empty));
            }            

            for (int i = 0; i < actualDistance.Count; i++)
            {
                if (actualDistance[i].Contains(","))
                {                    
                    Console.WriteLine("Distance values in Quote Results Page separated with comma ");
                }
                else
                {
                    decimal expectedLength = 3;
                    decimal distanceLength = actualDistance[i].Length;
                    if (distanceLength > expectedLength)
                    {
                        Report.WriteFailure("Distance value is more than 999 but comma is not displayed in Quote Results Page");
                    }
                    else
                    {
                        Console.WriteLine("Distance value is less than 999 hence comma is not expected in Quote Results Page");
                    }

                }
            }
        }

    }

}
