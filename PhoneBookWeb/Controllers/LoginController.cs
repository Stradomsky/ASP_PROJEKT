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
                return FAQLogged();
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult FAQLogged()
        {
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            if (_userService.SignedIn)
            {

            }

            return View();
        }

        [HttpPost]
        public IActionResult SignIn(Credentials credentials)
        {
            if (ModelState.IsValid)
            {
                bool signInSuccess = _userService.SignIn(credentials);

                if (signInSuccess)
                {
                    return Redirect("../User/PersonalData");
                }
                else
                {
                    ViewBag.ErrorMessage = "Incorrect credentials.";
                    return View();
                }
            }
            else
            {
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
            if (ModelState.IsValid)
            {
                try
                {
                    _userService.SignUp(newUser);

                    return Redirect("../User/PersonalData");
                }
                catch (Exception e)
                {
                    ViewBag.ErrorMessage = e.Message;
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult MainPage()
        {
            if (_userService.SignedIn)
            {
                return MainPageLogged();
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult MainPageLogged()
        {
            return View();
        }

        [HttpGet]
        public IActionResult LogOut()
        {
            _userService.LogOut();
            return Redirect("../Login/SignIn");
        }
    }
}
