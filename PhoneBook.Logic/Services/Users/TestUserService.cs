using PhoneBookApp.Data.Entities;
using PhoneBookApp.Logic.Models;

namespace PhoneBookApp.Logic.Services.Users
{
    public class TestUserService : IUserService
    {
        private readonly User _testUser = new User
        {
            Login = "test",
            Password = "test"
        };

        public bool SignedIn => true;

        public User SignedInUser { get; }

        public TestUserService()
        {
            SignedInUser = _testUser;
        }

        public bool SignIn(Credentials credentials)
        {
            throw new System.NotImplementedException();
        }

        public void SignUp(NewUser newUser)
        {
            throw new System.NotImplementedException();
        }

        public void PersonalDataEdition(PersonalDataEdition personalDataEdition)
        {
            throw new System.NotImplementedException();
        }

        public void ChangePassword(ChangePassword changePassword)
        {
            throw new System.NotImplementedException();
        }

        public void UpgradeUser(PremiumCode premiumCode)
        {
            throw new System.NotImplementedException();
        }

        public void LogOut()
        {
            throw new System.NotImplementedException();
        }
    }
}