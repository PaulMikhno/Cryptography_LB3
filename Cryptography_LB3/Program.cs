using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace Cryptography_LB3
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                bool isExit = false;

                Console.WriteLine("Please select an action:");
                Console.WriteLine("1) Encrypt using TripleDES;\n2) Encrypt using RSACng;\n3) Create DSA Sign;\n4) Get SHA384Managed Hash;\n5) Decrypt TripleDES file using key file\n6) Exit");
                var selected = Console.ReadLine();
                int action;
                var isValid = int.TryParse(selected, out action);

                if (!isValid)
                {
                    Console.WriteLine("Ivalid input!");
                }

                switch ((Actions)action)
                {
                    case Actions.EncryptTripleDES:
                        Console.WriteLine("===============================================================================");
                        Console.WriteLine("Please enter value that will be encrypted:");
                        var value = Console.ReadLine();
                        TripleDesService.EncryptTripleDES(value);
                        Console.WriteLine("===============================================================================\n");
                        break;
                    case Actions.DecryptTripleDES:
                        ProcessDecryptTripleDESAction();
                        break;
                    case Actions.Exit:
                        isExit = true;
                        break;
                    default:
                        Console.WriteLine("Ivalid input!");
                        break;
                }

                if (isExit)
                {
                    break;
                }
                continue;
            }
        }

        public static void ProcessDecryptTripleDESAction()
        {
            Console.WriteLine("===============================================================================");
            Console.WriteLine("Please enter path to encrypted file:");
            byte[] encriptedFileBytes;
            while (true)
            {
                var encryptedPath = Console.ReadLine();
                if (!File.Exists(encryptedPath))
                {
                    Console.WriteLine("Invalid file path! try again");
                    continue;
                }
                encriptedFileBytes = File.ReadAllBytes(encryptedPath);
                break;
            }
            Console.WriteLine("Please enter path to key file:");
            byte[] keyFileBytes;
            while (true)
            {
                var keyFilePath = Console.ReadLine();
                if (!File.Exists(keyFilePath))
                {
                    Console.WriteLine("Invalid file path! try again");
                    continue;
                }
                keyFileBytes = File.ReadAllBytes(keyFilePath);
                break;
            }
            Console.WriteLine("Please enter path to initialization vector file:");
            byte[] vectorFileBytes;
            while (true)
            {
                var vectorFilePath = Console.ReadLine();
                if (!File.Exists(vectorFilePath))
                {
                    Console.WriteLine("Invalid file path! try again");
                    continue;
                }
                vectorFileBytes = File.ReadAllBytes(vectorFilePath);
                break;
            }

            TripleDesService.DecryptTripleDES(encriptedFileBytes, keyFileBytes, vectorFileBytes);
            Console.WriteLine("===============================================================================\n");
        }
    }
}
