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
    public class ItemXElement : IItemXElement
    {
        private readonly IAddWeightinItemXElement _addWeightinItemXElement;
        private readonly IAddQuantityinItemXElement _addQuantityinItemXElement;
        private readonly IAddDimensioninItemXElement _addDimensioninItemXElement;
        private readonly IHazardousMaterialXmlAgent _hazardousMaterialXmlAgent;
        private readonly IBuildItemAttributes _buildItemAttributes;

        public ItemXElement(IAddWeightinItemXElement addWeightinItemXElement, IAddQuantityinItemXElement addQuantityinItemXElement,
            IAddDimensioninItemXElement addDimensioninItemXElement, IHazardousMaterialXmlAgent hazardousMaterialXmlAgent,
            IBuildItemAttributes buildItemAttributes)
        {
            _addWeightinItemXElement = addWeightinItemXElement;
            _addQuantityinItemXElement = addQuantityinItemXElement;
            _addDimensioninItemXElement = addDimensioninItemXElement;
            _hazardousMaterialXmlAgent = hazardousMaterialXmlAgent;
            _buildItemAttributes = buildItemAttributes;
        }

        public XElement BuildItemXElement(RateRequestViewModel rateRequest)
        {
            XElement items = new XElement("Items");

            if (rateRequest.Items != null && rateRequest.Items.Any())
            {
                int i = 0;
                foreach (RateItemModel itemRequest in rateRequest.Items)
                {
                    i = i + 1;

                    XElement item = _buildItemAttributes.BuildAttributes(itemRequest, i);

                    items.Add(item);

                    //Build the optional fields 
                    _addWeightinItemXElement.AddWeight(itemRequest, ref item);

                    _addQuantityinItemXElement.AddQuantity(itemRequest, ref item);

                    _addDimensioninItemXElement.AddDimension(itemRequest, ref item);

                    item.Add(new XElement("HazardousMaterial", itemRequest.IsHazardous != null ? itemRequest.IsHazardous : false));

                    XElement hazardousMaterial = _hazardousMaterialXmlAgent.CreateHazardousXml(itemRequest);

                    item.Add(hazardousMaterial);

                }
            }

            return items;
        }
    }
}
