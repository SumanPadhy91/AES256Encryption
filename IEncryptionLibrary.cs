using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoLibrary
{
    public interface IEncryptionLibrary
    {
        /// <summary>
        /// Use this method to encrypt plain text to AES encrypted string with the appropraiate key size. 
        /// Based on the key size the length of the string would vary.
        /// </summary>
        /// <param name="iPlainStr"></param>
        /// <param name="strEncryptionKey"></param>
        /// <param name="iKeySize"></param>
        /// <returns></returns>
        Task<string> EncryptString();
        /// <summary>
        /// Use this method to decrypt AES encrypted text to plain string with the appropraiate key size. 
        /// Based on the key size and key the decryption will be carried out
        /// </summary>
        /// <param name="iEncryptedText"></param>
        /// <param name="strEncryptionKey"></param>
        /// <param name="iKeySize"></param>
        /// <returns></returns>
        Task<string> DecryptString();
        /// <summary>
        /// Based on the key size appropriate Key and IV is generated and a base 64 string is returned. 
        /// The string is concatenation of IV and the Key. Pass the entire string as is to the encrypt and decrypt method. 
        /// Use the IV and Key returned in external applications with appropriate Cryptography library for AES 256 encryption.
        /// </summary>
        /// <param name="iKeySize"></param>
        /// <returns></returns>
        string GenerateKey(int keySize, out string strIV, out string strKey);
    }
}
