using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using CRM.UITest.Helper.ViewModel;
using CRM.UITest.Helper.Interfaces;
using System.Configuration;
using System;

namespace CRM.UITest.Helper.Implementations
{
    public class QuantityUnit : IQuantityUnit
    {
        /// <summary>
        /// GetQuantityUnits
        /// </summary>
        /// <return> List of UnitsViewModel </return>		
        public IEnumerable<UnitsViewModel> GetQuantityUnit()
        {
            List<UnitsViewModel> quantityUnits = new List<UnitsViewModel>();

            string path = Environment.CurrentDirectory + ConfigurationManager.AppSettings["QuantityUnitXml"];
            XmlTextReader reader = new XmlTextReader(path);
            XElement xelement = XElement.Load(reader);

            IEnumerable<XElement> values = xelement.Elements();

            quantityUnits.AddRange(values.Select(element => new UnitsViewModel
            {
                Name = element.Attribute(CommonConstants.NameText).Value,
                Code = element.Attribute(CommonConstants.CodeText).Value,
                IsDefault = element.Attribute(CommonConstants.IsDefaultValue).Value
            }));


            return quantityUnits;
        }
    }
}