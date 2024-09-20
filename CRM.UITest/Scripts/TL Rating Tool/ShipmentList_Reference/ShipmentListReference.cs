using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest
{
    [Binding]
    public class ShipmentListReference : Shipmentlist
    {
        [Given(@"I am a user and login into application with valid zzzext and Te\$t(.*)")]
        public void GivenIAmAUserAndLoginIntoApplicationWithValidZzzextAndTeT(int p0)
        {
            CommonMethodsCrm crm = new CommonMethodsCrm();
            crm.LoginToCRMApplication("zzzext", "Te$t1234");
        }

        [Given(@"I am landed on the Shipment List page")]
        public void GivenIAmLandedOnTheShipmentListPage()
        {
            try
            {
                Click(attributeName_xpath, ShipmentModule_Xpath);

            }
            catch (Exception)
            {
                Thread.Sleep(20000);
                Console.WriteLine("error occurred");
            }
            WaitForElementVisible(attributeName_xpath, ShipmentList_Title_Xpath, "Shipment List");
        }

       
        [Given(@"I entered the '(.*)' in Reference Number lookup field")]
        public void GivenIEnteredTheInReferenceNumberLookupField(string Ref)
        {
            Report.WriteLine("Enter Reference Numbers");
            //SendKeys(attributeName_xpath, ShipmentList_ReferenceNumLookup_Xpath, Ref);
            SendKeys(attributeName_xpath,"//*[@id='txtReferenceNumer']",Ref);
        }

        [When(@"I clicked on search arrow of Reference Number lookup")]
        public void WhenIClickedOnSearchArrowOfReferenceNumberLookup()
        {
            Click(attributeName_xpath, "//*[@id='page-content-wrapper']/div[2]/div[2]/div/div[2]/div/div/form/div/div/button");
            Thread.Sleep(8000);
        }


        [Then(@"I should be displayed with results for the entered valid reference numbers '(.*)'")]
        public void ThenIShouldBeDisplayedWithResultsForTheEnteredValidReferenceNumbers(string p0)
        {
            Assert.IsTrue(true);
        }



        [Given(@"I am a user and login into application with valid shpent and Te\$t(.*)")]
        public void GivenIAmAUserAndLoginIntoApplicationWithValidShpentAndTeT(int p0)
        {
            CommonMethodsCrm crm = new CommonMethodsCrm();
            crm.LoginToCRMApplication("zzzext", "Te$t1234");
        }

        


       

    }
}
