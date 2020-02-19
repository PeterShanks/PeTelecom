namespace PeTelecom.Modules.UserAccess.Domain.Users
{
    public interface IUsersCounter
    {
        int CountUsersWithLogin(string login);
    }
}
