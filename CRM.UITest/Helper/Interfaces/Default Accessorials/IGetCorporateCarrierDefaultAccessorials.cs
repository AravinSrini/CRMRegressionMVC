using CRM.UITest.Helper.DataModels;
using System.Collections.Generic;

namespace CRM.UITest.Helper.Interfaces.Default_Accessorials
{
    public interface IGetCorporateCarrierDefaultAccessorials
    {
        List<DefaultAccessorialSetupModel> GetCarrierDefaultAccessorialsForCorporate();
    }
}
