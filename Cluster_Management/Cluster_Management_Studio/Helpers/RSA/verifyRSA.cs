using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Helpers.RSA
{
    internal class verifyRSA
    {
        #region Private Globale Variables
        private string pub_key_path_Receiver = ""; // Path to the Public Key (to Verify)
        private string priv_key_path_Receiver = ""; // Path to the Private Key (to Decrypt)
        private string pub_key_path_Sender = ""; // Path to the Public Key (to Sign)
        private string priv_key_path_Sender = ""; // Path to the Private Key (to Encrypt)
        private RSACryptoServiceProvider key;
        #endregion

        internal List<Tuple<string, string>> GetMessage(string token, string verifyMessage)
        {
            if (!loadRSA(priv_key_path_Receiver))
                return new List<Tuple<string, string>>();

            byte[] Bytes = Encoding.Unicode.GetBytes(token);
            byte[] Bytes2 = key.Decrypt(Bytes, false);

            string plainMessage = Encoding.ASCII.GetString(Bytes2);

            if (!loadRSA(pub_key_path_Receiver))
                return new List<Tuple<string, string>>();

            Bytes = Convert.FromBase64String(plainMessage);
            Bytes2 = Encoding.Unicode.GetBytes(verifyMessage);
            if (!verifyData(Bytes2, Bytes, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1))
                return new List<Tuple<string, string>>();

            return SplitMessage(plainMessage);
        }

        #region Private Functions

        private bool verifyData(byte[] clear, byte[] hashed, HashAlgorithmName algoname, RSASignaturePadding sigpadding)
        {
            try
            {
                return key.VerifyData(clear, hashed, algoname, sigpadding);
            }
            catch
            {
                return false;
            }
        }

        private bool loadRSA(string path)
        {
            string mykey = "";
            try
            {
                using (StreamReader sr = new StreamReader(path))
                    mykey = sr.ReadToEnd();

                key = new RSACryptoServiceProvider();
                key.FromXmlString(mykey);

                return true;
            }
            catch
            {
                return false;
            }
        }

        private List<Tuple<string, string>> SplitMessage(string message)
        {
            List<Tuple<string, string>> returning = new List<Tuple<string, string>>();

            foreach (string item in message.Split(";;;"))
            {
                string[] item_splitted = item.Split("---");
                if (item_splitted.Length == 2)
                    returning.Add(new Tuple<string, string>(item_splitted[0], item_splitted[1]));
            }

            return returning;
        }

        #endregion
    }
}
