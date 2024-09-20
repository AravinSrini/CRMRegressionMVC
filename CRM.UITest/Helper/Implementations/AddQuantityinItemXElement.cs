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
    public class AddQuantityinItemXElement : IAddQuantityinItemXElement
    {
        public void AddQuantity(RateItemModel itemRequest, ref XElement item)
        {
            if (itemRequest.Quantity != 0.0 && !string.IsNullOrWhiteSpace(itemRequest.QuantityUnits))
            {
                XElement quantity = new XElement(
                    "Quantity",
                    itemRequest.Quantity,
                    new XAttribute("units", itemRequest.QuantityUnits));
                item.Add(quantity);
            }
            else if (!string.IsNullOrWhiteSpace(itemRequest.QuantityUnits))
            {
                XElement quantity = new XElement(
                   "Quantity", 1D,
                   new XAttribute("units", itemRequest.QuantityUnits));
                item.Add(quantity);
            }
        }
    }
}
