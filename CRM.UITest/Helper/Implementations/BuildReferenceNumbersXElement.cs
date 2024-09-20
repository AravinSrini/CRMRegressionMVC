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
    public class BuildReferenceNumbersXElement : IBuildReferenceNumbersXElement
    {
        public XElement BuildReferenceNumberXElement(RateRequestViewModel rateRequest)
        {
            // ***
            // *** Build the ReferenceNumbers XML node
            // *** 
            XElement referenceNumbers = new XElement("ReferenceNumbers");

            if (rateRequest.ReferenceNumbers != null && rateRequest.ReferenceNumbers.Any())
            {
                foreach (ReferenceNumberModel reference in rateRequest.ReferenceNumbers)
                {
                    XElement referenceNumberElement = new XElement(
                        "ReferenceNumber",
                        new XAttribute("type", reference.ReferenceType),
                        reference.ReferenceNumber.ToUpper());

                    referenceNumbers.Add(referenceNumberElement);
                }
            }

            return referenceNumbers;
        }
    }
}
