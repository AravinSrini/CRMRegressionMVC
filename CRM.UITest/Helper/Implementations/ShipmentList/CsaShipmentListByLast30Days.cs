using System;
using CRM.UITest.Helper.Interfaces.Shipment;
using CRM.UITest.CsaServiceReference;

namespace CRM.UITest.Helper.Implementations.ShipmentList
{
    public class CsaShipmentListByLast30Days : ICsaShipmentListByLast30Days
    {
       public ShipmentListReponse GetCsaShipmentListByLast30Days(int customerNumber, out string errorMessage)
        {
            ShipmentListReponse results = null;
            errorMessage = string.Empty;
            try
            {
                using (ShipmentsSoapClient csaClient = new ShipmentsSoapClient())
                {
                    results = csaClient.ShipmentListLast30DaysByCustomer(customerNumber);
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }

            return results;
        }

       
    }
}
