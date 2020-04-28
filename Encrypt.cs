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
        private readonly CryptoFactory _cryptoFactory;

        public EncryptionLibrary(CryptoFactory cryptoFactory)
        {
            _cryptoFactory = cryptoFactory;
        }
        public async Task<string> EncryptString()
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
                byte[] plainText = ASCIIEncoding.UTF8.GetBytes(_cryptoFactory._strPlainText);
                ICryptoTransform crypto = aesEncryption.CreateEncryptor();
                byte[] cipherText = crypto.TransformFinalBlock(plainText, 0, plainText.Length);
                return Convert.ToBase64String(cipherText);
            }
            catch(Exception ex)
            {
                EventLog.WriteEntry("Encryption error", "Stack Trace: "+ ex.StackTrace, EventLogEntryType.Error);
                throw;
            }
        }
    }
}
