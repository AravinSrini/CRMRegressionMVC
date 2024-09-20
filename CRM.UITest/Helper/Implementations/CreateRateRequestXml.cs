
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
    public class CreateRateRequestXml : ICreateRateRequestXml
    {
        private readonly IBuildConstrainsXElement _buildConstrainsXElement;
        private readonly IBuildReferenceNumbersXElement _buildReferenceNumbersXElement;
        private readonly IItemXElement _itemXElement;
        private readonly IEventXElement _eventXElement;
        private readonly IDecrypt _decryptCustomerName;
        public CreateRateRequestXml(IDecrypt decryptCustomerName, IBuildConstrainsXElement buildConstrainsXElement,
            IBuildReferenceNumbersXElement buildReferenceNumbersXElement, IItemXElement itemXElement, IEventXElement eventXElement)
        {
            _decryptCustomerName = decryptCustomerName;
            _buildConstrainsXElement = buildConstrainsXElement;
            _buildReferenceNumbersXElement = buildReferenceNumbersXElement;
            _itemXElement = itemXElement;
            _eventXElement = eventXElement;

        }
        public XElement CreateRateRequestsXml(RateRequestViewModel rateRequest)
        {
            // Decrypt the Encrypted Customer Name        
            //rateRequest.RatingLevel = _decryptCustomerName.StringDecryption(rateRequest.RatingLevel);

            // *** Extract the valid Customer Account         
            if (string.IsNullOrWhiteSpace(rateRequest.RatingLevel))
            {
                rateRequest.RatingLevel = string.Empty;
            }
            else
            {
                if (rateRequest.RatingLevel.IndexOf('|') > 0)
                {
                    List<string> custAccountList = rateRequest.RatingLevel.Split('|').Select(x => x.Trim()).ToList();
                    rateRequest.RatingLevel = string.Join("|", custAccountList);
                }
                else
                {
                    rateRequest.RatingLevel = rateRequest.RatingLevel.Trim();
                }
            }

            // Build the Request XML           
            XElement requestXml = new XElement(
                "service-request",
                new XElement("service-id", "XMLRating"),
                new XElement("request-id", "123456789"),
                new XElement(
                    "data",
                    new XElement(
                        "RateRequest",
                        _buildConstrainsXElement.BuildConstrainsXElements(rateRequest),
                        _buildReferenceNumbersXElement.BuildReferenceNumberXElement(rateRequest),
                        _itemXElement.BuildItemXElement(rateRequest),
                        _eventXElement.BuildEventXElement(rateRequest),
                        new XElement("RatingLevel", rateRequest.RatingLevel),
                        new XElement("ReturnAssociatedCarrierPricesheet", "true"))));

            return requestXml;
        }
    }
}
