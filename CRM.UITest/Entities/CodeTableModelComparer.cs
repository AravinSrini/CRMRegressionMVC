using System.Collections.Generic;

namespace CRM.UITest.Entities
{
    public class CodeTableModelComparer : IEqualityComparer<CodeTableViewModel>
    {
        public bool Equals(CodeTableViewModel x, CodeTableViewModel y)
        {
            return (x.Name.ToLower().Equals(y.Name.ToLower()));
        }

        public int GetHashCode(CodeTableViewModel obj)
        {
            return 1;
        }
    }
}