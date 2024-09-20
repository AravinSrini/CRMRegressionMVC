using CRM.UITest.Helper.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.Implementations
{
    public class LogErrorMessage : ILogErrorMessage
    {
        public void LogMessage(string errorMessage, string errorDetail)
        {
            Trace.WriteLine(
                string.Format(
                 "{0} Details : {1}", errorMessage, errorDetail),
                "TraceError");
        }
    }
}
