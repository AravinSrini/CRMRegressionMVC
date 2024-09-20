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
    public class ServiceFlagsXelement : IServiceFlagsXelement
    {
        private readonly IServiceCodeNode _serviceCodeNode;

        public ServiceFlagsXelement(IServiceCodeNode serviceCodeNode)
        {
            _serviceCodeNode = serviceCodeNode;
        }

        public XElement BuildServiceFlagsXelement(RateRequestViewModel rateRequest)
        {
            XElement serviceFlags = new XElement("ServiceFlags");

            if (rateRequest.Constraints != null && rateRequest.Constraints.ServiceFlags != null
                && rateRequest.Constraints.ServiceFlags.Any())
            {
                // Build the ServiceFlags XML node
                serviceFlags = _serviceCodeNode.AddServiceCodeNode(rateRequest.Constraints.ServiceFlags);
            }

            return serviceFlags;
        }
    }
}
