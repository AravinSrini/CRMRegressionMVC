using CRM.UITest.Helper.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CRM.UITest.Helper.Interfaces
{
    public interface IBuildHazardousMaterialXml
    {
        void BuildHazardousXelement(ShipmentImportHazMatDetailModel hazardousMaterial, string contactPhone, ref XElement hazardousXelement);
    }
}
