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
    public class HazardousMaterialXmlAgent : IHazardousMaterialXmlAgent
    {
        private readonly IContactPhoneNodeHazardousXml _contactPhoneNodeHazardousXml;
        private readonly IBuildHazardousMaterialXml _buildHazardousMaterialXml;

        public HazardousMaterialXmlAgent(IContactPhoneNodeHazardousXml contactPhoneNodeHazardousXml, IBuildHazardousMaterialXml buildHazardousMaterialXml)
        {
            _contactPhoneNodeHazardousXml = contactPhoneNodeHazardousXml;
            _buildHazardousMaterialXml = buildHazardousMaterialXml;
        }

        public XElement CreateHazardousXml(RateItemModel itemModel)
        {
            XElement hazardousMaterial = default(XElement);

            if (itemModel.IsHazardous == true && itemModel.HazardousMaterial != null)
            {
                //Get ContactPhone Node for the HazardousXml
                string contactPhone = _contactPhoneNodeHazardousXml.GetContactPhoneNode(itemModel.HazardousMaterial);

                //Build the XElement for HazardousMaterial
                _buildHazardousMaterialXml.BuildHazardousXelement(itemModel.HazardousMaterial, contactPhone, ref hazardousMaterial);
            }

            return hazardousMaterial;
        }
    }
}
