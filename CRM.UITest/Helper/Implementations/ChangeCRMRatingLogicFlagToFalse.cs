using CRM.UITest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper
{
    public class ChangeCRMRatingLogicFlagToFalse : IChangeCRMRatingLogicFlagToFalse
    {
        public void ChangeCRMRatingLogicFlagFromTrueToFalse(string customerName)
        {
            DBHelper.ChangeCRMRatingLogicToFalse(customerName);
        }
    }
}
