using Microsoft.AspNetCore.Mvc;
using PhoneBookApp.Data.Entities;
using PhoneBookApp.Logic.Models;
using PhoneBookApp.Logic.Services.PhoneBooks;
using PhoneBookApp.Logic.Services.Users;
using System;
using System.Collections.Generic;

namespace PhoneBookApp.Controllers
{
    // IActionResult to interfejs (albo "kontrakt") dla wszystkiego co może zostać zwrócone do przeglądarki internetowej (albo po prostu dla żądania)
    public class PhoneBookController : Controller
    {
        // Zadanko domowe:
        // Podorabiać serwisy, z jakąś logiką, np walidacyjną (na jakieś błędne dane throw new Exception z odpowiednim komunikatem, a tu w kontrolerze try catch)
        // Pododawać dane testowe, żeby było na czym pracować

        private readonly IPhoneBookService _phoneBookService;
        private readonly IUserService _userService;

        public PhoneBookController(IPhoneBookService phoneBookService, IUserService userService)
        {
            _phoneBookService = phoneBookService;
            _userService = userService;
        }

        [HttpGet]
        [ResponseCache(NoStore = true)]
        public IActionResult ShowAllPhoneBooks()
        {
            if (_userService.SignedIn)
            {
                // Tu wszelki testowy kod !

                List<PhoneBook> phoneBooks = _phoneBookService.GetAllPhoneBooks();

                // Metoda View() będzie szukała widoku w lokacji Views/PhoneBook/Index.cshtml
                // A bierze się to ze "wzoru"                    Views/NazwaKontrolera/NazwaAkcji.cshtml
                return View(phoneBooks); 
            }
            else
            {
                return View("NoAccess");
            }
        }

        [HttpGet]
        [ResponseCache(NoStore = true)]
        public IActionResult CreatePhoneBook()
        {
            if (_userService.SignedIn)
            {
                return View();
            }
            else
            {
                return View("NoAccess");
            }
        }

        [HttpPost]
        [ResponseCache(NoStore = true)]
        public IActionResult CreatePhoneBook(PhoneBook phoneBook)
        {
            if (_userService.SignedIn)
            {
                _phoneBookService.CreatePhoneBook(_userService.SignedInUser, phoneBook);
                return Redirect("../PhoneBook/ShowAllPhoneBooks ");
            }
            else
            {
                return View("NoAccess");
            }
        }

        [HttpPost]
        [ResponseCache(NoStore = true)]
        public IActionResult EditPhoneBook(PhoneBook phoneBook)
        {
            if (_userService.SignedIn)
            {
                return View();
            }
            else
            {
                return View("NoAccess");
            }
        }

        [HttpGet]
        [ResponseCache(NoStore = true)]
        public IActionResult DeletePhoneBook(int phoneBookId)
        {
            if (_userService.SignedIn)
            {
                _phoneBookService.DeletePhoneBookById(phoneBookId);

                return Redirect("../PhoneBook/ShowAllPhoneBooks");
            }
            else
            {
                return View("NoAccess");
            }
        }

        [HttpGet]
        [ResponseCache(NoStore = true)]
        public IActionResult ShowContacts(int phoneBookId)
        {
            if (_userService.SignedIn)
            {
                PhoneBook phoneBook = _phoneBookService.GetPhoneBookById(phoneBookId);

                return View(phoneBook);
            }
            else
            {
                return View("NoAccess");
            }
        }

        [HttpGet]
        [ResponseCache(NoStore = true)]
        public IActionResult CreateContact(int phoneBookId)
        {
            if (_userService.SignedIn)
            {
                PhoneBook phoneBook = _phoneBookService.GetPhoneBookById(phoneBookId);

                ViewBag.PhoneBookId = phoneBook.Id;

                return View();
            }
            else
            {
                return View("NoAccess");
            }
        }

        [HttpPost]
        [ResponseCache(NoStore = true)]
        public IActionResult CreateContact(NewContact newContact)
        {
            if (_userService.SignedIn)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        _phoneBookService.AddContact(newContact);
                        return Redirect($"../PhoneBook/ShowContacts?phoneBookId={newContact.PhoneBookId}");
                    }
                    catch (Exception e)
                    {
                        ViewBag.ErrorMessage = e.Message;
                        ViewBag.PhoneBookId = newContact.PhoneBookId;
                        return View();
                    }
                }
                else
                {
                    ViewBag.PhoneBookId = newContact.PhoneBookId;
                    return View();
                }
            }
            else
            {
                return View("NoAccess");
            }
        }

        [HttpGet]
        [ResponseCache(NoStore = true)]
        public IActionResult DeleteContact(int phoneBookId, int contactId)
        {
            if (_userService.SignedIn)
            {
                _phoneBookService.DeleteContactById(phoneBookId, contactId);

                return Redirect($"../PhoneBook/ShowContacts?phoneBookId={phoneBookId}");
            }
            else
            {
                return View("NoAccess");
            }
        }
    }
}