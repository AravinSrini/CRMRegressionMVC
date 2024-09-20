using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CRM.UITest.Helper.Interfaces
{
    public interface IBuildPickupDropEventXElement
    {
        void AddPickupDropEventDate(DateTime date, ref XElement pickupEvent);
    }
}
