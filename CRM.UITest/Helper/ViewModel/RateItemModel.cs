using CRM.UITest.Helper.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.ViewModel
{
    public class RateItemModel
    {
        public string Name { get; set; }

        public string FreightClass { get; set; }

        public double Weight { get; set; }

        public string WeightUnits { get; set; }

        public double? Width { get; set; }

        public double? Length { get; set; }

        public double? Height { get; set; }

        public string DimensionUnits { get; set; }

        public double Quantity { get; set; }

        public string QuantityUnits { get; set; }

        public int? MonetaryValue { get; set; }

        public int? Cube { get; set; }

        public bool? IsHazardous { get; set; }

        public ShipmentImportHazMatDetailModel HazardousMaterial { get; set; }

    }
}
