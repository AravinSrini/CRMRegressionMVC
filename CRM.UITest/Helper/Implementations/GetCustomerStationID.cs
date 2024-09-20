using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.Interfaces;
using System.Linq;
using System;

namespace CRM.UITest.Helper.Implementations
{
    public class GetCustomerStationID : IGetCustomerStationID
    {
        public string GetStationIDFromCustomerName(string customerName)
        {
            string stationID;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;");
                stationID = (from custAccount in context.CustomerAccounts
                             join custSetup in context.CustomerSetups
                                         on custAccount.CustomerSetUpId equals custSetup.CustomerSetupId
                             where custSetup.CustomerName == customerName
                             select custAccount.StationId).FirstOrDefault();
            }

            return stationID;
        }
    }
}
