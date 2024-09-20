using CRM.UITest.CsaServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.Interfaces.Shipment
{
     public interface ICsaShipmentListByLast30Days
    {
        ShipmentListReponse GetCsaShipmentListByLast30Days(int customerNumber, out string errorMessage);
    }
}
