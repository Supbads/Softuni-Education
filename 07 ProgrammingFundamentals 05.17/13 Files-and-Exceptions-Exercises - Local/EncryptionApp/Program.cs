using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace EncryptionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string direcotry = @"fileToEncrypt.txt";
            string outputFile = @"EncryptedFile";

            Console.WriteLine("Select 1 to Encrypt, 2 to Decrypt or 3 to Exit");
            var input = Console.ReadLine();

            while (true)
            {
                bool successfullSelection = true;
                

                try
                {
                    
                    if (input != "1" && input != "2" && input != "3")
                    {
                        throw new ArgumentException();
                    }

                    if (input == "1")
                    {
                        EncryptFile(direcotry, outputFile);
                        
                    }
                    else if (input == "2")
                    {
                        Console.WriteLine("Please enter the password.");
                        string password = Console.ReadLine();

                        DecryptFile(direcotry, outputFile, password);
                    }
                    else
                    {
                        Environment.Exit(0);
                    }
                }
                catch (Exception e)
                {
                    successfullSelection = false;
                    Console.WriteLine("Please select option 1, 2 or 3. 1 - Encrypt. 2 - Decrypt. 3 - Exit");
                }
                
                if(successfullSelection)
                Console.WriteLine("Select 1 to Encrypt 2 to Decrypt and 3 to Exit");

                input = Console.ReadLine();
            }
        }

        static void EncryptFile(string inputFile, string outputFile)
        {
            try
            {
                string password = @"myPassword"; // Your Key Here
                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(password);

                string cryptFile = outputFile;
                using (FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create))
                {
                    RijndaelManaged RMCrypto = new RijndaelManaged();

                    using (CryptoStream cs =
                        new CryptoStream(fsCrypt, RMCrypto.CreateEncryptor(key, key), CryptoStreamMode.Write))
                    {
                        using (FileStream fsIn = new FileStream(inputFile, FileMode.Open))
                        {
                            int data;
                            while ((data = fsIn.ReadByte()) != -1)
                            {
                                cs.WriteByte((byte)data);
                            }

                        }

                    }
                }
              
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        ///<summary>
        /// Steve Lydford - 12/05/2008.
        ///
        /// Decrypts a file using Rijndael algorithm.
        ///</summary>
        ///<param name="inputFile"></param>
        ///<param name="outputFile"></param>
        static void DecryptFile(string inputFile, string outputFile, string password)
        {
            //string password = ""; // Your Key Here

            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] key = UE.GetBytes(password);

            using (FileStream fsCrypt = new FileStream(inputFile, FileMode.Open))
            {
                RijndaelManaged RMCrypto = new RijndaelManaged();

                using (CryptoStream cs = new CryptoStream(fsCrypt,
                    RMCrypto.CreateDecryptor(key, key),
                    CryptoStreamMode.Read))
                {
                    using (FileStream fsOut = new FileStream(outputFile, FileMode.Create))
                    {
                        int data;
                        while ((data = cs.ReadByte()) != -1)
                        {
                            fsOut.WriteByte((byte)data);
                        }
                    }
                }
            }
        }
    }
    
    public class EncryptionHelper
    {
        static SymmetricAlgorithm encryption;
        static string password = "My Password";
        static string salt = "this is my salt. There are many like it, but this one is mine.";

        static EncryptionHelper()
        {
            encryption = new RijndaelManaged();
            Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(password, Encoding.ASCII.GetBytes(salt));

            encryption.Key = key.GetBytes(encryption.KeySize / 8);
            encryption.IV = key.GetBytes(encryption.BlockSize / 8);
            encryption.Padding = PaddingMode.PKCS7;
        }

        public void Encrypt(Stream inStream, Stream OutStream)
        {
            ICryptoTransform encryptor = encryption.CreateEncryptor();
            inStream.Position = 0;
            CryptoStream encryptStream = new CryptoStream(OutStream, encryptor, CryptoStreamMode.Write);
            inStream.CopyTo(encryptStream);
            encryptStream.FlushFinalBlock();
        }


        public void Decrypt(Stream inStream, Stream OutStream)
        {
            ICryptoTransform encryptor = encryption.CreateDecryptor();
            inStream.Position = 0;
            CryptoStream encryptStream = new CryptoStream(inStream, encryptor, CryptoStreamMode.Read);
            encryptStream.CopyTo(OutStream);
            OutStream.Position = 0;
        }
    }
}
