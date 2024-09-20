using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.ShipmentList_InternalUsers.ShipmentList_EditShipment
{
    [Binding]
    public class EditShipment_AccessorialGainshareType_CRMRatingLogicSteps : AddShipments
    {
        //AddShipments addshipment = new AddShipments();
        //IndividualAccessorialModel newAccessorialModel;
        //List<IndividualAccessorialModel> IndividualaccessorialModelsByCustomer;
        //List<IndividualAccessorialModel> IndividualaccessorialModelsByCarrier;
        AddShipmentLTL ltl = new AddShipmentLTL();
        List<IndividualAccessorialModel> accessorialModalFromPriceSheet, priceSheetBasedOnGainShareType;
        List<IndividualAccessorialModel> IndividualaccessorialModelsByCustomer = new List<IndividualAccessorialModel>();
        List<IndividualAccessorialModel> IndividualaccessorialModelsByCarrier = new List<IndividualAccessorialModel>();
        IndividualAccessorialModel newAccessorialModel;
        List<AccessorialCustomerSetUp> accessorialModelsByCustomer;
        List<AccessorialCarrierSetUp> accessorialModelsByCarrier;

        string OriginZip = string.Empty;
        string OriginCity = string.Empty;
        string OriginState = string.Empty;
        string OriginCountry = string.Empty;

        string DestinationZip = string.Empty;
        string DestinationCity = string.Empty;
        string DestinationState = string.Empty;
        string DestinationCountry = string.Empty;

        string Classification = string.Empty;
        double Quantity = 0;
        double Weight = 0;

        string Service = "LTL";
        string UserType = "Internal";
        string QuantityUNIT = string.Empty;
        string WeightUnit = string.Empty;
        string originAccessorials = null;
        string destinationAccessorials = string.Empty;
        string customerName = "ZZZ - Czar Customer Test";

        string accvalue = string.Empty;
        string _gainshareType = string.Empty;

        //List<AccessorialCustomerSetUp> accessorialModelsByCustomer;
        //List<AccessorialCarrierSetUp> accessorialModelsByCarrier;
        //List<IndividualAccessorialModel> accessorialModalFromPriceSheet, priceSheetBasedOnGainShareType;



        [Given(@"I am Editing an LTL shipment")]
        public void GivenIAmEditingAnLTLShipment()
        {
            Report.WriteLine("Click on the Shipment icon from the left navigation bar");
            Click(attributeName_xpath, ShipmentIcon_Xpath);

            Report.WriteLine("I am on the shipment list page");
            Verifytext(attributeName_xpath, ShipmentList_Title_Xpath, "Shipment List");

            Click(attributeName_xpath, CustomerDropdownExtuser_Xpath);

            Report.WriteLine("Selecting " + customerName + "from the Customer drop down list");

            IList<IWebElement> CustomerDropdown_List = GlobalVariables.webDriver.FindElements(By.XPath(CustomerDropdownValesExtuser_Xpath));
            int CustomerNameListCount = CustomerDropdown_List.Count;
            for (int i = 0; i < CustomerNameListCount; i++)
            {
                if (CustomerDropdown_List[i].Text == customerName)
                {
                    CustomerDropdown_List[i].Click();
                    break;
                }
            }

            GlobalVariables.webDriver.WaitForPageLoad();

            SendKeys(attributeName_id, "searchbox", "ZZX002011738");//ZZS12522//ZZX002011737
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, ".//*[@id='ShipmentGrid']/tbody/tr/td[10]/button");
            GlobalVariables.webDriver.WaitForPageLoad();

            OriginZip = GetValue(attributeName_id, ShippingFrom_zipcode_Id, "value");
            OriginCity = GetValue(attributeName_id, ShippingTo_City_Id, "value");
            OriginState = Gettext(attributeName_xpath, ShippingFrom_StateDropdwon_xpath);
            OriginCountry = "USA";

            DestinationZip = GetValue(attributeName_id, ShippingTo_zipcode_Id, "value");
            DestinationCity = GetValue(attributeName_id, ShippingTo_City_Id, "value");
            DestinationState = Gettext(attributeName_xpath, ShippingTo_StateDropdwon_xpath);
            DestinationCountry = "USA";
            //destinationAccessorials = Gettext(attributeName_xpath, ShippingTo_selectedServicesAccessorial_DropDown_xpath);

            destinationAccessorials = Gettext(attributeName_xpath, ".//*[@id='shippingtoaccessorial_chosen']/ul/li[1]");

            scrollpagedown();
            scrollpagedown();

            Classification = GetValue(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id, "value");
            Quantity = Convert.ToDouble(GetValue(attributeName_id, FreightDesp_FirstItem_Quantity_Id, "value"));
            Weight = Convert.ToDouble(GetValue(attributeName_id, FreightDesp_FirstItem_Weight_Id, "value"));

            QuantityUNIT = Gettext(attributeName_xpath, FreightDesp_FirstItem_QuantityType_xpath);
            WeightUnit = Gettext(attributeName_xpath, FreightDesp_FirstItem_WeightType_xpath);
            scrollElementIntoView(attributeName_xpath, ViewRatesButton_xpath);
            ltl.ClickViewRates();
            GlobalVariables.webDriver.WaitForPageLoad();

        }

        [Given(@"the customer of the shipment being edited has a Set Individual Accessorial")]
        public void GivenTheCustomerOfTheShipmentBeingEditedHasASetIndividualAccessorial()
        {


            int customerAccountId = DBHelper.GetCustomerAccountId(customerName);


            accessorialModelsByCustomer = DBHelper.GetAccessorials(customerAccountId);
            accessorialModelsByCarrier = DBHelper.GetCarrierAccessorials(customerAccountId);

            if (accessorialModelsByCarrier != null)
            {
                foreach (var carrierData in accessorialModelsByCarrier)
                {
                    IndividualAccessorialModel accData = new IndividualAccessorialModel()
                    {
                        AccessorialCode = carrierData.AccessorialCode,
                        AccessorialValue = carrierData.AccessorialValue,
                        CarrierScac = carrierData.CarrierSCAC,
                        CustomerName = customerName,
                        GainShareType = carrierData.GainShareType
                    };

                    IndividualaccessorialModelsByCarrier.Add(accData);
                }
            }

            if (accessorialModelsByCustomer != null)
            {
                foreach (var customerData in accessorialModelsByCustomer)
                {
                    IndividualAccessorialModel accData = new IndividualAccessorialModel()
                    {
                        AccessorialCode = customerData.AccessorialCode,
                        AccessorialValue = customerData.AccessorialValue,
                        CustomerName = customerName,
                        GainShareType = customerData.GainShareType

                    };
                    IndividualaccessorialModelsByCustomer.Add(accData);
                }
            }

            bool isCustomerhasCustomerAccessorial = accessorialModelsByCustomer.Count > 0 ? true : false;

            if (isCustomerhasCustomerAccessorial)
            {
                Report.WriteLine("Customer has a Set Individual Accessorial");
            }

        }

        [Given(@"the CRM Rating Logic = Yes for the customer of the shipment being edited")]
        public void GivenTheCRMRatingLogicYesForTheCustomerOfTheShipmentBeingEdited()
        {
            bool iSCrmRatingLogic_GainshareCustomer = DBHelper.CheckNewCrmRatingLogic(customerName);
            if (iSCrmRatingLogic_GainshareCustomer)
            {
                Report.WriteLine("CRM Rating logic is Enabled for the Customer");
            }
            else
            {
                Report.WriteLine("CRM Rating logic is not Enabled for the Customer");
            }
        }

        [Given(@"the Accessorial Gainshare Type is ""(.*)""")]
        public void GivenTheAccessorialGainshareTypeIs(string gainShareType)
        {
            _gainshareType = gainShareType;
            Report.WriteLine("Validating for the Gainshare Type " + gainShareType);
            bool IsGainShareTypeMatches = accessorialModelsByCarrier?.Any(a => a.GainShareType == gainShareType) ??
                accessorialModelsByCustomer?.Any(a => a.GainShareType == gainShareType) ?? false;

            if (IsGainShareTypeMatches)
            {
                Report.WriteLine("Customer have a " + gainShareType + " Accessorial");
            }
            else
            {
                Report.WriteLine("Custoemr don't have a " + gainShareType + " Accessorial");
            }
        }

        [When(@"CRM receives a rate request response from MG that includes the Set Individual Accessorial")]
        public void WhenCRMReceivesARateRequestResponseFromMGThatIncludesTheSetIndividualAccessorial()
        {
            //Weight = 12;
            //Quantity = 1;
            //string QuantityUNIT = "pallets";
            //string WeightUnit = "LBS";
            string originAccessorials = null;
            string destinationAccessorials = "Inside Delivery";
            string Username = "";
            customerName = customerName.Trim();
            accessorialModalFromPriceSheet = GetRatesAndCarriersAPICall.BuildIndividualAccessorialModelFromCostPriceSheet(customerName, Service, OriginCity, OriginZip, OriginState, OriginCountry,
                DestinationCity, DestinationZip, DestinationState, DestinationCountry, originAccessorials, destinationAccessorials, Classification, Quantity, QuantityUNIT, Weight, WeightUnit, Username, false);
            priceSheetBasedOnGainShareType = GetRatesAndCarriersAPICall.BuildIndividualAccessorialModelFromCostPriceSheet(customerName, Service, OriginCity, OriginZip, OriginState, OriginCountry,
                DestinationCity, DestinationZip, DestinationState, DestinationCountry, originAccessorials, destinationAccessorials, Classification, Quantity, QuantityUNIT, Weight, WeightUnit, Username, true);
        }

        [Then(@"CRM will calculate the accessorial-cost using the formula ""(.*)""")]
        public void ThenCRMWillCalculateTheAccessorial_CostUsingTheFormula(string calculationFormaula)
        {
            Report.WriteLine("Calculation Logic Started");
            foreach (IndividualAccessorialModel priceSheetModel in accessorialModalFromPriceSheet)
            {
                newAccessorialModel = IndividualaccessorialModelsByCarrier?.Where(a => string.Equals(a.CarrierScac, priceSheetModel.CarrierScac, StringComparison.InvariantCultureIgnoreCase)
                                                            && string.Equals(a.AccessorialCode, priceSheetModel.AccessorialCode, StringComparison.InvariantCultureIgnoreCase) && string.Equals("Accessorial", priceSheetModel.chargeType, StringComparison.InvariantCultureIgnoreCase)).Select(b => new IndividualAccessorialModel()
                                                            {
                                                                AccessorialValue = b.AccessorialValue,
                                                                GainShareType = b.GainShareType
                                                            }
                                                             ).FirstOrDefault()

                        ?? IndividualaccessorialModelsByCustomer?.Where(a => string.Equals("Accessorial", priceSheetModel.chargeType, StringComparison.InvariantCultureIgnoreCase) && string.Equals(a.AccessorialCode, priceSheetModel.AccessorialCode, StringComparison.InvariantCultureIgnoreCase)).Select(b => new IndividualAccessorialModel()
                        {
                            AccessorialValue = b.AccessorialValue,
                            GainShareType = b.GainShareType
                        }
                                                             ).FirstOrDefault();

                if (newAccessorialModel != null)
                {
                    if (newAccessorialModel.GainShareType == "% over cost")
                    {
                        priceSheetModel.amount = (Convert.ToDecimal(priceSheetModel.amount) + (Convert.ToDecimal(priceSheetModel.amount) * (newAccessorialModel.AccessorialValue / 100))).ToString();
                        priceSheetModel.GainShareType = "% over cost";
                    }
                    else if (newAccessorialModel.GainShareType == "Set flat amount")
                    {
                        priceSheetModel.amount = newAccessorialModel.AccessorialValue.ToString();
                        priceSheetModel.GainShareType = "Set flat amount";
                    }
                    else if (newAccessorialModel.GainShareType == "Flat over cost")
                    {
                        priceSheetModel.amount = (Convert.ToDecimal(priceSheetModel.amount) + newAccessorialModel.AccessorialValue).ToString();
                        priceSheetModel.GainShareType = "Flat over cost";
                    }
                }
            }

            if (accessorialModalFromPriceSheet.Count() > 0)
            {
                foreach (IndividualAccessorialModel priceSheetModel in accessorialModalFromPriceSheet)
                {
                    newAccessorialModel = priceSheetBasedOnGainShareType?.Where(a => string.Equals(a.CarrierScac, priceSheetModel.CarrierScac, StringComparison.InvariantCultureIgnoreCase)
                    && string.Equals("Accessorial", priceSheetModel.chargeType, StringComparison.InvariantCultureIgnoreCase) && string.Equals(a.AccessorialCode, priceSheetModel.AccessorialCode, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();

                    if (newAccessorialModel != null)
                    {
                        if (string.Equals(newAccessorialModel.CarrierScac, "CTII", StringComparison.InvariantCultureIgnoreCase) && string.Equals("Flat over cost", _gainshareType, StringComparison.InvariantCultureIgnoreCase))
                        {
                            Assert.AreEqual(priceSheetModel.amount, newAccessorialModel.amount);
                            break;
                        }
                        if (string.Equals(newAccessorialModel.CarrierScac, "FXFE", StringComparison.InvariantCultureIgnoreCase) && string.Equals("% over cost", _gainshareType, StringComparison.InvariantCultureIgnoreCase))
                        {
                            Assert.AreEqual(priceSheetModel.amount, newAccessorialModel.amount);
                            break;
                        }
                        if (string.Equals(newAccessorialModel.CarrierScac, "CLNI", StringComparison.InvariantCultureIgnoreCase) && string.Equals("Set flat amount", _gainshareType, StringComparison.InvariantCultureIgnoreCase))
                        {
                            Assert.AreEqual(priceSheetModel.amount, newAccessorialModel.amount);
                            break;
                        }
                    }

                }
            }
        }


        [Then(@"CRM will apply the ""(.*)"" as the accessorial cost")]
        public void ThenCRMWillApplyTheAsTheAccessorialCost(string calculationFormaula)
        {
            ThenCRMWillCalculateTheAccessorial_CostUsingTheFormula(calculationFormaula);
        }

        [Given(@"the customer of the shipment being edited has a Carrier-Specific Set Individual Accessorial,")]
        public void GivenTheCustomerOfTheShipmentBeingEditedHasACarrier_SpecificSetIndividualAccessorial()
        {



            int customerAccountId = DBHelper.GetCustomerAccountId(customerName);


            accessorialModelsByCustomer = DBHelper.GetAccessorials(customerAccountId);
            accessorialModelsByCarrier = DBHelper.GetCarrierAccessorials(customerAccountId);

            if (accessorialModelsByCarrier != null)
            {
                foreach (var carrierData in accessorialModelsByCarrier)
                {
                    IndividualAccessorialModel accData = new IndividualAccessorialModel()
                    {
                        AccessorialCode = carrierData.AccessorialCode,
                        AccessorialValue = carrierData.AccessorialValue,
                        CarrierScac = carrierData.CarrierSCAC,
                        CustomerName = customerName,
                        GainShareType = carrierData.GainShareType
                    };

                    IndividualaccessorialModelsByCarrier.Add(accData);
                }
            }

            if (accessorialModelsByCustomer != null)
            {
                foreach (var customerData in accessorialModelsByCustomer)
                {
                    IndividualAccessorialModel accData = new IndividualAccessorialModel()
                    {
                        AccessorialCode = customerData.AccessorialCode,
                        AccessorialValue = customerData.AccessorialValue,
                        CustomerName = customerName,
                        GainShareType = customerData.GainShareType

                    };
                    IndividualaccessorialModelsByCustomer.Add(accData);
                }
            }


            bool isCustomerhasCarrierAccessorial = accessorialModelsByCarrier.Count > 0 ? true : false;

            if (isCustomerhasCarrierAccessorial)
            {
                Report.WriteLine("Customer has a Carrier-Specific Set Individual Accessorial");
            }
        }

        [When(@"CRM receives a rate request response from MG for the carrier with specific pricing that includes the Set Individual Accessorial")]
        public void WhenCRMReceivesARateRequestResponseFromMGForTheCarrierWithSpecificPricingThatIncludesTheSetIndividualAccessorial()
        {
            WhenCRMReceivesARateRequestResponseFromMGThatIncludesTheSetIndividualAccessorial();
        }
    }
}