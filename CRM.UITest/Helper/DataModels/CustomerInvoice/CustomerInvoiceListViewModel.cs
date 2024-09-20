using System;

namespace CRM.UITest.Helper.DataModels.CustomerInvoice
{
    public class CustomerInvoiceListViewModel
    {
        public string SalesRep { get; set; }

        public string AccountNumber { get; set; }

        public string CustomerNumber { get; set; }

        public string CustomerName { get; set; }

        public string InvoiceNumber { get; set; }

        public string ReferenceIdNumber { get; set; }

        public DateTime InvoiceDate { get; set; }

        public DateTime DueDate { get; set; }

        public decimal OriginalAmount { get; set; }

        public decimal Current { get; set; }

        public int DaysPastDue { get; set; }

        public string DisputeCode { get; set; }

        public string InvoiceStatus { get; set; }

        public string StationName { get; set; }
    }
}
