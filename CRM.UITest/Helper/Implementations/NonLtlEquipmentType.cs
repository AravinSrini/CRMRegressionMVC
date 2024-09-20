using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using CRM.UITest.Helper.DataModels;
using CRM.UITest.Helper.Interfaces;

namespace CRM.UITest.Helper.Implementations
{
    public class NonLtlEquipmentTypes : INonLtlEquipmentTypes
	{
		/// <summary>
		/// GetNonLTLEquipmentTypes
		/// </summary>
		/// <return> IEnumerable of CodeTableViewModel </return>
		public IEnumerable<CodeTableViewModel> GetNonLtlEquipmentTypes()
		{
			List<CodeTableViewModel> nonLtlEquipmentTypes = new List<CodeTableViewModel>();

			// ***
			// *** To Read the NonLTLEquipmentTypes XML file 
			// ***
            Assembly asm = Assembly.Load("CrmLegacyDataModels");

			if (asm != null)
			{
				XmlTextReader reader = new XmlTextReader(asm.GetManifestResourceStream(Constants.NonLtlEquipmentTypes));
				XElement xelement = XElement.Load(reader);

				IEnumerable<XElement> values = xelement.Elements();

				nonLtlEquipmentTypes.AddRange(values.Select(element => new CodeTableViewModel()
				{
					Name = element.Attribute(CommonConstants.NameText).Value,
					Value = element.Attribute("value").Value
				}));
			}

			return nonLtlEquipmentTypes;
		}

		/// <summary>
		/// constants
		/// </summary>
		private class Constants
		{
			internal const string NonLtlEquipmentTypes =
				"Rrdl.Dls.Crm.SharedLibrary.DataModels.Resources.NonLtlEquipmentTypes.xml";
		}
	}
}