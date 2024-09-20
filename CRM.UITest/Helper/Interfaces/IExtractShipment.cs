using System.Collections.Generic;
using CRM.UITest.Helper.ViewModel;
using CRM.UITest.Helper.DataModels;


namespace CRM.UITest.Helper.Interfaces
{
    public interface IExtractShipment
        {
        /// <summary>
        /// Method for Shipment Details\Extract
        /// </summary>
        /// <param name="primaryReferenceBol">List of string</param>
        /// <param name="customerName">string</param>
        /// <param name="errorMessage"></param>
        /// <returns>List of ShipmentExtractViewModel</returns>
        IEnumerable<ShipmentExtractViewModel> ShipmentExtract(
        List<UploadTemplateViewModel> primaryReferenceBol,
        string customerName,
        out string errorMessage);
    }
}
