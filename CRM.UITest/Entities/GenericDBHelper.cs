using CRM.UITest.Entities.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CRM.UITest.Entities
{
    class GenericDBHelper<T> where T : class
    {
        public static List<T> FindAll(Func<T, bool> filter, int take=0)
        {
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");
                if (take == 0)
                    return context.Set<T>().Where(filter).ToList();
                else
                    return context.Set<T>().Where(filter).Take(take).ToList();
            }            
        }

    }
}
