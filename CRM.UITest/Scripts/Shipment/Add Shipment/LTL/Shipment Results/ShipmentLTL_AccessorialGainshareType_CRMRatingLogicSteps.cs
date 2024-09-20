using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Configuration;
using TechTalk.SpecFlow;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using System.Collections.Generic;
using CRM.UITest.Helper;
using OpenQA.Selenium;
using System.Threading;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Results
{
    [Binding]
    public class ShipmentLTL_AccessorialGainshareType_CRMRatingLogicSteps : AddShipments
    {
        string customerName = "ZZZ - Czar Customer Test";
        string customerType = "Internal";        
        string nfsc = "123";
       
        List<IndividualAccessorialModel> accessorialModalFromPriceSheet, priceSheetBasedOnGainShareType;
        List<IndividualAccessorialModel> IndividualaccessorialModelsByCustomer = new List<IndividualAccessorialModel>();
        List<IndividualAccessorialModel> IndividualaccessorialModelsByCarrier = new List<IndividualAccessorialModel>();
        IndividualAccessorialModel newAccessorialModel;
        List<AccessorialCustomerSetUp> accessorialModelsByCustomer;
        List<AccessorialCarrierSetUp> accessorialModelsByCarrier;

    [Given(@"I am a  shp\.entry, sales, sales management, operations, or station owner user")]
        public void GivenIAmAShp_EntrySalesSalesManagementOperationsOrStationOwnerUser()
        {
            Report.WriteLine("Logging in as CrmOperation");
            string username = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
            string password = ConfigurationManager.AppSettings["password-crmOperation"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"I am creating an LTL Shipment,")]
        public void GivenIAmCreatingAnLTLShipment()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ShipmentIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();

            AddShipmentLTL ltl = new AddShipmentLTL();
            ltl.SelectCustomerFromShipmentList(customerType, customerName);
            GlobalVariables.webDriver.WaitForPageLoad();
            ltl.AddShipmentOriginData("oName", "oAdd", "33126");
            ltl.AddShipmentDestinationData("dName", "dAdd", "85282");
            scrollElementIntoView(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            Click(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            ltl.AddShipmentFreightDescription("50", nfsc, "1", "12", "test");
            scrollElementIntoView(attributeName_xpath, ViewRatesButton_xpath);
            ltl.ClickViewRates();
            GlobalVariables.webDriver.WaitForPageLoad();

        }

        [Given(@"my customer has a Set Individual Accessorial,")]
        public void GivenMyCustomerHasASetIndividualAccessorial()
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


        [Given(@"CRM Rating Logic = Yes")]
        public void GivenCRMRatingLogicYes()
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

        [Given(@"CRM receives a rate request response from MG that includes the Set Individual Accessorial(.*), (.*) ,(.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*),(.*),(.*), (.*),(.*)")]
        public void GivenCRMReceivesARateRequestResponseFromMGThatIncludesTheSetIndividualAccessorial(string Customer_Name, string Service, string OriginCity, string OriginZip, string OriginState, string OriginCountry, string DestinationCity, string DestinationZip, string DestinationState, string DestinationCountry, string Classification, double Quantity, double Weight, string UserType)
        {
            string QuantityUNIT = "skids";
            string WeightUnit = "LBS";
            string originAccessorials = null;
            string destinationAccessorials = "Linehaul Fee";
            string Username = "";
            Customer_Name = Customer_Name.Trim();
            accessorialModalFromPriceSheet = GetRatesAndCarriersAPICall.BuildIndividualAccessorialModelFromCostPriceSheet(Customer_Name, Service, OriginCity, OriginZip, OriginState, OriginCountry,
                DestinationCity, DestinationZip, DestinationState, DestinationCountry, originAccessorials, destinationAccessorials, Classification, Quantity, QuantityUNIT, Weight, WeightUnit, Username, false);
            priceSheetBasedOnGainShareType = GetRatesAndCarriersAPICall.BuildIndividualAccessorialModelFromCostPriceSheet(Customer_Name, Service, OriginCity, OriginZip, OriginState, OriginCountry,
                DestinationCity, DestinationZip, DestinationState, DestinationCountry, originAccessorials, destinationAccessorials, Classification, Quantity, QuantityUNIT, Weight, WeightUnit, Username, true);
        }

        [When(@"the Accessorial Gainshare Type is (.*)")]
       public void WhenTheAccessorialGainshareTypeIs(string gainShareType)
        {
            Report.WriteLine("Validating for the Gainshare Type " + gainShareType);


            bool IsGainShareTypeMatches = IndividualaccessorialModelsByCarrier?.Any(a => a.GainShareType == gainShareType) ??
                IndividualaccessorialModelsByCustomer?.Any(a => a.GainShareType == gainShareType) ?? false;

            if (IsGainShareTypeMatches)
            {
                Report.WriteLine("Customer have a " + gainShareType + " Accessorial");
            }
            else
            {
                Report.WriteLine("Custoemr don't have a " + gainShareType + " Accessorial");
            }

        }

        [Given(@"the Accessorial Gainshare Type is (.*),")]
        public void GivenTheAccessorialGainshareTypeIs(string gainShareType)
        {
            Report.WriteLine("Validating for the Gainshare Type " + gainShareType);


            bool IsGainShareTypeMatches = IndividualaccessorialModelsByCarrier?.Any(a => a.GainShareType == gainShareType) ??
                IndividualaccessorialModelsByCustomer?.Any(a => a.GainShareType == gainShareType) ?? false;

            if (IsGainShareTypeMatches)
            {
                Report.WriteLine("Customer have a " + gainShareType + " Accessorial");
            }
            else
            {
                Report.WriteLine("Custoemr don't have a " + gainShareType + " Accessorial");
            }
        }




        [Then(@"CRM will calculate the accessorial cost using the formula")]
        public void ThenCRMWillCalculateTheAccessorialCostUsingTheFormula()
        {
            Report.WriteLine("Calculation Logic Started");
            foreach (IndividualAccessorialModel priceSheetModel in accessorialModalFromPriceSheet)
            {
                newAccessorialModel = IndividualaccessorialModelsByCarrier?.Where(a => string.Equals("Accessorial", priceSheetModel.chargeType, StringComparison.InvariantCultureIgnoreCase)
                                                            && string.Equals(a.CarrierScac, priceSheetModel.CarrierScac, StringComparison.InvariantCultureIgnoreCase)
                                                            && string.Equals(a.AccessorialCode, priceSheetModel.AccessorialCode, StringComparison.InvariantCultureIgnoreCase)).Select(b => new IndividualAccessorialModel()
                                                            {
                                                                AccessorialValue = b.AccessorialValue,
                                                                GainShareType = b.GainShareType
                                                            }
                                                             ).FirstOrDefault()

                        ?? IndividualaccessorialModelsByCustomer?.Where(a => string.Equals("Accessorial", priceSheetModel.chargeType, StringComparison.InvariantCultureIgnoreCase)
                                                               && string.Equals(a.AccessorialCode, priceSheetModel.AccessorialCode, StringComparison.InvariantCultureIgnoreCase)).Select(b => new IndividualAccessorialModel()
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
                    }
                    else if (newAccessorialModel.GainShareType == "Set flat amount")
                    {
                        priceSheetModel.amount = priceSheetModel.amount;
                    }
                    else if (newAccessorialModel.GainShareType == "Flat over cost")
                    {
                        priceSheetModel.amount = (Convert.ToDecimal(priceSheetModel.amount) + newAccessorialModel.AccessorialValue).ToString();
                    }
                }
            }

            if (accessorialModalFromPriceSheet.Count() > 0)
            {
                foreach (IndividualAccessorialModel priceSheetModel in accessorialModalFromPriceSheet)
                {
                    newAccessorialModel = priceSheetBasedOnGainShareType?.Where(a => string.Equals("CTII", priceSheetModel.CarrierScac, StringComparison.InvariantCultureIgnoreCase)
                    && string.Equals("Accessorial", priceSheetModel.chargeType, StringComparison.InvariantCultureIgnoreCase)
                                                            && string.Equals(a.AccessorialCode, priceSheetModel.AccessorialCode, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();

                    if (string.Equals("CTII", priceSheetModel.CarrierScac, StringComparison.InvariantCultureIgnoreCase) && string.Equals("Accessorial", priceSheetModel.chargeType, StringComparison.InvariantCultureIgnoreCase))
                    {
                        Assert.AreEqual(priceSheetModel.amount, newAccessorialModel.amount);
                    }

                }
            }

        }

        [Given(@"the rate request from CRM included the Set Individual Accessorial,")]
        public void GivenTheRateRequestFromCRMIncludedTheSetIndividualAccessorial()
        {
            Report.WriteLine("Selected Accessorial Value when creating LTL shipment. So Individual Accessorial will be included to Rate Request");
        }

        [When(@"CRM receives a rate response from MG(.*), (.*) ,(.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*),(.*),(.*), (.*),(.*)")]
        public void WhenCRMReceivesARateResponseFromMG(string Customer_Name, string Service, string OriginCity, string OriginZip, string OriginState, string OriginCountry, string DestinationCity, string DestinationZip, string DestinationState, string DestinationCountry, string Classification, double Quantity, double Weight, string UserType)
        {
            Weight = 12;
            Quantity = 1;
            string QuantityUNIT = "pallets";
            string WeightUnit = "LBS";
            string originAccessorials = null;
            string destinationAccessorials = "Inside Delivery";
            string Username = "";
            Customer_Name = Customer_Name.Trim();
            accessorialModalFromPriceSheet = GetRatesAndCarriersAPICall.BuildIndividualAccessorialModelFromCostPriceSheet(Customer_Name, Service, OriginCity, OriginZip, OriginState, OriginCountry,
                DestinationCity, DestinationZip, DestinationState, DestinationCountry, originAccessorials, destinationAccessorials, Classification, Quantity, QuantityUNIT, Weight, WeightUnit, Username, false);
            priceSheetBasedOnGainShareType = GetRatesAndCarriersAPICall.BuildIndividualAccessorialModelFromCostPriceSheet(Customer_Name, Service, OriginCity, OriginZip, OriginState, OriginCountry,
                DestinationCity, DestinationZip, DestinationState, DestinationCountry, originAccessorials, destinationAccessorials, Classification, Quantity, QuantityUNIT, Weight, WeightUnit, Username, true);
        }

        [Then(@"CRM will calculate the accessorial cost using the formula (.*)")]
        public void ThenCRMWillCalculateTheAccessorialCostUsingTheFormula(string gainShareType)
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
                        if (string.Equals(newAccessorialModel.CarrierScac, "CTII", StringComparison.InvariantCultureIgnoreCase) && string.Equals("Flat over cost", gainShareType, StringComparison.InvariantCultureIgnoreCase))
                        {
                            Assert.AreEqual(priceSheetModel.amount, newAccessorialModel.amount);
                            break;
                        }
                        if (string.Equals(newAccessorialModel.CarrierScac, "FXFE", StringComparison.InvariantCultureIgnoreCase) && string.Equals("% over cost", gainShareType, StringComparison.InvariantCultureIgnoreCase))
                        {
                            Assert.AreEqual(priceSheetModel.amount, newAccessorialModel.amount);
                            break;
                        }
                        if (string.Equals(newAccessorialModel.CarrierScac, "CLNI", StringComparison.InvariantCultureIgnoreCase) && string.Equals("Set flat amount", gainShareType, StringComparison.InvariantCultureIgnoreCase))
                        {
                            Assert.AreEqual(priceSheetModel.amount, newAccessorialModel.amount);
                            break;
                        }
                    }

                }
            }
        }


        [Given(@"my customer has a Carrier-Specific Set Individual Accessorial,")]
        public void GivenMyCustomerHasACarrier_SpecificSetIndividualAccessorial()
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

        [Given(@"CRM receives a rate request response from MG for the carrier with specific pricing that includes the Set Individual Accessorial(.*), (.*) ,(.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*),(.*),(.*), (.*),(.*)")]
        public void GivenCRMReceivesARateRequestResponseFromMGForTheCarrierWithSpecificPricingThatIncludesTheSetIndividualAccessorial(string Customer_Name, string Service, string OriginCity, string OriginZip, string OriginState, string OriginCountry, string DestinationCity, string DestinationZip, string DestinationState, string DestinationCountry, string Classification, double Quantity, double Weight, string UserType)
        {
            string QuantityUNIT = "skids";
            string WeightUnit = "LBS";
            string originAccessorials = null;
            string destinationAccessorials = "Linehaul Fee";
            string Username = "";
            Customer_Name = Customer_Name.Trim();
            accessorialModalFromPriceSheet = GetRatesAndCarriersAPICall.BuildIndividualAccessorialModelFromCostPriceSheet(Customer_Name, Service, OriginCity, OriginZip, OriginState, OriginCountry,
                DestinationCity, DestinationZip, DestinationState, DestinationCountry, originAccessorials, destinationAccessorials, Classification, Quantity, QuantityUNIT, Weight, WeightUnit, Username, false);
            priceSheetBasedOnGainShareType = GetRatesAndCarriersAPICall.BuildIndividualAccessorialModelFromCostPriceSheet(Customer_Name, Service, OriginCity, OriginZip, OriginState, OriginCountry,
                DestinationCity, DestinationZip, DestinationState, DestinationCountry, originAccessorials, destinationAccessorials, Classification, Quantity, QuantityUNIT, Weight, WeightUnit, Username, true);
        }








        [Given(@"I am copying an LTL shipment (.*),")]
        public void GivenIAmCopyingAnLTLShipment(string Usertype)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            if (Usertype == "Internal")
            {
                Click(attributeName_id, ShipmentIcon_Id);
                GlobalVariables.webDriver.WaitForPageLoad();
                Click(attributeName_xpath, ShipmentList_Customer_dropdown_Xpath);

                IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_Customer_dropdownValue_Xpath));
                int DropDownCount = DropDownList.Count;
                for (int i = 0; i < DropDownCount; i++)
                {
                    if (DropDownList[i].Text == customerName)
                    {
                        DropDownList[i].Click();
                        break;
                    }
                }
                GlobalVariables.webDriver.WaitForPageLoad();
            }
            SendKeys(attributeName_id, ShipmentListSearchBox_Id, "ZZX002011707");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, CopyIconFirst_AddShipmentList_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Thread.Sleep(9000);
            Click(attributeName_id, CopyShipmentConfirmButton_Id);
            Thread.Sleep(9000);
            GlobalVariables.webDriver.WaitForPageLoad();
            AddShipmentLTL ltl = new AddShipmentLTL();
            scrollElementIntoView(attributeName_xpath, ViewRatesButton_xpath);
            ltl.ClickViewRates();
            GlobalVariables.webDriver.WaitForPageLoad();
        }





    }
}
