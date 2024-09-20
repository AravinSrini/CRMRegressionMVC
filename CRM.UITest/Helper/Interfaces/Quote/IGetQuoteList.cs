using System.Collections.Generic;
using CRM.UITest.Helper.ViewModel.RateModel;

namespace CRM.UITest.Helper.Interfaces.Quote
{
    public interface IGetQuoteList
    {
        List<QuoteListExtractModel> GetMgQuotes(string customerName, out string errorMessage);
    }
}
