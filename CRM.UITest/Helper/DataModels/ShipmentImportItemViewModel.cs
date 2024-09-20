namespace CRM.UITest.Helper.DataModels
{
    public class ShipmentImportItemViewModel
    {
        public string Id { get; set; }

        public string ContainedBy { get; set; }

        public bool? IsShipUnit { get; set; }

        public bool? IsHandlingUnit { get; set; }

        public ShipmentImportItemDimensionsViewModel Dimensions { get; set; }

        public string Description { get; set; }

        public ShipmentImportFreightClassViewModel FreightClasses { get; set; }

        public string Commodity { get; set; }

        public string NmfcCode { get; set; }

        public string StccCode { get; set; }

        public bool? Stackability { get; set; }

        public string TrackingNumber { get; set; }

        public string DeliveryStatus { get; set; }

        public double? MinTemperature { get; set; }

        public double? MaxTemperature { get; set; }

        public string TemperatureUnits { get; set; }

        public bool? HazardousMaterial { get; set; }

        public ShipmentImportHazMatDetailViewModel HazMatDetail { get; set; }

        public ShipmentImportMeasurementViewModel Weights { get; set; }

        public ShipmentImportMeasurementViewModel Quantities { get; set; }
    }
}
