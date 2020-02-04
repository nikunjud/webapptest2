using System;
using System.Collections.Generic;
using System.Data.SQLite;
namespace PhoneBookTestApp
{
    public class PhoneBook : IPhoneBook
    {
        /// <summary>
        /// Add Person In Phone Book
        /// </summary>
        /// <param name="person">Person To Be Added</param>
        public void AddPerson(Person person)
        {
            var dbConnection = DatabaseUtil.GetConnection();
            try
            {
                SQLiteCommand command =
                     new SQLiteCommand(
                        "INSERT INTO PHONEBOOK (NAME, PHONENUMBER, ADDRESS) VALUES(@personName,@personContact, @personAddress)",
                        dbConnection);
                command.Parameters.AddWithValue("@personName", person.name);
                command.Parameters.AddWithValue("@personContact", person.phoneNumber);
                command.Parameters.AddWithValue("@personAddress", person.address);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                dbConnection.Close();
            }
        }

        /// <summary>
        /// Find Person With Given Name In Phone Boook
        /// </summary>
        /// <param name="firstName">Person First Name</param>
        /// <param name="lastName">Person Last Name</param>
        /// <returns>Found Person Information</returns>
        public Person FindPerson(string firstName, string lastName)
        {
            Person person = new Person();
            if (!(string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName)))
            {
                var dbConnection = DatabaseUtil.GetConnection();
                try
                {
                    string personName = (firstName + " " + lastName).Trim();
                    SQLiteCommand command =
                         new SQLiteCommand(
                            "SELECT NAME, PHONENUMBER, ADDRESS FROM PHONEBOOK WHERE NAME LIKE @personName ORDER BY NAME ASC LIMIT 1", dbConnection);
                    command.Parameters.AddWithValue("@personName", "%" + personName + "%");
                    using (var oReader = command.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            person.name = oReader.GetString(0);
                            person.phoneNumber = oReader.GetString(1);
                            person.address = oReader.GetString(2);
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    dbConnection.Close();
                }
            }

            return person;
        }

        /// <summary>
        /// Get All Person Present In The Phone Boook
        /// </summary>
        /// <returns>List Of Persons</returns>
        public IList<Person> GetAllPersons()
        {
            var dbConnection = DatabaseUtil.GetConnection();
            IList<Person> personsList = new List<Person>();
            try
            {
                SQLiteCommand command =
                     new SQLiteCommand(
                        "SELECT NAME, PHONENUMBER, ADDRESS FROM PHONEBOOK ", dbConnection);
                using (var oReader = command.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        Person pp = new Person();
                        pp.name = oReader.GetString(0);
                        pp.phoneNumber = oReader.GetString(1);
                        pp.address = oReader.GetString(2);
                        personsList.Add(pp);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                dbConnection.Close();
            }

            return personsList;
        }
    }
}