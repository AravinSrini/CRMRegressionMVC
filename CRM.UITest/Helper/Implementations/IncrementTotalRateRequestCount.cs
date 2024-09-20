using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.Implementations
{
    public class IncrementTotalRateRequestCount : IIncrementTotalRateRequestCount
    {
        private const int incrementCounter = 1;

        public void IncrementRateRequestCount(int customerSetupId, string userName)
        {
            DateTime currentDate = DateTime.UtcNow.Date;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");
                MetricsTransactionTable metricsData = (from metrics in context.MetricsTransactionTables
                                                       where (metrics.CustomerSetupId == customerSetupId &&
                                                       (EntityFunctions.TruncateTime(metrics.CreatedDate) == currentDate))
                                                       select metrics).FirstOrDefault();

                if (metricsData != null)
                {
                    metricsData.ModifiedBy = userName;
                    metricsData.ModifiedDateTime = DateTime.UtcNow;
                    metricsData.TotalRateRequest += incrementCounter;

                    context.SaveChanges();
                }
            }
        }
    }
}
