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
    public class AddWeightinItemXElement : IAddWeightinItemXElement
    {
        public void AddWeight(RateItemModel itemRequest, ref XElement item)
        {
            if (itemRequest.Weight != 0.0 && !string.IsNullOrWhiteSpace(itemRequest.WeightUnits))
            {
                XElement weight = new XElement(
                    "Weight",
                    new XAttribute("units", itemRequest.WeightUnits),
                    itemRequest.Weight);
                item.Add(weight);
            }
        }
    }
}
