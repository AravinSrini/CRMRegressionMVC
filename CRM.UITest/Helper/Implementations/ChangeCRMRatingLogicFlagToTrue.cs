using CRM.UITest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.Implementations
{
    public class ChangeCRMRatingLogicFlagToTrue : IChangeCRMRatingLogicFlagToTrue
    {
        public void ChangeCRMRatingLogicToTrue(string customerName)
        {
            DBHelper.ChangeCRMRatingLogicToTrue(customerName);
        }
    }
}
