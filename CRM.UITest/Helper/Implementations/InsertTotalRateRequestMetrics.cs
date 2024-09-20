using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.Implementations
{
    public class InsertTotalRateRequestMetrics : IInsertTotalRateRequestMetrics
    {
        private const int totalRateRequestCount = 1;
        private const int totalCountZero = 0;

        public void InsertRateRequest(int customerSetupId, string userName)
        {
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");
                MetricsTransactionTable metricsData = new MetricsTransactionTable
                {
                    CustomerSetupId = customerSetupId,
                    CreatedBy = userName,
                    CreatedDate = DateTime.UtcNow,
                    TotalRateRequest = totalRateRequestCount,
                    TotalSavedQuote = totalCountZero,
                    TotalShipments = totalCountZero,
                    TotalQuoteToShipmentConversion = totalCountZero
                };

                context.MetricsTransactionTables.Add(metricsData);
                context.SaveChanges();
            }
        }
    }
}
