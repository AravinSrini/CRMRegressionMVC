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
    public class AddAdditionalServiceDays : IAddAdditionalServiceDays
    {
        public List<AddAdditionalServiceDaysModel> GetAdditionalServiceDays()
        {
            List<AddAdditionalServiceDaysModel> serviceDaysList = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;");
                serviceDaysList = (from b in context.CarrierAddtionalServiceDays
                                   select new AddAdditionalServiceDaysModel
                                   {
                                       CarrierName = b.CarrierName,
                                       ScacCode = b.ScacCode,
                                       ServiceDays = b.AdditionalServiceDays
                                   }).ToList();
            }

            return serviceDaysList;
        }
    }
}
