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
    public class GetDefaultInsAllRiskDetails : IGetDefaultInsAllRiskDetails
    {
        public InsAllRiskViewModel GetDefaultInsAllRisk()
        {
            InsAllRiskViewModel defaultInsAllRiskDetails = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;");
                defaultInsAllRiskDetails = (from ins in context.DefaultInsSettings
                                            select new InsAllRiskViewModel
                                            {
                                                DefaultInsSettingId = ins.DefaultInsSettingId,
                                                DefaultcostPerHundred = ins.DefaultCostPerHundred.ToString(),
                                                DefaultMinimumCost = ins.DefaultMinimumInsCost.ToString(),
                                                DefaultMaximumCost = ins.DefaultMaximumInsCost.ToString()
                                            }).FirstOrDefault();
            }

            return defaultInsAllRiskDetails;
        }
    }
}
