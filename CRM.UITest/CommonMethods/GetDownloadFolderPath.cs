using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CRM.UITest.CommonMethods
{
    public class GetDownloadPath
    {
        public string GetDownloadFolderPath(string FileName)
        {
            string pathUser = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders", "{374DE290-123F-4565-9164-39C4925E467B}", String.Empty).ToString();
            string downloadedFile = pathUser + FileName;
            return downloadedFile;
        }

    }
}
