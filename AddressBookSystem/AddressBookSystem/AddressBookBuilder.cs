using AddressBookSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdressBookSystem
{
    public class AdressBookBuilder : IContacts
    {
        public List<Contact> contactList;

        
        public AdressBookBuilder()
        {
            this.contactList = new List<Contact>();
        }

        
        /// Adds the contact but contact is not be duplicated
       
        public void addContact(string firstName, string lastName, string address, string city, string state, string zip, string phoneNumber, string email)
        {
            bool duplicate = equals(firstName);
            if (!duplicate)
            {
                Contact contact = new Contact(firstName, lastName, address, city, state, zip, phoneNumber, email);
                contactList.Add(contact);
            }
            else
            {
                Console.WriteLine("Cannot add duplicate contacts when you give first name same");
            }
        }

        
        /// Equalses the specified first name for duplicate name.
       
        private bool equals(string firstName)
        {
            if (this.contactList.Any(e => e.firstName == firstName))
                return true;
            else
                return false;
        }

       
        /// Edits the contact with the help of first name of person
        
        public void editContact(string firstName)
        {
            int flag = 1;
            foreach (Contact contact in contactList)
            {
                if (firstName.Equals(contact.firstName))
                {
                    flag = 0;
                    Console.WriteLine("Enter last name = ");
                    contact.lastName = Console.ReadLine();
                    Console.WriteLine("Enter address= ");
                    contact.address = Console.ReadLine();
                    Console.WriteLine("Enter city= ");
                    contact.city = Console.ReadLine();
                    Console.WriteLine("Enter state= ");
                    contact.state = Console.ReadLine();
                    Console.WriteLine("Enter zip= ");
                    contact.zip = Console.ReadLine();
                    Console.WriteLine("Enter phoneNumber= ");
                    contact.phoneNumber = Console.ReadLine();
                    Console.WriteLine("Enter email= ");
                    contact.email = Console.ReadLine();
                    break;
                }
            }
            if (flag == 1)
            {
                Console.WriteLine("Contact not found");
            }
        }

        public void deleteContact(string firstName)
        {
            int flag = 1;
            foreach (Contact contact in contactList)
            {
                if (firstName.Equals(contact.firstName))
                {
                    flag = 0;
                    contactList.Remove(contact);
                    Console.WriteLine("Sucessfully deleted");
                    break;
                }
            }
            if (flag == 1)
            {
                Console.WriteLine("Contact not found");
            }
        }

       
        public void displayContact()
        {
            foreach (Contact contact in contactList)
            {
                Console.WriteLine("\nFirst name = " + contact.firstName);
                Console.WriteLine("Last name = " + contact.lastName);
                Console.WriteLine("Address = " + contact.address);
                Console.WriteLine("city = " + contact.city);
                Console.WriteLine("state = " + contact.state);
                Console.WriteLine("zip = " + contact.zip);
                Console.WriteLine("phoneNumber = " + contact.phoneNumber);
                Console.WriteLine("email = " + contact.email);
            }
        }

    
        // Find  the persons by place ie state or city.
       
        // <returns>person information</returns>
        public List<string> findPersons(string place)
        {
            List<string> personFounded = new List<string>();
            foreach (Contact contacts in contactList.FindAll(e => (e.city.Equals(place))).ToList())
            {
                string name = contacts.firstName + " " + contacts.lastName;
                personFounded.Add(name);
            }
            if (personFounded.Count == 0)
            {
                foreach (Contact contacts in contactList.FindAll(e => (e.state.Equals(place))).ToList())
                {
                    string name = contacts.firstName + " " + contacts.lastName;
                    personFounded.Add(name);
                }
            }
            return personFounded;
        }

        
        
        public void sortByFirstName()
        {
            List<string> sortList = new List<string>();
            foreach (Contact contacts in contactList)
            {
                string sort = contacts.ToString();
                sortList.Add(sort);
            }
            sortList.Sort();
            foreach (string sort in sortList)
            {
                Console.WriteLine(sort);
            }
        }

       
        public void sortByCity()
        {
            contactList.Sort(new Comparison<Contact>((a, b) => string.Compare(a.city, b.city)));
            Console.WriteLine("Contacts after sorting By City = ");
            foreach (Contact contact in contactList)
            {
                Console.WriteLine("\n FirstName = " + contact.firstName + "\n Last Name = " + contact.lastName + "\n Address = " + contact.address + "\n City = " + contact.city + "\n State = " + contact.state + "\n Zip = " + contact.zip + "\n Phone Number = " + contact.phoneNumber + "\n Email = " + contact.email);
            }
        }

       
        public void sortByState()
        {
            contactList.Sort(new Comparison<Contact>((a, b) => string.Compare(a.state, b.state)));
            Console.WriteLine("Contacts after sorting By State = ");
            foreach (Contact contact in contactList)
            {
                Console.WriteLine("\n FirstName = " + contact.firstName + "\n Last Name = " + contact.lastName + "\n Address = " + contact.address + "\n City = " + contact.city + "\n State = " + contact.state + "\n Zip = " + contact.zip + "\n Phone Number = " + contact.phoneNumber + "\n Email = " + contact.email);
            }
        }

        
        public void sortByZip()
        {
            contactList.Sort(new Comparison<Contact>((a, b) => string.Compare(a.zip, b.zip)));
            Console.WriteLine("Contacts after sorting By Zip = ");
            foreach (Contact contact in contactList)
            {
                Console.WriteLine("\n FirstName = " + contact.firstName + "\n Last Name = " + contact.lastName + "\n Address = " + contact.address + "\n City = " + contact.city + "\n State = " + contact.state + "\n Zip = " + contact.zip + "\n Phone Number = " + contact.phoneNumber + "\n Email = " + contact.email);
            }
        }

        public void writeInTxtFile()
        {
            FileReadWrite.writeInTxtFile(contactList);
        }

        /// <summary>
        /// Reads from text file.
        /// </summary>
        public void readFromTxtFile()
        {
            FileReadWrite.readFromTxtFile();
        }
        
        public void writeInCSVFile()
        {
            FileReadWrite.writeIntoCsvFile(contactList);
        }

        
        public void readFromCSVFile()
        {
            FileReadWrite.readFromCSVFile();
        }

        public void writeInJSONFile()
        {
            FileReadWrite.writeIntoJSONFile(contactList);
        }

       
        public void readFromJSONFile()
        {
            FileReadWrite.readFromJSONFile();
        }
    }
}