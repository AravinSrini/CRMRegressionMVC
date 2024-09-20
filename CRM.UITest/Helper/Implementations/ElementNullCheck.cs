using CRM.UITest.Helper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CRM.UITest.Helper.Implementations
{
    public class ElementNullCheck : IElementNullCheck
    {
        public string ReadElementWithNullCheck(XElement element, string nodeName)
        {
            string value = null;

            // read the specified node value from XElement.if node is empty 
            XElement eleNode = element.Element(nodeName);

            if (!string.IsNullOrWhiteSpace(Convert.ToString(eleNode)))
            {
                if (!string.IsNullOrWhiteSpace(eleNode.Value))
                {
                    value = eleNode.Value;
                }
            }

            return value;
        }
    }
}
