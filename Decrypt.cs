using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CryptoLibrary
{
    public partial class EncryptionLibrary : IEncryptionLibrary
    {
        public async Task<string> DecryptString()
        {
            try
            { 
                RijndaelManaged aesEncryption = new RijndaelManaged();
                aesEncryption.KeySize = _cryptoFactory._iKeySize;
                aesEncryption.BlockSize = 128;
                aesEncryption.Mode = CipherMode.CBC;
                aesEncryption.Padding = PaddingMode.PKCS7;
                aesEncryption.IV = Convert.FromBase64String(ASCIIEncoding.UTF8.GetString(Convert.FromBase64String(_cryptoFactory._strEncryptionKey)).Split(',')[0]);
                aesEncryption.Key = Convert.FromBase64String(ASCIIEncoding.UTF8.GetString(Convert.FromBase64String(_cryptoFactory._strEncryptionKey)).Split(',')[1]);
                ICryptoTransform decrypto = aesEncryption.CreateDecryptor();
                byte[] encryptedBytes = Convert.FromBase64CharArray(_cryptoFactory._strEncryptedText.ToCharArray(), 0, _cryptoFactory._strEncryptedText.Length);
                return ASCIIEncoding.UTF8.GetString(decrypto.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length));
            }
            catch(Exception ex)
            {
                EventLog.WriteEntry("Encryption error", "Stack Trace: "+ ex.StackTrace, EventLogEntryType.Error);
                throw;
            }
}
    }
}
