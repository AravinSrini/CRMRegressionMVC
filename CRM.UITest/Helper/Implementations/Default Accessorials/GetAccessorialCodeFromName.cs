using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.Interfaces.Default_Accessorials;
using System.Linq;

namespace CRM.UITest.Helper.Implementations.Default_Accessorials
{
    public class GetAccessorialCode : IGetAccessorialCodeFromName
    {
        public string GetAccessorialCodeFromName(string accessorialName)
        {
            string accessorialCode;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;");
                accessorialCode = (from setup in context.AccessorialSetUps
                                   where setup.AccessorialName == accessorialName
                                   select setup.AccessorialCode).FirstOrDefault();
            }


            return accessorialCode;
        }
    }
}
