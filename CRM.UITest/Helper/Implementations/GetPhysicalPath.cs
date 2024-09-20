using System.Web;
using CRM.UITest.Helper.Interfaces;



namespace CRM.UITest.Helper.Implementations
{
    public class GetPhysicalPath : IGetPhysicalPath
    {
        public string GetPath(string relativePath)
        {
            string fullPath = string.Empty;

            // Get full physical path for given relative path
            fullPath = HttpContext.Current.Server.MapPath(relativePath);

            return fullPath;
        }
    }
}
