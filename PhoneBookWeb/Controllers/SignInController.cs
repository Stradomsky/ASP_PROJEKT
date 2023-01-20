using Microsoft.AspNetCore.Mvc;
using PhoneBookApp.Logic.Services.Users;
using PhoneBookApp.Web.Models;

namespace PhoneBookApp.Web.Controllers
{
    public class SignInController : Controller
    {
        private readonly IUserService _userService;

        public SignInController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(Credentials credentials)
        {
            bool signInSuccess = _userService.SignIn(credentials.Login, credentials.Password);

            if (signInSuccess)
            {
                return Redirect("PhoneBook/ShowAllPhoneBooks");
            }
            else
            {
                ViewBag.Error = "Lalala";
                return View();
            }
        }
    }
}
