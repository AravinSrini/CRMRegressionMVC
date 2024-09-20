using System.Collections.Generic;
using CRM.UITest.Helper.DataModels;
using CRM.UITest.Helper.ViewModel;

namespace CRM.UITest.Helper.Interfaces
{
    public interface IExtractShipments
    {
        /// <summary>
        /// Get all shipment details 
        /// </summary>
        /// <param name="shipmentListViewModels"></param>
        /// <param name="customerName">string</param>
        /// <returns>IEnumerable of ShipmentExtractViewModel</returns>
        IEnumerable<ShipmentExtractViewModel> ShipmentExtract(
            IEnumerable<ShipmentExtractBusinessModel> shipmentListViewModels,
            string customerName);
    }
}
