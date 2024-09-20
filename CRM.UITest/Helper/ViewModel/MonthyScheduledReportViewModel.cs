using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.ViewModel
{
    class MonthyScheduledReportViewModel
    {
        public int MonthlyScheduledReportId { get; set; }
        public int ScheduledReportId { get; set; }
        public string Months { get; set; }
        public Nullable<int> Week { get; set; }
        public string WeekDay { get; set; }
        public Nullable<int> DayOfMonth { get; set; }
        public System.TimeSpan MonthlyReportTime { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public System.DateTime ModifiedDate { get; set; }

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
