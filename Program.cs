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
            Console.WriteLine("0: To hash a file");
            Console.WriteLine("1: To hash a string");

            string ?choice = Console.ReadLine();
            Console.WriteLine();
            switch(choice)
            {
                case "0":
                    MakeFileHash();
                    break;
                
                case "1":
                    MakeStringHash();
                    break;
                
                default:
                break;
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
            fileHash = GenFileHash(filePath);
                            
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
            stringHash = GenStringHash(rarString);

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

        //calculate hash
        public static string GenFileHash(string theFilePath)
        {
            SHA256 hashSvc = SHA256.Create();

            byte[] hashPros = hashSvc.ComputeHash(System.IO.File.ReadAllBytes(theFilePath));

            return BitConverter.ToString(hashPros).Replace("-", ""); 
        }
        
        public static string GenStringHash(string theRarString)
        {
            SHA256 hashSvc = SHA256.Create();

            byte[] hashPros = hashSvc.ComputeHash(Encoding.UTF8.GetBytes(theRarString));

            return BitConverter.ToString(hashPros).Replace("-", ""); 
        }
    }
}