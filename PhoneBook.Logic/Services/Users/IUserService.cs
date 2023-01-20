namespace PhoneBookApp.Logic.Services.Users
{
    public interface IUserService 
    {
        bool SignIn(string login, string password);
    }
}
