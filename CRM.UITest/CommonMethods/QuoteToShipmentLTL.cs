using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CRM.UITest.CommonMethods
{
    public class QuoteToShipmentLTL : AddShipments
    {
        string BOL;

        RateToShipmentLTL RTS = new RateToShipmentLTL();
        AddShipmentLTL _shipmentLTL = new AddShipmentLTL();

        string BOL_Quote;

        public void ClickOnSaveRateAsQuoteLink(string Usertype)
        {
            string configURL = launchUrl;
            string resultPagrURL = configURL + "Rate/LtlResultsView";
            if (GetURL() == resultPagrURL)
            {

                switch (Usertype)
                {
                    case "External":
                        Click(attributeName_xpath, ltlsaverateasquotelnk_xpath);
                        break;

                    case "Internal":
                        Click(attributeName_xpath, ltlsaverateasquotelnkStationUsers_xpath);
                        break;
                }                
            }

            else
            {
                Report.WriteLine("No Rates available");
                Click(attributeName_xpath, ltlsavequotenorateslink_xpath);
            }
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        public string BOLNumberInConfirmationpage_Quote(string Usertype)
        {
            WaitForElementVisible(attributeName_xpath, LTL_QuoteConfirmationPageHeader_Xpath, "confirmpage");
            switch (Usertype)
            {
                case "External":
                    BOL = Gettext(attributeName_id, "");
                    break;

                case "Internal":
                    BOL = Gettext(attributeName_id, "referenceNumber-value");
                    break;
            }

            return BOL;
        }

        public void RateToShipmentShipmentInformationPage_Navigation(string Usertype, string CustomerName, string ocity, string ostate, string ozip, string dcity, string dstate, string dzip, string quantity, string weight, string Item, string oname, string oadd1, string dname, string dadd1, string nmfc)
        {
            RTS.NaviagteToQuoteList();
            RTS.SelectCustomerFrom_QuotetList(Usertype, CustomerName);
            RTS.ShpFromAddressFields_Quote(ocity, ostate, ozip);
            RTS.ShpToAddressFields_Quote(dcity, dstate, dzip);
            RTS.addItem_Quote(Item, quantity, weight);
            RTS.ClickOnViewQuoteResultsButton_Quote();
            RTS.ClickOnCreateShipmentbutton_Quote(Usertype);
            RTS.Enter_Name_Address1_ShpFromSection_Shipment(oname, oadd1);
            RTS.Enter_Name_Address1_ShpToSection_Shipment(dname, dadd1);
            RTS.Enter_NMFC_Shipment(nmfc);
        }

        public void DirectShipmentInformationPage_Navigation(string Usertype, string oAdd2, string oZip, string oName, string oAdd1, string dAdd2, string dName, string dAdd1, string Customer_Name, string oComments, string dComments, string dZip, string classification, string nmfc, string quantity, string weight, string desc)
        {
            _shipmentLTL.NaviagteToShipmentList();
            _shipmentLTL.SelectCustomerFromShipmentList(Usertype, Customer_Name);
            Click(attributeName_id, ShippingFrom_ClearAddress_Id);
            Click(attributeName_id, ShippingTo_ClearAddress_Id);
            _shipmentLTL.AddShipmentOriginData(oName, oAdd1, oZip);
            _shipmentLTL.AddShipmentDestinationData(dName, dAdd1, dZip);
            scrollElementIntoView(attributeName_id, LTL_PickUpDate_Id);
            Thread.Sleep(800);
            Click(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            Thread.Sleep(1000);
            _shipmentLTL.AddShipmentFreightDescription(classification, nmfc, quantity, weight, desc);
            Thread.Sleep(1000);
            SendKeys(attributeName_id, InsuredValue_TextBox_Id, quantity);
            
            
        }

        public void QuoteToShipmentShipmentInformationPage_Navigation(string service, string Usertype, string CustomerName, string ocity, string ostate, string ozip, string dcity, string dstate, string dzip, string quantity, string weight, string Item, string oname, string oadd1, string dname, string dadd1, string nmfc)
        {
            RTS.NaviagteToQuoteList();
            RTS.SelectCustomerFrom_QuotetList(Usertype, CustomerName);

            int rowcount = GetCount(attributeName_xpath, ".//*[@id='QuotesGrid']/tbody/tr");
            if (rowcount > 1)
            {
                Click(attributeName_id, "showNew");
                Click(attributeName_xpath, ".//*[@id='toggle-button']");
                Thread.Sleep(1000);
                Click(attributeName_id, "clear-all-btn");
                Click(attributeName_xpath, ".//*[@id='dropdown-display']/form/div[1]/div/div[2]/div[3]/label");
                SendKeys(attributeName_id, "searchbox", "LTL");
                Click(attributeName_xpath, ".//*[@id='toggle-button']");
                Thread.Sleep(10000);

                switch (Usertype)
                {
                    case "External":
                        Click(attributeName_xpath, ".//*[@id='QuotesGrid']/tbody/tr[1]/td[8]/button");
                        Thread.Sleep(2000);
                        break;

                    case "Internal":
                        Click(attributeName_xpath, ".//*[@id='QuotesGrid']/tbody/tr[1]/td[9]/button");
                        Thread.Sleep(4000);
                        break;
                }
                Thread.Sleep(2000);
                Click(attributeName_id, "btn-CreateShipment");
                RTS.Enter_Name_Address1_ShpFromSection_Shipment(oname, oadd1);
                RTS.Enter_Name_Address1_ShpToSection_Shipment(dname, dadd1);
                RTS.Enter_NMFC_Shipment(nmfc);

            }
            else
            {
                RTS.ShpFromAddressFields_Quote(ocity, ostate, ozip);
                RTS.ShpToAddressFields_Quote(dcity, dstate, dzip);
                RTS.addItem_Quote(Item, quantity, weight);
                RTS.ClickOnViewQuoteResultsButton_Quote();

                ClickOnSaveRateAsQuoteLink(Usertype);
                BOL_Quote = BOLNumberInConfirmationpage_Quote(Usertype);
                Click(attributeName_id, "Btn_BackQuoteList");
                Thread.Sleep(2000);
                RTS._selectingCustomerNameonly_Quotelist(Usertype, CustomerName);
                Thread.Sleep(4000);
                SendKeys(attributeName_id, "searchbox", BOL_Quote);
                Thread.Sleep(2000);
                switch (Usertype)
                {
                    case "External":
                        Click(attributeName_xpath, ".//*[@id='QuotesGrid']/tbody/tr[1]/td[8]/button");
                        Thread.Sleep(2000);
                        break;

                    case "Internal":
                        Click(attributeName_xpath, ".//*[@id='QuotesGrid']/tbody/tr[1]/td[9]/button");
                        Thread.Sleep(4000);
                        break;
                }
                Thread.Sleep(2000);
                Click(attributeName_id, "btn-CreateShipment");
                RTS.Enter_Name_Address1_ShpFromSection_Shipment(oname, oadd1);
                RTS.Enter_Name_Address1_ShpToSection_Shipment(dname, dadd1);
                RTS.Enter_NMFC_Shipment(nmfc);

            }
        }
    }
}
