using CRM.UITest.Entities;
using CRM.UITest.Helper.Interfaces.Csrs;

namespace CRM.UITest.Helper.Implementations.Csrs
{
    public class RevertCsrAuditInforForUser : IRevertCsrAuditInfoForUser
    {
        public void RevertCsrAuditInfoForUser(string customerAccountName)
        {
            DBHelper.RevertCsrAuditInfoForUser(customerAccountName);
        }
    }
}
