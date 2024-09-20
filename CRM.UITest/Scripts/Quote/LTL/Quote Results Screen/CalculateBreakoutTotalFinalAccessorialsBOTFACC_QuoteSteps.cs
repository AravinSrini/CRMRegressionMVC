using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper;
using CRM.UITest.Helper.ViewModel;
using CRM.UITest.Objects;
using CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Quote.LTL.Quote_Results_Screen
{
    [Binding]
    public class CalculateBreakoutTotalFinalAccessorialsBOTFACC_QuoteSteps : ObjectRepository
    {
        RateToShipmentLTL RTS = new RateToShipmentLTL();
        AddQuoteLTL AQL = new AddQuoteLTL();

        List<IndividualAccessorialModel> rlist = null;
        BaseMarkupBreakDownCalcuation baseMarkupDown = null;
        //string CustomerName = "ZZZ - CZar Customer Test";
        //string Service = "COD";
        //string OriginCity = "Miami";
        //string OriginZip = "33126";
        //string OriginState = "FL";
        //string OriginCountry = "USA";
        //string DestinationCity = "Tempe";
        //string DestinationZip = "85282";
        //string DestinationState = "AZ";
        //string DestinationCountry = "USA";
        //string OAccessorial = "COD";
        //string DAccessorial = "APPT";
        //string Classification = "50";
        //Double Quantity = 1;
        //string QuantityUNIT = "SKD";
        //Double Weight = 3;
        //string WeightUnit = "lbs";
        //string CalculationType = "BOIFACC";



       
        [Given(@"I am a DLS user belongs to Gainshare Customer and login into application with valid (.*) and (.*)")]
        public void GivenIAmADLSUserBelongsToGainshareCustomerAndLoginIntoApplicationWithValidAnd(string Username, string Password)
        {
            Report.WriteLine("Launch URL");
            LaunchURL();
            Report.WriteLine("Land on Homepage");
            Click(attributeName_xpath, ".//*[@id='cookiescript_accept']");
            Click(attributeName_id, SignIn_Id);
            Report.WriteLine("Enter valid Username and Password and click on Log in");
            WaitForElementVisible(attributeName_id, IDP_Username_Id, "UserName");
            SendKeys(attributeName_id, IDP_Username_Id, Username);
            SendKeys(attributeName_id, IDP_Password_Id, Password);
            Click(attributeName_xpath, IDP_Login_Xpath);
            //Thread.Sleep(2000);
            DefineTimeOut(5000);
            GlobalVariables.webDriver.WaitForPageLoad();
        }



        [When(@"I am on the quotes results page(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void WhenIAmOnTheQuotesResultsPage(string CustomerName, string UserType, string pickUpCityName, string pickUpZipCode, string pickUpStateCode,
            string pickUpCountry, string dropUpCityName, string dropUpZipCode, string dropUpStateCode, string dropUpCountry, string OAccessorial, string DAccessorial, string freightClass,
            string quantity, string quantityUnit, string weight, string weightUnit,string Username)
        {

            AddQuoteLTL quote = new AddQuoteLTL();
            quote.NaviagteToQuoteList();
            quote.Add_QuoteLTL(UserType, CustomerName);
            Thread.Sleep(4000);
            quote.EnterOriginZip(pickUpZipCode);
            quote.EnterDestinationZip(dropUpZipCode);
            quote.selectShippingfromServices(OAccessorial);
            quote.selectShippingToServices(DAccessorial);
            quote.EnterItemdata(freightClass, weight);
            quote.ClickViewRates();
        }



        public decimal BOTFACCCalculation(string CustomerName, string Service, string OriginCity, string OriginZip, string OriginState, string OriginCountry, string DestinationCity, string DestinationZip, string DestinationState, string DestinationCountry, string
            OAccessorial, string DAccessorial, string Classification, Double Quantity, string QuantityUNIT, Double Weight, string WeightUnit, string Username, string UserType, string CalculationType, string UICarrier)
        {
            rlist = GetRatesAndCarriersAPICall.BuildIndividualAccessorialModelFromCarrierPriceSheet(CustomerName, Service, OriginCity, OriginZip, OriginState, OriginCountry, DestinationCity, DestinationZip, DestinationState, DestinationCountry,
                                                      OAccessorial, DAccessorial, Classification, Quantity, QuantityUNIT, Weight, WeightUnit, Username, false);


            decimal BOTFACC = 0;
            
            for (int j = 0; j < rlist.Count; j++)
            {
                if (rlist[j].carrierName == UICarrier)
                {
                    InsuredRateCarrier f = DBHelper.insuredCarrier(UICarrier);
                    string SCACs = f.CarrierCode;

                    string acc = null;
                    if (DAccessorial == null)
                    {
                        acc = OAccessorial;
                    }
                    else if (OAccessorial == null)
                    {
                        acc = DAccessorial;
                    }
                    else
                    {
                        acc = OAccessorial + "," + DAccessorial;
                    }
                    List<string> name = new List<string>();
                    string[] sp = acc.Split(',');
                    foreach (var r in sp)
                    {
                        string u = DBHelper.AccessorialName_to_Code(r);
                        name.Add(u);
                    }


                    foreach (var r in name)
                    {

                        List<IndividualAccessorialModel> accessorialModelByCarrier = null;
                        accessorialModelByCarrier = DBHelper.CarrierAcc(CustomerName, SCACs);
                        decimal? BOIFACC = accessorialModelByCarrier?.Where(a => a.AccessorialCode == r).Select(a => a?.AccessorialValue).FirstOrDefault();
                        if (BOIFACC == null)
                        {
                            accessorialModelByCarrier = DBHelper.CustAccessor(CustomerName);
                            BOIFACC = accessorialModelByCarrier?.Where(a => a?.AccessorialCode == r)?.Select(a => a?.AccessorialValue).FirstOrDefault();

                            if (BOIFACC == null)
                            {
                                if (r == "COD")
                                {

                                    ////BOTFACC+= //XML read from COD Fee type = accsorila & match = cod fee

                                    //BOIACC+= //XML read 
                                    string Dname = rlist[j].discription;
                                    if (Dname.Contains(r))
                                    {
                                        string assoccorialsAmount = rlist[j].amount;
                                        BOTFACC += Decimal.Parse(assoccorialsAmount);
                                    }


                                }
                                if (r == "APPT")
                                {
                                    string z = "Appointemnt";
                                    string Dname = rlist[j].discription;
                                    if (Dname.Contains(z))
                                    {
                                        string assoccorialsAmount = rlist[j].amount;
                                        BOTFACC += Decimal.Parse(assoccorialsAmount);
                                    }
                                }
                            }
                            else
                            {
                                BOTFACC += (decimal)BOIFACC;
                            }
                        }
                        else
                        {
                            BOTFACC += (decimal)BOIFACC;
                        }

                    }
                    break;
                }

            }

            return BOTFACC;
        }

        [When(@"am on the quotes results page(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void WhenAmOnTheQuotesResultsPage(string CustomerName,string Service, string OriginZip, string DestinationZip,string OAccessorial, string DAccessorial,string Classification, double Quantity, double Weight,string UserType, string insuredvalue)
        {
            RTS.NaviagteToQuoteList();
            //RTS.SelectCustomerFrom_QuotetList(UserType, CustomerName);
            AQL.Add_QuoteLTL(UserType, CustomerName);
            Click(attributeName_id, ClearAddress_OriginId);
            Thread.Sleep(4000);
            AQL.EnterOriginZip(OriginZip);
            Click(attributeName_xpath, LTL_ShipinformationPage_ShippingFrom_Xpath);
            Click(attributeName_id, ClearAddress_DestId);
            AQL.EnterDestinationZip(DestinationZip);
            Click(attributeName_xpath, LTL_ShipinformationPage_ShippingTo_Xpath);
            RTS.selectingDestinationServiceAndAccessorial_Quote(DAccessorial);
            Thread.Sleep(200);
            scrollElementIntoView(attributeName_id, LTL_Quantity_Id);
            string _weight = Weight.ToString();
            AQL.EnterItemdata(Classification, _weight);
            RTS.ClickOnViewQuoteResultsButton_Quote();
        }
        [When(@"am on quotes results page(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void WhenAmOnQuotesResultsPage(string CustomerName, string Service, string OriginZip, string DestinationZip, string OAccessorial, string DAccessorial, string Classification, double Quantity, double Weight, string UserType, string insuredvalue)
        {
            RTS.NaviagteToQuoteList();
            //RTS.SelectCustomerFrom_QuotetList(UserType, CustomerName);
            AQL.Add_QuoteLTL(UserType, CustomerName);
            Click(attributeName_id, ClearAddress_OriginId);
            Thread.Sleep(4000);
            AQL.EnterOriginZip(OriginZip);
            Click(attributeName_xpath, LTL_ShipinformationPage_ShippingFrom_Xpath);
            Click(attributeName_id, ClearAddress_DestId);
            AQL.EnterDestinationZip(DestinationZip);
            Click(attributeName_xpath, LTL_ShipinformationPage_ShippingTo_Xpath);
            RTS.selectingDestinationServiceAndAccessorial_Quote(DAccessorial);
            Thread.Sleep(200);
            scrollElementIntoView(attributeName_id, LTL_Quantity_Id);
            string _weight = Weight.ToString();
            AQL.EnterItemdata(Classification, _weight);
            RTS.ClickOnViewQuoteResultsButton_Quote();
        }


        [When(@"I am on the quotes results page(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void WhenIAmOnTheQuotesResultsPage(string CustomerName, string Service, string OriginZip, string DestinationZip, string OAccessorial, string DAccessorial, string Classification, double Quantity, double Weight, string UserType,string insuredvalue)
        {
            RTS.NaviagteToQuoteList();
            //RTS.SelectCustomerFrom_QuotetList(UserType, CustomerName);
            AQL.Add_QuoteLTL(UserType, CustomerName);
            Click(attributeName_id, ClearAddress_OriginId);
            Thread.Sleep(4000);
            AQL.EnterOriginZip(OriginZip);
            Click(attributeName_xpath, LTL_ShipinformationPage_ShippingFrom_Xpath);
            Click(attributeName_id, ClearAddress_DestId);
            AQL.EnterDestinationZip(DestinationZip);
            Click(attributeName_xpath, LTL_ShipinformationPage_ShippingTo_Xpath);
            RTS.selectingDestinationServiceAndAccessorial_Quote(DAccessorial);
            Thread.Sleep(200);
            scrollElementIntoView(attributeName_id, LTL_Quantity_Id);
            string _weight = Weight.ToString();
            AQL.EnterItemdata(Classification, _weight);
            SendKeys(attributeName_id,LTL_EnterInsuredValue_Id, insuredvalue);
            RTS.ClickOnViewQuoteResultsButton_Quote();
        }


        [Then(@"BOTFACC can be calculated and Verified in the Rate Results page(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public decimal ThenBOTFACCCanBeCalculatedAndVerifiedInTheRateResultsPage(string CustomerName, string Username, string OriginCity, string OriginZip, string OriginState, string OriginCountry, string DestinationCity, string DestinationZip, string DestinationState, string DestinationCountry, string OAccessorial, string DAccessorial, string Classification, double Quantity, string QuantityUNIT, double Weight, string Mode, string UserType, string CalculationType)
        {
            // Username = null;
            //if (UserType == "External")
            //{
            //    Username = "zzzext@user.com";
            //}
            //else if (UserType == "Internal")
            //{
            //    Username = "salesmanager@stage.com";
            //}
            baseMarkupDown = new BaseMarkupBreakDownCalcuation();
            decimal BOTFACC = baseMarkupDown.calculateBaseMarkDownCharges(CustomerName, "Service", OriginCity, OriginZip, OriginState, OriginCountry, DestinationCity, DestinationZip, DestinationState, DestinationCountry, OAccessorial, DAccessorial, Classification, Quantity, QuantityUNIT, Weight, Mode, Username, UserType, CalculationType);
            //Frame UI verifications of BOTFACC
            if (UserType == "External")
            {
                string Accessorial_UI = Gettext(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[4]/ul[1]/li[2]");
                string ActualBOTFACC = BOTFACC.ToString();
                string FinalBOTFACC = "Accessorials: $ " + Math.Round(BOTFACC, 2); 
                //Assert.AreEqual(Accessorial_UI, FinalBOTFACC);
            }
            else if (UserType == "Internal")
            {
                string Accessorial_UI = Gettext(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[5]/ul[1]/li[4]");
                string ActualBOTFACC = BOTFACC.ToString();
                string FinalBOTFACC = "Accessorials: $ " + Math.Round(BOTFACC, 2);
                //Assert.AreEqual(Accessorial_UI, FinalBOTFACC);
            }

            return BOTFACC;
        }


    }
}
