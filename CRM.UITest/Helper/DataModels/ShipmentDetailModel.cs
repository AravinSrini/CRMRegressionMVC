using System.Collections.Generic;

namespace CRM.UITest.Helper.DataModels
{
    /// <summary>
    /// ViewModel for ShipmentDetail
    /// </summary>
    public class ShipmentDetailModel
    {
        public List<string> AdditionalServices { get; set; }

        public string SpecialInstructions { get; set; }

        public List<string> EquipmentType { get; set; }

        public List<string> EquipmentTypeCode { get; set; }

        public bool? ShipmentCoverage { get; set; }
    }
}
