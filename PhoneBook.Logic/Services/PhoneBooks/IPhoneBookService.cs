using PhoneBookApp.Data.Entities;
using System.Collections.Generic;

namespace PhoneBookApp.Logic.Services.PhoneBooks
{
    public interface IPhoneBookService
    {
        List<PhoneBook> GetAllPhoneBooks();

        void CreatePhoneBook();
    }
}
