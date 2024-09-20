using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.Implementations
{
    public class GetCsrAccountId : IGetCsrAccountId
    {
        public int GetCsrAccountIdFromDB(string customerName)
        {
            int csrId;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;");
                csrId = (from data in context.CsrCustomerAccounts
                           join item in context.CsrSetups
                           on data.CustomerSetUpId equals item.CustomerSetupId
                           where item.CustomerName == customerName
                           select data.CustomerAccountId).FirstOrDefault();
            }

            return csrId;
        }
    }
}
