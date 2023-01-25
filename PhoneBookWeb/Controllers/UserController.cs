using Microsoft.AspNetCore.Mvc;
using PhoneBookApp.Data.Entities;
using PhoneBookApp.Logic.Services.Users;

namespace PhoneBookApp.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult PersonalData()
        {
            if (_userService.SignedIn)
            {                
                return View();
            }
            else
            {
                // TODO: Utworzyć widok braku dostępu
                return View("NoAccess");
            }

        }

        [HttpPost]
        public IActionResult PersonalData(PersonalData personalData)
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult PersonalDataEdition()
        {
            if (_userService.SignedIn)
            {
                // TODO: przekazać model personal data i uzupełnić kontrolki danymi personalnymi usera
                return View();
            }
            else
            {
                // TODO: Utworzyć widok braku dostępu
                return View("NoAccess");
            }

        }

        [HttpPost]
        public IActionResult PersonalDataEdition(PersonalData personalData)
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UpgradeUser()
        {
            return View();
        }
    }
}
