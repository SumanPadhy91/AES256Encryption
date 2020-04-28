using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CryptoLibrary
{
    public partial class EncryptionLibrary : IEncryptionLibrary
    {
        /// <summary>
        /// Based on the key size appropriate Key and IV is generated and a base 64 string is returned. 
        /// The string is concatenation of IV and the Key. Pass the entire string as is to the encrypt and decrypt method. 
        /// Use the IV and Key returned in external applications with appropriate Cryptography library for AES 256 encryption.
        /// </summary>
        /// <param name="iKeySize"></param>
        /// <returns></returns>
        public string GenerateKey(int iKeySize, out string strIV, out string strKey)
        {
            try
            {
                if ((iKeySize == 256) || (iKeySize == 128))
                {
                    RijndaelManaged aesEncryption = new RijndaelManaged();
                    aesEncryption.KeySize = iKeySize;
                    aesEncryption.BlockSize = 128;
                    aesEncryption.Mode = CipherMode.CBC;
                    aesEncryption.Padding = PaddingMode.PKCS7;
                    aesEncryption.GenerateIV();
                    strIV = Convert.ToBase64String(aesEncryption.IV);
                    aesEncryption.GenerateKey();
                    strKey = Convert.ToBase64String(aesEncryption.Key);
                    string completeKey = $"{strIV},{strKey}";

                    return Convert.ToBase64String(ASCIIEncoding.UTF8.GetBytes(completeKey));
                }
                else
                {
                    strIV = "";
                    strKey = "";
                    return "Invalid Key Size. allowed values are 128 or 256.";
                }
            }
            catch
            {
                strIV = "";
                strKey = "";
                return "Please contact author.";
            }            
        }
    }
}
