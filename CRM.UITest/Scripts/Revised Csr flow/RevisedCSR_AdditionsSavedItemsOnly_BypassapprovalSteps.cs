using System;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System.Threading;

namespace CRM.UITest.Scripts.Revised_Csr_flow
{
    [Binding]
    public class RevisedCSR_AdditionsSavedItemsOnly_BypassapprovalSteps : Submit_CSR
    {
        [Then(@"CSR should be completed (.*)")]
        public void ThenCSRShouldBeCompleted(string customer)
        {
            Report.WriteLine("Verifying the Completed Customer in CSR List");
            
            SendKeys(attributeName_xpath, CSRList_Searchbox_Xpath, customer);
            VerifyElementVisible(attributeName_xpath, NoSearcheddataforCSR_Grid_Xpath, "No Results Found for");
            //verifying the completed customer in customer profiles
            Thread.Sleep(20000);
            try
            {
                Thread.Sleep(20000);
                Click(attributeName_xpath, UserManagementIcon_Xpath);
            }
            catch
            {
                Thread.Sleep(20000);
                

            }

            SendKeys(attributeName_id, SearchCustomer_id, customer);
            Thread.Sleep(20000);
            VerifyElementVisible(attributeName_xpath, SearchedCustomer_Xpath, customer);
            Report.WriteLine("Searched Customer Displaying in Customer Profiles Page");
        }

        [Then(@"Revised CSR should be completed (.*)")]
        public void ThenRevisedCSRShouldBeCompleted(string customer)
        {


            Report.WriteLine("Verifying the Completed Customer in CSR List");
            
            SendKeys(attributeName_xpath, CSRList_Searchbox_Xpath, customer);
            VerifyElementVisible(attributeName_xpath, NoSearcheddataforCSR_Grid_Xpath, "No Results Found for");
            //verifying the completed customer in customer profiles
            Thread.Sleep(20000);
            try
            {
                Thread.Sleep(20000);
                Click(attributeName_xpath, UserManagementIcon_Xpath);
            }
            catch
            {
                Thread.Sleep(20000);
                

            }

            SendKeys(attributeName_id, SearchCustomer_id, customer);
            Thread.Sleep(20000);
            VerifyElementVisible(attributeName_xpath, SearchedCustomer_Xpath, customer);
            Report.WriteLine("Searched Customer Displaying in Customer Profiles Page");
        }

    }
}
