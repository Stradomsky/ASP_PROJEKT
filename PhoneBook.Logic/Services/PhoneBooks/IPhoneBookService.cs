using PhoneBookApp.Data.Entities;
using PhoneBookApp.Logic.Models;
using System.Collections.Generic;

namespace PhoneBookApp.Logic.Services.PhoneBooks
{
    public interface IPhoneBookService
    {
        List<PhoneBook> GetAllPhoneBooks();

        PhoneBook GetPhoneBookById(int phoneBookId);

        void CreatePhoneBook(User user, PhoneBook phoneBook);

        void EditPhoneBook(PhoneBook phoneBook);

        void DeletePhoneBookById(int phoneBookId);

        void AddContact(NewContact newContact);

        void DeleteContactById(int phoneBookId, int contactId);
    }
}
