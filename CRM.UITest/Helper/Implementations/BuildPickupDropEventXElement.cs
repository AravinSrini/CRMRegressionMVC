using CRM.UITest.Helper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CRM.UITest.Helper.Implementations
{
    public class BuildPickupDropEventXElement : IBuildPickupDropEventXElement
    {

        public void AddPickupDropEventDate(DateTime date, ref XElement pickupDropEvent)
        {
            if (date != DateTime.MinValue)
            {
                XAttribute pickupDropEventDate = new XAttribute(
                    "date",
                    date.ToString("MM/dd/yyyy HH:mm"));
                pickupDropEvent.Add(pickupDropEventDate);
            }
        }
    }
}
