using System.IO;
using System.Threading;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using Microsoft.Win32;
using System;
namespace CRM.UITest
{
    [Binding]
    public class RateRequest_ViewTC_EvidenceOfInsuranceLinkSteps:ObjectRepository
    {
        RateToShipmentLTL RTS = new RateToShipmentLTL();
        AddQuoteLTL AQL = new AddQuoteLTL();
        GetDownloadPath GetDownloadFolder = new GetDownloadPath();

      [When(@"I am on Terms & Conditions of Coverage")]
        public void WhenIAmOnTermsConditionsOfCoverage()
        {
            DefineTimeOut(50000);
            //Thread.Sleep(50000);
            Click(attributeName_id, LTL_TermsandConditionslink);
            GlobalVariables.webDriver.WaitForPageLoad();
            //Thread.Sleep(30000);
        }
        
        [When(@"I am on Terms & Conditions of Coverage modal")]
        public void WhenIAmOnTermsConditionsOfCoverageModal()
        {
            DefineTimeOut(10000);
            //Thread.Sleep(10000);
            Click(attributeName_id, LTL_TermsAndConditions_Results_Id);
            //Thread.Sleep(30000);
        }
        
        [Then(@"I will be presented with an option to download the '(.*)' form")]
        public void ThenIWillBePresentedWithAnOptionToDownloadTheForm(string p0)
        {
            Thread.Sleep(10000);
            MoveToElement(attributeName_id, LTL_EvidenceofInsuranceForm_Id);
            Click(attributeName_id, LTL_EvidenceofInsuranceForm_Id);
            DefineTimeOut(50000);
            Thread.Sleep(10000);
            GlobalVariables.webDriver.WaitForPageLoad();
            string downloadpath = GetDownloadFolder.GetDownloadFolderPath(@"\DownloadDlswwClaimsForm.docx");
            Thread.Sleep(10000);
            Assert.IsTrue(File.Exists(downloadpath));
        }

        [When(@"I am on Get Quote \(LTL\) page (.*),(.*),(.*)")]
        public void WhenIAmOnGetQuoteLTLPage(string Service, string UserType, string CustomerName)
        {
            RTS.NaviagteToQuoteList();
            AQL.Add_QuoteLTL(UserType, CustomerName);
        }

        [When(@"I have entered an (.*) on the Get Quote \(LTL\) page")]
        public void WhenIHaveEnteredAnOnTheGetQuoteLTLPage(string Insuredvalue)
        {
            Report.WriteLine("I Have Entered Ins value On GetQuoteLTLPage");
            DefineTimeOut(300000);
            MoveToElement(attributeName_id, LTL_EnterInsuredValue_Id);
            SendKeys(attributeName_id, LTL_EnterInsuredValue_Id, Insuredvalue);
            //for clicking outside of tab
            SendKeys(attributeName_id, LTL_Quantity_Id,"");
            //Thread.Sleep(10000);

        }

    }
}
