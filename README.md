# AES256 Encryption
Use this method to encrypt plain text to AES encrypted string with the appropraiate key size. 
Based on the key size the length of the string would vary. It considers the concatenation of key and IV comma separated and 
encrypted to base64.
Task<string> EncryptString();
  
Use this method to decrypt AES encrypted text to plain string with the appropraiate key size. 
Based on the key size and key the decryption will be carried out. It considers the concatenation of key and IV comma separated and 
encrypted to base64.
Task<string> DecryptString();
  
Based on the key size appropriate Key and IV is generated and a base 64 string is returned. 
The string is concatenation of IV and the Key. Pass the entire string as is to the encrypt and decrypt method. 
Use the IV and Key returned in external applications with appropriate Cryptography library for AES 256 encryption.
string GenerateKey(int keySize, out string strIV, out string strKey);

var key = GenerateKey(iKeySize, out strIV, out strKey);
CryptoFactory crypto = new CryptoFactory(128, data, "", key);
var obj = crypto.CreateCryptoObject(crypto);
var enc = await obj.EncryptString();
         
crypto = new CryptoFactory(128, "", encryptedTxt, key);
obj = crypto.CreateCryptoObject(crypto);
enc = await obj.DecryptString();
