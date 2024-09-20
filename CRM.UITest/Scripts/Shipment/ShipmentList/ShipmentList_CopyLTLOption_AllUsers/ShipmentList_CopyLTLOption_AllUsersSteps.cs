using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.ShipmentList.ShipmentList_CopyLTLOption_AllUsers
{
    [Binding]
    public  class ShipmentList_CopyLTLOption_AllUsersSteps : Shipmentlist
    {

        [Then(@"I must see the copy icon of any displayed shipment in shipment list grid")]
        public void ThenIMustSeeTheCopyIconOfAnyDisplayedShipmentInShipmentListGrid()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ShipmentList_SearchBox_ToggleButton_Id);
            Thread.Sleep(1000);
            Click(attributeName_id, ShipmentListSearchBox_ClearAll_Button_Id);
            Thread.Sleep(1000);
            Click(attributeName_xpath, ShipmentList_Search_Service_Checkbox_Xpath);
            Thread.Sleep(1000);
            SendKeys(attributeName_id, ShipmentListSearchBox_Id, "LTL");

            int rowcount = GetCount(attributeName_xpath, ShipmentList_NoOf_Rows_Xpath);
            if (rowcount >= 1)
            {
                Report.WriteLine("I must see the Copy icon for any displayed shipment in shipment list grid");
                VerifyElementPresent(attributeName_xpath, ShipmentListGrid_CopyIcon_Xpath, "Copy Icon");              
            }
            else
            {
                Report.WriteLine("No Records found for the service LTL in Shipment List Grid");
            }

        }

        [When(@"I click on copy icon for any shipment")]
        public void WhenIClickOnCopyIconForAnyShipment()
        {
            Report.WriteLine("I click on Copy Icon");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, ShipmentListGrid_CopyIcon_Xpath);
            Thread.Sleep(2000);
        }

        [Then(@"Verify the copy shipment on (.*) of any displayed shipment")]
        public void ThenVerifyTheCopyShipmentOnOfAnyDisplayedShipment(string confirmationmodel)
        {
            Report.WriteLine("Verified the message on pop up model ");
            String ModelMessage = Gettext(attributeName_xpath, ShipmentList_CopyIcon_ModelText_Xpath);
            Assert.AreEqual(confirmationmodel, ModelMessage);
        }
        [Then(@"The model have the Cancel and Copy Shipment buttons")]
        public void ThenTheModelHaveTheCancelAndCopyShipmentButtons()
        {
            Report.WriteLine("Popup model have the Cancel and Copy Shipment Button ");
            VerifyElementPresent(attributeName_xpath, ShipmentList_CopyIcon_Model_CancelButton_Xpath, "Cancel Button");
            VerifyElementPresent(attributeName_id, ShipmentList_CopyIcon_Model_CopyShipmentButton_Id, "Copy Shipment Button");
        }

        [When(@"I have click on cancel button")]
        public void WhenIHaveClickOnCancelButton()
        {
            Report.WriteLine("I have click on Cancel button");
            Click(attributeName_xpath, ShipmentList_CopyIcon_Model_CancelButton_Xpath);
        }

        [Then(@"I must be arrive back on shipment list page")]
        public void ThenIMustBeArriveBackOnShipmentListPage()
        {
            Report.WriteLine("I must see the Shipment List page");
            Report.WriteLine("Verify i must navigate to the Shipment List page");
            VerifyElementVisible(attributeName_xpath, ShipmentList_Title_Xpath, "Shipment List");
        }

    }
}
