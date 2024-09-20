using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.ViewModel
{
   public  class AvailableLoadsViewModel
    {
        public string CarrierSCAC { get; set; }
        public string DeliveryRange { get; set; }
        public string Destination { get; set; }
        public string DestinationCity { get; set; }
        public string DestinationState { get; set; }
        public string DestinationZip { get; set; }
        public string EquipmentType { get; set; }
        public string NoOfDrops { get; set; }
        public string NoOfPickup { get; set; }
        public string Origin { get; set; }
        public string OriginCity { get; set; }
        public string OriginState { get; set; }
        public string OriginZip { get; set; }
        public string PickupRange { get; set; }
        public string PrimaryReference { get; set; }
        public double Weight { get; set; }
        
    }
}
