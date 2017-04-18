using System;
using System.Security.Cryptography;
using System.Text;

namespace CryptographyExample
{
    internal class AsymectricRsa
    {
        internal static void EncryptSomeText()
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(); string publicKeyXML = rsa.ToXmlString(false); string privateKeyXML = rsa.ToXmlString(true);
            Console.WriteLine(publicKeyXML);
            Console.WriteLine(privateKeyXML);

            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            byte[] dataToEncrypt = ByteConverter.GetBytes("My Secret Data!");
            byte[] encryptedData;
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                RSA.FromXmlString(publicKeyXML);
                encryptedData = RSA.Encrypt(dataToEncrypt, false);
            }
            byte[] decryptedData;
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                RSA.FromXmlString(privateKeyXML); decryptedData = RSA.Decrypt(encryptedData, false);
            }

            Console.WriteLine(ByteConverter.GetString(encryptedData));
            Console.WriteLine(ByteConverter.GetString(decryptedData));
        }
    }
}