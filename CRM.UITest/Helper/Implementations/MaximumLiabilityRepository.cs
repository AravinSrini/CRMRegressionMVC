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
    public class MaximumLiabilityRepository : IMaximumLiabilityRepository
    {
        public InsuredRateCarrierViewModel GetMaximumLiabilites(string carrierCode)
        {
            InsuredRateCarrierViewModel insuredRateCarrierViewModel = null;

            using (WWProxyEntities entity = new WWProxyEntities())
            {
                entity.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;");
                insuredRateCarrierViewModel = (from a in entity.InsuredRateCarriers
                                               where a.CarrierCode.ToUpper() == carrierCode.ToUpper()
                                               select new InsuredRateCarrierViewModel
                                               {
                                                   CarrierCode = a.CarrierCode,
                                                   CarrierName = a.CarrierName,
                                                   NewMaximumLiabilityCoverage = a.MaximumLiabilityNew__,
                                                   UsedMaximumLiabilityCoverage = a.MaximumLiabilityUsed__,
                                                   NewCostPerPound = a.CostPerPoundNew,
                                                   UsedCostPerPound = a.CostPerPoundUsed_
                                               }).FirstOrDefault();
            }

            return insuredRateCarrierViewModel;
        }
    }
}
