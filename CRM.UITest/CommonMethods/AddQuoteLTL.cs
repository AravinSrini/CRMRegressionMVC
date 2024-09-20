using System.Collections.Generic;
using System.Configuration;
using CRM.UITest.Objects;
using OpenQA.Selenium;
using Rrd.ServiceAccessLayer;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Threading;

namespace CRM.UITest.CommonMethods
{
    public class AddQuoteLTL : Quotelist
    {
        #region QuoteListModule
        public void NaviagteToQuoteList()
        {
           
            Click(attributeName_id, QuoteIcon_Id);//try            
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        public void Add_QuoteLTL(string userType, string customerAcc)
        {
            
            if (userType == "Internal")
            {              
                               
                Click(attributeName_xpath, QuoteList_ClickCustomerDropdown_xpath);                
                Report.WriteLine("Selecting" + customerAcc + "from the Customer dropdown list");

                IList<IWebElement> CustomerDropdown_List = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_CustomerDropdownList_Xpath));
                int CustomerNameListCount = CustomerDropdown_List.Count;
                for (int i = 0; i < CustomerNameListCount; i++)
                {
                    if (CustomerDropdown_List[i].Text == customerAcc)
                    {
                       
                        CustomerDropdown_List[i].Click();
                        break;
                    }
                }
            }
            else
            {
                Report.WriteLine("Unable to find the passed customer account" + customerAcc);
            }
            
            Click(attributeName_id, SubmitRateRequestButton_Id);
            GlobalVariables.webDriver.WaitForPageLoad();            
            Click(attributeName_id, LTL_TileLabel_Id);            
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        #endregion QuoteListModule

        public void EnterOriginZip(string oZip)
        {
            WaitForElementVisible(attributeName_id, LTL_OriginZipPostal_Id, "Origin Zip");           
            SendKeys(attributeName_id, LTL_OriginZipPostal_Id, oZip);
        }

        public void EnterDestinationZip(string dZip)
        {
            WaitForElementVisible(attributeName_id, LTL_DestinationZipPostal_Id, "Destination Zip");           
            SendKeys(attributeName_id, LTL_DestinationZipPostal_Id, dZip);
        }

        public void EnterItemdata(string classification, string weight)
        {
           
            scrollElementIntoView(attributeName_id, LTL_Classification_Id);
            Click(attributeName_id, LTL_ClearItem_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_id, LTL_Classification_Id, classification);
            SendKeys(attributeName_id, LTL_Weight_Id, weight);
            GlobalVariables.webDriver.WaitForPageLoad();
        }
       
        public void selectShippingfromServices(string services)
        {

            Click(attributeName_xpath, LTL_ServicesAndAccessorials_ShipFrom_Xpath);
            //SelectDropdownValueFromList(attributeName_xpath, LTL_ServicesDropdownValues_ShipFrom_Xpath, services);
            IList<IWebElement> accessorialsAndServices = GlobalVariables.webDriver.FindElements(By.XPath(LTL_ServicesDropdownValues_ShipFrom_Xpath));
            int CustomerNameListCount = accessorialsAndServices.Count;
            for (int i = 0; i < CustomerNameListCount; i++)
            {
                if (accessorialsAndServices[i].Text == services)
                {

                    accessorialsAndServices[i].Click();
                    break;
                }
            }
        }

        public void selectShippingToServices(string services)
        {
            Click(attributeName_xpath, LTL_ServicesAndAccessorials_ShipTo_Xpath);            
            //SelectDropdownValueFromList(attributeName_xpath, LTL_ServicesDropdownValues_ShipTo_Xpath, services);         
            IList<IWebElement> accessorialsAndServices = GlobalVariables.webDriver.FindElements(By.XPath(LTL_ServicesDropdownValues_ShipTo_Xpath));
            int CustomerNameListCount = accessorialsAndServices.Count;
            for (int i = 0; i < CustomerNameListCount; i++)
            {
                if (accessorialsAndServices[i].Text == services)
                {

                    accessorialsAndServices[i].Click();
                    break;
                }
            }
        }
        public void EnterLWH(string length, string width, string height, string services)
        {         
            SendKeys(attributeName_id, LTL_Length_Id, length);
            SendKeys(attributeName_id, LTL_Width_Id, width);
            SendKeys(attributeName_id, LTL_Height_Id, height);
            if (services == "Overlength")
            {
                Click(attributeName_xpath, "//*[@id='Length-Additional-Warning-0']/h4/i[@class='icon-close right']");
                Thread.Sleep(1000);
            }
            else
            {
                Report.WriteLine("Selected serivce is not a Overlength");
            }               
                           
        }


        public void ClickViewRates()
        {
            Report.WriteLine("Click on Quote Results");

            Click(attributeName_id, LTL_ViewQuoteResults_Id);

            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementPresent(attributeName_xpath, ltlQuoteResultsheader_xpath, "waitforheader");
        }
    }
}