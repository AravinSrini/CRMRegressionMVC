using CRM.UITest.Helper.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.Interfaces
{
    public interface IGetCustomerInsuranceAllRiskByCustomerAccountId
    {
        InsAllRiskViewModel GetCustomerInsuranceAllRisk(int customerAccountId);
    }
}
