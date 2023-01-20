using PhoneBookApp.Data.Entities;
using PhoneBookApp.Data.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBookApp.Logic.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public bool SignIn(string login, string password)
        {
            List<User> users = _userRepository.GetAll();

            bool userExists = users.Any(u => u.Login == login && u.Password == password);

            return userExists;
        }
    }
}
