using CRM.UITest.Objects;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Collections.Generic;
using System.Threading;

namespace CRM.UITest.CommonMethods
{
    public class CommonQuoteNavigations: Quotelist
    {
        AddQuoteLTL quoteLtl = new AddQuoteLTL();
        QuoteToShipmentLTL qsLTL = new QuoteToShipmentLTL();
        public void SelectCustomerFromDropdown(string Account)
        {
            Report.WriteLine("Select Customer Name from the dropdown list");
            Click(attributeName_xpath, QuoteList_CustomerDropdown_Xpath);

            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_CustomerDropdownList_Xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == Account)
                {
                    DropDownList[i].Click();
                    break;
                }
            }
        }

        public void SelectViewOptionsFromDropdown(string Option)
        {
            Click(attributeName_xpath, QuoteList_TopGrid_DisplayListViewDropdown_Xpath);
            IList<IWebElement> OptionDropdown = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_TopGrid_DisplayListDropdownOptions_Xpath));
            int OptionDropdownCount = OptionDropdown.Count;
            for (int i = 0; i < OptionDropdownCount; i++)
            {
                if (OptionDropdown[i].Text == "ALL")
                {
                    OptionDropdown[i].Click();
                    break;
                }
            }
        }

        public void NavigatetoQuoteResultsPage(string userType)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            //quoteLtl.NaviagteToQuoteList();
            scrollElementIntoView(attributeName_xpath, ".//div[@id='showRate']");
            Click(attributeName_xpath, ".//input[@id='rate-1']");
            Thread.Sleep(1000);
            Click(attributeName_xpath, ".//*[@id='getRate']");

            //quoteLtl.Add_QuoteLTL(userType, "ZZZ - GS Customer Test");
            //Enter data in shipping information screen            
            quoteLtl.EnterOriginZip("60606");
            quoteLtl.EnterDestinationZip("33126");
            scrollElementIntoView(attributeName_id, LTL_SavedItemDropdown_Id);            
            quoteLtl.EnterItemdata("65", "1200");            
            //click on view quote results button
            Click(attributeName_id, LTL_ViewQuoteResults_Id);            
        }
        public void NavigatetoQuoteConfirmationFromQuoteListWithServices(string userType,string customerAcc,string userName, string length,string width, string height, string service)
        {
                //Navigation from Quote List page
                GlobalVariables.webDriver.WaitForPageLoad();
                quoteLtl.NaviagteToQuoteList();
                quoteLtl.Add_QuoteLTL(userType, customerAcc);
                quoteLtl.EnterOriginZip("60606");
                quoteLtl.EnterDestinationZip("33126");
                GlobalVariables.webDriver.WaitForPageLoad();
                quoteLtl.selectShippingToServices(service);
                quoteLtl.selectShippingfromServices(service);
                scrollElementIntoView(attributeName_id, LTL_SavedItemDropdown_Id);
                quoteLtl.EnterItemdata("65", "1200");
                quoteLtl.EnterLWH(length, width, height, service);
                  try{ Click(attributeName_id, LTL_ViewQuoteResults_Id); }
                  catch{}
                GlobalVariables.webDriver.WaitForPageLoad();
                GlobalVariables.webDriver.WaitForPageLoad();
                qsLTL.ClickOnSaveRateAsQuoteLink(userType);
        }

        public void NavigatetoQuoteConfirmationFromQuoteListWithaccessorialfromsection(string userType, string customerAcc,string userName,string service)
        {
            //Navigation from Quote List page
            GlobalVariables.webDriver.WaitForPageLoad();
            quoteLtl.NaviagteToQuoteList();
            quoteLtl.Add_QuoteLTL(userType, customerAcc);
            quoteLtl.EnterOriginZip("60606");
            quoteLtl.EnterDestinationZip("33126");
            GlobalVariables.webDriver.WaitForPageLoad();
            quoteLtl.selectShippingfromServices("Notification");
            scrollElementIntoView(attributeName_id, LTL_SavedItemDropdown_Id);
            quoteLtl.EnterItemdata("65", "1200");
            Click(attributeName_id, LTL_ViewQuoteResults_Id);
           GlobalVariables.webDriver.WaitForPageLoad();
            GlobalVariables.webDriver.WaitForPageLoad();
            qsLTL.ClickOnSaveRateAsQuoteLink(userType);
        }

        public void NavigatetoQuoteConfirmationFromQuoteListWithaccessorialTOsection(string userType, string customerAcc, string userName, string service)
        {
            //Navigation from Quote List page
            GlobalVariables.webDriver.WaitForPageLoad();
            quoteLtl.NaviagteToQuoteList();
            quoteLtl.Add_QuoteLTL(userType, customerAcc);
            quoteLtl.EnterOriginZip("60606");
            quoteLtl.EnterDestinationZip("33126");
            GlobalVariables.webDriver.WaitForPageLoad();
            quoteLtl.selectShippingToServices("Notification");
            scrollElementIntoView(attributeName_id, LTL_SavedItemDropdown_Id);
            quoteLtl.EnterItemdata("65", "1200");
            Click(attributeName_id, LTL_ViewQuoteResults_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            GlobalVariables.webDriver.WaitForPageLoad();
            qsLTL.ClickOnSaveRateAsQuoteLink(userType);
        }
        public void NavigatetoQuoteConfirmationFromQuoteListwithoutservices(string userType, string customerAcc, string userName)
        {
            //Navigation from Quote List page
            GlobalVariables.webDriver.WaitForPageLoad();
            quoteLtl.NaviagteToQuoteList();
            quoteLtl.Add_QuoteLTL(userType, customerAcc);
            quoteLtl.EnterOriginZip("60606");
            quoteLtl.EnterDestinationZip("33126");            
            scrollElementIntoView(attributeName_id, LTL_SavedItemDropdown_Id);
            quoteLtl.EnterItemdata("65", "1200");            
            Click(attributeName_id, LTL_ViewQuoteResults_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            GlobalVariables.webDriver.WaitForPageLoad();
            qsLTL.ClickOnSaveRateAsQuoteLink(userType);
        }
        public void QuotewithOverLengthNoDimensions(string userType, string customerAcc, string service)
        {
            quoteLtl.NaviagteToQuoteList();
            quoteLtl.Add_QuoteLTL(userType, customerAcc);
            quoteLtl.EnterOriginZip("60606");
            quoteLtl.EnterDestinationZip("33126");
            quoteLtl.selectShippingToServices(service);
            quoteLtl.selectShippingfromServices(service);            
            scrollElementIntoView(attributeName_id, LTL_SavedItemDropdown_Id);
            quoteLtl.EnterItemdata("65", "1200");
            Click(attributeName_id, LTL_ViewQuoteResults_Id);
        }
    }
}
