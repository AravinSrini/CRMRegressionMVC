using CRM.UITest.Helper.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CRM.UITest.Helper.Implementations
{
    public class AddDimensioninItemXElement : IAddDimensioninItemXElement
    {
        public void AddDimension(RateItemModel itemRequest, ref XElement item)
        {
            if ((itemRequest.Length != null || itemRequest.Width != null || itemRequest.Height != null)
                   && !string.IsNullOrWhiteSpace(itemRequest.DimensionUnits))
            {
                //Can not insert null in XML attributes. If the value of entity is null assigning it to default value
                itemRequest.Length = itemRequest.Length ?? 0.0;

                itemRequest.Width = itemRequest.Width ?? 0.0;

                itemRequest.Height = itemRequest.Height ?? 0.0;

                XElement dimensions = new XElement(
                    "Dimensions",
                    new XAttribute("length", itemRequest.Length),
                    new XAttribute("width", itemRequest.Width),
                    new XAttribute("height", itemRequest.Height),
                    new XAttribute("units", itemRequest.DimensionUnits));

                item.Add(dimensions);
            }
        }
    }
}
