using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper;
using CRM.UITest.Helper.Implementations.Default_Accessorials;
using CRM.UITest.Helper.Interfaces.Default_Accessorials;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.CRM_Rating_Logic
{
    [Binding]
    public sealed class CRM_Rating_Logic_Accessorial_Calculations_Steps
    {
        ISetupDefaultAccessorials setupDefaultAccessorials = new SetupDefaultAccessoirals();
        GetRatesAndCarriersAPICall getRatesAndCarriersAPICall = new GetRatesAndCarriersAPICall();

        List<IndividualAccessorialModel> accessorialsFromAPIResponse;


        [Given(@"I have the customer ""(.*)"" which has the accessorials set up at the customer level")]
        public void GivenIHaveTheCustomerWhichHasTheAccessorialsSetUpAtTheCustomerLevel(string customerName, Table table)
        {
            Report.WriteLine("Adding default accessorials at the customer level");
            List<AccessorialCustomerSetUp> individualAccessorialsToAdd = new List<AccessorialCustomerSetUp>();
            List<AccessorialCarrierSetUp> carrierAccessorialsToAdd = new List<AccessorialCarrierSetUp>();
            foreach (TableRow accessorial in table.Rows)
            {
                if(string.IsNullOrEmpty(accessorial[3]))
                {
                    individualAccessorialsToAdd.Add(new AccessorialCustomerSetUp()
                    {
                        AccessorialCode = accessorial[0],
                        AccessorialValue = decimal.Parse(accessorial[1]),
                        CreatedBy = "Automation  108081",
                        CreatedDate = DateTime.UtcNow,
                        ModifiedBy = "Automation  108081",
                        ModifiedDate = DateTime.UtcNow,
                        GainShareType = accessorial[2]
                    });
                }                
                else
                {
                    carrierAccessorialsToAdd.Add(new AccessorialCarrierSetUp()
                    {
                        AccessorialCode = accessorial[0],
                        AccessorialValue = decimal.Parse(accessorial[1]),
                        CarrierSCAC = accessorial[3],
                        CreatedBy = "Automation  108081",
                        CreatedDate = DateTime.UtcNow,
                        ModifiedBy = "Automation  108081",
                        ModifiedDate = DateTime.UtcNow,
                        GainShareType = accessorial[2]
                    });
                }
            }
            if(!setupDefaultAccessorials.SetupCustomersDefaultAccessorials(customerName, individualAccessorialsToAdd, carrierAccessorialsToAdd))
                Report.WriteFailure("Not able to setup default accessorials correctly");
        }


        [Given(@"I have a sub customer ""(.*)"" which has the accessorials set up at the primary customer ""(.*)"" level")]
        public void GivenIHaveASubCustomerWhichHasTheAccessorialsSetUpAtThePrimaryCustomerLevel(string subCustomer, string primaryCustomer, Table table)
        {
            Report.WriteLine("Adding default accessorials at the primary customer level for a sub customer");
            List<AccessorialCustomerSetUp> individualAccessorialsToAdd = new List<AccessorialCustomerSetUp>();
            List<AccessorialCarrierSetUp> carrierAccessorialsToAdd = new List<AccessorialCarrierSetUp>();
            foreach (TableRow accessorial in table.Rows)
            {
                if (string.IsNullOrEmpty(accessorial[3]))
                {
                    individualAccessorialsToAdd.Add(new AccessorialCustomerSetUp()
                    {
                        AccessorialCode = accessorial[0],
                        AccessorialValue = decimal.Parse(accessorial[1]),
                        CreatedBy = "Automation  108081",
                        CreatedDate = DateTime.UtcNow,
                        ModifiedBy = "Automation  108081",
                        ModifiedDate = DateTime.UtcNow,
                        GainShareType = accessorial[2]
                    });
                }
                else
                {
                    carrierAccessorialsToAdd.Add(new AccessorialCarrierSetUp()
                    {
                        AccessorialCode = accessorial[0],
                        AccessorialValue = decimal.Parse(accessorial[1]),
                        CarrierSCAC = accessorial[3],
                        CreatedBy = "Automation  108081",
                        CreatedDate = DateTime.UtcNow,
                        ModifiedBy = "Automation  108081",
                        ModifiedDate = DateTime.UtcNow,
                        GainShareType = accessorial[2]
                    });
                }
            }
            if (!setupDefaultAccessorials.SetupPrimaryLevelAccessorialsForSubCustomer(subCustomer, primaryCustomer, individualAccessorialsToAdd, carrierAccessorialsToAdd))
                Report.WriteFailure("Not able to setup default accessorials correctly");
        }

        [Given(@"I have the customer ""(.*)"" which has the accessorials set up at the station level")]
        public void GivenIHaveTheCustomerWhichHasTheAccessorialsSetUpAtTheStationLevel(string customerName, Table table)
        {
            Report.WriteLine("Adding default accessorials at the station level");
            List<DefaultAccessorialSetup> accessorialsToAdd = new List<DefaultAccessorialSetup>();
            foreach (TableRow accessorial in table.Rows)
            {
                accessorialsToAdd.Add(new DefaultAccessorialSetup()
                {
                    AccessorialCode = accessorial[1],
                    AccessorialValue = decimal.Parse(accessorial[2]),
                    AccessorialName = accessorial[0],
                    CreatedBy = "Automation  108081",
                    CreatedDate = DateTime.UtcNow,
                    ModifiedBy = "Automation  108081",
                    ModifiedDate = DateTime.UtcNow,
                    GainshareCostingTypeId = 1,
                    CarrierSCAC = string.IsNullOrEmpty(accessorial[4]) ? null : accessorial[4]
                });
            }
            if (!setupDefaultAccessorials.SetupStationLevelAccessorialsForCustomer(customerName, accessorialsToAdd))
                Report.WriteFailure("Not able to setup default accessorials correctly");
        }

        [Given(@"I have the customer ""(.*)"" which has the accessorials set up at the corporate level")]
        public void GivenIHaveTheCustomerWhichHasTheAccessorialsSetUpAtTheCorporateLevel(string customerName, Table table)
        {
            Report.WriteLine("Adding default accessorials at the corporate level");
            List<DefaultAccessorialSetup> accessorialsToAdd = new List<DefaultAccessorialSetup>();
            foreach (TableRow accessorial in table.Rows)
            {
                accessorialsToAdd.Add(new DefaultAccessorialSetup()
                {
                    AccessorialName = accessorial[0],
                    AccessorialCode = accessorial[1],
                    AccessorialValue = decimal.Parse(accessorial[2]),
                    CreatedBy = "Automation  108081",
                    CreatedDate = DateTime.UtcNow,
                    ModifiedBy = "Automation  108081",
                    ModifiedDate = DateTime.UtcNow,
                    GainshareCostingTypeId = 1,
                    CarrierSCAC = string.IsNullOrEmpty(accessorial[4]) ? null : accessorial[4]
                });
            }
            if (!setupDefaultAccessorials.SetupCorporateLevelAccessorialsForCustomer(customerName, accessorialsToAdd))
                Report.WriteFailure("Not able to setup default accessorials correctly");
        }

        [Given(@"I have the sub customer ""(.*)"" for primary customer ""(.*)"" which has the accessorials set up at the station level")]
        public void GivenIHaveTheSubCustomerWhichHasTheAccessorialsSetUpAtTheStationLevel(string customerName, string primaryCustomer, Table table)
        {
            Report.WriteLine("Adding default accessorials at the station level");
            List<DefaultAccessorialSetup> accessorialsToAdd = new List<DefaultAccessorialSetup>();
            foreach (TableRow accessorial in table.Rows)
            {
                accessorialsToAdd.Add(new DefaultAccessorialSetup()
                {
                    AccessorialCode = accessorial[1],
                    AccessorialValue = decimal.Parse(accessorial[2]),
                    AccessorialName = accessorial[0],
                    CreatedBy = "Automation  108081",
                    CreatedDate = DateTime.UtcNow,
                    ModifiedBy = "Automation  108081",
                    ModifiedDate = DateTime.UtcNow,
                    GainshareCostingTypeId = 1,
                    CarrierSCAC = string.IsNullOrEmpty(accessorial[4]) ? null : accessorial[4]
                });
            }
            if (!setupDefaultAccessorials.SetupStationLevelAccessorialsForCustomer(customerName, accessorialsToAdd))
                Report.WriteFailure("Not able to setup default accessorials correctly");
        }

        [Given(@"I have the sub customer ""(.*)"" for primary customer ""(.*)"" which has the accessorials set up at the corporate level")]
        public void GivenIHaveTheSubCustomerWhichHasTheAccessorialsSetUpAtTheCorporateLevel(string customerName, string primaryCustomer, Table table)
        {
            Report.WriteLine("Adding default accessorials at the corporate level");
            List<DefaultAccessorialSetup> accessorialsToAdd = new List<DefaultAccessorialSetup>();
            foreach (TableRow accessorial in table.Rows)
            {
                accessorialsToAdd.Add(new DefaultAccessorialSetup()
                {
                    AccessorialName = accessorial[0],
                    AccessorialCode = accessorial[1],
                    AccessorialValue = decimal.Parse(accessorial[2]),
                    CreatedBy = "Automation  108081",
                    CreatedDate = DateTime.UtcNow,
                    ModifiedBy = "Automation  108081",
                    ModifiedDate = DateTime.UtcNow,
                    GainshareCostingTypeId = 1,
                    CarrierSCAC = string.IsNullOrEmpty(accessorial[4]) ? null : accessorial[4]
                });
            }
            if (!setupDefaultAccessorials.SetupCorporateLevelAccessorialsForCustomer(customerName, accessorialsToAdd))
                Report.WriteFailure("Not able to setup default accessorials correctly");
        }


        [When(@"I send a rate request for ""(.*)"" with the following values ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)""")]
        public void WhenISendARateRequestForWithTheFollowingValues(string Customer_Name, string Service, string OriginCity, string OriginZip, string OriginState,
            string OriginCountry, string DestinationCity, string DestinationZip, string DestinationState, string DestinationCountry, string Classification,
            double Quantity, double Weight, string Username, string usertype, string originAccessorials, string destinationAccessorials)
        {
            string QuantityUNIT = "skids";
            string WeightUnit = "LBS";
            bool iSCrmRatingLogic_GainshareCustomer = DBHelper.CheckNewCrmRatingLogic(Customer_Name);

            if (iSCrmRatingLogic_GainshareCustomer)
            {

                accessorialsFromAPIResponse = GetRatesAndCarriersAPICall.BuildIndividualAccessorialModelFromCostPriceSheet(Customer_Name,
                    Service,
                    OriginCity,
                    OriginZip,
                    OriginState,
                    OriginCountry,
                    DestinationCity,
                    DestinationZip,
                    DestinationState,
                    DestinationCountry,
                    originAccessorials,
                    destinationAccessorials,
                    Classification,
                    Quantity,
                    QuantityUNIT,
                    Weight,
                    WeightUnit,
                    Username,
                    true);
            }
            else
            {
                Report.WriteFailure("Customer not gainshare crm rating logic customer");
            }
        }


        [Then(@"the following accessorials will have the values")]
        public void ThenTheFollowingAccessorialsWillHaveTheValues(Table table)
        {
            foreach (TableRow accessorial in table.Rows)
            {
                List<IndividualAccessorialModel> filteredAcccessorials = accessorialsFromAPIResponse.Where((x => x.discription == accessorial[0] || x.discription == accessorial[1])).ToList();
                if(!string.IsNullOrEmpty(accessorial[3]))
                {
                    filteredAcccessorials = filteredAcccessorials.Where(x => x.CarrierScac == accessorial[3]).ToList();
                }

                if(filteredAcccessorials.Count < 1)
                {
                    string errorMessage = "No Accessoirals found for : " + accessorial[0];
                    Report.WriteFailure(errorMessage);
                }

                foreach (IndividualAccessorialModel filteredAccessorial in filteredAcccessorials)
                {
                    if (filteredAccessorial.amount != accessorial[2])
                    {
                        string errorMessage = "Accessoiral values do not match for : " + accessorial[0];
                        Report.WriteFailure(errorMessage);
                    }
                }
                string message = "Accessorials have the right values for: " + accessorial[0];
                Report.WriteLine(message);
            }
        }
    }
}
