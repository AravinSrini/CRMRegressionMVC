using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CRM.UITest.Helper.Interfaces
{
    public interface IReadElementWithNullCheck
    {
        bool ReadXmlElement(XElement element, string nodeName, out string value);
    }
}
