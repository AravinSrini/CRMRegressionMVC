using CRM.UITest.Helper.DataModels;
using System.Collections.Generic;

namespace CRM.UITest.Helper.Interfaces
{
    public interface IGetStationCarrierDefaultAccessorials
    {
        List<DefaultAccessorialSetupModel> GetCarrierDefaultAccessorialsForStation(string stationID);
    }
}
