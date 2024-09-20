using CRM.UITest.Objects;
using CRM.UITest.CommonMethods;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using TechTalk.SpecFlow;
using System.Threading;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Confirmation_Screen__All_Users 
{
    [Binding]
    public class ShipmentConfirmationLTLMVC5Station_CustomerDisplayStationUsersSteps : AddShipments

    {
        CommonMethodsCrm crm = new CommonMethodsCrm();
        AddShipmentLTL ltl = new AddShipmentLTL();
        [When(@"I am on confirmation page of the shipment")]
        public void WhenIAmOnConfirmationPageOfTheShipment()
        {
            Report.WriteLine("IAmOnConfirmationPageOfTheShipment");
            VerifyElementVisible(attributeName_xpath, confirmation_pageheader,"confirmationpage");
        }

        [Then(@"I should be display with mapped customer and station name  '(.*)' on confirmation page")]
        public void ThenIShouldBeDisplayWithMappedCustomerAndStationNameOnConfirmationPage(string station_customer)
        {
            Report.WriteLine("display with mapped customer and station name on confirmation page");
            Verifytext(attributeName_xpath, LTL_StationCustomerName_value_xpath, station_customer);
        }

        [When(@"I am on the Shipment Confirmation \(LTL\) page  Internal, , (.*),DName, OAddress, asd,DAddress,Daddress,Dunkin Donuts, Dname,, (.*), (.*),q(.*)asd, (.*), (.*), desc")]
        public void WhenIAmOnTheShipmentConfirmationLTLPage(string Usertype,
            string oAdd2,
            string oZip,
            string oName,
            string oAdd1,
            string dAdd2,
            string dName,
            string dAdd1,
            string Customer_Name,
            string oComments,
            string dComments,
            string dZip,
            string classification,
            string nmfc,
            string quantity,
            string weight,
            string desc)
        {
            //Navigate
            //Click(attributeName_id, "btn_ltl");
            ltl.NaviagteToShipmentList();
            ltl.SelectCustomerFromShipmentList(Usertype, Customer_Name);

            //Enter shipment information
            Click(attributeName_id, ShippingFrom_ClearAddress_Id);
            Click(attributeName_id, ShippingTo_ClearAddress_Id);
            ltl.AddShipmentOriginData(oName, oAdd1, oZip);
            ltl.AddShipmentDestinationData(dName, dAdd1, dZip);
            scrollElementIntoView(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            Click(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            ltl.AddShipmentFreightDescription(classification, nmfc, quantity, weight, desc);
            SendKeys(attributeName_id, InsuredValue_TextBox_Id, quantity); //Entering Insured value

            //added to click on view rate button
            try
            {
                Click(attributeName_xpath, ViewRatesButton_xpath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Thread.Sleep(50000);
            }

            //Results page Create Shipment button Click
            ltl.ClickOnCreateShipmentButton(Usertype);

            //Navigation to Review and Submit page and Click on Submit button
            ltl.ReviewAndSubmit_ClickOnSubmitShipmentButton();
        }



    }


}
