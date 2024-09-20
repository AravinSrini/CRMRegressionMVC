using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.ViewModel.RateModel
{
    public class QuoteListExtractModel
    {
        public string QuoteReferenceNumber { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string Status { get; set; }

        public string SubmittedBy { get; set; }

        public string ServiceType { get; set; }

        public string ServiceLevel { get; set; }

        public string QuoteAmount { get; set; }

        public string CustomerName { get; set; }

        public string CarrierName { get; set; }

        public DateTime? PickUpDate { get; set; }

        public DateTime? Deliverydate { get; set; }

        public string EstCost { get; set; }

        public string EstMargin { get; set; }
    }
}
