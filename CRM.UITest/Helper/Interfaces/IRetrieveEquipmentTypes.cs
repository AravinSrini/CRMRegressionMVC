using System.Collections.Generic;

namespace CRM.UITest.Helper.Interfaces
{
    public interface IRetrieveEquipmentTypes
    {
        /// <summary>
        /// Read the Equipment code and return the Equipment name
        /// </summary>
        /// <param name="equipmentCode">List of string</param>
        /// <param name="shipmentMode">string</param>
        /// <returns>string</returns>
        List<string> GetEquipmentType(List<string> equipmentCode, string shipmentMode);
    }
}
