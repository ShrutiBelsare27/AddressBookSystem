﻿
using System;
using System.Collections.Generic;
using System.IO;
using AdressBookSystem;
using Newtonsoft.Json;

namespace AddressBookSystem
{
   public class FileReadWrite
    {
        public static string textFilePath = @"E:\.net\Day9Assg\AddressBookSystem\AddressBookSystem\Contact.txt";
        public static string csvFilePath = @"E:\.net\Day9Assg\AddressBookSystem\AddressBookSystem\Contact.csv";
        public static string jsonFilePath = @"E:\.net\Day9Assg\AddressBookSystem\AddressBookSystem\Contact.json";



        public static void writeInTxtFile(List<Contact> contacts)
        {
            if (File.Exists(textFilePath))
            {
                using (StreamWriter streamWriter = File.AppendText(textFilePath))
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

        
        public static void readFromTxtFile()
        {
            if (File.Exists(textFilePath))
            {
                using (StreamReader streamReader = File.OpenText(textFilePath))
                {
                    string data = "";
                    while ((data = streamReader.ReadLine()) != null)
                    {
                        Console.WriteLine("\n" + data);
                    }
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("No File Beacuse Of Wrong Path Or File Name");
            }
        }

       
        public static void writeIntoCsvFile(List<Contact> contacts)
        {
            if (File.Exists(csvFilePath))
            {
                using (StreamWriter streamWriter = File.AppendText(csvFilePath))
                {
                    foreach (Contact contact in contacts)
                    {
                        streamWriter.WriteLine(contact.firstName + "," + contact.lastName + "," + contact.address + "," + contact.city + "," + contact.state + "," + contact.zip + "," + contact.phoneNumber + "," + contact.email);
                    }
                    streamWriter.Close();
                }
                Console.WriteLine("SucessFully write into CSV file");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("No File Beacuse Of Wrong Path Or File Name");
            }
        }

        
        public static void readFromCSVFile()
        {
            string[] csvData = File.ReadAllLines(csvFilePath);
            foreach (string data in csvData)
            {
                string[] csv = data.Split(",");
                foreach (string dataCsv in csv)
                {
                    Console.Write("\n" + dataCsv);
                }
            }
        }

        public static void writeIntoJSONFile(List<Contact> contacts)
        {
            if (File.Exists(jsonFilePath))
            {
                JsonSerializer jsonSerializer = new JsonSerializer();
                using (StreamWriter streamWriter = new StreamWriter(jsonFilePath))
                using (JsonWriter writer = new JsonTextWriter(streamWriter))
                {
                    jsonSerializer.Serialize(writer, contacts);
                }
                Console.WriteLine("SucessFully write into JSON file");
            }
            else
            {
                Console.WriteLine("No File Beacuse Of Wrong Path Or File Name");
            }
        }

       
        public static void readFromJSONFile()
        {
            if (File.Exists(jsonFilePath))
            {
                List<Contact> contacts = JsonConvert.DeserializeObject<List<Contact>>(File.ReadAllText(jsonFilePath));
                foreach (Contact contact in contacts)
                {
                    Console.Write("\n" + contact.firstName);
                    Console.Write("\n" + contact.lastName);
                    Console.Write("\n" + contact.address);
                    Console.Write("\n" + contact.city);
                    Console.Write("\n" + contact.state);
                    Console.Write("\n" + contact.zip);
                    Console.Write("\n" + contact.phoneNumber);
                    Console.Write("\n" + contact.email);
                }
            }
            else
            {
                Console.WriteLine("No File Beacuse Of Wrong Path Or File Name");
            }
        }


    }
}
