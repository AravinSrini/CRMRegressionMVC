using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.ViewModel
{
    public class RateRequestViewModel
    {
        public RateConstraintsModel Constraints { get; set; }

        public List<RateItemModel> Items { get; set; }

        public RateEventModel PickupEvent { get; set; }

        public RateEventModel DropEvent { get; set; }

        public List<ReferenceNumberModel> ReferenceNumbers { get; set; }

        public string RatingLevel { get; set; }

        public bool? IsCompanyAccountNumber { get; set; }

        public int? RatingCount { get; set; }

        public int? LinearFeet { get; set; }

        public bool? ReturnAssociatedCarrierPricesheet { get; set; }

        public int? MaxPriceSheet { get; set; }

        public double ShipmentValue { get; set; }

        public string SourceSystem { get; set; }

        public string CustomerStationEmail { get; set; }

        public string InsuredType { get; set; }
    }
}
