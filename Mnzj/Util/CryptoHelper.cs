using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace Mnzj.Util
{
    public class CryptoHelper
    {
        public static string GetMD5Hash(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToUpper();
            }
            return string.Empty;
        }
    }
}