namespace PeTelecome.Modules.UserAccess.Application.Authentication
{
    public interface IPasswordManager
    {
        string HashPassword(string password);
        bool VerifyPassword(string hashedPassword, string password);
    }
}