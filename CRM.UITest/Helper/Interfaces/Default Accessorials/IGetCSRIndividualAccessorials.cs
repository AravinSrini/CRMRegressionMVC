using CRM.UITest.Helper.DataModels;
using System.Collections.Generic;

namespace CRM.UITest.Helper.Interfaces.Default_Accessorials
{
    public interface IGetCSRIndividualAccessorials
    {
        List<DefaultAccessorialSetupModel> GetAccessorialsFromCsrStage(int accountID);
    }
}
