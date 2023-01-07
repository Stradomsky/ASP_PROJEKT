using PhoneBookApp.Data.Entities;
using PhoneBookApp.Data.Repositories;
using System;
using System.Collections.Generic;

namespace PhoneBookApp.Logic.Services.PhoneBooks
{
    public class PhoneBookService : IPhoneBookService
    {
        private readonly IRepository<PhoneBook> _phoneBookRepository;

        public PhoneBookService(IRepository<PhoneBook> phoneBookRepository)
        {
            _phoneBookRepository = phoneBookRepository;
        }

        public List<PhoneBook> GetAllPhoneBooks()
        {
            List<PhoneBook> phoneBooks = _phoneBookRepository.GetAll();

            return phoneBooks;
        }

        public void CreatePhoneBook()
        {
            throw new NotImplementedException();
        }

        //private readonly List<PhoneBook> _phoneBooks = new List<PhoneBook>
        //{
        //    new PhoneBook
        //    {
        //        Name = "Kontakty z roboty",
        //        Contacts = new List<Contact>
        //        {
        //            new Contact { Name = "Adam", PhoneNumber = "111 222 333" },
        //            new Contact { Name = "Alicja", PhoneNumber = "69 69 69 69 69" }
        //        }
        //    }
        //};
    }
}
