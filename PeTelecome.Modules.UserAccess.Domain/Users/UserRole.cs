using PeTelecome.BuildingBlocks.Domain;

namespace PeTelecome.Modules.UserAccess.Domain.Users
{
    public class UserRole: ValueObject
    {
        public static UserRole Client => new UserRole(nameof(Client));
        public string Value { get; }
        public UserRole(string value)
        {
            Value = value;
        }
    }
}
