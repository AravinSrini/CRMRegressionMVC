using CRM.UITest.Helper.Interfaces;
using CRM.UITest.Helper.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CRM.UITest.Helper.Implementations
{
    public class EventXElement : IEventXElement
    {
        private readonly IBuildPickupDropEventXElement _buildPickupDropEventXElement;
        public EventXElement(IBuildPickupDropEventXElement buildPickupDropEventXElement)
        {
            _buildPickupDropEventXElement = buildPickupDropEventXElement;

        }
        public XElement BuildEventXElement(RateRequestViewModel rateRequest)
        {
            // Build the pick up event XML node
            if (!string.IsNullOrWhiteSpace(rateRequest.PickupEvent.Country) && (rateRequest.PickupEvent.Country) == "CA")
            {
                rateRequest.PickupEvent.Country = "CANADA";
            }

            if (!string.IsNullOrWhiteSpace(rateRequest.DropEvent.Country) && (rateRequest.DropEvent.Country) == "CA")
            {
                rateRequest.DropEvent.Country = "CANADA";
            }

            XElement pickupEvent = new XElement(
                "Event",
                new XAttribute("sequence", '1'),
                new XAttribute("type", "Pickup"),
                new XElement(
                    "Location",
                    new XElement(
                        "LocationCode",
                        string.IsNullOrWhiteSpace(rateRequest.PickupEvent.LocationCode)
                            ? null
                            : rateRequest.PickupEvent.LocationCode),
                    new XElement(
                        "City",
                        string.IsNullOrWhiteSpace(rateRequest.PickupEvent.City)
                            ? null
                            : rateRequest.PickupEvent.City.ToUpper()),
                    new XElement(
                        "State",
                        string.IsNullOrWhiteSpace(rateRequest.PickupEvent.State) ? null : rateRequest.PickupEvent.State),
                    new XElement(
                        "Zip",
                        string.IsNullOrWhiteSpace(rateRequest.PickupEvent.Zip) ? null : rateRequest.PickupEvent.Zip),
                    new XElement(
                        "Country",
                        string.IsNullOrWhiteSpace(rateRequest.PickupEvent.Country)
                            ? null
                            : rateRequest.PickupEvent.Country.ToUpper())));

            _buildPickupDropEventXElement.AddPickupDropEventDate(rateRequest.PickupEvent.Date, ref pickupEvent);


            // Build the drop event XML node

            XElement dropEvent = new XElement(
                "Event",
                new XAttribute("sequence", "2"),
                new XAttribute("type", "Drop"),
                new XElement(
                    "Location",
                    new XElement(
                        "LocationCode",
                        string.IsNullOrWhiteSpace(rateRequest.DropEvent.LocationCode)
                            ? null
                            : rateRequest.DropEvent.LocationCode),
                    new XElement(
                        "City",
                        string.IsNullOrWhiteSpace(rateRequest.DropEvent.City)
                            ? null
                            : rateRequest.DropEvent.City.ToUpper()),
                    new XElement(
                        "State",
                        string.IsNullOrWhiteSpace(rateRequest.DropEvent.State) ? null : rateRequest.DropEvent.State),
                    new XElement(
                        "Zip",
                        string.IsNullOrWhiteSpace(rateRequest.DropEvent.Zip) ? null : rateRequest.DropEvent.Zip),
                    new XElement(
                        "Country",
                        string.IsNullOrWhiteSpace(rateRequest.DropEvent.Country)
                            ? null
                            : rateRequest.DropEvent.Country.ToUpper())));

            _buildPickupDropEventXElement.AddPickupDropEventDate(rateRequest.DropEvent.Date, ref dropEvent);

            XElement events = new XElement("Events", pickupEvent, dropEvent);

            return events;
        }
    }
}
