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
    public class EquipmentsCodeNode : IEquipmentsCodeNode
    {
        public XElement AddEquipmentCodeNode(List<EquipmentModel> equipment)
        {
            XElement equipmentNode = new XElement("Equipments");

            foreach (EquipmentModel equipments in equipment)
            {
                if (!string.IsNullOrWhiteSpace(equipments.EquipmentCode))
                {
                    XElement equipmentCodes = new XElement(
                        "Equipment",
                        new XAttribute("code", equipments.EquipmentCode.ToUpper()));
                    equipmentNode.Add(equipmentCodes);
                }
            }
            return equipmentNode;
        }
    }
}
