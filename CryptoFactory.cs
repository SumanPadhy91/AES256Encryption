using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoLibrary
{
    public class CryptoFactory
    {
        public readonly string _strPlainText;
        public readonly string _strEncryptedText;
        public readonly string _strEncryptionKey;
        public readonly int _iKeySize;

        public CryptoFactory(int iKeySize, string strPlainText, string strEncryptedText, string strEncryptionKey)
        {
            _strPlainText = strPlainText;
            _strEncryptedText = strEncryptedText;
            _strEncryptionKey = strEncryptionKey;
            _iKeySize = iKeySize;
        }
        public IEncryptionLibrary CreateCryptoObject(CryptoFactory cryptoFactory)
        {
            return new EncryptionLibrary(cryptoFactory);
        }
    }
}
