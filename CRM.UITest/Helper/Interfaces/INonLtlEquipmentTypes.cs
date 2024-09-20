using System.Collections.Generic;
using CRM.UITest.Helper.DataModels;

namespace CRM.UITest.Helper.Interfaces
{
    /// <summary>
    /// GetNonLtlEquipmentTypes Interface
    /// </summary>
    public interface INonLtlEquipmentTypes
    {
        /// <summary>
        /// GetNonLTLEquipmentTypes
        /// </summary>
        /// <return> IEnumerable of CodeTableViewModel </return>
        IEnumerable<CodeTableViewModel> GetNonLtlEquipmentTypes();
    }
}
