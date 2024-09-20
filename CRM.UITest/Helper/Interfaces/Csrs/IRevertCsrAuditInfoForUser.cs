using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.Interfaces.Csrs
{
    public interface IRevertCsrAuditInfoForUser
    {
        void RevertCsrAuditInfoForUser(string customerAccountName);
    }
}
