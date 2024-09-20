using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.Implementations
{
    public class GetCustomerSetupId : IGetCustomerSetupId
    {
        public int GetSetupIdValue(string customerName)
        {
            int customerId;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;");
                customerId = (from custAcct in context.CustomerSetups
                              where custAcct.CustomerName == customerName
                              select custAcct.CustomerSetupId).ToList().FirstOrDefault();
            }

            return customerId;
        }
    }
}
