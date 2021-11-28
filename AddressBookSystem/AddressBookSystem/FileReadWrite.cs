
using System;
using System.Collections.Generic;
using System.IO;
using AdressBookSystem;

namespace AddressBookSystem
{
   public class FileReadWrite
    {
        public static string path = @"E:\.net\Day9Assg\AddressBookSystem\AddressBookSystem\Contact.txt";

       
        public static  void writeFile(List<Contact> contacts)
        {
            if (File.Exists(path))
            {
                using (StreamWriter streamWriter = File.AppendText(path))
                {
                    foreach (Contact contact in contacts)
                    {
                        streamWriter.WriteLine(contact);
                    }
                    streamWriter.Close();
                }
                Console.WriteLine("SucessFully write into txt file");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("No File Beacuse Of Wrong Path Or File Name");
            }
        }

        /// <summary>
        /// Reads the file.
        /// </summary>
        public static void readFile()
        {
            if (File.Exists(path))
            {
                using (StreamReader streamReader = File.OpenText(path))
                {
                    string data = "";
                    while ((data = streamReader.ReadLine()) != null)
                    {
                        Console.WriteLine(data);
                    }
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("No File Beacuse Of Wrong Path Or File Name");
            }
        }
    }
}
