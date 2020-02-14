using System.Threading.Tasks;

namespace PeTelecom.Modules.UserAccess.Domain.UserRegistrations
{
    public interface IUserRegistrationRepository
    {
        Task AddAsync(UserRegistration userRegistration);
        Task<UserRegistration> GetByIdAsync(UserRegistrationId userRegistrationId);
        Task<int> CountUsersWithLogin(string login);
    }
}
