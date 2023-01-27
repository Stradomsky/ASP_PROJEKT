using PhoneBookApp.Data.Entities;
using PhoneBookApp.Logic.Models;

namespace PhoneBookApp.Logic.Services.Users
{
    public interface IUserService
    {
        bool SignedIn { get; }

        User SignedInUser { get; }

        bool SignIn(Credentials credentials);

        void SignUp(NewUser newUser);

        void PersonalDataEdition(PersonalDataEdition personalDataEdition);

        void ChangePassword(ChangePassword changePassword);

        void UpgradeUser(PremiumCode premiumCode);

        void LogOut();
    }
}
