using System.Collections.Generic;
using System.Linq;
using CRM.UITest.Helper.Interfaces;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.DataModels;

namespace CRM.UITest.Helper.Implementations
{
    public class RetrieveEquipmentTypes : IRetrieveEquipmentTypes
	{
		/// <summary>
		/// Read the Equipment code and return the Equipment name
		/// </summary>
		/// <param name="equipmentCode">List of string</param>
		/// <param name="shipmentMode">string</param>
		/// <returns>string</returns>
		public List<string> GetEquipmentType(List<string> equipmentCode, string shipmentMode)
		{
			List<string> equipmentType = null;

			if (equipmentCode.Contains("None") || equipmentCode.Contains(string.Empty) || equipmentCode.Count == 0)
			{
				equipmentType = new List<string>();
				equipmentType.Add("None");
			}
			else if (equipmentCode.Any())
			{
				string code = equipmentCode[0];

				if (shipmentMode.ToUpper() == "LTL")
				{
					using (WWProxyEntities context = new WWProxyEntities())
					{
                        context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;");
                        equipmentType =
							(from name in context.CodeTables
							 where name.Code == code && name.Type == "Equipment"
							 select name.Name).ToList();
					}
				}
				else
				{
					// *** 
					// *** Call to GetNonLTLEquipmentTypes method of XML helper class.
					// ***
					INonLtlEquipmentTypes getNonLtlEquipmentTypesHelper = new NonLtlEquipmentTypes();
					IEnumerable<CodeTableViewModel> equipmentTypes =
						getNonLtlEquipmentTypesHelper.GetNonLtlEquipmentTypes();

					equipmentType = (from x in equipmentTypes where x.Value == code select x.Name).ToList();
				}
			}

			return equipmentType;
		}
	}
}