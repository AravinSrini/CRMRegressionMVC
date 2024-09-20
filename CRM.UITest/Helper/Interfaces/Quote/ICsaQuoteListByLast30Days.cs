using CRM.UITest.CsaServiceReference;

namespace CRM.UITest.Helper.Interfaces.Quote
{
    public interface ICsaQuoteListByLast30Days
    {
        ShipmentListReponse GetCsaQuoteListByLast30Days(int customerNumber, out string errorMessage);
    }
}
