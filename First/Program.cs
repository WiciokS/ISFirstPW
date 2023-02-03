using System;
using System.Text;

namespace VigenereCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Enter the text to be encrypted: ");
            string inputText = Console.ReadLine();
            Console.WriteLine("Enter the key: ");
            string key = Console.ReadLine();

            string encryptedText = Encrypt(inputText, key);
            Console.WriteLine("Encrypted text: " + encryptedText);

            string decryptedText = Decrypt(encryptedText, key);
            Console.WriteLine("Decrypted text: " + decryptedText);

            Console.ReadLine();
        }

        static string Encrypt(string inputText, string key)
        {
            // Convert input text and key to ASCII codes
            byte[] inputTextAscii = Encoding.ASCII.GetBytes(inputText);
            byte[] keyAscii = Encoding.ASCII.GetBytes(key);

            int check = 0;
            // Vinegre Cipher Method
            for (int i = 0; i < inputTextAscii.Length; i++)
            {
                inputTextAscii[i] = (byte)(inputTextAscii[i] ^ keyAscii[check]);
                check = (check + 1) % keyAscii.Length;
            }

            // Convert the encrypted text back to a string and return it
            return Encoding.ASCII.GetString(inputTextAscii);
        }

        static string Decrypt(string encryptedText, string key)
        {
            // Perform the decryption by encrypting the encrypted text with the key again
            return Encrypt(encryptedText, key);
        }
    }
}