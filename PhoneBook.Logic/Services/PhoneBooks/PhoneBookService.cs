using PhoneBookApp.Data.Entities;
using PhoneBookApp.Data.Repositories;
using PhoneBookApp.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBookApp.Logic.Services.PhoneBooks
{
    public class PhoneBookService : IPhoneBookService
    {
        private readonly IRepository<PhoneBook> _phoneBookRepository;
        private readonly IRepository<Contact> _contactRepository;

        public PhoneBookService(IRepository<PhoneBook> phoneBookRepository, IRepository<Contact> contactRepository)
        {
            _phoneBookRepository = phoneBookRepository;
            _contactRepository = contactRepository;
        }

        public List<PhoneBook> GetAllPhoneBooks()
        {
            List<PhoneBook> phoneBooks = _phoneBookRepository.GetAll();

            return phoneBooks;
        }

        public PhoneBook GetPhoneBookById(int phoneBookId)
        {
            List<PhoneBook> phoneBooks = _phoneBookRepository.GetAll();

            PhoneBook phoneBook = phoneBooks.Single(pb => pb.Id == phoneBookId);

            return phoneBook;
        }

        public void CreatePhoneBook(User user, PhoneBook phoneBook)
        {
            // Walidacja danych (powtórzone nazwy itp)

            // Podczepić phonebooka pod zalogowanego użytkownika
            
            user.PhoneBooks.Add(phoneBook);

            _phoneBookRepository.SaveChanges();
        }

        public void EditPhoneBook(PhoneBook phoneBook)
        {
            //_phoneBookRepository.Sa
        }

        public void DeletePhoneBookById(int phoneBookId)
        {
            PhoneBook phoneBookToDelete = GetPhoneBookById(phoneBookId);

            _phoneBookRepository.Delete(phoneBookToDelete);
        }

        public void AddContact(NewContact newContact)
        {
            List<Contact> allContacts = _contactRepository.GetAll();

            if (allContacts.Any(c => c.Name == newContact.Name))
            {
                throw new Exception("There already is contact with this name.");
            }

            if (allContacts.Any(c => c.PhoneNumber == newContact.PhoneNumber))
            {
                throw new Exception("There already is contact with this phone number.");
            }

            PhoneBook phoneBook = GetPhoneBookById(newContact.PhoneBookId);

            Contact contact = new Contact
            {
                Name = newContact.Name,
                PhoneNumber = newContact.PhoneNumber,
                Description = newContact.Description
            };

            phoneBook.Contacts.Add(contact);

            _phoneBookRepository.SaveChanges();
        }

        public void DeleteContactById(int phoneBookId, int contactId)
        {
            PhoneBook phoneBook = GetPhoneBookById(phoneBookId);

            List<Contact> contacts = _contactRepository.GetAll();
            Contact contact = contacts.Single(c => c.Id == contactId);

            phoneBook.Contacts.Remove(contact);
            _contactRepository.Delete(contact);
        }
    }
}