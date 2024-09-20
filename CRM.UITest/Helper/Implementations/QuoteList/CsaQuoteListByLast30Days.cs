using System;
using CRM.UITest.Helper.Interfaces.Quote;
using CRM.UITest.CsaServiceReference;

namespace CRM.UITest.Helper.Implementations.QuoteList
{
    public class CsaQuoteListByLast30Days : ICsaQuoteListByLast30Days
    {
        public ShipmentListReponse GetCsaQuoteListByLast30Days(int customerNumber, out string errorMessage)
        {
            ShipmentListReponse results = null;
            errorMessage = string.Empty;

            try
            {
                using (ShipmentsSoapClient csaClient = new ShipmentsSoapClient())
                {
                    results = csaClient.QuoteListLast30DaysByCustomer(customerNumber);
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
