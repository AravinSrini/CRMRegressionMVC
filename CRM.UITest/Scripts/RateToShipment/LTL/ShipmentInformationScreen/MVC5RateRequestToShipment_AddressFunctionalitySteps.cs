using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Text.RegularExpressions;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.RateToShipment.LTL.ShipmentInformationScreen
{
    [Binding]
    public class MVC5RateRequestToShipment_AddressFunctionalitySteps : AddShipments
    {
        RateToShipmentLTL RTS = new RateToShipmentLTL();

        string FromAddress_Quote;
        string ToAddress_Quote;


        [When(@"I have selected any Origin and Destination address on the Quote Results \(LTL\) page(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void WhenIHaveSelectedAnyOriginAndDestinationAddressOnTheQuoteResultsLTLPage(string Usertype, string CustomerName, string oname, string dname, string Item, string weight, string Quantity, string Insuredvalue)
        {
            RTS.NaviagteToQuoteList();
            RTS.SelectCustomerFrom_QuotetList(Usertype, CustomerName);
            RTS.ClickOnOriginSavedAddressDropdown_Quote();
            RTS.SearchByNameInTheOriginSavedAddressField_Quote(oname);
            RTS.SelectFirstAddressFromTheOriginSavedAddressDropdown_Quote();
            Thread.Sleep(2000);
            string ShpFromDropdownvalues = GetValue(attributeName_id, LTL_SavedOriginAddressDropdown_Id, "value");
            FromAddress_Quote = Regex.Replace(ShpFromDropdownvalues, @"\s", "");
            Thread.Sleep(1000);

            RTS.ClickOnDestinationSavedAddressDropdown_Quote();
            RTS.SearchByNameInTheDestinationSavedAddressField_Quote(dname);
            RTS.SelectFirstAddressFromTheDestinationSavedAddressDropdown_Quote();
            Thread.Sleep(2000);
            string ShpToDropdownvalues_Quote = GetValue(attributeName_id, LTL_SavedDestinationAddressDropdown_Id, "value");
            ToAddress_Quote = Regex.Replace(ShpToDropdownvalues_Quote, @"\s", "");
            Thread.Sleep(1000);

            RTS.addItem_Quote(Item, Quantity, weight);
            RTS.EnterDataInInsuredField_Quote(Insuredvalue);
            RTS.ClickOnViewQuoteResultsButton_Quote();
        }

        [When(@"I clicked on Create Shipment button in Quote Results\(LTL\) page(.*)")]
        public void WhenIClickedOnCreateShipmentButtonInQuoteResultsLTLPage(string Usertype)
        {
            RTS.ClickOnCreateShipmentbutton_Quote(Usertype);
        }

        [Then(@"the saved address will be preselected on the Shipping From and To address dropdown in the Add Shipment\(LTL\) page")]
        public void ThenTheSavedAddressWillBePreselectedOnTheShippingFromAndToAddressDropdownInTheAddShipmentLTLPage()
        {
            Thread.Sleep(15000);
            WaitForElementVisible(attributeName_id, ShippingFrom_SelectSavedOriginDropDown_Id, "Ship From dropdown");
            string FromselectedAddress = GetValue(attributeName_id, ShippingFrom_SelectSavedOriginDropDown_Id, "value");
            string FromAddress_Shipment = Regex.Replace(FromselectedAddress, @"\s", "");
            Assert.AreEqual(FromAddress_Quote.ToUpper(), FromAddress_Shipment.ToUpper());


            Thread.Sleep(2000);
            string ToselectedAddress = GetValue(attributeName_id, ShippingTo_SelectSavedDestDropDown_Id, "value");
            string ToAddress_Shipment = Regex.Replace(ToselectedAddress, @"\s", "");
            Assert.AreEqual(ToAddress_Quote.ToUpper(), ToAddress_Shipment.ToUpper());

        }

        [When(@"I Clicked on create Insured Shipment button in Quote Results\(LTL\) page(.*)")]
        public void WhenIClickedOnCreateInsuredShipmentButtonInQuoteResultsLTLPage(string Usertype)
        {
            RTS.ClickOnCreateInsuredShipmentbutton_Quote(Usertype);
        }

        [When(@"I have selected any Org and Dest\.address with Contact Info on the Quote Results \(LTL\) page(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void WhenIHaveSelectedAnyOrgAndDest_AddressWithContactInfoOnTheQuoteResultsLTLPage(string Usertype, string CustomerName, string oname, string dname, string Item, string weight, string Quantity, string Insuredvalue)
        {
            RTS.NaviagteToQuoteList();
            RTS.SelectCustomerFrom_QuotetList(Usertype, CustomerName);
            RTS.ClickOnOriginSavedAddressDropdown_Quote();
            RTS.SearchByNameInTheOriginSavedAddressField_Quote(oname);
            RTS.SelectFirstAddressFromTheOriginSavedAddressDropdown_Quote();
            Thread.Sleep(1000);

            RTS.ClickOnDestinationSavedAddressDropdown_Quote();
            RTS.SearchByNameInTheDestinationSavedAddressField_Quote(dname);
            RTS.SelectFirstAddressFromTheDestinationSavedAddressDropdown_Quote();
            Thread.Sleep(1000);

            RTS.addItem_Quote(Item, Quantity, weight);
            RTS.EnterDataInInsuredField_Quote(Insuredvalue);
            RTS.ClickOnViewQuoteResultsButton_Quote();
        }

        [Then(@"the Shipping From and To contact Info will be autopopulated in the Add Shipment\(LTL\) page(.*),(.*),(.*)")]
        public void ThenTheShippingFromAndToContactInfoWillBeAutopopulatedInTheAddShipmentLTLPage(string oname, string dname, string CustomerName)
        {
            Report.WriteLine("Verifying Origin Contact Info Autopopulated");
            Thread.Sleep(15000);
            string oActualContactName = GetValue(attributeName_id, ShippingFrom_ContactName_Id, "value");
            string oActualContactEmail = GetValue(attributeName_id, ShippingFrom_ContactEmail_Id, "value");
            string oActualContactPhone = GetValue(attributeName_id, ShippingFrom_ContactPhone_Id, "value");
            string oActualContactFax = GetValue(attributeName_id, ShippingFrom_ContactFax_Id, "value");
            Address _originaddressDB = DBHelper.GetAddress_By_searchedhName(CustomerName, oname);
            Thread.Sleep(1000);
            if (oActualContactName == "")
            {
                Assert.IsNull(_originaddressDB.ContactName);
            }
            else
            {
                Assert.AreEqual((_originaddressDB.ContactName).ToUpper(), oActualContactName.ToUpper());
            }
            Thread.Sleep(1000);

            if (_originaddressDB.EmailId == null || _originaddressDB.EmailId == "")
            {
                Assert.AreEqual(oActualContactEmail, "");
            }
            else
            {
                Assert.AreEqual((_originaddressDB.EmailId).ToUpper(), oActualContactEmail.ToUpper());
            }
            Thread.Sleep(1000);

            if (oActualContactPhone == "")
            {
                Assert.IsNull(_originaddressDB.PhoneNumber);
            }
            else
            {
                string _Phoneexpected = Regex.Replace(_originaddressDB.PhoneNumber, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
                string _PhoneActual = Regex.Replace(oActualContactPhone, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
                Assert.AreEqual((_Phoneexpected), _PhoneActual);
            }
            Thread.Sleep(1000);

            if (_originaddressDB.FaxNumber == null || _originaddressDB.FaxNumber == "")
            {
                Assert.AreEqual(oActualContactFax, "");
            }
            else
            {
                string _Faxexpected = Regex.Replace(_originaddressDB.FaxNumber, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
                string _FaxActual = Regex.Replace(oActualContactFax, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
                Assert.AreEqual((_Faxexpected), _FaxActual);
            }
            Thread.Sleep(1000);


            Report.WriteLine("Verifying Destination Contact Info Autopopulated");
            string dActualContactName = GetValue(attributeName_id, ShippingTo_ContactName_Id, "value");
            string dActualContactEmail = GetValue(attributeName_id, ShippingTo_ContactEmail_Id, "value");
            string dActualContactPhone = GetValue(attributeName_id, ShippingTo_ContactPhone_Id, "value");
            string dActualContactFax = GetValue(attributeName_id, ShippingTo_ContactFax_Id, "value");
            Address _destaddressDB = DBHelper.GetAddress_By_searchedhName(CustomerName, dname);
            Thread.Sleep(1000);

            if (dActualContactName == "")
            {
                Assert.IsNull(_destaddressDB.ContactName);
            }
            else
            {
                Assert.AreEqual((_destaddressDB.ContactName).ToUpper(), dActualContactName.ToUpper());
            }
            Thread.Sleep(1000);

            if (_destaddressDB.EmailId == null || _destaddressDB.EmailId == "")
            {
                Assert.AreEqual(dActualContactEmail, "");
            }
            else
            {
                Assert.AreEqual((_destaddressDB.EmailId.ToUpper()), dActualContactEmail.ToUpper());
            }
            Thread.Sleep(1000);

            if (dActualContactPhone == "")
            {
                Assert.IsNull(_destaddressDB.PhoneNumber);
            }
            else
            {
                Assert.AreEqual((_destaddressDB.PhoneNumber), dActualContactPhone);
            }
            Thread.Sleep(1000);

            if (_destaddressDB.FaxNumber == null || _destaddressDB.FaxNumber == "")
            {
                Assert.AreEqual(dActualContactFax, "");
            }
            else
            {
                Assert.AreEqual((_destaddressDB.FaxNumber), dActualContactFax);
            }
            Thread.Sleep(1000);
        }

    }
}
