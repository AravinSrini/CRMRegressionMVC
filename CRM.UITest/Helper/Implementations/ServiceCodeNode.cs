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
    public class ServiceCodeNode : IServiceCodeNode
    {
        public XElement AddServiceCodeNode(List<ServiceFlagModel> services)
        {
            XElement serviceFlags = new XElement("ServiceFlags");

            foreach (ServiceFlagModel service in services)
            {
                if (!string.IsNullOrWhiteSpace(service.ServiceCode) && service.ServiceCode.ToUpper() != "INAR")
                {
                    XElement serviceFlag = new XElement("ServiceFlag", new XAttribute("code", service.ServiceCode.ToUpper()));

                    serviceFlags.Add(serviceFlag);
                }
            }

            return serviceFlags;
        }
    }
}
