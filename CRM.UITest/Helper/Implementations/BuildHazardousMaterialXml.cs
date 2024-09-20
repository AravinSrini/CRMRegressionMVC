using CRM.UITest.Helper.DataModels;
using CRM.UITest.Helper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CRM.UITest.Helper.Implementations
{
    public class BuildHazardousMaterialXml : IBuildHazardousMaterialXml
    {
        public void BuildHazardousXelement(ShipmentImportHazMatDetailModel hazardousMaterial, string contactPhone, ref XElement hazardousXelement)
        {
            hazardousXelement = new XElement(
                    "HazMatDetail",
                    new XElement("HazMatID", hazardousMaterial.HazMatId != null
                            ? hazardousMaterial.HazMatId : string.Empty),
                    new XElement("ProperShippingName", string.Empty),
                    new XElement("PackageGroup", string.IsNullOrWhiteSpace(hazardousMaterial.PackageGroup)
                            ? string.Empty : hazardousMaterial.PackageGroup),
                    new XElement("HazMatClass", string.IsNullOrWhiteSpace(hazardousMaterial.HazMatClass)
                            ? string.Empty : hazardousMaterial.HazMatClass),
                    new XElement("ContactName", string.IsNullOrWhiteSpace(hazardousMaterial.ContactName)
                            ? string.Empty : hazardousMaterial.ContactName),
                    new XElement("ContactPhone", string.IsNullOrWhiteSpace(contactPhone) ? string.Empty : contactPhone),
                    new XElement("HazMatPlacards", false),
                    new XElement("HazMatPlacardsDetails", string.Empty),
                    new XElement("HazMatFlashPointTemp", string.Empty),
                    new XElement("HazMatEMSNumber", string.Empty),
                    new XElement("Comments", string.Empty));
        }
    }
}
