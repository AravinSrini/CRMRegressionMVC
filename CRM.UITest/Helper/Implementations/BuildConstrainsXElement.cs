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
    public class BuildConstrainsXelement : IBuildConstrainsXElement
    {
        private readonly IServiceFlagsXelement _serviceFlagsXelement;
        private readonly IBuildEquipmentsXelement _buildEquipmentsXElement;

        public BuildConstrainsXelement(IServiceFlagsXelement serviceFlagsXelement, IBuildEquipmentsXelement buildEquipmentsXElement)
        {
            _serviceFlagsXelement = serviceFlagsXelement;
            _buildEquipmentsXElement = buildEquipmentsXElement;
        }

        public XElement BuildConstrainsXElements(RateRequestViewModel rateRequest)
        {
            //Build the Constraints XML node.           
            XElement constraints = new XElement(
                "Constraints",
                new XElement("Mode"),
                new XElement("Contract"),
                new XElement("Carrier"),
                _serviceFlagsXelement.BuildServiceFlagsXelement(rateRequest),
                _buildEquipmentsXElement.BuildEquipmentsXElements(rateRequest),
                new XElement("PaymentTerms"));

            return constraints;
        }
    }
}
