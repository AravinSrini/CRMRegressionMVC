using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.Interfaces;
using CRM.UITest.Helper.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.Implementations
{
    public class GetCustomerInsuranceAllRiskByCustomerAccountId : IGetCustomerInsuranceAllRiskByCustomerAccountId
    {
        public InsAllRiskViewModel GetCustomerInsuranceAllRisk(int customerAccountId)
        {
            InsAllRiskViewModel SpecificInsAllRisk = new InsAllRiskViewModel();

            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;");
                SpecificInsAllRisk = (from ca in context.CustomerAccounts
                                      where ca.CustomerAccountId == customerAccountId
                                      select new InsAllRiskViewModel
                                      {
                                          CustomerSpecificInsAllRisk = new List<CustomerSpecificInsAllRiskViewModel>
                                          {
                                              new CustomerSpecificInsAllRiskViewModel()
                                              {
                                              CustomerSpecificInsAllRiskDetails = new List<CustomerSpecificInsAllRiskDetailsViewModel>
                                              {
                                                   new CustomerSpecificInsAllRiskDetailsViewModel()
                                                   {
                                                  CostPerHundered = ca.CostPerHundred.ToString(),
                                                  MinimumCost = ca.MinimumInsCost!= null ? ca.MinimumInsCost.ToString() : string.Empty,
                                                  MaximumCost = ca.MaximumInsCost != null ? ca.MaximumInsCost.ToString() : string.Empty
                                                  }

                                              }
                                              }
                                          }
                                      }).FirstOrDefault();
            }
            return SpecificInsAllRisk;
        }
    }
}
