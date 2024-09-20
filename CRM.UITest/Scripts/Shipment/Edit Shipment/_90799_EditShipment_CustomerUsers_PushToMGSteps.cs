using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRM.UITest.CommonMethods;
using CRM.UITest.Helper.Common;
using CRM.UITest.Helper.DataModels;
using CRM.UITest.Helper.Implementations.ShipmentExtract;
using CRM.UITest.Helper.ViewModel;
using CRM.UITest.Objects;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Edit_Shipment
{
    [Binding]
    public class _90799_EditShipment_CustomerUsers_PushToMGSteps : AddShipments
    {

        AddShipmentLTL ltl = new AddShipmentLTL();
        GetQuantityType getquantity = new GetQuantityType();
        GetWeightType getweight = new GetWeightType();
        string originZip = string.Empty;
        string originCity = string.Empty;
        string originState = string.Empty;
        string originCountry = string.Empty;
        string BOLNumber = string.Empty;
        string carrierUI = string.Empty;
        string destinationName = string.Empty;
        string destinationAddress1 = string.Empty;
        string destinationAddress2 = string.Empty;
        string destinationZip = string.Empty;
        string destinationCity = string.Empty;
        string destinationState = string.Empty;
        string destinationCountry = string.Empty;
        string classificationUI = string.Empty;
        string quantityUI = string.Empty;
        string weightUI = string.Empty;
        string itemDescriptionUI = string.Empty;
        string NMFCUI = string.Empty;
        string quantityUnitUI = string.Empty;
        string weightUnitUI = string.Empty;
        string accessorial1 = "Liftgate Pickup";
        string accessorial2 = "Liftgate Delivery";


        CommonMethodsCrm crm = new CommonMethodsCrm();
        ShipmentExtractViewModel shipmentViewModels = null;

        [Given(@"I am a shp\.entry or shp\.entrynorates user")]
        public void GivenIAmAShp_EntryOrShp_EntrynoratesUser()
        {
            string userName = ConfigurationManager.AppSettings["username-CurrentSprintshpentry"].ToString();
            string password = ConfigurationManager.AppSettings["password-CurrentSprintshpentry"].ToString();
            crm.LoginToCRMApplication(userName, password);
        }

        [Given(@"I am Editing an LTL shipment for external user")]
        public void GivenIAmEditingAnLTLShipmentForExternalUser()
        {
            AddShipmentLTL ltl = new AddShipmentLTL();
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, AddShipmentButton_id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ShipmentServiceTypeLTL_id);
            GlobalVariables.webDriver.WaitForPageLoad();
            ltl.AddShipmentOriginData("oName", "oAdd", "33126");
            ltl.AddShipmentDestinationData("dName", "dAdd", "85282");
            scrollElementIntoView(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            Click(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            string classification = "70";
            string quantity = "22";
            string weight = "20";
            ltl.AddShipmentFreightDescription(classification, "1234", quantity, weight, "testdescription");
            ltl.ClickViewRates();
            ltl.ClickOnCreateShipmentButton("External");
            ltl.ReviewAndSubmit_ClickOnSubmitShipmentButton();
            GlobalVariables.webDriver.WaitForPageLoad();
            string refnumber = Gettext(attributeName_id, ShipmentConfirmationNumber_Id);
            Click(attributeName_id, ShipmentIcon_Id);

            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Click on Edit Shipment button");
            SendKeys(attributeName_id, "searchbox", refnumber);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, ".//*[@id='ShipmentGrid']/tbody/tr//*[@class = 'btn btn-default colored btn-sm btn-EditShipmentExtUsers']");
            GlobalVariables.webDriver.WaitForPageLoad();

            originZip = GetValue(attributeName_id, ShippingFrom_zipcode_Id, "value");
            originCity = GetValue(attributeName_id, ShippingFrom_City_Id, "value");
            originState = Gettext(attributeName_xpath, ShippingFrom_StateDropdwon_xpath);
            originCountry = Gettext(attributeName_xpath, ShippingFrom_CountryDropDown_SelectedValue_xpath);

            destinationZip = GetValue(attributeName_id, ShippingTo_zipcode_Id, "value");
            destinationCity = GetValue(attributeName_id, ShippingTo_City_Id, "value");
            destinationState = Gettext(attributeName_xpath, ShippingTo_StateDropdwon_xpath);
            destinationCountry = Gettext(attributeName_xpath, ShippingFrom_CountryDropDown_SelectedValue_xpath);

            Click(attributeName_xpath, ShippingFrom_ServicesAccessorial_DropDown_xpath);
            IList<IWebElement> AccessorialDropdown_List = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='shippingfromaccessorial_chosen']/*[@class ='chosen-drop']/*[@class ='chosen-results']/li"));
            int AccessorialDropdownListCount = AccessorialDropdown_List.Count;
            for (int i = 0; i < AccessorialDropdownListCount; i++)
            {
                if (AccessorialDropdown_List[i].Text == accessorial1)
                {
                    AccessorialDropdown_List[i].Click();
                    break;
                }
            }
            Click(attributeName_xpath, Overlength_ShippingTo_ServicesAccessorial_DropDown_xpath);
            IList<IWebElement> ShipToAccessorialDropdown_List = GlobalVariables.webDriver.FindElements(By.XPath(Overlength_ShippingTo_ServicesAccessorial_DropDown_Values_xpath));
            int ShipAccessorialDropdownListCount = ShipToAccessorialDropdown_List.Count;
            for (int i = 0; i < ShipAccessorialDropdownListCount; i++)
            {
                if (ShipToAccessorialDropdown_List[i].Text == accessorial2)
                {
                    ShipToAccessorialDropdown_List[i].Click();
                    break;
                }
            }

            scrollpagedown();
            scrollpagedown();

            classificationUI = GetValue(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id, "value");
            itemDescriptionUI = GetValue(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id, "value");
            NMFCUI = GetValue(attributeName_id, FreightDesp_FirstItem_NMFC_Id, "value");

            quantityUI = GetValue(attributeName_id, FreightDesp_FirstItem_Quantity_Id, "value");
            weightUI = GetValue(attributeName_id, FreightDesp_FirstItem_Weight_Id, "value");

            quantityUnitUI = Gettext(attributeName_xpath, FreightDesp_FirstItem_QuantityType_xpath);
            weightUnitUI = Gettext(attributeName_xpath, FreightDesp_FirstItem_WeightType_xpath);
            scrollElementIntoView(attributeName_xpath, ViewRatesButton_xpath);
            ltl.ClickViewRates();
            GlobalVariables.webDriver.WaitForPageLoad();
            carrierUI = Gettext(attributeName_xpath, ShipResults_FC_CarrierName_Xpath);
            scrollpagedown();
            Click(attributeName_id, "createShipment");
        }


        [Then(@"the shipment data will be pushed to MG")]
        public void ThenTheShipmentDataWillBePushedToMG()
        {
            string oname = string.Empty;
            string oadd1 = string.Empty;
            string oadd2 = string.Empty;
            string ozip = string.Empty;
            string ocity = string.Empty;
            string ostate = string.Empty;
            string ocountry = string.Empty;

            string dname = string.Empty;
            string dadd1 = string.Empty;
            string dadd2 = string.Empty;
            string dzip = string.Empty;
            string dcity = string.Empty;
            string dstate = string.Empty;
            string dcountry = string.Empty;

            string classification = string.Empty;
            string weight = string.Empty;
            string weightunit = string.Empty;
            string weightunitexp = string.Empty;
            string quantity = string.Empty;
            string quantityunit = string.Empty;
            string quantityunitexp = string.Empty;
            string description = string.Empty;
            string nmfc = string.Empty;
            string length = string.Empty;
            string width = string.Empty;
            string height = string.Empty;

            string carrier = string.Empty;
            string picupdate = string.Empty;
            string deliverydate = string.Empty;

            string uri = $"MercuryGate/OidLookup";
            BuildHttpClient client = new BuildHttpClient();
            HttpClient headers = client.BuildHttpClientWithHeaders("Admin", "application/xml");

            ShipmentExtract ext = new ShipmentExtract();
            string refnumber = Gettext(attributeName_id, ShipmentConfirmationNumber_Id);

            shipmentViewModels = ext.getShipmentData(uri, headers, refnumber, "Admin");
            if (shipmentViewModels.AddressViewModels[0].Type == "Origin")
            {
                string originaddr = shipmentViewModels.AddressViewModels[0].AddressLine1;
            }

            if (shipmentViewModels.AddressViewModels[0].Type == "Destination")
            {
                string destinationaddr = shipmentViewModels.AddressViewModels[0].AddressLine1;
            }


            for (var i = 0; i < shipmentViewModels.AddressViewModels.Count; i++)
            {
                if (shipmentViewModels.AddressViewModels[i].Type.ToLower() == "destination")
                {
                    dzip = shipmentViewModels.AddressViewModels[i].PostalCode;
                    dcity = shipmentViewModels.AddressViewModels[i].City;
                    dstate = shipmentViewModels.AddressViewModels[i].StateProvince;
                    dcountry = shipmentViewModels.AddressViewModels[i].CountryCode;
                }
                if (shipmentViewModels.AddressViewModels[i].Type.ToLower() == "origin")
                {
                    ozip = shipmentViewModels.AddressViewModels[i].PostalCode;
                    ocity = shipmentViewModels.AddressViewModels[i].City;
                    ostate = shipmentViewModels.AddressViewModels[i].StateProvince;
                    ocountry = shipmentViewModels.AddressViewModels[i].CountryCode;
                }
            }

            for (int i = 0; i < shipmentViewModels.ShipmentDetailsViewModel.AdditionalServices.Count; i++)
            {
                string accessorialMG = shipmentViewModels.ShipmentDetailsViewModel.AdditionalServices[i];
                if (accessorialMG == accessorial1)
                {
                    Report.WriteLine(accessorial1 + "is updated in MG");
                }
                else if (accessorialMG == accessorial2)
                {
                    Report.WriteLine(accessorial2 + "is updated in MG");
                }
                else
                {
                    Assert.Fail("No Accessorial updated in MG");
                }
            }


            classification = shipmentViewModels.ItemViewModels[0].Classification;
            quantity = shipmentViewModels.ItemViewModels[0].Quantity;
            weight = shipmentViewModels.ItemViewModels[0].Weight;
            quantityunit = shipmentViewModels.ItemViewModels[0].QuantityUnit;
            quantityunitexp = getquantity.Getquantity(quantityunit);
            weightunit = shipmentViewModels.ItemViewModels[0].WeightUnit;
            weightunitexp = getweight.GetWeight(weightunit);
            nmfc = shipmentViewModels.ItemViewModels[0].NmfcCode;
            length = shipmentViewModels.ItemViewModels[0].Length;
            width = shipmentViewModels.ItemViewModels[0].Width;
            height = shipmentViewModels.ItemViewModels[0].Height;
            carrier = shipmentViewModels.CarrierRatesViewModel.Carrier;
            picupdate = shipmentViewModels.EarliestPickupDate;
            deliverydate = shipmentViewModels.LatestDropDate;

            Report.WriteLine("Verifying the origin Zip with UI");
            Assert.AreEqual(originZip, ozip);
            Report.WriteLine("Displaying UI data " + originZip + "is matching with API data " + ozip);

            Report.WriteLine("Verifying the origin city with UI");
            Assert.AreEqual(originCity, ocity);
            Report.WriteLine("Displaying UI data " + originCity + "is matching with API data " + ocity);

            Report.WriteLine("Verifying the origin state with UI");
            Assert.AreEqual(originState, ostate);
            Report.WriteLine("Displaying UI data " + originState + "is matching with API data " + ostate);

            Report.WriteLine("Verifying the Destination Zip with UI");
            Assert.AreEqual(destinationZip, dzip);
            Report.WriteLine("Displaying UI data " + destinationZip + "is matching with API data " + dzip);

            Report.WriteLine("Verifying the Destination city with UI");
            Assert.AreEqual(destinationCity, dcity);
            Report.WriteLine("Displaying UI data " + destinationCity + "is matching with API data " + dcity);

            Report.WriteLine("Verifying the Destination state with UI");
            Assert.AreEqual(destinationState, dstate);
            Report.WriteLine("Displaying UI data " + destinationState + "is matching with API data " + dstate);


            Report.WriteLine("Verifying the Origin country with UI");
            if (originCountry == "United States")
            {
                Assert.AreEqual("USA", ocountry);
            }
            else
            {
                Assert.AreEqual("Canada".ToUpper(), ocountry.ToUpper());
            }
            Report.WriteLine("Displaying UI data " + originCountry + "is matching with API data " + ocountry);

            Report.WriteLine("Verifying the Destination country with UI");
            if (destinationCountry == "United States")
            {
                Assert.AreEqual("USA", dcountry);
            }
            else
            {
                Assert.AreEqual("Canada".ToUpper(), dcountry.ToUpper());
            }
            Report.WriteLine("Displaying UI data " + destinationCountry + "is matching with API data " + dcountry);

            Report.WriteLine("Verifying the quantity with UI");
            Assert.AreEqual(quantityUI + ".0", quantity);
            Report.WriteLine("Displaying UI data " + quantityUI + "is matching with API data " + quantity);

            Report.WriteLine("Verifying the weight with UI");
            Assert.AreEqual(weightUI + ".0", weight);
            Report.WriteLine("Displaying UI data " + weightUI + "is matching with API data " + weight);

            Report.WriteLine("Verifying the quantity unit with UI");
            Assert.AreEqual(quantityUnitUI, quantityunitexp);
            Report.WriteLine("Displaying UI data " + quantityUnitUI + "is matching with API data " + quantityunitexp);

            Report.WriteLine("Verifying the weight unit with UI");
            Assert.AreEqual(weightUnitUI, weightunitexp);
            Report.WriteLine("Displaying UI data " + weightUnitUI + "is matching with API data " + weightunitexp);

            Report.WriteLine("Verifying the classification with UI");
            Assert.AreEqual(classificationUI + ".0", classification);
            Report.WriteLine("Displaying UI data " + classificationUI + "is matching with API data " + classification);

            Report.WriteLine("Verifying the NMFC with UI");
            Assert.AreEqual(NMFCUI, nmfc);
            Report.WriteLine("Displaying UI data " + NMFCUI + "is matching with API data " + nmfc);

        }

        [Then(@"the BOL number will be added as a reference number to the shipment import xml with is primary =  true")]
        public void ThenTheBOLNumberWillBeAddedAsAReferenceNumberToTheShipmentImportXmlWithIsPrimaryTrue()
        {
            
        BOLNumber = Gettext(attributeName_xpath, confirmation_BOLValue_Xpath);
            int i = shipmentViewModels.ReferenceNumbers.Count;
            int q = 1;
            foreach (ShipmentImportReferenceModel a in shipmentViewModels.ReferenceNumbers)
            {
                if (a.Type == "BOL")
                {
                    Assert.AreEqual(BOLNumber, a.ReferenceNumber);
                    Report.WriteLine("Reference type BOL is updated to this Shipment");
                    Assert.IsTrue(Convert.ToBoolean(a.IsPrimary));

                    Report.WriteLine("Reference type BOL is Primary");
                    break;
                }
                else if (a.Type != "BOL" && q == i)
                {
                    Assert.Fail();
                }
                q++;
            }
        }

        [Then(@"the carrier pricesheet in MG will be selected")]
        public void ThenTheCarrierPricesheetInMGWillBeSelected()
        {
            String carrier = shipmentViewModels.CarrierRatesViewModel.Carrier;
            Report.WriteLine("Verifying the carrier with UI");
            Assert.AreEqual(carrierUI, carrier);
            Report.WriteLine("Displaying UI data " + carrierUI + "is matching with API data " + carrier);

        }
    }
}
