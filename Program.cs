using System.Security.Cryptography;
using System.Text;
using System.IO;
using System;

namespace FileHashing
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("==================================================");
            Console.WriteLine("0: To hash a string");
            Console.WriteLine("1: To hash a file");

            string ?choice = Console.ReadLine();
            Console.WriteLine();
            switch(choice)
            {
                case "0":
                    MakeStringHash();
                    break;
                
                case "1":
                    MakeFileHash();
                    break;
                
                default:
                break;
            }
        }

        static void MakeStringHash()
        {
            string ?originalHash;
            string ?rarString;
            string stringHash;

            //get preferred hash
            Console.Write("Enter original hash: ");
            originalHash = Console.ReadLine();

            //get string
            Console.Write("Enter string to get hashed: ");
            rarString = Console.ReadLine();
            Console.WriteLine();

            //get hash
            stringHash = GenHash(rarString, false);

            Console.WriteLine("===================== SHA256 =====================");
            Console.WriteLine("Files hash:    " + stringHash);
            Console.WriteLine("original hash: " + originalHash);

            if(string.Equals(stringHash, originalHash, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("The hashes matches 🥳");
            }
            else if(originalHash == "")
            {
                Console.WriteLine("No original hash provided 😐");
            }
            else
            {
                Console.WriteLine("The hashes don't match 😰");
            }

        }

        static void MakeFileHash()
        {
            string ?originalHash;
            string ?filePath;
            string ?fileHash;

            //get preferred hash
            Console.Write("Enter original hash: ");
            originalHash = Console.ReadLine();

            //get file path
            Console.Write("Enter file path: ");
            filePath = Console.ReadLine();
            Console.WriteLine();

            //get hash
            fileHash = GenHash(filePath, true);
                            
            Console.WriteLine("===================== SHA256 =====================");
            Console.WriteLine("Files hash:    " + fileHash);
            Console.WriteLine("original hash: " + originalHash);

            if(string.Equals(fileHash, originalHash, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("The hashes matches 🥳");
            }
            else if(originalHash == "")
            {
                Console.WriteLine("No original hash provided 😐");
            }
            else
            {
                Console.WriteLine("The hashes don't match 😰");
            }
        }

        //calculate hash (0 = string; 1 = file) 
        public static string GenHash(string rarData, bool type)
        {
            SHA256 hashSvc = SHA256.Create();
            byte[] hashPros;

            switch(type)
            {
                case false:
                    hashPros = hashSvc.ComputeHash(Encoding.UTF8.GetBytes(rarData));
                    break;

                case true:
                    hashPros = hashSvc.ComputeHash(System.IO.File.ReadAllBytes(rarData));
                    break;
            }

            return BitConverter.ToString(hashPros).Replace("-", ""); 
        }
    }
}