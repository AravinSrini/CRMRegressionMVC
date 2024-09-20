using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.Interfaces;
using System.Linq;

namespace CRM.UITest.Helper.Implementations
{
    public class GetCustomerRatingLogicAuditInfo : IGetCustomerRatingLogicAuditInfo
    {
        CustomerRatingLogicAuditModel IGetCustomerRatingLogicAuditInfo.GetCustomerRatingLogicAuditInfo(string customerAccountName)
        {
            CustomerRatingLogicAuditModel customerRatingLogicAudit = new CustomerRatingLogicAuditModel();

            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;");
                customerRatingLogicAudit = (from ratingLogicAudit in context.CustomerRatingLogicAudits
                                            join ca in context.CustomerAccounts
                                            on ratingLogicAudit.CustomerAccountId equals ca.CustomerAccountId
                                            join cs in context.CustomerSetups
                                            on ca.CustomerSetUpId equals cs.CustomerSetupId
                                            where cs.CustomerName == customerAccountName
                                            select new CustomerRatingLogicAuditModel
                                            {
                                                OldRatingLogicValue = ratingLogicAudit.OldRatingLogicValue,
                                                NewRatingLogicValue = ratingLogicAudit.NewRatingLogicValue,
                                                CreatedBy = ratingLogicAudit.CreatedBy,
                                                CreatedDate = ratingLogicAudit.CreatedDate,
                                                StationName = ca.StationName,
                                                CustomerName = cs.CustomerName

                                            }).FirstOrDefault();
            }

            return customerRatingLogicAudit;
        }
    }
}
