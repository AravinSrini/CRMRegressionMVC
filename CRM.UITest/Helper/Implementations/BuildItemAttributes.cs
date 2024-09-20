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
    public class BuildItemAttributes : IBuildItemAttributes
    {
        public XElement BuildAttributes(RateItemModel itemRequest, int sequence)
        {
            XElement item = new XElement(
                        "Item",
                        new XAttribute("sequence", sequence),
                        new XAttribute("freightClass", itemRequest.FreightClass != null ? itemRequest.FreightClass : "0"));

            return item;
        }
    }
}
