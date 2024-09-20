using CRM.UITest.Helper.Interfaces;
using CRM.UITest.Helper.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.Implementations
{
    public class AssignAdditionalServiceDays : IAssignAdditionalServiceDays
    {
        public RateResultCarrierViewModel AssignServiceDays(RateResultCarrierViewModel rateResultCarrierViewModel, List<AddAdditionalServiceDaysModel> serviceDaysModel, double serviceDays)
        {

            int serviceDaysInDb = 0;
            if (serviceDaysModel != null)
            {
                foreach (var service in serviceDaysModel)
                {
                    if (service.ScacCode == rateResultCarrierViewModel.ScacCode)
                    {
                        int.TryParse(Convert.ToString(service.ServiceDays), out serviceDaysInDb);
                        rateResultCarrierViewModel.ServiceDays = serviceDays + serviceDaysInDb;
                        break;
                    }
                    else
                    {
                        rateResultCarrierViewModel.ServiceDays = serviceDays;
                    }
                }
            }

            return rateResultCarrierViewModel;
        }
    }
}
