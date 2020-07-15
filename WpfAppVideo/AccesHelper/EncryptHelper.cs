using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppVideo.AccesHelper
{
    class EncryptHelper
    {
        // Pour le cryptage text clair en base64 
        public static string Base64Encode(string textClair)
        {
            // Convertir en byte
            var textClairByte = System.Text.Encoding.UTF8.GetBytes(textClair);
            return System.Convert.ToBase64String(textClairByte);
        }
        public static string Base64Decode(string codeEnBase64)
        {
            var textByte = System.Convert.FromBase64String(codeEnBase64);

            return System.Text.Encoding.UTF8.GetString(textByte);
        }

    }
}
