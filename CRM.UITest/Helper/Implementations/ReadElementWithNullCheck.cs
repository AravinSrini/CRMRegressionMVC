using CRM.UITest.Helper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CRM.UITest.Helper.Implementations
{
    public class ReadElementWithNullCheck : IReadElementWithNullCheck
    {
        public bool ReadXmlElement(XElement element, string nodeName, out string value)
        {
            bool isNodeExist = true;
            value = string.Empty;

            XElement eleNode = element.Element(nodeName);

            if (!string.IsNullOrEmpty(Convert.ToString(eleNode)))
            {
                value = eleNode.Value;
            }
            else
            {
                isNodeExist = false;
            }

            return isNodeExist;
        }
    }
}
