using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Threading;

namespace EncryptionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileToEncrypt = @"UnencryptedFile.txt";
            string encryptedFile = @"EncryptedFile.txt";
            string decryptedFile = @"DecryptedFile.txt";

            TaskLoop(fileToEncrypt, encryptedFile, decryptedFile);
        }

        private static void TaskLoop(string fileToEncrypt, string encryptedFile, string decryptedFile)
        {
            Console.WriteLine("Select 1 to Encrypt, 2 to Decrypt or 3 to Exit.");
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
                        Console.WriteLine("Input a password for the encryption.");
                        System.Console.Write("password: ");
                        string password = null;
                        while (true)
                        {
                            var key = System.Console.ReadKey(true);
                            if (key.Key == ConsoleKey.Enter)
                                break;
                            password += key.KeyChar;
                        }
                        EncryptFile(password, fileToEncrypt, encryptedFile);
                    }
                    else if (input == "2")
                    {
                        Console.WriteLine("Please enter the password.");
                        System.Console.Write("password: ");
                        string password = null;
                        while (true)
                        {
                            var key = System.Console.ReadKey(true);
                            if (key.Key == ConsoleKey.Enter)
                                break;
                            password += key.KeyChar;
                        }

                        DecryptFile(password, encryptedFile, decryptedFile);

                        Process.Start(decryptedFile);

                        Thread.Sleep(200);

                        File.Delete(decryptedFile);
                    }
                    else
                    {
                        Environment.Exit(0);
                    }
                }
                catch (Exception e)
                {
                    successfullSelection = false;
                    Console.WriteLine("Please select option 1, 2 or 3. 1 - Encrypt. 2 - Decrypt. 3 - Exit.");
                }

                if (successfullSelection)
                    Console.WriteLine("Select 1 to Encrypt 2 to Decrypt and 3 to Exit.");

                input = Console.ReadLine();
            }
        }

        public static void EncryptFile(string password,
            string in_file, string out_file)
        {
            CryptFile(password, in_file, out_file, true);
        }

        public static void DecryptFile(string password,
            string in_file, string out_file)
        {
            CryptFile(password, in_file, out_file, false);
        }

        public static void CryptFile(string password,
            string in_file, string out_file, bool encrypt)
        {
            // Create input and output file streams.
            using (FileStream in_stream =
                new FileStream(in_file, FileMode.Open, FileAccess.Read))
            {
                using (FileStream out_stream =
                    new FileStream(out_file, FileMode.Create,
                        FileAccess.Write))
                {
                    // Encrypt/decrypt the input stream into
                    // the output stream.
                    CryptStream(password, in_stream, out_stream, encrypt);
                }
            }
        }

        // Encrypt the data in the input stream into the output stream.
        public static void CryptStream(string password,
            Stream in_stream, Stream out_stream, bool encrypt)
        {
            // Make an AES service provider.
            AesCryptoServiceProvider aes_provider =
                new AesCryptoServiceProvider();

            // Find a valid key size for this provider.
            int key_size_bits = 0;
            for (int i = 1024; i > 1; i--)
            {
                if (aes_provider.ValidKeySize(i))
                {
                    key_size_bits = i;
                    break;
                }
            }
            Debug.Assert(key_size_bits > 0);
            Console.WriteLine("Key size: " + key_size_bits);

            // Get the block size for this provider.
            int block_size_bits = aes_provider.BlockSize;

            // Generate the key and initialization vector.
            byte[] key = null;
            byte[] iv = null;
            byte[] salt = { 0x0, 0x0, 0x1, 0x2, 0x3, 0x4, 0x5, 0x6,
                0xF1, 0xF0, 0xEE, 0x21, 0x22, 0x45 };
            MakeKeyAndIV(password, salt, key_size_bits, block_size_bits, out key, out iv);

            // Make the encryptor or decryptor.
            ICryptoTransform crypto_transform;
            if (encrypt)
            {
                crypto_transform = aes_provider.CreateEncryptor(key, iv);
            }
            else
            {
                crypto_transform = aes_provider.CreateDecryptor(key, iv);
            }

            // Attach a crypto stream to the output stream.
            // Closing crypto_stream sometimes throws an
            // exception if the decryption didn't work
            // (e.g. if we use the wrong password).
            try
            {
                using (CryptoStream crypto_stream =
                    new CryptoStream(out_stream, crypto_transform,
                        CryptoStreamMode.Write))
                {
                    // Encrypt or decrypt the file.
                    const int block_size = 1024;
                    byte[] buffer = new byte[block_size];
                    int bytes_read;
                    while (true)
                    {
                        // Read some bytes.
                        bytes_read = in_stream.Read(buffer, 0, block_size);
                        if (bytes_read == 0) break;

                        // Write the bytes into the CryptoStream.
                        crypto_stream.Write(buffer, 0, bytes_read);
                    }
                } // using crypto_stream 
            }
            catch
            {
            }

            crypto_transform.Dispose();
        }

        // Use the password to generate key bytes.
        private static void MakeKeyAndIV(string password, byte[] salt,
            int key_size_bits, int block_size_bits,
            out byte[] key, out byte[] iv)
        {
            Rfc2898DeriveBytes derive_bytes =
                new Rfc2898DeriveBytes(password, salt, 1000);

            key = derive_bytes.GetBytes(key_size_bits / 8);
            iv = derive_bytes.GetBytes(block_size_bits / 8);
        }

    }
}
