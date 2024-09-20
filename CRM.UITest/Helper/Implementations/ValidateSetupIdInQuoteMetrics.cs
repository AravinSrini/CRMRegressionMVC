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
    public class ValidateSetupIdInQuoteMetrics : IValidateSetupIdInQuoteMetrics
    {
        public bool ValidateSetupId(int setupId)
        {
            bool isExist = false;
            DateTime currentDate = DateTime.UtcNow.Date;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;");
                isExist = (from metrices in context.MetricsTransactionTables
                           where (metrices.CustomerSetupId == setupId &&
                           EntityFunctions.TruncateTime(metrices.CreatedDate) == currentDate)
                           select metrices).Any();
            }

            return isExist;
        }
    }
}
