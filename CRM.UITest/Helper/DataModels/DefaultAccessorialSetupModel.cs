using CRM.UITest.Entities.Proxy;
using System;

namespace CRM.UITest.Helper.DataModels
{
    public class DefaultAccessorialSetupModel
    {
        public int DefaultAccessorialSetupId { get; set; }
        public string CarrierSCAC { get; set; }
        public string AccessorialCode { get; set; }
        public string AccessorialName { get; set; }
        public decimal AccessorialValue { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public int GainshareCostingTypeId { get; set; }
        public string StationId { get; set; }

        public string GainshareCostingType { get; set; }
    }
}