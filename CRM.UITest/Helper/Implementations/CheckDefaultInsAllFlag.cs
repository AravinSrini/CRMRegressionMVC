using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.Implementations
{
    public class CheckDefaultInsAllFlag : ICheckDefaultInsAllFlag
    {
        public bool DefaultInsuredRates(string customerName)
        {
            bool isDefaultInsAll = true;

            using (WWProxyEntities entity = new WWProxyEntities())
            {
                entity.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;");
                isDefaultInsAll = (from a in entity.CustomerAccounts
                                   where a.CustomerSetup.CustomerName.ToLower() == customerName.ToLower()
                                   select a.IsDefaultInsAll).FirstOrDefault();
            }

            return isDefaultInsAll;
        }
    }
}
