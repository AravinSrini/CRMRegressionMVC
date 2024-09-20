using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.Implementations
{
    public class GetCustomerAccountId : IGetCustomerAccountId
    {
        public int GetCustomerAccountIdFromDb(string name)
        {
            int customerAccountId;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;");
                customerAccountId = (from data in context.CustomerAccounts
                                     join item in context.CustomerSetups
                                         on data.CustomerSetUpId equals item.CustomerSetupId
                                     where item.CustomerName == name
                                     select data.CustomerAccountId).FirstOrDefault();
            }

            return customerAccountId;
        }
    }
}
