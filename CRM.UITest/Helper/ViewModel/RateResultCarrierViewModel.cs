using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.ViewModel
{
    public class RateResultCarrierViewModel
    {

       // [Required(ErrorMessage = "CarrierName is required")]
        public string CarrierName { get; set; }

        public int CarrierId { get; set; }

        public double ServiceDays { get; set; }

        public double Distance { get; set; }

        public string ContractId { get; set; }

        public List<CostComponents> InsuredRateCharges { get; set; }

       // [Required(ErrorMessage = "Charges are required")]
        public List<CostComponents> Charges { get; set; }

       // [Required(ErrorMessage = "Pricesheet is required")]
        public string Pricesheets { get; set; }

        public string ServiceLane { get; set; }

        public bool IsGuaranteedCarrier { get; set; }

        public bool IsGuaranteedCarrierPrice { get; set; }

        public string ScacCode { get; set; }

        public bool IsInsuredRates { get; set; }

        public string MarkupPercentage { get; set; }

        public string MinAmountCharge { get; set; }

        public string MaximumLiabilityUsed { get; set; }

        public string MaximumLiabilityNew { get; set; }

        public string CarrierLogoPath { get; set; }

        public string NewCostPerPound { get; set; }

        public string UsedCostPerPound { get; set; }

        public List<CostComponents> EstCharges { get; set; }

        public string EstMargin { get; set; }

    }
}
