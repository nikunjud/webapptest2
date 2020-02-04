using System.Collections.Generic;
namespace PhoneBookTestApp
{
    public interface IPhoneBook
    {
        /// <summary>
        /// Find Person With Given Name In Phone Boook
        /// </summary>
        /// <param name="firstName">Person First Name</param>
        /// <param name="lastName">Person Last Name</param>
        /// <returns>Found Person Information</returns>
        Person FindPerson(string firstName, string lastName);

        /// <summary>
        /// Add Person In Phone Book
        /// </summary>
        /// <param name="person">Person To Be Added</param>
        void AddPerson(Person newPerson);

        /// <summary>
        /// Get All Person Present In The Phone Boook
        /// </summary>
        /// <returns>List Of Persons</returns>
        IList<Person> GetAllPersons();
    }
}