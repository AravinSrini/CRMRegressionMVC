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
    public class BuildEquipmentsXelement : IBuildEquipmentsXelement
    {
        private readonly IEquipmentsCodeNode _equipmentsCodeNode;
        public BuildEquipmentsXelement(IEquipmentsCodeNode equipmentsCodeNode)
        {
            _equipmentsCodeNode = equipmentsCodeNode;
        }
        public XElement BuildEquipmentsXElements(RateRequestViewModel rateRequest)
        {
            // *** 
            // *** Build the Equipments XML node
            // *** 
            XElement equipmentNode = new XElement("Equipments");

            if (rateRequest.Constraints != null && rateRequest.Constraints.Equipments != null
                && rateRequest.Constraints.Equipments.Any())
            {
                equipmentNode = _equipmentsCodeNode.AddEquipmentCodeNode(rateRequest.Constraints.Equipments);

            }

            return equipmentNode;
        }

    }
}
