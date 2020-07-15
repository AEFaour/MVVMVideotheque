using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppVideo.AccesHelper
{
    class WindowsAccesHelper
    {
        // Appler un bibliotheque windows qui teste si le compte est bon ou pas

        [STAThread]
        [System.Runtime.InteropServices.DllImport("advapi32.dll")]
        public static extern bool LogonUser(string userName, string domainName, string password,
            int LogonType, int LogonProvider, ref IntPtr phToken);
        public static bool IsValidateCredentials(string userName, string password, string domain)
        {
            IntPtr tokenHandler = IntPtr.Zero;
            bool isValid = LogonUser(userName, domain, password, 2, 0, ref tokenHandler);
            return isValid;
        }
    }
}
