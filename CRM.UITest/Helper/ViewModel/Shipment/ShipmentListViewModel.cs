using System;
using Newtonsoft.Json;

namespace CRM.UITest.Helper.ViewModel.Shipment
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

        public string OriginAddress2 { get; set; }

        public string DestinationName { get; set; }

        public string DestinationAddress { get; set; }

        public string DestinationAddress2 { get; set; }

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

        public string ServiceType { get; set; }

        public string PRONumber { get; set; }

        public string ContainerNumber { get; set; }

        public string CustomerName { get; set; }

        public string StationName { get; set; }

        public string EstCost { get; set; }

        public string EstMargin { get; set; }

        public string EstRevenue { get; set; }

        public string BillToName { get; set; }

        public string BillToZip { get; set; }

        public string BillToCountry { get; set; }

        public string BillToCity { get; set; }

        public string BillToState { get; set; }

        public string InternalID { get; set; }

        public string Owner { get; set; }

        public string Invoices { get; set; }
    }
}

