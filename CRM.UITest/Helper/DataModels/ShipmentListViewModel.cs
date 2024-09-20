using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.DataModels
{
    public class ShipmentListViewModel
    {
        public string PrimaryReference { get; set; }

        public string ReferenceType { get; set; }

        public string PONumber { get; set; }

        public string Status { get; set; }

        public string PickupEarliest { get; set; }

        public string PickupLatest { get; set; }

        public string ActualPickup { get; set; }

        public string DeliveryEarliest { get; set; }

        public string DeliveryLatest { get; set; }

        public string ActualDelivery { get; set; }

        public string OriginName { get; set; }

        public string OriginAddress { get; set; }

        public string DestinationName { get; set; }

        public string DestinationAddress { get; set; }

        public string Quantity { get; set; }

        public string Weight { get; set; }

        public string Mode { get; set; }

        public string CarrierScac { get; set; }

        public string CarrierName { get; set; }

        public string CustomerCharges { get; set; }

        public string PickupWording { get; set; }

        public string DeliveryWording { get; set; }

        public string ShipmentError { get; set; }

        public string DestinationCity { get; set; }

        public string DestinationState { get; set; }

        public string DestinationZip { get; set; }

        public string DestinationCountry { get; set; }

        public string OriginCity { get; set; }

        public string OriginState { get; set; }

        public string OriginZip { get; set; }

        public string OriginCountry { get; set; }

        public string ServiceLevel { get; set; }

        public string PRONumber { get; set; }

        public string ContainerNumber { get; set; }
    }
}
