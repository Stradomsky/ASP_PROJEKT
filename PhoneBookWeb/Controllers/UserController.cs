using Microsoft.AspNetCore.Mvc;
using PhoneBookApp.Data.Entities;
using PhoneBookApp.Logic.Models;
using PhoneBookApp.Logic.Services.TimeZoneApi;
using PhoneBookApp.Logic.Services.Users;

namespace PhoneBookApp.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ITimeZoneApiService _timeZoneApiService;

        public UserController(IUserService userService, ITimeZoneApiService timeZoneApiService)
        {
            _userService = userService;
            _timeZoneApiService = timeZoneApiService;
        }

        [HttpGet]
        public IActionResult PersonalData()
        {
            if (_userService.SignedIn)
            {
                ViewBag.Premium = "Premium user";
                ViewBag.Standard = "Standard user";

                TimeZoneApiResult timeZoneApiResult = _timeZoneApiService.GetTimeZone("Europe", "Warsaw");

                PersonalDataPack personalDataPack = new PersonalDataPack
                {
                    User = _userService.SignedInUser,
                    TimeZoneApiResult = timeZoneApiResult
                };

                return View(personalDataPack);
            }
            else
            {
                // TODO: Utworzyć widok braku dostępu
                return View("NoAccess");
            }
        }

        //[HttpPost]
        //public IActionResult PersonalData(PersonalData personalData)
        //{
        //    return Ok();
        //}

        [HttpGet]
        public IActionResult PersonalDataEdition()
        {
            if (_userService.SignedIn)
            {
                PersonalDataEdition personalDataEdition = new PersonalDataEdition
                {
                    Name = _userService.SignedInUser.PersonalData.Name,
                    Surname = _userService.SignedInUser.PersonalData.Surname,
                    Age = _userService.SignedInUser.PersonalData.Age,
                    EmailAddress = _userService.SignedInUser.PersonalData.EmailAddress,
                };

                // TODO: przekazać model personal data i uzupełnić kontrolki danymi personalnymi usera
                return View(personalDataEdition);
            }
            else
            {
                // TODO: Utworzyć widok braku dostępu
                return View("NoAccess");
            }

        }

        [HttpPost]
        public IActionResult PersonalDataEdition(PersonalDataEdition personalDataEdition)
        {
            if (ModelState.IsValid)
            {
                _userService.PersonalDataEdition(personalDataEdition);
                return Redirect("../User/PersonalData");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangePassword changePassword)
        {
            if (ModelState.IsValid)
            {
                _userService.ChangePassword(changePassword);
                return Redirect("../User/PersonalData");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult UpgradeUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpgradeUser(PremiumCode premiumCode)
        {
            if (ModelState.IsValid)
            {
                _userService.UpgradeUser(premiumCode);
                return Redirect("../User/PersonalData");
            }
            else
            {
                return View();
            }
        }
    }
}
