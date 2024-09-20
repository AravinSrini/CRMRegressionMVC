using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.Interfaces
{
    public interface IAddCustomReportToDB
    {
        void AddCustomReport(CustomReport reportViewModel);
    }
}
