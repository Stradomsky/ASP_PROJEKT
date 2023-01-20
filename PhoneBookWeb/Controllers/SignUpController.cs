using Microsoft.AspNetCore.Mvc;
using PhoneBookApp.Logic.Services.Users;
using PhoneBookApp.Web.Models;

namespace PhoneBookApp.Web.Controllers
{
    public class SignUpController : Controller
    {
        private readonly IUserService _userService;

        public SignUpController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }   

        [HttpPost]
        public IActionResult SignIn(Credentials credentials)
        {
            return View();
        }
    }
}
