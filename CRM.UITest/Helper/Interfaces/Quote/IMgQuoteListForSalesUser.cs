using System.Collections.Generic;
using CRM.UITest.Helper.ViewModel.RateModel;

namespace CRM.UITest.Helper.Interfaces.Quote
{
    public interface IMgQuoteListForSalesUser
    {
        List<QuoteListExtractModel> GetMgQuoteList(string customers,bool isSalesUser);
    }
}
