using CRM.UITest.Helper.Interfaces.Default_Accessorials;
using System.Collections.Generic;
using System.Linq;

using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.DataModels;

namespace CRM.UITest.Helper.Implementations.Default_Accessorials
{
    public class GetCorporateCarrierDefaultAccessorials : IGetCorporateCarrierDefaultAccessorials
    {
        public List<DefaultAccessorialSetupModel> GetCarrierDefaultAccessorialsForCorporate()
        {
            List<DefaultAccessorialSetupModel> defaultAccessorials;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;");
                defaultAccessorials = (from accessorialSetup in context.DefaultAccessorialSetups
                                       where accessorialSetup.CarrierSCAC != null && accessorialSetup.StationId == null
                                       select new DefaultAccessorialSetupModel
                                       {
                                           DefaultAccessorialSetupId = accessorialSetup.DefaultAccessorialSetupId,
                                           CarrierSCAC = accessorialSetup.CarrierSCAC,
                                           AccessorialCode = accessorialSetup.AccessorialCode,
                                           AccessorialName = accessorialSetup.AccessorialName,
                                           AccessorialValue = accessorialSetup.AccessorialValue,
                                           CreatedBy = accessorialSetup.CreatedBy,
                                           CreatedDate = accessorialSetup.CreatedDate,
                                           ModifiedBy = accessorialSetup.ModifiedBy,
                                           StationId = accessorialSetup.StationId,
                                           GainshareCostingType = accessorialSetup.GainshareCostingType.GainshareType,
                                           GainshareCostingTypeId = accessorialSetup.GainshareCostingTypeId,
                                           ModifiedDate = accessorialSetup.ModifiedDate
                                       }).ToList();
            }

            return defaultAccessorials;
        }
    }
}
