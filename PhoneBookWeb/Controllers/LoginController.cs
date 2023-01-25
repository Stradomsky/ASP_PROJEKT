using Microsoft.AspNetCore.Mvc;
using PhoneBookApp.Logic.Models;
using PhoneBookApp.Logic.Services.Users;
using System;

namespace PhoneBookApp.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult FAQ()
        {
            if (_userService.SignedIn)
            {
                return Redirect("../User/PersonalData");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            if(_userService.SignedIn)
            {

            }
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(Credentials credentials)
        {
            bool signInSuccess = _userService.SignIn(credentials);

            if (signInSuccess)
            {
                return Redirect("../User/PersonalData");
            }
            else
            {
                ViewBag.Error = "Lalala";
                return View();
            }
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(NewUser newUser)
        {
            try
            {
                _userService.SignUp(newUser);

                return Redirect("../User/PersonalData");
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View();
            }
        }
    }
}
