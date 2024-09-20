using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.DataModels;
using CRM.UITest.Helper.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CRM.UITest.Helper.Implementations
{
    public class GetStationCarrierDefaultAccessorials : IGetStationCarrierDefaultAccessorials
    {
        public List<DefaultAccessorialSetupModel> GetCarrierDefaultAccessorialsForStation(string stationID)
        {
            List<DefaultAccessorialSetupModel> defaultAccessorials;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;");
                defaultAccessorials = (from accessorialSetup in context.DefaultAccessorialSetups
                                       where accessorialSetup.StationId == stationID && accessorialSetup.CarrierSCAC != null
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
