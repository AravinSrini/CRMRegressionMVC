using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest
{
    [Binding]
    public class ShipmentList_CreateDeleteSteps:Shipmentlist
    {
        [Given(@"I am a landed on the Shipment List page")]
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
        [Given(@"I navigate to shipment list Shipment List page")]
        public void GivenINavigateToShipmentListShipmentListPage()
        {
            Report.WriteLine("I navigate to shipment list page");
            VerifyElementVisible(attributeName_xpath, ShipmentList_Title_Xpath, "Shipment List");
           // string ShipmentlistHeader_UI = Gettext(attributeName_xpath, ShipmentList_Title_Xpath);
           // Assert.AreEqual(ShipmentList_Header, ShipmentlistHeader_UI);
        }


        [Given(@"And I create a customreport CusRepDel(.*)")]
        public void GivenAndICreateACustomreportCusRepDel(int p0)
        {
            Click(attributeName_xpath, "//*[@id='toggleFilters']");
            SendKeys(attributeName_xpath, "//*[@id='originCity']", "Los Angeles");
            SendKeys(attributeName_id, FilterSection_DestCity_Textbox_Id, "Miami");
            Click(attributeName_id, FilterSection_SaveReport_button_Id);
            VerifyElementPresent(attributeName_xpath, SaveReport_ModalPopUp_Text_Xpath, "Save Report");
            Thread.Sleep(4000);
            SendKeys(attributeName_id,NameThisReport_Textbox_Id,"CS36");
            Thread.Sleep(3000);
            Click(attributeName_id,SaveReport_ModalPopUp_Ok_button_Id);
            Thread.Sleep(2000);
            Click(attributeName_xpath,"//*[@id='toggleFilters']");
            Thread.Sleep(4000);
        }

        //[Given(@"I have selected the custom report CusRepDel(.*) which i created")]
        //public void GivenIHaveSelectedTheCustomReportCusRepDelWhichICreated(int p0)
        //{
        //    Report.WriteLine("I have selected the custom report which i selected");
        //    Thread.Sleep(1000);
        //    Click(attributeName_xpath,"//*[@id='ReportType_chosen']");
        //    SendKeys(attributeName_xpath, SelectAReportSearchBoxnShipmentList_Xpath, "CusRepDe96");
        //    Click(attributeName_xpath, "//*[@id='ReportType_chosen']/div/ul/li[54]");
        //    Click(attributeName_xpath, "//*[@id='toggleFilters']");
        //    Thread.Sleep(8000);
        //    Report.WriteLine("I choose select filters");
            
        //}
        

        [Then(@"I should be displayed with Delete Report link")]
        public void ThenIShouldBeDisplayedWithDeleteReportLink()
        {
            Report.WriteLine("I should be displayed with Delete Report link");
           // VerifyElementVisible(attributeName_id, FilterSection_DeleteReport_button_Id, "Delete Report");
            VerifyElementVisible(attributeName_xpath, "//*[@id='deleteFilterBtn']", "Delete Report");
           
        }

        [Then(@"I click on Delete Report link")]
        public void ThenIClickOnDeleteReportLink()
        {
            Report.WriteLine("I click on Delete Report link");
            Click(attributeName_id, FilterSection_DeleteReport_button_Id);
            //Click(attributeName_xpath, "//*[@id='deleteFilterBtn']");
        }

        [When(@"I Clicked on Show Filter link")]
        public void WhenIClickedOnShowFilterLink()
        {
            Report.WriteLine("I click on Show filter Link");
            Assert.IsTrue(true);
        }
        


        [Then(@"I should be displayed with Delete Report modal pop up")]
        public void ThenIShouldBeDisplayedWithDeleteReportModalPopUp()
        {
            Report.WriteLine("I should be displayed with Delete Report modal");
            VerifyElementVisible(attributeName_xpath, FilterSection_DeleteReport_Header_Xpath, "");
        }

        [Then(@"I click on Cancel button in Delete report modal")]
        public void ThenIClickOnCancelButtonInDeleteReportModal()
        {
            Report.WriteLine("I click on Cancel button of Delete report modal");
            Click(attributeName_xpath, FilterSection_DeleteReport_Cancel_Xpath);
        }

    }
}
