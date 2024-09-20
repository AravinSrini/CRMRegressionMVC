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
using System.Configuration;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Quote.Rating_Logic
{

    [Binding]
    public class Quote_LTL__Accessorial_Gainshare_type___CRM_Rating_Logic_Steps : Quotelist
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

        List<AccessorialCarrierSetUp> CustomerCarrierAccessorials = new List<AccessorialCarrierSetUp>();
        List<AccessorialCustomerSetUp> CustomerAccessorials = new List<AccessorialCustomerSetUp>();

        List<IndividualAccessorialModel> AccessorialFromPriceSheet = new List<IndividualAccessorialModel>();
        List<IndividualAccessorialModel> PriceSheetFromGainShareType = new List<IndividualAccessorialModel>();

        IndividualAccessorialModel NewAccessorialModel;

        List<IndividualAccessorialModel> IndividualAccessorialForCustomer = new List<IndividualAccessorialModel>();
        List<IndividualAccessorialModel> IndividualAccessorialForCarrier = new List<IndividualAccessorialModel>();


        [Given(@"I am a shpinquiry shpentry sales sales management operations or station owner user")]
        public void GivenIAmAShpinquiryShpentrySalesSalesManagementOperationsOrStationOwnerUser()
        {
            Report.WriteLine("Logging in as shipentry");
            string username = ConfigurationManager.AppSettings["username-shipentry"].ToString();
            string password = ConfigurationManager.AppSettings["password-shipentry"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"I am submitting an LTL rate request (.*), (.*)")]
        public void GivenIAmSubmittingAnLTLRateRequest(string classification, string weight)
        {
            Click(attributeName_xpath, QuoteList_Button_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();

            Click(attributeName_xpath, QuoteList_SubmitQuote_Button_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();

            Click(attributeName_xpath, GetQuote_LtlButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();

            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(LTL_ClassificationValues_Xpath));
            int DropDownCount = DropDownList.Count;

            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == classification)
                {
                    DropDownList[i].Click();
                    break;
                }
            }

            SendKeys(attributeName_id, LTL_Weight_Id, weight);
        }


        [Given(@"I am creating an LTL rate request,")]
        public void GivenIAmCreatingAnLTLRateRequest()
        {
            ClickAndWaitMethods clickndwait = new ClickAndWaitMethods();
            clickndwait.ClickAndWait(attributeName_xpath, QuoteIconModule_Xpath);

            Report.WriteLine("Selecting a Customer from dropdown list");            
            Report.WriteLine("Select Customer Name from the dropdown list");
            Click(attributeName_xpath, QuoteList_CustomerDropdown_Label_Xpath);

            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_CustomerDropdownList_Xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == customerName)
                {
                    DropDownList[i].Click();
                    break;
                }
            }
            clickndwait.ClickAndWait(attributeName_xpath, QuoteList_SubmitQuote_Button_Xpath);
            clickndwait.ClickAndWait(attributeName_xpath, GetQuote_LtlButton_Xpath);
            AddQuoteLTL quoteLtl = new AddQuoteLTL();
            GlobalVariables.webDriver.WaitForPageLoad();
            quoteLtl.EnterOriginZip("33126");
            quoteLtl.EnterDestinationZip("85282");
            GlobalVariables.webDriver.WaitForPageLoad();
            quoteLtl.selectShippingToServices("Inside Delivery");            
            scrollElementIntoView(attributeName_id, LTL_SavedItemDropdown_Id);
            quoteLtl.EnterItemdata("50", "12");
            quoteLtl.EnterLWH("1", "1", "1", "LTL");
            Click(attributeName_id, LTL_ViewQuoteResults_Id);
            
        }

        [Given(@"I am re-quoting an expired LTL quote,")]
        public void GivenIAmRe_QuotingAnExpiredLTLQuote()
        {
            string Quotenumber = "QTWB50003517";
            ClickAndWaitMethods clickndwait = new ClickAndWaitMethods();
            clickndwait.ClickAndWait(attributeName_xpath, QuoteIconModule_Xpath);

            Report.WriteLine("Selecting a Customer from dropdown list");
            Click(attributeName_xpath, QuoteList_ClickCustomerDropdown_xpath);
            Report.WriteLine("Selecting" + customerName + "from the Customer dropdown list");

            IList<IWebElement> CustomerDropdown_List = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='CategoryType_chosen']/div/ul/li"));
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
            SendKeys(attributeName_id, QuoteList_Search_Box_Id, Quotenumber);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, QuoteList_TopGrid_expandquote_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, QuoteDetails_RequoteButton_id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, LTL_ViewQuoteResults_Id);
        }


        [Given(@"my customer has a Set Individual Accessorials,")]
        public void GivenMyCustomerHasASetIndividualAccessorials()
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

        [Given(@"the Accessorial GainshareType is (.*),")]
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

        [Given(@"CRM Rating Logic = Yes,")]
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

        [Given(@"the rate request from CRM included the Set Individual Accessorials,")]
        public void GivenTheRateRequestFromCRMIncludedTheSetIndividualAccessorials()
        {
            Report.WriteLine("Selected Accessorial Value when creating LTL shipment. So Individual Accessorial will be included to Rate Request");
        }

        [When(@"CRM receives a rate responses from MG(.*), (.*) ,(.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*),(.*),(.*), (.*),(.*)")]
        public void WhenCRMReceivesARateResponsesFromMG(string Customer_Name, string Service, string OriginCity, string OriginZip, string OriginState, string OriginCountry, string DestinationCity, string DestinationZip, string DestinationState, string DestinationCountry, string Classification, double Quantity, double Weight, string UserType)
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

        [Given(@"my customer has a Carrier-Specific Set Individual Accessorials,")]
        public void GivenMyCustomerHasACarrier_SpecificSetIndividualAccessorials()
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


        [Then(@"CRM will calculate the accessorials cost using the formula (.*)")]
        public void ThenCRMWillCalculateTheAccessorialsCostUsingTheFormula(string gainShareType)
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

    }


}