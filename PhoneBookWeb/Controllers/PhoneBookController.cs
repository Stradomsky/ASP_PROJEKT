using Microsoft.AspNetCore.Mvc;
using PhoneBookApp.Data.Entities;
using PhoneBookApp.Logic.Services.PhoneBooks;
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

        public PhoneBookController(IPhoneBookService phoneBookService)
        {
            _phoneBookService = phoneBookService;
        }

        // W ramach testu niech metoda wyświetla jakieś tam kontakty z naszej apki
        public IActionResult ShowAllPhoneBooks()
        {
            // Tu wszelki testowy kod !

            List<PhoneBook> phoneBooks = _phoneBookService.GetAllPhoneBooks();

            // Metoda View() będzie szukała widoku w lokacji Views/PhoneBook/Index.cshtml
            // A bierze się to ze "wzoru"                    Views/NazwaKontrolera/NazwaAkcji.cshtml
            return View(phoneBooks);
        }
    }
}