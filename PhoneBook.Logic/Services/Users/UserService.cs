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

        public bool SignedIn => SignedInUser != null;

        public User SignedInUser { get; set; }

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public bool SignIn(Credentials credentials)
        {
            List<User> users = _userRepository.GetAll();

            User user = users.Single(u => u.Login == credentials.Login && u.Password == credentials.Password);

            bool signInSuccess = user != null;

            if (signInSuccess)
            {
                SignedInUser = user;
            }

            return signInSuccess;
        }

        public void SignUp(NewUser newUser)
        {
            if(newUser.RepeatedPassword != newUser.Password)
            {
                throw new Exception("Repeated password isn't identical");
            }

            User user = new User();
            user.Login = newUser.Login;
            user.Password = newUser.Password;
            user.PersonalData = new PersonalData();
            user.PersonalData.EmailAddress = newUser.EmailAddress;
            _userRepository.Add(user);

            SignedInUser = user;
        }
    }
}
