using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.ViewModel
{
    public class ScheduledReportMonthlyData
    {
        public string Month { get; set; }
        public string Week { get; set; }
        public string WeekDay { get; set; }

        public string SpecificDayOfMonth { get; set; }
        public string Hours { get; set; }
        public string Minutes { get; set; }
        public string Meridiem { get; set; }

        public string To { get; set; }
        public string CC { get; set; }
        public string ReplyTo { get; set; }
        public string Format { get; set; }
        public string Subject { get; set; }
        public string Comments { get; set; }

    }
}
