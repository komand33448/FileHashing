using System.Security.Cryptography;
using System.Text﻿using System.Security.Cryptography;
using System.Text;
using System.IO;
using System;

namespace FileHashing
{
    class Program
    {
        static void Main()
        {
            string ?filePath;
            string ?fileHash;
            string ?originalHash;

            //get preferred hash
            Console.Write("Enter original hash: ");
            originalHash = Console.ReadLine();

            //get file path
            Console.Write("Enter file path: ");
            filePath = Console.ReadLine();
            Console.WriteLine();

            fileHash = GenHash(filePath);

            Console.WriteLine("==================================================");
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

        //calculate hash
        public static string GenHash(string theFilePath)
        {
            SHA256 hashSvc = SHA256.Create();

            byte[] hashPros = hashSvc.ComputeHash(System.IO.File.ReadAllBytes(theFilePath));

            return BitConverter.ToString(hashPros).Replace("-", ""); 
        }
    }
}
using System.IO;
using System;

namespace FileHashing
{
    class Program
    {
        static void Main()
        {
            string ?filePath;
            string ?fileHash;
            string ?originalHash;

            //get preferred hash
            Console.Write("Enter original hash: ");
            originalHash = Console.ReadLine();

            //get file path
            Console.Write("Enter file path: ");
            filePath = Console.ReadLine();
            Console.WriteLine();

            fileHash = GenHash(filePath);

            Console.WriteLine("==================================================");
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

        //calculate hash
        public static string GenHash(string theFilePath)
        {
            SHA256 hashSvc = SHA256.Create();

            byte[] hashPros = hashSvc.ComputeHash(System.IO.File.ReadAllBytes(theFilePath));

            return BitConverter.ToString(hashPros).Replace("-", ""); 
        }
    }
}
