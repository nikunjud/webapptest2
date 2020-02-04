using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookTestApp
{
    class Program
    {
        private PhoneBook phonebook = new PhoneBook();
        static void Main(string[] args)
        {
            try
            {
                DatabaseUtil.initializeDatabase();

                Program pg = new Program();

                // TODO: insert the new person objects into the database
                pg.AddNewPersons();

                // TODO: print the phone book out to System.out
                pg.GetAllPhonebookRecords();

                // TODO: find Cynthia Smith and print out just her entry
                pg.FindRecordWithGivenName("", "mi");

                Console.WriteLine("\nPress any key to exit.");
                Console.ReadKey();
            }
            finally
            {
                DatabaseUtil.CleanUp();
            }
        }

        /// <summary>
        /// Add new persons to database
        /// </summary>
        private void AddNewPersons()
        {
            /* TODO: create person objects and put them in the PhoneBook and database
                * John Smith, (248) 123-4567, 1234 Sand Hill Dr, Royal Oak, MI
                * Cynthia Smith, (824) 128-8758, 875 Main St, Ann Arbor, MI
                */
            phonebook.AddPerson(new Person { name = "Chris Johnson", phoneNumber = "(321) 231-7876", address = "452 Freeman Drive, Algonac, MI" });
            phonebook.AddPerson(new Person { name = "Dave Williams", phoneNumber = "(231) 502-1236", address = "285 Huron St, Port Austin, MI" });
            phonebook.AddPerson(new Person { name = "John Smith", phoneNumber = "(248) 123-4567", address = "1234 Sand Hill Dr, Royal Oak, MI" });
            phonebook.AddPerson(new Person { name = "Cynthia Smith", phoneNumber = "(824) 128-8758", address = "875 Main St, Ann Arbor, MI" });
        }

        /// <summary>
        /// Find Record With Given Name
        /// </summary>
        /// <param name="firstName">First Name Of Person</param>
        /// <param name="lastName">Last Name Of Person</param>
        private void FindRecordWithGivenName(string firstName, string lastName)
        {
            Person person= phonebook.FindPerson(firstName.Trim(), lastName.Trim());
            Console.WriteLine(Environment.NewLine);
            if (person != null && person.address != null) {
                Console.WriteLine("Found below Record");
                Console.WriteLine("Name = {0}, PhoneNumber = {1}, Address = {2}", person.name,
                    person.phoneNumber, person.address);
            }
            else
            {
                Console.WriteLine("No Matching Record Found");
            }
            
        }

        /// <summary>
        /// Show All Data Present In phonebok
        /// </summary>
        private void GetAllPhonebookRecords()
        {
            var personsList = phonebook.GetAllPersons();
            for (int index = 0; index < personsList.Count; index++)
            {
                Console.WriteLine("{0} ,Name = {1}, PhoneNumber = {2}, Address = {3}", index, personsList[index].name,
                    personsList[index].phoneNumber, personsList[index].address);
            }
        }

    }
}
