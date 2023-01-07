using Microsoft.AspNetCore.Mvc;
using PhoneBookApp.Data.Configuration;
using PhoneBookApp.Data.Entities;
using PhoneBookApp.Logic.Services.PhoneBooks;
using PhoneBookApp.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PhoneBookApp.Controllers
{
    // IActionResult to interfejs (albo "kontrakt") dla wszystkiego co może zostać zwrócone do przeglądarki internetowej (albo po prostu dla żądania)
    public class PhoneBookController : Controller
    {
        // Zadanko domowe:
        // Podorabiać serwisy, z jakąś logiką, np walidacyjną (na jakieś błędne dane throw new Exception z odpowiednim komunikatem, a tu w kontrolerze try catch)
        // Pododawać dane testowe, żeby było na czym pracować

        private readonly IPhoneBookService _phoneBookService;

        public PhoneBookController(IPhoneBookService phoneBookService)
        {
            _phoneBookService = phoneBookService;
        }

        // W ramach testu niech metoda wyświetla jakieś tam kontakty z naszej apki
        public IActionResult Index()
        {
            // Tu wszelki testowy kod !

            List<PhoneBook> phoneBooks = _phoneBookService.GetAllPhoneBooks();

            return View(phoneBooks);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}