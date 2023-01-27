using PhoneBookApp.Data.Entities;
using PhoneBookApp.Data.Repositories;
using PhoneBookApp.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBookApp.Logic.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        private readonly int _premiumPhoneBookMaxSize = 100;

        public bool SignedIn => SignedInUser != null;

        public User SignedInUser { get; set; }

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public bool SignIn(Credentials credentials)
        {
            List<User> users = _userRepository.GetAll();

            User user = users.SingleOrDefault(u => u.Login == credentials.Login && u.Password == credentials.Password);

            bool signInSuccess = user != null;

            if (signInSuccess)
            {
                SignedInUser = user;
            }

            return signInSuccess;
        }

        public void SignUp(NewUser newUser)
        {
            if (newUser.RepeatedPassword != newUser.Password)
            {
                throw new Exception("Repeated password isn't identical");
            }

            User signingUpUser = new User
            {
                Login = newUser.Login,
                Password = newUser.Password,
                PersonalData = new PersonalData
                {
                    EmailAddress = newUser.EmailAddress
                }
            };

            _userRepository.Add(signingUpUser);

            SignedInUser = signingUpUser;
        }

        public void PersonalDataEdition(PersonalDataEdition personalDataEdition)
        {
            SignedInUser.PersonalData.Name = personalDataEdition.Name;
            SignedInUser.PersonalData.Surname = personalDataEdition.Surname;
            SignedInUser.PersonalData.Age = personalDataEdition.Age;
            SignedInUser.PersonalData.EmailAddress = personalDataEdition.EmailAddress;

            _userRepository.SaveChanges();
        }

        public void ChangePassword(ChangePassword changePassword)
        {
            bool isOldPasswordCorrect = SignedInUser.Password == changePassword.OldPassword;

            if (!isOldPasswordCorrect)
            {
                throw new Exception("Current password is incorrect.");
            }

            bool isNewPasswordTheSameAsRepeated = changePassword.NewPassword == changePassword.RepeatedNewPassword;

            if (!isNewPasswordTheSameAsRepeated)
            {
                throw new Exception("New passwords do not match.");
            }

            SignedInUser.Password = changePassword.NewPassword;
            _userRepository.SaveChanges();
        }

        public void UpgradeUser(PremiumCode premiumCode)
        {
            if (premiumCode.ActivationCode == "QWERTY123" || premiumCode.ActivationCode == "ASDFG456")
            {
                SignedInUser.IsPremium = true;

                foreach (PhoneBook phoneBook in SignedInUser.PhoneBooks)
                {
                    phoneBook.MaxSize = _premiumPhoneBookMaxSize;
                }

                _userRepository.SaveChanges();
            }
        }

        public void LogOut()
        {
            SignedInUser = null;
        }
    }
}