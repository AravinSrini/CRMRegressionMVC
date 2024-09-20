using System.Collections.Generic;
using CRM.UITest.Helper.ViewModel;

namespace CRM.UITest.Helper.Interfaces
{
    /// <summary>
    /// GetQuantityUnits Interface
    /// </summary>
    public interface IQuantityUnit
    {
        /// <summary>
        /// GetQuantityUnits
        /// </summary>
        /// <return> List of UnitsViewModel </return>
        IEnumerable<UnitsViewModel> GetQuantityUnit();
    }
}
