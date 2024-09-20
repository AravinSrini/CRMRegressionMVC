using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.ViewModel
{
    class WeeklyScheduleReportViewModel
    {
        public string WeekDay { get; set; }
        public System.TimeSpan WeeklyReportTime { get; set; }
        
        public string EmailTo { get; set; }
        public string EmailCC { get; set; }
        public string EmailReplyTo { get; set; }
        public string ReportFormat { get; set; }
        public string EmailSubject { get; set; }
        public string Comment { get; set; }

        public string CustomReportName { get; set; }
        public bool IsScheduled { get; set; }
        public string ReportFrequencyVal { get; internal set; }
    }
}
