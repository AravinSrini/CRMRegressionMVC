using CRM.UITest.Helper.Interfaces.Default_Accessorials;
using System.Collections.Generic;
using System.Linq;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.DataModels;

namespace CRM.UITest.Helper.Implementations.Default_Accessorials
{
    public class GetPrimaryCustomerCarrierAccessorials : IGetPrimaryCustomerCarrierAccessorials
    {
        public List<DefaultAccessorialSetupModel> GetCarrierAccessorialsFromCsrStage(int accountID)
        {
            List<DefaultAccessorialSetupModel> carrierAccessorials = new List<DefaultAccessorialSetupModel>();

            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;");
                carrierAccessorials =  (from accessorialSetup in context.AccessorialSetUps
                                        join csrAccessorial in context.AccessorialCarrierSetUps
                                        on accessorialSetup.AccessorialCode equals csrAccessorial.AccessorialCode
                                        where csrAccessorial.CustomerAccountId == accountID
                                        select new DefaultAccessorialSetupModel
                                        {
                                            AccessorialCode = csrAccessorial.AccessorialCode,
                                            AccessorialName = accessorialSetup.AccessorialName,
                                            AccessorialValue = csrAccessorial.AccessorialValue,
                                            CreatedBy = csrAccessorial.CreatedBy,
                                            CreatedDate = csrAccessorial.CreatedDate,
                                            ModifiedBy = csrAccessorial.ModifiedBy,
                                            ModifiedDate = csrAccessorial.ModifiedDate,
                                            GainshareCostingType = csrAccessorial.GainShareType,
                                            CarrierSCAC = csrAccessorial.CarrierSCAC
                                        }).ToList();

            }
            return carrierAccessorials;

        }
    }
}
