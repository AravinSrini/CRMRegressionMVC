
namespace CRM.UITest.Helper.DataModels
{
    /// <summary>
    /// View model for Item
    /// </summary>
    public class ItemBusinessModel
    {
        public string ItemId { get; set; }

        public string Classification { get; set; }

        public string NmfcCode { get; set; }

        public string Quantity { get; set; }

        public string QuantityUnit { get; set; }

        public string QuantityUnitName { get; set; }

        public string Weight { get; set; }

        public string WeightUnit { get; set; }

        public string DollarValue { get; set; }

        public string Length { get; set; }

        public string Height { get; set; }

        public string Width { get; set; }

        public string DimensionUnit { get; set; }

        public string ItemDescription { get; set; }

        public bool IsSaved { get; set; }

        public bool IsHazardous { get; set; }

        public ShipmentImportHazMatDetailModel ShipmentImportHazMatDetailViewModels { get; set; }        
    }
}
